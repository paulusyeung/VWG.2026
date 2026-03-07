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

namespace CompanionKit.Controls.RadioButton.Functionality
{
    public partial class CheckedPage : UserControl
    {
        public CheckedPage()
        {
            InitializeComponent();
            //Update label text with initial state of demonstrated RadioButton
            UpdateLabelText();
        }

        /// <summary>
        /// Updates label text, that indicates state of demonstrated RadioButton.
        /// </summary>
        private void UpdateLabelText()
        {
            this.mobjInfoLabel.Text = String.Format("RadioButton1 is {0}!", (this.mobjRadioButton1.Checked ? "checked" : "unchecked"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Updates label text, that indicates state of demonstrated CheckBox.
            UpdateLabelText();
        }
    }
}