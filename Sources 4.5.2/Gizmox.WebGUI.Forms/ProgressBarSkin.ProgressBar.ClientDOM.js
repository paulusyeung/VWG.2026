
function vwgProgressBar(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseProgressBar = new vwgControl();
vwgProgressBar.prototype = objBaseProgressBar;
vwgProgressBar.prototype.constructor = objBaseProgressBar;

vwgProgressBar.prototype.value = function (objValue)
{
    if (objValue == undefined)
    {
        return Number(Xml_GetAttribute(this.objNode, "Precent"));
    }

    Xml_SetAttribute(this.objNode, "Precent", (objValue >= 0 && objValue <= 100)  ? objValue : "");
};