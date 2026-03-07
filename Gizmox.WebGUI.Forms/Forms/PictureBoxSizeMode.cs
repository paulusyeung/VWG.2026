// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PictureBoxSizeMode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies how an image is positioned within a <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
  /// </summary>
  [Serializable]
  public enum PictureBoxSizeMode
  {
    /// <summary>
    /// The image is placed in the upper-left corner of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>. The image is clipped if it is larger than the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> it is contained in.
    /// </summary>
    Normal,
    /// <summary>
    /// The image within the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> is stretched or shrunk to fit the size of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
    /// </summary>
    StretchImage,
    /// <summary>
    /// The <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> is sized equal to the size of the image that it contains.This mode doesn't work at run time.
    /// </summary>
    AutoSize,
    /// <summary>
    /// The image is displayed in the center if the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> is larger than the image. If the image is larger than the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>, the picture is placed in the center of the <see cref="T:System.Windows.Forms.PictureBox"></see> and the outside edges are clipped.
    /// </summary>
    CenterImage,
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)] Zoom,
  }
}
