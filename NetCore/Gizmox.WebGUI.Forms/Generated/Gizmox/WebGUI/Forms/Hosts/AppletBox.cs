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
	/// Applet box control can host java applets and embed the in a Visual WebGui
	/// application
	/// </summary>
	/// 
	/// 	<code lang="CS">
	/// 		<![CDATA[
	/// AppletBox objAppletBox = new AppletBox();
	///
	/// objAppletBox.CodeBase = [URL Relative location]
	/// objAppletBox.Code = [Class filename]
	///
	/// //If your class file is located in Resources folder inside project and it's a dedicated server:
	///
	/// objAppletBox.CodeBase = "/Resources/";
	/// objAppletBox.Code = "MyClass.class";
	///
	/// //If your class files located in virtual directory inside server:
	///
	/// objAppletBox.CodeBase = "Resources/";
	/// objAppletBox.Code = "MyClass.class";]]>
	/// 	</code>
	/// 	<code lang="VB">
	/// 		<![CDATA[
	/// Dim objAppletBox As New AppletBox()
	///
	/// objAppletBox.CodeBase = [URL Relative location]
	/// objAppletBox.Code = [Class filename]
	///
	/// //If your Class file Is located In Resources folder inside project And it's a dedicated server:
	///
	/// objAppletBox.CodeBase = "/Resources/"
	/// objAppletBox.Code = "MyClass.class"
	///
	/// //If your Class files located In virtual directory inside server:
	///
	/// objAppletBox.CodeBase = "Resources/"
	/// objAppletBox.Code = "MyClass.class"]]>
	/// 	</code>
	/// </example>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(AppletBox), "AppletBox_45.png")]
	public class AppletBox : AppletBoxBase, IGatewayComponent
	{
		/// 
		/// Gets or sets the archive.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		public string Archive
		{
			get
			{
				return base.InternalArchive;
			}
			set
			{
				base.InternalArchive = value;
			}
		}

		/// 
		/// Gets or sets the code base.
		/// </summary>
		/// The code base.</value>
		[DefaultValue("")]
		public string CodeBase
		{
			get
			{
				return base.ObjectCodeBase;
			}
			set
			{
				base.ObjectCodeBase = value;
			}
		}

		/// 
		/// Gets or sets the code base.
		/// </summary>
		/// The code base.</value>
		[DefaultValue("")]
		public string Code
		{
			get
			{
				return base.ObjectCode;
			}
			set
			{
				base.ObjectCode = value;
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.AppletBox" /> instance.
		/// </summary>
		public AppletBox()
			: this(null, null)
		{
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Hosts.AppletBox" /> instance.
		/// </summary>
		/// <param name="strCodeBase">Applet code base.</param>
		/// <param name="strArchive">Applet archive.</param>
		/// <param name="strCode">Applet code.</param>
		public AppletBox(string strArchive, string strCode)
			: base(strArchive, strCode)
		{
			base.ObjectType = "application/x-java-applet";
		}
	}
}
