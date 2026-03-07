// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.LoadingSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>Provides loading customization capabilities</summary>
  [ToolboxBitmap(typeof (ProgressBar))]
  public class LoadingSkin : CommonSkin
  {
    /// <summary>Gets the loading panel style.</summary>
    /// <value>The loading panel style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The loading animation style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue LoadingAnimationStyle => new StyleValue((CommonSkin) this, nameof (LoadingAnimationStyle));

    /// <summary>
    /// Gets or sets the loading message horizontal alignment.
    /// </summary>
    /// <value>The loading message horizontal alignment.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignmentValue MessageHorizontalAlignment
    {
      get => this.GetValue<HorizontalAlignmentValue>(nameof (MessageHorizontalAlignment), new HorizontalAlignmentValue(HorizontalAlignment.Center));
      set => this.SetValue(nameof (MessageHorizontalAlignment), (object) value);
    }

    /// <summary>Gets the loading message style.</summary>
    /// <value>The loading message style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The loading message style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public LoadingMessageStyle LoadingMessageStyle => new LoadingMessageStyle(this.MessageVerticalAlignment, this.MessageHorizontalAlignment, this.MessageStyle);

    /// <summary>Gets the message style.</summary>
    /// <value>The message style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleValue MessageStyle => new StyleValue((CommonSkin) this, nameof (MessageStyle));

    /// <summary>Gets or sets the loading message vertical alignment.</summary>
    /// <value>The loading message vertical alignment.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerticalAlignmentValue MessageVerticalAlignment
    {
      get => this.GetValue<VerticalAlignmentValue>(nameof (MessageVerticalAlignment), new VerticalAlignmentValue(VerticalAlignment.Center));
      set => this.SetValue(nameof (MessageVerticalAlignment), (object) value);
    }

    /// <summary>Gets the web set style function.</summary>
    /// <value>The web set style function.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TextResourceReference LoadingAnimationCSS => new TextResourceReference(typeof (LoadingSkin), "LoadingAnimation.css");

    private void InitializeComponent()
    {
    }
  }
}
