using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Media : IMedia
    {
        private DeviceMedia mobjDeviceMedia;
        private string mstrSource;
        private long mlngLastModified;
        private float mfltDuration = -1;

        private EventHandler<MediaEventArgs> mobjSuccessCallback;
        private EventHandler<EmptyDeviceEventArgs> mobjErrorCallback;
        private EventHandler<MediaStateEventArgs> mobjMediaStateCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="Media"/> class.
        /// </summary>
        /// <param name="strSource">The STR source.</param>
        /// <param name="objDeviceMedia">The obj device media.</param>
        public Media(string strSource, DeviceMedia objDeviceMedia)
        {
            mstrSource = strSource;
            mobjDeviceMedia = objDeviceMedia;
            mlngLastModified = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Occurs when [compass heading changed].
        /// </summary>
        public event Action<MediaPositionEventArgs> PositionChanged
        {
            add
            {
                mobjDeviceMedia.AddPositionChanged(this, value);
            }
            remove
            {
                mobjDeviceMedia.RemovePositionChanged(this, value);
                this.Update();
            }
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public string Id
        {
            get 
            { 
                return GetHashCode().ToString(); 
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public string Source
        {
            get { return mstrSource; }
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            mobjDeviceMedia.Play(this);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        internal void Update()
        {
            mobjDeviceMedia.Update();
            mlngLastModified = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Pauses this instance.
        /// </summary>
        public void Pause()
        {
            mobjDeviceMedia.Pause(this);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            mobjDeviceMedia.Stop(this);
        }

        /// <summary>
        /// Releases this instance.
        /// </summary>
        public void Release()
        {
            mobjDeviceMedia.Release(this);
        }

        /// <summary>
        /// Seeks to.
        /// </summary>
        /// <param name="lngMilliseconds">The LNG milliseconds.</param>
        public void SeekTo(ulong lngMilliseconds)
        {
            mobjDeviceMedia.SeekTo(this, lngMilliseconds);
        }

        /// <summary>
        /// Gets the current position.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetCurrentPosition(EventHandler<MediaPositionEventArgs> objCallback)
        {
            mobjDeviceMedia.GetCurrentPosition(this, objCallback);
        }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public float Duration
        {
            get
            {
                return mfltDuration;
            }
            internal set
            {
                mfltDuration = value;
            }
        }

        /// <summary>
        /// Starts the record.
        /// </summary>
        public void StartRecord()
        {
            mobjDeviceMedia.StartRecord(this);
        }

        /// <summary>
        /// Stops the record.
        /// </summary>
        public void StopRecord()
        {
            mobjDeviceMedia.StopRecord(this);
        }

        /// <summary>
        /// Sets the success event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetSuccessEvent(EventHandler<MediaEventArgs> objCallback)
        {
            Update();
            mobjSuccessCallback = objCallback;
        }

        /// <summary>
        /// Sets the error event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            Update();
            mobjErrorCallback = objCallback;
        }

        /// <summary>
        /// Sets the state change event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetStateChangeEvent(EventHandler<MediaStateEventArgs> objCallback)
        {
            Update();
            mobjMediaStateCallback = objCallback;
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal void HandleEvent(IEvent objEvent)
        {
            switch (objEvent.Member.ToLower())
            {
                case "success":
                    if (mobjSuccessCallback != null)
                    {
                        MediaEventArgs objArgs = new MediaEventArgs(this);
                        mobjSuccessCallback(this, objArgs);
                    }
                    break;
                case "error":
                    if (mobjErrorCallback != null)
                    {
                        EmptyDeviceEventArgs objArgs;
                        DeviceEventArgs.TryGetError(objEvent, out objArgs);

                        mobjErrorCallback(this, objArgs);
                    }
                    break;
                case "state":
                    int intState;
                    if (mobjMediaStateCallback != null && int.TryParse(objEvent["state"], out intState))
                    {
                        mobjMediaStateCallback(this, new MediaStateEventArgs(intState));
                    }
                    break;
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Determines whether the specified LNG request ID is dirty.
        /// </summary>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <returns>
        ///   <c>true</c> if the specified LNG request ID is dirty; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsDirty(long lngRequestID)
        {
            return lngRequestID < mlngLastModified;
        }

        /// <summary>
        /// Gets the success data.
        /// </summary>
        /// <returns></returns>
        internal object GetSuccessData()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjSuccessCallback);
        }

        /// <summary>
        /// Gets the error data.
        /// </summary>
        /// <returns></returns>
        internal object GetErrorData()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjErrorCallback);
        }

        /// <summary>
        /// Gets the state data.
        /// </summary>
        /// <returns></returns>
        internal object GetStateData()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjMediaStateCallback);
        }
    }
}
