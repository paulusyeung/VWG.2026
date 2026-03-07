// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a collection of cells in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [ListBindable(false)]
  [Serializable]
  public class DataGridViewCellCollection : BaseCollection, IList, ICollection, IEnumerable
  {
    private ArrayList mobjItems;
    private DataGridViewRow mobjOwner;

    /// <summary>Occurs when the collection is changed. </summary>
    /// <filterpriority>1</filterpriority>
    public event CollectionChangeEventHandler CollectionChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
    /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that owns the collection.</param>
    public DataGridViewCellCollection(DataGridViewRow objDataGridViewRow)
    {
      this.mobjItems = new ArrayList();
      this.mobjOwner = objDataGridViewRow;
    }

    /// <summary>Adds a cell to the collection.</summary>
    /// <returns>The position in which to insert the new element.</returns>
    /// <param name="objDataGridViewCell">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to add to the collection.</param>
    /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-dataGridViewCell already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual int Add(DataGridViewCell objDataGridViewCell)
    {
      if (this.mobjOwner.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
      return objDataGridViewCell.OwningRow == null ? this.AddInternal(objDataGridViewCell) : throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
    }

    internal int AddInternal(DataGridViewCell objDataGridViewCell)
    {
      int index = this.mobjItems.Add((object) objDataGridViewCell);
      objDataGridViewCell.OwningRowInternal = this.mobjOwner;
      DataGridView dataGridView = this.mobjOwner.DataGridView;
      if (dataGridView != null && dataGridView.Columns.Count > index)
        objDataGridViewCell.OwningColumnInternal = dataGridView.Columns[index];
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewCell));
      return index;
    }

    /// <summary>Adds an array of cells to the collection.</summary>
    /// <param name="arrDataGridViewCells">The array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> objects to add to the collection.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewCells is null.</exception>
    /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-At least one value in dataGridViewCells is null.-or-At least one cell in dataGridViewCells already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.-or-At least two values in dataGridViewCells are references to the same <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual void AddRange(params DataGridViewCell[] arrDataGridViewCells)
    {
      if (arrDataGridViewCells == null)
        throw new ArgumentNullException("dataGridViewCells");
      if (this.mobjOwner.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
      foreach (DataGridViewCell dataGridViewCell in arrDataGridViewCells)
      {
        if (dataGridViewCell == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_AtLeastOneCellIsNull"));
        if (dataGridViewCell.OwningRow != null)
          throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
      }
      int length = arrDataGridViewCells.Length;
      for (int index1 = 0; index1 < length - 1; ++index1)
      {
        for (int index2 = index1 + 1; index2 < length; ++index2)
        {
          if (arrDataGridViewCells[index1] == arrDataGridViewCells[index2])
            throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CannotAddIdenticalCells"));
        }
      }
      this.mobjItems.AddRange((ICollection) arrDataGridViewCells);
      foreach (DataGridViewCell dataGridViewCell in arrDataGridViewCells)
        dataGridViewCell.OwningRowInternal = this.mobjOwner;
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null));
    }

    /// <summary>Clears all cells from the collection.</summary>
    /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Clear()
    {
      if (this.mobjOwner.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
      foreach (DataGridViewCell mobjItem in this.mobjItems)
        mobjItem.OwningRowInternal = (DataGridViewRow) null;
      this.mobjItems.Clear();
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null));
    }

    /// <summary>Determines whether the specified cell is contained in the collection.</summary>
    /// <returns>true if dataGridViewCell is in the collection; otherwise, false.</returns>
    /// <param name="objDataGridViewCell">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to locate in the collection.</param>
    /// <filterpriority>1</filterpriority>
    public virtual bool Contains(DataGridViewCell objDataGridViewCell) => this.mobjItems.IndexOf((object) objDataGridViewCell) != -1;

    /// <summary>Copies the entire collection of cells into an array at a specified location within the array.</summary>
    /// <param name="arrCells">The destination array to which the contents will be copied.</param>
    /// <param name="index">The index of the element in array at which to start copying.</param>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(DataGridViewCell[] arrCells, int index) => this.mobjItems.CopyTo((Array) arrCells, index);

    /// <summary>Returns the index of the specified cell.</summary>
    /// <returns>The zero-based index of the value of dataGridViewCell parameter, if it is found in the collection; otherwise, -1.</returns>
    /// <param name="objDataGridViewCell">The cell to locate in the collection.</param>
    /// <filterpriority>1</filterpriority>
    public int IndexOf(DataGridViewCell objDataGridViewCell) => this.mobjItems.IndexOf((object) objDataGridViewCell);

    /// <summary>Inserts a cell into the collection at the specified index. </summary>
    /// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to insert.</param>
    /// <param name="index">The zero-based index at which to place dataGridViewCell.</param>
    /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-dataGridViewCell already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Insert(int index, DataGridViewCell objDataGridViewCell)
    {
      if (this.mobjOwner.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
      if (objDataGridViewCell.OwningRow != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
      this.mobjItems.Insert(index, (object) objDataGridViewCell);
      objDataGridViewCell.OwningRowInternal = this.mobjOwner;
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewCell));
    }

    internal void InsertInternal(int index, DataGridViewCell objDataGridViewCell)
    {
      this.mobjItems.Insert(index, (object) objDataGridViewCell);
      objDataGridViewCell.OwningRowInternal = this.mobjOwner;
      DataGridView dataGridView = this.mobjOwner.DataGridView;
      if (dataGridView != null && dataGridView.Columns.Count > index)
        objDataGridViewCell.OwningColumnInternal = dataGridView.Columns[index];
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objDataGridViewCell));
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewCellCollection.CollectionChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
    protected void OnCollectionChanged(CollectionChangeEventArgs e)
    {
      CollectionChangeEventHandler collectionChanged = this.CollectionChanged;
      if (collectionChanged == null)
        return;
      collectionChanged((object) this, e);
    }

    /// <summary>Removes the specified cell from the collection.</summary>
    /// <param name="objCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to remove from the collection.</param>
    /// <exception cref="T:System.ArgumentException">cell could not be found in the collection.</exception>
    /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void Remove(DataGridViewCell objCell)
    {
      if (this.mobjOwner.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
      int index1 = -1;
      int count = this.mobjItems.Count;
      for (int index2 = 0; index2 < count; ++index2)
      {
        if (this.mobjItems[index2] == objCell)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
        throw new ArgumentException(SR.GetString("DataGridViewCellCollection_CellNotFound"));
      this.RemoveAt(index1);
    }

    /// <summary>Removes the cell at the specified index.</summary>
    /// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to be removed.</param>
    /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void RemoveAt(int index)
    {
      if (this.mobjOwner.DataGridView != null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
      this.RemoveAtInternal(index);
    }

    internal void RemoveAtInternal(int index)
    {
      DataGridViewCell mobjItem = (DataGridViewCell) this.mobjItems[index];
      this.mobjItems.RemoveAt(index);
      mobjItem.DataGridViewInternal = (DataGridView) null;
      mobjItem.OwningRowInternal = (DataGridViewRow) null;
      if (mobjItem.ReadOnly)
        mobjItem.ReadOnlyInternal = false;
      if (mobjItem.Selected && this.mobjOwner != null && this.mobjOwner.DataGridView != null)
        this.mobjOwner.DataGridView.SetSelectedCellCore(mobjItem, false, false);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, (object) mobjItem));
    }

    void ICollection.CopyTo(Array objArray, int index) => this.mobjItems.CopyTo(objArray, index);

    IEnumerator IEnumerable.GetEnumerator() => this.mobjItems.GetEnumerator();

    int IList.Add(object objValue) => this.Add((DataGridViewCell) objValue);

    void IList.Clear() => this.Clear();

    bool IList.Contains(object objValue) => this.mobjItems.Contains(objValue);

    int IList.IndexOf(object objValue) => this.mobjItems.IndexOf(objValue);

    void IList.Insert(int index, object objValue) => this.Insert(index, (DataGridViewCell) objValue);

    void IList.Remove(object objValue) => this.Remove((DataGridViewCell) objValue);

    void IList.RemoveAt(int index) => this.RemoveAt(index);

    /// <summary>Gets or sets the cell at the provided index location. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> stored at the given index.</returns>
    /// <param name="index">The zero-based index of the cell to get or set.</param>
    /// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewCell this[int index]
    {
      get => (DataGridViewCell) this.mobjItems[index];
      set
      {
        DataGridViewCell dataGridViewCell = value;
        if (dataGridViewCell == null)
          throw new ArgumentNullException(nameof (value));
        if (dataGridViewCell.DataGridView != null)
          throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridView"));
        if (dataGridViewCell.OwningRow != null)
          throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
        if (this.mobjOwner.DataGridView != null)
          this.mobjOwner.DataGridView.OnReplacingCell(this.mobjOwner, index);
        DataGridViewCell mobjItem = (DataGridViewCell) this.mobjItems[index];
        this.mobjItems[index] = (object) dataGridViewCell;
        dataGridViewCell.OwningRowInternal = this.mobjOwner;
        dataGridViewCell.StateInternal = mobjItem.State;
        if (this.mobjOwner.DataGridView != null)
        {
          dataGridViewCell.DataGridViewInternal = this.mobjOwner.DataGridView;
          dataGridViewCell.OwningColumnInternal = this.mobjOwner.DataGridView.Columns[index];
          this.mobjOwner.DataGridView.OnReplacedCell(this.mobjOwner, index);
        }
        mobjItem.DataGridViewInternal = (DataGridView) null;
        mobjItem.OwningRowInternal = (DataGridViewRow) null;
        mobjItem.OwningColumnInternal = (DataGridViewColumn) null;
        if (mobjItem.ReadOnly)
          mobjItem.ReadOnlyInternal = false;
        if (!mobjItem.Selected || this.mobjOwner == null || this.mobjOwner.DataGridView == null)
          return;
        this.mobjOwner.DataGridView.SetSelectedCellCore(mobjItem, false, false);
      }
    }

    /// <summary>Gets or sets the cell in the column with the provided name. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> stored in the column with the given name.</returns>
    /// <param name="strColumnName">The name of the column in which to get or set the cell.</param>
    /// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <exception cref="T:System.ArgumentException">columnName does not match the name of any columns in the control.</exception>
    /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
    /// <filterpriority>1</filterpriority>
    public DataGridViewCell this[string strColumnName]
    {
      get
      {
        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) null;
        if (this.mobjOwner.DataGridView != null)
          dataGridViewColumn = this.mobjOwner.DataGridView.Columns[strColumnName];
        if (dataGridViewColumn == null)
          throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", (object) strColumnName), "columnName");
        return (DataGridViewCell) this.mobjItems[dataGridViewColumn.Index];
      }
      set
      {
        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn) null;
        if (this.mobjOwner.DataGridView != null)
          dataGridViewColumn = this.mobjOwner.DataGridView.Columns[strColumnName];
        if (dataGridViewColumn == null)
          throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", (object) strColumnName), "columnName");
        this[dataGridViewColumn.Index] = value;
      }
    }

    /// <summary>Gets an <see cref="T:System.Collections.ArrayList"></see> containing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> objects.</summary>
    /// <returns><see cref="T:System.Collections.ArrayList"></see>.</returns>
    protected override ArrayList List => this.mobjItems;

    int ICollection.Count => this.mobjItems.Count;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => (object) this;

    bool IList.IsFixedSize => false;

    bool IList.IsReadOnly => false;

    object IList.this[int index]
    {
      get => (object) this[index];
      set => this[index] = (DataGridViewCell) value;
    }
  }
}
