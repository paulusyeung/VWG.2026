// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.LinkLabelSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>LinkLabel Skin</summary>
  [ToolboxBitmap(typeof (LinkLabel), "LinkLabel.bmp")]
  [Serializable]
  public class LinkLabelSkin : LabelSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the color of the link.</summary>
    /// <value>The color of the link.</value>
    [Category("Colors")]
    [Description("The color which is used to display the link text.")]
    public virtual Color LinkColor
    {
      get => this.GetValue<Color>(nameof (LinkColor), this.DefaultLinkColor);
      set => this.SetValue(nameof (LinkColor), (object) value);
    }

    /// <summary>Resets the color of the link.</summary>
    internal void ResetLinkColor() => this.Reset("LinkColor");

    /// <summary>Gets the default color of the link.</summary>
    /// <value>The default color of the link.</value>
    protected virtual Color DefaultLinkColor => Color.Blue;

    /// <summary>Gets or sets the link color disabled.</summary>
    /// <value>The link color disabled.</value>
    [Category("Colors")]
    [Description("The color which is used to display the Disabled link text.")]
    public virtual Color LinkColorDisabled
    {
      get => this.GetValue<Color>(nameof (LinkColorDisabled), this.DefaultLinkColorDisabled);
      set => this.SetValue(nameof (LinkColorDisabled), (object) value);
    }

    /// <summary>Resets the link color disabled.</summary>
    internal void ResetLinkColorDisabled() => this.Reset("LinkColorDisabled");

    /// <summary>Gets the default link color disabled.</summary>
    /// <value>The default link color disabled.</value>
    protected virtual Color DefaultLinkColorDisabled => Color.FromArgb(169, 169, 169);

    /// <summary>Gets the Content style.</summary>
    /// <value>The Content style.</value>
    public virtual StyleValue ContentStyle => new StyleValue((CommonSkin) this, nameof (ContentStyle));

    /// <summary>Gets the focused style.</summary>
    /// <value>The focused style.</value>
    public virtual StyleValue FocusedStyle => new StyleValue((CommonSkin) this, nameof (FocusedStyle));
  }
}
