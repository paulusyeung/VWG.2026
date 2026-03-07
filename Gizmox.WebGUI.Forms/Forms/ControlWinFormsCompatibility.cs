// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ControlWinFormsCompatibility
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
  public class ControlWinFormsCompatibility : WinFormsCompatibility
  {
    /// <summary>
    /// Gets or sets a value indicating if control resizing should raise Resize events for contained controls like in WinForms.
    /// </summary>
    /// <value>
    /// <c>True</c> if control resizing should raise Resize events for contained controls like in WinForms; otherwise, <c>False</c>; <c>Default</c> if a value should be inherited from Config settings.
    /// </value>
    [DefaultValue(WinFormsCompatibilityStates.Default)]
    public WinFormsCompatibilityStates RecursiveResizeEvent
    {
      get => this.GetFeature(nameof (RecursiveResizeEvent));
      set => this.SetFeature(nameof (RecursiveResizeEvent), value);
    }

    /// <summary>
    /// Gets a value indicating if control resizing should raise Resize events for contained controls like in WinForms.
    /// </summary>
    /// <value>
    /// <c>true</c> if control resizing should raise Resize events for contained controls like in WinForms; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public bool IsRecursiveResizeEvent => this.GetFeatureBoolValue("RecursiveResizeEvent");

    /// <summary>
    /// Should forbid margin styles on items in Dock container or use Winforms style with no margin
    /// </summary>
    [DefaultValue(WinFormsCompatibilityStates.Default)]
    [SRDescription("Don't Include margins when docking controls within a container")]
    public WinFormsCompatibilityStates ForbidDockMargin
    {
      get => this.GetFeature(nameof (ForbidDockMargin));
      set => this.SetFeature(nameof (ForbidDockMargin), value);
    }

    /// <summary>
    /// Should forbid margin styles on items in Dock container or use Winforms style with no margin
    /// </summary>
    [Browsable(false)]
    public bool IsForbidDockMargin => this.GetFeatureBoolValue("ForbidDockMargin");
  }
}
