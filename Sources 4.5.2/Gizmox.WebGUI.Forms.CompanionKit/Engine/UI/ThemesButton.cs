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
    /// A button control
    /// </summary>
    [Skin(typeof(ThemesButtonSkin))]
    [ToolboxItem(false)]
    [Serializable()]
    public class ThemesButton : Button
    {
        public ThemesButton()
        {
            this.CustomStyle = "ThemesButtonSkin";
        }
    }

}
