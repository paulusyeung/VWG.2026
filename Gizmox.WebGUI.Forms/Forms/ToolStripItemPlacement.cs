// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemPlacement
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies where a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be layed out.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ToolStripItemPlacement
  {
    /// <summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be layed out on the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    Main,
    /// <summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be layed out on the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    Overflow,
    /// <summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not to be layed out on the screen.</summary>
    /// <filterpriority>1</filterpriority>
    None,
  }
}
