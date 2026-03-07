// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileSystem
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
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class FileSystem : DevicePropertyDictionary, IFileSystem
  {
    private FileSystemType menmType;
    private ulong lngRequestedSize;

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    public static FileSystem FromVWGEvent(FileManager objFileManager, IEvent objEvent)
    {
      if (objEvent == null)
        return (FileSystem) null;
      FileSystem objFileSystem = new FileSystem();
      objFileSystem.Name = objEvent["filesystemName"];
      if (!string.IsNullOrEmpty(objEvent["filesystemSize"]) && !string.IsNullOrEmpty(objEvent["filesystemType"]))
      {
        objFileSystem.Type = (FileSystemType) int.Parse(objEvent["filesystemType"]);
        objFileSystem.RequestedSize = ulong.Parse(objEvent["filesystemSize"]);
      }
      objFileSystem.Root = (IDirectoryEntry) DirectoryEntry.FromVWGEvent(objEvent, objFileManager, (IFileSystem) objFileSystem);
      return objFileSystem;
    }

    public ulong RequestedSize
    {
      get => this.lngRequestedSize;
      internal set => this.lngRequestedSize = value;
    }

    public FileSystemType Type
    {
      get => this.menmType;
      internal set => this.menmType = value;
    }

    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    public string Name
    {
      get => this.GetNullableProperty<string>("name");
      set => this.SetNullableProperty<string>("name", value);
    }

    /// <summary>Gets or sets the root.</summary>
    /// <value>The root.</value>
    public IDirectoryEntry Root
    {
      get => (IDirectoryEntry) this.GetNullableProperty<DirectoryEntry>("root");
      set => this.SetNullableProperty<IDirectoryEntry>("root", value);
    }
  }
}
