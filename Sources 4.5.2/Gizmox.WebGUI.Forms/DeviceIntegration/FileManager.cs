using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Interfaces;

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
        /// Initializes a new instance of the <see cref="FileManager"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public FileManager(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        {

        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.FileManager;
        }

        /// <summary>
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

        /// <summary>
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

        /// <summary>
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

        /// <summary>
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

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(objEvent.Type);

            switch (objSplittedValues.Key)
            {
                case "fileSystem":
                    FileSystemEventArgs objArguments = CreateFileSystemArguments(objEvent);
                    mobjFileSystemStore.InvokeSingleCallMethod(objSplittedValues.Value, objArguments);
                    break;
                case "metadata":
                    MetadataEventArgs objMetadataEventArgs = CreateMetadataEventArguments(objEvent);
                    mobjEntryMetadataEventStore.InvokeContextualMethod(objSplittedValues.Value, objMetadataEventArgs);
                    break;
                case "entry":
                    Entry objDirectoryEntryContext = mobjEntryEventArgsStore.GetContaxt<Entry>(objSplittedValues.Value);
                    EntryEventArgs objEntryEventArgs = CraeteEntryEventArgs(objEvent, objDirectoryEntryContext.FileSystem);
                    mobjEntryEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objEntryEventArgs);
                    break;
                case "tourl":
                    ToUrlEventArgs objToUrlEventArgs = CreateToUrlArguments(objEvent);
                    mobjToUrlEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objToUrlEventArgs);
                    break;
                case "readDirectory":
                    DirectoryReader objDirectoryReader = mobjDirectoryReaderEventArgsStore.GetContaxt<DirectoryReader>(objSplittedValues.Value);
                    DirectoryReaderEventArgs objDirectoryReaderEventArgs = CreateDirectoryReaderEventArgs(objEvent, objDirectoryReader.Directory.FileSystem);
                    mobjDirectoryReaderEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objDirectoryReaderEventArgs);
                    break;
                case "removerec":
                case "remove":
                    EmptyDeviceEventArgs objEmptyDeviceEventArgs;

                    if (!DeviceEventArgs.TryGetError(objEvent, out objEmptyDeviceEventArgs))
                    {
                        objEmptyDeviceEventArgs = new EmptyDeviceEventArgs();
                    }

                    mobjEmptyArgsStore.InvokeContextualMethod(objSplittedValues.Value, objEmptyDeviceEventArgs);
                    break;
                case "getFileWriter":
                    FileEntry objFileEntryContext = mobjFileWriterEventArgsStore.GetContaxt<FileEntry>(objSplittedValues.Value);
                    FileWriterEventArgs objFileWriterEventArgs = CreateFileWriterEventArgs(objEvent, objFileEntryContext);
                    mobjFileWriterEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objFileWriterEventArgs);
                    break;
                case "getfile":
                    FileEventArgs objFileEventArgs = CreateFileEventArgsArguments(objEvent);
                    mobjFileEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objFileEventArgs);
                    break;
                case "filewriter":
                    FileWriter objWriter;

                    if (mobjFileWritersIndexByFileWriterHashCode.TryGetValue(objSplittedValues.Value, out objWriter))
                    {
                        objWriter.HandleEvent(objEvent);
                    }

                    if (objWriter.Finished)
                    {
                        mobjFileWritersIndexByFileWriterHashCode.Remove(objSplittedValues.Value);
                    }
                    break;
                case "filereader":
                    FileReader objReader;
                    if (mobjFileReadersIndexByFileWriterHashCode.TryGetValue(objSplittedValues.Value, out objReader))
                    {
                        objReader.HandleEvent(objEvent);

                        if (objReader.Finished)
                        {
                            mobjFileReadersIndexByFileWriterHashCode.Remove(objSplittedValues.Value);
                        }
                    }
                    break;
                case "upload":
                    FileUploadEventArgs objFileUploadEventArgs = CreateFileUploadEventArgs(objEvent);
                    mobjFileUploadEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objFileUploadEventArgs);
                    break;
                case "download":
                    FileDownloadEventArgs objDownloadEventArgs = CraeteFileDownloadEventArgs(objEvent);
                    FileDownloadEventArgsStore.InvokeContextualMethod(objSplittedValues.Value, objDownloadEventArgs);
                    break;
                case "resolve":
                    EntryEventArgs objResolveEntryEventArgs = CraeteEntryEventArgs(objEvent, null);
                    mobjEntryEventArgsStore.InvokeSingleCallMethod(objSplittedValues.Value, objResolveEntryEventArgs);
                    break;
                default:
                    throw new NotSupportedException(string.Format("Key ({0}) is not supported", objSplittedValues.Key));
            }
        }

        /// <summary>
        /// Craetes the file download event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private FileDownloadEventArgs CraeteFileDownloadEventArgs(Common.Interfaces.IEvent objEvent)
        {
            return PhonegapFileDownloadEventArgs.FromVWGEvent(objEvent, this);
        }

        /// <summary>
        /// Creates the file upload event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private FileUploadEventArgs CreateFileUploadEventArgs(Common.Interfaces.IEvent objEvent)
        {
            return PhonegapFileUploadEventArgs.FromVWGEvent(objEvent);
        }

        /// <summary>
        /// Creates the file writer event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileEntryContext">The obj file entry context.</param>
        /// <returns></returns>
        private FileWriterEventArgs CreateFileWriterEventArgs(Common.Interfaces.IEvent objEvent, FileEntry objFileEntryContext)
        {
            FileWriterEventArgs objArgs;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArgs))
            {
                objArgs = new FileWriterEventArgs(FileWriter.FromVWGEvent(objEvent, objFileEntryContext, this));
            }

            return objArgs;
        }

        /// <summary>
        /// Creates the file event args arguments.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private FileEventArgs CreateFileEventArgsArguments(Common.Interfaces.IEvent objEvent)
        {
            FileEventArgs objFileEventArgs;

            if (!DeviceEventArgs.TryGetError(objEvent, out objFileEventArgs))
            {
                objFileEventArgs = new FileEventArgs(DeviceFile.FromVWGEvent(objEvent));
            }

            return objFileEventArgs;
        }

        /// <summary>
        /// Creates the directory reader event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileSystem">The obj file system.</param>
        /// <returns></returns>
        private DirectoryReaderEventArgs CreateDirectoryReaderEventArgs(Common.Interfaces.IEvent objEvent, IFileSystem objFileSystem)
        {
            DirectoryReaderEventArgs objArguments;
            List<IEntry> objEntries = new List<IEntry>();

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                int intCount;
                if (int.TryParse(objEvent["count"], out intCount))
                {
                    for (int i = 0; i < intCount; i++)
                    {
                        string strPrefix = "a" + i;
                        bool? objIsDirectory = Entry.IsEntryDirectoryFromVwgEvent(strPrefix, objEvent);
                        if (objIsDirectory.HasValue)
                        {
                            if (objIsDirectory.Value)
                            {
                                objEntries.Add(DirectoryEntry.FromVWGEvent(strPrefix, objEvent, this, objFileSystem));
                            }
                            else
                            {
                                objEntries.Add(FileEntry.FromVWGEvent(strPrefix, objEvent, this, objFileSystem));
                            }
                        }
                    }
                }

                objArguments = new DirectoryReaderEventArgs(objEntries.ToArray());
            }

            return objArguments;
        }

        /// <summary>
        /// Creates to URL arguments.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private ToUrlEventArgs CreateToUrlArguments(Common.Interfaces.IEvent objEvent)
        {
            ToUrlEventArgs objArguments;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                objArguments = ToUrlEventArgs.FromVWGEvent(objEvent);
            }

            return objArguments;
        }

        /// <summary>
        /// Craetes the entry event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileSystem">The obj file system.</param>
        /// <returns></returns>
        private EntryEventArgs CraeteEntryEventArgs(Common.Interfaces.IEvent objEvent, IFileSystem objFileSystem)
        {
            EntryEventArgs objArguments;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                bool? objIsDir = Entry.IsEntryDirectoryFromVwgEvent("", objEvent);

                if (objIsDir.HasValue)
                {
                    if (objIsDir.Value)
                    {
                        objArguments = new EntryEventArgs(DirectoryEntry.FromVWGEvent(objEvent, this, objFileSystem));
                    }
                    else
                    {
                        objArguments = new EntryEventArgs(FileEntry.FromVWGEvent(objEvent, this, objFileSystem));
                    }
                }
                else
                {
                    // TODO:TAL - throw?
                }
            }

            return objArguments;
        }

        /// <summary>
        /// Creates the metadata event arguments.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private MetadataEventArgs CreateMetadataEventArguments(Common.Interfaces.IEvent objEvent)
        {
            MetadataEventArgs objArguments;
            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                EntryMetadata objMetadata = EntryMetadata.CreateFromVWGEvent(objEvent);
                objArguments = new MetadataEventArgs(objMetadata);
            }

            return objArguments;
        }

        /// <summary>
        /// Creates the file system arguments.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private FileSystemEventArgs CreateFileSystemArguments(Common.Interfaces.IEvent objEvent)
        {
            FileSystemEventArgs objArguments = new FileSystemEventArgs(FileSystem.FromVWGEvent(this, objEvent));
            int intErrorCode;

            if (objEvent["code"] != null)
            {
                objArguments = new FileSystemEventArgs(FileSystem.FromVWGEvent(this, objEvent));
            }
            else if (int.TryParse(objEvent["code"], out intErrorCode))
            {
                objArguments = new FileSystemEventArgs(intErrorCode);
            }

            return objArguments;
        }

        /// <summary>
        /// Requests the file system.
        /// </summary>
        /// <param name="enmType">Type of the enm.</param>
        /// <param name="lngRequestedSizeInBytes">The LNG requested size in bytes.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void RequestFileSystem(FileSystemType enmType, ulong lngRequestedSizeInBytes, Action<FileSystemEventArgs> objCallback)
        {
            if (mobjFileSystemStore == null)
            {
                mobjFileSystemStore = new SingleCallMethodStore<FileSystemEventArgs>();
            }

            object[] arrParameters = new object[3];
            arrParameters[0] = (int)enmType;
            arrParameters[1] = lngRequestedSizeInBytes;
            arrParameters[2] = mobjFileSystemStore.StoreSingleCallMethod("fileSystem", objCallback);

            Invoke("DeviceIntegrator.FileManager.requestFileSystem", arrParameters);
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("FileManager_Initialize", ID);
        }

        /// <summary>
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

            string strMethodKey = mobjEntryMetadataEventStore.StoreContextualSingleCallMethod(entry, "metadata", objHandler);

            object[] objArguments = new object[3];

            objArguments[0] = entry.FullPath;
            objArguments[1] = entry.IsDirectory;
            objArguments[2] = strMethodKey;

            Invoke("DeviceIntegrator.FileManager.getMetadataByPath", objArguments);
        }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <param name="objDirectoryEntry">The obj directory entry.</param>
        /// <param name="strFilePath">The STR file path.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void GetDirectory(DirectoryEntry objDirectoryEntry, string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)
        {
            string strMethodKey = EntryEventArgsStore.StoreContextualSingleCallMethod(objDirectoryEntry, "entry", objCallback);

            object[] objArguments = new object[4];

            objArguments[0] = objDirectoryEntry.FullPath;
            objArguments[1] = strFilePath;
            objArguments[2] = CommonUtils.GetClientJsonObject(objOptions);
            objArguments[3] = strMethodKey;

            Invoke("DeviceIntegrator.FileManager.getDirectoryByPath", objArguments);
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="objDirectoryEntry">The obj directory entry.</param>
        /// <param name="strFilePath">The STR file path.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void GetFile(DirectoryEntry objDirectoryEntry, string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)
        {
            string strMethodKey = EntryEventArgsStore.StoreContextualSingleCallMethod(objDirectoryEntry, "entry", objCallback);

            object[] objArguments = new object[4];

            objArguments[0] = objDirectoryEntry.FullPath;
            objArguments[1] = strFilePath;
            objArguments[2] = CommonUtils.GetClientJsonObject(objOptions);
            objArguments[3] = strMethodKey;


            Invoke("DeviceIntegrator.FileManager.getFileByPath", objArguments);
        }

        /// <summary>
        /// Changes the file location.
        /// </summary>
        /// <param name="strChangeType">Type of the STR change.</param>
        /// <param name="objEntry">The obj entry.</param>
        /// <param name="objParentDirectory">The obj parent directory.</param>
        /// <param name="strNewName">New name of the STR.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void ChangeFileLocation(string strChangeType, Entry objEntry, IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)
        {
            object[] objArguments = new object[5];

            objArguments[0] = objParentDirectory.FullPath;
            objArguments[1] = objEntry.FullPath;
            objArguments[2] = objEntry.IsDirectory;
            objArguments[3] = strNewName;
            objArguments[4] = EntryEventArgsStore.StoreContextualSingleCallMethod(objEntry, "entry", objCallback); ;

            Invoke(string.Format("DeviceIntegrator.FileManager.{0}", strChangeType), objArguments);
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="objEntry">The obj entry.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void GetParent(Entry objEntry, EventHandler<EntryEventArgs> objCallback)
        {
            object[] objArguments = new object[3];

            objArguments[0] = objEntry.FullPath;
            objArguments[1] = objEntry.IsDirectory;
            objArguments[2] = EntryEventArgsStore.StoreContextualSingleCallMethod(objEntry, "entry", objCallback);

            Invoke("DeviceIntegrator.FileManager.getParentByPath", objArguments);
        }

        /// <summary>
        /// Removes the specified obj entry.
        /// </summary>
        /// <param name="objEntry">The obj entry.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void Remove(Entry objEntry, EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            object[] objArguments = new object[3];

            objArguments[0] = objEntry.FullPath;
            objArguments[1] = objEntry.IsDirectory;
            objArguments[2] = EmptyArgsStore.StoreContextualSingleCallMethod(objEntry, "remove", objCallback);

            Invoke("DeviceIntegrator.FileManager.removeByPath", objArguments);
        }

        /// <summary>
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

            object[] objArguments = new object[3];

            objArguments[0] = objEntry.FullPath;
            objArguments[1] = objEntry.IsDirectory;
            objArguments[2] = mobjToUrlEventArgsStore.StoreContextualSingleCallMethod(objEntry, "tourl", objCallback);

            Invoke("DeviceIntegrator.FileManager.toURLByPath", objArguments);
        }

        /// <summary>
        /// Sets the metadata.
        /// </summary>
        /// <param name="objEntry">The obj entry.</param>
        /// <param name="objValues">The obj values.</param>
        /// <param name="objHandler">The obj handler.</param>
        internal void SetMetadata(Entry objEntry, MetadataDictionary objValues, EventHandler<EmptyDeviceEventArgs> objHandler)
        {
            object[] objArguments = new object[4];

            objArguments[0] = objEntry.FullPath;
            objArguments[1] = objEntry.IsDirectory;
            objArguments[2] = CommonUtils.GetClientJsonObject(objValues);
            objArguments[3] = EmptyArgsStore.StoreContextualSingleCallMethod(objEntry, "setmeta", objHandler);

            Invoke("DeviceIntegrator.FileManager.setMetadataByPath", objArguments);
        }

        /// <summary>
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

            object[] objArguments = new object[2];

            objArguments[0] = objDirectoryReader.Directory.FullPath;
            objArguments[1] = mobjDirectoryReaderEventArgsStore.StoreContextualSingleCallMethod(objDirectoryReader, "readDirectory", objCallback);

            Invoke("DeviceIntegrator.FileManager.readDirectory", objArguments);
        }

        /// <summary>
        /// Removes the recursively.
        /// </summary>
        /// <param name="objDirectoryEntry">The obj directory entry.</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void RemoveRecursively(DirectoryEntry objDirectoryEntry, EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            object[] objArguments = new object[2];

            objArguments[0] = objDirectoryEntry.FullPath;
            objArguments[1] = EmptyArgsStore.StoreContextualSingleCallMethod(objDirectoryEntry, "removerec", objCallback);

            Invoke("DeviceIntegrator.FileManager.removeRecursively", objArguments);
        }

        /// <summary>
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

            object[] objArguments = new object[2];

            objArguments[0] = objFileEntry.FullPath;
            objArguments[1] = mobjFileEventArgsStore.StoreContextualSingleCallMethod(objFileEntry, "getfile", objCallback);

            Invoke("DeviceIntegrator.FileManager.fileEntryGetFile", objArguments);
        }

        /// <summary>
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

            object[] objArguments = new object[2];

            objArguments[0] = objFileEntry.FullPath;
            objArguments[1] = mobjFileWriterEventArgsStore.StoreContextualSingleCallMethod(objFileEntry, "getFileWriter", objCallback);

            Invoke("DeviceIntegrator.FileManager.getFileWriter", objArguments);
        }

        /// <summary>
        /// Writes to file.
        /// </summary>
        /// <param name="objFileWriter">The obj file writer.</param>
        /// <param name="strData">The STR data.</param>
        internal void WriteToFile(FileWriter objFileWriter, string strData)
        {
            ExecuteFileWriterOperation("write", objFileWriter, strData);
        }

        /// <summary>
        /// Truncates the specified obj file writer.
        /// </summary>
        /// <param name="objFileWriter">The obj file writer.</param>
        /// <param name="lngLength">Length of the LNG.</param>
        internal void Truncate(FileWriter objFileWriter, ulong lngLength)
        {
            ExecuteFileWriterOperation("truncate", objFileWriter, lngLength);
        }

        /// <summary>
        /// Executes the file writer operation.
        /// </summary>
        /// <param name="strOperation">The STR operation.</param>
        /// <param name="objFileWriter">The obj file writer.</param>
        /// <param name="objData">The obj data.</param>
        /// <param name="objContext">The obj context.</param>
        private void ExecuteFileWriterOperation(string strOperation, FileWriter objFileWriter, object objData)
        {
            string strHashCode = objFileWriter.GetHashCode().ToString();

            if (mobjFileWritersIndexByFileWriterHashCode == null)
            {
                mobjFileWritersIndexByFileWriterHashCode = new Dictionary<string, FileWriter>();
            }

            if (!mobjFileWritersIndexByFileWriterHashCode.ContainsKey(strHashCode))
            {
                mobjFileWritersIndexByFileWriterHashCode.Add(strHashCode, objFileWriter);
            }

            object[] objArguments = new object[6];

            objArguments[0] = strOperation;
            objArguments[1] = objFileWriter.FileEntry.FullPath;
            objArguments[2] = string.Format("filewriter-{0}", strHashCode);
            objArguments[3] = objFileWriter.Position;
            objArguments[4] = objData;
            objArguments[5] = CommonUtils.GetClientJsonObject(objFileWriter.GetCallbacksData);

            Invoke("DeviceIntegrator.FileManager.fileWriterOperation", objArguments);
        }

        /// <summary>
        /// Reads as text.
        /// </summary>
        /// <param name="objFileReader">The obj file reader.</param>
        /// <param name="strEncoding">The STR encoding.</param>
        /// <param name="objContext">The obj context.</param>
        internal void ReadAsText(FileReader objFileReader, string strEncoding)
        {
            ReadFile("readAsText", objFileReader, strEncoding);
        }

        /// <summary>
        /// Reads as data URL.
        /// </summary>
        /// <param name="objFileReader">The obj file reader.</param>
        /// <param name="objContext">The obj context.</param>
        internal void ReadAsDataUrl(FileReader objFileReader)
        {
            ReadFile("readAsDataURL", objFileReader, null);
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="strOperation">The STR operation.</param>
        /// <param name="objFileReader">The obj file reader.</param>
        /// <param name="objParameter">The obj parameter.</param>
        /// <param name="objContext">The obj context.</param>
        private void ReadFile(string strOperation, FileReader objFileReader, object objParameter)
        {
            string strHashCode = objFileReader.GetHashCode().ToString();

            if (mobjFileReadersIndexByFileWriterHashCode == null)
            {
                mobjFileReadersIndexByFileWriterHashCode = new Dictionary<string, FileReader>();
            }

            if (!mobjFileReadersIndexByFileWriterHashCode.ContainsKey(strHashCode))
            {
                mobjFileReadersIndexByFileWriterHashCode.Add(strHashCode, objFileReader);
            }

            object[] objArguments = new object[5];

            objArguments[0] = strOperation;
            objArguments[1] = objFileReader.FileEntry.FullPath;
            objArguments[2] = string.Format("filereader-{0}", strHashCode);
            objArguments[3] = objParameter;
            objArguments[4] = CommonUtils.GetClientJsonObject(objFileReader.GetCallbacksData);

            Invoke("DeviceIntegrator.FileManager.fileReaderOperation", objArguments);
        }

        /// <summary>
        /// Gets the file transfer.
        /// </summary>
        /// <returns></returns>
        public IFileTransfer GetFileTransfer()
        {
            return new FileTransfer(this);
        }

        /// <summary>
        /// Downloads the specified obj file transfer.
        /// </summary>
        /// <param name="objFileTransfer">The obj file transfer.</param>
        /// <param name="strSourceUrl">The STR source URL.</param>
        /// <param name="strDestinationFileFullPath">The STR destination file full path.</param>
        /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void Download(FileTransfer objFileTransfer, string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler<FileDownloadEventArgs> objCallback)
        {
            object[] arrParameters = new object[5];
            arrParameters[0] = strSourceUrl;
            arrParameters[1] = strDestinationFileFullPath;
            arrParameters[2] = CommonUtils.GetClientJsonObject(objFileTransfer.GetProgressEventData());
            arrParameters[3] = blnTrustAllHosts;
            arrParameters[4] = FileDownloadEventArgsStore.StoreContextualSingleCallMethod(objFileTransfer, "download", objCallback);


            Invoke("DeviceIntegrator.FileManager.downloadFile", arrParameters);
        }

        /// <summary>
        /// Uploads the specified obj file transfer.
        /// </summary>
        /// <param name="objFileTransfer">The obj file transfer.</param>
        /// <param name="strFullFilePath">The STR full file path.</param>
        /// <param name="strUploadUrl">The STR upload URL.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
        /// <param name="objCallback">The obj callback.</param>
        internal void Upload(FileTransfer objFileTransfer, string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler<FileUploadEventArgs> objCallback)
        {
            object[] arrParameters = new object[6];
            arrParameters[0] = strFullFilePath;
            arrParameters[1] = strUploadUrl;
            arrParameters[2] = CommonUtils.GetClientJsonObject(objFileTransfer.GetProgressEventData());
            arrParameters[3] = CommonUtils.GetClientJsonObject(objOptions);
            arrParameters[4] = blnTrustAllHosts;
            arrParameters[5] = FileUploadEventArgsStore.StoreContextualSingleCallMethod(objFileTransfer, "upload", objCallback);


            Invoke("DeviceIntegrator.FileManager.uploadFile", arrParameters);
        }

        /// <summary>
        /// Resolves the local file system URI.
        /// </summary>
        /// <param name="strFileUri">The STR file URI.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void ResolveLocalFileSystemURI(string strFileUri, Action<EntryEventArgs> objCallback)
        {
            object[] arrParameters = new object[2];
            arrParameters[0] = strFileUri;
            arrParameters[1] = EntryEventArgsStore.StoreSingleCallMethod("resolve", objCallback);

            Invoke("DeviceIntegrator.FileManager.resolveLocalFileSystemURI", arrParameters);
        }

        
    }
}