// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColorDepth
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
  public enum ColorDepth
  {
    Depth4Bit = 4,
    Depth8Bit = 8,
    Depth16Bit = 16, // 0x00000010
    Depth24Bit = 24, // 0x00000018
    Depth32Bit = 32, // 0x00000020
  }
}
