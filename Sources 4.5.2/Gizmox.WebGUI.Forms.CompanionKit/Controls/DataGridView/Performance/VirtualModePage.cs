using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DataGridView.Features
{
    public partial class VirtualModePage : UserControl
    {
      
        public VirtualModePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjFillDGVButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjFillDGVButton_Click(object sender, EventArgs e)
        {
            //Clears all records if such exist
            if (mobjDGVUserDS.Users.Count > 0)
            {
                mobjDGVUserDS.Users.Clear();
            }
            // Fills up the DataGridView.
            for (int i = 1; i < 3000; i++)
            {
                mobjDGVUserDS.Users.AddUsersRow(string.Format("User{0}", i), string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064");
            }
            //Creates temp Column array and fills with current values 
            DataGridViewColumn[] mobjTempCollection = new DataGridViewColumn[mobjDataGridView.Columns.Count];
            mobjDataGridView.Columns.CopyTo(mobjTempCollection, 0);
            //Temporary unbinding datasource
            mobjDataGridView.DataSource = null;
            //If DVG doesn't contain any column - fills with temp array  
            if (mobjDataGridView.Columns.Count == 0)
            {
                mobjDataGridView.Columns.AddRange(mobjTempCollection);
            }
            //Shows warning message with possibility to stop binding operation or continue it
            MessageBox.Show("Press 'Yes' to cancel this operation or press 'No' to continue (probably, page will fall)", "Page is not responding", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, OnTimeout);
        }

        /// <summary>
        /// Handles the Click event of the mobjFillVDGVButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjFillVDGVButton_Click(object sender, EventArgs e)
        {
            //Clears all records if such exist
            if (mobjVDGVUserDS.Users.Count > 0)
            {
                mobjVDGVUserDS.Users.Clear();
            }
            // Fills up the VirtualDataGridView.
            for (int i = 1; i < 3000; i++)
            {
                mobjVDGVUserDS.Users.AddUsersRow(string.Format("User{0}", i), string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064");
            }
        }

        /// <summary>
        /// Called when [timeout].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnTimeout(object sender, EventArgs e)
        {
            //If 'Yes' button pressed - clear all added data  
            if (((MessageBoxWindow)sender).DialogResult == DialogResult.Yes)
            {
                mobjDGVUserDS = new UserDS();
                mobjDGVBindingSource.DataSource = mobjDGVUserDS;
                mobjDataGridView.DataSource = mobjDGVBindingSource; 
            }
            //If 'No' button pressed - bind back datasource
            else { mobjDataGridView.DataSource = mobjDGVBindingSource;}
        }
    }
}