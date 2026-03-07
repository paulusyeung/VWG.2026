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
    public partial class DefaultExtPage : UserControl
    {
        public DefaultExtPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set images file Filter for Open File Dialog
            this.mobjDemoOpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp";
            // Set index of default images file Filter for Open File Dialog
            this.mobjDemoOpenFileDialog.FilterIndex = 1;
            // Set default file extension Open File Dialog
            this.mobjDemoOpenFileDialog.DefaultExt = this.mobjDefaultExtTextBox.Text;
            // Set initial directory for Open File Dialog
            this.mobjDemoOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }

        /// <summary>
        /// Handles Load event of the example UserControl
        /// </summary>
        private void DefaultExtPage_Load(object sender, EventArgs e)
        {
            // Set initial default extension for the TextBox as the OpenFileDialog DefaultExt property value.
            this.mobjDefaultExtTextBox.Text= this.mobjDemoOpenFileDialog.DefaultExt;
        }

    }
}