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

namespace Gizmox.WebGUI.Forms.Skins
{
	[Serializable]
	public class SkinFactory
	{
		internal class DB : ISkinable
		{
			public string Theme => "Default";
		}

		private static Dictionary<Type, Skin> mobjComponentTypeSkin;

		private static object mobjComponentTypeSkinLock;

		private static Dictionary<Type, Skin> mobjSkinInstances;

		private static Dictionary<Type, Type> mobjComponentToSkinType;

		private static object mobjLockInstaceSkinCreation;

		private static object mobjLockSkinCreation;

		private static SkinDataStore mobjSkinDataStore;

		private static Z mobjSkinCache;

		private static SkinIncludeCollector mobjScriptIncludeCollector;

		private static SkinIncludeCollector mobjStyleSheetIncludeCollector;

		private static Dictionary<string, SkinCompiler> mobjCompilers;

		private static object mobjLockSkinCompilerCreation;

		private static int mintCallGetCount;

		private static double mdblCallGetTime;

		private static Dictionary<string, Type> mobjTypeByResourceNamespace;

		private static object mobjTypeByResourceNamespaceLock;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool TraceMode => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int CallGetCount => mintCallGetCount;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static double CallGetTime => mdblCallGetTime;

		internal static SkinDataStore DataStore => mobjSkinDataStore;

		internal static Z Cache => mobjSkinCache;

		internal static bool IsCodeRepairEnabled => false;

		internal static bool IsCompilerEnabled => true;

		static SkinFactory()
		{
			mobjComponentTypeSkin = null;
			mobjComponentTypeSkinLock = new object();
			mobjSkinInstances = null;
			mobjComponentToSkinType = null;
			mobjLockInstaceSkinCreation = null;
			mobjLockSkinCreation = null;
			mobjSkinDataStore = null;
			mobjSkinCache = null;
			mobjScriptIncludeCollector = new EB();
			mobjStyleSheetIncludeCollector = new FB();
			mobjCompilers = null;
			mobjLockSkinCompilerCreation = null;
			mintCallGetCount = 0;
			mdblCallGetTime = 0.0;
			mobjTypeByResourceNamespace = new Dictionary<string, Type>();
			mobjTypeByResourceNamespaceLock = new object();
			mobjComponentTypeSkin = new Dictionary<Type, Skin>();
			mobjSkinInstances = new Dictionary<Type, Skin>();
			mobjLockInstaceSkinCreation = new object();
			mobjLockSkinCreation = new object();
			mobjSkinDataStore = new SkinDataStore();
			mobjCompilers = new Dictionary<string, SkinCompiler>();
			mobjLockSkinCompilerCreation = new object();
			mobjSkinCache = new Z();
			mobjComponentToSkinType = new Dictionary<Type, Type>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResetTracing()
		{
			mintCallGetCount = 0;
			mdblCallGetTime = 0.0;
		}

		internal static void RegisterGetCall(long lngTime1, long lngTime2)
		{
			mintCallGetCount++;
			mdblCallGetTime += TimeSpan.FromTicks(lngTime2 - lngTime1).TotalMilliseconds;
		}

		internal static Type[] GetSkinDependentTypes(Type objSkinType)
		{
			List<Type> list = new List<Type>();
			if (!(objSkinType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object[] customAttributes = objSkinType.GetCustomAttributes(typeof(SkinDependencyAttribute), inherit: true);
				for (int i = 0; i < customAttributes.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (customAttributes[i] is SkinDependencyAttribute skinDependencyAttribute)
					{
						if (list.Contains(skinDependencyAttribute.SkinType))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(skinDependencyAttribute.SkinType);
						}
					}
				}
			}
			return list.ToArray();
		}

		public static Skin GetSkin(IContext objContext, Type objSkinType)
		{
			if (mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				InitializeResources(objContext);
			}
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
			}
			return mobjCompilers[objContext.CurrentTheme].GetSkin(objContext, objSkinType);
		}

		public static Skin GetSkin(ISkinable objSkinable)
		{
			try
			{
				Skin skin = null;
				if (objSkinable == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new ArgumentNullException("objInstance");
				}
				Type skinType = GetSkinType(objSkinable.GetType());
				if (!(skinType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new SkinResolvingException(objSkinable);
				}
				skin = (Skin)Activator.CreateInstance(skinType);
				skin?.SetOwner(objSkinable);
				return skin;
			}
			catch (Exception objInnerException)
			{
				throw new SkinException("Could not get skin for compoenent.", objInnerException);
			}
		}

		public static Skin GetSkin(ISkinable objSkinable, Type objSkinType)
		{
			return GetSkin(objSkinable, objSkinType, blnEnableSkinableFallback: false);
		}

		public static Skin GetSkin(ISkinable objSkinable, Type objSkinType, bool blnEnableSkinableFallback)
		{
			try
			{
				Skin skin = null;
				if (!(objSkinable != null || blnEnableSkinableFallback))
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new ArgumentNullException("objInstance");
				}
				if (objSkinable != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objSkinable = new DB();
				}
				if (!(objSkinType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new SkinResolvingException(objSkinable);
				}
				skin = (Skin)Activator.CreateInstance(objSkinType);
				if (skin == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					skin.SetOwner(objSkinable);
				}
				return skin;
			}
			catch (Exception objInnerException)
			{
				throw new SkinException("Could not get skin for compoenent.", objInnerException);
			}
		}

		internal static Type GetSkinType(Type objComponentType)
		{
			Type value = null;
			if (mobjComponentToSkinType.TryGetValue(objComponentType, out value))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = mobjComponentTypeSkinLock;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (mobjComponentToSkinType.TryGetValue(objComponentType, out value))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						object[] customAttributes = objComponentType.GetCustomAttributes(typeof(SkinAttribute), inherit: true);
						if (customAttributes.Length == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							value = ((SkinAttribute)customAttributes[0]).SkinType;
							mobjComponentToSkinType[objComponentType] = value;
						}
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
			return value;
		}

		public static Type GetTheme(string strThemeName)
		{
			Type value = null;
			if (strThemeName.Equals("Default"))
			{
				value = CommonUtils.DefaultThemeType;
			}
			else
			{
				ConfigHelper.ThemeTypes.TryGetValue(strThemeName, out value);
			}
			return value;
		}

		public static void InitializeResources(IContext objContext)
		{
			InitializeResources(objContext.CurrentTheme);
		}

		public static void InitializeResources(string strTheme)
		{
			if (mobjCompilers.ContainsKey(strTheme))
			{
				return;
			}
			lock (mobjLockSkinCompilerCreation)
			{
				if (mobjCompilers.ContainsKey(strTheme))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				SkinCompiler skinCompiler = new SkinCompiler();
				skinCompiler.Initialize(strTheme);
				mobjCompilers[strTheme] = skinCompiler;
			}
		}

		public static string GetSkinResourcePath(Type objSkinType, string strResourceName)
		{
			return $"Resources.{objSkinType.FullName}.{strResourceName}{ConfigHelper.DynamicExtension}";
		}

		public static string GetSkinResourceNameFromPath(string strResourcePath)
		{
			if (!string.IsNullOrEmpty(strResourcePath))
			{
				if (!strResourcePath.StartsWith("Resources."))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					strResourcePath = strResourcePath.Substring(10);
				}
				if (!strResourcePath.EndsWith(ConfigHelper.DynamicExtension))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					strResourcePath = strResourcePath.Substring(0, strResourcePath.Length - ConfigHelper.DynamicExtension.Length);
				}
			}
			return strResourcePath;
		}

		public static string[] GetSkinResourcesList(IContext objContext)
		{
			if (mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				InitializeResources(objContext);
			}
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
			}
			return mobjCompilers[objContext.CurrentTheme].GetSkinResourcesList();
		}

		public static void WriteSkinResource(IContext objContext, HostContext objHostContext, string strResourceName, NameValueCollection objArguments)
		{
			if (strResourceName.ToLowerInvariant() == "manifest")
			{
				WriteSkinManifest(objContext, objHostContext.Response, objArguments);
			}
			else if (!(strResourceName.ToLowerInvariant() == "includes.js"))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(strResourceName.ToLowerInvariant() == "includes.css"))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (mobjCompilers.ContainsKey(objContext.CurrentTheme))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						InitializeResources(objContext);
					}
					if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
					{
						/*OpCode not supported: LdMemberToken*/;
						throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
					}
					mobjCompilers[objContext.CurrentTheme].WriteSkinResource(objContext, objHostContext, strResourceName, objArguments);
				}
				else
				{
					mobjStyleSheetIncludeCollector.Write(objHostContext, objContext);
				}
			}
			else
			{
				mobjScriptIncludeCollector.Write(objHostContext, objContext);
			}
		}

		public static void WriteSkinResource(IContext objContext, Stream objOutputStream, string strResourceName, NameValueCollection objArguments)
		{
			if (!(strResourceName.ToLowerInvariant() == "manifest"))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(strResourceName.ToLowerInvariant() == "includes.js"))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strResourceName.ToLowerInvariant() == "includes.css")
					{
						mobjStyleSheetIncludeCollector.Write(objOutputStream, objContext);
						return;
					}
					if (mobjCompilers.ContainsKey(objContext.CurrentTheme))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						InitializeResources(objContext);
					}
					if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
					{
						/*OpCode not supported: LdMemberToken*/;
						throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
					}
					mobjCompilers[objContext.CurrentTheme].WriteSkinResource(objContext, objOutputStream, strResourceName, objArguments);
				}
				else
				{
					mobjScriptIncludeCollector.Write(objOutputStream, objContext);
				}
			}
			else
			{
				WriteSkinManifest(objContext, objOutputStream, objArguments);
			}
		}

		private static void WriteSkinManifest(IContext objContext, HostResponse objResponse, NameValueCollection objArguments)
		{
			objResponse.ContentType = "text/html";
			objResponse.Expires = -1;
			WriteSkinManifest(objContext, objResponse.OutputStream, objArguments);
		}

		private static void WriteSkinManifest(IContext objContext, Stream objOutputStream, NameValueCollection objArguments)
		{
			if (ConfigHelper.HideResourcesPane)
			{
				return;
			}
			if (!string.IsNullOrEmpty(objArguments["view"]))
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = objArguments["theme"];
				if (mobjCompilers.ContainsKey(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					InitializeResources(text);
				}
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				SkinCompiler skinCompiler = mobjCompilers[text];
				if (skinCompiler == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					skinCompiler.WriteSkinManifestView(objContext, objOutputStream, objArguments);
				}
				return;
			}
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StreamWriter(objOutputStream, Encoding.UTF8));
			SkinCompiler.WriteSkinManifestHeader(htmlTextWriter, "Themes");
			List<string> list = new List<string>(ConfigHelper.Themes);
			if (!list.Contains("Default"))
			{
				list.Add("Default");
			}
			using (List<string>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					string current = enumerator.Current;
					htmlTextWriter.WriteFullBeginTag("table");
					htmlTextWriter.WriteFullBeginTag("tr");
					htmlTextWriter.WriteBeginTag("td");
					htmlTextWriter.WriteAttribute("colspan", "7");
					htmlTextWriter.Write(">Theme:");
					SkinCompiler.WriteSkinManifestViewLink(htmlTextWriter, current, "collectors", current, null, null);
					htmlTextWriter.Write(" (");
					SkinCompiler.WriteSkinManifestViewLink(htmlTextWriter, "Scopes", "scopes", current, null, null);
					htmlTextWriter.Write(")");
					htmlTextWriter.WriteEndTag("td");
					htmlTextWriter.WriteEndTag("tr");
					htmlTextWriter.Write("\n");
					htmlTextWriter.WriteEndTag("table");
					htmlTextWriter.Write("\n");
				}
			}
			SkinCompiler.WriteSkinManifestFooter(htmlTextWriter);
			htmlTextWriter.Flush();
		}

		public static string GetSkinMethod(IContext objContext, ISkinable objComponent, string strMember)
		{
			if (mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				InitializeResources(objContext);
			}
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
			}
			return mobjCompilers[objContext.CurrentTheme].GetSkinMethodName(objContext, objComponent, strMember);
		}

		public static string GetSkinMethodName(IContext objContext, Type objSkinType, string strMember)
		{
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				InitializeResources(objContext);
			}
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
			}
			return mobjCompilers[objContext.CurrentTheme].GetSkinMethodName(objContext, objSkinType, strMember);
		}

		public static string GetSkinClassName(IContext objContext, IRegisteredComponent objComponent, string strMember)
		{
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				InitializeResources(objContext);
			}
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
			}
			return mobjCompilers[objContext.CurrentTheme].GetSkinClassName(objContext, objComponent, strMember);
		}

		public static string GetSkinClassName(IContext objContext, Type objSkinType, string strMember)
		{
			if (mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				InitializeResources(objContext);
			}
			if (!mobjCompilers.ContainsKey(objContext.CurrentTheme))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new SkinException($"Could not create compiler for '{objContext.CurrentTheme}' theme", null);
			}
			return mobjCompilers[objContext.CurrentTheme].GetSkinClassName(objContext, objSkinType, strMember);
		}

		internal static string GetRoleResourceName(PresentationRole enmRole)
		{
			switch (enmRole)
			{
			case PresentationRole.BrowserCode:
			case PresentationRole.BrowserStyle:
			case PresentationRole.BrowserTemplate:
				return "Browser.Form";
			default:
				return enmRole.ToString();
			}
		}

		public static Type GetType(string strName)
		{
			return GetType(strName, blnIsResources: false);
		}

		internal static string GetTypeName(string name, bool blnIsResources)
		{
			if (string.IsNullOrEmpty(name))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (name.IndexOf(".") == -1)
			{
				if (!blnIsResources)
				{
					/*OpCode not supported: LdMemberToken*/;
					return GetFullCommonType($"Gizmox.WebGUI.Forms.Skins.{name}");
				}
				return GetFullCommonType($"Gizmox.WebGUI.Forms.Skins.Resources.{name}");
			}
			return name;
		}

		internal static string GetFullCommonType(string strTypeName)
		{
			return $"{strTypeName}, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		internal static Type GetType(string strName, bool blnIsResources)
		{
			string typeName = GetTypeName(strName, blnIsResources);
			if (string.IsNullOrEmpty(typeName))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return Type.GetType(typeName, throwOnError: false);
		}

		internal static Type GetSkinTypeByResourceNamespace(string strResourceNamespace)
		{
			if (string.IsNullOrEmpty(strResourceNamespace))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjTypeByResourceNamespace.ContainsKey(strResourceNamespace))
				{
					return mobjTypeByResourceNamespace[strResourceNamespace];
				}
				/*OpCode not supported: LdMemberToken*/;
				object obj = mobjTypeByResourceNamespaceLock;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (mobjTypeByResourceNamespace.ContainsKey(strResourceNamespace))
					{
						return mobjTypeByResourceNamespace[strResourceNamespace];
					}
					/*OpCode not supported: LdMemberToken*/;
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					for (int i = 0; i < assemblies.Length; i++)
					{
						/*OpCode not supported: LdMemberToken*/;
						Type type = assemblies[i].GetType(strResourceNamespace, throwOnError: false);
						if (type != null)
						{
							mobjTypeByResourceNamespace[strResourceNamespace] = type;
							return type;
						}
					}
					mobjTypeByResourceNamespace[strResourceNamespace] = null;
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
			return null;
		}
	}
}
