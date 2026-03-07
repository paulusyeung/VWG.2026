// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemClickedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:System.Windows.Forms.ToolStrip.ItemClicked"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ToolStripItemClickedEventArgs : EventArgs
  {
    private ToolStripItem mobjClickedItem;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs"></see> class, specifying the <see cref="T:System.Windows.Forms.ToolStripItem"></see> that was clicked. </summary>
    /// <param name="clickedItem">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> that was clicked.</param>
    public ToolStripItemClickedEventArgs(ToolStripItem clickedItem) => this.mobjClickedItem = clickedItem;

    /// <summary>Gets the item that was clicked on the <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ToolStripItem"></see> that was clicked.</returns>
    /// <filterpriority>1</filterpriority>
    public ToolStripItem ClickedItem => this.mobjClickedItem;
  }
}
