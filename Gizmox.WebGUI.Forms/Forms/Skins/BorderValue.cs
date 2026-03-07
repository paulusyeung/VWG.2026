// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.BorderValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides a way to return a composed skin value</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class BorderValue : SkinValue
  {
    /// <summary>
    /// 
    /// </summary>
    private BorderStyle menmStyle;
    /// <summary>
    /// 
    /// </summary>
    private BorderWidth mobjBorderWidth = BorderWidth.Empty;
    /// <summary>
    /// 
    /// </summary>
    private BorderColor mobjBorderColor = BorderColor.Empty;
    /// <summary>
    /// 
    /// </summary>
    private CornerRadius mobjCorner = CornerRadius.Empty;

    /// <summary>Gets or sets the style.</summary>
    /// <value>The style.</value>
    public BorderStyle Style
    {
      get => this.menmStyle;
      set => this.menmStyle = value;
    }

    /// <summary>Gets or sets the width.</summary>
    /// <value>The width.</value>
    public BorderWidth Width
    {
      get => this.mobjBorderWidth;
      set => this.mobjBorderWidth = value;
    }

    /// <summary>Gets or sets the color.</summary>
    /// <value>The color.</value>
    public BorderColor Color
    {
      get => this.mobjBorderColor;
      set => this.mobjBorderColor = value;
    }

    /// <summary>Gets or sets the corner values.</summary>
    /// <value>The corner values.</value>
    public CornerRadius Corner
    {
      get => this.mobjCorner;
      set => this.mobjCorner = value;
    }

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      if (this.menmStyle == BorderStyle.None)
        return string.Format("border:none{0};", (object) declarationValue);
      StringBuilder stringBuilder = new StringBuilder();
      string str1 = string.Format("border-top:{0}px {1} {2}{3};", (object) this.mobjBorderWidth.Top, (object) BorderValue.GetBorderName(this.menmStyle), BorderValue.GetBorderColor(this.mobjBorderColor.Top), (object) declarationValue);
      string str2 = string.Format("border-left:{0}px {1} {2}{3};", (object) this.mobjBorderWidth.Left, (object) BorderValue.GetBorderName(this.menmStyle), BorderValue.GetBorderColor(this.mobjBorderColor.Left), (object) declarationValue);
      string str3 = string.Format("border-right:{0}px {1} {2}{3};", (object) this.mobjBorderWidth.Right, (object) BorderValue.GetBorderName(this.menmStyle), BorderValue.GetBorderColor(this.mobjBorderColor.Right), (object) declarationValue);
      string str4 = string.Format("border-bottom:{0}px {1} {2}{3};", (object) this.mobjBorderWidth.Bottom, (object) BorderValue.GetBorderName(this.menmStyle), BorderValue.GetBorderColor(this.mobjBorderColor.Bottom), (object) declarationValue);
      stringBuilder.Append(string.Format("{0}{1}{2}{3}", (object) str1, (object) str2, (object) str3, (object) str4));
      return stringBuilder.ToString();
    }

    /// <summary>Gets the name of the border.</summary>
    /// <param name="enmStyle">The border style.</param>
    /// <returns></returns>
    internal static string GetBorderName(BorderStyle enmStyle)
    {
      switch (enmStyle)
      {
        case BorderStyle.FixedSingle:
          return "solid";
        case BorderStyle.Fixed3D:
          return "solid";
        case BorderStyle.Dashed:
          return "dashed";
        case BorderStyle.Dotted:
          return "dotted";
        case BorderStyle.Inset:
          return "inset";
        case BorderStyle.Outset:
          return "outset";
        default:
          return "fixed";
      }
    }

    /// <summary>Gets the color of the border.</summary>
    /// <param name="objColor">The border color.</param>
    /// <returns></returns>
    internal static object GetBorderColor(System.Drawing.Color objColor) => (object) CommonUtils.GetHtmlColor(objColor);
  }
}
