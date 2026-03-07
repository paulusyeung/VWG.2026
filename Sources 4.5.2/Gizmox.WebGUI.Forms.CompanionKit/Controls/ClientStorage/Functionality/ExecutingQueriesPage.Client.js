//String array
var arrUsers = ["John", " Elizabeth", "Steve", "Kevin", "George", "Michael", "David", "James", "William", "Mary"];

/// <method name="ExecuteQuery">
/// <summary>
///	Executes SQL query
/// </summary>
function ExecuteQuery(strQuery, blnIsSelectQueryType) {
    //If type of query INSERT or DELETE - execute query and update the list
    if (!blnIsSelectQueryType) {
        ClientStorage.executeSql(strQuery);
        ClientStorage.executeSql("SELECT * FROM 'objClientTable'", [], OnSuccess, OnError);
    }
    //If Select then just execute query
    else { ClientStorage.executeSql(strQuery, [], OnSuccess, OnError); }
}
///</method>

/// <method name="InititializeDatabase">
/// <summary>
///	//Fills dataBase with records
/// </summary>
function InititializeDatabase() {
    //Removes all records from storage 
    ClientStorage.executeSql("DELETE FROM 'objClientTable'");
    for (var i = 0; i < 10; i++) {
        //Inserts records to DataBase
        ClientStorage.executeSql("INSERT INTO 'objClientTable' (Id,Users) VALUES (?,?)", [i,arrUsers[i]]);
    }
    //
    ClientStorage.executeSql("SELECT * FROM 'objClientTable'",[],OnSuccess,OnError);
}
///</method>

/// <method name="OnSuccess">
/// <summary>
///	Fills listView control
/// </summary>
function OnSuccess(arrResults) {
    var objListView = vwgContext.provider.getComponentByClientId("listView");
    objListView.dataSource(arrResults);
    objListView.update();
}
///</method>

/// <method name="OnError">
/// <summary>
///	Shows error message
/// </summary>
function OnError(transaction, error) {
    alert(error.message);
}
///</method>
