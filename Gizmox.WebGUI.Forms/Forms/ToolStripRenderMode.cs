// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripRenderMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the painting style applied to one <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> contained in a form.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ToolStripRenderMode
  {
    /// <summary>Indicates that the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.RenderMode"></see> is not determined by the <see cref="T:Gizmox.WebGUI.Forms.ToolStripManager"></see> or the use of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> other than <see cref="T:Gizmox.WebGUI.Forms.ToolStripProfessionalRenderer"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripSystemRenderer"></see></summary>
    /// <filterpriority>1</filterpriority>
    Custom,
    /// <summary>Indicates the use of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSystemRenderer"></see> to paint.</summary>
    /// <filterpriority>1</filterpriority>
    System,
    /// <summary>Indicates the use of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripProfessionalRenderer"></see> to paint.</summary>
    /// <filterpriority>1</filterpriority>
    Professional,
    /// <summary>Indicates that the <see cref="P:Gizmox.WebGUI.Forms.ToolStripManager.RenderMode"></see> or <see cref="P:Gizmox.WebGUI.Forms.ToolStripManager.Renderer"></see> determines the painting style.</summary>
    /// <filterpriority>1</filterpriority>
    ManagerRenderMode,
  }
}
