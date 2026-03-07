using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Forms.Client;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class Entry : DevicePropertyDictionary, IEntry
    {
        private IFileSystem mobjFileSystem;
        private FileManager mobjFileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        /// <param name="objFileSystem">The obj file system.</param>
        internal Entry(FileManager objFileManager, IFileSystem objFileSystem)
        {
            mobjFileManager = objFileManager;
            mobjFileSystem = objFileSystem;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is file.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is file; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsFile
        {
            get
            {
                return GetValuetypePropertyOrDefault<bool>("isFile");
            }
            set
            {
                AddValueTypeProperty("isFile", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is directory.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is directory; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsDirectory
        {
            get
            {
                return GetValuetypePropertyOrDefault<bool>("isDirectory");
            }
            set
            {
                AddValueTypeProperty("isDirectory", value);
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
        /// Gets or sets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        public string FullPath
        {
            get
            {
                return GetNullableProperty<string>("fullPath");
            }
            set
            {
                SetNullableProperty("fullPath", value);
            }
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <param name="objHandler">The obj handler.</param>
        public void GetMetadata(EventHandler<MetadataEventArgs> objHandler)
        {
            mobjFileManager.GetEntryMetadata(this, objHandler);
        }

        /// <summary>
        /// Sets the metadata.
        /// </summary>
        /// <param name="objHandler">The obj handler.</param>
        public void SetMetadata(MetadataDictionary objValues, EventHandler<EmptyDeviceEventArgs> objHandler)
        {
            mobjFileManager.SetMetadata(this, objValues, objHandler);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="objParentDirectory">The obj parent directory.</param>
        /// <param name="strNewName">New name of the STR.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void CopyTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)
        {
            mobjFileManager.ChangeFileLocation("copyToByPath", this, objParentDirectory, strNewName, objCallback);
        }

        /// <summary>
        /// Moves to.
        /// </summary>
        /// <param name="objParentDirectory">The obj parent directory.</param>
        /// <param name="strNewName">New name of the STR.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void MoveTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)
        {
            mobjFileManager.ChangeFileLocation("moveToByPath", this, objParentDirectory, strNewName, objCallback);
        }

        /// <summary>
        /// Gets the file system.
        /// </summary>
        public IFileSystem FileSystem
        {
            get { return mobjFileSystem; }
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void GetParent(EventHandler<EntryEventArgs> objCallback)
        {
            mobjFileManager.GetParent(this, objCallback);
        }

        /// <summary>
        /// Removes the specified obj callback.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void Remove(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            mobjFileManager.Remove(this, objCallback);
        }

        /// <summary>
        /// Toes the URL.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void ToUrl(EventHandler<ToUrlEventArgs> objCallback)
        {
            mobjFileManager.ToUrl(this, objCallback);
        }

        /// <summary>
        /// Gets the file manager.
        /// </summary>
        protected internal FileManager FileManager
        {
            get { return mobjFileManager; }
        }

        internal static bool? IsEntryDirectoryFromVwgEvent(string strPrefix, Common.Interfaces.IEvent objEvent)
        {
            if (!string.IsNullOrEmpty(objEvent[strPrefix + "ent.isDirectory"]))
            {
                return bool.Parse(objEvent[strPrefix + "ent.isDirectory"]);
            }
            else if (!string.IsNullOrEmpty(objEvent[strPrefix + "ent.isFile"]))
            {
                return !bool.Parse(objEvent[strPrefix + "ent.isFile"]);
            }

            return null;
        }

        /// <summary>
        /// Fills from event.
        /// </summary>
        /// <param name="strPrefix">The STR prefix.</param>
        /// <param name="objEntry">The obj entry.</param>
        /// <param name="objEvent">The obj event.</param>
        protected static void FillFromEvent(string strPrefix, Entry objEntry, Common.Interfaces.IEvent objEvent)
        {
            objEntry.FullPath = objEvent[strPrefix + "ent.fullPath"];
            objEntry.Name = objEvent[strPrefix + "ent.name"];

            bool? isDirectory = IsEntryDirectoryFromVwgEvent(strPrefix, objEvent);
            if (isDirectory.HasValue)
            {
                if (isDirectory.Value)
                {
                    objEntry.IsDirectory = true;
                }
                else
                {
                    objEntry.IsFile = true;
                }
            }
        }

        protected static void FillFromEvent(Entry objEntry, Common.Interfaces.IEvent objEvent)
        {
            FillFromEvent(string.Empty, objEntry, objEvent);
        }
    }
}
