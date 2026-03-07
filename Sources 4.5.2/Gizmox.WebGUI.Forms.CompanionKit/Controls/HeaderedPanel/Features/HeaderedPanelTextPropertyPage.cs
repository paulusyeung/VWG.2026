using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.HeaderedPanel.Features
{
    public partial class HeaderedPanelTextPropertyPage : UserControl
    {
        public HeaderedPanelTextPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event for Button control
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            // Set header text for HeaderedPanel control
            mobjHeaderedPanel.Text = mobjTextBox.Text;
        }
    }
}