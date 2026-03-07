// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.UICues
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the state of the user interface.</summary>
  /// <filterpriority>2</filterpriority>
  [Flags]
  public enum UICues
  {
    /// <summary>The state of the focus cues and keyboard cues has changed.</summary>
    /// <filterpriority>1</filterpriority>
    Changed = 12, // 0x0000000C
    /// <summary>The state of the focus cues has changed.</summary>
    /// <filterpriority>1</filterpriority>
    ChangeFocus = 4,
    /// <summary>The state of the keyboard cues has changed.</summary>
    /// <filterpriority>1</filterpriority>
    ChangeKeyboard = 8,
    /// <summary>No change was made.</summary>
    /// <filterpriority>1</filterpriority>
    None = 0,
    /// <summary>Focus rectangles are displayed after the change.</summary>
    /// <filterpriority>1</filterpriority>
    ShowFocus = 1,
    /// <summary>Keyboard cues are underlined after the change.</summary>
    /// <filterpriority>1</filterpriority>
    ShowKeyboard = 2,
    /// <summary>Focus rectangles are displayed and keyboard cues are underlined after the change.</summary>
    /// <filterpriority>1</filterpriority>
    Shown = ShowKeyboard | ShowFocus, // 0x00000003
  }
}
