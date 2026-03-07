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
	public class ProxyTabPage : ProxyControl
	{
		/// 
		/// The mobj name
		/// </summary>
		private string mobjName;

		/// 
		/// Gets or sets the name of the component.
		/// </summary>
		public new string Name
		{
			get
			{
				string result = mobjName;
				if (string.IsNullOrEmpty(mobjName))
				{
					result = "TabPage";
				}
				return result;
			}
			set
			{
				mobjName = value;
			}
		}

		public override ProxyComponent Parent
		{
			get
			{
				return base.Parent;
			}
			set
			{
				if (value != null && !(value is ProxyTabControl))
				{
					throw new ArgumentException($"Cannot add component of type 'TabPage' to container of type '{value.GetType().Name}'");
				}
				base.Parent = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabPage" /> class.
		/// </summary>
		/// <param name="objComponent">The object component.</param>
		/// <param name="objParentProxy">The object parent proxy.</param>
		public ProxyTabPage(Component objComponent, ProxyComponent objParentProxy, bool blnStateComponent)
			: base(objComponent, objParentProxy, blnStateComponent)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabPage" /> class.
		/// </summary>
		public ProxyTabPage()
		{
		}

		/// 
		/// Returns wether proxy component is visible.
		/// </summary>
		protected override bool GetVisible()
		{
			if (Parent is ProxyTabControl proxyTabControl)
			{
				int num = proxyTabControl.TabPages.IndexOf(this);
				TabControl tabControl = proxyTabControl.SourceComponent as TabControl;
				if (tabControl.SelectedIndex != num)
				{
					return false;
				}
			}
			return base.GetVisible();
		}

		/// 
		/// Gets the proxy component property owner.
		/// </summary>
		/// <param name="objPropertyDescriptor"></param>
		/// </returns>
		protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
		{
			if (objPropertyDescriptor != null && objPropertyDescriptor.Name == "Name")
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
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this, arrAttributes, noCustomTypeDesc: true);
			PropertyDescriptor value = properties["Name"];
			proxyComponentProperties.Add(value);
			return proxyComponentProperties;
		}
	}
}
