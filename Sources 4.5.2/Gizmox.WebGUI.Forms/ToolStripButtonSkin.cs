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
    /// ToolStripButton Skin
    /// </summary>
    [Serializable()]
    public class ToolStripButtonSkin : ButtonSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the flat checked button normal style.
        /// </summary>
        /// <value>The flat checked button normal style.</value>
        [Category("States"), Description("The flat checked button normal style.")]
        public virtual StyleValue FlatCheckedButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatCheckedButtonNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the flat checked button hover style.
        /// </summary>
        /// <value>The flat checked button hover style.</value>
        [Category("States"), Description("The flat checked button hover style.")]
        public virtual StyleValue FlatCheckedButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatCheckedButtonHoverStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the flat checked button focused style.
        /// </summary>
        /// <value>The flat checked button focused style.</value>
        [Category("States"), Description("The flat checked button focused style.")]
        public virtual StyleValue FlatCheckedButtonFocusedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatCheckedButtonFocusedStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the flat checked button pressed style.
        /// </summary>
        /// <value>The flat checked button pressed style.</value>
        [Category("States"), Description("The flat checked button pressed style.")]
        public virtual StyleValue FlatCheckedButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatCheckedButtonPressedStyle");
                return objStyle;
            }
        }
    }
}
