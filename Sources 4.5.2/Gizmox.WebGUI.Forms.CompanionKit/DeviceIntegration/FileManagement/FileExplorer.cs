#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Forms.Google;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Common;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.Client;

#endregion

namespace CompanionKit.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FileExplorer : UserControl
    {
        private IFileManagement mobjFileManager;
        private IFileSystem mobjFileSystem;
        private List<IEntry> mobjItemsToDelete;
        private List<IEntry> mobjItemsToDeleteWithError;

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> class.
        /// </summary>
        public FileExplorer()
        {
            // Initialize global object
            mobjFileManager = VWGContext.Current.DeviceIntegrator.FileManager;
            mobjItemsToDelete = new List<IEntry>();
            mobjItemsToDeleteWithError = new List<IEntry>();

            InitializeComponent();

            // Register global events
            FileExplorerClipBoard.Current.Loaded += new EventHandler(Clipboard_Loaded);
            FileExplorerClipBoard.Current.EntryPasted += Clipboard_EntryPasted;
            this.folderList1.ListView.SelectedIndexChanged += new EventHandler(ListView_SelectedIndexChanged);
            this.folderList1.ListView.ItemCheck += new ItemCheckHandler(ListView_ItemCheck);
            this.folderList1.DirectoryChanged += new EventHandler<EntryEventArgs>(folderList1_DirectoryChanged);
            
            // Request the file system
            mobjFileManager.RequestFileSystem(Gizmox.WebGUI.Common.Device.FileManagement.FileSystemType.Persistent, 0, FileSystemReceived);
        }

        /// <summary>
        /// Handles the DirectoryChanged event of the folderList1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.FileManagement.EntryEventArgs"/> instance containing the event data.</param>
        void folderList1_DirectoryChanged(object sender, EntryEventArgs e)
        {
            UpdateToolStrip();
        }

        /// <summary>
        /// Handles the ItemCheck event of the ListView control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        void ListView_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {
            UpdateToolStrip();
        }

        /// <summary>
        /// Handles the EntryPasted event of the Current control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement.FilePastedEventArgs"/> instance containing the event data.</param>
        void Clipboard_EntryPasted(object sender, FilePastedEventArgs e)
        {
            // Disable the paste button
            this.mobjPasteButton.Enabled = false;

            // Refresh the folder to show the current state
            this.folderList1.Reload();

            // Update
            UpdateToolStrip();
        }

        /// <summary>
        /// Handles the Loaded event of the Current control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Clipboard_Loaded(object sender, EventArgs e)
        {
            // Show the paste button
            this.mobjPasteButton.Enabled = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem objItem = this.folderList1.ListView.SelectedItem;

            if (objItem != null && objItem.Tag is IEntry)
            {
                IEntry objEntry = objItem.Tag as IEntry;

                // If the entry is a folder, navigate inside it
                if (objEntry.IsDirectory)
                {
                    this.folderList1.LoadFolder(objEntry);
                }
            }
        }

        /// <summary>
        /// Updates the tool strip.
        /// </summary>
        private void UpdateToolStrip()
        {
            // If the current folder is the root folder, disable the FolderUp button. Othewise enable it
            if (this.folderList1.CurrentDirectory.FullPath == mobjFileSystem.Root.FullPath)
            {
                mobjFolderUpButton.Enabled = false;
            }
            else
            {
                mobjFolderUpButton.Enabled = true;
            }

            // If items are selected, show the clipboard and delete buttons
            if (this.folderList1.ListView.CheckedItems.Count > 0)
            {
                mobjDeleteButton.Enabled = mobjCopyButton.Enabled = mobjCutButton.Enabled = true;
            }
            else
            {
                mobjDeleteButton.Enabled = mobjCopyButton.Enabled = mobjCutButton.Enabled = false;
            }
        }

        /// <summary>
        /// Event when getting the file system from the client
        /// </summary>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs"/> instance containing the event data.</param>
        private void FileSystemReceived(FileSystemEventArgs objArguments)
        {
            if (!objArguments.HasError)
            {
                // Save a reference to the fileSystem
                this.mobjFileSystem = objArguments.FileSystem;

                // Load the root directory
                this.folderList1.LoadFolder(mobjFileSystem.Root);
            }
            else
            {
                throw new Exception("");
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjFolderUpButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjFolderUpButton_Click(object sender, EventArgs e)
        {
            // Get the parent folder
            this.folderList1.CurrentDirectory.GetParent(GotParent);
        }

        /// <summary>
        /// Gots the parent.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.FileManagement.EntryEventArgs"/> instance containing the event data.</param>
        private void GotParent(object sender, EntryEventArgs objArguments)
        {
            // Load the parent folder 
            if (!objArguments.HasError)
            {
                this.folderList1.LoadFolder(objArguments.Entry as IDirectoryEntry);
            }
            else
            {
                throw new Exception("Got Parent");
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjCopyButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjCopyButton_Click(object sender, EventArgs e)
        {
            List<IEntry> objEntries = GetSelectedEntries();

            if (objEntries.Count > 0)
            {
                FileExplorerClipBoard.Current.Copy(objEntries);
            }
        }

        /// <summary>
        /// Gets the selected entries.
        /// </summary>
        /// <returns></returns>
        private List<IEntry> GetSelectedEntries()
        {
            List<IEntry> objEntries = new List<IEntry>();
            foreach (ListViewItem objItem in folderList1.ListView.CheckedItems)
            {
                if (objItem != null && objItem.Tag is IEntry)
                {
                    objEntries.Add(objItem.Tag as IEntry);
                }
            }
            return objEntries;
        }

        /// <summary>
        /// Handles the Click event of the mobjCutButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjCutButton_Click(object sender, EventArgs e)
        {
            List<IEntry> objEntries = GetSelectedEntries();
            if (objEntries.Count > 0)
            {
                FileExplorerClipBoard.Current.Cut(objEntries);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjPasteButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjPasteButton_Click(object sender, EventArgs e)
        {
            FileExplorerClipBoard.Current.Paste(this.folderList1.CurrentDirectory);
        }

        /// <summary>
        /// Handles the Click event of the mobjDeleteButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjDeleteButton_Click(object sender, EventArgs e)
        {
            if (folderList1.ListView.CheckedItems.Count > 0)
            {
                // The the items to be deleted
                List<IEntry> objEntries = GetSelectedEntries();
                ConfirmOptions objOptions = new ConfirmOptions();

                objOptions.ButtonsText = new string[]{"Yes", "No"};
                objOptions.Title = "Delete";

                string strMessage = string.Empty;

                if (objEntries.Count == 1)
                {
                    strMessage = objEntries[0].Name;
                }
                else
                {
                    strMessage = objEntries.Count + " items";
                }

                // Show a confirmation box to the user
                VWGContext.Current.DeviceIntegrator.Notifications.Confirm(string.Format("Are you sure you want to delete {0}?", strMessage), objOptions, DeleteConfirmationCallback);
            }
        }

        /// <summary>
        /// Deletes the confirmation callback.
        /// </summary>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.Notifications.ConfirmEventArgs"/> instance containing the event data.</param>
        private void DeleteConfirmationCallback(ConfirmEventArgs objArguments)
        {
            if (folderList1.ListView.CheckedItems.Count > 0)
            {
                if (objArguments.ButtonIndex == 1) // Yes
                {
                    mobjItemsToDelete = GetSelectedEntries();

                    foreach (IEntry objEntry in mobjItemsToDelete)
                    {
                        objEntry.Remove(EntryRemoved);
                    }
                }
                else if (objArguments.ButtonIndex == 2) // No
                {
                    mobjItemsToDelete.Clear();
                }
            }
        }

        /// <summary>
        /// Entries the removed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="objArguments">The <see cref="Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs"/> instance containing the event data.</param>
        private void EntryRemoved(object sender, EmptyDeviceEventArgs objArguments)
        {
            IEntry objEntry = sender as IEntry;

            if (objEntry != null)
            {
                mobjItemsToDelete.Remove(objEntry);

                if (objArguments.HasError)
                {
                    mobjItemsToDeleteWithError.Add(objEntry);
                }

                if (mobjItemsToDelete.Count == 0)
                {
                    string strMessage = "Done!";

                    this.folderList1.Reload();
                    if (mobjItemsToDeleteWithError.Count != 0)
                    {
                        if (mobjItemsToDeleteWithError.Count == 1)
                        {
                            strMessage = string.Format("Could not delete {0}", mobjItemsToDeleteWithError[0].Name);
                        }
                        else
                        {
                            strMessage = string.Format("Could not delete {0} items", mobjItemsToDeleteWithError.Count);
                        }
                    }

                    VWGContext.Current.DeviceIntegrator.Notifications.Alert(strMessage);
                    mobjItemsToDelete.Clear();
                }
            }
        }
    }
}