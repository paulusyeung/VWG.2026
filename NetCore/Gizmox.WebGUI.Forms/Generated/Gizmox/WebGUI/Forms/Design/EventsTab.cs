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

namespace Gizmox.WebGUI.Forms.Design
{
	/// Provides a <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> that can display events for selection and linking.</summary>
	[Serializable]
	public class EventsTab : PropertyTab
	{
		private IDesignerHost mobjCurrentHost;

		private IServiceProvider mobjServiceProvider;

		private bool mblnSunkEvent;

		/// Gets the Help keyword for the tab.</summary>
		/// The Help keyword for the tab.</returns>
		public override string HelpKeyword => "Events";

		/// Gets the name of the tab.</summary>
		/// The name of the tab.</returns>
		public override string TabName => SR.GetString("PBRSToolTipEvents");

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.EventsTab"></see> class.</summary>
		/// <param name="objServiceProvider">An <see cref="T:System.IServiceProvider"></see> to use. </param>
		public EventsTab(IServiceProvider objServiceProvider)
		{
			mobjServiceProvider = objServiceProvider;
		}

		/// Gets a value indicating whether the specified object can be extended.</summary>
		/// true if the specified object can be extended; otherwise, false.</returns>
		/// <param name="objExtendee">The object to test for extensibility. </param>
		public override bool CanExtend(object objExtendee)
		{
			return !Marshal.IsComObject(objExtendee);
		}

		/// Gets the default property from the specified object.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> indicating the default property.</returns>
		/// <param name="obj">The object to retrieve the default property of. </param>
		public override PropertyDescriptor GetDefaultProperty(object obj)
		{
			IEventBindingService eventPropertyService = GetEventPropertyService(obj, null);
			if (eventPropertyService != null)
			{
				EventDescriptor defaultEvent = TypeDescriptor.GetDefaultEvent(obj);
				if (defaultEvent != null)
				{
					return eventPropertyService.GetEventProperty(defaultEvent);
				}
			}
			return null;
		}

		private IEventBindingService GetEventPropertyService(object obj, ITypeDescriptorContext objContext)
		{
			IEventBindingService eventBindingService = null;
			if (!mblnSunkEvent)
			{
				IDesignerEventService designerEventService = (IDesignerEventService)mobjServiceProvider.GetService(typeof(IDesignerEventService));
				if (designerEventService != null)
				{
					designerEventService.ActiveDesignerChanged += OnActiveDesignerChanged;
				}
				mblnSunkEvent = true;
			}
			if (eventBindingService == null && mobjCurrentHost != null)
			{
				eventBindingService = (IEventBindingService)mobjCurrentHost.GetService(typeof(IEventBindingService));
			}
			if (eventBindingService == null && obj is IComponent)
			{
				ISite site = ((IComponent)obj).Site;
				if (site != null)
				{
					eventBindingService = (IEventBindingService)site.GetService(typeof(IEventBindingService));
				}
			}
			if (eventBindingService == null && objContext != null)
			{
				eventBindingService = (IEventBindingService)objContext.GetService(typeof(IEventBindingService));
			}
			return eventBindingService;
		}

		/// Gets all the properties of the event tab that match the specified attributes.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties. This will be an empty <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> if the component does not implement an event service.</returns>
		/// <param name="arrAttributes">An array of <see cref="T:System.Attribute"></see> that indicates the attributes of the event properties to retrieve. </param>
		/// <param name="objComponent">The component to retrieve the properties of. </param>
		public override PropertyDescriptorCollection GetProperties(object objComponent, Attribute[] arrAttributes)
		{
			return GetProperties(null, objComponent, arrAttributes);
		}

		/// Gets all the properties of the event tab that match the specified attributes and context.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties. This will be an empty <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> if the component does not implement an event service.</returns>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain context information. </param>
		/// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the event properties to retrieve. </param>
		/// <param name="objComponent">The component to retrieve the properties of. </param>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objComponent, Attribute[] arrAttributes)
		{
			IEventBindingService eventPropertyService = GetEventPropertyService(objComponent, objContext);
			if (eventPropertyService == null)
			{
				return new PropertyDescriptorCollection(null);
			}
			EventDescriptorCollection events = TypeDescriptor.GetEvents(objComponent, arrAttributes);
			PropertyDescriptorCollection propertyDescriptorCollection = eventPropertyService.GetEventProperties(events);
			Attribute[] array = new Attribute[arrAttributes.Length + 1];
			Array.Copy(arrAttributes, 0, array, 0, arrAttributes.Length);
			array[arrAttributes.Length] = DesignerSerializationVisibilityAttribute.Content;
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objComponent, array);
			if (properties.Count > 0)
			{
				ArrayList arrayList = null;
				for (int i = 0; i < properties.Count; i++)
				{
					PropertyDescriptor propertyDescriptor = properties[i];
					if (!propertyDescriptor.Converter.GetPropertiesSupported())
					{
						continue;
					}
					object value = propertyDescriptor.GetValue(objComponent);
					EventDescriptorCollection events2 = TypeDescriptor.GetEvents(value, arrAttributes);
					if (events2.Count > 0)
					{
						if (arrayList == null)
						{
							arrayList = new ArrayList();
						}
						propertyDescriptor = TypeDescriptor.CreateProperty(propertyDescriptor.ComponentType, propertyDescriptor, MergablePropertyAttribute.No);
						arrayList.Add(propertyDescriptor);
					}
				}
				if (arrayList != null)
				{
					PropertyDescriptor[] array2 = new PropertyDescriptor[arrayList.Count];
					arrayList.CopyTo(array2, 0);
					PropertyDescriptor[] array3 = new PropertyDescriptor[propertyDescriptorCollection.Count + array2.Length];
					propertyDescriptorCollection.CopyTo(array3, 0);
					Array.Copy(array2, 0, array3, propertyDescriptorCollection.Count, array2.Length);
					propertyDescriptorCollection = new PropertyDescriptorCollection(array3);
				}
			}
			return propertyDescriptorCollection;
		}

		private void OnActiveDesignerChanged(object sender, ActiveDesignerEventArgs adevent)
		{
			mobjCurrentHost = adevent.NewDesigner;
		}
	}
}
