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
	/// Displays a combo box in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(DataGridViewComboBoxCellSkin))]
	public class DataGridViewComboBoxCell : DataGridViewCell
	{
		[Serializable]
		private sealed class ItemComparer : IComparer
		{
			private DataGridViewComboBoxCell dataGridViewComboBoxCell;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ItemComparer" /> class.
			/// </summary>
			/// <param name="objDataGridViewComboBoxCell">The data grid view combo box cell.</param>
			public ItemComparer(DataGridViewComboBoxCell objDataGridViewComboBoxCell)
			{
				dataGridViewComboBoxCell = objDataGridViewComboBoxCell;
			}

			public int Compare(object objItem1, object objItem2)
			{
				if (objItem1 == null)
				{
					if (objItem2 == null)
					{
						return 0;
					}
					return -1;
				}
				if (objItem2 == null)
				{
					return 1;
				}
				string itemDisplayText = dataGridViewComboBoxCell.GetItemDisplayText(objItem1);
				string itemDisplayText2 = dataGridViewComboBoxCell.GetItemDisplayText(objItem2);
				return Application.CurrentCulture.CompareInfo.Compare(itemDisplayText, itemDisplayText2, CompareOptions.StringSort);
			}
		}

		/// Represents the collection of selection choices in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
		[Serializable]
		[ListBindable(false)]
		public class ObjectCollection : IList, ICollection, IEnumerable
		{
			private IComparer mobjComparer;

			private ArrayList mobjItems;

			private DataGridViewComboBoxCell mobjOwner;

			private IComparer Comparer
			{
				get
				{
					if (mobjComparer == null)
					{
						mobjComparer = new ItemComparer(mobjOwner);
					}
					return mobjComparer;
				}
			}

			/// Gets the number of items in the collection.</summary>
			/// The number of items in the collection.</returns>
			public int Count => InnerArray.Count;

			internal ArrayList InnerArray
			{
				get
				{
					if (mobjItems == null)
					{
						mobjItems = new ArrayList();
					}
					return mobjItems;
				}
			}

			/// Gets a value indicating whether the collection is read-only.</summary>
			/// true if the collection is read-only; otherwise, false.</returns>
			public bool IsReadOnly => false;

			/// Gets or sets the item at the current index location. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> class.</summary>
			/// The <see cref="T:System.Object"></see> stored at the given index.</returns>
			/// <param name="index">The zero-based index of the element to get or set.</param>
			/// <exception cref="T:System.ArgumentException">When setting this property, the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection minus one. </exception>
			/// <exception cref="T:System.InvalidOperationException">When setting this property, the cell is in a shared row.</exception>
			public virtual object this[int index]
			{
				get
				{
					if (index < 0 || index >= InnerArray.Count)
					{
						throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
					}
					return InnerArray[index];
				}
				set
				{
					mobjOwner.CheckNoDataSource();
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					if (index < 0 || index >= InnerArray.Count)
					{
						throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
					}
					InnerArray[index] = value;
					mobjOwner.OnItemsCollectionChanged();
				}
			}

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => this;

			bool IList.IsFixedSize => false;

			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> class.</summary>
			/// <param name="owner">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> that owns the collection.</param>
			public ObjectCollection(DataGridViewComboBoxCell objOwner)
			{
				mobjOwner = objOwner;
			}

			/// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
			/// The position into which the new element was inserted.</returns>
			/// <param name="objItem">An object representing the item to add to the collection.</param>
			/// <exception cref="T:System.ArgumentNullException">item is null.</exception>
			/// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
			public virtual int Add(object objItem)
			{
				mobjOwner.CheckNoDataSource();
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				int result = InnerArray.Add(objItem);
				bool flag = false;
				if (mobjOwner.Sorted)
				{
					try
					{
						InnerArray.Sort(Comparer);
						result = InnerArray.IndexOf(objItem);
						flag = true;
					}
					finally
					{
						if (!flag)
						{
							InnerArray.Remove(objItem);
						}
					}
				}
				mobjOwner.OnItemsCollectionChanged();
				return result;
			}

			/// Adds one or more items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
			/// <param name="arrItems">One or more objects that represent items for the drop-down list.-or-An <see cref="T:System.Array"></see> of <see cref="T:System.Object"></see> values. </param>
			/// <exception cref="T:System.InvalidOperationException">One or more of the items in the items array is null.</exception>
			/// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
			/// <exception cref="T:System.ArgumentNullException">items is null.</exception>
			public virtual void AddRange(params object[] arrItems)
			{
				mobjOwner.CheckNoDataSource();
				AddRangeInternal(arrItems);
				mobjOwner.OnItemsCollectionChanged();
			}

			/// Adds the items of an existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> to the list of items in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
			/// <param name="objValues">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> to load into this collection.</param>
			/// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.InvalidOperationException">One or more of the items in the value collection is null.</exception>
			/// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public void AddRange(ObjectCollection objValues)
			{
				mobjOwner.CheckNoDataSource();
				AddRangeInternal(objValues);
				mobjOwner.OnItemsCollectionChanged();
			}

			internal void AddRangeInternal(ICollection objItems)
			{
				if (objItems == null)
				{
					throw new ArgumentNullException("items");
				}
				foreach (object objItem in objItems)
				{
					if (objItem == null)
					{
						throw new InvalidOperationException(SR.GetString("InvalidNullItemInCollection"));
					}
				}
				InnerArray.AddRange(objItems);
				if (mobjOwner.Sorted)
				{
					InnerArray.Sort(Comparer);
				}
			}

			/// Clears all items from the collection.</summary>
			/// <exception cref="T:System.InvalidOperationException">The collection contains at least one item and the cell is in a shared row.</exception>
			/// <exception cref="T:System.ArgumentException">The collection contains at least one item and the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			public void Clear()
			{
				if (InnerArray.Count > 0)
				{
					mobjOwner.CheckNoDataSource();
					InnerArray.Clear();
					mobjOwner.OnItemsCollectionChanged();
				}
			}

			internal void ClearInternal()
			{
				InnerArray.Clear();
			}

			/// Determines whether the specified item is contained in the collection.</summary>
			/// true if the item is in the collection; otherwise, false.</returns>
			/// <param name="objValue">An object representing the item to locate in the collection.</param>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public bool Contains(object objValue)
			{
				return IndexOf(objValue) != -1;
			}

			/// Copies the entire collection into an existing array of objects at a specified location within the array.</summary>
			/// <param name="intArrayIndex">The index of the element in dest at which to start copying.</param>
			/// <param name="arrDestination">The destination array to which the contents will be copied.</param>
			/// <exception cref="T:System.ArgumentNullException">destination is null.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">arrayIndex is less than 0 or equal to or greater than the length of destination.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> is greater than the available space from arrayIndex to the end of destination.</exception>
			/// <exception cref="T:System.ArgumentException">destination is multidimensional.</exception>
			public void CopyTo(object[] arrDestination, int intArrayIndex)
			{
				int count = InnerArray.Count;
				for (int i = 0; i < count; i++)
				{
					arrDestination[i + intArrayIndex] = InnerArray[i];
				}
			}

			/// Returns an enumerator that can iterate through a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see>.</summary>
			/// An enumerator of type <see cref="T:System.Collections.IEnumerator"></see>.</returns>
			public IEnumerator GetEnumerator()
			{
				return InnerArray.GetEnumerator();
			}

			/// Returns the index of the specified item in the collection.</summary>
			/// The zero-based index of the value parameter if it is found in the collection; otherwise, -1.</returns>
			/// <param name="objValue">An object representing the item to locate in the collection.</param>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public int IndexOf(object objValue)
			{
				if (objValue == null)
				{
					throw new ArgumentNullException("value");
				}
				return InnerArray.IndexOf(objValue);
			}

			/// Inserts an item into the collection at the specified index. </summary>
			/// <param name="objItem">An object representing the item to insert.</param>
			/// <param name="index">The zero-based index at which to place item within an unsorted <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</param>
			/// <exception cref="T:System.ArgumentNullException">item is null.</exception>
			/// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection. </exception>
			/// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
			public void Insert(int index, object objItem)
			{
				mobjOwner.CheckNoDataSource();
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				if (index < 0 || index > InnerArray.Count)
				{
					throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
				}
				if (mobjOwner.Sorted)
				{
					Add(objItem);
					return;
				}
				InnerArray.Insert(index, objItem);
				mobjOwner.OnItemsCollectionChanged();
			}

			/// Removes the specified object from the collection.</summary>
			/// <param name="objValue">An object representing the item to remove from the collection.</param>
			/// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
			public void Remove(object objValue)
			{
				int num = InnerArray.IndexOf(objValue);
				if (num != -1)
				{
					RemoveAt(num);
				}
			}

			/// Removes the object at the specified index.</summary>
			/// <param name="index">The zero-based index of the object to be removed.</param>
			/// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
			/// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection minus one. </exception>
			public void RemoveAt(int index)
			{
				mobjOwner.CheckNoDataSource();
				if (index < 0 || index >= InnerArray.Count)
				{
					throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
				}
				InnerArray.RemoveAt(index);
				mobjOwner.OnItemsCollectionChanged();
			}

			internal void SortInternal()
			{
				InnerArray.Sort(Comparer);
			}

			void ICollection.CopyTo(Array objDestinationArray, int index)
			{
				int count = InnerArray.Count;
				for (int i = 0; i < count; i++)
				{
					objDestinationArray.SetValue(InnerArray[i], i + index);
				}
			}

			int IList.Add(object objItem)
			{
				mobjOwner.CheckNoDataSource();
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				int result = InnerArray.Add(objItem);
				bool flag = false;
				if (mobjOwner.Sorted)
				{
					try
					{
						InnerArray.Sort(Comparer);
						result = InnerArray.IndexOf(objItem);
						flag = true;
					}
					finally
					{
						if (!flag)
						{
							InnerArray.Remove(objItem);
						}
					}
				}
				mobjOwner.OnItemsCollectionChanged();
				return result;
			}
		}

		private byte mobjFlags = 8;

		private static Type mobjDefaultEditType;

		private static Type mobjDefaultFormattedValueType;

		private static Type mobjDefaultValueType;

		private static Type mobjCellType;

		[NonSerialized]
		private PropertyDescriptor mobjValueMember = null;

		private object mobjInternalValueMember = null;

		private int mintMaxDropDownItems = 8;

		private ObjectCollection mobjItems = null;

		private FlatStyle menmFlatStyle = FlatStyle.Standard;

		private int mintDropDownWidth = 1;

		private int mintDisplayStyleForCurrentCellOnly = -1;

		private object mobjInternalDisplayMember = null;

		[NonSerialized]
		private PropertyDescriptor mobjDisplayMember = null;

		private object mobjDataSource = null;

		private object mobjDataManager = null;

		private DataGridViewComboBoxEditingControl menmComboBoxCellEditingComboBox = null;

		private DataGridViewComboBoxColumn mobjTemplateComboBoxColumn;

		private ComboBoxStyle menmDropDownStyle = ComboBoxStyle.DropDownList;

		private static bool mblnMouseInDropDownButtonBounds;

		private static int mintCachedDropDownWidth;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_autoComplete = 8;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_createItemsFromDataSource = 4;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_dataSourceInitializedHookedUp = 16;

		internal const int DATAGRIDVIEWCOMBOBOXCELL_defaultMaxDropDownItems = 8;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_dropDownHookedUp = 32;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_horizontalTextMarginLeft = 0;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_ignoreNextMouseClick = 1;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_margin = 3;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_nonXPTriangleHeight = 4;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_nonXPTriangleWidth = 7;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_sorted = 2;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_verticalTextMarginTopWithoutWrapping = 1;

		private const byte DATAGRIDVIEWCOMBOBOXCELL_verticalTextMarginTopWithWrapping = 0;

		/// 
		/// Gets or sets the drop down style.
		/// </summary>
		/// </value>
		[DefaultValue(ComboBoxStyle.DropDownList)]
		public virtual ComboBoxStyle DropDownStyle
		{
			get
			{
				ComboBoxStyle dropDownStyle = menmDropDownStyle;
				if (dropDownStyle == ComboBoxStyle.DropDownList && base.DataGridView != null && base.ColumnIndex < base.DataGridView.Columns.Count && base.ColumnIndex >= 0 && base.DataGridView.Columns[base.ColumnIndex].CellTemplate != null)
				{
					dropDownStyle = ((DataGridViewComboBoxCell)base.DataGridView.Columns[base.ColumnIndex].CellTemplate).DropDownStyle;
				}
				return dropDownStyle;
			}
			set
			{
				if (menmDropDownStyle != value)
				{
					menmDropDownStyle = value;
					Update();
				}
			}
		}

		/// 
		/// Gets a value indicating whether [support edit mode].
		/// </summary>
		/// true</c> if [support edit mode]; otherwise, false</c>.</value>
		protected override bool SupportEditMode => true;

		/// 
		/// Gets or sets the editing combo box.
		/// </summary>
		/// The editing combo box.</value>
		private DataGridViewComboBoxEditingControl EditingComboBox
		{
			get
			{
				return menmComboBoxCellEditingComboBox;
			}
			set
			{
				if (value != null || menmComboBoxCellEditingComboBox != null)
				{
					menmComboBoxCellEditingComboBox = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the cell will match the characters being entered in the cell with a selection from the drop-down list. </summary>
		/// true if automatic completion is activated; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[DefaultValue(true)]
		public virtual bool AutoComplete
		{
			get
			{
				return (Flags & 8) != 0;
			}
			set
			{
				if (value != AutoComplete)
				{
					if (value)
					{
						Flags |= 8;
					}
					else
					{
						Flags = (byte)(Flags & -9);
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [create items from data source].
		/// </summary>
		/// 
		/// 	true</c> if [create items from data source]; otherwise, false</c>.
		/// </value>
		private bool CreateItemsFromDataSource
		{
			get
			{
				return (Flags & 4) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= 4;
				}
				else
				{
					Flags = (byte)(Flags & -5);
				}
			}
		}

		/// 
		/// Gets or sets the data manager.
		/// </summary>
		/// The data manager.</value>
		private CurrencyManager DataManager
		{
			get
			{
				return GetDataManager(base.DataGridView);
			}
			set
			{
				if (value != null || mobjDataManager != null)
				{
					mobjDataManager = value;
				}
			}
		}

		/// Gets or sets the data source whose data contains the possible selections shown in the drop-down list.</summary>
		/// An <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> that contains a collection of values used to supply data to the drop-down list. The default value is null.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is not null and is not of type <see cref="T:System.Collections.IList"></see> nor <see cref="T:System.ComponentModel.IListSource"></see>.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual object DataSource
		{
			get
			{
				return mobjDataSource;
			}
			set
			{
				if (value != null && !(value is IList) && !(value is IListSource))
				{
					throw new ArgumentException(SR.GetString("BadDataSourceForComplexBinding"));
				}
				if (DataSource == value)
				{
					return;
				}
				DataManager = null;
				UnwireDataSource();
				mobjDataSource = value;
				WireDataSource(value);
				CreateItemsFromDataSource = true;
				mintCachedDropDownWidth = -1;
				try
				{
					InitializeDisplayMemberPropertyDescriptor(DisplayMember);
				}
				catch (Exception objException)
				{
					if (ClientUtils.IsCriticalException(objException))
					{
						throw;
					}
					DisplayMemberInternal = null;
				}
				try
				{
					InitializeValueMemberPropertyDescriptor(ValueMember);
				}
				catch (Exception objException2)
				{
					if (ClientUtils.IsCriticalException(objException2))
					{
						throw;
					}
					ValueMemberInternal = null;
				}
				if (value == null)
				{
					DisplayMemberInternal = null;
					ValueMemberInternal = null;
				}
				if (OwnsEditingComboBox(base.RowIndex))
				{
					InitializeComboBoxText();
				}
				else
				{
					OnCommonChange();
				}
			}
		}

		/// Gets or sets a string that specifies where to gather selections to display in the drop-down list.</summary>
		/// A string specifying the name of a property or column in the data source specified in the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property. The default value is <see cref="F:System.String.Empty"></see>, which indicates that the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DisplayMember"></see> property will not be used.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the specified value when setting this property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue("")]
		public virtual string DisplayMember
		{
			get
			{
				if (mobjInternalDisplayMember == null)
				{
					return string.Empty;
				}
				return (string)mobjInternalDisplayMember;
			}
			set
			{
				DisplayMemberInternal = value;
				if (OwnsEditingComboBox(base.RowIndex))
				{
					InitializeComboBoxText();
				}
				else
				{
					OnCommonChange();
				}
			}
		}

		/// 
		/// Gets or sets the flags.
		/// </summary>
		/// The flags.</value>
		private byte Flags
		{
			get
			{
				return mobjFlags;
			}
			set
			{
				mobjFlags = value;
			}
		}

		/// 
		/// Sets the display member internal.
		/// </summary>
		/// The display member internal.</value>
		private string DisplayMemberInternal
		{
			set
			{
				InitializeDisplayMemberPropertyDescriptor(value);
				if ((value != null && value.Length > 0) || mobjInternalDisplayMember != null)
				{
					mobjInternalDisplayMember = value;
				}
			}
		}

		/// 
		/// Gets or sets the display member property.
		/// </summary>
		/// The display member property.</value>
		private PropertyDescriptor DisplayMemberProperty
		{
			get
			{
				if (mobjDisplayMember == null)
				{
					InitializeDisplayMemberPropertyDescriptor(DisplayMember);
				}
				return mobjDisplayMember;
			}
			set
			{
				if (value != null || mobjDisplayMember != null)
				{
					mobjDisplayMember = value;
				}
			}
		}

		/// Gets or sets a value that determines how the combo box is displayed when it is not in edit mode.</summary>
		/// One of the <see cref="T:System.Windows.Forms.DataGridViewComboBoxDisplayStyle"></see> values. The default is <see cref="F:System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.DataGridViewComboBoxDisplayStyle"></see> value.</exception>
		[DefaultValue(1)]
		public DataGridViewComboBoxDisplayStyle DisplayStyle
		{
			get
			{
				if (mintDisplayStyleForCurrentCellOnly >= 0)
				{
					return (DataGridViewComboBoxDisplayStyle)mintDisplayStyleForCurrentCellOnly;
				}
				return DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewComboBoxDisplayStyle));
				}
				if (value == DisplayStyle)
				{
					return;
				}
				mintDisplayStyleForCurrentCellOnly = (int)value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// Gets or sets a value that determines if the display style only applies to the current cell.</summary>
		/// true if the display style applies only to the current cell; otherwise false. The default is false.</returns>
		[DefaultValue(false)]
		public bool DisplayStyleForCurrentCellOnly
		{
			get
			{
				return mintDisplayStyleForCurrentCellOnly != 0;
			}
			set
			{
				if (value == DisplayStyleForCurrentCellOnly)
				{
					return;
				}
				mintDisplayStyleForCurrentCellOnly = (value ? 1 : 0);
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		/// 
		/// Sets a value indicating whether [display style for current cell only internal].
		/// </summary>
		/// 
		/// 	true</c> if [display style for current cell only internal]; otherwise, false</c>.
		/// </value>
		internal bool DisplayStyleForCurrentCellOnlyInternal
		{
			set
			{
				if (value != DisplayStyleForCurrentCellOnly)
				{
					mintDisplayStyleForCurrentCellOnly = (value ? 1 : 0);
				}
			}
		}

		/// 
		/// Sets the display style internal.
		/// </summary>
		/// The display style internal.</value>
		internal DataGridViewComboBoxDisplayStyle DisplayStyleInternal
		{
			set
			{
				if (value != DisplayStyle)
				{
					mintDisplayStyleForCurrentCellOnly = (int)value;
				}
			}
		}

		/// 
		/// Gets the display type.
		/// </summary>
		/// The display type.</value>
		private Type DisplayType
		{
			get
			{
				if (DisplayMemberProperty != null)
				{
					return DisplayMemberProperty.PropertyType;
				}
				if (ValueMemberProperty != null)
				{
					return ValueMemberProperty.PropertyType;
				}
				return mobjDefaultFormattedValueType;
			}
		}

		/// 
		/// Gets the display type converter.
		/// </summary>
		/// The display type converter.</value>
		private TypeConverter DisplayTypeConverter
		{
			get
			{
				if (base.DataGridView != null)
				{
					return base.DataGridView.GetCachedTypeConverter(DisplayType);
				}
				return TypeDescriptor.GetConverter(DisplayType);
			}
		}

		/// Gets or sets the width of the of the drop-down list portion of a combo box.</summary>
		/// The width, in pixels, of the drop-down list. The default is 1.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value is less than one.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(1)]
		public virtual int DropDownWidth
		{
			get
			{
				return mintDropDownWidth;
			}
			set
			{
				if (value < 1)
				{
					object[] arrArgs = new object[1] { 1.ToString(CultureInfo.CurrentCulture) };
					throw new ArgumentOutOfRangeException("DropDownWidth", value, SR.GetString("DataGridViewComboBoxCell_DropDownWidthOutOfRange", arrArgs));
				}
				mintDropDownWidth = value;
			}
		}

		/// Gets the type of the cell's hosted editing control.</summary>
		/// The <see cref="T:System.Type"></see> of the underlying editing control. This property always returns <see cref="T:System.Windows.Forms.DataGridViewComboBoxEditingControl"></see>.</returns>
		/// 1</filterpriority>
		public override Type EditType => mobjDefaultEditType;

		/// Gets or sets the flat style appearance of the cell.</summary>
		/// One of the <see cref="T:System.Windows.Forms.FlatStyle"></see> values. The default value is <see cref="F:System.Windows.Forms.FlatStyle.Standard"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not a valid <see cref="T:System.Windows.Forms.FlatStyle"></see> value.</exception>
		/// 1</filterpriority>
		[DefaultValue(2)]
		public FlatStyle FlatStyle
		{
			get
			{
				return menmFlatStyle;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(FlatStyle));
				}
				if (value != FlatStyle)
				{
					menmFlatStyle = value;
					OnCommonChange();
				}
			}
		}

		/// 
		/// Sets the flat style internal.
		/// </summary>
		/// The flat style internal.</value>
		internal FlatStyle FlatStyleInternal
		{
			set
			{
				if (value != FlatStyle)
				{
					menmFlatStyle = value;
				}
			}
		}

		/// Gets the class type of the formatted value associated with the cell.</summary>
		/// The type of the cell's formatted value. This property always returns <see cref="T:System.String"></see>.</returns>
		/// 1</filterpriority>
		public override Type FormattedValueType => mobjDefaultFormattedValueType;

		/// 
		/// Gets a value indicating whether this instance has items.
		/// </summary>
		/// true</c> if this instance has items; otherwise, false</c>.</value>
		internal bool HasItems => LocalItems != null;

		/// Gets the objects that represent the selection displayed in the drop-down list. </summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> containing the selection. </returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual ObjectCollection Items => GetItems(base.DataGridView);

		/// 
		/// Gets or sets the local items.
		/// </summary>
		/// The local items.</value>
		private ObjectCollection LocalItems
		{
			get
			{
				return mobjItems;
			}
			set
			{
				mobjItems = value;
			}
		}

		/// Gets or sets the maximum number of items shown in the drop-down list.</summary>
		/// The number of drop-down list items to allow. The minimum is 1 and the maximum is 100; the default is 8.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 1 or greater than 100 when setting this property.</exception>
		/// 1</filterpriority>
		[DefaultValue(8)]
		public virtual int MaxDropDownItems
		{
			get
			{
				int num = mintMaxDropDownItems;
				if (num == -1)
				{
					if (base.DataGridView != null && base.ColumnIndex < base.DataGridView.Columns.Count && base.ColumnIndex >= 0 && base.DataGridView.Columns[base.ColumnIndex].CellTemplate != null)
					{
						num = (mintMaxDropDownItems = ((DataGridViewComboBoxCell)base.DataGridView.Columns[base.ColumnIndex].CellTemplate).MaxDropDownItems);
					}
					if (num == -1)
					{
						num = (mintMaxDropDownItems = 8);
					}
				}
				return num;
			}
			set
			{
				if (value < 1 || value > 100)
				{
					object[] arrArgs = new object[2]
					{
						1.ToString(CultureInfo.CurrentCulture),
						100.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("MaxDropDownItems", value, SR.GetString("DataGridViewComboBoxCell_MaxDropDownItemsOutOfRange", arrArgs));
				}
				mintMaxDropDownItems = value;
			}
		}

		/// 
		/// Gets a value indicating whether [paint XP themes].
		/// </summary>
		/// true</c> if [paint XP themes]; otherwise, false</c>.</value>
		private bool PaintXPThemes => FlatStyle != FlatStyle.Flat && FlatStyle != FlatStyle.Popup;

		/// Gets or sets a value indicating whether the items in the combo box are automatically sorted.</summary>
		/// true if the combo box is sorted; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.ArgumentException">An attempt was made to sort a cell that is attached to a data source.</exception>
		/// 1</filterpriority>
		[DefaultValue(false)]
		public virtual bool Sorted
		{
			get
			{
				return (Flags & 2) != 0;
			}
			set
			{
				if (value == Sorted)
				{
					return;
				}
				if (value)
				{
					if (DataSource != null)
					{
						throw new ArgumentException(SR.GetString("ComboBoxSortWithDataSource"));
					}
					Items.SortInternal();
					Flags |= 2;
				}
				else
				{
					Flags = (byte)(Flags & -3);
				}
			}
		}

		/// 
		/// Gets or sets the template combo box column.
		/// </summary>
		/// The template combo box column.</value>
		internal DataGridViewComboBoxColumn TemplateComboBoxColumn
		{
			get
			{
				return mobjTemplateComboBoxColumn;
			}
			set
			{
				mobjTemplateComboBoxColumn = value;
			}
		}

		/// Gets or sets a string that specifies where to gather the underlying values used in the drop-down list.</summary>
		/// A string specifying the name of a property or column. The default value is <see cref="F:System.String.Empty"></see>, which indicates that this property is ignored.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the specified value when setting this property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue("")]
		public virtual string ValueMember
		{
			get
			{
				if (mobjInternalValueMember == null)
				{
					return string.Empty;
				}
				return mobjInternalValueMember as string;
			}
			set
			{
				ValueMemberInternal = value;
				if (OwnsEditingComboBox(base.RowIndex))
				{
					InitializeComboBoxText();
				}
				else
				{
					OnCommonChange();
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance has a custom drop down.
		/// </summary>
		/// 
		/// 	true</c> if this instance has a custom drop down; otherwise, false</c>.
		/// </value>
		protected virtual bool IsCustomDropDown => false;

		/// 
		/// Gets a value indicating whether [owning column has items].
		/// </summary>
		/// 
		/// 	true</c> if [owning column has items]; otherwise, false</c>.
		/// </value>
		private bool OwningColumnHasItems => base.ColumnIndex != -1 && base.DataGridView != null && base.DataGridView.Columns[base.ColumnIndex] != null && base.DataGridView.Columns[base.ColumnIndex] is DataGridViewComboBoxColumn && ((DataGridViewComboBoxColumn)base.DataGridView.Columns[base.ColumnIndex]).Items.Count > 0;

		/// 
		/// Gets a value indicating whether [sholud render combobox items].
		/// </summary>
		/// 
		/// 	true</c> if [sholud render combobox items]; otherwise, false</c>.
		/// </value>
		private bool SholudRenderComboboxItems
		{
			get
			{
				ObjectCollection objectCollection = LocalItems;
				bool flag = objectCollection != null && objectCollection.Count > 0;
				if (!flag && TemplateComboBoxColumn != null)
				{
					objectCollection = GetItems(TemplateComboBoxColumn.DataGridView);
					flag = objectCollection != null && objectCollection.Count > 0;
				}
				return flag && (base.ColumnIndex == -1 || !CollectionsEquals(objectCollection, ((DataGridViewComboBoxColumn)base.DataGridView.Columns[base.ColumnIndex]).Items)) && !IsCustomDropDown;
			}
		}

		/// 
		/// Sets the value member internal.
		/// </summary>
		/// The value member internal.</value>
		private string ValueMemberInternal
		{
			set
			{
				InitializeValueMemberPropertyDescriptor(value);
				if ((value != null && value.Length > 0) || mobjInternalValueMember != null)
				{
					mobjInternalValueMember = value;
				}
			}
		}

		/// 
		/// Gets or sets the value member property.
		/// </summary>
		/// The value member property.</value>
		private PropertyDescriptor ValueMemberProperty
		{
			get
			{
				if (mobjValueMember == null)
				{
					InitializeValueMemberPropertyDescriptor(ValueMember);
				}
				return mobjValueMember;
			}
			set
			{
				if (value != null || mobjValueMember != null)
				{
					mobjValueMember = value;
				}
			}
		}

		/// 
		/// Gets or sets the data type of the values in the cell.
		/// </summary>
		/// </value>
		/// A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
		public override Type ValueType
		{
			get
			{
				if (ValueMemberProperty != null)
				{
					return ValueMemberProperty.PropertyType;
				}
				if (DisplayMemberProperty != null)
				{
					return DisplayMemberProperty.PropertyType;
				}
				Type valueType = base.ValueType;
				if (valueType != null)
				{
					return valueType;
				}
				return mobjDefaultValueType;
			}
		}

		/// 
		/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell" /> class.
		/// </summary>
		static DataGridViewComboBoxCell()
		{
			mobjCellType = typeof(DataGridViewComboBoxCell);
			mblnMouseInDropDownButtonBounds = false;
			mintCachedDropDownWidth = -1;
			mobjDefaultFormattedValueType = typeof(string);
			mobjDefaultEditType = typeof(DataGridViewComboBoxEditingControl);
			mobjDefaultValueType = typeof(object);
			mobjCellType = typeof(DataGridViewComboBoxCell);
			mblnMouseInDropDownButtonBounds = false;
			mintCachedDropDownWidth = -1;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> class.
		/// </summary>
		public DataGridViewComboBoxCell()
		{
		}

		/// Called when the <see cref="P:System.Windows.Forms.DataGridViewElement.DataGridView"></see> property of the cell changes.</summary>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the value of either the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DisplayMember"></see> property or the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.ValueMember"></see> property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
		protected override void OnDataGridViewChanged()
		{
			if (base.DataGridView != null)
			{
				InitializeDisplayMemberPropertyDescriptor(DisplayMember);
				InitializeValueMemberPropertyDescriptor(ValueMember);
			}
			base.OnDataGridViewChanged();
		}

		/// 
		/// Called when the focus moves to a cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
		protected override void OnEnter(int intRowIndex, bool blnThroughMouseClick)
		{
			if (base.DataGridView != null && blnThroughMouseClick && base.DataGridView.EditMode != DataGridViewEditMode.EditOnEnter)
			{
				Flags |= 1;
			}
		}

		/// 
		/// Called when [items collection changed].
		/// </summary>
		private void OnItemsCollectionChanged()
		{
			if (TemplateComboBoxColumn != null)
			{
				TemplateComboBoxColumn.OnItemsCollectionChanged();
			}
			mintCachedDropDownWidth = -1;
			if (OwnsEditingComboBox(base.RowIndex))
			{
				InitializeComboBoxText();
			}
			else
			{
				OnCommonChange();
			}
		}

		/// 
		/// Called when the focus moves from a cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <param name="blnThroughMouseClick">true if a user action moved focus from the cell; false if a programmatic operation moved focus from the cell.</param>
		protected override void OnLeave(int intRowIndex, bool blnThroughMouseClick)
		{
			if (base.DataGridView != null)
			{
				Flags = (byte)(Flags & -2);
			}
		}

		/// Determines if edit mode should be started based on the given key.</summary>
		/// true if edit mode should be started; otherwise, false. </returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
		/// 1</filterpriority>
		public override bool KeyEntersEditMode(KeyEventArgs e)
		{
			return false;
		}

		/// 
		/// Called when the user clicks a mouse button while the pointer is on a cell.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
		protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
		{
		}

		/// 
		/// Called when the mouse pointer moves over a cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		protected override void OnMouseEnter(int intRowIndex)
		{
			if (base.DataGridView != null)
			{
				if (DisplayStyle == DataGridViewComboBoxDisplayStyle.ComboBox && FlatStyle == FlatStyle.Popup)
				{
					base.DataGridView.InvalidateCell(base.ColumnIndex, intRowIndex);
				}
				base.OnMouseEnter(intRowIndex);
			}
		}

		/// 
		/// Called when the mouse pointer leaves the cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		protected override void OnMouseLeave(int intRowIndex)
		{
		}

		/// 
		/// Called when the mouse pointer moves within a cell.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
		protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
		{
		}

		/// 
		/// Ownses the editing combo box.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		private bool OwnsEditingComboBox(int intRowIndex)
		{
			return false;
		}

		/// 
		/// Handles the DropDown event of the ComboBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void ComboBox_DropDown(object sender, EventArgs e)
		{
		}

		/// 
		/// Handles the Disposed event of the DataSource control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DataSource_Disposed(object sender, EventArgs e)
		{
			DataSource = null;
		}

		/// 
		/// Handles the Initialized event of the DataSource control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DataSource_Initialized(object sender, EventArgs e)
		{
			if (DataSource is ISupportInitializeNotification supportInitializeNotification)
			{
				supportInitializeNotification.Initialized -= DataSource_Initialized;
			}
			Flags = (byte)(Flags & -17);
			InitializeDisplayMemberPropertyDescriptor(DisplayMember);
			InitializeValueMemberPropertyDescriptor(ValueMember);
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "ValueChange":
				if (objEvent.Contains("VLB"))
				{
					int num = Convert.ToInt32(objEvent["VLB"]);
					if (num >= 0 && num < Items.Count)
					{
						object objItem = Items[num];
						string itemDisplayText = GetItemDisplayText(objItem);
						SetValue(itemDisplayText, blnClientSource: true);
					}
				}
				break;
			case "TextChange":
				if (objEvent.Contains("VLB"))
				{
					string text = CommonUtils.DecodeText(objEvent["VLB"]);
					if (!string.IsNullOrEmpty(text))
					{
						SetValue(text, blnClientSource: true);
					}
				}
				break;
			case "DropDownWindow":
				GetCustomDropDown()?.ShowPopup(base.DataGridView, this, DialogAlignment.Below);
				break;
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			criticalEventsData.Set("VC");
			return criticalEventsData;
		}

		/// 
		/// Gets the key event captures.
		/// </summary>
		/// </returns>
		protected override KeyCaptures GetKeyEventCaptures()
		{
			KeyCaptures keyEventCaptures = base.GetKeyEventCaptures();
			keyEventCaptures |= KeyCaptures.UpKeyCapture;
			keyEventCaptures |= KeyCaptures.DownKeyCapture;
			keyEventCaptures |= KeyCaptures.LeftKeyCapture;
			keyEventCaptures |= KeyCaptures.RightKeyCapture;
			keyEventCaptures |= KeyCaptures.EndKeyCapture;
			keyEventCaptures |= KeyCaptures.HomeKeyCapture;
			keyEventCaptures |= KeyCaptures.PageDownKeyCapture;
			keyEventCaptures |= KeyCaptures.PageUpKeyCapture;
			return keyEventCaptures | KeyCaptures.EnterKeyCapture;
		}

		/// 
		/// Renders the animation.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderAnimationAttributes(IAttributeWriter objWriter)
		{
			if (base.DataGridView != null && base.DataGridView.DefaultAnimationEnabled)
			{
				objWriter.WriteAttributeString("AN", "1");
			}
		}

		/// 
		/// Renders the cell style attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objCellStyle">The cell style.</param>
		protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
		{
			base.RenderCellStyleAttributes(objWriter, objCellStyle);
			if (objCellStyle != null)
			{
				objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
			}
		}

		/// 
		/// Renders the cell text/value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objFormatedValue">The formated value.</param>
		protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
		{
			base.RenderCellValue(objContext, objWriter, objFormatedValue);
			object obj = null;
			object value = base.Value;
			if (value != null && value.ToString() != string.Empty)
			{
				obj = GetComboBoxItem(value);
				if (obj != null)
				{
					objWriter.WriteAttributeString("VLB", Items.IndexOf(obj).ToString());
					objWriter.WriteAttributeString("FT", objFormatedValue.ToString());
				}
			}
		}

		/// 
		/// Render the control Attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			objWriter.WriteAttributeString("CSD", "1");
			objWriter.WriteAttributeString("SKA", "0");
			objWriter.WriteAttributeString("MAX", Math.Min(MaxDropDownItems, Items.Count).ToString());
			if (DropDownWidth != 1)
			{
				objWriter.WriteAttributeString("DDW", DropDownWidth.ToString());
			}
			objWriter.WriteAttributeString("ACM", AutoComplete ? "S" : "N");
			objWriter.WriteAttributeString("IAC", AutoComplete ? "1" : "0");
			if (IsCustomDropDown)
			{
				objWriter.WriteAttributeString("CDD", "1");
				RenderCustomComboboxTextValue(objWriter);
			}
			switch (DropDownStyle)
			{
			case ComboBoxStyle.DropDown:
				objWriter.WriteAttributeString("S", "DD");
				break;
			case ComboBoxStyle.DropDownList:
				objWriter.WriteAttributeString("S", "DDL");
				break;
			case ComboBoxStyle.Simple:
				objWriter.WriteAttributeString("S", "S");
				break;
			}
			objWriter.WriteAttributeString("Id", string.Format("{0}_{1}", base.DataGridView.GetProxyPropertyValue("ID", base.DataGridView.ID).ToString(), MemberID));
			if (!SholudRenderComboboxItems && OwningColumnHasItems)
			{
				objWriter.WriteAttributeString("OC", string.Format("{0}_{1}", base.DataGridView.GetProxyPropertyValue("ID", base.DataGridView.ID).ToString(), base.DataGridView.Columns[base.ColumnIndex].MemberIDInternal));
			}
			objWriter.WriteAttributeString("IMH", GetPreferdItemHeight().ToString());
			RenderAnimationAttributes(objWriter);
		}

		/// 
		/// Renders the custom combobox text value.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderCustomComboboxTextValue(IAttributeWriter objWriter)
		{
			if (base.Value != null)
			{
				objWriter.WriteAttributeText("TX", base.Value.ToString());
			}
		}

		/// 
		/// Gets the text from value.
		/// </summary>
		/// <param name="objValue">The obj value.</param>
		/// </returns>
		protected virtual string GetRenderedTextFromValue(object objValue)
		{
			return base.Value.ToString();
		}

		/// 
		/// Renders the combobox items.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		public void RenderComboboxItems(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			if (IsDirty(lngRequestID) && SholudRenderComboboxItems)
			{
				ObjectCollection items = Items;
				if (items == null && TemplateComboBoxColumn != null)
				{
					items = GetItems(TemplateComboBoxColumn.DataGridView);
				}
				objWriter.WriteStartElement("OS");
				objWriter.WriteAttributeString("IDD", "0");
				for (int i = 0; i < items.Count; i++)
				{
					objWriter.WriteStartElement("O");
					objWriter.WriteAttributeString("IX", i.ToString());
					object objItem = items[i];
					string itemDisplayText = GetItemDisplayText(objItem);
					objWriter.WriteAttributeText("TX", itemDisplayText, (TextFilter)5);
					objWriter.WriteEndElement();
				}
				objWriter.WriteEndElement();
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
			RenderComboboxItems(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Gets the custom form to display as drop down
		/// </summary>
		/// </returns>
		protected virtual Form GetCustomDropDown()
		{
			return null;
		}

		/// 
		/// Checks the drop down list.
		/// </summary>
		/// <param name="intX">The x.</param>
		/// <param name="intY">The y.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		private void CheckDropDownList(int intX, int intY, int intRowIndex)
		{
		}

		/// 
		/// Checks the no data source.
		/// </summary>
		private void CheckNoDataSource()
		{
			if (DataSource != null)
			{
				throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
			}
		}

		/// 
		/// Gets the height of the preferd item font.        
		/// </summary>
		/// </returns>
		internal int GetPreferdItemHeight()
		{
			if (base.Skin is ComboBoxSkin comboBoxSkin)
			{
				PaddingValue padding = comboBoxSkin.PopupItemStyle.Padding;
				int num = 0;
				if (padding != null)
				{
					num = padding.Top + padding.Bottom;
				}
				Font objFont = comboBoxSkin.Font;
				if (base.FormattedCellStyle != null)
				{
					Font font = base.FormattedCellStyle.Font;
					if (font != null)
					{
						objFont = font;
					}
				}
				return CommonUtils.GetFontHeight(objFont) + num;
			}
			return 0;
		}

		/// 
		/// Determines whether [is collections equals] [the specified obj collection1].
		/// </summary>
		/// <param name="objCollection1">The obj collection1.</param>
		/// <param name="objCollection2">The obj collection2.</param>
		/// 
		/// 	true</c> if [is collections equals] [the specified obj collection1]; otherwise, false</c>.
		/// </returns>
		protected bool CollectionsEquals(ObjectCollection objCollection1, ObjectCollection objCollection2)
		{
			bool flag = (objCollection1 == null && objCollection2 == null) || (objCollection1 != null && objCollection2 != null);
			if (flag && objCollection1 != null)
			{
				flag = objCollection1.Count == objCollection2.Count;
				if (flag)
				{
					foreach (object item in objCollection1)
					{
						if (!objCollection2.Contains(item))
						{
							flag = false;
							break;
						}
					}
				}
			}
			return flag;
		}

		/// Calculates the preferred size, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
		/// <param name="objConstraintSize">The cell's maximum allowable size.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell.</param>
		protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
		{
			string text = Convert.ToString(GetValue(intRowIndex));
			try
			{
				if (base.Value != null)
				{
					text = GetFormattedValue(base.Value, base.RowIndex, ref objCellStyle, null, null, (DataGridViewDataErrorContexts)0).ToString();
				}
			}
			catch (Exception)
			{
			}
			if (string.IsNullOrEmpty(text))
			{
				text = " ";
			}
			Size preferredSize = base.GetPreferredSize(text, objCellStyle);
			return new Size(Math.Max(preferredSize.Width, 16), preferredSize.Height);
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</returns>
		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewComboBoxCell dataGridViewComboBoxCell = ((!(type == mobjCellType)) ? ((DataGridViewComboBoxCell)Activator.CreateInstance(type)) : new DataGridViewComboBoxCell());
			CloneInternal(dataGridViewComboBoxCell);
			dataGridViewComboBoxCell.DropDownWidth = DropDownWidth;
			dataGridViewComboBoxCell.DropDownStyle = DropDownStyle;
			dataGridViewComboBoxCell.MaxDropDownItems = MaxDropDownItems;
			dataGridViewComboBoxCell.CreateItemsFromDataSource = false;
			dataGridViewComboBoxCell.DataSource = DataSource;
			dataGridViewComboBoxCell.DisplayMember = DisplayMember;
			dataGridViewComboBoxCell.ValueMember = ValueMember;
			if (HasItems && DataSource == null && Items.Count > 0)
			{
				dataGridViewComboBoxCell.Items.AddRangeInternal(Items.InnerArray.ToArray());
			}
			dataGridViewComboBoxCell.AutoComplete = AutoComplete;
			dataGridViewComboBoxCell.Sorted = Sorted;
			dataGridViewComboBoxCell.FlatStyleInternal = FlatStyle;
			dataGridViewComboBoxCell.DisplayStyleInternal = DisplayStyle;
			dataGridViewComboBoxCell.DisplayStyleForCurrentCellOnlyInternal = DisplayStyleForCurrentCellOnly;
			return dataGridViewComboBoxCell;
		}

		/// 
		/// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
		public override void DetachEditingControl()
		{
		}

		private CurrencyManager GetDataManager(DataGridView objDataGridView)
		{
			CurrencyManager currencyManager = (CurrencyManager)mobjDataManager;
			if (currencyManager == null && DataSource != null && objDataGridView != null && objDataGridView.BindingContext != null && DataSource != Convert.DBNull)
			{
				if (DataSource is ISupportInitializeNotification { IsInitialized: false } supportInitializeNotification)
				{
					if ((Flags & 0x10) == 0)
					{
						supportInitializeNotification.Initialized += DataSource_Initialized;
						Flags |= 16;
					}
					return currencyManager;
				}
				currencyManager = (DataManager = (CurrencyManager)objDataGridView.BindingContext[DataSource]);
			}
			return currencyManager;
		}

		/// 
		/// Gets the height of the drop down button.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// </returns>
		private int GetDropDownButtonHeight(Graphics objGraphics, DataGridViewCellStyle objCellStyle)
		{
			return -1;
		}

		/// 
		/// Gets the formatted value of the cell's data.
		/// </summary>
		/// <param name="objValue">The value to be formatted.</param>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
		/// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
		/// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
		/// 
		/// The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
		/// </returns>
		/// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see> for type conversion errors or to type <see cref="T:System.ArgumentException"></see> if value cannot be found in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.Items"></see> collection. </exception>
		protected override object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
		{
			if (objValueTypeConverter == null)
			{
				if (ValueMemberProperty != null)
				{
					objValueTypeConverter = ValueMemberProperty.Converter;
				}
				else if (DisplayMemberProperty != null)
				{
					objValueTypeConverter = DisplayMemberProperty.Converter;
				}
			}
			if (objValue == null || (ValueType != null && !ValueType.IsAssignableFrom(objValue.GetType()) && objValue != DBNull.Value))
			{
				if (objValue == null)
				{
					return base.GetFormattedValue(null, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
				}
				if (base.DataGridView != null)
				{
					DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(new FormatException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), base.ColumnIndex, intRowIndex, enmContext);
					RaiseDataError(e);
					if (e.ThrowException)
					{
						throw e.Exception;
					}
				}
				return base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
			}
			string text = objValue as string;
			if ((DataManager != null && (ValueMemberProperty != null || DisplayMemberProperty != null)) || !string.IsNullOrEmpty(ValueMember) || !string.IsNullOrEmpty(DisplayMember))
			{
				if (!LookupDisplayValue(intRowIndex, objValue, out var objDisplayValue))
				{
					if (objValue == DBNull.Value)
					{
						objDisplayValue = DBNull.Value;
					}
					else if (text != null && string.IsNullOrEmpty(text) && DisplayType == typeof(string))
					{
						objDisplayValue = string.Empty;
					}
					else if (base.DataGridView != null)
					{
						DataGridViewDataErrorEventArgs e2 = new DataGridViewDataErrorEventArgs(new ArgumentException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), base.ColumnIndex, intRowIndex, enmContext);
						RaiseDataError(e2);
						if (e2.ThrowException)
						{
							throw e2.Exception;
						}
						if (OwnsEditingComboBox(intRowIndex))
						{
							base.DataGridView.NotifyCurrentCellDirty(blnDirty: true);
						}
					}
				}
				return base.GetFormattedValue(objDisplayValue, intRowIndex, ref objCellStyle, DisplayTypeConverter, objFormattedValueTypeConverter, enmContext);
			}
			if (!Items.Contains(objValue) && objValue != DBNull.Value && (!(objValue is string) || !string.IsNullOrEmpty(text)) && !IsCustomDropDown)
			{
				if (base.DataGridView != null)
				{
					DataGridViewDataErrorEventArgs e3 = new DataGridViewDataErrorEventArgs(new ArgumentException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), base.ColumnIndex, intRowIndex, enmContext);
					RaiseDataError(e3);
					if (e3.ThrowException)
					{
						throw e3.Exception;
					}
				}
				objValue = ((Items.Count <= 0) ? string.Empty : Items[0]);
			}
			return base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
		}

		/// 
		/// Lookups the display value.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objValue">The value.</param>
		/// <param name="objDisplayValue">The display value.</param>
		/// </returns>
		private bool LookupDisplayValue(int intRowIndex, object objValue, out object objDisplayValue)
		{
			object obj = null;
			obj = ((DisplayMemberProperty == null && ValueMemberProperty == null) ? ItemFromComboBoxItems(intRowIndex, string.IsNullOrEmpty(ValueMember) ? DisplayMember : ValueMember, objValue) : ItemFromComboBoxDataSource((ValueMemberProperty != null) ? ValueMemberProperty : DisplayMemberProperty, objValue));
			if (obj == null)
			{
				objDisplayValue = null;
				return false;
			}
			objDisplayValue = GetItemDisplayValue(obj);
			return true;
		}

		/// 
		/// Gets the item display text.
		/// </summary>
		/// <param name="objItem">The item.</param>
		/// </returns>
		internal string GetItemDisplayText(object objItem)
		{
			object itemDisplayValue = GetItemDisplayValue(objItem);
			if (itemDisplayValue == null)
			{
				return string.Empty;
			}
			return Convert.ToString(itemDisplayValue, CultureInfo.CurrentCulture);
		}

		/// 
		/// Gets the item display value.
		/// </summary>
		/// <param name="objItem">The item.</param>
		/// </returns>
		internal object GetItemDisplayValue(object objItem)
		{
			bool flag = false;
			object result = null;
			if (DisplayMemberProperty != null)
			{
				result = DisplayMemberProperty.GetValue(objItem);
				flag = true;
			}
			else if (ValueMemberProperty != null)
			{
				result = ValueMemberProperty.GetValue(objItem);
				flag = true;
			}
			else if (!CommonUtils.IsNullOrEmpty(DisplayMember))
			{
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(DisplayMember, ignoreCase: true);
				if (propertyDescriptor != null)
				{
					result = propertyDescriptor.GetValue(objItem);
					flag = true;
				}
			}
			else if (!CommonUtils.IsNullOrEmpty(ValueMember))
			{
				PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties(objItem).Find(ValueMember, ignoreCase: true);
				if (propertyDescriptor2 != null)
				{
					result = propertyDescriptor2.GetValue(objItem);
					flag = true;
				}
			}
			if (!flag)
			{
				result = objItem;
			}
			return result;
		}

		/// 
		/// Gets the items.
		/// </summary>
		/// <param name="objDataGridView">The data grid view.</param>
		/// </returns>
		internal ObjectCollection GetItems(DataGridView objDataGridView)
		{
			ObjectCollection objectCollection = LocalItems;
			if (objectCollection == null)
			{
				objectCollection = (LocalItems = CreateObjectCollection());
			}
			if (CreateItemsFromDataSource)
			{
				objectCollection.ClearInternal();
				CurrencyManager dataManager = GetDataManager(objDataGridView);
				if (dataManager != null && dataManager.Count != -1)
				{
					object[] array = new object[dataManager.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = dataManager[i];
					}
					objectCollection.AddRangeInternal(array);
				}
				if (dataManager == null && (Flags & 0x10) != 0)
				{
					return objectCollection;
				}
				CreateItemsFromDataSource = false;
			}
			return objectCollection;
		}

		/// 
		/// Creates the object collection.
		/// </summary>
		/// </returns>
		protected virtual ObjectCollection CreateObjectCollection()
		{
			return new ObjectCollection(this);
		}

		/// 
		/// Gets the combo box item.
		/// </summary>
		/// <param name="objValue">The obj value.</param>
		/// </returns>
		private object GetComboBoxItem(object objValue)
		{
			object obj = null;
			if (ValueMemberProperty != null)
			{
				obj = ItemFromComboBoxDataSource(ValueMemberProperty, objValue);
			}
			else if (DisplayMemberProperty != null)
			{
				obj = ItemFromComboBoxDataSource(DisplayMemberProperty, objValue);
			}
			else
			{
				if (!string.IsNullOrEmpty(ValueMember))
				{
					obj = ItemFromComboBoxItems(base.RowIndex, ValueMember, objValue);
				}
				if (obj == null)
				{
					obj = ItemFromComboBoxItems(base.RowIndex, DisplayMember, objValue);
				}
			}
			return obj;
		}

		/// 
		/// Gets the item value.
		/// </summary>
		/// <param name="objItem">The item.</param>
		/// </returns>
		internal object GetItemValue(object objItem)
		{
			bool flag = false;
			object result = null;
			if (ValueMemberProperty != null)
			{
				result = ValueMemberProperty.GetValue(objItem);
				flag = true;
			}
			else if (DisplayMemberProperty != null)
			{
				result = DisplayMemberProperty.GetValue(objItem);
				flag = true;
			}
			else if (!CommonUtils.IsNullOrEmpty(ValueMember))
			{
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(ValueMember, ignoreCase: true);
				if (propertyDescriptor != null)
				{
					result = propertyDescriptor.GetValue(objItem);
					flag = true;
				}
			}
			if (!flag && !CommonUtils.IsNullOrEmpty(DisplayMember))
			{
				PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties(objItem).Find(DisplayMember, ignoreCase: true);
				if (propertyDescriptor2 != null)
				{
					result = propertyDescriptor2.GetValue(objItem);
					flag = true;
				}
			}
			if (!flag)
			{
				result = objItem;
			}
			return result;
		}

		/// 
		/// Initializes the combo box text.
		/// </summary>
		private void InitializeComboBoxText()
		{
		}

		/// 
		/// Initializes the display member property descriptor.
		/// </summary>
		/// <param name="strDisplayMember">The display member.</param>
		private void InitializeDisplayMemberPropertyDescriptor(string strDisplayMember)
		{
			if (DataManager == null)
			{
				return;
			}
			if (CommonUtils.IsNullOrEmpty(strDisplayMember))
			{
				DisplayMemberProperty = null;
			}
			else if (base.DataGridView != null)
			{
				BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(strDisplayMember);
				DataManager = base.DataGridView.BindingContext[DataSource, bindingMemberInfo.BindingPath] as CurrencyManager;
				PropertyDescriptor propertyDescriptor = DataManager.GetItemProperties().Find(bindingMemberInfo.BindingField, ignoreCase: true);
				if (propertyDescriptor == null)
				{
					throw new ArgumentException(SR.GetString("DataGridViewComboBoxCell_FieldNotFound", strDisplayMember));
				}
				DisplayMemberProperty = propertyDescriptor;
			}
		}

		/// Attaches and initializes the hosted editing control.</summary>
		/// <param name="objInitialFormattedValue">The initial value to be displayed in the control.</param>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <param name="objDataGridViewCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that determines the appearance of the hosted control.</param>
		/// 1</filterpriority>
		public override void InitializeEditingControl(int intRowIndex, object objInitialFormattedValue, DataGridViewCellStyle objDataGridViewCellStyle)
		{
		}

		/// 
		/// Initializes the value member property descriptor.
		/// </summary>
		/// <param name="strValueMember">The value member.</param>
		private void InitializeValueMemberPropertyDescriptor(string strValueMember)
		{
			if (DataManager == null)
			{
				return;
			}
			if (CommonUtils.IsNullOrEmpty(strValueMember))
			{
				ValueMemberProperty = null;
			}
			else if (base.DataGridView != null)
			{
				BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(strValueMember);
				DataManager = base.DataGridView.BindingContext[DataSource, bindingMemberInfo.BindingPath] as CurrencyManager;
				PropertyDescriptor propertyDescriptor = DataManager.GetItemProperties().Find(bindingMemberInfo.BindingField, ignoreCase: true);
				if (propertyDescriptor == null)
				{
					throw new ArgumentException(SR.GetString("DataGridViewComboBoxCell_FieldNotFound", strValueMember));
				}
				ValueMemberProperty = propertyDescriptor;
			}
		}

		/// 
		/// Items from combo box data source.
		/// </summary>
		/// <param name="objPropertyDescriptor">The property.</param>
		/// <param name="objKey">The key.</param>
		/// </returns>
		private object ItemFromComboBoxDataSource(PropertyDescriptor objPropertyDescriptor, object objKey)
		{
			if (objKey == null)
			{
				throw new ArgumentNullException("key");
			}
			object result = null;
			if (DataManager.List<object> is IBindingList && ((IBindingList)DataManager.List).SupportsSearching)
			{
				int num = ((IBindingList)DataManager.List).Find(objPropertyDescriptor, objKey);
				if (num != -1)
				{
					result = DataManager.List[num];
				}
				return result;
			}
			for (int i = 0; i < DataManager.List.Count; i++)
			{
				object obj = DataManager.List[i];
				object value = objPropertyDescriptor.GetValue(obj);
				if (objKey.Equals(value))
				{
					return obj;
				}
			}
			return result;
		}

		/// 
		/// Items from combo box items.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="strField">The field.</param>
		/// <param name="objKey">The key.</param>
		/// </returns>
		private object ItemFromComboBoxItems(int intRowIndex, string strField, object objKey)
		{
			object obj = null;
			if (OwnsEditingComboBox(intRowIndex))
			{
				obj = EditingComboBox.SelectedItem;
				object obj2 = null;
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(obj).Find(strField, ignoreCase: true);
				if (propertyDescriptor != null)
				{
					obj2 = propertyDescriptor.GetValue(obj);
				}
				if (obj2 == null || !obj2.Equals(objKey))
				{
					obj = null;
				}
			}
			if (obj == null)
			{
				foreach (object item in Items)
				{
					object obj3 = null;
					PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties(item).Find(strField, ignoreCase: true);
					if (propertyDescriptor2 != null)
					{
						obj3 = propertyDescriptor2.GetValue(item);
					}
					if (obj3 != null && obj3.Equals(objKey))
					{
						obj = item;
						break;
					}
				}
			}
			if (obj == null)
			{
				if (OwnsEditingComboBox(intRowIndex))
				{
					obj = EditingComboBox.SelectedItem;
					if (obj == null || !obj.Equals(objKey))
					{
						obj = null;
					}
				}
				if (obj == null && Items.Contains(objKey))
				{
					obj = objKey;
				}
			}
			return obj;
		}

		/// 
		/// Lookups the value.
		/// </summary>
		/// <param name="objFormattedValue">The formatted value.</param>
		/// <param name="objValue">The value.</param>
		/// </returns>
		private bool LookupValue(object objFormattedValue, out object objValue)
		{
			if (objFormattedValue == null)
			{
				objValue = null;
				return true;
			}
			object obj = null;
			obj = ((DisplayMemberProperty == null && ValueMemberProperty == null) ? ItemFromComboBoxItems(base.RowIndex, string.IsNullOrEmpty(DisplayMember) ? ValueMember : DisplayMember, objFormattedValue) : ItemFromComboBoxDataSource((DisplayMemberProperty != null) ? DisplayMemberProperty : ValueMemberProperty, objFormattedValue));
			if (obj == null)
			{
				objValue = null;
				return false;
			}
			objValue = GetItemValue(obj);
			return true;
		}

		/// 
		/// Converts a value formatted for display to an actual cell value.
		/// </summary>
		/// <param name="objFormattedValue">The formatted value.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// <param name="objFormattedValueTypeConverter">The formatted value type converter.</param>
		/// <param name="objValueTypeConverter">The value type converter.</param>
		/// </returns>
		public override object ParseFormattedValue(object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
		{
			if (objValueTypeConverter == null)
			{
				if (ValueMemberProperty != null)
				{
					objValueTypeConverter = ValueMemberProperty.Converter;
				}
				else if (DisplayMemberProperty != null)
				{
					objValueTypeConverter = DisplayMemberProperty.Converter;
				}
			}
			if ((DataManager == null || (DisplayMemberProperty == null && ValueMemberProperty == null)) && CommonUtils.IsNullOrEmpty(DisplayMember) && CommonUtils.IsNullOrEmpty(ValueMember))
			{
				return ParseFormattedValueInternal(ValueType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
			}
			object objValue = ParseFormattedValueInternal(DisplayType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, DisplayTypeConverter);
			object obj = objValue;
			if (LookupValue(obj, out objValue))
			{
				return objValue;
			}
			if (obj != DBNull.Value)
			{
				throw new FormatException(string.Format(CultureInfo.CurrentCulture, SR.GetString("Formatter_CantConvert"), new object[2] { objValue, DisplayType }));
			}
			return DBNull.Value;
		}

		/// 
		/// Returns a string that describes the current object.
		/// </summary>
		/// 
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			return "DataGridViewComboBoxCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
		}

		/// 
		/// Unwires the data source.
		/// </summary>
		private void UnwireDataSource()
		{
			if (DataSource is IComponent component)
			{
				component.Disposed -= DataSource_Disposed;
			}
			if (DataSource is ISupportInitializeNotification supportInitializeNotification && (Flags & 0x10) != 0)
			{
				supportInitializeNotification.Initialized -= DataSource_Initialized;
				Flags = (byte)(Flags & -17);
			}
		}

		/// 
		/// Wires the data source.
		/// </summary>
		/// <param name="objDataSource">The data source.</param>
		private void WireDataSource(object objDataSource)
		{
			if (objDataSource is IComponent component)
			{
				component.Disposed += DataSource_Disposed;
			}
		}
	}
}
