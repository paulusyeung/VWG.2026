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

namespace Gizmox.WebGUI.Virtualization.Win32
{
	[Serializable]
	public static class VirtualRegistry
	{
		internal static readonly Guid KeyTypeId = new Guid("a3758688-0dca-46cf-a028-1c544196ec48");

		internal static readonly Guid ValueTypeId = new Guid("b443490f-0435-4eb0-99ff-3886f0e74d4a");

		public static VirtualRegistryKey ClassesRoot => GetRegistryKey("HKEY_CLASSES_ROOT");

		public static VirtualRegistryKey CurrentConfig => GetRegistryKey("HKEY_CURRENT_CONFIG");

		public static VirtualRegistryKey CurrentUser => GetRegistryKey($"HKEY_USERS\\{VirtualUser.Current.Username}");

		public static VirtualRegistryKey DynData => GetRegistryKey("HKEY_DYN_DATA");

		public static VirtualRegistryKey LocalMachine => GetRegistryKey("HKEY_LOCAL_MACHINE");

		public static VirtualRegistryKey PerformanceData => GetRegistryKey("HKEY_PERFORMANCE_DATA");

		public static VirtualRegistryKey Users => GetRegistryKey("HKEY_USERS");

		public static object GetValue(string keyName, string valueName)
		{
			return GetValue(keyName, valueName, null, VirtualRegistryValueOptions.None);
		}

		public static object GetValue(string keyName, string valueName, object defaultValue)
		{
			return GetValue(keyName, valueName, defaultValue, VirtualRegistryValueOptions.None);
		}

		internal static object GetValue(string keyName, string valueName, object defaultValue, VirtualRegistryValueOptions options)
		{
			VirtualNode virtualNode = F.Current.Read(new VirtualReference(VirtualForest.Default.Id, keyName, KeyTypeId, valueName, ValueTypeId));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object typedValue = GetTypedValue(virtualNode);
				if (typedValue != null)
				{
					return typedValue;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return defaultValue;
		}

		internal static VirtualRegistryValueKind GetValueKind(VirtualRegistryKey registryKey, string name)
		{
			return VirtualRegistryValueKind.String;
		}

		private static object GetTypedValue(VirtualNode objVirtualNode)
		{
			return objVirtualNode.DataValue;
		}

		public static void SetValue(string keyName, string valueName, object value)
		{
			F.Current.Update(new VirtualReference(VirtualForest.Default.Id, keyName, KeyTypeId, valueName, ValueTypeId), GetDataId(value), GetDataValue(value), GetDataContent(value));
		}

		private static byte[] GetDataContent(object value)
		{
			return null;
		}

		private static Guid GetDataId(object value)
		{
			return Guid.Empty;
		}

		private static string GetDataValue(object value)
		{
			return (string)value;
		}

		public static void SetValue(string keyName, string valueName, object value, VirtualRegistryValueKind valueKind)
		{
			F.Current.Update(new VirtualReference(VirtualForest.Default.Id, keyName, KeyTypeId, valueName, ValueTypeId), GetDataId(value), GetDataValue(value), GetDataContent(value));
		}

		internal static void SetValue(VirtualRegistryKey objKey, string valueName, object value, VirtualRegistryValueKind valueKind)
		{
			F.Current.Update(new VirtualReference(objKey.VirtualNode, string.Empty, KeyTypeId, valueName, ValueTypeId), GetDataId(value), GetDataValue(value), GetDataContent(value));
		}

		internal static void SetValue(VirtualRegistryKey objKey, string valueName, object value)
		{
			F.Current.Update(new VirtualReference(objKey.VirtualNode, string.Empty, KeyTypeId, valueName, ValueTypeId), GetDataId(value), GetDataValue(value), GetDataContent(value));
		}

		internal static VirtualRegistryKey GetRegistryKey(string strPath)
		{
			return VirtualRegistryKey.Create(F.Current.Read(new VirtualReference(VirtualForest.Default.Id, strPath, KeyTypeId)));
		}

		internal static VirtualRegistryKey GetRegistryKey(string strPath, string strName)
		{
			return VirtualRegistryKey.Create(F.Current.Read(new VirtualReference(VirtualForest.Default.Id, strPath, KeyTypeId, strName, ValueTypeId)));
		}

		internal static VirtualRegistryKey GetRegistryKey(VirtualNode objRoot, string strPath, string strName)
		{
			VirtualRegistryKey result = null;
			VirtualNode virtualNode = F.Current.Read(new VirtualReference(objRoot, strPath, KeyTypeId, strName, ValueTypeId));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = VirtualRegistryKey.Create(virtualNode);
			}
			return result;
		}

		internal static object GetValue(VirtualRegistryKey objKey, string valueName)
		{
			VirtualNode virtualNode = F.Current.Read(new VirtualReference(objKey.VirtualNode, "", KeyTypeId, valueName, ValueTypeId));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return GetTypedValue(virtualNode);
		}

		internal static object GetValue(VirtualRegistryKey objKey, string valueName, object defaultValue)
		{
			VirtualNode virtualNode = F.Current.Read(new VirtualReference(objKey.VirtualNode, "", KeyTypeId, valueName, ValueTypeId));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object typedValue = GetTypedValue(virtualNode);
				if (typedValue != null)
				{
					return typedValue;
				}
			}
			return defaultValue;
		}

		internal static object GetValue(VirtualRegistryKey objKey, string valueName, object defaultValue, VirtualRegistryValueOptions options)
		{
			VirtualNode virtualNode = F.Current.Read(new VirtualReference(objKey.VirtualNode, "", KeyTypeId, valueName, ValueTypeId));
			if (virtualNode != null)
			{
				object typedValue = GetTypedValue(virtualNode);
				if (typedValue != null)
				{
					return typedValue;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return defaultValue;
		}

		internal static string[] GetSubKeyNames(VirtualRegistryKey registryKey)
		{
			return F.Current.ReadNameList(new VirtualReference(registryKey.VirtualNode), KeyTypeId, Guid.Empty);
		}

		internal static string[] GetValueNames(VirtualRegistryKey registryKey)
		{
			return F.Current.ReadNameList(new VirtualReference(registryKey.VirtualNode), ValueTypeId, Guid.Empty);
		}

		internal static VirtualRegistryKey OpenSubKey(VirtualRegistryKey registryKey, string name)
		{
			return GetRegistryKey(registryKey.VirtualNode, name, "");
		}

		internal static int GetSubKeyCount(VirtualRegistryKey registryKey)
		{
			return F.Current.GetListCount(new VirtualReference(registryKey.VirtualNode), KeyTypeId, Guid.Empty);
		}

		internal static int GetValueCount(VirtualRegistryKey registryKey)
		{
			return F.Current.GetListCount(new VirtualReference(registryKey.VirtualNode), ValueTypeId, Guid.Empty);
		}

		internal static VirtualRegistryKey OpenSubKey(VirtualRegistryKey registryKey, string name, VirtualRegistryKeyPermissionCheck permissionCheck)
		{
			return GetRegistryKey(registryKey.VirtualNode, name, "");
		}

		internal static VirtualRegistryKey OpenSubKey(VirtualRegistryKey registryKey, string name, bool writable)
		{
			return GetRegistryKey(registryKey.VirtualNode, name, "");
		}

		internal static VirtualRegistryKey OpenSubKey(VirtualRegistryKey registryKey, string name, VirtualRegistryKeyPermissionCheck permissionCheck, RegistryRights rights)
		{
			return GetRegistryKey(registryKey.VirtualNode, name, "");
		}

		internal static VirtualRegistryKey OpenRemoteBaseKey(VirtualRegistryHive hKey, string machineName)
		{
			throw new NotImplementedException();
		}

		internal static void DeleteSubKeyTree(VirtualRegistryKey registryKey, string subkey)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void DeleteValue(VirtualRegistryKey registryKey, string name)
		{
			F.Current.Delete(new VirtualReference(registryKey.VirtualNode, string.Empty, KeyTypeId, name, ValueTypeId));
		}

		internal static void DeleteValue(VirtualRegistryKey registryKey, string name, bool throwOnMissingValue)
		{
			F.Current.Delete(new VirtualReference(registryKey.VirtualNode, string.Empty, KeyTypeId, name, ValueTypeId));
		}

		internal static void DeleteSubKey(VirtualRegistryKey registryKey, string subkey, bool throwOnMissingSubKey)
		{
			F.Current.Delete(new VirtualReference(registryKey.VirtualNode, subkey, KeyTypeId));
		}

		internal static void DeleteSubKey(VirtualRegistryKey registryKey, string subkey)
		{
			F.Current.Delete(new VirtualReference(registryKey.VirtualNode, subkey, KeyTypeId));
		}

		internal static VirtualRegistryKey CreateSubKey(VirtualRegistryKey registryKey, string subkey, VirtualRegistryKeyPermissionCheck permissionCheck, RegistrySecurity registrySecurity)
		{
			VirtualNode virtualNode = F.Current.Create(new VirtualReference(registryKey.VirtualNode), subkey, KeyTypeId, Guid.Empty, string.Empty, new byte[0]);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return VirtualRegistryKey.Create(virtualNode);
		}

		internal static VirtualRegistryKey CreateSubKey(VirtualRegistryKey registryKey, string subkey, VirtualRegistryKeyPermissionCheck permissionCheck)
		{
			VirtualNode virtualNode = F.Current.Create(new VirtualReference(registryKey.VirtualNode), subkey, KeyTypeId, Guid.Empty, string.Empty, new byte[0]);
			if (virtualNode != null)
			{
				return VirtualRegistryKey.Create(virtualNode);
			}
			return null;
		}

		internal static VirtualRegistryKey CreateSubKey(VirtualRegistryKey registryKey, string subkey)
		{
			return CreateSubKey(new VirtualReference(registryKey.VirtualNode), subkey);
		}

		internal static VirtualRegistryKey CreateSubKey(VirtualReference registryKeyReference, string subkey)
		{
			VirtualNode virtualNode = F.Current.Create(registryKeyReference, subkey, KeyTypeId, Guid.Empty, string.Empty, new byte[0]);
			if (virtualNode != null)
			{
				return VirtualRegistryKey.Create(virtualNode);
			}
			return null;
		}

		internal static RegistrySecurity GetAccessControl(VirtualRegistryKey registryKey)
		{
			throw new NotImplementedException();
		}

		internal static RegistrySecurity GetAccessControl(VirtualRegistryKey registryKey, AccessControlSections includeSections)
		{
			throw new NotImplementedException();
		}

		internal static void SetAccessControl(VirtualRegistryKey registryKey, RegistrySecurity registrySecurity)
		{
			throw new NotImplementedException();
		}

		internal static VirtualRegistryKey[] GetSubKeys(VirtualRegistryKey registryKey)
		{
			List<VirtualRegistryKey> list = new List<VirtualRegistryKey>();
			VirtualNode[] array = F.Current.ReadList(new VirtualReference(registryKey.VirtualNode), KeyTypeId, Guid.Empty);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode objVirtualNode = array2[i];
					list.Add(VirtualRegistryKey.Create(objVirtualNode));
				}
			}
			return list.ToArray();
		}

		internal static VirtualRegistryValue[] GetSubValues(VirtualRegistryKey registryKey)
		{
			List<VirtualRegistryValue> list = new List<VirtualRegistryValue>();
			VirtualNode[] array = F.Current.ReadList(new VirtualReference(registryKey.VirtualNode), KeyTypeId, Guid.Empty);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode objVirtualNode = array2[i];
					list.Add(VirtualRegistryValue.Create(objVirtualNode));
				}
			}
			return list.ToArray();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ImportFromFile(string strRegistryDumpPath)
		{
			if (!File.Exists(strRegistryDumpPath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Import(new StreamReader(File.OpenRead(strRegistryDumpPath)));
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Import(string strRegistryDump)
		{
			Import(new StringReader(strRegistryDump));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Import(TextReader objRegistryDump)
		{
			RegTokenReader regTokenReader = new RegTokenReader(null, objRegistryDump);
			Token token = null;
			string text = null;
			string text2 = null;
			VirtualRegistryKey virtualRegistryKey = null;
			while ((token = regTokenReader.Read()) != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (token.Type != TokenType.RegPath)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (text == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (virtualRegistryKey == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (token.Type == TokenType.RegName)
					{
						text2 = token.Content;
					}
					else if (text2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (token.Type == TokenType.RegValue)
					{
						CreateKeyValue(virtualRegistryKey, GetImportedValueName(text2), GetImportedValue(token.Content));
					}
				}
				else
				{
					text = token.Content.Trim('[', ']');
					virtualRegistryKey = CreateKeyPath(text);
				}
			}
		}

		private static void CreateKeyValue(VirtualRegistryKey objParentKey, string strCurrentValueName, string strCurrentValue)
		{
			objParentKey.SetValue(strCurrentValueName, strCurrentValue);
		}

		private static VirtualRegistryKey CreateKeyPath(string strCurrentKeyPath)
		{
			return CreateKeyPath(null, strCurrentKeyPath.Split('\\'), 0);
		}

		private static VirtualRegistryKey CreateKeyPath(VirtualRegistryKey objParentKey, string[] arrCurrentKeyPath, int intCurrentIndex)
		{
			VirtualRegistryKey virtualRegistryKey = CreateKeySubKeyOrRootKey(objParentKey, arrCurrentKeyPath[intCurrentIndex]);
			if (virtualRegistryKey != null)
			{
				if (arrCurrentKeyPath.Length <= intCurrentIndex + 1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					virtualRegistryKey = CreateKeyPath(virtualRegistryKey, arrCurrentKeyPath, intCurrentIndex + 1);
				}
			}
			return virtualRegistryKey;
		}

		private static VirtualRegistryKey CreateKeySubKeyOrRootKey(VirtualRegistryKey objParentKey, string strSubKeyName)
		{
			VirtualReference virtualReference = null;
			if (objParentKey == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				virtualReference = VirtualReference.DefaultRoot;
			}
			else
			{
				virtualReference = new VirtualReference(objParentKey.VirtualNode);
			}
			return CreateSubKey(virtualReference, strSubKeyName);
		}

		private static string GetImportedValue(string strCurrentValue)
		{
			return strCurrentValue.Trim('"');
		}

		private static string GetImportedValueName(string strCurrentValueName)
		{
			return strCurrentValueName.Trim('"');
		}
	}
}
