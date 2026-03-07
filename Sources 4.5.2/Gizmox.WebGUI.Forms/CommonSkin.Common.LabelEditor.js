// Representor of the window which contain the current label editor.
var mobjLabelEditorWindow = null;


/// <method name="LabelEditor_FireAfterLabelEdit">
/// <summary>
/// Firess end edit event.
/// </summary>
function LabelEditor_FireAfterLabelEdit(strGuid,strValue)
{
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Create an AfterLabelEdit event.
        var objVwgEvent = Events_CreateEvent(strGuid,"AfterLabelEdit",null,true); 
        Events_SetEventAttribute(objVwgEvent, "Text", strValue);        
        
        // Fire if critical.
        if (Data_IsCriticalEvent(strGuid, "Event.AfterLabelEdit"))
        {
            Events_RaiseEvents();
        }
        
		Events_ProcessClientEvent(objVwgEvent);
    }
}
/// </method>

/// <method name="LabelEditor_Hide">
/// <summary>
/// Handles element editing
/// </summary>
function LabelEditor_Hide()
{
    if(mobjLabelEditorWindow)
    {
        // Get the edit element.
        var objEditElement = Web_GetElementById("VWG_LabelEditor",mobjLabelEditorWindow);
        if(objEditElement)
        {
            // Clear the Guid attribute.
            Web_SetAttribute(objEditElement,"vwgguid","");
        }
        
        // Get the edit element container.
        var objEditElementContainer = Web_GetElementById("VWG_LabelEditorContainer",mobjLabelEditorWindow);
        if(objEditElementContainer)
        {
            // Hide the edit element container.
            objEditElementContainer.style.visibility="hidden";
        }
    }
    
    // Clear input value.
    LabelEditor_Clear();
}
/// </method>

/// <method name="LabelEditor_OnBlur">
/// <summary>
/// Handles edited element on blur.
/// </summary>
function LabelEditor_OnBlur(objEvent,objWindow)
{   
    if(objWindow)
    {
        // Get the edit element.
        var objEditElement = Web_GetElementById("VWG_LabelEditor",objWindow);
        if(objEditElement)
        {
            // Get the edit input element.
            var objEditElementInput = Web_GetElementById("VWG_LabelEditorInput",objWindow);
            if(objEditElementInput)
            {
                if(objEvent)
                {
                    // Cancel buble.
                    Web_EventCancelBubble(objEvent);
                }
                
                // Get the Guid attribute.
                var strGuid = Web_GetAttribute(objEditElement,"vwgguid",true);
                if(!Aux_IsNullOrEmpty(strGuid))
                {
                    // Get input value.
                    var strValue = objEditElementInput.value;
                    
                    // Fires the EndEdit event.
                    LabelEditor_FireAfterLabelEdit(strGuid,strValue);
                    
                    // Set the label's new text.
                    LabelEditor_SetLabelText(strGuid,strValue);
                }
            }
            
            // Hide the edit element.
            LabelEditor_Hide();
        }
    }
}
/// </method>

/// <method name="LabelEditor_SetLabelText">
/// <summary>
/// Set the receieved label's text.
/// </summary>
function LabelEditor_SetLabelText(strGuid,strText)
{
    if(mobjLabelEditorWindow)
    {
        // Get the receieved element's label editor element.
        var objNodeElement = Web_GetElementById("VWGLE_"+strGuid,mobjLabelEditorWindow);
        if(objNodeElement)
        {   
            // Set the element's inner text.
            if(!Aux_IsNullOrEmpty(strText))
            {
                // Set element's inner text.
                Web_SetInnerText(objNodeElement,strText);
            }
            else
            {
                // Set element's inner html to a default single space character.
                Web_SetInnerHtml(objNodeElement,"&nbsp;");
            }
        }
    }
}
/// </method>

/// <method name="LabelEditor_Show">
/// <summary>
/// Handles element editing
/// </summary>
function LabelEditor_Show(strElementGuid,objWindow)
{   
    // Validate the received elemen's guid.
    if(!Aux_IsNullOrEmpty(strElementGuid))
    {
        // Check the recieved window.
        if(objWindow)
        {
            mobjLabelEditorWindow = objWindow;
        }   
        // Check if the label editor's window is still null.
        else 
        {
            // Get the label editor's window by the receieved element's guid.
            mobjLabelEditorWindow = Forms_GetWindowByDataId(strElementGuid);
        }
        
        if(mobjLabelEditorWindow)
        {        
            // Get the receieved element's label editor element.
            var objNodeElement = Web_GetElementById("VWGLE_"+strElementGuid,mobjLabelEditorWindow);
            
            // Validate the received node element.
            if(objNodeElement)
            {
                // Get initial text out of the receieved element's inner text.
                var strInitialText = Web_GetInnerText(objNodeElement);
                
                var objLabelEditorElementNode = Data_GetNode(strElementGuid);
                Xml_SetAttribute(objLabelEditorElementNode,"Attr.Text",strInitialText);

                // Get the edit element.
                var objEditElement = Web_GetElementById("VWG_LabelEditor",mobjLabelEditorWindow);
                if(objEditElement)
                {
                    // Scrolls into view.
                    Web_ScrollIntoView(objNodeElement,null,0);
                    
                    // Set the Guid attribute.
                    Web_SetAttribute(objEditElement,"vwgguid",strElementGuid);
                    
                    // Get the rect of the received element.
                    var objElementRect = Web_GetRect(objNodeElement);
                    if(objElementRect)
                    {      
                        // Get the edit element style
                        var objEditElementStyle = objEditElement.style;
                        
                        // Position the edit element.   
                        objEditElementStyle.top = objElementRect.top + "px";
                        objEditElementStyle.left = objElementRect.left + "px";
                        
                        // Set the edit element sizes (add 2 pixels for each of the border edges).
                        objEditElementStyle.height = ((objElementRect.bottom - objElementRect.top) + 4) + "px";
                        objEditElementStyle.width = ((objElementRect.right - objElementRect.left) + 4) + "px";
                        
                        // Set the edit element's minimal width.
                        objEditElementStyle.minWidth = objEditElement.style.width;
                        
                        // Get the edit input element.
                        var objEditElementInput = Web_GetElementById("VWG_LabelEditorInput",mobjLabelEditorWindow);
                        if(objEditElementInput)
                        {
                            // Initialize the input value.
                            objEditElementInput.value = !Aux_IsNullOrEmpty(strInitialText)?strInitialText:"";
                            
                            // Get the edit element container.
                            var objEditElementContainer = Web_GetElementById("VWG_LabelEditorContainer",mobjLabelEditorWindow);
                            if(objEditElementContainer)
                            {
                                // Displaythe edit element container.
                                objEditElementContainer.style.visibility="visible";
                            }
                            
                            // Select all of the input's value.
                            if(objEditElementInput.value)
                            {   
                                Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_SetSelection,objEditElementInput,0,objEditElementInput.value.length),10);
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="LabelEditor_OnKeyDown">
/// <summary>
/// Handles input key down.
/// </summary>
function LabelEditor_OnKeyDown(objInput,objEvent,objWindow)
{
    // Validate the received event.
    if(objEvent)
    {
        // Cancel bubbling.
        Web_EventCancelBubble(objEvent,false,true);
        
        // Validate the received input element.
        if(objInput)
        {
            // Get the edit input element.
            var objEditElement = Web_GetElementById("VWG_LabelEditor",objWindow);
            if(objEditElement)
            {
                // Get key code out of html event.
                var intKeyCode = Web_GetEventKeyCode(objEvent);
            
                // Handle the enter and escape keys. 
                if(intKeyCode == mcntEnterKey || intKeyCode == mcntEscapeKey)
                { 
                    // Prevent default behavior.
                    Web_EventCancelBubble(objEvent,true,false);
                    
                    // Get the vwgguid out of the edit element.
                    var strGuid = Web_GetAttribute(objEditElement,"vwgguid",true);
                    if(!Aux_IsNullOrEmpty(strGuid))
                    {
                        // Get input's value.
                        var strNewValue = objInput.value;
                        
                        // Handle the escape key.
                        if(intKeyCode == mcntEscapeKey)
                        {   
                            // Get the element's node.
                            var objElementNode = Data_GetNode(strGuid);
                            if(objElementNode)
                            {
                                // Get node's previous value from xml.
                                strNewValue = Xml_GetAttribute(objElementNode,"Attr.Text","",true);
                            }
                        }
                        
                        // Fires the EndEdit event.
                        LabelEditor_FireAfterLabelEdit(strGuid,strNewValue);
                        
                        // Set the label's new text.
                        LabelEditor_SetLabelText(strGuid,strNewValue);
                    }
                    
                    // Hide edit element.
                    LabelEditor_Hide();
                }
                else
                {
                    // Synchronise input size.
                    LabelEditor_SynchInputSize();
                }
            }
        }
    }
}
/// </method>

/// <method name="LabelEditor_SynchInputSize">
/// <summary>
/// Synchronizes input size.
/// </summary>
function LabelEditor_SynchInputSize()
{
    if (mobjLabelEditorWindow)
    {
        // Get the messuring BR element.   
        var objEditElementBr = Web_GetElementById("VWG_LabelEditorBr", mobjLabelEditorWindow);
        if (objEditElementBr)
        {
            // Get the edit element.
            var objEditElement = Web_GetElementById("VWG_LabelEditor", mobjLabelEditorWindow);
            if (objEditElement)
            {
                // Get the edit input element.
                var objEditElementInput = Web_GetElementById("VWG_LabelEditorInput", mobjLabelEditorWindow);
                if (objEditElementInput)
                {
                    // Set the BR innerHTML.
                    Web_SetInnerHtml(objEditElementBr, objEditElementInput.value);

                    // Set the edit element's width.
                    objEditElement.style.width = (objEditElementBr.clientWidth + 3) + "px";
                }
            }
        }
    }
}
/// </method>