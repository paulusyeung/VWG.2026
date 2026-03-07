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
    public partial class FrozenColumnsAndRowsPage : UserControl
    {
        public FrozenColumnsAndRowsPage()
        {
            InitializeComponent();
        }

        private void FrozenColumnsAndRowsPage_Load(object sender, EventArgs e)
        {
            // Fill up the DataGridView.
            for (int i = 1; i < 20; ++i)
            {
                mobjUserDS.Users.AddUsersRow(string.Format("User{0}", i), string.Format("user{0}@gmail.com", i), 
                                         string.Format("8-800-236589{0}", i), "Franklin", 
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064");
            }

            // Set Frozen property to true for the First row
            this.mobjDataGridView.Rows[0].Frozen = true;
        }
    }
}