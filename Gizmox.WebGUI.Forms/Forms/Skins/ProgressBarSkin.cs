// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ProgressBarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ProgressBar Skin</summary>
  [ToolboxBitmap(typeof (ProgressBar), "ProgressBar.bmp")]
  [Serializable]
  public class ProgressBarSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the control disabled style.</summary>
    /// <value>The control disabled style.</value>
    public virtual StyleValue ProgressBarNormalStyle => new StyleValue((CommonSkin) this, nameof (ProgressBarNormalStyle));

    /// <summary>Gets or sets the control disabled style.</summary>
    /// <value>The control disabled style.</value>
    public virtual StyleValue ProgressBarBarStyle => new StyleValue((CommonSkin) this, nameof (ProgressBarBarStyle));

    /// <summary>Gets or sets the start width of the progress minimum.</summary>
    /// <value>The start width of the progress minimum.</value>
    public int ProgressMinimumStartWidth
    {
      get => this.GetValue<int>(nameof (ProgressMinimumStartWidth), 0);
      set => this.SetValue(nameof (ProgressMinimumStartWidth), (object) value);
    }

    /// <summary>Gets or sets the progress bar image left.</summary>
    /// <value>The progress bar image left.</value>
    public ImageResourceReference ProgressBarImageLeft
    {
      get => this.GetValue<ImageResourceReference>(nameof (ProgressBarImageLeft), ImageResourceReference.Empty);
      set => this.SetValue(nameof (ProgressBarImageLeft), (object) value);
    }

    /// <summary>Gets the width of the progress bar image left.</summary>
    /// <value>The width of the progress bar image left.</value>
    [Browsable(false)]
    public int ProgressBarImageLeftWidth => this.GetImageWidth(this.ProgressBarImageLeft, 0);

    /// <summary>Gets or sets the progress bar image right.</summary>
    /// <value>The progress bar image right.</value>
    public ImageResourceReference ProgressBarImageRight
    {
      get => this.GetValue<ImageResourceReference>(nameof (ProgressBarImageRight), ImageResourceReference.Empty);
      set => this.SetValue(nameof (ProgressBarImageRight), (object) value);
    }

    /// <summary>Gets the progress bar image left right.</summary>
    /// <value>The progress bar image left right.</value>
    [Browsable(false)]
    public int ProgressBarImageLeftRight => this.GetImageWidth(this.ProgressBarImageRight, 0);
  }
}
