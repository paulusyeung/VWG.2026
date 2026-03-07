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
    /// MainMenu Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(MainMenu), "MainMenu.bmp"), Serializable()]
    public class MainMenuSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {
        }

        #region Sizes

        /// <summary>
        /// Gets or sets the height of the menu.
        /// </summary>
        /// <value>The height of the menu.</value>
        [Category("Sizes"), Description("The height of the main menu.")]
        public virtual int Height
        {
            get
            {
                return this.GetValue<int>("Height", this.DefaultHeight);
            }
            set
            {
                this.SetValue("Height", value);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        internal void ResetHeight()
        {
            this.Reset("Height");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultHeight
        {
            get
            {
                return 22;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("Gets or sets the width of the left frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int LeftFrameWidth
        {
            get
            {
                return this.GetImageWidth(this.LeftFrameStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        internal void ResetLeftFrameWidth()
        {
            this.Reset("LeftFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("Gets or sets the width of the right frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int RightFrameWidth
        {
            get
            {
                return this.GetImageWidth(this.RightFrameStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        internal void ResetRightFrameWidth()
        {
            this.Reset("RightFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the seperator.
        /// </summary>
        /// <value>The width of the seperator.</value>
        [Category("Sizes"), Description("The width of the seperator.")]
        public virtual int SeperatorWidth
        {
            get
            {
                return this.GetValue<int>("SeperatorWidth", this.DefaultSeperatorWidth);
            }
            set
            {
                this.SetValue("SeperatorWidth", value);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        internal void ResetSeperatorWidth()
        {
            this.Reset("SeperatorWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultSeperatorWidth
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region Frame Styles

        /// <summary>
        /// Gets the top menu item hover style.
        /// </summary>
        /// <value>The top menu item hover style.</value>
        [Category("States"), Description("The top menu item hover style.")]
        public virtual SimpleFrameStyleValue FrameStyle
        {
            get
            {
                return new SimpleFrameStyleValue(
                    this.LeftFrameStyle,
                    this.RightFrameStyle,
                    this.CenterFrameStyle);
            }
        }

        /// <summary>
        /// Gets the right frame style.
        /// </summary>
        /// <value>The right frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left frame style.
        /// </summary>
        /// <value>The left frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center frame style.
        /// </summary>
        /// <value>The center frame style.</value>
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


        #endregion

        #region Tab Styles

        /// <summary>
        /// Gets the top menu item normal style.
        /// </summary>
        /// <value>The top menu item normal style.</value>
        [Category("States"), Description("The top menu item normal style.")]
        public virtual SimpleFrameStyleValue MenuItemNormalStyle
        {
            get
            {
                return new SimpleFrameStyleValue(
                    this.LeftMenuItemNormalStyle,
                    this.RightMenuItemNormalStyle,
                    this.CenterMenuItemNormalStyle);
            }
        }

        /// <summary>
        /// Gets the top menu item pressed style.
        /// </summary>
        /// <value>The top menu item pressed style.</value>
        [Category("States"), Description("The top menu item pressed style.")]
        public virtual SimpleFrameStyleValue MenuItemPressedStyle
        {
            get
            {
                return new SimpleFrameStyleValue(
                    this.LeftMenuItemPressedStyle,
                    this.RightMenuItemPressedStyle,
                    this.CenterMenuItemPressedStyle);
            }
        }


        /// <summary>
        /// Gets the top menu item hover style.
        /// </summary>
        /// <value>The top menu item hover style.</value>
        [Category("States"), Description("The top menu item hover style.")]
        public virtual SimpleFrameStyleValue MenuItemHoverStyle
        {
            get
            {
                return new SimpleFrameStyleValue(
                    this.LeftMenuItemHoverStyle,
                    this.RightMenuItemHoverStyle,
                    this.CenterMenuItemHoverStyle);
            }
        }

        /// <summary>
        /// Gets the top menu item disable style.
        /// </summary>
        /// <value>The top menu item disable style.</value>
        [Category("States"), Description("The top menu item disable style.")]
        public virtual SimpleFrameStyleValue MenuItemDisableStyle
        {
            get
            {
                return new SimpleFrameStyleValue(
                    this.LeftMenuItemDisableStyle,
                    this.RightMenuItemDisableStyle,
                    this.CenterMenuItemDisableStyle);
            }
        }        

        /// <summary>
        /// Gets the right menu item normal style.
        /// </summary>
        /// <value>The right menu item normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightMenuItemNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightMenuItemNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right menu item pressed style.
        /// </summary>
        /// <value>The right menu item pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightMenuItemPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightMenuItemPressedStyle", this.RightMenuItemNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right menu item hover style.
        /// </summary>
        /// <value>The right menu item hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightMenuItemHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightMenuItemHoverStyle", this.RightMenuItemNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left menu item normal style.
        /// </summary>
        /// <value>The left menu item normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftMenuItemNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftMenuItemNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left menu item pressed style.
        /// </summary>
        /// <value>The left menu item pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftMenuItemPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftMenuItemPressedStyle", this.LeftMenuItemNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left menu item hover style.
        /// </summary>
        /// <value>The left menu item hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftMenuItemHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftMenuItemHoverStyle", this.LeftMenuItemNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the width of the left menu item.
        /// </summary>
        /// <value>The width of the left menu item.</value>
        [Category("Sizes"), Description("The width of the left menu item.")]
        public virtual int LeftMenuItemWidth
        {
            get
            {
                return this.GetValue<int>("LeftMenuItemWidth", this.GetImageWidth(this.LeftMenuItemNormalStyle.BackgroundImage, 0));
            }
            set
            {
                this.SetValue("LeftMenuItemWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the right menu item.
        /// </summary>
        /// <value>The width of the right menu item.</value>
        [Category("Sizes"), Description("The width of the right menu item.")]
        public virtual int RightMenuItemWidth
        {
            get
            {
                return this.GetValue<int>("RightMenuItemWidth", this.GetImageWidth(this.RightMenuItemNormalStyle.BackgroundImage, 0));
            }
            set
            {
                this.SetValue("RightMenuItemWidth", value);
            }
        }

        /// <summary>
        /// Gets the center menu item normal style.
        /// </summary>
        /// <value>The center menu item normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterMenuItemNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterMenuItemNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center menu item pressed style.
        /// </summary>
        /// <value>The center menu item pressed style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterMenuItemPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterMenuItemPressedStyle", this.CenterMenuItemNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center menu item hover style.
        /// </summary>
        /// <value>The center menu item hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterMenuItemHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterMenuItemHoverStyle", this.CenterMenuItemNormalStyle);
                return objStyle;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue LeftMenuItemDisableStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LeftMenuItemDisableStyle", this.LeftMenuItemNormalStyle);
                return objStyle;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterMenuItemDisableStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterMenuItemDisableStyle", this.CenterMenuItemNormalStyle);
                return objStyle;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue RightMenuItemDisableStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "RightMenuItemDisableStyle", this.RightMenuItemNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the seperator style.
        /// </summary>
        /// <value>The seperator style.</value>
        public virtual StyleValue SeperatorStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SeperatorStyle");
                return objStyle;
            }
        }

        #endregion
    }
}
