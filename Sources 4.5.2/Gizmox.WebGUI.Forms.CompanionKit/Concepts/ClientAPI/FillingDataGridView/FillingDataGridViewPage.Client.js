/// <method name="fillGrid" access="private">
/// <summary>
/// Fills DataGridView. 
/// </summary>
function fillGrid() {
    //Getting components by client Id
    var objNumericUpDown = vwgContext.provider.getComponentByClientId("nud");
    var objDataGridView = vwgContext.provider.getComponentByClientId("dvg");

    //Getting value from numericUpDown component and converting to number
    var intRecordsCount = parseInt(objNumericUpDown.value(), 10);

    // Checking if intRecordsCount is not null and more than 0
    if (intRecordsCount && intRecordsCount > 0) {

        //Creating new array
        var objSource = []; 

        //Filling our source array
        for (i = 0; i < intRecordsCount; i++) {
            objSource.push({ "colId": (i + 1), "colVal": "Value #" + (i + 1) });
        }
        //Assigning array as data source and updating DVG
        objDataGridView.dataSource(objSource);
        objDataGridView.update();
    }
}
/// </method>