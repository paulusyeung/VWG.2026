using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    public class ToolStripMenuItemSkin : ControlSkin
    {
        /// <summary>
        /// Gets the tool strip menu item style.
        /// </summary>
        /// <value>The tool strip menu item style.</value>
        [Category("States"), SRDescription("The tool strip menu item style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item hover style.
        /// </summary>
        /// <value>The menu item hover style.</value>
        [Category("States"), SRDescription("The tool strip menu item over style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemHoverStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item down style.
        /// </summary>
        /// <value>The menu item down style.</value>
        [Category("States"), SRDescription("The tool strip menu item down style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemDownStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the disabled menu item style.
        /// </summary>
        /// <value>The disabled menu item style.</value>
        [Category("States"), SRDescription("The tool strip menu item disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue DisabledMenuItemTextStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DisabledMenuItemTextStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the arrow image width LTR.
        /// </summary>
        /// <value>The arrow image width LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int MenuItemArrowImageWidthLTR
        {
            get
            {
                return this.GetImageWidth(this.MenuItemArrowLTR.BackgroundImage, 7);
            }
        }

        /// <summary>
        /// Gets the arrow image width RTL.
        /// </summary>
        /// <value>The arrow image width RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int MenuItemArrowImageWidthRTL
        {
            get
            {
                return this.GetImageWidth(this.MenuItemArrowRTL.BackgroundImage, 7);
            }
        }

        /// <summary>
        /// Gets the width of the arrow image.
        /// </summary>
        /// <value>The width of the arrow image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SkinValue MenuItemArrowImageWidth
        {
            get
            {
                return new BidirectionalSkinValue<int>(this, MenuItemArrowImageWidthLTR, MenuItemArrowImageWidthRTL);
            }
        }

        /// <summary>
        /// Gets the menu item image style.
        /// </summary>
        /// <value>The menu item image style.</value>
        [Category("States"), SRDescription("The menu item image style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinValue<StyleValue> MenuItemImageStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemImageStyleLTR, this.MenuItemImageStyleRTL);
            }
        }

        /// <summary>
        /// Gets the menu item image style LTR.
        /// </summary>
        /// <value>The menu item image style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue MenuItemImageStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemImageStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item image style RTL.
        /// </summary>
        /// <value>The menu item image style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue MenuItemImageStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemImageStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the width of the tool strip menu item image.
        /// </summary>
        /// <value>The width of the tool strip menu item image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SkinValue MenuItemImageWidth
        {
            get
            {
                return new BidirectionalSkinValue<int>(this, this.MenuItemImageWidthLTR, this.MenuItemImageWidthRTL);
            }
        }

        /// <summary>
        /// Gets the tool strip menu item image width LTR.
        /// </summary>
        /// <value>The tool strip menu item image width LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int MenuItemImageWidthLTR
        {
            get
            {
                return this.GetImageWidth(this.MenuItemImageStyleLTR.BackgroundImage, 32);
            }
        }

        /// <summary>
        /// Gets the tool strip menu item image width RTL.
        /// </summary>
        /// <value>The tool strip menu item image width RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int MenuItemImageWidthRTL
        {
            get
            {
                return this.GetImageWidth(this.MenuItemImageStyleRTL.BackgroundImage, 32);
            }
        }

        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets the menu item arrow.
        /// </summary>
        /// <value>The menu item arrow.</value>
        [Category("States"), SRDescription("The menu item arrow style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinValue<StyleValue> MenuItemArrow
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemArrowLTR, this.MenuItemArrowRTL);
            }
        }

        /// <summary>
        /// Gets the menu item arrow LTR.
        /// </summary>
        /// <value>The menu item arrow LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue MenuItemArrowLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemArrowLTR");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the menu item arrow RTL.
        /// </summary>
        /// <value>The menu item arrow RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue MenuItemArrowRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemArrowRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item arrow disabled.
        /// </summary>
        /// <value>The menu item arrow disabled.</value>
        [Category("States"), SRDescription("The menu item arrow disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinValue<StyleValue> MenuItemArrowDisabled
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.MenuItemArrowDisabledLTR, this.MenuItemArrowDisabledRTL);
            }
        }

        /// <summary>
        /// Gets the menu item arrow disabled LTR.
        /// </summary>
        /// <value>The menu item arrow disabled LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue MenuItemArrowDisabledLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemArrowDisabledLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item arrow disabled RTL.
        /// </summary>
        /// <value>The menu item arrow disabled RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue MenuItemArrowDisabledRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemArrowDisabledRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item checked.
        /// </summary>
        /// <value>The menu item checked.</value>
        [Category("States"), SRDescription("The menu item checked style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemChecked
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemChecked");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the menu item checked disabled.
        /// </summary>
        /// <value>The menu item checked disabled.</value>
        [Category("States"), SRDescription("The menu item checked disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemCheckedDisabled
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemCheckedDisabled");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item indeterminate.
        /// </summary>
        /// <value>The menu item indeterminate.</value>
        [Category("States"), SRDescription("The menu item indeterminate style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemIndeterminate
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemIndeterminate");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the menu item indeterminate disabled.
        /// </summary>
        /// <value>The menu item indeterminate disabled.</value>
        [Category("States"), SRDescription("The menu item indeterminate disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue MenuItemIndeterminateDisabled
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "MenuItemIndeterminateDisabled");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the size of the text image gap.
        /// </summary>
        /// <value>The size of the text image gap.</value>
        [Category("Sizes"), SRDescription("The size of the gap between text and image elements.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int TextImageGapSize
        {
            get
            {
                return this.GetValue<int>("TextImageGapSize", this.DefaultTextImageGapSize);
            }
            set
            {
                this.SetValue("TextImageGapSize", value);
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels to add to the calculated max image width to allow spacing around images
        /// </summary>
        /// <value>The extra width in pixels added for image area in addition to calculated image width.</value>
        [Category("Sizes"), SRDescription("The extra width in pixels added for image area in addition to calculated image width.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(4)]
        public int MenuItemImageExtraWidth
        {
            get
            {
                return this.GetValue<int>("MenuItemImageExtraWidth", 4);
            }
            set
            {
                this.SetValue("MenuItemImageExtraWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the text image gap.
        /// </summary>
        /// <value>The size of the text image gap.</value>
        [Category("Sizes"), SRDescription("The padding between the arrow and the end of the menu item.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ArrowEdgeGapSize
        {
            get
            {
                return this.GetValue<int>("ArrowEdgeGapSize", 3);
            }
            set
            {
                this.SetValue("ArrowEdgeGapSize", value);
            }
        }

        /// <summary>
        /// Gets the size of the default text image gap.
        /// </summary>
        /// <value>The size of the default text image gap.</value>
        private int DefaultTextImageGapSize
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Gets or sets the size of the text shortcut gap.
        /// </summary>
        /// <value>
        /// The size of the text shortcut gap.
        /// </value>
        [Category("Sizes"), SRDescription("The size of the gap between text and its shortcut.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int TextShortcutGapSize
        {
            get
            {
                return this.GetValue<int>("TextShortcutGapSize", 8);
            }
            set
            {
                this.SetValue("TextShortcutGapSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the text shortcut gap.
        /// </summary>
        internal void ResetTextShortcutGapSize()
        {
            this.Reset("TextShortcutGapSize");
        }

        /// <summary>
        /// Gets or sets the end size of the spacing.
        /// </summary>
        /// <value>
        /// The end size of the spacing.
        /// </value>
        [Category("Sizes"), SRDescription("The size of the gap between text and menu item arrow.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int TextArrowGapSize
        {
            get
            {
                return this.GetValue<int>("TextArrowGapSize", 10);
            }
            set
            {
                this.SetValue("TextArrowGapSize", value);
            }
        }

        /// <summary>
        /// Resets the size of the text arrow gap.
        /// </summary>
        internal void ResetTextArrowGapSize()
        {
            this.Reset("TextArrowGapSize");
        }
    }
}
