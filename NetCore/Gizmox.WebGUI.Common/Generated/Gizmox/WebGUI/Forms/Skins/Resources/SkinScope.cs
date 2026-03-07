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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	internal class SkinScope : KB
	{
		[Serializable]
		internal class ScopeVariables : LB
		{
			private SkinScope mobjOwner;

			public object this[string strVariableName]
			{
				get
				{
					if (!string.IsNullOrEmpty(strVariableName))
					{
						if (strVariableName == "Path")
						{
							return mobjOwner.SkinPath;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (strVariableName == "CommonPath")
						{
							return "Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.";
						}
						/*OpCode not supported: LdMemberToken*/;
						Skin skin = mobjOwner.Skin;
						if (skin != null)
						{
							PropertyInfo property = skin.GetType().GetProperty(strVariableName);
							if (!(property != null))
							{
								/*OpCode not supported: LdMemberToken*/;
								return null;
							}
							return property.GetValue(skin, new object[0]);
						}
					}
					return null;
				}
			}

			public ScopeVariables(SkinScope objOwner)
			{
				mobjOwner = objOwner;
			}
		}

		[Serializable]
		internal class SkinScopeCollection : List<SkinScope>
		{
		}

		private SkinScopeCollection mobjSkins;

		private Skin mobjSkin;

		private Dictionary<string, FileResource> mobjResources;

		private ScopeVariables mobjVariables;

		private readonly string mstrName;

		private bool mblnIsCompiled;

		private object mobjCompileLock = new object();

		public string Name => mstrName;

		public string SkinPath => $"Resources.{Name}.";

		public SkinScopeCollection Skins
		{
			get
			{
				if (mobjSkins != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjSkins = new SkinScopeCollection();
				}
				return mobjSkins;
			}
		}

		public override LB Variables
		{
			get
			{
				if (mobjVariables == null)
				{
					mobjVariables = new ScopeVariables(this);
				}
				return mobjVariables;
			}
		}

		private Dictionary<string, FileResource> Resources
		{
			get
			{
				if (mobjResources == null)
				{
					mobjResources = new Dictionary<string, FileResource>();
				}
				return mobjResources;
			}
		}

		public Skin Skin => mobjSkin;

		public bool IsCompiled => mblnIsCompiled;

		public SkinScope(string strName, int intID)
			: base(intID)
		{
			mstrName = strName;
		}

		internal void AddResource(string strName, FileResource objFileResource)
		{
			Resources.Add(GetResourceSafeName(strName, objFileResource.FileExtension, Resources), objFileResource);
			SkinCollector resourceCollector = GetResourceCollector(strName, objFileResource);
			if (resourceCollector == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				resourceCollector.Add(GetResourceSafeName(strName, objFileResource.FileExtension, resourceCollector), new SkinCollectorResource(this, objFileResource));
			}
		}

		private string GetResourceSafeName(string strResourceName, string strResourceFileExtension, IDictionary objDictionary)
		{
			string text = strResourceName;
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!objDictionary.Contains(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string arg = strResourceName.TrimEnd(strResourceFileExtension.ToCharArray());
				int num = 1;
				text = $"{arg}{num.ToString()}{strResourceFileExtension}";
				while (objDictionary.Contains(text))
				{
					/*OpCode not supported: LdMemberToken*/;
					num++;
					text = $"{arg}{num.ToString()}{strResourceFileExtension}";
				}
			}
			return text;
		}

		private SkinCollector GetResourceCollector(string strFileName, FileResource objFileResource)
		{
			string resourceCollectorName = GetResourceCollectorName(strFileName, objFileResource);
			if (string.IsNullOrEmpty(resourceCollectorName))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Global is GlobalScope { Collectors: var collectors })
			{
				if (collectors.ContainsKey(resourceCollectorName))
				{
					return collectors[resourceCollectorName];
				}
				SkinCollector skinCollector = (SkinCollector)Activator.CreateInstance(objFileResource.CompilerCollectorType, Global, resourceCollectorName);
				if (skinCollector != null)
				{
					collectors.Add(resourceCollectorName, skinCollector);
					return skinCollector;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return null;
		}

		private string GetResourceCollectorName(string strFileName, FileResource objFileResource)
		{
			PresentationRole presentationRole = objFileResource.PresentationRole;
			if (presentationRole != PresentationRole.Custom)
			{
				return $"{SkinFactory.GetRoleResourceName(presentationRole)}{objFileResource.FileExtension}";
			}
			string name = Name;
			string arg;
			if (!string.IsNullOrEmpty(objFileResource.AccessName))
			{
				/*OpCode not supported: LdMemberToken*/;
				arg = objFileResource.AccessName;
			}
			else
			{
				arg = strFileName;
			}
			return $"{name}.{arg}";
		}

		internal string GetMethodName(string strMember)
		{
			if (!SkinFactory.IsCompilerEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return strMember;
			}
			return GetScriptMemberValue(strMember);
		}

		internal string GetClassName(string strMember)
		{
			if (!SkinFactory.IsCompilerEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return strMember;
			}
			return GetCssMemberValue(GetClassNamePart(strMember), GetClassStatePart(strMember));
		}

		internal void SetSkin(Skin objSkin)
		{
			mobjSkin = objSkin;
		}

		public void Compile()
		{
			if (mblnIsCompiled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			object obj = mobjCompileLock;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (mblnIsCompiled)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (!(base.Parent is SkinScope skinScope))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				skinScope.Compile();
				try
				{
					using Dictionary<string, FileResource>.ValueCollection.Enumerator enumerator = Resources.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						FileResource current = enumerator.Current;
						if (!current.IsCompileEnabled)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							current.Compile(this);
						}
					}
				}
				finally
				{
					mblnIsCompiled = true;
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
	}
}
