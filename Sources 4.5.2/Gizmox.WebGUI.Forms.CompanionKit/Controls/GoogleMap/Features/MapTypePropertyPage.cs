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
    public partial class MapTypePropertyPage : UserControl
    {
        public MapTypePropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void MapTypePropertyPage_Load(object sender, EventArgs e)
        {
            // Fill ComboBox items collection with GoogleMapType enum items
            mobjMapTypeComboBox.DataSource = Enum.GetValues(typeof(GoogleMapType));
        }

        /// <summary>
        /// Handles SelectedIndexChanged for ComboBox
        /// </summary>
        private void mobjMapTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set map type for GoogleMap
            mobjGoogleMap.MapType = (GoogleMapType)mobjMapTypeComboBox.SelectedItem;
        }
    }
}