// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IDataGridViewEditingCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Defines common functionality for a cell that allows the manipulation of its value.
  /// </summary>
  public interface IDataGridViewEditingCell
  {
    /// <summary>Retrieves the formatted value of the cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which the data is needed.</param>
    object GetEditingCellFormattedValue(DataGridViewDataErrorContexts enmContext);

    /// <summary>Prepares the currently selected cell for editing.</summary>
    /// <param name="selectAll">true to select the cell contents; otherwise, false.</param>
    void PrepareEditingCellForEdit(bool blnSelectAll);

    /// <summary>Gets or sets the formatted value of the cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that contains the cell's value.</returns>
    object EditingCellFormattedValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the value of the cell has changed.
    /// </summary>
    /// <returns>true if the value of the cell has changed; otherwise, false.</returns>
    bool EditingCellValueChanged { get; set; }
  }
}
