// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowContextMenuStripNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Obsolete("DataGridViewRowContextMenuStripNeededEventArgs  is obsilete use DataGridViewRowContextMenuNeededEventArgs instead")]
  [Serializable]
  public class DataGridViewRowContextMenuStripNeededEventArgs : EventArgs
  {
    private int mintRowIndex;
    private ContextMenuStrip mobjContextMenuStrip;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuStripNeededEventArgs"></see> class. </summary>
    /// <param name="intRowIndex">The index of the row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than -1.</exception>
    public DataGridViewRowContextMenuStripNeededEventArgs(int intRowIndex) => this.mintRowIndex = intRowIndex >= -1 ? intRowIndex : throw new ArgumentOutOfRangeException("rowIndex");

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuStripNeededEventArgs" /> class.
    /// </summary>
    /// <param name="rowIndex">Index of the row.</param>
    /// <param name="contextMenuStrip">The context menu strip.</param>
    internal DataGridViewRowContextMenuStripNeededEventArgs(
      int rowIndex,
      ContextMenuStrip contextMenuStrip)
      : this(rowIndex)
    {
      this.mobjContextMenuStrip = contextMenuStrip;
    }

    /// <summary>Gets or sets the context menu strip.</summary>
    /// <value>The context menu strip.</value>
    public ContextMenuStrip ContextMenuStrip
    {
      get => this.mobjContextMenuStrip;
      set => this.mobjContextMenuStrip = value;
    }

    /// <summary>Gets the index of the row that is requesting a shortcut menu.</summary>
    /// <returns>The zero-based index of the row that is requesting a shortcut menu.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
