using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MaskedTextBox.Features
{
    public partial class PromptCharacterPage : UserControl
    {
        public PromptCharacterPage()
        {
            InitializeComponent();

			this.mobjPromptCharsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.mobjPromptCharsComboBox.Items.AddRange(new char[] {'*','+','_','~','@'});
			this.mobjPromptCharsComboBox.SelectedIndex = 3;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjPromptCharsComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPromptCharsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mobjMaskedTextBox.PromptChar = (char)this.mobjPromptCharsComboBox.SelectedItem;
        }
    }
}