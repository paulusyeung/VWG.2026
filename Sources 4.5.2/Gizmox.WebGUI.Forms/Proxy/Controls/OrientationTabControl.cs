#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Client.Design;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A TabControl control
    /// </summary>
    [Skin(typeof(OrientationTabControlSkin))]
    [Serializable()]
    public class OrientationTabControl : TabControl
    {
        private long mlngProxyId;
        private bool? mblnDeviceLandscape;

        public OrientationTabControl()
        {
        }

        /// <summary>
        /// Handle pre render.
        /// </summary>
        protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
        {
            base.PreRenderControl(objContext, lngRequestID);

            // Call UpdateOrientation in the client if dirty and not adminitstration form (EMS for example)
            if (!(VWGContext.Current.MainForm is IAdministrationForm))
            {
                // If the mblnDeviceLandscape == null it means we are at startup
                if (mblnDeviceLandscape == null)
                {                    
                    mblnDeviceLandscape = IsDeviceLandscape();
                    bool blnStartupLandscape = IsStartupLandscape();
                    SelectedIndex = mblnDeviceLandscape.Value == blnStartupLandscape ? 0 : 1;
                }

                if (IsDirty(lngRequestID))
                {
                    // Save the mlngProxyId here, for the use ot the Form_ClientOrientationChanged, because here the control has ProxyComponent attached.
                    mlngProxyId = GetProxyPropertyValue<long>("ID", 0);
                    Form.ClientOrientationChanged += Form_ClientOrientationChanged;
                }
            }
        }

        /// <summary>
        /// Handle client orientation changed event.
        /// </summary>
        void Form_ClientOrientationChanged(object objSender, Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke(this, "OrientationTabControl_UpdateOrientation", mlngProxyId, mblnDeviceLandscape.Value);
        }

        /// <summary>
        /// Returns whether the device start the application in landscape.
        /// </summary>
        private bool IsStartupLandscape()
        {
            bool blnIsLandscape = false;
            if (((IContextParams)VWGContext.Current).StartupDeviceOrientation == DeviceOrientation.Landscape)
            {
                blnIsLandscape = true;
            }

            return blnIsLandscape;
        }

        /// <summary>
        /// Return if the current device is landscape.
        /// </summary>
        private bool IsDeviceLandscape()
        {
            IContextParams objContextParams = VWGContext.Current as IContextParams;
            BrowserRepository objBrowserRepository = new BrowserRepository();
            Size objDeviceSize = objBrowserRepository.GetDeviceSize(VWGContext.Current as IClientDesignServices, objContextParams.BrowserId);
            bool blnIsLandscape = false;
            if (objDeviceSize.Width > objDeviceSize.Height)
            {
                blnIsLandscape = true;
            }

            return blnIsLandscape;
        }
    }

}
