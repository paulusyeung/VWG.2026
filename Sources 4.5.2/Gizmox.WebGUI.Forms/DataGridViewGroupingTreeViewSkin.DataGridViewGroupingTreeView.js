/// <method name="DataGridView_ClearFilters">
/// <summary>
///	Handles "close group" action.
/// </summary>
function DataGridViewGroupingTreeView_CloseGroup(strGridId, strColumnName, objEvent, objWindow)
{
	// Create CloseGroup event.
	var objCloseGroupEvent = Events_CreateEvent(strGridId, "CloseGroup", strGridId, true, false);
	
	// Add column headers attribute.
	Events_SetEventAttribute(objCloseGroupEvent, "Attr.Name", strColumnName, false);

	Web_OnClick(objEvent, objWindow, true);

}
/// </method>