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
    public partial class ValidatorPage : UserControl
    {
        public ValidatorPage()
        {
            InitializeComponent();
            //Set validator for demo TexBoxt that it will allow to enter only number, '.' or '_' 
            this.mobjTextBox.Validator = new TextBoxValidation("", "", string.Concat("0-9\\.\\-"));
        }
    }
}