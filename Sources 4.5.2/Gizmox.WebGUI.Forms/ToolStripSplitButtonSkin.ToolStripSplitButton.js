/// <method name="ToolStripSplitButton_DropDownClick">
/// <summary>
/// 
/// </summary>
function ToolStripSplitButton_DropDownClick(objThis, objEvent)
{
    var objVwgElement = Web_GetVwgElement(objThis, true);
    
    if (objVwgElement != null)
    {
        var strID = Data_GetDataId(objVwgElement.id);

        // The "DropDown" event also raises the click on the server so we check if click is also critical
        var blnIsCritical = Data_IsCriticalEvent(strID, "Event.Click") || Data_IsCriticalEvent(strID, "Event.Expand");

        if (blnIsCritical)
        {
            Events_CreateEvent(strID, "DropDown");

            Events_RaiseEvents();

            // Don't want the main Web_OnClick to execute
            Web_EventCancelBubble(objEvent);
        }
    }
}
/// </method>
