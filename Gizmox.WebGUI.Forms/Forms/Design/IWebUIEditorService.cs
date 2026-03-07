// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.IWebUIEditorService
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>Provides an interface for a <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> to display Windows Forms or to display a control in a drop-down area from a property grid control in design mode.</summary>
  public interface IWebUIEditorService
  {
    /// <summary>Closes any previously opened drop down control area.</summary>
    void CloseDropDown();

    /// <summary>
    /// Displays the specified control in a drop down area below a value field of the property grid that provides this service.
    /// </summary>
    /// <param name="objDialog">The dialog.</param>
    void ShowDropDown(Form objDialog);

    /// <summary>
    /// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
    /// </summary>
    /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
    void ShowDialog(Form objDialog);

    /// <summary>
    /// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
    /// </summary>
    /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
    void ShowDialog(CommonDialog objDialog);
  }
}
