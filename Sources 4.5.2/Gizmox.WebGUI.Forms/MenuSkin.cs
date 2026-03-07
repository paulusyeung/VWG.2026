using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.ComponentModel;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Menu Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(Menu), "MainMenu.bmp")]
    [Serializable()]
    public class MenuSkin : ControlSkin
    {
        #region PopupWindow Style

        /// <summary>
        /// Gets or sets the width of the popup window offset.
        /// </summary>
        /// <value>The width of the popup window offset.</value>
        [Category("Sizes"), Description("The offset width for the popup window.")]
        public virtual int PopupWindowOffsetWidth
        {
            get
            {
                return this.GetValue<int>("PopupWindowOffsetWidth", this.DefaultPopupWindowOffsetWidth);
            }
            set
            {
                this.SetValue("PopupWindowOffsetWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the popup window offset.
        /// </summary>
        private void ResetPopupWindowOffsetWidth()
        {
            this.Reset("PopupWindowOffsetWidth");
        }

        /// <summary>
        /// Gets the default width of the popup window offset.
        /// </summary>
        /// <value>The default width of the popup window offset.</value>
        protected virtual int DefaultPopupWindowOffsetWidth
        {
            get
            {
                int intDefaultWidth = this.PopupWindowStyle.CenterStyle.BorderWidth.Left + this.PopupWindowStyle.CenterStyle.BorderWidth.Right
                    + this.PopupWindowStyle.CenterStyle.Padding.Horizontal;

                if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null)
                {
                    if ((HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
                    {
                        return intDefaultWidth;
                    }
                }

                return intDefaultWidth + this.RightPopupWindowFrameWidth + this.LeftPopupWindowFrameWidth;
            }
        }

        /// <summary>
        /// Gets or sets the height of the popup window offset.
        /// </summary>
        /// <value>The height of the popup window offset.</value>
        [Category("Sizes"), Description("The offset height for the popup window.")]
        public virtual int PopupWindowOffsetHeight
        {
            get
            {
                return this.GetValue<int>("PopupWindowOffsetHeight", this.DefaultPopupWindowOffsetHeight);
            }
            set
            {
                this.SetValue("PopupWindowOffsetHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the popup window offset.
        /// </summary>
        private void ResetPopupWindowOffsetHeight()
        {
            this.Reset("PopupWindowOffsetHeight");
        }

        /// <summary>
        /// Gets the default height of the popup window offset.
        /// </summary>
        /// <value>The default height of the popup window offset.</value>
        protected virtual int DefaultPopupWindowOffsetHeight
        {
            get
            {
                int intDefaultHeight = this.PopupWindowStyle.CenterStyle.BorderWidth.Top + this.PopupWindowStyle.CenterStyle.BorderWidth.Bottom
                    + this.PopupWindowStyle.CenterStyle.Padding.Vertical;

                if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null)
                {
                    if ((HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
                    {
                        return intDefaultHeight;
                    }
                }

                return intDefaultHeight + this.TopPopupWindowFrameHeight + this.BottomPopupWindowFrameHeight;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left popup window frame.
        /// </summary>
        /// <value>The width of the left popup window frame.</value>
        [Category("Sizes"), Description("The width of the left popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int LeftPopupWindowFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Resets the width of the left popup window frame.
        /// </summary>
        internal void ResetLeftPopupWindowFrameWidth()
        {
            this.Reset("LeftPopupWindowFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the right popup window frame.
        /// </summary>
        /// <value>The width of the right popup window frame.</value>
        [Category("Sizes"), Description("The width of the right popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int RightPopupWindowFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Right);
            }
        }

        /// <summary>
        /// Resets the width of the right popup window frame.
        /// </summary>
        internal void ResetRightPopupWindowFrameWidth()
        {
            this.Reset("RightPopupWindowFrameWidth");
        }

        /// <summary>
        /// Gets or sets the height of the top popup window frame.
        /// </summary>
        /// <value>The height of the top popup window frame.</value>
        [Category("Sizes"), Description("The height of the top popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int TopPopupWindowFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Top);
            }
        }

        /// <summary>
        /// Resets the height of the top popup window frame.
        /// </summary>
        internal void ResetTopPopupWindowFrameHeight()
        {
            this.Reset("TopPopupWindowFrameHeight");
        }

        /// <summary>
        /// Gets or sets the height of the bottom popup window frame.
        /// </summary>
        /// <value>The height of the bottom popup window frame.</value>
        [Category("Sizes"), Description("The height of the bottom popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int BottomPopupWindowFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.PopupWindowStyle, FrameEdge.Bottom);
            }
        }

        /// <summary>
        /// Resets the height of the bottom popup window frame.
        /// </summary>
        internal void ResetBottomPopupWindowFrameHeight()
        {
            this.Reset("BottomPopupWindowFrameHeight");
        }

        /// <summary>
        /// Gets the opup window style.
        /// </summary>
        /// <value>The opup window style.</value>
        [Category("States"), Description("The popup window style.")]
        public FrameStyleValue PopupWindowStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomPopupWindowStyle,
                    this.LeftPopupWindowStyle,
                    this.LeftTopPopupWindowStyle,
                    this.TopPopupWindowStyle,
                    this.RightTopPopupWindowStyle,
                    this.RightPopupWindowStyle,
                    this.RightBottomPopupWindowStyle,
                    this.BottomPopupWindowStyle,
                    this.CenterPopupWindowStyle);
            }
        }


        /// <summary>
        /// Gets the center popup window style.
        /// </summary>
        /// <value>The center popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterPopupWindowStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterPopupWindowStyle", this.PopupSkin.CenterStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left popup window style.
        /// </summary>
        /// <value>The left popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftPopupWindowStyle", this.PopupSkin.LeftStyle, true);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the top popup window style.
        /// </summary>
        /// <value>The top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopPopupWindowStyle", this.PopupSkin.TopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom popup window style.
        /// </summary>
        /// <value>The bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomPopupWindowStyle", this.PopupSkin.BottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right popup window style.
        /// </summary>
        /// <value>The right popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightPopupWindowStyle", this.PopupSkin.RightStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top popup window style.
        /// </summary>
        /// <value>The right top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopPopupWindowStyle", this.PopupSkin.RightTopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top popup window style.
        /// </summary>
        /// <value>The left top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopPopupWindowStyle", this.PopupSkin.LeftTopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom popup window style.
        /// </summary>
        /// <value>The left bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomPopupWindowStyle", this.PopupSkin.LeftBottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom popup window style.
        /// </summary>
        /// <value>The right bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomPopupWindowStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomPopupWindowStyle", this.PopupSkin.RightBottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the popups skin.
        /// </summary>
        /// <value>The popups skin.</value>
        private PopupsSkin PopupSkin
        {
            get
            {
                return SkinFactory.GetSkin(this.Owner, typeof(PopupsSkin),true) as PopupsSkin;
            }
        }

        #endregion

        #region Control Skin ovrride properties

        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BackgroundValue Background
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.BackColor;
                objBackgroundValue.BackgroundImage = this.BackgroundImage;
                objBackgroundValue.BackgroundImagePosition = this.BackgroundImagePosition;
                objBackgroundValue.BackgroundImageRepeat = this.BackgroundImageRepeat;
                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageResourceReference BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image repeat.
        /// </summary>
        /// <value>The background image repeat.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BackgroundImageRepeat BackgroundImageRepeat
        {
            get
            {
                return base.BackgroundImageRepeat;
            }
            set
            {
                base.BackgroundImageRepeat = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>The background image position.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BackgroundImagePosition BackgroundImagePosition
        {
            get
            {
                return base.BackgroundImagePosition;
            }
            set
            {
                base.BackgroundImagePosition = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderWidth BorderWidth
        {
            get
            {
                return this.GetValue<BorderWidth>("BorderWidth", new BorderWidth(0));
            }
            set
            {
                this.SetValue("BorderWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderColor BorderColor
        {
            get
            {
                return this.GetValue<BorderColor>("BorderColor", new BorderColor(Color.Black));
            }
            set
            {
                this.SetValue("BorderColor", value);
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets the fore color.
        /// </summary>
        /// <value></value>
        /// <remarks>ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <value>The space between controls.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override MarginValue Margin
        {
            get
            {
                return base.Margin;
            }
            set
            {
                base.Margin = value;
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value>The control padding.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override PaddingValue Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }
        #endregion       

        private void InitializeComponent()
        {

        }


    }
}
