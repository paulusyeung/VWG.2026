using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    [SkinContainerAttribute(typeof(ToolBarSkin))]
    [ToolboxBitmap(typeof(Button), "Button.bmp"), Serializable()]
    public class ToolBarButtonSkin : ButtonSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the pushed style.
        /// </summary>
        /// <value>The pushed style.</value>
        [Category("States"), Description("The pushed button style.")]
        public virtual FrameStyleValue PushedStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomPushedStyle,
                    this.LeftPushedStyle,
                    this.LeftTopPushedStyle,
                    this.TopPushedStyle,
                    this.RightTopPushedStyle,
                    this.RightPushedStyle,
                    this.RightBottomPushedStyle,
                    this.BottomPushedStyle,
                    this.CenterPushedStyle);
            }
        }

        /// <summary>
        /// Gets the drop down button style.
        /// </summary>
        /// <value>The drop down button style.</value>
        [Category("States"), Description("The drop down button sytle.")]
        public virtual StyleValue DropDownButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownButtonStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the seperator style.
        /// </summary>
        /// <value>The seperator style.</value>
        public StyleValue SeperatorStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SeperatorStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the width of the seperator.
        /// </summary>
        /// <value>The width of the seperator.</value>
        [Category("Sizes"), Description("The width of the seperator.")]
        public int SeperatorWidth
        {
            get
            {
                return this.GetValue<int>("SeperatorWidth", 3);
            }
            set
            {
                this.SetValue("SeperatorWidth", value);
            }
        }


        #region Pushed Style

        /// <summary>
        /// Gets the center pushed style.
        /// </summary>
        /// <value>The center pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterPushedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterPushedStyle", this.CenterPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left pushed style.
        /// </summary>
        /// <value>The left pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftPushedStyle", this.LeftPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top pushed style.
        /// </summary>
        /// <value>The top pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopPushedStyle", this.TopPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom pushed style.
        /// </summary>
        /// <value>The bottom pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomPushedStyle", this.BottomPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right pushed style.
        /// </summary>
        /// <value>The right pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightPushedStyle", this.RightPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top pushed style.
        /// </summary>
        /// <value>The right top pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopPushedStyle", this.RightTopPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top pushed style.
        /// </summary>
        /// <value>The left top pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopPushedStyle", this.LeftTopPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom pushed style.
        /// </summary>
        /// <value>The left bottom pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomPushedStyle", this.LeftBottomPressedStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom pushed style.
        /// </summary>
        /// <value>The right bottom pushed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomPushedStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomPushedStyle", this.RightBottomPressedStyle);
                return objStyle;
            }
        }

        #endregion

        /// <summary>
        /// Gets the size of the drop down image.
        /// </summary>
        /// <value>The size of the drop down image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size DropDownImageSize
        {
            get
            {
                return GetImageSize(DropDownButtonStyle.BackgroundImage, Size.Empty);
            }
        }

        /// <summary>
        /// Gets the width of the drop down image.
        /// </summary>
        /// <value>The width of the drop down image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DropDownImageWidth
        {
            get
            {
                return this.DropDownImageSize.Width;
            }
        }
    }
}
