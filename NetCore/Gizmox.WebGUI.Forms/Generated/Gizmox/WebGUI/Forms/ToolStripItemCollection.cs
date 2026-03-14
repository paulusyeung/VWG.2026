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
/// Represents a collection of <see cref="T:System.Windows.Forms.ToolStripItem"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ListBindable(false)]
	public class ToolStripItemCollection : ArrangedElementCollection, IList, ICollection, IEnumerable
	{
		private bool mblnIsReadOnly;

		private bool mblnItemsCollection;

		private int mintLastAccessedIndex;

		private ToolStrip mobjOwnerToolStrip;

		bool IList.IsFixedSize => base.InnerList.IsFixedSize;

		object IList.this[int index]
		{
			get
			{
				return base.InnerList[index];
			}
			set
			{
				throw new NotSupportedException(SR.GetString("ToolStripCollectionMustInsertAndRemove"));
			}
		}

		/// Gets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only; otherwise, false.</returns>
		public override bool IsReadOnly => mblnIsReadOnly;

		/// Gets the item at the specified index.</summary>
		/// The <see cref="T:System.Windows.Forms.ToolStripItem"></see> located at the specified position in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>.</returns>
		/// <param name="index">The zero-based index of the item to get.</param>
		/// 1</filterpriority>
		public new virtual ToolStripItem this[int index] => (ToolStripItem)base.InnerList[index];

		/// Gets the item with the specified name.</summary>
		/// The <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified name.</returns>
		/// <param name="key">The name of the item to get.</param>
		/// 1</filterpriority>
		public virtual ToolStripItem this[string key]
		{
			get
			{
				if (key != null && key.Length != 0)
				{
					int num = IndexOfKey(key);
					if (IsValidIndex(num))
					{
						return (ToolStripItem)base.InnerList[num];
					}
				}
				return null;
			}
		}

		internal ToolStripItemCollection(ToolStrip owner, bool itemsCollection, bool isReadOnly)
		{
			mintLastAccessedIndex = -1;
			mobjOwnerToolStrip = owner;
			mblnItemsCollection = itemsCollection;
			mblnIsReadOnly = isReadOnly;
		}

		internal ToolStripItemCollection(ToolStrip owner, bool itemsCollection)
			: this(owner, itemsCollection, isReadOnly: false)
		{
		}

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> class with the specified container <see cref="T:System.Windows.Forms.ToolStrip"></see> and the specified array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls.</summary>
		/// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStrip"></see> to which this <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> belongs. </param>
		/// <param name="value">An array of type <see cref="T:System.Windows.Forms.ToolStripItem"></see> containing the initial controls for this <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
		/// <exception cref="T:System.ArgumentNullException">The owner parameter is null.</exception>
		public ToolStripItemCollection(ToolStrip owner, ToolStripItem[] value)
		{
			mintLastAccessedIndex = -1;
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			mobjOwnerToolStrip = owner;
			AddRange(value);
		}

		/// Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image to the collection.</summary>
		/// The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		public ToolStripItem Add(ResourceHandle image)
		{
			return Add(null, image, null);
		}

		/// Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified text to the collection.</summary>
		/// The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
		/// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		public ToolStripItem Add(string text)
		{
			return Add(text, null, null);
		}

		/// Adds the specified item to the end of the collection.</summary>
		/// An <see cref="T:System.Int32"></see> representing the zero-based index of the new item in the collection.</returns>
		/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to add to the end of the collection. </param>
		/// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public int Add(ToolStripItem value)
		{
			CheckCanAddOrInsertItem(value);
			SetOwner(value);
			value.InternalParent = mobjOwnerToolStrip;
			int result = base.InnerList.Add(value);
			if (mblnItemsCollection && mobjOwnerToolStrip != null)
			{
				mobjOwnerToolStrip.OnItemAdded(new ToolStripItemEventArgs(value));
			}
			return result;
		}

		/// Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image and text to the collection.</summary>
		/// The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		/// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		public ToolStripItem Add(string text, ResourceHandle image)
		{
			return Add(text, image, null);
		}

		/// Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image and text to the collection and that raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click"></see> event.</summary>
		/// The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
		/// <param name="onClick">Raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click"></see> event.</param>
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		/// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		public ToolStripItem Add(string text, ResourceHandle image, EventHandler onClick)
		{
			ToolStripItem toolStripItem = mobjOwnerToolStrip.CreateDefaultItem(text, image, onClick);
			Add(toolStripItem);
			return toolStripItem;
		}

		/// Adds an array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls to the collection.</summary>
		/// <param name="toolStripItems">An array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls. </param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentNullException">The toolStripItems parameter is null. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void AddRange(ToolStripItem[] toolStripItems)
		{
			if (toolStripItems == null)
			{
				throw new ArgumentNullException("toolStripItems");
			}
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			for (int i = 0; i < toolStripItems.Length; i++)
			{
				Add(toolStripItems[i]);
			}
		}

		/// Adds a <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> to the current collection.</summary>
		/// <param name="toolStripItems">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> to be added to the current collection. </param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
		/// <exception cref="T:System.ArgumentNullException">The toolStripItems parameter is null. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void AddRange(ToolStripItemCollection toolStripItems)
		{
			if (toolStripItems == null)
			{
				throw new ArgumentNullException("toolStripItems");
			}
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			int count = toolStripItems.Count;
			for (int i = 0; i < count; i++)
			{
				Add(toolStripItems[i]);
			}
		}

		/// Removes all items from the collection.</summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual void Clear()
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			if (Count != 0)
			{
				while (Count != 0)
				{
					RemoveAt(Count - 1);
				}
			}
		}

		/// Determines whether the specified item is a member of the collection.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is a member of the current <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>; otherwise, false.</returns>
		/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to search for in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
		/// 1</filterpriority>
		public bool Contains(ToolStripItem value)
		{
			return base.InnerList.Contains(value);
		}

		/// Determines whether the collection contains an item with the specified key.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> contains a <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified key; otherwise, false.</returns>
		/// <param name="key">The key to locate in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
		/// 1</filterpriority>
		public virtual bool ContainsKey(string key)
		{
			return IsValidIndex(IndexOfKey(key));
		}

		/// Copies the collection into the specified position of the specified <see cref="T:System.Windows.Forms.ToolStripItem"></see> array.</summary>
		/// <param name="array">The array of type <see cref="T:System.Windows.Forms.ToolStripItem"></see> to which to copy the collection. </param>
		/// <param name="index">The position in the <see cref="T:System.Windows.Forms.ToolStripItem"></see> array at which to paste the collection. </param>
		/// 1</filterpriority>
		public void CopyTo(ToolStripItem[] array, int index)
		{
			base.InnerList.CopyTo(array, index);
		}

		/// Searches for items by their name and returns an array of all matching controls.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripItem"></see> array of the search results.</returns>
		/// <param name="searchAllChildren">true to search child items of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> specified by the key parameter; otherwise, false. </param>
		/// <param name="key">The item name to search the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> for.</param>
		/// <exception cref="T:System.ArgumentNullException">The key parameter is null or empty.</exception>
		public ToolStripItem[] Find(string key, bool searchAllChildren)
		{
			if (key == null || key.Length == 0)
			{
				throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
			}
			ArrayList arrayList = FindInternal(key, searchAllChildren, this, new ArrayList());
			ToolStripItem[] array = new ToolStripItem[arrayList.Count];
			arrayList.CopyTo(array, 0);
			return array;
		}

		/// Retrieves the index of the specified item in the collection.</summary>
		/// A zero-based index value that represents the position of the specified <see cref="T:System.Windows.Forms.ToolStripItem"></see> in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>, if found; otherwise, -1.</returns>
		/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to locate in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
		/// 1</filterpriority>
		public int IndexOf(ToolStripItem value)
		{
			return base.InnerList.IndexOf(value);
		}

		/// Retrieves the index of the first occurrence of the specified item within the collection.</summary>
		/// A zero-based index value that represents the position of the first occurrence of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> specified by the key parameter, if found; otherwise, -1.</returns>
		/// <param name="key">The name of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to search for. </param>
		/// 1</filterpriority>
		public virtual int IndexOfKey(string key)
		{
			if (key != null && key.Length != 0)
			{
				if (IsValidIndex(mintLastAccessedIndex) && ClientUtils.SafeCompareStrings(this[mintLastAccessedIndex].Name, key, blnIgnoreCase: true))
				{
					return mintLastAccessedIndex;
				}
				for (int i = 0; i < Count; i++)
				{
					if (ClientUtils.SafeCompareStrings(this[i].Name, key, blnIgnoreCase: true))
					{
						mintLastAccessedIndex = i;
						return i;
					}
				}
				mintLastAccessedIndex = -1;
			}
			return -1;
		}

		/// Inserts the specified item into the collection at the specified index.</summary>
		/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to insert. </param>
		/// <param name="index">The location in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> at which to insert the <see cref="T:System.Windows.Forms.ToolStripItem"></see>. </param>
		/// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Insert(int index, ToolStripItem value)
		{
			CheckCanAddOrInsertItem(value);
			SetOwner(value);
			base.InnerList.Insert(index, value);
			if (mblnItemsCollection && mobjOwnerToolStrip != null)
			{
				mobjOwnerToolStrip.OnItemAdded(new ToolStripItemEventArgs(value));
			}
		}

		/// Removes the specified item from the collection.</summary>
		/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove from the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Remove(ToolStripItem value)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			base.InnerList.Remove(value);
			OnAfterRemove(value);
			value.InternalParent = null;
		}

		/// Removes an item from the specified index in the collection.</summary>
		/// <param name="index">The index value of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove. </param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void RemoveAt(int index)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			ToolStripItem toolStripItem = null;
			if (index < Count && index >= 0)
			{
				toolStripItem = (ToolStripItem)base.InnerList[index];
			}
			base.InnerList.RemoveAt(index);
			OnAfterRemove(toolStripItem);
			if (toolStripItem != null)
			{
				toolStripItem.InternalParent = null;
			}
		}

		/// Removes the item that has the specified key.</summary>
		/// <param name="key">The key of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove. </param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual void RemoveByKey(string key)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			int num = IndexOfKey(key);
			if (IsValidIndex(num))
			{
				RemoveAt(num);
			}
		}

		private void CheckCanAddOrInsertItem(ToolStripItem value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (IsReadOnly)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
			}
			if (mobjOwnerToolStrip is ToolStripDropDown toolStripDropDown && toolStripDropDown.OwnerItem == value)
			{
				throw new NotSupportedException(SR.GetString("ToolStripItemCircularReference"));
			}
		}

		private ArrayList FindInternal(string key, bool searchAllChildren, ToolStripItemCollection itemsToLookIn, ArrayList foundItems)
		{
			if (itemsToLookIn == null || foundItems == null)
			{
				return null;
			}
			try
			{
				for (int i = 0; i < itemsToLookIn.Count; i++)
				{
					if (itemsToLookIn[i] != null)
					{
						foundItems.Add(itemsToLookIn[i]);
					}
				}
				if (!searchAllChildren)
				{
					return foundItems;
				}
				for (int j = 0; j < itemsToLookIn.Count; j++)
				{
					if (itemsToLookIn[j] is ToolStripDropDownItem { HasDropDownItems: not false } toolStripDropDownItem)
					{
						foundItems = FindInternal(key, searchAllChildren, toolStripDropDownItem.DropDownItems, foundItems);
					}
				}
			}
			catch (Exception objException)
			{
				if (ClientUtils.IsCriticalException(objException))
				{
					throw;
				}
			}
			return foundItems;
		}

		int IList.Add(object objValue)
		{
			return Add(objValue as ToolStripItem);
		}

		void IList.Clear()
		{
			Clear();
		}

		bool IList.Contains(object objValue)
		{
			return base.InnerList.Contains(objValue);
		}

		int IList.IndexOf(object objValue)
		{
			return IndexOf(objValue as ToolStripItem);
		}

		void IList.Insert(int index, object objValue)
		{
			Insert(index, objValue as ToolStripItem);
		}

		void IList.Remove(object objValue)
		{
			Remove(objValue as ToolStripItem);
		}

		void IList.RemoveAt(int intIndex)
		{
			RemoveAt(intIndex);
		}

		private bool IsValidIndex(int intIndex)
		{
			return intIndex >= 0 && intIndex < Count;
		}

		private void OnAfterRemove(ToolStripItem objToolStripItem)
		{
			if (mblnItemsCollection)
			{
				objToolStripItem?.SetOwner(null);
				if (mobjOwnerToolStrip != null)
				{
					mobjOwnerToolStrip.OnItemRemoved(new ToolStripItemEventArgs(objToolStripItem));
				}
			}
		}

		private void SetOwner(ToolStripItem objToolStripItem)
		{
			if (mblnItemsCollection && objToolStripItem != null)
			{
				if (objToolStripItem.Owner != null)
				{
					objToolStripItem.Owner.Items.Remove(objToolStripItem);
				}
				objToolStripItem.SetOwner(mobjOwnerToolStrip);
			}
		}

		internal void MoveItem(ToolStripItem objToolStripItem)
		{
			if (objToolStripItem.ParentInternal != null)
			{
				int num = objToolStripItem.ParentInternal.Items.IndexOf(objToolStripItem);
				if (num >= 0)
				{
					objToolStripItem.ParentInternal.Items.RemoveAt(num);
				}
			}
			Add(objToolStripItem);
		}

		internal void MoveItem(int index, ToolStripItem objToolStripItem)
		{
			if (index == Count)
			{
				MoveItem(objToolStripItem);
				return;
			}
			if (objToolStripItem.ParentInternal != null)
			{
				int num = objToolStripItem.ParentInternal.Items.IndexOf(objToolStripItem);
				if (num >= 0)
				{
					objToolStripItem.ParentInternal.Items.RemoveAt(num);
					if (objToolStripItem.ParentInternal == mobjOwnerToolStrip && index > num)
					{
						index--;
					}
				}
			}
			Insert(index, objToolStripItem);
		}
	}
}
