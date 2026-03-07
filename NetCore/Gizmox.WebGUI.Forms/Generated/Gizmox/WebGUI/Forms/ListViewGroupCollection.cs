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
	/// Represents the collection of groups within a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
	[Serializable]
	[ListBindable(false)]
	public class ListViewGroupCollection : IList, ICollection, IEnumerable
	{
		/// 
		///
		/// </summary>
		private ArrayList mobjGroups;

		/// 
		///
		/// </summary>
		private object mobjOwner;

		/// 
		/// Gets the list.
		/// </summary>
		/// The list.</value>
		private ArrayList List
		{
			get
			{
				if (mobjGroups == null)
				{
					mobjGroups = new ArrayList();
				}
				return mobjGroups;
			}
		}

		/// Gets the number of groups in the collection.</summary>
		/// The number of groups in the collection.</returns>
		/// 1</filterpriority>
		public int Count => List.Count;

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</returns>
		/// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to get or set. </param>
		/// 1</filterpriority>
		public ListViewGroup this[int index]
		{
			get
			{
				return (ListViewGroup)List[index];
			}
			set
			{
				if (!List.Contains(value))
				{
					List[index] = value;
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> with the specified <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property value. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> with the specified name.</returns>
		/// <param name="strKey">The name of the group to get or set.</param>
		public ListViewGroup this[string strKey]
		{
			get
			{
				if (mobjGroups != null)
				{
					for (int i = 0; i < mobjGroups.Count; i++)
					{
						if (string.Compare(strKey, this[i].Name, ignoreCase: false, CultureInfo.CurrentCulture) == 0)
						{
							return this[i];
						}
					}
				}
				return null;
			}
			set
			{
				int num = -1;
				if (mobjGroups == null)
				{
					return;
				}
				for (int i = 0; i < mobjGroups.Count; i++)
				{
					if (string.Compare(strKey, this[i].Name, ignoreCase: false, CultureInfo.CurrentCulture) == 0)
					{
						num = i;
						break;
					}
				}
				if (num != -1)
				{
					mobjGroups[num] = value;
				}
			}
		}

		/// 
		/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
		/// </summary>
		/// </value>
		/// true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.</returns>
		bool ICollection.IsSynchronized => true;

		/// 
		/// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
		/// </summary>
		/// </value>
		/// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
		object ICollection.SyncRoot => this;

		/// 
		/// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
		/// </summary>
		/// </value>
		/// true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.</returns>
		bool IList.IsFixedSize => false;

		/// 
		/// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.
		/// </summary>
		/// </value>
		/// true if the <see cref="T:System.Collections.IList" /> is read-only; otherwise, false.</returns>
		bool IList.IsReadOnly => false;

		/// 
		/// Gets or sets the <see cref="T:System.Object" /> at the specified index.
		/// </summary>
		/// </value>
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				if (value is ListViewGroup)
				{
					this[index] = (ListViewGroup)value;
				}
			}
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to the collection.</summary>
		/// The index of the group within the collection, or -1 if the group is already present in the collection.</returns>
		/// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to add to the collection. </param>
		/// <exception cref="T:System.ArgumentException">group contains at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
		public int Add(ListViewGroup objGroup)
		{
			if (Contains(objGroup))
			{
				return -1;
			}
			objGroup.ListViewInternal = GetOwnerListView();
			return List.Add(objGroup);
		}

		/// Adds a new <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to the collection using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> and <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> properties </summary>
		/// The new <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see>.</returns>
		/// <param name="strHeaderText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property for the new group.</param>
		/// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property for the new group.</param>
		public ListViewGroup Add(string strKey, string strHeaderText)
		{
			ListViewGroup listViewGroup = new ListViewGroup(strKey, strHeaderText);
			Add(listViewGroup);
			return listViewGroup;
		}

		/// Adds an array of groups to the collection.</summary>
		/// <param name="arrGroups">An array of type <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> that specifies the groups to add to the collection. </param>
		/// <exception cref="T:System.ArgumentException">groups contains at least one group with at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
		public void AddRange(ListViewGroup[] arrGroups)
		{
			for (int i = 0; i < arrGroups.Length; i++)
			{
				Add(arrGroups[i]);
			}
		}

		/// Adds the groups in an existing <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> to the collection.</summary>
		/// <param name="objGroups">A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> containing the groups to add to the collection. </param>
		/// <exception cref="T:System.ArgumentException">groups contains at least one group with at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
		public void AddRange(ListViewGroupCollection objGroups)
		{
			for (int i = 0; i < objGroups.Count; i++)
			{
				Add(objGroups[i]);
			}
		}

		/// Removes all groups from the collection.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Clear()
		{
			for (int num = List.Count - 1; num >= 0; num--)
			{
				Remove(this[num]);
			}
		}

		/// 
		/// Clears the internal.
		/// </summary>
		internal void ClearInternal()
		{
			for (int num = List.Count - 1; num >= 0; num--)
			{
				List.Remove(this[num]);
			}
		}

		/// Determines whether the specified group is located in the collection.</summary>
		/// true if the group is in the collection; otherwise, false.</returns>
		/// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to locate in the collection. </param>
		/// 1</filterpriority>
		public bool Contains(ListViewGroup value)
		{
			return List.Contains(value);
		}

		/// Copies the groups in the collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
		/// <param name="objArray">The <see cref="T:System.Array"></see> to which the groups are copied. </param>
		/// <param name="index">The first index within the array to which the groups are copied. </param>
		/// 1</filterpriority>
		public void CopyTo(Array objArray, int index)
		{
			List.CopyTo(objArray, index);
		}

		/// Returns an enumerator used to iterate through the collection.</summary>
		/// An <see cref="T:System.Collections.IEnumerator"></see> that represents the collection.</returns>
		/// 1</filterpriority>
		public IEnumerator GetEnumerator()
		{
			return List.GetEnumerator();
		}

		/// Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> within the collection.</summary>
		/// The zero-based index of the group within the collection, or -1 if the group is not in the collection.</returns>
		/// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to locate in the collection. </param>
		/// 1</filterpriority>
		public int IndexOf(ListViewGroup value)
		{
			return List.IndexOf(value);
		}

		/// Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> into the collection at the specified index.</summary>
		/// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to insert into the collection. </param>
		/// <param name="index">The index within the collection at which to insert the group. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Insert(int index, ListViewGroup objGroup)
		{
			if (!Contains(objGroup))
			{
				objGroup.ListViewInternal = GetOwnerListView();
				List.Insert(index, objGroup);
			}
		}

		/// 
		/// Gets the owner list view.
		/// </summary>
		/// </returns>
		private ListView GetOwnerListView()
		{
			if (mobjOwner is ListView result)
			{
				return result;
			}
			if (!(mobjOwner is ListViewGroup { ListView: var listView }))
			{
				return null;
			}
			return listView;
		}

		/// Removes the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> from the collection.</summary>
		/// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to remove from the collection. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Remove(ListViewGroup objGroup)
		{
			ClearGroup(objGroup);
			List.Remove(objGroup);
		}

		/// Removes the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</summary>
		/// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to remove. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void RemoveAt(int index)
		{
			Remove(this[index]);
		}

		/// 
		/// Adds an item to the <see cref="T:System.Collections.IList" />.
		/// </summary>
		/// <param name="objValue">The <see cref="T:System.Object" /> to add to the <see cref="T:System.Collections.IList" />.</param>
		/// 
		/// The position into which the new element was inserted.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
		int IList.Add(object objValue)
		{
			if (!(objValue is ListViewGroup))
			{
				throw new ArgumentException("value");
			}
			return Add((ListViewGroup)objValue);
		}

		/// 
		/// Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.
		/// </summary>
		/// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
		/// 
		/// true if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, false.
		/// </returns>
		bool IList.Contains(object objValue)
		{
			return objValue is ListViewGroup && Contains((ListViewGroup)objValue);
		}

		/// 
		/// Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.
		/// </summary>
		/// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
		/// 
		/// The index of <paramref name="value" /> if found in the list; otherwise, -1.
		/// </returns>
		int IList.IndexOf(object objValue)
		{
			if (objValue is ListViewGroup)
			{
				return IndexOf((ListViewGroup)objValue);
			}
			return -1;
		}

		/// 
		/// Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
		/// <param name="objValue">The <see cref="T:System.Object" /> to insert into the <see cref="T:System.Collections.IList" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// 	<paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
		/// <exception cref="T:System.NullReferenceException">
		/// 	<paramref name="value" /> is null reference in the <see cref="T:System.Collections.IList" />.</exception>
		void IList.Insert(int index, object objValue)
		{
			if (objValue is ListViewGroup)
			{
				Insert(index, (ListViewGroup)objValue);
			}
		}

		/// 
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.
		/// </summary>
		/// <param name="objValue">The <see cref="T:System.Object" /> to remove from the <see cref="T:System.Collections.IList" />.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
		void IList.Remove(object objValue)
		{
			if (objValue is ListViewGroup)
			{
				Remove((ListViewGroup)objValue);
			}
		}

		/// 
		/// Clears the group.
		/// </summary>
		/// <param name="objGroup">The group.</param>
		private void ClearGroup(ListViewGroup objGroup)
		{
			if (objGroup == null)
			{
				return;
			}
			if (objGroup.Groups.Count > 0)
			{
				objGroup.Groups.Clear();
			}
			if (objGroup.Items.Count > 0)
			{
				for (int num = objGroup.Items.Count - 1; num >= 0; num--)
				{
					ListViewItem listViewItem = objGroup.Items[num];
					if (listViewItem != null)
					{
						listViewItem.Group = null;
					}
				}
				if (objGroup.ListViewInternal != null)
				{
					objGroup.ListViewInternal.Update();
				}
			}
			objGroup.ListViewInternal = null;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection" /> class.
		/// </summary>
		/// <param name="objOwner">The owner list view.</param>
		internal ListViewGroupCollection(ListView objOwner)
		{
			mobjOwner = objOwner;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection" /> class.
		/// </summary>
		/// <param name="objOwner">The owner list view.</param>
		/// <param name="arrGroups">The arr groups.</param>
		internal ListViewGroupCollection(ListView objOwner, object[] arrGroups)
		{
			mobjOwner = objOwner;
			mobjGroups = new ArrayList(arrGroups);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection" /> class.
		/// </summary>
		/// <param name="objOwner">The owner list view group.</param>
		internal ListViewGroupCollection(ListViewGroup objOwner)
		{
			mobjOwner = objOwner;
		}
	}
}
