

/// <method name="RadioButton_Click">
/// <summary>
///Handles radiobutton click event.
/// </summary>
/// <param name="strGuid">The radio button guid.</param>
/// <param name="objWindow">The radio button window.</param>
function RadioButton_Click(strGuid, objWindow)
{
    RadioButton_Change(strGuid, objWindow);
}
/// </method>

/// <method name="RadioButton_TouchEnd">
/// <summary>
/// Handles radiobutton touch event.
/// </summary>
/// <param name="strGuid">The radio button guid.</param>
/// <param name="objWindow">The radio button window.</param>
function RadioButton_TouchEnd(strGuid, objWindow)
{
	RadioButton_Change(strGuid, objWindow);
}
/// </method>


/// <method name="RadioButton_Change">
/// <summary>
///
/// </summary>
/// <param name="strGuid">The radio button guid.</param>
function RadioButton_Change(strDataId, objWindow)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strDataId) && objWindow)
    {
        // Get radio button node
	    var objRadioButtonNode = Data_GetNode(strDataId);
	    if(objRadioButtonNode)
	    {
	        // Validate that radio button is allready checked.
	        if(!Xml_IsAttribute(objRadioButtonNode,"Attr.Checked","1"))
	        {
		        // Get parent node
		        var objParentNode = objRadioButtonNode.parentNode;
		        if(objParentNode)
		        {
		            // Define a flag that will indicate if events should be raised.
		            var blnRaiseEvents = false;
		            
		            // Try get a node of a radio button which is currently checked.
		            var objCheckedRadioButtonNode = Xml_SelectSingleNode("WC:Tags.RadioButton[@Attr.Checked='1']", objParentNode);
		            if(objCheckedRadioButtonNode)
		            {   
		                // Get checked radio button id.
		    	        var strCheckedRadioButtonId = Xml_GetAttribute(objCheckedRadioButtonNode, "Attr.Id");
		    	        
		                // Check if value change is critical for the checked radio button.
		    	        blnRaiseEvents = blnRaiseEvents || Data_IsCriticalEvent(strCheckedRadioButtonId, "Event.ValueChange");
                        
	                    // Uncheck the checked radio button.
                        Xml_SetAttribute(objCheckedRadioButtonNode, "Attr.Checked", "0");
                        
                        // Redraw the checked radio button.
                        Controls_RedrawControlByNode(objWindow,objCheckedRadioButtonNode,false);
		            }
		            
		            // Check if value change is critical for the handled radio button.
		            blnRaiseEvents = blnRaiseEvents || Data_IsCriticalEvent(strDataId, "Event.ValueChange");
                    
                    // Check the handled radio button.
                    Xml_SetAttribute(objRadioButtonNode, "Attr.Checked", "1");
                    
                    if (mcntIsObsoleteIE)
                    {
                        // Redraw the control in delay so the infrastructure will handle the mousedown/mouseclick events 
                        // If we don't delay it, the elements are separated from the DOM and the events do not bubble to the body handlers
                        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Controls_RedrawControlByNode, objWindow, objRadioButtonNode), 10);
                    }
                    else
                    {
                        // Redraw the handled radio button.
                        Controls_RedrawControlByNode(objWindow, objRadioButtonNode, false);
                    }
                    
                    // Set the focus back to the redrawn radio button element.
                    Web_SetFocusByDataId(strDataId,true);
		            
		            // Create event and raise if critical
                    var objEvent = Events_CreateEvent(strDataId, "ValueChange", null, true);                    
            	    
                    // Raise events if critical
                    if(blnRaiseEvents) 
                    {
                        Events_RaiseEvents();
                    }

                    Events_ProcessClientEvent(objEvent);    
		        }   
            }
	    }
	}
}
/// </method>

/// <method name="RadioButton_Click">
/// <summary>
///
/// </summary>
/// <param name="strGuid">The radio button guid.</param>
/// <param name="objWindow">The radio button window.</param>
/// <param name="objEvent">The event object.</param>
function RadioButton_KeyDown(strGuid, objWindow, objEvent)
{
    // Get the pressed key	
	var intKeyCode =  Web_GetEventKeyCode(objEvent);
	
	//When space/Enter key was pressed
	if(intKeyCode == mcntSpaceKey || intKeyCode == mcntEnterKey )
	{		
        RadioButton_Change(strGuid, objWindow);
    }
}
/// </method>

/// <summary>
/// Functions to be executed upon user's pressed arrows keys to navigate to current control
/// </summary>
/// <param name="strTargetDataId">The control's Node Data Id</param>
/// <param name="objTargetElement">Element to which navigation key was target</param>
/// <param name="intKeyCode">The pressed key code</param>
function RadioButton_AfterNavigationKeyDown(strDataId, intKeyCode, objWindow) 
{
   
    if (Web_IsArrowKey(intKeyCode))
    {
        //Upon complete move focus to current control due to arrow key press, set radio button as Checked
        RadioButton_Change(strDataId, objWindow);
    }
}
