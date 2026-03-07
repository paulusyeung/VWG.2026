
function vwgLabel(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseLabel = new vwgControl();
vwgLabel.prototype = objBaseLabel;
vwgLabel.prototype.constructor = objBaseLabel;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgLabel.prototype.typeName = function ()
{
    return "Label";
};

/// <method name="text">
/// <summary>
/// Gets and sets the text of the control.
/// </summary>
vwgLabel.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Text");
    }

    strValue = strValue ? Aux_EncodeText(strValue.toString()) : "";
    Xml_SetAttribute(this.objNode, "Attr.Text", strValue);
};