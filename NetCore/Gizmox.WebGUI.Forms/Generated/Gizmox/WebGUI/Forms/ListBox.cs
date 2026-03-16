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
	/// Implementation of ListBox class.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ListBox), "ListBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[MetadataTag("LX")]
	[Skin(typeof(ListBoxSkin))]
	public class ListBox : ListControl
	{
		/// 
		///
		/// </summary>
		internal class ListBoxItem
		{
			/// 
			/// The listbox item state
			/// </summary>
			[Flags]
			internal enum ItemState
			{
				/// 
				/// The list state enum 
				/// </summary>
				Selected = 1
			}

			/// 
			/// The list state
			/// </summary>
			[NonSerialized]
			private int mintState = 0;

			/// 
			///
			/// </summary>
			[NonSerialized]
			private object mobjItem;

			/// 
			///
			/// </summary>
			[NonSerialized]
			private CheckState menmCheckState = CheckState.Unchecked;

			/// 
			/// Gets or sets the item.
			/// </summary>
			/// The item.</value>
			public object Item
			{
				get
				{
					return mobjItem;
				}
				set
				{
					mobjItem = value;
				}
			}

			/// 
			/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> is selected.
			/// </summary>
			/// true</c> if selected; otherwise, false</c>.</value>
			public bool Selected
			{
				get
				{
					return GetState(ItemState.Selected);
				}
				set
				{
					SetState(ItemState.Selected, value);
				}
			}

			/// 
			/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> is checked.
			/// </summary>
			/// true</c> if checked; otherwise, false</c>.</value>
			public CheckState CheckState
			{
				get
				{
					return menmCheckState;
				}
				set
				{
					menmCheckState = value;
				}
			}

			/// 
			/// Gets or sets the state.
			/// </summary>
			/// The state.</value>
			internal int State
			{
				get
				{
					return mintState;
				}
				set
				{
					mintState = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> class.
			/// </summary>
			/// <param name="objItem">The item.</param>
			public ListBoxItem(object objItem)
			{
				mobjItem = objItem;
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> class.
			/// </summary>
			/// <param name="objItem">The item.</param>
			public ListBoxItem(object objItem, int intState)
			{
				mobjItem = objItem;
				mintState = intState;
			}

			/// 
			/// Sets the state.
			/// </summary>
			/// <param name="enmState">The flag to set.</param>
			/// <param name="blnValue">The flag value to set.</param>
			internal void SetState(ItemState enmState, bool blnValue)
			{
				mintState = (blnValue ? (mintState | (int)enmState) : (mintState & (int)(~enmState)));
			}

			/// 
			/// Gets the state.
			/// </summary>
			/// <param name="enmState">The state to get.</param>
			/// </returns>
			internal bool GetState(ItemState enmState)
			{
				return ((uint)mintState & (uint)enmState) != 0;
			}
		}

		/// 
		/// The list box object collection
		/// </summary>
		public class ObjectCollection : ICollection, IEnumerable, IList
		{
			[Serializable]
			internal class ObjectCollectionComparer : IComparer<ListBox.ListBoxItem>
			{
				private ListBox mobjListControl = null;

				internal ObjectCollectionComparer(ListBox objListControl)
				{
					mobjListControl = objListControl;
				}

				int IComparer<ListBoxItem>.Compare(ListBoxItem? objFirstListBoxItem, ListBoxItem? objSecondListBoxItem)
				{
					if (objFirstListBoxItem == null)
					{
						if (objSecondListBoxItem == null)
						{
							return 0;
						}
						return -1;
					}
					if (objSecondListBoxItem == null)
					{
						return 1;
					}
					object item = objFirstListBoxItem.Item;
					object item2 = objSecondListBoxItem.Item;
					if (item == null)
					{
						if (item2 == null)
						{
							return 0;
						}
						return -1;
					}
					if (item2 == null)
					{
						return 1;
					}
					string itemText = mobjListControl.GetItemText(item);
					string itemText2 = mobjListControl.GetItemText(item2);
					return Application.CurrentCulture.CompareInfo.Compare(itemText, itemText2, CompareOptions.StringSort);
				}
			}

			/// 
			/// The owner tab control
			/// </summary>
			internal List<ListBoxItem> mobjList = null;

			/// 
			/// The object collection parent control
			/// </summary>
			private ListBox mobjParent = null;

			/// 
			/// Gets a value indicating whether access to the collection is synchronized (thread safe).
			/// </summary>
			/// false in all cases.</returns>
			public bool IsSynchronized => false;

			/// 
			/// Gets the number of items in the collection.
			/// </summary>
			/// The number of items in the collection </returns>
			public int Count => mobjList.Count;

			/// 
			/// Gets the sync root.
			/// </summary>
			/// An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see>.</returns>
			public object SyncRoot => mobjList;

			/// 
			/// Gets or sets the item at the specified index within the collection.
			/// </summary>
			/// An object representing the item located at the specified index within the collection.</returns>
			/// <param name="intIndex">The index of the item in the collection to get or set. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[Browsable(false)]
			public object this[int intIndex]
			{
				get
				{
					return mobjList[intIndex].Item;
				}
				set
				{
					mobjParent.CheckNoDataSource();
					if (mobjList[intIndex].Item != value)
					{
						mobjList[intIndex].Item = value;
						if (mobjParent != null)
						{
							mobjParent.Update();
						}
					}
				}
			}

			/// 
			/// Gets the parent listbox
			/// </summary>
			private ListBox InternalListBox => mobjParent;

			/// 
			/// Gets a value indicating whether the collection is read-only.
			/// </summary>
			/// true if this collection is read-only; otherwise, false.</returns>
			public bool IsReadOnly => false;

			/// 
			/// Gets a value indicating whether the collection has a fixed size.
			/// </summary>
			/// true in all cases.</returns>
			public bool IsFixedSize => false;

			/// 
			/// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see>.
			/// </summary>
			/// <param name="objParent">The <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that owns the collection. </param>
			internal ObjectCollection(ListBox objParent)
			{
				mobjList = new List<ListBoxItem>();
				mobjParent = objParent;
			}

			/// 
			/// Sorts the items using an internal comparer which compares by text
			/// </summary>
			internal void InternalSort()
			{
				mobjList.Sort(new ObjectCollectionComparer(mobjParent));
			}

			/// 
			/// Copies the entire collection into an existing array of objects at a specified location within the array.
			/// </summary>
			/// <param name="intArrayIndex">The location within the destination array to copy the items from the collection to. </param>
			/// <param name="objDestinationArray">The object array in which the items from the collection are copied to. </param>
			public void CopyTo(Array objDestinationArray, int intArrayIndex)
			{
				for (int i = intArrayIndex; i < mobjList.Count; i++)
				{
					objDestinationArray.SetValue(mobjList[i].Item, i);
				}
			}

			/// 
			/// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
			/// </summary>
			/// The zero-based index of the item in the collection, or -1 if <see cref="M:Gizmox.WebGUI.Forms.ListBox.BeginUpdate"></see> has been called.</returns>
			/// <param name="objObject">An object representing the item to add to the collection. </param>
			/// <exception cref="T:System.SystemException">There is insufficient space available to add the new item to the list. </exception>
			public int Add(object objObject)
			{
				mobjParent.CheckNoDataSource();
				int num = -1;
				if (IsItemValid(objObject))
				{
					num = AddInternal(objObject);
					mobjParent.Update();
					return num;
				}
				throw new ArgumentException(GetItemInvalidMessage(objObject));
			}

			/// 
			/// Add to internal list with or with out sorting
			/// </summary>
			/// <param name="objItem">The obj item.</param>
			/// </returns>
			private int AddInternal(object objItem)
			{
				if (objItem == null)
				{
					throw new ArgumentNullException("item");
				}
				return AddInternal(new ListBoxItem(objItem));
			}

			/// 
			/// Adds the internal.
			/// </summary>
			/// <param name="objListBoxItem">The obj list box item.</param>
			/// </returns>
			internal int AddInternal(ListBoxItem objListBoxItem)
			{
				int num = -1;
				if (!mobjParent.Sorted)
				{
					mobjList.Add(objListBoxItem);
					num = mobjList.IndexOf(objListBoxItem);
				}
				else
				{
					if (Count > 0)
					{
						num = mobjList.BinarySearch(objListBoxItem, new ObjectCollectionComparer(mobjParent));
						if (num < 0)
						{
							num = ~num;
						}
					}
					else
					{
						num = 0;
					}
					mobjList.Insert(num, objListBoxItem);
				}
				return num;
			}

			/// 
			/// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
			/// </summary>
			/// <param name="arrObjects">The obj objects.</param>
			internal void AddRangeInternal(object[] arrObjects)
			{
				foreach (object objItem in arrObjects)
				{
					if (IsItemValid(objItem))
					{
						AddInternal(objItem);
						continue;
					}
					throw new ArgumentException(GetItemInvalidMessage(objItem));
				}
				mobjParent.Update();
			}

			/// 
			/// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
			/// </summary>
			/// <param name="arrObjects">An array of objects to add to the list. </param>
			public void AddRange(object[] arrObjects)
			{
				mobjParent.CheckNoDataSource();
				AddRangeInternal(arrObjects);
			}

			/// 
			/// Determines whether item is valid.
			/// </summary>
			/// <param name="objItem">The item to check validite.</param>
			/// 
			/// 	true</c> if valid item; otherwise, false</c>.
			/// </returns>
			protected virtual bool IsItemValid(object objItem)
			{
				return true;
			}

			/// 
			/// Gets the item invalid message.
			/// </summary>
			/// <param name="objItem">The item to check validite.</param>
			/// </returns>
			protected virtual string GetItemInvalidMessage(object objItem)
			{
				return "";
			}

			/// 
			/// Adds the items of an existing <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> to the list of items in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
			/// </summary>
			/// <param name="objObjects">A <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> to load into this collection. </param>
			public void AddRange(ICollection objObjects)
			{
				mobjParent.CheckNoDataSource();
				AddRangeInternal(objObjects);
			}

			/// 
			/// Adds the range internal.
			/// </summary>
			/// <param name="objObjects">The obj objects.</param>
			internal void AddRangeInternal(ICollection objObjects)
			{
				foreach (object objObject in objObjects)
				{
					if (IsItemValid(objObject))
					{
						AddInternal(objObject);
						continue;
					}
					throw new ArgumentException(GetItemInvalidMessage(objObject));
				}
				mobjParent.Update();
			}

			/// 
			/// Sets the item with a new value
			/// </summary>
			/// <param name="index">The index.</param>
			/// <param name="objValue">The value.</param>
			internal void SetItemInternal(int index, object objValue)
			{
				if (objValue == null)
				{
					throw new ArgumentNullException("value");
				}
				if (index < 0 || index >= mobjList.Count)
				{
					throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString()));
				}
				mobjList[index].Item = objValue;
				mobjParent.Update();
			}

			internal int GetRequiredSerializationCapacity()
			{
				return mobjList.Count * 2 + 1;
			}

			/// 
			/// Called when listbox is serializing].
			/// </summary>
			/// <param name="objWriter">The serialization writer.</param>
			internal void OnSerializableObjectSerializing(SerializationWriter objWriter)
			{
				objWriter.WriteInt32(mobjList.Count);
				for (int i = 0; i < mobjList.Count; i++)
				{
					ListBoxItem listBoxItem = mobjList[i];
					if (listBoxItem != null)
					{
						objWriter.WriteObject(listBoxItem.Item);
						objWriter.WriteInt32(listBoxItem.State);
						objWriter.WriteInt32((int)listBoxItem.CheckState);
					}
					else
					{
						objWriter.WriteObject(null);
						objWriter.WriteInt32(0);
						objWriter.WriteInt32(0);
					}
				}
			}

			/// 
			/// Called when listbox is deserializing.
			/// </summary>
			/// <param name="objReader">The serialization reader.</param>
			internal void OnSerializableObjectDeserializing(SerializationReader objReader)
			{
				mobjList = new List<ListBoxItem>();
				int num = objReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListBoxItem listBoxItem = new ListBoxItem(objReader.ReadObject(), objReader.ReadInt32());
					listBoxItem.CheckState = (CheckState)objReader.ReadInt32();
					mobjList.Add(listBoxItem);
				}
			}

			/// 
			/// Clears the selected items.
			/// </summary>
			internal void ClearSelectedItems()
			{
				List<ListBoxItem> list = mobjList.FindAll((ListBoxItem objListBoxItem) => objListBoxItem.Selected);
				if (list == null)
				{
					return;
				}
				foreach (ListBoxItem item in list)
				{
					if (item.Selected)
					{
						item.Selected = false;
					}
				}
			}

			/// 
			/// Removes the specified object from the collection.
			/// </summary>
			/// <param name="objItem">An object representing the item to remove from the collection. </param>
			public virtual void Remove(object objItem)
			{
				ListBoxItem listBoxItemByItem = GetListBoxItemByItem(objItem);
				if (listBoxItemByItem != null)
				{
					int num = mobjList.IndexOf(listBoxItemByItem);
					if (num != -1)
					{
						RemoveAt(num);
					}
				}
			}

			/// 
			/// Gets the list box item by item.
			/// </summary>
			/// <param name="objItem">The obj item.</param>
			/// </returns>
			internal ListBoxItem GetListBoxItemByItem(object objItem)
			{
				return mobjList.Find(delegate(ListBoxItem objListBoxItem)
				{
					if (objListBoxItem.Item == null && objItem == null)
					{
						return true;
					}
					return (objListBoxItem.Item != null || objItem == null) && (objListBoxItem.Item == null || objItem != null) && objListBoxItem.Item.Equals(objItem);
				});
			}

			/// 
			/// Returns an enumerator to use to iterate through the item collection.
			/// </summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
			public IEnumerator GetEnumerator()
			{
				object[] array = new object[mobjList.Count];
				for (int i = 0; i < mobjList.Count; i++)
				{
					array[i] = mobjList[i].Item;
				}
				return array.GetEnumerator();
			}

			/// 
			/// Clears the internal.
			/// </summary>
			internal void ClearInternal()
			{
				InternalClear();
				if (InternalListBox != null)
				{
					InternalListBox.ResetSelection();
				}
				mobjParent.Update();
			}

			/// 
			/// Removes all items from the <see cref="T:System.Collections.IList"></see>.
			/// </summary>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only. </exception>
			public virtual void Clear()
			{
				mobjParent.CheckNoDataSource();
				ClearInternal();
			}

			/// 
			/// Internal Clear method.
			/// </summary>
			internal void InternalClear()
			{
				mobjList.Clear();
			}

			/// 
			/// Returns the index within the collection of the specified item.
			/// </summary>
			/// The zero-based index where the item is located within the collection; otherwise, negative one (-1).</returns>
			/// <param name="objItem">An item representing the item to locate in the collection. </param>
			/// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
			/// </returns>
			public int IndexOf(object objItem)
			{
				ListBoxItem listBoxItemByItem = GetListBoxItemByItem(objItem);
				if (listBoxItemByItem != null)
				{
					return mobjList.IndexOf(listBoxItemByItem);
				}
				return -1;
			}

			/// 
			/// Gets the selected.
			/// </summary>
			/// <param name="intIndex">Index of the int.</param>
			/// 
			/// 	true</c> if the specified obj item is selected; otherwise, false</c>.
			/// </returns>
			internal bool GetSelected(int intIndex)
			{
				return mobjList[intIndex].Selected;
			}

			/// 
			/// Sets the selected.
			/// </summary>
			/// <param name="intIndex">Index of the int.</param>
			/// <param name="blnSelected">if set to true</c> [BLN selected].</param>
			/// </returns>
			internal bool SetSelected(int intIndex, bool blnSelected)
			{
				bool result = false;
				if (mobjList[intIndex].Selected != blnSelected)
				{
					result = true;
					mobjList[intIndex].Selected = blnSelected;
				}
				return result;
			}

			/// 
			/// Removes the item at the specified index within the collection.
			/// </summary>
			/// <param name="index">The zero-based index of the item to remove. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
			public void RemoveAt(int index)
			{
				if (mobjParent != null)
				{
					mobjParent.CheckNoDataSource();
					if (index < 0 || index >= mobjList.Count)
					{
						throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
					}
					bool flag = false;
					ListBoxItem listBoxItem = mobjList[index];
					if (listBoxItem != null)
					{
						flag = listBoxItem.Selected;
					}
					bool flag2 = SelectedIndicesChanged(index);
					mobjList.RemoveAt(index);
					if (flag || flag2)
					{
						mobjParent.InvalidateSelectionCache();
					}
					mobjParent.Update();
					if (flag || flag2)
					{
						mobjParent.OnSelectedIndexChanged(EventArgs.Empty);
					}
				}
			}

			/// 
			/// Checks if selected indices should be updated.
			/// </summary>
			/// <param name="index">The index of removed/inserted item.</param>
			/// true if selected indices should be updated; otherwise, false</returns>
			private bool SelectedIndicesChanged(int index)
			{
				foreach (int selectedIndex in mobjParent.SelectedIndices)
				{
					if (selectedIndex >= index)
					{
						return true;
					}
				}
				return false;
			}

			/// Inserts an item into the list box at the specified index.
			/// </summary>
			/// <param name="objValue">An object representing the item to insert. </param>
			/// <param name="index">The zero-based index location where the item is inserted. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
			public void Insert(int index, object objValue)
			{
				mobjParent.CheckNoDataSource();
				bool flag = SelectedIndicesChanged(index);
				mobjList.Insert(index, new ListBoxItem(objValue));
				if (flag)
				{
					mobjParent.InvalidateSelectionCache();
				}
				mobjParent.Update();
				if (flag)
				{
					mobjParent.OnSelectedIndexChanged(EventArgs.Empty);
				}
			}

			/// 
			/// Determines whether the specified item is located within the collection.
			/// </summary>
			/// true if the item is located within the collection; otherwise, false.</returns>
			/// <param name="value">An object representing the item to locate in the collection. </param>
			public bool Contains(object objItem)
			{
				return GetListBoxItemByItem(objItem) != null;
			}

			/// 
			/// Swaps the items.
			/// </summary>
			/// <param name="intIndexA">The int index A.</param>
			/// <param name="intIndexB">The int index B.</param>
			internal void SwapItems(int intIndexA, int intIndexB)
			{
				ListBoxItem value = mobjList[intIndexA];
				mobjList[intIndexA] = mobjList[intIndexB];
				mobjList[intIndexB] = value;
			}
		}

		/// 
		/// This is the selected index collection
		/// </summary>
		[Serializable]
		public class SelectedIndexCollection : IList, ICollection, IEnumerable
		{
			/// 
			///
			/// </summary>
			[Serializable]
			private class SelectedIndexEnumerator : IEnumerator
			{
				private int mintCurrent;

				private SelectedIndexCollection mobjItems;

				/// 
				/// Gets the current element in the collection.
				/// </summary>
				/// The current element in the collection.</returns>
				///
				/// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception>
				object IEnumerator.Current
				{
					get
					{
						if (mintCurrent == -1 || mintCurrent == mobjItems.Count)
						{
							throw new InvalidOperationException(SR.GetString("ListEnumCurrentOutOfRange"));
						}
						return mobjItems[mintCurrent];
					}
				}

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection.SelectedIndexEnumerator" /> class.
				/// </summary>
				/// <param name="objItems">The items.</param>
				public SelectedIndexEnumerator(SelectedIndexCollection objItems)
				{
					mobjItems = objItems;
					mintCurrent = -1;
				}

				/// 
				/// Advances the enumerator to the next element of the collection.
				/// </summary>
				/// 
				/// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
				/// </returns>
				/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
				bool IEnumerator.MoveNext()
				{
					if (mintCurrent < mobjItems.Count - 1)
					{
						mintCurrent++;
						return true;
					}
					mintCurrent = mobjItems.Count;
					return false;
				}

				/// 
				/// Sets the enumerator to its initial position, which is before the first element in the collection.
				/// </summary>
				/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
				void IEnumerator.Reset()
				{
					mintCurrent = -1;
				}
			}

			private ListBox mobjOwner;

			[Browsable(false)]
			public int Count => mobjOwner.SelectedItems.Count;

			/// 
			/// Gets the inner array.
			/// </summary>
			private ObjectCollection InnerArray => mobjOwner.Items;

			/// 
			/// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.
			/// </summary>
			/// true if the <see cref="T:System.Collections.IList" /> is read-only; otherwise, false.</returns>
			public bool IsReadOnly => true;

			/// 
			/// Gets or sets the element at the specified index.
			/// </summary>
			/// The element at the specified index.</returns>
			///
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
			///
			/// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList" /> is read-only. </exception>
			public int this[int intIndex] => mobjOwner.SelectedIndexesInternal[intIndex];

			/// 
			/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
			/// </summary>
			/// true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.</returns>
			bool ICollection.IsSynchronized => true;

			/// 
			/// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
			/// </summary>
			/// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
			object ICollection.SyncRoot => this;

			/// 
			/// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
			/// </summary>
			/// true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.</returns>
			bool IList.IsFixedSize => true;

			/// 
			/// Gets or sets the element at the specified index.
			/// </summary>
			/// The element at the specified index.</returns>
			///
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
			///
			/// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList" /> is read-only. </exception>
			object IList.this[int intIndex]
			{
				get
				{
					return this[intIndex];
				}
				set
				{
					throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection" /> class.
			/// </summary>
			/// <param name="objOwner">The owner.</param>
			public SelectedIndexCollection(ListBox objOwner)
			{
				mobjOwner = objOwner;
			}

			/// 
			/// Adds the specified index.
			/// </summary>
			/// <param name="intIndex">The index.</param>
			public void Add(int intIndex)
			{
				if (mobjOwner != null && mobjOwner.Items != null && intIndex != -1 && !Contains(intIndex))
				{
					mobjOwner.SetSelected(intIndex, blnValue: true);
				}
			}

			/// 
			/// Removes all items from the <see cref="T:System.Collections.IList" />.
			/// </summary>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only. </exception>
			public void Clear()
			{
				if (mobjOwner != null)
				{
					mobjOwner.ClearSelected();
				}
			}

			/// 
			/// Determines whether [contains] [the specified selected index].
			/// </summary>
			/// <param name="intSelectedIndex">Index of the selected.</param>
			/// 
			///   true</c> if [contains] [the specified selected index]; otherwise, false</c>.
			/// </returns>
			public bool Contains(int intSelectedIndex)
			{
				return IndexOf(intSelectedIndex) != -1;
			}

			/// 
			/// Copies to.
			/// </summary>
			/// <param name="objDestination">The destination.</param>
			/// <param name="intIndex">The index.</param>
			public void CopyTo(Array objDestination, int intIndex)
			{
				int count = Count;
				for (int i = 0; i < count; i++)
				{
					objDestination.SetValue(this[i], i + intIndex);
				}
			}

			/// 
			/// Returns an enumerator that iterates through a collection.
			/// </summary>
			/// 
			/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
			/// </returns>
			public IEnumerator GetEnumerator()
			{
				return new SelectedIndexEnumerator(this);
			}

			/// 
			/// Indexes the of.
			/// </summary>
			/// <param name="intSelectedIndex">Index of the selected.</param>
			/// </returns>
			public int IndexOf(int intSelectedIndex)
			{
				if (mobjOwner != null && intSelectedIndex >= 0 && intSelectedIndex < InnerArray.Count)
				{
					return mobjOwner.SelectedIndexesInternal.IndexOf(intSelectedIndex);
				}
				return -1;
			}

			/// 
			/// Removes the specified index.
			/// </summary>
			/// <param name="intIndex">The index.</param>
			public void Remove(int intIndex)
			{
				if (mobjOwner != null && mobjOwner.Items != null && intIndex != -1 && Contains(intIndex))
				{
					mobjOwner.SetSelected(intIndex, blnValue: false);
				}
			}

			/// 
			/// Adds an item to the <see cref="T:System.Collections.IList" />.
			/// </summary>
			/// <param name="value">The object to add to the <see cref="T:System.Collections.IList" />.</param>
			/// 
			/// The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection,
			/// </returns>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
			int IList.Add(object value)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
			}

			/// 
			/// Removes all items from the <see cref="T:System.Collections.IList" />.
			/// </summary>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only. </exception>
			void IList.Clear()
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
			}

			/// 
			/// Determines whether [contains] [the specified selected index].
			/// </summary>
			/// <param name="objSelectedIndex">Index of the selected.</param>
			/// 
			///   true</c> if [contains] [the specified selected index]; otherwise, false</c>.
			/// </returns>
			bool IList.Contains(object objSelectedIndex)
			{
				return objSelectedIndex is int && Contains((int)objSelectedIndex);
			}

			/// 
			/// Indexes the of.
			/// </summary>
			/// <param name="objSelectedIndex">Index of the selected.</param>
			/// </returns>
			int IList.IndexOf(object objSelectedIndex)
			{
				if (objSelectedIndex is int)
				{
					return IndexOf((int)objSelectedIndex);
				}
				return -1;
			}

			/// 
			/// Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.
			/// </summary>
			/// <param name="intIndex">The zero-based index at which <paramref name="objValue" /> should be inserted.</param>
			/// <param name="objValue">The object to insert into the <see cref="T:System.Collections.IList" />.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
			///
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
			///
			/// <exception cref="T:System.NullReferenceException">
			///   <paramref name="objValue" /> is null reference in the <see cref="T:System.Collections.IList" />.</exception>
			void IList.Insert(int intIndex, object objValue)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
			}

			/// 
			/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.
			/// </summary>
			/// <param name="objValue">The object to remove from the <see cref="T:System.Collections.IList" />.</param>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
			void IList.Remove(object objValue)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
			}

			/// 
			/// Removes the <see cref="T:System.Collections.IList" /> item at the specified index.
			/// </summary>
			/// <param name="intIndex">The zero-based index of the item to remove.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
			///
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
			void IList.RemoveAt(int intIndex)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
			}
		}

		/// 
		/// Represents the collection of selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		[Serializable]
		public class SelectedObjectCollection : IList, ICollection, IEnumerable
		{
			private ListBox mobjOwner;

			/// Gets the number of items in the collection.</summary>
			/// The number of items in the collection.</returns>
			public int Count => mobjOwner.SelectedItemsInternal.Count;

			/// Gets a value indicating whether the collection is read-only.</summary>
			/// true if the collection is read-only; otherwise, false.</returns>
			public bool IsReadOnly => true;

			/// Gets the item at the specified index within the collection.</summary>
			/// An object representing the item located at the specified index within the collection.</returns>
			/// <param name="index">The index of the item in the collection to retrieve. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> class. </exception>
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[Browsable(false)]
			public object this[int index]
			{
				get
				{
					return mobjOwner.SelectedItemsInternal[index];
				}
				set
				{
					throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
				}
			}

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => this;

			bool IList.IsFixedSize => true;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> class.
			/// </summary>
			/// <param name="objOwner">A <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> representing the mobjOwner of the collection. </param>
			public SelectedObjectCollection(ListBox objOwner)
			{
				mobjOwner = objOwner;
			}

			/// 
			/// Adds an item to the list of selected items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
			/// </summary>
			/// <param name="objValue">An object representing the item to add to the collection of selected items.</param>
			public void Add(object objValue)
			{
				if (mobjOwner == null)
				{
					return;
				}
				ObjectCollection items = mobjOwner.Items;
				if (items != null && objValue != null)
				{
					int num = items.IndexOf(objValue);
					if (num != -1 && !GetSelected(num))
					{
						mobjOwner.SelectedIndex = num;
					}
				}
			}

			/// 
			/// Removes all items from the collection of selected items.
			/// </summary>
			public void Clear()
			{
				if (mobjOwner != null)
				{
					mobjOwner.ClearSelected();
				}
			}

			/// 
			/// Determines whether the specified item is located within the collection.
			/// </summary>
			/// true if the specified item is located in the collection; otherwise, false.</returns>
			/// <param name="selectedObject">An object representing the item to locate in the collection. </param>
			public bool Contains(object selectedObject)
			{
				return mobjOwner.SelectedItemsInternal.IndexOf(selectedObject) != -1;
			}

			/// 
			/// Copies the entire collection into an existing array at a specified location within the array.
			/// </summary>
			/// <param name="objDestinationArray">An <see cref="T:System.Array"></see> representing the array to copy the contents of the collection to. </param>
			/// <param name="index">The location within the destination array to copy the items from the collection to. </param>
			public void CopyTo(Array objDestinationArray, int index)
			{
				mobjOwner.SelectedItemsInternal.CopyTo(objDestinationArray, index);
			}

			/// 
			/// Returns an enumerator that can be used to iterate through the selected item collection.
			/// </summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
			public IEnumerator GetEnumerator()
			{
				return mobjOwner.SelectedItemsInternal.GetEnumerator();
			}

			internal object GetObjectAt(int index)
			{
				return mobjOwner.SelectedItemsInternal[index];
			}

			/// 
			/// Gets the selected.
			/// </summary>
			/// <param name="index">The index.</param>
			/// </returns>
			internal bool GetSelected(int index)
			{
				return mobjOwner.SelectedItemsInternal.Contains(mobjOwner.Items[index]);
			}

			/// 
			/// Returns the index within the collection of the specified item.
			/// </summary>
			/// The zero-based index of the item in the collection; otherwise, -1.</returns>
			/// <param name="selectedObject">An object representing the item to locate in the collection. </param>
			public int IndexOf(object selectedObject)
			{
				return mobjOwner.SelectedItemsInternal.IndexOf(selectedObject);
			}

			/// 
			/// Removes the specified object from the collection of selected items.
			/// </summary>
			/// <param name="objValue">An object representing the item to remove from the collection.</param>
			public void Remove(object objValue)
			{
				if (mobjOwner == null)
				{
					return;
				}
				ObjectCollection items = mobjOwner.Items;
				if (items != null && objValue != null)
				{
					int num = items.IndexOf(objValue);
					if (num != -1 && GetSelected(num))
					{
						mobjOwner.SetSelected(num, blnValue: false);
					}
				}
			}

			/// 
			/// Adds an item to the <see cref="T:System.Collections.IList"></see>.
			/// </summary>
			/// <param name="objValue">The <see cref="T:System.Object"></see> to add to the <see cref="T:System.Collections.IList"></see>.</param>
			/// 
			/// The position into which the new element was inserted.
			/// </returns>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
			int IList.Add(object objValue)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
			}

			/// 
			/// Removes all items from the <see cref="T:System.Collections.IList"></see>.
			/// </summary>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only. </exception>
			void IList.Clear()
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
			}

			/// 
			/// Inserts an item to the <see cref="T:System.Collections.IList"></see> at the specified index.
			/// </summary>
			/// <param name="index"></param>
			/// <param name="objValue">The <see cref="T:System.Object"></see> to insert into the <see cref="T:System.Collections.IList"></see>.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
			/// <exception cref="T:System.NullReferenceException">value is null reference in the <see cref="T:System.Collections.IList"></see>.</exception>
			void IList.Insert(int index, object objValue)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
			}

			/// 
			/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"></see>.
			/// </summary>
			/// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the <see cref="T:System.Collections.IList"></see>.</param>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
			void IList.Remove(object objValue)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
			}

			/// 
			/// Removes the <see cref="T:System.Collections.IList"></see> item at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index of the item to remove.</param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
			/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
			void IList.RemoveAt(int index)
			{
				throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
			}
		}

		/// 
		/// Provides a property reference to RadioBoxes property.
		/// </summary>
		private static SerializableProperty RadioBoxesProperty = SerializableProperty.Register("RadioBoxes", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to CheckBoxes property.
		/// </summary>
		private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register("CheckBoxes", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to Mode property.
		/// </summary>
		private static SerializableProperty ModeProperty = SerializableProperty.Register("Mode", typeof(SelectionMode), typeof(ListBox), new SerializablePropertyMetadata(SelectionMode.One));

		/// 
		/// Provides a property reference to Sorted property.
		/// </summary>
		private static SerializableProperty SortedProperty = SerializableProperty.Register("Sorted", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to MultiColumn property.
		/// </summary>
		private static SerializableProperty MultiColumnProperty = SerializableProperty.Register("MultiColumn", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ColumnWidth property.
		/// </summary>
		private static SerializableProperty ColumnWidthProperty = SerializableProperty.Register("ColumnWidth", typeof(int), typeof(ListBox), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to IntegralHeight property.
		/// </summary>
		private static SerializableProperty IntegralHeightProperty = SerializableProperty.Register("IntegralHeight", typeof(bool), typeof(ListBox), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to TopIndex property.
		/// </summary>
		private static SerializableProperty TopIndexProperty = SerializableProperty.Register("TopIndex", typeof(int), typeof(ListBox));

		/// 
		/// Provides a property reference to SelectedIndices property.
		/// </summary>
		[NonSerialized]
		private SelectedIndexCollection mobjSelectedIndexCollection = null;

		/// 
		/// Provides a property reference to SelectedItemd property.
		/// </summary>
		[NonSerialized]
		private SelectedObjectCollection mobjSelectedObjectCollection = null;

		/// 
		/// The SelectedIndexChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedIndexChangedEvent;

		/// 
		/// The cached Selected Items
		/// </summary>
		[NonSerialized]
		private ArrayList mobjCachedSelectedItems = null;

		/// 
		/// The cached Selected indexes
		/// </summary>
		[NonSerialized]
		private List<int> mobjCachedSelectedIndexes = null;

		/// 
		/// The list box items
		/// </summary>
		[NonSerialized]
		private ObjectCollection mobjItems = null;

		/// 
		/// The amount of fields the listbox needs to serialize
		/// </summary>
		private const int mintSerializableFieldCount = 0;

		/// 
		/// Gets the hanlder for the SelectedIndexChanged event.
		/// </summary>
		private EventHandler SelectedIndexChangedHandler => (EventHandler)GetHandler(SelectedIndexChangedEvent);

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
				return serializableDataInitialSize + mobjItems.GetRequiredSerializationCapacity();
			}
		}

		/// 
		/// Gets a value indicating whether this instance is delayed drawing.
		/// </summary>
		/// 
		/// 	true</c> if this instance is delayed drawing; otherwise, false</c>.
		/// </value>
		protected override bool IsDelayedDrawing => true;

		/// 
		/// Gets or sets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> are sorted alphabetically.
		/// </summary>
		/// true if items in the control are sorted; otherwise, false. The default is false.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ListBoxSortedDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool Sorted
		{
			get
			{
				return GetValue(SortedProperty);
			}
			set
			{
				if (SetValue(SortedProperty, value))
				{
					ObjectCollection items = Items;
					if (value && items != null && items.Count >= 1)
					{
						Sort();
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the method in which items are selected in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.SelectionMode"></see> values. The default is SelectionMode.One.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.SelectionMode"></see> values.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[DefaultValue(SelectionMode.One)]
		[SRDescription("ListBoxSelectionModeDescr")]
		public SelectionMode SelectionMode
		{
			get
			{
				return GetValue(ModeProperty);
			}
			set
			{
				SelectionMode selectionMode = SelectionMode;
				if (!SetValue(ModeProperty, value))
				{
					return;
				}
				switch (value)
				{
				case SelectionMode.None:
					ResetSelection();
					break;
				case SelectionMode.One:
					if (selectionMode == SelectionMode.MultiExtended || selectionMode == SelectionMode.MultiSimple)
					{
						ApplySingleSelectionMode();
					}
					break;
				}
				Update();
			}
		}

		private bool CheckBoxesInternal
		{
			get
			{
				return GetValue(CheckBoxesProperty);
			}
			set
			{
				SetValue(CheckBoxesProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [check boxes].
		/// </summary>
		/// true</c> if [check boxes]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		public virtual bool CheckBoxes
		{
			get
			{
				return CheckBoxesInternal;
			}
			set
			{
				if (CheckBoxesInternal != value)
				{
					CheckBoxesInternal = value;
					if (value)
					{
						RadioBoxesInternal = false;
					}
					Update();
				}
			}
		}

		private bool RadioBoxesInternal
		{
			get
			{
				return GetValue(RadioBoxesProperty);
			}
			set
			{
				SetValue(RadioBoxesProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [radio boxes].
		/// </summary>
		/// true</c> if [radio boxes]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		public virtual bool RadioBoxes
		{
			get
			{
				return RadioBoxesInternal;
			}
			set
			{
				if (RadioBoxesInternal != value)
				{
					RadioBoxesInternal = value;
					Update();
					if (value)
					{
						CheckBoxesInternal = false;
					}
				}
			}
		}

		/// 
		/// Gets the items of the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatData")]
		[SRDescription("ListBoxItemsDescr")]
		[Localizable(true)]
		[Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public ObjectCollection Items => mobjItems;

		/// 
		/// Gets or sets the zero-based index of the currently selected item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		/// A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.ListBox.SelectionMode"></see> property is set to None.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than -1 or greater than or equal to the item count.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(-1)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Bindable(true)]
		[SRDescription("ListBoxSelectedIndexDescr")]
		public override int SelectedIndex
		{
			get
			{
				EnsureSelectionCache();
				if (mobjCachedSelectedIndexes.Count > 0)
				{
					return mobjCachedSelectedIndexes[0];
				}
				return -1;
			}
			set
			{
				if (Items.Count <= value)
				{
					return;
				}
				if (value >= 0)
				{
					switch (SelectionMode)
					{
					case SelectionMode.None:
						throw new ArgumentException(SR.GetString("ListBoxInvalidSelectionMode"), "SelectedIndex");
					case SelectionMode.One:
						SelectIndexes(value.ToString());
						break;
					default:
						SetSelected(value, blnValue: true);
						break;
					}
					Update();
					InvokeMethod("ListBox_ScrollIntoView", ID.ToString(), value.ToString());
				}
				else if (value == -1 && SelectedItems.Count > 0)
				{
					SelectedItems.Clear();
					Update();
					InvokeMethod("ListBox_ScrollIntoView", ID.ToString(), value.ToString());
				}
			}
		}

		/// 
		/// Gets a collection that contains the zero-based indexes of all currently selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection"></see> containing the indexes of the currently selected items in the control. If no items are currently selected, an empty <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection"></see> is returned.</returns>
		[SRDescription("ListBoxSelectedIndicesDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SelectedIndexCollection SelectedIndices
		{
			get
			{
				EnsureSelectionCache();
				if (mobjSelectedIndexCollection == null)
				{
					mobjSelectedIndexCollection = new SelectedIndexCollection(this);
				}
				return mobjSelectedIndexCollection;
			}
		}

		/// 
		/// Gets the internal selected array list
		/// </summary>
		internal List<int> SelectedIndexesInternal
		{
			get
			{
				EnsureSelectionCache();
				return mobjCachedSelectedIndexes;
			}
		}

		/// 
		/// Gets or sets the currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		/// An object that represents the current selection in the control.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Bindable(true)]
		public object SelectedItem
		{
			get
			{
				EnsureSelectionCache();
				if (mobjCachedSelectedItems.Count > 0)
				{
					return mobjCachedSelectedItems[0];
				}
				return null;
			}
			set
			{
				SelectedIndex = Items.IndexOf(value);
			}
		}

		/// 
		/// Gets a collection containing the currently selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> containing the currently selected items in the control.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ListBoxSelectedItemsDescr")]
		[Browsable(false)]
		public SelectedObjectCollection SelectedItems
		{
			get
			{
				if (mobjSelectedObjectCollection == null)
				{
					mobjSelectedObjectCollection = new SelectedObjectCollection(this);
				}
				return mobjSelectedObjectCollection;
			}
		}

		/// 
		/// Gets the internal selected array list
		/// </summary>
		internal ArrayList SelectedItemsInternal
		{
			get
			{
				EnsureSelectionCache();
				return mobjCachedSelectedItems;
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Bindable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override string Text
		{
			get
			{
				if (SelectionMode == SelectionMode.None || SelectedItem == null)
				{
					return base.Text;
				}
				if (base.FormattingEnabled)
				{
					return base.GetItemText(SelectedItem);
				}
				return FilterItemOnProperty(SelectedItem).ToString();
			}
			set
			{
				base.Text = value;
				if (SelectionMode == SelectionMode.None || value == null || (SelectedItem != null && value.Equals(base.GetItemText(SelectedItem))))
				{
					return;
				}
				int count = Items.Count;
				for (int i = 0; i < count; i++)
				{
					if (string.Compare(value, base.GetItemText(Items[i]), ignoreCase: true, CultureInfo.InvariantCulture) == 0)
					{
						SelectedIndex = i;
						break;
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [multi column].
		/// </summary>
		/// 
		///   true</c> if [multi column]; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool MultiColumn
		{
			get
			{
				return GetValue(MultiColumnProperty);
			}
			set
			{
				SetValue(MultiColumnProperty, value);
			}
		}

		/// 
		/// Gets or sets the column width.
		/// </summary>
		/// 
		///   The width of the columns
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[SRDescription("ListBoxColumnWidthDescr")]
		[Localizable(true)]
		[DefaultValue(0)]
		public int ColumnWidth
		{
			get
			{
				return GetValue(ColumnWidthProperty);
			}
			set
			{
				SetValue(ColumnWidthProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [integral height].
		/// </summary>
		/// 
		///   true</c> if [integral height]; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IntegralHeight
		{
			get
			{
				return GetValue(IntegralHeightProperty);
			}
			set
			{
				SetValue(IntegralHeightProperty, value);
			}
		}

		/// 
		/// Gets or sets the index of the top.
		/// </summary>
		/// 
		/// The index of the top.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TopIndex
		{
			get
			{
				return GetValue(TopIndexProperty);
			}
			set
			{
				SetValue(TopIndexProperty, value);
			}
		}

		/// Gets or sets a value indicating whether the vertical scroll bar is shown at all times.</summary>
		/// true if the vertical scroll bar should always be displayed; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[SRDescription("ListBoxScrollIsVisibleDescr")]
		[DefaultValue(false)]
		[Localizable(true)]
		public bool ScrollAlwaysVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether a horizontal scroll bar is displayed in the control.</summary>
		/// true to display a horizontal scroll bar in the control; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ListBoxHorizontalScrollbarDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[Localizable(true)]
		public bool HorizontalScrollbar
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
		/// Gets or sets the height of the item.
		/// </summary>
		/// 
		/// The height of the item.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("Setter not implemented. Added for migration compatibility")]
		public int ItemHeight
		{
			get
			{
				return GetPreferdItemHeight();
			}
			set
			{
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
		/// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ListBox"></see> value has changed.
		/// </summary>
		[SRDescription("selectedIndexChangedEventDescr")]
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
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> class.
		/// </summary>
		public ListBox()
		{
			mobjItems = CreateItemCollection();
			SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, blnValue: false);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mobjItems = CreateItemCollection();
			mobjItems.OnSerializableObjectDeserializing(objReader);
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			mobjItems.OnSerializableObjectSerializing(objWriter);
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			bool blnShouldRenderItemImage = ShouldRenderImage();
			bool blnShouldRenderItemColor = ShouldRenderColor();
			if (SelectionMode != SelectionMode.One)
			{
				objWriter.WriteAttributeString("SM", Convert.ToInt32(SelectionMode).ToString());
			}
			if (base.MetadataTag == "LX")
			{
				if (CheckBoxes)
				{
					objWriter.WriteAttributeString("CB", "1");
				}
				else if (RadioBoxes)
				{
					objWriter.WriteAttributeString("RB", "1");
				}
			}
			ObjectCollection items = Items;
			for (int i = 0; i < items.Count; i++)
			{
				objWriter.WriteStartElement("O");
				RenderItemAttributes(objWriter, items[i], i, blnShouldRenderItemImage, blnShouldRenderItemColor);
				objWriter.WriteEndElement();
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (ShouldRenderColor())
			{
				objWriter.WriteAttributeString("SHC", "1");
			}
			if (ShouldRenderImage())
			{
				objWriter.WriteAttributeString("SHI", "1");
			}
			objWriter.WriteAttributeString("IMH", GetPreferdItemHeight().ToString());
		}

		/// 
		///
		/// </summary>
		/// <param name="objWriter"></param>
		/// <param name="objItem"></param>
		/// <param name="intIndex"></param>
		protected internal virtual void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor)
		{
			objWriter.WriteAttributeString("Idx", intIndex.ToString());
			RenderItemIdAttribute(objWriter, objItem);
			if (Items.GetSelected(intIndex))
			{
				objWriter.WriteAttributeString("SE", "1");
			}
			if (objItem == null)
			{
				objWriter.WriteAttributeString("TX", "");
				return;
			}
			objWriter.WriteAttributeText("TX", GetItemText(objItem), (TextFilter)5);
			RenderColorAndImageAttribute(objWriter, blnShouldRenderItemImage, blnShouldRenderItemColor, objItem);
		}

		/// 
		/// Renders the item attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objItem">The obj item.</param>
		/// <param name="intIndex">Index of the int.</param>
		protected internal virtual void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex)
		{
			RenderItemAttributes(objWriter, objItem, intIndex, blnShouldRenderItemImage: false, blnShouldRenderItemColor: false);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "SelectionChange")
			{
				SelectIndexes(objEvent["Indexes"]);
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.SelectedValueChangedHandler != null || SelectedIndexChangedHandler != null || IsPostBackRequired)
			{
				criticalEventsData.Set("SLC");
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
			return criticalClientEventsData;
		}

		/// 
		/// Unselects all items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		public void ClearSelected()
		{
			ClearSelectedItems();
			Update();
		}

		/// 
		/// Clears the selected items.
		/// </summary>
		private void ClearSelectedItems()
		{
			Items.ClearSelectedItems();
			InvalidateSelectionCache();
		}

		/// 
		/// Selects the indexes.
		/// </summary>
		/// <param name="strIndexes">STR indexes.</param>
		private void SelectIndexes(string strIndexes)
		{
			bool flag = false;
			List<object> list = new List<object>(strIndexes.Split(','));
			ObjectCollection items = Items;
			int count = items.Count;
			for (int i = 0; i < count; i++)
			{
				if (list.Contains(i.ToString()))
				{
					if (!items.GetSelected(i))
					{
						flag = true;
						Items.SetSelected(i, blnSelected: true);
					}
				}
				else if (items.GetSelected(i))
				{
					flag = true;
					Items.SetSelected(i, blnSelected: false);
				}
			}
			if (flag || base.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick)
			{
				InvalidateSelectionCache();
				OnSelectedIndexChanged(EventArgs.Empty);
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			CurrencyManager dataManager = base.DataManager;
			if (dataManager != null && dataManager.Position != SelectedIndex && (!base.FormattingEnabled || SelectedIndex != -1))
			{
				dataManager.Position = SelectedIndex;
			}
			SelectedIndexChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnDataSourceChanged(EventArgs e)
		{
			if (base.DataSource == null)
			{
				SelectedIndex = -1;
				Items.ClearInternal();
			}
			base.OnDataSourceChanged(e);
			RefreshItems();
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DisplayMemberChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnDisplayMemberChanged(EventArgs e)
		{
			base.OnDisplayMemberChanged(e);
			RefreshItems();
			if (SelectionMode != SelectionMode.None && base.DataManager != null)
			{
				SelectedIndex = base.DataManager.Position;
			}
		}

		/// 
		/// Refreshes all <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> items and retrieves new strings for them.
		/// </summary>
		protected override void RefreshItems()
		{
			ObjectCollection objectCollection = mobjItems;
			ObjectCollection objectCollection2 = (mobjItems = CreateItemCollection());
			ClearSelectedItems();
			if (base.DataManager != null && base.DataManager.Count != -1)
			{
				object[] array = new object[base.DataManager.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = base.DataManager[i];
				}
				objectCollection2.AddRangeInternal(array);
			}
			else if (objectCollection != null)
			{
				foreach (object item in objectCollection)
				{
					ListBoxItem listBoxItemByItem = objectCollection.GetListBoxItemByItem(item);
					if (listBoxItemByItem != null)
					{
						objectCollection2.AddInternal(listBoxItemByItem);
					}
				}
				Update();
			}
			if (SelectionMode != SelectionMode.None && base.DataManager != null)
			{
				SelectedIndex = base.DataManager.Position;
			}
		}

		/// When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
		/// <param name="index">The zero-based index of the item whose data to refresh. </param>
		protected override void RefreshItem(int index)
		{
			Update();
		}

		/// When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
		/// <param name="objItems">An array of items.</param>
		protected override void SetItemsCore(IList objItems)
		{
			Items.ClearInternal();
			Items.AddRangeInternal(objItems);
		}

		/// 
		/// When overridden in a derived class, sets the object with the specified index in the derived class.
		/// </summary>
		/// <param name="index">The array index of the object.</param>
		/// <param name="objValue">The object.</param>
		protected override void SetItemCore(int index, object objValue)
		{
			Items.SetItemInternal(index, objValue);
		}

		/// 
		/// Clears the current selection 
		/// </summary>
		internal void ResetSelection()
		{
			ClearSelectedItems();
		}

		/// 
		/// Clears the selection from object if selected
		/// </summary>
		/// <param name="intIndex">Index of the int.</param>
		internal void RemoveSelection(int intIndex)
		{
			if (Items.SetSelected(intIndex, blnSelected: false))
			{
				InvalidateSelectionCache();
			}
		}

		/// Selects or clears the selection for the specified item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.</summary>
		/// <param name="blnValue">true to select the specified item; otherwise, false. </param>
		/// <param name="intIndex">The zero-based index of the item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> to select or clear the selection for. </param>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.ListBox.SelectionMode"></see> property was set to None.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified index was outside the range of valid values. </exception>
		/// 1</filterpriority>
		public void SetSelected(int intIndex, bool blnValue)
		{
			int num = Items?.Count ?? 0;
			if (intIndex < 0 || intIndex >= num)
			{
				throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", intIndex.ToString()));
			}
			if (SelectionMode == SelectionMode.None)
			{
				throw new InvalidOperationException(SR.GetString("ListBoxInvalidSelectionMode"));
			}
			if (Items.SetSelected(intIndex, blnValue))
			{
				InvalidateSelectionCache();
				Update();
			}
			OnSelectedIndexChanged(EventArgs.Empty);
		}

		/// 
		/// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that starts with the specified string.
		/// </summary>
		/// The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
		/// <param name="strValue">The text to search for. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the s parameter is less than -1 or greater than or equal to the item count.</exception>
		public int FindString(string strValue)
		{
			return FindString(strValue, 0);
		}

		/// 
		/// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that starts with the specified string. The search starts at a specific starting index.
		/// </summary>
		/// The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
		/// <param name="strValue">The text to search for. </param>
		/// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to negative one (-1) to search from the beginning of the control. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
		public int FindString(string strValue, int intStartIndex)
		{
			ObjectCollection items = Items;
			for (int i = intStartIndex; i < items.Count; i++)
			{
				if (items[i] != null)
				{
					string itemText = GetItemText(items[i]);
					if (itemText.StartsWith(strValue))
					{
						return i;
					}
				}
			}
			return -1;
		}

		/// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that exactly matches the specified string.</summary>
		/// The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
		/// <param name="strValue">The text to search for. </param>
		/// 1</filterpriority>
		public int FindStringExact(string strValue)
		{
			return FindStringExact(strValue, -1);
		}

		/// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that exactly matches the specified string. The search starts at a specific starting index.</summary>
		/// The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
		/// <param name="strValue">The text to search for. </param>
		/// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to negative one (-1) to search from the beginning of the control. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
		/// 1</filterpriority>
		public int FindStringExact(string strValue, int intStartIndex)
		{
			if (strValue == null)
			{
				return -1;
			}
			int num = ((Items != null) ? Items.Count : 0);
			if (num == 0)
			{
				return -1;
			}
			if (intStartIndex < -1 || intStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("intStartIndex");
			}
			return FindStringInternal(strValue, Items, intStartIndex, blnExact: true);
		}

		/// 
		/// Swaps the items.
		/// </summary>
		/// <param name="intIndexA">The int index A.</param>
		/// <param name="intIndexB">The int index B.</param>
		public virtual void SwapItems(int intIndexA, int intIndexB)
		{
			mobjItems.SwapItems(intIndexA, intIndexB);
			InvalidateSelectionCache();
			Update();
		}

		/// 
		/// Creates the item collection.
		/// </summary>
		protected virtual ObjectCollection CreateItemCollection()
		{
			return new ObjectCollection(this);
		}

		/// 
		/// Validates that there is no data source
		/// </summary>
		private void CheckNoDataSource()
		{
			if (base.DataSource != null)
			{
				throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
			}
		}

		/// 
		/// Sorts the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
		/// </summary>
		protected virtual void Sort()
		{
			ObjectCollection items = Items;
			CheckNoDataSource();
			SelectedObjectCollection selectedItems = SelectedItems;
			if (Sorted)
			{
				items?.InternalSort();
			}
		}

		/// 
		/// Gets the height of the preferd item font.        
		/// </summary>
		/// </returns>
		internal int GetPreferdItemHeight()
		{
			if (base.Skin is ListBoxSkin listBoxSkin)
			{
				int num = 0;
				PaddingValue padding = listBoxSkin.CellStyle.Padding;
				BorderValue border = listBoxSkin.CellStyle.Border;
				if (border != null && border.Style != BorderStyle.None)
				{
					num = border.Width.Bottom + border.Width.Top;
				}
				int val = 0;
				if (ShouldRenderColor())
				{
					val = listBoxSkin.ListBoxColorBoxHeight;
				}
				int val2 = 0;
				if (ShouldRenderImage())
				{
					val2 = listBoxSkin.ListBoxImageCellHeight;
				}
				int num2 = 0;
				if (padding != null)
				{
					num2 = padding.Top + padding.Bottom;
				}
				int val3 = Math.Max(CommonUtils.GetFontHeight(Font), val);
				val3 = Math.Max(val2, val3);
				return val3 + num2 + num;
			}
			return 0;
		}

		/// 
		/// Should serialize selection mode.
		/// </summary>
		protected virtual bool ShouldSerializeSelectionMode()
		{
			return SelectionMode != SelectionMode.MultiSimple;
		}

		/// 
		/// Applies a single selection mode.
		/// </summary>
		private void ApplySingleSelectionMode()
		{
			ObjectCollection items = Items;
			if (items == null)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < items.Count; i++)
			{
				if (items.GetSelected(i))
				{
					arrayList.Add(i);
				}
			}
			for (int j = 0; j < arrayList.Count - 1; j++)
			{
				items.SetSelected(Convert.ToInt32(arrayList[j]), blnSelected: false);
			}
		}

		/// 
		/// Invalidates the selected items.
		/// </summary>
		private void EnsureSelectionCache()
		{
			if (mobjCachedSelectedItems != null && mobjCachedSelectedIndexes != null)
			{
				return;
			}
			mobjCachedSelectedItems = new ArrayList();
			mobjCachedSelectedIndexes = new List<int>();
			ObjectCollection items = Items;
			for (int i = 0; i < items.Count; i++)
			{
				if (items.GetSelected(i))
				{
					mobjCachedSelectedIndexes.Add(i);
					mobjCachedSelectedItems.Add(items[i]);
				}
			}
		}

		/// 
		/// Invalidates the selection cache
		/// </summary>
		private void InvalidateSelectionCache()
		{
			mobjCachedSelectedItems = null;
			mobjCachedSelectedIndexes = null;
		}

		static ListBox()
		{
			SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(ListBox));
		}
	}
}
