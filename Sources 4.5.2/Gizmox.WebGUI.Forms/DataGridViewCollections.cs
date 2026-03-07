#region Using

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System.Collections.Generic;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region DataGridViewCellCollection Class

    /// <summary>Represents a collection of cells in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ListBindable(false)]
    [Serializable()]
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
            }
            if (objDataGridViewCell.OwningRow != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
            }
            return this.AddInternal(objDataGridViewCell);
        }

        internal int AddInternal(DataGridViewCell objDataGridViewCell)
        {
            int num1 = this.mobjItems.Add(objDataGridViewCell);
            objDataGridViewCell.OwningRowInternal = this.mobjOwner;
            DataGridView objDataGridView = this.mobjOwner.DataGridView;
            if ((objDataGridView != null) && (objDataGridView.Columns.Count > num1))
            {
                objDataGridViewCell.OwningColumnInternal = objDataGridView.Columns[num1];
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewCell));
            return num1;
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
            {
                throw new ArgumentNullException("dataGridViewCells");
            }
            if (this.mobjOwner.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
            }
            foreach (DataGridViewCell objCell1 in arrDataGridViewCells)
            {
                if (objCell1 == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_AtLeastOneCellIsNull"));
                }
                if (objCell1.OwningRow != null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
                }
            }
            int num1 = arrDataGridViewCells.Length;
            for (int num2 = 0; num2 < (num1 - 1); num2++)
            {
                for (int num3 = num2 + 1; num3 < num1; num3++)
                {
                    if (arrDataGridViewCells[num2] == arrDataGridViewCells[num3])
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CannotAddIdenticalCells"));
                    }
                }
            }
            this.mobjItems.AddRange(arrDataGridViewCells);
            foreach (DataGridViewCell objCell2 in arrDataGridViewCells)
            {
                objCell2.OwningRowInternal = this.mobjOwner;
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>Clears all cells from the collection.</summary>
        /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void Clear()
        {
            if (this.mobjOwner.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
            }
            foreach (DataGridViewCell objCell1 in this.mobjItems)
            {
                objCell1.OwningRowInternal = null;
            }
            this.mobjItems.Clear();
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>Determines whether the specified cell is contained in the collection.</summary>
        /// <returns>true if dataGridViewCell is in the collection; otherwise, false.</returns>
        /// <param name="objDataGridViewCell">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to locate in the collection.</param>
        /// <filterpriority>1</filterpriority>
        public virtual bool Contains(DataGridViewCell objDataGridViewCell)
        {
            int num1 = this.mobjItems.IndexOf(objDataGridViewCell);
            return (num1 != -1);
        }

        /// <summary>Copies the entire collection of cells into an array at a specified location within the array.</summary>
        /// <param name="arrCells">The destination array to which the contents will be copied.</param>
        /// <param name="index">The index of the element in array at which to start copying.</param>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(DataGridViewCell[] arrCells, int index)
        {
            this.mobjItems.CopyTo(arrCells, index);
        }

        /// <summary>Returns the index of the specified cell.</summary>
        /// <returns>The zero-based index of the value of dataGridViewCell parameter, if it is found in the collection; otherwise, -1.</returns>
        /// <param name="objDataGridViewCell">The cell to locate in the collection.</param>
        /// <filterpriority>1</filterpriority>
        public int IndexOf(DataGridViewCell objDataGridViewCell)
        {
            return this.mobjItems.IndexOf(objDataGridViewCell);
        }

        /// <summary>Inserts a cell into the collection at the specified index. </summary>
        /// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to insert.</param>
        /// <param name="index">The zero-based index at which to place dataGridViewCell.</param>
        /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-dataGridViewCell already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void Insert(int index, DataGridViewCell objDataGridViewCell)
        {
            if (this.mobjOwner.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
            }
            if (objDataGridViewCell.OwningRow != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
            }
            this.mobjItems.Insert(index, objDataGridViewCell);
            objDataGridViewCell.OwningRowInternal = this.mobjOwner;
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewCell));
        }

        internal void InsertInternal(int index, DataGridViewCell objDataGridViewCell)
        {
            this.mobjItems.Insert(index, objDataGridViewCell);
            objDataGridViewCell.OwningRowInternal = this.mobjOwner;
            DataGridView objDataGridView = this.mobjOwner.DataGridView;
            if ((objDataGridView != null) && (objDataGridView.Columns.Count > index))
            {
                objDataGridViewCell.OwningColumnInternal = objDataGridView.Columns[index];
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewCell));
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewCellCollection.CollectionChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
        protected void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            // Raise event if needed
            CollectionChangeEventHandler objEventHandler = this.CollectionChanged;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Removes the specified cell from the collection.</summary>
        /// <param name="objCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to remove from the collection.</param>
        /// <exception cref="T:System.ArgumentException">cell could not be found in the collection.</exception>
        /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void Remove(DataGridViewCell objCell)
        {
            if (this.mobjOwner.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
            }
            int num1 = -1;
            int num2 = this.mobjItems.Count;
            for (int num3 = 0; num3 < num2; num3++)
            {
                if (this.mobjItems[num3] == objCell)
                {
                    num1 = num3;
                    break;
                }
            }
            if (num1 == -1)
            {
                throw new ArgumentException(SR.GetString("DataGridViewCellCollection_CellNotFound"));
            }
            this.RemoveAt(num1);
        }

        /// <summary>Removes the cell at the specified index.</summary>
        /// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to be removed.</param>
        /// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        /// <filterpriority>1</filterpriority>

        public virtual void RemoveAt(int index)
        {
            if (this.mobjOwner.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
            }
            this.RemoveAtInternal(index);
        }

        internal void RemoveAtInternal(int index)
        {
            DataGridViewCell objCell1 = (DataGridViewCell)this.mobjItems[index];
            this.mobjItems.RemoveAt(index);
            objCell1.DataGridViewInternal = null;
            objCell1.OwningRowInternal = null;
            if (objCell1.ReadOnly)
            {
                objCell1.ReadOnlyInternal = false;
            }
            if (objCell1.Selected)
            {
                if (this.mobjOwner != null && this.mobjOwner.DataGridView != null)
                {
                    this.mobjOwner.DataGridView.SetSelectedCellCore(objCell1, false, false);
                }
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, objCell1));
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.mobjItems.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.mobjItems.GetEnumerator();
        }

        int IList.Add(object objValue)
        {
            return this.Add((DataGridViewCell)objValue);
        }

        void IList.Clear()
        {
            this.Clear();
        }

        bool IList.Contains(object objValue)
        {
            return this.mobjItems.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjItems.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            this.Insert(index, (DataGridViewCell)objValue);
        }

        void IList.Remove(object objValue)
        {
            this.Remove((DataGridViewCell)objValue);
        }

        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }


        /// <summary>Gets or sets the cell at the provided index location. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> stored at the given index.</returns>
        /// <param name="index">The zero-based index of the cell to get or set.</param>
        /// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
        /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewCell this[int index]
        {
            get
            {
                return (DataGridViewCell)this.mobjItems[index];
            }
            set
            {
                DataGridViewCell objCell1 = value;
                if (objCell1 == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (objCell1.DataGridView != null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridView"));
                }
                if (objCell1.OwningRow != null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
                }
                if (this.mobjOwner.DataGridView != null)
                {
                    this.mobjOwner.DataGridView.OnReplacingCell(this.mobjOwner, index);
                }
                DataGridViewCell objCell2 = (DataGridViewCell)this.mobjItems[index];
                this.mobjItems[index] = objCell1;
                objCell1.OwningRowInternal = this.mobjOwner;
                objCell1.StateInternal = objCell2.State;
                if (this.mobjOwner.DataGridView != null)
                {
                    objCell1.DataGridViewInternal = this.mobjOwner.DataGridView;
                    objCell1.OwningColumnInternal = this.mobjOwner.DataGridView.Columns[index];
                    this.mobjOwner.DataGridView.OnReplacedCell(this.mobjOwner, index);
                }
                objCell2.DataGridViewInternal = null;
                objCell2.OwningRowInternal = null;
                objCell2.OwningColumnInternal = null;
                if (objCell2.ReadOnly)
                {
                    objCell2.ReadOnlyInternal = false;
                }
                if (objCell2.Selected)
                {
                    if (this.mobjOwner != null && this.mobjOwner.DataGridView != null)
                    {
                        this.mobjOwner.DataGridView.SetSelectedCellCore(objCell2, false, false);
                    }
                }
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
                DataGridViewColumn objColumn1 = null;
                if (this.mobjOwner.DataGridView != null)
                {
                    objColumn1 = this.mobjOwner.DataGridView.Columns[strColumnName];
                }
                if (objColumn1 == null)
                {
                    throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", new object[] { strColumnName }), "columnName");
                }
                return (DataGridViewCell)this.mobjItems[objColumn1.Index];
            }
            set
            {
                DataGridViewColumn objColumn1 = null;
                if (this.mobjOwner.DataGridView != null)
                {
                    objColumn1 = this.mobjOwner.DataGridView.Columns[strColumnName];
                }
                if (objColumn1 == null)
                {
                    throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", new object[] { strColumnName }), "columnName");
                }
                this[objColumn1.Index] = value;
            }
        }

        /// <summary>Gets an <see cref="T:System.Collections.ArrayList"></see> containing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> objects.</summary>
        /// <returns><see cref="T:System.Collections.ArrayList"></see>.</returns>
        protected override ArrayList List
        {
            get
            {
                return this.mobjItems;
            }
        }

        int ICollection.Count
        {
            get
            {
                return this.mobjItems.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (DataGridViewCell)value;
            }
        }



    }

    #endregion

    #region DataGridViewColumnCollection Class

    /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <filterpriority>2</filterpriority>
    [ListBindable(false)]
#if WG_NET46
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewColumnCollection : BaseCollection, IList, ICollection, IEnumerable
    {
        /// <summary>Occurs when the collection changes.</summary>
        /// <filterpriority>1</filterpriority>
        public event CollectionChangeEventHandler CollectionChanged;

        private int mintColumnCountsVisible;
        private int mintColumnCountsVisibleSelected;
        private static ColumnOrderComparer mobjColumnOrderComparer;
        private int mintColumnsWidthVisible;
        private int mintColumnsWidthVisibleFrozen;
        private DataGridView mobjDataGridView;
        private ArrayList marrItems;
        private ArrayList marrItemsSorted;
        private int mintLastAccessedSortedIndex;



        static DataGridViewColumnCollection()
        {
            DataGridViewColumnCollection.mobjColumnOrderComparer = new ColumnOrderComparer();
        }

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

        internal int ActualDisplayIndexToColumnIndex(int intActualDisplayIndex, DataGridViewElementStates enmIncludeFilter)
        {
            DataGridViewColumn objColumn1 = this.GetFirstColumn(enmIncludeFilter);
            for (int num1 = 0; num1 < intActualDisplayIndex; num1++)
            {
                objColumn1 = this.GetNextColumn(objColumn1, enmIncludeFilter, DataGridViewElementStates.None);
            }
            return objColumn1.Index;
        }

        /// <summary>Adds the given column to the collection.</summary>
        /// <returns>The index of the column.</returns>
        /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to add.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewColumn already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>.
        ///  Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-dataGridViewColumn has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property value that would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.-or-dataGridViewColumn has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row and dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null.</exception>
        /// <filterpriority>1</filterpriority>

        public virtual int Add(DataGridViewColumn objDataGridViewColumn)
        {
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.InDisplayIndexAdjustments)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
            }
            if (objDataGridViewColumn == null)
            {
                throw new ArgumentNullException("objDataGridViewColumn");
            }
            if (objDataGridViewColumn.Frozen && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
            {
                throw new Exception("DataGridView does not support hierarchies with frozen columns");
            }

            this.DataGridView.OnAddingColumn(objDataGridViewColumn);
            this.InvalidateCachedColumnsOrder();
            int num1 = this.marrItems.Add(objDataGridViewColumn);
            objDataGridViewColumn.IndexInternal = num1;
            objDataGridViewColumn.DataGridViewInternal = this.mobjDataGridView;
            this.UpdateColumnCaches(objDataGridViewColumn, true);
            this.DataGridView.OnAddedColumn(objDataGridViewColumn);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewColumn), false, new Point(-1, -1));
            return num1;
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
            DataGridViewColumn objColumn1 = this.DataGridView.GetDataGridViewDefaultColumn();
            objColumn1.Name = strColumnName;
            objColumn1.HeaderText = strHeaderText;
            return this.Add(objColumn1);
        }

        /// <summary>Adds a range of columns to the collection. </summary>
        /// <param name="arrDataGridViewColumns">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects to add.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewColumns is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-At least one of the values in dataGridViewColumns is null.-or-At least one of the columns in dataGridViewColumns already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-At least one of the columns in dataGridViewColumns has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row.-or-At least one of the columns in dataGridViewColumns has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>. 
        /// Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-At least one of the columns in dataGridViewColumns has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-At least one of the columns in dataGridViewColumns has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-The columns in dataGridViewColumns have <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values that would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.-or-At least two of the values in dataGridViewColumns are references to the same <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.-or-At least one of the columns in dataGridViewColumns has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.</exception>
        /// <filterpriority>1</filterpriority>

        public virtual void AddRange(params DataGridViewColumn[] arrDataGridViewColumns)
        {
            int num3;
            if (arrDataGridViewColumns == null)
            {
                throw new ArgumentNullException("dataGridViewColumns");
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.InDisplayIndexAdjustments)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
            }
            ArrayList objList1 = new ArrayList(arrDataGridViewColumns.Length);
            ArrayList objList2 = new ArrayList(arrDataGridViewColumns.Length);
            foreach (DataGridViewColumn objColumn1 in arrDataGridViewColumns)
            {
                if (objColumn1.DisplayIndex != -1)
                {
                    objList1.Add(objColumn1);
                }
            }
            while (objList1.Count > 0)
            {
                int num1 = 0x7fffffff;
                int num2 = -1;
                for (num3 = 0; num3 < objList1.Count; num3++)
                {
                    DataGridViewColumn objColumn2 = (DataGridViewColumn)objList1[num3];
                    if (objColumn2.DisplayIndex < num1)
                    {
                        num1 = objColumn2.DisplayIndex;
                        num2 = num3;
                    }
                }
                objList2.Add(objList1[num2]);
                objList1.RemoveAt(num2);
            }
            foreach (DataGridViewColumn objColumn3 in arrDataGridViewColumns)
            {
                if (objColumn3.DisplayIndex == -1)
                {
                    objList2.Add(objColumn3);
                }
            }
            num3 = 0;
            foreach (DataGridViewColumn objColumn4 in objList2)
            {
                arrDataGridViewColumns[num3] = objColumn4;
                num3++;
            }
            this.DataGridView.OnAddingColumns(arrDataGridViewColumns);
            foreach (DataGridViewColumn objColumn5 in arrDataGridViewColumns)
            {
                this.InvalidateCachedColumnsOrder();
                num3 = this.marrItems.Add(objColumn5);
                objColumn5.IndexInternal = num3;
                objColumn5.DataGridViewInternal = this.mobjDataGridView;
                this.UpdateColumnCaches(objColumn5, true);
                this.DataGridView.OnAddedColumn(objColumn5);
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), false, new Point(-1, -1));
        }

        /// <summary>Clears the collection. </summary>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
        /// <filterpriority>1</filterpriority>

        public virtual void Clear()
        {
            if (this.Count > 0)
            {
                if (this.DataGridView.NoDimensionChangeAllowed)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
                }
                if (this.DataGridView.InDisplayIndexAdjustments)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
                }
                for (int num1 = 0; num1 < this.Count; num1++)
                {
                    DataGridViewColumn objColumn1 = this[num1];
                    objColumn1.DataGridViewInternal = null;
                    if (objColumn1.HasHeaderCell)
                    {
                        objColumn1.HeaderCell.DataGridViewInternal = null;
                    }
                }
                DataGridViewColumn[] arrColumns = new DataGridViewColumn[this.marrItems.Count];
                this.CopyTo(arrColumns, 0);
                this.DataGridView.OnClearingColumns();
                this.InvalidateCachedColumnsOrder();
                this.marrItems.Clear();
                this.InvalidateCachedColumnCounts();
                this.InvalidateCachedColumnsWidths();
                foreach (DataGridViewColumn objColumn2 in arrColumns)
                {
                    this.DataGridView.OnColumnRemoved(objColumn2);
                    this.DataGridView.OnColumnHidden(objColumn2);
                }
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), false, new Point(-1, -1));
            }
        }

        internal int ColumnIndexToActualDisplayIndex(int intColumnIndex, DataGridViewElementStates enmIncludeFilter)
        {
            DataGridViewColumn objColumn1 = this.GetFirstColumn(enmIncludeFilter);
            int num1 = 0;
            while ((objColumn1 != null) && (objColumn1.Index != intColumnIndex))
            {
                objColumn1 = this.GetNextColumn(objColumn1, enmIncludeFilter, DataGridViewElementStates.None);
                num1++;
            }
            return num1;
        }

        /// <summary>
        /// Creates the real data member from the proposed member.
        /// </summary>
        /// <param name="strFilteringDataMember">The STR filtering data member.</param>
        internal string GetRealDataMemberForProposedMember(string strFilteringDataMember)
        {
            // Iterate through the DGV's columns
            foreach (DataGridViewColumn objColumn in this)
            {
                if (objColumn.Name == strFilteringDataMember || objColumn.DataPropertyName == strFilteringDataMember)
                {
                    return objColumn.Name;
                }
            }

            return null;
        }

        /// <summary>Determines whether the collection contains the column referred to by the given name. </summary>
        /// <returns>true if the column is contained in the collection; otherwise, false.</returns>
        /// <param name="strColumnName">The name of the column to look for.</param>
        /// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual bool Contains(string strColumnName)
        {
            if (strColumnName == null)
            {
                throw new ArgumentNullException("columnName");
            }
            int num1 = this.marrItems.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[num2];
                if (string.Compare(objColumn1.Name, strColumnName, true, CultureInfo.InvariantCulture) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>Determines whether the collection contains the given column.</summary>
        /// <returns>true if the given column is in the collection; otherwise, false.</returns>
        /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to look for.</param>
        /// <filterpriority>1</filterpriority>
        public virtual bool Contains(DataGridViewColumn objDataGridViewColumn)
        {
            return (this.marrItems.IndexOf(objDataGridViewColumn) != -1);
        }

        /// <summary>Copies the items from the collection to the given array.</summary>
        /// <param name="arrColumns">The destination <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> array.</param>
        /// <param name="index">The index of the destination array at which to start copying.</param>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(DataGridViewColumn[] arrColumns, int index)
        {
            this.marrItems.CopyTo(arrColumns, index);
        }

        internal bool DisplayInOrder(int intColumnIndex1, int intColumnIndex2)
        {
            int num1 = ((DataGridViewColumn)this.marrItems[intColumnIndex1]).DisplayIndex;
            int num2 = ((DataGridViewColumn)this.marrItems[intColumnIndex2]).DisplayIndex;
            return (num1 < num2);
        }

        internal DataGridViewColumn GetColumnAtDisplayIndex(int intDisplayIndex)
        {
            if ((intDisplayIndex >= 0) && (intDisplayIndex < this.marrItems.Count))
            {
                DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[intDisplayIndex];
                if (objColumn1.DisplayIndex == intDisplayIndex)
                {
                    return objColumn1;
                }
                for (int num1 = 0; num1 < this.marrItems.Count; num1++)
                {
                    objColumn1 = (DataGridViewColumn)this.marrItems[num1];
                    if (objColumn1.DisplayIndex == intDisplayIndex)
                    {
                        return objColumn1;
                    }
                }
            }
            return null;
        }

        /// <summary>Returns the number of columns that meet the given filter requirements.</summary>
        /// <returns>The number of columns that meet the filter requirements.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter for inclusion.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public int GetColumnCount(DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            DataGridViewElementStates enmElementState2 = enmIncludeFilter;
            if (enmElementState2 != DataGridViewElementStates.Visible)
            {
                if ((enmElementState2 == (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected)) && (this.mintColumnCountsVisibleSelected != -1))
                {
                    return this.mintColumnCountsVisibleSelected;
                }
            }
            else if (this.mintColumnCountsVisible != -1)
            {
                return this.mintColumnCountsVisible;
            }
            int num1 = 0;
            if ((enmIncludeFilter & DataGridViewElementStates.Resizable) == DataGridViewElementStates.None)
            {
                for (int num2 = 0; num2 < this.marrItems.Count; num2++)
                {
                    if (((DataGridViewColumn)this.marrItems[num2]).StateIncludes(enmIncludeFilter))
                    {
                        num1++;
                    }
                }
                DataGridViewElementStates enmElementState3 = enmIncludeFilter;
                if (enmElementState3 != DataGridViewElementStates.Visible)
                {
                    if (enmElementState3 != (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected))
                    {
                        return num1;
                    }
                }
                else
                {
                    this.mintColumnCountsVisible = num1;
                    return num1;
                }
                this.mintColumnCountsVisibleSelected = num1;
                return num1;
            }
            DataGridViewElementStates enmElementState1 = enmIncludeFilter & ~DataGridViewElementStates.Resizable;
            for (int num3 = 0; num3 < this.marrItems.Count; num3++)
            {
                if (((DataGridViewColumn)this.marrItems[num3]).StateIncludes(enmElementState1) && (((DataGridViewColumn)this.marrItems[num3]).Resizable == DataGridViewTriState.True))
                {
                    num1++;
                }
            }
            return num1;
        }

        internal int GetColumnCount(DataGridViewElementStates enmIncludeFilter, int intFromColumnIndex, int toColumnIndex)
        {
            int num1 = 0;
            DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[intFromColumnIndex];
            while (objColumn1 != ((DataGridViewColumn)this.marrItems[toColumnIndex]))
            {
                objColumn1 = this.GetNextColumn(objColumn1, enmIncludeFilter, DataGridViewElementStates.None);
                if (objColumn1.StateIncludes(enmIncludeFilter))
                {
                    num1++;
                }
            }
            return num1;
        }

        internal float GetColumnsFillWeight(DataGridViewElementStates enmIncludeFilter)
        {
            float fltSingle1 = 0f;
            for (int num1 = 0; num1 < this.marrItems.Count; num1++)
            {
                if (((DataGridViewColumn)this.marrItems[num1]).StateIncludes(enmIncludeFilter))
                {
                    fltSingle1 += ((DataGridViewColumn)this.marrItems[num1]).FillWeight;
                }
            }
            return fltSingle1;
        }

        private int GetColumnSortedIndex(DataGridViewColumn objDataGridViewColumn)
        {
            if ((this.mintLastAccessedSortedIndex != -1) && (this.marrItemsSorted[this.mintLastAccessedSortedIndex] == objDataGridViewColumn))
            {
                return this.mintLastAccessedSortedIndex;
            }
            for (int num1 = 0; num1 < this.marrItemsSorted.Count; num1++)
            {
                if (objDataGridViewColumn.Index == ((DataGridViewColumn)this.marrItemsSorted[num1]).Index)
                {
                    this.mintLastAccessedSortedIndex = num1;
                    return num1;
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
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    if (this.mintColumnsWidthVisible == -1)
                    {
                        break;
                    }
                    return this.mintColumnsWidthVisible;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    if (this.mintColumnsWidthVisibleFrozen == -1)
                    {
                        break;
                    }
                    return this.mintColumnsWidthVisibleFrozen;
            }
            int num = 0;
            for (int i = 0; i < this.List.Count; i++)
            {
                if (((DataGridViewColumn)this.List[i]).StateIncludes(enmIncludeFilter))
                {
                    num += ((DataGridViewColumn)this.List[i]).Thickness;
                }
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    this.mintColumnsWidthVisible = num;
                    return num;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Displayed):
                    return num;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    this.mintColumnsWidthVisibleFrozen = num;
                    return num;
            }
            return num;

        }

        /// <summary>Returns the first column in display order that meets the given inclusion-filter requirements.</summary>
        /// <returns>The first column in display order that meets the given filter requirements, or null if no column is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represents the filter for inclusion.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public DataGridViewColumn GetFirstColumn(DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if (this.marrItemsSorted == null)
            {
                this.UpdateColumnOrderCache();
            }
            for (int num1 = 0; num1 < this.marrItemsSorted.Count; num1++)
            {
                DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItemsSorted[num1];
                if (objColumn1.StateIncludes(enmIncludeFilter))
                {
                    this.mintLastAccessedSortedIndex = num1;
                    return objColumn1;
                }
            }
            return null;
        }

        /// <summary>Returns the first column in display order that meets the given inclusion-filter and exclusion-filter requirements. </summary>
        /// <returns>The first column in display order that meets the given filter requirements, or null if no column is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
        /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public DataGridViewColumn GetFirstColumn(DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if (enmExcludeFilter == DataGridViewElementStates.None)
            {
                return this.GetFirstColumn(enmIncludeFilter);
            }
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            if (this.marrItemsSorted == null)
            {
                this.UpdateColumnOrderCache();
            }
            for (int num1 = 0; num1 < this.marrItemsSorted.Count; num1++)
            {
                DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItemsSorted[num1];
                if (objColumn1.StateIncludes(enmIncludeFilter) && objColumn1.StateExcludes(enmExcludeFilter))
                {
                    this.mintLastAccessedSortedIndex = num1;
                    return objColumn1;
                }
            }
            return null;
        }

        /// <summary>Returns the last column in display order that meets the given filter requirements. </summary>
        /// <returns>The last displayed column in display order that meets the given filter requirements, or null if no column is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
        /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public DataGridViewColumn GetLastColumn(DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            if (this.marrItemsSorted == null)
            {
                this.UpdateColumnOrderCache();
            }
            for (int num1 = this.marrItemsSorted.Count - 1; num1 >= 0; num1--)
            {
                DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItemsSorted[num1];
                if (objColumn1.StateIncludes(enmIncludeFilter) && objColumn1.StateExcludes(enmExcludeFilter))
                {
                    this.mintLastAccessedSortedIndex = num1;
                    return objColumn1;
                }
            }
            return null;
        }

        /// <summary>Gets the first column after the given column in display order that meets the given filter requirements. </summary>
        /// <returns>The next column that meets the given filter requirements, or null if no column is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
        /// <param name="objDataGridViewColumnStart">The column from which to start searching for the next column.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
        /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewColumnStart is null.</exception>
        public DataGridViewColumn GetNextColumn(DataGridViewColumn objDataGridViewColumnStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if (objDataGridViewColumnStart == null)
            {
                throw new ArgumentNullException("dataGridViewColumnStart");
            }
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            if (this.marrItemsSorted == null)
            {
                this.UpdateColumnOrderCache();
            }
            int num1 = this.GetColumnSortedIndex(objDataGridViewColumnStart);
            if (num1 == -1)
            {
                bool blnFlag1 = false;
                int num2 = 0x7fffffff;
                int num3 = 0x7fffffff;
                for (num1 = 0; num1 < this.marrItems.Count; num1++)
                {
                    DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[num1];
                    if (((objColumn1.StateIncludes(enmIncludeFilter) && objColumn1.StateExcludes(enmExcludeFilter)) && ((objColumn1.DisplayIndex > objDataGridViewColumnStart.DisplayIndex) || ((objColumn1.DisplayIndex == objDataGridViewColumnStart.DisplayIndex) && (objColumn1.Index > objDataGridViewColumnStart.Index)))) && ((objColumn1.DisplayIndex < num3) || ((objColumn1.DisplayIndex == num3) && (objColumn1.Index < num2))))
                    {
                        num2 = num1;
                        num3 = objColumn1.DisplayIndex;
                        blnFlag1 = true;
                    }
                }
                if (!blnFlag1)
                {
                    return null;
                }
                return (DataGridViewColumn)this.marrItems[num2];
            }
            num1++;
            while (num1 < this.marrItemsSorted.Count)
            {
                DataGridViewColumn objColumn2 = (DataGridViewColumn)this.marrItemsSorted[num1];
                if (objColumn2.StateIncludes(enmIncludeFilter) && objColumn2.StateExcludes(enmExcludeFilter))
                {
                    this.mintLastAccessedSortedIndex = num1;
                    return objColumn2;
                }
                num1++;
            }
            return null;
        }

        /// <summary>Gets the last column prior to the given column in display order that meets the given filter requirements. </summary>
        /// <returns>The previous column that meets the given filter requirements, or null if no column is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
        /// <param name="objDataGridViewColumnStart">The column from which to start searching for the previous column.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
        /// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewColumnStart is null.</exception>
        public DataGridViewColumn GetPreviousColumn(DataGridViewColumn objDataGridViewColumnStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if (objDataGridViewColumnStart == null)
            {
                throw new ArgumentNullException("dataGridViewColumnStart");
            }
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            if (this.marrItemsSorted == null)
            {
                this.UpdateColumnOrderCache();
            }
            int num1 = this.GetColumnSortedIndex(objDataGridViewColumnStart);
            if (num1 == -1)
            {
                bool blnFlag1 = false;
                int num2 = -1;
                int num3 = -1;
                for (num1 = 0; num1 < this.marrItems.Count; num1++)
                {
                    DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[num1];
                    if (((objColumn1.StateIncludes(enmIncludeFilter) && objColumn1.StateExcludes(enmExcludeFilter)) && ((objColumn1.DisplayIndex < objDataGridViewColumnStart.DisplayIndex) || ((objColumn1.DisplayIndex == objDataGridViewColumnStart.DisplayIndex) && (objColumn1.Index < objDataGridViewColumnStart.Index)))) && ((objColumn1.DisplayIndex > num3) || ((objColumn1.DisplayIndex == num3) && (objColumn1.Index > num2))))
                    {
                        num2 = num1;
                        num3 = objColumn1.DisplayIndex;
                        blnFlag1 = true;
                    }
                }
                if (!blnFlag1)
                {
                    return null;
                }
                return (DataGridViewColumn)this.marrItems[num2];
            }
            num1--;
            while (num1 >= 0)
            {
                DataGridViewColumn objColumn2 = (DataGridViewColumn)this.marrItemsSorted[num1];
                if (objColumn2.StateIncludes(enmIncludeFilter) && objColumn2.StateExcludes(enmExcludeFilter))
                {
                    this.mintLastAccessedSortedIndex = num1;
                    return objColumn2;
                }
                num1--;
            }
            return null;
        }

        /// <summary>Gets the index of the given <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> in the collection.</summary>
        /// <returns>The index of the given <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</returns>
        /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to return the index of.</param>
        /// <filterpriority>1</filterpriority>
        public int IndexOf(DataGridViewColumn objDataGridViewColumn)
        {
            return this.marrItems.IndexOf(objDataGridViewColumn);
        }

        /// <summary>Inserts a column at the given index in the collection.</summary>
        /// <param name="intColumnIndex">The zero-based index at which to insert the given column.</param>
        /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to insert.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewColumn already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>. Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> 
        /// property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-dataGridViewColumn has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-dataGridViewColumn has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row and dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void Insert(int intColumnIndex, DataGridViewColumn objDataGridViewColumn)
        {
            Point objPoint;
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.InDisplayIndexAdjustments)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
            }
            if (objDataGridViewColumn == null)
            {
                throw new ArgumentNullException("dataGridViewColumn");
            }
            if (objDataGridViewColumn.Frozen && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
            {
                throw new Exception("DataGridView does not support hierarchies with frozen columns");
            }
            int num1 = objDataGridViewColumn.DisplayIndex;
            if (num1 == -1)
            {
                objDataGridViewColumn.DisplayIndex = intColumnIndex;
            }
            try
            {
                this.DataGridView.OnInsertingColumn(intColumnIndex, objDataGridViewColumn, out objPoint);
            }
            finally
            {
                objDataGridViewColumn.DisplayIndexInternal = num1;
            }
            this.InvalidateCachedColumnsOrder();
            this.marrItems.Insert(intColumnIndex, objDataGridViewColumn);
            objDataGridViewColumn.IndexInternal = intColumnIndex;
            objDataGridViewColumn.DataGridViewInternal = this.mobjDataGridView;
            this.UpdateColumnCaches(objDataGridViewColumn, true);
            this.DataGridView.OnInsertedColumn_PreNotification(objDataGridViewColumn);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewColumn), true, objPoint);
        }

        internal void InvalidateCachedColumnCount(DataGridViewElementStates enmIncludeFilter)
        {
            if (enmIncludeFilter == DataGridViewElementStates.Visible)
            {
                this.InvalidateCachedColumnCounts();
            }
            else if (enmIncludeFilter == DataGridViewElementStates.Selected)
            {
                this.mintColumnCountsVisibleSelected = -1;
            }
        }

        internal void InvalidateCachedColumnCounts()
        {
            this.mintColumnCountsVisible = this.mintColumnCountsVisibleSelected = -1;
        }

        internal void InvalidateCachedColumnsOrder()
        {
            this.marrItemsSorted = null;
        }

        internal void InvalidateCachedColumnsWidth(DataGridViewElementStates enmIncludeFilter)
        {
            if (enmIncludeFilter == DataGridViewElementStates.Visible)
            {
                this.InvalidateCachedColumnsWidths();
            }
            else if (enmIncludeFilter == DataGridViewElementStates.Frozen)
            {
                this.mintColumnsWidthVisibleFrozen = -1;
            }
        }

        internal void InvalidateCachedColumnsWidths()
        {
            this.mintColumnsWidthVisible = this.mintColumnsWidthVisibleFrozen = -1;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewColumnCollection.CollectionChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data.</param>
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            // Raise event if needed
            CollectionChangeEventHandler objEventHandler = this.CollectionChanged;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        private void OnCollectionChanged(CollectionChangeEventArgs ccea, bool blnChangeIsInsertion, Point objNewCurrentCell)
        {
            this.OnCollectionChanged_PreNotification(ccea);
            this.OnCollectionChanged(ccea);
            this.OnCollectionChanged_PostNotification(ccea, blnChangeIsInsertion, objNewCurrentCell);
        }

        private void OnCollectionChanged_PostNotification(CollectionChangeEventArgs ccea, bool blnChangeIsInsertion, Point objNewCurrentCell)
        {
            DataGridViewColumn objColumn1 = (DataGridViewColumn)ccea.Element;
            if ((ccea.Action == CollectionChangeAction.Add) && blnChangeIsInsertion)
            {
                this.DataGridView.OnInsertedColumn_PostNotification(objNewCurrentCell);
            }
            else if (ccea.Action == CollectionChangeAction.Remove)
            {
                this.DataGridView.OnRemovedColumn_PostNotification(objColumn1, objNewCurrentCell);
            }
            this.DataGridView.OnColumnCollectionChanged_PostNotification(objColumn1);
        }


        private void OnCollectionChanged_PreNotification(CollectionChangeEventArgs ccea)
        {
            this.DataGridView.OnColumnCollectionChanged_PreNotification(ccea);
        }

        /// <summary>Removes the column with the specified name from the collection.</summary>
        /// <param name="strColumnName">The name of the column to delete.</param>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
        /// <exception cref="T:System.ArgumentException">columnName does not match the name of any column in the collection.</exception>
        /// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
        /// <filterpriority>1</filterpriority>

        public virtual void Remove(string strColumnName)
        {
            if (strColumnName == null)
            {
                throw new ArgumentNullException("columnName");
            }
            int num1 = this.marrItems.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[num2];
                if (string.Compare(objColumn1.Name, strColumnName, true, CultureInfo.InvariantCulture) == 0)
                {
                    this.RemoveAt(num2);
                    return;
                }
            }
            throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", new object[] { strColumnName }), "columnName");
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
            {
                throw new ArgumentNullException("dataGridViewColumn");
            }
            if (objDataGridViewColumn.DataGridView != this.DataGridView)
            {
                throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"), "dataGridViewColumn");
            }
            int num1 = this.marrItems.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                if (this.marrItems[num2] == objDataGridViewColumn)
                {
                    this.RemoveAt(num2);
                    return;
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
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.InDisplayIndexAdjustments)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
            }
            this.RemoveAtInternal(index, false);
        }

        internal void RemoveAtInternal(int index, bool blnForce)
        {
            Point objPoint;
            DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[index];
            this.DataGridView.OnRemovingColumn(objColumn1, out objPoint, blnForce);
            this.InvalidateCachedColumnsOrder();
            this.marrItems.RemoveAt(index);
            objColumn1.DataGridViewInternal = null;
            this.UpdateColumnCaches(objColumn1, false);
            this.DataGridView.OnRemovedColumn_PreNotification(objColumn1);
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, objColumn1), false, objPoint);
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.marrItems.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.marrItems.GetEnumerator();
        }

        int IList.Add(object objValue)
        {
            return this.Add((DataGridViewColumn)objValue);
        }

        void IList.Clear()
        {
            this.Clear();
        }

        bool IList.Contains(object objValue)
        {
            return this.marrItems.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.marrItems.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            this.Insert(index, (DataGridViewColumn)objValue);
        }

        void IList.Remove(object objValue)
        {
            this.Remove((DataGridViewColumn)objValue);
        }

        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        private void UpdateColumnCaches(DataGridViewColumn objDataGridViewColumn, bool blnAdding)
        {
            if (((this.mintColumnCountsVisible != -1) || (this.mintColumnCountsVisibleSelected != -1)) || ((this.mintColumnsWidthVisible != -1) || (this.mintColumnsWidthVisibleFrozen != -1)))
            {
                DataGridViewElementStates enmElementState = objDataGridViewColumn.State;
                if ((enmElementState & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
                {
                    int num1 = blnAdding ? 1 : -1;
                    int num2 = 0;
                    if ((this.mintColumnsWidthVisible != -1) || ((this.mintColumnsWidthVisibleFrozen != -1) && ((enmElementState & (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen)) == (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen))))
                    {
                        num2 = blnAdding ? objDataGridViewColumn.Width : -objDataGridViewColumn.Width;
                    }
                    if (this.mintColumnCountsVisible != -1)
                    {
                        this.mintColumnCountsVisible += num1;
                    }
                    if (this.mintColumnsWidthVisible != -1)
                    {
                        this.mintColumnsWidthVisible += num2;
                    }
                    if (((enmElementState & (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen)) == (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen)) && (this.mintColumnsWidthVisibleFrozen != -1))
                    {
                        this.mintColumnsWidthVisibleFrozen += num2;
                    }
                    if (((enmElementState & (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected)) == (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected)) && (this.mintColumnCountsVisibleSelected != -1))
                    {
                        this.mintColumnCountsVisibleSelected += num1;
                    }
                }
            }
        }

        private void UpdateColumnOrderCache()
        {
            this.marrItemsSorted = (ArrayList)this.marrItems.Clone();
            this.marrItemsSorted.Sort(DataGridViewColumnCollection.mobjColumnOrderComparer);
            this.mintLastAccessedSortedIndex = -1;
        }


        internal static IComparer ColumnCollectionOrderComparer
        {
            get
            {
                return DataGridViewColumnCollection.mobjColumnOrderComparer;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> upon which the collection performs column-related operations.</summary>
        /// <returns><see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
        protected Gizmox.WebGUI.Forms.DataGridView DataGridView
        {
            get
            {
                return this.mobjDataGridView;
            }
        }

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
                {
                    throw new ArgumentNullException("columnName");
                }
                int num1 = this.marrItems.Count;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    DataGridViewColumn objColumn1 = (DataGridViewColumn)this.marrItems[num2];
                    if (ClientUtils.IsEquals(objColumn1.Name, strColumnName, StringComparison.OrdinalIgnoreCase))
                    {
                        return objColumn1;
                    }
                }
                return null;
            }
        }

        /// <summary>Gets or sets the column at the given index in the collection. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> at the given index.</returns>
        /// <param name="index">The zero-based index of the column to get or set.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the number of columns in the collection minus one.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewColumn this[int index]
        {
            get
            {
                return (DataGridViewColumn)this.marrItems[index];
            }
        }

        /// <summary>
        /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
        /// </summary>
        /// <value></value>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
        protected override ArrayList List
        {
            get
            {
                return this.marrItems;
            }
        }

        int ICollection.Count
        {
            get
            {
                return this.marrItems.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }



        [Serializable()]
        private class ColumnOrderComparer : IComparer
        {
            public int Compare(object objX, object objY)
            {
                DataGridViewColumn objColumn1 = objX as DataGridViewColumn;
                DataGridViewColumn objColumn2 = objY as DataGridViewColumn;
                return (objColumn1.DisplayIndex - objColumn2.DisplayIndex);
            }

        }
    }

    #endregion

    #region DataGridViewRowCollection Class

    /// <summary>A collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ListBindable(false), DesignerSerializer("Gizmox.WebGUI.Forms.Design.DataGridViewRowCollectionCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [ListBindable(false), DesignerSerializer("Gizmox.WebGUI.Forms.Design.DataGridViewRowCollectionCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
    [Serializable()]
    public class DataGridViewRowCollection : IList, ICollection, IEnumerable
    {
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
            this.mobjRowStates = new List<DataGridViewElementStates>();
            this.mobjItems = new RowArrayList(this);
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            return this.AddInternal(false, null);
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
            {
                throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
            }
            if (this.DataGridView.Columns.Count == 0)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
            }
            if (this.DataGridView.DataSource != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.RowTemplate.Cells.Count > this.DataGridView.Columns.Count)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
            }
            DataGridViewRow objDataGridViewRow1 = this.DataGridView.RowTemplateClone;
            DataGridViewElementStates enmElementState = objDataGridViewRow1.State;
            objDataGridViewRow1.DataGridViewInternal = this.mobjDataGridView;
            int num1 = 0;
            foreach (DataGridViewCell objCell1 in objDataGridViewRow1.Cells)
            {
                objCell1.DataGridViewInternal = this.mobjDataGridView;
                objCell1.OwningColumnInternal = this.DataGridView.Columns[num1];
                num1++;
            }
            if (objDataGridViewRow1.HasHeaderCell)
            {
                objDataGridViewRow1.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
                objDataGridViewRow1.HeaderCell.OwningRowInternal = objDataGridViewRow1;
            }
            if (this.DataGridView.NewRowIndex != -1)
            {
                int num2 = this.Count - 1;
                this.InsertCopiesPrivate(objDataGridViewRow1, enmElementState, num2, intCount);
                return ((num2 + intCount) - 1);
            }
            return this.AddCopiesPrivate(objDataGridViewRow1, enmElementState, intCount);
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
            {
                throw new ArgumentNullException("values");
            }
            if (this.DataGridView.VirtualMode)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
            }
            if (this.DataGridView.DataSource != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
            }
            if (this.DataGridView.DataSource != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            return this.AddCopiesInternal(indexSource, intCount);
        }

        internal int AddCopiesInternal(int indexSource, int intCount)
        {
            if (this.DataGridView.NewRowIndex != -1)
            {
                int num1 = this.Count - 1;
                this.InsertCopiesPrivate(indexSource, num1, intCount);
                return ((num1 + intCount) - 1);
            }
            return this.AddCopiesInternal(indexSource, intCount, DataGridViewElementStates.None, DataGridViewElementStates.Selected | DataGridViewElementStates.Displayed);
        }

        internal int AddCopiesInternal(int indexSource, int intCount, DataGridViewElementStates enmDgvesAdd, DataGridViewElementStates enmDgvesRemove)
        {
            if ((indexSource < 0) || (this.Count <= indexSource))
            {
                throw new ArgumentOutOfRangeException("indexSource", SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
            }
            if (intCount <= 0)
            {
                throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
            }
            DataGridViewElementStates enmElementState = ((DataGridViewElementStates)this.mobjRowStates[indexSource]) & ~enmDgvesRemove;
            enmElementState |= enmDgvesAdd;
            return this.AddCopiesPrivate(this.SharedRow(indexSource), enmElementState, intCount);
        }

        private int AddCopiesPrivate(DataGridViewRow objRowTemplate, DataGridViewElementStates enmRowTemplateState, int intCount)
        {
            int num1;
            int num2 = this.mobjItems.Count;
            if (objRowTemplate.Index == -1)
            {
                this.DataGridView.OnAddingRow(objRowTemplate, enmRowTemplateState, true);
                for (int num3 = 0; num3 < (intCount - 1); num3++)
                {
                    this.SharedList.Add(objRowTemplate);
                    this.mobjRowStates.Add(enmRowTemplateState);
                }
                num1 = this.SharedList.Add(objRowTemplate);
                this.mobjRowStates.Add(enmRowTemplateState);
                this.DataGridView.OnAddedRow_PreNotification(num1);
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), num2, intCount);
                for (int num4 = 0; num4 < intCount; num4++)
                {
                    this.DataGridView.OnAddedRow_PostNotification((num1 - (intCount - 1)) + num4);
                }
                return num1;
            }
            num1 = this.AddDuplicateRow(objRowTemplate, false);
            if (intCount > 1)
            {
                this.DataGridView.OnAddedRow_PreNotification(num1);
                if (this.RowIsSharable(num1))
                {
                    DataGridViewRow objDataGridViewRow1 = this.SharedRow(num1);
                    this.DataGridView.OnAddingRow(objDataGridViewRow1, enmRowTemplateState, true);
                    for (int num5 = 1; num5 < (intCount - 1); num5++)
                    {
                        this.SharedList.Add(objDataGridViewRow1);
                        this.mobjRowStates.Add(enmRowTemplateState);
                    }
                    num1 = this.SharedList.Add(objDataGridViewRow1);
                    this.mobjRowStates.Add(enmRowTemplateState);
                    this.DataGridView.OnAddedRow_PreNotification(num1);
                }
                else
                {
                    this.UnshareRow(num1);
                    for (int num6 = 1; num6 < intCount; num6++)
                    {
                        num1 = this.AddDuplicateRow(objRowTemplate, false);
                        this.UnshareRow(num1);
                        this.DataGridView.OnAddedRow_PreNotification(num1);
                    }
                }
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), num2, intCount);
                for (int num7 = 0; num7 < intCount; num7++)
                {
                    this.DataGridView.OnAddedRow_PostNotification((num1 - (intCount - 1)) + num7);
                }
                return num1;
            }
            if (this.IsCollectionChangedListenedTo)
            {
                this.UnshareRow(num1);
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, this.SharedRow(num1)), num1, 1);
            return num1;
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            return this.AddCopyInternal(indexSource, DataGridViewElementStates.None, DataGridViewElementStates.Selected | DataGridViewElementStates.Displayed, false);
        }

        internal int AddCopyInternal(int indexSource, DataGridViewElementStates enmDgvesAdd, DataGridViewElementStates enmDgvesRemove, bool blnNewRow)
        {
            int num2;
            if (this.DataGridView.NewRowIndex != -1)
            {
                int num1 = this.Count - 1;
                this.InsertCopy(indexSource, num1);
                return num1;
            }
            if ((indexSource < 0) || (indexSource >= this.Count))
            {
                throw new ArgumentOutOfRangeException("indexSource", SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
            }
            DataGridViewRow objDataGridViewRow1 = this.SharedRow(indexSource);
            if (((objDataGridViewRow1.Index == -1) && !this.IsCollectionChangedListenedTo) && !blnNewRow)
            {
                DataGridViewElementStates enmElementState = ((DataGridViewElementStates)this.mobjRowStates[indexSource]) & ~enmDgvesRemove;
                enmElementState |= enmDgvesAdd;
                this.DataGridView.OnAddingRow(objDataGridViewRow1, enmElementState, true);
                num2 = this.SharedList.Add(objDataGridViewRow1);
                this.mobjRowStates.Add(enmElementState);
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewRow1), num2, 1);
                return num2;
            }
            num2 = this.AddDuplicateRow(objDataGridViewRow1, blnNewRow);
            if ((!this.RowIsSharable(num2) || DataGridViewRowCollection.RowHasValueOrToolTipText(this.SharedRow(num2))) || this.IsCollectionChangedListenedTo)
            {
                this.UnshareRow(num2);
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, this.SharedRow(num2)), num2, 1);
            return num2;
        }

        private int AddDuplicateRow(DataGridViewRow objRowTemplate, bool blnNewRow)
        {
            DataGridViewRow objDataGridViewRow1 = (DataGridViewRow)objRowTemplate.Clone();
            objDataGridViewRow1.StateInternal = DataGridViewElementStates.None;
            objDataGridViewRow1.DataGridViewInternal = this.mobjDataGridView;
            DataGridViewCellCollection objCollection1 = objDataGridViewRow1.Cells;
            int num1 = 0;
            foreach (DataGridViewCell objCell1 in objCollection1)
            {
                if (blnNewRow)
                {
                    objCell1.Value = objCell1.DefaultNewRowValue;
                }
                objCell1.DataGridViewInternal = this.mobjDataGridView;
                objCell1.OwningColumnInternal = this.DataGridView.Columns[num1];
                num1++;
            }
            DataGridViewElementStates enmElementState = objRowTemplate.State & ~(DataGridViewElementStates.Selected | DataGridViewElementStates.Displayed);
            if (objDataGridViewRow1.HasHeaderCell)
            {
                objDataGridViewRow1.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
                objDataGridViewRow1.HeaderCell.OwningRowInternal = objDataGridViewRow1;
            }
            this.DataGridView.OnAddingRow(objDataGridViewRow1, enmElementState, true);
            this.mobjRowStates.Add(enmElementState);
            return this.SharedList.Add(objDataGridViewRow1);
        }

        internal int AddInternal(DataGridViewRow objDataGridViewRow)
        {
            if (objDataGridViewRow == null)
            {
                throw new ArgumentNullException("dataGridViewRow");
            }
            if (objDataGridViewRow.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
            }
            if (this.DataGridView.Columns.Count == 0)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
            }
            if (objDataGridViewRow.Cells.Count > this.DataGridView.Columns.Count)
            {
                throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
            }
            if (objDataGridViewRow.Selected)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
            }
            if (this.DataGridView.NewRowIndex != -1)
            {
                int intRowIndex = this.Count - 1;
                this.InsertInternal(intRowIndex, objDataGridViewRow);
                return intRowIndex;
            }
            this.DataGridView.CompleteCellsCollection(objDataGridViewRow);
            this.DataGridView.OnAddingRow(objDataGridViewRow, objDataGridViewRow.State, true);
            int num2 = 0;
            foreach (DataGridViewCell objCell in objDataGridViewRow.Cells)
            {
                objCell.DataGridViewInternal = this.mobjDataGridView;
                if (objCell.ColumnIndex == -1)
                {
                    objCell.OwningColumnInternal = this.DataGridView.Columns[num2];
                }
                num2++;
            }
            if (objDataGridViewRow.HasHeaderCell)
            {
                objDataGridViewRow.HeaderCell.DataGridViewInternal = this.DataGridView;
                objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
            }
            int index = this.SharedList.Add(objDataGridViewRow);
            this.mobjRowStates.Add(objDataGridViewRow.State);
            objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
            if ((!this.RowIsSharable(index) || RowHasValueOrToolTipText(objDataGridViewRow)) || this.IsCollectionChangedListenedTo)
            {
                objDataGridViewRow.IndexInternal = index;
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewRow), index, 1);
            return index;
        }

        internal int AddInternal(bool blnNewRow, object[] arrValues)
        {
            if (this.DataGridView.Columns.Count == 0)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
            }
            if (this.DataGridView.RowTemplate.Cells.Count > this.DataGridView.Columns.Count)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
            }
            DataGridViewRow objDataGridViewRow1 = this.DataGridView.RowTemplateClone;
            if (blnNewRow)
            {
                objDataGridViewRow1.StateInternal = objDataGridViewRow1.State | DataGridViewElementStates.Visible;
                foreach (DataGridViewCell objCell1 in objDataGridViewRow1.Cells)
                {
                    objCell1.Value = objCell1.DefaultNewRowValue;
                }
            }
            if (arrValues != null)
            {
                objDataGridViewRow1.SetValuesInternal(arrValues);
            }
            if (this.DataGridView.NewRowIndex != -1)
            {
                int num1 = this.Count - 1;
                this.Insert(num1, objDataGridViewRow1);
                return num1;
            }
            DataGridViewElementStates enmElementState = objDataGridViewRow1.State;
            this.DataGridView.OnAddingRow(objDataGridViewRow1, enmElementState, true);
            objDataGridViewRow1.DataGridViewInternal = this.mobjDataGridView;
            int num2 = 0;
            foreach (DataGridViewCell objCell2 in objDataGridViewRow1.Cells)
            {
                objCell2.DataGridViewInternal = this.mobjDataGridView;
                objCell2.OwningColumnInternal = this.DataGridView.Columns[num2];
                num2++;
            }
            int num3 = this.SharedList.Add(objDataGridViewRow1);
            this.mobjRowStates.Add(enmElementState);
            if (((arrValues != null) || !this.RowIsSharable(num3)) || (DataGridViewRowCollection.RowHasValueOrToolTipText(objDataGridViewRow1) || this.IsCollectionChangedListenedTo))
            {
                objDataGridViewRow1.IndexInternal = num3;
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewRow1), num3, 1);
            return num3;
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
            {
                throw new ArgumentNullException("dataGridViewRows");
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.DataSource != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NewRowIndex != -1)
            {
                this.InsertRange(this.Count - 1, arrDataGridViewRows);
            }
            else
            {
                if (this.DataGridView.Columns.Count == 0)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
                }
                int num1 = this.mobjItems.Count;
                this.DataGridView.OnAddingRows(arrDataGridViewRows, true);
                foreach (DataGridViewRow objDataGridViewRow1 in arrDataGridViewRows)
                {
                    int num2 = 0;
                    foreach (DataGridViewCell objCell1 in objDataGridViewRow1.Cells)
                    {
                        objCell1.DataGridViewInternal = this.mobjDataGridView;
                        objCell1.OwningColumnInternal = this.DataGridView.Columns[num2];
                        num2++;
                    }
                    if (objDataGridViewRow1.HasHeaderCell)
                    {
                        objDataGridViewRow1.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
                        objDataGridViewRow1.HeaderCell.OwningRowInternal = objDataGridViewRow1;
                    }
                    int num3 = this.SharedList.Add(objDataGridViewRow1);
                    this.mobjRowStates.Add(objDataGridViewRow1.State);
                    objDataGridViewRow1.IndexInternal = num3;
                    objDataGridViewRow1.DataGridViewInternal = this.mobjDataGridView;
                }
                this.DataGridView.OnAddedRows_PreNotification(arrDataGridViewRows);
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), num1, arrDataGridViewRows.Length);
                this.DataGridView.OnAddedRows_PostNotification(arrDataGridViewRows);
            }
        }

        /// <summary>Clears the collection. </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection is data bound and the underlying data source does not support clearing the row data.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
        /// <filterpriority>1</filterpriority>

        public virtual void Clear()
        {
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.DataSource != null)
            {
                IBindingList objList = this.DataGridView.DataConnection.List as IBindingList;
                if (((objList != null) && objList.AllowRemove) && objList.SupportsChangeNotification)
                {
                    objList.Clear();
                    return;
                }
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CantClearRowCollectionWithWrongSource"));
            }
            this.ClearInternal(true);
        }

        internal void ClearInternal(bool blnRecreateNewRow)
        {
            int num1 = this.mobjItems.Count;
            if (num1 > 0)
            {
                this.DataGridView.OnClearingRows();
                for (int num2 = 0; num2 < num1; num2++)
                {
                    this.SharedRow(num2).DetachFromDataGridView();
                }
                this.SharedList.Clear();
                this.mobjRowStates.Clear();
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), 0, num1, true, false, blnRecreateNewRow, new Point(-1, -1));
            }
            else if ((blnRecreateNewRow && (this.DataGridView.Columns.Count != 0)) && (this.DataGridView.AllowUserToAddRowsInternal && (this.mobjItems.Count == 0)))
            {
                this.DataGridView.AddNewRow(false);
            }
        }

        /// <summary>Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> is in the collection.</summary>
        /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> is in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>; otherwise, false.</returns>
        /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public virtual bool Contains(DataGridViewRow objDataGridViewRow)
        {
            return (this.mobjItems.IndexOf(objDataGridViewRow) != -1);
        }

        /// <summary>Copies the items from the collection into the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> array, starting at the specified index.</summary>
        /// <param name="arrRows">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> array that is the destination of the items copied from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="T:System.ArgumentException">array is multidimensional.-or- index is equal to or greater than the length of array.-or- The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> is greater than the available space from index to the end of array. </exception>
        /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(DataGridViewRow[] arrRows, int index)
        {
            this.mobjItems.CopyTo(arrRows, index);
        }

        internal int DisplayIndexToRowIndex(int visibleRowIndex)
        {
            int num1 = -1;
            for (int num2 = 0; num2 < this.Count; num2++)
            {
                if ((this.GetRowState(num2) & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible)
                {
                    num1++;
                }
                if (num1 == visibleRowIndex)
                {
                    return num2;
                }
            }
            return -1;
        }

        /// <summary>Returns the index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
        /// <returns>The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public int GetFirstRow(DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    if (this.mintRowCountsVisible == 0)
                    {
                        return -1;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    if (this.mintRowCountsVisibleFrozen == 0)
                    {
                        return -1;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected):
                    if (this.mintRowCountsVisibleSelected == 0)
                    {
                        return -1;
                    }
                    break;
            }
            int num1 = 0;
            while ((num1 < this.mobjItems.Count) && ((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter))
            {
                num1++;
            }
            if (num1 >= this.mobjItems.Count)
            {
                return -1;
            }
            return num1;
        }

        /// <summary>Returns the index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
        /// <returns>The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public int GetFirstRow(DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if (enmExcludeFilter == DataGridViewElementStates.None)
            {
                return this.GetFirstRow(enmIncludeFilter);
            }
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    if (this.mintRowCountsVisible == 0)
                    {
                        return -1;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    if (this.mintRowCountsVisibleFrozen == 0)
                    {
                        return -1;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected):
                    if (this.mintRowCountsVisibleSelected == 0)
                    {
                        return -1;
                    }
                    break;
            }
            int num1 = 0;
            while ((num1 < this.mobjItems.Count) && (((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter) || ((this.GetRowState(num1) & enmExcludeFilter) != DataGridViewElementStates.None)))
            {
                num1++;
            }
            if (num1 >= this.mobjItems.Count)
            {
                return -1;
            }
            return num1;
        }

        /// <summary>Returns the index of the last <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
        /// <returns>The index of the last <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public int GetLastRow(DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    if (this.mintRowCountsVisible == 0)
                    {
                        return -1;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    if (this.mintRowCountsVisibleFrozen == 0)
                    {
                        return -1;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected):
                    if (this.mintRowCountsVisibleSelected == 0)
                    {
                        return -1;
                    }
                    break;
            }
            int num1 = this.mobjItems.Count - 1;
            while ((num1 >= 0) && ((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter))
            {
                num1--;
            }
            if (num1 < 0)
            {
                return -1;
            }
            return num1;
        }

        /// <summary>Returns the index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
        /// <returns>The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> after indexStart that has the attributes specified by includeFilter, or -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <param name="indexStart">The index of the row where the method should begin to look for the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is less than -1.</exception>
        public int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if (indexStart < -1)
            {
                object[] arrObjects2 = new object[] { "indexStart", indexStart.ToString(CultureInfo.CurrentCulture), (-1).ToString(CultureInfo.CurrentCulture) };
                throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidLowBoundArgumentEx", arrObjects2));
            }
            int num1 = indexStart + 1;
            while ((num1 < this.mobjItems.Count) && ((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter))
            {
                num1++;
            }
            if (num1 >= this.mobjItems.Count)
            {
                return -1;
            }
            return num1;
        }

        internal int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter, int intSkipRows)
        {
            int num1 = indexStart;
            do
            {
                num1 = this.GetNextRow(num1, enmIncludeFilter);
                intSkipRows--;
            }
            while ((intSkipRows >= 0) && (num1 != -1));
            return num1;
        }

        /// <summary>Returns the index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
        /// <returns>The index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <param name="indexStart">The index of the row where the method should begin to look for the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is less than -1.</exception>
        public int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if (enmExcludeFilter == DataGridViewElementStates.None)
            {
                return this.GetNextRow(indexStart, enmIncludeFilter);
            }
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            if (indexStart < -1)
            {
                object[] arrObjects3 = new object[] { "indexStart", indexStart.ToString(CultureInfo.CurrentCulture), (-1).ToString(CultureInfo.CurrentCulture) };
                throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidLowBoundArgumentEx", arrObjects3));
            }
            int num1 = indexStart + 1;
            while ((num1 < this.mobjItems.Count) && (((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter) || ((this.GetRowState(num1) & enmExcludeFilter) != DataGridViewElementStates.None)))
            {
                num1++;
            }
            if (num1 >= this.mobjItems.Count)
            {
                return -1;
            }
            return num1;
        }

        /// <summary>Returns the index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
        /// <returns>The index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <param name="indexStart">The index of the row where the method should begin to look for the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is greater than the number of rows in the collection.</exception>
        public int GetPreviousRow(int indexStart, DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if (indexStart > this.mobjItems.Count)
            {
                throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidHighBoundArgumentEx", new object[] { "indexStart", indexStart.ToString(CultureInfo.CurrentCulture), this.mobjItems.Count.ToString(CultureInfo.CurrentCulture) }));
            }
            int num1 = indexStart - 1;
            while ((num1 >= 0) && ((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter))
            {
                num1--;
            }
            if (num1 < 0)
            {
                return -1;
            }
            return num1;
        }

        /// <summary>Returns the index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
        /// <returns>The index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <param name="indexStart">The index of the row where the method should begin to look for the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
        /// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is greater than the number of rows in the collection.</exception>
        public int GetPreviousRow(int indexStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
        {
            if (enmExcludeFilter == DataGridViewElementStates.None)
            {
                return this.GetPreviousRow(indexStart, enmIncludeFilter);
            }
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            if ((enmExcludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "excludeFilter" }));
            }
            if (indexStart > this.mobjItems.Count)
            {
                throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidHighBoundArgumentEx", new object[] { "indexStart", indexStart.ToString(CultureInfo.CurrentCulture), this.mobjItems.Count.ToString(CultureInfo.CurrentCulture) }));
            }
            int num1 = indexStart - 1;
            while ((num1 >= 0) && (((this.GetRowState(num1) & enmIncludeFilter) != enmIncludeFilter) || ((this.GetRowState(num1) & enmExcludeFilter) != DataGridViewElementStates.None)))
            {
                num1--;
            }
            if (num1 < 0)
            {
                return -1;
            }
            return num1;
        }

        /// <summary>Returns the number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the collection that meet the specified criteria.</summary>
        /// <returns>The number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that have the attributes specified by includeFilter.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public int GetRowCount(DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    if (this.mintRowCountsVisible != -1)
                    {
                        return this.mintRowCountsVisible;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    if (this.mintRowCountsVisibleFrozen != -1)
                    {
                        return this.mintRowCountsVisibleFrozen;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected):
                    if (this.mintRowCountsVisibleSelected != -1)
                    {
                        return this.mintRowCountsVisibleSelected;
                    }
                    break;
            }
            int num1 = 0;
            for (int num2 = 0; num2 < this.mobjItems.Count; num2++)
            {
                if ((this.GetRowState(num2) & enmIncludeFilter) == enmIncludeFilter)
                {
                    num1++;
                }
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    this.mintRowCountsVisible = num1;
                    return num1;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Displayed):
                    return num1;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    this.mintRowCountsVisibleFrozen = num1;
                    return num1;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected):
                    this.mintRowCountsVisibleSelected = num1;
                    return num1;
            }
            return num1;
        }

        internal int GetRowCount(DataGridViewElementStates enmIncludeFilter, int intFromRowIndex, int toRowIndex)
        {
            int num1 = 0;
            for (int num2 = intFromRowIndex + 1; num2 <= toRowIndex; num2++)
            {
                if ((this.GetRowState(num2) & enmIncludeFilter) == enmIncludeFilter)
                {
                    num1++;
                }
            }
            return num1;
        }

        /// <summary>Returns the cumulative height of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects that meet the specified criteria.</summary>
        /// <returns>The cumulative height of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that have the attributes specified by includeFilter.</returns>
        /// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
        public int GetRowsHeight(DataGridViewElementStates enmIncludeFilter)
        {
            if ((enmIncludeFilter & ~(DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed)) != DataGridViewElementStates.None)
            {
                throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", new object[] { "includeFilter" }));
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    if (this.mintRowsHeightVisible != -1)
                    {
                        return this.mintRowsHeightVisible;
                    }
                    break;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    if (this.mintRowsHeightVisibleFrozen != -1)
                    {
                        return this.mintRowsHeightVisibleFrozen;
                    }
                    break;
            }
            int num1 = 0;
            for (int num2 = 0; num2 < this.mobjItems.Count; num2++)
            {
                if ((this.GetRowState(num2) & enmIncludeFilter) == enmIncludeFilter)
                {
                    num1 += ((DataGridViewRow)this.mobjItems[num2]).GetHeight(num2);
                }
            }
            switch (enmIncludeFilter)
            {
                case DataGridViewElementStates.Visible:
                    this.mintRowsHeightVisible = num1;
                    return num1;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Displayed):
                    return num1;

                case (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen):
                    this.mintRowsHeightVisibleFrozen = num1;
                    return num1;
            }
            return num1;
        }

        internal int GetRowsHeight(DataGridViewElementStates enmIncludeFilter, int intFromRowIndex, int toRowIndex)
        {
            int num1 = 0;
            for (int num2 = intFromRowIndex; num2 < toRowIndex; num2++)
            {
                if ((this.GetRowState(num2) & enmIncludeFilter) == enmIncludeFilter)
                {
                    num1 += ((DataGridViewRow)this.mobjItems[num2]).GetHeight(num2);
                }
            }
            return num1;
        }

        private bool GetRowsHeightExceedLimit(DataGridViewElementStates enmIncludeFilter, int intFromRowIndex, int toRowIndex, int intHeightLimit)
        {
            int num1 = 0;
            for (int num2 = intFromRowIndex; num2 < toRowIndex; num2++)
            {
                if ((this.GetRowState(num2) & enmIncludeFilter) == enmIncludeFilter)
                {
                    num1 += ((DataGridViewRow)this.mobjItems[num2]).GetHeight(num2);
                    if (num1 > intHeightLimit)
                    {
                        return true;
                    }
                }
            }
            return (num1 > intHeightLimit);
        }

        /// <summary>Gets the state of the row with the specified index.</summary>
        /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state of the specified row.</returns>
        /// <param name="intRowIndex">The index of the row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero and greater than the number of rows in the collection minus one.</exception>
        public virtual DataGridViewElementStates GetRowState(int intRowIndex)
        {
            if ((intRowIndex < 0) || (intRowIndex >= this.mobjItems.Count))
            {
                throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
            }
            DataGridViewRow objDataGridViewRow1 = this.SharedRow(intRowIndex);
            if (objDataGridViewRow1.Index == -1)
            {
                return this.SharedRowState(intRowIndex);
            }
            return objDataGridViewRow1.GetState(intRowIndex);
        }

        /// <summary>Returns the index of a specified item in the collection.</summary>
        /// <returns>The index of value if it is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> found in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>; otherwise, -1.</returns>
        /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public int IndexOf(DataGridViewRow objDataGridViewRow)
        {
            return this.mobjItems.IndexOf(objDataGridViewRow);
        }

        /// <summary>Inserts the specified number of rows into the collection at the specified location.</summary>
        /// <param name="intCount">The number of rows to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
        /// <param name="intRowIndex">The position at which to insert the rows.</param>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. -or-count is less than 1.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void Insert(int intRowIndex, int intCount)
        {
            if (this.DataGridView.DataSource != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if ((intRowIndex < 0) || (this.Count < intRowIndex))
            {
                throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
            }
            if (intCount <= 0)
            {
                throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.Columns.Count == 0)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
            }
            if (this.DataGridView.RowTemplate.Cells.Count > this.DataGridView.Columns.Count)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
            }
            if ((this.DataGridView.NewRowIndex != -1) && (intRowIndex == this.Count))
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
            }
            DataGridViewRow objRowTemplateClone = this.DataGridView.RowTemplateClone;
            DataGridViewElementStates enmElementState = objRowTemplateClone.State;
            objRowTemplateClone.DataGridViewInternal = this.mobjDataGridView;
            int num = 0;
            foreach (DataGridViewCell objCell in objRowTemplateClone.Cells)
            {
                objCell.DataGridViewInternal = this.mobjDataGridView;
                objCell.OwningColumnInternal = this.DataGridView.Columns[num];
                num++;
            }
            if (objRowTemplateClone.HasHeaderCell)
            {
                objRowTemplateClone.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
                objRowTemplateClone.HeaderCell.OwningRowInternal = objRowTemplateClone;
            }
            this.InsertCopiesPrivate(objRowTemplateClone, enmElementState, intRowIndex, intCount);
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
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
            {
                throw new ArgumentNullException("values");
            }
            if (this.DataGridView.VirtualMode)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
            }
            if (this.DataGridView.DataSource != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            DataGridViewRow objRowTemplateClone = this.DataGridView.RowTemplateClone;
            objRowTemplateClone.SetValuesInternal(arrValues);
            this.Insert(intRowIndex, objRowTemplateClone);
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
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            this.InsertCopiesPrivate(indexSource, indexDestination, intCount);
        }

        /// <summary>
        /// Inserts the copies private.
        /// </summary>
        /// <param name="indexSource">The index source.</param>
        /// <param name="indexDestination">The index destination.</param>
        /// <param name="intCount">The count.</param>
        private void InsertCopiesPrivate(int indexSource, int indexDestination, int intCount)
        {
            if ((indexSource < 0) || (this.Count <= indexSource))
            {
                throw new ArgumentOutOfRangeException("indexSource", SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
            }
            if ((indexDestination < 0) || (this.Count < indexDestination))
            {
                throw new ArgumentOutOfRangeException("indexDestination", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
            }
            if (intCount <= 0)
            {
                throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
            }
            if ((this.DataGridView.NewRowIndex != -1) && (indexDestination == this.Count))
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
            }
            DataGridViewElementStates enmRowTemplateState = this.GetRowState(indexSource) & ~(DataGridViewElementStates.Selected | DataGridViewElementStates.Displayed);
            this.InsertCopiesPrivate(this.SharedRow(indexSource), enmRowTemplateState, indexDestination, intCount);
        }

        /// <summary>
        /// Inserts the copies private.
        /// </summary>
        /// <param name="objRowTemplate">The row template.</param>
        /// <param name="enmRowTemplateState">State of the row template.</param>
        /// <param name="indexDestination">The index destination.</param>
        /// <param name="intCount">The count.</param>
        private void InsertCopiesPrivate(DataGridViewRow objRowTemplate, DataGridViewElementStates enmRowTemplateState, int indexDestination, int intCount)
        {
            Point objNewCurrentCell = new Point(-1, -1);
            if (objRowTemplate.Index == -1)
            {
                if (intCount > 1)
                {
                    this.DataGridView.OnInsertingRow(indexDestination, objRowTemplate, enmRowTemplateState, ref objNewCurrentCell, true, intCount, false);
                    for (int i = 0; i < intCount; i++)
                    {
                        this.SharedList.Insert(indexDestination + i, objRowTemplate);
                        this.mobjRowStates.Insert(indexDestination + i, enmRowTemplateState);
                    }
                    this.DataGridView.OnInsertedRow_PreNotification(indexDestination, intCount);
                    this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), indexDestination, intCount, false, true, false, objNewCurrentCell);
                    for (int j = 0; j < intCount; j++)
                    {
                        this.DataGridView.OnInsertedRow_PostNotification(indexDestination + j, objNewCurrentCell, j == (intCount - 1));
                    }
                }
                else
                {
                    this.DataGridView.OnInsertingRow(indexDestination, objRowTemplate, enmRowTemplateState, ref objNewCurrentCell, true, 1, false);
                    this.SharedList.Insert(indexDestination, objRowTemplate);
                    this.mobjRowStates.Insert(indexDestination, enmRowTemplateState);
                    this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, this.SharedRow(indexDestination)), indexDestination, intCount, false, true, false, objNewCurrentCell);
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
                        for (int m = 1; m < intCount; m++)
                        {
                            this.SharedList.Insert(indexDestination + m, objDataGridViewRow);
                            this.mobjRowStates.Insert(indexDestination + m, enmRowTemplateState);
                        }
                        this.DataGridView.OnInsertedRow_PreNotification(indexDestination + 1, intCount - 1);
                        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), indexDestination, intCount, false, true, false, objNewCurrentCell);
                    }
                    else
                    {
                        this.UnshareRow(indexDestination);
                        for (int n = 1; n < intCount; n++)
                        {
                            this.InsertDuplicateRow(indexDestination + n, objRowTemplate, false, ref objNewCurrentCell);
                            this.UnshareRow(indexDestination + n);
                        }
                        this.DataGridView.OnInsertedRow_PreNotification(indexDestination + 1, intCount - 1);
                        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), indexDestination, intCount, false, true, false, objNewCurrentCell);
                    }
                    for (int k = 0; k < intCount; k++)
                    {
                        this.DataGridView.OnInsertedRow_PostNotification(indexDestination + k, objNewCurrentCell, k == (intCount - 1));
                    }
                }
                else
                {
                    if (this.IsCollectionChangedListenedTo)
                    {
                        this.UnshareRow(indexDestination);
                    }
                    this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, this.SharedRow(indexDestination)), indexDestination, 1, false, true, false, objNewCurrentCell);
                }
            }
        }

        /// <summary>Inserts a row into the collection at the specified position, based on the row at specified position.</summary>
        /// <param name="indexDestination">The position at which to insert the row.</param>
        /// <param name="indexSource">The index of the row on which to base the new row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than the number of rows in the collection minus one.-or-indexDestination is less than zero or greater than the number of rows in the collection.</exception>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-indexDestination is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
        /// <filterpriority>1</filterpriority>

        public virtual void InsertCopy(int indexSource, int indexDestination)
        {
            this.InsertCopies(indexSource, indexDestination, 1);
        }

        /// <summary>
        /// Inserts the duplicate row.
        /// </summary>
        /// <param name="indexDestination">The index destination.</param>
        /// <param name="objRowTemplate">The row template.</param>
        /// <param name="blnFirstInsertion">if set to <c>true</c> [first insertion].</param>
        /// <param name="objNewCurrentCell">The new current cell.</param>
        private void InsertDuplicateRow(int indexDestination, DataGridViewRow objRowTemplate, bool blnFirstInsertion, ref Point objNewCurrentCell)
        {
            DataGridViewRow objDataGridViewRow = (DataGridViewRow)objRowTemplate.Clone();
            objDataGridViewRow.StateInternal = DataGridViewElementStates.None;
            objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
            DataGridViewCellCollection objCells = objDataGridViewRow.Cells;
            int num = 0;
            foreach (DataGridViewCell objCell in objCells)
            {
                objCell.DataGridViewInternal = this.mobjDataGridView;
                objCell.OwningColumnInternal = this.DataGridView.Columns[num];
                num++;
            }
            DataGridViewElementStates enmRowState = objRowTemplate.State & ~(DataGridViewElementStates.Selected | DataGridViewElementStates.Displayed);
            if (objDataGridViewRow.HasHeaderCell)
            {
                objDataGridViewRow.HeaderCell.DataGridViewInternal = this.mobjDataGridView;
                objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
            }
            this.DataGridView.OnInsertingRow(indexDestination, objDataGridViewRow, enmRowState, ref objNewCurrentCell, blnFirstInsertion, 1, false);
            this.SharedList.Insert(indexDestination, objDataGridViewRow);
            this.mobjRowStates.Insert(indexDestination, enmRowState);
        }

        /// <summary>
        /// Inserts the internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objDataGridViewRow">The data grid view row.</param>
        internal void InsertInternal(int intRowIndex, DataGridViewRow objDataGridViewRow)
        {
            if ((intRowIndex < 0) || (this.Count < intRowIndex))
            {
                throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
            }
            if (objDataGridViewRow == null)
            {
                throw new ArgumentNullException("dataGridViewRow");
            }
            if (objDataGridViewRow.DataGridView != null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
            }
            if ((this.DataGridView.NewRowIndex != -1) && (intRowIndex == this.Count))
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
            }
            if (this.DataGridView.Columns.Count == 0)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
            }
            if (objDataGridViewRow.Cells.Count > this.DataGridView.Columns.Count)
            {
                throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
            }
            if (objDataGridViewRow.Selected)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
            }
            this.InsertInternal(intRowIndex, objDataGridViewRow, false);
        }

        /// <summary>
        /// Inserts the internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objDataGridViewRow">The data grid view row.</param>
        /// <param name="blnForce">if set to <c>true</c> [force].</param>
        internal void InsertInternal(int intRowIndex, DataGridViewRow objDataGridViewRow, bool blnForce)
        {
            Point objNewCurrentCell = new Point(-1, -1);
            if (blnForce)
            {
                if (this.DataGridView.Columns.Count == 0)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
                }
                if (objDataGridViewRow.Cells.Count > this.DataGridView.Columns.Count)
                {
                    throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
                }
            }
            this.DataGridView.CompleteCellsCollection(objDataGridViewRow);
            this.DataGridView.OnInsertingRow(intRowIndex, objDataGridViewRow, objDataGridViewRow.State, ref objNewCurrentCell, true, 1, blnForce);
            int num = 0;
            foreach (DataGridViewCell objCell in objDataGridViewRow.Cells)
            {
                objCell.DataGridViewInternal = this.mobjDataGridView;
                if (objCell.ColumnIndex == -1)
                {
                    objCell.OwningColumnInternal = this.DataGridView.Columns[num];
                }
                num++;
            }
            if (objDataGridViewRow.HasHeaderCell)
            {
                objDataGridViewRow.HeaderCell.DataGridViewInternal = this.DataGridView;
                objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
            }
            this.SharedList.Insert(intRowIndex, objDataGridViewRow);
            this.mobjRowStates.Insert(intRowIndex, objDataGridViewRow.State);
            objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
            if ((!this.RowIsSharable(intRowIndex) || RowHasValueOrToolTipText(objDataGridViewRow)) || this.IsCollectionChangedListenedTo)
            {
                objDataGridViewRow.IndexInternal = intRowIndex;
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewRow), intRowIndex, 1, false, true, false, objNewCurrentCell);
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
            {
                throw new ArgumentNullException("dataGridViewRows");
            }
            if (arrDataGridViewRows.Length == 1)
            {
                this.Insert(intRowIndex, arrDataGridViewRows[0]);
            }
            else
            {
                if ((intRowIndex < 0) || (intRowIndex > this.Count))
                {
                    throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
                }
                if (this.DataGridView.NoDimensionChangeAllowed)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
                }
                if ((this.DataGridView.NewRowIndex != -1) && (intRowIndex == this.Count))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
                }
                if (this.DataGridView.DataSource != null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
                }
                if (this.DataGridView.Columns.Count == 0)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
                }
                Point objNewCurrentCell = new Point(-1, -1);
                this.DataGridView.OnInsertingRows(intRowIndex, arrDataGridViewRows, ref objNewCurrentCell);
                int index = intRowIndex;
                foreach (DataGridViewRow objDataGridViewRow in arrDataGridViewRows)
                {
                    int num2 = 0;
                    foreach (DataGridViewCell objCell in objDataGridViewRow.Cells)
                    {
                        objCell.DataGridViewInternal = this.mobjDataGridView;
                        if (objCell.ColumnIndex == -1)
                        {
                            objCell.OwningColumnInternal = this.DataGridView.Columns[num2];
                        }
                        num2++;
                    }
                    if (objDataGridViewRow.HasHeaderCell)
                    {
                        objDataGridViewRow.HeaderCell.DataGridViewInternal = this.DataGridView;
                        objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
                    }
                    this.SharedList.Insert(index, objDataGridViewRow);
                    this.mobjRowStates.Insert(index, objDataGridViewRow.State);
                    objDataGridViewRow.IndexInternal = index;
                    objDataGridViewRow.DataGridViewInternal = this.mobjDataGridView;
                    index++;
                }
                this.DataGridView.OnInsertedRows_PreNotification(intRowIndex, arrDataGridViewRows);
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), intRowIndex, arrDataGridViewRows.Length, false, true, false, objNewCurrentCell);
                this.DataGridView.OnInsertedRows_PostNotification(arrDataGridViewRows, objNewCurrentCell);
            }
        }

        internal void InvalidateCachedRowCount(DataGridViewElementStates enmIncludeFilter)
        {
            if (enmIncludeFilter == DataGridViewElementStates.Visible)
            {
                this.InvalidateCachedRowCounts();
            }
            else if (enmIncludeFilter == DataGridViewElementStates.Frozen)
            {
                this.mintRowCountsVisibleFrozen = -1;
            }
            else if (enmIncludeFilter == DataGridViewElementStates.Selected)
            {
                this.mintRowCountsVisibleSelected = -1;
            }
        }

        internal void InvalidateCachedRowCounts()
        {
            this.mintRowCountsVisible = this.mintRowCountsVisibleFrozen = this.mintRowCountsVisibleSelected = -1;
        }

        internal void InvalidateCachedRowsHeight(DataGridViewElementStates enmIncludeFilter)
        {
            if (enmIncludeFilter == DataGridViewElementStates.Visible)
            {
                this.InvalidateCachedRowsHeights();
            }
            else if (enmIncludeFilter == DataGridViewElementStates.Frozen)
            {
                this.mintRowsHeightVisibleFrozen = -1;
            }
        }

        internal void InvalidateCachedRowsHeights()
        {
            this.mintRowsHeightVisible = this.mintRowsHeightVisibleFrozen = -1;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewRowCollection.CollectionChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            // Raise event if needed
            CollectionChangeEventHandler objEventHandler = this.CollectionChanged;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        private void OnCollectionChanged(CollectionChangeEventArgs e, int intRowIndex, int intRowCount)
        {
            Point objPoint1 = new Point(-1, -1);
            DataGridViewRow objDataGridViewRow1 = (DataGridViewRow)e.Element;
            int num1 = 0;
            if ((objDataGridViewRow1 != null) && (e.Action == CollectionChangeAction.Add))
            {
                num1 = this.SharedRow(intRowIndex).Index;
            }
            this.OnCollectionChanged_PreNotification(e.Action, intRowIndex, intRowCount, ref objDataGridViewRow1, false);
            if ((num1 == -1) && (this.SharedRow(intRowIndex).Index != -1))
            {
                e = new CollectionChangeEventArgs(e.Action, objDataGridViewRow1);
            }
            this.OnCollectionChanged(e);
            this.OnCollectionChanged_PostNotification(e.Action, intRowIndex, intRowCount, objDataGridViewRow1, false, false, false, objPoint1);
        }

        private void OnCollectionChanged(CollectionChangeEventArgs e, int intRowIndex, int intRowCount, bool blnChangeIsDeletion, bool blnChangeIsInsertion, bool blnRecreateNewRow, Point objNewCurrentCell)
        {
            DataGridViewRow objDataGridViewRow1 = (DataGridViewRow)e.Element;
            int num1 = 0;
            if ((objDataGridViewRow1 != null) && (e.Action == CollectionChangeAction.Add))
            {
                num1 = this.SharedRow(intRowIndex).Index;
            }
            this.OnCollectionChanged_PreNotification(e.Action, intRowIndex, intRowCount, ref objDataGridViewRow1, blnChangeIsInsertion);
            if ((num1 == -1) && (this.SharedRow(intRowIndex).Index != -1))
            {
                e = new CollectionChangeEventArgs(e.Action, objDataGridViewRow1);
            }
            this.OnCollectionChanged(e);
            this.OnCollectionChanged_PostNotification(e.Action, intRowIndex, intRowCount, objDataGridViewRow1, blnChangeIsDeletion, blnChangeIsInsertion, blnRecreateNewRow, objNewCurrentCell);
        }

        private void OnCollectionChanged_PostNotification(CollectionChangeAction enmCca, int intRowIndex, int intRowCount, DataGridViewRow objDataGridViewRow, bool blnChangeIsDeletion, bool blnChangeIsInsertion, bool blnRecreateNewRow, Point objNewCurrentCell)
        {
            if (blnChangeIsDeletion)
            {
                this.DataGridView.OnRowsRemovedInternal(intRowIndex, intRowCount);
            }
            else
            {
                this.DataGridView.OnRowsAddedInternal(intRowIndex, intRowCount);
            }
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
                    }
                    break;
            }
            this.DataGridView.OnRowCollectionChanged_PostNotification(blnRecreateNewRow, objNewCurrentCell.X == -1, enmCca, objDataGridViewRow, intRowIndex);
        }

        /// <summary>
        /// Called when [collection changed_ pre notification].
        /// </summary>
        /// <param name="enmCca">The cca.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="intRowCount">The row count.</param>
        /// <param name="objDataGridViewRow">The data grid view row.</param>
        /// <param name="blnChangeIsInsertion">if set to <c>true</c> [change is insertion].</param>
        private void OnCollectionChanged_PreNotification(CollectionChangeAction enmCca, int intRowIndex, int intRowCount, ref DataGridViewRow objDataGridViewRow, bool blnChangeIsInsertion)
        {
            int intHeight;
            bool blnUseRowShortcut = false;
            bool blnComputeVisibleRows = false;
            switch (enmCca)
            {
                case CollectionChangeAction.Add:
                    intHeight = 0;
                    this.UpdateRowCaches(intRowIndex, ref objDataGridViewRow, true);
                    if ((this.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
                    {
                        int intFirstDisplayedRowIndex = this.DataGridView.FirstDisplayedRowIndex;
                        if (intFirstDisplayedRowIndex != -1)
                        {
                            intHeight = this.SharedRow(intFirstDisplayedRowIndex).GetHeight(intFirstDisplayedRowIndex);
                        }
                        break;
                    }
                    blnUseRowShortcut = true;
                    blnComputeVisibleRows = blnChangeIsInsertion;
                    break;

                case CollectionChangeAction.Remove:
                    {
                        DataGridViewElementStates enmRowState = this.GetRowState(intRowIndex);
                        bool blnFlag3 = (enmRowState & DataGridViewElementStates.Visible) != DataGridViewElementStates.None;
                        bool blnFlag4 = (enmRowState & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None;
                        this.mobjRowStates.RemoveAt(intRowIndex);
                        this.SharedList.RemoveAt(intRowIndex);
                        this.DataGridView.OnRemovedRow_PreNotification(intRowIndex);
                        if (!blnFlag3)
                        {
                            blnUseRowShortcut = true;
                        }
                        else if (!blnFlag4)
                        {
                            if ((this.DataGridView.FirstDisplayedScrollingRowIndex != -1) && (intRowIndex > this.DataGridView.FirstDisplayedScrollingRowIndex))
                            {
                                int num4 = 0;
                                int num5 = this.DataGridView.FirstDisplayedRowIndex;
                                if (num5 != -1)
                                {
                                    num4 = this.SharedRow(num5).GetHeight(num5);
                                }
                                blnUseRowShortcut = this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, (this.DataGridView.LayoutInfo.Data.Height + this.DataGridView.VerticalScrollingOffset)) && (num4 <= this.DataGridView.LayoutInfo.Data.Height);
                            }
                        }
                        else
                        {
                            blnUseRowShortcut = (this.DataGridView.FirstDisplayedScrollingRowIndex == -1) && this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height);
                        }
                        goto Label_02DF;
                    }
                case CollectionChangeAction.Refresh:
                    this.InvalidateCachedRowCounts();
                    this.InvalidateCachedRowsHeights();
                    goto Label_02DF;

                default:
                    goto Label_02DF;
            }
            if (blnChangeIsInsertion)
            {
                this.DataGridView.OnInsertedRow_PreNotification(intRowIndex, 1);
                if (!blnUseRowShortcut)
                {
                    if ((this.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
                    {
                        blnUseRowShortcut = (this.DataGridView.FirstDisplayedScrollingRowIndex == -1) && this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height);
                    }
                    else if ((this.DataGridView.FirstDisplayedScrollingRowIndex != -1) && (intRowIndex > this.DataGridView.FirstDisplayedScrollingRowIndex))
                    {
                        blnUseRowShortcut = this.GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, this.DataGridView.LayoutInfo.Data.Height + this.DataGridView.VerticalScrollingOffset) && (intHeight <= this.DataGridView.LayoutInfo.Data.Height);
                    }
                }
            }
            else
            {
                this.DataGridView.OnAddedRow_PreNotification(intRowIndex);
                if (!blnUseRowShortcut)
                {
                    int num3 = (this.GetRowsHeight(DataGridViewElementStates.Visible) - this.DataGridView.VerticalScrollingOffset) - objDataGridViewRow.GetHeight(intRowIndex);
                    objDataGridViewRow = this.SharedRow(intRowIndex);
                    blnUseRowShortcut = (this.DataGridView.LayoutInfo.Data.Height < num3) && (intHeight <= this.DataGridView.LayoutInfo.Data.Height);
                }
            }
        Label_02DF:
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
            {
                throw new ArgumentNullException("dataGridViewRow");
            }
            if (objDataGridViewRow.DataGridView != this.DataGridView)
            {
                throw new ArgumentException(SR.GetString("DataGridView_RowDoesNotBelongToDataGridView"), "dataGridViewRow");
            }
            if (objDataGridViewRow.Index == -1)
            {
                throw new ArgumentException(SR.GetString("DataGridView_RowMustBeUnshared"), "dataGridViewRow");
            }
            this.RemoveAt(objDataGridViewRow.Index);
        }

        /// <summary>Removes the row at the specified position from the collection.</summary>
        /// <param name="index">The position of the row to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero and greater than the number of rows in the collection minus one. </exception>
        /// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-index is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is bound to an <see cref="T:System.ComponentModel.IBindingList"></see> implementation with <see cref="P:System.ComponentModel.IBindingList.AllowRemove"></see> and <see cref="P:System.ComponentModel.IBindingList.SupportsChangeNotification"></see> property values that are not both true.</exception>
        /// <filterpriority>1</filterpriority>

        public virtual void RemoveAt(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException("index", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
            }
            if (this.DataGridView.NewRowIndex == index)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotDeleteNewRow"));
            }
            if (this.DataGridView.NoDimensionChangeAllowed)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
            }
            if (this.DataGridView.DataSource != null)
            {
                IBindingList objList = this.DataGridView.DataConnection.List as IBindingList;
                if (((objList != null) && objList.AllowRemove) && objList.SupportsChangeNotification)
                {
                    objList.RemoveAt(index);
                    return;
                }
                throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CantRemoveRowsWithWrongSource"));
            }
            this.RemoveAtInternal(index, false);
        }

        internal void RemoveAtInternal(int index, bool blnForce)
        {
            DataGridViewRow objDataGridViewRow = this.SharedRow(index);
            Point objNewCurrentCell = new Point(-1, -1);
            if (this.IsCollectionChangedListenedTo || objDataGridViewRow.GetDisplayed(index))
            {
                objDataGridViewRow = this[index];
            }
            objDataGridViewRow = this.SharedRow(index);
            this.DataGridView.OnRemovingRow(index, out objNewCurrentCell, blnForce);
            this.UpdateRowCaches(index, ref objDataGridViewRow, false);
            if (objDataGridViewRow.Index != -1)
            {
                this.mobjRowStates[index] = objDataGridViewRow.State;
                objDataGridViewRow.DetachFromDataGridView();
            }
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, objDataGridViewRow), index, 1, true, false, false, objNewCurrentCell);

        }

        private static bool RowHasValueOrToolTipText(DataGridViewRow objDataGridViewRow)
        {
            foreach (DataGridViewCell objCell1 in objDataGridViewRow.Cells)
            {
                if (objCell1.HasValue || objCell1.HasToolTipText)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Rows the is sharable.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        internal bool RowIsSharable(int index)
        {
            DataGridViewRow objDataGridViewRow = this.SharedRow(index);
            if (objDataGridViewRow.Index != -1)
            {
                return false;
            }
            foreach (DataGridViewCell objCell in objDataGridViewRow.Cells)
            {
                if ((objCell.State & ~objCell.CellStateFromColumnRowStates(this.mobjRowStates[index])) != DataGridViewElementStates.None)
                {
                    return false;
                }
            }
            return true;
        }

        internal void SetRowState(int intRowIndex, DataGridViewElementStates enmElementState, bool blnValue)
        {
            DataGridViewRow objDataGridViewRow1 = this.SharedRow(intRowIndex);
            if (objDataGridViewRow1.Index == -1)
            {
                if (((((DataGridViewElementStates)this.mobjRowStates[intRowIndex]) & enmElementState) != DataGridViewElementStates.None) != blnValue)
                {
                    if (((enmElementState == DataGridViewElementStates.Frozen) || (enmElementState == DataGridViewElementStates.Visible)) || (enmElementState == DataGridViewElementStates.ReadOnly))
                    {
                        objDataGridViewRow1.OnSharedStateChanging(intRowIndex, enmElementState);
                    }
                    if (blnValue)
                    {
                        this.mobjRowStates[intRowIndex] = ((DataGridViewElementStates)this.mobjRowStates[intRowIndex]) | enmElementState;
                    }
                    else
                    {
                        this.mobjRowStates[intRowIndex] = ((DataGridViewElementStates)this.mobjRowStates[intRowIndex]) & ~enmElementState;
                    }
                    objDataGridViewRow1.OnSharedStateChanged(intRowIndex, enmElementState);
                }
            }
            else
            {
                DataGridViewElementStates enmElementState1 = enmElementState;
                if (enmElementState1 <= DataGridViewElementStates.Resizable)
                {
                    switch (enmElementState1)
                    {
                        case DataGridViewElementStates.Displayed:
                            objDataGridViewRow1.DisplayedInternal = blnValue;
                            return;

                        case DataGridViewElementStates.Frozen:
                            objDataGridViewRow1.Frozen = blnValue;
                            return;

                        case (DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed):
                            return;

                        case DataGridViewElementStates.ReadOnly:
                            objDataGridViewRow1.ReadOnlyInternal = blnValue;
                            return;

                        case DataGridViewElementStates.Resizable:
                            objDataGridViewRow1.Resizable = blnValue ? DataGridViewTriState.True : DataGridViewTriState.False;
                            return;
                    }
                }
                else
                {
                    if (enmElementState1 != DataGridViewElementStates.Selected)
                    {
                        if (enmElementState1 != DataGridViewElementStates.Visible)
                        {
                            return;
                        }
                    }
                    else
                    {
                        objDataGridViewRow1.SelectedInternal = blnValue;
                        return;
                    }
                    objDataGridViewRow1.Visible = blnValue;
                }
            }
        }

        /// <summary>Returns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> at the specified index.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> positioned at the specified index.</returns>
        /// <param name="intRowIndex">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to get.</param>
        /// <filterpriority>1</filterpriority>
        public DataGridViewRow SharedRow(int intRowIndex)
        {
            return (DataGridViewRow)this.SharedList[intRowIndex];
        }

        internal DataGridViewElementStates SharedRowState(int intRowIndex)
        {
            return (DataGridViewElementStates)this.mobjRowStates[intRowIndex];
        }

        internal void Sort(IComparer objCustomComparer, bool blnAscending)
        {
            if (this.mobjItems.Count > 0)
            {
                RowComparer objComparer1 = new RowComparer(this, objCustomComparer, blnAscending);
                this.mobjItems.CustomSort(objComparer1);
            }
        }

        internal void SwapSortedRows(int intRowIndex1, int intRowIndex2)
        {
            this.DataGridView.SwapSortedRows(intRowIndex1, intRowIndex2);
            DataGridViewRow objDataGridViewRow1 = this.SharedRow(intRowIndex1);
            DataGridViewRow objDataGridViewRow2 = this.SharedRow(intRowIndex2);
            if (objDataGridViewRow1.Index != -1)
            {
                objDataGridViewRow1.IndexInternal = intRowIndex2;
            }
            if (objDataGridViewRow2.Index != -1)
            {
                objDataGridViewRow2.IndexInternal = intRowIndex1;
            }
            if (this.DataGridView.VirtualMode)
            {
                int num1 = this.DataGridView.Columns.Count;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    DataGridViewCell objCell1 = objDataGridViewRow1.Cells[num2];
                    DataGridViewCell objCell2 = objDataGridViewRow2.Cells[num2];
                    object obj1 = objCell1.GetValueInternal(intRowIndex1);
                    object obj2 = objCell2.GetValueInternal(intRowIndex2);
                    objCell1.SetValueInternal(intRowIndex1, obj2);
                    objCell2.SetValueInternal(intRowIndex2, obj1);
                }
            }
            object obj3 = this.mobjItems[intRowIndex1];
            this.mobjItems[intRowIndex1] = this.mobjItems[intRowIndex2];
            this.mobjItems[intRowIndex2] = obj3;
            DataGridViewElementStates enmElementState = (DataGridViewElementStates)this.mobjRowStates[intRowIndex1];
            this.mobjRowStates[intRowIndex1] = this.mobjRowStates[intRowIndex2];
            this.mobjRowStates[intRowIndex2] = enmElementState;
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.mobjItems.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new UnsharingRowEnumerator(this);
        }

        int IList.Add(object objValue)
        {
            return this.Add((DataGridViewRow)objValue);
        }

        void IList.Clear()
        {
            this.Clear();
        }

        bool IList.Contains(object objValue)
        {
            return this.mobjItems.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjItems.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            this.Insert(index, (DataGridViewRow)objValue);
        }

        void IList.Remove(object objValue)
        {
            this.Remove((DataGridViewRow)objValue);
        }

        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        private void UnshareRow(int intRowIndex)
        {
            this.SharedRow(intRowIndex).IndexInternal = intRowIndex;
            this.SharedRow(intRowIndex).StateInternal = this.SharedRowState(intRowIndex);
        }

        private void UpdateRowCaches(int intRowIndex, ref DataGridViewRow objDataGridViewRow, bool blnAdding)
        {
            if (((this.mintRowCountsVisible != -1) || (this.mintRowCountsVisibleFrozen != -1)) || (((this.mintRowCountsVisibleSelected != -1) || (this.mintRowsHeightVisible != -1)) || (this.mintRowsHeightVisibleFrozen != -1)))
            {
                DataGridViewElementStates enmElementState = this.GetRowState(intRowIndex);
                if ((enmElementState & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
                {
                    int num1 = blnAdding ? 1 : -1;
                    int num2 = 0;
                    if ((this.mintRowsHeightVisible != -1) || ((this.mintRowsHeightVisibleFrozen != -1) && ((enmElementState & (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen)) == (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen))))
                    {
                        num2 = blnAdding ? objDataGridViewRow.GetHeight(intRowIndex) : -objDataGridViewRow.GetHeight(intRowIndex);
                        objDataGridViewRow = this.SharedRow(intRowIndex);
                    }
                    if (this.mintRowCountsVisible != -1)
                    {
                        this.mintRowCountsVisible += num1;
                    }
                    if (this.mintRowsHeightVisible != -1)
                    {
                        this.mintRowsHeightVisible += num2;
                    }
                    if ((enmElementState & (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen)) == (DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen))
                    {
                        if (this.mintRowCountsVisibleFrozen != -1)
                        {
                            this.mintRowCountsVisibleFrozen += num1;
                        }
                        if (this.mintRowsHeightVisibleFrozen != -1)
                        {
                            this.mintRowsHeightVisibleFrozen += num2;
                        }
                    }
                    if (((enmElementState & (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected)) == (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected)) && (this.mintRowCountsVisibleSelected != -1))
                    {
                        this.mintRowCountsVisibleSelected += num1;
                    }
                }
            }
        }


        /// <summary>Gets the number of rows in the collection.</summary>
        /// <returns>The number of rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public int Count
        {
            get
            {
                return this.mobjItems.Count;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the collection.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
        protected Gizmox.WebGUI.Forms.DataGridView DataGridView
        {
            get
            {
                return this.mobjDataGridView;
            }
        }

        internal bool IsCollectionChangedListenedTo
        {
            get
            {
                return (this.CollectionChanged != null);
            }
        }

        /// <summary>Gets the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index. Accessing a <see cref="T:System.Windows.Forms.DataGridViewRow"></see> with this indexer causes the row to become unshared. To keep the row shared, use the <see cref="M:System.Windows.Forms.DataGridViewRowCollection.SharedRow(System.Int32)"></see> method. For more information, see Best Practices for Scaling the Windows Forms DataGridView Control.</returns>
        /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> to get.</param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public DataGridViewRow this[int index]
        {
            get
            {
                DataGridViewRow objDataGridViewRow = this.SharedRow(index);
                if (objDataGridViewRow.Index != -1)
                {
                    return objDataGridViewRow;
                }
                if ((index == 0) && (this.mobjItems.Count == 1))
                {
                    objDataGridViewRow.IndexInternal = 0;
                    objDataGridViewRow.StateInternal = this.SharedRowState(0);
                    if (this.DataGridView != null)
                    {
                        this.DataGridView.OnRowUnshared(objDataGridViewRow);
                    }
                    return objDataGridViewRow;
                }
                DataGridViewRow objDataGridViewRow2 = (DataGridViewRow)objDataGridViewRow.Clone();
                objDataGridViewRow2.IndexInternal = index;
                objDataGridViewRow2.DataGridViewInternal = objDataGridViewRow.DataGridView;
                objDataGridViewRow2.StateInternal = this.SharedRowState(index);
                this.SharedList[index] = objDataGridViewRow2;
                int num = 0;
                foreach (DataGridViewCell objCell in objDataGridViewRow2.Cells)
                {
                    objCell.DataGridViewInternal = objDataGridViewRow.DataGridView;
                    objCell.OwningRowInternal = objDataGridViewRow2;
                    objCell.OwningColumnInternal = this.DataGridView.Columns[num];
                    num++;
                }
                if (objDataGridViewRow2.HasHeaderCell)
                {
                    objDataGridViewRow2.HeaderCell.DataGridViewInternal = objDataGridViewRow.DataGridView;
                    objDataGridViewRow2.HeaderCell.OwningRowInternal = objDataGridViewRow2;
                }
                if (this.DataGridView != null)
                {
                    this.DataGridView.OnRowUnshared(objDataGridViewRow2);
                }
                return objDataGridViewRow2;
            }
        }

        /// <summary>Gets an array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</summary>
        /// <returns>An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</returns>
        protected ArrayList List
        {
            get
            {
                int num1 = this.Count;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    DataGridViewRow objDataGridViewRow1 = this[num2];
                }
                return this.mobjItems;
            }
        }

        internal ArrayList SharedList
        {
            get
            {
                return this.mobjItems;
            }
        }

        int ICollection.Count
        {
            get
            {
                return this.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        private DataGridView mobjDataGridView;
        private RowArrayList mobjItems;
        private int mintRowCountsVisible;
        private int mintRowCountsVisibleFrozen;
        private int mintRowCountsVisibleSelected;
        private int mintRowsHeightVisible;
        private int mintRowsHeightVisibleFrozen;
        private List<DataGridViewElementStates> mobjRowStates;

        [Serializable()]
        private class RowArrayList : ArrayList
        {
            public RowArrayList(DataGridViewRowCollection objOwner)
            {
                this.mobjOwner = objOwner;
            }

            private void CustomQuickSort(int intLeft, int intRight)
            {
                if ((intRight - intLeft) < 2)
                {
                    if (((intRight - intLeft) > 0) && (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intLeft), this.mobjRowComparer.GetComparedObject(intRight), intLeft, intRight) > 0))
                    {
                        this.mobjOwner.SwapSortedRows(intLeft, intRight);
                    }
                }
                else
                {
                    do
                    {
                        int num1 = (intLeft + intRight) >> 1;
                        object obj1 = this.Pivot(intLeft, num1, intRight);
                        int num2 = intLeft + 1;
                        int num3 = intRight - 1;
                        do
                        {
                            while ((num1 != num2) && (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(num2), obj1, num2, num1) < 0))
                            {
                                num2++;
                            }
                            while ((num1 != num3) && (this.mobjRowComparer.CompareObjects(obj1, this.mobjRowComparer.GetComparedObject(num3), num1, num3) < 0))
                            {
                                num3--;
                            }
                            if (num2 > num3)
                            {
                                break;
                            }
                            if (num2 < num3)
                            {
                                this.mobjOwner.SwapSortedRows(num2, num3);
                                if (num2 == num1)
                                {
                                    num1 = num3;
                                }
                                else if (num3 == num1)
                                {
                                    num1 = num2;
                                }
                            }
                            num2++;
                            num3--;
                        }
                        while (num2 <= num3);
                        if ((num3 - intLeft) <= (intRight - num2))
                        {
                            if (intLeft < num3)
                            {
                                this.CustomQuickSort(intLeft, num3);
                            }
                            intLeft = num2;
                        }
                        else
                        {
                            if (num2 < intRight)
                            {
                                this.CustomQuickSort(num2, intRight);
                            }
                            intRight = num3;
                        }
                    }
                    while (intLeft < intRight);
                }
            }

            public void CustomSort(DataGridViewRowCollection.RowComparer objRowComparer)
            {
                this.mobjRowComparer = objRowComparer;
                this.CustomQuickSort(0, this.Count - 1);
            }

            private object Pivot(int intLeft, int intCenter, int intRight)
            {
                if (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intLeft), this.mobjRowComparer.GetComparedObject(intCenter), intLeft, intCenter) > 0)
                {
                    this.mobjOwner.SwapSortedRows(intLeft, intCenter);
                }
                if (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intLeft), this.mobjRowComparer.GetComparedObject(intRight), intLeft, intRight) > 0)
                {
                    this.mobjOwner.SwapSortedRows(intLeft, intRight);
                }
                if (this.mobjRowComparer.CompareObjects(this.mobjRowComparer.GetComparedObject(intCenter), this.mobjRowComparer.GetComparedObject(intRight), intCenter, intRight) > 0)
                {
                    this.mobjOwner.SwapSortedRows(intCenter, intRight);
                }
                return this.mobjRowComparer.GetComparedObject(intCenter);
            }


            private DataGridViewRowCollection mobjOwner;
            private DataGridViewRowCollection.RowComparer mobjRowComparer;
        }

        [Serializable()]
        private class RowComparer
        {
            static RowComparer()
            {
                DataGridViewRowCollection.RowComparer.mobjMax = new ComparedObjectMax();
            }

            public RowComparer(DataGridViewRowCollection objDataGridViewRows, IComparer objCustomComparer, bool blnAscending)
            {
                this.mobjDataGridView = objDataGridViewRows.DataGridView;
                this.mobjDataGridViewRows = objDataGridViewRows;
                this.mobjDataGridViewSortedColumn = this.mobjDataGridView.SortedColumn;
                if (this.mobjDataGridViewSortedColumn == null)
                {
                    this.mintSortedColumnIndex = -1;
                }
                else
                {
                    this.mintSortedColumnIndex = this.mobjDataGridViewSortedColumn.Index;
                }
                this.mobjCustomComparer = objCustomComparer;
                this.mblnAscending = blnAscending;
            }

            internal int CompareObjects(object objValue1, object objValue2, int intRowIndex1, int intRowIndex2)
            {
                if (objValue1 is ComparedObjectMax)
                {
                    return 1;
                }
                if (objValue2 is ComparedObjectMax)
                {
                    return -1;
                }
                int num1 = 0;
                if (this.mobjCustomComparer == null)
                {
                    if (!this.mobjDataGridView.OnSortCompare(this.mobjDataGridViewSortedColumn, objValue1, objValue2, intRowIndex1, intRowIndex2, out num1))
                    {
                        if (!(objValue1 is IComparable) && !(objValue2 is IComparable))
                        {
                            if (objValue1 == null)
                            {
                                if (objValue2 == null)
                                {
                                    num1 = 0;
                                }
                                else
                                {
                                    num1 = 1;
                                }
                            }
                            else if (objValue2 == null)
                            {
                                num1 = -1;
                            }
                            else
                            {
                                num1 = Comparer.Default.Compare(objValue1.ToString(), objValue2.ToString());
                            }
                        }
                        else
                        {
                            num1 = Comparer.Default.Compare(objValue1, objValue2);
                        }
                        if (num1 == 0)
                        {
                            if (this.mblnAscending)
                            {
                                num1 = intRowIndex1 - intRowIndex2;
                            }
                            else
                            {
                                num1 = intRowIndex2 - intRowIndex1;
                            }
                        }
                    }
                }
                else
                {
                    num1 = this.mobjCustomComparer.Compare(objValue1, objValue2);
                }
                if (this.mblnAscending)
                {
                    return num1;
                }
                return -num1;
            }

            internal object GetComparedObject(int intRowIndex)
            {
                if ((this.mobjDataGridView.NewRowIndex != -1) && (intRowIndex == this.mobjDataGridView.NewRowIndex))
                {
                    return DataGridViewRowCollection.RowComparer.mobjMax;
                }
                if (this.mobjCustomComparer == null)
                {
                    DataGridViewRow objDataGridViewRow1 = this.mobjDataGridViewRows.SharedRow(intRowIndex);
                    return objDataGridViewRow1.Cells[this.mintSortedColumnIndex].GetValueInternal(intRowIndex);
                }
                return this.mobjDataGridViewRows[intRowIndex];
            }


            private bool mblnAscending;
            private IComparer mobjCustomComparer;
            private DataGridView mobjDataGridView;
            private DataGridViewRowCollection mobjDataGridViewRows;
            private DataGridViewColumn mobjDataGridViewSortedColumn;
            private static ComparedObjectMax mobjMax;
            private int mintSortedColumnIndex;


            [Serializable()]
            private class ComparedObjectMax
            {
            }
        }

        [Serializable()]
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
                if (this.mintCurrent < (this.mobjOwner.Count - 1))
                {
                    this.mintCurrent++;
                    return true;
                }
                this.mintCurrent = this.mobjOwner.Count;
                return false;
            }

            void IEnumerator.Reset()
            {
                this.mintCurrent = -1;
            }


            object IEnumerator.Current
            {
                get
                {
                    if (this.mintCurrent == -1)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_EnumNotStarted"));
                    }
                    if (this.mintCurrent == this.mobjOwner.Count)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_EnumFinished"));
                    }
                    return this.mobjOwner[this.mintCurrent];
                }
            }


        }
    }

    #endregion

    #region DataGridViewSelectedCellCollection Class

    /// <summary>Represents a collection of cells that are selected in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ListBindable(false)]
    [Serializable()]
    public class DataGridViewSelectedCellCollection : BaseCollection, IList, ICollection, IEnumerable
    {
        internal DataGridViewSelectedCellCollection()
        {
            this.mobjItems = new ArrayList();
        }

        internal int Add(DataGridViewCell objDataGridViewCell)
        {
            return this.mobjItems.Add(objDataGridViewCell);
        }

        internal void AddCellLinkedList(DataGridViewCellLinkedList dataGridViewCells)
        {
            foreach (DataGridViewCell objCell1 in dataGridViewCells)
            {
                this.mobjItems.Add(objCell1);
            }
        }

        /// <summary>Clears the collection. </summary>
        /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        /// <summary>Determines whether the specified cell is contained in the collection.</summary>
        /// <returns>true if dataGridViewCell is in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedCellCollection"></see>; otherwise, false.</returns>
        /// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedCellCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(DataGridViewCell objDataGridViewCell)
        {
            return (this.mobjItems.IndexOf(objDataGridViewCell) != -1);
        }

        /// <summary>Copies the elements of the collection to the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> array, starting at the specified index.</summary>
        /// <param name="arrCells">The one-dimensional array of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> is greater than the available space from index to the end of array.</exception>
        /// <exception cref="T:System.InvalidCastException">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> cannot be cast automatically to the type of array.</exception>
        /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(DataGridViewCell[] arrCells, int index)
        {
            this.mobjItems.CopyTo(arrCells, index);
        }

        /// <summary>Inserts a cell into the collection.</summary>
        /// <param name="objDataGridViewCell">The object to be added to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedCellCollection"></see>.</param>
        /// <param name="index">The index at which dataGridViewCell should be inserted.</param>
        /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Insert(int index, DataGridViewCell objDataGridViewCell)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.mobjItems.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.mobjItems.GetEnumerator();
        }

        int IList.Add(object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.Clear()
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        bool IList.Contains(object objValue)
        {
            return this.mobjItems.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjItems.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.Remove(object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.RemoveAt(int index)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }


        /// <summary>Gets the cell at the specified index.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> at the specified index.</returns>
        /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to get from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedCellCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public DataGridViewCell this[int index]
        {
            get
            {
                return (DataGridViewCell)this.mobjItems[index];
            }
        }

        /// <summary>Gets a list of elements in the collection.</summary>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection.</returns>
        protected override ArrayList List
        {
            get
            {
                return this.mobjItems;
            }
        }

        int ICollection.Count
        {
            get
            {
                return this.mobjItems.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return true;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.mobjItems[index];
            }
            set
            {
                throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
            }
        }


        private ArrayList mobjItems;
    }

    #endregion

    #region DataGridViewSelectedColumnCollection Class

    /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects that are selected in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ListBindable(false)]
    [Serializable()]
    public class DataGridViewSelectedColumnCollection : BaseCollection, IList, ICollection, IEnumerable
    {
        internal DataGridViewSelectedColumnCollection()
        {
            this.mobjItems = new ArrayList();
        }

        internal int Add(DataGridViewColumn objDataGridViewColumn)
        {
            return this.mobjItems.Add(objDataGridViewColumn);
        }

        /// <summary>Clears the collection.</summary>
        /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        /// <summary>Determines whether the specified column is contained in the collection.</summary>
        /// <returns>true if the dataGridViewColumn parameter is in the collection; otherwise, false.</returns>
        /// <param name="objDataGridViewColumn">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(DataGridViewColumn objDataGridViewColumn)
        {
            return (this.mobjItems.IndexOf(objDataGridViewColumn) != -1);
        }

        /// <summary>Copies the elements of the collection to the specified array, starting at the specified index.</summary>
        /// <param name="arrColumns">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in the array at which copying begins.</param>
        /// <exception cref="T:System.InvalidCastException">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> cannot be cast automatically to the type of array.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> is greater than the available space from index to the end of array.</exception>
        /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(DataGridViewColumn[] arrColumns, int index)
        {
            this.mobjItems.CopyTo(arrColumns, index);
        }

        /// <summary>Inserts a column into the collection at the specified position.</summary>
        /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see>.</param>
        /// <param name="index">The zero-based index at which the column should be inserted. </param>
        /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Insert(int index, DataGridViewColumn objDataGridViewColumn)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.mobjItems.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.mobjItems.GetEnumerator();
        }

        int IList.Add(object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.Clear()
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        bool IList.Contains(object objValue)
        {
            return this.mobjItems.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjItems.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.Remove(object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.RemoveAt(int index)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }


        /// <summary>Gets the column at the specified index.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> at the specified index.</returns>
        /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to get from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public DataGridViewColumn this[int index]
        {
            get
            {
                return (DataGridViewColumn)this.mobjItems[index];
            }
        }

        /// <summary>
        /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
        /// </summary>
        /// <value></value>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
        protected override ArrayList List
        {
            get
            {
                return this.mobjItems;
            }
        }

        int ICollection.Count
        {
            get
            {
                return this.mobjItems.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return true;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.mobjItems[index];
            }
            set
            {
                throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
            }
        }


        private ArrayList mobjItems;
    }

    #endregion

    #region DataGridViewSelectedRowCollection Class

    /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects that are selected in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ListBindable(false)]
    [Serializable()]
    public class DataGridViewSelectedRowCollection : BaseCollection, IList, ICollection, IEnumerable
    {
        private ArrayList mobjItems;

        internal DataGridViewSelectedRowCollection()
        {
            this.mobjItems = new ArrayList();
        }

        internal int Add(DataGridViewRow objDataGridViewRow)
        {
            return this.mobjItems.Add(objDataGridViewRow);
        }

        /// <summary>Clears the collection.</summary>
        /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        /// <summary>Determines whether the specified row is contained in the collection.</summary>
        /// <returns>true if dataGridViewRow is in the collection; otherwise, false.</returns>
        /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public bool Contains(DataGridViewRow objDataGridViewRow)
        {
            return (this.mobjItems.IndexOf(objDataGridViewRow) != -1);
        }

        /// <summary>Copies the elements of the collection to the specified array, starting at the specified index.</summary>
        /// <param name="arrRows">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in the array at which copying begins.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> is greater than the available space from index to the end of array.</exception>
        /// <exception cref="T:System.InvalidCastException">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> cannot be cast automatically to the type of array.</exception>
        /// <exception cref="T:System.ArgumentNullException">array is null.</exception>
        /// <filterpriority>1</filterpriority>
        public void CopyTo(DataGridViewRow[] arrRows, int index)
        {
            this.mobjItems.CopyTo(arrRows, index);
        }

        /// <summary>Inserts a row into the collection at the specified position.</summary>
        /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see>.</param>
        /// <param name="index">The zero-based index at which dataGridViewRow should be inserted. </param>
        /// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Insert(int index, DataGridViewRow objDataGridViewRow)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.mobjItems.CopyTo(objArray, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.mobjItems.GetEnumerator();
        }

        int IList.Add(object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.Clear()
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        bool IList.Contains(object objValue)
        {
            return this.mobjItems.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjItems.IndexOf(objValue);
        }

        void IList.Insert(int index, object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.Remove(object objValue)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }

        void IList.RemoveAt(int index)
        {
            throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
        }


        /// <summary>Gets the row at the specified index.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> at the current index.</returns>
        /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see>.</param>
        /// <filterpriority>1</filterpriority>
        public DataGridViewRow this[int index]
        {
            get
            {
                return (DataGridViewRow)this.mobjItems[index];
            }
        }

        /// <summary>
        /// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
        /// </summary>
        /// <value></value>
        /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
        protected override ArrayList List
        {
            get
            {
                return this.mobjItems;
            }
        }

        int ICollection.Count
        {
            get
            {
                return this.mobjItems.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return true;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.mobjItems[index];
            }
            set
            {
                throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
            }
        }



    }

    #endregion
}
