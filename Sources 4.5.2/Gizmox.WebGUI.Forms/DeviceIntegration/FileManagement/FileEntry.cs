using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.FileManagement;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    [Serializable]
    public class FileEntry : Entry, IFileEntry
    {
        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileSystem">The obj file system.</param>
        /// <returns></returns>
        internal static FileEntry FromVWGEvent(string strPrefix, IEvent objEvent, FileManager objFileManager, IFileSystem objFileSystem)
        {
            if (objEvent != null) // In some cases, FileSystem can be null
            {
                FileEntry objDirectoryEntry = new FileEntry(objFileManager, objFileSystem);

                Entry.FillFromEvent(strPrefix, objDirectoryEntry, objEvent);

                return objDirectoryEntry;
            }

            return null;
        }

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileManager">The obj file manager.</param>
        /// <param name="objFileSystem">The obj file system.</param>
        /// <returns></returns>
        internal static FileEntry FromVWGEvent(IEvent objEvent, FileManager objFileManager, IFileSystem objFileSystem)
        {
            return FromVWGEvent(string.Empty, objEvent, objFileManager, objFileSystem);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEntry"/> class.
        /// </summary>
        /// <param name="objFileManager"></param>
        /// <param name="objFileSystem">The obj file system.</param>
        public FileEntry(FileManager objFileManager, IFileSystem objFileSystem)
            : base(objFileManager, objFileSystem)
        {

        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetFile(EventHandler<Common.Device.FileManagement.FileEventArgs> objCallback)
        {
            FileManager.GetFile(this, objCallback);
        }

        /// <summary>
        /// Creates the writer.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void CreateWriter(EventHandler<FileWriterEventArgs> objCallback)
        {
            FileManager.CreateWriter(this, objCallback);
        }

        /// <summary>
        /// Creates the reader.
        /// </summary>
        /// <returns></returns>
        public IFileReader CreateReader()
        {
            return new FileReader(this, base.FileManager);
        }
    }
}
