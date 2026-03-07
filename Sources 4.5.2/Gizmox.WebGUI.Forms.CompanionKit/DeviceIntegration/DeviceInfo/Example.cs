#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.DeviceInfo;

#endregion

namespace CompanionKit.DeviceIntegration.DeviceInfo
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Example : UserControl
    {
        private IDeviceIntegrator mobjDevice;


        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public Example()
        {
            InitializeComponent();

            if (VWGContext.Current != null)
            {
                // Get device integrator.
                mobjDevice = VWGContext.Current.DeviceIntegrator;
            }

            mobjNameText.ClientId = "mobjNameText";
            mobjPlatformText.ClientId = "mobjPlatformText";
            mobjCordovaText.ClientId = "mobjJavascriptVersionText";
            mobjUUIDText.ClientId = "mobjUUIDText";
            mobjVersionText.ClientId = "mobjVersionText";
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjGetInfoButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjGetInfoButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("onGetDeviceInfoClick");
        }
    }
}