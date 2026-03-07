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
    /// Button Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(Button), "Button.bmp"), Serializable()]
    public class ButtonSkin : Gizmox.WebGUI.Forms.Skins.ButtonBaseSkin
    {
        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {

        }


        #region Hide Unnecessary Properties

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
        }

        /// <summary>
        /// Gets the foreground.
        /// </summary>
        /// <value>The foreground.</value>
        [Browsable(false)]
        public ForegroundValue Foreground
        {
            get
            {
                return base.Foreground;
            }
        }

        #endregion

        /// <summary>
        /// Gets the normal style.
        /// </summary>
        /// <value>The normal style.</value>
        [Category("States"), Description("The normal button style.")]
        public FrameStyleValue NormalStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomNormalStyle,
                    this.LeftNormalStyle,
                    this.LeftTopNormalStyle,
                    this.TopNormalStyle,
                    this.RightTopNormalStyle,
                    this.RightNormalStyle,
                    this.RightBottomNormalStyle,
                    this.BottomNormalStyle,
                    this.CenterNormalStyle);
            }
        }

        /// <summary>
        /// Gets the hover style.
        /// </summary>
        /// <value>The hover style.</value>
        [Category("States"), Description("The hover button style.")]
        public FrameStyleValue HoverStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomHoverStyle,
                    this.LeftHoverStyle,
                    this.LeftTopHoverStyle,
                    this.TopHoverStyle,
                    this.RightTopHoverStyle,
                    this.RightHoverStyle,
                    this.RightBottomHoverStyle,
                    this.BottomHoverStyle,
                    this.CenterHoverStyle);
            }
        }

        /// <summary>
        /// Gets the pressed style.
        /// </summary>
        /// <value>The pressed style.</value>
        [Category("States"), Description("The pressed button style.")]
        public FrameStyleValue PressedStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomPressedStyle,
                    this.LeftPressedStyle,
                    this.LeftTopPressedStyle,
                    this.TopPressedStyle,
                    this.RightTopPressedStyle,
                    this.RightPressedStyle,
                    this.RightBottomPressedStyle,
                    this.BottomPressedStyle,
                    this.CenterPressedStyle);
            }
        }

        /// <summary>
        /// Gets the disabled style.
        /// </summary>
        /// <value>The disabled style.</value>
        [Category("States"), Description("The disabled button style.")]
        public FrameStyleValue DisabledStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomDisabledStyle,
                    this.LeftDisabledStyle,
                    this.LeftTopDisabledStyle,
                    this.TopDisabledStyle,
                    this.RightTopDisabledStyle,
                    this.RightDisabledStyle,
                    this.RightBottomDisabledStyle,
                    this.BottomDisabledStyle,
                    this.CenterDisabledStyle);
            }
        }

        /// <summary>
        /// Gets the focused style.
        /// </summary>
        /// <value>The focused style.</value>
        [Category("States"), Description("The focused button style.")]
        public FrameStyleValue FocusedStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomFocusedStyle,
                    this.LeftFocusedStyle,
                    this.LeftTopFocusedStyle,
                    this.TopFocusedStyle,
                    this.RightTopFocusedStyle,
                    this.RightFocusedStyle,
                    this.RightBottomFocusedStyle,
                    this.BottomFocusedStyle,
                    this.CenterFocusedStyle);
            }
        }

        #region Normal Style

        /// <summary>
        /// Gets the center normal style.
        /// </summary>
        /// <value>The center normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left normal style.
        /// </summary>
        /// <value>The left normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top normal style.
        /// </summary>
        /// <value>The top normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom normal style.
        /// </summary>
        /// <value>The bottom normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right normal style.
        /// </summary>
        /// <value>The right normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top normal style.
        /// </summary>
        /// <value>The right top normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top normal style.
        /// </summary>
        /// <value>The left top normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom normal style.
        /// </summary>
        /// <value>The left bottom normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom normal style.
        /// </summary>
        /// <value>The right bottom normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomNormalStyle");
                return objStyle;
            }
        }

        #endregion

        #region Hover Style

        /// <summary>
        /// Gets the center hover style.
        /// </summary>
        /// <value>The center hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterHoverStyle", this.CenterNormalStyle);

                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left hover style.
        /// </summary>
        /// <value>The left hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftHoverStyle", this.LeftNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top hover style.
        /// </summary>
        /// <value>The top hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopHoverStyle", this.TopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom hover style.
        /// </summary>
        /// <value>The bottom hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomHoverStyle", this.BottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right hover style.
        /// </summary>
        /// <value>The right hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightHoverStyle", this.RightNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top hover style.
        /// </summary>
        /// <value>The right top hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopHoverStyle", this.RightTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top hover style.
        /// </summary>
        /// <value>The left top hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopHoverStyle", this.LeftTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom hover style.
        /// </summary>
        /// <value>The left bottom hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomHoverStyle", this.LeftBottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom hover style.
        /// </summary>
        /// <value>The right bottom hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomHoverStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomHoverStyle", this.RightBottomNormalStyle);
                return objStyle;
            }
        }

        #endregion

        #region Disabled Style

        /// <summary>
        /// Gets the center disabled style.
        /// </summary>
        /// <value>The center disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterDisabledStyle", this.CenterNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left disabled style.
        /// </summary>
        /// <value>The left disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftDisabledStyle", this.LeftNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top disabled style.
        /// </summary>
        /// <value>The top disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopDisabledStyle", this.TopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom disabled style.
        /// </summary>
        /// <value>The bottom disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomDisabledStyle", this.BottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right disabled style.
        /// </summary>
        /// <value>The right disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightDisabledStyle", this.RightNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top disabled style.
        /// </summary>
        /// <value>The right top disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopDisabledStyle", this.RightTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top disabled style.
        /// </summary>
        /// <value>The left top disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopDisabledStyle", this.LeftTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom disabled style.
        /// </summary>
        /// <value>The left bottom disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomDisabledStyle", this.LeftBottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom disabled style.
        /// </summary>
        /// <value>The right bottom disabled style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomDisabledStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomDisabledStyle", this.RightBottomNormalStyle);
                return objStyle;
            }
        }

        #endregion

        #region Focused Style

        /// <summary>
        /// Gets the center focused style.
        /// </summary>
        /// <value>The center focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterFocusedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterFocusedStyle", this.CenterNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left focused style.
        /// </summary>
        /// <value>The left focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftFocusedStyle", this.LeftNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top focused style.
        /// </summary>
        /// <value>The top focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopFocusedStyle", this.TopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom focused style.
        /// </summary>
        /// <value>The bottom focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomFocusedStyle", this.BottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right focused style.
        /// </summary>
        /// <value>The right focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightFocusedStyle", this.RightNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top focused style.
        /// </summary>
        /// <value>The right top focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopFocusedStyle", this.RightTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top focused style.
        /// </summary>
        /// <value>The left top focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopFocusedStyle", this.LeftTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom focused style.
        /// </summary>
        /// <value>The left bottom focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomFocusedStyle", this.LeftBottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom focused style.
        /// </summary>
        /// <value>The right bottom focused style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomFocusedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomFocusedStyle", this.RightBottomNormalStyle);
                return objStyle;
            }
        }
        #endregion

        #region Pressed Style

        /// <summary>
        /// Gets the center pressed style.
        /// </summary>
        /// <value>The center pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterPressedStyle", this.CenterNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left pressed style.
        /// </summary>
        /// <value>The left pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftPressedStyle", this.LeftNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top pressed style.
        /// </summary>
        /// <value>The top pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopPressedStyle", this.TopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom pressed style.
        /// </summary>
        /// <value>The bottom pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomPressedStyle", this.BottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right pressed style.
        /// </summary>
        /// <value>The right pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightPressedStyle", this.RightNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top pressed style.
        /// </summary>
        /// <value>The right top pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopPressedStyle", this.RightTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top pressed style.
        /// </summary>
        /// <value>The left top pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopPressedStyle", this.LeftTopNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom pressed style.
        /// </summary>
        /// <value>The left bottom pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomPressedStyle", this.LeftBottomNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom pressed style.
        /// </summary>
        /// <value>The right bottom pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomPressedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomPressedStyle", this.RightBottomNormalStyle);
                return objStyle;
            }
        }

        #endregion





        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("The width of the left frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int LeftFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Resets the width of the left frame.
        /// </summary>
        internal void ResetLeftFrameWidth()
        {
            this.Reset("LeftFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("The width of the right frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int RightFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Right);
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
        /// Gets or sets the height of the top frame.
        /// </summary>
        /// <value>The height of the top frame.</value>
        [Category("Sizes"), Description("The height of the top frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int TopFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Top);
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
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Category("Sizes"), Description("The height of the bottom frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int BottomFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Bottom);
            }
        }

        /// <summary>
        /// Gets the content padding.
        /// </summary>
        /// <value>The content padding.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual PaddingValue ContentPadding
        {
            get
            {
                // Get skin's padding.
                return this.Padding;
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
        /// Gets the font When the button is normal.
        /// </summary>
        /// <value>The font normal.</value>
        [Browsable(false)]
        public Font FontNormal
        {
            get
            {
                return this.CenterNormalStyle.Font;
            }
        }

        /// <summary>
        /// Gets the font When the button is pressed.
        /// </summary>
        /// <value>The font pressed.</value>
        [Browsable(false)]
        public Font FontPressed
        {
            get
            {
                return this.CenterPressedStyle.Font;
            }
        }

        /// <summary>
        /// Gets the font When the button is hover.
        /// </summary>
        /// <value>The font hover.</value>
        [Browsable(false)]
        public Font FontHover
        {
            get
            {
                return this.CenterHoverStyle.Font;
            }
        }

        /// <summary>
        /// Gets the font When the button is focused.
        /// </summary>
        /// <value>The font focused.</value>
        [Browsable(false)]
        public Font FontFocused
        {
            get
            {
                return this.CenterFocusedStyle.Font;
            }
        }

        /// <summary>
        /// Gets the font When the button is disabled.
        /// </summary>
        /// <value>The font disabled.</value>
        [Browsable(false)]
        public Font FontDisabled
        {
            get
            {
                return this.CenterDisabledStyle.Font;
            }
        }

        /// <summary>
        /// Gets the foreground value When the button is normal.
        /// </summary>
        /// <value>The foreground value normal.</value>
        [Browsable(false)]
        public ForegroundValue ForegroundNormal
        {
            get
            {
                return new ForegroundValue(this.CenterNormalStyle.ForeColor);
            }
        }

        /// <summary>
        /// Gets the foreground value When the button is pressed.
        /// </summary>
        /// <value>The foreground value pressed.</value>
        [Browsable(false)]
        public ForegroundValue ForegroundPressed
        {
            get
            {
                return new ForegroundValue(this.CenterPressedStyle.ForeColor);

            }
        }

        /// <summary>
        /// Gets the foreground value When the button is hover.
        /// </summary>
        /// <value>The foreground value hover.</value>
        [Browsable(false)]
        public ForegroundValue ForegroundHover
        {
            get
            {
                return new ForegroundValue(this.CenterHoverStyle.ForeColor);

            }
        }

        /// <summary>
        /// Gets the foreground value When the button is focused.
        /// </summary>
        /// <value>The foreground value focused.</value>
        [Browsable(false)]
        public ForegroundValue ForegroundFocused
        {
            get
            {
                return new ForegroundValue(this.CenterFocusedStyle.ForeColor);
            }
        }

        /// <summary>
        /// Gets the foreground value When the button is disabled.
        /// </summary>
        /// <value>The foreground value disabled.</value>
        [Browsable(false)]
        public ForegroundValue ForegroundDisabled
        {
            get
            {
                return new ForegroundValue(this.CenterDisabledStyle.ForeColor);
            }
        }

        #region Flat button

        #region Normal Style

        /// <summary>
        /// Gets the flat button normal style.
        /// </summary>
        /// <value>The flat button normal style.</value>
        [Category("States"), Description("The flat button normal style.")]
        public virtual StyleValue FlatButtonNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatButtonNormalStyle");
                return objStyle;
            }
        }

        #endregion Normal Style

        #region Focused Style

        /// <summary>
        /// Gets the flat button focused style.
        /// </summary>
        /// <value>The flat button focused style.</value>
        [Category("States"), Description("The flat button focused style.")]
        public virtual StyleValue FlatButtonFocusedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatButtonFocusedStyle");
                return objStyle;
            }
        }

        #endregion Focused Style

        #region Hover Style

        /// <summary>
        /// Gets the flat button hover style.
        /// </summary>
        /// <value>The flat button hover style.</value>
        [Category("States"), Description("The flat button hover style.")]
        public virtual StyleValue FlatButtonHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatButtonHoverStyle");
                return objStyle;
            }
        }

        #endregion Hover Style

        #region Pressed Style

        /// <summary>
        /// Gets the flat button pressed style.
        /// </summary>
        /// <value>The flat button pressed style.</value>
        [Category("States"), Description("The flat button pressed style.")]
        public virtual StyleValue FlatButtonPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FlatButtonPressedStyle");
                return objStyle;
            }
        }


        #endregion Pressed Style

        #region DropDown arrow image

        /// <summary>
        /// Gets the drop down arrow image style.
        /// </summary>
        [Category("States"), SRDescription("The menu item image style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue DropDownArrowImageStyle
        {
            get
            {
                return new StyleValue(this, "DropDownArrowImageStyle");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int DropDownImageWidth
        {
            get
            {
                return GetImageSize(this.DropDownArrowImageStyle.BackgroundImage, Size.Empty).Width;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int DropDownImageHeight
        {
            get
            {
                return GetImageSize(this.DropDownArrowImageStyle.BackgroundImage, Size.Empty).Height;
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        public ImageResourceReference DropDownArrowImage
        {
            get
            {
                return this.DropDownArrowImageStyle.BackgroundImage;
            }
            set
            {
                this.DropDownArrowImageStyle.BackgroundImage = value;
            }
        }

        /// <summary>
        /// Gets the drop down arrow image disabled style.
        /// </summary>
        /// <value>
        /// The drop down arrow image disabled style.
        /// </value>
        [Category("States"), Description("The drop down arrow image disable style.")]
        public virtual StyleValue DropDownArrowImageDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownArrowImageDisabledStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Resets the drop down arrow image disabled style.
        /// </summary>
        internal void ResetDropDownArrowImageDisabledStyle()
        {
            this.Reset("DropDownArrowImageDisabledStyle");
        }


        #endregion

        #endregion

        /// <summary>
        /// Gets the button image disabled style.
        /// </summary>
        [Category("States"), Description("The button image disabled style.")]
        public virtual StyleValue ImageDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ImageDisabledStyle", ImageStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the button image style.
        /// </summary>
        [Category("States"), Description("The button image style.")]
        public virtual StyleValue ImageStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ImageStyle");
                return objStyle;
            }
        }        
    }
}
