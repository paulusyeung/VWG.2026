// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueNeeded"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValuePushed"></see> events of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewCellValueEventArgs : EventArgs
  {
    private int mintColumnIndex;
    private int mintRowIndex;
    private object mobjValue;

    internal DataGridViewCellValueEventArgs() => this.mintColumnIndex = this.mintRowIndex = -1;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs"></see> class. </summary>
    /// <param name="intColumnIndex">The index of the column containing the cell that the event occurs for.</param>
    /// <param name="intRowIndex">The index of the row containing the cell that the event occurs for.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0.-or-rowIndex is less than 0.</exception>
    public DataGridViewCellValueEventArgs(int intColumnIndex, int intRowIndex)
    {
      if (intColumnIndex < 0)
        throw new ArgumentOutOfRangeException("columnIndex");
      this.mintRowIndex = intRowIndex >= 0 ? intRowIndex : throw new ArgumentOutOfRangeException("rowIndex");
      this.mintColumnIndex = intColumnIndex;
    }

    internal void SetProperties(int intColumnIndex, int intRowIndex, object objValue)
    {
      this.mintColumnIndex = intColumnIndex;
      this.mintRowIndex = intRowIndex;
      this.mobjValue = objValue;
    }

    /// <summary>Gets a value indicating the column index of the cell that the event occurs for.</summary>
    /// <returns>The index of the column containing the cell that the event occurs for.</returns>
    /// <filterpriority>1</filterpriority>
    public int ColumnIndex => this.mintColumnIndex;

    /// <summary>Gets a value indicating the row index of the cell that the event occurs for.</summary>
    /// <returns>The index of the row containing the cell that the event occurs for.</returns>
    /// <filterpriority>1</filterpriority>
    public int RowIndex => this.mintRowIndex;

    /// <summary>Gets or sets the value of the cell that the event occurs for.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the cell's value.</returns>
    /// <filterpriority>1</filterpriority>
    public object Value
    {
      get => this.mobjValue;
      set => this.mobjValue = value;
    }
  }
}
