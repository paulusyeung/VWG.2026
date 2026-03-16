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
	/// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects.
	/// </summary>
	[Serializable]
	public class ProxyTabPageCollection : ICollection, IEnumerable, IList, IComparer
	{
		/// 
		/// Implements IComparer for TabPages sorting by TabIndex
		/// </summary>
		/// </returns>
		[Serializable]
		private class ProxyTabIndexComparer : IComparer
		{
			int IComparer.Compare(object objX, object objY)
			{
				TabPage tabPage = (objX as ProxyTabPage).SourceComponent as TabPage;
				TabPage tabPage2 = (objY as ProxyTabPage).SourceComponent as TabPage;
				if (tabPage != null && tabPage2 != null)
				{
					return tabPage.TabIndex.CompareTo(tabPage2.TabIndex);
				}
				return 0;
			}
		}

		/// 
		/// The mobj proxy tab control
		/// </summary>
		private ProxyTabControl mobjProxyTabControl = null;

		/// 
		/// The mobj tab control
		/// </summary>
		private TabControl mobjTabControl = null;

		/// 
		/// Gets or sets the owner.
		/// </summary>
		/// 
		/// The owner.
		/// </value>
		protected ProxyTabControl Owner => mobjProxyTabControl;

		/// 
		/// Gets a value indicating whether access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is synchronized (thread safe).
		/// </summary>
		/// false in all cases.</returns>
		public bool IsSynchronized => ((ICollection)mobjProxyTabControl.Components).IsSynchronized;

		/// 
		/// Gets the number of tab pages in the collection.
		/// </summary>
		/// The number of tab pages in the collection.</returns>
		[Browsable(false)]
		public int Count => mobjProxyTabControl.Components.Count;

		/// 
		/// Gets an object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
		/// </summary>
		/// An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
		public object SyncRoot => ((ICollection)mobjProxyTabControl.Components).SyncRoot;

		/// 
		/// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
		/// </summary>
		/// <param name="index">The zero-based index of the tab page to get or set.</param>
		/// 
		/// The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the highest available index.</exception>
		public ProxyTabPage this[int index] => (ProxyTabPage)mobjProxyTabControl.Components[index];

		/// 
		/// Gets a value indicating whether the collection is read-only.
		/// </summary>
		/// This property always returns false.</returns>
		public bool IsReadOnly => false;

		/// 
		/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> has a fixed size.
		/// </summary>
		/// false in all cases.</returns>
		public bool IsFixedSize => false;

		/// 
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// </returns>
		object IList.this[int index]
		{
			get
			{
				return Owner.Components[index];
			}
			set
			{
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabPageCollection" /> class.
		/// </summary>
		/// <param name="objOwner">The object owner.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ProxyTabPageCollection(ProxyTabControl objOwner)
		{
			mobjProxyTabControl = objOwner;
			mobjTabControl = mobjProxyTabControl.SourceComponent as TabControl;
		}

		/// 
		/// Copies the elements of the collection to the specified array, starting at the specified index.
		/// </summary>
		/// <param name="objDestArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in the array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentException">dest is multidimensional.-or-index is equal to or greater than the length of dest.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is greater than the available space from index to the end of dest.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
		/// <exception cref="T:System.InvalidCastException">The items in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> cannot be cast automatically to the type of dest.</exception>
		/// <exception cref="T:System.ArgumentNullException">dest is null.</exception>
		public void CopyTo(Array objDestArray, int index)
		{
			List<object> list = new List<object>();
			foreach (ProxyComponent component in mobjProxyTabControl.Components)
			{
				list.Add(component);
			}
			list.ToArray().CopyTo(objDestArray, index);
		}

		/// 
		/// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to the collection.
		/// </summary>
		/// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add.</param>
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">The specified value is null.</exception>
		public virtual int Add(object objTabPage)
		{
			ProxyComponent proxyComponent = objTabPage as ProxyComponent;
			Insert(Count, proxyComponent);
			return mobjProxyTabControl.Components.IndexOf(proxyComponent);
		}

		/// 
		/// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
		/// </summary>
		/// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
		/// <exception cref="T:System.ArgumentNullException">The value parameter is null.</exception>
		public virtual void Remove(object objTabPage)
		{
			ProxyTabPage proxyTabPage = objTabPage as ProxyTabPage;
			mobjProxyTabControl.Components.Remove(proxyTabPage);
			mobjTabControl.Controls.Remove(proxyTabPage.SourceComponent as Control);
		}

		/// 
		/// Returns an enumeration of all the tab pages in the collection.
		/// </summary>
		/// 
		/// An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return mobjProxyTabControl.Components.GetEnumerator();
		}

		/// 
		/// Returns the index of the specified tab page in the collection.
		/// </summary>
		/// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection.</param>
		/// 
		/// The zero-based index of the tab page; -1 if it cannot be found.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">The value of page is null.</exception>
		public int IndexOf(object objTabPage)
		{
			ProxyTabPage item = objTabPage as ProxyTabPage;
			return mobjProxyTabControl.Components.IndexOf(item);
		}

		/// 
		/// Removes the tab page at the specified index from the collection.
		/// </summary>
		/// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
		public void RemoveAt(int index)
		{
			mobjProxyTabControl.Components.RemoveAt(index);
			mobjTabControl.Controls.RemoveAt(index);
		}

		/// 
		/// Inserts an existing tab page into the collection at the specified index.
		/// </summary>
		/// <param name="index">The location where the tab page is inserted.</param>
		/// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to insert in the collection.</param>
		public void Insert(int index, object objTabPage)
		{
			if (!(objTabPage is ProxyTabPage proxyTabPage))
			{
				throw new ArgumentException($"Cannot add component of type '{objTabPage.GetType().Name}' to container of type 'ProxyTabControl'");
			}
			if (proxyTabPage.SourceComponent == null && string.IsNullOrEmpty(proxyTabPage.UniqueID))
			{
				proxyTabPage.NonStateComponentType = typeof(TabPage).FullName;
				proxyTabPage.Parent = Owner;
			}
			mobjTabControl.TabPages.Insert(index, proxyTabPage.SourceComponent as TabPage);
			Hashtable hashtable = new Hashtable();
			if (proxyTabPage == null)
			{
				return;
			}
			if (Count == 0)
			{
				mobjProxyTabControl.Components.Add(proxyTabPage);
				return;
			}
			foreach (ProxyTabPage item in (IEnumerable)this)
			{
				TabPage tabPage = item.SourceComponent as TabPage;
				hashtable.Add(tabPage.GetHashCode(), tabPage.TabIndex);
				tabPage.TabIndex = IndexOf(item);
			}
			if (index > Count || index < 0)
			{
				index = Count;
			}
			AdvanceTabIndexFromIndex((ushort)index, 1);
			mobjProxyTabControl.Components.Add(proxyTabPage);
			(proxyTabPage.SourceComponent as TabPage).TabIndex = index;
			mobjProxyTabControl.Components.Sort(delegate(ProxyComponent objX, ProxyComponent objY)
			{
				TabPage tabPage2 = objX.SourceComponent as TabPage;
				TabPage tabPage3 = objY.SourceComponent as TabPage;
				return (tabPage2 != null && tabPage3 != null) ? tabPage2.TabIndex.CompareTo(tabPage3.TabIndex) : 0;
			});
		}

		/// 
		/// Returns a sorted TabPage list from current unsorted TabPageCollection.
		/// </summary>
		/// <param name="blnSortByIndex">if set to true</c> [BLN sort by index].</param>
		/// </returns>
		protected ArrayList GetSortedTabPageListFromCurrent(bool blnSortByIndex)
		{
			ArrayList arrayList = new ArrayList();
			foreach (ProxyTabPage item in (IEnumerable)this)
			{
				arrayList.Add(item);
			}
			if (blnSortByIndex)
			{
				arrayList.Sort(this);
			}
			else
			{
				arrayList.Sort(new ProxyTabIndexComparer());
			}
			return arrayList;
		}

		/// 
		/// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
		/// </summary>
		/// <param name="usrFromIndex">Index of the usr from.</param>
		/// <param name="usrAdvanceBy">The usr advance by.</param>
		protected void AdvanceTabIndexFromIndex(ushort usrFromIndex, ushort usrAdvanceBy)
		{
			if (Count >= 2)
			{
				ArrayList objTabPageList = GetSortedTabPageListFromCurrent(blnSortByIndex: true);
				AdvanceTabIndexFromIndex(ref objTabPageList, usrFromIndex, usrAdvanceBy);
			}
		}

		/// 
		/// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
		/// </summary>
		/// <param name="objTabPageList">The obj tab page list.</param>
		/// <param name="usrFromIndex">Index of the usr from.</param>
		/// <param name="usrAdvanceBy">The usr advance by.</param>
		protected void AdvanceTabIndexFromIndex(ref ArrayList objTabPageList, ushort usrFromIndex, ushort usrAdvanceBy)
		{
			TabPage tabPage = null;
			if (usrFromIndex < 0 || usrAdvanceBy <= 0 || usrFromIndex > objTabPageList.Count - 1)
			{
				return;
			}
			for (ushort num = usrFromIndex; num < objTabPageList.Count; num++)
			{
				if ((objTabPageList[num] as ProxyTabPage).SourceComponent is TabPage tabPage2)
				{
					tabPage2.TabIndex += usrAdvanceBy;
				}
			}
		}

		/// 
		/// Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control is in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
		/// </summary>
		/// <param name="objValue">The object to locate in the collection.</param>
		/// 
		/// true if the specified object is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise, false.
		/// </returns>
		public bool Contains(object objValue)
		{
			ProxyTabPage item = objValue as ProxyTabPage;
			return mobjProxyTabControl.Components.Contains(item);
		}

		/// 
		/// Removes all the tab pages from the collection.
		/// </summary>
		public void Clear()
		{
			mobjProxyTabControl.Components.Clear();
			mobjTabControl.Controls.Clear();
		}

		/// 
		/// Compares the index of two sequencial TabPages in the TabPageCollection.
		/// </summary>
		/// <param name="objArgFirstTP">The first TabPage.</param>
		/// <param name="objArgSecondTP">The second TabPage.</param>
		/// </returns>
		public int Compare(object objArgFirstTP, object objArgSecondTP)
		{
			TabPage tabPage = (objArgFirstTP as ProxyTabPage).SourceComponent as TabPage;
			TabPage tabPage2 = (objArgFirstTP as ProxyTabPage).SourceComponent as TabPage;
			if (tabPage == null || tabPage2 == null)
			{
				return 0;
			}
			return IndexOf(objArgFirstTP).CompareTo(IndexOf(objArgSecondTP));
		}
	}
}
