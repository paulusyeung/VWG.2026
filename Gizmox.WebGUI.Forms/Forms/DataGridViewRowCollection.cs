// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [ListBindable(false)]
  [DesignerSerializer("Gizmox.WebGUI.Forms.Design.DataGridViewRowCollectionCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Serializable]
  public class DataGridViewRowCollection : IList, ICollection, IEnumerable
  {
    private DataGridView mobjDataGridView;
    private DataGridViewRowCollection.RowArrayList mobjItems;
    private int mintRowCountsVisible;
    private int mintRowCountsVisibleFrozen;
    private int mintRowCountsVisibleSelected;
    private int mintRowsHeightVisible;
    private int mintRowsHeightVisibleFrozen;
    private System.Collections.Generic.List<DataGridViewElementStates> mobjRowStates;

    /// <summary>Occurs when the contents of the collection change.</summary>
    /// <filterpriority>1</filterpriority>
    public event CollectionChangeEventHandler CollectionChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> class. </summary>
    /// <param name="objDataGridView">The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    public DataGridViewRowCollection(DataGridView objDataGridView)
    {
      this.InvalidateCachedRowCounts();
      this.InvalidateCachedRowsHeights();
      this.mobjDataGridView = objDataGridView;
      this.mobjRowStates = new System.Collections.Generic.List<DataGridViewElementStates>();
      this.mobjItems = new DataGridViewRowCollection.RowArrayList(this);
    }

    /// <summary>Adds a new row to the collection.</summary>
    /// <returns>The index of the new row.</returns>
    /// <exception cref="T:System.ArgumentException">The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-This operation would add a frozen row after unfrozen rows.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int Add()
    {
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      return this.AddInternal(false, (object[]) null);
    }

    /// <summary>Adds the specified number of new rows to the collection.</summary>
    /// <returns>The index of the last row that was added.</returns>
    /// <param name="intCount">The number of rows to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">count is less than 1.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control. -or-This operation would add frozen rows after unfrozen rows.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int Add(int intCount)
    {
      if (intCount <= 0)
        throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
      if (this.DataGridView.Columns.Count == 0)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.RowTemplate.Cells.Count > this.DataGridView.Columns.Count)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
      DataGridViewRow rowTemplateClone = this.DataGridView.RowTemplateClone;
      DataGridViewElementStates state = rowTemplateClone.State;
      rowTemplateClone.DataGridViewInternal = this.mobjDataGridView;
      int index = 0;
      foreach (DataGridViewCell cell in (BaseCollection) rowTemplateClone.Cells)
      {
        cell.DataGridViewInternal = this.mobjDataGridView;
        cell.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      if (rowTemplateClone.HasHeaderCell)
      {
        rowTemplateClone.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
        rowTemplateClone.HeaderCell.OwningRowInternal = rowTemplateClone;
      }
      if (this.DataGridView.NewRowIndex == -1)
        return this.AddCopiesPrivate(rowTemplateClone, state, intCount);
      int indexDestination = this.Count - 1;
      this.InsertCopiesPrivate(rowTemplateClone, state, indexDestination, intCount);
      return indexDestination + intCount - 1;
    }

    /// <summary>Adds a new row to the collection, and populates the cells with the specified objects.</summary>
    /// <returns>The index of the new row.</returns>
    /// <param name="arrValues">A variable number of objects that populate the cells of the new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.- or -The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns. -or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control.-or-This operation would add a frozen row after unfrozen rows.</exception>
    /// <exception cref="T:System.ArgumentNullException">values is null.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int Add(params object[] arrValues)
    {
      if (arrValues == null)
        throw new ArgumentNullException("values");
      if (this.DataGridView.VirtualMode)
        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      return this.AddInternal(false, arrValues);
    }

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to the collection.</summary>
    /// <returns>The index of the new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</returns>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <exception cref="T:System.ArgumentException">dataGridViewRow has more cells than there are columns in the control.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the dataGridViewRow is not null.-or-dataGridViewRow has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true. -or-This operation would add a frozen row after unfrozen rows.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual int Add(DataGridViewRow objDataGridViewRow)
    {
      if (this.DataGridView.Columns.Count == 0)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      return this.AddInternal(objDataGridViewRow);
    }

    /// <summary>Adds the specified number of rows to the collection based on the row at the specified index.</summary>
    /// <returns>The index of the last row that was added.</returns>
    /// <param name="intCount">The number of rows to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <param name="indexSource">The index of the row on which to base the new rows.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than or equal to the number of rows in the control.-or-count is less than zero.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-This operation would add a frozen row after unfrozen rows.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual int AddCopies(int indexSource, int intCount)
    {
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      return this.AddCopiesInternal(indexSource, intCount);
    }

    internal int AddCopiesInternal(int indexSource, int intCount)
    {
      if (this.DataGridView.NewRowIndex == -1)
        return this.AddCopiesInternal(indexSource, intCount, DataGridViewElementStates.None, DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
      int indexDestination = this.Count - 1;
      this.InsertCopiesPrivate(indexSource, indexDestination, intCount);
      return indexDestination + intCount - 1;
    }

    internal int AddCopiesInternal(
      int indexSource,
      int intCount,
      DataGridViewElementStates enmDgvesAdd,
      DataGridViewElementStates enmDgvesRemove)
    {
      if (indexSource < 0 || this.Count <= indexSource)
        throw new ArgumentOutOfRangeException(nameof (indexSource), SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
      if (intCount <= 0)
        throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
      DataGridViewElementStates enmRowTemplateState = this.mobjRowStates[indexSource] & ~enmDgvesRemove | enmDgvesAdd;
      return this.AddCopiesPrivate(this.SharedRow(indexSource), enmRowTemplateState, intCount);
    }

    private int AddCopiesPrivate(
      DataGridViewRow objRowTemplate,
      DataGridViewElementStates enmRowTemplateState,
      int intCount)
    {
      int count = this.mobjItems.Count;
      if (objRowTemplate.Index == -1)
      {
        this.DataGridView.OnAddingRow(objRowTemplate, enmRowTemplateState, true);
        for (int index = 0; index < intCount - 1; ++index)
        {
          this.SharedList.Add((object) objRowTemplate);
          this.mobjRowStates.Add(enmRowTemplateState);
        }
        int intRowIndex = this.SharedList.Add((object) objRowTemplate);
        this.mobjRowStates.Add(enmRowTemplateState);
        this.DataGridView.OnAddedRow_PreNotification(intRowIndex);
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), count, intCount);
        for (int index = 0; index < intCount; ++index)
          this.DataGridView.OnAddedRow_PostNotification(intRowIndex - (intCount - 1) + index);
        return intRowIndex;
      }
      int num = this.AddDuplicateRow(objRowTemplate, false);
      if (intCount > 1)
      {
        this.DataGridView.OnAddedRow_PreNotification(num);
        if (this.RowIsSharable(num))
        {
          DataGridViewRow objDataGridViewRow = this.SharedRow(num);
          this.DataGridView.OnAddingRow(objDataGridViewRow, enmRowTemplateState, true);
          for (int index = 1; index < intCount - 1; ++index)
          {
            this.SharedList.Add((object) objDataGridViewRow);
            this.mobjRowStates.Add(enmRowTemplateState);
          }
          num = this.SharedList.Add((object) objDataGridViewRow);
          this.mobjRowStates.Add(enmRowTemplateState);
          this.DataGridView.OnAddedRow_PreNotification(num);
        }
        else
        {
          this.UnshareRow(num);
          for (int index = 1; index < intCount; ++index)
          {
            num = this.AddDuplicateRow(objRowTemplate, false);
            this.UnshareRow(num);
            this.DataGridView.OnAddedRow_PreNotification(num);
          }
        }
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), count, intCount);
        for (int index = 0; index < intCount; ++index)
          this.DataGridView.OnAddedRow_PostNotification(num - (intCount - 1) + index);
        return num;
      }
      if (this.IsCollectionChangedListenedTo)
        this.UnshareRow(num);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) this.SharedRow(num)), num, 1);
      return num;
    }

    /// <summary>Adds a new row based on the row at the specified index.</summary>
    /// <returns>The index of the new row.</returns>
    /// <param name="indexSource">The index of the row on which to base the new row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than or equal to the number of rows in the collection.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-This operation would add a frozen row after unfrozen rows.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual int AddCopy(int indexSource)
    {
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      return this.AddCopyInternal(indexSource, DataGridViewElementStates.None, DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected, false);
    }

    internal int AddCopyInternal(
      int indexSource,
      DataGridViewElementStates enmDgvesAdd,
      DataGridViewElementStates enmDgvesRemove,
      bool blnNewRow)
    {
      if (this.DataGridView.NewRowIndex != -1)
      {
        int indexDestination = this.Count - 1;
        this.InsertCopy(indexSource, indexDestination);
        return indexDestination;
      }
      DataGridViewRow dataGridViewRow = indexSource >= 0 && indexSource < this.Count ? this.SharedRow(indexSource) : throw new ArgumentOutOfRangeException(nameof (indexSource), SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
      if (dataGridViewRow.Index == -1 && !this.IsCollectionChangedListenedTo && !blnNewRow)
      {
        DataGridViewElementStates enmRowState = this.mobjRowStates[indexSource] & ~enmDgvesRemove | enmDgvesAdd;
        this.DataGridView.OnAddingRow(dataGridViewRow, enmRowState, true);
        int intRowIndex = this.SharedList.Add((object) dataGridViewRow);
        this.mobjRowStates.Add(enmRowState);
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) dataGridViewRow), intRowIndex, 1);
        return intRowIndex;
      }
      int num = this.AddDuplicateRow(dataGridViewRow, blnNewRow);
      if (!this.RowIsSharable(num) || DataGridViewRowCollection.RowHasValueOrToolTipText(this.SharedRow(num)) || this.IsCollectionChangedListenedTo)
        this.UnshareRow(num);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) this.SharedRow(num)), num, 1);
      return num;
    }

    private int AddDuplicateRow(DataGridViewRow objRowTemplate, bool blnNewRow)
    {
      DataGridViewRow objDataGridViewRow = (DataGridViewRow) objRowTemplate.Clone();
      objDataGridViewRow.StateInternal = DataGridViewElementStates.None;
      objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
      DataGridViewCellCollection cells = objDataGridViewRow.Cells;
      int index = 0;
      foreach (DataGridViewCell dataGridViewCell1 in (BaseCollection) cells)
      {
        if (blnNewRow)
        {
          DataGridViewCell dataGridViewCell2 = dataGridViewCell1;
          dataGridViewCell2.Value = dataGridViewCell2.DefaultNewRowValue;
        }
        dataGridViewCell1.DataGridViewInternal = this.mobjDataGridView;
        dataGridViewCell1.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      DataGridViewElementStates enmRowState = objRowTemplate.State & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
      if (objDataGridViewRow.HasHeaderCell)
      {
        objDataGridViewRow.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
        objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
      }
      this.DataGridView.OnAddingRow(objDataGridViewRow, enmRowState, true);
      this.mobjRowStates.Add(enmRowState);
      return this.SharedList.Add((object) objDataGridViewRow);
    }

    internal int AddInternal(DataGridViewRow objDataGridViewRow)
    {
      if (objDataGridViewRow == null)
        throw new ArgumentNullException("dataGridViewRow");
      if (objDataGridViewRow.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
      if (this.DataGridView.Columns.Count == 0)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
      if (objDataGridViewRow.Cells.Count > this.DataGridView.Columns.Count)
        throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
      if (objDataGridViewRow.Selected)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
      if (this.DataGridView.NewRowIndex != -1)
      {
        int intRowIndex = this.Count - 1;
        this.InsertInternal(intRowIndex, objDataGridViewRow);
        return intRowIndex;
      }
      this.DataGridView.CompleteCellsCollection(objDataGridViewRow);
      DataGridView dataGridView = this.DataGridView;
      DataGridViewRow objDataGridViewRow1 = objDataGridViewRow;
      int state = (int) objDataGridViewRow1.State;
      dataGridView.OnAddingRow(objDataGridViewRow1, (DataGridViewElementStates) state, true);
      int index = 0;
      foreach (DataGridViewCell cell in (BaseCollection) objDataGridViewRow.Cells)
      {
        cell.DataGridViewInternal = this.mobjDataGridView;
        if (cell.ColumnIndex == -1)
          cell.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      if (objDataGridViewRow.HasHeaderCell)
      {
        objDataGridViewRow.HeaderCell.DataGridViewInternal = this.DataGridView;
        objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
      }
      int num = this.SharedList.Add((object) objDataGridViewRow);
      this.mobjRowStates.Add(objDataGridViewRow.State);
      objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
      if (!this.RowIsSharable(num) || DataGridViewRowCollection.RowHasValueOrToolTipText(objDataGridViewRow) || this.IsCollectionChangedListenedTo)
        objDataGridViewRow.IndexInternal = num;
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewRow), num, 1);
      return num;
    }

    internal int AddInternal(bool blnNewRow, object[] arrValues)
    {
      if (this.DataGridView.Columns.Count == 0)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
      if (this.DataGridView.RowTemplate.Cells.Count > this.DataGridView.Columns.Count)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
      DataGridViewRow rowTemplateClone = this.DataGridView.RowTemplateClone;
      if (blnNewRow)
      {
        DataGridViewRow dataGridViewRow = rowTemplateClone;
        dataGridViewRow.StateInternal = dataGridViewRow.State | DataGridViewElementStates.Visible;
        foreach (DataGridViewCell cell in (BaseCollection) rowTemplateClone.Cells)
          cell.Value = cell.DefaultNewRowValue;
      }
      if (arrValues != null)
        rowTemplateClone.SetValuesInternal(arrValues);
      if (this.DataGridView.NewRowIndex != -1)
      {
        int intRowIndex = this.Count - 1;
        this.Insert(intRowIndex, rowTemplateClone);
        return intRowIndex;
      }
      DataGridViewElementStates state = rowTemplateClone.State;
      this.DataGridView.OnAddingRow(rowTemplateClone, state, true);
      rowTemplateClone.DataGridViewInternal = this.mobjDataGridView;
      int index = 0;
      foreach (DataGridViewCell cell in (BaseCollection) rowTemplateClone.Cells)
      {
        cell.DataGridViewInternal = this.mobjDataGridView;
        cell.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      int num = this.SharedList.Add((object) rowTemplateClone);
      this.mobjRowStates.Add(state);
      if (arrValues != null || !this.RowIsSharable(num) || DataGridViewRowCollection.RowHasValueOrToolTipText(rowTemplateClone) || this.IsCollectionChangedListenedTo)
        rowTemplateClone.IndexInternal = num;
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) rowTemplateClone), num, 1);
      return num;
    }

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to the collection.</summary>
    /// <param name="arrDataGridViewRows">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to be added to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-At least one entry in the dataGridViewRows array is null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property value that is not null.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true.-or-Two or more rows in the dataGridViewRows array are identical.-or-At least one row in the dataGridViewRows array contains one or more cells of a type that is incompatible with the type of the corresponding column in the control.-or-At least one row in the dataGridViewRows array contains more cells than there are columns in the control.-or-This operation would add frozen rows after unfrozen rows.</exception>
    /// <exception cref="T:System.ArgumentException">dataGridViewRows contains only one row, and the row it contains has more cells than there are columns in the control.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewRows is null.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual void AddRange(params DataGridViewRow[] arrDataGridViewRows)
    {
      if (arrDataGridViewRows == null)
        throw new ArgumentNullException("dataGridViewRows");
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NewRowIndex != -1)
      {
        this.InsertRange(this.Count - 1, arrDataGridViewRows);
      }
      else
      {
        if (this.DataGridView.Columns.Count == 0)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
        int count = this.mobjItems.Count;
        this.DataGridView.OnAddingRows(arrDataGridViewRows, true);
        foreach (DataGridViewRow arrDataGridViewRow in arrDataGridViewRows)
        {
          int index = 0;
          foreach (DataGridViewCell cell in (BaseCollection) arrDataGridViewRow.Cells)
          {
            cell.DataGridViewInternal = this.mobjDataGridView;
            cell.OwningColumnInternal = this.DataGridView.Columns[index];
            ++index;
          }
          if (arrDataGridViewRow.HasHeaderCell)
          {
            arrDataGridViewRow.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
            arrDataGridViewRow.HeaderCell.OwningRowInternal = arrDataGridViewRow;
          }
          int num = this.SharedList.Add((object) arrDataGridViewRow);
          this.mobjRowStates.Add(arrDataGridViewRow.State);
          arrDataGridViewRow.IndexInternal = num;
          arrDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
        }
        this.DataGridView.OnAddedRows_PreNotification(arrDataGridViewRows);
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), count, arrDataGridViewRows.Length);
        this.DataGridView.OnAddedRows_PostNotification(arrDataGridViewRows);
      }
    }

    /// <summary>Clears the collection. </summary>
    /// <exception cref="T:System.InvalidOperationException">The collection is data bound and the underlying data source does not support clearing the row data.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Clear()
    {
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.DataSource != null)
      {
        if (!(this.DataGridView.DataConnection.List is IBindingList list) || !list.AllowRemove || !list.SupportsChangeNotification)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CantClearRowCollectionWithWrongSource"));
        list.Clear();
      }
      else
        this.ClearInternal(true);
    }

    internal void ClearInternal(bool blnRecreateNewRow)
    {
      int count = this.mobjItems.Count;
      if (count > 0)
      {
        this.DataGridView.OnClearingRows();
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
          this.SharedRow(intRowIndex).DetachFromDataGridView();
        this.SharedList.Clear();
        this.mobjRowStates.Clear();
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), 0, count, true, false, blnRecreateNewRow, new Point(-1, -1));
      }
      else
      {
        if (!blnRecreateNewRow || this.DataGridView.Columns.Count == 0 || !this.DataGridView.AllowUserToAddRowsInternal || this.mobjItems.Count != 0)
          return;
        this.DataGridView.AddNewRow(false);
      }
    }

    /// <summary>Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> is in the collection.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> is in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>; otherwise, false.</returns>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <filterpriority>1</filterpriority>
    public virtual bool Contains(DataGridViewRow objDataGridViewRow) => this.mobjItems.IndexOf((object) objDataGridViewRow) != -1;

    /// <summary>Copies the items from the collection into the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> array, starting at the specified index.</summary>
    /// <param name="arrRows">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> array that is the destination of the items copied from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <param name="index">The zero-based index in array at which copying begins.</param>
    /// <exception cref="T:System.ArgumentException">array is multidimensional.-or- index is equal to or greater than the length of array.-or- The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> is greater than the available space from index to the end of array. </exception>
    /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(DataGridViewRow[] arrRows, int index) => this.mobjItems.CopyTo((Array) arrRows, index);

    internal int DisplayIndexToRowIndex(int visibleRowIndex)
    {
      int num = -1;
      for (int intRowIndex = 0; intRowIndex < this.Count; ++intRowIndex)
      {
        if ((this.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible)
          ++num;
        if (num == visibleRowIndex)
          return intRowIndex;
      }
      return -1;
    }

    /// <summary>Returns the index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
    /// <returns>The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetFirstRow(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisible == 0)
            return -1;
          break;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleFrozen == 0)
            return -1;
          break;
        case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleSelected == 0)
            return -1;
          break;
      }
      int intRowIndex = 0;
      while (intRowIndex < this.mobjItems.Count && (this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter)
        ++intRowIndex;
      return intRowIndex >= this.mobjItems.Count ? -1 : intRowIndex;
    }

    /// <summary>Returns the index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
    /// <returns>The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetFirstRow(
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if (enmExcludeFilter == DataGridViewElementStates.None)
        return this.GetFirstRow(enmIncludeFilter);
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisible == 0)
            return -1;
          break;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleFrozen == 0)
            return -1;
          break;
        case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleSelected == 0)
            return -1;
          break;
      }
      int intRowIndex = 0;
      while (intRowIndex < this.mobjItems.Count && ((this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter || (this.GetRowState(intRowIndex) & enmExcludeFilter) != DataGridViewElementStates.None))
        ++intRowIndex;
      return intRowIndex >= this.mobjItems.Count ? -1 : intRowIndex;
    }

    /// <summary>Returns the index of the last <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
    /// <returns>The index of the last <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetLastRow(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisible == 0)
            return -1;
          break;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleFrozen == 0)
            return -1;
          break;
        case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleSelected == 0)
            return -1;
          break;
      }
      int intRowIndex = this.mobjItems.Count - 1;
      while (intRowIndex >= 0 && (this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter)
        --intRowIndex;
      return intRowIndex < 0 ? -1 : intRowIndex;
    }

    /// <summary>Returns the index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
    /// <returns>The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> after indexStart that has the attributes specified by includeFilter, or -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <param name="indexStart">The index of the row where the method should begin to look for the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is less than -1.</exception>
    public int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if (indexStart < -1)
        throw new ArgumentOutOfRangeException(nameof (indexStart), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (indexStart), (object) indexStart.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) -1.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int intRowIndex = indexStart + 1;
      while (intRowIndex < this.mobjItems.Count && (this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter)
        ++intRowIndex;
      return intRowIndex >= this.mobjItems.Count ? -1 : intRowIndex;
    }

    internal int GetNextRow(
      int indexStart,
      DataGridViewElementStates enmIncludeFilter,
      int intSkipRows)
    {
      int indexStart1 = indexStart;
      do
      {
        indexStart1 = this.GetNextRow(indexStart1, enmIncludeFilter);
        --intSkipRows;
      }
      while (intSkipRows >= 0 && indexStart1 != -1);
      return indexStart1;
    }

    /// <summary>Returns the index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
    /// <returns>The index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <param name="indexStart">The index of the row where the method should begin to look for the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is less than -1.</exception>
    public int GetNextRow(
      int indexStart,
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if (enmExcludeFilter == DataGridViewElementStates.None)
        return this.GetNextRow(indexStart, enmIncludeFilter);
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      if (indexStart < -1)
        throw new ArgumentOutOfRangeException(nameof (indexStart), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (indexStart), (object) indexStart.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) -1.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int intRowIndex = indexStart + 1;
      while (intRowIndex < this.mobjItems.Count && ((this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter || (this.GetRowState(intRowIndex) & enmExcludeFilter) != DataGridViewElementStates.None))
        ++intRowIndex;
      return intRowIndex >= this.mobjItems.Count ? -1 : intRowIndex;
    }

    /// <summary>Returns the index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
    /// <returns>The index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <param name="indexStart">The index of the row where the method should begin to look for the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is greater than the number of rows in the collection.</exception>
    public int GetPreviousRow(int indexStart, DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if (indexStart > this.mobjItems.Count)
        throw new ArgumentOutOfRangeException(nameof (indexStart), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (indexStart), (object) indexStart.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) this.mobjItems.Count.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int intRowIndex = indexStart - 1;
      while (intRowIndex >= 0 && (this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter)
        --intRowIndex;
      return intRowIndex < 0 ? -1 : intRowIndex;
    }

    /// <summary>Returns the index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
    /// <returns>The index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <param name="indexStart">The index of the row where the method should begin to look for the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
    /// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is greater than the number of rows in the collection.</exception>
    public int GetPreviousRow(
      int indexStart,
      DataGridViewElementStates enmIncludeFilter,
      DataGridViewElementStates enmExcludeFilter)
    {
      if (enmExcludeFilter == DataGridViewElementStates.None)
        return this.GetPreviousRow(indexStart, enmIncludeFilter);
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "excludeFilter"));
      if (indexStart > this.mobjItems.Count)
        throw new ArgumentOutOfRangeException(nameof (indexStart), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (indexStart), (object) indexStart.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) this.mobjItems.Count.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int intRowIndex = indexStart - 1;
      while (intRowIndex >= 0 && ((this.GetRowState(intRowIndex) & enmIncludeFilter) != enmIncludeFilter || (this.GetRowState(intRowIndex) & enmExcludeFilter) != DataGridViewElementStates.None))
        --intRowIndex;
      return intRowIndex < 0 ? -1 : intRowIndex;
    }

    /// <summary>Returns the number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the collection that meet the specified criteria.</summary>
    /// <returns>The number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that have the attributes specified by includeFilter.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetRowCount(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisible != -1)
            return this.mintRowCountsVisible;
          break;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleFrozen != -1)
            return this.mintRowCountsVisibleFrozen;
          break;
        case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
          if (this.mintRowCountsVisibleSelected != -1)
            return this.mintRowCountsVisibleSelected;
          break;
      }
      int rowCount = 0;
      for (int intRowIndex = 0; intRowIndex < this.mobjItems.Count; ++intRowIndex)
      {
        if ((this.GetRowState(intRowIndex) & enmIncludeFilter) == enmIncludeFilter)
          ++rowCount;
      }
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          this.mintRowCountsVisible = rowCount;
          return rowCount;
        case DataGridViewElementStates.Displayed | DataGridViewElementStates.Visible:
          return rowCount;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          this.mintRowCountsVisibleFrozen = rowCount;
          return rowCount;
        case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
          this.mintRowCountsVisibleSelected = rowCount;
          return rowCount;
        default:
          return rowCount;
      }
    }

    internal int GetRowCount(
      DataGridViewElementStates enmIncludeFilter,
      int intFromRowIndex,
      int toRowIndex)
    {
      int rowCount = 0;
      for (int intRowIndex = intFromRowIndex + 1; intRowIndex <= toRowIndex; ++intRowIndex)
      {
        if ((this.GetRowState(intRowIndex) & enmIncludeFilter) == enmIncludeFilter)
          ++rowCount;
      }
      return rowCount;
    }

    /// <summary>Returns the cumulative height of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects that meet the specified criteria.</summary>
    /// <returns>The cumulative height of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that have the attributes specified by includeFilter.</returns>
    /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
    /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
    public int GetRowsHeight(DataGridViewElementStates enmIncludeFilter)
    {
      if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
        throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", (object) "includeFilter"));
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          if (this.mintRowsHeightVisible != -1)
            return this.mintRowsHeightVisible;
          break;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          if (this.mintRowsHeightVisibleFrozen != -1)
            return this.mintRowsHeightVisibleFrozen;
          break;
      }
      int rowsHeight = 0;
      for (int index = 0; index < this.mobjItems.Count; ++index)
      {
        if ((this.GetRowState(index) & enmIncludeFilter) == enmIncludeFilter)
          rowsHeight += ((DataGridViewRow) this.mobjItems[index]).GetHeight(index);
      }
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Visible:
          this.mintRowsHeightVisible = rowsHeight;
          return rowsHeight;
        case DataGridViewElementStates.Displayed | DataGridViewElementStates.Visible:
          return rowsHeight;
        case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
          this.mintRowsHeightVisibleFrozen = rowsHeight;
          return rowsHeight;
        default:
          return rowsHeight;
      }
    }

    internal int GetRowsHeight(
      DataGridViewElementStates enmIncludeFilter,
      int intFromRowIndex,
      int toRowIndex)
    {
      int rowsHeight = 0;
      for (int index = intFromRowIndex; index < toRowIndex; ++index)
      {
        if ((this.GetRowState(index) & enmIncludeFilter) == enmIncludeFilter)
          rowsHeight += ((DataGridViewRow) this.mobjItems[index]).GetHeight(index);
      }
      return rowsHeight;
    }

    private bool GetRowsHeightExceedLimit(
      DataGridViewElementStates enmIncludeFilter,
      int intFromRowIndex,
      int toRowIndex,
      int intHeightLimit)
    {
      int num = 0;
      for (int index = intFromRowIndex; index < toRowIndex; ++index)
      {
        if ((this.GetRowState(index) & enmIncludeFilter) == enmIncludeFilter)
        {
          num += ((DataGridViewRow) this.mobjItems[index]).GetHeight(index);
          if (num > intHeightLimit)
            return true;
        }
      }
      return num > intHeightLimit;
    }

    /// <summary>Gets the state of the row with the specified index.</summary>
    /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state of the specified row.</returns>
    /// <param name="intRowIndex">The index of the row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero and greater than the number of rows in the collection minus one.</exception>
    public virtual DataGridViewElementStates GetRowState(int intRowIndex)
    {
      if (intRowIndex < 0 || intRowIndex >= this.mobjItems.Count)
        throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
      DataGridViewRow dataGridViewRow = this.SharedRow(intRowIndex);
      return dataGridViewRow.Index == -1 ? this.SharedRowState(intRowIndex) : dataGridViewRow.GetState(intRowIndex);
    }

    /// <summary>Returns the index of a specified item in the collection.</summary>
    /// <returns>The index of value if it is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> found in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>; otherwise, -1.</returns>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <filterpriority>1</filterpriority>
    public int IndexOf(DataGridViewRow objDataGridViewRow) => this.mobjItems.IndexOf((object) objDataGridViewRow);

    /// <summary>Inserts the specified number of rows into the collection at the specified location.</summary>
    /// <param name="intCount">The number of rows to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <param name="intRowIndex">The position at which to insert the rows.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. -or-count is less than 1.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Insert(int intRowIndex, int intCount)
    {
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (intRowIndex < 0 || this.Count < intRowIndex)
        throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
      if (intCount <= 0)
        throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.Columns.Count == 0)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
      if (this.DataGridView.RowTemplate.Cells.Count > this.DataGridView.Columns.Count)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
      if (this.DataGridView.NewRowIndex != -1 && intRowIndex == this.Count)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
      DataGridViewRow rowTemplateClone = this.DataGridView.RowTemplateClone;
      DataGridViewElementStates state = rowTemplateClone.State;
      rowTemplateClone.DataGridViewInternal = this.mobjDataGridView;
      int index = 0;
      foreach (DataGridViewCell cell in (BaseCollection) rowTemplateClone.Cells)
      {
        cell.DataGridViewInternal = this.mobjDataGridView;
        cell.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      if (rowTemplateClone.HasHeaderCell)
      {
        rowTemplateClone.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
        rowTemplateClone.HeaderCell.OwningRowInternal = rowTemplateClone;
      }
      this.InsertCopiesPrivate(rowTemplateClone, state, intRowIndex, intCount);
    }

    /// <summary>Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> into the collection.</summary>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <param name="intRowIndex">The position at which to insert the row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. </exception>
    /// <exception cref="T:System.ArgumentException">dataGridViewRow has more cells than there are columns in the control.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of dataGridViewRow is not null.-or-dataGridViewRow has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Insert(int intRowIndex, DataGridViewRow objDataGridViewRow)
    {
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      this.InsertInternal(intRowIndex, objDataGridViewRow);
    }

    /// <summary>Inserts a row into the collection at the specified position, and populates the cells with the specified objects.</summary>
    /// <param name="intRowIndex">The position at which to insert the row.</param>
    /// <param name="arrValues">A variable number of objects that populate the cells of the new row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. </exception>
    /// <exception cref="T:System.ArgumentException">The row returned by the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the row returned by the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property is not null. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
    /// <exception cref="T:System.ArgumentNullException">values is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Insert(int intRowIndex, params object[] arrValues)
    {
      if (arrValues == null)
        throw new ArgumentNullException("values");
      if (this.DataGridView.VirtualMode)
        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
      DataGridViewRow objDataGridViewRow = this.DataGridView.DataSource == null ? this.DataGridView.RowTemplateClone : throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      objDataGridViewRow.SetValuesInternal(arrValues);
      this.Insert(intRowIndex, objDataGridViewRow);
    }

    /// <summary>Inserts rows into the collection at the specified position.</summary>
    /// <param name="indexDestination">The position at which to insert the rows.</param>
    /// <param name="intCount">The number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <param name="indexSource">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> on which to base the new rows.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than the number of rows in the collection minus one.-or-indexDestination is less than zero or greater than the number of rows in the collection.-or-count is less than 1.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-indexDestination is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true.-or-This operation would insert frozen rows after unfrozen rows or unfrozen rows before frozen rows.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void InsertCopies(int indexSource, int indexDestination, int intCount)
    {
      if (this.DataGridView.DataSource != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      this.InsertCopiesPrivate(indexSource, indexDestination, intCount);
    }

    /// <summary>Inserts the copies private.</summary>
    /// <param name="indexSource">The index source.</param>
    /// <param name="indexDestination">The index destination.</param>
    /// <param name="intCount">The count.</param>
    private void InsertCopiesPrivate(int indexSource, int indexDestination, int intCount)
    {
      if (indexSource < 0 || this.Count <= indexSource)
        throw new ArgumentOutOfRangeException(nameof (indexSource), SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
      if (indexDestination < 0 || this.Count < indexDestination)
        throw new ArgumentOutOfRangeException(nameof (indexDestination), SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
      if (intCount <= 0)
        throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
      if (this.DataGridView.NewRowIndex != -1 && indexDestination == this.Count)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
      DataGridViewElementStates enmRowTemplateState = this.GetRowState(indexSource) & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
      this.InsertCopiesPrivate(this.SharedRow(indexSource), enmRowTemplateState, indexDestination, intCount);
    }

    /// <summary>Inserts the copies private.</summary>
    /// <param name="objRowTemplate">The row template.</param>
    /// <param name="enmRowTemplateState">State of the row template.</param>
    /// <param name="indexDestination">The index destination.</param>
    /// <param name="intCount">The count.</param>
    private void InsertCopiesPrivate(
      DataGridViewRow objRowTemplate,
      DataGridViewElementStates enmRowTemplateState,
      int indexDestination,
      int intCount)
    {
      Point objNewCurrentCell = new Point(-1, -1);
      if (objRowTemplate.Index == -1)
      {
        if (intCount > 1)
        {
          this.DataGridView.OnInsertingRow(indexDestination, objRowTemplate, enmRowTemplateState, ref objNewCurrentCell, true, intCount, false);
          for (int index = 0; index < intCount; ++index)
          {
            this.SharedList.Insert(indexDestination + index, (object) objRowTemplate);
            this.mobjRowStates.Insert(indexDestination + index, enmRowTemplateState);
          }
          this.DataGridView.OnInsertedRow_PreNotification(indexDestination, intCount);
          this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), indexDestination, intCount, false, true, false, objNewCurrentCell);
          for (int index = 0; index < intCount; ++index)
            this.DataGridView.OnInsertedRow_PostNotification(indexDestination + index, objNewCurrentCell, index == intCount - 1);
        }
        else
        {
          this.DataGridView.OnInsertingRow(indexDestination, objRowTemplate, enmRowTemplateState, ref objNewCurrentCell, true, 1, false);
          this.SharedList.Insert(indexDestination, (object) objRowTemplate);
          this.mobjRowStates.Insert(indexDestination, enmRowTemplateState);
          this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) this.SharedRow(indexDestination)), indexDestination, intCount, false, true, false, objNewCurrentCell);
        }
      }
      else
      {
        this.InsertDuplicateRow(indexDestination, objRowTemplate, true, ref objNewCurrentCell);
        if (intCount > 1)
        {
          this.DataGridView.OnInsertedRow_PreNotification(indexDestination, 1);
          if (this.RowIsSharable(indexDestination))
          {
            DataGridViewRow objDataGridViewRow = this.SharedRow(indexDestination);
            this.DataGridView.OnInsertingRow(indexDestination + 1, objDataGridViewRow, enmRowTemplateState, ref objNewCurrentCell, false, intCount - 1, false);
            for (int index = 1; index < intCount; ++index)
            {
              this.SharedList.Insert(indexDestination + index, (object) objDataGridViewRow);
              this.mobjRowStates.Insert(indexDestination + index, enmRowTemplateState);
            }
            this.DataGridView.OnInsertedRow_PreNotification(indexDestination + 1, intCount - 1);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), indexDestination, intCount, false, true, false, objNewCurrentCell);
          }
          else
          {
            this.UnshareRow(indexDestination);
            for (int index = 1; index < intCount; ++index)
            {
              this.InsertDuplicateRow(indexDestination + index, objRowTemplate, false, ref objNewCurrentCell);
              this.UnshareRow(indexDestination + index);
            }
            this.DataGridView.OnInsertedRow_PreNotification(indexDestination + 1, intCount - 1);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), indexDestination, intCount, false, true, false, objNewCurrentCell);
          }
          for (int index = 0; index < intCount; ++index)
            this.DataGridView.OnInsertedRow_PostNotification(indexDestination + index, objNewCurrentCell, index == intCount - 1);
        }
        else
        {
          if (this.IsCollectionChangedListenedTo)
            this.UnshareRow(indexDestination);
          this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) this.SharedRow(indexDestination)), indexDestination, 1, false, true, false, objNewCurrentCell);
        }
      }
    }

    /// <summary>Inserts a row into the collection at the specified position, based on the row at specified position.</summary>
    /// <param name="indexDestination">The position at which to insert the row.</param>
    /// <param name="indexSource">The index of the row on which to base the new row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than the number of rows in the collection minus one.-or-indexDestination is less than zero or greater than the number of rows in the collection.</exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-indexDestination is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void InsertCopy(int indexSource, int indexDestination) => this.InsertCopies(indexSource, indexDestination, 1);

    /// <summary>Inserts the duplicate row.</summary>
    /// <param name="indexDestination">The index destination.</param>
    /// <param name="objRowTemplate">The row template.</param>
    /// <param name="blnFirstInsertion">if set to <c>true</c> [first insertion].</param>
    /// <param name="objNewCurrentCell">The new current cell.</param>
    private void InsertDuplicateRow(
      int indexDestination,
      DataGridViewRow objRowTemplate,
      bool blnFirstInsertion,
      ref Point objNewCurrentCell)
    {
      DataGridViewRow objDataGridViewRow = (DataGridViewRow) objRowTemplate.Clone();
      objDataGridViewRow.StateInternal = DataGridViewElementStates.None;
      objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
      DataGridViewCellCollection cells = objDataGridViewRow.Cells;
      int index = 0;
      foreach (DataGridViewCell dataGridViewCell in (BaseCollection) cells)
      {
        dataGridViewCell.DataGridViewInternal = this.mobjDataGridView;
        dataGridViewCell.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      DataGridViewElementStates enmRowState = objRowTemplate.State & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
      if (objDataGridViewRow.HasHeaderCell)
      {
        objDataGridViewRow.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
        objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
      }
      this.DataGridView.OnInsertingRow(indexDestination, objDataGridViewRow, enmRowState, ref objNewCurrentCell, blnFirstInsertion, 1, false);
      this.SharedList.Insert(indexDestination, (object) objDataGridViewRow);
      this.mobjRowStates.Insert(indexDestination, enmRowState);
    }

    /// <summary>Inserts the internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objDataGridViewRow">The data grid view row.</param>
    internal void InsertInternal(int intRowIndex, DataGridViewRow objDataGridViewRow)
    {
      if (intRowIndex < 0 || this.Count < intRowIndex)
        throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
      if (objDataGridViewRow == null)
        throw new ArgumentNullException("dataGridViewRow");
      if (objDataGridViewRow.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
      if (this.DataGridView.NewRowIndex != -1 && intRowIndex == this.Count)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
      if (this.DataGridView.Columns.Count == 0)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
      if (objDataGridViewRow.Cells.Count > this.DataGridView.Columns.Count)
        throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
      if (objDataGridViewRow.Selected)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
      this.InsertInternal(intRowIndex, objDataGridViewRow, false);
    }

    /// <summary>Inserts the internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objDataGridViewRow">The data grid view row.</param>
    /// <param name="blnForce">if set to <c>true</c> [force].</param>
    internal void InsertInternal(
      int intRowIndex,
      DataGridViewRow objDataGridViewRow,
      bool blnForce)
    {
      Point objNewCurrentCell = new Point(-1, -1);
      if (blnForce)
      {
        if (this.DataGridView.Columns.Count == 0)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
        if (objDataGridViewRow.Cells.Count > this.DataGridView.Columns.Count)
          throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
      }
      this.DataGridView.CompleteCellsCollection(objDataGridViewRow);
      DataGridView dataGridView = this.DataGridView;
      int intRowIndexInserted = intRowIndex;
      DataGridViewRow objDataGridViewRow1 = objDataGridViewRow;
      int state = (int) objDataGridViewRow1.State;
      ref Point local = ref objNewCurrentCell;
      int num = blnForce ? 1 : 0;
      dataGridView.OnInsertingRow(intRowIndexInserted, objDataGridViewRow1, (DataGridViewElementStates) state, ref local, true, 1, num != 0);
      int index = 0;
      foreach (DataGridViewCell cell in (BaseCollection) objDataGridViewRow.Cells)
      {
        cell.DataGridViewInternal = this.mobjDataGridView;
        if (cell.ColumnIndex == -1)
          cell.OwningColumnInternal = this.DataGridView.Columns[index];
        ++index;
      }
      if (objDataGridViewRow.HasHeaderCell)
      {
        objDataGridViewRow.HeaderCell.DataGridViewInternal = this.DataGridView;
        objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
      }
      this.SharedList.Insert(intRowIndex, (object) objDataGridViewRow);
      this.mobjRowStates.Insert(intRowIndex, objDataGridViewRow.State);
      objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
      if (!this.RowIsSharable(intRowIndex) || DataGridViewRowCollection.RowHasValueOrToolTipText(objDataGridViewRow) || this.IsCollectionChangedListenedTo)
        objDataGridViewRow.IndexInternal = intRowIndex;
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewRow), intRowIndex, 1, false, true, false, objNewCurrentCell);
    }

    /// <summary>Inserts the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects into the collection at the specified position.</summary>
    /// <param name="intRowIndex">The position at which to insert the rows.</param>
    /// <param name="arrDataGridViewRows">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-rowIndex is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-At least one entry in the dataGridViewRows array is null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property value that is not null.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true.-or-Two or more rows in the dataGridViewRows array are identical.-or-At least one row in the dataGridViewRows array contains one or more cells of a type that is incompatible with the type of the corresponding column in the control.-or-At least one row in the dataGridViewRows array contains more cells than there are columns in the control.
    /// -or-This operation would insert frozen rows after unfrozen rows or unfrozen rows before frozen rows.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection.</exception>
    /// <exception cref="T:System.ArgumentException">dataGridViewRows contains only one row, and the row it contains has more cells than there are columns in the control.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewRows is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void InsertRange(int intRowIndex, params DataGridViewRow[] arrDataGridViewRows)
    {
      if (arrDataGridViewRows == null)
        throw new ArgumentNullException("dataGridViewRows");
      if (arrDataGridViewRows.Length == 1)
      {
        this.Insert(intRowIndex, arrDataGridViewRows[0]);
      }
      else
      {
        if (intRowIndex < 0 || intRowIndex > this.Count)
          throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
        if (this.DataGridView.NoDimensionChangeAllowed)
          throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
        if (this.DataGridView.NewRowIndex != -1 && intRowIndex == this.Count)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
        if (this.DataGridView.DataSource != null)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
        if (this.DataGridView.Columns.Count == 0)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
        Point objNewCurrentCell = new Point(-1, -1);
        this.DataGridView.OnInsertingRows(intRowIndex, arrDataGridViewRows, ref objNewCurrentCell);
        int index1 = intRowIndex;
        foreach (DataGridViewRow arrDataGridViewRow in arrDataGridViewRows)
        {
          int index2 = 0;
          foreach (DataGridViewCell cell in (BaseCollection) arrDataGridViewRow.Cells)
          {
            cell.DataGridViewInternal = this.mobjDataGridView;
            if (cell.ColumnIndex == -1)
              cell.OwningColumnInternal = this.DataGridView.Columns[index2];
            ++index2;
          }
          if (arrDataGridViewRow.HasHeaderCell)
          {
            arrDataGridViewRow.HeaderCell.DataGridViewInternal = this.DataGridView;
            arrDataGridViewRow.HeaderCell.OwningRowInternal = arrDataGridViewRow;
          }
          this.SharedList.Insert(index1, (object) arrDataGridViewRow);
          this.mobjRowStates.Insert(index1, arrDataGridViewRow.State);
          arrDataGridViewRow.IndexInternal = index1;
          arrDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
          ++index1;
        }
        this.DataGridView.OnInsertedRows_PreNotification(intRowIndex, arrDataGridViewRows);
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null), intRowIndex, arrDataGridViewRows.Length, false, true, false, objNewCurrentCell);
        this.DataGridView.OnInsertedRows_PostNotification(arrDataGridViewRows, objNewCurrentCell);
      }
    }

    internal void InvalidateCachedRowCount(DataGridViewElementStates enmIncludeFilter)
    {
      switch (enmIncludeFilter)
      {
        case DataGridViewElementStates.Frozen:
          this.mintRowCountsVisibleFrozen = -1;
          break;
        case DataGridViewElementStates.Selected:
          this.mintRowCountsVisibleSelected = -1;
          break;
        case DataGridViewElementStates.Visible:
          this.InvalidateCachedRowCounts();
          break;
      }
    }

    internal void InvalidateCachedRowCounts() => this.mintRowCountsVisible = this.mintRowCountsVisibleFrozen = this.mintRowCountsVisibleSelected = -1;

    internal void InvalidateCachedRowsHeight(DataGridViewElementStates enmIncludeFilter)
    {
      if (enmIncludeFilter == DataGridViewElementStates.Visible)
      {
        this.InvalidateCachedRowsHeights();
      }
      else
      {
        if (enmIncludeFilter != DataGridViewElementStates.Frozen)
          return;
        this.mintRowsHeightVisibleFrozen = -1;
      }
    }

    internal void InvalidateCachedRowsHeights() => this.mintRowsHeightVisible = this.mintRowsHeightVisibleFrozen = -1;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewRowCollection.CollectionChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
    protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
    {
      CollectionChangeEventHandler collectionChanged = this.CollectionChanged;
      if (collectionChanged == null)
        return;
      collectionChanged((object) this, e);
    }

    private void OnCollectionChanged(CollectionChangeEventArgs e, int intRowIndex, int intRowCount)
    {
      Point objNewCurrentCell = new Point(-1, -1);
      DataGridViewRow element = (DataGridViewRow) e.Element;
      int num = 0;
      if (element != null && e.Action == CollectionChangeAction.Add)
        num = this.SharedRow(intRowIndex).Index;
      this.OnCollectionChanged_PreNotification(e.Action, intRowIndex, intRowCount, ref element, false);
      if (num == -1 && this.SharedRow(intRowIndex).Index != -1)
        e = new CollectionChangeEventArgs(e.Action, (object) element);
      this.OnCollectionChanged(e);
      this.OnCollectionChanged_PostNotification(e.Action, intRowIndex, intRowCount, element, false, false, false, objNewCurrentCell);
    }

    private void OnCollectionChanged(
      CollectionChangeEventArgs e,
      int intRowIndex,
      int intRowCount,
      bool blnChangeIsDeletion,
      bool blnChangeIsInsertion,
      bool blnRecreateNewRow,
      Point objNewCurrentCell)
    {
      DataGridViewRow element = (DataGridViewRow) e.Element;
      int num = 0;
      if (element != null && e.Action == CollectionChangeAction.Add)
        num = this.SharedRow(intRowIndex).Index;
      this.OnCollectionChanged_PreNotification(e.Action, intRowIndex, intRowCount, ref element, blnChangeIsInsertion);
      if (num == -1 && this.SharedRow(intRowIndex).Index != -1)
        e = new CollectionChangeEventArgs(e.Action, (object) element);
      this.OnCollectionChanged(e);
      this.OnCollectionChanged_PostNotification(e.Action, intRowIndex, intRowCount, element, blnChangeIsDeletion, blnChangeIsInsertion, blnRecreateNewRow, objNewCurrentCell);
    }

    private void OnCollectionChanged_PostNotification(
      CollectionChangeAction enmCca,
      int intRowIndex,
      int intRowCount,
      DataGridViewRow objDataGridViewRow,
      bool blnChangeIsDeletion,
      bool blnChangeIsInsertion,
      bool blnRecreateNewRow,
      Point objNewCurrentCell)
    {
      if (blnChangeIsDeletion)
        this.DataGridView.OnRowsRemovedInternal(intRowIndex, intRowCount);
      else
        this.DataGridView.OnRowsAddedInternal(intRowIndex, intRowCount);
      switch (enmCca)
      {
        case CollectionChangeAction.Add:
          if (!blnChangeIsInsertion)
          {
            this.DataGridView.OnAddedRow_PostNotification(intRowIndex);
            break;
          }
          this.DataGridView.OnInsertedRow_PostNotification(intRowIndex, objNewCurrentCell, true);
          break;
        case CollectionChangeAction.Remove:
          this.DataGridView.OnRemovedRow_PostNotification(objDataGridViewRow, objNewCurrentCell);
          break;
        case CollectionChangeAction.Refresh:
          if (blnChangeIsDeletion)
          {
            this.DataGridView.OnClearedRows();
            break;
          }
          break;
      }
      this.DataGridView.OnRowCollectionChanged_PostNotification(blnRecreateNewRow, objNewCurrentCell.X == -1, enmCca, objDataGridViewRow, intRowIndex);
    }

    /// <summary>Called when [collection changed_ pre notification].</summary>
    /// <param name="enmCca">The cca.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="intRowCount">The row count.</param>
    /// <param name="objDataGridViewRow">The data grid view row.</param>
    /// <param name="blnChangeIsInsertion">if set to <c>true</c> [change is insertion].</param>
    private void OnCollectionChanged_PreNotification(
      CollectionChangeAction enmCca,
      int intRowIndex,
      int intRowCount,
      ref DataGridViewRow objDataGridViewRow,
      bool blnChangeIsInsertion)
    {
      bool flag1 = false;
      bool blnComputeVisibleRows = false;
      bool flag2;
      switch (enmCca)
      {
        case CollectionChangeAction.Add:
          int num1 = 0;
          this.UpdateRowCaches(intRowIndex, ref objDataGridViewRow, true);
          if ((this.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
          {
            int displayedRowIndex = this.DataGridView.FirstDisplayedRowIndex;
            if (displayedRowIndex != -1)
              num1 = this.SharedRow(displayedRowIndex).GetHeight(displayedRowIndex);
          }
          else
          {
            flag1 = true;
            blnComputeVisibleRows = blnChangeIsInsertion;
          }
          if (blnChangeIsInsertion)
          {
            this.DataGridView.OnInsertedRow_PreNotification(intRowIndex, 1);
            if (!flag1)
            {
              if ((this.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
              {
                flag2 = this.DataGridView.FirstDisplayedScrollingRowIndex == -1 && this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height);
                break;
              }
              if (this.DataGridView.FirstDisplayedScrollingRowIndex != -1 && intRowIndex > this.DataGridView.FirstDisplayedScrollingRowIndex)
              {
                flag2 = this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height + this.DataGridView.VerticalScrollingOffset) && num1 <= this.DataGridView.LayoutInfo.Data.Height;
                break;
              }
              break;
            }
            break;
          }
          this.DataGridView.OnAddedRow_PreNotification(intRowIndex);
          if (!flag1)
          {
            int num2 = this.GetRowsHeight(DataGridViewElementStates.Visible) - this.DataGridView.VerticalScrollingOffset - objDataGridViewRow.GetHeight(intRowIndex);
            objDataGridViewRow = this.SharedRow(intRowIndex);
            flag2 = this.DataGridView.LayoutInfo.Data.Height < num2 && num1 <= this.DataGridView.LayoutInfo.Data.Height;
            break;
          }
          break;
        case CollectionChangeAction.Remove:
          int rowState = (int) this.GetRowState(intRowIndex);
          bool flag3 = (rowState & 64) != 0;
          bool flag4 = (rowState & 2) != 0;
          this.mobjRowStates.RemoveAt(intRowIndex);
          this.SharedList.RemoveAt(intRowIndex);
          this.DataGridView.OnRemovedRow_PreNotification(intRowIndex);
          if (!flag3)
          {
            flag2 = true;
            break;
          }
          if (!flag4)
          {
            if (this.DataGridView.FirstDisplayedScrollingRowIndex != -1 && intRowIndex > this.DataGridView.FirstDisplayedScrollingRowIndex)
            {
              int num3 = 0;
              int displayedRowIndex = this.DataGridView.FirstDisplayedRowIndex;
              if (displayedRowIndex != -1)
                num3 = this.SharedRow(displayedRowIndex).GetHeight(displayedRowIndex);
              flag2 = this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height + this.DataGridView.VerticalScrollingOffset) && num3 <= this.DataGridView.LayoutInfo.Data.Height;
              break;
            }
            break;
          }
          flag2 = this.DataGridView.FirstDisplayedScrollingRowIndex == -1 && this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height);
          break;
        case CollectionChangeAction.Refresh:
          this.InvalidateCachedRowCounts();
          this.InvalidateCachedRowsHeights();
          break;
      }
      this.DataGridView.ResetUIState(false, blnComputeVisibleRows);
    }

    /// <summary>Removes the row from the collection.</summary>
    /// <param name="objDataGridViewRow">The row to remove from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewRow is the row for new records.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is bound to an <see cref="T:System.ComponentModel.IBindingList"></see> implementation with <see cref="P:System.ComponentModel.IBindingList.AllowRemove"></see> and <see cref="P:System.ComponentModel.IBindingList.SupportsChangeNotification"></see> property values that are not both true. </exception>
    /// <exception cref="T:System.ArgumentException">dataGridViewRow is not contained in this collection.-or-dataGridViewRow is a shared row.</exception>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Remove(DataGridViewRow objDataGridViewRow)
    {
      if (objDataGridViewRow == null)
        throw new ArgumentNullException("dataGridViewRow");
      if (objDataGridViewRow.DataGridView != this.DataGridView)
        throw new ArgumentException(SR.GetString("DataGridView_RowDoesNotBelongToDataGridView"), "dataGridViewRow");
      if (objDataGridViewRow.Index == -1)
        throw new ArgumentException(SR.GetString("DataGridView_RowMustBeUnshared"), "dataGridViewRow");
      this.RemoveAt(objDataGridViewRow.Index);
    }

    /// <summary>Removes the row at the specified position from the collection.</summary>
    /// <param name="index">The position of the row to remove.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero and greater than the number of rows in the collection minus one. </exception>
    /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-index is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is bound to an <see cref="T:System.ComponentModel.IBindingList"></see> implementation with <see cref="P:System.ComponentModel.IBindingList.AllowRemove"></see> and <see cref="P:System.ComponentModel.IBindingList.SupportsChangeNotification"></see> property values that are not both true.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void RemoveAt(int index)
    {
      if (index < 0 || index >= this.Count)
        throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
      if (this.DataGridView.NewRowIndex == index)
        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotDeleteNewRow"));
      if (this.DataGridView.NoDimensionChangeAllowed)
        throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
      if (this.DataGridView.DataSource != null)
      {
        if (!(this.DataGridView.DataConnection.List is IBindingList list) || !list.AllowRemove || !list.SupportsChangeNotification)
          throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CantRemoveRowsWithWrongSource"));
        list.RemoveAt(index);
      }
      else
        this.RemoveAtInternal(index, false);
    }

    internal void RemoveAtInternal(int index, bool blnForce)
    {
      DataGridViewRow dataGridViewRow1 = this.SharedRow(index);
      Point objNewCurrentCell = new Point(-1, -1);
      if (this.IsCollectionChangedListenedTo || dataGridViewRow1.GetDisplayed(index))
      {
        DataGridViewRow dataGridViewRow2 = this[index];
      }
      DataGridViewRow objDataGridViewRow = this.SharedRow(index);
      this.DataGridView.OnRemovingRow(index, out objNewCurrentCell, blnForce);
      this.UpdateRowCaches(index, ref objDataGridViewRow, false);
      if (objDataGridViewRow.Index != -1)
      {
        this.mobjRowStates[index] = objDataGridViewRow.State;
        objDataGridViewRow.DetachFromDataGridView();
      }
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, (object) objDataGridViewRow), index, 1, true, false, false, objNewCurrentCell);
    }

    private static bool RowHasValueOrToolTipText(DataGridViewRow objDataGridViewRow)
    {
      foreach (DataGridViewCell cell in (BaseCollection) objDataGridViewRow.Cells)
      {
        if (cell.HasValue || cell.HasToolTipText)
          return true;
      }
      return false;
    }

    /// <summary>Rows the is sharable.</summary>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    internal bool RowIsSharable(int index)
    {
      DataGridViewRow dataGridViewRow = this.SharedRow(index);
      if (dataGridViewRow.Index != -1)
        return false;
      foreach (DataGridViewCell cell in (BaseCollection) dataGridViewRow.Cells)
      {
        if ((cell.State & ~cell.CellStateFromColumnRowStates(this.mobjRowStates[index])) != DataGridViewElementStates.None)
          return false;
      }
      return true;
    }

    internal void SetRowState(
      int intRowIndex,
      DataGridViewElementStates enmElementState,
      bool blnValue)
    {
      DataGridViewRow dataGridViewRow = this.SharedRow(intRowIndex);
      if (dataGridViewRow.Index == -1)
      {
        if ((this.mobjRowStates[intRowIndex] & enmElementState) != 0 == blnValue)
          return;
        if (enmElementState == DataGridViewElementStates.Frozen || enmElementState == DataGridViewElementStates.Visible || enmElementState == DataGridViewElementStates.ReadOnly)
          dataGridViewRow.OnSharedStateChanging(intRowIndex, enmElementState);
        this.mobjRowStates[intRowIndex] = !blnValue ? this.mobjRowStates[intRowIndex] & ~enmElementState : this.mobjRowStates[intRowIndex] | enmElementState;
        dataGridViewRow.OnSharedStateChanged(intRowIndex, enmElementState);
      }
      else
      {
        switch (enmElementState)
        {
          case DataGridViewElementStates.Displayed:
            dataGridViewRow.DisplayedInternal = blnValue;
            break;
          case DataGridViewElementStates.Frozen:
            dataGridViewRow.Frozen = blnValue;
            break;
          case DataGridViewElementStates.ReadOnly:
            dataGridViewRow.ReadOnlyInternal = blnValue;
            break;
          case DataGridViewElementStates.Resizable:
            dataGridViewRow.Resizable = blnValue ? DataGridViewTriState.True : DataGridViewTriState.False;
            break;
          case DataGridViewElementStates.Selected:
            dataGridViewRow.SelectedInternal = blnValue;
            break;
          case DataGridViewElementStates.Visible:
            dataGridViewRow.Visible = blnValue;
            break;
        }
      }
    }

    /// <summary>Returns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> at the specified index.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> positioned at the specified index.</returns>
    /// <param name="intRowIndex">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to get.</param>
    /// <filterpriority>1</filterpriority>
    public DataGridViewRow SharedRow(int intRowIndex) => (DataGridViewRow) this.SharedList[intRowIndex];

    internal DataGridViewElementStates SharedRowState(int intRowIndex) => this.mobjRowStates[intRowIndex];

    internal void Sort(IComparer objCustomComparer, bool blnAscending)
    {
      if (this.mobjItems.Count <= 0)
        return;
      this.mobjItems.CustomSort(new DataGridViewRowCollection.RowComparer(this, objCustomComparer, blnAscending));
    }

    internal void SwapSortedRows(int intRowIndex1, int intRowIndex2)
    {
      this.DataGridView.SwapSortedRows(intRowIndex1, intRowIndex2);
      DataGridViewRow dataGridViewRow1 = this.SharedRow(intRowIndex1);
      DataGridViewRow dataGridViewRow2 = this.SharedRow(intRowIndex2);
      if (dataGridViewRow1.Index != -1)
        dataGridViewRow1.IndexInternal = intRowIndex2;
      if (dataGridViewRow2.Index != -1)
        dataGridViewRow2.IndexInternal = intRowIndex1;
      if (this.DataGridView.VirtualMode)
      {
        int count = this.DataGridView.Columns.Count;
        for (int index = 0; index < count; ++index)
        {
          DataGridViewCell cell1 = dataGridViewRow1.Cells[index];
          DataGridViewCell cell2 = dataGridViewRow2.Cells[index];
          object valueInternal1 = cell1.GetValueInternal(intRowIndex1);
          object valueInternal2 = cell2.GetValueInternal(intRowIndex2);
          cell1.SetValueInternal(intRowIndex1, valueInternal2);
          cell2.SetValueInternal(intRowIndex2, valueInternal1);
        }
      }
      object mobjItem = this.mobjItems[intRowIndex1];
      this.mobjItems[intRowIndex1] = this.mobjItems[intRowIndex2];
      this.mobjItems[intRowIndex2] = mobjItem;
      DataGridViewElementStates mobjRowState = this.mobjRowStates[intRowIndex1];
      this.mobjRowStates[intRowIndex1] = this.mobjRowStates[intRowIndex2];
      this.mobjRowStates[intRowIndex2] = mobjRowState;
    }

    void ICollection.CopyTo(Array objArray, int index) => this.mobjItems.CopyTo(objArray, index);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new DataGridViewRowCollection.UnsharingRowEnumerator(this);

    int IList.Add(object objValue) => this.Add((DataGridViewRow) objValue);

    void IList.Clear() => this.Clear();

    bool IList.Contains(object objValue) => this.mobjItems.Contains(objValue);

    int IList.IndexOf(object objValue) => this.mobjItems.IndexOf(objValue);

    void IList.Insert(int index, object objValue) => this.Insert(index, (DataGridViewRow) objValue);

    void IList.Remove(object objValue) => this.Remove((DataGridViewRow) objValue);

    void IList.RemoveAt(int index) => this.RemoveAt(index);

    private void UnshareRow(int intRowIndex)
    {
      this.SharedRow(intRowIndex).IndexInternal = intRowIndex;
      this.SharedRow(intRowIndex).StateInternal = this.SharedRowState(intRowIndex);
    }

    private void UpdateRowCaches(
      int intRowIndex,
      ref DataGridViewRow objDataGridViewRow,
      bool blnAdding)
    {
      if (this.mintRowCountsVisible == -1 && this.mintRowCountsVisibleFrozen == -1 && this.mintRowCountsVisibleSelected == -1 && this.mintRowsHeightVisible == -1 && this.mintRowsHeightVisibleFrozen == -1)
        return;
      DataGridViewElementStates rowState = this.GetRowState(intRowIndex);
      if ((rowState & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
        return;
      int num1 = blnAdding ? 1 : -1;
      int num2 = 0;
      if (this.mintRowsHeightVisible != -1 || this.mintRowsHeightVisibleFrozen != -1 && (rowState & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
      {
        num2 = blnAdding ? objDataGridViewRow.GetHeight(intRowIndex) : -objDataGridViewRow.GetHeight(intRowIndex);
        objDataGridViewRow = this.SharedRow(intRowIndex);
      }
      if (this.mintRowCountsVisible != -1)
        this.mintRowCountsVisible += num1;
      if (this.mintRowsHeightVisible != -1)
        this.mintRowsHeightVisible += num2;
      if ((rowState & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
      {
        if (this.mintRowCountsVisibleFrozen != -1)
          this.mintRowCountsVisibleFrozen += num1;
        if (this.mintRowsHeightVisibleFrozen != -1)
          this.mintRowsHeightVisibleFrozen += num2;
      }
      if ((rowState & (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) || this.mintRowCountsVisibleSelected == -1)
        return;
      this.mintRowCountsVisibleSelected += num1;
    }

    /// <summary>Gets the number of rows in the collection.</summary>
    /// <returns>The number of rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public int Count => this.mobjItems.Count;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the collection.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
    protected DataGridView DataGridView => this.mobjDataGridView;

    internal bool IsCollectionChangedListenedTo => this.CollectionChanged != null;

    /// <summary>Gets the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index. Accessing a <see cref="T:System.Windows.Forms.DataGridViewRow"></see> with this indexer causes the row to become unshared. To keep the row shared, use the <see cref="M:System.Windows.Forms.DataGridViewRowCollection.SharedRow(System.Int32)"></see> method. For more information, see Best Practices for Scaling the Windows Forms DataGridView Control.</returns>
    /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> to get.</param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public DataGridViewRow this[int index]
    {
      get
      {
        DataGridViewRow objDataGridViewRow2_1 = this.SharedRow(index);
        if (objDataGridViewRow2_1.Index != -1)
          return objDataGridViewRow2_1;
        if (index == 0 && this.mobjItems.Count == 1)
        {
          objDataGridViewRow2_1.IndexInternal = 0;
          objDataGridViewRow2_1.StateInternal = this.SharedRowState(0);
          if (this.DataGridView != null)
            this.DataGridView.OnRowUnshared(objDataGridViewRow2_1);
          return objDataGridViewRow2_1;
        }
        DataGridViewRow objDataGridViewRow2_2 = (DataGridViewRow) objDataGridViewRow2_1.Clone();
        objDataGridViewRow2_2.IndexInternal = index;
        objDataGridViewRow2_2.DataGridViewInternal = objDataGridViewRow2_1.DataGridView;
        objDataGridViewRow2_2.StateInternal = this.SharedRowState(index);
        this.SharedList[index] = (object) objDataGridViewRow2_2;
        int index1 = 0;
        foreach (DataGridViewCell cell in (BaseCollection) objDataGridViewRow2_2.Cells)
        {
          cell.DataGridViewInternal = objDataGridViewRow2_1.DataGridView;
          cell.OwningRowInternal = objDataGridViewRow2_2;
          cell.OwningColumnInternal = this.DataGridView.Columns[index1];
          ++index1;
        }
        if (objDataGridViewRow2_2.HasHeaderCell)
        {
          objDataGridViewRow2_2.HeaderCell.DataGridViewInternal = objDataGridViewRow2_1.DataGridView;
          objDataGridViewRow2_2.HeaderCell.OwningRowInternal = objDataGridViewRow2_2;
        }
        if (this.DataGridView != null)
          this.DataGridView.OnRowUnshared(objDataGridViewRow2_2);
        return objDataGridViewRow2_2;
      }
    }

    /// <summary>Gets an array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</summary>
    /// <returns>An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</returns>
    protected ArrayList List
    {
      get
      {
        int count = this.Count;
        for (int index = 0; index < count; ++index)
        {
          DataGridViewRow dataGridViewRow = this[index];
        }
        return (ArrayList) this.mobjItems;
      }
    }

    internal ArrayList SharedList => (ArrayList) this.mobjItems;

    int ICollection.Count => this.Count;

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
    private class RowArrayList : ArrayList
    {
      private DataGridViewRowCollection mobjOwner;
      private DataGridViewRowCollection.RowComparer mobjRowComparer;

      public RowArrayList(DataGridViewRowCollection objOwner) => this.mobjOwner = objOwner;

      private void CustomQuickSort(int intLeft, int intRight)
      {
        if (intRight - intLeft < 2)
        {
          if (intRight - intLeft <= 0 || this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intLeft), this.mobjRowComparer.GetComparedObject(intRight), intLeft, intRight) <= 0)
            return;
          this.mobjOwner.SwapSortedRows(intLeft, intRight);
        }
        else
        {
          do
          {
            int num1 = intLeft + intRight >> 1;
            object obj = this.Pivot(intLeft, num1, intRight);
            int num2 = intLeft + 1;
            int num3 = intRight - 1;
            while (true)
            {
              do
              {
                if (num1 == num2 || this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(num2), obj, num2, num1) >= 0)
                {
                  while (num1 != num3 && this.mobjRowComparer.CompareObjects(obj, this.mobjRowComparer.GetComparedObject(num3), num1, num3) < 0)
                    --num3;
                  if (num2 <= num3)
                  {
                    if (num2 < num3)
                    {
                      this.mobjOwner.SwapSortedRows(num2, num3);
                      if (num2 == num1)
                        num1 = num3;
                      else if (num3 == num1)
                        num1 = num2;
                    }
                    ++num2;
                    --num3;
                  }
                  else
                    break;
                }
                else
                  goto label_4;
              }
              while (num2 <= num3);
              break;
label_4:
              ++num2;
            }
            if (num3 - intLeft <= intRight - num2)
            {
              if (intLeft < num3)
                this.CustomQuickSort(intLeft, num3);
              intLeft = num2;
            }
            else
            {
              if (num2 < intRight)
                this.CustomQuickSort(num2, intRight);
              intRight = num3;
            }
          }
          while (intLeft < intRight);
        }
      }

      public void CustomSort(
        DataGridViewRowCollection.RowComparer objRowComparer)
      {
        this.mobjRowComparer = objRowComparer;
        this.CustomQuickSort(0, this.Count - 1);
      }

      private object Pivot(int intLeft, int intCenter, int intRight)
      {
        if (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intLeft), this.mobjRowComparer.GetComparedObject(intCenter), intLeft, intCenter) > 0)
          this.mobjOwner.SwapSortedRows(intLeft, intCenter);
        if (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intLeft), this.mobjRowComparer.GetComparedObject(intRight), intLeft, intRight) > 0)
          this.mobjOwner.SwapSortedRows(intLeft, intRight);
        if (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intCenter), this.mobjRowComparer.GetComparedObject(intRight), intCenter, intRight) > 0)
          this.mobjOwner.SwapSortedRows(intCenter, intRight);
        return this.mobjRowComparer.GetComparedObject(intCenter);
      }
    }

    [Serializable]
    private class RowComparer
    {
      private bool mblnAscending;
      private IComparer mobjCustomComparer;
      private DataGridView mobjDataGridView;
      private DataGridViewRowCollection mobjDataGridViewRows;
      private DataGridViewColumn mobjDataGridViewSortedColumn;
      private static DataGridViewRowCollection.RowComparer.ComparedObjectMax mobjMax = new DataGridViewRowCollection.RowComparer.ComparedObjectMax();
      private int mintSortedColumnIndex;

      public RowComparer(
        DataGridViewRowCollection objDataGridViewRows,
        IComparer objCustomComparer,
        bool blnAscending)
      {
        this.mobjDataGridView = objDataGridViewRows.DataGridView;
        this.mobjDataGridViewRows = objDataGridViewRows;
        this.mobjDataGridViewSortedColumn = this.mobjDataGridView.SortedColumn;
        this.mintSortedColumnIndex = this.mobjDataGridViewSortedColumn != null ? this.mobjDataGridViewSortedColumn.Index : -1;
        this.mobjCustomComparer = objCustomComparer;
        this.mblnAscending = blnAscending;
      }

      internal int CompareObjects(
        object objValue1,
        object objValue2,
        int intRowIndex1,
        int intRowIndex2)
      {
        if (objValue1 is DataGridViewRowCollection.RowComparer.ComparedObjectMax)
          return 1;
        if (objValue2 is DataGridViewRowCollection.RowComparer.ComparedObjectMax)
          return -1;
        int intSortResult = 0;
        if (this.mobjCustomComparer == null)
        {
          if (!this.mobjDataGridView.OnSortCompare(this.mobjDataGridViewSortedColumn, objValue1, objValue2, intRowIndex1, intRowIndex2, out intSortResult))
          {
            intSortResult = objValue1 is IComparable || objValue2 is IComparable ? Comparer.Default.Compare(objValue1, objValue2) : (objValue1 != null ? (objValue2 != null ? Comparer.Default.Compare((object) objValue1.ToString(), (object) objValue2.ToString()) : -1) : (objValue2 != null ? 1 : 0));
            if (intSortResult == 0)
              intSortResult = !this.mblnAscending ? intRowIndex2 - intRowIndex1 : intRowIndex1 - intRowIndex2;
          }
        }
        else
          intSortResult = this.mobjCustomComparer.Compare(objValue1, objValue2);
        return this.mblnAscending ? intSortResult : -intSortResult;
      }

      internal object GetComparedObject(int intRowIndex)
      {
        if (this.mobjDataGridView.NewRowIndex != -1 && intRowIndex == this.mobjDataGridView.NewRowIndex)
          return (object) DataGridViewRowCollection.RowComparer.mobjMax;
        return this.mobjCustomComparer == null ? this.mobjDataGridViewRows.SharedRow(intRowIndex).Cells[this.mintSortedColumnIndex].GetValueInternal(intRowIndex) : (object) this.mobjDataGridViewRows[intRowIndex];
      }

      [Serializable]
      private class ComparedObjectMax
      {
      }
    }

    [Serializable]
    private class UnsharingRowEnumerator : IEnumerator
    {
      private int mintCurrent;
      private DataGridViewRowCollection mobjOwner;

      public UnsharingRowEnumerator(DataGridViewRowCollection objOwner)
      {
        this.mobjOwner = objOwner;
        this.mintCurrent = -1;
      }

      bool IEnumerator.MoveNext()
      {
        if (this.mintCurrent < this.mobjOwner.Count - 1)
        {
          ++this.mintCurrent;
          return true;
        }
        this.mintCurrent = this.mobjOwner.Count;
        return false;
      }

      void IEnumerator.Reset() => this.mintCurrent = -1;

      object IEnumerator.Current
      {
        get
        {
          if (this.mintCurrent == -1)
            throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_EnumNotStarted"));
          if (this.mintCurrent == this.mobjOwner.Count)
            throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_EnumFinished"));
          return (object) this.mobjOwner[this.mintCurrent];
        }
      }
    }
  }
}
