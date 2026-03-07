#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using System.Diagnostics;
using Gizmox.WebGUI.Forms.Client;

#endregion

namespace CompanionKit.DeviceIntegration.Storage.Functionality
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SQLExample : UserControl
    {
        #region Members

        private string mstrQueryType = string.Empty;
        private string mstrFields = string.Empty;

        // Web SQL DB settings
        private DatabaseOptions mobjDBOptions = new DatabaseOptions("DB", "1.0", "Test Database", 1024 * 1024);

        #endregion Members

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLExample"/> class.
        /// </summary>
        public SQLExample()
        {
            // Init GUI
            InitializeComponent();

            // Reset client database table.
            ResetDatabaseTable();

            // Check all CheckListBox items.
            for (int intItemIndex = 0; intItemIndex < mobjFieldsSet.Items.Count; intItemIndex++)
            {
                mobjFieldsSet.SetItemChecked(intItemIndex, true);
            }

            // Invoke query analysis.
            OnQueryTypeChanged(null, EventArgs.Empty);
            OnFieldSetChanged(null, new ItemCheckEventArgs(0, CheckState.Checked, CheckState.Checked));

        }

        /// <summary>
        /// Populates the database.
        /// </summary>
        private void ResetDatabaseTable()
        {
            // Create database
            IDatabase objDB = Context.DeviceIntegrator.Storage.OpenDatabase(mobjDBOptions);

            // Create transaction.
            ISQLTransaction objTransaction = objDB.Transaction(OnTransactionComplete);

            // Execute commands.
            objTransaction.ExecuteSQL(LogSQLCommand, "DROP TABLE IF EXISTS DEMO");
            objTransaction.ExecuteSQL(LogSQLCommand, "CREATE TABLE IF NOT EXISTS DEMO (ID unique, Name)");
        }

        /// <summary>
        /// Logs the SQL command.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.Storage.SQLResultEventArgs"/> instance containing the event data.</param>
        private void LogSQLCommand(object sender, SQLResultEventArgs e)
        {
            Debug.WriteLine("Command " + e.Command + " complete.");
        }

        /// <summary>
        /// Called when [transaction complete].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.Storage.TransactionEventArgs"/> instance containing the event data.</param>
        private void OnTransactionComplete(object sender, TransactionEventArgs e)
        {
            Debug.WriteLine("Transaction complete.");
        }

        /// <summary>
        /// Resets the database.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PopulateDBTable(object sender, EventArgs e)
        {
            ClientContext objContext = VWGClientContext.Current;

            string objDataGatewayUrl = ClientStaticGateway.GetUrl<DataGateway>("DataGateway");
            objContext.Invoke("initDababase", mtxtQuery.ID.ToString(), mlsvData.ID.ToString(), objDataGatewayUrl, mobjDBOptions.Name, mobjDBOptions.DisplayName, mobjDBOptions.Version, mobjDBOptions.Size);
        }

        /// <summary>
        /// Called when [query type changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnQueryTypeChanged(object sender, EventArgs e)
        {
            // Set query pattern
            mstrQueryType = mrbDelete.Checked ? "DELETE FROM DEMO" : mrbInsert.Checked ? "INSERT INTO DEMO ({0}) VALUES ()" : "SELECT {0} FROM DEMO";

            // Cannot run SELECT or INSERT query without fields
            if (!mrbDelete.Checked && string.IsNullOrEmpty(mstrFields))
            {
                mtxtQuery.Text = string.Empty;
            }
            else
            {
                mtxtQuery.Text = string.Format(mstrQueryType, mstrFields);
            }
        }

        /// <summary>
        /// Called when [field set changed].
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        private void OnFieldSetChanged(object objSender, ItemCheckEventArgs objArgs)
        {
            string strComma = string.Empty;
            mstrFields = string.Empty;

            //Iterate through checklistbox items
            for (int intItemIndex = 0; intItemIndex < mobjFieldsSet.Items.Count; intItemIndex++)
            {
                // If checked, add to query fields, show listview column
                if (mobjFieldsSet.GetItemChecked(intItemIndex))
                {
                    mstrFields += strComma + mobjFieldsSet.Items[intItemIndex];
                    strComma = ", ";
                    mlsvData.Columns[intItemIndex].Visible = true;
                }

                // Else, hide column of listview
                else
                {
                    mlsvData.Columns[intItemIndex].Visible = false;
                }

            }

            // Cannot run SELECT or INSERT query without fields
            if (string.IsNullOrEmpty(mstrFields) && !mrbDelete.Checked)
            {
                mtxtQuery.Text = string.Empty;
            }
            else
            {
                mtxtQuery.Text = string.Format(mstrQueryType, mstrFields);
            }
        }

        /// <summary>
        /// Handles the ClientClick event of the mbtnRun control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mbtnRun_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            ClientContext objContext = objArgs.Context;
            objContext.Invoke("runQuery", mtxtQuery.ID.ToString(), mlsvData.ID.ToString(), mobjDBOptions.Name, mobjDBOptions.DisplayName, mobjDBOptions.Version, mobjDBOptions.Size);
        }
    }
}