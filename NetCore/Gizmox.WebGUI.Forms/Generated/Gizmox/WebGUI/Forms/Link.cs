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
	/// The Link class provides services for opening links in a new window
	/// </summary>
	[Serializable]
	public class Link : ILink
	{
		/// 
		/// The current link url
		/// </summary>
		private string mstrUrl = string.Empty;

		/// 
		/// Gets the link url
		/// </summary>
		public string Url => mstrUrl;

		/// 
		/// Create a new link object
		/// </summary>
		/// <param name="strUrl"></param>
		internal Link(string strUrl)
		{
			mstrUrl = strUrl;
		}

		/// 
		/// Opens a new url
		/// </summary>
		/// <param name="strUrl">The url to open</param>
		public static void Open(string strUrl)
		{
			Global.Context.OpenLink(new Link(strUrl));
		}

		/// 
		/// Opens a new url with window parameters
		/// </summary>
		/// <param name="strUrl">The url to open</param>
		/// <param name="objLinkParameters">The link window paramters</param>
		public static void Open(string strUrl, LinkParameters objLinkParameters)
		{
			Global.Context.OpenLink(new Link(strUrl), objLinkParameters);
		}

		/// 
		/// Download a resource handle with content disposition to force browser save as.
		/// </summary>
		/// <param name="objResourceHandle">The resource handle to download its content.</param>
		/// 
		/// Only local server resource handles (such as ImageResourceHandle, GatewayResourceHandle) can be downloaded using the content disposition header and
		/// non local server resources (such as UrlResourceHandle) will be opened in a blank window.
		/// </remarks>
		public static void Download(ResourceHandle objResourceHandle)
		{
			string fileName = Path.GetFileName(objResourceHandle.File);
			Download(objResourceHandle, fileName);
		}

		/// 
		/// Download a resource handle with content disposition to force browser save as.
		/// </summary>
		/// <param name="objResourceHandle">The resource handle to download its content.</param>
		/// <param name="strFileName">The file name to give the downloaded file.</param>
		/// 
		/// Only local server resource handles (such as ImageResourceHandle, GatewayResourceHandle) can be downloaded using the content disposition header and
		/// non local server resources (such as UrlResourceHandle) will be opened in a blank window.
		/// </remarks> 
		public static void Download(ResourceHandle objResourceHandle, string strFileName)
		{
			LinkParameters linkParameters = new LinkParameters();
			if (objResourceHandle.IsServerResource)
			{
				linkParameters.QueryString["content-disposition"] = strFileName;
				linkParameters.Target = "_self";
			}
			else
			{
				linkParameters.Target = "_blank";
			}
			Open(objResourceHandle.ToString(), linkParameters);
		}

		/// 
		/// Opens a gateway link
		/// </summary>
		/// <param name="objGatewayReference">The gateway reference</param>
		public static void Open(GatewayReference objGatewayReference)
		{
			Open(objGatewayReference.ToString());
		}

		/// 
		/// Opens a gateway link with parameters
		/// </summary>
		/// <param name="objGatewayReference">The gateway reference</param>
		/// <param name="objLinkParameters">The link window paramters</param>
		public static void Open(GatewayReference objGatewayReference, LinkParameters objLinkParameters)
		{
			Open(objGatewayReference.ToString(), objLinkParameters);
		}

		/// 
		/// Opens a form reference link
		/// </summary>
		/// <param name="objFormReference">The form reference</param>
		public static void Open(FormReference objFormReference)
		{
			Open(objFormReference, new LinkParameters());
		}

		/// 
		/// Opens a form reference link with parameters
		/// </summary>
		/// <param name="objFormReference">The form reference</param>
		/// <param name="objLinkParameters">The link window paramters</param>
		public static void Open(FormReference objFormReference, LinkParameters objLinkParameters)
		{
			if (objLinkParameters == null)
			{
				objLinkParameters = new LinkParameters();
			}
			Global.Context.OpenLink(objFormReference, objLinkParameters);
		}
	}
}
