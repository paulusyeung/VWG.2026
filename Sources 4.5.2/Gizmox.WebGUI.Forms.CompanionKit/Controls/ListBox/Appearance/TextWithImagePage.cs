#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.CompanionKit.Controls.Util;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.Controls.ListBox.Appearance
{
    public partial class TextWithImagePage : UserControl
    {
        public TextWithImagePage()
        {
            InitializeComponent();

            //Get ResourceHandle for photo of customer.
            global::Gizmox.WebGUI.Common.Resources.ResourceHandle photoResource = new ImageResourceHandle("32x32.Photo.png");
            //Set objects collection as DataSource for ComboBox.
            this.mobjListBox.DataSource = Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomersWithImage(photoResource);

            //Fill TextBoxes with the values of appropriate properties
            this.mobjDisplayTextBox.Text = this.mobjListBox.DisplayMember;
            this.mobjValueTextBox.Text = this.mobjListBox.ValueMember;
            this.mobjImageTextBox.Text = this.mobjListBox.ImageMember;

        }
    }
}
