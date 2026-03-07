// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides generic control styling mechanism</summary>
  [TypeConverter(typeof (BackgroundStyleValueConverter))]
  [Serializable]
  public class BackgroundStyleValue : SkinMultiValue
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
      : base((Skin) objPropertyOwner, strPropertyPrefix)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    public BackgroundStyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      BackgroundStyleValue objDefaults)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) objDefaults)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    /// <param name="blnLocalizeBaseBackgroundStyleValues">Treats inherited base style values as locals.</param>
    public BackgroundStyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      BackgroundStyleValue objDefaults,
      bool blnLocalizeBaseBackgroundStyleValues)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) objDefaults, blnLocalizeBaseBackgroundStyleValues)
    {
    }

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
    protected virtual ImageResourceReference DefaultBackgroundImage => this.Defaults != null ? this.Defaults.GetValue<ImageResourceReference>("BackgroundImage", ImageResourceReference.Empty) : ImageResourceReference.Empty;

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
    protected virtual BackgroundImageRepeat DefaultBackgroundImageRepeat => this.Defaults != null ? ((BackgroundStyleValue) this.Defaults).BackgroundImageRepeat : BackgroundImageRepeat.Repeat;

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
    protected virtual BackgroundImagePosition DefaultBackgroundImagePosition => this.Defaults != null ? ((BackgroundStyleValue) this.Defaults).BackgroundImagePosition : BackgroundImagePosition.MiddleCenter;

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
    protected virtual Color DefaultBackColor => this.Defaults != null ? ((BackgroundStyleValue) this.Defaults).BackColor : Color.Empty;

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

    /// <summary>
    /// Gets a value indicating whether this instance has background.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has background; otherwise, <c>false</c>.
    /// </value>
    protected bool HasBackground => this.HasBackColor || this.HasBackgroundImage || this.HasBackgroundImagePosition || this.HasBackgroundImageRepeat;

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.HasBackground)
        stringBuilder.AppendLine(string.Format("{0};", (object) this.FormatValue(this.Background.GetValue(objContext))));
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
