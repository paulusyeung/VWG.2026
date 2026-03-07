// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a column header in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewColumnHeaderCell : DataGridViewHeaderCell
  {
    private SortOrder menmSortGlyphDirection;
    private DataGridViewHeaderFilterComboBox mobjFilterComboBox;
    private bool mblnShouldPreRenderHeaderFilter;
    private static Type mobjCellType = typeof (DataGridViewColumnHeaderCell);
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_horizontalTextMarginLeft = 2;
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_horizontalTextMarginRight = 2;
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphHeight = 7;
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphHorizontalMargin = 4;
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphSeparatorWidth = 2;
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphWidth = 9;
    private const byte DATAGRIDVIEWCOLUMNHEADERCELL_verticalMargin = 1;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> class.</summary>
    public DataGridViewColumnHeaderCell() => this.SortGlyphDirectionInternal = SortOrder.None;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Click":
          this.FireColumnHeaderMouseClick(objEvent);
          break;
        case "DoubleClick":
          this.FireColumnHeaderMouseClick(objEvent);
          this.FireColumnHeaderMouseDoubleClick(objEvent);
          break;
      }
    }

    /// <summary>Fires the column header mouse click.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected virtual void FireColumnHeaderMouseClick(IEvent objEvent)
    {
      if (this.DataGridView == null)
        return;
      int eventValue1 = this.GetEventValue(objEvent, "X", 0);
      int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
      this.DataGridView.FireColumnHeaderMouseClick(new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, 0, 0, new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0)));
      if (this.DataGridView == null)
        return;
      this.DataGridView.Update();
    }

    /// <summary>Fires the column header mouse double click.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected virtual void FireColumnHeaderMouseDoubleClick(IEvent objEvent)
    {
      if (this.DataGridView == null)
        return;
      int eventValue1 = this.GetEventValue(objEvent, "X", 0);
      int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
      this.DataGridView.FireColumnHeaderMouseDoubleClick(new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, 0, 0, new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0)));
    }

    /// <summary>Renders a header- cell's attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      if (this.SortGlyphDirection == SortOrder.None)
        return;
      objWriter.WriteAttributeString("SOD", this.SortGlyphDirection == SortOrder.Descending ? "1" : "0");
    }

    /// <summary>Renders the cell style attributes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objCellStyle">The cell style.</param>
    protected override void RenderCellStyleAttributes(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objCellStyle)
    {
      base.RenderCellStyleAttributes(objWriter, objCellStyle);
      if (objCellStyle == null)
        return;
      objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected override void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.OwningColumn == null || !this.OwningColumn.ShowHeaderFilter || this.mobjFilterComboBox == null)
        return;
      this.mobjFilterComboBox.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Prerenders component.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    internal override void PreRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
      base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
      if (!this.ShouldPreRenderHeaderFilter)
        return;
      this.FilterComboBox.InitializeFilterValues(true, true, false);
      this.ShouldPreRenderHeaderFilter = false;
    }

    /// <summary>
    /// Selected index changed event handler of the filter combo box.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void FilterComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null || dataGridView.mblnSuspendFilterInitialization)
        return;
      if (this.FilterComboBox.SelectedItem is DataGridViewSystemFilterOption selectedItem && selectedItem.Option == SystemFilterOptions.Custom)
      {
        dataGridView.OpenCustomFilterDialog((DataGridViewCell) this);
      }
      else
      {
        dataGridView.mblnSuspendFilterInitialization = true;
        if (dataGridView.ShowFilterRow && dataGridView.FilterRow != null && dataGridView.FilterRow.Cells.Count > 0)
          (dataGridView.FilterRow.Cells[this.OwningColumn.Index] as DataGridViewFilterCell).ClearFilter(false);
        this.OwningColumn.mstrCustomFilterExpression = string.Empty;
        dataGridView.ApplyDataGridViewFilter();
        dataGridView.mblnSuspendFilterInitialization = false;
      }
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DataGridView != null)
      {
        if (this.OwningColumn != null && this.OwningColumn.SortMode != DataGridViewColumnSortMode.NotSortable || this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK))
        {
          criticalEventsData.Set("CL");
          criticalEventsData.Set("RC");
        }
        if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK))
          criticalEventsData.Set("DCL");
      }
      return criticalEventsData;
    }

    /// <summary>
    /// Determines whether [has wrap mode] [the specified obj cell style].
    /// </summary>
    /// <param name="objCellStyle">The obj cell style.</param>
    /// <returns>
    ///   <c>true</c> if [has wrap mode] [the specified obj cell style]; otherwise, <c>false</c>.
    /// </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override bool HasWrapMode(DataGridViewCellStyle objCellStyle)
    {
      DataGridViewColumn owningColumn = this.OwningColumn;
      if (owningColumn != null && owningColumn.AutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet)
      {
        switch (owningColumn.AutoSizeMode)
        {
          case DataGridViewAutoSizeColumnMode.None:
          case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
          case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
          case DataGridViewAutoSizeColumnMode.Fill:
            return objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True;
          default:
            return false;
        }
      }
      else
      {
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView != null)
        {
          switch (dataGridView.AutoSizeColumnsMode)
          {
            case DataGridViewAutoSizeColumnsMode.None:
            case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
            case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
            case DataGridViewAutoSizeColumnsMode.Fill:
              return objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True;
          }
        }
        return false;
      }
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>
    /// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.
    /// </returns>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewColumnHeaderCell objDataGridViewCell = !(type == DataGridViewColumnHeaderCell.mobjCellType) ? (DataGridViewColumnHeaderCell) Activator.CreateInstance(type) : new DataGridViewColumnHeaderCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      objDataGridViewCell.Value = this.Value;
      return (object) objDataGridViewCell;
    }

    /// <summary>Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
    /// <returns>A <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
    /// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="strFormat">The current format string of the cell.</param>
    /// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
    protected override object GetClipboardContent(
      int intRowIndex,
      bool blnFirstCell,
      bool blnLastCell,
      bool blnInFirstRow,
      bool blnInLastRow,
      string strFormat)
    {
      if (intRowIndex != -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      if (this.DataGridView == null)
        return (object) null;
      object obj = this.GetValue(intRowIndex);
      StringBuilder sb = new StringBuilder(64);
      if (ClientUtils.IsEquals(strFormat, DataFormats.Html, StringComparison.OrdinalIgnoreCase))
      {
        if (blnFirstCell)
        {
          sb.Append("<TABLE>");
          sb.Append("<THEAD>");
        }
        sb.Append("<TH>");
        if (obj != null)
          DataGridViewCell.FormatPlainTextAsHtml(obj.ToString(), (TextWriter) new StringWriter(sb, (IFormatProvider) CultureInfo.CurrentCulture));
        else
          sb.Append("&nbsp;");
        sb.Append("</TH>");
        if (blnLastCell)
        {
          sb.Append("</THEAD>");
          if (blnInLastRow)
            sb.Append("</TABLE>");
        }
        return (object) sb.ToString();
      }
      bool blnCsv = ClientUtils.IsEquals(strFormat, DataFormats.CommaSeparatedValue, StringComparison.OrdinalIgnoreCase);
      if (!blnCsv && !ClientUtils.IsEquals(strFormat, DataFormats.Text, StringComparison.OrdinalIgnoreCase) && !ClientUtils.IsEquals(strFormat, DataFormats.UnicodeText, StringComparison.OrdinalIgnoreCase))
        return (object) null;
      if (obj != null)
      {
        bool blnEscapeApplied = false;
        int length = sb.Length;
        DataGridViewCell.FormatPlainText(obj.ToString(), blnCsv, (TextWriter) new StringWriter(sb, (IFormatProvider) CultureInfo.CurrentCulture), ref blnEscapeApplied);
        if (blnEscapeApplied)
          sb.Insert(length, '"');
      }
      if (blnLastCell)
      {
        if (!blnInLastRow)
        {
          sb.Append('\r');
          sb.Append('\n');
        }
      }
      else
        sb.Append(blnCsv ? ',' : '\t');
      return (object) sb.ToString();
    }

    /// <summary>Gets the style applied to the cell. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style. </param>
    /// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
    public override DataGridViewCellStyle GetInheritedStyle(
      DataGridViewCellStyle objInheritedCellStyle,
      int intRowIndex,
      bool blnIncludeColors)
    {
      if (intRowIndex != -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      DataGridViewCellStyle inheritedStyle = objInheritedCellStyle == null ? new DataGridViewCellStyle() : objInheritedCellStyle;
      DataGridViewCellStyle gridViewCellStyle = (DataGridViewCellStyle) null;
      if (this.HasStyle)
        gridViewCellStyle = this.Style;
      DataGridViewCellStyle defaultCellStyle1 = this.DataGridView.ColumnHeadersDefaultCellStyle;
      DataGridViewCellStyle defaultCellStyle2 = this.DataGridView.DefaultCellStyle;
      if (blnIncludeColors)
      {
        if (gridViewCellStyle != null && !gridViewCellStyle.BackColor.IsEmpty)
        {
          inheritedStyle.BackColor = gridViewCellStyle.BackColor;
        }
        else
        {
          Color backColor = defaultCellStyle1.BackColor;
          inheritedStyle.BackColor = backColor.IsEmpty ? defaultCellStyle2.BackColor : defaultCellStyle1.BackColor;
        }
        if (gridViewCellStyle != null && !gridViewCellStyle.ForeColor.IsEmpty)
        {
          inheritedStyle.ForeColor = gridViewCellStyle.ForeColor;
        }
        else
        {
          Color foreColor = defaultCellStyle1.ForeColor;
          inheritedStyle.ForeColor = foreColor.IsEmpty ? defaultCellStyle2.ForeColor : defaultCellStyle1.ForeColor;
        }
        if (gridViewCellStyle != null && !gridViewCellStyle.SelectionBackColor.IsEmpty)
        {
          inheritedStyle.SelectionBackColor = gridViewCellStyle.SelectionBackColor;
        }
        else
        {
          Color selectionBackColor = defaultCellStyle1.SelectionBackColor;
          inheritedStyle.SelectionBackColor = selectionBackColor.IsEmpty ? defaultCellStyle2.SelectionBackColor : defaultCellStyle1.SelectionBackColor;
        }
        if (gridViewCellStyle != null && !gridViewCellStyle.SelectionForeColor.IsEmpty)
        {
          inheritedStyle.SelectionForeColor = gridViewCellStyle.SelectionForeColor;
        }
        else
        {
          Color selectionForeColor = defaultCellStyle1.SelectionForeColor;
          inheritedStyle.SelectionForeColor = selectionForeColor.IsEmpty ? defaultCellStyle2.SelectionForeColor : defaultCellStyle1.SelectionForeColor;
        }
      }
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
    /// <returns>The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see>.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
    protected override object GetValue(int intRowIndex)
    {
      if (intRowIndex != -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      if (this.ContainsLocalValue)
        return this.LocalValue;
      return this.OwningColumn != null ? (object) this.OwningColumn.Name : (object) null;
    }

    /// <summary>
    /// Calculates the preferred size, in pixels, of the cell.
    /// </summary>
    /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <param name="intRowIndex">The zero-based row index of the cell.</param>
    /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
    /// </returns>
    protected override Size GetPreferredSize(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex,
      Size objConstraintSize)
    {
      int num1 = 0;
      if (this.DataGridView != null)
      {
        DataGridViewColumn owningColumn = this.OwningColumn;
        if (this.DataGridView.Skin is DataGridViewSkin skin && owningColumn != null)
        {
          if (owningColumn.SortMode != DataGridViewColumnSortMode.NotSortable)
          {
            int num2 = num1;
            Size indicatorImageSize = skin.SortAscendingIndicatorImageSize;
            int width1 = indicatorImageSize.Width;
            indicatorImageSize = skin.SortDescendingIndicatorImageSize;
            int width2 = indicatorImageSize.Width;
            int num3 = Math.Max(width1, width2);
            num1 = num2 + num3;
          }
          int result;
          if (owningColumn.HasFilterInfo() && int.TryParse(skin.HeaderFilterComboBoxImageWidth.GetValue(VWGContext.Current), out result))
            num1 += result;
        }
      }
      Size objConstraintSize1 = objConstraintSize;
      if (objConstraintSize.Height == 0)
        objConstraintSize1 = new Size(Math.Max(0, objConstraintSize.Width - num1), objConstraintSize1.Height);
      try
      {
        objConstraintSize1 = base.GetPreferredSize(objGraphics, objCellStyle, intRowIndex, objConstraintSize1);
      }
      catch (Exception ex)
      {
      }
      return new Size(objConstraintSize1.Width + num1, objConstraintSize1.Height + 4);
    }

    /// <summary>Sets the value of the cell. </summary>
    /// <returns>true if the value has been set; otherwise false.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <param name="objValue">The cell value to set. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
    protected override bool SetValue(int intRowIndex, object objValue)
    {
      object obj = intRowIndex == -1 ? this.GetValue(intRowIndex) : throw new ArgumentOutOfRangeException("rowIndex");
      this.LocalValue = objValue;
      if (this.DataGridView != null && obj != objValue)
        this.RaiseCellValueChanged(new DataGridViewCellEventArgs(this.ColumnIndex, -1));
      return true;
    }

    public override string ToString() => "DataGridViewColumnHeaderCell { ColumnIndex=" + this.ColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + " }";

    /// <summary>Gets or sets the coll span.</summary>
    /// <value>The coll span.</value>
    public override int Colspan
    {
      get => base.Colspan;
      set => base.Colspan = value <= 1 ? value : throw new NotSupportedException("Header cell does not support col span");
    }

    /// <summary>Gets or sets the row span.</summary>
    /// <value>The row span.</value>
    public override int Rowspan
    {
      get => base.Rowspan;
      set => base.Rowspan = value <= 1 ? value : throw new NotSupportedException("Header cell does not support row span");
    }

    /// <summary>Gets the filter combo box.</summary>
    [Browsable(false)]
    public DataGridViewHeaderFilterComboBox FilterComboBox
    {
      get
      {
        if (this.mobjFilterComboBox == null)
        {
          this.mobjFilterComboBox = new DataGridViewHeaderFilterComboBox(this);
          this.mobjFilterComboBox.SelectedIndexChanged += new EventHandler(this.FilterComboBoxSelectedIndexChanged);
        }
        return this.mobjFilterComboBox;
      }
    }

    /// <summary>Gets or sets a value indicating which sort glyph is displayed.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> value representing the current glyph. The default is <see cref="F:Gizmox.WebGUI.Forms.SortOrder.None"></see>. </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> value.</exception>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the value of either the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> property or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is null.-or-When changing the value of this property, the specified value is not <see cref="F:Gizmox.WebGUI.Forms.SortOrder.None"></see> and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property of the owning column is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable"></see>.</exception>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SortOrder SortGlyphDirection
    {
      get => this.menmSortGlyphDirection;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (SortOrder));
        if (this.OwningColumn == null || this.DataGridView == null)
          throw new InvalidOperationException(SR.GetString("DataGridView_CellDoesNotYetBelongToDataGridView"));
        if (value == this.SortGlyphDirection)
          return;
        if (this.OwningColumn.SortMode == DataGridViewColumnSortMode.NotSortable && value != SortOrder.None)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumnHeaderCell_SortModeAndSortGlyphDirectionClash", (object) value.ToString()));
        this.SortGlyphDirectionInternal = value;
        this.DataGridView.OnSortGlyphDirectionChanged(this);
        this.Update();
      }
    }

    /// <summary>Sets the sort glyph direction internal.</summary>
    /// <value>The sort glyph direction internal.</value>
    internal SortOrder SortGlyphDirectionInternal
    {
      set => this.menmSortGlyphDirection = value;
    }

    /// <summary>Retrieves the inherited shortcut menu for the specified row.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> of the column headers if one exists; otherwise, the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> inherited from <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
    /// <param name="intRowIndex">The index of the row to get the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> of. The index must be -1 to indicate the row of column headers.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
    public override ContextMenu GetInheritedContextMenu(int intRowIndex)
    {
      if (intRowIndex != -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      ContextMenu contextMenu = this.GetContextMenu(-1);
      if (contextMenu != null)
        return contextMenu;
      return this.DataGridView != null ? this.DataGridView.ContextMenu : (ContextMenu) null;
    }

    /// <summary>Gets the inherited context menu strip.</summary>
    /// <param name="intRowIndex">Index of the int row.</param>
    /// <returns></returns>
    public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
    {
      if (intRowIndex != -1)
        throw new ArgumentOutOfRangeException("rowIndex");
      ContextMenuStrip contextMenuStrip = this.GetContextMenuStrip(-1);
      if (contextMenuStrip != null)
        return contextMenuStrip;
      return this.DataGridView != null ? this.DataGridView.ContextMenuStrip : (ContextMenuStrip) null;
    }

    /// <summary>
    /// 
    /// </summary>
    protected override string MemberID => "CHC" + (object) this.ColumnIndex;

    /// <summary>
    /// Gets or sets a value indicating whether [should pre render header filter].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [should pre render header filter]; otherwise, <c>false</c>.
    /// </value>
    internal bool ShouldPreRenderHeaderFilter
    {
      get => this.mblnShouldPreRenderHeaderFilter;
      set => this.mblnShouldPreRenderHeaderFilter = value;
    }
  }
}
