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
	public class FileManager : DeviceComponent, IFileManagement
	{
		private SingleCallMethodStore<Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs> mobjFileSystemStore;

		private SingleCallMethodStore<MetadataEventArgs> mobjEntryMetadataEventStore;

		private SingleCallMethodStore<EntryEventArgs> mobjEntryEventArgsStore;

		private SingleCallMethodStore<EmptyDeviceEventArgs> mobjEmptyArgsStore;

		private SingleCallMethodStore<ToUrlEventArgs> mobjToUrlEventArgsStore;

		private SingleCallMethodStore<DirectoryReaderEventArgs> mobjDirectoryReaderEventArgsStore;

		private SingleCallMethodStore<FileEventArgs> mobjFileEventArgsStore;

		private SingleCallMethodStore<FileWriterEventArgs> mobjFileWriterEventArgsStore;

		private SingleCallMethodStore<FileUploadEventArgs> mobjFileUploadEventArgsStore;

		private SingleCallMethodStore<FileDownloadEventArgs> mobjFileDownloadEventArgsStore;

		private Dictionary<string, FileWriter> mobjFileWritersIndexByFileWriterHashCode;

		private Dictionary<string, FileReader> mobjFileReadersIndexByFileWriterHashCode;

		/// 
		/// Gets the empty args store.
		/// </summary>
		internal SingleCallMethodStore<FileDownloadEventArgs> FileDownloadEventArgsStore
		{
			get
			{
				if (mobjFileDownloadEventArgsStore == null)
				{
					mobjFileDownloadEventArgsStore = new SingleCallMethodStore<FileDownloadEventArgs>();
				}
				return mobjFileDownloadEventArgsStore;
			}
		}

		/// 
		/// Gets the empty args store.
		/// </summary>
		internal SingleCallMethodStore<EmptyDeviceEventArgs> EmptyArgsStore
		{
			get
			{
				if (mobjEmptyArgsStore == null)
				{
					mobjEmptyArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
				}
				return mobjEmptyArgsStore;
			}
		}

		/// 
		/// Gets the entry event args store.
		/// </summary>
		private SingleCallMethodStore<EntryEventArgs> EntryEventArgsStore
		{
			get
			{
				if (mobjEntryEventArgsStore == null)
				{
					mobjEntryEventArgsStore = new SingleCallMethodStore<EntryEventArgs>();
				}
				return mobjEntryEventArgsStore;
			}
		}

		/// 
		/// Gets the file upload event args store.
		/// </summary>
		private SingleCallMethodStore<FileUploadEventArgs> FileUploadEventArgsStore
		{
			get
			{
				if (mobjFileUploadEventArgsStore == null)
				{
					mobjFileUploadEventArgsStore = new SingleCallMethodStore<FileUploadEventArgs>();
				}
				return mobjFileUploadEventArgsStore;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManager" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public FileManager(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "FMR";
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(objEvent.Type);
			switch (keyValuePair.Key)
			{
			case "fileSystem":
			{
				Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs args4 = CreateFileSystemArguments(objEvent);
				mobjFileSystemStore.InvokeSingleCallMethod(keyValuePair.Value, args4);
				break;
			}
			case "metadata":
			{
				MetadataEventArgs args5 = CreateMetadataEventArguments(objEvent);
				mobjEntryMetadataEventStore.InvokeContextualMethod(keyValuePair.Value, args5);
				break;
			}
			case "entry":
			{
				Entry contaxt2 = mobjEntryEventArgsStore.GetContaxt<Entry>(keyValuePair.Value);
				EntryEventArgs args8 = CraeteEntryEventArgs(objEvent, contaxt2.FileSystem);
				mobjEntryEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args8);
				break;
			}
			case "tourl":
			{
				ToUrlEventArgs args6 = CreateToUrlArguments(objEvent);
				mobjToUrlEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args6);
				break;
			}
			case "readDirectory":
			{
				DirectoryReader contaxt = mobjDirectoryReaderEventArgsStore.GetContaxt<DirectoryReader>(keyValuePair.Value);
				DirectoryReaderEventArgs args7 = CreateDirectoryReaderEventArgs(objEvent, contaxt.Directory.FileSystem);
				mobjDirectoryReaderEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args7);
				break;
			}
			case "removerec":
			case "remove":
			{
				if (!DeviceEventArgs.TryGetError<EmptyDeviceEventArgs>(objEvent, out var objEventArgs))
				{
					objEventArgs = new EmptyDeviceEventArgs();
				}
				mobjEmptyArgsStore.InvokeContextualMethod(keyValuePair.Value, objEventArgs);
				break;
			}
			case "getFileWriter":
			{
				FileEntry contaxt3 = mobjFileWriterEventArgsStore.GetContaxt<FileEntry>(keyValuePair.Value);
				FileWriterEventArgs args10 = CreateFileWriterEventArgs(objEvent, contaxt3);
				mobjFileWriterEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args10);
				break;
			}
			case "getfile":
			{
				FileEventArgs args9 = CreateFileEventArgsArguments(objEvent);
				mobjFileEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args9);
				break;
			}
			case "filewriter":
			{
				if (mobjFileWritersIndexByFileWriterHashCode.TryGetValue(keyValuePair.Value, out var value2))
				{
					value2.HandleEvent(objEvent);
				}
				if (value2.Finished)
				{
					mobjFileWritersIndexByFileWriterHashCode.Remove(keyValuePair.Value);
				}
				break;
			}
			case "filereader":
			{
				if (mobjFileReadersIndexByFileWriterHashCode.TryGetValue(keyValuePair.Value, out var value))
				{
					value.HandleEvent(objEvent);
					if (value.Finished)
					{
						mobjFileReadersIndexByFileWriterHashCode.Remove(keyValuePair.Value);
					}
				}
				break;
			}
			case "upload":
			{
				FileUploadEventArgs args3 = CreateFileUploadEventArgs(objEvent);
				mobjFileUploadEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args3);
				break;
			}
			case "download":
			{
				FileDownloadEventArgs args2 = CraeteFileDownloadEventArgs(objEvent);
				FileDownloadEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args2);
				break;
			}
			case "resolve":
			{
				EntryEventArgs args = CraeteEntryEventArgs(objEvent, null);
				mobjEntryEventArgsStore.InvokeSingleCallMethod(keyValuePair.Value, args);
				break;
			}
			default:
				throw new NotSupportedException($"Key ({keyValuePair.Key}) is not supported");
			}
		}

		/// 
		/// Craetes the file download event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private FileDownloadEventArgs CraeteFileDownloadEventArgs(IEvent objEvent)
		{
			return PhonegapFileDownloadEventArgs.FromVWGEvent(objEvent, this);
		}

		/// 
		/// Creates the file upload event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private FileUploadEventArgs CreateFileUploadEventArgs(IEvent objEvent)
		{
			return PhonegapFileUploadEventArgs.FromVWGEvent(objEvent);
		}

		/// 
		/// Creates the file writer event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// <param name="objFileEntryContext">The obj file entry context.</param>
		/// </returns>
		private FileWriterEventArgs CreateFileWriterEventArgs(IEvent objEvent, FileEntry objFileEntryContext)
		{
			FileWriterEventArgs objEventArgs;
			if (!DeviceEventArgs.TryGetError<FileWriterEventArgs>(objEvent, out objEventArgs))
				objEventArgs = new FileWriterEventArgs(FileWriter.FromVWGEvent(objEvent, objFileEntryContext, this));
			return objEventArgs;
		}

		/// 
		/// Creates the file event args arguments.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private FileEventArgs CreateFileEventArgsArguments(IEvent objEvent)
		{
			FileEventArgs objEventArgs;
			if (!DeviceEventArgs.TryGetError<FileEventArgs>(objEvent, out objEventArgs))
				objEventArgs = new FileEventArgs(DeviceFile.FromVWGEvent(objEvent));
			return objEventArgs;
		}

		/// 
		/// Creates the directory reader event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// <param name="objFileSystem">The obj file system.</param>
		/// </returns>
		private DirectoryReaderEventArgs CreateDirectoryReaderEventArgs(IEvent objEvent, IFileSystem objFileSystem)
		{
			DirectoryReaderEventArgs objEventArgs;
			List<IEntry> list = new List<IEntry>();
			if (!DeviceEventArgs.TryGetError<DirectoryReaderEventArgs>(objEvent, out objEventArgs))
			{
				if (int.TryParse(objEvent["count"], out var result))
				{
					for (int i = 0; i < result; i++)
					{
						string strPrefix = "a" + i;
						bool? flag = Entry.IsEntryDirectoryFromVwgEvent(strPrefix, objEvent);
						if (flag.HasValue)
						{
							if (flag.Value)
							{
								list.Add((IEntry)DirectoryEntry.FromVWGEvent(strPrefix, objEvent, this, objFileSystem));
							}
							else
							{
								list.Add((IEntry)FileEntry.FromVWGEvent(strPrefix, objEvent, this, objFileSystem));
							}
						}
					}
				}
				objEventArgs = new DirectoryReaderEventArgs(list.ToArray());
			}
			return objEventArgs!;
		}

		/// 
		/// Creates to URL arguments.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private ToUrlEventArgs CreateToUrlArguments(IEvent objEvent)
		{
			ToUrlEventArgs objEventArgs;
			if (!DeviceEventArgs.TryGetError<ToUrlEventArgs>(objEvent, out objEventArgs))
				objEventArgs = ToUrlEventArgs.FromVWGEvent(objEvent);
			return objEventArgs;
		}

		/// 
		/// Craetes the entry event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// <param name="objFileSystem">The obj file system.</param>
		/// </returns>
		private EntryEventArgs CraeteEntryEventArgs(IEvent objEvent, IFileSystem objFileSystem)
		{
			EntryEventArgs objEventArgs;
			if (!DeviceEventArgs.TryGetError<EntryEventArgs>(objEvent, out objEventArgs))
			{
				bool? flag = Entry.IsEntryDirectoryFromVwgEvent("", objEvent);
				if (flag.HasValue)
				{
					if (flag.Value)
					{
						objEventArgs = new EntryEventArgs(DirectoryEntry.FromVWGEvent(objEvent, this, objFileSystem));
					}
					else objEventArgs = new EntryEventArgs(FileEntry.FromVWGEvent(objEvent, this, objFileSystem));
				}
			}
			return objEventArgs!;
		}

		/// 
		/// Creates the metadata event arguments.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private MetadataEventArgs CreateMetadataEventArguments(IEvent objEvent)
		{
			MetadataEventArgs objEventArgs;
			if (!DeviceEventArgs.TryGetError<MetadataEventArgs>(objEvent, out objEventArgs))
				objEventArgs = new MetadataEventArgs(EntryMetadata.CreateFromVWGEvent(objEvent));
			return objEventArgs;
		}

		/// 
		/// Creates the file system arguments.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs CreateFileSystemArguments(IEvent objEvent)
		{
			Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs result = new Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs(FileSystem.FromVWGEvent(this, objEvent));
			int result2;
			if (objEvent["code"] != null)
			{
				result = new Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs(FileSystem.FromVWGEvent(this, objEvent));
			}
			else if (int.TryParse(objEvent["code"], out result2))
			{
				result = new Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs(result2);
			}
			return result;
		}

		/// 
		/// Requests the file system.
		/// </summary>
		/// <param name="enmType">Type of the enm.</param>
		/// <param name="lngRequestedSizeInBytes">The LNG requested size in bytes.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void RequestFileSystem(FileSystemType enmType, ulong lngRequestedSizeInBytes, Action<Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs> objCallback)
		{
			if (mobjFileSystemStore == null)
			{
				mobjFileSystemStore = new SingleCallMethodStore<Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs>();
			}
			Invoke("DeviceIntegrator.FileManager.requestFileSystem", (int)enmType, lngRequestedSizeInBytes, mobjFileSystemStore.StoreSingleCallMethod("fileSystem", objCallback));
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("FileManager_Initialize", ID);
		}

		/// 
		/// Gets the entry metadata.
		/// </summary>
		/// <param name="entry">The entry.</param>
		/// <param name="objHandler">The obj handler.</param>
		internal void GetEntryMetadata(Entry entry, EventHandler<MetadataEventArgs> objHandler)
		{
			if (mobjEntryMetadataEventStore == null)
			{
				mobjEntryMetadataEventStore = new SingleCallMethodStore<MetadataEventArgs>();
			}
			string text = mobjEntryMetadataEventStore.StoreContextualSingleCallMethod(entry, "metadata", objHandler);
			Invoke("DeviceIntegrator.FileManager.getMetadataByPath", entry.FullPath, entry.IsDirectory, text);
		}

		/// 
		/// Gets the directory.
		/// </summary>
		/// <param name="objDirectoryEntry">The obj directory entry.</param>
		/// <param name="strFilePath">The STR file path.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void GetDirectory(DirectoryEntry objDirectoryEntry, string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)
		{
			string text = EntryEventArgsStore.StoreContextualSingleCallMethod(objDirectoryEntry, "entry", objCallback);
			Invoke("DeviceIntegrator.FileManager.getDirectoryByPath", objDirectoryEntry.FullPath, strFilePath, CommonUtils.GetClientJsonObject(objOptions), text);
		}

		/// 
		/// Gets the file.
		/// </summary>
		/// <param name="objDirectoryEntry">The obj directory entry.</param>
		/// <param name="strFilePath">The STR file path.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void GetFile(DirectoryEntry objDirectoryEntry, string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)
		{
			string text = EntryEventArgsStore.StoreContextualSingleCallMethod(objDirectoryEntry, "entry", objCallback);
			Invoke("DeviceIntegrator.FileManager.getFileByPath", objDirectoryEntry.FullPath, strFilePath, CommonUtils.GetClientJsonObject(objOptions), text);
		}

		/// 
		/// Changes the file location.
		/// </summary>
		/// <param name="strChangeType">Type of the STR change.</param>
		/// <param name="objEntry">The obj entry.</param>
		/// <param name="objParentDirectory">The obj parent directory.</param>
		/// <param name="strNewName">New name of the STR.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void ChangeFileLocation(string strChangeType, Entry objEntry, IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)
		{
			Invoke(arrArguments: new object[5]
			{
				objParentDirectory.FullPath,
				objEntry.FullPath,
				objEntry.IsDirectory,
				strNewName,
				EntryEventArgsStore.StoreContextualSingleCallMethod(objEntry, "entry", objCallback)
			}, strMethodName: $"DeviceIntegrator.FileManager.{strChangeType}");
		}

		/// 
		/// Gets the parent.
		/// </summary>
		/// <param name="objEntry">The obj entry.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void GetParent(Entry objEntry, EventHandler<EntryEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.FileManager.getParentByPath", objEntry.FullPath, objEntry.IsDirectory, EntryEventArgsStore.StoreContextualSingleCallMethod(objEntry, "entry", objCallback));
		}

		/// 
		/// Removes the specified obj entry.
		/// </summary>
		/// <param name="objEntry">The obj entry.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void Remove(Entry objEntry, EventHandler<EmptyDeviceEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.FileManager.removeByPath", objEntry.FullPath, objEntry.IsDirectory, EmptyArgsStore.StoreContextualSingleCallMethod(objEntry, "remove", objCallback));
		}

		/// 
		/// Toes the URL.
		/// </summary>
		/// <param name="objEntry">The obj entry.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void ToUrl(Entry objEntry, EventHandler<ToUrlEventArgs> objCallback)
		{
			if (mobjToUrlEventArgsStore == null)
			{
				mobjToUrlEventArgsStore = new SingleCallMethodStore<ToUrlEventArgs>();
			}
			Invoke("DeviceIntegrator.FileManager.toURLByPath", objEntry.FullPath, objEntry.IsDirectory, mobjToUrlEventArgsStore.StoreContextualSingleCallMethod(objEntry, "tourl", objCallback));
		}

		/// 
		/// Sets the metadata.
		/// </summary>
		/// <param name="objEntry">The obj entry.</param>
		/// <param name="objValues">The obj values.</param>
		/// <param name="objHandler">The obj handler.</param>
		internal void SetMetadata(Entry objEntry, MetadataDictionary objValues, EventHandler<EmptyDeviceEventArgs> objHandler)
		{
			Invoke("DeviceIntegrator.FileManager.setMetadataByPath", objEntry.FullPath, objEntry.IsDirectory, CommonUtils.GetClientJsonObject(objValues), EmptyArgsStore.StoreContextualSingleCallMethod(objEntry, "setmeta", objHandler));
		}

		/// 
		/// Reads the entries.
		/// </summary>
		/// <param name="objDirectoryReader">The obj directory reader.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void ReadEntries(DirectoryReader objDirectoryReader, EventHandler<DirectoryReaderEventArgs> objCallback)
		{
			if (mobjDirectoryReaderEventArgsStore == null)
			{
				mobjDirectoryReaderEventArgsStore = new SingleCallMethodStore<DirectoryReaderEventArgs>();
			}
			Invoke("DeviceIntegrator.FileManager.readDirectory", objDirectoryReader.Directory.FullPath, mobjDirectoryReaderEventArgsStore.StoreContextualSingleCallMethod(objDirectoryReader, "readDirectory", objCallback));
		}

		/// 
		/// Removes the recursively.
		/// </summary>
		/// <param name="objDirectoryEntry">The obj directory entry.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void RemoveRecursively(DirectoryEntry objDirectoryEntry, EventHandler<EmptyDeviceEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.FileManager.removeRecursively", objDirectoryEntry.FullPath, EmptyArgsStore.StoreContextualSingleCallMethod(objDirectoryEntry, "removerec", objCallback));
		}

		/// 
		/// Gets the file.
		/// </summary>
		/// <param name="objFileEntry">The obj file entry.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void GetFile(FileEntry objFileEntry, EventHandler<FileEventArgs> objCallback)
		{
			if (mobjFileEventArgsStore == null)
			{
				mobjFileEventArgsStore = new SingleCallMethodStore<FileEventArgs>();
			}
			Invoke("DeviceIntegrator.FileManager.fileEntryGetFile", objFileEntry.FullPath, mobjFileEventArgsStore.StoreContextualSingleCallMethod(objFileEntry, "getfile", objCallback));
		}

		/// 
		/// Gets the writer.
		/// </summary>
		/// <param name="objFileEntry">The obj file entry.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void CreateWriter(FileEntry objFileEntry, EventHandler<FileWriterEventArgs> objCallback)
		{
			if (mobjFileWriterEventArgsStore == null)
			{
				mobjFileWriterEventArgsStore = new SingleCallMethodStore<FileWriterEventArgs>();
			}
			Invoke("DeviceIntegrator.FileManager.getFileWriter", objFileEntry.FullPath, mobjFileWriterEventArgsStore.StoreContextualSingleCallMethod(objFileEntry, "getFileWriter", objCallback));
		}

		/// 
		/// Writes to file.
		/// </summary>
		/// <param name="objFileWriter">The obj file writer.</param>
		/// <param name="strData">The STR data.</param>
		internal void WriteToFile(FileWriter objFileWriter, string strData)
		{
			ExecuteFileWriterOperation("write", objFileWriter, strData);
		}

		/// 
		/// Truncates the specified obj file writer.
		/// </summary>
		/// <param name="objFileWriter">The obj file writer.</param>
		/// <param name="lngLength">Length of the LNG.</param>
		internal void Truncate(FileWriter objFileWriter, ulong lngLength)
		{
			ExecuteFileWriterOperation("truncate", objFileWriter, lngLength);
		}

		/// 
		/// Executes the file writer operation.
		/// </summary>
		/// <param name="strOperation">The STR operation.</param>
		/// <param name="objFileWriter">The obj file writer.</param>
		/// <param name="objData">The obj data.</param>
		/// <param name="objContext">The obj context.</param>
		private void ExecuteFileWriterOperation(string strOperation, FileWriter objFileWriter, object objData)
		{
			string text = objFileWriter.GetHashCode().ToString();
			if (mobjFileWritersIndexByFileWriterHashCode == null)
			{
				mobjFileWritersIndexByFileWriterHashCode = new Dictionary<string, FileWriter>();
			}
			if (!mobjFileWritersIndexByFileWriterHashCode.ContainsKey(text))
			{
				mobjFileWritersIndexByFileWriterHashCode.Add(text, objFileWriter);
			}
			Invoke("DeviceIntegrator.FileManager.fileWriterOperation", strOperation, objFileWriter.FileEntry.FullPath, $"filewriter-{text}", objFileWriter.Position, objData, CommonUtils.GetClientJsonObject(objFileWriter.GetCallbacksData));
		}

		/// 
		/// Reads as text.
		/// </summary>
		/// <param name="objFileReader">The obj file reader.</param>
		/// <param name="strEncoding">The STR encoding.</param>
		/// <param name="objContext">The obj context.</param>
		internal void ReadAsText(FileReader objFileReader, string strEncoding)
		{
			ReadFile("readAsText", objFileReader, strEncoding);
		}

		/// 
		/// Reads as data URL.
		/// </summary>
		/// <param name="objFileReader">The obj file reader.</param>
		/// <param name="objContext">The obj context.</param>
		internal void ReadAsDataUrl(FileReader objFileReader)
		{
			ReadFile("readAsDataURL", objFileReader, null);
		}

		/// 
		/// Reads the file.
		/// </summary>
		/// <param name="strOperation">The STR operation.</param>
		/// <param name="objFileReader">The obj file reader.</param>
		/// <param name="objParameter">The obj parameter.</param>
		/// <param name="objContext">The obj context.</param>
		private void ReadFile(string strOperation, FileReader objFileReader, object objParameter)
		{
			string text = objFileReader.GetHashCode().ToString();
			if (mobjFileReadersIndexByFileWriterHashCode == null)
			{
				mobjFileReadersIndexByFileWriterHashCode = new Dictionary<string, FileReader>();
			}
			if (!mobjFileReadersIndexByFileWriterHashCode.ContainsKey(text))
			{
				mobjFileReadersIndexByFileWriterHashCode.Add(text, objFileReader);
			}
			Invoke("DeviceIntegrator.FileManager.fileReaderOperation", strOperation, objFileReader.FileEntry.FullPath, $"filereader-{text}", objParameter, CommonUtils.GetClientJsonObject(objFileReader.GetCallbacksData));
		}

		/// 
		/// Gets the file transfer.
		/// </summary>
		/// </returns>
		public IFileTransfer GetFileTransfer()
		{
			return new FileTransfer(this);
		}

		/// 
		/// Downloads the specified obj file transfer.
		/// </summary>
		/// <param name="objFileTransfer">The obj file transfer.</param>
		/// <param name="strSourceUrl">The STR source URL.</param>
		/// <param name="strDestinationFileFullPath">The STR destination file full path.</param>
		/// <param name="blnTrustAllHosts">if set to true</c> [BLN trust all hosts].</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void Download(FileTransfer objFileTransfer, string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler<FileDownloadEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.FileManager.downloadFile", strSourceUrl, strDestinationFileFullPath, CommonUtils.GetClientJsonObject(objFileTransfer.GetProgressEventData()), blnTrustAllHosts, FileDownloadEventArgsStore.StoreContextualSingleCallMethod(objFileTransfer, "download", objCallback));
		}

		/// 
		/// Uploads the specified obj file transfer.
		/// </summary>
		/// <param name="objFileTransfer">The obj file transfer.</param>
		/// <param name="strFullFilePath">The STR full file path.</param>
		/// <param name="strUploadUrl">The STR upload URL.</param>
		/// <param name="objOptions">The obj options.</param>
		/// <param name="blnTrustAllHosts">if set to true</c> [BLN trust all hosts].</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void Upload(FileTransfer objFileTransfer, string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler<FileUploadEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.FileManager.uploadFile", strFullFilePath, strUploadUrl, CommonUtils.GetClientJsonObject(objFileTransfer.GetProgressEventData()), CommonUtils.GetClientJsonObject(objOptions), blnTrustAllHosts, FileUploadEventArgsStore.StoreContextualSingleCallMethod(objFileTransfer, "upload", objCallback));
		}

		/// 
		/// Resolves the local file system URI.
		/// </summary>
		/// <param name="strFileUri">The STR file URI.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void ResolveLocalFileSystemURI(string strFileUri, Action<EntryEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.FileManager.resolveLocalFileSystemURI", strFileUri, EntryEventArgsStore.StoreSingleCallMethod("resolve", objCallback));
		}
	}
}
