// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IButtonControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for IButton.</summary>
  public interface IButtonControl
  {
    /// <summary>
    /// <para>Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.</para>
    /// </summary>
    /// <param name="value">
    /// <see langword="true" /> if the control should behave as a default button; otherwise <see langword="false" />.</param>
    void NotifyDefault(bool blnValue);

    /// <summary>
    /// <para>Generates a <see cref="E:System.Windows.Forms.Control.Click" /> event for the control.</para>
    /// </summary>
    void PerformClick();

    /// <summary>
    /// <para> Gets or sets the value returned to the parent form when the
    /// button is clicked.</para>
    /// </summary>
    DialogResult DialogResult { get; set; }
  }
}
