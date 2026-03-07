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
    public partial class PasswordCharPage : UserControl
    {
        public PasswordCharPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjCharTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCharTextBox_TextChanged(object sender, EventArgs e)
        {
            //If Text property is not empty or null, then -- continue
            if (!string.IsNullOrEmpty(mobjCharTextBox.Text))
            {
                //If string contains more than one char, take first one
                if (mobjCharTextBox.Text.ToCharArray().Length > 1)
                {
                    mobjCharTextBox.Text = mobjCharTextBox.Text.ToCharArray()[0].ToString();
                }
                //Applies parsed string to PasswordChar property
                mobjTextBox.PasswordChar = char.Parse(mobjCharTextBox.Text);
            }
        }
    }
}