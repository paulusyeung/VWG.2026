// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs
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
  public class ToolStripArrowRenderEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> class. </summary>
    /// <param name="arrowRectangle">The bounding area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param>
    /// <param name="g">The graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param>
    /// <param name="arrowDirection">The direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow points.</param>
    /// <param name="toolStripItem">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to paint the arrow.</param>
    /// <param name="arrowColor">The color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param>
    public ToolStripArrowRenderEventArgs(
      Graphics g,
      ToolStripItem toolStripItem,
      Rectangle arrowRectangle,
      Color arrowColor,
      ArrowDirection arrowDirection)
    {
    }

    /// <summary>Gets or sets the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color of the arrow.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color ArrowColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the bounding area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding area.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ArrowRectangle
    {
      get => Rectangle.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow points.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ArrowDirection Direction
    {
      get => ArrowDirection.Left;
      set
      {
      }
    }

    /// <summary>Gets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary>
    /// <returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint. </returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Graphics Graphics => (Graphics) null;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to paint the arrow.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripItem Item => (ToolStripItem) null;
  }
}
