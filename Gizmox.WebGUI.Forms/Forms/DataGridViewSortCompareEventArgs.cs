// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewSortCompareEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SortCompare"></see> event.</summary>
  [Serializable]
  public class DataGridViewSortCompareEventArgs : HandledEventArgs
  {
    private object mobjCellValue1;
    private object mobjCellValue2;
    private DataGridViewColumn mobjDataGridViewColumn;
    private int mintRowIndex1;
    private int mintRowIndex2;
    private int mintSortResult;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSortCompareEventArgs"></see> class.</summary>
    /// <param name="objCellValue2">The value of the second cell to compare.</param>
    /// <param name="objDataGridViewColumn">The column to sort.</param>
    /// <param name="intRowIndex2">The index of the row containing the second cell.</param>
    /// <param name="objCellValue1">The value of the first cell to compare.</param>
    /// <param name="intRowIndex1">The index of the row containing the first cell.</param>
    public DataGridViewSortCompareEventArgs(
      DataGridViewColumn objDataGridViewColumn,
      object objCellValue1,
      object objCellValue2,
      int intRowIndex1,
      int intRowIndex2)
    {
      this.mobjDataGridViewColumn = objDataGridViewColumn;
      this.mobjCellValue1 = objCellValue1;
      this.mobjCellValue2 = objCellValue2;
      this.mintRowIndex1 = intRowIndex1;
      this.mintRowIndex2 = intRowIndex2;
    }

    /// <summary>Gets the value of the first cell to compare.</summary>
    /// <returns>The value of the first cell.</returns>
    public object CellValue1 => this.mobjCellValue1;

    /// <summary>Gets the value of the second cell to compare.</summary>
    /// <returns>The value of the second cell.</returns>
    public object CellValue2 => this.mobjCellValue2;

    /// <summary>Gets the column being sorted. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to sort.</returns>
    public DataGridViewColumn Column => this.mobjDataGridViewColumn;

    /// <summary>Gets the index of the row containing the first cell to compare.</summary>
    /// <returns>The index of the row containing the second cell.</returns>
    public int RowIndex1 => this.mintRowIndex1;

    /// <summary>Gets the index of the row containing the second cell to compare.</summary>
    /// <returns>The index of the row containing the second cell.</returns>
    public int RowIndex2 => this.mintRowIndex2;

    /// <summary>Gets or sets a value indicating the order in which the compared cells will be sorted.</summary>
    /// <returns>Less than zero if the first cell will be sorted before the second cell; zero if the first cell and second cell have equivalent values; greater than zero if the second cell will be sorted before the first cell.</returns>
    public int SortResult
    {
      get => this.mintSortResult;
      set => this.mintSortResult = value;
    }
  }
}
