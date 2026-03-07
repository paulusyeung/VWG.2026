
function vwgLinkLabel(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseLinkLabel = new vwgControl();
vwgLinkLabel.prototype = objBaseLinkLabel;
vwgLinkLabel.prototype.constructor = objBaseLinkLabel;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgLinkLabel.prototype.typeName = function ()
{
    return "LinkLabel";
};

/// <method name="text">
/// <summary>
/// Gets and sets the text of the control.
/// </summary>
vwgLinkLabel.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Text");
    }

    Xml_SetAttribute(this.objNode, "Attr.Text", strValue ? strValue : "");
};