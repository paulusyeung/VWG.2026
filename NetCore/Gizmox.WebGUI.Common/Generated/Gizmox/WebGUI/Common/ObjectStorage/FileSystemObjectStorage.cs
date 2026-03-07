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

namespace Gizmox.WebGUI.Common.ObjectStorage
{
	[Serializable]
	public class FileSystemObjectStorage : BaseObjectStorage
	{
		private string mstrPath;

		private string mstrEncodingName;

		[NonSerialized]
		private Encoding A;

		public string EncodingName
		{
			get
			{
				return mstrEncodingName;
			}
			set
			{
				mstrEncodingName = value;
				A = null;
			}
		}

		protected Encoding Encoding
		{
			get
			{
				if (A == null)
				{
					if (string.IsNullOrEmpty(EncodingName))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						A = Encoding.GetEncoding(EncodingName);
					}
				}
				return A;
			}
		}

		public string Path
		{
			get
			{
				return mstrPath;
			}
			set
			{
				mstrPath = value;
			}
		}

		public FileSystemObjectStorage()
		{
		}

		public FileSystemObjectStorage(string strPath)
			: this(strPath, null)
		{
		}

		public FileSystemObjectStorage(string strPath, string strEncodingName)
		{
			mstrPath = strPath;
			mstrEncodingName = strEncodingName;
			Directory.CreateDirectory(strPath);
		}

		public override T RetrieveObject<T>(string strKey)
		{
			string fileFullPath = GetFileFullPath(strKey);
			if (IsContainsKey(strKey))
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = null;
				if (Encoding != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					text = File.ReadAllText(fileFullPath, Encoding);
				}
				else
				{
					text = File.ReadAllText(fileFullPath);
				}
				return ConvertStringToObject<T>(text);
			}
			return null;
		}

		public override void SaveObject<T>(string strKey, T objObject)
		{
			string fileFullPath = GetFileFullPath(strKey);
			if (IsContainsKey(strKey))
			{
				RemoveObject(strKey);
			}
			string contents = ConvertObjectToString(objObject);
			if (Encoding != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				File.WriteAllText(fileFullPath, contents, Encoding);
			}
			else
			{
				File.WriteAllText(fileFullPath, contents);
			}
		}

		public override bool RemoveObject(string strKey)
		{
			string fileFullPath = GetFileFullPath(strKey);
			if (IsContainsKey(strKey))
			{
				/*OpCode not supported: LdMemberToken*/;
				File.Delete(fileFullPath);
				return true;
			}
			return false;
		}

		private bool IsContainsKey(string strKey)
		{
			if (File.Exists(GetFileFullPath(strKey)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return false;
		}

		private string GetFileFullPath(string strKey)
		{
			string text = strKey;
			char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
			foreach (char oldChar in invalidFileNameChars)
			{
				text = text.Replace(oldChar, '_');
			}
			return System.IO.Path.Combine(mstrPath, text);
		}

		public override string[] GetAllKeys()
		{
			List<string> list = new List<string>();
			FileInfo[] files = new DirectoryInfo(mstrPath).GetFiles("*.xaml");
			foreach (FileInfo fileInfo in files)
			{
				list.Add(fileInfo.Name);
			}
			return list.ToArray();
		}
	}
}
