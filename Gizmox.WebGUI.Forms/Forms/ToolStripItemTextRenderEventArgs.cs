// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs
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
  public class ToolStripItemTextRenderEventArgs : ToolStripItemRenderEventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> class with the specified text and text properties format.</summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to draw the text.</param>
    /// <param name="textRectangle">The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds to draw the text in.</param>
    /// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to draw the text.</param>
    /// <param name="format">The display and layout information for text strings.</param>
    /// <param name="textColor">The <see cref="T:System.Drawing.Color"></see> used to draw the text.</param>
    /// <param name="textFont">The <see cref="T:System.Drawing.Font"></see> used to draw the text.</param>
    /// <param name="text">The text to be drawn.</param>
    public ToolStripItemTextRenderEventArgs(
      Graphics g,
      ToolStripItem item,
      string text,
      Rectangle textRectangle,
      Color textColor,
      Font textFont,
      TextFormatFlags format)
      : base(g, item)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> class with the specified text and text properties. </summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to draw the text.</param>
    /// <param name="textRectangle">The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds to draw the text in.</param>
    /// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to draw the text.</param>
    /// <param name="textAlign">The <see cref="T:System.Drawing.ContentAlignment"></see> that specifies the vertical and horizontal alignment of the text in the bounding area.</param>
    /// <param name="textColor">The <see cref="T:System.Drawing.Color"></see> used to draw the text.</param>
    /// <param name="textFont">The <see cref="T:System.Drawing.Font"></see> used to draw the text.</param>
    /// <param name="text">The text to be drawn.</param>
    public ToolStripItemTextRenderEventArgs(
      Graphics g,
      ToolStripItem item,
      string text,
      Rectangle textRectangle,
      Color textColor,
      Font textFont,
      ContentAlignment textAlign)
      : base(g, item)
    {
    }

    /// <summary>Gets or sets the text to be drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>A string that represents the text to be painted on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Text
    {
      get => (string) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text. </summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color TextColor
    {
      get => Color.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets whether the text is drawn vertically or horizontally.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. </returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripTextDirection TextDirection
    {
      get => ToolStripTextDirection.Inherit;
      set
      {
      }
    }

    /// <summary>Gets or sets the font of the text drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>The <see cref="T:System.Drawing.Font"></see> of the text drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Font TextFont
    {
      get => (Font) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the display and layout information of the text drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.TextFormatFlags"></see> values that specify the display and layout information of the drawn text. </returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextFormatFlags TextFormat
    {
      get => TextFormatFlags.Default;
      set
      {
      }
    }

    /// <summary>Gets or sets the rectangle that represents the bounds to draw the text in.</summary>
    /// <returns>The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds to draw the text in.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle TextRectangle
    {
      get => Rectangle.Empty;
      set
      {
      }
    }
  }
}
