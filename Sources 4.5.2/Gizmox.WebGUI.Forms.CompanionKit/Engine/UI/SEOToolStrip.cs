using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Skin(typeof(SEOToolStripSkin))]
    public class SEOToolStrip : ToolStrip
    {
        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        public override string CustomStyle
        {
            get
            {
                return "SEO";
            }
            set
            {
                base.CustomStyle = value;
            }
        }

    }
}
