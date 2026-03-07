#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
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
using Gizmox.WebGUI.Common.Extensibility;
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
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	[Serializable]
	internal class SecurityUtils
	{
		private static bool HasReflectionPermission
		{
			get
			{
				try
				{
					new ReflectionPermission(PermissionState.Unrestricted).Demand();
					return true;
				}
				catch (SecurityException)
				{
				}
				return false;
			}
		}

		internal static object SecureConstructorInvoke(Type objType, Type[] arrArgTypes, object[] arrArgs, bool blnAllowNonPublic)
		{
			return SecureConstructorInvoke(objType, arrArgTypes, arrArgs, blnAllowNonPublic, BindingFlags.Default);
		}

		internal static object SecureConstructorInvoke(Type objType, Type[] arrArgTypes, object[] arrArgs, bool blnAllowNonPublic, BindingFlags enmExtraFlags)
		{
			if (objType == null)
			{
				throw new ArgumentNullException("type");
			}
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | enmExtraFlags;
			if (objType.Assembly == typeof(SecurityUtils).Assembly)
			{
				if (!objType.IsPublic && !objType.IsNestedPublic)
				{
					new ReflectionPermission(PermissionState.Unrestricted).Demand();
				}
				else if (blnAllowNonPublic && !HasReflectionPermission)
				{
					blnAllowNonPublic = false;
				}
			}
			if (blnAllowNonPublic)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			ConstructorInfo constructor = objType.GetConstructor(bindingFlags, null, arrArgTypes, null);
			if (constructor != null)
			{
				return constructor.Invoke(arrArgs);
			}
			return null;
		}

		internal static object SecureCreateInstance(Type objType)
		{
			return SecureCreateInstance(objType, null);
		}

		internal static object SecureCreateInstance(Type objType, object[] arrArgs)
		{
			if (objType == null)
			{
				throw new ArgumentNullException("type");
			}
			if (objType.Assembly == typeof(SecurityUtils).Assembly && !objType.IsPublic && !objType.IsNestedPublic)
			{
				new ReflectionPermission(PermissionState.Unrestricted).Demand();
			}
			return Activator.CreateInstance(objType, arrArgs);
		}

		internal static object SecureCreateInstance(Type objType, object[] arrArgs, bool blnAllowNonPublic)
		{
			if (objType == null)
			{
				throw new ArgumentNullException("type");
			}
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;
			if (objType.Assembly == typeof(SecurityUtils).Assembly)
			{
				if (!objType.IsPublic && !objType.IsNestedPublic)
				{
					new ReflectionPermission(PermissionState.Unrestricted).Demand();
				}
				else if (blnAllowNonPublic && !HasReflectionPermission)
				{
					blnAllowNonPublic = false;
				}
			}
			if (blnAllowNonPublic)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return Activator.CreateInstance(objType, bindingFlags, null, arrArgs, null);
		}
	}
}
