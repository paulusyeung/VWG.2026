/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
var mobjListViewObjectRect	= null;
var mobjListViewObject1		= null;
var mobjListViewObject2		= null;
var mstrListViewDataId        = null;
/// </parameters>

/// <page name="ListView.js">
/// <summary>
/// This script is used as a shared list view script.
/// </summary>

/// <method name="ListView_Select">
/// <summary>
/// Calls ListServices List_Select method which
/// selects element based on strId
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strId"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <returns>undefined</returns>
function ListView_Click(strGuid,strId,objWindow,objEvent)
{
    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // Executig selection of list item
	ListView_Select(strGuid, strId, objWindow, Web_IsShift(objEvent), Web_IsControl(objEvent), true);
	
	// If click and doubleclick are not critical and the selected index change event is critical - raise events.
	if (Data_IsCriticalEvent(strGuid, "Event.SelectionChange"))
    {
        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnClick(objEvent,objWindow, true);
    }
}
/// </method>

/// <method name="ListView_SelectAsync">
/// <summary>
/// Calls ListServices List_Select method which
/// selects element based on strId
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strId"></param>
/// <param name="objWindow"></param>
/// <param name="blnShiftKey"></param>
/// <param name="blnCtrlKey"></param>
/// <returns>undefined</returns>
function ListView_Select(strGuid,strId,objWindow,blnShiftKey,blnCtrlKey,blnSuspendRaiseEvents,intKeyCode)
{
    // Exit on disabled control
	if(Data_IsDisabled(strGuid)) return;
	
	// Get the multiselect attribute.
	var objNode = Data_GetNode(strGuid);
	var blnMultiple = Xml_IsAttribute(objNode,"Attr.Multiple","1");
	
    List_Click(strGuid,strId,(blnMultiple?0:3),false,false,objWindow,blnShiftKey,blnCtrlKey,blnSuspendRaiseEvents);
}
/// </method>

/// <method name="ListView_IsClickable">
/// <summary>
/// 
/// </summary>
function ListView_IsClickableColumn(strGuid)
{
    var blnIsClickableColumn = false;
    
    // Get data node
	var objColumnNode = Data_GetNode(Data_GetDataId(strGuid));
	
	if(objColumnNode && objColumnNode.parentNode)
	{
	    blnIsClickableColumn = (Xml_GetAttribute(objColumnNode.parentNode,"Attr.HeaderStyle")=="2");
	}
	
	// Check header style.
	return blnIsClickableColumn;
}
/// </method>


/// <method name="ListViewHeaderClick">
/// Sorts ListView by the ColumnHeader clicked
/// <summary>
/// Handler list view header click
/// </summary>
/// <param name="objListViewColumn"></param>
/// <param name="">strGuid</param>
/// <returns>undefined</returns>
function ListView_HeaderClick(objListViewColumn,strGuid)
{
    // Exit on disabled or none clickable control.
	if(Data_IsDisabled(strGuid) || !ListView_IsClickableColumn(strGuid)) return;
	        
	var objEvent = Events_CreateEvent(objListViewColumn.id,"Sort");
	Events_RaiseEvents();
}
/// </method>


/// <method name="ListView_KeyDown">
/// Handles keypad navigation 
/// Supports List, Details, LargeIcon and SmallIcon views
/// <summary>
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <returns>undefined</returns>
function ListView_KeyDown(strGuid,objWindow,objEvent)
{
    // Exit on disabled control
	if(Data_IsDisabled(strGuid)) return;
	
	// Get the pressed key
	var intKeyCode = Web_GetEventKeyCode(objEvent);
	
	// handle navigation keys
	if(Web_IsNavigationKey(intKeyCode))
	{
	    // Get ListView node
	    var objNode = Data_GetNode(strGuid);
	    
        if (objNode)
        {
            // get data row nodes
            var objItems = Xml_SelectNodes("Tags.Row",objNode);
            
            // Get selected items.
            var objSelectedItems = Xml_SelectNodes("Tags.Row[@Attr.Selected='1']",objNode);
            
            // Get the selection mode
            var intSelectionMode =(Xml_IsAttribute(objNode,"Attr.Multiple","1")?0:3);
                
            //first false - blnUseIndexes(is it ListBox)
            //second false - blnSuspendRaiseEvents
            List_KeyDown(strGuid,objItems,objSelectedItems,objNode,objWindow,objEvent,intSelectionMode,intKeyCode,Xml_GetAttribute(objNode,"Attr.View","Details"),false,false);
        }
        
        // Cancel defailt scrolling functionality.
        Web_EventCancelBubble(objEvent);    
	}
}   
/// </method>

/// <method name="ListView_RaiseChangeColumnWidthEvent">
/// <summary>
///
/// </summary>
/// <param name="objRect"></param>
/// <returns>undefined</returns>
function ListView_RaiseChangeColumnWidthEvent(objRect)
{
    if(mblnIsRTL)
	{
		if(mobjListViewObjectRect.right<=(objRect.right+15))
		{
			mobjListViewObjectRect.left = mobjListViewObjectRect.right-15;
		}
		else
		{
			mobjListViewObjectRect.left = objRect.right;
		}
	}
	else
	{
		if(mobjListViewObjectRect.left>=(objRect.left-15))
		{
			mobjListViewObjectRect.right = mobjListViewObjectRect.left+15;
		}
		else
		{
			mobjListViewObjectRect.right = objRect.left;
		}
	}
	
	var intWidth = parseInt(mobjListViewObjectRect.right - mobjListViewObjectRect.left);
	
	with(mobjListViewObject1.style)
	{
		width = intWidth + "px";
	}
	
	with(mobjListViewObject2.style)
	{
	    width = intWidth + "px";
	}
	
	// Get the active column guid.
	var strColumnGuid = String(mobjListViewObject1.id).replace("COL1_","");
	
	var objEvent = Events_CreateEvent(strColumnGuid, "ChangeColumnWidth"); 
	Events_SetEventAttribute(objEvent, "Width", intWidth);
	
	// Set the column's data new width.
	Xml_SetAttribute(Data_GetNode(strColumnGuid), "Attr.Width", intWidth);

	var objListView = Web_GetVwgElement(mobjListViewObject1);
	
	if(objListView) 
	{
	    var strListViewId = Web_GetId(objListView);
	    strListViewId = String(strListViewId).replace("VWG_","");

	    if (Data_IsCriticalEvent(strListViewId, "Event.ChangeColumnWidth"))
        {
            Events_RaiseEvents();
        }

        Events_ProcessClientEvent(objEvent);
	}
}
/// </method>

/// <method name="ListView_DoubleClick">
/// <summary>
///
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strItemGuid"></param>
/// <param name="objCheckImage"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <param name="blnScheduleCheck"></param>
/// <returns>undefined</returns>
function ListView_DoubleClick(strGuid,strItemGuid,objWindow,objEvent)
{
    // Get checkbox image element.
    var objCheckImage =  Web_GetElementById("LVI_CB_"+strItemGuid,objWindow);
    
    if(objCheckImage)
    {
         // Executig check change
        List_Checked(strGuid, strItemGuid, false, objCheckImage, objWindow, Data_IsCriticalEvent(strItemGuid, "Event.DoubleClick"));
    }
	
	// If click and doubleclick are not critical and the cehck change event is critical - raise events.
    if (Data_IsCriticalEvent(strGuid, "Event.CheckedChange"))
    {
        // Handles the double click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnDblClick(objEvent,objWindow,true);
    }
}
/// </method>

/// <method name="ListView_CheckBoxClick">
/// <summary>
///
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strItemGuid"></param>
/// <param name="objCheckImage"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <param name="blnScheduleCheck"></param>
/// <returns>undefined</returns>
function ListView_CheckBoxClick(strGuid,strItemGuid,objWindow,objEvent)
{
    // Get checkbox image element.
    var objCheckImage =  Web_GetElementById("LVI_CB_"+strItemGuid,objWindow);
    
    if(objCheckImage)
    {
        // Executig check change
	    List_Checked(strGuid,strItemGuid,false,objCheckImage,objWindow,true);
	}
	
	// If click and doubleclick are not critical and the checked change event is critical - raise events.
    if (Data_IsCriticalEvent(strGuid, "Event.CheckedChange"))
    {
        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnClick(objEvent,objWindow, true);
    }
}
/// </method>

/// <method name="ListView_RightClick">
/// <summary>
/// Calls ListServices List_Select method which
/// selects element based on strId on right click
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strId"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <returns>undefined</returns>
function ListView_RightClick(strGuid,strId,objWindow,objEvent)
{
	// Check if selection on right click is enabled.
    if(Data_IsAttribute(strGuid,"Attr.SelectOnRightClick","1"))
    {
        // Executig selection of list item
        ListView_Select(strGuid, strId, objWindow, Web_IsShift(objEvent), Web_IsControl(objEvent), Data_IsCriticalEvent(strId, "Event.RightClick"));
    }
}

/// </method>

/// <method name="ListView_OrderColumn">
/// <summary>
///	Handles listview column oredering.
/// </summary>
/// <param name="strGuid">The id of the listview</param>
/// <param name="strColumn">The id of the listview column</param>
/// <param name="objWindow">The owner window of this listview</param>
/// <param name="objEvent">The event object</param>
function ListView_OrderColumn(strListGuid,strColumnId,objWindow,objEvent)
{   
    // Validate received parameters.
    if (objWindow &&
        strListGuid && strListGuid != "" && 
        strColumnId && strColumnId != "")
    {
        // Get listview node
        var objListElementNode = Data_GetNode(strListGuid);
        
        // Check if user is allowed ordering columns.
        if(!objListElementNode || !Xml_IsAttribute(objListElementNode,"Attr.AllowUserToOrderColumns","1"))        
        {
            return;
        }
        
        // Get column header element.
        var objDraggedElement = Web_GetElementById("VWG_"+strColumnId, objWindow);
        
        if(objDraggedElement)
        {
            // Get list element
            var objListElement = objWindow.$$(Web_GetWebId(strListGuid));
            
            if(objListElement)
            {
                // Store global variables
                ListView_OrderColumn.ListGuid       = strListGuid;
                ListView_OrderColumn.ColumnId       = strColumnId;
                ListView_OrderColumn.ActiveWindow   = objWindow;
                
                // Get dragged element rect
                var objDraggedElementRect   = Web_GetRect(objDraggedElement);
                
                // Get list rect
                var objListElementRect = Web_GetRect(objListElement);
                
                // Update the limitating rectangle width.
                objListElementRect.right -= (objDraggedElementRect.right-objDraggedElementRect.left);
               
                // Show dragging rect
                Drag_RegisterDragElement(objDraggedElement,mcntDragMoveHorz,objWindow,objEvent,ListView_OrderColumnEnd,null,objListElementRect,false    ,ListView_OrderColumnMove,30);
            }
        }
    }
}
/// </method>


/// <method name="ListView_OrderColumnMove">
/// <summary>
///	Handles the actual column ordering
/// </summary>
function ListView_OrderColumnMove()
{
    // Restore global variables.
    var strListGuid = ListView_OrderColumn.ListGuid;
    var strColumnId = ListView_OrderColumn.ColumnId;
    var objWindow   = ListView_OrderColumn.ActiveWindow;
    
    // Validate drag window, drag subject, and drag subject's rectangle.
    if( objWindow && mobjDragRect &&
        !Aux_IsNullOrEmpty(strListGuid) && !Aux_IsNullOrEmpty(strColumnId))        
    {   
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_"+strColumnId, objWindow);
        
        var objListElement = objWindow.$$(Web_GetWebId(strListGuid));
        
        // Validate the subject VWG element.
        if(objVwgDragSubject)
        {
            // Define x an y position.
            var intX = mobjDragRect.left - 1;
            var intY = mobjDragRect.top;
            
            // Get element according to x and y position.
            var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);
             
            // Check that the source element is not the VWG_DraggedOverFloatingElement.
            if(objDraggedOverElement && Web_GetId(objDraggedOverElement)!="VWG_DraggedOverFloatingElement")
            {          
                // Removes the DropTargetElement - if exists.
                Drag_RemoveDropTargetElement();
                
                // Get the VWG dragged over element.
                var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement, true);
                
                // Validate the VWG dragged over element.
                if( objVwgDraggedOverElement && 
                    Web_IsAttribute(objVwgDraggedOverElement,"vwgdragable","1",true) &&
                    Web_GetId(objVwgDraggedOverElement)!="VWG_DragHtmlIndicatorBox")
                { 
                    // Get the dragged over element rectangle.
                    var objVwgDraggedOverElementRect = Web_GetRect(objVwgDraggedOverElement);
                    
                    // Validate the dragged over element rectangle.
                    if(objVwgDraggedOverElementRect)
                    {
                        // Create a new DIV element.
                        var objDraggedOverFloatingElement = mobjDragWindow.document.createElement("DIV");

                        var objDraggedOverContainerElement = Drag_GetDraggedOverContainer();
                        if(objDraggedOverContainerElement)
                        {
	                        // Add floating element to its container.
	                        objDraggedOverContainerElement.appendChild(objDraggedOverFloatingElement);
                            
                            // Update the dragged over floating element id.
                            objDraggedOverFloatingElement.id = "VWG_DraggedOverFloatingElement";
                            
                            // Set the dragged over floating element position to absolute.
                            objDraggedOverFloatingElement.style.position = "absolute";
                            
                            objDraggedOverFloatingElement.style.backgroundColor = "black";
                            
                            // Set element's height and top.
                            objDraggedOverFloatingElement.style.height = (objVwgDraggedOverElementRect.bottom - objVwgDraggedOverElementRect.top) + "px";
                            objDraggedOverFloatingElement.style.top = objVwgDraggedOverElementRect.top + "px";
                            
                            // Set element's width and left. 
                            objDraggedOverFloatingElement.style.width = "3px";
                            objDraggedOverFloatingElement.style.left = (objVwgDraggedOverElementRect.right - 3) + "px";
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="ListView_OrderColumnEnd">
/// <summary>
///	Handles the actual column ordering
/// </summary>
/// <param name="objRect">The new rectangle</param>
/// <param name="objRectOld">The original rectangle</param>
function ListView_OrderColumnEnd(objRect,objRectOld)
{   
    // Restore global variables.
    var strListGuid = ListView_OrderColumn.ListGuid;
    var strColumnId = ListView_OrderColumn.ColumnId;
    var objWindow   = ListView_OrderColumn.ActiveWindow;
    
    // Removes the DropTargetElement - if exists.
    Drag_RemoveDropTargetElement();
    
    // Validate drag window, drag subject, and drag subject's rectangle.
    if( objWindow && mobjDragRect &&
        !Aux_IsNullOrEmpty(strListGuid) && !Aux_IsNullOrEmpty(strColumnId))
    {   
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_"+strColumnId, objWindow);
        
        // Validate the subject VWG element.
        if(objVwgDragSubject)
        {
            // Define x an y position.
            var intX = mobjDragRect.left;
            var intY = mobjDragRect.top;
            
            // Get element according to x and y position.
            var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);
             
            // Check that the source element is valid.
            if(objDraggedOverElement)
            {          
                // Get the VWG dragged over element.
                var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement, true);
                
                // Validate the VWG dragged over element.
                if( objVwgDraggedOverElement && 
                    Web_IsAttribute(objVwgDraggedOverElement,"vwgdragable","1",true) &&
                    Web_GetId(objVwgDraggedOverElement)!="VWG_DragHtmlIndicatorBox")
                {                           
                    // Define a dragged column id.
                    var strDraggedColumnId = strColumnId;
                                                            
                    // Get target column id.
                    var strTargetColumnId = Web_GetId(objVwgDraggedOverElement);
                    
                    // Validate target column id.
                    if(strTargetColumnId.indexOf("VWG_") != -1)
                    {
                        // Fix target column id.
                        strTargetColumnId = strTargetColumnId.substring(strTargetColumnId.indexOf("VWG_") + 4);
                    }    
                    
                    // Validate both column id's and check that they are not equal.
                    if( strDraggedColumnId && strDraggedColumnId != "" &&
                        strTargetColumnId && strTargetColumnId != "" &&
                        strDraggedColumnId != strTargetColumnId)
                    {                        
                        // Create the columns reorder event
                        var objEvent = Events_CreateEvent(strListGuid,"ColumnsReorder",null,true); 
                        
                        // Set column id's as attributes.
                        Events_SetEventAttribute(objEvent,"Attr.DraggedColumn",strDraggedColumnId);
                        Events_SetEventAttribute(objEvent,"Attr.TargetColumn",strTargetColumnId);
                        
                        // Raise events.
                        Events_RaiseEvents();

                        Events_ProcessClientEvent(objEvent);
                    }
                }
            }
        }
    }
}
/// </method>


/// <method name="ListViewResizeChange">
/// <summary>
///
/// </summary>
/// <param name=""></param>
function ListView_ResizeChange(objRect)
{
    // Raise change column width event.
	ListView_RaiseChangeColumnWidthEvent(objRect);

    // Validate list id.
    if(!Aux_IsNullOrEmpty(mstrListViewDataId))
    {
        // Get list's window.
        var objWindow = Forms_GetWindowByDataId(mstrListViewDataId);
        if(objWindow)
        {
            // Redraw the list view.
            Controls_RedrawControlById(objWindow, mstrListViewDataId);
        }
    }
}
/// </method>

/// <method name="ListViewResize">
/// <summary>
///
/// </summary>
/// <param name=""></param>
/// <param name=""></param>
function ListView_Resize(objTd,objWindow,objEvent)
{
	mobjListViewObject1		= Web_GetWebElement("COL1_"+Web_GetAttribute(objTd,"colid"),objWindow);
	mobjListViewObject2		= Web_GetWebElement("COL2_"+Web_GetAttribute(objTd,"colid"),objWindow);
	mobjListViewObjectRect	= Web_GetRect(objTd.previousSibling);
	mstrListViewDataId        = String(Web_GetId(objTd)).replace("HEADER_","");
	
	Drag_ShowDragElement(Web_GetRect(objTd),mcntDragMoveHorz,objWindow,ListView_ResizeChange);
	        
    // Cancel events
    Web_EventCancelBubble(objEvent);
}
/// </method>

/// <method name="ListView_iScrollSyncScrollers">
/// <summary>
///
/// </summary>
function ListView_iScrollSyncScrollers(strDataID)
{
    if (!Aux_IsNullOrEmpty(strDataID))
    {
        // Gets the list's window.
        var objWindow = Forms_GetWindowByDataId(strDataID);
        if (objWindow)
        {
            // Get the list's scrollable element.
            var objLvBodyElement = Web_GetElementById("VWGLVBODY_" + strDataID, objWindow);
            if (objLvBodyElement)
            {
                // Get the list's iScroll element.
                var objLvBodyIScrollElement = objLvBodyElement.iScrollElement;
                if (objLvBodyIScrollElement)
                {
                    // Get list's header's element.
                    var objListHeaderElement = Web_GetElementById("HEADER_" + strDataID, objWindow);
                    if (objListHeaderElement)
                    {
                        // Get the column header's iScroll element.
                        var objListHeaderIScrollElement = objListHeaderElement.iScrollElement;
                        if (!objListHeaderIScrollElement)
                        {
                            // Create and preserve a new IScroll element for the column header.
                            objListHeaderElement.iScrollElement = objListHeaderIScrollElement = new IScroll(objListHeaderElement, { scrollbars: false });
                        }

                        // Perform scrolling on the column header's iScroll element.
                        objListHeaderIScrollElement.scrollTo(objLvBodyIScrollElement.x, 0, 0);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="ListView_AddEmptyGridLineRows">
/// <summary>
///
/// </summary>
function ListView_AddEmptyGridLineRows(objWindow, strID, intRowHeight)
{
    if (!objWindow["vwglistlock" + strID])
    {
        // Solves IE bug that onresize fires each time we add a row, so we need to lock it.
        objWindow["vwglistlock" + strID] = true;

        if (objWindow["vwglistviewtimeout" + strID])
        {
            objWindow.clearTimeout(objWindow["vwglistviewtimeout" + strID]);
        }

        // Timeout so the sizes will be right
        objWindow["vwglistviewtimeout" + strID] = objWindow.setTimeout(function ()
        {

            // The scrollable container
            var jqContainer = $(Web_GetElementById("VWGLVBODY_" + strID, objWindow));
            if (jqContainer.length == 1)
            {
                var jqTable = jqContainer.children("table");
                if (jqTable.length == 1)
                {
                    try
                    {
                        // Always remember the original height
                        if (!jqTable.attr("vwgoriginalheight"))
                        {
                            jqTable.attr("vwgoriginalheight", jqTable.height());
                        }

                        // Check if there should be a real overflow (scrollbars)
                        if (jqContainer.height() - parseInt(jqTable.attr("vwgoriginalheight")) > 0)
                        {
                            var intHeightDiff = jqContainer.height() - jqTable.height();
                            // Height > 0 means that there's a blank area between the table and the bottom of the control
                            if (intHeightDiff > 0)
                            {
                                // In this state there's no need to overflow because we don't have enough lines anyway
                                jqContainer.css({ "overflow-y": "hidden" });

                                // The number of rows needed to fill the blank area
                                var intDifferenceInNumberOfRows = Math.ceil(intHeightDiff / intRowHeight);

                                if (!isNaN(intDifferenceInNumberOfRows))
                                {
                                    var intNumberOfColumns = jqTable.children("colgroup").children("col").length;

                                    var objTemplate = $("<tr></tr>", objWindow.document).height(intRowHeight).addClass("Common-HideFocus ListView-FontData ListView-DataRow0").attr("vwgdummyrow", strID);

                                    // Create buffer to add all elements at once
                                    var arrBuffer = [];

                                    for (var i = 0; i < intNumberOfColumns; i++)
                                    {
                                        // Create the cell                      // Every second column is a seperator cell
                                        var objListViewCellElement = $("<td></td>", objWindow.document).addClass(i % 2 === 0 ? "ListView-DataCell ListView-Cell" : "ListView-Cell ListView-SeperatorCell");
                                        Web_SetInnerHtml(objListViewCellElement[0], "&nbsp;");

                                        arrBuffer.push(objListViewCellElement);
                                    }

                                    objTemplate.append(arrBuffer);

                                    // Empty the array
                                    arrBuffer = [];

                                    // We need to determine what color of alternating coloring the last row has.
                                    var intLatRowAlternatingOrderNumber = $("#VWGLVBODY_" + strID + " table tr").last().hasClass("ListView-DataRow1") ? 1 : 0;

                                    for (var i = 0; i < intDifferenceInNumberOfRows; i++)
                                    {
                                        // Use alternate row template on every second row. Also we need to consider the color of the last row to have correct alternating coloring.
                                        if ((intLatRowAlternatingOrderNumber + i) % 2 === 0)
                                        {
                                            objTemplate.addClass("ListView-DataRow1");
                                        }
                                        else
                                        {
                                            objTemplate.removeClass("ListView-DataRow1");
                                        }

                                        arrBuffer.push(objTemplate.clone());
                                    }

                                    jqTable.append(arrBuffer);
                                }
                            }
                        }
                        else
                        {
                            // Restore the overflow if we don't have a blank area.
                            jqContainer.css({ "overflow-y": "auto" });

                            // Remove all dummyrows
                            $("[vwgdummyrow=" + strID + "]", objWindow.document).remove();
                        }
                    }
                    finally
                    {
                        // Timeout is for IE - we need to wait for the rendering to be complete
                        objWindow.setTimeout(function ()
                        {
                            objWindow["vwglistlock" + strID] = false;
                        }, 10);
                    }
                }
            }
        }, 100);
    }
}
/// </method>