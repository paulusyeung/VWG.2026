
function vwgDomainUpDown(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseDomainUpDown = new vwgControl();
vwgDomainUpDown.prototype = objBaseDomainUpDown;
vwgDomainUpDown.prototype.constructor = objBaseDomainUpDown;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgDomainUpDown.prototype.typeName = function ()
{
    return "DomainUpDown";
};

/// <method name="selectedIndex">
/// <summary>
/// Gets the selected index of the control.
/// </summary>
vwgDomainUpDown.prototype.selectedIndex = function (intValue)
{
    if (intValue == undefined)
    {
        return Number(Xml_GetAttribute(this.objNode, "Attr.Value"));
    }

    var intIndex = Number(intValue);
    if (!isNaN(intIndex))
    {
        var objOptionNode = Xml_SelectSingleNode("Tags.Options/Tags.Option[@Attr.Index=" + intIndex + "]", this.objNode);
        if (objOptionNode)
        {
            Xml_SetAttribute(this.objNode, "Attr.Text", Xml_GetAttribute(objOptionNode, "Attr.Text", ""));
            Xml_SetAttribute(this.objNode, "Attr.Value", intIndex);
            return;
        }
    }

    Xml_SetAttribute(this.objNode, "Attr.Value", -1);
    Xml_SetAttribute(this.objNode, "Attr.Text", "");
};