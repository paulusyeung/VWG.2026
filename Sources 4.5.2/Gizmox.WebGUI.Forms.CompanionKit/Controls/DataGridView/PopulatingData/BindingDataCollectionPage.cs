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
    public partial class BindingDataCollectionPage : UserControl
    {
        public BindingDataCollectionPage()
        {
            InitializeComponent();

            // Get ResourceHandle for photo of customer.
            global::Gizmox.WebGUI.Common.Resources.ResourceHandle mobjPhotoResource = new global::Gizmox.WebGUI.Common.Resources.ImageResourceHandle("32x32.Photo.png");
            // Set objects collection as DataSource for ComboBox.
            this.mobjDataGridView.DataSource = global::Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomersWithImage(mobjPhotoResource);

        }

        private void mobjDataGridView_CellValidating(object objSender, DataGridViewCellValidatingEventArgs objEventArgs)
        {
            // Gets the column header text
            string mstrHeaderText = this.mobjDataGridView.Columns[objEventArgs.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column
            if (!mstrHeaderText.Equals("Favorite Color")) { return; }

            // Get color from inputted name
            Color mobjNewColor = Color.FromName(objEventArgs.FormattedValue.ToString());
            // Check if the inputted color is a known (valid) color
            if (!(mobjNewColor.IsKnownColor))
            {
                // Show error text on the grid row
                this.mobjDataGridView.Rows[objEventArgs.RowIndex].ErrorText = "Cell must contain a valid color name";
                // Cancel the value change
                objEventArgs.Cancel = true;
            }
        }

        private void mobjDataGridView_CellEndEdit(object objSender, DataGridViewCellEventArgs objEventArgs)
        {
            // Clear the row error in case the user enters a valid value.
            this.mobjDataGridView.Rows[objEventArgs.RowIndex].ErrorText = String.Empty;
        }
    }
}