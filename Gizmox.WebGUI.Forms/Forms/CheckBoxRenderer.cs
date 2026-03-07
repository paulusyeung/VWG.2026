// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CheckBoxRenderer
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
  /// <summary>Provides support for rendering CheckBoxes</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class CheckBoxRenderer : ButtonBaseRenderer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CheckBoxRenderer" /> class.
    /// </summary>
    /// <param name="objCheckBox">The checkbox.</param>
    internal CheckBoxRenderer(CheckBox objCheckBox)
      : base((ButtonBase) objCheckBox)
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
      if (this.Control is CheckBox control && control.Skin is CheckBoxSkin skin)
      {
        ResourceHandle objResourceHandle = (ResourceHandle) null;
        switch (control.CheckState)
        {
          case CheckState.Unchecked:
            CheckBoxSkin checkBoxSkin1 = skin;
            objResourceHandle = checkBoxSkin1.GetResourceHandleFromReference((SkinResourceReference) checkBoxSkin1.UnCheckedCheckBoxImage);
            break;
          case CheckState.Checked:
            CheckBoxSkin checkBoxSkin2 = skin;
            objResourceHandle = checkBoxSkin2.GetResourceHandleFromReference((SkinResourceReference) checkBoxSkin2.CheckedCheckBoxImage);
            break;
          case CheckState.Indeterminate:
            CheckBoxSkin checkBoxSkin3 = skin;
            objResourceHandle = checkBoxSkin3.GetResourceHandleFromReference((SkinResourceReference) checkBoxSkin3.IndeterminateCheckBoxImage);
            break;
        }
        objRegion = ControlRenderer.DockInRegion(objRegion, DockStyle.Left, ControlRenderer.RenderImage(objContext, objGraphics, objResourceHandle, objRegion, ContentAlignment.MiddleLeft));
      }
      base.RenderButtonContent(objContext, objGraphics, objButtonBase, objRegion);
    }
  }
}
