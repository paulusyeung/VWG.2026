// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GiveFeedbackEventArgs
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
  public class GiveFeedbackEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GiveFeedbackEventArgs"></see> class.</summary>
    /// <param name="effect">The type of drag-and-drop operation. Possible values are obtained by applying the bitwise OR (|) operation to the constants defined in the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see>. </param>
    /// <param name="useDefaultCursors">true if default pointers are used; otherwise, false. </param>
    public GiveFeedbackEventArgs(DragDropEffects effect, bool useDefaultCursors)
    {
    }

    /// <summary>Gets the drag-and-drop operation feedback that is displayed.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DragDropEffects Effect => DragDropEffects.None;

    /// <summary>Gets or sets whether drag operation should use the default cursors that are associated with drag-drop effects.</summary>
    /// <returns>true if the default pointers are used; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseDefaultCursors
    {
      get => false;
      set
      {
      }
    }
  }
}
