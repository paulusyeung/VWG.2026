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
    public partial class TitlePage : UserControl
    {
        public TitlePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of example UserControl.
        /// Sets initial title of the open file dialog.
        /// </summary>
        private void TitlePage_Load(object sender, EventArgs e)
        {
            // Set initial title of the open file dialog.
            this.mobjTitleFileDialogTextBox.Text = this.mobjDemoOpenFileDialog.Title;
        }

        /// <summary>
        /// Handles Click event of the Button.
        /// Sets specified title for open file dialog and open it.
        /// </summary>
        private void mobjOpenFileDialogButton_Click(object sender, EventArgs e)
        {
            // Set specified title for open file dialog and open it.
            this.mobjDemoOpenFileDialog.Title = this.mobjTitleFileDialogTextBox.Text;
            this.mobjDemoOpenFileDialog.ShowDialog();
        }
    }
}