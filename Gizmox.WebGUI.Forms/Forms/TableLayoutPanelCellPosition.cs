// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a cell in a TableLayoutPanel.</summary>
  [TypeConverter(typeof (TableLayoutPanelCellPositionTypeConverter))]
  [Serializable]
  public struct TableLayoutPanelCellPosition
  {
    private int mintRow;
    private int mintColumn;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition" /> struct.
    /// </summary>
    /// <param name="intColumn">The column.</param>
    /// <param name="intRow">The row.</param>
    public TableLayoutPanelCellPosition(int intColumn, int intRow)
    {
      if (intRow < -1)
        throw new ArgumentOutOfRangeException("row", SR.GetString("InvalidArgument", (object) "row", (object) intRow.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (intColumn < -1)
        throw new ArgumentOutOfRangeException("column", SR.GetString("InvalidArgument", (object) "column", (object) intColumn.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      this.mintRow = intRow;
      this.mintColumn = intColumn;
    }

    /// <summary>
    /// Gets or sets the row number of the current TableLayoutPanelCellPosition.
    /// </summary>
    /// <value>The row.</value>
    public int Row
    {
      get => this.mintRow;
      set => this.mintRow = value;
    }

    /// <summary>
    /// Gets or sets the column number of the current TableLayoutPanelCellPosition.
    /// </summary>
    /// <value>The column.</value>
    public int Column
    {
      get => this.mintColumn;
      set => this.mintColumn = value;
    }

    /// <summary>
    /// Specifies whether this TableLayoutPanelCellPosition contains the same row and column as the specified TableLayoutPanelCellPosition.
    /// </summary>
    /// <param name="objOther">The other.</param>
    /// <returns></returns>
    public override bool Equals(object objOther) => objOther is TableLayoutPanelCellPosition panelCellPosition && panelCellPosition.mintRow == this.mintRow && panelCellPosition.mintColumn == this.mintColumn;

    /// <summary>Implements the operator ==.</summary>
    /// <param name="objPos1">The p1.</param>
    /// <param name="objPos2">The p2.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(
      TableLayoutPanelCellPosition objPos1,
      TableLayoutPanelCellPosition objPos2)
    {
      return objPos1.Row == objPos2.Row && objPos1.Column == objPos2.Column;
    }

    /// <summary>Implements the operator !=.</summary>
    /// <param name="objPos1">The p1.</param>
    /// <param name="objPos2">The p2.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(
      TableLayoutPanelCellPosition objPos1,
      TableLayoutPanelCellPosition objPos2)
    {
      return objPos1 != objPos2;
    }

    /// <summary>
    /// Returns the fully qualified type name of this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> containing a fully qualified type name.
    /// </returns>
    public override string ToString()
    {
      int num = this.Column;
      string str1 = num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      num = this.Row;
      string str2 = num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      return str1 + "," + str2;
    }

    /// <summary>Returns the hash code for this instance.</summary>
    /// <returns>
    /// A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    public override int GetHashCode() => CommonUtils.GetCombinedHashCodes(this.mintRow, this.mintColumn);
  }
}
