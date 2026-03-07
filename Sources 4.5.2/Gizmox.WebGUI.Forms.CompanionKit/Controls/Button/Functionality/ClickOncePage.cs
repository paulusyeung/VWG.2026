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

namespace CompanionKit.Controls.Button.Functionality
{
    public partial class ClickOncePage : UserControl
    {
        public ClickOncePage()
        {
            InitializeComponent();
            this.mobjLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.mobjAllowCheckOnceCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            
            // Set initial check state that indicates whethet ClickOnce property is enabled
            this.mobjAllowCheckOnceCheckBox.Checked = this.mobjButton.ClickOnce;
        }

        /// <summary>
        /// Handles the Click event of the mobjButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            // Show messge to indicate that clicl event is fired
            MessageBox.Show("Button has been clicked!");
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAllowCheckOnceCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAllowCheckOnceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Switch ClickOnce property for Button with CheckBox
            this.mobjButton.ClickOnce = this.mobjAllowCheckOnceCheckBox.Checked;
            if (!this.mobjButton.ClickOnce && !this.mobjButton.Enabled)
            {
                this.mobjButton.Enabled = true;
            }
        }
    }
}