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
	/// Proxy TabControl
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class ProxyTabControl : ProxyControl, IProxyNavigationControl, INavigationControl
	{
		/// 
		/// The object proxy tab pages
		/// </summary>
		[NonSerialized]
		private ProxyTabPageCollection objProxyTabPages;

		/// 
		/// The count change event handler
		/// </summary>
		private EventHandler mobjCountChangeEventHandler = null;

		/// 
		/// For EMS editing purposes
		/// </summary>
		/// 
		/// The tab pages.
		/// </value>
		[WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ProxyTabPageCollection TabPages
		{
			get
			{
				if (objProxyTabPages == null)
				{
					objProxyTabPages = new ProxyTabPageCollection(this);
				}
				return objProxyTabPages;
			}
		}

		private INavigationControl TabControl => base.SourceComponent as INavigationControl;

		int INavigationControl.Count => TabControl.Count;

		int INavigationControl.SelectedIndex => TabControl.SelectedIndex;

		/// 
		/// Occurs when count change.
		/// </summary>
		event EventHandler IProxyNavigationControl.CountChange
		{
			add
			{
				RegisterCollectionChange(blnRegister: true);
				mobjCountChangeEventHandler = (EventHandler)Delegate.Combine(mobjCountChangeEventHandler, value);
			}
			remove
			{
				mobjCountChangeEventHandler = (EventHandler)Delegate.Remove(mobjCountChangeEventHandler, value);
				RegisterCollectionChange(blnRegister: false);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabControl" /> class.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objParent">The obj parent.</param>
		/// <param name="blnStateComponent">if set to true</c> [BLN state component].</param>
		public ProxyTabControl(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
			: base(objComponent, objParent, blnStateComponent)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabControl" /> class.
		/// </summary>
		public ProxyTabControl()
		{
		}

		/// 
		/// Raises the <see cref="E:SourceComponentFireEvent" /> event.
		/// </summary>
		/// <param name="objFireEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyFireEventArgs" /> instance containing the event data.</param>
		internal override void OnSourceComponentFireEvent(ProxyFireEventArgs objFireEventArgs)
		{
			base.OnSourceComponentFireEvent(objFireEventArgs);
			if (objFireEventArgs.Event.Type == "ValueChange")
			{
				objFireEventArgs.AllowEvent = true;
			}
		}

		/// 
		/// Gets the proxy component property owner.
		/// </summary>
		/// <param name="objPropertyDescriptor"></param>
		/// </returns>
		protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			if (objPropertyDescriptor != null && objPropertyDescriptor.Name == "TabPages")
			{
				return this;
			}
			return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
		}

		/// 
		/// Gets the proxy component properties.
		/// </summary>
		/// <param name="arrAttributes">The arr attributes.</param>
		/// </returns>
		protected override PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
		{
			PropertyDescriptorCollection proxyComponentProperties = base.GetProxyComponentProperties(arrAttributes);
			if (!base.IsStateComponent)
			{
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, arrAttributes, noCustomTypeDesc: true);
				PropertyDescriptor value = properties["TabPages"];
				proxyComponentProperties.Add(value);
			}
			return proxyComponentProperties;
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

		/// 
		/// Happens after the load of the component from XAML.
		/// </summary>
		public override void OnLoad()
		{
			base.OnLoad();
			if (base.IsStateComponent)
			{
				return;
			}
			if (base.SourceComponent is TabControl tabControl)
			{
				{
					foreach (ProxyComponent component in Components)
					{
						if (component.SourceComponent is TabPage tabPage && !tabControl.TabPages.Contains(tabPage))
						{
							tabControl.TabPages.Add(tabPage);
						}
					}
					return;
				}
			}
			throw new NullReferenceException(string.Format("this.SourceComponent is null or not a TabControl. Type is {0}", (base.SourceComponent == null) ? "null" : base.SourceComponent.GetType().Name));
		}

		/// 
		/// Gets the proxy property value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// <param name="objDefaultValue">The obj default value.</param>
		/// </returns>
		public override T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
		{
			if (strPropertyName == "TabPages")
			{
				List<object> list = new List<object><object>();
				foreach (ProxyTabPage item2 in (IEnumerable)TabPages)
				{
					if (item2.SourceComponent is TabPage item)
					{
						list.Add(item);
					}
				}
				object obj = list;
				return (T)obj;
			}
			return base.GetProxyPropertyValue(strPropertyName, objDefaultValue);
		}

		ProxyControl IProxyNavigationControl.AddNew()
		{
			ProxyTabPage proxyTabPage = new ProxyTabPage();
			TabPages.Add(proxyTabPage);
			return proxyTabPage;
		}

		void IProxyNavigationControl.RemoveCurrent()
		{
			TabPages.RemoveAt(TabControl.SelectedIndex);
		}

		/// 
		/// Registers the collection change.
		/// </summary>
		/// <param name="blnRegister">if set to true</c> [BLN register].</param>
		private void RegisterCollectionChange(bool blnRegister)
		{
			if (blnRegister)
			{
				if (mobjCountChangeEventHandler == null && base.SourceComponent is TabControl { Controls: { } controls })
				{
					controls.ObservableItemAdded += Controls_ObservableItemAdded;
					controls.ObservableItemInserted += Controls_ObservableItemInserted;
					controls.ObservableItemRemoved += Controls_ObservableItemRemoved;
					controls.ObservableListCleared += Controls_ObservableListCleared;
				}
			}
			else if (mobjCountChangeEventHandler == null && base.SourceComponent is TabControl { Controls: { } controls2 })
			{
				controls2.ObservableItemAdded -= Controls_ObservableItemAdded;
				controls2.ObservableItemInserted -= Controls_ObservableItemInserted;
				controls2.ObservableItemRemoved -= Controls_ObservableItemRemoved;
				controls2.ObservableListCleared -= Controls_ObservableListCleared;
			}
		}

		/// 
		/// Handles the ObservableListCleared event of the Controls control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void Controls_ObservableListCleared(object sender, EventArgs e)
		{
			OnCountChange(new EventArgs());
		}

		/// 
		/// Handles the ObservableItemRemoved event of the Controls control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void Controls_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			OnCountChange(new EventArgs());
		}

		/// 
		/// Handles the ObservableItemInserted event of the Controls control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void Controls_ObservableItemInserted(object objSender, ObservableListEventArgs objArgs)
		{
			OnCountChange(new EventArgs());
		}

		/// 
		/// Handles the ObservableItemAdded event of the Controls control.
		/// </summary>
		/// <param name="objSender">The source of the event.</param>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
		private void Controls_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			OnCountChange(new EventArgs());
		}

		/// 
		/// Raises the <see cref="E:CountChange" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnCountChange(EventArgs e)
		{
			if (mobjCountChangeEventHandler != null)
			{
				mobjCountChangeEventHandler(this, e);
			}
		}

		bool INavigationControl.MoveFirst()
		{
			return TabControl.MoveFirst();
		}

		bool INavigationControl.MoveLast()
		{
			return TabControl.MoveLast();
		}

		bool INavigationControl.MoveNext()
		{
			return TabControl.MoveNext();
		}

		bool INavigationControl.MovePrevious()
		{
			return TabControl.MovePrevious();
		}

		void INavigationControl.MoveTo(int intIndex)
		{
			TabControl.MoveTo(intIndex);
		}
	}
}
