// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.DirectoryEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  [Serializable]
  public class DirectoryEntry : Entry, IDirectoryEntry, IEntry
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.DirectoryEntry" /> class.
    /// </summary>
    /// <param name="objFileManager"></param>
    /// <param name="objFileSystem">The obj file system.</param>
    public DirectoryEntry(FileManager objFileManager, IFileSystem objFileSystem)
      : base(objFileManager, objFileSystem)
    {
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is directory.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is directory; otherwise, <c>false</c>.
    /// </value>
    public override bool IsDirectory
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is file.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is file; otherwise, <c>false</c>.
    /// </value>
    public override bool IsFile
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Froms the VWG event.</summary>
    /// <param name="strPrefix">The STR prefix.</param>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    /// <param name="objFileSystem">The obj file system.</param>
    /// <returns></returns>
    internal static DirectoryEntry FromVWGEvent(
      string strPrefix,
      IEvent objEvent,
      FileManager objFileManager,
      IFileSystem objFileSystem)
    {
      if (objEvent == null || objFileSystem == null)
        return (DirectoryEntry) null;
      DirectoryEntry objEntry = new DirectoryEntry(objFileManager, objFileSystem);
      Entry.FillFromEvent(strPrefix, (Entry) objEntry, objEvent);
      return objEntry;
    }

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    /// <param name="objFileSystem">The obj file system.</param>
    /// <returns></returns>
    internal static DirectoryEntry FromVWGEvent(
      IEvent objEvent,
      FileManager objFileManager,
      IFileSystem objFileSystem)
    {
      return DirectoryEntry.FromVWGEvent(string.Empty, objEvent, objFileManager, objFileSystem);
    }

    /// <summary>Gets the D irectory.</summary>
    /// <param name="strDirectoryPath">The STR file path.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void GetDirectory(
      string strDirectoryPath,
      FlagsOptions objOptions,
      EventHandler<EntryEventArgs> objCallback)
    {
      this.FileManager.GetDirectory(this, strDirectoryPath, objOptions, objCallback);
    }

    /// <summary>Gets the file.</summary>
    /// <param name="strFilePath">The STR file path.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void GetFile(
      string strFilePath,
      FlagsOptions objOptions,
      EventHandler<EntryEventArgs> objCallback)
    {
      this.FileManager.GetFile(this, strFilePath, objOptions, objCallback);
    }

    /// <summary>Removes the recursively.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void RemoveRecursively(EventHandler<EmptyDeviceEventArgs> objCallback) => this.FileManager.RemoveRecursively(this, objCallback);

    /// <summary>Creates the reder.</summary>
    /// <returns></returns>
    public IDirectoryReader CreateReader() => (IDirectoryReader) new DirectoryReader((IDirectoryEntry) this, this.FileManager);
  }
}
