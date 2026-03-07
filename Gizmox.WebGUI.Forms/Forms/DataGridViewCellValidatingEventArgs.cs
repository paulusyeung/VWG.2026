// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  [Serializable]
  public class DataGridViewCellValidatingEventArgs : CancelEventArgs
  {
    private int mintColumnIndex;
    private object mobjFormattedValue;
    private int mintRowIndex;

    internal DataGridViewCellValidatingEventArgs(
      int intColumnIndex,
      int intRowIndex,
      object objFormattedValue)
    {
      this.mintRowIndex = intRowIndex;
      this.mintColumnIndex = intColumnIndex;
      this.mobjFormattedValue = objFormattedValue;
    }

    /// <summary>Gets the column index of the cell that needs to be validated.</summary>
    /// <returns>A zero-based integer that specifies the column index of the cell that needs to be validated.</returns>
    public int ColumnIndex => this.mintColumnIndex;

    /// <summary>Gets the formatted contents of the cell that needs to be validated.</summary>
    /// <returns>A reference to the formatted value.</returns>
    public object FormattedValue => this.mobjFormattedValue;

    /// <summary>Gets the row index of the cell that needs to be validated.</summary>
    /// <returns>A zero-based integer that specifies the row index of the cell that needs to be validated.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
