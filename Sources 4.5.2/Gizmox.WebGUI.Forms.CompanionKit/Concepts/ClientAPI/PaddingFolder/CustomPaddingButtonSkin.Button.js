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

/// <method name="CustomPaddingButton_ChangePadding">
/// <summary>
///	Changes control's padding
/// </summary>
function CustomPaddingButton_ChangePadding(objEventArgs, strId, blnIncrease) {
    //Getting button's instance
    var objButton = vwgContext.provider.getComponentById(strId);
    //Getting padding value (all)
    var intPaddingAll = parseInt(objButton.padding().all, 10);

    //Defines which mouse button was pressed
    //If left - increase padding on 5
    if (blnIncrease && intPaddingAll < 20) {
        intPaddingAll += 5;
        objButton.padding({ "all": intPaddingAll });
    }
    //If right - decrease padding on 5
    else if (!blnIncrease && intPaddingAll >= 0) {
        intPaddingAll -= 5;
        objButton.padding({ "all": intPaddingAll });
    }
  
    //Update control
    objButton.update();
}
/// </method>