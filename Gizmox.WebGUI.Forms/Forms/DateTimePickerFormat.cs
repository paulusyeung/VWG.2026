// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DateTimePickerFormat
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the date and time format the <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker" /> control displays.
  /// </summary>
  [Serializable]
  public enum DateTimePickerFormat
  {
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in the long date format set by the user's operating system.
    /// </summary>
    Long = 1,
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in the short date format set by the user's operating system.
    /// </summary>
    Short = 2,
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in the time format set by the user's operating system.
    /// </summary>
    Time = 4,
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.DateTimePicker"></see> control displays the date/time value in a custom format.
    /// </summary>
    Custom = 8,
  }
}
