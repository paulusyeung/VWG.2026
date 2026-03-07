/// <page name="TrackBar.js">
/// <summary>
/// This script is used as a native trackbar.
/// </summary>


/// <summary>
/// Native trackbar asynchronic raise event timer
/// </summary>
var mintNativeTrackBarTimer = 0;

/// <method name="NativeTrackBar_OnChange">
/// <summary>
/// 
/// </summary>
function NativeTrackBar_OnChange(strGuid, objInput, objEvent, objWindow)
{
    // Clear previous navigation
    Web_ClearTimeout(mintNativeTrackBarTimer);

    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        var varRange = parseInt(objInput.max) - parseInt(objInput.min);
        var varValue = 100*((objInput.value - parseInt(objInput.min)) / varRange);

        // Check if new value is different from local data.
        if (!Data_IsNodeAttribute(objNode, "Attr.Value", varValue))
        {
            // Update local data.
            Data_SetNodeAttribute(objNode, "Attr.Value", varValue);

            // Create server event
            var objServerEvent = Events_CreateEvent(strGuid, "ValueChange", null, true);
            Events_SetEventAttribute(objServerEvent, "Attr.Value", varValue);

            // Check if event is critical.
            if (Data_IsCriticalEvent(strGuid, "Event.ValueChange"))
            {
                // Raise events with timer.
                mintNativeTrackBarTimer = Web_SetTimeout("mobjApp.Events_RaiseEvents()", 100, objWindow);
            }

            Events_ProcessClientEvent(objServerEvent);
        }
    }
}
/// </method>