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
    public partial class HeaderedPanelHeaderPropertyPage : UserControl
    {
        public HeaderedPanelHeaderPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void HeaderedPanelHeaderPropertyPage_Load(object sender, EventArgs e)
        {
            // Set Label as header control for HeaderedPanel
            mobjHeaderedPanel.Header = new Label("Header content");
        }

        /// <summary>
        /// Handles DoubleClick event for Control
        /// </summary>
        private void Control_DoubleClick(object sender, EventArgs e)
        {
            // Set control as header for HeaderedPanel
            mobjHeaderedPanel.Header = (Control)sender;
        }

        /// <summary>
        /// Handles Click event for Button control
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            // Clear all form controls
            this.Controls.Clear();
            // Initialize all form controls
            this.InitializeComponent();
            // Set Label as header control for HeaderedPanel
            mobjHeaderedPanel.Header = new Label("Header content");
        }
    }
}