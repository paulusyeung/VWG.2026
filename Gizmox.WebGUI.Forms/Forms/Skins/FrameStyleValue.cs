// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.FrameStyleValue
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides a class for editing multiple frame styles</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [TypeConverter(typeof (FrameStyleValueConverter))]
  [Serializable]
  public class FrameStyleValue
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjTopStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjBottomStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjLeftStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjLeftTopStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjLeftBottomStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjRightStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjRightTopStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FramePartStyleValue mobjRightBottomStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjCenterStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.FrameStyleValue" /> class.
    /// </summary>
    /// <param name="objLeftBottomStyle">The left bottom style.</param>
    /// <param name="objLeftStyle">The left style.</param>
    /// <param name="objLeftTopStyle">obj left top style.</param>
    /// <param name="objTopStyle">The top style.</param>
    /// <param name="objRightTopStyle">The right top style.</param>
    /// <param name="objRightStyle">The right style.</param>
    /// <param name="objRightBottomStyle">The right bottom style.</param>
    /// <param name="objBottomStyle">The bottom style.</param>
    /// <param name="objCenterStyle">The center style.</param>
    public FrameStyleValue(
      FramePartStyleValue objLeftBottomStyle,
      FramePartStyleValue objLeftStyle,
      FramePartStyleValue objLeftTopStyle,
      FramePartStyleValue objTopStyle,
      FramePartStyleValue objRightTopStyle,
      FramePartStyleValue objRightStyle,
      FramePartStyleValue objRightBottomStyle,
      FramePartStyleValue objBottomStyle,
      StyleValue objCenterStyle)
    {
      this.mobjLeftBottomStyle = objLeftBottomStyle;
      this.mobjLeftStyle = objLeftStyle;
      this.mobjLeftTopStyle = objLeftTopStyle;
      this.mobjTopStyle = objTopStyle;
      this.mobjRightTopStyle = objRightTopStyle;
      this.mobjRightStyle = objRightStyle;
      this.mobjRightBottomStyle = objRightBottomStyle;
      this.mobjBottomStyle = objBottomStyle;
      this.mobjCenterStyle = objCenterStyle;
    }

    /// <summary>Gets the center style.</summary>
    /// <value>The center style.</value>
    public StyleValue CenterStyle => this.mobjCenterStyle;

    /// <summary>Gets the top style.</summary>
    /// <value>The top style.</value>
    public FramePartStyleValue TopStyle => this.mobjTopStyle;

    /// <summary>Gets the bottom style.</summary>
    /// <value>The bottom style.</value>
    public FramePartStyleValue BottomStyle => this.mobjBottomStyle;

    /// <summary>Gets the left style.</summary>
    /// <value>The left style.</value>
    public FramePartStyleValue LeftStyle => this.mobjLeftStyle;

    /// <summary>Gets the left top style.</summary>
    /// <value>The left top style.</value>
    public FramePartStyleValue LeftTopStyle => this.mobjLeftTopStyle;

    /// <summary>Gets the left bottom style.</summary>
    /// <value>The left bottom style.</value>
    public FramePartStyleValue LeftBottomStyle => this.mobjLeftBottomStyle;

    /// <summary>Gets the right style.</summary>
    /// <value>The right style.</value>
    public FramePartStyleValue RightStyle => this.mobjRightStyle;

    /// <summary>Gets the right top style.</summary>
    /// <value>The right top style.</value>
    public FramePartStyleValue RightTopStyle => this.mobjRightTopStyle;

    /// <summary>Gets the right bottom style.</summary>
    /// <value>The right bottom style.</value>
    public FramePartStyleValue RightBottomStyle => this.mobjRightBottomStyle;
  }
}
