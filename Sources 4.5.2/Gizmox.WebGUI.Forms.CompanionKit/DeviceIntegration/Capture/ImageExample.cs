#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.Capture;

#endregion

namespace CompanionKit.DeviceIntegration.Capture
{
    public partial class ImageExample : UserControl
    {
        private IDeviceIntegrator mobjDevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public ImageExample()
        {
            InitializeComponent();

            if (VWGContext.Current != null)
            {
                // Get device integrator.
                mobjDevice = VWGContext.Current.DeviceIntegrator;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageCaptureOptions objImageCaptureOptions = new ImageCaptureOptions();
            objImageCaptureOptions.Limit = 1;

            mobjDevice.Capture.CaptureImage(objImageCaptureOptions, ImageCaptured);
        }

        public void ImageCaptured(CaptureEventArgs objCaptureEventArgs)
        {
            if (!objCaptureEventArgs.HasError)
            {
                this.mobjCaptureDetails.LoadMediaFile(objCaptureEventArgs.CapturedFiles[0]);
            }
        }
    }
}