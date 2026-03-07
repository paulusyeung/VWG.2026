// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellContextMenuStripNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuNeeded"></see> event. </summary>
  [Serializable]
  public class DataGridViewCellContextMenuStripNeededEventArgs : DataGridViewCellEventArgs
  {
    private ContextMenuStrip mobjContextMenuStrip;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs"></see> class. </summary>
    /// <param name="intColumnIndex">The column index of cell that the event occurred for.</param>
    /// <param name="intRowIndex">The row index of the cell that the event occurred for.</param>
    public DataGridViewCellContextMenuStripNeededEventArgs(int intColumnIndex, int intRowIndex)
      : base(intColumnIndex, intRowIndex)
    {
    }

    internal DataGridViewCellContextMenuStripNeededEventArgs(
      int intColumnIndex,
      int intRowIndex,
      ContextMenuStrip objContextMenuStrip)
      : base(intColumnIndex, intRowIndex)
    {
      this.mobjContextMenuStrip = objContextMenuStrip;
    }

    /// <summary>Gets or sets the shortcut menu for the cell that raised the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded"></see> event.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for the cell. </returns>
    public ContextMenuStrip ContextMenuStrip
    {
      get => this.mobjContextMenuStrip;
      set => this.mobjContextMenuStrip = value;
    }
  }
}
