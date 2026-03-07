using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Device.Storage;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents
{
    /// <summary>
    /// Represents client database.
    /// </summary>
    [Serializable]
    public class Database : IDatabase
    {
        #region Members

        private string mstrName;
        private string mstrVersion;
        private string mstrDisplayName;
        private double mdblSize;
        private Storage mobjStorage;

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        /// <param name="objOptions">The database options.</param>
        /// <param name="objStorage">The storage.</param>
        public Database(DatabaseOptions objOptions, Storage objStorage)
        {
            mstrName = objOptions.Name;
            mstrVersion = objOptions.Version;
            mstrDisplayName = objOptions.DisplayName;
            mdblSize = objOptions.Size;
            mobjStorage = objStorage;
        }

        #endregion C'tors

        #region Properties

        /// <summary>
        /// Gets the storage.
        /// </summary>
        public Storage Storage
        {
            get { return mobjStorage; }
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public string Name
        {
            get { return mstrName; }
            private set { mstrName = value; }
        }

        /// <summary>
        /// Gets the version of the database.
        /// </summary>
        /// <value>
        /// The version of the database.
        /// </value>
        public string Version
        {
            get { return mstrVersion; }
            private set { mstrVersion = value; }
        }

        /// <summary>
        /// Gets the display name of the database.
        /// </summary>
        /// <value>
        /// The display name of the database.
        /// </value>
        public string DisplayName
        {
            get { return mstrDisplayName; }
            private set { mstrDisplayName = value; }
        }

        /// <summary>
        /// Gets the size of the database in bytes.
        /// </summary>
        /// <value>
        /// The size of the database in bytes.
        /// </value>
        public double Size
        {
            get { return mdblSize; }
            private set { mdblSize = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Allows to atomically verify the version number and change it at the same time as doing a schema update (server).
        /// </summary>
        /// <param name="strNewVersion">The new version.</param>
        public void ChangeVersion(string strNewVersion)
        {
            this.mstrVersion = strNewVersion;
        }

        /// <summary>
        /// Gets a database transaction.
        /// </summary>
        /// <param name="objCallback">Method called when transaction completes.</param>
        /// <returns></returns>
        public ISQLTransaction Transaction(EventHandler<TransactionEventArgs> objCallback)
        {
            SQLTransaction objTransaction = new SQLTransaction(this);
            string strMethodKey = this.mobjStorage.TransactionCallbackMethods.StoreContextualSingleCallMethod(this, "transaction", objCallback);
            ArrayList lstParams = new ArrayList();
            lstParams.Add(strMethodKey);
            lstParams.Add(DatabaseOptions.GetClientArgument(this));
            lstParams.Add(objTransaction.ID);

            mobjStorage.Invoke("DeviceIntegrator.Storage.transaction", lstParams.ToArray());

            return objTransaction;
        }

        #endregion Methods

    }
}
