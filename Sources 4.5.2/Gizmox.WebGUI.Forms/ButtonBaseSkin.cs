using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// ButtonBase Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(Button), "Button.bmp"), Serializable()]
    public class ButtonBaseSkin : ControlSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets the control focused style.
        /// </summary>
        /// <value>
        /// The control focused style.
        /// </value>
        [Category("States"), Description("Gets or sets the control Focused style.")]
        public virtual StyleValue ControlFocusedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ControlFocusedStyle");
                return objStyle;
            }
            set
            {
                this.SetValue("ControlFocusedStyle", value);
            }
        }

        /// <summary>
        /// Resets the control focused style.
        /// </summary>
        internal void ResetControlFocusedStyle()
        {
            this.Reset("ControlFocusedStyle");
        }
    }
}
