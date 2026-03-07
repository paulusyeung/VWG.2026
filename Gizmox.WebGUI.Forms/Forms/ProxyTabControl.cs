// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyTabControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Proxy TabControl</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ProxyTabControl : ProxyControl, IProxyNavigationControl, INavigationControl
  {
    /// <summary>The object proxy tab pages</summary>
    [NonSerialized]
    private ProxyTabPageCollection objProxyTabPages;
    /// <summary>The count change event handler</summary>
    private EventHandler mobjCountChangeEventHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabControl" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyTabControl(
      Component objComponent,
      ProxyComponent objParent,
      bool blnStateComponent)
      : base(objComponent, objParent, blnStateComponent)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabControl" /> class.
    /// </summary>
    public ProxyTabControl()
    {
    }

    /// <summary>
    /// Raises the <see cref="E:SourceComponentFireEvent" /> event.
    /// </summary>
    /// <param name="objFireEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyFireEventArgs" /> instance containing the event data.</param>
    internal override void OnSourceComponentFireEvent(ProxyFireEventArgs objFireEventArgs)
    {
      base.OnSourceComponentFireEvent(objFireEventArgs);
      if (!(objFireEventArgs.Event.Type == "ValueChange"))
        return;
      objFireEventArgs.AllowEvent = true;
    }

    /// <summary>Gets the proxy component property owner.</summary>
    /// <param name="objPropertyDescriptor"></param>
    /// <returns></returns>
    protected override object GetProxyComponentPropertyOwner(
      PropertyDescriptor objPropertyDescriptor)
    {
      return objPropertyDescriptor != null && objPropertyDescriptor.Name == "TabPages" ? (object) this : base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
    }

    /// <summary>Gets the proxy component properties.</summary>
    /// <param name="arrAttributes">The arr attributes.</param>
    /// <returns></returns>
    protected override PropertyDescriptorCollection GetProxyComponentProperties(
      Attribute[] arrAttributes)
    {
      PropertyDescriptorCollection componentProperties = base.GetProxyComponentProperties(arrAttributes);
      if (!this.IsStateComponent)
      {
        PropertyDescriptor property = TypeDescriptor.GetProperties((object) this, arrAttributes, true)["TabPages"];
        componentProperties.Add(property);
      }
      return componentProperties;
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

    /// <summary>For EMS editing purposes</summary>
    /// <value>The tab pages.</value>
    [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ProxyTabPageCollection TabPages
    {
      get
      {
        if (this.objProxyTabPages == null)
          this.objProxyTabPages = new ProxyTabPageCollection(this);
        return this.objProxyTabPages;
      }
    }

    /// <summary>Happens after the load of the component from XAML.</summary>
    public override void OnLoad()
    {
      base.OnLoad();
      if (this.IsStateComponent)
        return;
      if (!(this.SourceComponent is Gizmox.WebGUI.Forms.TabControl sourceComponent1))
        throw new NullReferenceException(string.Format("this.SourceComponent is null or not a TabControl. Type is {0}", this.SourceComponent == null ? (object) "null" : (object) this.SourceComponent.GetType().Name));
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
      {
        if (component.SourceComponent is TabPage sourceComponent2 && !sourceComponent1.TabPages.Contains((object) sourceComponent2))
          sourceComponent1.TabPages.Add(sourceComponent2);
      }
    }

    /// <summary>Gets the proxy property value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <param name="objDefaultValue">The obj default value.</param>
    /// <returns></returns>
    public override T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
    {
      if (!(strPropertyName == "TabPages"))
        return base.GetProxyPropertyValue<T>(strPropertyName, objDefaultValue);
      List<TabPage> proxyPropertyValue = new List<TabPage>();
      foreach (ProxyComponent tabPage in (IEnumerable) this.TabPages)
      {
        if (tabPage.SourceComponent is TabPage sourceComponent)
          proxyPropertyValue.Add(sourceComponent);
      }
      return (T) proxyPropertyValue;
    }

    private INavigationControl TabControl => this.SourceComponent as INavigationControl;

    ProxyControl IProxyNavigationControl.AddNew()
    {
      ProxyTabPage objTabPage = new ProxyTabPage();
      this.TabPages.Add((object) objTabPage);
      return (ProxyControl) objTabPage;
    }

    void IProxyNavigationControl.RemoveCurrent() => this.TabPages.RemoveAt(this.TabControl.SelectedIndex);

    /// <summary>Occurs when count change.</summary>
    event EventHandler IProxyNavigationControl.CountChange
    {
      add
      {
        this.RegisterCollectionChange(true);
        this.mobjCountChangeEventHandler += value;
      }
      remove
      {
        this.mobjCountChangeEventHandler -= value;
        this.RegisterCollectionChange(false);
      }
    }

    /// <summary>Registers the collection change.</summary>
    /// <param name="blnRegister">if set to <c>true</c> [BLN register].</param>
    private void RegisterCollectionChange(bool blnRegister)
    {
      if (blnRegister)
      {
        if (this.mobjCountChangeEventHandler != null || !(this.SourceComponent is Gizmox.WebGUI.Forms.TabControl sourceComponent))
          return;
        Control.ControlCollection controls = sourceComponent.Controls;
        if (controls == null)
          return;
        controls.ObservableItemAdded += new ObservableListEventHandler(this.Controls_ObservableItemAdded);
        controls.ObservableItemInserted += new ObservableListEventHandler(this.Controls_ObservableItemInserted);
        controls.ObservableItemRemoved += new ObservableListEventHandler(this.Controls_ObservableItemRemoved);
        controls.ObservableListCleared += new EventHandler(this.Controls_ObservableListCleared);
      }
      else
      {
        if (this.mobjCountChangeEventHandler != null || !(this.SourceComponent is Gizmox.WebGUI.Forms.TabControl sourceComponent))
          return;
        Control.ControlCollection controls = sourceComponent.Controls;
        if (controls == null)
          return;
        controls.ObservableItemAdded -= new ObservableListEventHandler(this.Controls_ObservableItemAdded);
        controls.ObservableItemInserted -= new ObservableListEventHandler(this.Controls_ObservableItemInserted);
        controls.ObservableItemRemoved -= new ObservableListEventHandler(this.Controls_ObservableItemRemoved);
        controls.ObservableListCleared -= new EventHandler(this.Controls_ObservableListCleared);
      }
    }

    /// <summary>
    /// Handles the ObservableListCleared event of the Controls control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void Controls_ObservableListCleared(object sender, EventArgs e) => this.OnCountChange(new EventArgs());

    /// <summary>
    /// Handles the ObservableItemRemoved event of the Controls control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void Controls_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs) => this.OnCountChange(new EventArgs());

    /// <summary>
    /// Handles the ObservableItemInserted event of the Controls control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void Controls_ObservableItemInserted(object objSender, ObservableListEventArgs objArgs) => this.OnCountChange(new EventArgs());

    /// <summary>
    /// Handles the ObservableItemAdded event of the Controls control.
    /// </summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Interfaces.ObservableListEventArgs" /> instance containing the event data.</param>
    private void Controls_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs) => this.OnCountChange(new EventArgs());

    /// <summary>
    /// Raises the <see cref="E:CountChange" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnCountChange(EventArgs e)
    {
      if (this.mobjCountChangeEventHandler == null)
        return;
      this.mobjCountChangeEventHandler((object) this, e);
    }

    int INavigationControl.Count => this.TabControl.Count;

    bool INavigationControl.MoveFirst() => this.TabControl.MoveFirst();

    bool INavigationControl.MoveLast() => this.TabControl.MoveLast();

    bool INavigationControl.MoveNext() => this.TabControl.MoveNext();

    bool INavigationControl.MovePrevious() => this.TabControl.MovePrevious();

    void INavigationControl.MoveTo(int intIndex) => this.TabControl.MoveTo(intIndex);

    int INavigationControl.SelectedIndex => this.TabControl.SelectedIndex;
  }
}
