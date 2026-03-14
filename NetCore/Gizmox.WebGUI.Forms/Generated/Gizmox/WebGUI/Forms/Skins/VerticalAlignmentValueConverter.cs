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

namespace Gizmox.WebGUI.Forms.Skins
{
/// 
	/// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values to and from various other representations.
	/// </summary>
	[Serializable]
	public class VerticalAlignmentValueConverter : TypeConverter
	{
		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaddingConverter"></see> class. 
		/// </summary>
		public VerticalAlignmentValueConverter()
		{
		}

		/// 
		/// Returns whether this converter can convert the object to the specified type, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
		/// 
		/// true if this converter can perform the conversion; otherwise, false.
		/// </returns>
		public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
		{
			if (objDestinationType == typeof(string) || objDestinationType == typeof(int) || objDestinationType == typeof(VerticalAlignment))
			{
				return true;
			}
			return base.CanConvertTo(objContext, objDestinationType);
		}

		/// 
		/// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
		/// 
		/// true if this converter can perform the conversion; otherwise, false.
		/// </returns>
		public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
		{
			if (objSourceType == typeof(string) || objSourceType == typeof(int) || objSourceType == typeof(VerticalAlignment))
			{
				return true;
			}
			return base.CanConvertFrom(objContext, objSourceType);
		}

		/// 
		/// Converts the given object to the type of this converter, using the specified context and culture information.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
		/// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
		/// 
		/// An <see cref="T:System.Object" /> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
		public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
		{
			if (objValue is string || objValue is int)
			{
				string value = objValue.ToString();
				if (!string.IsNullOrEmpty(value))
				{
					if (Enum.IsDefined(typeof(VerticalAlignment), value))
					{
						return new VerticalAlignmentValue((VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), value, ignoreCase: true));
					}
					throw new Exception("Illegal vertical alignment value.");
				}
			}
			else if (objValue is VerticalAlignment)
			{
				return new VerticalAlignmentValue((VerticalAlignment)objValue);
			}
			return base.ConvertFrom(objContext, objCulture, objValue);
		}

		/// 
		/// Converts the given value object to the specified type, using the specified context and culture information.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
		/// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
		/// <param name="objDestinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
		/// 
		/// An <see cref="T:System.Object" /> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="objDestinationType" /> parameter is null. </exception>
		/// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
		public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (objDestinationType == typeof(string))
			{
				if (objValue is VerticalAlignmentValue verticalAlignmentValue)
				{
					return verticalAlignmentValue.ToString();
				}
			}
			else if (objDestinationType == typeof(VerticalAlignment) && objValue is VerticalAlignmentValue verticalAlignmentValue2)
			{
				return verticalAlignmentValue2.VerticalAlignment;
			}
			return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
		}

		/// 
		/// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
		/// 
		/// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
		/// </returns>
		public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
		{
			VerticalAlignmentValue verticalAlignmentValue = (VerticalAlignmentValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);
			int num = (int)objPropertyValues["VerticalAlignment"];
			return Activator.CreateInstance(verticalAlignmentValue.GetType(), num);
		}

		/// 
		/// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// 
		/// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
		/// </returns>
		public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
		{
			return true;
		}

		/// 
		/// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
		/// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
		/// 
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
		/// </returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(VerticalAlignmentValue), arrAttributes);
			string[] names = new string[1] { "VerticalAlignment" };
			return properties.Sort(names);
		}

		/// 
		/// Returns whether this object supports properties, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// 
		/// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
		/// </returns>
		public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
		{
			return true;
		}

		/// 
		/// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// 
		/// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> should be called to find a common set of values the object supports; otherwise, false.
		/// </returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
		{
			return true;
		}

		/// 
		/// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exclusive list of possible values, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// 
		/// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exhaustive list of possible values; false if other values are possible.
		/// </returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext objContext)
		{
			return true;
		}

		/// 
		/// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
		/// 
		/// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
		/// </returns>
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
		{
			return new StandardValuesCollection(Enum.GetValues(typeof(VerticalAlignment)));
		}
	}
}
