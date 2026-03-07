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
	///
	/// </summary>
	[Serializable]
	public class Geolocation : WatchedDeviceComponent, IGeolocation
	{
		private const int PERMISSION_DENIED = 1;

		private const int POSITION_UNAVAILABLE = 2;

		private const int TIMEOUT = 3;

		/// 
		/// Geolocation single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GeolocationEventArgs> mobjSingleCallMethodStore;

		/// 
		///  Geolocation multiple-call methods store.
		/// </summary>
		private MultipleCallMethodStore<GeolocationEventArgs> mobjMultipleCallMethodStore;

		/// 
		/// Gets the single call method store.
		/// </summary>
		private SingleCallMethodStore<GeolocationEventArgs> SingleCallMethodStore {
			get
			{
				if (mobjSingleCallMethodStore == null)
				{
					mobjSingleCallMethodStore = new SingleCallMethodStore<GeolocationEventArgs>();
				}
				return mobjSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the multiple call method store.
		/// </summary>
		private MultipleCallMethodStore<GeolocationEventArgs> MultipleCallMethodStore {
			get
			{
				if (mobjMultipleCallMethodStore == null)
				{
					mobjMultipleCallMethodStore = new MultipleCallMethodStore<GeolocationEventArgs>();
				}
				return mobjMultipleCallMethodStore;
			}
		}

		/// 
		/// Occurs when [Geolocation position changed].
		/// </summary>
		public event Action<GeolocationEventArgs> PositionChanged {
			add
			{
				MultipleCallMethodStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				MultipleCallMethodStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Geolocation" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public Geolocation(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		/// 
		/// Raises the <see cref="E:PositionChanged" /> event.
		/// </summary>
		/// <param name="objArguments">The <see cref="T:Gizmox.WebGUI.Common.Device.Geolocation.GeolocationEventArgs" /> instance containing the event data.</param>
		private void OnPositionChanged(GeolocationEventArgs objArguments)
		{
			MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			GeolocationEventArgs argumentsFromEvent = GetArgumentsFromEvent(objEvent);
			if (argumentsFromEvent != null)
			{
				if (type == "GPS")
				{
					OnPositionChanged(argumentsFromEvent);
				}
				else if (!string.IsNullOrEmpty(type) && SingleCallMethodStore.HasRegisteredMethod(type))
				{
					SingleCallMethodStore.InvokeSingleCallMethod(type, argumentsFromEvent);
				}
			}
		}

		/// 
		/// Gets the arguments from event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GeolocationEventArgs GetArgumentsFromEvent(IEvent objEvent)
		{
			GeolocationEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs))
			{
				string empty = string.Empty;
				objEventArgs = new GeolocationEventArgs();
				if (objEvent["latitude"] != null && CommonUtils.TryParse(objEvent["latitude"], out double dblValue))
				{
					objEventArgs.Latitude = dblValue;
				}
				if (objEvent["longitude"] != null && CommonUtils.TryParse(objEvent["longitude"], out double dblValue2))
				{
					objEventArgs.Longitude = dblValue2;
				}
				if (objEvent["altitude"] != null && CommonUtils.TryParse(objEvent["altitude"], out double dblValue3))
				{
					objEventArgs.Altitude = dblValue3;
				}
				if (objEvent["altitudeAccuracy"] != null && CommonUtils.TryParse(objEvent["altitudeAccuracy"], out double dblValue4))
				{
					objEventArgs.AltitudeAccuracy = dblValue4;
				}
				if (objEvent["accuracy"] != null && CommonUtils.TryParse(objEvent["accuracy"], out double dblValue5))
				{
					objEventArgs.Accuracy = dblValue5;
				}
				if (objEvent["heading"] != null && CommonUtils.TryParse(objEvent["heading"], out double dblValue6))
				{
					objEventArgs.Heading = dblValue6;
				}
				if (objEvent["speed"] != null && CommonUtils.TryParse(objEvent["speed"], out double dblValue7))
				{
					objEventArgs.Speed = dblValue7;
				}
			}
			return objEventArgs;
		}

		/// 
		/// Gets the Geolocation position with default options.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void GetPosition(Action objCallback)
		{
			string value = SingleCallMethodStore.StoreSingleCallMethod(objCallback);
			ArrayList arrayList = new ArrayList();
			arrayList.Add(value);
			Invoke("DeviceIntegrator.Geolocation.getPosition", arrayList.ToArray());
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Geolocation_Initialize", ID);
		}

		/// 
		/// Renders the attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		internal override void RenderAttributes(IContext objContext, IResponseWriter objWriter)
		{
			if (objWriter is IAttributeWriter attributeWriter)
			{
				attributeWriter.WriteAttributeString("E", GetCriticalEventsData().ToClientString());
			}
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "GPS";
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		public override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = new CriticalEventsData();
			if (MultipleCallMethodStore.HasEventListeners())
			{
				criticalEventsData.Set("DGE");
			}
			return criticalEventsData;
		}
	}
}
