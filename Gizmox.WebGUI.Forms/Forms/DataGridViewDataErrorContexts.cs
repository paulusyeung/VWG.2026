// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the state of a data-bound <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control when a data error occurred.</summary>
  [Flags]
  [Serializable]
  public enum DataGridViewDataErrorContexts
  {
    /// <summary>A data error occurred when copying content to the Clipboard. This value indicates that the cell value could not be converted to a string.</summary>
    ClipboardContent = 16384, // 0x00004000
    /// <summary>A data error occurred when committing changes to the data store. This value indicates that data entered in a cell could not be committed to the underlying data store.</summary>
    Commit = 512, // 0x00000200
    /// <summary>A data error occurred when the selection cursor moved to another cell. This value indicates that a user selected a cell when the previously selected cell had an error condition.</summary>
    CurrentCellChange = 4096, // 0x00001000
    /// <summary>A data error occurred when displaying a cell that was populated by a data source. This value indicates that the value from the data source cannot be displayed by the cell, or a mapping that translates the value from the data source to the cell is missing.</summary>
    Display = 2,
    /// <summary>A data error occurred when trying to format data that is either being sent to a data store, or being loaded from a data store. This value indicates that a change to a cell failed to format correctly. Either the new cell value needs to be corrected or the cell's formatting needs to change.</summary>
    Formatting = 1,
    /// <summary>A data error occurred when restoring a cell to its previous value. This value indicates that a cell tried to cancel an edit and the rollback to the initial value failed. This can occur if the cell formatting changed so that it is incompatible with the initial value.</summary>
    InitialValueRestoration = 1024, // 0x00000400
    /// <summary>A data error occurred when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> lost focus. This value indicates that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> could not commit user changes after losing focus.</summary>
    LeaveControl = 2048, // 0x00000800
    /// <summary>A data error occurred when parsing new data. This value indicates that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> could not parse new data that was entered by the user or loaded from the underlying data store.</summary>
    Parsing = 256, // 0x00000100
    /// <summary>A data error occurred when calculating the preferred size of a cell. This value indicates that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> failed to calculate the preferred width or height of a cell when programmatically resizing a column or row. This can occur if the cell failed to format its value.</summary>
    PreferredSize = 4,
    /// <summary>A data error occurred when deleting a row. This value indicates that the underlying data store threw an exception when a data-bound <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> deleted a row.</summary>
    RowDeletion = 8,
    /// <summary>A data error occurred when scrolling a new region into view. This value indicates that a cell with data errors scrolled into view programmatically or with the scroll bar.</summary>
    Scroll = 8192, // 0x00002000
  }
}
