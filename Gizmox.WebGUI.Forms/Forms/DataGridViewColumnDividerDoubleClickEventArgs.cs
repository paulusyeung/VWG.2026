// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerDoubleClick"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
  [Serializable]
  public class DataGridViewColumnDividerDoubleClickEventArgs : HandledMouseEventArgs
  {
    private int mintColumnIndex;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs"></see> class. </summary>
    /// <param name="intColumnIndex">The index of the column next to the column divider that was double-clicked. </param>
    /// <param name="e">A new <see cref="T:Gizmox.WebGUI.Forms.HandledMouseEventArgs"></see> containing the inherited event data. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.</exception>
    public DataGridViewColumnDividerDoubleClickEventArgs(
      int intColumnIndex,
      HandledMouseEventArgs e)
      : base(e.Button, e.Clicks, e.X, e.Y, e.Delta, e.Handled)
    {
      this.mintColumnIndex = intColumnIndex >= -1 ? intColumnIndex : throw new ArgumentOutOfRangeException("columnIndex");
    }

    /// <summary>The index of the column next to the column divider that was double-clicked.</summary>
    /// <returns>The index of the column next to the divider. </returns>
    public int ColumnIndex => this.mintColumnIndex;
  }
}
