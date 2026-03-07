// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  /// <filterpriority>2</filterpriority>
  [ListBindable(false)]
  [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewColumnCollection : BaseCollection, IList, ICollection, IEnumerable
  {
    private int mintColumnCountsVisible;
    private int mintColumnCountsVisibleSelected;
    private static DataGridViewColumnCollection.ColumnOrderComparer mobjColumnOrderComparer = new DataGridViewColumnCollection.ColumnOrderComparer();
    private int mintColumnsWidthVisible;
    private int mintColumnsWidthVisibleFrozen;
    private DataGridView mobjDataGridView;
    private ArrayList marrItems;
    private ArrayList marrItemsSorted;
    private int mintLastAccessedSortedIndex;

    /// <summary>Occurs when the collection changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event CollectionChangeEventHandler CollectionChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> class for the given <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <param name="objDataGridView">The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that created this collection.</param>
    public DataGridViewColumnCollection(DataGridView objDataGridView)
    {
      this.marrItems = new ArrayList();
      this.mintLastAccessedSortedIndex = -1;
      this.InvalidateCachedColumnCounts();
      this.InvalidateCachedColumnsWidths();
      this.mobjDataGridView = objDataGridView;
    }

    internal int ActualDisplayIndexToColumnIndex(
      int intActualDisplayIndex,
      DataGridViewElementStates enmIncludeFilter)
    {
      DataGridViewColumn objDataGridViewColumnStart = this.GetFirstColumn(enmIncludeFilter);
      for (int index = 0; index < intActualDisplayIndex; ++index)
        objDataGridViewColumnStart = this.GetNextColumn(objDataGridViewColumnStart, enmIncludeFilter, DataGridViewElementStates.None);
      return objDataGridViewColumnStart.Index;
    }

    /// <summary>Adds the given column to the collection.</summary>
    /// <returns>The index of the column.</returns>
    /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to add.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewColumn already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>.
    /// Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-dataGridViewColumn has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property value that would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.-or-dataGridViewColumn has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row and dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual int Add(DataGridViewColumn objDataGridViewColumn)
    {
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.InDisplayIndexAdjustments)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
      if (objDataGridViewColumn == null)
        throw new ArgumentNullException(nameof (objDataGridViewColumn));
      if (objDataGridViewColumn.Frozen && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
        throw new Exception("DataGridView does not support hierarchies with frozen columns");
      this.DataGridView.OnAddingColumn(objDataGridViewColumn);
      this.InvalidateCachedColumnsOrder();
      int num = this.marrItems.Add((object) objDataGridViewColumn);
      objDataGridViewColumn.IndexInternal = num;
      objDataGridViewColumn.DataGridViewInternal = this.mobjDataGridView;
      this.UpdateColumnCaches(objDataGridViewColumn, true);
      this.DataGridView.OnAddedColumn(objDataGridViewColumn);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewColumn), false, new Point(-1, -1));
      return num;
    }

    /// <summary>Adds a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn"></see> with the given column name and column header text to the collection.</summary>
    /// <returns>The index of the column.</returns>
    /// <param name="strHeaderText">The text for the column's header.</param>
    /// <param name="strColumnName">The name by which the column will be referred.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>, which conflicts with the default column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see>.-or-The default column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property value of 100 would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int Add(string strColumnName, string strHeaderText)
    {
      DataGridViewColumn viewDefaultColumn = this.DataGridView.GetDataGridViewDefaultColumn();
      viewDefaultColumn.Name = strColumnName;
      viewDefaultColumn.HeaderText = strHeaderText;
      return this.Add(viewDefaultColumn);
    }

    /// <summary>Adds a range of columns to the collection. </summary>
    /// <param name="arrDataGridViewColumns">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects to add.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumns is null.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-At least one of the values in dataGridViewColumns is null.-or-At least one of the columns in dataGridViewColumns already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-At least one of the columns in dataGridViewColumns has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row.-or-At least one of the columns in dataGridViewColumns has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>.
    /// Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-At least one of the columns in dataGridViewColumns has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-At least one of the columns in dataGridViewColumns has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-The columns in dataGridViewColumns have <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values that would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.-or-At least two of the values in dataGridViewColumns are references to the same <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.-or-At least one of the columns in dataGridViewColumns has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void AddRange(params DataGridViewColumn[] arrDataGridViewColumns)
    {
      if (arrDataGridViewColumns == null)
        throw new ArgumentNullException("dataGridViewColumns");
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.InDisplayIndexAdjustments)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
      ArrayList arrayList1 = new ArrayList(arrDataGridViewColumns.Length);
      ArrayList arrayList2 = new ArrayList(arrDataGridViewColumns.Length);
      foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
      {
        if (dataGridViewColumn.DisplayIndex != -1)
          arrayList1.Add((object) dataGridViewColumn);
      }
      while (arrayList1.Count > 0)
      {
        int num = int.MaxValue;
        int index1 = -1;
        for (int index2 = 0; index2 < arrayList1.Count; ++index2)
        {
          DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) arrayList1[index2];
          if (dataGridViewColumn.DisplayIndex < num)
          {
            num = dataGridViewColumn.DisplayIndex;
            index1 = index2;
          }
        }
        arrayList2.Add(arrayList1[index1]);
        arrayList1.RemoveAt(index1);
      }
      foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
      {
        if (dataGridViewColumn.DisplayIndex == -1)
          arrayList2.Add((object) dataGridViewColumn);
      }
      int index = 0;
      foreach (DataGridViewColumn dataGridViewColumn in arrayList2)
      {
        arrDataGridViewColumns[index] = dataGridViewColumn;
        ++index;
      }
      this.DataGridView.OnAddingColumns(arrDataGridViewColumns);
      foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
      {
        this.InvalidateCachedColumnsOrder();
        int num = this.marrItems.Add((object) dataGridViewColumn);
        dataGridViewColumn.IndexInternal = num;
        dataGridViewColumn.DataGridViewInternal = this.mobjDataGridView;
        this.UpdateColumnCaches(dataGridViewColumn, true);
        this.DataGridView.OnAddedColumn(dataGridViewColumn);
      }
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), false, new Point(-1, -1));
    }

    /// <summary>Clears the collection. </summary>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Clear()
    {
      if (this.Count <= 0)
        return;
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.InDisplayIndexAdjustments)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
      for (int index = 0; index < this.Count; ++index)
      {
        DataGridViewColumn dataGridViewColumn = this[index];
        dataGridViewColumn.DataGridViewInternal = (DataGridView) null;
        if (dataGridViewColumn.HasHeaderCell)
          dataGridViewColumn.HeaderCell.DataGridViewInternal = (DataGridView) null;
      }
      DataGridViewColumn[] arrColumns = new DataGridViewColumn[this.marrItems.Count];
      this.CopyTo(arrColumns, 0);
      this.DataGridView.OnClearingColumns();
      this.InvalidateCachedColumnsOrder();
      this.marrItems.Clear();
      this.InvalidateCachedColumnCounts();
      this.InvalidateCachedColumnsWidths();
      foreach (DataGridViewColumn objDataGridViewColumn in arrColumns)
      {
        this.DataGridView.OnColumnRemoved(objDataGridViewColumn);
        this.DataGridView.OnColumnHidden(objDataGridViewColumn);
      }
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), false, new Point(-1, -1));
    }

    internal int ColumnIndexToActualDisplayIndex(
      int intColumnIndex,
      DataGridViewElementStates enmIncludeFilter)
    {
      DataGridViewColumn objDataGridViewColumnStart = this.GetFirstColumn(enmIncludeFilter);
      int actualDisplayIndex = 0;
      while (objDataGridViewColumnStart != null && objDataGridViewColumnStart.Index != intColumnIndex)
      {
        objDataGridViewColumnStart = this.GetNextColumn(objDataGridViewColumnStart, enmIncludeFilter, DataGridViewElementStates.None);
        ++actualDisplayIndex;
      }
      return actualDisplayIndex;
    }

    /// <summary>
    /// Creates the real data member from the proposed member.
    /// </summary>
    /// <param name="strFilteringDataMember">The STR filtering data member.</param>
    internal string GetRealDataMemberForProposedMember(string strFilteringDataMember)
    {
      foreach (DataGridViewColumn dataGridViewColumn in (BaseCollection) this)
      {
        if (dataGridViewColumn.Name == strFilteringDataMember || dataGridViewColumn.DataPropertyName == strFilteringDataMember)
          return dataGridViewColumn.Name;
      }
      return (string) null;
    }

    /// <summary>Determines whether the collection contains the column referred to by the given name. </summary>
    /// <returns>true if the column is contained in the collection; otherwise, false.</returns>
    /// <param name="strColumnName">The name of the column to look for.</param>
    /// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual bool Contains(string strColumnName)
    {
      if (strColumnName == null)
        throw new ArgumentNullException("columnName");
      int count = this.marrItems.Count;
      for (int index = 0; index < count; ++index)
      {
        if (string.Compare(((DataGridViewColumn) this.marrItems[index]).Name, strColumnName, true, CultureInfo.InvariantCulture) == 0)
          return true;
      }
      return false;
    }

    /// <summary>Determines whether the collection contains the given column.</summary>
    /// <returns>true if the given column is in the collection; otherwise, false.</returns>
    /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to look for.</param>
    /// <filterpriority>1</filterpriority>
    public virtual bool Contains(DataGridViewColumn objDataGridViewColumn) => this.marrItems.IndexOf((object) objDataGridViewColumn) != -1;

    /// <summary>Copies the items from the collection to the given array.</summary>
    /// <param name="arrColumns">The destination <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> array.</param>
    /// <param name="index">The index of the destination array at which to start copying.</param>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(DataGridViewColumn[] arrColumns, int index) => this.marrItems.CopyTo((Array) arrColumns, index);

    internal bool DisplayInOrder(int intColumnIndex1, int intColumnIndex2) => ((DataGridViewColumn) this.marrItems[intColumnIndex1]).DisplayIndex < ((DataGridViewColumn) this.marrItems[intColumnIndex2]).DisplayIndex;

    internal DataGridViewColumn GetColumnAtDisplayIndex(int intDisplayIndex)
    {
      if (intDisplayIndex >= 0 && intDisplayIndex < this.marrItems.Count)
      {
        DataGridViewColumn marrItem1 = (DataGridViewColumn) this.marrItems[intDisplayIndex];
        if (marrItem1.DisplayIndex == intDisplayIndex)
          return marrItem1;
        for (int index = 0; index < this.marrItems.Count; ++index)
        {
          DataGridViewColumn marrItem2 = (DataGridViewColumn) this.marrItems[index];
          if (marrItem2.DisplayIndex == intDisplayIndex)
            return marrItem2;
        }
      }
      return (DataGridViewColumn) null;
    }

    /// <summary>Returns the number of columns that meet the given filter requirements.</summary>
    /// <returns>The number of columns that meet the filter requirements.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter for inclusion.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetColumnCount(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintColumnCountsVisible != -1)
            return this.mintColumnCountsVisible;
          break;
        case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
          if (this.mintColumnCountsVisibleSelected != -1)
            return this.mintColumnCountsVisibleSelected;
          break;
      }
      int columnCount = 0;
      if ((enmIncludeFilter & DataGridViewElementStates.Resizable) == DataGridViewElementStates.None)
      {
        for (int index = 0; index < this.marrItems.Count; ++index)
        {
          if (((DataGridViewElement) this.marrItems[index]).StateIncludes(enmIncludeFilter))
            ++columnCount;
        }
        switch (enmIncludeFilter)
        {
          case DataGridViewElementStates.Visible:
            this.mintColumnCountsVisible = columnCount;
            return columnCount;
          case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
            this.mintColumnCountsVisibleSelected = columnCount;
            return columnCount;
          default:
            return columnCount;
        }
      }
      else
      {
        DataGridViewElementStates elementState = enmIncludeFilter & ~DataGridViewElementStates.Resizable;
        for (int index = 0; index < this.marrItems.Count; ++index)
        {
          if (((DataGridViewElement) this.marrItems[index]).StateIncludes(elementState) && ((DataGridViewBand) this.marrItems[index]).Resizable == DataGridViewTriState.True)
            ++columnCount;
        }
        return columnCount;
      }
    }

    internal int GetColumnCount(
      DataGridViewElementStates enmIncludeFilter,
      int intFromColumnIndex,
      int toColumnIndex)
    {
      int columnCount = 0;
      DataGridViewColumn objDataGridViewColumnStart = (DataGridViewColumn) this.marrItems[intFromColumnIndex];
      while (objDataGridViewColumnStart != (DataGridViewColumn) this.marrItems[toColumnIndex])
      {
        objDataGridViewColumnStart = this.GetNextColumn(objDataGridViewColumnStart, enmIncludeFilter, DataGridViewElementStates.None);
        if (objDataGridViewColumnStart.StateIncludes(enmIncludeFilter))
          ++columnCount;
      }
      return columnCount;
    }

    internal float GetColumnsFillWeight(DataGridViewElementStates enmIncludeFilter)
    {
      float columnsFillWeight = 0.0f;
      for (int index = 0; index < this.marrItems.Count; ++index)
      {
        if (((DataGridViewElement) this.marrItems[index]).StateIncludes(enmIncludeFilter))
          columnsFillWeight += ((DataGridViewColumn) this.marrItems[index]).FillWeight;
      }
      return columnsFillWeight;
    }

    private int GetColumnSortedIndex(DataGridViewColumn objDataGridViewColumn)
    {
      if (this.mintLastAccessedSortedIndex != -1 && this.marrItemsSorted[this.mintLastAccessedSortedIndex] == objDataGridViewColumn)
        return this.mintLastAccessedSortedIndex;
      for (int index = 0; index < this.marrItemsSorted.Count; ++index)
      {
        if (objDataGridViewColumn.Index == ((DataGridViewBand) this.marrItemsSorted[index]).Index)
        {
          this.mintLastAccessedSortedIndex = index;
          return index;
        }
      }
      return -1;
    }

    /// <summary>Returns the width, in pixels, required to display all of the columns that meet the given filter requirements. </summary>
    /// <returns>The width, in pixels, that is necessary to display all of the columns that meet the filter requirements.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter for inclusion.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetColumnsWidth(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintColumnsWidthVisible != -1)
            return this.mintColumnsWidthVisible;
          break;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          if (this.mintColumnsWidthVisibleFrozen != -1)
            return this.mintColumnsWidthVisibleFrozen;
          break;
      }
      int columnsWidth = 0;
      for (int index = 0; index < this.List.Count; ++index)
      {
        if (((DataGridViewElement) this.List[index]).StateIncludes(enmIncludeFilter))
          columnsWidth += ((DataGridViewBand) this.List[index]).Thickness;
      }
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          this.mintColumnsWidthVisible = columnsWidth;
          return columnsWidth;
        case DataGridViewElementStates.Displayed | DataGridViewElementStates.Visible:
          return columnsWidth;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          this.mintColumnsWidthVisibleFrozen = columnsWidth;
          return columnsWidth;
        default:
          return columnsWidth;
      }
    }

    /// <summary>Returns the first column in display order that meets the given inclusion-filter requirements.</summary>
    /// <returns>The first column in display order that meets the given filter requirements, or null if no column is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represents the filter for inclusion.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public DataGridViewColumn GetFirstColumn(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if (this.marrItemsSorted == null)
        this.UpdateColumnOrderCache();
      for (int index = 0; index < this.marrItemsSorted.Count; ++index)
      {
        DataGridViewColumn firstColumn = (DataGridViewColumn) this.marrItemsSorted[index];
        if (firstColumn.StateIncludes(enmIncludeFilter))
        {
          this.mintLastAccessedSortedIndex = index;
          return firstColumn;
        }
      }
      return (DataGridViewColumn) null;
    }

    /// <summary>Returns the first column in display order that meets the given inclusion-filter and exclusion-filter requirements. </summary>
    /// <returns>The first column in display order that meets the given filter requirements, or null if no column is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
    /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public DataGridViewColumn GetFirstColumn(
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if (enmExcludeFilter == DataGridViewElementStates.None)
        return this.GetFirstColumn(enmIncludeFilter);
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      if (this.marrItemsSorted == null)
        this.UpdateColumnOrderCache();
      for (int index = 0; index < this.marrItemsSorted.Count; ++index)
      {
        DataGridViewColumn firstColumn = (DataGridViewColumn) this.marrItemsSorted[index];
        if (firstColumn.StateIncludes(enmIncludeFilter) && firstColumn.StateExcludes(enmExcludeFilter))
        {
          this.mintLastAccessedSortedIndex = index;
          return firstColumn;
        }
      }
      return (DataGridViewColumn) null;
    }

    /// <summary>Returns the last column in display order that meets the given filter requirements. </summary>
    /// <returns>The last displayed column in display order that meets the given filter requirements, or null if no column is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
    /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public DataGridViewColumn GetLastColumn(
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      if (this.marrItemsSorted == null)
        this.UpdateColumnOrderCache();
      for (int index = this.marrItemsSorted.Count - 1; index >= 0; --index)
      {
        DataGridViewColumn lastColumn = (DataGridViewColumn) this.marrItemsSorted[index];
        if (lastColumn.StateIncludes(enmIncludeFilter) && lastColumn.StateExcludes(enmExcludeFilter))
        {
          this.mintLastAccessedSortedIndex = index;
          return lastColumn;
        }
      }
      return (DataGridViewColumn) null;
    }

    /// <summary>Gets the first column after the given column in display order that meets the given filter requirements. </summary>
    /// <returns>The next column that meets the given filter requirements, or null if no column is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
    /// <param name="objDataGridViewColumnStart">The column from which to start searching for the next column.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
    /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumnStart is null.</exception>
    public DataGridViewColumn GetNextColumn(
      DataGridViewColumn objDataGridViewColumnStart,
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if (objDataGridViewColumnStart == null)
        throw new ArgumentNullException("dataGridViewColumnStart");
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      if (this.marrItemsSorted == null)
        this.UpdateColumnOrderCache();
      int columnSortedIndex = this.GetColumnSortedIndex(objDataGridViewColumnStart);
      if (columnSortedIndex == -1)
      {
        bool flag = false;
        int index1 = int.MaxValue;
        int num = int.MaxValue;
        for (int index2 = 0; index2 < this.marrItems.Count; ++index2)
        {
          DataGridViewColumn marrItem = (DataGridViewColumn) this.marrItems[index2];
          if (marrItem.StateIncludes(enmIncludeFilter) && marrItem.StateExcludes(enmExcludeFilter) && (marrItem.DisplayIndex > objDataGridViewColumnStart.DisplayIndex || marrItem.DisplayIndex == objDataGridViewColumnStart.DisplayIndex && marrItem.Index > objDataGridViewColumnStart.Index) && (marrItem.DisplayIndex < num || marrItem.DisplayIndex == num && marrItem.Index < index1))
          {
            index1 = index2;
            num = marrItem.DisplayIndex;
            flag = true;
          }
        }
        return !flag ? (DataGridViewColumn) null : (DataGridViewColumn) this.marrItems[index1];
      }
      for (int index = columnSortedIndex + 1; index < this.marrItemsSorted.Count; ++index)
      {
        DataGridViewColumn nextColumn = (DataGridViewColumn) this.marrItemsSorted[index];
        if (nextColumn.StateIncludes(enmIncludeFilter) && nextColumn.StateExcludes(enmExcludeFilter))
        {
          this.mintLastAccessedSortedIndex = index;
          return nextColumn;
        }
      }
      return (DataGridViewColumn) null;
    }

    /// <summary>Gets the last column prior to the given column in display order that meets the given filter requirements. </summary>
    /// <returns>The previous column that meets the given filter requirements, or null if no column is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
    /// <param name="objDataGridViewColumnStart">The column from which to start searching for the previous column.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
    /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumnStart is null.</exception>
    public DataGridViewColumn GetPreviousColumn(
      DataGridViewColumn objDataGridViewColumnStart,
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if (objDataGridViewColumnStart == null)
        throw new ArgumentNullException("dataGridViewColumnStart");
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      if (this.marrItemsSorted == null)
        this.UpdateColumnOrderCache();
      int columnSortedIndex = this.GetColumnSortedIndex(objDataGridViewColumnStart);
      if (columnSortedIndex == -1)
      {
        bool flag = false;
        int index1 = -1;
        int num = -1;
        for (int index2 = 0; index2 < this.marrItems.Count; ++index2)
        {
          DataGridViewColumn marrItem = (DataGridViewColumn) this.marrItems[index2];
          if (marrItem.StateIncludes(enmIncludeFilter) && marrItem.StateExcludes(enmExcludeFilter) && (marrItem.DisplayIndex < objDataGridViewColumnStart.DisplayIndex || marrItem.DisplayIndex == objDataGridViewColumnStart.DisplayIndex && marrItem.Index < objDataGridViewColumnStart.Index) && (marrItem.DisplayIndex > num || marrItem.DisplayIndex == num && marrItem.Index > index1))
          {
            index1 = index2;
            num = marrItem.DisplayIndex;
            flag = true;
          }
        }
        return !flag ? (DataGridViewColumn) null : (DataGridViewColumn) this.marrItems[index1];
      }
      for (int index = columnSortedIndex - 1; index >= 0; --index)
      {
        DataGridViewColumn previousColumn = (DataGridViewColumn) this.marrItemsSorted[index];
        if (previousColumn.StateIncludes(enmIncludeFilter) && previousColumn.StateExcludes(enmExcludeFilter))
        {
          this.mintLastAccessedSortedIndex = index;
          return previousColumn;
        }
      }
      return (DataGridViewColumn) null;
    }

    /// <summary>Gets the index of the given <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> in the collection.</summary>
    /// <returns>The index of the given <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</returns>
    /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to return the index of.</param>
    /// <filterpriority>1</filterpriority>
    public int IndexOf(DataGridViewColumn objDataGridViewColumn) => this.marrItems.IndexOf((object) objDataGridViewColumn);

    /// <summary>Inserts a column at the given index in the collection.</summary>
    /// <param name="intColumnIndex">The zero-based index at which to insert the given column.</param>
    /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to insert.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewColumn already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>. Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see>
    /// property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-dataGridViewColumn has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-dataGridViewColumn has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row and dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Insert(int intColumnIndex, DataGridViewColumn objDataGridViewColumn)
    {
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.InDisplayIndexAdjustments)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
      if (objDataGridViewColumn == null)
        throw new ArgumentNullException("dataGridViewColumn");
      if (objDataGridViewColumn.Frozen && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
        throw new Exception("DataGridView does not support hierarchies with frozen columns");
      int displayIndex = objDataGridViewColumn.DisplayIndex;
      if (displayIndex == -1)
        objDataGridViewColumn.DisplayIndex = intColumnIndex;
      Point objNewCurrentCell;
      try
      {
        this.DataGridView.OnInsertingColumn(intColumnIndex, objDataGridViewColumn, out objNewCurrentCell);
      }
      finally
      {
        objDataGridViewColumn.DisplayIndexInternal = displayIndex;
      }
      this.InvalidateCachedColumnsOrder();
      this.marrItems.Insert(intColumnIndex, (object) objDataGridViewColumn);
      objDataGridViewColumn.IndexInternal = intColumnIndex;
      objDataGridViewColumn.DataGridViewInternal = this.mobjDataGridView;
      this.UpdateColumnCaches(objDataGridViewColumn, true);
      this.DataGridView.OnInsertedColumn_PreNotification(objDataGridViewColumn);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewColumn), true, objNewCurrentCell);
    }

    internal void InvalidateCachedColumnCount(DataGridViewElementStates enmIncludeFilter)
    {
      if (enmIncludeFilter == DataGridViewElementStates.Visible)
      {
        this.InvalidateCachedColumnCounts();
      }
      else
      {
        if (enmIncludeFilter != DataGridViewElementStates.Selected)
          return;
        this.mintColumnCountsVisibleSelected = -1;
      }
    }

    internal void InvalidateCachedColumnCounts() => this.mintColumnCountsVisible = this.mintColumnCountsVisibleSelected = -1;

    internal void InvalidateCachedColumnsOrder() => this.marrItemsSorted = (ArrayList) null;

    internal void InvalidateCachedColumnsWidth(DataGridViewElementStates enmIncludeFilter)
    {
      if (enmIncludeFilter == DataGridViewElementStates.Visible)
      {
        this.InvalidateCachedColumnsWidths();
      }
      else
      {
        if (enmIncludeFilter != DataGridViewElementStates.Frozen)
          return;
        this.mintColumnsWidthVisibleFrozen = -1;
      }
    }

    internal void InvalidateCachedColumnsWidths() => this.mintColumnsWidthVisible = this.mintColumnsWidthVisibleFrozen = -1;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewColumnCollection.CollectionChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data.</param>
    protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
    {
      CollectionChangeEventHandler collectionChanged = this.CollectionChanged;
      if (collectionChanged == null)
        return;
      collectionChanged((object) this, e);
    }

    private void OnCollectionChanged(
      CollectionChangeEventArgs ccea,
      bool blnChangeIsInsertion,
      Point objNewCurrentCell)
    {
      this.OnCollectionChanged_PreNotification(ccea);
      this.OnCollectionChanged(ccea);
      this.OnCollectionChanged_PostNotification(ccea, blnChangeIsInsertion, objNewCurrentCell);
    }

    private void OnCollectionChanged_PostNotification(
      CollectionChangeEventArgs ccea,
      bool blnChangeIsInsertion,
      Point objNewCurrentCell)
    {
      DataGridViewColumn element = (DataGridViewColumn) ccea.Element;
      if (ccea.Action == CollectionChangeAction.Add & blnChangeIsInsertion)
        this.DataGridView.OnInsertedColumn_PostNotification(objNewCurrentCell);
      else if (ccea.Action == CollectionChangeAction.Remove)
        this.DataGridView.OnRemovedColumn_PostNotification(element, objNewCurrentCell);
      this.DataGridView.OnColumnCollectionChanged_PostNotification(element);
    }

    private void OnCollectionChanged_PreNotification(CollectionChangeEventArgs ccea) => this.DataGridView.OnColumnCollectionChanged_PreNotification(ccea);

    /// <summary>Removes the column with the specified name from the collection.</summary>
    /// <param name="strColumnName">The name of the column to delete.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
    /// <exception cref="T:System.ArgumentException">columnName does not match the name of any column in the collection.</exception>
    /// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Remove(string strColumnName)
    {
      if (strColumnName == null)
        throw new ArgumentNullException("columnName");
      int count = this.marrItems.Count;
      for (int index = 0; index < count; ++index)
      {
        if (string.Compare(((DataGridViewColumn) this.marrItems[index]).Name, strColumnName, true, CultureInfo.InvariantCulture) == 0)
        {
          this.RemoveAt(index);
          return;
        }
      }
      throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", (object) strColumnName), "columnName");
    }

    /// <summary>Removes the specified column from the collection.</summary>
    /// <param name="objDataGridViewColumn">The column to delete.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
    /// <exception cref="T:System.ArgumentException">dataGridViewColumn is not in the collection.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Remove(DataGridViewColumn objDataGridViewColumn)
    {
      if (objDataGridViewColumn == null)
        throw new ArgumentNullException("dataGridViewColumn");
      if (objDataGridViewColumn.DataGridView != this.DataGridView)
        throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"), "dataGridViewColumn");
      int count = this.marrItems.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.marrItems[index] == objDataGridViewColumn)
        {
          this.RemoveAt(index);
          break;
        }
      }
    }

    /// <summary>Removes the column at the given index in the collection.</summary>
    /// <param name="index">The index of the column to delete.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the number of columns in the control minus one. </exception>
    /// <filterpriority>1</filterpriority>
    public virtual void RemoveAt(int index)
    {
      if (index < 0 || index >= this.Count)
        throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.InDisplayIndexAdjustments)
        throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
      this.RemoveAtInternal(index, false);
    }

    internal void RemoveAtInternal(int index, bool blnForce)
    {
      DataGridViewColumn marrItem = (DataGridViewColumn) this.marrItems[index];
      Point objNewCurrentCell;
      this.DataGridView.OnRemovingColumn(marrItem, out objNewCurrentCell, blnForce);
      this.InvalidateCachedColumnsOrder();
      this.marrItems.RemoveAt(index);
      marrItem.DataGridViewInternal = (DataGridView) null;
      this.UpdateColumnCaches(marrItem, false);
      this.DataGridView.OnRemovedColumn_PreNotification(marrItem);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, (object) marrItem), false, objNewCurrentCell);
    }

    void ICollection.CopyTo(Array objArray, int index) => this.marrItems.CopyTo(objArray, index);

    IEnumerator IEnumerable.GetEnumerator() => this.marrItems.GetEnumerator();

    int IList.Add(object objValue) => this.Add((DataGridViewColumn) objValue);

    void IList.Clear() => this.Clear();

    bool IList.Contains(object objValue) => this.marrItems.Contains(objValue);

    int IList.IndexOf(object objValue) => this.marrItems.IndexOf(objValue);

    void IList.Insert(int index, object objValue) => this.Insert(index, (DataGridViewColumn) objValue);

    void IList.Remove(object objValue) => this.Remove((DataGridViewColumn) objValue);

    void IList.RemoveAt(int index) => this.RemoveAt(index);

    private void UpdateColumnCaches(DataGridViewColumn objDataGridViewColumn, bool blnAdding)
    {
      if (this.mintColumnCountsVisible == -1 && this.mintColumnCountsVisibleSelected == -1 && this.mintColumnsWidthVisible == -1 && this.mintColumnsWidthVisibleFrozen == -1)
        return;
      DataGridViewElementStates state = objDataGridViewColumn.State;
      if ((state & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
        return;
      int num1 = blnAdding ? 1 : -1;
      int num2 = 0;
      if (this.mintColumnsWidthVisible != -1 || this.mintColumnsWidthVisibleFrozen != -1 && (state & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
        num2 = blnAdding ? objDataGridViewColumn.Width : -objDataGridViewColumn.Width;
      if (this.mintColumnCountsVisible != -1)
        this.mintColumnCountsVisible += num1;
      if (this.mintColumnsWidthVisible != -1)
        this.mintColumnsWidthVisible += num2;
      if ((state & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) && this.mintColumnsWidthVisibleFrozen != -1)
        this.mintColumnsWidthVisibleFrozen += num2;
      if ((state & (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) || this.mintColumnCountsVisibleSelected == -1)
        return;
      this.mintColumnCountsVisibleSelected += num1;
    }

    private void UpdateColumnOrderCache()
    {
      this.marrItemsSorted = (ArrayList) this.marrItems.Clone();
      this.marrItemsSorted.Sort((IComparer) DataGridViewColumnCollection.mobjColumnOrderComparer);
      this.mintLastAccessedSortedIndex = -1;
    }

    internal static IComparer ColumnCollectionOrderComparer => (IComparer) DataGridViewColumnCollection.mobjColumnOrderComparer;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> upon which the collection performs column-related operations.</summary>
    /// <returns><see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    protected DataGridView DataGridView => this.mobjDataGridView;

    /// <summary>Gets or sets the column of the given name in the collection. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> identified by the columnName parameter.</returns>
    /// <param name="strColumnName">The name of the column to get or set.</param>
    /// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewColumn this[string strColumnName]
    {
      get
      {
        if (strColumnName == null)
          throw new ArgumentNullException("columnName");
        int count = this.marrItems.Count;
        for (int index = 0; index < count; ++index)
        {
          DataGridViewColumn marrItem = (DataGridViewColumn) this.marrItems[index];
          if (ClientUtils.IsEquals(marrItem.Name, strColumnName, StringComparison.OrdinalIgnoreCase))
            return marrItem;
        }
        return (DataGridViewColumn) null;
      }
    }

    /// <summary>Gets or sets the column at the given index in the collection. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> at the given index.</returns>
    /// <param name="index">The zero-based index of the column to get or set.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the number of columns in the collection minus one.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewColumn this[int index] => (DataGridViewColumn) this.marrItems[index];

    /// <summary>
    /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
    /// </summary>
    /// <value></value>
    /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
    protected override ArrayList List => this.marrItems;

    int ICollection.Count => this.marrItems.Count;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => (object) this;

    bool IList.IsFixedSize => false;

    bool IList.IsReadOnly => false;

    object IList.this[int index]
    {
      get => (object) this[index];
      set => throw new NotSupportedException();
    }

    [Serializable]
    private class ColumnOrderComparer : IComparer
    {
      public int Compare(object objX, object objY) => (objX as DataGridViewColumn).DisplayIndex - (objY as DataGridViewColumn).DisplayIndex;
    }
  }
}
