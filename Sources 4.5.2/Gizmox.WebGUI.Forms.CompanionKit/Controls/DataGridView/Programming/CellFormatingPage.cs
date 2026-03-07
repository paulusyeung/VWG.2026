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

namespace CompanionKit.Controls.DataGridView.Programming
{
    public partial class CellFormatingPage : UserControl
    {

        public CellFormatingPage()
        {
            InitializeComponent();
        }

        private void CellFormatingPage_Load(object sender, EventArgs e)
        {
            //Fill up colors ComboBox with known Colors.
            KnownColor[] marrKnownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            Color[] marrColors = new Color[marrKnownColors.Length];
            for (int i = 0; i < marrKnownColors.Length; ++i)
            {
                marrColors[i] = Color.FromKnownColor(marrKnownColors[i]);
            }

            this.mobjForeColorComboBox.DataSource = marrColors;
            this.mobjForeColorComboBox.ColorMember = "Name";
            this.mobjForeColorComboBox.DisplayMember = "Name";

            this.mobjBackColorComboBox.DataSource = marrColors.Clone();
            this.mobjBackColorComboBox.ColorMember = "Name";
            this.mobjBackColorComboBox.DisplayMember = "Name";

            //Fill up DataGridView
            for (int i = 1; i < 20; ++i)
            {
                this.mobjUserDS.Users.AddUsersRow(string.Format("User{0}", i), 
                                         string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", 
                                         "Tennessee", "37064");
            }
           

        }

        /// <summary>
        /// Handles CellFormatting event for a DataGridView.
        /// Updates text of the informed label with names of new colors.
        /// </summary>
        private void mobjDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Update text of the informed label with names of new colors.
            if ((e.RowIndex > -1 && e.RowIndex < this.mobjDataGridView.Rows.Count)
                && (e.ColumnIndex > -1 && e.ColumnIndex < mobjDataGridView.Columns.Count))
            {
                DataGridViewCell selectedCell = this.mobjDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                this.mobjInformLabel.Text = string.Format("Cell[{0},{1}] has foreground {2} and background {3} colors.",
                                                    e.RowIndex, e.ColumnIndex, 
                                                    !selectedCell.Style.ForeColor.IsEmpty ? selectedCell.Style.ForeColor.Name : this.mobjDataGridView.DefaultCellStyle.ForeColor.Name,
                                                    !selectedCell.Style.BackColor.IsEmpty ? selectedCell.Style.BackColor.Name : this.mobjDataGridView.DefaultCellStyle.BackColor.Name);
            }
        }

        /// <summary>
        /// Handles SelectedIndexChanged event for ComboBox.
        /// Changes foreground color for selected cells.
        /// </summary>
        private void mobjForeColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Changes foreground color for selected cells.
            for (int i = 0; i < this.mobjDataGridView.SelectedCells.Count; ++i)
            {
                DataGridViewCell mobjCell = this.mobjDataGridView.SelectedCells[i];
                mobjCell.Style.ForeColor = (Color)this.mobjForeColorComboBox.SelectedItem;
            }
        }

        /// <summary>
        /// Handles SelectedIndexChanged event for ComboBox.
        /// Changes background color for selected cells.
        /// </summary>
        private void mobjBackColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change background color for selected cells.
            for (int i = 0; i < this.mobjDataGridView.SelectedCells.Count; ++i)
            {
                DataGridViewCell mobjCell = this.mobjDataGridView.SelectedCells[i];
                mobjCell.Style.BackColor = (Color)this.mobjBackColorComboBox.SelectedItem;
            }
        }

        /// <summary>
        /// Handles SelectionChanged event for a DataGridView.
        /// Selects color in the ComboBox appropriate to colors of cell.
        /// </summary>
        private void mobjDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.mobjDataGridView.SelectedCells.Count > 0)
            {
                DataGridViewCell mobjFirstCell = this.mobjDataGridView.SelectedCells[0];

                // Update colors ComboBox
                // Enable color ComboBoxes only when DataGridView cell has selected and before anything cells were not selected.
                if (!this.mobjBackColorComboBox.Enabled)
                {
                    this.mobjBackColorComboBox.Enabled = true;
                }
                if (!this.mobjForeColorComboBox.Enabled)
                {
                    this.mobjForeColorComboBox.Enabled = true;
                }
                mobjForeColorComboBox.SelectedItem = !mobjFirstCell.Style.ForeColor.IsEmpty ? mobjFirstCell.Style.ForeColor : this.mobjDataGridView.DefaultCellStyle.ForeColor;
                mobjBackColorComboBox.SelectedItem = !mobjFirstCell.Style.BackColor.IsEmpty ? mobjFirstCell.Style.BackColor : this.mobjDataGridView.DefaultCellStyle.BackColor;
            }
            else
            {
                this.mobjBackColorComboBox.Enabled = false;
                this.mobjForeColorComboBox.Enabled = false;
               
            }
        }

    }
}