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
	/// Proxy ListView
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class ProxyListView : ProxyControl
	{
		/// 
		/// Gets or sets the components.
		/// </summary>
		/// 
		/// The components.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ProxySet Components => base.Components;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyListView" /> class. (this constructor will be initialized from Xaml desirialize)
		/// </summary>
		public ProxyListView()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyListView" /> class. (this constructor will be initialized whenever a listview will be dragged to Emulator Form)
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objParent">The obj parent.</param>
		/// <param name="blnStateComponent">if set to true</c> [BLN state component].</param>
		public ProxyListView(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
			: base(objComponent, objParent, blnStateComponent)
		{
			AddContainedComponents(objComponent);
			RegisterEvents(objComponent);
		}

		/// 
		/// Initializes the emulation - will occur whenever a proxy form is loaded from Xaml in recursion (from emulation form).
		/// </summary>
		internal override void InitializeProxy()
		{
			if (!base.ProxyInitialized)
			{
				Component sourceComponent = base.SourceComponent;
				if (sourceComponent != null)
				{
					AddContainedComponents(sourceComponent);
					RegisterEvents(sourceComponent);
				}
				SetProxyInitialized();
			}
		}

		/// 
		/// Registers the events.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		private void RegisterEvents(Component objComponent)
		{
			if (objComponent is ListView { Items: var items } listView)
			{
				items.ObservableItemAdded += Items_ObservableItemAdded;
				items.ObservableItemInserted += Items_ObservableItemAdded;
				items.ObservableItemRemoved += objItems_ObservableItemRemoved;
				items.ObservableListCleared += objItems_ObservableListCleared;
				ListView.ColumnHeaderCollection columns = listView.Columns;
				columns.ObservableItemAdded += objColumnHeaderCollection_ObservableItemAdded;
				columns.ObservableItemInserted += objColumnHeaderCollection_ObservableItemAdded;
				columns.ObservableItemRemoved += objColumnHeaderCollection_ObservableItemRemoved;
				columns.ObservableListCleared += objColumnHeaderCollection_ObservableListCleared;
				listView.Controls.ObservableItemAdded += Controls_ObservableItemAdded;
				listView.Controls.ObservableItemInserted += Controls_ObservableItemAdded;
				listView.Controls.ObservableItemRemoved += Controls_ObservableItemRemoved;
			}
		}

		/// 
		/// Handles the ObservableItemRemoved event of the Controls control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void Controls_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			if (objArgs.Item is Control objComponent)
			{
				RemoveSubComponent(objComponent);
			}
		}

		/// 
		/// Handles the ObservableItemAdded event of the Controls control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void Controls_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			if (objArgs.Item is Control objComponent)
			{
				AddSubComponent(objComponent);
			}
		}

		/// 
		/// Handles the ObservableListCleared event of the objColumnHeaderCollection control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objColumnHeaderCollection_ObservableListCleared(object sender, EventArgs e)
		{
			ClearProxyComponents(typeof(ColumnHeader));
		}

		/// 
		/// Handles the ObservableItemRemoved event of the objColumnHeaderCollection control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void objColumnHeaderCollection_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			if (objArgs.Item is ColumnHeader objComponent)
			{
				RemoveSubComponent(objComponent);
			}
		}

		/// 
		/// Handles the ObservableItemAdded event of the objColumnHeaderCollection control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void objColumnHeaderCollection_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			if (objArgs.Item is ColumnHeader objComponent)
			{
				AddSubComponent(objComponent);
			}
		}

		/// 
		/// Handles the ObservableListCleared event of the objItems control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objItems_ObservableListCleared(object sender, EventArgs e)
		{
			ClearProxyComponents(typeof(ListViewItem));
		}

		/// 
		/// Handles the ObservableItemRemoved event of the objItems control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void objItems_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			if (objArgs.Item is ListViewItem objComponent)
			{
				RemoveSubComponent(objComponent);
			}
		}

		/// 
		/// Handles the ObservableItemAdded event of the Items control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void Items_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			if (objArgs.Item is ListViewItem objComponent)
			{
				AddSubComponent(objComponent);
			}
		}

		/// 
		/// Clears the proxy components.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		private void ClearProxyComponents(Type objType)
		{
			GettingPropertyValueEventHandler gettingPropertyValueEventHandler = base.GettingPropertyValueEventHandler;
			ProxyComponent[] array = Components.ToArray();
			ProxyComponent[] array2 = array;
			foreach (ProxyComponent proxyComponent in array2)
			{
				if (proxyComponent.SourceComponent != null && proxyComponent.SourceComponent.GetType() == objType)
				{
					if (gettingPropertyValueEventHandler != null)
					{
						proxyComponent.GettingPropertyValue -= gettingPropertyValueEventHandler;
					}
					Components.Remove(proxyComponent);
				}
			}
		}

		/// 
		/// Adds the sub component.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		private void AddSubComponent(Component objComponent)
		{
			ProxyComponent proxyComponent = CreateProxyByComponent(objComponent);
			if (proxyComponent != null)
			{
				SubscribeGetEventsWithChildren(proxyComponent);
				Components.Add(proxyComponent);
			}
		}

		/// 
		/// Removes the sub component.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		private void RemoveSubComponent(Component objComponent)
		{
			ProxyComponent childProxyComponent = GetChildProxyComponent(objComponent);
			if (childProxyComponent != null)
			{
				UnsubscribeGetEventsWithChildren(childProxyComponent);
				Components.Remove(childProxyComponent);
			}
		}

		/// 
		/// Adds the contained components.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		private void AddContainedComponents(Component objComponent)
		{
			if (!(objComponent is ListView listView))
			{
				return;
			}
			foreach (ColumnHeader column in listView.Columns)
			{
				ProxyComponent proxyComponent = CreateProxyByComponent(column);
				if (proxyComponent != null)
				{
					Components.Add(proxyComponent);
				}
			}
			foreach (ListViewItem item in listView.Items)
			{
				ProxyComponent proxyComponent2 = CreateProxyByComponent(item);
				if (proxyComponent2 != null)
				{
					Components.Add(proxyComponent2);
				}
			}
			foreach (Control control in listView.Controls)
			{
				ProxyComponent proxyComponent3 = CreateProxyByComponent(control);
				if (proxyComponent3 != null)
				{
					Components.Add(proxyComponent3);
				}
			}
		}

		/// 
		/// Renders the specified obj context.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		public override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (ProxyComponent component in Components)
			{
				Component sourceComponent = component.SourceComponent;
				if (sourceComponent != null)
				{
					sourceComponent.ProxyComponent = component;
				}
			}
			base.Render(objContext, objWriter, lngRequestID);
			foreach (ProxyComponent component2 in Components)
			{
				Component sourceComponent2 = component2.SourceComponent;
				if (sourceComponent2 != null)
				{
					sourceComponent2.ProxyComponent = null;
				}
			}
		}
	}
}
