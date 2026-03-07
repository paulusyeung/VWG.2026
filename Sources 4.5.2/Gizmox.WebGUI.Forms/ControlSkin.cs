using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Provides skin definition for control
    /// </summary>
    [ToolboxBitmapAttribute(typeof(UserControl)), Serializable()]
    public class ControlSkin : CommonSkin
    {
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public override ArrowsScrollerProperties ArrowsScrollProperties
        {
            get
            {
                return base.ArrowsScrollProperties;
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [SRDescription("ControlBackgroundImageDescr")]
        [SRCategory("CatAppearance")]
        public virtual ImageResourceReference BackgroundImage
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

        /// <summary>
        /// Resets the background image.
        /// </summary>
        internal void ResetBackgroundImage()
        {
            this.Reset("BackgroundImage");
        }

        /// <summary>
        /// Gets or sets the visual effect.
        /// </summary>
        /// <value>
        /// The visual effect.
        /// </value>
        [SRCategory("CatBehavior"), Description("Provide definitions for visual effects."), DefaultValue(null), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public VisualEffectValue VisualEffect
        {
            get
            {
                return this.GetValue<VisualEffectValue>("VisualEffect", null);
            }
            set
            {
                this.SetValue("VisualEffect", value);
            }
        }

        /// <summary>
        /// Gets or sets the background image repeat.
        /// </summary>
        /// <value>The background image repeat.</value>
        [SRDescription("Sets if or how a background image will be repeated.")]
        [SRCategory("CatAppearance")]
        public virtual BackgroundImageRepeat BackgroundImageRepeat
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

        /// <summary>
        /// Resets the background image repeat.
        /// </summary>
        internal void ResetBackgroundImageRepeat()
        {
            this.Reset("BackgroundImageRepeat");
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>The background image position.</value>
        [SRDescription("Sets the starting position of a background image.")]
        [SRCategory("CatAppearance")]
        public virtual BackgroundImagePosition BackgroundImagePosition
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


        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBackColorDescr")]
        public virtual Color BackColor
        {
            get
            {
                return this.GetAmbientValue<Color>("BackColor", Color.FromKnownColor(KnownColor.Control));
            }
            set
            {
                this.SetValue("BackColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the back.
        /// </summary>
        internal void ResetBackColor()
        {
            this.Reset("BackColor");
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value>The control padding.</value>
        [SRDescription("ControlPaddingDescr"),  Category("Layout")]
        public virtual PaddingValue Padding
        {
            get
            {
                return this.GetValue<PaddingValue>("Padding", PaddingValue.Empty);
            }
            set
            {
                
                this.SetValue("Padding", value);
            }
        }

        /// <summary>
        /// Resets the padding.
        /// </summary>
        internal void ResetPadding()
        {
            this.Reset("Padding");
        }

        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <value>The space between controls.</value>
        [Category("Layout"), SRDescription("ControlMarginDescr")]
        public virtual MarginValue Margin
        {
            get
            {
                return this.GetValue<MarginValue>("Margin", MarginValue.Empty);
            }
            set
            {
                this.SetValue("Margin", value);
            }
        }

        /// <summary>
        /// Resets the margin.
        /// </summary>
        internal void ResetMargin()
        {
            this.Reset("Margin");
        }

        /// <summary>
        /// Resets the Border Radius.
        /// </summary>
        internal void ResetBorderRadius()
        {
            this.Reset("BorderRadius");
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value></value>
        [SRDescription("ControlBorderWidthDescr")]
        [SRCategory("CatAppearance")]
        public virtual BorderWidth BorderWidth
        {
            get
            {
                return this.GetValue<BorderWidth>("BorderWidth", new BorderWidth(1));
            }
            set
            {
                this.SetValue("BorderWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the border.
        /// </summary>
        internal void ResetBorderWidth()
        {
            this.Reset("BorderWidth");
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [SRDescription("ControlBorderColorDescr")]
        [SRCategory("CatAppearance")]
        public virtual BorderColor BorderColor
        {
            get
            {
                return this.GetValue<BorderColor>("BorderColor", new BorderColor(Color.FromArgb(101, 147, 207)));
            }
            set
            {
                this.SetValue("BorderColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the border.
        /// </summary>
        internal void ResetBorderColor()
        {
            this.Reset("BorderColor");
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [SRDescription("ControlBorderStyleDescr")]
        [SRCategory("CatAppearance")]
        public virtual BorderStyle BorderStyle
        {
            get
            {
                return this.GetValue<BorderStyle>("BorderStyle", BorderStyle.None);
            }
            set
            {
                this.SetValue("BorderStyle", value);
            }
        }

        /// <summary>
        /// Resets the border style.
        /// </summary>
        internal void ResetBorderStyle()
        {
            this.Reset("BorderStyle");
        }

        /// <summary>
        /// Gets the border value which can be translated.
        /// </summary>
        /// <value>The border.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderValue Border
        {
            get
            {
                BorderValue objBorderValue = new BorderValue();
                objBorderValue.Color = this.BorderColor;
                objBorderValue.Style = this.BorderStyle;
                objBorderValue.Width = this.BorderWidth;
                return objBorderValue;
            }
        }

        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundValue Background
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

        /// <summary>
        /// Gets or sets the control disabled style.
        /// </summary>
        /// <value>
        /// The control disabled style.
        /// </value>
        [Category("States"), Description("Gets or sets the control disabled style.")]
        public virtual StyleValue ControlDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ControlDisabledStyle");
                return objStyle;
            }
            set
            {
                this.SetValue("ControlDisabledStyle", value);
            }
        }

        /// <summary>
        /// Resets the control disabled style.
        /// </summary>
        internal void ResetControlDisabledStyle()
        {
            this.Reset("ControlDisabledStyle");
        }


        /// <summary>
        /// Gets the text foreground disabled.
        /// </summary>
        /// <value>
        /// The text foreground disabled.
        /// </value>
        [Browsable(false)]
        public ForegroundValue ControlTextForegroundDisabled
        {
            get
            {
                ForegroundValue objForegroundValue = new ForegroundValue();
                objForegroundValue.ForeColor = this.ControlDisabledStyle.ForeColor;
                return objForegroundValue;
            }
        }

        /// <summary>
        /// Gets the text background disabled.
        /// </summary>
        /// <value>
        /// The text background disabled.
        /// </value>
        [Browsable(false)]
        public BackgroundValue ControlTextBackgroundDisabled
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.ControlDisabledStyle.BackColor;
                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets the Opacity value for disabled control
        /// </summary>
        /// <value>
        /// The Opacity value for disabled control
        /// </value>
        [Browsable(false)]
        public OpacityValue ControlOpacityDisabled
        {
            get
            {
                OpacityValue objOpacityValue = new OpacityValue(this.ControlDisabledStyle.Opacity.Opacity);
                return objOpacityValue;
            }
        }
        /// <summary>
        /// Gets the control text font disabled.
        /// </summary>
        /// <value>
        /// The control text font disabled.
        /// </value>
        [Browsable(false)]
        public Font ControlTextFontDisabled
        {
            get
            {
                return this.ControlDisabledStyle.Font;
            }
        }

        private void InitializeComponent()
        {

        }

      

    }


}
