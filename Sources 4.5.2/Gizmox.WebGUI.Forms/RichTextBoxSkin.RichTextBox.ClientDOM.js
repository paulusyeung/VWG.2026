

function vwgRichTextBox(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseRichTextBox = new vwgControl();
vwgRichTextBox.prototype = objBaseRichTextBox;
vwgRichTextBox.prototype.constructor = objBaseRichTextBox;

vwgRichTextBox.prototype.html = function (objHtml)
{
    if (objHtml == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Source");
    }

    Xml_SetAttribute(this.objNode, "Attr.Source", objHtml ? objHtml : "");
};