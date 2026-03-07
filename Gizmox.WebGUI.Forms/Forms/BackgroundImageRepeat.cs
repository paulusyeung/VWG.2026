// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BackgroundImageRepeat
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies the layout of the image when used as a backgound image
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public enum BackgroundImageRepeat : byte
  {
    /// <summary>
    /// The image is centered within the control's client rectangle
    /// </summary>
    None,
    /// <summary>
    /// The image is tiled across the control's client rectangle.
    /// </summary>
    Repeat,
    /// <summary>
    /// The image will be tiled across the control's horizontaly only
    /// </summary>
    RepeatX,
    /// <summary>
    /// The image will be tiled across the control's verticaly only
    /// </summary>
    RepeatY,
  }
}
