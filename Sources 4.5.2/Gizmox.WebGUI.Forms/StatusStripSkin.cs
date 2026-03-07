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
    /// StatusStrip Skin
    /// </summary>
    [SkinDependency(typeof(ToolStripStatusLabelSkin))]
    public class StatusStripSkin : ToolStripSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets the vertical orientation padding.
        /// </summary>
        /// <value>
        /// The vertical orientation padding.
        /// </value>
        [SRDescription("Vertial Orientation Padding"), Category("Layout")]
        public virtual PaddingValue VerticalOrientationPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("VerticalOrientationPadding", new Padding(1, 3, 1,3));
            }
            set
            {

                this.SetValue("VerticalOrientationPadding", value);
            }
        }

        /// <summary>
        /// Resets the vertical orientation padding.
        /// </summary>
        internal void ResetVerticalOrientationPadding()
        {
            this.Reset("VerticalOrientationPadding");
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value>
        /// The control padding.
        /// </value>
        [Category("Layout"), Description("Horizontal Orientation Padding.")]
        public PaddingValue HorizontalOrientationPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("HorizontalOrientationPadding", new Padding(1, 0, 14, 0));
            }
            set
            {
                this.SetValue("HorizontalOrientationPadding", value);
            }
        }

        /// <summary>
        /// Resets the horizontal orientation padding.
        /// </summary>
        internal void ResetHorizontalOrientationPadding()
        {
            this.Reset("HorizontalOrientationPadding");
        }
    }
}
