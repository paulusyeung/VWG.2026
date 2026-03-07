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
    public partial class FilesPage : UserControl
    {
        public FilesPage()
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
            this.mobjSelectedFilesListView.Items.Clear();

            foreach (string fileKey in this.mobjDemoOpenFileDialog.Files)
            {
                FileHandle file = this.mobjDemoOpenFileDialog.Files[fileKey];
                string origFileName = ((Gizmox.WebGUI.Common.Resources.HttpPostedFileHandle)file).OriginalFileName;
                ListViewItem fileListViewItem = new ListViewItem(new string[] { origFileName, file.ContentLength.ToString() });

                this.mobjSelectedFilesListView.Items.Add(fileListViewItem);
            }
        }
    }
}
