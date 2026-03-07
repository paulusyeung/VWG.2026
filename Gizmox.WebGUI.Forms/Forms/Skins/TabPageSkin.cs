// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TabPageSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>TabPage Skin</summary>
  [SkinContainer(typeof (TabControlSkin))]
  [ToolboxBitmap(typeof (TabPage), "TabPage.bmp")]
  [Serializable]
  public class TabPageSkin : ControlSkin
  {
    /// <summary>
    /// Gets or sets the font of the header text displayed by the control.
    /// </summary>
    /// <value></value>
    /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
    [Category("Fonts")]
    [Description("The font used to display header text in the control.")]
    public Font HeaderFont
    {
      get => this.GetAmbientValue<Font>(nameof (HeaderFont), new Font("Tahoma", 8.25f));
      set => this.SetValue(nameof (HeaderFont), (object) value);
    }

    /// <summary>Gets or sets the header fore color.</summary>
    /// <value></value>
    /// <remarks>HeaderForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
    [Category("Colors")]
    [Description("The foreground color of this component, which is used to display header text.")]
    public Color HeaderForeColor
    {
      get => this.GetAmbientValue<Color>(nameof (HeaderForeColor), Color.Black);
      set => this.SetValue(nameof (HeaderForeColor), (object) value);
    }

    private void InitializeComponent()
    {
    }
  }
}
