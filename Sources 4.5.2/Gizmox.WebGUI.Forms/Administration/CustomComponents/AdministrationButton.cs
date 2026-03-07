#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
    /// <summary>
    /// A button control
    /// </summary>
    [Skin(typeof(AdministrationButtonSkin))]
    [Serializable()]
    [ToolboxItem(false)]
    internal class AdministrationButton : Button
    {
        public AdministrationButton()
        {
            this.CustomStyle = "AdministrationButtonSkin";
        }
    }

}
