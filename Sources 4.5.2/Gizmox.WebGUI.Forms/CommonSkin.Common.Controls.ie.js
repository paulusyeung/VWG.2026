/// <page code="Controls" browser="ie">


/// <method name="Controls_SetInnerHtmlFromNode" access="private">
/// <summary>
/// 
/// </summary>
/// <param name="objElement">The element to set it's inner html.</param>
/// <param name="objNode">The node to transform to get inner html.</param>
function Controls_SetInnerHtmlFromNode(objWindow, objElement, objNode, strGuid)
{
    // Set the outer HTML of the current element
    Web_SetInnerHtml(objElement,Controls_GetHtmlFromNode(objNode,strGuid));
}
/// </method>

/// <method name="Controls_SetInnerHtmlFromNode" access="private">
/// <summary>
/// 
/// </summary>
/// <param name="objElement">The element to set it's inner html.</param>
/// <param name="objNode">The node to transform to get inner html.</param>
function Controls_SetOuterHtmlFromNode(objWindow, objElement, objNode, strGuid)
{
    // Set the outer HTML of the current element
    Web_SetOuterHTML(objWindow,objElement,Controls_GetHtmlFromNode(objNode,strGuid),strGuid);
}
/// </method>

/// <method name="Controls_UpdateWidth">
/// <summary>
/// Updates a given control width
/// </summary>
/// <param name="strGuid">The node guid of the current control.</param>
/// <param name="objElement">The browser element to be updated.</param>
/// <param name="intWidth">The control new width value.</param>
function Controls_UpdateWidth(strGuid,objElement,intWidth)
{
    Data_SetAttribute(strGuid,"Attr.Width",intWidth);
    
    Layout_PerformContainerLayout(objElement.parentNode);
}
/// </method>

/// <method name="Controls_UpdateHeight">
/// <summary>
/// Updates a given control height
/// </summary>
/// <param name="strGuid">The node guid of the current control.</param>
/// <param name="objElement">The browser element to be updated.</param>
/// <param name="intHeight">The control new height value.</param>
function Controls_UpdateHeight(strGuid,objElement,intHeight)
{
    Data_SetAttribute(strGuid,"Attr.Height",intHeight);
    
    Layout_PerformContainerLayout(objElement.parentNode);
}
/// </method>

/// </page>