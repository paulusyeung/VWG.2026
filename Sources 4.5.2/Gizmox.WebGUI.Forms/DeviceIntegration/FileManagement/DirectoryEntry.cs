using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.FileManagement;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    [Serializable]
    public class DirectoryEntry : Entry, IDirectoryEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryEntry"/> class.
        /// </summary>
        /// <param name="objFileManager"></param>
        /// <param name="objFileSystem">The obj file system.</param>
        public DirectoryEntry(FileManager objFileManager, IFileSystem objFileSystem)
            : base(objFileManager, objFileSystem)
        {

        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is directory.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is directory; otherwise, <c>false</c>.
        /// </value>
        public override bool IsDirectory
        {
            get
            {
                return true;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is file.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is file; otherwise, <c>false</c>.
        /// </value>
        public override bool IsFile
        {
            get
            {
                return false;
            }
            set
            { }
        }

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="strPrefix">The STR prefix.</param>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileManager">The obj file manager.</param>
        /// <param name="objFileSystem">The obj file system.</param>
        /// <returns></returns>
        internal static DirectoryEntry FromVWGEvent(string strPrefix, IEvent objEvent, FileManager objFileManager, IFileSystem objFileSystem)
        {
            if (objEvent != null && objFileSystem != null)
            {
                DirectoryEntry objDirectoryEntry = new DirectoryEntry(objFileManager, objFileSystem);

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
        internal static DirectoryEntry FromVWGEvent(IEvent objEvent, FileManager objFileManager, IFileSystem objFileSystem)
        {
            return FromVWGEvent(string.Empty, objEvent, objFileManager, objFileSystem);
        }


        /// <summary>
        /// Gets the D irectory.
        /// </summary>
        /// <param name="strDirectoryPath">The STR file path.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void GetDirectory(string strDirectoryPath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)
        {
            FileManager.GetDirectory(this, strDirectoryPath, objOptions, objCallback);
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="strFilePath">The STR file path.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void GetFile(string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)
        {
            FileManager.GetFile(this, strFilePath, objOptions, objCallback);
        }

        /// <summary>
        /// Removes the recursively.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void RemoveRecursively(EventHandler<Common.Device.Common.EmptyDeviceEventArgs> objCallback)
        {
            FileManager.RemoveRecursively(this, objCallback);
        }

        /// <summary>
        /// Creates the reder.
        /// </summary>
        /// <returns></returns>
        public IDirectoryReader CreateReader()
        {
            return new DirectoryReader(this, this.FileManager);
        }
    }
}
