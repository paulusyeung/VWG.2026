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

namespace CompanionKit.Controls.CheckBox.Functionality
{
    public partial class CheckStatePage : UserControl
    {
        
        public CheckStatePage()
        {
            InitializeComponent();

            //Update label text with initial state of demonstrated CheckBox
            UpdateLabelText();
        }

        /// <summary>
        /// Handles the Click event of the mobjCheckStateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckStateButton_Click(object sender, EventArgs e)
        {
            UpdateLabelText();
        }

        /// <summary>
        /// Updates label text, that indicates state of demonstrated CheckBox.
        /// </summary>
        private void UpdateLabelText()
        {
            this.mobjStateLabel.Text = String.Format("CheckBox state is {0}!", mobjCheckBox.CheckState);
        }
    }
}