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
    public partial class ShowReadOnlyPage : UserControl
    {
        public ShowReadOnlyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example UserControl
        /// </summary>
        private void ShowReadOnlyPage_Load(object sender, EventArgs e)
        {
            // Set checked state for CheckBox according to OpenFileDialog ShowReadOnly property value
            this.mobjEnableShowReadOnlyCheckBox.Checked = this.mobjDemoOpenFileDialog.ShowReadOnly;
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set OpenFileDialog ShowReadOnly property value according to checked state of CheckBox
            this.mobjDemoOpenFileDialog.ShowReadOnly = this.mobjEnableShowReadOnlyCheckBox.Checked;
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog(); 
        }
    }
}