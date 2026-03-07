// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.StatusStripSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>StatusStrip Skin</summary>
  [SkinDependency(typeof (ToolStripStatusLabelSkin))]
  public class StatusStripSkin : ToolStripSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the vertical orientation padding.</summary>
    /// <value>The vertical orientation padding.</value>
    [SRDescription("Vertial Orientation Padding")]
    [Category("Layout")]
    public virtual PaddingValue VerticalOrientationPadding
    {
      get => this.GetValue<PaddingValue>(nameof (VerticalOrientationPadding), (PaddingValue) new Gizmox.WebGUI.Forms.Padding(1, 3, 1, 3));
      set => this.SetValue(nameof (VerticalOrientationPadding), (object) value);
    }

    /// <summary>Resets the vertical orientation padding.</summary>
    internal void ResetVerticalOrientationPadding() => this.Reset("VerticalOrientationPadding");

    /// <summary>Gets or sets the control padding.</summary>
    /// <value>The control padding.</value>
    [Category("Layout")]
    [Description("Horizontal Orientation Padding.")]
    public PaddingValue HorizontalOrientationPadding
    {
      get => this.GetValue<PaddingValue>(nameof (HorizontalOrientationPadding), (PaddingValue) new Gizmox.WebGUI.Forms.Padding(1, 0, 14, 0));
      set => this.SetValue(nameof (HorizontalOrientationPadding), (object) value);
    }

    /// <summary>Resets the horizontal orientation padding.</summary>
    internal void ResetHorizontalOrientationPadding() => this.Reset("HorizontalOrientationPadding");
  }
}
