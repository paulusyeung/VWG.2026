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
	public class ValueResource<T> : SkinResource, PB
	{
		internal T mobjValue;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public object Value
		{
			get
			{
				return mobjValue;
			}
			set
			{
				mobjValue = GetTypedValue(value);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Presentation Presentation
		{
			get
			{
				return Presentation.Agnostic;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override string Comment
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override BrowserCapabilities BrowserCapabilities
		{
			get
			{
				return BrowserCapabilities.Empty;
			}
			set
			{
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override PresentationRole PresentationRole
		{
			get
			{
				return PresentationRole.Custom;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override PresentationEngine PresentationEngine
		{
			get
			{
				return PresentationEngine.Agnostic;
			}
			set
			{
			}
		}

		public ValueResource()
		{
		}

		public ValueResource(object objValue)
		{
			mobjValue = GetTypedValue(objValue);
		}

		internal override VT GetValue<VT>(VT objDefaultValue)
		{
			object obj = mobjValue;
			if (obj != null)
			{
				if (typeof(VT).IsAssignableFrom(obj.GetType()))
				{
					return (VT)obj;
				}
				return (VT)ConvertTo(typeof(VT));
			}
			return objDefaultValue;
		}

		private T GetTypedValue(object objValue)
		{
			if (objValue == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return default(T);
			}
			if (objValue is T)
			{
				return (T)objValue;
			}
			return ConvertToTypeValue(objValue);
		}

		private T ConvertToTypeValue(object objValue)
		{
			if (objValue == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (typeof(T).IsAssignableFrom(objValue.GetType()))
				{
					return (T)objValue;
				}
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				if (converter == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (converter.CanConvertFrom(objValue.GetType()))
				{
					return (T)converter.ConvertFrom(null, CultureInfo.InvariantCulture, objValue);
				}
			}
			return default(T);
		}

		public object ConvertTo(Type objDestinationType)
		{
			try
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				if (converter == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (converter.CanConvertTo(objDestinationType))
				{
					_ = SkinFactory.TraceMode;
					return converter.ConvertTo(mobjValue, objDestinationType);
				}
				TypeConverter converter2 = TypeDescriptor.GetConverter(objDestinationType);
				if (converter2 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new SkinException(GetConvertExceptionMessage(objDestinationType));
				}
				_ = SkinFactory.TraceMode;
				return converter2.ConvertFrom(null, CultureInfo.InvariantCulture, mobjValue);
			}
			catch (Exception objInnerException)
			{
				throw new SkinException(GetConvertExceptionMessage(objDestinationType), objInnerException);
			}
		}

		private static string GetConvertExceptionMessage(Type objDestinationType)
		{
			return $"The following type '{typeof(T).FullName}' cannot be converted to '{objDestinationType.FullName}'.";
		}

		private static string GetConvertTraceMessage(Type objDestinationType)
		{
			return $"The following type '{typeof(T).FullName}' was converted to '{objDestinationType.FullName}'.";
		}
	}
}
