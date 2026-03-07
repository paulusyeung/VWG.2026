// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingSource
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Encapsulates the data source for a form.</summary>
  [ToolboxItem(true)]
  [ComplexBindingProperties("DataSource", "DataMember")]
  [SRDescription("DescriptionBindingSource")]
  [DefaultProperty("DataSource")]
  [DefaultEvent("CurrentChanged")]
  [ToolboxBitmap(typeof (BindingSource), "BindingSource_45.bmp")]
  [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ToolboxItemCategory("Data")]
  [Serializable]
  public class BindingSource : 
    ComponentBase,
    ICloneable,
    IBindingListView,
    IBindingList,
    IList,
    ICollection,
    IEnumerable,
    ITypedList,
    ICancelAddNew,
    ISupportInitializeNotification,
    ISupportInitialize,
    ICurrencyManagerProvider
  {
    private static readonly SerializableEvent EVENT_ADDINGNEW = SerializableEvent.Register(nameof (EVENT_ADDINGNEW), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_BINDINGCOMPLETE = SerializableEvent.Register(nameof (EVENT_BINDINGCOMPLETE), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_CURRENTCHANGED = SerializableEvent.Register(nameof (EVENT_CURRENTCHANGED), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_CURRENTITEMCHANGED = SerializableEvent.Register(nameof (EVENT_CURRENTITEMCHANGED), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_DATAERROR = SerializableEvent.Register(nameof (EVENT_DATAERROR), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_DATAMEMBERCHANGED = SerializableEvent.Register(nameof (EVENT_DATAMEMBERCHANGED), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_DATASOURCECHANGED = SerializableEvent.Register(nameof (EVENT_DATASOURCECHANGED), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_INITIALIZED = SerializableEvent.Register(nameof (EVENT_INITIALIZED), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_LISTCHANGED = SerializableEvent.Register(nameof (EVENT_LISTCHANGED), typeof (Delegate), typeof (BindingSource));
    private static readonly SerializableEvent EVENT_POSITIONCHANGED = SerializableEvent.Register(nameof (EVENT_POSITIONCHANGED), typeof (Delegate), typeof (BindingSource));
    private bool mblnAllowNewIsSet;
    private bool mblnAllowNewSetValue;
    private bool mblnDisposedOrFinalized;
    private bool mblnEndingEdit;
    private bool mblnInitializing;
    private bool mblnInnerListChanging;
    private bool mblnIsBindingList;
    private bool mblnListExtractedFromEnumerable;
    private bool mblnListRaisesItemChangedEvents;
    private bool mblnNeedToSetList;
    private bool mblnParentsCurrentItemChanging;
    private bool mblnRaiseListChangedEvents;
    private bool mblnRecursionDetectionFlag;
    private int mintAddNewPos;
    private string mstrDataMember;
    private string mstrFilter;
    private string mstrSort;
    private object mobjCurrentItemHookedForItemChange;
    private object mobjDataSource;
    private object mobjLastCurrentItem;
    [NonSerialized]
    private IList mobjInnerList;
    private CurrencyManager mobjCurrencyManager;
    private ConstructorInfo mobjItemConstructor;
    [NonSerialized]
    private PropertyDescriptorCollection mobjItemShape;
    private bool mblnItemShape;
    private Type mobjItemType;
    private EventHandler mobjListItemPropertyChangedHandler;
    private Hashtable mobjRelatedBindingSources;
    /// <summary>
    /// Manual serialization interception for 'NewRow' when the data source is a System.Data.DataView.
    /// A 'NewRow' is a row that has not yet been committed to the underlying DataTable, but can have values in one
    /// or more fields. System.Data.DataView is an unserializable type which means 'NewRow' must be manually serialized
    /// and deserialized.
    /// </summary>
    private object[] marrSerializedDataViewNewRowValues;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class to the default property values.</summary>
    public BindingSource()
      : this((object) null, string.Empty)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class and adds the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to the specified container.</summary>
    /// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to add the current <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to.</param>
    public BindingSource(IContainer objContainer)
      : this()
    {
      objContainer?.Add((IComponent) this);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class with the specified data source and data member.</summary>
    /// <param name="objDataSource">The data source for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</param>
    /// <param name="strDataMember">The specific column or list name within the data source to bind to.</param>
    public BindingSource(object objDataSource, string strDataMember) => this.InitializeBindingSource(objDataSource, strDataMember);

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

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      if (this.mobjDataSource != null)
      {
        bool listChangedEvents = this.mblnRaiseListChangedEvents;
        this.mblnRaiseListChangedEvents = false;
        this.ResetList();
        this.mblnRaiseListChangedEvents = listChangedEvents;
      }
      if (this.marrSerializedDataViewNewRowValues == null)
        return;
      object[] viewNewRowValues = this.marrSerializedDataViewNewRowValues;
      this.marrSerializedDataViewNewRowValues = (object[]) null;
      this.UnwireDataSource();
      this.UnwireInnerList();
      if (this.List.GetType() == typeof (DataView))
        ((DataView) this.List).AddNew().Row.ItemArray = viewNewRowValues;
      this.WireInnerList();
      this.WireDataSource();
      this.marrSerializedDataViewNewRowValues = (object[]) null;
    }

    /// <summary>Initializes the binding source.</summary>
    /// <param name="objDataSource">The obj data source.</param>
    /// <param name="strDataMember">The STR data member.</param>
    private void InitializeBindingSource(object objDataSource, string strDataMember)
    {
      this.mstrDataMember = string.Empty;
      this.mblnRaiseListChangedEvents = true;
      this.mblnAllowNewSetValue = true;
      this.mintAddNewPos = -1;
      this.mobjDataSource = objDataSource;
      this.mstrDataMember = strDataMember;
      this.mobjInnerList = (IList) new ArrayList();
      this.mobjCurrencyManager = new CurrencyManager((object) this);
      this.WireCurrencyManager(this.mobjCurrencyManager);
      this.ResetList();
      this.mobjListItemPropertyChangedHandler = new EventHandler(this.ListItem_PropertyChanged);
      this.WireDataSource();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource" /> class.
    /// </summary>
    /// <param name="objSourceBindingSource">The source of the binding source.</param>
    public BindingSource(BindingSource objSourceBindingSource)
    {
      if (objSourceBindingSource == null)
        return;
      this.InitializeBindingSource(objSourceBindingSource.DataSource, objSourceBindingSource.DataMember);
    }

    private void CurrencyManager_BindingComplete(object sender, BindingCompleteEventArgs e) => this.OnBindingComplete(e);

    private void CurrencyManager_CurrentChanged(object sender, EventArgs e) => this.OnCurrentChanged(EventArgs.Empty);

    private void CurrencyManager_CurrentItemChanged(object sender, EventArgs e) => this.OnCurrentItemChanged(EventArgs.Empty);

    private void CurrencyManager_DataError(object sender, BindingManagerDataErrorEventArgs e) => this.OnDataError(e);

    private void CurrencyManager_PositionChanged(object sender, EventArgs e) => this.OnPositionChanged(e);

    private void DataSource_Initialized(object sender, EventArgs e)
    {
      if (this.DataSource is ISupportInitializeNotification dataSource)
        dataSource.Initialized -= new EventHandler(this.DataSource_Initialized);
      this.EndInitCore();
    }

    private void InnerList_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (this.mblnInnerListChanging)
        return;
      try
      {
        this.mblnInnerListChanging = true;
        this.OnListChanged(e);
      }
      finally
      {
        this.mblnInnerListChanging = false;
      }
    }

    private void ListItem_PropertyChanged(object sender, EventArgs e) => this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, sender != this.mobjCurrentItemHookedForItemChange ? this.IndexOf(sender) : this.Position));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.AddingNew"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    internal virtual void OnAddingNew(AddingNewEventArgs e)
    {
      AddingNewEventHandler handler = (AddingNewEventHandler) this.GetHandler(BindingSource.EVENT_ADDINGNEW);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.BindingComplete"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
    protected virtual void OnBindingComplete(BindingCompleteEventArgs e)
    {
      BindingCompleteEventHandler handler = (BindingCompleteEventHandler) this.GetHandler(BindingSource.EVENT_BINDINGCOMPLETE);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:CurrentChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCurrentChanged(EventArgs e)
    {
      this.UnhookItemChangedEventsForOldCurrent();
      this.HookItemChangedEventsForNewCurrent();
      EventHandler handler = (EventHandler) this.GetHandler(BindingSource.EVENT_CURRENTCHANGED);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.CurrentItemChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnCurrentItemChanged(EventArgs e)
    {
      EventHandler handler = (EventHandler) this.GetHandler(BindingSource.EVENT_CURRENTITEMCHANGED);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataError"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingManagerDataErrorEventArgs"></see> that contains the event data. </param>
    protected virtual void OnDataError(BindingManagerDataErrorEventArgs e)
    {
      if (!(this.GetHandler(BindingSource.EVENT_DATAERROR) is BindingManagerDataErrorEventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataMemberChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnDataMemberChanged(EventArgs e)
    {
      if (!(this.GetHandler(BindingSource.EVENT_DATAMEMBERCHANGED) is EventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataSourceChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnDataSourceChanged(EventArgs e)
    {
      if (!(this.GetHandler(BindingSource.EVENT_DATASOURCECHANGED) is EventHandler handler))
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnListChanged(ListChangedEventArgs e)
    {
      if (!this.mblnRaiseListChangedEvents || this.mblnInitializing)
        return;
      ListChangedEventHandler handler = (ListChangedEventHandler) this.GetHandler(BindingSource.EVENT_LISTCHANGED);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.PositionChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.ListChangedEventArgs"></see> that contains the event data.</param>
    protected virtual void OnPositionChanged(EventArgs e)
    {
      EventHandler handler = (EventHandler) this.GetHandler(BindingSource.EVENT_POSITIONCHANGED);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    private void OnSimpleListChanged(ListChangedType enmListChangedType, int intNewIndex)
    {
      if (this.mblnIsBindingList)
        return;
      this.OnListChanged(new ListChangedEventArgs(enmListChangedType, intNewIndex));
    }

    private void ParentCurrencyManager_CurrentItemChanged(object sender, EventArgs e)
    {
      if (this.mblnInitializing)
        return;
      if (this.mblnParentsCurrentItemChanging)
        return;
      try
      {
        this.mblnParentsCurrentItemChanging = true;
        this.mobjCurrencyManager.PullData(out bool _);
      }
      finally
      {
        this.mblnParentsCurrentItemChanging = false;
      }
      CurrencyManager currencyManager = (CurrencyManager) sender;
      if (!CommonUtils.IsNullOrEmpty(this.mstrDataMember))
      {
        object obj = (object) null;
        IList objList = (IList) null;
        if (currencyManager.Count > 0)
        {
          PropertyDescriptor itemProperty = currencyManager.GetItemProperties()[this.mstrDataMember];
          if (itemProperty != null)
          {
            obj = ListBindingHelper.GetList(itemProperty.GetValue(currencyManager.Current));
            objList = obj as IList;
          }
        }
        if (objList != null)
          this.SetList(objList, false, true);
        else if (obj != null)
          this.SetList(BindingSource.WrapObjectInBindingList(obj), false, false);
        else
          this.SetList(BindingSource.CreateBindingList(this.mobjItemType), false, false);
        int num = this.mobjLastCurrentItem == null || currencyManager.Count == 0 || this.mobjLastCurrentItem != currencyManager.Current ? 1 : (this.Position >= this.Count ? 1 : 0);
        this.mobjLastCurrentItem = currencyManager.Count > 0 ? currencyManager.Current : (object) null;
        if (num != 0)
          this.Position = this.Count > 0 ? 0 : -1;
      }
      this.OnCurrentItemChanged(EventArgs.Empty);
    }

    private void ParentCurrencyManager_MetaDataChanged(object sender, EventArgs e)
    {
      this.ClearInvalidDataMember();
      this.ResetList();
    }

    /// <summary>Ensures the item shape.</summary>
    private void EnsureItemShape()
    {
      if (!this.mblnItemShape || this.mobjItemShape != null)
        return;
      this.mobjItemShape = ListBindingHelper.GetListItemProperties((object) this.List);
    }

    /// <summary>Adds an existing item to the internal list.</summary>
    /// <returns>The zero-based index at which value was added to the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. </returns>
    /// <param name="objValue">An <see cref="T:System.Object"></see> to be added to the internal list.</param>
    /// <exception cref="T:System.InvalidOperationException">value differs in type from the existing items in the underlying list.</exception>
    public virtual int Add(object objValue)
    {
      if (this.mobjDataSource == null && this.List.Count == 0)
        this.SetList(BindingSource.CreateBindingList(objValue == null ? typeof (object) : objValue.GetType()), true, true);
      if (objValue != null && !this.mobjItemType.IsAssignableFrom(objValue.GetType()))
        throw new InvalidOperationException(SR.GetString("BindingSourceItemTypeMismatchOnAdd"));
      if (objValue == null && this.mobjItemType.IsValueType)
        throw new InvalidOperationException(SR.GetString("BindingSourceItemTypeIsValueType"));
      int intNewIndex = this.List.Add(objValue);
      this.OnSimpleListChanged(ListChangedType.ItemAdded, intNewIndex);
      return intNewIndex;
    }

    private object AddNewMono()
    {
      if (!this.AllowNewInternal(false))
        throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperAddToReadOnlyList"));
      if (!this.AllowNewInternal(true))
        throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedToSetAllowNew", this.mobjItemType == (Type) null ? (object) "(null)" : (object) this.mobjItemType.FullName));
      int mintAddNewPos = this.mintAddNewPos;
      this.EndEdit();
      if (mintAddNewPos != -1)
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, mintAddNewPos));
      int count = this.List.Count;
      object objValue = (object) null;
      if (objValue == null)
      {
        if (this.mblnIsBindingList)
        {
          object obj = (this.List as IBindingList).AddNew();
          this.Position = this.Count - 1;
          return obj;
        }
        objValue = !(this.mobjItemConstructor == (ConstructorInfo) null) ? this.mobjItemConstructor.Invoke((object[]) null) : throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedAParameterlessConstructor", this.mobjItemType == (Type) null ? (object) "(null)" : (object) this.mobjItemType.FullName));
      }
      if (this.List.Count > count)
      {
        this.mintAddNewPos = this.Position;
        return objValue;
      }
      this.mintAddNewPos = this.Add(objValue);
      this.Position = this.mintAddNewPos;
      return objValue;
    }

    private object AddNewNonMono()
    {
      if (!this.AllowNewInternal(false))
        throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperAddToReadOnlyList"));
      if (!this.AllowNewInternal(true))
        throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedToSetAllowNew", this.mobjItemType == (Type) null ? (object) "(null)" : (object) this.mobjItemType.FullName));
      int mintAddNewPos = this.mintAddNewPos;
      this.EndEdit();
      if (mintAddNewPos != -1)
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, mintAddNewPos));
      AddingNewEventArgs e = new AddingNewEventArgs();
      int count = this.List.Count;
      this.OnAddingNew(e);
      object objValue = e.NewObject;
      if (objValue == null)
      {
        if (this.mblnIsBindingList)
        {
          object obj = (this.List as IBindingList).AddNew();
          this.Position = this.Count - 1;
          return obj;
        }
        objValue = !(this.mobjItemConstructor == (ConstructorInfo) null) ? this.mobjItemConstructor.Invoke((object[]) null) : throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedAParameterlessConstructor", this.mobjItemType == (Type) null ? (object) "(null)" : (object) this.mobjItemType.FullName));
      }
      if (this.List.Count > count)
      {
        this.mintAddNewPos = this.Position;
        return objValue;
      }
      this.mintAddNewPos = this.Add(objValue);
      this.Position = this.mintAddNewPos;
      return objValue;
    }

    /// <summary>Adds a new item to the underlying list.</summary>
    /// <returns>The <see cref="T:System.Object"></see> that was created and added to the list.</returns>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowNew"></see> property is set to false. -or-A public default constructor could not be found for the current item type.</exception>
    public virtual object AddNew()
    {
      if (this.DesignMode)
        return (object) null;
      return CommonUtils.IsMono ? this.AddNewMono() : this.AddNewNonMono();
    }

    private bool AllowNewInternal(bool blnCheckConstructor)
    {
      if (this.mblnDisposedOrFinalized)
        return false;
      if (this.mblnAllowNewIsSet)
        return this.mblnAllowNewSetValue;
      if (this.mblnListExtractedFromEnumerable)
        return false;
      return this.mblnIsBindingList ? ((IBindingList) this.List).AllowNew : this.IsListWriteable(blnCheckConstructor);
    }

    /// <summary>Sorts the data source with the specified sort descriptions.</summary>
    /// <param name="objSortsCollection">A <see cref="T:System.ComponentModel.ListSortDescriptionCollection"></see> containing the sort descriptions to apply to the data source.</param>
    /// <exception cref="T:System.NotSupportedException">The data source is not an <see cref="T:System.ComponentModel.IBindingListView"></see>.</exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ApplySort(ListSortDescriptionCollection objSortsCollection)
    {
      if (!(this.List is IBindingListView list))
        throw new NotSupportedException(SR.GetString("OperationRequiresIBindingListView"));
      list.ApplySort(objSortsCollection);
    }

    /// <summary>Sorts the data source using the specified property descriptor and sort direction.</summary>
    /// <param name="enmSortDirection">A <see cref="T:System.ComponentModel.ListSortDirection"></see> indicating how the list should be sorted.</param>
    /// <param name="objPropertyDescriptor">A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that describes the property by which to sort the data source.</param>
    /// <exception cref="T:System.NotSupportedException">The data source is not an <see cref="T:System.ComponentModel.IBindingList"></see>.</exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ApplySort(
      PropertyDescriptor objPropertyDescriptor,
      ListSortDirection enmSortDirection)
    {
      if (!this.mblnIsBindingList)
        throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
      ((IBindingList) this.List).ApplySort(objPropertyDescriptor, enmSortDirection);
    }

    private static string BuildSortString(ListSortDescriptionCollection objSortsColln)
    {
      if (objSortsColln == null)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder(objSortsColln.Count);
      for (int index = 0; index < objSortsColln.Count; ++index)
        stringBuilder.Append(objSortsColln[index].PropertyDescriptor.Name + (objSortsColln[index].SortDirection == ListSortDirection.Ascending ? " ASC" : " DESC") + (index < objSortsColln.Count - 1 ? "," : string.Empty));
      return stringBuilder.ToString();
    }

    /// <summary>Cancels the current edit operation.</summary>
    public void CancelEdit() => this.mobjCurrencyManager.CancelCurrentEdit();

    /// <summary>Removes all elements from the list.</summary>
    public virtual void Clear()
    {
      this.UnhookItemChangedEventsForOldCurrent();
      this.List.Clear();
      this.OnSimpleListChanged(ListChangedType.Reset, -1);
    }

    private void ClearInvalidDataMember()
    {
      if (this.IsDataMemberValid())
        return;
      this.mstrDataMember = "";
      this.OnDataMemberChanged(EventArgs.Empty);
    }

    /// <summary>Determines whether an object is an item in the list.</summary>
    /// <returns>true if the value parameter is found in the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>; otherwise, false.</returns>
    /// <param name="objValue">The <see cref="T:System.Object"></see> to locate in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. The value can be null. </param>
    public virtual bool Contains(object objValue) => this.List.Contains(objValue);

    /// <summary>Copies the contents of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> to the specified array, starting at the specified index value.</summary>
    /// <param name="objArray">The destination array.</param>
    /// <param name="intIndex">The index in the destination array at which to start the copy operation.</param>
    public virtual void CopyTo(Array objArray, int intIndex) => this.List.CopyTo(objArray, intIndex);

    private static IList CreateBindingList(Type objType) => (IList) SecurityUtils.SecureCreateInstance(typeof (BindingList<>).MakeGenericType(objType));

    private static object CreateInstanceOfType(Type objType)
    {
      object instanceOfType = (object) null;
      Exception innerException = (Exception) null;
      try
      {
        instanceOfType = SecurityUtils.SecureCreateInstance(objType);
      }
      catch (TargetInvocationException ex)
      {
        innerException = (Exception) ex;
      }
      catch (MethodAccessException ex)
      {
        innerException = (Exception) ex;
      }
      catch (MissingMethodException ex)
      {
        innerException = (Exception) ex;
      }
      if (innerException != null)
        throw new NotSupportedException(SR.GetString("BindingSourceInstanceError"), innerException);
      return instanceOfType;
    }

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> and optionally releases the managed resources. </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        this.UnwireDataSource();
        this.UnwireInnerList();
        this.UnhookItemChangedEventsForOldCurrent();
        this.UnwireCurrencyManager(this.mobjCurrencyManager);
        this.mobjDataSource = (object) null;
        this.mstrDataMember = (string) null;
        this.mobjInnerList = (IList) null;
        this.mblnIsBindingList = false;
        this.mblnNeedToSetList = true;
        this.mblnRaiseListChangedEvents = false;
      }
      this.mblnDisposedOrFinalized = true;
      base.Dispose(blnDisposing);
    }

    /// <summary>Applies pending changes to the underlying data source.</summary>
    public void EndEdit()
    {
      if (this.mblnEndingEdit)
        return;
      try
      {
        this.mblnEndingEdit = true;
        this.mobjCurrencyManager.EndCurrentEdit();
      }
      finally
      {
        this.mblnEndingEdit = false;
      }
    }

    private void EndInitCore()
    {
      this.mblnInitializing = false;
      this.EnsureInnerList();
      this.OnInitialized();
      if (this.mobjRelatedBindingSources == null)
        return;
      foreach (ISupportInitialize supportInitialize in (IEnumerable) this.mobjRelatedBindingSources.Values)
        supportInitialize.EndInit();
    }

    private void EnsureInnerList()
    {
      if (this.mblnInitializing || !this.mblnNeedToSetList)
        return;
      this.mblnNeedToSetList = false;
      this.ResetList();
    }

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public object Clone() => (object) new BindingSource(this);

    /// <summary>Searches for the index of the item that has the given property descriptor.</summary>
    /// <returns>The zero-based index of the item that has the given value for <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.</returns>
    /// <param name="objPropertyDescriptor">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to search for. </param>
    /// <param name="objKey">The value of prop to match. </param>
    /// <exception cref="T:System.NotSupportedException">The underlying list is not of type <see cref="T:System.ComponentModel.IBindingList"></see>.</exception>
    public virtual int Find(PropertyDescriptor objPropertyDescriptor, object objKey)
    {
      if (!this.mblnIsBindingList)
        throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
      return ((IBindingList) this.List).Find(objPropertyDescriptor, objKey);
    }

    /// <summary>Returns the index of the item in the list with the specified property name and value.</summary>
    /// <returns>The zero-based index of the item with the specified property name and value.</returns>
    /// <param name="objKey">The value of the item with the specified propertyName to find.</param>
    /// <param name="strPropertyName">The name of the property to search for.</param>
    /// <exception cref="T:System.ArgumentException">propertyName does not match a property in the list.</exception>
    /// <exception cref="T:System.InvalidOperationException">The underlying list is not a <see cref="T:System.ComponentModel.IBindingList"></see> with searching functionality implemented.</exception>
    public int Find(string strPropertyName, object objKey)
    {
      this.EnsureItemShape();
      return this.Find((this.mobjItemShape == null ? (PropertyDescriptor) null : this.mobjItemShape.Find(strPropertyName, true)) ?? throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", (object) strPropertyName)), objKey);
    }

    /// <summary>Retrieves an enumerator for the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>. </returns>
    public virtual IEnumerator GetEnumerator() => this.List.GetEnumerator();

    /// <summary>Retrieves an array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects representing the bindable properties of the data source list type.</summary>
    /// <returns>An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects that represents the properties on this list type used to bind data.</returns>
    /// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the list as bindable.</param>
    public virtual PropertyDescriptorCollection GetItemProperties(
      PropertyDescriptor[] arrListAccessors)
    {
      object list = ListBindingHelper.GetList(this.mobjDataSource);
      if (list is ITypedList)
      {
        if (!CommonUtils.IsNullOrEmpty(this.mstrDataMember))
          return ListBindingHelper.GetListItemProperties(list, this.mstrDataMember, arrListAccessors);
      }
      return ListBindingHelper.GetListItemProperties((object) this.List, arrListAccessors);
    }

    private static IList GetListFromEnumerable(IEnumerable objEnumerable)
    {
      IList listFromEnumerable = (IList) null;
      foreach (object obj in objEnumerable)
      {
        if (listFromEnumerable == null)
          listFromEnumerable = BindingSource.CreateBindingList(obj.GetType());
        listFromEnumerable.Add(obj);
      }
      return listFromEnumerable;
    }

    private static IList GetListFromType(Type objType)
    {
      if (typeof (ITypedList).IsAssignableFrom(objType) && typeof (IList).IsAssignableFrom(objType))
        return BindingSource.CreateInstanceOfType(objType) as IList;
      return typeof (IListSource).IsAssignableFrom(objType) ? (BindingSource.CreateInstanceOfType(objType) as IListSource).GetList() : BindingSource.CreateBindingList(ListBindingHelper.GetListItemType((object) objType));
    }

    /// <summary>Gets the name of the list supplying data for the binding.</summary>
    /// <returns>The name of the list supplying the data for binding.</returns>
    /// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the list as bindable.</param>
    public virtual string GetListName(PropertyDescriptor[] arrListAccessors) => ListBindingHelper.GetListName((object) this.List, arrListAccessors);

    private BindingSource GetRelatedBindingSource(string strDataMember)
    {
      if (this.mobjRelatedBindingSources == null)
        this.mobjRelatedBindingSources = new Hashtable();
      foreach (string key in (IEnumerable) this.mobjRelatedBindingSources.Keys)
      {
        if (ClientUtils.IsEquals(key, strDataMember, StringComparison.OrdinalIgnoreCase))
          return this.mobjRelatedBindingSources[(object) key] as BindingSource;
      }
      BindingSource relatedBindingSource = new BindingSource((object) this, strDataMember);
      this.mobjRelatedBindingSources[(object) strDataMember] = (object) relatedBindingSource;
      return relatedBindingSource;
    }

    /// <summary>Gets the related currency manager for the specified data member.</summary>
    /// <returns>The related <see cref="T:CurrencyManager"></see> for the specified data member.</returns>
    /// <param name="strDataMember">The name of column or list, within the data source to retrieve the currency manager for.</param>
    public virtual CurrencyManager GetRelatedCurrencyManager(string strDataMember)
    {
      this.EnsureInnerList();
      if (CommonUtils.IsNullOrEmpty(strDataMember))
        return this.mobjCurrencyManager;
      return strDataMember.IndexOf(".") != -1 ? (CurrencyManager) null : this.GetRelatedBindingSource(strDataMember).CurrencyManager;
    }

    private void HookItemChangedEventsForNewCurrent()
    {
      if (this.mblnListRaisesItemChangedEvents)
        return;
      if (this.Position >= 0 && this.Position <= this.Count - 1)
      {
        this.mobjCurrentItemHookedForItemChange = this.Current;
        this.WirePropertyChangedEvents(this.mobjCurrentItemHookedForItemChange);
      }
      else
        this.mobjCurrentItemHookedForItemChange = (object) null;
    }

    /// <summary>Searches for the specified object and returns the index of the first occurrence within the entire list.</summary>
    /// <returns>The zero-based index of the first occurrence of the value parameter; otherwise, -1 if value is not in the list.</returns>
    /// <param name="objValue">The <see cref="T:System.Object"></see> to locate in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. The value can be null. </param>
    public virtual int IndexOf(object objValue) => this.List.IndexOf(objValue);

    /// <summary>Inserts an item into the list at the specified index.</summary>
    /// <param name="objValue">The <see cref="T:System.Object"></see> to insert. The value can be null. </param>
    /// <param name="intIndex">The zero-based index at which value should be inserted. </param>
    /// <exception cref="T:System.NotSupportedException">The list is read-only or has a fixed size.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
    public virtual void Insert(int intIndex, object objValue)
    {
      this.List.Insert(intIndex, objValue);
      this.OnSimpleListChanged(ListChangedType.ItemAdded, intIndex);
    }

    private bool IsDataMemberValid()
    {
      if (this.mblnInitializing)
        return true;
      return CommonUtils.IsNullOrEmpty(this.mstrDataMember) || ListBindingHelper.GetListItemProperties(this.mobjDataSource)[this.mstrDataMember] != null;
    }

    private bool IsListWriteable(bool blnCheckConstructor)
    {
      if (this.List.IsReadOnly || this.List.IsFixedSize)
        return false;
      return !blnCheckConstructor || this.mobjItemConstructor != (ConstructorInfo) null;
    }

    /// <summary>Moves to the first item in the list.</summary>
    public void MoveFirst() => this.Position = 0;

    /// <summary>Moves to the last item in the list.</summary>
    public void MoveLast() => this.Position = this.Count - 1;

    /// <summary>Moves to the next item in the list.</summary>
    public void MoveNext() => ++this.Position;

    /// <summary>Moves to the previous item in the list.</summary>
    public void MovePrevious() => --this.Position;

    private void OnInitialized()
    {
      EventHandler handler = (EventHandler) this.GetHandler(BindingSource.EVENT_INITIALIZED);
      if (handler == null)
        return;
      handler((object) this, EventArgs.Empty);
    }

    private ListSortDescriptionCollection ParseSortString(string strSortString)
    {
      if (CommonUtils.IsNullOrEmpty(strSortString))
        return new ListSortDescriptionCollection();
      ArrayList arrayList = new ArrayList();
      PropertyDescriptorCollection itemProperties = this.mobjCurrencyManager.GetItemProperties();
      string str1 = strSortString;
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        string str3 = str2.Trim();
        int length = str3.Length;
        bool flag = true;
        if (length >= 5 && string.Compare(str3, length - 4, " ASC", 0, 4, true, CultureInfo.InvariantCulture) == 0)
          str3 = str3.Substring(0, length - 4).Trim();
        else if (length >= 6 && string.Compare(str3, length - 5, " DESC", 0, 5, true, CultureInfo.InvariantCulture) == 0)
        {
          flag = false;
          str3 = str3.Substring(0, length - 5).Trim();
        }
        if (str3.StartsWith("["))
          str3 = str3.EndsWith("]") ? str3.Substring(1, str3.Length - 2) : throw new ArgumentException(SR.GetString("BindingSourceBadSortString"));
        arrayList.Add((object) new ListSortDescription(itemProperties.Find(str3, true) ?? throw new ArgumentException(SR.GetString("BindingSourceSortStringPropertyNotInIBindingList")), flag ? ListSortDirection.Ascending : ListSortDirection.Descending));
      }
      ListSortDescription[] sorts = new ListSortDescription[arrayList.Count];
      arrayList.CopyTo((Array) sorts);
      return new ListSortDescriptionCollection(sorts);
    }

    /// <summary>Removes the specified item from the list.</summary>
    /// <param name="objValue">The item to remove from the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property.</param>
    /// <exception cref="T:System.NotSupportedException">The underlying list has a fixed size or is read-only. </exception>
    public virtual void Remove(object objValue)
    {
      int intNewIndex = this.IndexOf(objValue);
      this.List.Remove(objValue);
      if (intNewIndex == -1)
        return;
      this.OnSimpleListChanged(ListChangedType.ItemDeleted, intNewIndex);
    }

    /// <summary>Removes the item at the specified index in the list.</summary>
    /// <param name="intIndex">The zero-based index of the item to remove. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see> property.</exception>
    /// <exception cref="T:System.NotSupportedException">The underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property is read-only or has a fixed size.</exception>
    public virtual void RemoveAt(int intIndex)
    {
      object obj = this[intIndex];
      this.List.RemoveAt(intIndex);
      this.OnSimpleListChanged(ListChangedType.ItemDeleted, intIndex);
    }

    /// <summary>Removes the current item from the list.</summary>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowRemove"></see> property is false.-or-<see cref="P:Gizmox.WebGUI.Forms.BindingSource.Position"></see> is less than zero or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
    /// <exception cref="T:System.NotSupportedException">The underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property is read-only or has a fixed size.</exception>
    public void RemoveCurrent()
    {
      if (!this.AllowRemove)
        throw new InvalidOperationException(SR.GetString("BindingSourceRemoveCurrentNotAllowed"));
      if (this.Position < 0 || this.Position >= this.Count)
        throw new InvalidOperationException(SR.GetString("BindingSourceRemoveCurrentNoCurrentItem"));
      this.RemoveAt(this.Position);
    }

    /// <summary>Removes the filter associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    /// <exception cref="T:System.NotSupportedException">The underlying list does not support filtering.</exception>
    public virtual void RemoveFilter()
    {
      this.mstrFilter = (string) null;
      if (!(this.List is IBindingListView list))
        return;
      list.RemoveFilter();
    }

    /// <summary>Removes the sort associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    /// <exception cref="T:System.NotSupportedException">The underlying list does not support sorting.</exception>
    public virtual void RemoveSort()
    {
      this.mstrSort = (string) null;
      if (!this.mblnIsBindingList)
        return;
      ((IBindingList) this.List).RemoveSort();
    }

    /// <summary>Reinitializes the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowNew"></see> property.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual void ResetAllowNew()
    {
      this.mblnAllowNewIsSet = false;
      this.mblnAllowNewSetValue = true;
    }

    /// <summary>Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread all the items in the list and refresh their displayed values. </summary>
    /// <param name="blnMetadataChanged">true if the data schema has changed; false if only values have changed.</param>
    public void ResetBindings(bool blnMetadataChanged)
    {
      if (blnMetadataChanged)
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.PropertyDescriptorChanged, (PropertyDescriptor) null));
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    /// <summary>Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread the currently selected item and refresh its displayed value.</summary>
    public void ResetCurrentItem() => this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.Position));

    /// <summary>Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread the item at the specified index, and refresh its displayed value. </summary>
    /// <param name="intItemIndex">The zero-based index of the item that has changed.</param>
    public void ResetItem(int intItemIndex) => this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, intItemIndex));

    private void ResetList()
    {
      if (this.mblnInitializing)
      {
        this.mblnNeedToSetList = true;
      }
      else
      {
        this.mblnNeedToSetList = false;
        object obj = ListBindingHelper.GetList((object) (this.mobjDataSource as Type) != null ? (object) BindingSource.GetListFromType(this.mobjDataSource as Type) : this.mobjDataSource, this.mstrDataMember);
        this.mblnListExtractedFromEnumerable = false;
        switch (obj)
        {
          case IList _:
label_6:
            this.SetList(obj as IList, true, true);
            break;
          case IEnumerable _:
            obj = (object) BindingSource.GetListFromEnumerable(obj as IEnumerable);
            this.mblnListExtractedFromEnumerable = true;
            goto label_6;
          case null:
            obj = (object) BindingSource.CreateBindingList(ListBindingHelper.GetListItemType(this.mobjDataSource, this.mstrDataMember));
            goto label_6;
          default:
            obj = (object) BindingSource.WrapObjectInBindingList(obj);
            goto label_6;
        }
      }
    }

    /// <summary>Resumes data binding.</summary>
    public void ResumeBinding() => this.mobjCurrencyManager.ResumeBinding();

    private void SetList(IList objList, bool blnMetaDataChanged, bool blnApplySortAndFilter)
    {
      if (objList == null)
        objList = BindingSource.CreateBindingList(this.mobjItemType);
      this.UnwireInnerList();
      this.UnhookItemChangedEventsForOldCurrent();
      this.mobjInnerList = objList;
      this.mblnIsBindingList = objList is IBindingList;
      this.mblnListRaisesItemChangedEvents = !(objList is IRaiseItemChangedEvents) ? !(objList is DataView) && this.mblnIsBindingList : (objList as IRaiseItemChangedEvents).RaisesItemChangedEvents;
      if (blnMetaDataChanged)
      {
        this.mobjItemType = ListBindingHelper.GetListItemType((object) this.List);
        this.mobjItemShape = ListBindingHelper.GetListItemProperties((object) this.List);
        this.mblnItemShape = this.mobjItemShape != null;
        this.mobjItemConstructor = this.mobjItemType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, (Binder) null, new Type[0], (ParameterModifier[]) null);
      }
      this.WireInnerList();
      this.HookItemChangedEventsForNewCurrent();
      this.ResetBindings(blnMetaDataChanged);
      if (!blnApplySortAndFilter)
        return;
      if (this.Sort != null)
        this.InnerListSort = this.Sort;
      if (this.Filter == null)
        return;
      this.InnerListFilter = this.Filter;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeAllowNew() => this.mblnAllowNewIsSet;

    /// <summary>Suspends data binding to prevent changes from updating the bound data source.</summary>
    public void SuspendBinding() => this.mobjCurrencyManager.SuspendBinding();

    void IBindingList.AddIndex(PropertyDescriptor objPropertyDescriptor)
    {
      if (!this.mblnIsBindingList)
        throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
      ((IBindingList) this.List).AddIndex(objPropertyDescriptor);
    }

    void IBindingList.RemoveIndex(PropertyDescriptor objPropertyDescriptor)
    {
      if (!this.mblnIsBindingList)
        throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
      ((IBindingList) this.List).RemoveIndex(objPropertyDescriptor);
    }

    void ICancelAddNew.CancelNew(int intPosition)
    {
      if (this.mintAddNewPos >= 0 && this.mintAddNewPos == intPosition)
      {
        this.RemoveAt(this.mintAddNewPos);
        this.mintAddNewPos = -1;
      }
      else
      {
        if (!(this.List is ICancelAddNew list))
          return;
        list.CancelNew(intPosition);
      }
    }

    void ICancelAddNew.EndNew(int intPosition)
    {
      if (this.mintAddNewPos >= 0 && this.mintAddNewPos == intPosition)
      {
        this.mintAddNewPos = -1;
      }
      else
      {
        if (!(this.List is ICancelAddNew list))
          return;
        list.EndNew(intPosition);
      }
    }

    void ISupportInitialize.BeginInit() => this.mblnInitializing = true;

    void ISupportInitialize.EndInit()
    {
      if (this.DataSource is ISupportInitializeNotification dataSource && !dataSource.IsInitialized)
        dataSource.Initialized += new EventHandler(this.DataSource_Initialized);
      else
        this.EndInitCore();
    }

    private void ThrowIfBindingSourceRecursionDetected(object objNewDataSource)
    {
      for (BindingSource bindingSource = objNewDataSource as BindingSource; bindingSource != null; bindingSource = bindingSource.DataSource as BindingSource)
      {
        if (bindingSource == this)
          throw new InvalidOperationException(SR.GetString("BindingSourceRecursionDetected"));
      }
    }

    private void UnhookItemChangedEventsForOldCurrent()
    {
      if (this.mblnListRaisesItemChangedEvents)
        return;
      this.UnwirePropertyChangedEvents(this.mobjCurrentItemHookedForItemChange);
      this.mobjCurrentItemHookedForItemChange = (object) null;
    }

    private void UnwireCurrencyManager(CurrencyManager objCurrencyManager)
    {
      if (objCurrencyManager == null)
        return;
      objCurrencyManager.PositionChanged -= new EventHandler(this.CurrencyManager_PositionChanged);
      objCurrencyManager.CurrentChanged -= new EventHandler(this.CurrencyManager_CurrentChanged);
      objCurrencyManager.CurrentItemChanged -= new EventHandler(this.CurrencyManager_CurrentItemChanged);
      objCurrencyManager.BindingComplete -= new BindingCompleteEventHandler(this.CurrencyManager_BindingComplete);
      objCurrencyManager.DataError -= new BindingManagerDataErrorEventHandler(this.CurrencyManager_DataError);
    }

    private void UnwireDataSource()
    {
      if (!(this.mobjDataSource is ICurrencyManagerProvider))
        return;
      CurrencyManager currencyManager = (this.mobjDataSource as ICurrencyManagerProvider).CurrencyManager;
      currencyManager.CurrentItemChanged -= new EventHandler(this.ParentCurrencyManager_CurrentItemChanged);
      currencyManager.MetaDataChanged -= new EventHandler(this.ParentCurrencyManager_MetaDataChanged);
    }

    private void UnwireInnerList()
    {
      if (!(this.mobjInnerList is IBindingList))
        return;
      (this.mobjInnerList as IBindingList).ListChanged -= new ListChangedEventHandler(this.InnerList_ListChanged);
    }

    private void UnwirePropertyChangedEvents(object objItem)
    {
      this.EnsureItemShape();
      if (objItem == null || this.mobjItemShape == null)
        return;
      for (int index = 0; index < this.mobjItemShape.Count; ++index)
      {
        if (this.mobjListItemPropertyChangedHandler != null)
          this.mobjItemShape[index].RemoveValueChanged(objItem, this.mobjListItemPropertyChangedHandler);
      }
    }

    private void WireCurrencyManager(CurrencyManager objCurrencyManager)
    {
      if (objCurrencyManager == null)
        return;
      objCurrencyManager.PositionChanged += new EventHandler(this.CurrencyManager_PositionChanged);
      objCurrencyManager.CurrentChanged += new EventHandler(this.CurrencyManager_CurrentChanged);
      objCurrencyManager.CurrentItemChanged += new EventHandler(this.CurrencyManager_CurrentItemChanged);
      objCurrencyManager.BindingComplete += new BindingCompleteEventHandler(this.CurrencyManager_BindingComplete);
      objCurrencyManager.DataError += new BindingManagerDataErrorEventHandler(this.CurrencyManager_DataError);
    }

    private void WireDataSource()
    {
      if (!(this.mobjDataSource is ICurrencyManagerProvider))
        return;
      CurrencyManager currencyManager = (this.mobjDataSource as ICurrencyManagerProvider).CurrencyManager;
      currencyManager.CurrentItemChanged += new EventHandler(this.ParentCurrencyManager_CurrentItemChanged);
      currencyManager.MetaDataChanged += new EventHandler(this.ParentCurrencyManager_MetaDataChanged);
    }

    private void WireInnerList()
    {
      if (!(this.mobjInnerList is IBindingList))
        return;
      (this.mobjInnerList as IBindingList).ListChanged += new ListChangedEventHandler(this.InnerList_ListChanged);
    }

    private void WirePropertyChangedEvents(object objItem)
    {
      this.EnsureItemShape();
      if (objItem == null || this.mobjItemShape == null)
        return;
      for (int index = 0; index < this.mobjItemShape.Count; ++index)
      {
        if (this.mobjListItemPropertyChangedHandler != null)
          this.mobjItemShape[index].AddValueChanged(objItem, this.mobjListItemPropertyChangedHandler);
      }
    }

    private static IList WrapObjectInBindingList(object obj)
    {
      IList bindingList = BindingSource.CreateBindingList(obj.GetType());
      bindingList.Add(obj);
      return bindingList;
    }

    /// <summary>Gets a value indicating whether items in the underlying list can be edited.</summary>
    /// <returns>true to indicate list items can be edited; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool AllowEdit => this.mblnIsBindingList ? ((IBindingList) this.List).AllowEdit : !this.List.IsReadOnly;

    /// <summary>Gets or sets a value indicating whether the <see cref="M:Gizmox.WebGUI.Forms.BindingSource.AddNew"></see> method can be used to add items to the list.</summary>
    /// <returns>true if <see cref="M:Gizmox.WebGUI.Forms.BindingSource.AddNew"></see> can be used to add items to the list; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">This property is set to true when the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property has a fixed size or is read-only.</exception>
    /// <exception cref="T:System.MissingMethodException">The property is set to true and the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.AddingNew"></see> event is not handled when the underlying list type does not have a default constructor.</exception>
    [SRCategory("CatBehavior")]
    [SRDescription("BindingSourceAllowNewDescr")]
    public virtual bool AllowNew
    {
      get => this.AllowNewInternal(true);
      set
      {
        if (this.mblnAllowNewIsSet && value == this.mblnAllowNewSetValue)
          return;
        if (value && !this.mblnIsBindingList && !this.IsListWriteable(false))
          throw new InvalidOperationException(SR.GetString("NoAllowNewOnReadOnlyList"));
        this.mblnAllowNewIsSet = true;
        this.mblnAllowNewSetValue = value;
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
      }
    }

    /// <summary>Gets a value indicating whether items can be removed from the underlying list.</summary>
    /// <returns>true to indicate list items can be removed from the list; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool AllowRemove
    {
      get
      {
        if (this.mblnIsBindingList)
          return ((IBindingList) this.List).AllowRemove;
        return !this.List.IsReadOnly && !this.List.IsFixedSize;
      }
    }

    /// <summary>Gets the total number of items in the underlying list.</summary>
    /// <returns>The total number of items in the underlying list.</returns>
    [Browsable(false)]
    public virtual int Count
    {
      get
      {
        try
        {
          if (this.mblnDisposedOrFinalized)
            return 0;
          this.mblnRecursionDetectionFlag = !this.mblnRecursionDetectionFlag ? true : throw new InvalidOperationException(SR.GetString("BindingSourceRecursionDetected"));
          return this.List.Count;
        }
        finally
        {
          this.mblnRecursionDetectionFlag = false;
        }
      }
    }

    /// <summary>Gets the currency manager associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    /// <returns>The <see cref="T:CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [Browsable(false)]
    public virtual CurrencyManager CurrencyManager => this.GetRelatedCurrencyManager((string) null);

    /// <summary>Gets the current item in the list.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the current item in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property, or null if the list has no items.</returns>
    [Browsable(false)]
    public object Current => this.mobjCurrencyManager.Count <= 0 ? (object) null : this.mobjCurrencyManager.Current;

    /// <summary>Gets or sets the specific list in the data source to which the connector currently binds to.</summary>
    /// <returns>The name of a list (or row) in the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataSource"></see>. The default is an empty string ("").</returns>
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("BindingSourceDataMemberDescr")]
    [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [DefaultValue("")]
    [SRCategory("CatData")]
    public string DataMember
    {
      get => this.mstrDataMember;
      set
      {
        if (value == null)
          value = string.Empty;
        if (this.mstrDataMember.Equals(value))
          return;
        this.mstrDataMember = value;
        this.ResetList();
        this.OnDataMemberChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the data source that the connector binds to.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that acts as a data source. The default is null.</returns>
    [AttributeProvider(typeof (Binding.IDataSourceAttributeProvider))]
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(null)]
    [SRCategory("CatData")]
    [SRDescription("BindingSourceDataSourceDescr")]
    public object DataSource
    {
      get => this.mobjDataSource;
      set
      {
        if (this.mobjDataSource == value)
          return;
        this.ThrowIfBindingSourceRecursionDetected(value);
        this.UnwireDataSource();
        this.mobjDataSource = value;
        this.ClearInvalidDataMember();
        this.ResetList();
        this.WireDataSource();
        this.OnDataSourceChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the expression used to filter which rows are viewed.</summary>
    /// <returns>A string that specifies how rows are to be filtered. The default is null.</returns>
    [DefaultValue(null)]
    [SRDescription("BindingSourceFilterDescr")]
    [SRCategory("CatData")]
    public virtual string Filter
    {
      get => this.mstrFilter;
      set
      {
        this.mstrFilter = value;
        this.InnerListFilter = value;
      }
    }

    private string InnerListFilter
    {
      get => this.List is IBindingListView list && list.SupportsFiltering ? list.Filter : string.Empty;
      set
      {
        if (this.mblnInitializing || this.DesignMode || ClientUtils.IsEquals(value, this.InnerListFilter, StringComparison.Ordinal) || !(this.List is IBindingListView list) || !list.SupportsFiltering)
          return;
        list.Filter = value;
      }
    }

    private string InnerListSort
    {
      get
      {
        ListSortDescriptionCollection objSortsColln = (ListSortDescriptionCollection) null;
        IBindingListView list1 = this.List as IBindingListView;
        IBindingList list2 = this.List as IBindingList;
        if (list1 != null && list1.SupportsAdvancedSorting)
          objSortsColln = list1.SortDescriptions;
        else if (list2 != null && list2.SupportsSorting && list2.IsSorted)
          objSortsColln = new ListSortDescriptionCollection(new ListSortDescription[1]
          {
            new ListSortDescription(list2.SortProperty, list2.SortDirection)
          });
        return BindingSource.BuildSortString(objSortsColln);
      }
      set
      {
        if (this.mblnInitializing || this.DesignMode || string.Compare(value, this.InnerListSort, false, CultureInfo.InvariantCulture) == 0)
          return;
        ListSortDescriptionCollection sortString = this.ParseSortString(value);
        IBindingListView list1 = this.List as IBindingListView;
        IBindingList list2 = this.List as IBindingList;
        if (list1 != null && list1.SupportsAdvancedSorting)
        {
          if (sortString.Count == 0)
            list1.RemoveSort();
          else
            list1.ApplySort(sortString);
        }
        else
        {
          if (list2 == null || !list2.SupportsSorting)
            return;
          if (sortString.Count == 0)
          {
            list2.RemoveSort();
          }
          else
          {
            if (sortString.Count != 1)
              return;
            list2.ApplySort(sortString[0].PropertyDescriptor, sortString[0].SortDirection);
          }
        }
      }
    }

    /// <summary>Gets a value indicating whether the list binding is suspended.</summary>
    /// <returns>true to indicate the binding is suspended; otherwise, false. </returns>
    [Browsable(false)]
    public bool IsBindingSuspended => this.mobjCurrencyManager.IsBindingSuspended;

    /// <summary>Gets a value indicating whether the underlying list has a fixed size.</summary>
    /// <returns>true if the underlying list has a fixed size; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool IsFixedSize => this.List.IsFixedSize;

    /// <summary>Gets a value indicating whether the underlying list is read-only.</summary>
    /// <returns>true if the list is read-only; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool IsReadOnly => this.List.IsReadOnly;

    /// <summary>Gets a value indicating whether the items in the underlying list are sorted. </summary>
    /// <returns>true if the list is an <see cref="T:System.ComponentModel.IBindingList"></see> and is sorted; otherwise, false. </returns>
    [Browsable(false)]
    public virtual bool IsSorted => this.mblnIsBindingList && ((IBindingList) this.List).IsSorted;

    /// <summary>Gets a value indicating whether access to the collection is synchronized (thread safe).</summary>
    /// <returns>true to indicate the list is synchronized; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool IsSynchronized => this.List.IsSynchronized;

    /// <summary>Gets or sets the list element at the specified index.</summary>
    /// <returns>The element at the specified index.</returns>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or is equal to or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
    [Browsable(false)]
    public virtual object this[int index]
    {
      get => this.List[index];
      set
      {
        this.List[index] = value;
        if (this.mblnIsBindingList)
          return;
        this.OnSimpleListChanged(ListChangedType.ItemChanged, index);
      }
    }

    /// <summary>Gets the list that the connector is bound to.</summary>
    /// <returns>An <see cref="T:System.Collections.IList"></see> that represents the list, or null if there is no underlying list associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
    [Browsable(false)]
    public IList List
    {
      get
      {
        this.EnsureInnerList();
        return this.mobjInnerList;
      }
    }

    /// <summary>Gets or sets the index of the current item in the underlying list.</summary>
    /// <returns>A zero-based index that specifies the position of the current item in the underlying list.</returns>
    [Browsable(false)]
    [DefaultValue(-1)]
    public int Position
    {
      get => this.mobjCurrencyManager.Position;
      set
      {
        if (this.mobjCurrencyManager.Position == value)
          return;
        this.mobjCurrencyManager.Position = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> events should be raised.</summary>
    /// <returns>true if <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> events should be raised; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    [Browsable(false)]
    public bool RaiseListChangedEvents
    {
      get => this.mblnRaiseListChangedEvents;
      set
      {
        if (this.mblnRaiseListChangedEvents == value)
          return;
        this.mblnRaiseListChangedEvents = value;
      }
    }

    /// <summary>Gets or sets the column names used for sorting, and the sort order for viewing the rows in the data source.</summary>
    /// <returns>A case-sensitive string containing the column name followed by "ASC" (for ascending) or "DESC" (for descending). The default is null.</returns>
    [SRDescription("BindingSourceSortDescr")]
    [SRCategory("CatData")]
    [DefaultValue(null)]
    public string Sort
    {
      get => this.mstrSort;
      set
      {
        this.mstrSort = value;
        this.InnerListSort = value;
      }
    }

    /// <summary>Gets the collection of sort descriptions applied to the data source.</summary>
    /// <returns>If the data source is an <see cref="T:System.ComponentModel.IBindingListView"></see>, a <see cref="T:System.ComponentModel.ListSortDescriptionCollection"></see> that contains the sort descriptions applied to the list; otherwise, null.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public virtual ListSortDescriptionCollection SortDescriptions => this.List is IBindingListView list ? list.SortDescriptions : (ListSortDescriptionCollection) null;

    /// <summary>Gets the direction the items in the list are sorted.</summary>
    /// <returns>One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values indicating the direction the list is sorted.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ListSortDirection SortDirection => this.mblnIsBindingList ? ((IBindingList) this.List).SortDirection : ListSortDirection.Ascending;

    /// <summary>Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting the list.</summary>
    /// <returns>If the list is an <see cref="T:System.ComponentModel.IBindingList"></see>, the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting; otherwise, null.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual PropertyDescriptor SortProperty => this.mblnIsBindingList ? ((IBindingList) this.List).SortProperty : (PropertyDescriptor) null;

    /// <summary>Gets a value indicating whether the data source supports multi-column sorting.</summary>
    /// <returns>true if the list is an <see cref="T:System.ComponentModel.IBindingListView"></see> and supports multi-column sorting; otherwise, false. </returns>
    [Browsable(false)]
    public virtual bool SupportsAdvancedSorting => this.List is IBindingListView list && list.SupportsAdvancedSorting;

    /// <summary>Gets a value indicating whether the data source supports change notification.</summary>
    /// <returns>true in all cases.</returns>
    [Browsable(false)]
    public virtual bool SupportsChangeNotification => true;

    /// <summary>Gets a value indicating whether the data source supports filtering.</summary>
    /// <returns>true if the list is an <see cref="T:System.ComponentModel.IBindingListView"></see> and supports filtering; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool SupportsFiltering => this.List is IBindingListView list && list.SupportsFiltering;

    /// <summary>
    /// Gets whether the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)" /> method.
    /// </summary>
    /// <value></value>
    /// <returns>true if the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)" /> method; otherwise, false.
    /// </returns>
    [Browsable(false)]
    public virtual bool SupportsSearching => this.mblnIsBindingList && ((IBindingList) this.List).SupportsSearching;

    /// <summary>Gets a value indicating whether the data source supports sorting.</summary>
    /// <returns>true if the data source is an <see cref="T:System.ComponentModel.IBindingList"></see> and supports sorting; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool SupportsSorting => this.mblnIsBindingList && ((IBindingList) this.List).SupportsSorting;

    /// <summary>Gets an object that can be used to synchronize access to the underlying list.</summary>
    /// <returns>An object that can be used to synchronize access to the underlying list.</returns>
    [Browsable(false)]
    public virtual object SyncRoot => this.List.SyncRoot;

    bool ISupportInitializeNotification.IsInitialized => !this.mblnInitializing;

    /// <summary>Occurs before an item is added to the underlying list.</summary>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.ComponentModel.AddingNewEventArgs.NewObject"></see> is not the same type as the type contained in the list.</exception>
    [SRDescription("BindingSourceAddingNewEventHandlerDescr")]
    [SRCategory("CatData")]
    public event AddingNewEventHandler AddingNew
    {
      add => this.AddHandler(BindingSource.EVENT_ADDINGNEW, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_ADDINGNEW, (Delegate) value);
    }

    /// <summary>Occurs when all the clients have been bound to this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    [SRCategory("CatData")]
    [SRDescription("BindingSourceBindingCompleteEventHandlerDescr")]
    public event BindingCompleteEventHandler BindingComplete
    {
      add => this.AddHandler(BindingSource.EVENT_BINDINGCOMPLETE, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_BINDINGCOMPLETE, (Delegate) value);
    }

    /// <summary>Occurs when the currently bound item changes.</summary>
    [SRCategory("CatData")]
    [SRDescription("BindingSourceCurrentChangedEventHandlerDescr")]
    public event EventHandler CurrentChanged
    {
      add => this.AddHandler(BindingSource.EVENT_CURRENTCHANGED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_CURRENTCHANGED, (Delegate) value);
    }

    /// <summary>Occurs when a property value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Current"></see> property has changed.</summary>
    [SRDescription("BindingSourceCurrentItemChangedEventHandlerDescr")]
    [SRCategory("CatData")]
    public event EventHandler CurrentItemChanged
    {
      add => this.AddHandler(BindingSource.EVENT_CURRENTITEMCHANGED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_CURRENTITEMCHANGED, (Delegate) value);
    }

    /// <summary>Occurs when a currency-related exception is silently handled by the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
    [SRCategory("CatData")]
    [SRDescription("BindingSourceDataErrorEventHandlerDescr")]
    public event BindingManagerDataErrorEventHandler DataError
    {
      add => this.AddHandler(BindingSource.EVENT_DATAERROR, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_DATAERROR, (Delegate) value);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataMember"></see> property value has changed.</summary>
    [SRCategory("CatData")]
    [SRDescription("BindingSourceDataMemberChangedEventHandlerDescr")]
    public event EventHandler DataMemberChanged
    {
      add => this.AddHandler(BindingSource.EVENT_DATAMEMBERCHANGED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_DATAMEMBERCHANGED, (Delegate) value);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataSource"></see> property value has changed.</summary>
    [SRDescription("BindingSourceDataSourceChangedEventHandlerDescr")]
    [SRCategory("CatData")]
    public event EventHandler DataSourceChanged
    {
      add => this.AddHandler(BindingSource.EVENT_DATASOURCECHANGED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_DATASOURCECHANGED, (Delegate) value);
    }

    /// <summary>Occurs when the underlying list changes or an item in the list changes.</summary>
    [SRCategory("CatData")]
    [SRDescription("BindingSourceListChangedEventHandlerDescr")]
    public event ListChangedEventHandler ListChanged
    {
      add => this.AddHandler(BindingSource.EVENT_LISTCHANGED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_LISTCHANGED, (Delegate) value);
    }

    /// <summary>Occurs after the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Position"></see> property has changed.</summary>
    [SRCategory("CatData")]
    [SRDescription("BindingSourcePositionChangedEventHandlerDescr")]
    public event EventHandler PositionChanged
    {
      add => this.AddHandler(BindingSource.EVENT_POSITIONCHANGED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_POSITIONCHANGED, (Delegate) value);
    }

    event EventHandler ISupportInitializeNotification.Initialized
    {
      add => this.AddHandler(BindingSource.EVENT_INITIALIZED, (Delegate) value);
      remove => this.RemoveHandler(BindingSource.EVENT_INITIALIZED, (Delegate) value);
    }
  }
}
