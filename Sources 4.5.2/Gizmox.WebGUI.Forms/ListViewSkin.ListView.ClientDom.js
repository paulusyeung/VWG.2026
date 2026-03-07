
function vwgListView(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseListView = new vwgControl();
vwgListView.prototype = objBaseListView;
vwgListView.prototype.constructor = objBaseListView;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgListView.prototype.typeName = function ()
{
    return "ListView";
};

/// <method name="dataSource">
/// <summary>
/// Gets the data source of the control.
/// </summary>
vwgListView.prototype.dataSource = function (objValue)
{
    if (objValue == undefined)
    {
        throw Error("Setting dataSource does not implemeneted yet.");
    }

    // Try getting exist row nodes.
    var arrExistRows = Xml_SelectNodes("Tags.Row", this.objNode);
    if (arrExistRows)
    {
        // Loop al exist nodes.
        for (var intRow = 0; intRow < arrExistRows.length; intRow++)
        {
            // Remove current option node.
            Xml_RemoveChild(this.objNode, arrExistRows[intRow]);
        }
    }

    var strListViewId = Xml_GetAttribute(this.objNode, "Attr.Id", "");
    var arrColumnNodes = Xml_SelectNodes("Tags.Column", this.objNode);

    // Loop all data item nodes.
    for (var intData = 0; intData < objValue.length; intData++)
    {
        // Get current item node.
        var objItemNode = objValue[intData];
        // Create a new row node.
        var objRowNode = Xml_CreateNode(mobjDataDomObject, 1, "Tags.Row", "");
        // Set id attribute.
        Xml_SetAttribute(objRowNode, "Attr.Id", String(strListViewId + "_" + intData));

        // Set UseItemStyleForSubItems attribute.
        Xml_SetAttribute(objRowNode, "Attr.UseItemStyleForSubItems", "1");

        // Set Events attribute.
        Xml_SetAttribute(objRowNode, "Attr.Events", "0");

        // Loop all column nodes.
        for (var intColumn = 0; intColumn < arrColumnNodes.length; intColumn++)
        {
            var objColumnNode = arrColumnNodes[intColumn];

            // Get column client id value.
            var strClientId = Xml_GetAttribute(objColumnNode, "Attr.ClientId", "");

            // Get column name.
            var strColumnName = Xml_GetAttribute(objColumnNode, "Attr.Name", "");

            // Validate column name and client id.
            if (!Aux_IsNullOrEmpty(strClientId) && !Aux_IsNullOrEmpty(strColumnName))
            {
                // Try getting client id out of data item.
                var strAttributeValue = objItemNode[strClientId];
                if (!Aux_IsNullOrEmpty(strAttributeValue))
                {
                    // Set row node column name with a proper value.
                    Xml_SetAttribute(objRowNode, strColumnName, strAttributeValue);
                }
            }
        }

        // Append current row node.
        this.objNode.appendChild(objRowNode);
    }
};

/// <method name="selectedItems">
/// <summary>
/// Gets and sets selected items of the control.
/// </summary>
vwgListView.prototype.selectedItems = function ()
{
    // Get first and last selected indicies.
    var intFirstIndex = parseInt(Xml_GetAttribute(this.objNode, "FSI", ""), 10);
    var intLastIndex = parseInt(Xml_GetAttribute(this.objNode, "LSI", ""), 10);

    if (intFirstIndex >= 0 && intLastIndex >= 0)
    {
        // Get all rows (items)
        var arrRowsNodes = Xml_SelectNodes("./Tags.Row", this.objNode);
        var arrSelectedRowNodes = [];

        var intStartIndex = Math.min(intFirstIndex, intLastIndex);
        var intEndIndex = Math.max(intFirstIndex, intLastIndex);

        // Select items between FSI-LSI
        for (var intIndex = intStartIndex; intIndex <= intEndIndex; intIndex++)
        {
            arrSelectedRowNodes.push(arrRowsNodes[intIndex]);
        }
        // Return ClientDom array of selected items.
        return ClientDOM_MapRowsToListViewItems(arrSelectedRowNodes);
    }
};

/// <method name="items">
/// <summary>
/// Gets and sets items of the control.
/// </summary>
vwgListView.prototype.items = function ()
{
    var arrRowsNodes = Xml_SelectNodes("./Tags.Row", this.objNode);    
    return ClientDOM_MapRowsToListViewItems(arrRowsNodes);
};


function vwgListViewItem(objNode)
{
    vwgComponent.call(this, objNode);
}

var objBaseListViewItem = new vwgComponent();
vwgListViewItem.prototype = objBaseListViewItem;
vwgListViewItem.prototype.constructor = objBaseListViewItem;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgListViewItem.prototype.typeName = function ()
{
    return "ListViewItem";
};

/// <method name="typeName">
/// <summary>
/// Gets the text of listview item.
/// </summary>
vwgListViewItem.prototype.text = function (strValue)
{
    if (typeof strValue === "undefined")
    {
        return Xml_GetAttribute(this.objNode, "c" + this.index || 0, "");
    }
    else
    {
        Xml_SetAttribute(this.objNode, "c" + this.index || 0, strValue);
    }
};

/// <method name="subItems">
/// <summary>
/// Gets and sets sub items of the control.
/// </summary>
vwgListViewItem.prototype.subItems = function ()
{
    // Get liesview columns
    var arrColumnNodes = Xml_SelectNodes("../Tags.Column", this.objNode);

    // Try to get subitems (start from index = 1)
    if (arrColumnNodes && arrColumnNodes.length > 1)
    {
        var objSubItems = [];
        for (var intIndex = 1, len = arrColumnNodes.length; intIndex < len; intIndex++)
        {
            var objListViewSubItem = new vwgListViewItem(this.objNode);
            objListViewSubItem.index = intIndex;
            objSubItems.push(objListViewSubItem);
        }

        return objSubItems;
    }
};

/// <method name="tagName">
/// <summary>
/// Gets and sets tag name of the control.
/// </summary>
vwgListViewItem.prototype.tagName = function (strTagName)
{
    if (strTagName == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.ClientTag" + this.index, "");
    }

    return Xml_SetAttribute(this.objNode, "Attr.ClientTag" + this.index, strTagName);
};

/// <summary>
/// Maps the Row nodes to ListViewItems
/// </summary>
ClientDOM_MapRowsToListViewItems = function (arrRowNodes)
{
    if (arrRowNodes.length == 0) { return; }

    var objItems = [];
    for (var intIndex = 0; intIndex < arrRowNodes.length; intIndex++)
    {
        var objRowNode = arrRowNodes[intIndex];
        var objItem = new vwgListViewItem(objRowNode);
        objItems.push(objItem);
    }

    return objItems;
};
/// </method>


