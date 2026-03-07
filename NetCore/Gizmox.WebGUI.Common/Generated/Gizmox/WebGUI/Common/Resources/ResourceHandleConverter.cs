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

namespace Gizmox.WebGUI.Common.Resources
{
	[Serializable]
	public class ResourceHandleConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			if (!(sourceType == typeof(Bitmap)))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (sourceType == typeof(Icon))
				{
					return true;
				}
				if (sourceType == typeof(Stream))
				{
					return true;
				}
				return base.CanConvertFrom(context, sourceType);
			}
			return true;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (!(destinationType == typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(destinationType == typeof(Image)))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(destinationType == typeof(Icon)))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(destinationType == typeof(Stream)))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (!(destinationType == typeof(InstanceDescriptor)))
							{
								/*OpCode not supported: LdMemberToken*/;
								return base.CanConvertTo(context, destinationType);
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return true;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (!(value is string))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (value is Bitmap)
				{
					return null;
				}
				if (!(value is Icon))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (value is Stream)
					{
						return null;
					}
					return base.ConvertFrom(context, culture, value);
				}
				return true;
			}
			string text = ((string)value).Trim();
			if (text.Length != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!text.StartsWith("Icons."))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!text.StartsWith("Images."))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!text.ToLower().StartsWith("http:"))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (text.ToLower().StartsWith("ftp:"))
							{
								return new UrlResourceHandle(text);
							}
							if (!text.ToLower().StartsWith("https:"))
							{
								/*OpCode not supported: LdMemberToken*/;
								return null;
							}
							return new UrlResourceHandle(text);
						}
						return new UrlResourceHandle(text);
					}
					return new ImageResourceHandle(text.Substring(7));
				}
				return new IconResourceHandle(text.Substring(6));
			}
			return null;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				MemberInfo memberInfo = null;
				object[] arguments = null;
				if (value == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(value is string))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (value is ResourceHandle)
					{
						memberInfo = typeof(ResourceHandle).GetMethod("FromString", new Type[1] { typeof(string) });
						arguments = new object[1] { ConvertToInvariantString(value) };
					}
				}
				else
				{
					memberInfo = typeof(ResourceHandle).GetMethod("FromString", new Type[1] { typeof(string) });
					arguments = new object[1] { value };
				}
				if (memberInfo != null)
				{
					return new InstanceDescriptor(memberInfo, arguments);
				}
			}
			else
			{
				if (!(destinationType == typeof(string)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (value == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(value is ResourceHandle))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (value is IconResourceHandle)
					{
						return "Icons." + ((ResourceHandle)value).File;
					}
					if (value is ImageResourceHandle)
					{
						return "Images." + ((ResourceHandle)value).File;
					}
					if (value is SkinResourceHandle)
					{
						return "Skins." + ((ResourceHandle)value).File;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				ResourceHandle resourceHandle = value as ResourceHandle;
				if (!(destinationType == typeof(Image)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (resourceHandle != null)
				{
					return resourceHandle.ToImage();
				}
				if (!(destinationType == typeof(Icon)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (resourceHandle != null)
					{
						return resourceHandle.ToIcon();
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!(destinationType == typeof(Stream)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (resourceHandle != null)
					{
						return resourceHandle.ToStream();
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
