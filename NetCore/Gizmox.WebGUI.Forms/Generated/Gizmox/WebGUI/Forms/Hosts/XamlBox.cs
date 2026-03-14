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

namespace Gizmox.WebGUI.Forms.Hosts
{
/// 
	/// A html control
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(XamlBox), "XamlBox_45.png")]
	[ToolboxItemCategory("Host Controls")]
	[Skin(typeof(XamlBoxSkin))]
	public class XamlBox : ObjectBox
	{
		/// 
		/// Xaml gateway handler
		/// </summary>
		[Serializable]
		public class XamlGateway : GatewayWriter
		{
			private XamlBox mobjXamlBox;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.XamlBox.XamlGateway" /> class.
			/// </summary>
			/// <param name="objXamlBox">The obj xaml box.</param>
			public XamlGateway(XamlBox objXamlBox)
			{
				mobjXamlBox = objXamlBox;
			}

			/// 
			/// Processes the request.
			/// </summary>
			protected override void ProcessRequest()
			{
				if (mobjXamlBox == null)
				{
					return;
				}
				if (mobjXamlBox.Type == XamlBoxType.XAML)
				{
					if (mobjXamlBox.Xaml != string.Empty)
					{
						Write(mobjXamlBox.Xaml);
					}
					else
					{
						Write("<Canvas xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" Height=\"500\" Width=\"500\"></Canvas>");
					}
				}
				else
				{
					WriteFile(mobjXamlBox.Path);
				}
				base.ContentType = "text/xml";
			}
		}

		private string mstrXaml = string.Empty;

		private string mstrUrl;

		private XamlBoxType menmType = XamlBoxType.XAML;

		private XamlGateway mobjGateway = null;

		private ResourceHandle mobjResourceHandle = null;

		/// 
		/// Gets or sets the Xaml code of the control.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public string Xaml
		{
			get
			{
				return (Type == XamlBoxType.XAML) ? mstrXaml : "";
			}
			set
			{
				menmType = XamlBoxType.XAML;
				mstrXaml = value;
				mstrUrl = "";
				FireObservableItemPropertyChanged("Content");
			}
		}

		/// 
		/// Gets or sets a flag indicating if the Xaml control should be windowless.
		/// </summary>
		[DefaultValue(true)]
		public bool Windowless
		{
			get
			{
				if (base.Parameters.Contains("windowless"))
				{
					return bool.Parse(base.Parameters["windowless"].ToString());
				}
				return false;
			}
			set
			{
				base.Parameters["windowless"] = value;
			}
		}

		/// 
		/// Gets or sets the URL to the Xaml code.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public string Url
		{
			get
			{
				if (base.Parameters.Contains("source"))
				{
					return base.Parameters["source"].ToString();
				}
				return string.Empty;
			}
			set
			{
				if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
				{
					string strUrl = (value.Contains("~/") ? value : ("~/" + value));
					base.Parameters["source"] = new UrlResourceHandle(strUrl).ToString();
				}
				else
				{
					base.Parameters["source"] = value;
				}
			}
		}

		/// 
		/// Gets or sets the path to the Xaml code.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public string Path
		{
			get
			{
				return (Type == XamlBoxType.UNC) ? mstrUrl : "";
			}
			set
			{
				menmType = XamlBoxType.UNC;
				mstrUrl = value;
				mstrXaml = "";
				FireObservableItemPropertyChanged("Content");
			}
		}

		/// 
		/// Gets or sets a resource that contains Xaml.
		/// </summary>
		/// </value>
		[DefaultValue(null)]
		public ResourceHandle Resource
		{
			get
			{
				return (Type == XamlBoxType.RESOURCE) ? mobjResourceHandle : null;
			}
			set
			{
				menmType = XamlBoxType.RESOURCE;
				mobjResourceHandle = value;
				mstrXaml = "";
				FireObservableItemPropertyChanged("Content");
			}
		}

		/// 
		/// Gets the html box type.
		/// </summary>
		/// </value>    
		public XamlBoxType Type => menmType;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.HtmlBox" /> instance.
		/// </summary>
		public XamlBox()
		{
			base.Size = new Size(200, 200);
			base.ObjectType = "application/x-silverlight-2";
			base.ObjectData = "data:application/x-silverlight-2,";
		}

		/// 
		/// Resets the resource.
		/// </summary>
		private void ResetResource()
		{
			Resource = null;
		}

		/// 
		/// Updates this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			FireObservableItemPropertyChanged("Content");
		}

		/// 
		/// Gets the gateway handler.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="strAction">The STR action.</param>
		/// </returns>
		public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
		{
			if (strAction == "Xaml")
			{
				return new XamlGateway(this);
			}
			return null;
		}
	}
}
