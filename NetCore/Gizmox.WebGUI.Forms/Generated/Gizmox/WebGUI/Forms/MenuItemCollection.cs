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
	///
	/// </summary>
	[Serializable]
	public class MenuItemCollection : ICollection, IEnumerable, IList, INotifyCollectionChanged
	{
		private ArrayList mobjMenus = null;

		private Component mobjParent = null;

		/// 
		/// Gets the menu item count.
		/// </summary>
		/// </value>
		public int Count => mobjMenus.Count;

		bool IList.IsReadOnly => mobjMenus.IsReadOnly;

		/// 
		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> at the specified index.
		/// </summary>
		/// </value>
		public MenuItem this[int index] => (MenuItem)mobjMenus[index];

		object IList.this[int index]
		{
			get
			{
				return mobjMenus[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		bool IList.IsFixedSize => mobjMenus.IsFixedSize;

		/// 
		/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
		/// </summary>
		/// </value>
		/// true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.
		/// </returns>
		public bool IsSynchronized => mobjMenus.IsSynchronized;

		/// 
		/// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
		/// </summary>
		/// </value>
		/// 
		/// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
		/// </returns>
		public object SyncRoot => mobjMenus.SyncRoot;

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItemCollection" /> class.
		/// </summary>
		/// <param name="objParent">The obj parent.</param>
		public MenuItemCollection(Component objParent)
		{
			mobjMenus = new ArrayList();
			mobjParent = objParent;
		}

		/// 
		/// Removes a <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> from the menu
		/// item collection at a specified index.</para>
		/// </summary>
		/// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> to remove.</param>
		public virtual void RemoveAt(int index)
		{
			if (mobjMenus != null)
			{
				Remove(mobjMenus[index] as MenuItem);
			}
		}

		/// 
		/// Adds a previously created <see cref="T:Gizmox.WebGUI.Forms.MenuItem" />
		/// at the
		/// specified index within the menu item collection.</para>
		/// </summary>
		/// <param name="index">The position to add the new item.</param>
		/// <param name="objItem">The <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> to add.</param>
		/// 
		/// The zero-based index where the item is stored in the collection.</para>
		/// </returns>
		/// <exception cref="T:System.Exception">The <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> being added is already in use.</exception>
		/// <exception cref="T:System.ArgumentException">The index supplied in the <paramref name="index" /> parameter is larger than the size of the collection.</exception>
		public virtual int Add(int index, MenuItem objItem)
		{
			if (mobjMenus != null)
			{
				mobjMenus.Insert(index, objItem);
				return index;
			}
			return -1;
		}

		/// 
		/// Adds a previously created MenuItem to the end of the current menu.
		/// </summary>
		/// <param name="objMenuItem">The MenuItem to add.</param>
		/// The zero-based index where the item is stored in the collection.</returns>
		public int Add(MenuItem objMenuItem)
		{
			objMenuItem.InternalParent = mobjParent;
			mobjParent.Update();
			int result = mobjMenus.Add(objMenuItem);
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, objMenuItem));
			}
			return result;
		}

		/// 
		/// Adds a new MenuItem to the end of the current menu with a specified caption and a specified event handler for the Click event.
		/// </summary>
		/// <param name="strCaption">The caption of the menu item.</param>
		/// <param name="objOnClick">An EventHandler that represents the event handler that is called when the item is clicked by the user, or when a user presses an accelerator or shortcut key for the menu item.</param>
		/// A MenuItem that represents the menu item being added to the collection.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public MenuItem Add(string strCaption, EventHandler objOnClick)
		{
			MenuItem menuItem = new MenuItem(strCaption, objOnClick);
			Add(menuItem);
			return menuItem;
		}

		/// 
		/// Adds the range.
		/// </summary>
		/// <param name="arrMenuItems">The obj menu items.</param>
		public void AddRange(MenuItem[] arrMenuItems)
		{
			MenuItem[] array = new MenuItem[arrMenuItems.Length];
			bool flag = true;
			foreach (MenuItem menuItem in arrMenuItems)
			{
				if (flag && menuItem.Index >= 0 && menuItem.Index < array.Length)
				{
					array[menuItem.Index] = menuItem;
					continue;
				}
				flag = false;
				Add(menuItem);
			}
			if (flag)
			{
				for (int j = 0; j < array.Length; j++)
				{
					Add(array[j]);
				}
			}
		}

		/// 
		/// Determines whether [contains] [the specified obj menu item].
		/// </summary>
		/// <param name="objMenuItem">The obj menu item.</param>
		/// 
		/// 	true</c> if [contains] [the specified obj menu item]; otherwise, false</c>.
		/// </returns>
		public bool Contains(MenuItem objMenuItem)
		{
			return mobjMenus.Contains(objMenuItem);
		}

		internal void AttachedToDOM()
		{
			foreach (MenuItem mobjMenu in mobjMenus)
			{
				mobjMenu.AttachedToDOM();
			}
		}

		internal void RemovingFromDOM()
		{
			foreach (MenuItem mobjMenu in mobjMenus)
			{
				mobjMenu.RemovingFromDOM();
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objMenuItem"></param>
		public void Remove(MenuItem objMenuItem)
		{
			if (objMenuItem.InternalParent == mobjParent && mobjParent != null)
			{
				((IRegisteredComponent)mobjParent).UnregisterContextMenu();
				objMenuItem.InternalParent = null;
			}
			mobjMenus.Remove(objMenuItem);
			mobjParent.Update();
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, objMenuItem));
			}
		}

		/// 
		/// Removes all items from the <see cref="T:System.Collections.IList" />.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">
		/// The <see cref="T:System.Collections.IList" /> is read-only.
		/// </exception>
		public void Clear()
		{
			mobjMenus.Clear();
			mobjParent.Update();
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			return mobjMenus.GetEnumerator();
		}

		void IList.RemoveAt(int index)
		{
			mobjMenus.RemoveAt(index);
		}

		void IList.Insert(int index, object objValue)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object objValue)
		{
			Remove((MenuItem)objValue);
		}

		bool IList.Contains(object objValue)
		{
			return Contains((MenuItem)objValue);
		}

		void IList.Clear()
		{
			mobjMenus.Clear();
		}

		int IList.IndexOf(object objValue)
		{
			return mobjMenus.IndexOf(objValue);
		}

		int IList.Add(object objValue)
		{
			if (objValue is MenuItem)
			{
				Add((MenuItem)objValue);
				return mobjMenus.IndexOf((MenuItem)objValue);
			}
			throw new ArgumentException("value");
		}

		/// 
		/// Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
		/// </summary>
		/// <param name="objArray">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// 	<paramref name="array" /> is null.
		/// </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// 	<paramref name="index" /> is less than zero.
		/// </exception>
		/// <exception cref="T:System.ArgumentException">
		/// 	<paramref name="objArray" /> is multidimensional.
		/// -or-
		/// <paramref name="index" /> is equal to or greater than the length of <paramref name="array" />.
		/// -or-
		/// The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.
		/// </exception>
		/// <exception cref="T:System.ArgumentException">
		/// The type of the source <see cref="T:System.Collections.ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.
		/// </exception>
		public void CopyTo(Array objArray, int index)
		{
			mobjMenus.CopyTo(objArray, index);
		}
	}
}
