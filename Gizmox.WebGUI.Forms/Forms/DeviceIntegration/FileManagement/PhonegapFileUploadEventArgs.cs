// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.PhonegapFileUploadEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;

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

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    public static FileUploadEventArgs FromVWGEvent(IEvent objEvent)
    {
      PhonegapFileUploadEventArgs objEventArgs;
      if (DeviceEventArgs.TryGetError<PhonegapFileUploadEventArgs>(objEvent, out objEventArgs))
      {
        objEventArgs.mobjFileTransferError = FileTransferError.FromVWGEvent(objEvent);
      }
      else
      {
        objEventArgs = new PhonegapFileUploadEventArgs();
        objEventArgs.mstrResponse = objEvent["response"];
        ulong.TryParse(objEvent["bytesSent"], out objEventArgs.mlngBytesSent);
        int.TryParse(objEvent["responseCode"], out objEventArgs.mintResponseCode);
      }
      return (FileUploadEventArgs) objEventArgs;
    }

    /// <summary>Gets the bytes sent.</summary>
    public override ulong BytesSent => this.mlngBytesSent;

    /// <summary>Gets the response.</summary>
    public override string Response => this.mstrResponse;

    /// <summary>Gets the response code.</summary>
    public override int ResponseCode => this.mintResponseCode;

    /// <summary>Gets the error.</summary>
    public override IFileTransferError Error => this.mobjFileTransferError;
  }
}
