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
    /// ToolStrip Skin
    /// </summary>
    [Serializable()]    
    [SkinDependency(typeof(ToolStripButtonSkin)), SkinDependency(typeof(ToolStripDropDownButtonSkin)), SkinDependency(typeof(ToolStripLabelSkin)), SkinDependency(typeof(ToolStripSeparatorSkin)), SkinDependency(typeof(ToolStripSplitButtonSkin)), SkinDependency(typeof(ToolStripControlHostSkin)), SkinDependency(typeof(ToolStripMenuItemSkin)), SkinDependency(typeof(ToolStripDropDownSkin)), SkinDependency(typeof(ToolStripDropDownContentPanelSkin))]
    public class ToolStripSkin : ControlSkin
    {
        internal const int IMAGE_SCALING_SIZE = 16;
        private void InitializeComponent()
        {

        }

        #region Niner Styles

        /// <summary>
        /// Gets the frame frame style.
        /// </summary>
        /// <value>The frame frame style.</value>
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int TopFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Top);
            }
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("The width of the right frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int RightFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Right);
            }
        }

        /// <summary>
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Category("Sizes"), Description("The height of the bottom frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int BottomFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Bottom);
            }
        }

        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("The width of the left frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int LeftFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Gets the frame left top style.
        /// </summary>
        /// <value>The frame left top style.</value>
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
        /// Gets the frame top style.
        /// </summary>
        /// <value>The frame top style.</value>
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
        /// Gets the frame right top style.
        /// </summary>
        /// <value>The frame right top style.</value>
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
        /// Gets the frame left style.
        /// </summary>
        /// <value>The frame left style.</value>
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
        /// Gets the frame right style.
        /// </summary>
        /// <value>The frame right style.</value>
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
        /// Gets the frame left bottom style.
        /// </summary>
        /// <value>The frame left bottom style.</value>
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
        /// Gets the frame bottom style.
        /// </summary>
        /// <value>The frame bottom style.</value>
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
        /// Gets the frame right bottom style.
        /// </summary>
        /// <value>The frame right bottom style.</value>
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

        #endregion

        #region ToolStrip DropDown Styles

        /// <summary>
        /// Gets the horizontal drop down button style.
        /// </summary>
        /// <value>The horizontal drop down button style.</value>
        public StyleValue HorizontalDropDownButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HorizontalDropDownButtonStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the vertical drop down button style.
        /// </summary>
        /// <value>The vertical drop down button style.</value>
        public StyleValue VerticalDropDownButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "VerticalDropDownButtonStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the width of the horizontal drop down button.
        /// </summary>
        /// <value>The width of the horizontal drop down button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalDropDownButtonWidth
        {
            get
            {
                return this.GetImageWidth(this.HorizontalDropDownButtonStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the height of the vertical drop down button.
        /// </summary>
        /// <value>The height of the vertical drop down button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalDropDownButtonHeight
        {
            get
            {
                return this.GetImageHeight(this.VerticalDropDownButtonStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the vertical grip style.
        /// </summary>
        /// <value>The vertical grip style.</value>
        public StyleValue VerticalGripStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "VerticalGripStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the horizontal grip style.
        /// </summary>
        /// <value>The horizontal grip style.</value>
        public StyleValue HorizontalGripStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HorizontalGripStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the width of the drop down button.
        /// </summary>
        /// <value>The width of the drop down button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalGripWidth
        {
            get
            {
                return this.GetImageWidth(this.HorizontalGripStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the height of the vertical grip.
        /// </summary>
        /// <value>The height of the vertical grip.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalGripHeight
        {
            get
            {
                return this.GetImageHeight(this.VerticalGripStyle.BackgroundImage);
            }
        }

        #endregion

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
                return this.RightPopupWindowFrameWidth + this.LeftPopupWindowFrameWidth;
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
                int intDefaultHeight = CenterPopupWindowStyle.BorderWidth.Top + this.CenterPopupWindowStyle.BorderWidth.Bottom + CenterPopupWindowStyle.Padding.Vertical;

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
                return SkinFactory.GetSkin(this.Owner, typeof(PopupsSkin), true) as PopupsSkin;
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the size of the image scaling.
        /// </summary>
        /// <value>
        /// The size of the image scaling.
        /// </value>
        public Size ImageScalingSize
        {
            get
            {
                return this.GetValue<Size>("ImageScalingSize", new Size(IMAGE_SCALING_SIZE, IMAGE_SCALING_SIZE));
            }
            set
            {
                this.SetValue("ImageScalingSize", value);
            }
        }
    }
}
