// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for <see cref="T:System.Windows.Forms.ToolStripItem"></see> events.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class ToolStripItemEventArgs : EventArgs
  {
    private ToolStripItem mobjToolStripItem;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> class, specifying a <see cref="T:System.Windows.Forms.ToolStripItem"></see>. </summary>
    /// <param name="item">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> for which to specify events.</param>
    public ToolStripItemEventArgs(ToolStripItem item) => this.mobjToolStripItem = item;

    /// <summary>Gets a <see cref="T:System.Windows.Forms.ToolStripItem"></see> for which to handle events.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public ToolStripItem Item => this.mobjToolStripItem;
  }
}
