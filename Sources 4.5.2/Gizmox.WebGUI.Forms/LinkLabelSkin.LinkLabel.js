/// <method name="LinkLabel_KeyDown">
/// <summary>
/// Handle the LinkLable KeyDown event.
/// </summary>
/// <param name="strGuid">The LinkLable guid.</param>
/// <param name="objWindow">the window from which the event is fired.</param>
/// <param name="objElement">the event</param>
function LinkLabel_KeyDown(strGuid, objWindow, objEvent) 
{
    // Get the pressed key code.
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // LinkLabel Enter or Space pressed.
    if (intKeyCode == mcntSpaceKey || intKeyCode == mcntEnterKey)
    {
        // Get source element.
        var objLinkLabelElement = Web_GetElementByDataId(strGuid, objWindow);
        if (objLinkLabelElement) 
        {
            // Get the relative point
            var objRelativePoint = Web_GetRelativePoint(objLinkLabelElement, Web_PointFromEvent(objEvent));

            // Raise the click event
            Events_Click(objWindow, objEvent, strGuid, false, false, objRelativePoint.left, objRelativePoint.top, false);

            // Check if click it critical.
            if (Data_IsCriticalEvent(strGuid, "Event.Click"))
            {
                Web_OnKeyDown(objEvent, objWindow, true);
            }

            // Get the URL value.
            var strURL = Data_GetAttribute(strGuid, "Attr.Value", "");
            
            // If ClientMode == true
            if (!Aux_IsNullOrEmpty(strURL)) 
            {
                //If shift is also pressed
                if (Web_IsShift(objEvent)) 
                {
                    // Open in new window/tab (browser dependent)
                    objWindow.open(strURL);
                }
                else 
                {
                    //Open link in same window
                    Web_SetMainWindowLocation(strURL);
                }
            }      
        }
    }
}

/// </method>