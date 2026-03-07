// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ItemDragEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.ListView.ItemDrag"></see> event of the <see cref="T:Gizmox.WebGui.Forms.ListView"></see> and <see cref="T:Gizmox.WebGui.Forms.TreeView"></see> controls.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ItemDragEventArgs : EventArgs
  {
    private readonly MouseButtons menmMouseButtons;
    private readonly object mobjItem;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ItemDragEventArgs" /> class.
    /// </summary>
    /// <param name="button">The button.</param>
    public ItemDragEventArgs(MouseButtons button)
    {
      this.menmMouseButtons = button;
      this.mobjItem = (object) null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ItemDragEventArgs" /> class.
    /// </summary>
    /// <param name="button">The button.</param>
    /// <param name="item">The item.</param>
    public ItemDragEventArgs(MouseButtons button, object item)
    {
      this.menmMouseButtons = button;
      this.mobjItem = item;
    }

    /// <summary>Gets the button.</summary>
    /// <value>The button.</value>
    public MouseButtons Button => this.menmMouseButtons;

    /// <summary>Gets the item.</summary>
    /// <value>The item.</value>
    public object Item => this.mobjItem;
  }
}
