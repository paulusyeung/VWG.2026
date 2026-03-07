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
    public partial class MaxFileSizePage : UserControl
    {
        /// <summary>
        /// Represents minimum value for the MaxFileSize property of the OpenFileDialog.
        /// </summary>
        private int MINIMUM_MAX_FILE_SIZE = 40;
        
        public MaxFileSizePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example UserControl
        /// </summary>
        private void MaxFileSizePage_Load(object sender, EventArgs e)
        {
            // Set validator for demo TexBoxt that it will allow to enter only number 
            this.mobjMaximumFileSizeTextBox.Validator = new TextBoxValidation("", "", string.Concat("0-9"));

            // Set initial MaxFileSize into TextBox.
            this.mobjMaximumFileSizeTextBox.Text = this.mobjDemoOpenFileDialog.MaxFileSize.ToString();
        }

        /// <summary>
        /// Handles TextChanged event for the TextBox.
        /// Validates whether value of the TextBox Text property is empty, 
        /// null or less than minimum MinFileSize. If it is, maximum file 
        /// size is set to minimum file size value.
        /// </summary>
        private void mobjMaximumFileSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.mobjMaximumFileSizeTextBox.Text))
            {
                this.mobjMaximumFileSizeTextBox.Text = MINIMUM_MAX_FILE_SIZE.ToString();
            }
            else
            {
                int mintMaxFileSize = int.Parse(this.mobjMaximumFileSizeTextBox.Text);
                if (mintMaxFileSize < MINIMUM_MAX_FILE_SIZE)
                {
                    this.mobjMaximumFileSizeTextBox.Text = MINIMUM_MAX_FILE_SIZE.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set the Maximum file size allowed in kilobytes.
            this.mobjDemoOpenFileDialog.MaxFileSize = int.Parse(this.mobjMaximumFileSizeTextBox.Text);
            
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }
    }
}