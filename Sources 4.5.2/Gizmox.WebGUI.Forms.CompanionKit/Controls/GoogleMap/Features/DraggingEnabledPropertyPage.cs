using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.GoogleMap.Features
{
    public partial class DraggingEnabledPropertyPage : UserControl
    {
        public DraggingEnabledPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles CheckedChanged event for CheckBox control
        /// </summary>
        private void mobjAllowDraggingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Set enable dragging for GoogleMap control
            mobjGoogleMap.MapDraggingEnabled = mobjAllowDraggingCheckBox.Checked;
        }
    }
}