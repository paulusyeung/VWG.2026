// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ToolStripSeparatorSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ToolStripSeparator Skin</summary>
  [Serializable]
  public class ToolStripSeparatorSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the width of the vertical seperator.</summary>
    /// <value>The width of the vertical seperator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int VerticalSeperatorWidth => this.GetImageWidth(this.SeperatorVerticalStyle.BackgroundImage);

    /// <summary>Gets the height of the horizontal seperator.</summary>
    /// <value>The height of the horizontal seperator.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int HorizontalSeperatorHeight => this.GetImageWidth(this.SeperatorHorizontalStyle.BackgroundImage);

    /// <summary>Gets the seperator vertical style.</summary>
    /// <value>The seperator style.</value>
    public StyleValue SeperatorVerticalStyle => new StyleValue((CommonSkin) this, nameof (SeperatorVerticalStyle));

    /// <summary>Gets the seperator horizontal style.</summary>
    /// <value>The seperator horizontal style.</value>
    public StyleValue SeperatorHorizontalStyle => new StyleValue((CommonSkin) this, nameof (SeperatorHorizontalStyle));
  }
}
