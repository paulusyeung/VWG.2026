// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoPushedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoPushed"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
  [Serializable]
  public class DataGridViewRowHeightInfoPushedEventArgs : HandledEventArgs
  {
    private int mintHeight;
    private int mintMinimumHeight;
    private int mintRowIndex;

    internal DataGridViewRowHeightInfoPushedEventArgs(
      int intRowIndex,
      int intHeight,
      int intMinimumHeight)
      : base(false)
    {
      this.mintRowIndex = intRowIndex;
      this.mintHeight = intHeight;
      this.mintMinimumHeight = intMinimumHeight;
    }

    /// <summary>Gets the height of the row the event occurred for.</summary>
    /// <returns>The row height, in pixels.</returns>
    public int Height => this.mintHeight;

    /// <summary>Gets the minimum height of the row the event occurred for.</summary>
    /// <returns>The minimum row height, in pixels.</returns>
    public int MinimumHeight => this.mintMinimumHeight;

    /// <summary>Gets the index of the row the event occurred for.</summary>
    /// <returns>The zero-based index of the row.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
