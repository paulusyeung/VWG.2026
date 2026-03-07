// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewContentAlignment
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Defines constants that indicate the alignment of content within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public enum DataGridViewContentAlignment
  {
    /// <summary>The alignment is not set.</summary>
    /// <filterpriority>1</filterpriority>
    NotSet = 0,
    /// <summary>The content is aligned vertically at the top and horizontally at the left of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    TopLeft = 1,
    /// <summary>The content is aligned vertically at the top and horizontally at the center of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    TopCenter = 2,
    /// <summary>The content is aligned vertically at the top and horizontally at the right of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    TopRight = 4,
    /// <summary>The content is aligned vertically at the middle and horizontally at the left of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    MiddleLeft = 16, // 0x00000010
    /// <summary>The content is aligned at the vertical and horizontal center of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    MiddleCenter = 32, // 0x00000020
    /// <summary>The content is aligned vertically at the middle and horizontally at the right of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    MiddleRight = 64, // 0x00000040
    /// <summary>The content is aligned vertically at the bottom and horizontally at the left of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    BottomLeft = 256, // 0x00000100
    /// <summary>The content is aligned vertically at the bottom and horizontally at the center of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    BottomCenter = 512, // 0x00000200
    /// <summary>The content is aligned vertically at the bottom and horizontally at the right of a cell.</summary>
    /// <filterpriority>1</filterpriority>
    BottomRight = 1024, // 0x00000400
  }
}
