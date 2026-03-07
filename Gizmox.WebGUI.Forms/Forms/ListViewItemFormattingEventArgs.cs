// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListView.ItemFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ListViewItemFormattingEventArgs : EventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly int mintIndex;
    /// <summary>
    /// 
    /// </summary>
    private readonly int mintSubItemIndex;
    /// <summary>
    /// 
    /// </summary>
    private readonly ListViewItem.ListViewSubItem mobjSubItem;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs"></see> class.</summary>
    /// <param name="intItemIndex">The item index of the Item that caused the event.</param>
    /// <param name="intColumnIndex">The column index of the Item that caused the event.</param>
    /// <param name="objSubItem">The sub item.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1-or-rowIndex is less than -1.</exception>
    internal ListViewItemFormattingEventArgs(
      int intItemIndex,
      int intColumnIndex,
      ListViewItem.ListViewSubItem objSubItem)
    {
      this.mintIndex = intItemIndex;
      this.mintSubItemIndex = intColumnIndex;
      this.mobjSubItem = objSubItem;
    }

    /// <summary>Gets the list item index.</summary>
    /// <value>The index.</value>
    public int Index => this.mintIndex;

    /// <summary>Gets the index of the sub item.</summary>
    /// <value>The index of the sub item.</value>
    public int SubItemIndex => this.mintSubItemIndex;

    /// <summary>Gets or sets the value.</summary>
    /// <value>The value.</value>
    public string Value
    {
      get => this.mobjSubItem.Text;
      set => this.mobjSubItem.Text = value;
    }

    /// <summary>
    /// Gets or sets the background color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.
    /// </summary>
    /// <value>The color of the back.</value>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of a item. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    public Color BackColor
    {
      get => this.mobjSubItem.BackColor;
      set => this.mobjSubItem.BackColor = value;
    }

    /// <summary>Gets or sets the font applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.</summary>
    /// <returns>The <see cref="T:System.Drawing.Font"></see> applied to the item text. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    public Font Font
    {
      get => this.mobjSubItem.Font;
      set => this.mobjSubItem.Font = value;
    }

    /// <summary>Gets or sets the foreground color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a item. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public Color ForeColor
    {
      get => this.mobjSubItem.ForeColor;
      set => this.mobjSubItem.ForeColor = value;
    }
  }
}
