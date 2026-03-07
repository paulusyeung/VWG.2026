using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces;
using Newtonsoft.Json.Linq;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Forms.Client;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MediaFile : IMediaFile
    {
        private Capture mobjCaptureComponent;
        private string mstrName;
        private string mstrFullPath;
        private string mstrType;
        private DateTime mobjLastModifiedDate;
        private ulong mlngSize;

        /// <summary>
        /// Parses from VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objCaptureComponent">The obj capture component.</param>
        /// <returns></returns>
        internal static IMediaFile[] ParseFromVWGEvent(IEvent objEvent, Capture objCaptureComponent)
        {
            int intCount;
            if (!string.IsNullOrEmpty(objEvent["count"]) && int.TryParse(objEvent["count"], out intCount))
            {
                IMediaFile[] arrMediaFiles = new IMediaFile[intCount];

                for (int i = 0; i < intCount; i++)
                {
                    string strCapture = objEvent["cap" + i];

                    if (!string.IsNullOrEmpty(strCapture))
                    {
                        JObject objMediaFile = JsonUtils.Deserialize(strCapture);
                        
                        MediaFile objFile = new MediaFile(objCaptureComponent);

                        objFile.Name = objMediaFile.Value<string>("name");
                        objFile.FullPath = objMediaFile.Value<string>("fullPath");
                        objFile.Type = objMediaFile.Value<string>("type");
                        objFile.LastModifiedDate = objMediaFile.Value<DateTime>("lastModifiedDate");
                        objFile.Size = objMediaFile.Value<ulong>("size");

                        arrMediaFiles[i] = objFile;
                    }
                }

                return arrMediaFiles;
            }

            return null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFile"/> class.
        /// </summary>
        /// <param name="objCaptureComponent">The obj capture component.</param>
        public MediaFile(Capture objCaptureComponent)
        {
            mobjCaptureComponent = objCaptureComponent;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return mstrName; }
            internal set { mstrName = value; }
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        public string FullPath
        {
            get { return mstrFullPath; }
            internal set { mstrFullPath = value; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public string Type
        {
            get { return mstrType; }
            internal set { mstrType = value; }
        }

        /// <summary>
        /// Gets the last modified date.
        /// </summary>
        public DateTime LastModifiedDate
        {
            get { return mobjLastModifiedDate; }
            internal set { mobjLastModifiedDate = value; }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public ulong Size
        {
            get { return mlngSize; }
            internal set { mlngSize = value; }
        }

        /// <summary>
        /// Gets the format data.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetFormatData(EventHandler<MediaFileDataEventArgs> objCallback)
        {
            mobjCaptureComponent.GetFormatData(this, objCallback);
        }
    }
}
