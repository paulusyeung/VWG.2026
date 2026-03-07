// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyFireEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class ProxyFireEventArgs : EventArgs
  {
    private bool mblnAllowEvent = true;
    private IEvent mobjEvent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyFireEventArgs" /> class.
    /// </summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="blnAllowEvent">if set to <c>true</c> [BLN allow event].</param>
    public ProxyFireEventArgs(IEvent objEvent, bool blnAllowEvent)
    {
      this.mobjEvent = objEvent;
      this.mblnAllowEvent = blnAllowEvent;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow event].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [allow event]; otherwise, <c>false</c>.
    /// </value>
    public bool AllowEvent
    {
      get => this.mblnAllowEvent;
      set => this.mblnAllowEvent = value;
    }

    /// <summary>Gets or sets the event.</summary>
    /// <value>The event.</value>
    public IEvent Event
    {
      get => this.mobjEvent;
      set => this.mobjEvent = value;
    }
  }
}
