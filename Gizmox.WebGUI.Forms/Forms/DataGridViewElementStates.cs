// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewElementStates
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the user interface (UI) state of a element within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  [Flags]
  [Serializable]
  public enum DataGridViewElementStates
  {
    /// <summary>Indicates the an element is currently displayed onscreen.</summary>
    Displayed = 1,
    /// <summary>Indicates that an element cannot be scrolled through the UI.</summary>
    Frozen = 2,
    /// <summary>Indicates that an element is in its default state.</summary>
    None = 0,
    /// <summary>Indicates that an element will not accept user input to change its value.</summary>
    ReadOnly = 4,
    /// <summary>Indicates that an element can be resized through the UI. This value is ignored except when combined with the <see cref="F:Gizmox.WebGUI.Forms.DataGridViewElementStates.ResizableSet"></see> value.</summary>
    Resizable = 8,
    /// <summary>Indicates that an element does not inherit the resizable state of its parent.</summary>
    ResizableSet = 16, // 0x00000010
    /// <summary>Indicates that an element is in a selected (highlighted) UI state.</summary>
    Selected = 32, // 0x00000020
    /// <summary>Indicates that an element is visible (displayable).</summary>
    Visible = 64, // 0x00000040
  }
}
