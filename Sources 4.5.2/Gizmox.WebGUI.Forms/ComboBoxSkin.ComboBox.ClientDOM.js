
function vwgComboBox(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseComboBox = new vwgControl();
vwgComboBox.prototype = objBaseComboBox;
vwgComboBox.prototype.constructor = objBaseComboBox;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgComboBox.prototype.typeName = function ()
{
    return "ComboBox";
};

/// <method name="selectedIndex">
/// <summary>
/// Gets and sets a the selected index.
/// </summary>
vwgComboBox.prototype.selectedIndex = function (intValue)
{
    if (intValue == undefined)
    {
        var strValue = Xml_GetAttribute(this.objNode, "Attr.Value", "");
        if (!Aux_IsNullOrEmpty(strValue))
        {
            // Cast value to integer.
            var intIndex = Number(strValue);
            if (intIndex >= 0)
            {
                // Decrease value inorder to fix zero base.
                intIndex++;

                // Try getting exist ooption nodes.
                var objOptionNode = Xml_SelectSingleNode("Tags.Options/Tags.Option[position()=" + String(intIndex) + "]", this.objNode);
                if (objOptionNode)
                {
                    return Xml_GetAttribute(objOptionNode, "Attr.Value", Xml_GetAttribute(objOptionNode, "Attr.Index", null));
                }
            }
        }
    }

    // Cast value to integer.
    var intIndex = Number(intValue);
    if (intIndex >= 0)
    {
        // Try getting exist ooption nodes.
        var objOptionNode = Xml_SelectSingleNode("Tags.Options/Tags.Option[position()=" + String(Number(intIndex + 1)) + "]", this.objNode);
        if (objOptionNode)
        {
            Xml_SetAttribute(this.objNode, "Attr.Text", Xml_GetAttribute(objOptionNode, "Attr.Text", ""));
            Xml_SetAttribute(this.objNode, "Attr.Value", String(intIndex));

            return;
        }
    }

    Xml_SetAttribute(this.objNode, "Attr.Value", "-1");
    Xml_SetAttribute(this.objNode, "Attr.Text", "");
};

/// <method name="dataSource">
/// <summary>
/// Gets and sets the data source.
/// </summary>
vwgComboBox.prototype.dataSource = function (objValue)
{
    if (objValue == undefined)
    {
        var arrData = [];
        // Try getting exist ooption nodes.
        var arrOptionNodes = Xml_SelectNodes("Tags.Options/Tags.Option", this.objNode);
        if (arrOptionNodes)
        {
            for (var intIndex = 0; intIndex < arrOptionNodes.length; ++intIndex)
            {
                var objOptionData = {};
                objOptionData.text = Xml_GetAttribute(arrOptionNodes[intIndex], "Attr.Text", "");
                arrData.push(objOptionData);
            }
        }

        return arrData;
    }

    // Try getting exist option nodes.
    var objExistOptions = Xml_SelectSingleNode("Tags.Options", this.objNode);
    if (objExistOptions)
    {
        // Remove current option node.
        Xml_RemoveChild(this.objNode, objExistOptions);
    }

    // Check that data nodes exists.
    if (objValue.length > 0)
    {
        // Get the max items to display
        Xml_SetAttribute(this.objNode, "Attr.Maximum", String(Math.min(8, objValue.length)));

        // Create a new options node.
        var objOptionsNode = Xml_CreateNode(mobjDataDomObject, 1, "Tags.Options", "");
        if (objOptionsNode)
        {
            // Set option node's animation attribute.
            Xml_SetAttribute(objOptionsNode, "Attr.Animation", "1");

            // Append new options node to listbox node.
            this.objNode.appendChild(objOptionsNode);

            // Loop all data item nodes.
            for (var intData = 0; intData < objValue.length; intData++)
            {
                // Get current item node.
                var objItemNode = objValue[intData];

                // Create a new option node.
                var objOptionNode = Xml_CreateNode(mobjDataDomObject, 1, "Tags.Option", "");

                // Set option node's index and text attributes.
                Xml_SetAttribute(objOptionNode, "Attr.Index", intData);
                Xml_SetAttribute(objOptionNode, "Attr.Text", objItemNode.text);

                // Append new option node to listbox node.
                objOptionsNode.appendChild(objOptionNode);
            }
        }
    }
};

/// <method name="dataSource">
/// <summary>
/// Gets and sets the text.
/// </summary>
vwgComboBox.prototype.text = function ()
{    
    return Xml_GetAttribute(this.objNode, "Attr.Text");
};
