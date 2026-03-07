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
	/// 
	///
	/// </summary>
	[Serializable]
	public sealed class SR
	{
		internal const string Test = "Test";

		/// 
		/// The singltone SR class
		/// </summary>
		private static SR mobjLoader;

		/// 
		/// The string resource resource manegar
		/// </summary>
		private System.Resources.ResourceManager mobjResources;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.SR" /> instance.
		/// </summary>
		static SR()
		{
			mobjLoader = null;
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.SR" /> instance.
		/// </summary>
		internal SR()
		{
			mobjResources = new System.Resources.ResourceManager("Gizmox.WebGUI.Forms.SR", GetType().Assembly);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static bool GetBoolean(string strName)
		{
			return GetBoolean(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static bool GetBoolean(CultureInfo objCulture, string strName)
		{
			bool result = false;
			SR loader = GetLoader();
			if (loader != null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is bool)
				{
					result = (bool)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static byte GetByte(string strName)
		{
			return GetByte(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static byte GetByte(CultureInfo objCulture, string strName)
		{
			byte result = 0;
			SR loader = GetLoader();
			if (loader != null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is byte)
				{
					result = (byte)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static char GetChar(string strName)
		{
			return GetChar(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static char GetChar(CultureInfo objCulture, string strName)
		{
			char result = '\0';
			SR loader = GetLoader();
			if (loader != null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is char)
				{
					result = (char)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static double GetDouble(string strName)
		{
			return GetDouble(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static double GetDouble(CultureInfo objCulture, string strName)
		{
			double result = 0.0;
			SR loader = GetLoader();
			if (loader == null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is double)
				{
					result = (double)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static float GetFloat(string strName)
		{
			return GetFloat(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static float GetFloat(CultureInfo objCulture, string strName)
		{
			float result = 0f;
			SR loader = GetLoader();
			if (loader == null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is float)
				{
					result = (float)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static int GetInt(string strName)
		{
			return GetInt(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static int GetInt(CultureInfo objCulture, string strName)
		{
			int result = 0;
			SR loader = GetLoader();
			if (loader != null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is int)
				{
					result = (int)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		private static SR GetLoader()
		{
			if (mobjLoader == null)
			{
				lock (typeof(SR))
				{
					if (mobjLoader == null)
					{
						mobjLoader = new SR();
					}
				}
			}
			return mobjLoader;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static long GetLong(string strName)
		{
			return GetLong(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static long GetLong(CultureInfo objCulture, string strName)
		{
			long result = 0L;
			SR loader = GetLoader();
			if (loader != null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is long)
				{
					result = (long)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static object GetObject(string strName)
		{
			return GetObject(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static object GetObject(CultureInfo objCulture, string strName)
		{
			return GetLoader()?.mobjResources.GetObject(strName, objCulture);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static short GetShort(string strName)
		{
			return GetShort(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static short GetShort(CultureInfo objCulture, string strName)
		{
			short result = 0;
			SR loader = GetLoader();
			if (loader != null)
			{
				object obj = loader.mobjResources.GetObject(strName, objCulture);
				if (obj is short)
				{
					result = (short)obj;
				}
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		public static string GetString(string strName)
		{
			return GetString(null, strName);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		public static string GetString(CultureInfo objCulture, string strName)
		{
			SR loader = GetLoader();
			if (loader == null)
			{
				return null;
			}
			try
			{
				return loader.mobjResources.GetString(strName, objCulture);
			}
			catch
			{
				return strName;
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="arrArgs"></param>
		public static string GetString(string strName, params object[] arrArgs)
		{
			return GetString(null, strName, arrArgs);
		}

		/// 
		///
		/// </summary>
		/// <param name="objCulture"></param>
		/// <param name="strName"></param>
		/// <param name="arrArgs"></param>
		public static string GetString(CultureInfo objCulture, string strName, params object[] arrArgs)
		{
			SR loader = GetLoader();
			if (loader == null)
			{
				return null;
			}
			string text = loader.mobjResources.GetString(strName, objCulture);
			if (text == null)
			{
				return strName;
			}
			if (arrArgs != null && arrArgs.Length != 0 && text != null)
			{
				return string.Format(text, arrArgs);
			}
			return text;
		}
	}
}
