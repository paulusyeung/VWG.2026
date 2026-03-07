// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AutoCompleteMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the mode for the automatic completion feature used in the
  /// ComboBox and TextBox controls.
  /// </summary>
  public enum AutoCompleteMode
  {
    /// <summary>
    /// Disables the automatic completion feature for the ComboBox and TextBox controls.
    /// </summary>
    None,
    /// <summary>
    /// Displays the auxiliary drop-down list associated with the edit control.
    /// This drop-down is populated with one or more suggested completion strings.
    /// </summary>
    Suggest,
    /// <summary>
    /// Appends the remainder of the most likely candidate string to the existing
    /// characters, highlighting the appended characters.
    /// </summary>
    Append,
    /// <summary>Applies both Suggest and Append options.</summary>
    SuggestAppend,
  }
}
