// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FormStartPosition
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  public enum FormStartPosition : byte
  {
    /// <summary>
    /// The position of the form is determined by the Location property.
    /// </summary>
    Manual,
    /// <summary>
    /// The form is centered on the current display, and has the dimensions specified in the form's size.
    /// </summary>
    CenterScreen,
    /// <summary>
    /// The form is positioned at the Windows default location and has the dimensions specified in the form's size.
    /// </summary>
    WindowsDefaultLocation,
    /// <summary>
    /// The form is positioned at the Windows default location and has the bounds determined by Windows default.
    /// </summary>
    WindowsDefaultBounds,
    /// <summary>
    /// The form is centered within the bounds of its parent form.
    /// </summary>
    CenterParent,
  }
}
