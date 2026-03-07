#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Summary description for SurfacePanel
    /// </summary>
    [ToolboxItem(false)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.SurfacePanelSkin)), Serializable()]
    public class SurfacePanel : Panel, IRequiresRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SurfacePanel"/> class.
        /// </summary>
        public SurfacePanel()
        {
            this.PanelType = PanelType.Custom;
            this.CustomStyle = "Surface";
        }
    }
}
