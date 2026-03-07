/// <method name="UpDownBase_FireValueChange">
/// <summary>
///  
/// </summary>
function UpDownBase_FireValueChange(strGuid,strValue,blnIsIndex) 
{
    if (!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strValue)) 
    {
        // Fire the value change event.                                   
        var objEvent=Events_CreateEvent(strGuid,"ValueChange",null,true);

        // Add the is index attribute.
        if (blnIsIndex) 
        {
            Events_SetEventAttribute(objEvent,"Attr.Index","1");
        }

        // Add value attribute.      
        Events_SetEventAttribute(objEvent,"Attr.Value",strValue);

        ///Raise Event if critical       
        if (Data_IsCriticalEvent(strGuid, "Event.ValueChange"))
        {
            Events_RaiseEvents();
        }

        Events_ProcessClientEvent(objEvent);
    }
}
/// </method>   

/// <method name="UpDownBase_UpdateInputValue">
/// <summary>
///  Update Client Gui 
/// </summary>
function UpDownBase_UpdateInputValue(objInput,strValue) 
{
    //Validate Recived Arguments
    if (objInput) 
    {
        //Set the value
        objInput.value=strValue;
    }
}
/// </method>   

/// <method name="UpDownBase_IsIncrementOrDecrementKey">
/// <summary>
/// Determine Up Arown Or Down Arow Keys
/// </summary>
/// <param name="intKeyCode"></param>
function UpDownBase_IsIncrementOrDecrementKey(intKeyCode) 
{
    return (!Aux_IsNullOrEmpty(intKeyCode) && [mcntUpKey,mcntDownKey].contains(intKeyCode));
}
/// </method>   

/// <method name="UpDownBase_StartSpin">
/// <summary>
/// Start to spin UpDown Controls
/// </summary>
function UpDownBase_StartSpin(strGuid,blnNextValue,objWindow,fncUpdateDelegate,fncValidationDelegate) 
{
    if(!UpDownBase_StartSpin.SpinInterval)
    {
        // Preserve function parameters.
        UpDownBase_StartSpin.Window=objWindow;
        UpDownBase_StartSpin.Input=Web_GetElementById("UDB_Input_" + strGuid,objWindow);
        UpDownBase_StartSpin.Guid=strGuid;
        UpDownBase_StartSpin.NextValue=blnNextValue;
        UpDownBase_StartSpin.UpdateDelegate=fncUpdateDelegate;
        UpDownBase_StartSpin.ValidationDelegate=fncValidationDelegate;
    
        // Get domainupdown node
        var objNode = Data_GetNode(strGuid);
        if(objNode)
        {
            // Get current value.
            UpDownBase_StartSpin.SpinValue = Number(Xml_GetAttribute(objNode,"Attr.Value","-1"));
            
            // Validate current index boundries
            if(fncValidationDelegate && fncValidationDelegate(strGuid,UpDownBase_StartSpin.SpinValue,(blnNextValue?2:1)))
            {   
                // Start spin.
                UpDownBase_StartSpin.SpinInterval=Web_SetInterval("mobjApp.UpDownBase_Spin()",200,objWindow);                    
            }
        }
    }
}
/// </method>   

/// <method name="UpDownBase_Spin">
/// <summary>
///
/// </summary>
function UpDownBase_Spin() 
{
    // Restore function parameters.
    var objWindow=UpDownBase_StartSpin.Window;
    var objInput=UpDownBase_StartSpin.Input;
    var strGuid=UpDownBase_StartSpin.Guid;
    var blnNextValue=UpDownBase_StartSpin.NextValue;
    var objSpinValue=UpDownBase_StartSpin.SpinValue;
    var fncUpdateDelegate=UpDownBase_StartSpin.UpdateDelegate;

    if(fncUpdateDelegate)
    {
        // Invoke the recieved handler.
        UpDownBase_StartSpin.SpinValue=fncUpdateDelegate(strGuid,objInput,blnNextValue,objWindow,objSpinValue);
    }

}
/// </method>   

/// <method name="UpDownBase_StopSpin">
/// <summary>
///  
/// </summary>
function UpDownBase_StopSpin(objWindow,strGuid,objInput,blnNextValue,blnUpdateNextValue,blnIsIndex,blnFocusInput, fncStopSpinCallback) 
{
    // Define empty spin value.
    var intSpinValue = null;
    
    // Preserve delgates of last spin.
    var fncUpdateDelegate = UpDownBase_StartSpin.UpdateDelegate;
    var fncValidationDelegate = UpDownBase_StartSpin.ValidationDelegate;
    
    if(UpDownBase_StartSpin.SpinInterval)
    {
        // Get spin value.
        intSpinValue = UpDownBase_StartSpin.SpinValue;
        
        // Stop spinning  
        if(UpDownBase_StartSpin.Window)
        {
            // Clear previous scrolling interval.
            Web_ClearInterval(UpDownBase_StartSpin.SpinInterval,UpDownBase_StartSpin.Window);   
            
            // Initialize spin arguments.
            UpDownBase_StartSpin.SpinInterval=null;
            UpDownBase_StartSpin.Window=null;
            UpDownBase_StartSpin.Input=null;
            UpDownBase_StartSpin.Guid=null;
            UpDownBase_StartSpin.NextValue=null;
            UpDownBase_StartSpin.UpdateDelegate=null;
            UpDownBase_StartSpin.ValidationDelegate=null;
            UpDownBase_StartSpin.SpinValue=null;
        }
    }
    
    // Check if spinning was'nt activated.
    if(blnUpdateNextValue)
    {
        //Get the input control  
        var objInput = UpDownBase_GetInputElement(strGuid,objWindow);
        
        // Get domainupdown node
        var objNode = Data_GetNode(strGuid);
        if(objNode)
        {
            // Set current value to spin value.
            var intCurrentValue = intSpinValue;
            
            // Check if spin value is null.
            if(Aux_IsNullOrEmpty(intCurrentValue))
            {
                // Get current node value attriute.
                intCurrentValue = Number(Xml_GetAttribute(objNode,"Attr.Value","0"));
            }
            
            // Validate current index boundries
            if(fncValidationDelegate && fncValidationDelegate(strGuid,intCurrentValue,(blnNextValue?2:1)))
            {
                // Perform a single value update
                intSpinValue=fncUpdateDelegate(strGuid,objInput,blnNextValue,objWindow,intCurrentValue);
            }
        }
    }    
    
    // Check that current value is different from the spin value.
    if( !Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(intSpinValue) &&
        !Data_IsAttribute(strGuid,"Attr.Value",intSpinValue))
    {
        // Call stop spin callback to update value and text
        if (typeof fncStopSpinCallback === "function")
        {
            fncStopSpinCallback(intSpinValue, strGuid);
        }
           
        // Fire value change.
        UpDownBase_FireValueChange(strGuid,intSpinValue,blnIsIndex);
    }
    
    if(blnFocusInput)
    {
        Web_SetFocus(objInput,true);
    }
    
    return intSpinValue;
}
/// </method>   

/// <method name="UpDownBase_GetInputElement">
/// <summary>
/// 
/// </summary>
function UpDownBase_GetInputElement(strGuid,objWindow) 
{
    if(!Aux_IsNullOrEmpty(strGuid) && objWindow)
    {
        return Web_GetElementById("UDB_Input_" + strGuid,objWindow);
    }
}
/// </method>

/// <method name="UpDownBase_IsTextChanged">
/// <summary>
///
/// </summary>
function UpDownBase_IsTextChanged(strGuid,objInput) 
{
    // Validate recieved arguments.
    if (objInput && !Aux_IsNullOrEmpty(strGuid)) 
    {
        // Check the text attribute.
        var strDecodeText = Aux_DecodeText(objInput.value);
        return !Data_IsAttribute(strGuid,"Attr.Text",strDecodeText);
    }
    
    return false;
}
/// </method> 

/// <method name="UpDownBase_SetSelection">
/// <summary>
///
/// </summary>
function UpDownBase_SetSelection(strGuid,strStart,strLength)
{   
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(strStart) && !Aux_IsNullOrEmpty(strLength))
    {
        // Get active window.
        var objWindow = Web_GetActiveWindow();
        if(objWindow)
        {
            // Get target element by data id.
            var objTargetElement = Web_GetElementById("UDB_Input_" + strGuid, objWindow);
            if(objTargetElement)
            {
                // Set selection.
                Web_SetSelection(objTargetElement,parseInt(strStart,10),parseInt(strLength,10));
            }
        }
    }
}
/// </method> 