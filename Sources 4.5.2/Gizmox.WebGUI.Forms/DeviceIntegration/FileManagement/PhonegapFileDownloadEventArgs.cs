using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PhonegapFileDownloadEventArgs : FileDownloadEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private IFileTransferError mobjFileTransferError;
        private IFileEntry mobjFileEntry;

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objManager">The obj manager.</param>
        /// <returns></returns>
        public static FileDownloadEventArgs FromVWGEvent(IEvent objEvent, FileManager objManager)
        {
            PhonegapFileDownloadEventArgs objFileDownloadEventArgs;

            if (DeviceEventArgs.TryGetError(objEvent, out objFileDownloadEventArgs))
            {
                objFileDownloadEventArgs.mobjFileTransferError = FileTransferError.FromVWGEvent(objEvent);
            }
            else
            {
                objFileDownloadEventArgs = new PhonegapFileDownloadEventArgs();
                objFileDownloadEventArgs.mobjFileEntry = Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileEntry.FromVWGEvent(objEvent, objManager, null);
            }

            return objFileDownloadEventArgs;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public override IFileTransferError Error
        {
            get { return mobjFileTransferError; }
        }

        /// <summary>
        /// Gets the file entry.
        /// </summary>
        public override IFileEntry FileEntry
        {
            get { return mobjFileEntry; }
        }
    }
}
