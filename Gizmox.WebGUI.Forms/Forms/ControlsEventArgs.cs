// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ControlsEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Control event arguments</summary>
  [Serializable]
  public class ControlsEventArgs : EventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    private Control[] mobjControl;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ControlsEventArgs" /> instance.
    /// </summary>
    /// <param name="objControl">control.</param>
    public ControlsEventArgs(Control[] objControl) => this.mobjControl = objControl;

    /// <summary>Gets the control.</summary>
    /// <value></value>
    public Control[] Controls => this.mobjControl;
  }
}
