// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabAppearance
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the appearance of the tabs in a tab control.
  /// </summary>
  [Serializable]
  public enum TabAppearance
  {
    /// <summary>The tabs have the standard appearance of tabs.</summary>
    Normal = 0,
    /// <summary>
    /// The tabs have the appearance of three-dimensional buttons.
    /// </summary>
    Buttons = 1,
    /// <summary>The tabs have the appearance of flat buttons.</summary>
    FlatButtons = 2,
    /// <summary>The tabs have the appearance of workspace buttons.</summary>
    [Obsolete("Use the WorkspaceTabs class in the forms extension instead")] Workspace = 4,
    /// <summary>The tabs have the appearance of logical buttons.</summary>
    Logical = 8,
    /// <summary>The tabs have the appearance of navigation buttons.</summary>
    Navigation = 16, // 0x00000010
    /// <summary>The tabs have spread appearance.</summary>
    Spread = 32, // 0x00000020
  }
}
