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
	internal class Formatter : SerializableObject
	{
		private static Type mobjBooleanType;

		private static Type mobjCheckStateType;

		private static object mobjDefaultDataSourceNullValue;

		private static object mobjParseMethodNotFound;

		private static Type mobjStringType;

		static Formatter()
		{
			mobjStringType = typeof(string);
			mobjBooleanType = typeof(bool);
			mobjCheckStateType = typeof(CheckState);
			mobjParseMethodNotFound = new object();
			mobjDefaultDataSourceNullValue = DBNull.Value;
		}

		private static object ChangeType(object objValue, Type objType, IFormatProvider objFormatInfo)
		{
			try
			{
				if (objFormatInfo == null)
				{
					objFormatInfo = CultureInfo.CurrentCulture;
				}
				return Convert.ChangeType(objValue, objType, objFormatInfo);
			}
			catch (InvalidCastException ex)
			{
				throw new FormatException(ex.Message, ex);
			}
		}

		private static bool EqualsFormattedNullValue(object objValue, object objFormattedNullValue, IFormatProvider objFormatInfo)
		{
			if (objFormattedNullValue is string && objValue is string)
			{
				return string.Compare((string)objValue, (string)objFormattedNullValue, ignoreCase: true, GetFormatterCulture(objFormatInfo)) == 0;
			}
			return object.Equals(objValue, objFormattedNullValue);
		}

		public static object FormatObject(object objValue, Type objTargetType, TypeConverter objSourceConverter, TypeConverter objTargetConverter, string strFormatString, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
		{
			if (IsNullData(objValue, objDataSourceNullValue))
			{
				objValue = DBNull.Value;
			}
			Type type = objTargetType;
			objTargetType = NullableUnwrap(objTargetType);
			objSourceConverter = NullableUnwrap(objSourceConverter);
			objTargetConverter = NullableUnwrap(objTargetConverter);
			bool flag = objTargetType != type;
			object obj = FormatObjectInternal(objValue, objTargetType, objSourceConverter, objTargetConverter, strFormatString, objFormatInfo, objFormattedNullValue);
			if (type.IsValueType && obj == null && !flag)
			{
				throw new FormatException(GetCantConvertMessage(objValue, objTargetType));
			}
			return obj;
		}

		private static object FormatObjectInternal(object objValue, Type objTargetType, TypeConverter objSourceConverter, TypeConverter objTargetConverter, string strFormatString, IFormatProvider objFormatInfo, object objFormattedNullValue)
		{
			if (objValue == DBNull.Value || objValue == null)
			{
				if (objFormattedNullValue != null)
				{
					return objFormattedNullValue;
				}
				if (objTargetType == mobjStringType)
				{
					return string.Empty;
				}
				if (objTargetType == mobjCheckStateType)
				{
					return CheckState.Indeterminate;
				}
				return null;
			}
			if (objTargetType == mobjStringType && objValue is IFormattable && !CommonUtils.IsNullOrEmpty(strFormatString))
			{
				return (objValue as IFormattable).ToString(strFormatString, objFormatInfo);
			}
			Type type = objValue.GetType();
			TypeConverter converter = TypeDescriptor.GetConverter(type);
			if (objSourceConverter != null && objSourceConverter != converter && objSourceConverter.CanConvertTo(objTargetType))
			{
				return objSourceConverter.ConvertTo(null, GetFormatterCulture(objFormatInfo), objValue, objTargetType);
			}
			TypeConverter converter2 = TypeDescriptor.GetConverter(objTargetType);
			if (objTargetConverter != null && objTargetConverter != converter2 && objTargetConverter.CanConvertFrom(type))
			{
				return objTargetConverter.ConvertFrom(null, GetFormatterCulture(objFormatInfo), objValue);
			}
			if (objTargetType == mobjCheckStateType)
			{
				if (type == mobjBooleanType)
				{
					return ((bool)objValue) ? CheckState.Checked : CheckState.Unchecked;
				}
				if (objSourceConverter == null)
				{
					objSourceConverter = converter;
				}
				if (objSourceConverter != null && objSourceConverter.CanConvertTo(mobjBooleanType))
				{
					return ((bool)objSourceConverter.ConvertTo(null, GetFormatterCulture(objFormatInfo), objValue, mobjBooleanType)) ? CheckState.Checked : CheckState.Unchecked;
				}
			}
			if (!objTargetType.IsAssignableFrom(type))
			{
				if (objSourceConverter == null)
				{
					objSourceConverter = converter;
				}
				if (objTargetConverter == null)
				{
					objTargetConverter = converter2;
				}
				if (objSourceConverter == null || !objSourceConverter.CanConvertTo(objTargetType))
				{
					if (objTargetConverter == null || !objTargetConverter.CanConvertFrom(type))
					{
						if (!(objValue is IConvertible))
						{
							throw new FormatException(GetCantConvertMessage(objValue, objTargetType));
						}
						return ChangeType(objValue, objTargetType, objFormatInfo);
					}
					return objTargetConverter.ConvertFrom(null, GetFormatterCulture(objFormatInfo), objValue);
				}
				return objSourceConverter.ConvertTo(null, GetFormatterCulture(objFormatInfo), objValue, objTargetType);
			}
			return objValue;
		}

		private static string GetCantConvertMessage(object objValue, Type objTargetType)
		{
			string strName = ((objValue == null) ? "Formatter_CantConvertNull" : "Formatter_CantConvert");
			return string.Format(CultureInfo.CurrentCulture, SR.GetString(strName), new object[2] { objValue, objTargetType.Name });
		}

		public static object GetDefaultDataSourceNullValue(Type objType)
		{
			if (objType != null && !objType.IsValueType)
			{
				return null;
			}
			return mobjDefaultDataSourceNullValue;
		}

		private static CultureInfo GetFormatterCulture(IFormatProvider objFormatInfo)
		{
			if (objFormatInfo is CultureInfo)
			{
				return objFormatInfo as CultureInfo;
			}
			return CultureInfo.CurrentCulture;
		}

		public static object InvokeStringParseMethod(object objValue, Type objTargetType, IFormatProvider objFormatInfo)
		{
			object result;
			try
			{
				MethodInfo method = objTargetType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public, null, new Type[3]
				{
					mobjStringType,
					typeof(NumberStyles),
					typeof(IFormatProvider)
				}, null);
				if (method != null)
				{
					return method.Invoke(null, new object[3]
					{
						(string)objValue,
						NumberStyles.Any,
						objFormatInfo
					});
				}
				method = objTargetType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
				{
					mobjStringType,
					typeof(IFormatProvider)
				}, null);
				if (method != null)
				{
					return method.Invoke(null, new object[2]
					{
						(string)objValue,
						objFormatInfo
					});
				}
				method = objTargetType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public, null, new Type[1] { mobjStringType }, null);
				if (method != null)
				{
					return method.Invoke(null, new object[1] { (string)objValue });
				}
				result = mobjParseMethodNotFound;
			}
			catch (TargetInvocationException ex)
			{
				throw new FormatException(ex.InnerException.Message, ex.InnerException);
			}
			return result;
		}

		public static bool IsNullData(object objValue, object objDataSourceNullValue)
		{
			if (objValue != null && objValue != DBNull.Value)
			{
				return object.Equals(objValue, NullData(objValue.GetType(), objDataSourceNullValue));
			}
			return true;
		}

		private static TypeConverter NullableUnwrap(TypeConverter objTypeConverter)
		{
			if (objTypeConverter != null)
			{
				Type typeFromHandle = typeof(NullableConverter);
				if (typeFromHandle != null)
				{
					Type type = objTypeConverter.GetType();
					if (type.IsSubclassOf(typeFromHandle) || type == typeFromHandle)
					{
						PropertyInfo property = typeFromHandle.GetProperty("UnderlyingTypeConverter", BindingFlags.Instance | BindingFlags.Public);
						objTypeConverter = (TypeConverter)property.GetValue(objTypeConverter, null);
					}
				}
			}
			return objTypeConverter;
		}

		private static Type NullableUnwrap(Type objType)
		{
			if (objType == mobjStringType)
			{
				return mobjStringType;
			}
			Type underlyingType = Nullable.GetUnderlyingType(objType);
			return (underlyingType != null) ? underlyingType : objType;
		}

		public static object NullData(Type objType, object objDataSourceNullValue)
		{
			if (!objType.IsGenericType || objType.GetGenericTypeDefinition() != typeof(Nullable<>))
			{
				return objDataSourceNullValue;
			}
			if (objDataSourceNullValue != null && objDataSourceNullValue != DBNull.Value)
			{
				return objDataSourceNullValue;
			}
			return null;
		}

		public static object ParseObject(object objValue, Type objTargetType, Type objSourceType, TypeConverter objTargetConverter, TypeConverter objSourceConverter, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
		{
			Type objType = objTargetType;
			objSourceType = NullableUnwrap(objSourceType);
			objTargetType = NullableUnwrap(objTargetType);
			objSourceConverter = NullableUnwrap(objSourceConverter);
			objTargetConverter = NullableUnwrap(objTargetConverter);
			object obj = ParseObjectInternal(objValue, objTargetType, objSourceType, objTargetConverter, objSourceConverter, objFormatInfo, objFormattedNullValue);
			if (obj == DBNull.Value)
			{
				return NullData(objType, objDataSourceNullValue);
			}
			return obj;
		}

		private static object ParseObjectInternal(object objValue, Type objTargetType, Type objSourceType, TypeConverter objTargetConverter, TypeConverter objSourceConverter, IFormatProvider objFormatInfo, object objFormattedNullValue)
		{
			if (EqualsFormattedNullValue(objValue, objFormattedNullValue, objFormatInfo) || objValue == DBNull.Value)
			{
				return DBNull.Value;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(objTargetType);
			if (objTargetConverter == null || converter == objTargetConverter || !objTargetConverter.CanConvertFrom(objSourceType))
			{
				TypeConverter converter2 = TypeDescriptor.GetConverter(objSourceType);
				if (objSourceConverter != null && converter2 != objSourceConverter && objSourceConverter.CanConvertTo(objTargetType))
				{
					return objSourceConverter.ConvertTo(null, GetFormatterCulture(objFormatInfo), objValue, objTargetType);
				}
				if (objValue is string)
				{
					object obj = InvokeStringParseMethod(objValue, objTargetType, objFormatInfo);
					if (obj != mobjParseMethodNotFound)
					{
						return obj;
					}
				}
				else if (objValue is CheckState checkState)
				{
					if (checkState == CheckState.Indeterminate)
					{
						return DBNull.Value;
					}
					if (objTargetType == mobjBooleanType)
					{
						return checkState == CheckState.Checked;
					}
					if (objTargetConverter == null)
					{
						objTargetConverter = converter;
					}
					if (objTargetConverter != null && objTargetConverter.CanConvertFrom(mobjBooleanType))
					{
						return objTargetConverter.ConvertFrom(null, GetFormatterCulture(objFormatInfo), checkState == CheckState.Checked);
					}
				}
				else if (objValue != null && objTargetType.IsAssignableFrom(objValue.GetType()))
				{
					return objValue;
				}
				if (objTargetConverter == null)
				{
					objTargetConverter = converter;
				}
				if (objSourceConverter == null)
				{
					objSourceConverter = converter2;
				}
				if (objTargetConverter == null || !objTargetConverter.CanConvertFrom(objSourceType))
				{
					if (objSourceConverter == null || !objSourceConverter.CanConvertTo(objTargetType))
					{
						if (!(objValue is IConvertible))
						{
							throw new FormatException(GetCantConvertMessage(objValue, objTargetType));
						}
						return ChangeType(objValue, objTargetType, objFormatInfo);
					}
					return objSourceConverter.ConvertTo(null, GetFormatterCulture(objFormatInfo), objValue, objTargetType);
				}
			}
			return objTargetConverter.ConvertFrom(null, GetFormatterCulture(objFormatInfo), objValue);
		}
	}
}
