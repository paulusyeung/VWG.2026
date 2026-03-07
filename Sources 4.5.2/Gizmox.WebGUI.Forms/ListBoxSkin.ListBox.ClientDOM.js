function vwgListBox(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseListBox = new vwgControl();
vwgListBox.prototype = objBaseListBox;
vwgListBox.prototype.constructor = objBaseListBox;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgListBox.prototype.typeName = function ()
{
    return "ListBox";
};

/// <method name="selectedIndex">
/// <summary>
/// Gets the selected index of the control.
/// </summary>
vwgListBox.prototype.selectedIndex = function (intValue)
{
    if (typeof intValue === "undefined")
    {
        // Try getting exist option nodes.
        var objOptionNode = Xml_SelectSingleNode("Tags.Option[@Attr.Selected='1']", this.objNode);
        if (objOptionNode)
        {
            return Xml_GetAttribute(objOptionNode, "Idx", null);
        }
    }
    else
    {
        // Get selected option
        var objSelectedOptionNode = Xml_SelectSingleNode("Tags.Option[@Attr.Selected='1']", this.objNode);
        if (objSelectedOptionNode)
        {
            // Get its index
            var intSelectedIndex = parseInt(Xml_GetAttribute(objSelectedOptionNode, "Idx", -1), 10);
            
            // If selected is not equls to new selection index
            if (intSelectedIndex > -1 && intValue !== intSelectedIndex)
            {
                // Reset its selection attribute.
                Xml_SetAttribute(objSelectedOptionNode, "@Attr.Selected", "0");

                // Get node by index to be selected.
                var objOptionNode = Xml_SelectSingleNodes("Tags.Option[@Idx='" + intValue + "']", this.objNode);

                // Select it
                if (objOptionNode)
                {
                    Xml_SetAttribute(objOptionNode, "@Attr.Selected", "1");
                }
            }            
        }
    }
};

/// <method name="dataSource">
/// <summary>
/// Gets the data source of the control.
/// </summary>
vwgListBox.prototype.dataSource = function (objValue)
{
    if (objValue == undefined)
    {
        var arrData = [];

        var arrOptionNodes = Xml_SelectNodes("Tags.Option", this.objNode);
        for (var i = 0; i < arrOptionNodes.length; ++i)
        {
            var objOptionData = {};
            objOptionData.text = Xml_GetAttribute(arrOptionNodes[i], "Attr.Text", "");
            arrData.push(objOptionData);
        }

        return arrData;        
    }

    // Try getting exist ooption nodes.
    var arrExistOptions = Xml_SelectNodes("Tags.Option", this.objNode);
    if (arrExistOptions)
    {
        // Loop al exist nodes.
        for (var intOption = 0; intOption < arrExistOptions.length; intOption++)
        {
            // Remove current option node.
            Xml_RemoveChild(this.objNode, arrExistOptions[intOption]);
        }
    }

    // Loop all data item nodes.
    for (var i = 0; i < objValue.length; i++)
    {
        // Get current item node.
        var objItemNode = objValue[i];

        // Create a new option node.
        var objOptionNode = Xml_CreateNode(mobjDataDomObject, 1, "Tags.Option", "");

        // Set option node's index and text attributes.
        Xml_SetAttribute(objOptionNode, "Idx", i);
        Xml_SetAttribute(objOptionNode, "Attr.Text", objItemNode.text);

        // Append new option node to listbox node.
        this.objNode.appendChild(objOptionNode);
    }
};
