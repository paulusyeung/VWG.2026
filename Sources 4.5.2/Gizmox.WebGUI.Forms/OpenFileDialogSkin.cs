using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using System.Globalization;
namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// OpenFileDialog Skin
    /// </summary>
    [ToolboxBitmap(typeof(OpenFileDialog), "OpenFileDialog.bmp"), Serializable()]
    public class OpenFileDialogSkin : ControlSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets the uploading image.
        /// </summary>
        /// <value>
        /// The uploading image.
        /// </value>
        [Category("Images"), Description("Uploading animation image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageResourceReference UploadingImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UploadingImage", new ImageResourceReference(typeof(OpenFileDialogSkin), "Uploading.gif"));
            }

            set
            {
                this.SetValue("UploadingImage", value);
            }
        }

        /// <summary>
        /// Gets the width of the uploading image.
        /// </summary>
        /// <value>
        /// The width of the uploading image.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int UploadingImageWidth
        {
            get
            {
                return this.GetImageWidth(this.UploadingImage);
            }
        }

        /// <summary>
        /// Gets Flash Add button font style.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FlashAddButtonFont
        {
            get
            {
                // Get skin font
                Font objFont = this.Font;

                StringBuilder objSB = new StringBuilder();

                // Add font size
                objSB.Append("font-size:").Append(objFont.Size.ToString(CultureInfo.InvariantCulture));

                // Add size unit
                switch (objFont.Unit)
                {
                    case GraphicsUnit.Pixel:
                        objSB.Append("px");
                        break;
                    case GraphicsUnit.Point:
                        objSB.Append("pt");
                        break;
                }
                // Add font name
                objSB.Append(";font-family:").Append(objFont.Name);

                // Add font weight
                if (objFont.Bold)
                {
                    objSB.Append(";font-weight:bold");
                }

                // Add font style
                if (objFont.Italic)
                {
                    objSB.Append(";font-style:italic");
                }
                // Add fore color
                if (this.ForeColor != Color.Black)
                {
                    objSB.Append(";color:#").Append(CommonUtils.GetRGBColor(this.ForeColor));
                }

                return objSB.ToString();
            }
        }

        /// <summary>
        /// Gets the upload list frame style.
        /// </summary>
        /// <value>
        /// The upload list frame style.
        /// </value>
        [Category("Styles"), Description("The upload list frame style.")]
        public virtual StyleValue UploadListFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UploadListFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Resets the upload list frame style.
        /// </summary>
        internal void ResetUploadListFrameStyle()
        {
            this.Reset("UploadListFrameStyle");
        }

        /// <summary>
        /// Gets the upload button style.
        /// </summary>
        /// <value>
        /// The upload button style.
        /// </value>
        [Category("Styles"), Description("The upload button style.")]
        public virtual StyleValue UploadButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UploadButtonStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Resets the upload button style.
        /// </summary>
        internal void ResetUploadButtonStyle()
        {
            this.Reset("UploadButtonStyle");
        }

        /// <summary>
        /// Gets the upload label style.
        /// </summary>
        /// <value>
        /// The upload label style.
        /// </value>
        [Category("Styles"), Description("The upload label style.")]
        public virtual StyleValue UploadLabelStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "UploadLabelStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Resets the upload label style.
        /// </summary>
        internal void ResetUploadLabelStyle()
        {
            this.Reset("UploadLabelStyle");
        }
    }
}