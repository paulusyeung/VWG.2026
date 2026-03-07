using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Common;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    [Serializable]
    public class DeviceMedia : WatchedDeviceComponent, IDeviceMedia
    {
        private Dictionary<string, Media> mobjIdMediaMap = new Dictionary<string, Media>();
        private List<KeyValuePair<string, object[]>> mobjClientMethodsInvocationBuffer;
        private SingleCallMethodStore<MediaPositionEventArgs> mobjMediaPositionEventArgsStore;
        private SingleCallMethodStore<MediaEventArgs> mobjMediaEventArgsStore;
        private Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>> mobjMediaIdPositionChangedStoreMap = new Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceMedia"/> class.
        /// </summary>
        /// <param name="objIntegrator">The obj integrator.</param>
        public DeviceMedia(DeviceIntegrator objIntegrator)
            : base(objIntegrator)
        {
        }

        private MultipleCallMethodStore<MediaPositionEventArgs> GetPositionChangedStore(Media objMedia)
        {
            MultipleCallMethodStore<MediaPositionEventArgs> objResult = null;
            if (!mobjMediaIdPositionChangedStoreMap.TryGetValue(objMedia.Id, out objResult))
            {
                objResult = new MultipleCallMethodStore<MediaPositionEventArgs>();
                mobjMediaIdPositionChangedStoreMap.Add(objMedia.Id, objResult);

            }

            return objResult;
        }

        /// <summary>
        /// Gets the media position event args store.
        /// </summary>
        internal SingleCallMethodStore<MediaPositionEventArgs> MediaPositionEventArgsStore
        {
            get
            {
                if (mobjMediaPositionEventArgsStore == null)
                {
                    mobjMediaPositionEventArgsStore = new SingleCallMethodStore<MediaPositionEventArgs>();
                }

                return mobjMediaPositionEventArgsStore;
            }
        }

        /// <summary>
        /// Gets the media event args store.
        /// </summary>
        internal SingleCallMethodStore<MediaEventArgs> MediaEventArgsStore
        {
            get
            {
                if (mobjMediaEventArgsStore == null)
                {
                    mobjMediaEventArgsStore = new SingleCallMethodStore<MediaEventArgs>();
                }

                return mobjMediaEventArgsStore;
            }
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.DeviceMedia;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);
            if (objEvent.Type == "Duration")
            {
                // Handle duration.
                string strDuration = objEvent["dur"];
                float fltDuration = float.Parse(strDuration);
                string strMediaId = objEvent["mid"];
                Media objMedia = mobjIdMediaMap[strMediaId];
                objMedia.Duration = fltDuration;
                return;
            }

            // Handle CurrentPositionChanged event.
            if (objEvent.Type == "Position")
            {
                // Handle media current positions.
                string strMediaIdsPositionData = objEvent["mediaIdsPositionData"];
                if (!string.IsNullOrEmpty(strMediaIdsPositionData))
                {
                    string[] arrMediaIdsPositionData = strMediaIdsPositionData.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arrMediaIdsPositionData.Length; i++)
                    {
                        string strMediaIdPositionData = arrMediaIdsPositionData[i];
                        string[] arrMediaIdPosition = strMediaIdPositionData.Split(new string[1] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                        Media objMedia = mobjIdMediaMap[arrMediaIdPosition[0]];
                        float fltPosition = float.Parse(arrMediaIdPosition[1]);

                        OnPositionChanged(objMedia, new MediaPositionEventArgs(fltPosition));
                    }
                }

                return;
            }

            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(objEvent.Type);

            if (objSplittedValues.Key == null)
            {
                Media objMedia;

                if (this.mobjIdMediaMap.TryGetValue(objEvent.Type, out objMedia))
                {
                    objMedia.HandleEvent(objEvent);
                }
            }
            else
            {
                switch (objSplittedValues.Key)
                {
                    case "pos":

                        float fltPosition;
                        if (CommonUtils.TryParse(objEvent["pos"], out fltPosition))
                        {
                            MediaPositionEventArgs objMediaPositionEventArgs = new MediaPositionEventArgs(fltPosition);

                            mobjMediaPositionEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objMediaPositionEventArgs);
                        }
                        break;
                    case "dur":
                        float intDuration;
                        if (CommonUtils.TryParse(objEvent["dur"], out intDuration))
                        {
                            Media objMedia = mobjIdMediaMap[objSplittedValues.Value];
                            objMedia.Duration = intDuration;
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:OnPositionChanged"/> event.
        /// </summary>
        private void OnPositionChanged(Media objMedia, MediaPositionEventArgs objArguments)
        {
            MultipleCallMethodStore<MediaPositionEventArgs> objPositionChangedStore = GetPositionChangedStore(objMedia);
            objPositionChangedStore.InvokeMultipleCallMethods(objArguments);
        }

        /// <summary>
        /// Creates a media.
        /// </summary>
        /// <param name="strSource">The STR source.</param>
        /// <returns></returns>
        public IMedia CreateMedia(string strSource)
        {
            this.Update();
            Media objMedia = new Media(strSource, this);

            mobjIdMediaMap.Add(objMedia.GetHashCode().ToString(), objMedia);

            return objMedia;
        }

        /// <summary>
        /// Plays the specified obj media.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void Play(Media objMedia)
        {
            Invoke("DeviceIntegrator.Media.playBack", "play", objMedia.GetHashCode().ToString());
        }

        /// <summary>
        /// Pauses the specified obj media.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void Pause(Media objMedia)
        {
            Invoke("DeviceIntegrator.Media.playBack", "pause", objMedia.GetHashCode().ToString());
        }

        /// <summary>
        /// Stops the specified obj media.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void Stop(Media objMedia)
        {
            Invoke("DeviceIntegrator.Media.playBack", "stop", objMedia.GetHashCode().ToString());
        }

        /// <summary>
        /// Releases the specified obj media.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void Release(Media objMedia)
        {
            Invoke("DeviceIntegrator.Media.release", objMedia.GetHashCode().ToString());
        }

        /// <summary>
        /// Seeks to.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="lngMilliseconds">The LNG milliseconds.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void SeekTo(Media objMedia, ulong lngMilliseconds)
        {
            Invoke("DeviceIntegrator.Media.seek", objMedia.GetHashCode().ToString(), lngMilliseconds);
        }

        /// <summary>
        /// Renders the sub components.
        /// </summary>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Media_Initialize", ID);
            foreach (Media objMedia in mobjIdMediaMap.Values)
            {
                if (objMedia.IsDirty(lngRequestID))
                {
                    RenderMedia(objMedia, objContext, objWriter);
                }
            }

            if (mobjClientMethodsInvocationBuffer != null)
            {
                foreach (KeyValuePair<string, object[]> objBufferedMethod in mobjClientMethodsInvocationBuffer)
                {
                    VWGClientContext.Current.Invoke(objBufferedMethod.Key, objBufferedMethod.Value);
                }

                mobjClientMethodsInvocationBuffer.Clear();
                mobjClientMethodsInvocationBuffer = null;
            }
        }

        /// <summary>
        /// Renders the media.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderMedia(Media objMedia, IContext objContext, IResponseWriter objWriter)
        {
            bool blnSuccessCallbackExist = false;
            bool blnErrorCallbackExist = false;
            bool blnStateCallbackExist = false;

            if (objMedia.GetSuccessData() != null)
            {
                blnSuccessCallbackExist = true;
            }

            if (objMedia.GetErrorData() != null)
            {
                blnErrorCallbackExist = true;
            }

            if (objMedia.GetStateData() != null)
            {
                blnStateCallbackExist = true;
            }

            bool blnPositionChangedWatch = false;
            if (mobjMediaIdPositionChangedStoreMap.ContainsKey(objMedia.Id))
            {
                blnPositionChangedWatch = true;
            }

            VWGClientContext.Current.Invoke(DeviceIntegrator, "Media_InitializeMedia", objMedia.Id, objMedia.Source, blnSuccessCallbackExist, blnErrorCallbackExist, blnStateCallbackExist, blnPositionChangedWatch);
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        internal override void RenderAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IResponseWriter objWriter)
        {
            IAttributeWriter objAttributeWriter = objWriter as IAttributeWriter;
            if (this.GetCriticalEventsData().HasEvents)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Events, this.GetCriticalEventsData().ToClientString());
            }
        }

        public void AddPositionChanged(Media objMedia, Action<MediaPositionEventArgs> objAction)
        {
            MultipleCallMethodStore<MediaPositionEventArgs> objPositionChangedStore = GetPositionChangedStore(objMedia);
            objPositionChangedStore.AddMultipleCallMethod(objAction);
            objMedia.Update();
        }

        public void RemovePositionChanged(Media objMedia, Action<MediaPositionEventArgs> objAction)
        {
            MultipleCallMethodStore<MediaPositionEventArgs> objPositionChangedStore = GetPositionChangedStore(objMedia);
            objPositionChangedStore.RemoveMultipleCallMethod(objAction);

            if (!objPositionChangedStore.HasEventListeners())
            {
                mobjMediaIdPositionChangedStoreMap.Remove(objMedia.Id);
            }
            objMedia.Update();
        }

        /// <summary>
        /// Gets the current position.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void GetCurrentPosition(Media objMedia, EventHandler<MediaPositionEventArgs> objCallback)
        {
            object[] arrParameters = new object[2];
            arrParameters[0] = objMedia.GetHashCode().ToString();
            arrParameters[1] = MediaPositionEventArgsStore.StoreContextualSingleCallMethod(objMedia, "pos", objCallback);

            Invoke("DeviceIntegrator.Media.getCurrentPosition", arrParameters);
        }

        /// <summary>
        /// Starts the record.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void StartRecord(Media objMedia)
        {
            Invoke("DeviceIntegrator.Media.playBack", "startRecord", objMedia.GetHashCode().ToString());
        }

        /// <summary>
        /// Stops the record.
        /// </summary>
        /// <param name="objMedia">The obj media.</param>
        /// <param name="objClientContext">The obj client context.</param>
        internal void StopRecord(Media objMedia)
        {
            Invoke("DeviceIntegrator.Media.playBack", "stopRecord", objMedia.GetHashCode().ToString());
        }

        public override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            foreach (MultipleCallMethodStore<MediaPositionEventArgs> objPositionChangedStore in mobjMediaIdPositionChangedStoreMap.Values)
            {
                if (objPositionChangedStore.HasEventListeners())
                {
                    objEvents.Set(WGEvents.DeviceMediaPosition);
                }
            }

            return objEvents;
        }

    }
}
