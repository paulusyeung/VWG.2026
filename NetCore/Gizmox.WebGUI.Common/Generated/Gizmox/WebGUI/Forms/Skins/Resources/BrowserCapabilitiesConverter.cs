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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	public class BrowserCapabilitiesConverter : TypeConverter
	{
		public BrowserCapabilitiesConverter(Type objType)
		{
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (!(destinationType == typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return base.CanConvertTo(context, destinationType);
			}
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (!(sourceType == typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return base.CanConvertFrom(context, sourceType);
			}
			return true;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return ConvertFromString((string)value);
			}
			return base.ConvertFrom(context, culture, value);
		}

		protected new virtual object ConvertFromString(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string[] array = strValue.Split(',');
				if (array.Length != 6)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					int result = -1;
					int result2 = -1;
					int result3 = -1;
					int result4 = -1;
					int result5 = -1;
					int result6 = -1;
					if (!int.TryParse(array[0], out result))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!int.TryParse(array[1], out result2))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!int.TryParse(array[2], out result3))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (int.TryParse(array[3], out result4))
					{
						if (!int.TryParse(array[4], out result5))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (int.TryParse(array[5], out result6))
						{
							return new BrowserCapabilities((CSS3BrowserCapabilities)result, (HTML5BrowserCapabilities)result2, (MISCBrowserCapabilities)result3, (CSS3BrowserCapabilities)result4, (HTML5BrowserCapabilities)result5, (MISCBrowserCapabilities)result6);
						}
					}
				}
			}
			return null;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (!(destinationType == typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (value is BrowserCapabilities browserCapabilities)
			{
				return $"{Convert.ToInt32(browserCapabilities.RequiredBrowserCSS3Capabilities)},{Convert.ToInt32(browserCapabilities.RequiredBrowserHTML5Capabilities)},{Convert.ToInt32(browserCapabilities.RequiredBrowserMISCCapabilities)},{Convert.ToInt32(browserCapabilities.ForbiddenBrowserCSS3Capabilities)},{Convert.ToInt32(browserCapabilities.ForbiddenBrowserHTML5Capabilities)},{Convert.ToInt32(browserCapabilities.ForbiddenBrowserMISCCapabilities)}";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
