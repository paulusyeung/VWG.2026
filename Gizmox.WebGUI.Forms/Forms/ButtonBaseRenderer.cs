// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ButtonBaseRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class ButtonBaseRenderer : ControlRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ButtonBaseRenderer" /> class.
    /// </summary>
    /// <param name="objButtonBase">The obj ButtonBase.</param>
    internal ButtonBaseRenderer(ButtonBase objButtonBase)
      : base((Control) objButtonBase)
    {
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
    {
      if (!(this.Control is ButtonBase control))
        return;
      this.RenderButtonContent(objContext, objGraphics, control, ControlRenderer.GetContentRegion((Control) control));
    }

    /// <summary>Renders the content of the button.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objButtonBase">The button base.</param>
    /// <param name="objRegion">The region.</param>
    protected virtual void RenderButtonContent(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ButtonBase objButtonBase,
      Rectangle objRegion)
    {
      switch (objButtonBase.TextImageRelation)
      {
        case TextImageRelation.Overlay:
          ControlRenderer.RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, objButtonBase.ImageAlign);
          break;
        case TextImageRelation.ImageAboveText:
          objRegion = ControlRenderer.DockInRegion(objRegion, DockStyle.Top, ControlRenderer.RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, ControlRenderer.GetHorizontalAlignment(objButtonBase.ImageAlign, true)));
          break;
        case TextImageRelation.TextAboveImage:
          objRegion = ControlRenderer.DockInRegion(objRegion, DockStyle.Bottom, ControlRenderer.RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, ControlRenderer.GetHorizontalAlignment(objButtonBase.ImageAlign, false)));
          break;
        case TextImageRelation.ImageBeforeText:
          objRegion = ControlRenderer.DockInRegion(objRegion, DockStyle.Left, ControlRenderer.RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, ControlRenderer.GetVerticalAlignment(objButtonBase.ImageAlign, true)));
          break;
        case TextImageRelation.TextBeforeImage:
          objRegion = ControlRenderer.DockInRegion(objRegion, DockStyle.Right, ControlRenderer.RenderImage(objContext, objGraphics, objButtonBase.Image, objRegion, ControlRenderer.GetVerticalAlignment(objButtonBase.ImageAlign, false)));
          break;
      }
      ControlRenderer.RenderText(objContext, objGraphics, objButtonBase.Text, objButtonBase.Font, objButtonBase.ForeColor, objRegion, objButtonBase.TextAlign, true);
    }
  }
}
