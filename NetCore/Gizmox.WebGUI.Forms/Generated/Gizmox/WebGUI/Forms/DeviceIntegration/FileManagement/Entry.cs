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
	public abstract class Entry : DevicePropertyDictionary, IEntry
	{
		private IFileSystem mobjFileSystem;

		private FileManager mobjFileManager;

		/// 
		/// Gets or sets a value indicating whether this instance is file.
		/// </summary>
		/// 
		///   true</c> if this instance is file; otherwise, false</c>.
		/// </value>
		public virtual bool IsFile
		{
			get
			{
				return GetValuetypePropertyOrDefault("isFile");
			}
			set
			{
				AddValueTypeProperty("isFile", value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is directory.
		/// </summary>
		/// 
		/// 	true</c> if this instance is directory; otherwise, false</c>.
		/// </value>
		public virtual bool IsDirectory
		{
			get
			{
				return GetValuetypePropertyOrDefault("isDirectory");
			}
			set
			{
				AddValueTypeProperty("isDirectory", value);
			}
		}

		/// 
		/// Gets or sets the name.
		/// </summary>
		/// 
		/// The name.
		/// </value>
		public string Name
		{
			get
			{
				return GetNullableProperty("name");
			}
			set
			{
				SetNullableProperty("name", value);
			}
		}

		/// 
		/// Gets or sets the full path.
		/// </summary>
		/// 
		/// The full path.
		/// </value>
		public string FullPath
		{
			get
			{
				return GetNullableProperty("fullPath");
			}
			set
			{
				SetNullableProperty("fullPath", value);
			}
		}

		/// 
		/// Gets the file system.
		/// </summary>
		public IFileSystem FileSystem => mobjFileSystem;

		/// 
		/// Gets the file manager.
		/// </summary>
		protected internal FileManager FileManager => mobjFileManager;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry" /> class.
		/// </summary>
		/// <param name="objFileSystem">The obj file system.</param>
		internal Entry(FileManager objFileManager, IFileSystem objFileSystem)
		{
			mobjFileManager = objFileManager;
			mobjFileSystem = objFileSystem;
		}

		/// 
		/// Gets the metadata.
		/// </summary>
		/// <param name="objHandler">The obj handler.</param>
		public void GetMetadata(EventHandler<MetadataEventArgs> objHandler)
		{
			mobjFileManager.GetEntryMetadata(this, objHandler);
		}

		/// 
		/// Sets the metadata.
		/// </summary>
		/// <param name="objHandler">The obj handler.</param>
		public void SetMetadata(MetadataDictionary objValues, EventHandler<EmptyDeviceEventArgs> objHandler)
		{
			mobjFileManager.SetMetadata(this, objValues, objHandler);
		}

		/// 
		/// Copies to.
		/// </summary>
		/// <param name="objParentDirectory">The obj parent directory.</param>
		/// <param name="strNewName">New name of the STR.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void CopyTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)
		{
			mobjFileManager.ChangeFileLocation("copyToByPath", this, objParentDirectory, strNewName, objCallback);
		}

		/// 
		/// Moves to.
		/// </summary>
		/// <param name="objParentDirectory">The obj parent directory.</param>
		/// <param name="strNewName">New name of the STR.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void MoveTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)
		{
			mobjFileManager.ChangeFileLocation("moveToByPath", this, objParentDirectory, strNewName, objCallback);
		}

		/// 
		/// Gets the parent.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void GetParent(EventHandler<EntryEventArgs> objCallback)
		{
			mobjFileManager.GetParent(this, objCallback);
		}

		/// 
		/// Removes the specified obj callback.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void Remove(EventHandler<EmptyDeviceEventArgs> objCallback)
		{
			mobjFileManager.Remove(this, objCallback);
		}

		/// 
		/// Toes the URL.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		public void ToUrl(EventHandler<ToUrlEventArgs> objCallback)
		{
			mobjFileManager.ToUrl(this, objCallback);
		}

		internal static bool? IsEntryDirectoryFromVwgEvent(string strPrefix, IEvent objEvent)
		{
			if (!string.IsNullOrEmpty(objEvent[strPrefix + "ent.isDirectory"]))
			{
				return bool.Parse(objEvent[strPrefix + "ent.isDirectory"]);
			}
			if (!string.IsNullOrEmpty(objEvent[strPrefix + "ent.isFile"]))
			{
				return !bool.Parse(objEvent[strPrefix + "ent.isFile"]);
			}
			return null;
		}

		/// 
		/// Fills from event.
		/// </summary>
		/// <param name="strPrefix">The STR prefix.</param>
		/// <param name="objEntry">The obj entry.</param>
		/// <param name="objEvent">The obj event.</param>
		protected static void FillFromEvent(string strPrefix, Entry objEntry, IEvent objEvent)
		{
			objEntry.FullPath = objEvent[strPrefix + "ent.fullPath"];
			objEntry.Name = objEvent[strPrefix + "ent.name"];
			bool? flag = IsEntryDirectoryFromVwgEvent(strPrefix, objEvent);
			if (flag.HasValue)
			{
				if (flag.Value)
				{
					objEntry.IsDirectory = true;
				}
				else
				{
					objEntry.IsFile = true;
				}
			}
		}

		protected static void FillFromEvent(Entry objEntry, IEvent objEvent)
		{
			FillFromEvent(string.Empty, objEntry, objEvent);
		}
	}
}
