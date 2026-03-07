
// Runs provided SQL query on device Web SQL and 
function fillListView(strQuery, objListView, objDBInfo)
{
    if (strQuery)
    {
        // Execute query
        // Params: callback func, query to execute, db info, params to callback.
        executeSQL(fillListViewData, objDBInfo, strQuery, objListView);
    }
}

// SQL query execution callback. Fills listView with query result data. 
// Params: query, result set, other params.
function fillListViewData(objResultSet, objListView)
{
    var arrData = [];
    
    // Validate params
    if (objResultSet && objListView && objResultSet.rows)
    {
        // Store result rows in array
        for (var i = 0; i < objResultSet.rows.length; i++)
        {
            arrData.push(objResultSet.rows.item(i));
        }

        // Set list view data
        objListView.dataSource(arrData);

        // Update listView
        objListView.update();
    }
}


// Transaction callback
function transactionCallback()
{
    console.log("transaction complete");
}

// Fills SQL DEMO table with provided data
function fillSqlTable(arrData, objDBInfo)
{
    var strTransactionID = "configDB";
       
    // Delete previously existing data from table.
    executeSQL(transactionCallback, objDBInfo, "DELETE FROM DEMO"); 

    // Insert every data row to SQL table.
    for (var i = 0; i < arrData.length; i++)
    {
        DeviceIntegrator.executeSQL(transactionCallback, objDBInfo, "INSERT INTO DEMO (ID, Name) VALUES (" + arrData[i].ID + ", '" + arrData[i].Name + "')"); 
    }
}

function executeSQL(fncCallback, objDatabaseInfo, strSQLCommand, argument)
{
    // Open database according to provided params
    var objDatabase = vwgContext.deviceIntegrator.Storage.openDatabase(objDatabaseInfo.name, objDatabaseInfo.version, objDatabaseInfo.displayName, objDatabaseInfo.size);

    // Call transaction
    objDatabase.transaction(
        function (objTransaction)
        {
            objTransaction.executeSql(strSQLCommand, [],
                // On execution success..
                function (objTransaction, objSQLResult)
                {
                    fncCallback.apply(this, [objSQLResult, argument]);
                });
        });
}

// Run the query.
function runQuery(strTextBoxId, strListViewId, strDbName, strDisplayName, strVersion, dblSize)
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        var textBox1 = vwgContext.provider.getComponentById(strTextBoxId);
        var listView1 = vwgContext.provider.getComponentById(strListViewId);
        if (textBox1.text())
        {
            window.fillListView(textBox1.text(), listView1, { name: strDbName, displayName: strDisplayName, version: strVersion, size: dblSize });
        }
        else
        {
            alert("No query found");
        }
    });
}

// Initialize db.
function initDababase(strTextBoxId, strListViewId, strDataGatewayUrl, strDbName, strDisplayName, strVersion, dblSize)
{
    // This sample uses Phonegap integration API directly. (No VWG envolve)
    DeviceIntegrator_DeviceReady(function ()
    {
        var textBox1 = vwgContext.provider.getComponentById(strTextBoxId);

        var arrData = [];
        $.ajax({
            url: strDataGatewayUrl, dataType: 'json', timeout: 1000, success: function (res)
            {
                if (res)
                {
                    for (var i = 0; i < res.length; i++)
                    {
                        var row = res[i];
                        arrData.push(row);
                    }

                    window.fillSqlTable(arrData, { name: strDbName, displayName: strDisplayName, version: strVersion, size: dblSize });
                }
                var listView1 = vwgContext.provider.getComponentById(strListViewId);
                window.fillListView(textBox1.text(), listView1, { name: strDbName, displayName: strDisplayName, version: strVersion, size: dblSize });
            }
        });
    });
}