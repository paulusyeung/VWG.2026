// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManager
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class FileManager : DeviceComponent, IFileManagement
  {
    private SingleCallMethodStore<FileSystemEventArgs> mobjFileSystemStore;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManager" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public FileManager(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "FMR";

    /// <summary>Gets the empty args store.</summary>
    internal SingleCallMethodStore<FileDownloadEventArgs> FileDownloadEventArgsStore
    {
      get
      {
        if (this.mobjFileDownloadEventArgsStore == null)
          this.mobjFileDownloadEventArgsStore = new SingleCallMethodStore<FileDownloadEventArgs>();
        return this.mobjFileDownloadEventArgsStore;
      }
    }

    /// <summary>Gets the empty args store.</summary>
    internal SingleCallMethodStore<EmptyDeviceEventArgs> EmptyArgsStore
    {
      get
      {
        if (this.mobjEmptyArgsStore == null)
          this.mobjEmptyArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjEmptyArgsStore;
      }
    }

    /// <summary>Gets the entry event args store.</summary>
    private SingleCallMethodStore<EntryEventArgs> EntryEventArgsStore
    {
      get
      {
        if (this.mobjEntryEventArgsStore == null)
          this.mobjEntryEventArgsStore = new SingleCallMethodStore<EntryEventArgs>();
        return this.mobjEntryEventArgsStore;
      }
    }

    /// <summary>Gets the file upload event args store.</summary>
    private SingleCallMethodStore<FileUploadEventArgs> FileUploadEventArgsStore
    {
      get
      {
        if (this.mobjFileUploadEventArgsStore == null)
          this.mobjFileUploadEventArgsStore = new SingleCallMethodStore<FileUploadEventArgs>();
        return this.mobjFileUploadEventArgsStore;
      }
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      switch (keyValuePair.Key)
      {
        case "download":
          FileDownloadEventArgs args1 = this.CraeteFileDownloadEventArgs(objEvent);
          this.FileDownloadEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args1);
          break;
        case "entry":
          Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry contaxt1 = this.mobjEntryEventArgsStore.GetContaxt<Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry>(keyValuePair.Value);
          EntryEventArgs args2 = this.CraeteEntryEventArgs(objEvent, contaxt1.FileSystem);
          this.mobjEntryEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args2);
          break;
        case "fileSystem":
          FileSystemEventArgs fileSystemArguments = this.CreateFileSystemArguments(objEvent);
          this.mobjFileSystemStore.InvokeSingleCallMethod(keyValuePair.Value, fileSystemArguments);
          break;
        case "filereader":
          FileReader fileReader;
          if (!this.mobjFileReadersIndexByFileWriterHashCode.TryGetValue(keyValuePair.Value, out fileReader))
            break;
          fileReader.HandleEvent(objEvent);
          if (!fileReader.Finished)
            break;
          this.mobjFileReadersIndexByFileWriterHashCode.Remove(keyValuePair.Value);
          break;
        case "filewriter":
          FileWriter fileWriter;
          if (this.mobjFileWritersIndexByFileWriterHashCode.TryGetValue(keyValuePair.Value, out fileWriter))
            fileWriter.HandleEvent(objEvent);
          if (!fileWriter.Finished)
            break;
          this.mobjFileWritersIndexByFileWriterHashCode.Remove(keyValuePair.Value);
          break;
        case "getFileWriter":
          FileEntry contaxt2 = this.mobjFileWriterEventArgsStore.GetContaxt<FileEntry>(keyValuePair.Value);
          FileWriterEventArgs fileWriterEventArgs = this.CreateFileWriterEventArgs(objEvent, contaxt2);
          this.mobjFileWriterEventArgsStore.InvokeContextualMethod(keyValuePair.Value, fileWriterEventArgs);
          break;
        case "getfile":
          FileEventArgs eventArgsArguments = this.CreateFileEventArgsArguments(objEvent);
          this.mobjFileEventArgsStore.InvokeContextualMethod(keyValuePair.Value, eventArgsArguments);
          break;
        case "metadata":
          MetadataEventArgs metadataEventArguments = this.CreateMetadataEventArguments(objEvent);
          this.mobjEntryMetadataEventStore.InvokeContextualMethod(keyValuePair.Value, metadataEventArguments);
          break;
        case "readDirectory":
          DirectoryReader contaxt3 = this.mobjDirectoryReaderEventArgsStore.GetContaxt<DirectoryReader>(keyValuePair.Value);
          DirectoryReaderEventArgs directoryReaderEventArgs = this.CreateDirectoryReaderEventArgs(objEvent, contaxt3.Directory.FileSystem);
          this.mobjDirectoryReaderEventArgsStore.InvokeContextualMethod(keyValuePair.Value, directoryReaderEventArgs);
          break;
        case "remove":
        case "removerec":
          EmptyDeviceEventArgs objEventArgs;
          if (!DeviceEventArgs.TryGetError<EmptyDeviceEventArgs>(objEvent, out objEventArgs))
            objEventArgs = new EmptyDeviceEventArgs();
          this.mobjEmptyArgsStore.InvokeContextualMethod(keyValuePair.Value, objEventArgs);
          break;
        case "resolve":
          EntryEventArgs args3 = this.CraeteEntryEventArgs(objEvent, (IFileSystem) null);
          this.mobjEntryEventArgsStore.InvokeSingleCallMethod(keyValuePair.Value, args3);
          break;
        case "tourl":
          ToUrlEventArgs toUrlArguments = this.CreateToUrlArguments(objEvent);
          this.mobjToUrlEventArgsStore.InvokeContextualMethod(keyValuePair.Value, toUrlArguments);
          break;
        case "upload":
          FileUploadEventArgs fileUploadEventArgs = this.CreateFileUploadEventArgs(objEvent);
          this.mobjFileUploadEventArgsStore.InvokeContextualMethod(keyValuePair.Value, fileUploadEventArgs);
          break;
        default:
          throw new NotSupportedException(string.Format("Key ({0}) is not supported", (object) keyValuePair.Key));
      }
    }

    /// <summary>Craetes the file download event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private FileDownloadEventArgs CraeteFileDownloadEventArgs(IEvent objEvent) => PhonegapFileDownloadEventArgs.FromVWGEvent(objEvent, this);

    /// <summary>Creates the file upload event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private FileUploadEventArgs CreateFileUploadEventArgs(IEvent objEvent) => PhonegapFileUploadEventArgs.FromVWGEvent(objEvent);

    /// <summary>Creates the file writer event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileEntryContext">The obj file entry context.</param>
    /// <returns></returns>
    private FileWriterEventArgs CreateFileWriterEventArgs(
      IEvent objEvent,
      FileEntry objFileEntryContext)
    {
      FileWriterEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<FileWriterEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new FileWriterEventArgs(FileWriter.FromVWGEvent(objEvent, objFileEntryContext, this));
      return objEventArgs;
    }

    /// <summary>Creates the file event args arguments.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private FileEventArgs CreateFileEventArgsArguments(IEvent objEvent)
    {
      FileEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<FileEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new FileEventArgs((IDeviceFile) DeviceFile.FromVWGEvent(objEvent));
      return objEventArgs;
    }

    /// <summary>Creates the directory reader event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileSystem">The obj file system.</param>
    /// <returns></returns>
    private DirectoryReaderEventArgs CreateDirectoryReaderEventArgs(
      IEvent objEvent,
      IFileSystem objFileSystem)
    {
      List<IEntry> entryList = new List<IEntry>();
      DirectoryReaderEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<DirectoryReaderEventArgs>(objEvent, out objEventArgs))
      {
        int result;
        if (int.TryParse(objEvent["count"], out result))
        {
          for (int index = 0; index < result; ++index)
          {
            string strPrefix = "a" + (object) index;
            bool? nullable = Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry.IsEntryDirectoryFromVwgEvent(strPrefix, objEvent);
            if (nullable.HasValue)
            {
              if (nullable.Value)
                entryList.Add((IEntry) DirectoryEntry.FromVWGEvent(strPrefix, objEvent, this, objFileSystem));
              else
                entryList.Add((IEntry) FileEntry.FromVWGEvent(strPrefix, objEvent, this, objFileSystem));
            }
          }
        }
        objEventArgs = new DirectoryReaderEventArgs(entryList.ToArray());
      }
      return objEventArgs;
    }

    /// <summary>Creates to URL arguments.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private ToUrlEventArgs CreateToUrlArguments(IEvent objEvent)
    {
      ToUrlEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<ToUrlEventArgs>(objEvent, out objEventArgs))
        objEventArgs = ToUrlEventArgs.FromVWGEvent(objEvent);
      return objEventArgs;
    }

    /// <summary>Craetes the entry event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileSystem">The obj file system.</param>
    /// <returns></returns>
    private EntryEventArgs CraeteEntryEventArgs(IEvent objEvent, IFileSystem objFileSystem)
    {
      EntryEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<EntryEventArgs>(objEvent, out objEventArgs))
      {
        bool? nullable = Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry.IsEntryDirectoryFromVwgEvent("", objEvent);
        if (nullable.HasValue)
          objEventArgs = !nullable.Value ? new EntryEventArgs((IEntry) FileEntry.FromVWGEvent(objEvent, this, objFileSystem)) : new EntryEventArgs((IEntry) DirectoryEntry.FromVWGEvent(objEvent, this, objFileSystem));
      }
      return objEventArgs;
    }

    /// <summary>Creates the metadata event arguments.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private MetadataEventArgs CreateMetadataEventArguments(IEvent objEvent)
    {
      MetadataEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<MetadataEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new MetadataEventArgs((IMetadata) EntryMetadata.CreateFromVWGEvent(objEvent));
      return objEventArgs;
    }

    /// <summary>Creates the file system arguments.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private FileSystemEventArgs CreateFileSystemArguments(IEvent objEvent)
    {
      FileSystemEventArgs fileSystemArguments = new FileSystemEventArgs((IFileSystem) FileSystem.FromVWGEvent(this, objEvent));
      if (objEvent["code"] != null)
      {
        fileSystemArguments = new FileSystemEventArgs((IFileSystem) FileSystem.FromVWGEvent(this, objEvent));
      }
      else
      {
        int result;
        if (int.TryParse(objEvent["code"], out result))
          fileSystemArguments = new FileSystemEventArgs(result);
      }
      return fileSystemArguments;
    }

    /// <summary>Requests the file system.</summary>
    /// <param name="enmType">Type of the enm.</param>
    /// <param name="lngRequestedSizeInBytes">The LNG requested size in bytes.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void RequestFileSystem(
      FileSystemType enmType,
      ulong lngRequestedSizeInBytes,
      Action<FileSystemEventArgs> objCallback)
    {
      if (this.mobjFileSystemStore == null)
        this.mobjFileSystemStore = new SingleCallMethodStore<FileSystemEventArgs>();
      this.Invoke("DeviceIntegrator.FileManager.requestFileSystem", (object) (int) enmType, (object) lngRequestedSizeInBytes, (object) this.mobjFileSystemStore.StoreSingleCallMethod("fileSystem", objCallback));
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("FileManager_Initialize", (object) this.ID);
    }

    /// <summary>Gets the entry metadata.</summary>
    /// <param name="entry">The entry.</param>
    /// <param name="objHandler">The obj handler.</param>
    internal void GetEntryMetadata(Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry entry, EventHandler<MetadataEventArgs> objHandler)
    {
      if (this.mobjEntryMetadataEventStore == null)
        this.mobjEntryMetadataEventStore = new SingleCallMethodStore<MetadataEventArgs>();
      string str = this.mobjEntryMetadataEventStore.StoreContextualSingleCallMethod((object) entry, "metadata", objHandler);
      this.Invoke("DeviceIntegrator.FileManager.getMetadataByPath", (object) entry.FullPath, (object) entry.IsDirectory, (object) str);
    }

    /// <summary>Gets the directory.</summary>
    /// <param name="objDirectoryEntry">The obj directory entry.</param>
    /// <param name="strFilePath">The STR file path.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void GetDirectory(
      DirectoryEntry objDirectoryEntry,
      string strFilePath,
      FlagsOptions objOptions,
      EventHandler<EntryEventArgs> objCallback)
    {
      string str = this.EntryEventArgsStore.StoreContextualSingleCallMethod((object) objDirectoryEntry, "entry", objCallback);
      this.Invoke("DeviceIntegrator.FileManager.getDirectoryByPath", (object) objDirectoryEntry.FullPath, (object) strFilePath, (object) CommonUtils.GetClientJsonObject((object) objOptions), (object) str);
    }

    /// <summary>Gets the file.</summary>
    /// <param name="objDirectoryEntry">The obj directory entry.</param>
    /// <param name="strFilePath">The STR file path.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void GetFile(
      DirectoryEntry objDirectoryEntry,
      string strFilePath,
      FlagsOptions objOptions,
      EventHandler<EntryEventArgs> objCallback)
    {
      string str = this.EntryEventArgsStore.StoreContextualSingleCallMethod((object) objDirectoryEntry, "entry", objCallback);
      this.Invoke("DeviceIntegrator.FileManager.getFileByPath", (object) objDirectoryEntry.FullPath, (object) strFilePath, (object) CommonUtils.GetClientJsonObject((object) objOptions), (object) str);
    }

    /// <summary>Changes the file location.</summary>
    /// <param name="strChangeType">Type of the STR change.</param>
    /// <param name="objEntry">The obj entry.</param>
    /// <param name="objParentDirectory">The obj parent directory.</param>
    /// <param name="strNewName">New name of the STR.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void ChangeFileLocation(
      string strChangeType,
      Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry objEntry,
      IDirectoryEntry objParentDirectory,
      string strNewName,
      EventHandler<EntryEventArgs> objCallback)
    {
      object[] objArray = new object[5]
      {
        (object) objParentDirectory.FullPath,
        (object) objEntry.FullPath,
        (object) objEntry.IsDirectory,
        (object) strNewName,
        (object) this.EntryEventArgsStore.StoreContextualSingleCallMethod((object) objEntry, "entry", objCallback)
      };
      this.Invoke(string.Format("DeviceIntegrator.FileManager.{0}", (object) strChangeType), objArray);
    }

    /// <summary>Gets the parent.</summary>
    /// <param name="objEntry">The obj entry.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void GetParent(Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry objEntry, EventHandler<EntryEventArgs> objCallback) => this.Invoke("DeviceIntegrator.FileManager.getParentByPath", (object) objEntry.FullPath, (object) objEntry.IsDirectory, (object) this.EntryEventArgsStore.StoreContextualSingleCallMethod((object) objEntry, "entry", objCallback));

    /// <summary>Removes the specified obj entry.</summary>
    /// <param name="objEntry">The obj entry.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void Remove(Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry objEntry, EventHandler<EmptyDeviceEventArgs> objCallback) => this.Invoke("DeviceIntegrator.FileManager.removeByPath", (object) objEntry.FullPath, (object) objEntry.IsDirectory, (object) this.EmptyArgsStore.StoreContextualSingleCallMethod((object) objEntry, "remove", objCallback));

    /// <summary>Toes the URL.</summary>
    /// <param name="objEntry">The obj entry.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void ToUrl(Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry objEntry, EventHandler<ToUrlEventArgs> objCallback)
    {
      if (this.mobjToUrlEventArgsStore == null)
        this.mobjToUrlEventArgsStore = new SingleCallMethodStore<ToUrlEventArgs>();
      this.Invoke("DeviceIntegrator.FileManager.toURLByPath", (object) objEntry.FullPath, (object) objEntry.IsDirectory, (object) this.mobjToUrlEventArgsStore.StoreContextualSingleCallMethod((object) objEntry, "tourl", objCallback));
    }

    /// <summary>Sets the metadata.</summary>
    /// <param name="objEntry">The obj entry.</param>
    /// <param name="objValues">The obj values.</param>
    /// <param name="objHandler">The obj handler.</param>
    internal void SetMetadata(
      Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry objEntry,
      MetadataDictionary objValues,
      EventHandler<EmptyDeviceEventArgs> objHandler)
    {
      this.Invoke("DeviceIntegrator.FileManager.setMetadataByPath", (object) objEntry.FullPath, (object) objEntry.IsDirectory, (object) CommonUtils.GetClientJsonObject((object) objValues), (object) this.EmptyArgsStore.StoreContextualSingleCallMethod((object) objEntry, "setmeta", objHandler));
    }

    /// <summary>Reads the entries.</summary>
    /// <param name="objDirectoryReader">The obj directory reader.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void ReadEntries(
      DirectoryReader objDirectoryReader,
      EventHandler<DirectoryReaderEventArgs> objCallback)
    {
      if (this.mobjDirectoryReaderEventArgsStore == null)
        this.mobjDirectoryReaderEventArgsStore = new SingleCallMethodStore<DirectoryReaderEventArgs>();
      this.Invoke("DeviceIntegrator.FileManager.readDirectory", (object) objDirectoryReader.Directory.FullPath, (object) this.mobjDirectoryReaderEventArgsStore.StoreContextualSingleCallMethod((object) objDirectoryReader, "readDirectory", objCallback));
    }

    /// <summary>Removes the recursively.</summary>
    /// <param name="objDirectoryEntry">The obj directory entry.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void RemoveRecursively(
      DirectoryEntry objDirectoryEntry,
      EventHandler<EmptyDeviceEventArgs> objCallback)
    {
      this.Invoke("DeviceIntegrator.FileManager.removeRecursively", (object) objDirectoryEntry.FullPath, (object) this.EmptyArgsStore.StoreContextualSingleCallMethod((object) objDirectoryEntry, "removerec", objCallback));
    }

    /// <summary>Gets the file.</summary>
    /// <param name="objFileEntry">The obj file entry.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void GetFile(FileEntry objFileEntry, EventHandler<FileEventArgs> objCallback)
    {
      if (this.mobjFileEventArgsStore == null)
        this.mobjFileEventArgsStore = new SingleCallMethodStore<FileEventArgs>();
      this.Invoke("DeviceIntegrator.FileManager.fileEntryGetFile", (object) objFileEntry.FullPath, (object) this.mobjFileEventArgsStore.StoreContextualSingleCallMethod((object) objFileEntry, "getfile", objCallback));
    }

    /// <summary>Gets the writer.</summary>
    /// <param name="objFileEntry">The obj file entry.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void CreateWriter(
      FileEntry objFileEntry,
      EventHandler<FileWriterEventArgs> objCallback)
    {
      if (this.mobjFileWriterEventArgsStore == null)
        this.mobjFileWriterEventArgsStore = new SingleCallMethodStore<FileWriterEventArgs>();
      this.Invoke("DeviceIntegrator.FileManager.getFileWriter", (object) objFileEntry.FullPath, (object) this.mobjFileWriterEventArgsStore.StoreContextualSingleCallMethod((object) objFileEntry, "getFileWriter", objCallback));
    }

    /// <summary>Writes to file.</summary>
    /// <param name="objFileWriter">The obj file writer.</param>
    /// <param name="strData">The STR data.</param>
    internal void WriteToFile(FileWriter objFileWriter, string strData) => this.ExecuteFileWriterOperation("write", objFileWriter, (object) strData);

    /// <summary>Truncates the specified obj file writer.</summary>
    /// <param name="objFileWriter">The obj file writer.</param>
    /// <param name="lngLength">Length of the LNG.</param>
    internal void Truncate(FileWriter objFileWriter, ulong lngLength) => this.ExecuteFileWriterOperation("truncate", objFileWriter, (object) lngLength);

    /// <summary>Executes the file writer operation.</summary>
    /// <param name="strOperation">The STR operation.</param>
    /// <param name="objFileWriter">The obj file writer.</param>
    /// <param name="objData">The obj data.</param>
    /// <param name="objContext">The obj context.</param>
    private void ExecuteFileWriterOperation(
      string strOperation,
      FileWriter objFileWriter,
      object objData)
    {
      string key = objFileWriter.GetHashCode().ToString();
      if (this.mobjFileWritersIndexByFileWriterHashCode == null)
        this.mobjFileWritersIndexByFileWriterHashCode = new Dictionary<string, FileWriter>();
      if (!this.mobjFileWritersIndexByFileWriterHashCode.ContainsKey(key))
        this.mobjFileWritersIndexByFileWriterHashCode.Add(key, objFileWriter);
      this.Invoke("DeviceIntegrator.FileManager.fileWriterOperation", (object) strOperation, (object) objFileWriter.FileEntry.FullPath, (object) string.Format("filewriter-{0}", (object) key), (object) objFileWriter.Position, objData, (object) CommonUtils.GetClientJsonObject((object) objFileWriter.GetCallbacksData));
    }

    /// <summary>Reads as text.</summary>
    /// <param name="objFileReader">The obj file reader.</param>
    /// <param name="strEncoding">The STR encoding.</param>
    /// <param name="objContext">The obj context.</param>
    internal void ReadAsText(FileReader objFileReader, string strEncoding) => this.ReadFile("readAsText", objFileReader, (object) strEncoding);

    /// <summary>Reads as data URL.</summary>
    /// <param name="objFileReader">The obj file reader.</param>
    /// <param name="objContext">The obj context.</param>
    internal void ReadAsDataUrl(FileReader objFileReader) => this.ReadFile("readAsDataURL", objFileReader, (object) null);

    /// <summary>Reads the file.</summary>
    /// <param name="strOperation">The STR operation.</param>
    /// <param name="objFileReader">The obj file reader.</param>
    /// <param name="objParameter">The obj parameter.</param>
    /// <param name="objContext">The obj context.</param>
    private void ReadFile(string strOperation, FileReader objFileReader, object objParameter)
    {
      string key = objFileReader.GetHashCode().ToString();
      if (this.mobjFileReadersIndexByFileWriterHashCode == null)
        this.mobjFileReadersIndexByFileWriterHashCode = new Dictionary<string, FileReader>();
      if (!this.mobjFileReadersIndexByFileWriterHashCode.ContainsKey(key))
        this.mobjFileReadersIndexByFileWriterHashCode.Add(key, objFileReader);
      this.Invoke("DeviceIntegrator.FileManager.fileReaderOperation", (object) strOperation, (object) objFileReader.FileEntry.FullPath, (object) string.Format("filereader-{0}", (object) key), objParameter, (object) CommonUtils.GetClientJsonObject((object) objFileReader.GetCallbacksData));
    }

    /// <summary>Gets the file transfer.</summary>
    /// <returns></returns>
    public IFileTransfer GetFileTransfer() => (IFileTransfer) new FileTransfer(this);

    /// <summary>Downloads the specified obj file transfer.</summary>
    /// <param name="objFileTransfer">The obj file transfer.</param>
    /// <param name="strSourceUrl">The STR source URL.</param>
    /// <param name="strDestinationFileFullPath">The STR destination file full path.</param>
    /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void Download(
      FileTransfer objFileTransfer,
      string strSourceUrl,
      string strDestinationFileFullPath,
      bool blnTrustAllHosts,
      EventHandler<FileDownloadEventArgs> objCallback)
    {
      this.Invoke("DeviceIntegrator.FileManager.downloadFile", (object) strSourceUrl, (object) strDestinationFileFullPath, (object) CommonUtils.GetClientJsonObject((object) objFileTransfer.GetProgressEventData()), (object) blnTrustAllHosts, (object) this.FileDownloadEventArgsStore.StoreContextualSingleCallMethod((object) objFileTransfer, "download", objCallback));
    }

    /// <summary>Uploads the specified obj file transfer.</summary>
    /// <param name="objFileTransfer">The obj file transfer.</param>
    /// <param name="strFullFilePath">The STR full file path.</param>
    /// <param name="strUploadUrl">The STR upload URL.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void Upload(
      FileTransfer objFileTransfer,
      string strFullFilePath,
      string strUploadUrl,
      FileUploadOptions objOptions,
      bool blnTrustAllHosts,
      EventHandler<FileUploadEventArgs> objCallback)
    {
      this.Invoke("DeviceIntegrator.FileManager.uploadFile", (object) strFullFilePath, (object) strUploadUrl, (object) CommonUtils.GetClientJsonObject((object) objFileTransfer.GetProgressEventData()), (object) CommonUtils.GetClientJsonObject((object) objOptions), (object) blnTrustAllHosts, (object) this.FileUploadEventArgsStore.StoreContextualSingleCallMethod((object) objFileTransfer, "upload", objCallback));
    }

    /// <summary>Resolves the local file system URI.</summary>
    /// <param name="strFileUri">The STR file URI.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void ResolveLocalFileSystemURI(string strFileUri, Action<EntryEventArgs> objCallback) => this.Invoke("DeviceIntegrator.FileManager.resolveLocalFileSystemURI", (object) strFileUri, (object) this.EntryEventArgsStore.StoreSingleCallMethod("resolve", objCallback));
  }
}
