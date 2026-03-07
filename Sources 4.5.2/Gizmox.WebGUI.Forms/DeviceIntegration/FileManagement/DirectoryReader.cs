using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.FileManagement;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DirectoryReader : IDirectoryReader
    {
        private IDirectoryEntry mobjDirectory;
        private FileManager mobjFileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryReader"/> class.
        /// </summary>
        /// <param name="objDirectory">The obj directory.</param>
        /// <param name="objFileManager">The obj file manager.</param>
        public DirectoryReader(IDirectoryEntry objDirectory, FileManager objFileManager)
        {
            mobjDirectory = objDirectory;
            mobjFileManager = objFileManager;
        }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        internal IDirectoryEntry Directory
        {
            get { return mobjDirectory; }
        }

        /// <summary>
        /// Reads the entries.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void ReadEntries(EventHandler<DirectoryReaderEventArgs> objCallback)
        {
            mobjFileManager.ReadEntries(this, objCallback);
        }
    }
}
