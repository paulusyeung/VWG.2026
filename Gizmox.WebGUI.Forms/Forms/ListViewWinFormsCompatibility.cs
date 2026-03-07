// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewWinFormsCompatibility
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ListViewWinFormsCompatibility : ControlWinFormsCompatibility
  {
    /// <summary>
    /// Gets or sets a value indicating if grid lines should be rendered into ListView on empty rows.
    /// </summary>
    /// <value>
    /// <c>True</c> if grid lines should be rendered like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
    /// </value>
    [DefaultValue(WinFormsCompatibilityStates.Default)]
    public WinFormsCompatibilityStates ListViewShowGridLinesOnEmptyRows
    {
      get => this.GetFeature(nameof (ListViewShowGridLinesOnEmptyRows));
      set => this.SetFeature(nameof (ListViewShowGridLinesOnEmptyRows), value);
    }

    /// <summary>
    /// Gets or sets a value indicating if grid lines should be rendered into ListView on empty rows.
    /// </summary>
    /// <value>
    /// <c>true</c>if grid lines should be rendered like in WinForms; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public bool ShowGridLinesOnEmptyRows => this.GetFeatureBoolValue("ListViewShowGridLinesOnEmptyRows");
  }
}
