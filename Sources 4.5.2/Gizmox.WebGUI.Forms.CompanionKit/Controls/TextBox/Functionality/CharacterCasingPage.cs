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

namespace CompanionKit.Controls.TextBox.Functionality
{
    public partial class CharacterCasingPage : UserControl
    {
        public CharacterCasingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aplies CharacterCasing according to selected item in ComboBox
            switch (mobjComboBox.SelectedIndex)
            {
                //Normal
                case 0:
                    mobjTextBox.CharacterCasing = CharacterCasing.Normal;
                    break;
                //Upper
                case 1:
                    mobjTextBox.CharacterCasing = CharacterCasing.Upper;
                    break;
                //Lower
                case 2:
                    mobjTextBox.CharacterCasing = CharacterCasing.Lower;
                    break;
            }
        }
    }
}