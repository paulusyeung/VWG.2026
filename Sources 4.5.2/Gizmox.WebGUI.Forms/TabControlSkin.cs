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
    /// TabControl Skin
    /// </summary>
    [ToolboxBitmap(typeof(TabControl), "TabControl.bmp"), Serializable()]
    [SkinDependency(typeof(TabPageSkin))]
    public class TabControlSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        #region Right Scroll Button Styles


        /// <summary>
        /// Gets the right scroll button normal style.
        /// </summary>
        /// <value>The right scroll button normal style.</value>
        [Category("States"), Description("The right scroll button normal style.")]
        public virtual StyleValue RightScrollButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightScrollButtonNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right scroll button hover style.
        /// </summary>
        /// <value>The right scroll button hover style.</value>
        [Category("States"), Description("The right scroll button hover style.")]
        public virtual StyleValue RightScrollButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightScrollButtonHoverStyle", this.RightScrollButtonNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right scroll button pressed style.
        /// </summary>
        /// <value>The right scroll button pressed style.</value>
        [Category("States"), Description("The right scroll button pressed style.")]
        public virtual StyleValue RightScrollButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightScrollButtonPressedStyle", this.RightScrollButtonNormalStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets or sets the size of the right scroll button.
        /// </summary>
        /// <value>The size of the right scroll button.</value>
        [Category("Sizes"), Description("The size of the right scroll button.")]
        public virtual Size RightScrollButtonSize
        {
            get
            {
                return this.GetValue<Size>("RightScrollButtonSize", this.GetImageSize(this.RightScrollButtonNormalStyle.BackgroundImage, this.DefaultRightScrollButtonSize));
            }
            set
            {
                this.SetValue("RightScrollButtonSize", value);
            }
        }

        /// <summary>
        /// Gets the default size of the right scroll button.
        /// </summary>
        /// <value>The default size of the right scroll button.</value>
        protected virtual Size DefaultRightScrollButtonSize
        {
            get
            {
                return new Size(16, 16);
            }
        }

        /// <summary>
        /// Resets the size of the right scroll button.
        /// </summary>
        private void ResetRightScrollButtonSize()
        {
            this.Reset("RightScrollButtonSize");
        }


        /// <summary>
        /// Gets the width of the right scroll button.
        /// </summary>
        /// <value>The width of the right scroll button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightScrollButtonWidth
        {
            get
            {
                return this.RightScrollButtonSize.Width;
            }
        }


        /// <summary>
        /// Gets the height of the right scroll button.
        /// </summary>
        /// <value>The height of the right scroll button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightScrollButtonHeight
        {
            get
            {
                return this.RightScrollButtonSize.Height;
            }
        }


        #endregion

        #region Left Scroll Button Styles


        /// <summary>
        /// Gets the left scroll button normal style.
        /// </summary>
        /// <value>The left scroll button normal style.</value>
        [Category("States"), Description("The left scroll button normal style.")]
        public virtual StyleValue LeftScrollButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftScrollButtonNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left scroll button hover style.
        /// </summary>
        /// <value>The left scroll button hover style.</value>
        [Category("States"), Description("The left scroll button hover style.")]
        public virtual StyleValue LeftScrollButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftScrollButtonHoverStyle", this.LeftScrollButtonNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left scroll button pressed style.
        /// </summary>
        /// <value>The left scroll button pressed style.</value>
        [Category("States"), Description("The left scroll button pressed style.")]
        public virtual StyleValue LeftScrollButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftScrollButtonPressedStyle", this.LeftScrollButtonNormalStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets or sets the size of the left scroll button.
        /// </summary>
        /// <value>The size of the left scroll button.</value>
        [Category("Sizes"), Description("The size of the left scroll button.")]
        public virtual Size LeftScrollButtonSize
        {
            get
            {
                return this.GetValue<Size>("LeftScrollButtonSize", this.GetImageSize(this.LeftScrollButtonNormalStyle.BackgroundImage, this.DefaultLeftScrollButtonSize));
            }
            set
            {
                this.SetValue("LeftScrollButtonSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the left scroll button.
        /// </summary>
        private void ResetLeftScrollButtonSize()
        {
            this.Reset("LeftScrollButtonSize");
        }

        /// <summary>
        /// Gets the default size of the left scroll button.
        /// </summary>
        /// <value>The default size of the left scroll button.</value>
        protected virtual Size DefaultLeftScrollButtonSize
        {
            get
            {
                return new Size(16, 16);
            }
        }


        /// <summary>
        /// Gets the width of the left scroll button.
        /// </summary>
        /// <value>The width of the left scroll button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftScrollButtonWidth
        {
            get
            {
                return this.LeftScrollButtonSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the left scroll button.
        /// </summary>
        /// <value>The height of the left scroll button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftScrollButtonHeight
        {
            get
            {
                return this.LeftScrollButtonSize.Height;
            }
        }

        #endregion

        #region Bidirectional Styles


        /// <summary>
        /// Gets the bidirectional right scroll button normal style.
        /// </summary>
        /// <value>The bidirectional right scroll button normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> BidirectionalRightScrollButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightScrollButtonNormalStyle, this.LeftScrollButtonNormalStyle);
            }
        }

        /// <summary>
        /// Gets the bidirectional left scroll button normal style.
        /// </summary>
        /// <value>The bidirectional left scroll button normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> BidirectionalLeftScrollButtonNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftScrollButtonNormalStyle, this.RightScrollButtonNormalStyle);
            }
        }





        /// <summary>
        /// Gets the bidirectional left scroll button hover style.
        /// </summary>
        /// <value>The bidirectional left scroll button hover style.</value>
        public BidirectionalSkinValue<StyleValue> BidirectionalLeftScrollButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftScrollButtonHoverStyle, this.RightScrollButtonHoverStyle);
            }
        }


        /// <summary>
        /// Gets the bidirectional left scroll button pressed style.
        /// </summary>
        /// <value>The bidirectional left scroll button pressed style.</value>
        public BidirectionalSkinValue<StyleValue> BidirectionalLeftScrollButtonPressedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftScrollButtonPressedStyle, this.RightScrollButtonPressedStyle);
            }
        }

        /// <summary>
        /// Gets the bidirectional right scroll button hover style.
        /// </summary>
        /// <value>The bi directional right scroll button hover style.</value>
        public BidirectionalSkinValue<StyleValue> BidirectionalRightScrollButtonHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightScrollButtonHoverStyle, this.LeftScrollButtonHoverStyle);
            }
        }

        /// <summary>
        /// Gets the bidirectional right scroll button pressed style.
        /// </summary>
        /// <value>The bidirectional right scroll button pressed style.</value>
        public BidirectionalSkinValue<StyleValue> BidirectionalRightScrollButtonPressedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightScrollButtonPressedStyle, this.LeftScrollButtonPressedStyle);
            }
        }

        #endregion Bidirectional Styles

        #region Tab Styles

        /// <summary>
        /// Gets the SpreadTabHeaderTextColumn style.
        /// </summary>
        [Category("Styles"), Description("The SpreadTabHeaderTextColumn style.")]
        public virtual StyleValue SpreadTabHeaderTextColumnStyle
        {
            get
            {
                return new StyleValue(this, "SpreadTabHeaderTextColumnStyle");
            }
        }

        /// <summary>
        /// Resets the SpreadTabHeaderTextColumn.
        /// </summary>
        internal void ResetSpreadTabHeaderTextColumnStyle()
        {
            this.Reset("SpreadTabHeaderTextColumnStyle");
        }

        /// <summary>
        /// Gets or sets the initial start point of the tabs.
        /// </summary>
        /// <value>The initial start point of the tabs.</value>
        [Category("Sizes"), Description("The initial start point of the tabs.")]
        public virtual int HeadersOffset
        {
            get
            {
                return this.GetValue<int>("HeadersOffset", this.DefaultHeadersOffset);
            }
            set
            {
                this.SetValue("HeadersOffset", value);
            }
        }

        #region Top

        /// <summary>
        /// Gets the tab top normal style.
        /// </summary>
        /// <value>The tab top normal style.</value>
        public BidirectionalSkinValue<TripleCellFrameStyleValue> TabTopNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.TabTopNormalLTRStyle, this.TabTopNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tab top normal style.
        /// </summary>
        /// <value>The tab top normal style.</value>
        public BidirectionalSkinValue<StyleValue> TabTopNormalSpreadStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTabTopNormalLTRSpreadStyle, this.CenterTabTopNormalRTLSpreadStyle);
            }
        }

        /// <summary>
        /// Gets the tab top normal LTR spread style.
        /// </summary>
        [Category("States"), Description("The top tab normal spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabTopNormalLTRSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabTopNormalLTRSpreadStyle", this.CenterBottomTabNormalLTRStyle);
            }
        }

        /// <summary>
        /// Gets the tab top normal RTL spread style.
        /// </summary>
        [Category("States"), Description("The top tab normal spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabTopNormalRTLSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabTopNormalRTLSpreadStyle");
            }
        }

        /// <summary>
        /// Gets the top tab normal style.
        /// </summary>
        /// <value>The top tab normal style.</value>
        [Category("States"), Description("The top tab normal LTR style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabTopNormalLTRStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftTopTabNormalLTRStyle,
                    this.RightTopTabNormalLTRStyle,
                    this.CenterTopTabNormalLTRStyle);
            }
        }

        /// <summary>
        /// Gets the tab top normal RTL style.
        /// </summary>
        /// <value>The tab top normal RTL style.</value>
        [Category("States"), Description("The top tab normal RTL style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabTopNormalRTLStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftTopTabNormalRTLStyle,
                    this.RightTopTabNormalRTLStyle,
                    this.CenterTopTabNormalRTLStyle);
            }
        }


        /// <summary>
        /// Gets the tab top selected style.
        /// </summary>
        /// <value>The tab top selected style.</value>
        public BidirectionalSkinValue<TripleCellFrameStyleValue> TabTopSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.TabTopSelectedLTRStyle, this.TabTopSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tab top Selected style.
        /// </summary>
        /// <value>The tab top Selected style.</value>
        public BidirectionalSkinValue<StyleValue> TabTopSelectedSpreadStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTabTopSelectedLTRSpreadStyle, this.CenterTabTopSelectedRTLSpreadStyle);
            }
        }

        /// <summary>
        /// Gets the tab top selected LTR spread style.
        /// </summary>
        [Category("States"), Description("The top tab selected spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabTopSelectedLTRSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabTopSelectedLTRSpreadStyle", this.TabPageHeaderSelectedStyle);
            }
        }

        /// <summary>
        /// Gets the tab top selected LTR spread style.
        /// </summary>
        [Category("States"), Description("The top tab selected  spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabTopSelectedRTLSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabTopSelectedRTLSpreadStyle", this.TabPageHeaderSelectedStyle);
            }
        }

        /// <summary>
        /// Gets the top tab selected style.
        /// </summary>
        /// <value>The top tab selected style.</value>
        [Category("States"), Description("The top tab selected style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabTopSelectedLTRStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftTopTabSelectedLTRStyle,
                    this.RightTopTabSelectedLTRStyle,
                    this.CenterTopTabSelectedLTRStyle);
            }
        }

        /// <summary>
        /// Gets the tab top selected RTL style.
        /// </summary>
        /// <value>The tab top selected RTL style.</value>
        [Category("States"), Description("The top tab selected style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabTopSelectedRTLStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftTopTabSelectedRTLStyle,
                    this.RightTopTabSelectedRTLStyle,
                    this.CenterTopTabSelectedRTLStyle);
            }
        }


        /// <summary>
        /// Gets the tab top hover style.
        /// </summary>
        /// <value>The tab top hover style.</value>
        public BidirectionalSkinValue<TripleCellFrameStyleValue> TabTopHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.TabTopHoverLTRStyle, this.TabTopHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tab top Hover style.
        /// </summary>
        /// <value>The tab top Hover style.</value>
        public BidirectionalSkinValue<StyleValue> TabTopHoverSpreadStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTabTopHoverLTRSpreadStyle, this.CenterTabTopHoverRTLSpreadStyle);
            }
        }

        /// <summary>
        /// Gets the tab top hover LTR spread style.
        /// </summary>
        [Category("States"), Description("The top tab hover spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabTopHoverLTRSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabTopHoverLTRSpreadStyle");
            }
        }

        /// <summary>
        /// Gets the tab top hover RTL spread style.
        /// </summary>
        [Category("States"), Description("The top tab hover spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabTopHoverRTLSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabTopHoverRTLSpreadStyle");
            }
        }

        /// <summary>
        /// Gets the top tab hover style.
        /// </summary>
        /// <value>The top tab hover style.</value>
        [Category("States"), Description("The top tab hover style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabTopHoverLTRStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftTopTabHoverLTRStyle,
                    this.RightTopTabHoverLTRStyle,
                    this.CenterTopTabHoverLTRStyle);
            }
        }


        /// <summary>
        /// Gets the top tab hover style.
        /// </summary>
        /// <value>The top tab hover style.</value>
        [Category("States"), Description("The top tab hover style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabTopHoverRTLStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftTopTabHoverRTLStyle,
                    this.RightTopTabHoverRTLStyle,
                    this.CenterTopTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the right tab normal style.
        /// </summary>
        /// <value>The right tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightTopTabNormalLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightTopTabNormalLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top tab normal RTL style.
        /// </summary>
        /// <value>The right top tab normal RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightTopTabNormalRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightTopTabNormalRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top tab normal style.
        /// </summary>
        /// <value>The right top tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> RightTopTabNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightTopTabNormalLTRStyle, this.RightTopTabNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the right tab selected style.
        /// </summary>
        /// <value>The right tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightTopTabSelectedLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightTopTabSelectedLTRStyle", this.RightTopTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top tab selected RTL style.
        /// </summary>
        /// <value>The right top tab selected RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightTopTabSelectedRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightTopTabSelectedRTLStyle", this.RightTopTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top tab selected style.
        /// </summary>
        /// <value>The right top tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> RightTopTabSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightTopTabSelectedLTRStyle, this.RightTopTabSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the right tab hover style.
        /// </summary>
        /// <value>The right tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightTopTabHoverLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightTopTabHoverLTRStyle", this.RightTopTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top tab hover RTL style.
        /// </summary>
        /// <value>The right top tab hover RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightTopTabHoverRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightTopTabHoverRTLStyle", this.RightTopTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top tab hover style.
        /// </summary>
        /// <value>The right top tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> RightTopTabHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightTopTabHoverLTRStyle, this.RightTopTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the left tab normal style.
        /// </summary>
        /// <value>The left tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftTopTabNormalLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftTopTabNormalLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top tab normal RTL style.
        /// </summary>
        /// <value>The left top tab normal RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftTopTabNormalRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftTopTabNormalRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top tab normal style.
        /// </summary>
        /// <value>The left top tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> LeftTopTabNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftTopTabNormalLTRStyle, this.LeftTopTabNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the left tab selected style.
        /// </summary>
        /// <value>The left tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftTopTabSelectedLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftTopTabSelectedLTRStyle", this.LeftTopTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top tab selected RTL style.
        /// </summary>
        /// <value>The left top tab selected RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftTopTabSelectedRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftTopTabSelectedRTLStyle", this.LeftTopTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top tab selected style.
        /// </summary>
        /// <value>The left top tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> LeftTopTabSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftTopTabSelectedLTRStyle, this.LeftTopTabSelectedLTRStyle);
            }
        }

        /// <summary>
        /// Gets the left tab hover style.
        /// </summary>
        /// <value>The left tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftTopTabHoverLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftTopTabHoverLTRStyle", this.LeftTopTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top tab hover RTL style.
        /// </summary>
        /// <value>The left top tab hover RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftTopTabHoverRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftTopTabHoverRTLStyle", this.LeftTopTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top tab hover style.
        /// </summary>
        /// <value>The left top tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> LeftTopTabHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftTopTabHoverLTRStyle, this.LeftTopTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets or sets the width of the left tab top in LTR.
        /// </summary>
        /// <value>The width of the left tab top in LTR.</value>
        [Category("Sizes"), Description("The width of the left tab top in LTR.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftTopTabWidthLTR
        {
            get
            {
                return this.GetValue<int>("LeftTopTabWidthLTR", this.GetImageWidth(this.LeftTopTabNormalLTRStyle.BackgroundImage, this.DefaultLeftTopTabWidthLTR));
            }
            set
            {
                this.SetValue("LeftTopTabWidthLTR", value);
            }
        }

        /// <summary>
        /// Resets the width of the left tab top in LTR.
        /// </summary>
        internal void ResetLeftTopTabWidthLTR()
        {
            this.Reset("LeftTopTabWidthLTR");
        }

        /// <summary>
        /// Gets the default width of the left tab top in LTR.
        /// </summary>
        /// <value>The default width of the left tab top in LTR.</value>
        protected virtual int DefaultLeftTopTabWidthLTR
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left tab top in RTL.
        /// </summary>
        /// <value>The width of the left tab top in RTL.</value>
        [Category("Sizes"), Description("The width of the left tab top in RTL.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftTopTabWidthRTL
        {
            get
            {
                return this.GetValue<int>("LeftTopTabWidthRTL", this.GetImageWidth(this.LeftTopTabNormalRTLStyle.BackgroundImage, this.DefaultLeftTopTabWidthRTL));
            }
            set
            {
                this.SetValue("LeftTopTabWidthRTL", value);
            }
        }

        /// <summary>
        /// Resets the width of the left tab top in RTL.
        /// </summary>
        internal void ResetLeftTopTabWidthRTL()
        {
            this.Reset("LeftTopTabWidthRTL");
        }

        /// <summary>
        /// Gets the default width of the left tab top in RTL.
        /// </summary>
        /// <value>The default width of the left tab top in RTL.</value>
        protected virtual int DefaultLeftTopTabWidthRTL
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the width of the left top tab.
        /// </summary>
        /// <value>The width of the left top tab.</value>       
        public BidirectionalSkinProperty<int> LeftTopTabWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "LeftTopTabWidthLTR", "LeftTopTabWidthRTL");
            }
        }

        /// <summary>
        /// Gets or sets the width of the right tab top in LTR.
        /// </summary>
        /// <value>The width of the right tab top in LTR.</value>
        [Category("Sizes"), Description("The width of the right tab top in LTR.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightTopTabWidthLTR
        {
            get
            {
                return this.GetValue<int>("RightTopTabWidthLTR", this.GetImageWidth(this.RightTopTabNormalLTRStyle.BackgroundImage, this.DefaultRightTopTabWidthLTR));
            }
            set
            {
                this.SetValue("RightTopTabWidthLTR", value);
            }
        }

        /// <summary>
        /// Gets the default width of the right tab top in LTR.
        /// </summary>
        /// <value>The default width of the right tab top in LTR.</value>
        protected virtual int DefaultRightTopTabWidthLTR
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Resets the width of the right tab top in LTR.
        /// </summary>
        internal void ResetRightTopTabWidthLTR()
        {
            this.Reset("RightTopTabWidthLTR");
        }

        /// <summary>
        /// Gets the width of the right top tab.
        /// </summary>
        /// <value>The width of the right top tab.</value>
        public BidirectionalSkinProperty<int> RightTopTabWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "RightTopTabWidthLTR", "RightTopTabWidthRTL");
            }
        }

        /// <summary>
        /// Gets or sets the width of the right tab top in RTL.
        /// </summary>
        /// <value>The width of the right tab top in RTL.</value>
        [Category("Sizes"), Description("The width of the right tab top in RTL.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightTopTabWidthRTL
        {
            get
            {
                return this.GetValue<int>("RightTopTabWidthRTL", this.GetImageWidth(this.RightTopTabNormalRTLStyle.BackgroundImage, this.DefaultRightTopTabWidthRTL));
            }
            set
            {
                this.SetValue("RightTopTabWidthRTL", value);
            }
        }

        /// <summary>
        /// Gets the default width of the right tab top in RTL.
        /// </summary>
        /// <value>The default width of the right tab top in RTL.</value>
        protected virtual int DefaultRightTopTabWidthRTL
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Resets the width of the right tab top in RTL.
        /// </summary>
        internal void ResetRightTopTabWidthRTL()
        {
            this.Reset("RightTopTabWidthRTL");
        }

        /// <summary>
        /// Gets the center tab normal style.
        /// </summary>
        /// <value>The center tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTopTabNormalLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterTopTabNormalLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center top tab normal RTL style.
        /// </summary>
        /// <value>The center top tab normal RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTopTabNormalRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterTopTabNormalRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center top tab normal style.
        /// </summary>
        /// <value>The center top tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> CenterTopTabNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTopTabNormalLTRStyle, this.CenterTopTabNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the center tab selected style.
        /// </summary>
        /// <value>The center tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTopTabSelectedLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterTopTabSelectedLTRStyle", this.CenterTopTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center top tab selected RTL style.
        /// </summary>
        /// <value>The center top tab selected RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTopTabSelectedRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterTopTabSelectedRTLStyle", this.CenterTopTabNormalRTLStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the center top tab selected style.
        /// </summary>
        /// <value>The center top tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> CenterTopTabSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTopTabSelectedLTRStyle, this.CenterTopTabSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the center tab hover style.
        /// </summary>
        /// <value>The center tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTopTabHoverLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterTopTabHoverLTRStyle", this.CenterTopTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center top tab hover RTL style.
        /// </summary>
        /// <value>The center top tab hover RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTopTabHoverRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterTopTabHoverRTLStyle", this.CenterTopTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center top tab hover style.
        /// </summary>
        /// <value>The center top tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> CenterTopTabHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTopTabHoverLTRStyle, this.CenterTopTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tabs container style.
        /// </summary>
        /// <value>The tabs container style.</value>
        [Category("Styles"), Description("The top tab container style.")]
        public virtual StyleValue TabsTopContainerStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TabsTopContainerStyle");
                return objStyle;
            }
        }

        #endregion

        #region Bottom

        /// <summary>
        /// Gets the tab Bottom normal style.
        /// </summary>
        /// <value>The tab Bottom normal style.</value>
        public BidirectionalSkinValue<TripleCellFrameStyleValue> TabBottomNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.TabBottomNormalLTRStyle, this.TabBottomNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the Bottom tab normal style.
        /// </summary>
        /// <value>The Bottom tab normal style.</value>
        [Category("States"), Description("The Bottom tab normal LTR style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabBottomNormalLTRStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftBottomTabNormalLTRStyle,
                    this.RightBottomTabNormalLTRStyle,
                    this.CenterBottomTabNormalLTRStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom normal style.
        /// </summary>
        /// <value>The tab Bottom normal style.</value>
        public BidirectionalSkinValue<StyleValue> TabBottomNormalSpreadStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTabBottomNormalLTRSpreadStyle, this.CenterTabBottomNormalRTLSpreadStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom normal LTR spread style.
        /// </summary>
        [Category("States"), Description("The Bottom tab normal spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabBottomNormalLTRSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabBottomNormalLTRSpreadStyle", this.CenterBottomTabNormalLTRStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom normal RTL spread style.
        /// </summary>
        [Category("States"), Description("The Bottom tab normal spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabBottomNormalRTLSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabBottomNormalRTLSpreadStyle");
            }
        }

        /// <summary>
        /// Gets the tab Bottom normal RTL style.
        /// </summary>
        /// <value>The tab Bottom normal RTL style.</value>
        [Category("States"), Description("The Bottom tab normal RTL style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabBottomNormalRTLStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftBottomTabNormalRTLStyle,
                    this.RightBottomTabNormalRTLStyle,
                    this.CenterBottomTabNormalRTLStyle);
            }
        }


        /// <summary>
        /// Gets the tab Bottom selected style.
        /// </summary>
        /// <value>The tab Bottom selected style.</value>
        public BidirectionalSkinValue<TripleCellFrameStyleValue> TabBottomSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.TabBottomSelectedLTRStyle, this.TabBottomSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom Selected style.
        /// </summary>
        /// <value>The tab Bottom Selected style.</value>
        public BidirectionalSkinValue<StyleValue> TabBottomSelectedSpreadStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTabBottomSelectedLTRSpreadStyle, this.CenterTabBottomSelectedRTLSpreadStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom selected LTR spread style.
        /// </summary>
        [Category("States"), Description("The Bottom tab selected spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabBottomSelectedLTRSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabBottomSelectedLTRSpreadStyle", this.TabPageHeaderSelectedStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom selected LTR spread style.
        /// </summary>
        [Category("States"), Description("The Bottom tab selected  spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabBottomSelectedRTLSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabBottomSelectedRTLSpreadStyle", this.TabPageHeaderSelectedStyle);
            }
        }

        /// <summary>
        /// Gets the Bottom tab selected style.
        /// </summary>
        /// <value>The Bottom tab selected style.</value>
        [Category("States"), Description("The Bottom tab selected style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabBottomSelectedLTRStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftBottomTabSelectedLTRStyle,
                    this.RightBottomTabSelectedLTRStyle,
                    this.CenterBottomTabSelectedLTRStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom selected RTL style.
        /// </summary>
        /// <value>The tab Bottom selected RTL style.</value>
        [Category("States"), Description("The Bottom tab selected style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabBottomSelectedRTLStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftBottomTabSelectedRTLStyle,
                    this.RightBottomTabSelectedRTLStyle,
                    this.CenterBottomTabSelectedRTLStyle);
            }
        }


        /// <summary>
        /// Gets the tab Bottom hover style.
        /// </summary>
        /// <value>The tab Bottom hover style.</value>
        public BidirectionalSkinValue<TripleCellFrameStyleValue> TabBottomHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.TabBottomHoverLTRStyle, this.TabBottomHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom Hover style.
        /// </summary>
        /// <value>The tab Bottom Hover style.</value>
        public BidirectionalSkinValue<StyleValue> TabBottomHoverSpreadStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterTabBottomHoverLTRSpreadStyle, this.CenterTabBottomHoverRTLSpreadStyle);
            }
        }

        /// <summary>
        /// Gets the tab Bottom hover LTR spread style.
        /// </summary>
        [Category("States"), Description("The Bottom tab hover spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabBottomHoverLTRSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabBottomHoverLTRSpreadStyle");
            }
        }

        /// <summary>
        /// Gets the tab Bottom hover RTL spread style.
        /// </summary>
        [Category("States"), Description("The Bottom tab hover spread appearance style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterTabBottomHoverRTLSpreadStyle
        {
            get
            {
                return new StyleValue(this, "CenterTabBottomHoverRTLSpreadStyle");
            }
        }

        /// <summary>
        /// Gets the Bottom tab hover style.
        /// </summary>
        /// <value>The Bottom tab hover style.</value>
        [Category("States"), Description("The Bottom tab hover style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabBottomHoverLTRStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftBottomTabHoverLTRStyle,
                    this.RightBottomTabHoverLTRStyle,
                    this.CenterBottomTabHoverLTRStyle);
            }
        }


        /// <summary>
        /// Gets the Bottom tab hover style.
        /// </summary>
        /// <value>The Bottom tab hover style.</value>
        [Category("States"), Description("The Bottom tab hover style.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TripleCellFrameStyleValue TabBottomHoverRTLStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.LeftBottomTabHoverRTLStyle,
                    this.RightBottomTabHoverRTLStyle,
                    this.CenterBottomTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the right tab normal style.
        /// </summary>
        /// <value>The right tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightBottomTabNormalLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightBottomTabNormalLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right Bottom tab normal RTL style.
        /// </summary>
        /// <value>The right Bottom tab normal RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightBottomTabNormalRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightBottomTabNormalRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right Bottom tab normal style.
        /// </summary>
        /// <value>The right Bottom tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> RightBottomTabNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightBottomTabNormalLTRStyle, this.RightBottomTabNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the right tab selected style.
        /// </summary>
        /// <value>The right tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightBottomTabSelectedLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightBottomTabSelectedLTRStyle", this.RightBottomTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right Bottom tab selected RTL style.
        /// </summary>
        /// <value>The right Bottom tab selected RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightBottomTabSelectedRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightBottomTabSelectedRTLStyle", this.RightBottomTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right Bottom tab selected style.
        /// </summary>
        /// <value>The right Bottom tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> RightBottomTabSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightBottomTabSelectedLTRStyle, this.RightBottomTabSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the right tab hover style.
        /// </summary>
        /// <value>The right tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightBottomTabHoverLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightBottomTabHoverLTRStyle", this.RightBottomTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right Bottom tab hover RTL style.
        /// </summary>
        /// <value>The right Bottom tab hover RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightBottomTabHoverRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightBottomTabHoverRTLStyle", this.RightBottomTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right Bottom tab hover style.
        /// </summary>
        /// <value>The right Bottom tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> RightBottomTabHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.RightBottomTabHoverLTRStyle, this.RightBottomTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the left tab normal style.
        /// </summary>
        /// <value>The left tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftBottomTabNormalLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftBottomTabNormalLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left Bottom tab normal RTL style.
        /// </summary>
        /// <value>The left Bottom tab normal RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftBottomTabNormalRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftBottomTabNormalRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left Bottom tab normal style.
        /// </summary>
        /// <value>The left Bottom tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> LeftBottomTabNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftBottomTabNormalLTRStyle, this.LeftBottomTabNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the left tab selected style.
        /// </summary>
        /// <value>The left tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftBottomTabSelectedLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftBottomTabSelectedLTRStyle", this.LeftBottomTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left Bottom tab selected RTL style.
        /// </summary>
        /// <value>The left Bottom tab selected RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftBottomTabSelectedRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftBottomTabSelectedRTLStyle", this.LeftBottomTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left Bottom tab selected style.
        /// </summary>
        /// <value>The left Bottom tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> LeftBottomTabSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftBottomTabSelectedLTRStyle, this.LeftBottomTabSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the left tab hover style.
        /// </summary>
        /// <value>The left tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftBottomTabHoverLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftBottomTabHoverLTRStyle", this.LeftBottomTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left Bottom tab hover RTL style.
        /// </summary>
        /// <value>The left Bottom tab hover RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftBottomTabHoverRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftBottomTabHoverRTLStyle", this.LeftBottomTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left Bottom tab hover style.
        /// </summary>
        /// <value>The left Bottom tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> LeftBottomTabHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftBottomTabHoverLTRStyle, this.LeftBottomTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets or sets the width of the left tab Bottom in LTR.
        /// </summary>
        /// <value>The width of the left tab Bottom in LTR.</value>
        [Category("Sizes"), Description("The width of the left tab Bottom in LTR.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftBottomTabWidthLTR
        {
            get
            {
                return this.GetValue<int>("LeftBottomTabWidthLTR", this.GetImageWidth(this.LeftBottomTabNormalLTRStyle.BackgroundImage, this.DefaultLeftBottomTabWidthLTR));
            }
            set
            {
                this.SetValue("LeftBottomTabWidthLTR", value);
            }
        }

        /// <summary>
        /// Resets the width of the left tab Bottom in LTR.
        /// </summary>
        internal void ResetLeftBottomTabWidthLTR()
        {
            this.Reset("LeftBottomTabWidthLTR");
        }

        /// <summary>
        /// Gets the default width of the left tab Bottom in LTR.
        /// </summary>
        /// <value>The default width of the left tab Bottom in LTR.</value>
        protected virtual int DefaultLeftBottomTabWidthLTR
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left tab Bottom in RTL.
        /// </summary>
        /// <value>The width of the left tab Bottom in RTL.</value>
        [Category("Sizes"), Description("The width of the left tab Bottom in RTL.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftBottomTabWidthRTL
        {
            get
            {
                return this.GetValue<int>("LeftBottomTabWidthRTL", this.GetImageWidth(this.LeftBottomTabNormalRTLStyle.BackgroundImage, this.DefaultLeftBottomTabWidthRTL));
            }
            set
            {
                this.SetValue("LeftBottomTabWidthRTL", value);
            }
        }

        /// <summary>
        /// Resets the width of the left tab Bottom in RTL.
        /// </summary>
        internal void ResetLeftBottomTabWidthRTL()
        {
            this.Reset("LeftBottomTabWidthRTL");
        }

        /// <summary>
        /// Gets the default width of the left tab Bottom in RTL.
        /// </summary>
        /// <value>The default width of the left tab Bottom in RTL.</value>
        protected virtual int DefaultLeftBottomTabWidthRTL
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the width of the left Bottom tab.
        /// </summary>
        /// <value>The width of the left Bottom tab.</value>       
        public BidirectionalSkinProperty<int> LeftBottomTabWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "LeftBottomTabWidthLTR", "LeftBottomTabWidthRTL");
            }
        }

        /// <summary>
        /// Gets or sets the width of the right tab Bottom in LTR.
        /// </summary>
        /// <value>The width of the right tab Bottom in LTR.</value>
        [Category("Sizes"), Description("The width of the right tab Bottom in LTR.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightBottomTabWidthLTR
        {
            get
            {
                return this.GetValue<int>("RightBottomTabWidthLTR", this.GetImageWidth(this.RightBottomTabNormalLTRStyle.BackgroundImage, this.DefaultRightBottomTabWidthLTR));
            }
            set
            {
                this.SetValue("RightBottomTabWidthLTR", value);
            }
        }

        /// <summary>
        /// Gets the default width of the right tab Bottom in LTR.
        /// </summary>
        /// <value>The default width of the right tab Bottom in LTR.</value>
        protected virtual int DefaultRightBottomTabWidthLTR
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Resets the width of the right tab Bottom in LTR.
        /// </summary>
        internal void ResetRightBottomTabWidthLTR()
        {
            this.Reset("RightBottomTabWidthLTR");
        }

        /// <summary>
        /// Gets the width of the right Bottom tab.
        /// </summary>
        /// <value>The width of the right Bottom tab.</value>
        public BidirectionalSkinProperty<int> RightBottomTabWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "RightBottomTabWidthLTR", "RightBottomTabWidthRTL");
            }
        }

        /// <summary>
        /// Gets or sets the width of the right tab Bottom in RTL.
        /// </summary>
        /// <value>The width of the right tab Bottom in RTL.</value>
        [Category("Sizes"), Description("The width of the right tab Bottom in RTL.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightBottomTabWidthRTL
        {
            get
            {
                return this.GetValue<int>("RightBottomTabWidthRTL", this.GetImageWidth(this.RightBottomTabNormalRTLStyle.BackgroundImage, this.DefaultRightBottomTabWidthRTL));
            }
            set
            {
                this.SetValue("RightBottomTabWidthRTL", value);
            }
        }

        /// <summary>
        /// Gets the default width of the right tab Bottom in RTL.
        /// </summary>
        /// <value>The default width of the right tab Bottom in RTL.</value>
        protected virtual int DefaultRightBottomTabWidthRTL
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Resets the width of the right tab Bottom in RTL.
        /// </summary>
        internal void ResetRightBottomTabWidthRTL()
        {
            this.Reset("RightBottomTabWidthRTL");
        }

        /// <summary>
        /// Gets the center tab normal style.
        /// </summary>
        /// <value>The center tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterBottomTabNormalLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterBottomTabNormalLTRStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center Bottom tab normal RTL style.
        /// </summary>
        /// <value>The center Bottom tab normal RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterBottomTabNormalRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterBottomTabNormalRTLStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center Bottom tab normal style.
        /// </summary>
        /// <value>The center Bottom tab normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> CenterBottomTabNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterBottomTabNormalLTRStyle, this.CenterBottomTabNormalRTLStyle);
            }
        }

        /// <summary>
        /// Gets the center tab selected style.
        /// </summary>
        /// <value>The center tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterBottomTabSelectedLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterBottomTabSelectedLTRStyle", this.CenterBottomTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center Bottom tab selected RTL style.
        /// </summary>
        /// <value>The center Bottom tab selected RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterBottomTabSelectedRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterBottomTabSelectedRTLStyle", this.CenterBottomTabNormalRTLStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the center Bottom tab selected style.
        /// </summary>
        /// <value>The center Bottom tab selected style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> CenterBottomTabSelectedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterBottomTabSelectedLTRStyle, this.CenterBottomTabSelectedRTLStyle);
            }
        }

        /// <summary>
        /// Gets the center tab hover style.
        /// </summary>
        /// <value>The center tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterBottomTabHoverLTRStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterBottomTabHoverLTRStyle", this.CenterBottomTabNormalLTRStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center Bottom tab hover RTL style.
        /// </summary>
        /// <value>The center Bottom tab hover RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterBottomTabHoverRTLStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterBottomTabHoverRTLStyle", this.CenterBottomTabNormalRTLStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center Bottom tab hover style.
        /// </summary>
        /// <value>The center Bottom tab hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<StyleValue> CenterBottomTabHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.CenterBottomTabHoverLTRStyle, this.CenterBottomTabHoverRTLStyle);
            }
        }

        /// <summary>
        /// Gets the tabs container style.
        /// </summary>
        /// <value>The tabs container style.</value>
        [Category("Styles"), Description("The Bottom tab container style.")]
        public virtual StyleValue TabsBottomContainerStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TabsBottomContainerStyle");
                return objStyle;
            }
        }

        #endregion

        #endregion

        #region TabControl Frame


        /// <summary>
        /// Gets the frame frame style.
        /// </summary>
        /// <value>The frame frame style.</value>
        [Category("Styles"), Description("The frame style.")]
        public virtual FrameStyleValue FrameStyle
        {
            get
            {
                return new FrameStyleValue(this.LeftBottomFrameStyle, this.LeftFrameStyle,
                                            this.LeftTopFrameStyle, this.TopFrameStyle,
                                            this.RightTopFrameStyle, this.RightFrameStyle,
                                            this.RightBottomFrameStyle, this.BottomFrameStyle,
                                            this.CenterFrameStyle);
            }
        }

        /// <summary>
        /// Gets or sets the height of the top frame.
        /// </summary>
        /// <value>The height of the top frame.</value>
        [Category("Sizes"), Description("The height of the top frame.")]
        public virtual int TopFrameHeight
        {
            get
            {
                return this.GetValue<int>("TopFrameHeight", this.DefaultTopFrameHeight);
            }
            set
            {
                this.SetValue("TopFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the top frame.
        /// </summary>
        internal void ResetTopFrameHeight()
        {
            this.Reset("TopFrameHeight");
        }

        /// <summary>
        /// Gets the default height of the top frame.
        /// </summary>
        /// <value>The default height of the top frame.</value>
        protected virtual int DefaultTopFrameHeight
        {
            get
            {
                return 1;
            }
        }


        /// <summary>
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Category("Sizes"), Description("The height of the bottom frame.")]
        public virtual int BottomFrameHeight
        {
            get
            {
                return this.GetValue<int>("BottomFrameHeight", this.DefaultBottomFrameHeight);
            }
            set
            {
                this.SetValue("BottomFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the bottom frame.
        /// </summary>
        internal void ResetBottomFrameHeight()
        {
            this.Reset("BottomFrameHeight");
        }

        /// <summary>
        /// Gets the default height of the bottom frame.
        /// </summary>
        /// <value>The default height of the bottom frame.</value>
        protected virtual int DefaultBottomFrameHeight
        {
            get
            {
                return 1;
            }
        }


        /// <summary>
        /// Gets or sets the height of the tab.
        /// </summary>
        /// <value>The height of the tab.</value>
        [Category("Sizes"), Description("The height of the tab.")]
        public virtual int TabHeight
        {
            get
            {
                return this.GetValue<int>("TabHeight", this.DefaultTabHeight);
            }
            set
            {
                this.SetValue("TabHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the tab in Spread appearance.
        /// </summary>
        /// <value>The height of the tab.</value>
        [Category("Sizes"), Description("The height of the tab in Spread appearance.")]
        public virtual int TabSpreadHeight
        {
            get
            {
                return this.GetValue<int>("TabSpreadHeight", this.DefaultTabHeight);
            }
            set
            {
                this.SetValue("TabSpreadHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the tab.
        /// </summary>
        internal void ResetTabHeight()
        {
            this.Reset("TabHeight");
        }

        /// <summary>
        /// Gets the default height of the tab.
        /// </summary>
        /// <value>The default height of the tab.</value>
        protected virtual int DefaultTabHeight
        {
            get
            {
                return 21;
            }
        }

        /// <summary>
        /// Gets or sets the default initial start point of the tabs.
        /// </summary>
        /// <value>The default initial start point of the tabs.</value>
        protected virtual int DefaultHeadersOffset
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("The width of the right frame.")]
        public virtual int RightFrameWidth
        {
            get
            {
                return this.GetValue<int>("RightFrameWidth", this.DefaultRightFrameWidth);
            }
            set
            {
                this.SetValue("RightFrameWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the right frame.
        /// </summary>
        internal void ResetRightFrameWidth()
        {
            this.Reset("RightFrameWidth");
        }

        /// <summary>
        /// Gets the default width of the right frame.
        /// </summary>
        /// <value>The default width of the right frame.</value>
        protected virtual int DefaultRightFrameWidth
        {
            get
            {
                return 1;
            }
        }


        /// <summary>
        /// Gets or sets the height of the seperator frame.
        /// </summary>
        /// <value>The height of the seperator frame.</value>
        [Category("Sizes"), Description("The height of the seperator frame.")]
        public virtual int SeperatorFrameHeight
        {
            get
            {
                return this.GetValue<int>("SeperatorFrameHeight", this.DefaultSeperatorFrameHeight);
            }
            set
            {
                this.SetValue("SeperatorFrameHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the seperator frame.
        /// </summary>
        private void ResetSeperatorFrameHeight()
        {
            this.Reset("SeperatorFrameHeight");
        }

        /// <summary>
        /// Gets the default height of the seperator frame.
        /// </summary>
        /// <value>The default height of the seperator frame.</value>
        protected virtual int DefaultSeperatorFrameHeight
        {
            get
            {
                return 0;
            }
        }


        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("The width of the left frame.")]
        public virtual int LeftFrameWidth
        {
            get
            {
                return this.GetValue<int>("LeftFrameWidth", this.DefaultLeftFrameWidth);
            }
            set
            {
                this.SetValue("LeftFrameWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the left frame.
        /// </summary>
        private void ResetLeftFrameWidth()
        {
            this.Reset("LeftFrameWidth");
        }

        /// <summary>
        /// Gets the default width of the left frame.
        /// </summary>
        /// <value>The default width of the left frame.</value>
        protected virtual int DefaultLeftFrameWidth
        {
            get
            {
                return 1;
            }
        }


        /// <summary>
        /// Gets the frame left top style.
        /// </summary>
        /// <value>The frame left top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopFrameStyle
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
        public virtual FramePartStyleValue TopFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopFrameStyle");
                return objStyle;
            }
        }



        /// <summary>
        /// Gets the frame right top style.
        /// </summary>
        /// <value>The frame right top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame left style.
        /// </summary>
        /// <value>The frame left style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame right style.
        /// </summary>
        /// <value>The frame right style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame left bottom style.
        /// </summary>
        /// <value>The frame left bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center style.
        /// </summary>
        /// <value>The center style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame bottom style.
        /// </summary>
        /// <value>The frame bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame right bottom style.
        /// </summary>
        /// <value>The frame right bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomFrameStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the seperator frame style.
        /// </summary>
        /// <value>The seperator frame style.</value>
        [Category("Styles"), Description("The seperator style.")]
        public virtual SimpleFrameStyleValue SeperatorFrameStyle
        {
            get
            {
                return new SimpleFrameStyleValue(
                    this.LeftSeperatorFrameStyle,
                    this.RightSeperatorFrameStyle,
                    this.CenterSeperatorFrameStyle);
            }
        }

        /// <summary>
        /// Gets the center seperator frame style.
        /// </summary>
        /// <value>The center seperator frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterSeperatorFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterSeperatorFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right seperator frame style.
        /// </summary>
        /// <value>The right seperator frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightSeperatorFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightSeperatorFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left seperator frame style.
        /// </summary>
        /// <value>The left seperator frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftSeperatorFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftSeperatorFrameStyle");
                return objStyle;
            }
        }


        #endregion

        /// <summary>
        /// Gets the header lable normal padding.
        /// </summary>
        /// <value>The header lable normal padding.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinValue<PaddingValue> HeaderLableNormalPadding
        {
            get
            {
                return new BidirectionalSkinValue<PaddingValue>(this, CenterTopTabNormalLTRStyle.Padding, CenterTopTabNormalLTRStyle.Padding);
            }
        }

        #region Close Button Styles


        /// <summary>
        /// Gets the Close button normal style.
        /// </summary>
        /// <value>The Close button normal style.</value>
        [Category("States"), Description("The Close button normal style.")]
        public virtual StyleValue CloseButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CloseButtonNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Close button hover style.
        /// </summary>
        /// <value>The Close button hover style.</value>
        [Category("States"), Description("The Close button hover style.")]
        public virtual StyleValue CloseButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CloseButtonHoverStyle", this.CloseButtonNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Close button pressed style.
        /// </summary>
        /// <value>The Close button pressed style.</value>
        [Category("States"), Description("The Close button pressed style.")]
        public virtual StyleValue CloseButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CloseButtonPressedStyle", this.CloseButtonNormalStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets or sets the size of the Close button.
        /// </summary>
        /// <value>The size of the Close button.</value>
        [Category("Sizes"), Description("The size of the Close button.")]
        public virtual Size CloseButtonSize
        {
            get
            {
                return this.GetValue<Size>("CloseButtonSize", this.GetImageSize(this.CloseButtonNormalStyle.BackgroundImage, this.DefaultCloseButtonSize));
            }
            set
            {
                this.SetValue("CloseButtonSize", value);
            }
        }

        /// <summary>
        /// Gets the default size of the Close button.
        /// </summary>
        /// <value>The default size of the Close button.</value>
        protected virtual Size DefaultCloseButtonSize
        {
            get
            {
                return new Size(16, 16);
            }
        }

        /// <summary>
        /// Resets the size of the Close button.
        /// </summary>
        private void ResetCloseButtonSize()
        {
            this.Reset("CloseButtonSize");
        }


        /// <summary>
        /// Gets the width of the Close button.
        /// </summary>
        /// <value>The width of the Close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CloseButtonWidth
        {
            get
            {
                return this.CloseButtonSize.Width + CloseButtonNormalStyle.Padding.Horizontal;
            }
        }


        /// <summary>
        /// Gets the height of the Close button.
        /// </summary>
        /// <value>The height of the Close button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CloseButtonHeight
        {
            get
            {
                return this.CloseButtonSize.Height;
            }
        }


        #endregion

        #region Expand Button Styles


        /// <summary>
        /// Gets the expand button normal style.
        /// </summary>
        /// <value>The expand button normal style.</value>
        [Category("States"), Description("The expand button normal style.")]
        public virtual StyleValue ExpandButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ExpandButtonNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Expand button hover style.
        /// </summary>
        /// <value>The Expand button hover style.</value>
        [Category("States"), Description("The Expand button hover style.")]
        public virtual StyleValue ExpandButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ExpandButtonHoverStyle", this.ExpandButtonNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the expand button pressed style.
        /// </summary>
        /// <value>The expand button pressed style.</value>
        [Category("States"), Description("The Expand button pressed style.")]
        public virtual StyleValue ExpandButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ExpandButtonPressedStyle", this.ExpandButtonNormalStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets or sets the size of the expand button.
        /// </summary>
        /// <value>The size of the Expand button.</value>
        [Category("Sizes"), Description("The size of the expand button.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Size ExpandButtonSize
        {
            get
            {
                return this.GetImageSize(this.ExpandButtonNormalStyle.BackgroundImage, this.DefaultExpandButtonSize);
            }
        }

        /// <summary>
        /// Gets the default size of the expand button.
        /// </summary>
        /// <value>The default size of the expand button.</value>
        protected virtual Size DefaultExpandButtonSize
        {
            get
            {
                return new Size(16, 16);
            }
        }

        /// <summary>
        /// Gets the width of the Expand button.
        /// </summary>
        /// <value>The width of the Expand button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ExpandButtonWidth
        {
            get
            {
                return this.ExpandButtonSize.Width + ExpandButtonNormalStyle.Padding.Horizontal;
            }
        }


        /// <summary>
        /// Gets the height of the Expand button.
        /// </summary>
        /// <value>The height of the Expand button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ExpandButtonHeight
        {
            get
            {
                return this.ExpandButtonSize.Height;
            }
        }


        #endregion

        #region Collapse Button Styles

        /// <summary>
        /// Gets the collapse button normal style.
        /// </summary>
        /// <value>The collapse button normal style.</value>
        [Category("States"), Description("The collapse button normal style.")]
        public virtual StyleValue CollapseButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CollapseButtonNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Collapse button hover style.
        /// </summary>
        /// <value>The Collapse button hover style.</value>
        [Category("States"), Description("The Collapse button hover style.")]
        public virtual StyleValue CollapseButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CollapseButtonHoverStyle", this.CollapseButtonNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the collapse button pressed style.
        /// </summary>
        /// <value>The collapse button pressed style.</value>
        [Category("States"), Description("The Collapse button pressed style.")]
        public virtual StyleValue CollapseButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CollapseButtonPressedStyle", this.CollapseButtonNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the size of the collapse button.
        /// </summary>
        /// <value>The size of the Collapse button.</value>
        [Category("Sizes"), Description("The size of the collapse button.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Size CollapseButtonSize
        {
            get
            {
                return this.GetImageSize(this.CollapseButtonNormalStyle.BackgroundImage, this.DefaultCollapseButtonSize);
            }
        }

        /// <summary>
        /// Gets the default size of the collapse button.
        /// </summary>
        /// <value>The default size of the collapse button.</value>
        protected virtual Size DefaultCollapseButtonSize
        {
            get
            {
                return new Size(16, 16);
            }
        }

        /// <summary>
        /// Gets the width of the Collapse button.
        /// </summary>
        /// <value>The width of the Collapse button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CollapseButtonWidth
        {
            get
            {
                return this.CollapseButtonSize.Width + CollapseButtonNormalStyle.Padding.Horizontal;
            }
        }

        /// <summary>
        /// Gets the height of the Collapse button.
        /// </summary>
        /// <value>The height of the Collapse button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CollapseButtonHeight
        {
            get
            {
                return this.CollapseButtonSize.Height;
            }
        }

        #endregion

        /// <summary>
        /// Hide font property
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Hide fore color property
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        #region Tab Sizes

        /// <summary>
        /// Gets or sets the size of the tab image.
        /// </summary>
        /// <value>The size of the tab image.</value>
        [Category("Sizes"), Description("The width and height of the tab page image.")]
        public virtual Size TabImageSize
        {
            get
            {
                return new Size(TabImageWidth, TabImageHeight);
            }
            set
            {
                TabImageWidth = value.Width;
                TabImageHeight = value.Height;
            }
        }

        /// <summary>
        /// Resets the size of the tab image.
        /// </summary>
        private void ResetTabImageSize()
        {
            this.Reset("TabImageHeight");
            this.Reset("TabImageWidth");
        }



        /// <summary>
        /// Gets or sets the height of the tab image.
        /// </summary>
        /// <value>The height of the tab image.</value>
        [Category("Sizes"), Description("The height of the tab page image.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TabImageHeight
        {
            get
            {
                return this.GetValue<int>("TabImageHeight", this.DefaultTabImageHeight);
            }
            set
            {
                this.SetValue("TabImageHeight", value);
            }
        }

        /// <summary>
        /// Gets the default height of the tab image.
        /// </summary>
        /// <value>The default height of the tab image.</value>
        protected virtual int DefaultTabImageHeight
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets or sets the width of the tab image.
        /// </summary>
        /// <value>The width of the tab image.</value>
        [Category("Sizes"), Description("The width of the tab page image.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TabImageWidth
        {
            get
            {
                return this.GetValue<int>("TabImageWidth", this.DefaultTabImageWidth);
            }
            set
            {
                this.SetValue("TabImageWidth", value);
            }
        }

        /// <summary>
        /// Gets the default width of the tab image.
        /// </summary>
        /// <value>The default width of the tab image.</value>
        protected virtual int DefaultTabImageWidth
        {
            get
            {
                return 16;
            }
        }

        #endregion


        #region ContextualTabGroup Style


        /// <summary>
        /// Gets the contextual tab group normal style.
        /// </summary>
        public virtual StyleValue ContextualTabGroupNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ContextualTabGroupNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the height of the contextual tab group.
        /// </summary>
        /// <value>The height of the tab.</value>
        [Category("Sizes"), Description("The height of the contextual tab group.")]
        public virtual int ContextualTabGroupHeight
        {
            get
            {
                return this.GetValue<int>("ContextualTabGroupHeight", this.DefaultContextualTabGroupHeight);
            }
            set
            {
                this.SetValue("ContextualTabGroupHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the contextual tab group.
        /// </summary>
        internal void ResetContextualTabGroupHeight()
        {
            this.Reset("ContextualTabGroupHeight");
        }

        /// <summary>
        /// Gets the default height of the tab.
        /// </summary>
        /// <value>The default height of the tab.</value>
        protected virtual int DefaultContextualTabGroupHeight
        {
            get
            {
                return 21;
            }
        }

        #endregion ContextualTabGroup Style

        #region Tab More

        /// <summary>
        /// Gets the tab show content image.
        /// </summary>
        [Category("Images"), Description("The default image shown on the each tab in 'MORE' display.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> TabShowContentImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "TabShowContentImageLTR", "TabShowContentImageRTL");
            }
        }

        [Category("Images"), Description("The default image size shown on the each tab in 'MORE' display.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<Size> TabShowContentImageSize
        {
            get
            {
                return new BidirectionalSkinProperty<Size>(this, "TabShowContentImageLTRSize", "TabShowContentImageRTLSize");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinProperty<int> TabShowContentImageHeight
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "TabShowContentImageLTRHeight", "TabShowContentImageRTLHeight");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BidirectionalSkinProperty<int> TabShowContentImageWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "TabShowContentImageLTRWidth", "TabShowContentImageRTLWidth");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TabShowContentImageLTRHeight
        {
            get
            {
                return TabShowContentImageLTRSize.Height;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TabShowContentImageLTRWidth
        {
            get
            {
                return TabShowContentImageLTRSize.Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TabShowContentImageRTLHeight
        {
            get
            {
                return TabShowContentImageRTLSize.Height;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TabShowContentImageRTLWidth
        {
            get
            {
                return TabShowContentImageRTLSize.Width;
            }
        }

        /// <summary>
        /// Gets or sets the tab show content image LTR.
        /// </summary>
        /// <value>
        /// The tab show content image LTR.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference TabShowContentImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TabShowContentImageLTR", new ImageResourceReference(typeof(TabControlSkin), "TabShowContentLTR.png"));
            }
            set
            {
                this.SetValue("TabShowContentImageLTR", value);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size TabShowContentImageLTRSize
        {
            get
            {
                return this.GetValue<Size>("TabShowContentImageLTRSize", GetImageSize(TabShowContentImageLTR, Size.Empty));
            }
            set
            {
                this.SetValue("TabShowContentImageLTRSize", value);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size TabShowContentImageRTLSize
        {
            get
            {
                return this.GetValue<Size>("TabShowContentImageRTLSize", GetImageSize(TabShowContentImageRTL, Size.Empty));
            }
            set
            {
                this.SetValue("TabShowContentImageRTLSize", value);
            }
        }

        /// <summary>
        /// Resets the tab show content image LTR.
        /// </summary>
        private void ResetTabShowContentImageLTR()
        {
            this.Reset("TabShowContentImageLTR");
        }

        /// <summary>
        /// Gets or sets the tab show content image RTL.
        /// </summary>
        /// <value>
        /// The tab show content image RTL.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference TabShowContentImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TabShowContentImageRTL", new ImageResourceReference(typeof(TabControlSkin), "TabShowContentRTL.png"));
            }
            set
            {
                this.SetValue("DropDownOverImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the tab show content image RTL.
        /// </summary>
        private void ResetTabShowContentImageRTL()
        {
            this.Reset("TabShowContentImageRTL");
        }

        /// <summary>
        /// Gets the More Tab image.
        /// </summary>
        /// <value>The image.</value>
        [Category("Images"), Description("The default image shown on tab 'MORE'.")]
        public virtual ImageResourceReference TabMoreImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TabMoreImage", new ImageResourceReference(typeof(TabControlSkin), "TabMoreImage.png"));
            }
            set
            {
                this.SetValue("TabMoreImage", value);
            }
        }

        /// <summary>
        /// Gets the tab page headers container spread style.
        /// </summary>
        [Category("Appearance"), Description("Tab Page Headers Container style in Spread appearance.")]
        public virtual StyleValue TabPageHeadersContainerSpreadStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TabPageHeadersContainerSpreadStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tab page headers container spread top padding.
        /// </summary>
        [Browsable(false)]
        public virtual int TabPageHeadersContainerSpreadStylePaddingTop
        {
            get
            {
                return TabPageHeadersContainerSpreadStyle.Padding.Top;
            }
        }
        /// <summary>
        /// Gets the tab page headers container spread bottom padding.
        /// </summary>
        [Browsable(false)]
        public virtual int TabPageHeadersContainerSpreadStylePaddingBottom
        {
            get
            {
                return TabPageHeadersContainerSpreadStyle.Padding.Bottom;
            }
        }
       
        /// <summary>
        /// Gets the tab page header gradient selected style.
        /// </summary>
        [Category("Appearance"), Description("Tab Page Header Selected style.")]
        public virtual StyleValue TabPageHeaderSelectedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TabPageHeaderSelectedStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tab page more tab page style.
        /// </summary>
        [Category("Appearance"), Description("The style of the tab pages in tab more content.")]
        public virtual StyleValue TabPageMoreTabPagesStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TabPageMoreTabPagesStyle", this.CenterTabTopNormalLTRSpreadStyle);
                return objStyle;
            }

        }

        /// <summary>
        /// Gets the tab page more tab page hover style.
        /// </summary>
        [Category("Appearance"), Description("The style of the tab pages in tab more content on hover.")]
        public virtual StyleValue TabPageMoreTabHoverPagesStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TabPageMoreTabHoverPagesStyle", this.CenterTabTopHoverLTRSpreadStyle);
                return objStyle;
            }

        }
        /// <summary>
        /// Gets the tab top pressed more style.
        /// </summary>
        [Category("Appearance"), Description("The top tab pressed more appearance style.")]
        public virtual StyleValue TabPageMoreTabPressedPagesStyle
        {
            get
            {
                return new StyleValue(this, "TabPageMoreTabSelectedPagesStyle", this.CenterTabTopSelectedLTRSpreadStyle);
            }
        }
        /// <summary>
        /// Gets or sets the height of the tab page more tab page.
        /// </summary>
        /// <value>
        /// The height of the tab page more tab page.
        /// </value>
        [Category("Sizes"), Description("The height of the tab pages in tab more content.")]
        public virtual int TabPageMoreTabPageHeight
        {
            get
            {
                return this.GetValue<int>("TabPageMoreTabPageHeight", this.DefaultTabPageMoreTabPageHeight);
            }
            set
            {
                this.SetValue("TabPageMoreTabPageHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the tab page more tab page.
        /// </summary>
        internal void ResetTabPageMoreTabPageHeight()
        {
            this.Reset("TabPageMoreTabPageHeight");
        }

        /// <summary>
        /// Gets the default height of the tab page more tab page.
        /// </summary>
        /// <value>
        /// The default height of the tab page more tab page.
        /// </value>
        private int DefaultTabPageMoreTabPageHeight
        {
            get
            {
                return 44;
            }
        }

        #endregion

        private void InitializeComponent()
        {

        }


    }
}
