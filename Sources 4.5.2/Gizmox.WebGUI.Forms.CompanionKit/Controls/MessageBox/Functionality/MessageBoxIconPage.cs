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
    public partial class MessageBoxIconPage : UserControl
    {
        public MessageBoxIconPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the MessageBoxIconPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MessageBoxIconPage_Load(object sender, EventArgs e)
        {
            // Bind values of the MessageBoxIcon enumerator to
            // ComboBox control
            mobjMessageBoxIconsCB.DataSource = Enum.GetValues(typeof(MessageBoxIcon));
        }

        /// <summary>
        /// Handles the Click event of the mobjShowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowButton_Click(object sender, EventArgs e)
        {
            // Show MessageBox with the selected icon, handler and modal mask set
            MessageBox.Show("Message text", "Message", MessageBoxButtons.OKCancel, (MessageBoxIcon)mobjMessageBoxIconsCB.SelectedValue, MessageBoxHandler, mobjShowModalMask.Checked);
        }

        /// <summary>
        /// These event handler calls when MessageBox windows closed
        /// </summary>
        private void MessageBoxHandler(object sender, EventArgs e)
        {
            // Get Gizmox.WebGUI.Forms.Form object that called MessageBox
            Gizmox.WebGUI.Forms.Form senderForm = (Gizmox.WebGUI.Forms.Form)sender;

            if (senderForm != null)
            {
                // Set DialogResult value of the Form as a text for label
                mobjResultLbl.Text = string.Format("Dialog result value: \"{0}\"", senderForm.DialogResult);
            }
        }
    }
}