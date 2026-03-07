// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyListView
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
  /// <summary>Proxy ListView</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyListView : ProxyControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyListView" /> class. (this constructor will be initialized from Xaml desirialize)
    /// </summary>
    public ProxyListView()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyListView" /> class. (this constructor will be initialized whenever a listview will be dragged to Emulator Form)
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyListView(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
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
      if (!(objComponent is ListView listView))
        return;
      ListView.ListViewItemCollection items = listView.Items;
      items.ObservableItemAdded += new ObservableListEventHandler(this.Items_ObservableItemAdded);
      items.ObservableItemInserted += new ObservableListEventHandler(this.Items_ObservableItemAdded);
      items.ObservableItemRemoved += new ObservableListEventHandler(this.objItems_ObservableItemRemoved);
      items.ObservableListCleared += new EventHandler(this.objItems_ObservableListCleared);
      ListView.ColumnHeaderCollection columns = listView.Columns;
      columns.ObservableItemAdded += new ObservableListEventHandler(this.objColumnHeaderCollection_ObservableItemAdded);
      columns.ObservableItemInserted += new ObservableListEventHandler(this.objColumnHeaderCollection_ObservableItemAdded);
      columns.ObservableItemRemoved += new ObservableListEventHandler(this.objColumnHeaderCollection_ObservableItemRemoved);
      columns.ObservableListCleared += new EventHandler(this.objColumnHeaderCollection_ObservableListCleared);
      listView.Controls.ObservableItemAdded += new ObservableListEventHandler(this.Controls_ObservableItemAdded);
      listView.Controls.ObservableItemInserted += new ObservableListEventHandler(this.Controls_ObservableItemAdded);
      listView.Controls.ObservableItemRemoved += new ObservableListEventHandler(this.Controls_ObservableItemRemoved);
    }

    /// <summary>
    /// Handles the ObservableItemRemoved event of the Controls control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void Controls_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
    {
      if (!(objArgs.Item is Control objComponent))
        return;
      this.RemoveSubComponent((Component) objComponent);
    }

    /// <summary>
    /// Handles the ObservableItemAdded event of the Controls control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void Controls_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
    {
      if (!(objArgs.Item is Control objComponent))
        return;
      this.AddSubComponent((Component) objComponent);
    }

    /// <summary>
    /// Handles the ObservableListCleared event of the objColumnHeaderCollection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objColumnHeaderCollection_ObservableListCleared(object sender, EventArgs e) => this.ClearProxyComponents(typeof (ColumnHeader));

    /// <summary>
    /// Handles the ObservableItemRemoved event of the objColumnHeaderCollection control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void objColumnHeaderCollection_ObservableItemRemoved(
      object objSender,
      ObservableListEventArgs objArgs)
    {
      if (!(objArgs.Item is ColumnHeader objComponent))
        return;
      this.RemoveSubComponent((Component) objComponent);
    }

    /// <summary>
    /// Handles the ObservableItemAdded event of the objColumnHeaderCollection control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void objColumnHeaderCollection_ObservableItemAdded(
      object objSender,
      ObservableListEventArgs objArgs)
    {
      if (!(objArgs.Item is ColumnHeader objComponent))
        return;
      this.AddSubComponent((Component) objComponent);
    }

    /// <summary>
    /// Handles the ObservableListCleared event of the objItems control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objItems_ObservableListCleared(object sender, EventArgs e) => this.ClearProxyComponents(typeof (ListViewItem));

    /// <summary>
    /// Handles the ObservableItemRemoved event of the objItems control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void objItems_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
    {
      if (!(objArgs.Item is ListViewItem objComponent))
        return;
      this.RemoveSubComponent((Component) objComponent);
    }

    /// <summary>
    /// Handles the ObservableItemAdded event of the Items control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void Items_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
    {
      if (!(objArgs.Item is ListViewItem objComponent))
        return;
      this.AddSubComponent((Component) objComponent);
    }

    /// <summary>Clears the proxy components.</summary>
    /// <param name="objType">Type of the obj.</param>
    private void ClearProxyComponents(Type objType)
    {
      GettingPropertyValueEventHandler valueEventHandler = this.GettingPropertyValueEventHandler;
      foreach (ProxyComponent proxyComponent in this.Components.ToArray())
      {
        if (proxyComponent.SourceComponent != null && proxyComponent.SourceComponent.GetType() == objType)
        {
          if (valueEventHandler != null)
            proxyComponent.GettingPropertyValue -= valueEventHandler;
          this.Components.Remove(proxyComponent);
        }
      }
    }

    /// <summary>Adds the sub component.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void AddSubComponent(Component objComponent)
    {
      ProxyComponent proxyByComponent = this.CreateProxyByComponent(objComponent);
      if (proxyByComponent == null)
        return;
      this.SubscribeGetEventsWithChildren(proxyByComponent);
      this.Components.Add(proxyByComponent);
    }

    /// <summary>Removes the sub component.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void RemoveSubComponent(Component objComponent)
    {
      ProxyComponent childProxyComponent = this.GetChildProxyComponent(objComponent);
      if (childProxyComponent == null)
        return;
      this.UnsubscribeGetEventsWithChildren(childProxyComponent);
      this.Components.Remove(childProxyComponent);
    }

    /// <summary>Adds the contained components.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void AddContainedComponents(Component objComponent)
    {
      if (!(objComponent is ListView listView))
        return;
      foreach (Component column in listView.Columns)
      {
        ProxyComponent proxyByComponent = this.CreateProxyByComponent(column);
        if (proxyByComponent != null)
          this.Components.Add(proxyByComponent);
      }
      foreach (Component objComponent1 in listView.Items)
      {
        ProxyComponent proxyByComponent = this.CreateProxyByComponent(objComponent1);
        if (proxyByComponent != null)
          this.Components.Add(proxyByComponent);
      }
      foreach (Component control in (ArrangedElementCollection) listView.Controls)
      {
        ProxyComponent proxyByComponent = this.CreateProxyByComponent(control);
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
