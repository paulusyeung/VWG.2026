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

namespace CompanionKit.Controls.DataGridView.Appearance
{
    public partial class AlternatingStylePage : UserControl
    {
        public AlternatingStylePage()
        {
            InitializeComponent();
        }

        private void AlternatingStylePage_Load(object sender, EventArgs e)
        {
            this.mobjDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
            this.mobjDataGridView.AlternatingRowsDefaultCellStyle.Font = new Font(this.mobjDataGridView.Font, FontStyle.Regular);

            // Relates PropertyGrid with DataGridView AlternatingRowsDefaultCellStyle propety object
            this.mobjPropertyGrid.SelectedObject = this.mobjDataGridView.AlternatingRowsDefaultCellStyle;

            // Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);

        }
    }
}
