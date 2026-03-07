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
    /// A Label control
    /// </summary>
    [Skin(typeof(AdministrationHeaderLabelSkin))]
    [Serializable()]
    [ToolboxItem(false)]
    internal class AdministrationHeaderLabel : Label
    {
        public AdministrationHeaderLabel()
        {
            this.CustomStyle = "AdministrationHeaderLabelSkin";
        }
    }

}
