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
	public class Camera : DeviceComponent, ICamera
	{
		private SingleCallMethodStore<CameraEventArgs> mobjCameraMethodStore;

		private SingleCallMethodStore<CameraEventArgs> mobjClearMethodStore;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Camera" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public Camera(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Camera_Initialize", ID);
		}

		/// 
		/// Cleans up the image files that were taken by the camera, that were stored in a temporary storage location.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void Cleanup(Action<CameraEventArgs> objCallback)
		{
			if (mobjClearMethodStore == null)
			{
				mobjClearMethodStore = new SingleCallMethodStore<CameraEventArgs>();
			}
			string text = mobjClearMethodStore.StoreSingleCallMethod("cln", objCallback);
			Invoke("DeviceIntegrator.Camera.cleanup", text);
		}

		/// 
		/// Gets A picture with given options.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void GetPicture(Action<CameraEventArgs> objCallback, CameraOptions objOptions)
		{
			if (mobjCameraMethodStore == null)
			{
				mobjCameraMethodStore = new SingleCallMethodStore<CameraEventArgs>();
			}
			string text = mobjCameraMethodStore.StoreSingleCallMethod("pic", objCallback);
			IClientJsonObject clientJsonObject = null;
			if (objOptions != null)
			{
				clientJsonObject = CommonUtils.GetClientJsonObject(objOptions);
			}
			Invoke("DeviceIntegrator.Camera.getPicture", text, clientJsonObject);
		}

		/// 
		/// Gets a picture with default options.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void GetPicture(Action<CameraEventArgs> objCallback)
		{
			GetPicture(objCallback, null);
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "CAM";
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			HandleEvent(objEvent);
		}

		private void HandleEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(type);
			string key = keyValuePair.Key;
			if (!(key == "pic"))
			{
				if (key == "cln")
				{
					CleanupEventArgs cleanupEventArgs = GetCleanupEventArgs(objEvent);
					if (mobjClearMethodStore.HasRegisteredMethod(keyValuePair.Value))
					{
						mobjClearMethodStore.InvokeSingleCallMethod(keyValuePair.Value, cleanupEventArgs);
					}
				}
			}
			else
			{
				CameraEventArgs cameraArgumentsFromEvent = GetCameraArgumentsFromEvent(objEvent);
				if (mobjCameraMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjCameraMethodStore.InvokeSingleCallMethod(keyValuePair.Value, cameraArgumentsFromEvent);
				}
			}
		}

		/// 
		/// Gets the cleanup event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private CleanupEventArgs GetCleanupEventArgs(IEvent objEvent)
		{
			CleanupEventArgs objEventArgs = null;
			if (!CameraBaseEventArgs.TryGetCameraError(objEvent, out objEventArgs))
			{
				objEventArgs = new CleanupEventArgs();
			}
			return objEventArgs;
		}

		/// 
		/// Gets the camera arguments from event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private CameraEventArgs GetCameraArgumentsFromEvent(IEvent objEvent)
		{
			CameraEventArgs objEventArgs = null;
			if (!CameraBaseEventArgs.TryGetCameraError(objEvent, out objEventArgs))
			{
				string value = objEvent.Value;
				string text = objEvent["FileUri"];
				if (!string.IsNullOrEmpty(value) || !string.IsNullOrEmpty(text))
				{
					objEventArgs = new CameraEventArgs(text, value);
				}
			}
			return objEventArgs;
		}
	}
}
