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

namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    public partial class FilePage : UserControl
    {
        public FilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            this.mobjDemoOpenFileDialog.ShowDialog();
        }

        /// <summary>
        /// Handles FileOK event of the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjDemoOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            // Change text of TextBoxes to the file name and the file size.
            this.mobjOrigFileNameTextBox.Text = ((Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle)(this.mobjDemoOpenFileDialog).File).OriginalFileName;
            this.mobjFileNameTextBox.Text = this.mobjDemoOpenFileDialog.File.FileName;
            this.mobjFileSizeTextBox.Text = this.mobjDemoOpenFileDialog.File.ContentLength.ToString();
        }
    }
}
