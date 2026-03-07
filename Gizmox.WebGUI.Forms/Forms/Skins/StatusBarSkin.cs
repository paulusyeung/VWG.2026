// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.StatusBarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Status Bar Skin</summary>
  [ToolboxBitmap(typeof (StatusBar), "StatusBar.bmp")]
  [Serializable]
  public class StatusBarSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the status bar style.</summary>
    /// <value>The status bar style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The StatusBar style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue StatusBarStyle => new StyleValue((CommonSkin) this, nameof (StatusBarStyle));

    /// <summary>Gets the status bar layout style.</summary>
    /// <value>The status bar layout style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The StatusBar layout style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue StatusBarLayoutStyle => new StyleValue((CommonSkin) this, nameof (StatusBarLayoutStyle));

    /// <summary>Gets the status bar panel style.</summary>
    /// <value>The status bar panel style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The StatusBar layout style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue StatusBarPanelStyle => new StyleValue((CommonSkin) this, nameof (StatusBarPanelStyle));

    /// <summary>Gets the separator image.</summary>
    /// <value>The separator image.</value>
    [Category("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("Separator image")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual ImageResourceReference SeparatorImage
    {
      get => (ImageResourceReference) this.GetValue<string>(nameof (SeparatorImage), (string) new ImageResourceReference(typeof (StatusBarSkin), "StatusBarSep.gif"));
      set => this.SetValue(nameof (SeparatorImage), (object) (string) value);
    }

    /// <summary>Gets the width of the separator image.</summary>
    /// <value>The width of the separator image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SeparatorImageWidth => this.GetImageWidth(this.SeparatorImage, 2);

    /// <summary>Gets or sets background top image.</summary>
    /// <value>Background top image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Background Top Image image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference BackgroundTopImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (BackgroundTopImage), new ImageResourceReference(typeof (StatusBarSkin), "StatusBarTopBG.gif"));
      set => this.SetValue(nameof (BackgroundTopImage), (object) value);
    }

    /// <summary>Resets the background top image.</summary>
    internal void ResetBackgroundTopImage() => this.Reset("BackgroundTopImage");

    /// <summary>Gets or sets background bottom image.</summary>
    /// <value>Background bottom image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Background bottom image")]
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    public virtual ImageResourceReference BackgroundBottomImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (BackgroundBottomImage), new ImageResourceReference(typeof (StatusBarSkin), "StatusBarBottomBG.gif"));
      set => this.SetValue(nameof (BackgroundBottomImage), (object) value);
    }

    /// <summary>Resets the background bottom image.</summary>
    internal void ResetBackgroundBottomImage() => this.Reset("BackgroundBottomImage");
  }
}
