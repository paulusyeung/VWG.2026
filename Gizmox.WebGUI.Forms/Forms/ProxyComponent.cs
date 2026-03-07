// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyComponent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The basic proxy component</summary>
  [Serializable]
  public class ProxyComponent : Component, ICustomTypeDescriptor
  {
    /// <summary>
    /// 
    /// </summary>
    private EventHandler mobjProxyClickEventHandler;
    /// <summary>
    /// 
    /// </summary>
    private GettingPropertyValueEventHandler mobjGettingPropertyValueEventHandler;
    /// <summary>
    /// 
    /// </summary>
    private SourceComponentFireEventHandler mobjSourceComponentFireEventHandler;
    /// <summary>
    /// 
    /// </summary>
    private ProxyComponentChangingEventHandler mobjProxyComponentChangingEventHandler;
    /// <summary>The filter properties event handler</summary>
    private FilterPropertiesEventHandler mobjFilterPropertiesEventHandler;
    /// <summary>
    /// 
    /// </summary>
    private ProxySet mobjComponents = new ProxySet();
    /// <summary>The property bag</summary>
    private ProxyPropertyBag mobjPropertyBag = new ProxyPropertyBag();
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private ProxyComponent mobjParent;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    protected Form mobjParentForm;
    /// <summary>The unique ID</summary>
    private string mstrUniqueID;
    /// <summary>
    /// The cached proxy compomnent (only valid for runtim mode)
    /// </summary>
    private Component mobjCachedSourceCompomnent;
    /// <summary>The MSTR custom component type</summary>
    private string mstrNonStateComponentType;
    private bool mblnProxyInitialized;

    /// <summary>
    /// Unsubscribe to get  events of proxy control with children.
    /// </summary>
    protected void UnsubscribeGetEventsWithChildren(ProxyComponent objProxyComponent)
    {
      GettingPropertyValueEventHandler valueEventHandler = this.GettingPropertyValueEventHandler;
      if (valueEventHandler != null)
        objProxyComponent.GettingPropertyValue -= valueEventHandler;
      FilterPropertiesEventHandler propertiesEventHandler = this.FilterPropertiesEventHandler;
      if (propertiesEventHandler != null)
        objProxyComponent.FilterProperties -= propertiesEventHandler;
      foreach (ProxyComponent component in (List<ProxyComponent>) objProxyComponent.Components)
        this.UnsubscribeGetEventsWithChildren(component);
    }

    /// <summary>
    /// Subscribe to get events of proxy control with children.
    /// </summary>
    protected void SubscribeGetEventsWithChildren(ProxyComponent objProxyComponent)
    {
      GettingPropertyValueEventHandler valueEventHandler = this.GettingPropertyValueEventHandler;
      if (valueEventHandler != null)
        objProxyComponent.GettingPropertyValue += valueEventHandler;
      FilterPropertiesEventHandler propertiesEventHandler = this.FilterPropertiesEventHandler;
      if (propertiesEventHandler != null)
        objProxyComponent.FilterProperties += propertiesEventHandler;
      foreach (ProxyComponent component in (List<ProxyComponent>) objProxyComponent.Components)
        this.SubscribeGetEventsWithChildren(component);
    }

    /// <summary>Occurs when [getting property value].</summary>
    internal event GettingPropertyValueEventHandler GettingPropertyValue
    {
      add => this.mobjGettingPropertyValueEventHandler += value;
      remove => this.mobjGettingPropertyValueEventHandler -= value;
    }

    /// <summary>Occurs when [filter properties].</summary>
    internal event FilterPropertiesEventHandler FilterProperties
    {
      add => this.mobjFilterPropertiesEventHandler += value;
      remove => this.mobjFilterPropertiesEventHandler -= value;
    }

    /// <summary>Occurs when [source component fire event].</summary>
    internal event SourceComponentFireEventHandler SourceComponentFireEvent
    {
      add => this.mobjSourceComponentFireEventHandler += value;
      remove => this.mobjSourceComponentFireEventHandler -= value;
    }

    /// <summary>Occurs when [getting property value].</summary>
    internal event ProxyComponentChangingEventHandler ProxyComponentChanging
    {
      add => this.mobjProxyComponentChangingEventHandler += value;
      remove => this.mobjProxyComponentChangingEventHandler -= value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyComponent" /> class.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objParent">The obj parent.</param>
    /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
    public ProxyComponent(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
      : this()
    {
      this.Parent = objParent;
      if (blnStateComponent)
        this.PreserveComponentUniqueID(objComponent);
      else
        this.UpdateNonStateComponentType(objComponent);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyComponent" /> class.
    /// </summary>
    public ProxyComponent() => this.PropertyBag.PropertyValueChanging += new UiPropertyValueChangedEventHandler(this.PropertyBag_PropertyValueChanging);

    /// <summary>Preserves the component unique ID.</summary>
    /// <param name="objComponent">The obj component.</param>
    private void PreserveComponentUniqueID(Component objComponent) => this.UniqueID = this.GetComponentUniqueID(this.ParentForm, objComponent);

    private void UpdateNonStateComponentType(Component objComponent)
    {
      this.mobjCachedSourceCompomnent = objComponent;
      this.mstrNonStateComponentType = objComponent.GetType().AssemblyQualifiedName;
    }

    /// <summary>Gets a value indicating whether [is custom].</summary>
    /// <value>
    ///   <c>true</c> if [is custom]; otherwise, <c>false</c>.
    /// </value>
    public bool IsStateComponent => string.IsNullOrEmpty(this.mstrNonStateComponentType);

    /// <summary>Gets the type of the custom component.</summary>
    /// <value>The type of the custom component.</value>
    public string NonStateComponentType
    {
      get => this.mstrNonStateComponentType;
      set => this.mstrNonStateComponentType = value;
    }

    /// <summary>Gets or sets the name of the component.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual string Name
    {
      get => this.ToString();
      set => throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected virtual Component GetSourceComponent()
    {
      if (this.IsStateComponent)
        return this.GetComponentByUniqueId((Component) this.ParentForm, this.UniqueID);
      if (Activator.CreateInstance(Type.GetType(this.NonStateComponentType)) is Component instance && this.Parent != null)
        instance.InternalParent = this.Parent.SourceComponent;
      return instance;
    }

    /// <summary>Gets the getting property value event handler.</summary>
    /// <value>The getting property value event handler.</value>
    internal GettingPropertyValueEventHandler GettingPropertyValueEventHandler => this.mobjGettingPropertyValueEventHandler;

    /// <summary>Gets the filter properties event handler.</summary>
    /// <value>The filter properties event handler.</value>
    internal FilterPropertiesEventHandler FilterPropertiesEventHandler => this.mobjFilterPropertiesEventHandler;

    /// <summary>Gets or sets the components.</summary>
    /// <value>The components.</value>
    public virtual ProxySet Components => this.mobjComponents;

    /// <summary>
    /// Gets a value indicating whether proxy component is visible.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Visible => this.GetVisible();

    /// <summary>Returns wether proxy component is visible.</summary>
    protected virtual bool GetVisible()
    {
      if (this.PropertyBag.ContainsKey("Visible") && !(bool) this.PropertyBag["Visible"] || this.SourceComponent is Control sourceComponent && !sourceComponent.Visible)
        return false;
      return this.Parent == null || this.Parent.GetVisible();
    }

    /// <summary>Gets the owner form.</summary>
    public override Form Form => this.ParentForm != null ? this.ParentForm : base.Form;

    /// <summary>Initializes the emulation.</summary>
    internal virtual void InitializeProxy()
    {
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
        component.InitializeProxy();
      this.mblnProxyInitialized = true;
    }

    /// <summary>
    /// Gets a value indicating whether InitializeProxy already been called for this component.
    /// </summary>
    protected bool ProxyInitialized => this.mblnProxyInitialized;

    /// <summary>Sign proxy as initialized.</summary>
    protected void SetProxyInitialized() => this.mblnProxyInitialized = true;

    /// <summary>Gets the child proxy component.</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <returns></returns>
    internal ProxyComponent GetChildProxyComponent(Component objComponent)
    {
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
      {
        if (component.SourceComponent == objComponent)
          return component;
      }
      return (ProxyComponent) null;
    }

    /// <summary>Creates the proxy component from component.</summary>
    /// <param name="objComponent">The object component.</param>
    /// <param name="objParentControl">The object parent control.</param>
    /// <returns></returns>
    internal static ProxyComponent CreateProxyComponentFromComponent(
      Component objComponent,
      ProxyComponent objParentControl,
      bool blnStateComponent)
    {
      ProxyComponent componentFromComponent = (ProxyComponent) null;
      object[] customAttributes = objComponent.GetType().GetCustomAttributes(typeof (ProxyComponentAttribute), true);
      if (customAttributes.Length == 1)
        componentFromComponent = Activator.CreateInstance(((ProxyComponentAttribute) customAttributes[0]).ProxyComponentType, (object) objComponent, (object) objParentControl, (object) blnStateComponent) as ProxyComponent;
      return componentFromComponent;
    }

    /// <summary>Creates the proxy by component.</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <returns></returns>
    protected ProxyComponent CreateProxyByComponent(Component objComponent) => ProxyComponent.CreateProxyComponentFromComponent(objComponent, this, this.IsStateComponent);

    /// <summary>
    /// Raises the <see cref="E:GettingPropertyValue" /> event.
    /// </summary>
    /// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
    private void OnGettingPropertyValue(
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
    {
      if (this.mobjGettingPropertyValueEventHandler == null)
        return;
      this.mobjGettingPropertyValueEventHandler((object) this, objProxyPropertyValueEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:FilterProperties" /> event.
    /// </summary>
    /// <param name="objProxyFilterPropertiesEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyFilterPropertiesEventArgs" /> instance containing the event data.</param>
    private void OnFilterProperties(
      ProxyFilterPropertiesEventArgs objProxyFilterPropertiesEventArgs)
    {
      if (this.mobjFilterPropertiesEventHandler == null)
        return;
      this.mobjFilterPropertiesEventHandler((object) this, objProxyFilterPropertiesEventArgs);
    }

    /// <summary>
    /// Raises the <see cref="E:SourceComponentFireEvent" /> event.
    /// </summary>
    /// <param name="objFireEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyFireEventArgs" /> instance containing the event data.</param>
    internal virtual void OnSourceComponentFireEvent(ProxyFireEventArgs objFireEventArgs)
    {
      if (this.mobjSourceComponentFireEventHandler == null)
        return;
      this.mobjSourceComponentFireEventHandler((object) this, objFireEventArgs);
    }

    /// <summary>
    /// Handles the PropertyValueChanging event of the PropertyBag control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    internal void PropertyBag_PropertyValueChanging(object sender, ProxyPropertyValueEventArgs e) => this.OnPropertyValueChanging(e);

    /// <summary>
    /// Raises the <see cref="E:PropertyValueChanging" /> event.
    /// </summary>
    /// <param name="objProxyPropertyValueEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs" /> instance containing the event data.</param>
    internal virtual void OnPropertyValueChanging(
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
    {
      if (this.mobjProxyComponentChangingEventHandler == null)
        return;
      this.mobjProxyComponentChangingEventHandler((object) this, objProxyPropertyValueEventArgs);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.mobjProxyClickEventHandler != null)
        criticalEventsData.Set("CL");
      return criticalEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "Click")
        this.OnProxyClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
      ProxyFireEventArgs objFireEventArgs = new ProxyFireEventArgs(objEvent, true);
      this.OnSourceComponentFireEvent(objFireEventArgs);
      if (!objFireEventArgs.AllowEvent || this.SourceComponent == null)
        return;
      this.SourceComponent.FireComponentEvent(objEvent);
    }

    private void OnProxyClick(EventArgs objEventArgs)
    {
      if (this.mobjProxyClickEventHandler == null)
        return;
      if (!(objEventArgs is MouseEventArgs e))
        e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
      this.mobjProxyClickEventHandler((object) this, (EventArgs) e);
    }

    /// <summary>Occurs when [UI property value changing].</summary>
    internal event EventHandler ProxyClick
    {
      add => this.mobjProxyClickEventHandler += value;
      remove => this.mobjProxyClickEventHandler -= value;
    }

    /// <summary>Shoulds the type of the serialize custom component.</summary>
    /// <returns></returns>
    public bool ShouldSerializeNonStateComponentType() => this.NonStateComponentType != null;

    /// <summary>Shoulds the serialize unique identifier.</summary>
    /// <returns></returns>
    public bool ShouldSerializeUniqueID() => this.UniqueID != null;

    /// <summary>Gets the proxy property value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <param name="objDefaultValue">The obj default value.</param>
    /// <returns></returns>
    public new virtual T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
    {
      if (strPropertyName == "ID")
        return (T) (ValueType) this.ID;
      objValue = objDefaultValue;
      if (this.mobjPropertyBag.ContainsKey(strPropertyName))
      {
        object obj = this.mobjPropertyBag[strPropertyName];
        if (obj == null || !(obj is T objValue))
          ;
      }
      ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs = new ProxyPropertyValueEventArgs(strPropertyName, (object) objValue);
      this.OnGettingPropertyValue(objProxyPropertyValueEventArgs);
      return (T) objProxyPropertyValueEventArgs.Value;
    }

    /// <summary>
    /// Determines whether [has proxy property value] [the specified STR property name].
    /// </summary>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <returns>
    ///   <c>true</c> if [has proxy property value] [the specified STR property name]; otherwise, <c>false</c>.
    /// </returns>
    public new bool HasProxyPropertyValue(string strPropertyName) => this.mobjPropertyBag.ContainsKey(strPropertyName);

    /// <summary>Gets the component by path.</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="strPathPart">The STR path part.</param>
    /// <returns></returns>
    private Component GetComponentByPath(Component objComponent, string strPathPart)
    {
      int index = 0;
      string strOffspringTypeName = strPathPart;
      int length = strPathPart.IndexOf('[');
      if (length != -1)
      {
        strOffspringTypeName = strPathPart.Substring(0, length);
        int num = strPathPart.IndexOf(']');
        if (num != -1)
          index = Convert.ToInt32(strPathPart.Substring(length + 1, num - length - 1));
      }
      IList componentOffsprings = objComponent.GetComponentOffsprings(strOffspringTypeName);
      return componentOffsprings != null && index < componentOffsprings.Count && componentOffsprings[index] is Component component && strOffspringTypeName == component.GetType().FullName ? component : (Component) null;
    }

    /// <summary>Gets the component by unique id.</summary>
    /// <param name="objSourceComponent">The obj source component.</param>
    /// <param name="strComponentPath">The STR component path.</param>
    /// <returns></returns>
    internal Component GetComponentByUniqueId(Component objSourceComponent, string strComponentPath)
    {
      Component objSourceComponent1 = objSourceComponent;
      if (objSourceComponent != null && !string.IsNullOrEmpty(strComponentPath))
      {
        string[] strArray = strComponentPath.Split('/');
        if (strArray.Length >= 1)
        {
          objSourceComponent1 = this.GetComponentByPath(objSourceComponent, strArray[0]);
          if (strArray.Length > 1)
            objSourceComponent1 = this.GetComponentByUniqueId(objSourceComponent1, string.Join("/", strArray, 1, strArray.Length - 1));
        }
      }
      return objSourceComponent1;
    }

    /// <summary>Renders the specified obj context.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    public virtual void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      Component sourceComponent = this.SourceComponent;
      if (sourceComponent == null || !(sourceComponent is IRenderableComponent renderableComponent))
        return;
      sourceComponent.ProxyComponent = this;
      renderableComponent.RenderComponent(objContext, objWriter, lngRequestID);
      sourceComponent.ProxyComponent = (ProxyComponent) null;
    }

    /// <summary>Renders the components.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    public virtual void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.Components.RenderSet(objContext, objWriter, lngRequestID);
    }

    /// <summary>PreRenders the specified object.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    public virtual void PreRender(IContext objContext, long lngRequestID)
    {
    }

    /// <summary>Pres the render components.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    public virtual void PreRenderComponents(IContext objContext, long lngRequestID) => this.Components.PreRenderSet(objContext, lngRequestID);

    /// <summary>Posts the render.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="lngRequestID">The LNG request identifier.</param>
    public virtual void PostRender(IContext objContext, long lngRequestID)
    {
    }

    /// <summary>Posts the render components.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="lngRequestID">The LNG request identifier.</param>
    public virtual void PostRenderComponents(IContext objContext, long lngRequestID) => this.Components.PostRenderSet(objContext, lngRequestID);

    /// <summary>Validates the source component.</summary>
    internal virtual void ValidateSourceComponent()
    {
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
        component.ValidateSourceComponent();
    }

    /// <summary>Happens after the load of the component from XAML.</summary>
    public virtual void OnLoad()
    {
      foreach (ProxyComponent component in (List<ProxyComponent>) this.Components)
        component?.OnLoad();
    }

    /// <summary>Gets the unique ID.</summary>
    /// <value>The unique ID.</value>
    public string UniqueID
    {
      get => this.mstrUniqueID;
      set => this.mstrUniqueID = value;
    }

    /// <summary>
    /// 
    /// </summary>
    private bool ShouldGetSourceComponent
    {
      get
      {
        if (!this.IsStateComponent)
          return this.mobjCachedSourceCompomnent == null;
        return this.mobjCachedSourceCompomnent == null || !this.mobjCachedSourceCompomnent.IsRegistered;
      }
    }

    /// <summary>Gets or sets the source component.</summary>
    /// <value>The source component.</value>
    internal Component SourceComponent
    {
      get
      {
        if (this.ShouldGetSourceComponent)
          this.mobjCachedSourceCompomnent = this.GetSourceComponent();
        return this.mobjCachedSourceCompomnent;
      }
    }

    /// <summary>Gets the cached source compomnent.</summary>
    /// <value>The cached source compomnent.</value>
    internal Component CachedSourceCompomnent => this.mobjCachedSourceCompomnent;

    /// <summary>Gets the property bag.</summary>
    public ProxyPropertyBag PropertyBag => this.mobjPropertyBag;

    /// <summary>Gets the parent.</summary>
    public virtual ProxyComponent Parent
    {
      get => this.mobjParent;
      set => this.mobjParent = value;
    }

    /// <summary>Gets or sets the parent form.</summary>
    /// <value>The parent form.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Form ParentForm
    {
      get
      {
        if (this.mobjParentForm != null)
          return this.mobjParentForm;
        return this.Parent != null ? this.Parent.ParentForm : (Form) null;
      }
      set => this.mobjParentForm = value;
    }

    /// <summary>
    /// Gets a value indicating whether this instance is emulation mode.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is emulation mode; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmulationMode => this.Context is IContextParams context && context.EmulatorForm != null;

    AttributeCollection ICustomTypeDescriptor.GetAttributes() => TypeDescriptor.GetAttributes((object) this, true);

    string ICustomTypeDescriptor.GetClassName() => TypeDescriptor.GetClassName((object) this, true);

    string ICustomTypeDescriptor.GetComponentName() => TypeDescriptor.GetComponentName((object) this, true);

    TypeConverter ICustomTypeDescriptor.GetConverter() => TypeDescriptor.GetConverter((object) this, true);

    EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() => TypeDescriptor.GetDefaultEvent((object) this, true);

    PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() => TypeDescriptor.GetDefaultProperty((object) this, true);

    object ICustomTypeDescriptor.GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor((object) this, editorBaseType, true);

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents((object) this, attributes, true);

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => TypeDescriptor.GetEvents((object) this, true);

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes) => this.GetCustomProperties(attributes);

    /// <summary>Gets the custom properties.</summary>
    /// <param name="arrAttributes">The attributes.</param>
    /// <returns></returns>
    private PropertyDescriptorCollection GetCustomProperties(Attribute[] arrAttributes)
    {
      PropertyDescriptorCollection componentProperties = this.GetProxyComponentProperties(arrAttributes);
      this.OnFilterProperties(new ProxyFilterPropertiesEventArgs((IDictionary) componentProperties));
      return componentProperties;
    }

    /// <summary>Gets the proxy component property owner.</summary>
    /// <returns></returns>
    protected virtual object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor) => (object) this.SourceComponent;

    /// <summary>Gets the proxy component properties.</summary>
    /// <param name="arrAttributes">The arr attributes.</param>
    /// <returns></returns>
    protected virtual PropertyDescriptorCollection GetProxyComponentProperties(
      Attribute[] arrAttributes)
    {
      List<PropertyDescriptor> propertyDescriptorList = new List<PropertyDescriptor>();
      Component sourceComponent = this.SourceComponent;
      if (sourceComponent != null)
      {
        foreach (PropertyDescriptor property in TypeDescriptor.GetProperties((object) sourceComponent, arrAttributes, true))
        {
          if (property.Attributes[typeof (ProxyBrowsableAttribute)] is ProxyBrowsableAttribute attribute1 && attribute1.Browsable && (!(property.Attributes[typeof (BrowsableAttribute)] is BrowsableAttribute attribute2) || attribute2.Browsable))
            propertyDescriptorList.Add(property);
        }
      }
      return new PropertyDescriptorCollection(propertyDescriptorList.ToArray());
    }

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => this.GetCustomProperties((Attribute[]) null);

    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor) => this.GetProxyComponentPropertyOwner(objPropertyDescriptor);
  }
}
