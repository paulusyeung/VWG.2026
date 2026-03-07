// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemOverflow
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Determines whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is placed in the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ToolStripItemOverflow
  {
    /// <summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is never a candidate for the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>. If the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> cannot fit on the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, it will not be shown.</summary>
    /// <filterpriority>1</filterpriority>
    Never,
    /// <summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is permanently shown in the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    Always,
    /// <summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> drifts between the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> and the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> as required if space is not available on the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    AsNeeded,
  }
}
