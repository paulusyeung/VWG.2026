// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public class ToolStripSeparatorRenderEventArgs : ToolStripItemRenderEventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> class. </summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> to paint with.</param>
    /// <param name="vertical">A value indicating whether or not the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is to be drawn vertically.</param>
    /// <param name="separator">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> to be painted.</param>
    public ToolStripSeparatorRenderEventArgs(
      Graphics g,
      ToolStripSeparator separator,
      bool vertical)
      : base(g, (ToolStripItem) separator)
    {
    }

    /// <summary>Gets a value indicating whether the display style for the grip is vertical. </summary>
    /// <returns>true if the display style for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is vertical; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Vertical => false;
  }
}
