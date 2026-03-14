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
/// Provides a base class for property tabs.</summary>
	[Serializable]
	public abstract class PropertyTab : IExtenderProvider
	{
		private Bitmap mobjBitmap;

		private bool mblnCheckedBmp;

		private object[] marrComponents;

		/// Gets the bitmap that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</summary>
		/// The <see cref="T:System.Drawing.Bitmap"></see> to display for the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</returns>
		public virtual Bitmap Bitmap
		{
			get
			{
				if (!mblnCheckedBmp && mobjBitmap == null)
				{
					string resource = GetType().Name + ".bmp";
					try
					{
						mobjBitmap = new Bitmap(GetType(), resource);
					}
					catch (Exception)
					{
					}
					mblnCheckedBmp = true;
				}
				return mobjBitmap;
			}
		}

		/// Gets or sets the array of components the property tab is associated with.</summary>
		/// The array of components the property tab is associated with.</returns>
		public virtual object[] Components
		{
			get
			{
				return marrComponents;
			}
			set
			{
				marrComponents = value;
			}
		}

		/// Gets the Help keyword that is to be associated with this tab.</summary>
		/// The Help keyword to be associated with this tab.</returns>
		public virtual string HelpKeyword => TabName;

		/// Gets the name for the property tab.</summary>
		/// The name for the property tab.</returns>
		public abstract string TabName { get; }

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> class.</summary>
		protected PropertyTab()
		{
		}

		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> can display properties for the specified component.</summary>
		/// true if the object can be extended; otherwise, false.</returns>
		/// <param name="objExtendee">The object to test. </param>
		public virtual bool CanExtend(object objExtendee)
		{
			return true;
		}

		/// Releases all the resources used by the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</summary>
		public virtual void Dispose()
		{
			Dispose(blnDisposing: true);
			GC.SuppressFinalize(this);
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> and optionally releases the managed resources.</summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
		protected virtual void Dispose(bool blnDisposing)
		{
			if (blnDisposing && mobjBitmap != null)
			{
				mobjBitmap.Dispose();
				mobjBitmap = null;
			}
		}

		/// Allows a <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> to attempt to free resources and perform other cleanup operations before the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> is reclaimed by garbage collection.</summary>
		~PropertyTab()
		{
			Dispose(blnDisposing: false);
		}

		/// Gets the default property of the specified component.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that represents the default property.</returns>
		/// <param name="objComponent">The component to retrieve the default property of. </param>
		public virtual PropertyDescriptor GetDefaultProperty(object objComponent)
		{
			return TypeDescriptor.GetDefaultProperty(objComponent);
		}

		/// Gets the properties of the specified component.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties of the component.</returns>
		/// <param name="objComponent">The component to retrieve the properties of. </param>
		public virtual PropertyDescriptorCollection GetProperties(object objComponent)
		{
			return GetProperties(objComponent, null);
		}

		/// Gets the properties of the specified component that match the specified attributes.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties.</returns>
		/// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the properties to retrieve. </param>
		/// <param name="objComponent">The component to retrieve properties from. </param>
		public abstract PropertyDescriptorCollection GetProperties(object objComponent, Attribute[] arrAttributes);

		/// Gets the properties of the specified component that match the specified attributes and context.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties matching the specified context and attributes.</returns>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context to retrieve properties from. </param>
		/// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the properties to retrieve. </param>
		/// <param name="objComponent">The component to retrieve properties from. </param>
		public virtual PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objComponent, Attribute[] arrAttributes)
		{
			return GetProperties(objComponent, arrAttributes);
		}
	}
}
