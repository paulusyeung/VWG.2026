#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// A button control
    /// </summary>
    [Skin(typeof(DeviceNavigationUpButtonSkin))]
    [Serializable()]
    public class DeviceNavigationUpButton : Button
    {
        public DeviceNavigationUpButton()
        {
            this.CustomStyle = "DeviceNavigationUpButtonSkin";           
        }
    }

}
