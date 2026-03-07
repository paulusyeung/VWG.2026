// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabControlRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering a TabControl control</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class TabControlRenderer : ControlRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabControlRenderer" /> class.
    /// </summary>
    /// <param name="objTabControl">The TabControl control.</param>
    public TabControlRenderer(TabControl objTabControl)
      : base((Control) objTabControl)
    {
    }

    /// <summary>Renders the border.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
    {
    }

    /// <summary>Renders the background.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderBackground(
      ControlRenderingContext objContext,
      Graphics objGraphics)
    {
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
    {
      if (!(this.Control is TabControl control))
        return;
      TabPage selectedTab = control.SelectedTab;
      if (selectedTab == null)
        return;
      Bitmap bitmap = selectedTab.DrawControl(objContext, selectedTab.Width, selectedTab.Height);
      if (bitmap == null)
        return;
      objGraphics.DrawImage((Image) bitmap, new Point(0, 0));
    }
  }
}
