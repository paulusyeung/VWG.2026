var mcintPropertyGridPageSize = 15;

/// <method name="PropertyGrid_NavigateEditor">
/// <summary>
/// 
/// </summary>
function PropertyGrid_NavigateEditor(objWindow,objEvent,strEntryGuid)
{
    // Add navigate editor event.
    Events_CreateEvent(strEntryGuid,"NavigateEditor",null,true);
    
    // Enforce click (will cause raise events).
    Web_OnClick(objEvent,objWindow,true);
}
/// </method>

/// <method name="PropertyGrid_DeactivateEntry">
/// <summary>
/// 
/// </summary>
function PropertyGrid_DeactivateEntry(strEntryDataID,strPropertyGridDataID,blnApplyValue,strValue,objWindow)
{
    // Get property node
	var objNode = Data_GetNode(strEntryDataID);
	if(objNode)
	{      
	    if(blnApplyValue)      
	    {
	        // Encode recieved text.
	        strValue = Aux_EncodeText(strValue);
    	    
	        // Check if value has changed
	        blnApplyValue = !Xml_IsAttribute(objNode,"Attr.Value",strValue);
    	    
	        // Set value attribute.
	        if(blnApplyValue)
	        {
                Xml_SetAttribute(objNode,"Attr.Value",strValue);	        
            }
        }
        
        // Set it as not active
        Xml_SetAttribute(objNode,"Attr.Active","0");
	    
        // Set owner id attribute.
        Xml_SetAttribute(objNode,"Attr.OwnerID",strPropertyGridDataID);
	    
        // Redraws node.
        Controls_RedrawControlByNode(objWindow,objNode);
	    
	    // Check if value has changed
	    if(blnApplyValue)
	    {    	            
            // Create a value change event.
	        var objEvent = Events_CreateEvent(strEntryDataID,"ValueChange",null,true);
            Events_SetEventAttribute(objEvent,"Attr.Value",strValue);
            Events_ScheduleRaiseEvents(100);
            Events_ScheduleProcessClientEvent(objEvent,100);
        }
    }
}
/// </method>

/// <method name="PropertyGrid_InputKeyDown">
/// <summary>
/// 
/// </summary>
function PropertyGrid_InputKeyDown(strEntryDataID,strPropertyGridDataID,objInput,objWindow,objEvent)
{
    // Validate recieved arguments.
    if(objWindow && objEvent && objInput && !Aux_IsNullOrEmpty(strEntryDataID) && !Aux_IsNullOrEmpty(strPropertyGridDataID))
    {
        // Get key code.
        var intKeyCode = Web_GetEventKeyCode(objEvent); 
        
        // In case of an enter.
	    if(intKeyCode==mcntEnterKey) 
	    { 
	        // Redraw entry and change value.
            PropertyGrid_DeactivateEntry(strEntryDataID,strPropertyGridDataID,true,objInput.value,objWindow);
	    } 
    	
	    // In case of an escape.
	    else if(intKeyCode==mcntEscapeKey) 
	    { 
	        // Redraw entry and preserve value.
            PropertyGrid_DeactivateEntry(strEntryDataID,strPropertyGridDataID,false,null,objWindow);
	    } 
	}
}
/// </method>

/// <method name="PropertyGrid_FocusEntry">
/// <summary>
/// 
/// </summary>
function PropertyGrid_FocusEntry(strEntryDataID,objWindow)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strEntryDataID))
    {
        // Get input element.
        var objInputElement = $('#' + Web_GetWebId(strEntryDataID)).find('input[data-id="vwgText"]:first').get(0);
        if (objInputElement)
        {
            if(objInputElement.value)
            {
                // Set input text selection.
                Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_SetSelection,objInputElement,0,objInputElement.value.length),50);
            }
            else
            {
                // Focus input element.
                Web_SetFocus(objInputElement,true);
            }
        }
    }
}
/// </method>

/// <method name="PropertyGrid_GetEntryOwnerNode">
/// <summary>
/// 
/// </summary>
function PropertyGrid_GetEntryOwnerNode(objEntryNode)
{
    if(objEntryNode)
    {
        // Try getting the OwnerEntryID attribute.
        var strOwnerEntryID = Xml_GetAttribute(objEntryNode,"Attr.OwnerEntryID","0");
        if(strOwnerEntryID!="0")
        {
            // Find owner entry node.
            return Xml_SelectSingleNode("../WG:Tags.PropertyGridEntry[@Attr.MemberID='"+strOwnerEntryID+"']",objEntryNode);
        }        
    }
    
    return null;
}
/// </method>

/// <method name="PropertyGrid_IsVisibleEntryNode">
/// <summary>
/// 
/// </summary>
function PropertyGrid_IsVisibleEntryNode(objEntryNode)
{
    if(objEntryNode)
    {
        // Try getting an owner entry node.
        var objOwnerEntryNode = PropertyGrid_GetEntryOwnerNode(objEntryNode);
        
        // If no owner entry node found entry is visible.
        if(!objOwnerEntryNode)
        {
            return true;
        }
        
        // Check that owner entry is expanded.
        else if(Xml_IsAttribute(objOwnerEntryNode,"Attr.Expanded","1"))
        {
            // Execute recursion call for owner entry.
            return PropertyGrid_IsVisibleEntryNode(objOwnerEntryNode);
        }
    }
    
    return false;
}
/// </method>

/// <method name="PropertyGrid_GetSiblingEntryNode">
/// <summary>
/// 
/// </summary>
function PropertyGrid_GetSiblingEntryNode(objEntryNode,intDirection,blnIncludeRecievedEntry)
{
    // Validate entry node.
    if(objEntryNode)
    {
        // Check if recieved node should be included in algorithm.
        if(blnIncludeRecievedEntry)
        {
            // Check if entry is visible.
            if(PropertyGrid_IsVisibleEntryNode(objEntryNode))
            {
                // Check that entry is not a category node.
                if(!Xml_IsAttribute(objEntryNode,"Attr.Type","C"))
                {
                    return objEntryNode;
                }
            }
            else
            {
                // Execute recursion call for handled entry.
                return PropertyGrid_GetSiblingEntryNode(objEntryNode,intDirection,false);
            }
        }
        else
        {
            // Try getting a sibling node as for required direction.
            var objSiblingEntry = (intDirection==1?objEntryNode.nextSibling:objEntryNode.previousSibling);
            if(!objSiblingEntry)
            {
                // Try getting an owner entry node.
                var objOwnerEntryNode = PropertyGrid_GetEntryOwnerNode(objEntryNode);
                
                // Check that owner entry is expanded.
                if(objOwnerEntryNode && Xml_IsAttribute(objOwnerEntryNode,"Attr.Expanded","1"))
                {
                    objSiblingEntry=objOwnerEntryNode;
                }
            }
            
            // Execute recursion call for sibling entry.
            return PropertyGrid_GetSiblingEntryNode(objSiblingEntry,intDirection,true);
        }
    }
    
    return null;
}
/// </method>

/// <method name="PropertyGrid_GetNavigatedEntryNode">
/// <summary>
/// 
/// </summary>
function PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,intSteps,blnEdge)
{
    // Validate steps and active node.
    if(intSteps==0 || !objActiveEntryNode)
    {
        return objActiveEntryNode;
    }
    else
    {
        // Define direction.
        var intDirection = (intSteps>0?1:-1);
        
        // Presevre current entry node.
        var objCurrentEntryNode = objActiveEntryNode;
        
        // Loop while steps remains.
        while(intSteps!=0)
        {
            // Try getting sibling node as for defined direction.
            var objSiblingEntryNode = PropertyGrid_GetSiblingEntryNode(objCurrentEntryNode,intDirection,false);
            if(objSiblingEntryNode)
            {
                // Preserve sibling node.
                objCurrentEntryNode=objSiblingEntryNode;
                
                // Check the edge variable (used for starting and ending nodes).
                if(!blnEdge)
                {
                    // Update remaining steps.
                    intSteps+=(-1*intDirection);
                }
            }
            else
            {
                // Break loop.
                intSteps=0;
            }
        }
        
        return objCurrentEntryNode;
    }
}
/// </method>

/// <method name="PropertyGrid_KeyDown">
/// <summary>
/// 
/// </summary>
function PropertyGrid_KeyDown(strPropertyGridDataID,objWindow,objEvent)
{
    // Validate recieved arguments.
    if(objWindow && objEvent && !Aux_IsNullOrEmpty(strPropertyGridDataID))
    {
        // Get event source.
        var objEventSource = Web_GetEventSource(objEvent);
        
        // Check that source element is not the editing input.
        if(!Web_IsAttribute(objEventSource,"vwgeditable","1",true))
        {            
            var objPropertyGridNode = Data_GetNode(strPropertyGridDataID);
            if(objPropertyGridNode)
            {
                var objNavigatedEntryNode = null;
                var objActiveEntryNode = Xml_SelectSingleNode(".//WG:Tags.PropertyGridEntry[@Attr.Active='1']",objPropertyGridNode);
                
                // Get event key code.
                var intKeyCode = Web_GetEventKeyCode(objEvent);        
                switch(intKeyCode)
                {
                    case mcntUpKey: 
                        objNavigatedEntryNode=PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,-1,false);
                        break;                        
                    case mcntDownKey:
                        objNavigatedEntryNode=PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,1,false);
                        break;                        
                    case mcntEndKey: 
                        objNavigatedEntryNode=PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,1,true);                    
                        break;                        
                    case mcntHomeKey: 
                        objNavigatedEntryNode=PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,-1,true);
                        break;                        
                    case mcntPageUpKey: 
                        objNavigatedEntryNode=PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,(-1*mcintPropertyGridPageSize),false);
                        break;                        
                    case mcntPageDownKey: 
                        objNavigatedEntryNode=PropertyGrid_GetNavigatedEntryNode(objActiveEntryNode,mcintPropertyGridPageSize,false);
                        break;                        
                    default:
                        if(objActiveEntryNode)
                        {
                            // Set focus to the active entry.
                            PropertyGrid_FocusEntry(strPropertyGridDataID+"_"+Xml_GetAttribute(objActiveEntryNode,"Attr.MemberID",""),objWindow);
                        }
			            break;
                }   
                
                // Validate navigated grid entry.
                if(objNavigatedEntryNode)
                {
                    // Activate property.
                    PropertyGrid_ActivateEntry(strPropertyGridDataID+"_"+Xml_GetAttribute(objNavigatedEntryNode,"Attr.MemberID",""),strPropertyGridDataID,objWindow,false);
                    
                     // Check if help is needed
			        if(!Xml_IsAttribute(objPropertyGridNode,"Attr.HelpVisible","0"))
			        {			    
			            // Enforce key down (will cause raise events).
			            Web_OnKeyDown(objEvent,objWindow,true);
			        }
                }
            }
	    }
	}
}
/// </method>

/// <method name="PropertyGrid_EntryMouseDown">
/// <summary>
/// 
/// </summary>
function PropertyGrid_EntryMouseDown(strGridEntryMemberId,strPropertyGridDataID,objWindow,objEvent,blnFocusInput)
{
    // Get the event's source element.
    var objSourceElement = Web_GetEventSourceElement(objEvent);
    if(objSourceElement)
    {   
        // Hide all popup elements beside popup that contains source element.
        Popups_HidePopups(objSourceElement);            
    }
    
    // Activate property.
    PropertyGrid_ActivateEntry(strGridEntryMemberId,strPropertyGridDataID,objWindow,blnFocusInput);
    
     // Check if help is needed
    if(!Data_IsAttribute(strPropertyGridDataID,"Attr.HelpVisible","0"))
    {			    
        // Enforce click (will cause raise events).
        Web_OnClick(objEvent,objWindow,true);
    }
}
/// </method>


/// <method name="PropertyGrid_OnEntryBlur">
/// <summary>
/// 
/// </summary>
function PropertyGrid_OnEntryBlur(strPropertyGridDataID,strMemberID,objInputElement,objWindow)
{
    var objNode = Data_GetNode(strPropertyGridDataID + "_" + strMemberID);
    if(objNode)
    {
        if(Xml_IsAttribute(objNode,"Attr.Active","1"))
        {
            // Redraw's previous entry.
            PropertyGrid_DeactivateEntry(strPropertyGridDataID + "_" + strMemberID, strPropertyGridDataID, true, objInputElement.value, objWindow);
        }
    }
}
/// </summary>

/// <method name="PropertyGrid_ActivateEntry">
/// <summary>
/// 
/// </summary>
function PropertyGrid_ActivateEntry(strEntryDataID,strPropertyGridDataID,objWindow,blnFocusInput)
{
    // Get property node
	var objNode = Data_GetNode(strEntryDataID);
	if(objNode)
	{
	    // Get grid
	    var objPropertyGridNode = Data_GetNode(strPropertyGridDataID);
	    if(objPropertyGridNode)
	    {
	        // Get previous node
	        var objPrevNode = Xml_SelectSingleNode("./"+"/WG:Tags.PropertyGridEntry[@Attr.Active='1']",objPropertyGridNode);
	        
	        // Check if previous active node is different form the handled one.
	        if(objNode != objPrevNode)
	        {
	            // Add an activated event
	        	var objVwgEvent = Events_CreateEvent(strEntryDataID, "Activated", null, true);
	        	Events_ProcessClientEvent(objVwgEvent);
			    
	            if(objPrevNode)
	            {
				    // Get input element.
	                var objPrevInputElement = $('#' + Web_GetWebId(strPropertyGridDataID + "_" + Xml_GetAttribute(objPrevNode, "Attr.MemberID", ""))).find('input[data-id="vwgText"]:first').get(0);

			        if(objPrevInputElement)
			        {
			            // Redraw's previous entry.
	                    PropertyGrid_DeactivateEntry(strPropertyGridDataID+"_"+Xml_GetAttribute(objPrevNode,"Attr.MemberID",""),strPropertyGridDataID,true,objPrevInputElement.value,objWindow);				        
			        }
	            }
    	    
			    // Set active attribute
			    Xml_SetAttribute(objNode,"Attr.Active","1");

			    // Set owner attribute.
			    Xml_SetAttribute(objNode,"Attr.OwnerID",Xml_GetAttribute(objPropertyGridNode,"Attr.Id"));
    	    
			    // Render active node
			    Controls_RedrawControlByNode(objWindow,objNode);
			    
			    // Scrolls the entry into view.
			    Controls_ScrollIntoView(strEntryDataID,strPropertyGridDataID,1);
    	        
    	        // Check if input focus is needed.
    	        if(blnFocusInput)
    	        {
                    // Set focus to the active entry.
                    PropertyGrid_FocusEntry(strEntryDataID,objWindow);
			    }
			    else
			    {
			        // Set focus back to the property grid.
			        Controls_Focus(strPropertyGridDataID,mcntIsIE);
			    }
			}
	    }
	}
}
/// </method>

/// <method name="PropertyGrid_Toggle">
/// <summary>
///	Expand/collapse - handler
/// </summary>
/// <param name="strGridID">the property grid ID</param>
/// <param name="strEntryID">the ID related to HTML element been expanded/collapsed</param>
/// <param name="objImage">Plus/Minus image been clicked for further state change</param>
/// <param name="objWindow">The browser window</param>
/// <param name="objEvent">The event of click</param>
/// <returns>no return value</returns>
function PropertyGrid_Toggle(strGridID, strEntryID, objImage, objWindow, objEvent)
{
    // Get the entry full id (including grid - owner)
    var strEntryID = strGridID + "_" + strEntryID;
    
    // Get property grid entry XML behind node by Owner and MemberId
	var objNode = Data_GetNode(strEntryID);

	if(objNode)
	{
	    // Get the top row of expanded rows
	    var objRow  = Web_GetElementById(Web_GetWebId(strEntryID), objWindow);
	    
	    // Calculate required state
	    var blnExpanded = !Xml_IsAttribute(objNode,"Attr.Expanded","1");
	    
	    // Set required state
	    Xml_SetAttribute(objNode,"Attr.Expanded",blnExpanded?"1":"0");
	    
	    // Change image to required state
	    PropertyGrid_ToggleImage(objImage, blnExpanded);
	    
	    // Show/Hide rows to fit to required state
        PropertyGrid_ToggleEntry(strGridID, strEntryID, objNode, objRow, blnExpanded, objWindow);
        
        var objExpandEvent = Events_CreateEvent(strEntryID, "ExpandChange", null, true);
        Events_SetEventAttribute(objExpandEvent, "Attr.Value", blnExpanded ? "1" : "0");       
    }
}
/// </method>


/// <method name="PropertyGrid_GetEntryOwnedEntryNodes">
/// <summary>
/// Expands/collapse given property grid entry and owned entries
/// </summary>
/// <param name="strGridID">the property grid ID</param>
/// <param name="strEntryID">the ID related to HTML element been expanded/collapsed</param>
/// <param name="objNode">the XML node behind expanded/collpased entry</param>
/// <param name="objRow">the HTML element expanded/collapsed row </param>
/// <param name="blnVisible">true - expand, false - collapse</param>
/// <param name="objWindow">The current window</param>
/// <returns>no return value</returns>
function PropertyGrid_ToggleEntry(strGridID, strEntryID, objNode, objRow, blnVisible, objWindow)
{   
    // Check valid node and row
    if(objNode && objRow)
    {
        // Calculate visibility
        var blnSubVisible = blnVisible &&  Xml_IsAttribute(objNode, "Attr.Expanded", '1');
        
        // Loop all child nodes
        var arrOwnedEntries = PropertyGrid_GetEntryOwnedEntryNodes(objNode);
        for(var intIndex=0; intIndex < arrOwnedEntries.length; intIndex++)
        {
            // Get current sub node
            var objSubNode  = arrOwnedEntries[intIndex];
            var strSubRowID = Xml_GetAttribute(objSubNode, "Attr.MemberID");
            var objSubRow   = Web_GetElementById(Web_GetWebId(strGridID + "_" + strSubRowID), objWindow);
            
            // If valid row
            if(objSubRow)
            {
                // Set row visibility
                Web_SetRowVisibility(objSubRow, blnSubVisible);
                
                // In case of IE only.
                if(mcntIsIE)
                {
                    // Get label input element.
                    var objLabelInputElement = $(objSubRow).find('input[data-id="vwgLabel"]:first').get(0);
                    if(objLabelInputElement)
                    {
                        // Show / hide label input element
                        objLabelInputElement.style.display=(blnSubVisible?"block":"none");
                    }
                }
                
                // Continue to sub nodes if exist
                PropertyGrid_ToggleEntry(strGridID, strSubRowID, objSubNode, objSubRow, blnSubVisible, objWindow);
            }
        }
    }
}
/// </method>

/// <method name="PropertyGrid_GetEntryOwnedEntryNodes">
/// <summary>
/// Get sibling nodes that are owned by given entry node (excluding node itself)
/// </summary>
/// <param name="objEntryNode">The node we interested to find out its owned entries</param>
/// <returns>an array of XML nodes that are ownded by given objEntryNode</returns>
function PropertyGrid_GetEntryOwnedEntryNodes(objEntryNode)
{
    var arrOwnedEntries = [];
    if(objEntryNode)
    {
        arrOwnedEntries = Xml_SelectNodes("../WG:Tags.PropertyGridEntry[@Attr.OwnerEntryID='" + Xml_GetAttribute(objEntryNode, "Attr.MemberID") + 
                                          "' and @Attr.OwnerEntryID != @Attr.MemberID]", objEntryNode);
    }
    return arrOwnedEntries;
}
/// </method>


/// <method name="PropertyGrid_ToggleImage">
/// <summary>
/// Set an image of Plus/Minus in according to blnExpanded argument
/// </summary>
function PropertyGrid_ToggleImage(objImage,blnExpanded)
{
    // Change current image to requierd image
    objImage.src = objImage.src.replace((blnExpanded?"0":"1")+".gif",(blnExpanded?"1":"0")+".gif");
}
/// </method>

/// <method name="PropertyGrid_SplitterResize">
/// <summary>
/// 
/// </summary>
function PropertyGrid_SplitterResize(strPropertyGridDataID,objSplitter,objWindow,objEvent)
{
    // Get grid
    var objPropertyGridObject = Web_GetWebElement(Web_GetWebId(strPropertyGridDataID),objWindow);
    if(objPropertyGridObject)
	{
		// Get grid rect
        var objGridRect = Web_GetRect(objPropertyGridObject);
        
        // Get splitter rect
		var objPropertyGridRect = Web_GetRect(objSplitter);
		
		// Set current horizontal positioning
		objPropertyGridRect.top		= objGridRect.top;
		objPropertyGridRect.bottom	= objGridRect.bottom;
		
		// Set global memory
		PropertyGrid_SplitterResize.intPropertyGridLeft = objPropertyGridRect.left;
		PropertyGrid_SplitterResize.objPropertyGridCol = $(objPropertyGridObject).find('col[data-id="vwgLabelsCol"]:first');
		PropertyGrid_SplitterResize.intPropertyGridMin = objGridRect.left+15;
		PropertyGrid_SplitterResize.intPropertyGridMax = objGridRect.right-15;
		PropertyGrid_SplitterResize.strPropertyGridDataID        = strPropertyGridDataID;
		PropertyGrid_SplitterResize.objWindow          = objWindow;
		
		// Perform drag
	    Drag_ShowDragElement(objPropertyGridRect,mcntDragMoveHorz,objWindow,PropertyGrid_SplitterChange);
	}
}
/// </method>

/// <method name="PropertyGrid_SplitterChange">
/// <summary>
/// 
/// </summary>
function PropertyGrid_SplitterChange(objRect)
{
	try
	{
		// Get x offset
		var intOffsetX = objRect.left;
		
		// Vlidate minimum value
		if(intOffsetX<PropertyGrid_SplitterResize.intPropertyGridMin)
		{
			intOffsetX=PropertyGrid_SplitterResize.intPropertyGridMin;
		}
		
		// Validate maximum value
		if(intOffsetX>PropertyGrid_SplitterResize.intPropertyGridMax)
		{
			intOffsetX=PropertyGrid_SplitterResize.intPropertyGridMax;
		}
	    // Calculate new labels column width
		var intSplitterWidth = PropertyGrid_SplitterResize.objPropertyGridCol.get(0).style.width;
		
		var intWidth = parseInt(intSplitterWidth) + (mblnIsRTL ? (PropertyGrid_SplitterResize.intPropertyGridLeft - intOffsetX) : (intOffsetX - PropertyGrid_SplitterResize.intPropertyGridLeft));

		if (intWidth < 15)
		{
			intWidth = 15;
		}
		
		// Set new column width
		if (intSplitterWidth != intWidth)
		{
			// Preserve updated width
		    PropertyGrid_SplitterResize.objPropertyGridCol.css("width", intWidth);

	        // Add the splitter change event.
            PropertyGrid_AddSplitterChangeEvent(PropertyGrid_SplitterResize.objWindow, PropertyGrid_SplitterResize.strPropertyGridDataID);
		}
	}
	catch(e)
	{
	}
	
	// Reset global memory
	PropertyGrid_SplitterResize.objPropertyGridRect = null;
	PropertyGrid_SplitterResize.objPropertyGridCol  = null; 
	PropertyGrid_SplitterResize.strPropertyGridDataID         = null;
	PropertyGrid_SplitterResize.objWindow           = null;
	  
}
/// </method>

/// <method name="PropertyGrid_AddSplitterChangeEvent">
/// <summary>
/// 
/// </summary>
function PropertyGrid_AddSplitterChangeEvent(objWindow,strPropertyGridDataID)
{
    if(!Aux_IsNullOrEmpty(strPropertyGridDataID))
	{
        // Get the property grid html object.
        var objPropertyGridObject = Web_GetWebElement(Web_GetWebId(strPropertyGridDataID),objWindow);
        if(objPropertyGridObject)
        {
            // Get the labels html column.
            var objPropertyGridCol = $(objPropertyGridObject).find('col[data-id="vwgLabelsCol"]:first').get(0);
            if(objPropertyGridCol)
            {
                // Add event to indicate that the splitter has changed.
                var objEvent = Events_CreateEvent(strPropertyGridDataID,"SplitterChange",null,true);
                
                // Set the width attribute.
                Events_SetEventAttribute(objEvent, "Attr.Width", parseInt(objPropertyGridCol.style.width));                
            }
        }
    }
}
/// </method>
