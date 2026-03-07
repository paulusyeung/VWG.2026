#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// A ListView control
    /// </summary>
    [Skin(typeof(MainDeviceListViewSkin))]
    [Serializable()]
    public class MainDeviceListView : ListView
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SEOListView"/> class.
        /// </summary>
        public MainDeviceListView()
        {
            this.CustomStyle = "MainDeviceListViewSkin";
        }

        #endregion Constructors

        #region Delegates and Events

        /// <summary>
        /// Occurs when [item click].
        /// </summary>
        public event EventHandler ItemClick;

        #endregion Delegates and Events

        #region Methods

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (ItemClick != null)
            {
                objEvents.Set(WGEvents.Click);
            }

            return objEvents;
        }

        /// <summary>
        /// </summary>
        /// <param name="objListViewItem"></param>
        /// <param name="objMouseEventArgs"></param>
        protected override void OnItemClick(ListViewItem objListViewItem, MouseEventArgs objMouseEventArgs)
        {
            base.OnItemClick(objListViewItem, objMouseEventArgs);

            if (ItemClick != null)
            {
                ItemClick(objListViewItem, objMouseEventArgs); 
            }
        }

        #endregion Methods
    }
}
