// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ButtonBaseSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ButtonBase Skin</summary>
  [ToolboxBitmap(typeof (Button), "Button.bmp")]
  [Serializable]
  public class ButtonBaseSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the control focused style.</summary>
    /// <value>The control focused style.</value>
    [Category("States")]
    [Description("Gets or sets the control Focused style.")]
    public virtual StyleValue ControlFocusedStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (ControlFocusedStyle));
      set => this.SetValue(nameof (ControlFocusedStyle), (object) value);
    }

    /// <summary>Resets the control focused style.</summary>
    internal void ResetControlFocusedStyle() => this.Reset("ControlFocusedStyle");
  }
}
