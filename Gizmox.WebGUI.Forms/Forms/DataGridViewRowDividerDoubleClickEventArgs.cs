// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowDividerDoubleClickEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerDoubleClick"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
  [Serializable]
  public class DataGridViewRowDividerDoubleClickEventArgs : HandledMouseEventArgs
  {
    private int mintRowIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowDividerDoubleClickEventArgs"></see> class. </summary>
    /// <param name="e">A new <see cref="T:Gizmox.WebGUI.Forms.HandledMouseEventArgs"></see> containing the inherited event data.</param>
    /// <param name="intRowIndex">The index of the row above the row divider that was double-clicked.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than -1.</exception>
    public DataGridViewRowDividerDoubleClickEventArgs(int intRowIndex, HandledMouseEventArgs e)
      : base(e.Button, e.Clicks, e.X, e.Y, e.Delta, e.Handled)
    {
      this.mintRowIndex = intRowIndex >= -1 ? intRowIndex : throw new ArgumentOutOfRangeException("rowIndex");
    }

    /// <summary>The index of the row above the row divider that was double-clicked.</summary>
    /// <returns>The index of the row above the divider.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
