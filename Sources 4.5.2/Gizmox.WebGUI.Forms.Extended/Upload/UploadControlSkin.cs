#region Using

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;


#endregion

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Summary description for UploadControlSkin
    /// </summary>   
    [Serializable]
    public class UploadControlSkin : ControlSkin
    {

        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets Cursor for the upload control
        /// </summary>
        /// <value></value>
        [Category("UploadControl")]
        [Description("Cursor for the Upload Control")]
        public virtual Cursor Cursor
        {
            get
            {
                return this.GetValue<Cursor>("Cursor", Cursors.No);
            }
            set
            {
                this.SetValue("Cursor", value);
            }
        }

        /// <summary>
        /// Gets or sets Cursor for the upload control
        /// </summary>
        /// <value></value>
        [Category("UploadButton")]
        [Description("Cursor for the Upload Button")]
        public virtual Cursor UploadButtonCursor
        {
            get
            {
                return this.GetValue<Cursor>("UploadButtonCursor", Cursors.No);
            }
            set
            {
                this.SetValue("UploadButtonCursor", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the upload button in pixels
        /// </summary>
        /// <value></value>
        [Category("UploadButton")]
        [Description("Width of upload button in pixels")]
        public virtual int UploadButtonWidth
        {
            get
            {
                return this.GetValue<int>("UploadButtonWidth", 0);
            }
            set
            {
                this.SetValue("UploadButtonWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets Style of the upload button
        /// </summary>
        /// <value></value>
        [Category("UploadButton")]
        [Description("Style of the Upload button")]
        public StyleValue UploadButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UploadButtonStyle");
                return objStyle;
            }
        }

        internal void ResetUploadButtonStyle()
        {
	        this.Reset("UploadButtonStyle");
        }

        /// <summary>
        /// Gets or sets the height of progress bar in pixels
        /// </summary>
        /// <value></value>
        [Category("UploadBar")]
        [Description("Height of progress bar in pixels")]
        public virtual int UploadBarHeight
        {
            get
            {
                return this.GetValue<int>("UploadBarHeight", 0);
            }
            set
            {
                this.SetValue("UploadBarHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets Style of the not completed area area of the progress bar bar
        /// </summary>
        /// <value></value>
        [Category("UploadBar")]
        [Description("Style of the not completed area area of the progress bar")]
        public StyleValue UploadBarStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UploadBarStyle");
                return objStyle;
            }
        }

        internal void ResetUploadBarStyle()
        {
            this.Reset("UploadBarStyle");
        }

        /// <summary>
        /// Gets or sets Style of completed area of the progress bar
        /// </summary>
        /// <value></value>
        [Category("UploadBar")]
        [Description("Style of completed area of the progress bar")]
        public StyleValue UploadBarCompletedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UploadBarCompletedStyle");
                return objStyle;
            }
        }

        internal void ResetUploadBarCompletedStyle()
        {
            this.Reset("UploadBarCompletedStyle");
        }
    }
}

