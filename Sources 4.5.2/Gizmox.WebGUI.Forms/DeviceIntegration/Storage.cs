using System;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Device.Common;
using Newtonsoft.Json.Linq;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Common.Device;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    [Serializable]
    public class Storage : DeviceComponent, IStorage
    {
        #region C'tors

        public Storage(DeviceIntegrator objPhonegapIntegrator)
            : base(objPhonegapIntegrator)
        {

        }

        #endregion C'tors

        #region Members

        private LocalStorage mobjLocalStorage;
        private SingleCallMethodStore<LocalStorageEventArgs> mobjClearLocalStorageMethods;
        private SingleCallMethodStore<LocalStorageEventArgs> mobjGetLocalStorageItemMethods;
        private SingleCallMethodStore<LocalStorageEventArgs> mobjSetLocalStorageItemMethods;
        private SingleCallMethodStore<LocalStorageEventArgs> mobjRemoveLocalStorageItemMethods;
        private SingleCallMethodStore<LocalStorageEventArgs> mobjGetLocalStorageKeyMethods;
        private SingleCallMethodStore<SQLResultEventArgs> mobjExecuteSQLMethods;
        private SingleCallMethodStore<TransactionEventArgs> mobjTransactionCallbackMethods;

        #endregion Members

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Storage_Initialize", ID);
        }

        #region Properties

        /// <summary>
        /// Gets the transaction callback methods.
        /// </summary>
        internal SingleCallMethodStore<TransactionEventArgs> TransactionCallbackMethods
        {
            get
            {
                if (mobjTransactionCallbackMethods == null)
                {
                    mobjTransactionCallbackMethods = new SingleCallMethodStore<TransactionEventArgs>();
                }
                return mobjTransactionCallbackMethods;
            }
        }

        /// <summary>
        /// Gets the execute SQL methods store.
        /// </summary>
        internal SingleCallMethodStore<SQLResultEventArgs> ExecuteSQLMethods
        {
            get
            {
                if (mobjExecuteSQLMethods == null)
                {
                    mobjExecuteSQLMethods = new SingleCallMethodStore<SQLResultEventArgs>();
                }
                return mobjExecuteSQLMethods;
            }
        }

        /// <summary>
        /// Gets the clear local storage methods.
        /// </summary>
        internal SingleCallMethodStore<LocalStorageEventArgs> ClearLocalStorageMethods
        {
            get
            {

                if (mobjClearLocalStorageMethods == null)
                {
                    mobjClearLocalStorageMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
                }
                return mobjClearLocalStorageMethods;
            }

        }

        /// <summary>
        /// Gets the set local storage item methods store.
        /// </summary>
        internal SingleCallMethodStore<LocalStorageEventArgs> SetLocalStorageItemMethods
        {
            get
            {
                if (mobjSetLocalStorageItemMethods == null)
                {
                    mobjSetLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
                }
                return mobjSetLocalStorageItemMethods;
            }
        }

        /// <summary>
        /// Gets the get local storage item methods store.
        /// </summary>
        internal SingleCallMethodStore<LocalStorageEventArgs> GetLocalStorageItemMethods
        {
            get
            {
                if (mobjGetLocalStorageItemMethods == null)
                {
                    mobjGetLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
                }
                return mobjGetLocalStorageItemMethods;
            }
        }


        /// <summary>
        /// Gets the get local storage key methods store.
        /// </summary>
        internal SingleCallMethodStore<LocalStorageEventArgs> GetLocalStorageKeyMethods
        {
            get
            {
                if (mobjGetLocalStorageKeyMethods == null)
                {
                    mobjGetLocalStorageKeyMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
                }
                return mobjGetLocalStorageKeyMethods;
            }
        }

        /// <summary>
        /// Gets the remove local storage item methods store.
        /// </summary>
        internal SingleCallMethodStore<LocalStorageEventArgs> RemoveLocalStorageItemMethods
        {
            get
            {
                if (mobjRemoveLocalStorageItemMethods == null)
                {
                    mobjRemoveLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
                }
                return mobjRemoveLocalStorageItemMethods;
            }
        }

        #endregion Properties

        #region IStorage

        /// <summary>
        /// Gets the local storage.
        /// </summary>
        public ILocalStorage LocalStorage
        {
            get
            {
                if (mobjLocalStorage == null)
                {
                    mobjLocalStorage = new LocalStorage(this);
                }
                return mobjLocalStorage;
            }
        }

        /// <summary>
        /// Opens the database (server).
        /// </summary>
        /// <param name="objOptions">The database options.</param>
        /// <returns>
        /// The database instance.
        /// </returns>
        public IDatabase OpenDatabase(DatabaseOptions objOptions)
        {
            return new Database(objOptions, this);
        }

        #endregion

        #region DeviceComponent

        protected internal override string GetTag()
        {
            return WGTags.Storage;
        }

        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strMethodKey = objEvent.Type;
            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(strMethodKey);

            switch (objSplittedValues.Key)
            {
                // Local Storage
                case "clearLocalStorage":
                    this.ClearLocalStorageMethods.InvokeContextualMethod(objSplittedValues.Value, new LocalStorageEventArgs());
                    break;
                case "getItem":
                    LocalStorageEventArgs objGetArgs = GetLocalStorageArgsFromEvent(objEvent);
                    if (objGetArgs != null)
                    {
                        this.GetLocalStorageItemMethods.InvokeContextualMethod(objSplittedValues.Value, objGetArgs);
                    }
                    break;
                case "setItem":
                    LocalStorageEventArgs objSetArgs = GetLocalStorageArgsFromEvent(objEvent);
                    if (objSetArgs != null)
                    {
                        this.SetLocalStorageItemMethods.InvokeContextualMethod(objSplittedValues.Value, objSetArgs);
                    }
                    break;
                case "removeItem":
                    LocalStorageEventArgs objRemoveArgs = GetLocalStorageArgsFromEvent(objEvent);
                    if (objRemoveArgs != null)
                    {
                        this.RemoveLocalStorageItemMethods.InvokeContextualMethod(objSplittedValues.Value, objRemoveArgs);
                    }
                    break;
                case "key":
                    LocalStorageEventArgs objKeyArgs = GetLocalStorageArgsFromEvent(objEvent);
                    if (objKeyArgs != null)
                    {
                        this.GetLocalStorageKeyMethods.InvokeContextualMethod(objSplittedValues.Value, objKeyArgs);
                    }
                    break;
                case "executeSQL":
                    SQLResultEventArgs objSQLArgs = GetSQLResultEventArgsFromEvent(objEvent);
                    if (objSQLArgs != null)
                    {
                        this.ExecuteSQLMethods.InvokeContextualMethod(objSplittedValues.Value, objSQLArgs);
                    }
                    break;
                case "transaction":
                    TransactionEventArgs objTransactionEventArgs = GetTransactionEventArgsFromEvent(objEvent);
                    if (objTransactionEventArgs != null)
                    {
                        this.TransactionCallbackMethods.InvokeContextualMethod(objSplittedValues.Value, objTransactionEventArgs);
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets the transaction event args from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private TransactionEventArgs GetTransactionEventArgsFromEvent(IEvent objEvent)
        {
            TransactionEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                objArguments = new TransactionEventArgs();
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the transaction event args from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private SQLResultEventArgs GetSQLResultEventArgsFromEvent(IEvent objEvent)
        {
            SQLResultEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                SQLResultSet objResultSet = new SQLResultSet();

                // Get all arguments
                if (!string.IsNullOrEmpty(objEvent["rows"]))
                {
                    int intRowsCount = JsonUtils.Deserialize<int>(objEvent["rows"]);
                    List<Dictionary<string, string>> lstRows = null;
                    Dictionary<string, string> objRowData;

                    if (intRowsCount > 0)
                    {
                        lstRows = new List<Dictionary<string, string>>();
                        for (int intRowIndex = 0; intRowIndex < intRowsCount; intRowIndex++)
                        {
                            if (!string.IsNullOrEmpty(objEvent["row" + intRowIndex]))
                            {
                                objRowData = ParseRowFromJSON(objEvent["row" + intRowIndex]);
                                if (objRowData != null)
                                {
                                    lstRows.Add(objRowData);
                                }
                            }
                        }

                        objResultSet.Rows = lstRows;
                    }

                }

                if (!string.IsNullOrEmpty(objEvent["insertId"]))
                {
                    uint intInsertID;
                    if (uint.TryParse(objEvent["insertId"], out intInsertID))
                    {
                        objResultSet.InsertID = intInsertID;
                    }
                }

                if (!string.IsNullOrEmpty(objEvent["rowsAffected"]))
                {
                    uint intRowsAffected;
                    if (uint.TryParse(objEvent["rowsAffected"], out intRowsAffected))
                    {
                        objResultSet.RowsAffected = intRowsAffected;
                    }
                }

                objArguments = new SQLResultEventArgs(objResultSet);
                if (!string.IsNullOrEmpty(objEvent["command"]))
                {
                    objArguments.Command = objEvent["command"];
                }


            }

            return objArguments;
        }

        /// <summary>
        /// Parses the rows from JSON.
        /// </summary>
        /// <param name="strRowData">The STR rows.</param>
        /// <returns></returns>
        private Dictionary<string, string> ParseRowFromJSON(string strRowData)
        {
            Dictionary<string, string> objRow = JsonUtils.Deserialize<Dictionary<string, string>>(strRowData);
            return objRow;
        }



        /// <summary>
        /// Gets the local storage args from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private LocalStorageEventArgs GetLocalStorageArgsFromEvent(IEvent objEvent)
        {
            LocalStorageEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                // Validate all arguments
                if (!string.IsNullOrEmpty(objEvent["localStorageArgs"]))
                {
                    JObject objJSON = JsonUtils.Deserialize(objEvent["localStorageArgs"]);

                    string strKey = objJSON.Value<string>("key");
                    string strValue = objJSON.Value<string>("item");

                    objArguments = new LocalStorageEventArgs(strKey, strValue);
                }
                else
                {
                    // Exception???
                }
            }

            return objArguments;

        }
        #endregion
    }
}
