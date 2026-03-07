#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Forms.Google;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.DeviceIntegration.Geolocation
{
    public partial class Example : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
            InitializeComponent();

            // Start watching GPS
            this.Context.DeviceIntegrator.Geolocation.PositionChanged += new Action<GeolocationEventArgs>(Geolocation_PositionChanged);
        }

        /// <summary>
        /// Handles the Click event of the btnGetPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GetPositionButton_Click(object sender, EventArgs e)
        {
            // Get position providing handler.
            this.Context.DeviceIntegrator.Geolocation.GetPosition(GetPositionHandler);
        }

        /// <summary>
        /// Gets the position handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.Geolocation.GeolocationEventArgs"/> instance containing the event data.</param>
        private void GetPositionHandler(GeolocationEventArgs e)
        {
            // If no error occured..
            if (!e.HasError)
            {
                string strData = "";

                strData += string.Format("Latitude: {0}\n", e.Latitude);
                strData += string.Format("Longitude: {0}\n", e.Longitude);
                strData += string.Format("Altitude: {0}\n", e.Altitude);
                strData += string.Format("Accuracy: {0}\n", e.Accuracy);

                // Show map position data.                
                MessageBox.Show(strData);
            }
            else
            {
                // Else, show error message.
                MessageBox.Show(string.Format("Error: ({0}).", e.ErrorCode));
            }
        }

        /// <summary>
        /// Handles the PositionChanged event of the Geolocation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.Geolocation.GeolocationEventArgs"/> instance containing the event data.</param>
        void Geolocation_PositionChanged(GeolocationEventArgs e)
        {
            // If no errror occured..
            if (!e.HasError)
            {
                // Set map position.               
                SetMapPosition(e);
            }
            else
            {
                // Else, show error message.
                MessageBox.Show(string.Format("Error: ({0}).", e.ErrorCode));
            }
        }

        /// <summary>
        /// Sets the map position.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.Geolocation.GeolocationEventArgs"/> instance containing the event data.</param>
        private void SetMapPosition(GeolocationEventArgs e)
        {
            googleMap.MapOverlays.Clear();
            googleMap.MapOverlays.Add(new GoogleMapMarkerOverlay(e.Latitude, e.Longitude));
            googleMap.MapLocation = new GoogleMapLocation(e.Latitude, e.Longitude);
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Stops GPS watching.
            this.Context.DeviceIntegrator.Geolocation.PositionChanged -= Geolocation_PositionChanged;
        }
    }
}