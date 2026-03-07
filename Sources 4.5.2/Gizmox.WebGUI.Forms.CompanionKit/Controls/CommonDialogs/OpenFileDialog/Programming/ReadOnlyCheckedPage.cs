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
    public partial class ReadOnlyCheckedPage : UserControl
    {
        public ReadOnlyCheckedPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Handles Load event of the example UserControl
        /// </summary>
        private void ReadOnlyCheckedPage_Load(object sender, EventArgs e)
        {
            // Set checked state for CheckBox according to OpenFileDialog ReadOnlyChecked property value
            this.mobjCheckedReaodOnlyCheckBox.Checked = this.mobjDemoOpenFileDialog.ReadOnlyChecked;
        }

        /// <summary>
        /// Handles the click event of the open file dialog box button.
        /// Opens the demonstrated OpenFileDialog dialog box.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set OpenFileDialog ReadOnlyChecked property value according to checked state of CheckBox
            this.mobjDemoOpenFileDialog.ReadOnlyChecked = this.mobjCheckedReaodOnlyCheckBox.Checked;
            // Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }
    }
}