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
    /// ComboBox Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ComboBox), "ComboBox.bmp"), Serializable()]
    public class ComboBoxSkin : ControlSkin
    {

        private void InitializeComponent()
        {

        }

        #region Styles

        /// <summary>
        /// Gets the data container style.
        /// </summary>
        [Category("States"), SRDescription("ComboBox ListBox section style.")]
        public virtual BidirectionalSkinValue<StyleValue> ItemsContainerStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ListBoxContainerStyleLTR, ListBoxContainerStyleRTL);
            }
        }

        /// <summary>
        /// Gets the data container style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ListBoxContainerStyleLTR
        {
            get
            {
                return new StyleValue(this, "ListBoxContainerStyleLTR");
            }
        }

        /// <summary>
        /// Gets the data container style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue ListBoxContainerStyleRTL
        {
            get
            {
                return new StyleValue(this, "ListBoxContainerStyleRTL");
            }
        }

        /// <summary>
        /// Gets the data container style.
        /// </summary>
        [Category("States"), SRDescription("ComboBox Data section style.")]
        public virtual BidirectionalSkinValue<StyleValue> DataContainerDropDownListModeStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DataContainerDropDownListModeStyleLTR, DataContainerDropDownListModeStyleRTL);
            }
        }

        /// <summary>
        /// Gets the data container style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DataContainerDropDownListModeStyleLTR
        {
            get
            {
                return new StyleValue(this, "DataContainerDropDownListModeStyleLTR");
            }
        }

        /// <summary>
        /// Gets the data container style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DataContainerDropDownListModeStyleRTL
        {
            get
            {
                return new StyleValue(this, "DataContainerDropDownListModeStyleRTL");
            }
        }

        /// <summary>
        /// Gets the data container style.
        /// </summary>
        [Category("States"), SRDescription("ComboBox Data section style.")]
        public virtual BidirectionalSkinValue<StyleValue> DataContainerDropDownModeStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DataContainerDropDownModeStyleLTR, DataContainerDropDownModeStyleRTL);
            }
        }

        /// <summary>
        /// Gets the data container style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DataContainerDropDownModeStyleLTR
        {
            get
            {
                return new StyleValue(this, "DataContainerDropDownModeStyleLTR");
            }
        }

        /// <summary>
        /// Gets the data container style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DataContainerDropDownModeStyleRTL
        {
            get
            {
                return new StyleValue(this, "DataContainerDropDownModeStyleRTL");
            }
        }

        /*****/

        /// <summary>
        /// Gets the data container style.
        /// </summary>
        [Category("States"), SRDescription("ComboBox Data section style in Simple mode.")]
        public virtual BidirectionalSkinValue<StyleValue> DataContainerSimpleModeStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DataContainerSimpleModeStyleLTR, DataContainerSimpleModeStyleRTL);
            }
        }

        /// <summary>
        /// Gets the data container style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DataContainerSimpleModeStyleLTR
        {
            get
            {
                return new StyleValue(this, "DataContainerSimpleModeStyleLTR");
            }
        }

        /// <summary>
        /// Gets the data container style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DataContainerSimpleModeStyleRTL
        {
            get
            {
                return new StyleValue(this, "DataContainerSimpleModeStyleRTL");
            }
        }

        /****/

        /// <summary>
        /// Gets the drop down normal image container.
        /// </summary>
        [Category("States"), SRDescription("The drop down image container.")]
        public virtual BidirectionalSkinValue<StyleValue> DropDownContainerNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DropDownContainerNormalStyleLTR, DropDownContainerNormalStyleRTL);
            }
        }

        /// <summary>
        /// Gets the drop down container normal style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DropDownContainerNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down container normal style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DropDownContainerNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down normal image container.
        /// </summary>
        [Category("States"), SRDescription("The drop down image container hover.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DropDownContainerHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DropDownContainerHoverStyleLTR, DropDownContainerHoverStyleRTL);
            }
        }

        /// <summary>
        /// Gets the drop down container normal style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("States"), SRDescription("The drop down image container.")]
        public virtual StyleValue DropDownContainerHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerHoverStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down container normal style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("States"), SRDescription("The drop down image container.")]
        public virtual StyleValue DropDownContainerHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerHoverStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down normal image container.
        /// </summary>
        [Category("States"), SRDescription("The drop down image container down.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DropDownContainerPressedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DropDownContainerPressedStyleLTR, DropDownContainerPressedStyleRTL);
            }
        }

        /// <summary>
        /// Gets the drop down container normal style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("States"), SRDescription("The drop down image container.")]
        public virtual StyleValue DropDownContainerPressedStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerPressedStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down container normal style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DropDownContainerPressedStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerPressedStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down normal image container.
        /// </summary>
        [Category("States"), SRDescription("The drop down image container disabled.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DropDownContainerDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DropDownContainerDisabledStyleLTR, DropDownContainerDisabledStyleRTL);
            }
        }

        /// <summary>
        /// Gets the drop down container normal style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DropDownContainerDisabledStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerDisabledStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the drop down container normal style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue DropDownContainerDisabledStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "DropDownContainerDisabledStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the pop up body style.
        /// </summary>
        /// <value>The pop up body style.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual StyleValue PopupBodyStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PopupBodyStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the pop up item style.
        /// </summary>
        /// <value>The pop up item style.</value>
        [Category("States"), SRDescription("The popup item style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PopupItemStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PopupItemStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the pop up item enter style.
        /// </summary>
        /// <value>The pop up item enter style.</value>
        [Category("States"), SRDescription("The popup item enter style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PopupItemEnterStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PopupItemEnterStyle", this.PopupItemStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the color of the popup item enter fore.
        /// </summary>
        /// <value>The color of the popup item enter fore.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual Color PopupItemEnterForeColor
        {
            get
            {
                return PopupItemEnterStyle.ForeColor;
            }
        }

        /// <summary>
        /// Gets the pop up item selected style.
        /// </summary>
        /// <value>The pop up item selected style.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual StyleValue PopupItemSelectedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PopupItemSelectedStyle", this.PopupItemStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the pop up item down style.
        /// </summary>
        /// <value>The pop up item down style.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual StyleValue PopupItemDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PopupItemDownStyle", this.PopupItemStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the selected popup item.
        /// </summary>
        /// <value>The selected popup item.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual StyleValue SelectedPopupItem
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SelectedPopupItem", this.PopupItemStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the simple combo box text box border style.
        /// </summary>
        /// <value>The simple combo box text box border style.</value>
        [Category("States"), SRDescription("The simple combobox textbox border style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ComboBoxTextBoxContainerStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ComboBoxTextBoxContainerStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the drop down list text box style.
        /// </summary>
        /// <value>
        /// The drop down list text box style.
        /// </value>
        [Category("States"), SRDescription("The drop down list text box style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> DropDownListTextBoxStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, DropDownListTextBoxStyleLTR, DropDownListTextBoxStyleRTL);
            }
        }
        /// <summary>
        /// Gets the drop down list text box style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DropDownListTextBoxStyleLTR { get { return new StyleValue(this, "DropDownListTextBoxStyleLTR"); } }
        /// <summary>
        /// Gets the drop down list text box style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StyleValue DropDownListTextBoxStyleRTL { get { return new StyleValue(this, "DropDownListTextBoxStyleRTL"); } }

        /// <summary>
        /// Gets the text box style.
        /// </summary>
        /// <value>The text box style.</value>
        [Category("States"), SRDescription("The TextBox style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TextBoxStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TextBoxStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the focused drop down list text box style.
        /// </summary>
        /// <value>The focused drop down list text box style.</value>
        [Category("States"), SRDescription("The focused drop down list text box style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue FocusedDropDownListTextBoxStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "FocusedDropDownListTextBoxStyle");
                return objStyle;
            }
        }
        

        /// <summary>
        /// Gets the text box disable style.
        /// </summary>
        /// <value>The text box disable style.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual StyleValue TextBoxDisableStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TextBoxDisableStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the color box style.
        /// </summary>
        /// <value>The color box style.</value>
        [Category("States"), SRDescription("The color box style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual  StyleValue ColorBoxStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ColorBoxStyle");
                return objStyle;
            }
        }
        #endregion

        #region Images



        /// <summary>
        /// Gets the drop down normal image.
        /// </summary>
        /// <value>The drop down normal image.</value>
        [Category("Images"), Description("drop down normal image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> DropDownNormalImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "DropDownNormalImageLTR", "DropDownNormalImageRTL");
            }
        }


        /// <summary>
        /// Gets or sets the left to right drop down normal image.
        /// </summary>
        /// <value>The left to right drop down normal image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownNormalImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownNormalImageLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownNormal.gif"));
            }
            set
            {
                this.SetValue("DropDownNormalImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the right to left drop down normal image.
        /// </summary>
        /// <value>The right to left drop down normal image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownNormalImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownNormalImageRTL", this.DropDownNormalImageLTR);
            }
            set
            {
                this.SetValue("DropDownNormalImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the drop down normal image.
        /// </summary>
        private void ResetDropDownNormalImage()
        {
            this.Reset("DropDownNormalImage");
        }


        /// <summary>
        /// Gets the drop down over image.
        /// </summary>
        /// <value>The drop down over image.</value>
        [Category("Images"), Description("The DropDown over Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> DropDownOverImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "DropDownOverImageLTR", "DropDownOverImageRTL");
            }
        }


        /// <summary>
        /// Gets or sets the drop down over image LTR.
        /// </summary>
        /// <value>The drop down over image LTR.</value>
        [Description("Drop down left to right over image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownOverImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownOverImageLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownOver.gif"));
            }
            set
            {
                this.SetValue("DropDownOverImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the drop down over image RTL.
        /// </summary>
        /// <value>The drop down over image RTL.</value>
        [Description("Drop down right to left over image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownOverImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownOverImageRTL", this.DropDownOverImageLTR);
            }
            set
            {
                this.SetValue("DropDownOverImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the drop down over image.
        /// </summary>
        private void ResetDropDownOverImage()
        {
            this.Reset("DropDownOverImage");
        }


        /// <summary>
        /// Gets the drop down down image.
        /// </summary>
        /// <value>The drop down down image.</value>
        [Category("Images"), Description("The DropDown down Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> DropDownDownImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "DropDownDownImageLTR", "DropDownDownImageRTL");
            }
        }


        /// <summary>
        /// Gets or sets the drop down down image LTR.
        /// </summary>
        /// <value>The drop down down image LTR.</value>
        [Description("Drop down left to right down image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownDownImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownDownImageLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownDown.gif"));
            }
            set
            {
                this.SetValue("DropDownDownImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the drop down down image RTL.
        /// </summary>
        /// <value>The drop down down image RTL.</value>
        [Description("Drop down down right to left image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownDownImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownDownImageRTL", this.DropDownDownImageLTR);
            }
            set
            {
                this.SetValue("DropDownDownImageRTL", value);
            }
        }

        /// <summary>
        /// Resets the drop down down image.
        /// </summary>
        private void ResetDropDownDownImage()
        {
            this.Reset("DropDownDownImage");
        }


        /// <summary>
        /// Gets the drop down image disable.
        /// </summary>
        /// <value>The drop down image disable.</value>
        [Category("Images"), Description("The DropDown disable Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> DropDownImageDisable
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "DropDownImageDisableLTR", "DropDownImageDisableRTL");
            }
        }


        /// <summary>
        /// Gets or sets the drop down image disable LTR.
        /// </summary>
        /// <value>The drop down image disable LTR.</value>
        [Description("Drop down left to right image Disable")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownImageDisableLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownImageDisableLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownDisable.gif"));
            }
            set
            {
                this.SetValue("DropDownImageDisableLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the drop down image disable RTL.
        /// </summary>
        /// <value>The drop down image disable RTL.</value>
        [Description("Drop down right to left image Disable")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference DropDownImageDisableRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownImageDisableRTL", this.DropDownImageDisableLTR);
            }
            set
            {
                this.SetValue("DropDownImageDisableRTL", value);
            }
        }

        /// <summary>
        /// Resets the drop down down image disable.
        /// </summary>
        private void ResetDropDownDownImageDisable()
        {
            this.Reset("DropDownImageDisable");
        }
        #endregion

        #region Sizes

        /// <summary>
        /// Gets or sets the width of the drop down image.
        /// </summary>
        /// <value>The width of the drop down image.</value>
        [SRCategory("Sizes"), SRDescription("The drop down image width.")]
        public virtual int DropDownImageWidth
        {
            get
            {
                return this.GetValue<int>("DropDownImageWidth", this.DefaultDropDownImageWidth);
            }
            set
            {
                this.SetValue("DropDownImageWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the drop down image.
        /// </summary>
        private void ResetDropDownImageWidth()
        {
            this.Reset("DropDownImageWidth");
        }

        /// <summary>
        /// Gets the default width of the drop down image.
        /// </summary>
        /// <value>The default width of the drop down image.</value>
        protected virtual int DefaultDropDownImageWidth
        {
            get
            {
                return 15;
            }
        }

        /// <summary>
        /// Gets or sets the height of the drop down image.
        /// </summary>
        /// <value>The height of the drop down image.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual int DropDownImageHeight
        {
            get
            {
                return this.GetValue<int>("DropDownImageHeight", this.DefaultDropDownImageHeight);
            }
            set
            {
                this.SetValue("DropDownImageHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the drop down image.
        /// </summary>
        private void ResetDropDownImageHeight()
        {
            this.Reset("DropDownImageHeight");
        }

        /// <summary>
        /// Gets the default height of the drop down image.
        /// </summary>
        /// <value>The default height of the drop down image.</value>
        protected virtual int DefaultDropDownImageHeight
        {
            get
            {
                return 17;
            }
        }

        /// <summary>
        /// Gets or sets the width of the drop down image cell.
        /// </summary>
        /// <value>The width of the drop down image cell.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public virtual int DropDownImageCellWidth
        {
            get
            {
                return this.GetValue<int>("DropDownImageCellWidth", this.DefaultDropDownImageCellWidth);
            }
            set
            {
                this.SetValue("DropDownImageCellWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the drop down image cell.
        /// </summary>
        private void ResetDropDownImageCellWidth()
        {
            this.Reset("DropDownImageCellWidth");
        }

        /// <summary>
        /// Gets the default width of the drop down image cell.
        /// </summary>
        /// <value>The default width of the drop down image cell.</value>
        protected virtual int DefaultDropDownImageCellWidth
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets or sets the width of the color box.
        /// </summary>
        /// <value>The width of the color box.</value>
        [SRCategory("Sizes"), SRDescription("The color box width.")]
        public virtual int ColorBoxWidth
        {
            get
            {
                return this.GetValue<int>("ColorBoxWidth", this.DefaultColorBoxWidth);
            }
            set
            {
                this.SetValue("ColorBoxWidth", value);
            }
        }


        /// <summary>
        /// Resets the width of the color box.
        /// </summary>
        private void ResetColorBoxWidth()
        {
            this.Reset("ColorBoxWidth");
        }

        /// <summary>
        /// Gets or sets the height of the color box.
        /// </summary>
        /// <value>The height of the color box.</value>
        [SRCategory("Sizes"), SRDescription("The color box height.")]
        public virtual int ColorBoxHeight
        {
            get
            {
                return this.GetValue<int>("ColorBoxHeight", this.DefaultColorBoxHeight);
            }
            set
            {
                this.SetValue("ColorBoxHeight", value);
            }
        }


        /// <summary>
        /// Resets the height of the color box.
        /// </summary>
        private void ResetColorBoxHeight()
        {
            this.Reset("ColorBoxHeight");
        }

        /// <summary>
        /// Gets or sets the width of the image box.
        /// </summary>
        /// <value>The width of the image box.</value>
        [SRCategory("Sizes"), SRDescription("The image box width.")]
        public virtual int ImageBoxWidth
        {
            get
            {
                return this.GetValue<int>("ImageBoxWidth", this.DefaultColorBoxWidth);
            }
            set
            {
                this.SetValue("ImageBoxWidth", value);
            }
        }


        /// <summary>
        /// Resets the width of the image box.
        /// </summary>
        private void ResetImageBoxWidth()
        {
            this.Reset("ImageBoxWidth");
        }

        /// <summary>
        /// Gets or sets the height of the image box.
        /// </summary>
        /// <value>The height of the image box.</value>
        [SRCategory("Sizes"), SRDescription("The Image box height.")]
        public virtual int ImageBoxHeight
        {
            get
            {
                return this.GetValue<int>("ImageBoxHeight", this.DefaultImageBoxHeight);
            }
            set
            {
                this.SetValue("ImageBoxHeight", value);
            }
        }

        private void ResetImageBoxHeight()
        {
            this.Reset("ImageBoxHeight");
        }

        /// <summary>
        /// Gets the default width of the color box.
        /// </summary>
        /// <value>The default width of the color box.</value>
        protected virtual int DefaultColorBoxWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets the default height of the color box.
        /// </summary>
        /// <value>The default height of the color box.</value>
        protected virtual int DefaultColorBoxHeight
        {
            get
            {
                return 14;
            }
        }

        /// <summary>
        /// Gets the default height of the Image box.
        /// </summary>
        /// <value>The default height of the Image box.</value>
        protected virtual int DefaultImageBoxHeight
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets the default width of the image box.
        /// </summary>
        /// <value>The default width of the image box.</value>
        protected virtual int DefaultImageBoxWidth
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets the width of the preferd image box.
        /// </summary>
        /// <value>The width of the preferd image box.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PreferdImageBoxWidth
        {
            get
            {
                //Return the image box width as set by the user + the horizontal padding
                return this.ImageBoxWidth + this.PopupItemStyle.Padding.Horizontal;
            }
        }

        /// <summary>
        /// Gets the width of the preferd color box.
        /// </summary>
        /// <value>The width of the preferd color box.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PreferdColorBoxWidth
        {
            get
            {
                //Return the color box width as set by the user + the horizontal padding
                return this.ColorBoxWidth + this.PopupItemStyle.Padding.Horizontal;
            }
        }

        /// <summary>
        /// Gets or sets the height of the simple combo box input.
        /// </summary>
        /// <value>The height of the simple combo box input.</value>
        [Category("Sizes"), Description("The height of the simple combo box input.")]
        public int SimpleComboBoxInputHeight
        {
            get
            {
                return this.GetValue<int>("SimpleComboBoxInputHeight", this.DefaultSimpleComboBoxInputHeight);
            }
            set
            {
                this.SetValue("SimpleComboBoxInputHeight", value);
            }
        }

        /// <summary>
        /// Gets the default height of the simple combo box input.
        /// </summary>
        /// <value>The default height of the simple combo box input.</value>
        protected virtual int DefaultSimpleComboBoxInputHeight
        {
            get
            {
                return 17;
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
                int intDefaultWidth = this.PopupWindowStyle.CenterStyle.BorderWidth.Left + this.PopupWindowStyle.CenterStyle.BorderWidth.Right
                    + this.PopupWindowStyle.CenterStyle.Padding.Horizontal;

                if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null)
                {
                    if ((HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
                    {
                        return intDefaultWidth;
                    }
                }

                return intDefaultWidth + this.RightPopupWindowFrameWidth +  this.LeftPopupWindowFrameWidth;
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
                int intDefaultHeight = this.PopupWindowStyle.CenterStyle.BorderWidth.Top + this.PopupWindowStyle.CenterStyle.BorderWidth.Bottom
                    + this.PopupWindowStyle.CenterStyle.Padding.Vertical;

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
    }
}
