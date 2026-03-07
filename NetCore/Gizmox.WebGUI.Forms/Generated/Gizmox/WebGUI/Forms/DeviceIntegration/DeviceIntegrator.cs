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

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
	/// 
	/// Represents default device integrator implemented by PhoneGap
	/// </summary>
	[Serializable]
	[Skin(typeof(DeviceIntegratorSkin))]
	public class DeviceIntegrator : RegisteredComponent, ISkinable, IDeviceIntegrator, IRenderableComponent
	{
		/// 
		///
		/// </summary>
		public static class ConnectionType
		{
			public const string TYPE_UNKNOWN = "unknown";

			public const string TYPE_ETHERNET = "ethernet";

			public const string TYPE_WIFI = "wifi";

			public const string TYPE_CELL_2G = "2g";

			public const string TYPE_CELL_3G = "3g";

			public const string TYPE_CELL_4G = "4g";

			public const string TYPE_NONE = "none";
		}

		private Accelerometer mobjAccelerometer;

		private Camera mobjCamera;

		private Compass mobjCompass;

		private Geolocation mobjGeolocation;

		private Notifications mobjNotifications;

		private DeviceEvents mobjEvents;

		private FileManager mobjFileManager;

		private Contacts mobjContacts;

		private Connection mobjConnection;

		private DeviceInfo mobjDeviceInfo;

		private DeviceMedia mobjMedia;

		private Globalization mobjGlobalizaion;

		private Capture mobjCapture;

		private Splashscreen mobjSplashscreen;

		private Storage mobjStorage;

		private List<object> marrDeviceComponents = new List<object>();

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// 
		/// The theme related to the skinable component.
		/// </value>
		public string Theme
		{
			get
			{
				if (VWGContext.Current != null)
				{
					return VWGContext.Current.CurrentTheme;
				}
				return null;
			}
		}

		/// 
		/// Gets the current application context.
		/// </summary>
		public override IContext Context => VWGContext.Current;

		/// 
		/// Gets the accelerometer.
		/// </summary>
		public IAccelerometer Accelerometer => mobjAccelerometer;

		/// 
		/// Gets the camera.
		/// </summary>
		public ICamera Camera => mobjCamera;

		/// 
		/// Gets the compass.
		/// </summary>
		public ICompass Compass => mobjCompass;

		/// 
		/// Gets the geolocation.
		/// </summary>
		public IGeolocation Geolocation => mobjGeolocation;

		/// 
		/// Gets the notifications.
		/// </summary>
		public INotifications Notifications => mobjNotifications;

		/// 
		/// Gets the file manager.
		/// </summary>
		public IFileManagement FileManager => mobjFileManager;

		/// 
		/// Gets the client events.
		/// </summary>
		public IDeviceEvents Events => mobjEvents;

		/// 
		/// Gets the connection.
		/// </summary>
		public IConnection Connection => mobjConnection;

		/// 
		/// Gets the Device Info.
		/// </summary>
		public IDeviceInfo DeviceInfo => mobjDeviceInfo;

		/// 
		/// Gets the contacts.
		/// </summary>
		public IContacts Contacts => mobjContacts;

		/// 
		/// Gets the Device Info.
		/// </summary>
		public IDeviceMedia Media => mobjMedia;

		/// 
		/// Gets the device storage.
		/// </summary>
		public IStorage Storage => mobjStorage;

		/// 
		/// Gets the Capture.
		/// </summary>
		public ICapture Capture => mobjCapture;

		/// 
		/// Gets the globalization.
		/// </summary>
		public IGlobalization Globalization => mobjGlobalizaion;

		/// 
		/// Gets the splashscreen.
		/// </summary>
		public ISplashscreen Splashscreen => mobjSplashscreen;

		/// 
		/// Initializes a new instance of the <see cref="!:PhonegapIntegrator" /> class.
		/// </summary>
		public DeviceIntegrator()
		{
			mobjAccelerometer = new Accelerometer(this);
			marrDeviceComponents.Add(mobjAccelerometer);
			mobjCamera = new Camera(this);
			marrDeviceComponents.Add(mobjCamera);
			mobjCompass = new Compass(this);
			marrDeviceComponents.Add(mobjCompass);
			mobjGeolocation = new Geolocation(this);
			marrDeviceComponents.Add(mobjGeolocation);
			mobjNotifications = new Notifications(this);
			marrDeviceComponents.Add(mobjNotifications);
			mobjEvents = new DeviceEvents(this);
			marrDeviceComponents.Add(mobjEvents);
			mobjFileManager = new FileManager(this);
			marrDeviceComponents.Add(mobjFileManager);
			mobjContacts = new Contacts(this);
			marrDeviceComponents.Add(mobjContacts);
			mobjConnection = new Connection(this);
			marrDeviceComponents.Add(mobjConnection);
			mobjDeviceInfo = new DeviceInfo(this);
			marrDeviceComponents.Add(mobjDeviceInfo);
			mobjMedia = new DeviceMedia(this);
			marrDeviceComponents.Add(mobjMedia);
			mobjGlobalizaion = new Globalization(this);
			marrDeviceComponents.Add(mobjGlobalizaion);
			mobjCapture = new Capture(this);
			marrDeviceComponents.Add(mobjCapture);
			mobjSplashscreen = new Splashscreen(this);
			marrDeviceComponents.Add(mobjSplashscreen);
			mobjStorage = new Storage(this);
			marrDeviceComponents.Add(mobjStorage);
		}

		public void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (DeviceComponent marrDeviceComponent in marrDeviceComponents)
			{
				marrDeviceComponent.OnRendering(objContext, objWriter, lngRequestID);
			}
			if (IsDirty(lngRequestID))
			{
				if (!base.IsRegistered)
				{
					RegisterSelf();
				}
				objWriter.WriteStartElement("DI");
				(objWriter as IAttributeWriter).WriteAttributeString("Id", ID);
				foreach (DeviceComponent marrDeviceComponent2 in marrDeviceComponents)
				{
					marrDeviceComponent2.RenderComponent(objContext, objWriter, lngRequestID);
				}
				objWriter.WriteEndElement();
			}
			foreach (DeviceComponent marrDeviceComponent3 in marrDeviceComponents)
			{
				marrDeviceComponent3.OnRendered(objContext, objWriter, lngRequestID);
			}
		}
	}
}
