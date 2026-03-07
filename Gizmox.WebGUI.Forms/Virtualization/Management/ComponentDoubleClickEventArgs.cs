// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.ComponentDoubleClickEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;

namespace Gizmox.WebGUI.Virtualization.Management
{
  /// <summary>
  /// 
  /// </summary>
  public class ComponentDoubleClickEventArgs : EventArgs
  {
    /// <summary>The mobj component</summary>
    private IRegisteredComponent mobjComponent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ComponentDoubleClickEventArgs" /> class.
    /// </summary>
    /// <param name="objComponent">The object component.</param>
    public ComponentDoubleClickEventArgs(IRegisteredComponent objComponent) => this.mobjComponent = objComponent;

    /// <summary>Gets the component.</summary>
    /// <value>The component.</value>
    public IRegisteredComponent Component => this.mobjComponent;
  }
}
