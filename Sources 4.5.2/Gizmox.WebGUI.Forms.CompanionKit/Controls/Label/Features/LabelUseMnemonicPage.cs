using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.LabelFolder.Features
{
    public partial class LabelUseMnemonicPage : UserControl
    {
        public LabelUseMnemonicPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chbUseMnemonic control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chbUseMnemonic_CheckedChanged(object sender, EventArgs e)
        {
            mobjNicknameLabel.UseMnemonic = chbUseMnemonic.Checked;
            mobjPassLabel.UseMnemonic = chbUseMnemonic.Checked;
            mobjEmailLabel.UseMnemonic = chbUseMnemonic.Checked;
            mobjAddressLabel.UseMnemonic = chbUseMnemonic.Checked;
        }

    }
}