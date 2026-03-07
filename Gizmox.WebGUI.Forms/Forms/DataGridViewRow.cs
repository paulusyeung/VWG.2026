// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRow
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a row in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [TypeConverter("Gizmox.WebGUI.Forms.DataGridViewRowConverter, Gizmox.WebGUI.Forms")]
  [Serializable]
  public class DataGridViewRow : DataGridViewBand
  {
    private string mstrErrorText;
    private static Type objRowType = typeof (DataGridViewRow);
    private DataGridViewCellCollection mobjCells;
    private HierarchicDataGridView mobjChildGrid;
    private HierarchicInfo mobjRelatedHierarchyInfo;
    private DataGridViewRowStyle mobjStyle;
    private RowExpansionType menmRowExpansionType;
    private bool mblnIsExpanded;

    /// <summary>Gets or sets the type of the row expansion.</summary>
    /// <value>The type of the row expansion.</value>
    [DefaultValue(RowExpansionType.Inherit)]
    public RowExpansionType RowExpansionIndicatorVisibility
    {
      get => this.menmRowExpansionType;
      set
      {
        if (this.menmRowExpansionType == value)
          return;
        this.menmRowExpansionType = value;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> class without using a template.</summary>
    public DataGridViewRow()
    {
      this.BandIsRow = true;
      this.MinimumThickness = 3;
      this.Thickness = DataGridViewRow.GetDefaultRowHeight();
      this.mobjStyle = new DataGridViewRowStyle(this);
      this.TagName = "DR";
    }

    /// <summary>Called when [shared state changed].</summary>
    /// <param name="intSharedRowIndex">Index of the shared row.</param>
    /// <param name="enmElementState">State of the element.</param>
    internal void OnSharedStateChanged(
      int intSharedRowIndex,
      DataGridViewElementStates enmElementState)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        return;
      DataGridViewRowCollection rows = dataGridView.Rows;
      dataGridView.Rows.InvalidateCachedRowCount(enmElementState);
      dataGridView.Rows.InvalidateCachedRowsHeight(enmElementState);
      dataGridView.OnDataGridViewElementStateChanged((DataGridViewElement) this, intSharedRowIndex, enmElementState);
    }

    /// <summary>Called when [shared state changing].</summary>
    /// <param name="intSharedRowIndex">Index of the shared row.</param>
    /// <param name="enmElementState">State of the element.</param>
    internal void OnSharedStateChanging(
      int intSharedRowIndex,
      DataGridViewElementStates enmElementState)
    {
      this.DataGridView.OnDataGridViewElementStateChanging((DataGridViewElement) this, intSharedRowIndex, enmElementState);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Resize":
          int num = int.Parse(objEvent["VLB"]);
          if (num <= 5)
            break;
          this.ThicknessInternal = num;
          break;
        case "Click":
          if (this.DataGridView == null)
            break;
          int eventValue1 = this.GetEventValue(objEvent, "X", 0);
          int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
          MouseEventArgs e = new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0);
          this.DataGridView.OnRowHeaderMouseClickInternal(new DataGridViewCellMouseEventArgs(-1, this.Index, eventValue1, eventValue2, e));
          break;
        case "DoubleClick":
          if (this.DataGridView == null)
            break;
          int eventValue3 = this.GetEventValue(objEvent, "X", 0);
          int eventValue4 = this.GetEventValue(objEvent, "Y", 0);
          this.DataGridView.OnRowHeaderMouseDoubleClickInternal(new DataGridViewCellMouseEventArgs(-1, this.Index, eventValue3, eventValue4, new MouseEventArgs(MouseButtons.Left, 1, eventValue3, eventValue4, 0)));
          break;
        case "Expand":
          this.ExpandInternal(true);
          break;
        case "Collapse":
          this.Collapse();
          break;
      }
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DataGridView != null && this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEIGHTCHANGED))
        criticalEventsData.Set("SC");
      return criticalEventsData;
    }

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree/
    /// </summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected override void RenderComponent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        this.RenderSelectedAttribute(objWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        this.RenderNumberOfChildRows(objWriter, true);
        this.RenderRowExpansionType(objWriter, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Layout) || !this.Visible)
        return;
      objWriter.WriteAttributeString("H", this.Height.ToString());
    }

    /// <summary>Renders the band attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      if (this.DataGridView == null || !this.Visible)
        return;
      if (this.IsNewRow)
        objWriter.WriteAttributeString("IN", "1");
      if (DataGridViewElement.ShouldRender(this.RenderMask, DataGridViewElement.Renderable.SelectedAttribute))
        this.RenderSelectedAttribute(objWriter, false);
      objWriter.WriteAttributeString("H", this.Height.ToString());
      if (this.Resizable == DataGridViewTriState.False)
        objWriter.WriteAttributeString("RE", "0");
      if (DataGridViewElement.ShouldRender(this.RenderMask, DataGridViewElement.Renderable.ErrorTextAttribute))
      {
        string errorText = this.ErrorText;
        if (!string.IsNullOrEmpty(errorText))
          objWriter.WriteAttributeText("EM", errorText);
      }
      if (this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any) && !this.IsNewRow)
      {
        if (this.Expanded)
          objWriter.WriteAttributeString("IEX", "1");
        if (this.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded) && this.mobjChildGrid != null)
          objWriter.WriteAttributeString("CGH", this.ChildGrid.Height.ToString());
        if (this.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded))
          this.RenderNumberOfChildRows(objWriter, false);
        this.RenderRowExpansionType(objWriter, false);
      }
      DataGridViewRowStyle style = this.Style;
      if (style == null || style.BorderWidth == 0 || !(style.BorderColor != Color.Empty) || style.BorderStyle == BorderStyle.None)
        return;
      objWriter.WriteAttributeString("BS", BorderValue.GetBorderName(style.BorderStyle));
      objWriter.WriteAttributeString("BC", BorderValue.GetBorderColor(style.BorderColor).ToString());
      objWriter.WriteAttributeString("BRW", style.BorderWidth.ToString());
    }

    /// <summary>Renders the type of the row expansion.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderRowExpansionType(IAttributeWriter objWriter, bool blnForceRender)
    {
      RowExpansionType indicatorVisibility = this.RowExpansionIndicatorVisibility;
      if (!(indicatorVisibility != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("EIN", ((int) indicatorVisibility).ToString());
    }

    /// <summary>Renders the number of child rows.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderNumberOfChildRows(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!this.ContainedInBindedHierarchicGrid || this.mobjChildGrid == null)
        return;
      int intValue = this.mobjChildGrid.AllowUserToAddRows ? this.mobjChildGrid.Rows.Count - 1 : this.mobjChildGrid.Rows.Count;
      objWriter.WriteAttributeString("NOC", intValue);
    }

    /// <summary>Renders the selected attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSelectedAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.Selected && (this.DataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect || this.DataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect))
      {
        objWriter.WriteAttributeString("SE", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SE", "0");
      }
    }

    /// <summary>Pres the render component.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    private void PreRenderHeaderCell(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
      this.HeaderCell?.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
    }

    /// <summary>Posts the render header cell.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
    private void PostRenderHeaderCell(
      IContext objContext,
      long lngRequestID,
      bool blnForcePostRender)
    {
      this.HeaderCell?.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
    }

    /// <summary>Pres the render component.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    internal override void PreRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
      base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
      this.PreRenderHeaderCell(objContext, lngRequestID, blnForcePreRender);
      if (this.DataGridView != null)
      {
        for (DataGridViewColumn objDataGridViewColumnStart = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null && objDataGridViewColumnStart.Index >= 0 && objDataGridViewColumnStart.Index < this.Cells.Count; objDataGridViewColumnStart = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
          this.Cells[objDataGridViewColumnStart.Index].PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
      }
      if (!this.Expanded || !this.ContainedInBindedHierarchicGrid)
        return;
      this.ChildGrid.PreRenderControlInternal(objContext, lngRequestID);
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
      base.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
      this.PostRenderHeaderCell(objContext, lngRequestID, blnForcePostRender);
      if (this.DataGridView != null)
      {
        for (DataGridViewColumn objDataGridViewColumnStart = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null && objDataGridViewColumnStart.Index >= 0 && objDataGridViewColumnStart.Index < this.Cells.Count; objDataGridViewColumnStart = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
          this.Cells[objDataGridViewColumnStart.Index].PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
      }
      if (!this.Expanded || !this.ContainedInBindedHierarchicGrid)
        return;
      this.ChildGrid.PostRenderControlInternal(objContext, lngRequestID);
    }

    /// <summary>Renders the controls sub tree</summary>
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
      if (this.HeaderCell != null)
        ((IRenderableComponentMember) this.HeaderCell).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.DataGridView == null)
        return;
      for (DataGridViewColumn objDataGridViewColumnStart = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible); objDataGridViewColumnStart != null && objDataGridViewColumnStart.Index >= 0 && objDataGridViewColumnStart.Index < this.Cells.Count; objDataGridViewColumnStart = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumnStart, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
        ((IRenderableComponentMember) this.Cells[objDataGridViewColumnStart.Index]).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (!this.Expanded || !this.ContainedInBindedHierarchicGrid)
        return;
      this.ChildGrid.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Gets the default height of the row.</summary>
    /// <returns></returns>
    public static int GetDefaultRowHeight() => CommonUtils.GetFontHeight(Control.DefaultFont) + 9;

    /// <summary>Resets the child grid.</summary>
    internal void ResetChildGrid()
    {
      if (this.mobjChildGrid == null)
        return;
      this.Collapse();
      this.mobjChildGrid = (HierarchicDataGridView) null;
    }

    /// <summary>Expands this instance.</summary>
    public void Expand() => this.ExpandInternal(false);

    /// <summary>Expands this instance.</summary>
    /// <param name="blnIsClientSource">True - if the user expanded the row from the row's expantion button, False - if row was expanded from an external invokation (like a Button.Click event)</param>
    private void ExpandInternal(bool blnIsClientSource)
    {
      if (this.IsFilterRow || this.IsNewRow)
        return;
      if (this.ContainedInBindedHierarchicGrid)
      {
        if (this.mobjChildGrid == null)
          this.mobjChildGrid = this.CreateAndBindChildDataGrid();
        this.mblnIsExpanded = true;
        if (blnIsClientSource)
        {
          switch (this.DataGridView.RootGrid.ExpansionIndicator)
          {
            case ShowExpansionIndicator.Always:
              break;
            case ShowExpansionIndicator.Never:
              this.Collapse();
              break;
            case ShowExpansionIndicator.CheckOnDisplay:
            case ShowExpansionIndicator.CheckOnExpand:
            case ShowExpansionIndicator.Empty:
              if (!this.mobjChildGrid.HasRows())
              {
                this.Collapse();
                this.UpdateParams(AttributeType.Control);
                break;
              }
              break;
            default:
              throw new NotImplementedException("The expanstion indicator of type: " + this.DataGridView.RootGrid.ExpansionIndicator.ToString() + " is not supported");
          }
        }
      }
      else if (this.IsHierarchic)
        this.mblnIsExpanded = true;
      if (!this.mblnIsExpanded)
        return;
      RowExpandingEventArgs objArgs = new RowExpandingEventArgs(this);
      this.DataGridView.OnRowExpanding(objArgs);
      if (!objArgs.Cancel)
      {
        this.DataGridView.OnRowExpanded(new RowExpandedEventArgs(this));
        this.Update();
      }
      else
        this.mblnIsExpanded = false;
    }

    /// <summary>Ensures the columns visibility.</summary>
    internal void EnsureColumnsVisibility(DataGridView objDataGridView, HierarchicInfo objInfo)
    {
      if (objDataGridView == null || objInfo == null)
        return;
      DataGridView rootGrid = objDataGridView.RootGrid;
      List<DataGridViewColumn> objChangedColumnsVisibility = new List<DataGridViewColumn>();
      foreach (DataGridViewColumn column in (BaseCollection) objDataGridView.Columns)
      {
        string dataPropertyName = column.DataPropertyName;
        bool flag = objInfo.HiddenColumns.IndexOf(dataPropertyName) == -1;
        if (flag && rootGrid.HideGroupedColumns)
          flag = rootGrid.GroupingColumns.IndexOf(dataPropertyName) == -1;
        if (column.Visible != flag)
        {
          column.Visible = flag;
          objChangedColumnsVisibility.Add(column);
        }
      }
      objDataGridView.OnColumnChooserColumnsVisibilityChanged(objChangedColumnsVisibility);
    }

    /// <summary>Collapses this instance.</summary>
    public void Collapse()
    {
      if (!this.mblnIsExpanded)
        return;
      RowCollapsingEventArgs objEventArgs = new RowCollapsingEventArgs(this);
      this.DataGridView.OnRowCollapsing(objEventArgs);
      if (!objEventArgs.Cancel)
      {
        this.mblnIsExpanded = false;
        this.DataGridView.OnRowCollapsed(this);
      }
      this.Update();
    }

    /// <summary>Gets the grouping columns without root.</summary>
    /// <param name="objDataGridViewColumns">The obj data grid view columns.</param>
    /// <returns></returns>
    private UniqueObservableCollection<string> GetGroupingColumnsWithoutRoot(
      UniqueObservableCollection<string> objDataGridViewColumns)
    {
      UniqueObservableCollection<string> columnsWithoutRoot = new UniqueObservableCollection<string>();
      for (int index = 1; index < objDataGridViewColumns.Count; ++index)
        columnsWithoutRoot.Add(objDataGridViewColumns[index]);
      return columnsWithoutRoot;
    }

    /// <summary>Binds the child data grid.</summary>
    private HierarchicDataGridView CreateAndBindChildDataGrid()
    {
      HierarchicDataGridView gridView = this.CreateGridView();
      DataGridView dataGridView = this.DataGridView;
      gridView.VisualTemplate = dataGridView.VisualTemplate;
      gridView.HierarchyLevel = dataGridView.HierarchyLevel + 1;
      gridView.ContainingRow = this;
      dataGridView.RootGrid.NotifyHierarchicGridCreated(gridView);
      gridView.RootGrid = dataGridView.RootGrid;
      gridView.GroupingColumns = this.GetGroupingColumnsWithoutRoot(dataGridView.GroupingColumns);
      gridView.SystemHierarchicInfos = HierarchicInfo.GetClonedInfos(dataGridView.SystemHierarchicInfos, false);
      dataGridView.SuspendLayout();
      ObservableCollection<HierarchicInfo> hierarchicInfos = dataGridView.HierarchicInfos;
      dataGridView.ResumeLayout();
      if (dataGridView.RootGrid.SystemHierarchicInfos.Count > dataGridView.HierarchyLevel)
        gridView.HierarchicInfos = HierarchicInfo.GetClonedInfos(hierarchicInfos, true);
      else
        gridView.HierarchicInfos = HierarchicInfo.GetClonedInfos(hierarchicInfos, false);
      ObservableCollection<HierarchicInfo> relevantHierarchicInfos = this.DataGridView.GetRelevantHierarchicInfos();
      gridView.BindingContext = dataGridView.BindingContext;
      gridView.DataSource = (object) dataGridView.GetClonedBindingSourceWithFilterForNextLevel(this);
      if (relevantHierarchicInfos.Count > 0)
      {
        this.mobjRelatedHierarchyInfo = relevantHierarchicInfos[0];
        this.EnsureColumnsVisibility((DataGridView) gridView, this.mobjRelatedHierarchyInfo);
        if (gridView.SystemHierarchicInfos.Count == 0)
          this.mobjRelatedHierarchyInfo.HiddenColumns.CollectionChanged += new NotifyCollectionChangedEventHandler(this.HiddenColumns_CollectionChanged);
      }
      return gridView;
    }

    /// <summary>
    /// Handles the CollectionChanged event of the HiddenColumns control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void HiddenColumns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => this.EnsureColumnsVisibility((DataGridView) this.mobjChildGrid, this.mobjRelatedHierarchyInfo);

    /// <summary>Creates the grid view.</summary>
    /// <returns></returns>
    private HierarchicDataGridView CreateGridView()
    {
      HierarchicDataGridView gridView = (HierarchicDataGridView) null;
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView != null)
      {
        Type childGridType = dataGridView.GetChildGridType(this);
        if (childGridType != (Type) null)
          gridView = Activator.CreateInstance(childGridType) as HierarchicDataGridView;
        if (gridView != null)
        {
          gridView.BorderStyle = BorderStyle.FixedSingle;
          gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          gridView.Dock = DockStyle.Fill;
          gridView.CustomStyle = dataGridView.CustomStyle;
          gridView.UseInternalPaging = dataGridView.UseInternalPaging;
          gridView.SupportGroupCount = dataGridView.SupportGroupCount;
          gridView.ExpansionIndicator = dataGridView.ExpansionIndicator;
        }
      }
      return gridView;
    }

    /// <summary>Sets the read only cell core.</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    /// <param name="blnReadOnly">if set to <c>true</c> [read only].</param>
    internal void SetReadOnlyCellCore(DataGridViewCell objDataGridViewCell, bool blnReadOnly)
    {
      if (this.ReadOnly && !blnReadOnly)
      {
        foreach (DataGridViewCell cell in (BaseCollection) this.Cells)
          cell.ReadOnlyInternal = true;
        objDataGridViewCell.ReadOnlyInternal = false;
        this.ReadOnly = false;
      }
      else
      {
        if (!(!this.ReadOnly & blnReadOnly))
          return;
        objDataGridViewCell.ReadOnlyInternal = true;
      }
    }

    /// <summary>Sets the values of the row's cells.</summary>
    /// <returns>true if all values have been set; otherwise, false.</returns>
    /// <param name="arrValues">One or more objects that represent the cell values in the row.-or-An <see cref="T:System.Array"></see> of <see cref="T:System.Object"></see> values. </param>
    /// <exception cref="T:System.ArgumentNullException">values is null. </exception>
    /// <exception cref="T:System.InvalidOperationException">This method is called when the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is operating in virtual mode. -or-This row is a shared row.</exception>
    /// <filterpriority>1</filterpriority>
    public bool SetValues(params object[] arrValues)
    {
      if (arrValues == null)
        throw new ArgumentNullException("values");
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView != null)
      {
        if (dataGridView.VirtualMode)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
        if (this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
      }
      return this.SetValuesInternal(arrValues);
    }

    /// <summary>Sets the values internal.</summary>
    /// <param name="arrValues">The values.</param>
    /// <returns></returns>
    internal bool SetValuesInternal(params object[] arrValues)
    {
      bool flag = true;
      DataGridViewCellCollection cells = this.Cells;
      int count = cells.Count;
      for (int index = 0; index < cells.Count && index != arrValues.Length; ++index)
      {
        if (!cells[index].SetValueInternal(this.Index, arrValues[index]))
          flag = false;
      }
      return flag && arrValues.Length <= count;
    }

    /// <summary>Gets a human-readable string that describes the row.</summary>
    /// <returns>A <see cref="T:System.String"></see> that describes this row.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(36);
      stringBuilder.Append("DataGridViewRow { Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      if (this.DataGridView == null)
        return;
      this.DataGridView.Update(true);
    }

    /// <summary>Updates only the parameters of this instance.</summary>
    protected override void UpdateParams()
    {
      base.UpdateParams();
      if (this.DataGridView == null)
        return;
      this.DataGridView.Update(true);
    }

    /// <summary>Updates the params.</summary>
    /// <param name="enmParams">The enm params.</param>
    protected internal override void UpdateParams(AttributeType enmParams)
    {
      base.UpdateParams(enmParams);
      if (this.DataGridView == null)
        return;
      this.DataGridView.Update(true);
    }

    /// <summary>Redraw only</summary>
    /// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
    public override void Update(bool blnRedrawOnly)
    {
      base.Update(blnRedrawOnly);
      if (this.DataGridView == null)
        return;
      this.DataGridView.Update(true);
    }

    /// <summary>Redraw only</summary>
    /// <param name="enmParams">The enm params.</param>
    internal override void Update(AttributeType enmParams)
    {
      base.Update(enmParams);
      if (this.DataGridView == null)
        return;
      this.DataGridView.Update(true);
    }

    /// <summary>Modifies an input row header border style according to the specified criteria.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the new border style used.</returns>
    /// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the row header border style.</param>
    /// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the row header border style to modify. </param>
    /// <param name="blnSingleVerticalBorderAdded">true to add a single vertical border to the result; otherwise, false. </param>
    /// <param name="blnIsLastVisibleRow">true if the row is the last row in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that has its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Visible"></see> property set to true; otherwise, false. </param>
    /// <param name="blnSingleHorizontalBorderAdded">true to add a single horizontal border to the result; otherwise, false. </param>
    /// <param name="blnIsFirstDisplayedRow">true if the row is the first row displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual DataGridViewAdvancedBorderStyle AdjustRowHeaderBorderStyle(
      DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput,
      DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder,
      bool blnSingleVerticalBorderAdded,
      bool blnSingleHorizontalBorderAdded,
      bool blnIsFirstDisplayedRow,
      bool blnIsLastVisibleRow)
    {
      return (DataGridViewAdvancedBorderStyle) null;
    }

    /// <summary>Builds the inherited row header cell style.</summary>
    /// <param name="objInheritedCellStyle">The inherited cell style.</param>
    private void BuildInheritedRowHeaderCellStyle(DataGridViewCellStyle objInheritedCellStyle)
    {
    }

    /// <summary>Builds the inherited row style.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objInheritedRowStyle">The inherited row style.</param>
    private void BuildInheritedRowStyle(int intRowIndex, DataGridViewCellStyle ObjInheritedRowStyle)
    {
    }

    /// <summary>Creates an exact copy of this row.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewRow objDataGridViewBand = !(type == DataGridViewRow.objRowType) ? (DataGridViewRow) Activator.CreateInstance(type) : new DataGridViewRow();
      if (objDataGridViewBand != null)
      {
        this.CloneInternal((DataGridViewBand) objDataGridViewBand);
        if (this.HasErrorText)
          objDataGridViewBand.ErrorText = this.ErrorTextInternal;
        if (this.HasHeaderCell)
          objDataGridViewBand.HeaderCell = (DataGridViewRowHeaderCell) this.HeaderCell.Clone();
        objDataGridViewBand.CloneCells(this);
      }
      return (object) objDataGridViewBand;
    }

    /// <summary>Clones the cells.</summary>
    /// <param name="objRowTemplate">The row template.</param>
    private void CloneCells(DataGridViewRow objRowTemplate)
    {
      int count = objRowTemplate.Cells.Count;
      if (count <= 0)
        return;
      DataGridViewCell[] dataGridViewCellArray = new DataGridViewCell[count];
      for (int index = 0; index < count; ++index)
      {
        DataGridViewCell dataGridViewCell = (DataGridViewCell) objRowTemplate.Cells[index].Clone();
        dataGridViewCellArray[index] = dataGridViewCell;
      }
      this.Cells.AddRange(dataGridViewCellArray);
    }

    /// <summary>Clears the existing cells and sets their template according to the supplied <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> template.</summary>
    /// <param name="objDataGridView">A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that acts as a template for cell styles. </param>
    /// <exception cref="T:System.InvalidOperationException">A row that already belongs to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was added. -or-A column that has no cell template was added.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridView is null. </exception>
    /// <filterpriority>1</filterpriority>
    public void CreateCells(DataGridView objDataGridView)
    {
    }

    /// <summary>Clears the existing cells and sets their template and values.</summary>
    /// <param name="objDataGridView">A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that acts as a template for cell styles. </param>
    /// <param name="arrValues">An array of objects that initialize the reset cells. </param>
    /// <exception cref="T:System.ArgumentNullException">Either of the parameters is null. </exception>
    /// <exception cref="T:System.InvalidOperationException">A row that already belongs to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was added. -or-A column that has no cell template was added.</exception>
    /// <filterpriority>1</filterpriority>
    public void CreateCells(DataGridView objDataGridView, params object[] arrValues)
    {
    }

    /// <summary>Constructs a new collection of cells based on this row.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual DataGridViewCellCollection CreateCellsInstance() => new DataGridViewCellCollection(this);

    /// <summary>Detaches from data grid view.</summary>
    internal void DetachFromDataGridView()
    {
      if (this.DataGridView == null)
        return;
      this.DataGridViewInternal = (DataGridView) null;
      this.IndexInternal = -1;
      if (this.HasHeaderCell)
        this.HeaderCell.DataGridViewInternal = (DataGridView) null;
      foreach (DataGridViewCell cell in (BaseCollection) this.Cells)
      {
        cell.DataGridViewInternal = (DataGridView) null;
        if (cell.Selected)
          cell.SelectedInternal = false;
      }
      if (!this.Selected)
        return;
      this.SelectedInternal = false;
    }

    /// <summary>Draws a focus rectangle around the specified bounds.</summary>
    /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> used to paint the focus rectangle.</param>
    /// <param name="enmRowState">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that specifies the state of the row.</param>
    /// <param name="objBounds">A <see cref="T:System.Drawing.Rectangle"></see> that contains the bounds of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that is being painted.</param>
    /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to paint the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
    /// <param name="intRowIndex">The row index of the cell that is being painted.</param>
    /// <param name="objClipBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that needs to be painted.</param>
    /// <param name="blnCellsPaintSelectionBackground">true to use the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.SelectionBackColor"></see> property of cellStyle as the color of the focus rectangle; false to use the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.BackColor"></see> property of cellStyle as the color of the focus rectangle.</param>
    /// <exception cref="T:System.InvalidOperationException">The row has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    /// <exception cref="T:System.ArgumentNullException">graphics is null.-or-cellStyle is null.</exception>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected internal virtual void DrawFocus(
      Graphics objGraphics,
      Rectangle objClipBounds,
      Rectangle objBounds,
      int intRowIndex,
      DataGridViewElementStates enmRowState,
      DataGridViewCellStyle objCellStyle,
      bool blnCellsPaintSelectionBackground)
    {
    }

    /// <summary>Gets the displayed.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool GetDisplayed(int intRowIndex) => (this.GetState(intRowIndex) & DataGridViewElementStates.Displayed) != 0;

    /// <summary>Gets the error text for the row at the specified index.</summary>
    /// <returns>A string that describes the error of the row at the specified index.</returns>
    /// <param name="intRowIndex">The index of the row that contains the error.</param>
    /// <exception cref="T:System.InvalidOperationException">The row belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is less than zero or greater than the number of rows in the control minus one. </exception>
    public string GetErrorText(int intRowIndex)
    {
      string strErrorText = this.ErrorTextInternal;
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        return strErrorText;
      if (intRowIndex == -1)
        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
      if (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      if (CommonUtils.IsNullOrEmpty(strErrorText) && dataGridView.DataSource != null && intRowIndex != dataGridView.NewRowIndex)
        strErrorText = dataGridView.DataConnection.GetError(intRowIndex);
      return dataGridView.DataSource == null && !dataGridView.VirtualMode ? strErrorText : dataGridView.OnRowErrorTextNeeded(intRowIndex, strErrorText);
    }

    /// <summary>Gets the frozen.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool GetFrozen(int intRowIndex) => (this.GetState(intRowIndex) & DataGridViewElementStates.Frozen) != 0;

    /// <summary>Gets the event integer attribute value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="strAttribute">The attribute name.</param>
    /// <param name="intDefault">The default integer value.</param>
    /// <returns></returns>
    protected new int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
    {
      string s = objEvent[strAttribute];
      return CommonUtils.IsNullOrEmpty(s) ? intDefault : int.Parse(s);
    }

    /// <summary>Gets the height.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal int GetHeight(int intRowIndex)
    {
      int intHeight;
      this.GetHeightInfo(intRowIndex, out intHeight, out int _);
      return intHeight;
    }

    /// <summary>Gets the minimum height.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal int GetMinimumHeight(int intRowIndex)
    {
      int intMinimumHeight;
      this.GetHeightInfo(intRowIndex, out int _, out intMinimumHeight);
      return intMinimumHeight;
    }

    /// <summary>Calculates the ideal height of the specified row based on the specified criteria.</summary>
    /// <returns>The ideal height of the row, in pixels.</returns>
    /// <param name="enmAutoSizeRowMode">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> that specifies an automatic sizing mode.</param>
    /// <param name="intRowIndex">The index of the row whose preferred height is calculated.</param>
    /// <param name="blnFixedWidth">true to calculate the preferred height for a fixed cell width; otherwise, false.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The rowIndex is not in the valid range of 0 to the number of rows in the control minus 1. </exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
    public virtual int GetPreferredHeight(
      int intRowIndex,
      DataGridViewAutoSizeRowMode enmAutoSizeRowMode,
      bool blnFixedWidth)
    {
      DataGridView dataGridView = this.DataGridView;
      if ((enmAutoSizeRowMode & ~DataGridViewAutoSizeRowMode.AllCells) != (DataGridViewAutoSizeRowMode) 0)
        throw new InvalidEnumArgumentException("autoSizeRowMode", (int) enmAutoSizeRowMode, typeof (DataGridViewAutoSizeRowMode));
      if (dataGridView != null && (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count))
        throw new ArgumentOutOfRangeException("rowIndex");
      if (dataGridView == null)
        return -1;
      int val1_1 = 0;
      Size preferredSize;
      if (dataGridView.RowHeadersVisible && (enmAutoSizeRowMode & DataGridViewAutoSizeRowMode.RowHeader) != (DataGridViewAutoSizeRowMode) 0)
      {
        if (blnFixedWidth || dataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || dataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.DisableResizing)
        {
          val1_1 = Math.Max(val1_1, this.HeaderCell.GetPreferredHeight(intRowIndex, dataGridView.RowHeadersWidth));
        }
        else
        {
          int val1_2 = val1_1;
          preferredSize = this.HeaderCell.GetPreferredSize(intRowIndex);
          int height = preferredSize.Height;
          val1_1 = Math.Max(val1_2, height);
        }
      }
      if ((enmAutoSizeRowMode & DataGridViewAutoSizeRowMode.AllCellsExceptHeader) != (DataGridViewAutoSizeRowMode) 0)
      {
        foreach (DataGridViewCell cell in (BaseCollection) this.Cells)
        {
          DataGridViewColumn column = dataGridView.Columns[cell.ColumnIndex];
          if (column.Visible)
          {
            int num;
            if (blnFixedWidth || (column.InheritedAutoSizeMode & (DataGridViewAutoSizeColumnMode.AllCellsExceptHeader | DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader)) == DataGridViewAutoSizeColumnMode.NotSet)
            {
              num = cell.GetPreferredHeight(intRowIndex, column.Width);
            }
            else
            {
              preferredSize = cell.GetPreferredSize(intRowIndex);
              num = preferredSize.Height;
            }
            if (val1_1 < num)
              val1_1 = num;
          }
        }
      }
      return val1_1;
    }

    /// <summary>Gets the read only.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool GetReadOnly(int intRowIndex)
    {
      if ((this.GetState(intRowIndex) & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
        return true;
      DataGridView dataGridView = this.DataGridView;
      return dataGridView != null && dataGridView.ReadOnly;
    }

    /// <summary>Gets the resizable.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal DataGridViewTriState GetResizable(int intRowIndex)
    {
      if ((this.GetState(intRowIndex) & DataGridViewElementStates.ResizableSet) != DataGridViewElementStates.None)
        return (this.GetState(intRowIndex) & DataGridViewElementStates.Resizable) == DataGridViewElementStates.None ? DataGridViewTriState.False : DataGridViewTriState.True;
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        return DataGridViewTriState.NotSet;
      return !dataGridView.AllowUserToResizeRows ? DataGridViewTriState.False : DataGridViewTriState.True;
    }

    /// <summary>Gets the selected.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool GetSelected(int intRowIndex) => (this.GetState(intRowIndex) & DataGridViewElementStates.Selected) != 0;

    /// <summary>Returns a value indicating the current state of the row.</summary>
    /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the row state.</returns>
    /// <param name="intRowIndex">The index of the row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row has been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, but the rowIndex value is not in the valid range of 0 to the number of rows in the control minus 1.</exception>
    /// <exception cref="T:System.ArgumentException">The row is not a shared row, but the rowIndex value does not match the row's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Index"></see> property value.-or-The row has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, but the rowIndex value does not match the row's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Index"></see> property value.</exception>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual DataGridViewElementStates GetState(int intRowIndex)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView != null)
      {
        DataGridViewRowCollection rows = dataGridView.Rows;
        if (intRowIndex < 0 || intRowIndex >= rows.Count)
          throw new ArgumentOutOfRangeException("rowIndex");
        if (rows.SharedRow(intRowIndex).Index == -1)
          return rows.GetRowState(intRowIndex);
      }
      if (intRowIndex != this.Index)
        throw new ArgumentException(SR.GetString("InvalidArgument", (object) "rowIndex", (object) intRowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      return base.State;
    }

    /// <summary>Gets the visible.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool GetVisible(int intRowIndex) => (this.GetState(intRowIndex) & DataGridViewElementStates.Visible) != 0;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow" /> is expanded.
    /// </summary>
    /// <value>
    ///   <c>true</c> if expanded; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool Expanded
    {
      get => this.mblnIsExpanded;
      set
      {
        if (value)
          this.Expand();
        else
          this.Collapse();
      }
    }

    /// <summary>Gets the child grid.</summary>
    /// <value>The child grid.</value>
    public HierarchicDataGridView ChildGrid
    {
      get
      {
        if (this.mobjChildGrid == null && this.ContainedInBindedHierarchicGrid && !this.IsNewRow)
          this.mobjChildGrid = this.CreateAndBindChildDataGrid();
        return this.mobjChildGrid;
      }
    }

    /// <summary>Gets the related hierarchy info.</summary>
    internal HierarchicInfo RelatedHierarchyInfo => this.mobjRelatedHierarchyInfo;

    /// <summary>Gets the member ID.</summary>
    /// <value>The member ID.</value>
    protected override string MemberID => "R" + (this.IsFilterRow ? 0 : this.Index + (this.DataGridView.ShowFilterRow ? 1 : 0)).ToString();

    /// <summary>Gets or sets the style.</summary>
    /// <value>The style.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public DataGridViewRowStyle Style => this.mobjStyle;

    /// <summary>
    /// This is a recursive function that loop through a control and all of its parents
    /// cheching if one of the controls(and control containers) is hidden or
    /// disabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
    /// </value>
    /// <returns>false if one of the controls is hidden or disabled.</returns>
    public override bool IsEventsEnabled => this.Visible && base.IsEventsEnabled;

    /// <summary>Gets the collection of cells that populate the row.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> that contains all of the cells in the row.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DataGridViewCellCollection Cells
    {
      get
      {
        if (this.mobjCells == null)
          this.mobjCells = this.CreateCellsInstance();
        return this.mobjCells;
      }
    }

    /// <summary>Gets the data-bound object that populated the row.</summary>
    /// <returns>The data-bound <see cref="T:System.Object"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public object DataBoundItem
    {
      get
      {
        DataGridView dataGridView = this.DataGridView;
        return dataGridView != null && dataGridView.DataConnection != null && this.Index > -1 && this.Index != dataGridView.NewRowIndex ? dataGridView.DataConnection.CurrencyManager[this.Index] : (object) null;
      }
    }

    /// <summary>Gets or sets the default styles for the row, which are used to render cells in the row unless the styles are overridden. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(true)]
    [SRDescription("DataGridView_RowDefaultCellStyleDescr")]
    [NotifyParentProperty(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatAppearance")]
    public override DataGridViewCellStyle DefaultCellStyle
    {
      get => base.DefaultCellStyle;
      set
      {
        if (this.DataGridView != null && this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (DefaultCellStyle)));
        base.DefaultCellStyle = value;
      }
    }

    /// <summary>Gets a value indicating whether this row is displayed on the screen.</summary>
    /// <returns>true if the row is currently displayed on the screen; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    [Browsable(false)]
    public override bool Displayed => this.DataGridView == null || this.Index != -1 ? this.GetDisplayed(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (Displayed)));

    /// <summary>Gets or sets the height, in pixels, of the row divider.</summary>
    /// <returns>The height, in pixels, of the divider (the row's bottom margin). </returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    [NotifyParentProperty(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_RowDividerHeightDescr")]
    [DefaultValue(0)]
    public int DividerHeight
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets the error message text for row-level errors.</summary>
    /// <returns>A <see cref="T:System.String"></see> containing the error message.</returns>
    /// <exception cref="T:System.InvalidOperationException">When getting the value of this property, the row is a shared row in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    /// <filterpriority>1</filterpriority>
    [NotifyParentProperty(true)]
    [SRCategory("CatAppearance")]
    [DefaultValue("")]
    [SRDescription("DataGridView_RowErrorTextDescr")]
    public string ErrorText
    {
      get => this.GetErrorText(this.Index);
      set => this.ErrorTextInternal = value;
    }

    /// <summary>Gets or sets the error text internal.</summary>
    /// <value>The error text internal.</value>
    private string ErrorTextInternal
    {
      get => this.mstrErrorText != null ? this.mstrErrorText : string.Empty;
      set
      {
        string errorTextInternal = this.ErrorTextInternal;
        string mstrErrorText = this.mstrErrorText;
        DataGridView dataGridView = this.DataGridView;
        if ((!CommonUtils.IsNullOrEmpty(value) || mstrErrorText != null) && mstrErrorText != value)
        {
          this.mstrErrorText = value;
          if (dataGridView != null)
          {
            dataGridView.FocusInternal();
            dataGridView.Update();
          }
        }
        if (dataGridView == null || errorTextInternal.Equals(this.ErrorTextInternal))
          return;
        dataGridView.OnRowErrorTextChanged(this);
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is frozen. </summary>
    /// <returns>true if the row is frozen; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public override bool Frozen
    {
      get => this.DataGridView == null || this.Index != -1 ? this.GetFrozen(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (Frozen)));
      set
      {
        if (this.DataGridView != null && this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (Frozen)));
        base.Frozen = value;
      }
    }

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
          IList pageRows = this.DataGridView.PageRows;
          if (pageRows.Count > 0)
          {
            foreach (DataGridViewRow dataGridViewRow in (IEnumerable) pageRows)
            {
              if (dataGridViewRow != this)
              {
                if (dataGridViewRow.Visible)
                  empty.Y += dataGridViewRow.Height;
              }
              else
                break;
            }
          }
          empty.Y -= this.DataGridView.ScrollPoisition.Y;
        }
        return empty;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has error text.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has error text; otherwise, <c>false</c>.
    /// </value>
    internal bool HasErrorText
    {
      get
      {
        string mstrErrorText = this.mstrErrorText;
        return mstrErrorText != null && mstrErrorText != string.Empty;
      }
    }

    /// <summary>Gets or sets the row's header cell.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> that represents the header cell of row.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridViewRowHeaderCell HeaderCell
    {
      get => (DataGridViewRowHeaderCell) this.HeaderCellCore;
      set => this.HeaderCellCore = (DataGridViewHeaderCell) value;
    }

    /// <summary>Gets or sets the current height of the row.</summary>
    /// <returns>The height, in pixels, of the row. The default is the height of the default font plus 9 pixels.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [NotifyParentProperty(true)]
    [SRDescription("DataGridView_RowHeightDescr")]
    [DefaultValue(22)]
    public int Height
    {
      get => this.Thickness;
      set
      {
        if (this.DataGridView != null && this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (Height)));
        this.Thickness = value;
      }
    }

    /// <summary>Gets the cell style in effect for the row.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that specifies the formatting and style information for the cells in the row.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    public override DataGridViewCellStyle InheritedStyle
    {
      get
      {
        if (this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (InheritedStyle)));
        DataGridViewCellStyle ObjInheritedRowStyle = new DataGridViewCellStyle();
        this.BuildInheritedRowStyle(this.Index, ObjInheritedRowStyle);
        return ObjInheritedRowStyle;
      }
    }

    /// <summary>Gets a value indicating whether the row is the row for new records.</summary>
    /// <returns>true if the row is the last row in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>,
    /// which is used for the entry of a new row of data; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsNewRow
    {
      get
      {
        DataGridView dataGridView = this.DataGridView;
        return dataGridView != null && dataGridView.NewRowIndex == this.Index;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is filter row.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is filter row; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool IsFilterRow => false;

    /// <summary>Gets or sets the minimum height of the row.</summary>
    /// <returns>The minimum row height in pixels, ranging from 2 to <see cref="F:System.Int32.MaxValue"></see>. The default is 3.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 2.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int MinimumHeight
    {
      get => this.MinimumThickness;
      set
      {
        if (this.DataGridView != null && this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (MinimumHeight)));
        this.MinimumThickness = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the row is read-only.</summary>
    /// <returns>true if the row is read-only; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <filterpriority>1</filterpriority>
    [NotifyParentProperty(true)]
    [SRDescription("DataGridView_RowReadOnlyDescr")]
    [DefaultValue(false)]
    [Browsable(true)]
    [SRCategory("CatBehavior")]
    public override bool ReadOnly
    {
      get => this.DataGridView == null || this.Index != -1 ? this.GetReadOnly(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (ReadOnly)));
      set
      {
        if (value != this.ReadOnly && this.DataGridView != null)
          this.DataGridView.Update();
        base.ReadOnly = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether users can resize the row or indicating that the behavior is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value that indicates whether the row can be resized or whether it can be resized only when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property is set to true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    [SRDescription("DataGridView_RowResizableDescr")]
    [SRCategory("CatBehavior")]
    [NotifyParentProperty(true)]
    [DefaultValue(DataGridViewTriState.NotSet)]
    public override DataGridViewTriState Resizable
    {
      get => this.DataGridView == null || this.Index != -1 ? this.GetResizable(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (Resizable)));
      set => base.Resizable = value;
    }

    /// <summary>Gets or sets a value indicating whether the row is selected. </summary>
    /// <returns>true if the row is selected; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    public override bool Selected
    {
      get => this.DataGridView == null || this.Index != -1 ? this.GetSelected(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (Selected)));
      set => base.Selected = value;
    }

    /// <summary>Gets the current state of the row.</summary>
    /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the row state.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    public override DataGridViewElementStates State => this.DataGridView == null || this.Index != -1 ? this.GetState(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (State)));

    /// <summary>Gets or sets a value indicating whether the row is visible. </summary>
    /// <returns>true if the row is visible; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public override bool Visible
    {
      get => this.DataGridView == null || this.Index != -1 ? this.GetVisible(this.Index) : throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", (object) nameof (Visible)));
      set
      {
        if (this.DataGridView != null && this.Index == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", (object) nameof (Visible)));
        base.Visible = value;
      }
    }

    /// <summary>Gets or sets the shortcut menu for the row.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the current <see cref="T:System.Windows.Forms.DataGridViewRow"></see>. The default is null.</returns>
    /// <exception cref="T:System.InvalidOperationException">When getting the value of this property, the row is in a <see cref="T:System.Windows.Forms.DataGridView"></see> control and is a shared row.</exception>
    [SRDescription("DataGridView_RowContextMenuStripDescr")]
    [DefaultValue(null)]
    [SRCategory("CatBehavior")]
    public override ContextMenu ContextMenu
    {
      get => base.ContextMenu;
      set => base.ContextMenu = value;
    }

    /// <summary>Gets the shortcut menu for the row.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> that belongs to the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index.</returns>
    /// <param name="intRowIndex">The index of the current row.</param>
    /// <exception cref="T:System.InvalidOperationException">rowIndex is -1.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than or equal to the number of rows in the control minus one.</exception>
    public ContextMenu GetContextMenu(int intRowIndex)
    {
      ContextMenu contextMenuInternal = this.ContextMenuInternal;
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        return contextMenuInternal;
      if (intRowIndex == -1)
        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
      if (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      return !dataGridView.VirtualMode && dataGridView.DataSource == null ? contextMenuInternal : dataGridView.OnRowContextMenuNeeded(intRowIndex, contextMenuInternal);
    }

    /// <summary>Gets the context menu strip.</summary>
    /// <param name="rowIndex">Index of the row.</param>
    /// <returns></returns>
    public ContextMenuStrip GetContextMenuStrip(int rowIndex)
    {
      ContextMenuStrip menuStripInternal = this.ContextMenuStripInternal;
      if (this.DataGridView == null)
        return menuStripInternal;
      if (rowIndex == -1)
        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
      if (rowIndex < 0 || rowIndex >= this.DataGridView.Rows.Count)
        throw new ArgumentOutOfRangeException(nameof (rowIndex));
      return !this.DataGridView.VirtualMode && this.DataGridView.DataSource == null ? menuStripInternal : this.DataGridView.OnRowContextMenuStripNeeded(rowIndex, menuStripInternal);
    }

    /// <summary>
    /// Gets a value indicating whether [contained in hierarchic grid].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [contained in hierarchic grid]; otherwise, <c>false</c>.
    /// </value>
    public bool ContainedInBindedHierarchicGrid => this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded);

    /// <summary>
    /// Gets a value indicating whether this instance is hierarchic.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is hierarchic; otherwise, <c>false</c>.
    /// </value>
    public bool IsHierarchic => this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any);
  }
}
