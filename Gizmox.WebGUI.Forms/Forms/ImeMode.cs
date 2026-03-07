// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ImeMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public enum ImeMode
  {
    Inherit = -1, // 0xFFFFFFFF
    NoControl = 0,
    On = 1,
    Off = 2,
    Disable = 3,
    Hiragana = 4,
    Katakana = 5,
    KatakanaHalf = 6,
    AlphaFull = 7,
    Alpha = 8,
    HangulFull = 9,
    Hangul = 10, // 0x0000000A
    Close = 11, // 0x0000000B
    OnHalf = 12, // 0x0000000C
  }
}
