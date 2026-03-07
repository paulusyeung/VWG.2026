// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SplitterCancelEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for splitter events.</summary>
  [Serializable]
  public class SplitterCancelEventArgs : CancelEventArgs
  {
    private readonly int mintMouseCursorX;
    private readonly int mintMouseCursorY;
    private int mintSplitX;
    private int mintSplitY;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitterCancelEventArgs" /> class.
    /// </summary>
    /// <param name="intMouseCursorX">The mouse cursor X.</param>
    /// <param name="intMouseCursorY">The mouse cursor Y.</param>
    /// <param name="intSplitX">The split X.</param>
    /// <param name="intSplitY">The split Y.</param>
    public SplitterCancelEventArgs(
      int intMouseCursorX,
      int intMouseCursorY,
      int intSplitX,
      int intSplitY)
      : base(false)
    {
      this.mintMouseCursorX = intMouseCursorX;
      this.mintMouseCursorY = intMouseCursorY;
      this.mintSplitX = intSplitX;
      this.mintSplitY = intSplitY;
    }

    /// <summary>
    /// Gets the X coordinate of the mouse pointer in client coordinates.
    /// </summary>
    /// <value>The mouse cursor X.</value>
    public int MouseCursorX => this.mintMouseCursorX;

    /// <summary>
    /// Gets the Y coordinate of the mouse pointer in client coordinates.
    /// </summary>
    /// <value>The mouse cursor Y.</value>
    public int MouseCursorY => this.mintMouseCursorY;

    /// <summary>
    /// Gets or sets the X coordinate of the upper left corner of the SplitContainer in client coordinates.
    /// </summary>
    /// <value>The split X.</value>
    public int SplitX
    {
      get => this.mintSplitX;
      set => this.mintSplitX = value;
    }

    /// <summary>
    /// Gets or sets the Y coordinate of the upper left corner of the SplitContainer in client coordinates.
    /// </summary>
    /// <value>The split Y.</value>
    public int SplitY
    {
      get => this.mintSplitY;
      set => this.mintSplitY = value;
    }
  }
}
