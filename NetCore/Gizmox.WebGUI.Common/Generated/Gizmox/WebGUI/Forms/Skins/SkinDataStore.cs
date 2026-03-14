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
	public class SkinDataStore
	{
		private Dictionary<Type, SkinData> mobjSkinDataCache;

		private Dictionary<Type, System.Resources.ResourceManager> mobjSkinResourceCache;

		private object mobjSkinResourceCacheLock;

		private object mobjSkinDataCacheLock;

		private IServiceProvider mobjServiceProvider;

		private Type mobjDesignedType;

		public SkinDataStore(IServiceProvider objServiceProvider, Type objDesignedType)
			: this()
		{
			mobjServiceProvider = objServiceProvider;
			mobjDesignedType = objDesignedType;
		}

		public SkinDataStore()
		{
			mobjSkinDataCache = new Dictionary<Type, SkinData>();
			mobjSkinDataCacheLock = new object();
			mobjSkinResourceCache = new Dictionary<Type, System.Resources.ResourceManager>();
			mobjSkinResourceCacheLock = new object();
		}

		internal SkinData GetData(Skin objSkinInstance)
		{
			if (objSkinInstance == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return GetData(objSkinInstance.SkinType);
		}

		internal SkinData GetData(Theme objThemeInstance)
		{
			if (objThemeInstance == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return GetData(objThemeInstance.ThemeType);
		}

		internal SkinData GetData(Type objType)
		{
			SkinData result = null;
			if (mobjSkinDataCache.ContainsKey(objType))
			{
				/*OpCode not supported: LdMemberToken*/;
				result = mobjSkinDataCache[objType];
			}
			else
			{
				lock (mobjSkinDataCacheLock)
				{
					result = (mobjSkinDataCache.ContainsKey(objType) ? mobjSkinDataCache[objType] : (mobjSkinDataCache[objType] = CreateData(objType)));
				}
			}
			return result;
		}

		internal Stream GetResourceContent(Type objSkinType, string mstrResource)
		{
			System.Resources.ResourceManager resourceManager = GetResourceManager(objSkinType);
			if (resourceManager == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return resourceManager.GetObject(mstrResource, CultureInfo.InvariantCulture) as Stream;
		}

		private System.Resources.ResourceManager GetResourceManager(Type objSkinType)
		{
			System.Resources.ResourceManager result = null;
			if (!mobjSkinResourceCache.ContainsKey(objSkinType))
			{
				/*OpCode not supported: LdMemberToken*/;
				object obj = mobjSkinResourceCacheLock;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (mobjSkinResourceCache.ContainsKey(objSkinType))
					{
						result = mobjSkinResourceCache[objSkinType];
					}
					else
					{
						result = (mobjSkinResourceCache[objSkinType] = new System.Resources.ResourceManager(objSkinType));
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
			else
			{
				result = mobjSkinResourceCache[objSkinType];
			}
			return result;
		}

		private SkinData CreateData(Type objSkinType)
		{
			IEnumerable enumerable = null;
			if (mobjServiceProvider == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(mobjDesignedType == objSkinType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IResourceService resourceService = (IResourceService)mobjServiceProvider.GetService(typeof(IResourceService));
				if (resourceService == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					enumerable = resourceService.GetResourceReader(CultureInfo.InvariantCulture);
				}
			}
			if (enumerable != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				System.Resources.ResourceManager resourceManager = GetResourceManager(objSkinType);
				if (resourceManager != null)
				{
					enumerable = GetSafeResourceSet(resourceManager);
				}
			}
			bool flag = typeof(Theme).IsAssignableFrom(objSkinType);
			if (enumerable == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!flag)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new SkinData(this, objSkinType);
				}
				return new Y(this, objSkinType);
			}
			return LoadData(objSkinType, enumerable, flag);
		}

		private static IEnumerable GetSafeResourceSet(System.Resources.ResourceManager objResourceManager)
		{
			try
			{
				return objResourceManager.GetResourceSet(CultureInfo.InvariantCulture, createIfNotExists: true, tryParents: false);
			}
			catch (MissingManifestResourceException ex)
			{
				if (!CommonUtils.IsMono)
				{
					throw;
				}
			}
			return null;
		}

		private SkinData LoadData(Type objSkinType, IEnumerable objResources, bool blnIsTheme)
		{
			SkinData skinData = null;
			if (!blnIsTheme)
			{
				/*OpCode not supported: LdMemberToken*/;
				skinData = new SkinData(this, objSkinType);
			}
			else
			{
				skinData = new Y(this, objSkinType);
			}
			if (objResources == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				List<DictionaryEntry> list = new List<DictionaryEntry>();
				IEnumerator enumerator = objResources.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						DictionaryEntry item = (DictionaryEntry)enumerator.Current;
						string text = item.Key as string;
						if (string.IsNullOrEmpty(text))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						string[] array = text.Split(':');
						if (array.Length == 3)
						{
							if (!(array[0] == "Skin"))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (!(array[1] == objSkinType.FullName || blnIsTheme))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							string text2 = item.Value as string;
							if (string.IsNullOrEmpty(text2))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							Type skinResourceType = GetSkinResourceType(text2);
							if (!(skinResourceType != null))
							{
								/*OpCode not supported: LdMemberToken*/;
								throw new SkinException($"Could not resolve skin resource of type '{text2}'.");
							}
							if (!(Activator.CreateInstance(skinResourceType) is SkinResource value))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								skinData[GetSkinResourceName(array, blnIsTheme)] = value;
							}
						}
						else if (array.Length == 4)
						{
							list.Add(item);
						}
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						disposable.Dispose();
					}
				}
				using List<DictionaryEntry>.Enumerator enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					DictionaryEntry current = enumerator2.Current;
					string text3 = current.Key as string;
					if (string.IsNullOrEmpty(text3))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string[] array2 = text3.Split(':');
					if (array2.Length != 4)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (!(array2[0] == "Skin"))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (!(array2[1] == objSkinType.FullName || blnIsTheme))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string skinResourceName = GetSkinResourceName(array2, blnIsTheme);
					if (!skinData.ContainsKey(skinResourceName))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string skinResourceName2 = GetSkinResourceName(array2, blnIsTheme);
					SkinResource skinResource = skinData[skinResourceName2];
					if (skinResource == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					PropertyInfo property = skinResource.GetType().GetProperty(array2[3]);
					if (!(property != null))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (!property.CanWrite)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (!(property.Name == "Content"))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (mobjServiceProvider == null)
					{
						property.SetValue(skinResource, new FileResourceContentReference(this, objSkinType, text3), new object[0]);
						continue;
					}
					object value2 = current.Value;
					if (value2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						property.SetValue(skinResource, null, new object[0]);
						continue;
					}
					if (property.PropertyType == value2.GetType())
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!(property.PropertyType == typeof(object)))
					{
						TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
						if (converter == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!converter.CanConvertFrom(value2.GetType()))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							property.SetValue(skinResource, converter.ConvertFrom(null, CultureInfo.InvariantCulture, value2), new object[0]);
						}
						continue;
					}
					property.SetValue(skinResource, value2, new object[0]);
				}
			}
			return skinData;
		}

		private static Type GetSkinResourceType(string strResourceType)
		{
			if (!IsValueResource(strResourceType))
			{
				/*OpCode not supported: LdMemberToken*/;
				return Type.GetType($"Gizmox.WebGUI.Forms.Skins.Resources.{strResourceType}, Gizmox.WebGUI.Common", throwOnError: false);
			}
			string[] array = strResourceType.Split(':');
			if (array.Length <= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				return Type.GetType("Gizmox.WebGUI.Forms.Skins.Resources.ValueResource`1[System.Object], Gizmox.WebGUI.Common", throwOnError: false);
			}
			Type skinValueResourceType = GetSkinValueResourceType(array[1]);
			if (!(skinValueResourceType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return typeof(ValueResource<>).MakeGenericType(skinValueResourceType);
		}

		private static Type GetSkinValueResourceType(string strValueResourceType)
		{
			Type type = null;
			string[] array = strValueResourceType.Split(',');
			if (array.Length <= 2)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				type = Type.GetType(strValueResourceType, throwOnError: false);
			}
			if (type == null)
			{
				if (array.Length <= 1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					type = Type.GetType($"{array[0]}, {CommonUtils.GetFullAssemblyName(array[1].Trim())}", throwOnError: false);
				}
			}
			return type;
		}

		private static bool IsValueResource(string strResourceType)
		{
			return strResourceType?.StartsWith("ValueResource") ?? false;
		}

		private string GetSkinResourceName(string[] arrDictionaryKey, bool blnIsTheme)
		{
			if (blnIsTheme)
			{
				/*OpCode not supported: LdMemberToken*/;
				return $"{arrDictionaryKey[1]}:{arrDictionaryKey[2]}";
			}
			return arrDictionaryKey[2];
		}
	}
}
