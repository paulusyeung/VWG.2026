// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DragDropEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Contains Drag and drop event arguments.</summary>
  [ComVisible(true)]
  [Serializable]
  public class DragDropEventArgs : DragEventArgs
  {
    private Component mobjSource;
    private Component mobjTarget;
    private Component mobjExplicitTarget;
    private Point mobjRelativePosition;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEventArgs" /> class.
    /// </summary>
    /// <param name="objData">The data associated with this event.</param>
    /// <param name="intKeyState">The current state of the SHIFT, CTRL, and ALT keys.</param>
    /// <param name="intX">The x-coordinate of the mouse cursor in pixels.</param>
    /// <param name="intY">The y-coordinate of the mouse cursor in pixels.</param>
    /// <param name="enmAllowedEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</param>
    /// <param name="enmEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</param>
    public DragDropEventArgs(
      IDataObject objData,
      int intKeyState,
      int intX,
      int intY,
      DragDropEffects enmAllowedEffect,
      DragDropEffects enmEffect)
      : base(objData, intKeyState, intX, intY, enmAllowedEffect, enmEffect)
    {
      if (objData == null)
        return;
      string[] formats = objData.GetFormats();
      if (formats == null || formats.Length == 0)
        return;
      this.mobjSource = objData.GetData(formats[0]) as Component;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEventArgs" /> class.
    /// </summary>
    /// <param name="objSource">The source.</param>
    /// <param name="objSourceMember">The source member.</param>
    /// <param name="objTarget">The target.</param>
    /// <param name="objTargetMember">The target member.</param>
    /// <param name="intKeyState">State of the key.</param>
    /// <param name="intX">The x.</param>
    /// <param name="intY">The y.</param>
    /// <param name="enmAllowedEffect">The allowed effect.</param>
    /// <param name="enmEffect">The effect.</param>
    [Obsolete("Not supported - please use other constructors which exceptes 'ExplicitTarget'.")]
    [Browsable(false)]
    public DragDropEventArgs(
      Component objSource,
      Component objSourceMember,
      Component objTarget,
      Component objTargetMember,
      int intKeyState,
      int intX,
      int intY,
      DragDropEffects enmAllowedEffect,
      DragDropEffects enmEffect)
      : base((IDataObject) new DataObject((object) objSource), intKeyState, intX, intY, enmAllowedEffect, enmEffect)
    {
      this.mobjSource = objSource;
      this.mobjTarget = objTarget;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEventArgs" /> class.
    /// </summary>
    /// <param name="objSource">The obj source.</param>
    /// <param name="objTarget">The obj target.</param>
    /// <param name="intKeyState">State of the int key.</param>
    /// <param name="intX">The int X.</param>
    /// <param name="intY">The int Y.</param>
    /// <param name="enmAllowedEffect">The enm allowed effect.</param>
    /// <param name="enmEffect">The enm effect.</param>
    public DragDropEventArgs(
      Component objSource,
      Component objTarget,
      Component objExplicitTarget,
      int intKeyState,
      int intX,
      int intY,
      int intRelativeX,
      int intRelativeY,
      DragDropEffects enmAllowedEffect,
      DragDropEffects enmEffect)
      : base((IDataObject) new DataObject((object) objSource), intKeyState, intX, intY, enmAllowedEffect, enmEffect)
    {
      this.mobjSource = objSource;
      this.mobjTarget = objTarget;
      this.mobjExplicitTarget = objExplicitTarget;
      this.mobjRelativePosition = new Point(intRelativeX, intRelativeY);
    }

    /// <summary>Gets the position relative to the parent control.</summary>
    public Point RelativePosition => this.mobjRelativePosition;

    /// <summary>Gets the source component.</summary>
    /// <value>The source component.</value>
    public Component Source => this.mobjSource;

    /// <summary>Gets the source component member.</summary>
    /// <value>The source component member.</value>
    [Obsolete("Not supported - please use 'Source' property instead.")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Component SourceMember => (Component) null;

    /// <summary>Gets the target component.</summary>
    /// <value>The target component.</value>
    public Component Target => this.mobjTarget;

    /// <summary>Gets the target component member.</summary>
    /// <value>The target component member.</value>
    [Obsolete("Not supported - please use 'ExplicitTarget' property instead.")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Component TargetMember => (Component) null;

    /// <summary>Gets the explicit target.</summary>
    public Component ExplicitTarget => this.mobjExplicitTarget;
  }
}
