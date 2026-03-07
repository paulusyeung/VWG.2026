// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewRowContextMenuNeededEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
  [Serializable]
  public class DataGridViewRowContextMenuNeededEventArgs : EventArgs
  {
    private ContextMenu mobjContextMenu;
    private int mintRowIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuNeededEventArgs" /> class.
    /// </summary>
    /// <param name="intRowIndex">Index of the row.</param>
    public DataGridViewRowContextMenuNeededEventArgs(int intRowIndex) => this.mintRowIndex = intRowIndex >= -1 ? intRowIndex : throw new ArgumentOutOfRangeException("rowIndex");

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuNeededEventArgs" /> class.
    /// </summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objContextMenu">The context menu.</param>
    internal DataGridViewRowContextMenuNeededEventArgs(int intRowIndex, ContextMenu objContextMenu)
      : this(intRowIndex)
    {
      this.mobjContextMenu = objContextMenu;
    }

    /// <summary>Gets or sets the shortcut menu for the row that raised the <see cref="E:System.Windows.Forms.DataGridView.RowContextMenuStripNeeded"></see> event.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> in use.</returns>
    public ContextMenu ContextMenu
    {
      get => this.mobjContextMenu;
      set => this.mobjContextMenu = value;
    }

    /// <summary>Gets the index of the row that is requesting a shortcut menu.</summary>
    /// <returns>The zero-based index of the row that is requesting a shortcut menu.</returns>
    public int RowIndex => this.mintRowIndex;
  }
}
