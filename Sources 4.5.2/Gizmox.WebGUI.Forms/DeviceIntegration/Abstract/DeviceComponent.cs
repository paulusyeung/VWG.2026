using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class DeviceComponent : RegisteredComponent
    {
        private DeviceIntegrator mobjDeviceIntegrator;
        private List<KeyValuePair<string, object[]>> mobjClientMethodsInvocationBuffer;
        private bool mblnBufferInvoke = true;
        private bool mblnShouldThrowUnsupportedError = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponent"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public DeviceComponent(DeviceIntegrator objDeviceIntegrator)
        {
            mobjDeviceIntegrator = objDeviceIntegrator;
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal abstract string GetTag();

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            string strMethodKey = objEvent.Type;
            if (strMethodKey == WGEvents.DeviceNotImplementedError)
            {
                throw new NotSupportedException(string.Format("This Device Provider do not support the {0} method of {1}", objEvent["methodName"], objEvent["featureName"]));
            }
        }

        /// <summary>
        /// Renders the component ID.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected void RenderComponentID(IAttributeWriter objWriter)
        {
            // Render component's id.
            objWriter.WriteAttributeString(WGAttributes.Id, this.ID.ToString());
        }

        /// <summary>
        /// Gets the mobile integrator.
        /// </summary>
        protected internal DeviceIntegrator DeviceIntegrator
        {
            get { return mobjDeviceIntegrator; }
        }

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();
            DeviceIntegrator.Update();
        }

        /// <summary>
        /// Gets the current application context.
        /// </summary>
        public override Common.Interfaces.IContext Context
        {
            get
            {
                return VWGContext.Current;
            }
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        internal virtual void RenderAttributes(IContext objContext, IResponseWriter objWriter) { }

        /// <summary>
        /// Called just before the RenderComponent is called.
        /// NOTE: This method is called also if the component is not dirty.
        /// </summary>
        public void OnRendering(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            mblnBufferInvoke = false;
        }

        /// <summary>
        /// Called after the render component is called.
        /// NOTE: This method is called also if the component is not dirty.
        /// </summary>
        public void OnRendered(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            InvokeBufferedMethods();
            mblnBufferInvoke = true;
        }

        /// <summary>
        /// Renders the component.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        internal void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (!this.IsRegistered)
            {
                RegisterSelf();
            }

            if (IsDirty(lngRequestID))
            {
                objWriter.WriteStartElement(GetTag());

                // Render the component's ID
                RenderComponentID(objWriter as IAttributeWriter);

                RenderAttributes(objContext, objWriter);

                RenderSubComponents(lngRequestID, objContext, objWriter);

                // Render offline events
                RenderComponentClientEvents(objContext, objWriter, lngRequestID);

                // Clear the events queue after rendering
                ClearComponentOfflineEvents();

                objWriter.WriteEndElement();
            }
        }

        protected internal virtual void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
        }

        /// <summary>
        /// Invoke all methods that are stored in the buffer
        /// </summary>
        private void InvokeBufferedMethods()
        {
            if (mobjClientMethodsInvocationBuffer == null) { return; }

            foreach (KeyValuePair<string, object[]> objBufferedMethod in mobjClientMethodsInvocationBuffer)
            {
                VWGClientContext.Current.Invoke(objBufferedMethod.Key, objBufferedMethod.Value);
            }

            mobjClientMethodsInvocationBuffer.Clear();
            mobjClientMethodsInvocationBuffer = null;
        }

        /// <summary>
        /// Centralized method to invoke client methods
        /// </summary>
        /// <param name="strMethodName"></param>
        /// <param name="arrArguments"></param>
        protected internal virtual void Invoke(string strMethodName, params object[] arrArguments)
        {
            if (mblnBufferInvoke)
            {
                // If not initialized, we must store the mothods in order to invoke them after the initialization method
                mobjClientMethodsInvocationBuffer = mobjClientMethodsInvocationBuffer ?? new List<KeyValuePair<string, object[]>>();
                mobjClientMethodsInvocationBuffer.Add(new KeyValuePair<string, object[]>(strMethodName, arrArguments));
            }
            else
            {
                // When initialized, we simply invoke the method in a regular way
                VWGClientContext.Current.Invoke(DeviceIntegrator as ISkinable, strMethodName, arrArguments);
            }
        }

        /// <summary>
        /// Splits the prefix from method key.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <returns></returns>
        internal protected KeyValuePair<string, string> SplitPrefixFromMethodKey(string strValue)
        {
            string[] arrValues = strValue.Split('-');

            if (arrValues.Length == 2)
            {
                return new KeyValuePair<string, string>(arrValues[0], arrValues[1]);
            }

            return new KeyValuePair<string, string>(null, null);
        }

    }
}