/// <summary>
/// Current datetime attribute name.
/// </summary>
var mcntCurrentDateTimeAttribute = ("vwg_currentdatetime");

/// <method name="DateTimePicker_GetTokenEnums">
/// <summary>
/// Gets the values of a given format 
/// </summary>
/// <param name="strTokenFormat"></param>
function DateTimePicker_GetTokenEnums(strTokenFormat)
{
    // Get field values array
    switch(strTokenFormat)
    {
        case "t":
            return marrShortTimeParts;
        case "tt":
            return marrTimeParts;
        case "MMM":
            return marrShortMonths;
        case "MMMM":
            return marrGenitiveMonths;
        case "ddd":
            return marrShortDaysOfWeek;
        case "dddd":         
            return marrDaysOfWeek;
    }
    
    return null;
}
/// </method>

/// <method name="DateTimePicker_GetDataDateTimeValue">
/// <summary>
///  
/// </summary>
function DateTimePicker_GetDataDateTimeValue(strGuid)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Get the current meta data datetime value.
        var strDataValue = DateTimePicker_GetDataDateTimeTicks(strGuid);
        if(!Aux_IsNullOrEmpty(strDataValue))
        {
            // Try parsing ticks data into a data object.
            return Web_GetDateFromTicks(parseFloat(strDataValue));
        }
    }
    return null;
}
/// </method>

/// <method name="DateTimePicker_GetDataDateTimeTicks">
/// <summary>
///  
/// </summary>
function DateTimePicker_GetDataDateTimeTicks(strGuid)
{
    // Define an empty data date time ticks.
    var strDateTimeTicks = "";
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Get data node
        var objNode = Data_GetNode(strGuid);

        // Get current datetime value.
        strDateTimeTicks = Data_GetNodeAttribute(objNode, mcntCurrentDateTimeAttribute, "");
        if(Aux_IsNullOrEmpty(strDateTimeTicks))
        {
            // In case of a null current datetime value, get meta data datetime value.
            strDateTimeTicks = Data_GetNodeAttribute(objNode, "Attr.DateTime", "");
        }
	}	
	
    // Rteurn the data date time ticks.
	return strDateTimeTicks;
}
/// </method>

/// <method name="DateTimePicker_GetDataMaxDateTimeTicks">
/// <summary>
///  
/// </summary>
function DateTimePicker_GetDataMaxDateTimeTicks(strGuid)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        return Data_GetAttribute(strGuid,"Attr.MaxDate","");
	}	
	return "";
}
/// </method>

/// <method name="DateTimePicker_GetDataMinDateTimeTicks">
/// <summary>
///  
/// </summary>
function DateTimePicker_GetDataMinDateTimeTicks(strGuid)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        return Data_GetAttribute(strGuid,"Attr.MinDate","");
	}	
	return "";
}
/// </method>

/// <method name="DateTimePicker_SetDateTimeDataValue">
/// <summary>
///  
/// </summary>
function DateTimePicker_SetDateTimeDataValue(strGuid,strDateTimeValue)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strDateTimeValue))
    {
        Data_SetAttribute(strGuid,mcntCurrentDateTimeAttribute,strDateTimeValue);
	}
}
/// </method>

/// <method name="DateTimePicker_FireValueChange">
/// <summary>
///  
/// </summary>
function DateTimePicker_FireValueChange(strGuid)
{
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Get the current date time value.
        var strDateTimeTicks = DateTimePicker_GetDataDateTimeTicks(strGuid);
        if(!Aux_IsNullOrEmpty(strDateTimeTicks))
        {
            // Update meta data date time value.
            Data_SetAttribute(strGuid,"Attr.DateTime",strDateTimeTicks);

            // Fire the value change event.
            Events_ValueChange(strGuid, strDateTimeTicks, Data_IsCriticalEvent(strGuid, "Event.ValueChange"));
        }
	}
}
/// </method>

/// <method name="DateTimePicker_SetActiveTokenDigitPressed">
/// <summary>
///  
/// </summary>
function DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,strDigitPressed)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strDigitPressed))
    {
        // Get the date time picker element.  
        var objDateTimePickerElement = Web_GetElementByDataId(strGuid,objWindow);
        if(objDateTimePickerElement)
        {
            // Set the date time picker's active token digit pressed.            
            Web_SetAttribute(objDateTimePickerElement,"vwg_DigitPressed",strDigitPressed);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_GetActiveTokenDigitPressed">
/// <summary>
///  
/// </summary>
function DateTimePicker_GetActiveTokenDigitPressed(objWindow,strGuid)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid))
    {
        // Get the date time picker element.  
        var objDateTimePickerElement = Web_GetElementByDataId(strGuid,objWindow);
        if(objDateTimePickerElement)
        {
            // Get the date time picker's active token digit pressed.
            return Web_GetAttribute(objDateTimePickerElement,"vwg_DigitPressed",true);
        }
    }
    return "";
}
/// </method>

/// <method name="DateTimePicker_OnFocus">
/// <summary>
/// Manage date picker focus event 
/// </summary>
function DateTimePicker_OnFocus(strDateTimePickerGuid,strPosition,objInput,objWindow)
{   
    // Get the child node.
    var objNode = DateTimePicker_GetChildNode(strDateTimePickerGuid,parseInt(strPosition,10)-1);
    if(objNode)
    {     
        // Check if child is a literal or is read only.
        if(objNode.tagName=="Tags.Literal" || Xml_IsAttribute(objNode,"Attr.ReadOnly","1"))
        {
            if(mcntIsWebKit)
            {
                // Navigate to next token asynchronicly.      
                Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(DateTimePicker_ExecuteTokenNavigation,objWindow,strDateTimePickerGuid,strPosition,true),10);
            }
            else
            {
                // Navigate to next token.      
                DateTimePicker_ExecuteTokenNavigation(objWindow,strDateTimePickerGuid,strPosition,true);
            }
        }
        else
        {
            // Set active token index on the picker element.
            DateTimePicker_SetActiveTokenPosition(objWindow,strDateTimePickerGuid,strPosition);

            // Set the focus to the active token
            DateTimePicker_SetActiveTokenFocusIndicator(objWindow, objInput, strDateTimePickerGuid);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_OnCheckBoxFocus">
/// <summary>
/// 
/// </summary>
function DateTimePicker_OnCheckBoxFocus(objElement, strType, objWindow, objEvent)
{
    // Set checkbox style
    Web_SetStyle(objElement, strType, objWindow, objEvent);

    if (objElement)
    {
        // Get DateTimePicker element
        var objVwgElement = Web_GetVwgElement(objElement);

        if (objVwgElement)
        {
            // Set the active input
            DateTimePicker_SetActiveTokenFocusIndicator(objWindow, objElement, Data_GetDataId(objVwgElement.id));
        }
    }
}
/// </method>

/// <method name="DateTimePicker_SetActiveTokenFocusIndicator">
/// <summary>
/// 
/// </summary>
function DateTimePicker_SetActiveTokenFocusIndicator(objWindow, objFocusingElement, strDateTimePickerGuid)
{
    // Get the current focused element
    var objFocusedElement = Controls_GetFocusElementByDataId(strDateTimePickerGuid);

    // Remove focus from the previous element
    Web_SetAttribute(objFocusedElement, "vwgfocuselement", "0");

    // Set focus to the current element
    Web_SetAttribute(objFocusingElement, "vwgfocuselement", "1");
}
/// </method>

/// <method name="DateTimePicker_OnMouseup">
/// <summary>
/// 
/// </summary>
function DateTimePicker_OnMouseup(objEvent)
{        
	//When onfocus select text in chrome the defualt behavoiur should be canceled.
	if(mcntIsWebKit)
    {
    	Web_EventCancelBubble(objEvent,true,false);
	}                                    
}
/// </method>

/// <method name="DateTimePicker_SetTokenSelection">
/// <summary>
/// 
/// </summary>
function DateTimePicker_SetTokenSelection(objInput)
{
	// Select full text with 5 millisecond delay.
    Web_SetInputSelection(objInput,5);	
}
/// </method>

/// <method name="DateTimePicker_SetActiveTokenPosition">
/// <summary>
///  
/// </summary>
function DateTimePicker_SetActiveTokenPosition(objWindow,strGuid,strTokenPosition)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    {
        // Get the date time picker element.  
        var objDateTimePickerElement = Web_GetElementByDataId(strGuid,objWindow);
        if(objDateTimePickerElement)
        {
            // Set the date time picker's active token index.            
            Web_SetAttribute(objDateTimePickerElement,"vwg_ActiveToken",strTokenPosition);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_GetActiveTokenPosition">
/// <summary>
///  
/// </summary>
function DateTimePicker_GetActiveTokenPosition(objWindow,strGuid)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid))
    {
        // Get the date time picker element.  
        var objDateTimePickerElement = Web_GetElementByDataId(strGuid,objWindow);
        if(objDateTimePickerElement)
        {
            // Get the date time picker's active token index.            
            return Web_GetAttribute(objDateTimePickerElement,"vwg_ActiveToken",true);
        }
    }
    return "";
}
/// </method>

/// <method name="DateTimePicker_CheckChange">
/// <summary>
/// Manage CheckedChange event - enable/disable
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objElement"></param>
function DateTimePicker_CheckChange(objWindow,strGuid,objElement)
{
    // Validate recieved arguments.
    if(objWindow && !Data_IsDisabled(strGuid)) 
    {
        var blnChecked = Data_IsAttribute(strGuid,"Attr.Checked","1");
        
	    // Update data behind
	    Data_SetAttribute(strGuid,"Attr.Checked",blnChecked?"0":"1");

        // Redraw control.	
        Controls_RedrawControlById(objWindow,strGuid);
	    
	    // Returning the focus to checkbox after reseting control's HTML
	    Controls_Focus(strGuid,true);
	    
	    // Fire the checked change event.
        DateTimePicker_FireCheckedChange(strGuid,!blnChecked);
	}
}
/// </method>

/// <method name="DateTimePicker_FireCheckedChange">
/// <summary>
/// 
/// </summary>
function DateTimePicker_FireCheckedChange(strGuid,blnChecked)
{
    if(!Data_IsDisabled(strGuid)) 
    {
        // Create a check change event
    	var objEvent = Events_CreateEvent(strGuid, "CheckedChange", null, true); 
	    
	    // Set the value.
	    Events_SetEventAttribute(objEvent, "Value", blnChecked ? "true" : "false");	   
	    
	    // Check if event is critical.
	    if (Data_IsCriticalEvent(strGuid, "Event.CheckedChange"))
	    {
	        // Raise events.
	        Events_RaiseEvents();
	    }

	    Events_ProcessClientEvent(objEvent);
	}
}
/// </method>


/// <method name="DateTimePicker_DropDownIconMouseDown">
/// <summary>
/// 
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
function DateTimePicker_DropDownIconMouseDown(strGuid,objWindow,objEvent)
{
    // Check if left click.
    if (Web_IsLeftClick(objEvent))
    {
        DateTimePicker_Browse(strGuid,objWindow,objEvent);
    }
}
/// </method>


/// <method name="DateTimePicker_HandleDropDownIconMouseEvents">
/// <summary>
/// 
/// </summary>
function DateTimePicker_HandleDropDownIconMouseEvents(objElement, strType, objWindow, objEvent)
{
    Web_SetStyle(objElement, strType, objWindow, objEvent);

    // In case od miouse down.
    if (strType == "mousedown")
    {
        // Validate recieved element.
        if (objElement)
        {
            // Get VWG source.
            var objVwgSource = Web_GetVwgElement(objElement);
            if (objVwgSource)
            {
                // Perform DropDown action
                DateTimePicker_DropDownIconMouseDown(Data_GetDataId(objVwgSource.id), objWindow, objEvent);
            }
        }
    }    
}
/// </method>

/// <method name="DateTimePicker_Browse">
/// <summary>
/// Raise the browse event which will open the date picker dialog
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
function DateTimePicker_Browse(strGuid,objWindow,objEvent)
{
    
    // Check if control is not disabled.
    if(!Data_IsDisabled(strGuid))
    {
	    if(!Popups_GetPopup("vwg_ControlId",strGuid))
        {
	        // If date is blank, set to current date before showing dropdown
	        DateTimePicker_setNowOnClick(strGuid, objWindow, objEvent);

	        // Check if this control is in focus.
            if(Focus_GetFocusElementDataId()==strGuid)
            {
                // Handle token blur validation.
                DateTimePicker_HandleTokenBlurValidation(strGuid,DateTimePicker_GetActiveTokenPosition(objWindow,strGuid),objWindow);
            }

            // Create a browse event.
            var objEvent = Events_CreateEvent(strGuid,"Browse");
            
            // Raise events.
            Events_RaiseEvents();

            Events_ProcessClientEvent(objEvent);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_setNowOnClick">
/// <summary>
/// On Browse on a DateTimePicker with a blank date, replace date with current date and then select.
/// </summary>
/// <param name="strGuid">VWG ID of control being clicked</param>
/// <param name="objWindow">Current window object</param>
/// <param name="objEvent">The event object for mousedown event</param>

function DateTimePicker_setNowOnClick(strGuid, objWindow, objEvent) {
    if (!Aux_IsNullOrEmpty(strGuid)) {
        var objNode = Web_GetElementByDataId(strGuid);

        var intEmptyYear = parseInt(Data_GetAttribute(strGuid, "Attr.EmptyDateYear", "0"));
        var strCurrent = Data_GetAttribute(strGuid, "Attr.DateTime");
        var strYear = DateTimePicker_GetDataDateTimeValue(strGuid).getFullYear();

        if (Aux_IsNullOrEmpty(strCurrent) || parseInt(strYear) <= intEmptyYear) {
            var strNowValue = Web_GetTicksFromDate(new Date());
            DateTimePicker_SetDateTimeDataValue(strGuid, strNowValue);

            // Data_SetAttribute(strGuid, "Attr.DateTimeEmpty", 0);
            DateTimePicker_ResetTokensFromData(objWindow, strGuid, "");

            // Fire value change event.
            DateTimePicker_FireValueChange(strGuid);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_GetYearTokenValidatedValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetYearTokenValidatedValue(strGuid,strTokenPosition,objWindow)
{   
    var intYearTokenValidatedValue = -1;
    
    // Validate recieved arguments.
    if  (!Aux_IsNullOrEmpty(strGuid) && !isNaN(strTokenPosition) && objWindow)
    {
        // Get token input value.
        var strTokenInputValue = DateTimePicker_GetTokenInputValue(objWindow,strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenInputValue))
        {   
            // Parser token input's numeric value.
            var intTokenInputValue = parseInt(strTokenInputValue,10);
            if(!isNaN(intTokenInputValue))
            {
                // In case of one digit year.
                if(strTokenInputValue.length==1)
                {
                    intYearTokenValidatedValue=(2000+intTokenInputValue);
                }
                // In case of two digits year.                
                else if(strTokenInputValue.length==2)
                {
                    intYearTokenValidatedValue=(intTokenInputValue+(intTokenInputValue>=30?1900:2000));
                }
            }
        }
    }
    
    return intYearTokenValidatedValue;
}
/// </method>

/// <method name="DateTimePicker_HandleTokenBlurValidation">
/// <summary>
/// 
/// </summary>
function DateTimePicker_HandleTokenBlurValidation(strGuid,strTokenPosition,objWindow)
{   
    // Validate recieved arguments.
    if  (!Aux_IsNullOrEmpty(strGuid) && !isNaN(strTokenPosition) && objWindow)
    {
        // Get the handled token's format and check its validation length.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat) && DateTimePicker_GetTokenValidationLength(strTokenFormat)>0)
        {            
            // Define token's numeric value.
            var intCalculatedValue = -1;
            
            // Switch token format.
            switch(strTokenFormat)
            {
                case "y":
                case "yy":
                case "yyyy":
                    // Get calculated value for a year.
                    intCalculatedValue=DateTimePicker_GetYearTokenValidatedValue(strGuid,strTokenPosition,objWindow);
                    break;
            }
            
            if(intCalculatedValue>=0)
            {
                // Try updating datetime value.
                DateTimePicker_UpdatedDateTimeValue(objWindow,strGuid,strTokenPosition,intCalculatedValue);
            }
            else
            {
                // Restores token's data value.
                DateTimePicker_RestoreTokenValue(objWindow,strGuid,strTokenPosition,false);
                
                // Initialize the digit pressed attribute.
                DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,"0");
            }
        }
        
        // Check that dataa value has changed.
        if(DateTimePicker_IsDataValueChanged(strGuid))
        {
            // Fire value change event.
            DateTimePicker_FireValueChange(strGuid);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_OnTokenBlur">
/// <summary>
/// Handles the onblur event
/// </summary>
function DateTimePicker_OnTokenBlur(strGuid,strTokenPosition,objInput,objWindow)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && objWindow)
    {   
    	// Handle token blur validation.
	    DateTimePicker_HandleTokenBlurValidation(strGuid,strTokenPosition,objWindow);
    }
}
/// </method>

/// <method name="DateTimePicker_UpdatedDateTimeValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_UpdatedDateTimeValue(objWindow,strGuid,strTokenPosition,intTokenValue)
{ 
    var intChangeType = 0;
    
    // Validate recieved arguments.
    if  (objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && 
        !isNaN(intTokenValue) && intTokenValue>=0)
    {       
        // Get the handled token's format.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat))
        {      
            // Get current datetime object.
            var objDateTimeValue = DateTimePicker_GetDataDateTimeValue(strGuid);
            if(objDateTimeValue)
            {
                // Set the date object value.
                switch(strTokenFormat)
                {
                    case "d":
                    case "dd":
                    case "ddd":
                    case "dddd":    
                        if(intTokenValue!=objDateTimeValue.getDate())
                        {
                            objDateTimeValue.setDate(intTokenValue);
                            intChangeType=1;
                        }
                        break;
                    case "h":
                    case "hh":
                    case "H":
                    case "HH":
                        if(intTokenValue!=objDateTimeValue.getHours())
                        {
                            objDateTimeValue.setHours(intTokenValue);
                            intChangeType=1;
                        }
                        break;
                    case "m":
                    case "mm":
                        if(intTokenValue!=objDateTimeValue.getMinutes())
                        {
                            objDateTimeValue.setMinutes(intTokenValue);                                                                
                            intChangeType=1;
                        }
                        break;
                    case "M":
                    case "MM":
                    case "MMM":
                    case "MMMM":        
                        if(intTokenValue!=objDateTimeValue.getMonth())
                        {
                            // Get current day in the month.
                            var intDay = objDateTimeValue.getDate();
                            
                            // Get current year.
                            var intYear = objDateTimeValue.getFullYear();
                            
                            // Get the number of days in the new month.
                            var intNumberOfDaysInMonth = DateTimePicker_GetNumberOfDaysInMonth(intTokenValue,intYear);
                            
                            // Check if the new month has less days then the current month.
                            if(intDay>intNumberOfDaysInMonth)
                            {
                                // Set current day to the number of days in the new month.
                                objDateTimeValue.setDate(intNumberOfDaysInMonth);
                            }
                            
                            // Set the new month value.
                            objDateTimeValue.setMonth(intTokenValue);                                    
                            
                            intChangeType=1;
                        }
                        break;
                    case "s":
                    case "ss":
                        if(intTokenValue!=objDateTimeValue.getSeconds())
                        {
                            objDateTimeValue.setSeconds(intTokenValue);
                            intChangeType=1;
                        }
                        break;
                    case "t":
                    case "tt":
                        // Get current hour.
                        var intHour = objDateTimeValue.getHours();
                        
                        if(intHour>11 && intTokenValue==0)
                        {
                            objDateTimeValue.setHours(intHour-12);       
                            intChangeType=1;
                        }
                        else if(intHour<12 && intTokenValue==1)
                        {
                            objDateTimeValue.setHours(intHour+12);               
                            intChangeType=1;                                                         
                        }
                        break;
                    case "y":
                    case "yy":
                    case "yyyy":
                        if(intTokenValue!=objDateTimeValue.getFullYear())
                        {
                            // Get current day in the month.
                            var intDay = objDateTimeValue.getDate();
                            
                            // Get current month.
                            var intMonth = objDateTimeValue.getMonth();
                            
                            // Get the number of days in the new year.
                            var intNumberOfDaysInMonth = DateTimePicker_GetNumberOfDaysInMonth(intMonth,intTokenValue);
                            
                            // Check if the new month has less days then the current month.
                            if(intDay>intNumberOfDaysInMonth)
                            {
                                // Set current day to the number of days in the new year.
                                objDateTimeValue.setDate(intNumberOfDaysInMonth);
                            }
                            
                            // Set full year.
                            objDateTimeValue.setFullYear(intTokenValue);
                            
                            intChangeType=1;
                        }
                        break;                            
                }
                
                if(intChangeType!=0)
                {
                    // Get the updated datetime ticks.
                    var lngUpdatedDateTimeTicks = Web_GetTicksFromDate(objDateTimeValue);
                                       
                    // Get minimal datetime ticks.
                    var lngMinDateTimeTicks = parseFloat(DateTimePicker_GetDataMinDateTimeTicks(strGuid));
                    
                    // Get maximal datetime ticks.
                    var lngMaxDateTimeTicks = parseFloat(DateTimePicker_GetDataMaxDateTimeTicks(strGuid));
                                       
                    // Check if updated value exceeded maxmium value.
                    if(!isNaN(lngMaxDateTimeTicks) && lngUpdatedDateTimeTicks>lngMaxDateTimeTicks)
                    {
                        lngUpdatedDateTimeTicks=lngMaxDateTimeTicks;
                        intChangeType=2;
                    }
                    
                    // Check if updated value exceeded minimum value.                       
                    if(!isNaN(lngMinDateTimeTicks) && lngUpdatedDateTimeTicks<lngMinDateTimeTicks)
                    {
                        lngUpdatedDateTimeTicks=lngMinDateTimeTicks;
                        intChangeType=2;
                    }
                    
                    // Update the datetime data's value.
                    DateTimePicker_SetDateTimeDataValue(strGuid,String(lngUpdatedDateTimeTicks));
                    
                    // Check change type.
                    if(intChangeType==1)
                    {
                        // Set token's display value.
                        DateTimePicker_SetTokenDisplayValue(objWindow,strGuid,strTokenPosition,intTokenValue,true,true);
                    }
                    else if(intChangeType==2)
                    {
                        // Reset all token values from data.
                        DateTimePicker_ResetTokensFromData(objWindow,strGuid,strTokenPosition);
                    }
                }
            }
        }
    }
    
    // Return a result structure.
    return intChangeType;
}
/// </method>


/// <method name="DateTimePicker_ResetTokensFromData">
/// <summary>
/// 
/// </summary>
function DateTimePicker_ResetTokensFromData(objWindow,strGuid,strSelectedTokenPosition)
{  
    // Validate recieved arguments.    
    if(objWindow && !Aux_IsNullOrEmpty(strGuid))
    {
        // Get current datetime object.
        var objDateTimeValue = DateTimePicker_GetDataDateTimeValue(strGuid);
        if(objDateTimeValue)
        {
            // Get the date time picker node.
            var objDateTimePickerNode = Data_GetNode(strGuid);
            if(objDateTimePickerNode && objDateTimePickerNode.childNodes.length>0)
            {
                // Loop all childs.
                for(var intChild=0; intChild<objDateTimePickerNode.childNodes.length; intChild++)
                {
                    // Get current child node.
                    var objChildNode = objDateTimePickerNode.childNodes[intChild];
                    
                    // Cehck if current child is a token.
                    if(objChildNode && objChildNode.tagName=="Tags.Token")
                    {
                        // Get current token position.
                        var strCurrentTokenPosition = String(intChild+1);
                        
                        // Get the handled token's format.
                        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strCurrentTokenPosition);
                        if(!Aux_IsNullOrEmpty(strTokenFormat))
                        {
                            var intTokenNumericValue = DateTimePicker_GetTokenNumericValue(strTokenFormat,objDateTimeValue);
                            if(intTokenNumericValue >= 0)
                            {
                                // Set token's display value.
                                DateTimePicker_SetTokenDisplayValue(objWindow,strGuid,strCurrentTokenPosition,intTokenNumericValue,false,(strCurrentTokenPosition==strSelectedTokenPosition));
                            }
                        }
                    }
                }                
            }
        }
    }
}
/// </method>


/// <method name="DateTimePicker_GetTokenNumericValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenNumericValue(strTokenFormat,objDateTimeValue)
{   
    var intNumericValue = -1;
    
    // Validate recieved arguments.    
    if(!Aux_IsNullOrEmpty(strTokenFormat) && objDateTimeValue)
    {
        // Set a numeric value as for date object.
        switch(strTokenFormat)
        {
            case "ddd":
            case "dddd":
                intNumericValue=objDateTimeValue.getDay();
                break;
            case "d":
            case "dd":    
                intNumericValue=objDateTimeValue.getDate();
                break;
            case "h":
            case "hh":
            case "H":
            case "HH":
                intNumericValue=objDateTimeValue.getHours();
                break;
            case "m":
            case "mm":
                intNumericValue=objDateTimeValue.getMinutes();
                break;
            case "M":
            case "MM":
            case "MMM":
            case "MMMM":        
                intNumericValue=objDateTimeValue.getMonth();
                break;
            case "s":
            case "ss":
                intNumericValue=objDateTimeValue.getSeconds();
                break;
            case "t":
            case "tt":
                intNumericValue=(objDateTimeValue.getHours()>11?1:0);
                break;
            case "y":
            case "yy":
            case "yyyy":
                intNumericValue=objDateTimeValue.getFullYear();
                break;                            
        }
    }
    
    return intNumericValue;
}
/// </method>


/// <method name="DateTimePicker_GetTokenFormat">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenFormat(strGuid,strTokenPosition)
{   
    var strTokenFormat = "";
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    {
        // Get the token's node.
        var objTokenNode = DateTimePicker_GetChildNode(strGuid,parseInt(strTokenPosition,10)-1);
        if(objTokenNode)
        {
            // Get the token's format.
            strTokenFormat = Xml_GetAttribute(objTokenNode,"Attr.Format","");
        }
    }
    
    return strTokenFormat;
}
/// </method>

/// <method name="DateTimePicker_SetTokenDataValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_SetTokenDataValue(strGuid,strTokenPosition,strTokenValue)
{   
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && !Aux_IsNullOrEmpty(strTokenValue))
    {
        // Get the token's node.
        var objTokenNode = DateTimePicker_GetChildNode(strGuid,parseInt(strTokenPosition,10)-1);
        if(objTokenNode)
        {
            // Set the value attributre.
            Xml_SetAttribute(objTokenNode,"Attr.Value",strTokenValue);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_GetTokenDataValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenDataValue(strGuid,strTokenPosition)
{   
    var strTokenValue = "";
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    {
        // Get the token's node.
        var objTokenNode = DateTimePicker_GetChildNode(strGuid,parseInt(strTokenPosition,10)-1);
        if(objTokenNode)
        {
            // Get the token's value attribute.
            strTokenValue = Xml_GetAttribute(objTokenNode,"Attr.Value","");
        }
    }
    
    return strTokenValue;
}
/// </method>

/// <method name="DateTimePicker_IsTokenSupportingNumericKeys">
/// <summary>
/// 
/// </summary>
function DateTimePicker_IsTokenSupportingNumericKeys(strTokenFormat)
{   
    return (!Aux_IsNullOrEmpty(strTokenFormat) && strTokenFormat != "t" && strTokenFormat != "tt");
}
/// </method>


/// <method name="DateTimePicker_IsTokenSupportingCircularity">
/// <summary>
/// 
/// </summary>
function DateTimePicker_IsTokenSupportingCircularity(strTokenFormat)
{   
    return (!Aux_IsNullOrEmpty(strTokenFormat) && strTokenFormat != "y" && strTokenFormat != "yy" && strTokenFormat != "yyyy");
}
/// </method>


/// <method name="DateTimePicker_IsTokenNavigationKey">
/// <summary>
/// 
/// </summary>
function DateTimePicker_IsTokenNavigationKey(intKeyCode)
{   
    return (!Aux_IsNullOrEmpty(intKeyCode) && [mcntLeftKey,mcntRightKey].contains(intKeyCode));
}
/// </method>

/// <method name="DateTimePicker_IsIncrementOrDecrementKey">
/// <summary>
///  
/// </summary>
/// <param name="intKeyCode"></param>
function DateTimePicker_IsIncrementOrDecrementKey(intKeyCode)
{
    return (!Aux_IsNullOrEmpty(intKeyCode) && [mcntUpKey,mcntDownKey,mcntPlusKey,mcntMinusKey1,mcntMinusKey2].contains(intKeyCode));
}
/// </method>

/// <method name="DateTimePicker_IsPermitedSystemKey">
/// <summary>
///  
/// </summary>
/// <param name="objEvent"></param>
function DateTimePicker_IsPermitedSystemKey(objEvent)
{
    // Check if alt or control are pressed.
    if(Web_IsAlt(objEvent) || Web_IsControl(objEvent))
    {
        return true;
    }
    else
    {
        // Check whether one of the "F" keys was pressed.
        return [mcntF1Key,mcntF2Key,mcntF3Key,mcntF4Key,mcntF5Key,mcntF6Key,mcntF7Key,mcntF8Key,mcntF9Key,mcntF10Key,mcntF11Key,mcntF12Key].contains(Web_GetEventKeyCode(objEvent));
    }
}
/// </method>

/// <method name="DateTimePicker_IsNumericKey">
/// <summary>
///  
/// </summary>
/// <param name="intKeyCode"></param>
function DateTimePicker_IsNumericKey(intKeyCode)
{
    return (!Aux_IsNullOrEmpty(intKeyCode) && ((intKeyCode>=96 && intKeyCode<=105) || (intKeyCode>=48 && intKeyCode<=57)));
}
/// </method>

/// <method name="DateTimePicker_CheckBoxKeyDown">
/// <summary>
/// Handles the check box key down.
/// </summary>
function DateTimePicker_CheckBoxKeyDown(objWindow,objEvent,strGuid,objElement)
{
    if(objEvent)
    {
        // Get the pressed key
	    var intKeyCode = Web_GetEventKeyCode(objEvent);
	    
	    // Check if a spacebar was clicked.
	    if(intKeyCode==mcntSpaceKey)
	    {
		    DateTimePicker_CheckChange(objWindow,strGuid,objElement);
	    }
	    
	    // In case of navigation keys.
	    else if (DateTimePicker_IsTokenNavigationKey(intKeyCode)) 
	    {
	        DateTimePicker_HandleNavigationKeys(objWindow,strGuid,null,intKeyCode);	      

            // Cancel buble.
            Web_EventCancelBubble(objEvent); 	        	        
	    }
	}
}
/// </method>

/// <method name="DateTimePicker_ExecuteTokenNavigation">
/// <summary>
/// 
/// </summary>
function DateTimePicker_ExecuteTokenNavigation(objWindow,strGuid,strTokenPosition,blnNextSibling)
{  
     // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && objWindow)
    {
        // Get the date time picker node.
        var objDateTimePickerNode = Data_GetNode(strGuid);
        if(objDateTimePickerNode)
        {
            // Define empty token element and token position.
            var objFocusableElement = null;
            var intTokenPosition = -1;
            
            // Get token count.
            var intTokenCount = objDateTimePickerNode.childNodes.length;
            
            // Check whether checkbox is shown.
            var blnCheckboxShown = Data_IsAttribute(strGuid,"Attr.CheckBoxes","1");
            
            // Validate recieved token position.
            if(!Aux_IsNullOrEmpty(strTokenPosition))
            {
                // Parse position string.
                intTokenPosition = parseInt(strTokenPosition,10)-1;
                
                // Check if position is an edge.
                if( (intTokenPosition==(intTokenCount-1) && blnNextSibling) ||
                    (intTokenPosition==0 && !blnNextSibling))
                {
                    // In case that checkbox is shown - set it as token element.
                    if(blnCheckboxShown)
                    {   
                        // Get check box element.
                        objFocusableElement = DateTimePicker_GetCheckBoxElement(objWindow,strGuid);
                    }
                    else
                    {
                        // Get edges position.
                        intTokenPosition=(intTokenPosition==0?intTokenCount-1:0);
                    }
                }
                else
                {
                    // Update position for zero base reasons.
                    intTokenPosition=(blnNextSibling?intTokenPosition+1:intTokenPosition-1);
                }
            }
            else
            {       
                // If no token position supplied - get edge token as for direction.
                intTokenPosition=(blnNextSibling?0:intTokenCount-1);
            }
            
            // If noe token element was found and position is valid.
            if(!objFocusableElement && intTokenPosition>=0 && intTokenPosition<intTokenCount)
            {
                // Get target token as for position.
                var objTargetTokenNode = DateTimePicker_GetChildNode(strGuid,intTokenPosition);
                if(objTargetTokenNode)
                {
                    // Get a sequential token.
                    var objSequentialToken=DateTimePicker_GetSequentialTokenNode(objTargetTokenNode,blnNextSibling,intTokenPosition);
                    
                    // If no token has been found.
                    if(!objSequentialToken.Token)
                    {
                        // In case that checkbox is shown - set it as token element.
                        if(blnCheckboxShown)
                        {   
                            // Get check box element.
                            objFocusableElement = DateTimePicker_GetCheckBoxElement(objWindow,strGuid);
                        }
                        else
                        {
                            // Initialize token position to the proper edge.
                            intTokenPosition=(blnNextSibling?0:intTokenCount-1);
                            
                            // Update target token as for position.
                            objTargetTokenNode = DateTimePicker_GetChildNode(strGuid,intTokenPosition);
                            
                            // Retry getting a new sequential token.
                            objSequentialToken=DateTimePicker_GetSequentialTokenNode(objTargetTokenNode,blnNextSibling,intTokenPosition);
                        }
                    }
                    
                    // In cae that no tokenelement has been founf so far - validate recieved sequential token.
                    if(!objFocusableElement && objSequentialToken.Token)
                    {
                        // Get token element.
                        objFocusableElement =  DateTimePicker_GetTokenElement(objWindow,strGuid,String(objSequentialToken.Index+1));
                    }
                }
            }
            
            // If no focusable element found.
            if(!objFocusableElement)
            {
                // Try getting the default focusable element.
                objFocusableElement = Web_GetElementById("TRG_"+strGuid,objWindow);
            }
            
            // If a valid focusable element found.
            if(objFocusableElement)
            {
                // Ste focus on token element.
                Web_SetFocus(objFocusableElement);
            }
        }
    }
}
/// </method>

/// <method name="DateTimePicker_HandleNavigationKeys">
/// <summary>
/// 
/// </summary>
function DateTimePicker_HandleNavigationKeys(objWindow,strGuid,strTokenPosition,intKeyCode)
{   
    // Validate recieved arguments.
    if  (!Aux_IsNullOrEmpty(strGuid) && objWindow && 
        DateTimePicker_IsTokenNavigationKey(intKeyCode))
    {
        var blnNextSibling = true;
            
        // Check recieved key code.
        switch(intKeyCode)
        {   
            case mcntLeftKey:
                blnNextSibling = false;
                break;
            case mcntRightKey:
                blnNextSibling = true;
                break;
        }
        
        // Navigate token.
        DateTimePicker_ExecuteTokenNavigation(objWindow,strGuid,strTokenPosition,blnNextSibling);
    }
}
/// </method>

/// <method name="DateTimePicker_GetSequentialTokenNode">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetSequentialTokenNode(objToken,blnNextSibling,intTokenPosition)
{
    // Loop while a valid token was'nt found.
    while(objToken && (objToken.tagName!="Tags.Token" || Xml_IsAttribute(objToken,"Attr.ReadOnly","1")))
    {               
        if(blnNextSibling)
        {
            // Move to next sibling and raise position.
            objToken=objToken.nextSibling;
            intTokenPosition++;
        }
        else
        {
            // Move to previous sibling and decrease position.
            objToken=objToken.previousSibling;  
            intTokenPosition--;                
        }
    }
    
    // Return a struct with new token and index.
    return {Token:objToken,Index:intTokenPosition};
}
/// </method>

/// <method name="DateTimePicker_GetCheckBoxElement">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetCheckBoxElement(objWindow,strGuid)
{
    var objCheckBoxElement = null;
   
    // Validate recieved arguments.    
	if(objWindow && !Aux_IsNullOrEmpty(strGuid))
	{
	    // Get token element.
        objCheckBoxElement =  Web_GetElementById("VWG"+strGuid+"_CB",objWindow);
	}
	
	return objCheckBoxElement;
}
/// </method>

/// <method name="DateTimePicker_GetChildNode">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetChildNode(strGuid,intPosition)
{
    var objNode = null;
   
    // Validate recieved arguments.    
	if(!Aux_IsNullOrEmpty(strGuid) && !isNaN(intPosition) && intPosition>=0)
	{
	    // Get the date time picker node.
        var objDateTimePickerNode = Data_GetNode(strGuid);
        if(objDateTimePickerNode && intPosition<objDateTimePickerNode.childNodes.length)
        {
	        // Get token node.
            objNode = objDateTimePickerNode.childNodes[intPosition];
        }
	}
	
	return objNode;
}
/// </method>

/// <method name="DateTimePicker_GetTokenElement">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenElement(objWindow,strGuid,strTokenPosition)
{
    var objTokenElement = null;
   
    // Validate recieved arguments.    
	if(objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
	{
	    // Get token element.
        objTokenElement =  Web_GetElementById("VWG"+strGuid+"_"+strTokenPosition,objWindow);
	}
	
	return objTokenElement;
}
/// </method>

/// <method name="DateTimePicker_OnKeyDown">
/// <summary>
/// Manage DateTimePicker KeyDown 
/// </summary>
function DateTimePicker_OnKeyDown(strGuid,objInput,objWindow,objEvent)
{
    // Get the pressed key
	var intKeyCode = Web_GetEventKeyCode(objEvent);
	
	// Check if need to browse
	if(Web_IsAlt(objEvent) && intKeyCode == mcntDownKey)
    {
        // Check if popup is already opened
        if(!Popups_GetPopup("vwg_ControlId",strGuid))
        {
            DateTimePicker_Browse(strGuid,objWindow,objEvent);
        }
    }
	else if(DateTimePicker_IsTokenNavigationKey(intKeyCode))
	{
	    DateTimePicker_HandleNavigationKeys(objWindow,strGuid,Web_GetAttribute(objInput,"vwgposition",true),intKeyCode);
	}
	else if(DateTimePicker_IsIncrementOrDecrementKey(intKeyCode))
	{
	    DateTimePicker_HandleUpDownKeys(objWindow,objInput,strGuid,Web_GetAttribute(objInput,"vwgposition",true),intKeyCode);
	}
	else if(DateTimePicker_IsNumericKey(intKeyCode))
	{
	    DateTimePicker_HandleNumericKeys(objWindow,objInput,strGuid,Web_GetAttribute(objInput,"vwgposition",true),intKeyCode);	    
	}
	
	// Check if key is not a permited system key.
	if(!DateTimePicker_IsPermitedSystemKey(objEvent))
	{
	    // Prevent default key down behavior.
        Web_EventCancelBubble(objEvent,true,false); 
	}
	
	// Flag that last key pressed is not a numeric one.
	if(!DateTimePicker_IsNumericKey(intKeyCode))
	{
	    DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,"0");
	}
}
/// </method>

/// <method name="DateTimePicker_HandleUpDownKeys">
/// <summary>
/// 
/// </summary>
function DateTimePicker_HandleUpDownKeys(objWindow,objInput,strGuid,strTokenPosition,intKeyCode)
{
    // Validate recieved arguments.
    if  (!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && 
        objWindow && objInput && DateTimePicker_IsIncrementOrDecrementKey(intKeyCode))
    {
        var blnNextValue = true;
            
        // Check recieved key code.
        switch(intKeyCode)
        {   
            case mcntDownKey:
            case mcntMinusKey1:
            case mcntMinusKey2:
                blnNextValue = false;
                break;
            case mcntUpKey:
            case mcntPlusKey:
                blnNextValue = true;
                break;
        }
        
        // Execute up down logic.
        DateTimePicker_ExecuteTokenUpDownAssignment(objWindow,objInput,strGuid,strTokenPosition,blnNextValue);
    }
}
/// </method>

/// <method name="DateTimePicker_GetTokenSequentialCalculatedValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenSequentialCalculatedValue(objDateTimeValue,strGuid,strTokenPosition,blnNextValue)
{
    var intSequentialValue = -1;
    
    // Validate recieved arguments.
    if(objDateTimeValue && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    { 
        // Get the handled token's format.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat))
        {
            // Get a numeric value for the recieved token's value.
            var intValue = DateTimePicker_GetTokenNumericValue(strTokenFormat,objDateTimeValue);
            if(intValue >= 0)
            {
                // Get token's value borders.
                var objTokenValueBorders = DateTimePicker_GetTokenValueBorders(strGuid,strTokenFormat);
                
                // Validate borders.
                if(objTokenValueBorders && objTokenValueBorders.Bottom>=0 && objTokenValueBorders.Top>=0)
                {
                    // Check whether recieved token is circular.
                    var blnIsTokenCircular = DateTimePicker_IsTokenSupportingCircularity(strTokenFormat);
                    
                    // Calculate sequential value.
                    intSequentialValue = (intValue+(blnNextValue?1:-1));
                    
                    // Check if sequential value execeded bottom border.
                    if(intSequentialValue<objTokenValueBorders.Bottom)
                    {   
                        // Set sequential value to top border.
                        intSequentialValue=(blnIsTokenCircular?objTokenValueBorders.Top:-1);
                    }
                    // Check if sequential value execeded top border.                    
                    else if(intSequentialValue>objTokenValueBorders.Top)
                    {
                        // Set sequential value to bottom border.                        
                        intSequentialValue=(blnIsTokenCircular?objTokenValueBorders.Bottom:-1);                    
                    }
                }              
            }
        }
    }
    
    return intSequentialValue;
}
/// </method>

/// <method name="DateTimePicker_IsValueInRange">
/// <summary>
/// 
/// </summary>
function DateTimePicker_IsValueInRange(intValue,intTop,intBottom)
{
    return (intValue<=intTop && intValue>=intBottom);
}
/// </method>

/// <method name="DateTimePicker_GetTokenNumericCalculatedValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenNumericCalculatedValue(objWindow,objDateTimeValue,strGuid,strTokenPosition,intKeyCode,intTokenValidationLength)
{
    var intCalculatedValue = -1;
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) &&
        objDateTimeValue && objWindow && DateTimePicker_IsNumericKey(intKeyCode))
    { 
        // Get the handled token's format.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat))
        {
            // Get token input value.
            var strTokenInputValue = DateTimePicker_GetTokenInputValue(objWindow,strGuid,strTokenPosition);
            
            // Get a numeric value for the recieved token's value.
            var intValue = (intTokenValidationLength>0?parseInt(strTokenInputValue,10):DateTimePicker_GetTokenNumericValue(strTokenFormat,objDateTimeValue));                                    
            
            // Get token's none zero based value.
            intValue = DateTimePicker_GetTokeZeroBasedValue(intValue,strTokenFormat,false);
            
            if(intValue >= 0)
            {
                // Get token's value borders.
                var objTokenValueBorders = DateTimePicker_GetTokenValueBorders(strGuid,strTokenFormat);
                
                // Validate borders.
                if(objTokenValueBorders && objTokenValueBorders.Bottom>=0 && objTokenValueBorders.Top>=0)
                {
                    // Parse the new digit out of recieved key code.
                    var intDigit = parseInt(Aux_CharFromKeyCode(intKeyCode),10);
                    if(!isNaN(intDigit))
                    {
                        // Concat the new digit to the end of current value.
                        var intConcatenatedValue = parseInt(String(intValue)+String(intDigit),10);
                        
                        // Get token's zreo based value.
                        intConcatenatedValue = DateTimePicker_GetTokeZeroBasedValue(intConcatenatedValue,strTokenFormat,true);
                        
                        // Check if current token has a predefined array.                        
                        var blnTokenHasEnums = DateTimePicker_GetTokenEnums(strTokenFormat);
                        if(blnTokenHasEnums)
                        {
                            // Concat a new aray value.
                            intConcatenatedValue = (((intValue+1)*10)+(intDigit-1));
                        }
                        
                        // Check whether the handled token has a digit pressed since it got focus.
                        var blnDigitPreviouslyPressed = ((DateTimePicker_GetActiveTokenPosition(objWindow,strGuid)==strTokenPosition) && (DateTimePicker_GetActiveTokenDigitPressed(objWindow,strGuid)=="1"));
                                                
                        // Check if the new concatenated value fall in a valid range.
                        if(blnDigitPreviouslyPressed)
                        {
                            // Check whether token validation should be suspended.
                            var blnSuspendTokenValidation = (intTokenValidationLength>0 && (intTokenValidationLength-strTokenInputValue.length)>1);
                        
                            if(blnSuspendTokenValidation || DateTimePicker_IsValueInRange(intConcatenatedValue,objTokenValueBorders.Top,objTokenValueBorders.Bottom))
                            {
                                // Return the concatenated value.
                                intCalculatedValue = intConcatenatedValue;
                            }
                        }
                        else 
                        {
                            // Check whether token validation should be suspended.                          
                            var blnSuspendTokenValidation = (intTokenValidationLength>0);
                            
                            // Check if the new digit falls in a valid range.
                            if(blnSuspendTokenValidation || DateTimePicker_IsValueInRange(intDigit,objTokenValueBorders.Top,objTokenValueBorders.Bottom))
                            {
                                // Return the array index or the new zero based digit.
                                intCalculatedValue = (blnTokenHasEnums?intDigit-1:DateTimePicker_GetTokeZeroBasedValue(intDigit,strTokenFormat,true));
                            }
                        }
                        
                        // Flag the a digit has been pressed on active token element.
                        if(intCalculatedValue!=-1)
                        {
                            DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,"1");
                        }
                    }
                }
            }
        }
    }
    
    return intCalculatedValue;
}
/// </method>

/// <method name="DateTimePicker_GetTokeZeroBasedValue">
/// <summary>
/// Get token's zero based value.
/// </summary>
function DateTimePicker_GetTokeZeroBasedValue(intValue,strTokenFormat,blnZeroBased)
{
    var intFixValue = intValue;
    
    switch(strTokenFormat)
    {
        case "M":
        case "MM":
            intFixValue += (blnZeroBased?-1:1);
            break;                     
    }
    
    return intFixValue;
}
/// </method>

/// <method name="DateTimePicker_GetTokenValueBorders">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenValueBorders(strGuid,strTokenFormat)
{
    // Define negative borders.
    var intBottomBorder=-1;
    var intTopBorder=-1;
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenFormat))
    {
        // Get current datetime object.
        var objDateTimeValue = DateTimePicker_GetDataDateTimeValue(strGuid);
        if(objDateTimeValue)
        {
            // Check if the recieved token has valid enums array.
            var arrEnums = DateTimePicker_GetTokenEnums(strTokenFormat);
            if(arrEnums)
            {
                // Set borders as for array.
                intBottomBorder=0;
                intTopBorder=arrEnums.length-1;
            }  
            else
            {
                // Set borders as for token format.
                switch(strTokenFormat)
                {
                    case "d":
                    case "dd":
                        intBottomBorder=1;
                        intTopBorder=DateTimePicker_GetNumberOfDaysInMonth(objDateTimeValue.getMonth(),objDateTimeValue.getFullYear());
                        break;
                    case "h":
                    case "hh":
                    case "H":
                    case "HH":
                        intBottomBorder=0;
                        intTopBorder=23;
                        break;
                    case "M":
                    case "MM":
                        intBottomBorder=0;
                        intTopBorder=11;
                        break;
                        break;
                    case "m":
                    case "mm":
                    case "s":
                    case "ss":
                        intBottomBorder=0;
                        intTopBorder=59;
                        break;
                    case "t":
                    case "tt":
                        intBottomBorder=0;
                        intTopBorder=1;
                        break;
                    case "y":
                    case "yy":
                    case "yyyy":
                        intBottomBorder=1753;
                        intTopBorder=9998;
                        break;                           
                }
            }
        }
    }
    
    return {Bottom:intBottomBorder,Top:intTopBorder};
}
/// </method>

/// <method name="DateTimePicker_GetTokenValidationLength">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenValidationLength(strTokenFormat)
{
    if(strTokenFormat=="y" || strTokenFormat=="yy" || strTokenFormat=="yyyy")
    {
        return 4;
    }
    return 0;
}
/// </method>

/// <method name="DateTimePicker_ExecuteTokenNumericAssignment">
/// <summary>
/// 
/// </summary>
function DateTimePicker_ExecuteTokenNumericAssignment(objWindow,objInput,strGuid,strTokenPosition,intKeyCode)
{
    // Validate recieved arguments.
    if( !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && 
        objWindow && objInput && DateTimePicker_IsNumericKey(intKeyCode))
    {   
        // Get the handled token's format.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat) && DateTimePicker_IsTokenSupportingNumericKeys(strTokenFormat))
        {
            // Try parsing ticks data into a data object.
            var objCurrentDateTimeValue = DateTimePicker_GetDataDateTimeValue(strGuid);
            if(objCurrentDateTimeValue)
            {
                // Check token's validation length.
                var intTokenValidationLength = DateTimePicker_GetTokenValidationLength(strTokenFormat);
                
                // Calculate token numeric value.
                var intNumericCalculatedValue = DateTimePicker_GetTokenNumericCalculatedValue(objWindow,objCurrentDateTimeValue,strGuid,strTokenPosition,intKeyCode,intTokenValidationLength);
                
                // Check if calculated value is not valid.
                if(intNumericCalculatedValue<0)
                {
                    // Initialize the digit pressed attribute.
                    DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,"0");
                    
                    // Recalculate token numeric value.
                    intNumericCalculatedValue = DateTimePicker_GetTokenNumericCalculatedValue(objWindow,objCurrentDateTimeValue,strGuid,strTokenPosition,intKeyCode,intTokenValidationLength);
                }
                
                // Validate calculated value.
                if(intNumericCalculatedValue>=0)
                {
                    // Check if date time should not be suspended.
                    var blnUpdatedDateTimeValue = (intTokenValidationLength==0 || intTokenValidationLength==String(intNumericCalculatedValue).length);
                    
                    // Check whether token validation should be suspended.
                    if(blnUpdatedDateTimeValue)
                    {
                        // Try updating datetime value.
                        DateTimePicker_UpdatedDateTimeValue(objWindow,strGuid,strTokenPosition,intNumericCalculatedValue);
                    }
                    else
                    {
                        // Set token input value.
                        DateTimePicker_SetTokenInputValue(objWindow,strGuid,strTokenPosition,intNumericCalculatedValue,true);
                    }
                }
                else
                {
                    // Restores token's data value.
                    DateTimePicker_RestoreTokenValue(objWindow,strGuid,strTokenPosition,true);
                    
                    // Initialize the digit pressed attribute.
                    DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,"0");
                }
            }
        }
    }
}
/// </method>

/// <method name="DateTimePicker_RestoreTokenValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_RestoreTokenValue(objWindow,strGuid,strTokenPosition,blnSetTokenSelection)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && objWindow)
    {
        // Get token's data value.
        var strTokenDataValue = DateTimePicker_GetTokenDataValue(strGuid,strTokenPosition);
        
        // Get token's input value.
        var strTokenInputValue = DateTimePicker_GetTokenInputValue(objWindow,strGuid,strTokenPosition);
        
        // Check if data value and input's value are different.
        if(!Aux_IsNullOrEmpty(strTokenDataValue) && !Aux_IsNullOrEmpty(strTokenInputValue) && strTokenDataValue!=strTokenInputValue)
        {
            // Set data value as input value.
            DateTimePicker_SetTokenInputValue(objWindow,strGuid,strTokenPosition,strTokenDataValue,blnSetTokenSelection);
        }
    }
}
/// </method>

/// <method name="DateTimePicker_ExecuteTokenUpDownAssignment">
/// <summary>
/// 
/// </summary>
function DateTimePicker_ExecuteTokenUpDownAssignment(objWindow,objInput,strGuid,strTokenPosition,blnNextValue)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && objWindow && objInput)
    {   
        // Get the handled token's format.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat))
        {            
            // Try parsing ticks data into a data object.
            var objCurrentDateTimeValue = DateTimePicker_GetDataDateTimeValue(strGuid);
            if(objCurrentDateTimeValue)
            {
                // Get token's sequential value.
                var intTokenSequentialValue = DateTimePicker_GetTokenSequentialCalculatedValue(objCurrentDateTimeValue,strGuid,strTokenPosition,blnNextValue);
                if(intTokenSequentialValue>=0)
                {
                    // Try updating datetime value.
                    DateTimePicker_UpdatedDateTimeValue(objWindow,strGuid,strTokenPosition,intTokenSequentialValue);
                }
            }
        }
    }
}
/// </method>

/// <method name="DateTimePicker_SetTokenInputValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_SetTokenInputValue(objWindow,strGuid,strTokenPosition,strTokenDisplayValue,blnSetTokenSelection)
{
    // Validate recieved arguments.
    if( objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && 
        !Aux_IsNullOrEmpty(strTokenDisplayValue))
    { 
        // Get token element.
        var objTokenInput =  DateTimePicker_GetTokenElement(objWindow,strGuid,strTokenPosition);
        if(objTokenInput)
        {
            // Set display value.                            
            objTokenInput.value = strTokenDisplayValue;
            
            // Set token's selection.
            if(blnSetTokenSelection)
            {
                DateTimePicker_SetTokenSelection(objTokenInput);
            }
        }
    }
}
/// </method>

/// <method name="DateTimePicker_GetTokenInputValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenInputValue(objWindow,strGuid,strTokenPosition)
{
    var strTokenInputValue = "";
    
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    { 
        // Get token element.
        var objTokenInput =  DateTimePicker_GetTokenElement(objWindow,strGuid,strTokenPosition);
        if(objTokenInput)
        {
            // Get input's value.
            strTokenInputValue=objTokenInput.value;
        }
    }
    
    return strTokenInputValue;
}
/// </method>

/// <method name="DateTimePicker_SetTokenDisplayValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_SetTokenDisplayValue(objWindow,strGuid,strTokenPosition,intTokenValue,blnUpdateEffectedTokens,blnSetTokenSelection)
{
     // Validate recieved arguments.
    if( !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && 
        !isNaN(intTokenValue) && objWindow)
    { 
        // Get the handled token's format.
        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strTokenPosition);
        if(!Aux_IsNullOrEmpty(strTokenFormat))
        {
            // Get token's value display value.
            var strTokenDisplayValue = DateTimePicker_GetTokenDisplayValue(intTokenValue,strTokenFormat);
            if(!Aux_IsNullOrEmpty(strTokenDisplayValue))
            {                        
                // Update to token's data value.
                DateTimePicker_SetTokenDataValue(strGuid,strTokenPosition,strTokenDisplayValue);
                
                // Update effected tokens.
                if(blnUpdateEffectedTokens)
                {
                    DateTimePicker_UpdateEffectedTokens(objWindow,strGuid,strTokenPosition);
                }

                // Set token input value.
                DateTimePicker_SetTokenInputValue(objWindow,strGuid,strTokenPosition,strTokenDisplayValue,blnSetTokenSelection);
            }
        }
    }
}
/// </method>

/// <method name="DateTimePicker_UpdateEffectedTokens">
/// <summary>
/// 
/// </summary>
function DateTimePicker_UpdateEffectedTokens(objWindow,strGuid,strTokenPosition)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    {
        // Get token's effected formats.
        var arrTokenEffectedFormats = DateTimePicker_GetTokenEffectedFormats(strGuid,strTokenPosition);
        if(arrTokenEffectedFormats)
        {
            // Get effected token positions.
            var arrEffectedTokenPositions = DateTimePicker_GetEffectedTokenPositions(strGuid,arrTokenEffectedFormats,parseInt(strTokenPosition,10)-1);
            if(arrEffectedTokenPositions)
            {
                // Get current datetime object.
                var objDateTimeValue = DateTimePicker_GetDataDateTimeValue(strGuid);
                if(objDateTimeValue)
                {
                    // Loop all effected token positions.
                    for(var intEffectedToken=0; intEffectedToken<arrEffectedTokenPositions.length; intEffectedToken++)
                    {
                        // Get effected token position.
                        var strEffectedTokenPosition = String(arrEffectedTokenPositions[intEffectedToken]);
                        if(!Aux_IsNullOrEmpty(strEffectedTokenPosition))
                        {
                            // Get effected token input.
                            var objEffectedTokenInput = DateTimePicker_GetTokenElement(objWindow,strGuid,strEffectedTokenPosition);
                            if(objEffectedTokenInput)
                            {
                                 // Get the handled token's format.
                                var strEffectedTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strEffectedTokenPosition);
                                if(!Aux_IsNullOrEmpty(strEffectedTokenFormat))
                                {
                                    // Get effected token numeric value.
                                    var intEffectedTokenValue= DateTimePicker_GetTokenNumericValue(strEffectedTokenFormat,objDateTimeValue);
                                    if(!isNaN(intEffectedTokenValue))
                                    {
                                        // Set effected token display value.
                                        DateTimePicker_SetTokenDisplayValue(objWindow,strGuid,strEffectedTokenPosition,intEffectedTokenValue,false,false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="DateTimePicker_GetEffectedTokenPositions">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetEffectedTokenPositions(strGuid,arrTokenEffectedFormats,intTokenPosition)
{
    var arrEffectedTokenPositions = null;
    
    // Validate recieved arguments.
    if( !Aux_IsNullOrEmpty(strGuid) && arrTokenEffectedFormats && 
        arrTokenEffectedFormats.length>0 && !isNaN(intTokenPosition))
    {
        // Get the date time picker node.
        var objDateTimePickerNode = Data_GetNode(strGuid);
        if(objDateTimePickerNode && objDateTimePickerNode.childNodes.length>0)
        {
            // Loop all childs.
            for(var intChild=0; intChild<objDateTimePickerNode.childNodes.length; intChild++)
            {
                // Check that current child is not the effecting token.
                if(intChild!=intTokenPosition)
                {
                    // Get current child node.
                    var objChildNode = objDateTimePickerNode.childNodes[intChild];
                    
                    // Cehck if current child is a token.
                    if(objChildNode && objChildNode.tagName=="Tags.Token")
                    {
                        // Get current token position.
                        var strCurrentTokenPosition = String(intChild+1);
                        
                        // Get the handled token's format.
                        var strTokenFormat = DateTimePicker_GetTokenFormat(strGuid,strCurrentTokenPosition);
                        if(!Aux_IsNullOrEmpty(strTokenFormat) && arrTokenEffectedFormats.contains(strTokenFormat))
                        {
                            // Check if the result array is null and create it.
                            if(!arrEffectedTokenPositions)
                            {
                                arrEffectedTokenPositions = [];
                            }
                            
                            // Push current token position into result array.
                            arrEffectedTokenPositions.push(strCurrentTokenPosition);
                        }
                    }
                }
            }
        }
    }
    
    return arrEffectedTokenPositions;
}
/// </method>

/// <method name="DateTimePicker_GetTokenDisplayValue">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenDisplayValue(intTokenValue,strTokenFormat)
{
    var strTokenDisplayValue="";
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strTokenFormat) && intTokenValue>=0)
    {
        // Check if the recieved token has valid enums array.
        var arrEnums = DateTimePicker_GetTokenEnums(strTokenFormat);
        if(arrEnums)
        {
            // Parse string value out of array.                        
            strTokenDisplayValue=arrEnums[intTokenValue];
        }  
        else
        {
            // Get a none zero based token's value.
            intTokenValue=DateTimePicker_GetTokeZeroBasedValue(intTokenValue,strTokenFormat,false);
            
            // Parses the value according to format.
            switch(strTokenFormat)
            {
                case "h":
                case "hh":
                    if(intTokenValue>12)
                    {
                        intTokenValue-=12;
                    }
                    else if(intTokenValue==0)
                    {
                        intTokenValue=12;
                    }
                    
                    if(strTokenFormat=="hh" && intTokenValue<10)
                    {
                        strTokenDisplayValue="0"+String(intTokenValue);
                    }
                    break;
                case "M":
                case "MM":
                    if(strTokenFormat=="MM" && intTokenValue<10)
                    {
                        strTokenDisplayValue="0"+String(intTokenValue);
                    }
                    break;                    
                case "mm":
                case "ss":
                case "HH":
                case "dd":
                    if(intTokenValue<10)
                    {
                        strTokenDisplayValue="0"+String(intTokenValue);
                    }
                    break;
                case "y":
                case "yy":
                    strTokenDisplayValue=String(intTokenValue).substring(2);
                    if(strTokenFormat=="y") 
                    {
                        strTokenDisplayValue=String(parseInt(strTokenDisplayValue,10));
                    }                    
                    break;
            }
            
            // Set default display value as standard casting to string.
            if(strTokenDisplayValue=="")
            {
                strTokenDisplayValue=String(intTokenValue);
            }
        }
    }
    
    return strTokenDisplayValue;
}
/// </method>

/// <method name="DateTimePicker_HandleNumericKeys">
/// <summary>
/// 
/// </summary>
function DateTimePicker_HandleNumericKeys(objWindow,objInput,strGuid,strTokenPosition,intKeyCode)
{
    // Validate recieved arguments.
    if  (!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition) && 
        objWindow && objInput && DateTimePicker_IsNumericKey(intKeyCode))
    {
        // Execute up down logic.
        DateTimePicker_ExecuteTokenNumericAssignment(objWindow,objInput,strGuid,strTokenPosition,intKeyCode);
    }
}
/// </method>

/// <method name="DateTimePicker_GetNumberOfDaysInMonth">
/// <summary>
/// Returns the number of days in a specific month
/// </summary>
/// <param name="intMonth"></param>
/// <param name="intYear"></param>
function DateTimePicker_GetNumberOfDaysInMonth(intMonth,intYear)
{
    // Define array with number of days per month.
    var intDays = [31,28,31,30,31,30,31,31,30,31,30,31][intMonth];
    
    // check for LeapYear - every 4th year except centuries not divisible by 400
    if (intMonth==1)
    {
        if(intYear%4==0 && (intYear%100!=00 || intYear%400==0))
        {
            intDays = 29;
        }
    }
    
    return intDays;
}
/// </method>

/// <method name="DateTimePicker_OnUpDown">
/// <summary>
/// 
/// </summary>
function DateTimePicker_OnUpDown(strGuid, objWindow, blnNextValue)
{
    // Validate received arguments.     
    if (!Aux_IsNullOrEmpty(strGuid) && objWindow)
    {
        // Get active token position.         
        var strActiveTokenPosition = DateTimePicker_GetActiveTokenPosition(objWindow, strGuid);

        if (Aux_IsNullOrEmpty(strActiveTokenPosition))
        {
            // Get the child node.
            var objNode = DateTimePicker_GetChildNode(strGuid, 0);
            if (objNode)
            {

                // Check if child is a literal or is read only.
                if (objNode.tagName == "Tags.Literal" || Xml_IsAttribute(objNode, "Attr.ReadOnly", "1"))
                {
                    // Get a sequential token.
                    var objSequentialToken = DateTimePicker_GetSequentialTokenNode(objNode, objNode.nextSibling, 1);

                    // Check valid token
                    if (objSequentialToken.Token)
                    {
                        // Get token index
                        strActiveTokenPosition = objSequentialToken.Index;
                    }
                }
                else
                {
                    strActiveTokenPosition = 1;
                }
            }

            // Check valid token position
            if (!Aux_IsNullOrEmpty(strActiveTokenPosition))
            {
                // Update active token position
                DateTimePicker_SetActiveTokenPosition(objWindow, strGuid, strActiveTokenPosition);
            }
        }

        // Check valid token position
        if (!Aux_IsNullOrEmpty(strActiveTokenPosition))
        {
            // Get active token element.
            var objActiveTokenInput = DateTimePicker_GetTokenElement(objWindow, strGuid, strActiveTokenPosition);
            if (objActiveTokenInput)
            {
                // Execute up down logic.
                DateTimePicker_ExecuteTokenUpDownAssignment(objWindow, objActiveTokenInput, strGuid, strActiveTokenPosition, blnNextValue);
            }
        }
    }
}
/// </method>


/// <method name="DateTimePicker_GetTokenEffectedFormats">
/// <summary>
/// 
/// </summary>
function DateTimePicker_GetTokenEffectedFormats(strGuid,strTokenPosition)
{   
    var arrTokenEffectedFormats = null;
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strTokenPosition))
    {
        // Get the token's node.
        var objTokenNode = DateTimePicker_GetChildNode(strGuid,parseInt(strTokenPosition,10)-1);
        if(objTokenNode)
        {
            // Check the token's circular attribute.
            var strTokenEffectedFormats = Xml_GetAttribute(objTokenNode,"Attr.EffectedFormats","");
            if(!Aux_IsNullOrEmpty(strTokenEffectedFormats))
            {
                // Split token effected string value.
                arrTokenEffectedFormats=strTokenEffectedFormats.split(',');
            }
        }
    }
    
    return arrTokenEffectedFormats;
}
/// </method>

/// <method name="DateTimePicker_OnClick">
/// <summary>
/// 
/// </summary>
function DateTimePicker_OnClick(objWindow,objInput,strGuid,strTokenPosition)
{   
    // Validate recieved arguments.
    if( !Aux_IsNullOrEmpty(strGuid) && objWindow && 
        !Aux_IsNullOrEmpty(strTokenPosition) && objInput)
    {
        // Initialize the digit pressed attribute.
        DateTimePicker_SetActiveTokenDigitPressed(objWindow,strGuid,"0");
        
        // Set token's selection.
        DateTimePicker_SetTokenSelection(objInput);
    }
}
/// </method>

/// <method name="DateTimePicker_IsDataValueChanged">
/// <summary>
///  
/// </summary>
function DateTimePicker_IsDataValueChanged(strGuid)
{
    var blnIsDataValueChanged = false;
    
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid))
    {   
        // Get current date time attribute.
        var strCurrentDateTime = Data_GetAttribute(strGuid,mcntCurrentDateTimeAttribute,"");
        if(!Aux_IsNullOrEmpty(strCurrentDateTime))
        {
            // Check if current datetime value is different from the meta data one.
            blnIsDataValueChanged=!Data_IsAttribute(strGuid,"Attr.DateTime",strCurrentDateTime);
        }
	}
	
	return blnIsDataValueChanged;
}
/// </method>

/// <method name="DateTimePicker_HandleUpButtonMouseEvents">
/// <summary>
///  
/// </summary>
function DateTimePicker_HandleUpButtonMouseEvents(objElement,strType,objWindow,objEvent)
{
    // Perform up action.
    DateTimePicker_HandleUpDownButtonMouseEvents(objElement,strType,objWindow,objEvent,true);
}
/// </method>

/// <method name="DateTimePicker_HandleDownButtonMouseEvents">
/// <summary>
///  
/// </summary>
function DateTimePicker_HandleDownButtonMouseEvents(objElement,strType,objWindow,objEvent)
{
    // Perform down action.
    DateTimePicker_HandleUpDownButtonMouseEvents(objElement,strType,objWindow,objEvent,false);
}
/// </method>

/// <method name="DateTimePicker_HandleUpDownButtonMouseEvents">
/// <summary>
///  
/// </summary>
function DateTimePicker_HandleUpDownButtonMouseEvents(objElement,strType,objWindow,objEvent,blnNextValue)
{
    // Perform class managing.
    Web_SetStyle(objElement,strType);
    
    // In case od miouse down.
    if(strType=="mousedown")
    {
          // Validate recieved element.
        if(objElement)
        {
            // Check if a left click.
            if(Web_IsLeftClick(objEvent))
            {
                // Get VWG source.
                var objVwgSource = Web_GetVwgElement(objElement);
                if(objVwgSource)
                {
                    // Perform up /down action.
                    DateTimePicker_OnUpDown(Data_GetDataId(objVwgSource.id),objWindow,blnNextValue,true);
                }
            }
        }
    }
}
/// </method>
