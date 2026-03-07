// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BorderStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Border style types</summary>
  [Serializable]
  public enum BorderStyle
  {
    /// <summary>No border.</summary>
    None,
    /// <summary>A Single line border.</summary>
    FixedSingle,
    /// <summary>A three-dimensional border.</summary>
    Fixed3D,
    /// <summary>A Clear border.</summary>
    Clear,
    /// <summary>A dashed line border.</summary>
    Dashed,
    /// <summary>A dotted line border.</summary>
    Dotted,
    /// <summary>An inset border for a sunken control appearance.</summary>
    Inset,
    /// <summary>An outset border for a raised control appearance.</summary>
    Outset,
  }
}
