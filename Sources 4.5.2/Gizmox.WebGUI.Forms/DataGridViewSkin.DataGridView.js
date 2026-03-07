/// <page name="DataGridView.js">
/// <summary>
/// General scripts for web stuff handling.
/// </summary>
var mcntMoveBegin = Number.MIN_VALUE;
var mcntMoveEnd = Number.MAX_VALUE;
var mcntCkeyCode = 67;
var mcntAkeyCode = 65;

// Navigation Key Filter const
var mcntNavigationKeyFilterNone = 0;
var mcntNavigationKeyFilterDown = 1;
var mcntNavigationKeyFilterUp = 2;
var mcntNavigationKeyFilterLeft = 4;
var mcntNavigationKeyFilterRight = 8;
var mcntNavigationKeyFilterPageDown = 16;
var mcntNavigationKeyFilterPageUp = 32;
var mcntNavigationKeyFilterHome = 64;
var mcntNavigationKeyFilterEnd = 128;
var mcntNavigationKeyFilterEnter = 256;
var mcntNavigationKeyFilterTab = 512;

// Scroll-sensetive bounds width const (for DGV scrolling on columns reordering)
var mcntScrollColumnReorderingAreaWidth = 5;

// Scroll shifting  const (for DGV scrolling on columns reordering)
var mcntScrollShift = 20;

/// <method name="DataGridView_ClearFilters">
/// <summary>
///	Handles "all filters clear" action.
/// </summary>
function DataGridView_ClearFilters(strGridId, objWindow, objEvent)
{
    // Create ClearFilters event.
    Events_CreateEvent(strGridId, "ClearFilters", strGridId, true, false);

    Web_OnClick(objEvent, objWindow, true);
}
/// </method>

/// <method name="DataGridView_ColumnDividerMouseDownAsync">
/// <summary>
///	Handles datagrid resizing
/// </summary>
/// <param name="objElement">The resizing element</param>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="strMember">The id of the datagrid member</param>
/// <param name="blnColumn">A flag indicating if member is column or row</param>
/// <param name="objWindow">The owner window of this datagrid</param>
function DataGridView_ColumnDividerMouseDownAsync(objElement, strGrid, strMember, blnColumn, objWindow)
{
    // Initialize click interval value.
    DataGridView_ColumnDividerMouseDown.ClickInterval = null;

    // Get grid element
    var objGrid = objWindow.$$(Web_GetWebId(strGrid));

    // Get target elements (columns or rows)
    var objTargets = objWindow.$$(
		DataGridView_GetMemberID(strGrid, strMember, "1", blnColumn),
		DataGridView_GetMemberID(strGrid, strMember, "2", blnColumn)
	);

    // Store global variables
    DataGridView_ResizeEnd.IsColumn = blnColumn;
    DataGridView_ResizeEnd.DragTargets = objTargets;
    DataGridView_ResizeEnd.GridId = strGrid;
    DataGridView_ResizeEnd.TargetMemberId = strMember;
    DataGridView_ResizeEnd.ActiveWindow = objWindow;

    // Get current rect
    var objRect = Web_GetRect(objElement);

    // Get grid rect
    var objGridRect = Web_GetRect(objGrid);
    if (blnColumn)
    {
        // Fix width
        if (!mblnIsRTL)
        {
            objRect.left = objRect.right - 3;
        }
        else
        {
            objRect.right = objRect.left + 3;
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
        objRect.top = objRect.bottom - 3;
    }

    // Show dragging rect
    Drag_ShowDragElement(objRect, blnColumn ? mcntDragMoveHorz : mcntDragMoveVert, objWindow, DataGridView_ResizeEnd);
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
function DataGridView_ColumnDividerMouseDown(objElement, strGrid, strMember, blnColumn, objWindow, objEvent)
{
    if (!DataGridView_ColumnDividerMouseDown.ClickInterval)
    {
        // If is the actual resizing element and not an internal element
        if (Web_GetEventSource(objEvent) == objElement)
        {
            DataGridView_ColumnDividerMouseDown.ClickInterval = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(DataGridView_ColumnDividerMouseDownAsync, objElement, strGrid, strMember, blnColumn, objWindow), mcntDoubleClickInterval);
        }
    }
}
/// </method>

/// <method name="DataGridView_ColumnDividerDoubleClick">
/// <summary>
///	Handles column divider double click
/// </summary>
function DataGridView_ColumnDividerDoubleClick(objElement, strGridID, strMemberID, objEvent, objWindow)
{
    // Clear the click time out
    Web_ClearTimeout(DataGridView_ColumnDividerMouseDown.ClickInterval, objWindow);

    // Initialize click interval value.
    DataGridView_ColumnDividerMouseDown.ClickInterval = null;

    // If is the actual resizing element and not an internal element
    if (Web_GetEventSource(objEvent) == objElement)
    {
        // Validate recieved arguments.
        if (!Aux_IsNullOrEmpty(strGridID) && !Aux_IsNullOrEmpty(strMemberID))
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

/// <method name="DataGridView_OpenColumnChooser">
/// <summary>
///	
/// </summary>
function DataGridView_OpenColumnChooser(strGridId, objWindow, objEvent)
{
    // Create the event
    Events_CreateEvent(strGridId, "OpenColumnChooser", null, true);

    // Enforce click (will cause raise events).
    Web_OnClick(objEvent, objWindow, true);
}
/// </method>

function DataGridView_DoExpandCollapseClick(strGridId, strMemberId, fncHandleEventsDelegate)
{
    // Build the row's id
    var strRowId = strGridId + "_" + strMemberId;

    // Try getting the row node
    var objRowNode = Data_GetNode(strRowId);

    if (objRowNode)
    {
        // Check if the row is already expanded
        var blnIsExpanded = Xml_IsAttribute(objRowNode, "Attr.IsExpanded", "1");
        var blnIsBoundedHierarchy = Data_IsAttribute(strGridId, "Attr.Bounded", "1");

        // In short, raise if there should be a child grid and it is not already on the client.
        var blnRaiseEvents = (blnIsBoundedHierarchy && !blnIsExpanded && !Xml_HasNods("WC:Tags.DataGridView", objRowNode));

        var objEvent;

        if (blnIsExpanded)
        {
            // Create collapse event
            objEvent = Events_CreateEvent(strRowId, "Collapse", null, true);

            if (!blnRaiseEvents)
            {
                blnRaiseEvents = Data_IsCriticalEvent(strGridId, "Event.Collapse");
                // Change state to collapsed
                Xml_SetAttribute(objRowNode, "Attr.IsExpanded", "0");
            }
        }
        else
        {
            // Create expand event
            objEvent = Events_CreateEvent(strRowId, "Expand", null, true);

            if (!blnRaiseEvents)
            {
                blnRaiseEvents = Data_IsCriticalEvent(strGridId, "Event.Expand");
                Xml_SetAttribute(objRowNode, "Attr.IsExpanded", "1");
            }
        }

        if (fncHandleEventsDelegate != null && typeof (fncHandleEventsDelegate) === "function")
        {
            fncHandleEventsDelegate(blnRaiseEvents, strRowId, blnIsExpanded);
        }

        Events_ProcessClientEvent(objEvent);
    }
}

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
            Events_RaiseEvents();
        }
        else
        {
            DataGridView_RedrawContainingGrid(objWindow, strGridId);
        }
    });
}
/// </method>

/// <method name="DataGridView_RedrawContainingGrid">
/// <summary>
///	
/// </summary>
function DataGridView_RedrawContainingGrid(objWindow, strGridId)
{
    var objGridNode = Data_GetNode(strGridId);
    if (objGridNode)
    {
        // Redraw the owning Grid
        Controls_RedrawControlByNode(objWindow, objGridNode);
    }
}
/// </method>

/// <method name="DataGridView_GetClientRect">
/// <summary>
///	Gets the DataGridView client rectangle, which considers control borders and 
/// fixes the position of rectangle, which can be gotten via Web_GetRect().
/// </summary>
function DataGridView_GetClientRect(objDataGridViewElement)
{
    var objVwgGridRect = Web_GetRect(objDataGridViewElement, true);

    objVwgGridRect.left += objDataGridViewElement.clientLeft;
    objVwgGridRect.right += objDataGridViewElement.clientLeft;

    return objVwgGridRect;
}
/// </method>

/// <method name="DataGridView_DropAllowed">
/// <summary>
/// Mixing frozen and unfrozen column 'groups' is not allowed when ordering columns. 
///	Returns false if requested drop would mix 'groups', else return true which means requested ordering is allowed.
///
/// Column cells have the drop indicator to the right of the cell in both LTR and RTL
/// In LTR handle is on left of dragged subject, which means insert (drop) is after target column
/// In RTL handle is on right og dragged subject, which means insert (drop) is also after target column
/// This means that LTR and RTL logic for allow drop check is the same.
/// </summary>
function DataGridView_DropAllowed(objVwgDragSubject, objVwgDraggedOverElement) {
    // Check Frozen attributes on subject columns, handle is to right of target column.
    var varIsFrozenSubject = Xml_GetAttribute(DataGridView_GetNodeFromElement(objVwgDragSubject), "Attr.Frozen", "0");
    var varIsFrozenTarget = Xml_GetAttribute(DataGridView_GetNodeFromElement(objVwgDraggedOverElement), "Attr.Frozen", "0");
    // Assume we allow the move/drop
    var blnAllowTargetDrop = true;

    // in LTR, frozen on left, unfrozon on right
    // In RTL, frozen on right, unfrozen on left.

    // Are we dragging a frozen or unfrozen column 
    if (varIsFrozenSubject == "1") {
        // Frozen column being dropped after an unfrozon one is mixing groups
        if (varIsFrozenSubject != varIsFrozenTarget)
            blnAllowTargetDrop = false;
    }
    else {
        // Find next visible column after target
        var objNextAfterTarget = objVwgDraggedOverElement.nextSibling;
        while (objNextAfterTarget && Xml_GetAttribute(DataGridView_GetNodeFromElement(objNextAfterTarget), "Attr.Visible", "1") == "0") {
            objNextAfterTarget = objNextAfterTarget.nextSibling;
        }
        // Unfrozen column being dragged amongst frozen
        if (objNextAfterTarget && Xml_GetAttribute(DataGridView_GetNodeFromElement(objVwgDraggedOverElement), "Attr.Frozen", "0") == "1")
            blnAllowTargetDrop = false;
    }
    return blnAllowTargetDrop;
}
/// </method>

/// <method name="DataGridView_DragColumnMove">
/// <summary>
///	Handles column header dragging.
/// </summary>
function DataGridView_DragColumnMove()
{
    // Restore global variables.
    var strGridGuid = DataGridView_OnColumnHeaderMouseDown.GridGuid;
    var strMemberId = DataGridView_OnColumnHeaderMouseDown.MemberId;
    var objWindow = DataGridView_OnColumnHeaderMouseDown.ActiveWindow;

    // Validate drag window, drag subject, and drag subject's rectangle.
    if (objWindow && mobjDragRect &&
		!Aux_IsNullOrEmpty(strGridGuid) && !Aux_IsNullOrEmpty(strMemberId))
    {
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_" + strGridGuid + "_" + strMemberId, objWindow);

        // Get the grid element.
        var objDataGridViewElement = Web_GetElementByDataId(strGridGuid, objWindow);

        // Validate the subject VWG element.
        if (objVwgDragSubject && objDataGridViewElement)
        {
            // Define x an y position.
            var intX = mblnIsRTL ? mobjDragRect.right + 1 : mobjDragRect.left - 1;
            var intY = mobjDragRect.top;

            // Get element according to x and y position.
            var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);

            // Check that the source element is not the VWG_DraggedOverFloatingElement.
            if (objDraggedOverElement)
            {
                // Removes the DropTargetElement - if exists.
                Drag_RemoveDropTargetElement();

                // Get grid node
                var objGridElementNode = Data_GetNode(strGridGuid);
                if (objGridElementNode)
                {
                    if (Xml_IsAttribute(objGridElementNode, "Attr.AllowUserToOrderColumns", "1"))
                    {
                        var objScrollableContainer;

                        // Get the DGV scrollable container
                        if (Xml_IsAttribute(objGridElementNode, "Attr.Virtual", "1")) // If it is VirtualDataGridView
                        {
                            objScrollableContainer = Web_GetElementById("VWGVLSC_" + strGridGuid, objWindow);
                        }
                        else
                        {
                            objScrollableContainer = Web_GetElementById("VWGDGVBODY_" + strGridGuid, objWindow);
                        }

                        

                            //Get the scrollable container rectangle to got the left and right coord
                            var objVwgScrollableContainerRect = Web_GetRect(objScrollableContainer);

                            var intScrollableContainerRight = objVwgScrollableContainerRect.right + 1;
                            var intDragRectRight = mobjDragRect.right;

                            // Check if scroll should be right shifted
                            if ((intScrollableContainerRight - intDragRectRight) <= mcntScrollColumnReorderingAreaWidth)
                            {
                                // If is IE
                                if (mblnIsRTL && mcntIsIE)
                                {
                                    objScrollableContainer.scrollLeft -= mcntScrollShift;
                                }
                                else
                                {
                                    objScrollableContainer.scrollLeft += mcntScrollShift;
                                }
                            }

                            var intScrollableContainerLeft = objVwgScrollableContainerRect.left;
                            var intDragRectLeft = mobjDragRect.left + 1;

                            // Check if scroll should be left shifted
                            if ((intDragRectLeft - intScrollableContainerLeft) <= mcntScrollColumnReorderingAreaWidth)
                            {
                                // If is IE
                                if (mblnIsRTL && mcntIsIE)
                                {
                                    objScrollableContainer.scrollLeft += mcntScrollShift;
                                }
                                else
                                {
                                    objScrollableContainer.scrollLeft -= mcntScrollShift;

                                }
                            }

                            var objVwgGridRect = DataGridView_GetClientRect(objDataGridViewElement);

                            // Check if we need to show indicator at first position and set the draggedOverElement
                            if (mblnIsRTL)
                            {
                                var blnIsMaxScrolled = mcntIsWebKit ? (objScrollableContainer.scrollWidth - objScrollableContainer.clientWidth == objScrollableContainer.scrollLeft) : (objScrollableContainer.scrollLeft == 0);

                                if (blnIsMaxScrolled && (objVwgGridRect.right - mobjDragRect.right <= 0))
                                {
                                    var objDraggableHeaderCell = Web_GetElementById("VWG_" + "DGFDHC_" + strGridGuid, objWindow);
                                    if (objDraggableHeaderCell)
                                    {
                                        objDraggedOverElement = objDraggableHeaderCell;
                                    }
                                }
                            }
                            else
                            {
                                if ((objVwgGridRect.left - mobjDragRect.left >= 0) && (0 == objScrollableContainer.scrollLeft))
                                {
                                    var objDraggableHeaderCell = Web_GetElementById("VWG_" + "DGFDHC_" + strGridGuid, objWindow);
                                    if (objDraggableHeaderCell)
                                    {
                                        objDraggedOverElement = objDraggableHeaderCell;
                                    }
                                }
                            }
                     


                        if (Web_GetId(objDraggedOverElement) != "VWG_DraggedOverFloatingElement")
                        {

                            // Get the VWG dragged over element.
                            var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement, true);

                            // Validate the VWG dragged over element.
                            if (objVwgDraggedOverElement &&
						        Web_IsAttribute(objVwgDraggedOverElement, "vwgdragable", "1", true) &&
						        Web_GetId(objVwgDraggedOverElement) != "VWG_DragHtmlIndicatorBox")
                            {
                                // Get the dragged over element rectangle.
                                var objVwgDraggedOverElementRect = Web_GetRect(objVwgDraggedOverElement);

                                // Validate the dragged over element rectangle.
                                if (objVwgDraggedOverElementRect)
                                {
                                    // Create a new DIV element.
                                    var objDraggedOverFloatingElement = mobjDragWindow.document.createElement("DIV");

                                    var objDraggedOverContainerElement = Drag_GetDraggedOverContainer();
                                    if (objDraggedOverContainerElement && DataGridView_DropAllowed(objVwgDragSubject, objVwgDraggedOverElement))
                                    {
                                        // Add floating element to its container.
                                        $(objDraggedOverContainerElement).append(objDraggedOverFloatingElement);

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
                                        objDraggedOverFloatingElement.style.left = mblnIsRTL ? objVwgDraggedOverElementRect.left + "px" : (objVwgDraggedOverElementRect.right - 3) + "px";

                                    }
                                }
                            }
                        }
                    }
                    else if (Xml_IsAttribute(objGridElementNode, "Attr.ShowGroupingDropArea", "1"))
                    {
                        // Get dragged over element id.
                        var strDraggedOverElementID = objDraggedOverElement.id;

                        // Validate dragged over element.
                        if (strDraggedOverElementID.indexOf("VWGNODECONTAINER_") == 0)
                        {
                            // Get the dragged over element rectangle.
                            var objDraggedOverElementRect = Web_GetRect(objDraggedOverElement);
                            if (objDraggedOverElementRect)
                            {
                                // Create a new DIV element.
                                var objDraggedOverFloatingElement = mobjDragWindow.document.createElement("DIV");

                                var objDraggedOverContainerElement = Drag_GetDraggedOverContainer();
                                if (objDraggedOverContainerElement)
                                {
                                    // Add floating element to its container.
                                    $(objDraggedOverContainerElement).append(objDraggedOverFloatingElement);

                                    // Update the dragged over floating element id.
                                    objDraggedOverFloatingElement.id = "VWG_DraggedOverFloatingElement";

                                    // Set the dragged over floating element position to absolute.
                                    objDraggedOverFloatingElement.style.position = "absolute";

                                    // Get control's theme.
                                    var strClassName = Controls_GetTheme(strGridGuid);

                                    // Add a class spacer if needed.
                                    if(!Aux_IsNullOrEmpty(strClassName))
                                    {
                                        strClassName += " ";
                                    }
                                    else
                                    {
                                        strClassName = "";
                                    }

                                    // Set class name.
                                    objDraggedOverFloatingElement.className = strClassName + "DataGridView-DropIndicator";

                                    var strLeft = objDraggedOverElementRect.left;
                                    var strTop = objDraggedOverElementRect.top;

                                    var strDraggedOverElementDataID = strDraggedOverElementID.substring(17);
                                    if (!Aux_IsNullOrEmpty(strDraggedOverElementDataID))
                                    {
                                        var objNodeBodyElement = Web_GetElementById("VWGNODEBODY_" + strDraggedOverElementDataID, objWindow);
                                        if (objNodeBodyElement)
                                        {
                                            var objNodeBodyElementRect = Web_GetRect(objNodeBodyElement);
                                            if (objNodeBodyElementRect)
                                            {
                                                strLeft = String(mblnIsRTL ? objNodeBodyElementRect.left : objNodeBodyElementRect.right);
                                                strTop = String(objNodeBodyElementRect.top);
                                            }
                                        }
                                    }

                                    // Set element's top.
                                    objDraggedOverFloatingElement.style.top = strTop + "px";

                                    objDraggedOverFloatingElement.style.left = strLeft + "px";
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

/// <method name="DataGridView_OnColumnHeaderMouseDown">
/// <summary>
///	Handles datagrid column header mouse down.
/// </summary>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="strMemberId">The id of the datagrid member</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent">The event object</param>
function DataGridView_OnColumnHeaderMouseDown(strGridGuid, strMemberId, objWindow, objEvent)
{
    // Validate received parameters.
    if (objWindow &&
		strGridGuid && strGridGuid != "" &&
		strMemberId && strMemberId != "")
    {
        // Store global variables
        DataGridView_OnColumnHeaderMouseDown.GridGuid = strGridGuid;
        DataGridView_OnColumnHeaderMouseDown.MemberId = strMemberId;
        DataGridView_OnColumnHeaderMouseDown.ActiveWindow = objWindow;

        var strDraggedElementId = strGridGuid + "_" + strMemberId;

        // Get column header element.
        var objDraggedElement = Web_GetElementById("VWG_" + strDraggedElementId, objWindow);
        if (objDraggedElement)
        {
            // Get grid node
            var objGridElementNode = Data_GetNode(strGridGuid);
            if (objGridElementNode)
            {
                // Check if user is allowed ordering columns.
                if (Xml_IsAttribute(objGridElementNode, "Attr.AllowUserToOrderColumns", "1"))
                {
                    // Get grid element
                    var objGridElement = objWindow.$$(Web_GetWebId(strGridGuid));

                    if (objGridElement)
                    {
                        // Get updated limiting grid rect.
                        var objGridElementRect = DataGridView_GetUpdatedLimitRect(objDraggedElement, objGridElement);

                        // Show dragging rect
                        Drag_RegisterDragElement(objDraggedElement, mcntDragMoveHorz, objWindow, objEvent, DataGridView_DragColumnEnd, null, objGridElementRect, false, DataGridView_DragColumnMove, 30);
                    }
                }
                else if (Xml_IsAttribute(objGridElementNode, "Attr.ShowGroupingDropArea", "1"))
                {
                    // Get dragged element node
                    var objDraggedElementNode = Data_GetNode(strDraggedElementId);

                    if (objDraggedElementNode)
                    {
                        // Check if element is groupable
                        if (!Xml_IsAttribute(objDraggedElementNode, "Attr.CanGroupBy", "0"))
                        {
                            // Get grid tree view element
                            var objGridTreeViewElement = Web_GetElementById("VWGDGVTV_" + strGridGuid, objWindow);
                            if (objGridTreeViewElement)
                            {
                                // Get treeview rect.
                                var objGridTreeViewElementRect = DataGridView_GetUpdatedLimitRect(objDraggedElement, objGridTreeViewElement);

                                // Show dragging rect.
                                Drag_RegisterDragElement(objDraggedElement, mcntDragMoveFree, objWindow, objEvent, DataGridView_DragColumnEnd, null, objGridTreeViewElementRect, false, DataGridView_DragColumnMove, 30);
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_GetUpdatedLimitRect">
/// <summary>
///	Gets the updated limiting rectangle.
/// </summary>
function DataGridView_GetUpdatedLimitRect(objDraggedElement, objHostingElement)
{
    // Get dragged element rect
    var objDraggedElementRect = Web_GetRect(objDraggedElement);

    // Get hosting rect
    var objHostingElementRect = DataGridView_GetClientRect(objHostingElement);

    // Update the limitating rectangle width.
    objHostingElementRect.left -= (objDraggedElementRect.right - objDraggedElementRect.left);

    return objHostingElementRect;
}
/// </method>

/// <method name="DataGridView_DragColumnEnd">
/// <summary>
///	Handles dragged column header end drag.
/// </summary>
function DataGridView_DragColumnEnd(objRect, objRectOld)
{
    // Restore global variables.
    var strGridGuid = DataGridView_OnColumnHeaderMouseDown.GridGuid;
    var strMemberId = DataGridView_OnColumnHeaderMouseDown.MemberId;
    var objWindow = DataGridView_OnColumnHeaderMouseDown.ActiveWindow;

    // Removes the DropTargetElement - if exists.
    Drag_RemoveDropTargetElement();

    // Validate drag window, drag subject, and drag subject's rectangle.
    if (objWindow && mobjDragRect &&
		!Aux_IsNullOrEmpty(strGridGuid) && !Aux_IsNullOrEmpty(strMemberId))
    {
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_" + strGridGuid + "_" + strMemberId, objWindow);

        // Validate the subject VWG element.
        if (objVwgDragSubject)
        {
            // Get the grid element.
            var objDataGridViewElement = Web_GetElementByDataId(strGridGuid, objWindow);

            // Get the client DGV rectangle
            var objVwgGridRect = DataGridView_GetClientRect(objDataGridViewElement);

            // Define x an y position.         
            var intX = mblnIsRTL ? mobjDragRect.right : mobjDragRect.left;
            var intY = mobjDragRect.top;

            // Get element according to x and y position.
            var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);


            // Fix dragging over right border in RTL to paste the column to the first position and in LTR when the recatange exceeds the DGV outlines
            if ((mblnIsRTL && (intX >= objVwgGridRect.right)) ||
                (!mblnIsRTL && (intX <= objVwgGridRect.left)))
            {
                objDraggedOverElement = Web_GetElementById("VWG_" + "DGFDHC_" + strGridGuid, objWindow);
            }

            // Check that the source element is valid.
            if (objDraggedOverElement)
            {
                // Get grid node
                var objGridElementNode = Data_GetNode(strGridGuid);
                if (objGridElementNode)
                {
                    // Get the VWG dragged over element.
                    var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement, true);

                    // If columns reordered.
                    if (Xml_IsAttribute(objGridElementNode, "Attr.AllowUserToOrderColumns", "1") && objVwgDraggedOverElement &&
					    Web_IsAttribute(objVwgDraggedOverElement, "vwgdragable", "1", true) &&
					    Web_GetId(objVwgDraggedOverElement) != "VWG_DragHtmlIndicatorBox" &&
                        DataGridView_DropAllowed(objVwgDragSubject, objVwgDraggedOverElement))
                    {
                        // Define a dragged column id.
                        var strDraggedColumnId = strMemberId;

                        // Validate dragged column id.
                        if (strDraggedColumnId.indexOf("C") != 1)
                        {
                            // Fix dragged column id.
                            strDraggedColumnId = strDraggedColumnId.substring(strDraggedColumnId.indexOf("C") + 1);
                        }

                        // Get target column id.
                        var strTargetColumnId = Web_GetId(objVwgDraggedOverElement);
                        var blnBefore = false;

                        // Validate target column id.
                        if (strTargetColumnId.indexOf("_C") != -1)
                        {
                            // Fix target column id.
                            strTargetColumnId = strTargetColumnId.substring(strTargetColumnId.indexOf("_C") + 2);
                        }
                        // Check if column should be pasted to the first position
                        else if ((strTargetColumnId.indexOf("DGFDHC") != -1) || (strTargetColumnId.indexOf("GHC0") != -1))
                        {
                            blnBefore = true;

                            // Get column data node
                            var objColumnDataNode = Xml_SelectSingleNode("WG:Tags.DataGridViewColumn[not(@Attr.Visible='0')]", objGridElementNode);
                            if (objColumnDataNode)
                            {
                                // Fix target column id.
                                strTargetColumnId = Xml_GetAttribute(objColumnDataNode, "Attr.MemberID", "").substring(1);
                            }
                        }

                        // Validate both column id's and check that they are not equal.
                        if (strDraggedColumnId && strDraggedColumnId != "" &&
						strTargetColumnId && strTargetColumnId != "" &&
						strDraggedColumnId != strTargetColumnId)
                        {
                            // Raise proper event.
                            DataGridView_CreateColumnDragEvent(strGridGuid, "ColumnsReorder", strDraggedColumnId, strTargetColumnId, blnBefore);
                        }
                    }

                    // If columns grouped.
                    else if (Xml_IsAttribute(objGridElementNode, "Attr.ShowGroupingDropArea", "1") && objVwgDraggedOverElement &&
					    Web_GetId(objVwgDraggedOverElement) != "VWG_DragHtmlIndicatorBox")
                    {
                        // Get dragged column data property name.
                        var strDraggedColumnDataPropertyName = Web_GetAttribute(objVwgDragSubject, "vwggroupingcolumnname", "");

                        // Insert a new group to the 1st position.
                        if (objDraggedOverElement.id === "VWGNODECONTAINER_" + strGridGuid)
                        {

                            if (!Aux_IsNullOrEmpty(strDraggedColumnDataPropertyName))
                            {
                                // Raise proper event.
                                DataGridView_CreateColumnDragEvent(strGridGuid, "InsertGroup", strDraggedColumnDataPropertyName, "");
                            }
                        }

                        // Append header to existing group header.					
                        else
                        {
                            // Get target column data property name.
                            var strTargetColumnDataPropertyName = Web_GetAttribute(objDraggedOverElement, "vwggroupingcolumnname", "");

                            // If these are different column headers
                            if (!Aux_IsNullOrEmpty(strDraggedColumnDataPropertyName) && !Aux_IsNullOrEmpty(strTargetColumnDataPropertyName) && strDraggedColumnDataPropertyName !== strTargetColumnDataPropertyName)
                            {
                                // Raise proper event.
                                DataGridView_CreateColumnDragEvent(strGridGuid, "InsertGroup", strDraggedColumnDataPropertyName, strTargetColumnDataPropertyName);
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_CreateColumnDragEvent">
/// <summary>
///	Creates column drag related event.
/// </summary>
function DataGridView_CreateColumnDragEvent(strGridGuid, strEventType, strDraggedColumnAttribute, strTargetColumnAttribute, blnBefore)
{
    // Create the column event
    var objEvent = Events_CreateEvent(strGridGuid, strEventType, null, true);

    // Set column data property names as attributes.
    if (!Aux_IsNullOrEmpty(strDraggedColumnAttribute))
    {
        Events_SetEventAttribute(objEvent, "Attr.DraggedColumn", strDraggedColumnAttribute);
    }

    if (!Aux_IsNullOrEmpty(strTargetColumnAttribute))
    {
        Events_SetEventAttribute(objEvent, "Attr.TargetColumn", strTargetColumnAttribute);
    }

    // If column should be pasted to the first position set the Before attribute
    if (blnBefore)
    {
        Events_SetEventAttribute(objEvent, "Attr.Before", "1");
    }

    // Raise events.
    Events_RaiseEvents();
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
function DataGridView_GetMemberID(strGrid, strMember, strInstance, blnColumn)
{
    return (blnColumn ? "VWGCOL" : "VWGROW") + strInstance + "_" + strGrid + "_" + strMember;
}
/// </method>

/// <method name="DataGridView_ResizeEnd">
/// <summary>
///	Handles the actual resizing
/// </summary>
/// <param name="objRect">The new rectangle</param>
/// <param name="objRectOld">The original rectangle</param>
function DataGridView_ResizeEnd(objRect, objRectOld)
{
    // Restore global variables
    var blnColumn = DataGridView_ResizeEnd.IsColumn;
    var objTargets = DataGridView_ResizeEnd.DragTargets;
    var strGridId = DataGridView_ResizeEnd.GridId;
    var strMemberId = DataGridView_ResizeEnd.TargetMemberId;
    var objWindow = DataGridView_ResizeEnd.ActiveWindow;

    // Get diff
    var intDiff = blnColumn ? Math.round(objRect.left - objRectOld.left) : Math.round(objRect.top - objRectOld.top);
    var strGuid = strGridId + "_" + strMemberId;
    var strAttr = blnColumn ? "Attr.Width" : "Attr.Height";

    // Get updated value
    var intValue = parseInt(Data_GetAttribute(strGuid, strAttr, "0"));

    // In case of width changinf - check text direction in order to decide
    // on value increment or decrement.
    if (strAttr.toUpperCase() == "W" && mblnIsRTL)
    {
        intValue -= intDiff;
    }
    else
    {
        intValue += intDiff;
    }

    // Check that is greater then 5px
    if (intValue > 5)
    {
        // Get the GridView object
        // Check all rows should resize
        var objDataGridView = Data_GetNode(strGridId);
        if (blnColumn || !Xml_IsAttribute(objDataGridView, "Attr.EnforceEqualRowSize", "1"))
        {
            // Update the off screen data
            Data_SetAttribute(strGuid, strAttr, intValue, true);
        }
        else
        {
            // Get all rows
            var arrDataGridViewRows = Xml_SelectNodes("WG:Tags.DataGridViewRow", objDataGridView);

            // Update all rows' height
            for (var i = 0; i < arrDataGridViewRows.length; ++i)
            {
                Xml_SetAttribute(arrDataGridViewRows[i], strAttr, intValue);
            }
        }

        // Redraw the grid 
        Controls_RedrawControlById(objWindow, strGridId);

        // Create the resizing event
        var objEvent = Events_CreateEvent(strGuid, "Resize", null, true);
        Events_SetEventAttribute(objEvent, "Attr.Value", intValue);

        // Check if resize event is critical and raise event.
        if (Data_IsCriticalEvent(strGuid, "Event.SizeChange"))
        {
            Events_RaiseEvents();
        }

        // Process client event.
        Events_ProcessClientEvent(objEvent);
    }
}
/// </method>

/// <method name="DataGridView_IsValidNavigationKey">
/// <summary>
///	
/// </summary>
function DataGridView_IsValidNavigationKey(objGridNode, objWindow, objEvent)
{
    // Get key code.
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // Check if control key is held.
    var blnControlKey = Web_IsControl(objEvent);

    // Check if alt key is held.
    var blnAltKey = Web_IsAlt(objEvent);

    // Check if key code is a navigation key.
    var blnIsNavigationKey = Web_IsNavigationKey(intKeyCode) || [mcntEnterKey, mcntTabKey, mcntEscapeKey].contains(intKeyCode);
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

/// <method name="DataGridView_ShouldFilterNavigationKey">
/// <summary>
/// Returns true if key should be filtered.
/// </summary>
/// <param name="intKeyCode">The ASCII keycode.</param>
function DataGridView_ShouldFilterNavigationKey(objNode, intKeyCode)
{
    if (objNode)
    {
        // Get the key filter attribute.
        var intKeyFilter = parseInt(Xml_GetAttribute(objNode, "Attr.NavigationKeyFilter", "0"));

        // Check if had no key filter defined.
        if (intKeyFilter == 0)
        {
            return false;
        }
        else
        {
            // Get appropriate binary number for bitmask test based on ASCII keycode.
            switch (intKeyCode)
            {
                // Down      
                case 40:
                    intKeyFilterCode = mcntNavigationKeyFilterDown;
                    break;
                // Up       
                case 38:
                    intKeyFilterCode = mcntNavigationKeyFilterUp;
                    break;
                // Left       
                case 37:
                    intKeyFilterCode = mcntNavigationKeyFilterLeft;
                    break;
                // Right       
                case 39:
                    intKeyFilterCode = mcntNavigationKeyFilterRight;
                    break;
                // PageDown      
                case 34:
                    intKeyFilterCode = mcntNavigationKeyFilterPageDown;
                    break;
                // PageUp      
                case 33:
                    intKeyFilterCode = mcntNavigationKeyFilterPageUp;
                    break;
                // Home      
                case 36:
                    intKeyFilterCode = mcntNavigationKeyFilterHome;
                    break;
                // End      
                case 35:
                    intKeyFilterCode = mcntNavigationKeyFilterEnd;
                    break;
                // Enter      
                case 13:
                    intKeyFilterCode = mcntNavigationKeyFilterEnter;
                    break;
                // Tab      
                case 9:
                    intKeyFilterCode = mcntNavigationKeyFilterTab;
                    break;
                // Default      
                default:
                    return false;
            }

            // Perform a bit mask comparison.
            return (intKeyFilter & intKeyFilterCode) > 0;
        }
    }
}
/// </method>

/// <method name="DataGridView_HandleNavigation">
/// <summary>
///	
/// </summary>
function DataGridView_HandleNavigation(objWindow, objGridNode, objCurrentCellNode, objEvent)
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

        var objCellNode = null;
        var intDirHoriShiftModifier = (mblnIsRTL) ? -1 : 1;
        switch (intKeyCode)
        {
            case mcntEscapeKey:
                // Set last selected one.
                objCellNode = objCurrentCellNode;
                break;
            case mcntLeftKey:
                if (!blnControlKey)
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, (-1 * intDirHoriShiftModifier), 0);
                }
                else
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, (mblnIsRTL ? mcntMoveEnd : mcntMoveBegin), 0);
                }
                break;
            case mcntUpKey:
                if (!blnControlKey)
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, -1);
                }
                else
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, mcntMoveBegin);
                }
                break;

            case mcntRightKey:
                if (!blnControlKey)
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, (1 * intDirHoriShiftModifier), 0);
                }
                else
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, (mblnIsRTL ? mcntMoveBegin : mcntMoveEnd), 0);
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
                                // Check if current selection is on first cell in row
                                if (objCurrentCellNode.previousSibling != null && !Xml_IsAttribute(objCurrentCellNode.previousSibling, "Attr.Type", "7"))
                                {
                                    // Navigate to previous cell
                                    intY = 0;
                                    intX = -1;
                                }
                                else if (DataGridView_GetPreviousRowFromCellNode(objCurrentCellNode, false))
                                {
                                    // Navigate to previous row and it's last cell
                                    intY = -1;
                                    intX = mcntMoveEnd;
                                }
                            }
                            else
                            {
                                // Check if current selection is on last cell in the row and that the next sibling is not a data grid view (for hierarchic grid)
                                if (objCurrentCellNode.nextSibling != null && objCurrentCellNode.nextSibling.nodeName != "WC:Tags.DataGridView")
                                {
                                    // Navigate to next cell
                                    intY = 0;
                                    intX = 1;
                                }
                                else if (objCurrentCellNode.parentNode != null && objCurrentCellNode.parentNode.nextSibling != null)
                                {
                                    // Navigate to next row and it's first cell
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
                                objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, intX, intY);

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
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, 1);
                }
                else
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, mcntMoveEnd);
                }
                break;
            case mcntEnterKey:
                objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, 1);
                break;
            case mcntEndKey:
                if (!blnControlKey)
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, mcntMoveEnd, 0);
                }
                else
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, mcntMoveEnd, mcntMoveEnd);
                }
                break;
            case mcntHomeKey:
                if (!blnControlKey)
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, mcntMoveBegin, 0);
                }
                else
                {
                    objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, mcntMoveBegin, mcntMoveBegin);
                }
                break;
            case mcntPageUpKey:
                objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, -10);
                break;
            case mcntPageDownKey:
                objCellNode = DataGridView_Navigate(objWindow, objGridNode, objCurrentCellNode, 0, 10);
                break;
        }

        if (objCellNode && objCellNode != objCurrentCellNode)
        {
            if (!Xml_IsAttribute(objCurrentCellNode, "Attr.Active", "1") ||
				DataGridView_ShouldActiveCellFireSelectionChangeAfterNavigation(objWindow, objGridNode, objCurrentCellNode, intKeyCode))
            {
                // Fire selection change.
                DataGridView_FireSelectionChange(objGridNode, false, objEvent);
            }
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
                // In case that current cell has not changed (escape key).
                if (objCellNode == objCurrentCellNode)
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
        if (objFocusElement && (!Xml_IsAttribute(objGridNode, "Attr.EditMode", "0") || objCellNode))
        {
            // Blur focus element.
            Web_Blur(objFocusElement);
        }

        // Redraw header.
        DataGridView_UpdateRowHeaders(objWindow, objGridNode, objCellNode, objCurrentCellNode);
    }
}
/// </method>

/// <method name="DataGridView_GetPreviousRowFromCellNode">
/// <summary>
///	
/// </summary>
function DataGridView_GetPreviousRowFromCellNode(objCurrentCellNode, blnIsVirtual)
{
    var objPreviousRowNode = Xml_SelectSingleNode("../preceding-sibling::WG:Tags.DataGridViewRow", objCurrentCellNode);

    if (blnIsVirtual && !objPreviousRowNode)
    {
        objPreviousRowNode = Xml_SelectSingleNode("../../preceding-sibling::WG:Tags.DataGridViewBlock/WG:Tags.DataGridViewRow[last()]", objCurrentCellNode);
    }

    return objPreviousRowNode;
}
/// </method>

/// <method name="DataGridView_ShouldActiveCellFireSelectionChangeAfterNavigation">
/// <summary>
///	
/// </summary>
function DataGridView_ShouldActiveCellFireSelectionChangeAfterNavigation(objWindow, objGridNode, objCurrentCellNode, intKeyCode)
{
    var blnShouldFireSelectionChangeAfterNavigation = true;

    if (objGridNode)
    {
        if (objCurrentCellNode)
        {
            switch (Xml_GetAttribute(objCurrentCellNode, "Attr.Type"))
            {
                case "1":   // Textbox cell

                    var blnValueChanged = false;

                    var objCellElement = DataGridView_GetCellElement(objWindow, objGridNode, objCurrentCellNode);
                    if (objCellElement)
                    {
                        var objInputElement = Web_GetContextElementById(objCellElement, "TRG_" + DataGridView_GetFullMemberID(objGridNode, objCurrentCellNode));
                        if (objInputElement)
                        {
                            var strValue = objInputElement.value;
                            if ((Xml_HasAttribute(objCurrentCellNode, "Attr.Value") || !Aux_IsNullOrEmpty(strValue)) &&
									!Xml_IsAttribute(objCurrentCellNode, "Attr.Value", strValue))
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

/// <method name="IsSourceFromAChildGrid">
/// <summary>
///	Checks
/// </summary>
function DataGridView_IsEventSourceFromAChildGrid(strGuid, objEvent)
{
    var objSourceElement = Web_GetEventSourceElement(objEvent);
    if (objSourceElement)
    {
        var objElement = Web_GetVwgElement(objSourceElement);
        if (objElement)
        {
            return strGuid != Data_GetDataId(Web_GetId(objElement));
        }
    }

    return false;
}
/// </method>

/// <method name="DataGridView_KeyDown">
/// <summary>
///	Handle data grid key down actions
/// </summary>
/// <param name="strGuid">The id of the data grid</param>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objEvent">The event object</param>
function DataGridView_KeyDown(strGuid, objWindow, objEvent)
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
    var strCSV = "";
    var intRowID = "";
    var intPrevRowID = "";
    var strCellValue = "";
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);

    // Define selected rows array.
    var arrSelectedRowsNodes = null;

    // In case of FullRowSelect selection mode.    
    if (intSelectionMode == 2)
    {
        // Get all selected rows.
        arrSelectedRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow[@Attr.Selected='1']", objGridNode);
    }
    // In case of CellSelect selection mode.       
    else if (intSelectionMode == 1)
    {
        // Get all rows which has selected cells.
        arrSelectedRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow[./WG:Tags.DataGridViewCell/@Attr.Selected='1']", objGridNode);
    }
    // In case of RowHeaderSelect selection mode.       
    else if (intSelectionMode == 8)
    {
        // Get all rows which has selected cells.
        arrSelectedRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow[./WG:Tags.DataGridViewCell/@Attr.Selected='1' or @Attr.Selected='1']", objGridNode);
    }

    if (arrSelectedRowsNodes)
    {
        // Loop all child items(rows)
        for (var intIndex = 0; intIndex < arrSelectedRowsNodes.length; intIndex++)
        {
            // Get current row node
            var objSelectedRowNode = arrSelectedRowsNodes[intIndex];

            if (objSelectedRowNode)
            {
                //In not in a FullRowSelect selection mode.
                if (intSelectionMode != 2)
                {
                    var strMemberId = Xml_GetAttribute(objSelectedRowNode, "mId", "");

                    //Look for the row id(index)
                    if (strMemberId != "")
                    {
                        //get the new row id(index) and insert empty rows between selected cells if exist
                        intRowID = parseInt(strMemberId.replace("R", ""));

                        //In the first time
                        if (intPrevRowID == "")
                        {
                            intPrevRowID = intRowID;
                        }
                        else
                        {
                            while (intPrevRowID < intRowID - 1)
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
                var objSelectedRowCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell", objSelectedRowNode);

                //run all over the cells
                for (var intCellIndex = 0; intCellIndex < objSelectedRowCellNodes.length; intCellIndex++)
                {
                    //get the cell node object
                    var objSelectedCellNode = objSelectedRowCellNodes[intCellIndex];

                    if (objSelectedCellNode)
                    {
                        //clear the value
                        strCellValue = "";

                        //Cell selection mode
                        if (Xml_IsAttribute(objSelectedCellNode, "Attr.Selected", "1") || Xml_IsAttribute(objSelectedCellNode.parentNode, "Attr.Selected", "1"))
                        {
                            //Get the cell value
                            strCellValue = Xml_GetAttribute(objSelectedCellNode, "Attr.Value", "");
                        }

                        //Check for the last column
                        if (intCellIndex == objSelectedRowCellNodes.length - 1)
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
        Web_CopyToClipBoard("Text", strCSV);
    }
}
/// </method>

/// <method name="DataGridView_Navigate">
/// <summary>
///	Impliments a navigation executer that navigates relativly to the last selected cell
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="intX">The horizontal navigation factor</param>
/// <param name="intY">The vertical navigation factor</param>
function DataGridView_Navigate(objWindow, objGridNode, objCellNode, intMoveX, intMoveY)
{
    var objCurrentNode = null;

    if (objGridNode && objCellNode &&
		!Xml_IsAttribute(objGridNode, "Attr.DisableNavigation", "1"))
    {
        // Get cell position.
        var intX = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objCellNode).length;

        // Get all rows.
        var objRowsNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow", objGridNode);
        if (objRowsNodes)
        {
            // Get the zero-based row index of the current node.
            var intY = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewRow", objCellNode.parentNode).length;
            var objRowNode = null;

            // get target row
            switch (intMoveY)
            {
                case mcntMoveBegin:
                    objRowNode = objRowsNodes[0];
                    break;
                case mcntMoveEnd:
                    objRowNode = objRowsNodes[objRowsNodes.length - 1];
                    break;
                default:
                    if ((intY + intMoveY) >= 0 && (intY + intMoveY) < objRowsNodes.length)
                    {
                        objRowNode = objRowsNodes[intY + intMoveY];
                    }
                    else if (intMoveY > 0 && intY != objRowsNodes.length - 1)
                    {
                        objRowNode = objRowsNodes[objRowsNodes.length - 1];
                    }
                    else if (intMoveY < 0 && intY != 0)
                    {
                        objRowNode = objRowsNodes[0];
                    }
            }

            if (objRowNode)
            {
                // Get contained cell nodes.
                var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objRowNode);
                if (objCellNodes)
                {
                    var intCellNodesLength = objCellNodes.length;
                    if (intCellNodesLength > 0)
                    {
                        if (intMoveX == mcntMoveBegin)
                        {
                            objCurrentNode = objCellNodes[0];
                        }
                        else if (intMoveX == mcntMoveEnd)
                        {
                            objCurrentNode = objCellNodes[intCellNodesLength - 1];
                        }
                        else if ((intX + intMoveX) >= 0 && (intX + intMoveX) < objCellNodes.length)
                        {
                            objCurrentNode = objCellNodes[intX + intMoveX];
                        }
                    }
                }
            }

            if (objCurrentNode)
            {
                // Clear selected cells.
                DataGridView_ClearSelectedCells(objWindow, objGridNode);

                // Get the current selection mode
                var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);
                if (intSelectionMode == 2)
                {
                    DataGridView_ToggleRowSelection(objWindow, objGridNode, objCurrentNode.parentNode, true, true);
                }
                else
                {
                    DataGridView_ToggleCellSelection(objWindow, objGridNode, objCurrentNode, true, true);
                }

                DataGridView_SetCurrentCell(objGridNode, objCurrentNode);

                // Check if EditMode is EditOnEnter
                if (Xml_IsAttribute(objGridNode, "Attr.EditMode", "0"))
                {
                    DataGridView_BeginActivateCell(objWindow, objGridNode, objCurrentNode);
                }

                // Define scroll mode variable.
                var intScrollMode = 0;

                // Check if only a vertical scrolling is needed.
                if (intMoveY > 0 && intMoveX == 0)
                {
                    intScrollMode = 1;
                }
                // Check if only an horizontal scrolling is needed.
                else if (intMoveX > 0 && intMoveY == 0)
                {
                    intScrollMode = 2;
                }

                DataGridView_ScrollIntoView(objWindow, objGridNode, objCurrentNode, intScrollMode);
            }
        }
    }

    return objCurrentNode;
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
    if (objGridNode)
    {
        // Check if grid contain any selected rows.
        if (Xml_SelectNodes("WG:Tags.DataGridViewRow[@Attr.Selected='1']", objGridNode).length > 0)
        {
            // Create a delete event.
            var objVwgEvent = Events_CreateEvent(Xml_GetAttribute(objGridNode, "Attr.Id"), "Delete", null, true);

            // Raise events.
            Events_RaiseEvents();

            Events_ProcessClientEvent(objVwgEvent);
        }
    }
}
/// </method>

/// <method name="DataGridView_ContainedInNewRow">
/// <summary>
///	
/// </summary>
/// <param name="objCellNode">The cell node being checked</param>
function DataGridView_ContainedInNewRow(objCellNode)
{
    return (objCellNode &&
			objCellNode.parentNode &&
			Xml_IsAttribute(objCellNode.parentNode, "Attr.IsNew", "1"));
}
/// </method>

/// <method name="DataGridView_HasActiveCells">
/// <summary>
///	Check whether the grid has active Cells
/// </summary>
function DataGridView_HasActiveCells(objGridNode)
{
    return Xml_SelectNodes("WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Active='1']", objGridNode).length > 0;
}
/// </method>

/// <method name="DataGridView_FireSelectionChange">
/// <summary>
///	Notifies the server about selection changes
/// </summary>
/// <param name="objGridNode">The altered grid</param>
/// <param name="blnSuspendEvents">A boolean that indicates whether to raise events or not.</param>
function DataGridView_FireSelectionChange(objGridNode, blnSuspendEvents, objEvent)
{
    // Get selected entities
    var arrSelected = DataGridView_GetSelectedEntities(objGridNode);

    // Get the grid's ID value.
    var strGuid = Xml_GetAttribute(objGridNode, "Attr.Id");

    // Creat ea new selection change event.
    var objVWGEvent = Events_CreateEvent(strGuid, "SelectionChanged", null, true);

    // Set value attribute.
    Events_SetEventAttribute(objVWGEvent, "Attr.Value", arrSelected.join(","));

    // Set the current cell attribute.
    var strCurrentCell = Xml_GetAttribute(objGridNode, "Attr.CurrentCell", "");
    if (strCurrentCell != "")
    {
        Events_SetEventAttribute(objVWGEvent, "Attr.CurrentCell", strCurrentCell);
    }

    // Check if control key is pressed and set Incremental attribute accordingly
    if (objEvent && Web_IsControl(objEvent))
    {
        Events_SetEventAttribute(objVWGEvent, "Incremental", "1");
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
    if (intSelectionMode == 2 || intSelectionMode == 8)
    {
        var objSelectedRowNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow[@Attr.Selected='1']", objGridNode);

        // Loop all child items
        for (var intIndex = 0; intIndex < objSelectedRowNodes.length; intIndex++)
        {
            arrSelected.push(Xml_GetAttribute(objSelectedRowNodes[intIndex], "Attr.MemberID"));
        }
    }

    // CellSelect or RowHeaderSelect mode.    
    if (intSelectionMode == 1 || intSelectionMode == 8)
    {
        var objSelectedCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[@Attr.Selected='1']", objGridNode);

        // Loop all child items
        for (var intIndex = 0; intIndex < objSelectedCellNodes.length; intIndex++)
        {
            arrSelected.push(Xml_GetAttribute(objSelectedCellNodes[intIndex], "Attr.MemberID"));
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
function DataGridView_CellClick(objCellElement, objWindow, objEvent)
{
    if (objCellElement)
    {
        // Update client cell selection.
        DataGridView_UpdateSelection(objCellElement, objWindow, objEvent);

        // Get DataGridView node
        var objGridNode = DataGridView_GetGridNode(objCellElement);

        // Get cell node.
        var objCellNode = DataGridView_GetNodeFromElement(objCellElement);

        if (objGridNode && objCellNode)
        {
            // Gets grid's guid.
            var strGridGuid = Xml_GetAttribute(objGridNode, "Attr.Id", "");

            /// Get cell full member id.
            var strCellMemberID = DataGridView_GetFullMemberID(objGridNode, objCellNode);

            // Validate id's.
            if (strGridGuid != "" && strCellMemberID != "")
            {
                // Raise events is selection change is critical.
                if (Data_IsCriticalEvent(strGridGuid, "Event.SelectionChange"))
                {
                    // Handles the click event and forces raise (this 'overload' cancels the click bubble.
                    Web_OnClick(objEvent, objWindow, true);
                }
            }
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

/// <method name="DataGridView_UpdateCellSelectSelection">
/// <summary>
///	
/// </summary>
function DataGridView_UpdateCellSelectSelection(objGridNode, objCellNode, objWindow, objEvent)
{
    // Validate recieved arguments.
    if (objGridNode && objCellNode && objWindow && objEvent)
    {
        //get old selected entities
        var strOldSelectedCells = DataGridView_GetSelectedEntities(objGridNode).join(",");

        // Get last selected cell node
        var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);

        // Define a switch which will indicate whether to toggle cell selection or not.
        var blnToggleCellSelection = true;

        // Check if cell is selected.
        var blnIsSelectedCell = Xml_IsAttribute(objCellNode, "Attr.Selected", "1");

        // Check if cell's row is selected.
        var blnIsContainedRowSelected = Xml_IsAttribute(objCellNode.parentNode, "Attr.Selected", "1");

        // Check if multi selection is enabled.
        var blnIsMultiSelectionEnabled = DataGridView_IsMultiSelectionEnabled(objGridNode);

        // Check if EditMode is EditOnEnter
        var blnIsEditOnEnter = Xml_IsAttribute(objGridNode, "Attr.EditMode", "0");

        // If is range click
        if (Web_IsShift(objEvent) && blnIsMultiSelectionEnabled)
        {
            if (objCurrentCellNode)
            {
                // Toggle selection range
                DataGridView_SelectCellRange(objWindow, objGridNode, objCellNode, objCurrentCellNode);
            }

            // Flag not to toggle.
            blnToggleCellSelection = false;
        }
        // If normal click
        else if (!Web_IsControl(objEvent) || !blnIsMultiSelectionEnabled)
        {
            // Clear previous selected cells
            DataGridView_ClearSelectedCells(objWindow, objGridNode, objCellNode);

            // If cell was seleceted.
            if (blnIsSelectedCell || blnIsContainedRowSelected || blnIsEditOnEnter)
            {
                // Check if cell is not read only.
                if (DataGridView_CanActivateCell(objGridNode, objCellNode))
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
                    else if (blnIsSelectedCell)
                    {
                        // Flag not to toggle.
                        blnToggleCellSelection = false;
                    }
                }
                // In case that cell is read only - check if the selected cell was selected previously.
                else if (blnIsSelectedCell)
                {
                    // Flag not to toggle.
                    blnToggleCellSelection = false;
                }
            }
        }

        // Check if toggling is needed.
        if (blnToggleCellSelection)
        {
            // In case that containg row was fully selected.
            if (Xml_IsAttribute(objCellNode.parentNode, "Attr.Selected", "1"))
            {
                // Toggle handled cell selection - GUI only.
                DataGridView_ToggleCellSelection(objWindow, objGridNode, objCellNode, true, false);

                // Unselect containg row.
                Xml_SetAttribute(objCellNode.parentNode, "Attr.Selected", "0");

                // Get chiild nodes length.
                var intChildLength = objCellNode.parentNode.childNodes.length;

                // Loop all of the handled cell's siblings.
                for (var intCellIndex = 0; intCellIndex < intChildLength; intCellIndex++)
                {
                    // Get current cell node.
                    var objChildCellNode = objCellNode.parentNode.childNodes[intCellIndex];

                    // Check if current cell is not the handled one and that it is not selected.
                    if (objCellNode != objChildCellNode && !Xml_IsAttribute(objChildCellNode, "Attr.Selected", "1"))
                    {
                        // Select current cell.
                        Xml_SetAttribute(objChildCellNode, "Attr.Selected", "1");
                    }
                }
            }
            else
            {
                // Add or remove cell selection
                DataGridView_ToggleCellSelection(objWindow, objGridNode, objCellNode, true, true);
            }
        }

        if (Xml_IsAttribute(objCellNode, "Attr.Selected", "1") || blnIsEditOnEnter)
        {
            DataGridView_SetCurrentCell(objGridNode, objCellNode);
        }

        // Redraw row headers.
        DataGridView_UpdateRowHeaders(objWindow, objGridNode, objCellNode, objCurrentCellNode);

        if (strOldSelectedCells != DataGridView_GetSelectedEntities(objGridNode).join(","))
        {
            // Fire selection change event.
            DataGridView_FireSelectionChange(objGridNode, true, objEvent);
        }
    }
}
/// </method>


/// <method name="DataGridView_UpdateSelection">
/// <summary>
///	
/// </summary>
function DataGridView_UpdateSelection(objClickSource, objWindow, objEvent)
{
    // Get cell node
    var objCellNode = DataGridView_GetNodeFromElement(objClickSource);

    // Get grid node.
    var objGridNode = DataGridView_GetGridNode(objClickSource);

    // Get the current selection mode
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);

    //In case of FullRowSellect.
    if (intSelectionMode == 2)
    {
        DataGridView_UpdateFullRowSelectSelection(false, objWindow, objEvent, objGridNode, objCellNode.parentNode, objCellNode);
    }
    //In case of CellSellect or RowHeaderSelect.
    else if (intSelectionMode == 1 || intSelectionMode == 8)
    {
        DataGridView_UpdateCellSelectSelection(objGridNode, objCellNode, objWindow, objEvent);
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
function DataGridView_RowHeaderClick(objCell, objWindow, objEvent, blnSetDgvTableFocus)
{
    // Get cell node
    var objRowNode = DataGridView_GetNodeFromElement(objCell);
    if (objRowNode)
    {
        // Get contained cell nodes.
        var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objRowNode);
        if (objCellNodes)
        {
            // Get grid's node.
            var objGridNode = DataGridView_GetGridNode(objCell);
            if (objGridNode)
            {
                // Get the current cell.
                var objCellNode = DataGridView_GetCurrentCell(objGridNode);

                // Check if current cell row changed 
                if (objCellNode == null || objCellNode.parentNode != objRowNode)
                {
                    // Set the first cell node as current cell.
                    objCellNode = objCellNodes[0];
                }

                // Update row selection.
                DataGridView_UpdateFullRowSelectSelection(true, objWindow, objEvent, objGridNode, objRowNode, objCellNode, blnSetDgvTableFocus);

                // Gets grid's guid.
                var strGridGuid = Xml_GetAttribute(objGridNode, "Attr.Id", "");

                /// Get row full member id.
                var strRowMemberID = DataGridView_GetFullMemberID(objGridNode, objRowNode);

                // Validate id's.
                if (!Aux_IsNullOrEmpty(strGridGuid) && !Aux_IsNullOrEmpty(strRowMemberID))
                {

                    // Raise events is selection change is critical.
                    if (Data_IsCriticalEvent(strGridGuid, "Event.SelectionChange"))
                    {
                        // We call the Focus function in order to restore the focus to the DGV after the event is raised (The event redraws the DGV so the focus is lost).
                        var objFocusDelegate = { fncMethod: DataGridView_FocusDataGridViewTable, arrArguments: [objWindow, objGridNode, true] };
		         
                        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
                        Web_OnClick(objEvent, objWindow, true, null, objFocusDelegate);
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
function DataGridView_UpdateFullRowSelectSelection(blnIsHeaderCellSource, objWindow, objEvent, objGridNode, objRowNode, objCellNode, blnSetDgvTableFocus)
{
    if (objGridNode && objRowNode)
    {
        //get old selected entities    
        var strOldSelectedCells = DataGridView_GetSelectedEntities(objGridNode).join(","); ;

        // Set default required status
        var strRequiredSelectedStatus = "1";

        // Check ig multi selection is enabled.
        var blnIsMultiSelectionEnabled = DataGridView_IsMultiSelectionEnabled(objGridNode);

        // If is adding click
        if (Web_IsControl(objEvent) && blnIsMultiSelectionEnabled)
        {
            strRequiredSelectedStatus = (Xml_IsAttribute(objRowNode, "Attr.Selected", "1") ? "0" : "1");
        }
        // If is range click
        else if (Web_IsShift(objEvent) && blnIsMultiSelectionEnabled)
        {
            // Define empty range indexes.
            var intFromIndex = null;
            var intToIndex = null;

            // Get current row position.
            var intCurrentRowPosition = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewRow", objRowNode).length + 1;

            // Get last selected row which is positioned before current row.
            var objPriorSelectedRow = Xml_SelectSingleNode("WG:Tags.DataGridViewRow[@Attr.Selected='1' and position()<" + intCurrentRowPosition + "][last()]", objGridNode);

            // Get first selected row positioned after current row.
            var objFollowingSelectedRow = Xml_SelectSingleNode("WG:Tags.DataGridViewRow[@Attr.Selected='1' and position()>" + intCurrentRowPosition + "][1]", objGridNode);

            // Check if a prior row has been found.
            if (objPriorSelectedRow)
            {
                // Set proper indexes.            
                intFromIndex = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewRow", objPriorSelectedRow).length + 1;
                intToIndex = intCurrentRowPosition - 1;
            }
            // Check if a following row has been found.            
            else if (objFollowingSelectedRow)
            {
                // Set proper indexes.
                intFromIndex = intCurrentRowPosition + 1;
                intToIndex = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewRow", objFollowingSelectedRow).length + 1;
            }

            // Clears all selected cells in grid.
            DataGridView_ClearSelectedCells(objWindow, objGridNode);

            if (!Aux_IsNullOrEmpty(intFromIndex) && !Aux_IsNullOrEmpty(intToIndex))
            {
                // Query all rows in range.
                var arrRows = Xml_SelectNodes("WG:Tags.DataGridViewRow[position()>=" + intFromIndex + " and position()<=" + intToIndex + "]", objGridNode);

                // Loop all rows.
                for (var intRowIndex = 0; intRowIndex < arrRows.length; intRowIndex++)
                {
                    // Toggle row selection.
                    DataGridView_ToggleRowSelection(objWindow, objGridNode, arrRows[intRowIndex], true, true);
                }
            }
        }
        // If normal click
        else
        {
            var blnSelectedRow = (objRowNode && Xml_IsAttribute(objRowNode, "Attr.Selected", "1"));

            // Clear all selected cells.
            DataGridView_ClearSelectedCells(objWindow, objGridNode, objRowNode);

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
        if (!Xml_IsAttribute(objRowNode, "Attr.Selected", strRequiredSelectedStatus))
        {
            // Get contained cell nodes.
            var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objRowNode);
            if (objCellNodes)
            {
                // Get the number of cells.
                var intCellsLength = objCellNodes.length;

                // Loop all child items
                for (var intIndex = 0; intIndex < intCellsLength; intIndex++)
                {
                    // Clear cell's selected attribute.
                    Xml_SetAttribute(objCellNodes[intIndex], "Attr.Selected", "0");

                    // Toggle cell selection.
                    DataGridView_ToggleCellSelection(objWindow, objGridNode, objCellNodes[intIndex], true, false);
                }
            }

            // Toggle row selection mode
            Xml_SetAttribute(objRowNode, "Attr.Selected", strRequiredSelectedStatus);
        }

        // Set current cell.   
        DataGridView_SetCurrentCell(objGridNode, objCellNode);

        // Redraw row header.   
        DataGridView_UpdateRowHeaders(objWindow, objGridNode, objCellNode, objCurrentCellNode, objRowNode);

        if (blnSetDgvTableFocus)
        {
            // Set the DataGridView table focus.
            DataGridView_FocusDataGridViewTable(objWindow, objGridNode);
        }

        if (strOldSelectedCells != DataGridView_GetSelectedEntities(objGridNode).join(","))
        {
            // Fire selection change event.
            DataGridView_FireSelectionChange(objGridNode, true, objEvent);
        }
    }
}
/// </method>


/// <method name="DataGridView_IsMultiSelectionEnabled">
/// <summary>
///	
/// </summary>
function DataGridView_IsMultiSelectionEnabled(objGridNode)
{
    return !Xml_IsAttribute(objGridNode, "Attr.Multiple", "0");
}
/// </method>

/// <method name="DataGridView_GetSelectionMode">
/// <summary>
///	CellSelect = 1, FullRowSelect = 2, RowHeaderSelect = 8
/// </summary>
function DataGridView_GetSelectionMode(objGridNode)
{
    return parseInt(Xml_GetAttribute(objGridNode, "Attr.SelectionMode", 1));
}
/// </method>

/// <method name="DataGridView_SelectCellRange">
/// <summary>
///	Toggles the state of a selected cell range
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="objCurrentCellNode">The last selected cell data node</param>
function DataGridView_SelectCellRange(objWindow, objGridNode, objCellNode, objCurrentCellNode)
{
    // Get cell range
    var intFirstCell = Xml_GetPosition(objCellNode);
    var intLastCell = Xml_GetPosition(objCurrentCellNode);

    // Get row range
    var intFirstRow = Xml_GetPosition(objCellNode.parentNode);
    var intLastRow = Xml_GetPosition(objCurrentCellNode.parentNode);

    // Used to normalize ranges
    var intTemp;

    // Normalize cell range
    if (intFirstCell > intLastCell)
    {
        intTemp = intLastCell;
        intLastCell = intFirstCell;
        intFirstCell = intTemp;
    }

    // Normalize row rande
    if (intFirstRow > intLastRow)
    {
        intTemp = intLastRow;
        intLastRow = intFirstRow;
        intFirstRow = intTemp;
    }

    // Iterate row range
    for (var intRow = intFirstRow; intRow <= intLastRow; intRow++)
    {
        // Get current row
        var objCurrentRow = objGridNode.childNodes[intRow];
        if (objCurrentRow && !Xml_IsAttribute(objCurrentRow, "Attr.Selected", "1"))
        {
            // Iterate cell range
            for (var intCell = intFirstCell; intCell <= intLastCell; intCell++)
            {
                // Get current cell
                var objChildNode = objCurrentRow.childNodes[intCell];
                if (objChildNode && !Xml_IsAttribute(objChildNode, "Attr.Selected", "1"))
                {
                    // Toggle cell state 
                    DataGridView_ToggleCellSelection(objWindow, objGridNode, objChildNode, true, true);
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
function DataGridView_ClearSelectedCells(objWindow, objGridNode, objExcludedNode)
{
    // Get the current selection mode
    var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);

    // Define xpath variables.
    var strXPath = "WG:Tags.DataGridViewRow";
    var strConditionXPath = "@Attr.Selected='1'";

    // Validate excluded node.
    if (objExcludedNode)
    {
        // Update the condition Xpath.
        strConditionXPath += (" and not(@Attr.MemberID='" + Xml_GetAttribute(objExcludedNode, "Attr.MemberID", "") + "')");
    }

    // FullRowSelect mode.    
    if (intSelectionMode == 2)
    {
        // Concat the full xpath.
        strXPath += ("[" + strConditionXPath + "]");
    }
    // CellSelect mode.        
    else if (intSelectionMode == 1)
    {
        // Concat the full xpath.        
        strXPath += ("/WG:Tags.DataGridViewCell[" + strConditionXPath + "]");
    }
    // RowHeaderSelect mode.
    else if (intSelectionMode == 8)
    {
        // Concat the full xpath.        
        strXPath += ("[" + strConditionXPath + "] | WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[" + strConditionXPath + "]");
    }

    // Get selected nodes.
    var arrSelectedNodes = Xml_SelectNodes(strXPath, objGridNode);
    if (arrSelectedNodes && arrSelectedNodes.length > 0)
    {
        // Get selected nodes length.
        var intNoneSelectedNodesLength = arrSelectedNodes.length;

        // Loop all child items
        for (var intIndex = 0; intIndex < intNoneSelectedNodesLength; intIndex++)
        {
            // Get current cell node
            var objSelectedNode = arrSelectedNodes[intIndex];

            // In case of a row node.    
            if (objSelectedNode.tagName == "WG:Tags.DataGridViewRow")
            {
                DataGridView_ToggleRowSelection(objWindow, objGridNode, objSelectedNode, true, true);
            }
            // In case of a cell node.    
            else if (objSelectedNode.tagName == "WG:Tags.DataGridViewCell")
            {
                DataGridView_ToggleCellSelection(objWindow, objGridNode, objSelectedNode, true, true);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_GetCellElement">
/// <summary>
///	Gets a browser dom element from a given cell data node
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_GetCellElement(objWindow, objGridNode, objCellNode)
{
    return Web_GetWebElement(Web_GetWebId(Xml_GetAttribute(objGridNode, "Id") + "_" + Xml_GetAttribute(objCellNode, "Attr.MemberID")), objWindow);
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
function DataGridView_PerformScrollIntoView(strGuid, strCellId, blnHidePopups)
{
    // Get the relevant window
    var objWindow = Forms_GetWindowByDataId(strGuid);
    if (objWindow)
    {
        // Check if popups should be hidden.
        if (blnHidePopups)
        {
            // Get the grid element.
            var objDataGridViewElement = Web_GetElementByDataId(strGuid, objWindow);
            if (objDataGridViewElement)
            {
                // Hide all popups beside the popup element the grid might be located in.
                Popups_HidePopups(objDataGridViewElement);
            }
        }

        // Get the grid node.
        var objGridNode = Data_GetNode(strGuid);
        if (objGridNode)
        {
            // Scroll into view.
            DataGridView_ScrollIntoView(objWindow, objGridNode, Data_GetNodeByMember(strCellId, objGridNode, true), 0);
        }
    }
}
/// </method>

/// <method name="DataGridView_ScrollIntoView">
/// <summary>
///	Implements a scroll into view behavior for the datagrid
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
/// <param name="intMode">intMode = {0 - Both horizontal and vertical scrolling ; 1- Vertical scrolling. ; 2 - horizontal scrolling.}</param>
function DataGridView_ScrollIntoView(objWindow, objGridNode, objCellNode, intMode)
{
    // Validate recieved arguments.
    if (objWindow && objGridNode && objCellNode)
    {
        // Get cell element
        var objCellElement = DataGridView_GetCellElement(objWindow, objGridNode, objCellNode);

        // Get the scollable element
        var objScrollElement = Web_GetWebElement("VWGDGVBODY_" + Xml_GetAttribute(objGridNode, "Id"), objWindow);

        // If cell and scrollable elements where found
        if (objScrollElement && objCellElement)
        {
            Web_ScrollIntoView(objCellElement, objScrollElement, intMode);
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
    var objContainer = Web_GetWebElement("VWGDGVBODY_" + Xml_GetAttribute(objGridNode, "Id"), objWindow);
    if (objContainer && Web_IsContained(objContainer, objCellElement))
    {
        return 0; // Container is a SCROLLER
    }
    else
    {
        objContainer = Web_GetWebElement("VWGDGVFROZENROWS_" + Xml_GetAttribute(objGridNode, "Id"), objWindow);
        if (objContainer && Web_IsContained(objContainer, objCellElement))
        {
            return 1;  // Container is a ROWHEADER (Frozen Column)
        }
        else
        {
            objContainer = Web_GetWebElement("VWGDGVFROZENCOLUMNS_" + Xml_GetAttribute(objGridNode, "Id"), objWindow);
            if (objContainer && Web_IsContained(objContainer, objCellElement))
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
function DataGridView_ActivateCell(objWindow, objGridNode, objCellNode)
{
    if (objCellNode)
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
    if (objSource)
    {
        // Deattach blur handler.
        Web_DetachEvent(objSource, "blur", DataGridView_OnActiveCelllBlur);

        // Get VWG source element.
        var objVwgSource = Web_GetVwgElement(objSource, true);
        if (objVwgSource)
        {
            // Get grid node.
            var objGridNode = DataGridView_GetGridNode(objVwgSource);
            if (objGridNode)
            {
                // Get cell's data id.
                var strCellDataId = Data_GetDataId(Web_GetId(objVwgSource));
                if (!Aux_IsNullOrEmpty(strCellDataId))
                {
                    // Get grid's window
                    var objWindow = Forms_GetWindowByDataId(strCellDataId);
                    if (objWindow)
                    {
                        // Get cell node.
                        var objCellNode = Data_GetNode(strCellDataId);
                        if (objCellNode)
                        {
                            //Check if combobox cell share focus
                            if (!Popups_ShareFocusWithExistPopup(strCellDataId))
                            {
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
                                DataGridView_DeactivateCell(objWindow, objGridNode, objCellNode);

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
function DataGridView_SetCellActiveState(objCellNode, blnActiveState)
{
    // Validate cell node.
    if (objCellNode)
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
function DataGridView_DeactivateCell(objWindow, objGridNode, objCellNode)
{
    if (objGridNode)
    {
        // If not cell node
        if (!objCellNode)
        {
            // Get current node
            objCellNode = DataGridView_GetCurrentCell(objGridNode);
        }

        // Set active node
        if (objCellNode && Xml_IsAttribute(objCellNode, "Attr.Active", "1"))
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
function DataGridView_SelectAllGridRows(strGridGuid, objWindow, objEvent)
{
    // Get grid node
    var objGridNode = Data_GetNode(strGridGuid);
    if (objGridNode)
    {
        // Get the current selection mode
        var intSelectionMode = DataGridView_GetSelectionMode(objGridNode);

        // Define none selected cell array.
        var arrNoneSelectedNodes = null;

        // FullRowSelect or RowHeaderSelect mode.
        if (intSelectionMode == 2 || intSelectionMode == 8)
        {
            // Get all unselected rows.
            arrNoneSelectedNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow[not(@Attr.Selected) or @Attr.Selected='0']", objGridNode);
        }
        // CellSelect mode.
        else if (intSelectionMode == 1)
        {
            // Get all unselected cells.
            arrNoneSelectedNodes = Xml_SelectNodes("WG:Tags.DataGridViewRow/WG:Tags.DataGridViewCell[not(@Attr.Selected) or @Attr.Selected='0']", objGridNode);
        }

        if (arrNoneSelectedNodes)
        {
            // Get nodes array length.
            var intNoneSelectedNodesLength = arrNoneSelectedNodes.length;

            // Loop all none selected nodes.
            for (var intIndex = 0; intIndex < intNoneSelectedNodesLength; intIndex++)
            {
                // FullRowSelect or RowHeaderSelect mode.
                if (intSelectionMode == 2 || intSelectionMode == 8)
                {
                    // Select current row
                    DataGridView_ToggleRowSelection(objWindow, objGridNode, arrNoneSelectedNodes[intIndex], false, true);
                }
                // CellSelect mode.    
                else if (intSelectionMode == 1)
                {
                    // Select current cell
                    DataGridView_ToggleCellSelection(objWindow, objGridNode, arrNoneSelectedNodes[intIndex], false, true);
                }
            }

            if (intNoneSelectedNodesLength > 0)
            {
                // Fire selection change.
                DataGridView_FireSelectionChange(objGridNode, false, objEvent);

                // Redraws grid.
                Controls_RedrawControlById(objWindow, strGridGuid);
            }
        }
    }

    // Prevent default behavior.
    Web_EventCancelBubble(objEvent, true, false);
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
function DataGridView_ToggleCellSelection(objWindow, objGridNode, objCellNode, blnToggleGui, blnToggleData)
{
    // Get cell element
    var objCellElement = DataGridView_GetCellElement(objWindow, objGridNode, objCellNode);
    if (objCellElement)
    {
        // Get grid's id.
        var strDataID = Xml_GetAttribute(objGridNode, "Attr.Id");

        // Define empty variables.
        var strBackgroundColor = "";
        var strForeColor = "";

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

        // Check whether handled node is selected.
        var blnIsSelected = (Xml_IsAttribute(objCellNode, "Attr.Selected", "1") || Xml_IsAttribute(objCellNode.parentNode, "Attr.Selected", "1"));

        // Toggle data attribute.
        if (blnToggleData)
        {
            Xml_SetAttribute(objCellNode, "Attr.Selected", blnIsSelected ? "0" : "1");
        }

        // Check if gui should be updated.
        if (blnToggleGui)
        {
            // If cell is selected
            if (blnIsSelected)
            {
                // Get the BackgroundColor and ForeColor from the rendered XML
                strBackgroundColor = Xml_GetAttribute(objCellNode, "Attr.Background", "");
                strForeColor = Xml_GetAttribute(objCellNode, "Attr.Fore", "");

                // Set normal class name.
                strClassName += "DataGridView-Cell";
            }
            else
            {
                // Get the BackgroundColor and ForeColor from the rendered XML
                strBackgroundColor = Xml_GetAttribute(objCellNode, "Attr.SelectionBackColor", "");
                strForeColor = Xml_GetAttribute(objCellNode, "Attr.SelectionForeColor", "");

                // Set selected class name.
                strClassName += "DataGridView-Cell_Selected";
            }

            // Set class name.
            if (!Aux_IsNullOrEmpty(strClassName))
            {
                objCellElement.className = strClassName;
            }

            // Set background color.
            objCellElement.style.backgroundColor = strBackgroundColor;

            // Set fore color.
            objCellElement.style.color = strForeColor;
                
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
function DataGridView_ToggleRowSelection(objWindow, objGridNode, objRowNode, blnToggleGui, blnToggleData)
{
    if (objRowNode)
    {
        // Get contained cell nodes.
        var objCellNodes = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objRowNode);
        if (objCellNodes)
        {
            for (var i = 0; i < objCellNodes.length; i++)
            {
                var objCellNode = objCellNodes[i];
                if (objCellNode)
                {
                    DataGridView_ToggleCellSelection(objWindow, objGridNode, objCellNode, blnToggleGui, blnToggleData && Xml_IsAttribute(objCellNode, "Attr.Selected", "1"));
                }
            }

            if (blnToggleData)
            {
                // Check whether handled row is selected.
                var blnIsSelected = Xml_IsAttribute(objRowNode, "Attr.Selected", "1");

                // Toggle row selection mode
                Xml_SetAttribute(objRowNode, "Attr.Selected", blnIsSelected ? "0" : "1");
            }

            // Redraw header.
            DataGridView_RedrawRowHeader(objWindow, objGridNode, objRowNode);
        }
    }
}
/// </method>

/// <method name="DataGridView_UpdateRowHeaders">
/// <summary>
///	Redraws a row header
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objNewCurrentCellNode">The new grid cell data node</param>
/// <param name="objPreviousCurrentCellNode">The previous grid cell data node</param>
function DataGridView_UpdateRowHeaders(objWindow, objGridNode, objNewCurrentCellNode, objPreviousCurrentCellNode, objNewCurrentRow)
{
    // Check if previous current cell node has been sent.
    if (!objPreviousCurrentCellNode)
    {
        objPreviousCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);
    }

    // Get preious and new current cells id's.
    var strPreviousCurrentCellDataID = Xml_GetAttribute(objPreviousCurrentCellNode, "Attr.MemberID", "");
    var strNewCurrentCellDataID = Xml_GetAttribute(objNewCurrentCellNode, "Attr.MemberID", "");

    // Check if current cell has been changed.
    if (strPreviousCurrentCellDataID != strNewCurrentCellDataID)
    {
        if (!Aux_IsNullOrEmpty(strNewCurrentCellDataID))
        {
            Xml_SetAttribute(objGridNode, "Attr.CurrentCell", strNewCurrentCellDataID);
        }

        if (objPreviousCurrentCellNode)
        {
            DataGridView_RedrawRowHeader(objWindow, objGridNode, objPreviousCurrentCellNode.parentNode);
        }
    }

    // Update current row header
    if (objNewCurrentCellNode || objNewCurrentRow)
    {
        DataGridView_RedrawRowHeader(objWindow, objGridNode, objNewCurrentRow || objNewCurrentCellNode.parentNode);
    }
}
/// </method>

/// <method name="DataGridView_RedrawRowHeaderByID">
/// <summary>
///	Redraws a row header
/// </summary>
/// <param name="strGridGuid">The current grid data id</param>
/// <param name="strRowGuid">The current grid row data id</param>
function DataGridView_RedrawRowHeaderByID(strGridGuid, strRowGuid)
{
    // Get grid node
    var objGridNode = Data_GetNode(strGridGuid);
    if (objGridNode)
    {
        // Get row node.
        var objRowNode = Data_GetNode(strRowGuid);
        if (objRowNode)
        {
            // Redraws a row header.
            return DataGridView_RedrawRowHeader(Web_GetActiveWindow(), objGridNode, objRowNode);
        }
    }
}
/// </method>

/// <method name="DoDataGridView_RedrawRowHeader">
/// <summary>
///	Redraws a row header
/// </summary>
/// <param name="objWindow">The owner window of this datagrid</param>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objRowNode">The current grid row data node</param>
function DataGridView_RedrawRowHeader(objWindow, objGridNode, objRowNode)
{
    if (objGridNode && objRowNode)
    {
        // Get grid's id.
        var strDataID = Xml_GetAttribute(objGridNode, "Attr.Id");

        // Get row header container element.
        var objRowHeaderContainerElement = Web_GetElementById("VWGROW1_" + strDataID + "_" + Xml_GetAttribute(objRowNode, "Attr.MemberID"), objWindow);
        if (objRowHeaderContainerElement)
        {
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

            // Add row header class name.
            strClassName += "DataGridView-RowHeader";

            // Check if the handled row is selected.
            if (Xml_IsAttribute(objRowNode, "Attr.Selected", "1"))
            {
                // Add selected class.
                strClassName += " DataGridView-RowHeader_Selected";
            }

            // Check if new class name is different from the exist one.
            if (objRowHeaderContainerElement.className != strClassName)
            {
                // Update class name.
                objRowHeaderContainerElement.className = strClassName;
            }
        }

        // Get row header element.
        var objRowHeaderElement = Web_GetElementById("DGVRH_" + Xml_GetAttribute(objGridNode, "Attr.Id") + "_" + Xml_GetAttribute(objRowNode, "Attr.MemberID"), objWindow);
        if (objRowHeaderElement)
        {
            // Clear all previous images.
            while (objRowHeaderElement.childNodes.length > 0)
            {
                objRowHeaderElement.removeChild(objRowHeaderElement.childNodes[0]);
            }

            // Check if the recieved row has a cell (textbox, ceckbox or combobox) which is active.
            if ((Xml_GetAttribute(objGridNode, "Attr.ShowEditingIcon", "1") == "1") && Xml_SelectNodes("WG:Tags.DataGridViewCell[@Attr.Active='1' and @Attr.SupportEditMode='1']", objRowNode).length > 0)
            {
                $(objRowHeaderElement).append(DataGridView_CreateImageElement(objWindow, "[Skin.Path]DGVEditedMode" + (mblnIsRTL ? "RTL" : "LTR") + ".gif.wgx", "middle"));
            }

            // Check if the recieved row has a cell which is the current cell.
            else if (Xml_SelectNodes("WG:Tags.DataGridViewCell[@Attr.MemberID='" + Xml_GetAttribute(objGridNode, "Attr.CurrentCell", "") + "']", objRowNode).length > 0)
            {
                $(objRowHeaderElement).append(DataGridView_CreateImageElement(objWindow, "[Skin.Path]DGVSelectedMode" + (mblnIsRTL ? "RTL" : "LTR") + ".gif.wgx", "middle"));
            }

            // Check if the recieved row is not a new row.
            else if (!Xml_IsAttribute(objRowNode, "Attr.IsNew", "1"))
            {
                Web_SetInnerText(objRowHeaderElement, " ");
            }

            // Check if the recieved row is a new row.
            if (Xml_IsAttribute(objRowNode, "Attr.IsNew", "1"))
            {
                $(objRowHeaderElement).append(DataGridView_CreateImageElement(objWindow, "[Skin.Path]DGVNewRowMode.gif.wgx"));
            }

            // Try get an error message out of the recieved row.
            var strErrorMessage = Xml_GetAttribute(objRowNode, "Attr.ErrorMessage", "", true);

            if (strErrorMessage != "")
            {
                $(objRowHeaderElement).append(DataGridView_CreateImageElement(objWindow, "[Skin.Path]ErrorProvider.gif.wgx", "middle", strErrorMessage));
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_CreateImageElement">
/// <summary>
///	
/// </summary>
/// <param name="strSource">The source of the image</param>
/// <param name="strTitle">The title of the image.</param>
function DataGridView_CreateImageElement(objWindow, strSource, strValign, strTitle)
{
    var objImage = null;

    if (objWindow && strSource)
    {
        // Create a new image element.
        objImage = objWindow.document.createElement("IMG");

        // Set image's source.
        objImage.src = strSource;

        // Set image's title.
        objImage.alt = "";
        if (strTitle)
        {
            objImage.title = strTitle;
            objImage.alt = strTitle;
        }
    }

    return objImage;
}
/// </method>

/// <method name="DataGridView_SetCurrentCell">
/// <summary>
///	Sets the last selected cell
/// </summary>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_SetCurrentCell(objGridNode, objCellNode)
{
    if (objCellNode)
    {
        Xml_SetAttribute(objGridNode, "Attr.CurrentCell", Xml_GetAttribute(objCellNode, "Attr.MemberID"));
        Xml_SetAttribute(objGridNode, "LCR", "");
    }
}
/// </method>

/// <method name="DataGridView_GetCurrentCell">
/// <summary>
///	Gets the last selected cell
/// </summary>
/// <param name="objGridNode">The current grid data node</param>
function DataGridView_GetCurrentCell(objGridNode)
{
    var strMemberId = Xml_GetAttribute(objGridNode, "Attr.CurrentCell");
    if (!Aux_IsNullOrEmpty(strMemberId))
    {
        return Data_GetNodeByMember(strMemberId, objGridNode, true);
    }
}
/// </method>

/// <method name="DataGridView_GetLastCellRange">
/// <summary>
///	Gets last selected cell that has created a cell range
/// </summary>
/// <param name="objGridNode">The current grid data node</param>
function DataGridView_GetLastCellRange(objGridNode)
{
    var strMemberId = Xml_GetAttribute(objGridNode, "LCR");
    if (strMemberId)
    {
        return Data_GetNodeByMember(strMemberId, objGridNode, true);
    }
}
/// </method>


/// <method name="DataGridView_GetNodeFromElement">
/// <summary>
///	Gets a data node from a element reference
/// </summary>
/// <param name="objElement">Element reference</param>
function DataGridView_GetNodeFromElement(objElement)
{
    if (objElement)
    {
        return Data_GetNode(Data_GetDataId(objElement.id));
    }
    return null;
}
/// </method>

/// <method name="DataGridView_GetNode">
/// <summary>
///	Gets a grid data node from a cell reference
/// </summary>
/// <param name="objCell">Cell reference</param>
function DataGridView_GetGridNode(objCell)
{
    return Data_GetNode(Data_GetDataOwnerId(objCell.id));
}
/// </method>

/// <method name="DataGridView_GetFullMemberID">
/// <summary>
///	
/// </summary>
function DataGridView_GetFullMemberID(objGridNode, objMemberNode)
{
    return Xml_GetAttribute(objGridNode, "Id") + "_" + Xml_GetAttribute(objMemberNode, "Attr.MemberID");
}
/// </method>

/// <method name="DataGridView_CanActivateCell">
/// <summary>
///	Checks if a cell can be activated
/// </summary>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_CanActivateCell(objGridNode, objCellNode)
{
    return !DataGridView_IsReadOnly(objGridNode, objCellNode);
}
/// </method>

/// <method name="DataGridView_IsReadOnly">
/// <summary>
///	Checks if a cell is read only
/// </summary>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_IsReadOnly(objGridNode, objCellNode)
{
    var blnReadOnly = false;

    // Get cell definition
    var strReadOnly = Xml_GetAttribute(objCellNode, "Attr.ReadOnly", "-1");

    //check if the value exist	
    if (strReadOnly != "-1")
    {
        //set readonly flag to true if the xml attribute is 1
        blnReadOnly = (strReadOnly == "1");
    }
    else
    {
        // Get column definition
        var objColumnNode = DataGridView_GetColumnNode(objGridNode, objCellNode);
        if (objColumnNode)
        {
            // Check if column is read only.
            blnReadOnly = Xml_IsAttribute(objColumnNode, "Attr.ReadOnly", "1");
        }

        if (!blnReadOnly)
        {
            // Get row  definition
            var objRowNode = objCellNode.parentNode;
            if (objRowNode)
            {
                // Check if row is read only.
                blnReadOnly = Xml_IsAttribute(objRowNode, "Attr.ReadOnly", "1");
            }

            if (!blnReadOnly)
            {
                // Check if grid is only.
                blnReadOnly = Xml_IsAttribute(objGridNode, "Attr.ReadOnly", "1");
            }
        }
    }

    return blnReadOnly;
}
/// </method>

/// <method name="DataGridView_GetColumnNode">
/// <summary>
///	Gets the current cell grid node
/// </summary>
/// <param name="objGridNode">The current grid data node</param>
/// <param name="objCellNode">The current grid cell data node</param>
function DataGridView_GetColumnNode(objGridNode, objCellNode)
{
    // Get cell's position.
    var intIndex = Xml_SelectNodes("preceding-sibling::WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objCellNode).length;
    if (intIndex >= 0)
    {
        return Xml_SelectSingleNode("WG:Tags.DataGridViewColumn[position()='" + (intIndex + 1) + "']", objGridNode);
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
    if (blnSynchronicFocus)
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

/// <method name="DataGridView_IsActivatingKeyCode">
/// <summary>
///	
/// </summary>
function DataGridView_IsActivatingKeyCode(intKeyCode)
{
    return ![20, 16, 17, 18, 91, 33, 34, 144, 93, 145, 45].contains(intKeyCode) && (intKeyCode < 112 || intKeyCode > 123);
}
/// </method>

/// <method name="DataGridView_HandleKeyDownCellActivation">
/// <summary>
///	
/// </summary>
function DataGridView_HandleKeyDownCellActivation(objWindow, objGridNode, objCellNode, objEvent)
{
    // If cell is not already active.
    if (!Xml_IsAttribute(objCellNode, "Attr.Active", "1") && DataGridView_CanActivateCell(objGridNode, objCellNode))
    {
        // Get cell full member id.
        var strCellFullMemberID = DataGridView_GetFullMemberID(objGridNode, objCellNode);

        var blnIsBeginEditCritical = Data_IsCriticalEvent(strCellFullMemberID, "Event.BeginEdit");

        // Create a BeginEdit event.
        var objVwgEvent = Events_CreateEvent(strCellFullMemberID, "BeginEdit", null, true, false, !blnIsBeginEditCritical);

        // Check if begin edit is critical for the activated
        if (blnIsBeginEditCritical)
        {
            Events_RaiseEvents();
        }

            // Activate cell.
            DataGridView_ActivateCell(objWindow, objGridNode, objCellNode);

            // Redraw row header so that the edit icon will appear.
            DataGridView_UpdateRowHeaders(objWindow, objGridNode, objCellNode);

            // Get the active cell element.
            var objCellElement = DataGridView_GetCellElement(objWindow, objGridNode, objCellNode);
            if (objCellElement)
            {
                // Try getting a focusable element.
                var objFocusableElement = Controls_GetFocusElement(objCellElement);
                if (objFocusableElement)
                {
                    // Define a function which will handle the key down source element's key down event.
                    var fncKeyDownHandler = function (objKeyDownEvent)
                    {
                        // Unbind this key down handler.
                        $(this).unbind("keydown", fncKeyDownHandler);

                        // Stop event's propogation.
                        objKeyDownEvent.stopPropagation();
                    };

                    // Bind a key down handler to the key down source element.
                    $(objFocusableElement).bind("keydown", fncKeyDownHandler);

                    // Trigger key down event on the focusable element.
                    $(objFocusableElement).keydown();

                    if (mcntIsIE)
                    {
                        // Cancel bubble
                        Web_EventCancelBubble(objEvent, false, true);
                    }
                }
            }
        // Process client BeginEdit event.
        Events_ProcessClientEvent(objVwgEvent);
    }
}
/// </method>

/// <method name="DataGridView_iScrollSyncScrollers">
/// <summary>
///	
/// </summary>
function DataGridView_iScrollSyncScrollers(strDataID)
{
    if (!Aux_IsNullOrEmpty(strDataID))
    {
        // Gets the grid's window.
        var objWindow = Forms_GetWindowByDataId(strDataID);
        if (objWindow)
        {
            // Get the grid's scrollable element.
            var objDgvBodyElement = Web_GetElementById("VWGDGVBODY_" + strDataID, objWindow);
            if (objDgvBodyElement)
            {
                // Get the grid's iScroll element.
                var objDgvBodyIScrollElement = objDgvBodyElement.iScrollElement;
                if (objDgvBodyIScrollElement)
                {
                    // Get column header's scroller element.
                    var objColumnHeaderScroller = Web_GetElementById("VWGDGVFROZENCOLUMNS_" + strDataID, objWindow);
                    if (objColumnHeaderScroller)
                    {
                        // Get the column header's iScroll element.
                        var objColumnHeaderIScroller = objColumnHeaderScroller.iScrollElement;
                        if (!objColumnHeaderIScroller)
                        {
                            // Create and preserve a new IScroll element for the column header.
                            objColumnHeaderScroller.iScrollElement = objColumnHeaderIScroller = new IScroll(objColumnHeaderScroller, { scrollbars: false });
                        }

                        // Perform scrolling on the column header's iScroll element.
                        objColumnHeaderIScroller.scrollTo(objDgvBodyIScrollElement.x, 0, 0);
                    }

                    // Get row header's scroller element.
                    var objRowHeaderScroller = Web_GetElementById("VWGDGVFROZENROWS_" + strDataID, objWindow);
                    if (objRowHeaderScroller)
                    {
                        // Get the row header's iScroll element.
                        var objRowHeaderIScroller = objRowHeaderScroller.iScrollElement;
                        if (!objRowHeaderIScroller)
                        {
                            // Create and preserve a new IScroll element for the row header.
                            objRowHeaderScroller.iScrollElement = objRowHeaderIScroller = new IScroll(objRowHeaderScroller, { scrollbars: false });
                        }

                        // Perform scrolling on the row header's iScroll element.
                        objRowHeaderIScroller.scrollTo(0, objDgvBodyIScrollElement.y, 0);
                    }
                }
            }
        }
    }
}
/// </method>

function DataGridView_DoSyncScrollers(objScrollingContainer, objSource, intType, strDir, strDimention)
{
    if (objScrollingContainer && objSource)
    {
        // Checks if source element has a vertical scroller.            
        if (objScrollingContainer.firstChild && objSource.firstChild)
        {
            // Check if both horizontal and veritcal scrollers are visible.
            if (Web_HasScrollY(objSource) && Web_HasScrollX(objSource))
            {
                // Increase column header's width element by 17 (the width of the scroller).
                objScrollingContainer.firstChild.style[strDimention.toLocaleLowerCase()] = (objSource.firstChild["client" + strDimention] + 17) + "px";
            }
            else
            {
                // Set column header's width to source's natural value.
                objScrollingContainer.firstChild.style[strDimention.toLocaleLowerCase()] = objSource.firstChild["client" + strDimention] + "px";
            }
        }

        // Horizontal synch of the column header's scroller element.
        Web_SyncScroll(objSource, objScrollingContainer, intType, strDir);
    }
}

/// <method name="DataGridView_SyncScrollers">
/// <summary>
///	
/// </summary>
function DataGridView_SyncScrollers(objWindow, objSource, strGuid, strDir)
{
    // Validate recieved arguments.
    if (objWindow && objSource && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strDir))
    {
        // Sync extended headers
        DataGridView_DoSyncScrollers(Web_GetElementById("XCH_" + strGuid, objWindow), objSource, 1, strDir, "Width");

        // Sync column headers
        DataGridView_DoSyncScrollers(Web_GetElementById("VWGDGVFROZENCOLUMNS_" + strGuid, objWindow), objSource, 1, strDir, "Width");

        // Sync row headers
        DataGridView_DoSyncScrollers(Web_GetElementById("VWGDGVFROZENROWS_" + strGuid, objWindow), objSource, 2, strDir, "Height");
    }
}
/// </method>

/// <method name="DataGridView_InvokeSetSelectionMode">
/// <summary>
///	
/// </summary>
function DataGridView_InvokeSetSelectionMode(strGridGuid, strSelectionMode)
{
    // Get grid node
    var objGridNode = Data_GetNode(strGridGuid);
    if (objGridNode)
    {
        // Set grid's selection mode.
        DataGridView_SetSelectionMode(objGridNode, strSelectionMode);
    }
}
/// </method>

/// <method name="DataGridView_SetSelectionMode">
/// <summary>
///	
/// </summary>
function DataGridView_SetSelectionMode(objGridNode, strSelectionMode)
{
    if (objGridNode && !Aux_IsNullOrEmpty(strSelectionMode))
    {
        Xml_SetAttribute(objGridNode, "Attr.SelectionMode", strSelectionMode);
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

/// <method name="DataGridView_AfterCreateTextBoxEvents">
/// <summary>
///	
/// </summary>
function DataGridView_AfterCreateTextBoxEvents(objWindow, objEvent, strSourceDataId, strEventType, strTargetDataId)
{
    if (strEventType == "ValueChange")
    {
        // Validate recieved arguments.
        if (!Aux_IsNullOrEmpty(strSourceDataId))
        {
            // Get DataGridView node.
            var objGridNode = Data_GetNode(Data_GetDataOwnerId(strSourceDataId));
            if (objGridNode)
            {
                // Fires the selection change event.
                DataGridView_FireSelectionChange(objGridNode, true, objEvent);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_BeginEdit">
/// <summary>
///	
/// </summary>
/// <param name="strGridDataId">The current grid data node</param>
/// <param name="strCellDataId">The current grid cell data node</param>
function DataGridView_BeginEdit(strGridDataId, strCellDataId)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGridDataId && strCellDataId))
    {
        // Get grid's hosting window.
        var objWindow = Forms_GetWindowByDataId(strGridDataId);
        if (objWindow)
        {
            // Get grid's and cell's nodes
            var objGridNode = Data_GetNode(strGridDataId);
            var objCellNode = Data_GetNode(strCellDataId);
            if (objGridNode && objCellNode)
            {
                DataGridView_ActivateCell(objWindow, objGridNode, objCellNode);

                // Redraw row header so that the edit icon will appear.
                DataGridView_UpdateRowHeaders(objWindow, objGridNode, objCellNode);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_AfterCreateComboBoxEvents">
/// <summary>
///	
/// </summary>
function DataGridView_AfterCreateComboBoxEvents(objWindow, objEvent, strSourceDataId, strEventType, strTargetDataId)
{
    if (strEventType == "ValueChange")
    {
        // Validate recieved arguments.
        if (!Aux_IsNullOrEmpty(strSourceDataId) && objWindow)
        {
            // Get DataGridView node.
            var objGridNode = Data_GetNode(Data_GetDataOwnerId(strSourceDataId));

            if (objGridNode)
            {
                // Garantee focus back to grid, for further navigation
                DataGridView_FocusDataGridViewTable(objWindow, objGridNode);
            }
        }
    }
}
/// </method>

/// <method name="DataGridView_OnBlur">
/// <summary>
/// Handle masked DataGridView blur event
/// </summary>
/// <param name="strGridDataId">The Grid data id.</param>
/// <param name="objEvent">The current event object.</param>
/// <param name="objWindow">The masked control window.</param>
function DataGridView_OnBlur(strGridDataId, objEvent, objWindow)
{
    // Get grid node
    var objGridNode = Data_GetNode(Data_GetDataOwnerId(strGridDataId));
    if (objGridNode)
    {
        // Get last selected node
        var objCurrentCellNode = DataGridView_GetCurrentCell(objGridNode);
        if (objCurrentCellNode && Xml_IsAttribute(objCurrentCellNode, "Attr.Active", "1"))
        {
            // If this cell supports edit mode
            if (Xml_IsAttribute(objCurrentCellNode, "Attr.SupportEditeMode", "1"))
            {
                // Get cell's focus element.
                var objFocusableElement = Controls_GetFocusElementByDataId(DataGridView_GetFullMemberID(objGridNode, objCurrentCellNode));
                if (objFocusableElement)
                {
                    // Triger the "blur" and "focusout" handlers of the textbox element.
                    $(objFocusableElement).triggerHandler("blur");
                    $(objFocusableElement).triggerHandler("focusout");
                }
            }
        }
    }
}
/// </method>