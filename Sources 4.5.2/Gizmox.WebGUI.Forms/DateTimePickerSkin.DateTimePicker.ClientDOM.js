

function vwgDateTimePicker(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseDateTimePicker = new vwgControl();
vwgDateTimePicker.prototype = objBaseDateTimePicker;
vwgDateTimePicker.prototype.constructor = objBaseDateTimePicker;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgDateTimePicker.prototype.typeName = function ()
{
    return "DateTimePicker";
};

/// <method name="ticks">
/// <summary>
/// Gets the date ticks of the control.
/// </summary>
// TODO: Change to data.
vwgDateTimePicker.prototype.ticks = function (objValue)
{
    if (objValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.DateTime");
    }

    Xml_SetAttribute(this.objNode, "Attr.DateTime", objValue);
};
