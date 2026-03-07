// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyToolStripControlHost
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Proxy ToolStripControlHost</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyToolStripControlHost : ProxyComponent
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyToolStripControlHost" /> class.
    /// </summary>
    public ProxyToolStripControlHost()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyToolStripControlHost" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyToolStripControlHost(
      Component objComponent,
      ProxyComponent objParent,
      bool blnStateComponent)
      : base(objComponent, objParent, blnStateComponent)
    {
      this.AddContainedComponents(objComponent);
    }

    /// <summary>Adds the contained components.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void AddContainedComponents(Component objComponent)
    {
      if (!(objComponent is ToolStripControlHost stripControlHost))
        return;
      ProxyComponent proxyByComponent = this.CreateProxyByComponent((Component) stripControlHost.Control);
      if (proxyByComponent == null)
        return;
      this.Components.Add(proxyByComponent);
    }

    /// <summary>Attaches the proxy.</summary>
    public void AttachProxy()
    {
      if (this.Components.Count <= 0)
        return;
      ProxyComponent component = this.Components[0];
      Component sourceComponent = component.SourceComponent;
      if (sourceComponent == null)
        return;
      sourceComponent.ProxyComponent = component;
    }

    /// <summary>Des the attach proxy.</summary>
    public void DeAttachProxy()
    {
      if (this.Components.Count <= 0)
        return;
      Component sourceComponent = this.Components[0].SourceComponent;
      if (sourceComponent == null)
        return;
      sourceComponent.ProxyComponent = (ProxyComponent) null;
    }
  }
}
