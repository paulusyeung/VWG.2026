using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MessageBoxControl.ApplicationScenario
{
    public partial class MessageBoxBuilderPage : UserControl
    {
        public MessageBoxBuilderPage()
        {
            InitializeComponent();

            // Fill ComboBox.Items collection with MessageBoxButtons enumerator values
            this.mobjComboButtons.Items.AddRange(Enum.GetValues(typeof(MessageBoxButtons)));
            // Fill ComboBox.Items collection with MessageBoxIcon enumerator values
            this.mobjComboIcon.Items.AddRange(Enum.GetValues(typeof(MessageBoxIcon)));
            // Set SelectedIndex property values for ComboBox controls
            this.mobjComboButtons.SelectedIndex = 0;
            this.mobjComboIcon.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonShow_Click(object sender, System.EventArgs e)
        {
            // Show MessageBox window with custom caption, message text, buttons, icon and handler
            MessageBox.Show(this.mobjTextMessage.Text, this.mobjTextTitle.Text, (MessageBoxButtons)this.mobjComboButtons.SelectedItem, (MessageBoxIcon)this.mobjComboIcon.SelectedItem, objMessageBox_Closed);
        }

        /// <summary>
        /// These event handler calls when MessageBox windows closed
        /// </summary>
        private void objMessageBox_Closed(object sender, EventArgs e)
        {
            // Show the button pressed using another MessageBox window
            MessageBox.Show("You pressed button: " + ((MessageBoxWindow)sender).DialogResult.ToString(), "MessageBox Result");
        }
    }
}