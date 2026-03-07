// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutCellPaintEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the CellPaint event.</summary>
  [Serializable]
  public class TableLayoutCellPaintEventArgs : PaintEventArgs
  {
    private Rectangle mobjBoundsRect;
    private int mintColumn;
    private int mintRow;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutCellPaintEventArgs" /> class.
    /// </summary>
    /// <param name="objGraphics">The g.</param>
    /// <param name="objClipRectangle">The clip rectangle.</param>
    /// <param name="objCellBounds">The cell bounds.</param>
    /// <param name="intColumn">The column.</param>
    /// <param name="intRow">The row.</param>
    public TableLayoutCellPaintEventArgs(
      Graphics objGraphics,
      Rectangle objClipRectangle,
      Rectangle objCellBounds,
      int intColumn,
      int intRow)
      : base(objGraphics, objClipRectangle)
    {
      this.mobjBoundsRect = objCellBounds;
      this.mintRow = intRow;
      this.mintColumn = intColumn;
    }

    /// <summary>Gets the size and location of the cell.</summary>
    /// <value>The cell bounds.</value>
    public Rectangle CellBounds => this.mobjBoundsRect;

    /// <summary>GGets the column of the cell.</summary>
    /// <value>The column.</value>
    public int Column => this.mintColumn;

    /// <summary>Gets the row of the cell.</summary>
    /// <value>The row.</value>
    public int Row => this.mintRow;
  }
}
