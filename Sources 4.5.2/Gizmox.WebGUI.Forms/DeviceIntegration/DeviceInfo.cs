using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    [Serializable()]
    public class DeviceInfo : DeviceComponent, IDeviceInfo
    {
        /// <summary>
        /// Single call method store.
        /// </summary>
        private SingleCallMethodStore<DeviceInfoEventArgs> mobjSingleCallMethodStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchedDeviceComponent"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public DeviceInfo(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        { }



        /// <summary>
        /// Gets the single call method store.
        /// </summary>
        private SingleCallMethodStore<DeviceInfoEventArgs> SingleCallMethodStore
        {
            get
            {
                if (mobjSingleCallMethodStore == null)
                {
                    mobjSingleCallMethodStore = new SingleCallMethodStore<DeviceInfoEventArgs>();
                }
                return mobjSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.DeviceInfo;
        }

        /// <summary>
        /// Gets the arguments from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private DeviceInfoEventArgs GetArgumentsFromEvent(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            DeviceInfoEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                // Validate all arguments
                if (objEvent["Name"] != null && objEvent["JavascriptVersion"] != null && objEvent["Platform"] != null && objEvent["UUID"] != null && objEvent["Version"] != null)
                {
                    objArguments = new DeviceInfoEventArgs(objEvent["Name"].ToString(), objEvent["JavascriptVersion"].ToString(), objEvent["Platform"].ToString(), objEvent["UUID"].ToString(), objEvent["Version"].ToString());
                }
                else
                {
                    // Exception???
                }
            }

            return objArguments;
        }


        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strMethodKey = objEvent.Type;

            // Insert to args - maybe remove irrelevant args
            DeviceInfoEventArgs objArguments = GetArgumentsFromEvent(objEvent);

            // Check if got valid arguments
            if (objArguments != null)
            {
                if (!string.IsNullOrEmpty(strMethodKey) && SingleCallMethodStore.HasRegisteredMethod(strMethodKey))
                {
                    // Invoke a single call method with a method key
                    SingleCallMethodStore.InvokeSingleCallMethod(strMethodKey, objArguments);
                }
            }
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("DeviceInfo_Initialize", ID);
        }

        /// <summary>
        /// Gets the device info.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetDeviceInfo(Action<DeviceInfoEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod(objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.DeviceInfo.getDeviceInfo", strMethodKey);
        }

     
    }
}
