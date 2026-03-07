// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.StyleValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides generic control styling mechanism</summary>
  [TypeConverter(typeof (StyleValueConverter))]
  [Serializable]
  public class StyleValue : SkinMultiValue
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
      : base((Skin) objPropertyOwner, strPropertyPrefix)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    public StyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      bool blnIsAmbientValues)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) null, blnIsAmbientValues)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    public StyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      StyleValue objDefaults)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) objDefaults)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    /// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
    public StyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      StyleValue objDefaults,
      bool blnLocalizeBaseStyleValues)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) objDefaults, blnLocalizeBaseStyleValues)
    {
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <value></value>
    /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
    [Category("Fonts")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlFontDescr")]
    public Font Font
    {
      get => this.GetValue<Font>(nameof (Font), this.DefaultFont);
      set => this.SetValue(nameof (Font), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has font.
    /// </summary>
    /// <value><c>true</c> if this instance has font; otherwise, <c>false</c>.</value>
    protected bool HasFont => this.HasValue("Font");

    /// <summary>Resets the font.</summary>
    private void ResetFont() => this.Reset("Font");

    /// <summary>Gets or sets the default font.</summary>
    /// <value></value>
    protected Font DefaultFont => this.Defaults != null ? ((StyleValue) this.Defaults).Font : ((CommonSkin) this.Skin).Font;

    /// <summary>Gets or sets the background image.</summary>
    /// <value>The background image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlBackgroundImageDescr")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public ImageResourceReference BackgroundImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (BackgroundImage), this.DefaultBackgroundImage);
      set => this.SetValue(nameof (BackgroundImage), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has background image.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has background image; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBackgroundImage => this.BackgroundImage != ImageResourceReference.Empty;

    /// <summary>Resets the font.</summary>
    private void ResetBackgroundImage() => this.Reset("BackgroundImage");

    /// <summary>Gets or sets the default background image.</summary>
    /// <value></value>
    protected virtual ImageResourceReference DefaultBackgroundImage
    {
      get
      {
        if (this.Defaults != null)
          return this.Defaults.GetValue<ImageResourceReference>("BackgroundImage", ImageResourceReference.Empty);
        return this.Skin is ControlSkin skin ? skin.BackgroundImage : ImageResourceReference.Empty;
      }
    }

    /// <summary>Gets or sets the background image repeat.</summary>
    /// <value>The background image repeat.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets if or how a background image will be repeated.")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public BackgroundImageRepeat BackgroundImageRepeat
    {
      get => this.GetValue<BackgroundImageRepeat>(nameof (BackgroundImageRepeat), this.DefaultBackgroundImageRepeat);
      set => this.SetValue(nameof (BackgroundImageRepeat), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has background image repeat.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has background image repeat; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBackgroundImageRepeat => this.HasValue("BackgroundImageRepeat");

    /// <summary>Resets the BackgroundImageRepeat.</summary>
    private void ResetBackgroundImageRepeat() => this.Reset("BackgroundImageRepeat");

    /// <summary>Gets or sets the default background image repeat.</summary>
    /// <value></value>
    protected virtual BackgroundImageRepeat DefaultBackgroundImageRepeat => this.Defaults != null ? ((StyleValue) this.Defaults).BackgroundImageRepeat : BackgroundImageRepeat.Repeat;

    /// <summary>Gets or sets the background image position.</summary>
    /// <value>The background image position.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets the starting position of a background image.")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public BackgroundImagePosition BackgroundImagePosition
    {
      get => this.GetValue<BackgroundImagePosition>(nameof (BackgroundImagePosition), this.DefaultBackgroundImagePosition);
      set => this.SetValue(nameof (BackgroundImagePosition), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has background image position.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has background image position; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBackgroundImagePosition => this.HasValue("BackgroundImagePosition");

    /// <summary>Gets or sets the default background image position.</summary>
    /// <value></value>
    protected virtual BackgroundImagePosition DefaultBackgroundImagePosition => this.Defaults != null ? ((StyleValue) this.Defaults).BackgroundImagePosition : BackgroundImagePosition.MiddleCenter;

    /// <summary>Gets or sets the fore color.</summary>
    /// <value></value>
    /// <remarks>ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlForeColorDescr")]
    public Color ForeColor
    {
      get => this.GetValue<Color>(nameof (ForeColor), this.DefaultForeColor);
      set => this.SetValue(nameof (ForeColor), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has fore color.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has fore color; otherwise, <c>false</c>.
    /// </value>
    protected bool HasForeColor => this.HasValue("ForeColor");

    /// <summary>Resets the ForeColor.</summary>
    private void ResetForeColor() => this.Reset("ForeColor");

    /// <summary>Gets or sets the default fore color.</summary>
    /// <value></value>
    protected virtual Color DefaultForeColor => this.Defaults != null ? ((StyleValue) this.Defaults).ForeColor : ((CommonSkin) this.Skin).ForeColor;

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlBackColorDescr")]
    public virtual Color BackColor
    {
      get => this.GetValue<Color>(nameof (BackColor), this.DefaultBackColor);
      set => this.SetValue(nameof (BackColor), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has back color.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has back color; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBackColor => this.HasValue("BackColor");

    /// <summary>Resets the BackColor.</summary>
    private void ResetBackColor() => this.Reset("BackColor");

    /// <summary>Gets or sets the default back color.</summary>
    /// <value></value>
    protected virtual Color DefaultBackColor
    {
      get
      {
        if (this.Defaults != null)
          return ((StyleValue) this.Defaults).BackColor;
        return this.Skin is ControlSkin skin ? skin.BackColor : Color.Empty;
      }
    }

    /// <summary>Gets or sets the padding.</summary>
    /// <value>The padding.</value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlPaddingDescr")]
    [Category("Layout")]
    public PaddingValue Padding
    {
      get => this.GetValue<PaddingValue>(nameof (Padding), this.DefaultPadding);
      set => this.SetValue(nameof (Padding), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has padding.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has padding; otherwise, <c>false</c>.
    /// </value>
    protected bool HasPadding => this.HasValue("Padding");

    /// <summary>Resets the Padding.</summary>
    private void ResetPadding() => this.Reset("Padding");

    /// <summary>Gets or sets the opacity.</summary>
    /// <value>The opacity.</value>
    [Gizmox.WebGUI.Forms.SRDescription("ControlOpacityDescr")]
    [Category("CatAppearance")]
    public OpacityValue Opacity
    {
      get => this.GetValue<OpacityValue>(nameof (Opacity), this.DefaultOpacity);
      set => this.SetValue(nameof (Opacity), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has opacity.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has opacity; otherwise, <c>false</c>.
    /// </value>
    protected bool HasOpacity => this.HasValue("Opacity");

    /// <summary>Resets the opacity.</summary>
    private void ResetOpacity() => this.Reset("Opacity");

    /// <summary>Resets this instance.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Reset()
    {
      this.ResetBackColor();
      this.ResetBackgroundImage();
      this.ResetBackgroundImageRepeat();
      this.ResetBorderColor();
      this.ResetBorderStyle();
      this.ResetBorderWidth();
      this.ResetFont();
      this.ResetForeColor();
      this.ResetMargin();
      this.ResetPadding();
      this.ResetOpacity();
    }

    /// <summary>Gets or sets the default padding.</summary>
    /// <value></value>
    protected virtual PaddingValue DefaultPadding => this.Defaults != null ? this.Defaults.GetValue<PaddingValue>("Padding", PaddingValue.Empty) : (PaddingValue) "0";

    /// <summary>
    /// Gets a value indicating whether this instance has padding.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has padding; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBorderRadius => this.HasValue("BorderRadius");

    /// <summary>Resets the Padding.</summary>
    private void ResetBorderRadius() => this.Reset("BorderRadius");

    /// <summary>Gets the default opacity.</summary>
    /// <value>The default opacity.</value>
    protected virtual OpacityValue DefaultOpacity => this.Defaults != null ? this.Defaults.GetValue<OpacityValue>("Opacity", (OpacityValue) "100") : OpacityValue.Empty;

    /// <summary>Gets or sets the space between controls.</summary>
    /// <value>The space between controls.</value>
    [Category("Layout")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlMarginDescr")]
    public MarginValue Margin
    {
      get => this.GetValue<MarginValue>(nameof (Margin), this.DefaultMargin);
      set => this.SetValue(nameof (Margin), (object) value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has margin.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has margin; otherwise, <c>false</c>.
    /// </value>
    protected bool HasMargin => this.HasValue("Margin");

    /// <summary>Resets the Margin.</summary>
    private void ResetMargin() => this.Reset("Margin");

    /// <summary>Gets or sets the default margin.</summary>
    /// <value></value>
    protected virtual MarginValue DefaultMargin => this.Defaults != null ? this.Defaults.GetValue<MarginValue>("Margin", MarginValue.Empty) : MarginValue.Empty;

    /// <summary>Gets or sets the width of the border.</summary>
    /// <value></value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlBorderWidthDescr")]
    public BorderWidth BorderWidth
    {
      get => this.GetValue<BorderWidth>(nameof (BorderWidth), this.DefaultBorderWidth);
      set => this.SetValue(nameof (BorderWidth), (object) value);
    }

    /// <summary>Resets the BorderColor.</summary>
    private void ResetBorderWidth() => this.Reset("BorderWidth");

    /// <summary>
    /// Gets a value indicating whether this instance has border width.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has border width; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBorderWidth => this.HasValue("BorderWidth");

    /// <summary>Gets or sets the default border width.</summary>
    /// <value></value>
    protected virtual BorderWidth DefaultBorderWidth
    {
      get
      {
        if (this.Defaults != null)
          return this.Defaults.GetValue<BorderWidth>("BorderWidth", BorderWidth.Empty);
        return this.Skin is ControlSkin skin ? skin.BorderWidth : new BorderWidth(1);
      }
    }

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlBorderColorDescr")]
    public BorderColor BorderColor
    {
      get => this.GetValue<BorderColor>(nameof (BorderColor), this.DefaultBorderColor);
      set => this.SetValue(nameof (BorderColor), (object) value);
    }

    /// <summary>Gets or sets the visual effect.</summary>
    /// <value>The visual effect.</value>
    [Category("Styles")]
    [Description("Provide definitions for visual effects.")]
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public VisualEffectValue VisualEffect
    {
      get => this.GetValue<VisualEffectValue>(nameof (VisualEffect), (VisualEffectValue) null);
      set => this.SetValue(nameof (VisualEffect), (object) value);
    }

    /// <summary>Resets the visual effect.</summary>
    private void ResetVisualEffect() => this.Reset("VisualEffect");

    /// <summary>Resets the BorderColor.</summary>
    private void ResetBorderColor() => this.Reset("BorderColor");

    /// <summary>
    /// Gets a value indicating whether this instance has border color.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has border color; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBorderColor => this.HasValue("BorderColor");

    /// <summary>
    /// Gets a value indicating whether this instance has visual effect.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has visual effect; otherwise, <c>false</c>.
    /// </value>
    protected bool HasVisualEffect => this.HasValue("VisualEffect");

    /// <summary>Gets or sets the default border width.</summary>
    /// <value></value>
    protected virtual BorderColor DefaultBorderColor
    {
      get
      {
        if (this.Defaults != null)
          return this.Defaults.GetValue<BorderColor>("BorderColor", new BorderColor(Color.FromArgb(111, 157, 217)));
        return this.Skin is ControlSkin skin ? skin.BorderColor : BorderColor.Empty;
      }
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("ControlBorderStyleDescr")]
    public BorderStyle BorderStyle
    {
      get => this.GetValue<BorderStyle>(nameof (BorderStyle), this.DefaultBorderStyle);
      set => this.SetValue(nameof (BorderStyle), (object) value);
    }

    /// <summary>Resets the BorderColor.</summary>
    private void ResetBorderStyle() => this.Reset("BorderStyle");

    /// <summary>
    /// Gets a value indicating whether this instance has border style.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has border style; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBorderStyle => this.HasValue("BorderStyle");

    /// <summary>Gets or sets the default border style.</summary>
    /// <value></value>
    protected virtual BorderStyle DefaultBorderStyle
    {
      get
      {
        if (this.Defaults != null)
          return this.Defaults.GetValue<BorderStyle>("BorderStyle", BorderStyle.FixedSingle);
        return this.Skin is ControlSkin skin ? skin.BorderStyle : BorderStyle.None;
      }
    }

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
    public BackgroundValue Background
    {
      get
      {
        BackgroundValue background = new BackgroundValue();
        if (this.HasBackColor)
          background.BackColor = this.BackColor;
        if (this.HasBackgroundImage)
        {
          background.BackgroundImage = this.BackgroundImage;
          background.BackgroundImagePosition = this.BackgroundImagePosition;
          background.BackgroundImageRepeat = this.BackgroundImageRepeat;
        }
        return background;
      }
    }

    /// <summary>Gets the foreground.</summary>
    /// <value>The foreground.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ForegroundValue Foreground => new ForegroundValue()
    {
      ForeColor = this.ForeColor
    };

    /// <summary>
    /// Gets a value indicating whether this instance has background.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has background; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBackground => this.HasBackColor || this.HasBackgroundImage || this.HasBackgroundImagePosition || this.HasBackgroundImageRepeat;

    /// <summary>
    /// Gets a value indicating whether this instance has border.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has border; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBorder => this.HasBorderColor || this.HasBorderStyle || this.HasBorderWidth;

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.HasFont)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(SkinTranslator.GetFont(objContext, this.Font, objValueDefinition))));
      if (this.HasBackground)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Background.GetValue(objContext, objValueDefinition))));
      if (this.HasForeColor)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Foreground.GetValue(objContext, objValueDefinition))));
      if (this.HasBorder)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Border.GetValue(objContext, objValueDefinition))));
      if (this.HasMargin)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Margin.GetValue(objContext, objValueDefinition))));
      if (this.HasPadding)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Padding.GetValue(objContext, objValueDefinition))));
      if (this.HasOpacity)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Opacity.GetValue(objContext, objValueDefinition))));
      if (this.HasVisualEffect)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.VisualEffect.GetValue(objContext, objValueDefinition))));
      return this.FormatValue(stringBuilder.ToString());
    }

    private string FormatValue(string strValue)
    {
      if (string.IsNullOrEmpty(strValue))
        return string.Empty;
      return strValue.TrimEnd(';', '\r', '\n');
    }
  }
}
