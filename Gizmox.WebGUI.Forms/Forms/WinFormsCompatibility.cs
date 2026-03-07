// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.WinFormsCompatibility
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class WinFormsCompatibility
  {
    /// <summary>
    /// The store dictionary for WinFormsCompatibility features.
    /// </summary>
    private Dictionary<string, bool> mobjFeatureIsOnIndexByFeatureName;

    /// <summary>Called when option value is changed.</summary>
    public event WinFormsCompatibility.WinFormsCompatibilityEventHandler OptionValueChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WinFormsCompatibility" /> class.
    /// </summary>
    public WinFormsCompatibility() => this.mobjFeatureIsOnIndexByFeatureName = new Dictionary<string, bool>();

    /// <summary>Gets the feature.</summary>
    /// <param name="strFeatureName">Name of the string feature.</param>
    /// <returns></returns>
    protected WinFormsCompatibilityStates GetFeature(string strFeatureName)
    {
      bool flag = false;
      if (!this.mobjFeatureIsOnIndexByFeatureName.TryGetValue(strFeatureName, out flag))
        return WinFormsCompatibilityStates.Default;
      return !flag ? WinFormsCompatibilityStates.False : WinFormsCompatibilityStates.True;
    }

    /// <summary>Gets the feature value from configuration.</summary>
    /// <param name="strFeatureName">Name of the string feature.</param>
    /// <returns></returns>
    private bool GetFeatureValueFromConfiguration(string strFeatureName) => VWGContext.Current != null && VWGContext.Current.Config != null && VWGContext.Current.Config.IsWinFormsCompatibilityOptionOn(strFeatureName);

    /// <summary>Gets the feature bool value.</summary>
    /// <param name="strFeatureName">Name of the string feature.</param>
    /// <returns></returns>
    protected bool GetFeatureBoolValue(string strFeatureName)
    {
      bool featureBoolValue = false;
      if (!this.mobjFeatureIsOnIndexByFeatureName.TryGetValue(strFeatureName, out featureBoolValue))
        featureBoolValue = this.GetFeatureValueFromConfiguration(strFeatureName);
      return featureBoolValue;
    }

    /// <summary>Sets the feature.</summary>
    /// <param name="strFeatureName">Name of the string feature.</param>
    /// <param name="blnState">if set to <c>true</c> [BLN state].</param>
    protected void SetFeature(string strFeatureName, WinFormsCompatibilityStates enmState)
    {
      int num1 = this.GetFeatureBoolValue(strFeatureName) ? 1 : 0;
      if (enmState == WinFormsCompatibilityStates.Default)
        this.mobjFeatureIsOnIndexByFeatureName.Remove(strFeatureName);
      else
        this.mobjFeatureIsOnIndexByFeatureName[strFeatureName] = enmState == WinFormsCompatibilityStates.True;
      int num2 = this.GetFeatureBoolValue(strFeatureName) ? 1 : 0;
      if (num1 == num2)
        return;
      this.OnOptionValueChanged(strFeatureName);
    }

    /// <summary>Called when option value is changed.</summary>
    private void OnOptionValueChanged(string strChangedOptionName)
    {
      if (this.OptionValueChanged == null)
        return;
      this.OptionValueChanged((object) this, new WinFormsCompatibilityEventArgs(strChangedOptionName));
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Empty;

    /// <summary>
    /// Represents the method that will handle the WinFormsCompatibility option changed event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.WinFormsCompatibilityEventArgs" /> instance containing the event data.</param>
    public delegate void WinFormsCompatibilityEventHandler(
      object sender,
      WinFormsCompatibilityEventArgs e);
  }
}
