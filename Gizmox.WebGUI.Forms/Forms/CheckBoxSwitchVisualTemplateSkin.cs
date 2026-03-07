// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CheckBoxSwitchVisualTemplateSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class CheckBoxSwitchVisualTemplateSkin : CheckBoxSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the checkbox wrapper style.</summary>
    /// <value>The check box wrapper style.</value>
    public virtual StyleValue CheckBoxWrapperStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (CheckBoxWrapperStyle));
      set => this.SetValue(nameof (CheckBoxWrapperStyle), (object) value);
    }

    /// <summary>Resets the checkbox wrapper style.</summary>
    internal void ResetCheckBoxWrapperStyle() => this.Reset("CheckBoxWrapperStyle");

    /// <summary>Gets or sets the checkbox state label style.</summary>
    /// <value>The check box state label style.</value>
    public virtual StyleValue CheckBoxStateLabelStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (CheckBoxStateLabelStyle));
      set => this.SetValue(nameof (CheckBoxStateLabelStyle), (object) value);
    }

    /// <summary>Resets the checkbox state label style.</summary>
    internal void ResetCheckBoxStateLabelStyle() => this.Reset("CheckBoxStateLabelStyle");

    /// <summary>Gets or sets the checkbox state label before style.</summary>
    /// <value>The checkbox state label before style.</value>
    public virtual StyleValue CheckBoxStateLabelBeforeStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (CheckBoxStateLabelBeforeStyle));
      set => this.SetValue(nameof (CheckBoxStateLabelBeforeStyle), (object) value);
    }

    /// <summary>Resets the checkbox state label before style.</summary>
    internal void ResetCheckBoxStateLabelBeforeStyle() => this.Reset("CheckBoxStateLabelBeforeStyle");

    /// <summary>Gets or sets the checkbox state label after style.</summary>
    /// <value>The checkbox state label after style.</value>
    public virtual StyleValue CheckBoxStateLabelAfterStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (CheckBoxStateLabelAfterStyle));
      set => this.SetValue(nameof (CheckBoxStateLabelAfterStyle), (object) value);
    }

    /// <summary>Resets the checkbox state label after style.</summary>
    internal void ResetCheckBoxStateLabelAfterStyle() => this.Reset("CheckBoxStateLabelAfterStyle");

    /// <summary>Gets or sets the checkbox switch style.</summary>
    /// <value>The checkbox switch style.</value>
    public virtual StyleValue CheckBoxSwitchStyle
    {
      get => new StyleValue((CommonSkin) this, nameof (CheckBoxSwitchStyle));
      set => this.SetValue(nameof (CheckBoxSwitchStyle), (object) value);
    }

    /// <summary>Resets the checkbox switch style.</summary>
    internal void ResetCheckBoxSwitchStyle() => this.Reset("CheckBoxSwitchStyle");

    /// <summary>Gets a value indicating whether [rounded switch].</summary>
    /// <value>
    ///   <c>true</c> if [rounded switch]; otherwise, <c>false</c>.
    /// </value>
    public bool RoundedSwitch
    {
      get => this.GetValue<bool>(nameof (RoundedSwitch), true);
      set => this.SetValue(nameof (RoundedSwitch), (object) value);
    }

    /// <summary>Resets the rounded switch.</summary>
    internal void ResetRoundedSwitch() => this.Reset("RoundedSwitch");

    /// <summary>Gets a value indicating whether [use animation].</summary>
    /// <value>
    ///   <c>true</c> if [use animation]; otherwise, <c>false</c>.
    /// </value>
    public bool UseAnimation
    {
      get => this.GetValue<bool>(nameof (UseAnimation), true);
      set => this.SetValue(nameof (UseAnimation), (object) value);
    }

    /// <summary>Resets the use animation.</summary>
    internal void ResetUseAnimation() => this.Reset("UseAnimation");

    /// <summary>Gets the switch width percentage.</summary>
    /// <value>The switch width percentage.</value>
    public int SwitchWidthPercentage
    {
      get => this.GetValue<int>(nameof (SwitchWidthPercentage), 0);
      set => this.SetValue(nameof (SwitchWidthPercentage), (object) value);
    }

    /// <summary>Resets the switch width percentage.</summary>
    internal void ResetSwitchWidthPercentage() => this.Reset("SwitchWidthPercentage");
  }
}
