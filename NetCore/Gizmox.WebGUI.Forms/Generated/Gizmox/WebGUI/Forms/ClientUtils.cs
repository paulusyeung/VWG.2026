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
	/// Summary description for WebGUIUtils.
	/// </summary>
	[Serializable]
	internal sealed class ClientUtils
	{
		[Serializable]
		public class ReadOnlyControlCollection : Control.ControlCollection
		{
			private readonly bool mblnIsReadOnly;

			public override bool IsReadOnly => mblnIsReadOnly;

			public ReadOnlyControlCollection(Control objOwner, bool blnIsReadOnly)
				: base(objOwner)
			{
				mblnIsReadOnly = blnIsReadOnly;
			}

			public override void Add(Control objControl)
			{
				if (IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
				}
				AddInternal(objControl);
			}

			internal virtual void AddInternal(Control objControl)
			{
				base.Add(objControl);
			}

			public override void Clear()
			{
				if (IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
				}
				base.Clear();
			}

			public override void RemoveByKey(string strKey)
			{
				if (IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
				}
				base.RemoveByKey(strKey);
			}

			internal virtual void RemoveInternal(Control objControl)
			{
				base.Remove(objControl);
			}
		}

		[Serializable]
		public class TypedControlCollection : ReadOnlyControlCollection
		{
			private Control mobjOwnerControl;

			private Type mobjTypeOfControl;

			public TypedControlCollection(Control objOwner, Type objTypeOfControl)
				: base(objOwner, blnIsReadOnly: false)
			{
				mobjTypeOfControl = objTypeOfControl;
				mobjOwnerControl = objOwner;
			}

			public TypedControlCollection(Control objOwner, Type objTypeOfControl, bool blnIsReadOnly)
				: base(objOwner, blnIsReadOnly)
			{
				mobjTypeOfControl = objTypeOfControl;
				mobjOwnerControl = objOwner;
			}

			public override void Add(Control objControl)
			{
				Control.CheckParentingCycle(mobjOwnerControl, objControl);
				if (objControl == null)
				{
					throw new ArgumentNullException("value");
				}
				if (IsReadOnly)
				{
					throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
				}
				if (!mobjTypeOfControl.IsAssignableFrom(objControl.GetType()))
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.GetString("TypedControlCollectionShouldBeOfType", mobjTypeOfControl.Name)), objControl.GetType().Name);
				}
				base.Add(objControl);
			}
		}

		/// 
		/// Get the VWG router type
		/// </summary>
		private static Type RouterType
		{
			get
			{
				Type type = null;
				return Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.5.25701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
			}
		}

		/// Returns the largest item from the array of comparable objects.</summary>
		/// The largest item from the array of comparable objects.</returns>
		/// <param name="arrArgs">array of comparable objects. </param>
		public static IComparable Max(params IComparable[] arrArgs)
		{
			return MaxOrMin(blnFindMax: true, arrArgs);
		}

		/// Returns the smallest item from the array of comparable objects.</summary>
		/// The smallest item from the array of comparable objects.</returns>
		/// <param name="arrArgs">array of comparable objects. </param>
		public static IComparable Min(params IComparable[] arrArgs)
		{
			return MaxOrMin(blnFindMax: false, arrArgs);
		}

		/// Returns the smallest or largest (depends on findMax) item from the array of comparable objects.</summary>
		/// The smallest or largest (depends on findMax) item from the array of comparable objects.</returns>
		/// <param name="blnFindMax">If true then finds the largest item, else find the smallest item</param>
		/// <param name="arrArgs">array of comparable objects. </param>
		private static IComparable MaxOrMin(bool blnFindMax, params IComparable[] arrArgs)
		{
			if (arrArgs.Length == 0 || arrArgs == null)
			{
				throw new NullReferenceException("Null or empty array are invalid.");
			}
			if (arrArgs.Length == 1)
			{
				return arrArgs[0];
			}
			IComparable comparable = arrArgs[0];
			for (int i = 1; i < arrArgs.Length; i++)
			{
				if (blnFindMax)
				{
					if (arrArgs[i].CompareTo(comparable) > 0)
					{
						comparable = arrArgs[i];
					}
				}
				else if (arrArgs[i].CompareTo(comparable) < 0)
				{
					comparable = arrArgs[i];
				}
			}
			return comparable;
		}

		/// Determines whether two specified <see cref="T:System.String"></see> objects have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
		/// true if the value of the a parameter is equal to the value of the b parameter; otherwise, false.</returns>
		/// <param name="strA">A <see cref="T:System.String"></see> object or null. </param>
		/// <param name="enmComparisonType">One of the <see cref="T:System.StringComparison"></see> values. </param>
		/// <param name="strB">A <see cref="T:System.String"></see> object or null. </param>
		/// <exception cref="T:System.ArgumentException">comparisonType objIs not a <see cref="T:System.StringComparison"></see> value. </exception>
		/// 1</filterpriority>
		public static bool IsEquals(string strA, string strB, StringComparison enmComparisonType)
		{
			return string.Equals(strA, strB, enmComparisonType);
		}

		public static int GetCombinedHashCodes(params int[] arrIntArgs)
		{
			int num = -757577119;
			for (int i = 0; i < arrIntArgs.Length; i++)
			{
				num = (arrIntArgs[i] ^ num) * -1640531535;
			}
			return num;
		}

		public static bool SafeCompareStrings(string string1, string string2, bool blnIgnoreCase)
		{
			if (string1 == null || string2 == null)
			{
				return false;
			}
			if (string1.Length != string2.Length)
			{
				return false;
			}
			return string.Compare(string1, string2, blnIgnoreCase, CultureInfo.InvariantCulture) == 0;
		}

		public static int RotateLeft(int intValue, int intNBits)
		{
			intNBits %= 32;
			return (intValue << (intNBits & 0x1F)) | (intValue >> ((32 - intNBits) & 0x1F));
		}

		public static int GetBitCount(uint uintX)
		{
			int num = 0;
			while (uintX != 0)
			{
				uintX &= uintX - 1;
				num++;
			}
			return num;
		}

		/// 
		/// Determines whether the specified text contains mnemonic.
		/// </summary>
		/// <param name="text">The text.</param>
		/// 
		/// 	true</c> if the specified text contains mnemonic; otherwise, false</c>.
		/// </returns>
		public static bool ContainsMnemonic(string strText)
		{
			if (strText != null)
			{
				int length = strText.Length;
				int num = strText.IndexOf('&', 0);
				if (num >= 0 && num <= length - 2 && strText.IndexOf('&', num + 1) == -1)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsEnumValid(Enum objEnumValue, int intValue, int intMinValue, int intMaxValue)
		{
			return intValue >= intMinValue && intValue <= intMaxValue;
		}

		public static bool IsEnumValid(Enum objEnumValue, int intValue, int intMinValue, int intMaxValue, int intMaxNumberOfBitsOn)
		{
			return intValue >= intMinValue && intValue <= intMaxValue && GetBitCount((uint)intValue) <= intMaxNumberOfBitsOn;
		}

		public static bool IsEnumValid_Masked(Enum objEnumValue, int intValue, uint uintMask)
		{
			return (intValue & uintMask) == intValue;
		}

		public static bool IsEnumValid_NotSequential(Enum objEnumValue, int intValue, params int[] arrEnumValues)
		{
			for (int i = 0; i < arrEnumValues.Length; i++)
			{
				if (arrEnumValues[i] == intValue)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsSecurityOrCriticalException(Exception objException)
		{
			if (!(objException is SecurityException))
			{
				return IsCriticalException(objException);
			}
			return true;
		}

		public static bool IsCriticalException(Exception objException)
		{
			if (!(objException is NullReferenceException) && !(objException is StackOverflowException) && !(objException is OutOfMemoryException) && !(objException is ThreadAbortException) && !(objException is ExecutionEngineException) && !(objException is IndexOutOfRangeException))
			{
				return objException is AccessViolationException;
			}
			return true;
		}

		public static object FormatObject(object objValue, Type objTargetType, TypeConverter objSourceConverter, TypeConverter objTargetConverter, string strFormatString, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
		{
			return Formatter.FormatObject(objValue, objTargetType, objSourceConverter, objTargetConverter, strFormatString, objFormatInfo, objFormattedNullValue, objDataSourceNullValue);
		}

		public static object ParseObject(object objValue, Type objTargetType, Type objSourceType, TypeConverter objTargetConverter, TypeConverter objSourceConverter, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
		{
			return Formatter.ParseObject(objValue, objTargetType, objSourceType, objTargetConverter, objSourceConverter, objFormatInfo, objFormattedNullValue, objDataSourceNullValue);
		}

		public static object GetDefaultDataSourceNullValue(Type objType)
		{
			return Formatter.GetDefaultDataSourceNullValue(objType);
		}

		/// 
		/// Returns a web color
		/// </summary>
		/// <param name="objColor"></param>
		/// </returns>
		public static string GetWebColor(Color objColor)
		{
			return "#" + objColor.R.ToString("X2", null) + objColor.G.ToString("X2", null) + objColor.B.ToString("X2", null);
		}

		/// 
		/// Returns a web color string from an integer array
		/// </summary>
		/// <param name="arrColors"></param>
		/// </returns>
		public static string GetWebColor(int[] arrColors)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int argb in arrColors)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(GetWebColor(Color.FromArgb(argb)));
			}
			return stringBuilder.ToString();
		}

		public static string GetWebFont(Font objFont)
		{
			string text = "";
			if (objFont != null)
			{
				text = ((!objFont.Italic) ? (text + "normal ") : (text + "italic "));
				text += "normal ";
				text = ((!objFont.Bold) ? (text + "normal ") : (text + "bold "));
				switch (objFont.Unit)
				{
				case GraphicsUnit.Pixel:
					text = text + objFont.Size.ToString(CultureInfo.InvariantCulture) + "px ";
					break;
				case GraphicsUnit.Point:
					text = text + objFont.Size.ToString(CultureInfo.InvariantCulture) + "pt ";
					break;
				case GraphicsUnit.Inch:
					text = text + objFont.Size.ToString(CultureInfo.InvariantCulture) + "in ";
					break;
				case GraphicsUnit.Millimeter:
					text = text + objFont.Size.ToString(CultureInfo.InvariantCulture) + "mm ";
					break;
				}
				text = text + objFont.FontFamily.Name + " ";
				if (!objFont.Underline)
				{
					text = ((!objFont.Strikeout) ? (text + ";text-decoration:none") : (text + ";text-decoration:line-through"));
				}
				else
				{
					text += ";text-decoration:underline";
					if (objFont.Strikeout)
					{
						text += " line-through";
					}
				}
			}
			return text;
		}

		/// 
		/// Get a VWG router instance
		/// </summary>
		/// </returns>
		internal static IRouter GetRouter()
		{
			Type routerType = RouterType;
			if (routerType != null)
			{
				return Activator.CreateInstance(routerType) as IRouter;
			}
			return null;
		}
	}
}
