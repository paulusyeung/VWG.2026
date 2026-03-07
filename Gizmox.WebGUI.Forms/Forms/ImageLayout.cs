// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ImageLayout
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the position of the image on the control.</summary>
  /// <filterpriority>2</filterpriority>
  public enum ImageLayout : byte
  {
    /// <summary>
    /// The image is left-aligned at the top across the control's client rectangle.
    /// </summary>
    None,
    /// <summary>
    /// The image is tiled across the control's client rectangle.
    /// </summary>
    Tile,
    /// <summary>
    /// The image is centered within the control's client rectangle
    /// </summary>
    Center,
    /// <summary>
    /// The image is streched across the control's client rectangle.
    /// </summary>
    Stretch,
    /// <summary>
    /// The image is enlarged within the control's client rectangle.
    /// </summary>
    Zoom,
  }
}
