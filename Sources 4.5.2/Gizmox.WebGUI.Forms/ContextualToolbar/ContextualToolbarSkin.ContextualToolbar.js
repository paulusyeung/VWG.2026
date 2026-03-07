// Fires the event with the property required to change
function ContextualToolbar_ButtonClick(objButton, strProperty, strGuid)
{
    if (objButton && strProperty && strGuid)
    {      
        if (strGuid)
        {
            // Create event and raise 
            var objEvent = Events_CreateEvent(strGuid, "ContextualToolbarEditor", null, true);

            Events_SetEventAttribute(objEvent, "Attr.Argument", strProperty);

            Events_RaiseEvents();
        }
    }
};