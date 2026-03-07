// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LinkBehavior
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the behaviors of a link in a <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see>.
  /// </summary>
  [Serializable]
  public enum LinkBehavior
  {
    /// <summary>
    /// The behavior of this setting depends on the options set using the Internet Options dialog box in Control Panel or Internet Explorer.
    /// </summary>
    SystemDefault,
    /// <summary>The link always displays with underlined text.</summary>
    AlwaysUnderline,
    /// <summary>
    /// The link displays underlined text only when the mouse is hovered over the link text.
    /// </summary>
    HoverUnderline,
    /// <summary>
    /// The link text is never underlined. The link can still be distinguished from other text by use of the <see cref="P:Gizmox.WebGUI.Forms.LinkLabel.LinkColor"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.LinkLabel"></see> control.
    /// </summary>
    NeverUnderline,
  }
}
