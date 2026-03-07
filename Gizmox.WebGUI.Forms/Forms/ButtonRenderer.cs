// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ButtonRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering a Button control</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class ButtonRenderer : ButtonBaseRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ButtonRenderer" /> class.
    /// </summary>
    /// <param name="objButton">The Button control.</param>
    public ButtonRenderer(Button objButton)
      : base((ButtonBase) objButton)
    {
    }

    /// <summary>Renders the border.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
    {
      if (!(this.Control is Button control) || !(control.Skin is ButtonSkin skin))
        return;
      if (control.Enabled)
        ControlRenderer.RenderFrame(objContext, objGraphics, (Skin) skin, skin.NormalStyle, ControlRenderer.GetContentRegion((Control) control, false, false));
      else
        ControlRenderer.RenderFrame(objContext, objGraphics, (Skin) skin, skin.DisabledStyle, ControlRenderer.GetContentRegion((Control) control, false, false));
    }
  }
}
