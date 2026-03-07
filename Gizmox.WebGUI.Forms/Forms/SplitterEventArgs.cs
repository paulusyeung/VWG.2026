// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SplitterEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for SplitterMoving and the SplitterMoved events.
  /// </summary>
  [ComVisible(true)]
  [Serializable]
  public class SplitterEventArgs : EventArgs
  {
    private int mintSplitX;
    private int mintSplitY;
    private readonly int mintX;
    private readonly int mintY;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> class.
    /// </summary>
    /// <param name="intX">The x.</param>
    /// <param name="intY">The y.</param>
    /// <param name="intSplitX">The split X.</param>
    /// <param name="intSplitY">The split Y.</param>
    public SplitterEventArgs(int intX, int intY, int intSplitX, int intSplitY)
    {
      this.mintX = intX;
      this.mintY = intY;
      this.mintSplitX = intSplitX;
      this.mintSplitY = intSplitY;
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the upper-left corner of the Splitter (in client coordinates).
    /// </summary>
    /// <value>The split X.</value>
    public int SplitX
    {
      get => this.mintSplitX;
      set => this.mintSplitX = value;
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the upper-left corner of the Splitter (in client coordinates).
    /// </summary>
    /// <value>The split Y.</value>
    public int SplitY
    {
      get => this.mintSplitY;
      set => this.mintSplitY = value;
    }

    /// <summary>
    /// Gets the x-coordinate of the mouse pointer (in client coordinates).
    /// </summary>
    /// <value>The X.</value>
    public int X => this.mintX;

    /// <summary>
    /// Gets the y-coordinate of the mouse pointer (in client coordinates).
    /// </summary>
    /// <value>The Y.</value>
    public int Y => this.mintY;
  }
}
