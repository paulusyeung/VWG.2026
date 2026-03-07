using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms
{
    public class ToolStripDropDownSkin : ToolStripSkin
    {
        /// <summary>
        /// Gets or sets the width of the popup window offset.
        /// </summary>
        /// <value>The width of the popup window offset.</value>
        [Category("Sizes"), Description("The offset width for the popup window.")]
        public virtual int DropDownOffsetWidth
        {
            get
            {
                return this.GetValue<int>("DropDownOffsetWidth", this.DefaultDropDownOffsetWidth);
            }
            set
            {
                this.SetValue("DropDownOffsetWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the popup window offset.
        /// </summary>
        private void ResetDropDownOffsetWidth()
        {
            this.Reset("DropDownOffsetWidth");
        }

        /// <summary>
        /// Gets the default width of the popup window offset.
        /// </summary>
        /// <value>The default width of the popup window offset.</value>
        protected virtual int DefaultDropDownOffsetWidth
        {
            get
            {
                int intDefaultWidth = this.DropDownStyle.CenterStyle.BorderWidth.Left + this.DropDownStyle.CenterStyle.BorderWidth.Right
                    + this.DropDownStyle.CenterStyle.Padding.Horizontal;

                if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null)
                {
                    if ((HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
                    {
                        return intDefaultWidth;
                    }
                }

                return intDefaultWidth + this.RightDropDownFrameWidth + this.LeftDropDownFrameWidth;
            }
        }

        /// <summary>
        /// Gets or sets the height of the popup window offset.
        /// </summary>
        /// <value>The height of the popup window offset.</value>
        [Category("Sizes"), Description("The offset height for the popup window.")]
        public virtual int DropDownOffsetHeight
        {
            get
            {
                return this.GetValue<int>("DropDownOffsetHeight", this.DefaultDropDownOffsetHeight);
            }
            set
            {
                this.SetValue("DropDownOffsetHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the popup window offset.
        /// </summary>
        private void ResetDropDownOffsetHeight()
        {
            this.Reset("DropDownOffsetHeight");
        }

        /// <summary>
        /// Gets the default height of the popup window offset.
        /// </summary>
        /// <value>The default height of the popup window offset.</value>
        protected virtual int DefaultDropDownOffsetHeight
        {
            get
            {
                int intDefaultHeight = this.DropDownStyle.CenterStyle.BorderWidth.Top + this.DropDownStyle.CenterStyle.BorderWidth.Bottom
                    + this.DropDownStyle.CenterStyle.Padding.Vertical;

                if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null)
                {
                    if ((HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
                    {
                        return intDefaultHeight;
                    }
                }

                return intDefaultHeight + this.TopDropDownFrameHeight + this.BottomDropDownFrameHeight;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left popup window frame.
        /// </summary>
        /// <value>The width of the left popup window frame.</value>
        [Category("Sizes"), Description("The width of the left popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int LeftDropDownFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.DropDownStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Resets the width of the left popup window frame.
        /// </summary>
        internal void ResetLeftDropDownFrameWidth()
        {
            this.Reset("LeftDropDownFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the right popup window frame.
        /// </summary>
        /// <value>The width of the right popup window frame.</value>
        [Category("Sizes"), Description("The width of the right popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int RightDropDownFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.DropDownStyle, FrameEdge.Right);
            }
        }

        /// <summary>
        /// Resets the width of the right popup window frame.
        /// </summary>
        internal void ResetRightDropDownFrameWidth()
        {
            this.Reset("RightDropDownFrameWidth");
        }

        /// <summary>
        /// Gets or sets the height of the top popup window frame.
        /// </summary>
        /// <value>The height of the top popup window frame.</value>
        [Category("Sizes"), Description("The height of the top popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int TopDropDownFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.DropDownStyle, FrameEdge.Top);
            }
        }

        /// <summary>
        /// Resets the height of the top popup window frame.
        /// </summary>
        internal void ResetTopDropDownFrameHeight()
        {
            this.Reset("TopDropDownFrameHeight");
        }

        /// <summary>
        /// Gets or sets the height of the bottom popup window frame.
        /// </summary>
        /// <value>The height of the bottom popup window frame.</value>
        [Category("Sizes"), Description("The height of the bottom popup window frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int BottomDropDownFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.DropDownStyle, FrameEdge.Bottom);
            }
        }

        /// <summary>
        /// Resets the height of the bottom popup window frame.
        /// </summary>
        internal void ResetBottomDropDownFrameHeight()
        {
            this.Reset("BottomDropDownFrameHeight");
        }

        /// <summary>
        /// Gets the opup window style.
        /// </summary>
        /// <value>The opup window style.</value>
        [Category("States"), Description("The popup window style.")]
        public FrameStyleValue DropDownStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomDropDownStyle,
                    this.LeftDropDownStyle,
                    this.LeftTopDropDownStyle,
                    this.TopDropDownStyle,
                    this.RightTopDropDownStyle,
                    this.RightDropDownStyle,
                    this.RightBottomDropDownStyle,
                    this.BottomDropDownStyle,
                    this.CenterDropDownStyle);
            }
        }


        /// <summary>
        /// Gets the center popup window style.
        /// </summary>
        /// <value>The center popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterDropDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterDropDownStyle", this.PopupSkin.CenterStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left popup window style.
        /// </summary>
        /// <value>The left popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftDropDownStyle", this.PopupSkin.LeftStyle, true);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the top popup window style.
        /// </summary>
        /// <value>The top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopDropDownStyle", this.PopupSkin.TopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom popup window style.
        /// </summary>
        /// <value>The bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomDropDownStyle", this.PopupSkin.BottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right popup window style.
        /// </summary>
        /// <value>The right popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightDropDownStyle", this.PopupSkin.RightStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top popup window style.
        /// </summary>
        /// <value>The right top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopDropDownStyle", this.PopupSkin.RightTopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top popup window style.
        /// </summary>
        /// <value>The left top popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopDropDownStyle", this.PopupSkin.LeftTopStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom popup window style.
        /// </summary>
        /// <value>The left bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomDropDownStyle", this.PopupSkin.LeftBottomStyle, true);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom popup window style.
        /// </summary>
        /// <value>The right bottom popup window style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomDropDownStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomDropDownStyle", this.PopupSkin.RightBottomStyle, true);
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
                return SkinFactory.GetSkin(this.Owner, typeof(PopupsSkin), true) as PopupsSkin;
            }
        }

        private void InitializeComponent()
        {

        } 
    }
}
