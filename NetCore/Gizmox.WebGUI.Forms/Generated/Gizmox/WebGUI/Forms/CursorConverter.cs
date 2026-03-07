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
	/// Provides a type converter to convert <see cref="T:System.Windows.Forms.Cursor"></see> objects to and from various other representations.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class CursorConverter : TypeConverter
	{
		[NonSerialized]
		private StandardValuesCollection mobjValues;

		/// Determines if this converter can convert an object in the given source type to the native type of the converter.</summary>
		/// true if this object can perform the conversion.</returns>
		/// <param name="objContext">A formatter context. This object can be used to extract additional information about the environment this converter is being invoked from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
		/// <param name="objSourceType">The type you wish to convert from. </param>
		/// 1</filterpriority>
		public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
		{
			if (objSourceType != typeof(string) && objSourceType != typeof(byte[]))
			{
				return base.CanConvertFrom(objContext, objSourceType);
			}
			return true;
		}

		/// Gets a value indicating whether this converter can convert an object to the given destination type using the context.</summary>
		/// true if this converter can perform the conversion; otherwise, false.</returns>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context. </param>
		/// <param name="objDestinationType">A <see cref="T:System.Type"></see> that represents the type you wish to convert to. </param>
		/// 1</filterpriority>
		public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
		{
			if (objDestinationType != typeof(InstanceDescriptor) && objDestinationType != typeof(byte[]))
			{
				return base.CanConvertTo(objContext, objDestinationType);
			}
			return true;
		}

		/// 1</filterpriority>
		public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
		{
			if (objValue is string)
			{
				string strB = ((string)objValue).Trim();
				PropertyInfo[] properties = GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (ClientUtils.IsEquals(propertyInfo.Name, strB, StringComparison.OrdinalIgnoreCase))
					{
						object[] index = null;
						return propertyInfo.GetValue(null, index);
					}
				}
			}
			return base.ConvertFrom(objContext, objCulture, objValue);
		}

		/// 1</filterpriority>
		public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (objDestinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (objDestinationType == typeof(string) && objValue != null)
			{
				PropertyInfo[] properties = GetProperties();
				int num = -1;
				for (int i = 0; i < properties.Length; i++)
				{
					PropertyInfo propertyInfo = properties[i];
					object[] index = null;
					Cursor cursor = (Cursor)propertyInfo.GetValue(null, index);
					if (cursor == (Cursor)objValue)
					{
						if (cursor == objValue)
						{
							return propertyInfo.Name;
						}
						num = i;
					}
				}
				if (num == -1)
				{
					throw new FormatException(SR.GetString("CursorCannotCovertToString"));
				}
				return properties[num].Name;
			}
			if (objDestinationType == typeof(InstanceDescriptor) && objValue is Cursor)
			{
				return ConvertToInstanceDescriptor(objContext, objValue);
			}
			if (objDestinationType != typeof(byte[]))
			{
				return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
			}
			return new byte[0];
		}

		/// 
		/// Convert to InstanceDescriptor
		/// </summary>
		/// 
		/// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
		/// </remarks>
		private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
		{
			PropertyInfo[] properties = GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.GetValue(null, null) == objValue)
				{
					return new InstanceDescriptor(propertyInfo, null);
				}
			}
			return new byte[0];
		}

		private PropertyInfo[] GetProperties()
		{
			return typeof(Cursors).GetProperties(BindingFlags.Static | BindingFlags.Public);
		}

		/// Retrieves a collection containing a set of standard values for the data type this validator is designed for. This will return null if the data type does not support a standard set of values.</summary>
		/// A collection containing a standard set of valid values, or null. The default implementation always returns null.</returns>
		/// <param name="objContext">A formatter context. This object can be used to extract additional information about the environment this converter is being invoked from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
		/// 1</filterpriority>
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
		{
			if (mobjValues == null)
			{
				ArrayList arrayList = new ArrayList();
				PropertyInfo[] properties = GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					object[] index = null;
					arrayList.Add(propertyInfo.GetValue(null, index));
				}
				mobjValues = new StandardValuesCollection(arrayList.ToArray());
			}
			return mobjValues;
		}

		/// Determines if this object supports a standard set of values that can be picked from a list.</summary>
		/// Returns true if GetStandardValues should be called to find a common set of values the object supports.</returns>
		/// <param name="objContext">A type descriptor through which additional context may be provided. </param>
		/// 1</filterpriority>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
		{
			return true;
		}
	}
}
