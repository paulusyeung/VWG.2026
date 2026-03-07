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
	public class ToolBarItemCollection : ICollection, IEnumerable, IList, IObservableList
	{
		private ArrayList mobjButtons = null;

		private ToolBar mobjToolBar;

		/// 
		/// Gets the list.
		/// </summary>
		/// The list.</value>
		protected virtual ArrayList List => mobjButtons;

		/// 
		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton" /> with the specified int index.
		/// </summary>
		/// </value>
		public ToolBarButton this[int intIndex]
		{
			get
			{
				return (ToolBarButton)List[intIndex];
			}
			set
			{
				value.InternalParent = mobjToolBar;
				List[intIndex] = value;
			}
		}

		bool IList.IsReadOnly => false;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (ToolBarButton)value;
			}
		}

		bool IList.IsFixedSize => false;

		bool ICollection.IsSynchronized => mobjButtons.IsSynchronized;

		/// 
		/// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
		/// </summary>
		/// </value>
		/// 
		/// The number of elements contained in the <see cref="T:System.Collections.ICollection" />.
		/// </returns>
		public int Count => mobjButtons.Count;

		object ICollection.SyncRoot => mobjButtons.SyncRoot;

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
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ToolBarItemCollection" /> instance.
		/// </summary>
		/// <param name="objToolBar">The obj tool bar.</param>
		public ToolBarItemCollection(ToolBar objToolBar)
		{
			mobjToolBar = objToolBar;
			mobjButtons = new ArrayList();
		}

		/// 
		///
		/// </summary>
		/// <param name="objToolBarButton"></param>
		/// </returns>
		public int Add(ToolBarButton objToolBarButton)
		{
			int result = -1;
			if (objToolBarButton != null)
			{
				objToolBarButton.ToolBar = mobjToolBar;
				objToolBarButton.InternalParent = mobjToolBar;
				result = List.Add(objToolBarButton);
				mobjToolBar.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				mobjToolBar.Update();
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(objToolBarButton));
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="arrToolBarButtons"></param>
		public void AddRange(ToolBarButton[] arrToolBarButtons)
		{
			foreach (ToolBarButton objToolBarButton in arrToolBarButtons)
			{
				Add(objToolBarButton);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objToolBarButton"></param>
		public void Remove(ToolBarButton objToolBarButton)
		{
			if (objToolBarButton != null)
			{
				if (objToolBarButton.ToolBar == mobjToolBar)
				{
					objToolBarButton.ToolBar = null;
				}
				mobjToolBar.InternalRemove(objToolBarButton);
				List.Remove(objToolBarButton);
				mobjToolBar.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				mobjToolBar.Update();
				if (this.ObservableItemRemoved != null)
				{
					this.ObservableItemRemoved(this, new ObservableListEventArgs(objToolBarButton));
				}
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
			mobjToolBar.InternalClear(List);
			mobjButtons.Clear();
			if (this.ObservableListCleared != null)
			{
				this.ObservableListCleared(this, EventArgs.Empty);
			}
		}

		/// 
		/// Return the index of objToolBarButton in the Buttons collection
		/// </summary>
		/// <param name="objToolBarButton"></param>
		public int IndexOf(ToolBarButton objToolBarButton)
		{
			return mobjButtons.IndexOf(objToolBarButton);
		}

		void IList.RemoveAt(int index)
		{
			Remove(this[index]);
		}

		void IList.Insert(int index, object objValue)
		{
		}

		void IList.Remove(object objValue)
		{
			Remove((ToolBarButton)objValue);
		}

		bool IList.Contains(object objValue)
		{
			return mobjButtons.Contains(objValue);
		}

		int IList.IndexOf(object objValue)
		{
			return mobjButtons.IndexOf(objValue);
		}

		int IList.Add(object objValue)
		{
			return Add((ToolBarButton)objValue);
		}

		void ICollection.CopyTo(Array objArray, int index)
		{
			List.CopyTo(objArray, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return mobjButtons.GetEnumerator();
		}
	}
}
