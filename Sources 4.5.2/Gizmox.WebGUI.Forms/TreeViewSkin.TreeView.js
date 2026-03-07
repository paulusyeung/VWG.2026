/// <page name="TreeView.js">
/// <summary>
/// This script is used as a treeview script.
/// </summary>

var mintTreeViewClickTimeout = 0;

/// <method name="TreeView_HandleEvent">
/// <summary>
/// 
/// </summary>
function TreeView_HandleEvent(strGuid, strTreeViewGuid, strEvent, objWindow, objEvent)
{
    // Get the event source
    var objSource = Web_GetEventSource(objEvent);

    // If there is a valid event source
    if (objSource)
    {
        // Get the source type
        var strSourceType = Web_GetAttribute(objSource, "vwgtype");

        // If is a key down event
        if (strEvent == "keydown")
        {
            TreeView_KeyDown(strGuid, objWindow, objEvent);
        }
        else
        {
            // Check the source type
            switch (strSourceType)
            {
                case "label":
                case "text":
                case "icon":
                    switch (strEvent)
                    {
                        case "mousedown":
                            //check if its right click
                            if (Web_IsRightClick(objEvent))
                            {
                                //get tree node XML
                                var objNode = Data_GetNode(strGuid);

                                //search SelectOnRightClick attribute all the node path to the tree view
                                objNode = Xml_SelectSingleNode("ancestor-or-self::*[@Attr.Id=" + strTreeViewGuid + "or @Attr.SelectOnRightClick!=''][1]", objNode);

                                //check if the current node have SelectOnRightClick
                                if (Xml_IsAttribute(objNode, "Attr.SelectOnRightClick", "1"))
                                {
                                    TreeView_DoNodeAction(strGuid, objWindow, false, objEvent);
                                }
                            }
                            break;

                        case "click":
                            TreeView_DoNodeAction(strGuid, objWindow, false, objEvent);
                            break;
                    }
                    break;

                case "joint":
                    // Get treeview node
                    var objTreeViewNode = Data_GetNode(strTreeViewGuid);

                    if (strEvent == "click")
                    {
                        var strClickSourceId = strGuid;
                        var objClickSource = null;

                        // Check if click event should be fired on tree node while toggling.
                        if (Xml_IsAttribute(objTreeViewNode, "Attr.TreeNodeClickEventsOnToggle", "0"))
                        {
                            strClickSourceId = strTreeViewGuid;

                            // Get treeview element
                            objClickSource = Web_GetElementByDataId(strClickSourceId, objWindow);
                        }

                        // Toggle tree node and if the toggle or the click are critical call Web_OnClick
                        if (TreeView_Toggle(strGuid, objWindow, objEvent, true) || Data_IsCriticalEvent(strClickSourceId, "Event.Click"))
                        {
                            Web_OnClick(objEvent, objWindow, true, objClickSource);
                        }
                        else
                        {
                            //cancel bubble
                            Web_EventCancelBubble(objEvent);
                        }
                    }
                    else if (strEvent == "dblclick")
                    {
                        // Check if double click event should be fired on tree node while toggling.
                        if (Xml_IsAttribute(objTreeViewNode, "Attr.TreeNodeClickEventsOnToggle", "0"))
                        {
                            //check if the DoubleClick event is critical
                            if (Data_IsCriticalEvent(strTreeViewGuid, "Event.DoubleClick"))
                            {
                                //fire DoubleClick with the TreeView as source
                                Web_OnDblClick(objEvent, objWindow, true, Web_GetElementByDataId(strTreeViewGuid, objWindow));
                            }
                            else
                            {
                                //cancel bubble
                                Web_EventCancelBubble(objEvent);
                            }
                        }
                    }
                    break;

                case "checkbox":
                    if (strEvent == "click")
                    {
                        //CheckedChanged event
                        TreeView_Checked(strGuid, objSource, objWindow);

                        //cancel bubble, since checkbox click does not fire Click and Select events in WinForms
                        Web_EventCancelBubble(objEvent, false, true);
                    }
                    break;
            }
        }
    }
}
/// </method>

/// <method name="TreeView_KeyDown">
/// <summary>
/// Handles node keydown
/// </summary>
function TreeView_KeyDown(strGuid, objWindow, objEvent)
{
    // Get key code
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // Check for valid Key Code
    if (intKeyCode)
    {
        // Check if valid navigation key
        if (Web_IsNavigationKey(intKeyCode))
        {
    // find selected node in treeview
            var objTreeViewNode = Data_GetNode(strGuid);

            if (objTreeViewNode)
    {
                // Get current selected node
                var objNode = Xml_SelectSingleNode(".//Tags.TreeNode[@Attr.Selected='1']", objTreeViewNode);

                var objNewNode = null;

                // If current node is not null then navigate on tree nodes
                if (objNode)
    {
        switch (intKeyCode)
        {
            case mcntLeftKey:
                            objNewNode = TreeView_MoveLeft(objNode, objWindow, objEvent);
                break;
            case mcntUpKey:
                            objNewNode = TreeView_MoveUp(objNode);
                break;
            case mcntRightKey:
                            objNewNode = TreeView_MoveRight(objNode, objWindow, objEvent);
                break;
            case mcntDownKey:
                            objNewNode = TreeView_MoveDown(objNode);
                break;
            case mcntEndKey:
                            objNewNode = TreeView_MoveEnd(objTreeViewNode);
                break;
            case mcntHomeKey:
                            objNewNode = TreeView_MoveHome(objTreeViewNode);
                break;
            case mcntPageUpKey:
                            objNewNode = TreeView_PageUp(objNode);
                break;
            case mcntPageDownKey:
                            objNewNode = TreeView_PageDown(objNode);
                break;
        }
                }
                else
                {
                    // select first node
                    objNewNode = Xml_SelectSingleNode(".//Tags.TreeNode", objTreeViewNode);
                }

                // Check for valid new node
                if (objNewNode)
        {
                    TreeView_DoNodeAction(Xml_GetAttribute(objNewNode, "Attr.Id"), objWindow, true, objEvent);
        }

        // Cancel default scrolling functionality.
        Web_EventCancelBubble(objEvent, true, false);
    }
}
    }
}
/// </method>

/// <method name="TreeView_IsCriticalEvent">
/// <summary>
/// Gets critical event value from the tree and the node
/// </summary>
function TreeView_IsCriticalEvent(strTreeViewGuid, strTreeNodeGuid, mintEventId)
{
    return Data_IsCriticalEvent(strTreeViewGuid, mintEventId) || Data_IsCriticalEvent(strTreeNodeGuid, mintEventId);
}
/// </method>


/// <method name="TreeView_Toggle">
/// <summary>
/// Expand node
/// </summary>
function TreeView_Toggle(strGuid, objWindow, objEvent, blnSuspendRaiseEvents)
{
    // Exit on disabled control
    if (Data_IsDisabled(strGuid)) return;

    // Define a raise event flag.
    var blnRaiseEvents = false;

    // Get node data
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Get node variables
        var blnExpanded = !Xml_IsAttribute(objNode, "Attr.Expanded", "0");
        var blnHasRedrawingParent = Xml_IsAttribute(objNode, "Attr.HasRedrawingParent", "1");
        var blnLoaded = !Xml_IsAttribute(objNode, "Attr.Loaded", "0");
        var blnSelected = Xml_IsAttribute(objNode, "Attr.Selected", "1");
        var blnHasNodes = Xml_IsAttribute(objNode, "Attr.HasNodes", "1");
		var objVwgEvent;

        if (blnHasNodes)
        {
            // If node is not loaded
            if (!blnLoaded)
            {
				objVwgEvent = Events_CreateEvent(strGuid, "FirstExpand");
                blnRaiseEvents = true;
            }
            else
            {
                // Get tree view node
                var objTreeNode = TreeView_GetTreeViewFromNode(objNode);
                if (objTreeNode)
                {
                    // Get the tree id
                    var strTreeGuid = Xml_GetAttribute(objTreeNode, "Id");

                    // If is expand
                    if (!blnExpanded)
                    {
                        // Create the expand event
						objVwgEvent = Events_CreateEvent(strGuid, "Expand");

                        // Set the raise event if needed
						blnRaiseEvents = blnRaiseEvents || TreeView_IsCriticalEvent(strTreeGuid, strGuid, "Event.Expand");
                    }
                    else
                    {
                        // Create the collapse event
						objVwgEvent = Events_CreateEvent(strGuid, "Collapse");

                        // Set the raise event if needed
						blnRaiseEvents = blnRaiseEvents || TreeView_IsCriticalEvent(strTreeGuid, strGuid, "Event.Collapse");
                    }

                    // Set sub nodes display status
                    var objSubs = Web_GetWebElement("VWGSUBS_" + strGuid, objWindow);
                    if (objSubs)
                    {
                        // Set row visibility
                        Web_SetDisplayBlock(objSubs, !blnExpanded);
                    }

                    // Set expander image state
                    var objExpanderImage = Web_GetWebElement("VWGJOINT_" + strGuid, objWindow);
                    if (objExpanderImage)
                    {
                        Web_ReplaceBackgroundImage(objExpanderImage, blnExpanded ? "0.gif" : "1.gif", blnExpanded ? "1.gif" : "0.gif");
                    }

                    // Set state
                    Xml_SetAttribute(objNode, "Attr.Expanded", blnExpanded ? "0" : "1");

                    TreeView_ApplyIcon(objNode, objWindow);

                    // When the treeview parent's is redrawing it self and one of its loaded nodes is collapsed,
                    // we'll have to redraw the node so it will redraw its child nodes.
                    if (blnLoaded && blnHasRedrawingParent && !blnExpanded)
                    {
                        Controls_RedrawControlById(objWindow, strGuid);
                    }

                    // If need to raise event
                    if (blnRaiseEvents && !blnSuspendRaiseEvents)
                    {
                        Events_RaiseEvents();
                    }

					Events_ProcessClientEvent(objVwgEvent);
                }
            }
        }
    }

    return blnRaiseEvents;
}
/// </method>

function TreeView_ApplyIcon(objNode, objWindow)
{
    if (objNode)
    {
        if (objWindow)
        {

            var objIconImage = Web_GetWebElement("VWGICON_" + Xml_GetAttribute(objNode, "Id"), objWindow);
            if (objIconImage)
            {

                var strIcon = Xml_GetAttribute(objNode, "Attr.Image");
                var strSelectedIcon = Xml_GetAttribute(objNode, "Attr.SelectedImage");
                var strExpandedIcon = Xml_GetAttribute(objNode, "Attr.ExpandedImage");
                var blnHasNodes = Xml_IsAttribute(objNode, "Attr.HasNodes", "1") || Xml_HasNods("TN", objNode);
                var blnExpanded = !Xml_IsAttribute(objNode, "Attr.Expanded", "0") && blnHasNodes;

                var blnIsSelected = Xml_IsAttribute(objNode, "Attr.Selected", "1");

                if (!blnExpanded && !blnIsSelected)
                {
                    Web_SetBackgroundImage(objIconImage, strIcon);
                }
                else if (!blnExpanded && blnIsSelected)
                {

                    if (!Web_IsEmptyOrNull(strSelectedIcon))
                    {
                        Web_SetBackgroundImage(objIconImage, strSelectedIcon);
                    }
                    else
                    {
                        Web_SetBackgroundImage(objIconImage, strIcon);
                    }
                }
                else if (blnExpanded && blnIsSelected)
                {
                    if (!Web_IsEmptyOrNull(strSelectedIcon))
                    {
                        Web_SetBackgroundImage(objIconImage, strSelectedIcon);
                    }
                    else if (!Web_IsEmptyOrNull(strExpandedIcon))
                    {
                        Web_SetBackgroundImage(objIconImage, strExpandedIcon);
                    }
                    else
                    {
                        Web_SetBackgroundImage(objIconImage, strIcon);
                    }
                }
                else
                {
                    if (!Web_IsEmptyOrNull(strExpandedIcon))
                    {
                        Web_SetBackgroundImage(objIconImage, strExpandedIcon);
                    }
                    else
                    {
                        Web_SetBackgroundImage(objIconImage, strIcon);
                    }
                }
            }
        }
    }
}




function TreeView_GetTreeViewFromNode(objNode)
{
    var objCurrent = objNode;
    while (objCurrent.nodeName != "WC:TV")
    {
        objCurrent = objCurrent.parentNode;
    }
    return objCurrent;
}


/// <method name="TreeView_Checked">
/// <summary>
///
/// </summary>
function TreeView_Checked(strGuid, objElement, objWindow)
{

    // Exit on disabled control
    if (Data_IsDisabled(strGuid)) return;

    // Get node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        var objTreeNode = TreeView_GetTreeViewFromNode(objNode);
        if (objTreeNode)
        {

            // set checked flag
            var blnChecked = false;

            // check current image state
            if (Xml_IsAttribute(objNode, "Attr.Checked", "1"))
            {
                //Check if a state image exist
                if (Xml_HasAttribute(objTreeNode, "Attr.StateImageUnchecked"))
                {
                    // set the unchecked state image
                    Web_SetBackgroundImage(objElement, Xml_GetAttribute(objTreeNode, "Attr.StateImageUnchecked"));
                }
                else
                {
                    // turn check box off
                    Web_ReplaceBackgroundImage(objElement, "1.gif", "0.gif");
                }



                Xml_SetAttribute(objNode, "Attr.Checked", "0");
                blnChecked = false;
            }
            else
            {

                //Check if a state image exist
                if (Xml_HasAttribute(objTreeNode, "Attr.StateImageChecked"))
                {
                    // set the unchecked state image
                    Web_SetBackgroundImage(objElement, Xml_GetAttribute(objTreeNode, "Attr.StateImageChecked"));
                }
                else
                {
                    // turn check box on
                    Web_ReplaceBackgroundImage(objElement, "0.gif", "1.gif");
                }

                Xml_SetAttribute(objNode, "Attr.Checked", "1");
                blnChecked = true;
            }

            var strTreeGuid = Xml_GetAttribute(objTreeNode, "Id");

            // Create event and raise if critical
            var objEvent = Events_CreateEvent(strGuid, "CheckedChange", true);
            Events_SetEventAttribute(objEvent, "Value", blnChecked ? "1" : "0");

            if (Data_IsCriticalEvent(objTreeNode, "Event.CheckedChange", true) || Data_IsCriticalEvent(objNode, "Event.CheckedChange", true)) Events_RaiseEvents();
            
            Events_ProcessClientEvent(objEvent);
        }
    }
}
/// </method>

/// <method name="TreeView_DoNodeAction">
/// <summary>
/// Handles the node click / double click / keydown events
/// </summary>
function TreeView_DoNodeAction(strCurrentNodeDataId, objWindow, blnIsKeyboard, objEvent)
{
    // Exit on disabled control
    if (!Data_IsDisabled(strCurrentNodeDataId))
    {
        // Get the node which is to be selected
        var objCurrentNode = Data_GetNode(strCurrentNodeDataId);
        if (objCurrentNode)
        {
            // Get tree view node
            var objTreeViewNode = TreeView_GetTreeViewFromNode(objCurrentNode);

            // Define an empty previous node data id.
            var strPreviousNodeDataId = "";

            // Get previously selected node.
            var objPreviousNode = Xml_SelectSingleNode("./" + "/TN[@Attr.Selected='1']", objTreeViewNode);
            if (objPreviousNode)
            {
                // Get previously selected node id
                strPreviousNodeDataId = Xml_GetAttribute(objPreviousNode, "Attr.Id", "");
            }

            // If node has been changed.
            if (strPreviousNodeDataId != strCurrentNodeDataId)
            {
                // Check if label editing is enabled.
                var blnLabelEditingEnabled = Xml_IsAttribute(objTreeViewNode, "Attr.LabelEdit", "1");

                // Validate previous node data id.
                if (!Aux_IsNullOrEmpty(strPreviousNodeDataId))
                {
                    // Set previos node's selected attribute value.
                    Xml_SetAttribute(objPreviousNode, "Attr.Selected", "0");

                    // Apply a proper icon to the previos node element.
                    TreeView_ApplyIcon(objPreviousNode, objWindow);

                    // Get previously selected node element.
                    var objPreviousElement = Web_GetWebElement("VWGNODE_" + strPreviousNodeDataId, objWindow);
                    if (objPreviousElement)
                    {
                        // Apply unselected style on previos node's element.
                        Web_SetUnselectedElement(objPreviousElement, objWindow);
                    }

                    if (blnLabelEditingEnabled)
                    {
                        // Get previous label element.
                        var objPreviousLabelElement = Web_GetWebElement("VWGLE_" + strPreviousNodeDataId, objWindow);
                        if (objPreviousLabelElement)
                        {
                            // Flag that previous label element is not editable.
                            Web_SetAttribute(objPreviousLabelElement, "vwglabeledit", "0");
                        }
                    }
                }

                // Set current node's selected attribute value.
                Xml_SetAttribute(objCurrentNode, "Attr.Selected", "1");

                // Apply a proper icon to the current node element.
                TreeView_ApplyIcon(objCurrentNode, objWindow);

                // Get current tree node
                var objCurrentElement = Web_GetWebElement("VWGNODE_" + strCurrentNodeDataId, objWindow);
                if (objCurrentElement)
                {
                    // Scroll iinto view.
                    Web_ScrollIntoView(objCurrentElement);

                    // Apply selected style on current node's element.
                    Web_SetSelectedElement(objCurrentElement, objWindow);
                }

                if (blnLabelEditingEnabled)
                {
                    // Get current label element.
                    var objCurrentLabelElement = Web_GetWebElement("VWGLE_" + strCurrentNodeDataId, objWindow);
                    if (objCurrentLabelElement)
                    {
                        // Flag that current label element is editable asynchronicly so that current click won't start editing.
                        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_SetAttribute, objCurrentLabelElement, "vwglabeledit", "1"), 10);
                    }
                }

    	        var objActionEvent = null;
	    		
                // Flag if keyboard source.
                if (blnIsKeyboard)
                {
                    // Create a selection change event.
	                objActionEvent = Events_CreateEvent(strCurrentNodeDataId,"Selection",null,true,true);

                    Events_SetEventAttribute(objActionEvent, "Keyboard", "1");
                }

                // Check if selection change is critical.     
                if (Data_IsCriticalEvent(strCurrentNodeDataId, "Event.SelectionChange"))
                {
                    if (blnIsKeyboard)
                    {
                        // Add a key down event and raise events.
	                	Web_OnKeyDown(objEvent, objWindow, true);
                    }
                    else
                    {
                        if (Web_IsRightClick(objEvent))
                        {
                            // if Right Click is critical then the context menu right click will raise the event
                            if (!Data_IsCriticalEvent(strCurrentNodeDataId, "Event.RightClick"))
                            {
                                // Add a right click event and raise events.
                                Web_OnRightClick(objEvent, objWindow, true);
                            }
                        }
                        else
                        {
                            // Add a click event and raise events.
                            Web_OnClick(objEvent, objWindow, true);
                        }
                    }
                }

	            if (objActionEvent)
                {
	                Events_ProcessClientEvent(objActionEvent);
                }
            }
        }
    }
}
/// </method>

/// <method name="TreeView_MoveUp">
/// <summary>
///
/// </summary>
/// <param name="objNode"></param>
/// <returns>next higher visible node</returns>
function TreeView_MoveUp(objNode)
{
    var objCurrentNode = null;

    if (objNode.previousSibling)
    {
        objCurrentNode = TreeView_GetLastVisibleChild(objNode.previousSibling);
    }
    else if (objNode.parentNode && objNode.parentNode.nodeName == "TN")
    {
        objCurrentNode = objNode.parentNode;
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_GetLastVisibleChild">
/// <summary>
/// Traverse branch beginning with objNode until either node is collapsed or is leaf
/// </summary>
/// <param name="objNode"></param>
/// <returns>last visible node in the branch</returns>
function TreeView_GetLastVisibleChild(objNode)
{
    var objCurrentNode = objNode;

    while (!Xml_IsAttribute(objCurrentNode, "Attr.Expanded", "0") && objCurrentNode.lastChild)
    {
        objCurrentNode = objCurrentNode.lastChild;
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_MoveDown">
/// <summary>
///
/// </summary>
/// <param name="objNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_MoveDown(objNode)
{
    var objCurrentNode = null;

    if (objNode.firstChild && (!Xml_IsAttribute(objNode, "Attr.Expanded", "0")))
    {
        objCurrentNode = objNode.firstChild;
    }
    else if (objNode.nextSibling)
    {
        objCurrentNode = objNode.nextSibling;
    }
    else
    {
        while (objNode.parentNode.nodeName == "TN" && objCurrentNode == null)
        {
            if (objNode.parentNode.nextSibling)
            {
                objCurrentNode = objNode.parentNode.nextSibling;
            }
            else
            {
                objNode = objNode.parentNode;
            }
        }
    }

    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_MoveRight">
/// <summary>
///
/// </summary>
/// <param name="objNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_MoveRight(objNode, objWindow, objEvent)
{
    var objCurrentNode = null;

    if (Xml_IsAttribute(objNode, "Attr.Expanded", "0"))
    {
        if (TreeView_Toggle(Xml_GetAttribute(objNode, "Attr.Id"), objWindow, objEvent, true))
        {
            Web_OnKeyDown(objEvent, objWindow, true);
        }
    }
    else if (objNode.firstChild)
    {
        objCurrentNode = objNode.firstChild;
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_MoveLeft">
/// <summary>
///
/// </summary>
/// <param name="objNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_MoveLeft(objNode, objWindow, objEvent)
{
    var objCurrentNode = null;

    if (!Xml_IsAttribute(objNode, "Attr.Expanded", "0") && objNode.childNodes.length > 0)
    {
        if (TreeView_Toggle(Xml_GetAttribute(objNode, "Attr.Id"), objWindow, objEvent, true))
        {
            Web_OnKeyDown(objEvent, objWindow, true);
        }
    }
    else if (objNode.parentNode && objNode.parentNode.nodeName == "TN")
    {
        objCurrentNode = objNode.parentNode;
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_MoveHome">
/// <summary>
///
/// </summary>
/// <param name="objTreeViewNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_MoveHome(objTreeViewNode)
{
    var objCurrentNode = null;

    if (objTreeViewNode.firstChild)
    {
        objCurrentNode = objTreeViewNode.firstChild;
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_MoveEnd">
/// <summary>
///
/// </summary>
/// <param name="objTreeViewNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_MoveEnd(objTreeViewNode)
{
    var objCurrentNode = null;

    if (objTreeViewNode.lastChild)
    {
        objCurrentNode = TreeView_GetLastVisibleChild(objTreeViewNode.lastChild);
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_PageDown">
/// <summary>
///
/// </summary>
/// <param name="objNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_PageDown(objNode)
{
    var objCurrentNode = null;

    if (TreeView_MoveDown(objNode))
    {
        objCurrentNode = objNode;
        var i = 0;
        do
        {
            objCurrentNode = TreeView_MoveDown(objCurrentNode);
            i++;
        } while (TreeView_MoveDown(objCurrentNode) && i < 10)
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_PageUp">
/// <summary>
///
/// </summary>
/// <param name="objNode"></param>
/// <returns>next lower visible node</returns>
function TreeView_PageUp(objNode)
{
    var objCurrentNode = null;

    if (TreeView_MoveUp(objNode))
    {
        objCurrentNode = objNode;
        var i = 0;
        do
        {
            objCurrentNode = TreeView_MoveUp(objCurrentNode);
            i++;
        } while (TreeView_MoveUp(objCurrentNode) && i < 10)
    }
    return objCurrentNode;
}
/// </method>

/// <method name="TreeView_AfterCreateTreeNodeEvents">
/// <summary>
///	
/// </summary>
function TreeView_AfterCreateTreeNodeEvents(objWindow, objEvent, strSourceDataId, strEventType, strTargetDataId)
{
    if (strEventType == "Click")
    {
        // Validate recieved arguments.
    	if (!Aux_IsNullOrEmpty(strSourceDataId)) {

    		var objVwgEvent = Events_CreateEvent(strSourceDataId, "Selection", null, true, true);

    		Events_ProcessClientEvent(objVwgEvent);
        }
    }
}
/// </method>