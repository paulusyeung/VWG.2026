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

namespace CompanionKit.Controls.ListBox.Appearance
{
    public partial class TextWithColorPage : UserControl
    {
        public TextWithColorPage()
        {
            InitializeComponent();

            //Set collection of customer as DataSource.

            this.mobjListBox.DataSource = Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomers();

            //Fill TextBoxes with the values of appropriate properties
            this.mobjDisplayTextBox.Text = this.mobjListBox.DisplayMember;
            this.mobjValueTextBox.Text = this.mobjListBox.ValueMember;
            this.mobjColorTextBox.Text = this.mobjListBox.ColorMember;
        }
    }
}