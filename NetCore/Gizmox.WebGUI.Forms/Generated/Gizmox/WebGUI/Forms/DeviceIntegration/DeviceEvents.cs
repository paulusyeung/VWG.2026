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
	/// Represents Device Events target object.
	/// </summary>
	[Serializable]
	public class DeviceEvents : WatchedDeviceComponent, IDeviceEvents
	{
		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjPauseEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjResumeEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjOnlineEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjOfflineEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjBackButtonEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjMenuButtonEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjSearchButtonEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjVolumeDownButtonEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjVolumeUpButtonEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjStartCallButtonEventStore;

		private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjEndCallButtonEventStore;

		private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryCriticalEventStore;

		private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryLowEventStore;

		private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryStatusEventStore;

		/// 
		/// Gets the pause event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> PauseEventStore
		{
			get
			{
				if (mobjPauseEventStore == null)
				{
					mobjPauseEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjPauseEventStore;
			}
		}

		/// 
		/// Gets the resume event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> ResumeEventStore
		{
			get
			{
				if (mobjResumeEventStore == null)
				{
					mobjResumeEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjResumeEventStore;
			}
		}

		/// 
		/// Gets the online event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> OnlineEventStore
		{
			get
			{
				if (mobjOnlineEventStore == null)
				{
					mobjOnlineEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjOnlineEventStore;
			}
		}

		/// 
		/// Gets the offline event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> OfflineEventStore
		{
			get
			{
				if (mobjOfflineEventStore == null)
				{
					mobjOfflineEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjOfflineEventStore;
			}
		}

		/// 
		/// Gets the back button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> BackButtonEventStore
		{
			get
			{
				if (mobjBackButtonEventStore == null)
				{
					mobjBackButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjBackButtonEventStore;
			}
		}

		/// 
		/// Gets the menu button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> MenuButtonEventStore
		{
			get
			{
				if (mobjMenuButtonEventStore == null)
				{
					mobjMenuButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjMenuButtonEventStore;
			}
		}

		/// 
		/// Gets the search button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> SearchButtonEventStore
		{
			get
			{
				if (mobjSearchButtonEventStore == null)
				{
					mobjSearchButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjSearchButtonEventStore;
			}
		}

		/// 
		/// Gets the volume down button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> VolumeDownButtonEventStore
		{
			get
			{
				if (mobjVolumeDownButtonEventStore == null)
				{
					mobjVolumeDownButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjVolumeDownButtonEventStore;
			}
		}

		/// 
		/// Gets the volume up button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> VolumeUpButtonEventStore
		{
			get
			{
				if (mobjVolumeUpButtonEventStore == null)
				{
					mobjVolumeUpButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjVolumeUpButtonEventStore;
			}
		}

		/// 
		/// Gets the start call button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> StartCallButtonEventStore
		{
			get
			{
				if (mobjStartCallButtonEventStore == null)
				{
					mobjStartCallButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjStartCallButtonEventStore;
			}
		}

		/// 
		/// Gets the end call button event store.
		/// </summary>
		private MultipleCallMethodStore<EmptyDeviceEventArgs> EndCallButtonEventStore
		{
			get
			{
				if (mobjEndCallButtonEventStore == null)
				{
					mobjEndCallButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjEndCallButtonEventStore;
			}
		}

		/// 
		/// Gets the battery critical event store.
		/// </summary>
		private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryCriticalEventStore
		{
			get
			{
				if (mobjBatteryCriticalEventStore == null)
				{
					mobjBatteryCriticalEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
				}
				return mobjBatteryCriticalEventStore;
			}
		}

		/// 
		/// Gets the battery low event store.
		/// </summary>
		private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryLowEventStore
		{
			get
			{
				if (mobjBatteryLowEventStore == null)
				{
					mobjBatteryLowEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
				}
				return mobjBatteryLowEventStore;
			}
		}

		/// 
		/// Gets the battery status event store.
		/// </summary>
		private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryStatusEventStore
		{
			get
			{
				if (mobjBatteryStatusEventStore == null)
				{
					mobjBatteryStatusEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
				}
				return mobjBatteryStatusEventStore;
			}
		}

		/// 
		/// Occurs when application is put into the background.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> Pause
		{
			add
			{
				PauseEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				PauseEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when application is retrieved from the background.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> Resume
		{
			add
			{
				ResumeEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				ResumeEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when application is online (connected to the Internet).
		/// </summary>
		public event Action<EmptyDeviceEventArgs> Online
		{
			add
			{
				OnlineEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				OnlineEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when application is offline (not connected to the Internet).
		/// </summary>
		public event Action<EmptyDeviceEventArgs> Offline
		{
			add
			{
				OfflineEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				OfflineEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when the user presses the back button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> BackButtonPressed
		{
			add
			{
				BackButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				BackButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when the user presses the menu button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> MenuButtonPressed
		{
			add
			{
				MenuButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				MenuButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when he user presses the search button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> SearchButtonPressed
		{
			add
			{
				SearchButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				SearchButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when  the user presses the start call button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> StartCallButtonPressed
		{
			add
			{
				StartCallButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				StartCallButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when the user presses the end call button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> EndCallButtonPressed
		{
			add
			{
				EndCallButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				EndCallButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when the user presses the volume down button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> VolumeDownButtonPressed
		{
			add
			{
				VolumeDownButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				VolumeDownButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when the user presses the volume up button.
		/// </summary>
		public event Action<EmptyDeviceEventArgs> VolumeUpButtonPressed
		{
			add
			{
				VolumeUpButtonEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				VolumeUpButtonEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when application detects the battery has reached the critical level threshold.
		/// </summary>
		public event Action<DeviceBatteryEventArgs> BatteryCritical
		{
			add
			{
				BatteryCriticalEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				BatteryCriticalEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when application detects the battery has reached the low level threshold.
		/// </summary>
		public event Action<DeviceBatteryEventArgs> BatteryLow
		{
			add
			{
				BatteryLowEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				BatteryLowEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Occurs when application detects a change in the battery status.
		/// </summary>
		public event Action<DeviceBatteryEventArgs> BatteryStatusChanged
		{
			add
			{
				BatteryStatusEventStore.AddMultipleCallMethod(value);
				Update();
			}
			remove
			{
				BatteryStatusEventStore.RemoveMultipleCallMethod(value);
				Update();
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.DeviceEvents" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public DeviceEvents(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("DeviceEvents_Initialize", ID);
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
			return "ES";
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			MultipleCallMethodStore<DeviceEventArgs> multipleCallMethodStore = null;
			MultipleCallMethodStore<DeviceEventArgs> multipleCallMethodStore2 = null;
			switch (type)
			{
			case "DPA":
				multipleCallMethodStore = PauseEventStore;
				break;
			case "DRE":
				multipleCallMethodStore = ResumeEventStore;
				break;
			case "DON":
				multipleCallMethodStore = OnlineEventStore;
				break;
			case "DOF":
				multipleCallMethodStore = OfflineEventStore;
				break;
			case "DBB":
				multipleCallMethodStore = BackButtonEventStore;
				break;
			case "DBC":
				multipleCallMethodStore2 = BatteryCriticalEventStore;
				break;
			case "DBL":
				multipleCallMethodStore2 = BatteryLowEventStore;
				break;
			case "DBS":
				multipleCallMethodStore2 = BatteryStatusEventStore;
				break;
			case "DMB":
				multipleCallMethodStore = MenuButtonEventStore;
				break;
			case "DSB":
				multipleCallMethodStore = SearchButtonEventStore;
				break;
			case "DSC":
				multipleCallMethodStore = StartCallButtonEventStore;
				break;
			case "DEC":
				multipleCallMethodStore = EndCallButtonEventStore;
				break;
			case "DVD":
				multipleCallMethodStore = VolumeDownButtonEventStore;
				break;
			case "DVU":
				multipleCallMethodStore = VolumeUpButtonEventStore;
				break;
			}
			if (multipleCallMethodStore2 != null)
			{
				DeviceBatteryEventArgs objArgs = DeviceBatteryEventArgs.ParseFromVWGEvent(objEvent);
				RaiseDeviceEvent(objArgs, multipleCallMethodStore2);
			}
			else if (multipleCallMethodStore != null)
			{
				EmptyDeviceEventArgs objArgs2 = EmptyDeviceEventArgs.ParseFromVWGEvent(objEvent);
				RaiseDeviceEvent(objArgs2, multipleCallMethodStore);
			}
		}

		/// 
		/// Raises the device event.
		/// </summary>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs" /> instance containing the event data.</param>
		/// <param name="objDeviceMethodStore">The obj device method store.</param>
		private void RaiseDeviceEvent(EmptyDeviceEventArgs objArgs, MultipleCallMethodStore<EmptyDeviceEventArgs> objDeviceMethodStore)
		{
			objDeviceMethodStore.InvokeMultipleCallMethods(objArgs);
		}

		/// 
		/// Raises the device event.
		/// </summary>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs" /> instance containing the event data.</param>
		/// <param name="objBatteryMethodStore">The obj battery method store.</param>
		private void RaiseDeviceEvent(DeviceBatteryEventArgs objArgs, MultipleCallMethodStore<DeviceBatteryEventArgs> objBatteryMethodStore)
		{
			objBatteryMethodStore.InvokeMultipleCallMethods(objArgs);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		public override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = new CriticalEventsData();
			if (PauseEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DPA");
			}
			if (ResumeEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DRE");
			}
			if (OnlineEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DON");
			}
			if (OfflineEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DOF");
			}
			if (BackButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DBB");
			}
			if (MenuButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DMB");
			}
			if (SearchButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DSB");
			}
			if (StartCallButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DSC");
			}
			if (EndCallButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DEC");
			}
			if (VolumeUpButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DVU");
			}
			if (VolumeDownButtonEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DVD");
			}
			if (BatteryCriticalEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DBC");
			}
			if (BatteryLowEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DBL");
			}
			if (BatteryStatusEventStore.HasEventListeners())
			{
				criticalEventsData.Set("DBS");
			}
			return criticalEventsData;
		}
	}
}
