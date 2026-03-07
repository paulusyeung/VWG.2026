// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs
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
  public class ToolStripItemImageRenderEventArgs : ToolStripItemRenderEventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> within the specified space and that has the specified properties.</summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to paint the image.</param>
    /// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
    /// <param name="imageRectangle">The bounding area of the image.</param>
    public ToolStripItemImageRenderEventArgs(
      Graphics g,
      ToolStripItem item,
      Rectangle imageRectangle)
      : base(g, item)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that displays an image within the specified space and that has the specified properties. </summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to paint the image.</param>
    /// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to draw the image.</param>
    /// <param name="image">The <see cref="T:System.Drawing.Image"></see> to paint.</param>
    /// <param name="imageRectangle">The bounding area of the image.</param>
    public ToolStripItemImageRenderEventArgs(
      Graphics g,
      ToolStripItem item,
      Image image,
      Rectangle imageRectangle)
      : base(g, item)
    {
    }

    /// <summary>Gets the image painted on the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>The <see cref="T:System.Drawing.Image"></see> painted on the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Image Image => (Image) null;

    /// <summary>Gets the rectangle that represents the bounding area of the image.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding area of the image.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ImageRectangle => Rectangle.Empty;
  }
}
