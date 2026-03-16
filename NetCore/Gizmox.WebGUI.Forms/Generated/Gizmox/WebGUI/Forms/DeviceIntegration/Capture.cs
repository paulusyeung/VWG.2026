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
	public class Capture : DeviceComponent, ICapture
	{
		private SingleCallMethodStore<CaptureEventArgs> mobjCaptureEventArgsStore;

		private SingleCallMethodStore<MediaFileDataEventArgs> mobjMediaFileDataEventArgsStore;

		/// 
		/// Gets the capture event args store.
		/// </summary>
		internal SingleCallMethodStore<CaptureEventArgs> CaptureEventArgsStore
		{
			get
			{
				if (mobjCaptureEventArgsStore == null)
				{
					mobjCaptureEventArgsStore = new SingleCallMethodStore<CaptureEventArgs>();
				}
				return mobjCaptureEventArgsStore;
			}
		}

		/// 
		/// Gets the media file data event args store.
		/// </summary>
		internal SingleCallMethodStore<MediaFileDataEventArgs> MediaFileDataEventArgsStore
		{
			get
			{
				if (mobjMediaFileDataEventArgsStore == null)
				{
					mobjMediaFileDataEventArgsStore = new SingleCallMethodStore<MediaFileDataEventArgs>();
				}
				return mobjMediaFileDataEventArgsStore;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Capture" /> class.
		/// </summary>
		/// <param name="objPhonegapIntegrator">The obj phonegap integrator.</param>
		public Capture(DeviceIntegrator objPhonegapIntegrator)
			: base(objPhonegapIntegrator)
		{
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "CAP";
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Capture_Initialize", ID);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(objEvent.Type);
			if (string.IsNullOrEmpty(keyValuePair.Key))
			{
				CaptureEventArgs captureEventArgs = GetCaptureEventArgs(objEvent);
				mobjCaptureEventArgsStore.InvokeSingleCallMethod(objEvent.Type, captureEventArgs);
				return;
			}
			string key = keyValuePair.Key;
			if (key == "for")
			{
				MediaFileDataEventArgs args = CreateMediaFileDataEventArgs(objEvent);
				MediaFileDataEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args);
			}
		}

		/// 
		/// Creates the media file data event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private MediaFileDataEventArgs CreateMediaFileDataEventArgs(IEvent objEvent)
		{
			if (!DeviceEventArgs.TryGetError<MediaFileDataEventArgs>(objEvent, out var objEventArgs))
			{
				return new MediaFileDataEventArgs(MediaFileData.FromVWGEvent(objEvent));
			}
			return objEventArgs;
		}

		/// 
		/// Gets the capture event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private CaptureEventArgs GetCaptureEventArgs(IEvent objEvent)
		{
			if (!DeviceEventArgs.TryGetError<CaptureEventArgs>(objEvent, out var objEventArgs))
			{
				IMediaFile[] arrCapturedFiles = MediaFile.ParseFromVWGEvent(objEvent, this);
				return new CaptureEventArgs(arrCapturedFiles);
			}
			return objEventArgs;
		}

		/// 
		/// Captures the audio.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void CaptureAudio(Action<CaptureEventArgs> objCallback)
		{
			CaptureAudio(null, objCallback);
		}

		/// 
		/// Captures the audio.
		/// </summary>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void CaptureAudio(AudioCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)
		{
			CaptureOnline("captureAudio", objOptions, objCallback);
		}

		/// 
		/// Captures the image.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void CaptureImage(Action<CaptureEventArgs> objCallback)
		{
			CaptureImage(null, objCallback);
		}

		/// 
		/// Captures the image.
		/// </summary>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void CaptureImage(ImageCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)
		{
			CaptureOnline("captureImage", objOptions, objCallback);
		}

		/// 
		/// Captures the video.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void CaptureVideo(Action<CaptureEventArgs> objCallback)
		{
			CaptureVideo(null, objCallback);
		}

		/// 
		/// Captures the video.
		/// </summary>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void CaptureVideo(VideoCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)
		{
			CaptureOnline("captureVideo", objOptions, objCallback);
		}

		/// 
		/// Captures the online.
		/// </summary>
		/// <param name="strCaptureType">Type of the STR capture.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		private void CaptureOnline(string strCaptureType, DevicePropertyDictionary objOptions, Action<CaptureEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.Capture.capture", strCaptureType, CaptureEventArgsStore.StoreSingleCallMethod(objCallback), CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Gets the format data.
		/// </summary>
		/// <param name="objMediaFile">The obj media file.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void GetFormatData(MediaFile objMediaFile, EventHandler<MediaFileDataEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.Capture.getFormatData", MediaFileDataEventArgsStore.StoreContextualSingleCallMethod(objMediaFile, "for", objCallback), objMediaFile.FullPath, objMediaFile.Type);
		}
	}
}
