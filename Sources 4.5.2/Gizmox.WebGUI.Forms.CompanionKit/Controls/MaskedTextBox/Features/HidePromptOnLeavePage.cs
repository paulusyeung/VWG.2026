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
    public partial class HidePromptOnLeavePage : UserControl
    {
        public HidePromptOnLeavePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the hidePromptOnLeaveCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void hidePromptOnLeaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Set changed value:
            demoMaskedTextBox.HidePromptOnLeave = hidePromptOnLeaveCheckBox.Checked;
            demoMaskedTextBox2.HidePromptOnLeave = hidePromptOnLeaveCheckBox.Checked;
        }
    }
}