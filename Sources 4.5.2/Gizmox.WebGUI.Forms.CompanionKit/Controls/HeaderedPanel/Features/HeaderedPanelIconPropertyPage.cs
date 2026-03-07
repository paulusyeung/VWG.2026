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
    public partial class HeaderedPanelIconPropertyPage : UserControl
    {
        public HeaderedPanelIconPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles CheckedChanged event for RadioButton controls
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If RadioButton is checked
            if (((Gizmox.WebGUI.Forms.RadioButton)sender).Checked)
            {
                // Set icon for HeaderedPanel using RadioButton.Image property
                mobjHeaderedPanel.Icon = ((Gizmox.WebGUI.Forms.RadioButton)sender).Image;
            }
        }
    }
}