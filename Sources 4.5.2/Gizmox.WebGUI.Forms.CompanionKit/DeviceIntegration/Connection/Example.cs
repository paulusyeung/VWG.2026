#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Forms.Client;

#endregion

namespace CompanionKit.DeviceIntegration.Connection
{
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

            mobjButtonAction.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(mobjButtonAction_ClientClick);
        }

        void mobjButtonAction_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("onCheckConnectionClick");
        }
        
    }
}