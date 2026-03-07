// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellParsing"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewCellParsingEventArgs : ConvertEventArgs
  {
    private int mintColumnIndex;
    private DataGridViewCellStyle mobjInheritedCellStyle;
    private bool mblnParsingApplied;
    private int mintRowIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs"></see> class. </summary>
    /// <param name="objInheritedCellStyle">The style applied to the cell that was changed.</param>
    /// <param name="intColumnIndex">The column index of the cell that was changed.</param>
    /// <param name="intRowIndex">The row index of the cell that was changed.</param>
    /// <param name="objDesiredType">The type of the new value.</param>
    /// <param name="objValue">The new value.</param>
    public DataGridViewCellParsingEventArgs(
      int intRowIndex,
      int intColumnIndex,
      object objValue,
      Type objDesiredType,
      DataGridViewCellStyle objInheritedCellStyle)
      : base(objValue, objDesiredType)
    {
      this.mintRowIndex = intRowIndex;
      this.mintColumnIndex = intColumnIndex;
      this.mobjInheritedCellStyle = objInheritedCellStyle;
    }

    /// <summary>Gets the column index of the cell data that requires parsing.</summary>
    /// <returns>The column index of the cell that was changed.</returns>
    /// <filterpriority>1</filterpriority>
    public int ColumnIndex => this.mintColumnIndex;

    /// <summary>Gets or sets the style applied to the edited cell.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the current style of the cell being edited. The default value is the value of the cell <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.InheritedStyle"></see> property.</returns>
    public DataGridViewCellStyle InheritedCellStyle
    {
      get => this.mobjInheritedCellStyle;
      set => this.mobjInheritedCellStyle = value;
    }

    /// <summary>Gets or sets a value indicating whether a cell's value has been successfully parsed.</summary>
    /// <returns>true if the cell's value has been successfully parsed; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool ParsingApplied
    {
      get => this.mblnParsingApplied;
      set => this.mblnParsingApplied = value;
    }

    /// <summary>Gets the row index of the cell that requires parsing.</summary>
    /// <returns>The row index of the cell that was changed.</returns>
    /// <filterpriority>1</filterpriority>
    public int RowIndex => this.mintRowIndex;
  }
}
