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
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Device.Media;

#endregion

namespace CompanionKit.DeviceIntegration.Capture
{
    public partial class AudioExample : UserControl
    {
        private IDeviceIntegrator mobjDevice;
        private IMedia mobjMedia;
        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public AudioExample()
        {
            InitializeComponent();

            if (VWGContext.Current != null)
            {
                // Get device integrator.
                mobjDevice = VWGContext.Current.DeviceIntegrator;
            }
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            AudioCaptureOptions objImageCaptureOptions = new AudioCaptureOptions();
            objImageCaptureOptions.Limit = 1;

            mobjDevice.Capture.CaptureAudio(objImageCaptureOptions, AudioCaptured);
        }

        /// <summary>
        /// Audioes the captured.
        /// </summary>
        /// <param name="objCaptureEventArgs">The <see cref="Gizmox.WebGUI.Common.Device.Capture.CaptureEventArgs"/> instance containing the event data.</param>
        public void AudioCaptured(CaptureEventArgs objCaptureEventArgs)
        {
            if (!objCaptureEventArgs.HasError)
            {
                mobjPlay.Enabled = true;
                this.mobjCaptureDetails.LoadMediaFile(objCaptureEventArgs.CapturedFiles[0]);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjPlay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjPlay_Click(object sender, EventArgs e)
        {
            if (mobjMedia != null)
            {
                mobjMedia.Release();
            }

            mobjMedia = mobjDevice.Media.CreateMedia(mobjCaptureDetails.MediaFile.FullPath);
            mobjMedia.SetSuccessEvent(MediaStateChanged);
            mobjMedia.Play();

            mobjPlay.Enabled = false;

        }

        /// <summary>
        /// Medias the state changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="objArguments">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MediaStateChanged(object sender, EventArgs objArguments)
        {
            mobjPlay.Enabled = true;
        }
    }
}