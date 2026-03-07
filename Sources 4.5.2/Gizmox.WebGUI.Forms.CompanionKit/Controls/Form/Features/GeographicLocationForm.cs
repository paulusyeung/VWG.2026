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

namespace CompanionKit.Controls.Form.Features
{
    public partial class GeographicLocationForm : Gizmox.WebGUI.Forms.Form
    {
        public GeographicLocationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objRepeatCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRepeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.GeographicLocation.RepeatCheck = mobjRepeatCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objHighAccuracyCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjHighAccuracyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.GeographicLocation.EnableHighAccuracy = mobjHighAccuracyCheckBox.Checked;
        }

        /// <summary>
        /// Handles the ValueChanged event of the objMaxAgeNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaxAgeNUD_ValueChanged(object sender, EventArgs e)
        {
            this.GeographicLocation.MaximumAge = (double?)mobjMaxAgeNUD.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of the objTimeoutNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTimeoutNUD_ValueChanged(object sender, EventArgs e)
        {
            this.GeographicLocation.Timeout = (double?)mobjTimeoutNUD.Value;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objMaxAgeNullCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaxAgeNullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //If MaxAgeNullCheckBox is checked -- disable MaxAgeNUD, otherwise enable it.
            mobjMaxAgeNUD.Enabled = !mobjMaxAgeNullCheckBox.Checked;
            //Sets MaximumAge property
            this.GeographicLocation.MaximumAge = mobjMaxAgeNullCheckBox.Checked ? (double?)mobjMaxAgeNUD.Value : null;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objTimeoutNullCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTimeoutNullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //If TimeoutNullCheckBox is checked -- disable TimeoutNUD, otherwise enable it.
            mobjTimeoutNUD.Enabled = !mobjTimeoutNullCheckBox.Checked;
            //Sets Timeout property
            this.GeographicLocation.Timeout = mobjTimeoutNullCheckBox.Checked ? (double?)mobjTimeoutNUD.Value : null;
        }

        /// <summary>
        /// Handles the GeographicLocationChanged event of the GeographicLocationForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GeographicLocationChangedEventArgs"/> instance containing the event data.</param>
        private void GeographicLocationForm_GeographicLocationChanged(object sender, GeographicLocationChangedEventArgs e)
        {
            //Sets location variables
            double dblLatitude = e.Location.Latitude;
            double dblLongitude = e.Location.Longitude;
            //Sets start map location and adds marker location
            mobjGoogleMap.MapOverlays.Clear();
            mobjGoogleMap.MapOverlays.Add(new Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay(dblLatitude, dblLongitude));
            mobjGoogleMap.MapLocation = new Gizmox.WebGUI.Forms.Google.GoogleMapLocation(dblLatitude, dblLongitude);
        }
    }
}