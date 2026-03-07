
function vwgNumericUpDown(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseNumericUpDown = new vwgControl();
vwgNumericUpDown.prototype = objBaseNumericUpDown;
vwgNumericUpDown.prototype.constructor = objBaseNumericUpDown;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgNumericUpDown.prototype.typeName = function ()
{
    return "NumericUpDown";
};

/// <method name="value">
/// <summary>
/// Gets the number of the control.
/// </summary>
vwgNumericUpDown.prototype.value = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Value");
    }

    Xml_SetAttribute(this.objNode, "Attr.Value", strValue);
    Xml_SetAttribute(this.objNode, "Attr.Text", strValue);
};