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
    public partial class ComboBoxForm : global::Gizmox.WebGUI.Forms.Form
    {
        public ComboBoxForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Show message that indicates whether button will be clicked
            MessageBox.Show("Message of ComboBox Form!!!");
        }
    }
}