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

namespace Gizmox.WebGUI.Common.Configuration
{
	public class ConfigHelper
	{
		private static DeviceIntegrationInfo A;

		private static bool B;

		private static bool C;

		private static bool D;

		private static bool E;

		private static bool F;

		private static Dictionary<string, Type> G;

		private static string[] H;

		private static AdministrationConfigurationInfo I;

		private static List<string> J;

		private static Type[] K;

		private static string L;

		private static string M;

		private static bool N;

		private static string O;

		private static List<Type> P;

		public static DeviceIntegrationInfo DeviceIntegrationInfo => A;

		public static Dictionary<string, Type> ThemeTypes
		{
			get
			{
				if (!CommonUtils.IsDesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Config instance = Config.GetInstance();
					if (instance == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						G = instance.ThemeTypes;
					}
				}
				return G;
			}
		}

		public static bool IsCompressionEnabled => D;

		public static bool ForceContentAvailabilityOnClient => E;

		public static string DefaultClientEventAvailability => O;

		public static PresentationDrawingEngine CurrentPresentationDrawingEngine => Config.GetInstance()?.GetCurrentPresentationDrawingEngine() ?? PresentationDrawingEngine.JQT;

		public static string ModalDialogEmulationMode => M;

		public static bool FullScreenMode => N;

		public static bool IsCacheEnabled => B;

		public static bool HideResourcesPane => C;

		public static bool IsObscuringEnabled => F;

		public static string DynamicExtension => L;

		public static string[] Themes
		{
			get
			{
				if (!CommonUtils.IsDesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Config instance = Config.GetInstance();
					if (instance == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						H = instance.Themes;
					}
				}
				return H;
			}
		}

		public static AdministrationConfigurationInfo Administration
		{
			get
			{
				if (!CommonUtils.IsDesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Config instance = Config.GetInstance();
					if (instance != null)
					{
						I = instance.Administration;
					}
				}
				return I;
			}
		}

		public static List<string> AvailableThemes
		{
			get
			{
				if (CommonUtils.IsDesignMode)
				{
					Config instance = Config.GetInstance();
					if (instance == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						J = instance.AvailableThemes;
					}
				}
				return J;
			}
		}

		public static Type[] VisualTemplateTypesList
		{
			get
			{
				if (!CommonUtils.IsDesignMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Config instance = Config.GetInstance();
					if (instance == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						K = instance.RegisteredVisualTemplates.ToArray();
					}
				}
				return K;
			}
		}

		public static string SelectedTheme
		{
			get
			{
				string result = "Default";
				Config instance = Config.GetInstance();
				if (instance == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = instance.DefaultTheme;
				}
				return result;
			}
		}

		public static bool ApplySelectedThemeInDesignTime
		{
			get
			{
				bool result = false;
				Config instance = Config.GetInstance();
				if (instance == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = instance.ApplySelectedThemeInDesignTime;
				}
				return result;
			}
		}

		public static List<Type> Actions => P;

		static ConfigHelper()
		{
			B = false;
			C = false;
			D = false;
			E = false;
			F = false;
			G = null;
			H = null;
			I = null;
			J = null;
			K = null;
			L = ".wgx";
			M = "none";
			N = false;
			O = "";
			P = null;
			B = !CommonSwitches.DisableCaching.Enabled;
			C = IsSwitchEnabled(CommonSwitches.HideResourcesPane, CommonSwitches.DisableResourcesManifest);
			F = !CommonSwitches.DisableObscuring;
			Config instance = Config.GetInstance();
			if (instance == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				G = new Dictionary<string, Type>();
				H = new string[1] { "Default" };
				J = new List<string>();
				I = new AdministrationConfigurationInfo(string.Empty, "admin", "Default", "admin");
				return;
			}
			D = instance.GetFeatureValue("GZipCompression", blnDefault: true);
			E = instance.GetFeatureValue("ForceContentAvailabilityOnClient", blnDefault: false);
			object m;
			if (instance.GetFeatureValue("ModalDialogEmulation", blnDefault: false))
			{
				/*OpCode not supported: LdMemberToken*/;
				m = "onthread";
			}
			else
			{
				m = instance.GetFeatureValue("ModalDialogEmulation", "none");
			}
			M = (string)m;
			N = instance.GetFeatureValue("FullScreen", blnDefault: false);
			L = instance.DynamicExtension;
			G = instance.ThemeTypes;
			H = instance.Themes;
			I = instance.Administration;
			J = instance.AvailableThemes;
			P = instance.ActionTypes;
			K = instance.RegisteredVisualTemplates.ToArray();
			O = instance.GetFeatureValue("DefaultClientEventAvailability", "Always");
			A = new DeviceIntegrationInfo(instance.GetSection("DeviceIntegration"));
		}

		private static bool IsSwitchEnabled(BooleanSwitch objBooleanSwitch, params BooleanSwitch[] arrOldNames)
		{
			Config instance = Config.GetInstance();
			if (instance == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (instance.GetSection(objBooleanSwitch.DisplayName) != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				for (int i = 0; i < arrOldNames.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					BooleanSwitch booleanSwitch = arrOldNames[i];
					if (instance.GetSection(booleanSwitch.DisplayName) == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					return booleanSwitch.Enabled;
				}
			}
			return objBooleanSwitch.Enabled;
		}
	}
}
