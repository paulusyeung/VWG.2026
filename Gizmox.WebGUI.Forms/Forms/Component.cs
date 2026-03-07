// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Component
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The base class for all GUI elements</summary>
  [ToolboxItem(false)]
  [Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof (IDesigner))]
  [ProxyComponent(typeof (ProxyComponent))]
  [Serializable]
  public class Component : RegisteredComponent, IObservableItem, IAttributeExtender
  {
    /// <summary>The DragDrop event registration.</summary>
    private static readonly SerializableEvent DragDropEvent = SerializableEvent.Register("DragDrop", typeof (DragEventHandler), typeof (Component));
    /// <summary>The DragDrop event registration.</summary>
    private static readonly SerializableEvent SwipeEvent = SerializableEvent.Register("Swipe", typeof (Component.SwipeEventHandler), typeof (Component));
    /// <summary>The ContextMenuStripChanged event registration.</summary>
    private static readonly SerializableEvent ContextMenuStripChangedEvent = SerializableEvent.Register("ContextMenuStripChanged", typeof (EventHandler), typeof (Component));
    /// <summary>The MenuClick event registration.</summary>
    private static readonly SerializableEvent MenuClickEvent = SerializableEvent.Register("MenuClick", typeof (MenuEventHandler), typeof (Component));
    private static SkinResourceHandle mobjEmptyGif;
    /// <summary>
    /// The proxy component representing the object during emulations. Will be populated during render time.
    /// </summary>
    private ProxyComponent mobjProxyComponent;
    /// <summary>The win forms compatibility</summary>
    private WinFormsCompatibility mobjWinFormsCompatibility;
    /// <summary>The component state</summary>
    [NonSerialized]
    private int mintComponentState;
    /// <summary>Register the LoadingMessage property</summary>
    private static SerializableProperty LoadingMessageProperty = SerializableProperty.Register("LoadingMessage", typeof (string), typeof (Component), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register the ClientAction property</summary>
    private static SerializableProperty ClientActionProperty = SerializableProperty.Register(nameof (ClientAction), typeof (RegisteredClientAction), typeof (Component), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the Attributes property</summary>
    private static SerializableProperty AttributesProperty = SerializableProperty.Register("Attributes", typeof (Component.AttributesWrapper), typeof (Component), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the Tag property</summary>
    private static SerializableProperty TagProperty = SerializableProperty.Register(nameof (Tag), typeof (object), typeof (Component), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the SystemTag property</summary>
    private static SerializableProperty SystemTagProperty = SerializableProperty.Register(nameof (SystemTag), typeof (object), typeof (Component), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the CustomTemplate property</summary>
    private static SerializableProperty CustomTemplateProperty = SerializableProperty.Register(nameof (CustomTemplate), typeof (string), typeof (Component), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The parent of this component</summary>
    [NonSerialized]
    private Component mobjInternalParent;
    /// <summary>Register the AllowDragTargetsPropagation property</summary>
    private static SerializableProperty AllowDragTargetsPropagationProperty = SerializableProperty.Register(nameof (AllowDragTargetsPropagation), typeof (bool), typeof (Component), new SerializablePropertyMetadata((object) true));
    /// <summary>Register the DragTargets property</summary>
    private static SerializableProperty ExcludedDragTargetsProperty = SerializableProperty.Register(nameof (ExcludedDragTargets), typeof (Component[]), typeof (Component), new SerializablePropertyMetadata((object) new Component[0]));
    private static SerializableProperty DragTargetsProperty = SerializableProperty.Register(nameof (DragTargets), typeof (Component[]), typeof (Component), new SerializablePropertyMetadata((object) new Component[0]));
    private static SerializableProperty ReferencedDragTargetsComponentProperty = SerializableProperty.Register(nameof (ReferencedDragTargetsComponent), typeof (Component), typeof (Component), new SerializablePropertyMetadata((object) null));
    /// <summary>The component context menu</summary>
    [NonSerialized]
    private ContextMenu mobjContextMenu;
    /// <summary>The component context menu strip.</summary>
    [NonSerialized]
    private ContextMenuStrip mobjContextMenuStrip;

    /// <summary>Occurs when a drag-and-drop operation is completed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatDragDrop")]
    [SRDescription("ControlOnDragDropDescr")]
    public virtual event DragEventHandler DragDrop
    {
      add => this.AddHandler(Component.DragDropEvent, (Delegate) value);
      remove => this.RemoveHandler(Component.DragDropEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the DragDrop event.</summary>
    private DragEventHandler DragDropHandler => (DragEventHandler) this.GetHandler(Component.DragDropEvent);

    /// <summary>Occurs when [swipe].</summary>
    public virtual event Component.SwipeEventHandler Swipe
    {
      add => this.AddCriticalHandler(Component.SwipeEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Component.SwipeEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the DragDrop event.</summary>
    private Component.SwipeEventHandler SwipHandler => (Component.SwipeEventHandler) this.GetHandler(Component.SwipeEvent);

    /// <summary>Invokes when a menu item was clicked</summary>
    public virtual event MenuEventHandler MenuClick
    {
      add => this.AddHandler(Component.MenuClickEvent, (Delegate) value);
      remove => this.RemoveHandler(Component.MenuClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the MenuClick event.</summary>
    private MenuEventHandler MenuClickHandler => (MenuEventHandler) this.GetHandler(Component.MenuClickEvent);

    /// <summary>
    /// Occurs when the value of the <see cref="P:System.Windows.Forms.Control.ContextMenuStrip"></see> property changes.
    /// </summary>
    [SRDescription("ControlContextMenuStripChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler ContextMenuStripChanged
    {
      add => this.AddHandler(Component.ContextMenuStripChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Component.ContextMenuStripChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the ContextMenuStripChanged event.
    /// </summary>
    private EventHandler ContextMenuStripChangedHandler => (EventHandler) this.GetHandler(Component.ContextMenuStripChangedEvent);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Component" /> instance.
    /// </summary>
    public Component()
    {
      this.SetState(Component.ComponentState.AllowDrag, true);
      this.SetState(Component.ComponentState.AnimationEnabled, this.DefaultAnimation);
      this.SetState(Component.ComponentState.DropIndicatorPropogation, true);
    }

    /// <summary>Sets the state.</summary>
    /// <param name="intFlag">The flag to set.</param>
    /// <param name="blnValue">The flag value to set.</param>
    internal void SetState(Component.ComponentState enmState, bool blnValue) => this.mintComponentState = blnValue ? (int) ((Component.ComponentState) this.mintComponentState | enmState) : (int) ((Component.ComponentState) this.mintComponentState & ~enmState);

    /// <summary>
    /// Sets the state and returns a flag if value had changed.
    /// </summary>
    /// <param name="intFlag">The flag to set.</param>
    /// <param name="blnValue">The flag value to set.</param>
    internal bool SetStateWithCheck(Component.ComponentState enmState, bool blnValue)
    {
      if (this.GetState(enmState) == blnValue)
        return false;
      this.SetState(enmState, blnValue);
      return true;
    }

    /// <summary>Gets the state.</summary>
    /// <param name="intFlag">The flag to get.</param>
    /// <returns></returns>
    internal bool GetState(Component.ComponentState enmState) => ((Component.ComponentState) this.mintComponentState & enmState) != 0;

    /// <summary>Renders the component update attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected void RenderComponentUpdateAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      objWriter.WriteAttributeString("Id", this.GetProxyPropertyValue<long>("ID", this.ID).ToString());
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Drag))
        this.RenderDragAndDropAttributes(objContext, objWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
        this.RenderComponentEventAttributes(objContext, objWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.VisualEffect))
        this.RenderComponentVisualEffectsAttributes(objContext, objWriter);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        this.RenderClientID(objWriter, true);
      this.RenderClientUpdateHandler(objContext, objWriter, true);
      this.RenderUseClientUpdateHandlerAttribute(objContext, objWriter);
      this.RenderSwipableAttribute(objWriter);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected void RenderComponentAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      this.RenderComponentID(objWriter);
      this.RenderClientID(objWriter, false);
      this.RenderIsDirtyAttributes(objContext, objWriter);
      this.RenderComponentEventAttributes(objContext, objWriter, false);
      this.RenderClientUpdateHandler(objContext, objWriter, false);
      this.RenderUseClientUpdateHandlerAttribute(objContext, objWriter);
      this.RenderAnimationAttributes(objWriter);
      this.RenderComponentVisualEffectsAttributes(objContext, objWriter);
      this.RenderClientEventsPropogationTags(objWriter);
      string customTemplate = this.CustomTemplate;
      if (!string.IsNullOrEmpty(customTemplate))
        objWriter.WriteAttributeString("CT", customTemplate);
      string strText = this.GetValue<string>(Component.LoadingMessageProperty);
      if (!string.IsNullOrEmpty(strText))
        objWriter.WriteAttributeText("LM", strText);
      ContextMenu contextMenuInherited = this.ContextMenuInherited;
      if (contextMenuInherited != null)
        objWriter.WriteAttributeString("M", contextMenuInherited.ID.ToString());
      this.RenderSwipableAttribute(objWriter);
      this.RenderClientInvocation(objContext, objWriter);
      this.RenderExtendedComponentAttributes(objContext, objWriter);
      this.RenderDragAndDropAttributes(objContext, objWriter, false);
      if (!this.Context.Config.EnableAutomationIds || !string.IsNullOrEmpty(((IAttributeExtender) this).GetAttribute("CUID")))
        return;
      string componentUniqueId = this.GetComponentUniqueID(this.Form, this);
      if (string.IsNullOrEmpty(componentUniqueId))
        return;
      objWriter.WriteAttributeText("CUID", componentUniqueId);
    }

    /// <summary>Renders the is dirty attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected internal void RenderIsDirtyAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      if (!(objContext is IContextParams contextParams))
        return;
      long lastRender = contextParams.LastRender;
      if (lastRender == 0L || !this.IsDirty(lastRender) && !this.IsDirtyAttributes(lastRender) || !this.ShouldRenderIsDirtyAttribute(lastRender))
        return;
      objWriter.WriteAttributeString("IY", "1");
    }

    /// <summary>Renders the component's ID.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderComponentID(IAttributeWriter objWriter) => objWriter.WriteAttributeString("Id", this.GetProxyPropertyValue<long>("ID", this.ID).ToString());

    /// <summary>Renders the component's ID.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderClientID(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!blnForceRender && string.IsNullOrEmpty(this.ClientId))
        return;
      objWriter.WriteAttributeString("CID", this.ClientId);
    }

    /// <summary>Renders the swipable attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderSwipableAttribute(IAttributeWriter objWriter)
    {
      if (this.SwipHandler == null)
        return;
      objWriter.WriteAttributeString("SW", "1");
    }

    /// <summary>Renders the client invocation mapping if needed.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected internal void RenderClientInvocation(IContext objContext, IAttributeWriter objWriter)
    {
      if (!this.ShouldRenderClientEvents)
        return;
      this.ClientAction?.RenderAttributes((IContextMethodInvoker) objContext, objWriter);
    }

    /// <summary>Returns the component client events list.</summary>
    protected override ClientEventList GetClientEvents() => this.GetProxyPropertyValue<ClientEventList>("ClientEvents", (ClientEventList) null) ?? base.GetClientEvents();

    /// <summary>Renders the client events and behavior fields.</summary>
    /// <value>
    /// <c>true</c> if [should render client events]; otherwise, <c>false</c>.
    /// </value>
    /// <returns></returns>
    protected override bool ShouldRenderClientEvents => this.GetProxyPropertyValue<bool>(nameof (ShouldRenderClientEvents), true);

    /// <summary>Renders the extended component attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected internal void RenderExtendedComponentAttributes(
      IContext objContext,
      IAttributeWriter objWriter)
    {
      ((IAttributeExtender) this).RenderAttributes(objWriter);
    }

    /// <summary>Renders the drag and drop attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected void RenderDragAndDropAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      Component[] proxyPropertyValue = this.GetProxyPropertyValue<Component[]>("DragTargets", this.DragTargets);
      if (((proxyPropertyValue == null ? 0 : (proxyPropertyValue.Length != 0 ? 1 : 0)) | (blnForceRender ? 1 : 0)) != 0)
        objWriter.WriteAttributeString("DTS", this.CommaSeperatedString((IEnumerable<Component>) proxyPropertyValue));
      if (this.AllowDrop | blnForceRender)
        objWriter.WriteAttributeString("AD", this.AllowDrop ? "1" : "0");
      if (!this.AllowDrag | blnForceRender)
        objWriter.WriteAttributeString("ADG", this.AllowDrag ? "1" : "0");
      if (!this.DropIndicatorPropogation | blnForceRender)
        objWriter.WriteAttributeString("DIP", this.DropIndicatorPropogation ? "1" : "0");
      if (((this.ExcludedDragTargets == null ? 0 : (this.ExcludedDragTargets.Length != 0 ? 1 : 0)) | (blnForceRender ? 1 : 0)) != 0)
        objWriter.WriteAttributeString("EDT", this.CommaSeperatedString((IEnumerable<Component>) this.ExcludedDragTargets));
      bool targetsPropagation = this.AllowDragTargetsPropagation;
      if (!targetsPropagation | blnForceRender)
        objWriter.WriteAttributeString("APC", targetsPropagation ? "1" : "0");
      if (!(this.ReferencedDragTargetsComponent != null | blnForceRender))
        return;
      string strValue = this.ReferencedDragTargetsComponent != null ? this.ReferencedDragTargetsComponent.ID.ToString() : string.Empty;
      objWriter.WriteAttributeString("DTC", strValue);
    }

    /// <summary>Commas the seperated string.</summary>
    /// <param name="obj">The obj.</param>
    /// <returns></returns>
    private string CommaSeperatedString(IEnumerable<Component> obj)
    {
      string str1 = string.Empty;
      string str2 = string.Empty;
      foreach (Component component in obj)
      {
        str1 = str1 + str2 + (object) component.ID;
        str2 = ",";
      }
      return str1;
    }

    /// <summary>Registers the default client invocation.</summary>
    /// <param name="strMethod">The target method.</param>
    /// <param name="arrArgs">The invocation args.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void RegisterClientAction(string strMethod, params string[] arrArgs) => this.RegisterClientAction((Component) null, strMethod, arrArgs);

    /// <summary>Registers the default client invocation.</summary>
    /// <param name="objTarget">The invocation target.</param>
    /// <param name="strMethod">The target method.</param>
    /// <param name="arrArgs">The invocation args.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void RegisterClientAction(
      Component objTarget,
      string strMethod,
      params string[] arrArgs)
    {
      if (strMethod == null)
        throw new ArgumentNullException(nameof (strMethod));
      this.ClientAction = RegisteredClientAction.Create((IRegisteredComponent) objTarget, strMethod, arrArgs);
      this.Update();
    }

    /// <summary>
    /// Registers the default client invocation (Adds component id as the first parameter).
    /// </summary>
    /// <param name="objTarget">The invocation target.</param>
    /// <param name="strMethod">The target method.</param>
    /// <param name="arrArgs">The invocation args.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void RegisterClientActionWithId(
      Component objTarget,
      string strMethod,
      params string[] arrArgs)
    {
      if (strMethod == null)
        throw new ArgumentNullException(nameof (strMethod));
      if (objTarget == null)
        throw new ArgumentNullException(nameof (objTarget));
      this.ClientAction = RegisteredClientAction.CreateWithId((IRegisteredComponent) objTarget, strMethod, arrArgs);
      this.Update();
    }

    /// <summary>Gets or sets the client action.</summary>
    /// <value>The client action.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RegisteredClientAction ClientAction
    {
      get => this.GetValue<RegisteredClientAction>(Component.ClientActionProperty);
      set
      {
        if (!this.SetValue<RegisteredClientAction>(Component.ClientActionProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Unregisters the default client invocation.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void UnregisterClientAction()
    {
      this.ClientAction = (RegisteredClientAction) null;
      this.Update();
    }

    /// <summary>Sets the loading message.</summary>
    /// <value></value>
    public void SetLoadingMessage(string strLoadingMessage) => this.SetValue<string>(Component.LoadingMessageProperty, strLoadingMessage);

    /// <summary>
    /// This is a recursive function that loop through a control and all of its parents
    /// cheching if one of the controls(and control containers) is hidden or
    /// disabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
    /// </value>
    /// <returns>false if one of the controls is hidden or disabled.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool IsEventsEnabled
    {
      get
      {
        if (this.InternalParent == null)
          return base.IsEventsEnabled;
        bool isEventsEnabled = this.InternalParent.IsEventsEnabled;
        if (!this.DesignMode && this.InternalParent is Form internalParent && this.Context.Config.FormsSecurityEnabled)
        {
          IContextParams context = this.Context as IContextParams;
          isEventsEnabled &= context.GetFormAccessMode((IForm) internalParent) == FormAccessMode.FullControl;
        }
        return isEventsEnabled;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
    /// event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private void OnComponentClick(EventArgs objEventArgs)
    {
      if (!(objEventArgs is MouseEventArgs mouseEventArgs))
        mouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
      if (mouseEventArgs.Button != MouseButtons.Right)
        return;
      if (this.ContextMenuInherited != null)
      {
        this.ContextMenuInherited.Show(this, new Point(mouseEventArgs.X, mouseEventArgs.Y), DialogAlignment.Custom);
      }
      else
      {
        if (this.ContextMenuStripInherited == null)
          return;
        this.ContextMenuStripInherited.ShowDropDown(this, mouseEventArgs.X, mouseEventArgs.Y);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.ContextMenuStripChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnContextMenuStripChanged(EventArgs e)
    {
      EventHandler stripChangedHandler = this.ContextMenuStripChangedHandler;
      if (stripChangedHandler == null)
        return;
      stripChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.DragDrop"></see> event.</summary>
    /// <param name="objDragEventArgs">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnDragDrop(DragEventArgs objDragEventArgs)
    {
      DragEventHandler dragDropHandler = this.DragDropHandler;
      if (dragDropHandler == null)
        return;
      dragDropHandler((object) this, objDragEventArgs);
    }

    /// <summary>Called when [swipe].</summary>
    /// <param name="enmSwipeDirection">The swipe direction.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSwipe(SwipeDirection enmSwipeDirection)
    {
      Component.SwipeEventHandler swipHandler = this.SwipHandler;
      if (swipHandler == null)
        return;
      swipHandler(this, enmSwipeDirection);
    }

    /// <summary>Detaches the context menu.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DetachContextMenu(object sender, EventArgs e) => this.ContextMenu = (ContextMenu) null;

    /// <summary>Detaches the context menu strip.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DetachContextMenuStrip(object sender, EventArgs e) => this.ContextMenuStrip = (ContextMenuStrip) null;

    /// <summary>Gets the proxy property value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <param name="objDefaultValue">The obj default value.</param>
    /// <returns></returns>
    protected internal virtual T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
    {
      ProxyComponent proxyComponent = this.ProxyComponent;
      return proxyComponent != null ? proxyComponent.GetProxyPropertyValue<T>(strPropertyName, objDefaultValue) : objDefaultValue;
    }

    /// <summary>
    /// Determines whether [has proxy property value] [the specified STR property name].
    /// </summary>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <returns>
    ///   <c>true</c> if [has proxy property value] [the specified STR property name]; otherwise, <c>false</c>.
    /// </returns>
    protected internal virtual bool HasProxyPropertyValue(string strPropertyName)
    {
      ProxyComponent proxyComponent = this.ProxyComponent;
      return proxyComponent != null && proxyComponent.HasProxyPropertyValue(strPropertyName);
    }

    /// <summary>Gets the ancestor by type.</summary>
    /// <param name="objType">type.</param>
    /// <returns></returns>
    protected Component GetAncestorByType(Type objType)
    {
      Component o = this;
      while (o != null && o != o.InternalParent && !objType.IsInstanceOfType((object) o) && o != null)
        o = o.InternalParent;
      return o;
    }

    /// <summary>Disposes the specified component.</summary>
    /// <param name="blnDisposing"></param>
    protected override void Dispose(bool blnDisposing)
    {
      base.Dispose(blnDisposing);
      if (!blnDisposing)
        return;
      ContextMenu contextMenu = this.ContextMenu;
      if (contextMenu == null)
        return;
      contextMenu.Disposed -= new EventHandler(this.DetachContextMenu);
    }

    /// <summary>Gets the event integer attribute value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="strAttribute">The attribute name.</param>
    /// <param name="intDefault">The default integer value.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
    {
      string strValue = objEvent[strAttribute];
      if (CommonUtils.IsNullOrEmpty(strValue))
        return intDefault;
      double dblValue = 0.0;
      CommonUtils.TryParse(strValue, out dblValue);
      return Convert.ToInt32(dblValue);
    }

    /// <summary>Gets the event buttons value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="enmDefault">The default value.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
    {
      switch (objEvent["BTN"])
      {
        case "L":
          return MouseButtons.Left;
        case "R":
          return MouseButtons.Right;
        case "M":
          return MouseButtons.Middle;
        default:
          return enmDefault;
      }
    }

    /// <summary>Fires the menu click.</summary>
    /// <param name="objMenuItem">The obj menu item.</param>
    internal void FireMenuClick(MenuItem objMenuItem, IIdentifiedComponent objMember) => this.FireMenuClick(new MenuItemEventArgs(objMenuItem, this, objMember));

    /// <summary>Fires the menu click.</summary>
    /// <param name="objMenuItem">The obj menu item.</param>
    internal void FireMenuClick(MenuItem objMenuItem) => this.FireMenuClick(new MenuItemEventArgs(objMenuItem, this));

    /// <summary>Fires the menu click.</summary>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MenuItemEventArgs" /> instance containing the event data.</param>
    internal void FireMenuClick(MenuItemEventArgs objEventArgs)
    {
      if (this.MenuClickHandler != null)
      {
        this.MenuClickHandler((object) this, objEventArgs);
      }
      else
      {
        if (this.InternalParent == null)
          return;
        this.InternalParent.FireMenuClick(objEventArgs);
      }
    }

    /// <summary>Gets the image.</summary>
    /// <param name="intHandledImageKey">The int handled image key.</param>
    /// <param name="objImageList">The obj image list.</param>
    /// <param name="intImageIndex">Index of the int image.</param>
    /// <param name="strImageKey">The STR image key.</param>
    /// <param name="intParentImageIndex">Index of the int parent image.</param>
    /// <param name="strParentImageKey">The STR parent image key.</param>
    /// <returns></returns>
    protected internal ResourceHandle GetImage(
      SerializableProperty intHandledImageKey,
      ImageList objImageList,
      int intImageIndex,
      string strImageKey,
      int intParentImageIndex,
      string strParentImageKey)
    {
      if (objImageList == null)
        return this.GetValue<ResourceHandle>(intHandledImageKey);
      if (intImageIndex > -1)
        return objImageList.Images[intImageIndex];
      if (!string.IsNullOrEmpty(strImageKey))
        return objImageList.Images[strImageKey];
      if (intParentImageIndex > -1)
        return objImageList.Images[intParentImageIndex];
      return !string.IsNullOrEmpty(strParentImageKey) ? objImageList.Images[strParentImageKey] : (ResourceHandle) null;
    }

    /// <summary>Sets the image.</summary>
    /// <param name="objHandledImage">The obj handled image.</param>
    /// <param name="objNewValue">The obj new value.</param>
    /// <param name="objImageList">The obj image list.</param>
    protected internal bool SetImage(
      SerializableProperty intHandledImageKey,
      ResourceHandle objNewValue,
      ImageList objImageList)
    {
      if (objImageList != null)
        throw new Exception("Cannot assign image when working in ImageList mode.");
      int num = this.SetValue<ResourceHandle>(intHandledImageKey, objNewValue) ? 1 : 0;
      if (num == 0)
        return num != 0;
      this.Update();
      return num != 0;
    }

    /// <summary>Gets the component critical events.</summary>
    /// <returns></returns>
    internal CriticalEventsData GetComponentCriticalEventsData() => this.GetCriticalEventsData();

    /// <summary>Gets the component critical client events.</summary>
    /// <returns></returns>
    internal CriticalEventsData GetComponentCriticalClientEventsData() => this.GetCriticalClientEventsData();

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      ProxyComponent proxyComponent = this.ProxyComponent;
      if (proxyComponent != null)
        criticalEventsData.Set(proxyComponent.GetCriticalEventsData());
      if (this.DragDropHandler != null)
        criticalEventsData.Set("DD");
      if (this.ContextMenuInherited != null || this.ContextMenuStripInherited != null)
        criticalEventsData.Set("RC");
      if (this.SwipHandler != null)
        criticalEventsData.Set("SWP");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      ProxyComponent proxyComponent = this.ProxyComponent;
      if (proxyComponent != null)
        clientEventsData.Set(proxyComponent.GetCriticalClientEventsData());
      if (this.HasClientHandler("StartDrag"))
        clientEventsData.Set("SD");
      if (this.HasClientHandler("DragDrop"))
        clientEventsData.Set("DD");
      return clientEventsData;
    }

    /// <summary>Occurs when [client after start drag].</summary>
    [SRDescription("Occurs when control dragged in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientStartDrag
    {
      add => this.AddClientHandler("StartDrag", value);
      remove => this.RemoveClientHandler("StartDrag", value);
    }

    /// <summary>Occurs when [client drag drop].</summary>
    [SRDescription("Occurs when dragged component dropped in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientDragDrop
    {
      add => this.AddClientHandler("DragDrop", value);
      remove => this.RemoveClientHandler("DragDrop", value);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Click":
          this.OnComponentClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
        case "DragDrop":
          if (objEvent["DS"] == null || !(((ISessionRegistry) this.Context).GetRegisteredComponent(objEvent["DS"]) is Component registeredComponent1) || !(((ISessionRegistry) this.Context).GetRegisteredComponent(objEvent["ET"]) is Component registeredComponent2))
            break;
          int intKeyState = 0;
          if (objEvent["KS"] != null)
            intKeyState = Convert.ToInt32(objEvent["KS"]);
          Point eventPosition1 = this.GetEventPosition(objEvent, "CPS");
          Point eventPosition2 = this.GetEventPosition(objEvent, "RPS");
          this.OnDragDrop((DragEventArgs) new DragDropEventArgs(registeredComponent1, this, registeredComponent2, intKeyState, eventPosition1.X, eventPosition1.Y, eventPosition2.X, eventPosition2.Y, DragDropEffects.Move, DragDropEffects.Move));
          break;
        case "Swipe":
          string s = objEvent["DR"];
          if (string.IsNullOrEmpty(s))
            break;
          int result = -1;
          if (!int.TryParse(s, out result) || !Enum.IsDefined(typeof (SwipeDirection), (object) result))
            break;
          this.OnSwipe((SwipeDirection) Enum.Parse(typeof (SwipeDirection), s));
          break;
      }
    }

    /// <summary>Gets position from event.</summary>
    private Point GetEventPosition(IEvent objEvent, string strEventName)
    {
      int x = 0;
      int y = 0;
      if (objEvent[strEventName] != null)
      {
        string str = objEvent[strEventName];
        if (str != null)
        {
          string[] strArray = str.Split(',');
          if (strArray != null && strArray.Length == 2)
          {
            x = Convert.ToInt32(Convert.ToDouble(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture));
            y = Convert.ToInt32(Convert.ToDouble(strArray[1], (IFormatProvider) CultureInfo.InvariantCulture));
          }
        }
      }
      return new Point(x, y);
    }

    /// <summary>Fires the component event.</summary>
    /// <param name="objEvent">The obj event.</param>
    internal void FireComponentEvent(IEvent objEvent) => this.FireEvent(objEvent);

    /// <summary>Fires a component event</summary>
    /// <param name="objSource"></param>
    /// <param name="objArgs"></param>
    internal void FireComponentEvent(object objSource, EventArgs objArgs)
    {
      if (!(objArgs is MenuItemEventArgs) || this.MenuClickHandler == null)
        return;
      this.MenuClickHandler(objSource, objArgs as MenuItemEventArgs);
    }

    /// <summary>
    /// Property change indicator for the observable item interface
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

    /// <summary>
    /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
    /// </summary>
    /// <param name="strProperty">The name of the property that has changed</param>
    protected void FireObservableItemPropertyChanged(string strProperty)
    {
      if (this.ObservableItemPropertyChanged == null)
        return;
      this.ObservableItemPropertyChanged((object) this, new ObservableItemPropertyChangedArgs(strProperty));
    }

    /// <summary>
    /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
    /// </summary>
    /// <param name="strProperty">The name of the property that has changed</param>
    /// <param name="objSubject">The subject of the property that has changed</param>
    protected void FireObservableItemPropertyChanged(string strProperty, object objSubject)
    {
      if (this.ObservableItemPropertyChanged == null)
        return;
      this.ObservableItemPropertyChanged((object) this, new ObservableItemPropertyChangedArgs(strProperty, objSubject));
    }

    /// <summary>Gets an attribute from the container</summary>
    /// <param name="strName">The attribute name.</param>
    /// <returns></returns>
    string IAttributeExtender.GetAttribute(string strName) => this.GetValue<Component.AttributesWrapper>(Component.AttributesProperty)?[strName];

    void IAttributeExtender.SetAttribute(string strName, string strValue)
    {
      Component.AttributesWrapper objValue = this.GetValue<Component.AttributesWrapper>(Component.AttributesProperty);
      if (objValue == null)
      {
        objValue = new Component.AttributesWrapper();
        this.SetValue<Component.AttributesWrapper>(Component.AttributesProperty, objValue);
      }
      if (!(objValue[strName] != strValue))
        return;
      objValue[strName] = strValue;
      this.UpdateParams(AttributeType.Extended);
    }

    /// <summary>Renders the attributes.</summary>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void RenderAttributes(IAttributeWriter objAttributeWriter, long lngRequestID) => this.GetValue<Component.AttributesWrapper>(Component.AttributesProperty)?.RenderAttributes(objAttributeWriter, lngRequestID);

    /// <summary>Renders the controls meta attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
    }

    /// <summary>Renders the client events propogated tags.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    private void RenderClientEventsPropogationTags(IAttributeWriter objAttributeWriter)
    {
      if (string.IsNullOrEmpty(this.ClientEventsPropogationTags))
        return;
      objAttributeWriter.WriteAttributeString("OEPT", this.ClientEventsPropogationTags);
    }

    /// <summary>
    /// Writes the container attributes to an IAttributeWriter
    /// </summary>
    /// <param name="objAttributeWriter"></param>
    void IAttributeExtender.RenderAttributes(IAttributeWriter objAttributeWriter) => this.RenderAttributes(objAttributeWriter, 0L);

    /// <summary>Renders the updated attributes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    void IAttributeExtender.RenderUpdatedAttributes(IAttributeWriter objWriter, long lngRequestID) => this.RenderAttributes(objWriter, lngRequestID);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected virtual WinFormsCompatibility GetWinFormsCompatibility() => new WinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void WinFormsCompatibilityOptionValueChanged(
      object sender,
      WinFormsCompatibilityEventArgs e)
    {
      this.OnWinFormsCompatibilityOptionValueChanged(e.ChangedOptionName);
    }

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected virtual void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
    }

    /// <summary>Gets the empty GIF handle.</summary>
    /// <value>The empty GIF.</value>
    protected static SkinResourceHandle EmptyGif
    {
      get
      {
        if (Component.mobjEmptyGif == null)
          Component.mobjEmptyGif = new SkinResourceHandle(typeof (CommonSkin), "Empty.gif");
        return Component.mobjEmptyGif;
      }
    }

    /// <summary>Renders the animation.</summary>
    /// <param name="objWriter">The obj writer.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void RenderAnimationAttributes(IAttributeWriter objWriter)
    {
      if (!this.Animation)
        return;
      objWriter.WriteAttributeString("AN", "1");
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is animation.
    /// </summary>
    /// <value><c>true</c> if animation; otherwise, <c>false</c>.</value>
    /// <remarks>This is a temporary implementation of animation support.</remarks>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal bool Animation
    {
      get => this.GetState(Component.ComponentState.AnimationEnabled);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.AnimationEnabled, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets a value indicating whether animation is enabled by default.
    /// </summary>
    /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool DefaultAnimation => false;

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal virtual IList GetComponentOffsprings(string strOffspringTypeName) => (IList) null;

    /// <summary>Gets the component unique ID.</summary>
    /// <param name="objMainForm">The obj main form.</param>
    /// <param name="objComponent">The obj component.</param>
    /// <returns></returns>
    internal string GetComponentUniqueID(Form objMainForm, Component objComponent)
    {
      if (objComponent != null && objComponent != objMainForm)
      {
        string fullName = objComponent.GetType().FullName;
        if (!string.IsNullOrEmpty(fullName))
        {
          Component internalParent = objComponent.InternalParent;
          if (internalParent != null)
          {
            string str = this.GetComponentUniqueID(objMainForm, internalParent);
            if (!string.IsNullOrEmpty(str))
              str = string.Format("{0}/", (object) str);
            IList componentOffsprings = internalParent.GetComponentOffsprings(fullName);
            if (componentOffsprings != null)
              return string.Format("{0}{1}[{2}]", (object) str, (object) fullName, (object) componentOffsprings.IndexOf((object) objComponent));
          }
        }
      }
      return (string) null;
    }

    /// <summary>Shoulds the render is dirty attribute.</summary>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <returns></returns>
    protected override bool ShouldRenderIsDirtyAttribute(long lngRequestID) => this.HasParentWithClientUpdateHandler() && this.FirstDirtyParentHasClientUpdateHandler(lngRequestID);

    /// <summary>Firsts the dirty parent has client update handler.</summary>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <returns></returns>
    private bool FirstDirtyParentHasClientUpdateHandler(long lngRequestID)
    {
      Component internalParent = this.InternalParent;
      if (internalParent == null)
        return false;
      if (!internalParent.IsDirty(lngRequestID) && !internalParent.IsDirtyAttributes(lngRequestID))
        return internalParent.FirstDirtyParentHasClientUpdateHandler(lngRequestID);
      return internalParent.UseClientUpdateHandler && !string.IsNullOrEmpty(internalParent.ClientUpdateHandler);
    }

    /// <summary>
    /// Determines whether [has parent with client update handler].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if [has parent with client update handler]; otherwise, <c>false</c>.
    /// </returns>
    protected bool HasParentWithClientUpdateHandler()
    {
      Component internalParent = this.InternalParent;
      if (internalParent == null)
        return false;
      return internalParent.UseClientUpdateHandler && !string.IsNullOrEmpty(internalParent.ClientUpdateHandler) || internalParent.HasParentWithClientUpdateHandler();
    }

    /// <summary>
    /// Gets a value indicating whether this instance is connected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is connected; otherwise, <c>false</c>.
    /// </value>
    protected override bool IsConnected => this.InternalParent != null;

    /// <summary>Gets/Sets User definied tag</summary>
    [Localizable(false)]
    [Bindable(true)]
    [TypeConverter(typeof (StringConverter))]
    [SRCategory("CatData")]
    [SRDescription("ControlTagDescr")]
    [DefaultValue(null)]
    public object Tag
    {
      get => this.GetValue<object>(Component.TagProperty);
      set => this.SetValue<object>(Component.TagProperty, value);
    }

    /// <summary>Gets/Sets System definied tag</summary>
    [DefaultValue(null)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public object SystemTag
    {
      get => this.GetValue<object>(Component.SystemTagProperty);
      set => this.SetValue<object>(Component.SystemTagProperty, value);
    }

    /// <summary>Gets or sets the custom template.</summary>
    /// <value>The custom template.</value>
    [DefaultValue("")]
    public string CustomTemplate
    {
      get => this.GetValue<string>(Component.CustomTemplateProperty);
      set => this.SetValue<string>(Component.CustomTemplateProperty, value);
    }

    /// <summary>Gets or sets the proxy component.</summary>
    /// <value>The proxy component.</value>
    protected internal virtual ProxyComponent ProxyComponent
    {
      get => this.mobjProxyComponent;
      set => this.mobjProxyComponent = value;
    }

    /// <summary>Gets the parent of this component.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Component InternalParent
    {
      get => this.mobjInternalParent;
      set => this.mobjInternalParent = value;
    }

    /// <summary>Gets a flag indicating if the object is initializing</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected internal override bool IsSerializableObjectInitializing => this.mobjInternalParent == null;

    /// <summary>
    /// Gets the initial size of the serializable filed storage.
    /// </summary>
    /// <value>The initial size of the serializable filed storage.</value>
    protected internal override int SerializableFieldStorageInitialSize => 8;

    /// <summary>
    /// Gets or sets whether this control accepts dropping dragged content to it
    /// </summary>
    /// <value>A flag indicating if this control accepts dropping dragged content to it.</value>
    [Description("A flag indicating whether this component is drop-able.")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public virtual bool AllowDrop
    {
      get => this.GetState(Component.ComponentState.AllowDrop);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.AllowDrop, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>Gets or sets a value indicating whether [allow drop].</summary>
    /// <value>
    ///   <c>true</c> if [allow drop]; otherwise, <c>false</c>.
    /// </value>
    [Description("A flag indicating whether this component is drag-able.")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public virtual bool AllowDrag
    {
      get => this.GetState(Component.ComponentState.AllowDrag);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.AllowDrag, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [propogate drop indicator].
    /// </summary>
    /// <value>
    /// <c>true</c> if [propogate drop indicator]; otherwise, <c>false</c>.
    /// </value>
    [Description("A flag indicating which control will be illuminated when dragging over inner controls.")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public virtual bool DropIndicatorPropogation
    {
      get => this.GetState(Component.ComponentState.DropIndicatorPropogation);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.DropIndicatorPropogation, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>
    /// Gets the list of tags that client events are propogated to.
    /// </summary>
    /// <value>The client event propogated tags.</value>
    protected virtual string ClientEventsPropogationTags => string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether [exclude self from drag targets].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [exclude self from drag targets]; otherwise, <c>false</c>.
    /// </value>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [Description("An array which contains all components which should be excluded from this component drag targets.")]
    [SRCategory("CatBehavior")]
    public virtual Component[] ExcludedDragTargets
    {
      get => this.GetValue<Component[]>(Component.ExcludedDragTargetsProperty);
      set
      {
        bool flag = false;
        Component[] excludedDragTargets = this.ExcludedDragTargets;
        if (excludedDragTargets != value)
        {
          if (value == null || excludedDragTargets == null || value.Length == 0 || excludedDragTargets.Length == 0 || value.Length != excludedDragTargets.Length)
          {
            flag = true;
          }
          else
          {
            for (int index = 0; index < value.Length; ++index)
            {
              if (value[index] != excludedDragTargets[index])
              {
                flag = true;
                break;
              }
            }
          }
        }
        if (!flag)
          return;
        if (value == null || value.Length == 0)
          this.RemoveValue<Component[]>(Component.ExcludedDragTargetsProperty);
        else
          this.SetValue<Component[]>(Component.ExcludedDragTargetsProperty, value);
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>Gets the owner form.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Form Form
    {
      get
      {
        if (this is Form)
          return (Form) this;
        if (this.ProxyComponent != null && !this.ProxyComponent.IsStateComponent)
          return this.ProxyComponent.ParentForm;
        return this.InternalParent != null ? this.InternalParent.Form : (Form) null;
      }
    }

    /// <summary>Gets the empty drag targets.</summary>
    /// <value>The empty drag targets.</value>
    private static Component[] EmptyDragTargets => new Component[0];

    /// <summary>
    /// Gets or sets a value indicating whether [allow targets propagate to child controls].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [allow targets propagate to child controls]; otherwise, <c>false</c>.
    /// </value>
    [Description("A flag indicating whether this component allows its drag target to propogate to its contained components.")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool AllowDragTargetsPropagation
    {
      get => this.GetValue<bool>(Component.AllowDragTargetsPropagationProperty);
      set
      {
        if (!this.SetValue<bool>(Component.AllowDragTargetsPropagationProperty, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>Gets or sets the referenced drag targets component.</summary>
    /// <value>The referenced drag targets component.</value>
    [Description("A refference to a component which contains the drag targets which will serve this component.")]
    [SRCategory("CatBehavior")]
    [DefaultValue(null)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Component ReferencedDragTargetsComponent
    {
      get => this.GetValue<Component>(Component.ReferencedDragTargetsComponentProperty);
      set
      {
        if (!this.SetValue<Component>(Component.ReferencedDragTargetsComponentProperty, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>
    /// Defines the valid drag and drop targets when drag starts from this control.
    /// </summary>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [Description("An array which represents the component's drag targets.")]
    [SRCategory("CatBehavior")]
    [TypeConverter(typeof (DragTargetsTypeConverter))]
    public virtual Component[] DragTargets
    {
      get => this.GetValue<Component[]>(Component.DragTargetsProperty);
      set
      {
        bool flag = false;
        Component[] dragTargets = this.DragTargets;
        if (dragTargets != value)
        {
          if (value == null || dragTargets == null || value.Length == 0 || dragTargets.Length == 0 || value.Length != dragTargets.Length)
          {
            flag = true;
          }
          else
          {
            for (int index = 0; index < value.Length; ++index)
            {
              if (value[index] != dragTargets[index])
              {
                flag = true;
                break;
              }
            }
          }
        }
        if (!flag)
          return;
        if (value == null || value.Length == 0)
          this.RemoveValue<Component[]>(Component.DragTargetsProperty);
        else
          this.SetValue<Component[]>(Component.DragTargetsProperty, value);
        this.UpdateParams(AttributeType.Drag);
      }
    }

    internal ISession InternalSession => this.Session;

    /// <summary>Shoulds the serialize allow drop.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeAllowDrop() => this.AllowDrop;

    /// <summary>Shoulds the serialize drag targets.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeDragTargets() => this.ContainsValue<Component[]>(Component.DragTargetsProperty);

    /// <summary>Shoulds the serialize excluded drag targets.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeExcludedDragTargets() => this.ContainsValue<Component[]>(Component.ExcludedDragTargetsProperty);

    /// <summary>Shoulds the serialize custom template.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeCustomTemplate() => this.ContainsValue<string>(Component.CustomTemplateProperty);

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      if (this.mobjContextMenu == null)
        return;
      this.RegisterComponent((IRegisteredComponent) this.mobjContextMenu);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      if (this.mobjContextMenu == null)
        return;
      this.UnRegisterComponent((IRegisteredComponent) this.mobjContextMenu);
    }

    /// <summary>Gets or sets the context menu code.</summary>
    [Browsable(true)]
    [DefaultValue(null)]
    public virtual ContextMenu ContextMenu
    {
      get => this.mobjContextMenu;
      set
      {
        ContextMenu mobjContextMenu = this.mobjContextMenu;
        if (mobjContextMenu == value)
          return;
        EventHandler eventHandler = new EventHandler(this.DetachContextMenu);
        if (mobjContextMenu != null)
          mobjContextMenu.Disposed -= eventHandler;
        this.mobjContextMenu = value;
        if (value != null)
          value.Disposed += eventHandler;
        if (value != null && value.InternalParent == null)
          value.InternalParent = this;
        this.Update();
      }
    }

    /// <summary>Gets the inherited context menu.</summary>
    internal ContextMenu ContextMenuInherited
    {
      get
      {
        ContextMenu contextMenu = this.ContextMenu;
        if (contextMenu != null)
          return contextMenu;
        return this.InternalParent?.ContextMenuInherited;
      }
    }

    /// <summary>Gets or sets the context menu strip.</summary>
    /// <value>The context menu strip.</value>
    [SRDescription("ControlContextMenuDescr")]
    [DefaultValue(null)]
    [SRCategory("CatBehavior")]
    [Browsable(true)]
    public virtual ContextMenuStrip ContextMenuStrip
    {
      get => this.mobjContextMenuStrip;
      set
      {
        ContextMenuStrip contextMenuStrip = this.mobjContextMenuStrip;
        if (contextMenuStrip == value)
          return;
        EventHandler eventHandler = new EventHandler(this.DetachContextMenuStrip);
        if (contextMenuStrip != null)
          contextMenuStrip.Disposed -= eventHandler;
        this.mobjContextMenuStrip = value;
        if (value != null)
          value.Disposed += eventHandler;
        this.OnContextMenuStripChanged(EventArgs.Empty);
        this.Update();
      }
    }

    /// <summary>Gets the inherited context menu strip.</summary>
    internal ContextMenuStrip ContextMenuStripInherited
    {
      get
      {
        ContextMenuStrip contextMenuStrip = this.ContextMenuStrip;
        if (contextMenuStrip != null)
          return contextMenuStrip;
        return this.InternalParent?.ContextMenuStripInherited;
      }
    }

    /// <summary>Gets the current application context.</summary>
    /// <value></value>
    public override IContext Context
    {
      get
      {
        Component internalParent = this.InternalParent;
        return internalParent != null ? internalParent.Context : VWGContext.Current;
      }
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    protected WinFormsCompatibility WinFormsCompatibility
    {
      get
      {
        if (this.mobjWinFormsCompatibility == null)
        {
          this.mobjWinFormsCompatibility = this.GetWinFormsCompatibility();
          this.mobjWinFormsCompatibility.OptionValueChanged += new WinFormsCompatibility.WinFormsCompatibilityEventHandler(this.WinFormsCompatibilityOptionValueChanged);
        }
        return this.mobjWinFormsCompatibility;
      }
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 4;

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjInternalParent = (Component) objReader.ReadObject();
      this.mintComponentState = objReader.ReadInt32();
      this.mobjContextMenu = (ContextMenu) objReader.ReadObject();
      this.mobjContextMenuStrip = (ContextMenuStrip) objReader.ReadObject();
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteObject((object) this.mobjInternalParent);
      objWriter.WriteInt32(this.mintComponentState);
      objWriter.WriteObject((object) this.mobjContextMenu);
      objWriter.WriteObject((object) this.mobjContextMenuStrip);
    }

    /// <summary>Provides support for adding extended attributes</summary>
    [Serializable]
    private sealed class AttributesWrapper : SerializableObject, IEnumerable
    {
      /// <summary>The internal attribute collection</summary>
      [NonSerialized]
      private Dictionary<string, string> mobjAttributes;
      /// <summary>Indicates last render identifiers</summary>
      [NonSerialized]
      private long mlngLastModified;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Component.AttributesWrapper" /> class.
      /// </summary>
      public AttributesWrapper() => this.mobjAttributes = new Dictionary<string, string>();

      /// <summary>
      /// The size of the initiale serialization data array which is the optmized serialization graph.
      /// </summary>
      /// <value></value>
      /// <remarks>
      /// This value should be the actual size needed so that re-allocations and truncating will not be required.
      /// </remarks>
      protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 2;

      /// <summary>
      /// Called when serializable object is deserialized and we need to extract the optimized
      /// object graph to the working graph.
      /// </summary>
      /// <param name="objReader">The optimized object graph reader.</param>
      protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
      {
        base.OnSerializableObjectDeserializing(objReader);
        this.mlngLastModified = objReader.ReadInt64();
        this.mobjAttributes = objReader.ReadDictionary<string, string>();
      }

      /// <summary>
      /// Called before serializable object is serialized to optimize the application object graph.
      /// </summary>
      /// <param name="objWriter">The optimized object graph writer.</param>
      protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
      {
        base.OnSerializableObjectSerializing(objWriter);
        objWriter.WriteInt64(this.mlngLastModified);
        objWriter.WriteDictionary<string, string>(this.mobjAttributes);
      }

      /// <summary>
      /// Gets or sets the <see cref="T:System.String" /> with the specified name.
      /// </summary>
      /// <value></value>
      public string this[string strName]
      {
        get => this.mobjAttributes.ContainsKey(strName) ? this.mobjAttributes[strName] : (string) null;
        set
        {
          this.mlngLastModified = this.GetCurrentTicks();
          if (value != null)
          {
            this.mobjAttributes[strName] = value;
          }
          else
          {
            if (!this.mobjAttributes.ContainsKey(strName))
              return;
            this.mobjAttributes.Remove(strName);
          }
        }
      }

      public void RenderAttributes(IAttributeWriter attributeWriter, long lngRequestID)
      {
        if (this.mlngLastModified <= lngRequestID)
          return;
        foreach (string str in (IEnumerable) this)
          attributeWriter.WriteAttributeString(str, this[str]);
      }

      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.mobjAttributes.Keys.GetEnumerator();
    }

    /// <summary>Represent a swipe event handler.</summary>
    public delegate void SwipeEventHandler(Component objSource, SwipeDirection enmSwipeDirection);

    [Flags]
    internal enum ComponentState
    {
      /// <summary>The visible state flag</summary>
      Visible = 1,
      /// <summary>The enabled state flag</summary>
      Enabled = 2,
      /// <summary>The selected flag</summary>
      Selected = 8,
      /// <summary>The checked flag</summary>
      Checked = 16, // 0x00000010
      /// <summary>The initializing flag</summary>
      Initializing = 32, // 0x00000020
      /// <summary>the allow drop flag</summary>
      AllowDrop = 128, // 0x00000080
      /// <summary>The loaded flag</summary>
      Loaded = 256, // 0x00000100
      /// <summary>The read only flag</summary>
      ReadOnly = 512, // 0x00000200
      /// <summary>The animation enabled flag</summary>
      AnimationEnabled = 2048, // 0x00000800
      /// <summary>The click once flag</summary>
      ClickOnce = 4096, // 0x00001000
      /// <summary>The auto allipsis flag</summary>
      AutoEllipsis = 8192, // 0x00002000
      /// <summary>The allow drag flag</summary>
      AllowDrag = 16384, // 0x00004000
      /// <summary>The propogation of drop target indicator</summary>
      DropIndicatorPropogation = 32768, // 0x00008000
    }
  }
}
