// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ScrollBars
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies which scroll bars will be visible on a control.
  /// </summary>
  [Serializable]
  public enum ScrollBars : byte
  {
    /// <summary>Displays no scroll bars.</summary>
    None,
    /// <summary>Displays only a horizontal scroll bar.</summary>
    Horizontal,
    /// <summary>Displays only a vertical scroll bar.</summary>
    Vertical,
    /// <summary>Displays both a horizontal and a vertical scroll bar.</summary>
    Both,
  }
}
