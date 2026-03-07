// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a row header of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
  /// </summary>
  [Serializable]
  public class DataGridViewRowHeaderCell : DataGridViewHeaderCell
  {
    private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginHeight = 3;
    private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginWidth = 3;
    private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginLeft = 1;
    private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginRight = 2;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginHeight = 2;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginWidth = 3;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconsHeight = 11;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconsWidth = 12;
    private const byte DATAGRIDVIEWROWHEADERCELL_verticalTextMargin = 1;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Click":
          if (this.DataGridView == null)
            break;
          int eventValue1 = this.GetEventValue(objEvent, "X", 0);
          int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
          this.DataGridView.FireRowHeaderMouseClick(new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, 0, 0, new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0)));
          if (this.DataGridView == null)
            break;
          this.DataGridView.Update();
          break;
        case "DoubleClick":
          if (this.DataGridView == null)
            break;
          int eventValue3 = this.GetEventValue(objEvent, "X", 0);
          int eventValue4 = this.GetEventValue(objEvent, "Y", 0);
          this.DataGridView.OnRowHeaderMouseDoubleClickInternal(new DataGridViewCellMouseEventArgs(-1, this.RowIndex, eventValue3, eventValue4, new MouseEventArgs(MouseButtons.Left, 1, eventValue3, eventValue4, 0)));
          break;
      }
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DataGridView != null)
      {
        if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK))
        {
          criticalEventsData.Set("CL");
          criticalEventsData.Set("RC");
        }
        if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK))
          criticalEventsData.Set("DCL");
      }
      return criticalEventsData;
    }

    /// <summary>Gets the shortcut menu of the header cell.</summary>
    /// <param name="intRowIndex">Ignored by this implementation.</param>
    /// <returns>
    /// A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> if the <see cref="T:System.Windows.Forms.DataGridViewHeaderCell"></see> or <see cref="T:System.Windows.Forms.DataGridView"></see> has a shortcut menu assigned; otherwise, null.
    /// </returns>
    public override ContextMenu GetInheritedContextMenu(int intRowIndex)
    {
      if (this.DataGridView != null && (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count))
        throw new ArgumentOutOfRangeException("rowIndex");
      ContextMenu contextMenu = this.GetContextMenu(intRowIndex);
      if (contextMenu != null)
        return contextMenu;
      return this.DataGridView != null ? this.DataGridView.ContextMenu : (ContextMenu) null;
    }

    /// <summary>
    /// Calculates the preferred size, in pixels, of the cell.
    /// </summary>
    /// <param name="strText">The text to be measured.</param>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
    /// </returns>
    protected override Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
    {
      Size preferredSize = base.GetPreferredSize(strText, objCellStyle);
      DataGridViewRow owningRow = this.OwningRow;
      if (owningRow != null)
      {
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView != null && dataGridView.Skin is DataGridViewSkin skin)
        {
          string str = dataGridView.Context.RightToLeft ? "RTL" : "LTR";
          Size imageSize1 = skin.GetImageSize(string.Format("DGVEditedMode{0}.gif", (object) str));
          Size imageSize2 = skin.GetImageSize(string.Format("Arrow{0}.gif", (object) str));
          preferredSize.Height = Math.Max(preferredSize.Height, Math.Max(imageSize2.Height, imageSize1.Height));
          if (owningRow.IsNewRow)
          {
            Size imageSize3 = skin.GetImageSize("DGVNewRowMode.gif");
            preferredSize.Height = Math.Max(preferredSize.Height, imageSize3.Height);
          }
        }
      }
      return preferredSize;
    }

    /// <summary>Gets the inherited context menu strip.</summary>
    /// <param name="intRowIndex">Index of the int row.</param>
    /// <returns></returns>
    public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
    {
      if (this.DataGridView != null && (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count))
        throw new ArgumentOutOfRangeException("rowIndex");
      ContextMenuStrip contextMenuStrip = this.GetContextMenuStrip(intRowIndex);
      if (contextMenuStrip != null)
        return contextMenuStrip;
      return this.DataGridView != null ? this.DataGridView.ContextMenuStrip : (ContextMenuStrip) null;
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>
    /// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.
    /// </returns>
    public override object Clone() => (object) null;

    /// <summary>Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
    /// <returns>A <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
    /// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="strFormat">The current format string of the cell.</param>
    /// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than or equal to the number of rows in the control.</exception>
    protected override object GetClipboardContent(
      int intRowIndex,
      bool blnFirstCell,
      bool blnLastCell,
      bool blnInFirstRow,
      bool blnInLastRow,
      string strFormat)
    {
      return (object) null;
    }

    /// <summary>Gets the style applied to the cell.</summary>
    /// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style.</param>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false.</param>
    /// <returns>
    /// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0, or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The cell has no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    public override DataGridViewCellStyle GetInheritedStyle(
      DataGridViewCellStyle objInheritedCellStyle,
      int intRowIndex,
      bool blnIncludeColors)
    {
      DataGridViewCellStyle inheritedStyle = objInheritedCellStyle == null ? new DataGridViewCellStyle() : objInheritedCellStyle;
      DataGridViewCellStyle gridViewCellStyle = (DataGridViewCellStyle) null;
      if (this.HasStyle)
        gridViewCellStyle = this.Style;
      DataGridViewCellStyle defaultCellStyle1 = this.DataGridView.RowHeadersDefaultCellStyle;
      DataGridViewCellStyle defaultCellStyle2 = this.DataGridView.DefaultCellStyle;
      if (blnIncludeColors)
      {
        Color color;
        if (gridViewCellStyle != null)
        {
          color = gridViewCellStyle.BackColor;
          if (!color.IsEmpty)
          {
            inheritedStyle.BackColor = gridViewCellStyle.BackColor;
            goto label_7;
          }
        }
        color = defaultCellStyle1.BackColor;
        inheritedStyle.BackColor = color.IsEmpty ? defaultCellStyle2.BackColor : defaultCellStyle1.BackColor;
label_7:
        if (gridViewCellStyle != null)
        {
          color = gridViewCellStyle.ForeColor;
          if (!color.IsEmpty)
          {
            inheritedStyle.ForeColor = gridViewCellStyle.ForeColor;
            goto label_11;
          }
        }
        color = defaultCellStyle1.ForeColor;
        inheritedStyle.ForeColor = color.IsEmpty ? defaultCellStyle2.ForeColor : defaultCellStyle1.ForeColor;
label_11:
        if (gridViewCellStyle != null)
        {
          color = gridViewCellStyle.SelectionBackColor;
          if (!color.IsEmpty)
          {
            inheritedStyle.SelectionBackColor = gridViewCellStyle.SelectionBackColor;
            goto label_15;
          }
        }
        color = defaultCellStyle1.SelectionBackColor;
        inheritedStyle.SelectionBackColor = color.IsEmpty ? defaultCellStyle2.SelectionBackColor : defaultCellStyle1.SelectionBackColor;
label_15:
        if (gridViewCellStyle != null)
        {
          color = gridViewCellStyle.SelectionForeColor;
          if (!color.IsEmpty)
          {
            inheritedStyle.SelectionForeColor = gridViewCellStyle.SelectionForeColor;
            goto label_19;
          }
        }
        color = defaultCellStyle1.SelectionForeColor;
        inheritedStyle.SelectionForeColor = color.IsEmpty ? defaultCellStyle2.SelectionForeColor : defaultCellStyle1.SelectionForeColor;
      }
label_19:
      inheritedStyle.Font = gridViewCellStyle == null || gridViewCellStyle.Font == null ? (defaultCellStyle1.Font == null ? defaultCellStyle2.Font : defaultCellStyle1.Font) : gridViewCellStyle.Font;
      inheritedStyle.NullValue = gridViewCellStyle == null || gridViewCellStyle.IsNullValueDefault ? (defaultCellStyle1.IsNullValueDefault ? defaultCellStyle2.NullValue : defaultCellStyle1.NullValue) : gridViewCellStyle.NullValue;
      inheritedStyle.DataSourceNullValue = gridViewCellStyle == null || gridViewCellStyle.IsDataSourceNullValueDefault ? (defaultCellStyle1.IsDataSourceNullValueDefault ? defaultCellStyle2.DataSourceNullValue : defaultCellStyle1.DataSourceNullValue) : gridViewCellStyle.DataSourceNullValue;
      inheritedStyle.Format = gridViewCellStyle == null || gridViewCellStyle.Format.Length == 0 ? (defaultCellStyle1.Format.Length == 0 ? defaultCellStyle2.Format : defaultCellStyle1.Format) : gridViewCellStyle.Format;
      inheritedStyle.FormatProvider = gridViewCellStyle == null || gridViewCellStyle.IsFormatProviderDefault ? (defaultCellStyle1.IsFormatProviderDefault ? defaultCellStyle2.FormatProvider : defaultCellStyle1.FormatProvider) : gridViewCellStyle.FormatProvider;
      inheritedStyle.AlignmentInternal = gridViewCellStyle == null || gridViewCellStyle.Alignment == DataGridViewContentAlignment.NotSet ? (defaultCellStyle1.Alignment == DataGridViewContentAlignment.NotSet ? defaultCellStyle2.Alignment : defaultCellStyle1.Alignment) : gridViewCellStyle.Alignment;
      inheritedStyle.WrapModeInternal = gridViewCellStyle == null || gridViewCellStyle.WrapMode == DataGridViewTriState.NotSet ? (defaultCellStyle1.WrapMode == DataGridViewTriState.NotSet ? defaultCellStyle2.WrapMode : defaultCellStyle1.WrapMode) : gridViewCellStyle.WrapMode;
      inheritedStyle.Tag = gridViewCellStyle == null || gridViewCellStyle.Tag == null ? (defaultCellStyle1.Tag == null ? defaultCellStyle2.Tag : defaultCellStyle1.Tag) : gridViewCellStyle.Tag;
      if (gridViewCellStyle != null && gridViewCellStyle.Padding != Padding.Empty)
      {
        inheritedStyle.PaddingInternal = gridViewCellStyle.Padding;
        return inheritedStyle;
      }
      if (defaultCellStyle1.Padding != Padding.Empty)
      {
        inheritedStyle.PaddingInternal = defaultCellStyle1.Padding;
        return inheritedStyle;
      }
      inheritedStyle.PaddingInternal = defaultCellStyle2.Padding;
      return inheritedStyle;
    }

    /// <summary>Gets the value of the cell. </summary>
    /// <returns>The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see>.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than -1 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    protected override object GetValue(int intRowIndex)
    {
      if (this.DataGridView != null && (intRowIndex < -1 || intRowIndex >= this.DataGridView.Rows.Count))
        throw new ArgumentOutOfRangeException("rowIndex");
      return this.ContainsLocalValue ? this.LocalValue : (object) null;
    }

    /// <summary>Sets the value of the cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <param name="objValue">The cell value to set.</param>
    /// <returns>true if the value has been set; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    protected override bool SetValue(int intRowIndex, object objValue)
    {
      object obj = this.GetValue(intRowIndex);
      if (objValue != null || this.ContainsLocalValue)
        this.LocalValue = objValue;
      if (this.DataGridView != null && obj != objValue)
        this.RaiseCellValueChanged(new DataGridViewCellEventArgs(-1, intRowIndex));
      return true;
    }

    /// <filterpriority>1</filterpriority>
    public override string ToString() => (string) null;

    /// <summary>Gets the left arrow bitmap.</summary>
    /// <value>The left arrow bitmap.</value>
    private static Bitmap LeftArrowBitmap => (Bitmap) null;

    /// <summary>Gets the left arrow star bitmap.</summary>
    /// <value>The left arrow star bitmap.</value>
    private static Bitmap LeftArrowStarBitmap => (Bitmap) null;

    /// <summary>Gets the pencil LTR bitmap.</summary>
    /// <value>The pencil LTR bitmap.</value>
    private static Bitmap PencilLTRBitmap => (Bitmap) null;

    /// <summary>Gets the pencil RTL bitmap.</summary>
    /// <value>The pencil RTL bitmap.</value>
    private static Bitmap PencilRTLBitmap => (Bitmap) null;

    /// <summary>Gets the right arrow bitmap.</summary>
    /// <value>The right arrow bitmap.</value>
    private static Bitmap RightArrowBitmap => (Bitmap) null;

    /// <summary>Gets the right arrow star bitmap.</summary>
    /// <value>The right arrow star bitmap.</value>
    private static Bitmap RightArrowStarBitmap => (Bitmap) null;

    /// <summary>Gets the star bitmap.</summary>
    /// <value>The star bitmap.</value>
    private static Bitmap StarBitmap => (Bitmap) null;

    /// <summary>Renders the Row header cell member ID</summary>
    protected override string MemberID => "RHC" + (object) this.RowIndex;
  }
}
