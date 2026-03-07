// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ControlSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides skin definition for control</summary>
  [ToolboxBitmap(typeof (UserControl))]
  [Serializable]
  public class ControlSkin : CommonSkin
  {
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public override CommonSkin.ArrowsScrollerProperties ArrowsScrollProperties => base.ArrowsScrollProperties;

    /// <summary>Gets or sets the background image.</summary>
    /// <value>The background image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlBackgroundImageDescr")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual ImageResourceReference BackgroundImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (BackgroundImage), (ImageResourceReference) "");
      set => this.SetValue(nameof (BackgroundImage), (object) value);
    }

    /// <summary>Resets the background image.</summary>
    internal void ResetBackgroundImage() => this.Reset("BackgroundImage");

    /// <summary>Gets or sets the visual effect.</summary>
    /// <value>The visual effect.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
    [Description("Provide definitions for visual effects.")]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public VisualEffectValue VisualEffect
    {
      get => this.GetValue<VisualEffectValue>(nameof (VisualEffect), (VisualEffectValue) null);
      set => this.SetValue(nameof (VisualEffect), (object) value);
    }

    /// <summary>Gets or sets the background image repeat.</summary>
    /// <value>The background image repeat.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets if or how a background image will be repeated.")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BackgroundImageRepeat BackgroundImageRepeat
    {
      get => this.GetValue<BackgroundImageRepeat>(nameof (BackgroundImageRepeat), BackgroundImageRepeat.Repeat);
      set => this.SetValue(nameof (BackgroundImageRepeat), (object) value);
    }

    /// <summary>Resets the background image repeat.</summary>
    internal void ResetBackgroundImageRepeat() => this.Reset("BackgroundImageRepeat");

    /// <summary>Gets or sets the background image position.</summary>
    /// <value>The background image position.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets the starting position of a background image.")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BackgroundImagePosition BackgroundImagePosition
    {
      get => this.GetValue<BackgroundImagePosition>(nameof (BackgroundImagePosition), BackgroundImagePosition.MiddleCenter);
      set => this.SetValue(nameof (BackgroundImagePosition), (object) value);
    }

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlBackColorDescr")]
    public virtual Color BackColor
    {
      get => this.GetAmbientValue<Color>(nameof (BackColor), Color.FromKnownColor(KnownColor.Control));
      set => this.SetValue(nameof (BackColor), (object) value);
    }

    /// <summary>Resets the color of the back.</summary>
    internal void ResetBackColor() => this.Reset("BackColor");

    /// <summary>Gets or sets the control padding.</summary>
    /// <value>The control padding.</value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlPaddingDescr")]
    [Category("Layout")]
    public virtual PaddingValue Padding
    {
      get => this.GetValue<PaddingValue>(nameof (Padding), PaddingValue.Empty);
      set => this.SetValue(nameof (Padding), (object) value);
    }

    /// <summary>Resets the padding.</summary>
    internal void ResetPadding() => this.Reset("Padding");

    /// <summary>Gets or sets the space between controls.</summary>
    /// <value>The space between controls.</value>
    [Category("Layout")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlMarginDescr")]
    public virtual MarginValue Margin
    {
      get => this.GetValue<MarginValue>(nameof (Margin), MarginValue.Empty);
      set => this.SetValue(nameof (Margin), (object) value);
    }

    /// <summary>Resets the margin.</summary>
    internal void ResetMargin() => this.Reset("Margin");

    /// <summary>Resets the Border Radius.</summary>
    internal void ResetBorderRadius() => this.Reset("BorderRadius");

    /// <summary>Gets or sets the width of the border.</summary>
    /// <value></value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlBorderWidthDescr")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BorderWidth BorderWidth
    {
      get => this.GetValue<BorderWidth>(nameof (BorderWidth), new BorderWidth(1));
      set => this.SetValue(nameof (BorderWidth), (object) value);
    }

    /// <summary>Resets the width of the border.</summary>
    internal void ResetBorderWidth() => this.Reset("BorderWidth");

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlBorderColorDescr")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BorderColor BorderColor
    {
      get => this.GetValue<BorderColor>(nameof (BorderColor), new BorderColor(Color.FromArgb(101, 147, 207)));
      set => this.SetValue(nameof (BorderColor), (object) value);
    }

    /// <summary>Resets the color of the border.</summary>
    internal void ResetBorderColor() => this.Reset("BorderColor");

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlBorderStyleDescr")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BorderStyle BorderStyle
    {
      get => this.GetValue<BorderStyle>(nameof (BorderStyle), BorderStyle.None);
      set => this.SetValue(nameof (BorderStyle), (object) value);
    }

    /// <summary>Resets the border style.</summary>
    internal void ResetBorderStyle() => this.Reset("BorderStyle");

    /// <summary>Gets the border value which can be translated.</summary>
    /// <value>The border.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderValue Border => new BorderValue()
    {
      Color = this.BorderColor,
      Style = this.BorderStyle,
      Width = this.BorderWidth
    };

    /// <summary>Gets the background.</summary>
    /// <value>The background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundValue Background => new BackgroundValue()
    {
      BackColor = this.BackColor,
      BackgroundImage = this.BackgroundImage,
      BackgroundImagePosition = this.BackgroundImagePosition,
      BackgroundImageRepeat = this.BackgroundImageRepeat
    };

    /// <summary>Gets or sets the control disabled style.</summary>
    /// <value>The control disabled style.</value>
    [Category("States")]
    [Description("Gets or sets the control disabled style.")]
    public virtual StyleValue ControlDisabledStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (ControlDisabledStyle));
      set => this.SetValue(nameof (ControlDisabledStyle), (object) value);
    }

    /// <summary>Resets the control disabled style.</summary>
    internal void ResetControlDisabledStyle() => this.Reset("ControlDisabledStyle");

    /// <summary>Gets the text foreground disabled.</summary>
    /// <value>The text foreground disabled.</value>
    [Browsable(false)]
    public ForegroundValue ControlTextForegroundDisabled => new ForegroundValue()
    {
      ForeColor = this.ControlDisabledStyle.ForeColor
    };

    /// <summary>Gets the text background disabled.</summary>
    /// <value>The text background disabled.</value>
    [Browsable(false)]
    public BackgroundValue ControlTextBackgroundDisabled => new BackgroundValue()
    {
      BackColor = this.ControlDisabledStyle.BackColor
    };

    /// <summary>Gets the Opacity value for disabled control</summary>
    /// <value>The Opacity value for disabled control</value>
    [Browsable(false)]
    public OpacityValue ControlOpacityDisabled => new OpacityValue(this.ControlDisabledStyle.Opacity.Opacity);

    /// <summary>Gets the control text font disabled.</summary>
    /// <value>The control text font disabled.</value>
    [Browsable(false)]
    public Font ControlTextFontDisabled => this.ControlDisabledStyle.Font;

    private void InitializeComponent()
    {
    }
  }
}
