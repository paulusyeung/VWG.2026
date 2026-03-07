// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects that are selected in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [ListBindable(false)]
  [Serializable]
  public class DataGridViewSelectedColumnCollection : BaseCollection, IList, ICollection, IEnumerable
  {
    private ArrayList mobjItems;

    internal DataGridViewSelectedColumnCollection() => this.mobjItems = new ArrayList();

    internal int Add(DataGridViewColumn objDataGridViewColumn) => this.mobjItems.Add((object) objDataGridViewColumn);

    /// <summary>Clears the collection.</summary>
    /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Clear() => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    /// <summary>Determines whether the specified column is contained in the collection.</summary>
    /// <returns>true if the dataGridViewColumn parameter is in the collection; otherwise, false.</returns>
    /// <param name="objDataGridViewColumn">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see>.</param>
    /// <filterpriority>1</filterpriority>
    public bool Contains(DataGridViewColumn objDataGridViewColumn) => this.mobjItems.IndexOf((object) objDataGridViewColumn) != -1;

    /// <summary>Copies the elements of the collection to the specified array, starting at the specified index.</summary>
    /// <param name="arrColumns">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in the array at which copying begins.</param>
    /// <exception cref="T:System.InvalidCastException">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> cannot be cast automatically to the type of array.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
    /// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> is greater than the available space from index to the end of array.</exception>
    /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(DataGridViewColumn[] arrColumns, int index) => this.mobjItems.CopyTo((Array) arrColumns, index);

    /// <summary>Inserts a column into the collection at the specified position.</summary>
    /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see>.</param>
    /// <param name="index">The zero-based index at which the column should be inserted. </param>
    /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Insert(int index, DataGridViewColumn objDataGridViewColumn) => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    void ICollection.CopyTo(Array objArray, int index) => this.mobjItems.CopyTo(objArray, index);

    IEnumerator IEnumerable.GetEnumerator() => this.mobjItems.GetEnumerator();

    int IList.Add(object objValue) => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    void IList.Clear() => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    bool IList.Contains(object objValue) => this.mobjItems.Contains(objValue);

    int IList.IndexOf(object objValue) => this.mobjItems.IndexOf(objValue);

    void IList.Insert(int index, object objValue) => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    void IList.Remove(object objValue) => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    void IList.RemoveAt(int index) => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));

    /// <summary>Gets the column at the specified index.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> at the specified index.</returns>
    /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to get from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see>.</param>
    /// <filterpriority>1</filterpriority>
    public DataGridViewColumn this[int index] => (DataGridViewColumn) this.mobjItems[index];

    /// <summary>
    /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
    /// </summary>
    /// <value></value>
    /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
    protected override ArrayList List => this.mobjItems;

    int ICollection.Count => this.mobjItems.Count;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => (object) this;

    bool IList.IsFixedSize => true;

    bool IList.IsReadOnly => true;

    object IList.this[int index]
    {
      get => this.mobjItems[index];
      set => throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
    }
  }
}
