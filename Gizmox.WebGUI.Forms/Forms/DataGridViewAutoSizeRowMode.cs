// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines values for specifying how the height of a row is adjusted. </summary>
  [Serializable]
  public enum DataGridViewAutoSizeRowMode
  {
    /// <summary>The row height adjusts to fit the contents of the row header. </summary>
    RowHeader = 1,
    /// <summary>The row height adjusts to fit the contents of all cells in the row, excluding the header cell. </summary>
    AllCellsExceptHeader = 2,
    /// <summary>The row height adjusts to fit the contents of all cells in the row, including the header cell. </summary>
    AllCells = 3,
  }
}
