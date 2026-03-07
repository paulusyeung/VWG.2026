using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Accelerometer : WatchedDeviceComponent, IAccelerometer
    {
        /// <summary>
        /// Accelerometer single-call methods store.
        /// </summary>
        private SingleCallMethodStore<AccelerometerEventArgs> mobjSingleCallMethodStore;

        /// <summary>
        /// Gets the Accelerometer single-call methods store.
        /// </summary>
        private SingleCallMethodStore<AccelerometerEventArgs> SingleCallMethodStore
        {
            get
            {
                if (mobjSingleCallMethodStore == null)
                {
                    mobjSingleCallMethodStore = new SingleCallMethodStore<AccelerometerEventArgs>();
                }
                return mobjSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Accelerometer multiple-call methods store.
        /// </summary>
        private MultipleCallMethodStore<AccelerometerEventArgs> mobjMultipleCallMethodStore;

        /// <summary>
        /// Gets the Accelerometer multiple-call method store.
        /// </summary>
        private MultipleCallMethodStore<AccelerometerEventArgs> MultipleCallMethodStore
        {
            get
            {
                if (mobjMultipleCallMethodStore == null)
                {
                    mobjMultipleCallMethodStore = new MultipleCallMethodStore<AccelerometerEventArgs>();
                }
                return mobjMultipleCallMethodStore;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Accelerometer"/> class.
        /// </summary>
        /// <param name="objMobileIntegrator">The obj mobile integrator.</param>
        public Accelerometer(DeviceIntegrator objMobileIntegrator)
            : base(objMobileIntegrator)
        { }

        /// <summary>
        /// Gets the acceleration.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetCurrentAcceleration(Action<AccelerometerEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod(objCallback);

            // Call the offline api for getting the acceleration
            Invoke("DeviceIntegrator.Accelerometer.getCurrentAcceleration", strMethodKey);
        }

        /// <summary>
        /// Gets the arguments from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private AccelerometerEventArgs GetArgumentsFromEvent(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            AccelerometerEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                double x;
                double y;
                double z;
                string strTimestamp = string.Empty;
                string strWatchID = string.Empty;

                // Validate all arguments
                if (objEvent["X"] != null && objEvent["Y"] != null && objEvent["Z"] != null
                    && CommonUtils.TryParse(objEvent["X"], out x)
                    && CommonUtils.TryParse(objEvent["Y"], out y)
                    && CommonUtils.TryParse(objEvent["Z"], out z))
                {
                    // Check for time stamp
                    if (objEvent["timeStamp"] != null)
                    {
                        strTimestamp = objEvent["timeStamp"];
                    }

                    objArguments = new AccelerometerEventArgs(x, y, z, strTimestamp);
                }
                else
                {
                    // Exception???
                }
            }

            return objArguments;
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
            AccelerometerEventArgs objArguments = GetArgumentsFromEvent(objEvent);

            // Check if got valid arguments
            if (objArguments != null)
            {
                if (strMethodKey == WGTags.Accelerometer)
                {
                    // If there's no method key, invoke the multiple call methods
                    OnAccelerationChanged(objArguments);
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
        /// Raises the <see cref="E:AccelerationChanged"/> event.
        /// </summary>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.Accelerometer.AccelerometerEventArgs"/> instance containing the event data.</param>
        private void OnAccelerationChanged(AccelerometerEventArgs objArguments)
        {
            MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);
        }

        /// <summary>
        /// Occurs when [acceleration changed].
        /// </summary>
        public event Action<AccelerometerEventArgs> AccelerationChanged
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
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        public override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            if (MultipleCallMethodStore.HasEventListeners())
            {
                objEvents.Set(WGEvents.DeviceAccelerometer);
            }

            return objEvents;
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Accelerometer_Initialize", ID);
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
            return WGTags.Accelerometer;
        }

    }
}
