using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ComboBox.Features
{
    public partial class CasingPage : UserControl
    {
        public CasingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objCasingComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCasingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets selected type of CharacterCasing to combo

            mobjTestComboBox.CharacterCasing = mobjCasingComboBox.SelectedIndex == 0 ? CharacterCasing.Normal : (mobjCasingComboBox.SelectedIndex == 1 ? CharacterCasing.Upper : CharacterCasing.Lower);
        }
    }
}