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
    public partial class CheckStateChangedPage : UserControl
    {
        public CheckStateChangedPage()
        {
            InitializeComponent();

            //Update label text with initial state of demonstrated CheckBox
            UpdateLabelText();
        }


        /// <summary>
        /// Updates the label text with current state of demonstrated CheckBox.
        /// </summary>
        private void UpdateLabelText()
        {
            this.mobjStateLabel.Text = String.Format("CheckBox state is {0}!", mobjCheckBox.CheckState);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            //Update Label text
            UpdateLabelText();
        }

    }
}