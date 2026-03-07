using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// DockedHiddenZonesPanel Skin
    /// </summary>
    [Serializable(), Gizmox.WebGUI.Forms.Skins.SkinContainer(typeof(DockingManagerSkin))]
    public class DockedHiddenZonesPanelSkin : Gizmox.WebGUI.Forms.Skins.PanelSkin
    {
		#region Fields (1) 

        private HiddenZoneItemProperties mobjHiddenZoneItemProperties;

		#endregion Fields 

		#region Properties (23) 

        /// <summary>
        /// Gets the font When the button is focused.
        /// </summary>
        /// <value>The font focused.</value>
        [Browsable(false)]
        public Font FontData
        {
            get
            {
                return this.HiddenZoneItemStyle.Font;
            }
        }

        /// <summary>
        /// Gets the hidden zone item properties object.
        /// </summary>
        public HiddenZoneItemProperties HiddenZoneItem
        {
            get
            {
                if (mobjHiddenZoneItemProperties == null)
                {
                    mobjHiddenZoneItemProperties = new HiddenZoneItemProperties(this);
                }

                return mobjHiddenZoneItemProperties;
            }
        }

        /// <summary>
        /// Gets the drop down arrow image style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneItemHoverStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneItemHoverStyle");
            }
        }

        /// <summary>
        /// Gets the drop down arrow image style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZonePopUpStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZonePopUpStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller bottom hover style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerBottomHoverStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerBottomHoverStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller bottom pressed style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerBottomPressedStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerBottomPressedStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller bottom style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerBottomStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerBottomStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller left hover style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerLeftHoverStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerLeftHoverStyle");
            }
        }

        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerLeftPressedStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerLeftPressedStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller left style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerLeftStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerLeftStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller right hover style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerRightHoverStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerRightHoverStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller right pressed style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerRightPressedStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerRightPressedStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller right style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerRightStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerRightStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller top hover style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerTopHoverStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerTopHoverStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller top pressed style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerTopPressedStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerTopPressedStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone scroller top style.
        /// </summary>
        [Category("States")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue HiddenZoneScrollerTopStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneScrollerTopStyle");
            }
        }

        /// <summary>
        /// Gets the height of the left right center content.
        /// </summary>
        /// <value>
        /// The height of the left right center content.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LeftRightContentWidth
        {
            get
            {
                return this.PanelThickness - LeftRightPanelsPadding.Left - LeftRightPanelsPadding.Right;
            }
        }

        /// <summary>
        /// Gets or sets the left right panels padding.
        /// </summary>
        /// <value>
        /// The left right panels padding.
        /// </value>
        [SRDescription("ControlPaddingDescr"), Category("Layout")]
        public PaddingValue LeftRightPanelsPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("LeftRightPanelsPadding", new PaddingValue(new Padding(0, 0, 0, 0)));
            }
            set
            {
                this.SetValue("LeftRightPanelsPadding", value);
            }
        }

        /// <summary>
        /// Gets or sets the panel item thickness.
        /// </summary>
        /// <value>
        /// The panel item thickness.
        /// </value>
        public int PanelItemThickness
        {
            get
            {
                return this.GetValue<int>("PanelItemThickness", 100);
            }
            set
            {
                this.SetValue("PanelItemThickness", value);
            }
        }

        /// <summary>
        /// Gets or sets the panel thickness.
        /// </summary>
        /// <value>
        /// The panel thickness.
        /// </value>
        public int PanelThickness
        {
            get
            {
                return this.GetValue<int>("PanelThickness", 22);
            }
            set
            {
                this.SetValue("PanelThickness", value);
            }
        }

        /// <summary>
        /// Gets or sets the scroller thickness.
        /// </summary>
        /// <value>
        /// The scroller thickness.
        /// </value>
        public int ScrollerThickness
        {
            get
            {
                return this.GetValue<int>("ScrollerThickness", 22);
            }
            set
            {
                this.SetValue("ScrollerThickness", value);
            }
        }

        /// <summary>
        /// Gets the height of the top bottom center content.
        /// </summary>
        /// <value>
        /// The height of the top bottom center content.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TopBottomContentHeight
        {
            get
            {
                return this.PanelThickness - TopBottomPanelsPadding.Top - TopBottomPanelsPadding.Bottom - HiddenZoneItemStyle.BorderWidth.Top - HiddenZoneItemStyle.BorderWidth.Bottom;
            }
        }


        /// <summary>
        /// Gets or sets the top bottom panels padding.
        /// </summary>
        /// <value>
        /// The top bottom panels padding.
        /// </value>
        [SRDescription("ControlPaddingDescr"), Category("Layout")]
        public PaddingValue TopBottomPanelsPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("TopBottomPanelsPadding", new PaddingValue(new Padding(0, 0, 0, 0)));
            }
            set
            {
                this.SetValue("TopBottomPanelsPadding", value);
            }
        }

		#endregion Properties 

		#region Methods (1) 

		// Private Methods (1) 

        private void InitializeComponent()
        { }

		#endregion Methods 

        #region Hidden Zone Item Skin Properties

        /// <summary>
        /// Gets the width of the top bottom hidden zone item image.
        /// </summary>
        /// <value>
        /// The width of the top bottom hidden zone item image.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HiddenZoneItemImageWidth
        {
            get
            {
                return HiddenZoneItemImageSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the top bottom hidden zone item image.
        /// </summary>
        /// <value>
        /// The height of the top bottom hidden zone item image.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HiddenZoneItemImageHeight
        {
            get
            {
                return HiddenZoneItemImageSize.Height;
            }
        }

        /// <summary>
        /// Gets or sets the size of the top bottom hidden zone item image.
        /// </summary>
        /// <value>
        /// The size of the top bottom hidden zone item image.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size HiddenZoneItemImageSize
        {
            get
            {
                return this.GetValue<Size>("HiddenZoneItemImageSize", new Size(TopBottomContentHeight, TopBottomContentHeight));
            }
            set
            {
                this.SetValue("HiddenZoneItemImageSize", value);
            }
        }

        /// <summary>
        /// Gets or sets the hidden zone item expantion delay.
        /// </summary>
        /// <value>
        /// The hidden zone item expantion delay.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HiddenZoneItemExpantionDelay
        {
            get
            {
                return this.GetValue<int>("HiddenZoneItemExpantionDelay", 500);
            }
            set
            {
                this.SetValue("HiddenZoneItemExpantionDelay", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the hidden zone item expantion.
        /// </summary>
        /// <value>
        /// The width of the hidden zone item expantion.
        /// </value>
        public int HiddenZoneItemExpantionWidth
        {
            get
            {
                return this.GetValue<int>("HiddenZoneItemExpantionWidth", 300);
            }
            set
            {
                this.SetValue("HiddenZoneItemExpantionWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the duration of the hidden zone item expantion animation.
        /// </summary>
        /// <value>
        /// The duration of the hidden zone item expantion animation.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HiddenZoneItemExpantionAnimationDuration
        {
            get
            {
                return this.GetValue<int>("HiddenZoneItemExpantionAnimationDuration", 500);
            }
            set
            {
                this.SetValue("HiddenZoneItemExpantionAnimationDuration", value);
            }
        }

        /// <summary>
        /// Gets the drop down arrow image style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue HiddenZoneItemStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneItemStyle");
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HiddenZoneItemStyleVerticalPadding
        {
            get
            {
                return HiddenZoneItemStyle.Padding.Vertical + HiddenZoneItemStyle.Border.Width.Top + HiddenZoneItemStyle.Border.Width.Bottom;
            }
        }

        internal int HiddenZoneItemStyleHorizontalPadding
        {
            get
            {
                return HiddenZoneItemStyle.Padding.Horizontal;
            }
        }

        /// <summary>
        /// Gets the hidden zone item container vertical style.
        /// </summary>
        /// <value>
        /// The hidden zone item container vertical style.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue HiddenZoneItemContainerVerticalStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneItemContainerVerticalStyle");
            }
        }

        /// <summary>
        /// Gets the hidden zone item container horizontal style.
        /// </summary>
        /// <value>
        /// The hidden zone item container horizontal style.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue HiddenZoneItemContainerHorizontalStyle
        {
            get
            {
                return new StyleValue(this, "HiddenZoneItemContainerHorizontalStyle");
            }
        }

        #endregion Hidden Zone Item Skin Properties
    }

    /// <summary>
    /// 
    /// </summary>
    [TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class HiddenZoneItemProperties
    {
		#region Fields (1) 

        private DockedHiddenZonesPanelSkin mobjHiddenZonePanelSkin;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="HiddenZoneItemProperties"/> class.
        /// </summary>
        /// <param name="objHiddenZonePanelSkin">The obj hidden zone panel skin.</param>
        public HiddenZoneItemProperties(DockedHiddenZonesPanelSkin objHiddenZonePanelSkin)
        { 
            this.mobjHiddenZonePanelSkin = objHiddenZonePanelSkin;
        }

		#endregion Constructors 

		#region Properties (5) 

        /// <summary>
        /// Gets the item container vertical style.
        /// </summary>
        /// <value>
        /// The item container vertical style.
        /// </value>
        public StyleValue ItemContainerVerticalStyle
        {
            get
            {
                return mobjHiddenZonePanelSkin.HiddenZoneItemContainerVerticalStyle;
            }
        }

        /// <summary>
        /// Gets the item container horizontal style.
        /// </summary>
        /// <value>
        /// The item container horizontal style.
        /// </value>
        public StyleValue ItemContainerHorizontalStyle
        {
            get
            {
                return mobjHiddenZonePanelSkin.HiddenZoneItemContainerHorizontalStyle;
            }
        }

        /// <summary>
        /// Gets or sets the duration of the animation.
        /// </summary>
        /// <value>
        /// The duration of the animation.
        /// </value>
        public int AnimationDuration 
        {
            get
            {
                return mobjHiddenZonePanelSkin.HiddenZoneItemExpantionAnimationDuration;
            }
            set
            {
                mobjHiddenZonePanelSkin.HiddenZoneItemExpantionAnimationDuration = value;
            }
        }

        /// <summary>
        /// Gets or sets the expantion delay.
        /// </summary>
        /// <value>
        /// The expantion delay.
        /// </value>
        public int ExpantionDelay 
        {
            get
            {
                return mobjHiddenZonePanelSkin.HiddenZoneItemExpantionDelay;
            }
            set
            {
                mobjHiddenZonePanelSkin.HiddenZoneItemExpantionDelay = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the horizontal panels item image.
        /// </summary>
        /// <value>
        /// The size of the horizontal panels item image.
        /// </value>
        public Size HorizontalPanelsItemImageSize
        {
            get
            {
                return mobjHiddenZonePanelSkin.HiddenZoneItemImageSize;
            }
            set
            {
                mobjHiddenZonePanelSkin.HiddenZoneItemImageSize = value;
            }
        }

        /// <summary>
        /// Gets the item style.
        /// </summary>
        public StyleValue ItemStyle
        {
            get
            {
                return mobjHiddenZonePanelSkin.HiddenZoneItemStyle;
            }
        }

		#endregion Properties 
    }
}
