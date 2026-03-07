using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.RadioButton.Appearance
{
    public partial class ButtonAppearancePage : UserControl
    {
        public ButtonAppearancePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Applies selected ButtonAppearance type
            Gizmox.WebGUI.Forms.Appearance mobjAppearanceType = mobjComboBox.SelectedIndex == 0 ? Gizmox.WebGUI.Forms.Appearance.Normal : Gizmox.WebGUI.Forms.Appearance.Button;
            mobjRadioButton1.Appearance = mobjRadioButton2.Appearance = mobjRadioButton3.Appearance = mobjAppearanceType;
        }
    }
}