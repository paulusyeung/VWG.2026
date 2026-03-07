// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs
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
  public class ToolStripPanelRenderEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that uses the specified graphics for drawing. </summary>
    /// <param name="g">The graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
    /// <param name="toolStripPanel">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> to draw.</param>
    public ToolStripPanelRenderEventArgs(Graphics g, ToolStripPanel toolStripPanel)
    {
    }

    /// <summary>Gets or sets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint.</returns>
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

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> to paint.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> to paint.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripPanel ToolStripPanel => (ToolStripPanel) null;
  }
}
