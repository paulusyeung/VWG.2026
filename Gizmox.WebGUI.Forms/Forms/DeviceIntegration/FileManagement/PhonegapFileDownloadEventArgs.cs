// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.PhonegapFileDownloadEventArgs
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
  public class PhonegapFileDownloadEventArgs : FileDownloadEventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    private IFileTransferError mobjFileTransferError;
    private IFileEntry mobjFileEntry;

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <returns></returns>
    public static FileDownloadEventArgs FromVWGEvent(IEvent objEvent, FileManager objManager)
    {
      PhonegapFileDownloadEventArgs objEventArgs;
      if (DeviceEventArgs.TryGetError<PhonegapFileDownloadEventArgs>(objEvent, out objEventArgs))
      {
        objEventArgs.mobjFileTransferError = FileTransferError.FromVWGEvent(objEvent);
      }
      else
      {
        objEventArgs = new PhonegapFileDownloadEventArgs();
        objEventArgs.mobjFileEntry = (IFileEntry) Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileEntry.FromVWGEvent(objEvent, objManager, (IFileSystem) null);
      }
      return (FileDownloadEventArgs) objEventArgs;
    }

    /// <summary>Gets the error.</summary>
    public override IFileTransferError Error => this.mobjFileTransferError;

    /// <summary>Gets the file entry.</summary>
    public override IFileEntry FileEntry => this.mobjFileEntry;
  }
}
