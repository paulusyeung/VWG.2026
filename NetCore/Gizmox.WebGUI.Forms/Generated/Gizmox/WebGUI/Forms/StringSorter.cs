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
	internal sealed class StringSorter
	{
		public const int Descending = int.MinValue;

		public const int IgnoreCase = 1;

		public const int IgnoreKanaType = 65536;

		public const int IgnoreNonSpace = 2;

		public const int IgnoreSymbols = 4;

		public const int IgnoreWidth = 131072;

		public const int StringSort = 4096;

		private const int CompareOptions = 200711;

		private bool mblnDescending;

		private object[] marrItems;

		private string[] marrKeys;

		private int mintLCID;

		private int mintOptions;

		private StringSorter(CultureInfo objCulture, string[] arrKeys, object[] arrItem, int intOptions)
		{
			if (arrKeys == null)
			{
				if (arrItem is string[])
				{
					arrKeys = (string[])arrItem;
					arrItem = null;
				}
				else
				{
					arrKeys = new string[arrItem.Length];
					for (int i = 0; i < arrItem.Length; i++)
					{
						object obj = arrItem[i];
						if (obj != null)
						{
							arrKeys[i] = obj.ToString();
						}
					}
				}
			}
			marrKeys = arrKeys;
			marrItems = arrItem;
			mintLCID = objCulture?.LCID ?? ((Global.Context != null && Global.Context.CurrentUICulture != null) ? Global.Context.CurrentUICulture.LCID : CultureInfo.CurrentUICulture.LCID);
			mintOptions = intOptions & 0x31007;
			mblnDescending = (intOptions & int.MinValue) != 0;
		}

		internal static int ArrayLength(object[] arrObjects)
		{
			if (arrObjects == null)
			{
				return 0;
			}
			return arrObjects.Length;
		}

		public static int Compare(string s1, string s2)
		{
			return Compare(Global.Context.CurrentUICulture, s1, s2, 0);
		}

		public static int Compare(string s1, string s2, int intOption)
		{
			return Compare(Global.Context.CurrentUICulture, s1, s2, intOption);
		}

		public static int Compare(CultureInfo objCulture, string s1, string s2, int intOption)
		{
			return Compare(objCulture.LCID, s1, s2, intOption);
		}

		private static int Compare(int intLcid, string s1, string s2, int intOption)
		{
			if (s1 == null)
			{
				if (s2 != null)
				{
					return -1;
				}
				return 0;
			}
			if (s2 == null)
			{
				return 1;
			}
			return string.Compare(s1, s2, ignoreCase: false, (Global.Context != null && Global.Context.CurrentUICulture != null) ? Global.Context.CurrentUICulture : CultureInfo.CurrentUICulture);
		}

		private int CompareKeys(string s1, string s2)
		{
			int num = Compare(mintLCID, s1, s2, mintOptions);
			if (!mblnDescending)
			{
				return num;
			}
			return -num;
		}

		private void QuickSort(int intLeft, int intRight)
		{
			do
			{
				int num = intLeft;
				int num2 = intRight;
				string text = marrKeys[num + num2 >> 1];
				while (true)
				{
					if (CompareKeys(marrKeys[num], text) < 0)
					{
						num++;
						continue;
					}
					while (CompareKeys(text, marrKeys[num2]) < 0)
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						string text2 = marrKeys[num];
						marrKeys[num] = marrKeys[num2];
						marrKeys[num2] = text2;
						if (marrItems != null)
						{
							object obj = marrItems[num];
							marrItems[num] = marrItems[num2];
							marrItems[num2] = obj;
						}
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (num2 - intLeft <= intRight - num)
				{
					if (intLeft < num2)
					{
						QuickSort(intLeft, num2);
					}
					intLeft = num;
				}
				else
				{
					if (num < intRight)
					{
						QuickSort(num, intRight);
					}
					intRight = num2;
				}
			}
			while (intLeft < intRight);
		}

		public static void Sort(object[] arrItems)
		{
			Sort(null, null, arrItems, 0, ArrayLength(arrItems), 0);
		}

		public static void Sort(object[] arrItems, int intOption)
		{
			Sort(null, null, arrItems, 0, ArrayLength(arrItems), intOption);
		}

		public static void Sort(string[] arrKeys, object[] arrItems)
		{
			Sort(null, arrKeys, arrItems, 0, ArrayLength(arrItems), 0);
		}

		public static void Sort(CultureInfo objCulture, object[] arrItems, int intOption)
		{
			Sort(objCulture, null, arrItems, 0, ArrayLength(arrItems), intOption);
		}

		public static void Sort(object[] arrItems, int index, int intCount)
		{
			Sort(null, null, arrItems, index, intCount, 0);
		}

		public static void Sort(string[] arrKeys, object[] arrItems, int intOption)
		{
			Sort(null, arrKeys, arrItems, 0, ArrayLength(arrItems), intOption);
		}

		public static void Sort(object[] arrItems, int index, int intCount, int intOption)
		{
			Sort(null, null, arrItems, index, intCount, intOption);
		}

		public static void Sort(CultureInfo objCulture, string[] arrKeys, object[] arrItems, int intOption)
		{
			Sort(objCulture, arrKeys, arrItems, 0, ArrayLength(arrItems), intOption);
		}

		public static void Sort(string[] arrKeys, object[] arrItems, int index, int intCount)
		{
			Sort(null, arrKeys, arrItems, index, intCount, 0);
		}

		public static void Sort(CultureInfo objCulture, object[] arrItems, int index, int intCount, int intOption)
		{
			Sort(objCulture, null, arrItems, index, intCount, intOption);
		}

		public static void Sort(string[] arrKeys, object[] arrItems, int index, int intCount, int intOption)
		{
			Sort(null, arrKeys, arrItems, index, intCount, intOption);
		}

		public static void Sort(CultureInfo objCulture, string[] arrKeys, object[] arrItems, int index, int intCount, int intOption)
		{
			if (arrItems == null || (arrKeys != null && arrKeys.Length != arrItems.Length))
			{
				throw new ArgumentException(SR.GetString("ArraysNotSameSize", "keys", "items"));
			}
			if (intCount > 1)
			{
				new StringSorter(objCulture, arrKeys, arrItems, intOption).QuickSort(index, index + intCount - 1);
			}
		}
	}
}
