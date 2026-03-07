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
    public partial class ValidationPage : UserControl
    {
        public ValidationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles CellValidating event of the DataGRidView.
        /// Validates whether enter values isn't null or empty .
        /// and validates whether entered values in Phone or Email columns are matches with correct format.
        /// </summary>
        private void mobjDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string formatedValue = e.FormattedValue as string;
            if (string.IsNullOrEmpty(formatedValue))
            {
                MessageBox.Show("Please enter value!");
                e.Cancel = true;
            }
            else if (this.mobjDataGridView.Columns[e.ColumnIndex].DataPropertyName.Equals("UserPhone")
                && !System.Text.RegularExpressions.Regex.IsMatch(formatedValue, @"^\d{1}-\d{3}-\d{7}$"))
            {
                MessageBox.Show("Please enter phone in format: X-XXX-XXXXXXX!");
                e.Cancel = true;
            }
            else if (this.mobjDataGridView.Columns[e.ColumnIndex].DataPropertyName.Equals("UserEmail")
                && !System.Text.RegularExpressions.Regex.IsMatch(formatedValue, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                MessageBox.Show("Please enter correct user e-mail!");
                e.Cancel = true;
            }
            

        }

        private void ValidationPage_Load(object sender, EventArgs e)
        {
            // Fill up the DataGridView.
            for (int i = 1; i < 20; ++i)
            {
                mobjUserDS.Users.AddUsersRow(string.Format("User{0}", i), string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064");
            }
        }
    }
}