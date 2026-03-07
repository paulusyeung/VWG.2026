// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines constants that indicate whether content is copied from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control to the Clipboard.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public enum DataGridViewClipboardCopyMode
  {
    /// <summary>Disable</summary>
    Disable,
    /// <summary>EnableWithAutoHeaderText</summary>
    EnableWithAutoHeaderText,
    /// <summary>EnableWithoutHeaderText</summary>
    EnableWithoutHeaderText,
    /// <summary>EnableAlwaysIncludeHeaderText</summary>
    EnableAlwaysIncludeHeaderText,
  }
}
