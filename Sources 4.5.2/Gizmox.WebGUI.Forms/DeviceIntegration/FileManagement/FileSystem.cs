using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.FileManagement;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class FileSystem : DevicePropertyDictionary, IFileSystem
    {
        private FileSystemType menmType;
        private ulong lngRequestedSize;
        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        public static FileSystem FromVWGEvent(FileManager objFileManager, IEvent objEvent)
        {
            if (objEvent != null)
            {
                FileSystem objFileSystem = new FileSystem();

                objFileSystem.Name = objEvent["filesystemName"];

                if (!string.IsNullOrEmpty(objEvent["filesystemSize"]) && !string.IsNullOrEmpty(objEvent["filesystemType"]))
                {
                    objFileSystem.Type = (FileSystemType)int.Parse(objEvent["filesystemType"]);
                    objFileSystem.RequestedSize = ulong.Parse(objEvent["filesystemSize"]);
                }

                objFileSystem.Root = DirectoryEntry.FromVWGEvent(objEvent, objFileManager, objFileSystem);

                return objFileSystem;
            }
            return null;
        }

        public ulong RequestedSize
        {
            get
            {
                return lngRequestedSize;
            }
            internal set
            {

                lngRequestedSize = value;
            }
        }

        public FileSystemType Type
        {
            get
            {
                return menmType;
            }
            internal set
            {
                menmType = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return GetNullableProperty<string>("name");
            }
            set
            {
                SetNullableProperty("name", value);
            }
        }

        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public IDirectoryEntry Root
        {
            get
            {
                return GetNullableProperty<DirectoryEntry>("root");
            }
            set
            {
                SetNullableProperty("root", value);
            }
        }
    }
}
