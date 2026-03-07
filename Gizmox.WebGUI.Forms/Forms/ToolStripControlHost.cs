// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripControlHost
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Hosts custom controls or Windows Forms controls.</summary>
  [Skin(typeof (ToolStripControlHostSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ProxyComponent(typeof (ProxyToolStripControlHost))]
  [Serializable]
  public class ToolStripControlHost : ToolStripItem
  {
    private static readonly SerializableProperty mobjControlProperty = SerializableProperty.Register(nameof (mobjControl), typeof (Control), typeof (ToolStripControlHost));
    private static readonly SerializableProperty menmControlAlignProperty = SerializableProperty.Register(nameof (menmControlAlign), typeof (ContentAlignment), typeof (ToolStripControlHost));
    private static readonly SerializableEvent DisplayStyleChangedEvent = SerializableEvent.Register("DisplayStyleChanged", typeof (EventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent EnterEvent = SerializableEvent.Register("Enter", typeof (EventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent GotFocusEvent = SerializableEvent.Register("GotFocus", typeof (EventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent KeyDownEvent = SerializableEvent.Register("KeyDown", typeof (KeyEventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent KeyPressEvent = SerializableEvent.Register("KeyPress", typeof (KeyPressEventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent KeyUpEvent = SerializableEvent.Register("KeyUp", typeof (KeyEventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent LeaveEvent = SerializableEvent.Register("Leave", typeof (EventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent LostFocusEvent = SerializableEvent.Register("LostFocus", typeof (EventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent ValidatedEvent = SerializableEvent.Register("Validated", typeof (EventHandler), typeof (ToolStripControlHost));
    private static readonly SerializableEvent ValidatingEvent = SerializableEvent.Register("Validating", typeof (EventHandler), typeof (ToolStripControlHost));
    private int intSuspendSyncSizeCount;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class that hosts the specified control.</summary>
    /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> hosted by this <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class. </param>
    /// <exception cref="T:System.ArgumentNullException">The control referred to by the c parameter is null.</exception>
    public ToolStripControlHost(Control objControl)
    {
      this.menmControlAlign = ContentAlignment.MiddleCenter;
      this.mobjControl = objControl != null ? objControl : throw new ArgumentNullException(nameof (objControl), "ControlCannotBeNull");
      this.SyncControlParent();
      objControl.Visible = true;
      this.SetBounds(objControl.Bounds);
      Rectangle bounds = this.Bounds;
      objControl.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
      this.OnSubscribeControlEvents(objControl);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class that hosts the specified control and that has the specified name.</summary>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see>.</param>
    /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> hosted by this <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class.</param>
    public ToolStripControlHost(Control objControl, string name)
      : this(objControl)
    {
      this.Name = name;
    }

    /// <summary>Pres the render tool strip item.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal override void PreRenderToolStripItem(IContext objContext, long lngRequestID)
    {
      base.PreRenderToolStripItem(objContext, lngRequestID);
      if (this.Control == null)
        return;
      this.Control.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Posts the render tool strip item.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal override void PostRenderToolStripItem(IContext objContext, long lngRequestID)
    {
      base.PostRenderToolStripItem(objContext, lngRequestID);
      if (this.Control == null)
        return;
      this.Control.PostRenderControl(objContext, lngRequestID);
    }

    /// <summary>Gets the preferred size.</summary>
    /// <param name="objConstrainingSize"></param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objConstrainingSize)
    {
      if (this.Control != null)
      {
        Size size = this.Control.Size;
        Size preferredSize = this.Control.GetPreferredSize(size);
        if (preferredSize == Size.Empty)
          preferredSize = size;
        if (preferredSize != Size.Empty)
        {
          if (SkinFactory.GetSkin((ISkinable) this, typeof (ToolStripMenuItemSkin)) is ToolStripMenuItemSkin skin)
          {
            BorderWidth borderWidth = skin.MenuItemStyle.Border.Style != BorderStyle.None ? skin.MenuItemStyle.Border.Width : BorderWidth.Empty;
            preferredSize.Width += borderWidth.Left + borderWidth.Right;
            preferredSize.Height += borderWidth.Top + borderWidth.Bottom;
          }
          return preferredSize;
        }
      }
      return this.DefaultSize;
    }

    /// <summary>Renders the tool strip item's controls.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected override void RenderToolStripItemControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.RenderToolStripItemControls(objContext, objWriter, lngRequestID);
      this.Control?.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Bounds"></see> property changes.
    /// </summary>
    protected override void OnBoundsChanged()
    {
      if (this.Control == null)
        return;
      this.SuspendSizeSync();
      IArrangedElement control = (IArrangedElement) this.Control;
      if (control == null)
        return;
      Rectangle objBounds1 = LayoutUtils.Align(LayoutUtils.DeflateRect(this.Bounds, this.Padding).Size, this.Bounds, this.ControlAlign);
      control.SetBounds(objBounds1, BoundsSpecified.None);
      if (objBounds1 != this.Control.Bounds)
      {
        Rectangle objBounds2 = LayoutUtils.Align(this.Control.Size, this.Bounds, this.ControlAlign);
        control.SetBounds(objBounds2, BoundsSpecified.None);
      }
      this.ResumeSizeSync();
      this.Control.Update();
    }

    /// <summary>Register a component.</summary>
    /// <param name="objComponent">Component.</param>
    protected override void RegisterComponent(IRegisteredComponent objComponent)
    {
      base.RegisterComponent(objComponent);
      if (objComponent != this)
        return;
      Control control = this.Control;
      if (control == null)
        return;
      base.RegisterComponent((IRegisteredComponent) control);
    }

    /// <summary>Unregister a component.</summary>
    /// <param name="objComponent">Component.</param>
    protected override void UnRegisterComponent(IRegisteredComponent objComponent)
    {
      base.UnRegisterComponent(objComponent);
      if (objComponent != this)
        return;
      Control control = this.Control;
      if (control == null)
        return;
      base.UnRegisterComponent((IRegisteredComponent) control);
    }

    private Control.ControlCollection GetControlCollection(ToolStrip objToolStrip) => objToolStrip?.Controls;

    private void SyncControlParent() => this.GetControlCollection(this.ParentInternal)?.Add(this.Control);

    /// <summary>Gives the focus to a control.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void Focus() => this.Control.Focus();

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Enter"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnEnter(EventArgs e)
    {
      EventHandler enterHandler = this.EnterHandler;
      if (enterHandler == null)
        return;
      enterHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.GotFocus"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnGotFocus(EventArgs e)
    {
      EventHandler gotFocusHandler = this.GotFocusHandler;
      if (gotFocusHandler == null)
        return;
      gotFocusHandler((object) this, e);
    }

    /// <summary>Synchronizes the resizing of the control host with the resizing of the hosted control.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnHostedControlResize(EventArgs e) => this.Size = this.Control.Size;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyDown"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
    protected virtual void OnKeyDown(KeyEventArgs e)
    {
      KeyEventHandler keyDownHandler = this.KeyDownHandler;
      if (keyDownHandler == null)
        return;
      keyDownHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyPress"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data.</param>
    protected virtual void OnKeyPress(KeyPressEventArgs e)
    {
      KeyPressEventHandler keyPressHandler = this.KeyPressHandler;
      if (keyPressHandler == null)
        return;
      keyPressHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyUp"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
    protected virtual void OnKeyUp(KeyEventArgs e)
    {
      KeyEventHandler keyUpHandler = this.KeyUpHandler;
      if (keyUpHandler == null)
        return;
      keyUpHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Leave"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnLeave(EventArgs e)
    {
      EventHandler leaveHandler = this.LeaveHandler;
      if (leaveHandler == null)
        return;
      leaveHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.LostFocus"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnLostFocus(EventArgs e)
    {
      EventHandler lostFocusHandler = this.LostFocusHandler;
      if (lostFocusHandler == null)
        return;
      lostFocusHandler((object) this, e);
    }

    private void HandleClick(object sender, EventArgs e) => this.OnClick(e);

    private void HandleBackColorChanged(object sender, EventArgs e) => this.OnBackColorChanged(e);

    private void HandleDoubleClick(object sender, EventArgs e) => this.OnDoubleClick(e);

    private void HandleDragDrop(object sender, DragEventArgs e) => this.OnDragDrop(e);

    private void HandleEnabledChanged(object sender, EventArgs e) => this.OnEnabledChanged(e);

    private void HandleForeColorChanged(object sender, EventArgs e) => this.OnForeColorChanged(e);

    private void HandleGotFocus(object sender, EventArgs e) => this.OnGotFocus(e);

    private void HandleLeave(object sender, EventArgs e) => this.OnLeave(e);

    private void HandleEnter(object sender, EventArgs e) => this.OnEnter(e);

    private void HandleLocationChanged(object sender, EventArgs e) => this.OnLocationChanged(e);

    private void HandleLostFocus(object sender, EventArgs e) => this.OnLostFocus(e);

    private void HandleKeyDown(object sender, KeyEventArgs e) => this.OnKeyDown(e);

    private void HandleKeyPress(object sender, KeyPressEventArgs e) => this.OnKeyPress(e);

    private void HandleKeyUp(object sender, KeyEventArgs e) => this.OnKeyUp(e);

    private void HandleMouseDown(object sender, MouseEventArgs e) => this.OnMouseDown(e);

    private void HandleMouseUp(object sender, MouseEventArgs e) => this.OnMouseUp(e);

    private void HandleResize(object sender, EventArgs e) => this.OnHostedControlResize(e);

    private void HandleTextChanged(object sender, EventArgs e) => this.OnTextChanged(e);

    private void HandleControlVisibleChanged(object sender, EventArgs e)
    {
      if (((IArrangedElement) this).ParticipatesInLayout == ((IArrangedElement) this.Control).ParticipatesInLayout)
        return;
      this.Visible = this.Control.Visible;
    }

    private void HandleValidated(object sender, EventArgs e) => this.OnValidated(e);

    private void HandleValidating(object sender, CancelEventArgs e) => this.OnValidating(e);

    /// <summary>Subscribes events from the hosted control.</summary>
    /// <param name="objControl">The control from which to subscribe events.</param>
    protected virtual void OnSubscribeControlEvents(Control objControl)
    {
      if (objControl == null)
        return;
      objControl.BackColorChanged += new EventHandler(this.HandleBackColorChanged);
      objControl.DragDrop += new DragEventHandler(this.HandleDragDrop);
      objControl.EnabledChanged += new EventHandler(this.HandleEnabledChanged);
      objControl.ForeColorChanged += new EventHandler(this.HandleForeColorChanged);
      objControl.LocationChanged += new EventHandler(this.HandleLocationChanged);
      objControl.Resize += new EventHandler(this.HandleResize);
      objControl.VisibleChanged += new EventHandler(this.HandleControlVisibleChanged);
    }

    /// <summary>Unsubscribes events from the hosted control.</summary>
    /// <param name="objControl">The control from which to unsubscribe events.</param>
    protected virtual void OnUnsubscribeControlEvents(Control objControl)
    {
      if (objControl == null)
        return;
      objControl.BackColorChanged -= new EventHandler(this.HandleBackColorChanged);
      objControl.DragDrop -= new DragEventHandler(this.HandleDragDrop);
      objControl.EnabledChanged -= new EventHandler(this.HandleEnabledChanged);
      objControl.ForeColorChanged -= new EventHandler(this.HandleForeColorChanged);
      objControl.LocationChanged -= new EventHandler(this.HandleLocationChanged);
      objControl.Resize -= new EventHandler(this.HandleResize);
      objControl.VisibleChanged -= new EventHandler(this.HandleControlVisibleChanged);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Validated"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnValidated(EventArgs e)
    {
      EventHandler validatedHandler = this.ValidatedHandler;
      if (validatedHandler == null)
        return;
      validatedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Validating"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
    protected virtual void OnValidating(CancelEventArgs e)
    {
      EventHandler validatingHandler = this.ValidatingHandler;
      if (validatingHandler == null)
        return;
      validatingHandler((object) this, (EventArgs) e);
    }

    /// <summary>Suspends the size sync.</summary>
    private void SuspendSizeSync() => ++this.intSuspendSyncSizeCount;

    /// <summary>Resumes the size sync.</summary>
    private void ResumeSizeSync() => --this.intSuspendSyncSizeCount;

    /// <summary>Shoulds the color of the serialize back.</summary>
    /// <returns></returns>
    internal override bool ShouldSerializeBackColor() => this.Control.ShouldSerializeBackColor();

    /// <summary>Shoulds the color of the serialize fore.</summary>
    /// <returns></returns>
    internal override bool ShouldSerializeForeColor() => this.Control.ShouldSerializeForeColor();

    /// <summary>Shoulds the serialize right to left.</summary>
    /// <returns></returns>
    internal override bool ShouldSerializeRightToLeft() => this.Control.ShouldSerializeRightToLeft();

    /// <summary>Shoulds the serialize font.</summary>
    /// <returns></returns>
    internal override bool ShouldSerializeFont() => this.Control.ShouldSerializeFont();

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) new List<Control>()
    {
      this.Control
    };

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.
    /// </summary>
    /// <param name="oldParent">The original parent of the item.</param>
    /// <param name="newParent">The new parent of the item.</param>
    protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
    {
      if (oldParent != null && this.Owner == null && newParent == null && this.Control != null)
        this.GetControlCollection(this.Control.ParentInternal as ToolStrip)?.Remove(this.Control);
      else
        this.SyncControlParent();
      base.OnParentChanged(oldParent, newParent);
    }

    /// <summary>This event is not relevant to this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler DisplayStyleChanged
    {
      add => this.AddCriticalHandler(ToolStripControlHost.DisplayStyleChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripControlHost.DisplayStyleChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the DisplayStyleChanged handler.</summary>
    /// <value>The DisplayStyleChanged handler.</value>
    private EventHandler DisplayStyleChangedHandler => (EventHandler) this.GetHandler(ToolStripControlHost.DisplayStyleChangedEvent);

    /// <summary>Occurs when the hosted control is entered.</summary>
    [SRDescription("ControlOnEnterDescr")]
    [SRCategory("CatFocus")]
    public event EventHandler Enter
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.EnterEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.Enter += new EventHandler(this.HandleEnter);
        }
        this.AddCriticalHandler(ToolStripControlHost.EnterEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.EnterEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.EnterEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.Enter -= new EventHandler(this.HandleEnter);
      }
    }

    /// <summary>Gets the Enter handler.</summary>
    /// <value>The Enter handler.</value>
    private EventHandler EnterHandler => (EventHandler) this.GetHandler(ToolStripControlHost.EnterEvent);

    /// <summary>Occurs when the hosted control receives focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatFocus")]
    [SRDescription("ToolStripItemOnGotFocusDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public event EventHandler GotFocus
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.GotFocusEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.GotFocus += new EventHandler(this.HandleGotFocus);
        }
        this.AddCriticalHandler(ToolStripControlHost.GotFocusEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.GotFocusEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.GotFocusEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.GotFocus -= new EventHandler(this.HandleGotFocus);
      }
    }

    /// <summary>Gets the GotFocus handler.</summary>
    /// <value>The GotFocus handler.</value>
    private EventHandler GotFocusHandler => (EventHandler) this.GetHandler(ToolStripControlHost.GotFocusEvent);

    /// <summary>Occurs when a key is pressed and held down while the hosted control has focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ControlOnKeyDownDescr")]
    [SRCategory("CatKey")]
    public event KeyEventHandler KeyDown
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.KeyDownEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.KeyDown += new KeyEventHandler(this.HandleKeyDown);
        }
        this.AddCriticalHandler(ToolStripControlHost.KeyDownEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.KeyDownEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.KeyDownEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.KeyDown -= new KeyEventHandler(this.HandleKeyDown);
      }
    }

    /// <summary>Gets the KeyDown handler.</summary>
    /// <value>The KeyDown handler.</value>
    private KeyEventHandler KeyDownHandler => this.GetHandler(ToolStripControlHost.KeyDownEvent) as KeyEventHandler;

    /// <summary>Occurs when a key is pressed while the hosted control has focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatKey")]
    [SRDescription("ControlOnKeyPressDescr")]
    public event KeyPressEventHandler KeyPress
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.KeyPressEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.KeyPress += new KeyPressEventHandler(this.HandleKeyPress);
        }
        this.AddCriticalHandler(ToolStripControlHost.KeyPressEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.KeyPressEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.KeyPressEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.KeyPress -= new KeyPressEventHandler(this.HandleKeyPress);
      }
    }

    /// <summary>Gets the KeyPress handler.</summary>
    /// <value>The KeyPress handler.</value>
    private KeyPressEventHandler KeyPressHandler => this.GetHandler(ToolStripControlHost.KeyPressEvent) as KeyPressEventHandler;

    /// <summary>Gets the key up handler.</summary>
    private KeyEventHandler KeyUpHandler => this.GetHandler(ToolStripControlHost.KeyUpEvent) as KeyEventHandler;

    /// <summary>Occurs when a key is released while the hosted control has focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatKey")]
    [SRDescription("ControlOnKeyUpDescr")]
    public event KeyEventHandler KeyUp
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.KeyUpEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.KeyUp += new KeyEventHandler(this.HandleKeyUp);
        }
        this.AddCriticalHandler(ToolStripControlHost.KeyUpEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.KeyUpEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.KeyUpEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.KeyUp -= new KeyEventHandler(this.HandleKeyUp);
      }
    }

    /// <summary>Occurs when the input focus leaves the hosted control.</summary>
    [SRCategory("CatFocus")]
    [SRDescription("ControlOnLeaveDescr")]
    public event EventHandler Leave
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.LeaveEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.Leave += new EventHandler(this.HandleLeave);
        }
        this.AddCriticalHandler(ToolStripControlHost.LeaveEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.LeaveEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.LeaveEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.Leave -= new EventHandler(this.HandleLeave);
      }
    }

    /// <summary>Gets the Leave handler.</summary>
    /// <value>The Leave handler.</value>
    private EventHandler LeaveHandler => (EventHandler) this.GetHandler(ToolStripControlHost.LeaveEvent);

    /// <summary>Occurs when the hosted control loses focus.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolStripItemOnLostFocusDescr")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRCategory("CatFocus")]
    public event EventHandler LostFocus
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.LostFocusEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.LostFocus += new EventHandler(this.HandleLostFocus);
        }
        this.AddCriticalHandler(ToolStripControlHost.LostFocusEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.LostFocusEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.LostFocusEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.LostFocus -= new EventHandler(this.HandleLostFocus);
      }
    }

    /// <summary>Gets the LostFocus handler.</summary>
    /// <value>The LostFocus handler.</value>
    private EventHandler LostFocusHandler => (EventHandler) this.GetHandler(ToolStripControlHost.LostFocusEvent);

    /// <summary>Occurs after the hosted control has been successfully validated.</summary>
    [SRDescription("ControlOnValidatedDescr")]
    [SRCategory("CatFocus")]
    public event EventHandler Validated
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.ValidatedEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.Validated += new EventHandler(this.HandleValidated);
        }
        this.AddCriticalHandler(ToolStripControlHost.ValidatedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.ValidatedEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.ValidatedEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.Validated -= new EventHandler(this.HandleValidated);
      }
    }

    /// <summary>Gets the Validated handler.</summary>
    /// <value>The Validated handler.</value>
    private EventHandler ValidatedHandler => (EventHandler) this.GetHandler(ToolStripControlHost.ValidatedEvent);

    /// <summary>Occurs while the hosted control is validating.</summary>
    [SRCategory("CatFocus")]
    [SRDescription("ControlOnValidatingDescr")]
    public event CancelEventHandler Validating
    {
      add
      {
        if (!this.HasHandler(ToolStripControlHost.ValidatingEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.Validating += new CancelEventHandler(this.HandleValidating);
        }
        this.AddCriticalHandler(ToolStripControlHost.ValidatingEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripControlHost.ValidatingEvent, (Delegate) value);
        if (this.HasHandler(ToolStripControlHost.ValidatingEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.Validating -= new CancelEventHandler(this.HandleValidating);
      }
    }

    /// <summary>Gets the Validating handler.</summary>
    /// <value>The Validating handler.</value>
    private EventHandler ValidatingHandler => (EventHandler) this.GetHandler(ToolStripControlHost.ValidatingEvent);

    /// <summary>
    /// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.
    /// </summary>
    public override event EventHandler Click
    {
      add
      {
        if (!this.HasHandler(ToolStripItem.ClickEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.Click += new EventHandler(this.HandleClick);
        }
        base.Click += value;
      }
      remove
      {
        base.Click -= value;
        if (this.HasHandler(ToolStripItem.ClickEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.Click -= new EventHandler(this.HandleClick);
      }
    }

    /// <summary>
    /// Occurs when the item is double-clicked with the mouse.
    /// </summary>
    public override event EventHandler DoubleClick
    {
      add
      {
        if (!this.HasHandler(ToolStripItem.DoubleClickEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.DoubleClick += new EventHandler(this.HandleDoubleClick);
        }
        base.DoubleClick += value;
      }
      remove
      {
        base.DoubleClick -= value;
        if (this.HasHandler(ToolStripItem.DoubleClickEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.DoubleClick -= new EventHandler(this.HandleDoubleClick);
      }
    }

    /// <summary>
    /// Occurs when the mouse pointer is over the item and a mouse button is pressed.
    /// </summary>
    public override event MouseEventHandler MouseDown
    {
      add
      {
        if (!this.HasHandler(ToolStripItem.MouseDownEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.MouseDown += new MouseEventHandler(this.HandleMouseDown);
        }
        base.MouseDown += value;
      }
      remove
      {
        base.MouseDown -= value;
        if (this.HasHandler(ToolStripItem.MouseDownEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.MouseDown -= new MouseEventHandler(this.HandleMouseDown);
      }
    }

    /// <summary>
    /// Occurs when the mouse pointer is over the item and a mouse button is released.
    /// </summary>
    public override event MouseEventHandler MouseUp
    {
      add
      {
        if (!this.HasHandler(ToolStripItem.MouseUpEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.MouseUp += new MouseEventHandler(this.HandleMouseUp);
        }
        base.MouseUp += value;
      }
      remove
      {
        base.MouseUp -= value;
        if (this.HasHandler(ToolStripItem.MouseUpEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.MouseUp -= new MouseEventHandler(this.HandleMouseUp);
      }
    }

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property changes.
    /// </summary>
    public override event EventHandler TextChanged
    {
      add
      {
        if (!this.HasHandler(ToolStripItem.TextChangedEvent))
        {
          Control control = this.Control;
          if (control != null)
            control.TextChanged += new EventHandler(this.HandleTextChanged);
        }
        base.TextChanged += value;
      }
      remove
      {
        base.TextChanged -= value;
        if (this.HasHandler(ToolStripItem.TextChangedEvent))
          return;
        Control control = this.Control;
        if (control == null)
          return;
        control.TextChanged -= new EventHandler(this.HandleTextChanged);
      }
    }

    private Control mobjControl
    {
      get => this.GetValue<Control>(ToolStripControlHost.mobjControlProperty, (Control) null);
      set => this.SetValue<Control>(ToolStripControlHost.mobjControlProperty, value);
    }

    private ContentAlignment menmControlAlign
    {
      get => this.GetValue<ContentAlignment>(ToolStripControlHost.menmControlAlignProperty);
      set => this.SetValue<ContentAlignment>(ToolStripControlHost.menmControlAlignProperty, value);
    }

    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override Color BackColor
    {
      get => this.Control.BackColor;
      set => this.Control.BackColor = value;
    }

    /// <summary>Gets or sets the background image displayed in the control.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    [SRDescription("ToolStripItemImageDescr")]
    [Localizable(true)]
    public override ResourceHandle BackgroundImage
    {
      get => this.Control.BackgroundImage;
      set => this.Control.BackgroundImage = value;
    }

    /// <summary>Gets or sets the background image layout as defined in the ImageLayout enumeration.</summary>
    /// <returns>One of the values of <see cref="T:System.Windows.Forms.ImageLayout"></see>:<see cref="F:System.Windows.Forms.ImageLayout.Center"></see><see cref="F:System.Windows.Forms.ImageLayout.None"></see><see cref="F:System.Windows.Forms.ImageLayout.Stretch"></see><see cref="F:System.Windows.Forms.ImageLayout.Tile"></see> (default)<see cref="F:System.Windows.Forms.ImageLayout.Zoom"></see></returns>
    [SRDescription("ControlBackgroundImageLayoutDescr")]
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [DefaultValue(ImageLayout.Tile)]
    public override ImageLayout BackgroundImageLayout
    {
      get => this.Control.BackgroundImageLayout;
      set => this.Control.BackgroundImageLayout = value;
    }

    /// <summary>Gets a value indicating whether the control can be selected.</summary>
    /// <returns>true if the control can be selected; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public override bool CanSelect
    {
      get
      {
        if (this.mobjControl == null)
          return false;
        return this.DesignMode || this.Control.CanSelect;
      }
    }

    /// <summary>Gets or sets a value indicating whether the hosted control causes and raises validation events on other controls when the hosted control receives focus.</summary>
    /// <returns>true if the hosted control causes and raises validation events on other controls when the hosted control receives focus; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    [SRDescription("ControlCausesValidationDescr")]
    [SRCategory("CatFocus")]
    public bool CausesValidation
    {
      get => this.Control.CausesValidation;
      set => this.Control.CausesValidation = value;
    }

    /// <summary>Gets the <see cref="T:System.Windows.Forms.Control"></see> that this <see cref="T:System.Windows.Forms.ToolStripControlHost"></see> is hosting.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.Control"></see> that this <see cref="T:System.Windows.Forms.ToolStripControlHost"></see> is hosting.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Control Control => this.mobjControl;

    /// <summary>Gets or sets the alignment of the control on the form.</summary>
    /// <returns>One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleCenter"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:System.Windows.Forms.ToolStripControlHost.ControlAlign"></see> property is set to a value that is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [DefaultValue(ContentAlignment.MiddleCenter)]
    public ContentAlignment ControlAlign
    {
      get => this.menmControlAlign;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 1, 1024))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ContentAlignment));
        if (this.menmControlAlign == value)
          return;
        this.menmControlAlign = value;
        this.OnBoundsChanged();
      }
    }

    /// <summary>Gets the default size of the control.</summary>
    /// <returns>The default <see cref="T:System.Drawing.Size"></see> of the control.</returns>
    protected override Size DefaultSize => this.Control != null ? this.Control.Size : base.DefaultSize;

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripItemDisplayStyle"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new ToolStripItemDisplayStyle DisplayStyle
    {
      get => base.DisplayStyle;
      set => base.DisplayStyle = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if double clicking is enabled; otherwise, false. </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(false)]
    public new bool DoubleClickEnabled
    {
      get => base.DoubleClickEnabled;
      set => base.DoubleClickEnabled = value;
    }

    /// <summary>Gets or sets a value indicating whether the parent control of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is enabled.</summary>
    /// <returns>true if the parent control of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is enabled; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override bool Enabled
    {
      get => this.Control.Enabled;
      set => this.mblnEnabled = this.Control.Enabled = value;
    }

    /// <summary>Gets a value indicating whether the control has input focus.</summary>
    /// <returns>true if the control has input focus; otherwise, false. </returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual bool Focused => this.Control.Focused;

    /// <summary>Gets or sets the font to be used on the hosted control.</summary>
    /// <returns>The <see cref="T:System.Drawing.Font"></see> for the hosted control.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override Font Font
    {
      get => this.Control.Font;
      set => this.Control.Font = value;
    }

    /// <summary>Gets or sets the foreground color of the hosted control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> representing the foreground color of the hosted control.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override Color ForeColor
    {
      get => this.Control.ForeColor;
      set => this.Control.ForeColor = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override ResourceHandle Image
    {
      get => base.Image;
      set => base.Image = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.ContentAlignment"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ContentAlignment ImageAlign
    {
      get => base.ImageAlign;
      set => base.ImageAlign = value;
    }

    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override RightToLeft RightToLeft
    {
      get => this.mobjControl != null ? this.mobjControl.RightToLeft : base.RightToLeft;
      set
      {
        if (this.mobjControl == null)
          return;
        this.mobjControl.RightToLeft = value;
      }
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if the image is mirrored; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public new bool RightToLeftAutoMirrorImage
    {
      get => base.RightToLeftAutoMirrorImage;
      set => base.RightToLeftAutoMirrorImage = value;
    }

    /// <summary>Gets or sets the size of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</summary>
    /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
    public override Size Size
    {
      get => base.Size;
      set
      {
        if (this.mobjControl != null)
          this.mobjControl.Size = value;
        base.Size = value;
      }
    }

    /// <summary>Gets or sets the text to be displayed on the hosted control.</summary>
    /// <returns>A <see cref="T:System.String"></see> representing the text.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    public override string Text
    {
      get => this.Control.Text;
      set => this.Control.Text = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.VisualStyles.ContentAlignment"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ContentAlignment TextAlign
    {
      get => base.TextAlign;
      set => base.TextAlign = value;
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 5;

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripTextDirection"></see>.</returns>
    [DefaultValue(ToolStripTextDirection.Horizontal)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ToolStripTextDirection TextDirection
    {
      get => base.TextDirection;
      set => base.TextDirection = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.TextImageRelation"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new TextImageRelation TextImageRelation
    {
      get => base.TextImageRelation;
      set => base.TextImageRelation = value;
    }
  }
}
