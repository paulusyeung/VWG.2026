// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewTextBoxEditingControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a text box control that can be hosted in a <see cref="T:System.Windows.Forms.DataGridViewTextBoxCell"></see>.
  /// </summary>
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ToolboxItem(false)]
  [Serializable]
  public class DataGridViewTextBoxEditingControl : TextBox, IDataGridViewEditingControl
  {
    private bool mblnRepositionEditingControlOnValueChange;
    private bool mblnEditingControlValueChanged;
    private int mintEditingControlRowIndex;
    private DataGridView mobjDataGridView;
    private static readonly DataGridViewContentAlignment menmAnyCenter = DataGridViewContentAlignment.BottomCenter | DataGridViewContentAlignment.MiddleCenter | DataGridViewContentAlignment.TopCenter;
    private static readonly DataGridViewContentAlignment menmAnyRight = DataGridViewContentAlignment.BottomRight | DataGridViewContentAlignment.MiddleRight | DataGridViewContentAlignment.TopRight;
    private static readonly DataGridViewContentAlignment menmAnyTop = DataGridViewContentAlignment.TopCenter | DataGridViewContentAlignment.TopLeft | DataGridViewContentAlignment.TopRight;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewTextBoxEditingControl"></see> class.</summary>
    public DataGridViewTextBoxEditingControl() => this.TabStop = false;

    /// <summary>
    /// Raises the <see cref="E:TextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
      this.NotifyDataGridViewOfValueChange();
    }

    /// <summary>Changes the control's user interface (UI) to be consistent with the specified cell style.</summary>
    /// <param name="objDataGridViewCellStyle">The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to use as the model for the UI.</param>
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
      if (objDataGridViewCellStyle.WrapMode == DataGridViewTriState.True)
        this.WordWrap = true;
      this.TextAlign = DataGridViewTextBoxEditingControl.TranslateAlignment(objDataGridViewCellStyle.Alignment);
      this.RepositionEditingControlOnValueChange = objDataGridViewCellStyle.WrapMode == DataGridViewTriState.True && (objDataGridViewCellStyle.Alignment & DataGridViewTextBoxEditingControl.menmAnyTop) == DataGridViewContentAlignment.NotSet;
    }

    /// <summary>Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.</summary>
    /// <returns>true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
    /// <param name="enmKeyData">A <see cref="T:System.Windows.Forms.Keys"></see> that represents the key that was pressed.</param>
    /// <param name="blnDataGridViewWantsInputKey">true when the <see cref="T:System.Windows.Forms.DataGridView"></see> wants to process the keyData; otherwise, false.</param>
    public virtual bool EditingControlWantsInputKey(
      Keys enmKeyData,
      bool blnDataGridViewWantsInputKey)
    {
      switch (enmKeyData & Keys.KeyCode)
      {
        case Keys.Enter:
          if ((enmKeyData & (Keys.Alt | Keys.Control | Keys.Shift)) == Keys.Shift && this.Multiline && this.AcceptsReturn)
            return true;
          break;
        case Keys.PageUp:
        case Keys.Next:
          if (this.EditingControlValueChanged)
            return true;
          break;
        case Keys.End:
        case Keys.Home:
          if (this.SelectionLength != this.Text.Length)
            return true;
          break;
        case Keys.Left:
          if (this.RightToLeft == RightToLeft.No && (this.SelectionLength != 0 || this.SelectionStart != 0) || this.RightToLeft == RightToLeft.Yes && (this.SelectionLength != 0 || this.SelectionStart != this.Text.Length))
            return true;
          break;
        case Keys.Up:
          if (this.Text.IndexOf("\r\n") >= 0 && this.SelectionStart + this.SelectionLength >= this.Text.IndexOf("\r\n"))
            return true;
          break;
        case Keys.Right:
          if (this.RightToLeft == RightToLeft.No && (this.SelectionLength != 0 || this.SelectionStart != this.Text.Length) || this.RightToLeft == RightToLeft.Yes && (this.SelectionLength != 0 || this.SelectionStart != 0))
            return true;
          break;
        case Keys.Down:
          if (this.Text.IndexOf("\r\n", this.SelectionStart + this.SelectionLength) != -1)
            return true;
          break;
        case Keys.Delete:
          if (this.SelectionLength > 0 || this.SelectionStart < this.Text.Length)
            return true;
          break;
      }
      return !blnDataGridViewWantsInputKey;
    }

    /// <summary>Retrieves the formatted value of the cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
    /// <param name="enmContext">One of the <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
    public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext) => this.EditingControlDataGridView != null && this.EditingControlDataGridView.CurrentCell != null ? this.EditingControlDataGridView.CurrentCell.EditingProposedValue : (object) null;

    /// <summary>Notifies the data grid view of value change.</summary>
    private void NotifyDataGridViewOfValueChange()
    {
      this.EditingControlValueChanged = true;
      this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
    }

    /// <summary>Prepares the currently selected cell for editing.</summary>
    /// <param name="blnSelectAll">true to select the cell contents; otherwise, false.</param>
    public virtual void PrepareEditingControlForEdit(bool blnSelectAll)
    {
      if (blnSelectAll)
        this.SelectAll();
      else
        this.SelectionStart = this.Text.Length;
    }

    /// <summary>Translates the alignment.</summary>
    /// <param name="enmAlign">The align.</param>
    /// <returns></returns>
    private static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment enmAlign)
    {
      if ((enmAlign & DataGridViewTextBoxEditingControl.menmAnyRight) != DataGridViewContentAlignment.NotSet)
        return HorizontalAlignment.Right;
      return (enmAlign & DataGridViewTextBoxEditingControl.menmAnyCenter) != DataGridViewContentAlignment.NotSet ? HorizontalAlignment.Center : HorizontalAlignment.Left;
    }

    /// <summary>Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the text box control.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the <see cref="T:System.Windows.Forms.DataGridViewTextBoxCell"></see> that contains this control; otherwise, null if there is no associated <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
    public virtual DataGridView EditingControlDataGridView
    {
      get => this.mobjDataGridView;
      set => this.mobjDataGridView = value;
    }

    /// <summary>Gets or sets the formatted representation of the current value of the text box control.</summary>
    /// <returns>An object representing the current value of this control.</returns>
    public virtual object EditingControlFormattedValue
    {
      get => this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
      set => this.Text = (string) value;
    }

    /// <summary>Gets or sets the index of the owning cell's parent row.</summary>
    /// <returns>The index of the row that contains the owning cell; -1 if there is no owning row.</returns>
    public virtual int EditingControlRowIndex
    {
      get => this.mintEditingControlRowIndex;
      set => this.mintEditingControlRowIndex = value;
    }

    /// <summary>Gets or sets a value indicating whether the current value of the text box control has changed.</summary>
    /// <returns>true if the value of the control has changed; otherwise, false.</returns>
    public virtual bool EditingControlValueChanged
    {
      get => this.mblnEditingControlValueChanged;
      set => this.mblnEditingControlValueChanged = value;
    }

    /// <summary>Gets the cursor used when the mouse pointer is over the <see cref="P:System.Windows.Forms.DataGridView.EditingPanel"></see> but not over the editing control.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the mouse pointer used for the editing panel. </returns>
    public virtual Cursor EditingPanelCursor => Cursors.Default;

    /// <summary>Gets a value indicating whether the cell contents need to be repositioned whenever the value changes.</summary>
    /// <returns>true if the cell's <see cref="P:System.Windows.Forms.DataGridViewCellStyle.WrapMode"></see> is set to true and the alignment property is not set to one of the <see cref="T:System.Windows.Forms.DataGridViewContentAlignment"></see> values that aligns the content to the top; otherwise, false.</returns>
    public virtual bool RepositionEditingControlOnValueChange
    {
      get => this.mblnRepositionEditingControlOnValueChange;
      private set => this.mblnRepositionEditingControlOnValueChange = value;
    }
  }
}
