using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MessageBoxControl.Functionality
{
    public partial class MessageBoxTextCaptionPage : UserControl
    {
        public MessageBoxTextCaptionPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjShowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowButton_Click(object sender, EventArgs e)
        {
            // Show MessageBox with custom caption, text, handler and modal mask set
            MessageBox.Show(mobjText.Text, mobjCaptionText.Text, MessageBoxButtons.OKCancel, MessageBoxHandler, mobjShowModalMask.Checked);
        }

        /// <summary>
        /// These event handler calls when MessageBox windows closed
        /// </summary>
        private void MessageBoxHandler(object sender, EventArgs e)
        {
            // Get Gizmox.WebGUI.Forms.Form object that called MessageBox
            Gizmox.WebGUI.Forms.Form senderForm = (Gizmox.WebGUI.Forms.Form) sender;

            if (senderForm != null)
            {
                // Set DialogResult value of the Form as a text for label
                mobjResultLbl.Text = string.Format("Dialog result value: \"{0}\"", senderForm.DialogResult);
            }
        }

    }
}