using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class FileTransferError : IFileTransferError
    {
        private int mintHttpStatus;
        private string mstrSource;
        private string mstrTarget;

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        internal static IFileTransferError FromVWGEvent(IEvent objEvent)
        {
            FileTransferError objFileTransferError = new FileTransferError();

            int.TryParse(objEvent["http_status"], out objFileTransferError.mintHttpStatus);
            objFileTransferError.mstrSource = objEvent["source"];
            objFileTransferError.mstrTarget = objEvent["target"];

            return objFileTransferError;
        }

        /// <summary>
        /// Gets the HTTP status.
        /// </summary>
        public int HttpStatus
        {
            get { return mintHttpStatus; }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public string Source
        {
            get { return mstrSource; }
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        public string Target
        {
            get { return mstrTarget; }
        }
    }
}
