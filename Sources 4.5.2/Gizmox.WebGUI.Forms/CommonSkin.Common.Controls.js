/// <page code="Controls" name="Control Services">
/// <summary>
/// This script is used as a shared script.
/// </summary>

/// <summary>
/// Stores the last scroll store timeout.
/// </summary>
var mintStoreScrollTimeout = 0;

/// <summary>
/// Stores the last scroll store guid.
/// </summary>
var mstrStoreScrollGuid = 0;

/// <summary>
/// Stores the last scroll store scroll element.
/// </summary>
var mobjStoreScrollScrollable = 0;

/// <method name="Controls_GetGuid">
/// <summary>
/// Gets the component or component member id
/// </summary>
/// <param name="objNode">The node to get its guid.</param>
function Controls_GetGuid(objNode)
{
    // Get component id
    var strGuid	= objNode.getAttribute("Id");
    
    // If is component
    if(strGuid)
    {
        // Return component guid
        return strGuid;
    }
    else
    {
        // Return component member guid
        return objNode.getAttribute("Attr.OwnerID") + "_" + objNode.getAttribute("Attr.MemberID");
    }
}
/// </method> 

/// <method name="Controls_IsUpdateableAttribute" access="private">
/// <summary>
/// 
/// </summary>
function Controls_IsUpdateableAttribute(objAttribute)
{
    if(objAttribute)
    {
        if (!Xml_IsNodeName(objAttribute, "Attr.Id") && !Xml_IsNodeName(objAttribute, "Attr.UseClientUpdateHandler"))
		{
            return true;
        }
    }

    return false;
}
/// </method> 

/// <method name="Controls_UpdateControlParams" access="private">
/// <summary>
/// Handles control param updating from application server
/// </summary>
/// <param name="objWindow">The browser window containing the node element.</param>
/// <param name="objSourceNode">The source node to copy from.</param>
/// <param name="objNodeScope">The node scope to search with in for target node.</param>
/// <param name="blnRedraw">A flag indicating if redraw is required after updating.</param>
/// <param name="blnDrawDelayedControls">Whether to draw delayed controls or not.</param>
function Controls_UpdateControlParams(objWindow, objSourceNode, objNodeScope, blnRedraw, blnShouldUseUpdateHandler, blnDrawDelayedControls)
{
    // Trace control updating
	Trace_Time("Controls","UpdateControlParams");
	
	// Get the control id to update
	var strGuid	= Controls_GetGuid(objSourceNode);
	
	// Reference to the client update handler
	var fncClientUpdateHandler = null;
	
	// Get the control data by the id
	var objTargetNode = Data_GetNode(strGuid,objNodeScope);

	var objTragetPreviousValues = {};

	// If there is a valid target node
	if(objTargetNode)
	{
		// Get all control attributes
		var objAttributes = Xml_SelectNodes("@*", objSourceNode);

		// Loop all updated attributes
		for(var intIndex=0; intIndex<objAttributes.length; intIndex++)
		{
			// Get current attribute
			var objAttribute = objAttributes[intIndex];
			
			// If is an updateable attribute.
			if(Controls_IsUpdateableAttribute(objAttribute))
			{
				// Save the Node's previous values of changed attributes
			    objTragetPreviousValues[objAttribute.nodeName] = XML_GetAttribute(objTargetNode, objAttribute.nodeName);
				// Set control attribute value
				Xml_SetAttribute(objTargetNode, objAttribute.nodeName, objAttribute.nodeValue);
			}
        }

		// If update handler should be used try to get it
	    if(blnShouldUseUpdateHandler)
	    {
	        // Get the client update handler if there is one
	        fncClientUpdateHandler = Controls_GetClientUpdateHandler(objTargetNode);
	    }	
		
		// Checks if parent forces child redraw.
        var blnRedrawChildren = Xml_IsAttribute(objSourceNode,"Attr.ForceChildRedraw","1");
        
        // If this node should be redrwan 
        if(!blnRedrawChildren && blnRedraw)
        {
            // Child nodes should be redrawn if there is a client update handler for current node.
            blnRedrawChildren = (fncClientUpdateHandler!=null);
        }
		
		// Get all sub nodes of the current node
		var objSubSourceNodes = Xml_SelectNodes("*", objSourceNode);
				
		// Loop all sub nodes
		for(var intIndex=0; intIndex < objSubSourceNodes.length; intIndex++)
		{
			// Get current sub element
			var objSubSourceNode = objSubSourceNodes[intIndex];
			
			// Continue recursing on the child node
			switch(objSubSourceNode.nodeName)
			{
				case "WC:Tags.UpdateParams":
				case "WG:Tags.UpdateParams":
                    // sub control should use an update handler only 
                    // if parent has one and is does not cause redrawing of its child elements.
	                Controls_UpdateControlParams(objWindow, objSubSourceNode, objTargetNode, blnRedrawChildren, fncClientUpdateHandler!=null,blnDrawDelayedControls);
					break;
					
				default:
					Controls_UpdateControl(objWindow, objSubSourceNode, blnRedrawChildren, blnDrawDelayedControls);
					break;
			}
        }

		// If there is a client update handler it should 
		// be used instead of redrawing the control
		if(fncClientUpdateHandler!=null)
        {
            fncClientUpdateHandler(objTargetNode, objTragetPreviousValues);
        }
		else
		{	        
		    // If node needs to be redrawn
	        if(blnRedraw)
		    {
			    Controls_RedrawControlByNode(objWindow,objTargetNode,!blnDrawDelayedControls);
		    }
		}
	}
}
/// </method>

/// <method name="Controls_GetClientUpdateHandler">
/// <summary>
/// Gets the client update handler from a given data node
/// </summary>
/// <param name="objNode">The data node.</param>
function Controls_GetClientUpdateHandler(objNode)
{
    var strUpdateHandler = Xml_GetAttribute(objNode,"Attr.ClientUpdateHandler");
    if(strUpdateHandler)
    {
        return Remoting_GetMethod(strUpdateHandler);
    }    
}
/// </method>


/// <method name="Controls_ExeceuteClientUpdateHandler">
/// <summary>
/// Execute the update handler of the received control.
/// </summary>
function Controls_ExeceuteClientUpdateHandler(objNode)
{
    if(objNode)
    {
        var fncClientUpdateHandler = Controls_GetClientUpdateHandler(objNode);
        if(fncClientUpdateHandler)
        {   
             fncClientUpdateHandler(objNode);
        }
    }
}
/// </method>


/// <method name="Controls_UpdateControl" access="private">
/// <summary>
/// Update the control data (optional rendering).
/// </summary>
/// <param name="objWindow">The browser window containing the node element.</param>
/// <param name="objResponseSourceNode">The source node to copy from.</param>
/// <param name="blnRedraw">A flag indicating if redraw is required after updating.</param>
/// <param name="blnDrawDelayedControls">Whether to draw delayed controls or not.</param>
function Controls_UpdateControl(objWindow, objResponseSourceNode, blnRedraw, blnDrawDelayedControls)
{
    if (objResponseSourceNode)
    {
        // Get control data id
        var strDataID = Controls_GetGuid(objResponseSourceNode);

        // Validate control data id
        if (!Aux_IsNullOrEmpty(strDataID))
        {
            // Get existing data node
            var objExistDataNode = Data_GetNode(strDataID);
            if (objExistDataNode)
            {
                var objRedrawnNode = objExistDataNode;

                // Check if xml was change
                if (Xml_GetOuterXML(objExistDataNode) != Xml_GetOuterXML(objResponseSourceNode))
                {
                    // Update control's node data
                    objRedrawnNode = Data_SetNode(strDataID, objResponseSourceNode.cloneNode(true));
                }

                // remove is dirty attribute attribute - if exist.
                if (Xml_HasAttribute(objRedrawnNode, "Attr.IsDirty"))
                {
                    Xml_RemoveAttribute(objRedrawnNode, "Attr.IsDirty");
                }

                if (blnRedraw)
                {
                    var fncClientUpdateHandler = null;

                    // Check if control should be update with client update handler
                    if (Xml_IsAttribute(objResponseSourceNode, "Attr.UseClientUpdateHandler", "1") &&
                        (fncClientUpdateHandler = Controls_GetClientUpdateHandler(objRedrawnNode)))
                    {
                        // remove use client update handler attribute - if exist.
                        Xml_RemoveAttribute(objRedrawnNode, "Attr.UseClientUpdateHandler");

                        // Excute client update handler function
                        fncClientUpdateHandler(objRedrawnNode);

                        // Get all control sub controls
                        var objRedrawnNodes = Xml_SelectNodes("descendant::*[@Attr.IsDirty=1 and not(ancestor::*[@Attr.IsDirty='1'])]", objRedrawnNode);

                        // Loop all dirty nodes.
                        for (var i = 0; i < objRedrawnNodes.length; i++)
                        {
                            var objRedrawnChildNode = objRedrawnNodes[i];
                            if (objRedrawnChildNode)
                            {
                                // Update control
                                Controls_UpdateControl(objWindow, objRedrawnChildNode, blnRedraw, blnDrawDelayedControls);
                            }
                        }
                    }
                    else
                    {
                        Controls_RedrawControlByNode(objWindow, objRedrawnNode, !blnDrawDelayedControls);
                    }
                }
            }
        }

        // In case that the updated control is sharing focus with an exist popup.
        if (Popups_ShareFocusWithExistPopup(strDataID))
        {
            // Hide pop-up of redrawn control.
            Popups_HideControlPopup(objWindow, strDataID);
        }
    }
}
/// </method>

/// <method name="Controls_RedrawControlById" access="private">
/// <summary>
/// Redraws an element according to the control ID.
/// </summary>
/// <param name="objWindow">The browser window containing the element.</param>
/// <param name="strGuid">The control ID (used to trace performance).</param>
/// <param name="blnExcludeDelayedControls">Whether to exclude delayed controls or not from drawing.</param>
function Controls_RedrawControlById(objWindow, strGuid, blnExcludeDelayedControls)
{
	var objNode	= Data_GetNode(strGuid,null);
	if(objNode)
	{
	    Controls_RedrawControlByNode(objWindow,objNode,blnExcludeDelayedControls);
	}
}
/// </method>

/// <method name="Controls_RefreshContainingIScroller">
/// <summary>
/// 
/// </summary>
function Controls_RefreshContainingIScroller(strDataId, objWindow)
{
    // Validate recieved data id.
    if (!Aux_IsNullOrEmpty(strDataId))
    {
        // Get element by id.
        var objElement = Web_GetElementByDataId(strDataId, objWindow);

        // Loop while an iScroll element is not found.
        while (objElement && !objElement.iScrollElement)
        {
            // Proceed to parent node.
            objElement = objElement.parentNode;
        }

        // Validte iScroll element.
        if (objElement)
        {
            // Perform element refresh
            if (objElement.calculateNewSize)
            {
                objElement.calculateNewSize();
            }
            if (objElement.iScrollElement)
            {
                // Perform iScroll refresh.
                objElement.iScrollElement.refresh();
            }
        }
    }
}
/// </method>

/// <method name="Controls_RedrawControlByNode">
/// <summary>
/// Redraws an element from the element node. 
/// </summary>
/// <param name="objWindow">The browser window containing the node element.</param>
/// <param name="objNode">The node to redraw its area.</param>
/// <param name="blnExcludeDelayedControls">Whether to exclude delayed controls or not from drawing.</param>
function Controls_RedrawControlByNode(objWindow,objNode,blnExcludeDelayedControls)
{
	// Get node id
	var strGuid = Controls_GetGuid(objNode);
	
	// Get node web element
	var objElement	= Web_GetWebElement(Web_GetWebId(strGuid),(objWindow ? objWindow : window));
	
	// If found element
	if(objElement!=null)
	{
	    // If delayed controls should be drawn
	    if(!blnExcludeDelayedControls)
	    {
		    // Clear delayed controls
		    Data_ClearIsDelayedDrawingFromChildren(objNode);
	    }

	    // Set the outer HTML of the current element
	    Controls_SetOuterHtmlFromNode(objWindow, objElement, objNode, strGuid);
	    

        // Check if browser does not support scrollbars.
        if(!Web_SupportsMISCBrowserCapability(512))
        {
            // Refresh containing IScroller element.
            Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Controls_RefreshContainingIScroller,strGuid,objWindow),20);
        }
	}
}
/// </method>

/// <method name="Controls_GetHtmlFromNode">
/// <summary>
/// Gets a html representation of a given node.
/// </summary>
/// <param name="objNode">The node to get its html.</param>
/// <param name="strGuid" optional="true">Node guid used for tracing.</param>
function Controls_GetHtmlFromNode(objNode,strGuid)
{
	if(!Aux_IsNullOrEmpty(strGuid)) 
	{
	    Trace_Time("Controls","GetControlHTML");
	}
	
	// Reset the delayed drawing flag
	Xml_SetAttribute(objNode,"Attr.IsDelayedDrawing","0");
	
	// Transform HTML.
	var strHtml	= Xml_TransformToHTML(objNode);

	if(!Aux_IsNullOrEmpty(strGuid)) 
	{
	    Trace_Write("Transform control data to HTML.",strGuid);
	}
	
	return strHtml;
}
/// </method>

/// <method name="Controls_DrawDelayedControls" access="private">
/// <summary>
/// Draws any missing dalyed drawing controls if there are
/// </summary>
function Controls_DrawDelayedControls()
{
    // Get the next delayed control if there is one
    var objDelayedControl = Xml_SelectSingleNode("//WC:*[@Attr.IsDelayedDrawing='1']", mobjDataRootObject);
    
    // If there are more delayed controls
    if(objDelayedControl)
    {
        // Remove is dirty attribute - if exist.
        if (Xml_HasAttribute(objDelayedControl, "Attr.IsDirty"))
        {
            Xml_RemoveAttribute(objDelayedControl, "Attr.IsDirty");
        }

        // Try getting window by the delayed control id.
        var objWindow = Forms_GetWindowByDataId(Xml_GetAttribute(objDelayedControl, "Attr.Id", ""));
        if(objWindow)
        {
            // Reset the delayed drawing flag
            Xml_SetAttribute(objDelayedControl,"Attr.IsDelayedDrawing","0");
                
            // Redraw the control.
            Controls_RedrawControlByNode(objWindow, objDelayedControl, false);
        }
    }

	
	// Return whether any delayed control exists.
	return (objDelayedControl!=null);
}
/// </method>

/// <method name="Controls_DrawControl" access="private">
/// <summary>
///
/// </summary>
/// <param name="objWindow">The browser window containing the node element.</param>
/// <param name="objNode">The node to update its content.</param>
/// <param name="blnInnerHTML">Render as inner content or replacement of current element.</param>
function Controls_DrawControl(objWindow,objNode,blnInnerHTML,objElement)
{
    // Validate recieved arguments.
    if(objWindow && objNode)
    {
        var strDataId = Xml_GetAttribute(objNode,"Attr.Id","");
        if(!Aux_IsNullOrEmpty(strDataId))
        {
            // Check if an element has been sent.
            if(!objElement)
            {
                // Get element as for data id.
		        objElement = Web_GetElementByDataId(strDataId,objWindow);
		    }
		    
		    // Validate element.
		    if(objElement)
		    {
		        // Set control html 
		        if(blnInnerHTML)
		        {
		            Controls_SetInnerHtmlFromNode(objWindow, objElement, objNode, strDataId);
		        }
		        else
		        {
		            Controls_SetOuterHtmlFromNode(objWindow, objElement, objNode, strDataId);
		        }
		    }
        }
    }
}
/// </method>

/// <method name="Controls_ScrollIntoView" access="public">
/// <summary>
/// Scrolls a control intro the current view
/// </summary>
/// <param name="strElementGuid">The guid of the control.</param>
/// <param name="strContainerGuid">The guid of the container control.</param>
/// <param name="intMode">Both horizontal and vertical scrolling ; 1- Vertical scrolling. ; 2 - horizontal scrolling.</param>
/// <param name="blnEnsureScrollingArea">Ensure scrolling area.</param>
function Controls_ScrollIntoView(strElementGuid, strContainerGuid, intMode, blnEnsureScrollingArea)
{
    var objScrollableContainer = null;
    
    // Validate container guid
    if(!Aux_IsNullOrEmpty(strContainerGuid))
    {
        // Get scrollable container
        objScrollableContainer = Web_GetElementByDataId(strContainerGuid);

        // Validate scrollable container
        if(objScrollableContainer)
        {
            // Drill down and get scrollable container scrollable element
            objScrollableContainer = Controls_GetScrollableElement(objScrollableContainer);

            // Check if scrollers validation needed
            if (blnEnsureScrollingArea)
            {
                while (objScrollableContainer)
                {
                    // Check scrollers exist
                    if ((intMode != 2 && Web_HasScrollY(objScrollableContainer)) || (intMode != 1 && Web_HasScrollX(objScrollableContainer)))
                    {
                        // Scrollers are valid, exit while
                        break;
                    }

                    // Get parent element
                    objScrollableContainer = objScrollableContainer.parentNode;
                    
                    // Validate parent element
                    if (objScrollableContainer)
                    {
                        // Get scrollable parent
                        objScrollableContainer = Web_GetScrollableParent(objScrollableContainer);
                    }
                }
            }
        }
    }

    if(!Aux_IsNullOrEmpty(strElementGuid))
    {
        Web_ScrollIntoView(Web_GetElementByDataId(strElementGuid), objScrollableContainer, intMode);
    }
}
/// </method>

/// <method name="Controls_GetScrollableElement" access="public">
/// <summary>
/// Finds and returns the first scrollable control inside the received control including the control itself.
/// </summary>
/// <param name="objElement">The element in which to search.</param>
function Controls_GetScrollableElement(objElement, blnExcludeContainedControls)
{
    if (objElement != null)
    {
        if (Web_IsAttribute(objElement, "vwgscrollable", "1", true))
        {
            return objElement;
        }

        if (blnExcludeContainedControls && objElement.id && objElement.id.indexOf("VWG_") === 0)
        {
            return;
        }

        var intIndex = 0;
      // Checks if any of the first level children of 'objElement' are vwgscrollable
        for (intIndex = 0; intIndex < objElement.childNodes.length; intIndex++)
        {
            if (Web_IsAttribute(objElement.childNodes[intIndex], "vwgscrollable", "1", true))
            {
                return objElement.childNodes[intIndex];
            }
        }
      // Initiating a recursion
        for (intIndex = 0; intIndex < objElement.childNodes.length; intIndex++)
        {
            var result = Controls_GetScrollableElement(objElement.childNodes[intIndex], true);
            if (result != null)
            {
                return result;
            }
        }
    }
    return null;
}
/// </method>

/// <method name="Controls_Focus" access="public">
/// <summary>
/// Sets focus to a given control
/// </summary>
/// <param name="strControlDataId">The id of the control.</param>
function Controls_Focus(strControlDataId,blnAsynchronic,objWindow)
{
    // Validate recieved control id.
    if(!Aux_IsNullOrEmpty(strControlDataId))
    {
        // Define an empty focus cotnrol.
        var strFocusControlDataId = null;
        var objFocusControlNode = null;

        // Get the control node.
        var objControlNode = Data_GetNode(strControlDataId);
        if (objControlNode) 
        {
            // Check if recieved control is focusable.
            if(Xml_IsAttribute(objControlNode, "Attr.Focus", "1"))
            {
                // Set focus control to recieved control.
                strFocusControlDataId=strControlDataId;
                objFocusControlNode = objControlNode;
            }
            else
            {
            
                // Get first focusable target node.
                var objFirstTargetNode = Data_GetTabKeyContentTargetNodeOfSelf(objControlNode,false,true);
                if(objFirstTargetNode)
                {
                    // Set focus control to the first focusable target id.
                    strFocusControlDataId=Xml_GetAttribute(objFirstTargetNode,"Attr.Id","");
                    objFocusControlNode = objFirstTargetNode;
                }
            }
        }
        
        // Validate focus control id.
        if(!Aux_IsNullOrEmpty(strFocusControlDataId))
        {
            // Get element by data id.
            var objVwgElement = Web_GetElementByDataId(strFocusControlDataId,objWindow);
            if(objVwgElement)
            {
                // Get focused element.
                var objFocusElement = Controls_GetFocusElement(objVwgElement);
                if(objFocusElement)
                {
                    // Update the local member that holds the focus element.
                    Focus_SetFocusElementDataId(strFocusControlDataId, null, objFocusControlNode);
                    
                    // Requires async focusing in order to work after updating
                    Web_SetFocus(objFocusElement,blnAsynchronic);
                }
            }
        }
    }
}
/// </method>

/// <method name="Controls_GetFocusElementByDataId" access="public">
/// <summary>
/// Gets the focus element
/// </summary>
/// <param name="strGuid">The guid of the control.</param>
function Controls_GetFocusElementByDataId(strGuid)
{
    // Get element from data id
    var objElement = Web_GetElementByDataId(strGuid);
    if(objElement)
    {
        // Get element with focus
        return Controls_GetFocusElement(objElement);
    }
}
/// </method>

/// <method name="Controls_GetFocusElement" access="public">
/// <summary>
/// Gets the contained focus control
/// </summary>
/// <param name="objElement">The element to get the contained focus element.</param>
function Controls_GetFocusElement(objElement)
{
    if (objElement && Web_GetAttribute(objElement, "vwgfocuselement") == "1")
    {
        return objElement;
    }
    else
    {
        return Web_GetContextElementByAttribute(objElement, "vwgfocuselement", "1");
    }
}
/// </method>



/// <method name="Controls_StoreScroll" access="private">
/// <summary>
/// 
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objScrollable"></param>
function Controls_StoreScroll(objWindow,strGuid,objScrollable)
{
    // Clear previous store scroll timeout 
    Web_ClearTimeout(mintStoreScrollTimeout);

    // Check if the store scroll event came from the 'Controls_RestoreScroll' method.
    if (!objScrollable.vwgRestoringScroll)
    {
        mintStoreScrollTimeout = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(mobjApp.Controls_DoStoreScroll, strGuid, objScrollable.scrollTop, objScrollable.scrollLeft, objScrollable.scrollWidth), 100);
    }
}
/// </method>

/// <method name="Controls_DoStoreScroll" access="private">
/// <summary>
/// Store the scrolling position
/// </summary>
function Controls_DoStoreScroll(strGuid, strScrollTop, strScrollLeft, strScrollWidth)
{
    // If there is a valid scrollable element
    if (!Aux_IsNullOrEmpty(strGuid))
    {
        // Get node
        var objNode = Data_GetNode(strGuid);
        if (objNode)
	    {
	        var intScrollLeft = (mblnIsRTL ? strScrollWidth - strScrollLeft : strScrollLeft);
	            
	        // Store scrolling position
	        Xml_SetAttribute(objNode, "Attr.ScrollTop", strScrollTop);
        	Xml_SetAttribute(objNode,"Attr.ScrollLeft",intScrollLeft);
        	var objEvent = Events_CreateEvent(strGuid, "ScrollPositionChanged", null, true);
        	if (objEvent)
        	{
        	    Events_SetEventAttribute(objEvent, "Attr.ScrollTop", strScrollTop);
        	    Events_SetEventAttribute(objEvent,"Attr.ScrollLeft",intScrollLeft);
        	}
	    }
	}
}
/// </method>

/// <method name="Controls_RestoreScroll" access="private">
/// <summary>
/// Restore the scrolling position
/// </summary>
/// <param name="objWindow"></param>
/// <param name="strGuid"></param>
/// <param name="fncBeforeRestoreHandler"></param>
/// <param name="fncAfterRestoreHandler"></param>
/// <param name="objScrollable"></param>
function Controls_RestoreScroll(objWindow,strGuid,fncBeforeRestoreHandler,fncAfterRestoreHandler,objScrollable)
{
    // Check if the before restore hendler has been recieved.
    if(!Aux_IsNullOrEmpty(fncBeforeRestoreHandler))
    {
        // Invoke recieved before restore handler.
        Aux_InvokeMethod(fncBeforeRestoreHandler,[objWindow,strGuid,objScrollable]);
    }
    
    // Define a switch that will indicate if scroll position has change or not.
    var blnScrollPositionChanged = false;
    
    // Get radio button node
    var objNode = Data_GetNode(strGuid);
    if(objNode)
    {
        // Restore scroll top position
        var strScrollTop = Xml_GetAttribute(objNode,"Attr.ScrollTop","");
        if (!Aux_IsNullOrEmpty(strScrollTop))
        {   
            // Parse scroll top attribute to integer.
            var intScrollTop = parseInt(strScrollTop);
            
            // Validate scroll top and check that it is different from exist one.
            if(!isNaN(intScrollTop) && intScrollTop!=objScrollable.scrollTop)
            {
                // Indicate that the restore scroll has happened on the scrollable element
                objScrollable.vwgRestoringScroll = true;

                // Set scroll
                objScrollable.scrollTop = intScrollTop;

				// Indicate that the scroll has been stord
			    objScrollable.vwgRestoringScroll = false;

                // Flag that scroll position has changed.
                blnScrollPositionChanged=true;
            }
        }
        
        // Restore scoll left position
        var intScrollLeft = Xml_GetAttribute(objNode,"Attr.ScrollLeft","");
        
        // Update the scroll left variable.
        if(Aux_IsNullOrEmpty(intScrollLeft))
        {
            if(mblnIsRTL && !mcntIsIE)
            {
                intScrollLeft=objScrollable.scrollWidth;
            }
            else
            {
                intScrollLeft = 0;
            }
        }
        else
        {
            intScrollLeft = parseInt(intScrollLeft);
        }
        
        if(!isNaN(intScrollLeft))
        {
            // Update the scroll left as for direction variable.
            if(mblnIsRTL)
            {
                intScrollLeft = (objScrollable.scrollWidth-intScrollLeft);
            }
        
            // Validate scroll left and check that it is different from exist one.        
            if(objScrollable.scrollLeft!=intScrollLeft)
            {
                objScrollable.scrollLeft = intScrollLeft;
                
                // Flag that scroll position has changed.
                blnScrollPositionChanged=true;
            }
        }
    }
    
    // Check if the after restore hendler has been recieved.
    if(!Aux_IsNullOrEmpty(fncAfterRestoreHandler))
    {
        // Invoke recieved after restore handler.
        Aux_InvokeMethod(fncAfterRestoreHandler,[objWindow,strGuid,objScrollable,blnScrollPositionChanged]);
    }
}
/// </method>

/// <method name="Control_Execute">
/// <summary>
/// Executes a Control command(used by the server control)
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strCommand">The command to be executed.</param>
/// <param name="strParamA">The first command parameter.</param>
/// <param name="strParamB">The second command parameter.</param>
function Control_SetSelection(strGuid, strStart, strLength)
{
    // Get text area/input element
    var objElement = Web_GetTargetElementByDataId(strGuid);
    if(objElement)
    {
        var intStart = parseInt(strStart);
        var intLength = parseInt(strLength);
        Web_SetSelection(objElement, intStart, intLength);
    }
}
/// </method>

/// <method name="Controls_GetScrollableElementByID">
/// <summary>
/// 
/// </summary>
function Controls_GetScrollableElementByID(strID, objWindow)
{
    var objElement = Web_GetElementById(strID, objWindow);
    if (objElement)
    {
        objElement = Controls_GetScrollableElement(objElement);
    }

    return objElement;
}
/// </method>

/// <method name="Controls_GetTheme">
/// <summary>
/// 
/// </summary>
function Controls_GetTheme(strDataID)
{
    var strTheme = null;

    if (!Aux_IsNullOrEmpty(strDataID))
    {
        var objNode = Data_GetNode(strDataID);
        if (objNode)
        {
            strTheme = Xml_GetAttribute(objNode, "Attr.Theme", "");
            if (Aux_IsNullOrEmpty(strTheme))
            {
                var objParentNode = Xml_SelectSingleNode("./ancestor::*[@Attr.Theme and not(@Attr.Theme='')][1]", objNode);
                if(objParentNode)
                {
                    strTheme = Xml_GetAttribute(objParentNode, "Attr.Theme", "");
                }
            }
        }
    }

    return strTheme;
}
/// </method>

/// </page>