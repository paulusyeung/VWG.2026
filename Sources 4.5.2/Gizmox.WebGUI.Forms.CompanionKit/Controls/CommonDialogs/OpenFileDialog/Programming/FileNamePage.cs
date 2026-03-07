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
    public partial class FileNamePage : UserControl
    {
        public FileNamePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Closed event of the demonstrated FileDialog.
        /// </summary>
        private void mobjDemoOpenFileDialog_Closed(object sender, EventArgs e)
        {
            // Update text of the TextBox with the selected file name.
            if (this.mobjDemoOpenFileDialog.DialogResult == DialogResult.OK)
            {
                this.mobjSelectedFileTextBox.Text = this.mobjDemoOpenFileDialog.FileName;
                this.mobjOrigFileNameTextBox.Text = ((Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle)(this.mobjDemoOpenFileDialog).File).OriginalFileName;
            }
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            this.mobjDemoOpenFileDialog.ShowDialog();
        }
    }
}
