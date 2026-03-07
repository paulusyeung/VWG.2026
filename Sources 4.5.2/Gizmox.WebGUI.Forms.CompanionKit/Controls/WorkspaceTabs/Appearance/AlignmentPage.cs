using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.WorkspaceTabs.Appearance
{
    public partial class AlignmentPage : UserControl
    {
        public AlignmentPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objTopRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTopRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mobjWorkspaceTabs.Alignment = mobjTopRadioButton.Checked ? TabAlignment.Top : TabAlignment.Bottom;
        }


    }
}