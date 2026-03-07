#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections.Specialized;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    public partial class ResultsPropertyForm : Form
    {
        public ResultsPropertyForm()
        {
            InitializeComponent();

            // Set selected indexes of ComboBox controls
            cmbColor.SelectedIndex = 0;
            cmbSize.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles Click event of Button control
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Create collection that will contain result values
            NameValueCollection results = new NameValueCollection();

            // Add result values to collection
            results.Add("Color", cmbColor.SelectedItem.ToString());
            results.Add("Size", cmbSize.SelectedItem.ToString());

            // Clear collection from all keys and values
            Context.Results.Clear();
            // Add collection with result values to return
            Context.Results.Add(results);

            // Show MessageBox window for notification
            MessageBox.Show("Results are sent");
        }
    }
}