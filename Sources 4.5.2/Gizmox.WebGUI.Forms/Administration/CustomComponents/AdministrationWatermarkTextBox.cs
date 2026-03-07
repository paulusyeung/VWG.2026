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
    /// A TextBox control
    /// </summary>
    [Skin(typeof(AdministrationWatermarkTextBoxSkin))]
    [Serializable()]
    [ToolboxItem(false)]
    internal class AdministrationWatermarkTextBox : WatermarkTextBox
    {
        public AdministrationWatermarkTextBox()
        {
            this.CustomStyle = "AdministrationWatermarkTextBoxSkin";
        }
    }

}
