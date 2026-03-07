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
    public partial class MapLocationPropertyPage : UserControl
    {
        public MapLocationPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event for Button
        /// </summary>
        private void mobjSetCoordinatesButton_Click(object sender, EventArgs e)
        {
            // Set local variable for validation
            bool isValid = true;
            // Set local variables for coordinates
            double longitude = (double) this.mobjLongitudeNUD.Value;
            double latitude = (double) this.mobjLatitudeNUD.Value ;

            // If all values entered are valid
            if (isValid)
            {
                // Set map location for GoogleMap control
                this.mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(latitude, longitude );
            }            
        }
    }
}