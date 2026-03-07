// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RadioButtonRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering RadioButtones</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class RadioButtonRenderer : ButtonBaseRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RadioButtonRenderer" /> class.
    /// </summary>
    /// <param name="objRadioButton">The RadioButton.</param>
    internal RadioButtonRenderer(RadioButton objRadioButton)
      : base((ButtonBase) objRadioButton)
    {
    }

    /// <summary>Renders the content of the button.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objButtonBase">The button base.</param>
    /// <param name="objRegion">The region.</param>
    protected override void RenderButtonContent(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ButtonBase objButtonBase,
      Rectangle objRegion)
    {
      if (this.Control is RadioButton control && control.Skin is RadioButtonSkin skin)
      {
        ResourceHandle handleFromReference;
        if (control.Checked)
        {
          RadioButtonSkin radioButtonSkin = skin;
          handleFromReference = radioButtonSkin.GetResourceHandleFromReference((SkinResourceReference) radioButtonSkin.CheckedRadioImage);
        }
        else
        {
          RadioButtonSkin radioButtonSkin = skin;
          handleFromReference = radioButtonSkin.GetResourceHandleFromReference((SkinResourceReference) radioButtonSkin.UnCheckedRadioImage);
        }
        objRegion = ControlRenderer.DockInRegion(objRegion, DockStyle.Left, ControlRenderer.RenderImage(objContext, objGraphics, handleFromReference, objRegion, ContentAlignment.MiddleLeft));
      }
      base.RenderButtonContent(objContext, objGraphics, objButtonBase, objRegion);
    }
  }
}
