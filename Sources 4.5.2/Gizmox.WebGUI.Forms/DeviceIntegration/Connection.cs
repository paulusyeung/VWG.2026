using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.Phonegap.Integration;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Connection : DeviceComponent, IConnection
    {
        /// <summary>
        /// Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<ConnectionEventArgs> mobjSingleCallMethodStore;



        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public Connection(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        { }


        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<ConnectionEventArgs> SingleCallMethodStore
        {
            get
            {
                if (mobjSingleCallMethodStore == null)
                {
                    mobjSingleCallMethodStore = new SingleCallMethodStore<ConnectionEventArgs>();
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
            return WGTags.ConnectionType;
        }

        /// <summary>
        /// Gets the arguments from event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private ConnectionEventArgs GetArgumentsFromEvent(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            ConnectionEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                // Validate all arguments
                if (objEvent["NetworkState"] != null)
                {
                    objArguments = new ConnectionEventArgs(objEvent["NetworkState"].ToString());
                }
                else
                {
                    // Exception???
                }
            }

            return objArguments;
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Connection_Initialize", ID);
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
            ConnectionEventArgs objArguments = GetArgumentsFromEvent(objEvent);

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

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetConnection(Action<ConnectionEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod(objCallback);

            // Call the offline api for getting the connection
            Invoke("DeviceIntegrator.Connection.getConnection", strMethodKey);
        }


    }
}
