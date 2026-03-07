// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FlowDirection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Defines constants that specify the direction in which consecutive user interface (UI) elements are placed in a linear layout container.
  /// </summary>
  public enum FlowDirection
  {
    /// <summary>
    /// Elements flow from the left edge of the design surface to the right.
    /// </summary>
    LeftToRight = 1,
    /// <summary>
    /// Elements flow from the top of the design surface to the bottom.
    /// </summary>
    TopDown = 2,
    /// <summary>
    /// Elements flow from the right edge of the design surface to the left.
    /// </summary>
    RightToLeft = 4,
    /// <summary>
    /// Elements flow from the bottom of the design surface to the top.
    /// </summary>
    BottomUp = 8,
  }
}
