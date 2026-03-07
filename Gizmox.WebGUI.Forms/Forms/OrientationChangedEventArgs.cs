// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.OrientationChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.Form.OrientationChanged"></see> event.</summary>
  public class OrientationChangedEventArgs : EventArgs
  {
    private int? mintOrientation;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.OrientationChangeEventArgs"></see> class.
    /// </summary>
    /// <param name="intOrientation">The int? orientation.</param>
    public OrientationChangedEventArgs(int? intOrientation) => this.mintOrientation = intOrientation;

    /// <summary>
    /// Gets a value that indicates the orientation of the form.
    /// Reutrns a nullable int representin the orientation degrees.
    /// </summary>
    public int? Orientation => this.mintOrientation;
  }
}
