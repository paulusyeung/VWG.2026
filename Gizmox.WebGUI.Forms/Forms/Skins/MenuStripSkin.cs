// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.MenuStripSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>MenuStrip Skin</summary>
  public class MenuStripSkin : ToolStripSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the padding with grip.</summary>
    /// <value>The padding with grip.</value>
    [Category("Layout")]
    [Description("Padding value when grip is visible.")]
    public virtual PaddingValue PaddingWithGrip
    {
      get => this.GetValue<PaddingValue>(nameof (PaddingWithGrip), (PaddingValue) new Gizmox.WebGUI.Forms.Padding(3, 2, 0, 2));
      set => this.SetValue(nameof (PaddingWithGrip), (object) value);
    }

    /// <summary>Resets the padding with grip.</summary>
    internal void ResetPaddingWithGrip() => this.Reset("PaddingWithGrip");

    /// <summary>Gets or sets the padding with out grip.</summary>
    /// <value>The padding with out grip.</value>
    [Category("Layout")]
    [Description("Padding value when grip is not visible.")]
    public virtual PaddingValue PaddingWithOutGrip
    {
      get => this.GetValue<PaddingValue>(nameof (PaddingWithOutGrip), (PaddingValue) new Gizmox.WebGUI.Forms.Padding(6, 2, 0, 2));
      set => this.SetValue(nameof (PaddingWithOutGrip), (object) value);
    }

    /// <summary>Resets the padding with out grip.</summary>
    internal void ResetPaddingWithOutGrip() => this.Reset("PaddingWithOutGrip");
  }
}
