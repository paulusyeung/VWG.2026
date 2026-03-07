
function vwgRadioButton(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseRadioButton = new vwgControl();
vwgRadioButton.prototype = objBaseRadioButton;
vwgRadioButton.prototype.constructor = objBaseRadioButton;

/// <method name="checked">
/// <summary>
/// Gets and sets a value indicating whether the control is checked.
/// </summary>
vwgRadioButton.prototype.checked = function (objValue)
{
    if (objValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Checked");
    }

    // Get value type.
    var strValueType = typeof (objValue);

    // Check value type.
    switch (strValueType)
    {
        case "number":
        case "boolean":
            // Handle number
            var intValue = Number(objValue);
            if (!isNaN(intValue))
            {
                Xml_SetAttribute(this.objNode, "Attr.Checked", intValue);
            }
            break;
    }
};