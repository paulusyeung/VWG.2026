// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IContainerControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides the functionality for a control to act as a parent for other controls.</summary>
  /// <filterpriority>2</filterpriority>
  public interface IContainerControl
  {
    /// <summary>Activates a specified control.</summary>
    /// <returns>true if the control is successfully activated; otherwise, false.</returns>
    /// <param name="objActive">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> being activated. </param>
    bool ActivateControl(Control objActive);

    /// <summary>Gets or sets the control that is active on the container control.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that is currently active on the container control.</returns>
    Control ActiveControl { get; set; }
  }
}
