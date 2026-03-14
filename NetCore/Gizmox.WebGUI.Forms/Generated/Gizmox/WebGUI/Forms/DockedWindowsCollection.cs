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
	public class DockedWindowsCollection : ICollection, IEnumerable
	{
		/// 
		///
		/// </summary>
		private DockingManager mobjManager;

		private Dictionary<DockingWindowName, DockingWindow> mobjWindowsIndexByWindowName;

		private Dictionary<DockingWindowName, DockingWindow> mobjHiddenWindowsIndexByWindowName;

		/// 
		/// Gets the manager.
		/// </summary>
		public DockingManager Manager
		{
			get
			{
				return mobjManager;
			}
			internal set
			{
				mobjManager = value;
			}
		}

		/// 
		/// Gets the name of the windows index by window.
		/// </summary>
		/// 
		/// The name of the windows index by window.
		/// </value>
		internal Dictionary<DockingWindowName, DockingWindow> WindowsIndexByWindowName => mobjWindowsIndexByWindowName;

		/// 
		/// Gets the name of the hidden windows index by window.
		/// </summary>
		/// 
		/// The name of the hidden windows index by window.
		/// </value>
		internal Dictionary<DockingWindowName, DockingWindow> HiddenWindowsIndexByWindowName => mobjHiddenWindowsIndexByWindowName;

		/// 
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
		public int Count => mobjWindowsIndexByWindowName.Count;
        void ICollection.CopyTo(Array array, int index) { ((ICollection)mobjWindowsIndexByWindowName.Values).CopyTo(array, index); }
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => ((ICollection)mobjWindowsIndexByWindowName.Values).SyncRoot;

		/// 
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
		/// </summary>
		/// true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
		public bool IsReadOnly => false;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedWindowsCollection" /> class.
		/// </summary>
		public DockedWindowsCollection()
		{
			mobjWindowsIndexByWindowName = new Dictionary<DockingWindowName, DockingWindow>(DockingWindowName.DockedWindowNameEqulityComparer);
			mobjHiddenWindowsIndexByWindowName = new Dictionary<DockingWindowName, DockingWindow>(DockingWindowName.DockedWindowNameEqulityComparer);
		}

		/// 
		/// Adds the window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		internal void AddWindowIfDoesntExist(DockingWindow objWindow)
		{
			objWindow.Manager = mobjManager;
			if (!mobjWindowsIndexByWindowName.ContainsKey(objWindow.WindowName))
			{
				mobjWindowsIndexByWindowName.Add(objWindow.WindowName, objWindow);
				return;
			}
			if (mobjWindowsIndexByWindowName[objWindow.WindowName] == objWindow)
			{
				throw new Exception("The given window already exists in the manager. In order to add a window of the same type, create a new instance of the window and give it a unique name");
			}
			throw new Exception("A window with the same name ('" + objWindow.WindowName.WindowName + "') already exists in the manager. In order to add a window, create a new instance of the window and give it a unique name");
		}

		/// 
		/// Removes the window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		/// </returns>
		internal bool RemoveWindow(DockingWindow objWindow)
		{
			return mobjWindowsIndexByWindowName.Remove(objWindow.WindowName);
		}

		/// 
		/// Adds the hidden window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		internal void AddHiddenWindow(DockingWindow objWindow)
		{
			objWindow.Manager = mobjManager;
			if (!mobjHiddenWindowsIndexByWindowName.ContainsKey(objWindow.WindowName))
			{
				DockState lastDockState;
				switch (objWindow.CurrentDockState)
				{
				case DockState.Float:
					lastDockState = DockState.Float;
					break;
				case DockState.Tabbed:
					lastDockState = DockState.Tabbed;
					break;
				case DockState.Dock:
				case DockState.AutoHide:
					lastDockState = DockState.Dock;
					break;
				case DockState.Hidden:
				case DockState.Close:
					lastDockState = objWindow.LastDockState;
					break;
				default:
					throw new Exception();
				}
				objWindow.LastDockState = lastDockState;
				mobjHiddenWindowsIndexByWindowName.Add(objWindow.WindowName, objWindow);
			}
		}

		/// 
		/// Removes the hidden window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		/// </returns>
		internal bool RemoveHiddenWindow(DockingWindow objWindow)
		{
			return mobjHiddenWindowsIndexByWindowName.Remove(objWindow.WindowName);
		}

		/// 
		/// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
		public void Add(DockingWindow item)
		{
			mobjManager.AddTabbedWindows(item);
		}

		/// 
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		public void Clear()
		{
			foreach (DockingWindow value in mobjWindowsIndexByWindowName.Values)
			{
				value.Close();
			}
			mobjWindowsIndexByWindowName.Clear();
		}

		/// 
		/// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
		/// </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
		/// 
		/// true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
		/// </returns>
		public bool Contains(DockingWindow item)
		{
			return mobjWindowsIndexByWindowName.ContainsKey(item.WindowName);
		}

		/// 
		/// Copies to.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <param name="arrayIndex">Index of the array.</param>
		public void CopyTo(DockingWindow[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		/// 
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
		/// 
		/// true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
		public bool Remove(DockingWindow item)
		{
			if (!item.Closed)
			{
				item.Close();
				return true;
			}
			return false;
		}

		/// 
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// 
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator GetEnumerator()
		{
			return mobjWindowsIndexByWindowName.Values.GetEnumerator();
		}

		/// 
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// 
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return mobjWindowsIndexByWindowName.Values.GetEnumerator();
		}
	}
}
