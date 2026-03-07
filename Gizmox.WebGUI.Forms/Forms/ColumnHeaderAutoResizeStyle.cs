// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies how a column contained in a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> should be resized.</summary>
  public enum ColumnHeaderAutoResizeStyle
  {
    /// <summary>Specifies no resizing should occur.</summary>
    None,
    /// <summary>
    /// Specifies the column should be resized based on the length of the column header content.
    /// </summary>
    HeaderSize,
    /// <summary>
    /// Specifies the column should be resized based on the length of the column content.
    /// </summary>
    ColumnContent,
  }
}
