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

#endregion

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    public partial class BatteryControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatteryControl"/> class.
        /// </summary>
        public BatteryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value
        {
            set { progressBar1.Value = value; }
        }
    }
}