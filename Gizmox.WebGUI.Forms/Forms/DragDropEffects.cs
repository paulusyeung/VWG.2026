// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DragDropEffects
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the effects of a drag-and-drop operation.</summary>
  /// <filterpriority>2</filterpriority>
  [Flags]
  public enum DragDropEffects
  {
    /// <summary>The data is copied, removed from the drag source, and scrolled in the drop target.</summary>
    /// <filterpriority>1</filterpriority>
    All = -2147483645, // 0x80000003
    /// <summary>The data is copied to the drop target.</summary>
    /// <filterpriority>1</filterpriority>
    Copy = 1,
    /// <summary>The data from the drag source is linked to the drop target.</summary>
    /// <filterpriority>1</filterpriority>
    Link = 4,
    /// <summary>The data from the drag source is moved to the drop target.</summary>
    /// <filterpriority>1</filterpriority>
    Move = 2,
    /// <summary>The drop target does not accept the data.</summary>
    /// <filterpriority>1</filterpriority>
    None = 0,
    /// <summary>Scrolling is about to start or is currently occurring in the drop target.</summary>
    /// <filterpriority>1</filterpriority>
    Scroll = -2147483648, // 0x80000000
  }
}
