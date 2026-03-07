/// <method name="ToolStrip_ApplyResize">
/// <summary>
/// 
/// </summary>
function ToolStrip_ApplyResize(objWindow,objToolStripElement,strDataId)
{
    // Validate recieved arguments.
    if(objWindow && objToolStripElement && !Aux_IsNullOrEmpty(strDataId))
    {                  
        // Get drop down element.
        var objDropDownElement = Web_GetElementById("VWGTSD_"+strDataId,objWindow);
        if(objDropDownElement)
        {
            // Get wrapped items result.
            var objWrappedItemsResult = ToolStrip_GetWrappedItems(objWindow,strDataId);
            if(objWrappedItemsResult)
            {
                // Show / hide drop down element according to hidden childs count.
                objDropDownElement.style.display = (objWrappedItemsResult.HiddenChilds.length>0) ? "block" : "none";   
            }
        }
        
        // Clean resize handler.
        objToolStripElement.ToolStripResizeHandle = null;
    }
}
/// </method>

/// <method name="ToolStrip_OnResize">
/// <summary>
/// 
/// </summary>
function ToolStrip_OnResize(objWindow,objToolStripElement,strDataId)
{
    // Check resize handler.
    if(Aux_IsNullOrEmpty(objToolStripElement.ToolStripResizeHandle))
    {
        // Apply resize asynchrincly.
        objToolStripElement.ToolStripResizeHandle = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(ToolStrip_ApplyResize,objWindow,objToolStripElement,strDataId),200);
    }
}
/// </method>

/// <method name="ToolStrip_GetWrappedItems">
/// <summary>
/// 
/// </summary>
function ToolStrip_GetWrappedItems(objWindow,strDataID)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strDataID))
    {
        // Get a tool strip element.
        var objToolStripElement = Web_GetElementById("VWGTSIC_"+strDataID,objWindow);
        if(objToolStripElement)
        {
            // Check tool strip element child count.
            var intChildCount = objToolStripElement.childNodes.length;
            if(intChildCount > 0)
            {
                // Get tool strip element's rectangle.
                var objToolStripElementRect = Web_GetRect(objToolStripElement);
                
                // Define an empty hidden childs array.
                var arrHiddenChilds = [];
                
                // Define a zero length items max width.
                var intItemsMaxWidth = 0;
                
                // Initialize the hidden on wrap counter.
                var intHiddenOnWrapCount = 0;
                
                // Loop all tool strip element's childs.
                for(var intChild=0 ; intChild<intChildCount; intChild++)
                {
                    // Get current child.
                    var objChildElement = objToolStripElement.childNodes[intChild];
                    if(objChildElement)
                    {
                        // Get current child's rectangle.
                        var objChildElementRect = Web_GetRect(objChildElement);
                        if(objChildElementRect)
                        {
                            // Check if current child is hidden.
                            if( objChildElementRect.top >= objToolStripElementRect.bottom ||
                                objChildElementRect.left >= objToolStripElementRect.right)
                            {
                                // Add current child to the hidden childs array.
                                arrHiddenChilds.push(objChildElement);
                                
                                // Calculate current child's width.
                                var intChildWidth = objChildElementRect.right-objChildElementRect.left;
                                
                                // Check if current child's width is bigger then the popup width.
                                if(intChildWidth > intItemsMaxWidth)
                                {
                                    // Preserve the current child's width as popup width.
                                    intItemsMaxWidth = intChildWidth;
                                }
                                
                                // Check if current elment should be hidden on wrap.
                                if(Web_IsAttribute(objChildElement,"vwg_HideOnWrap","1",true))
                                {
                                    // Raise hidden on wrap counter.
                                    intHiddenOnWrapCount+=1;
                            }
                        }
                    }
                }
                }
                
                // Return a structed result.
                return {HiddenChilds:arrHiddenChilds,ItemsMaxWidth:intItemsMaxWidth,HiddenOnWrapCount:intHiddenOnWrapCount};
            }
        }
    }
}
/// </method>

/// <method name="ToolStrip_ShowDropDown">
/// <summary>
/// 
/// </summary>
function ToolStrip_ShowDropDown(objWindow,strDataID,objToolStripDropDownElement)
{
    // Validate recieved arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strDataID) && objToolStripDropDownElement)
    {
        // Get a tool strip element.
        var objToolStripElement = Web_GetElementById("VWGTSIC_"+strDataID,objWindow);
        if(objToolStripElement)
        {
            // Check tool strip element child count.
            var intChildCount = objToolStripElement.childNodes.length;
            if(intChildCount > 0)
            {
                // Get wrapped items result.
                var objWrappedItemsResult = ToolStrip_GetWrappedItems(objWindow,strDataID);
                if(objWrappedItemsResult)
                {
                    // Get hidden childs array.
                    var arrHiddenChilds = objWrappedItemsResult.HiddenChilds;
                    
                    // Get value of the hidden on wrap counter.
                    var intHiddenOnWrapCount = objWrappedItemsResult.HiddenOnWrapCount;
                    
                    // Calculate total number of hidden childs.
                    var intHiddenChildsCount = (arrHiddenChilds.length - intHiddenOnWrapCount);
                    if(intHiddenChildsCount > 0)
                    {
                        // Get the drop down elment rectangle.
                        var objToolStripDropDownElementRect = Web_GetRect(objToolStripDropDownElement);
                        if(objToolStripDropDownElementRect)
                        {     
                            // Get the tool strip node.                   
                            var objToolStripNode = Data_GetNode(strDataID);
                            if(objToolStripNode)
                            {
                                // Create an id to drop down popup.
                                var strDropDownID = strDataID+"_DD";
                                
                                // Try getting drop down form node.
                                var objFormNode = Xml_SelectSingleNode("WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.Id='"+strDropDownID+"']",objToolStripNode);
                                
                                // Check if form node does not exist.
                                if(!objFormNode)
                                {
                                    // Create a new form node.
                                    objFormNode = Xml_CreateNode(mobjDataDomObject,1,"WG:Tags.Form","http://www.gizmox.com/webgui");
                                    
                                    // Set new form as poopup window.
                                    Xml_SetAttribute(objFormNode,"Attr.Type","PopupWindow");
                                    
                                    // Set form's id.
                                    Xml_SetAttribute(objFormNode,"Attr.Id",strDropDownID);
                                
                                    // Add form node to tool strip node.
                                    objToolStripNode.appendChild(objFormNode);
                                }
                                
                                // Define an empty popup height. 
                                var intPopupHeight = 0;
                                                                  
                                // Create a dropdown element.
                                var objDropDownElement = objWindow.document.createElement("DIV");
                                
                                // Set dropdown element's id.
                                objDropDownElement.id="VWGTSDD_"+strDataID;
                                
                                // Loop all hidden childs.
                                for(var intHiddenChild=0; intHiddenChild< arrHiddenChilds.length ; intHiddenChild++)
                                {
                                    // Get current hidden child element.
                                    var objHiddenChildElement = arrHiddenChilds[intHiddenChild];
                                    if (objHiddenChildElement)
                                    {
                                        // Get hidden child element's rectangle.
                                        var objHiddenChildElementRect = Web_GetRect(objHiddenChildElement);
                                        if (objHiddenChildElementRect)
                                        {
                                            // Create an item element.
                                            var objItemElement = objWindow.document.createElement("DIV");

                                            // Calculate current item's height.
                                            var intHiddenChildHeight = (objHiddenChildElementRect.bottom - objHiddenChildElementRect.top);

                                            // Check if item should be hidden on wrap.
                                            if (Web_IsAttribute(objHiddenChildElement, "vwg_HideOnWrap", "1", true))
                                            {
                                                // Show item.
                                                objHiddenChildElement.style.display = "none";
                                            }
                                            else
                                            {
                                            // Set Item's height.
                                            objItemElement.style.height = intHiddenChildHeight + "px";

                                            // Set item's margin.
                                            objItemElement.style.margin = "1px";

                                            // Sum hidden child's height into popup' height.
                                            intPopupHeight += (intHiddenChildHeight + 1);
                                            }

                                            // Append hidden child element to item element.
                                            objItemElement.appendChild(objHiddenChildElement);

                                            // Append item element to dropdown element.
                                            $(objDropDownElement).append(objItemElement);
                                        }
                                    }
                                }
                                
                                // Get value for the popup width and update the popup width as for a single 
                                // item's margin horizontal edges.
                                var intPopupWidth = objWrappedItemsResult.ItemsMaxWidth;
                                
                                // Add width offset - if one has been provided through skin.
                                var intSkinPopupWindowOffsetWidth = [Skin.PopupWindowOffsetWidth];
                                if(!Aux_IsNullOrEmpty(intSkinPopupWindowOffsetWidth))
                                {
                                    intPopupWidth += parseInt(intSkinPopupWindowOffsetWidth,10);
                                }

                                // Add height offset - if one has been provided through skin.
                                var intSkinPopupWindowOffsetHeight = [Skin.PopupWindowOffsetHeight];
                                if(!Aux_IsNullOrEmpty(intSkinPopupWindowOffsetHeight))
                                {
                                    intPopupHeight += parseInt(intSkinPopupWindowOffsetHeight,10);
                                }
                                
                                // Set form's size.
                                Xml_SetAttribute(objFormNode,"Attr.Width",intPopupWidth);
                                Xml_SetAttribute(objFormNode,"Attr.Height",intPopupHeight);
                                
                                // Get aligned position.
                                var objAlignedPosition = Popups_GetAlignedRectangleByElement(objToolStripDropDownElement,"B",intPopupWidth,intPopupHeight);
                                if (objAlignedPosition)
                                {
                                    // Define an empty owner popup id.
                                    var strOwnerPopupId = null;

                                    // Get current toolstrip's form node.
                                    var objOwnerFormNode = Data_GetFormNodeByDataId(strDataID);
                                    if (objOwnerFormNode)
                                    {
                                        // Check if toolstrip's form is a popup window.
                                        if (Xml_IsAttribute(objOwnerFormNode, "Attr.Type", "PopupWindow"))
                                        {
                                            // Get owner form id.
                                            strOwnerPopupId = Xml_GetAttribute(objOwnerFormNode, "Attr.Id", "");
                                        }
                                    }

                                    // Create a popup element.
                                    var objPopupElement = Popups_CreatePopup(null, strDataID, strOwnerPopupId, objAlignedPosition.X, objAlignedPosition.Y, objAlignedPosition.Width, objAlignedPosition.Height, objFormNode, false, true, false, ToolStrip_OnDropDownClosed);
                                    if(objPopupElement)
                                    {
                                        // Append dropdown element to popup element.
                                        $(objPopupElement).append(objDropDownElement);
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

/// <method name="ToolStrip_OnDropDownClosed">
/// <summary>
/// 
/// </summary>
function ToolStrip_OnDropDownClosed()
{
    // Try getting control id from popup element.
    var strControlID = Web_GetAttribute(this,"vwg_ControlId",true);
    if(!Aux_IsNullOrEmpty(strControlID))
    {
        // Remove the "_DD" suffix.
        strControlID = strControlID.replace("_DD","");
        
        // Get window as for control id.
        var objWindow = Forms_GetWindowByDataId(strControlID);
        if(objWindow)
        {
            // Get tool strip element.
            var objToolStripElement = Web_GetElementById("VWGTSIC_"+strControlID,objWindow);
            if(objToolStripElement)
            {
                // Get drop down element.
                var objDropDownElement = Web_GetElementById("VWGTSDD_"+strControlID,objWindow);
                if(objDropDownElement)
                {
                    // Get tool strip node.
                    var objToolStripNode = Data_GetNode(strControlID);
                    if(objToolStripNode)
                    {
                        // Loop all of the drop down element's childs.
                        for(var intChild=0; intChild<objDropDownElement.childNodes.length; intChild++)
                        {
                            // Get current item.
                            var objItemElement = objDropDownElement.childNodes[intChild];
                            if(objItemElement)
                            {
                                // Get current tool strip item element.
                                var objToolStripItemElement = objItemElement.firstChild;
                                if (objToolStripItemElement)
                                {
                                    // Append current item's first child to tool strip element.
                                    $(objToolStripElement).append(objToolStripItemElement);

                                    // Check if item should be hidden on wrap.
                                    if (Web_IsAttribute(objToolStripItemElement, "vwg_HideOnWrap", "1", true))
                                    {
                                    // Show item.
                                    objToolStripItemElement.style.display = "block";
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
