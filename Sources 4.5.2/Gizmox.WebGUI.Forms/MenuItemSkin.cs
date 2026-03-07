using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using System.Drawing;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Menu Item Skin
    /// </summary>    

    [ToolboxBitmapAttribute(typeof(Menu), "MainMenu.bmp"), Serializable()]
    public class MenuItemSkin : ControlSkin
    {
        private void InitializeComponent()
        {

        }

        #region Styles

        #region Background

        /// <summary>
        /// Gets the menu item Background LTR.
        /// </summary>
        /// <value>The menu item Background LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundStyleValue BackgroundLTR
        {
            get
            {
                BackgroundStyleValue objStyle = new BackgroundStyleValue(this, "BackgroundLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item Background RTL.
        /// </summary>
        /// <value>The menu item Background RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundStyleValue BackgroundRTL
        {
            get
            {
                BackgroundStyleValue objStyle = new BackgroundStyleValue(this, "BackgroundRTL", this.BackgroundLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item background.
        /// </summary>
        /// <value>The background.</value>
        [Category("States"), Description("The menu item Background.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<BackgroundStyleValue> MenuItemBackground
        {
            get
            {
                return new BidirectionalSkinValue<BackgroundStyleValue>(this, this.BackgroundLTR, this.BackgroundRTL);
            }
        }

        #endregion

        #region Seperator

        /// <summary>
        /// Gets the menu item seperator row.
        /// </summary>
        /// <value>The menu item seperator row.</value>
        [Category("States"), Description("The menu item seperator row style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue MenuItemSeperator
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemSeperator");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the seperator icon column.
        /// </summary>
        /// <value>The seperator icon column.</value>
        [Category("States"), Description("The seperator icon column style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SeperatorIconColumn
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SeperatorIconColumn");
                return objStyle;
            }
        }

        #endregion

        #region Menu item

        #region Normal

        /// <summary>
        /// Gets the menu item normal.
        /// </summary>
        /// <value>The menu item normal.</value>
        [Category("States"), Description("The item  normal  style.")]
        public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemNormal
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, MenuItemNormalLTR, MenuItemNormalRTL);
            }
        }

        /// <summary>
        /// Gets the item row normal LTR style.
        /// </summary>
        /// <value>The item row normal LTR style.</value>
        [Category("States"), Description("The item  normal LTR style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemNormalLTR
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemNormalLeftLTR,
                                            this.MenuItemNormalRightLTR,
                                           this.MenuItemNormalCenterLTR);
            }
        }

        /// <summary>
        /// Gets the item row normal RTL style.
        /// </summary>
        /// <value>The item row normal RTL style.</value>
        [Category("States"), Description("The item  normal RTL style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemNormalRTL
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemNormalLeftRTL,
                                            this.MenuItemNormalRightRTL,
                                           this.MenuItemNormalCenterRTL);
            }
        }

        /// <summary>
        /// Gets the item row normal left LTR style.
        /// </summary>
        /// <value>The item row normal left LTR style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemNormalLeftLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemNormalLeftLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item row normal left RTL style.
        /// </summary>
        /// <value>The item row normal left RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemNormalLeftRTL
        {

            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemNormalLeftRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item normal left.
        /// </summary>
        /// <value>The menu item normal left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemNormalLeft
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemNormalLeftLTR, this.MenuItemNormalLeftRTL);
            }
        }

        /// <summary>
        /// Gets the item row normal right LTR style.
        /// </summary>
        /// <value>The item row normal right LTR style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemNormalRightLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemNormalRightLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item row normal right RTL style.
        /// </summary>
        /// <value>The item row normal right RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemNormalRightRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemNormalRightRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item normal right.
        /// </summary>
        /// <value>The menu item normal right.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemNormalRight
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemNormalRightLTR, this.MenuItemNormalRightRTL);
            }
        }

        /// <summary>
        /// Gets the item row normal center LTR style.
        /// </summary>
        /// <value>The item row normal center LTR style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemNormalCenterLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemNormalCenterLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item row normal center RTL style.
        /// </summary>
        /// <value>The item row normal center RTL style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemNormalCenterRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemNormalCenterRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item normal center.
        /// </summary>
        /// <value>The menu item normal center.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemNormalCenter
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemNormalCenterLTR, this.MenuItemNormalCenterRTL);
            }
        }

        #endregion

        #region Hover


        /// <summary>
        /// Gets the menu item hover.
        /// </summary>
        /// <value>The menu item hover.</value>
        [Category("States"), Description("The item  hover  style.")]
        public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemHover
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, MenuItemHoverLTR, MenuItemHoverRTL);
            }
        }

        /// <summary>
        /// Gets the item row hover LTR style.
        /// </summary>
        /// <value>The item row hover LTR style.</value>
        [Category("States"), Description("The item  Hover LTR style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemHoverLTR
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemHoverLeftLTR,
                                            this.MenuItemHoverRightLTR,
                                           this.MenuItemHoverCenterLTR);
            }
        }

        /// <summary>
        /// Gets the item row hover RTL style.
        /// </summary>
        /// <value>The item row hover RTL style.</value>
        [Category("States"), Description("The item  Hover RTL style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemHoverRTL
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemHoverLeftRTL,
                                            this.MenuItemHoverRightRTL,
                                           this.MenuItemHoverCenterRTL);
            }
        }

        /// <summary>
        /// Gets the menu item row hover left LTR style.
        /// </summary>
        /// <value>The menu item row hover left LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemHoverLeftLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverLeftLTR", this.MenuItemNormalLeftLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item row hover left RTL style.
        /// </summary>
        /// <value>The menu item row hover left RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemHoverLeftRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverLeftRTL", this.MenuItemNormalLeftRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item hover left.
        /// </summary>
        /// <value>The menu item hover left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemHoverLeft
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemHoverLeftLTR, this.MenuItemHoverLeftRTL);
            }
        }

        /// <summary>
        /// Gets the menu item row hover right LTR style.
        /// </summary>
        /// <value>The menu item row hover right LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemHoverRightLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverRightLTR", this.MenuItemNormalRightLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item row hover right RTL style.
        /// </summary>
        /// <value>The menu item row hover right RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemHoverRightRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverRightRTL", this.MenuItemNormalRightRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item hover right.
        /// </summary>
        /// <value>The menu item hover right.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemHoverRight
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemHoverRightLTR, this.MenuItemHoverRightRTL);
            }
        }

        /// <summary>
        /// Gets the menu item row hover center LTR style.
        /// </summary>
        /// <value>The menu item row hover center LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemHoverCenterLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverCenterLTR", this.MenuItemNormalCenterLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item row hover center RTL style.
        /// </summary>
        /// <value>The menu item row hover center RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemHoverCenterRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverCenterRTL", this.MenuItemNormalCenterRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item hover center.
        /// </summary>
        /// <value>The menu item hover center.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemHoverCenter
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemHoverCenterLTR, this.MenuItemHoverCenterRTL);
            }
        }

        #endregion

        #region Down

        /// <summary>
        /// Gets the menu item down.
        /// </summary>
        /// <value>The menu item down.</value>
        [Category("States"), Description("The item  down  style.")]
        public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemDown
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, MenuItemDownLTR, MenuItemDownRTL);
            }
        }


        /// <summary>
        /// Gets the item row down LTR style.
        /// </summary>
        /// <value>The item row down LTR style.</value>
        [Category("States"), Description("The item down LTR style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemDownLTR
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemDownLeftLTR,
                                            this.MenuItemDownRightLTR,
                                           this.MenuItemDownCenterLTR);
            }
        }

        /// <summary>
        /// Gets the item row down RTL style.
        /// </summary>
        /// <value>The item row down RTL style.</value>
        [Category("States"), Description("The item  down RTL style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemDownRTL
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemDownLeftRTL,
                                            this.MenuItemDownRightRTL,
                                           this.MenuItemDownCenterRTL);
            }
        }

        /// <summary>
        /// Gets the menu item row down left LTR style.
        /// </summary>
        /// <value>The menu item row down left LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDownLeftLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownLeftLTR", this.MenuItemNormalLeftLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item row down left RTL style.
        /// </summary>
        /// <value>The menu item row down left RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDownLeftRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownLeftRTL", this.MenuItemNormalLeftRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item down left.
        /// </summary>
        /// <value>The menu item down Left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemDownLeft
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemDownLeftLTR, this.MenuItemDownLeftRTL);
            }
        }

        /// <summary>
        /// Gets the menu item row down right LTR style.
        /// </summary>
        /// <value>The menu item row down right LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDownRightLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownRightLTR", this.MenuItemNormalRightLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item row down right style RTL.
        /// </summary>
        /// <value>The menu item row down right RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDownRightRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownRightRTL", this.MenuItemNormalRightRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item down right.
        /// </summary>
        /// <value>The menu item down right.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemDownRight
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemDownRightLTR, this.MenuItemDownRightRTL);
            }
        }

        /// <summary>
        /// Gets the menu item row down center style LTR.
        /// </summary>
        /// <value>The menu item row down center LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDownCenterLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownCenterLTR", this.MenuItemNormalCenterLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item row down center style RTL.
        /// </summary>
        /// <value>The menu item row down center RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDownCenterRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownCenterRTL", this.MenuItemNormalCenterRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item down center.
        /// </summary>
        /// <value>The menu item down center.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemDownCenter
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemDownCenterLTR, this.MenuItemDownCenterRTL);
            }
        }

        #endregion

        #region Disable


        /// <summary>
        /// Gets the menu item disable.
        /// </summary>
        /// <value>The menu item disable.</value>
        [Category("States"), Description("The item disable style.")]
        public BidirectionalSkinValue<TripleCellFrameStyleValue> MenuItemDisable
        {
            get
            {
                return new BidirectionalSkinValue<TripleCellFrameStyleValue>(this, this.MenuItemDisableLTR, this.MenuItemDisableRTL);
            }
        }

        /// <summary>
        /// Gets the item row disable LTR style.
        /// </summary>
        /// <value>The item row disable LTR style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemDisableLTR
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemDisableLeftLTR,
                                            this.MenuItemDisableRightLTR,
                                           this.MenuItemDisableCenterLTR);
            }
        }

        /// <summary>
        /// Gets the item row disable RTL style.
        /// </summary>
        /// <value>The item row disable RTL style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public virtual TripleCellFrameStyleValue MenuItemDisableRTL
        {
            get
            {
                return new TripleCellFrameStyleValue(this.MenuItemDisableLeftRTL,
                                            this.MenuItemDisableRightRTL,
                                           this.MenuItemDisableCenterRTL);
            }
        }

        /// <summary>
        /// Gets the menu item Disable LTR.
        /// </summary>
        /// <value>The menu item Disable LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDisableLeftLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDisableLeftLTR", this.MenuItemNormalLeftLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item Disable RTL.
        /// </summary>
        /// <value>The menu item Disable RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDisableLeftRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDisableLeftRTL", this.MenuItemNormalLeftRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item down left.
        /// </summary>
        /// <value>The menu item down left.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemDisableLeft
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemDisableLeftLTR, this.MenuItemDisableLeftRTL);
            }
        }

        /// <summary>
        /// Gets the menu item Disable LTR.
        /// </summary>
        /// <value>The menu item Disable LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDisableRightLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDisableRightLTR", this.MenuItemNormalRightLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item Disable RTL.
        /// </summary>
        /// <value>The menu item Disable RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDisableRightRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDisableRightRTL", this.MenuItemNormalRightRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item disable right.
        /// </summary>
        /// <value>The menu item disable right.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemDisableRight
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemDisableRightLTR, this.MenuItemDisableRightRTL);
            }
        }

        /// <summary>
        /// Gets the menu item Disable LTR.
        /// </summary>
        /// <value>The menu item Disable LTr.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDisableCenterLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDisableCenterLTR", this.MenuItemNormalCenterLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item Disable RTL.
        /// </summary>
        /// <value>The menu item Disable RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemDisableCenterRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDisableCenterRTL", this.MenuItemNormalCenterRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item disable center.
        /// </summary>
        /// <value>The menu item disable center.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue MenuItemDisableCenter
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemDisableCenterLTR, this.MenuItemDisableCenterRTL);
            }
        }

        #endregion


        #endregion

        #region Menu Item Label

        /// <summary>
        /// Gets the menu item label normal style .
        /// </summary>
        /// <value>The menu item label normal style.</value>
        [Category("States"), SRDescription("Menu item label normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemLabelNormalStyleLTR, this.MenuItemLabelNormalStyleRTL);
            }
        }


        /// <summary>
        /// Gets the menu item label normal style LTR.
        /// </summary>
        /// <value>The menu item label normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelNormalStyleLTR", this.MenuItemNormalCenterLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item label normal style RTL.
        /// </summary>
        /// <value>The menu item label normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelNormalStyleRTL", this.MenuItemNormalCenterRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item label hover style .
        /// </summary>
        /// <value>The menu item label hover style.</value>
        [Category("States"), SRDescription("Menu item label hover style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemLabelHoverStyleLTR, this.MenuItemLabelHoverStyleRTL);
            }
        }


        /// <summary>
        /// Gets the menu item label hover style LTR.
        /// </summary>
        /// <value>The menu item label hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelHoverStyleLTR", this.MenuItemLabelNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item label hover style RTL.
        /// </summary>
        /// <value>The menu item label hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelHoverStyleRTL", this.MenuItemLabelNormalStyleRTL);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the menu item label down style .
        /// </summary>
        /// <value>The menu item label down style.</value>
        [Category("States"), SRDescription("Menu item label down style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelDownStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemLabelDownStyleLTR, this.MenuItemLabelDownStyleRTL);
            }
        }

        /// <summary>
        /// Gets the menu item label down style LTR.
        /// </summary>
        /// <value>The menu item label down style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelDownStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelDownStyleLTR", this.MenuItemLabelNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item label down style RTL.
        /// </summary>
        /// <value>The menu item label down style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelDownStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelDownStyleRTL", this.MenuItemLabelNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item label Disable style .
        /// </summary>
        /// <value>The menu item label Disable style.</value>
        [Category("States"), SRDescription("Menu item label disable style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> MenuItemLabelDisableStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemLabelDisableStyleLTR, this.MenuItemLabelDisableStyleRTL);
            }
        }


        /// <summary>
        /// Gets the menu item label disable style LTR.
        /// </summary>
        /// <value>The menu item label disable style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelDisableStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelDisableStyleLTR", this.MenuItemLabelNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item label disable style RTL.
        /// </summary>
        /// <value>The menu item label disable style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemLabelDisableStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemLabelDisableStyleRTL", this.MenuItemLabelNormalStyleRTL);
                return objStyle;
            }
        }

        #endregion

        #region Menu Item Icon

        /// <summary>
        /// Gets the menu item Icon LTR Padding.
        /// </summary>
        /// <value>The menu item Icon LTR Padding.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual PaddingValue MenuItemIconPaddingLTR
        {
            get
            {
                return this.GetValue<PaddingValue>("MenuItemIconPaddingLTR", new PaddingValue(new Padding(2, 3, 0, 0)));
            }
            set
            {
                this.SetValue("MenuItemIconPaddingLTR", value);
            }
        }

        /// <summary>
        /// Gets the menu item Icon RTL Padding.
        /// </summary>
        /// <value>The menu item Icon RTL Padding.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual PaddingValue MenuItemIconPaddingRTL
        {
            get
            {
                return this.GetValue<PaddingValue>("MenuItemIconPaddingRTL", new PaddingValue(new Padding(0, 3, 2, 0)));
            }
            set
            {
                this.SetValue("MenuItemIconPaddingRTL", value);
            }
        }

        /// <summary>
        /// Gets the menu item Icon Padding.
        /// </summary>
        /// <value>The menu item Icon Padding.</value>
        [Category("Padding"), Description("The menu item Icon Padding.")]
        public BidirectionalSkinValue<PaddingValue> MenuItemIconPadding
        {
            get
            {
                return new BidirectionalSkinValue<PaddingValue>(this, this.MenuItemIconPaddingLTR, this.MenuItemIconPaddingRTL);
            }
        }

        #endregion

        #region Menu Item Arrow

        /// <summary>
        /// Gets the menu item arrow LTR Padding.
        /// </summary>
        /// <value>The menu item arrow LTR Padding.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual PaddingValue MenuItemArrowPaddingLTR
        {
            get
            {
                return this.GetValue<PaddingValue>("MenuItemArrowPaddingLTR", new PaddingValue(new Padding(0, 7, 2, 0)));
            }
            set
            {
                this.SetValue("MenuItemArrowPaddingLTR", value);
            }
        }

        /// <summary>
        /// Gets the menu item arrow RTL Padding.
        /// </summary>
        /// <value>The menu item arrow RTL Padding.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual PaddingValue MenuItemArrowPaddingRTL
        {
            get
            {
                return this.GetValue<PaddingValue>("MenuItemArrowPaddingRTL", new PaddingValue(new Padding(0, 7, 2, 0)));
            }
            set
            {
                this.SetValue("MenuItemArrowPaddingRTL", value);
            }
        }

        /// <summary>
        /// Gets the menu item arrow Bidirectional style.
        /// </summary>
        /// <value>The menu item arrow Bidirectional style.</value>
        [Category("Padding"), Description("The menu item arrow Padding.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinValue<PaddingValue> MenuItemArrowPadding
        {
            get
            {
                return new BidirectionalSkinValue<PaddingValue>(this, this.MenuItemArrowPaddingLTR, this.MenuItemArrowPaddingRTL);
            }
        }

        #endregion

        #region Menu Item Shortcut

        /// <summary>
        /// Gets the menu item Shortcut normal style .
        /// </summary>
        /// <value>The menu item Shortcut normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BidirectionalSkinValue<StyleValue> MenuItemShortcutNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemShortcutNormalStyleLTR, this.MenuItemShortcutNormalStyleRTL);
            }
        }


        /// <summary>
        /// Gets the menu item shortcut normal style LTR.
        /// </summary>
        /// <value>The menu item shortcut normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutNormalStyleLTR", this.MenuItemNormalCenterLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item shortcut normal style RTL.
        /// </summary>
        /// <value>The menu item shortcut normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutNormalStyleRTL", this.MenuItemNormalCenterRTL);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the menu item Shortcut hover style .
        /// </summary>
        /// <value>The menu item Shortcut hover style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual SkinValue MenuItemShortcutHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemShortcutHoverStyleLTR, this.MenuItemShortcutHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the menu item shortcut hover style LTR.
        /// </summary>
        /// <value>The menu item shortcut hover style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutHoverStyleLTR", this.MenuItemShortcutNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item shortcut hover style RTL.
        /// </summary>
        /// <value>The menu item shortcut hover style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutHoverStyleRTL", this.MenuItemShortcutNormalStyleRTL);
                return objStyle;
            }
        }



        /// <summary>
        /// Gets the menu item Shortcut down style .
        /// </summary>
        /// <value>The menu item Shortcut down style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual SkinValue MenuItemShortcutDownStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemShortcutDownStyleLTR, this.MenuItemShortcutDownStyleRTL);
            }
        }

        /// <summary>
        /// Gets the menu item shortcut down style LTR.
        /// </summary>
        /// <value>The menu item shortcut down style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutDownStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutDownStyleLTR", this.MenuItemShortcutNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item shortcut down style RTL.
        /// </summary>
        /// <value>The menu item shortcut down style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutDownStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutDownStyleRTL", this.MenuItemShortcutNormalStyleRTL);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item Shortcut Disable style .
        /// </summary>
        /// <value>The menu item Shortcut Disable style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual SkinValue MenuItemShortcutDisableStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemShortcutDisableStyleLTR, this.MenuItemShortcutDisableStyleRTL);
            }
        }

        /// <summary>
        /// Gets the menu item shortcut disable style LTR.
        /// </summary>
        /// <value>The menu item shortcut disable style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutDisableStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutDisableStyleLTR", this.MenuItemShortcutNormalStyleLTR);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item shortcut disable style RTL.
        /// </summary>
        /// <value>The menu item shortcut disable style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue MenuItemShortcutDisableStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemShortcutDisableStyleRTL", this.MenuItemShortcutNormalStyleRTL);
                return objStyle;
            }
        }

        #endregion

        #endregion

        #region Sizes

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>The height of the item.</value>
        [Category("Sizes"), Description("The height of a item.")]
        public int Height
        {
            get
            {
                return this.GetValue<int>("Height", this.DefaultItemHeight);
            }
            set
            {
                this.SetValue("Height", value);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        internal void ResetItemHeight()
        {
            this.Reset("Height");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultItemHeight
        {
            get
            {
                return 22;
            }
        }

        /// <summary>
        /// Gets or sets the height of the seperator.
        /// </summary>
        /// <value>The height of the seperator.</value>
        [Category("Sizes"), Description("The height of the seperator.")]
        public int SeperatorHeight
        {
            get
            {
                return this.GetValue<int>("SeperatorRowHeight", this.DefaultSeperatorRowHeight);
            }
            set
            {
                this.SetValue("SeperatorRowHeight", value);
            }
        }

        /// <summary>
        /// Resets the seperator row height
        /// </summary>
        internal void ResetSeperatorRowHeight()
        {
            this.Reset("SeperatorRowHeight");
        }

        /// <summary>
        /// Gets default Seperator row height
        /// </summary>
        protected virtual int DefaultSeperatorRowHeight
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets the arrow image width LTR.
        /// </summary>
        /// <value>The arrow image width LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int ArrowImageWidthLTR
        {
            get
            {
                return this.GetImageWidth(this.ArrowImageLTR, 7);
            }
        }

        /// <summary>
        /// Gets the arrow image width RTL.
        /// </summary>
        /// <value>The arrow image width RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int ArrowImageWidthRTL
        {
            get
            {
                return this.GetImageWidth(this.ArrowImageRTL, 7);
            }
        }

        /// <summary>
        /// Gets the width of the arrow image.
        /// </summary>
        /// <value>The width of the arrow image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SkinValue ArrowImageWidth
        {
            get
            {
                return new BidirectionalSkinValue<int>(this, ArrowImageWidthLTR, ArrowImageWidthRTL);
            }
        }

        /// <summary>
        /// Gets the width of the menu item icons column.
        /// </summary>
        /// <value>The width of the menu item icons column.</value>
        [Category("Sizes"), Description("The width of the menu item icons column.")]
        public int MenuItemIconsColumnWidth
        {
            get
            {
                return this.GetValue<int>("MenuItemIconsColumnWidth", this.DefaultMenuItemIconsColumnWidth);
            }
            set
            {
                this.SetValue("MenuItemIconsColumnWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the menu item icons column.
        /// </summary>
        internal void ResetMenuItemIconsColumnWidth()
        {
            this.Reset("MenuItemIconsColumnWidth");
        }

        /// <summary>
        /// Gets the default width of the menu item icons column.
        /// </summary>
        /// <value>The default width of the menu item icons column.</value>
        protected virtual int DefaultMenuItemIconsColumnWidth
        {
            get
            {
                return 32;
            }
        }

        /// <summary>
        /// Gets the menu item highlight left width LTR.
        /// </summary>
        /// <value>The menu item highlight left width LTR.</value>
        [Category("Sizes"), Description("The width of the LTR menu item Highlight Left column Width")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int MenuItemHighlightLeftWidthLTR
        {
            get
            {
                return this.GetImageWidth(this.MenuItemHoverLTR.LeftStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the menu item highlight left width RTL.
        /// </summary>
        /// <value>The menu item highlight left width RTL.</value>
        [Category("Sizes"), Description("The width of the RTL menu item Highlight Left column Width")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int MenuItemHighlightLeftWidthRTL
        {
            get
            {
                return this.GetImageWidth(this.MenuItemHoverRTL.LeftStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the width of the menu item Highlight Left column Width
        /// </summary>
        /// <value>The width of the menu item Highlight Left column Width.</value>
        [Category("Sizes"), Description("The width of the menu item Highlight Left column Width")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BidirectionalSkinProperty<int> MenuItemHighlightLeftWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "MenuItemHighlightLeftWidthLTR", "MenuItemHighlightLeftWidthRTL");
            }
        }

        /// <summary>
        /// Gets the menu item highlight right width LTR.
        /// </summary>
        /// <value>The menu item highlight right width LTR.</value>
        [Category("Sizes"), Description("The width of the LTR menu item Highlight Right column Width")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int MenuItemHighlightRightWidthLTR
        {
            get
            {
                return this.GetImageWidth(this.MenuItemHoverLTR.RightStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the menu item highlight right width RTL.
        /// </summary>
        /// <value>The menu item highlight right width RTL.</value>
        [Category("Sizes"), Description("The width of the RTL menu item Highlight Right column Width")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int MenuItemHighlightRightWidthRTL
        {
            get
            {
                return this.GetImageWidth(this.MenuItemHoverRTL.RightStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the width of the menu item Highlight Right column Width
        /// </summary>
        /// <value>The width of the menu item Highlight Right column Width.</value>
        [Category("Sizes"), Description("The width of the menu item Highlight Right column Width")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BidirectionalSkinProperty<int> MenuItemHighlightRightWidth
        {
            get
            {
                return new BidirectionalSkinProperty<int>(this, "MenuItemHighlightRightWidthLTR", "MenuItemHighlightRightWidthRTL");
            }
        }

        #endregion

        #region images

        /// <summary>
        /// Gets or sets menu item the checked image.
        /// </summary>
        /// <value>The checked image.</value>
        [Description("Menu item checked image")]
        [Category("Images")]
        public ImageResourceReference CheckedImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("CheckedImage", (string)new ImageResourceReference(typeof(MenuItemSkin), "Checked.gif"));
            }
            set
            {
                this.SetValue("CheckedImage", value);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        internal void ResetCheckedImage()
        {
            this.Reset("CheckedImage");
        }

        /// <summary>
        /// Gets or sets menu item the checked Disable image.
        /// </summary>
        /// <value>The checked Disable image.</value>
        [Description("Menu item checked Disable image")]
        [Category("Images")]
        public ImageResourceReference CheckedImageDisable
        {
            get
            {
                return this.GetValue<ImageResourceReference>("CheckedImageDisable", (string)new ImageResourceReference(typeof(MenuItemSkin), "CheckedDisabled.gif"));
            }
            set
            {
                this.SetValue("CheckedImageDisable", value);
            }
        }

        /// <summary>
        /// Gets or sets the radio checked image.
        /// </summary>
        /// <value>The radio checked image.</value>
        [Description("Menu item radio checked image")]
        [Category("Images")]
        public ImageResourceReference RadioCheckedImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RadioCheckedImage", (string)new ImageResourceReference(typeof(MenuItemSkin), "RadioChecked.gif"));
            }
            set
            {
                this.SetValue("RadioCheckedImage", value);
            }
        }

        /// <summary>
        /// Gets or sets the radio checked Disable image.
        /// </summary>
        /// <value>The radio checked Disable image.</value>
        [Description("Menu item radio checked Disable image")]
        [Category("Images")]
        public ImageResourceReference RadioCheckedImageDisable
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RadioCheckedImageDisable", (string)new ImageResourceReference(typeof(MenuItemSkin), "RadioCheckedDisabled.gif"));
            }
            set
            {
                this.SetValue("RadioCheckedImageDisable", value);
            }
        }

        /// <summary>
        /// Gets or sets the arrow image LTR.
        /// </summary>
        /// <value>The arrow image LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageResourceReference ArrowImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ArrowImageLTR", (string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowLTR.gif"));
            }
            set
            {
                this.SetValue("ArrowImageLTR", value);
            }

        }

        /// <summary>
        /// Gets or sets the arrow image RTL.
        /// </summary>
        /// <value>The arrow image RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageResourceReference ArrowImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ArrowImageRTL", (string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowRTL.gif"));
            }
            set
            {
                this.SetValue("ArrowImageRTL", value);
            }

        }

        /// <summary>
        /// Gets or sets the arrow image Bidirectional.
        /// </summary>
        /// <value>The arrow image Bidirectional.</value>
        [Category("Images"), Description("The menu item arrow image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> ArrowImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "ArrowImageLTR", "ArrowImageRTL");
            }
        }

        /// <summary>
        /// Gets or sets the arrow Disable image LTR.
        /// </summary>
        /// <value>The arrow image Disable LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageResourceReference ArrowImageLTRDisabled
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ArrowImageLTRDisabled", (string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowLTRDisabled.gif"));
            }
            set
            {
                this.SetValue("ArrowImageLTRDisabled", value);
            }

        }

        /// <summary>
        /// Gets or sets the arrow Disable image RTL.
        /// </summary>
        /// <value>The arrow Disable image RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageResourceReference ArrowImageRTLDisabled
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ArrowImageRTLDisabled", (string)new ImageResourceReference(typeof(MenuItemSkin), "ArrowRTLDisabled.gif"));

            }
            set
            {
                this.SetValue("ArrowImageRTLDisabled", value);
            }

        }

        /// <summary>
        /// Gets or sets the arrow Disable image Bidirectional.
        /// </summary>
        /// <value>The arrow Disable image Bidirectional.</value>
        [Category("Images"), Description("The menu item disable arrow image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> ArrowImageDisabled
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "ArrowImageLTRDisabled", "ArrowImageRTLDisabled");
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageResourceReference BackgroundImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("BackgroundImage", "");
            }
            set
            {
                this.SetValue("BackgroundImage", value);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BackgroundImageRepeat BackgroundImageRepeat
        {
            get
            {
                return this.GetValue<BackgroundImageRepeat>("BackgroundImageRepeat", BackgroundImageRepeat.Repeat);
            }
            set
            {
                this.SetValue("BackgroundImageRepeat", value);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BackgroundImagePosition BackgroundImagePosition
        {
            get
            {
                return this.GetValue<BackgroundImagePosition>("BackgroundImagePosition", BackgroundImagePosition.MiddleCenter);
            }
            set
            {
                this.SetValue("BackgroundImagePosition", value);
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderWidth BorderWidth
        {
            get
            {
                return base.BorderWidth;
            }
            set
            {
                base.BorderWidth = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderColor BorderColor
        {
            get
            {
                return base.BorderColor;
            }
            set
            {
                base.BorderColor = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BorderStyle BorderStyle
        {
            get
            {
                return this.GetValue<BorderStyle>("BorderStyle", BorderStyle.FixedSingle);
            }
            set
            {
                this.SetValue("BorderStyle", value);
            }
        }

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
    }
}
