// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.DirectoryReader
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DirectoryReader : IDirectoryReader
  {
    private IDirectoryEntry mobjDirectory;
    private FileManager mobjFileManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.DirectoryReader" /> class.
    /// </summary>
    /// <param name="objDirectory">The obj directory.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    public DirectoryReader(IDirectoryEntry objDirectory, FileManager objFileManager)
    {
      this.mobjDirectory = objDirectory;
      this.mobjFileManager = objFileManager;
    }

    /// <summary>Gets the directory.</summary>
    internal IDirectoryEntry Directory => this.mobjDirectory;

    /// <summary>Reads the entries.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void ReadEntries(EventHandler<DirectoryReaderEventArgs> objCallback) => this.mobjFileManager.ReadEntries(this, objCallback);
  }
}
