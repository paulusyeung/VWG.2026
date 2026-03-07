/// <page name="VirtualDataGridView.js">
/// <summary>
/// General scripts for web stuff handling.
/// </summary>
var mintBlocksDataSyncHandler = 0;

/// <method name="DataGridView_ColumnDividerMouseDownAsync">
/// <summary>
///	Handles datagrid resizing
/// </summary>
/// <param name="objElement">The resizing element</param>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="strMember">The id of the datagrid member</param>
/// <param name="blnColumn">A flag indicating if member is column or row</param>
/// <param name="objWindow">The owner window of this datagrid</param>
function DataGridView_ColumnDividerMouseDownAsync(objElement,strGrid,strMember,blnColumn,objWindow)
{
    // Initialize click interval value.
    DataGridView_ColumnDividerMouseDown.ClickInterval = null;

    // Get grid element
    var objGrid = objWindow.$$(Web_GetWebId(strGrid));
    
    // Get target elements (columns or rows)
    var objTargets = objWindow.$$(
        DataGridView_GetMemberID(strGrid,strMember,"1",blnColumn),
        DataGridView_GetMemberID(strGrid,strMember,"2",blnColumn)
    );
    
    // Store global variables
    DataGridView_ResizeEnd.IsColumn         = blnColumn;
    DataGridView_ResizeEnd.DragTargets      = objTargets;
    DataGridView_ResizeEnd.GridId           = strGrid;
    DataGridView_ResizeEnd.TargetMemberId   = strMember;
    DataGridView_ResizeEnd.ActiveWindow     = objWindow;
    
    // Get current rect
    var objRect = Web_GetRect(objElement);
    
    // Get grid rect
    var objGridRect = Web_GetRect(objGrid);
    if(blnColumn)
    {            
        // Fix width
        if(!mblnIsRTL)
        {
            objRect.left = objRect.right-3;
        }
        else 
        {
            objRect.right = objRect.left+3;
        }

        // Fix height
        objRect.top = objGridRect.top;
        objRect.bottom = objGridRect.bottom;
    }
    else
    {
        // Fix width
        objRect.left = objGridRect.left;
        objRect.right = objGridRect.right;
        
        // Fix height
        objRect.top = objRect.bottom-3;
    }
   
    // Show dragging rect
    Drag_ShowDragElement(objRect,blnColumn?mcntDragMoveHorz:mcntDragMoveVert,objWindow,DataGridView_ResizeEnd);
}
/// </method>

/// <method name="DataGridView_ColumnDividerMouseDown">
/// <summary>
///	Handles datagrid resizing
/// </summary>
/// <param name="objElement">The resizing element</param>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="strMember">The id of the datagrid member</param>
/// <param name="blnColumn">A flag indicating if member is column or row</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent">The event object</param>
function DataGridView_ColumnDividerMouseDown(objElement,strGrid,strMember,blnColumn,objWindow,objEvent)
{
    if(!DataGridView_ColumnDividerMouseDown.ClickInterval)
    {
        // If is the actual resizing element and not an internal element
        if(Web_GetEventSource(objEvent)==objElement)
        {
            DataGridView_ColumnDividerMouseDown.ClickInterval = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(DataGridView_ColumnDividerMouseDownAsync,objElement,strGrid,strMember,blnColumn,objWindow),mcntDoubleClickInterval);
        }
    }
}
/// </method>

/// <method name="DataGridView_ColumnDividerDoubleClick">
/// <summary>
///	Handles column divider double click
/// </summary>
function DataGridView_ColumnDividerDoubleClick(objElement,strGridID,strMemberID,objEvent,objWindow)
{
    // Clear the click time out
	Web_ClearTimeout(DataGridView_ColumnDividerMouseDown.ClickInterval,objWindow);

    // Initialize click interval value.
    DataGridView_ColumnDividerMouseDown.ClickInterval = null;

    // If is the actual resizing element and not an internal element
    if (Web_GetEventSource(objEvent) == objElement)
    {
        // Validate recieved arguments.
        if(!Aux_IsNullOrEmpty(strGridID) && !Aux_IsNullOrEmpty(strMemberID))
        {
            // Create a DividerDoubleClick event.
        	var objEvent = Events_CreateEvent(strGridID + "_" + strMemberID, "DividerDoubleClick", null, true);

        	// Cehck if DividerDoubleClick is a critical event.
        	if (Data_IsCriticalEvent(strGridID, "Event.ColumnDividerDoubleClick"))
            {
                Events_RaiseEvents();
            }

            Events_ProcessClientEvent(objEvent);
        }
    }
}
/// </method>

/// <method name="DataGridView_ExpandCollapseClick">
/// <summary>
///	Handles the expand collapse operation on an hierarchic data grid view
/// </summary>
function DataGridView_ExpandCollapseClick(objRow, strGridId, strMemberId, objWindow)
{
    DataGridView_DoExpandCollapseClick(strGridId, strMemberId, function (blnRaiseEvents, strRowId, blnIsExpanded)
    {
        if (blnRaiseEvents)
        {
            Events_RaiseEvents(new Aux_CallbackDelegate(function ()
            {
                // Change the block's height to fit the row's new height
                DataGridView_UpdateContainingBlockHeight(Data_GetNode(strRowId), !blnIsExpanded);

                // Redraw the parent grid
                DataGridView_RedrawContainingGrid(objWindow, strGridId);
            }));
        }
        else
        {
            // Change the block's height to fit the row's new height
            DataGridView_UpdateContainingBlockHeight(Data_GetNode(strRowId), !blnIsExpanded);

            // Redraw the parent grid
            DataGridView_RedrawContainingGrid(objWindow, strGridId);
        }
    });
}
/// </method>

/// <method name="DataGridView_UpdateContainingBlockHeight">
/// <summary>
///	Update the block's height according to a row's height
/// </summary>
function DataGridView_UpdateContainingBlockHeight(objRowNode, blnIsExpanded)
{
    // If the row is not frozen
    if (!(Xml_IsAttribute(objRowNode, "Attr.Frozen", "1")))
    {
        // Get the containing block
        var objContainingBlock = objRowNode.parentNode;

        if (objContainingBlock)
        {
            // Get the current block's height
            var intBlockHeight = parseInt(Xml_GetAttribute(objContainingBlock, "Attr.Height", "0"));

            // Get the child row's height
            var intChildRowHeight = parseInt(Xml_GetAttribute(objRowNode, "Attr.ChildGridHeight", "0"));

            // Decrease or increase the height according to the expansion indicator
            if (blnIsExpanded)
            {
                Xml_SetAttribute(objContainingBlock, "Attr.Height", intBlockHeight + intChildRowHeight);
            }
            else
            {
                Xml_SetAttribute(objContainingBlock, "Attr.Height", intBlockHeight - intChildRowHeight);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_OrderColumnEnd">
/// <summary>
///	Handles the actual column ordering
/// </summary>
/// <param name="objRect">The new rectangle</param>
/// <param name="objRectOld">The original rectangle</param>
function DataGridView_OrderColumnEnd(objRect,objRectOld)
{   
    // Restore global variables.
    var strGridGuid = DataGridView_OnColumnHeaderMouseDown.GridGuid;
    var strMemberId = DataGridView_OnColumnHeaderMouseDown.MemberId;
    var objWindow = DataGridView_OnColumnHeaderMouseDown.ActiveWindow;
    
    // Removes the DropTargetElement - if exists.
    Drag_RemoveDropTargetElement();
    
    // Validate drag window, drag subject, and drag subject's rectangle.
    if( objWindow && mobjDragRect &&
        !Aux_IsNullOrEmpty(strGridGuid) && !Aux_IsNullOrEmpty(strMemberId))
    {   
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_"+strGridGuid+"_"+strMemberId, objWindow);
        
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
                    var strDraggedColumnId = strMemberId;
                    
                    // Validate dragged column id.
                    if(strDraggedColumnId.indexOf("C") != 1)
                    {   
                        // Fix dragged column id.
                        strDraggedColumnId = strDraggedColumnId.substring(strDraggedColumnId.indexOf("C") + 1);
                    }
                    
                    // Get target column id.
                    var strTargetColumnId = Web_GetId(objVwgDraggedOverElement);
                    
                    // Validate target column id.
                    if(strTargetColumnId.indexOf("_C") != -1)
                    {
                        // Fix target column id.
                        strTargetColumnId = strTargetColumnId.substring(strTargetColumnId.indexOf("_C") + 2);
                    }    
                    
                    // Validate both column id's and check that they are not equal.
                    if( strDraggedColumnId && strDraggedColumnId != "" &&
                        strTargetColumnId && strTargetColumnId != "" &&
                        strDraggedColumnId != strTargetColumnId)
                    {                        
                        // Create the columns reorder event
                        var objEvent = Events_CreateEvent(strGridGuid,"ColumnsReorder",null,true);
                        
                        // Set column id's as attributes.
                        Events_SetEventAttribute(objEvent,"Attr.DraggedColumn",strDraggedColumnId);
                        Events_SetEventAttribute(objEvent, "Attr.TargetColumn", strTargetColumnId);                        
                        
                        // Raise events.
                        Events_RaiseEvents();
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_OrderColumnEnd">
/// <summary>
///	Handles the actual column ordering
/// </summary>
/// <param name="objRect">The new rectangle</param>
/// <param name="objRectOld">The original rectangle</param>
function DataGridView_OrderColumnMove()
{
    // Restore global variables.
    var strGridGuid = DataGridView_OnColumnHeaderMouseDown.GridGuid;
    var strMemberId = DataGridView_OnColumnHeaderMouseDown.MemberId;
    var objWindow = DataGridView_OnColumnHeaderMouseDown.ActiveWindow;
    
    // Validate drag window, drag subject, and drag subject's rectangle.
    if( objWindow && mobjDragRect &&
        !Aux_IsNullOrEmpty(strGridGuid) && !Aux_IsNullOrEmpty(strMemberId))        
    {   
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_"+strGridGuid+"_"+strMemberId, objWindow);
        
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

/// <method name="DataGridView_GetMemberID">
/// <summary>
///	Gets a datagrid UI member id
/// </summary>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="strMember">The id of the datagrid member</param>
/// <param name="strInstance">The instance id of the UI member</param>
/// <param name="blnColumn">A flag indicating if member is column or row</param>
function DataGridView_GetMemberID(strGrid,strMember,strInstance,blnColumn)
{
    return (blnColumn?"VWGCOL":"VWGROW")+strInstance+"_"+strGrid+"_"+strMember;
}
/// </method>

/// <method name="DataGridView_ResizeEnd">
/// <summary>
///	Handles the actual resizing
/// </summary>
/// <param name="objRect">The new rectangle</param>
/// <param name="objRectOld">The original rectangle</param>
function DataGridView_ResizeEnd(objRect,objRectOld)
{
    // Restore global variables
    var blnColumn   = DataGridView_ResizeEnd.IsColumn;
    var objTargets  = DataGridView_ResizeEnd.DragTargets;
    var strGridId   = DataGridView_ResizeEnd.GridId;
    var strMemberId = DataGridView_ResizeEnd.TargetMemberId;
    var objWindow   = DataGridView_ResizeEnd.ActiveWindow;
    
    // Get diff
    var intDiff = blnColumn ? Math.round(objRect.left - objRectOld.left) : Math.round(objRect.top - objRectOld.top);
    var strGuid = strGridId+"_"+strMemberId;
    var strAttr = blnColumn?"Attr.Width":"Attr.Height";
    
    // Get updated value
    var intValue = parseInt(Data_GetAttribute(strGuid,strAttr,"0"));
    var intOriginalValue = intValue;

    // In case of width changinf - check text direction in order to decide
    // on value increment or decrement.
    if(strAttr.toUpperCase() == "W" && mblnIsRTL)
    {
        intValue-=intDiff;
    }
    else
    {
        intValue+=intDiff;
    }
    
    // Check that is greater then 5px
    if(intValue>5)
    {
        // Update the off screen data
        Data_SetAttribute(strGuid,strAttr,intValue);
        
        // In case of row resizing.
        if(!blnColumn)
        {
            var objDataGridViewNode = Data_GetNode(strGridId);

            if (blnColumn || !Xml_IsAttribute(objDataGridViewNode, "Attr.EnforceEqualRowSize", "1"))
            {
                // Frozen rows do not need to update their parent block due to a different rendering logic for the frozen items
                if (!Data_IsAttribute(strGuid, "Attr.Frozen", "1"))
                {
                    // Get row node.
                    var objRowNode = Data_GetNode(strGuid);
                    if (objRowNode)
                    {
                        // Get row's block node.
                        var objBlockNode = objRowNode.parentNode;
                        if (objBlockNode)
                        {
                            // Get block's height.
                            var intBlockHeight = Xml_GetAttribute(objBlockNode, "Attr.Height", "");
                            if (!Aux_IsNullOrEmpty(intBlockHeight))
                            {
                                // Update block's height attribute.
                                Xml_SetAttribute(objBlockNode, "Attr.Height", String(Number(intBlockHeight) + intDiff));
                            }
                        }
                    }
                }
            }
            else
            {
                // Get all Blocks
                var arrDataGridViewBlocks = Xml_SelectNodes("WG:Tags.DataGridViewBlock", objDataGridViewNode);
                
                // Get all rows
                var arrDataGridViewRows = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow", objDataGridViewNode);

                // Update all rows' height
                for (var i = 0; i < arrDataGridViewBlocks.length; ++i)
                {
                    // Calculate how many items the block contains
                    var intNumberOfBlockItems = (parseInt(Xml_GetAttribute(arrDataGridViewBlocks[i], strAttr))) / intOriginalValue;

                    // Set the block's size according to the new height
                    Xml_SetAttribute(arrDataGridViewBlocks[i], strAttr, intNumberOfBlockItems * intValue);
                }

                // Update all rows' height
                for (var i = 0; i < arrDataGridViewRows.length; ++i)
                {
                    Xml_SetAttribute(arrDataGridViewRows[i], strAttr, intValue);
                }

            }
        }
               
        // Redraw the grid 
        Controls_RedrawControlById(objWindow,strGridId);
        
        // Create the resizing event
        var objEvent = Events_CreateEvent(strGuid,"Resize",null,true);
        Events_SetEventAttribute(objEvent, "Attr.Value", intValue);       
        
        // Check if resize event is critical and raise event.
        if (Data_IsCriticalEvent(strGuid, "Event.SizeChange"))
        {
            Events_RaiseEvents();
        }

        Events_ProcessClientEvent(objEvent);
    }
}
/// </method>

/// <method name="DataGridView_FocusDataGridViewTable">
/// <summary>
///	
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
function DataGridView_FocusDataGridViewTable(objWindow, objGridNode, blnSynchronicFocus)
{
    if(blnSynchronicFocus)
    {
        if (objWindow && objGridNode)
        {
            // Check if grid has active cell - If there are then no need to set focus on the grid element
            if (!DataGridView_HasActiveCells(objGridNode))
            {
                var objGridElement = Web_GetElementByDataId(Xml_GetAttribute(objGridNode, "Attr.Id"), objWindow);
                if (objGridElement)
                {
                    // Get cell's focusable element.
                    var objFocusableElement = Controls_GetFocusElement(objGridElement);
                    if (objFocusableElement)
                    {
                        Web_SetFocus(objFocusableElement, false);
                    }
                }
            }
        }
    }
    else
    {
        // Recall function with delay
        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(DataGridView_FocusDataGridViewTable, objWindow, objGridNode, true), 200);
    }
}
/// </method>

/// <method name="DataGridView_HasActiveCells">
/// <summary>
///	Check whether the grid has active Cells
/// </summary>
function DataGridView_HasActiveCells(objGridNode)
{
    return Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Active='1']", objGridNode).length > 0;
}
/// </method>

/// <method name="DataGridView_IsValidNavigationKey">
/// <summary>
///	
/// </summary>
function DataGridView_IsValidNavigationKey(objGridNode,objWindow,objEvent)
{
     // Get key code.
    var intKeyCode = Web_GetEventKeyCode(objEvent);
    
    // Check if control key is held.
    var blnControlKey = Web_IsControl(objEvent);
    
    // Check if alt key is held.
    var blnAltKey = Web_IsAlt(objEvent);
    
    // Check if key code is a navigation key.
    var blnIsNavigationKey = Web_IsNavigationKey(intKeyCode) || [mcntEnterKey,mcntTabKey,mcntEscapeKey].contains(intKeyCode);
    if (blnIsNavigationKey)
    {
        // Check if navigation key should be filtered.
        blnIsNavigationKey = !DataGridView_ShouldFilterNavigationKey(objGridNode, intKeyCode);

        if (blnIsNavigationKey)
        {
            // Get current node
            var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);
            if (objCurrentCellNode)
            {
                // Check if current cell's type.
                switch (Xml_GetAttribute(objCurrentCellNode, "Attr.Type"))
                {
                    // Combobox cell  
                    case "6":
                        // Check that keycode is not the down key or up key and that the alt key is not held.
                        blnIsNavigationKey = !(blnAltKey && (intKeyCode == mcntDownKey || intKeyCode == mcntUpKey));
                        break;
                }
            }
        }
    }
    
    return blnIsNavigationKey;
}
/// </method>

/// <method name="DataGridView_HandleNavigation">
/// <summary>
///	
/// </summary>
function DataGridView_HandleNavigation(objWindow,objGridNode,objCurrentCellNode,objEvent)
{
    // Validate recieved arguments.
	if (objWindow && objGridNode && objCurrentCellNode && objEvent)
	{
		// Get key code.
		var intKeyCode = Web_GetEventKeyCode(objEvent);

		// Check if control key is held.
		var blnControlKey = Web_IsControl(objEvent);

		// Prevent default.
		Web_EventCancelBubble(objEvent, true, false);

		// Define switch indicating whether escape was pressed.
		var blnEscapeKey = false;
		var blnDidMove = false;

		var intDirHoriShiftModifier = (mblnIsRTL) ? -1 : 1;
		switch (intKeyCode)
		{
			case mcntEscapeKey:
				blnEscapeKey = true;
				break;
			case mcntLeftKey:
				if (!blnControlKey)
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, (-1 * intDirHoriShiftModifier), 0);
				}
				else
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, (mblnIsRTL ? mcntMoveEnd : mcntMoveBegin), 0);
				}
				break;
			case mcntUpKey:
				if (!blnControlKey)
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, -1);
				}
				else
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, mcntMoveBegin);
				}
				break;

			case mcntRightKey:
				if (!blnControlKey)
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, (1 * intDirHoriShiftModifier), 0);
				}
				else
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, (mblnIsRTL ? mcntMoveBegin : mcntMoveEnd), 0);
				}
				break;
			case mcntTabKey:
				//if StandardTab = false, handle gridview level navigation
				if (!Xml_IsAttribute(objGridNode, "Attr.StandardTab", "1"))
				{
					if (!blnControlKey)
					{
						// Validate objCurrentCellNode.
						if (objCurrentCellNode)
						{
							// Define x and y positions.
							var intY = null;
							var intX = null;

							// Check tab direction.
							if (Web_IsShift(objEvent))
							{
								// Check if current selection is on last cell in the row and that the next sibling is not a data grid view (for hierarchic grid)
								if (objCurrentCellNode.previousSibling != null && !Xml_IsAttribute(objCurrentCellNode.previousSibling, "Attr.Type", "7"))
								{
									// Navigate to previous cell
									intY = 0;
									intX = -1;
								}
					            else if (DataGridView_GetPreviousRowFromCellNode(objCurrentCellNode, true))
								{
									// Navigate to previous row/block and it's last cell
									intY = -1;
									intX = mcntMoveEnd;
								}
							}
							else
							{
								// Check if current selection is on last cell in row
								if (objCurrentCellNode.nextSibling != null && objCurrentCellNode.nextSibling.nodeName != "WC:Tags.DataGridView")
								{
									// Navigate to next cell
									intY = 0;
									intX = 1;
								}
								else if ((objCurrentCellNode.parentNode != null &&
                                        objCurrentCellNode.parentNode.nextSibling != null)
										||
										(objCurrentCellNode.parentNode != null &&
                                        objCurrentCellNode.parentNode.parentNode != null &&
                                        objCurrentCellNode.parentNode.parentNode.nextSibling != null))
								{
									// Navigate to next row/block and it's first cell
									intY = 1;
									intX = mcntMoveBegin;
								}
							}

							// Validate x and y positions.
							if (intX != null & intY != null)
							{
								// Fire key down event.
								Web_FireKeyDown(Web_GetEventSource(objEvent), objEvent, false);

								// Navigate to next row and it's first cell
								blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, intX, intY);

								// Cancel buble.
								Web_EventCancelBubble(objEvent, false, true);
							}
						}
					}
				}
				break;
			case mcntDownKey:
				if (!blnControlKey)
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, 1);
				}
				else
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, mcntMoveEnd);
				}
				break;
			case mcntEnterKey:
				blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, 1);
				break;
			case mcntEndKey:
				if (!blnControlKey)
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, mcntMoveEnd, 0);
				}
				else
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, mcntMoveEnd, mcntMoveEnd);
				}
				break;
			case mcntHomeKey:
				if (!blnControlKey)
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, mcntMoveBegin, 0);
				}
				else
				{
					blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, mcntMoveBegin, mcntMoveBegin);
				}
				break;
			case mcntPageUpKey:
				blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, -10);
				break;
			case mcntPageDownKey:
				blnDidMove = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intKeyCode, blnControlKey, 0, 10);
				break;
		}

		// Try getting focus element for the current cell node.
		var objFocusElement = null;

		// If this cell supports active mode
		if (objCurrentCellNode && Xml_IsAttribute(objCurrentCellNode, "Attr.SupportActiveMode", "1"))
		{
			// Try getting focus element for the current cell node.
			objFocusElement = Controls_GetFocusElementByDataId(DataGridView_GetFullMemberID(objGridNode, objCurrentCellNode));
			if (objFocusElement)
			{
				// In case that escape key was pressed.
				if (blnEscapeKey)
				{
				    // Remove any blur handlers to avoid value change of the textbox.
				    objFocusElement.onblur = null;

				    // Attach blur handler.
				    Web_AttachEvent(objFocusElement, "blur", DataGridView_OnActiveCelllBlur);
				}
			}
		}

		// Check if focus element has already been set.
		if (!objFocusElement)
		{
			// Try getting focus element for the current cell node.
			objFocusElement = Controls_GetFocusElementByDataId(DataGridView_GetFullMemberID(objGridNode, objCurrentCellNode));
		}

		// If current navigation element exists, and the next nav. item found, or not in EditOnEnter mode.
		if (objFocusElement  && (!Xml_IsAttribute(objGridNode, "Attr.EditMode", "0") || blnDidMove))
		{
			// Blur focus element.
			Web_Blur(objFocusElement);
		}
	}
}
/// </method>

/// <method name="DataGridView_BeginActivateCell">
/// <summary>
///	
/// </summary>
function DataGridView_BeginActivateCell(objWindow, objGridNode, objCellNode)
{
    if (!Xml_IsAttribute(objCellNode, "Attr.Active", "1"))
    {
        // Get cell full member id.
        var strCellFullMemberID = DataGridView_GetFullMemberID(objGridNode, objCellNode);

        var blnIsBeginEditCritical = Data_IsCriticalEvent(strCellFullMemberID, "Event.BeginEdit");

        // Create a BeginEdit event.
        var objVwgEvent = Events_CreateEvent(strCellFullMemberID, "BeginEdit", null, true, false, !blnIsBeginEditCritical);

        // Check if begin edit is critical for the activated
        if (blnIsBeginEditCritical)
        {
        	// Raise events.
        	Events_RaiseEvents();
        }

        // Activate cell.
        DataGridView_ActivateCell(objWindow, objGridNode, objCellNode);

        // Process client BeginEdit event.
        Events_ProcessClientEvent(objVwgEvent);
    }
}
/// </method>


/// <method name="DataGridView_NavigateCell">
/// <summary>
///	
/// </summary>
function DataGridView_NavigateCell(objWindow,objGridNode,objCellNode,objCurrentCellNode,intKeyCode,blnIncremental)
{
    // Validate recieved arguments.
    if(objWindow && objGridNode && objCellNode && objCurrentCellNode)
    {
        // Clear selected cells.
        DataGridView_ClearSelectedCells(objWindow,objGridNode);
        
        // Get the current selection mode
        var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
        if(intSelectionMode==2)
        {
            // Toggle row selection.
            DataGridView_ToggleRowSelection(objWindow,objGridNode,objCellNode.parentNode,true,true);
        }
        else
        {
            // Toggle cell selection.
            DataGridView_ToggleCellSelection(objWindow,objGridNode,objCellNode,true,true);
        }
        
        // Set current cell.
        DataGridView_SetCurrentCell(objGridNode,objCellNode);

        // Check if EditMode is EditOnEnter
        if (Xml_IsAttribute(objGridNode, "Attr.EditMode", "0"))
        {
            DataGridView_BeginActivateCell(objWindow, objGridNode, objCellNode);
        }

        // Define scroll mode variable.
        var intScrollMode = 0;
        
        // Check if only a vertical scrolling is needed.
        if([mcntUpKey,mcntDownKey,mcntEnterKey,mcntPageUpKey,mcntPageDownKey].contains(intKeyCode))
        {
            intScrollMode = 1;
        }
        // Check if only an horizontal scrolling is needed.
        else if([mcntLeftKey,mcntRightKey].contains(intKeyCode))
        {
            intScrollMode = 2;
        }
        
        // Scrolls into view.
        DataGridView_ScrollCellIntoView(objWindow,objGridNode,objCellNode,intScrollMode);

        if(!Xml_IsAttribute(objCurrentCellNode,"Attr.Active","1") || 
	        DataGridView_ShouldActiveCellFireSelectionChangeAfterNavigation(objWindow,objGridNode,objCurrentCellNode,intKeyCode))
        {
            // Fire selection change.
            DataGridView_FireSelectionChange(objGridNode,false,blnIncremental,false);
        }
        
        // Redraw header.
        DataGridView_UpdateRowHeaders(objWindow,objGridNode,objCellNode,objCurrentCellNode);
    }
}
/// </method>

/// <method name="DataGridView_ShouldActiveCellFireSelectionChangeAfterNavigation">
/// <summary>
///	
/// </summary>
function DataGridView_ShouldActiveCellFireSelectionChangeAfterNavigation(objWindow,objGridNode,objCurrentCellNode,intKeyCode)
{
    var blnShouldFireSelectionChangeAfterNavigation = true;
    
    if(objGridNode)
    {
        if(objCurrentCellNode)
        {
            switch(Xml_GetAttribute(objCurrentCellNode,"Attr.Type"))
            {
                case "1":   // Textbox cell
                    
                    var blnValueChanged = false;
                    
                    var objCellElement = DataGridView_GetCellElement(objWindow,objGridNode,objCurrentCellNode);
                    if(objCellElement)
                    {
                        var objInputElement = Web_GetContextElementById(objCellElement,"TRG_"+DataGridView_GetFullMemberID(objGridNode,objCurrentCellNode));
                        if(objInputElement)
                        {
                            var strValue = objInputElement.value;
                            if ((Xml_HasAttribute(objCurrentCellNode,"Attr.Value") || !Aux_IsNullOrEmpty(strValue)) &&
		                            !Xml_IsAttribute(objCurrentCellNode,"Attr.Value",strValue))
		                    {
		                        blnValueChanged = true;
                            }
                        }
                    }
                
                    blnShouldFireSelectionChangeAfterNavigation = !blnValueChanged;
                    break;
            }
        }
    }

    return blnShouldFireSelectionChangeAfterNavigation;                    
}
/// </method>

/// <method name="DataGridView_KeyDown">
/// <summary>
///	Handle data grid key down actions
/// </summary>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent">The event object</param>
function DataGridView_KeyDown(strGuid,objWindow,objEvent)
{
    if (!DataGridView_IsEventSourceFromAChildGrid(strGuid, objEvent))
    {
        // Get key code.
        var intKeyCode = Web_GetEventKeyCode(objEvent);

        // Check if control key is held.
        var blnControlKey = Web_IsControl(objEvent);

        // Check if alt key is held.
        var blnAltKey = Web_IsAlt(objEvent);

        // In case of control and tab - let infrastructure handle tab key.
        if (!(intKeyCode == mcntTabKey && blnControlKey))
        {
            // Get grid node
            var objGridNode = Data_GetNode(strGuid);
            if (objGridNode)
            {
                // Get last selected node
                var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);

                // Check if navigation key pressed.
                if (DataGridView_IsValidNavigationKey(objGridNode, objWindow, objEvent))
                {
                    // Handle key down navigation.
                    DataGridView_HandleNavigation(objWindow, objGridNode, objCurrentCellNode, objEvent);
                }
                // Handle delete key.
                else if (intKeyCode == mcntDeleteKey)
                {
                    DataGridView_HandleDelete(objGridNode);
                }
                // Handle CTRL C(Copy)
                else if (blnControlKey && intKeyCode == mcntCkeyCode)
                {
                    DataGridView_HandleCopy(objGridNode);
                }
                // Handle CTRL A(Select all)
                else if (blnControlKey && intKeyCode == mcntAkeyCode)
                {
                    DataGridView_SelectAllGridRows(strGuid, objWindow, objEvent);
                }
                // Default key down handling.
                else if (objCurrentCellNode)
                {
                    // Check whether key down default behavior should be prevented.
                    var blnPreventDefaultKeyBehavior = (!Xml_IsAttribute(objCurrentCellNode, "Attr.Type", "1") &&
                                                    Web_GetEventKeyCode(objEvent) == mcntSpaceKey);

                    // In case of an activating keycode, handle keydown cell activation.
                    if (DataGridView_IsActivatingKeyCode(intKeyCode))
                    {
                        DataGridView_HandleKeyDownCellActivation(objWindow, objGridNode, objCurrentCellNode, objEvent);
                    }

                    // Check if needed to prevent default key behavior.
                    if (blnPreventDefaultKeyBehavior)
                    {
                        // Prevent default key behavior.
                        Web_EventCancelBubble(objEvent, true, false);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_HandleCopy">
/// <summary>
///	Run over the selected cells or rows and copy it to the clipboard
/// </summary>
/// <param name="objGridNode">The grid</param>
function DataGridView_HandleCopy(objGridNode)
{
    var strCSV="";
    var intRowID ="";
    var intPrevRowID ="";
    var strCellValue = "";
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
        
    // Define selected rows array.
    var arrSelectedRowsNodes = null;

    // In case of FullRowSelect selection mode.    
    if(intSelectionMode==2)
    {
        // Get all selected rows.
        arrSelectedRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[@Attr.Selected='1']",objGridNode);
    }
    // In case of CellSelect selection mode.       
    else if(intSelectionMode==1)
    {
        // Get all rows which has selected cells.
        arrSelectedRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[./WG:Tags.DataGridViewCell/@Attr.Selected='1']",objGridNode);
    }
    // In case of RowHeaderSelect selection mode.       
    else if(intSelectionMode==8)
    {
        // Get all rows which has selected cells.
        arrSelectedRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[./WG:Tags.DataGridViewCell/@Attr.Selected='1' or @Attr.Selected='1']",objGridNode);
    }
    
    if(arrSelectedRowsNodes)
    {
        // Loop all child items(rows)
        for(var intIndex=0;intIndex<arrSelectedRowsNodes.length;intIndex++)
        {
            // Get current row node
            var objSelectedRowNode = arrSelectedRowsNodes[intIndex];
    		
    		if(objSelectedRowNode)
    		{
    		    //In not in a FullRowSelect selection mode.
    		    if(intSelectionMode!=2)
    		    {
    		        var strMemberId = Xml_GetAttribute(objSelectedRowNode,"mId","");
    		        
                    //Look for the row id(index)
    		        if(strMemberId != "")
    		        {	
    		            //get the new row id(index) and insert empty rows between selected cells if exist
    		            intRowID  = parseInt(strMemberId.replace("R",""));
    		                	                
    		            //In the first time
    		            if(intPrevRowID == "")
    		            {
    		                intPrevRowID  = intRowID;
    		            }
    		            else
    		            {
    		                while(intPrevRowID < intRowID-1)
    		                {
    		                    //New row(Enter)
    		                    strCSV = strCSV + "\r\n";
    		                    
    		                    // Raise index.
    		                    intPrevRowID++;
    		                }
    		                
    		                //Save the last row id(index)
    		                intPrevRowID = intRowID;
    		            }
    		        }
                }    		
    		
    		    //Get all of the cells of the currnt row
	            var objSelectedRowCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell",objSelectedRowNode);
                
                //run all over the cells
	            for(var intCellIndex=0;intCellIndex<objSelectedRowCellNodes.length;intCellIndex++)
	            {
	                //get the cell node object
	                var objSelectedCellNode = objSelectedRowCellNodes[intCellIndex];
        		    
    		        if(objSelectedCellNode)
    		        {
    		            //clear the value
    		            strCellValue ="";
    		            
    		            //Cell selection mode
    		            if(Xml_IsAttribute(objSelectedCellNode, "Attr.Selected", "1") || Xml_IsAttribute(objSelectedCellNode.parentNode, "Attr.Selected", "1"))
                        {
    		                //Get the cell value
    		                strCellValue = Xml_GetAttribute(objSelectedCellNode, "Attr.Value", "");
    		            }
        		    
        		        //Check for the last column
	                    if(intCellIndex == objSelectedRowCellNodes.length-1)
	                    {
	                        //Insert cell value and Enter for a new row
                            strCSV = strCSV + strCellValue + "\r\n";
	                    }
	                    else
	                    {
	                        //Insert cell value and Tab  
                            strCSV = strCSV + strCellValue + "\t";
	                    }
	                }    
	            }
    		}
        }
        
        //Copy the data to ClipBoard
        Web_CopyToClipBoard("Text",strCSV);
    }
}
/// </method>

/// <method name="DataGridView_Navigate">
/// <summary>
///	Impliments a navigation executer that navigates relativly to the last selected cell
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCurrentCellNode">The current grid cell data node</param>
/// <param name="intKeyCode">The key code pressed</param>
/// <param name="blnControlKey">Whether control key is pressed</param>
/// <param name="intMoveX">The horizontal navigation factor</param>
/// <param name="intMoveY">The vertical navigation factor</param>
function DataGridView_Navigate(objWindow,objGridNode,objCurrentCellNode,intKeyCode,blnControlKey,intMoveX,intMoveY)
{
    if( objGridNode && objCurrentCellNode &&
        !Xml_IsAttribute(objGridNode,"Attr.DisableNavigation","1"))
    {        
        // Get row count.
        var intRowCount = parseInt(Xml_GetAttribute(objGridNode,"Attr.RowCount","0"),10);
        
        // Get the virtual block size.
        var intVirtualBlockSize = parseInt(Xml_GetAttribute(objGridNode,"Attr.VirtualBlockSize","0"),10);
        
        // Validate rows count, columns count and virtual block size.
        if(intRowCount > 0 && intVirtualBlockSize > 0)
        {
            // Get current cell's row node.
            var objCurrentCellRowNode = objCurrentCellNode.parentNode;
            if(objCurrentCellRowNode)
            {
                // Get current cell's block node.
                var objCurrentCellBlockNode = objCurrentCellRowNode.parentNode;
                if(objCurrentCellBlockNode)
                {
                    // Calculate current cell's block position.
                    var intCurrentCellBlockPosition = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewBlock",objCurrentCellBlockNode).length;

					// Calculate current cell's row position.
                    var intCurrentCellRowPosition = Xml_GetPosition(objCurrentCellRowNode)+(intCurrentCellBlockPosition*intVirtualBlockSize);
                                        
                    // Define a negative navigated cell row position.
                    var intNavigatedCellRowPosition = -1;
                    
                    // get target row
                    switch (intMoveY)
                    {
                    	case mcntMoveBegin:
                    		intNavigatedCellRowPosition = 0;
                    		break;
                    	case mcntMoveEnd:
                            intNavigatedCellRowPosition = (intRowCount-1);
                            break;
                        default:
                            if((intCurrentCellRowPosition + intMoveY)>=0 && (intCurrentCellRowPosition + intMoveY)<intRowCount)
                            {
                                intNavigatedCellRowPosition = (intCurrentCellRowPosition+intMoveY);
                            }
                            else if(intMoveY>0 && intCurrentCellRowPosition!=intRowCount-1)
                            {
                                intNavigatedCellRowPosition = (intRowCount-1);
                            }
                            else if(intMoveY<0 && intCurrentCellRowPosition!=0)
                            {
                                intNavigatedCellRowPosition = 0;
                            }
                    }
                    
                    if(intNavigatedCellRowPosition >= 0)
                    {
                        // Navigate row.
                        DataGridView_NavigateRow(objWindow, objGridNode, intNavigatedCellRowPosition, intMoveX, objCurrentCellNode, intKeyCode, blnControlKey);

                        // Return a value indicating that the navigation has found a target cell
                        return true;
                    }
                }
            } 
        }   
    }

    // Return a value indicating that the navigation had not found a target cell
    return false;
}
/// </method>

/// <method name="DataGridView_NavigateRow">
/// <summary>
///	
/// </summary>
function DataGridView_NavigateRow(objWindow,objGridNode,intRowPosition,intMoveX,objCurrentCellNode,intKeyCode,blnControlKey)
{
    // Validate recieved arguments.
    if(objWindow && objGridNode && objCurrentCellNode)
    {
        // Get the visrtual block size.
        var intVirtualBlockSize = parseInt(Xml_GetAttribute(objGridNode,"Attr.VirtualBlockSize","0"),10);
        if(intVirtualBlockSize>0)
        {
            // Calculate the requested block position.
            var intBlockPosition = Math.floor(intRowPosition / intVirtualBlockSize)+1;
            
            // Get the requested block node.
            var objBlockNode = Xml_SelectSingleNode("WG:Tags.DataGridViewBlock[@Attr.MemberID='Tags.DataGridViewBlock"+intBlockPosition+"']",objGridNode);
			if(objBlockNode)
            {
                // Check if block is loaded.
                if(Xml_IsAttribute(objBlockNode,"Attr.Loaded","1"))
                {                    
                    // Get block's child row nodes.
                    var objChildRowNodes = objBlockNode.childNodes;
                    if(objChildRowNodes)
                    {
                        // Calculate row position whithin the block.
                        var intRowPositionInBlock = (intRowPosition % intVirtualBlockSize);
                        
                        // Validte row position in block.
                        if( intRowPositionInBlock >= 0 &&
                            intRowPositionInBlock < objChildRowNodes.length)
                        {   
                            // Get row node.
                            var objRowNode = objChildRowNodes[intRowPositionInBlock];
                            if(objRowNode)
                            {
                                // Get current cell's X location.
                                var intCurrentCellColumnPosition = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objCurrentCellNode).length;
                                
                                var objNavigatedCellNode = null;
                            
                                // Get contained cell nodes.
                                var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objRowNode);
                                if(objCellNodes)
                                {
                                    // Get cell nodes length.
                                    var intCellNodesLength = objCellNodes.length;
                                    if(intCellNodesLength > 0)
                                    {
                                        if(intMoveX==mcntMoveBegin)
                                        {
                                            objNavigatedCellNode = objCellNodes[0];
                                        }
                        				else if (intMoveX == mcntMoveEnd)
                        				{
                        					objNavigatedCellNode = objCellNodes[intCellNodesLength - 1];
                        				}
                        				else if ((intCurrentCellColumnPosition + intMoveX) >= 0 && (intCurrentCellColumnPosition + intMoveX) < intCellNodesLength)
                        				{
                        					objNavigatedCellNode = objCellNodes[intCurrentCellColumnPosition + intMoveX];
                        				}
                        			}
                        		}

                        		// Check that navigated cell is valid.
                        		if (objNavigatedCellNode && objNavigatedCellNode != objCurrentCellNode)
                        		{
                                    DataGridView_NavigateCell(objWindow,objGridNode,objNavigatedCellNode,objCurrentCellNode,intKeyCode,blnControlKey);
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Set a call back to "DataGridView_NavigateRow" function in order to navigate to the desired row
                    // after server is loading the missing block.
                    DataGridView_SyncBlocksData.fncCallbackDelegate = {fncMethod:DataGridView_NavigateRow,arrArguments:[objWindow,objGridNode,intRowPosition,intMoveX,objCurrentCellNode,intKeyCode,blnControlKey]};
                    
                    // Scroll block into view.
                    DataGridView_ScrollBlockIntoView(objWindow,objGridNode,objBlockNode);
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_FireSelectionChange">
/// <summary>
///	Notifies the server about selection changes
/// </summary>
/// <param name="objGridNode">The altered grid</param>
/// <param name="blnSuspendEvents">A boolean that indicates whether to raise events or not.</param>
/// <param name="blnSelectAll">A boolean that indicates whether to select all cells or not.</param>
function DataGridView_FireSelectionChange(objGridNode, blnSuspendEvents, blnIncremental, blnSelectAll)
{
    // Get selected entities
    var strSelectedEntities = (blnSelectAll?"*":DataGridView_GetSelectedEntities(objGridNode).join(","));
    
    // Get the grid's ID value.
    var strGuid = Xml_GetAttribute(objGridNode,"Attr.Id");
    
    // Creat ea new selection change event.
    var objVWGEvent = Events_CreateEvent(strGuid,"SelectionChanged",null,true);
    
    // Set value attribute.
    Events_SetEventAttribute(objVWGEvent,"Attr.Value",strSelectedEntities);

    	// Set the current cell attribute.
    	var strCurrentCell = Xml_GetAttribute(objGridNode, "Attr.CurrentCell", "");
    	if (strCurrentCell != "")
    	{
    		Events_SetEventAttribute(objVWGEvent, "Attr.CurrentCell", strCurrentCell);
    	}
    
    // Check if should render Incremental attribute.
	if(blnIncremental)
	{
	    Events_SetEventAttribute(objVWGEvent,"Incremental","1");
	}	
     
    // Raise events.
	if (!blnSuspendEvents && Data_IsCriticalEvent(strGuid, "Event.SelectionChange"))
    {    
        Events_RaiseEvents();
    }

    Events_ProcessClientEvent(objVWGEvent);   
}
/// </method>

/// <method name="DataGridView_GetSelectedEntities">
/// <summary>
///	Get Selected entities
/// </summary>
/// <param name="objGridNode">The altered grid</param>
function DataGridView_GetSelectedEntities(objGridNode)
{
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
    var arrSelected = [];
    
    // FullRowSelect or RowHeaderSelect mode.
    if(intSelectionMode==2 || intSelectionMode==8)
    {
        var objSelectedRowNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[@Attr.Selected='1']",objGridNode);
        
        // Loop all child items
        for(var intIndex=0;intIndex<objSelectedRowNodes.length;intIndex++)
        {
            arrSelected.push(Xml_GetAttribute(objSelectedRowNodes[intIndex],"Attr.MemberID"));    
        } 
    }
    
    // CellSelect or RowHeaderSelect mode.    
    if(intSelectionMode==1 || intSelectionMode==8)
    {
        var objSelectedCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Selected='1']",objGridNode);
        
        // Loop all child items
        for(var intIndex=0;intIndex<objSelectedCellNodes.length;intIndex++)
        {
            arrSelected.push(Xml_GetAttribute(objSelectedCellNodes[intIndex],"Attr.MemberID")); 
        }        
    }
    return arrSelected;
}

/// </method>

/// <method name="DataGridView_CellClick">
/// <summary>
///	Handle cell click action
/// </summary>
/// <param name="objCellElement"></param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent">The HTML event object.</param>
function DataGridView_CellClick(objCellElement,objWindow,objEvent)
{
   if(objCellElement)
    {
        // Update client cell selection.
        DataGridView_UpdateSelection(objCellElement,objWindow,objEvent);
        
        // Get DataGridView node
        var objGridNode = DataGridView_GetGridNode(objCellElement);
        
        // Get cell node.
        var objCellNode = DataGridView_GetNodeFromElement(objCellElement);
        
        if(objGridNode && objCellNode)        
        {
            // Gets grid's guid.
            var strGridGuid = Xml_GetAttribute(objGridNode,"Attr.Id","");
            
            /// Get cell full member id.
            var strCellMemberID = DataGridView_GetFullMemberID(objGridNode,objCellNode);
            
            // Validate id's.
            if(strGridGuid!="" && strCellMemberID!="")
            {
                // Raise events is selection change is critical.
                if (Data_IsCriticalEvent(strGridGuid, "Event.SelectionChange"))
                {
                    // Handles the click event and forces raise (this 'overload' cancels the click bubble.
                    Web_OnClick(objEvent,objWindow,true);
                }
            }
        }
    }
}
/// </method>


/// <method name="DataGridView_UpdateCellSelectSelection">
/// <summary>
///	
/// </summary>
function DataGridView_UpdateCellSelectSelection(objGridNode,objCellNode,objWindow,objEvent)
{
    // Validate recieved arguments.
    if(objGridNode && objCellNode && objWindow && objEvent)
    {
        //get old selected entities
	    var strOldSelectedCells = DataGridView_GetSelectedEntities(objGridNode).join(",");
        
        // Get last selected cell node
        var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);
            
        // Define a switch which will indicate whether to toggle cell selection or not.
        var blnToggleCellSelection = true;
        
        // Check if cell is selected.
        var blnIsSelectedCell = Xml_IsAttribute(objCellNode,"Attr.Selected","1");
        
        // Check if cell's row is selected.
        var blnIsContainedRowSelected = Xml_IsAttribute(objCellNode.parentNode,"Attr.Selected","1");
        
        // Check if multi selection is enabled.
        var blnIsMultiSelectionEnabled = DataGridView_IsMultiSelectionEnabled(objGridNode);

        // Check if EditMode is EditOnEnter
        var blnIsEditOnEnter = Xml_IsAttribute(objGridNode, "Attr.EditMode", "0");

        // If is range click
        if(Web_IsShift(objEvent) && blnIsMultiSelectionEnabled)
        {
            if(objCurrentCellNode)
            {
                // Toggle selection range
                DataGridView_SelectCellRange(objWindow,objGridNode,objCellNode,objCurrentCellNode);
            }

            // Flag not to toggle.
            blnToggleCellSelection = false;
        }
        // If normal click
        else if(!Web_IsControl(objEvent) || !blnIsMultiSelectionEnabled)
        {
            // Clear previous selected cells
            DataGridView_ClearSelectedCells(objWindow,objGridNode,objCellNode);
            
            // If cell was seleceted.
            if (blnIsSelectedCell || blnIsContainedRowSelected || blnIsEditOnEnter)
            {
                // Check if cell is not read only.
                if(DataGridView_CanActivateCell(objGridNode,objCellNode))
                {
                    // Check if selected cell is current cell.
                    if (DataGridView_GetCurrentCell(objGridNode) == objCellNode || blnIsEditOnEnter)
                    {
                        // Check if begin init event was attached or invoke Cell activation
                        DataGridView_BeginActivateCell(objWindow, objGridNode, objCellNode);
                        
                        // Flag not to toggle.
                        blnToggleCellSelection = blnIsEditOnEnter && !(blnIsSelectedCell || blnIsContainedRowSelected);
                    }
                    // In case that cell is not current cell - check if the selected cell was selected previously.
                    else if(blnIsSelectedCell)
                    {
                        // Flag not to toggle.
                        blnToggleCellSelection = false;
                    }
                }
                // In case that cell is read only - check if the selected cell was selected previously.
                else if(blnIsSelectedCell)
                {
                    // Flag not to toggle.
                    blnToggleCellSelection = false;
                }
            }
        }
        
        // Check if toggling is needed.
        if(blnToggleCellSelection)
        {            
            // In case that containg row was fully selected.
            if(Xml_IsAttribute(objCellNode.parentNode,"Attr.Selected","1"))
            {
                // Toggle handled cell selection - GUI only.
                DataGridView_ToggleCellSelection(objWindow,objGridNode,objCellNode,true,false);
                    
                // Unselect containg row.
                Xml_SetAttribute(objCellNode.parentNode,"Attr.Selected","0");
                
                // Get chiild nodes length.
                var intChildLength = objCellNode.parentNode.childNodes.length;
                
                // Loop all of the handled cell's siblings.
                for(var intCellIndex=0; intCellIndex<intChildLength; intCellIndex++)
                {
                    // Get current cell node.
                    var objChildCellNode = objCellNode.parentNode.childNodes[intCellIndex];
                    
                    // Check if current cell is not the handled one and that it is not selected.
                    if(objCellNode!=objChildCellNode && !Xml_IsAttribute(objChildCellNode,"Attr.Selected","1"))
                    {
                        // Select current cell.
                        Xml_SetAttribute(objChildCellNode,"Attr.Selected","1");
                    }
                }
            }
            else
            {
                // Add or remove cell selection
                DataGridView_ToggleCellSelection(objWindow,objGridNode,objCellNode,true,true);
            }
        }
        
        if (Xml_IsAttribute(objCellNode,"Attr.Selected","1") || blnIsEditOnEnter)
        {
            DataGridView_SetCurrentCell(objGridNode,objCellNode);
        }
        
        // Redraw row headers.
        DataGridView_UpdateRowHeaders(objWindow,objGridNode,objCellNode,objCurrentCellNode);
        
        if(strOldSelectedCells!=DataGridView_GetSelectedEntities(objGridNode).join(","))
        {
            // Fire selection change event.
            DataGridView_FireSelectionChange(objGridNode,true,Web_IsControl(objEvent),false);
        }
    }
}
/// </method>


/// <method name="DataGridView_UpdateSelection">
/// <summary>
///	
/// </summary>
function DataGridView_UpdateSelection(objClickSource,objWindow,objEvent)
{   
     // Get cell node
	var objCellNode = DataGridView_GetNodeFromElement(objClickSource);	
	
    // Get grid node.
	var objGridNode = DataGridView_GetGridNode(objClickSource);    
	
    // Get the current selection mode
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
    
    //In case of FullRowSellect.
    if(intSelectionMode==2)
    {
        DataGridView_UpdateFullRowSelectSelection(false,objWindow,objEvent,objGridNode,objCellNode.parentNode,objCellNode);
    }
    //In case of CellSellect or RowHeaderSelect.
    else if(intSelectionMode==1 || intSelectionMode==8)
    {
        DataGridView_UpdateCellSelectSelection(objGridNode,objCellNode,objWindow,objEvent);
    }
}
/// </method>

/// <method name="DataGridView_RowHeaderClick">
/// <summary>
///	Handles row header click event
/// </summary>
/// <param name="objCell">The row header cell</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent"></param>
/// <param name="objGridNode"></param>
/// <param name="objRowNode"></param>
/// <param name="objCellNode"></param>
/// <param name="blnSetDgvTableFocus">A boolean that indicates whether to set the DGV focus.</param>
function DataGridView_RowHeaderClick(objCell,objWindow,objEvent,blnSetDgvTableFocus)
{   
    // Get cell node
      var objRowNode = DataGridView_GetNodeFromElement(objCell);
      if(objRowNode)
      {        
        // Get contained cell nodes.
        var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objRowNode);
        if(objCellNodes)
        {
            // Get grid's node.
            var objGridNode = DataGridView_GetGridNode(objCell);
            if(objGridNode)
            {
                // Get the current cell.
                var objCellNode = DataGridView_GetCurrentCell(objGridNode);

                var blnNeedSaveScroll = Xml_IsAttribute(objCellNode.parentNode, "Attr.IsNew", "1");

                // Check if current cell row changed 
                if(!objCellNode || objCellNode.parentNode!=objRowNode)
                {
                    // Set the first cell node as current cell.
                    objCellNode = objCellNodes[0];
                }
                
                // Update row selection.
                DataGridView_UpdateFullRowSelectSelection(true,objWindow,objEvent,objGridNode,objRowNode,objCellNode,blnSetDgvTableFocus);
                
                // Gets grid's guid.
                var strGridGuid = Xml_GetAttribute(objGridNode,"Attr.Id","");
                
                /// Get row full member id.
                var strRowMemberID = DataGridView_GetFullMemberID(objGridNode,objRowNode);
                
                // Validate id's.
                if(!Aux_IsNullOrEmpty(strGridGuid) && !Aux_IsNullOrEmpty(strRowMemberID))
                {
                    
                    // Raise events is selection change is critical.
                    if (Data_IsCriticalEvent(strGridGuid, "Event.SelectionChange"))
                    {
                        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
                        Web_OnClick(objEvent,objWindow, true);
                    }
                }

                if (Xml_IsAttribute(objCellNode.parentNode, "Attr.IsNew", "1") || (blnNeedSaveScroll))
                {
                    // Get the scollable element
                    var objScrollElement = Web_GetWebElement("VWGVLSC_" + strGridGuid, objWindow);

                    // Get the scroll position value
                    var strScrollTop = objScrollElement.scrollTop;

                    // Store scrolling position
                    Xml_SetAttribute(objGridNode, "Attr.ScrollTop", strScrollTop);

                    var objScrollEvent = Events_CreateEvent(strGridGuid, "ScrollPositionChanged", null, true);

                    if (objScrollEvent)
                    {
                        Events_SetEventAttribute(objScrollEvent, "Attr.ScrollTop", strScrollTop);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_UpdateFullRowSelectSelection">
/// <summary>
///	Handles row header click event
/// </summary>
/// <param name="blnIsHeaderCellSource">Whether click source is a header cell</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent"></param>
/// <param name="objGridNode"></param>
/// <param name="objRowNode"></param>
/// <param name="objCellNode"></param>
/// <param name="blnSetDgvTableFocus">A boolean that indicates whether to set the DGV focus.</param>
function DataGridView_UpdateFullRowSelectSelection(blnIsHeaderCellSource,objWindow,objEvent,objGridNode,objRowNode,objCellNode,blnSetDgvTableFocus)
{
	if(objGridNode && objRowNode)
	{	
	    //get old selected entities    
	    var strOldSelectedCells = DataGridView_GetSelectedEntities(objGridNode).join(",");;
	    
        // Set default required status
        var strRequiredSelectedStatus = "1";
        
        // Check ig multi selection is enabled.
        var blnIsMultiSelectionEnabled = DataGridView_IsMultiSelectionEnabled(objGridNode);
        
        // If is adding click
        if(Web_IsControl(objEvent) && blnIsMultiSelectionEnabled)
        {
            strRequiredSelectedStatus = (Xml_IsAttribute(objRowNode,"Attr.Selected","1")?"0":"1");
        }
        // If is range click
        else if(Web_IsShift(objEvent) && blnIsMultiSelectionEnabled)
        {
            // Clears all selected cells in grid.
            DataGridView_ClearSelectedCells(objWindow,objGridNode);
            
            // Get current cell node.
            var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);
            if(objCurrentCellNode)
            {
                // Get current cell's row node.
                var objCurrentCellRowNode = objCurrentCellNode.parentNode;
                if(objCurrentCellRowNode)
                {
                    // Selec row range.
                    DataGridView_SelectRowRange(objWindow,objGridNode,objRowNode,objCurrentCellRowNode);
                }
            }
        }
        // If normal click
        else
        {
            var blnSelectedRow = (objRowNode && Xml_IsAttribute(objRowNode,"Attr.Selected","1"));

            // Clear all selected cells.
            DataGridView_ClearSelectedCells(objWindow,objGridNode,objRowNode);

            // Check if handled cell should be activated.
            if (objCellNode && DataGridView_CanActivateCell(objGridNode, objCellNode))
            {
                if (!blnIsHeaderCellSource && blnSelectedRow && DataGridView_GetCurrentCell(objGridNode) == objCellNode)
                {
                    DataGridView_BeginActivateCell(objWindow, objGridNode, objCellNode);
                }
                else if (Xml_IsAttribute(objGridNode, "Attr.EditMode", "0"))
                {
                    DataGridView_BeginActivateCell(objWindow, objGridNode, objCellNode);
                }
            }
        }
        
        // Get the current cell.
        var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);
    
        // Check if recieved row does not have the desired seleced status.
        if(!Xml_IsAttribute(objRowNode,"Attr.Selected",strRequiredSelectedStatus))
        {       
            // Get contained cell nodes.
            var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objRowNode);
            if(objCellNodes)
            {     
                // Get the number of cells.
                var intCellsLength = objCellNodes.length;

                // Loop all child items
                for(var intIndex=0;intIndex<intCellsLength;intIndex++)
                {
                    // Clear cell's selected attribute.
                    Xml_SetAttribute(objCellNodes[intIndex],"Attr.Selected","0");
                    
	                // Toggle cell selection.
                    DataGridView_ToggleCellSelection(objWindow,objGridNode,objCellNodes[intIndex],true,false);
                }
            }
            
            // Toggle row selection mode
            Xml_SetAttribute(objRowNode,"Attr.Selected",strRequiredSelectedStatus);
        }
        
        // Set current cell.   
        DataGridView_SetCurrentCell(objGridNode,objCellNode);
        
        // Redraw row header.   
        DataGridView_UpdateRowHeaders(objWindow, objGridNode, objCellNode, objCurrentCellNode, objRowNode);

        if(blnSetDgvTableFocus)
        {
            // Set the DataGridView table focus.
            DataGridView_FocusDataGridViewTable(objWindow,objGridNode);
        }

        if(strOldSelectedCells!=DataGridView_GetSelectedEntities(objGridNode).join(","))
        {
            // Fire selection change event.
            DataGridView_FireSelectionChange(objGridNode,true,Web_IsControl(objEvent),false);
        }
    }
}
/// </method>

/// <method name="DataGridView_SelectCellRange">
/// <summary>
///	Toggles the state of a selected cell range
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objFromCellNode">The current grid cell data node</param>
/// <param name="objToCellNode">The last selected cell data node</param>
function DataGridView_SelectCellRange(objWindow,objGridNode,objFromCellNode,objToCellNode)
{
    // Get the visrtual block size.
    var intVirtualBlockSize = parseInt(Xml_GetAttribute(objGridNode,"Attr.VirtualBlockSize","0"),10);
    if(intVirtualBlockSize>0)
    {
        // Get row nodes.
        var objFromRowNode = objFromCellNode.parentNode;
        var objToRowNode = objToCellNode.parentNode;
        
        // Validate row nodes.
        if(objFromRowNode && objToRowNode)
        {
            // Get block nodes.
            var objFromBlockNode = objFromRowNode.parentNode;
            var objToBlockNode = objToRowNode.parentNode;
            
            // Validate block nodes.
            if(objFromBlockNode && objToBlockNode)
            {
                // Get column count.
                var intColumnCount = Xml_SelectNodes("WG:Tags.DataGridViewColumn",objGridNode).length;
                
                // Get cell header count.
                var intCellHeaderCount = Xml_SelectNodes("WG:Tags.DataGridViewCell",objGridNode).length;
                
                // Get block position.
                var intFromBlockY = Xml_GetPosition(objFromBlockNode)-(intColumnCount+intCellHeaderCount)+1;
                var intToBlockY = Xml_GetPosition(objToBlockNode)-(intColumnCount+intCellHeaderCount)+1;
                
                // Claulcate blocks position.
                var intFromRowY = Xml_GetPosition(objFromRowNode)+((intFromBlockY-1)*intVirtualBlockSize);
                var intToRowY = Xml_GetPosition(objToRowNode)+((intToBlockY-1)*intVirtualBlockSize);
                
                // Get cells x position.
                var intFromCellX = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objFromCellNode).length;
                var intToCellX = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objToCellNode).length;
                
                // Normalize X range
                if(intFromCellX>intToCellX)
                {
                    var intTempX = intFromCellX;
                    intFromCellX = intToCellX;
                    intToCellX = intTempX;
                }
                
                // Normalize Y range
                if(intFromRowY>intToRowY)
                {
                    intTempY = intFromRowY;
                    intFromRowY = intToRowY;
                    intToRowY = intTempY;
                }

                // Iterate row range
	            for(var intRow=intFromRowY;intRow<=intToRowY;intRow++)
	            {
	                // Calculate the requested block position.
                    var intBlockPosition = Math.floor(intRow / intVirtualBlockSize)+1;
                    
                    // Get the requested block node.
                    var objBlockNode = Xml_SelectSingleNode("WG:Tags.DataGridViewBlock[@Attr.MemberID='Tags.DataGridViewBlock"+intBlockPosition+"']",objGridNode);
                    if(objBlockNode)
                    {
                        // Check if block is loaded.
                        if(Xml_IsAttribute(objBlockNode,"Attr.Loaded","1"))
                        {                    
                            // Get block's child row nodes.
                            var objChildRowNodes = objBlockNode.childNodes;
                            if(objChildRowNodes)
                            {
                                // Calculate row position whithin the block.
                                var intRowPositionInBlock = (intRow % intVirtualBlockSize);
                                
                                // Validte row position in block.
                                if( intRowPositionInBlock >= 0 &&
                                    intRowPositionInBlock < objChildRowNodes.length)
                                {
	                                // Get current row
	                                var objCurrentRow = objChildRowNodes[intRowPositionInBlock];
	                                if(objCurrentRow && !Xml_IsAttribute(objCurrentRow,"Attr.Selected","1"))
	                                {
	                                    // Get target cell nodes.
	                                    var objTargetCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objCurrentRow);
	                                    if(objTargetCellNodes)
	                                    {
	                                        // Iterate cell range
	                                        for(var intCell=intFromCellX;intCell<=intToCellX;intCell++)
	                                        {
	                                            // Get current cell
	                                            var objChildNode = objTargetCellNodes[intCell];
	                                            if(objChildNode && !Xml_IsAttribute(objChildNode,"Attr.Selected","1"))
	                                            {
	                                                // Toggle cell state 
	                                                DataGridView_ToggleCellSelection(objWindow,objGridNode,objChildNode,true,true);
	                                            }
	                                        }
	                                    }
	                                }
	                            }
	                        }
	                    }
	                }
	            }
	        }
	    }
	}
}
/// </method>

/// <method name="DataGridView_SelectRowRange">
/// <summary>
///	Toggles the state of a selected row range
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objFromRowNode">The current grid row data node</param>
/// <param name="objToRowNode">The last selected row data node</param>
function DataGridView_SelectRowRange(objWindow,objGridNode,objFromRowNode,objToRowNode)
{
    // Get the visrtual block size.
    var intVirtualBlockSize = parseInt(Xml_GetAttribute(objGridNode,"Attr.VirtualBlockSize","0"),10);
    if(intVirtualBlockSize>0)
    {
        // Get block nodes.
        var objFromBlockNode = objFromRowNode.parentNode;
        var objToBlockNode = objToRowNode.parentNode;
        
        // Validate block nodes.
        if(objFromBlockNode && objToBlockNode)
        {
            // Get column count.
            var intColumnCount = Xml_SelectNodes("WG:Tags.DataGridViewColumn",objGridNode).length;
            
            // Get cell header count.
            var intCellHeaderCount = Xml_SelectNodes("WG:Tags.DataGridViewCell",objGridNode).length;
            
            // Get block position.
            var intFromBlockY = Xml_GetPosition(objFromBlockNode)-(intColumnCount+intCellHeaderCount)+1;
            var intToBlockY = Xml_GetPosition(objToBlockNode)-(intColumnCount+intCellHeaderCount)+1;
            
            // Claulcate blocks position.
            var intFromRowY = Xml_GetPosition(objFromRowNode)+((intFromBlockY-1)*intVirtualBlockSize);
            var intToRowY = Xml_GetPosition(objToRowNode)+((intToBlockY-1)*intVirtualBlockSize);
            
            // Normalize Y range
            if(intFromRowY>intToRowY)
            {
                intTempY = intFromRowY;
                intFromRowY = intToRowY;
                intToRowY = intTempY;
            }

            // Iterate row range
	        for(var intRow=intFromRowY;intRow<=intToRowY;intRow++)
	        {
	            // Calculate the requested block position.
                var intBlockPosition = Math.floor(intRow / intVirtualBlockSize)+1;
                
                // Get the requested block node.
                var objBlockNode = Xml_SelectSingleNode("WG:Tags.DataGridViewBlock[@Attr.MemberID='Tags.DataGridViewBlock"+intBlockPosition+"']",objGridNode);
                if(objBlockNode)
                {
                    // Check if block is loaded.
                    if(Xml_IsAttribute(objBlockNode,"Attr.Loaded","1"))
                    {                    
                        // Get block's child row nodes.
                        var objChildRowNodes = objBlockNode.childNodes;
                        if(objChildRowNodes)
                        {
                            // Calculate row position whithin the block.
                            var intRowPositionInBlock = (intRow % intVirtualBlockSize);
                            
                            // Validte row position in block.
                            if( intRowPositionInBlock >= 0 &&
                                intRowPositionInBlock < objChildRowNodes.length)
                            {
	                            // Get current row
	                            var objCurrentRow = objChildRowNodes[intRowPositionInBlock];
	                            if(objCurrentRow && !Xml_IsAttribute(objCurrentRow,"Attr.Selected","1"))
	                            {
                                    // Toggle row selection.
                                    DataGridView_ToggleRowSelection(objWindow,objGridNode,objCurrentRow,true,true);
	                            }
	                        }
	                    }
	                }
	            }
	        }
	    }
	}
}
/// </method>

/// <method name="DataGridView_ClearSelectedCells">
/// <summary>
///	Clears the current selected cells
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objExcludedNode">A node to be excluded - can be a row or a cell node.</param>
function DataGridView_ClearSelectedCells(objWindow,objGridNode,objExcludedNode)
{
    // Get the current selection mode
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
        
    // Define xpath variables.
    var strXPath = "WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow";
    var strConditionXPath = "@Attr.Selected='1'";
    
    // Validate excluded node.
    if(objExcludedNode)
    {
        // Update the condition Xpath.
        strConditionXPath += (" and not(@Attr.MemberID='"+Xml_GetAttribute(objExcludedNode,"Attr.MemberID","")+"')");
    }

    // FullRowSelect mode.    
    if(intSelectionMode==2)
    {
        // Concat the full xpath.
        strXPath += ("["+strConditionXPath+"]");
    }
    // CellSelect mode.        
    else if(intSelectionMode==1)
    {   
        // Concat the full xpath.        
        strXPath += ("/WG:Tags.DataGridViewCell["+strConditionXPath+"]");
    }
    // RowHeaderSelect mode.
    else if(intSelectionMode==8)
    {   
        // Concat the full xpath.        
        strXPath += ("["+strConditionXPath+"] | WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell["+strConditionXPath+"]");
    }
    
    // Get selected nodes.
    var arrSelectedNodes = Xml_SelectNodes(strXPath,objGridNode);
    if(arrSelectedNodes && arrSelectedNodes.length>0)
    {
        // Get selected nodes length.
        var intNoneSelectedNodesLength = arrSelectedNodes.length;
        
        // Loop all child items
        for(var intIndex=0;intIndex<intNoneSelectedNodesLength;intIndex++)
        {
	        // Get current cell node
	        var objSelectedNode = arrSelectedNodes[intIndex];
    		
            // In case of a row node.    
            if(objSelectedNode.tagName=="WG:Tags.DataGridViewRow")
            {
                DataGridView_ToggleRowSelection(objWindow,objGridNode,objSelectedNode,true,true);	            	                
            }
            // In case of a cell node.    
            else if(objSelectedNode.tagName=="WG:Tags.DataGridViewCell")
            {
                DataGridView_ToggleCellSelection(objWindow,objGridNode,objSelectedNode,true,true);	            
            }
        }
	}
}
/// </method>

/// <method name="DataGridView_PerformScrollIntoView">
/// <summary>
///	Implements a scroll into view behavior for the data grid
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="blnHidePopups">Switvch that indicates whether to hide popups or not.</param>
function DataGridView_PerformScrollIntoView(strGuid,strCellId,blnHidePopups)
{
    // Get the relevant window
    var objWindow = Forms_GetWindowByDataId(strGuid);
    if(objWindow)
    {
        // Check if popups should be hidden.
        if(blnHidePopups)
        {
            // Get the grid element.
            var objDataGridViewElement = Web_GetElementByDataId(strGuid,objWindow);
            if(objDataGridViewElement)
            {
                // Hide all popups beside the popup element the grid might be located in.
                Popups_HidePopups(objDataGridViewElement);
            }
        }
        
        // Get the grid node.
        var objGridNode = Data_GetNode(strGuid);
        if(objGridNode)
        {
            // Scroll into view.
            DataGridView_ScrollCellIntoView(objWindow,objGridNode,Data_GetNodeByMember(strCellId, objGridNode, true),0);
        }
    }
}
/// </method>

/// <method name="DataGridView_ScrollCellIntoView">
/// <summary>
///	Implements a scroll into view behavior for the datagrid
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="intMode">intMode = {0 - Both horizontal and vertical scrolling ; 1- Vertical scrolling. ; 2 - horizontal scrolling.}</param>
function DataGridView_ScrollCellIntoView(objWindow,objGridNode,objCellNode,intMode)
{
    // Validate recieved arguments.
    if(objWindow && objGridNode && objCellNode)
    {
        // Get cell element
        var objCellElement = DataGridView_GetCellElement(objWindow,objGridNode,objCellNode);
        if(objCellElement)
        {
            // Get the scollable element
            var objScrollElement = Web_GetWebElement("VWGVLSC_"  + Xml_GetAttribute(objGridNode,"Id"),objWindow);

            // If cell and scrollable elements where found
            if(objScrollElement && objCellElement)
            {
                // Gets cell and scroll elements locations.
                var objCellElementRect = Web_GetRect(objCellElement);
                var objScrollElementRect = Web_GetRect(objScrollElement,true);
                
                // Take into consideration the frozen columns width in case horizontal scrolling
                if(intMode!=1)
                {
                    // Get cell's row node
                    var objRowNode = objCellNode.parentNode;
                    if(objRowNode)
                    {
                        // Get row's block node
                        var objBlockNode = objRowNode.parentNode;
                        if(objBlockNode)
                        {
                            // Get frozen row element
                            var objFrozenRows = Web_GetWebElement("VWGDGVFROZENROWS_"  + Xml_GetAttribute(objGridNode,"Id") + "_" + Xml_GetAttribute(objBlockNode,"Attr.MemberID",""),objWindow);
                            if(objFrozenRows)
                            {
                                if(mblnIsRTL)
                                {
                                    // Add frozen rows width to the right of the scroll element rect
                                    objScrollElementRect.right-=objFrozenRows.clientWidth;
                                }
                                else
                                {
                                    // Add frozen rows width to the left of the scroll element rect
                                    objScrollElementRect.left+=objFrozenRows.clientWidth;
                                }
                            }
                        }
                    }
                }
                
                // ensure cell is visible
                Web_ScrollIntoViewByRect(objCellElement,objCellElementRect,objScrollElement,objScrollElementRect,intMode);
            }
        }
        else
        {
            // Get cell's row node.
            var objRowNode = objCellNode.parentNode;
            if(objRowNode)
            {
                // Get row's block node.
                var objBlockNode = objRowNode.parentNode;
                if(objBlockNode)
                {
                    // Set a call back to the "DataGridView_ScrollCellIntoView" function in order to scroll the desired cell into view
                    // after the server is loading the missing block.
                    DataGridView_SyncBlocksData.fncCallbackDelegate = {fncMethod:DataGridView_ScrollCellIntoView,arrArguments:[objWindow,objGridNode,objCellNode,intMode]};
                    
                    // Scroll block into view.
                    DataGridView_ScrollBlockIntoView(objWindow,objGridNode,objBlockNode);
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_ScrollBlockIntoView">
/// <summary>
///	
/// </summary>
function DataGridView_ScrollBlockIntoView(objWindow,objGridNode,objBlockNode)
{
    // Validate recieved arguments.
    if(objWindow && objGridNode && objBlockNode)
    {
        // Get grid id.
        var strGridId = Xml_GetAttribute(objGridNode,"Attr.Id","");
        if(!Aux_IsNullOrEmpty(strGridId))
        {
            // Get block element.
            var objBlockElement = Web_GetElementById("VWG_"+strGridId+"_"+Xml_GetAttribute(objBlockNode,"Attr.MemberID",""), objWindow);
            if(objBlockElement)
            {
                // Get the scollable element
                var objScrollElement = Web_GetWebElement("VWGVLSC_"+strGridId,objWindow);
                if(objScrollElement)
                {
                    // Scroll block into view (vertical only).
                    Web_ScrollIntoView(objBlockElement,objScrollElement,1);
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_GetCellContainerType">
/// <summary>
///	Gets the container type of the current cell's container.
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_GetCellContainerType(objWindow, objGridNode, objCellElement)
{
    var objContainer = Web_GetWebElement("VWGVLSC_"  + Xml_GetAttribute(objGridNode,"Id"),objWindow);
    if (objContainer && Web_IsContained(objContainer,objCellElement))
    {
        return 0; // Container is a SCROLLER
    }
    else
    {
        objContainer = Web_GetWebElement("VWGDGVFROZENROWS_"  + Xml_GetAttribute(objGridNode,"Id"),objWindow);
        if (objContainer && Web_IsContained(objContainer,objCellElement))
        {
            return 1;  // Container is a ROWHEADER (Frozen Column)
        }
        else
        {
            objContainer = Web_GetWebElement("VWGDGVFROZENCOLUMNS_"  + Xml_GetAttribute(objGridNode,"Id"),objWindow);
            if (objContainer && Web_IsContained(objContainer,objCellElement))
            {
                return 2;  // Container is a COLHEADER (Frozen Row)
            }
            else
            {
                return -1; // Container type is unknown.
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_ActivateCell">
/// <summary>
///	Activates cell for editing
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_ActivateCell(objWindow,objGridNode,objCellNode)
{
    if(objCellNode)
    {
        if (Xml_IsAttribute(objCellNode, "Attr.SupportEditMode", "1"))
        {
            DataGridView_SetCellActiveState(objCellNode, true);
        }
        // If this cell supports active mode
        if (Xml_IsAttribute(objCellNode, "Attr.SupportActiveMode", "1"))
        {
            // Set node owner
            Xml_SetAttribute(objCellNode, "Attr.OwnerID", Xml_GetAttribute(objGridNode, "Attr.Id"));

            // Render active node
            Controls_RedrawControlByNode(objWindow, objCellNode);
        }
        
        // Get cell's focus element.
        var objFocusableElement = Controls_GetFocusElementByDataId(DataGridView_GetFullMemberID(objGridNode, objCellNode));
        if (objFocusableElement)
        {
            // Get focus element's tag name.
            var strElementTagName = objFocusableElement.tagName.toLowerCase();
            
            // In case of a textbox cell - set text selection.
            if (!Aux_IsNullOrEmpty(objFocusableElement.value) &&
				(strElementTagName == "input" || strElementTagName == "textarea"))
            {
                Web_SetSelection(objFocusableElement, 0, objFocusableElement.value.length);
            }
            else
            {
                // Activate focusable element.
                Web_SetActive(objFocusableElement);

                // Set focus on first focusable child.
                Web_SetFocus(objFocusableElement);
            }

            // Attach blur handler.
            Web_AttachEvent(objFocusableElement, "blur", DataGridView_OnActiveCelllBlur);
        }
    }
}
/// </method>

/// <method name="DataGridView_OnActiveCelllBlur">
/// <summary>
///   
/// </summary>
function DataGridView_OnActiveCelllBlur(objEvent)
{
    // Get event source.
    var objSource = Web_GetEventSource(objEvent);
    if(objSource)
    {
        // Deattach blur handler.
        Web_DetachEvent(objSource,"blur",DataGridView_OnActiveCelllBlur);
        
        // Get VWG source element.
        var objVwgSource = Web_GetVwgElement(objSource, true);
        if(objVwgSource)
        {   
            // Get grid node.
            var objGridNode = DataGridView_GetGridNode(objVwgSource);
            if(objGridNode)
            {
                // Get cell's data id.
                var strCellDataId = Data_GetDataId(Web_GetId(objVwgSource));
                if(!Aux_IsNullOrEmpty(strCellDataId))
                {
                    // Get grid's window
                    var objWindow = Forms_GetWindowByDataId(strCellDataId);
                    if(objWindow)
                    {
                        // Get cell node.
                        var objCellNode = Data_GetNode(strCellDataId);
                        if(objCellNode)
                        {
                            //Check if combobox cell share focus
                            if (!Popups_ShareFocusWithExistPopup(strCellDataId)) {
                            	
                                var blnIsEndEditCritical = Data_IsCriticalEvent(strCellDataId, "Event.EndEdit");

								// Create a EndEdit event.
                                var objVwgEvent = Events_CreateEvent(strCellDataId, "EndEdit", null, true, false, !blnIsEndEditCritical);

                                // Check if end edit is critical for the deactivation
                                if (blnIsEndEditCritical) 
								{
									// Raise events.
									Events_RaiseEvents();
                                }

                                // Render active node
                                DataGridView_DeactivateCell(objWindow,objGridNode,objCellNode);
                            
                                // Render row headers
                                DataGridView_UpdateRowHeaders(objWindow, objGridNode, DataGridView_GetCurrentCell(objGridNode), objCellNode);

                                // Process client EndEdit.
                                Events_ProcessClientEvent(objVwgEvent);  
                             }   
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_SetCellActiveState">
/// <summary>
///   
/// </summary>
function DataGridView_SetCellActiveState(objCellNode,blnActiveState)
{
    // Validate cell node.
    if(objCellNode)
    {
		Xml_SetAttribute(objCellNode, "Attr.Active", blnActiveState ? "1" : "0");
    }
}
/// </method>

/// <method name="DataGridView_DeactivateCell">
/// <summary>
///   Deactivates a cell 
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="blnCancelUpdating">Cancels updating mode if is in active mode.</param>
/// <param name="strGridGuid">The data grid view guid.</param>
function DataGridView_DeactivateCell(objWindow,objGridNode,objCellNode)
{
    if(objGridNode)
    {
        // If not cell node
        if(!objCellNode)
        {
            // Get current node
            objCellNode = DataGridView_GetCurrentCell(objGridNode);
        }
        
        // Set active node
        if(objCellNode && Xml_IsAttribute(objCellNode,"Attr.Active","1"))
        {
            // Deactivate cell.
			DataGridView_SetCellActiveState(objCellNode, false);

			// If this cell supports active mode
            if (Xml_IsAttribute(objCellNode, "Attr.SupportActiveMode", "1"))
            {
            	// Set node owner
                Xml_SetAttribute(objCellNode, "Attr.OwnerID", Xml_GetAttribute(objGridNode, "Attr.Id"));

				// Render active node
                Controls_RedrawControlByNode(objWindow, objCellNode);
			}

			// Check if grid is the focus element.
			if (Xml_IsAttribute(objGridNode, "Attr.Id", Focus_GetFocusElementDataId()))
			{
				// Move focus back to grid's table. Essential for handling 'Escape' pressed to cancel cell editing
				DataGridView_FocusDataGridViewTable(objWindow, objGridNode);
			} 
        }
    }
}
/// </method>

/// <method name="DataGridView_SelectAllGridRows">
/// <summary>
///	Handles Selection of All rows
/// </summary>
/// <param name="objCell">The row header cell</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent">The event object</param>
function DataGridView_SelectAllGridRows(strGridGuid,objWindow,objEvent)
{    
    // Get grid node
    var objGridNode = Data_GetNode(strGridGuid);
    if(objGridNode)
    {             
        // Get the current selection mode
        var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
            
        // Define none selected cell array.
        var arrNoneSelectedNodes = null;

        // FullRowSelect or RowHeaderSelect mode.
        if(intSelectionMode==2 || intSelectionMode==8)
        {
            // Get all unselected rows.
            arrNoneSelectedNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[not(@Attr.Selected) or @Attr.Selected='0']",objGridNode);           
        }
        // CellSelect mode.
        else if(intSelectionMode==1)
        {
            // Get all unselected cells.
            arrNoneSelectedNodes = Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[not(@Attr.Selected) or @Attr.Selected='0']",objGridNode);
        }      
         	    
        if(arrNoneSelectedNodes)
        {
            // Get nodes array length.
            var intNoneSelectedNodesLength = arrNoneSelectedNodes.length;
            
            // Loop all none selected nodes.
            for(var intIndex=0;intIndex<intNoneSelectedNodesLength;intIndex++)
            {
                // FullRowSelect or RowHeaderSelect mode.
                if(intSelectionMode==2 || intSelectionMode==8)
                {      
                    // Select current row
                    DataGridView_ToggleRowSelection(objWindow, objGridNode, arrNoneSelectedNodes[intIndex],false,true);
                }
                // CellSelect mode.    
                else if(intSelectionMode==1)
                {
                    // Select current cell                                                                                         
                    DataGridView_ToggleCellSelection(objWindow, objGridNode, arrNoneSelectedNodes[intIndex],false,true);
                }
            }
            
            // Check if none selected nodes has been found or if any unloaded blocks exists.
            if( intNoneSelectedNodesLength>0 || 
                Xml_SelectNodes("WG:Tags.DataGridViewBlock[not(@Attr.Loaded='1')]",objGridNode).length>0)
            {
                // Fire selection change.
                DataGridView_FireSelectionChange(objGridNode,false,Web_IsControl(objEvent),true);
            }
            
            if(intNoneSelectedNodesLength>0)
            {
                // Redraws grid.
                Controls_RedrawControlById(objWindow,strGridGuid);
            }
        }
    }

    // Prevent default behavior.
	Web_EventCancelBubble(objEvent,true,false);
}
/// </method>

/// <method name="DataGridView_ToggleRowSelection">
/// <summary>
///	Toggle the state of a cell's row between selected and not selected
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objRowNode">The current grid cell data node</param>
/// <param name="blnToggleGui">Determine weather to toggle Gui</param>
/// <param name="blnToggleData">Determine weather to toggle data</param>
function DataGridView_ToggleRowSelection(objWindow,objGridNode,objRowNode,blnToggleGui,blnToggleData)
{
    if(objRowNode)
    {
        // Get contained cell nodes.
        var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]" ,objRowNode);
        if(objCellNodes)
        {
            for(var i=0; i<objCellNodes.length; i++)
            {
                var objCellNode = objCellNodes[i];
                if(objCellNode)
                {
                    DataGridView_ToggleCellSelection(objWindow,objGridNode,objCellNode,blnToggleGui,blnToggleData && Xml_IsAttribute(objCellNode,"Attr.Selected","1"));
                }
            }
        }
        
        if(blnToggleData)
        {
            // Check whether handled row is selected.
            var blnIsSelected =  Xml_IsAttribute(objRowNode,"Attr.Selected","1");
            
            // Toggle row selection mode
            Xml_SetAttribute(objRowNode,"Attr.Selected",blnIsSelected?"0":"1");
        }
        
        // Redraw header.
        DataGridView_RedrawRowHeader(objWindow,objGridNode,objRowNode);
    }
}
/// </method>

/// <method name="DataGridView_ToggleCellSelection">
/// <summary>
///	Toggle the state of a cell between selected and not selected
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="blnToggleGui">Determine weather to toggle Gui</param>
/// <param name="blnToggleData">Determine weather to toggle data</param>
function DataGridView_ToggleCellSelection(objWindow,objGridNode,objCellNode,blnToggleGui,blnToggleData)
{
    // Check whether handled node is selected.
    var blnIsSelected =  (Xml_IsAttribute(objCellNode,"Attr.Selected","1") || Xml_IsAttribute(objCellNode.parentNode,"Attr.Selected","1"));
    
    // Toggle data attribute.
    if(blnToggleData)
    {
        Xml_SetAttribute(objCellNode,"Attr.Selected",blnIsSelected?"0":"1");
    }
    
    // Check if gui should be updated.
    if(blnToggleGui)
    {
        // Get cell element
        var objCellElement = DataGridView_GetCellElement(objWindow,objGridNode,objCellNode);
        if(objCellElement)
        {
            // Get grid's id.
            var strDataID = Xml_GetAttribute(objGridNode, "Attr.Id");

            // Define empty variables.
            var strBackgroundColor="";
            var strForeColor="";

            // Get control's theme.
            var strClassName = Controls_GetTheme(strDataID);

            // Add a class spacer if needed.
            if(!Aux_IsNullOrEmpty(strClassName))
            {
                strClassName += " ";
            }
            else
            {
                strClassName = "";
            }
        
            // If cell is selected
            if(blnIsSelected)
            {
                // Get the BackgroundColor and ForeColor from the rendered XML
                strBackgroundColor= Xml_GetAttribute(objCellNode,"Attr.Background","");
                strForeColor= Xml_GetAttribute(objCellNode,"Attr.Fore","");
                
                // Set normal class name.
                strClassName += "DataGridView-Cell";
            }
            else
            {
                // Get the BackgroundColor and ForeColor from the rendered XML
                strBackgroundColor= Xml_GetAttribute(objCellNode,"Attr.SelectionBackColor","");
                strForeColor= Xml_GetAttribute(objCellNode,"Attr.SelectionForeColor","");
                
                // Set selected class name.
                strClassName += "DataGridView-Cell_Selected";            
            }
            
            // Set class name.
            if(!Aux_IsNullOrEmpty(strClassName))
            {
		        objCellElement.className=strClassName;
		    }
        	
            // Set background color.
            objCellElement.style.backgroundColor=strBackgroundColor;

            // Set fore color.
            objCellElement.style.color=strForeColor;
        }
        else
        {
            // Get cell's row node.
            var objRowNode = objCellNode.parentNode;
            if(objRowNode)
            {
                // Get row's block node.
                var objBlockNode = objRowNode.parentNode;
                if(objBlockNode)
                {
                    // Get block element.
                    var objBlockElement = Web_GetElementById("VWG_"+Xml_GetAttribute(objGridNode,"Attr.Id","")+"_"+Xml_GetAttribute(objBlockNode,"Attr.MemberID",""), objWindow);
                    if(objBlockElement)
                    {
                        // Initialize the is drawn attribute.
                        Web_SetAttribute(objBlockElement,"vwg_IsDrawn","0");
                        
                        // Kill the drawn element.
                        objBlockElement.vwg_DrawnElement = null;
                    }
                }
            }
        }

        // If IE switch focus to the DGV from cell.
        if (mcntIsIE)
        {
            var objGridElement = Web_GetElementByDataId(Xml_GetAttribute(objGridNode, "Attr.Id"), objWindow);
            if (objGridElement)
            {

                var objFocusable = Controls_GetFocusElement(objGridElement);

                if (objFocusable)
                {
                    Web_SetFocus(objFocusable);
                }
            }
        }
    }
}
/// </method>


/// <method name="DataGridView_AfterCreateTextBoxEvents">
/// <summary>
///	
/// </summary>
function DataGridView_AfterCreateTextBoxEvents(objWindow,objEvent,strSourceDataId,strEventType,strTargetDataId)
{
    if(strEventType=="ValueChange")
    {
        // Validate recieved arguments.
        if(!Aux_IsNullOrEmpty(strSourceDataId))
        {            
            // Get DataGridView node.
            var objGridNode = Data_GetNode(Data_GetDataOwnerId(strSourceDataId));
            if(objGridNode)
            {
                // Fires the selection change event.
                DataGridView_FireSelectionChange(objGridNode,true,false,false);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_SyncVirtualScrollers">
/// <summary>
///	
/// </summary>
function DataGridView_SyncVirtualScrollers(objWindow, objVirtualScrollerElement, objBlocksContainer, strGuid, strDir)
{
    // Validate recieved arguments.
    if (objWindow && objVirtualScrollerElement && objBlocksContainer && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strDir))
    {
        // Handle Extended Columns scroll-sync
        DataGridView_DoSyncScrollers(Web_GetElementById("XCH_" + strGuid, objWindow), objVirtualScrollerElement, 1, strDir, "Width");
        
        // Clear previous vertical scroller synchronizing.
        Web_ClearTimeout(mintBlocksDataSyncHandler, objWindow);

        // Perform an aynych blocks data synchronizing.
        mintBlocksDataSyncHandler = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(DataGridView_SyncBlocksData, objWindow, objVirtualScrollerElement, objBlocksContainer, strGuid, strDir), 100);

        // Synchronize blocks container's scollers.
        DataGridView_SyncBlocksContainersScrollers(objWindow, objVirtualScrollerElement, objBlocksContainer, strGuid, strDir);
    }
}
/// </method>

/// <method name="DataGridView_SyncBlocksData">
/// <summary>
///	
/// </summary>
function DataGridView_SyncBlocksData(objWindow,objVirtualScrollerElement,objBlocksContainer,strGuid,strDir)
{
    // Validate recieved arguments.
    if(objWindow && objVirtualScrollerElement && objBlocksContainer && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strDir))
    {
        // Get virtual scroller's scroll top position.
        var intVirtualScrollerScrollTop = objVirtualScrollerElement.scrollTop;
        
        // Get virtual scroller's scroll client height.
        var intVirtualScrollerHeight = objVirtualScrollerElement.clientHeight;
        
        // Calculate virtual scroller's bottom position.
        var intVirtualScrollerBottom = intVirtualScrollerScrollTop + intVirtualScrollerHeight;

        // Get blocks elements
        var arrBlockElements  = objBlocksContainer.childNodes;

        // Define arrays which will assist in blocks sorting.
        var arrVisibleUndrawnBlocks = [];
        var arrVisibleUnloadedBlocks = [];
        var arrVisibleDrawnBlocks = [];
        var arrInvisibleDrawnBlocks = [];
        
        // Loops all blocks.
        for(var intIndex = 0; intIndex< arrBlockElements.length; intIndex++)
        {
            // Get current element.
            var objGridBlock = arrBlockElements[intIndex];
            
            // Get block's top position.
            var intBlockTop = objGridBlock.offsetTop;
            
            // Get block's height.
            var intBlockHeight = objGridBlock.clientHeight;
            
            // Calculate block's bottom position.
            var intBlockBottom = intBlockTop +  intBlockHeight;
            
            // Define a variable which will indicate if current block is visible.
            var blnBlockIsVisible = false;
            
            // Check if the top part of the block is visible.
            if(intBlockTop >= intVirtualScrollerScrollTop && intBlockTop <= intVirtualScrollerBottom)
            {
                blnBlockIsVisible = true;
            }
            // Check if the bottom part of the block is visible.
            else if(intBlockBottom >= intVirtualScrollerScrollTop && intBlockBottom <= intVirtualScrollerBottom)
            {
                blnBlockIsVisible = true;
            }
            // Check if the block spreads over the whole scrolling area.
            else if(intBlockTop < intVirtualScrollerScrollTop && intBlockBottom > intVirtualScrollerBottom)
            {
                blnBlockIsVisible = true;
            }
            
            // Check if current block should be visible.
            if(blnBlockIsVisible)
            {
                // Check if current block is not already drawn.
                if(!Web_IsAttribute(objGridBlock, "vwg_IsDrawn", "1"))
                {
                    // Check if current block is not already loaded.
                    if(!Web_IsAttribute(objGridBlock, "vwg_IsLoaded", "1"))
                    {
                        //checking if the block has NOT been called already
                        if (!Web_IsAttribute(objGridBlock, "vwg_IsRequested", "1")) 
                        {
                            // Push current block into the visible unloaded array.
                            arrVisibleUnloadedBlocks.push(objGridBlock);
                        }
                    }
                    else
                    {
                        // Push current block into the visible undrawn array.
                        arrVisibleUndrawnBlocks.push(objGridBlock);
                    }
                }    
                else
                {
                    // Push current block into the visible drawn array.
                    arrVisibleDrawnBlocks.push(objGridBlock);
                }                
            }
            else
            {
                // Check if current block is already drawn.
                if(Web_IsAttribute(objGridBlock, "vwg_IsDrawn", "1"))
                {
                    // Push current block into the invisible drawn array.
                    arrInvisibleDrawnBlocks.push(objGridBlock);
                }
            }
        }
        
        // Loop all visible unloaded blocks.
        for(var intIndex = 0; intIndex< arrVisibleUnloadedBlocks.length; intIndex++)
        {
            // Get current block element.
            var objGridBlock = arrVisibleUnloadedBlocks[intIndex];
           
            // Create a load event for current block.
            Events_CreateEvent(Data_GetDataId(objGridBlock.id), "Load", null, true);

            //setting the block as one being requested
            Web_SetAttribute(objGridBlock, "vwg_IsRequested", "1");          
        }
        
        // In case that there is one visible unloaded block.
        if(arrVisibleUnloadedBlocks.length > 0)
        {
            // Check if a valid raise events call back delegate has been set.
            if(!Aux_IsNullOrEmpty(DataGridView_SyncBlocksData.fncCallbackDelegate) &&
                DataGridView_SyncBlocksData.fncCallbackDelegate != undefined)
            {
                // Raise events with delegate.
                Events_RaiseEvents(DataGridView_SyncBlocksData.fncCallbackDelegate);
                
                // Clear local delegate.
                DataGridView_SyncBlocksData.fncCallbackDelegate = null;
            }
            else
            {
                // Raise events without delegate.
                Events_RaiseEvents();
            }
        }
       
        // Loop all visible undrawn blocks.
        for(var intIndex = 0; intIndex< arrVisibleUndrawnBlocks.length; intIndex++)
        {
            // Get current block element.
            var objGridBlock = arrVisibleUndrawnBlocks[intIndex];
            
            // Get bolck node.
            var objGridBlockNode = Data_GetNode(Data_GetDataId(objGridBlock.id));
            
            // Set the block visibility to true.
            Xml_SetAttribute(objGridBlockNode, "Attr.Visible","1");
            
            // Redraw control.
            Controls_RedrawControlByNode(objWindow, objGridBlockNode, false);
        }
       
        // Loop all visible drawn blocks.
        for(var intIndex = 0; intIndex< arrVisibleDrawnBlocks.length; intIndex++)
        {
            // Get current block element.
            var objGridBlock = arrVisibleDrawnBlocks[intIndex]; 
            
            // Try getting the block's drawn element.
            var objDrawnElement = objGridBlock.vwg_DrawnElement;
            if(objDrawnElement != null)
            {
                // Initialize the block's drawn element property.
                objGridBlock.vwg_DrawnElement = null;
                
                // Append the drawn element into the grid block.
                $(objGridBlock).append(objDrawnElement);
            }
        }
        
        // Loop all invisible drawn blocks.
        for(var intIndex = 0; intIndex< arrInvisibleDrawnBlocks.length; intIndex++)
        {
            // Get current block element.
            var objGridBlock = arrInvisibleDrawnBlocks[intIndex];
            
            // Check if the block's drawn element is empty.
            if(objGridBlock.vwg_DrawnElement == null)
            {
                // Get the block's fist child.
                var objGridBlockBody = objGridBlock.firstChild;                
                if(objGridBlockBody!=null)
                {
                    // Preserve the block's first child as a drawn element property.
                    objGridBlock.vwg_DrawnElement = objGridBlockBody;
                    
                    // Remove the block's first child.
                    objGridBlock.removeChild(objGridBlockBody);
                }
            }
        }
        
        // Check if a valid raise events call back delegate has been set.
        if(!Aux_IsNullOrEmpty(DataGridView_SyncBlocksData.fncCallbackDelegate) &&
            DataGridView_SyncBlocksData.fncCallbackDelegate != undefined)
        {
            // Invoke delegate.
            Aux_InvokeCallbackDelegate(DataGridView_SyncBlocksData.fncCallbackDelegate);

            // Clean delegate.
            DataGridView_SyncBlocksData.fncCallbackDelegate = null;
        }
    }
}
/// </method>

/// <method name="DataGridView_SyncBlocksContainersScrollers">
/// <summary>
///	
/// </summary>
function DataGridView_SyncBlocksContainersScrollers(objWindow,objVirtualScrollerElement,objBlocksContainer,strGuid,strDir)
{   
    // Validate recieved arguments.
    if(objWindow && objVirtualScrollerElement && objBlocksContainer && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strDir))
    {
        // Synch vertical scroll position.
        objBlocksContainer.scrollTop = objVirtualScrollerElement.scrollTop;
        
        // Get the blocks container client width.
        var intBlocksContainerWidth = objBlocksContainer.vwg_ScrollWidth;
        
        // Check if the blocks container has never been scrolled horizontally before.
        if(Aux_IsNullOrEmpty(intBlocksContainerWidth))
        {
            // Presertve the blocks container original client width.
            intBlocksContainerWidth = objBlocksContainer.vwg_ScrollWidth = objBlocksContainer.clientWidth;
        }
        
        // Get virtual scroller element's horizontal scroll position.
        var intVirtualScrollerHorizontalScrollPosition = objVirtualScrollerElement.scrollLeft;
        
        // If is rtl
        if(strDir=="RTL")
        {
            // WebKit scroll value will be from 0 to X
            if(mcntIsWebKit)
            {
                intVirtualScrollerHorizontalScrollPosition = objVirtualScrollerElement.scrollWidth - objVirtualScrollerElement.scrollLeft - objVirtualScrollerElement.clientWidth;
            }
            else // In IE + FF scroll value will be from -X to 0
            {
                intVirtualScrollerHorizontalScrollPosition = Math.abs(intVirtualScrollerHorizontalScrollPosition);
            }
        }

        // Update the blocks container client width according to the difference between the 
        // the blocks container client width and the virtual scroller element's horizontal scroll position.
        objBlocksContainer.style.width = (intBlocksContainerWidth - intVirtualScrollerHorizontalScrollPosition) + "px";
        
        // Get column header's scroller element.
        var objColumnHeaderScroller = Web_GetElementById("VWGDGVFROZENCOLUMNS_"+strGuid,objWindow);
        if(objColumnHeaderScroller)
        {
            // Checks if source element has a vertical scroller.            
            if(objColumnHeaderScroller.firstChild && objVirtualScrollerElement.firstChild)
            {
                // Check if both horizontal and veritcal scrollers are visible.
                if(Web_HasScrollY(objVirtualScrollerElement) && Web_HasScrollX(objVirtualScrollerElement))
                {
                    // Increase column header's width element by 17 (the width of the scroller).
                    objColumnHeaderScroller.firstChild.style.width = (objVirtualScrollerElement.firstChild.clientWidth+17)+"px";
                }
                else
                {
                    // Set column header's width to source's natural value.
                    objColumnHeaderScroller.firstChild.style.width = objVirtualScrollerElement.firstChild.clientWidth+"px";
                }
            }
            
            // Horizontal synch of the column header's scroller element.
            Web_SyncScroll(objVirtualScrollerElement,objColumnHeaderScroller,1,strDir);
        }
    }     
}
/// </method>

/// <method name="DataGridView_BeforeRestoreScrollHandler">
/// <summary>
///	
/// </summary>
function DataGridView_BeforeRestoreScrollHandler(objWindow,strGuid,objScrollableElement)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid) && objScrollableElement)
    {        
        // Get blocks container.
        var objBlocksContainer = Web_GetElementById("VWGBlocksContainer_"+strGuid, objWindow);
        if(objBlocksContainer)
        {    
            // Inizialize the blocks container
            DataGridView_InitializeBlocksContainer(objBlocksContainer,objScrollableElement);
        }
    }
}
/// </method>

/// <method name="DataGridView_AfterRestoreScrollHandler">
/// <summary>
///	
/// </summary>
function DataGridView_AfterRestoreScrollHandler(objWindow,strGuid,objScrollableElement,blnScrollPositionChanged)
{
    // Check if scroll position has changed.
    if(!blnScrollPositionChanged)
    {               
        // Validate recieved arguments.
        if(objWindow && !Aux_IsNullOrEmpty(strGuid) && objScrollableElement)
        {        
            // Get blocks container.
            var objBlocksContainer = Web_GetElementById("VWGBlocksContainer_"+strGuid, objWindow);
            if(objBlocksContainer)
            {    
                // Synch blocks data.
                DataGridView_SyncBlocksData(objWindow,objScrollableElement,objBlocksContainer,strGuid,"Context.Direction");
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_InitializeBlocksContainer">
/// <summary>
///	
/// </summary>
function DataGridView_InitializeBlocksContainer(objBlocksContainer,objScrollableElement)
{
    // Validate recieved arguments.
    if(objBlocksContainer && objScrollableElement)
    {
        // Get blocks main container element.
        var objBlocksMainContainer = objScrollableElement.previousSibling;
        if(objBlocksMainContainer)
        {
            // Check if the scrollable element has an horizontal scrolling.
            if(objScrollableElement.scrollWidth>objScrollableElement.clientWidth)
            {
                // Set a bottom padding to the main container element.
                objBlocksMainContainer.style.paddingBottom = "16px";
            }
            else
            {
                // Initialize the bottom padding to the main container element.
                objBlocksMainContainer.style.paddingBottom=0;
            }
            
            // Check if the scrollable element has a vertical scrolling.            
            if(objScrollableElement.scrollHeight>objScrollableElement.clientHeight)
            {
                // If is rtl (and not WebKit becaue scroller is (for now..) in left position always)
                if(mblnIsRTL && !mcntIsWebKit)
                {
                    // Set a left padding to the main container element.
                    objBlocksMainContainer.style.paddingLeft= "16px";
                }
                else
                {
                    // Set a right padding to the main container element.
                    objBlocksMainContainer.style.paddingRight = "16px";
                }
            }
            else
            {
                // Initialize the right padding to the main container element.
                objBlocksMainContainer.style.paddingRight=0;
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_OnBlocksContainerMouseWheel">
/// <summary>
///	
/// </summary>
function DataGridView_OnBlocksContainerMouseWheel(objEvent,objScrollableElement)
{
    // Validate recieved arguments.
    if(objEvent && objScrollableElement)
    {
        // Update scrollable element's scroll top position according to the mouse wheel event's parameters.
        objScrollableElement.scrollTop += (objEvent.detail ? objEvent.detail * (15) : (objEvent.wheelDelta / 2) * (-1));
    }
} 
/// </method>

/// <method name="DataGridView_AfterCreateComboBoxEvents">
/// <summary>
///	
/// </summary>
function DataGridView_AfterCreateComboBoxEvents(objWindow,objEvent,strSourceDataId,strEventType,strTargetDataId)
{
    if(strEventType=="ValueChange")
    {
        // Validate recieved arguments.
        if(!Aux_IsNullOrEmpty(strSourceDataId) && objWindow)
        {
            // Get DataGridView node.
            var objGridNode = Data_GetNode(Data_GetDataOwnerId(strSourceDataId));
            
            if(objGridNode)
            {
                // Garantee focus back to grid, for further navigation
                DataGridView_FocusDataGridViewTable(objWindow, objGridNode);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_HandleDelete">
/// <summary>
///	Fires the delete row event
/// </summary>
/// <param name="objGridNode">The altered grid</param>
function DataGridView_HandleDelete(objGridNode)
{
    // Validate recieved arguments.
    if(objGridNode)
    {
        // Check if grid contain any selected rows.
        if(Xml_SelectNodes("WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[@Attr.Selected='1']",objGridNode).length>0)
        {
            // Create a delete event.
        	var objVWGEvent = Events_CreateEvent(Xml_GetAttribute(objGridNode, "Attr.Id"), "Delete", null, true);        	   
            
            // Raise events.
        	Events_RaiseEvents();

        	Events_ProcessClientEvent(objVWGEvent);
        }
    }
}
/// </method>

/// <method name="DataGridView_BeforeCreateCheckBoxEvents">
/// <summary>
///	
/// </summary>
function DataGridView_BeforeCreateCheckBoxEvents(objWindow, objEvent, strSourceDataId, strEventType, strTargetDataId)
{
    if (strEventType == "ValueChange")
    {
        // Validate recieved arguments.
        if (!Aux_IsNullOrEmpty(strSourceDataId) && objWindow && objEvent)
        {
            // Get cell node.
            var objCellNode = Data_GetNode(strSourceDataId);
            if (objCellNode)
            {
                // Check whether handled node is selected.
                var blnIsSelected = (Xml_IsAttribute(objCellNode, "Attr.Selected", "1") || Xml_IsAttribute(objCellNode.parentNode, "Attr.Selected", "1"));

                // Get DataGridView node.
                var objGridNode = Data_GetNode(Data_GetDataOwnerId(strSourceDataId));

                // In case that cell is not selected.
                if (!blnIsSelected)
                {
                    if (objGridNode)
                    {
                        // Get cell element.
                        var objCellElement = Web_GetElementByDataId(strSourceDataId, objWindow);
                        if (objCellElement)
                        {
                            // Update client cell selection.
                            DataGridView_UpdateSelection(objCellElement, objWindow, objEvent);
                        }
                    }
                }
                // Garantee focus back to grid, for further navigation
                DataGridView_FocusDataGridViewTable(objWindow, objGridNode);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_iScrollSyncVirtualScrollers">
/// <summary>
///	
/// </summary>
function DataGridView_iScrollSyncVirtualScrollers(objEvent)
{
}
/// </method>