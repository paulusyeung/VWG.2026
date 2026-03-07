// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines values for specifying how the widths of columns are adjusted. </summary>
  [Serializable]
  public enum DataGridViewAutoSizeColumnsMode
  {
    /// <summary>The column widths do not automatically adjust. </summary>
    None = 1,
    /// <summary>The column widths adjust to fit the contents of the column header cells. </summary>
    ColumnHeader = 2,
    /// <summary>The column widths adjust to fit the contents of all cells in the columns, excluding header cells. </summary>
    AllCellsExceptHeader = 4,
    /// <summary>The column widths adjust to fit the contents of all cells in the columns, including header cells. </summary>
    AllCells = 6,
    /// <summary>The column widths adjust to fit the contents of all cells in the columns that are in rows currently displayed onscreen, excluding header cells. </summary>
    DisplayedCellsExceptHeader = 8,
    /// <summary>The column widths adjust to fit the contents of all cells in the columns that are in rows currently displayed onscreen, including header cells. </summary>
    DisplayedCells = 10, // 0x0000000A
    /// <summary>The column widths adjust so that the widths of all columns exactly fill the display area of the control, requiring horizontal scrolling only to keep column widths above the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.MinimumWidth"></see> property values. Relative column widths are determined by the relative <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values.</summary>
    Fill = 16, // 0x00000010
  }
}
