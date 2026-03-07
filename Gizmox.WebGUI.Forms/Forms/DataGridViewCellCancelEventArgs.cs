// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  public class DataGridViewCellCancelEventArgs : CancelEventArgs
  {
    private int mintColumnIndex;
    private int mintRowIndex;

    internal DataGridViewCellCancelEventArgs(DataGridViewCell objDataGridViewCell)
      : this(objDataGridViewCell.ColumnIndex, objDataGridViewCell.RowIndex)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs"></see> class. </summary>
    /// <param name="intColumnIndex">The index of the column containing the cell that the event occurs for.</param>
    /// <param name="intRowIndex">The index of the row containing the cell that the event occurs for.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.-or-rowIndex is less than -1.</exception>
    public DataGridViewCellCancelEventArgs(int intColumnIndex, int intRowIndex)
    {
      if (intColumnIndex < -1)
        throw new ArgumentOutOfRangeException("columnIndex");
      if (intRowIndex < -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      this.mintColumnIndex = intColumnIndex;
      this.mintRowIndex = intRowIndex;
    }

    /// <summary>Gets the column index of the cell that the event occurs for.</summary>
    /// <returns>The column index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that the event occurs for.</returns>
    /// <filterpriority>1</filterpriority>
    public int ColumnIndex => this.mintColumnIndex;

    /// <summary>Gets the row index of the cell that the event occurs for.</summary>
    /// <returns>The row index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that the event occurs for.</returns>
    /// <filterpriority>1</filterpriority>
    public int RowIndex => this.mintRowIndex;
  }
}
