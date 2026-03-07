#region Using

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces.Device;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Device.Accelerometer;

#endregion

namespace CompanionKit.DeviceIntegration.Accelerometer
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

            accelerationPanel1.ClientId = "accelerationPanel1";
        }

        /// <summary>
        /// Handles the Click event of the btnWatchAcceleration control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnWatchAcceleration_Click(object sender, System.EventArgs e)
        {
            // Toggle watching
            if (!mblnIsWatching)
            {
                StartWatch();
                mobjWatchAccelerationButton.Image = new ImageResourceHandle("On.png");
            }
            else
            {
                StopWatch();
                mobjWatchAccelerationButton.Image = new ImageResourceHandle("Off.png");
            }
            mblnIsWatching = !mblnIsWatching;
        }

        /// <summary>
        /// Starts the watch.
        /// </summary>
        private void StartWatch()
        {
            VWGClientContext.Current.Invoke("startAccelerationWatch");
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
            ClientContext context = VWGClientContext.Current;
            if (context != null)
            {
                VWGClientContext.Current.Invoke("stopAccelerationWatch");
            }
        }
    }


}