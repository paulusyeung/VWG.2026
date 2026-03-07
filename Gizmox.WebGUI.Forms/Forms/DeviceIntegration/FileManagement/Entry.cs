// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry
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
  public abstract class Entry : DevicePropertyDictionary, IEntry
  {
    private IFileSystem mobjFileSystem;
    private FileManager mobjFileManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.Entry" /> class.
    /// </summary>
    /// <param name="objFileSystem">The obj file system.</param>
    internal Entry(FileManager objFileManager, IFileSystem objFileSystem)
    {
      this.mobjFileManager = objFileManager;
      this.mobjFileSystem = objFileSystem;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is file.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is file; otherwise, <c>false</c>.
    /// </value>
    public virtual bool IsFile
    {
      get => this.GetValuetypePropertyOrDefault<bool>("isFile");
      set => this.AddValueTypeProperty<bool>("isFile", value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is directory.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is directory; otherwise, <c>false</c>.
    /// </value>
    public virtual bool IsDirectory
    {
      get => this.GetValuetypePropertyOrDefault<bool>("isDirectory");
      set => this.AddValueTypeProperty<bool>("isDirectory", value);
    }

    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    public string Name
    {
      get => this.GetNullableProperty<string>("name");
      set => this.SetNullableProperty<string>("name", value);
    }

    /// <summary>Gets or sets the full path.</summary>
    /// <value>The full path.</value>
    public string FullPath
    {
      get => this.GetNullableProperty<string>("fullPath");
      set => this.SetNullableProperty<string>("fullPath", value);
    }

    /// <summary>Gets the metadata.</summary>
    /// <param name="objHandler">The obj handler.</param>
    public void GetMetadata(EventHandler<MetadataEventArgs> objHandler) => this.mobjFileManager.GetEntryMetadata(this, objHandler);

    /// <summary>Sets the metadata.</summary>
    /// <param name="objHandler">The obj handler.</param>
    public void SetMetadata(
      MetadataDictionary objValues,
      EventHandler<EmptyDeviceEventArgs> objHandler)
    {
      this.mobjFileManager.SetMetadata(this, objValues, objHandler);
    }

    /// <summary>Copies to.</summary>
    /// <param name="objParentDirectory">The obj parent directory.</param>
    /// <param name="strNewName">New name of the STR.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void CopyTo(
      IDirectoryEntry objParentDirectory,
      string strNewName,
      EventHandler<EntryEventArgs> objCallback)
    {
      this.mobjFileManager.ChangeFileLocation("copyToByPath", this, objParentDirectory, strNewName, objCallback);
    }

    /// <summary>Moves to.</summary>
    /// <param name="objParentDirectory">The obj parent directory.</param>
    /// <param name="strNewName">New name of the STR.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void MoveTo(
      IDirectoryEntry objParentDirectory,
      string strNewName,
      EventHandler<EntryEventArgs> objCallback)
    {
      this.mobjFileManager.ChangeFileLocation("moveToByPath", this, objParentDirectory, strNewName, objCallback);
    }

    /// <summary>Gets the file system.</summary>
    public IFileSystem FileSystem => this.mobjFileSystem;

    /// <summary>Gets the parent.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetParent(EventHandler<EntryEventArgs> objCallback) => this.mobjFileManager.GetParent(this, objCallback);

    /// <summary>Removes the specified obj callback.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void Remove(EventHandler<EmptyDeviceEventArgs> objCallback) => this.mobjFileManager.Remove(this, objCallback);

    /// <summary>Toes the URL.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void ToUrl(EventHandler<ToUrlEventArgs> objCallback) => this.mobjFileManager.ToUrl(this, objCallback);

    /// <summary>Gets the file manager.</summary>
    protected internal FileManager FileManager => this.mobjFileManager;

    internal static bool? IsEntryDirectoryFromVwgEvent(string strPrefix, IEvent objEvent)
    {
      if (!string.IsNullOrEmpty(objEvent[strPrefix + "ent.isDirectory"]))
        return new bool?(bool.Parse(objEvent[strPrefix + "ent.isDirectory"]));
      return !string.IsNullOrEmpty(objEvent[strPrefix + "ent.isFile"]) ? new bool?(!bool.Parse(objEvent[strPrefix + "ent.isFile"])) : new bool?();
    }

    /// <summary>Fills from event.</summary>
    /// <param name="strPrefix">The STR prefix.</param>
    /// <param name="objEntry">The obj entry.</param>
    /// <param name="objEvent">The obj event.</param>
    protected static void FillFromEvent(string strPrefix, Entry objEntry, IEvent objEvent)
    {
      objEntry.FullPath = objEvent[strPrefix + "ent.fullPath"];
      objEntry.Name = objEvent[strPrefix + "ent.name"];
      bool? nullable = Entry.IsEntryDirectoryFromVwgEvent(strPrefix, objEvent);
      if (!nullable.HasValue)
        return;
      if (nullable.Value)
        objEntry.IsDirectory = true;
      else
        objEntry.IsFile = true;
    }

    protected static void FillFromEvent(Entry objEntry, IEvent objEvent) => Entry.FillFromEvent(string.Empty, objEntry, objEvent);
  }
}
