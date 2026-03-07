using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Google;

namespace CompanionKit.Controls.GoogleMap.Features
{
    public partial class MapControlTypePropertyPage : UserControl
    {
        public MapControlTypePropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles SelectedIndexChanged event for ComboBox
        /// </summary>
        private void mobjMapControlTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set map control type for GoogleMap control
            mobjGoogleMap.MapControlType = mobjMapControlTypeComboBox.SelectedIndex == 0 ? GoogleMapControlType.Default : (mobjMapControlTypeComboBox.SelectedIndex == 1 ? GoogleMapControlType.DropdownMenu : GoogleMapControlType.HorizontalBar);
        }

        /// <summary>
        /// Handles SelectedIndexChanged event for ComboBox
        /// </summary>
        private void mobjMapZoomControlTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set map control type for GoogleMap control
            mobjGoogleMap.MapZoomControlType = mobjMapZoomControlTypeComboBox.SelectedIndex == 0 ? GoogleMapZoomControlType.Default : (mobjMapZoomControlTypeComboBox.SelectedIndex == 1 ? GoogleMapZoomControlType.Large : GoogleMapZoomControlType.Small);
        }

    }
}