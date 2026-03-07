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

namespace CompanionKit.Controls.ListView.PopulatingData
{
    public partial class BindingDataSourcePage : UserControl
    {
        public BindingDataSourcePage()
        {
            InitializeComponent();
        }

        private void BindingDataSourcePage_Load(object sender, EventArgs e)
        {
            // Fill up adapter, that is DataSources for the ListView, with data of Database Customer table.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }
    }
}