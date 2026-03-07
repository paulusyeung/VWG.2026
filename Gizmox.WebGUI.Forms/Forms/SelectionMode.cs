// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SelectionMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the selection behavior of a list box.</summary>
  public enum SelectionMode : byte
  {
    /// <summary>
    ///  Multiple items can be selected, and the user can use the SHIFT, CTRL, and arrow keys to make selections
    /// </summary>
    MultiExtended,
    /// <summary>Multiple items can be selected.</summary>
    MultiSimple,
    /// <summary>No items can be selected.</summary>
    None,
    /// <summary>Only one item can be selected.</summary>
    One,
  }
}
