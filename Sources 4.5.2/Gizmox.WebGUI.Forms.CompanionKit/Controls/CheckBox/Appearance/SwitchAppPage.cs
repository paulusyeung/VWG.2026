using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.CheckBox.Appearance
{
    public partial class SwitchAppPage : UserControl
    {
        public SwitchAppPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Change Label Text in accordance to CheckedState of CheckBox
            mobjCheckedLabel.Text = mobjCheckBox.Checked ? "Checked" : "Unchecked";
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjNormalRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNormalRB_CheckedChanged(object sender, EventArgs e)
        {
            //Switch CheckBox appearance
            if (mobjNormalRB.Checked)
                mobjCheckBox.Appearance = Gizmox.WebGUI.Forms.Appearance.Normal;
            else
               mobjCheckBox.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
        }

    }
}