using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.FolderBrowserDialog.Features
{
    public partial class RootFolderButtonPage : UserControl
    {
        public RootFolderButtonPage()
        {
            InitializeComponent();
            // Fill ComboBox with Environment.SpecialFolder enumerator items
            mobjRootFolderComboBox.DataSource = Enum.GetValues(typeof(Environment.SpecialFolder));
        }

        /// <summary>
        /// Handles Click event for Button control
        /// </summary>
        private void mobjBrowseButton_Click(object sender, EventArgs e)
        {
            // Select root folder for FolderBrowserDialog from ComboBox selected item
            mobjFolderBrowserDialog.RootFolder = (Environment.SpecialFolder)mobjRootFolderComboBox.SelectedItem;
            // Call dialog with an event handler as a parameter
            mobjFolderBrowserDialog.ShowDialog(mobjFolderBrowserDialog_Closed);
        }

        /// <summary>
        /// These event handler calls when FolderBrowserDialog windows closed
        /// </summary>
        private void mobjFolderBrowserDialog_Closed(object sender, EventArgs e)
        {
            // Get Gizmox.WebGUI.Forms.FolderBrowserDialog object
            Gizmox.WebGUI.Forms.FolderBrowserDialog mobjSenderDialog = (Gizmox.WebGUI.Forms.FolderBrowserDialog)sender;

            if (mobjSenderDialog != null)
            {
                // Set SelectedPath value of the FolderBrowserDialog as a text for label
                mobjSelectedDirectoryLabel.Text = string.Format("Selected path: \"{0}\"", mobjSenderDialog.SelectedPath);
            }
        }
    }
}