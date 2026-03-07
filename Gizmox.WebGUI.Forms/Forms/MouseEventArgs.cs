// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MouseEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides data for the MouseUp, MouseDown, and MouseMove events.
  /// </summary>
  [Serializable]
  public class MouseEventArgs : EventArgs
  {
    private readonly MouseButtons menmButton;
    private readonly int mintClicks;
    private readonly int mintDelta;
    private readonly int mintX;
    private readonly int mintY;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> class.
    /// </summary>
    /// <param name="enmButton">The button.</param>
    /// <param name="intClicks">The clicks.</param>
    /// <param name="intX">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="intDelta">The delta.</param>
    public MouseEventArgs(
      MouseButtons enmButton,
      int intClicks,
      int intX,
      int intY,
      int intDelta)
    {
      this.menmButton = enmButton;
      this.mintClicks = intClicks;
      this.mintX = intX;
      this.mintY = intY;
      this.mintDelta = intDelta;
    }

    /// <summary>Gets which mouse button was pressed.</summary>
    /// <value>The button.</value>
    public MouseButtons Button => this.menmButton;

    /// <summary>
    /// Gets the number of times the mouse button was pressed and released.
    /// </summary>
    /// <value>The clicks.</value>
    public int Clicks => this.mintClicks;

    /// <summary>
    /// Gets a signed count of the number of detents the mouse wheel has rotated. A detent is one notch of the mouse wheel.
    /// </summary>
    /// <value>The delta.</value>
    public int Delta => this.mintDelta;

    /// <summary>Gets the location of the mouse during the generating mouse event.</summary>
    /// <returns>A <see cref="T:System.Drawing.Point"></see> containing the x- and y- coordinate of the mouse, in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    public Point Location => new Point(this.X, this.Y);

    /// <summary>
    /// Gets the x-coordinate of the mouse during the generating mouse event.
    /// </summary>
    /// <value>The X.</value>
    public int X => this.mintX;

    /// <summary>
    /// Gets the y-coordinate of the mouse during the generating mouse event.
    /// </summary>
    /// <value>The Y.</value>
    public int Y => this.mintY;
  }
}
