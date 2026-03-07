// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellStyleScopes
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> entity that owns the cell style that was changed.</summary>
  [Flags]
  [Serializable]
  public enum DataGridViewCellStyleScopes
  {
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AlternatingRowsDefaultCellStyle"></see> property changed.</summary>
    AlternatingRows = 128, // 0x00000080
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property changed.</summary>
    Cell = 1,
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DefaultCellStyle"></see> property changed.</summary>
    Column = 2,
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersDefaultCellStyle"></see> property changed.</summary>
    ColumnHeaders = 16, // 0x00000010
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DefaultCellStyle"></see> property changed.</summary>
    DataGridView = 8,
    /// <summary>The owning entity is unspecified.</summary>
    None = 0,
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.DefaultCellStyle"></see> property changed.</summary>
    Row = 4,
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersDefaultCellStyle"></see> property changed.</summary>
    RowHeaders = 32, // 0x00000020
    /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowsDefaultCellStyle"></see> property changed.</summary>
    Rows = 64, // 0x00000040
  }
}
