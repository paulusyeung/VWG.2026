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
    public partial class ValidateNamesPage : UserControl
    {
        public ValidateNamesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example UserControl
        /// </summary>
        private void ValidateNamesPage_Load(object sender, EventArgs e)
        {
            // Set checked state for CheckBox according to OpenFileDialog ValidateNames property value
            this.mobjEnableValidationNamesCheckBox.Checked = this.mobjDemoOpenFileDialog.ValidateNames;
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set OpenFileDialog ValidateNames property value according to checked state of CheckBox
            this.mobjDemoOpenFileDialog.ValidateNames = this.mobjEnableValidationNamesCheckBox.Checked;
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog(); 
        }
    }
}