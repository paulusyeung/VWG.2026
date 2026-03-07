
// The current client storage
var mobjClientStorage = null;

/// <object name="ClientStorage">
/// <summary>
/// Provides support  for client storage
/// </summary>
function ClientStorage(objStorageNode)
{
    // Local storage node
    this.mobjStorageNode = objStorageNode;

    // Local storage DB
    this.mobjStorageDB = null;

    // Local storage DB tables
    this.mobjStorageTables = {};
}


/// <summary>
/// The ClientStorage instance methods
/// </summary>
ClientStorage.prototype = {

	/// <method name="_createDB">    
	/// <summary>
    /// Creates db if needed
    /// <summary>
    _createDB: function (fncCallback) {

        // If we need to create the sotrage DB and there is a valid storage node
        if(!this.mobjStorageDB && this.mobjStorageNode)
        {
			// Variable for calling this
			var objCaller = this;

			// Open data base
			this.mobjStorageDB = openDatabase(
                Xml_GetAttribute(this.mobjStorageNode, "Attr.Name", "db"),
                "1.0",
                Xml_GetAttribute(this.mobjStorageNode, "Attr.Description", "1.0"),
                2 * 1024 * 1024);


			// Get the tables list
			var objTables = Xml_SelectNodes("Tags.Table", this.mobjStorageNode);

			// The table index
			var intTableIndex = 0;

			// Create the current table
            var fncCreateTable = function () {

				// Try to create table
                objCaller._createTable(objTables[intTableIndex], function () {

					// Increment the table index
					intTableIndex++;

					// If there are more tables to create
					if (intTableIndex < objTables.length)
					{
						// Create next table
						fncCreateTable();
					}
					else
					{
						// Call the create DB callback 
						fncCallback();
					}

				});
			};

			// Create the tables
			fncCreateTable();


		}
		else
		{
			// Call the caller callback 
			fncCallback();
		}

	},
	/// </method>



	/// <method name="createTable">    
	/// <summary>
	/// Creates db table if needed
	/// <summary>
    _createTable: function (objTable, fncCallback) {

		// If there is a valid table definition
		if (objTable)
		{
			// Create table sql
			var strSQL = "CREATE TABLE IF NOT EXISTS " + Xml_GetAttribute(objTable, "Attr.Name") + "(";

			// Get the columns list
			var objColumns = Xml_SelectNodes("Tags.Column", objTable);

			// Loop all columns
			for (var intIndex = 0; intIndex < objColumns.length; intIndex++)
			{
				// If we need to add a comma
				if (intIndex > 0)
				{
					// Add column seperator
					strSQL += ", ";
				}

				// Get the column at the specific position
				var objColumn = objColumns[intIndex];

				// Add the column name
				strSQL += "[" + Xml_GetAttribute(objColumn, "Attr.Name") + "] ";

				// Set autoincrement if needed.
				if (Xml_IsAttribute(objColumn, "Attr.AutoIncreased", "1"))
				{
					strSQL += "INTEGER PRIMARY KEY AUTOINCREMENT";
				}
				else
				{
					// Add the column type
					strSQL += Xml_GetAttribute(objColumn, "Attr.Type") + " ";

					// Set primary key if needed.
					if (Xml_IsAttribute(objColumn, "Attr.PrimaryKey", "1"))
					{
						strSQL += " PRIMARY KEY";
					}
					else
					{
						if (Xml_IsAttribute(objColumn, "Attr.Unique", "1"))
						{
							strSQL += "UNIQUE";
						}
						else
						{
							// Set default value if exists
							var strDefaultValue = Xml_GetAttribute(objColumn, "Attr.Default");

							if (!Aux_IsNullOrEmpty(strDefaultValue))
							{
								strSQL += "DEFAULT " + strDefaultValue;
							}
						}
					}
				}
			}

			// Close the column definition
			strSQL += ")";

			// Create the table and call the callback
			this._executeSql(strSQL, [], fncCallback);
		}
		else
		{
			if (fncCallback)
			{
				fncCallback();
			}
		}
	},
	/// </method>

	/// <method name="createTable">    
	/// <summary>
	/// Creates db table if needed
	/// <summary>
    _executeSql: function (strSQL, arrParams, fncResultsCallback) {

		try
		{
			// Debug executed SQL.
			Debug_Log("Client - execute SQL ==> " + strSQL);

			// Create transaction
			this.mobjStorageDB.transaction(

			// Called after transaction was created
                function (objTransaction) {

                	try
                	{
                		// Execute the SQL
                		objTransaction.executeSql(

                		// The SQL to run
                            strSQL,

                		// The SQL parameters
                            arrParams,

                		// Call the result
                            function (objTransaction, objResults) {

                            	// If there is a valid callback function
                            	if (fncResultsCallback)
                            	{
                            		// Call the callback function
                            		fncResultsCallback(ClientStorage_GetResults(objResults));
                            	}
                            },

                            function (objTransaction, objError) {

                                alert(objError.message);

                            	if (fncResultsCallback)
                            	{
                            		fncResultsCallback(null);
                            	}
                            });
                	}
                	catch (e)
                	{
                		alert(e.message);

                		if (fncResultsCallback)
                		{
                			fncResultsCallback(null);
                		}
                	}
                });
		}
		catch (e)
		{
			alert(e.message);

			if (fncResultsCallback)
			{
				fncResultsCallback(null);
			}
		}
	}
	/// </method>
};
/// </object>

/// <method name="Client_ProcessStorageInAction">
/// <summary>
/// 
/// </summary>
ClientStorage.executeSql = function(strSQL, arrParams, fncCallback) {

    try
    {
        // Get the client storage
        var objClientStorage = ClientStorage_GetInstance();

        // If there is a valid client storage
        if(objClientStorage!=null)
        {
            // Ensure DB is created
            objClientStorage._createDB(function() {

                // Execute SQL and call the callback function
                objClientStorage._executeSql(strSQL, arrParams, fncCallback);
           });
        }
    }
    catch(e)
    {
        alert(e.message);

        if(fncCallback)
        {
            fncCallback(null);
        }
    }
};
/// </method>


ClientStorage.Globals = {};


/// <method name="ClientStorage_GetInstance">    
/// <summary>
/// Get client storage instance
/// <summary>
function ClientStorage_GetInstance() 
{
    // If client storage had not been created
    if(!mobjClientStorage)
    {
        // If there is a valid data object
        if(mobjDataRootObject)
        {
            // Get the storage node 
            var objStorageNode = Xml_SelectSingleNode("./" + "/Tags.ClientStorage", mobjDataRootObject);

            // If there is a valid storage node
            if(objStorageNode)
            {
                // Create the client storage 
                mobjClientStorage = new ClientStorage(objStorageNode);
            }
            else
            {
                alert("Could not find storage schema.");
            }
        }
    }

    return mobjClientStorage;
}
/// </method>

/// <method name="ClientStorage_GetResults">    
/// <summary>
/// Gets results as an array of objects
/// <summary>
function ClientStorage_GetResults(objResults) 
{   
    try
    {
        // The collected results
        var arrResults = [];

        // If there is a valid results
        if(objResults)
        {      
            // Get the results rows
            var objRows = objResults.rows;

            // If there is a valid result
            if(objRows)
            {
                // Get the rows length
                var intLength = objRows.length;

                // Loop all rows
                for (var intIndex = 0; intIndex < intLength; intIndex++) 
                {
                    // Add the result to the array
                    arrResults.push(objRows.item(intIndex));
                }
            }
        }

        // Return the results
        return arrResults;
    }
    catch(e)
    {
        alert(e.message);

        return null;
    }
}
/// </method>
