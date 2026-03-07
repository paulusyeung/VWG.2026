using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    [Serializable]
    public class Compass : WatchedDeviceComponent, ICompass
    {
        // Error codes
        private const int INTERNAL_ERROR = 0;
        private const int COMPASS_UNSUPPORTED = 20;

        /// <summary>
        /// Compass single-call methods store.
        /// </summary>
        private SingleCallMethodStore<CompassEventArgs> mobjSingleCallMethodStore;

        /// <summary>
        ///  Compass multiple-call methods store.
        /// </summary>
        private MultipleCallMethodStore<CompassEventArgs> mobjMultipleCallMethodStore;

        /// <summary>
        /// Gets the single call method store.
        /// </summary>
        private SingleCallMethodStore<CompassEventArgs> SingleCallMethodStore
        {
            get
            {
                if (mobjSingleCallMethodStore == null)
                {
                    mobjSingleCallMethodStore = new SingleCallMethodStore<CompassEventArgs>();
                }
                return mobjSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the multiple call method store.
        /// </summary>
        private MultipleCallMethodStore<CompassEventArgs> MultipleCallMethodStore
        {
            get
            {
                if (mobjMultipleCallMethodStore == null)
                {
                    mobjMultipleCallMethodStore = new MultipleCallMethodStore<CompassEventArgs>();
                }
                return mobjMultipleCallMethodStore;
            }
        }


        public Compass(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        {
        }

        /// <summary>
        /// Occurs when [compass heading changed].
        /// </summary>
        public event Action<CompassEventArgs> HeadingChanged
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
        /// Raises the <see cref="E:CompassHeadingChanged"/> event.
        /// </summary>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.Compass.CompassEventArgs"/> instance containing the event data.</param>
        private void OnHeadingChanged(CompassEventArgs objArguments)
        {
            MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);
        }

        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strMethodKey = objEvent.Type;

            // Insert to args - maybe remove irrelevant args
            CompassEventArgs objArguments = GetArgumentsFromEvent(objEvent);

            // Check if got valid arguments
            if (objArguments != null)
            {
                if (strMethodKey == WGTags.Compass)
                {
                    // If there's no method key, invoke the multiple call methods
                    OnHeadingChanged(objArguments);
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
        private CompassEventArgs GetArgumentsFromEvent(IEvent objEvent)
        {
            // Prepare an arguments object
            CompassEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                double dblMagneticHeading;
                double dblTrueHeading;
                double dblHeadingAccuracy;
                string strTimestamp = string.Empty;

                // Validate all arguments
                if (objEvent["magneticHeading"] != null && CommonUtils.TryParse(objEvent["magneticHeading"], out dblMagneticHeading) &&
                    objEvent["trueHeading"] != null && CommonUtils.TryParse(objEvent["trueHeading"], out dblTrueHeading) &&
                    objEvent["headingAccuracy"] != null && CommonUtils.TryParse(objEvent["magneticHeading"], out dblHeadingAccuracy))
                {
                    // Check for time stamp
                    if (objEvent["timeStamp"] != null)
                    {
                        strTimestamp = objEvent["timeStamp"];
                    }

                    objArguments = new CompassEventArgs(dblMagneticHeading, dblTrueHeading, dblHeadingAccuracy, strTimestamp);
                }
                else
                {
                    // Exception???
                }
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the compass heading.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetCurrentHeading(Action<CompassEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod(objCallback);

            // Call the offline api for getting the compass heading
            Invoke("DeviceIntegrator.Compass.getCurrentHeading", strMethodKey);
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Compass_Initialize", ID);
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
            return WGTags.Compass;
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
                objEvents.Set(WGEvents.DeviceCompass);
            }

            return objEvents;
        }

       
    }
}
