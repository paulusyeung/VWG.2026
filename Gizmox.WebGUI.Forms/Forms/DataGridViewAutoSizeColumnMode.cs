// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines values for specifying how the width of a column is adjusted. </summary>
  [Serializable]
  public enum DataGridViewAutoSizeColumnMode
  {
    /// <summary>The sizing behavior of the column is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsMode"></see> property.</summary>
    NotSet = 0,
    /// <summary>The column width does not automatically adjust.</summary>
    None = 1,
    /// <summary>The column width adjusts to fit the contents of the column header cell. </summary>
    ColumnHeader = 2,
    /// <summary>The column width adjusts to fit the contents of all cells in the column, excluding the header cell. </summary>
    AllCellsExceptHeader = 4,
    /// <summary>The column width adjusts to fit the contents of all cells in the column, including the header cell. </summary>
    AllCells = 6,
    /// <summary>The column width adjusts to fit the contents of all cells in the column that are in rows currently displayed onscreen, excluding the header cell. </summary>
    DisplayedCellsExceptHeader = 8,
    /// <summary>The column width adjusts to fit the contents of all cells in the column that are in rows currently displayed onscreen, including the header cell. </summary>
    DisplayedCells = 10, // 0x0000000A
    /// <summary>The column width adjusts so that the widths of all columns exactly fills the display area of the control, requiring horizontal scrolling only to keep column widths above the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.MinimumWidth"></see> property values. Relative column widths are determined by the relative <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values.</summary>
    Fill = 16, // 0x00000010
  }
}
