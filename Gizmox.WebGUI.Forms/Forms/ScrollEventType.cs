// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ScrollEventType
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the type of action used to raise the <see cref="E:Gizmox.WebGUI.Forms.ScrollBar.Scroll"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  public enum ScrollEventType
  {
    /// <summary>The scroll box was moved a small distance. The user clicked the left(horizontal) or top(vertical) scroll arrow, or pressed the UP ARROW key.</summary>
    /// <filterpriority>1</filterpriority>
    SmallDecrement,
    /// <summary>The scroll box was moved a small distance. The user clicked the right(horizontal) or bottom(vertical) scroll arrow, or pressed the DOWN ARROW key.</summary>
    /// <filterpriority>1</filterpriority>
    SmallIncrement,
    /// <summary>The scroll box moved a large distance. The user clicked the scroll bar to the left(horizontal) or above(vertical) the scroll box, or pressed the PAGE UP key.</summary>
    /// <filterpriority>1</filterpriority>
    LargeDecrement,
    /// <summary>The scroll box moved a large distance. The user clicked the scroll bar to the right(horizontal) or below(vertical) the scroll box, or pressed the PAGE DOWN key.</summary>
    /// <filterpriority>1</filterpriority>
    LargeIncrement,
    /// <summary>The scroll box was moved.</summary>
    /// <filterpriority>1</filterpriority>
    ThumbPosition,
    /// <summary>The scroll box is currently being moved.</summary>
    /// <filterpriority>1</filterpriority>
    ThumbTrack,
    /// <summary>The scroll box was moved to the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Minimum"></see> position.</summary>
    /// <filterpriority>1</filterpriority>
    First,
    /// <summary>The scroll box was moved to the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Maximum"></see> position.</summary>
    /// <filterpriority>1</filterpriority>
    Last,
    /// <summary>The scroll box has stopped moving.</summary>
    /// <filterpriority>1</filterpriority>
    EndScroll,
  }
}
