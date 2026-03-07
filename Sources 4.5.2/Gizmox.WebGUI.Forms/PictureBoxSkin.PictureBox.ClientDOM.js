
function vwgPictureBox(objNode)
{
    vwgControl.call(this, objNode);
}

var objBasePictureBox = new vwgControl();
vwgPictureBox.prototype = objBasePictureBox;
vwgPictureBox.prototype.constructor = objBasePictureBox;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgPictureBox.prototype.typeName = function ()
{
    return "PictureBox";
};

/// <method name="imageUrl">
/// <summary>
/// Gets the url image of the control.
/// </summary>
vwgPictureBox.prototype.imageUrl = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Image", null);
    }

    if (!Aux_IsNullOrEmpty(strValue))
    {
        Xml_SetAttribute(this.objNode, "Attr.Image", strValue);
    }
};