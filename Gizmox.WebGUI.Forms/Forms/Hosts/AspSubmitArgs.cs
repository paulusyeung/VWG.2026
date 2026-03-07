// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspSubmitArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// 
  /// </summary>
  public class AspSubmitArgs : EventArgs
  {
    private readonly string mstrEventArgument;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspSubmitArgs" /> class.
    /// </summary>
    /// <param name="strEventArgument">The event argument.</param>
    internal AspSubmitArgs(string strEventArgument) => this.mstrEventArgument = strEventArgument;

    /// <summary>Gets the event argument.</summary>
    /// <value>The event argument.</value>
    public string EventArgument => this.mstrEventArgument;
  }
}
