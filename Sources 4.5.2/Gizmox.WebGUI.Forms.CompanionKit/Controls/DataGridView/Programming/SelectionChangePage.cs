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
    public partial class SelectionChangePage : UserControl
    {
        public SelectionChangePage()
        {
            InitializeComponent();
        }
        private void SelectionChangePage_Load(object sender, EventArgs e)
        {
            //Fill DataGridView
            for (int i = 1; i < 10; ++i)
            {
                this.mobjUserDS.Users.AddUsersRow(string.Format("User{0}", i), 
                                         string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", 
                                         "Tennessee", "37064");
            }
        }

        /// <summary>
        /// Handles SelectionChanged event for the DataGridView.
        /// Builds the string with the indexes of the selected cells 
        /// and displays it in the informed label.
        /// </summary>
        private void mobjDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            StringBuilder mobjStringBuilder = new StringBuilder("You are select the following cells: ");
            for (int i = 0; i < this.mobjDataGridView.SelectedCells.Count; ++i)
            {
                DataGridViewCell mobjCell = this.mobjDataGridView.SelectedCells[i];
                if (i == 0)
                {
                    mobjStringBuilder.Append(string.Format("[{0},{1}]", mobjCell.RowIndex, mobjCell.ColumnIndex));
                }
                else
                {
                    mobjStringBuilder.Append(string.Format(", [{0},{1}]", mobjCell.RowIndex, mobjCell.ColumnIndex));
                }
            }
            mobjStringBuilder.Append(".");
            this.mobjInformedLabel.Text = mobjStringBuilder.ToString();
        }

    }
}