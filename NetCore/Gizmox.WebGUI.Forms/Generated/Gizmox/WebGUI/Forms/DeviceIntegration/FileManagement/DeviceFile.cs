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

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
[Serializable]
	public class DeviceFile : DevicePropertyDictionary, IDeviceFile
	{
		/// 
		/// Gets the full path.
		/// </summary>
		public string FullPath
		{
			get
			{
				return GetNullableProperty<string>("fullPath");
			}
			internal set
			{
				SetNullableProperty("fullPath", value);
			}
		}

		/// 
		/// Gets the last modified date.
		/// </summary>
		public DateTime LastModifiedDate
		{
			get
			{
				long valuetypePropertyOrDefault = GetValuetypePropertyOrDefault<long>("lastModifiedDate");
				if (valuetypePropertyOrDefault != 0)
				{
					return new DateTime(valuetypePropertyOrDefault * 10000 + 621355968000000000L);
				}
				return DateTime.MinValue;
			}
			internal set
			{
				AddValueTypeProperty("lastModifiedDate", value);
			}
		}

		/// 
		/// Gets the name.
		/// </summary>
		public string Name
		{
			get
			{
				return GetNullableProperty<string>("name");
			}
			internal set
			{
				SetNullableProperty("name", value);
			}
		}

		/// 
		/// Gets the size.
		/// </summary>
		public ulong Size
		{
			get
			{
				return GetValuetypePropertyOrDefault<ulong>("size");
			}
			internal set
			{
				AddValueTypeProperty("size", value);
			}
		}

		/// 
		/// Gets the full path.
		/// </summary>
		public string Type
		{
			get
			{
				return GetNullableProperty<string>("type");
			}
			internal set
			{
				SetNullableProperty("type", value);
			}
		}

		public static DeviceFile FromVWGEvent(IEvent objEvent)
		{
			DeviceFile deviceFile = new DeviceFile();
			deviceFile.FullPath = objEvent["fullPath"];
			if (long.TryParse(objEvent["lastModifiedDate"], out var result))
			{
				deviceFile.AddValueTypeProperty("lastModifiedDate", result);
			}
			deviceFile.Name = objEvent["name"];
			if (ulong.TryParse(objEvent["size"], out var result2))
			{
				deviceFile.Size = result2;
			}
			deviceFile.Type = objEvent["type"];
			return deviceFile;
		}
	}
}
