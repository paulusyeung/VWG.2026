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

namespace CompanionKit.Controls.LinkLabel.Functionality
{
    public partial class ClientModePage : UserControl
    {
        public ClientModePage()
        {
            InitializeComponent();

            // Update Label text
            this.mobjStatusLabel.Text = string.Format("Current client-mode status: {0}", this.mobjLinkLabel.ClientMode);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mobjCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            // Set ClientMode property value for LinkLabel
            this.mobjLinkLabel.ClientMode = this.mobjCheckBox.Checked;
            // Update Label text
            this.mobjStatusLabel.Text = string.Format("Current client-mode status: {0}", this.mobjLinkLabel.ClientMode);
        }
    }
}