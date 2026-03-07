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
	public sealed class VirtualRegistryKey : IDisposable
	{
		private VirtualNode mobjVirtualNode;

		public string Name => mobjVirtualNode.Name;

		public int SubKeyCount => VirtualRegistry.GetSubKeyCount(this);

		public int ValueCount => VirtualRegistry.GetValueCount(this);

		internal VirtualNode VirtualNode => mobjVirtualNode;

		private VirtualRegistryKey(VirtualNode objVirtualNode)
		{
			mobjVirtualNode = objVirtualNode;
		}

		internal static VirtualRegistryKey Create(VirtualNode objVirtualNode)
		{
			return new VirtualRegistryKey(objVirtualNode);
		}

		public void Close()
		{
		}

		public VirtualRegistryKey CreateSubKey(string subkey)
		{
			return VirtualRegistry.CreateSubKey(this, subkey);
		}

		public VirtualRegistryKey CreateSubKey(string subkey, VirtualRegistryKeyPermissionCheck permissionCheck)
		{
			return VirtualRegistry.CreateSubKey(this, subkey, permissionCheck);
		}

		public VirtualRegistryKey CreateSubKey(string subkey, VirtualRegistryKeyPermissionCheck permissionCheck, RegistrySecurity registrySecurity)
		{
			return VirtualRegistry.CreateSubKey(this, subkey, permissionCheck, registrySecurity);
		}

		public void DeleteSubKey(string subkey)
		{
			VirtualRegistry.DeleteSubKey(this, subkey);
		}

		public void DeleteSubKey(string subkey, bool throwOnMissingSubKey)
		{
			VirtualRegistry.DeleteSubKey(this, subkey, throwOnMissingSubKey);
		}

		public void DeleteSubKeyTree(string subkey)
		{
			VirtualRegistry.DeleteSubKeyTree(this, subkey);
		}

		public void DeleteValue(string name)
		{
			VirtualRegistry.DeleteValue(this, name);
		}

		public void DeleteValue(string name, bool throwOnMissingValue)
		{
			VirtualRegistry.DeleteValue(this, name, throwOnMissingValue);
		}

		public void Flush()
		{
		}

		public RegistrySecurity GetAccessControl()
		{
			return VirtualRegistry.GetAccessControl(this);
		}

		public RegistrySecurity GetAccessControl(AccessControlSections includeSections)
		{
			return VirtualRegistry.GetAccessControl(this, includeSections);
		}

		public string[] GetSubKeyNames()
		{
			return VirtualRegistry.GetSubKeyNames(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public VirtualRegistryKey[] GetSubKeys()
		{
			return VirtualRegistry.GetSubKeys(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public VirtualRegistryValue[] GetSubValues()
		{
			return VirtualRegistry.GetSubValues(this);
		}

		public object GetValue(string name)
		{
			return VirtualRegistry.GetValue(this, name);
		}

		public object GetValue(string name, object defaultValue)
		{
			return VirtualRegistry.GetValue(this, name, defaultValue);
		}

		public object GetValue(string name, object defaultValue, VirtualRegistryValueOptions options)
		{
			return VirtualRegistry.GetValue(this, name, defaultValue, options);
		}

		public VirtualRegistryValueKind GetValueKind(string name)
		{
			return VirtualRegistry.GetValueKind(this, name);
		}

		public string[] GetValueNames()
		{
			return VirtualRegistry.GetValueNames(this);
		}

		public static VirtualRegistryKey OpenRemoteBaseKey(VirtualRegistryHive hKey, string machineName)
		{
			return VirtualRegistry.OpenRemoteBaseKey(hKey, machineName);
		}

		public VirtualRegistryKey OpenSubKey(string name)
		{
			return VirtualRegistry.OpenSubKey(this, name);
		}

		public VirtualRegistryKey OpenSubKey(string name, VirtualRegistryKeyPermissionCheck permissionCheck)
		{
			return VirtualRegistry.OpenSubKey(this, name, permissionCheck);
		}

		public VirtualRegistryKey OpenSubKey(string name, bool writable)
		{
			return VirtualRegistry.OpenSubKey(this, name, writable);
		}

		public VirtualRegistryKey OpenSubKey(string name, VirtualRegistryKeyPermissionCheck permissionCheck, RegistryRights rights)
		{
			return VirtualRegistry.OpenSubKey(this, name, permissionCheck, rights);
		}

		public void SetAccessControl(RegistrySecurity registrySecurity)
		{
			VirtualRegistry.SetAccessControl(this, registrySecurity);
		}

		public void SetValue(string name, object value)
		{
			VirtualRegistry.SetValue(this, name, value);
		}

		public void SetValue(string name, object value, VirtualRegistryValueKind valueKind)
		{
			VirtualRegistry.SetValue(this, name, value, valueKind);
		}

		public override string ToString()
		{
			return Name;
		}

		void IDisposable.Dispose()
		{
		}
	}
}
