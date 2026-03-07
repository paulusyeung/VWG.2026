// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowsRemovedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsRemoved"></see> event.</summary>
  [Serializable]
  public class DataGridViewRowsRemovedEventArgs : EventArgs
  {
    private int mintRowCount;
    private int mintRowIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsRemovedEventArgs"></see> class.</summary>
    /// <param name="intRowCount">The number of rows that were deleted.</param>
    /// <param name="intRowIndex">The zero-based index of the row that was deleted, or the first deleted row if multiple rows were deleted. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0.-or-rowCount is less than 1.</exception>
    public DataGridViewRowsRemovedEventArgs(int intRowIndex, int intRowCount)
    {
      if (intRowIndex < 0)
        throw new ArgumentOutOfRangeException();
      if (intRowCount < 1)
        throw new ArgumentOutOfRangeException();
      this.mintRowIndex = intRowIndex;
      this.mintRowCount = intRowCount;
    }

    /// <summary>Gets the number of rows that were deleted.</summary>
    /// <returns>The number of deleted rows.</returns>
    public int RowCount => this.mintRowCount;

    /// <summary>Gets the zero-based index of the row deleted, or the first deleted row if multiple rows were deleted.</summary>
    /// <returns>The zero-based index of the row that was deleted, or the first deleted row if multiple rows were deleted.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
