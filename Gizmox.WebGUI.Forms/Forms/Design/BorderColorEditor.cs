// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.BorderColorEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Drawing;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// 
  /// </summary>
  public class BorderColorEditor : ColorEditor
  {
    /// <summary>
    /// Supplies a editor level mechanism to convert property values before editing
    /// </summary>
    /// <param name="value">The property value.</param>
    /// <returns></returns>
    protected override object GetEditorValueFromPropertyValue(object objValue) => objValue != null ? (object) ((BorderColor) objValue).All : (object) Color.Empty;

    /// <summary>
    /// Supplies a editor level mechanism to convert editor returned values before assigning to property
    /// </summary>
    /// <param name="value">The editor returned value.</param>
    /// <returns></returns>
    protected override object GetPropertyValueFromEditorValue(object objValue) => objValue != null ? (object) new BorderColor((Color) objValue) : (object) BorderColor.Empty;
  }
}
