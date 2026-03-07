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
    /// Status Bar Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(StatusBar), "StatusBar.bmp"), Serializable()]
    public class StatusBarSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {

        }

        #region Styles

        /// <summary>
        /// Gets the status bar style.
        /// </summary>
        /// <value>The status bar style.</value>
        [Category("States"), SRDescription("The StatusBar style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue StatusBarStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "StatusBarStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the status bar layout style.
        /// </summary>
        /// <value>The status bar layout style.</value>
        [Category("States"), SRDescription("The StatusBar layout style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue StatusBarLayoutStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "StatusBarLayoutStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the status bar panel style.
        /// </summary>
        /// <value>The status bar panel style.</value>
        [Category("States"), SRDescription("The StatusBar layout style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue StatusBarPanelStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "StatusBarPanelStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the separator image.
        /// </summary>
        /// <value>The separator image.</value>
        [Category("Images"), SRDescription("Separator image")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageResourceReference SeparatorImage
        {
            get
            {
                return (ImageResourceReference)this.GetValue<string>("SeparatorImage", new ImageResourceReference(typeof(StatusBarSkin), "StatusBarSep.gif"));
            }
            set
            {
                this.SetValue("SeparatorImage", (string)value);
            }
        }

        /// <summary>
        /// Gets the width of the separator image.
        /// </summary>
        /// <value>The width of the separator image.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int SeparatorImageWidth
        {
            get
            {
                return this.GetImageWidth(this.SeparatorImage, 2);
            }
        }

        #endregion        

        #region Images

        /// <summary>
        /// Gets or sets background top image.
        /// </summary>
        /// <value>Background top image.</value>
        [SRDescription("Background Top Image image")]
        [SRCategory("Images")]
        public virtual ImageResourceReference BackgroundTopImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("BackgroundTopImage", new ImageResourceReference(typeof(StatusBarSkin), "StatusBarTopBG.gif"));
            }
            set
            {
                this.SetValue("BackgroundTopImage", value);
            }
        }

        /// <summary>
        /// Resets the background top image.
        /// </summary>
        internal void ResetBackgroundTopImage()
        {
            this.Reset("BackgroundTopImage");
        }


        /// <summary>
        /// Gets or sets background bottom image.
        /// </summary>
        /// <value>Background bottom image.</value>
        [SRDescription("Background bottom image")]
        [SRCategory("Images")]
        public virtual ImageResourceReference BackgroundBottomImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("BackgroundBottomImage", new ImageResourceReference(typeof(StatusBarSkin), "StatusBarBottomBG.gif"));
            }
            set
            {
                this.SetValue("BackgroundBottomImage", value);
            }
        }

        /// <summary>
        /// Resets the background bottom image.
        /// </summary>
        internal void ResetBackgroundBottomImage()
        {
            this.Reset("BackgroundBottomImage");
        }

        #endregion Images
    }
}
