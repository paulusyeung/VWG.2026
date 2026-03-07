// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AutoSizeMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
  /// </summary>
  public enum AutoSizeMode : byte
  {
    /// <summary>
    /// The control grows or shrinks to fit its contents. The control cannot be resized manually.
    /// </summary>
    GrowAndShrink,
    /// <summary>
    ///     The control grows as much as necessary to fit its contents but does not shrink
    ///     smaller than the value of its <see cref="P:Gizmox.WebGUI.Forms.Control.Size">Size</see> property.
    ///     The form can be resized, but cannot be made so small that any of its contained
    ///     controls are hidden.
    /// </summary>
    GrowOnly,
  }
}
