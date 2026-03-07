// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileTransfer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  [Serializable]
  public class FileTransfer : IFileTransfer
  {
    private FileManager mobjManager;
    private KeyValuePair<string, object[]> mobjProgressClientCallback;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileTransfer" /> class.
    /// </summary>
    /// <param name="objManager">The obj manager.</param>
    internal FileTransfer(FileManager objManager) => this.mobjManager = objManager;

    /// <summary>Downloads the specified STR source URL.</summary>
    /// <param name="strSourceUrl">The STR source URL.</param>
    /// <param name="strDestinationFileFullPath">The STR destination file full path.</param>
    /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
    /// <param name="objCallback">The obj callback.</param>
    public void Download(
      string strSourceUrl,
      string strDestinationFileFullPath,
      bool blnTrustAllHosts,
      EventHandler<FileDownloadEventArgs> objCallback)
    {
      this.mobjManager.Download(this, strSourceUrl, strDestinationFileFullPath, blnTrustAllHosts, objCallback);
    }

    /// <summary>Uploads the specified STR full file path.</summary>
    /// <param name="strFullFilePath">The STR full file path.</param>
    /// <param name="strUploadUrl">The STR upload URL.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="blnTrustAllHosts">if set to <c>true</c> [BLN trust all hosts].</param>
    /// <param name="objCallback">The obj callback.</param>
    public void Upload(
      string strFullFilePath,
      string strUploadUrl,
      FileUploadOptions objOptions,
      bool blnTrustAllHosts,
      EventHandler<FileUploadEventArgs> objCallback)
    {
      this.mobjManager.Upload(this, strFullFilePath, strUploadUrl, objOptions, blnTrustAllHosts, objCallback);
    }

    /// <summary>Gets the progress event data.</summary>
    /// <returns></returns>
    internal IDictionary<string, object> GetProgressEventData()
    {
      IDictionary<string, object> dictionary = (IDictionary<string, object>) new Dictionary<string, object>();
      if (this.mobjProgressClientCallback.Key != null)
      {
        dictionary.Add("client", (object) this.mobjProgressClientCallback.Key);
        if (this.mobjProgressClientCallback.Value != null)
          dictionary.Add("clientp", (object) this.mobjProgressClientCallback.Value);
      }
      return dictionary.Count > 0 ? dictionary : (IDictionary<string, object>) null;
    }
  }
}
