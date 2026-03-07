using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ComboBox.Functionality
{
    public partial class ForceSelectedIndexChangedOnClickPage : UserControl
    {
        public ForceSelectedIndexChangedOnClickPage()
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
            mobjComboBox.ForceSelectedIndexChangedOnClick = mobjCheckBox.Checked;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mobjTextBox.Text += "Selected index changed:" + mobjComboBox.SelectedIndex + "\r\n";
        }
    }
}