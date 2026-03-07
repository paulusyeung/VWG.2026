#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace CompanionKit.DeviceIntegration.Accelerometer
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(AccelerationPanelSkin))]
    [Serializable()]
    public class AccelerationPanel : Panel
    {
        public AccelerationPanel()
        {
            this.CustomStyle = "AccelerationPanelSkin";
        }
    }

}
