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
using Gizmox.WebGUI.Forms.Client;

#endregion

namespace CompanionKit.DeviceIntegration.Splashscreen
{
    /// <summary>
    /// Splashscreen example.
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

            mobjButtonAction.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(mobjButtonAction_ClientClick);
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjButtonAction control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        void mobjButtonAction_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            // Amitai
            //this.mobjDevice.Splashscreen.Show(objArgs.Context);
            VWGClientContext.Current.Invoke("setTimeout", "DeviceIntegrator.Splashscreen.hide", 3000);
        }        
    }
}