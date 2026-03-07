// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewHitTestType
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies a location in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public enum DataGridViewHitTestType
  {
    /// <summary>None</summary>
    None,
    /// <summary>Cell</summary>
    Cell,
    /// <summary>ColumnHeader</summary>
    ColumnHeader,
    /// <summary>RowHeader</summary>
    RowHeader,
    /// <summary>TopLeftHeader</summary>
    TopLeftHeader,
    /// <summary>HorizontalScrollBar</summary>
    HorizontalScrollBar,
    /// <summary>VerticalScrollBar</summary>
    VerticalScrollBar,
  }
}
