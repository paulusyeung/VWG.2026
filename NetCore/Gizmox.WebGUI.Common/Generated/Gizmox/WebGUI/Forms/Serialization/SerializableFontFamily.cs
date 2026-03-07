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

namespace Gizmox.WebGUI.Forms.Serialization
{
	[Serializable]
	public class SerializableFontFamily : ISerializationWrapper, IDisposable, ISerializable
	{
		private readonly FontFamily mobjFontFamily;

		private static SerializableFontFamily[] marrFamilies = null;

		private static object mobjFamiliesCreationLock = new object();

		public static SerializableFontFamily[] Families
		{
			get
			{
				if (marrFamilies != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object obj = mobjFamiliesCreationLock;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (marrFamilies == null)
						{
							marrFamilies = GetSerializableFamilies(FontFamily.Families);
						}
					}
					finally
					{
						if (!lockTaken)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							Monitor.Exit(obj);
						}
					}
				}
				return marrFamilies;
			}
		}

		public static SerializableFontFamily GenericMonospace => (SerializableFontFamily)FontFamily.GenericMonospace;

		public static SerializableFontFamily GenericSansSerif => (SerializableFontFamily)FontFamily.GenericSansSerif;

		public static SerializableFontFamily GenericSerif => (SerializableFontFamily)FontFamily.GenericSerif;

		public string Name
		{
			get
			{
				if (mobjFontFamily == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return string.Empty;
				}
				return mobjFontFamily.Name;
			}
		}

		object ISerializationWrapper.Value => mobjFontFamily;

		public SerializableFontFamily(FontFamily objFontFamily)
		{
			mobjFontFamily = objFontFamily;
		}

		public SerializableFontFamily(GenericFontFamilies genericFamily)
		{
			mobjFontFamily = new FontFamily(genericFamily);
		}

		public SerializableFontFamily(string name)
		{
			mobjFontFamily = new FontFamily(name);
		}

		public SerializableFontFamily(string name, FontCollection fontCollection)
		{
			mobjFontFamily = new FontFamily(name, fontCollection);
		}

		private SerializableFontFamily(SerializationInfo info, StreamingContext context)
		{
			string text = info.GetString("Name");
			if (text == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				mobjFontFamily = null;
			}
			else
			{
				mobjFontFamily = new FontFamily(text);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (mobjFontFamily != null)
			{
				info.AddValue("Name", mobjFontFamily.Name);
			}
			else
			{
				info.AddValue("Name", null);
			}
		}

		public static implicit operator FontFamily(SerializableFontFamily objSerializableFontFamily)
		{
			if (objSerializableFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return objSerializableFontFamily.mobjFontFamily;
		}

		public static explicit operator SerializableFontFamily(FontFamily objFontFamily)
		{
			if (objFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new SerializableFontFamily(objFontFamily);
		}

		public void Dispose()
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjFontFamily.Dispose();
			}
		}

		public int GetCellAscent(FontStyle style)
		{
			if (mobjFontFamily != null)
			{
				return mobjFontFamily.GetCellAscent(style);
			}
			throw new ArgumentNullException();
		}

		public int GetCellDescent(FontStyle style)
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new ArgumentNullException();
			}
			return mobjFontFamily.GetCellDescent(style);
		}

		public int GetEmHeight(FontStyle style)
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new ArgumentNullException();
			}
			return mobjFontFamily.GetEmHeight(style);
		}

		public static SerializableFontFamily[] GetFamilies(Graphics graphics)
		{
			return GetSerializableFamilies(FontFamily.GetFamilies(graphics));
		}

		public override int GetHashCode()
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return -1;
			}
			return mobjFontFamily.GetHashCode();
		}

		public int GetLineSpacing(FontStyle style)
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new ArgumentNullException();
			}
			return mobjFontFamily.GetLineSpacing(style);
		}

		public string GetName(int language)
		{
			if (mobjFontFamily != null)
			{
				return mobjFontFamily.GetName(language);
			}
			throw new ArgumentNullException();
		}

		public bool IsStyleAvailable(FontStyle style)
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new ArgumentNullException();
			}
			return mobjFontFamily.IsStyleAvailable(style);
		}

		public override string ToString()
		{
			if (mobjFontFamily == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return mobjFontFamily.ToString();
		}

		private static SerializableFontFamily[] GetSerializableFamilies(FontFamily[] arrFamilies)
		{
			List<SerializableFontFamily> list = new List<SerializableFontFamily>();
			for (int i = 0; i < arrFamilies.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				FontFamily objFontFamily = arrFamilies[i];
				list.Add(new SerializableFontFamily(objFontFamily));
			}
			return list.ToArray();
		}
	}
}
