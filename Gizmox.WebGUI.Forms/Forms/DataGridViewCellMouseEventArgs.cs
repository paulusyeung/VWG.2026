// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for mouse events raised by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> whenever the mouse is moved within a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewCellMouseEventArgs : MouseEventArgs
  {
    private int mintColumnIndex;
    private int mintRowIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> class.</summary>
    /// <param name="intLocalY">The y-coordinate of the mouse, in pixels.</param>
    /// <param name="intColumnIndex">The cell's zero-based column index.</param>
    /// <param name="e">The originating <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see>.</param>
    /// <param name="intRowIndex">The cell's zero-based row index.</param>
    /// <param name="intLocalX">The x-coordinate of the mouse, in pixels.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.-or-rowIndex is less than -1.</exception>
    public DataGridViewCellMouseEventArgs(
      int intColumnIndex,
      int intRowIndex,
      int intLocalX,
      int intLocalY,
      MouseEventArgs e)
      : base(e.Button, e.Clicks, intLocalX, intLocalY, e.Delta)
    {
      if (intColumnIndex < -1)
        throw new ArgumentOutOfRangeException("columnIndex");
      if (intRowIndex < -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      this.mintColumnIndex = intColumnIndex;
      this.mintRowIndex = intRowIndex;
    }

    /// <summary>Gets the zero-based column index of the cell.</summary>
    /// <returns>An integer specifying the column index.</returns>
    /// <filterpriority>1</filterpriority>
    public int ColumnIndex => this.mintColumnIndex;

    /// <summary>Gets the zero-based row index of the cell.</summary>
    /// <returns>An integer specifying the row index.</returns>
    /// <filterpriority>1</filterpriority>
    public int RowIndex => this.mintRowIndex;
  }
}
