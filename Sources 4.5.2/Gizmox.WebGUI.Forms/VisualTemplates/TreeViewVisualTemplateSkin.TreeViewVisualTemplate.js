/// <method name="TreeViewVisualTemplate_HandleEvent">
/// <summary>
/// 
/// </summary>
function TreeViewVisualTemplate_HandleEvent(strGuid, strTreeViewGuid, strEvent, objWindow, objEvent)
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
                case "icon":
                case "label":
                case "text":
                    switch (strEvent)
                    {
                        case "mousedown":
                        case "click":
                            TreeViewVisualTemplate_Click(strEvent, strGuid, strTreeViewGuid, strEvent, objWindow, objEvent);
                            break;
                    }
                    break;
                case "joint":                    
                    switch (strEvent)
                    {
                        case "dblclick":
                        case "click":
                            TreeViewVisualTemplate_Click(strEvent, strGuid, strTreeViewGuid, strEvent, objWindow, objEvent);
                            break;
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

/// <method name="TreeViewVisualTemplate_Click">
/// <summary>
/// 
/// </summary>
function TreeViewVisualTemplate_Click(strEvent, strGuid, strTreeViewGuid, strEvent, objWindow, objEvent)
{
    // Get treeview node
    var objTreeViewNode = Data_GetNode(strTreeViewGuid);

    if (strEvent == "click")
    {
        var strClickSourceId = strGuid;
        var objClickSource = null;

        TreeView_DoNodeAction(strGuid, objWindow, false, objEvent);

        // Check if click event should be fired on tree node while toggling.
        if (Xml_IsAttribute(objTreeViewNode, "Attr.TreeNodeClickEventsOnToggle", "0"))
        {
            strClickSourceId = strTreeViewGuid;

            // Get treeview element
            objClickSource = Web_GetElementByDataId(strClickSourceId, objWindow);
        }

        // Toggle tree node and if the toggle or the click are critical call Web_OnClick
        if (TreeViewVisualTemplate_Toggle(strGuid, objWindow, objEvent, true) || Data_IsCriticalEvent(strClickSourceId, "Event.Click"))
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
    else if (strEvent == "mousedown")
    {
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
    }
}


/// <method name="TreeViewVisualTemplate_Toggle">
/// <summary>
/// Expand node
/// </summary>
function TreeViewVisualTemplate_Toggle(strGuid, objWindow, objEvent, blnSuspendRaiseEvents)
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
        // Get tree view node
        var objTreeNode = TreeView_GetTreeViewFromNode(objNode);

        // Set the last view node page
        if (objTreeNode)
        {
            // Set state at the parent node
            Xml_SetAttribute(objTreeNode, "REQUESTEDVIEWEDNODEPAGE", strGuid);
        }

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

            if (objTreeNode)
            {                
                // Get the parentNode to get the container
                var objParentNode = objNode.parentNode;

                if (objParentNode.nodeName == "WC:Tags.TreeView" || objParentNode.nodeName == "Tags.TreeNode")
                {
                    var strParentGuid = Xml_GetAttribute(objParentNode, "Id"); 

                    // Set sub nodes display status
                    var objSubs = Web_GetWebElement("VWGSUBS_" + strParentGuid, objWindow);
                    if (objSubs)
                    {
                        // Set row visibility by css class                        
                        $(objSubs).addClass('TreeViewVisualTemplate-PaddingContainer_HiddenRight')
                    }
                    if (blnLoaded)
                    {
                        TreeViewVisualTemplate_NodesOnLoad(strGuid, objWindow, true);
                    }
                }
            }

        }
    }

    return blnRaiseEvents;
}
/// </method>

/// <method name="TreeViewVisualTemplate_NodesOnLoad">
/// <summary>
/// 
/// </summary>
function TreeViewVisualTemplate_NodesOnLoad(strGuid, objWindow, blnIsToShow)
{
    // Get node data
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Get tree view node
        var objTreeNode = TreeView_GetTreeViewFromNode(objNode);

        if (objTreeNode)
        {
            // Get the tree id
            var strTreeGuid = Xml_GetAttribute(objTreeNode, "Id");
            
            var objTreeNodesContainer = Web_GetWebElement("VWGTREECONTAINER_" + strTreeGuid, objWindow);

            // Get the subitems to show
            var objSubs = Web_GetWebElement("VWGSUBS_" + strGuid, objWindow);
            if (objSubs && objTreeNodesContainer)
            {
                // Appending the subsections to the section container (because leaving it inside the node, will make it move with the parent node)
                // Rendering it defferently at the moment didn't work, because the html is not refreshed due to infrustructure.
                $(objTreeNodesContainer).append(objSubs);

                if (blnIsToShow)
                {
                    // Set state at the parent node
                    Xml_SetAttribute(objTreeNode, "CURRENTVIEWEDNODEPAGE", strGuid);

                    // Call a function after the HTML is updated.
                    Web_SetTimeout(function ()
                    {
                        mobjApp.TreeViewVisualTemplate_ShowNodesAfterAppend(objSubs);
                    }, 0, objWindow);
                }
            }
        }
    }
}
/// </method>

/// <method name="TreeViewVisualTemplate_ShowNodesAfterAppend">
/// <summary>
/// Happens after a node is loded (through timer)
/// </summary>
function TreeViewVisualTemplate_ShowNodesAfterAppend(objSubs)
{
    if (objSubs)
    {
        // Set row visibility by css class                        
        $(objSubs).removeClass('TreeViewVisualTemplate-PaddingContainer_HiddenLeft');
    }
}
/// </method>

/// <method name="TreeViewVisualTemplate_BackOnClick">
/// <summary>
/// Happens when the back button is clicked.
/// </summary>
function TreeViewVisualTemplate_BackOnClick(strShownGuid, strParentGuid, objWindow, objEvent)
{
    var objShownSubs = Web_GetWebElement("VWGSUBS_" + strShownGuid, objWindow);
    var objParentSubs = Web_GetWebElement("VWGSUBS_" + strParentGuid, objWindow);

    if (objShownSubs && objParentSubs)
    {
        // Get node data
        var objNode = Data_GetNode(strParentGuid);

        // Get the treeView to update the nodes
        var objTreeNode = TreeView_GetTreeViewFromNode(objNode);

        // Set state at the parent node (Note - when clicking back, the previous node is already loaded)
        Xml_SetAttribute(objTreeNode, "CURRENTVIEWEDNODEPAGE", strParentGuid);

        // Set state at the parent node
        Xml_SetAttribute(objTreeNode, "REQUESTEDVIEWEDNODEPAGE", strParentGuid);

        // Set row visibility by css class                        
        $(objShownSubs).addClass('TreeViewVisualTemplate-PaddingContainer_HiddenLeft');

        // Set row visibility by css class
        $(objParentSubs).removeClass('TreeViewVisualTemplate-PaddingContainer_HiddenRight');
    }
}
/// </method>