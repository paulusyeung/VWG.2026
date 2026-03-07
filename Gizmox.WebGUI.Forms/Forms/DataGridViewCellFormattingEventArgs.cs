// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewCellFormattingEventArgs : ConvertEventArgs
  {
    private DataGridViewCellStyle mobjCellStyle;
    private int mintColumnIndex;
    private bool mblnFormattingApplied;
    private int mintRowIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs"></see> class.</summary>
    /// <param name="objCellStyle">The style of the cell that caused the event.</param>
    /// <param name="intColumnIndex">The column index of the cell that caused the event.</param>
    /// <param name="intRowIndex">The row index of the cell that caused the event.</param>
    /// <param name="objDesiredType">The type to convert value to. </param>
    /// <param name="objValue">The cell's contents.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1-or-rowIndex is less than -1.</exception>
    public DataGridViewCellFormattingEventArgs(
      int intColumnIndex,
      int intRowIndex,
      object objValue,
      Type objDesiredType,
      DataGridViewCellStyle objCellStyle)
      : base(objValue, objDesiredType)
    {
      if (intColumnIndex < -1)
        throw new ArgumentOutOfRangeException("columnIndex");
      if (intRowIndex < -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      this.mintColumnIndex = intColumnIndex;
      this.mintRowIndex = intRowIndex;
      this.mobjCellStyle = objCellStyle;
    }

    /// <summary>Gets or sets the style of the cell that is being formatted.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the display style of the cell being formatted. The default is the value of the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.InheritedStyle"></see> property. </returns>
    /// <filterpriority>1</filterpriority>
    public DataGridViewCellStyle CellStyle
    {
      get => this.mobjCellStyle;
      set => this.mobjCellStyle = value;
    }

    /// <summary>Gets the column index of the cell that is being formatted.</summary>
    /// <returns>The column index of the cell that is being formatted.</returns>
    /// <filterpriority>1</filterpriority>
    public int ColumnIndex => this.mintColumnIndex;

    /// <summary>Gets or sets a value indicating whether the cell value has been successfully formatted.</summary>
    /// <returns>true if the formatting for the cell value has been handled; otherwise, false. The default value is false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool FormattingApplied
    {
      get => this.mblnFormattingApplied;
      set => this.mblnFormattingApplied = value;
    }

    /// <summary>Gets the row index of the cell that is being formatted.</summary>
    /// <returns>The row index of the cell that is being formatted.</returns>
    /// <filterpriority>1</filterpriority>
    public int RowIndex => this.mintRowIndex;
  }
}
