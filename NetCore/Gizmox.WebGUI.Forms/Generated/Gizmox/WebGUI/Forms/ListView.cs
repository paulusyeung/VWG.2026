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
/// 
	/// A ListView control.
	/// </summary>
	/// 
	/// The list view control is used to display a list of items.
	/// </remarks>
	[Serializable]
	[ToolboxItem(true)]
	[DefaultEvent("SelectedIndexChanged")]
	[ToolboxItemCategory("Common Controls")]
	[ToolboxBitmap(typeof(ListView), "ListView_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[MetadataTag("LV")]
	[Skin(typeof(ListViewSkin))]
	[ProxyComponent(typeof(ProxyListView))]
	public class ListView : Control, IComparer
	{
		/// 
		/// Provides an implementation for internal list of items for listview control
		/// </summary>
		[Serializable]
		internal class ListViewNativeItemCollection : ListViewItemCollection.IInnerList
		{
			/// 
			/// The internal array list
			/// </summary>
			private ArrayList mobjList;

			/// 
			/// The owning listview
			/// </summary>
			private ListView mobjListView;

			/// 
			/// Gets the list.
			/// </summary>
			/// The list.</value>
			private ArrayList List
			{
				get
				{
					if (mobjList == null)
					{
						mobjList = new ArrayList();
					}
					return mobjList;
				}
			}

			/// 
			/// Gets the count.
			/// </summary>
			/// The count.</value>
			public int Count => List.Count;

			/// 
			/// Gets the list view.
			/// </summary>
			/// The list view.</value>
			public ListView ListView => mobjListView;

			/// 
			/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> with the specified display index.
			/// </summary>
			/// </value>
			public ListViewItem this[int intDisplayIndex]
			{
				get
				{
					return (ListViewItem)List[intDisplayIndex];
				}
				set
				{
					List[intDisplayIndex] = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewNativeItemCollection" /> class.
			/// </summary>
			/// <param name="objListView">The owner list view.</param>
			public ListViewNativeItemCollection(ListView objListView)
			{
				mobjListView = objListView;
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewNativeItemCollection" /> class.
			/// </summary>
			/// <param name="objListView">The owner list view.</param>
			/// <param name="arrItems">The arr items.</param>
			internal ListViewNativeItemCollection(ListView objListView, object[] arrItems)
			{
				mobjListView = objListView;
				mobjList = new ArrayList(arrItems);
			}

			/// 
			/// Adds the specified item.
			/// </summary>
			/// <param name="value">The value.</param>
			/// </returns>
			public ListViewItem Add(ListViewItem value)
			{
				List.Add(value);
				value.InternalListView = mobjListView;
				mobjListView.Update();
				return value;
			}

			/// 
			/// Adds the range.
			/// </summary>
			/// <param name="arrItems">The items.</param>
			public void AddRange(ListViewItem[] arrItems)
			{
				List.AddRange(arrItems);
			}

			/// 
			/// Clears the items.
			/// </summary>
			public void Clear()
			{
				mobjListView.UnRegisterBatch(List);
				mobjListView.SelectedIndex = -1;
				if (mobjListView.UseInternalPaging)
				{
					mobjListView.ClearPaging();
				}
				mobjListView.Update();
				List.Clear();
			}

			/// 
			/// Determines whether [contains] [the specified item].
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// 
			/// 	true</c> if [contains] [the specified item]; otherwise, false</c>.
			/// </returns>
			public bool Contains(ListViewItem objItem)
			{
				return List.Contains(objItem);
			}

			/// 
			/// Copies to.
			/// </summary>
			/// <param name="objDestinationArray">The dest.</param>
			/// <param name="index">The index.</param>
			public void CopyTo(Array objDestinationArray, int index)
			{
				List.CopyTo(objDestinationArray, index);
			}

			/// 
			/// Gets the enumerator.
			/// </summary>
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				return List.GetEnumerator();
			}

			/// 
			/// Indexes the of.
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public int IndexOf(ListViewItem objItem)
			{
				return List.IndexOf(objItem);
			}

			/// 
			/// Inserts the specified index.
			/// </summary>
			/// <param name="index">The index.</param>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public ListViewItem Insert(int index, ListViewItem objItem)
			{
				List.Insert(index, objItem);
				objItem.InternalListView = mobjListView;
				mobjListView.Update();
				return objItem;
			}

			/// 
			/// Removes the specified obj list view item.
			/// </summary>
			/// <param name="objListViewItem">The obj list view item.</param>
			public void Remove(ListViewItem objListViewItem)
			{
				bool selected = objListViewItem.Selected;
				if (objListViewItem.InternalParent == mobjListView)
				{
					objListViewItem.InternalUnRegisterSelf();
					objListViewItem.InternalParent = null;
				}
				List.Remove(objListViewItem);
				if (mobjListView != null)
				{
					mobjListView.UnRegisterComponent(objListViewItem);
					if (selected)
					{
						mobjListView.OnSelectedIndexChanged(EventArgs.Empty);
					}
					if (mobjListView.CurrentPage > mobjListView.TotalPages)
					{
						mobjListView.CurrentPage = mobjListView.TotalPages;
					}
					mobjListView.Update();
				}
			}

			/// 
			/// Removes at.
			/// </summary>
			/// <param name="index">The index.</param>
			public void RemoveAt(int index)
			{
				List.RemoveAt(index);
				if (mobjListView != null && mobjListView.CurrentPage > mobjListView.TotalPages)
				{
					mobjListView.CurrentPage = mobjListView.TotalPages;
					mobjListView.Update();
				}
			}

			public void Sort()
			{
				if (mobjListView.ListViewItemSorterInternal != null)
				{
					mobjListView.ResetSortingColumns();
					List.Sort(mobjListView.ListViewItemSorterInternal);
					mobjListView.Update();
				}
			}
		}

		/// 
		/// Provides a collection of items that are mapped to this group
		/// </summary>
		[Serializable]
		internal class ListViewGroupItemCollection : ListViewItemCollection.IInnerList
		{
			/// 
			/// The owning listview group
			/// </summary>
			private ListViewGroup mobjListViewGroup = null;

			/// 
			/// The inner items collection
			/// </summary>
			private ArrayList mobjItems = new ArrayList();

			/// 
			/// Gets the count.
			/// </summary>
			/// The count.</value>
			public int Count => mobjItems.Count;

			/// 
			/// Gets the list view.
			/// </summary>
			/// The list view.</value>
			public ListView ListView => null;

			/// 
			/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> at the specified index.
			/// </summary>
			/// </value>
			public ListViewItem this[int index]
			{
				get
				{
					return (ListViewItem)mobjItems[index];
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					if (value.Group != null)
					{
						value.Group.Items.Remove(value);
					}
					value.MoveToGroup(mobjListViewGroup);
					mobjItems[index] = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewGroupItemCollection" /> class.
			/// </summary>
			/// <param name="objListViewGroup">The list view group.</param>
			internal ListViewGroupItemCollection(ListViewGroup objListViewGroup)
			{
				mobjListViewGroup = objListViewGroup;
			}

			/// 
			/// Adds the specified item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public ListViewItem Add(ListViewItem objItem)
			{
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				if (objItem.Group != null)
				{
					objItem.Group.Items.Remove(objItem);
				}
				mobjItems.Add(objItem);
				objItem.MoveToGroup(mobjListViewGroup);
				return objItem;
			}

			/// 
			/// Adds the range.
			/// </summary>
			/// <param name="arrItems">The items.</param>
			public void AddRange(ListViewItem[] arrItems)
			{
				foreach (ListViewItem objItem in arrItems)
				{
					Add(objItem);
				}
			}

			/// 
			/// Clears this instance.
			/// </summary>
			public void Clear()
			{
				foreach (ListViewItem mobjItem in mobjItems)
				{
					mobjItem.MoveToGroup(null);
				}
				mobjItems.Clear();
			}

			/// 
			/// Determines whether [contains] [the specified item].
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// 
			/// 	true</c> if [contains] [the specified item]; otherwise, false</c>.
			/// </returns>
			public bool Contains(ListViewItem objItem)
			{
				return mobjItems.Contains(objItem);
			}

			/// 
			/// Copies to.
			/// </summary>
			/// <param name="objDestinationArray">The dest.</param>
			/// <param name="index">The index.</param>
			public void CopyTo(Array objDestinationArray, int index)
			{
				mobjItems.CopyTo(objDestinationArray, index);
			}

			/// 
			/// Gets the enumerator.
			/// </summary>
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				return mobjItems.GetEnumerator();
			}

			/// 
			/// Indexes the of.
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public int IndexOf(ListViewItem objItem)
			{
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				return mobjItems.IndexOf(objItem);
			}

			/// 
			/// Inserts the specified index.
			/// </summary>
			/// <param name="index">The index.</param>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public ListViewItem Insert(int index, ListViewItem objItem)
			{
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				if (objItem.Group != null)
				{
					objItem.Group.Items.Remove(objItem);
				}
				objItem.MoveToGroup(mobjListViewGroup);
				return objItem;
			}

			/// 
			/// Removes the specified item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			public void Remove(ListViewItem objItem)
			{
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				if (objItem.Group == mobjListViewGroup)
				{
					mobjItems.Remove(objItem);
					objItem.MoveToGroup(null);
				}
			}

			/// 
			/// Removes at.
			/// </summary>
			/// <param name="index">The index.</param>
			public void RemoveAt(int index)
			{
				mobjItems.Remove(mobjItems[index]);
			}

			/// 
			/// Sorts this instance.
			/// </summary>
			public void Sort()
			{
			}
		}

		/// 
		///
		/// </summary>
		internal class ListViewOrederedItems : ListViewItemCollection.IInnerList
		{
			/// 
			///
			/// </summary>
			private ListView mobjListView = null;

			/// 
			///
			/// </summary>
			private bool mblnShowGroups = false;

			/// 
			///
			/// </summary>
			private List<object> mobjGroupedItems = null;

			/// 
			/// Gets the count.
			/// </summary>
			/// The count.</value>
			public int Count => mobjListView.Items.Count;

			/// 
			/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> at the specified index.
			/// </summary>
			/// </value>
			public ListViewItem this[int index]
			{
				get
				{
					if (mblnShowGroups)
					{
						EnsureGroupedItems();
						return mobjGroupedItems[index];
					}
					return mobjListView.Items[index];
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			/// 
			/// Gets the list view.
			/// </summary>
			/// The list view.</value>
			public ListView ListView => mobjListView;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewOrederedItems" /> class.
			/// </summary>
			/// <param name="objListView">The list view.</param>
			public ListViewOrederedItems(ListView objListView)
			{
				mobjListView = objListView;
				if (mobjListView != null)
				{
					mblnShowGroups = mobjListView.ShowGroups;
				}
			}

			/// 
			/// Adds the specified item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public ListViewItem Add(ListViewItem objItem)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Adds the range.
			/// </summary>
			/// <param name="arrItems">The items.</param>
			public void AddRange(ListViewItem[] arrItems)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Clears this instance.
			/// </summary>
			public void Clear()
			{
				throw new NotSupportedException();
			}

			/// 
			///
			/// </summary>
			/// <param name="objItem"></param>
			/// </returns>
			public bool Contains(ListViewItem objItem)
			{
				return mobjListView.Items.Contains(objItem);
			}

			/// 
			/// Copies to.
			/// </summary>
			/// <param name="objDestinationArray">The dest.</param>
			/// <param name="index">The index.</param>
			public void CopyTo(Array objDestinationArray, int index)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Gets the enumerator.
			/// </summary>
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				throw new NotSupportedException();
			}

			/// 
			/// Get item index
			/// </summary>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public int IndexOf(ListViewItem objItem)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Inserts the specified index.
			/// </summary>
			/// <param name="index">The index.</param>
			/// <param name="objItem">The item.</param>
			/// </returns>
			public ListViewItem Insert(int index, ListViewItem objItem)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Removes the specified item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			public void Remove(ListViewItem objItem)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Removes at.
			/// </summary>
			/// <param name="index">The index.</param>
			public void RemoveAt(int index)
			{
				throw new NotSupportedException();
			}

			/// 
			/// Sorts this instance.
			/// </summary>
			public void Sort()
			{
				throw new NotSupportedException();
			}

			/// 
			/// Ensures grouped items.
			/// </summary>
			private void EnsureGroupedItems()
			{
				if (mobjGroupedItems != null)
				{
					return;
				}
				mobjGroupedItems = new List<object>();
				List<object> list = new List<object><object>();
				list.Add(null);
				if (ListView == null)
				{
					return;
				}
				foreach (ListViewGroup group in ListView.Groups)
				{
					list.Add(group);
				}
				foreach (ListViewGroup item in list)
				{
					foreach (ListViewItem item2 in ListView.Items)
					{
						if (item2.Group == item)
						{
							mobjGroupedItems.Add(item2);
						}
					}
				}
			}
		}

		/// 
		/// Represents the collection of items in a ListView control.
		/// </summary>
		[Serializable]
		[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public class ListViewItemCollection : ICollection, IEnumerable, IList, IObservableList
		{
			/// 
			/// Provides a way to expose group items and list view items using the same
			/// class.
			/// </summary>
			internal interface IInnerList
			{
				int Count { get; }

				ListViewItem this[int index] { get; set; }

				ListView ListView { get; }

				ListViewItem Add(ListViewItem objItem);

				void AddRange(ListViewItem[] arrItems);

				void Clear();

				bool Contains(ListViewItem objItem);

				void CopyTo(Array objDestinationArray, int index);

				IEnumerator GetEnumerator();

				int IndexOf(ListViewItem objItem);

				ListViewItem Insert(int index, ListViewItem objItem);

				void Remove(ListViewItem objItem);

				void RemoveAt(int index);

				void Sort();
			}

			private IInnerList mobjList;

			/// 
			/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> at the specified int index.
			/// </summary>
			/// </value>
			public ListViewItem this[int intIndex]
			{
				get
				{
					return mobjList[intIndex];
				}
				set
				{
					if (intIndex < 0 || intIndex >= mobjList.Count)
					{
						throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", intIndex.ToString(CultureInfo.CurrentCulture)));
					}
					mobjList[intIndex] = value;
				}
			}

			/// 
			/// Gets a value indicating whether this instance is synchronized.
			/// </summary>
			/// 
			/// 	true</c> if this instance is synchronized; otherwise, false</c>.
			/// </value>
			public bool IsSynchronized => false;

			/// 
			/// Gets the count.
			/// </summary>
			/// </value>
			public int Count => mobjList.Count;

			/// 
			/// Gets the sync root.
			/// </summary>
			/// </value>
			public object SyncRoot => null;

			/// 
			///
			/// </summary>
			public bool IsReadOnly => false;

			/// 
			/// Return object (ListViewItem) at the specified index.
			/// </summary>
			object IList.this[int index]
			{
				get
				{
					return mobjList[index];
				}
				set
				{
					ListViewItem listViewItem = (ListViewItem)value;
					if (listViewItem != null)
					{
						mobjList[index] = listViewItem;
						OnItemAdded(listViewItem);
					}
				}
			}

			/// 
			/// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
			/// </summary>
			/// </value>
			/// true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.
			/// </returns>
			public bool IsFixedSize => false;

			/// 
			/// Occurs when [observable item inserted].
			/// </summary>
			public event ObservableListEventHandler ObservableItemInserted;

			/// 
			/// Occurs when [observable item added].
			/// </summary>
			public event ObservableListEventHandler ObservableItemAdded;

			/// 
			/// Occurs when [observable list cleared].
			/// </summary>
			public event EventHandler ObservableListCleared;

			/// 
			/// Occurs when [observable item removed].
			/// </summary>
			public event ObservableListEventHandler ObservableItemRemoved;

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection" /> instance.
			/// </summary>
			/// <param name="objListView">The obj list view.</param>
			public ListViewItemCollection(ListView objListView)
			{
				mobjList = new ListViewNativeItemCollection(objListView);
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection" /> instance.
			/// </summary>
			/// <param name="objListView">The obj list view.</param>
			/// <param name="arrItems">The arr items.</param>
			internal ListViewItemCollection(ListView objListView, object[] arrItems)
			{
				mobjList = new ListViewNativeItemCollection(objListView, arrItems);
			}

			internal ListViewItemCollection(ListViewGroup objListViewGroup)
			{
				mobjList = new ListViewGroupItemCollection(objListViewGroup);
			}

			/// 
			///
			/// </summary>
			/// <param name="strText">The first sub item text.</param>
			/// </returns>
			public virtual ListViewItem Add(string strText)
			{
				return Add((Control)null, strText, -1);
			}

			/// 
			///
			/// </summary>
			/// <param name="objPanel">The panel to use in for the list view item.</param>
			/// <param name="strText">The first sub item text.</param>
			/// </returns>
			public virtual ListViewItem Add(Control objPanel, string strText)
			{
				return Add(objPanel, strText, -1);
			}

			/// 
			/// Adds the specified obj list view item.
			/// </summary>
			/// <param name="objListViewItem">Obj list view item.</param>
			/// </returns>
			public virtual ListViewItem Add(ListViewItem objListViewItem)
			{
				mobjList.Add(objListViewItem);
				OnItemAdded(objListViewItem);
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(objListViewItem));
				}
				return objListViewItem;
			}

			/// 
			/// Adds the specified text.
			/// </summary>
			/// <param name="strText">Text.</param>
			/// <param name="intImageIndex">Image index.</param>
			/// </returns>
			public virtual ListViewItem Add(string strText, int intImageIndex)
			{
				return Add((Control)null, strText, intImageIndex);
			}

			/// 
			/// Adds the specified text.
			/// </summary>
			/// <param name="strText">The text.</param>
			/// <param name="strImageKey">The image key.</param>
			/// </returns>
			public virtual ListViewItem Add(string strText, string strImageKey)
			{
				ListViewItem listViewItem = new ListViewItem(strText, strImageKey);
				Add(listViewItem);
				return listViewItem;
			}

			/// 
			/// Adds the specified key.
			/// </summary>
			/// <param name="strKey">The key.</param>
			/// <param name="strText">The text.</param>
			/// <param name="intImageIndex">Index of the image.</param>
			/// </returns>
			public virtual ListViewItem Add(string strKey, string strText, int intImageIndex)
			{
				ListViewItem listViewItem = new ListViewItem(strText, intImageIndex);
				listViewItem.Name = strKey;
				Add(listViewItem);
				return listViewItem;
			}

			/// 
			/// Adds the specified key.
			/// </summary>
			/// <param name="strKey">The STR key.</param>
			/// <param name="strText">The text.</param>
			/// <param name="strImageKey">The STR image key.</param>
			/// </returns>
			public virtual ListViewItem Add(string strKey, string strText, string strImageKey)
			{
				ListViewItem listViewItem = new ListViewItem(strText, strImageKey);
				listViewItem.Name = strKey;
				Add(listViewItem);
				return listViewItem;
			}

			/// 
			/// Adds the specified text.
			/// </summary>
			/// <param name="objPanel">The obj panel.</param>
			/// <param name="strText">Text.</param>
			/// <param name="intImageIndex">Image index.</param>
			/// </returns>
			public virtual ListViewItem Add(Control objPanel, string strText, int intImageIndex)
			{
				ListViewItem listViewItem = null;
				listViewItem = ((objPanel != null) ? new ListViewPanelItem(objPanel, strText, intImageIndex) : new ListViewItem(strText, intImageIndex));
				mobjList.Add(listViewItem);
				OnItemAdded(listViewItem);
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(listViewItem));
				}
				return listViewItem;
			}

			/// Adds an array of <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to the collection.</summary>
			/// <param name="arrListViewItems">An array of <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to add to the collection. </param>
			/// <exception cref="T:System.ArgumentNullException">items is null.</exception>
			public void AddRange(ListViewItem[] arrListViewItems)
			{
				foreach (ListViewItem objListViewItem in arrListViewItems)
				{
					Add(objListViewItem);
				}
			}

			/// 
			/// Removes the specified list view item.
			/// </summary>
			/// <param name="objListViewItem">list view item.</param>
			public void Remove(ListViewItem objListViewItem)
			{
				mobjList.Remove(objListViewItem);
				objListViewItem.Group?.Items.Remove(objListViewItem);
				OnItemRemoved(objListViewItem);
				if (this.ObservableItemRemoved != null)
				{
					this.ObservableItemRemoved(this, new ObservableListEventArgs(objListViewItem));
				}
			}

			/// 
			/// Called when item was removed.
			/// </summary>
			/// <param name="objListViewItem">The list view item removed.</param>
			private void OnItemRemoved(ListViewItem objListViewItem)
			{
				ListView listView = mobjList.ListView;
				if (listView == null)
				{
					return;
				}
				if (objListViewItem is ListViewPanelItem listViewPanelItem)
				{
					listView.Controls.Remove(listViewPanelItem.Panel);
				}
				foreach (ListViewItem.ListViewSubItem subItem in objListViewItem.SubItems)
				{
					if (subItem is ListViewItem.ListViewSubControlItem { Control: { } control })
					{
						listView.Controls.Remove(control);
					}
				}
			}

			/// 
			/// Get the index the of the specified list view item.
			/// </summary>
			/// <param name="objListViewItem">Obj list view item.</param>
			/// </returns>
			public int IndexOf(ListViewItem objListViewItem)
			{
				return mobjList.IndexOf(objListViewItem);
			}

			/// 
			/// Clears this list items.
			/// </summary>
			public void Clear()
			{
				ListViewItem[] array = new ListViewItem[mobjList.Count];
				mobjList.CopyTo(array, 0);
				mobjList.Clear();
				bool flag = !mobjList.ListView.DesignMode;
				ListViewItem[] array2 = array;
				foreach (ListViewItem listViewItem in array2)
				{
					if (flag)
					{
						listViewItem.Group?.Items.Remove(listViewItem);
					}
					OnItemRemoved(listViewItem);
				}
				if (this.ObservableListCleared != null)
				{
					this.ObservableListCleared(this, EventArgs.Empty);
				}
			}

			/// 
			/// Copies to an array.
			/// </summary>
			/// <param name="objArray">The obj array.</param>
			/// <param name="intIndex">Index of the int.</param>
			public void CopyTo(Array objArray, int intIndex)
			{
				mobjList.CopyTo(objArray, intIndex);
			}

			/// 
			/// Gets an enumerator.
			/// </summary>
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				return mobjList.GetEnumerator();
			}

			/// 
			/// Sorts this instance.
			/// </summary>
			internal void Sort()
			{
				mobjList.Sort();
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			public void RemoveAt(int index)
			{
				if (index > -1 && index < mobjList.Count)
				{
					ListViewItem listViewItem = mobjList[index];
					if (listViewItem != null)
					{
						Remove(listViewItem);
					}
					return;
				}
				throw new ArgumentOutOfRangeException();
			}

			/// Creates a new item and inserts it into the collection at the specified index.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
			/// <param name="index">The zero-based index location where the item is inserted. </param>
			/// <param name="strText">The text to display for the item. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
			public ListViewItem Insert(int index, string strText)
			{
				return Insert(index, new ListViewItem(strText));
			}

			/// Inserts an existing <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> into the collection at the specified index.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
			/// <param name="objItem">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that represents the item to insert. </param>
			/// <param name="index">The zero-based index location where the item is inserted. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
			public ListViewItem Insert(int index, ListViewItem objItem)
			{
				mobjList.Insert(index, objItem);
				OnItemAdded(objItem);
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(objItem));
				}
				return objItem;
			}

			/// 
			/// Called when item was added.
			/// </summary>
			/// <param name="objListViewItem">The list view item added.</param>
			private void OnItemAdded(ListViewItem objListViewItem)
			{
				ListView listView = mobjList.ListView;
				if (listView == null)
				{
					return;
				}
				if (objListViewItem is ListViewPanelItem listViewPanelItem)
				{
					listView.Controls.Add(listViewPanelItem.Panel);
				}
				foreach (ListViewItem.ListViewSubItem subItem in objListViewItem.SubItems)
				{
					if (subItem is ListViewItem.ListViewSubControlItem { Control: { } control })
					{
						listView.Controls.Add(control);
					}
				}
			}

			/// Creates a new item with the specified image index and inserts it into the collection at the specified index.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
			/// <param name="intImageIndex">The index of the image to display for the item. </param>
			/// <param name="index">The zero-based index location where the item is inserted. </param>
			/// <param name="strText">The text to display for the item. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
			public ListViewItem Insert(int index, string strText, int intImageIndex)
			{
				return Insert(index, new ListViewItem(strText, intImageIndex));
			}

			/// Creates a new item with the specified text and image and inserts it in the collection at the specified index.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
			/// <param name="strImageKey">The key of the image to display for the item.</param>
			/// <param name="index">The zero-based index location where the item is inserted. </param>
			/// <param name="strText">The text of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
			public ListViewItem Insert(int index, string strText, string strImageKey)
			{
				return Insert(index, new ListViewItem(strText));
			}

			/// Creates a new item with the specified key, text, and image, and inserts it in the collection at the specified index.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
			/// <param name="intImageIndex">The index of the image to display for the item.</param>
			/// <param name="strKey">The <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Name"></see> of the item.</param>
			/// <param name="intIndex">The zero-based index location where the item is inserted</param>
			/// <param name="strText">The text of the item.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
			public virtual ListViewItem Insert(int intIndex, string strKey, string strText, int intImageIndex)
			{
				ListViewItem listViewItem = new ListViewItem(strText, intImageIndex);
				listViewItem.Name = strKey;
				return Insert(intIndex, listViewItem);
			}

			/// Creates a new item with the specified key, text, and image, and adds it to the collection at the specified index.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
			/// <param name="strImageKey">The key of the image to display for the item.</param>
			/// <param name="strKey">The <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Name"></see> of the item. </param>
			/// <param name="intIndex">The zero-based index location where the item is inserted.</param>
			/// <param name="strText">The text of the item.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
			public virtual ListViewItem Insert(int intIndex, string strKey, string strText, string strImageKey)
			{
				ListViewItem listViewItem = new ListViewItem(strText, strImageKey);
				listViewItem.Name = strKey;
				return Insert(intIndex, listViewItem);
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			/// <param name="objValue"></param>
			void IList.Insert(int index, object objValue)
			{
				mobjList.Insert(index, (ListViewItem)objValue);
				OnItemAdded((ListViewItem)objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			void IList.Remove(object objValue)
			{
				if (objValue is ListViewItem objListViewItem)
				{
					Remove(objListViewItem);
				}
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			public bool Contains(object objValue)
			{
				return mobjList.Contains((ListViewItem)objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			public int IndexOf(object objValue)
			{
				return mobjList.IndexOf((ListViewItem)objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			int IList.Add(object objValue)
			{
				if (objValue is ListViewItem objListViewItem)
				{
					Add(objListViewItem);
					OnItemAdded(objListViewItem);
				}
				return IndexOf(objValue);
			}
		}

		/// 
		/// Represents the collection of column headers in a ListView control.
		/// </summary>
		[Serializable]
		public class ColumnHeaderCollection : ICollection, IEnumerable, IList, IObservableList
		{
			private ListView mobjListView;

			private ArrayList mobjList;

			private ArrayList mobjSortedColumns;

			/// 
			/// Gets a value indicating whether this instance is synchronized.
			/// </summary>
			/// 
			/// 	true</c> if this instance is synchronized; otherwise, false</c>.
			/// </value>
			public bool IsSynchronized => mobjList.IsSynchronized;

			/// 
			/// Gets the count.
			/// </summary>
			/// </value>
			public int Count => mobjList.Count;

			/// 
			/// Gets the sync root.
			/// </summary>
			/// </value>
			public object SyncRoot => mobjList.SyncRoot;

			/// 
			/// Gets the visible columns.
			/// </summary>
			/// </value>
			public ICollection VisibleColumns
			{
				get
				{
					ArrayList arrayList = new ArrayList();
					foreach (ColumnHeader mobj in mobjList)
					{
						if (mobj.Visible)
						{
							arrayList.Add(mobj);
						}
					}
					return arrayList;
				}
			}

			/// 
			/// Gets the position sorted column list.
			/// </summary>
			/// </value>
			public ICollection SortedColumns
			{
				get
				{
					if (mobjSortedColumns == null)
					{
						mobjSortedColumns = new ArrayList(mobjList);
						mobjSortedColumns.Sort();
					}
					return mobjSortedColumns;
				}
			}

			/// 
			/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> with the specified int index.
			/// </summary>
			/// </value>
			public ColumnHeader this[int intIndex] => (ColumnHeader)mobjList[intIndex];

			/// 
			///
			/// </summary>
			public bool IsReadOnly => false;

			/// 
			///
			/// </summary>
			object IList.this[int index]
			{
				get
				{
					return mobjList[index];
				}
				set
				{
					if (mobjListView != null)
					{
						mobjListView.Update();
					}
					mobjList[index] = value;
				}
			}

			/// 
			///
			/// </summary>
			public bool IsFixedSize => false;

			/// 
			/// Occurs when [observable item inserted].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemInserted;

			/// 
			/// Occurs when [observable item added].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemAdded;

			/// 
			/// Occurs when [observable list cleared].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event EventHandler ObservableListCleared;

			/// 
			/// Occurs when [observable item removed].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemRemoved;

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection" /> instance.
			/// </summary>
			public ColumnHeaderCollection(ListView objListView)
			{
				mobjListView = objListView;
				mobjList = new ArrayList();
			}

			/// 
			/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection" /> instance.
			/// </summary>
			internal ColumnHeaderCollection(ListView objListView, object[] arrColumns)
			{
				mobjListView = objListView;
				mobjList = new ArrayList(arrColumns);
			}

			/// 
			/// Adds the specified list view column.
			/// </summary>
			/// <param name="objListViewColumn">Obj list view column.</param>
			/// </returns>
			public int Add(ColumnHeader objListViewColumn)
			{
				objListViewColumn.InternalParent = mobjListView;
				objListViewColumn.InternalIndex = mobjList.Add(objListViewColumn);
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(objListViewColumn));
				}
				if (mobjListView != null)
				{
					mobjListView.Update();
				}
				ClearSortedColumns();
				objListViewColumn.DisplayIndexInternal = objListViewColumn.Index;
				return objListViewColumn.Index;
			}

			/// 
			/// Adds the range.
			/// </summary>
			/// <param name="arrColumnHeaders">column headers array.</param>
			public virtual void AddRange(ColumnHeader[] arrColumnHeaders)
			{
				foreach (ColumnHeader objListViewColumn in arrColumnHeaders)
				{
					Add(objListViewColumn);
				}
			}

			/// 
			/// Creates and adds a new list view column.
			/// </summary>
			/// <param name="strLabel">Label.</param>
			/// <param name="intWidth">Width.</param>
			/// <param name="enmTextAlign">Text align.</param>
			/// </returns>
			public ColumnHeader Add(string strLabel, int intWidth, HorizontalAlignment enmTextAlign)
			{
				ColumnHeader columnHeader = new ColumnHeader(strLabel, strLabel, intWidth);
				columnHeader.TextAlign = enmTextAlign;
				Add(columnHeader);
				return columnHeader;
			}

			/// 
			/// Removes the specified list view column.
			/// </summary>
			/// <param name="objListViewColumn">list view column.</param>
			public void Remove(ColumnHeader objListViewColumn)
			{
				int displayIndex = objListViewColumn.DisplayIndex;
				if (objListViewColumn.InternalParent == mobjListView)
				{
					objListViewColumn.InternalParent = null;
				}
				mobjList.Remove(objListViewColumn);
				if (mobjListView != null)
				{
					mobjListView.Update();
				}
				if (this.ObservableItemRemoved != null)
				{
					this.ObservableItemRemoved(this, new ObservableListEventArgs(objListViewColumn));
				}
				UpdateColumnsIndex();
				UpdateDisplayIndex(displayIndex, blnAdd: false);
			}

			/// 
			/// Updates the display index.
			/// </summary>
			/// <param name="intDisplayIndex">Display index of the int.</param>
			/// <param name="blnAdd">if set to true</c> [BLN add].</param>
			private void UpdateDisplayIndex(int intDisplayIndex, bool blnAdd)
			{
				foreach (ColumnHeader mobj in mobjList)
				{
					if (mobj.DisplayIndex > intDisplayIndex)
					{
						mobj.DisplayIndexInternal += (blnAdd ? 1 : (-1));
					}
				}
				ClearSortedColumns();
			}

			/// 
			/// Updates the columns index.
			/// </summary>
			private void UpdateColumnsIndex()
			{
				int num = 0;
				foreach (ColumnHeader mobj in mobjList)
				{
					mobj.InternalIndex = num;
					num++;
				}
			}

			/// 
			/// Clears this instance.
			/// </summary>
			public void Clear()
			{
				mobjListView.UnRegisterBatch(this);
				mobjSortedColumns = null;
				mobjList.Clear();
			}

			/// 
			/// Clears the sorted columns array list.
			/// </summary>
			internal void ClearSortedColumns()
			{
				mobjSortedColumns = null;
			}

			/// 
			/// Gets the enumerator.
			/// </summary>
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				return mobjList.GetEnumerator();
			}

			/// 
			/// Copies to.
			/// </summary>
			/// <param name="objArray">Array.</param>
			/// <param name="index">Index.</param>
			public void CopyTo(Array objArray, int index)
			{
				mobjList.CopyTo(objArray, index);
			}

			/// 
			/// Updates the listview columns.
			/// </summary>
			public void UpdateColumns()
			{
				bool blnValid = true;
				foreach (ColumnHeader mobj in mobjList)
				{
					if (mobj.Visible && !mobj.Loaded)
					{
						blnValid = false;
						break;
					}
				}
				mobjSortedColumns = null;
				mobjListView.FireUpdateColumns(blnValid);
				mobjListView.Update(blnRedrawOnly: true);
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			public void RemoveAt(int index)
			{
				if (mobjList[index] is ColumnHeader objListViewColumn)
				{
					Remove(objListViewColumn);
				}
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			/// <param name="objValue"></param>
			public void Insert(int index, object objValue)
			{
				if (index < 0 || objValue == null || !(objValue is ColumnHeader columnHeader))
				{
					return;
				}
				columnHeader.InternalParent = mobjListView;
				columnHeader.DisplayIndex = index;
				mobjList.Insert(index, columnHeader);
				foreach (ColumnHeader mobj in mobjList)
				{
					mobj.InternalIndex = mobjList.IndexOf(mobj);
				}
				UpdateDisplayIndex(index, blnAdd: true);
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(columnHeader));
				}
				if (mobjListView != null)
				{
					mobjListView.Update();
				}
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			void IList.Remove(object objValue)
			{
				if (mobjListView != null)
				{
					mobjListView.Update();
				}
				mobjList.Remove(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			public bool Contains(object objValue)
			{
				return mobjList.Contains(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			public int IndexOf(object objValue)
			{
				if (mobjListView != null)
				{
					mobjListView.Update();
				}
				return mobjList.IndexOf(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			int IList.Add(object objValue)
			{
				if (!(objValue is ColumnHeader))
				{
					throw new ArgumentException(SR.GetString("ColumnHeaderCollectionInvalidArgument"));
				}
				return Add((ColumnHeader)objValue);
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		public class SelectedListViewItemCollection : ICollection, IEnumerable, IList
		{
			private ArrayList mobjItems;

			private ListView mobjListView;

			/// 
			///
			/// </summary>
			bool ICollection.IsSynchronized => mobjItems.IsSynchronized;

			/// 
			///
			/// </summary>
			public int Count => mobjItems.Count;

			/// 
			///
			/// </summary>
			object ICollection.SyncRoot => mobjItems.SyncRoot;

			/// 
			///
			/// </summary>
			public bool IsReadOnly => true;

			/// 
			///
			/// </summary>
			public ListViewItem this[int index] => (ListViewItem)mobjItems[index];

			/// 
			///
			/// </summary>
			bool IList.IsFixedSize => true;

			/// 
			///
			/// </summary>
			object IList.this[int index]
			{
				get
				{
					return mobjItems[index];
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			/// 
			///
			/// </summary>
			/// <param name="objArray"></param>
			/// <param name="index"></param>
			public void CopyTo(Array objArray, int index)
			{
				mobjItems.CopyTo(objArray, index);
			}

			/// 
			///
			/// </summary>
			public IEnumerator GetEnumerator()
			{
				return mobjItems.GetEnumerator();
			}

			/// 
			///
			/// </summary>
			/// <param name="objListViewItem"></param>
			public bool Contains(ListViewItem objListViewItem)
			{
				return mobjItems.Contains(objListViewItem);
			}

			/// 
			///
			/// </summary>
			void IList.Clear()
			{
				Clear();
			}

			/// 
			/// Removes all items from the <see cref="T:System.Collections.IList" />.
			/// </summary>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only. </exception>
			public void Clear()
			{
				if (mobjItems == null)
				{
					return;
				}
				foreach (ListViewItem mobjItem in mobjItems)
				{
					mobjItem.Selected = false;
				}
				mobjItems.Clear();
				if (mobjListView != null)
				{
					mobjListView.Update();
				}
			}

			/// 
			///
			/// </summary>
			/// <param name="objListViewItem"></param>
			public int IndexOf(ListViewItem objListViewItem)
			{
				return mobjItems.IndexOf(objListViewItem);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			int IList.Add(object objValue)
			{
				throw new NotSupportedException();
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			void IList.RemoveAt(int index)
			{
				throw new NotSupportedException();
			}

			/// 
			///
			/// </summary>
			/// <param name="index"></param>
			/// <param name="objValue"></param>
			void IList.Insert(int index, object objValue)
			{
				throw new NotSupportedException();
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			void IList.Remove(object objValue)
			{
				throw new NotSupportedException();
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			bool IList.Contains(object objValue)
			{
				return mobjItems.Contains(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objValue"></param>
			int IList.IndexOf(object objValue)
			{
				return mobjItems.IndexOf(objValue);
			}

			/// 
			///
			/// </summary>
			/// <param name="objListView"></param>
			public SelectedListViewItemCollection(ListView objListView)
			{
				mobjListView = objListView;
				mobjItems = new ArrayList();
				foreach (ListViewItem item in objListView.Items)
				{
					if (item.Selected)
					{
						mobjItems.Add(item);
					}
				}
			}
		}

		/// 
		/// Provides item processing base implementation
		/// </summary>
		internal abstract class ItemProcessor
		{
			/// 
			/// Gets a value indicating whether processing is still needed.
			/// </summary>
			/// 
			/// 	true</c> if processing is still needed; otherwise, false</c>.
			/// </value>
			internal virtual bool IsProcessingStillNeeded => true;

			/// 
			/// Processes the item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			internal abstract void ProcessItem(ListViewItem objItem);

			/// 
			/// Processes the group.
			/// </summary>
			/// <param name="objGroup">The group.</param>
			internal abstract void ProcessGroup(ListViewGroup objGroup);
		}

		/// 
		/// Provides support for rendering items
		/// </summary>
		internal class ItemRenderingProcessor : ItemProcessor
		{
			/// 
			/// The owner listview
			/// </summary>
			private readonly ListView mobjListView;

			/// 
			/// The current context
			/// </summary>
			private readonly IContext mobjContext;

			/// 
			/// The current response writer
			/// </summary>
			private readonly IResponseWriter mobjWriter;

			/// 
			/// The current request ID.
			/// </summary>
			private readonly long mlngRequestID;

			/// 
			///
			/// </summary>
			private readonly View menmView;

			/// 
			///
			/// </summary>
			private readonly bool mblnShowItemToolTips;

			/// 
			///
			/// </summary>
			private readonly ICollection mobjSortedColumns;

			/// 
			///
			/// </summary>
			private readonly bool mblnFullListRedraw;

			/// 
			/// Gets a value indicating whether in full list redraw.
			/// </summary>
			/// true</c> if in full list redraw; otherwise, false</c>.</value>
			public bool FullListRedraw => mblnFullListRedraw;

			/// 
			/// Gets the list view.
			/// </summary>
			/// The list view.</value>
			public ListView ListView => mobjListView;

			/// 
			/// Gets the view.
			/// </summary>
			/// The view.</value>
			public View View => menmView;

			/// 
			/// Gets a value indicating whether to show item tooltips.
			/// </summary>
			/// true</c> if to show item tool tips; otherwise, false</c>.</value>
			public bool ShowItemToolTips => mblnShowItemToolTips;

			/// 
			/// Gets the sorted columns.
			/// </summary>
			/// The sorted columns.</value>
			public ICollection SortedColumns => mobjSortedColumns;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemRenderingProcessor" /> class.
			/// </summary>
			/// <param name="objListView">The list view.</param>
			/// <param name="objContext">The context.</param>
			/// <param name="objWriter">The writer.</param>
			/// <param name="lngRequestID">The request ID.</param>
			public ItemRenderingProcessor(ListView objListView, IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullListRedraw)
			{
				mobjListView = objListView;
				mobjContext = objContext;
				mobjWriter = objWriter;
				mlngRequestID = lngRequestID;
				menmView = objListView.View;
				mblnShowItemToolTips = objListView.ShowItemToolTips;
				mobjSortedColumns = objListView.Columns.SortedColumns;
				mblnFullListRedraw = blnFullListRedraw;
			}

			/// 
			/// Processes the item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			internal override void ProcessItem(ListViewItem objItem)
			{
				objItem.RenderItem(mobjContext, mobjWriter, mlngRequestID, this);
			}

			/// 
			/// Processes the group.
			/// </summary>
			/// <param name="objGroup">The group.</param>
			internal override void ProcessGroup(ListViewGroup objGroup)
			{
				mobjListView.RenderGroup(mobjContext, mobjWriter, objGroup, this);
			}

			/// 
			/// Called when item is formatted.
			/// </summary>
			/// <param name="intItemIndex">The item index.</param>
			/// <param name="intColumnIndex">The column index.</param>
			/// <param name="objSubItem">The sub item.</param>
			internal void OnItemFormatting(int intItemIndex, int intColumnIndex, ListViewItem.ListViewSubItem objSubItem)
			{
				mobjListView.OnItemFormatting(intItemIndex, intColumnIndex, objSubItem);
			}
		}

		/// 
		/// Provides support for get layout information on the current listview status
		/// </summary>
		internal class ItemLayoutProcessor : ItemProcessor
		{
			/// 
			///
			/// </summary>
			private enum SearchType
			{
				/// 
				///
				/// </summary>
				ItemFromLocation,
				/// 
				///
				/// </summary>
				LocationFromItem
			}

			/// 
			///
			/// </summary>
			private Point mobjItemLocation = Point.Empty;

			/// 
			///
			/// </summary>
			private ListViewItem mobjItem = null;

			/// 
			///
			/// </summary>
			private ListViewSkin mobjOwnerSkin = null;

			/// 
			///
			/// </summary>
			private Size mobjOwnerSize = Size.Empty;

			/// 
			///
			/// </summary>
			private ListView mobjListView = null;

			/// 
			///
			/// </summary>
			private Point mobjCurrentPosition = Point.Empty;

			/// 
			///
			/// </summary>
			private bool mblnIsProcessingStillNeeded = true;

			/// 
			///
			/// </summary>
			private int mintLastLineHeight = 0;

			/// 
			///
			/// </summary>
			private readonly SearchType menmSearchType = SearchType.ItemFromLocation;

			/// 
			/// Gets a value indicating whether this instance is item from location search.
			/// </summary>
			/// 
			/// 	true</c> if this instance is item from location search; otherwise, false</c>.
			/// </value>
			private bool IsItemFromLocationSearch => menmSearchType == SearchType.ItemFromLocation;

			/// 
			/// Gets a value indicating whether this instance is location from item search.
			/// </summary>
			/// 
			/// 	true</c> if this instance is location from item search; otherwise, false</c>.
			/// </value>
			private bool IsLocationFromItemSearch => menmSearchType == SearchType.LocationFromItem;

			/// 
			/// Gets a value indicating whether this instance is header visible.
			/// </summary>
			/// 
			/// 	true</c> if this instance is header visible; otherwise, false</c>.
			/// </value>
			private bool IsHeaderVisible
			{
				get
				{
					if (CurrentView == View.Details)
					{
						return mobjListView.HeaderStyle != ColumnHeaderStyle.None;
					}
					return false;
				}
			}

			/// 
			/// Gets the current view.
			/// </summary>
			/// The current view.</value>
			private View CurrentView => mobjListView.View;

			/// 
			/// Gets the current position.
			/// </summary>
			/// The current position.</value>
			private Point CurrentPosition => mobjCurrentPosition;

			/// 
			/// Gets a value indicating whether processing is still needed.
			/// </summary>
			/// 
			/// 	true</c> if processing is still needed; otherwise, false</c>.
			/// </value>
			internal override bool IsProcessingStillNeeded => mblnIsProcessingStillNeeded;

			/// 
			/// Gets the item.
			/// </summary>
			/// The item.</value>
			public ListViewItem Item
			{
				get
				{
					return mobjItem;
				}
				private set
				{
					mobjItem = value;
				}
			}

			/// 
			/// Gets the location.
			/// </summary>
			/// The location.</value>
			public Point ItemLocation
			{
				get
				{
					return mobjItemLocation;
				}
				private set
				{
					mobjItemLocation = value;
				}
			}

			/// 
			/// Gets the owner skin.
			/// </summary>
			/// The owner skin.</value>
			private ListViewSkin OwnerSkin => mobjOwnerSkin;

			/// 
			/// Gets the size of the owner.
			/// </summary>
			/// The size of the owner.</value>
			private Size OwnerSize => mobjOwnerSize;

			/// 
			/// Gets the height of the owner.
			/// </summary>
			/// The height of the owner.</value>
			private int OwnerHeight => OwnerSize.Height;

			/// 
			/// Gets the width of the owner.
			/// </summary>
			/// The width of the owner.</value>
			private int OwnerWidth => OwnerSize.Width;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemLayoutProcessor" /> class.
			/// </summary>
			/// <param name="objListView">The list view.</param>
			/// <param name="objItem">The list view item.</param>
			/// <param name="objSize">The list view size.</param>
			internal ItemLayoutProcessor(ListView objListView, ListViewItem objItem)
			{
				mobjItem = objItem;
				mobjOwnerSize = objListView.Size;
				mobjOwnerSkin = (ListViewSkin)objListView.Skin;
				mobjListView = objListView;
				menmSearchType = SearchType.LocationFromItem;
				ProcessHeader();
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemLayoutProcessor" /> class.
			/// </summary>
			/// <param name="objListView">The list view.</param>
			/// <param name="objLocation">The mouse location.</param>
			/// <param name="objSize">The list view size.</param>
			internal ItemLayoutProcessor(ListView objListView, Point objLocation)
			{
				mobjItemLocation = objLocation;
				mobjOwnerSkin = (ListViewSkin)objListView.Skin;
				mobjOwnerSize = objListView.Size;
				mobjListView = objListView;
				menmSearchType = SearchType.ItemFromLocation;
				ProcessHeader();
			}

			/// 
			/// Processes the header.
			/// </summary>
			private void ProcessHeader()
			{
				if (IsHeaderVisible)
				{
					Rectangle objItemRectangle = new Rectangle(CurrentPosition, new Size(OwnerWidth, mobjListView.GetPreferdItemFontHeight(blnIsHeader: true)));
					AddItemRectangleToPosition(objItemRectangle);
					if (IsItemFromLocationSearch && objItemRectangle.Contains(ItemLocation))
					{
						SetFoundItemAndStopProcessing(null);
					}
				}
			}

			/// 
			/// Processes the item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			internal override void ProcessItem(ListViewItem objItem)
			{
				Rectangle rectangle = Rectangle.Empty;
				switch (CurrentView)
				{
				case View.Details:
					rectangle = new Rectangle(CurrentPosition, new Size(OwnerWidth, mobjListView.GetPreferdItemFontHeight(blnIsHeader: false)));
					break;
				case View.LargeIcon:
					rectangle = new Rectangle(CurrentPosition, OwnerSkin.GetItemSizeForView(View.LargeIcon));
					break;
				case View.SmallIcon:
					rectangle = new Rectangle(CurrentPosition, OwnerSkin.GetItemSizeForView(View.SmallIcon));
					break;
				case View.List:
					rectangle = new Rectangle(CurrentPosition, OwnerSkin.GetItemSizeForView(View.List));
					break;
				}
				if (!(rectangle != Rectangle.Empty))
				{
					return;
				}
				if (IsItemFromLocationSearch)
				{
					if (rectangle.Contains(ItemLocation))
					{
						SetFoundItemAndStopProcessing(objItem);
					}
				}
				else if (IsLocationFromItemSearch && IsItemSearchTarget(objItem))
				{
					SetFoundItemLocationAndStopProcessing(rectangle.Location);
				}
				AddItemRectangleToPosition(rectangle);
			}

			/// 
			/// Processes the group.
			/// </summary>
			/// <param name="objGroup">The group.</param>
			internal override void ProcessGroup(ListViewGroup objGroup)
			{
				AddItemRectangleToPosition(new Rectangle(CurrentPosition, new Size(OwnerWidth, mobjListView.GetPreferdItemFontHeight(blnIsHeader: false))));
			}

			/// 
			/// Stops the processing.
			/// </summary>
			private void StopProcessing()
			{
				mblnIsProcessingStillNeeded = false;
			}

			/// 
			/// Sets the found item and stop processing.
			/// </summary>
			/// <param name="objItem">The found item.</param>
			private void SetFoundItemAndStopProcessing(ListViewItem objItem)
			{
				Item = objItem;
				StopProcessing();
			}

			/// 
			/// Sets the found item location and stop processing.
			/// </summary>
			/// <param name="objItemLocation">The found item location.</param>
			private void SetFoundItemLocationAndStopProcessing(Point objItemLocation)
			{
				ItemLocation = objItemLocation;
				StopProcessing();
			}

			/// 
			/// Indicates if this is the item we are searching for
			/// </summary>
			/// <param name="objItem"></param>
			/// </returns>
			private bool IsItemSearchTarget(ListViewItem objItem)
			{
				return Item == objItem;
			}

			/// 
			/// Adds the item rectangle to position.
			/// </summary>
			/// <param name="objItemRectangle">The item rectangle.</param>
			private void AddItemRectangleToPosition(Rectangle objItemRectangle)
			{
				if (OwnerWidth < CurrentPosition.X + objItemRectangle.Width)
				{
					AddToYPosition(mintLastLineHeight);
					mintLastLineHeight = 0;
					ResetXPosition();
				}
				if (OwnerWidth <= objItemRectangle.Width)
				{
					AddToYPosition(objItemRectangle.Height);
					mintLastLineHeight = 0;
					ResetXPosition();
				}
				else
				{
					mintLastLineHeight = Math.Max(mintLastLineHeight, objItemRectangle.Height);
					AddToXPosition(objItemRectangle.Width);
				}
			}

			/// 
			/// Resets the X position.
			/// </summary>
			private void ResetXPosition()
			{
				mobjCurrentPosition = new Point(0, CurrentPosition.Y);
			}

			/// 
			/// Adds to Y position.
			/// </summary>
			/// <param name="intOffsetY">The offset Y.</param>
			private void AddToYPosition(int intOffsetY)
			{
				mobjCurrentPosition = new Point(CurrentPosition.X, CurrentPosition.Y + intOffsetY);
			}

			/// 
			/// Adds to X position.
			/// </summary>
			/// <param name="intOffsetX">The offset X.</param>
			private void AddToXPosition(int intOffsetX)
			{
				mobjCurrentPosition = new Point(CurrentPosition.X + intOffsetX, CurrentPosition.Y);
			}

			/// 
			/// Adds to XY position.
			/// </summary>
			/// <param name="intOffsetX">The offset X.</param>
			/// <param name="intOffsetY">The offset Y.</param>
			private void AddToXYPosition(int intOffsetX, int intOffsetY)
			{
				mobjCurrentPosition = new Point(CurrentPosition.X + intOffsetX, CurrentPosition.Y + intOffsetY);
			}

			/// 
			/// If the location y is with in the y position range
			/// </summary>
			/// <param name="objLocation"></param>
			/// </returns>
			private bool IsYInPositionRange(Point objLocation)
			{
				return mobjCurrentPosition.Y >= objLocation.Y;
			}

			/// 
			/// If the location x is with in the x position range
			/// </summary>
			/// <param name="objLocation"></param>
			/// </returns>
			private bool IsXInPositionRange(Point objLocation)
			{
				return mobjCurrentPosition.X >= objLocation.X;
			}

			/// 
			/// If the location xy is with in the xy position range
			/// </summary>
			/// <param name="objLocation"></param>
			/// </returns>
			private bool IsXYInPositionRange(Point objLocation)
			{
				return IsXInPositionRange(objLocation) && IsYInPositionRange(objLocation);
			}
		}

		/// 
		///
		/// </summary>
		internal class ItemPreRenderingProcessor : ItemProcessor
		{
			/// 
			/// The owner listview
			/// </summary>
			private readonly ListView mobjListView;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemPreRenderingProcessor" /> class.
			/// </summary>
			/// <param name="objListView">The obj list view.</param>
			internal ItemPreRenderingProcessor(ListView objListView)
			{
				mobjListView = objListView;
			}

			/// 
			/// Processes the item.
			/// </summary>
			/// <param name="objItem">The item.</param>
			internal override void ProcessItem(ListViewItem objItem)
			{
				if (mobjListView == null)
				{
					return;
				}
				if (mobjListView.View == View.Details)
				{
					ListViewItem.ListViewSubItemCollection subItems = objItem.SubItems;
					if (subItems == null)
					{
						return;
					}
					{
						foreach (ColumnHeader column in mobjListView.Columns)
						{
							if (column.IsValidColumn && subItems.Count > column.Index)
							{
								ListViewItem.ListViewSubItem objSubItem = subItems[column.Index];
								if (!objItem.UseItemStyleForSubItems || column.Index == 0)
								{
									mobjListView.OnItemFormatting(objItem.Index, column.Index, objSubItem);
								}
							}
						}
						return;
					}
				}
				if (objItem.SubItems.Count > 0)
				{
					mobjListView.OnItemFormatting(objItem.Index, 0, objItem.SubItems[0]);
				}
			}

			/// 
			/// Processes the group.
			/// </summary>
			/// <param name="objGroup">The group.</param>
			internal override void ProcessGroup(ListViewGroup objGroup)
			{
			}
		}

		/// 
		/// Provides a property reference to WrapColumnHeaders property.
		/// </summary>
		private static SerializableProperty WrapColumnHeadersProperty = SerializableProperty.Register("WrapColumnHeaders", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ColumnHeadersHeight property.
		/// </summary>
		private static SerializableProperty ColumnHeadersHeightProperty = SerializableProperty.Register("ColumnHeadersHeight", typeof(int), typeof(ListView), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to DataMember property.
		/// </summary>
		private static SerializableProperty DataMemberProperty = SerializableProperty.Register("DataMember", typeof(string), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to DataSource property.
		/// </summary>
		private static SerializableProperty DataSourceProperty = SerializableProperty.Register("DataSource", typeof(object), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to AutoGenerateColumns property.
		/// </summary>
		private static SerializableProperty AutoGenerateColumnsProperty = SerializableProperty.Register("AutoGenerateColumns", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to TotalPages property.
		/// </summary>
		private static SerializableProperty TotalPagesProperty = SerializableProperty.Register("TotalPages", typeof(int), typeof(ListView), new SerializablePropertyMetadata(1));

		/// 
		/// Provides a property reference to ItemsPerPage property.
		/// </summary>
		private static SerializableProperty ItemsPerPageProperty = SerializableProperty.Register("ItemsPerPage", typeof(int), typeof(ListView), new SerializablePropertyMetadata(20));

		/// 
		/// Provides a property reference to CurrentPage property.
		/// </summary>
		private static SerializableProperty CurrentPageProperty = SerializableProperty.Register("CurrentPage", typeof(int), typeof(ListView), new SerializablePropertyMetadata(1));

		/// 
		/// Provides a property reference to UseInternalPaging property.
		/// </summary>
		private static SerializableProperty UseInternalPagingProperty = SerializableProperty.Register("UseInternalPaging", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to InUpdate property.
		/// </summary>
		private static SerializableProperty InUpdateProperty = SerializableProperty.Register("InUpdate", typeof(int), typeof(ListView), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to TotalItems property.
		/// </summary>
		private static SerializableProperty TotalItemsProperty = SerializableProperty.Register("TotalItems", typeof(int), typeof(ListView), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to SortingColumns property.
		/// </summary>
		private static SerializableProperty SortingColumnsProperty = SerializableProperty.Register("SortingColumns", typeof(ICollection), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to MultiSelect property.
		/// </summary>
		private static SerializableProperty MultiSelectProperty = SerializableProperty.Register("MultiSelect", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to CheckBoxes property. 
		/// </summary>
		private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register("CheckBoxes", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to CheckOnDoubleClick property. 
		/// </summary>
		private static SerializableProperty CheckOnDoubleClickProperty = SerializableProperty.Register("CheckOnDoubleClick", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to StateImageList property.
		/// </summary>
		private static SerializableProperty StateImageListProperty = SerializableProperty.Register("StateImageList", typeof(ImageList), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ImageListSmall property.
		/// </summary>
		private static SerializableProperty ImageListSmallProperty = SerializableProperty.Register("ImageListSmall", typeof(ImageList), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to LargeImageList property.
		/// </summary>
		private static SerializableProperty LargeImageListProperty = SerializableProperty.Register("LargeImageList", typeof(ImageList), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to Columns property.
		/// </summary>
		private static SerializableProperty ColumnsProperty = SerializableProperty.Register("Columns", typeof(ColumnHeaderCollection), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to View property.
		/// </summary>
		private static SerializableProperty ViewProperty = SerializableProperty.Register("View", typeof(View), typeof(ListView), new SerializablePropertyMetadata(View.Details));

		/// 
		/// Provides a property reference to SelectOnRightClick property.
		/// </summary>
		private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to FullRowSelect property.
		/// </summary>
		private static SerializableProperty FullRowSelectProperty = SerializableProperty.Register("FullRowSelect", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to GridLines property.
		/// </summary>
		private static SerializableProperty GridLinesProperty = SerializableProperty.Register("GridLines", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ShowItemToolTips property.
		/// </summary>
		private static SerializableProperty ShowItemToolTipsProperty = SerializableProperty.Register("ShowItemToolTips", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ShowGroups property.
		/// </summary>
		private static SerializableProperty ShowGroupsProperty = SerializableProperty.Register("ShowGroups", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(true));

		/// 
		/// The item sorter of this list
		/// </summary>
		private static readonly SerializableProperty ListViewItemSorterProperty = SerializableProperty.Register("ListViewItemSorter", typeof(IComparer), typeof(ListView), new SerializablePropertyMetadata(null));

		/// 
		/// The header style
		/// </summary>
		private static readonly SerializableProperty ColumnHeaderStyleProperty = SerializableProperty.Register("ColumnHeaderStyle", typeof(ColumnHeaderStyle), typeof(ListView), new SerializablePropertyMetadata(ColumnHeaderStyle.Clickable));

		/// 
		/// Allow Column Reorder
		/// </summary>
		private static readonly SerializableProperty AllowColumnReorderProperty = SerializableProperty.Register("AllowColumnReorder", typeof(bool), typeof(ListView), new SerializablePropertyMetadata(false));

		/// 
		/// The list view data binding complete Serializable Event
		/// </summary>
		internal static readonly SerializableEvent EVENT_LISTVIEWDATABINDINGCOMPLETE = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

		/// 
		/// The list view data member changed Serializable Event
		/// </summary>
		internal static readonly SerializableEvent EVENT_LISTVIEWDATAMEMBERCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

		/// 
		/// The list view data source changed Serializable Event
		/// </summary>
		internal static readonly SerializableEvent EVENT_LISTVIEWDATASOURCECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

		/// 
		/// The list view Column Reordered Serializable Event
		/// </summary>
		private static readonly SerializableEvent EventColumnReordered = SerializableEvent.Register("Event", typeof(Delegate), typeof(ListView));

		/// 
		/// The SelectedIndexChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedIndexChangedEvent;

		/// 
		/// The ItemCheck event registration.
		/// </summary>
		private static readonly SerializableEvent ItemCheckEvent;

		/// 
		/// The ColumnWidthChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ColumnWidthChangedEvent;

		/// 
		/// The AfterLabelEdit event registration.
		/// </summary>
		internal static readonly SerializableEvent AfterLabelEditEvent;

		/// 
		/// The BeforeLabelEdit event registration.
		/// </summary>
		private static readonly SerializableEvent BeforeLabelEditEvent;

		/// 
		/// The listview items collection
		/// </summary>
		[NonSerialized]
		private ListViewItemCollection mobjItems = null;

		/// 
		/// The listview columns collection
		/// </summary>
		[NonSerialized]
		private ColumnHeaderCollection mobjColumns = null;

		/// 
		/// the original item sorting
		/// </summary>
		[NonSerialized]
		private List<object> mobjOriginalItemSorting;

		/// 
		/// The group collection
		/// </summary>
		[NonSerialized]
		private ListViewGroupCollection mobjGroups = null;

		/// 
		/// The column headers resizing mide
		/// </summary>
		private static readonly SerializableProperty HeaderAutoResizeStyleProperty;

		/// 
		/// Gets the hanlder for the SelectedIndexChanged event.
		/// </summary>
		private EventHandler SelectedIndexChangedHandler => (EventHandler)GetHandler(SelectedIndexChanged);

		/// 
		/// Gets the hanlder for the ItemCheck event.
		/// </summary>
		private ItemCheckHandler ItemCheckHandler => (ItemCheckHandler)GetHandler(ItemCheck);

		/// 
		/// Gets the hanlder for the ColumnWidthChanged event.
		/// </summary>
		private ColumnWidthChangedEventHandler ColumnWidthChangedHandler => (ColumnWidthChangedEventHandler)GetHandler(ColumnWidthChanged);

		/// 
		/// Gets the hanlder for the AfterLabelEdit event.
		/// </summary>
		private LabelEditEventHandler AfterLabelEditHandler => (LabelEditEventHandler)GetHandler(AfterLabelEditEvent);

		/// 
		/// Gets the hanlder for the BeforeLabelEdit event.
		/// </summary>
		private LabelEditEventHandler BeforeLabelEditHandler => (LabelEditEventHandler)GetHandler(BeforeLabelEdit);

		/// 
		/// Gets or sets a value indicating whether [allow column reorder].
		/// </summary>
		/// true</c> if [allow column reorder]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		[SRDescription("ListViewAllowColumnReorderDescr")]
		[SRCategory("CatBehavior")]
		public bool AllowColumnReorder
		{
			get
			{
				return GetValue(AllowColumnReorderProperty);
			}
			set
			{
				if (SetValue(AllowColumnReorderProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets a value indicating whether a scroll bar is added to the control when there is not enough room to display all items.</summary>
		/// true if scroll bars are added to the control when necessary to allow the user to see all the items; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(true)]
		[SRDescription("ListViewScrollableDescr")]
		[SRCategory("CatBehavior")]
		public bool Scrollable
		{
			get
			{
				return GetState(ControlState.AutoScroll);
			}
			set
			{
				if (SetStateWithCheck(ControlState.AutoScroll, value))
				{
					Update();
					FireObservableItemPropertyChanged("Scrollable");
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether ToolTips are shown for the ListViewItem objects contained in the ListView. 
		/// </summary>
		/// ShowItemToolTips property must be set true for tooltips to appear.</remarks>
		[DefaultValue(false)]
		public bool ShowItemToolTips
		{
			get
			{
				return GetValue(ShowItemToolTipsProperty);
			}
			set
			{
				SetValue(ShowItemToolTipsProperty, value);
			}
		}

		/// Gets or sets a value indicating whether items are displayed in groups.</summary>
		/// true to display items in groups; otherwise, false. The default value is true.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[SRDescription("ListViewShowGroupsDescr")]
		public bool ShowGroups
		{
			get
			{
				return GetValue(ShowGroupsProperty);
			}
			set
			{
				if (SetValue(ShowGroupsProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the sorting.
		/// </summary>
		/// The sorting.</value>
		[SRCategory("CatBehavior")]
		[DefaultValue(SortOrder.None)]
		[SRDescription("ListViewSortingDescr")]
		public SortOrder Sorting
		{
			get
			{
				if (Columns.Count > 0)
				{
					return Columns[0].SortOrder;
				}
				return SortOrder.None;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(SortOrder));
				}
				if (Columns.Count <= 0)
				{
					return;
				}
				ColumnHeader columnHeader = Columns[0];
				if (columnHeader != null && columnHeader.SortOrder != value)
				{
					columnHeader.SortOrder = value;
					if (value != SortOrder.None)
					{
						Sort();
					}
				}
			}
		}

		/// Gets the item in the control that currently has focus.</summary>
		/// A <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see> that represents the item that has focus, or null if no item has the focus in the <see cref="T:Gizmox.WebGui.Forms.ListView"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ListViewFocusedItemDescr")]
		[SRCategory("CatAppearance")]
		public ListViewItem FocusedItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Set/Gets the activation type (Not implemented).
		/// </summary>
		/// </value>
		[DefaultValue(ItemActivation.Standard)]
		public ItemActivation Activation
		{
			get
			{
				return ItemActivation.Standard;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether grid lines exists.
		/// </summary>
		/// true</c> if has grid lines; otherwise, false</c>.</value>
		[Browsable(true)]
		[SRDescription("ListViewGridLinesDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(false)]
		public bool GridLines
		{
			get
			{
				bool blnFound;
				bool value = GetValue(GridLinesProperty, out blnFound);
				if (!blnFound)
				{
					return ((ListViewSkin)base.Skin).ShowGridLines;
				}
				return value;
			}
			set
			{
				if (SetValue(GridLinesProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [hide selection].
		/// </summary>
		/// true</c> if [hide selection]; otherwise, false</c>.</value>
		[Browsable(true)]
		[DefaultValue(false)]
		public bool HideSelection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Gets the list view item sorter internal value.
		/// </summary>
		/// The list view item sorter internal value.</value>
		private IComparer ListViewItemSorterInternal
		{
			get
			{
				IComparer listViewItemSorter = ListViewItemSorter;
				if (listViewItemSorter == null)
				{
					if (DataSource != null)
					{
						return this;
					}
					return new ListViewItemSorter(this);
				}
				return listViewItemSorter;
			}
		}

		/// 
		/// Gets or sets the list view item sorter.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IComparer ListViewItemSorter
		{
			get
			{
				return GetValue(ListViewItemSorterProperty);
			}
			set
			{
				SetValue(ListViewItemSorterProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether full row select is enabled.
		/// </summary>
		/// 
		/// 	true</c> if full row select is enabled; otherwise, false</c>.
		/// </value>
		[Browsable(true)]
		[DefaultValue(false)]
		public bool FullRowSelect
		{
			get
			{
				return GetValue(FullRowSelectProperty);
			}
			set
			{
				if (SetValue(FullRowSelectProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the list view mode.
		/// </summary>
		/// </value>
		[Browsable(true)]
		[DefaultValue(View.Details)]
		public View View
		{
			get
			{
				return GetValue(ViewProperty);
			}
			set
			{
				if (SetValue(ViewProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("View");
				}
			}
		}

		/// 
		/// Gets the list of tags that client events are propogated to.
		/// </summary>
		/// 
		/// The client event propogated tags.
		/// </value>
		protected override string ClientEventsPropogationTags => string.Format("{0},{1}", "R", "C");

		/// 
		///  Gets the collection of columns contained within the listview.
		/// </summary>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[MergableProperty(false)]
		public ColumnHeaderCollection Columns => mobjColumns;

		/// Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> objects assigned to the control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> that contains all the groups in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[MergableProperty(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[SRDescription("ListViewGroupsDescr")]
		[WebEditor(typeof(ListViewGroupCollectionEditor), typeof(WebUITypeEditor))]
		public ListViewGroupCollection Groups
		{
			get
			{
				if (mobjGroups == null)
				{
					mobjGroups = new ListViewGroupCollection(this);
				}
				return mobjGroups;
			}
		}

		/// 
		///  Gets the collection of items contained within the listview.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ListViewItemCollection Items => mobjItems;

		/// 
		/// Gets or sets the header style.
		/// </summary>
		/// </value>
		[Browsable(true)]
		[DefaultValue(ColumnHeaderStyle.Clickable)]
		public ColumnHeaderStyle HeaderStyle
		{
			get
			{
				return GetValue(ColumnHeaderStyleProperty);
			}
			set
			{
				if (SetValue(ColumnHeaderStyleProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as large icons in the control.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.LargeIcon"></see>. The default is null.</returns>
		/// 2</filterpriority>
		[DefaultValue(null)]
		[SRDescription("ListViewLargeImageListDescr")]
		[SRCategory("CatBehavior")]
		public ImageList LargeImageList
		{
			get
			{
				return GetValue(LargeImageListProperty);
			}
			set
			{
				if (SetValue(LargeImageListProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
		/// 2</filterpriority>
		[SRDescription("ListViewSmallImageListDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(null)]
		public ImageList SmallImageList
		{
			get
			{
				return GetValue(ImageListSmallProperty);
			}
			set
			{
				if (SetValue(ImageListSmallProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> associated with application-defined states in the control.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains a set of state images that can be used to indicate an application-defined state of an item. The default is null.</returns>
		/// 1</filterpriority>
		[SRDescription("ListViewStateImageListDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(null)]
		public ImageList StateImageList
		{
			get
			{
				return GetValue(StateImageListProperty);
			}
			set
			{
				if (SetValue(StateImageListProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether a check box appears next to each item in the control.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(false)]
		public bool CheckBoxes
		{
			get
			{
				return GetValue(CheckBoxesProperty);
			}
			set
			{
				if (SetValue(CheckBoxesProperty, value))
				{
					Update();
				}
				FireObservableItemPropertyChanged("CheckBoxes");
			}
		}

		/// 
		/// Gets or sets a value indicating whether to check CheckBoxes on double click.
		/// </summary>
		/// 
		/// true</c> if check CheckBoxes on double click; otherwise, false</c>.
		/// </value>
		[Browsable(true)]
		[DefaultValue(true)]
		public bool CheckOnDoubleClick
		{
			get
			{
				return GetValue(CheckOnDoubleClickProperty);
			}
			set
			{
				if (SetValue(CheckOnDoubleClickProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether multiple items can be selected.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(true)]
		public bool MultiSelect
		{
			get
			{
				return GetValue(MultiSelectProperty);
			}
			set
			{
				if (SetValue(MultiSelectProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// A collection of columns participating in sorting
		/// </summary>
		internal ICollection SortingColumnsInternal
		{
			get
			{
				return GetValue(SortingColumnsProperty);
			}
			set
			{
				SetValue(SortingColumnsProperty, value);
			}
		}

		/// 
		/// A collection of columns participating in sorting
		/// </summary>
		internal ICollection SortingColumns
		{
			get
			{
				if (SortingColumnsInternal == null)
				{
					ColumnHeaderSortingData columnHeaderSortingData = new ColumnHeaderSortingData(this);
					SortingColumnsInternal = columnHeaderSortingData.SortingColumns;
					columnHeaderSortingData = null;
				}
				return SortingColumnsInternal;
			}
		}

		private CurrencyManager CurrencyManagerInternal
		{
			get
			{
				object dataSource = DataSource;
				string dataMember = DataMember;
				if (dataSource != null)
				{
					if (!string.IsNullOrEmpty(dataMember))
					{
						return BindingContext[dataSource, dataMember] as CurrencyManager;
					}
					return BindingContext[dataSource] as CurrencyManager;
				}
				return null;
			}
		}

		/// 
		/// Gets the currently selected item index.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectedIndex
		{
			get
			{
				ListViewItemCollection items = Items;
				int num = 0;
				foreach (ListViewItem item in items)
				{
					if (item.Selected)
					{
						return num;
					}
					num++;
				}
				return -1;
			}
			set
			{
				bool flag = false;
				int num = 0;
				foreach (ListViewItem item in Items)
				{
					if (value == num)
					{
						if (!item.InternalSelected)
						{
							item.InternalSelected = true;
							flag = true;
							item.Update();
						}
					}
					else if (item.InternalSelected)
					{
						item.InternalSelected = false;
						flag = true;
						item.Update();
					}
					num++;
				}
				if (flag && SelectedIndexChangedHandler != null)
				{
					OnSelectedIndexChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets the selected indices.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public ArrayList SelectedIndices
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				int num = 0;
				foreach (ListViewItem item in Items)
				{
					if (item.Selected)
					{
						arrayList.Add(num);
					}
					num++;
				}
				return arrayList;
			}
		}

		/// 
		/// Gets the currently selected item index.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ListViewItem SelectedItem
		{
			get
			{
				int selectedIndex = SelectedIndex;
				if (selectedIndex != -1)
				{
					return Items[selectedIndex];
				}
				return null;
			}
			set
			{
				int selectedIndex = Items.IndexOf(value);
				SelectedIndex = selectedIndex;
			}
		}

		/// 
		/// Gets or sets the height of the column headers.
		/// </summary>
		/// The height of the column headers.</value>
		[Localizable(false)]
		[DefaultValue(-1)]
		[SRCategory("CatAppearance")]
		[SRDescription("ListView_ColumnHeadersHeightDescr")]
		public int ColumnHeadersHeight
		{
			get
			{
				return GetValue(ColumnHeadersHeightProperty);
			}
			set
			{
				if (SetValue(ColumnHeadersHeightProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [wrap column headers].
		/// </summary>
		/// true</c> if [wrap column headers]; otherwise, false</c>.</value>
		[Localizable(false)]
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("ListView_WrapColumnHeadersDescr")]
		public bool WrapColumnHeaders
		{
			get
			{
				return GetValue(WrapColumnHeadersProperty);
			}
			set
			{
				if (SetValue(WrapColumnHeadersProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets the selected items.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public SelectedListViewItemCollection SelectedItems => new SelectedListViewItemCollection(this);

		/// 
		/// Gets the checked indices.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public ArrayList CheckedIndices
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				int num = 0;
				foreach (ListViewItem item in Items)
				{
					if (item.Checked)
					{
						arrayList.Add(num);
					}
					num++;
				}
				return arrayList;
			}
		}

		/// 
		/// Gets the checked items.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public ArrayList CheckedItems
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (ListViewItem item in Items)
				{
					if (item.Checked)
					{
						arrayList.Add(item);
					}
				}
				return arrayList;
			}
		}

		/// 
		/// Indicates whether the list view is in update mode.
		/// </summary>
		internal int InUpadte
		{
			get
			{
				return GetValue(InUpdateProperty);
			}
			private set
			{
				SetValue(InUpdateProperty, value);
			}
		}

		/// 
		///
		/// </summary>
		protected override bool IsDelayedDrawing => true;

		/// 
		/// Uses internal paging algorithem
		/// </summary>
		[DefaultValue(false)]
		public bool UseInternalPaging
		{
			get
			{
				return GetValue(UseInternalPagingProperty);
			}
			set
			{
				if (SetValue(UseInternalPagingProperty, value))
				{
					Update();
				}
			}
		}

		private int CurrentPageInternal
		{
			get
			{
				return GetValue(CurrentPageProperty);
			}
			set
			{
				SetValue(CurrentPageProperty, value);
			}
		}

		/// 
		/// Gets or sets the current page.
		/// </summary>
		/// </value>
		[DefaultValue(1)]
		public int CurrentPage
		{
			get
			{
				return CurrentPageInternal;
			}
			set
			{
				if (value > -1 && TotalPages >= value)
				{
					if (CurrentPageInternal != value)
					{
						CurrentPageInternal = value;
						if (UseInternalPaging)
						{
							base.ScrollTop = 0;
							Update();
						}
					}
					return;
				}
				throw new ArgumentOutOfRangeException("CurrentPage");
			}
		}

		/// 
		/// Gets or sets the items per page.
		/// </summary>
		/// The items per page.</value>
		[DefaultValue(20)]
		public int ItemsPerPage
		{
			get
			{
				return GetValue(ItemsPerPageProperty);
			}
			set
			{
				if (SetValue(ItemsPerPageProperty, value))
				{
					ClearPaging();
					Update();
				}
			}
		}

		private int TotalPagesInternal
		{
			get
			{
				return GetValue(TotalPagesProperty);
			}
			set
			{
				SetValue(TotalPagesProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [select on right click].
		/// </summary>
		/// true</c> if [select on right click]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		public bool SelectOnRightClick
		{
			get
			{
				return GetValue(SelectOnRightClickProperty);
			}
			set
			{
				if (SetValue(SelectOnRightClickProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the total pages.
		/// </summary>
		/// </value>
		[DefaultValue(1)]
		public int TotalPages
		{
			get
			{
				if (!UseInternalPaging)
				{
					return TotalPagesInternal;
				}
				int num = (int)Math.Ceiling((double)TotalItems / (double)ItemsPerPage);
				if (num < 1)
				{
					num = 1;
				}
				return num;
			}
			set
			{
				if (!UseInternalPaging)
				{
					if (value <= -1)
					{
						throw new ArgumentOutOfRangeException("TotalPages");
					}
					if (TotalPagesInternal != value)
					{
						TotalPagesInternal = value;
						Update();
					}
				}
			}
		}

		/// 
		/// Gets or sets the total items.
		/// </summary>
		/// </value>
		[DefaultValue(0)]
		public int TotalItems
		{
			get
			{
				if (!UseInternalPaging)
				{
					return GetValue(TotalItemsProperty);
				}
				return Items.Count;
			}
			set
			{
				if (value >= 0)
				{
					if (SetValue(TotalItemsProperty, value))
					{
						Update();
					}
					return;
				}
				throw new ArgumentOutOfRangeException("TotalItems");
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(true)]
		public bool UseCompatibleStateImageBehavior
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// Gets or sets the size of the tiles shown in tile view.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that contains the new tile size.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ListViewTileSizeDescr")]
		[SRCategory("CatAppearance")]
		public Size TileSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets the alignment of items in the control.</summary>
		/// One of the <see cref="T:Gizmox.WebGui.Forms.ListViewAlignment"></see> values. The default is <see cref="F:Gizmox.WebGui.Forms.ListViewAlignment.Top"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is not one of the <see cref="T:Gizmox.WebGui.Forms.ListViewAlignment"></see> values. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[SRDescription("ListViewAlignmentDescr")]
		[DefaultValue(ListViewAlignment.Top)]
		[SRCategory("CatBehavior")]
		public ListViewAlignment Alignment
		{
			get
			{
				return ListViewAlignment.Top;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the label text of the list items can be edited.</summary>
		/// true if the label text of the list items can be edited; otherwise, false. The default is false.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ListViewLabelEditDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool LabelEdit
		{
			get
			{
				return GetState(ComponentState.ReadOnly);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.ReadOnly, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new ListViewWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ListViewWinFormsCompatibility;

		/// 
		/// Gets the default row back color
		/// </summary>
		internal Color DefaultRowBackColor => ((ListViewSkin)base.Skin).RowBackColor;

		/// 
		/// Gets the default row back color
		/// </summary>
		internal Color DefaultRowForeColor => ((ListViewSkin)base.Skin).RowForeColor;

		/// 
		/// Gets the default row font.
		/// </summary>
		/// The default row font.</value>
		internal Font DefaultRowFont => ((ListViewSkin)base.Skin).RowFont;

		/// 
		/// Gets or sets if auto column generation is active when using data binding
		/// </summary>
		[Obsolete("Please use the 'AutoGenerateColumns' property instead.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoColumnGeneration
		{
			get
			{
				return AutoGenerateColumns;
			}
			set
			{
				AutoGenerateColumns = value;
			}
		}

		/// 
		/// Gets or sets if auto column generation is active when using data binding
		/// </summary>
		[Browsable(true)]
		[DefaultValue(true)]
		[SRCategory("CatData")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool AutoGenerateColumns
		{
			get
			{
				return GetValue(AutoGenerateColumnsProperty);
			}
			set
			{
				if (SetValue(AutoGenerateColumnsProperty, value))
				{
					Bind();
				}
			}
		}

		/// 
		/// Gets or sets if column auto resizing mode
		/// </summary>
		[DefaultValue(ColumnHeaderAutoResizeStyle.None)]
		[SRCategory("CatData")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public ColumnHeaderAutoResizeStyle ColumnResizeStyle
		{
			get
			{
				return GetValue(HeaderAutoResizeStyleProperty);
			}
			set
			{
				if (SetValue(HeaderAutoResizeStyleProperty, value))
				{
					OnAutoResizeColumns();
				}
			}
		}

		/// 
		/// The listview data source
		/// </summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		[AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
		[SRCategory("CatData")]
		[DefaultValue(null)]
		public object DataSource
		{
			get
			{
				return GetValue(DataSourceProperty, null);
			}
			set
			{
				if (SetValue(DataSourceProperty, value))
				{
					OnDataSourceChanged(EventArgs.Empty);
					Bind();
				}
			}
		}

		/// 
		/// The listview data memeber
		/// </summary>
		[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[DefaultValue("")]
		[SRCategory("CatData")]
		public string DataMember
		{
			get
			{
				return GetValue(DataMemberProperty);
			}
			set
			{
				if (SetValue(DataMemberProperty, value))
				{
					OnDataMemberChanged(EventArgs.Empty);
					Bind();
				}
			}
		}

		/// 
		/// Gets a value indicating whether this listview is binded.
		/// </summary>
		/// true</c> if this listview is binded; otherwise, false</c>.</value>
		private bool IsBinded => DataSource != null;

		/// 
		/// Gets a value indicating whether [data source has bindings].
		/// </summary>
		/// 
		/// 	true</c> if [data source has bindings]; otherwise, false</c>.
		/// </value>
		private bool DataSourceHasBindings
		{
			get
			{
				if (DataSource is BindingSource { CurrencyManager: not null } bindingSource)
				{
					return bindingSource.CurrencyManager.BindingsCount > 0;
				}
				return false;
			}
		}

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize
		{
			get
			{
				int serializableDataInitialSize = base.SerializableDataInitialSize;
				serializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjColumns);
				serializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjItems);
				serializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjOriginalItemSorting);
				return serializableDataInitialSize + SerializationWriter.GetRequiredCapacity(mobjGroups);
			}
		}

		/// 
		/// Occurs when the SelectedIndex property has changed.
		/// </summary>
		public event EventHandler SelectedIndexChanged
		{
			add
			{
				AddCriticalHandler(SelectedIndexChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectedIndexChangedEvent, value);
			}
		}

		/// 
		/// Columns where updated by the user
		/// </summary>
		public event EventHandler ColumnUpdate;

		/// 
		/// Occurs when the checked state of an item changes.
		/// </summary>
		public event ItemCheckHandler ItemCheck
		{
			add
			{
				AddCriticalHandler(ItemCheckEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ItemCheckEvent, value);
			}
		}

		/// 
		/// Occurs when [client paging changed].
		/// </summary>
		[SRDescription("Occurs when control navigated to another page in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientPagingChanged
		{
			add
			{
				AddClientHandler("Navigate", value);
			}
			remove
			{
				RemoveClientHandler("Navigate", value);
			}
		}

		/// 
		/// Occurs when [client selected index changed].
		/// </summary>
		[SRDescription("Occurs when control's selection changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientSelectedIndexChanged
		{
			add
			{
				AddClientHandler("SelectionChange", value);
			}
			remove
			{
				RemoveClientHandler("SelectionChange", value);
			}
		}

		/// 
		/// Occurs when [client item check].
		/// </summary>
		[SRDescription("Occurs when control's item checked state changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientItemCheck
		{
			add
			{
				AddClientHandler("CheckedChange", value);
			}
			remove
			{
				RemoveClientHandler("CheckedChange", value);
			}
		}

		/// 
		/// Occurs when [client column reordered].
		/// </summary>
		[SRDescription("Occurs when control's columns reordered in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientColumnReordered
		{
			add
			{
				AddClientHandler("ColumnsReorder", value);
			}
			remove
			{
				RemoveClientHandler("ColumnsReorder", value);
			}
		}

		/// 
		/// Occurs when [client column reordered].
		/// </summary>
		[SRDescription("Occurs when control's column width changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientColumnWidthChanged
		{
			add
			{
				AddClientHandler("ChangeColumnWidth", value);
			}
			remove
			{
				RemoveClientHandler("ChangeColumnWidth", value);
			}
		}

		/// 
		/// Occurs when an item is activated.
		/// </summary>
		public event EventHandler ItemActivate;

		/// 
		/// Occurs when the paging params have changed.
		/// </summary>
		public event EventHandler PagingChanged;

		/// 
		///
		/// </summary>
		public event ColumnClickEventHandler ColumnClick;

		/// 
		/// Occurs when the column width has changed.
		/// /// </summary>
		public event ColumnWidthChangedEventHandler ColumnWidthChanged
		{
			add
			{
				AddCriticalHandler(ColumnWidthChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ColumnWidthChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [column width changing].
		/// Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).
		/// </summary>
		[Obsolete("Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).")]
		public event ColumnWidthChangedEventHandler ColumnWidthChanging;

		/// 
		/// Occurs when the item is formatting.
		/// will not occurs on sub items when UseItemStyleForSubItems is true
		/// </summary>
		[SRDescription("ListView_ItemFormattingDescr")]
		[SRCategory("CatDisplay")]
		public event ListViewItemFormattingEventHandler ItemFormatting;

		/// 
		/// Occurs when [item binding].
		/// </summary>
		[SRDescription("ListView_ItemBindingDescr")]
		[SRCategory("CatDisplay")]
		public event ListViewItemBindingEventHandler ItemBinding;

		/// 
		/// Occurs when [data binding complete].
		/// </summary>
		[SRDescription("ListView_DataBindingCompleteDescr")]
		[SRCategory("CatData")]
		public event ListViewBindingCompleteEventHandler DataBindingComplete;

		/// Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.DataMember"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("ListViewDataMemberChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler DataMemberChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.DataSource"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("ListViewDataSourceChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler DataSourceChanged;

		/// 
		/// Occurs when [column reordered].
		/// </summary>
		[SRDescription("ListViewColumnReorderedDscr")]
		[SRCategory("CatPropertyChanged")]
		public event ColumnReorderedEventHandler ColumnReordered
		{
			add
			{
				AddHandler(EventColumnReordered, value);
			}
			remove
			{
				RemoveHandler(EventColumnReordered, value);
			}
		}

		/// Occurs after the list item label text is edited.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("ListViewAfterLabelEditDescr")]
		public event LabelEditEventHandler AfterLabelEdit
		{
			add
			{
				AddCriticalHandler(AfterLabelEditEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AfterLabelEditEvent, value);
			}
		}

		/// Occurs before the tree node label text is edited.</summary>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event LabelEditEventHandler BeforeLabelEdit
		{
			add
			{
				AddHandler(BeforeLabelEditEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeLabelEditEvent, value);
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView" /> instance.
		/// </summary>
		public ListView()
		{
			SetStyle(ControlStyles.UserPaint, blnValue: false);
			SetStyle(ControlStyles.StandardClick, blnValue: false);
			SetStyle(ControlStyles.UseTextForAccessibility, blnValue: false);
			SetState(ControlState.AutoScroll, blnValue: true);
			mobjColumns = new ColumnHeaderCollection(this);
			mobjItems = new ListViewItemCollection(this);
			mobjOriginalItemSorting = new List<object>();
		}

		/// 
		/// Resets the current sorting columns collection to enforce recreation of the collection
		/// </summary>
		internal void ResetSortingColumns()
		{
			SortingColumnsInternal = null;
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RegisterComponent(this);
			RegisterBatch(Columns);
			RegisterBatch(Items);
			objWriter.WriteAttributeString("VW", View.ToString());
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			if (!Scrollable)
			{
				objWriter.WriteAttributeString("SB", "0");
			}
			if (FullRowSelect)
			{
				objWriter.WriteAttributeString("FRS", "1");
			}
			ImageList largeImageList = LargeImageList;
			ImageList smallImageList = SmallImageList;
			if (largeImageList != null && View == View.LargeIcon)
			{
				objWriter.WriteAttributeString("LIW", largeImageList.ImageSize.Width.ToString());
				objWriter.WriteAttributeString("LIH", largeImageList.ImageSize.Height.ToString());
			}
			else if (smallImageList != null && View == View.SmallIcon)
			{
				objWriter.WriteAttributeString("IW", smallImageList.ImageSize.Width.ToString());
				objWriter.WriteAttributeString("IH", smallImageList.ImageSize.Height.ToString());
			}
			objWriter.WriteAttributeString("CP", CurrentPage.ToString());
			objWriter.WriteAttributeString("TOP", TotalPages.ToString());
			objWriter.WriteAttributeString("HDS", Convert.ToInt32(HeaderStyle).ToString());
			if (CheckBoxes)
			{
				objWriter.WriteAttributeString("CB", "1");
			}
			if (CheckOnDoubleClick)
			{
				objWriter.WriteAttributeString("CODC", "1");
			}
			if (MultiSelect)
			{
				objWriter.WriteAttributeString("MU", "1");
			}
			if (GridLines)
			{
				objWriter.WriteAttributeString("GL", "1");
			}
			RenderControls(objContext, objWriter, 0L);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderAllowColumnReorder(objWriter, blnForceRender: false);
			RenderSelectOnRightClick(objWriter, blnForceRender: false);
			RenderEditingInformation(objWriter, blnForceRender: false);
			objWriter.WriteAttributeString("IMH", GetPreferdControlItemHeight().ToString());
			objWriter.WriteAttributeString("LVSGLOER", WinFormsCompatibility.ShowGridLinesOnEmptyRows ? "1" : "0");
			if (View == View.Details)
			{
				objWriter.WriteAttributeString("HH", GetColumnHeaderHeight().ToString());
				if (WrapColumnHeaders)
				{
					objWriter.WriteAttributeString("WC", "1");
				}
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
		{
			RenderContent(objContext, objWriter, lngRequestID, blnFullRedraw);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RenderContent(objContext, objWriter, lngRequestID, blnFullRedraw: true);
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			ProcessVisibleItemsAndGroups(new ItemPreRenderingProcessor(this), blnGroupsShouldBeRendered: false);
			base.PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Renders the content.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnFullRedraw">if set to true</c> full redraw.</param>
		private void RenderContent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
		{
			foreach (ColumnHeader sortedColumn in Columns.SortedColumns)
			{
				sortedColumn.RenderColumn(objContext, objWriter, lngRequestID);
			}
			ProcessVisibleItemsAndGroups(new ItemRenderingProcessor(this, objContext, objWriter, lngRequestID, blnFullRedraw), IsDirty(lngRequestID));
		}

		/// 
		/// Processes the visible items and groups.
		/// </summary>
		/// <param name="blnGroupdShouldBeRendered">
		/// A flag indicating if current group should be rendered
		/// this value is by default true only if is in dirty mode
		/// otherwise we do not need to render groups
		/// </param>
		/// </returns>
		private void ProcessVisibleItemsAndGroups(ItemProcessor objProcessor, bool blnGroupsShouldBeRendered)
		{
			if (!objProcessor.IsProcessingStillNeeded)
			{
				return;
			}
			int itemsPerPage = ItemsPerPage;
			int num = 0;
			int num2 = (CurrentPageInternal - 1) * itemsPerPage;
			int num3 = num2 + itemsPerPage;
			ListViewGroupCollection groupsToRender = GetGroupsToRender();
			if (groupsToRender == null)
			{
				foreach (ListViewItem item in Items)
				{
					if (!objProcessor.IsProcessingStillNeeded)
					{
						break;
					}
					if (UseInternalPaging)
					{
						if (num >= num2)
						{
							if (num >= num3)
							{
								break;
							}
							objProcessor.ProcessItem(item);
						}
					}
					else
					{
						objProcessor.ProcessItem(item);
					}
					num++;
				}
				return;
			}
			bool flag = blnGroupsShouldBeRendered;
			foreach (ListViewItem item2 in Items)
			{
				if (!objProcessor.IsProcessingStillNeeded)
				{
					return;
				}
				if (item2.Group != null && Groups.Contains(item2.Group))
				{
					continue;
				}
				if (UseInternalPaging)
				{
					if (num >= num2)
					{
						if (num >= num3)
						{
							break;
						}
						if (flag)
						{
							objProcessor.ProcessGroup(null);
							flag = false;
						}
						objProcessor.ProcessItem(item2);
					}
				}
				else
				{
					if (flag)
					{
						objProcessor.ProcessGroup(null);
						flag = false;
					}
					objProcessor.ProcessItem(item2);
				}
				num++;
			}
			foreach (ListViewGroup item3 in groupsToRender)
			{
				flag = blnGroupsShouldBeRendered;
				foreach (ListViewItem item4 in Items)
				{
					if (item4.Group != item3)
					{
						continue;
					}
					if (UseInternalPaging)
					{
						if (num >= num2)
						{
							if (num >= num3)
							{
								break;
							}
							if (flag)
							{
								objProcessor.ProcessGroup(item4.Group);
								flag = false;
							}
							objProcessor.ProcessItem(item4);
						}
					}
					else
					{
						if (flag)
						{
							objProcessor.ProcessGroup(item3);
							flag = false;
						}
						objProcessor.ProcessItem(item4);
					}
					num++;
				}
			}
		}

		/// 
		/// Renders the group.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objListViewGroup">The list view group.</param>
		private void RenderGroup(IContext objContext, IResponseWriter objWriter, ListViewGroup objListViewGroup, ItemRenderingProcessor objProcessor)
		{
			objWriter.WriteStartElement("G");
			if (objListViewGroup != null)
			{
				objWriter.WriteAttributeText("TX", objListViewGroup.Header, (TextFilter)5);
			}
			else
			{
				objWriter.WriteAttributeString("TX", "Default");
			}
			objWriter.WriteEndElement();
		}

		/// 
		/// Gets a collection of groups if should render groups.
		/// </summary>
		/// </returns>
		private ListViewGroupCollection GetGroupsToRender()
		{
			if (ShowGroups && mobjGroups != null && mobjGroups.Count > 0)
			{
				return mobjGroups;
			}
			return null;
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			objWriter.WriteAttributeString("CB", CheckBoxes ? "1" : "0");
			objWriter.WriteAttributeString("CODC", CheckOnDoubleClick ? "1" : "0");
			objWriter.WriteAttributeString("MU", MultiSelect ? "1" : "0");
			objWriter.WriteAttributeString("GL", GridLines ? "1" : "0");
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderEditingInformation(objWriter, blnForceRender: true);
				RenderAllowColumnReorder(objWriter, blnForceRender: true);
				RenderSelectOnRightClick(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the editing information.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [force render].</param>
		protected void RenderEditingInformation(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (LabelEdit || blnForceRender)
			{
				objWriter.WriteAttributeString("LE", LabelEdit ? "1" : "0");
			}
		}

		/// 
		/// Renders the select on right click.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (SelectOnRightClick)
			{
				objWriter.WriteAttributeString("SOR", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SOR", "0");
			}
		}

		/// 
		/// Renders the allow column reorder.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> force render.</param>
		private void RenderAllowColumnReorder(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (AllowColumnReorder)
			{
				objWriter.WriteAttributeString("AOC", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("AOC", "0");
			}
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objProposedSize">The proposed size.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			return objProposedSize;
		}

		/// 
		/// Layout the internal controls to reflect parent changes
		/// </summary>
		/// <param name="objEventArgs">The layout arguments.</param>
		/// <param name="objNewSize">The new parent size.</param>
		/// <param name="objOldSize">The old parent size.</param>
		protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
		{
		}

		/// 
		/// Gets the height of the preferd item font.
		/// </summary>
		/// </returns>
		internal int GetPreferdItemFontHeight(bool blnIsHeader)
		{
			if (base.Skin is ListViewSkin listViewSkin)
			{
				PaddingValue paddingValue = null;
				paddingValue = ((!blnIsHeader) ? listViewSkin.CellNormalStyle.Padding : listViewSkin.HeaderNormalStyle.Padding);
				int num = 0;
				if (paddingValue != null)
				{
					num = paddingValue.Vertical + (blnIsHeader ? 7 : 0);
				}
				return Math.Max(listViewSkin.CheckBoxButtonHeight, CommonUtils.GetFontHeight(GetProxyPropertyValue("Font", Font))) + num;
			}
			return 0;
		}

		/// 
		/// Raises the <see cref="E:ItemFormatting" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs" /> instance containing the event data.</param>
		protected virtual void OnItemFormatting(ListViewItemFormattingEventArgs e)
		{
			this.ItemFormatting?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ItemBinding" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs" /> instance containing the event data.</param>
		private void OnItemBinding(ListViewItemBindingEventArgs e)
		{
			this.ItemBinding?.Invoke(this, e);
		}

		internal void OnItemFormatting(int intItemIndex, int intColumnIndex, ListViewItem.ListViewSubItem objSubItem)
		{
			ListViewItemFormattingEventArgs e = new ListViewItemFormattingEventArgs(intItemIndex, intColumnIndex, objSubItem);
			OnItemFormatting(e);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="blnValid"></param>
		internal void FireUpdateColumns(bool blnValid)
		{
			this.ColumnUpdate?.Invoke(this, new EventArgs());
		}

		/// 
		/// Fires the selected index changed.
		/// </summary>
		/// <param name="objListViewItem">The obj list view item.</param>
		internal void FireSelectedIndexChanged(ListViewItem objListViewItem)
		{
			OnSelectedIndexChanged(new ListViewItemEventArgs(objListViewItem));
		}

		/// 
		/// Raises the <see cref="E:SelectedIndexChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnSelectedIndexChanged(EventArgs e)
		{
			CurrencyManager currencyManagerInternal = CurrencyManagerInternal;
			SelectedIndexChangedHandler?.Invoke(this, e);
			if (currencyManagerInternal != null && mobjOriginalItemSorting != null && SelectedItem != null)
			{
				currencyManagerInternal.Position = mobjOriginalItemSorting.IndexOf(SelectedItem);
			}
		}

		/// 
		/// Internals the column width changed.
		/// </summary>
		/// <param name="ColumnIndex">Index of the column.</param>
		internal void InternalColumnWidthChanged(int ColumnIndex)
		{
			ColumnWidthChangedEventArgs e = new ColumnWidthChangedEventArgs(ColumnIndex);
			OnColumnWidthChanging(e);
			OnColumnWidthChanged(e);
		}

		/// 
		/// Raises the <see cref="E:ColumnWidthChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs" /> instance containing the event data.</param>
		protected virtual void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
		{
			ColumnWidthChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs" /> instance containing the event data.</param>
		[Obsolete("Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).")]
		protected virtual void OnColumnWidthChanging(ColumnWidthChangedEventArgs e)
		{
			this.ColumnWidthChanging?.Invoke(this, e);
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			ColumnHeaderCollection columns = Columns;
			ListViewItemCollection items = Items;
			if (columns != null)
			{
				RegisterBatch(columns);
			}
			if (items != null)
			{
				RegisterBatch(items);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			ColumnHeaderCollection columns = Columns;
			ListViewItemCollection items = Items;
			if (columns != null)
			{
				UnRegisterBatch(columns);
			}
			if (items != null)
			{
				UnRegisterBatch(items);
			}
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			Type type = Type.GetType(strOffspringTypeName);
			if (type != null)
			{
				if (CommonUtils.IsTypeOrSubType(type, typeof(ListViewItem)))
				{
					return Items;
				}
				if (CommonUtils.IsTypeOrSubType(type, typeof(ColumnHeader)))
				{
					return Columns;
				}
			}
			return base.GetComponentOffsprings(strOffspringTypeName);
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new ListViewRenderer(this);
		}

		/// 
		/// Fires the item check.
		/// </summary>
		/// <param name="objListViewItem">The obj list view item.</param>
		/// <param name="blnChecked">if set to true</c> [BLN checked].</param>
		internal void FireItemCheck(ListViewItem objListViewItem, bool blnChecked)
		{
			if (ItemCheckHandler != null)
			{
				ListViewItemCollection items = Items;
				if (blnChecked)
				{
					ItemCheckHandler(this, new ItemCheckEventArgs(items.IndexOf(objListViewItem), CheckState.Checked, CheckState.Unchecked));
				}
				else
				{
					ItemCheckHandler(this, new ItemCheckEventArgs(items.IndexOf(objListViewItem), CheckState.Unchecked, CheckState.Checked));
				}
			}
		}

		/// 
		///
		/// </summary>
		protected internal virtual void OnItemDoubleClick(ListViewItem objListViewItem, MouseEventArgs objMouseEventArgs)
		{
			OnDoubleClick(objMouseEventArgs);
		}

		/// 
		///
		/// </summary>
		protected internal virtual void OnItemClick(ListViewItem objListViewItem, MouseEventArgs objMouseEventArgs)
		{
			OnClick(objMouseEventArgs);
		}

		/// 
		/// Fires the swipe.
		/// </summary>
		/// <param name="enmSwipeDirection">The swipe direction.</param>
		protected internal virtual void OnItemSwipe(ListViewItem objListViewItem, SwipeDirection enmSwipeDirection)
		{
			OnSwipe(enmSwipeDirection);
		}

		/// 
		/// Gets the relative XY from item.
		/// </summary>
		/// <param name="objItem">The list view item.</param>
		/// <param name="intX">The X position.</param>
		/// <param name="intY">The Y position</param>
		/// </returns>
		internal void GetRelativeXYFromItem(ListViewItem objItem, ref int intX, ref int intY)
		{
			ItemLayoutProcessor itemLayoutProcessor = new ItemLayoutProcessor(this, objItem);
			ProcessVisibleItemsAndGroups(itemLayoutProcessor, blnGroupsShouldBeRendered: true);
			intX = itemLayoutProcessor.ItemLocation.X + intX;
			intY = itemLayoutProcessor.ItemLocation.Y + intY;
		}

		/// 
		/// Gets the item from relative XY.
		/// </summary>
		/// <param name="intX">The X position.</param>
		/// <param name="intY">The Y position</param>
		/// </returns>
		private ListViewItem GetItemFromRelativeXY(int intX, int intY)
		{
			ItemLayoutProcessor itemLayoutProcessor = new ItemLayoutProcessor(this, new Point(intX, intY));
			ProcessVisibleItemsAndGroups(itemLayoutProcessor, blnGroupsShouldBeRendered: true);
			return itemLayoutProcessor.Item;
		}

		/// Retrieves the item at the specified location.</summary>
		/// A <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see> that represents the item at the specified position. If there is no item at the specified location, the method returns null.</returns>
		/// <param name="intY">The y-coordinate of the location to search for an item (expressed in client coordinates). </param>
		/// <param name="intX">The x-coordinate of the location to search for an item (expressed in client coordinates). </param>
		/// 1</filterpriority>
		public ListViewItem GetItemAt(int intX, int intY)
		{
			return GetItemFromRelativeXY(intX, intY);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			bool flag = false;
			switch (objEvent.Type)
			{
			case "SelectionChange":
				SelectIndexes(objEvent["Indexes"], objEvent["Incremental"] == "1");
				break;
			case "CheckedChange":
				CheckIndexes(objEvent["Indexes"]);
				break;
			case "Navigate":
			{
				string text = objEvent["To"];
				switch (text)
				{
				case "End":
					CurrentPage = TotalPages;
					break;
				case "Home":
					CurrentPage = 1;
					break;
				case "Next":
					if (CurrentPage < TotalPages)
					{
						CurrentPage++;
					}
					break;
				case "Back":
					if (CurrentPage > 1)
					{
						CurrentPage--;
					}
					break;
				default:
				{
					if (int.TryParse(text, out var result) && result > 0 && result <= TotalPages)
					{
						CurrentPage = result;
					}
					break;
				}
				}
				if (this.PagingChanged != null)
				{
					this.PagingChanged(this, new EventArgs());
				}
				break;
			}
			case "SelectNone":
				foreach (ListViewItem item in Items)
				{
					if (item.Selected)
					{
						item.Selected = false;
						flag = true;
					}
				}
				break;
			case "SelectAll":
				foreach (ListViewItem item2 in Items)
				{
					if (!item2.Selected)
					{
						item2.Selected = true;
						flag = true;
					}
				}
				break;
			case "CheckAll":
				foreach (ListViewItem item3 in Items)
				{
					if (!item3.Checked)
					{
						item3.Checked = true;
						flag = true;
					}
				}
				break;
			case "CheckNone":
				foreach (ListViewItem item4 in Items)
				{
					if (item4.Checked)
					{
						item4.Checked = false;
						flag = true;
					}
				}
				break;
			case "ColumnsReorder":
			{
				if (!objEvent.Contains("DCN") || !objEvent.Contains("TCN"))
				{
					break;
				}
				int num = Convert.ToInt32(objEvent["DCN"]);
				int num2 = Convert.ToInt32(objEvent["TCN"]);
				int num3 = -1;
				int num4 = -1;
				foreach (ColumnHeader column in Columns)
				{
					if (column.ID == num)
					{
						num3 = column.Index;
					}
					else if (column.ID == num2)
					{
						num4 = column.Index;
					}
				}
				if (num3 < 0 || num3 >= Columns.Count || num4 < 0 || num4 >= Columns.Count)
				{
					break;
				}
				int num5 = Columns[num4].DisplayIndex;
				int displayIndex = Columns[num3].DisplayIndex;
				if (displayIndex > num5)
				{
					num5++;
				}
				if (displayIndex != num5)
				{
					ColumnReorderedEventArgs e = new ColumnReorderedEventArgs(displayIndex, num5, Columns[num3]);
					((ColumnReorderedEventHandler)GetHandler(EventColumnReordered))?.Invoke(this, e);
					if (!e.Cancel)
					{
						Columns[num3].DisplayIndex = num5;
						Columns.ClearSortedColumns();
						flag = true;
					}
				}
				break;
			}
			}
			base.FireEvent(objEvent);
			if (flag)
			{
				Update();
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (SelectedIndexChangedHandler != null || DataSourceHasBindings)
			{
				criticalEventsData.Set("SLC");
			}
			if (ItemCheckHandler != null)
			{
				criticalEventsData.Set("CC");
			}
			if (ColumnWidthChangedHandler != null)
			{
				criticalEventsData.Set("CCW");
			}
			if (AfterLabelEditHandler != null)
			{
				criticalEventsData.Set("ALE");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("SelectionChange"))
			{
				criticalClientEventsData.Set("SLC");
			}
			if (HasClientHandler("CheckedChange"))
			{
				criticalClientEventsData.Set("CC");
			}
			if (HasClientHandler("ChangeColumnWidth"))
			{
				criticalClientEventsData.Set("CCW");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Gets the critical events internal.
		/// </summary>
		/// </returns>
		internal CriticalEventsData GetCriticalEventsDataInternal()
		{
			return GetCriticalEventsData();
		}

		/// Ensures that the specified item is visible within the control, scrolling the contents of the control if necessary.</summary>
		/// <param name="index">The zero-based index of the item to scroll into view. </param>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void EnsureVisible(int index)
		{
			if (index < 0 || index >= Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
			}
			Items[index].EnsureVisible();
		}

		/// 
		/// Removes all items and columns from the control.
		/// </summary>
		public void Clear()
		{
			Items.Clear();
			Columns.Clear();
		}

		/// 
		/// Selects the indexes.
		/// </summary>
		/// <param name="strIndexes">STR indexes.</param>
		/// <param name="blnIncremental">if set to true</c> [BLN incremental].</param>
		private void SelectIndexes(string strIndexes, bool blnIncremental)
		{
			bool flag = false;
			ListViewOrederedItems listViewOrederedItems = new ListViewOrederedItems(this);
			int num = 0;
			int num2 = listViewOrederedItems.Count - 1;
			int itemsPerPage = ItemsPerPage;
			if (UseInternalPaging)
			{
				num = (CurrentPageInternal - 1) * itemsPerPage;
				num2 = num + itemsPerPage - 1;
				if (num2 > listViewOrederedItems.Count - 1)
				{
					num2 = listViewOrederedItems.Count - 1;
				}
			}
			if (!blnIncremental)
			{
				for (int i = 0; i < listViewOrederedItems.Count; i++)
				{
					if (listViewOrederedItems[i].InternalSelected)
					{
						listViewOrederedItems[i].InternalSelected = false;
						flag = true;
					}
				}
			}
			else
			{
				for (int j = num; j <= num2; j++)
				{
					if (listViewOrederedItems[j].InternalSelected)
					{
						listViewOrederedItems[j].InternalSelected = false;
						flag = true;
					}
				}
			}
			if (strIndexes != string.Empty)
			{
				string[] array = strIndexes.Split(',');
				string[] array2 = array;
				foreach (string s in array2)
				{
					int num3 = int.Parse(s);
					if (!listViewOrederedItems[num3 + num].InternalSelected)
					{
						listViewOrederedItems[num3 + num].InternalSelected = true;
						flag = true;
					}
				}
			}
			if (flag)
			{
				OnSelectedIndexChanged(EventArgs.Empty);
			}
		}

		/// 
		/// Checks the indexes.
		/// </summary>
		/// <param name="strIndexes">indexes.</param>
		private void CheckIndexes(string strIndexes)
		{
			ArrayList arrayList = new ArrayList(strIndexes.Split(','));
			ListViewOrederedItems listViewOrederedItems = new ListViewOrederedItems(this);
			int num = 0;
			int num2 = listViewOrederedItems.Count - 1;
			if (UseInternalPaging)
			{
				int itemsPerPage = ItemsPerPage;
				num = (CurrentPageInternal - 1) * itemsPerPage;
				num2 = num + itemsPerPage - 1;
				if (num2 > listViewOrederedItems.Count - 1)
				{
					num2 = listViewOrederedItems.Count - 1;
				}
			}
			List<object> list = new List<object><object>(num2 + 1 - num);
			for (int i = num; i <= num2; i++)
			{
				list.Add(listViewOrederedItems[i].InternalChecked);
			}
			for (int j = num; j <= num2; j++)
			{
				if (arrayList.Contains((j - num).ToString()))
				{
					if (!list[j - num])
					{
						listViewOrederedItems[j].InternalChecked = true;
						if (ItemCheckHandler != null)
						{
							ItemCheckHandler(this, new ItemCheckEventArgs(Items.IndexOf(listViewOrederedItems[j]), CheckState.Checked, CheckState.Unchecked));
						}
					}
				}
				else if (list[j - num])
				{
					listViewOrederedItems[j].InternalChecked = false;
					if (ItemCheckHandler != null)
					{
						ItemCheckHandler(this, new ItemCheckEventArgs(Items.IndexOf(listViewOrederedItems[j]), CheckState.Unchecked, CheckState.Checked));
					}
				}
			}
		}

		/// 
		/// Gets the height of the column header.
		/// </summary>
		/// </returns>
		private int GetColumnHeaderHeight()
		{
			int num = ColumnHeadersHeight;
			if (num == -1)
			{
				num = ((ListViewSkin)base.Skin).HeaderHeight;
				if (num == -1)
				{
					num = GetPreferdItemFontHeight(blnIsHeader: true);
				}
			}
			return num;
		}

		/// 
		/// Gets the preferd height of the control item.
		/// </summary>
		/// <param name="intPreferedItemHeight">The preferd height of the item.</param>
		/// </returns>
		private int GetPreferdControlItemHeight()
		{
			int preferdItemFontHeight = GetPreferdItemFontHeight(blnIsHeader: false);
			int num = 0;
			foreach (ColumnHeader column in Columns)
			{
				if (column.Type == ListViewColumnType.Control)
				{
					num = Math.Max(num, column.PreferedItemHeight);
				}
			}
			return Math.Max(preferdItemFontHeight, num);
		}

		/// 
		/// Flags that the listview is currently going through updates.
		/// </summary>
		public void BeginUpdate()
		{
			InUpadte++;
		}

		/// 
		/// Finish batch updates and flags that the listview has finished updates.
		/// </summary>
		public void EndUpdate()
		{
			if (InUpadte <= 0)
			{
				return;
			}
			InUpadte--;
			if (InUpadte != 0)
			{
				return;
			}
			foreach (ColumnHeader column in Columns)
			{
				column.Width = column.InternalWidth;
			}
		}

		/// 
		///
		/// </summary>
		internal void ClearPaging()
		{
			CurrentPageInternal = 1;
			TotalPagesInternal = 1;
		}

		/// 
		/// Sort the list view by this column
		/// </summary>
		/// <param name="objColumn"></param>
		internal void SortBy(ColumnHeader objColumn)
		{
			foreach (ColumnHeader column in Columns)
			{
				if (column == objColumn)
				{
					if (column.SortOrder == SortOrder.Ascending)
					{
						column.SortOrder = SortOrder.Descending;
					}
					else
					{
						column.SortOrder = SortOrder.Ascending;
					}
					column.SortPosition = 0;
				}
				else
				{
					column.SortOrder = SortOrder.None;
					column.SortPosition = 1000;
				}
			}
			if (this.ColumnClick != null)
			{
				OnColumnClick(new ColumnClickEventArgs(objColumn.Index));
			}
			else
			{
				Sort();
			}
		}

		/// 
		/// Sorts this list items.
		/// </summary>
		public virtual void Sort()
		{
			Items.Sort();
		}

		/// 
		///
		/// </summary>
		internal void FireGroup()
		{
			ApplyGrouping();
		}

		/// 
		/// Apply grouping
		/// </summary>
		protected virtual void ApplyGrouping()
		{
		}

		/// Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</summary>
		/// The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
		/// <param name="strText">The text to search for.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public ListViewItem FindItemWithText(string strText)
		{
			if (Items.Count == 0)
			{
				return null;
			}
			return FindItemWithText(strText, blnIncludeSubItemsInSearch: true, 0, blnIsPrefixSearch: true);
		}

		/// Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> or <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.</summary>
		/// The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
		/// <param name="blnIncludeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
		/// <param name="intStartIndex">The index of the item at which to start the search.</param>
		/// <param name="strText">The text to search for.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is less 0 or more than the number items in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public ListViewItem FindItemWithText(string strText, bool blnIncludeSubItemsInSearch, int intStartIndex)
		{
			return FindItemWithText(strText, blnIncludeSubItemsInSearch, intStartIndex, blnIsPrefixSearch: true);
		}

		/// Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> or <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.</summary>
		/// The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
		/// <param name="blnIsPrefixSearch">true to return match the text to the text prefix of an item; otherwise, false. </param>
		/// <param name="blnIncludeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
		/// <param name="intStartIndex">The index of the item at which to start the search.</param>
		/// <param name="strText">The text to search for.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is less 0 or more than the number of items in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public ListViewItem FindItemWithText(string strText, bool blnIncludeSubItemsInSearch, int intStartIndex, bool blnIsPrefixSearch)
		{
			if (intStartIndex < 0 || intStartIndex >= Items.Count)
			{
				throw new ArgumentOutOfRangeException("startIndex", SR.GetString("InvalidArgument", "startIndex", intStartIndex.ToString(CultureInfo.CurrentCulture)));
			}
			return FindItem(blnIsTextSearch: true, strText, blnIsPrefixSearch, new Point(0, 0), SearchDirectionHint.Down, intStartIndex, blnIncludeSubItemsInSearch);
		}

		/// 
		/// Finds the item.
		/// </summary>
		/// <param name="blnIsTextSearch">if set to true</c> is text search.</param>
		/// <param name="strText">The text to search for.</param>
		/// <param name="blnIsPrefixSearch">if set to true</c> return match the text to the text prefix of an item.</param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmSearchDirectionHint">The enm search direction hint.</param>
		/// <param name="intStartIndex">The index of the item at which to start the search.</param>
		/// <param name="blnIncludeSubItemsInSearch">if set to true</c> include subitems in the search.</param>
		/// </returns>
		private ListViewItem FindItem(bool blnIsTextSearch, string strText, bool blnIsPrefixSearch, Point objPoint, SearchDirectionHint enmSearchDirectionHint, int intStartIndex, bool blnIncludeSubItemsInSearch)
		{
			if (Items.Count != 0)
			{
				int num = 0;
				if (!base.IsHandleCreated)
				{
					return null;
				}
				if (blnIsTextSearch)
				{
					for (int i = intStartIndex; i < Items.Count; i++)
					{
						ListViewItem listViewItem = Items[i];
						num = ((!blnIncludeSubItemsInSearch) ? 1 : listViewItem.SubItems.Count);
						for (int j = 0; j < num; j++)
						{
							ListViewItem.ListViewSubItem listViewSubItem = listViewItem.SubItems[j];
							if (string.Equals(strText, listViewSubItem.Text, StringComparison.OrdinalIgnoreCase))
							{
								return listViewItem;
							}
							if (blnIsPrefixSearch && CultureInfo.CurrentCulture.CompareInfo.IsPrefix(listViewSubItem.Text, strText, CompareOptions.IgnoreCase))
							{
								return listViewItem;
							}
						}
					}
				}
			}
			return null;
		}

		/// Resizes the width of the given column as indicated by the resize style.</summary>
		/// <param name="intColumnIndex">The zero-based index of the column to resize.</param>
		/// <param name="enmHeaderAutoResize">One of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle"></see> values.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">headerAutoResize is not a member of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle"></see> enumeration.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is greater than 0 when <see cref="P:Gizmox.WebGUI.Forms.ListView.Columns"></see> is null-or-columnIndex is less than 0 or greater than the number of columns set.</exception>
		public void AutoResizeColumn(int intColumnIndex, ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
		{
			SetColumnWidth(intColumnIndex, enmHeaderAutoResize);
		}

		internal int GetColumnFixedWidth(int intColumnIndex, int intInternalWidth, bool blnIsAutoResizeStyle)
		{
			int result = 0;
			string empty = string.Empty;
			int num = 1;
			int num2 = 1;
			ColumnHeader columnHeader = null;
			bool flag = false;
			bool flag2 = false;
			ColumnHeaderCollection columns = Columns;
			if (intColumnIndex < 0 || (intColumnIndex >= 0 && columns == null) || intColumnIndex >= columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex", SR.GetString("InvalidArgument", "columnIndex", intColumnIndex.ToString(CultureInfo.CurrentCulture)));
			}
			columnHeader = columns[intColumnIndex];
			if (columnHeader != null && columnHeader.Type != ListViewColumnType.Icon)
			{
				if (blnIsAutoResizeStyle)
				{
					flag2 = intInternalWidth == 1;
					flag = flag2 || intInternalWidth == 2;
				}
				else if (intInternalWidth < 0)
				{
					flag = true;
					flag2 = intInternalWidth == -2;
				}
				if (flag)
				{
					foreach (ListViewItem item in Items)
					{
						ListViewItem.ListViewSubItem listViewSubItem = item.SubItems[columnHeader.Index];
						if (listViewSubItem != null && listViewSubItem.Text != null)
						{
							string text = listViewSubItem.Text;
							int width = CommonUtils.GetStringMeasurements(text, listViewSubItem.Font).Width;
							if (width > num)
							{
								num = width;
							}
						}
					}
				}
				if (flag2)
				{
					num2 = CommonUtils.GetStringMeasurements(columnHeader.Text, Font).Width;
				}
				if (flag2 && flag)
				{
					result = Math.Max(num2, num);
				}
				else if (!flag2 && flag)
				{
					result = num;
				}
				else if (flag2 && !flag)
				{
					result = num2;
				}
			}
			return result;
		}

		internal void SetColumnWidth(int intColumnIndex, ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
		{
			ColumnHeader columnHeader = null;
			ColumnHeaderCollection columns = Columns;
			if (intColumnIndex < 0 || (intColumnIndex >= 0 && columns == null) || intColumnIndex >= columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex", SR.GetString("InvalidArgument", "columnIndex", intColumnIndex.ToString(CultureInfo.CurrentCulture)));
			}
			columnHeader = Columns[intColumnIndex];
			if (columnHeader != null && columnHeader.Type != ListViewColumnType.Icon)
			{
				columnHeader.Width = GetColumnFixedWidth(intColumnIndex, (int)enmHeaderAutoResize, blnIsAutoResizeStyle: true);
			}
		}

		/// 
		/// Gets the current item display index
		/// </summary>
		/// <param name="objListViewItem"></param>
		/// </returns>
		internal int GetDisplayIndex(ListViewItem objListViewItem)
		{
			return Items?.IndexOf(objListViewItem) ?? (-1);
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is ColumnHeader)
			{
				Columns.Add((ColumnHeader)objValue);
			}
			else if (objValue is ListViewItem)
			{
				Items.Add((ListViewItem)objValue);
			}
			else
			{
				base.AddChild(objValue);
			}
		}

		/// 
		/// Raises the <see cref="E:ColumnClick" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ColumnClickEventArgs" /> instance containing the event data.</param>
		protected virtual void OnColumnClick(ColumnClickEventArgs e)
		{
			if (this.ColumnClick != null)
			{
				this.ColumnClick(this, e);
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.AfterLabelEdit"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs"></see> that contains the event data.</param>
		protected virtual void OnAfterLabelEdit(LabelEditEventArgs e)
		{
			AfterLabelEditHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.BeforeLabelEdit"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs"></see> that contains the event data. </param>
		protected virtual void OnBeforeLabelEdit(LabelEditEventArgs e)
		{
			BeforeLabelEditHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:AfterLabelEditInternal" /> event.
		/// </summary>
		/// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.ListViewItemLabelEditEventArgs" /> instance containing the event data.</param>
		internal void OnAfterLabelEditInternal(LabelEditEventArgs e)
		{
			OnAfterLabelEdit(e);
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new ListViewWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "ListViewShowGridLinesOnEmptyRows")
			{
				Update();
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BindingContextChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnBindingContextChanged(EventArgs e)
		{
			if (IsBinded)
			{
				Bind();
			}
		}

		private void Bind()
		{
			Bind(null);
		}

		private bool ShoudRegenerateColumns(ListChangedEventArgs objBindArgs)
		{
			if (objBindArgs != null)
			{
				return objBindArgs.ListChangedType == ListChangedType.Reset;
			}
			return true;
		}

		private bool ShouldRegenerateItems(ListChangedEventArgs objBindArgs)
		{
			if (objBindArgs != null)
			{
				return objBindArgs.ListChangedType == ListChangedType.Reset;
			}
			return true;
		}

		/// 
		/// Gets the property descriptor.
		/// </summary>
		/// <param name="strPropertyName">Name of the property.</param>
		/// </returns>
		private PropertyDescriptor GetPropertyDescriptor(string strPropertyName)
		{
			PropertyDescriptor result = null;
			if (!string.IsNullOrEmpty(strPropertyName))
			{
				object dataSource = DataSource;
				if (dataSource != null)
				{
					IList dataSourceList = GetDataSourceList(dataSource);
					if (dataSourceList != null && !(dataSourceList is DataViewManager))
					{
						PropertyDescriptorCollection listItemProperties = ListBindingHelper.GetListItemProperties(dataSourceList);
						if (listItemProperties != null)
						{
							result = listItemProperties[strPropertyName];
						}
					}
				}
			}
			return result;
		}

		/// 
		/// Bind listview to data
		/// </summary>        
		private void Bind(ListChangedEventArgs objBindArgs)
		{
			if (BindingContext == null)
			{
				return;
			}
			bool flag = ShoudRegenerateColumns(objBindArgs);
			bool flag2 = ShouldRegenerateItems(objBindArgs);
			if (AutoGenerateColumns && flag)
			{
				if (base.DesignMode)
				{
					foreach (ColumnHeader column in Columns)
					{
						UnregisterInDesignMode(column);
					}
				}
				Columns.Clear();
			}
			if (flag2)
			{
				Items.Clear();
				mobjOriginalItemSorting.Clear();
			}
			object dataSource = DataSource;
			if (dataSource == null)
			{
				return;
			}
			IList dataSourceList = GetDataSourceList(dataSource);
			if (objBindArgs == null)
			{
				OnUnWireCurrencyEvents();
				OnWireCurrencyEvents();
			}
			if (dataSourceList == null || dataSourceList is DataViewManager)
			{
				return;
			}
			PropertyDescriptorCollection listItemProperties = ListBindingHelper.GetListItemProperties(dataSourceList);
			if (listItemProperties != null)
			{
				foreach (PropertyDescriptor item in listItemProperties)
				{
					if (AutoGenerateColumns && flag)
					{
						ColumnHeader columnHeader = OnGetColumn(item);
						if (columnHeader != null)
						{
							columnHeader.Tag = item.Name;
							RegisterInDesignMode(columnHeader, item.Name);
							Columns.Add(columnHeader);
						}
					}
				}
				if (flag2)
				{
					for (int i = 0; i < dataSourceList.Count; i++)
					{
						object obj = dataSourceList[i];
						if (obj != null)
						{
							CreateOrUpdateBindableItem(obj, i, null);
						}
					}
					OnAutoResizeColumns();
				}
				else if (objBindArgs != null)
				{
					switch (objBindArgs.ListChangedType)
					{
					case ListChangedType.ItemAdded:
						CreateOrUpdateBindableItem(dataSourceList[objBindArgs.NewIndex], objBindArgs.NewIndex, null);
						break;
					case ListChangedType.ItemDeleted:
						Items.RemoveAt(objBindArgs.NewIndex);
						break;
					case ListChangedType.ItemChanged:
					{
						object obj2 = dataSourceList[objBindArgs.NewIndex];
						if (obj2 != null)
						{
							ListViewItem listViewItem = Items[objBindArgs.NewIndex];
							if (listViewItem != null && !object.Equals(listViewItem.DataItemIndex, objBindArgs.NewIndex))
							{
								listViewItem = GetListViewItemByBindableItemIndex(objBindArgs.NewIndex);
							}
							if (listViewItem != null)
							{
								CreateOrUpdateBindableItem(obj2, objBindArgs.NewIndex, listViewItem);
							}
						}
						break;
					}
					}
				}
				CurrencyManager currencyManagerInternal = CurrencyManagerInternal;
				if (currencyManagerInternal != null && SelectedIndex != currencyManagerInternal.Position)
				{
					SelectedIndex = currencyManagerInternal.Position;
					if (SelectedItem != null)
					{
						SelectedItem.EnsureVisible();
					}
				}
			}
			OnDataBindingComplete(ListChangedType.Reset);
		}

		/// 
		/// Gets the data source list.
		/// </summary>
		/// <param name="objDataSource">The data source.</param>
		/// </returns>
		private IList GetDataSourceList(object objDataSource)
		{
			IList list = null;
			if (DataMember == null)
			{
				return ListBindingHelper.GetList(objDataSource) as IList;
			}
			return ListBindingHelper.GetList(objDataSource, DataMember) as IList;
		}

		/// 
		/// Get the matched list view item by bindable item
		/// </summary>
		/// <param name="intBindableItemIndex">Index of the int bindable item.</param>
		/// </returns>
		private ListViewItem GetListViewItemByBindableItemIndex(int intBindableItemIndex)
		{
			ListViewItem result = null;
			foreach (ListViewItem item in Items)
			{
				if (object.Equals(item.DataItemIndex, intBindableItemIndex))
				{
					result = item;
					break;
				}
			}
			return result;
		}

		private void CreateOrUpdateBindableItem(object objItem, int intItemIndex, ListViewItem objExistingListViewItem)
		{
			int num = 0;
			ListViewItem listViewItem = objExistingListViewItem;
			foreach (ColumnHeader column in Columns)
			{
				PropertyDescriptor propertyDescriptor = null;
				if (column.Tag != null)
				{
					propertyDescriptor = GetPropertyDescriptor(Convert.ToString(column.Tag));
				}
				string text = "";
				if (propertyDescriptor != null)
				{
					text = OnGetCellValue(objItem, propertyDescriptor);
				}
				if (num == 0)
				{
					if (listViewItem == null)
					{
						listViewItem = Items.Add(text);
						listViewItem.DataItemIndex = intItemIndex;
						mobjOriginalItemSorting.Add(listViewItem);
					}
					else
					{
						listViewItem.Text = text;
					}
				}
				else if (objExistingListViewItem == null)
				{
					listViewItem.SubItems.Add(text);
				}
				else if (listViewItem.SubItems.Count > num)
				{
					listViewItem.SubItems[num].Text = text;
				}
				num++;
			}
			OnRowFormating(objItem, listViewItem);
			OnItemBinding(new ListViewItemBindingEventArgs(objItem, listViewItem));
		}

		/// 
		/// Called when [row formating].
		/// </summary>
		/// <param name="objRow">The row.</param>
		/// <param name="objListViewItem">The list view item.</param>
		protected virtual void OnRowFormating(object objRow, ListViewItem objListViewItem)
		{
		}

		/// 
		/// Do column resizing
		/// </summary>
		private void OnAutoResizeColumns()
		{
			if (IsBinded && ColumnResizeStyle != ColumnHeaderAutoResizeStyle.None)
			{
				for (int i = 0; i < Columns.Count; i++)
				{
					AutoResizeColumn(i, ColumnResizeStyle);
				}
			}
		}

		/// 
		/// Unwire currency manager event
		/// </summary>
		private void OnUnWireCurrencyEvents()
		{
			CurrencyManager currencyManagerInternal = CurrencyManagerInternal;
			if (currencyManagerInternal != null)
			{
				currencyManagerInternal.PositionChanged -= OnCurrencyManagerPositionChanged;
				currencyManagerInternal.ListChanged -= OnCurrencyManagerListChanged;
			}
		}

		/// 
		/// Wire currency manager events
		/// </summary>
		private void OnWireCurrencyEvents()
		{
			CurrencyManager currencyManagerInternal = CurrencyManagerInternal;
			if (currencyManagerInternal != null)
			{
				currencyManagerInternal.PositionChanged += OnCurrencyManagerPositionChanged;
				currencyManagerInternal.ListChanged += OnCurrencyManagerListChanged;
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCurrencyManagerPositionChanged(object sender, EventArgs e)
		{
			CurrencyManager currencyManagerInternal = CurrencyManagerInternal;
			if (currencyManagerInternal.Position >= mobjOriginalItemSorting.Count)
			{
				return;
			}
			if (currencyManagerInternal.Position > -1 && currencyManagerInternal.Position < mobjOriginalItemSorting.Count && mobjOriginalItemSorting.IndexOf(SelectedItem) > -1)
			{
				ListViewItem listViewItem = mobjOriginalItemSorting[currencyManagerInternal.Position];
				if (SelectedItem != listViewItem)
				{
					SelectedItem = listViewItem;
					Update();
				}
			}
			else
			{
				SelectedIndex = -1;
				Update();
			}
		}

		/// 
		/// Handle list change events
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCurrencyManagerListChanged(object sender, ListChangedEventArgs e)
		{
			Bind(e);
		}

		/// 
		/// Get column from property
		/// </summary>
		/// <param name="objProperty"></param>
		/// </returns>
		protected virtual ColumnHeader OnGetColumn(PropertyDescriptor objProperty)
		{
			bool flag = false;
			TypeConverter converter = objProperty.Converter;
			if (converter != null && converter.CanConvertTo(typeof(string)))
			{
				flag = true;
			}
			if (flag)
			{
				return OnCreateColumn(objProperty);
			}
			return null;
		}

		/// 
		/// Creates the column
		/// </summary>
		/// <param name="objProperty"></param>
		/// </returns>
		protected virtual ColumnHeader OnCreateColumn(PropertyDescriptor objProperty)
		{
			ColumnHeader columnHeader = new ColumnHeader();
			columnHeader.Label = objProperty.DisplayName;
			columnHeader.Width = 100;
			return columnHeader;
		}

		/// 
		/// Register column header in design mode
		/// </summary>
		/// <param name="objColumn"></param>
		/// <param name="strName"></param>
		private void RegisterInDesignMode(ColumnHeader objColumn, string strName)
		{
			if (base.DesignMode && Site != null && Site.Container != null && objColumn.Site == null)
			{
				Site.Container.Add(objColumn, GetSafeName(strName, Site.Container));
			}
		}

		/// 
		/// Get safe name for column header
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="objContainer"></param>
		/// </returns>
		private string GetSafeName(string strName, IContainer objContainer)
		{
			Regex regex = new Regex("[^a-zA-Z0-9]", RegexOptions.CultureInvariant);
			string text = "column" + regex.Replace(strName, "_");
			if (objContainer.Components[text] == null)
			{
				return text;
			}
			int num = 1;
			while (objContainer.Components[text + num] != null)
			{
				num++;
			}
			return text + num;
		}

		/// 
		/// Unregister column header in design mode
		/// </summary>
		/// <param name="objColumn"></param>
		private void UnregisterInDesignMode(ColumnHeader objColumn)
		{
			if (base.DesignMode && Site != null && Site.Container != null && objColumn.Site != null)
			{
				Site.Container.Remove(objColumn);
			}
		}

		/// 
		/// Gets the row item value
		/// </summary>
		/// <param name="objRow"></param>
		/// <param name="objProperty"></param>
		/// </returns>
		protected virtual object OnGetCellValueAsObject(object objRow, PropertyDescriptor objProperty)
		{
			if (objProperty != null && objRow != null)
			{
				return objProperty.GetValue(objRow);
			}
			return null;
		}

		/// 
		/// Gets the row item value
		/// </summary>
		/// <param name="objRow"></param>
		/// <param name="objProperty"></param>
		/// </returns>
		protected virtual string OnGetCellValue(object objRow, PropertyDescriptor objProperty)
		{
			object obj = OnGetCellValueAsObject(objRow, objProperty);
			string result = "";
			if (obj != null)
			{
				TypeConverter converter = objProperty.Converter;
				result = ((converter == null) ? obj.ToString() : ((string)objProperty.Converter.ConvertTo(obj, typeof(string))));
			}
			return result;
		}

		/// 
		/// Called when [data binding complete].
		/// </summary>
		/// <param name="enmListChangedType">Type of the list changed.</param>
		internal void OnDataBindingComplete(ListChangedType enmListChangedType)
		{
			OnDataBindingComplete(new ListViewBindingCompleteEventArgs(enmListChangedType));
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
		protected virtual void OnDataBindingComplete(ListViewBindingCompleteEventArgs e)
		{
			ListViewBindingCompleteEventHandler listViewBindingCompleteEventHandler = this.DataBindingComplete;
			if (listViewBindingCompleteEventHandler != null && !base.IsDisposed)
			{
				listViewBindingCompleteEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataMemberChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDataMemberChanged(EventArgs e)
		{
			EventHandler eventHandler = this.DataMemberChanged;
			if (eventHandler != null && !base.IsDisposed)
			{
				eventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataSourceChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDataSourceChanged(EventArgs e)
		{
			EventHandler eventHandler = this.DataSourceChanged;
			if (eventHandler != null && !base.IsDisposed)
			{
				eventHandler(this, e);
			}
		}

		/// 
		/// Compares two ListView Items
		/// </summary>
		/// <param name="objObjectA">object A.</param>
		/// <param name="objObjectB">object B.</param>
		/// </returns>
		int IComparer.Compare(object objObjectA, object objObjectB)
		{
			ListViewItem listViewItem = objObjectA as ListViewItem;
			ListViewItem listViewItem2 = objObjectB as ListViewItem;
			ICollection sortingColumns = SortingColumns;
			if (listViewItem != null && listViewItem2 != null)
			{
				int dataItemIndex = listViewItem.DataItemIndex;
				int dataItemIndex2 = listViewItem2.DataItemIndex;
				if (dataItemIndex >= 0 && dataItemIndex2 >= 0)
				{
					object dataSource = DataSource;
					if (dataSource != null)
					{
						IList dataSourceList = GetDataSourceList(dataSource);
						if (dataSourceList != null)
						{
							object objRow = dataSourceList[dataItemIndex];
							object objRow2 = dataSourceList[dataItemIndex2];
							if (sortingColumns.Count > 0)
							{
								foreach (ColumnHeader item in sortingColumns)
								{
									PropertyDescriptor propertyDescriptor = GetPropertyDescriptor(Convert.ToString(item.Tag));
									if (propertyDescriptor == null)
									{
										continue;
									}
									object obj = OnGetCellValueAsObject(objRow, propertyDescriptor);
									object obj2 = OnGetCellValueAsObject(objRow2, propertyDescriptor);
									if (object.Equals(obj, obj2))
									{
										continue;
									}
									if (obj != null && obj2 != null && obj != DBNull.Value && obj2 != DBNull.Value)
									{
										if (obj is IComparable comparable)
										{
											int num = comparable.CompareTo(obj2);
											if (num != 0)
											{
												return num * ((item.SortOrder == SortOrder.Ascending) ? 1 : (-1));
											}
										}
									}
									else
									{
										if ((obj == null || obj == DBNull.Value) && obj2 != null && obj2 != DBNull.Value)
										{
											return -1;
										}
										if (obj != null && obj != DBNull.Value && (obj2 == null || obj2 == DBNull.Value))
										{
											return 1;
										}
									}
								}
							}
						}
					}
				}
			}
			return 0;
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mobjColumns = new ColumnHeaderCollection(this, objReader.ReadArray());
			mobjItems = new ListViewItemCollection(this, objReader.ReadArray());
			mobjGroups = new ListViewGroupCollection(this, objReader.ReadArray());
			mobjOriginalItemSorting = new List<object>(objReader.ReadArray());
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteArray(mobjColumns);
			objWriter.WriteArray(mobjItems);
			objWriter.WriteArray(mobjGroups);
			objWriter.WriteArray(mobjOriginalItemSorting);
		}

		/// 
		/// Gets the sub item rect.
		/// </summary>
		/// <param name="intItemIndex">Index of the int item.</param>
		/// <param name="intSubItemIndex">Index of the int sub item.</param>
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// intItemIndex
		/// or
		/// intSubItemIndex
		/// </exception>
		internal Rectangle GetSubItemRect(int intItemIndex, int intSubItemIndex)
		{
			if (View != View.Details)
			{
				return Rectangle.Empty;
			}
			if (intItemIndex < 0 || intItemIndex >= Items.Count)
			{
				throw new ArgumentOutOfRangeException("intItemIndex", SR.GetString("InvalidArgument", "intItemIndex", intItemIndex.ToString(CultureInfo.CurrentCulture)));
			}
			int count = Items[intItemIndex].SubItems.Count;
			if (intSubItemIndex < 0 || intSubItemIndex >= count)
			{
				throw new ArgumentOutOfRangeException("intSubItemIndex", SR.GetString("InvalidArgument", "intSubItemIndex", intSubItemIndex.ToString(CultureInfo.CurrentCulture)));
			}
			int preferdControlItemHeight = GetPreferdControlItemHeight();
			int num = 0;
			int num2 = GetColumnHeaderHeight();
			int num3 = Columns[0].Width;
			if (CheckBoxes)
			{
				ListViewSkin listViewSkin = base.Skin as ListViewSkin;
				num3 += 22 + listViewSkin.HeaderSeperatorWidth;
			}
			for (int i = 0; i < intSubItemIndex; i++)
			{
				num += ((i == 0) ? num3 : Columns[i].Width);
			}
			for (int j = 0; j < intItemIndex; j++)
			{
				num2 += preferdControlItemHeight;
			}
			num2 -= base.ScrollTop;
			num -= base.ScrollLeft;
			return Rectangle.FromLTRB(num, num2, num + ((intSubItemIndex == 0) ? num3 : Columns[intSubItemIndex].Width), num2 + preferdControlItemHeight);
		}

		/// 
		/// Gets the item rect.
		/// </summary>
		/// <param name="index">The index.</param>
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index</exception>
		public Rectangle GetItemRect(int index)
		{
			if (index < 0 || index >= Items.Count)
			{
				throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
			}
			int preferdControlItemHeight = GetPreferdControlItemHeight();
			int num = 0;
			int num2 = 0;
			int num3 = GetColumnHeaderHeight();
			for (int i = 0; i < Columns.Count; i++)
			{
				num2 += Columns[i].Width;
			}
			for (int j = 0; j < index; j++)
			{
				num3 += preferdControlItemHeight;
			}
			num3 -= base.ScrollTop;
			num -= base.ScrollLeft;
			return Rectangle.FromLTRB(num, num3, num + num2, num3 + preferdControlItemHeight);
		}

		static ListView()
		{
			SelectedIndexChanged = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ListView));
			ItemCheck = SerializableEvent.Register("ItemCheck", typeof(ItemCheckHandler), typeof(ListView));
			ColumnWidthChanged = SerializableEvent.Register("ColumnWidthChanged", typeof(ColumnWidthChangedEventHandler), typeof(ListView));
			AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof(LabelEditEventHandler), typeof(ListView));
			BeforeLabelEdit = SerializableEvent.Register("BeforeLabelEdit", typeof(LabelEditEventHandler), typeof(ListView));
			HeaderAutoResizeStyleProperty = SerializableProperty.Register("HeaderAutoResizeStyle", typeof(ColumnHeaderAutoResizeStyle), typeof(ListView), new SerializablePropertyMetadata(ColumnHeaderAutoResizeStyle.None));
		}
	}
}
