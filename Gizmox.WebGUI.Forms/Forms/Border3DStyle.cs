// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Border3DStyle
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
  public enum Border3DStyle
  {
    RaisedOuter = 1,
    SunkenOuter = 2,
    RaisedInner = 4,
    Raised = 5,
    Etched = 6,
    SunkenInner = 8,
    Bump = 9,
    Sunken = 10, // 0x0000000A
    Adjust = 8192, // 0x00002000
    Flat = 16394, // 0x0000400A
  }
}
