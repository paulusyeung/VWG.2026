// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AutoValidate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Determines how a control validates its data when it loses user input focus.</summary>
  /// <filterpriority>2</filterpriority>
  public enum AutoValidate
  {
    /// <summary>The control inherits its <see cref="T:System.Windows.Forms.AutoValidate"></see> behavior from its container (such as a form or another control). If there is no container control, it defaults to <see cref="F:System.Windows.Forms.AutoValidate.EnablePreventFocusChange"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    Inherit = -1, // 0xFFFFFFFF
    /// <summary>Implicit validation will not occur. Setting this value will not interfere with explicit calls to <see cref="M:System.Windows.Forms.ContainerControl.Validate"></see> or <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren"></see>.</summary>
    Disable = 0,
    /// <summary>Implicit validation occurs when the control loses focus.</summary>
    EnablePreventFocusChange = 1,
    /// <summary>Implicit validation occurs, but if validation fails, focus will still change to the new control. If validation fails, the <see cref="E:System.Windows.Forms.Control.Validated"></see> event will not fire.</summary>
    EnableAllowFocusChange = 2,
  }
}
