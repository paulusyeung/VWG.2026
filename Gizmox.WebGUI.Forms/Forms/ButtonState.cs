// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ButtonState
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the appearance of a button.</summary>
  /// <filterpriority>2</filterpriority>
  [Flags]
  public enum ButtonState
  {
    /// <summary>All flags except Normal are set.</summary>
    /// <filterpriority>1</filterpriority>
    All = 18176, // 0x00004700
    /// <summary>The button has a checked or latched appearance. Use this appearance to show that a toggle button has been pressed.</summary>
    /// <filterpriority>1</filterpriority>
    Checked = 1024, // 0x00000400
    /// <summary>The button has a flat, two-dimensional appearance.</summary>
    /// <filterpriority>1</filterpriority>
    Flat = 16384, // 0x00004000
    /// <summary>The button is inactive (grayed).</summary>
    /// <filterpriority>1</filterpriority>
    Inactive = 256, // 0x00000100
    /// <summary>The button has its normal appearance (three-dimensional).</summary>
    /// <filterpriority>1</filterpriority>
    Normal = 0,
    /// <summary>The button appears pressed.</summary>
    /// <filterpriority>1</filterpriority>
    Pushed = 512, // 0x00000200
  }
}
