// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines values for specifying how the heights of rows are adjusted. </summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public enum DataGridViewAutoSizeRowsMode
  {
    /// <summary>The row heights do not automatically adjust.</summary>
    /// <filterpriority>1</filterpriority>
    None = 0,
    /// <summary>The row heights adjust to fit the contents of the row header. </summary>
    AllHeaders = 5,
    /// <summary>The row heights adjust to fit the contents of all cells in the rows, excluding header cells. </summary>
    AllCellsExceptHeaders = 6,
    /// <summary>The row heights adjust to fit the contents of all cells in the rows, including header cells. </summary>
    AllCells = 7,
    /// <summary>The row heights adjust to fit the contents of the row headers currently displayed onscreen.</summary>
    DisplayedHeaders = 9,
    /// <summary>The row heights adjust to fit the contents of all cells in rows currently displayed onscreen, excluding header cells. </summary>
    DisplayedCellsExceptHeaders = 10, // 0x0000000A
    /// <summary>The row heights adjust to fit the contents of all cells in rows currently displayed onscreen, including header cells. </summary>
    DisplayedCells = 11, // 0x0000000B
  }
}
