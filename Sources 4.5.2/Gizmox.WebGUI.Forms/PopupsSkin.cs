using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Provides loading customization capabilities
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ImageList))]
    public class PopupsSkin : CommonSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the popup frame style.
        /// </summary>
        /// <value>The popup frame style.</value>
        public FrameStyleValue FrameStyle
        {
            get
            {
                return new FrameStyleValue(this.LeftBottomStyle, this.LeftStyle,
                                            this.LeftTopStyle, this.TopStyle,
                                            this.RightTopStyle, this.RightStyle,
                                            this.RightBottomStyle, this.BottomStyle,
                                            this.CenterStyle);
            }
        }

        /// <summary>
        /// Gets or sets the height of the top frame.
        /// </summary>
        /// <value>The height of the top frame.</value>
        [Category("Sizes"), Description("The height of the top frame.")]
        public int TopFrameHeight
        {
            get
            {
                return this.GetValue<int>("TopFrameHeight", this.GetImageWidth(this.LeftTopStyle.BackgroundImage, 0));
            }
            set
            {
                this.SetValue("TopFrameHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("The width of the right frame.")]
        public int RightFrameWidth
        {
            get
            {
                return this.GetValue<int>("RightFrameWidth", this.GetImageWidth(this.RightTopStyle.BackgroundImage, 0));
            }
            set
            {
                this.SetValue("RightFrameWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Category("Sizes"), Description("The height of the bottom frame.")]
        public int BottomFrameHeight
        {
            get
            {
                return this.GetValue<int>("BottomFrameHeight", this.GetImageWidth(this.LeftBottomStyle.BackgroundImage, 0));
            }
            set
            {
                this.SetValue("BottomFrameHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("The width of the left frame.")]
        public int LeftFrameWidth
        {
            get
            {
                return this.GetValue<int>("LeftFrameWidth", this.GetImageWidth(this.LeftBottomStyle.BackgroundImage, 0));
            }
            set
            {
                this.SetValue("LeftFrameWidth", value);
            }
        }

        /// <summary>
        /// Gets the popup left top style.
        /// </summary>
        /// <value>The popup left top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue LeftTopStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup top style.
        /// </summary>
        /// <value>The popup top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue TopStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup right top style.
        /// </summary>
        /// <value>The popup right top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue RightTopStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup left style.
        /// </summary>
        /// <value>The popup left style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue LeftStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup right style.
        /// </summary>
        /// <value>The popup right style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue RightStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup left bottom style.
        /// </summary>
        /// <value>The popup left bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue LeftBottomStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center style.
        /// </summary>
        /// <value>The center style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue CenterStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup bottom style.
        /// </summary>
        /// <value>The popup bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue BottomStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popup right bottom style.
        /// </summary>
        /// <value>The popup right bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue RightBottomStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the content padding.
        /// </summary>
        /// <value>The content padding.</value>
        [Description("The popup's content padding"), Category("Layout")]
        public virtual PaddingValue ContentPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("ContentPadding", PaddingValue.Empty);
            }
            set
            {

                this.SetValue("ContentPadding", value);
            }
        }


        /// <summary>
        /// Gets the box shadow popup offset.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BoxShadowPopupOffset
        {
            get
            {
                string strLeftOffset = "0";
                string strTopOffset = "0";
                string strRighttOffset = "0";
                string strBottomOffset = "0";

                if (this.CenterStyle.BorderStyle != BorderStyle.None)
                {
                    strLeftOffset = this.CenterStyle.BorderWidth.Left.ToString();
                    strTopOffset = this.CenterStyle.BorderWidth.Top.ToString();
                    strRighttOffset = this.CenterStyle.BorderWidth.Right.ToString();
                    strBottomOffset = this.CenterStyle.BorderWidth.Bottom.ToString();
                }

                return string.Format("{0} {1} {2} {3}", strTopOffset, strRighttOffset, strBottomOffset, strLeftOffset);
            }
        }
    }
}
