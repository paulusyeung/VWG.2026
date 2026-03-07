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
	public abstract class HostRequestInfo
	{
		private enum J
		{
			A,
			B,
			C
		}

		internal const string RouteDirectory = "Route/";

		private string mstrPageName;

		private string mstrPageResource;

		private RequestType menmPageType;

		private string mstrPageInstance;

		private string mstrWebSocketConnectionId;

		private string mstrThemeDirectory;

		private ReadOnlyCollection<string> marrAvailableThemes = new ReadOnlyCollection<string>(new List<string>());

		private string mstrCultureDirectory;

		private string mstrBrowserDirectory;

		private bool mblnIsUserPostbackRequest;

		private bool mblnIsPostbackRequest;

		private bool mblnIsCompressionRequested;

		private string mstrApplicationRelativePath;

		private string mstrApplicationAuthentication;

		private HostRequest mobjRequest;

		private static bool mblnPngSupportEnabled;

		private static Dictionary<string, string> marrSystemPages;

		private static string mstrForcedDomain;

		private static string mstrForcedPort;

		private static string mstrForceVirtualDirectory;

		private static J menmForceSSLProtocol;

		private static string[] marrVirtualDirectory;

		private static bool mblnUseAuthentication;

		private bool mblnPageInstanceWasForced;

		private string mstrUserAgent;

		private HostBrowserCapabilities mobjBrowser;

		private CSS3BrowserCapabilities menmCSS3BrowserCapabilities = CSS3BrowserCapabilities.Empty;

		private HTML5BrowserCapabilities menmHTML5BrowserCapabilities = HTML5BrowserCapabilities.Empty;

		private MISCBrowserCapabilities menmMISCBrowserCapabilities = MISCBrowserCapabilities.Empty;

		private bool mblnFullScreenMode;

		internal ICollection<string> SystemPages => marrSystemPages.Keys;

		public bool PageInstanceWasForced
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrPageInstance))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadPageInstanceFromRequest();
				}
				return mblnPageInstanceWasForced;
			}
		}

		public bool IsCompressionRequested
		{
			get
			{
				if (string.IsNullOrEmpty(mstrPageName))
				{
					LoadPageFromRequest();
				}
				return mblnIsCompressionRequested;
			}
		}

		public string PageResource
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrPageName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadPageFromRequest();
				}
				if (!string.IsNullOrEmpty(mstrPageResource))
				{
					return mstrPageResource;
				}
				return mstrPageName;
			}
		}

		public bool IsPostbackRequest
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrPageName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadPageFromRequest();
				}
				return mblnIsPostbackRequest;
			}
		}

		public bool IsUserPostbackRequest
		{
			get
			{
				if (string.IsNullOrEmpty(mstrPageName))
				{
					LoadPageFromRequest();
				}
				return mblnIsUserPostbackRequest;
			}
		}

		public bool IsStatelessApplicationOrRequest
		{
			get
			{
				if (!(mobjRequest.QueryString["vwgstateless"] == "1"))
				{
					/*OpCode not supported: LdMemberToken*/;
					return HostRuntime.Config.GetApplicationStateless(PageName);
				}
				return true;
			}
		}

		public bool IsRedirectToSSLRequired
		{
			get
			{
				if (mobjRequest.Url.Scheme != Uri.UriSchemeHttps)
				{
					if (menmForceSSLProtocol == J.B)
					{
						return true;
					}
					if (PageType == RequestType.Preload)
					{
						return HostRuntime.Config.GetApplicationForceSSL(PageName);
					}
				}
				return false;
			}
		}

		public string PageName
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrPageName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadPageFromRequest();
				}
				return mstrPageName;
			}
		}

		public RequestType PageType
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrPageName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadPageFromRequest();
				}
				return menmPageType;
			}
		}

		public string PageInstance
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrPageInstance))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadPageInstanceFromRequest();
				}
				return mstrPageInstance;
			}
		}

		public string WebSocketConnectionId
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrWebSocketConnectionId))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadWebSocketConnectionIdFromRequest();
				}
				return mstrWebSocketConnectionId;
			}
		}

		public bool PageInstanceWasGiven => !string.IsNullOrEmpty(GetVwgInstanceValue());

		public Uri HttpsRedirectionUri
		{
			get
			{
				UriBuilder uriBuilder = new UriBuilder(mobjRequest.Url);
				uriBuilder.Scheme = Uri.UriSchemeHttps;
				string portFromUriOrConfiguration = GetPortFromUriOrConfiguration(uriBuilder.Uri, blnAddColon: false);
				if (!(portFromUriOrConfiguration != string.Empty))
				{
					/*OpCode not supported: LdMemberToken*/;
					uriBuilder.Port = -1;
				}
				else
				{
					uriBuilder.Port = int.Parse(portFromUriOrConfiguration);
				}
				return uriBuilder.Uri;
			}
		}

		public string ApplicationRelativePath
		{
			get
			{
				if (string.IsNullOrEmpty(mstrApplicationRelativePath))
				{
					if (!string.IsNullOrEmpty(mstrPageName))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						LoadPageFromRequest();
					}
					string[] array = mstrPageName.Split('~');
					if (array.Length <= 1)
					{
						/*OpCode not supported: LdMemberToken*/;
						mstrApplicationRelativePath = "/";
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < array.Length - 1; i++)
						{
							/*OpCode not supported: LdMemberToken*/;
							stringBuilder.Append("/");
							stringBuilder.Append(array[i]);
						}
						stringBuilder.Append("/");
						mstrApplicationRelativePath = stringBuilder.ToString();
					}
				}
				return mstrApplicationRelativePath;
			}
		}

		public string ThemeDirectory
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrThemeDirectory))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadDirectoriesFromRequest();
				}
				return mstrThemeDirectory;
			}
			set
			{
				mstrThemeDirectory = value;
			}
		}

		public ReadOnlyCollection<string> AvailableThemes => marrAvailableThemes;

		public string CultureDirectory
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrCultureDirectory))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadDirectoriesFromRequest();
				}
				if (!string.IsNullOrEmpty(mstrCultureDirectory))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadCultureFromContext();
				}
				return mstrCultureDirectory;
			}
			set
			{
				mstrCultureDirectory = value;
			}
		}

		public CSS3BrowserCapabilities CSS3BrowserCapabilities
		{
			get
			{
				if (menmCSS3BrowserCapabilities != CSS3BrowserCapabilities.Empty)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadDirectoriesFromRequest();
				}
				return menmCSS3BrowserCapabilities;
			}
			set
			{
				menmCSS3BrowserCapabilities = value;
			}
		}

		public bool FullScreenMode
		{
			get
			{
				return mblnFullScreenMode;
			}
			set
			{
				mblnFullScreenMode = value;
			}
		}

		public HTML5BrowserCapabilities HTML5BrowserCapabilities
		{
			get
			{
				if (menmHTML5BrowserCapabilities != HTML5BrowserCapabilities.Empty)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadDirectoriesFromRequest();
				}
				return menmHTML5BrowserCapabilities;
			}
			set
			{
				menmHTML5BrowserCapabilities = value;
			}
		}

		public MISCBrowserCapabilities MISCBrowserCapabilities
		{
			get
			{
				if (menmMISCBrowserCapabilities == MISCBrowserCapabilities.Empty)
				{
					LoadDirectoriesFromRequest();
				}
				return menmMISCBrowserCapabilities;
			}
			set
			{
				menmMISCBrowserCapabilities = value;
			}
		}

		public string BrowserCapabilitiesDirectory => $"{Convert.ToInt32(CSS3BrowserCapabilities).ToString()}.{Convert.ToInt32(HTML5BrowserCapabilities).ToString()}.{Convert.ToInt32(MISCBrowserCapabilities).ToString()}";

		public string FullScreenDirectory
		{
			get
			{
				if (mblnFullScreenMode)
				{
					/*OpCode not supported: LdMemberToken*/;
					return "1";
				}
				return "0";
			}
		}

		public string BrowserDirectory
		{
			get
			{
				if (string.IsNullOrEmpty(mstrBrowserDirectory))
				{
					LoadDirectoriesFromRequest();
				}
				if (!string.IsNullOrEmpty(mstrBrowserDirectory))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadBrowserFromRequest();
				}
				return mstrBrowserDirectory;
			}
			set
			{
				mstrBrowserDirectory = value;
			}
		}

		public string CacheDirectory => WGConst.CacheVersion;

		public bool UseAuthentication
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrApplicationAuthentication))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadApplicationAuthenticationFromConfig();
				}
				string text = mstrApplicationAuthentication.ToLowerInvariant();
				if (!(text == "none"))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(text != "default"))
					{
						/*OpCode not supported: LdMemberToken*/;
						return mblnUseAuthentication;
					}
					return true;
				}
				return false;
			}
		}

		public string AuthenticationFormType
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrApplicationAuthentication))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadApplicationAuthenticationFromConfig();
				}
				string text = mstrApplicationAuthentication.ToLowerInvariant();
				if (!(text == "none"))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (text != "default")
					{
						return mstrApplicationAuthentication;
					}
					return HostRuntime.Config.GetAuthenticationParam("Type");
				}
				return null;
			}
		}

		public string UserAgent
		{
			get
			{
				if (!string.IsNullOrEmpty(mstrUserAgent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrUserAgent = mobjRequest.UserAgent;
				}
				return mstrUserAgent;
			}
		}

		public HostBrowserCapabilities Browser
		{
			get
			{
				if (mobjBrowser != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjBrowser = mobjRequest.Browser;
				}
				return mobjBrowser;
			}
		}

		static HostRequestInfo()
		{
			mblnPngSupportEnabled = true;
			mblnUseAuthentication = false;
			mblnPngSupportEnabled = HostRuntime.Config.GetFeatureValue("PngSupport", blnDefault: true);
			mstrForcedDomain = HostRuntime.Config.GetFeatureValue("ForceDomain", string.Empty);
			mstrForcedPort = HostRuntime.Config.GetFeatureValue("ForcePort", string.Empty);
			mstrForceVirtualDirectory = HostRuntime.Config.GetFeatureValue("ForceVirtualDirectory", string.Empty);
			string text = HostRuntime.Config.GetFeatureValue("ForceHTTPS", string.Empty);
			if (!string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!HostRuntime.Config.IsFeatureEnabled("ForceHTTPS", false))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = "Redirect";
			}
			if (string.IsNullOrEmpty(text))
			{
				menmForceSSLProtocol = J.A;
			}
			else
			{
				string text2 = text.ToLowerInvariant();
				if (text2 == "rewrite")
				{
					/*OpCode not supported: LdMemberToken*/;
					menmForceSSLProtocol = J.C;
				}
				else if (text2 == "redirect")
				{
					/*OpCode not supported: LdMemberToken*/;
					menmForceSSLProtocol = J.B;
				}
				else
				{
					menmForceSSLProtocol = J.A;
				}
			}
			mblnUseAuthentication = HostRuntime.Config.UseAuthentication;
			marrVirtualDirectory = GetVirtualDirectoryFromHostRuntime();
			marrSystemPages = new Dictionary<string, string>();
			InitializeSystemAuthenticationPages();
		}

		protected HostRequestInfo(HostRequest objRequest)
		{
			mobjRequest = objRequest;
		}

		private static void InitializeSystemAuthenticationPages()
		{
			marrSystemPages.Add("vwgadministration", "Gizmox.WebGUI.Forms.AdministrationLogonForm, Gizmox.WebGUI.Forms");
		}

		internal void Initialize()
		{
			LoadDirectoriesFromRequest();
		}

		private void LoadApplicationAuthenticationFromConfig()
		{
			if (string.IsNullOrEmpty(mstrApplicationAuthentication))
			{
				if (marrSystemPages.TryGetValue(PageName, out var value))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					value = HostRuntime.Config.GetApplicationAuthentication(PageName);
				}
				if (string.IsNullOrEmpty(value))
				{
					/*OpCode not supported: LdMemberToken*/;
					mstrApplicationAuthentication = "default";
				}
				else
				{
					mstrApplicationAuthentication = value;
				}
			}
		}

		private void LoadCultureFromContext()
		{
			if (!string.IsNullOrEmpty(mstrCultureDirectory))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mstrCultureDirectory = Thread.CurrentThread.CurrentUICulture.Name;
			}
		}

		private void LoadBrowserFromRequest()
		{
			if (!string.IsNullOrEmpty(mstrBrowserDirectory))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string text;
			if (!CommonUtils.IsMono)
			{
				/*OpCode not supported: LdMemberToken*/;
				text = mobjRequest.Browser[""];
			}
			else
			{
				text = mobjRequest.Headers["User-Agent"];
			}
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
				mstrBrowserDirectory = "ie";
			}
			else if (Regex.IsMatch(text, "MSIE ([^;]*)|Trident.*; rv:([0-9.]+)", RegexOptions.IgnoreCase))
			{
				mstrBrowserDirectory = "ie";
			}
			else if (text.IndexOf("WebKit") <= -1)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (text.IndexOf("Opera") <= -1)
				{
					/*OpCode not supported: LdMemberToken*/;
					mstrBrowserDirectory = "moz";
				}
				else
				{
					mstrBrowserDirectory = "opr";
				}
			}
			else
			{
				mstrBrowserDirectory = "kit";
			}
		}

		private void LoadDirectoriesFromRequest()
		{
			string[] segments = mobjRequest.Url.Segments;
			int num = -1;
			string[] array = segments;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = array[i];
				if (num == -1)
				{
					if (!text.Equals("Route/", StringComparison.InvariantCultureIgnoreCase))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						num = 0;
					}
					continue;
				}
				text = text.Trim('/');
				switch (num)
				{
				case 1:
					if (string.IsNullOrEmpty(mstrBrowserDirectory))
					{
						mstrBrowserDirectory = text;
					}
					break;
				case 2:
					if (string.IsNullOrEmpty(mstrCultureDirectory))
					{
						mstrCultureDirectory = text;
					}
					break;
				case 3:
				{
					string[] array2 = text.Split(new string[1] { "." }, StringSplitOptions.RemoveEmptyEntries);
					List<string> list = new List<string>();
					string[] array3 = array2;
					for (int j = 0; j < array3.Length; j++)
					{
						/*OpCode not supported: LdMemberToken*/;
						string item = array3[j];
						list.Add(item);
					}
					marrAvailableThemes = new ReadOnlyCollection<string>(list);
					break;
				}
				case 4:
				{
					string[] array4 = text.Split('.');
					if (array4.Length != 3)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					CommonUtils.TryParse(array4[0], out menmCSS3BrowserCapabilities);
					CommonUtils.TryParse(array4[1], out menmHTML5BrowserCapabilities);
					CommonUtils.TryParse(array4[2], out menmMISCBrowserCapabilities);
					break;
				}
				case 5:
					mblnFullScreenMode = text == "1";
					break;
				case 6:
					if (!string.IsNullOrEmpty(mstrThemeDirectory))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mstrThemeDirectory = text;
					}
					break;
				}
				num++;
			}
		}

		private void LoadPageInstanceFromRequest()
		{
			if (!string.IsNullOrEmpty(mstrPageInstance))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string vwgInstanceValue = GetVwgInstanceValue();
			if (string.IsNullOrEmpty(vwgInstanceValue))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (HostRuntime.Config.ForcePageInstance)
				{
					/*OpCode not supported: LdMemberToken*/;
					mstrPageInstance = Guid.NewGuid().ToString("N");
					mblnPageInstanceWasForced = true;
				}
				else
				{
					mstrPageInstance = "0";
				}
			}
			else
			{
				mstrPageInstance = vwgInstanceValue;
			}
		}

		private void LoadWebSocketConnectionIdFromRequest()
		{
			if (string.IsNullOrEmpty(mstrWebSocketConnectionId))
			{
				string vwgWebSocketConnectionIdValue = GetVwgWebSocketConnectionIdValue();
				if (string.IsNullOrEmpty(vwgWebSocketConnectionIdValue))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrWebSocketConnectionId = vwgWebSocketConnectionIdValue;
				}
			}
		}

		private string GetVwgInstanceValue()
		{
			string text = null;
			text = mobjRequest.QueryString["vwginstance"];
			if (!string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = mobjRequest.Form["vwginstance"];
			}
			return ValidateVwgInstanceValue(text);
		}

		private string ValidateVwgInstanceValue(string strInstance)
		{
			if (string.IsNullOrEmpty(strInstance))
			{
				return strInstance;
			}
			strInstance = strInstance.Trim();
			bool flag = true;
			string text = strInstance;
			foreach (char c in text)
			{
				if (c < '0')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (c <= '9')
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				flag = false;
			}
			if (flag)
			{
				return strInstance;
			}
			if (!Guid.TryParse(strInstance, out var _))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new ArgumentException("Invalid query argument - vwginstance can be either numeric or GUID.");
			}
			return strInstance;
		}

		private string GetVwgWebSocketConnectionIdValue()
		{
			return mobjRequest.QueryString["vwgwebsocketconnectionid"];
		}

		private bool IsAlphaNumeric(string strText)
		{
			return !new Regex("[^a-zA-Z0-9]").IsMatch(strText);
		}

		private void LoadPageFromRequest()
		{
			if (!string.IsNullOrEmpty(mstrPageName))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string[] segments = mobjRequest.Url.Segments;
			if (segments.Length != 0)
			{
				string[] array = segments[segments.Length - 1].Split('.');
				if (array.Length != 2)
				{
					/*OpCode not supported: LdMemberToken*/;
					RequestType requestType = LoadRequestTypeFromPrefix(array[0]);
					if (requestType != RequestType.Unknown)
					{
						/*OpCode not supported: LdMemberToken*/;
						mstrPageName = GetPageNameFromPageParts(array, blnHasReservedPrefix: true);
						menmPageType = requestType;
						if (requestType != RequestType.Gateway)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							LoadGatewayRequestParameters();
						}
					}
					else
					{
						mstrPageName = GetPageNameFromPageParts(array, blnHasReservedPrefix: false);
						menmPageType = RequestType.Preload;
					}
				}
				else
				{
					mstrPageName = array[0];
					menmPageType = RequestType.Preload;
				}
				LoadIsPostbackFromRequest();
			}
			if (menmPageType == RequestType.Preload)
			{
				mstrPageName = GetPageNameWithDirectory(segments, mstrPageName);
			}
		}

		private string GetPageNameWithDirectory(string[] arrUrlSegments, string strPageName)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			int num = -1;
			for (int i = 0; i < arrUrlSegments.Length - 1; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (arrUrlSegments[i] == "/")
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (arrUrlSegments[i].Equals("Route/", StringComparison.InvariantCultureIgnoreCase))
				{
					break;
				}
				num++;
				if (marrVirtualDirectory.Length <= num)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (marrVirtualDirectory[num].Equals(arrUrlSegments[i], StringComparison.InvariantCultureIgnoreCase))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				stringBuilder.Append(arrUrlSegments[i].Replace('/', '~'));
			}
			stringBuilder.Append(strPageName);
			return stringBuilder.ToString();
		}

		private static string GetPageNameFromPageParts(string[] arrPageNameParts, bool blnHasReservedPrefix)
		{
			int num = (blnHasReservedPrefix ? 1 : 0);
			int count = arrPageNameParts.Length - 1 - num;
			return string.Join(".", arrPageNameParts, num, count);
		}

		private void LoadIsPostbackFromRequest()
		{
			if (mblnIsUserPostbackRequest)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(mobjRequest.HttpMethod == "POST"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mblnIsPostbackRequest = true;
			}
		}

		private void LoadGatewayRequestParameters()
		{
			GatewayParameters gatewayParameters = new GatewayParameters(mstrPageName);
			if (gatewayParameters.IsFullyQualifiedParameters)
			{
				mstrPageResource = mstrPageName;
				mstrPageInstance = gatewayParameters.MainFormInstance;
				mstrPageName = gatewayParameters.MainForm;
			}
		}

		private RequestType LoadRequestTypeFromPrefix(string strPrefix)
		{
			RequestType result = RequestType.Unknown;
			strPrefix = strPrefix.ToLowerInvariant();
			uint num = SC.ComputeStringHash(strPrefix);
			if (num <= 3172023953u)
			{
				if (num > 1893056498)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 2428421058u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 2572284093u:
							/*OpCode not supported: LdMemberToken*/;
							if (strPrefix == "mashup")
							{
								result = RequestType.Mashup;
							}
							break;
						case 2953855385u:
							/*OpCode not supported: LdMemberToken*/;
							if (strPrefix == "assemblies")
							{
								result = RequestType.Assemblies;
							}
							break;
						case 3172023953u:
							/*OpCode not supported: LdMemberToken*/;
							if (strPrefix == "skins")
							{
								/*OpCode not supported: LdMemberToken*/;
								result = RequestType.Skins;
							}
							break;
						}
					}
					else
					{
						switch (num)
						{
						case 2428421058u:
							/*OpCode not supported: LdMemberToken*/;
							if (strPrefix == "content")
							{
								/*OpCode not supported: LdMemberToken*/;
								result = RequestType.Content;
							}
							break;
						case 2313681479u:
							if (strPrefix == "post")
							{
								/*OpCode not supported: LdMemberToken*/;
								result = RequestType.Preload;
								mblnIsUserPostbackRequest = true;
							}
							break;
						}
					}
				}
				else if (num > 1593667296)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 1792499812u:
						/*OpCode not supported: LdMemberToken*/;
						if (strPrefix == "manifest")
						{
							/*OpCode not supported: LdMemberToken*/;
							result = RequestType.Manifest;
						}
						break;
					case 1893056498u:
						/*OpCode not supported: LdMemberToken*/;
						if (strPrefix == "resources")
						{
							result = RequestType.Resources;
						}
						break;
					}
				}
				else
				{
					switch (num)
					{
					case 576405616u:
						/*OpCode not supported: LdMemberToken*/;
						if (strPrefix == "gzipcomponent")
						{
							/*OpCode not supported: LdMemberToken*/;
							result = RequestType.Gateway;
							mblnIsCompressionRequested = true;
						}
						break;
					case 1593667296u:
						if (strPrefix == "component")
						{
							result = RequestType.Gateway;
						}
						break;
					}
				}
			}
			else if (num > 3631407781u)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 4192329017u)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 4275479504u:
						/*OpCode not supported: LdMemberToken*/;
						if (strPrefix == "framestyleimage")
						{
							/*OpCode not supported: LdMemberToken*/;
							result = RequestType.FrameStyleImage;
						}
						break;
					case 4237826497u:
						if (strPrefix == "capture")
						{
							/*OpCode not supported: LdMemberToken*/;
							result = RequestType.Preload;
						}
						break;
					case 4292920474u:
						if (strPrefix == "types")
						{
							/*OpCode not supported: LdMemberToken*/;
							result = RequestType.Types;
						}
						break;
					}
				}
				else
				{
					switch (num)
					{
					case 4192329017u:
						/*OpCode not supported: LdMemberToken*/;
						if (strPrefix == "icons")
						{
							/*OpCode not supported: LdMemberToken*/;
							result = RequestType.Icons;
						}
						break;
					case 3804862122u:
						if (strPrefix == "statelesscomponent")
						{
							/*OpCode not supported: LdMemberToken*/;
							LoadSessionIdFromQueryString();
							result = RequestType.Gateway;
						}
						break;
					}
				}
			}
			else if (num > 3520546475u)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (num)
				{
				case 3532702267u:
					/*OpCode not supported: LdMemberToken*/;
					if (strPrefix == "static")
					{
						/*OpCode not supported: LdMemberToken*/;
						result = RequestType.StaticGateway;
					}
					break;
				case 3631407781u:
					/*OpCode not supported: LdMemberToken*/;
					if (strPrefix == "data")
					{
						/*OpCode not supported: LdMemberToken*/;
						result = RequestType.Data;
					}
					break;
				}
			}
			else
			{
				switch (num)
				{
				case 3443354634u:
					/*OpCode not supported: LdMemberToken*/;
					if (strPrefix == "statistics")
					{
						result = RequestType.Statistics;
					}
					break;
				case 3520546475u:
					/*OpCode not supported: LdMemberToken*/;
					if (strPrefix == "images")
					{
						/*OpCode not supported: LdMemberToken*/;
						result = RequestType.Images;
					}
					break;
				}
			}
			return result;
		}

		private void LoadSessionIdFromQueryString()
		{
			string value = mobjRequest.QueryString["SessionId"];
			if (string.IsNullOrEmpty(value))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjRequest.Cookies.Add("ASP.NET_SessionId", value);
			}
		}

		private string GetProtocolFromUriOrConfiguration(Uri objRequestUri)
		{
			if (menmForceSSLProtocol == J.A)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objRequestUri.Scheme == Uri.UriSchemeHttps)
				{
					return "https";
				}
				return "http";
			}
			return "https";
		}

		private string GetVirtualDirectoryFromUriOrConfiguration(Uri objRequestUri)
		{
			if (string.IsNullOrEmpty(mstrForceVirtualDirectory))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (marrVirtualDirectory.Length != 0)
				{
					return string.Join("/", marrVirtualDirectory);
				}
				return string.Empty;
			}
			if (mstrForceVirtualDirectory.EndsWith("/"))
			{
				/*OpCode not supported: LdMemberToken*/;
				return mstrForceVirtualDirectory;
			}
			return $"{mstrForceVirtualDirectory}/";
		}

		private string GetDomainFromUriOrConfiguration(Uri objRequestUri)
		{
			if (!string.IsNullOrEmpty(mstrForcedDomain))
			{
				return mstrForcedDomain;
			}
			return objRequestUri.Host;
		}

		private string GetPortFromUriOrConfiguration(Uri objRequestUri, bool blnAddColon)
		{
			int result = 80;
			if (string.IsNullOrEmpty(mstrForcedPort))
			{
				/*OpCode not supported: LdMemberToken*/;
				result = objRequestUri.Port;
			}
			else
			{
				int.TryParse(mstrForcedPort, out result);
			}
			if (result != 80)
			{
				if (blnAddColon)
				{
					return $":{result}";
				}
				return result.ToString();
			}
			return string.Empty;
		}

		private static string[] GetVirtualDirectoryFromHostRuntime()
		{
			List<string> list = new List<string>();
			try
			{
				string[] array = HostRuntime.AppDomainAppVirtualPath.Split('/', '\\');
				for (int i = 0; i < array.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						list.Add($"{text}/");
					}
				}
			}
			catch (Exception)
			{
			}
			return list.ToArray();
		}

		public string GetRouterContext(CultureInfo objCurrentCultureInfo, bool blnClosingSeperator)
		{
			Uri url = mobjRequest.Url;
			string protocolFromUriOrConfiguration = GetProtocolFromUriOrConfiguration(url);
			string portFromUriOrConfiguration = GetPortFromUriOrConfiguration(url, blnAddColon: true);
			string domainFromUriOrConfiguration = GetDomainFromUriOrConfiguration(url);
			string virtualDirectoryFromUriOrConfiguration = GetVirtualDirectoryFromUriOrConfiguration(url);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}://{1}{2}/{3}", protocolFromUriOrConfiguration, domainFromUriOrConfiguration, portFromUriOrConfiguration, virtualDirectoryFromUriOrConfiguration);
			string cookielessSession = GetCookielessSession();
			if (string.IsNullOrEmpty(cookielessSession))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.AppendFormat("(S({0}))/", cookielessSession);
			}
			stringBuilder.AppendFormat("{0}", "Route/");
			stringBuilder.AppendFormat("{0}/", CacheDirectory);
			stringBuilder.AppendFormat("{0}/", BrowserDirectory);
			stringBuilder.AppendFormat("{0}/", objCurrentCultureInfo.Name);
			string text = "";
			for (int i = 0; i < VWGContext.Current.AvailableThemes.Count; i++)
			{
				text += VWGContext.Current.AvailableThemes[i];
				if (i >= VWGContext.Current.AvailableThemes.Count - 1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text += ".";
				}
			}
			stringBuilder.AppendFormat("{0}/", text);
			stringBuilder.AppendFormat("{0}/", BrowserCapabilitiesDirectory);
			stringBuilder.AppendFormat("{0}/", FullScreenDirectory);
			stringBuilder.AppendFormat("{0}", ThemeDirectory);
			if (!blnClosingSeperator)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("/");
			}
			return stringBuilder.ToString();
		}

		private string GetCookielessSession()
		{
			return HostContext.Current.Items["AspCookielessSession"] as string;
		}
	}
}
