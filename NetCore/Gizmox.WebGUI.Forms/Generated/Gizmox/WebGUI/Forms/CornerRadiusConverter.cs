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
	/// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> values to and from various other representations.
	/// </summary>
	[Serializable]
	public class CornerRadiusConverter : TypeConverter
	{
		/// 
		/// Provides a SkinValue implementation of corner
		/// </summary>
		[Serializable]
		internal class CornerRadiusSkinValue : SkinValue
		{
			/// 
			///
			/// </summary>
			private CornerRadius mobjValue;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CornerRadiusConverter.CornerRadiusSkinValue" /> class.
			/// </summary>
			/// <param name="objValue">The corner value.</param>
			public CornerRadiusSkinValue(CornerRadius objValue)
			{
				mobjValue = objValue;
			}

			public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
			{
				if (mobjValue.IsAll)
				{
					return $"{mobjValue.All}";
				}
				return $"{mobjValue.TopLeft} {mobjValue.TopRight} {mobjValue.BottomRight} {mobjValue.BottomLeft}";
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CornerConverter"></see> class. 
		/// </summary>
		public CornerRadiusConverter()
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
		/// <exception cref="T:System.ArgumentNullException">The destinationType parameter is null. </exception>
		public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (objDestinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (objDestinationType == typeof(SkinValue))
			{
				return new CornerRadiusSkinValue((CornerRadius)objValue);
			}
			if (objDestinationType == typeof(InstanceDescriptor) && objValue is CornerRadius)
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
			CornerRadius cornerRadius = (CornerRadius)objValue;
			Type[] types;
			object[] arguments;
			if (cornerRadius.ShouldSerializeAll())
			{
				types = new Type[1] { typeof(int) };
				arguments = new object[1] { cornerRadius.All };
				return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(types), arguments);
			}
			types = new Type[4]
			{
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int)
			};
			arguments = new object[4] { cornerRadius.TopLeft, cornerRadius.TopRight, cornerRadius.BottomRight, cornerRadius.BottomLeft };
			return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(types), arguments);
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
			CornerRadius cornerRadius = (CornerRadius)objContext.PropertyDescriptor.GetValue(objContext.Instance);
			int num = (int)objPropertyValues["All"];
			if (cornerRadius.All != num)
			{
				return new CornerRadius(num);
			}
			return new CornerRadius((int)objPropertyValues["TopLeft"], (int)objPropertyValues["TopRight"], (int)objPropertyValues["BottomRight"], (int)objPropertyValues["BottomLeft"]);
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
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(CornerRadius), arrAttributes);
			string[] names = new string[5] { "All", "TopLeft", "TopRight", "BottomRight", "BottomLeft" };
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
