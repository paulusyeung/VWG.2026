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
	public class DraggableOptionsTypeConverter : TypeConverter
	{
		/// 
		/// Converts the specified objValue object to an enumeration object.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="destinationType">Type of the destination.</param>
		/// 
		///   true</c> if this instance [can convert from] the specified context; otherwise, false</c>.
		/// </returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string) || destinationType == typeof(bool))
			{
				return true;
			}
			return base.CanConvertFrom(context, destinationType);
		}

		/// 
		/// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
		/// 
		/// true if this converter can perform the conversion; otherwise, false.
		/// </returns>
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
				string[] array = ((string)value).Split('|');
				if (array.Length == 9)
				{
					DraggableOptions draggableOptions = new DraggableOptions(array[0] == "1");
					draggableOptions.SnapTo = (SnapTo)int.Parse(array[1]);
					draggableOptions.SnapMode = (SnapMode)int.Parse(array[2]);
					draggableOptions.Xgrid = int.Parse(array[3]);
					draggableOptions.Ygrid = int.Parse(array[4]);
					draggableOptions.SnapTolerance = int.Parse(array[5]);
					draggableOptions.RevertMode = (RevertMode)int.Parse(array[6]);
					draggableOptions.RevertDuration = int.Parse(array[7]);
					draggableOptions.AllowNegativeAxes = bool.Parse(array[8]);
					return draggableOptions;
				}
				return new DraggableOptions(blnIsDraggable: false);
			}
			if (value is bool)
			{
				return new DraggableOptions((bool)value);
			}
			return base.ConvertFrom(context, culture, value);
		}

		/// 
		/// Converts the given objValue object to the specified destination type.
		/// </summary>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("objDestinationType");
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				object obj = ConvertToInstanceDescriptor(context, value);
				if (obj != null)
				{
					return obj;
				}
			}
			else if (destinationType == typeof(string))
			{
				return ConvertToString(context, value);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		/// 
		/// gives the InstanceDescriptor of the object
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objValue"></param>
		/// </returns>
		private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
		{
			if (value is DraggableOptions draggableOptions)
			{
				object[] array = null;
				Type[] array2 = null;
				if (draggableOptions.IsDefault())
				{
					array = new object[1] { draggableOptions.IsDraggable };
					array2 = new Type[1] { draggableOptions.IsDraggable.GetType() };
				}
				else
				{
					array = new object[9] { draggableOptions.IsDraggable, draggableOptions.SnapTo, draggableOptions.SnapMode, draggableOptions.SnapTolerance, draggableOptions.RevertMode, draggableOptions.RevertDuration, draggableOptions.Xgrid, draggableOptions.Ygrid, draggableOptions.AllowNegativeAxes };
					array2 = new Type[9]
					{
						draggableOptions.IsDraggable.GetType(),
						draggableOptions.SnapTo.GetType(),
						draggableOptions.SnapMode.GetType(),
						draggableOptions.SnapTolerance.GetType(),
						draggableOptions.RevertMode.GetType(),
						draggableOptions.RevertDuration.GetType(),
						draggableOptions.Xgrid.GetType(),
						draggableOptions.Ygrid.GetType(),
						draggableOptions.AllowNegativeAxes.GetType()
					};
				}
				return new InstanceDescriptor(typeof(DraggableOptions).GetConstructor(array2), array);
			}
			return null;
		}

		/// 
		/// converts the object to string.
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objValue"></param>
		/// </returns>
		private new string ConvertToString(ITypeDescriptorContext objContext, object value)
		{
			if (value is DraggableOptions draggableOptions)
			{
				return draggableOptions.ToString();
			}
			return "";
		}

		/// 
		/// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
		/// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
		/// 
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.
		/// </returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(value);
		}

		/// 
		/// Returns whether this object supports properties, using the specified context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// 
		/// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
		/// </returns>
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
