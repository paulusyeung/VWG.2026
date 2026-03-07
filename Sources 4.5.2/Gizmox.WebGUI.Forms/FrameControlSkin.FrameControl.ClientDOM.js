function vwgFrameControl(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseFrameControl = new vwgControl();
vwgFrameControl.prototype = objBaseFrameControl;
vwgFrameControl.prototype.constructor = objBaseFrameControl;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgFrameControl.prototype.typeName = function ()
{
    return "FrameControl";
};

/// <method name="source">
/// <summary>
/// Gets the source url of the control.
/// </summary>
vwgFrameControl.prototype.source = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Source", "");
    }

    Xml_SetAttribute(this.objNode, "Attr.Source", strValue);
};