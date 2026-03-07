// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.FrameOverlayStyleValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides a class for editing multiple frame styles</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class FrameOverlayStyleValue : FramePartStyleValue
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FrameOverlayStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    public FrameOverlayStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
      : base(objPropertyOwner, strPropertyPrefix)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FrameOverlayStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    public FrameOverlayStyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      FrameOverlayStyleValue objDefaults)
      : base(objPropertyOwner, strPropertyPrefix, (FramePartStyleValue) objDefaults)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FrameOverlayStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    /// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
    public FrameOverlayStyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      FrameOverlayStyleValue objDefaults,
      bool blnLocalizeBaseStyleValues)
      : base(objPropertyOwner, strPropertyPrefix, (FramePartStyleValue) objDefaults, blnLocalizeBaseStyleValues)
    {
    }

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
    protected virtual BackgroundImagePosition DefaultBackgroundImagePosition => this.Defaults != null ? ((FrameOverlayStyleValue) this.Defaults).BackgroundImagePosition : BackgroundImagePosition.TopLeft;

    /// <summary>Resets the BackgroundImagePosition.</summary>
    private void ResetBackgroundImagePosition() => this.Reset("BackgroundImagePosition");

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      if (!this.HasBackgroundImagePosition)
        return base.GetValue(objContext, objValueDefinition);
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      return string.Format("background-position:{0}{1};{2}", (object) BackgroundValue.GetCSSValue(this.BackgroundImagePosition), (object) declarationValue, (object) base.GetValue(objContext, objValueDefinition));
    }
  }
}
