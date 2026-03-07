using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MaskedTextBox.Features
{
    public partial class AllowAndResetPromptPage : UserControl
    {
        public AllowAndResetPromptPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjResetCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjResetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjMaskedTextBox.ResetOnPrompt = mobjResetCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAllowCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAllowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjMaskedTextBox.AllowPromptAsInput = mobjAllowCheckBox.Checked;
        }
    }
}