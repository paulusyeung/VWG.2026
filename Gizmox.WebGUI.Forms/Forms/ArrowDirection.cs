// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ArrowDirection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the direction to move when getting items with the <see cref="M:Gizmox.WebGUI.Forms.ToolStrip.GetNextItem(Gizmox.WebGUI.Forms.ToolStripItem,Gizmox.WebGUI.Forms.ArrowDirection)"></see> method.</summary>
  public enum ArrowDirection
  {
    /// <summary>The direction is left (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>).</summary>
    Left = 0,
    /// <summary>The direction is left (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Vertical"></see>).</summary>
    Up = 1,
    /// <summary>The direction is right (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>).</summary>
    Right = 16, // 0x00000010
    /// <summary>The direction is down (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Vertical"></see>).</summary>
    Down = 17, // 0x00000011
  }
}
