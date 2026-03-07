// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AutoCompleteSource
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the source for ComboBox and TextBox automatic completion functionality.
  /// </summary>
  public enum AutoCompleteSource
  {
    /// <summary>Specifies the file system as the source.</summary>
    FileSystem = 1,
    /// <summary>
    /// Includes the Uniform Resource Locators (URLs) in the history list.
    /// </summary>
    HistoryList = 2,
    /// <summary>
    /// Includes the Uniform Resource Locators (URLs) in the list of those URLs most recently used.
    /// </summary>
    RecentlyUsedList = 4,
    /// <summary>
    /// Specifies the equivalent of HistoryList and RecentlyUsedList as the source.
    /// </summary>
    AllUrl = 6,
    /// <summary>
    /// Specifies the equivalent of FileSystem and AllUrl as the source.
    /// This is the default value when AutoCompleteMode has been set to a value other than
    /// the default.
    /// </summary>
    AllSystemSources = 7,
    /// <summary>
    /// Specifies that only directory names and not file names will be automatically completed.
    /// </summary>
    FileSystemDirectories = 32, // 0x00000020
    /// <summary>
    /// Specifies strings from a built-in AutoCompleteStringCollection as the source.
    /// </summary>
    CustomSource = 64, // 0x00000040
    /// <summary>
    /// Specifies that no AutoCompleteSource is currently in use.
    /// This is the default value of AutoCompleteSource.
    /// </summary>
    None = 128, // 0x00000080
    /// <summary>
    /// Specifies that the items of the ComboBox represent the source.
    /// </summary>
    ListItems = 256, // 0x00000100
  }
}
