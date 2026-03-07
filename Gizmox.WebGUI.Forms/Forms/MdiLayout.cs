// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MdiLayout
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the layout of multiple document interface (MDI) child windows in an MDI parent window.
  /// </summary>
  public enum MdiLayout
  {
    /// <summary>
    /// All MDI child windows are cascaded within the client region of the MDI parent form.
    /// </summary>
    Cascade,
    /// <summary>
    /// All MDI child windows are tiled horizontally within the client region of the MDI parent form.
    /// </summary>
    TileHorizontal,
    /// <summary>
    /// All MDI child windows are tiled vertically within the client region of the MDI parent form.
    /// </summary>
    TileVertical,
    /// <summary>
    /// All MDI child icons are arranged within the client region of the MDI parent form.
    /// </summary>
    ArrangeIcons,
  }
}
