#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming
{
    public partial class FileNamesPage : UserControl
    {
        public FileNamesPage()
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
            // Clear ListBox items from previously selected files and 
            // set a new  collection of selected files
            this.mobjSelectedFileNamesListView.Items.Clear();
            foreach (string tempFileName in this.mobjDemoOpenFileDialog.FileNames)
            {
                this.mobjSelectedFileNamesListView.Items.Add(new ListViewItem(new string[] { tempFileName, GetOriginalFileName(tempFileName) }));
            }
        }

        private string GetOriginalFileName(string tempFileName)
        {
            if(!string.IsNullOrEmpty(tempFileName))
            {
                foreach (string fileKey in this.mobjDemoOpenFileDialog.Files)
                {
                    FileHandle file = this.mobjDemoOpenFileDialog.Files[fileKey];
                    if (tempFileName.Equals(file.FileName))
                    {
                        return ((Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle)file).OriginalFileName;
                    }
                }
            }
            return string.Empty;
        }

    }
}
