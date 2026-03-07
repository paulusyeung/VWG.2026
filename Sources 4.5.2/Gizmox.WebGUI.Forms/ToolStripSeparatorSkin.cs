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
    /// ToolStripSeparator Skin
    /// </summary>
    [Serializable()]
    public class ToolStripSeparatorSkin : ControlSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the width of the vertical seperator.
        /// </summary>
        /// <value>
        /// The width of the vertical seperator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalSeperatorWidth
        {
            get
            {
                return this.GetImageWidth(this.SeperatorVerticalStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the height of the horizontal seperator.
        /// </summary>
        /// <value>
        /// The height of the horizontal seperator.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalSeperatorHeight
        {
            get
            {
                return this.GetImageWidth(this.SeperatorHorizontalStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the seperator vertical style.
        /// </summary>
        /// <value>The seperator style.</value>
        public StyleValue SeperatorVerticalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SeperatorVerticalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the seperator horizontal style.
        /// </summary>
        /// <value>The seperator horizontal style.</value>
        public StyleValue SeperatorHorizontalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SeperatorHorizontalStyle");
                return objStyle;
            }
        }
    }
}
