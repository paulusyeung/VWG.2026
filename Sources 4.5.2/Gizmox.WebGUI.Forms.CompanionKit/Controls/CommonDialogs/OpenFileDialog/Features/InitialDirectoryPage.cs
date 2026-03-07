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
    public partial class InitialDirectoryPage : UserControl
    {
        public InitialDirectoryPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the FolderBrowserDialog dialog box to select initial directory.
        /// </summary>
        private void mobjInitialDirectoryButton_Click(object sender, EventArgs e)
        {
            // Opens the folder browser dialog with initial selected path
            this.mobjInitialDirectoryFolderBrowserDialog.SelectedPath = this.mobjInitialDirectoryTextBox.Text;
            
            this.mobjInitialDirectoryFolderBrowserDialog.ShowDialog();

        }

        /// <summary>
        /// Handles the Closed event of the FolderBrowserDialog dialog box.
        /// </summary>
        private void mobjInitialDirectoryFolderBrowserDialog_Closed(object sender, EventArgs e)
        {
            // On success closing of the Folder Browser Dialog, 
            // Change selected path in the TextBox.
            if (this.mobjInitialDirectoryFolderBrowserDialog.DialogResult == DialogResult.OK)
            {
                this.mobjInitialDirectoryTextBox.Text = this.mobjInitialDirectoryFolderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
             // Set initial directory for Open File Dialog
             this.mobjDemoOpenFileDialog.InitialDirectory = this.mobjInitialDirectoryTextBox.Text;
         
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }

    }
}