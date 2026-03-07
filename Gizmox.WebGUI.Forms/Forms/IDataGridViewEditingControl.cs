// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IDataGridViewEditingControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Defines common functionality for controls that are hosted within cells of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
  /// </summary>
  public interface IDataGridViewEditingControl
  {
    /// <summary>
    /// Changes the control's user interface (UI) to be consistent with the specified cell style.
    /// </summary>
    /// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to use as the model for the UI.</param>
    void ApplyCellStyleToEditingControl(DataGridViewCellStyle objDataGridViewCellStyle);

    /// <summary>
    /// Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> should process.
    /// </summary>
    /// <returns>true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
    /// <param name="enmKeyData">A <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> that represents the key that was pressed.</param>
    /// <param name="blnDataGridViewWantsInputKey">true when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> wants to process the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> in keyData; otherwise, false.</param>
    bool EditingControlWantsInputKey(Keys enmKeyData, bool blnDataGridViewWantsInputKey);

    /// <summary>Retrieves the formatted value of the cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which the data is needed.</param>
    object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext);

    /// <summary>Prepares the currently selected cell for editing.</summary>
    /// <param name="blnSelectAll">true to select all of the cell's content; otherwise, false.</param>
    void PrepareEditingControlForEdit(bool blnSelectAll);

    /// <summary>
    /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that contains the cell.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is being edited; null if there is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    DataGridView EditingControlDataGridView { get; set; }

    /// <summary>
    /// Gets or sets the formatted value of the cell being modified by the editor.
    /// </summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the formatted value of the cell.</returns>
    object EditingControlFormattedValue { get; set; }

    /// <summary>
    /// Gets or sets the index of the hosting cell's parent row.
    /// </summary>
    /// <returns>The index of the row that contains the cell, or –1 if there is no parent row.</returns>
    int EditingControlRowIndex { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the value of the editing control differs from the value of the hosting cell.
    /// </summary>
    /// <returns>true if the value of the control differs from the cell value; otherwise, false.</returns>
    bool EditingControlValueChanged { get; set; }

    /// <summary>
    /// Gets the cursor used when the mouse pointer is over the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingPanel"></see> but not over the editing control.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the mouse pointer used for the editing panel. </returns>
    Cursor EditingPanelCursor { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the cell contents need to be repositioned whenever the value changes.
    /// </summary>
    /// <returns>true if the contents need to be repositioned; otherwise, false.</returns>
    bool RepositionEditingControlOnValueChange { get; }
  }
}
