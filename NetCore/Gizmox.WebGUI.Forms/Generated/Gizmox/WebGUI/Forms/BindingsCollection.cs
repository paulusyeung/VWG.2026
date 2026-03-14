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
/// Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects for a control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[DefaultEvent("CollectionChanged")]
	public class BindingsCollection : BaseCollection
	{
		private ArrayList mobjList;

		/// Gets the total number of bindings in the collection.</summary>
		/// The total number of bindings in the collection.</returns>
		/// 1</filterpriority>
		public override int Count
		{
			get
			{
				if (mobjList == null)
				{
					return 0;
				}
				return base.Count;
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.</returns>
		/// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to find. </param>
		/// <exception cref="T:System.IndexOutOfRangeException">The collection doesn't contain an item at the specified index. </exception>
		/// 1</filterpriority>
		public Binding this[int index] => (Binding)List[index];

		/// Gets the bindings in the collection as an object.</summary>
		/// An <see cref="T:System.Collections.ArrayList"></see> containing all of the collection members.</returns>
		protected override ArrayList List
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

		/// Occurs when the collection has changed.</summary>
		/// 1</filterpriority>
		[SRDescription("collectionChangedEventDescr")]
		public event CollectionChangeEventHandler CollectionChanged;

		/// Occurs when the collection is about to change.</summary>
		/// 1</filterpriority>
		[SRDescription("collectionChangingEventDescr")]
		public event CollectionChangeEventHandler CollectionChanging;

		internal BindingsCollection()
		{
		}

		/// Adds the specified binding to the collection.</summary>
		/// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add to the collection. </param>
		protected internal void Add(Binding objBinding)
		{
			CollectionChangeEventArgs e = new CollectionChangeEventArgs(CollectionChangeAction.Add, objBinding);
			OnCollectionChanging(e);
			AddCore(objBinding);
			OnCollectionChanged(e);
		}

		/// Adds a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to the collection.</summary>
		/// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add to the collection.</param>
		/// <exception cref="T:System.ArgumentNullException">The dataBinding argument was null. </exception>
		protected virtual void AddCore(Binding objDataBinding)
		{
			if (objDataBinding == null)
			{
				throw new ArgumentNullException("dataBinding");
			}
			List.Add(objDataBinding);
		}

		/// Clears the collection of binding objects.</summary>
		protected internal void Clear()
		{
			CollectionChangeEventArgs e = new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null);
			OnCollectionChanging(e);
			ClearCore();
			OnCollectionChanged(e);
		}

		/// Clears the collection of any members.</summary>
		protected virtual void ClearCore()
		{
			List.Clear();
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingsCollection.CollectionChanged"></see> event.</summary>
		/// <param name="objCcevent">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
		protected virtual void OnCollectionChanged(CollectionChangeEventArgs objCcevent)
		{
			this.CollectionChanged?.Invoke(this, objCcevent);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingsCollection.CollectionChanging"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains event data.</param>
		protected virtual void OnCollectionChanging(CollectionChangeEventArgs e)
		{
			this.CollectionChanging?.Invoke(this, e);
		}

		/// Deletes the specified binding from the collection.</summary>
		/// <param name="objBinding">The Binding to remove from the collection. </param>
		protected internal void Remove(Binding objBinding)
		{
			CollectionChangeEventArgs e = new CollectionChangeEventArgs(CollectionChangeAction.Remove, objBinding);
			OnCollectionChanging(e);
			RemoveCore(objBinding);
			OnCollectionChanged(e);
		}

		/// Deletes the binding from the collection at the specified index.</summary>
		/// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove. </param>
		protected internal void RemoveAt(int index)
		{
			Remove(this[index]);
		}

		/// Removes the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> from the collection.</summary>
		/// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove. </param>
		protected virtual void RemoveCore(Binding objDataBinding)
		{
			List.Remove(objDataBinding);
		}

		/// Gets a value that indicates whether the collection should be serialized.</summary>
		/// true if the collection count is greater than zero; otherwise, false.</returns>
		protected internal bool ShouldSerializeMyAll()
		{
			return Count > 0;
		}
	}
}
