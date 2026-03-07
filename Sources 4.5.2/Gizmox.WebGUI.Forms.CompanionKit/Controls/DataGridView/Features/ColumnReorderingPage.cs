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

namespace CompanionKit.Controls.DataGridView.Features
{
    public partial class ColumnReorderingPage : UserControl
    {
        public ColumnReorderingPage()
        {
            InitializeComponent();
        }

        private void ColumnReorderingPage_Load(object sender, EventArgs e)
        {
            // Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);
            
        }
    }
}