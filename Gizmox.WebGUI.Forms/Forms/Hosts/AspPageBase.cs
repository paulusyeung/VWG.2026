// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspPageBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Provides an Base class to Aspx box control</summary>
  [Serializable]
  public class AspPageBase : AspPipeLinePage
  {
    private AspPageBox mobjPageContext;

    internal void SetHost(AspPageBox objPageContext)
    {
      this.mobjPageContext = objPageContext;
      this.VwgControlId = this.mobjPageContext.ID;
    }

    /// <summary>Gets the page context.</summary>
    /// <value>The page context.</value>
    protected AspPageBox PageContext => this.mobjPageContext;
  }
}
