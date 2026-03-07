
function vwgDataGridView(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseDataGridView = new vwgControl();
vwgDataGridView.prototype = objBaseDataGridView;
vwgDataGridView.prototype.constructor = objBaseDataGridView;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgDataGridView.prototype.typeName = function ()
{
    return "DataGridView";
};

/// <method name="dataSource">
/// <summary>
/// Gets the data source of the object.
/// </summary>
vwgDataGridView.prototype.dataSource = function (objValue)
{
    if (objValue == undefined)
    {       
        //Init output Data object
        var arrData = [];

        //Get Grid's columns data
        var objColDataList = DataGridView_BuildColumnDataList(this.objNode);

        // Get existing row nodes.
        var arrRows = Xml_SelectNodes("WG:Tags.DataGridViewRow[not(@Attr.FilterRow)]", this.objNode);

        // Loop all row nodes.
        for (var intRow = 0; intRow < arrRows.length; intRow++)
        {
            var objRowNode = arrRows[intRow];

            //Create object to hold cells data for current row
            var objCellDetailsData = {};

            // Check if current row is defined as new row, if so we will not put it in the data source.
            var strIsNew = Xml_GetAttribute(objRowNode, "Attr.IsNew", "");
            if (!Aux_IsNullOrEmpty(strIsNew))
            {
                continue;
            }

            // Get cells of current row
            var arrCells = Xml_SelectNodes("WG:Tags.DataGridViewCell[not(@Attr.Type='7')]", objRowNode);

            if (arrCells)
            {
                // Loop all cell nodes.
                for (var intCell = 0; intCell < arrCells.length; intCell++)
                {
                    var objCellNode = arrCells[intCell];

                    if (objCellNode)
                    {

                        //Get client Id and column type fields from column List created earlier
                        var strClientId = objColDataList[intCell].ClientId;

                        var strColumnType = objColDataList[intCell].ColumnType;

                        //Set cell's value to column Id key. Get value from selected attribute by column type
                        objCellDetailsData[strClientId] = DataGridView_GetCellValueByType(objCellNode, strColumnType);

                    }
                }

                //Add Object of all cells data in current row
                arrData.push(objCellDetailsData);
            }
        }

        return arrData;
    }

    // Try getting exist row nodes.
    var arrExistRows = Xml_SelectNodes("WG:Tags.DataGridViewRow", this.objNode);
    if (arrExistRows)
    {
        // Loop al exist nodes.
        for (var intRow = 0; intRow < arrExistRows.length; intRow++)
        {
            // Remove current option node.
            Xml_RemoveChild(this.objNode, arrExistRows[intRow]);
        }
    }

    var strDataGridViewId = Xml_GetAttribute(this.objNode, "Attr.Id", "");
    if (!Aux_IsNullOrEmpty(strDataGridViewId))
    {
        var arrColumns = Xml_SelectNodes("WG:Tags.DataGridViewColumn", this.objNode);
        if (arrColumns)
        {
            // Loop all data item nodes.
            for (var intData = 0; intData < objValue.length; intData++)
            {
                // Get current item node.
                var objItemNode = objValue[intData];
                if (objItemNode)
                {
                    // Create a new row node.
                    var objRowNode = Xml_CreateNode(mobjDataDomObject, 1, "WG:Tags.DataGridViewRow", "http://www.gizmox.com/webgui");
                    if (objRowNode)
                    {
                        // Set member id attribute.
                        Xml_SetAttribute(objRowNode, "Attr.MemberID", String(strDataGridViewId + "_R" + intData));

                        // Set height attribute.
                        Xml_SetAttribute(objRowNode, "Attr.Height", "22");

                        // Loop all column nodes.
                        for (var intColumn = 0; intColumn < arrColumns.length; intColumn++)
                        {
                            var objColumnNode = arrColumns[intColumn];
                            if (objColumnNode)
                            {
                                // Get column client id value.
                                var strClientId = Xml_GetAttribute(objColumnNode, "Attr.ClientId", "");

                                // Get column type.
                                var strColumnType = Xml_GetAttribute(objColumnNode, "Attr.Type", "");

                                // Get column member id.
                                var strColumnMemberID = Xml_GetAttribute(objColumnNode, "Attr.MemberID", "");

                                // Validate column type and client id.
                                if (!Aux_IsNullOrEmpty(strClientId) && !Aux_IsNullOrEmpty(strColumnType) && !Aux_IsNullOrEmpty(strColumnMemberID))
                                {

                                    // Try getting client id out of data item.
                                    var strCellValue = objItemNode[strClientId];

                                    // Create a new cell node.
                                    var objCellNode = Xml_CreateNode(mobjDataDomObject, 1, "WG:Tags.DataGridViewCell", "http://www.gizmox.com/webgui");
                                    if (objCellNode)
                                    {
                                        // Set cell node's type attribute.
                                        Xml_SetAttribute(objCellNode, "Attr.Type", strColumnType);

                                        var strCellMemberId = "D" + String(intData) + String(intColumn);

                                        // Set cell node's member id attribute.
                                        Xml_SetAttribute(objCellNode, "Attr.MemberID", strCellMemberId);

                                        // Render cell node attributes.
                                        DataGridView_RenderCellNodeAttributes(objCellNode, strColumnType, strDataGridViewId, strColumnMemberID, strCellMemberId, strCellValue);

                                        // Append current cell node.
                                        objRowNode.appendChild(objCellNode);
                                    }

                                }
                            }
                        }


                        // Append current row node.
                        this.objNode.appendChild(objRowNode);
                    }
                }
            }
        }
    }
};


/// <method name="DataGridView_BuildColumnDataList">
/// <summary>
/// Get relevant attributes of grid's columns in list
/// </summary>
function DataGridView_BuildColumnDataList(objNode) {

    var objColDataList = [];

    //Get Grid's columns
    var arrColumns = Xml_SelectNodes("WG:Tags.DataGridViewColumn", objNode);
    if (arrColumns) {

        // Loop all column nodes and build list of Columns Data 
        for (var intColumn = 0; intColumn < arrColumns.length; intColumn++) {

            var objColumnNode = arrColumns[intColumn];
            if (objColumnNode) {

                var objCellData = {};

                // Get column client id value.
                objCellData.ClientId = Xml_GetAttribute(objColumnNode, "Attr.ClientId", "");

                // Get column type.
                objCellData.ColumnType = Xml_GetAttribute(objColumnNode, "Attr.Type", "");

                objColDataList.push(objCellData);
            }
        }
    }
    return objColDataList;
}

/// <method name="DataGridView_GetCellValueByType">
/// <summary>
/// Get Value attribute from Cell by its column's type
/// </summary>
function DataGridView_GetCellValueByType(objCellNode, strColumnType) {

    switch (strColumnType) {
        // TextBox column.                      
        case "1":
            return Xml_GetAttribute(objCellNode, "Attr.Value", "");
            break;
        // CheckBox column.                     
        case "2":
            return Xml_GetAttribute(objCellNode, "Attr.Checked", "");
            break;
        // Picture box column                 
        case "3":
            return Xml_GetAttribute(objCellNode, "Attr.Image", "");
            break;
        // LinkLabel column.                    
        case "4":
            return Xml_GetAttribute(objCellNode, "Attr.Text", "");
            break;
        // Button column.                       
        case "5":
            return Xml_GetAttribute(objCellNode, "Attr.Text", "");
            break;
        // ComboBox column.                  
        case "6":
            return Xml_GetAttribute(objCellNode, "Attr.Value", "");
            break;

    }
}
/// </method>

/// <method name="DataGridView_RenderCellNodeAttributes">
/// <summary>
/// Render cell node attributes.
/// </summary>
function DataGridView_RenderCellNodeAttributes(objCellNode,strColumnType,strDataGridViewId,strColumnMemberID,strCellMemberId,strCellValue)
{
    // Validate recieved arguments.
    if(objCellNode && !Aux_IsNullOrEmpty(strColumnType) && !Aux_IsNullOrEmpty(strCellValue))
    {
        switch (strColumnType) 
        {
            // TextBox cell.
            case "1":
                // Render text box cell attributes.
                Xml_SetAttribute(objCellNode, "Attr.Events", "8");
                Xml_SetAttribute(objCellNode, "Attr.Value", strCellValue);
                Xml_SetAttribute(objCellNode, "Attr.TextImageRelation", "0");
                Xml_SetAttribute(objCellNode, "Attr.TextAlign", "MiddleLeft");
                Xml_SetAttribute(objCellNode, "Attr.SupportActiveMode", "1");
                Xml_SetAttribute(objCellNode, "Attr.SupportEditMode", "1");
                break;
            // Button cell.
            case "5":
                // Render button cell attributes.
                Xml_SetAttribute(objCellNode, "Attr.Text", strCellValue);
                Xml_SetAttribute(objCellNode, "Attr.TextImageRelation", "0");
                Xml_SetAttribute(objCellNode, "Attr.TextAlign", "MiddleLeft");
                break;
            // CheckBox cell.
            case "2":
                // Render check box cell attributes.
                Xml_SetAttribute(objCellNode, "Attr.Events", "8");

                if(!isNaN(Number(strCellValue)))
                {
                    Xml_SetAttribute(objCellNode, "Attr.Checked", strCellValue);
                }
                else if(strCellValue=="true" || strCellValue=="false")
                {
                    Xml_SetAttribute(objCellNode, "Attr.Checked", strCellValue=="true"?"1":"0");
                }
                Xml_SetAttribute(objCellNode, "Attr.TextImageRelation", "0");
                Xml_SetAttribute(objCellNode, "Attr.ContentAlign", "MiddleCenter");
                Xml_SetAttribute(objCellNode, "Attr.SupportEditMode", "1");
                break;
            // Picture cell.
            case "3":
                // Render picture box cell attributes.
                Xml_SetAttribute(objCellNode, "Attr.Image", strCellValue);
                Xml_SetAttribute(objCellNode, "Attr.TextImageRelation", "0");
                break;
            // LinkLabel cell.
            case "4":
                // Render link label cell attributes.
                Xml_SetAttribute(objCellNode, "Attr.Text", strCellValue);
                Xml_SetAttribute(objCellNode, "Attr.TextImageRelation", "0");
                Xml_SetAttribute(objCellNode, "Attr.TextAlign", "MiddleLeft");
                break;
            // ComboBox cell.
            case "6":
                // Render combo box cell attributes.
                Xml_SetAttribute(objCellNode, "Attr.Events", "8");
                Xml_SetAttribute(objCellNode, "Attr.Value", strCellValue);
                Xml_SetAttribute(objCellNode, "Attr.TextImageRelation", "0");
                Xml_SetAttribute(objCellNode, "Attr.TextAlign", "MiddleLeft");
                Xml_SetAttribute(objCellNode, "Attr.SupportEditMode", "1");
                Xml_SetAttribute(objCellNode, "Attr.Style", "DDL");
                Xml_SetAttribute(objCellNode, "Attr.Captures", "33789");
                Xml_SetAttribute(objCellNode, "Attr.ItemHeight", "18");
                Xml_SetAttribute(objCellNode, "Attr.CancelSelectOnDropDownNaviagation", "1");
                Xml_SetAttribute(objCellNode, "Attr.SupportKeydownAccumulating", "0");
                Xml_SetAttribute(objCellNode, "Attr.Maximum", "8");
                Xml_SetAttribute(objCellNode, "Attr.AutoCompleteMode", "N");
                Xml_SetAttribute(objCellNode, "Attr.Animation", "1");
                Xml_SetAttribute(objCellNode, "Attr.OptionsComponent", strDataGridViewId+"_"+strColumnMemberID);
                Xml_SetAttribute(objCellNode, "Attr.Id", strDataGridViewId+"_"+strCellMemberId);
                break;
        }
    }
}
/// </method>