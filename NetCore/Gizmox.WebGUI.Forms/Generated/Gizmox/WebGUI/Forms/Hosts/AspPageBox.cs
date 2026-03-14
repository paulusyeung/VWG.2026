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
	/// Summary description for AspPageBox
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(AspPageBox), "AspPageBox_45.png")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemCategory("Host Controls")]
	[Skin(typeof(AspPageBoxSkin))]
	public class AspPageBox : FrameControl
	{
		/// 
		///
		/// </summary>
		private static SerializableProperty PathProperty = SerializableProperty.Register("Path", typeof(string), typeof(AspPageBox));

		/// 
		/// Gets the source.
		/// </summary>
		/// The source.</value>
		protected override string Source
		{
			get
			{
				if (IsValidPath(Path))
				{
					string baseUrl = CommonUtils.GetBaseUrl(VWGContext.Current.HostContext.Request);
					string text = new GatewayReference(this, "ASPXhost", SourceArguments).ToString();
					if (VWGContext.Current.HostContext.HttpContext.Session.IsCookieless)
					{
						text = VWGContext.Current.HostContext.HttpContext.Response.ApplyAppPathModifier(text);
					}
					return baseUrl + text;
				}
				return string.Empty;
			}
		}

		/// 
		/// Gets the source arguments.
		/// </summary>
		/// The source arguments.</value>
		private NameValueCollection SourceArguments
		{
			get
			{
				string pathQueryString = PathQueryString;
				if (!string.IsNullOrEmpty(pathQueryString))
				{
					NameValueCollection nameValueCollection = new NameValueCollection();
					string[] array = pathQueryString.Split('&');
					string[] array2 = array;
					foreach (string text in array2)
					{
						string[] array3 = text.Split('=');
						if (array3.Length == 2)
						{
							nameValueCollection[HttpUtility.UrlDecode(array3[0])] = HttpUtility.UrlDecode(array3[1]);
						}
					}
					return nameValueCollection;
				}
				return null;
			}
		}

		/// 
		/// Gets the path query string.
		/// </summary>
		/// The path query string.</value>
		private string PathQueryString
		{
			get
			{
				string path = Path;
				if (!string.IsNullOrEmpty(path))
				{
					string[] array = path.Split('?');
					if (array.Length > 1)
					{
						return array[1];
					}
				}
				return string.Empty;
			}
		}

		/// 
		/// Gets the path page.
		/// </summary>
		/// The path page.</value>
		private string PagePath
		{
			get
			{
				string path = Path;
				if (!string.IsNullOrEmpty(path))
				{
					path = path.Replace("\\", "/");
					if (!path.StartsWith("~/"))
					{
						path = $"~/{path}";
					}
					if (path.Contains("?"))
					{
						path = path.Split('?')[0];
					}
					return path;
				}
				return string.Empty;
			}
		}

		/// 
		/// The path of the asp page to be displayed
		/// </summary>
		[DefaultValue("")]
		public string Path
		{
			get
			{
				return GetValue(PathProperty);
			}
			set
			{
				if (Path != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(PathProperty);
					}
					else
					{
						SetValue(PathProperty, value);
					}
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPageBox" /> class.
		/// </summary>
		public AspPageBox()
		{
		}

		/// 
		/// Returns a flag indicating if path is valid
		/// </summary>
		/// <param name="strPath"></param>
		/// </returns>
		private bool IsValidPath(string strPath)
		{
			if (!string.IsNullOrEmpty(strPath) && strPath.Trim() != string.Empty)
			{
				return true;
			}
			return false;
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHttpContext">The gateway request HTTP context.</param>
		/// <param name="strAction">The gateway request action.</param>
		/// 
		/// By default this method returns a instance of a class which implements the IGatewayHandler and
		/// throws a non implemented HttpException.
		/// </returns>
		/// 
		/// This method is called from the implementation of IGatewayComponent which replaces the
		/// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
		/// RegisteredComponent class which is the base class of most of the Visual WebGui
		/// components.
		/// Referencing a RegisterComponent that overrides this method is done the same way that
		/// a control implementing IGatewayControl, which is by using the GatewayReference class.
		/// </remarks>
		protected override IGatewayHandler ProcessGatewayRequest(HttpContext objHttpContext, string strAction)
		{
			if (objHttpContext == null)
			{
				throw new HttpException("ASP.NET runtime is unavailable.");
			}
			string pagePath = PagePath;
			try
			{
				IHttpHandler httpHandler = (Page)PageParser.GetCompiledPageInstance(pagePath, objHttpContext.Server.MapPath(pagePath), objHttpContext);
				if (httpHandler != null)
				{
					if (httpHandler is AspPageBase aspPageBase)
					{
						aspPageBase.SetHost(this);
					}
					httpHandler.ProcessRequest(objHttpContext);
					return null;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return null;
		}
	}
}
