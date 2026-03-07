// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewSelectionMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Describes how cells of a DataGridView control can be selected.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public enum DataGridViewSelectionMode
  {
    /// <summary>CellSelect</summary>
    CellSelect = 1,
    /// <summary>FullRowSelect</summary>
    FullRowSelect = 2,
    /// <summary>FullColumnSelect</summary>
    FullColumnSelect = 4,
    /// <summary>RowHeaderSelect</summary>
    RowHeaderSelect = 8,
    /// <summary>ColumnHeaderSelect</summary>
    ColumnHeaderSelect = 16, // 0x00000010
  }
}
