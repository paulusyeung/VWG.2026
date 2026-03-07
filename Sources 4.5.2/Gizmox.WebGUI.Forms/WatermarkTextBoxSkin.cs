using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// WatermarkTextBox Skin
    /// </summary>
    [Serializable()]
    public class WatermarkTextBoxSkin : Gizmox.WebGUI.Forms.Skins.TextBoxSkin
    {
        /// <summary>
        /// Gets the watermark style.
        /// </summary>
        /// <value>The watermark style.</value>
        public virtual StyleValue WatermarkStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "WatermarkStyle");
                return objStyle;
            }
        }
    }
}