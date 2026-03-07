// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FormClosedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.Form.FormClosed"></see> event.</summary>
  /// <filterpriority>2</filterpriority>
  public class FormClosedEventArgs : EventArgs
  {
    private CloseReason mobjCloseReason;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.FormClosedEventArgs"></see> class.</summary>
    /// <param name="objCloseReason">A <see cref="T:Gizmox.WebGui.Forms.CloseReason"></see> value that represents the reason why the form was closed.</param>
    public FormClosedEventArgs(CloseReason objCloseReason) => this.mobjCloseReason = objCloseReason;

    /// <summary>Gets a value that indicates why the form was closed. </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGui.Forms.CloseReason"></see> enumerated values. </returns>
    /// <filterpriority>1</filterpriority>
    public CloseReason CloseReason => this.mobjCloseReason;
  }
}
