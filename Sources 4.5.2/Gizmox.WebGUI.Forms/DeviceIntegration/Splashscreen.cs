using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class Splashscreen : DeviceComponent, ISplashscreen
    {
        public Splashscreen(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        { }


        /// <summary>
        /// Shows this instance.
        /// </summary>
        public void Show()
        {
            // Call the offline api for getting the connection
            Invoke("DeviceIntegrator.Splashscreen.show");
        }

        /// <summary>
        /// Hides this instance.
        /// </summary>
        public void Hide()
        {
            // Call the offline api for getting the connection
            Invoke("DeviceIntegrator.Splashscreen.hide");
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.Splashscreen;
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Splashscreen_Initialize", ID);
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
        }

    }
}
