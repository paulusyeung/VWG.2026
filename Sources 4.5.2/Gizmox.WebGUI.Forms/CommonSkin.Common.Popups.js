var mobjPopUpBox = null;
var mobjPopUpBoxWindow = null;

/// <method name="Popups_EnsurePopupWindow" access="private">
/// <summary>
/// Ensures popup window box.
/// </summary>
function Popups_EnsurePopupWindowBox(strFormId,strControlId)
{
    // Define default window.
    var objWindow = null;

    // If in inline windos mode.
    if (!mblnInlineWindows)
    {
        // Check if recieved control id came empty.
        if (Aux_IsNullOrEmpty(strControlId))
        {
            // Validate recieved form id.
            if (!Aux_IsNullOrEmpty(strFormId))
            {
                // Try getting form owner id.
                strControlId = Data_GetAttribute(strFormId, "Attr.OwnerID", "");
            }
        }

        // Validate control id.
        if (!Aux_IsNullOrEmpty(strControlId))
        {
            // Get control's form window.
            objWindow = Forms_GetWindowByDataId(strControlId);
        }

        // Check if is popoup window
        if (Popups_IsPopup(objWindow))
        {
            // Get current popup offspring popup id.
            var strPopupId = Web_GetAttribute(objWindow, "vwg_PopupId", true);
            if (!Aux_IsNullOrEmpty(strPopupId))
            {
                // Get form data node
                var objPopupFormNode = Data_GetNode(strPopupId);
                if (objPopupFormNode)
                {
                    // Get non popup form ancestor data node
                    var objOwnerWindowNode = Xml_SelectSingleNode("ancestor::WG:Tags.Form[not(@Attr.Type='PopupWindow')][1]", objPopupFormNode);
                    if (objOwnerWindowNode)
                    {
                        // Get window element
                        objWindow = Forms_GetWindowById(Xml_GetAttribute(objOwnerWindowNode, "Attr.Id"));
                    }
                }
            }
        }
    }
    else
    {
        objWindow = window;
    }

    // Initialize popup window.
    Popups_Initialize(objWindow);

}
/// </method>

/// <method name="Popups_CreatePopup" access="private">
/// <summary>
///
/// </summary>
/// <param name="objObject"></param>
function Popups_CreatePopup(strFormId, strControlId, strOwnerPopupId, intX, intY, intWidth, intHeight, objNode, blnFocusPopup, blnShareFocus, blnHidePopup, fncCloseHandler)
{
    // Define an empty popup id.
    var strPopupId = null;

    // Determine popup id.
    if (!Aux_IsNullOrEmpty(strFormId))
    {
        strPopupId = strFormId;
    }
    else if (!Aux_IsNullOrEmpty(strControlId))
    {
        strPopupId = strControlId;
    }

    var objOwnerPopup = null;

    if (!Aux_IsNullOrEmpty(strOwnerPopupId))
    {
        // Get owner popup
        objOwnerPopup = Popups_GetPopup("vwg_PopupId", strOwnerPopupId);
    }

    // Hide other popups exlcuding owner popup
    Popups_HidePopups(objOwnerPopup);

    // Define an empty popup.
    var objPopup = null;

    // Ensures popup window box.
    Popups_EnsurePopupWindowBox(strFormId,strControlId);
	
    // Validate popup box and popup window.
    if (mobjPopUpBox && Web_IsWindow(mobjPopUpBoxWindow))
    {
        // Create a popup containing div
        var objPopupContainer = mobjPopUpBoxWindow.document.createElement("DIV");

        // Set container's inner html.
        if (objNode)
        {
            Web_SetInnerHtml(objPopupContainer, Controls_GetHtmlFromNode(objNode));
        }

        // Set popup value's.
        if (objPopup = objPopupContainer.firstChild)
        {
			// Check if the document property is missing.
            if(!objPopup.document)
            {
				// Set new element's document property.
                objPopup.document = mobjPopUpBoxWindow.document;
            }

            // Set internal vwg attributes.
            Web_SetAttribute(objPopup, "vwginlinewindow", "1");

            // Set the share focus flag - if one has been sent.
            if (blnShareFocus)
            {
                Web_SetAttribute(objPopup, "vwg_ShareFocus", "1");
            }

            // Set the new popup id - if one has been sent.	        
            if (!Aux_IsNullOrEmpty(strPopupId))
            {
                Web_SetAttribute(objPopup, "vwg_PopupId", strPopupId);
            }

            // Set the new popup owner id - if one has been sent.
            if (!Aux_IsNullOrEmpty(strOwnerPopupId))
            {
                Web_SetAttribute(objPopup, "vwg_OwnerPopupId", strOwnerPopupId);
            }

            if (!Aux_IsNullOrEmpty(strFormId))
            {
                // Set form id - if one has been sent.
                Web_SetAttribute(objPopup, "vwg_FormId", strFormId);

                // Preserve popup in the forms popup array.
                mobjFormsPopupById[strFormId] = objPopup;
            }

            // Set control id - if one has been sent.
            if (!Aux_IsNullOrEmpty(strControlId))
            {
                Web_SetAttribute(objPopup, "vwg_ControlId", strControlId);
            }

            // Set popup div width.
            if (!Aux_IsNullOrEmpty(intWidth))
            {
                objPopup.style.width = intWidth + "px";
            }

            // Set popup div height.	    
            if (!Aux_IsNullOrEmpty(intHeight))
            {
                objPopup.style.height = intHeight + "px";
            }

            // Validate the recieved x and y positions.
            if (!Aux_IsNullOrEmpty(intY) && !Aux_IsNullOrEmpty(intX))
            {
                // Get window's size.
                var intWindowHeight = mobjPopUpBoxWindow.document.body.clientHeight;
                var intWindowWidth = mobjPopUpBoxWindow.document.body.clientWidth;

                // Get popup's size.
                var intPopupHeight = objPopup.clientHeight;
                var intPopupWidth = objPopup.clientWidth;

                // Check if popup exceed window's area hrizentally.
                if ((intX + intPopupWidth) > intWindowWidth)
                {
                    // Update popup's X position to the rightest point on the window.
                    intX = (intWindowWidth - intPopupWidth);
                }

                // Check if popup exceed window's area vertically.
                if ((intY + intPopupHeight) > intWindowHeight)
                {
                    // Update popup's Y position to the most bottom point on the window.               
                    intY = (intWindowHeight - intPopupHeight);
                }
            }

            // Set popup div top location.
            if (!Aux_IsNullOrEmpty(intY))
            {
                objPopup.style.top = intY + "px";
            }

            // Set popup div left location.
            if (!Aux_IsNullOrEmpty(intX))
            {
                objPopup.style.left = intX + "px";
            }

            // Check whether to hide popup element.
            if (blnHidePopup)
            {
                // Hide popup element.
                objPopup.style.display = "none";
            }

            // Check if a clode handler has been sent.
            if (!Aux_IsNullOrEmpty(fncCloseHandler))
            {
                // Set the close handler as expando.
                objPopup.CloseHandler = fncCloseHandler;
            }

            // Set popup z-index
            objPopup.style.zIndex = mobjPopUpBox.childNodes.length + 1;
            
            // Add window to popup box.
            $(mobjPopUpBox).append(objPopup);
        }

        // Set focus on popup box.
        if (blnFocusPopup)
        {
            Web_SetFocus(mobjPopUpBox);
        }
    }

    // Return the new popup element.
    return objPopup;
}
/// </method>

/// <method name="Popups_Initialize">
/// <summary>
/// Initializes all popup prerequisits
/// </summary>
function Popups_Initialize(objWindow)
{
    if (objWindow)
    {
        // Set popup box.
        mobjPopUpBox = Web_GetElementById("VWG_PopUpBox", objWindow);

        // Save the popup box window.
        mobjPopUpBoxWindow = objWindow;
    }
}
/// </method>

/// <method name="Popups_HidePopups">
/// <summary>
/// Hide a specific window menu or last caller window
/// </summary>
/// <param name="objWindow">Window referencce.</param>
function Popups_HidePopups(objExcludedPopupElement)
{
    // Hide all menus except the excluded one.                
    Popups_DoHidePopups(objExcludedPopupElement);
}
/// </method>

/// <method name="Popups_DoHidePopup">
/// <summary>
/// 
/// </summary>
function Popups_DoHidePopup(objPopup)
{
    // Validate recieved arguments.
    if (mobjPopUpBox && objPopup)
    {
        // Check if popup has a close handler.
        if (!Aux_IsNullOrEmpty(objPopup.CloseHandler))
        {
            // Fire the close handler.
            objPopup.CloseHandler();
        }

        // Remove recieved popup from popup box.
        mobjPopUpBox.removeChild(objPopup);
    }
}
/// </method>

/// <method name="Popups_GetElementPopupDynasty">
/// <summary>
/// 
/// </summary>
function Popups_GetElementPopupDynasty(objElement)
{
    // Define an empty dynasty array.
    var arrElementPopupDynasty = [];

    // Validate recieved element.
    if (objElement)
    {
        var objPopupElement = objElement;

        // Loop to find the first ancestor with a popup id.
        while (objPopupElement && Aux_IsNullOrEmpty(Web_GetAttribute(objPopupElement, "vwg_PopupId", true)))
        {
            objPopupElement = objPopupElement.parentNode;
        }

        if (objPopupElement)
        {
            // Loops all of the popup element's dynasty.
            while (objPopupElement)
            {
                // Push current popup element's id to dynasty array.
                arrElementPopupDynasty.push(Web_GetAttribute(objPopupElement, "vwg_PopupId", true));

                // Get current popup's owner id.
                var strOwnerPopupId = Web_GetAttribute(objPopupElement, "vwg_OwnerPopupId", true);

                // Validate owner id.
                if (!Aux_IsNullOrEmpty(strOwnerPopupId))
                {
                    // Try getting owner popup.
                    objPopupElement = Popups_GetPopup("vwg_PopupId", strOwnerPopupId);
                }
                else
                {
                    // Flag null popup element in order to break loop.
                    objPopupElement = null;
                }
            }
        }
    }

    return arrElementPopupDynasty;
}
/// </method>

/// <method name="Popups_DoHidePopups">
/// <summary>
/// 
/// </summary>
function Popups_DoHidePopups(objExcludedPopupElement)
{
    if (mobjPopUpBox)
    {
        var arrPopupDynasty = Popups_GetElementPopupDynasty(objExcludedPopupElement);
        var intPopupBoxChilds = mobjPopUpBox.childNodes.length;

        // Loop all popup elements
        var len = mobjPopUpBox.childNodes.length;
        for (var intIndex = 0; intIndex < len; intIndex++)
        {
            // Get current popup
            var objCurrentPopup = mobjPopUpBox.childNodes[intIndex];
            var objCurrentPopupStyle = objCurrentPopup && objCurrentPopup.style;

            // Check if current popup is visible and if it is a part of the excluded element dynasty.
            if (objCurrentPopupStyle && objCurrentPopupStyle.visibility != "hidden" &&
    		    !arrPopupDynasty.contains(Web_GetAttribute(objCurrentPopup, "vwg_PopupId", true)))
            {
                // Gets form id.
                var strFormId = Web_GetAttribute(objCurrentPopup, "vwg_FormId", true);

                // Check if closing should be prevented because there is form AutoClose attribute with value equal to false.
                var blnPreventClosing = Xml_IsAttribute(Data_GetNode(strFormId), "Attr.AutoClose", "0");

                if (!blnPreventClosing)
                {
                    // Check if is inline popup
                    if (!Aux_IsNullOrEmpty(strFormId))
                    {
                        // Fires on unload event.
                        Forms_FireOnUnload(strFormId);

                        // Remove form's node from XML state.
                        Forms_UnloadForm(strFormId, false);
                    }

                    // Hide popup.
                    Popups_DoHidePopup(objCurrentPopup);

                    // If popup box has a different number of childeren - update index so next loop
                    // will handle the real next popup.
                    if (mobjPopUpBox.childNodes.length > 0 &&
	                intPopupBoxChilds > mobjPopUpBox.childNodes.length)
                    {
                        intIndex--;
                        intPopupBoxChilds = mobjPopUpBox.childNodes.length;
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Popups_HideFormPopup">
/// <summary>
/// 
/// </summary>
function Popups_HideFormPopup(objWindow, strFormId, blnServerSource)
{
    if (!Aux_IsNullOrEmpty(strFormId))
    {
        // Raise inline popup closed event.       
        Forms_CloseForm(strFormId, blnServerSource, null, true);
        return Popups_HidePopup(objWindow, "vwg_FormId", strFormId);
    }

    return false;
}
/// </method>

/// <method name="Popups_HideControlPopup">
/// <summary>
/// 
/// </summary>
function Popups_HideControlPopup(objWindow, strControlId)
{
    return Popups_HidePopup(objWindow, "vwg_ControlId", strControlId);
}
/// </method>

/// <method name="Popups_HidePopup">
/// <summary>
/// 
/// </summary>
function Popups_HidePopup(objWindow, strAttributeName, strAttributeValue)
{
    // Get current element
    var objCurrentPopup = Popups_GetPopup(strAttributeName, strAttributeValue);

    if (objCurrentPopup)
    {
        // Hide popup.
        Popups_DoHidePopup(objCurrentPopup);

        // Break loop with positive value.
        return true;
    }

    return false;
}
/// </method>

/// <method name="Popups_GetPopup">
/// <summary>
/// 
/// </summary>
function Popups_GetPopup(strAttributeName, strAttributeValue)
{
    // Validate poup box and recieved attributes.
    if (mobjPopUpBox && !Aux_IsNullOrEmpty(strAttributeName) && !Aux_IsNullOrEmpty(strAttributeValue))
    {
        // Loop all popup elements
        var len = mobjPopUpBox.childNodes.length;
        for (var intIndex = 0; intIndex < len; intIndex++)
        {
            // Get current element
            var objCurrentPopup = mobjPopUpBox.childNodes[intIndex];

            // Check if current poup is visible and matches the recieved criteria.
            if (Web_IsAttribute(objCurrentPopup, strAttributeName, strAttributeValue, true) &&
    		    objCurrentPopup.style.visibility != "hidden")
            {
                // Return current popup.
                return objCurrentPopup;
            }
        }
    }

    return null;
}
/// </method>

/// <method name="Popups_ShareFocusWithExistPopup">
/// <summary>
/// 
/// </summary>
function Popups_ShareFocusWithExistPopup(strControlGuid)
{
    // Try getting a popup which is related to the recieved control id.
    var objPopup = Popups_GetPopup("vwg_ControlId", strControlGuid);

    // Check if the found poup is allowing to share focus.
    return (objPopup && Web_IsAttribute(objPopup, "vwg_ShareFocus", "1", true));
}
/// </method>

/// <method name="Popups_GetOwnerPopupId">
/// <summary>
/// 
/// </summary>
function Popups_GetOwnerPopupId(objNode)
{
    var strOwnerPopupId = null;

    if (objNode)
    {
        // Get node's first parent.
        objNode = objNode.parentNode;

        // Loop all ancestors.
        while (objNode)
        {
            // Check if current ancestor is a popup form.
            if (objNode.tagName == "WG:Tags.Form" && Xml_IsAttribute(objNode, "Attr.Type", "PopupWindow"))
            {
                // Save current ancestor id and break.
                strOwnerPopupId = Xml_GetAttribute(objNode, "Attr.Id", "");
                break;
            }
            else
            {
                // Continue to next ancestor.
                objNode = objNode.parentNode;
            }
        }
    }

    // Return owner popup id.
    return strOwnerPopupId;
}
/// </method>

/// <method name="Popups_HidePopupDynasty">
/// <summary>
/// 
/// </summary>
function Popups_HidePopupDynasty(objWindow, objElement, blmIncludeFormPopups)
{
    // Validate recieved parameters.
    if (objWindow && objElement)
    {
        // Get popup dynasty for the recieved html element.
        var arrPopupDynasty = Popups_GetElementPopupDynasty(objElement);

        if (arrPopupDynasty && arrPopupDynasty.length > 0)
        {
            // Try getting offsprings of the recieved html element's popup.
            var objOffspringPopup = Popups_GetPopup("vwg_OwnerPopupId", arrPopupDynasty[0]);

            // Loop while offsprongs are found.
            while (objOffspringPopup)
            {
                // Get current popup offspring popup id.
                var strPopupId = Web_GetAttribute(objOffspringPopup, "vwg_PopupId", true);

                if (!Aux_IsNullOrEmpty(strPopupId))
                {
                    // Add current popup offspring popup id to array.
                    arrPopupDynasty.push(strPopupId);

                    // Try getting offsprings of the current offspring.
                    objOffspringPopup = Popups_GetPopup("vwg_OwnerPopupId", strPopupId);
                }
            }

            // Loop all popup in dynasty array.
            var len = arrPopupDynasty.length;
            for (var intIndex = 0; intIndex < len; intIndex++)
            {
                // Get current ancestor out of array.
                var objAncestorPopup = Popups_GetPopup("vwg_PopupId", arrPopupDynasty[intIndex]);

                if (objAncestorPopup)
                {
                    // If cuurrent ancestor is a form and forms sholud not be included - break loop.
                    if (!blmIncludeFormPopups && !Aux_IsNullOrEmpty(Web_GetAttribute(objAncestorPopup, "vwg_FormId", true)))
                    {
                        break;
                    }
                    else
                    {
                        // Hide current ancestor.
                        Popups_DoHidePopup(objAncestorPopup);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Popups_IsPopup">
/// <summary>
/// 
/// </summary>
function Popups_IsPopup(objPopupElement)
{
    return (objPopupElement && !Aux_IsNullOrEmpty(Web_GetAttribute(objPopupElement, "vwg_PopupId", true)));
}
/// </method>

/// <method name="Popups_GetAlignedRectangleByElement">
/// <summary>
/// 
/// </summary>
/// <param name="objAlignedComponentElement"></param>
/// <param name="strAlignmentType"></param>
/// <param name="intPopupWidth"></param>
/// <param name="intPopupHeight"></param>
/// <param name="intCustomTop"></param>
/// <param name="intCustomLeft"></param>
function Popups_GetAlignedRectangleByElement(objAlignedComponentElement, strAlignmentType, intPopupWidth, intPopupHeight, intCustomTop, intCustomLeft)
{
    if (objAlignedComponentElement)
    {
        var objWindow = null;
        var intNewWidth = intPopupWidth;
        var intNewHeight = intPopupHeight;

        // Get vwg component element.
        var objVwgComponentElement = Web_GetVwgElement(objAlignedComponentElement, true);

        var strID = Data_GetDataId(objVwgComponentElement.id);

        if (objVwgComponentElement)
        {
            // Get control's form window.
            objWindow = Forms_GetWindowByDataId(strID);
        }

        // Validate popup box and popup window.
        if (objWindow)
        {
            // Get aligned component rectangle.
            var objAlignedComponentRectangle = Web_GetRect(objAlignedComponentElement);

            if (strAlignmentType == "L" || strAlignmentType == "R" || strAlignmentType == "T" || strAlignmentType == "B")
            {
                var objVisibleRectangle = Popups_GetAlignedComponentVisibleRectangle(objWindow, objAlignedComponentRectangle, strID);
                if(objVisibleRectangle)
                {
                    // Validate that the returned retangle is valid
                    if(objVisibleRectangle.bottom>=objVisibleRectangle.top && objVisibleRectangle.right>=objVisibleRectangle.left)
                    {
                        objAlignedComponentRectangle = objVisibleRectangle;
                    }
                }
            }

            // Define point factors.
            var intPointY = 0;
            var intPointX = 0;

            // Custom alignment
            if (strAlignmentType == "C")
            {
                // Update positions so it will be relative to the aligned component.
                intPointY = (objAlignedComponentRectangle.top + intCustomTop);
                intPointX = (objAlignedComponentRectangle.left + intCustomLeft);

                // Initialize component rectangle so it will represent a point on the screen.
                objAlignedComponentRectangle = { left: intPointX, top: intPointY, right: intPointX, bottom: intPointY };
            }
            // Above and below alignments
            else if (strAlignmentType == "A" || strAlignmentType == "B")
            {
                // Define RTL switch.
                var blnIsRTL = (Web_IsAttribute(objAlignedComponentElement, "HorizentalOppositeAlignment", "1", true) ? !mblnIsRTL : mblnIsRTL);

                intPointX = (blnIsRTL ? objAlignedComponentRectangle.right - intPopupWidth : objAlignedComponentRectangle.left);
                intPointY = (strAlignmentType == "B" ? objAlignedComponentRectangle.bottom : (objAlignedComponentRectangle.top - intPopupHeight));
            }
            // Right and left alignments
            else if (strAlignmentType == "R" || strAlignmentType == "L")
            {
                intPointY = objAlignedComponentRectangle.top;
                intPointX = (strAlignmentType == "R" ? objAlignedComponentRectangle.right : objAlignedComponentRectangle.left - intPopupWidth);
            }

            // Get the body element.
            var objBodyElement = objWindow.document.body;
            if (objBodyElement)
            {
                // Check if the y point has exeeded one of body's edges.
                if (intPointY < 0 || (intPointY + intPopupHeight) > objBodyElement.clientHeight)
                {
                    // Check if current alignment is vertically.
                    var blnVerticalAlignment = (strAlignmentType == "A" || strAlignmentType == "B");

                    // Check if the algined component has a heigher spacing on the bottom side then on the top side.
                    if (objAlignedComponentRectangle.top < (objBodyElement.clientHeight - objAlignedComponentRectangle.bottom))
                    {
                        // Fix the y point so it will align the popup to the botttom of the aligned component.
                        intPointY = (blnVerticalAlignment ? objAlignedComponentRectangle.bottom : objAlignedComponentRectangle.top);
                    }
                    else
                    {
                        // Fix the y point so it will align the popup to the top of the aligned component.
                        intPointY = (blnVerticalAlignment ? objAlignedComponentRectangle.top : objAlignedComponentRectangle.bottom) - intPopupHeight;
                    }

                    // If popup bottom edge exceeds the window bottom 
                    if (intPointY + intPopupHeight > objBodyElement.clientHeight)
                    {
                        // Limit height to window bottom edge.
                        intNewHeight = objBodyElement.clientHeight - intPointY;
                    }

                    // If popup top edge exceeds window top
                    else if (intPointY < 0)
                    {
                        // Limit height and reset popup top, so it starts at 0, and does not exceeds element top.
                        intNewHeight += intPointY;
                        intPointY = 0;
                    }
                }

                // Check if the x point has exeeded one of body's edges.
                if (intPointX < 0 || (intPointX + intPopupWidth) > objBodyElement.clientWidth)
                {
                    // Check if current alignment is horizontally.
                    var blnHorizontalAlignment = (strAlignmentType == "R" || strAlignmentType == "L");

                    // Check if the algined component has a wider spacing on the right side then on the left side.
                    if (objAlignedComponentRectangle.left < (objBodyElement.clientWidth - objAlignedComponentRectangle.right))
                    {
                        // Fix the x point so it will align the popup to the right of the aligned component.
                        intPointX = (blnHorizontalAlignment ? objAlignedComponentRectangle.right : objAlignedComponentRectangle.left);
                    }
                    else
                    {
                        // Fix the x point so it will align the popup to the left of the aligned component.
                        intPointX =(blnHorizontalAlignment ? objAlignedComponentRectangle.left : objAlignedComponentRectangle.right) - intPopupWidth;                       
                    }

                    // If popup right edge exceeds window right edge
                    if (intPointX + intPopupWidth > objBodyElement.clientWidth)
                    {
                        // Limit popup width to window right edge
                        intNewWidth = objBodyElement.clientWidth - intPointX;
                    }

                    // If popup left edge exceeds window left
                    else if (intPointX < 0)
                    {
                        // Limit width and reset popup left, so it starts at 0, and does not exceeds element left.
                        intNewWidth += intPointX;
                        intPointX = 0;
                    }
                }
            }
        }

        // Build the returning rectangle (top, left, width, height).
        return { Y: intPointY, X: intPointX, Width: intNewWidth, Height: intNewHeight };
    }
}
/// </method>

/// <method name="Popups_GetAlignedComponentVisibleRectangle">
/// <summary>
/// 
/// </summary>
function Popups_GetAlignedComponentVisibleRectangle(objWindow, objAlignedComponentRectangle, strDataId)
{
    // Check valid parameters
    if (objWindow && objAlignedComponentRectangle && strDataId)
    {
        // Get data node
        var objDataNode = Data_GetNode(strDataId);
        if(objDataNode)
        {
            objDataNode = objDataNode.parentNode;

            // Climb on all component containers and check if one of them hiding the component
            // and if so then update visibale retangle
            do
            {
                objDataNode = Data_GetParentControl(objDataNode);
                
                if(objDataNode)
                {
                    strDataId = Data_GetNodeAttribute(objDataNode, "Attr.Id", "");
                    var objElement = Web_GetElementByDataId(strDataId, objWindow);
                    if(objElement)
                    {
                        var objTempRect = Web_GetRect(objElement);
                        if(objTempRect)
                        {
                            if (objAlignedComponentRectangle.top < objTempRect.top)
                            {
                                objAlignedComponentRectangle.top = objTempRect.top;
                            }

                            if(objAlignedComponentRectangle.bottom > objTempRect.bottom)
                            {
                                objAlignedComponentRectangle.bottom = objTempRect.bottom;
                            }

                            if (objAlignedComponentRectangle.left < objTempRect.left)
                            {
                                objAlignedComponentRectangle.left = objTempRect.left;
                            }

                            if (objAlignedComponentRectangle.right > objTempRect.right)
                            {
                                objAlignedComponentRectangle.right = objTempRect.right;
                            }
                        }
                    }

                    objDataNode = objDataNode.parentNode;
                }
            }
            while (objDataNode)
        }
    }

    return objAlignedComponentRectangle;
}
/// </method>

/// <method name="Popups_GetAlignedRectangle">
/// <summary>
/// 
/// </summary>
/// <param name="strAlignedComponentId"></param>
/// <param name="strAlignmentType"></param>
/// <param name="intPopupWidth"></param>
/// <param name="intPopupHeight"></param>
/// <param name="intCustomTop"></param>
/// <param name="intCustomLeft"></param>
function Popups_GetAlignedRectangle(strAlignedComponentId, strAlignmentType, intPopupWidth, intPopupHeight, intCustomTop, intCustomLeft)
{
    // Get control's form window.
    var objWindow = Forms_GetWindowByDataId(strAlignedComponentId);
    if(objWindow)
    {
        // Get object to align to
        var objAlignedComponentElement = Web_GetElementByDataId(strAlignedComponentId,objWindow);
        if(objAlignedComponentElement)
        {
            return Popups_GetAlignedRectangleByElement(objAlignedComponentElement, strAlignmentType, intPopupWidth, intPopupHeight, intCustomTop, intCustomLeft);
        }
    }
}
/// </method>