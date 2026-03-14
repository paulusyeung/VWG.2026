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
[Serializable]
	[ToolboxItem(false)]
	public class ProxyMasterPage : ProxyControl, IProxyMasterPage
	{
		private string mstrName;

		private string mstrMasterPageId;

		private IEmulatorForm mobjEmulatorForm;

		internal IEmulatorForm EmulatorForm
		{
			get
			{
				if (mobjEmulatorForm == null)
				{
					if (!(Context is IContextParams contextParams))
					{
						return null;
					}
					mobjEmulatorForm = contextParams.EmulatorForm;
				}
				return mobjEmulatorForm;
			}
		}

		/// 
		/// Gets or sets the id of the master page.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(false)]
		public string MasterPageId
		{
			get
			{
				if (mstrMasterPageId == null)
				{
					mstrMasterPageId = Guid.NewGuid().ToString();
				}
				return mstrMasterPageId;
			}
			set
			{
				mstrMasterPageId = value;
			}
		}

		/// 
		/// Gets or sets the name of the master page.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public override string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyMasterPage" /> class.
		/// </summary>
		public ProxyMasterPage()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyMasterPage" /> class.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		public ProxyMasterPage(Component objComponent)
			: base(objComponent, null, blnStateComponent: false)
		{
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			base.SourceComponent.Update();
		}

		/// 
		/// Gets the proxy component properties.
		/// </summary>
		/// <param name="arrAttributes">The arr attributes.</param>
		/// </returns>
		protected override PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
		{
			PropertyDescriptorCollection proxyComponentProperties = base.GetProxyComponentProperties(arrAttributes);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, arrAttributes, noCustomTypeDesc: true);
			foreach (PropertyDescriptor item in properties)
			{
				if (IsProxyProperty(item))
				{
					proxyComponentProperties.Add(item);
				}
			}
			return proxyComponentProperties;
		}

		/// 
		/// Determines whether [is proxy property] [the specified obj property descriptor].
		/// </summary>
		/// <param name="objPropertyDescriptor">The obj property descriptor.</param>
		/// 
		///   true</c> if [is proxy property] [the specified obj property descriptor]; otherwise, false</c>.
		/// </returns>
		private bool IsProxyProperty(PropertyDescriptor objPropertyDescriptor)
		{
			if (objPropertyDescriptor != null)
			{
				string name = objPropertyDescriptor.Name;
				if (name == "Name")
				{
					return true;
				}
			}
			return false;
		}

		/// 
		/// Gets the proxy component property owner.
		/// </summary>
		/// <param name="objPropertyDescriptor"></param>
		/// </returns>
		protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			if (IsProxyProperty(objPropertyDescriptor))
			{
				return this;
			}
			return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
		}

		void IProxyMasterPage.Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			Render(objContext, objWriter, lngRequestID);
		}

		void IProxyMasterPage.PreRender(IContext objContext, long lngRequestID)
		{
			PreRender(objContext, lngRequestID);
		}

		void IProxyMasterPage.PostRender(IContext objContext, long lngRequestID)
		{
			PostRender(objContext, lngRequestID);
		}
	}
}
