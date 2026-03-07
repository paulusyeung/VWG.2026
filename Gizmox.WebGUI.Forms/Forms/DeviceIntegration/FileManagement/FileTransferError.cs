// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileTransferError
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;

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

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    internal static IFileTransferError FromVWGEvent(IEvent objEvent)
    {
      FileTransferError fileTransferError = new FileTransferError();
      int.TryParse(objEvent["http_status"], out fileTransferError.mintHttpStatus);
      fileTransferError.mstrSource = objEvent["source"];
      fileTransferError.mstrTarget = objEvent["target"];
      return (IFileTransferError) fileTransferError;
    }

    /// <summary>Gets the HTTP status.</summary>
    public int HttpStatus => this.mintHttpStatus;

    /// <summary>Gets the source.</summary>
    public string Source => this.mstrSource;

    /// <summary>Gets the target.</summary>
    public string Target => this.mstrTarget;
  }
}
