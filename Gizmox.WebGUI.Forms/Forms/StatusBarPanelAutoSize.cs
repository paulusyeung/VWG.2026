// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.StatusBarPanelAutoSize
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies how a <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> on a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control behaves when the control resizes.
  /// </summary>
  public enum StatusBarPanelAutoSize
  {
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> does not change size when the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control resizes.
    /// </summary>
    None = 1,
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> shares the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> (the space not taken up by other panels whose <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.None"></see> or <see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.Contents"></see>) with other panels that have their <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property set to <see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.Spring"></see>.
    /// </summary>
    Spring = 2,
    /// <summary>
    /// The width of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> is determined by its contents.
    /// </summary>
    Contents = 3,
  }
}
