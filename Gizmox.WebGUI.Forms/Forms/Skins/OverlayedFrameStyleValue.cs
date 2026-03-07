// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.OverlayedFrameStyleValue
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
  [TypeConverter(typeof (OverlayedFrameStyleValueConverter))]
  [Serializable]
  public class OverlayedFrameStyleValue : FrameStyleValue
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly FrameOverlayStyleValue mobjLeftOverlayStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly FrameOverlayStyleValue mobjRightOverlayStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.OverlayedFrameStyleValue" /> class.
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
    /// <param name="objLeftOverlayStyle">The left overlay style.</param>
    /// <param name="objRightOverlayStyle">The right overlay style.</param>
    public OverlayedFrameStyleValue(
      FramePartStyleValue objLeftBottomStyle,
      FramePartStyleValue objLeftStyle,
      FramePartStyleValue objLeftTopStyle,
      FramePartStyleValue objTopStyle,
      FramePartStyleValue objRightTopStyle,
      FramePartStyleValue objRightStyle,
      FramePartStyleValue objRightBottomStyle,
      FramePartStyleValue objBottomStyle,
      StyleValue objCenterStyle,
      FrameOverlayStyleValue objLeftOverlayStyle,
      FrameOverlayStyleValue objRightOverlayStyle)
      : base(objLeftBottomStyle, objLeftStyle, objLeftTopStyle, objTopStyle, objRightTopStyle, objRightStyle, objRightBottomStyle, objBottomStyle, objCenterStyle)
    {
      this.mobjLeftOverlayStyle = objLeftOverlayStyle;
      this.mobjRightOverlayStyle = objRightOverlayStyle;
    }

    /// <summary>Gets the left overlay style.</summary>
    /// <value>The left overlay style.</value>
    public FrameOverlayStyleValue LeftOverlayStyle => this.mobjLeftOverlayStyle;

    /// <summary>Gets the right overlay style.</summary>
    /// <value>The right overlay style.</value>
    public FrameOverlayStyleValue RightOverlayStyle => this.mobjRightOverlayStyle;
  }
}
