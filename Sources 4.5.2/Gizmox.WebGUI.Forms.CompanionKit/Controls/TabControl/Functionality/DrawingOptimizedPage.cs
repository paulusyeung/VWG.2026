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

namespace CompanionKit.Controls.TabControl.Functionality
{
    public partial class DrawingOptimizedPage : UserControl
    {
        public DrawingOptimizedPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example's UserControl
        /// </summary>
        void DrawingOptimizedPage_Load(object sender, EventArgs e)
        {
            // Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);  
        }
    }
}