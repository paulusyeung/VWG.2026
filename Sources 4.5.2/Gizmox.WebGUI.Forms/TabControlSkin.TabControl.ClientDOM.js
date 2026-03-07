function vwgTabControl(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseTabControl = new vwgControl();
vwgTabControl.prototype = objBaseTabControl;
vwgTabControl.prototype.constructor = objBaseTabControl;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgTabControl.prototype.typeName = function ()
{
    return "TabControl";
};

vwgTabControl.prototype.selectedIndex = function (intIndex)
{
    if (intIndex == undefined)
    {
        var strTabPageId = Xml_GetAttribute(this.objNode, "Attr.Selected");
        for (var i = 0; i < this.tabPages().length; i++)
        {
            if (strTabPageId == this.tabPages()[i].id())
            {
                return i;
            }
        }
        
        return -1;
    }

    var objWindow = Web_GetActiveWindow();

    var objTabPageNodes = Xml_SelectNodes("WC:Tags.TabPage", this.objNode);
    var objTabPageNode = objTabPageNodes[intIndex];
    var strTabPageId = Xml_GetAttribute(objTabPageNode, "Attr.Id", "");
    TabControl_ChangeTab(strTabPageId, objWindow, objWindow.event, false);
};

vwgTabControl.prototype.tabPages = function ()
{
    return this.controls();
};
