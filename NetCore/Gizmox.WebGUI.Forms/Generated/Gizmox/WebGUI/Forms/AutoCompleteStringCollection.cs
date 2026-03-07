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
	public class AutoCompleteStringCollection : IList, ICollection, IEnumerable
	{
		private ArrayList mobjData = new ArrayList();

		private CollectionChangeEventHandler mobjCollectionChanged;

		/// 1</filterpriority>
		public int Count => mobjData.Count;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (string)value;
			}
		}

		/// 1</filterpriority>
		public bool IsReadOnly => false;

		/// 2</filterpriority>
		public bool IsSynchronized => false;

		/// 1</filterpriority>
		public object SyncRoot => this;

		/// 1</filterpriority>
		public string this[int index]
		{
			get
			{
				return (string)mobjData[index];
			}
			set
			{
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, mobjData[index]));
				mobjData[index] = value;
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, value));
			}
		}

		/// 
		/// Occurs when [collection changed].
		/// </summary>
		public event CollectionChangeEventHandler CollectionChanged
		{
			add
			{
				mobjCollectionChanged = (CollectionChangeEventHandler)Delegate.Combine(mobjCollectionChanged, value);
			}
			remove
			{
				mobjCollectionChanged = (CollectionChangeEventHandler)Delegate.Remove(mobjCollectionChanged, value);
			}
		}

		/// 1</filterpriority>
		public int Add(string value)
		{
			int result = mobjData.Add(value);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, value));
			return result;
		}

		/// 1</filterpriority>
		public void AddRange(string[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			mobjData.AddRange(value);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
		}

		/// 1</filterpriority>
		public void Clear()
		{
			mobjData.Clear();
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
		}

		/// 1</filterpriority>
		public bool Contains(string value)
		{
			return mobjData.Contains(value);
		}

		/// 1</filterpriority>
		public void CopyTo(string[] array, int index)
		{
			mobjData.CopyTo(array, index);
		}

		/// 1</filterpriority>
		public IEnumerator GetEnumerator()
		{
			return mobjData.GetEnumerator();
		}

		/// 1</filterpriority>
		public int IndexOf(string value)
		{
			return mobjData.IndexOf(value);
		}

		/// 1</filterpriority>
		public void Insert(int index, string value)
		{
			mobjData.Insert(index, value);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, value));
		}

		/// 1</filterpriority>
		public void Remove(string value)
		{
			mobjData.Remove(value);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, value));
		}

		/// 1</filterpriority>
		public void RemoveAt(int index)
		{
			string element = (string)mobjData[index];
			mobjData.RemoveAt(index);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, element));
		}

		protected void OnCollectionChanged(CollectionChangeEventArgs e)
		{
			if (mobjCollectionChanged != null)
			{
				mobjCollectionChanged(this, e);
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			mobjData.CopyTo(array, index);
		}

		int IList.Add(object value)
		{
			return Add((string)value);
		}

		bool IList.Contains(object value)
		{
			return Contains((string)value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((string)value);
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, (string)value);
		}

		void IList.Remove(object value)
		{
			Remove((string)value);
		}
	}
}
