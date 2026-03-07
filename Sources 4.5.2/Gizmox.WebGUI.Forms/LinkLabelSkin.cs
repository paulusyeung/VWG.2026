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
    /// LinkLabel Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(LinkLabel), "LinkLabel.bmp")]
    [Serializable()]
    public class LinkLabelSkin : LabelSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets the color of the link.
        /// </summary>
        /// <value>The color of the link.</value>
        [Category("Colors"), Description("The color which is used to display the link text.")]
        public virtual Color LinkColor
        {
            get
            {
                return this.GetValue<Color>("LinkColor", this.DefaultLinkColor);
            }
            set
            {
                this.SetValue("LinkColor", value);
            }
        }


        /// <summary>
        /// Resets the color of the link.
        /// </summary>
        internal void ResetLinkColor()
        {
            this.Reset("LinkColor");
        }


        /// <summary>
        /// Gets the default color of the link.
        /// </summary>
        /// <value>The default color of the link.</value>
        protected virtual Color DefaultLinkColor
        {
            get
            {
                return Color.Blue;
            }
        }

        /// <summary>
        /// Gets or sets the link color disabled.
        /// </summary>
        /// <value>The link color disabled.</value>
        [Category("Colors"), Description("The color which is used to display the Disabled link text.")]
        public virtual Color LinkColorDisabled
        {
            get
            {
                return this.GetValue<Color>("LinkColorDisabled", this.DefaultLinkColorDisabled);
            }
            set
            {
                this.SetValue("LinkColorDisabled", value);
            }
        }

        /// <summary>
        /// Resets the link color disabled.
        /// </summary>
        internal void ResetLinkColorDisabled()
        {
            this.Reset("LinkColorDisabled");
        }

        /// <summary>
        /// Gets the default link color disabled.
        /// </summary>
        /// <value>The default link color disabled.</value>
        protected virtual Color DefaultLinkColorDisabled
        {
            get
            {
                return Color.FromArgb(169,169,169);
            }
        }

        /// <summary>
        /// Gets the Content style.
        /// </summary>
        /// <value>The Content style.</value>
        public virtual StyleValue ContentStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ContentStyle");
                return objStyle;
            }
        }
        
        /// <summary>
        /// Gets the focused style.
        /// </summary>
        /// <value>The focused style.</value>
        public virtual StyleValue FocusedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FocusedStyle");
                return objStyle;
            }
        }
    }
}
