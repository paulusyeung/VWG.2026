// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NativeDateTimePickerVisualTemplate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [VisualTemplate(typeof (DateTimePicker), "Visually adjusts the DateTimePicker control to appear identical to a native DateTimePicker on the customized device.")]
  [Skin(typeof (NativeDateTimePickerVisualTemplateSkin))]
  [Serializable]
  public class NativeDateTimePickerVisualTemplate : VisualTemplate
  {
    private NativeDateTimePickerVisualTemplateFormat menmNativeDateTimePickerVisualTemplateFormat;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.NativeDateTimePickerVisualTemplate" /> class.
    /// </summary>
    public NativeDateTimePickerVisualTemplate()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.NativeDateTimePickerVisualTemplate" /> class.
    /// </summary>
    /// <param name="enmNativeDateTimePickerVisualTemplateFormat">The enm native date time picker visual template format.</param>
    public NativeDateTimePickerVisualTemplate(
      NativeDateTimePickerVisualTemplateFormat enmNativeDateTimePickerVisualTemplateFormat)
    {
      this.menmNativeDateTimePickerVisualTemplateFormat = enmNativeDateTimePickerVisualTemplateFormat;
    }

    /// <summary>Gets or sets the format.</summary>
    /// <value>The format.</value>
    public NativeDateTimePickerVisualTemplateFormat Format
    {
      get => this.menmNativeDateTimePickerVisualTemplateFormat;
      set => this.menmNativeDateTimePickerVisualTemplateFormat = value;
    }

    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    public override string VisualTemplateName => nameof (NativeDateTimePickerVisualTemplate);

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    public override ResourceHandle VisualizerImage => (ResourceHandle) new SkinResourceHandle(typeof (NativeDateTimePickerVisualTemplateSkin), "NativeDateTimePicker.png");

    /// <summary>Renders the specified object context.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    public override void Render(IContext objContext, IAttributeWriter objWriter)
    {
      base.Render(objContext, objWriter);
      objWriter.WriteAttributeString("VIS_DP_F", this.menmNativeDateTimePickerVisualTemplateFormat.ToString().Replace("_", "-").ToLower());
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Native DateTimePicker";

    /// <summary>Gets the constroctor arguments. (For TypeConverter)</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object[] GetConsturctorArguments() => new object[1]
    {
      (object) this.menmNativeDateTimePickerVisualTemplateFormat
    };

    /// <summary>Gets the constroctor types. (For TypeConverter)</summary>
    public override Type[] GetConstructorTypes() => new Type[1]
    {
      typeof (NativeDateTimePickerVisualTemplateFormat)
    };

    /// <summary>Converts to string.</summary>
    /// <returns></returns>
    internal override string ConvertToString() => string.Format("{0}|{1}", (object) base.ConvertToString(), (object) (int) this.menmNativeDateTimePickerVisualTemplateFormat);

    /// <summary>Converts from string.</summary>
    /// <param name="objVisualTemplateValues">The object visual template values.</param>
    internal override void ConvertFromString(List<string> objVisualTemplateValues)
    {
      int result = 0;
      if (objVisualTemplateValues.Count != 1 || !int.TryParse(objVisualTemplateValues[0], out result) || !Enum.IsDefined(typeof (NativeDateTimePickerVisualTemplateFormat), (object) result))
        return;
      this.menmNativeDateTimePickerVisualTemplateFormat = (NativeDateTimePickerVisualTemplateFormat) result;
    }
  }
}
