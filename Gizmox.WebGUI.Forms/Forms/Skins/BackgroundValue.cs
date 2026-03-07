// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.BackgroundValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Holds the Background Value of the control</summary>
  [Serializable]
  public class BackgroundValue : SkinValue
  {
    /// <summary>The background color</summary>
    private Color mobjBackColor = Color.Empty;
    /// <summary>The background image</summary>
    private ImageResourceReference mobjBackgroundImage = ImageResourceReference.Empty;
    /// <summary>The background image repeating definition</summary>
    private BackgroundImageRepeat menmBackgroundImageRepeat = BackgroundImageRepeat.Repeat;
    /// <summary>The background image positioning definition</summary>
    private BackgroundImagePosition menmBackgroundImagePosition = BackgroundImagePosition.MiddleCenter;

    /// <summary>Gets or sets the color of the back.</summary>
    /// <value>The color of the back.</value>
    public Color BackColor
    {
      get => this.mobjBackColor;
      set => this.mobjBackColor = value;
    }

    /// <summary>Gets or sets the background image.</summary>
    /// <value>The background image.</value>
    public ImageResourceReference BackgroundImage
    {
      get => this.mobjBackgroundImage;
      set => this.mobjBackgroundImage = value;
    }

    /// <summary>Gets or sets the background image repeat.</summary>
    /// <value>The background image repeat.</value>
    public BackgroundImageRepeat BackgroundImageRepeat
    {
      get => this.menmBackgroundImageRepeat;
      set => this.menmBackgroundImageRepeat = value;
    }

    /// <summary>Gets or sets the background image position.</summary>
    /// <value>The background image position.</value>
    public BackgroundImagePosition BackgroundImagePosition
    {
      get => this.menmBackgroundImagePosition;
      set => this.menmBackgroundImagePosition = value;
    }

    /// <summary>Gets the translated value.</summary>
    /// <param name="objContext">The current context.</param>
    /// <returns></returns>
    public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
    {
      string declarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
      StringBuilder stringBuilder = new StringBuilder();
      if (this.mobjBackColor != Color.Empty)
      {
        string str = string.Format("background-color:{0}{1};", (object) CommonUtils.GetHtmlColor(this.mobjBackColor), (object) declarationValue);
        stringBuilder.Append(str);
      }
      if (this.mobjBackgroundImage != ImageResourceReference.Empty)
      {
        string str1 = string.Format("background-image:url({0}){1};", (object) this.mobjBackgroundImage.GetValue(objContext, objValueDefinition), (object) declarationValue);
        string str2 = string.Format("background-position:{0}{1};", (object) BackgroundValue.GetCSSValue(this.menmBackgroundImagePosition), (object) declarationValue);
        string str3 = string.Format("background-repeat:{0}{1};", (object) BackgroundValue.GetCSSValue(this.menmBackgroundImageRepeat), (object) declarationValue);
        stringBuilder.Append(string.Format("{0}{1}{2}", (object) str1, (object) str2, (object) str3));
      }
      return stringBuilder.ToString();
    }

    /// <summary>Gets the CSS value.</summary>
    /// <param name="enmBackgroundImageRepeat">The background image repeat definition.</param>
    /// <returns></returns>
    internal static string GetCSSValue(BackgroundImageRepeat enmBackgroundImageRepeat)
    {
      switch (enmBackgroundImageRepeat)
      {
        case BackgroundImageRepeat.None:
          return "no-repeat";
        case BackgroundImageRepeat.Repeat:
          return "repeat";
        case BackgroundImageRepeat.RepeatX:
          return "repeat-x";
        case BackgroundImageRepeat.RepeatY:
          return "repeat-y";
        default:
          return "repeat";
      }
    }

    /// <summary>Gets the CSS value.</summary>
    /// <param name="enmBackgroundImagePosition">The background image position.</param>
    /// <returns></returns>
    internal static string GetCSSValue(BackgroundImagePosition enmBackgroundImagePosition)
    {
      switch (enmBackgroundImagePosition)
      {
        case BackgroundImagePosition.BottomCenter:
          return "bottom center";
        case BackgroundImagePosition.BottomLeft:
          return "bottom left";
        case BackgroundImagePosition.BottomRight:
          return "bottom right";
        case BackgroundImagePosition.MiddleCenter:
          return "center center";
        case BackgroundImagePosition.MiddleLeft:
          return "center left";
        case BackgroundImagePosition.MiddleRight:
          return "center right";
        case BackgroundImagePosition.TopCenter:
          return "top center";
        case BackgroundImagePosition.TopLeft:
          return "top left";
        case BackgroundImagePosition.TopRight:
          return "top right";
        default:
          return "center center";
      }
    }
  }
}
