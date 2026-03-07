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

namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    public partial class BindingDataSourcePage : UserControl
    {
        public BindingDataSourcePage()
        {
            InitializeComponent();
            //Allow grouping
            this.mobjDataGridView.ShowGroupingDropArea = true;
        }        

        private void BindingDataSourcePage_Load(object sender, EventArgs e)
        {
            //Fill up table adapter with data from table
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);
        }
    }
}