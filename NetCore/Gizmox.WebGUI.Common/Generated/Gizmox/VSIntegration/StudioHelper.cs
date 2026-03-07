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

namespace Gizmox.VSIntegration
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class StudioHelper
	{
		private enum PC
		{
			A,
			B,
			C,
			D,
			E,
			F,
			G,
			H,
			I,
			J,
			K,
			L
		}

		private static PC A = PC.K;

		private static string B = "studio_version_lock";

		private static PC Version
		{
			get
			{
				if (A == PC.K)
				{
					lock (B)
					{
						if (A == PC.K)
						{
							string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
							if (string.IsNullOrEmpty(baseDirectory))
							{
								/*OpCode not supported: LdMemberToken*/;
								A = PC.L;
							}
							else
							{
								A = GetStudioVersion(baseDirectory, AppDomain.CurrentDomain.SetupInformation.GetType().GetProperty("ConfigurationFile")?.GetValue(AppDomain.CurrentDomain.SetupInformation) as string ?? "app.config");
							}
						}
					}
				}
				return A;
			}
		}

		public static bool IsExpress
		{
			get
			{
				if (Version != PC.A)
				{
					if (Version == PC.B)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (Version != PC.C && Version != PC.D)
					{
						return Version == PC.E;
					}
				}
				return true;
			}
		}

		public static bool IsProfesional
		{
			get
			{
				if (Version == PC.F)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (Version == PC.G)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (Version == PC.H)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (Version != PC.I)
					{
						return Version == PC.J;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return true;
			}
		}

		public static bool IsUnapplicable => Version == PC.L;

		public static string VersionNumber
		{
			get
			{
				switch (Version)
				{
				case PC.A:
				case PC.F:
					return "v8.0";
				case PC.B:
				case PC.G:
					return "v9.0";
				case PC.C:
				case PC.H:
					return "v10.0";
				case PC.D:
				case PC.I:
					return "v11.0";
				case PC.E:
				case PC.J:
					return "v12.0";
				default:
					return "v0.0";
				}
			}
		}

		private static PC GetStudioVersion(string strBaseDirectory, string strConfigFile)
		{
			if (!IsStudio("SOFTWARE\\Microsoft\\VisualStudio\\8.0", strBaseDirectory))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsStudio("SOFTWARE\\Microsoft\\VisualStudio\\9.0", strBaseDirectory))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!IsStudio("SOFTWARE\\Microsoft\\VisualStudio\\10.0", strBaseDirectory))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsStudio("SOFTWARE\\Microsoft\\VisualStudio\\11.0", strBaseDirectory))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (!IsStudio("SOFTWARE\\Microsoft\\VisualStudio\\12.0", strBaseDirectory))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (IsStudio("SOFTWARE\\Microsoft\\VisualStudio\\10.0Exp", strBaseDirectory))
								{
									return PC.H;
								}
								if (IsStudio("SOFTWARE\\Microsoft\\VWDExpress\\8.0", strBaseDirectory))
								{
									return PC.A;
								}
								if (IsStudio("SOFTWARE\\Microsoft\\VWDExpress\\9.0", strBaseDirectory))
								{
									return PC.B;
								}
								if (IsStudio("SOFTWARE\\Microsoft\\VWDExpress\\10.0", strBaseDirectory))
								{
									return PC.C;
								}
								if (!IsStudio("SOFTWARE\\Microsoft\\VWDExpress\\11.0", strBaseDirectory))
								{
									/*OpCode not supported: LdMemberToken*/;
									if (!IsStudio("SOFTWARE\\Microsoft\\VWDExpress\\12.0", strBaseDirectory))
									{
										/*OpCode not supported: LdMemberToken*/;
										return PC.L;
									}
									return PC.E;
								}
								return PC.D;
							}
							if (!IsExpressConfigFile(strConfigFile))
							{
								/*OpCode not supported: LdMemberToken*/;
								return PC.J;
							}
							return PC.E;
						}
						if (!IsExpressConfigFile(strConfigFile))
						{
							/*OpCode not supported: LdMemberToken*/;
							return PC.I;
						}
						return PC.D;
					}
					if (!IsExpressConfigFile(strConfigFile))
					{
						/*OpCode not supported: LdMemberToken*/;
						return PC.H;
					}
					return PC.C;
				}
				if (!IsExpressConfigFile(strConfigFile))
				{
					/*OpCode not supported: LdMemberToken*/;
					return PC.G;
				}
				return PC.B;
			}
			if (!IsExpressConfigFile(strConfigFile))
			{
				/*OpCode not supported: LdMemberToken*/;
				return PC.F;
			}
			return PC.A;
		}

		private static bool IsExpressConfigFile(string strConfigFile)
		{
			if (string.IsNullOrEmpty(strConfigFile))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (strConfigFile.ToLowerInvariant().EndsWith("vwdexpress.exe.config"))
			{
				return true;
			}
			return false;
		}

		private static bool IsStudio(string strStudioKey, string strBaseDirectory)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(strStudioKey);
			if (registryKey == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object value = registryKey.GetValue("InstallDir");
				if (value != null)
				{
					if (value is string)
					{
						return ((string)value).ToLowerInvariant() == strBaseDirectory.ToLowerInvariant();
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return false;
		}
	}
}
