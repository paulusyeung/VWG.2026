using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ClientStorage.Functionality
{
    public partial class ExecutingQueriesPage : UserControl
    {
        //Global variables
        bool mblnIsSelectQueryType;
        private string mstrQueryTypePattern = string.Empty;
        private string mstrFields = string.Empty;

        public ExecutingQueriesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ExecutingQueriesPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExecutingQueriesPage_Load(object sender, EventArgs e)
        {
            //Applies ClientStorage control to mainform
            //Note: If Form is using instead of UserControl, this line of code should be replaced to: this.ClientStorage = this.objClientStorage;
            this.Form.ClientStorage = this.mobjClientStorage;
            //Changes state of CheckBoxList's items
            for (int i = 0; i < mobjCheckBoxList.Items.Count; i++)
            {
                mobjCheckBoxList.SetItemChecked(i, true);
            }
            //Selects the query type
            mobjRadioButtonSelect.Checked = true;
            //Fills ListView on load
            VWGClientContext.Current.Invoke("InititializeDatabase");
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjInitButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjInitButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            //Calls InititializeDatabase js-function
            objArgs.Context.Invoke("InititializeDatabase");
        }


        /// <summary>
        /// Handles the CheckedChanged event of the RadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Defines query pattern according to choosen radioButton
            switch (((Gizmox.WebGUI.Forms.RadioButton)sender).Text)
            {
                case "SELECT":
                    mstrQueryTypePattern = "SELECT {0} FROM 'objClientTable'";
                    mblnIsSelectQueryType = true;
                    break;
                case "INSERT":
                    mstrQueryTypePattern = "INSERT INTO 'objClientTable' ({0}) VALUES ()";
                    mblnIsSelectQueryType = false;
                    break;
                case "DELETE":
                    mstrQueryTypePattern = "DELETE FROM 'objClientTable'";
                    mblnIsSelectQueryType = false;
                    break;
            }

            // Cannot run SELECT or INSERT query without fields
            if (!mobjRadioButtonDelete.Checked && string.IsNullOrEmpty(mstrFields))
            {
                mobjQueryTextBox.Text = string.Empty;
            }
            else
            {
                mobjQueryTextBox.Text = string.Format(mstrQueryTypePattern, mstrFields);
            }
        }

        /// <summary>
        /// Handles the ItemCheck event of the mobjCheckBoxList control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void mobjCheckBoxList_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {
            string mstrComma = string.Empty;
            mstrFields = string.Empty;

            //Changes visibility of listView's columns
            mobjListView.Columns[objArgs.Index].Visible = objArgs.NewValue == CheckState.Checked ? true : false;

            //Iterate through checklistbox items
            for (int intItemIndex = 0; intItemIndex < mobjListView.Columns.Count; intItemIndex++)
            {
                // If column is visible, add to query fields
                if (mobjListView.Columns[intItemIndex].Visible)
                {
                    mstrFields += mstrComma + mobjCheckBoxList.Items[intItemIndex];
                    mstrComma = ", ";
                }
            }

            // Cannot run SELECT or INSERT query without fields
            if (string.IsNullOrEmpty(mstrFields) && !mobjRadioButtonDelete.Checked)
            {
                mobjQueryTextBox.Text = string.Empty;
            }
            else
            {
                mobjQueryTextBox.Text = string.Format(mstrQueryTypePattern, mstrFields);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjRunButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRunButton_Click(object sender, EventArgs e)
        {
            //Calls js function, if TextBox is not empty
            if (!string.IsNullOrEmpty(mobjQueryTextBox.Text))
            {
                VWGClientContext.Current.Invoke("ExecuteQuery", mobjQueryTextBox.Text, mblnIsSelectQueryType);
            }
        }
    }
}