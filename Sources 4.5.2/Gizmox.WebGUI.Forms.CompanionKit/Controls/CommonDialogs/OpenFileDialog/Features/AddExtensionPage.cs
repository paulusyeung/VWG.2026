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

namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features
{
    public partial class AddExtensionPage : UserControl
    {
        public AddExtensionPage()
        {
            InitializeComponent();
        }

        private void AddExtensionPage_Load(object sender, EventArgs e)
        {
            //Set checked state for CheckBox according to OpenFileDialog AddExtension property value
            this.mobjAllowAddExtensionCheckBox.Checked = this.mobjDemoOpenFileDialog.AddExtension;
        }

        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            //Set OpenFileDialog AddExtension property value according to checked state of CheckBox
            this.mobjDemoOpenFileDialog.AddExtension = this.mobjAllowAddExtensionCheckBox.Checked;
            //Set images file Filter for Open File Dialog
            this.mobjDemoOpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp";
            //Set index of default images file Filter for Open File Dialog
            this.mobjDemoOpenFileDialog.FilterIndex = 1;
            //Set default file extension Open File Dialog
            this.mobjDemoOpenFileDialog.DefaultExt = "*.jpg";
            //Set initial directory for Open File Dialog
            this.mobjDemoOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }
    }
}