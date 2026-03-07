using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
namespace Gizmox.WebGUI.Forms.Skins
{

    /// <summary>
    /// TextBox Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(TextBox), "TextBox.bmp"), Serializable()]
    public class TextBoxSkin : TextBoxBaseSkin
    {
        private void InitializeComponent()
        {

        }



        /// <summary>
        /// Gets the single line input style.
        /// </summary>
        /// <value>The single line input style.</value>
        [Category("States"), SRDescription("The text box single line input style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SingleLineInputStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SingleLineInputStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the multi line input style.
        /// </summary>
        /// <value>The multi line input style.</value>
        [Category("States"), SRDescription("The text box multi line input style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue MultiLineInputStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MultiLineInputStyle");
                return objStyle;
            }
        }
    }
}
