// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BackgroundImagePosition
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies position of the image when used as a backgound image
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public enum BackgroundImagePosition : byte
  {
    /// <summary>
    /// Content is vertically aligned at the bottom, and horizontally aligned at the center.
    /// </summary>
    BottomCenter,
    /// <summary>
    /// Content is vertically aligned at the bottom, and horizontally aligned on the left.
    /// </summary>
    BottomLeft,
    /// <summary>
    /// Content is vertically aligned at the bottom, and horizontally aligned on the right.
    /// </summary>
    BottomRight,
    /// <summary>
    /// Content is vertically aligned in the middle, and horizontally aligned at the center.
    /// </summary>
    MiddleCenter,
    /// <summary>
    /// Content is vertically aligned in the middle, and horizontally aligned on the left.
    /// </summary>
    MiddleLeft,
    /// <summary>
    /// Content is vertically aligned in the middle, and horizontally aligned on the right.
    /// </summary>
    MiddleRight,
    /// <summary>
    /// Content is vertically aligned at the top, and horizontally aligned at the center.
    /// </summary>
    TopCenter,
    /// <summary>
    /// Content is vertically aligned at the top, and horizontally aligned on the left.
    /// </summary>
    TopLeft,
    /// <summary>
    /// Content is vertically aligned at the top, and horizontally aligned on the right.
    /// </summary>
    TopRight,
  }
}
