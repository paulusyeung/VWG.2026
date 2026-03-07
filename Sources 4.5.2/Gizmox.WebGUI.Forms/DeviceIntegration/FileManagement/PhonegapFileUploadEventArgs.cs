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
    public class PhonegapFileUploadEventArgs : FileUploadEventArgs
    {
        private IFileTransferError mobjFileTransferError;
        private ulong mlngBytesSent;
        private string mstrResponse;
        private int mintResponseCode;

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        public static FileUploadEventArgs FromVWGEvent(IEvent objEvent)
        {
            PhonegapFileUploadEventArgs objFileDownloadEventArgs;

            if (DeviceEventArgs.TryGetError(objEvent, out objFileDownloadEventArgs))
            {
                objFileDownloadEventArgs.mobjFileTransferError = FileTransferError.FromVWGEvent(objEvent);
            }
            else
            {
                objFileDownloadEventArgs = new PhonegapFileUploadEventArgs();
                objFileDownloadEventArgs.mstrResponse = objEvent["response"];
                ulong.TryParse(objEvent["bytesSent"], out objFileDownloadEventArgs.mlngBytesSent);
                int.TryParse(objEvent["responseCode"], out objFileDownloadEventArgs.mintResponseCode);
            }

            return objFileDownloadEventArgs;
        }

        /// <summary>
        /// Gets the bytes sent.
        /// </summary>
        public override ulong BytesSent
        {
            get
            {
                return mlngBytesSent;
            }
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        public override string Response
        {
            get
            {
                return mstrResponse;
            }
        }

        /// <summary>
        /// Gets the response code.
        /// </summary>
        public override int ResponseCode
        {
            get
            {
                return mintResponseCode;
            }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public override IFileTransferError Error
        {
            get { return mobjFileTransferError; }
        }
    }
}
