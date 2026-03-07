using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class WatchedDeviceComponent : DeviceComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WatchedDeviceComponent"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public WatchedDeviceComponent(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        { }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected abstract internal override string GetTag();

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        public abstract CriticalEventsData GetCriticalEventsData();
    }
}
