// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ScrollableControlRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering a scrollable control</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class ScrollableControlRenderer : ControlRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControlRenderer" /> class.
    /// </summary>
    /// <param name="objScrollableControl">The scrollable control.</param>
    public ScrollableControlRenderer(ScrollableControl objScrollableControl)
      : base((Control) objScrollableControl)
    {
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics) => this.RenderControls(objContext, objGraphics);
  }
}
