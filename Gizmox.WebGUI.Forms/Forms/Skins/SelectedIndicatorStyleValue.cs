// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.SelectedIndicatorStyleValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (SelectedIndicatorStyleValueConverter))]
  [Serializable]
  public class SelectedIndicatorStyleValue
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjTopStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjBottomStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjLeftStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjLeftTopStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjLeftBottomStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjRightStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjRightTopStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjRightBottomStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.SelectedIndicatorStyleValue" /> class.
    /// </summary>
    /// <param name="objLeftBottomStyle">The left bottom style.</param>
    /// <param name="objLeftStyle">The left style.</param>
    /// <param name="objLeftTopStyle">obj left top style.</param>
    /// <param name="objTopStyle">The top style.</param>
    /// <param name="objRightTopStyle">The right top style.</param>
    /// <param name="objRightStyle">The right style.</param>
    /// <param name="objRightBottomStyle">The right bottom style.</param>
    /// <param name="objBottomStyle">The bottom style.</param>
    public SelectedIndicatorStyleValue(
      StyleValue objLeftBottomStyle,
      StyleValue objLeftStyle,
      StyleValue objLeftTopStyle,
      StyleValue objTopStyle,
      StyleValue objRightTopStyle,
      StyleValue objRightStyle,
      StyleValue objRightBottomStyle,
      StyleValue objBottomStyle)
    {
      this.mobjLeftBottomStyle = objLeftBottomStyle;
      this.mobjLeftStyle = objLeftStyle;
      this.mobjLeftTopStyle = objLeftTopStyle;
      this.mobjTopStyle = objTopStyle;
      this.mobjRightTopStyle = objRightTopStyle;
      this.mobjRightStyle = objRightStyle;
      this.mobjRightBottomStyle = objRightBottomStyle;
      this.mobjBottomStyle = objBottomStyle;
    }

    /// <summary>Gets the top style.</summary>
    /// <value>The top style.</value>
    public StyleValue TopStyle => this.mobjTopStyle;

    /// <summary>Gets the bottom style.</summary>
    /// <value>The bottom style.</value>
    public StyleValue BottomStyle => this.mobjBottomStyle;

    /// <summary>Gets the left style.</summary>
    /// <value>The left style.</value>
    public StyleValue LeftStyle => this.mobjLeftStyle;

    /// <summary>Gets the left top style.</summary>
    /// <value>The left top style.</value>
    public StyleValue LeftTopStyle => this.mobjLeftTopStyle;

    /// <summary>Gets the left bottom style.</summary>
    /// <value>The left bottom style.</value>
    public StyleValue LeftBottomStyle => this.mobjLeftBottomStyle;

    /// <summary>Gets the right style.</summary>
    /// <value>The right style.</value>
    public StyleValue RightStyle => this.mobjRightStyle;

    /// <summary>Gets the right top style.</summary>
    /// <value>The right top style.</value>
    public StyleValue RightTopStyle => this.mobjRightTopStyle;

    /// <summary>Gets the right bottom style.</summary>
    /// <value>The right bottom style.</value>
    public StyleValue RightBottomStyle => this.mobjRightBottomStyle;
  }
}
