// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs
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
  public class ToolStripItemRenderEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> and using the specified <see cref="T:System.Drawing.Graphics"></see>. </summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> object used to draw the item.</param>
    /// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to be drawn.</param>
    public ToolStripItemRenderEventArgs(Graphics g, ToolStripItem item)
    {
    }

    /// <summary>Gets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Graphics Graphics => (Graphics) null;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to paint.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to paint.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripItem Item => (ToolStripItem) null;

    /// <summary>Gets the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Owner"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to paint.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the owner of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStrip ToolStrip => (ToolStrip) null;
  }
}
