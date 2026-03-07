// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Web.UI;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Provides a base class for hosted ASP.NET events</summary>
  [Serializable]
  public class AspPageEventArgs : EventArgs
  {
    /// <summary>The ASP.NET page.</summary>
    private Page mobjAspPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs" /> class.
    /// </summary>
    /// <param name="objAspPage">The ASP.NET page.</param>
    internal AspPageEventArgs(Page objAspPage) => this.mobjAspPage = objAspPage;

    /// <summary>Gets the ASP.NET page that fired this event.</summary>
    /// <value>The ASP.NET page.</value>
    public Page Page => this.mobjAspPage;
  }
}
