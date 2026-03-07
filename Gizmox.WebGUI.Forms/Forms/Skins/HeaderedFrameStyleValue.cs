// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.HeaderedFrameStyleValue
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
  [TypeConverter(typeof (HeaderedFrameStyleValueConverter))]
  [Serializable]
  public class HeaderedFrameStyleValue : FrameStyleValue
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjHeaderLeftStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjHeaderCenterStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjHeaderRightStyle;

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
    /// <param name="objHeaderLeftStyle">The header left style.</param>
    /// <param name="objHeaderCenterStyle">The header center style.</param>
    /// <param name="objHeaderRightStyle">The header right style.</param>
    public HeaderedFrameStyleValue(
      FramePartStyleValue objLeftBottomStyle,
      FramePartStyleValue objLeftStyle,
      FramePartStyleValue objLeftTopStyle,
      FramePartStyleValue objTopStyle,
      FramePartStyleValue objRightTopStyle,
      FramePartStyleValue objRightStyle,
      FramePartStyleValue objRightBottomStyle,
      FramePartStyleValue objBottomStyle,
      StyleValue objCenterStyle,
      StyleValue objHeaderLeftStyle,
      StyleValue objHeaderCenterStyle,
      StyleValue objHeaderRightStyle)
      : base(objLeftBottomStyle, objLeftStyle, objLeftTopStyle, objTopStyle, objRightTopStyle, objRightStyle, objRightBottomStyle, objBottomStyle, objCenterStyle)
    {
      this.mobjHeaderRightStyle = objHeaderRightStyle;
      this.mobjHeaderCenterStyle = objHeaderCenterStyle;
      this.mobjHeaderLeftStyle = objHeaderLeftStyle;
    }

    /// <summary>Gets the header left style.</summary>
    /// <value>The header left style.</value>
    public StyleValue HeaderLeftStyle => this.mobjHeaderLeftStyle;

    /// <summary>Gets the header center style.</summary>
    /// <value>The header center style.</value>
    public StyleValue HeaderCenterStyle => this.mobjHeaderCenterStyle;

    /// <summary>Gets the header right style.</summary>
    /// <value>The header right style.</value>
    public StyleValue HeaderRightStyle => this.mobjHeaderRightStyle;
  }
}
