#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI;

#endregion Using

namespace CompanionKit.DeviceIntegration.Compass
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(CompassSkin))]
    [Serializable()]
    public class Compass : Panel
    {
        private const double MAX_HEADING = 360.0;
        private double mdblValue;
        public Compass()
        {
            this.CustomStyle = "CompassSkin";
        }

    }
}
