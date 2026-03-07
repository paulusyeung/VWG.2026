// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BorderlessButtonVisualTemplate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A borderless button visualtemplate</summary>
  [Skin(typeof (BorderlessButtonVisualTemplateSkin))]
  [VisualTemplate(typeof (Button), "Visually adjusts the Button control to an appearance more suitable for the customized device.")]
  [Serializable]
  public class BorderlessButtonVisualTemplate : VisualTemplate
  {
    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    public override string VisualTemplateName => "ButtonBorderLessVisualTemplate";

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    public override ResourceHandle VisualizerImage => (ResourceHandle) new SkinResourceHandle(typeof (BorderlessButtonVisualTemplateSkin), "BTNBorderLess.png");

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Borderless button";
  }
}
