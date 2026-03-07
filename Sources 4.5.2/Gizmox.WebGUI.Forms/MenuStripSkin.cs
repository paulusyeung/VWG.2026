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
    /// MenuStrip Skin
    /// </summary>
    public class MenuStripSkin : ToolStripSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets the padding with grip.
        /// </summary>
        /// <value>
        /// The padding with grip.
        /// </value>
        [Category("Layout"), Description("Padding value when grip is visible.")]
        public virtual PaddingValue PaddingWithGrip
        {
            get
            {
                return this.GetValue<PaddingValue>("PaddingWithGrip", new Padding(3, 2, 0, 2));
            }
            set
            {
                this.SetValue("PaddingWithGrip", value);
            }
        }

        /// <summary>
        /// Resets the padding with grip.
        /// </summary>
        internal void ResetPaddingWithGrip()
        {
            this.Reset("PaddingWithGrip");
        }

        /// <summary>
        /// Gets or sets the padding with out grip.
        /// </summary>
        /// <value>
        /// The padding with out grip.
        /// </value>
        [Category("Layout"), Description("Padding value when grip is not visible.")]
        public virtual PaddingValue PaddingWithOutGrip
        {
            get
            {
                return this.GetValue<PaddingValue>("PaddingWithOutGrip", new Padding(6, 2, 0, 2));
            }
            set
            {
                this.SetValue("PaddingWithOutGrip", value);
            }
        }

        /// <summary>
        /// Resets the padding with out grip.
        /// </summary>
        internal void ResetPaddingWithOutGrip()
        {
            this.Reset("PaddingWithOutGrip");
        }
    }
}