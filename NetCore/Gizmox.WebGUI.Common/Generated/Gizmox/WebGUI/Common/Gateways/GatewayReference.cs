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

namespace Gizmox.WebGUI.Common.Gateways
{
	[Serializable]
	public class GatewayReference
	{
		private IRegisteredComponent mobjComponent;

		private GatewayHandler mobjHandler;

		private string mstrAction;

		private static string mstrDynamicExtension;

		private bool mblnCachable;

		private NameValueCollection mobjArguments;

		public string Action => mstrAction;

		public IRegisteredComponent Component => mobjComponent;

		public bool Chachable => mblnCachable;

		public GatewayHandler Handler => mobjHandler;

		public NameValueCollection Arguments
		{
			get
			{
				return mobjArguments;
			}
			set
			{
				mobjArguments = value;
			}
		}

		internal virtual string ReferencePrefix => "Component";

		[Obsolete("Use alternative constructors.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GatewayReference(IRegisteredComponent objComponent, GatewayHandler objHandler, string strAction)
		{
			mobjComponent = objComponent;
			mstrAction = strAction;
			mobjHandler = objHandler;
		}

		public GatewayReference(IRegisteredComponent objComponent, string strAction, bool blnCachable)
		{
			mobjComponent = objComponent;
			mstrAction = strAction;
			mobjHandler = null;
			mblnCachable = blnCachable;
		}

		public GatewayReference(IRegisteredComponent objComponent, string strAction, NameValueCollection objArguments, bool blnCachable)
		{
			mobjComponent = objComponent;
			mstrAction = strAction;
			mobjHandler = null;
			mblnCachable = blnCachable;
			mobjArguments = objArguments;
		}

		public GatewayReference(IRegisteredComponent objComponent, string strAction)
			: this(objComponent, strAction, blnCachable: false)
		{
		}

		public GatewayReference(IRegisteredComponent objComponent, string strAction, NameValueCollection objArguments)
			: this(objComponent, strAction, objArguments, blnCachable: false)
		{
		}

		static GatewayReference()
		{
			mstrDynamicExtension = ".wgx";
			Config instance = Config.GetInstance();
			if (instance != null)
			{
				mstrDynamicExtension = instance.DynamicExtension;
			}
		}

		private string GetGatewayQueryString()
		{
			if (mobjArguments == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjArguments.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					string[] allKeys = mobjArguments.AllKeys;
					foreach (string text in allKeys)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("&");
						}
						stringBuilder.AppendFormat("{0}={1}", HttpUtility.UrlEncode(text), HttpUtility.UrlEncode(mobjArguments[text]));
					}
					return stringBuilder.ToString();
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return string.Empty;
		}

		public override string ToString()
		{
			IContext context = null;
			string text = GetGatewayQueryString();
			if ((context = VWGContext.Current) == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (context.Request is IRequestParams requestParams)
				{
					if (mblnCachable)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!(text != string.Empty))
					{
						/*OpCode not supported: LdMemberToken*/;
						text = $"?requestid={requestParams.LastRender}";
					}
					else
					{
						text = $"?requestid={requestParams.LastRender}&{text}";
					}
					return $"{ReferencePrefix}.{requestParams.Page}.{requestParams.PageInstance}.{mobjComponent.ID.ToString()}.{mstrAction}{mstrDynamicExtension}{NormalizeQueryString(text)}";
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return $"{ReferencePrefix}.{mobjComponent.ID.ToString()}.{mstrAction}{mstrDynamicExtension}{NormalizeQueryString(text)}";
		}

		private object NormalizeQueryString(string strQueryString)
		{
			if (string.IsNullOrEmpty(strQueryString))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (strQueryString.StartsWith("?"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				strQueryString = $"?{strQueryString}";
			}
			return strQueryString;
		}
	}
}
