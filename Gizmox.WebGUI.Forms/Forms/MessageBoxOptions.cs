// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MessageBoxOptions
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies options on a <see cref="T:Gizmox.WebGUI.Forms.MessageBox"></see>.
  /// </summary>
  [Flags]
  public enum MessageBoxOptions
  {
    /// <summary>The message box is displayed on the active desktop.</summary>
    DefaultDesktopOnly = 131072, // 0x00020000
    /// <summary>The message box text is right-aligned.</summary>
    RightAlign = 524288, // 0x00080000
    /// <summary>
    /// Specifies that the message box text is displayed with right to left reading order.
    /// </summary>
    RtlReading = 1048576, // 0x00100000
    /// <summary>The message box is displayed on the active desktop.</summary>
    ServiceNotification = 2097152, // 0x00200000
  }
}
