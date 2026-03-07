// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyToolStrip
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Proxy ToolStrip</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyToolStrip : ProxyControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyToolStrip" /> class.
    /// </summary>
    public ProxyToolStrip()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyToolStrip" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyToolStrip(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
      : base(objComponent, objParent, blnStateComponent)
    {
      this.AddContainedComponents(objComponent);
      this.RegisterEvents(objComponent);
    }

    /// <summary>
    /// Initializes the emulation - will occur whenever a proxy form is loaded from Xaml in recursion (from emulation form).
    /// </summary>
    internal override void InitializeProxy()
    {
      if (this.ProxyInitialized)
        return;
      Component sourceComponent = this.SourceComponent;
      if (sourceComponent != null)
      {
        this.AddContainedComponents(sourceComponent);
        this.RegisterEvents(sourceComponent);
      }
      this.SetProxyInitialized();
    }

    /// <summary>Registers the events.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void RegisterEvents(Component objComponent)
    {
      if (!(objComponent is ToolStrip toolStrip))
        return;
      toolStrip.ItemAdded += new ToolStripItemEventHandler(this.objToolStrip_ItemAdded);
      toolStrip.ItemRemoved += new ToolStripItemEventHandler(this.objToolStrip_ItemRemoved);
    }

    /// <summary>
    /// Handles the ItemRemoved event of the objToolStrip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemEventArgs" /> instance containing the event data.</param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    private void objToolStrip_ItemRemoved(object sender, ToolStripItemEventArgs e)
    {
      ToolStripItem objComponent = e.Item;
      if (objComponent == null)
        return;
      ProxyComponent childProxyComponent = this.GetChildProxyComponent((Component) objComponent);
      if (childProxyComponent == null)
        return;
      this.UnsubscribeGetEventsWithChildren(childProxyComponent);
      this.Components.Remove(childProxyComponent);
    }

    /// <summary>
    /// Handles the ItemAdded event of the objToolStrip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemEventArgs" /> instance containing the event data.</param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    private void objToolStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
    {
      ToolStripItem objComponent = e.Item;
      if (objComponent == null)
        return;
      ProxyComponent proxyByComponent = this.CreateProxyByComponent((Component) objComponent);
      if (proxyByComponent == null)
        return;
      this.SubscribeGetEventsWithChildren(proxyByComponent);
      this.Components.Add(proxyByComponent);
    }

    /// <summary>Adds the contained components.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void AddContainedComponents(Component objComponent)
    {
      if (!(objComponent is ToolStrip toolStrip))
        return;
      foreach (Component objComponent1 in (ArrangedElementCollection) toolStrip.Items)
      {
        ProxyComponent proxyByComponent = this.CreateProxyByComponent(objComponent1);
        if (proxyByComponent != null)
          this.Components.Add(proxyByComponent);
      }
    }

    /// <summary>Renders the specified obj context.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    public override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
      {
        Component sourceComponent = component.SourceComponent;
        if (sourceComponent != null)
          sourceComponent.ProxyComponent = component;
        if (component is ProxyToolStripControlHost stripControlHost)
          stripControlHost.AttachProxy();
      }
      base.Render(objContext, objWriter, lngRequestID);
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
      {
        Component sourceComponent = component.SourceComponent;
        if (sourceComponent != null)
          sourceComponent.ProxyComponent = (ProxyComponent) null;
        if (component is ProxyToolStripControlHost stripControlHost)
          stripControlHost.DeAttachProxy();
      }
    }

    /// <summary>Gets or sets the components.</summary>
    /// <value>The components.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ProxySet Components => base.Components;
  }
}
