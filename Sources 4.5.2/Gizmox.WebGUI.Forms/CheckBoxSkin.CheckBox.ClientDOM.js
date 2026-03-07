
function vwgCheckBox(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseCheckBox = new vwgControl();
vwgCheckBox.prototype = objBaseCheckBox;
vwgCheckBox.prototype.constructor = objBaseCheckBox;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgCheckBox.prototype.typeName = function ()
{
    return "CheckBox";
};

/// <method name="checked">
/// <summary>
/// Gets and sets a value indicating whether the control is checked.
/// </summary>
vwgCheckBox.prototype.checked = function (blnValue)
{
    if (blnValue == undefined)
    {
        var strChecked = Xml_GetAttribute(this.objNode, "Attr.Checked");
        return (strChecked == "1" || Aux_IsNullOrEmpty(strChecked)) ? true : false;
    }

    // Get value type.
    var strCheckedType = typeof (blnValue);

    // Check value type.
    switch (strCheckedType)
    {
        case "number":
        case "boolean":
            // Handle number
            var intValue = Number(strCheckedType);
            if (!isNaN(intValue))
            {
                Xml_SetAttribute(this.objNode, "Attr.Checked", intValue);
            }
            break;
    }
};

/// <method name="text">
/// <summary>
/// Gets and sets the text of the control.
/// </summary>
vwgCheckBox.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Text");
    }

    Xml_SetAttribute(this.objNode, "Attr.Text", strValue ? strValue : "");
};
/// </method>
