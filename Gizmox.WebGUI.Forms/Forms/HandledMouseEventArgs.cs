// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HandledMouseEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Allows a custom control to prevent the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseWheel"></see> event from being sent to its parent container.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class HandledMouseEventArgs : MouseEventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HandledMouseEventArgs" /> class.
    /// </summary>
    /// <param name="enmButton">The button.</param>
    /// <param name="intClicks">The clicks.</param>
    /// <param name="intX">The x.</param>
    /// <param name="intY">The y.</param>
    /// <param name="intDelta">The delta.</param>
    public HandledMouseEventArgs(
      MouseButtons enmButton,
      int intClicks,
      int intX,
      int intY,
      int intDelta)
      : base(enmButton, intClicks, intX, intY, intDelta)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HandledMouseEventArgs" /> class.
    /// </summary>
    /// <param name="enmButton">The button.</param>
    /// <param name="intClicks">The clicks.</param>
    /// <param name="intX">The x.</param>
    /// <param name="intY">The y.</param>
    /// <param name="intDelta">The delta.</param>
    /// <param name="blnDefaultHandledValue">if set to <c>true</c> [default handled value].</param>
    public HandledMouseEventArgs(
      MouseButtons enmButton,
      int intClicks,
      int intX,
      int intY,
      int intDelta,
      bool blnDefaultHandledValue)
      : base(enmButton, intClicks, intX, intY, intDelta)
    {
    }

    /// <summary>Gets or sets whether this event should be forwarded to the control's parent container.</summary>
    /// <returns>true if the mouse event should go to the parent control; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool Handled
    {
      get => false;
      set
      {
      }
    }
  }
}
