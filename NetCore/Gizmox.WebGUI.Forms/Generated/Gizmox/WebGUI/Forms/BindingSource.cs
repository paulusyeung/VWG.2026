#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// Encapsulates the data source for a form.</summary>
	[Serializable]
	[ToolboxItem(true)]
	[ComplexBindingProperties("DataSource", "DataMember")]
	[SRDescription("DescriptionBindingSource")]
	[DefaultProperty("DataSource")]
	[DefaultEvent("CurrentChanged")]
	[ToolboxBitmap(typeof(BindingSource), "BindingSource_45.bmp")]
	[Designer("Gizmox.WebGUI.Forms.Design.BindingSourceDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ToolboxItemCategory("Data")]
	public class BindingSource : ComponentBase, ICloneable, IBindingListView, IBindingList, IList, ICollection, IEnumerable, ITypedList, ICancelAddNew, ISupportInitializeNotification, ISupportInitialize, ICurrencyManagerProvider
	{
		private static readonly SerializableEvent EVENT_ADDINGNEW;

		private static readonly SerializableEvent EVENT_BINDINGCOMPLETE;

		private static readonly SerializableEvent EVENT_CURRENTCHANGED;

		private static readonly SerializableEvent EVENT_CURRENTITEMCHANGED;

		private static readonly SerializableEvent EVENT_DATAERROR;

		private static readonly SerializableEvent EVENT_DATAMEMBERCHANGED;

		private static readonly SerializableEvent EVENT_DATASOURCECHANGED;

		private static readonly SerializableEvent EVENT_INITIALIZED;

		private static readonly SerializableEvent EVENT_LISTCHANGED;

		private static readonly SerializableEvent EVENT_POSITIONCHANGED;

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

		/// 
		/// Manual serialization interception for 'NewRow' when the data source is a System.Data.DataView.
		/// A 'NewRow' is a row that has not yet been committed to the underlying DataTable, but can have values in one
		/// or more fields. System.Data.DataView is an unserializable type which means 'NewRow' must be manually serialized
		/// and deserialized.
		/// </summary>
		private object[] marrSerializedDataViewNewRowValues;

		/// Gets a value indicating whether items in the underlying list can be edited.</summary>
		/// true to indicate list items can be edited; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool AllowEdit
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).AllowEdit;
				}
				return !List.IsReadOnly;
			}
		}

		/// Gets or sets a value indicating whether the <see cref="M:Gizmox.WebGUI.Forms.BindingSource.AddNew"></see> method can be used to add items to the list.</summary>
		/// true if <see cref="M:Gizmox.WebGUI.Forms.BindingSource.AddNew"></see> can be used to add items to the list; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">This property is set to true when the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property has a fixed size or is read-only.</exception>
		/// <exception cref="T:System.MissingMethodException">The property is set to true and the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.AddingNew"></see> event is not handled when the underlying list type does not have a default constructor.</exception>
		[SRCategory("CatBehavior")]
		[SRDescription("BindingSourceAllowNewDescr")]
		public virtual bool AllowNew
		{
			get
			{
				return AllowNewInternal(blnCheckConstructor: true);
			}
			set
			{
				if (!mblnAllowNewIsSet || value != mblnAllowNewSetValue)
				{
					if (value && !mblnIsBindingList && !IsListWriteable(blnCheckConstructor: false))
					{
						throw new InvalidOperationException(SR.GetString("NoAllowNewOnReadOnlyList"));
					}
					mblnAllowNewIsSet = true;
					mblnAllowNewSetValue = value;
					OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
				}
			}
		}

		/// Gets a value indicating whether items can be removed from the underlying list.</summary>
		/// true to indicate list items can be removed from the list; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool AllowRemove
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).AllowRemove;
				}
				if (!List.IsReadOnly)
				{
					return !List.IsFixedSize;
				}
				return false;
			}
		}

		/// Gets the total number of items in the underlying list.</summary>
		/// The total number of items in the underlying list.</returns>
		[Browsable(false)]
		public virtual int Count
		{
			get
			{
				int count;
				try
				{
					if (mblnDisposedOrFinalized)
					{
						return 0;
					}
					if (mblnRecursionDetectionFlag)
					{
						throw new InvalidOperationException(SR.GetString("BindingSourceRecursionDetected"));
					}
					mblnRecursionDetectionFlag = true;
					count = List.Count;
				}
				finally
				{
					mblnRecursionDetectionFlag = false;
				}
				return count;
			}
		}

		/// Gets the currency manager associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		/// The <see cref="T:CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[Browsable(false)]
		public virtual CurrencyManager CurrencyManager => GetRelatedCurrencyManager(null);

		/// Gets the current item in the list.</summary>
		/// An <see cref="T:System.Object"></see> that represents the current item in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property, or null if the list has no items.</returns>
		[Browsable(false)]
		public object Current
		{
			get
			{
				if (mobjCurrencyManager.Count <= 0)
				{
					return null;
				}
				return mobjCurrencyManager.Current;
			}
		}

		/// Gets or sets the specific list in the data source to which the connector currently binds to.</summary>
		/// The name of a list (or row) in the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataSource"></see>. The default is an empty string ("").</returns>
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("BindingSourceDataMemberDescr")]
		[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[DefaultValue("")]
		[SRCategory("CatData")]
		public string DataMember
		{
			get
			{
				return mstrDataMember;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (!mstrDataMember.Equals(value))
				{
					mstrDataMember = value;
					ResetList();
					OnDataMemberChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets or sets the data source that the connector binds to.</summary>
		/// An <see cref="T:System.Object"></see> that acts as a data source. The default is null.</returns>
		[AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(null)]
		[SRCategory("CatData")]
		[SRDescription("BindingSourceDataSourceDescr")]
		public object DataSource
		{
			get
			{
				return mobjDataSource;
			}
			set
			{
				if (mobjDataSource != value)
				{
					ThrowIfBindingSourceRecursionDetected(value);
					UnwireDataSource();
					mobjDataSource = value;
					ClearInvalidDataMember();
					ResetList();
					WireDataSource();
					OnDataSourceChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets or sets the expression used to filter which rows are viewed.</summary>
		/// A string that specifies how rows are to be filtered. The default is null.</returns>
		[DefaultValue(null)]
		[SRDescription("BindingSourceFilterDescr")]
		[SRCategory("CatData")]
		public virtual string Filter
		{
			get
			{
				return mstrFilter;
			}
			set
			{
				mstrFilter = value;
				InnerListFilter = value;
			}
		}

		private string InnerListFilter
		{
			get
			{
				if (!(List<object> is IBindingListView { SupportsFiltering: not false, Filter: var filter }))
				{
					return string.Empty;
				}
				return filter;
			}
			set
			{
				if (!mblnInitializing && !base.DesignMode && !ClientUtils.IsEquals(value, InnerListFilter, StringComparison.Ordinal) && List<object> is IBindingListView { SupportsFiltering: not false } bindingListView)
				{
					bindingListView.Filter = value;
				}
			}
		}

		private string InnerListSort
		{
			get
			{
				ListSortDescriptionCollection objSortsColln = null;
				IBindingListView bindingListView = List<object> as IBindingListView;
				IBindingList bindingList = List<object> as IBindingList;
				if (bindingListView != null && bindingListView.SupportsAdvancedSorting)
				{
					objSortsColln = bindingListView.SortDescriptions;
				}
				else if (bindingList != null && bindingList.SupportsSorting && bindingList.IsSorted)
				{
					objSortsColln = new ListSortDescriptionCollection(new ListSortDescription[1]
					{
						new ListSortDescription(bindingList.SortProperty, bindingList.SortDirection)
					});
				}
				return BuildSortString(objSortsColln);
			}
			set
			{
				if (mblnInitializing || base.DesignMode || string.Compare(value, InnerListSort, ignoreCase: false, CultureInfo.InvariantCulture) == 0)
				{
					return;
				}
				ListSortDescriptionCollection listSortDescriptionCollection = ParseSortString(value);
				IBindingListView bindingListView = List<object> as IBindingListView;
				IBindingList bindingList = List<object> as IBindingList;
				if (bindingListView != null && bindingListView.SupportsAdvancedSorting)
				{
					if (listSortDescriptionCollection.Count == 0)
					{
						bindingListView.RemoveSort();
					}
					else
					{
						bindingListView.ApplySort(listSortDescriptionCollection);
					}
				}
				else if (bindingList != null && bindingList.SupportsSorting)
				{
					if (listSortDescriptionCollection.Count == 0)
					{
						bindingList.RemoveSort();
					}
					else if (listSortDescriptionCollection.Count == 1)
					{
						bindingList.ApplySort(listSortDescriptionCollection[0].PropertyDescriptor, listSortDescriptionCollection[0].SortDirection);
					}
				}
			}
		}

		/// Gets a value indicating whether the list binding is suspended.</summary>
		/// true to indicate the binding is suspended; otherwise, false. </returns>
		[Browsable(false)]
		public bool IsBindingSuspended => mobjCurrencyManager.IsBindingSuspended;

		/// Gets a value indicating whether the underlying list has a fixed size.</summary>
		/// true if the underlying list has a fixed size; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool IsFixedSize => List.IsFixedSize;

		/// Gets a value indicating whether the underlying list is read-only.</summary>
		/// true if the list is read-only; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool IsReadOnly => List.IsReadOnly;

		/// Gets a value indicating whether the items in the underlying list are sorted. </summary>
		/// true if the list is an <see cref="T:System.ComponentModel.IBindingList"></see> and is sorted; otherwise, false. </returns>
		[Browsable(false)]
		public virtual bool IsSorted
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).IsSorted;
				}
				return false;
			}
		}

		/// Gets a value indicating whether access to the collection is synchronized (thread safe).</summary>
		/// true to indicate the list is synchronized; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool IsSynchronized => List.IsSynchronized;

		/// Gets or sets the list element at the specified index.</summary>
		/// The element at the specified index.</returns>
		/// <param name="index">The zero-based index of the element to retrieve.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or is equal to or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
		[Browsable(false)]
		public virtual object this[int index]
		{
			get
			{
				return List[index];
			}
			set
			{
				List[index] = value;
				if (!mblnIsBindingList)
				{
					OnSimpleListChanged(ListChangedType.ItemChanged, index);
				}
			}
		}

		/// Gets the list that the connector is bound to.</summary>
		/// An <see cref="T:System.Collections.IList"></see> that represents the list, or null if there is no underlying list associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[Browsable(false)]
		public IList List
		{
			get
			{
				EnsureInnerList();
				return mobjInnerList;
			}
		}

		/// Gets or sets the index of the current item in the underlying list.</summary>
		/// A zero-based index that specifies the position of the current item in the underlying list.</returns>
		[Browsable(false)]
		[DefaultValue(-1)]
		public int Position
		{
			get
			{
				return mobjCurrencyManager.Position;
			}
			set
			{
				if (mobjCurrencyManager.Position != value)
				{
					mobjCurrencyManager.Position = value;
				}
			}
		}

		/// Gets or sets a value indicating whether <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> events should be raised.</summary>
		/// true if <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> events should be raised; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		[Browsable(false)]
		public bool RaiseListChangedEvents
		{
			get
			{
				return mblnRaiseListChangedEvents;
			}
			set
			{
				if (mblnRaiseListChangedEvents != value)
				{
					mblnRaiseListChangedEvents = value;
				}
			}
		}

		/// Gets or sets the column names used for sorting, and the sort order for viewing the rows in the data source.</summary>
		/// A case-sensitive string containing the column name followed by "ASC" (for ascending) or "DESC" (for descending). The default is null.</returns>
		[SRDescription("BindingSourceSortDescr")]
		[SRCategory("CatData")]
		[DefaultValue(null)]
		public string Sort
		{
			get
			{
				return mstrSort;
			}
			set
			{
				mstrSort = value;
				InnerListSort = value;
			}
		}

		/// Gets the collection of sort descriptions applied to the data source.</summary>
		/// If the data source is an <see cref="T:System.ComponentModel.IBindingListView"></see>, a <see cref="T:System.ComponentModel.ListSortDescriptionCollection"></see> that contains the sort descriptions applied to the list; otherwise, null.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual ListSortDescriptionCollection SortDescriptions
		{
			get
			{
				if (!(List<object> is IBindingListView { SortDescriptions: var sortDescriptions }))
				{
					return null;
				}
				return sortDescriptions;
			}
		}

		/// Gets the direction the items in the list are sorted.</summary>
		/// One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values indicating the direction the list is sorted.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ListSortDirection SortDirection
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).SortDirection;
				}
				return ListSortDirection.Ascending;
			}
		}

		/// Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting the list.</summary>
		/// If the list is an <see cref="T:System.ComponentModel.IBindingList"></see>, the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting; otherwise, null.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual PropertyDescriptor SortProperty
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).SortProperty;
				}
				return null;
			}
		}

		/// Gets a value indicating whether the data source supports multi-column sorting.</summary>
		/// true if the list is an <see cref="T:System.ComponentModel.IBindingListView"></see> and supports multi-column sorting; otherwise, false. </returns>
		[Browsable(false)]
		public virtual bool SupportsAdvancedSorting
		{
			get
			{
				if (!(List<object> is IBindingListView { SupportsAdvancedSorting: var supportsAdvancedSorting }))
				{
					return false;
				}
				return supportsAdvancedSorting;
			}
		}

		/// Gets a value indicating whether the data source supports change notification.</summary>
		/// true in all cases.</returns>
		[Browsable(false)]
		public virtual bool SupportsChangeNotification => true;

		/// Gets a value indicating whether the data source supports filtering.</summary>
		/// true if the list is an <see cref="T:System.ComponentModel.IBindingListView"></see> and supports filtering; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool SupportsFiltering
		{
			get
			{
				if (!(List<object> is IBindingListView { SupportsFiltering: var supportsFiltering }))
				{
					return false;
				}
				return supportsFiltering;
			}
		}

		/// 
		/// Gets whether the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)" /> method.
		/// </summary>
		/// </value>
		/// true if the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)" /> method; otherwise, false.
		/// </returns>
		[Browsable(false)]
		public virtual bool SupportsSearching
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).SupportsSearching;
				}
				return false;
			}
		}

		/// Gets a value indicating whether the data source supports sorting.</summary>
		/// true if the data source is an <see cref="T:System.ComponentModel.IBindingList"></see> and supports sorting; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool SupportsSorting
		{
			get
			{
				if (mblnIsBindingList)
				{
					return ((IBindingList)List).SupportsSorting;
				}
				return false;
			}
		}

		/// Gets an object that can be used to synchronize access to the underlying list.</summary>
		/// An object that can be used to synchronize access to the underlying list.</returns>
		[Browsable(false)]
		public virtual object SyncRoot => List.SyncRoot;

		bool ISupportInitializeNotification.IsInitialized => !mblnInitializing;

		/// Occurs before an item is added to the underlying list.</summary>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:System.ComponentModel.AddingNewEventArgs.NewObject"></see> is not the same type as the type contained in the list.</exception>
		[SRDescription("BindingSourceAddingNewEventHandlerDescr")]
		[SRCategory("CatData")]
		public event AddingNewEventHandler AddingNew
		{
			add
			{
				AddHandler(EVENT_ADDINGNEW, value);
			}
			remove
			{
				RemoveHandler(EVENT_ADDINGNEW, value);
			}
		}

		/// Occurs when all the clients have been bound to this <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		[SRCategory("CatData")]
		[SRDescription("BindingSourceBindingCompleteEventHandlerDescr")]
		public event BindingCompleteEventHandler BindingComplete
		{
			add
			{
				AddHandler(EVENT_BINDINGCOMPLETE, value);
			}
			remove
			{
				RemoveHandler(EVENT_BINDINGCOMPLETE, value);
			}
		}

		/// Occurs when the currently bound item changes.</summary>
		[SRCategory("CatData")]
		[SRDescription("BindingSourceCurrentChangedEventHandlerDescr")]
		public event EventHandler CurrentChanged
		{
			add
			{
				AddHandler(EVENT_CURRENTCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_CURRENTCHANGED, value);
			}
		}

		/// Occurs when a property value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Current"></see> property has changed.</summary>
		[SRDescription("BindingSourceCurrentItemChangedEventHandlerDescr")]
		[SRCategory("CatData")]
		public event EventHandler CurrentItemChanged
		{
			add
			{
				AddHandler(EVENT_CURRENTITEMCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_CURRENTITEMCHANGED, value);
			}
		}

		/// Occurs when a currency-related exception is silently handled by the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		[SRCategory("CatData")]
		[SRDescription("BindingSourceDataErrorEventHandlerDescr")]
		public event BindingManagerDataErrorEventHandler DataError
		{
			add
			{
				AddHandler(EVENT_DATAERROR, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAERROR, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataMember"></see> property value has changed.</summary>
		[SRCategory("CatData")]
		[SRDescription("BindingSourceDataMemberChangedEventHandlerDescr")]
		public event EventHandler DataMemberChanged
		{
			add
			{
				AddHandler(EVENT_DATAMEMBERCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAMEMBERCHANGED, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.DataSource"></see> property value has changed.</summary>
		[SRDescription("BindingSourceDataSourceChangedEventHandlerDescr")]
		[SRCategory("CatData")]
		public event EventHandler DataSourceChanged
		{
			add
			{
				AddHandler(EVENT_DATASOURCECHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATASOURCECHANGED, value);
			}
		}

		/// Occurs when the underlying list changes or an item in the list changes.</summary>
		[SRCategory("CatData")]
		[SRDescription("BindingSourceListChangedEventHandlerDescr")]
		public event ListChangedEventHandler ListChanged
		{
			add
			{
				AddHandler(EVENT_LISTCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_LISTCHANGED, value);
			}
		}

		/// Occurs after the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Position"></see> property has changed.</summary>
		[SRCategory("CatData")]
		[SRDescription("BindingSourcePositionChangedEventHandlerDescr")]
		public event EventHandler PositionChanged
		{
			add
			{
				AddHandler(EVENT_POSITIONCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_POSITIONCHANGED, value);
			}
		}

		event EventHandler ISupportInitializeNotification.Initialized
		{
			add
			{
				AddHandler(EVENT_INITIALIZED, value);
			}
			remove
			{
				RemoveHandler(EVENT_INITIALIZED, value);
			}
		}

		static BindingSource()
		{
			EVENT_ADDINGNEW = SerializableEvent.Register("EVENT_ADDINGNEW", typeof(Delegate), typeof(BindingSource));
			EVENT_BINDINGCOMPLETE = SerializableEvent.Register("EVENT_BINDINGCOMPLETE", typeof(Delegate), typeof(BindingSource));
			EVENT_CURRENTCHANGED = SerializableEvent.Register("EVENT_CURRENTCHANGED", typeof(Delegate), typeof(BindingSource));
			EVENT_CURRENTITEMCHANGED = SerializableEvent.Register("EVENT_CURRENTITEMCHANGED", typeof(Delegate), typeof(BindingSource));
			EVENT_DATAERROR = SerializableEvent.Register("EVENT_DATAERROR", typeof(Delegate), typeof(BindingSource));
			EVENT_DATAMEMBERCHANGED = SerializableEvent.Register("EVENT_DATAMEMBERCHANGED", typeof(Delegate), typeof(BindingSource));
			EVENT_DATASOURCECHANGED = SerializableEvent.Register("EVENT_DATASOURCECHANGED", typeof(Delegate), typeof(BindingSource));
			EVENT_INITIALIZED = SerializableEvent.Register("EVENT_INITIALIZED", typeof(Delegate), typeof(BindingSource));
			EVENT_LISTCHANGED = SerializableEvent.Register("EVENT_LISTCHANGED", typeof(Delegate), typeof(BindingSource));
			EVENT_POSITIONCHANGED = SerializableEvent.Register("EVENT_POSITIONCHANGED", typeof(Delegate), typeof(BindingSource));
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class to the default property values.</summary>
		public BindingSource()
			: this(null, string.Empty)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class and adds the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to the specified container.</summary>
		/// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to add the current <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to.</param>
		public BindingSource(IContainer objContainer)
			: this()
		{
			objContainer?.Add(this);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> class with the specified data source and data member.</summary>
		/// <param name="objDataSource">The data source for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</param>
		/// <param name="strDataMember">The specific column or list name within the data source to bind to.</param>
		public BindingSource(object objDataSource, string strDataMember)
		{
			InitializeBindingSource(objDataSource, strDataMember);
		}

		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			marrSerializedDataViewNewRowValues = null;
			try
			{
				if (List != null && List.GetType() == typeof(DataView) && Position >= 0 && Position < List.Count && ((DataRowView)this[Position]).IsNew)
				{
					marrSerializedDataViewNewRowValues = ((DataRowView)this[Position]).Row.ItemArray;
				}
			}
			catch
			{
			}
			base.OnSerializableObjectSerializing(objWriter);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			if (mobjDataSource != null)
			{
				bool flag = mblnRaiseListChangedEvents;
				mblnRaiseListChangedEvents = false;
				ResetList();
				mblnRaiseListChangedEvents = flag;
			}
			if (marrSerializedDataViewNewRowValues != null)
			{
				object[] itemArray = marrSerializedDataViewNewRowValues;
				marrSerializedDataViewNewRowValues = null;
				UnwireDataSource();
				UnwireInnerList();
				if (List.GetType() == typeof(DataView))
				{
					DataRowView dataRowView = ((DataView)List).AddNew();
					dataRowView.Row.ItemArray = itemArray;
				}
				WireInnerList();
				WireDataSource();
				marrSerializedDataViewNewRowValues = null;
			}
		}

		/// 
		/// Initializes the binding source.
		/// </summary>
		/// <param name="objDataSource">The obj data source.</param>
		/// <param name="strDataMember">The STR data member.</param>
		private void InitializeBindingSource(object objDataSource, string strDataMember)
		{
			mstrDataMember = string.Empty;
			mblnRaiseListChangedEvents = true;
			mblnAllowNewSetValue = true;
			mintAddNewPos = -1;
			mobjDataSource = objDataSource;
			mstrDataMember = strDataMember;
			mobjInnerList = new ArrayList();
			mobjCurrencyManager = new CurrencyManager(this);
			WireCurrencyManager(mobjCurrencyManager);
			ResetList();
			mobjListItemPropertyChangedHandler = ListItem_PropertyChanged;
			WireDataSource();
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingSource" /> class.
		/// </summary>
		/// <param name="objSourceBindingSource">The source of the binding source.</param>
		public BindingSource(BindingSource objSourceBindingSource)
		{
			if (objSourceBindingSource != null)
			{
				InitializeBindingSource(objSourceBindingSource.DataSource, objSourceBindingSource.DataMember);
			}
		}

		private void CurrencyManager_BindingComplete(object sender, BindingCompleteEventArgs e)
		{
			OnBindingComplete(e);
		}

		private void CurrencyManager_CurrentChanged(object sender, EventArgs e)
		{
			OnCurrentChanged(EventArgs.Empty);
		}

		private void CurrencyManager_CurrentItemChanged(object sender, EventArgs e)
		{
			OnCurrentItemChanged(EventArgs.Empty);
		}

		private void CurrencyManager_DataError(object sender, BindingManagerDataErrorEventArgs e)
		{
			OnDataError(e);
		}

		private void CurrencyManager_PositionChanged(object sender, EventArgs e)
		{
			OnPositionChanged(e);
		}

		private void DataSource_Initialized(object sender, EventArgs e)
		{
			if (DataSource is ISupportInitializeNotification supportInitializeNotification)
			{
				supportInitializeNotification.Initialized -= DataSource_Initialized;
			}
			EndInitCore();
		}

		private void InnerList_ListChanged(object sender, ListChangedEventArgs e)
		{
			if (!mblnInnerListChanging)
			{
				try
				{
					mblnInnerListChanging = true;
					OnListChanged(e);
				}
				finally
				{
					mblnInnerListChanging = false;
				}
			}
		}

		private void ListItem_PropertyChanged(object sender, EventArgs e)
		{
			int newIndex = ((sender != mobjCurrentItemHookedForItemChange) ? IndexOf(sender) : Position);
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, newIndex));
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.AddingNew"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		internal virtual void OnAddingNew(AddingNewEventArgs e)
		{
			((AddingNewEventHandler)GetHandler(EVENT_ADDINGNEW))?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.BindingComplete"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
		protected virtual void OnBindingComplete(BindingCompleteEventArgs e)
		{
			((BindingCompleteEventHandler)GetHandler(EVENT_BINDINGCOMPLETE))?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:CurrentChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCurrentChanged(EventArgs e)
		{
			UnhookItemChangedEventsForOldCurrent();
			HookItemChangedEventsForNewCurrent();
			((EventHandler)GetHandler(EVENT_CURRENTCHANGED))?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.CurrentItemChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnCurrentItemChanged(EventArgs e)
		{
			((EventHandler)GetHandler(EVENT_CURRENTITEMCHANGED))?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataError"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.BindingManagerDataErrorEventArgs"></see> that contains the event data. </param>
		protected virtual void OnDataError(BindingManagerDataErrorEventArgs e)
		{
			if (GetHandler(EVENT_DATAERROR) is BindingManagerDataErrorEventHandler bindingManagerDataErrorEventHandler)
			{
				bindingManagerDataErrorEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataMemberChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnDataMemberChanged(EventArgs e)
		{
			if (GetHandler(EVENT_DATAMEMBERCHANGED) is EventHandler eventHandler)
			{
				eventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.DataSourceChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnDataSourceChanged(EventArgs e)
		{
			if (GetHandler(EVENT_DATASOURCECHANGED) is EventHandler eventHandler)
			{
				eventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.ListChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnListChanged(ListChangedEventArgs e)
		{
			if (mblnRaiseListChangedEvents && !mblnInitializing)
			{
				((ListChangedEventHandler)GetHandler(EVENT_LISTCHANGED))?.Invoke(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingSource.PositionChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.ListChangedEventArgs"></see> that contains the event data.</param>
		protected virtual void OnPositionChanged(EventArgs e)
		{
			((EventHandler)GetHandler(EVENT_POSITIONCHANGED))?.Invoke(this, e);
		}

		private void OnSimpleListChanged(ListChangedType enmListChangedType, int intNewIndex)
		{
			if (!mblnIsBindingList)
			{
				OnListChanged(new ListChangedEventArgs(enmListChangedType, intNewIndex));
			}
		}

		private void ParentCurrencyManager_CurrentItemChanged(object sender, EventArgs e)
		{
			if (mblnInitializing || mblnParentsCurrentItemChanging)
			{
				return;
			}
			try
			{
				mblnParentsCurrentItemChanging = true;
				mobjCurrencyManager.PullData(out var _);
			}
			finally
			{
				mblnParentsCurrentItemChanging = false;
			}
			CurrencyManager currencyManager = (CurrencyManager)sender;
			bool flag = true;
			if (!CommonUtils.IsNullOrEmpty(mstrDataMember))
			{
				object obj = null;
				IList list = null;
				if (currencyManager.Count > 0)
				{
					PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
					PropertyDescriptor propertyDescriptor = itemProperties[mstrDataMember];
					if (propertyDescriptor != null)
					{
						obj = ListBindingHelper.GetList(propertyDescriptor.GetValue(currencyManager.Current));
						list = obj as IList;
					}
				}
				if (list != null)
				{
					SetList(list, blnMetaDataChanged: false, blnApplySortAndFilter: true);
				}
				else if (obj != null)
				{
					SetList(WrapObjectInBindingList(obj), blnMetaDataChanged: false, blnApplySortAndFilter: false);
				}
				else
				{
					SetList(CreateBindingList(mobjItemType), blnMetaDataChanged: false, blnApplySortAndFilter: false);
				}
				flag = mobjLastCurrentItem == null || currencyManager.Count == 0 || mobjLastCurrentItem != currencyManager.Current || Position >= Count;
				mobjLastCurrentItem = ((currencyManager.Count > 0) ? currencyManager.Current : null);
				if (flag)
				{
					Position = ((Count <= 0) ? (-1) : 0);
				}
			}
			OnCurrentItemChanged(EventArgs.Empty);
		}

		private void ParentCurrencyManager_MetaDataChanged(object sender, EventArgs e)
		{
			ClearInvalidDataMember();
			ResetList();
		}

		/// 
		/// Ensures the item shape.
		/// </summary>
		private void EnsureItemShape()
		{
			if (mblnItemShape && mobjItemShape == null)
			{
				mobjItemShape = ListBindingHelper.GetListItemProperties(List);
			}
		}

		/// Adds an existing item to the internal list.</summary>
		/// The zero-based index at which value was added to the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. </returns>
		/// <param name="objValue">An <see cref="T:System.Object"></see> to be added to the internal list.</param>
		/// <exception cref="T:System.InvalidOperationException">value differs in type from the existing items in the underlying list.</exception>
		public virtual int Add(object objValue)
		{
			int num = -1;
			if (mobjDataSource == null && List.Count == 0)
			{
				SetList(CreateBindingList((objValue == null) ? typeof(object) : objValue.GetType()), blnMetaDataChanged: true, blnApplySortAndFilter: true);
			}
			if (objValue != null && !mobjItemType.IsAssignableFrom(objValue.GetType()))
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceItemTypeMismatchOnAdd"));
			}
			if (objValue == null && mobjItemType.IsValueType)
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceItemTypeIsValueType"));
			}
			num = List.Add(objValue);
			OnSimpleListChanged(ListChangedType.ItemAdded, num);
			return num;
		}

		private object AddNewMono()
		{
			if (!AllowNewInternal(blnCheckConstructor: false))
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperAddToReadOnlyList"));
			}
			if (!AllowNewInternal(blnCheckConstructor: true))
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedToSetAllowNew", (mobjItemType == null) ? "(null)" : mobjItemType.FullName));
			}
			int num = mintAddNewPos;
			EndEdit();
			if (num != -1)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, num));
			}
			int count = List.Count;
			object obj = null;
			if (obj == null)
			{
				if (mblnIsBindingList)
				{
					obj = (List<object> as IBindingList).AddNew();
					Position = Count - 1;
					return obj;
				}
				if (mobjItemConstructor == null)
				{
					throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedAParameterlessConstructor", (mobjItemType == null) ? "(null)" : mobjItemType.FullName));
				}
				obj = mobjItemConstructor.Invoke(null);
			}
			if (List.Count > count)
			{
				mintAddNewPos = Position;
				return obj;
			}
			mintAddNewPos = Add(obj);
			Position = mintAddNewPos;
			return obj;
		}

		private object AddNewNonMono()
		{
			if (!AllowNewInternal(blnCheckConstructor: false))
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperAddToReadOnlyList"));
			}
			if (!AllowNewInternal(blnCheckConstructor: true))
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedToSetAllowNew", (mobjItemType == null) ? "(null)" : mobjItemType.FullName));
			}
			int num = mintAddNewPos;
			EndEdit();
			if (num != -1)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, num));
			}
			AddingNewEventArgs e = new AddingNewEventArgs();
			int count = List.Count;
			OnAddingNew(e);
			object obj = e.NewObject;
			if (obj == null)
			{
				if (mblnIsBindingList)
				{
					obj = (List<object> as IBindingList).AddNew();
					Position = Count - 1;
					return obj;
				}
				if (mobjItemConstructor == null)
				{
					throw new InvalidOperationException(SR.GetString("BindingSourceBindingListWrapperNeedAParameterlessConstructor", (mobjItemType == null) ? "(null)" : mobjItemType.FullName));
				}
				obj = mobjItemConstructor.Invoke(null);
			}
			if (List.Count > count)
			{
				mintAddNewPos = Position;
				return obj;
			}
			mintAddNewPos = Add(obj);
			Position = mintAddNewPos;
			return obj;
		}

		/// Adds a new item to the underlying list.</summary>
		/// The <see cref="T:System.Object"></see> that was created and added to the list.</returns>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowNew"></see> property is set to false. -or-A public default constructor could not be found for the current item type.</exception>
		public virtual object AddNew()
		{
			if (!base.DesignMode)
			{
				if (CommonUtils.IsMono)
				{
					return AddNewMono();
				}
				return AddNewNonMono();
			}
			return null;
		}

		private bool AllowNewInternal(bool blnCheckConstructor)
		{
			if (mblnDisposedOrFinalized)
			{
				return false;
			}
			if (mblnAllowNewIsSet)
			{
				return mblnAllowNewSetValue;
			}
			if (mblnListExtractedFromEnumerable)
			{
				return false;
			}
			if (mblnIsBindingList)
			{
				return ((IBindingList)List).AllowNew;
			}
			return IsListWriteable(blnCheckConstructor);
		}

		/// Sorts the data source with the specified sort descriptions.</summary>
		/// <param name="objSortsCollection">A <see cref="T:System.ComponentModel.ListSortDescriptionCollection"></see> containing the sort descriptions to apply to the data source.</param>
		/// <exception cref="T:System.NotSupportedException">The data source is not an <see cref="T:System.ComponentModel.IBindingListView"></see>.</exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ApplySort(ListSortDescriptionCollection objSortsCollection)
		{
			if (!(List<object> is IBindingListView bindingListView))
			{
				throw new NotSupportedException(SR.GetString("OperationRequiresIBindingListView"));
			}
			bindingListView.ApplySort(objSortsCollection);
		}

		/// Sorts the data source using the specified property descriptor and sort direction.</summary>
		/// <param name="enmSortDirection">A <see cref="T:System.ComponentModel.ListSortDirection"></see> indicating how the list should be sorted.</param>
		/// <param name="objPropertyDescriptor">A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that describes the property by which to sort the data source.</param>
		/// <exception cref="T:System.NotSupportedException">The data source is not an <see cref="T:System.ComponentModel.IBindingList"></see>.</exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ApplySort(PropertyDescriptor objPropertyDescriptor, ListSortDirection enmSortDirection)
		{
			if (!mblnIsBindingList)
			{
				throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
			}
			((IBindingList)List).ApplySort(objPropertyDescriptor, enmSortDirection);
		}

		private static string BuildSortString(ListSortDescriptionCollection objSortsColln)
		{
			if (objSortsColln == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(objSortsColln.Count);
			for (int i = 0; i < objSortsColln.Count; i++)
			{
				stringBuilder.Append(objSortsColln[i].PropertyDescriptor.Name + ((objSortsColln[i].SortDirection == ListSortDirection.Ascending) ? " ASC" : " DESC") + ((i < objSortsColln.Count - 1) ? "," : string.Empty));
			}
			return stringBuilder.ToString();
		}

		/// Cancels the current edit operation.</summary>
		public void CancelEdit()
		{
			mobjCurrencyManager.CancelCurrentEdit();
		}

		/// Removes all elements from the list.</summary>
		public virtual void Clear()
		{
			UnhookItemChangedEventsForOldCurrent();
			List.Clear();
			OnSimpleListChanged(ListChangedType.Reset, -1);
		}

		private void ClearInvalidDataMember()
		{
			if (!IsDataMemberValid())
			{
				mstrDataMember = "";
				OnDataMemberChanged(EventArgs.Empty);
			}
		}

		/// Determines whether an object is an item in the list.</summary>
		/// true if the value parameter is found in the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>; otherwise, false.</returns>
		/// <param name="objValue">The <see cref="T:System.Object"></see> to locate in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. The value can be null. </param>
		public virtual bool Contains(object objValue)
		{
			return List.Contains(objValue);
		}

		/// Copies the contents of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> to the specified array, starting at the specified index value.</summary>
		/// <param name="objArray">The destination array.</param>
		/// <param name="intIndex">The index in the destination array at which to start the copy operation.</param>
		public virtual void CopyTo(Array objArray, int intIndex)
		{
			List.CopyTo(objArray, intIndex);
		}

		private static IList CreateBindingList(Type objType)
		{
			Type objType2 = typeof(BindingList<>).MakeGenericType(objType);
			return (IList)SecurityUtils.SecureCreateInstance(objType2);
		}

		private static object CreateInstanceOfType(Type objType)
		{
			object result = null;
			Exception ex = null;
			try
			{
				result = SecurityUtils.SecureCreateInstance(objType);
			}
			catch (TargetInvocationException ex2)
			{
				ex = ex2;
			}
			catch (MethodAccessException ex3)
			{
				ex = ex3;
			}
			catch (MissingMethodException ex4)
			{
				ex = ex4;
			}
			if (ex != null)
			{
				throw new NotSupportedException(SR.GetString("BindingSourceInstanceError"), ex);
			}
			return result;
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> and optionally releases the managed resources. </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				UnwireDataSource();
				UnwireInnerList();
				UnhookItemChangedEventsForOldCurrent();
				UnwireCurrencyManager(mobjCurrencyManager);
				mobjDataSource = null;
				mstrDataMember = null;
				mobjInnerList = null;
				mblnIsBindingList = false;
				mblnNeedToSetList = true;
				mblnRaiseListChangedEvents = false;
			}
			mblnDisposedOrFinalized = true;
			base.Dispose(blnDisposing);
		}

		/// Applies pending changes to the underlying data source.</summary>
		public void EndEdit()
		{
			if (!mblnEndingEdit)
			{
				try
				{
					mblnEndingEdit = true;
					mobjCurrencyManager.EndCurrentEdit();
				}
				finally
				{
					mblnEndingEdit = false;
				}
			}
		}

		private void EndInitCore()
		{
			mblnInitializing = false;
			EnsureInnerList();
			OnInitialized();
			if (mobjRelatedBindingSources == null)
			{
				return;
			}
			foreach (ISupportInitialize value in mobjRelatedBindingSources.Values)
			{
				value.EndInit();
			}
		}

		private void EnsureInnerList()
		{
			if (!mblnInitializing && mblnNeedToSetList)
			{
				mblnNeedToSetList = false;
				ResetList();
			}
		}

		/// 
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// 
		/// A new object that is a copy of this instance.
		/// </returns>
		public object Clone()
		{
			return new BindingSource(this);
		}

		/// Searches for the index of the item that has the given property descriptor.</summary>
		/// The zero-based index of the item that has the given value for <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.</returns>
		/// <param name="objPropertyDescriptor">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to search for. </param>
		/// <param name="objKey">The value of prop to match. </param>
		/// <exception cref="T:System.NotSupportedException">The underlying list is not of type <see cref="T:System.ComponentModel.IBindingList"></see>.</exception>
		public virtual int Find(PropertyDescriptor objPropertyDescriptor, object objKey)
		{
			if (!mblnIsBindingList)
			{
				throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
			}
			return ((IBindingList)List).Find(objPropertyDescriptor, objKey);
		}

		/// Returns the index of the item in the list with the specified property name and value.</summary>
		/// The zero-based index of the item with the specified property name and value.</returns>
		/// <param name="objKey">The value of the item with the specified propertyName to find.</param>
		/// <param name="strPropertyName">The name of the property to search for.</param>
		/// <exception cref="T:System.ArgumentException">propertyName does not match a property in the list.</exception>
		/// <exception cref="T:System.InvalidOperationException">The underlying list is not a <see cref="T:System.ComponentModel.IBindingList"></see> with searching functionality implemented.</exception>
		public int Find(string strPropertyName, object objKey)
		{
			EnsureItemShape();
			PropertyDescriptor propertyDescriptor = ((mobjItemShape == null) ? null : mobjItemShape.Find(strPropertyName, ignoreCase: true));
			if (propertyDescriptor == null)
			{
				throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", strPropertyName));
			}
			return Find(propertyDescriptor, objKey);
		}

		/// Retrieves an enumerator for the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>.</summary>
		/// An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see>. </returns>
		public virtual IEnumerator GetEnumerator()
		{
			return List.GetEnumerator();
		}

		/// Retrieves an array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects representing the bindable properties of the data source list type.</summary>
		/// An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects that represents the properties on this list type used to bind data.</returns>
		/// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the list as bindable.</param>
		public virtual PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
		{
			object list = ListBindingHelper.GetList(mobjDataSource);
			if (list is ITypedList && !CommonUtils.IsNullOrEmpty(mstrDataMember))
			{
				return ListBindingHelper.GetListItemProperties(list, mstrDataMember, arrListAccessors);
			}
			return ListBindingHelper.GetListItemProperties(List, arrListAccessors);
		}

		private static IList GetListFromEnumerable(IEnumerable objEnumerable)
		{
			IList list = null;
			foreach (object item in objEnumerable)
			{
				if (list == null)
				{
					list = CreateBindingList(item.GetType());
				}
				list.Add(item);
			}
			return list;
		}

		private static IList GetListFromType(Type objType)
		{
			if (typeof(ITypedList).IsAssignableFrom(objType) && typeof(IList).IsAssignableFrom(objType))
			{
				return CreateInstanceOfType(objType) as IList;
			}
			if (typeof(IListSource).IsAssignableFrom(objType))
			{
				return (CreateInstanceOfType(objType) as IListSource).GetList();
			}
			return CreateBindingList(ListBindingHelper.GetListItemType(objType));
		}

		/// Gets the name of the list supplying data for the binding.</summary>
		/// The name of the list supplying the data for binding.</returns>
		/// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the list as bindable.</param>
		public virtual string GetListName(PropertyDescriptor[] arrListAccessors)
		{
			return ListBindingHelper.GetListName(List, arrListAccessors);
		}

		private BindingSource GetRelatedBindingSource(string strDataMember)
		{
			if (mobjRelatedBindingSources == null)
			{
				mobjRelatedBindingSources = new Hashtable();
			}
			foreach (string key in mobjRelatedBindingSources.Keys)
			{
				if (ClientUtils.IsEquals(key, strDataMember, StringComparison.OrdinalIgnoreCase))
				{
					return mobjRelatedBindingSources[key] as BindingSource;
				}
			}
			BindingSource bindingSource = new BindingSource(this, strDataMember);
			mobjRelatedBindingSources[strDataMember] = bindingSource;
			return bindingSource;
		}

		/// Gets the related currency manager for the specified data member.</summary>
		/// The related <see cref="T:CurrencyManager"></see> for the specified data member.</returns>
		/// <param name="strDataMember">The name of column or list, within the data source to retrieve the currency manager for.</param>
		public virtual CurrencyManager GetRelatedCurrencyManager(string strDataMember)
		{
			EnsureInnerList();
			if (CommonUtils.IsNullOrEmpty(strDataMember))
			{
				return mobjCurrencyManager;
			}
			if (strDataMember.IndexOf(".") != -1)
			{
				return null;
			}
			BindingSource relatedBindingSource = GetRelatedBindingSource(strDataMember);
			return relatedBindingSource.CurrencyManager;
		}

		private void HookItemChangedEventsForNewCurrent()
		{
			if (!mblnListRaisesItemChangedEvents)
			{
				if (Position >= 0 && Position <= Count - 1)
				{
					mobjCurrentItemHookedForItemChange = Current;
					WirePropertyChangedEvents(mobjCurrentItemHookedForItemChange);
				}
				else
				{
					mobjCurrentItemHookedForItemChange = null;
				}
			}
		}

		/// Searches for the specified object and returns the index of the first occurrence within the entire list.</summary>
		/// The zero-based index of the first occurrence of the value parameter; otherwise, -1 if value is not in the list.</returns>
		/// <param name="objValue">The <see cref="T:System.Object"></see> to locate in the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property. The value can be null. </param>
		public virtual int IndexOf(object objValue)
		{
			return List.IndexOf(objValue);
		}

		/// Inserts an item into the list at the specified index.</summary>
		/// <param name="objValue">The <see cref="T:System.Object"></see> to insert. The value can be null. </param>
		/// <param name="intIndex">The zero-based index at which value should be inserted. </param>
		/// <exception cref="T:System.NotSupportedException">The list is read-only or has a fixed size.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
		public virtual void Insert(int intIndex, object objValue)
		{
			List.Insert(intIndex, objValue);
			OnSimpleListChanged(ListChangedType.ItemAdded, intIndex);
		}

		private bool IsDataMemberValid()
		{
			if (mblnInitializing)
			{
				return true;
			}
			if (CommonUtils.IsNullOrEmpty(mstrDataMember))
			{
				return true;
			}
			PropertyDescriptorCollection listItemProperties = ListBindingHelper.GetListItemProperties(mobjDataSource);
			if (listItemProperties[mstrDataMember] != null)
			{
				return true;
			}
			return false;
		}

		private bool IsListWriteable(bool blnCheckConstructor)
		{
			if (List.IsReadOnly || List.IsFixedSize)
			{
				return false;
			}
			if (blnCheckConstructor)
			{
				return mobjItemConstructor != null;
			}
			return true;
		}

		/// Moves to the first item in the list.</summary>
		public void MoveFirst()
		{
			Position = 0;
		}

		/// Moves to the last item in the list.</summary>
		public void MoveLast()
		{
			Position = Count - 1;
		}

		/// Moves to the next item in the list.</summary>
		public void MoveNext()
		{
			Position++;
		}

		/// Moves to the previous item in the list.</summary>
		public void MovePrevious()
		{
			Position--;
		}

		private void OnInitialized()
		{
			((EventHandler)GetHandler(EVENT_INITIALIZED))?.Invoke(this, EventArgs.Empty);
		}

		private ListSortDescriptionCollection ParseSortString(string strSortString)
		{
			if (CommonUtils.IsNullOrEmpty(strSortString))
			{
				return new ListSortDescriptionCollection();
			}
			ArrayList arrayList = new ArrayList();
			PropertyDescriptorCollection itemProperties = mobjCurrencyManager.GetItemProperties();
			string[] array = strSortString.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				int length = text.Length;
				bool flag = true;
				if (length >= 5 && string.Compare(text, length - 4, " ASC", 0, 4, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					text = text.Substring(0, length - 4).Trim();
				}
				else if (length >= 6 && string.Compare(text, length - 5, " DESC", 0, 5, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					flag = false;
					text = text.Substring(0, length - 5).Trim();
				}
				if (text.StartsWith("["))
				{
					if (!text.EndsWith("]"))
					{
						throw new ArgumentException(SR.GetString("BindingSourceBadSortString"));
					}
					text = text.Substring(1, text.Length - 2);
				}
				PropertyDescriptor propertyDescriptor = itemProperties.Find(text, ignoreCase: true);
				if (propertyDescriptor == null)
				{
					throw new ArgumentException(SR.GetString("BindingSourceSortStringPropertyNotInIBindingList"));
				}
				arrayList.Add(new ListSortDescription(propertyDescriptor, (!flag) ? ListSortDirection.Descending : ListSortDirection.Ascending));
			}
			ListSortDescription[] array2 = new ListSortDescription[arrayList.Count];
			arrayList.CopyTo(array2);
			return new ListSortDescriptionCollection(array2);
		}

		/// Removes the specified item from the list.</summary>
		/// <param name="objValue">The item to remove from the underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property.</param>
		/// <exception cref="T:System.NotSupportedException">The underlying list has a fixed size or is read-only. </exception>
		public virtual void Remove(object objValue)
		{
			int num = IndexOf(objValue);
			List.Remove(objValue);
			if (num != -1)
			{
				OnSimpleListChanged(ListChangedType.ItemDeleted, num);
			}
		}

		/// Removes the item at the specified index in the list.</summary>
		/// <param name="intIndex">The zero-based index of the item to remove. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see> property.</exception>
		/// <exception cref="T:System.NotSupportedException">The underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property is read-only or has a fixed size.</exception>
		public virtual void RemoveAt(int intIndex)
		{
			object obj = this[intIndex];
			List.RemoveAt(intIndex);
			OnSimpleListChanged(ListChangedType.ItemDeleted, intIndex);
		}

		/// Removes the current item from the list.</summary>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowRemove"></see> property is false.-or-<see cref="P:Gizmox.WebGUI.Forms.BindingSource.Position"></see> is less than zero or greater than <see cref="P:Gizmox.WebGUI.Forms.BindingSource.Count"></see>.</exception>
		/// <exception cref="T:System.NotSupportedException">The underlying list represented by the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.List"></see> property is read-only or has a fixed size.</exception>
		public void RemoveCurrent()
		{
			if (!AllowRemove)
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceRemoveCurrentNotAllowed"));
			}
			if (Position < 0 || Position >= Count)
			{
				throw new InvalidOperationException(SR.GetString("BindingSourceRemoveCurrentNoCurrentItem"));
			}
			RemoveAt(Position);
		}

		/// Removes the filter associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		/// <exception cref="T:System.NotSupportedException">The underlying list does not support filtering.</exception>
		public virtual void RemoveFilter()
		{
			mstrFilter = null;
			if (List<object> is IBindingListView bindingListView)
			{
				bindingListView.RemoveFilter();
			}
		}

		/// Removes the sort associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		/// <exception cref="T:System.NotSupportedException">The underlying list does not support sorting.</exception>
		public virtual void RemoveSort()
		{
			mstrSort = null;
			if (mblnIsBindingList)
			{
				((IBindingList)List).RemoveSort();
			}
		}

		/// Reinitializes the <see cref="P:Gizmox.WebGUI.Forms.BindingSource.AllowNew"></see> property.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual void ResetAllowNew()
		{
			mblnAllowNewIsSet = false;
			mblnAllowNewSetValue = true;
		}

		/// Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread all the items in the list and refresh their displayed values. </summary>
		/// <param name="blnMetadataChanged">true if the data schema has changed; false if only values have changed.</param>
		public void ResetBindings(bool blnMetadataChanged)
		{
			if (blnMetadataChanged)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.PropertyDescriptorChanged, null));
			}
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		/// Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread the currently selected item and refresh its displayed value.</summary>
		public void ResetCurrentItem()
		{
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, Position));
		}

		/// Causes a control bound to the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> to reread the item at the specified index, and refresh its displayed value. </summary>
		/// <param name="intItemIndex">The zero-based index of the item that has changed.</param>
		public void ResetItem(int intItemIndex)
		{
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, intItemIndex));
		}

		private void ResetList()
		{
			if (mblnInitializing)
			{
				mblnNeedToSetList = true;
				return;
			}
			mblnNeedToSetList = false;
			object objDataSource = ((mobjDataSource is Type) ? GetListFromType(mobjDataSource as Type) : mobjDataSource);
			object obj = ListBindingHelper.GetList(objDataSource, mstrDataMember);
			mblnListExtractedFromEnumerable = false;
			if (!(obj is IList))
			{
				if (!(obj is IEnumerable))
				{
					obj = ((obj == null) ? CreateBindingList(ListBindingHelper.GetListItemType(mobjDataSource, mstrDataMember)) : WrapObjectInBindingList(obj));
				}
				else
				{
					obj = GetListFromEnumerable(obj as IEnumerable);
					mblnListExtractedFromEnumerable = true;
				}
			}
			SetList(obj as IList, blnMetaDataChanged: true, blnApplySortAndFilter: true);
		}

		/// Resumes data binding.</summary>
		public void ResumeBinding()
		{
			mobjCurrencyManager.ResumeBinding();
		}

		private void SetList(IList objList, bool blnMetaDataChanged, bool blnApplySortAndFilter)
		{
			if (objList == null)
			{
				objList = CreateBindingList(mobjItemType);
			}
			UnwireInnerList();
			UnhookItemChangedEventsForOldCurrent();
			mobjInnerList = objList;
			mblnIsBindingList = objList is IBindingList;
			if (objList is IRaiseItemChangedEvents)
			{
				mblnListRaisesItemChangedEvents = (objList as IRaiseItemChangedEvents).RaisesItemChangedEvents;
			}
			else if (objList is DataView)
			{
				mblnListRaisesItemChangedEvents = false;
			}
			else
			{
				mblnListRaisesItemChangedEvents = mblnIsBindingList;
			}
			if (blnMetaDataChanged)
			{
				mobjItemType = ListBindingHelper.GetListItemType(List);
				mobjItemShape = ListBindingHelper.GetListItemProperties(List);
				mblnItemShape = mobjItemShape != null;
				mobjItemConstructor = mobjItemType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, new Type[0], null);
			}
			WireInnerList();
			HookItemChangedEventsForNewCurrent();
			ResetBindings(blnMetaDataChanged);
			if (blnApplySortAndFilter)
			{
				if (Sort != null)
				{
					InnerListSort = Sort;
				}
				if (Filter != null)
				{
					InnerListFilter = Filter;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeAllowNew()
		{
			return mblnAllowNewIsSet;
		}

		/// Suspends data binding to prevent changes from updating the bound data source.</summary>
		public void SuspendBinding()
		{
			mobjCurrencyManager.SuspendBinding();
		}

		void IBindingList.AddIndex(PropertyDescriptor objPropertyDescriptor)
		{
			if (!mblnIsBindingList)
			{
				throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
			}
			((IBindingList)List).AddIndex(objPropertyDescriptor);
		}

		void IBindingList.RemoveIndex(PropertyDescriptor objPropertyDescriptor)
		{
			if (!mblnIsBindingList)
			{
				throw new NotSupportedException(SR.GetString("OperationRequiresIBindingList"));
			}
			((IBindingList)List).RemoveIndex(objPropertyDescriptor);
		}

		void ICancelAddNew.CancelNew(int intPosition)
		{
			if (mintAddNewPos >= 0 && mintAddNewPos == intPosition)
			{
				RemoveAt(mintAddNewPos);
				mintAddNewPos = -1;
			}
			else if (List<object> is ICancelAddNew cancelAddNew)
			{
				cancelAddNew.CancelNew(intPosition);
			}
		}

		void ICancelAddNew.EndNew(int intPosition)
		{
			if (mintAddNewPos >= 0 && mintAddNewPos == intPosition)
			{
				mintAddNewPos = -1;
			}
			else if (List<object> is ICancelAddNew cancelAddNew)
			{
				cancelAddNew.EndNew(intPosition);
			}
		}

		void ISupportInitialize.BeginInit()
		{
			mblnInitializing = true;
		}

		void ISupportInitialize.EndInit()
		{
			if (DataSource is ISupportInitializeNotification { IsInitialized: false } supportInitializeNotification)
			{
				supportInitializeNotification.Initialized += DataSource_Initialized;
			}
			else
			{
				EndInitCore();
			}
		}

		private void ThrowIfBindingSourceRecursionDetected(object objNewDataSource)
		{
			for (BindingSource bindingSource = objNewDataSource as BindingSource; bindingSource != null; bindingSource = bindingSource.DataSource as BindingSource)
			{
				if (bindingSource == this)
				{
					throw new InvalidOperationException(SR.GetString("BindingSourceRecursionDetected"));
				}
			}
		}

		private void UnhookItemChangedEventsForOldCurrent()
		{
			if (!mblnListRaisesItemChangedEvents)
			{
				UnwirePropertyChangedEvents(mobjCurrentItemHookedForItemChange);
				mobjCurrentItemHookedForItemChange = null;
			}
		}

		private void UnwireCurrencyManager(CurrencyManager objCurrencyManager)
		{
			if (objCurrencyManager != null)
			{
				objCurrencyManager.PositionChanged -= CurrencyManager_PositionChanged;
				objCurrencyManager.CurrentChanged -= CurrencyManager_CurrentChanged;
				objCurrencyManager.CurrentItemChanged -= CurrencyManager_CurrentItemChanged;
				objCurrencyManager.BindingComplete -= CurrencyManager_BindingComplete;
				objCurrencyManager.DataError -= CurrencyManager_DataError;
			}
		}

		private void UnwireDataSource()
		{
			if (mobjDataSource is ICurrencyManagerProvider)
			{
				CurrencyManager currencyManager = (mobjDataSource as ICurrencyManagerProvider).CurrencyManager;
				currencyManager.CurrentItemChanged -= ParentCurrencyManager_CurrentItemChanged;
				currencyManager.MetaDataChanged -= ParentCurrencyManager_MetaDataChanged;
			}
		}

		private void UnwireInnerList()
		{
			if (mobjInnerList is IBindingList)
			{
				IBindingList bindingList = mobjInnerList as IBindingList;
				bindingList.ListChanged -= InnerList_ListChanged;
			}
		}

		private void UnwirePropertyChangedEvents(object objItem)
		{
			EnsureItemShape();
			if (objItem == null || mobjItemShape == null)
			{
				return;
			}
			for (int i = 0; i < mobjItemShape.Count; i++)
			{
				if (mobjListItemPropertyChangedHandler != null)
				{
					mobjItemShape[i].RemoveValueChanged(objItem, mobjListItemPropertyChangedHandler);
				}
			}
		}

		private void WireCurrencyManager(CurrencyManager objCurrencyManager)
		{
			if (objCurrencyManager != null)
			{
				objCurrencyManager.PositionChanged += CurrencyManager_PositionChanged;
				objCurrencyManager.CurrentChanged += CurrencyManager_CurrentChanged;
				objCurrencyManager.CurrentItemChanged += CurrencyManager_CurrentItemChanged;
				objCurrencyManager.BindingComplete += CurrencyManager_BindingComplete;
				objCurrencyManager.DataError += CurrencyManager_DataError;
			}
		}

		private void WireDataSource()
		{
			if (mobjDataSource is ICurrencyManagerProvider)
			{
				CurrencyManager currencyManager = (mobjDataSource as ICurrencyManagerProvider).CurrencyManager;
				currencyManager.CurrentItemChanged += ParentCurrencyManager_CurrentItemChanged;
				currencyManager.MetaDataChanged += ParentCurrencyManager_MetaDataChanged;
			}
		}

		private void WireInnerList()
		{
			if (mobjInnerList is IBindingList)
			{
				IBindingList bindingList = mobjInnerList as IBindingList;
				bindingList.ListChanged += InnerList_ListChanged;
			}
		}

		private void WirePropertyChangedEvents(object objItem)
		{
			EnsureItemShape();
			if (objItem == null || mobjItemShape == null)
			{
				return;
			}
			for (int i = 0; i < mobjItemShape.Count; i++)
			{
				if (mobjListItemPropertyChangedHandler != null)
				{
					mobjItemShape[i].AddValueChanged(objItem, mobjListItemPropertyChangedHandler);
				}
			}
		}

		private static IList WrapObjectInBindingList(object obj)
		{
			IList list = CreateBindingList(obj.GetType());
			list.Add(obj);
			return list;
		}
	}
}
