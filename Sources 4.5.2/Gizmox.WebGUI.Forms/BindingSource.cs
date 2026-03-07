namespace Gizmox.WebGUI.Forms
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Drawing;
    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Forms.Design;

    #region BindingSource class

    /// <summary>Encapsulates the data source for a form.</summary>
    [ToolboxItem(true)]
    [ComplexBindingProperties("DataSource", "DataMember")]
    [SRDescription("DescriptionBindingSource")]
    [DefaultProperty("DataSource")]
    [DefaultEvent("CurrentChanged")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(BindingSource), "BindingSource_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(BindingSource), "BindingSource.bmp")]
#endif
#if WG_NET46
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#else
    [Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#endif

    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ToolboxItemCategory("Data"), Serializable()]
    public class BindingSource : ComponentBase, ICloneable, IBindingListView, IBindingList, IList, ICollection, IEnumerable, ITypedList, ICancelAddNew, ISupportInitializeNotification, ISupportInitialize, ICurrencyManagerProvider
    {
        #region Fields

        #region Static

        private static readonly SerializableEvent EVENT_ADDINGNEW = SerializableEvent.Register("EVENT_ADDINGNEW", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_BINDINGCOMPLETE = SerializableEvent.Register("EVENT_BINDINGCOMPLETE", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_CURRENTCHANGED = SerializableEvent.Register("EVENT_CURRENTCHANGED", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_CURRENTITEMCHANGED = SerializableEvent.Register("EVENT_CURRENTITEMCHANGED", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_DATAERROR = SerializableEvent.Register("EVENT_DATAERROR", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_DATAMEMBERCHANGED = SerializableEvent.Register("EVENT_DATAMEMBERCHANGED", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_DATASOURCECHANGED = SerializableEvent.Register("EVENT_DATASOURCECHANGED", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_INITIALIZED = SerializableEvent.Register("EVENT_INITIALIZED", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_LISTCHANGED = SerializableEvent.Register("EVENT_LISTCHANGED", typeof(Delegate), typeof(BindingSource));
        private static readonly SerializableEvent EVENT_POSITIONCHANGED = SerializableEvent.Register("EVENT_POSITIONCHANGED", typeof(Delegate), typeof(BindingSource));

        #endregion Static

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
       	private bool mblnItemShape = false;
        private Type mobjItemType;
        private EventHandler mobjListItemPropertyChangedHandler;
        private Hashtable mobjRelatedBindingSources;

        #endregion Fields

        #region C'tors / D'tors

        static BindingSource()
        {

        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class to the default property values.</summary>
        public BindingSource()
            : this(null, string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class and adds the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to the specified container.</summary>
        /// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to add the current <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to.</param>
        public BindingSource(IContainer objContainer)
            : this()
        {
            // Checking whether the container is not null which happens in Runtime mode
            if (objContainer != null)
            {
                objContainer.Add(this);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class with the specified data source and data member.</summary>
        /// <param name="objDataSource">The data source for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</param>
        /// <param name="strDataMember">The specific column or list name within the data source to bind to.</param>
        public BindingSource(object objDataSource, string strDataMember)
        {
            InitializeBindingSource(objDataSource, strDataMember);
        }

        /// <summary>
        /// Manual serialization interception for 'NewRow' when the data source is a System.Data.DataView.
        /// A 'NewRow' is a row that has not yet been committed to the underlying DataTable, but can have values in one
        /// or more fields. System.Data.DataView is an unserializable type which means 'NewRow' must be manually serialized
        /// and deserialized.
        /// </summary>
        private object[] marrSerializedDataViewNewRowValues;
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            marrSerializedDataViewNewRowValues = null;
            try
            {
                if ((this.List != null) && (this.List.GetType() == typeof(System.Data.DataView)))
                {
                    if (this.Position >= 0 && this.Position < this.List.Count && ((System.Data.DataRowView)this[this.Position]).IsNew)
                    {
                        marrSerializedDataViewNewRowValues = ((System.Data.DataRowView)this[this.Position]).Row.ItemArray;
                    }
                }
            }
            catch { }

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
                // Get current flag value
                bool blnTemp = this.mblnRaiseListChangedEvents;

                // Disable raising events
                this.mblnRaiseListChangedEvents = false;

                // Reset list
                ResetList();

                // Set flag value original
                this.mblnRaiseListChangedEvents = blnTemp;
            }

            if (marrSerializedDataViewNewRowValues != null)
            {
                object[] arrSerializedDataViewNewRowValues = marrSerializedDataViewNewRowValues;
                marrSerializedDataViewNewRowValues = null;

                // Add new row and load serialized row values

                this.UnwireDataSource();
                this.UnwireInnerList();
                if (this.List.GetType() == typeof(System.Data.DataView))
                {
                    System.Data.DataRowView objRowView = ((System.Data.DataView)this.List).AddNew();
                    objRowView.Row.ItemArray = arrSerializedDataViewNewRowValues;
                }
                this.WireInnerList();
                this.WireDataSource();

                marrSerializedDataViewNewRowValues = null;
            }

        }

        /// <summary>
        /// Initializes the binding source.
        /// </summary>
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
            this.mobjInnerList = new ArrayList();
            this.mobjCurrencyManager = new CurrencyManager(this);
            this.WireCurrencyManager(this.mobjCurrencyManager);
            this.ResetList();
            this.mobjListItemPropertyChangedHandler = new EventHandler(this.ListItem_PropertyChanged);
            this.WireDataSource();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingSource"/> class.
        /// </summary>
        /// <param name="objSourceBindingSource">The source of the binding source.</param>
        public BindingSource(BindingSource objSourceBindingSource)
        {
            if (objSourceBindingSource != null)
            {
                this.InitializeBindingSource(objSourceBindingSource.DataSource, objSourceBindingSource.DataMember);
            }
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        private void CurrencyManager_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            this.OnBindingComplete(e);
        }

        private void CurrencyManager_CurrentChanged(object sender, EventArgs e)
        {
            this.OnCurrentChanged(EventArgs.Empty);
        }

        private void CurrencyManager_CurrentItemChanged(object sender, EventArgs e)
        {
            this.OnCurrentItemChanged(EventArgs.Empty);
        }

        private void CurrencyManager_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            this.OnDataError(e);
        }

        private void CurrencyManager_PositionChanged(object sender, EventArgs e)
        {
            this.OnPositionChanged(e);
        }

        private void DataSource_Initialized(object sender, EventArgs e)
        {
            ISupportInitializeNotification objNotification = this.DataSource as ISupportInitializeNotification;
            if (objNotification != null)
            {
                objNotification.Initialized -= new EventHandler(this.DataSource_Initialized);
            }
            this.EndInitCore();
        }

        private void InnerList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (!this.mblnInnerListChanging)
            {
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
        }

        private void ListItem_PropertyChanged(object sender, EventArgs e)
        {
            int intNum;
            if (sender == this.mobjCurrentItemHookedForItemChange)
            {
                intNum = this.Position;
            }
            else
            {
                intNum = this.IndexOf(sender);
            }
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, intNum));
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.AddingNew"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        internal virtual void OnAddingNew(AddingNewEventArgs e)
        {

            // Raise event if needed
            AddingNewEventHandler objEventHandler = (AddingNewEventHandler)this.GetHandler(BindingSource.EVENT_ADDINGNEW);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.BindingComplete"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
        protected virtual void OnBindingComplete(BindingCompleteEventArgs e)
        {
            // Raise event if needed
            BindingCompleteEventHandler objEventHandler = (BindingCompleteEventHandler)this.GetHandler(BindingSource.EVENT_BINDINGCOMPLETE);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:CurrentChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCurrentChanged(EventArgs e)
        {
            this.UnhookItemChangedEventsForOldCurrent();
            this.HookItemChangedEventsForNewCurrent();

            // Raise event if needed
            EventHandler objEventHandler = (EventHandler)this.GetHandler(BindingSource.EVENT_CURRENTCHANGED);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.CurrentItemChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnCurrentItemChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = (EventHandler)this.GetHandler(BindingSource.EVENT_CURRENTITEMCHANGED);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataError"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingManagerDataErrorEventArgs"></see> that contains the event data. </param>
        protected virtual void OnDataError(BindingManagerDataErrorEventArgs e)
        {
            // Raise event if needed
            BindingManagerDataErrorEventHandler objEventHandler = this.GetHandler(BindingSource.EVENT_DATAERROR) as BindingManagerDataErrorEventHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataMemberChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnDataMemberChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.GetHandler(BindingSource.EVENT_DATAMEMBERCHANGED) as EventHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataSourceChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.GetHandler(BindingSource.EVENT_DATASOURCECHANGED) as EventHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnListChanged(ListChangedEventArgs e)
        {
            if (this.mblnRaiseListChangedEvents && !this.mblnInitializing)
            {
                // Raise event if needed
                ListChangedEventHandler objEventHandler = (ListChangedEventHandler)this.GetHandler(BindingSource.EVENT_LISTCHANGED);
                if (objEventHandler != null)
                {
                    objEventHandler(this, e);
                }
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.PositionChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.ListChangedEventArgs"></see> that contains the event data.</param>
        protected virtual void OnPositionChanged(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = (EventHandler)this.GetHandler(BindingSource.EVENT_POSITIONCHANGED);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        private void OnSimpleListChanged(ListChangedType enmListChangedType, int intNewIndex)
        {
            if (!this.mblnIsBindingList)
            {
                this.OnListChanged(new ListChangedEventArgs(enmListChangedType, intNewIndex));
            }
        }

        private void ParentCurrencyManager_CurrentItemChanged(object sender, EventArgs e)
        {
            if (!this.mblnInitializing && !this.mblnParentsCurrentItemChanging)
            {
                try
                {
                    bool blnFlag1;
                    this.mblnParentsCurrentItemChanging = true;
                    this.mobjCurrencyManager.PullData(out blnFlag1);
                }
                finally
                {
                    this.mblnParentsCurrentItemChanging = false;
                }
                CurrencyManager objCurrencyManager = (CurrencyManager)sender;
                bool blnFlag2 = true;
                if (!CommonUtils.IsNullOrEmpty(this.mstrDataMember))
                {
                    object obj1 = null;
                    IList objList = null;
                    if (objCurrencyManager.Count > 0)
                    {
                        PropertyDescriptorCollection objCollection1 = objCurrencyManager.GetItemProperties();
                        PropertyDescriptor objPropertyDescriptor = objCollection1[this.mstrDataMember];
                        if (objPropertyDescriptor != null)
                        {
                            obj1 = ListBindingHelper.GetList(objPropertyDescriptor.GetValue(objCurrencyManager.Current));
                            objList = obj1 as IList;
                        }
                    }
                    if (objList != null)
                    {
                        this.SetList(objList, false, true);
                    }
                    else if (obj1 != null)
                    {
                        this.SetList(BindingSource.WrapObjectInBindingList(obj1), false, false);
                    }
                    else
                    {
                        this.SetList(BindingSource.CreateBindingList(this.mobjItemType), false, false);
                    }
                    blnFlag2 = (((this.mobjLastCurrentItem == null) || (objCurrencyManager.Count == 0)) || (this.mobjLastCurrentItem != objCurrencyManager.Current)) || (this.Position >= this.Count);
                    this.mobjLastCurrentItem = (objCurrencyManager.Count > 0) ? objCurrencyManager.Current : null;
                    if (blnFlag2)
                    {
                        this.Position = (this.Count > 0) ? 0 : -1;
                    }
                }
                this.OnCurrentItemChanged(EventArgs.Empty);
            }
        }

        private void ParentCurrencyManager_MetaDataChanged(object sender, EventArgs e)
        {
            this.ClearInvalidDataMember();
            this.ResetList();
        }

        #endregion Events

        /// <summary>
        /// Ensures the item shape.
        /// </summary>
        private void EnsureItemShape()
        {
            if (mblnItemShape && mobjItemShape == null)
            {
                mobjItemShape = ListBindingHelper.GetListItemProperties(this.List);
            }
        }

        /// <summary>Adds an existing item to the internal list.</summary>
        /// <returns>The zero-based index at which value was added to the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. </returns>
        /// <param name="objValue">An <see cref="T:System.Object"></see> to be added to the internal list.</param>
        /// <exception cref="T:System.InvalidOperationException">value differs in type from the existing items in the underlying list.</exception>
        public virtual int Add(object objValue)
        {
            int num1 = -1;
            if ((this.mobjDataSource == null) && (this.List.Count == 0))
            {
                this.SetList(BindingSource.CreateBindingList((objValue == null) ? typeof(object) : objValue.GetType()), true, true);
            }
            if ((objValue != null) && !this.mobjItemType.IsAssignableFrom(objValue.GetType()))
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceItemTypeMismatchOnAdd"));
            }
            if ((objValue == null) && this.mobjItemType.IsValueType)
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceItemTypeIsValueType"));
            }
            num1 = this.List.Add(objValue);
            this.OnSimpleListChanged(ListChangedType.ItemAdded, num1);
            return num1;
        }

        private object AddNewMono()
        {
            if (!this.AllowNewInternal(false))
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperAddToReadOnlyList"));
            }
            if (!this.AllowNewInternal(true))
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedToSetAllowNew", new object[] { (this.mobjItemType == null) ? "(null)" : this.mobjItemType.FullName }));
            }
            int num1 = this.mintAddNewPos;
            this.EndEdit();
            if (num1 != -1)
            {
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, num1));
            }

            //AddingNewEventArgs args1 = new AddingNewEventArgs();
            int num2 = this.List.Count;
            //this.OnAddingNew(args1);
            //object obj1 = args1.NewObject;

            object obj1 = null;
            if (obj1 == null)
            {
                if (this.mblnIsBindingList)
                {
                    obj1 = (this.List as IBindingList).AddNew();
                    this.Position = this.Count - 1;
                    return obj1;
                }
                if (this.mobjItemConstructor == null)
                {
                    throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedAParameterlessConstructor", new object[] { (this.mobjItemType == null) ? "(null)" : this.mobjItemType.FullName }));
                }
                obj1 = this.mobjItemConstructor.Invoke(null);
            }
            if (this.List.Count > num2)
            {
                this.mintAddNewPos = this.Position;
                return obj1;
            }
            this.mintAddNewPos = this.Add(obj1);
            this.Position = this.mintAddNewPos;
            return obj1;
        }

        private object AddNewNonMono()
        {
#if !WG_MONO
            if (!this.AllowNewInternal(false))
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperAddToReadOnlyList"));
            }
            if (!this.AllowNewInternal(true))
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedToSetAllowNew", new object[] { (this.mobjItemType == null) ? "(null)" : this.mobjItemType.FullName }));
            }
            int num1 = this.mintAddNewPos;
            this.EndEdit();
            if (num1 != -1)
            {
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, num1));
            }

            AddingNewEventArgs args1 = new AddingNewEventArgs();
            int num2 = this.List.Count;
            this.OnAddingNew(args1);
            object obj1 = args1.NewObject;
            if (obj1 == null)
            {
                if (this.mblnIsBindingList)
                {
                    obj1 = (this.List as IBindingList).AddNew();
                    this.Position = this.Count - 1;
                    return obj1;
                }
                if (this.mobjItemConstructor == null)
                {
                    throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedAParameterlessConstructor", new object[] { (this.mobjItemType == null) ? "(null)" : this.mobjItemType.FullName }));
                }
                obj1 = this.mobjItemConstructor.Invoke(null);
            }
            if (this.List.Count > num2)
            {
                this.mintAddNewPos = this.Position;
                return obj1;
            }
            this.mintAddNewPos = this.Add(obj1);
            this.Position = this.mintAddNewPos;
            return obj1;
#else
            return null;
#endif
        }

        /// <summary>Adds a new item to the underlying list.</summary>
        /// <returns>The <see cref="T:System.Object"></see> that was created and added to the list.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowNew"></see> property is set to false. -or-A public default constructor could not be found for the current item type.</exception>
        public virtual object AddNew()
        {
            if (!this.DesignMode)
            {
                if (CommonUtils.IsMono)
                {
                    return AddNewMono();
                }
                else
                {
                    return AddNewNonMono();
                }
            }
            else
            {
                return null;
            }
        }

        private bool AllowNewInternal(bool blnCheckConstructor)
        {
            if (this.mblnDisposedOrFinalized)
            {
                return false;
            }
            if (this.mblnAllowNewIsSet)
            {
                return this.mblnAllowNewSetValue;
            }
            if (this.mblnListExtractedFromEnumerable)
            {
                return false;
            }
            if (this.mblnIsBindingList)
            {
                return ((IBindingList)this.List).AllowNew;
            }
            return this.IsListWriteable(blnCheckConstructor);
        }

        /// <summary>Sorts the data source with the specified sort descriptions.</summary>
        /// <param name="objSortsCollection">A <see cref="T:System.ComponentModel.ListSortDescriptionCollection"></see> containing the sort descriptions to apply to the data source.</param>
        /// <exception cref="T:System.NotSupportedException">The data source is not an <see cref="T:System.ComponentModel.IBindingListView"></see>.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ApplySort(ListSortDescriptionCollection objSortsCollection)
        {
            IBindingListView objView = this.List as IBindingListView;
            if (objView == null)
            {
                throw new NotSupportedException(SR.GetString("OperationRequiresIBindingListView"));
            }
            objView.ApplySort(objSortsCollection);
        }

        /// <summary>Sorts the data source using the specified property descriptor and sort direction.</summary>
        /// <param name="enmSortDirection">A <see cref="T:System.ComponentModel.ListSortDirection"></see> indicating how the list should be sorted.</param>
        /// <param name="objPropertyDescriptor">A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that describes the property by which to sort the data source.</param>
        /// <exception cref="T:System.NotSupportedException">The data source is not an <see cref="T:System.ComponentModel.IBindingList"></see>.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ApplySort(PropertyDescriptor objPropertyDescriptor, ListSortDirection enmSortDirection)
        {
            if (!this.mblnIsBindingList)
            {
                throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
            }
            ((IBindingList)this.List).ApplySort(objPropertyDescriptor, enmSortDirection);
        }

        private static string BuildSortString(ListSortDescriptionCollection objSortsColln)
        {
            if (objSortsColln == null)
            {
                return string.Empty;
            }
            StringBuilder objStringBuilder = new StringBuilder(objSortsColln.Count);
            for (int num1 = 0; num1 < objSortsColln.Count; num1++)
            {
                objStringBuilder.Append(objSortsColln[num1].PropertyDescriptor.Name + ((objSortsColln[num1].SortDirection == ListSortDirection.Ascending) ? " ASC" : " DESC") + ((num1 < (objSortsColln.Count - 1)) ? "," : string.Empty));
            }
            return objStringBuilder.ToString();
        }

        /// <summary>Cancels the current edit operation.</summary>
        public void CancelEdit()
        {
            this.mobjCurrencyManager.CancelCurrentEdit();
        }

        /// <summary>Removes all elements from the list.</summary>
        public virtual void Clear()
        {
            this.UnhookItemChangedEventsForOldCurrent();
            this.List.Clear();
            this.OnSimpleListChanged(ListChangedType.Reset, -1);
        }

        private void ClearInvalidDataMember()
        {
            if (!this.IsDataMemberValid())
            {
                this.mstrDataMember = "";
                this.OnDataMemberChanged(EventArgs.Empty);
            }
        }

        /// <summary>Determines whether an object is an item in the list.</summary>
        /// <returns>true if the value parameter is found in the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>; otherwise, false.</returns>
        /// <param name="objValue">The <see cref="T:System.Object"></see> to locate in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. The value can be null. </param>
        public virtual bool Contains(object objValue)
        {
            return this.List.Contains(objValue);
        }

        /// <summary>Copies the contents of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> to the specified array, starting at the specified index value.</summary>
        /// <param name="objArray">The destination array.</param>
        /// <param name="intIndex">The index in the destination array at which to start the copy operation.</param>
        public virtual void CopyTo(Array objArray, int intIndex)
        {
            this.List.CopyTo(objArray, intIndex);
        }

        private static IList CreateBindingList(Type objType)
        {
            //TODO:BINDING
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            Type objType2 = typeof(BindingList<>).MakeGenericType(new Type[] { objType });
            return (IList)Gizmox.WebGUI.Forms.SecurityUtils.SecureCreateInstance(objType2);
#else
            return null;
#endif
        }

        private static object CreateInstanceOfType(Type objType)
        {
            object obj1 = null;
            Exception objException = null;
            try
            {
                obj1 = Gizmox.WebGUI.Forms.SecurityUtils.SecureCreateInstance(objType);
            }
            catch (TargetInvocationException objTargetInvocationException)
            {
                objException = objTargetInvocationException;
            }
            catch (MethodAccessException objMethodAccessException)
            {
                objException = objMethodAccessException;
            }
            catch (MissingMethodException objMissingMethodException)
            {
                objException = objMissingMethodException;
            }
            if (objException != null)
            {
                throw new NotSupportedException(SR.GetString("BindingSourceInstanceError"), objException);
            }
            return obj1;
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
                this.mobjDataSource = null;
                this.mstrDataMember = null;
                this.mobjInnerList = null;
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
            if (!this.mblnEndingEdit)
            {
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
        }

        private void EndInitCore()
        {
            this.mblnInitializing = false;
            this.EnsureInnerList();
            this.OnInitialized();

            //This code was added as a complementary to the original BindingSource code
            //in order to enable support for hierarchical data objects binding.
            //As a workaround this code will call the EndInit() method of the related
            //(inner) binding sources and by that, the "Initialize" state of the binding
            //source will be ended. It seems as if EndInit() is not invoked for related
            //(inner) binding sources without this fix.
            if (mobjRelatedBindingSources != null)
            {
                foreach (ISupportInitialize objBindingSource in mobjRelatedBindingSources.Values)
                {
                    objBindingSource.EndInit();
                }
            }
        }

        private void EnsureInnerList()
        {
            if (!this.mblnInitializing && this.mblnNeedToSetList)
            {
                this.mblnNeedToSetList = false;
                this.ResetList();
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new BindingSource(this);
        }

        /// <summary>Searches for the index of the item that has the given property descriptor.</summary>
        /// <returns>The zero-based index of the item that has the given value for <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.</returns>
        /// <param name="objPropertyDescriptor">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to search for. </param>
        /// <param name="objKey">The value of prop to match. </param>
        /// <exception cref="T:System.NotSupportedException">The underlying list is not of type <see cref="T:System.ComponentModel.IBindingList"></see>.</exception>
        public virtual int Find(PropertyDescriptor objPropertyDescriptor, object objKey)
        {
            if (!this.mblnIsBindingList)
            {
                throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
            }
            return ((IBindingList)this.List).Find(objPropertyDescriptor, objKey);
        }

        /// <summary>Returns the index of the item in the list with the specified property name and value.</summary>
        /// <returns>The zero-based index of the item with the specified property name and value.</returns>
        /// <param name="objKey">The value of the item with the specified propertyName to find.</param>
        /// <param name="strPropertyName">The name of the property to search for.</param>
        /// <exception cref="T:System.ArgumentException">propertyName does not match a property in the list.</exception>
        /// <exception cref="T:System.InvalidOperationException">The underlying list is not a <see cref="T:System.ComponentModel.IBindingList"></see> with searching functionality implemented.</exception>
        public int Find(string strPropertyName, object objKey)
        {
            EnsureItemShape();

            PropertyDescriptor objPropertyDescriptor = (this.mobjItemShape == null) ? null : this.mobjItemShape.Find(strPropertyName, true);
            if (objPropertyDescriptor == null)
            {
                throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", new object[] { strPropertyName }));
            }
            return this.Find(objPropertyDescriptor, objKey);
        }

        /// <summary>Retrieves an enumerator for the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>. </returns>
        public virtual IEnumerator GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        /// <summary>Retrieves an array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects representing the bindable properties of the data source list type.</summary>
        /// <returns>An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects that represents the properties on this list type used to bind data.</returns>
        /// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the list as bindable.</param>
        public virtual PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
        {
            object obj1 = ListBindingHelper.GetList(this.mobjDataSource);
            if ((obj1 is ITypedList) && !CommonUtils.IsNullOrEmpty(this.mstrDataMember))
            {
                return ListBindingHelper.GetListItemProperties(obj1, this.mstrDataMember, arrListAccessors);
            }
            return ListBindingHelper.GetListItemProperties(this.List, arrListAccessors);
        }

        private static IList GetListFromEnumerable(IEnumerable objEnumerable)
        {
            IList objList = null;
            foreach (object obj1 in objEnumerable)
            {
                if (objList == null)
                {
                    objList = BindingSource.CreateBindingList(obj1.GetType());
                }
                objList.Add(obj1);
            }
            return objList;
        }

        private static IList GetListFromType(Type objType)
        {
            if (typeof(ITypedList).IsAssignableFrom(objType) && typeof(IList).IsAssignableFrom(objType))
            {
                return (BindingSource.CreateInstanceOfType(objType) as IList);
            }
            if (typeof(IListSource).IsAssignableFrom(objType))
            {
                return (BindingSource.CreateInstanceOfType(objType) as IListSource).GetList();
            }
            return BindingSource.CreateBindingList(ListBindingHelper.GetListItemType(objType));
        }

        /// <summary>Gets the name of the list supplying data for the binding.</summary>
        /// <returns>The name of the list supplying the data for binding.</returns>
        /// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the list as bindable.</param>
        public virtual string GetListName(PropertyDescriptor[] arrListAccessors)
        {
            return ListBindingHelper.GetListName(this.List, arrListAccessors);
        }

        private BindingSource GetRelatedBindingSource(string strDataMember)
        {
            if (this.mobjRelatedBindingSources == null)
            {
                this.mobjRelatedBindingSources = new Hashtable();
            }
            foreach (string strText1 in this.mobjRelatedBindingSources.Keys)
            {
                if (ClientUtils.IsEquals(strText1, strDataMember, StringComparison.OrdinalIgnoreCase))
                {
                    return this.mobjRelatedBindingSources[strText1] as BindingSource;
                }
            }
            BindingSource objBindingSource = new BindingSource(this, strDataMember);
            this.mobjRelatedBindingSources[strDataMember] = objBindingSource;
            return objBindingSource;
        }

        /// <summary>Gets the related currency manager for the specified data member.</summary>
        /// <returns>The related <see cref="T:CurrencyManager"></see> for the specified data member.</returns>
        /// <param name="strDataMember">The name of column or list, within the data source to retrieve the currency manager for.</param>
        public virtual CurrencyManager GetRelatedCurrencyManager(string strDataMember)
        {
            this.EnsureInnerList();
            if (CommonUtils.IsNullOrEmpty(strDataMember))
            {
                return this.mobjCurrencyManager;
            }
            if (strDataMember.IndexOf(".") != -1)
            {
                return null;
            }
            BindingSource objBindingSource = this.GetRelatedBindingSource(strDataMember);
            return objBindingSource.CurrencyManager;
        }

        private void HookItemChangedEventsForNewCurrent()
        {
            if (!this.mblnListRaisesItemChangedEvents)
            {
                if ((this.Position >= 0) && (this.Position <= (this.Count - 1)))
                {
                    this.mobjCurrentItemHookedForItemChange = this.Current;
                    this.WirePropertyChangedEvents(this.mobjCurrentItemHookedForItemChange);
                }
                else
                {
                    this.mobjCurrentItemHookedForItemChange = null;
                }
            }
        }

        /// <summary>Searches for the specified object and returns the index of the first occurrence within the entire list.</summary>
        /// <returns>The zero-based index of the first occurrence of the value parameter; otherwise, -1 if value is not in the list.</returns>
        /// <param name="objValue">The <see cref="T:System.Object"></see> to locate in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. The value can be null. </param>
        public virtual int IndexOf(object objValue)
        {
            return this.List.IndexOf(objValue);
        }

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
            {
                return true;
            }
            if (CommonUtils.IsNullOrEmpty(this.mstrDataMember))
            {
                return true;
            }
            PropertyDescriptorCollection objCollection1 = ListBindingHelper.GetListItemProperties(this.mobjDataSource);
            if (objCollection1[this.mstrDataMember] != null)
            {
                return true;
            }
            return false;
        }

        private bool IsListWriteable(bool blnCheckConstructor)
        {
            if (this.List.IsReadOnly || this.List.IsFixedSize)
            {
                return false;
            }
            if (blnCheckConstructor)
            {
                return (this.mobjItemConstructor != null);
            }
            return true;
        }

        /// <summary>Moves to the first item in the list.</summary>
        public void MoveFirst()
        {
            this.Position = 0;
        }

        /// <summary>Moves to the last item in the list.</summary>
        public void MoveLast()
        {
            this.Position = this.Count - 1;
        }

        /// <summary>Moves to the next item in the list.</summary>
        public void MoveNext()
        {
            this.Position++;
        }

        /// <summary>Moves to the previous item in the list.</summary>
        public void MovePrevious()
        {
            this.Position--;
        }

        private void OnInitialized()
        {
            // Raise event if needed
            EventHandler objEventHandler = (EventHandler)this.GetHandler(BindingSource.EVENT_INITIALIZED);
            if (objEventHandler != null)
            {
                objEventHandler(this, EventArgs.Empty);
            }
        }

        private ListSortDescriptionCollection ParseSortString(string strSortString)
        {
            if (CommonUtils.IsNullOrEmpty(strSortString))
            {
                return new ListSortDescriptionCollection();
            }
            ArrayList objList = new ArrayList();
            PropertyDescriptorCollection objCollection1 = this.mobjCurrencyManager.GetItemProperties();
            string[] arrTextArray = strSortString.Split(new char[] { ',' });
            for (int num1 = 0; num1 < arrTextArray.Length; num1++)
            {
                string strText = arrTextArray[num1].Trim();
                int num2 = strText.Length;
                bool blnFlag1 = true;
                if ((num2 >= 5) && (string.Compare(strText, num2 - 4, " ASC", 0, 4, true, CultureInfo.InvariantCulture) == 0))
                {
                    strText = strText.Substring(0, num2 - 4).Trim();
                }
                else if ((num2 >= 6) && (string.Compare(strText, num2 - 5, " DESC", 0, 5, true, CultureInfo.InvariantCulture) == 0))
                {
                    blnFlag1 = false;
                    strText = strText.Substring(0, num2 - 5).Trim();
                }
                if (strText.StartsWith("["))
                {
                    if (!strText.EndsWith("]"))
                    {
                        throw new ArgumentException(SR.GetString("BindingSourceBadSortString"));
                    }
                    strText = strText.Substring(1, strText.Length - 2);
                }
                PropertyDescriptor objPropertyDescriptor = objCollection1.Find(strText, true);
                if (objPropertyDescriptor == null)
                {
                    throw new ArgumentException(SR.GetString("BindingSourceSortStringPropertyNotInIBindingList"));
                }
                objList.Add(new ListSortDescription(objPropertyDescriptor, blnFlag1 ? ListSortDirection.Ascending : ListSortDirection.Descending));
            }
            ListSortDescription[] arrDescriptionArray = new ListSortDescription[objList.Count];
            objList.CopyTo(arrDescriptionArray);
            return new ListSortDescriptionCollection(arrDescriptionArray);
        }

        /// <summary>Removes the specified item from the list.</summary>
        /// <param name="objValue">The item to remove from the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property.</param>
        /// <exception cref="T:System.NotSupportedException">The underlying list has a fixed size or is read-only. </exception>
        public virtual void Remove(object objValue)
        {
            int num1 = this.IndexOf(objValue);
            this.List.Remove(objValue);
            if (num1 != -1)
            {
                this.OnSimpleListChanged(ListChangedType.ItemDeleted, num1);
            }
        }

        /// <summary>Removes the item at the specified index in the list.</summary>
        /// <param name="intIndex">The zero-based index of the item to remove. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see> property.</exception>
        /// <exception cref="T:System.NotSupportedException">The underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property is read-only or has a fixed size.</exception>
        public virtual void RemoveAt(int intIndex)
        {
            object obj1 = this[intIndex];
            this.List.RemoveAt(intIndex);
            this.OnSimpleListChanged(ListChangedType.ItemDeleted, intIndex);
        }

        /// <summary>Removes the current item from the list.</summary>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowRemove"></see> property is false.-or-<see cref="P:Gizmox.WebGUI.Forms.BindingSource.Position"></see> is less than zero or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
        /// <exception cref="T:System.NotSupportedException">The underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property is read-only or has a fixed size.</exception>
        public void RemoveCurrent()
        {
            if (!this.AllowRemove)
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceRemoveCurrentNotAllowed"));
            }
            if ((this.Position < 0) || (this.Position >= this.Count))
            {
                throw new InvalidOperationException(SR.GetString("BindingSourceRemoveCurrentNoCurrentItem"));
            }
            this.RemoveAt(this.Position);
        }

        /// <summary>Removes the filter associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        /// <exception cref="T:System.NotSupportedException">The underlying list does not support filtering.</exception>
        public virtual void RemoveFilter()
        {
            this.mstrFilter = null;
            IBindingListView objView = this.List as IBindingListView;
            if (objView != null)
            {
                objView.RemoveFilter();
            }
        }

        /// <summary>Removes the sort associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        /// <exception cref="T:System.NotSupportedException">The underlying list does not support sorting.</exception>
        public virtual void RemoveSort()
        {
            this.mstrSort = null;
            if (this.mblnIsBindingList)
            {
                ((IBindingList)this.List).RemoveSort();
            }
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
            {
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.PropertyDescriptorChanged, null));
            }
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread the currently selected item and refresh its displayed value.</summary>
        public void ResetCurrentItem()
        {
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.Position));
        }

        /// <summary>Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread the item at the specified index, and refresh its displayed value. </summary>
        /// <param name="intItemIndex">The zero-based index of the item that has changed.</param>
        public void ResetItem(int intItemIndex)
        {
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, intItemIndex));
        }

        private void ResetList()
        {
            if (this.mblnInitializing)
            {
                this.mblnNeedToSetList = true;
            }
            else
            {
                this.mblnNeedToSetList = false;
                object obj1 = (this.mobjDataSource is Type) ? BindingSource.GetListFromType(this.mobjDataSource as Type) : this.mobjDataSource;
                object obj2 = ListBindingHelper.GetList(obj1, this.mstrDataMember);
                this.mblnListExtractedFromEnumerable = false;
                if (!(obj2 is IList))
                {
                    if (obj2 is IEnumerable)
                    {
                        obj2 = BindingSource.GetListFromEnumerable(obj2 as IEnumerable);
                        this.mblnListExtractedFromEnumerable = true;
                    }
                    else if (obj2 != null)
                    {
                        obj2 = BindingSource.WrapObjectInBindingList(obj2);
                    }
                    else
                    {
                        obj2 = BindingSource.CreateBindingList(ListBindingHelper.GetListItemType(this.mobjDataSource, this.mstrDataMember));
                    }
                }
                this.SetList(obj2 as IList, true, true);
            }
        }

        /// <summary>Resumes data binding.</summary>
        public void ResumeBinding()
        {
            this.mobjCurrencyManager.ResumeBinding();
        }

        private void SetList(IList objList, bool blnMetaDataChanged, bool blnApplySortAndFilter)
        {
            if (objList == null)
            {
                objList = BindingSource.CreateBindingList(this.mobjItemType);
            }
            this.UnwireInnerList();
            this.UnhookItemChangedEventsForOldCurrent();
            this.mobjInnerList = objList;
            this.mblnIsBindingList = objList is IBindingList;
            if (objList is IRaiseItemChangedEvents)
            {
                this.mblnListRaisesItemChangedEvents = (objList as IRaiseItemChangedEvents).RaisesItemChangedEvents;
            }
            else if (objList is System.Data.DataView)
            {
                this.mblnListRaisesItemChangedEvents = false;
            }
            else
            {
                this.mblnListRaisesItemChangedEvents = this.mblnIsBindingList;
            }
            if (blnMetaDataChanged)
            {
                this.mobjItemType = ListBindingHelper.GetListItemType(this.List);
                this.mobjItemShape = ListBindingHelper.GetListItemProperties(this.List);
                this.mblnItemShape = (mobjItemShape != null);
                this.mobjItemConstructor = this.mobjItemType.GetConstructor(BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            }
            this.WireInnerList();
            this.HookItemChangedEventsForNewCurrent();
            this.ResetBindings(blnMetaDataChanged);
            if (blnApplySortAndFilter)
            {
                if (this.Sort != null)
                {
                    this.InnerListSort = this.Sort;
                }
                if (this.Filter != null)
                {
                    this.InnerListFilter = this.Filter;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeAllowNew()
        {
            return this.mblnAllowNewIsSet;
        }

        /// <summary>Suspends data binding to prevent changes from updating the bound data source.</summary>
        public void SuspendBinding()
        {
            this.mobjCurrencyManager.SuspendBinding();
        }

        void IBindingList.AddIndex(PropertyDescriptor objPropertyDescriptor)
        {
            if (!this.mblnIsBindingList)
            {
                throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
            }
            ((IBindingList)this.List).AddIndex(objPropertyDescriptor);
        }

        void IBindingList.RemoveIndex(PropertyDescriptor objPropertyDescriptor)
        {
            if (!this.mblnIsBindingList)
            {
                throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
            }
            ((IBindingList)this.List).RemoveIndex(objPropertyDescriptor);
        }

        void ICancelAddNew.CancelNew(int intPosition)
        {
            if ((this.mintAddNewPos >= 0) && (this.mintAddNewPos == intPosition))
            {
                this.RemoveAt(this.mintAddNewPos);
                this.mintAddNewPos = -1;
            }
            else
            {
                ICancelAddNew new1 = this.List as ICancelAddNew;
                if (new1 != null)
                {
                    new1.CancelNew(intPosition);
                }
            }
        }

        void ICancelAddNew.EndNew(int intPosition)
        {
            if ((this.mintAddNewPos >= 0) && (this.mintAddNewPos == intPosition))
            {
                this.mintAddNewPos = -1;
            }
            else
            {
                ICancelAddNew new1 = this.List as ICancelAddNew;
                if (new1 != null)
                {
                    new1.EndNew(intPosition);
                }
            }
        }

        void ISupportInitialize.BeginInit()
        {
            this.mblnInitializing = true;
        }

        void ISupportInitialize.EndInit()
        {
            ISupportInitializeNotification objNotification = this.DataSource as ISupportInitializeNotification;
            if ((objNotification != null) && !objNotification.IsInitialized)
            {
                objNotification.Initialized += new EventHandler(this.DataSource_Initialized);
            }
            else
            {
                this.EndInitCore();
            }
        }

        private void ThrowIfBindingSourceRecursionDetected(object objNewDataSource)
        {
            for (BindingSource objBindingSource = objNewDataSource as BindingSource; objBindingSource != null; objBindingSource = objBindingSource.DataSource as BindingSource)
            {
                if (objBindingSource == this)
                {
                    throw new InvalidOperationException(SR.GetString("BindingSourceRecursionDetected"));
                }
            }
        }

        private void UnhookItemChangedEventsForOldCurrent()
        {
            if (!this.mblnListRaisesItemChangedEvents)
            {
                this.UnwirePropertyChangedEvents(this.mobjCurrentItemHookedForItemChange);
                this.mobjCurrentItemHookedForItemChange = null;
            }
        }

        private void UnwireCurrencyManager(CurrencyManager objCurrencyManager)
        {
            if (objCurrencyManager != null)
            {
                objCurrencyManager.PositionChanged -= new EventHandler(this.CurrencyManager_PositionChanged);
                objCurrencyManager.CurrentChanged -= new EventHandler(this.CurrencyManager_CurrentChanged);
                objCurrencyManager.CurrentItemChanged -= new EventHandler(this.CurrencyManager_CurrentItemChanged);
                objCurrencyManager.BindingComplete -= new BindingCompleteEventHandler(this.CurrencyManager_BindingComplete);
                objCurrencyManager.DataError -= new BindingManagerDataErrorEventHandler(this.CurrencyManager_DataError);
            }
        }

        private void UnwireDataSource()
        {
            if (this.mobjDataSource is ICurrencyManagerProvider)
            {
                CurrencyManager objCurrencyManager = (this.mobjDataSource as ICurrencyManagerProvider).CurrencyManager;
                objCurrencyManager.CurrentItemChanged -= new EventHandler(this.ParentCurrencyManager_CurrentItemChanged);
                objCurrencyManager.MetaDataChanged -= new EventHandler(this.ParentCurrencyManager_MetaDataChanged);
            }
        }

        private void UnwireInnerList()
        {
            if (this.mobjInnerList is IBindingList)
            {
                IBindingList objList = this.mobjInnerList as IBindingList;
                objList.ListChanged -= new ListChangedEventHandler(this.InnerList_ListChanged);
            }
        }

        private void UnwirePropertyChangedEvents(object objItem)
        {
            EnsureItemShape();

            if ((objItem != null) && (this.mobjItemShape != null))
            {
                for (int num1 = 0; num1 < this.mobjItemShape.Count; num1++)
                {
                    if (this.mobjListItemPropertyChangedHandler != null)
                    {
                        this.mobjItemShape[num1].RemoveValueChanged(objItem, this.mobjListItemPropertyChangedHandler); 
                    }
                }
            }
        }



        private void WireCurrencyManager(CurrencyManager objCurrencyManager)
        {
            if (objCurrencyManager != null)
            {
                objCurrencyManager.PositionChanged += new EventHandler(this.CurrencyManager_PositionChanged);
                objCurrencyManager.CurrentChanged += new EventHandler(this.CurrencyManager_CurrentChanged);
                objCurrencyManager.CurrentItemChanged += new EventHandler(this.CurrencyManager_CurrentItemChanged);
                objCurrencyManager.BindingComplete += new BindingCompleteEventHandler(this.CurrencyManager_BindingComplete);
                objCurrencyManager.DataError += new BindingManagerDataErrorEventHandler(this.CurrencyManager_DataError);
            }
        }

        private void WireDataSource()
        {
            if (this.mobjDataSource is ICurrencyManagerProvider)
            {
                CurrencyManager objCurrencyManager = (this.mobjDataSource as ICurrencyManagerProvider).CurrencyManager;
                objCurrencyManager.CurrentItemChanged += new EventHandler(this.ParentCurrencyManager_CurrentItemChanged);
                objCurrencyManager.MetaDataChanged += new EventHandler(this.ParentCurrencyManager_MetaDataChanged);
            }
        }

        private void WireInnerList()
        {
            if (this.mobjInnerList is IBindingList)
            {
                IBindingList objList = this.mobjInnerList as IBindingList;
                objList.ListChanged += new ListChangedEventHandler(this.InnerList_ListChanged);
            }
        }

        private void WirePropertyChangedEvents(object objItem)
        {
            EnsureItemShape();

            if ((objItem != null) && (this.mobjItemShape != null))
            {
                for (int num1 = 0; num1 < this.mobjItemShape.Count; num1++)
                {
                    if (this.mobjListItemPropertyChangedHandler != null)
                    {
                        this.mobjItemShape[num1].AddValueChanged(objItem, this.mobjListItemPropertyChangedHandler); 
                    }
                }
            }
        }

        private static IList WrapObjectInBindingList(object obj)
        {
            IList objList = BindingSource.CreateBindingList(obj.GetType());
            objList.Add(obj);
            return objList;
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets a value indicating whether items in the underlying list can be edited.</summary>
        /// <returns>true to indicate list items can be edited; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool AllowEdit
        {
            get
            {
                if (this.mblnIsBindingList)
                {
                    return ((IBindingList)this.List).AllowEdit;
                }
                return !this.List.IsReadOnly;
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="M:Gizmox.WebGUI.Forms.BindingSource.AddNew"></see> method can be used to add items to the list.</summary>
        /// <returns>true if <see cref="M:Gizmox.WebGUI.Forms.BindingSource.AddNew"></see> can be used to add items to the list; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">This property is set to true when the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property has a fixed size or is read-only.</exception>
        /// <exception cref="T:System.MissingMethodException">The property is set to true and the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.AddingNew"></see> event is not handled when the underlying list type does not have a default constructor.</exception>
        [SRCategory("CatBehavior"), SRDescription("BindingSourceAllowNewDescr")]
        public virtual bool AllowNew
        {
            get
            {
                return this.AllowNewInternal(true);
            }
            set
            {
                if (!this.mblnAllowNewIsSet || (value != this.mblnAllowNewSetValue))
                {
                    if ((value && !this.mblnIsBindingList) && !this.IsListWriteable(false))
                    {
                        throw new InvalidOperationException(SR.GetString("NoAllowNewOnReadOnlyList"));
                    }
                    this.mblnAllowNewIsSet = true;
                    this.mblnAllowNewSetValue = value;
                    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
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
                {
                    return ((IBindingList)this.List).AllowRemove;
                }
                if (!this.List.IsReadOnly)
                {
                    return !this.List.IsFixedSize;
                }
                return false;
            }
        }

        /// <summary>Gets the total number of items in the underlying list.</summary>
        /// <returns>The total number of items in the underlying list.</returns>
        [Browsable(false)]
        public virtual int Count
        {
            get
            {
                int num1;
                try
                {
                    if (this.mblnDisposedOrFinalized)
                    {
                        return 0;
                    }
                    if (this.mblnRecursionDetectionFlag)
                    {
                        throw new InvalidOperationException(SR.GetString("BindingSourceRecursionDetected"));
                    }
                    this.mblnRecursionDetectionFlag = true;
                    num1 = this.List.Count;
                }
                finally
                {
                    this.mblnRecursionDetectionFlag = false;
                }
                return num1;
            }
        }

        /// <summary>Gets the currency manager associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        /// <returns>The <see cref="T:CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
        [Browsable(false)]
        public virtual CurrencyManager CurrencyManager
        {
            get
            {
                return this.GetRelatedCurrencyManager(null);
            }
        }

        /// <summary>Gets the current item in the list.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the current item in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property, or null if the list has no items.</returns>
        [Browsable(false)]
        public object Current
        {
            get
            {
                if (this.mobjCurrencyManager.Count <= 0)
                {
                    return null;
                }
                return this.mobjCurrencyManager.Current;
            }
        }

        /// <summary>Gets or sets the specific list in the data source to which the connector currently binds to.</summary>
        /// <returns>The name of a list (or row) in the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataSource"></see>. The default is an empty string ("").</returns>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [RefreshProperties(RefreshProperties.Repaint), SRDescription("BindingSourceDataMemberDescr"), Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), DefaultValue(""), SRCategory("CatData")]
#else
        [RefreshProperties(RefreshProperties.Repaint), SRDescription("BindingSourceDataMemberDescr"), Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), DefaultValue(""), SRCategory("CatData")]
#endif
        public string DataMember
        {
            get
            {
                return this.mstrDataMember;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this.mstrDataMember.Equals(value))
                {
                    this.mstrDataMember = value;
                    this.ResetList();
                    this.OnDataMemberChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>Gets or sets the data source that the connector binds to.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that acts as a data source. The default is null.</returns>
        [AttributeProvider(typeof(Binding.IDataSourceAttributeProvider)), RefreshProperties(RefreshProperties.Repaint), DefaultValue((string)null), SRCategory("CatData"), SRDescription("BindingSourceDataSourceDescr")]
        public object DataSource
        {
            get
            {
                return this.mobjDataSource;
            }
            set
            {
                if (this.mobjDataSource != value)
                {
                    this.ThrowIfBindingSourceRecursionDetected(value);
                    this.UnwireDataSource();
                    this.mobjDataSource = value;
                    this.ClearInvalidDataMember();
                    this.ResetList();
                    this.WireDataSource();
                    this.OnDataSourceChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>Gets or sets the expression used to filter which rows are viewed.</summary>
        /// <returns>A string that specifies how rows are to be filtered. The default is null.</returns>
        [DefaultValue((string)null), SRDescription("BindingSourceFilterDescr"), SRCategory("CatData")]
        public virtual string Filter
        {
            get
            {
                return this.mstrFilter;
            }
            set
            {
                this.mstrFilter = value;
                this.InnerListFilter = value;
            }
        }

        private string InnerListFilter
        {
            get
            {
                IBindingListView objView = this.List as IBindingListView;
                if ((objView != null) && objView.SupportsFiltering)
                {
                    return objView.Filter;
                }
                return string.Empty;
            }
            set
            {
                if ((!this.mblnInitializing && !base.DesignMode) && !ClientUtils.IsEquals(value, this.InnerListFilter, StringComparison.Ordinal))
                {
                    IBindingListView objView = this.List as IBindingListView;
                    if ((objView != null) && objView.SupportsFiltering)
                    {
                        objView.Filter = value;
                    }
                }
            }
        }

        private string InnerListSort
        {
            get
            {
                ListSortDescriptionCollection objCollection1 = null;
                IBindingListView objView = this.List as IBindingListView;
                IBindingList objList = this.List as IBindingList;
                if ((objView != null) && objView.SupportsAdvancedSorting)
                {
                    objCollection1 = objView.SortDescriptions;
                }
                else if (((objList != null) && objList.SupportsSorting) && objList.IsSorted)
                {
                    objCollection1 = new ListSortDescriptionCollection(new ListSortDescription[] { new ListSortDescription(objList.SortProperty, objList.SortDirection) });
                }
                return BindingSource.BuildSortString(objCollection1);
            }
            set
            {
                if ((!this.mblnInitializing && !base.DesignMode) && (string.Compare(value, this.InnerListSort, false, CultureInfo.InvariantCulture) != 0))
                {
                    ListSortDescriptionCollection objCollection1 = this.ParseSortString(value);
                    IBindingListView objView = this.List as IBindingListView;
                    IBindingList objList = this.List as IBindingList;
                    if ((objView != null) && objView.SupportsAdvancedSorting)
                    {
                        if (objCollection1.Count == 0)
                        {
                            objView.RemoveSort();
                        }
                        else
                        {
                            objView.ApplySort(objCollection1);
                        }
                    }
                    else if ((objList != null) && objList.SupportsSorting)
                    {
                        if (objCollection1.Count == 0)
                        {
                            objList.RemoveSort();
                        }
                        else if (objCollection1.Count == 1)
                        {
                            objList.ApplySort(objCollection1[0].PropertyDescriptor, objCollection1[0].SortDirection);
                        }
                    }
                }
            }
        }

        /// <summary>Gets a value indicating whether the list binding is suspended.</summary>
        /// <returns>true to indicate the binding is suspended; otherwise, false. </returns>
        [Browsable(false)]
        public bool IsBindingSuspended
        {
            get
            {
                return this.mobjCurrencyManager.IsBindingSuspended;
            }
        }

        /// <summary>Gets a value indicating whether the underlying list has a fixed size.</summary>
        /// <returns>true if the underlying list has a fixed size; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool IsFixedSize
        {
            get
            {
                return this.List.IsFixedSize;
            }
        }

        /// <summary>Gets a value indicating whether the underlying list is read-only.</summary>
        /// <returns>true if the list is read-only; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool IsReadOnly
        {
            get
            {
                return this.List.IsReadOnly;
            }
        }

        /// <summary>Gets a value indicating whether the items in the underlying list are sorted. </summary>
        /// <returns>true if the list is an <see cref="T:System.ComponentModel.IBindingList"></see> and is sorted; otherwise, false. </returns>
        [Browsable(false)]
        public virtual bool IsSorted
        {
            get
            {
                if (this.mblnIsBindingList)
                {
                    return ((IBindingList)this.List).IsSorted;
                }
                return false;
            }
        }

        /// <summary>Gets a value indicating whether access to the collection is synchronized (thread safe).</summary>
        /// <returns>true to indicate the list is synchronized; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool IsSynchronized
        {
            get
            {
                return this.List.IsSynchronized;
            }
        }

        /// <summary>Gets or sets the list element at the specified index.</summary>
        /// <returns>The element at the specified index.</returns>
        /// <param name="index">The zero-based index of the element to retrieve.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or is equal to or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
        [Browsable(false)]
        public virtual object this[int index]
        {
            get
            {
                return this.List[index];
            }
            set
            {
                this.List[index] = value;
                if (!this.mblnIsBindingList)
                {
                    this.OnSimpleListChanged(ListChangedType.ItemChanged, index);
                }
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
        [Browsable(false), DefaultValue(-1)]
        public int Position
        {
            get
            {
                return this.mobjCurrencyManager.Position;
            }
            set
            {
                if (this.mobjCurrencyManager.Position != value)
                {
                    this.mobjCurrencyManager.Position = value;
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> events should be raised.</summary>
        /// <returns>true if <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> events should be raised; otherwise, false. The default is true.</returns>
        [DefaultValue(true), Browsable(false)]
        public bool RaiseListChangedEvents
        {
            get
            {
                return this.mblnRaiseListChangedEvents;
            }
            set
            {
                if (this.mblnRaiseListChangedEvents != value)
                {
                    this.mblnRaiseListChangedEvents = value;
                }
            }
        }

        /// <summary>Gets or sets the column names used for sorting, and the sort order for viewing the rows in the data source.</summary>
        /// <returns>A case-sensitive string containing the column name followed by "ASC" (for ascending) or "DESC" (for descending). The default is null.</returns>
        [SRDescription("BindingSourceSortDescr"), SRCategory("CatData"), DefaultValue((string)null)]
        public string Sort
        {
            get
            {
                return this.mstrSort;
            }
            set
            {
                this.mstrSort = value;
                this.InnerListSort = value;
            }
        }

        /// <summary>Gets the collection of sort descriptions applied to the data source.</summary>
        /// <returns>If the data source is an <see cref="T:System.ComponentModel.IBindingListView"></see>, a <see cref="T:System.ComponentModel.ListSortDescriptionCollection"></see> that contains the sort descriptions applied to the list; otherwise, null.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public virtual ListSortDescriptionCollection SortDescriptions
        {
            get
            {
                IBindingListView objView = this.List as IBindingListView;
                if (objView != null)
                {
                    return objView.SortDescriptions;
                }
                return null;
            }
        }

        /// <summary>Gets the direction the items in the list are sorted.</summary>
        /// <returns>One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values indicating the direction the list is sorted.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ListSortDirection SortDirection
        {
            get
            {
                if (this.mblnIsBindingList)
                {
                    return ((IBindingList)this.List).SortDirection;
                }
                return ListSortDirection.Ascending;
            }
        }

        /// <summary>Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting the list.</summary>
        /// <returns>If the list is an <see cref="T:System.ComponentModel.IBindingList"></see>, the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting; otherwise, null.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual PropertyDescriptor SortProperty
        {
            get
            {
                if (this.mblnIsBindingList)
                {
                    return ((IBindingList)this.List).SortProperty;
                }
                return null;
            }
        }

        /// <summary>Gets a value indicating whether the data source supports multi-column sorting.</summary>
        /// <returns>true if the list is an <see cref="T:System.ComponentModel.IBindingListView"></see> and supports multi-column sorting; otherwise, false. </returns>
        [Browsable(false)]
        public virtual bool SupportsAdvancedSorting
        {
            get
            {
                IBindingListView objView = this.List as IBindingListView;
                if (objView != null)
                {
                    return objView.SupportsAdvancedSorting;
                }
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the data source supports change notification.</summary>
        /// <returns>true in all cases.</returns>
        [Browsable(false)]
        public virtual bool SupportsChangeNotification
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets a value indicating whether the data source supports filtering.</summary>
        /// <returns>true if the list is an <see cref="T:System.ComponentModel.IBindingListView"></see> and supports filtering; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool SupportsFiltering
        {
            get
            {
                IBindingListView objView = this.List as IBindingListView;
                if (objView != null)
                {
                    return objView.SupportsFiltering;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets whether the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"/> method.
        /// </summary>
        /// <value></value>
        /// <returns>true if the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"/> method; otherwise, false.
        /// </returns>
        [Browsable(false)]
        public virtual bool SupportsSearching
        {
            get
            {
                if (this.mblnIsBindingList)
                {
                    return ((IBindingList)this.List).SupportsSearching;
                }
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the data source supports sorting.</summary>
        /// <returns>true if the data source is an <see cref="T:System.ComponentModel.IBindingList"></see> and supports sorting; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool SupportsSorting
        {
            get
            {
                if (this.mblnIsBindingList)
                {
                    return ((IBindingList)this.List).SupportsSorting;
                }
                return false;
            }
        }

        /// <summary>Gets an object that can be used to synchronize access to the underlying list.</summary>
        /// <returns>An object that can be used to synchronize access to the underlying list.</returns>
        [Browsable(false)]
        public virtual object SyncRoot
        {
            get
            {
                return this.List.SyncRoot;
            }
        }

        bool ISupportInitializeNotification.IsInitialized
        {
            get
            {
                return !this.mblnInitializing;
            }
        }

        #endregion Properties

        #region Events

        /// <summary>Occurs before an item is added to the underlying list.</summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.ComponentModel.AddingNewEventArgs.NewObject"></see> is not the same type as the type contained in the list.</exception>
        [SRDescription("BindingSourceAddingNewEventHandlerDescr"), SRCategory("CatData")]
        public event AddingNewEventHandler AddingNew
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_ADDINGNEW, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_ADDINGNEW, value);
            }
        }
        /// <summary>Occurs when all the clients have been bound to this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        [SRCategory("CatData"), SRDescription("BindingSourceBindingCompleteEventHandlerDescr")]
        public event BindingCompleteEventHandler BindingComplete
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_BINDINGCOMPLETE, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_BINDINGCOMPLETE, value);
            }
        }
        /// <summary>Occurs when the currently bound item changes.</summary>
        [SRCategory("CatData"), SRDescription("BindingSourceCurrentChangedEventHandlerDescr")]
        public event EventHandler CurrentChanged
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_CURRENTCHANGED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_CURRENTCHANGED, value);
            }
        }
        /// <summary>Occurs when a property value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Current"></see> property has changed.</summary>
        [SRDescription("BindingSourceCurrentItemChangedEventHandlerDescr"), SRCategory("CatData")]
        public event EventHandler CurrentItemChanged
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_CURRENTITEMCHANGED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_CURRENTITEMCHANGED, value);
            }
        }
        /// <summary>Occurs when a currency-related exception is silently handled by the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        [SRCategory("CatData"), SRDescription("BindingSourceDataErrorEventHandlerDescr")]
        public event BindingManagerDataErrorEventHandler DataError
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_DATAERROR, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_DATAERROR, value);
            }
        }
        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataMember"></see> property value has changed.</summary>
        [SRCategory("CatData"), SRDescription("BindingSourceDataMemberChangedEventHandlerDescr")]
        public event EventHandler DataMemberChanged
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_DATAMEMBERCHANGED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_DATAMEMBERCHANGED, value);
            }
        }
        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataSource"></see> property value has changed.</summary>
        [SRDescription("BindingSourceDataSourceChangedEventHandlerDescr"), SRCategory("CatData")]
        public event EventHandler DataSourceChanged
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_DATASOURCECHANGED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_DATASOURCECHANGED, value);
            }
        }
        /// <summary>Occurs when the underlying list changes or an item in the list changes.</summary>
        [SRCategory("CatData"), SRDescription("BindingSourceListChangedEventHandlerDescr")]
        public event ListChangedEventHandler ListChanged
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_LISTCHANGED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_LISTCHANGED, value);
            }
        }
        /// <summary>Occurs after the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Position"></see> property has changed.</summary>
        [SRCategory("CatData"), SRDescription("BindingSourcePositionChangedEventHandlerDescr")]
        public event EventHandler PositionChanged
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_POSITIONCHANGED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_POSITIONCHANGED, value);
            }
        }

        event EventHandler ISupportInitializeNotification.Initialized
        {
            add
            {
                this.AddHandler(BindingSource.EVENT_INITIALIZED, value);
            }
            remove
            {
                this.RemoveHandler(BindingSource.EVENT_INITIALIZED, value);
            }
        }

        #endregion Events

    #endregion
    }
}
