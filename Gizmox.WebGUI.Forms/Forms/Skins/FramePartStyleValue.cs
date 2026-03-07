// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.FramePartStyleValue
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
  public class FramePartStyleValue : SkinMultiValue
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FramePartStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    public FramePartStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
      : base((Skin) objPropertyOwner, strPropertyPrefix)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FramePartStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    public FramePartStyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      FramePartStyleValue objDefaults)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) objDefaults)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FramePartStyleValue" /> class.
    /// </summary>
    /// <param name="objPropertyOwner">The property owner.</param>
    /// <param name="strPropertyPrefix">The property prefix.</param>
    /// <param name="objDefaults">The defaults.</param>
    /// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
    public FramePartStyleValue(
      CommonSkin objPropertyOwner,
      string strPropertyPrefix,
      FramePartStyleValue objDefaults,
      bool blnLocalizeBaseStyleValues)
      : base((Skin) objPropertyOwner, strPropertyPrefix, (SkinMultiValue) objDefaults, blnLocalizeBaseStyleValues)
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

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      if (!this.HasBackgroundImage)
        return string.Empty;
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      return string.Format("background-image:url({0}){1};", (object) this.BackgroundImage.GetValue(objContext, objValueDefinition), (object) declarationValue);
    }
  }
}
