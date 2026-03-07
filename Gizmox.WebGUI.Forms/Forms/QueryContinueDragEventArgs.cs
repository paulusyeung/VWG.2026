// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.QueryContinueDragEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ComVisible(true)]
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public class QueryContinueDragEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.QueryContinueDragEventArgs"></see> class.</summary>
    /// <param name="escapePressed">true if the ESC key was pressed; otherwise, false. </param>
    /// <param name="keyState">The current state of the SHIFT, CTRL, and ALT keys. </param>
    /// <param name="action">A <see cref="T:Gizmox.WebGUI.Forms.DragAction"></see> value. </param>
    public QueryContinueDragEventArgs(int keyState, bool escapePressed, DragAction action)
    {
    }

    /// <summary>Gets or sets the status of a drag-and-drop operation.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DragAction"></see> value.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DragAction Action
    {
      get => DragAction.Continue;
      set
      {
      }
    }

    /// <summary>Gets whether the user pressed the ESC key.</summary>
    /// <returns>true if the ESC key was pressed; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool EscapePressed => false;

    /// <summary>Gets the current state of the SHIFT, CTRL, and ALT keys.</summary>
    /// <returns>The current state of the SHIFT, CTRL, and ALT keys.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int KeyState => 0;
  }
}
