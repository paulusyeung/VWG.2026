/// <page name="TrackBar.js">
/// <summary>
/// This script is used as a trackbar script.
/// </summary>

/// <method name="TrackBar_DragStart">
/// <summary>
/// 
/// </summary>
function TrackBar_DragStart(strGuid, objSource, objWindow, objEvent)
{
    if (Web_IsLeftClick(objEvent))
    {
        objSource.isDragging = true;

        objWindow.$(objWindow.document).on('mousemove', { source: objSource, guid: strGuid, window: objWindow }, TrackBar_OnMouseMove);

        objWindow.$(objWindow.document).on('mouseup', { source: objSource, guid: strGuid, window: objWindow }, TrackBar_OnMouseUp);
    }
}
/// </method>

/// <method name="TrackBar_OnMouseMove">
/// <summary>
/// 
/// </summary>
function TrackBar_OnMouseMove(objEvent)
{
    var objSource = objEvent.data.source;
    var strGuid = objEvent.data.guid;
    var objWindow = objEvent.data.window;
    if (objSource.isDragging == true)
    {
        var objKnobRect = Web_GetRect(objSource);
        var objTrackBarType = Web_GetDragType(objSource);
        var objTrackBarRect = Web_GetRect(Web_GetVwgElement(objSource));
        var objTail = objWindow.$("#tail_" + strGuid);

        if (objTrackBarType == mcntDragMoveVert)
        {
            var intPosition = objTrackBarRect.bottom - objEvent.pageY;

            if (intPosition >= 0 && intPosition + objSource.offsetHeight <= objTrackBarRect.bottom - objTrackBarRect.top)
            {
                objTail.css("height", intPosition);
            }
        }
        else
        {
            var intPosition = objEvent.pageX - objTrackBarRect.left;

            if (intPosition >= 0 && intPosition + objSource.offsetWidth <= objTrackBarRect.right - objTrackBarRect.left)
            {
                objTail.css("width", intPosition);
            }
        }
    }
}
/// </method>


/// <method name="TrackBar_OnMouseUp">
/// <summary>
/// 
/// </summary>
function TrackBar_OnMouseUp(objEvent)
{
    var objSource = objEvent.data.source;
    var strGuid = objEvent.data.guid;
    var objWindow = objEvent.data.window;
    if (objSource.isDragging)
    {
        objSource.isDragging = false;

        var objKnobRect = Web_GetRect(objSource);
        var objTrackBarType = Web_GetDragType(objSource); 
        var objTrackBarRect = Web_GetRect($$("knobContainer_" + strGuid));

        // Status variables
        var intRange = 0;
        var intOffset = 0;

        // Check drag mode.
        if (objTrackBarType == mcntDragMoveVert)
        {
            // Calculate range.
            intRange = (objTrackBarRect.bottom - objTrackBarRect.top);

            // Get offset from trackbar region
            intOffset = objKnobRect.top - objTrackBarRect.top;
        }
        else
        {
            // Calculate range.
            intRange = (objTrackBarRect.right - objTrackBarRect.left);

            // Get offset from trackbar region
            intOffset = objKnobRect.left - objTrackBarRect.left;
        }

        // In case of webkit browsers - increase the offset value by one in order to overcome the default 
        // lower-rounding that the brwoesr commits on caculated rectangles.
        if (mcntIsWebKit)
        {
            intOffset += 1;
        }

        // Calculate value.
        var intValue = Common_Round((intRange == 0 ? 0 : intOffset / intRange) * 100, 2);

        // Normalize value.
        if (intValue < 0)
        {
            intValue = 0;
        }
        else if (intValue > 100)
        {
            intValue = 100;
        }

        // Define a fixed value.
        var intFixedValue = intValue;

        // Set display value
        if (objTrackBarType == mcntDragMoveVert)
        {
            //In vertical orientation the value we save as the data behind and raise to the server
            //Is the complementary to 100;
            intFixedValue = (100 - intValue);
        }

        // Check if new value is different from local data.
        if (!Data_IsAttribute(strGuid, "Attr.Value", intFixedValue))
        {
            // Update local data.
            Data_SetAttribute(strGuid, "Attr.Value", intFixedValue);

            // Create server event
            var objServerEvent = Events_CreateEvent(strGuid, "ValueChange", null, true);
            Events_SetEventAttribute(objServerEvent, "Attr.Value", intFixedValue);

            // Check if event is critical.
            if (Data_IsCriticalEvent(strGuid, "Event.ValueChange"))
            {
                // Raise events.
                Events_RaiseEvents();
            }

            Events_ProcessClientEvent(objServerEvent);
        }

        //removing the events
        objWindow.$(objWindow.document).off('mousemove', TrackBar_OnMouseMove);

        objWindow.$(objWindow.document).off('mouseup', TrackBar_OnMouseUp);
    }

}
/// </method>