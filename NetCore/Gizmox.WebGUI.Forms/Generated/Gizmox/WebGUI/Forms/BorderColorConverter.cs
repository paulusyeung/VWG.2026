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
	/// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> values to and from various other representations.
	/// </summary>
	[Serializable]
	public class BorderColorConverter : TypeConverter
	{
		/// 
		/// Provides a SkinValue implementation of color
		/// </summary>
		[Serializable]
		internal class BorderColorSkinValue : SkinValue
		{
			/// 
			///
			/// </summary>
			private BorderColor mobjValue;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColorConverter.BorderColorSkinValue" /> class.
			/// </summary>
			/// <param name="objValue">The color value.</param>
			public BorderColorSkinValue(BorderColor objValue)
			{
				mobjValue = objValue;
			}

			/// 
			/// Gets the value.
			/// </summary>
			/// <param name="objContext">The current context.</param>
			/// </returns>
			public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
			{
				if (mobjValue.IsAll)
				{
					return $"{mobjValue.All}";
				}
				return $"{mobjValue.Top} {mobjValue.Right} {mobjValue.Bottom} {mobjValue.Left}";
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColorConverter"></see> class. 
		/// </summary>
		public BorderColorConverter()
		{
		}

		/// 
		/// Returns whether this converter can convert the object to the specified type, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
		/// true if this converter can perform the conversion; otherwise, false.</returns>
		public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
		{
			if (objDestinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			if (objDestinationType == typeof(SkinValue))
			{
				return true;
			}
			if (objDestinationType == typeof(string))
			{
				return true;
			}
			return base.CanConvertTo(objContext, objDestinationType);
		}

		/// 
		/// Converts the given object to the type of this converter, using the specified context and culture information.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"></see>. If null is passed, the current culture is assumed.</param>
		/// <param name="objValue">The <see cref="T:System.Object"></see> to convert.</param>
		/// <param name="objDestinationType">The <see cref="T:System.Type"></see> to convert the value parameter to.</param>
		/// 
		/// An <see cref="T:System.Object"></see> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
		/// <exception cref="T:System.ArgumentNullException">The objDestinationType parameter is null. </exception>
		public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (objDestinationType == null)
			{
				throw new ArgumentNullException("objDestinationType");
			}
			if (objDestinationType == typeof(SkinValue))
			{
				return new BorderColorSkinValue((BorderColor)objValue);
			}
			if (objDestinationType == typeof(string) && objValue is BorderColor)
			{
				BorderColor borderColor = (BorderColor)objValue;
				if (borderColor.ShouldSerializeAll())
				{
					return GetColorString(borderColor.All, objCulture);
				}
				return $"{GetColorString(borderColor.Left, objCulture)} {GetColorString(borderColor.Top, objCulture)} {GetColorString(borderColor.Right, objCulture)} {GetColorString(borderColor.Bottom, objCulture)}";
			}
			if (objDestinationType == typeof(InstanceDescriptor) && objValue is BorderColor)
			{
				return ConvertToInstanceDescriptor(objContext, objValue);
			}
			return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
		}

		/// 
		/// Convert to InstanceDescriptor
		/// </summary>
		/// 
		/// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
		/// </remarks>
		private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
		{
			BorderColor borderColor = (BorderColor)objValue;
			Type[] types;
			object[] arguments;
			if (borderColor.ShouldSerializeAll())
			{
				types = new Type[1] { typeof(Color) };
				arguments = new object[1] { borderColor.All };
				return new InstanceDescriptor(typeof(BorderColor).GetConstructor(types), arguments);
			}
			types = new Type[4]
			{
				typeof(Color),
				typeof(Color),
				typeof(Color),
				typeof(Color)
			};
			arguments = new object[4] { borderColor.Left, borderColor.Top, borderColor.Right, borderColor.Bottom };
			return new InstanceDescriptor(typeof(BorderColor).GetConstructor(types), arguments);
		}

		private object GetColorString(Color objColor, CultureInfo objCulture)
		{
			return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(null, objCulture, objColor);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
		{
			if (objSourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(objContext, objSourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
		{
			if (objValue is string)
			{
				string text = (string)objValue;
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = ",";
					if (objCulture != null)
					{
						text2 = objCulture.TextInfo.ListSeparator;
					}
					text = text.Replace(text2 + " ", text2);
					string[] array = text.Split(' ');
					if (array.Length == 1)
					{
						return new BorderColor(ConvertColor(array[0], objCulture));
					}
					if (array.Length == 2)
					{
						return new BorderColor(ConvertColor(array[0], objCulture), ConvertColor(array[1], objCulture), ConvertColor(array[1], objCulture), ConvertColor(array[1], objCulture));
					}
					if (array.Length == 3)
					{
						return new BorderColor(ConvertColor(array[0], objCulture), ConvertColor(array[1], objCulture), ConvertColor(array[2], objCulture), ConvertColor(array[2], objCulture));
					}
					if (array.Length == 4)
					{
						return new BorderColor(ConvertColor(array[0], objCulture), ConvertColor(array[1], objCulture), ConvertColor(array[2], objCulture), ConvertColor(array[3], objCulture));
					}
					return BorderColor.Empty;
				}
				return BorderColor.Empty;
			}
			return base.ConvertFrom(objContext, objCulture, objValue);
		}

		/// 
		/// Converts the color.
		/// </summary>
		/// <param name="strColor">Color in string format.</param>
		/// <param name="objCulture">The culture.</param>
		/// </returns>
		private Color ConvertColor(string strColor, CultureInfo objCulture)
		{
			return (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(null, objCulture, strColor);
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
			BorderColor borderColor = (BorderColor)objContext.PropertyDescriptor.GetValue(objContext.Instance);
			Color color = (Color)objPropertyValues["Left"];
			Color color2 = (Color)objPropertyValues["Top"];
			Color color3 = (Color)objPropertyValues["Right"];
			Color color4 = (Color)objPropertyValues["Bottom"];
			if (color == color3 && color3 == color2 && color2 == color4)
			{
				return new BorderColor(color);
			}
			return new BorderColor(color, color2, color3, color4);
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
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(BorderColor), arrAttributes);
			string[] names = new string[5] { "All", "Left", "Top", "Right", "Bottom" };
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
	}
}
