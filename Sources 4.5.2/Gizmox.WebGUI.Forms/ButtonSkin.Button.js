/// <method name="Button_KeyPress">
/// <summary>
///	
/// </summary>
function Button_KeyPress(strDataId,objElement,objEvent)
{
    // Get the pressed key
    var intKeyCode =  Web_GetEventKeyCode(objEvent);
    
    // Check if enter or Spacebar was pressed.    
    if (intKeyCode==mcntEnterKey || intKeyCode==mcntSpaceKey)
    {
        // Check if source element has connected popup element - otherwise hide main popup box.
        if(!Popups_ShareFocusWithExistPopup(strDataId))
        {
            Popups_HidePopups(objElement);
        }
	    
	    // Get button node.
	    var objButtonNode = Data_GetNode(strDataId);
	    if(objButtonNode)
	    {
	        // Try execute client action.
            if(!Web_ExecuteClientInvocation(objButtonNode))
            {
                //raise the click event 
                Events_Click(null, objEvent, strDataId, Data_IsCriticalEvent(strDataId, "Event.Click"));
            }
        }
    }
}
/// </method>