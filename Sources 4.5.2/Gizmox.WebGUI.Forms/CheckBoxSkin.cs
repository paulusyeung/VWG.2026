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
    /// CheckBox Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(CheckBox), "CheckBox.bmp"), Serializable()]
    public class CheckBoxSkin : Gizmox.WebGUI.Forms.Skins.ButtonBaseSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the height of the check box image.
        /// </summary>
        /// <value>The height of the check box image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CheckBoxImageHeight
        {
            get
            {
                return this.GetMaxImageHeight(16,"CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");
            }
        }

        /// <summary>
        /// Gets the width of the check box image.
        /// </summary>
        /// <value>The width of the check box image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CheckBoxImageWidth
        {
            get
            {
                return this.GetMaxImageWidth(15, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");
            }
        }


        #region CheckBoxes

        /// <summary>
        /// Gets or sets the checked check box image.
        /// </summary>
        /// <value>The checked check box image.</value>
        [SRDescription("The checked checkbox image.")]
        [SRCategory("Images")]
        public ImageResourceReference CheckedCheckBoxImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("CheckedCheckBoxImage", new ImageResourceReference(typeof(CheckBoxSkin), "CheckBox1.gif"));
            }
            set
            {
                this.SetValue("CheckedCheckBoxImage", value);
            }
        }

        /// <summary>
        /// Resets the checked check box image.
        /// </summary>
        private void ResetCheckedCheckBoxImage()
        {
            this.Reset("CheckedCheckBoxImage");
        }

        /// <summary>
        /// Gets or sets the un checked check box image.
        /// </summary>
        /// <value>The un checked check box image.</value>
        [SRDescription("The unchecked checkbox image.")]
        [SRCategory("Images")]
        public ImageResourceReference UnCheckedCheckBoxImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UnCheckedCheckBoxImage", new ImageResourceReference(typeof(CheckBoxSkin), "CheckBox0.gif"));
            }
            set
            {
                this.SetValue("UnCheckedCheckBoxImage", value);
            }
        }

        /// <summary>
        /// Resets the un checked check box image.
        /// </summary>
        private void ResetUnCheckedCheckBoxImage()
        {
            this.Reset("UnCheckedCheckBoxImage");
        }

        /// <summary>
        /// Gets or sets the indeterminate check box image.
        /// </summary>
        /// <value>The indeterminate check box image.</value>
        [SRDescription("The Indeterminate checkbox image.")]
        [SRCategory("Images")]
        public ImageResourceReference IndeterminateCheckBoxImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("IndeterminateCheckBoxImage", new ImageResourceReference(typeof(CheckBoxSkin), "CheckBox2.gif"));
            }
            set
            {
                this.SetValue("IndeterminateCheckBoxImage", value);
            }
        }

        /// <summary>
        /// Resets the indeterminate check box image.
        /// </summary>
        private void ResetIndeterminateCheckBoxImage()
        {
            this.Reset("IndeterminateCheckBoxImage");
        }

        #endregion

        #region Label Style

        /// <summary>
        /// Gets the label normal style.
        /// </summary>
        /// <value>The center normal style.</value>
        [Category("States"), Description("The checkbox's label normal style.")]
        public virtual StyleValue LabelNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LabelNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the label focused style.
        /// </summary>
        /// <value>The center focused style.</value>
        [Category("States"), Description("The checkbox's label focused style.")]
        public virtual StyleValue LabelFocusedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LabelFocusedStyle");
                return objStyle;
            }
        }

        #endregion

        #region Button apperance

        #region Frames sizes

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

        #endregion

        #region Niner styles

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

        #endregion

        #region Font values

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

        #endregion

        #region Foreground values

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

        #endregion

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

        #endregion
    }
}
