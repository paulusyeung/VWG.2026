using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    [Serializable]
    public class FileTransfer : IFileTransfer
    {
        private FileManager mobjManager;
        private KeyValuePair<string, object[]> mobjProgressClientCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTransfer"/> class.
        /// </summary>
        /// <param name="objManager">The obj manager.</param>
        internal FileTransfer(FileManager objManager)
        {
            mobjManager = objManager;
        }

        /// <summary>
        /// Downloads the specified STR source URL.
        /// </summary>
        /// <param name="strSourceUrl">The STR source URL.</param>
        /// <param name="strDestinationFileFullPath">The STR destination file full path.</param>
        /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
        /// <param name="objCallback">The obj callback.</param>
        public void Download(string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler<FileDownloadEventArgs> objCallback)
        {
            mobjManager.Download(this, strSourceUrl, strDestinationFileFullPath, blnTrustAllHosts, objCallback);
        }

        /// <summary>
        /// Uploads the specified STR full file path.
        /// </summary>
        /// <param name="strFullFilePath">The STR full file path.</param>
        /// <param name="strUploadUrl">The STR upload URL.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
        /// <param name="objCallback">The obj callback.</param>
        public void Upload(string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler<FileUploadEventArgs> objCallback)
        {
            mobjManager.Upload(this, strFullFilePath, strUploadUrl, objOptions, blnTrustAllHosts, objCallback);
        }

        /// <summary>
        /// Gets the progress event data.
        /// </summary>
        /// <returns></returns>
        internal IDictionary<string, object> GetProgressEventData()
        {
            IDictionary<string, object> objData = new Dictionary<string, object>();

            if (this.mobjProgressClientCallback.Key != null)
            {
                objData.Add("client", this.mobjProgressClientCallback.Key);
                if (this.mobjProgressClientCallback.Value != null) 
                {
                    objData.Add("clientp", this.mobjProgressClientCallback.Value);
                }
            }

            if (objData.Count > 0)
            {
                return objData;
            }
            return null;
        }
    }
}
