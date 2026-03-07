// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.TextBoxSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>TextBox Skin</summary>
  [ToolboxBitmap(typeof (TextBox), "TextBox.bmp")]
  [Serializable]
  public class TextBoxSkin : TextBoxBaseSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the single line input style.</summary>
    /// <value>The single line input style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The text box single line input style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SingleLineInputStyle => new StyleValue((CommonSkin) this, nameof (SingleLineInputStyle));

    /// <summary>Gets the multi line input style.</summary>
    /// <value>The multi line input style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The text box multi line input style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue MultiLineInputStyle => new StyleValue((CommonSkin) this, nameof (MultiLineInputStyle));
  }
}
