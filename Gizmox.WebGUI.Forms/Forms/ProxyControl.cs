// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The proxy control</summary>
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar(typeof (ProxyControlContextualToolbar))]
  [Serializable]
  public class ProxyControl : ProxyComponent
  {
    /// <summary>
    /// 
    /// </summary>
    private UiPropertyValueChangedEventHandler mobjUiPropertyValueChangedEventHandler;
    /// <summary>
    /// 
    /// </summary>
    private UiPropertyValueChangedEventHandler mobjUiPropertyValueChangingEventHandler;
    /// <summary>
    /// 
    /// </summary>
    private List<ProxyAction> mobjProxyActions;
    private string mstrName;

    /// <summary>Occurs when [getting property value].</summary>
    internal event UiPropertyValueChangedEventHandler UiPropertyValueChanged
    {
      add => this.mobjUiPropertyValueChangedEventHandler += value;
      remove => this.mobjUiPropertyValueChangedEventHandler -= value;
    }

    /// <summary>Occurs when [UI property value changing].</summary>
    internal event UiPropertyValueChangedEventHandler UiPropertyValueChanging
    {
      add => this.mobjUiPropertyValueChangingEventHandler += value;
      remove => this.mobjUiPropertyValueChangingEventHandler -= value;
    }

    /// <summary>Occurs when [UI property key down].</summary>
    internal event ClientEventHandler ProxyClientKeyDown
    {
      add => this.AddClientHandler("KeyDown", value);
      remove => this.RemoveClientHandler("KeyDown", value);
    }

    /// <summary>Gets a value indicating whether [can edit cotnrol].</summary>
    /// <value>
    ///   <c>true</c> if [can edit cotnrol]; otherwise, <c>false</c>.
    /// </value>
    public bool CanEditCotnrol
    {
      get
      {
        bool canEditCotnrol = false;
        if (this.SourceComponent is Control sourceComponent)
          canEditCotnrol = sourceComponent.CanEditControl;
        return canEditCotnrol;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyControl" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyControl(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
      : base(objComponent, objParent, blnStateComponent)
    {
      this.AddContainedControls(objComponent);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyControl" /> class.
    /// </summary>
    public ProxyControl()
    {
    }

    /// <summary>Adds the contained controls.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void AddContainedControls(Component objComponent)
    {
      if (!(objComponent is Control control1))
        return;
      foreach (Component control2 in (ArrangedElementCollection) control1.Controls)
      {
        ProxyComponent proxyByComponent = this.CreateProxyByComponent(control2);
        if (proxyByComponent != null)
          this.Components.Add(proxyByComponent);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:UiPropertyValueChanged" /> event.
    /// </summary>
    /// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
    private void OnUiPropertyValueChanged(
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
    {
      if (this.mobjUiPropertyValueChangedEventHandler == null)
        return;
      this.mobjUiPropertyValueChangedEventHandler((object) this, objProxyPropertyValueEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:UiPropertyValueChanging" /> event.
    /// </summary>
    /// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
    private void OnUiPropertyValueChanging(
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
    {
      if (this.mobjUiPropertyValueChangingEventHandler == null)
        return;
      this.mobjUiPropertyValueChangingEventHandler((object) this, objProxyPropertyValueEventArgs);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "Resize":
          double num1 = Convert.ToDouble(objEvent["Width"], (IFormatProvider) CultureInfo.InvariantCulture);
          double num2 = Convert.ToDouble(objEvent["Height"], (IFormatProvider) CultureInfo.InvariantCulture);
          this.SetUiPropertyValue("Size", (object) new Size(Convert.ToInt32(num1), Convert.ToInt32(num2)));
          break;
        case "Move":
          double dblValue1 = -1.0;
          double dblValue2 = -1.0;
          if (CommonUtils.TryParse(objEvent["Left"], out dblValue1) && CommonUtils.TryParse(objEvent["Top"], out dblValue2))
          {
            this.SetUiPropertyValue("Location", (object) new Point(Convert.ToInt32(dblValue1), Convert.ToInt32(dblValue2)));
            break;
          }
          break;
      }
      base.FireEvent(objEvent);
    }

    public override T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
    {
      if (this.HasClientHandler("KeyDown"))
      {
        switch (strPropertyName)
        {
          case "ShouldRenderClientEvents":
            return (T) (ValueType) true;
          case "ClientEvents":
            return (T) ((IClientComponent) this).Events;
        }
      }
      return base.GetProxyPropertyValue<T>(strPropertyName, objDefaultValue);
    }

    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("KeyDown"))
        clientEventsData.Set("KD");
      return clientEventsData;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.HasRightClickSupport())
        criticalEventsData.Set("RC");
      return criticalEventsData;
    }

    /// <summary>
    /// Determines whether element has right click support for the context menu.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if [has right click support]; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool HasRightClickSupport() => true;

    /// <summary>Sets the UI property value.</summary>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <param name="objValue">The obj value.</param>
    internal void SetUiPropertyValue(string strPropertyName, object objValue)
    {
      bool flag = false;
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs = new ProxyPropertyValueEventArgs(strPropertyName, objValue);
      this.OnUiPropertyValueChanging(objProxyPropertyValueEventArgs);
      objValue = objProxyPropertyValueEventArgs.Value;
      if (this.PropertyBag.ContainsKey(strPropertyName))
      {
        if (this.PropertyBag[strPropertyName] != objValue)
        {
          this.PropertyBag[strPropertyName] = objValue;
          flag = true;
        }
      }
      else
      {
        this.PropertyBag.Add(strPropertyName, objValue);
        flag = true;
      }
      if (!flag)
        return;
      this.OnUiPropertyValueChanged(new ProxyPropertyValueEventArgs(strPropertyName, objValue));
    }

    /// <summary>Validates the source component.</summary>
    internal override void ValidateSourceComponent()
    {
      if (this.CachedSourceCompomnent != this.SourceComponent)
        this.Parent?.SourceComponent?.Update();
      else
        base.ValidateSourceComponent();
    }

    /// <summary>Gets the proxy component properties.</summary>
    /// <param name="arrAttributes">The arr attributes.</param>
    /// <returns></returns>
    protected override PropertyDescriptorCollection GetProxyComponentProperties(
      Attribute[] arrAttributes)
    {
      PropertyDescriptorCollection componentProperties = base.GetProxyComponentProperties(arrAttributes);
      foreach (PropertyDescriptor property in TypeDescriptor.GetProperties((object) this, arrAttributes, true))
      {
        if (property.Name == "Actions")
          componentProperties.Add(property);
      }
      return componentProperties;
    }

    /// <summary>Gets the proxy component property owner.</summary>
    /// <param name="objPropertyDescriptor"></param>
    /// <returns></returns>
    protected override object GetProxyComponentPropertyOwner(
      PropertyDescriptor objPropertyDescriptor)
    {
      return objPropertyDescriptor != null && objPropertyDescriptor.Name == "Actions" ? (object) this : base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
    }

    /// <summary>Shoulds the serialize actions.</summary>
    /// <returns></returns>
    private bool ShouldSerializeActions() => this.mobjProxyActions != null && this.mobjProxyActions.Count > 0;

    /// <summary>PreRenders the specified object.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    public override void PreRender(IContext objContext, long lngRequestID)
    {
      if (!(this.SourceComponent is Control sourceComponent))
        return;
      sourceComponent.ProxyComponent = (ProxyComponent) this;
      sourceComponent.PreRenderControl(objContext, lngRequestID);
      sourceComponent.ProxyComponent = (ProxyComponent) null;
    }

    /// <summary>Happenes after the render.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="lngRequestID">The LNG request identifier.</param>
    public override void PostRender(IContext objContext, long lngRequestID)
    {
      if (!(this.SourceComponent is Control sourceComponent))
        return;
      sourceComponent.ProxyComponent = (ProxyComponent) this;
      sourceComponent.PostRenderControl(objContext, lngRequestID);
      sourceComponent.ProxyComponent = (ProxyComponent) null;
    }

    /// <summary>Registers the actions events.</summary>
    internal void RegisterActionsEvents()
    {
      if (this.mobjProxyActions == null || this.mobjProxyActions.Count <= 0 || !(this.SourceComponent is Control sourceComponent))
        return;
      Type type = sourceComponent.GetType();
      object[] customAttributes = type.GetCustomAttributes(typeof (DefaultEventAttribute), true);
      if (customAttributes.Length == 0 || !(customAttributes[0] is DefaultEventAttribute defaultEventAttribute))
        return;
      EventInfo eventInfo = type.GetEvent(defaultEventAttribute.Name);
      if (!(eventInfo != (EventInfo) null))
        return;
      MethodInfo method = this.GetType().GetMethod("ExecuteProxyAction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      if (!(method != (MethodInfo) null))
        return;
      Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, (object) this, method);
      eventInfo.RemoveEventHandler((object) sourceComponent, handler);
      eventInfo.AddEventHandler((object) sourceComponent, handler);
    }

    /// <summary>Executes the proxy action.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected void ExecuteProxyAction(object sender, EventArgs e)
    {
      if (this.mobjProxyActions == null || this.mobjProxyActions.Count <= 0)
        return;
      foreach (ProxyAction mobjProxyAction in this.mobjProxyActions)
        mobjProxyAction.Execute();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override Component GetSourceComponent()
    {
      if (!this.IsStateComponent)
      {
        ProxyComponent parent = this.Parent;
        if (parent != null && !parent.IsStateComponent && parent.SourceComponent is Control sourceComponent)
        {
          int index = parent.Components.IndexOf((ProxyComponent) this);
          if (index >= 0 && index < sourceComponent.Controls.Count)
            return (Component) sourceComponent.Controls[index];
        }
      }
      return base.GetSourceComponent();
    }

    /// <summary>Shows the contextual toolbar.</summary>
    public void ShowContextualToolbar(
      EventHandler objOnEditorWindowOpen,
      EventHandler objOnEditorWindowClosed)
    {
      Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ShowContextualToolbar((Component) this, objOnEditorWindowOpen, objOnEditorWindowClosed);
    }

    /// <summary>Gets or sets the name of the control.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Name
    {
      get => this.SourceComponent is Control sourceComponent ? string.Format("{0} ({1})", (object) sourceComponent.Name, (object) sourceComponent.GetType().Name) : base.Name;
      set => throw new NotImplementedException();
    }

    /// <summary>Gets or sets the actions.</summary>
    /// <value>The actions.</value>
    [WebEditor("Gizmox.WebGUI.Forms.Design.ProxyActionEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof (WebUITypeEditor))]
    [MergableProperty(false)]
    public List<ProxyAction> Actions
    {
      get
      {
        if (this.mobjProxyActions == null)
          this.mobjProxyActions = new List<ProxyAction>();
        return this.mobjProxyActions;
      }
      set => this.mobjProxyActions = value;
    }
  }
}
