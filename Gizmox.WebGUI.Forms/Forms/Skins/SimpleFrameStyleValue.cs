// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.SimpleFrameStyleValue
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
  [TypeConverter(typeof (SimpleFrameStyleValueConverter))]
  [Serializable]
  public class SimpleFrameStyleValue
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjRightStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjLeftStyle;
    /// <summary>
    /// 
    /// </summary>
    private readonly StyleValue mobjCenterStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.SimpleFrameStyleValue" /> class.
    /// </summary>
    /// <param name="objLeftStyle">The left style.</param>
    /// <param name="objRightStyle">The right style.</param>
    /// <param name="objCenterStyle">The center style.</param>
    public SimpleFrameStyleValue(
      StyleValue objLeftStyle,
      StyleValue objRightStyle,
      StyleValue objCenterStyle)
    {
      this.mobjLeftStyle = objLeftStyle;
      this.mobjRightStyle = objRightStyle;
      this.mobjCenterStyle = objCenterStyle;
    }

    /// <summary>Gets the center style.</summary>
    /// <value>The center style.</value>
    public StyleValue CenterStyle => this.mobjCenterStyle;

    /// <summary>Gets the right style.</summary>
    /// <value>The right style.</value>
    public StyleValue RightStyle => this.mobjRightStyle;

    /// <summary>Gets the left style.</summary>
    /// <value>The left style.</value>
    public StyleValue LeftStyle => this.mobjLeftStyle;
  }
}
