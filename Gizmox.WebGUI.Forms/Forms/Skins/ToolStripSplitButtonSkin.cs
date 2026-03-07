// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ToolStripSplitButtonSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ToolStripSplitButton Skin</summary>
  [Serializable]
  public class ToolStripSplitButtonSkin : ButtonSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the drop down image container style.</summary>
    public StyleValue DropDownImageContainerStyle => new StyleValue((CommonSkin) this, nameof (DropDownImageContainerStyle));

    /// <summary>Gets the drop down image container hover style.</summary>
    public StyleValue DropDownImageContainerHoverStyle => new StyleValue((CommonSkin) this, nameof (DropDownImageContainerHoverStyle));

    /// <summary>Gets the drop down image container focus style.</summary>
    public StyleValue DropDownImageContainerFocusStyle => new StyleValue((CommonSkin) this, nameof (DropDownImageContainerFocusStyle));

    /// <summary>Gets the drop down image container down style.</summary>
    public StyleValue DropDownImageContainerDownStyle => new StyleValue((CommonSkin) this, nameof (DropDownImageContainerDownStyle));
  }
}
