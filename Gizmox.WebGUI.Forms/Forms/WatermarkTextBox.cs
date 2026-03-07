// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.WatermarkTextBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for WatermarkTextBox</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (WatermarkTextBox), "Extended.WatermarkTextBox_45.png")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (WatermarkTextBoxSkin))]
  [Gizmox.WebGUI.Forms.MetadataTag("WMT")]
  [Serializable]
  public class WatermarkTextBox : TextBox, IRequiresRegistration
  {
    /// <summary>The string property registration.</summary>
    private static readonly SerializableProperty MessageProperty = SerializableProperty.Register("mstrMessage", typeof (string), typeof (WatermarkTextBox));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WatermarkTextBox" /> class.
    /// </summary>
    public WatermarkTextBox() => this.CustomStyle = "Watermark";

    /// <summary>Renders the attributes.</summary>
    /// <param name="context">The context.</param>
    /// <param name="writer">The writer.</param>
    protected override void RenderAttributes(IContext context, IAttributeWriter writer)
    {
      base.RenderAttributes(context, writer);
      writer.WriteAttributeText("MS", this.Message, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Gets or sets the message.</summary>
    /// <value>The message.</value>
    [DefaultValue("Write text here...")]
    public string Message
    {
      get => this.GetValue<string>(WatermarkTextBox.MessageProperty, "Write text here...");
      set
      {
        if (!(this.Message != value))
          return;
        this.SetValue<string>(WatermarkTextBox.MessageProperty, value);
        this.Update();
      }
    }
  }
}
