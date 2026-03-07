#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
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
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Common.Device
{
	public class DeviceIntegrationInfo
	{
		private int A;

		private int B;

		private int C;

		private string D;

		private bool E;

		private int F;

		public int GeolocationMaximumAge => F;

		public int AccelerationFrequency => A;

		public int CompassFrequency => B;

		public int MediaPositionFrequency => C;

		public string GeolocationTimeout => D;

		public bool GeolocationEnableHighAccuracy => E;

		public DeviceIntegrationInfo(XmlNode objNode)
		{
			A = GetAccelerationFrequency(objNode) ?? 10000;
			B = GetCompassFrequency(objNode) ?? 100;
			int? mediaPositionFrequency = GetMediaPositionFrequency(objNode);
			int c;
			if (mediaPositionFrequency.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
				c = mediaPositionFrequency.GetValueOrDefault();
			}
			else
			{
				c = 1000;
			}
			C = c;
			object obj = GetGeolocationTimeout(objNode);
			if (obj != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				obj = "Infinity";
			}
			D = (string)obj;
			E = GetGeolocationEnableHighAccuracy(objNode) ?? false;
			mediaPositionFrequency = GetGeolocationMaximumAge(objNode);
			int f;
			if (mediaPositionFrequency.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
				f = mediaPositionFrequency.GetValueOrDefault();
			}
			else
			{
				f = 0;
			}
			F = f;
		}

		private int? GetGeolocationMaximumAge(XmlNode objNode)
		{
			return GetDeviceComponentOption<int>("Geolocation", "MaximumAge", objNode);
		}

		private T? GetDeviceComponentOption<T>(string strComponent, string strOption, XmlNode objNode) where T : struct
		{
			if (objNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objNode[strComponent] == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objNode[strComponent].Attributes[strOption] == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (objNode[strComponent].Attributes[strOption].Value != null)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
					try
					{
						return (T)converter.ConvertFromString(objNode[strComponent].Attributes[strOption].Value);
					}
					catch
					{
						return null;
					}
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		private bool? GetGeolocationEnableHighAccuracy(XmlNode objNode)
		{
			return GetDeviceComponentOption<bool>("Geolocation", "EnableHighAccuracy", objNode);
		}

		private int? GetCompassFrequency(XmlNode objNode)
		{
			return GetDeviceComponentOption<int>("Compass", "Frequency", objNode);
		}

		private int? GetMediaPositionFrequency(XmlNode objNode)
		{
			return GetDeviceComponentOption<int>("Media", "PositionFrequency", objNode);
		}

		private string GetGeolocationTimeout(XmlNode objNode)
		{
			if (objNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objNode["Geolocation"] == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objNode["Geolocation"].Attributes["Timeout"] == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (objNode["Geolocation"].Attributes["Timeout"].Value != null)
				{
					return objNode["Geolocation"].Attributes["Timeout"].Value;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		private int? GetAccelerationFrequency(XmlNode objNode)
		{
			return GetDeviceComponentOption<int>("Accelerometer", "Frequency", objNode);
		}
	}
}
