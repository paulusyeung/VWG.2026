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

namespace CompanionKit.Controls.TabControl.Functionality
{
    public partial class CloseButtonPage : UserControl
    {
        public CloseButtonPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example's UserControl
        /// </summary>
        private void CloseButtonPage_Load(object sender, EventArgs e)
        {
            // Set checked state for checkbox according to value of the ShowCloseButton property
            this.mobjDemoTabControl.ShowCloseButton = true;
            this.mobjCloseButtonCheckBox.Checked = this.mobjDemoTabControl.ShowCloseButton;
        }

        /// <summary>
        /// Handles CheckedChanged event of the CheckBox.
        /// Hides and shows close button for TabControl.
        /// </summary>
        private void mobjCloseButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.mobjDemoTabControl.ShowCloseButton = this.mobjCloseButtonCheckBox.Checked;
            this.mobjDemoTabControl.Update();
        }

        /// <summary>
        /// Handles CloseClick of the TabControl.
        /// Closes selected tab.
        /// </summary>
        private void mobjDemoTabControl_CloseClick(object sender, EventArgs e)
        {
            if (this.mobjDemoTabControl.SelectedItem != null)
            {
                this.mobjDemoTabControl.TabPages.Remove(this.mobjDemoTabControl.SelectedItem);
            }
        }
    }
}