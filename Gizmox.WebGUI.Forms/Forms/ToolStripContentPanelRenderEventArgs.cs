// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs
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
  public class ToolStripContentPanelRenderEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> class. </summary>
    /// <param name="g">A <see cref="T:System.Drawing.Graphics"></see> representing the GDI+ drawing surface.</param>
    /// <param name="contentPanel">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> to render.</param>
    public ToolStripContentPanelRenderEventArgs(Graphics g, ToolStripContentPanel contentPanel)
    {
    }

    /// <summary>Gets the object to use for drawing.</summary>
    /// <returns>The <see cref="T:System.Drawing.Graphics"></see> to use for drawing.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Graphics Graphics => (Graphics) null;

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Handled
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> affected by the click.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripContentPanel ToolStripContentPanel => (ToolStripContentPanel) null;
  }
}
