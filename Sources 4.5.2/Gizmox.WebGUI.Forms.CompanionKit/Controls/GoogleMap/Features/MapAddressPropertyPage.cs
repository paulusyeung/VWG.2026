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
    public partial class MapAddressPropertyPage : UserControl
    {
        public MapAddressPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click for Button control
        /// </summary>
        private void mobjSetAddressButton_Click(object sender, EventArgs e)
        {
            // Set map address for GoogleMap control
            this.mobjGoogleMap.MapAddress = mobjAddressTextBox.Text;
        }
    }
}