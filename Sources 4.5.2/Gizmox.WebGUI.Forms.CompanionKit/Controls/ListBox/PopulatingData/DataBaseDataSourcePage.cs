#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.ListBox.PopulatingData
{
    public partial class DataBaseDataSourcePage : UserControl
    {
        public DataBaseDataSourcePage()
        {
            InitializeComponent();

            //Fill Display and Value Members
            mobjDisplayText.Text = mobjListBox.DisplayMember;
            mobjValueText.Text = mobjListBox.ValueMember;
        }

        /// <summary>
        /// Handles the Load event of the DataBaseDataSourcePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DataBaseDataSourcePage_Load(object sender, EventArgs e)
        {
            //Fill up adapter with data from Customers table of DataBase
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }
    }
}