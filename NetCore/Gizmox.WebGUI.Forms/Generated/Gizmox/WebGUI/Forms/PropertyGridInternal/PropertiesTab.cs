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

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
	/// 
	/// Represents the Properties tab on a PropertyGrid control.
	/// </summary>
	[Serializable]
	public class PropertiesTab : PropertyTab
	{
		/// 
		/// Gets the Help keyword that is to be associated with this tab.
		/// </summary>
		/// </value>
		/// The string vs.properties.</returns>
		public override string HelpKeyword => "vs.properties";

		/// Gets the name of the Properties tab.</summary>
		/// The string Properties.</returns>
		public override string TabName => SR.GetString("PBRSToolTipProperties");

		/// 
		/// Gets the default Property Descriptor.
		/// </summary>
		/// <param name="objObject">The obj object.</param>
		/// </returns>
		public override PropertyDescriptor GetDefaultProperty(object objObject)
		{
			PropertyDescriptor defaultProperty = base.GetDefaultProperty(objObject);
			if (defaultProperty == null)
			{
				PropertyDescriptorCollection properties = GetProperties(objObject);
				if (properties == null)
				{
					return defaultProperty;
				}
				for (int i = 0; i < properties.Count; i++)
				{
					if ("Name".Equals(properties[i].Name))
					{
						return properties[i];
					}
				}
			}
			return defaultProperty;
		}

		/// 
		/// Returns a collection of property descriors
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="arrAttributes">The arr attributes.</param>
		/// </returns>
		public override PropertyDescriptorCollection GetProperties(object objComponent, Attribute[] arrAttributes)
		{
			return GetProperties(null, objComponent, arrAttributes);
		}

		/// 
		/// Returns a collection of property descriors
		/// </summary>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objComponent, Attribute[] arrAttributes)
		{
			if (arrAttributes == null)
			{
				arrAttributes = new Attribute[1] { BrowsableAttribute.Yes };
			}
			if (CommonUtils.IsEnvironmentSecurityPermitted)
			{
				Attribute[] array = new Attribute[arrAttributes.Length + 1];
				arrAttributes.CopyTo(array, 0);
				array[array.Length - 1] = LimitedTrustBrowsableAttribute.Yes;
				arrAttributes = array;
			}
			if (objContext != null)
			{
				TypeConverter typeConverter = ((objContext.PropertyDescriptor == null) ? TypeDescriptor.GetConverter(objComponent) : objContext.PropertyDescriptor.Converter);
				if (typeConverter != null && typeConverter.GetPropertiesSupported(objContext))
				{
					return typeConverter.GetProperties(objContext, objComponent, arrAttributes);
				}
			}
			return TypeDescriptor.GetProperties(objComponent, arrAttributes);
		}
	}
}
