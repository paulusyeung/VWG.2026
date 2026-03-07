#region Using

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces.Device;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.DeviceIntegration.Compass
{
    public partial class Example : UserControl
    {
        private IDeviceIntegrator mobjDevice;
        private bool mblnIsWatching;

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
            InitializeComponent();

            if (VWGContext.Current != null)
            {
                // Get device integrator.
                mobjDevice = VWGContext.Current.DeviceIntegrator;
            }

            compass1.ClientId = "compass1";
        }

        /// <summary>
        /// Handles the Click event of the btnWatchCompass control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnWatchCompass_Click(object sender, System.EventArgs e)
        {
            // Toggle watching.
            if (!mblnIsWatching)
            {
                StartWatch();
                mobjWatchCompassButton.Image = new ImageResourceHandle("On.png");
            }
            else
            {
                StopWatch();
                mobjWatchCompassButton.Image = new ImageResourceHandle("Off.png");
            }
            mblnIsWatching = !mblnIsWatching;
        }

        /// <summary>
        /// Starts the watch.
        /// </summary>
        private void StartWatch()
        {
            // Watch compass heading, providing callback name defined in included js
            VWGClientContext.Current.Invoke("startCompassWatch");
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            StopWatch();
        }

        /// <summary>
        /// Stops the watch.
        /// </summary>
        private void StopWatch()
        {
            VWGClientContext.Current.Invoke("stopCompassWatch");
        }
    }
}