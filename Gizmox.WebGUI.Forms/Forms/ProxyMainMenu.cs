// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyMainMenu
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Proxy ListView</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyMainMenu : ProxyControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyMainMenu" /> class.
    /// </summary>
    public ProxyMainMenu()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyMainMenu" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyMainMenu(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
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
      if (!(objComponent is MainMenu mainMenu))
        return;
      mainMenu.MenuItems.CollectionChanged += new NotifyCollectionChangedEventHandler(this.objMenuItems_CollectionChanged);
    }

    /// <summary>
    /// Handles the CollectionChanged event of the objMenuItems control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
    private void objMenuItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          if (!(e.NewItems[0] is MenuItem newItem))
            break;
          ProxyComponent proxyByComponent = this.CreateProxyByComponent((Component) newItem);
          if (proxyByComponent == null)
            break;
          this.SubscribeGetEventsWithChildren(proxyByComponent);
          this.Components.Add(proxyByComponent);
          break;
        case NotifyCollectionChangedAction.Remove:
          if (!(e.OldItems[0] is MenuItem oldItem))
            break;
          ProxyComponent childProxyComponent = this.GetChildProxyComponent((Component) oldItem);
          if (childProxyComponent == null)
            break;
          this.UnsubscribeGetEventsWithChildren(childProxyComponent);
          this.Components.Remove(childProxyComponent);
          break;
        case NotifyCollectionChangedAction.Reset:
          GettingPropertyValueEventHandler valueEventHandler = this.GettingPropertyValueEventHandler;
          foreach (ProxyComponent objProxyComponent in this.Components.ToArray())
          {
            if (objProxyComponent.SourceComponent != null)
            {
              this.UnsubscribeGetEventsWithChildren(objProxyComponent);
              this.Components.Remove(objProxyComponent);
            }
          }
          break;
      }
    }

    /// <summary>Adds the contained components.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void AddContainedComponents(Component objComponent)
    {
      if (!(objComponent is MainMenu mainMenu))
        return;
      foreach (Component menuItem in mainMenu.MenuItems)
      {
        ProxyComponent proxyByComponent = this.CreateProxyByComponent(menuItem);
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
      }
      base.Render(objContext, objWriter, lngRequestID);
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
      {
        Component sourceComponent = component.SourceComponent;
        if (sourceComponent != null)
          sourceComponent.ProxyComponent = (ProxyComponent) null;
      }
    }

    /// <summary>Gets or sets the components.</summary>
    /// <value>The components.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ProxySet Components => base.Components;
  }
}
