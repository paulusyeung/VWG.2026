using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// ToolStripSplitButton Skin
    /// </summary>
    [Serializable()]
    public class ToolStripSplitButtonSkin : ButtonSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the drop down image container style.
        /// </summary>
        public StyleValue DropDownImageContainerStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownImageContainerStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down image container hover style.
        /// </summary>
        public StyleValue DropDownImageContainerHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownImageContainerHoverStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down image container focus style.
        /// </summary>
        public StyleValue DropDownImageContainerFocusStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownImageContainerFocusStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down image container down style.
        /// </summary>
        public StyleValue DropDownImageContainerDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownImageContainerDownStyle");
                return objStyle;
            }
        }
    }
}
