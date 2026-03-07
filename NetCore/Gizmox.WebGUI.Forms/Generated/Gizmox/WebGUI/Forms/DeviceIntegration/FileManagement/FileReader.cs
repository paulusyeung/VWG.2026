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

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
	/// 
	///
	/// </summary>
	[Serializable]
	public class FileReader : IFileReader
	{
		private IFileEntry mobjFileEntry;

		private FileManager mobjFileManager;

		private bool mblnFinished;

		private ReaderReadyStateType menmReaderReadyStateType;

		private EventHandler mobjAbortCallback;

		private KeyValuePair<string, object[]> mobjAbortClientCallbackData;

		private EventHandler mobjErrorCallback;

		private KeyValuePair<string, object[]> mobjErrorClientCallbackData;

		private EventHandler mobjLoadEndCallback;

		private KeyValuePair<string, object[]> mobjLoadEndClientCallbackData;

		private EventHandler mobjLoadCallback;

		private KeyValuePair<string, object[]> mobjLoadClientCallbackData;

		private EventHandler mobjLoadStartCallback;

		private KeyValuePair<string, object[]> mobjLoadStartClientCallbackData;

		private int mintLastErrorCode;

		private string mstrResult;

		/// 
		/// Gets the file entry.
		/// </summary>
		internal IFileEntry FileEntry => mobjFileEntry;

		/// 
		/// Gets the last error code.
		/// </summary>
		public int LastErrorCode
		{
			get
			{
				return mintLastErrorCode;
			}
			internal set
			{
				mintLastErrorCode = value;
			}
		}

		/// 
		/// Gets the result.
		/// </summary>
		public string Result
		{
			get
			{
				return mstrResult;
			}
			internal set
			{
				mstrResult = value;
			}
		}

		/// 
		/// Gets the callbacks.
		/// </summary>
		internal IDictionary<string, object> GetCallbacksData
		{
			get
			{
				IDictionary<string, object> dictionary = new Dictionary<string, object>();
				object loadStartValue = GetLoadStartValue();
				if (loadStartValue != null)
				{
					dictionary.Add("loadStart", loadStartValue);
				}
				loadStartValue = GetLoadValue();
				if (loadStartValue != null)
				{
					dictionary.Add("load", loadStartValue);
				}
				loadStartValue = GetLoadEndValue();
				if (loadStartValue != null)
				{
					dictionary.Add("loadEnd", loadStartValue);
				}
				loadStartValue = GetErrorValue();
				if (loadStartValue != null)
				{
					dictionary.Add("error", loadStartValue);
				}
				loadStartValue = GetAbortValue();
				if (loadStartValue != null)
				{
					dictionary.Add("abort", loadStartValue);
				}
				if (dictionary.Count > 0)
				{
					return dictionary;
				}
				return null;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileReader" /> is finished.
		/// </summary>
		/// 
		///   true</c> if finished; otherwise, false</c>.
		/// </value>
		public bool Finished
		{
			get
			{
				bool result = mblnFinished;
				mblnFinished = false;
				return result;
			}
		}

		/// 
		/// Gets the state of the ready.
		/// </summary>
		/// 
		/// The state of the ready.
		/// </value>
		public ReaderReadyStateType ReadyState
		{
			get
			{
				return menmReaderReadyStateType;
			}
			internal set
			{
				menmReaderReadyStateType = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileReader" /> class.
		/// </summary>
		/// <param name="objFileEntry">The obj file entry.</param>
		/// <param name="objFileManager">The obj file manager.</param>
		public FileReader(IFileEntry objFileEntry, FileManager objFileManager)
		{
			ReadyState = ReaderReadyStateType.Empty;
			mobjFileEntry = objFileEntry;
			mobjFileManager = objFileManager;
		}

		/// 
		/// Reads as data URL.
		/// </summary>
		public void ReadAsDataUrl()
		{
			mobjFileManager.ReadAsDataUrl(this);
		}

		/// 
		/// Reads as text.
		/// </summary>
		public void ReadAsText()
		{
			ReadAsText(null);
		}

		/// 
		/// Reads as text.
		/// </summary>
		/// <param name="strEncoding">The STR encoding.</param>
		/// <param name="objContext">The obj context.</param>
		public void ReadAsText(string strEncoding)
		{
			mobjFileManager.ReadAsText(this, strEncoding);
		}

		/// 
		/// Sets the abort event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetAbortEvent(EventHandler objCallback)
		{
			mobjAbortCallback = objCallback;
		}

		/// 
		/// Sets the error event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetErrorEvent(EventHandler<FileReaderEventArgs> objCallback)
		{
			mobjErrorCallback = objCallback;
		}

		/// 
		/// Sets the load end event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetLoadEndEvent(EventHandler<FileReaderEventArgs> objCallback)
		{
			mobjLoadEndCallback = objCallback;
		}

		/// 
		/// Sets the load event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetLoadEvent(EventHandler<FileReaderEventArgs> objCallback)
		{
			mobjLoadCallback = objCallback;
		}

		/// 
		/// Sets the load start event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetLoadStartEvent(EventHandler<FileReaderEventArgs> objCallback)
		{
			mobjLoadStartCallback = objCallback;
		}

		/// 
		/// Gets the error value.
		/// </summary>
		/// </returns>
		internal object GetErrorValue()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjErrorCallback, mobjErrorClientCallbackData);
		}

		/// 
		/// Gets the abort value.
		/// </summary>
		/// </returns>
		internal object GetAbortValue()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjAbortCallback, mobjAbortClientCallbackData);
		}

		/// 
		/// Gets the load start value.
		/// </summary>
		/// </returns>
		internal object GetLoadStartValue()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjLoadStartCallback, mobjLoadStartClientCallbackData);
		}

		/// 
		/// Gets the load start value.
		/// </summary>
		/// </returns>
		internal object GetLoadEndValue()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjLoadEndCallback, mobjLoadEndClientCallbackData);
		}

		/// 
		/// Gets the load value.
		/// </summary>
		/// </returns>
		internal object GetLoadValue()
		{
			return DeviceUtils.GetServerSideEventTypeString(mobjLoadCallback, mobjLoadClientCallbackData);
		}

		/// 
		/// Determines whether [has server side events].
		/// </summary>
		/// 
		///   true</c> if [has server side events]; otherwise, false</c>.
		/// </returns>
		internal bool HasServerSideEvents()
		{
			return mobjLoadCallback != null || mobjLoadEndCallback != null || mobjLoadStartCallback != null || mobjErrorCallback != null || mobjAbortCallback != null;
		}

		/// 
		/// Handles the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		internal void HandleEvent(IEvent objEvent)
		{
			switch (objEvent.Member.ToLower())
			{
			case "value":
			{
				Result = objEvent.Value;
				if (!string.IsNullOrEmpty(objEvent["error"]) && int.TryParse(objEvent["error"], out var result))
				{
					LastErrorCode = result;
				}
				else
				{
					LastErrorCode = 0;
				}
				break;
			}
			case "loadstart":
				if (mobjLoadStartCallback != null)
				{
					mobjLoadStartCallback(this, new FileReaderEventArgs(this));
				}
				ReadyState = ReaderReadyStateType.Loading;
				break;
			case "load":
				if (mobjLoadCallback != null)
				{
					mobjLoadCallback(this, new FileReaderEventArgs(this));
				}
				ReadyState = ReaderReadyStateType.Done;
				if (mobjLoadEndCallback != null)
				{
					mobjLoadEndCallback(this, new FileReaderEventArgs(this));
				}
				break;
			case "loadend":
				ReadyState = ReaderReadyStateType.Done;
				if (mobjLoadEndCallback != null)
				{
					mobjLoadEndCallback(this, new FileReaderEventArgs(this));
				}
				break;
			case "error":
				ReadyState = ReaderReadyStateType.Done;
				if (mobjErrorCallback != null)
				{
					mobjErrorCallback(this, new FileReaderEventArgs(this));
				}
				if (mobjLoadEndCallback != null)
				{
					mobjLoadEndCallback(this, new FileReaderEventArgs(this));
				}
				break;
			case "abort":
				ReadyState = ReaderReadyStateType.Done;
				if (mobjAbortCallback != null)
				{
					mobjAbortCallback(this, new FileReaderEventArgs(this));
				}
				if (mobjLoadEndCallback != null)
				{
					mobjLoadEndCallback(this, new FileReaderEventArgs(this));
				}
				break;
			default:
				throw new Exception();
			}
			if (ReadyState == ReaderReadyStateType.Done)
			{
				mblnFinished = true;
			}
		}
	}
}
