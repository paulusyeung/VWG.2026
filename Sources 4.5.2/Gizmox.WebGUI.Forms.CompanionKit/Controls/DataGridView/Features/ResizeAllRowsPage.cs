using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DataGridView.Features
{
    public partial class ResizeAllRowsPage : UserControl
    {
        public ResizeAllRowsPage()
        {
            InitializeComponent();

            //Fill DGV with 3 rows
            mobjDGV.Rows.Add("value 1", "item 1", "row 1");
            mobjDGV.Rows.Add("value 2", "item 2", "row 2");
            mobjDGV.Rows.Add("value 3", "item 3", "row 3");
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjStandardTabCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjStandardTabCB_CheckedChanged(object sender, EventArgs e)
        {
            //Set the value of StandardTab property
            mobjDGV.StandardTab = mobjStandardTabCB.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjResizeAllCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjResizeAllCB_CheckedChanged(object sender, EventArgs e)
        {
            //Set the value of EnforceEqualRowSize property
            mobjDGV.EnforceEqualRowSize = mobjResizeAllCB.Checked;
        }
    }
}