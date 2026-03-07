#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Forms.Google;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device;

#endregion

namespace CompanionKit.DeviceIntegration.Media
{
    public partial class Example : UserControl
    {
        private IDeviceMedia mobjDeviceMedia;
        private IMedia mobjMedia;
        private float mfltPosition;
        private bool mblnPlaying;

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
            mobjDeviceMedia = VWGContext.Current.DeviceIntegrator.Media;
            InitializeComponent();

            mobjPositionLabel.ClientId = "mobjPositionLabel";
            mobjProgress.ClientId = "mobjProgress";
        }

        private void Example_Load(object sender, EventArgs e)
        {
            string baseUrl = VWGContext.Current.HostContext.Request.Info.GetRouterContext(VWGContext.Current.CurrentUICulture, true);
            
            mobjMedia = mobjDeviceMedia.CreateMedia(baseUrl + (new DataResourceHandle("MediaTestFile.mp3")).ToString());           
            mobjMedia.SetStateChangeEvent(StatusChangeHandler);            
            mobjMedia.SetSuccessEvent(SuccessHandler);

            mobjMedia.PositionChanged += mobjMedia_PositionChanged;
        }

        void mobjMedia_PositionChanged(MediaPositionEventArgs e)
        {
            if (mblnPlaying == false) { return; }

            // If the duration was not loaded yet, we will not do nothing.
            if (mobjMedia.Duration == -1) { return; }

            mfltPosition = e.Position;

            double intTotalSeconds = Math.Round(mfltPosition);
            double intMinutes = Math.Floor(intTotalSeconds / 60);
            double intSeconds = Math.Floor(intTotalSeconds % 60);
            string strTimeString = intMinutes + ":" + (intSeconds < 10 ? "0" : "") + intSeconds;
            mobjProgress.Value = Convert.ToInt32((((float)100) * mfltPosition / mobjMedia.Duration));
            mobjPositionLabel.Text = strTimeString;

            if (mobjMedia.Duration >= 0)
            {
                this.mobjLengthLabel.Text = ConvertSecondsToTimeString(mobjMedia.Duration);
            }
        }

        private void SuccessHandler(object sender, EventArgs objArgs)
        {
            mobjSeekBack.Enabled = false;
            mobjPause.Enabled = false;
            mobjStop.Enabled = false;
            mobjSeekForward.Enabled = false;
            mobjProgress.Enabled = false;
        }


        private void StatusChangeHandler(object sender, MediaStateEventArgs objArgs)
        {
            switch (objArgs.State)
            {
                case 1:
                case 2:
                    mblnPlaying = true;

                    mobjSeekBack.Enabled = true;
                    mobjPause.Enabled = true;
                    mobjPlay.Enabled = true;
                    mobjStop.Enabled = true;
                    mobjSeekForward.Enabled = true;
                    mobjProgress.Enabled = true;
                    break;
                case 3:
                    mblnPlaying = true;
                    
                    break;
                case 4:
                    mblnPlaying = true;

                    mobjLengthLabel.Text =  "--:--";

                    // Reset the values
                    mobjProgress.Value = 0;
                    mobjPositionLabel.Text = "--:--";

                    break;
                default:
                    break;
            }
        }

        private string ConvertSecondsToTimeString(float fltDuration)
        {
            int intTotalSeconds = (int)fltDuration;

            int intMinutes = intTotalSeconds / 60;
            int intSeconds = intTotalSeconds % 60;

            return string.Format("{0}:{1}", intMinutes, intSeconds);
        }

        private void mobjPlay_Click(object sender, EventArgs e)
        {            
            mobjMedia.Play();
        }

        private void mobjStop_Click(object sender, EventArgs e)
        {
            mobjMedia.Stop();
        }

        private void mobjPause_Click(object sender, EventArgs e)
        {
            mobjMedia.Pause();
        }

        private void mobjSeekBack_Click(object sender, EventArgs e)
        {
            mobjMedia.GetCurrentPosition(SeekBackHandler);
        }

        private void SeekBackHandler(object sender, MediaPositionEventArgs objArgs) 
        { 
            float fltSeekTo = 0;
            
            if (objArgs.Position - 15 > 0)
            {
                fltSeekTo = objArgs.Position - 15;
            }

            mobjMedia.SeekTo((ulong)(fltSeekTo * 1000));
        }

        private void SeekForwardHandler(object sender, MediaPositionEventArgs objArgs)
        {
            float fltSeekTo = mobjMedia.Duration;

            if (objArgs.Position + 15 < mobjMedia.Duration)
            {
                fltSeekTo = objArgs.Position + 15;
            }

            ulong fltPosition = (ulong)(fltSeekTo * 1000);

            System.Diagnostics.Debug.WriteLine(fltSeekTo + " | " + objArgs.Position + " | " + fltPosition);

            mobjMedia.SeekTo(fltPosition);
        }

        private void mobjSeekForward_Click(object sender, EventArgs e)
        {
            mobjMedia.GetCurrentPosition(SeekForwardHandler);
        }
    }
}