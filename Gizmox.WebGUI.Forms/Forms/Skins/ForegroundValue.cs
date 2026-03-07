// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ForegroundValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Holds the Foreground Value of the control.</summary>
  [Serializable]
  public class ForegroundValue : SkinValue
  {
    /// <summary>
    /// 
    /// </summary>
    private Color mobjColor = Color.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.ForegroundValue" /> class.
    /// </summary>
    public ForegroundValue()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.ForegroundValue" /> class.
    /// </summary>
    public ForegroundValue(Color objColor) => this.ForeColor = objColor;

    /// <summary>Gets or sets the color of the fore.</summary>
    /// <value>The color of the fore.</value>
    public Color ForeColor
    {
      get => this.mobjColor;
      set => this.mobjColor = value;
    }

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      if (!(this.mobjColor != Color.Empty))
        return string.Empty;
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      return string.Format("color:{0}{1}", (object) CommonUtils.GetHtmlColor(this.mobjColor), (object) declarationValue);
    }
  }
}
