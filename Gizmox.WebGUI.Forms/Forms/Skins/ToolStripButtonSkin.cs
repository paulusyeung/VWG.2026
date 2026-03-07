// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ToolStripButtonSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ToolStripButton Skin</summary>
  [Serializable]
  public class ToolStripButtonSkin : ButtonSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the flat checked button normal style.</summary>
    /// <value>The flat checked button normal style.</value>
    [Category("States")]
    [Description("The flat checked button normal style.")]
    public virtual StyleValue FlatCheckedButtonNormalStyle => new StyleValue((CommonSkin) this, nameof (FlatCheckedButtonNormalStyle));

    /// <summary>Gets the flat checked button hover style.</summary>
    /// <value>The flat checked button hover style.</value>
    [Category("States")]
    [Description("The flat checked button hover style.")]
    public virtual StyleValue FlatCheckedButtonHoverStyle => new StyleValue((CommonSkin) this, nameof (FlatCheckedButtonHoverStyle));

    /// <summary>Gets the flat checked button focused style.</summary>
    /// <value>The flat checked button focused style.</value>
    [Category("States")]
    [Description("The flat checked button focused style.")]
    public virtual StyleValue FlatCheckedButtonFocusedStyle => new StyleValue((CommonSkin) this, nameof (FlatCheckedButtonFocusedStyle));

    /// <summary>Gets the flat checked button pressed style.</summary>
    /// <value>The flat checked button pressed style.</value>
    [Category("States")]
    [Description("The flat checked button pressed style.")]
    public virtual StyleValue FlatCheckedButtonPressedStyle => new StyleValue((CommonSkin) this, nameof (FlatCheckedButtonPressedStyle));
  }
}
