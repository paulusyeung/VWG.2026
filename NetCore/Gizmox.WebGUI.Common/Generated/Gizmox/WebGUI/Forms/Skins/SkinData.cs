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
	internal class SkinData : Dictionary<string, SkinResource>
	{
		private SkinData mobjSkinContainerData;

		private SkinData mobjInheritedSkinData;

		private Type mobjSkinType;

		private Type mobjSkinContainerType;

		private Type mobjInheritedSkinType;

		private SkinDataStore mobjSkinDataCache;

		public Type ContainerType => mobjSkinContainerType;

		public SkinData ContainerData
		{
			get
			{
				if (!(mobjSkinContainerType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mobjSkinContainerData == null)
				{
					mobjSkinContainerData = mobjSkinDataCache.GetData(mobjSkinContainerType);
				}
				return mobjSkinContainerData;
			}
		}

		public Type InheritedType => mobjInheritedSkinType;

		public SkinData InheritedData
		{
			get
			{
				if (!(mobjInheritedSkinType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mobjInheritedSkinData == null)
				{
					mobjInheritedSkinData = mobjSkinDataCache.GetData(mobjInheritedSkinType);
				}
				return mobjInheritedSkinData;
			}
		}

		internal Type SkinType => mobjSkinType;

		internal SkinData(SkinDataStore objSkinDataCache, Type objSkinType)
			: this(objSkinDataCache, objSkinType, blnIsThemeData: false)
		{
		}

		protected SkinData(SkinDataStore objSkinDataCache, Type objSkinType, bool blnIsThemeData)
			: base((IEqualityComparer<string>)StringComparer.CurrentCultureIgnoreCase)
		{
			mobjSkinDataCache = objSkinDataCache;
			mobjSkinType = objSkinType;
			if (!IsValidBaseType(objSkinType.BaseType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjInheritedSkinType = objSkinType.BaseType;
			}
			if (!blnIsThemeData)
			{
				mobjSkinContainerType = GetSkinContainerType(objSkinType);
			}
		}

		private Type GetSkinContainerType(Type objSkinType)
		{
			object[] customAttributes = objSkinType.GetCustomAttributes(typeof(SkinContainerAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (customAttributes[0] is SkinContainerAttribute skinContainerAttribute)
			{
				return skinContainerAttribute.SkinType;
			}
			return null;
		}

		private bool IsValidBaseType(Type objBaseType)
		{
			if (objBaseType != typeof(Theme))
			{
				if (objBaseType != typeof(object))
				{
					return objBaseType != typeof(Skin);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private string GetThemeKey(Type objSkinType, string strResource)
		{
			return $"{objSkinType.FullName}:{strResource}";
		}

		private string GetThemeKey(Skin objSkin, string strResource)
		{
			return GetThemeKey(objSkin.GetType(), strResource);
		}

		private string GetThemePrefix(Type objSkinType)
		{
			return $"{objSkinType.FullName}:";
		}

		private string GetThemePrefix(Skin objSkin)
		{
			return GetThemePrefix(objSkin.GetType());
		}

		public void SetValue(SkinComponent objSkinComponent, string strResource, object objValue)
		{
			if (!objSkinComponent.DesignModeInternal)
			{
				return;
			}
			SkinResource skinResource = objValue as SkinResource;
			if (skinResource == null)
			{
				if (objValue == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					skinResource = new ValueResource<object>(objValue);
				}
				else
				{
					Type type = typeof(ValueResource<>).MakeGenericType(objValue.GetType());
					if (!(type != null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						skinResource = Activator.CreateInstance(type, objValue) as SkinResource;
					}
				}
			}
			if (skinResource != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(objSkinComponent is Skin skin))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (skin.Owner != null)
					{
						if (!(skin.Owner is Theme theme))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							theme.Data[GetThemeKey(skin.GetType(), strResource)] = skinResource;
						}
						return;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				base[strResource] = skinResource;
				return;
			}
			throw new SkinException("Could convert setted value to skin resource.");
		}

		public void RemoveValue(Skin objSkin, string strResource)
		{
			if (!objSkin.DesignModeInternal)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objSkin.Owner == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				Remove(strResource);
			}
			else if (!(objSkin.Owner is Theme theme))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				theme.Data.Remove(GetThemeKey(objSkin.GetType(), strResource));
			}
		}

		internal SkinResource GetResource(Type objSkinType, SkinData objThemeData, string strKey)
		{
			SkinResource value = GetThemeResource(objSkinType, objThemeData, strKey);
			if (value != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				TryGetValue(strKey, out value);
			}
			return value;
		}

		private SkinResource GetThemeResource(Type objSkinType, SkinData objThemeData, string strKey)
		{
			SkinResource value = null;
			if (objThemeData == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string themeKey = GetThemeKey(objSkinType, strKey);
				objThemeData.TryGetValue(themeKey, out value);
				if (value != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					SkinData inheritedData = objThemeData.InheritedData;
					if (inheritedData == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						value = GetThemeResource(objSkinType, inheritedData, strKey);
					}
				}
			}
			return value;
		}

		public bool HasValue(Skin objSkin, string strKey, CB enmSearchType)
		{
			return GetResource(objSkin, strKey, enmSearchType) != null;
		}

		public SkinResource GetResource(Skin objSkin, string strKey, CB enmSearchType)
		{
			return GetResource(objSkin.GetType(), objSkin.ThemeData, strKey, enmSearchType);
		}

		public SkinResource GetResource(Type objSkinType, SkinData objThemeData, string strKey, CB enmSearchType)
		{
			SkinResource resource = GetResource(objSkinType, objThemeData, strKey);
			if (resource != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (enmSearchType != CB.B)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (enmSearchType == CB.A)
				{
					if (ContainerData == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (InheritedData == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							resource = InheritedData.GetResource(InheritedType, objThemeData, strKey, enmSearchType);
						}
					}
					else
					{
						resource = ContainerData.GetResource(ContainerType, objThemeData, strKey, enmSearchType);
					}
				}
			}
			else
			{
				if (InheritedData != null)
				{
					return InheritedData.GetResource(InheritedType, objThemeData, strKey, enmSearchType);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return resource;
		}

		internal string GetResourceName(Skin objSkin, SkinResource objSkinResource)
		{
			string text = string.Empty;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, SkinResource> current = enumerator.Current;
					if (current.Value != objSkinResource)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text = current.Key;
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SkinData inheritedData = InheritedData;
				if (inheritedData == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text = inheritedData.GetResourceName(objSkin, objSkinResource);
				}
				if (!string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Y themeData = objSkin.ThemeData;
					if (themeData != null)
					{
						text = GetResourceNameByThemeData(objSkin, objSkinResource, themeData);
					}
				}
			}
			return text;
		}

		private string GetResourceNameByThemeData(Skin objSkin, SkinResource objSkinResource, SkinData objThemeData)
		{
			string text = string.Empty;
			string themePrefix = GetThemePrefix(objSkin);
			using (Enumerator enumerator = objThemeData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					KeyValuePair<string, SkinResource> current = enumerator.Current;
					if (current.Value != objSkinResource)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!current.Key.StartsWith(themePrefix))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text = current.Key.Substring(themePrefix.Length);
					}
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				SkinData inheritedData = objThemeData.InheritedData;
				if (inheritedData == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text = GetResourceNameByThemeData(objSkin, objSkinResource, inheritedData);
				}
			}
			return text;
		}

		internal void SetResourceName(Skin objSkin, SkinResource objSkinResource, string strName)
		{
			if (!objSkin.DesignModeInternal)
			{
				return;
			}
			string resourceName = GetResourceName(objSkin, objSkinResource);
			if (objSkin.Owner == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (ContainsKey(strName))
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new ArgumentException("The resource name already exists.", "strName");
				}
				if (string.IsNullOrEmpty(resourceName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Remove(resourceName);
				}
				Add(strName, objSkinResource);
				return;
			}
			if (!ContainsKey(resourceName))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (ContainsKey(strName))
				{
					throw new Exception("The skin already contains a resource with that name (override it if you want to change that resource).");
				}
				if (!(objSkin.Owner is Theme theme))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				string themeKey = GetThemeKey(objSkin, resourceName);
				string themeKey2 = GetThemeKey(objSkin, strName);
				if (!theme.Data.ContainsKey(themeKey2))
				{
					if (string.IsNullOrEmpty(themeKey))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						theme.Data.Remove(themeKey);
					}
					theme.Data.Add(themeKey2, objSkinResource);
					return;
				}
				throw new ArgumentException("The resource name already exists.", "strName");
			}
			throw new Exception("Cannot rename an inherited resource.");
		}

		internal bool RemoveResource(Skin objSkin, SkinResource objSkinResource)
		{
			string resourceName = GetResourceName(objSkin, objSkinResource);
			if (string.IsNullOrEmpty(resourceName))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SkinData themeData = objSkin.ThemeData;
				if (themeData == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (ContainsKey(resourceName))
					{
						Remove(resourceName);
						return true;
					}
				}
				else
				{
					string themeKey = GetThemeKey(objSkin, resourceName);
					if (themeData.ContainsKey(themeKey))
					{
						themeData.Remove(themeKey);
						return true;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return false;
		}
	}
}
