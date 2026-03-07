using System;
using System.Collections.Generic;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.FileManagement;

namespace Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class FilePastedEventArgs : EventArgs 
    {
        private bool mblnIsCopy;
        private List<IEntry> mobjErrorEntries;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilePastedEventArgs"/> class.
        /// </summary>
        /// <param name="objErrorEntries">The obj error entries.</param>
        /// <param name="blnIsCopy">if set to <c>true</c> [BLN is copy].</param>
        public FilePastedEventArgs(List<IEntry> objErrorEntries, bool blnIsCopy)
        {
            mobjErrorEntries = objErrorEntries;
            mblnIsCopy = blnIsCopy;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is copy.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is copy; otherwise, <c>false</c>.
        /// </value>
        public bool IsCopy
        {
            get { return mblnIsCopy; }
        }

        /// <summary>
        /// Gets or sets the error entries.
        /// </summary>
        /// <value>
        /// The error entries.
        /// </value>
        public List<IEntry> ErrorEntries
        {
            get { return mobjErrorEntries; }
            set { mobjErrorEntries = value; }
        }
    }

    /// <summary>
    /// Handles clipboard operations
    /// </summary>
    public class FileExplorerClipBoard
    {
        private List<IEntry> mobjEntries;
        private List<IEntry> mobjErrorEntries;
        private bool? mblnIsCopy;
        private EventHandler<FilePastedEventArgs> mobjEntryPasted;
        private EventHandler mobjLoaded;

        /// <summary>
        /// Gets the current.
        /// </summary>
        public static FileExplorerClipBoard Current
        {
            get
            {
                if (VWGContext.Current["ClipBoard"] == null)
                {
                    VWGContext.Current["ClipBoard"] = new FileExplorerClipBoard();
                }

                return VWGContext.Current["ClipBoard"] as FileExplorerClipBoard;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="FileExplorerClipBoard"/> class from being created.
        /// </summary>
        private FileExplorerClipBoard()
        {
            mobjErrorEntries = new List<IEntry>();
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        private void OnLoaded()
        {
            if (mobjLoaded != null)
            {
                mobjLoaded(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Pastes the specified obj directory.
        /// </summary>
        /// <param name="objDirectory">The obj directory.</param>
        public void Paste(IDirectoryEntry objDirectory)
        {
            if (mblnIsCopy.HasValue && mobjEntries != null && objDirectory != null)
            {
                foreach (IEntry objEntry in mobjEntries)
                {
                    if (mblnIsCopy.Value)
                    {

                        objEntry.CopyTo(objDirectory, objEntry.Name, FilePasted);
                    }
                    else
                    {
                        objEntry.MoveTo(objDirectory, objEntry.Name, FilePasted);
                    }
                }
            }
        }

        /// <summary>
        /// Files the pasted.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.FileManagement.EntryEventArgs"/> instance containing the event data.</param>
        private void FilePasted(object sender, EntryEventArgs objArguments)
        {
            IEntry objEntry = sender as IEntry;
            if (objEntry != null)
            {
                mobjEntries.Remove(objEntry);
                if (!objArguments.HasError)
                {

                }
                else
                {
                    mobjErrorEntries.Add(objEntry);
                }
            }
            if (mobjEntries.Count == 0)
            {
                if (mobjEntryPasted != null)
                {
                    mobjEntryPasted(this, new FilePastedEventArgs(mobjErrorEntries, this.mblnIsCopy.Value));
                    this.mblnIsCopy = null;
                    mobjErrorEntries.Clear();
                }
            }
        }

        /// <summary>
        /// Occurs when [entry pasted].
        /// </summary>
        public event EventHandler<FilePastedEventArgs> EntryPasted
        {
            add { mobjEntryPasted += value; }
            remove { mobjEntryPasted -= value; }
        }

        /// <summary>
        /// Occurs when [loaded].
        /// </summary>
        public event EventHandler Loaded
        {
            add { mobjLoaded += value; }
            remove { mobjLoaded -= value; }
        }

        /// <summary>
        /// Copies the specified obj entries.
        /// </summary>
        /// <param name="objEntries">The obj entries.</param>
        internal void Copy(List<IEntry> objEntries)
        {
            if (objEntries != null)
            {
                mobjEntries = objEntries;
                mblnIsCopy = true;

                OnLoaded();
            }
        }

        /// <summary>
        /// Cuts the specified obj entries.
        /// </summary>
        /// <param name="objEntries">The obj entries.</param>
        internal void Cut(List<IEntry> objEntries)
        {
            if (objEntries != null)
            {
                mobjEntries = objEntries;
                mblnIsCopy = false;

                OnLoaded();
            }
        }
    }
}