/// <page name="Common.Focus.js">
/// <summary>
/// This script is used as a shared script.
/// </summary>

var Focus = {};
var marrFocusElementDataIds = [];

/// <method name="Focus_GetFocusElementDataId">
/// <summary>
/// 
/// </summary>
function Focus_GetFocusElementDataId(strWindowGuid)
{
    var strFocusElementDataId = "";
    
    // Validate recieved window id.
    if(Aux_IsNullOrEmpty(strWindowGuid))
    {
        // Get active window id.
        strWindowGuid=mstrActiveWindowGuid;
    }
    
    // Validate recieved window id.
    if(!Aux_IsNullOrEmpty(strWindowGuid))
    {
        // Get the focus element guid for the recieved window.
        strFocusElementDataId = marrFocusElementDataIds[Data_GetDataId(strWindowGuid)];
	}
	
	return strFocusElementDataId;
}
/// </method>

/// <method name="Focus_SetFocusElementDataId">
/// <summary>
/// 
/// </summary>
function Focus_SetFocusElementDataId(strFocusedElementGuid,strFocusedElementFormGuid,objFocusedElementDataNode)
{
    // Check if recieved a focused element without focused element's form.
    if(!Aux_IsNullOrEmpty(strFocusedElementGuid) && Aux_IsNullOrEmpty(strFocusedElementFormGuid))
    {
        // Get focused element's form node.
        var objFocusedElementFormNode = Data_GetFormNodeByDataId(strFocusedElementGuid,false,objFocusedElementDataNode);
        if(objFocusedElementFormNode)
        {
            // Get focused element's form guid.
            strFocusedElementFormGuid = Xml_GetAttribute(objFocusedElementFormNode,"Attr.Id","");
        }
    }
    
    // Validate focused element's form.
    if(!Aux_IsNullOrEmpty(strFocusedElementFormGuid))
    {
        // Set the focus element guid for the active window.
        marrFocusElementDataIds[strFocusedElementFormGuid] = strFocusedElementGuid;
    }
}
/// </method>

/// <method name="Focus_RemoveFormFocusElement">
/// <summary>
/// 
/// </summary>
function Focus_RemoveFormFocusElement(strFormDataId)
{
    // Validate form data id.
    if(!Aux_IsNullOrEmpty(strFormDataId))
    {
        // Get an integer value as for form data id.
        var intFormDataId = Number(Data_GetDataId(strFormDataId));
        if(!isNaN(intFormDataId))
        {
            // Check if form's index is defined in array.
            if(marrFocusElementDataIds[intFormDataId] != undefined)
            {
                // Remove form from array.
                marrFocusElementDataIds.splice(intFormDataId,1);
            }
        }
    }
}
/// </method>

/// <method name="Focus_GetFormFocusableElementDataId">
/// <summary>
/// Get form's focusable element data id.
/// </summary>
/// <param name="strFormDataId">The form's data id.</param>
function Focus_GetFormFocusableElementDataId(strFormDataId)
{
    var strFocusableElementDataId = "";
    
    // Validate form data id.
    if(!Aux_IsNullOrEmpty(strFormDataId))
    {
        // Get focus element for the source element's form.
        var strCachedFocusElementId = Focus_GetFocusElementDataId(strFormDataId);
        if(!Aux_IsNullOrEmpty(strCachedFocusElementId))
        {
            // Get current window focused element node
            var objCachedFocusElementNode = Data_GetNode(strCachedFocusElementId);
            
            // Check that the current focused element still can get focus
            if(objCachedFocusElementNode &&
                !Data_IsDisabled(objCachedFocusElementNode) && 
                !Xml_IsAttribute(objCachedFocusElementNode,"Attr.Visible","0")&& 
                Xml_IsAttribute(objCachedFocusElementNode,"Attr.Focus","1"))
            {
                strFocusableElementDataId = strCachedFocusElementId;
            }
        }
        
        // Check if no focusable element has been found.
        if(Aux_IsNullOrEmpty(strFocusableElementDataId))
        {
            // Get the source's form node.
            var objFormNode = Data_GetFormNodeByDataId(strFormDataId);
            if(objFormNode)
            {
                // Get next focusable element node
                var objTargetNode = Data_GetTabKeyFirstTargetNode(objFormNode,false);
                if(objTargetNode)
                {
                    // Get focusable element id
                    strFocusableElementDataId=Xml_GetAttribute(objTargetNode,"Attr.Id","");
                }
            }
        }
    }
    
    return strFocusableElementDataId;
}
/// </method>

/// <method name="Focus_SetFocus">
/// <summary>
/// Sets the focus element.
/// </summary>
/// <param name="objSourceElement">The element to set focus to.</param>
function Focus_SetFocus(objSourceElement)
{
    // Define a raise events flag.	
    var blnRaiseEvents=false;
    
    if(objSourceElement)
    {
        // Preserve current window guid.
        var strPreviousWindowGuid = mstrActiveWindowGuid;
        
        // Get the previous focus element guid.
	    var strPreviousFocusElementDataId = Focus_GetFocusElementDataId();
        
        // Get the VWG source.
        var objVwgSource = Web_GetVwgElement(objSourceElement,true,false,true);
        if(objVwgSource)
        {
            // Get source element id.
            var strSourceDataId = Data_GetDataId(Web_GetId(objVwgSource));
            if(!Aux_IsNullOrEmpty(strSourceDataId))
            {
                // Get the source's form node.
                var objFormNode = Data_GetFormNodeByDataId(strSourceDataId);
                if(objFormNode)
                {
                    // Get form data id out of xml.
                    var strFormDataId=Xml_GetAttribute(objFormNode,"Attr.Id","");
        
                    // Try to get focus element from source element
                    var strFocusElementDataId = Focus_GetFocusbleAncestorOrSelf(Data_GetNode(strSourceDataId));
                    
                    // If no valid focus element found for source element.
                    if(Aux_IsNullOrEmpty(strFocusElementDataId))
                    {
                        // Get form's focusable element data id.
                        strFocusElementDataId=Focus_GetFormFocusableElementDataId(strFormDataId);
                    }
                    
                    // Preserve current focus element.
	                Focus_SetFocusElementDataId(strFocusElementDataId,strFormDataId);
            
                    // Update context's active form.
                    Forms_SetActiveFormById(strFormDataId,false);
        	        
                    // Check if current window has been change.
                    if(strPreviousWindowGuid!=mstrActiveWindowGuid)
                    {
                        // Check if previous window is valid.
                        if(!Aux_IsNullOrEmpty(strPreviousWindowGuid))
                        {
                            // Check if deactivate is critical for previous window.
                            blnRaiseEvents = Data_IsCriticalEvent(Data_GetDataId(strPreviousWindowGuid), "Event.Deactivate");
                        }
                    	
                        // Check if current window is valid.
                        if(!Aux_IsNullOrEmpty(mstrActiveWindowGuid))
                        {
                            // Check if activated is critical for current window.
                            blnRaiseEvents = blnRaiseEvents || Data_IsCriticalEvent(Data_GetDataId(mstrActiveWindowGuid), "Event.Activated");
                        }
                    }            
                                            
                    // Check if focus element has been changed.
                    if(strPreviousFocusElementDataId!=strFocusElementDataId)
                    {
                        // Check whether focusing is critical.
                        blnRaiseEvents = blnRaiseEvents || Focus_IsCriticalFocusing(strFocusElementDataId,strPreviousFocusElementDataId);
                        
                        // If focus was previously set.
                        if(!Aux_IsNullOrEmpty(strPreviousFocusElementDataId))
                        {
                            // Create a LostFocus event.
			                Events_LostFocus(strPreviousFocusElementDataId);
			            }
    		        	
                        if(!Aux_IsNullOrEmpty(strFocusElementDataId))
                        {
                            // Create a GotFocus event.
                            Events_GotFocus(strFocusElementDataId);
                        }
                    }
                }
            }
        }
    }
    
    return blnRaiseEvents;
}
/// </method>

/// <method name="Focus_GetFocusbleAncestorOrSelf">
/// <summary>
/// 
/// </summary>
function Focus_GetFocusbleAncestorOrSelf(objFocusableNode)
{
    if(objFocusableNode)
    {
        // Find first focusable element node or the element form
        objFocusableNode = Xml_SelectSingleNode("ancestor-or-self::*[not(@Attr.Visible='0') and not(@Attr.Enabled='0') and @Attr.Focus='1'][1]",objFocusableNode);
        if(objFocusableNode)
        {
            // return the focusable element id.
            return  Xml_GetAttribute(objFocusableNode,"Attr.Id","");
        }
    }
    return null;
}
/// </method>

/// <method name="Focus_IsCriticalFocusing">
/// <summary>
/// 
/// </summary>
function Focus_IsCriticalFocusing(strCurrentFocusElementGuid,strPreviousFocusElementGuid)
{
    // Validate recieved arguments.
	if(!Aux_IsNullOrEmpty(strCurrentFocusElementGuid) && !Aux_IsNullOrEmpty(strPreviousFocusElementGuid))
	{
		// Check if focus element has been changed.
		if(strPreviousFocusElementGuid!=strCurrentFocusElementGuid)
		{
			// Define a raise event flag and check whether containers need to update.
			var blnRaiseChange = Focus_RequireContainersUpdate(strPreviousFocusElementGuid,strCurrentFocusElementGuid);
			
			// If focus was previously set.
			if(!Aux_IsNullOrEmpty(strPreviousFocusElementGuid))
			{
			    // Update the raise event flag.
			    blnRaiseChange = blnRaiseChange || Data_IsCriticalEvent(strPreviousFocusElementGuid, ["Event.LostFocus", "Event.Leave"]);
			}
		
		    // Update the raise event flag.
			blnRaiseChange = blnRaiseChange || Data_IsCriticalEvent(strCurrentFocusElementGuid, ["Event.GotFocus", "Event.Enter"]);
			
			// Return wheter events should be raised.
			return blnRaiseChange;
		}
	}
	
	return false;
}
/// </method>

/// <method name="Focus_RequireContainersUpdate">
/// <summary>
/// 
/// </summary>
function Focus_RequireContainersUpdate(strPreviousFocusElementGuid,strCurrentFocusElementGuid)
{
    var blnContainersUpdateRequire = false;
    
    // Get first parent which is registered to the leave event.
    var objBlurRegisteredParent = Data_GetRegisteredParent(strPreviousFocusElementGuid, "Event.Leave", false);
	if(objBlurRegisteredParent)
	{
	    // Check whether the current focused element is contained in the leave registered parent.
	    blnContainersUpdateRequire=(!Xml_SelectSingleNode(".//WC:*[@Attr.Id='"+strCurrentFocusElementGuid+"']",objBlurRegisteredParent));
	}
    
    // Check if update is not reqiered yet.
    if(!blnContainersUpdateRequire)
    {
        // Get first parent which is registered to the enter event.
        var objEnterRegisteredParent = Data_GetRegisteredParent(strCurrentFocusElementGuid, "Event.Enter", false);
        if(objEnterRegisteredParent)
	    {
	        // Check whether the previous focused element is contained in the enter registered parent.
	        blnContainersUpdateRequire=(!Xml_SelectSingleNode(".//WC:*[@Attr.Id='"+strPreviousFocusElementGuid+"']",objEnterRegisteredParent));
	    }
    }
	
	return blnContainersUpdateRequire;
}
/// </method>

/// </page>


