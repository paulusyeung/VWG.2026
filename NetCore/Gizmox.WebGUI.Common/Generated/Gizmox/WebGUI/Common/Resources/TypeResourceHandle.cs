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

namespace Gizmox.WebGUI.Common.Resources
{
	[Serializable]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TypeResourceHandleSerializer, Gizmox.WebGUI.Common.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public class TypeResourceHandle : ResourceHandle
	{
		private CultureInfo mobjCulture = CultureInfo.CurrentUICulture;

		private Type mobjType;

		private string mstrResourcesBasePath = string.Empty;

		public CultureInfo Culture
		{
			get
			{
				return mobjCulture;
			}
			set
			{
				mobjCulture = value;
			}
		}

		public Type Type
		{
			get
			{
				return mobjType;
			}
			set
			{
				mobjType = value;
			}
		}

		public override bool IsServerResource => true;

		public string ResourcesBasePath
		{
			get
			{
				return mstrResourcesBasePath;
			}
			set
			{
				mstrResourcesBasePath = value;
			}
		}

		protected internal override bool IsResourceDataSupported => true;

		public TypeResourceHandle(Type objType, string strResourcesBasePath, string strFile, CultureInfo objCulture)
			: this(objType, strFile, objCulture)
		{
			mstrResourcesBasePath = strResourcesBasePath;
		}

		public TypeResourceHandle(Type objType, string strFile, CultureInfo objCulture)
			: this(objType, strFile)
		{
			mobjCulture = objCulture;
		}

		public TypeResourceHandle(Type objType, string strResourcesBasePath, string strFile)
			: this(objType, strFile)
		{
			mstrResourcesBasePath = strResourcesBasePath;
		}

		public TypeResourceHandle(Type objType, string strFile)
		{
			mobjType = objType;
			File = strFile;
		}

		public TypeResourceHandle()
		{
		}

		public override Stream ToStream()
		{
			Stream result = null;
			Type type = Type;
			if (type != null)
			{
				System.Resources.ResourceManager resourceManager = GetResourceManager(type);
				if (resourceManager == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					try
					{
						result = resourceManager.GetStream(File);
					}
					catch (Exception)
					{
					}
				}
			}
			return result;
		}

		public override Image ToImage()
		{
			Image result = null;
			Type type = Type;
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				System.Resources.ResourceManager resourceManager = GetResourceManager(type);
				if (resourceManager == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					try
					{
						result = resourceManager.GetObject(File) as Image;
					}
					catch (Exception)
					{
					}
				}
			}
			return result;
		}

		private System.Resources.ResourceManager GetResourceManager(Type objType)
		{
			System.Resources.ResourceManager resourceManager = null;
			string resourcesBasePath = ResourcesBasePath;
			if (!string.IsNullOrEmpty(resourcesBasePath))
			{
				return new System.Resources.ResourceManager(resourcesBasePath, objType.Assembly);
			}
			return new System.Resources.ResourceManager(objType);
		}

		protected override string GetSpecificResourceHandle()
		{
			string arg = $"Types.{File}{ResourceHandle.DynamicExtension}?type={HttpUtility.UrlEncode(mobjType.AssemblyQualifiedName)}";
			if (string.IsNullOrEmpty(ResourcesBasePath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				arg = $"{arg}&basepath={HttpUtility.UrlEncode(ResourcesBasePath)}";
			}
			return $"{arg}&culture={mobjCulture.Name}";
		}

		protected internal override string GetUniqueIdentifier()
		{
			return GetSpecificResourceHandle();
		}
	}
}
