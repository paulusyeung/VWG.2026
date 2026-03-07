// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LinkState
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Specifies constants that define the state of the link.
  /// </summary>
  [Serializable]
  public enum LinkState
  {
    /// <summary>
    /// The state of a link in its normal state (none of the other states apply).
    /// </summary>
    Normal = 0,
    /// <summary>
    /// The state of a link over which a mouse pointer is resting.
    /// </summary>
    Hover = 1,
    /// <summary>The state of a link that has been clicked.</summary>
    Active = 2,
    /// <summary>The state of a link that has been visited.</summary>
    Visited = 4,
  }
}
