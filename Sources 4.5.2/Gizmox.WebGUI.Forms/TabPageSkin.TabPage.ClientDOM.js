function vwgTabPage(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseTabPage = new vwgControl();
vwgTabPage.prototype = objBaseTabPage;
vwgTabPage.prototype.constructor = objBaseTabPage;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgTabPage.prototype.typeName = function ()
{
    return "TabPage";
};

/// <method name="text">
/// <summary>
/// Gets and sets the text of the control.
/// </summary>
vwgTabPage.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Text");
    }

    Xml_SetAttribute(this.objNode, "Attr.Text", strValue ? strValue : "");
};