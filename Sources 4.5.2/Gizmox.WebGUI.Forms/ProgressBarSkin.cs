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
    /// ProgressBar Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ProgressBar), "ProgressBar.bmp"), Serializable()]
    public class ProgressBarSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets the control disabled style.
        /// </summary>
        /// <value>
        /// The control disabled style.
        /// </value>
        public virtual StyleValue ProgressBarNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ProgressBarNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the control disabled style.
        /// </summary>
        /// <value>
        /// The control disabled style.
        /// </value>
        public virtual StyleValue ProgressBarBarStyle
        {
            get
            {

                StyleValue objStyle = new StyleValue(this, "ProgressBarBarStyle");
                return objStyle;
            }
        }
        
        /// <summary>
        /// Gets or sets the start width of the progress minimum.
        /// </summary>
        /// <value>
        /// The start width of the progress minimum.
        /// </value>
        public int ProgressMinimumStartWidth
        {
            get
            {
                return this.GetValue<int>("ProgressMinimumStartWidth", 0);
            }
            set
            {
                this.SetValue("ProgressMinimumStartWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the progress bar image left.
        /// </summary>
        /// <value>
        /// The progress bar image left.
        /// </value>
        public ImageResourceReference ProgressBarImageLeft
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ProgressBarImageLeft", ImageResourceReference.Empty);
            }
            set
            {
                this.SetValue("ProgressBarImageLeft", value);
            }
        }

        /// <summary>
        /// Gets the width of the progress bar image left.
        /// </summary>
        /// <value>
        /// The width of the progress bar image left.
        /// </value>
        [Browsable(false)]
        public int ProgressBarImageLeftWidth 
        {
            get
            {
                return GetImageWidth(ProgressBarImageLeft, 0);
            }
        }

        /// <summary>
        /// Gets or sets the progress bar image right.
        /// </summary>
        /// <value>
        /// The progress bar image right.
        /// </value>
        public ImageResourceReference ProgressBarImageRight
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ProgressBarImageRight", ImageResourceReference.Empty);
            }
            set
            {
                this.SetValue("ProgressBarImageRight", value);
            }
        }

        /// <summary>
        /// Gets the progress bar image left right.
        /// </summary>
        /// <value>
        /// The progress bar image left right.
        /// </value>
        [Browsable(false)]
        public int ProgressBarImageLeftRight
        {
            get
            {
                return GetImageWidth(ProgressBarImageRight, 0);
            }
        }
    }
}
