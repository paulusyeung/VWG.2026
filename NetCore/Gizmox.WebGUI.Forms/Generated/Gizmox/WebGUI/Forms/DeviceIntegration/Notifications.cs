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
	public class Notifications : DeviceComponent, INotifications
	{
		private SingleCallMethodStore<NotificationEventArgs> mobjAlertStore;

		private SingleCallMethodStore<NotificationEventArgs> mobjConfirmStore;

		private SingleCallMethodStore<NotificationEventArgs> mobjBeepStore;

		private SingleCallMethodStore<NotificationEventArgs> mobjVibrateStore;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Notifications" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public Notifications(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "NTF";
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(type);
			switch (keyValuePair.Key)
			{
			case "alert":
			{
				EmptyDeviceEventArgs args2 = new EmptyDeviceEventArgs();
				if (mobjAlertStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjAlertStore.InvokeSingleCallMethod(keyValuePair.Value, args2);
				}
				break;
			}
			case "confirm":
			{
				if (int.TryParse(objEvent["ButtonIndex"], out var result))
				{
					ConfirmEventArgs args = new ConfirmEventArgs(result);
					mobjConfirmStore.InvokeSingleCallMethod(keyValuePair.Value, args);
				}
				break;
			}
			case "beep":
				mobjBeepStore.InvokeSingleCallMethod(keyValuePair.Value, new EmptyDeviceEventArgs());
				break;
			case "vibrate":
				mobjVibrateStore.InvokeSingleCallMethod(keyValuePair.Value, new EmptyDeviceEventArgs());
				break;
			}
		}

		/// 
		/// Alerts the specified STR message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		public void Alert(string strMessage)
		{
			Alert(strMessage, null, mobjAlertStore.StoreSingleCallMethod("alert", GetNullAction()));
		}

		/// 
		/// Alerts the specified STR message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void Alert(string strMessage, AlertOptions objOptions, Action objCallback)
		{
			if (mobjAlertStore == null)
			{
				mobjAlertStore = new SingleCallMethodStore<NotificationEventArgs>();
			}
			Alert(strMessage, objOptions, mobjAlertStore.StoreSingleCallMethod("alert", objCallback));
		}

		/// 
		/// Alerts the specified STR message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		/// <param name="fncCallback">The FNC callback.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="arrCallbackParams">The arr callback params.</param>
		private void Alert(string strMessage, AlertOptions objOptions, string fncCallback)
		{
			Invoke("DeviceIntegrator.Notifications.alert", strMessage, fncCallback, CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Confirms the specified STR message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		public void Confirm(string strMessage)
		{
			Confirm(strMessage, null, GetNullAction());
		}

		/// 
		/// Confrims the specified STR message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void Confirm(string strMessage, ConfirmOptions objOptions, Action objCallback)
		{
			if (mobjConfirmStore == null)
			{
				mobjConfirmStore = new SingleCallMethodStore<NotificationEventArgs>();
			}
			Confirm(strMessage, objOptions, mobjConfirmStore.StoreSingleCallMethod("confirm", objCallback));
		}

		/// 
		/// Confirms the specified STR message.
		/// </summary>
		/// <param name="strMessage">The STR message.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="fncCallback">The FNC callback.</param>
		/// <param name="arrCallbackParams">The arr callback params.</param>
		private void Confirm(string strMessage, ConfirmOptions objOptions, string fncCallback)
		{
			Invoke("DeviceIntegrator.Notifications.confirm", strMessage, fncCallback, CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Beeps the specified int times.
		/// </summary>
		/// <param name="intTimes">The int times.</param>
		public void Beep(int intTimes)
		{
			Beep(intTimes, GetNullAction());
		}

		/// 
		/// Beeps the specified int times.
		/// </summary>
		/// <param name="intTimes">The int times.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void Beep(int intTimes, Action objCallback)
		{
			if (mobjBeepStore == null)
			{
				mobjBeepStore = new SingleCallMethodStore<NotificationEventArgs>();
			}
			Beep(intTimes, mobjBeepStore.StoreSingleCallMethod("beep", objCallback));
		}

		/// 
		/// Beeps the specified int times.
		/// </summary>
		/// <param name="intTimes">The int times.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="fncCallback">The FNC callback.</param>
		/// <param name="arrCallbackParams">The arr callback params.</param>
		public void Beep(int intTimes, string fncCallback)
		{
			SingleNumericParameterInvoker("beep", intTimes, fncCallback);
		}

		/// 
		/// Vibrates the specified int duiration in milliseconds.
		/// </summary>
		/// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
		public void Vibrate(int intDuirationInMilliseconds)
		{
			Vibrate(intDuirationInMilliseconds, GetNullAction());
		}

		/// 
		/// Beeps the specified int times.
		/// </summary>
		/// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void Vibrate(int intDuirationInMilliseconds, Action objCallback)
		{
			if (mobjVibrateStore == null)
			{
				mobjVibrateStore = new SingleCallMethodStore<NotificationEventArgs>();
			}
			Vibrate(intDuirationInMilliseconds, mobjVibrateStore.StoreSingleCallMethod("vibrate", objCallback));
		}

		/// 
		/// Beeps the specified int times.
		/// </summary>
		/// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="fncCallback">The FNC callback.</param>
		/// <param name="arrCallbackParams">The arr callback params.</param>
		private void Vibrate(int intDuirationInMilliseconds, string fncCallback)
		{
			SingleNumericParameterInvoker("vibrate", intDuirationInMilliseconds, fncCallback);
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Notifications_Initialize", ID);
		}

		/// 
		/// Singles the numeric parameter invoker.
		/// </summary>
		/// <param name="strFunction">The STR function.</param>
		/// <param name="intNumericParameter">The int numeric parameter.</param>
		/// <param name="objClientContext">The obj client context.</param>
		/// <param name="fncCallback">The FNC callback.</param>
		/// <param name="arrCallbackParams">The arr callback params.</param>
		private void SingleNumericParameterInvoker(string strFunction, int intNumericParameter, string fncCallback)
		{
			Invoke(arrArguments: new object[2] { intNumericParameter, fncCallback }, strMethodName: $"DeviceIntegrator.Notifications.{strFunction}");
		}

		/// 
		/// This method is used just for preventing conflicting between overload methods.
		/// </summary>
		private Action GetNullAction()
		{
			return null;
		}
	}
}
