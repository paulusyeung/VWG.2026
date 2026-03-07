// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the reason that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed.</summary>
  public enum ToolStripDropDownCloseReason
  {
    /// <summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because another application has received the focus.</summary>
    AppFocusChange,
    /// <summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because an application was launched.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")] AppClicked,
    /// <summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because one of its items was clicked.</summary>
    ItemClicked,
    /// <summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because of keyboard activity, such as the ESC key being pressed.</summary>
    Keyboard,
    /// <summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDown.Close"></see> method was called.</summary>
    CloseCalled,
  }
}
