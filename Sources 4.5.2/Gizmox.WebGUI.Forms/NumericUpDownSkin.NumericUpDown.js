/// <method name="NumericUpDown_HandleEvents">
/// <summary>
/// Fires the right action to take by the given event 
/// </summary>
function NumericUpDown_HandleEvents(strGuid,strAction,objWindow,objEvent) 
{
    // Validate recieved arguments
    if (!Aux_IsNullOrEmpty(strGuid)) 
    {
        if (Data_IsDisabled(strGuid)) 
        {
            return;
        }
        
        // User textbox input
        var objInput = UpDownBase_GetInputElement(strGuid,objWindow);
        
        //Set action
        switch (strAction) 
        {
            case "keydown":
                NumericUpDown_OnKeyDown(objWindow,strGuid,objInput,objEvent);
                break;
            case "keypress":
                NumericUpDown_OnKeyPress(objWindow,strGuid,objInput,objEvent);
                break;
            case "blur":
                NumericUpDown_OnBlur(strGuid,objInput,objWindow);
                break;
            case "keyup":
                NumericUpDown_OnKeyUp(strGuid,objInput,objWindow,objEvent);
                break;
        }
    }
}
/// </method>

/// <method name="NumericUpDown_HandleMouseEvents">
/// <summary>
/// Handle Mouse Events
/// </summary>
function NumericUpDown_HandleMouseEvents(objElement,strType,objWindow) 
{   
    // Validate recieved arguments
    if (objElement && objWindow && !Aux_IsNullOrEmpty(strType)) 
    {
        // Get source element data id.            
        var strElementId = Web_GetId(objElement);
        
        //Get the Guid from controls id                                
        var strGuid = strElementId.substr(6);
        
        //Validate guid
        if(!Aux_IsNullOrEmpty(strGuid)) 
        {
            // Get domainupdown node
            var objNode = Data_GetNode(strGuid);
            if(objNode)
            {
                //Get the input control  
                var objInput = UpDownBase_GetInputElement(strGuid,objWindow);
                
                // Check if up button or down button has been pressed.
                var blnNextValue = (strElementId.substring(0,6)=="UDB_U_");

                // Switch action type.
                switch (strType) 
                {
                    case "mousedown":
                        // Start up down spin.
                        NumericUpDown_StartSpin(strGuid,blnNextValue,objWindow,objInput,NumericUpDown_UpdateValue,NumericUpDown_IsValidValue,"M");
                        break;
                    case "click":
                        // Stop up down spin.
                        NumericUpDown_StopSpin(objWindow,strGuid,objInput,blnNextValue,true,true);
                        break;
                    case "mouseleave":
                    case "mouseout":
                        //set the focus only if the current object is the focused control
                        var blnFocus = (Focus_GetFocusElementDataId() == strGuid);

                        // Stop up down spin.
                        NumericUpDown_StopSpin(objWindow, strGuid, objInput, blnNextValue, false, blnFocus);
                        break;
                }
            }
        }
    }
}
/// </method>

/// <method name="NumericUpDown_OnBlur">
/// <summary>
///  Occurs when NumericUpDown Blurs
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objInput"></param>
/// <param name="intKeyCode"></param>
function NumericUpDown_OnBlur(strGuid,objInput,objWindow) 
{
    // Check if last spin is out of keyboard source.
    if (Web_IsAttribute(objInput,"vwg_spintype","K",true))
    {
        // Stop up down spin.
        NumericUpDown_StopSpin(objWindow,strGuid,objInput,false,false,false);
    }
    
    // Fire the value changed event .
    NumericUpDown_HandleInputTextChanged(strGuid,objInput,objWindow);
}
/// </method>

/// <method name="NumericUpDown_OnKeyPress">
/// <summary>
/// 
/// </summary>
function NumericUpDown_OnKeyPress(objWindow,strGuid,objInput,objEvent)
{
    // Validate recieved arguments.
    if(objEvent && objInput)
    {
        // Validate event's key code.
        if(!NumericUpDown_IsValidKey(objEvent,objInput))
        {
            // Cancel default behavior.        
            Web_EventCancelBubble(objEvent,true,false);
        }
    }
}
/// </method>

/// <method name="NumericUpDown_OnKeyDown">
/// <summary>
///  Occurs when NumericUpDown  KeyDown pressed
/// </summary>
function NumericUpDown_OnKeyDown(objWindow,strGuid,objInput,objEvent) 
{
    if(!Aux_IsNullOrEmpty(strGuid))
    {
         // Get NumericUpDown node
        var objNode = Data_GetNode(strGuid);
        
        // Get the pressed key
        var intKeyCode = Web_GetEventKeyCode(objEvent);

        //Determines input for  up and down keys
        if(UpDownBase_IsIncrementOrDecrementKey(intKeyCode)) 
        {
            // Start spin.
            NumericUpDown_StartSpin(strGuid,(intKeyCode==mcntUpKey),objWindow,objInput,NumericUpDown_UpdateValue,NumericUpDown_IsValidValue,"K");
        }
        // Check if enter was pressed.
        else if(intKeyCode==mcntEnterKey)
        {
            // Fire the value changed event .
            NumericUpDown_HandleInputTextChanged(strGuid,objInput,objWindow);
        }
    }
}
/// </method>

/// <method name="NumericUpDown_IsValidKey">
/// <summary>
///  
/// </summary>
function NumericUpDown_IsValidKey(objEvent, objInput)
{
    var blnIsValidKey = false;

    if (objEvent)
    {
        // Get key code
        intKeyCode = Web_GetEventKeyCode(objEvent);

        // Validate key code.
        if (!Aux_IsNullOrEmpty(intKeyCode))
        {
            // Check if recieved key is numeric or is related to text navigation or is related to text erasing.
            blnIsValidKey = NumericUpDown_IsNumericKey(intKeyCode) ||
                        Web_IsNavigationKey(intKeyCode) ||
                        [mcntBackspaceKey, mcntDeleteKey].contains(intKeyCode);

            if (!blnIsValidKey)
            {
                // Check if user pressed CTRL + A
                blnIsValidKey = objEvent.ctrlKey && (String.fromCharCode(intKeyCode).toLowerCase() == "a");

                // If key is still not valid.
                if (!blnIsValidKey)
                {
                    // Define permitted keys array.
                    var arrPermittedKeys = ["-", mstrNumberDecimalSeparator];

                    // Loop permitted keys array.
                    for (var intPermittedKeyIndex = 0; intPermittedKeyIndex < arrPermittedKeys.length; intPermittedKeyIndex++)
                    {
                        // Get current permitted key character.
                        var strPermittedKey = arrPermittedKeys[intPermittedKeyIndex];

                        // Check if recieved key is permitted.
                        if (intKeyCode == strPermittedKey.charCodeAt(0))
                        {
                            // Get the current selection	
                            var objSelection = Web_GetSelectionRange(objInput);

                            // Check if current permited key does not already occur in input value
                            // or if current permited key will replace selected part of text.
                            var intIndex = objInput.value.indexOf(strPermittedKey);
                            if ((intIndex == -1) || (intIndex != -1 && objSelection.Start != objSelection.End
                        		&& objSelection.Start <= intIndex && intIndex < objSelection.End))
                            {
                                blnIsValidKey = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
    
    return blnIsValidKey;
}
/// </method>

/// <method name="NumericUpDown_GetFormattedValue">
/// <summary>
///  
/// </summary>
function NumericUpDown_GetFormattedValue(strGuid,objValue) 
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(objValue)) 
    {
        // Get NumericUpDown node
        var objNode = Data_GetNode(strGuid);
        if (objNode) 
        {
            // Get Increment value
            var intDecimalPlaces = parseInt(Xml_GetAttribute(objNode,"Attr.DecimalPlaces","0"),10);
            
            // Parse float value.
            var strFormattedValue = String(objValue.toFixed(intDecimalPlaces));
            
            //split format value to integer and decimal
            var arrFormattedValue = strFormattedValue.split(".");
            
            //get integer value
            var strIntegerValue = arrFormattedValue[0];
            
            // Check if thousands separator should be visible.
            if(Data_IsAttribute(strGuid,"Attr.ThousandsSeparator","1"))
            {
                // Get integer value with thousands separator 
                strIntegerValue = NumericUpDown_GetFormatedThousandsSeparatedValue(strIntegerValue,mstrThousandsSeparator);
            }
            
            // only if there is decimal places then add Decimal Separator
            if(intDecimalPlaces>0)
            {
                // Merge integer formated value with decimal value
                strFormattedValue = strIntegerValue + mstrNumberDecimalSeparator + arrFormattedValue[1];
            }
            else
            {   //set the formated vaule to be the integer value
                strFormattedValue = strIntegerValue;
            }
            
            //return result
            return strFormattedValue;
        }
    }
}
/// </method>

/// <method name="NumericUpDown_GetFormatedThousandsSeparatedValue">
/// <summary>
///  
/// </summary>
function NumericUpDown_GetFormatedThousandsSeparatedValue(strValue,strThousandsSeparator) 
{
    // Define a regular expression object with a proper match.
    var objRegExp = new RegExp("(-?[0-9]+)([0-9]{3})");
    
    // Initialize return value.
    var strThousandsSeparatedValue = strValue;
    
    // Loops while a regular expression match exist.
    while(objRegExp.test(strThousandsSeparatedValue)) 
    {
        // Parse current match with a thousands separator.
        strThousandsSeparatedValue = strThousandsSeparatedValue.replace(objRegExp,"$1"+strThousandsSeparator+"$2");
    }
    
    return strThousandsSeparatedValue;
}
/// </method>

/// <method name="NumericUpDown_UpdateValue">
/// <summary>
///  Update NumericUpDown Value
/// </summary>
function NumericUpDown_UpdateValue(strGuid,objInput,blnNextValue,objWindow,fltCurrentValue) 
{   
    // Get current value.
    var fltNewValue = fltCurrentValue;

    //getting the actual value saved in an attribute in the input text box
    var fltActualValue = Web_GetAttribute(objInput, "vwgactualvalue", true);
    if (fltActualValue == null || fltActualValue == '') {
        fltActualValue = fltNewValue;
    }
    fltActualValue = Number(fltActualValue);
    
    // Get DomainUpDown node
    var objNode = Data_GetNode(strGuid);   
    if (objNode) 
    {           
        //Get Increment value
        var fltIncrement = parseFloat(Xml_GetAttribute(objNode,"Attr.Increment","1"));
        
        // Get Increment value
        var intDecimalPlaces = parseInt(Xml_GetAttribute(objNode, "Attr.DecimalPlaces", "0"), 10);

        // Update the new value according to direction.
        if (blnNextValue) 
        {
            fltActualValue = fltActualValue + fltIncrement;
        }
        else 
        {
            fltActualValue = fltActualValue - fltIncrement;
        }

        //setting the actual value for next usage
        Web_SetAttribute(objInput, "vwgactualvalue", fltActualValue);
        
        //Check if new value exceeded boundries 
        fltActualValue = NumericUpDown_GetValidatedValue(objNode, fltActualValue);

        //setting new value to fit display needs.
        fltNewValue = parseFloat((fltActualValue).toFixed(intDecimalPlaces));
        
        // Check if index has been changed.
        if(fltNewValue!=fltCurrentValue)
        {
            //Update the display input
            UpDownBase_UpdateInputValue(objInput,NumericUpDown_GetFormattedValue(strGuid,fltNewValue));
        }
    }
    
    // Return new value.
    return fltActualValue;
}
/// </method>

/// <method name="NumericUpDown_OnKeyUp">
/// <summary>
/// Handles NumericUpDown MouseUp
/// </summary>
function NumericUpDown_OnKeyUp(strGuid,objInput,objWindow,objEvent) 
{
    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // In case of a key down and up without any speening.
    if (UpDownBase_IsIncrementOrDecrementKey(intKeyCode)) 
    {
        // Stop spinning.
        NumericUpDown_StopSpin(objWindow,strGuid,objInput,(intKeyCode==mcntUpKey),true,false);
    }
}
/// </method>

/// <method name="NumericUpDown_IsNumericKey">
/// <summary>
///  Validate Numeric Key
/// </summary>
/// <param name="intKeyCode"></param>
function NumericUpDown_IsNumericKey(intKeyCode) 
{
    return (!Aux_IsNullOrEmpty(intKeyCode) && (intKeyCode >= 48 && intKeyCode <= 57));
}
/// </method>

/// <method name="NumericUpDown_GetUnformattedValue">
/// <summary>
///  
/// </summary>
function NumericUpDown_GetUnformattedValue(strGuid,objInput) 
{   
    var strUnformattedValue = "";
    
    // Validate recieved arguments.
    if(objInput && !Aux_IsNullOrEmpty(strGuid))
    {
        // Get input's value.
        strUnformattedValue=objInput.value;
        
        // Check if thousands separator should be visible.
        if(Data_IsAttribute(strGuid,"Attr.ThousandsSeparator","1"))
        {
            // Clear the thousands separator character.
            strUnformattedValue = strUnformattedValue.replace(new RegExp("[" + mstrThousandsSeparator + "]","g"),"");
        }
        
        // Replace the number decimal separator character with a point.
        strUnformattedValue=strUnformattedValue.replace(mstrNumberDecimalSeparator,".");
    }
    
    return strUnformattedValue;
}
/// </method>

/// <method name="NumericUpDown_HandleInputTextChanged">
/// <summary>
///  
/// </summary>
function NumericUpDown_HandleInputTextChanged(strGuid,objInput,objWindow) 
{    
    // Check that text was changed.
    if(UpDownBase_IsTextChanged(strGuid,objInput)) 
    {
        // Get input's value.
        var strValue = NumericUpDown_GetUnformattedValue(strGuid,objInput);
        
        // Validate input value.
        if( NumericUpDown_IsNumericValue(strValue))
        {
            // Get the numericupdown node.
            var objNode = Data_GetNode(strGuid);
            if(objNode)
            {
                //Check if new value exceeded boundries 
                strValue = String(NumericUpDown_GetValidatedValue(objNode,parseFloat(strValue)));
                
                // Check if index has been changed.
                if(!Xml_IsAttribute(objNode,"Attr.Value",strValue))
                {
                    // Get formated value.
            		var strFormatedValue=NumericUpDown_GetFormattedValue(strGuid,parseFloat(strValue));
                    
                    // Set the new value attribute.
            		Data_SetNodeAttribute(objNode, "Attr.Value", strValue);
                    
                    // Set the new text attribute.
            		Data_SetNodeAttribute(objNode, "Attr.Text", strFormatedValue);

                    //setting the actual value for next usage
                    Web_SetAttribute(objInput, "vwgactualvalue", strValue);

                    // Fire the value changed event 
                    UpDownBase_FireValueChange(strGuid,strValue,false);
                    
                    // Set formated value for input.
                    strValue = strFormatedValue;
                }
            }
        }
        else
        {
            // Get text value from meta data.
            strValue=Data_GetAttribute(strGuid,"Attr.Text","");
        }
        
        // Update input with meta data text.
        UpDownBase_UpdateInputValue(objInput,strValue);
    }
}
/// </method>

/// <method name="NumericUpDown_IsNumericValue">
/// <summary>
/// 
/// </summary>
function NumericUpDown_IsNumericValue(strValue)
{ 
    // Check if recieved value is not empty.
    var blnIsNumericValue = !Aux_IsNullOrEmpty(strValue);
    
    if(blnIsNumericValue)
    {
        // Check if recieved value has a proper minus sign (if any).
        blnIsNumericValue=(strValue.lastIndexOf("-")<=0);
        
        if(blnIsNumericValue)
        {   
            // Check if recieved value has one point character at the most.
            blnIsNumericValue=(strValue.split(".").length<3);
        }
    }
    
    return blnIsNumericValue;
}
/// </method>

/// <method name="NumericUpDown_IsValidValue">
/// <summary>
/// 
/// </summary>
function NumericUpDown_IsValidValue(strGuid,lngValue,enmDirection)
{   
    var blnValidValue = false;
    
    // Validate domain up down node.
    if (!Aux_IsNullOrEmpty(strGuid)) 
    {
        // Get domainupdown node
        var objNode = Data_GetNode(strGuid);
        if(objNode)
        {
            // Get minimal value.
            var fltMinimum = parseFloat(Xml_GetAttribute(objNode,"Attr.Minimum","0"));
            
            // Get maximal value.
            var fltMaximum = parseFloat(Xml_GetAttribute(objNode,"Attr.Maximum","100"));
        
            //Get Increment value.
            var fltIncrement = parseFloat(Xml_GetAttribute(objNode,"Attr.Increment","1"));
            
            switch(enmDirection)
            {
                case 0:
                   blnValidValue = (lngValue>=fltMinimum && lngValue<=fltMaximum);
                   break; 
                case 1:
                   blnValidValue = ((lngValue-fltIncrement)>=fltMinimum);
                   break; 
                case 2:
                   blnValidValue = ((lngValue+fltIncrement)<=fltMaximum);
                   break;
            }
        }
    }
    
    return blnValidValue;
}
/// </method>

/// <method name="NumericUpDown_StopSpin">
/// <summary>
///  
/// </summary>
function NumericUpDown_StopSpin(objWindow,strGuid,objInput,blnNextValue,blnUpdateNextValue,blnFocusInput) 
{
    // Initialize the spin type attribute.
    Web_SetAttribute(objInput,"vwg_spintype","");
    
    // Stops spin.
    UpDownBase_StopSpin(objWindow, strGuid, objInput, blnNextValue, blnUpdateNextValue, false, blnFocusInput, NumericUpDown_StopSpinCallback);    
}
/// </method>

/// <method name="NumericUpDown_StopSpinCallback">
/// <summary>
///  Callback for text and value attributes update.
/// </summary>
function NumericUpDown_StopSpinCallback(fltValue, strGuid)
{
    if (!Aux_IsNullOrEmpty(fltValue))
    {
        // Get data node
        var objNode = Data_GetNode(strGuid);

        // Set the new value attribute.
        Data_SetNodeAttribute(objNode, "Attr.Value", String(fltValue));

        // Set the new text attribute.
        Data_SetNodeAttribute(objNode, "Attr.Text", NumericUpDown_GetFormattedValue(strGuid, fltValue));
    }
}
/// </method>

/// <method name="NumericUpDown_GetValidatedValue">
/// <summary>
// Check if new value exceeded boundries and fix its value.
/// </summary>
function NumericUpDown_GetValidatedValue(objNode,fltValue)
{
    //Get minimal value.
    var fltMinimum = parseFloat(Xml_GetAttribute(objNode,"Attr.Minimum","0"));
    
    //Get maximal value.
    var fltMaximum = parseFloat(Xml_GetAttribute(objNode,"Attr.Maximum","100"));
    
    //Check if new value exceeded boundries and fix its value.
    if (fltValue>fltMaximum) 
    {
        fltValue = fltMaximum;
    }
    else if(fltValue<fltMinimum) 
    {
        fltValue = fltMinimum;
    }
    
    return fltValue;
}  
/// </method>

/// <method name="NumericUpDown_StartSpin">
/// <summary>
/// Start to spin NumericUpDown Controls
/// </summary>
function NumericUpDown_StartSpin(strGuid,blnNextValue,objWindow,objInput,fncUpdateDelegate,fncValidationDelegate,strSpinType) 
{
    // Set the spin type attribute.
    Web_SetAttribute(objInput,"vwg_spintype",strSpinType);
    
    // Handle input text change - for cases when input is focused before the up/down button is clicked.
    NumericUpDown_HandleInputTextChanged(strGuid,objInput,objWindow);
    
    // Start to spin DomainUpDown Controls.
    UpDownBase_StartSpin(strGuid,blnNextValue,objWindow,fncUpdateDelegate,fncValidationDelegate);
}
/// </method>