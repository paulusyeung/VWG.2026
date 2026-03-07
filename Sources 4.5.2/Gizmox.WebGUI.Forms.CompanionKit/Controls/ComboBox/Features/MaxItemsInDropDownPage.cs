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

namespace CompanionKit.Controls.ComboBox.Features
{
    public partial class MaxItemsInDropDownPage : UserControl
    {
        public MaxItemsInDropDownPage()
        {
            InitializeComponent();
            this.mobjComboBox.SelectedIndex = 0;
            //Set text for TextBox as initially value of tested ComboBox MaxDropDownItems property.
            this.mobjTextBox.Text = this.mobjComboBox.MaxDropDownItems.ToString();
            //Set validator on input text for TextBox. The TextBox have to input only digits.
            this.mobjTextBox.Validator = new TextBoxValidation("", "", string.Concat("0-9"));
        }

        private void mobjTextBox_TextChanged(object sender, EventArgs e)
        {

            //If value of the TextBox is changed then new value is set for tested ComboBox 
            //MaxDropDownItems property after losing focus from the TextBox
            if (!string.IsNullOrEmpty(this.mobjTextBox.Text))
            {
                this.mobjComboBox.MaxDropDownItems = int.Parse(this.mobjTextBox.Text);
            }
        }
    }
}