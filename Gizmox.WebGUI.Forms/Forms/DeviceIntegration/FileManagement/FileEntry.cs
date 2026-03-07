// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  [Serializable]
  public class FileEntry : Entry, IFileEntry, IEntry
  {
    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileSystem">The obj file system.</param>
    /// <returns></returns>
    internal static FileEntry FromVWGEvent(
      string strPrefix,
      IEvent objEvent,
      FileManager objFileManager,
      IFileSystem objFileSystem)
    {
      if (objEvent == null)
        return (FileEntry) null;
      FileEntry objEntry = new FileEntry(objFileManager, objFileSystem);
      Entry.FillFromEvent(strPrefix, (Entry) objEntry, objEvent);
      return objEntry;
    }

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    /// <param name="objFileSystem">The obj file system.</param>
    /// <returns></returns>
    internal static FileEntry FromVWGEvent(
      IEvent objEvent,
      FileManager objFileManager,
      IFileSystem objFileSystem)
    {
      return FileEntry.FromVWGEvent(string.Empty, objEvent, objFileManager, objFileSystem);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileEntry" /> class.
    /// </summary>
    /// <param name="objFileManager"></param>
    /// <param name="objFileSystem">The obj file system.</param>
    public FileEntry(FileManager objFileManager, IFileSystem objFileSystem)
      : base(objFileManager, objFileSystem)
    {
    }

    /// <summary>Gets the file.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetFile(EventHandler<FileEventArgs> objCallback) => this.FileManager.GetFile(this, objCallback);

    /// <summary>Creates the writer.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void CreateWriter(EventHandler<FileWriterEventArgs> objCallback) => this.FileManager.CreateWriter(this, objCallback);

    /// <summary>Creates the reader.</summary>
    /// <returns></returns>
    public IFileReader CreateReader() => (IFileReader) new FileReader((IFileEntry) this, this.FileManager);
  }
}
