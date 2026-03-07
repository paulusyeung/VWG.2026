// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DragEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:System.Windows.Forms.Control.DragDrop"></see>, <see cref="E:System.Windows.Forms.Control.DragEnter"></see>, or <see cref="E:System.Windows.Forms.Control.DragOver"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  [Serializable]
  public class DragEventArgs : EventArgs
  {
    private readonly DragDropEffects menmAllowedEffect;
    private readonly IDataObject mobjData;
    private DragDropEffects menmEffect;
    private readonly int mintKeyState;
    private readonly int mintX;
    private readonly int mintY;

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DragEventArgs"></see> class.</summary>
    /// <param name="intY">The y-coordinate of the mouse cursor in pixels. </param>
    /// <param name="enmAllowedEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
    /// <param name="objData">The data associated with this event. </param>
    /// <param name="intKeyState">The current state of the SHIFT, CTRL, and ALT keys. </param>
    /// <param name="enmEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
    /// <param name="intX">The x-coordinate of the mouse cursor in pixels. </param>
    public DragEventArgs(
      IDataObject objData,
      int intKeyState,
      int intX,
      int intY,
      DragDropEffects enmAllowedEffect,
      DragDropEffects enmEffect)
    {
      this.mobjData = objData;
      this.mintKeyState = intKeyState;
      this.mintX = intX;
      this.mintY = intY;
      this.menmAllowedEffect = enmAllowedEffect;
      this.menmEffect = enmEffect;
    }

    /// <summary>Gets which drag-and-drop operations are allowed by the originator (or source) of the drag event.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    public DragDropEffects AllowedEffect => this.menmAllowedEffect;

    /// <summary>Gets the <see cref="T:System.Windows.Forms.IDataObject"></see> that contains the data associated with this event.</summary>
    /// <returns>The data associated with this event.</returns>
    /// <filterpriority>1</filterpriority>
    public IDataObject Data => this.mobjData;

    /// <summary>Gets or sets the target drop effect in a drag-and-drop operation.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    public DragDropEffects Effect
    {
      get => this.menmEffect;
      set => this.menmEffect = value;
    }

    /// <summary>Gets the current state of the SHIFT, CTRL, and ALT keys, as well as the state of the mouse buttons.</summary>
    /// <returns>The current state of the SHIFT, CTRL, and ALT keys and of the mouse buttons.</returns>
    /// <filterpriority>1</filterpriority>
    public int KeyState => this.mintKeyState;

    /// <summary>Gets the x-coordinate of the mouse pointer, in screen coordinates.</summary>
    /// <returns>The x-coordinate of the mouse pointer in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    public int X => this.mintX;

    /// <summary>Gets the y-coordinate of the mouse pointer, in screen coordinates.</summary>
    /// <returns>The y-coordinate of the mouse pointer in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    public int Y => this.mintY;
  }
}
