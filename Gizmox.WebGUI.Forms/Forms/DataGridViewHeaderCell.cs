// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewHeaderCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Contains functionality common to row header cells and column header cells.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewHeaderCell : DataGridViewCell
  {
    protected static Type cellType;
    protected static Type defaultFormattedValueType = typeof (string);
    protected static Type defaultValueType = typeof (object);
    protected static readonly int PropButtonState;
    protected static readonly int PropFlipXPThemesBitmap;
    protected static readonly int PropValueType;
    protected static Rectangle rectThemeMargins;
    protected const byte DATAGRIDVIEWHEADERCELL_themeMargin = 100;
    protected const string HeaderTypeName = "7";
    private object mobjLocalValue;

    static DataGridViewHeaderCell()
    {
      DataGridViewHeaderCell.cellType = typeof (DataGridViewHeaderCell);
      DataGridViewHeaderCell.rectThemeMargins = new Rectangle(-1, -1, 0, 0);
    }

    /// <summary>Renders the wrap mode attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
    protected override void RenderWrapModeAttribute(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objInheritedCellStyle)
    {
      if (objInheritedCellStyle.WrapMode == DataGridViewTriState.True)
        return;
      objWriter.WriteAttributeString("WC", "0");
    }

    /// <summary>Renders the read only attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderReadOnlyAttribute(IAttributeWriter objWriter)
    {
    }

    /// <summary>Renders the back-color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
    protected override void RenderBackColorAttribute(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objInheritedCellStyle)
    {
      if (!(objInheritedCellStyle.BackColor != this.DataGridView.DefaultColumnHeadersDefaultCellStyleInternal.BackColor))
        return;
      objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(objInheritedCellStyle.BackColor));
    }

    /// <summary>Renders the fore color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
    protected override void RenderForeColorAttribute(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objInheritedCellStyle)
    {
      if (!(objInheritedCellStyle.ForeColor != this.DataGridView.DefaultColumnHeadersDefaultCellStyleInternal.ForeColor))
        return;
      objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(objInheritedCellStyle.ForeColor));
    }

    /// <summary>Renders the cell text/value.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objFormatedValue">The formated value.</param>
    protected override void RenderCellValue(
      IContext objContext,
      IAttributeWriter objWriter,
      object objFormatedValue)
    {
      base.RenderCellValue(objContext, objWriter, objFormatedValue);
      if (objFormatedValue == null)
        return;
      objWriter.WriteAttributeText("VLB", objFormatedValue.ToString());
    }

    /// <summary>Gets the shortcut menu of the header cell.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> if the <see cref="T:System.Windows.Forms.DataGridViewHeaderCell"></see> or <see cref="T:System.Windows.Forms.DataGridView"></see> has a shortcut menu assigned; otherwise, null.</returns>
    /// <param name="intRowIndex">Ignored by this implementation.</param>
    public override ContextMenu GetInheritedContextMenu(int intRowIndex)
    {
      ContextMenu contextMenu = this.GetContextMenu(intRowIndex);
      if (contextMenu != null)
        return contextMenu;
      return this.DataGridView != null ? this.DataGridView.ContextMenu : (ContextMenu) null;
    }

    /// <summary>Gets the inherited context menu strip.</summary>
    /// <param name="intRowIndex">Index of the int row.</param>
    /// <returns></returns>
    public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
    {
      ContextMenuStrip contextMenuStrip = this.GetContextMenuStrip(intRowIndex);
      if (contextMenuStrip != null)
        return contextMenuStrip;
      return this.DataGridView != null ? this.DataGridView.ContextMenuStrip : (ContextMenuStrip) null;
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewHeaderCell objDataGridViewCell = !(type == DataGridViewHeaderCell.cellType) ? (DataGridViewHeaderCell) Activator.CreateInstance(type) : new DataGridViewHeaderCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      objDataGridViewCell.Value = this.Value;
      return (object) objDataGridViewCell;
    }

    /// <summary>Returns a value indicating the current state of the cell as inherited from the state of its row or column.</summary>
    /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
    /// <param name="intRowIndex">The index of the row containing the cell or -1 if the cell is not a row header cell or is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</param>
    /// <exception cref="T:System.ArgumentException">The cell is a row header cell, the cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, and rowIndex is not -1.- or -The cell is a row header cell, the cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, and rowIndex is outside the valid range of 0 to the number of rows in the control minus 1.- or -The cell is a row header cell and rowIndex is not the index of the row containing this cell.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The cell is a column header cell or the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.TopLeftHeaderCell"></see>  and rowIndex is not -1.</exception>
    public override DataGridViewElementStates GetInheritedState(int intRowIndex)
    {
      DataGridViewElementStates inheritedState1 = DataGridViewElementStates.ReadOnly | DataGridViewElementStates.ResizableSet;
      if (this.OwningRow != null)
      {
        if (this.DataGridView == null && intRowIndex != -1 || this.DataGridView != null && (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count))
          throw new ArgumentException(SR.GetString("InvalidArgument", (object) "rowIndex", (object) intRowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.DataGridView != null && this.DataGridView.Rows.SharedRow(intRowIndex) != this.OwningRow)
          throw new ArgumentException(SR.GetString("InvalidArgument", (object) "rowIndex", (object) intRowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        DataGridViewElementStates inheritedState2 = inheritedState1 | this.OwningRow.GetState(intRowIndex) & DataGridViewElementStates.Frozen;
        if (this.OwningRow.GetResizable(intRowIndex) == DataGridViewTriState.True || this.DataGridView != null && this.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing)
          inheritedState2 |= DataGridViewElementStates.Resizable;
        if (this.OwningRow.GetVisible(intRowIndex) && (this.DataGridView == null || this.DataGridView.RowHeadersVisible))
        {
          inheritedState2 |= DataGridViewElementStates.Visible;
          if (this.OwningRow.GetDisplayed(intRowIndex))
            inheritedState2 |= DataGridViewElementStates.Displayed;
        }
        return inheritedState2;
      }
      if (this.OwningColumn != null)
      {
        if (intRowIndex != -1)
          throw new ArgumentOutOfRangeException("rowIndex");
        DataGridViewElementStates inheritedState3 = inheritedState1 | this.OwningColumn.State & DataGridViewElementStates.Frozen;
        if (this.OwningColumn.Resizable == DataGridViewTriState.True || this.DataGridView != null && this.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing)
          inheritedState3 |= DataGridViewElementStates.Resizable;
        if (this.OwningColumn.Visible && (this.DataGridView == null || this.DataGridView.ColumnHeadersVisible))
        {
          inheritedState3 |= DataGridViewElementStates.Visible;
          if (this.OwningColumn.Displayed)
            inheritedState3 |= DataGridViewElementStates.Displayed;
        }
        return inheritedState3;
      }
      if (this.DataGridView != null)
      {
        if (intRowIndex != -1)
          throw new ArgumentOutOfRangeException("rowIndex");
        inheritedState1 |= DataGridViewElementStates.Frozen;
        if (this.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || this.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing)
          inheritedState1 |= DataGridViewElementStates.Resizable;
      }
      return inheritedState1;
    }

    /// <summary>Gets the size of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the size of the header cell.</returns>
    /// <param name="intRowIndex">The row index of the header cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property for this cell is null and rowIndex does not equal -1. -or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> property for this cell is not null and rowIndex does not equal -1. -or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> property for this cell is not null and rowIndex is less than zero or greater than or equal to the number of rows in the control.-or-The values of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> properties of this cell are both null and rowIndex does not equal -1.</exception>
    /// <exception cref="T:System.ArgumentException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> property for this cell is not null and rowIndex indicates a row other than the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see>.</exception>
    protected override Size GetSize(int intRowIndex)
    {
      if (this.DataGridView == null)
      {
        if (intRowIndex != -1)
          throw new ArgumentOutOfRangeException("rowIndex");
        return new Size(-1, -1);
      }
      if (this.OwningRow != null)
      {
        if (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count)
          throw new ArgumentOutOfRangeException("rowIndex");
        if (this.DataGridView.Rows.SharedRow(intRowIndex) != this.OwningRow)
          throw new ArgumentException(SR.GetString("InvalidArgument", (object) "rowIndex", (object) intRowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        return new Size(this.DataGridView.RowHeadersWidth, this.OwningRow.GetHeight(intRowIndex));
      }
      if (intRowIndex != -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      return new Size(this.DataGridView.RowHeadersWidth, this.DataGridView.ColumnHeadersHeight);
    }

    /// <summary>Gets the value of the cell. </summary>
    /// <returns>The value of the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
    protected override object GetValue(int intRowIndex) => (object) null;

    /// <filterpriority>1</filterpriority>
    public override string ToString() => "DataGridViewHeaderCell { ColumnIndex=" + this.ColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + ", RowIndex=" + this.RowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + " }";

    private void UpdateButtonState(ButtonState newButtonState, int intRowIndex) => this.DataGridView.InvalidateCell(this.ColumnIndex, intRowIndex);

    /// <summary>
    /// Gets a value indicating whether [contains local value].
    /// </summary>
    /// <value><c>true</c> if [contains local value]; otherwise, <c>false</c>.</value>
    internal bool ContainsLocalValue
    {
      get
      {
        string str = Convert.ToString(this.LocalValue);
        return str != null && str != "";
      }
    }

    /// <summary>Gets or sets the local value.</summary>
    /// <value>The local value.</value>
    protected object LocalValue
    {
      get => this.mobjLocalValue;
      set => this.mobjLocalValue = value;
    }

    /// <summary>Gets the buttonlike visual state of the header cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ButtonState"></see> values; the default is <see cref="F:Gizmox.WebGUI.Forms.ButtonState.Normal"></see>.</returns>
    protected ButtonState ButtonState => ButtonState.Normal;

    /// <summary>
    /// </summary>
    /// <value></value>
    internal override string TypeName => "7";

    /// <summary>
    /// Gets a value that indicates whether the cell is currently displayed on-screen.
    /// </summary>
    /// <value></value>
    /// <returns>true if the cell is on-screen or partially on-screen; otherwise, false.</returns>
    [Browsable(false)]
    public override bool Displayed
    {
      get
      {
        if (this.DataGridView != null && this.DataGridView.Visible)
        {
          if (this.OwningRow != null)
            return this.DataGridView.RowHeadersVisible && this.OwningRow.Displayed;
          if (this.DataGridView.ColumnHeadersVisible)
            return this.OwningColumn.Displayed;
        }
        return false;
      }
    }

    /// <summary>Gets the type of the formatted value of the cell.</summary>
    /// <returns>A <see cref="T:System.Type"></see> object representing the <see cref="T:System.String"></see> type.</returns>
    public override Type FormattedValueType => DataGridViewHeaderCell.defaultFormattedValueType;

    /// <summary>Gets a value indicating whether the cell is frozen. </summary>
    /// <returns>true if the cell is frozen; otherwise, false. The default is false if the cell is detached from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public override bool Frozen
    {
      get
      {
        if (this.OwningRow != null)
          return this.OwningRow.Frozen;
        if (this.OwningColumn != null)
          return this.OwningColumn.Frozen;
        return this.DataGridView != null;
      }
    }

    /// <summary>Gets a value indicating whether the header cell is read-only.</summary>
    /// <returns>true in all cases.</returns>
    /// <exception cref="T:System.InvalidOperationException">An operation tries to set this property.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override bool ReadOnly
    {
      get => true;
      set => throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", (object) nameof (ReadOnly)));
    }

    /// <summary>Gets a value indicating whether the cell is resizable.</summary>
    /// <returns>true if this cell can be resized; otherwise, false. The default is false if the cell is not attached to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public override bool Resizable
    {
      get
      {
        if (this.OwningRow != null)
        {
          if (this.OwningRow.Resizable == DataGridViewTriState.True)
            return true;
          return this.DataGridView != null && this.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        }
        if (this.OwningColumn != null)
        {
          if (this.OwningColumn.Resizable == DataGridViewTriState.True)
            return true;
          return this.DataGridView != null && this.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        }
        if (this.DataGridView == null)
          return false;
        return this.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || this.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell is selected.</summary>
    /// <returns>false in all cases.</returns>
    /// <exception cref="T:System.InvalidOperationException">This property is being set.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool Selected
    {
      get => false;
      set => throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", (object) nameof (Selected)));
    }

    /// <summary>Gets the type of the value stored in the cell.</summary>
    /// <returns>A <see cref="T:System.Type"></see> object representing the <see cref="T:System.String"></see> type.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type ValueType
    {
      get => DataGridViewHeaderCell.defaultValueType;
      set
      {
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected override string MemberID => "HC" + (object) (this.DataGridView.ColumnCount * this.RowIndex + this.ColumnIndex);

    /// <summary>Gets a value indicating whether or not the cell is visible.</summary>
    /// <returns>true if the cell is visible; otherwise, false. The default is false if the cell is detached from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see></returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public override bool Visible
    {
      get
      {
        if (this.OwningRow != null)
        {
          if (!this.OwningRow.Visible)
            return false;
          return this.DataGridView == null || this.DataGridView.RowHeadersVisible;
        }
        if (this.OwningColumn != null)
        {
          if (!this.OwningColumn.Visible)
            return false;
          return this.DataGridView == null || this.DataGridView.ColumnHeadersVisible;
        }
        return this.DataGridView != null && this.DataGridView.RowHeadersVisible && this.DataGridView.ColumnHeadersVisible;
      }
    }
  }
}
