using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Common.Device;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    [Serializable]
    public class Capture : DeviceComponent, ICapture
    {
        private SingleCallMethodStore<CaptureEventArgs> mobjCaptureEventArgsStore;
        private SingleCallMethodStore<MediaFileDataEventArgs> mobjMediaFileDataEventArgsStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Capture"/> class.
        /// </summary>
        /// <param name="objPhonegapIntegrator">The obj phonegap integrator.</param>
        public Capture(DeviceIntegrator objPhonegapIntegrator)
            : base(objPhonegapIntegrator)
        {
        }

        /// <summary>
        /// Gets the capture event args store.
        /// </summary>
        internal SingleCallMethodStore<CaptureEventArgs> CaptureEventArgsStore
        {
            get
            {
                if (mobjCaptureEventArgsStore == null)
                {
                    mobjCaptureEventArgsStore = new SingleCallMethodStore<CaptureEventArgs>();
                }

                return mobjCaptureEventArgsStore;
            }
        }

        /// <summary>
        /// Gets the media file data event args store.
        /// </summary>
        internal SingleCallMethodStore<MediaFileDataEventArgs> MediaFileDataEventArgsStore
        {
            get
            {
                if (mobjMediaFileDataEventArgsStore == null)
                {
                    mobjMediaFileDataEventArgsStore = new SingleCallMethodStore<MediaFileDataEventArgs>();
                }

                return mobjMediaFileDataEventArgsStore;
            }
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.Capture;
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Capture_Initialize", ID);
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);
            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(objEvent.Type);

            if (string.IsNullOrEmpty(objSplittedValues.Key))
            {
                CaptureEventArgs objArguments = GetCaptureEventArgs(objEvent);
                mobjCaptureEventArgsStore.InvokeSingleCallMethod(objEvent.Type, objArguments);
            }
            else
            {
                switch (objSplittedValues.Key)
                {
                    case "for":
                        MediaFileDataEventArgs objMediaFileDataEventArgs = CreateMediaFileDataEventArgs(objEvent);
                        MediaFileDataEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objMediaFileDataEventArgs);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Creates the media file data event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private MediaFileDataEventArgs CreateMediaFileDataEventArgs(IEvent objEvent)
        {
            MediaFileDataEventArgs objMediaFileDataEventArgs;
            if (!DeviceEventArgs.TryGetError(objEvent, out objMediaFileDataEventArgs))
            {
                objMediaFileDataEventArgs = new MediaFileDataEventArgs(MediaFileData.FromVWGEvent(objEvent));
            }

            return objMediaFileDataEventArgs;
        }

        /// <summary>
        /// Gets the capture event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private CaptureEventArgs GetCaptureEventArgs(IEvent objEvent)
        {
            CaptureEventArgs objArguments;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                IMediaFile[] arrMediaFiles = MediaFile.ParseFromVWGEvent(objEvent, this);

                return new CaptureEventArgs(arrMediaFiles);
            }

            return objArguments;
        }

        /// <summary>
        /// Captures the audio.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void CaptureAudio(Action<CaptureEventArgs> objCallback)
        {
            CaptureAudio(null, objCallback);
        }

        /// <summary>
        /// Captures the audio.
        /// </summary>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void CaptureAudio(AudioCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)
        {
            CaptureOnline("captureAudio", objOptions, objCallback);
        }

        /// <summary>
        /// Captures the image.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void CaptureImage(Action<CaptureEventArgs> objCallback)
        {
            CaptureImage(null, objCallback);
        }

        /// <summary>
        /// Captures the image.
        /// </summary>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void CaptureImage(ImageCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)
        {
            CaptureOnline("captureImage", objOptions, objCallback);
        }

        /// <summary>
        /// Captures the video.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void CaptureVideo(Action<CaptureEventArgs> objCallback)
        {
            CaptureVideo(null, objCallback);
        }

        /// <summary>
        /// Captures the video.
        /// </summary>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void CaptureVideo(VideoCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)
        {
            CaptureOnline("captureVideo", objOptions, objCallback);
        }

        /// <summary>
        /// Captures the online.
        /// </summary>
        /// <param name="strCaptureType">Type of the STR capture.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        private void CaptureOnline(string strCaptureType, DevicePropertyDictionary objOptions, Action<CaptureEventArgs> objCallback)
        {
            object[] objArguments = new object[3];

            objArguments[0] = strCaptureType;
            objArguments[1] = CaptureEventArgsStore.StoreSingleCallMethod(objCallback);
            objArguments[2] = CommonUtils.GetClientJsonObject(objOptions);

            Invoke("DeviceIntegrator.Capture.capture", objArguments);
        }

        /// <summary>
        /// Gets the format data.
        /// </summary>
        /// <param name="objMediaFile">The obj media file.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void GetFormatData(MediaFile objMediaFile, EventHandler<MediaFileDataEventArgs> objCallback)
        {
            object[] objArguments = new object[3];

            objArguments[0] = MediaFileDataEventArgsStore.StoreContextualSingleCallMethod(objMediaFile, "for", objCallback);
            objArguments[1] = objMediaFile.FullPath;
            objArguments[2] = objMediaFile.Type;

            Invoke("DeviceIntegrator.Capture.getFormatData", objArguments);
        }
    }
}
