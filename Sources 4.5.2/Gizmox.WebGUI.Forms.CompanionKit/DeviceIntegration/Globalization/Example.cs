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
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI;

#endregion

namespace CompanionKit.DeviceIntegration.Globalization
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

            mobjPrefferedLangText.ClientId = "mobjPrefferedLangText";
            mobjLocaleText.ClientId = "mobjLocaleText";
            mobjIDLSText.ClientId = "mobjIDLSText";
            mobjFDOWText.ClientId = "mobjFDOWText";
            mobjCurrencyText.ClientId = "mobjCurrencyText";
            mobjDateText.ClientId = "mobjDateText";
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjGetDataButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjGetDataButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            // Updated the label with the string representing the date based on the device pattern.
            GlobalizationDateOptions objDateToStringOptions = new GlobalizationDateOptions();
            objDateToStringOptions.FormatLength = DateStringFormatLength.Medium;
            object objJsonDateToStringOptions = CommonUtils.GetClientJsonObject(objDateToStringOptions);

            objArgs.Context.Invoke("onGlobalizationGetDataClick", "USD", DateTime.Now, objJsonDateToStringOptions);
        }     
    }
}