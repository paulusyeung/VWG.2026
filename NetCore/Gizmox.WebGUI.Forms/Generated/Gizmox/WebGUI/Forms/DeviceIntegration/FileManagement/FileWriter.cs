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
	public class FileWriter : DevicePropertyDictionary, IFileWriter, IFileSaver
	{
		private IFileEntry mobjFileEntry;

		private FileManager mobjFileManager;

		private int mintLastErrorCode;

		private EventHandler mobjWriteEndCallback;

		private KeyValuePair<string, object[]> mobjWriteEndClientCallbackData;

		private EventHandler mobjWriteCallback;

		private KeyValuePair<string, object[]> mobjWriteClientCallbackData;

		private EventHandler mobjWriteStartCallback;

		private KeyValuePair<string, object[]> mobjWriteStartClientCallbackData;

		private EventHandler mobjErrorCallback;

		private KeyValuePair<string, object[]> mobjErrorClientCallbackData;

		private EventHandler mobjAbortCallback;

		private KeyValuePair<string, object[]> mobjAbortClientCallbackData;

		private bool mblnIsFinished;

		/// 
		/// Gets or sets the length.
		/// </summary>
		/// 
		/// The length.
		/// </value>
		public ulong Length
		{
			get
			{
				return GetValuetypePropertyOrDefault("length");
			}
			internal set
			{
				AddValueTypeProperty("length", value);
			}
		}

		/// 
		/// Gets or sets the position.
		/// </summary>
		/// 
		/// The position.
		/// </value>
		public ulong Position
		{
			get
			{
				return GetValuetypePropertyOrDefault("position");
			}
			internal set
			{
				AddValueTypeProperty("position", value);
			}
		}

		/// 
		/// Gets the error.
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
		/// Gets the state of the ready.
		/// </summary>
		/// 
		/// The state of the ready.
		/// </value>
		public ReadyStateType ReadyState
		{
			get
			{
				int? nullableValueTypeProperty = GetNullableValueTypeProperty("readyState");
				if (nullableValueTypeProperty.HasValue && Enum.IsDefined(typeof(ReaderReadyStateType), nullableValueTypeProperty))
				{
					return (ReadyStateType)nullableValueTypeProperty.Value;
				}
				return ReadyStateType.Init;
			}
			internal set
			{
				AddValueTypeProperty("readyState", (int)value);
			}
		}

		/// 
		/// Gets the file entry.
		/// </summary>
		internal IFileEntry FileEntry => mobjFileEntry;

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileWriter" /> is finished.
		/// </summary>
		/// 
		///   true</c> if finished; otherwise, false</c>.
		/// </value>
		internal bool Finished
		{
			get
			{
				bool result = mblnIsFinished;
				mblnIsFinished = false;
				return result;
			}
		}

		internal IDictionary<string, object> GetCallbacksData
		{
			get
			{
				IDictionary<string, object> dictionary = new Dictionary<string, object>();
				object writeStartValue = GetWriteStartValue();
				if (writeStartValue != null)
				{
					dictionary.Add("writeStart", GetWriteStartValue());
				}
				writeStartValue = GetWriteValue();
				if (writeStartValue != null)
				{
					dictionary.Add("write", writeStartValue);
				}
				writeStartValue = GetWriteEndValue();
				if (writeStartValue != null)
				{
					dictionary.Add("writeEnd", writeStartValue);
				}
				writeStartValue = GetErrorValue();
				if (writeStartValue != null)
				{
					dictionary.Add("error", writeStartValue);
				}
				writeStartValue = GetAbortValue();
				if (writeStartValue != null)
				{
					dictionary.Add("abort", writeStartValue);
				}
				if (dictionary.Count > 0)
				{
					return dictionary;
				}
				return null;
			}
		}

		/// 
		/// Froms the VWG event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// <param name="objFileEntryContext">The obj file entry context.</param>
		/// <param name="objFileManager">The obj file manager.</param>
		/// </returns>
		internal static IFileWriter FromVWGEvent(IEvent objEvent, FileEntry objFileEntryContext, FileManager objFileManager)
		{
			FileWriter fileWriter = new FileWriter(objFileEntryContext, objFileManager);
			FillAttributes(fileWriter, objEvent);
			return fileWriter;
		}

		private static void FillAttributes(FileWriter objFileWriter, IEvent objEvent)
		{
			if (!string.IsNullOrEmpty(objEvent["length"]) && ulong.TryParse(objEvent["length"], out var result))
			{
				objFileWriter.Length = result;
			}
			if (!string.IsNullOrEmpty(objEvent["position"]) && ulong.TryParse(objEvent["position"], out var result2))
			{
				objFileWriter.Position = result2;
			}
			if (!string.IsNullOrEmpty(objEvent["error"]) && int.TryParse(objEvent["error"], out var result3))
			{
				objFileWriter.LastErrorCode = result3;
			}
			else
			{
				objFileWriter.LastErrorCode = 0;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileWriter" /> class.
		/// </summary>
		/// <param name="objFileEntry">The obj file entry.</param>
		/// <param name="objFileManager">The obj file manager.</param>
		public FileWriter(IFileEntry objFileEntry, FileManager objFileManager)
		{
			ReadyState = ReadyStateType.Init;
			mblnIsFinished = false;
			mobjFileEntry = objFileEntry;
			mobjFileManager = objFileManager;
		}

		/// 
		/// Seeks the specified LNG position.
		/// </summary>
		/// <param name="lngOffset">The LNG position.</param>
		public void Seek(long lngOffset)
		{
			if (lngOffset < 0)
			{
				Position = (ulong)Math.Max(lngOffset + (long)Length, 0L);
			}
			else if (lngOffset - (long)Length > 0)
			{
				Position = Length;
			}
			else
			{
				Position = (ulong)lngOffset;
			}
		}

		/// 
		/// Truncates the specified LNG length.
		/// </summary>
		/// <param name="lngLength">Length of the LNG.</param>
		public void Truncate(ulong lngLength)
		{
			mobjFileManager.Truncate(this, lngLength);
		}

		/// 
		/// Writes the specified STR data.
		/// </summary>
		/// <param name="strData">The STR data.</param>
		public void Write(string strData)
		{
			mobjFileManager.WriteToFile(this, strData);
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
		public void SetErrorEvent(EventHandler<FileWriterEventArgs> objCallback)
		{
			mobjErrorCallback = objCallback;
		}

		/// 
		/// Sets the write end event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetWriteEndEvent(EventHandler<FileWriterEventArgs> objCallback)
		{
			mobjWriteEndCallback = objCallback;
		}

		/// 
		/// Sets the write event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetWriteEvent(EventHandler<FileWriterEventArgs> objCallback)
		{
			mobjWriteCallback = objCallback;
		}

		/// 
		/// Sets the write start event.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void SetWriteStartEvent(EventHandler<FileWriterEventArgs> objCallback)
		{
			mobjWriteStartCallback = objCallback;
		}

		/// 
		/// Gets the write start value.
		/// </summary>
		/// </returns>
		internal object GetWriteStartValue()
		{
			return GetServerSideEventTypeString(mobjWriteStartCallback, mobjWriteStartClientCallbackData);
		}

		private object GetServerSideEventTypeString(object objCallback, KeyValuePair<string, object[]> objClientCallbackData)
		{
			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			if (objCallback != null)
			{
				dictionary.Add("server", true);
			}
			if (objClientCallbackData.Key != null)
			{
				dictionary.Add("client", objClientCallbackData.Key);
				if (objClientCallbackData.Value != null)
				{
					dictionary.Add("clientp", objClientCallbackData.Value);
				}
			}
			if (dictionary.Count > 0)
			{
				return dictionary;
			}
			return null;
		}

		/// 
		/// Gets the write value.
		/// </summary>
		/// </returns>
		internal object GetWriteValue()
		{
			return GetServerSideEventTypeString(mobjWriteCallback, mobjWriteClientCallbackData);
		}

		/// 
		/// Gets the error value.
		/// </summary>
		/// </returns>
		internal object GetErrorValue()
		{
			return GetServerSideEventTypeString(mobjErrorCallback, mobjErrorClientCallbackData);
		}

		/// 
		/// Gets the write end value.
		/// </summary>
		/// </returns>
		internal object GetWriteEndValue()
		{
			return GetServerSideEventTypeString(mobjWriteEndCallback, mobjWriteEndClientCallbackData);
		}

		/// 
		/// Gets the abort value.
		/// </summary>
		/// </returns>
		internal object GetAbortValue()
		{
			return GetServerSideEventTypeString(mobjAbortCallback, mobjAbortClientCallbackData);
		}

		/// 
		/// Determines whether [has server side events].
		/// </summary>
		/// 
		///   true</c> if [has server side events]; otherwise, false</c>.
		/// </returns>
		internal bool HasServerSideEvents()
		{
			return mobjWriteCallback != null || mobjWriteEndCallback != null || mobjWriteStartCallback != null || mobjErrorCallback != null || mobjAbortCallback != null;
		}

		/// 
		/// Handles the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		internal void HandleEvent(IEvent objEvent)
		{
			switch (objEvent.Member.ToLower())
			{
			case "update":
				FillAttributes(this, objEvent);
				break;
			case "writestart":
				if (mobjWriteStartCallback != null)
				{
					mobjWriteStartCallback(this, new EmptyDeviceEventArgs());
				}
				ReadyState = ReadyStateType.Writing;
				break;
			case "write":
				if (mobjWriteCallback != null)
				{
					mobjWriteCallback(this, new EmptyDeviceEventArgs());
				}
				ReadyState = ReadyStateType.Done;
				if (mobjWriteEndCallback != null)
				{
					mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
				}
				break;
			case "error":
				ReadyState = ReadyStateType.Done;
				if (mobjErrorCallback != null)
				{
					mobjErrorCallback(this, new EmptyDeviceEventArgs());
				}
				if (mobjWriteEndCallback != null)
				{
					mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
				}
				break;
			case "abort":
				ReadyState = ReadyStateType.Done;
				if (mobjAbortCallback != null)
				{
					mobjAbortCallback(this, new EmptyDeviceEventArgs());
				}
				if (mobjWriteEndCallback != null)
				{
					mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
				}
				break;
			case "writeend":
				ReadyState = ReadyStateType.Done;
				if (mobjWriteEndCallback != null)
				{
					mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
				}
				break;
			default:
				throw new Exception();
			}
			if (ReadyState == ReadyStateType.Done)
			{
				mblnIsFinished = true;
			}
		}
	}
}
