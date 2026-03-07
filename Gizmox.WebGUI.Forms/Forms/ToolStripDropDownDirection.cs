// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownDirection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the direction in which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is displayed relative to its parent control.</summary>
  public enum ToolStripDropDownDirection
  {
    /// <summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed above and to the left of its parent control.</summary>
    AboveLeft = 0,
    /// <summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed above and to the right of its parent control.</summary>
    AboveRight = 1,
    /// <summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed below and to the left of its parent control.</summary>
    BelowLeft = 2,
    /// <summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed below and to the right of its parent control.</summary>
    BelowRight = 3,
    /// <summary>Compensates for nested drop-down controls and specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed to the left of its parent control.</summary>
    Left = 4,
    /// <summary>Compensates for nested drop-down controls and specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed to the right of its parent control.</summary>
    Right = 5,
    /// <summary>Compensates for nested drop-down controls and responds to the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> setting, specifying either <see cref="F:Gizmox.WebGUI.Forms.ToolStripDropDownDirection.Left"></see> or <see cref="F:Gizmox.WebGUI.Forms.ToolStripDropDownDirection.Right"></see> accordingly.</summary>
    Default = 7,
  }
}
