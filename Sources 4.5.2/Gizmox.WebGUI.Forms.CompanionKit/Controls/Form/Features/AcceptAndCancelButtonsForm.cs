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

namespace CompanionKit.Controls.Form.Features
{
    public partial class AcceptAndCancelButtonsForm : Gizmox.WebGUI.Forms.Form
    {
        public AcceptAndCancelButtonsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event for Save button.
        /// Sets OK dialog result for form and closes it.
        /// </summary>
        private void mobjSaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles Click event for Cancel button.
        /// Sets Cancel dialog result for form and closes it.
        /// </summary>
        private void mobjCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Gets information about saving user.
        /// </summary>
        public string GetSavingUserMessage()
        {
            return string.Format("Saving {0} {1} user with E-mail: {2} and Phone: {3}!",
                mobjUserFirstNameTextBox.Text, mobjUserLastNameTextBox.Text, mobjEmailTextBox.Text, mobjPhoneTextBox.Text);
        }
    }
}