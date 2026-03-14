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
	/// Type converter for the draggable option object.
	/// </summary>
	[Serializable]
	public class VisualTemplatesTypeConverter : TypeConverter
	{
		/// 
		/// Converts the specified objValue object to an enumeration object.
		/// </summary>
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, destinationType);
		}

		/// 
		/// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
		/// </summary>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		/// 
		/// converts from string to the object.
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="culture"></param>
		/// <param name="objValue"></param>
		/// </returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string text = (string)value;
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split('|');
					List<object> list = new List<object><object>();
					for (int i = 1; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					return GetVisualTemplateObjectFromString(array[0], list);
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		/// 
		/// Converts the given objValue object to the specified destination type.
		/// </summary>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return ConvertToInstanceDescriptor(context, value);
			}
			if (destinationType == typeof(string))
			{
				return ConvertToString(context, value);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		/// 
		/// converts the object to string.
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objValue"></param>
		/// </returns>
		private new string ConvertToString(ITypeDescriptorContext objContext, object value)
		{
			if (value is VisualTemplate visualTemplate)
			{
				return visualTemplate.ConvertToString();
			}
			return "";
		}

		/// 
		/// gives the InstanceDescriptor of the object
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objValue"></param>
		/// </returns>
		private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
		{
			VisualTemplate visualTemplate = value as VisualTemplate;
			object[] consturctorArguments = visualTemplate.GetConsturctorArguments();
			Type[] constructorTypes = visualTemplate.GetConstructorTypes();
			ConstructorInfo constructor = visualTemplate.GetType().GetConstructor(constructorTypes);
			return new InstanceDescriptor(constructor, consturctorArguments);
		}

		/// 
		/// Gets the visual effect object from string.
		/// </summary>
		/// <param name="strVisualEffectType">Name of the STR visual effect.</param>
		/// <param name="strVisualEffectValue">The STR visual effect objValue.</param>
		/// </returns>
		protected virtual VisualTemplate GetVisualTemplateObjectFromString(string strVisualTypeType,List<object> objVisualTemplateValues)
		{
			VisualTemplate visualTemplate = null;
			string typeName = strVisualTypeType;
			string[] array = strVisualTypeType.Split(',');
			if (array.Length > 1)
			{
				typeName = $"{array[0]}, {CommonUtils.GetFullAssemblyName(array[1].Trim())}";
			}
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				visualTemplate = Activator.CreateInstance(type) as VisualTemplate;
				visualTemplate?.ConvertFromString(objVisualTemplateValues);
			}
			return visualTemplate;
		}
	}
}
