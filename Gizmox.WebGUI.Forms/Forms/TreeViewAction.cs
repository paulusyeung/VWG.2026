// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeViewAction
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the action that raised a TreeViewEventArgs event.
  /// </summary>
  public enum TreeViewAction
  {
    /// <summary>The action that caused the event is unknown.</summary>
    Unknown,
    /// <summary>The event was caused by a keystroke.</summary>
    ByKeyboard,
    /// <summary>The event was caused by a mouse operation.</summary>
    ByMouse,
    /// <summary>The event was caused by the TreeNode collapsing.</summary>
    Collapse,
    /// <summary>The event was caused by the TreeNode expanding.</summary>
    Expand,
  }
}
