// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspControlEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Provides a base class for hosted ASP.NET events</summary>
  [Serializable]
  public class AspControlEventArgs : EventArgs
  {
    /// <summary>The ASP.NET control.</summary>
    private System.Web.UI.Control mobjAspControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlEventArgs" /> class.
    /// </summary>
    /// <param name="objAspControl">The ASP.NET control.</param>
    internal AspControlEventArgs(System.Web.UI.Control objAspControl) => this.mobjAspControl = objAspControl;

    /// <summary>Gets the ASP.NET control that fired this event.</summary>
    /// <value>The ASP.NET control.</value>
    public System.Web.UI.Control Control => this.mobjAspControl;
  }
}
