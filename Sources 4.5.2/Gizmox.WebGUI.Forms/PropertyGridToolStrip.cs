using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.PropertyGridToolStripSkin)), Serializable()]
    public class PropertyGridToolStrip : ToolStrip
    {
        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        public override string CustomStyle
        {
            get
            {
                return "PG";
            }
            set
            {
                base.CustomStyle = value;
            }
        }

    }
}
