// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownClosingEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public class ToolStripDropDownClosingEventArgs : CancelEventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownClosingEventArgs"></see> class with the specified reason for closing. </summary>
    /// <param name="reason">One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason"></see> values.</param>
    public ToolStripDropDownClosingEventArgs(ToolStripDropDownCloseReason reason)
    {
    }

    /// <summary>Gets the reason that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is closing.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason"></see> values.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripDropDownCloseReason CloseReason => ToolStripDropDownCloseReason.AppClicked;
  }
}
