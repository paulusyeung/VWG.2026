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

namespace Gizmox.WebGUI.Common
{
	[Serializable]
	internal sealed class SR
	{
		internal const string Test = "Test";

		private static SR mobjLoader;

		private System.Resources.ResourceManager mobjResources;

		static SR()
		{
			mobjLoader = null;
		}

		internal SR()
		{
			mobjResources = new System.Resources.ResourceManager("Gizmox.WebGUI.Forms.SR", Assembly.Load("Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d"));
		}

		public static bool GetBoolean(string name)
		{
			return GetBoolean(null, name);
		}

		public static bool GetBoolean(CultureInfo culture, string name)
		{
			bool result = false;
			SR loader = GetLoader();
			if (loader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (obj is bool)
				{
					result = (bool)obj;
				}
			}
			return result;
		}

		public static byte GetByte(string name)
		{
			return GetByte(null, name);
		}

		public static byte GetByte(CultureInfo culture, string name)
		{
			byte result = 0;
			SR loader = GetLoader();
			if (loader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (!(obj is byte))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = (byte)obj;
				}
			}
			return result;
		}

		public static char GetChar(string name)
		{
			return GetChar(null, name);
		}

		public static char GetChar(CultureInfo culture, string name)
		{
			char result = '\0';
			SR loader = GetLoader();
			if (loader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (obj is char)
				{
					result = (char)obj;
				}
			}
			return result;
		}

		public static double GetDouble(string name)
		{
			return GetDouble(null, name);
		}

		public static double GetDouble(CultureInfo culture, string name)
		{
			double result = 0.0;
			SR loader = GetLoader();
			if (loader != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (!(obj is double))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = (double)obj;
				}
			}
			return result;
		}

		public static float GetFloat(string name)
		{
			return GetFloat(null, name);
		}

		public static float GetFloat(CultureInfo culture, string name)
		{
			float result = 0f;
			SR loader = GetLoader();
			if (loader != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (!(obj is float))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = (float)obj;
				}
			}
			return result;
		}

		public static int GetInt(string name)
		{
			return GetInt(null, name);
		}

		public static int GetInt(CultureInfo culture, string name)
		{
			int result = 0;
			SR loader = GetLoader();
			if (loader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (obj is int)
				{
					result = (int)obj;
				}
			}
			return result;
		}

		private static SR GetLoader()
		{
			if (mobjLoader != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				lock (typeof(SR))
				{
					if (mobjLoader != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjLoader = new SR();
					}
				}
			}
			return mobjLoader;
		}

		public static long GetLong(string name)
		{
			return GetLong(null, name);
		}

		public static long GetLong(CultureInfo culture, string name)
		{
			long result = 0L;
			SR loader = GetLoader();
			if (loader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (!(obj is long))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = (long)obj;
				}
			}
			return result;
		}

		public static object GetObject(string name)
		{
			return GetObject(null, name);
		}

		public static object GetObject(CultureInfo culture, string name)
		{
			SR loader = GetLoader();
			if (loader != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return loader.mobjResources.GetObject(name, culture);
			}
			return null;
		}

		public static short GetShort(string name)
		{
			return GetShort(null, name);
		}

		public static short GetShort(CultureInfo culture, string name)
		{
			short result = 0;
			SR loader = GetLoader();
			if (loader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = loader.mobjResources.GetObject(name, culture);
				if (!(obj is short))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = (short)obj;
				}
			}
			return result;
		}

		public static string GetString(string name)
		{
			return GetString(null, name);
		}

		public static string GetString(CultureInfo culture, string name)
		{
			SR loader = GetLoader();
			if (loader != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return loader.mobjResources.GetString(name, culture);
			}
			return null;
		}

		public static string GetString(string name, params object[] args)
		{
			return GetString(null, name, args);
		}

		public static string GetString(CultureInfo culture, string name, params object[] args)
		{
			SR loader = GetLoader();
			if (loader != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = loader.mobjResources.GetString(name, culture);
				if (args == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (args.Length != 0)
					{
						return string.Format(text, args);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return text;
			}
			return null;
		}
	}
}
