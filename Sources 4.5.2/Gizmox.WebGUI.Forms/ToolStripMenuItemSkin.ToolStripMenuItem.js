/// <method name="ToolStripMenuItem_ItemHasActiveDropDown">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_ItemHasActiveDropDown(strMenuItemDataId,objMenuItemNode)
{
    // Define a flag which indicates whether the handled menu item has owned menu form.
    var blnHasOwnedMenuForm = false;
    
    if(!Aux_IsNullOrEmpty(strMenuItemDataId) && objMenuItemNode)
    {
        // Get owner form node.
        var objOwnerFormNode = objMenuItemNode;
        
        // Search for parent form node.
        while(objOwnerFormNode && objOwnerFormNode.tagName!="WG:Tags.Form")
        {
            objOwnerFormNode=objOwnerFormNode.parentNode;
        }
        
        // Validate form node.
        if(objOwnerFormNode)
        { 
            // Get all owned forms.
            var arrOwnedForms = Xml_SelectNodes("WG:Tags.Form[@Attr.ToolStripDropDown='1']", objOwnerFormNode);
            if(arrOwnedForms && arrOwnedForms.length>0)
            {
                // Loop owned forms.
                for(var i=0; i<arrOwnedForms.length; i++)
                {
                    // Check if current owned form is owned by the enetered menu item.
                    if(Xml_IsAttribute(arrOwnedForms[i],"Attr.OwnerID",strMenuItemDataId))
                    {
                        // Flag that an owned form exists.
                        blnHasOwnedMenuForm=true;
                        break;
                    }
                }
            }
        }
    }

    // Return flag value.
    return blnHasOwnedMenuForm;
}
/// </method>

/// <method name="ToolStripMenuItem_CloseItemSiblingsDropDowns">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_CloseItemSiblingsDropDowns(strExcludedMenuItemDataId,objMenuItemNode)
{
    // Validate recieved arguments
    if(!Aux_IsNullOrEmpty(strExcludedMenuItemDataId) && objMenuItemNode)
    {
        // Get owner form node.
        var objOwnerFormNode = objMenuItemNode;
        
        // Search for parent form node.
        while(objOwnerFormNode && objOwnerFormNode.tagName!="WG:Tags.Form")
        {
            objOwnerFormNode=objOwnerFormNode.parentNode;
        }
        
        // Validate form node.
        if(objOwnerFormNode)
        { 
            // Get all owned forms.
            var arrOwnedForms = Xml_SelectNodes("WG:Tags.Form[@Attr.ToolStripDropDown='1']", objOwnerFormNode);
            if(arrOwnedForms && arrOwnedForms.length>0)
            {
                // Loop owned forms.
                for(var i=0; i<arrOwnedForms.length; i++)
                {
                    // Check if current owned form is not owned by the enetered menu item.
                    if(!Xml_IsAttribute(arrOwnedForms[i],"Attr.OwnerID",strExcludedMenuItemDataId))
                    {
                        // Close current owned form recursivly.
                        ToolStripMenuItem_CloseMenuItemSubMenuForm(arrOwnedForms[i]);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="ToolStripMenuItem_IsItemValidStickinessBehavior">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_IsItemValidStickinessBehavior(strMenuItemDataId,objMenuItemNode,objParentStripNode,blnStripSupportStickiness)
{
    //  Check if strip stickiness is supported.
    if(blnStripSupportStickiness)
    {
        // Validate recieved arguments
        if(!Aux_IsNullOrEmpty(strMenuItemDataId) && objMenuItemNode && objParentStripNode)
        {
            // Define an empty siblings array.
            var arrSiblings = [];
            
            // Loop all siblings.
            for(var i=0; i<objParentStripNode.childNodes.length; i++)
            {
                var objSiblingNode = objParentStripNode.childNodes[i];
                if(objSiblingNode)
                {                            
                    // Get current sibling owner id.
                    var strSiblingOwnerId = Xml_GetAttribute(objSiblingNode,"Attr.OwnerID","");
                    
                    // Get current sibling mamber id.
                    var strSiblingMemberId = Xml_GetAttribute(objSiblingNode,"Attr.MemberID","");
                    
                    if(!Aux_IsNullOrEmpty(strSiblingOwnerId) && !Aux_IsNullOrEmpty(strSiblingMemberId))
                    {
                        // Add sibling id to array.
                        arrSiblings.push(strSiblingOwnerId+"_"+strSiblingMemberId);
                    }
                }
            }
        
            // Get owner form node.
            var objOwnerFormNode = objMenuItemNode;
        
            // Search for parent form node.
            while(objOwnerFormNode && objOwnerFormNode.tagName!="WG:Tags.Form")
            {
                objOwnerFormNode=objOwnerFormNode.parentNode;
            }
        
            // Validate form node.
            if(objOwnerFormNode)
            { 
                // Validate siblings array.
                if(arrSiblings.length>0)
                {
                    // Get all owned forms.
                    var arrOwnedForms = Xml_SelectNodes("WG:Tags.Form[@Attr.ToolStripDropDown='1']", objOwnerFormNode);
                    if(arrOwnedForms && arrOwnedForms.length>0)
                    {
                        // Loop owned forms.
                        for(var i=0; i<arrOwnedForms.length; i++)
                        {
                            // Check if current owned form owned by one of the entered menu item's siblings.
                            if(arrSiblings.contains(Xml_GetAttribute(arrOwnedForms[i],"Attr.OwnerID","")))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
    }

    // Return stickiness value.
    return !blnStripSupportStickiness;
}
/// </method>

/// <method name="ToolStripMenuItem_CloseMenuItemSubMenuForm">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_CloseMenuItemSubMenuForm(objForm)
{
    // Validate recieved arguments
    if(objForm)
    {
        // Get all owned forms.
        var arrOwnedForms = Xml_SelectNodes("WG:Tags.Form[@Attr.ToolStripDropDown='1']", objForm);
        if(arrOwnedForms && arrOwnedForms.length>0)
        {
            // Loop owned forms.
            for(var i=0; i<arrOwnedForms.length; i++)
            {
                ToolStripMenuItem_CloseMenuItemSubMenuForm(arrOwnedForms[i]);
            }
        }
        
        // Close current form.
        Forms_CloseWindow(Xml_GetAttribute(objForm,"Attr.Id"));
    }
}
/// </method>

/// <method name="ToolStripMenuItem_HandleMenuItemMouseEvents">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_HandleMenuItemMouseEvents(objElement,strType,objWindow,objEvent)
{
    // Set the menu item visual style
    Web_SetStyle(objElement,strType,objWindow);
	    	
    // Validate recieved arguments
    if(objElement && objWindow && !Aux_IsNullOrEmpty(strType))
    {
	    // Get VWG source element.
        var objVwgSource = Web_GetVwgElement(objElement, true);    	    
        if(objVwgSource)
        {
            // Get source element data id.
            var strMenuItemDataId = Data_GetDataId(Web_GetId(objVwgSource));            
            if(!Aux_IsNullOrEmpty(strMenuItemDataId))
            {
                // Get menu item's node
                var objMenuItemNode = ToolStripMenuItem_GetMenuItemNodeByDataID(strMenuItemDataId);
                if(objMenuItemNode)
                {
                    // Get parent strip node.
                    var objParentStripNode = objMenuItemNode.parentNode;
                    if(objParentStripNode)
                    {
                        // Check if parent strip suuports srickiness.
                        var blnStripSupportStickiness=Xml_IsAttribute(objParentStripNode,"Attr.SupportMenuStickiness","1");

                        // Check if parent strip suuports showing items drop down on enter.
                        var blnShowDropDownItemsOnEnter = Xml_IsAttribute(objParentStripNode, "Attr.ShowDropDownItemsOnEnter", "1");

                        // Check if item menu has sub menus and menu is not disabled.
                        if (Data_IsNodeAttribute(objMenuItemNode, "Attr.HasNodes", "1") && !Data_IsDisabled(objMenuItemNode))
                        {
                            // Define a flag that will indicate if enter should be raised.
                            var blnShouldRaiseEnter = false;

                            // Check event type.
                            switch (strType)
                            {
                                case "mousedown":
                                    // Close manu item's siblings drop downs.
                                    ToolStripMenuItem_CloseItemSiblingsDropDowns(strMenuItemDataId, objMenuItemNode);

                                    // Check if menu item has an active drop down.
                                    blnShouldRaiseEnter = !ToolStripMenuItem_ItemHasActiveDropDown(strMenuItemDataId, objMenuItemNode);
                                    break;
                                case "mouseenter":
                                    // Check if enter causes a valid item stickiness behavior.
                                    var blnIsValidStickinessBehavior = ToolStripMenuItem_IsItemValidStickinessBehavior(strMenuItemDataId, objMenuItemNode, objParentStripNode, blnStripSupportStickiness);

                                    // Close manu item's siblings drop downs.
                                    ToolStripMenuItem_CloseItemSiblingsDropDowns(strMenuItemDataId, objMenuItemNode);

                                    // Check if item has an active drop down.
                                    var blnHasOwnedMenuForm = ToolStripMenuItem_ItemHasActiveDropDown(strMenuItemDataId, objMenuItemNode);

                                    // Check if enter event should be raised.
                                    blnShouldRaiseEnter = !blnHasOwnedMenuForm && (blnIsValidStickinessBehavior || blnShowDropDownItemsOnEnter);
                                    break;
                            }

                            // Check if enter should be raised.
                            if (blnShouldRaiseEnter)
                            {
                                // Create an enter event.
                                Events_CreateEvent(strMenuItemDataId, "Enter", null, true);

                                // Raise events.
                                Events_RaiseEvents(null, true);
                            }
                        }
                        else
                        {
                            // Check event type.
                            switch (strType)
                            {
                                case "mouseenter":
                                    // Close manu item's siblings drop downs.
                                    ToolStripMenuItem_CloseItemSiblingsDropDowns(strMenuItemDataId, objMenuItemNode);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="ToolStripMenuItem_GetMenuItemNodeByDataID">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_GetMenuItemNodeByDataID(strDataID)
{
    var objMenuItemNode = null;
    
    // Split member id parts
    var arrGuid = strDataID.split("_");
    if(arrGuid.length==2)
    {
        // Get owner node from guid first part
        var objOwnerNode = Data_GetNode(arrGuid[0]);
        if(objOwnerNode)
        {
            objMenuItemNode	= Xml_SelectSingleNode("WC:Tags.Panel[@Attr.CustomStyle='ToolStripDropDownContentPanel']/WC:Tags.ToolStripItem[@Attr.MemberID='"+arrGuid[1]+"'] | WC:Tags.ToolStripItem[@Attr.MemberID='"+arrGuid[1]+"']",objOwnerNode);
        }
    }
    
    return objMenuItemNode;
}
/// </method>


/// <method name="ToolStripMenuItem_OnClick">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_OnClick(objEvent, objWindow, strDataID)
{
    // Validate recieved arguments.
    if (objEvent && objWindow && !Aux_IsNullOrEmpty(strDataID))
    {
        // Get the Relevant tool strip button node from XML
        var objToolStripMenuItemNode = Data_GetNode(strDataID);
        if (objToolStripMenuItemNode && Xml_IsAttribute(objToolStripMenuItemNode, "Attr.CheckOnClick", "1"))
        {
            // Determine the current button's checked state
            var blnChecked = Xml_IsAttribute(objToolStripMenuItemNode, "Attr.Checked", "1");

            // Set the buttons new state according to the old one
            Xml_SetAttribute(objToolStripMenuItemNode, "Attr.Checked", blnChecked ? "0" : "1");

            // Redraw the control for the user to see the changes
            Controls_RedrawControlByNode(objWindow, objToolStripMenuItemNode, false);

            // Create a 'queued' event to changed the button's state
            var objVwgEvent = Events_CreateEvent(strDataID, "CheckedChange", null, true);

            // Set event parameter to the current state
            Events_SetEventAttribute(objVwgEvent, "Attr.Checked", blnChecked ? "false" : "true");

            // Check if the control has a critical event attached to it
            Web_OnClick(objEvent, objWindow, Data_IsCriticalEvent(strDataID, "Event.CheckedChange"), Web_GetElementByDataId(strDataID, objWindow));
        }
    }
}
/// </method>

/// <method name="ToolStripMenuItem_AfterCreateEvents">
/// <summary>
///	
/// </summary>
function ToolStripMenuItem_AfterCreateEvents(objWindow, objEvent, strSourceDataId, strEventType, strTargetDataId)
{
    if (strEventType == "Click")
    {
        // Get menu item's node
        var objMenuItemNode = ToolStripMenuItem_GetMenuItemNodeByDataID(strSourceDataId);

		// Check that current item exists.
        if (objMenuItemNode)
        {
            // Search for the root drop down form node.
            var objRootDropDownFormNode = Xml_SelectSingleNode("ancestor::WG:Tags.Form[@Attr.ToolStripDropDown='1']", objMenuItemNode);
            if (objRootDropDownFormNode)
            {
                // Check if autoclosing is allowed.
                var blnPreventClosing = Xml_IsAttribute(objRootDropDownFormNode, "Attr.AutoClose", "0");
                if (!blnPreventClosing)
                {
                    // Close the root drop down form node.
                    ToolStripMenuItem_CloseMenuItemSubMenuForm(objRootDropDownFormNode);
                }
            }
        }
    }
}
/// </method>
