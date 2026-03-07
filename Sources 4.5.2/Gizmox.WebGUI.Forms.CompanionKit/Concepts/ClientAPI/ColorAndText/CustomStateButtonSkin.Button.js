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

/// <method name="CustomStateButton_Click">
/// <summary>
///	Handles button's click
/// </summary>
function CustomStateButton_Click(strId) {
    //Getting instance of control 
    var objCustomButton = vwgContext.provider.getComponentById(strId);
    //Calling appropriate function
    objCustomButton.text() == "Active" ? CustomStateButton_ToggleActiveState(objCustomButton, true) : CustomStateButton_ToggleActiveState(objCustomButton, false);
}
/// </method>

/// <method name="CustomStateButton_ToggleActiveState">
/// <summary>
///	Changing text, background and foreground color according to "Active" state
/// </summary>
function CustomStateButton_ToggleActiveState(objButton, blnIsActive) {
    //If flag true - change text and color to according "Inactive" style
    if (blnIsActive) {
        objButton.text("Inactive");
        objButton.backColor("Red");
        objButton.foreColor("Black");
    }
    //If flag false - change text and color to according "Active" style
    else {
        objButton.text("Active");
        objButton.backColor("Green");
        objButton.foreColor("White");
    }
    //Updating control
    objButton.update();
}
/// </method>