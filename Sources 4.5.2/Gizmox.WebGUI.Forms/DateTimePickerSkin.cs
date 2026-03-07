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
    /// DateTimePicker Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(DateTimePicker), "Button.bmp"), Serializable()]
    public class DateTimePickerSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
    
        private void InitializeComponent()
        {

        }


        #region Styles

        /// <summary>
        /// Gets the buttons' normal container style.
        /// </summary>
        [Category("States"), SRDescription("The buttons normal container style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ButtonsContainerNormalStyleLTR, ButtonsContainerNormalStyleRTL);
            }
        }
        /// <summary>
        /// Gets the buttons container normal style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerNormalStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerNormalStyleLTR");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the buttons container normal style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerNormalStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets The buttons hover container style.
        /// </summary>
        [Category("States"), SRDescription("The buttons hover container style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerHoverStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ButtonsContainerHoverStyleLTR, ButtonsContainerHoverStyleRTL);
            }
        }
        /// <summary>
        /// Gets the buttons container hover style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerHoverStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerHoverStyleLTR");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the buttons container hover style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerHoverStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerHoverStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets The buttons pressed container style.
        /// </summary>
        [Category("States"), SRDescription("The buttons pressed container style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual BidirectionalSkinValue<StyleValue> ButtonsContainerPressedStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, ButtonsContainerPressedStyleLTR, ButtonsContainerPressedStyleRTL);
            }
        }

        /// <summary>
        /// Gets the buttons container pressed style LTR.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerPressedStyleLTR
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerPressedStyleLTR");
                return objStyle;
            }
        }
        /// <summary>
        /// Gets the buttons container pressed style RTL.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue ButtonsContainerPressedStyleRTL
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ButtonsContainerPressedStyleRTL");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the input value style.
        /// </summary>
        /// <value>The input value style.</value>
        [SRCategory("States"), SRDescription("The input value style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue InputValueStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "InputValueStyle");
                return objStyle;
            }
        }

        #endregion Styles

        #region Sizes

        /// <summary>
        /// Gets or sets the width of up down icon container.
        /// </summary>
        /// <value>The width of up down icon container.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int UpDownIconContainerWidth
        {
            get
            {
                return this.GetImageWidth(this.UpDownDownNormalImage, this.DefaultUpDownIconContainerWidth);
            }
        }

        /// <summary>
        /// Resets the width of up down icon container.
        /// </summary>
        private void ResetUpDownIconContainerWidth()
        {
            this.Reset("UpDownIconContainerWidth");
        }

        /// <summary>
        /// Gets the default width of up down icon container.
        /// </summary>
        /// <value>The default width of up down icon container.</value>
        protected virtual int DefaultUpDownIconContainerWidth
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets or sets the width of up down icon.
        /// </summary>
        /// <value>The width of up down icon.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int UpDownIconWidth
        {
            get
            {
                return this.GetImageWidth(this.UpDownUpNormalImage, this.DefaultUpDownIconWidth);
            }
        }

        /// <summary>
        /// Gets the default width of up down icon.
        /// </summary>
        /// <value>The default width of up down icon.</value>
        protected virtual int DefaultUpDownIconWidth
        {
            get
            {
                return 15;
            }
        }

        /// <summary>
        /// Gets or sets the height of up icon.
        /// </summary>
        /// <value>The height of up icon.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int UpIconHeight
        {
            get
            {
                return this.GetImageHeight(this.UpDownUpNormalImage, this.DefaultUpIconHeight);
            }
        }

        /// <summary>
        /// Gets the default height of up  icon.
        /// </summary>
        /// <value>The default height of up  icon.</value>
        protected virtual int DefaultUpIconHeight
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Gets or sets the height of down icon.
        /// </summary>
        /// <value>The height of down icon.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DownIconHeight
        {
            get
            {
                return this.GetImageHeight(this.UpDownDownNormalImage, this.DefaultDownIconHeight);
            }
        }

        /// <summary>
        /// Gets the default height of up down icon.
        /// </summary>
        /// <value>The default height of up down icon.</value>
        protected virtual int DefaultDownIconHeight
        {
            get
            {
                return 9;
            }
        }

        /// <summary>
        /// Gets or sets the width of the drop down icon container.
        /// </summary>
        /// <value>The width of the drop down icon container.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DropDownIconContainerWidth
        {
            get
            {
                return this.GetImageWidth(this.DropDownNormalImage, this.DefaultDropDownIconContainerWidth);
            }
        }

        /// <summary>
        /// Resets the width of the drop down icon container.
        /// </summary>
        private void ResetDropDownIconContainerWidth()
        {
            this.Reset("DropDownIconContainerWidth");
        }

        /// <summary>
        /// Gets the default width of the drop down icon container.
        /// </summary>
        /// <value>The default width of the drop down icon container.</value>
        protected virtual int DefaultDropDownIconContainerWidth
        {
            get
            {
                return 17;
            }
        }

        /// <summary>
        /// Gets or sets the width of the check box icon container.
        /// </summary>
        /// <value>The width of the check box icon container.</value>
        [SRCategory("Sizes"), SRDescription("The check box icon container width.")]
        public virtual int CheckBoxIconContainerWidth
        {
            get
            {
                return this.GetValue<int>("CheckBoxIconContainerWidth", this.DefaultCheckBoxIconContainerWidth);
            }
            set
            {
                this.SetValue("CheckBoxIconContainerWidth", value);
            }
        }

        /// <summary>
        /// The picker drop down size
        /// </summary>
        [SRCategory("Sizes"), SRDescription("The picker drop down size.")]
        public Size DropDownSize
        {
            get
            {
                return this.GetValue<Size>("DropDownSize", Size.Empty);
            }
            set
            {
                this.SetValue("DropDownSize", value);
            }
        }
        //

        /// <summary>
        /// Resets the width of the check box icon container.
        /// </summary>
        private void ResetCheckBoxIconContainerWidth()
        {
            this.Reset("CheckBoxIconContainerWidth");
        }

        /// <summary>
        /// Gets the default width of the check box icon container.
        /// </summary>
        /// <value>The default width of the check box icon container.</value>
        protected virtual int DefaultCheckBoxIconContainerWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets or sets the width of the check box icon.
        /// </summary>
        /// <value>The width of the check box icon.</value>
        [SRCategory("Sizes"), SRDescription("The check box icon width.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CheckBoxIconWidth
        {
            get
            {
                return this.GetMaxImageWidth(this.DefaultCheckBoxIconWidth, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");
            }
        }

        /// <summary>
        /// Gets the default width of the check box icon.
        /// </summary>
        /// <value>The default width of the check box icon.</value>
        protected virtual int DefaultCheckBoxIconWidth
        {
            get
            {
                return 15;
            }
        }

        /// <summary>
        /// Gets or sets the height of the check box icon.
        /// </summary>
        /// <value>The height of the check box icon.</value>
        [SRCategory("Sizes"), SRDescription("The check box icon height.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CheckBoxIconHeight
        {
            get
            {
                return this.GetMaxImageHeight(this.DefaultCheckBoxIconHeight, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");
            }
        }

        /// <summary>
        /// Gets the default height of the check box icon.
        /// </summary>
        /// <value>The default height of the check box icon.</value>
        protected virtual int DefaultCheckBoxIconHeight
        {
            get
            {
                return 15;
            }
        }

        #endregion           

        #region Images

        #region ShowUpDown

        /// <summary>
        /// Gets or sets up down up over image.
        /// </summary>
        /// <value>Up down up over image.</value>
        [SRDescription("UpDown up over image")]
        [SRCategory("Images")]
        public ImageResourceReference UpDownUpOverImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UpDownUpOverImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownUpOver.gif"));
            }
            set
            {
                this.SetValue("UpDownUpOverImage", value);
            }
        }

        /// <summary>
        /// Resets up down up over image.
        /// </summary>
        private void ResetUpDownUpOverImage()
        {
            this.Reset("UpDownUpOverImage");
        }

        /// <summary>
        /// Gets or sets up down up normal image.
        /// </summary>
        /// <value>Up down up normal image.</value>
        [SRDescription("UpDown up normal image")]
        [SRCategory("Images")]
        public ImageResourceReference UpDownUpNormalImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UpDownUpNormalImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownUpNormal.gif"));
            }
            set
            {
                this.SetValue("UpDownUpNormalImage", value);
            }
        }

        /// <summary>
        /// Resets up down up normal image.
        /// </summary>
        private void ResetUpDownUpNormalImage()
        {
            this.Reset("UpDownUpNormalImage");
        }

        /// <summary>
        /// Gets or sets up down up down image.
        /// </summary>
        /// <value>Up down up down image.</value>
        [SRDescription("UpDown up down image")]
        [SRCategory("Images")]
        public ImageResourceReference UpDownUpDownImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UpDownUpDownImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownUpDown.gif"));
            }
            set
            {
                this.SetValue("UpDownUpDownImage", value);
            }
        }

        /// <summary>
        /// Resets up down up down image.
        /// </summary>
        private void ResetUpDownUpDownImage()
        {
            this.Reset("UpDownUpDownImage");
        }

        /// <summary>
        /// Gets or sets up down down over image.
        /// </summary>
        /// <value>Up down down over image.</value>
        [SRDescription("UpDown down over image")]
        [SRCategory("Images")]
        public ImageResourceReference UpDownDownOverImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UpDownDownOverImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownDownOver.gif"));
            }
            set
            {
                this.SetValue("UpDownDownOverImage", value);
            }
        }

        /// <summary>
        /// Resets up down down over image.
        /// </summary>
        private void ResetUpDownDownOverImage()
        {
            this.Reset("UpDownDownOverImage");
        }


        /// <summary>
        /// Gets or sets up down down normal image.
        /// </summary>
        /// <value>Up down down normal image.</value>
        [SRDescription("UpDown down normal image")]
        [SRCategory("CatAppearance")]
        public ImageResourceReference UpDownDownNormalImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UpDownDownNormalImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownDownNormal.gif"));
            }
            set
            {
                this.SetValue("UpDownDownNormalImage", value);
            }
        }

        /// <summary>
        /// Resets up down down normal image.
        /// </summary>
        private void ResetUpDownDownNormalImage()
        {
            this.Reset("UpDownDownNormalImage");
        }

        /// <summary>
        /// Gets or sets up down down down image.
        /// </summary>
        /// <value>Up down down down image.</value>
        [SRDescription("UpDown down down image")]
        [SRCategory("Images")]
        public ImageResourceReference UpDownDownDownImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("UpDownDownDownImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownDownDown.gif"));
            }
            set
            {
                this.SetValue("UpDownDownDownImage", value);
            }
        }

        /// <summary>
        /// Resets up down down down image.
        /// </summary>
        private void ResetUpDownDownDownImage()
        {
            this.Reset("UpDownDownDownImage");
        }
            
        #endregion ShowUpDown

        #region ShowDropDown

        /// <summary>
        /// Gets or sets the drop down normal image.
        /// </summary>
        /// <value>The drop down normal image.</value>
        [SRDescription("Drop down normal image")]
        [SRCategory("Images")]
        public ImageResourceReference DropDownNormalImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownNormalImage", new ImageResourceReference(typeof(DateTimePickerSkin), "DropDownNormal.gif"));
            }
            set
            {
                this.SetValue("DropDownNormalImage", value);
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
        /// Gets or sets the drop down over image.
        /// </summary>
        /// <value>The drop down over image.</value>
        [SRDescription("Drop down over image")]
        [SRCategory("Images")]
        public ImageResourceReference DropDownOverImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownOverImage", new ImageResourceReference(typeof(DateTimePickerSkin), "DropDownOver.gif"));
            }
            set
            {
                this.SetValue("DropDownOverImage", value);
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
        /// Gets or sets the drop down down image.
        /// </summary>
        /// <value>The drop down down image.</value>
        [SRDescription("Drop down down image")]
        [SRCategory("Images")]
        public ImageResourceReference DropDownDownImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DropDownDownImage", new ImageResourceReference(typeof(DateTimePickerSkin), "DropDownDown.gif"));
            }
            set
            {
                this.SetValue("DropDownDownImage", value);
            }
        }

        /// <summary>
        /// Resets the drop down down image.
        /// </summary>
        private void ResetDropDownDownImage()
        {
            this.Reset("DropDownDownImage");
        }

        #endregion ShowDropDown

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
                return this.GetValue<ImageResourceReference>("CheckedCheckBoxImage", new ImageResourceReference(typeof(DateTimePickerSkin), "CheckBox1.gif"));
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
                return this.GetValue<ImageResourceReference>("UnCheckedCheckBoxImage", new ImageResourceReference(typeof(DateTimePickerSkin), "CheckBox0.gif"));
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

        #endregion

        #endregion Images

    }
}
