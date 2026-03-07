// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CheckBoxSwitchVisualTemplate
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
  [VisualTemplate(typeof (CheckBox), "Visually adjusts the CheckBoxSwitch control to an appearance more suitable for the customized device.")]
  [Skin(typeof (CheckBoxSwitchVisualTemplateSkin))]
  [Serializable]
  public class CheckBoxSwitchVisualTemplate : VisualTemplate
  {
    private string mstrUnCheckedText = string.Empty;
    private string mstrCheckedText = string.Empty;
    private bool mblnShowCheckBoxLabel = true;
    private int mintSwitchWidth = 35;
    private CheckBoxSwitchVisualTemplateSwitchSizing menmCheckBoxSwitchVisualTemplateSwitchSizing;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CheckBoxSwitchVisualTemplate" /> class.
    /// </summary>
    public CheckBoxSwitchVisualTemplate()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.CheckBoxSwitchVisualTemplate" /> class.
    /// </summary>
    /// <param name="blnShowCheckBoxLabel">if set to <c>true</c> [BLN show check box label].</param>
    /// <param name="intSwitchWidth">Width of the int switch.</param>
    /// <param name="enmCheckBoxSwitchVisualTemplateSwitchSizing">The enm check box switch visual template switch sizing.</param>
    /// <param name="strUnCheckedText">The STR un checked text.</param>
    /// <param name="strCheckedText">The STR checked text.</param>
    public CheckBoxSwitchVisualTemplate(
      bool blnShowCheckBoxLabel,
      int intSwitchWidth,
      CheckBoxSwitchVisualTemplateSwitchSizing enmCheckBoxSwitchVisualTemplateSwitchSizing,
      string strUnCheckedText,
      string strCheckedText)
    {
      this.mblnShowCheckBoxLabel = blnShowCheckBoxLabel;
      this.mintSwitchWidth = intSwitchWidth;
      this.menmCheckBoxSwitchVisualTemplateSwitchSizing = enmCheckBoxSwitchVisualTemplateSwitchSizing;
      this.mstrUnCheckedText = strUnCheckedText;
      this.mstrCheckedText = strCheckedText;
    }

    /// <summary>Gets or sets the switch sizing.</summary>
    /// <value>The switch sizing.</value>
    public CheckBoxSwitchVisualTemplateSwitchSizing SwitchSizing
    {
      get => this.menmCheckBoxSwitchVisualTemplateSwitchSizing;
      set => this.menmCheckBoxSwitchVisualTemplateSwitchSizing = value;
    }

    /// <summary>Gets or sets the width of the switch.</summary>
    /// <value>The width of the switch.</value>
    [Description("Set switch width when displaying label.")]
    public int SwitchWidth
    {
      get => this.mintSwitchWidth;
      set => this.mintSwitchWidth = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether show the check box label.
    /// </summary>
    /// <value>
    ///   <c>true</c> if show check box label; otherwise, <c>false</c>.
    /// </value>
    public bool ShowCheckBoxLabel
    {
      get => this.mblnShowCheckBoxLabel;
      set => this.mblnShowCheckBoxLabel = value;
    }

    /// <summary>Gets or sets the un checked text.</summary>
    /// <value>The un checked text.</value>
    public string UnCheckedText
    {
      get => this.mstrUnCheckedText;
      set => this.mstrUnCheckedText = value;
    }

    /// <summary>Gets or sets the checked text.</summary>
    /// <value>The checked text.</value>
    public string CheckedText
    {
      get => this.mstrCheckedText;
      set => this.mstrCheckedText = value;
    }

    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    public override string VisualTemplateName => nameof (CheckBoxSwitchVisualTemplate);

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    public override ResourceHandle VisualizerImage => (ResourceHandle) new SkinResourceHandle(typeof (CheckBoxSwitchVisualTemplateSkin), "CheckBoxSwitch.png");

    /// <summary>Gets the constroctor arguments. (For TypeConverter)</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object[] GetConsturctorArguments() => new object[5]
    {
      (object) this.mblnShowCheckBoxLabel,
      (object) this.mintSwitchWidth,
      (object) this.menmCheckBoxSwitchVisualTemplateSwitchSizing,
      (object) this.mstrUnCheckedText,
      (object) this.mstrCheckedText
    };

    /// <summary>Gets the constroctor types. (For TypeConverter)</summary>
    public override Type[] GetConstructorTypes() => new Type[5]
    {
      typeof (bool),
      typeof (int),
      typeof (CheckBoxSwitchVisualTemplateSwitchSizing),
      typeof (string),
      typeof (string)
    };

    /// <summary>Converts to string.</summary>
    /// <returns></returns>
    internal override string ConvertToString() => string.Format("{0}|{1}|{2}|{3}|{4}|{5}", (object) base.ConvertToString(), (object) this.mblnShowCheckBoxLabel, (object) this.mintSwitchWidth, (object) (int) this.menmCheckBoxSwitchVisualTemplateSwitchSizing, (object) this.mstrUnCheckedText, (object) this.mstrCheckedText);

    /// <summary>Converts from string.</summary>
    /// <param name="objVisualTemplateValues">The object visual template values.</param>
    internal override void ConvertFromString(List<string> objVisualTemplateValues)
    {
      bool result1;
      int result2;
      int result3;
      if (objVisualTemplateValues.Count != 5 || !bool.TryParse(objVisualTemplateValues[0], out result1) || !int.TryParse(objVisualTemplateValues[1], out result2) || !int.TryParse(objVisualTemplateValues[2], out result3))
        return;
      this.mblnShowCheckBoxLabel = result1;
      this.mintSwitchWidth = result2;
      if (Enum.IsDefined(typeof (CheckBoxSwitchVisualTemplateSwitchSizing), (object) result3))
        this.menmCheckBoxSwitchVisualTemplateSwitchSizing = (CheckBoxSwitchVisualTemplateSwitchSizing) result3;
      this.mstrUnCheckedText = objVisualTemplateValues[3];
      this.mstrCheckedText = objVisualTemplateValues[4];
    }

    /// <summary>Renders the specified object context.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    public override void Render(IContext objContext, IAttributeWriter objWriter)
    {
      base.Render(objContext, objWriter);
      if (!string.IsNullOrEmpty(this.mstrCheckedText))
        objWriter.WriteAttributeString("VIS_CH_CT", this.mstrCheckedText);
      if (!string.IsNullOrEmpty(this.mstrUnCheckedText))
        objWriter.WriteAttributeString("VIS_CH_UT", this.mstrUnCheckedText);
      objWriter.WriteAttributeString("VIS_CH_SL", this.ShowCheckBoxLabel ? "1" : "0");
      if (!this.ShowCheckBoxLabel)
        return;
      objWriter.WriteAttributeString("VIS_CH_SW", this.mintSwitchWidth);
      objWriter.WriteAttributeString("VIS_CHSS", (int) this.menmCheckBoxSwitchVisualTemplateSwitchSizing);
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "CheckBox Switch Appearance";
  }
}
