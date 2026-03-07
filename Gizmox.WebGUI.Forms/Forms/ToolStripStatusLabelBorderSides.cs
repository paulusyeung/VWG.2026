// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripStatusLabelBorderSides
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies which sides of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> have borders.</summary>
  [ComVisible(true)]
  public enum ToolStripStatusLabelBorderSides
  {
    /// <summary>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has no borders.</summary>
    None = 0,
    /// <summary>Only the left side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
    Left = 1,
    /// <summary>Only the top side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
    Top = 2,
    /// <summary>Only the right side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
    Right = 4,
    /// <summary>Only the bottom side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
    Bottom = 8,
    /// <summary>All sides of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> have borders.</summary>
    All = 15, // 0x0000000F
  }
}
