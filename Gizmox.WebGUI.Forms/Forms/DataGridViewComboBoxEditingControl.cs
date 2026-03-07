// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewComboBoxEditingControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the hosted combo box control in a <see cref="T:System.Windows.Forms.DataGridViewComboBoxCell"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ComVisible(true)]
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewComboBoxEditingControl : ComboBox, IDataGridViewEditingControl
  {
    private bool mblnEditingControlValueChanged;
    private int mintEditingControlRowIndex;
    private DataGridView mobjDataGridView;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewComboBoxEditingControl"></see> class.</summary>
    public DataGridViewComboBoxEditingControl() => this.TabStop = false;

    protected override void OnSelectedIndexChanged(EventArgs e)
    {
      base.OnSelectedIndexChanged(e);
      if (this.SelectedIndex == -1)
        return;
      this.NotifyDataGridViewOfValueChange();
    }

    /// <summary>Changes the control's user interface (UI) to be consistent with the specified cell style.</summary>
    /// <param name="objDataGridViewCellStyle">The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to use as a pattern for the UI.</param>
    public virtual void ApplyCellStyleToEditingControl(
      DataGridViewCellStyle objDataGridViewCellStyle)
    {
      this.Font = objDataGridViewCellStyle.Font;
      if (objDataGridViewCellStyle.BackColor.A < byte.MaxValue)
      {
        Color color = Color.FromArgb((int) byte.MaxValue, objDataGridViewCellStyle.BackColor);
        this.BackColor = color;
        if (this.EditingControlDataGridView.EditingPanel != null)
          this.EditingControlDataGridView.EditingPanel.BackColor = color;
      }
      else
        this.BackColor = objDataGridViewCellStyle.BackColor;
      this.ForeColor = objDataGridViewCellStyle.ForeColor;
    }

    /// <summary>Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.</summary>
    /// <returns>true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
    /// <param name="enmKeyData">A bitwise combination of <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key that was pressed.</param>
    /// <param name="blnDataGridViewWantsInputKey">true to indicate that the <see cref="T:System.Windows.Forms.DataGridView"></see> control can process the key; otherwise, false.</param>
    public virtual bool EditingControlWantsInputKey(
      Keys enmKeyData,
      bool blnDataGridViewWantsInputKey)
    {
      return true;
    }

    /// <summary>Retrieves the formatted value of the cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
    public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext) => this.EditingControlDataGridView != null && this.EditingControlDataGridView.CurrentCell != null ? this.EditingControlDataGridView.CurrentCell.EditingProposedValue : (object) null;

    private void NotifyDataGridViewOfValueChange()
    {
      this.EditingControlValueChanged = true;
      this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
    }

    /// <summary>Prepares the currently selected cell for editing.</summary>
    /// <param name="blnSelectAll">true to select all of the cell's content; otherwise, false.</param>
    public virtual void PrepareEditingControlForEdit(bool blnSelectAll)
    {
      if (!blnSelectAll)
        return;
      this.SelectAll();
    }

    /// <summary>Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the combo box control.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the <see cref="T:System.Windows.Forms.DataGridViewComboBoxCell"></see> that contains this control; otherwise, null if there is no associated <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
    public virtual DataGridView EditingControlDataGridView
    {
      get => this.mobjDataGridView;
      set => this.mobjDataGridView = value;
    }

    /// <summary>Gets or sets the formatted representation of the current value of the control.</summary>
    /// <returns>An object representing the current value of this control.</returns>
    public virtual object EditingControlFormattedValue
    {
      get => this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
      set
      {
        if (!(value is string strA))
          return;
        this.Text = strA;
        if (string.Compare(strA, this.Text, true, CultureInfo.CurrentCulture) == 0)
          return;
        this.SelectedIndex = -1;
      }
    }

    /// <summary>Gets or sets the index of the owning cell's parent row.</summary>
    /// <returns>The index of the row that contains the owning cell; -1 if there is no owning row.</returns>
    public virtual int EditingControlRowIndex
    {
      get => this.mintEditingControlRowIndex;
      set => this.mintEditingControlRowIndex = value;
    }

    /// <summary>Gets or sets a value indicating whether the current value of the control has changed.</summary>
    /// <returns>true if the value of the control has changed; otherwise, false.</returns>
    public virtual bool EditingControlValueChanged
    {
      get => this.mblnEditingControlValueChanged;
      set => this.mblnEditingControlValueChanged = value;
    }

    /// <summary>Gets the cursor used during editing.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the cursor image used by the mouse pointer during editing.</returns>
    public virtual Cursor EditingPanelCursor => Cursors.Default;

    /// <summary>Gets a value indicating whether the cell contents need to be repositioned whenever the value changes.</summary>
    /// <returns>false in all cases.</returns>
    public virtual bool RepositionEditingControlOnValueChange => false;
  }
}
