// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.IDropTarget
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  public interface IDropTarget
  {
    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragDrop"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data.</param>
    /// <filterpriority>1</filterpriority>
    void OnDragDrop(DragEventArgs e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragEnter"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data.</param>
    /// <filterpriority>1</filterpriority>
    void OnDragEnter(DragEventArgs e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragLeave"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    /// <filterpriority>1</filterpriority>
    void OnDragLeave(EventArgs e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DragOver"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data.</param>
    /// <filterpriority>1</filterpriority>
    void OnDragOver(DragEventArgs e);
  }
}
