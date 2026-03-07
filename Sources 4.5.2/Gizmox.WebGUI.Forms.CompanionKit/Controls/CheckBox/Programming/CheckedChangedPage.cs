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

namespace CompanionKit.Controls.CheckBox.Programming
{
    public partial class CheckedChangedPage : UserControl
    {
        public CheckedChangedPage()
        {
            InitializeComponent();

            //Update label text with initial checked state of demonstrated CheckBox
            UpdateLabelText();
        }

        /// <summary>
        /// Updates label text, that indicates checked state of demonstrated CheckBox.
        /// </summary>
        private void UpdateLabelText()
        {
            this.mobjCheckedLabel.Text = String.Format("CheckBox is {0}!", (this.mobjCheckBox.Checked ? "checked" : "unchecked"));
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Updates label text, that indicates checked state of demonstrated CheckBox.
            UpdateLabelText();
        }

    }
}