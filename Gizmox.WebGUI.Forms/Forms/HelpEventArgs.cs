// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.HelpEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:S Gizmox.WebGUI.Forms.Control.HelpRequested"></see> event.</summary>
  [Serializable]
  public class HelpEventArgs : EventArgs
  {
    private bool mblnHandled;
    private readonly Point mobjMousePosition;

    /// <summary>Initializes a new instance of the <see cref="T:S Gizmox.WebGUI.Forms.HelpEventArgs"></see> class.</summary>
    /// <param name="objMousePosition">The coordinates of the mouse pointer. </param>
    public HelpEventArgs(Point objMousePosition) => this.mobjMousePosition = objMousePosition;

    /// <summary>Gets or sets a value indicating whether the help event was handled.</summary>
    /// <returns>true if the event is handled; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool Handled
    {
      get => this.mblnHandled;
      set => this.mblnHandled = value;
    }

    /// <summary>Gets the screen coordinates of the mouse pointer.</summary>
    /// <returns>A <see cref="T:System.Drawing.Point"></see> representing the screen coordinates of the mouse pointer.</returns>
    /// <filterpriority>1</filterpriority>
    public Point MousePos => this.mobjMousePosition;
  }
}
