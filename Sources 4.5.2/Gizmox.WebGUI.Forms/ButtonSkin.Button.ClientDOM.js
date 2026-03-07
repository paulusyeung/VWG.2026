
function vwgButton(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseButton = new vwgControl();
vwgButton.prototype = objBaseButton;
vwgButton.prototype.constructor = objBaseButton;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgButton.prototype.typeName = function ()
{
    return "Button";
};

/// <method name="text">
/// <summary>
/// Gets and sets the text of the control.
/// </summary>
vwgButton.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Text");
    }

    Xml_SetAttribute(this.objNode, "Attr.Text", strValue ? strValue : "");
};