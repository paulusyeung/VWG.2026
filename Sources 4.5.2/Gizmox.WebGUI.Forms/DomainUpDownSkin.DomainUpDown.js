/// <method name="DomainUpDown_HandleEvents">
/// <summary>
/// Fires the right action to take by the given event 
/// </summary>
function DomainUpDown_HandleEvents(strGuid,strAction,objWindow,objEvent) 
{
    // Validate recieved arguments
    if (!Aux_IsNullOrEmpty(strGuid) && !Data_IsDisabled(strGuid)) 
    {
        // User textbox input
        var objInput = UpDownBase_GetInputElement(strGuid,objWindow);
        
         // Get the pressed key
        var intKeyCode = Web_GetEventKeyCode(objEvent);
          
        //Set action
        switch (strAction) 
        {
            case "keydown":                
                DomainUpDown_OnKeyDown(objWindow,strGuid,objInput,objEvent);
                break;
            case "blur":
                DomainUpDown_OnBlur(strGuid,objInput,objWindow);
                break;
            case "keyup":
                DomainUpDown_OnKeyUp(objWindow,strGuid,objInput,objEvent);
                break;
        }
    }
}
/// </method>

/// <method name="DomainUpDown_HandleMouseEvents">
/// <summary>
/// Handle the mouse Events
/// </summary>
function DomainUpDown_HandleMouseEvents(objElement,strType,objWindow) 
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
            // Get domain updown node
            var objNode = Data_GetNode(strGuid);
            if(objNode)
            {
                //Get current node value attriute
                var intCurrentValue = parseInt(Xml_GetAttribute(objNode,"Attr.Value",0));
            
                //Get the input control  
                var objInput = UpDownBase_GetInputElement(strGuid,objWindow);
                
                // Check if up button or down button has been pressed.
                var blnNextValue = (strElementId.substring(0,6)=="UDB_U_");

                // Switch action type.
                switch (strType) 
                {
                    case "mousedown":                        
                        // Start up down spin.
                        DomainUpDown_StartSpin(strGuid,blnNextValue,objWindow,objInput,DomainUpDown_UpdateValue,DomainUpDown_IsValidValue,"M");
                        break;
                    case "click":
                        // Stop up down spin.
                        DomainUpDown_StopSpin(objWindow,strGuid,objInput,blnNextValue,true,true);
                        break;
                    case "mouseleave":
                    case "mouseout":
                        //set the focus only if the current object is the focused control
                        var blnFocus = (Focus_GetFocusElementDataId() == strGuid);

                        // Stop up down spin.
                        DomainUpDown_StopSpin(objWindow, strGuid, objInput, blnNextValue, false, blnFocus);
                        break;
                }
            }
        }
    }
}
/// </method>

/// <method name="DomainUpDown_HandleInputTextChanged">
/// <summary>
///  
/// </summary>
function DomainUpDown_HandleInputTextChanged(strGuid,objInput,objWindow) 
{    
    // Check that text was changed.
    if (UpDownBase_IsTextChanged(strGuid,objInput)) 
    {
        // Get default value out of input.
        var strText = Aux_EncodeText(objInput.value);

        // Get data node
        var objNode = Data_GetNode(strGuid);

        // Set the new text attribute.
        Data_SetNodeAttribute(objNode, "Attr.Text", strText);
        
        // Define an empty index.
        var intIndex = null;
        
        // Define default index flag to false.
        var blnIsIndex = false;
        
        // Try getting an exist option in a higher position then the current value.
        var objExistOption = DomainUpDown_GetOptionByText(strGuid,strText);
        
        // Check if an exist option found.
        if (objExistOption) 
        {
            // Update value to the position of the exist option.
            intIndex = Xml_GetPosition(objExistOption);
            
            // Set the new value attribute.
            Data_SetNodeAttribute(objNode, "Attr.Value", intIndex);
            
            // Flag that value is index.
            blnIsIndex = true;
        }
        
        // Fire the value changed event 
        UpDownBase_FireValueChange(strGuid,(blnIsIndex?intIndex:strText),blnIsIndex);
    }
}
/// </method>

/// <method name="DomainUpDown_OnBlur">
/// <summary>
///  Occurs when DomainUpDown Blurs
/// </summary>
function DomainUpDown_OnBlur(strGuid,objInput,objWindow) 
{    
    // Check if last spin is out of keyboard source.
    if (Web_IsAttribute(objInput,"vwg_spintype","K",true))
    {
        // Stop up down spin.
        DomainUpDown_StopSpin(objWindow,strGuid,objInput,false,false,false);
    }
    
    // Handle input value changed.
    DomainUpDown_HandleInputTextChanged(strGuid,objInput,objWindow);
}
/// </method>

/// <method name="DomainUpDown_OnKeyDown">
/// <summary>
///   Occurs when DomainUpDown  KeyDown pressed
/// </summary>
function DomainUpDown_OnKeyDown(objWindow,strGuid,objInput,objEvent) 
{  
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid))
    {
        // Get DomainUpDown node
        var objNode = Data_GetNode(strGuid);
        
        // Get input value.
        var strInputValue = objInput.value;
        
        // Get the pressed key
        var intKeyCode = Web_GetEventKeyCode(objEvent);
      
        //Is Increment Or DecrementKey
        if (UpDownBase_IsIncrementOrDecrementKey(intKeyCode))
        {   
            // Start spin.
            DomainUpDown_StartSpin(strGuid,(intKeyCode==mcntUpKey),objWindow,objInput,DomainUpDown_UpdateValue,DomainUpDown_IsValidValue,"K");
        }
        // Check if enter was pressed.
        else if(intKeyCode==mcntEnterKey)
        {
            // Handle input value changed.
            DomainUpDown_HandleInputTextChanged(strGuid,objInput,objWindow);                
        }
    }
}
/// </method>

/// <method name="DomainUpDown_UpdateValue">
/// <summary>
/// 
/// </summary>
function DomainUpDown_UpdateValue(strGuid,objInput,blnNextValue,objWindow,intCurrentValue) 
{    
    // Get current option position
    var intNewIndex=intCurrentValue;
    
    // Get DomainUpDown node
    var objNode = Data_GetNode(strGuid);   
    if (objNode) 
    {
        // Get maximal item index.
        var intOptionsCount = DomainUpDown_GetOptionsCount(objNode);

        // Determines up down direction                                 		        
        if (blnNextValue)
        {            
            if(intNewIndex>0)
            {
                intNewIndex--;
            }
        }
        else if (intNewIndex<intOptionsCount - 1) 
        {
            intNewIndex++;
        }
        
        // Check if index has been changed.
        if(intNewIndex!=intCurrentValue)
        {
            // Get the new option node.
            var objNewOption = DomainUpDown_GetOptionByIndex(objNode,intNewIndex);
            if (objNewOption) 
            {
                var strCurrentText = Xml_GetAttribute(objNewOption,"Attr.Text","",true);
                
                //Update the display input
                UpDownBase_UpdateInputValue(objInput,strCurrentText);
            }
        }
    }
    
    // Return new index.
    return intNewIndex;
}
/// </method>

/// <method name="DomainUpDown_OnKeyUp">
/// <summary>
/// 
/// </summary>
function DomainUpDown_OnKeyUp(objWindow,strGuid,objInput,objEvent) 
{
    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // In case of a key down and up without any speening.
    if (UpDownBase_IsIncrementOrDecrementKey(intKeyCode)) 
    {
        // Start spinning.
        DomainUpDown_StopSpin(objWindow,strGuid,objInput,(intKeyCode==mcntUpKey),true,false);
    }
}
/// </method>

/// <method name="DomainUpDown_GetOptionByText">
/// <summary>
/// 
/// </summary>
function DomainUpDown_GetOptionByText(strGuid,strText) 
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid)) 
    {
        // Get domainupdown node
        var objNode = Data_GetNode(strGuid);
        if(objNode) 
        {
            // Select a single node.
            return Xml_SelectSingleNode("Tags.Options/Tags.Option[@Attr.Text='"+strText+"']",objNode);
        }
    }
}
/// </method>

/// <method name="DomainUpDown_GetOptionByIndex">
/// <summary>
///	Gets a DomainUpDown option by index
/// </summary>
function DomainUpDown_GetOptionByIndex(objNode,intIndex) 
{
    // Validate recieved arguments.
    if (objNode) 
    {
        return Xml_SelectSingleNode("Tags.Options/Tags.Option[position()="+String(intIndex+1)+"]",objNode);
    }
}
/// </method>

/// <method name="DomainUpDown_GetOptionsCount">
/// <summary>
/// 
/// </summary>
function DomainUpDown_GetOptionsCount(objNode) 
{       
    // Validate recieved arguments.
    if (objNode) 
    {
        // Get the options node.
        var objOptions = Xml_SelectSingleNode("Tags.Options",objNode);
        if(objOptions)
        {
            // Returns options count.
            return objOptions.childNodes.length;
        }
    }
    
    return 0;
}
/// </method>

/// <method name="DomainUpDown_IsValidValue">
/// <summary>
/// 
/// </summary>
function DomainUpDown_IsValidValue(strGuid,intValue,enmDirection)
{   
    var blnValidValue = false;

    // Validate domain up down node.
    if (!Aux_IsNullOrEmpty(strGuid)) 
    {
        // Get domainupdown node
        var objNode = Data_GetNode(strGuid);
        if(objNode)
        {
            // Get options count.
            var intOptionsCount = DomainUpDown_GetOptionsCount(objNode);
            
            switch(enmDirection)
            {
                case 0:
                   blnValidValue = (intValue>=0 && intValue<intOptionsCount);
                   break; 
                case 1:
                   blnValidValue = (intValue<(intOptionsCount - 1));
                   break; 
                case 2:
                   blnValidValue = (intValue>0);
                   break;
            }
        }
    }
    
    return blnValidValue;   
}
/// </method>

/// <method name="DomainUpDown_StopSpin">
/// <summary>
///  
/// </summary>
function DomainUpDown_StopSpin(objWindow,strGuid,objInput,blnNextValue,blnUpdateNextValue,blnFocusInput) 
{
    // Initialize the spin type attribute.
    Web_SetAttribute(objInput,"vwg_spintype","");
    
    // Stops spin.
    UpDownBase_StopSpin(objWindow, strGuid, objInput, blnNextValue, blnUpdateNextValue, true, blnFocusInput, DomainUpDown_StopSpinCallback);
}
/// </method>

/// <method name="DomainUpDown_StopSpinCallback">
/// <summary>
///  Callback for text and value attributes update.
/// </summary>
function DomainUpDown_StopSpinCallback(intIndex, strGuid)
{
    if (!Aux_IsNullOrEmpty(intIndex))
    {
        // Get domain updown node
        var objNode = Data_GetNode(strGuid);
        if (objNode)
        {
            // Get the new option node.
            var objOption = DomainUpDown_GetOptionByIndex(objNode, intIndex);
            if (objOption)
            {
                // Set the new text attribute.
                Data_SetNodeAttribute(objNode, "Attr.Text", Xml_GetAttribute(objOption, "Attr.Text", ""));
            }

            // Set the new value attribute.
            Data_SetNodeAttribute(objNode, "Attr.Value", String(intIndex));
        }
    }
}
/// </method>

/// <method name="DomainUpDown_StartSpin">
/// <summary>
/// Start to spin DomainUpDown Controls
/// </summary>
function DomainUpDown_StartSpin(strGuid,blnNextValue,objWindow,objInput,fncUpdateDelegate,fncValidationDelegate,strSpinType) 
{
    // Set the spin type attribute.
    Web_SetAttribute(objInput,"vwg_spintype",strSpinType);
    
    // Handle input text change - for cases when input is focused before the up/down button is clicked.
    DomainUpDown_HandleInputTextChanged(strGuid,objInput,objWindow);
    
    // Start to spin DomainUpDown Controls.
    UpDownBase_StartSpin(strGuid,blnNextValue,objWindow,fncUpdateDelegate,fncValidationDelegate);
}
/// </method>