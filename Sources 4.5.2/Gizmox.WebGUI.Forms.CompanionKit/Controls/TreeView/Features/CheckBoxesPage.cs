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

namespace CompanionKit.Controls.TreeView.Features
{
    public partial class CheckBoxesPage : UserControl
    {
        public CheckBoxesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjTreeView.CheckBoxes = mobjCheckBox.Checked ? true : false;
        }
    }
}