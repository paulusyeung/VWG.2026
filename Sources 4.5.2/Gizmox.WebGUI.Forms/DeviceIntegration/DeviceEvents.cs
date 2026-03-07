using System;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.Client;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// Represents Device Events target object.
    /// </summary>
    [Serializable]
    public class DeviceEvents : WatchedDeviceComponent, IDeviceEvents
    {
        #region Members

        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjPauseEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjResumeEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjOnlineEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjOfflineEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjBackButtonEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjMenuButtonEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjSearchButtonEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjVolumeDownButtonEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjVolumeUpButtonEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjStartCallButtonEventStore;
        private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjEndCallButtonEventStore;

        private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryCriticalEventStore;
        private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryLowEventStore;
        private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryStatusEventStore;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets the pause event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> PauseEventStore
        {
            get
            {
                if (mobjPauseEventStore == null)
                {
                    mobjPauseEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjPauseEventStore;
            }
        }

        /// <summary>
        /// Gets the resume event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> ResumeEventStore
        {
            get
            {
                if (mobjResumeEventStore == null)
                {
                    mobjResumeEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjResumeEventStore;
            }
        }

        /// <summary>
        /// Gets the online event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> OnlineEventStore
        {
            get
            {
                if (mobjOnlineEventStore == null)
                {
                    mobjOnlineEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjOnlineEventStore;
            }
        }

        /// <summary>
        /// Gets the offline event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> OfflineEventStore
        {
            get
            {
                if (mobjOfflineEventStore == null)
                {
                    mobjOfflineEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjOfflineEventStore;
            }
        }

        /// <summary>
        /// Gets the back button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> BackButtonEventStore
        {
            get
            {
                if (mobjBackButtonEventStore == null)
                {
                    mobjBackButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjBackButtonEventStore;
            }
        }

        /// <summary>
        /// Gets the menu button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> MenuButtonEventStore
        {
            get
            {
                if (mobjMenuButtonEventStore == null)
                {
                    mobjMenuButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjMenuButtonEventStore;
            }
        }

        /// <summary>
        /// Gets the search button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> SearchButtonEventStore
        {
            get
            {
                if (mobjSearchButtonEventStore == null)
                {
                    mobjSearchButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjSearchButtonEventStore;
            }
        }

        /// <summary>
        /// Gets the volume down button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> VolumeDownButtonEventStore
        {
            get
            {
                if (mobjVolumeDownButtonEventStore == null)
                {
                    mobjVolumeDownButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjVolumeDownButtonEventStore;
            }
        }

        /// <summary>
        /// Gets the volume up button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> VolumeUpButtonEventStore
        {
            get
            {
                if (mobjVolumeUpButtonEventStore == null)
                {
                    mobjVolumeUpButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjVolumeUpButtonEventStore;
            }
        }

        /// <summary>
        /// Gets the start call button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> StartCallButtonEventStore
        {
            get
            {
                if (mobjStartCallButtonEventStore == null)
                {
                    mobjStartCallButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjStartCallButtonEventStore;
            }
        }

        /// <summary>
        /// Gets the end call button event store.
        /// </summary>
        private MultipleCallMethodStore<EmptyDeviceEventArgs> EndCallButtonEventStore
        {
            get
            {
                if (mobjEndCallButtonEventStore == null)
                {
                    mobjEndCallButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
                }

                return mobjEndCallButtonEventStore;
            }
        }


        /// <summary>
        /// Gets the battery critical event store.
        /// </summary>
        private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryCriticalEventStore
        {
            get
            {
                if (mobjBatteryCriticalEventStore == null)
                {
                    mobjBatteryCriticalEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
                }

                return mobjBatteryCriticalEventStore;
            }
        }

        /// <summary>
        /// Gets the battery low event store.
        /// </summary>
        private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryLowEventStore
        {
            get
            {
                if (mobjBatteryLowEventStore == null)
                {
                    mobjBatteryLowEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
                }

                return mobjBatteryLowEventStore;
            }
        }

        /// <summary>
        /// Gets the battery status event store.
        /// </summary>
        private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryStatusEventStore
        {
            get
            {
                if (mobjBatteryStatusEventStore == null)
                {
                    mobjBatteryStatusEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
                }

                return mobjBatteryStatusEventStore;
            }
        }


        #endregion Properties

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceEvents"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public DeviceEvents(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        {

        }

        #endregion C'tors

        #region Events

        /// <summary>
        /// Occurs when application is put into the background.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> Pause
        {
            add
            {
                PauseEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                PauseEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when application is retrieved from the background.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> Resume
        {
            add
            {
                ResumeEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                ResumeEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when application is online (connected to the Internet).
        /// </summary>
        public event Action<EmptyDeviceEventArgs> Online
        {
            add
            {
                OnlineEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                OnlineEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when application is offline (not connected to the Internet).
        /// </summary>
        public event Action<EmptyDeviceEventArgs> Offline
        {
            add
            {
                OfflineEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                OfflineEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when the user presses the back button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> BackButtonPressed
        {
            add
            {
                BackButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                BackButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when the user presses the menu button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> MenuButtonPressed
        {
            add
            {
                MenuButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                MenuButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when he user presses the search button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> SearchButtonPressed
        {
            add
            {
                SearchButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                SearchButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when  the user presses the start call button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> StartCallButtonPressed
        {
            add
            {
                StartCallButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                StartCallButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when the user presses the end call button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> EndCallButtonPressed
        {
            add
            {
                EndCallButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                EndCallButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when the user presses the volume down button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> VolumeDownButtonPressed
        {
            add
            {
                VolumeDownButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                VolumeDownButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when the user presses the volume up button.
        /// </summary>
        public event Action<EmptyDeviceEventArgs> VolumeUpButtonPressed
        {
            add
            {
                VolumeUpButtonEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                VolumeUpButtonEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when application detects the battery has reached the critical level threshold.
        /// </summary>
        public event Action<DeviceBatteryEventArgs> BatteryCritical
        {
            add
            {
                BatteryCriticalEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                BatteryCriticalEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when application detects the battery has reached the low level threshold.
        /// </summary>
        public event Action<DeviceBatteryEventArgs> BatteryLow
        {
            add
            {
                BatteryLowEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                BatteryLowEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Occurs when application detects a change in the battery status.
        /// </summary>
        public event Action<DeviceBatteryEventArgs> BatteryStatusChanged
        {
            add
            {
                BatteryStatusEventStore.AddMultipleCallMethod(value);
                this.Update();
            }

            remove
            {
                BatteryStatusEventStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        #endregion

        #region Methods

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("DeviceEvents_Initialize", ID);
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        internal override void RenderAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IResponseWriter objWriter)
        {
            IAttributeWriter objAttributeWriter = objWriter as IAttributeWriter;

            if (objAttributeWriter != null)
            {
                objAttributeWriter.WriteAttributeString(WGAttributes.Events, this.GetCriticalEventsData().ToClientString());
            }
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.Events;
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strEventType = objEvent.Type;

            MultipleCallMethodStore<EmptyDeviceEventArgs> objDeviceMethodStore = null;
            MultipleCallMethodStore<DeviceBatteryEventArgs> objBatteryMethodStore = null;

            switch (strEventType)
            {
                case WGEvents.DevicePause:
                    objDeviceMethodStore = PauseEventStore;
                    break;
                case WGEvents.DeviceResume:
                    objDeviceMethodStore = ResumeEventStore;
                    break;
                case WGEvents.DeviceOnline:
                    objDeviceMethodStore = OnlineEventStore;
                    break;
                case WGEvents.DeviceOffline:
                    objDeviceMethodStore = OfflineEventStore;
                    break;
                case WGEvents.DeviceBackButton:
                    objDeviceMethodStore = BackButtonEventStore;
                    break;
                case WGEvents.DeviceBatteryCritical:
                    objBatteryMethodStore = BatteryCriticalEventStore;
                    break;
                case WGEvents.DeviceBatteryLow:
                    objBatteryMethodStore = BatteryLowEventStore;
                    break;
                case WGEvents.DeviceBatteryStatus:
                    objBatteryMethodStore = BatteryStatusEventStore;
                    break;
                case WGEvents.DeviceMenuButton:
                    objDeviceMethodStore = MenuButtonEventStore;
                    break;
                case WGEvents.DeviceSearchButton:
                    objDeviceMethodStore = SearchButtonEventStore;
                    break;
                case WGEvents.DeviceStartCallButton:
                    objDeviceMethodStore = StartCallButtonEventStore;
                    break;
                case WGEvents.DeviceEndCallButton:
                    objDeviceMethodStore = EndCallButtonEventStore;
                    break;
                case WGEvents.DeviceVolumeDownButton:
                    objDeviceMethodStore = VolumeDownButtonEventStore;
                    break;
                case WGEvents.DeviceVolumeUpButton:
                    objDeviceMethodStore = VolumeUpButtonEventStore;

                    break;
                default:
                    break;
            }

            if (objBatteryMethodStore != null)
            {
                // Get event arguments.
                DeviceBatteryEventArgs objArgs = DeviceBatteryEventArgs.ParseFromVWGEvent(objEvent);

                // Raise event.
                this.RaiseDeviceEvent(objArgs, objBatteryMethodStore);
            }

            else if (objDeviceMethodStore != null)
            {
                // Get event arguments.
                EmptyDeviceEventArgs objArgs = EmptyDeviceEventArgs.ParseFromVWGEvent(objEvent);

                // Raise event.
                this.RaiseDeviceEvent(objArgs, objDeviceMethodStore);
            }
        }

        /// <summary>
        /// Raises the device event.
        /// </summary>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        /// <param name="objDeviceMethodStore">The obj device method store.</param>
        private void RaiseDeviceEvent(EmptyDeviceEventArgs objArgs, MultipleCallMethodStore<EmptyDeviceEventArgs> objDeviceMethodStore)
        {
            objDeviceMethodStore.InvokeMultipleCallMethods(objArgs);
        }

        /// <summary>
        /// Raises the device event.
        /// </summary>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs"/> instance containing the event data.</param>
        /// <param name="objBatteryMethodStore">The obj battery method store.</param>
        private void RaiseDeviceEvent(DeviceBatteryEventArgs objArgs, MultipleCallMethodStore<DeviceBatteryEventArgs> objBatteryMethodStore)
        {
            objBatteryMethodStore.InvokeMultipleCallMethods(objArgs);
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        public override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            if (PauseEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DevicePause);
            }

            if (ResumeEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceResume);
            }

            if (OnlineEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceOnline);
            }

            if (OfflineEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceOffline);
            }

            if (BackButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceBackButton);
            }

            if (MenuButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceMenuButton);
            }

            if (SearchButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceSearchButton);
            }

            if (StartCallButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceStartCallButton);
            }

            if (EndCallButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceEndCallButton);
            }

            if (VolumeUpButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceVolumeUpButton);
            }

            if (VolumeDownButtonEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceVolumeDownButton);
            }

            if (BatteryCriticalEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceBatteryCritical);
            }

            if (BatteryLowEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceBatteryLow);
            }

            if (BatteryStatusEventStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceBatteryStatus);
            }

            return objEvents;
        }

        #endregion Methods
    }
}
