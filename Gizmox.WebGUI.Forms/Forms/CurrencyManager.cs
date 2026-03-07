// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CurrencyManager
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Manages a list of <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class CurrencyManager : BindingManagerBase
  {
    private bool mblnBound;
    private object mobjDataSource;
    /// <summary>Specifies the data type of the list.</summary>
    protected Type finalType;
    private bool mblnInChangeRecordState;
    private int mintLastGoodKnownRow;
    [NonSerialized]
    private IList mobjList;
    /// <summary>Specifies the current position of the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> in the list.</summary>
    protected int listposition;
    private bool mblnPullingData;
    private ItemChangedEventArgs mobjResetEvent;
    private bool mblnShouldBind;
    private bool mblnSuspendPushDataInCurrentChanged;
    /// <summary>
    /// Manual serialization interception for 'NewRow' when the data source is a System.Data.DataView.
    /// A 'NewRow' is a row that has not yet been committed to the underlying DataTable, but can have values in one
    /// or more fields. System.Data.DataView is an unserializable type which means 'NewRow' must be manually serialized
    /// and deserialized.
    /// </summary>
    private object[] marrSerializedDataViewNewRowValues;

    /// <summary>Occurs when the current item has been altered.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    public event ItemChangedEventHandler ItemChanged;

    /// <summary>Occurs when the list changes or an item in the list changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event ListChangedEventHandler ListChanged;

    /// <summary>Occurs when the metadata of the <see cref="P:Gizmox.WebGUI.Forms.CurrencyManager.List"></see> has changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    public event EventHandler MetaDataChanged;

    internal CurrencyManager(object objDataSource)
    {
      this.mblnShouldBind = true;
      this.listposition = -1;
      this.mintLastGoodKnownRow = -1;
      this.mobjResetEvent = new ItemChangedEventArgs(-1);
      this.SetDataSource(objDataSource);
    }

    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      this.marrSerializedDataViewNewRowValues = (object[]) null;
      try
      {
        if (this.List != null)
        {
          if (this.List.GetType() == typeof (DataView))
          {
            if (this.Position >= 0)
            {
              if (this.Position < this.List.Count)
              {
                if (((DataRowView) this[this.Position]).IsNew)
                  this.marrSerializedDataViewNewRowValues = ((DataRowView) this[this.Position]).Row.ItemArray;
              }
            }
          }
        }
      }
      catch
      {
      }
      base.OnSerializableObjectSerializing(objWriter);
    }

    protected override void OnSerializableObjectDeserialized()
    {
      base.OnSerializableObjectDeserialized();
      if (this.marrSerializedDataViewNewRowValues == null)
        return;
      object[] viewNewRowValues = this.marrSerializedDataViewNewRowValues;
      this.marrSerializedDataViewNewRowValues = (object[]) null;
      this.UnwireEvents(this.List);
      if (this.List.GetType() == typeof (DataView))
        ((DataView) this.List).AddNew().Row.ItemArray = viewNewRowValues;
      this.WireEvents(this.List);
      this.marrSerializedDataViewNewRowValues = (object[]) null;
    }

    /// <summary>Adds a new item to the underlying list.</summary>
    /// <exception cref="T:System.NotSupportedException">The underlying data source does not implement <see cref="T:System.ComponentModel.IBindingList"></see>, or the data source has thrown an exception because the user has attempted to add a row to a read-only or fixed-size <see cref="T:System.Data.DataView"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    public override void AddNew()
    {
      if (!(this.List is IBindingList list))
        throw new NotSupportedException(SR.GetString("CurrencyManagerCantAddNew"));
      list.AddNew();
      this.ChangeRecordState(this.List.Count - 1, this.Position != this.List.Count - 1, this.Position != this.List.Count - 1, true, true);
    }

    /// <summary>Cancels the current edit operation.</summary>
    /// <filterpriority>1</filterpriority>
    public override void CancelCurrentEdit()
    {
      if (this.Count <= 0)
        return;
      if ((this.Position < 0 || this.Position >= this.List.Count ? (object) null : this.List[this.Position]) is IEditableObject editableObject)
        editableObject.CancelEdit();
      if (!CommonUtils.IsMono && this.List is ICancelAddNew list)
        list.CancelNew(this.Position);
      this.OnItemChanged(new ItemChangedEventArgs(this.Position));
      if (this.Position == -1)
        return;
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.Position));
    }

    private void ChangeRecordState(
      int intNewPosition,
      bool blnValidating,
      bool blnEndCurrentEdit,
      bool blnFirePositionChange,
      bool blnPullData)
    {
      if (intNewPosition == -1 && this.List.Count == 0)
      {
        if (this.listposition == -1)
          return;
        this.listposition = -1;
        this.OnPositionChanged(EventArgs.Empty);
      }
      else
      {
        if ((intNewPosition < 0 || intNewPosition >= this.Count) && this.IsBinding)
          throw new IndexOutOfRangeException(SR.GetString("ListManagerBadPosition"));
        int listposition = this.listposition;
        if (blnEndCurrentEdit)
        {
          this.mblnInChangeRecordState = true;
          try
          {
            this.EndCurrentEdit();
          }
          finally
          {
            this.mblnInChangeRecordState = false;
          }
        }
        if (blnValidating & blnPullData)
          this.CurrencyManager_PullData();
        this.listposition = Math.Min(intNewPosition, this.Count - 1);
        if (blnValidating)
          this.OnCurrentChanged(EventArgs.Empty);
        if (!(listposition != this.listposition & blnFirePositionChange))
          return;
        this.OnPositionChanged(EventArgs.Empty);
      }
    }

    /// <summary>Throws an exception if there is no list, or the list is empty.</summary>
    /// <exception cref="T:System.Exception">There is no list, or the list is empty. </exception>
    protected void CheckEmpty()
    {
      if (this.mobjDataSource == null || this.List == null || this.List.Count == 0)
        throw new InvalidOperationException(SR.GetString("ListManagerEmptyList"));
    }

    private bool CurrencyManager_PullData()
    {
      bool blnSuccess = true;
      this.mblnPullingData = true;
      try
      {
        this.PullData(out blnSuccess);
      }
      finally
      {
        this.mblnPullingData = false;
      }
      return blnSuccess;
    }

    private bool CurrencyManager_PushData()
    {
      if (this.mblnPullingData)
        return false;
      int listposition = this.listposition;
      if (this.mintLastGoodKnownRow == -1)
      {
        try
        {
          this.PushData();
        }
        catch (Exception ex)
        {
          this.OnDataError(ex);
          this.FindGoodRow();
        }
        this.mintLastGoodKnownRow = this.listposition;
      }
      else
      {
        try
        {
          this.PushData();
        }
        catch (Exception ex)
        {
          this.OnDataError(ex);
          this.listposition = this.mintLastGoodKnownRow;
          this.PushData();
        }
        this.mintLastGoodKnownRow = this.listposition;
      }
      return listposition != this.listposition;
    }

    /// <summary>Ends the current edit operation.</summary>
    /// <filterpriority>1</filterpriority>
    public override void EndCurrentEdit()
    {
      if (this.Count <= 0 || !this.CurrencyManager_PullData())
        return;
      if ((this.Position < 0 || this.Position >= this.List.Count ? (object) null : this.List[this.Position]) is IEditableObject editableObject)
        editableObject.EndEdit();
      if (CommonUtils.IsMono || !(this.List is ICancelAddNew list))
        return;
      list.EndNew(this.Position);
    }

    internal int Find(PropertyDescriptor objPropertyDescriptor, object objKey, bool blnKeepIndex)
    {
      if (objKey == null)
        throw new ArgumentNullException("key");
      if (objPropertyDescriptor != null && this.List is IBindingList && ((IBindingList) this.List).SupportsSearching)
        return ((IBindingList) this.List).Find(objPropertyDescriptor, objKey);
      for (int index = 0; index < this.List.Count; ++index)
      {
        object obj = objPropertyDescriptor.GetValue(this.List[index]);
        if (objKey.Equals(obj))
          return index;
      }
      return -1;
    }

    private void FindGoodRow()
    {
      int count = this.List.Count;
      for (int index = 0; index < count; ++index)
      {
        this.listposition = index;
        try
        {
          this.PushData();
        }
        catch (Exception ex)
        {
          this.OnDataError(ex);
          continue;
        }
        this.listposition = index;
        return;
      }
      this.SuspendBinding();
      throw new InvalidOperationException(SR.GetString("DataBindingPushDataException"));
    }

    /// <summary>Gets the property descriptor collection for the underlying list.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> for the list.</returns>
    /// <filterpriority>1</filterpriority>
    public override PropertyDescriptorCollection GetItemProperties() => this.GetItemProperties((PropertyDescriptor[]) null);

    internal override PropertyDescriptorCollection GetItemProperties(
      PropertyDescriptor[] arrListAccessors)
    {
      return ListBindingHelper.GetListItemProperties((object) this.List, arrListAccessors);
    }

    internal override string GetListName() => this.List is ITypedList ? ((ITypedList) this.List).GetListName((PropertyDescriptor[]) null) : this.finalType.Name;

    /// <summary>Gets the name of the list supplying the data for the binding using the specified set of bound properties.</summary>
    /// <returns>If successful, a <see cref="T:System.String"></see> containing name of the list supplying the data for the binding; otherwise, an <see cref="F:System.String.Empty"></see> string.</returns>
    /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> of properties to be found in the data source.</param>
    protected internal override string GetListName(ArrayList objListAccessors)
    {
      if (!(this.List is ITypedList))
        return "";
      PropertyDescriptor[] listAccessors = new PropertyDescriptor[objListAccessors.Count];
      objListAccessors.CopyTo((Array) listAccessors, 0);
      return ((ITypedList) this.List).GetListName(listAccessors);
    }

    internal ListSortDirection GetSortDirection() => this.List is IBindingList && ((IBindingList) this.List).SupportsSorting ? ((IBindingList) this.List).SortDirection : ListSortDirection.Ascending;

    internal PropertyDescriptor GetSortProperty() => this.List is IBindingList && ((IBindingList) this.List).SupportsSorting ? ((IBindingList) this.List).SortProperty : (PropertyDescriptor) null;

    private void List_ListChanged(object sender, ListChangedEventArgs e)
    {
      ListChangedEventArgs e1 = e.ListChangedType != ListChangedType.ItemMoved || e.OldIndex >= 0 ? (e.ListChangedType != ListChangedType.ItemMoved || e.NewIndex >= 0 ? e : new ListChangedEventArgs(ListChangedType.ItemDeleted, e.OldIndex, e.NewIndex)) : new ListChangedEventArgs(ListChangedType.ItemAdded, e.NewIndex, e.OldIndex);
      int listposition = this.listposition;
      this.UpdateLastGoodKnownRow(e1);
      this.UpdateIsBinding();
      if (this.List.Count == 0)
      {
        this.listposition = -1;
        if (listposition != -1)
        {
          this.OnPositionChanged(EventArgs.Empty);
          this.OnCurrentChanged(EventArgs.Empty);
        }
        if (e1.ListChangedType == ListChangedType.Reset && e.NewIndex == -1)
          this.OnItemChanged(this.mobjResetEvent);
        if (e1.ListChangedType == ListChangedType.ItemDeleted)
          this.OnItemChanged(this.mobjResetEvent);
        if (e.ListChangedType == ListChangedType.PropertyDescriptorAdded || e.ListChangedType == ListChangedType.PropertyDescriptorDeleted || e.ListChangedType == ListChangedType.PropertyDescriptorChanged)
          this.OnMetaDataChanged(EventArgs.Empty);
        this.OnListChanged(e1);
      }
      else
      {
        this.mblnSuspendPushDataInCurrentChanged = true;
        try
        {
          switch (e1.ListChangedType)
          {
            case ListChangedType.Reset:
              if (this.listposition == -1 && this.List.Count > 0)
                this.ChangeRecordState(0, true, false, true, false);
              else
                this.ChangeRecordState(Math.Min(this.listposition, this.List.Count - 1), true, false, true, false);
              this.UpdateIsBinding(false);
              this.OnItemChanged(this.mobjResetEvent);
              break;
            case ListChangedType.ItemAdded:
              if (e1.NewIndex <= this.listposition && this.listposition < this.List.Count - 1)
              {
                this.ChangeRecordState(this.listposition + 1, true, true, this.listposition != this.List.Count - 2, false);
                this.UpdateIsBinding();
                this.OnItemChanged(this.mobjResetEvent);
                if (this.listposition == this.List.Count - 1)
                {
                  this.OnPositionChanged(EventArgs.Empty);
                  break;
                }
                break;
              }
              if (e1.NewIndex == this.listposition && this.listposition == this.List.Count - 1 && this.listposition != -1)
                this.OnCurrentItemChanged(EventArgs.Empty);
              if (this.listposition == -1)
                this.ChangeRecordState(0, false, false, true, false);
              this.UpdateIsBinding();
              this.OnItemChanged(this.mobjResetEvent);
              break;
            case ListChangedType.ItemDeleted:
              if (e1.NewIndex == this.listposition)
              {
                this.ChangeRecordState(Math.Min(this.listposition, this.Count - 1), true, false, true, false);
                this.OnItemChanged(this.mobjResetEvent);
                break;
              }
              if (e1.NewIndex < this.listposition)
              {
                this.ChangeRecordState(this.listposition - 1, true, false, true, false);
                this.OnItemChanged(this.mobjResetEvent);
                break;
              }
              this.OnItemChanged(this.mobjResetEvent);
              break;
            case ListChangedType.ItemMoved:
              if (e1.OldIndex == this.listposition)
                this.ChangeRecordState(e1.NewIndex, true, this.Position > -1 && this.Position < this.List.Count, true, false);
              else if (e1.NewIndex == this.listposition)
                this.ChangeRecordState(e1.OldIndex, true, this.Position > -1 && this.Position < this.List.Count, true, false);
              this.OnItemChanged(this.mobjResetEvent);
              break;
            case ListChangedType.ItemChanged:
              if (e1.NewIndex == this.listposition)
                this.OnCurrentItemChanged(EventArgs.Empty);
              this.OnItemChanged(new ItemChangedEventArgs(e1.NewIndex));
              break;
            case ListChangedType.PropertyDescriptorAdded:
            case ListChangedType.PropertyDescriptorDeleted:
            case ListChangedType.PropertyDescriptorChanged:
              this.mintLastGoodKnownRow = -1;
              if (this.listposition == -1 && this.List.Count > 0)
                this.ChangeRecordState(0, true, false, true, false);
              else if (this.listposition > this.List.Count - 1)
                this.ChangeRecordState(this.List.Count - 1, true, false, true, false);
              this.OnMetaDataChanged(EventArgs.Empty);
              break;
          }
          this.OnListChanged(e1);
        }
        finally
        {
          this.mblnSuspendPushDataInCurrentChanged = false;
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentChanged"></see> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected internal override void OnCurrentChanged(EventArgs e)
    {
      if (this.mblnInChangeRecordState)
        return;
      int lastGoodKnownRow = this.mintLastGoodKnownRow;
      bool flag = false;
      if (!this.mblnSuspendPushDataInCurrentChanged)
        flag = this.CurrencyManager_PushData();
      if (this.Count > 0)
      {
        object obj = this.List[this.Position];
        if (obj is IEditableObject)
          ((IEditableObject) obj).BeginEdit();
      }
      try
      {
        if (flag && (!flag || lastGoodKnownRow == -1))
          return;
        this.FireCurrentChanged((object) this, e);
        this.FireCurrentItemChanged((object) this, e);
      }
      catch (Exception ex)
      {
        this.OnDataError(ex);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected internal override void OnCurrentItemChanged(EventArgs e) => this.FireCurrentItemChanged((object) this, e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.ItemChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.ItemChangedEventArgs"></see> that contains the event data. </param>
    protected virtual void OnItemChanged(ItemChangedEventArgs e)
    {
      bool flag = false;
      if ((e.Index == this.listposition || e.Index == -1 && this.Position < this.Count) && !this.mblnInChangeRecordState)
        flag = this.CurrencyManager_PushData();
      try
      {
        ItemChangedEventHandler itemChanged = this.ItemChanged;
        if (itemChanged != null)
          itemChanged((object) this, e);
      }
      catch (Exception ex)
      {
        this.OnDataError(ex);
      }
      if (!flag)
        return;
      this.OnPositionChanged(EventArgs.Empty);
    }

    private void OnListChanged(ListChangedEventArgs e)
    {
      ListChangedEventHandler listChanged = this.ListChanged;
      if (listChanged == null)
        return;
      listChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.MetaDataChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected internal void OnMetaDataChanged(EventArgs e)
    {
      EventHandler metaDataChanged = this.MetaDataChanged;
      if (metaDataChanged == null)
        return;
      metaDataChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.PositionChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnPositionChanged(EventArgs e)
    {
      try
      {
        this.FirePositionChanged((object) this, e);
      }
      catch (Exception ex)
      {
        this.OnDataError(ex);
      }
    }

    /// <summary>Forces a repopulation of the data-bound list.</summary>
    /// <filterpriority>1</filterpriority>
    public void Refresh()
    {
      if (this.List.Count > 0)
      {
        if (this.listposition >= this.List.Count)
        {
          this.mintLastGoodKnownRow = -1;
          this.listposition = 0;
        }
      }
      else
        this.listposition = -1;
      this.List_ListChanged((object) this.List, new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    internal void Release() => this.UnwireEvents(this.List);

    /// <summary>Removes the item at the specified index.</summary>
    /// <param name="index">The index of the item to remove from the list. </param>
    /// <exception cref="T:System.IndexOutOfRangeException">There is no row at the specified index. </exception>
    /// <filterpriority>1</filterpriority>
    public override void RemoveAt(int index) => this.List.RemoveAt(index);

    /// <summary>Resumes data binding.</summary>
    /// <filterpriority>1</filterpriority>
    public override void ResumeBinding()
    {
      this.mintLastGoodKnownRow = -1;
      try
      {
        if (this.mblnShouldBind)
          return;
        this.mblnShouldBind = true;
        this.listposition = this.List == null || this.List.Count == 0 ? -1 : 0;
        this.UpdateIsBinding();
      }
      catch
      {
        this.mblnShouldBind = false;
        this.UpdateIsBinding();
        throw;
      }
    }

    /// <summary>Sets the data source.</summary>
    /// <param name="objDataSource">The obj data source.</param>
    internal override void SetDataSource(object objDataSource)
    {
      if (this.mobjDataSource == objDataSource)
        return;
      this.Release();
      this.mobjDataSource = objDataSource;
      this.mobjList = (IList) null;
      this.finalType = (Type) null;
      this.SetDataSourceInternal(objDataSource, true);
    }

    /// <summary>Sets the data source internal.</summary>
    /// <param name="objDataSource">The obj data source.</param>
    /// <param name="blnUpdate">if set to <c>true</c> [BLN update].</param>
    private void SetDataSourceInternal(object objDataSource, bool blnUpdate)
    {
      object obj = objDataSource;
      if (obj is Array)
      {
        this.finalType = obj.GetType();
        obj = (object) (Array) obj;
      }
      if (obj is IListSource)
        obj = (object) ((IListSource) obj).GetList();
      if (obj is IList)
      {
        if (this.finalType == (Type) null)
          this.finalType = obj.GetType();
        this.mobjList = (IList) obj;
        this.WireEvents(this.mobjList);
        if (!blnUpdate)
          return;
        this.listposition = this.mobjList.Count <= 0 ? -1 : 0;
        this.OnItemChanged(this.mobjResetEvent);
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1, -1));
        this.UpdateIsBinding();
      }
      else
      {
        if (obj == null)
          throw new ArgumentNullException("dataSource");
        throw new ArgumentException(SR.GetString("ListManagerSetDataSource", (object) obj.GetType().FullName), "dataSource");
      }
    }

    internal void SetSort(PropertyDescriptor objPropertyDescriptor, ListSortDirection sortDirection)
    {
      if (!(this.List is IBindingList) || !((IBindingList) this.List).SupportsSorting)
        return;
      ((IBindingList) this.List).ApplySort(objPropertyDescriptor, sortDirection);
    }

    /// <summary>Suspends data binding to prevents changes from updating the bound data source.</summary>
    /// <filterpriority>1</filterpriority>
    public override void SuspendBinding()
    {
      this.mintLastGoodKnownRow = -1;
      if (!this.mblnShouldBind)
        return;
      this.mblnShouldBind = false;
      this.UpdateIsBinding();
    }

    internal void UnwireEvents(IList objList)
    {
      if (!(objList is IBindingList) || !((IBindingList) objList).SupportsChangeNotification)
        return;
      ((IBindingList) objList).ListChanged -= new ListChangedEventHandler(this.List_ListChanged);
    }

    /// <summary>Updates the status of the binding.</summary>
    protected override void UpdateIsBinding() => this.UpdateIsBinding(true);

    private void UpdateIsBinding(bool blnRaiseItemChangedEvent)
    {
      bool flag = this.List != null && this.List.Count > 0 && this.mblnShouldBind && this.listposition != -1;
      if (this.List == null || this.mblnBound == flag)
        return;
      this.mblnBound = flag;
      int intNewPosition = flag ? 0 : -1;
      this.ChangeRecordState(intNewPosition, this.mblnBound, this.Position != intNewPosition, true, false);
      int count = this.Bindings.Count;
      for (int index = 0; index < count; ++index)
        this.Bindings[index].UpdateIsBinding();
      if (!blnRaiseItemChangedEvent)
        return;
      this.OnItemChanged(this.mobjResetEvent);
    }

    private void UpdateLastGoodKnownRow(ListChangedEventArgs e)
    {
      switch (e.ListChangedType)
      {
        case ListChangedType.Reset:
          this.mintLastGoodKnownRow = -1;
          break;
        case ListChangedType.ItemAdded:
          if (e.NewIndex > this.mintLastGoodKnownRow || this.mintLastGoodKnownRow >= this.List.Count - 1)
            break;
          ++this.mintLastGoodKnownRow;
          break;
        case ListChangedType.ItemDeleted:
          if (e.NewIndex != this.mintLastGoodKnownRow)
            break;
          this.mintLastGoodKnownRow = -1;
          break;
        case ListChangedType.ItemMoved:
          if (e.OldIndex != this.mintLastGoodKnownRow)
            break;
          this.mintLastGoodKnownRow = e.NewIndex;
          break;
        case ListChangedType.ItemChanged:
          if (e.NewIndex != this.mintLastGoodKnownRow)
            break;
          this.mintLastGoodKnownRow = -1;
          break;
      }
    }

    internal void WireEvents(IList objList)
    {
      if (!(objList is IBindingList) || !((IBindingList) objList).SupportsChangeNotification)
        return;
      ((IBindingList) objList).ListChanged += new ListChangedEventHandler(this.List_ListChanged);
    }

    /// <summary>Gets a value indicating whether [allow add].</summary>
    /// <value><c>true</c> if [allow add]; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AllowAdd
    {
      get
      {
        if (this.List is IBindingList)
          return ((IBindingList) this.List).AllowNew;
        return this.List != null && !this.List.IsReadOnly && !this.List.IsFixedSize;
      }
    }

    /// <summary>Gets a value indicating whether [allow edit].</summary>
    /// <value><c>true</c> if [allow edit]; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AllowEdit
    {
      get
      {
        if (this.List is IBindingList)
          return ((IBindingList) this.List).AllowEdit;
        return this.List != null && !this.List.IsReadOnly;
      }
    }

    /// <summary>Gets a value indicating whether [allow remove].</summary>
    /// <value><c>true</c> if [allow remove]; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AllowRemove
    {
      get
      {
        if (this.List is IBindingList)
          return ((IBindingList) this.List).AllowRemove;
        return this.List != null && !this.List.IsReadOnly && !this.List.IsFixedSize;
      }
    }

    internal override Type BindType => ListBindingHelper.GetListItemType((object) this.List);

    /// <summary>Gets the number of items in the list.</summary>
    /// <returns>The number of items in the list.</returns>
    /// <filterpriority>1</filterpriority>
    public override int Count => this.List == null ? 0 : this.List.Count;

    /// <summary>Gets the current item in the list.</summary>
    /// <returns>A list item of type <see cref="T:System.Object"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Current => this[this.Position];

    internal override object DataSource => this.mobjDataSource;

    internal override bool IsBinding => this.mblnBound;

    /// <summary>
    /// Gets or sets the <see cref="T:System.Object" /> at the specified index.
    /// </summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public object this[int index]
    {
      get
      {
        if (index < 0 || index >= this.List.Count)
          throw new IndexOutOfRangeException(SR.GetString("ListManagerNoValue", (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        return this.List[index];
      }
      set
      {
        if (index < 0 || index >= this.List.Count)
          throw new IndexOutOfRangeException(SR.GetString("ListManagerNoValue", (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        this.List[index] = value;
      }
    }

    /// <summary>Gets the list for this <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see>.</summary>
    /// <returns>An <see cref="T:System.Collections.IList"></see> that contains the list.</returns>
    /// <filterpriority>1</filterpriority>
    public IList List
    {
      get
      {
        if (this.mobjList == null && this.mobjDataSource != null)
          this.SetDataSourceInternal(this.mobjDataSource, false);
        return this.mobjList;
      }
    }

    /// <summary>Gets or sets the position you are at within the list.</summary>
    /// <returns>A number between 0 and <see cref="P:Gizmox.WebGUI.Forms.CurrencyManager.Count"></see> minus 1.</returns>
    /// <filterpriority>1</filterpriority>
    public override int Position
    {
      get => this.listposition;
      set
      {
        if (this.listposition == -1)
          return;
        if (value < 0)
          value = 0;
        int count = this.List.Count;
        if (value >= count)
          value = count - 1;
        this.ChangeRecordState(value, this.listposition != value, true, true, false);
      }
    }

    /// <summary>Gets a value indicating whether [should bind].</summary>
    /// <value><c>true</c> if [should bind]; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldBind => this.mblnShouldBind;
  }
}
