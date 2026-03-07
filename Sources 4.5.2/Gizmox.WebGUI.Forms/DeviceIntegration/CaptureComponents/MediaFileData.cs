using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Device.Common;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MediaFileData : IMediaFileData
    {
        private string mstrCodecs;
        private ulong mlngBitrate;
        private ulong mlngHeight;
        private ulong mlngWidth;
        private ulong mlngDuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFileData"/> class.
        /// </summary>
        public MediaFileData()
        {

        }

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        internal static MediaFileData FromVWGEvent(IEvent objEvent) 
        {
            MediaFileData objMediaFileData = new MediaFileData();

            objMediaFileData.mstrCodecs = objEvent["codecs"];

            if (ulong.TryParse(objEvent["bitrate"], out  objMediaFileData.mlngBitrate)) { }
            if (ulong.TryParse(objEvent["height"], out  objMediaFileData.mlngHeight)) { }
            if (ulong.TryParse(objEvent["width"], out  objMediaFileData.mlngWidth)) { }
            if (ulong.TryParse(objEvent["duration"], out  objMediaFileData.mlngDuration)) { }

            return objMediaFileData;
        }

        /// <summary>
        /// Gets the codecs.
        /// </summary>
        public string Codecs
        {
            get { return mstrCodecs; }
            internal set { mstrCodecs = value; }
        }

        /// <summary>
        /// Gets the bitrate.
        /// </summary>
        public ulong Bitrate
        {
            get { return mlngBitrate; }
            internal set { mlngBitrate = value; }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        public ulong Height
        {
            get { return mlngHeight; }
            internal set { mlngHeight = value; }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public ulong Width
        {
            get { return mlngWidth; }
            internal set { mlngWidth = value; }
        }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        public ulong Duration
        {
            get { return mlngDuration; }
            internal set { mlngDuration = value; }
        }
    }
}
