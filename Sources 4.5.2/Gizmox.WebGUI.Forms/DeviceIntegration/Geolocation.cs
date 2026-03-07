using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Geolocation : WatchedDeviceComponent, IGeolocation
    {
        // Error codes
        private const int PERMISSION_DENIED = 1;
        private const int POSITION_UNAVAILABLE = 2;
        private const int TIMEOUT = 3;

        /// <summary>
        /// Geolocation single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GeolocationEventArgs> mobjSingleCallMethodStore;

        /// <summary>
        ///  Geolocation multiple-call methods store.
        /// </summary>
        private MultipleCallMethodStore<GeolocationEventArgs> mobjMultipleCallMethodStore;

        /// <summary>
        /// Gets the single call method store.
        /// </summary>
        private SingleCallMethodStore<GeolocationEventArgs> SingleCallMethodStore
        {
            get
            {
                if (mobjSingleCallMethodStore == null)
                {
                    mobjSingleCallMethodStore = new SingleCallMethodStore<GeolocationEventArgs>();
                }
                return mobjSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the multiple call method store.
        /// </summary>
        private MultipleCallMethodStore<GeolocationEventArgs> MultipleCallMethodStore
        {
            get
            {
                if (mobjMultipleCallMethodStore == null)
                {
                    mobjMultipleCallMethodStore = new MultipleCallMethodStore<GeolocationEventArgs>();
                }
                return mobjMultipleCallMethodStore;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Geolocation"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public Geolocation(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        {
        }

        /// <summary>
        /// Occurs when [Geolocation position changed].
        /// </summary>
        public event Action<GeolocationEventArgs> PositionChanged
        {
            add
            {
                MultipleCallMethodStore.AddMultipleCallMethod(value);
                this.Update();
            }
            remove
            {
                MultipleCallMethodStore.RemoveMultipleCallMethod(value);
                this.Update();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:PositionChanged"/> event.
        /// </summary>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.Geolocation.GeolocationEventArgs"/> instance containing the event data.</param>
        private void OnPositionChanged(GeolocationEventArgs objArguments)
        {
            MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strMethodKey = objEvent.Type;

            // Insert to args - maybe remove irrelevant args
            GeolocationEventArgs objArguments = GetArgumentsFromEvent(objEvent);

            // Check if got valid arguments
            if (objArguments != null)
            {
                if (strMethodKey == WGTags.Geolocation)
                {
                    // If there's no method key, invoke the multiple call methods
                    OnPositionChanged(objArguments);
                }
                // Check if has method key
                else if (!string.IsNullOrEmpty(strMethodKey))
                {
                    if (SingleCallMethodStore.HasRegisteredMethod(strMethodKey))
                    {
                        // Invoke a single call method with a method key
                        SingleCallMethodStore.InvokeSingleCallMethod(strMethodKey, objArguments);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the arguments from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GeolocationEventArgs GetArgumentsFromEvent(IEvent objEvent)
        {
            // Prepare an arguments object
            GeolocationEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                double dblLatitude;
                double dblLongitude;
                double dblAltitude;
                double dblAltitudeAccuracy;
                double dblAccuracy;
                double dblHeading;
                double dblSpeed;
                string strTimestamp = string.Empty;

                objArguments = new GeolocationEventArgs();

                // Validate arguments
                if (objEvent["latitude"] != null && CommonUtils.TryParse(objEvent["latitude"], out dblLatitude))
                {
                    objArguments.Latitude = dblLatitude;
                }

                if (objEvent["longitude"] != null && CommonUtils.TryParse(objEvent["longitude"], out dblLongitude))
                {
                    objArguments.Longitude = dblLongitude;
                }

                if (objEvent["altitude"] != null && CommonUtils.TryParse(objEvent["altitude"], out dblAltitude))
                {
                    objArguments.Altitude = dblAltitude;
                }

                if (objEvent["altitudeAccuracy"] != null && CommonUtils.TryParse(objEvent["altitudeAccuracy"], out dblAltitudeAccuracy))
                {
                    objArguments.AltitudeAccuracy = dblAltitudeAccuracy;
                }

                if (objEvent["accuracy"] != null && CommonUtils.TryParse(objEvent["accuracy"], out dblAccuracy))
                {
                    objArguments.Accuracy = dblAccuracy;
                }

                if (objEvent["heading"] != null && CommonUtils.TryParse(objEvent["heading"], out dblHeading))
                {
                    objArguments.Heading = dblHeading;
                }

                if (objEvent["speed"] != null && CommonUtils.TryParse(objEvent["speed"], out dblSpeed))
                {
                    objArguments.Speed = dblSpeed;
                }
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the Geolocation position with default options.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetPosition(Action<GeolocationEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod(objCallback);

            ArrayList arrArgs = new ArrayList();

            arrArgs.Add(strMethodKey);

            // Call the offline api for getting the Geolocation position
            Invoke("DeviceIntegrator.Geolocation.getPosition", arrArgs.ToArray());
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Geolocation_Initialize", ID);
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
            return WGTags.Geolocation;
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        public override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            if (MultipleCallMethodStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceGeolocation);
            }

            return objEvents;
        }

    }
}
