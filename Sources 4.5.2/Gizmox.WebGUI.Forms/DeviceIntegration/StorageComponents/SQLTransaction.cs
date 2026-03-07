using System;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Device.Storage;
using System.Collections.Generic;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents
{
    /// <summary>
    /// Allows the user to execute SQL statements against the Web SQL Database on device.
    /// </summary>
    [Serializable]
    public class SQLTransaction : ISQLTransaction
    {
        #region Members

        private Database mobjDatabase;
        private string mstrId;

        //private EventHandler<>

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLTransaction"/> class.
        /// </summary>
        /// <param name="objDatabase">The database.</param>
        internal SQLTransaction(Database objDatabase)
        {
            this.mobjDatabase = objDatabase;
            this.mstrId = "tx_" + this.GetHashCode();
        }

        #endregion C'tors

        #region Properties

        /// <summary>
        /// Gets the transaction ID.
        /// </summary>
        internal string ID
        {
            get { return mstrId; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Executes the SQL command (server callback).
        /// </summary>
        /// <param name="objMethod">The callback method.</param>
        /// <param name="strSQLCommand">The SQL command.</param>
        public void ExecuteSQL(EventHandler<SQLResultEventArgs> objMethod, string strSQLCommand)
        {
            ArrayList lstParams = new ArrayList();
            string strMethodKey = this.mobjDatabase.Storage.ExecuteSQLMethods.StoreContextualSingleCallMethod(this, "executeSQL", objMethod);
            lstParams.Add(strMethodKey);
            lstParams.Add(strSQLCommand);
            lstParams.Add(this.mstrId);

            mobjDatabase.Storage.Invoke("DeviceIntegrator.Storage.executeSQLByTransaction", lstParams.ToArray());
        }

        #endregion Methods


    }
}
