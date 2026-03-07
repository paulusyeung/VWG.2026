// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ScrollEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  [ComVisible(true)]
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public class ScrollEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see> and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see> properties.</summary>
    /// <param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param>
    /// <param name="newValue">The new value for the scroll bar. </param>
    public ScrollEventArgs(ScrollEventType type, int newValue)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.ScrollOrientation"></see> properties.</summary>
    /// <param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param>
    /// <param name="newValue">The new value for the scroll bar. </param>
    /// <param name="scroll">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollOrientation"></see> values. </param>
    public ScrollEventArgs(ScrollEventType type, int newValue, ScrollOrientation scroll)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.OldValue"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see> properties.</summary>
    /// <param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param>
    /// <param name="oldValue">The old value for the scroll bar. </param>
    /// <param name="newValue">The new value for the scroll bar. </param>
    public ScrollEventArgs(ScrollEventType type, int oldValue, int newValue)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.OldValue"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.ScrollOrientation"></see> properties.</summary>
    /// <param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param>
    /// <param name="oldValue">The old value for the scroll bar. </param>
    /// <param name="newValue">The new value for the scroll bar. </param>
    /// <param name="scroll">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollOrientation"></see> values. </param>
    public ScrollEventArgs(
      ScrollEventType type,
      int oldValue,
      int newValue,
      ScrollOrientation scroll)
    {
    }

    /// <summary>Gets or sets the new <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> of the scroll bar.</summary>
    /// <returns>The numeric value that the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> property will be changed to.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NewValue
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets the old <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> of the scroll bar.</summary>
    /// <returns>The numeric value that the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> property contained before it changed.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int OldValue => 0;

    /// <summary>Gets the scroll bar orientation that raised the Scroll event.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollOrientation"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ScrollOrientation ScrollOrientation => ScrollOrientation.VerticalScroll;

    /// <summary>Gets the type of scroll event that occurred.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ScrollEventType Type => ScrollEventType.EndScroll;
  }
}
