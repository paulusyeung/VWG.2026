// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumn
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a column in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [TypeConverter(typeof (DataGridViewColumnConverter))]
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewColumn : DataGridViewBand, IComponent, IDisposable
  {
    private Type mobjValueType;
    private ISite mobjSite;
    private string mstrName;
    private byte mobjFlags;
    private string mstrDataPropertyName;
    private int mintDesiredMinimumWidth;
    private int mintDesiredFillWidth;
    private DataGridViewCell mobjCellTemplate;
    private int mintBoundColumnIndex;
    private DataGridViewAutoSizeColumnMode menmAutoSizeMode;
    private float mfltFillWeight;
    private float mfltUsedFillWeight;
    private int mintDisplayIndex;
    private bool mblnIsExcludedFromColumnChooser;
    private string mstrClientId = string.Empty;
    private bool mblnCanGroupBy = true;
    private bool mblnShowHeaderFilter;
    internal string mstrCustomFilterExpression = string.Empty;
    [NonSerialized]
    private TypeConverter mobjBoundColumnConverter;
    private bool mblnAllowRowFiltering = true;
    private const byte DATAGRIDVIEWCOLUMN_automaticSort = 1;
    private const float DATAGRIDVIEWCOLUMN_defaultFillWeight = 100f;
    private const int DATAGRIDVIEWCOLUMN_defaultMinColumnThickness = 5;
    private const int DATAGRIDVIEWCOLUMN_defaultWidth = 100;
    private const byte DATAGRIDVIEWCOLUMN_displayIndexHasChangedInternal = 16;
    private const byte DATAGRIDVIEWCOLUMN_isBrowsableInternal = 8;
    private const byte DATAGRIDVIEWCOLUMN_isDataBound = 4;
    private const byte DATAGRIDVIEWCOLUMN_programmaticSort = 2;
    protected const string TextTypeName = "1";
    protected const string CheckBoxTypeName = "2";
    protected const string ImageTypeName = "3";
    protected const string LinkTypeName = "4";
    protected const string ButtonTypeName = "5";
    protected const string ComboBoxTypeName = "6";

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> is disposed.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler Disposed;

    /// <summary>Occurs when [allow row filtering changed].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler AllowRowFilteringChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> class to the default state.
    /// </summary>
    public DataGridViewColumn()
      : this((DataGridViewCell) null)
    {
      this.TagName = "DC";
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allowed row filtering].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [allowed row filtering]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public virtual bool AllowRowFiltering
    {
      get => this.mblnAllowRowFiltering;
      set
      {
        if (this.AllowRowFilteringInternal == value)
          return;
        this.AllowRowFilteringInternal = value;
        if (this.AllowRowFilteringChanged == null)
          return;
        this.AllowRowFilteringChanged((object) this, EventArgs.Empty);
      }
    }

    /// <summary>
    /// Sets a value indicating whether [row filtering is allowed internally].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [row filtering is allowed internally]; otherwise, <c>false</c>.
    /// </value>
    internal bool AllowRowFilteringInternal
    {
      get => this.mblnAllowRowFiltering;
      set => this.mblnAllowRowFiltering = value;
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected virtual string TypeName => string.Empty;

    /// <summary>Gets the type name internal.</summary>
    /// <value>The type name internal.</value>
    internal string TypeNameInternal => this.TypeName;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is excluded from column chooser.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is excluded from column chooser; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsExcludedFromColumnChooser
    {
      get => this.mblnIsExcludedFromColumnChooser;
      set => this.mblnIsExcludedFromColumnChooser = value;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> class using an existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> as a template.</summary>
    /// <param name="objCellTemplate">An existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to use as a template. </param>
    public DataGridViewColumn(DataGridViewCell objCellTemplate)
    {
      this.TagName = "DC";
      this.BoundColumnIndex = -1;
      this.DataPropertyName = string.Empty;
      this.mfltFillWeight = 100f;
      this.mfltUsedFillWeight = 100f;
      this.Thickness = 100;
      this.MinimumThickness = 5;
      this.BandIsRow = false;
      this.mstrName = string.Empty;
      this.mintDisplayIndex = -1;
      this.CellTemplate = objCellTemplate;
      this.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
      DataGridViewColumnHeaderCell headerCell = this.HeaderCell;
    }

    /// <summary>Gets the member ID.</summary>
    /// <value>The member ID.</value>
    protected override string MemberID => "C" + this.Index.ToString();

    /// <summary>Gets the member ID internal.</summary>
    /// <value>The member ID internal.</value>
    internal new string MemberIDInternal => this.MemberID;

    /// <summary>Sets the fill weight internal.</summary>
    /// <value>The fill weight internal.</value>
    internal float FillWeightInternal
    {
      set => this.mfltFillWeight = value;
    }

    /// <summary>Renders the column's inner components</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.HeaderCell == null)
        return;
      ((IRenderableComponentMember) this.HeaderCell).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Pres the render component.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    internal override void PreRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
      base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
      HeaderFilterInfo columnHeaderInfo = this.DataGridView.GetColumnHeaderInfo(this);
      if (columnHeaderInfo == null)
      {
        this.ShowHeaderFilter = false;
      }
      else
      {
        this.ShowHeaderFilter = true;
        this.IsCustomFilter = columnHeaderInfo.IsCustomFilter;
      }
      this.HeaderCell?.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
    }

    /// <summary>Posts the render component.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
    internal override void PostRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePostRender)
    {
      base.PreRenderComponent(objContext, lngRequestID, blnForcePostRender);
      this.HeaderCell?.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
    }

    /// <summary>Renders the DataGridViewColumn attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      this.RenderDataPropertyName(objWriter);
      objWriter.WriteAttributeString("W", this.Width.ToString());
      if (this.DataGridView.ShowCellToolTips && this.ToolTipText != null && this.ToolTipText != string.Empty)
        objWriter.WriteAttributeText("TT", this.ToolTipText);
      objWriter.WriteAttributeString("TP", this.TypeName);
      if (this.Resizable == DataGridViewTriState.False || this.AutoSizeMode != DataGridViewAutoSizeColumnMode.None && this.DataGridView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.Fill && this.DataGridView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.None)
        objWriter.WriteAttributeString("RE", "0");
      string clientId = this.ClientId;
      if (!string.IsNullOrEmpty(clientId))
        objWriter.WriteAttributeString("CID", clientId);
      this.RenderCanGroupByAttribute(objWriter, false);
    }

    /// <summary>Renders the updated attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        this.RenderDataPropertyName(objWriter);
        this.RenderCanGroupByAttribute(objWriter, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
        return;
      objWriter.WriteAttributeString("W", this.Width.ToString());
    }

    /// <summary>Renders the can group by attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderCanGroupByAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!(!this.mblnCanGroupBy | blnForceRender))
        return;
      objWriter.WriteAttributeString("CG", this.mblnCanGroupBy ? "1" : "0");
    }

    /// <summary>Renders the name of the data property.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [p].</param>
    private void RenderDataPropertyName(IAttributeWriter objWriter)
    {
      if (string.IsNullOrEmpty(this.DataPropertyName))
        return;
      objWriter.WriteAttributeText("N", this.DataPropertyName);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DataGridView != null && this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED))
        criticalEventsData.Set("SC");
      return criticalEventsData;
    }

    /// <summary>Gets the inherited auto size mode.</summary>
    /// <param name="objDataGridView">The data grid view.</param>
    /// <returns></returns>
    internal DataGridViewAutoSizeColumnMode GetInheritedAutoSizeMode(DataGridView objDataGridView)
    {
      DataGridViewAutoSizeColumnMode autoSizeMode = this.AutoSizeMode;
      if (objDataGridView == null || autoSizeMode != DataGridViewAutoSizeColumnMode.NotSet)
        return autoSizeMode;
      switch (objDataGridView.AutoSizeColumnsMode)
      {
        case DataGridViewAutoSizeColumnsMode.ColumnHeader:
          return DataGridViewAutoSizeColumnMode.ColumnHeader;
        case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
          return DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        case DataGridViewAutoSizeColumnsMode.AllCells:
          return DataGridViewAutoSizeColumnMode.AllCells;
        case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
          return DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
        case DataGridViewAutoSizeColumnsMode.DisplayedCells:
          return DataGridViewAutoSizeColumnMode.DisplayedCells;
        case DataGridViewAutoSizeColumnsMode.Fill:
          return DataGridViewAutoSizeColumnMode.Fill;
        default:
          return DataGridViewAutoSizeColumnMode.None;
      }
    }

    /// <summary>Calculates the ideal width of the column based on the specified criteria.</summary>
    /// <returns>The ideal width, in pixels, of the column.</returns>
    /// <param name="enmAutoSizeColumnMode">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value that specifies an automatic sizing mode. </param>
    /// <param name="blnFixedHeight">true to calculate the width of the column based on the current row heights; false to calculate the width with the expectation that the row heights will be adjusted.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value. </exception>
    /// <exception cref="T:System.ArgumentException">autoSizeColumnMode is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
    public virtual int GetPreferredWidth(
      DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode,
      bool blnFixedHeight)
    {
      if (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.NotSet || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.None || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill)
        throw new ArgumentException(SR.GetString("DataGridView_NeedColumnAutoSizingCriteria", (object) "autoSizeColumnMode"));
      switch (enmAutoSizeColumnMode)
      {
        case DataGridViewAutoSizeColumnMode.NotSet:
        case DataGridViewAutoSizeColumnMode.None:
        case DataGridViewAutoSizeColumnMode.ColumnHeader:
        case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
        case DataGridViewAutoSizeColumnMode.AllCells:
        case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
        case DataGridViewAutoSizeColumnMode.DisplayedCells:
        case DataGridViewAutoSizeColumnMode.Fill:
          DataGridView dataGridView = this.DataGridView;
          if (dataGridView == null)
            return -1;
          DataGridViewAutoSizeColumnCriteriaInternal criteriaInternal = (DataGridViewAutoSizeColumnCriteriaInternal) enmAutoSizeColumnMode;
          int preferredWidth = 0;
          if (dataGridView.ColumnHeadersVisible && (criteriaInternal & DataGridViewAutoSizeColumnCriteriaInternal.Header) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
          {
            int num = !blnFixedHeight ? this.HeaderCell.GetPreferredSize(-1).Width : this.HeaderCell.GetPreferredWidth(-1, dataGridView.ColumnHeadersHeight);
            if (preferredWidth < num)
              preferredWidth = num;
          }
          if ((criteriaInternal & DataGridViewAutoSizeColumnCriteriaInternal.AllRows) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
          {
            for (int index = dataGridView.Rows.GetFirstRow(DataGridViewElementStates.Visible); index != -1; index = dataGridView.Rows.GetNextRow(index, DataGridViewElementStates.Visible))
            {
              DataGridViewRow dataGridViewRow = dataGridView.Rows.SharedRow(index);
              int num = !blnFixedHeight ? dataGridViewRow.Cells[this.Index].GetPreferredSize(index).Width : dataGridViewRow.Cells[this.Index].GetPreferredWidth(index, dataGridViewRow.Thickness);
              if (preferredWidth < num)
                preferredWidth = num;
            }
            return preferredWidth;
          }
          if ((criteriaInternal & DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
          {
            int height = dataGridView.LayoutInfo.Data.Height;
            int num1 = 0;
            Size preferredSize;
            for (int index = dataGridView.Rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible); index != -1 && num1 < height; index = dataGridView.Rows.GetNextRow(index, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
            {
              DataGridViewRow dataGridViewRow = dataGridView.Rows.SharedRow(index);
              int num2;
              if (blnFixedHeight)
              {
                num2 = dataGridViewRow.Cells[this.Index].GetPreferredWidth(index, dataGridViewRow.Thickness);
              }
              else
              {
                preferredSize = dataGridViewRow.Cells[this.Index].GetPreferredSize(index);
                num2 = preferredSize.Width;
              }
              if (preferredWidth < num2)
                preferredWidth = num2;
              num1 += dataGridViewRow.Thickness;
            }
            if (num1 >= height)
              return preferredWidth;
            for (int index = dataGridView.FirstDisplayedScrollingRowIndex; index != -1 && num1 < height; index = dataGridView.Rows.GetNextRow(index, DataGridViewElementStates.Visible))
            {
              DataGridViewRow dataGridViewRow = dataGridView.Rows.SharedRow(index);
              int num3;
              if (blnFixedHeight)
              {
                num3 = dataGridViewRow.Cells[this.Index].GetPreferredWidth(index, dataGridViewRow.Thickness);
              }
              else
              {
                preferredSize = dataGridViewRow.Cells[this.Index].GetPreferredSize(index);
                num3 = preferredSize.Width;
              }
              if (preferredWidth < num3)
                preferredWidth = num3;
              num1 += dataGridViewRow.Thickness;
            }
          }
          return preferredWidth;
        default:
          throw new InvalidEnumArgumentException("value", (int) enmAutoSizeColumnMode, typeof (DataGridViewAutoSizeColumnMode));
      }
    }

    /// <summary>Shoulds the serialize default cell style.</summary>
    /// <returns></returns>
    private bool ShouldSerializeDefaultCellStyle()
    {
      if (!this.HasDefaultCellStyle)
        return false;
      DataGridViewCellStyle defaultCellStyle = this.DefaultCellStyle;
      if (defaultCellStyle.BackColor.IsEmpty && defaultCellStyle.ForeColor.IsEmpty && defaultCellStyle.SelectionBackColor.IsEmpty && defaultCellStyle.SelectionForeColor.IsEmpty && defaultCellStyle.Font == null && defaultCellStyle.IsNullValueDefault && defaultCellStyle.IsDataSourceNullValueDefault)
      {
        if (CommonUtils.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider != null && defaultCellStyle.FormatProvider.Equals((object) CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
          return !defaultCellStyle.Padding.Equals((object) Padding.Empty);
      }
      return true;
    }

    /// <summary>Shoulds the serialize header text.</summary>
    /// <returns></returns>
    private bool ShouldSerializeHeaderText() => this.HasHeaderCell && this.HeaderCell.ContainsLocalValue;

    /// <summary>Shoulds serialize the column width.</summary>
    /// <returns></returns>
    private bool ShouldSerializeWidth() => this.InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill && this.Width != 100;

    /// <summary>Gets a string that describes the column.</summary>
    /// <returns>A <see cref="T:System.String"></see> that describes the column.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.Append("DataGridViewColumn { Name=");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>
    /// This is a recursive function that loop through a control and all of its parents
    /// cheching if one of the controls(and control containers) is hidden or
    /// disabled.
    /// </summary>
    /// <value></value>
    /// <returns>false if one of the controls is hidden or disabled.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool IsEventsEnabled => this.Visible && base.IsEventsEnabled;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Resize":
          double num = Convert.ToDouble(objEvent["VLB"], (IFormatProvider) CultureInfo.InvariantCulture);
          if (num <= 5.0)
            break;
          this.ThicknessInternal = Convert.ToInt32(num);
          if (!this.DataGridView.NeedToAdjustFillingColumns)
            break;
          this.DataGridView.ResetUIState(false, false);
          break;
        case "DividerDoubleClick":
          DataGridView dataGridView = this.DataGridView;
          if (dataGridView == null)
            break;
          Point cursorPosition = objEvent.CursorPosition;
          dataGridView.RaiseColumnDividerDoubleClick(new DataGridViewColumnDividerDoubleClickEventArgs(this.Index, new HandledMouseEventArgs(MouseButtons.Left, 2, cursorPosition.X, cursorPosition.X, 280)));
          break;
      }
    }

    /// <summary>Clears the filter of this column.</summary>
    /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
    public void ClearFilter(bool blnClearHeaderFilter)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView != null && dataGridView.ShowFilterRow && dataGridView.FilterRow != null && dataGridView.FilterRow.Cells.Count > 0 && dataGridView.FilterRow.Cells.Count > this.Index)
      {
        (dataGridView.FilterRow.Cells[this.Index] as DataGridViewFilterCell).ClearFilter(blnClearHeaderFilter);
      }
      else
      {
        if (this.HasHeaderCell && this.ShowHeaderFilter)
        {
          this.HeaderCell.FilterComboBox.SelectedIndex = -1;
          this.HeaderCell.FilterComboBox.Text = string.Empty;
        }
        this.CustomFilterExpression = string.Empty;
      }
    }

    /// <summary>Gets or sets the mode by which the column automatically adjusts its width.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.DataGridViewAutoSizeColumnMode"></see> value that determines whether the column will automatically adjust its width and how it will determine its preferred width. The default is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property results in an <see cref="P:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> value of <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> for a visible column when column headers are hidden.-or-The specified value when setting this property results in an <see cref="P:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> value of <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> for a visible column that is frozen.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is a <see cref="T:System.Windows.Forms.DataGridViewAutoSizeColumnMode"></see> that is not valid. </exception>
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("DataGridViewColumn_AutoSizeModeDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(DataGridViewAutoSizeColumnMode.NotSet)]
    public DataGridViewAutoSizeColumnMode AutoSizeMode
    {
      get => this.menmAutoSizeMode;
      set
      {
        switch (value)
        {
          case DataGridViewAutoSizeColumnMode.NotSet:
          case DataGridViewAutoSizeColumnMode.None:
          case DataGridViewAutoSizeColumnMode.ColumnHeader:
          case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
          case DataGridViewAutoSizeColumnMode.AllCells:
          case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
          case DataGridViewAutoSizeColumnMode.DisplayedCells:
          case DataGridViewAutoSizeColumnMode.Fill:
            if (this.menmAutoSizeMode == value)
              break;
            if (this.Visible && this.DataGridView != null)
            {
              if (!this.DataGridView.ColumnHeadersVisible && (value == DataGridViewAutoSizeColumnMode.ColumnHeader || value == DataGridViewAutoSizeColumnMode.NotSet && this.DataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader))
                throw new InvalidOperationException(SR.GetString("DataGridViewColumn_AutoSizeCriteriaCannotUseInvisibleHeaders"));
              if (this.Frozen && (value == DataGridViewAutoSizeColumnMode.Fill || value == DataGridViewAutoSizeColumnMode.NotSet && this.DataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill))
                throw new InvalidOperationException(SR.GetString("DataGridViewColumn_FrozenColumnCannotAutoFill"));
            }
            DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = this.InheritedAutoSizeMode;
            int num;
            switch (inheritedAutoSizeMode)
            {
              case DataGridViewAutoSizeColumnMode.None:
              case DataGridViewAutoSizeColumnMode.Fill:
                num = 0;
                break;
              default:
                num = inheritedAutoSizeMode != 0 ? 1 : 0;
                break;
            }
            bool flag = num != 0;
            this.menmAutoSizeMode = value;
            if (this.DataGridView == null)
            {
              if (this.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || this.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.None || this.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
              {
                if (!(this.Thickness != this.CachedThickness & flag))
                  break;
                this.ThicknessInternal = this.CachedThickness;
                break;
              }
              if (flag)
                break;
              this.CachedThickness = this.Thickness;
              break;
            }
            this.DataGridView.OnAutoSizeColumnModeChanged(this, inheritedAutoSizeMode);
            break;
          default:
            throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewAutoSizeColumnMode));
        }
      }
    }

    /// <summary>Gets or sets the bound column converter.</summary>
    /// <value>The bound column converter.</value>
    internal TypeConverter BoundColumnConverter
    {
      get => this.mobjBoundColumnConverter;
      set => this.mobjBoundColumnConverter = value;
    }

    /// <summary>Gets or sets the index of the bound column.</summary>
    /// <value>The index of the bound column.</value>
    internal int BoundColumnIndex
    {
      get => this.mintBoundColumnIndex;
      set => this.mintBoundColumnIndex = value;
    }

    /// <summary>Gets or sets the template used to create new cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual DataGridViewCell CellTemplate
    {
      get => this.mobjCellTemplate;
      set => this.mobjCellTemplate = value;
    }

    /// <summary>Gets the run-time type of the cell template.</summary>
    /// <returns>The <see cref="T:System.Type"></see> of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> used as a template for this column. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Type CellType => this.CellTemplate?.GetType();

    /// <summary>Gets or sets the name of the data source property or database column to which the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> is bound.</summary>
    /// <returns>The name of the property or database column associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(true)]
    [DefaultValue("")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public string DataPropertyName
    {
      get => this.mstrDataPropertyName;
      set
      {
        if (value == null)
          value = string.Empty;
        if (!(value != this.DataPropertyName))
          return;
        this.mstrDataPropertyName = value;
        if (this.DataGridView != null)
          this.DataGridView.OnColumnDataPropertyNameChanged(this);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the column's default cell style.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default style of the cells in the column.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
    [Browsable(true)]
    [SRCategory("CatAppearance")]
    public override DataGridViewCellStyle DefaultCellStyle
    {
      get => base.DefaultCellStyle;
      set
      {
        if (base.DefaultCellStyle == value)
          return;
        base.DefaultCellStyle = value;
        this.DataGridView?.Update();
      }
    }

    /// <summary>Gets or sets the width of the desired fill.</summary>
    /// <value>The width of the desired fill.</value>
    internal int DesiredFillWidth
    {
      get => this.mintDesiredFillWidth;
      set => this.mintDesiredFillWidth = value;
    }

    /// <summary>Gets or sets the minimum width of the desired.</summary>
    /// <value>The minimum width of the desired.</value>
    internal int DesiredMinimumWidth
    {
      get => this.mintDesiredMinimumWidth;
      set => this.mintDesiredMinimumWidth = value;
    }

    /// <summary>Gets or sets the display order of the column relative to the currently displayed columns.</summary>
    /// <returns>The zero-based position of the column as it is displayed in the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, or -1 if the band is not contained within a control. </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> is not null and the specified value when setting this property is less than 0 or greater than or equal to the number of columns in the control.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> is null and the specified value when setting this property is less than -1.-or-The specified value when setting this property is equal to <see cref="F:System.Int32.MaxValue"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int DisplayIndex
    {
      get => this.mintDisplayIndex;
      set
      {
        if (this.DisplayIndex == value)
          return;
        if (value == int.MaxValue)
        {
          object[] objArray = new object[1]
          {
            (object) int.MaxValue.ToString((IFormatProvider) CultureInfo.CurrentCulture)
          };
          throw new ArgumentOutOfRangeException(nameof (DisplayIndex), (object) value, SR.GetString("DataGridViewColumn_DisplayIndexTooLarge", objArray));
        }
        if (this.DataGridView != null)
        {
          if (value < 0)
            throw new ArgumentOutOfRangeException(nameof (DisplayIndex), (object) value, SR.GetString("DataGridViewColumn_DisplayIndexNegative"));
          if (value >= this.DataGridView.Columns.Count)
            throw new ArgumentOutOfRangeException(nameof (DisplayIndex), (object) value, SR.GetString("DataGridViewColumn_DisplayIndexExceedsColumnCount"));
          this.DataGridView.OnColumnDisplayIndexChanging(this, value);
          this.mintDisplayIndex = value;
          try
          {
            this.DataGridView.InDisplayIndexAdjustments = true;
            this.DataGridView.OnColumnDisplayIndexChanged_PreNotification();
            this.DataGridView.OnColumnDisplayIndexChanged(this);
            this.DataGridView.OnColumnDisplayIndexChanged_PostNotification();
          }
          finally
          {
            this.DataGridView.InDisplayIndexAdjustments = false;
          }
        }
        else
          this.mintDisplayIndex = value >= -1 ? value : throw new ArgumentOutOfRangeException(nameof (DisplayIndex), (object) value, SR.GetString("DataGridViewColumn_DisplayIndexTooNegative"));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [display index has changed].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [display index has changed]; otherwise, <c>false</c>.
    /// </value>
    internal bool DisplayIndexHasChanged
    {
      get => ((uint) this.Flags & 16U) > 0U;
      set
      {
        if (value)
          this.Flags |= (byte) 16;
        else
          this.Flags &= (byte) 239;
      }
    }

    /// <summary>Sets the display index internal.</summary>
    /// <value>The display index internal.</value>
    internal int DisplayIndexInternal
    {
      set => this.mintDisplayIndex = value;
    }

    /// <summary>Gets or sets the width, in pixels, of the column divider.</summary>
    /// <returns>The thickness, in pixels, of the divider (the column's right margin). </returns>
    [DefaultValue(0)]
    [SRDescription("DataGridView_ColumnDividerWidthDescr")]
    [SRCategory("CatLayout")]
    public int DividerWidth
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets a value that represents the width of the column when it is in fill mode relative to the widths of other fill-mode columns in the control.</summary>
    /// <returns>A <see cref="T:System.Single"></see> representing the width of the column when it is in fill mode relative to the widths of other fill-mode columns. The default is 100.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than or equal to 0. </exception>
    [SRCategory("CatLayout")]
    [SRDescription("DataGridViewColumn_FillWeightDescr")]
    [DefaultValue(100f)]
    public float FillWeight
    {
      get => this.mfltFillWeight;
      set
      {
        if ((double) value <= 0.0)
          throw new ArgumentOutOfRangeException(nameof (FillWeight), SR.GetString("InvalidLowBoundArgument", (object) nameof (FillWeight), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if ((double) value > (double) ushort.MaxValue)
          throw new ArgumentOutOfRangeException(nameof (FillWeight), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (FillWeight), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) ((int) ushort.MaxValue).ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (this.DataGridView != null)
        {
          this.DataGridView.OnColumnFillWeightChanging(this, value);
          this.mfltFillWeight = value;
          this.DataGridView.OnColumnFillWeightChanged(this);
        }
        else
          this.mfltFillWeight = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether a column will move when a user scrolls the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control horizontally.</summary>
    /// <returns>true to freeze the column; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatLayout")]
    [SRDescription("DataGridView_ColumnFrozenDescr")]
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.All)]
    public override bool Frozen
    {
      get => base.Frozen;
      set => base.Frozen = !value || this.DataGridView == null || !this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any) ? value : throw new Exception("DataGridView does not support hierarchies with frozen columns");
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> that represents the column header.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> that represents the header cell for the column.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewColumnHeaderCell HeaderCell
    {
      get => (DataGridViewColumnHeaderCell) this.HeaderCellCore;
      set => this.HeaderCellCore = (DataGridViewHeaderCell) value;
    }

    /// <summary>Gets or sets the caption text on the column's header cell.</summary>
    /// <returns>A <see cref="T:System.String"></see> with the desired text. The default is an empty string ("").</returns>
    /// <filterpriority>1</filterpriority>
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_ColumnHeaderTextDescr")]
    public string HeaderText
    {
      get => this.HasHeaderCell && this.HeaderCell.Value is string str ? str : string.Empty;
      set
      {
        if (value == null && !this.HasHeaderCell || !(this.HeaderCell.ValueType != (Type) null) || !this.HeaderCell.ValueType.IsAssignableFrom(typeof (string)))
          return;
        this.HeaderCell.Value = (object) value;
      }
    }

    /// <summary>Gets the sizing mode in effect for the column.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value in effect for the column.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewAutoSizeColumnMode InheritedAutoSizeMode => this.GetInheritedAutoSizeMode(this.DataGridView);

    /// <summary>Gets the cell style currently applied to the column.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the cell style used to display the column.</returns>
    [Browsable(false)]
    public override DataGridViewCellStyle InheritedStyle
    {
      get
      {
        DataGridViewCellStyle inheritedStyle1 = (DataGridViewCellStyle) null;
        if (this.HasDefaultCellStyle)
          inheritedStyle1 = this.DefaultCellStyle;
        if (this.DataGridView == null)
          return inheritedStyle1;
        DataGridViewCellStyle inheritedStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle defaultCellStyle = this.DataGridView.DefaultCellStyle;
        inheritedStyle2.BackColor = inheritedStyle1 == null || inheritedStyle1.BackColor.IsEmpty ? defaultCellStyle.BackColor : inheritedStyle1.BackColor;
        inheritedStyle2.ForeColor = inheritedStyle1 == null || inheritedStyle1.ForeColor.IsEmpty ? defaultCellStyle.ForeColor : inheritedStyle1.ForeColor;
        inheritedStyle2.SelectionBackColor = inheritedStyle1 == null || inheritedStyle1.SelectionBackColor.IsEmpty ? defaultCellStyle.SelectionBackColor : inheritedStyle1.SelectionBackColor;
        inheritedStyle2.SelectionForeColor = inheritedStyle1 == null || inheritedStyle1.SelectionForeColor.IsEmpty ? defaultCellStyle.SelectionForeColor : inheritedStyle1.SelectionForeColor;
        inheritedStyle2.Font = inheritedStyle1 == null || inheritedStyle1.Font == null ? defaultCellStyle.Font : inheritedStyle1.Font;
        inheritedStyle2.NullValue = inheritedStyle1 == null || inheritedStyle1.IsNullValueDefault ? defaultCellStyle.NullValue : inheritedStyle1.NullValue;
        inheritedStyle2.DataSourceNullValue = inheritedStyle1 == null || inheritedStyle1.IsDataSourceNullValueDefault ? defaultCellStyle.DataSourceNullValue : inheritedStyle1.DataSourceNullValue;
        inheritedStyle2.Format = inheritedStyle1 == null || inheritedStyle1.Format.Length == 0 ? defaultCellStyle.Format : inheritedStyle1.Format;
        inheritedStyle2.FormatProvider = inheritedStyle1 == null || inheritedStyle1.IsFormatProviderDefault ? defaultCellStyle.FormatProvider : inheritedStyle1.FormatProvider;
        inheritedStyle2.AlignmentInternal = inheritedStyle1 == null || inheritedStyle1.Alignment == DataGridViewContentAlignment.NotSet ? defaultCellStyle.Alignment : inheritedStyle1.Alignment;
        inheritedStyle2.WrapModeInternal = inheritedStyle1 == null || inheritedStyle1.WrapMode == DataGridViewTriState.NotSet ? defaultCellStyle.WrapMode : inheritedStyle1.WrapMode;
        inheritedStyle2.Tag = inheritedStyle1 == null || inheritedStyle1.Tag == null ? defaultCellStyle.Tag : inheritedStyle1.Tag;
        if (inheritedStyle1 != null && inheritedStyle1.Padding != Padding.Empty)
        {
          inheritedStyle2.PaddingInternal = inheritedStyle1.Padding;
          return inheritedStyle2;
        }
        inheritedStyle2.PaddingInternal = defaultCellStyle.Padding;
        return inheritedStyle2;
      }
    }

    /// <summary>Gets or sets the flags.</summary>
    /// <value>The flags.</value>
    private byte Flags
    {
      get => this.mobjFlags;
      set => this.mobjFlags = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is browsable internal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is browsable internal; otherwise, <c>false</c>.
    /// </value>
    internal bool IsBrowsableInternal
    {
      get => ((uint) this.Flags & 8U) > 0U;
      set
      {
        if (value)
          this.Flags |= (byte) 8;
        else
          this.Flags &= (byte) 247;
      }
    }

    /// <summary>Gets a value indicating whether the column is bound to a data source.</summary>
    /// <returns>true if the column is connected to a data source; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsDataBound => this.IsDataBoundInternal;

    /// <summary>Gets the location.</summary>
    /// <value>The location.</value>
    protected internal override Point Location
    {
      get
      {
        Point empty = Point.Empty;
        if (this.DataGridView != null)
        {
          ref Point local1 = ref empty;
          int x = local1.X;
          Padding padding1 = this.DataGridView.Padding;
          int left1 = padding1.Left;
          padding1 = this.DataGridView.Margin;
          int left2 = padding1.Left;
          int num1 = left1 + left2;
          local1.X = x + num1;
          ref Point local2 = ref empty;
          int y = local2.Y;
          Padding padding2 = this.DataGridView.Padding;
          int top1 = padding2.Top;
          padding2 = this.DataGridView.Margin;
          int top2 = padding2.Top;
          int num2 = top1 + top2;
          local2.Y = y + num2;
          if (this.DataGridView.ColumnHeadersVisible)
            empty.Y += this.DataGridView.ColumnHeadersHeight;
          if (this.DataGridView.RowHeadersVisible)
            empty.X += this.DataGridView.RowHeadersWidth;
          if (this.DataGridView.Columns.Count > 0)
          {
            for (DataGridViewColumn objDataGridViewColumnStart = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null && objDataGridViewColumnStart != this; objDataGridViewColumnStart = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
              empty.X += objDataGridViewColumnStart.Width;
          }
          empty.X -= this.DataGridView.ScrollPoisition.X;
        }
        return empty;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is data bound internal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is data bound internal; otherwise, <c>false</c>.
    /// </value>
    internal bool IsDataBoundInternal
    {
      get => ((uint) this.Flags & 4U) > 0U;
      set
      {
        if (value)
          this.Flags |= (byte) 4;
        else
          this.Flags &= (byte) 251;
      }
    }

    /// <summary>Gets or sets the minimum width, in pixels, of the column.</summary>
    /// <returns>The number of pixels, from 2 to <see cref="F:System.Int32.MaxValue"></see>, that specifies the minimum width of the column. The default is 5.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 2 or greater than <see cref="F:System.Int32.MaxValue"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(5)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [SRDescription("DataGridView_ColumnMinimumWidthDescr")]
    [SRCategory("CatLayout")]
    public int MinimumWidth
    {
      get => this.MinimumThickness;
      set => this.MinimumThickness = value;
    }

    /// <summary>Gets or sets the name of the column.</summary>
    /// <returns>A <see cref="T:System.String"></see> that contains the name of the column. The default is an empty string ("").</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public string Name
    {
      get
      {
        if (this.Site != null)
        {
          if (!CommonUtils.IsNullOrEmpty(this.Site.Name))
            this.mstrName = this.Site.Name;
        }
        return this.mstrName;
      }
      set
      {
        this.mstrName = !CommonUtils.IsNullOrEmpty(value) ? value : string.Empty;
        if (this.DataGridView == null || ClientUtils.IsEquals(this.Name, this.mstrName, StringComparison.Ordinal))
          return;
        this.DataGridView.OnColumnNameChanged(this);
        this.DataGridView.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the user can edit the column's cells.</summary>
    /// <returns>true if the user cannot edit the column's cells; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">This property is set to false for a column that is bound to a read-only data source. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnReadOnlyDescr")]
    [SRCategory("CatBehavior")]
    public override bool ReadOnly
    {
      get => base.ReadOnly;
      set
      {
        int boundColumnIndex = this.BoundColumnIndex;
        if (this.IsDataBound && this.DataGridView != null && this.DataGridView.DataConnection != null && boundColumnIndex != -1 && this.DataGridView.DataConnection.DataFieldIsReadOnly(boundColumnIndex) && !value)
          throw new InvalidOperationException(SR.GetString("DataGridView_ColumnBoundToAReadOnlyFieldMustRemainReadOnly"));
        if (value != this.ReadOnly && this.DataGridView != null)
          this.DataGridView.Update();
        base.ReadOnly = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the column is resizable.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.True"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ColumnResizableDescr")]
    [SRCategory("CatBehavior")]
    public override DataGridViewTriState Resizable
    {
      get => base.Resizable;
      set => base.Resizable = value;
    }

    /// <summary>Gets or sets the site of the column.</summary>
    /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the column, if any.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public ISite Site
    {
      get => this.mobjSite;
      set => this.mobjSite = value;
    }

    /// <summary>Gets or sets the client id.</summary>
    /// <value>The client id.</value>
    [DefaultValue("")]
    public string ClientId
    {
      get => this.mstrClientId;
      set => this.mstrClientId = value;
    }

    /// <summary>Gets or sets the sort mode for the column.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode"></see> that specifies the criteria used to order the rows based on the cell values in a column.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value assigned to the property conflicts with <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DataGridViewColumnSortMode.NotSortable)]
    [SRDescription("DataGridView_ColumnSortModeDescr")]
    [SRCategory("CatBehavior")]
    public DataGridViewColumnSortMode SortMode
    {
      get
      {
        byte flags = this.Flags;
        if (((int) flags & 1) != 0)
          return DataGridViewColumnSortMode.Automatic;
        return ((int) flags & 2) != 0 ? DataGridViewColumnSortMode.Programmatic : DataGridViewColumnSortMode.NotSortable;
      }
      set
      {
        if (value == this.SortMode)
          return;
        if (value != DataGridViewColumnSortMode.NotSortable)
        {
          if (this.DataGridView != null && !this.DataGridView.InInitialization && value == DataGridViewColumnSortMode.Automatic && (this.DataGridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect || this.DataGridView.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
            throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", (object) value.ToString(), (object) this.DataGridView.SelectionMode.ToString()));
          if (value == DataGridViewColumnSortMode.Automatic)
          {
            this.Flags &= (byte) 253;
            this.Flags |= (byte) 1;
          }
          else
          {
            this.Flags &= (byte) 254;
            this.Flags |= (byte) 2;
          }
        }
        else
        {
          this.Flags &= (byte) 254;
          this.Flags &= (byte) 253;
        }
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnColumnSortModeChanged(this);
      }
    }

    /// <summary>Gets or sets the text used for ToolTips.</summary>
    /// <returns>The text to display as a ToolTip for the column.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [SRDescription("DataGridView_ColumnToolTipTextDescr")]
    [DefaultValue("")]
    public string ToolTipText
    {
      get => this.HeaderCell.ToolTipText;
      set
      {
        if (string.Compare(this.ToolTipText, value, false, CultureInfo.InvariantCulture) == 0)
          return;
        this.HeaderCell.ToolTipText = value;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnColumnToolTipTextChanged(this);
      }
    }

    /// <summary>Gets or sets the used fill weight.</summary>
    /// <value>The used fill weight.</value>
    internal float UsedFillWeight
    {
      get => this.mfltUsedFillWeight;
      set => this.mfltUsedFillWeight = value;
    }

    /// <summary>Gets or sets the data type of the values in the column's cells.</summary>
    /// <returns>A <see cref="T:System.Type"></see> that describes the run-time class of the values stored in the column's cells.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [DefaultValue(null)]
    public Type ValueType
    {
      get => this.mobjValueType;
      set => this.mobjValueType = value;
    }

    /// <summary>Gets or sets a value indicating whether the column is visible.</summary>
    /// <returns>true if the column is visible; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Localizable(true)]
    [SRDescription("DataGridView_ColumnVisibleDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    public override bool Visible
    {
      get => base.Visible;
      set
      {
        if (base.Visible == value)
          return;
        base.Visible = value;
        if (!value)
          this.ClearFilter(true);
        this.DataGridView?.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupHeaders);
      }
    }

    /// <summary>Gets or sets the custom filter expression.</summary>
    /// <value>The custom filter expression.</value>
    [DefaultValue("")]
    public string CustomFilterExpression
    {
      get => this.mstrCustomFilterExpression;
      set
      {
        if (!(this.mstrCustomFilterExpression != value))
          return;
        this.mstrCustomFilterExpression = value;
        DataGridView dataGridView = this.DataGridView;
        if (dataGridView == null || dataGridView.mblnSuspendFilterInitialization)
          return;
        dataGridView.ApplyDataGridViewFilter();
      }
    }

    /// <summary>Gets or sets the current width of the column.</summary>
    /// <returns>The width, in pixels, of the column. The default is 100.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is greater than 65536.</exception>
    /// <filterpriority>1</filterpriority>
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("DataGridView_ColumnWidthDescr")]
    [SRCategory("CatLayout")]
    [Localizable(true)]
    public int Width
    {
      get => this.Thickness;
      set => this.Thickness = value;
    }

    /// <summary>Clones the internal.</summary>
    /// <param name="objDataGridViewColumn">The data grid view column.</param>
    protected void CloneInternal(DataGridViewComboBoxColumn objDataGridViewColumn)
    {
      this.CloneInternal((DataGridViewBand) objDataGridViewColumn);
      objDataGridViewColumn.Name = this.Name;
      this.mintDisplayIndex = -1;
      objDataGridViewColumn.HeaderText = this.HeaderText;
      objDataGridViewColumn.DataPropertyName = this.DataPropertyName;
      if (objDataGridViewColumn.CellTemplate != null)
        objDataGridViewColumn.CellTemplate = (DataGridViewCell) this.CellTemplate.Clone();
      else
        objDataGridViewColumn.CellTemplate = (DataGridViewCell) null;
      if (this.HasHeaderCell)
        objDataGridViewColumn.HeaderCell = (DataGridViewColumnHeaderCell) this.HeaderCell.Clone();
      objDataGridViewColumn.AutoSizeMode = this.AutoSizeMode;
      objDataGridViewColumn.SortMode = this.SortMode;
    }

    /// <summary>Gets or sets the shortcut menu for the column.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the current <see cref="T:System.Windows.Forms.DataGridViewColumn"></see>. The default is null.</returns>
    [SRDescription("DataGridView_ColumnContextMenuStripDescr")]
    [DefaultValue(null)]
    [SRCategory("CatBehavior")]
    public override ContextMenu ContextMenu
    {
      get => base.ContextMenu;
      set => base.ContextMenu = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the user can group by this column.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the user can group by this column; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool CanGroupBy
    {
      get => this.mblnCanGroupBy;
      set
      {
        if (this.mblnCanGroupBy == value)
          return;
        this.mblnCanGroupBy = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show header filter].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show header filter]; otherwise, <c>false</c>.
    /// </value>
    internal bool ShowHeaderFilter
    {
      get => this.mblnShowHeaderFilter;
      set
      {
        if (this.mblnShowHeaderFilter == value)
          return;
        this.mblnShowHeaderFilter = value;
        DataGridViewColumnHeaderCell headerCell = this.HeaderCell;
        if (headerCell == null)
          return;
        headerCell.ShouldPreRenderHeaderFilter = this.mblnShowHeaderFilter;
        headerCell.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is custom filter.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is custom filter; otherwise, <c>false</c>.
    /// </value>
    internal bool IsCustomFilter
    {
      get
      {
        DataGridViewColumnHeaderCell headerCell = this.HeaderCell;
        return headerCell != null && headerCell.FilterComboBox.IsCustomFilter;
      }
      set
      {
        DataGridViewColumnHeaderCell headerCell = this.HeaderCell;
        if (headerCell == null)
          return;
        headerCell.FilterComboBox.IsCustomFilter = value;
      }
    }

    /// <summary>Determines whether [has filter info].</summary>
    /// <returns>
    ///   <c>true</c> if [has filter info]; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasFilterInfo()
    {
      DataGridView dataGridView = this.DataGridView;
      return dataGridView != null && dataGridView.GetColumnHeaderInfo(this) != null;
    }
  }
}
