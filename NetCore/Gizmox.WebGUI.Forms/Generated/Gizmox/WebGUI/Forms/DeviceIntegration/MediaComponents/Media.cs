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

namespace Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents
{
/// 
	///
	/// </summary>
	[Serializable]
	public class Media : IMedia
	{
		private DeviceMedia mobjDeviceMedia;

		private string mstrSource;

		private long mlngLastModified;

		private float mfltDuration = -1f;

		private EventHandler<MediaEventArgs> mobjSuccessCallback;

		private EventHandler<EmptyDeviceEventArgs> mobjErrorCallback;

		private EventHandler<MediaStateEventArgs> mobjMediaStateCallback;

		/// 
		/// Gets the id.
		/// </summary>
		public string Id => GetHashCode().ToString();

		/// 
		/// Gets the source.
		/// </summary>
		public string Source => mstrSource;

		/// 
		/// Gets the duration.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public float Duration
		{
			get
			{
				return mfltDuration;
			}
			internal set
			{
				mfltDuration = value;
			}
		}

		/// 
		/// Occurs when [compass heading changed].
		/// </summary>
		public event Action<MediaPositionEventArgs> PositionChanged
		{
			add
			{
				mobjDeviceMedia.AddPositionChanged(this, value);
			}
			remove
			{
				mobjDeviceMedia.RemovePositionChanged(this, value);
				Update();
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media" /> class.
		/// </summary>
		/// <param name="strSource">The STR source.</param>
		/// <param name="objDeviceMedia">The obj device media.</param>
		public Media(string strSource, DeviceMedia objDeviceMedia)
		{
			mstrSource = strSource;
			mobjDeviceMedia = objDeviceMedia;
			mlngLastModified = DateTime.Now.Ticks;
		}

		/// 
		/// Plays this instance.
		/// </summary>
		public void Play()
		{
			mobjDeviceMedia.Play(this);
		}

		/// 
		/// Updates this instance.
		/// </summary>
		internal void Update()
		{
			mobjDeviceMedia.Update();
			mlngLastModified = DateTime.Now.Ticks;
		}

		/// 
		/// Pauses this instance.
		/// </summary>
		public void Pause()
		{
			mobjDeviceMedia.Pause(this);
		}

		/// 
		/// Stops this instance.
		/// </summary>
		public void Stop()
		{
			mobjDeviceMedia.Stop(this);
		}

		/// 
		/// Releases this instance.
		/// </summary>
		public void Release()
		{
			mobjDeviceMedia.Release(this);
		}

		/// 
		/// Seeks to.
		/// </summary>
		/// <param name="lngMilliseconds">The LNG milliseconds.</param>
		public void SeekTo(ulong lngMilliseconds)
		{
			mobjDeviceMedia.SeekTo(this, lngMilliseconds);
		}

		/// 
		/// Gets the current position.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void GetCurrentPosition(EventHandler<MediaPositionEventArgs> objCallback)
		{
			mobjDeviceMedia.GetCurrentPosition(this, objCallback);
		}

		/// 
		/// Starts the record.
		/// </summary>
		public void StartRecord()
		{
			mobjDeviceMedia.StartRecord(this);
		}

		/// 
		/// Stops the record.
		/// </summary>
		public void StopRecord()
		{
			mobjDeviceMedia.StopRecord(this);
		}

		/// 
		/// Sets the success event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetSuccessEvent(EventHandler<MediaEventArgs> objCallback)
		{
			Update();
			mobjSuccessCallback = objCallback;
		}

		/// 
		/// Sets the error event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
		{
			Update();
			mobjErrorCallback = objCallback;
		}

		/// 
		/// Sets the state change event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetStateChangeEvent(EventHandler<MediaStateEventArgs> objCallback)
		{
			Update();
			mobjMediaStateCallback = objCallback;
		}

		/// 
		/// Handles the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		internal void HandleEvent(IEvent objEvent)
		{
			switch (objEvent.Member.ToLower())
			{
			case "success":
				if (mobjSuccessCallback != null)
				{
					MediaEventArgs e = new MediaEventArgs(this);
					mobjSuccessCallback(this, e);
				}
				break;
			case "error":
				if (mobjErrorCallback != null)
				{
					DeviceEventArgs.TryGetError(objEvent, out var objEventArgs);
					mobjErrorCallback(this, objEventArgs);
				}
				break;
			case "state":
			{
				if (mobjMediaStateCallback != null && int.TryParse(objEvent["state"], out var result))
				{
					mobjMediaStateCallback(this, new MediaStateEventArgs(result));
				}
				break;
			}
			default:
				throw new Exception();
			}
		}

		/// 
		/// Determines whether the specified LNG request ID is dirty.
		/// </summary>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// 
		///   true</c> if the specified LNG request ID is dirty; otherwise, false</c>.
		/// </returns>
		internal bool IsDirty(long lngRequestID)
		{
			return lngRequestID < mlngLastModified;
		}

		/// 
		/// Gets the success data.
		/// </summary>
		/// </returns>
		internal object GetSuccessData()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjSuccessCallback);
		}

		/// 
		/// Gets the error data.
		/// </summary>
		/// </returns>
		internal object GetErrorData()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjErrorCallback);
		}

		/// 
		/// Gets the state data.
		/// </summary>
		/// </returns>
		internal object GetStateData()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjMediaStateCallback);
		}
	}
}
