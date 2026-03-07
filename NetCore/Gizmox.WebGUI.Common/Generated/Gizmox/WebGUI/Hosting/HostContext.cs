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
	[Serializable]
	public abstract class HostContext
	{
		private HostRequest mobjRequest;

		private HostResponse mobjResponse;

		private HostSessionState mobjSession;

		private HostServerUtility mobjServer;

		private HostCache mobjCache;

		private HostApplicationState mobjApplication;

		private IContext mobjVWGContext;

		[ThreadStatic]
		private static HostContext mobjNonHttpHostContextStore;

		public static HostContext Current
		{
			get
			{
				HostContext hostContext = null;
				HttpContext current = HttpContext.Current;
				if (current == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					hostContext = mobjNonHttpHostContextStore;
				}
				else
				{
					hostContext = Get(current);
					if (hostContext != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						hostContext = HttpHostContext.Create(current);
					}
				}
				return hostContext;
			}
			set
			{
				HttpContext current = HttpContext.Current;
				if (current == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					mobjNonHttpHostContextStore = value;
				}
				else
				{
					Set(current, value);
				}
			}
		}

		public HostApplicationState Application
		{
			get
			{
				if (mobjApplication != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjApplication = CreateApplication();
				}
				return mobjApplication;
			}
		}

		public abstract HttpContext HttpContext { get; }

		public HostCache Cache => HostRuntime.Cache;

		public abstract IDictionary Items { get; }

		public HostRequest Request
		{
			get
			{
				if (mobjRequest != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjRequest = CreateRequest();
				}
				return mobjRequest;
			}
		}

		public HostResponse Response
		{
			get
			{
				if (mobjResponse != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjResponse = CreateResponse();
				}
				return mobjResponse;
			}
		}

		public HostServerUtility Server
		{
			get
			{
				if (mobjServer == null)
				{
					mobjServer = CreateServer();
				}
				return mobjServer;
			}
		}

		public HostSessionState Session
		{
			get
			{
				if (mobjSession != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjSession = CreateSession();
				}
				return mobjSession;
			}
		}

		public abstract DateTime Timestamp { get; }

		public abstract bool IsCustomErrorEnabled { get; }

		public abstract IPrincipal User { get; set; }

		internal IContext VWGContext
		{
			get
			{
				if (mobjVWGContext == null)
				{
					mobjVWGContext = Items["__VWGContext"] as IContext;
				}
				return mobjVWGContext;
			}
			set
			{
				Items["__VWGContext"] = (mobjVWGContext = value);
			}
		}

		protected abstract HostApplicationState CreateApplication();

		internal static void Set(HttpContext objHttpContext, HostContext objHostContext)
		{
			if (objHttpContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objHttpContext.Items["__VWGHostContext"] = objHostContext;
			}
		}

		protected abstract HostRequest CreateRequest();

		protected abstract HostResponse CreateResponse();

		protected abstract HostServerUtility CreateServer();

		protected abstract HostSessionState CreateSession();

		internal static HostContext Get(HttpContext objHttpContext)
		{
			if (objHttpContext != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return objHttpContext.Items["__VWGHostContext"] as HostContext;
			}
			throw new ArgumentNullException("objHttpContext");
		}
	}
}
