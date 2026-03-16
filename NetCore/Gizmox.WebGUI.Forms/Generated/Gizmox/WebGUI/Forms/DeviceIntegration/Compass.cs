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
[Serializable]
	public class Compass : WatchedDeviceComponent, ICompass
	{
		private const int INTERNAL_ERROR = 0;

		private const int COMPASS_UNSUPPORTED = 20;

		/// 
		/// Compass single-call methods store.
		/// </summary>
		private SingleCallMethodStore<CompassEventArgs> mobjSingleCallMethodStore;

		/// 
		///  Compass multiple-call methods store.
		/// </summary>
		private MultipleCallMethodStore<CompassEventArgs> mobjMultipleCallMethodStore;

		/// 
		/// Gets the single call method store.
		/// </summary>
		private SingleCallMethodStore<CompassEventArgs> SingleCallMethodStore
		{
			get
			{
				if (mobjSingleCallMethodStore == null)
				{
					mobjSingleCallMethodStore = new SingleCallMethodStore<CompassEventArgs>();
				}
				return mobjSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the multiple call method store.
		/// </summary>
		private MultipleCallMethodStore<CompassEventArgs> MultipleCallMethodStore
		{
			get
			{
				if (mobjMultipleCallMethodStore == null)
				{
					mobjMultipleCallMethodStore = new MultipleCallMethodStore<CompassEventArgs>();
				}
				return mobjMultipleCallMethodStore;
			}
		}

		/// 
		/// Occurs when [compass heading changed].
		/// </summary>
		public event Action<CompassEventArgs> HeadingChanged
		{
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

		public Compass(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		/// 
		/// Raises the <see cref="E:CompassHeadingChanged" /> event.
		/// </summary>
		/// <param name="objArguments">The <see cref="T:Gizmox.WebGUI.Common.Device.Compass.CompassEventArgs" /> instance containing the event data.</param>
		private void OnHeadingChanged(CompassEventArgs objArguments)
		{
			MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);
		}

		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			CompassEventArgs argumentsFromEvent = GetArgumentsFromEvent(objEvent);
			if (argumentsFromEvent != null)
			{
				if (type == "CMP")
				{
					OnHeadingChanged(argumentsFromEvent);
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
		private CompassEventArgs GetArgumentsFromEvent(IEvent objEvent)
		{
			CompassEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError<CompassEventArgs>(objEvent, out objEventArgs))
			{
				string strTimestamp = string.Empty;
				if (objEvent["magneticHeading"] != null && CommonUtils.TryParse(objEvent["magneticHeading"], out double dblValue) && objEvent["trueHeading"] != null && CommonUtils.TryParse(objEvent["trueHeading"], out double dblValue2) && objEvent["headingAccuracy"] != null && CommonUtils.TryParse(objEvent["magneticHeading"], out double dblValue3))
				{
					if (objEvent["timeStamp"] != null)
					{
						strTimestamp = objEvent["timeStamp"];
					}
					objEventArgs = new CompassEventArgs(dblValue, dblValue2, dblValue3, strTimestamp);
				}
			}
			return objEventArgs;
		}

		/// 
		/// Gets the compass heading.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void GetCurrentHeading(Action<CompassEventArgs> objCallback)
		{
			string text = SingleCallMethodStore.StoreSingleCallMethod(objCallback);
			Invoke("DeviceIntegrator.Compass.getCurrentHeading", text);
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Compass_Initialize", ID);
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
			return "CMP";
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
				criticalEventsData.Set("DCO");
			}
			return criticalEventsData;
		}
	}
}
