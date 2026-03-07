/// <method name="MainMenu_HandleEvent">
/// <summary>
/// Hanldes all main menu events
/// </summary>
/// <param name="objElement">Reference to menu element.</param>
/// <param name="strType">The event type.</param>
/// <param name="objWindow">Reference to element's window.</param>
/// <param name="objEvent">The handled event.</param>
function MainMenu_HandleEvent(objElement,strType,objWindow,objEvent)
{	
    // Validate recieved arguments
    if( objElement && objWindow && !Aux_IsNullOrEmpty(strType))
    {
	    // Set the menu item visual style
	    Web_SetStyle(objElement,strType,objWindow);
	    
	    // In case of mouse enter.
	    if(strType=="mouseenter")
	    {
	        // Get VWG source element.
            var objVwgSource = Web_GetVwgElement(objElement, true);    	    
            if(objVwgSource)
            {
                // Get source element data id.
                var strGuid = Data_GetDataId(Web_GetId(objVwgSource)); 
                if(!Aux_IsNullOrEmpty(strGuid))
                {
                    // Close owned forms and check whether enter event should be fire.
                    if(MainMenu_ShouldRaiseEnter(strGuid))
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

/// <method name="MainMenu_ShouldRaiseEnter">
/// <summary>
///	
/// </summary>
function MainMenu_ShouldRaiseEnter(strGuid)
{
    var blnShouldRaiseEnter = false;
    
    // Validate recieved arguments
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Check if recieved menu has sub menus.
        if(Data_IsAttribute(strGuid,"Attr.HasNodes","1"))
        {
            // Get control's node
            var objNode = Data_GetNode(strGuid);
            if(objNode && objNode.parentNode)
            {
                // Define an empty siblings array.
                var arrSiblings = [];
                
                // Loop all siblings.
                for(var i=0; i<objNode.parentNode.childNodes.length; i++)
                {
                    // Get current sibling id.
                    var strSiblingId = Xml_GetAttribute(objNode.parentNode.childNodes[i],"Attr.Id","");
                    if(!Aux_IsNullOrEmpty(strSiblingId))
                    {
                        // Add sibling id to array.
                        arrSiblings.push(strSiblingId);
                    }
                }
                
                if(arrSiblings.length>0)
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
                                if(arrSiblings.contains(Xml_GetAttribute(arrOwnedForms[i],"Attr.OwnerID","")))
                                {
                                    blnShouldRaiseEnter=true;
                                    break;
                                }
                            }
                            
                            if(blnShouldRaiseEnter)
                            {
                                // Loop owned forms.
                                for(var i=0; i<arrOwnedForms.length; i++)
                                {
                                    if(Xml_IsAttribute(arrOwnedForms[i],"Attr.OwnerID",strGuid))
                                    {
                                        // Flag that an owned form exists.
                                        blnShouldRaiseEnter=false;
                                    }
                                    else
                                    {
                                        // Close current owned form recursivly.
                                        MainMenu_CloseSubMenuForm(arrOwnedForms[i]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    return blnShouldRaiseEnter;
}
/// </method>

/// <method name="MainMenu_CloseSubMenuForm">
/// <summary>
///	
/// </summary>
function MainMenu_CloseSubMenuForm(objForm)
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
                MainMenu_CloseSubMenuForm(arrOwnedForms[i]);
            }
        }
        
        // Close current form.
        Forms_CloseWindow(Xml_GetAttribute(objForm,"Attr.Id"));
    }
}
/// </method>