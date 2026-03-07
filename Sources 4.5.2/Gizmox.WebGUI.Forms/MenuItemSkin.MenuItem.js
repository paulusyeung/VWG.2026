/// <method name="MenuItem_HandleMouseEvents">
/// <summary>
///	
/// </summary>
function MenuItem_HandleMouseEvents(objElement,strType,objWindow,objEvent)
{
    // Set the menu item visual style
    Web_SetStyle(objElement,strType,objWindow);
	    	
    // Validate recieved arguments
    if(objElement && objWindow && !Aux_IsNullOrEmpty(strType) && strType=="mouseenter")
    {
	    // Get VWG source element.
        var objVwgSource = Web_GetVwgElement(objElement, true);    	    
        if(objVwgSource)
        {
            // Get source element data id.
            var strGuid = Data_GetDataId(Web_GetId(objVwgSource));            
            if(!Aux_IsNullOrEmpty(strGuid))
            {
                var objNode = Data_GetNode(strGuid);

                if (!Data_IsDisabled(objNode))
                {
                    // Close owned forms and check whether an owned form already exist.
                    if(!MenuItem_CloseOwnedForms(strGuid) && Data_IsNodeAttribute(objNode, "Attr.HasNodes", "1"))
                    {
                        // Create an enter event.
                        Events_CreateEvent(strGuid,"Enter",null,true);
    	            
                        // Raise events.
                        Events_RaiseEvents(null,true);
                    }
                }
            }
        }        
    }
}
/// </method>

/// <method name="MenuItem_CloseOwnedForms">
/// <summary>
///	
/// </summary>
function MenuItem_CloseOwnedForms(strGuid)
{
    var blnExistOwnedForm = false;
    
    // Validate recieved arguments
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Get control's node
        var objNode = Data_GetNode(strGuid);
        if(objNode)
        {
            // Search for parent form node.
            while(objNode && objNode.tagName!="WG:Tags.Form")
            {
                objNode=objNode.parentNode;
            }
            
            // Validate form node.
            if(objNode)
            {            
                // Get all owned forms.
                var arrOwnedForms = Xml_SelectNodes("WG:Tags.Form[@Attr.CustomStyle='Menu']",objNode);
                if(arrOwnedForms && arrOwnedForms.length>0)
                {
                    // Loop owned forms.
                    for(var i=0; i<arrOwnedForms.length; i++)
                    {
                        if(Xml_IsAttribute(arrOwnedForms[i],"Attr.OwnerID",strGuid))
                        {
                            // Flag that an owned form exists.
                            blnExistOwnedForm=true;
                        }
                        else
                        {
                            // Close current owned form recursivly.
                            MenuItem_CloseSubMenuForm(arrOwnedForms[i]);
                        }
                    }
                }
            }
        }
    }
    
    return blnExistOwnedForm;
}
/// </method>

/// <method name="MenuItem_CloseSubMenuForm">
/// <summary>
///	
/// </summary>
function MenuItem_CloseSubMenuForm(objForm)
{
    // Validate recieved arguments
    if(objForm)
    {
        // Get all owned forms.
        var arrOwnedForms = Xml_SelectNodes("WG:Tags.Form[@Attr.CustomStyle='Menu']",objForm);
        if(arrOwnedForms && arrOwnedForms.length>0)
        {
            // Loop owned forms.
            for(var i=0; i<arrOwnedForms.length; i++)
            {
                MenuItem_CloseSubMenuForm(arrOwnedForms[i]);
            }
        }
        
        // Close current form.
        Forms_CloseWindow(Xml_GetAttribute(objForm,"Attr.Id"));
    }
}
/// </method>