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

namespace Gizmox.WebGUI.Hosting
{
	public class HostException : Exception
	{
		private HostExceptionFormatter A;

		private int B;

		private const int C = 7;

		private HostExceptionFormatter ExceptionFormatter
		{
			get
			{
				if (A != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					A = CreateHostExceptionFormatter();
				}
				return A;
			}
		}

		public HostException()
		{
		}

		public HostException(string message)
			: base(message)
		{
		}

		public HostException(int httpCode, string message)
			: base(message)
		{
			B = httpCode;
		}

		public HostException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public HostException(string message, int hr)
			: base(message)
		{
			base.HResult = hr;
		}

		public HostException(int httpCode, string message, Exception innerException)
			: base(message, innerException)
		{
			B = httpCode;
		}

		public HostException(int httpCode, string message, int hr)
			: base(message)
		{
			base.HResult = hr;
			B = httpCode;
		}

		public static HostException CreateFromLastError(string message)
		{
			return new HostException(message, HResultFromLastError(Marshal.GetLastWin32Error()));
		}

		internal static HostExceptionFormatter GetExceptionFormatter(Exception objException)
		{
			Exception innerException = objException.InnerException;
			if (innerException != null)
			{
				HostExceptionFormatter exceptionFormatter = GetExceptionFormatter(innerException);
				if (exceptionFormatter != null)
				{
					return exceptionFormatter;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(objException is HostException ex))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return ex.ExceptionFormatter;
		}

		protected virtual HostExceptionFormatter CreateHostExceptionFormatter()
		{
			return new I(this);
		}

		public string GetHtmlErrorMessage()
		{
			HostExceptionFormatter exceptionFormatter = GetExceptionFormatter(this);
			if (exceptionFormatter != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return exceptionFormatter.GetHtmlErrorMessage();
			}
			return null;
		}

		public int GetHttpCode()
		{
			return GetHttpCodeForException(this);
		}

		internal static int GetHttpCodeForException(Exception e)
		{
			if (!(e is HostException))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (e is UnauthorizedAccessException)
				{
					return 401;
				}
				/*OpCode not supported: LdMemberToken*/;
				if (e is PathTooLongException)
				{
					return 414;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				HostException ex = (HostException)e;
				if (ex.B > 0)
				{
					return ex.B;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (e.InnerException != null)
			{
				return GetHttpCodeForException(e.InnerException);
			}
			return 500;
		}

		internal static int HResultFromLastError(int lastError)
		{
			if (lastError < 0)
			{
				return lastError;
			}
			return (lastError & 0xFFFF) | 0x70000 | int.MinValue;
		}
	}
}
