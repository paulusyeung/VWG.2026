// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ErrorBlinkStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies constants indicating when the error icon, supplied by an <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" />, should blink to alert the user that an error has occurred.
  /// </summary>
  public enum ErrorBlinkStyle
  {
    /// <summary>
    /// Blinks when the icon is already displayed and a new error string is set for the control.
    /// </summary>
    BlinkIfDifferentError,
    /// <summary>
    /// Always blink when the error icon is first displayed, or when a error description string is set for the control and the error icon is already displayed.
    /// </summary>
    AlwaysBlink,
    /// <summary>Never blink the error icon.</summary>
    NeverBlink,
  }
}
