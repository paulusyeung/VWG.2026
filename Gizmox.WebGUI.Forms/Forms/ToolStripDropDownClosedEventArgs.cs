// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownClosedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:System.Windows.Forms.ToolStripDropDown.Closed"></see> event. </summary>
  [Serializable]
  public class ToolStripDropDownClosedEventArgs : EventArgs
  {
    private ToolStripDropDownCloseReason menmCloseReason;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripDropDownClosedEventArgs"></see> class. </summary>
    /// <param name="reason">One of the <see cref="T:System.Windows.Forms.ToolStripDropDownCloseReason"></see> values.</param>
    public ToolStripDropDownClosedEventArgs(ToolStripDropDownCloseReason reason) => this.menmCloseReason = reason;

    /// <summary>Gets the reason that the <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> closed.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripDropDownCloseReason"></see> values.</returns>
    public ToolStripDropDownCloseReason CloseReason => this.menmCloseReason;
  }
}
