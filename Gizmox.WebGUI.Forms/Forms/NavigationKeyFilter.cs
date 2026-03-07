// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NavigationKeyFilter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Navigation Key Filter</summary>
  [Flags]
  public enum NavigationKeyFilter
  {
    /// <summary>No filter</summary>
    None = 0,
    /// <summary>Arrow down key</summary>
    Down = 1,
    /// <summary>Arrow up key</summary>
    Up = 2,
    /// <summary>Arrow left key</summary>
    Left = 4,
    /// <summary>Arrow right key</summary>
    Right = 8,
    /// <summary>Page down key</summary>
    PageDown = 16, // 0x00000010
    /// <summary>Page up key</summary>
    PageUp = 32, // 0x00000020
    /// <summary>Home key</summary>
    Home = 64, // 0x00000040
    /// <summary>End key</summary>
    End = 128, // 0x00000080
    /// <summary>Enter key</summary>
    Enter = 256, // 0x00000100
    /// <summary>Tab key</summary>
    Tab = 512, // 0x00000200
    /// <summary>Filter all navigation keys</summary>
    All = Tab | Enter | End | Home | PageUp | PageDown | Right | Left | Up | Down, // 0x000003FF
  }
}
