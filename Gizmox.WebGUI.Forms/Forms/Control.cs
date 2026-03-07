// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Control
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>The base class for all positioned GUI elements</summary>
  [DefaultEvent("Click")]
  [ToolboxItem(false)]
  [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ControlSkin))]
  [ProxyComponent(typeof (ProxyControl))]
  [Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar(typeof (Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar))]
  [Serializable]
  public class Control : 
    Component,
    IControl,
    IRegisteredComponent,
    IEventHandler,
    IWin32Window,
    IBindableComponent,
    IComponent,
    IDisposable,
    IArrangedElement,
    IRenderableComponent,
    IObservableLayoutItem,
    ISkinable
  {
    /// <summary>
    /// Provides a property reference to DataBindings property.
    /// </summary>
    private static SerializableProperty DataBindingsProperty = SerializableProperty.Register(nameof (DataBindings), typeof (ControlBindingsCollection), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to BindingContext property.
    /// </summary>
    private static SerializableProperty BindingContextProperty = SerializableProperty.Register(nameof (BindingContext), typeof (BindingContext), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to BorderStyle property.
    /// </summary>
    private static SerializableProperty BorderStyleProperty = SerializableProperty.Register(nameof (BorderStyle), typeof (BorderStyle), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>
    /// Provides a property reference to BorderColor property.
    /// </summary>
    private static SerializableProperty BorderColorProperty = SerializableProperty.Register(nameof (BorderColor), typeof (BorderColor), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>
    /// Provides a property reference to ErrorMessage property.
    /// </summary>
    private static SerializableProperty ErrorMessageProperty = SerializableProperty.Register(nameof (ErrorMessage), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to ErrorIcon property.</summary>
    private static SerializableProperty ErrorIconProperty = SerializableProperty.Register(nameof (ErrorIcon), typeof (ResourceHandle), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ErrorIconPadding property.
    /// </summary>
    private static SerializableProperty ErrorIconPaddingProperty = SerializableProperty.Register(nameof (ErrorIconPadding), typeof (int), typeof (Control), new SerializablePropertyMetadata((object) 1));
    /// <summary>
    /// Provides a property reference to ErrorIconAlignment property.
    /// </summary>
    private static SerializableProperty ErrorIconAlignmentProperty = SerializableProperty.Register(nameof (ErrorIconAlignment), typeof (ErrorIconAlignment), typeof (Control), new SerializablePropertyMetadata((object) ErrorIconAlignment.TopRight));
    /// <summary>Provides a property reference to LayoutInfo property.</summary>
    internal static SerializableProperty LayoutInfoProperty = SerializableProperty.Register("LayoutInfo", typeof (TableLayout.LayoutInfo), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ContainerInfo property.
    /// </summary>
    internal static SerializableProperty ContainerInfoProperty = SerializableProperty.Register("ContainerInfo", typeof (TableLayout.ContainerInfo), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to BorderWidth property.
    /// </summary>
    private static SerializableProperty BorderWidthProperty = SerializableProperty.Register(nameof (BorderWidth), typeof (BorderWidth), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Provides a property reference to Cursor property.</summary>
    private static SerializableProperty CursorProperty = SerializableProperty.Register(nameof (Cursor), typeof (Cursor), typeof (Control), new SerializablePropertyMetadata((object) Cursors.Default));
    /// <summary>
    /// Provides a property reference to CustomStyle property.
    /// </summary>
    private static SerializableProperty CustomStyleProperty = SerializableProperty.Register(nameof (CustomStyle), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to RightToLeft property.
    /// </summary>
    private static SerializableProperty RightToLeftProperty = SerializableProperty.Register(nameof (RightToLeft), typeof (RightToLeft), typeof (Control), new SerializablePropertyMetadata((object) RightToLeft.Inherit));
    /// <summary>
    /// Provides a property reference to AutoSizeMode property.
    /// </summary>
    private static SerializableProperty AutoSizeModeProperty = SerializableProperty.Register(nameof (AutoSizeMode), typeof (AutoSizeMode), typeof (Control), new SerializablePropertyMetadata((object) AutoSizeMode.GrowOnly));
    /// <summary>
    /// Provides a property reference to TextProperty property.
    /// </summary>
    private static readonly SerializableProperty TextProperty = SerializableProperty.Register(nameof (Text), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register the BackgroundImageLayout property</summary>
    private static SerializableProperty BackgroundImageLayoutProperty = SerializableProperty.Register(nameof (BackgroundImageLayout), typeof (ImageLayout), typeof (Control), new SerializablePropertyMetadata((object) ImageLayout.Tile));
    /// <summary>Register the Margin property</summary>
    private static SerializableProperty MarginProperty = SerializableProperty.Register(nameof (Margin), typeof (Padding), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Register the Padding property</summary>
    private static SerializableProperty PaddingProperty = SerializableProperty.Register(nameof (Padding), typeof (Padding), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Register the ForeColor property</summary>
    private static SerializableProperty ForeColorProperty = SerializableProperty.Register(nameof (ForeColor), typeof (Color), typeof (Control), new SerializablePropertyMetadata((object) Color.Empty));
    /// <summary>Register the BackColor property</summary>
    private static SerializableProperty BackColorProperty = SerializableProperty.Register(nameof (BackColor), typeof (Color), typeof (Control), new SerializablePropertyMetadata((object) Color.Empty));
    /// <summary>Register the Theme property</summary>
    private static SerializableProperty ThemeProperty = SerializableProperty.Register(nameof (Theme), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) "Inherit"));
    /// <summary>Register the Font property</summary>
    private static SerializableProperty FontProperty = SerializableProperty.Register(nameof (Font), typeof (Font), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Register the ToolTip property</summary>
    private static SerializableProperty ToolTipProperty = SerializableProperty.Register(nameof (ToolTip), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register ExtendedToolTipDescriptor property.</summary>
    private static SerializableProperty ExtendedToolTipDescriptorProperty = SerializableProperty.Register(nameof (ExtendedToolTipDescriptor), typeof (ToolTipDescriptor), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Register the TagName property</summary>
    private static SerializableProperty TagNameProperty = SerializableProperty.Register(nameof (TagName), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register the Name property</summary>
    private static SerializableProperty NameProperty = SerializableProperty.Register(nameof (Name), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register the Accessible Name property</summary>
    private static SerializableProperty AccessibleNameProperty = SerializableProperty.Register(nameof (AccessibleName), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register the Accessible Description property</summary>
    private static SerializableProperty AccessibleDescriptionProperty = SerializableProperty.Register(nameof (AccessibleDescription), typeof (string), typeof (Control), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Register the MaximumSize property</summary>
    private static SerializableProperty MaximumSizeProperty = SerializableProperty.Register(nameof (MaximumSize), typeof (Size), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Register the MinimumSize property</summary>
    private static SerializableProperty MinimumSizeProperty = SerializableProperty.Register(nameof (MinimumSize), typeof (Size), typeof (Control), new SerializablePropertyMetadata());
    /// <summary>Register the KeyFilter property</summary>
    private static SerializableProperty KeyFilterProperty = SerializableProperty.Register(nameof (KeyFilter), typeof (KeyFilter), typeof (Control), new SerializablePropertyMetadata((object) KeyFilter.All));
    /// <summary>Register the ScrollTop property</summary>
    private static SerializableProperty ScrollTopProperty = SerializableProperty.Register(nameof (ScrollTop), typeof (int), typeof (Control), new SerializablePropertyMetadata((object) 0));
    /// <summary>Register the ScrollLeft property</summary>
    private static SerializableProperty ScrollLeftProperty = SerializableProperty.Register(nameof (ScrollLeft), typeof (int), typeof (Control), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// 
    /// </summary>
    private static SerializableProperty BackgroundImageProperty = SerializableProperty.Register(nameof (BackgroundImage), typeof (ResourceHandle), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the RegisteredTimers property</summary>
    private static SerializableProperty RegisteredTimersProperty = SerializableProperty.Register(nameof (RegisteredTimers), typeof (Timer[]), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the ImeMode property</summary>
    private static SerializableProperty ImeModeProperty = SerializableProperty.Register(nameof (ImeMode), typeof (ImeMode), typeof (Control), new SerializablePropertyMetadata((object) ImeMode.On));
    /// <summary>
    /// Register the ForceContentAvailabilityOnClient property
    /// </summary>
    private static SerializableProperty ForceContentAvailabilityOnClientProperty = SerializableProperty.Register(nameof (ForceContentAvailabilityOnClient), typeof (bool), typeof (Control), new SerializablePropertyMetadata((object) false));
    /// <summary>Register the Draggable property</summary>
    private static SerializableProperty DraggableProperty = SerializableProperty.Register(nameof (Draggable), typeof (DraggableOptions), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the Resizable property</summary>
    private static SerializableProperty ResizableProperty = SerializableProperty.Register(nameof (Resizable), typeof (ResizableOptions), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>Register the VisualTemplate</summary>
    private static SerializableProperty VisualTemplateProperty = SerializableProperty.Register(nameof (VisualTemplate), typeof (VisualTemplate), typeof (Control), new SerializablePropertyMetadata((object) null));
    /// <summary>The ParentChanged event registration.</summary>
    private static readonly SerializableEvent ParentChangedEvent = SerializableEvent.Register("ParentChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The Enter event registration.</summary>
    private static readonly SerializableEvent EnterEvent = SerializableEvent.Register("Enter", typeof (EventHandler), typeof (Control));
    /// <summary>The Leave event registration.</summary>
    private static readonly SerializableEvent LeaveEvent = SerializableEvent.Register("Leave", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent ResizeEvent = SerializableEvent.Register("Resize", typeof (EventHandler), typeof (Control));
    /// <summary>The EnabledChanged event registration.</summary>
    private static readonly SerializableEvent EnabledChangedEvent = SerializableEvent.Register("EnabledChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The Click event registration.</summary>
    internal static readonly SerializableEvent ClickEvent = SerializableEvent.Register("Click", typeof (EventHandler), typeof (Control));
    /// <summary>
    /// 
    /// </summary>
    internal static readonly SerializableEvent ControlSelectedEvent = SerializableEvent.Register("ControlSelected", typeof (ControlsEventHandler), typeof (Control));
    /// <summary>
    /// 
    /// </summary>
    internal static readonly SerializableEvent ControlDroppedEvent = SerializableEvent.Register("ControlDropped", typeof (ControlEventHandler), typeof (Control));
    /// <summary>The MouseClick event registration.</summary>
    internal static readonly SerializableEvent MouseClickEvent = SerializableEvent.Register("MouseClick", typeof (MouseEventHandler), typeof (Control));
    /// <summary>The KeyDown event registration.</summary>
    private static readonly SerializableEvent KeyDownEvent = SerializableEvent.Register("KeyDown", typeof (KeyEventHandler), typeof (Control));
    /// <summary>The KeyPress event registration.</summary>
    private static readonly SerializableEvent KeyPressEvent = SerializableEvent.Register("KeyPress", typeof (KeyPressEventHandler), typeof (Control));
    /// <summary>The KeyUp event registration.</summary>
    private static readonly SerializableEvent KeyUpEvent = SerializableEvent.Register("KeyUp", typeof (KeyEventHandler), typeof (Control));
    /// <summary>The GotFocus event registration.</summary>
    private static readonly SerializableEvent GotFocusEvent = SerializableEvent.Register("GotFocus", typeof (EventHandler), typeof (Control));
    /// <summary>The LostFocus event registration.</summary>
    private static readonly SerializableEvent LostFocusEvent = SerializableEvent.Register("LostFocus", typeof (EventHandler), typeof (Control));
    /// <summary>The DoubleClick event registration.</summary>
    internal static readonly SerializableEvent DoubleClickEvent = SerializableEvent.Register("DoubleClick", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent TextChangedEvent = SerializableEvent.Register("TextChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The Validated event registration.</summary>
    private static readonly SerializableEvent ValidatedEvent = SerializableEvent.Register("Validated", typeof (EventHandler), typeof (Control));
    /// <summary>The CausesValidationChanged event registration.</summary>
    private static readonly SerializableEvent CausesValidationChangedEvent = SerializableEvent.Register("CausesValidationChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The Validating event registration.</summary>
    private static readonly SerializableEvent ValidatingEvent = SerializableEvent.Register("Validating", typeof (CancelEventHandler), typeof (Control));
    private static readonly SerializableEvent TextChangedQueuedEvent = SerializableEvent.Register("TextChangedQueued", typeof (EventHandler), typeof (Control));
    /// <summary>The LocationChanged event registration.</summary>
    private static readonly SerializableEvent LocationChangedEvent = SerializableEvent.Register("LocationChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The ControlAdded event registration.</summary>
    private static readonly SerializableEvent ControlAddedEvent = SerializableEvent.Register("ControlAdded", typeof (ControlEventHandler), typeof (Control));
    private static readonly SerializableEvent ControlEditingEvent = SerializableEvent.Register("EditControlEditingEvent", typeof (EventHandler<EditValueEditingEventArgs>), typeof (Control));
    /// <summary>The ControlRemoved event registration.</summary>
    private static readonly SerializableEvent ControlRemovedEvent = SerializableEvent.Register("ControlRemoved", typeof (ControlEventHandler), typeof (Control));
    /// <summary>The MouseDown event registration.</summary>
    internal static readonly SerializableEvent MouseDownEvent = SerializableEvent.Register("MouseDown", typeof (MouseEventHandler), typeof (Control));
    /// <summary>The MouseUp event registration.</summary>
    internal static readonly SerializableEvent MouseUpEvent = SerializableEvent.Register("MouseUp", typeof (MouseEventHandler), typeof (Control));
    /// <summary>The BindingContextChanged event registration.</summary>
    private static readonly SerializableEvent BindingContextChangedEvent = SerializableEvent.Register("BindingContextChanged", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent BackColorChangedEvent = SerializableEvent.Register("BackColorChanged", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent BackgroundImageChangedEvent = SerializableEvent.Register("BackgroundImageChanged", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent BackgroundImageLayoutChangedEvent = SerializableEvent.Register("BackgroundImageLayoutChanged", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent FontChangedEvent = SerializableEvent.Register("FontChanged", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent ForeColorChangedEvent = SerializableEvent.Register("ForeColorChanged", typeof (EventHandler), typeof (Control));
    private static readonly SerializableEvent PaddingChangedEvent = SerializableEvent.Register("PaddingChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The CursorChanged event registration.</summary>
    private static readonly SerializableEvent CursorChangedEvent = SerializableEvent.Register("CursorChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The VisibleChanged event registration.</summary>
    private static readonly SerializableEvent VisibleChangedEvent = SerializableEvent.Register("VisibleChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The HelpRequested event registration.</summary>
    private static readonly SerializableEvent HelpRequestedEvent = SerializableEvent.Register("HelpRequested", typeof (HelpEventHandler), typeof (Control));
    /// <summary>The AutoSizeChanged event registration.</summary>
    private static readonly SerializableEvent AutoSizeChangedEvent = SerializableEvent.Register("AutoSizeChanged", typeof (EventHandler), typeof (Control));
    /// <summary>The CursorChanged event registration.</summary>
    private static readonly SerializableEvent SizeChangedEvent = SerializableEvent.Register("SizeChanged", typeof (EventHandler), typeof (Control));
    /// <summary>Gets or sets the control styles.</summary>
    /// <value>The control styles.</value>
    [NonSerialized]
    private ControlStyles menmControlStyle;
    /// <summary>The collection of controls this control has</summary>
    [NonSerialized]
    private Control.ControlCollection mobjControls;
    /// <summary>The height of the control.</summary>
    /// <value>The height of the control.</value>
    [NonSerialized]
    private int mintHeight;
    /// <summary>The layout height of the control</summary>
    [NonSerialized]
    private int mintLayoutHeight;
    /// <summary>The preferred height of the control.</summary>
    /// <value>The preferred height of the control.</value>
    [NonSerialized]
    private int mintPreferredHeight = -1;
    /// <summary>The width of the control.</summary>
    /// <value>The width of the control.</value>
    [NonSerialized]
    private int mintWidth;
    /// <summary>The layout width of the control.</summary>
    /// <value>The layout width of the control.</value>
    [NonSerialized]
    private int mintLayoutWidth;
    /// <summary>The preferred width of the control.</summary>
    /// <value>The preferred width of the control.</value>
    [NonSerialized]
    private int mintPreferredWidth = -1;
    /// <summary>The left position of the control.</summary>
    [NonSerialized]
    private int mintLeft;
    /// <summary>The top position of the control.</summary>
    [NonSerialized]
    private int mintTop;
    /// <summary>The control tab index</summary>
    [NonSerialized]
    private int mintTabIndex = -1;
    /// <summary>Control flags</summary>
    [NonSerialized]
    private int mintSuspendLayout;
    /// <summary>The current docking state</summary>
    [NonSerialized]
    private DockStyle menmDock;
    /// <summary>The current anchoring state</summary>
    [NonSerialized]
    private AnchorStyles menmAnchor = AnchorStyles.Left | AnchorStyles.Top;
    /// <summary>The component state</summary>
    [NonSerialized]
    private int mintControlState;
    /// <summary>The selected state</summary>
    [NonSerialized]
    private bool mblnSelectedIndicator;
    /// <summary>The amount of fields that the control writes / reads</summary>
    private const int mcntSerializableDataFieldCount = 14;
    /// <summary>The ObservableSuspendLayout event registration.</summary>
    private static readonly SerializableEvent ObservableSuspendLayoutEvent = SerializableEvent.Register("ObservableSuspendLayout", typeof (EventHandler), typeof (Control));
    /// <summary>The ObservableResumeLayout event registration.</summary>
    private static readonly SerializableEvent ObservableResumeLayoutEvent = SerializableEvent.Register("ObservableResumeLayout", typeof (ObservableResumeLayoutHandler), typeof (Control));
    private EditMode menmEditMode;
    /// <summary>The skin of the current control</summary>
    /// <remarks>
    /// This field provides the Skin property its presistance an in serialization mode
    /// it is not required to be serialized as the Skin property automaticly generates and
    /// instance if this field is null.
    /// </remarks>
    [NonSerialized]
    private ControlSkin mobjSkin;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Parent"></see> property value changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ControlOnParentChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler ParentChanged
    {
      add => this.AddHandler(Control.ParentChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ParentChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ParentChanged event.</summary>
    private EventHandler ParentChangedHandler => (EventHandler) this.GetHandler(Control.ParentChangedEvent);

    /// <summary>Occurs when the control is entered.</summary>
    public event EventHandler Enter
    {
      add => this.AddCriticalHandler(Control.EnterEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.EnterEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Enter event.</summary>
    private EventHandler EnterHandler => (EventHandler) this.GetHandler(Control.EnterEvent);

    /// <summary>Occurs when the input focus leaves the control.
    /// Not implemented by design.
    /// </summary>
    public event EventHandler Leave
    {
      add => this.AddCriticalHandler(Control.LeaveEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.LeaveEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Leave event.</summary>
    private EventHandler LeaveHandler => (EventHandler) this.GetHandler(Control.LeaveEvent);

    /// <summary>Occurs when the control is resized.</summary>
    public event EventHandler Resize
    {
      add => this.AddCriticalHandler(Control.ResizeEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.ResizeEvent, (Delegate) value);
    }

    private EventHandler ResizeHandler => (EventHandler) this.GetHandler(Control.ResizeEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Enabled"></see> property value has changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("ControlOnEnabledChangedDescr")]
    public event EventHandler EnabledChanged
    {
      add => this.AddHandler(Control.EnabledChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.EnabledChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the EnabledChanged event.</summary>
    private EventHandler EnabledChangedHandler => (EventHandler) this.GetHandler(Control.EnabledChangedEvent);

    /// <summary>Occurs on clicking the button.</summary>
    public event EventHandler Click
    {
      add => this.AddCriticalHandler(Control.ClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.ClickEvent, (Delegate) value);
    }

    /// <summary>Occurs when [controls selected].</summary>
    public event ControlsEventHandler ControlSelected
    {
      add => this.AddCriticalHandler(Control.ControlSelectedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.ControlSelectedEvent, (Delegate) value);
    }

    /// <summary>Gets the control selected handler.</summary>
    private ControlsEventHandler ControlSelectedHandler => (ControlsEventHandler) this.GetHandler(Control.ControlSelectedEvent);

    /// <summary>Occurs when [controls dropped].</summary>
    public event ControlEventHandler ControlDropped
    {
      add => this.AddCriticalHandler(Control.ControlDroppedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.ControlDroppedEvent, (Delegate) value);
    }

    /// <summary>Gets the control dropped handler.</summary>
    private ControlEventHandler ControlDroppedHandler => (ControlEventHandler) this.GetHandler(Control.ControlDroppedEvent);

    /// <summary>Occurs when the control is clicked by the mouse.</summary>
    [SRCategory("CatAction")]
    [SRDescription("ControlOnMouseClickDescr")]
    public event MouseEventHandler MouseClick
    {
      add => this.AddCriticalHandler(Control.MouseClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.MouseClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the MouseClick event.</summary>
    private MouseEventHandler MouseClickHandler => (MouseEventHandler) this.GetHandler(Control.MouseClickEvent);

    /// <summary>
    /// Occurs on key down.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    public event KeyEventHandler KeyDown
    {
      add => this.AddCriticalHandler(Control.KeyDownEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.KeyDownEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the KeyDown event.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected KeyEventHandler KeyDownHandler => (KeyEventHandler) this.GetHandler(Control.KeyDownEvent);

    /// <summary>Occurs on key press.</summary>
    public event KeyPressEventHandler KeyPress
    {
      add => this.AddCriticalHandler(Control.KeyPressEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.KeyPressEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the KeyPress event.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected KeyPressEventHandler KeyPressHandler => (KeyPressEventHandler) this.GetHandler(Control.KeyPressEvent);

    /// <summary>
    /// Occurs on key up.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    public event KeyEventHandler KeyUp
    {
      add => this.AddHandler(Control.KeyUpEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.KeyUpEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the KeyUp event.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected KeyEventHandler KeyUpHandler => (KeyEventHandler) this.GetHandler(Control.KeyUpEvent);

    /// <summary>Occurs when the control recives focus.</summary>
    public event EventHandler GotFocus
    {
      add => this.AddCriticalHandler(Control.GotFocusEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.GotFocusEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the GotFocus event.</summary>
    private EventHandler GotFocusHandler => (EventHandler) this.GetHandler(Control.GotFocusEvent);

    /// <summary>Occurs when the control loses focus.</summary>
    public event EventHandler LostFocus
    {
      add => this.AddCriticalHandler(Control.LostFocusEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.LostFocusEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the LostFocus event.</summary>
    private EventHandler LostFocusHandler => (EventHandler) this.GetHandler(Control.LostFocusEvent);

    /// <summary>Occurs when the control is double clicked.</summary>
    public event EventHandler DoubleClick
    {
      add => this.AddCriticalHandler(Control.DoubleClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.DoubleClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the DoubleClick event.</summary>
    private EventHandler DoubleClickHandler => (EventHandler) this.GetHandler(Control.DoubleClickEvent);

    /// <summary>Occurs when the Text property value changes.</summary>
    public event EventHandler TextChanged
    {
      add => this.AddCriticalHandler(Control.TextChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.TextChangedEvent, (Delegate) value);
    }

    private EventHandler TextChangedHandler => (EventHandler) this.GetHandler(Control.TextChangedEvent);

    /// <summary>Occurs when the control is finished validating.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ControlOnValidatedDescr")]
    [SRCategory("CatFocus")]
    public event EventHandler Validated
    {
      add => this.AddCriticalHandler(Control.ValidatedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.ValidatedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Validated event.</summary>
    private EventHandler ValidatedHandler => (EventHandler) this.GetHandler(Control.ValidatedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.CausesValidation"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("ControlOnCausesValidationChangedDescr")]
    public event EventHandler CausesValidationChanged
    {
      add => this.AddHandler(Control.CausesValidationChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.CausesValidationChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the CausesValidationChanged event.
    /// </summary>
    private EventHandler CausesValidationChangedHandler => (EventHandler) this.GetHandler(Control.CausesValidationChangedEvent);

    /// <summary>Occurs when the control is validating.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ControlOnValidatingDescr")]
    [SRCategory("CatFocus")]
    public event CancelEventHandler Validating
    {
      add => this.AddCriticalHandler(Control.ValidatingEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.ValidatingEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Validating event.</summary>
    private CancelEventHandler ValidatingHandler => (CancelEventHandler) this.GetHandler(Control.ValidatingEvent);

    /// <summary>
    /// Occurs when the Text property value changes (Queued).
    /// </summary>
    public event EventHandler TextChangedQueued
    {
      add => this.AddHandler(Control.TextChangedQueuedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.TextChangedQueuedEvent, (Delegate) value);
    }

    private EventHandler TextChangedQueuedHandler => (EventHandler) this.GetHandler(Control.TextChangedQueuedEvent);

    /// <summary>Occurs when the Location property value has changed.</summary>
    public event EventHandler LocationChanged
    {
      add => this.AddCriticalHandler(Control.LocationChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.LocationChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the LocationChanged event.</summary>
    private EventHandler LocationChangedHandler => (EventHandler) this.GetHandler(Control.LocationChangedEvent);

    /// <summary>
    /// Occurs when a new control is added to the ControlCollection.
    /// </summary>
    public event ControlEventHandler ControlAdded
    {
      add => this.AddHandler(Control.ControlAddedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ControlAddedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ControlAdded event.</summary>
    private ControlEventHandler ControlAddedHandler => (ControlEventHandler) this.GetHandler(Control.ControlAddedEvent);

    /// <summary>Occurs when [edit control editing].</summary>
    public event EventHandler<EditValueEditingEventArgs> EditControlEditing
    {
      add => this.AddHandler(Control.ControlEditingEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ControlEditingEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs when a control is removed from the ControlCollection.
    /// </summary>
    public event ControlEventHandler ControlRemoved
    {
      add => this.AddHandler(Control.ControlRemovedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ControlRemovedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ControlRemoved event.</summary>
    private ControlEventHandler ControlRemovedHandler => (ControlEventHandler) this.GetHandler(Control.ControlRemovedEvent);

    /// <summary>
    /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
    /// Implemented by design as Click (Use Click instead).
    /// </summary>
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    public event MouseEventHandler MouseDown
    {
      add => this.AddCriticalHandler(Control.MouseDownEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.MouseDownEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the MouseDown event.</summary>
    private MouseEventHandler MouseDownHandler => (MouseEventHandler) this.GetHandler(Control.MouseDownEvent);

    /// <summary>Occurs when the mouse pointer is over the control and a mouse button is released.
    /// Implemented by design as Click (Use Click instead).
    /// </summary>
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    public event MouseEventHandler MouseUp
    {
      add => this.AddCriticalHandler(Control.MouseUpEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Control.MouseUpEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the MouseUp event.</summary>
    private MouseEventHandler MouseUpHandler => (MouseEventHandler) this.GetHandler(Control.MouseUpEvent);

    /// <summary>
    /// Gets the position of the mouse cursor in screen coordinates.
    /// </summary>
    public static Point MousePosition => Cursor.Position;

    /// <summary>
    /// Occurs when the value of the BindingContext property changes.
    /// </summary>
    public event EventHandler BindingContextChanged
    {
      add => this.AddHandler(Control.BindingContextChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.BindingContextChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BindingContextChanged event.</summary>
    private EventHandler BindingContextChangedHandler => (EventHandler) this.GetHandler(Control.BindingContextChangedEvent);

    /// <summary>
    /// Occurs when the value of the BackColor property changes.
    /// </summary>
    public event EventHandler BackColorChanged
    {
      add => this.AddHandler(Control.BackColorChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.BackColorChangedEvent, (Delegate) value);
    }

    private EventHandler BackColorChangedHandler => (EventHandler) this.GetHandler(Control.BackColorChangedEvent);

    /// <summary>
    /// Occurs when the value of the BackgroundImage property changes.
    /// </summary>
    public event EventHandler BackgroundImageChanged
    {
      add => this.AddHandler(Control.BackgroundImageChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.BackgroundImageChangedEvent, (Delegate) value);
    }

    private EventHandler BackgroundImageChangedHandler => (EventHandler) this.GetHandler(Control.BackgroundImageChangedEvent);

    /// <summary>
    /// Occurs when the BackgroundImageLayout property changes.
    /// </summary>
    public event EventHandler BackgroundImageLayoutChanged
    {
      add => this.AddHandler(Control.BackgroundImageLayoutChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.BackgroundImageLayoutChangedEvent, (Delegate) value);
    }

    private EventHandler BackgroundImageLayoutChangedHandler => (EventHandler) this.GetHandler(Control.BackgroundImageLayoutChangedEvent);

    /// <summary>Occurs when the FontChanged property changes.</summary>
    public event EventHandler FontChanged
    {
      add => this.AddHandler(Control.FontChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.FontChangedEvent, (Delegate) value);
    }

    private EventHandler FontChangedHandler => (EventHandler) this.GetHandler(Control.FontChangedEvent);

    /// <summary>Occurs when the ForeColorChanged property changes.</summary>
    public event EventHandler ForeColorChanged
    {
      add => this.AddHandler(Control.ForeColorChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ForeColorChangedEvent, (Delegate) value);
    }

    private EventHandler ForeColorChangedHandler => (EventHandler) this.GetHandler(Control.ForeColorChangedEvent);

    /// <summary>Occurs when the PaddingChanged property changes.</summary>
    public event EventHandler PaddingChanged
    {
      add => this.AddHandler(Control.PaddingChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.PaddingChangedEvent, (Delegate) value);
    }

    private EventHandler PaddingChangedHandler => (EventHandler) this.GetHandler(Control.PaddingChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property changes.</summary>
    public event EventHandler CursorChanged
    {
      add => this.AddHandler(Control.CursorChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.CursorChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CursorChanged event.</summary>
    private EventHandler CursorChangedHandler => (EventHandler) this.GetHandler(Control.CursorChangedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Visible"></see> property value changes.</summary>
    [SRCategory("CatPropertyChanged")]
    [SRDescription("ControlOnVisibleChangedDescr")]
    public event EventHandler VisibleChanged
    {
      add => this.AddHandler(Control.VisibleChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.VisibleChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the VisibleChanged event.</summary>
    private EventHandler VisibleChangedHandler => (EventHandler) this.GetHandler(Control.VisibleChangedEvent);

    /// <summary>Occurs when the user requests help for a control.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("ControlOnHelpDescr")]
    public event HelpEventHandler HelpRequested
    {
      add => this.AddHandler(Control.HelpRequestedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.HelpRequestedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the HelpRequested event.</summary>
    private HelpEventHandler HelpRequestedHandler => (HelpEventHandler) this.GetHandler(Control.HelpRequestedEvent);

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ButtonBase.AutoSize">
    /// </see> property changes.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [SRDescription("ControlOnAutoSizeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler AutoSizeChanged
    {
      add => this.AddHandler(Control.AutoSizeChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.AutoSizeChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AutoSizeChanged event.</summary>
    private EventHandler AutoSizeChangedHandler => (EventHandler) this.GetHandler(Control.AutoSizeChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property changes.</summary>
    [SRDescription("ControlOnSizeChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler SizeChanged
    {
      add => this.AddHandler(Control.SizeChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.SizeChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CursorChanged event.</summary>
    private EventHandler SizeChangedHandler => (EventHandler) this.GetHandler(Control.SizeChangedEvent);

    /// <summary>Occurs when an object is dragged into the control's bounds.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ControlOnDragEnterDescr")]
    [SRCategory("CatDragDrop")]
    public event DragEventHandler DragEnter;

    /// <summary>Occurs when the mouse pointer is moved over the control.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ControlOnMouseMoveDescr")]
    [SRCategory("CatMouse")]
    public event MouseEventHandler MouseMove;

    /// <summary>Occurs when the mouse pointer leaves the control.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatMouse")]
    [SRDescription("ControlOnMouseLeaveDescr")]
    public event MouseEventHandler MouseLeave;

    /// <summary>Occurs when the mouse pointer enters the control.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ControlOnMouseEnterDescr")]
    [SRCategory("CatMouse")]
    public event MouseEventHandler MouseEnter;

    /// <summary>
    /// 
    /// </summary>
    public Control()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, true);
      this.SetState(Component.ComponentState.Visible | Component.ComponentState.Enabled | Component.ComponentState.AllowDrag, true);
      this.SetState(Control.ControlState.TabStop | Control.ControlState.HasPositioning | Control.ControlState.CausesValidation, true);
      Size defaultSize = this.DefaultSize;
      this.mintLayoutHeight = this.mintHeight = defaultSize.Height;
      this.mintLayoutWidth = this.mintWidth = defaultSize.Width;
      this.menmEditMode = EditMode.Off;
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize
    {
      get
      {
        int serializableDataInitialSize = base.SerializableDataInitialSize + 14;
        if (this.ShouldSerializableObjectSerializeControls)
          serializableDataInitialSize += SerializationWriter.GetRequiredCapacity((ICollection) this.mobjControls);
        return serializableDataInitialSize;
      }
    }

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.menmAnchor = (AnchorStyles) objReader.ReadObject();
      this.menmDock = (DockStyle) objReader.ReadObject();
      this.menmControlStyle = (ControlStyles) objReader.ReadObject();
      this.mintHeight = objReader.ReadInt32();
      this.mintWidth = objReader.ReadInt32();
      this.mintLeft = objReader.ReadInt32();
      this.mintTop = objReader.ReadInt32();
      this.mintLayoutHeight = objReader.ReadInt32();
      this.mintLayoutWidth = objReader.ReadInt32();
      this.mintPreferredHeight = objReader.ReadInt32();
      this.mintPreferredWidth = objReader.ReadInt32();
      this.mintTabIndex = objReader.ReadInt32();
      this.mintSuspendLayout = objReader.ReadInt32();
      this.mintControlState = objReader.ReadInt32();
      this.mblnSelectedIndicator = objReader.ReadBoolean();
      if (!this.ShouldSerializableObjectSerializeControls)
        return;
      object[] c = objReader.ReadArray();
      if (c.Length == 0)
        return;
      this.mobjControls = this.CreateControlsInstance();
      this.mobjControls.InnerList.AddRange((ICollection) c);
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteObject((object) this.menmAnchor);
      objWriter.WriteObject((object) this.menmDock);
      objWriter.WriteObject((object) this.menmControlStyle);
      objWriter.WriteInt32(this.mintHeight);
      objWriter.WriteInt32(this.mintWidth);
      objWriter.WriteInt32(this.mintLeft);
      objWriter.WriteInt32(this.mintTop);
      objWriter.WriteInt32(this.mintLayoutHeight);
      objWriter.WriteInt32(this.mintLayoutWidth);
      objWriter.WriteInt32(this.mintPreferredHeight);
      objWriter.WriteInt32(this.mintPreferredWidth);
      objWriter.WriteInt32(this.mintTabIndex);
      objWriter.WriteInt32(this.mintSuspendLayout);
      objWriter.WriteInt32(this.mintControlState);
      objWriter.WriteBoolean(this.mblnSelectedIndicator);
      if (!this.ShouldSerializableObjectSerializeControls)
        return;
      objWriter.WriteArray((ICollection) this.mobjControls);
    }

    /// <summary>
    /// Gets a value indicating whether serializable object should serialize controls.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if serializable object should serialize controls; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual bool ShouldSerializableObjectSerializeControls => true;

    /// <summary>Sets the state.</summary>
    /// <param name="intFlag">The flag to set.</param>
    /// <param name="blnValue">The flag value to set.</param>
    internal void SetState(Control.ControlState enmState, bool blnValue) => this.mintControlState = blnValue ? (int) ((Control.ControlState) this.mintControlState | enmState) : (int) ((Control.ControlState) this.mintControlState & ~enmState);

    /// <summary>
    /// Sets the state and returns a flag if value had changed.
    /// </summary>
    /// <param name="intFlag">The flag to set.</param>
    /// <param name="blnValue">The flag value to set.</param>
    internal bool SetStateWithCheck(Control.ControlState enmState, bool blnValue)
    {
      if (this.GetState(enmState) == blnValue)
        return false;
      this.SetState(enmState, blnValue);
      return true;
    }

    /// <summary>Gets the state.</summary>
    /// <param name="intFlag">The flag to get.</param>
    /// <returns></returns>
    internal bool GetState(Control.ControlState enmState) => ((Control.ControlState) this.mintControlState & enmState) != 0;

    /// <summary>Shows the contextual toolbar.</summary>
    public virtual void ShowContextualToolbar() => Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ShowContextualToolbar((Component) this);

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      this.RenderComponentAttributes(objContext, objWriter);
      if (this.TabStop || this.Controls.Count > 0 && !Control.IsFocusManagingContainerControl(this))
        objWriter.WriteAttributeString("TI", this.TabIndex.ToString());
      if (this.EnableGroupTabbing)
        objWriter.WriteAttributeString("EGT", "1");
      if (!this.GetState(Component.ComponentState.Visible))
        objWriter.WriteAttributeString("V", "0");
      this.RenderEnabledAttribute(objWriter);
      if (this.Focusable)
        objWriter.WriteAttributeString("F", "1");
      this.RenderVisualTemplate(objContext, objWriter);
      if (this.CustomStyle != "")
        objWriter.WriteAttributeString("ES", this.GetProxyPropertyValue<string>("CustomStyle", this.CustomStyle));
      if (this.ShouldRenderExtendedToolTip())
      {
        this.RenderExtendedToolTip(objWriter, false);
      }
      else
      {
        string toolTip = this.ToolTip;
        if (!string.IsNullOrEmpty(toolTip))
          objWriter.WriteAttributeText("TT", toolTip);
      }
      ResourceHandle proxyPropertyValue1 = this.GetProxyPropertyValue<ResourceHandle>("BackgroundImage", this.BackgroundImage);
      if (proxyPropertyValue1 != null)
        objWriter.WriteAttributeString("BI", proxyPropertyValue1.ToString());
      ImageLayout proxyPropertyValue2 = this.GetProxyPropertyValue<ImageLayout>("BackgroundImageLayout", this.BackgroundImageLayout);
      if (this.ShouldRenderBackgroundImageLayout(proxyPropertyValue2))
        objWriter.WriteAttributeString("BIL", ((int) proxyPropertyValue2).ToString());
      if (this.ShouldRenderKeyFilter())
        objWriter.WriteAttributeString("KF", Convert.ToInt64((object) this.KeyFilter).ToString());
      if (this.IsDelayedDrawing && !this.UseWGNamespace)
        objWriter.WriteAttributeString("IDD", "1");
      if (!this.AutoDrawn)
        objWriter.WriteAttributeString("ADN", "0");
      BorderValue objBorderValue = new BorderValue();
      objBorderValue.Width = this.GetProxyPropertyValue<BorderWidth>("BorderWidth", this.BorderWidth);
      objBorderValue.Color = this.GetProxyPropertyValue<BorderColor>("BorderColor", this.BorderColor);
      objBorderValue.Style = this.GetProxyPropertyValue<BorderStyle>("BorderStyle", this.BorderStyle);
      if (this.ShouldRenderBorder(objBorderValue))
        objWriter.WriteAttributeString("BR", objBorderValue.GetValue(objContext));
      if (this.ShouldRenderErrorMessage())
      {
        objWriter.WriteAttributeText("EM", this.ErrorMessage);
        objWriter.WriteAttributeString("EIP", this.ErrorIconPadding.ToString());
        objWriter.WriteAttributeString("EIA", this.ErrorIconAlignment.ToString());
        ResourceHandle errorIcon = this.ErrorIcon;
        if (errorIcon != null)
          objWriter.WriteAttributeString("EI", errorIcon.ToString());
      }
      Font proxyPropertyValue3 = this.GetProxyPropertyValue<Font>("Font", this.Font);
      if (this.ShouldRenderFont(proxyPropertyValue3))
        objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(proxyPropertyValue3));
      Color proxyPropertyValue4 = this.GetProxyPropertyValue<Color>("BackColor", this.BackColor);
      if (this.ShouldRenderBackColor(proxyPropertyValue4))
        this.RenderBackColorAttribute(objWriter, proxyPropertyValue4);
      Color proxyPropertyValue5 = this.GetProxyPropertyValue<Color>("ForeColor", this.GetForeColor());
      if (this.ShouldRenderForeColor(proxyPropertyValue5))
        objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(proxyPropertyValue5));
      Padding proxyPropertyValue6 = this.GetProxyPropertyValue<Padding>("Padding", this.Padding);
      if (this.ShouldRenderPaddingAttribute(proxyPropertyValue6))
      {
        if (proxyPropertyValue6.IsAll)
        {
          if (proxyPropertyValue6.All != 0)
            objWriter.WriteAttributeString("PA", proxyPropertyValue6.All.ToString());
        }
        else
        {
          if (proxyPropertyValue6.Top != 0)
            objWriter.WriteAttributeString("PT", proxyPropertyValue6.Top.ToString());
          if (proxyPropertyValue6.Right != 0)
            objWriter.WriteAttributeString("PR", proxyPropertyValue6.Right.ToString());
          if (proxyPropertyValue6.Bottom != 0)
            objWriter.WriteAttributeString("PB", proxyPropertyValue6.Bottom.ToString());
          if (proxyPropertyValue6.Left != 0)
            objWriter.WriteAttributeString("PL", proxyPropertyValue6.Left.ToString());
        }
      }
      if (this.Parent != null && this.Parent.SupportChildMargins || this.Parent != null && !this.Parent.WinFormsCompatibility.IsForbidDockMargin && this.Dock != DockStyle.None)
      {
        Padding proxyPropertyValue7 = this.GetProxyPropertyValue<Padding>("Margin", this.Margin);
        if (proxyPropertyValue7 != this.DefaultMargin)
        {
          if (proxyPropertyValue7.IsAll)
          {
            if (proxyPropertyValue7.All != 0)
              objWriter.WriteAttributeString("MA", proxyPropertyValue7.All.ToString());
          }
          else
          {
            objWriter.WriteAttributeString("MT", proxyPropertyValue7.Top.ToString());
            if (proxyPropertyValue7.Right != 0)
              objWriter.WriteAttributeString("MR", proxyPropertyValue7.Right.ToString());
            if (proxyPropertyValue7.Bottom != 0)
              objWriter.WriteAttributeString("MB", proxyPropertyValue7.Bottom.ToString());
            if (proxyPropertyValue7.Left != 0)
              objWriter.WriteAttributeString("ML", proxyPropertyValue7.Left.ToString());
          }
        }
      }
      Cursor proxyPropertyValue8 = this.GetProxyPropertyValue<Cursor>("Cursor", this.Cursor);
      if (proxyPropertyValue8 != (Cursor) null)
        proxyPropertyValue8.RenderCursor(objContext, objWriter);
      this.RenderScollPositionAttributes(objWriter, false);
      if (this is IButtonControl)
        objWriter.WriteAttributeString("IBC", "1");
      if (!this.GetProxyPropertyValue<bool>("SupportsKeyNavigation", this.SupportsKeyNavigation))
        objWriter.WriteAttributeString("SKN", "0");
      this.RenderRightToLeftAttribute(objWriter, false);
      this.RenderDraggableAttribute(objContext, objWriter, false);
      this.RenderDroppableAttribute(objContext, objWriter, false);
      this.RenderResizableAttribute(objContext, objWriter, false);
      this.RenderSelectableAttribute(objContext, objWriter, false);
      if (this is IButtonControl)
        objWriter.WriteAttributeString("ACL", "1");
      this.RenderSelectedIndicatorAttribute(objContext, objWriter, false);
      this.RenderAccessibleNameAttribute(objWriter, false);
      this.RenderEditModeAttirbute(objWriter, false);
      this.RenderThemeAttribute(objContext, objWriter, false);
      this.RenderSkipMultiTheme(objWriter, false);
    }

    /// <summary>Renders the visual template.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter) => this.RenderVisualTemplate(objContext, objWriter, this.GetProxyPropertyValue<VisualTemplate>("VisualTemplate", this.VisualTemplate));

    /// <summary>Renders the visual template.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objVisualTemplate">The obj visual template.</param>
    protected void RenderVisualTemplate(
      IContext objContext,
      IAttributeWriter objWriter,
      VisualTemplate objVisualTemplate)
    {
      objVisualTemplate?.Render(objContext, objWriter);
    }

    /// <summary>Renders the edit mode attirbute.</summary>
    /// <param name="objWriter">The object writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderEditModeAttirbute(IAttributeWriter objWriter, bool blnForceRender)
    {
      EditMode editControlMode = this.EditControlMode;
      if (!(editControlMode == EditMode.On | blnForceRender))
        return;
      objWriter.WriteAttributeString("CEM", editControlMode == EditMode.On ? "1" : "0");
    }

    /// <summary>Renders the enabled attribute.</summary>
    /// <param name="objWriter">The object writer.</param>
    protected virtual void RenderEnabledAttribute(IAttributeWriter objWriter)
    {
      if (this.GetProxyPropertyValue<bool>("Enabled", this.EnabledInternal))
        return;
      objWriter.WriteAttributeString("En", "0");
    }

    /// <summary>Renders the scoll position attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSkipMultiTheme(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!blnForceRender && this.SkipMultiTheme == ControlSkipMultiTheme.None)
        return;
      objWriter.WriteAttributeString("SMT", this.SkipMultiTheme.ToString());
    }

    /// <summary>Renders the scoll position attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderScollPositionAttributes(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.ScrollTop != 0 | blnForceRender)
        objWriter.WriteAttributeString("SCT", this.ScrollTop.ToString());
      if (!(this.ScrollLeft != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("SCL", this.ScrollLeft.ToString());
    }

    /// <summary>
    /// Determines whether to render extended tooltip.
    /// Renders if at least one value is not empty, and both template name and tooltip key exist.
    /// </summary>
    /// <returns></returns>
    private bool ShouldRenderExtendedToolTip()
    {
      ToolTipDescriptor toolTipDescriptor = this.ExtendedToolTipDescriptor;
      if (toolTipDescriptor != null)
      {
        string toolTipTemplateName = toolTipDescriptor.ToolTipTemplateName;
        string toolTipKey = toolTipDescriptor.ToolTipKey;
        if (!string.IsNullOrEmpty(toolTipTemplateName) && !string.IsNullOrEmpty(toolTipKey))
        {
          foreach (KeyValuePair<string, string> extendedProperty in toolTipDescriptor.ExtendedProperties)
          {
            if (!string.IsNullOrEmpty(extendedProperty.Value))
              return true;
          }
        }
      }
      return false;
    }

    /// <summary>Renders the extended tooltip.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderExtendedToolTip(IAttributeWriter objWriter, bool blnForceRender)
    {
      string strText = string.Empty;
      string strValue1 = string.Empty;
      string strValue2 = string.Empty;
      ToolTipDescriptor toolTipDescriptor = this.ExtendedToolTipDescriptor;
      if (toolTipDescriptor != null)
      {
        strText = toolTipDescriptor.SerializedProperties;
        strValue1 = toolTipDescriptor.ToolTipTemplateName;
        strValue2 = toolTipDescriptor.ToolTipKey;
      }
      if (((string.IsNullOrEmpty(strValue1) ? 0 : (!string.IsNullOrEmpty(strValue2) ? 1 : 0)) | (blnForceRender ? 1 : 0)) == 0)
        return;
      objWriter.WriteAttributeText("ETT", strText);
      objWriter.WriteAttributeString("ETTN", strValue1);
      objWriter.WriteAttributeString("ETTK", strValue2);
    }

    /// <summary>Renders the right to left attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">The BLN force render.</param>
    private void RenderRightToLeftAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      int rightToLeft = (int) this.RightToLeft;
      if (!blnForceRender && rightToLeft == Convert.ToInt32(this.Context.RightToLeft))
        return;
      objWriter.WriteAttributeString("RTL", rightToLeft.ToString());
    }

    /// <summary>Renders the draggable attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected void RenderDraggableAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      DraggableOptions proxyPropertyValue = this.GetProxyPropertyValue<DraggableOptions>("Draggable", this.DraggableInternal);
      if (((proxyPropertyValue == null ? 0 : (proxyPropertyValue.IsDraggable ? 1 : 0)) | (blnForceRender ? 1 : 0)) == 0)
        return;
      objWriter.WriteAttributeString("DA", proxyPropertyValue == null || !proxyPropertyValue.IsDraggable ? "0" : "1");
      if (proxyPropertyValue == null || !proxyPropertyValue.IsDraggable || proxyPropertyValue.IsDefault())
        return;
      objWriter.WriteAttributeString("DAP", proxyPropertyValue.ToRenderString());
    }

    /// <summary>Renders the droppable attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected void RenderDroppableAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      bool flag = this.ControlDroppedHandler != null;
      if (!(flag | blnForceRender))
        return;
      objWriter.WriteAttributeString("DPA", flag ? "1" : "0");
    }

    /// <summary>Renders the selectable attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected void RenderSelectableAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      bool flag = this.ControlSelectedHandler != null;
      if (!(flag | blnForceRender))
        return;
      objWriter.WriteAttributeString("SA", flag ? "1" : "0");
    }

    /// <summary>Renders the resizable attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected void RenderResizableAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      ResizableOptions proxyPropertyValue = this.GetProxyPropertyValue<ResizableOptions>("Resizable", this.ResizableInternal);
      string str = string.Empty;
      if (this.ResizableAllowedDirections != null)
        str = string.Join(",", this.ResizableAllowedDirections);
      if (((proxyPropertyValue == null ? 0 : (proxyPropertyValue.IsResizable ? 1 : 0)) | (blnForceRender ? 1 : 0)) == 0)
        return;
      objWriter.WriteAttributeString("RA", proxyPropertyValue == null || !proxyPropertyValue.IsResizable ? "0" : "1");
      if (str == null)
        str = string.Empty;
      if (proxyPropertyValue != null && proxyPropertyValue.IsResizable && !proxyPropertyValue.IsDefault())
        objWriter.WriteAttributeString("REP", str + "|" + proxyPropertyValue.ToRenderString());
      else if (!string.IsNullOrEmpty(str))
      {
        objWriter.WriteAttributeString("REP", str + "|");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("REP", "");
      }
    }

    /// <summary>Renders the back color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objBackColor">Color of the obj back.</param>
    protected virtual void RenderBackColorAttribute(IAttributeWriter objWriter, Color objBackColor) => objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(objBackColor));

    /// <summary>Renders the selected indicator attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected void RenderSelectedIndicatorAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      bool proxyPropertyValue = this.GetProxyPropertyValue<bool>("SelectedIndicator", this.SelectedIndicator);
      if (!(proxyPropertyValue | blnForceRender))
        return;
      objWriter.WriteAttributeString("SIR", proxyPropertyValue ? "1" : "0");
    }

    /// <summary>Renders the Accessibility Name attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">The BLN force render.</param>
    private void RenderAccessibleNameAttribute(IAttributeWriter objWriter, bool blnForcRender)
    {
      if (!this.Context.Config.AccessibilityMode)
        return;
      string strValue = this.AccessibleName;
      if (string.IsNullOrEmpty(strValue))
        strValue = this.AccessibleDescription;
      if (string.IsNullOrEmpty(strValue))
        strValue = this.Name;
      if (!(!string.IsNullOrEmpty(strValue) | blnForcRender))
        return;
      objWriter.WriteAttributeString("ACN", strValue);
    }

    /// <summary>Renders the color of the fore.</summary>
    protected virtual Color GetForeColor() => this.ForeColor;

    /// <summary>Indicates should render background image layout.</summary>
    /// <returns></returns>
    private bool ShouldRenderBackgroundImageLayout(ImageLayout objImageLayout) => true;

    /// <summary>Indicates if to render error message.</summary>
    /// <returns></returns>
    private bool ShouldRenderErrorMessage() => !string.IsNullOrEmpty(this.ErrorMessage);

    /// <summary>Indicates if to render key filter.</summary>
    /// <returns></returns>
    private bool ShouldRenderKeyFilter() => this.KeyFilter != 0;

    /// <summary>Indicates if to render padding attribute</summary>
    /// <returns></returns>
    protected virtual bool ShouldRenderPaddingAttribute(Padding objPadding) => this.DefaultPadding != objPadding;

    /// <summary>Indicates if to render padding.</summary>
    /// <returns></returns>
    private bool ShouldRenderPadding() => this.DefaultPadding != this.Padding;

    /// <summary>Shoulds the color of the render fore.</summary>
    /// <param name="objForeColor">Color of the obj fore.</param>
    /// <returns></returns>
    private bool ShouldRenderForeColor(Color objForeColor) => objForeColor != this.DefaultForeColor;

    /// <summary>Indicates if to render back color.</summary>
    /// <returns></returns>
    private bool ShouldRenderBackColor(Color objBackColor) => objBackColor != this.DefaultBackColor;

    /// <summary>Shoulds the render registered timers.</summary>
    /// <returns></returns>
    private bool ShouldRenderRegisteredTimers() => this.RegisteredTimers != null;

    /// <summary>Indicates if to render font.</summary>
    /// <returns></returns>
    private bool ShouldRenderFont(Font objFont) => objFont != this.DefaultControlFont;

    /// <summary>Check if conrtol should be rendered.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    protected virtual bool ShouldRenderControl(Control objControl) => true;

    /// <summary>Renders the component.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    void IRenderableComponent.RenderComponent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal virtual void PreRenderControl(IContext objContext, long lngRequestID)
    {
      ((IContextParams) this.Context).InvokeComponentMessage((object) this, new ComponentMessageEventArgs(nameof (PreRenderControl)));
      this.PreRenderControls(objContext, this.IsDirty(lngRequestID) ? 0L : lngRequestID);
    }

    /// <summary>Posts the render control.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal virtual void PostRenderControl(IContext objContext, long lngRequestID)
    {
      this.ResetParams();
      this.PostRenderControls(objContext, this.IsDirty(lngRequestID) ? 0L : lngRequestID);
    }

    /// <summary>Pre-renders controls.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected virtual void PreRenderControls(IContext objContext, long lngRequestID)
    {
      ProxyComponent proxyComponent = this.ProxyComponent;
      if (proxyComponent != null)
      {
        proxyComponent.PreRenderComponents(objContext, lngRequestID);
      }
      else
      {
        int count = this.Controls.Count;
        for (int index = 0; index < count; ++index)
          this.Controls[index]?.PreRenderControl(objContext, lngRequestID);
      }
    }

    /// <summary>Posts the render controls.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected virtual void PostRenderControls(IContext objContext, long lngRequestID)
    {
      ProxyComponent proxyComponent = this.ProxyComponent;
      if (proxyComponent != null)
      {
        proxyComponent.PostRenderComponents(objContext, lngRequestID);
      }
      else
      {
        int count = this.Controls.Count;
        for (int index = 0; index < count; ++index)
          this.Controls[index]?.PostRenderControl(objContext, lngRequestID);
      }
    }

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree/
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected internal virtual void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.IsDirty(lngRequestID))
      {
        this.RegisterSelf();
        if (this.UseWGNamespace)
          objWriter.WriteStartElement(WGConst.Prefix, this.MetadataTag, WGConst.Namespace);
        else
          objWriter.WriteStartElement(WGConst.ControlsPrefix, this.MetadataTag, WGConst.ControlsNamespace);
        this.RenderAttributes(objContext, (IAttributeWriter) objWriter);
        this.RenderPositioning(objContext, (IAttributeWriter) objWriter, false);
        if (this.ShouldRenderContentInternal())
          this.Render(objContext, objWriter, 0L);
        this.RenderComponentClientEvents(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
      else if (this.IsDirtyAttributes(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
        this.RenderUpdatedAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID);
        if (this.ShouldRenderContentInternal())
          this.RenderControls(objContext, objWriter, lngRequestID, true);
        objWriter.WriteEndElement();
      }
      else
      {
        if (!this.ShouldRenderContentInternal())
          return;
        this.RenderControls(objContext, objWriter, lngRequestID, false);
      }
    }

    /// <summary>Shoulds the content of the control.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected internal bool ShouldRenderContentInternal() => this.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient || this.ShouldRenderContent();

    /// <summary>Shoulds the content of the control.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool ShouldRenderContent()
    {
      if (!this.GetState(Component.ComponentState.Visible))
        return false;
      Control parentInternal = this.ParentInternal;
      return parentInternal == null || parentInternal.ShouldRenderContentInternal();
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnFullRedraw"></param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnFullRedraw)
    {
      this.RenderControls(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected virtual void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      ProxyComponent proxyComponent = this.ProxyComponent;
      if (proxyComponent != null)
      {
        proxyComponent.RenderComponents(objContext, objWriter, lngRequestID);
      }
      else
      {
        bool reverseControls = this.ReverseControls;
        int count = this.Controls.Count;
        for (int index = reverseControls ? 0 : count - 1; (reverseControls ? (index < count ? 1 : 0) : (index > -1 ? 1 : 0)) != 0; index += reverseControls ? 1 : -1)
        {
          Control control = this.Controls[index];
          if (control != null && this.ShouldRenderControl(control))
            control.RenderControl(objContext, objWriter, lngRequestID);
        }
      }
    }

    /// <summary>An abstract control method rendering</summary>
    protected virtual void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RenderControls(objContext, objWriter, lngRequestID, true);
    }

    /// <summary>An abstract param attribute rendering</summary>
    protected virtual void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      if (this.ForceChildRedraw)
        objWriter.WriteAttributeString("FCR", "1");
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        objWriter.WriteAttributeString("KF", Convert.ToInt64((object) this.KeyFilter).ToString());
        this.RenderScollPositionAttributes(objWriter, true);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        this.RenderRightToLeftAttribute(objWriter, true);
        objWriter.WriteAttributeString("V", this.Visible ? "1" : "0");
        this.RenderSelectedIndicatorAttribute(objContext, objWriter, true);
        this.RenderVisualTemplate(objContext, objWriter);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Enabled))
        objWriter.WriteAttributeString("En", this.EnabledInternal ? "1" : "0");
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
      {
        this.RenderPositioning(objContext, objWriter, true);
        this.RenderThemeAttribute(objContext, objWriter, true);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
        objWriter.WriteAttributeText("TT", this.ToolTip);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.ExtendedToolTip))
        this.RenderExtendedToolTip(objWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        this.RenderSkipMultiTheme(objWriter, true);
      this.RenderComponentUpdateAttributes(objContext, objWriter, lngRequestID);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Error))
      {
        string errorMessage = this.ErrorMessage;
        if (!string.IsNullOrEmpty(errorMessage))
        {
          objWriter.WriteAttributeText("EM", errorMessage);
          objWriter.WriteAttributeString("EIP", this.ErrorIconPadding.ToString());
          objWriter.WriteAttributeString("EIA", this.ErrorIconAlignment.ToString());
        }
        else
          objWriter.WriteAttributeString("EM", string.Empty);
        ResourceHandle errorIcon = this.ErrorIcon;
        if (errorIcon != null)
          objWriter.WriteAttributeString("EI", errorIcon.ToString());
        else
          objWriter.WriteAttributeString("EI", string.Empty);
      }
      Cursor cursor = this.Cursor;
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Redraw) && cursor != (Cursor) null)
        cursor.RenderCursor(objContext, objWriter);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Drag))
      {
        this.RenderDraggableAttribute(objContext, objWriter, true);
        this.RenderDroppableAttribute(objContext, objWriter, true);
        this.RenderResizableAttribute(objContext, objWriter, true);
        this.RenderSelectableAttribute(objContext, objWriter, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Accessibility))
        return;
      this.RenderAccessibleNameAttribute(objWriter, true);
    }

    /// <summary>
    /// Determines whether [is critical event] [the specified obj event key].
    /// </summary>
    /// <param name="objEventKey">The event key.</param>
    /// <returns>
    /// 	<c>true</c> if [is critical event] [the specified obj event key]; otherwise, <c>false</c>.
    /// </returns>
    protected internal bool IsCriticalEvent(SerializableEvent objEventKey) => objEventKey != null && this.HasHandler(objEventKey);

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(type))
      {
        case 37362191:
          if (!(type == "Click"))
            break;
          this.OnClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
        case 231533981:
          if (!(type == "LostFocus"))
            break;
          IContainerControl containerControlInternal1 = this.GetContainerControlInternal();
          if (containerControlInternal1 != null && containerControlInternal1.ActiveControl != this)
            containerControlInternal1.ActivateControl(this);
          this.OnLostFocus(new EventArgs());
          if (!(this.Context is IApplicationContext context1) || context1.GetFocused() != this)
            break;
          context1.SetFocused((IControl) null, false);
          break;
        case 395326401:
          if (!(type == "Resize"))
            break;
          double num1 = Convert.ToDouble(objEvent["Width"], (IFormatProvider) CultureInfo.InvariantCulture);
          double num2 = Convert.ToDouble(objEvent["Height"], (IFormatProvider) CultureInfo.InvariantCulture);
          if (!this.SetBounds(0, 0, Convert.ToInt32(num1), Convert.ToInt32(num2), BoundsSpecified.Size, true))
            break;
          this.OnResizeInternal(new LayoutEventArgs(true, false, true));
          break;
        case 439736093:
          if (!(type == "ScrollPositionChanged"))
            break;
          double dblValue1 = 0.0;
          if (!string.IsNullOrEmpty(objEvent["SCT"]))
          {
            CommonUtils.TryParse(objEvent["SCT"], out dblValue1);
            this.SetScrollTop(Convert.ToInt32(dblValue1));
          }
          if (string.IsNullOrEmpty(objEvent["SCT"]))
            break;
          CommonUtils.TryParse(objEvent["SCL"], out dblValue1);
          this.SetScrollLeft(Convert.ToInt32(dblValue1));
          break;
        case 585868736:
          if (!(type == "ControlDropped") || !(this.Context is ISessionRegistry context2))
            break;
          string strComponentId = objEvent["DPC"];
          if (string.IsNullOrEmpty(strComponentId) || !(context2.GetRegisteredComponent(strComponentId) is Control registeredComponent1))
            break;
          this.OnControlDropped(new ControlEventArgs(registeredComponent1));
          break;
        case 1348012936:
          if (!(type == "CEM"))
            break;
          if (objEvent["Attr.CancelEditingMode"] == "1")
          {
            this.SetEditControlMode(EditMode.Off, true);
            break;
          }
          this.ProcessEditModeValue(objEvent);
          break;
        case 1492555103:
          if (!(type == "VisualTemplate") || this.VisualTemplate == null)
            break;
          this.VisualTemplate.FireEvent(this, objEvent);
          break;
        case 2104694088:
          if (!(type == "ContextualToolbarEditor"))
            break;
          Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.FireEvent((Component) this, objEvent);
          break;
        case 2133600820:
          if (!(type == "Move"))
            break;
          double dblValue2 = -1.0;
          double dblValue3 = -1.0;
          if (!CommonUtils.TryParse(objEvent["Left"], out dblValue2) || !CommonUtils.TryParse(objEvent["Top"], out dblValue3) || !this.SetBounds(Convert.ToInt32(dblValue2), Convert.ToInt32(dblValue3), 0, 0, BoundsSpecified.Location, true))
            break;
          this.OnLocationChangedInternal(new LayoutEventArgs(true, false, true));
          break;
        case 2209454968:
          if (!(type == "KeyDown"))
            break;
          this.FireKeyDown(objEvent);
          break;
        case 2950315936:
          if (!(type == "DoubleClick"))
            break;
          this.OnClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          this.OnDoubleClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 2, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
        case 3601960571:
          if (!(type == "GotFocus"))
            break;
          IContainerControl containerControlInternal2 = this.GetContainerControlInternal();
          if (containerControlInternal2 != null && containerControlInternal2.ActiveControl != this)
          {
            containerControlInternal2.ActivateControl(this);
            this.OnGotFocus(EventArgs.Empty);
          }
          if (!(this.Context is IApplicationContext context3))
            break;
          context3.SetFocused((IControl) this, false);
          break;
        case 4107793895:
          if (!(type == "ControlSelected") || !(this.Context is ISessionRegistry context4))
            break;
          string str = objEvent["SE"];
          if (string.IsNullOrEmpty(str))
            break;
          string[] strArray = str.Split(',');
          if (strArray.Length == 0)
            break;
          Control[] objControl = new Control[strArray.Length];
          for (int index = 0; index < strArray.Length; ++index)
          {
            if (context4.GetRegisteredComponent(strArray[index]) is Control registeredComponent2)
              objControl[index] = registeredComponent2;
          }
          this.OnControlsSelected(new ControlsEventArgs(objControl));
          break;
      }
    }

    /// <summary>Sets the edit control mode.</summary>
    /// <param name="enmEditMode">The enm edit mode.</param>
    /// <param name="blnFromClient">if set to <c>true</c> [BLN from client].</param>
    private void SetEditControlMode(EditMode enmEditMode, bool blnFromClient)
    {
      if (this.menmEditMode == enmEditMode)
        return;
      this.menmEditMode = enmEditMode;
      if (blnFromClient)
        return;
      this.Update();
    }

    /// <summary>Processes the edit mode value.</summary>
    /// <param name="objEvent">The object event.</param>
    private void ProcessEditModeValue(IEvent objEvent)
    {
      EditValueEditingEventArgs objEditValueEditingEventArgs = new EditValueEditingEventArgs(objEvent);
      this.OnEditValueEditing(objEditValueEditingEventArgs);
      if (!objEditValueEditingEventArgs.Cancel)
        this.CommitValueEditing(objEditValueEditingEventArgs.FormattedValue);
      this.EditControlMode = objEditValueEditingEventArgs.ExitEditMode ? EditMode.Off : EditMode.On;
    }

    /// <summary>Commits the value editing.</summary>
    /// <param name="objFormattedValue">The object formatted value.</param>
    protected virtual void CommitValueEditing(object objFormattedValue)
    {
    }

    /// <summary>
    /// Raises the <see cref="E:EditValueEditing" /> event.
    /// </summary>
    /// <param name="objEditValueEditingEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.EditValueEditingEventArgs" /> instance containing the event data.</param>
    protected internal virtual void OnEditValueEditing(
      EditValueEditingEventArgs objEditValueEditingEventArgs)
    {
      if (!(this.GetHandler(Control.ControlEditingEvent) is EventHandler<EditValueEditingEventArgs> handler))
        return;
      handler((object) this, objEditValueEditingEventArgs);
    }

    /// <summary>Fires the control added event.</summary>
    /// <param name="objControl">Added control.</param>
    internal void FireControlAdded(Control objControl)
    {
      if (this.ControlAddedHandler == null)
        return;
      this.ControlAddedHandler((object) this, new ControlEventArgs(objControl));
    }

    /// <summary>Fires the control removed event.</summary>
    /// <param name="objControl">Removed control.</param>
    internal void FireControlRemoved(Control objControl)
    {
      if (this.ControlRemovedHandler == null)
        return;
      this.ControlRemovedHandler((object) this, new ControlEventArgs(objControl));
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
    /// event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnClick(EventArgs objEventArgs)
    {
      if (!(objEventArgs is MouseEventArgs e))
        e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
      this.OnMouseDown(e);
      if (e.Button == MouseButtons.Left || this.ShouldRaiseClickOnRightMouseDown)
        this.OnMouseClick(e);
      this.OnMouseUp(e);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlAdded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnControlAdded(ControlEventArgs e)
    {
      if (!this.DesignMode && e.Control != null)
        e.Control.ApplyPreReleaseDockFillCompatibility();
      ControlEventHandler controlAddedHandler = this.ControlAddedHandler;
      if (controlAddedHandler == null)
        return;
      controlAddedHandler((object) this, e);
    }

    /// <summary>Applies the pre release dock fill compatibility.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected internal virtual void ApplyPreReleaseDockFillCompatibility()
    {
      if (!this.IsFillDocked(this.Dock) || this.Context == null || !this.Context.Config.IsFeatureEnabled("PreReleaseDockFillCompatibility", false))
        return;
      this.BringToFront();
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnParentChanged(EventArgs e)
    {
      EventHandler parentChangedHandler = this.ParentChangedHandler;
      if (parentChangedHandler == null)
        return;
      parentChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CursorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnCursorChanged(EventArgs e)
    {
      EventHandler cursorChangedHandler = this.CursorChangedHandler;
      if (cursorChangedHandler == null)
        return;
      cursorChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlsSelected" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlsEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnControlsSelected(ControlsEventArgs e)
    {
      ControlsEventHandler controlSelectedHandler = this.ControlSelectedHandler;
      if (controlSelectedHandler == null)
        return;
      controlSelectedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlDropped" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnControlDropped(ControlEventArgs e)
    {
      ControlEventHandler controlDroppedHandler = this.ControlDroppedHandler;
      if (controlDroppedHandler == null)
        return;
      controlDroppedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Leave"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLeave(EventArgs e)
    {
      EventHandler leaveHandler = this.LeaveHandler;
      if (leaveHandler == null)
        return;
      leaveHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Enter"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnEnter(EventArgs e)
    {
      EventHandler enterHandler = this.EnterHandler;
      if (enterHandler == null)
        return;
      enterHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    protected virtual void OnKeyDown(KeyEventArgs e)
    {
      KeyEventHandler keyDownHandler = this.KeyDownHandler;
      if (keyDownHandler == null)
        return;
      keyDownHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyPress"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnKeyPress(KeyPressEventArgs e)
    {
      KeyPressEventHandler keyPressHandler = this.KeyPressHandler;
      if (keyPressHandler == null)
        return;
      keyPressHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Implemented by design as KeyPress(Use KeyPress instead).")]
    protected virtual void OnKeyUp(KeyEventArgs e)
    {
      KeyEventHandler keyUpHandler = this.KeyUpHandler;
      if (keyUpHandler == null)
        return;
      keyUpHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseClick"></see> event.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnMouseClick(MouseEventArgs e)
    {
      EventHandler handler1 = (EventHandler) this.GetHandler(Control.ClickEvent);
      if (handler1 != null)
        handler1((object) this, (EventArgs) e);
      MouseEventHandler handler2 = (MouseEventHandler) this.GetHandler(Control.MouseClickEvent);
      if (handler2 == null)
        return;
      handler2((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
    /// Implemented by design as Click (Use Click instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    protected virtual void OnMouseUp(MouseEventArgs e)
    {
      MouseEventHandler mouseUpHandler = this.MouseUpHandler;
      if (mouseUpHandler == null)
        return;
      mouseUpHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDoubleClick"></see> event.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnMouseDoubleClick(MouseEventArgs e)
    {
      EventHandler doubleClickHandler = this.DoubleClickHandler;
      if (doubleClickHandler == null)
        return;
      doubleClickHandler((object) this, (EventArgs) e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.
    /// Implemented by design as Click (Use Click instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    protected virtual void OnMouseDown(MouseEventArgs e)
    {
      MouseEventHandler mouseDownHandler = this.MouseDownHandler;
      if (mouseDownHandler == null)
        return;
      mouseDownHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlRemoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnControlRemoved(ControlEventArgs e)
    {
      ControlEventHandler controlRemovedHandler = this.ControlRemovedHandler;
      if (controlRemovedHandler == null)
        return;
      controlRemovedHandler((object) this, e);
    }

    /// <summary>Shoulds the perform container validation.</summary>
    /// <returns></returns>
    internal virtual bool ShouldPerformContainerValidation() => this.GetStyle(ControlStyles.ContainerControl);

    /// <summary>
    /// Gets a value indicating whether [should auto validate].
    /// </summary>
    /// <value><c>true</c> if [should auto validate]; otherwise, <c>false</c>.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal bool ShouldAutoValidate => Control.GetAutoValidateForControl(this) != 0;

    /// <summary>Performs the container validation.</summary>
    /// <param name="validationConstraints">The validation constraints.</param>
    /// <returns></returns>
    internal bool PerformContainerValidation(ValidationConstraints validationConstraints)
    {
      bool flag = false;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if ((validationConstraints & ValidationConstraints.ImmediateChildren) != ValidationConstraints.ImmediateChildren && control.ShouldPerformContainerValidation() && control.PerformContainerValidation(validationConstraints))
          flag = true;
        if (((validationConstraints & ValidationConstraints.Selectable) != ValidationConstraints.Selectable || control.GetStyle(ControlStyles.Selectable)) && ((validationConstraints & ValidationConstraints.Enabled) != ValidationConstraints.Enabled || control.Enabled) && ((validationConstraints & ValidationConstraints.Visible) != ValidationConstraints.Visible || control.Visible) && ((validationConstraints & ValidationConstraints.TabStop) != ValidationConstraints.TabStop || control.TabStop) && control.PerformControlValidation(true))
          flag = true;
      }
      return flag;
    }

    /// <summary>Performs the control validation.</summary>
    /// <param name="bulkValidation">if set to <c>true</c> [bulk validation].</param>
    /// <returns></returns>
    internal bool PerformControlValidation(bool bulkValidation)
    {
      if (this.CausesValidation)
      {
        if (this.NotifyValidating())
          return true;
        if (bulkValidation)
        {
          this.NotifyValidated();
        }
        else
        {
          try
          {
            this.NotifyValidated();
          }
          catch (Exception ex)
          {
            Application.OnThreadException(ex);
          }
        }
      }
      return false;
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    internal void OnLocationChangedInternal(LayoutEventArgs objEventArgs)
    {
      if (!objEventArgs.ShouldUpdateParent)
        return;
      this.InvalidateParentLayout(objEventArgs);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLocationChanged(LayoutEventArgs e)
    {
      EventHandler locationChangedHandler = this.LocationChangedHandler;
      if (locationChangedHandler == null)
        return;
      locationChangedHandler((object) this, (EventArgs) e);
    }

    /// <summary>Fires the key down event.</summary>
    /// <param name="objEvent">event.</param>
    internal void FireKeyDown(IEvent objEvent)
    {
      Keys keys = Control.CreateKeys(objEvent);
      this.OnKeyDown(new KeyEventArgs(keys));
      this.OnKeyPress(new KeyPressEventArgs((char) keys));
      this.OnKeyUp(new KeyEventArgs(keys));
      if (this.HelpRequestedHandler == null || keys != Keys.F1)
        return;
      this.OnHelpRequested(new HelpEventArgs(new Point(0, 0)));
    }

    /// <summary>Creates keys from event.</summary>
    internal static Keys CreateKeys(IEvent objEvent)
    {
      Keys keyCode = objEvent.KeyCode;
      if (objEvent.AltKey)
        keyCode |= Keys.Alt;
      if (objEvent.ControlKey)
        keyCode |= Keys.Control;
      if (objEvent.ShiftKey)
        keyCode |= Keys.Shift;
      return keyCode;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("Click"))
        clientEventsData.Set("CL");
      if (this.HasClientHandler("DoubleClick"))
        clientEventsData.Set("DCL");
      if (this.HasClientHandler("KeyDown"))
        clientEventsData.Set("KD");
      if (this.HasClientHandler("GotFocus"))
        clientEventsData.Set("GF");
      if (this.HasClientHandler("LostFocus"))
        clientEventsData.Set("LF");
      return clientEventsData;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.HasHandler(Control.ClickEvent) || this.HasHandler(Control.MouseClickEvent) || this.HasHandler(Control.MouseDownEvent) || this.HasHandler(Control.MouseUpEvent))
      {
        criticalEventsData.Set("CL");
        if (this.ShouldRaiseClickOnRightMouseDown)
          criticalEventsData.Set("RC");
      }
      if (this.DoubleClickHandler != null)
        criticalEventsData.Set("DCL");
      if (this.KeyDownHandler != null)
        criticalEventsData.Set("KD");
      if (this.KeyUpHandler != null)
        criticalEventsData.Set("KD");
      if (this.KeyPressHandler != null)
        criticalEventsData.Set("KD");
      if (this.SupportsFocusEvents)
      {
        if (this.GotFocusHandler != null)
          criticalEventsData.Set("GF");
        if (this.LostFocusHandler != null)
          criticalEventsData.Set("LF");
      }
      if (this.TextChangedHandler != null || this.ValidatingHandler != null || this.ValidatedHandler != null)
        criticalEventsData.Set("VC");
      if (this.ResizeHandler != null || this.ParentInternal != null && this.ParentInternal.AutoSize)
        criticalEventsData.Set("SC");
      if (this.LocationChangedHandler != null)
        criticalEventsData.Set("LC");
      if (this.EnterHandler != null)
        criticalEventsData.Set("EN");
      if (this.LeaveHandler != null)
        criticalEventsData.Set("LE");
      criticalEventsData.Set(this.GetProxyPropertyValue<CriticalEventsData>(nameof (GetCriticalEventsData), criticalEventsData));
      return criticalEventsData;
    }

    /// <summary>Gets the auto validate for control.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    internal static AutoValidate GetAutoValidateForControl(Control objControl)
    {
      ContainerControl containerControl = objControl.ParentContainerControl;
      return containerControl == null ? AutoValidate.EnablePreventFocusChange : containerControl.AutoValidate;
    }

    protected internal void RenderMinMaxSizeAttributes(
      IContext objContext,
      IAttributeWriter objWriter)
    {
      Size size1 = this.MinimumSize;
      int width1 = size1.Width;
      size1 = this.DefaultMinimumSize;
      int width2 = size1.Width;
      if (width1 != width2)
        objWriter.WriteAttributeString("MNW", this.MinimumSize.Width.ToString());
      Size size2 = this.MinimumSize;
      int height1 = size2.Height;
      size2 = this.DefaultMinimumSize;
      int height2 = size2.Height;
      if (height1 != height2)
        objWriter.WriteAttributeString("MNH", this.MinimumSize.Height.ToString());
      Size size3 = this.MaximumSize;
      int width3 = size3.Width;
      size3 = this.DefaultMaximumSize;
      int width4 = size3.Width;
      if (width3 != width4)
        objWriter.WriteAttributeString("MXW", this.MaximumSize.Width.ToString());
      Size size4 = this.MaximumSize;
      int height3 = size4.Height;
      size4 = this.DefaultMaximumSize;
      int height4 = size4.Height;
      if (height3 == height4)
        return;
      objWriter.WriteAttributeString("MXH", this.MaximumSize.Height.ToString());
    }

    /// <summary>Renders the theme.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected virtual void RenderThemeAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (!VWGContext.Current.SupportsMultipleThemes)
        return;
      string proxyPropertyValue = this.GetProxyPropertyValue<string>("Theme", this.Theme);
      if (!(proxyPropertyValue != "Inherit" | blnForceRender))
        return;
      objWriter.WriteAttributeString("TH", proxyPropertyValue != "Inherit" ? proxyPropertyValue : string.Empty);
    }

    /// <summary>Renders positioning</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderPositioning(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (!this.HasPositioning)
        return;
      this.RenderMinMaxSizeAttributes(objContext, objWriter);
      if (this.Parent is FlowLayoutPanel)
      {
        this.RenderWidth(objContext, objWriter);
        this.RenderHeight(objContext, objWriter);
      }
      else
      {
        DockStyle proxyPropertyValue = this.GetProxyPropertyValue<DockStyle>("Dock", this.Dock);
        if (proxyPropertyValue == DockStyle.None)
          this.RenderAnchoring(objContext, objWriter, this.GetProxyPropertyValue<AnchorStyles>("Anchor", this.Anchor), false);
        else if (blnForceRender)
          this.RenderAnchoring(objContext, objWriter, AnchorStyles.None, true);
        this.RenderDocking(objContext, objWriter, proxyPropertyValue, blnForceRender);
      }
    }

    /// <summary>Renders the docking.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="enmDockStyle">The dock style.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected virtual void RenderDocking(
      IContext objContext,
      IAttributeWriter objWriter,
      DockStyle enmDockStyle,
      bool blnForceRender)
    {
      switch (enmDockStyle)
      {
        case DockStyle.Fill:
          objWriter.WriteAttributeString("D", "F");
          break;
        case DockStyle.Top:
          objWriter.WriteAttributeString("D", "T");
          this.RenderHeight(objContext, objWriter);
          break;
        case DockStyle.Right:
          objWriter.WriteAttributeString("D", objContext.ShouldApplyMirroring ? "L" : "R");
          this.RenderWidth(objContext, objWriter);
          break;
        case DockStyle.Bottom:
          objWriter.WriteAttributeString("D", "B");
          this.RenderHeight(objContext, objWriter);
          break;
        case DockStyle.Left:
          objWriter.WriteAttributeString("D", objContext.ShouldApplyMirroring ? "R" : "L");
          this.RenderWidth(objContext, objWriter);
          break;
        default:
          if (!blnForceRender)
            break;
          objWriter.WriteAttributeString("D", string.Empty);
          break;
      }
    }

    /// <summary>Renders the anchoring.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="enmAnchorStyle">The anchor style.</param>
    /// <param name="blnForceEmptyRender">if set to <c>true</c> [BLN force empty render].</param>
    protected virtual void RenderAnchoring(
      IContext objContext,
      IAttributeWriter objWriter,
      AnchorStyles enmAnchorStyle,
      bool blnForceEmptyRender)
    {
      string empty = string.Empty;
      if (!blnForceEmptyRender)
      {
        bool flag1 = this.Parent is TableLayoutPanel;
        bool flag2 = false;
        bool flag3 = false;
        Point proxyPropertyValue = this.GetProxyPropertyValue<Point>("Location", new Point(this.mintLeft, this.mintTop));
        int num;
        if (this.IsLeftAnchored(enmAnchorStyle))
        {
          empty += "L";
          IAttributeWriter attributeWriter = objWriter;
          string strValue;
          if (!flag1)
          {
            num = proxyPropertyValue.X;
            strValue = num.ToString();
          }
          else
            strValue = "0";
          attributeWriter.WriteAttributeString("L", strValue);
          flag2 = true;
        }
        if (this.IsRightAnchored(enmAnchorStyle))
        {
          empty += "R";
          IAttributeWriter attributeWriter = objWriter;
          string strValue;
          if (!flag1)
          {
            num = this.LayoutRight;
            strValue = num.ToString();
          }
          else
            strValue = "0";
          attributeWriter.WriteAttributeString("R", strValue);
          flag2 = true;
        }
        if (this.IsTopAnchored(enmAnchorStyle))
        {
          empty += "T";
          IAttributeWriter attributeWriter = objWriter;
          string strValue;
          if (!flag1)
          {
            num = proxyPropertyValue.Y;
            strValue = num.ToString();
          }
          else
            strValue = "0";
          attributeWriter.WriteAttributeString("T", strValue);
          flag3 = true;
        }
        if (this.IsBottomAnchored(enmAnchorStyle))
        {
          empty += "B";
          IAttributeWriter attributeWriter = objWriter;
          string strValue;
          if (!flag1)
          {
            num = this.LayoutBottom;
            strValue = num.ToString();
          }
          else
            strValue = "0";
          attributeWriter.WriteAttributeString("B", strValue);
          flag3 = true;
        }
        if (!flag2)
        {
          empty += "H";
          IAttributeWriter attributeWriter = objWriter;
          num = this.CenteredLeft;
          string strValue = num.ToString();
          attributeWriter.WriteAttributeString("L", strValue);
        }
        if (!flag3)
        {
          empty += "V";
          IAttributeWriter attributeWriter = objWriter;
          num = this.CenteredTop;
          string strValue = num.ToString();
          attributeWriter.WriteAttributeString("T", strValue);
        }
        this.RenderHeight(objContext, objWriter);
        this.RenderWidth(objContext, objWriter);
      }
      objWriter.WriteAttributeString("A", empty);
    }

    /// <summary>Renders the height.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <remarks>This is a preliminary interface and is subject for change.</remarks>
    internal virtual void RenderHeight(IContext objContext, IAttributeWriter objWriter)
    {
      Size proxyPropertyValue = this.GetProxyPropertyValue<Size>("Size", new Size(0, this.GetCalculatedHeight(false)));
      objWriter.WriteAttributeString("H", proxyPropertyValue.Height.ToString());
    }

    /// <summary>Renders the width.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <remarks>This is a preliminary interface and is subject for change.</remarks>
    internal virtual void RenderWidth(IContext objContext, IAttributeWriter objWriter)
    {
      Size proxyPropertyValue = this.GetProxyPropertyValue<Size>("Size", new Size(this.GetCalculatedWidth(false), 0));
      objWriter.WriteAttributeString("W", proxyPropertyValue.Width.ToString());
    }

    /// <summary>Gets the container control</summary>
    /// <returns></returns>
    internal IContainerControl GetContainerControlInternal()
    {
      Control objControl = this;
      if (objControl != null && this.IsContainerControl)
        objControl = objControl.ParentInternal;
      while (objControl != null && !Control.IsFocusManagingContainerControl(objControl))
        objControl = objControl.ParentInternal;
      return (IContainerControl) objControl;
    }

    /// <summary>Gets a flag indicating if a control can manage focus</summary>
    /// <param name="objControl">The obj control.</param>
    /// <returns>
    /// 	<c>true</c> if [is focus managing container control] [the specified obj control]; otherwise, <c>false</c>.
    /// </returns>
    private static bool IsFocusManagingContainerControl(Control objControl) => (objControl.menmControlStyle & ControlStyles.ContainerControl) == ControlStyles.ContainerControl && objControl is IContainerControl;

    /// <summary>Gets a flag indicating if this is a container control</summary>
    internal virtual bool IsContainerControl => false;

    /// <summary>Gets a value indicating whether the control, or one of its child controls, currently has the input focus.</summary>
    /// <returns>true if the control or one of its child controls currently has the input focus; otherwise, false.</returns>
    [SRDescription("ControlContainsFocusDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool ContainsFocus
    {
      get
      {
        IContext context = this.Context;
        if (context != null && context.ActiveForm is Form activeForm)
        {
          if (this == activeForm)
            return true;
          Control activeControl = activeForm.ActiveControl;
          if (activeControl != null)
            return this == activeControl || this.Contains(activeControl);
        }
        return false;
      }
    }

    /// <summary>Gets a value indicating whether the control has input focus.</summary>
    /// <returns>true if the control has focus; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [SRDescription("ControlFocusedDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Focused => this.Context is IApplicationContext context && context.IsFocused((IControl) this);

    /// <summary>Sets focus to this control</summary>
    /// <returns></returns>
    public bool Focus()
    {
      Form form = this.Form;
      return form != null && form.Visible && !form.HasModalWindows && this.FocusInternal();
    }

    /// <summary>Focuses the internal.</summary>
    /// <returns></returns>
    internal virtual bool FocusInternal()
    {
      if (this.CanFocus && VWGContext.Current is IApplicationContext current && current.GetFocused() != this)
      {
        current.SetFocused((IControl) this, true);
        this.OnGotFocus(EventArgs.Empty);
      }
      if (this.Focused && this.ParentInternal != null)
      {
        IContainerControl containerControlInternal = this.ParentInternal.GetContainerControlInternal();
        if (containerControlInternal != null)
        {
          if (containerControlInternal is ContainerControl)
            ((ContainerControl) containerControlInternal).SetActiveControlInternal(this);
          else
            containerControlInternal.ActiveControl = this;
        }
      }
      return this.Focused;
    }

    /// <summary>Notifies the validated.</summary>
    private void NotifyValidated() => this.OnValidated(EventArgs.Empty);

    /// <summary>Notifies the validation result.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="ev">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
    internal virtual void NotifyValidationResult(object sender, CancelEventArgs ev) => this.ValidationCancelled = ev.Cancel;

    /// <summary>Notifies the validating.</summary>
    /// <returns></returns>
    private bool NotifyValidating()
    {
      CancelEventArgs e = new CancelEventArgs();
      this.OnValidating(e);
      return e.Cancel;
    }

    /// <summary>Raises the enter event</summary>
    internal void NotifyEnter() => this.OnEnter(EventArgs.Empty);

    /// <summary>Raises the leave event</summary>
    internal void NotifyLeave() => this.OnLeave(EventArgs.Empty);

    /// <summary>Invalidates the entire surface of the control and causes the control to be redrawn.</summary>
    public void Invalidate() => this.Invalidate(false);

    /// <summary>Invalidates a specific region of the control and causes a paint message to be sent to the control. Optionally, invalidates the child controls assigned to the control.</summary>
    public void Invalidate(bool blnInvalidateChildren) => this.Update();

    /// <summary>Activates the control.</summary>
    public void Select() => this.Select(false, false);

    /// <summary>
    ///  Activates a child control. Optionally specifies the direction in the tab order to select the control from.
    /// </summary>
    protected virtual void Select(bool blnDirected, bool blnForward)
    {
      IContainerControl containerControlInternal = this.GetContainerControlInternal();
      if (containerControlInternal == null)
        return;
      containerControlInternal.ActiveControl = this;
    }

    /// <summary>Activates the next control.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="blnForward">if set to <c>true</c> [BLN forward].</param>
    /// <param name="blnTabStopOnly">if set to <c>true</c> [BLN tab stop only].</param>
    /// <param name="blnNested">if set to <c>true</c> [BLN nested].</param>
    /// <param name="blnWrap">if set to <c>true</c> [BLN wrap].</param>
    /// <returns>true if a control was activated; otherwise, false.</returns>
    public bool SelectNextControl(
      Control objControl,
      bool blnForward,
      bool blnTabStopOnly,
      bool blnNested,
      bool blnWrap)
    {
      if (!this.Contains(objControl) || !blnNested && objControl.Parent != this)
        objControl = (Control) null;
      bool flag = false;
      Control control = objControl;
      do
      {
        objControl = this.GetNextControl(objControl, blnForward);
        if (objControl == null)
        {
          if (blnWrap && !flag)
            flag = true;
          else
            break;
        }
        else if (objControl.CanSelect && (!blnTabStopOnly || objControl.TabStop) && (blnNested || objControl.Parent == this))
        {
          objControl.Select(true, blnForward);
          return true;
        }
      }
      while (objControl != control);
      return false;
    }

    /// <devdoc>
    ///     Unsafe internal version of SelectNextControl - Use with caution!
    /// </devdoc>
    internal bool SelectNextControlInternal(
      Control objControl,
      bool blnForward,
      bool blnTabStopOnly,
      bool blnNested,
      bool blnWrap)
    {
      return this.SelectNextControl(objControl, blnForward, blnTabStopOnly, blnNested, blnWrap);
    }

    /// <summary>Updates the params internally.</summary>
    /// <param name="enmType">Type of the enm.</param>
    internal void UpdateParamsInternal(AttributeType enmType) => this.UpdateParams(enmType);

    /// <summary>Finds the form internal.</summary>
    /// <returns></returns>
    internal Form FindFormInternal()
    {
      Control formInternal = this;
      while (true)
      {
        switch (formInternal)
        {
          case null:
          case Form _:
            goto label_3;
          default:
            formInternal = formInternal.ParentInternal;
            continue;
        }
      }
label_3:
      return (Form) formInternal;
    }

    /// <summary>Finds the form.</summary>
    /// <returns></returns>
    public Form FindForm() => this.FindFormInternal();

    /// <summary>
    /// Raises the <see cref="E:EnabledChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnEnabledChanged(EventArgs e)
    {
      EventHandler enabledChangedHandler = this.EnabledChangedHandler;
      if (enabledChangedHandler == null)
        return;
      enabledChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:TextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTextChanged(EventArgs e)
    {
      EventHandler textChangedHandler = this.TextChangedHandler;
      if (textChangedHandler != null)
        textChangedHandler((object) this, e);
      this.OnTextChangedQueued(e);
    }

    /// <summary>Raise TextChangedQueued event</summary>
    /// <param name="e"></param>
    protected virtual void OnTextChangedQueued(EventArgs e)
    {
      EventHandler changedQueuedHandler = this.TextChangedQueuedHandler;
      if (changedQueuedHandler == null)
        return;
      changedQueuedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DoubleClick"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDoubleClick(EventArgs e)
    {
      EventHandler doubleClickHandler = this.DoubleClickHandler;
      if (doubleClickHandler == null)
        return;
      doubleClickHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnFontChanged(EventArgs e)
    {
      EventHandler fontChangedHandler = this.FontChangedHandler;
      if (fontChangedHandler == null)
        return;
      fontChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ForeColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnForeColorChanged(EventArgs e)
    {
      EventHandler colorChangedHandler = this.ForeColorChangedHandler;
      if (colorChangedHandler == null)
        return;
      colorChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleCreated"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnHandleCreated(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleDestroyed"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnHandleDestroyed(EventArgs e)
    {
    }

    /// <summary>Childs the got focus.</summary>
    /// <param name="objChild">The child.</param>
    private void ChildGotFocus(Control objChild)
    {
      if (this.Parent == null)
        return;
      this.Parent.ChildGotFocus(objChild);
    }

    /// <summary>
    /// Raises the <see cref="E:GotFocus" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected internal virtual void OnGotFocus(EventArgs e)
    {
      if (this.Parent != null)
        this.Parent.ChildGotFocus(this);
      EventHandler gotFocusHandler = this.GotFocusHandler;
      if (gotFocusHandler == null)
        return;
      gotFocusHandler((object) this, new EventArgs());
    }

    /// <summary>
    /// Raises the <see cref="E:LostFocus" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnLostFocus(EventArgs e)
    {
      EventHandler lostFocusHandler = this.LostFocusHandler;
      if (lostFocusHandler == null)
        return;
      lostFocusHandler((object) this, new EventArgs());
    }

    /// <summary>Displays the control to the user.</summary>
    public virtual void Show() => this.Visible = true;

    /// <summary>Conceals the control from the user.</summary>
    public void Hide() => this.Visible = false;

    /// <summary>Sets the control minimum size by updating its bounds.</summary>
    /// <param name="element">The element.</param>
    /// <param name="objValue">The value.</param>
    internal void SetMinimumSize(IArrangedElement objElement, Size objValue)
    {
      Rectangle bounds = objElement.Bounds;
      if (objValue.Width > 0)
        bounds.Width = Math.Max(bounds.Width, objValue.Width);
      if (objValue.Height <= 0)
        return;
      bounds.Height = Math.Max(bounds.Height, objValue.Height);
      objElement.SetBounds(bounds, BoundsSpecified.Size);
    }

    /// <summary>Sets the maximum size by updating its bounds.</summary>
    /// <param name="objElement">The element.</param>
    /// <param name="objValue">The value.</param>
    internal void SetMaximumSize(IArrangedElement objElement, Size objValue)
    {
      Rectangle bounds = objElement.Bounds;
      if (objValue.Width > 0)
        bounds.Width = Math.Min(bounds.Width, objValue.Width);
      if (objValue.Height > 0)
        bounds.Height = Math.Min(bounds.Height, objValue.Height);
      objElement.SetBounds(bounds, BoundsSpecified.Size);
    }

    /// <summary>Refreshes this instance.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void Refresh()
    {
    }

    /// <summary>Begins a drag-and-drop operation.</summary>
    /// <returns>A value from the <see cref="T:System.Windows.Forms.DragDropEffects"></see> enumeration that represents the final effect that was performed during the drag-and-drop operation.</returns>
    /// <param name="data">The data to drag. </param>
    /// <param name="allowedEffects">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects) => DragDropEffects.None;

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objProposedSize">Size of the obj proposed.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual Size GetPreferredSize(Size objProposedSize) => this.GetPreferredSize(objProposedSize, false);

    /// <summary>Gets the preferred size or the client minimum size.</summary>
    /// <param name="objProposedSize">The proposed size.</param>
    /// <param name="blnIsClientMinimumSize">if set to <c>true</c> [BLN is client minimum size].</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual Size GetPreferredSize(Size objProposedSize, bool blnIsClientMinimumSize)
    {
      int val1_1 = 0;
      int val1_2 = 0;
      int val2_1 = 0;
      int val2_2 = 0;
      int val1_3 = 0;
      int val1_4 = 0;
      if (this.mobjControls != null)
      {
        int count = this.mobjControls.Count;
        if (count > 0)
        {
          for (int index = count - 1; index >= 0; --index)
          {
            Control mobjControl = this.mobjControls[index];
            Size preferredSize;
            if (mobjControl.Visible)
            {
              switch (mobjControl.Dock)
              {
                case DockStyle.None:
                  AnchorStyles anchor = mobjControl.Anchor;
                  if (!mobjControl.IsBottomAnchored(anchor) && mobjControl.IsTopAnchored(anchor))
                    val1_1 = Math.Max(val1_1, mobjControl.LayoutTop + mobjControl.Height);
                  if (!mobjControl.IsRightAnchored(anchor) && mobjControl.IsLeftAnchored(anchor))
                  {
                    val1_2 = Math.Max(val1_2, mobjControl.LayoutLeft + mobjControl.Width);
                    continue;
                  }
                  continue;
                case DockStyle.Fill:
                  if (!blnIsClientMinimumSize || mobjControl.AutoSize)
                  {
                    int val1_5 = val1_3;
                    int num1 = val2_1;
                    preferredSize = mobjControl.PreferredSize;
                    int height = preferredSize.Height;
                    int val2_3 = num1 + height;
                    val1_3 = Math.Max(val1_5, val2_3);
                    int val1_6 = val1_4;
                    int num2 = val2_2;
                    preferredSize = mobjControl.PreferredSize;
                    int width = preferredSize.Width;
                    int val2_4 = num2 + width;
                    val1_4 = Math.Max(val1_6, val2_4);
                    continue;
                  }
                  continue;
                case DockStyle.Top:
                case DockStyle.Bottom:
                  val2_1 += mobjControl.Height;
                  if (!blnIsClientMinimumSize || mobjControl.AutoSize)
                  {
                    int val1_7 = val1_4;
                    int num = val2_2;
                    preferredSize = mobjControl.PreferredSize;
                    int width = preferredSize.Width;
                    int val2_5 = num + width;
                    val1_4 = Math.Max(val1_7, val2_5);
                    continue;
                  }
                  continue;
                case DockStyle.Right:
                case DockStyle.Left:
                  val2_2 += mobjControl.Width;
                  if (!blnIsClientMinimumSize || mobjControl.AutoSize)
                  {
                    int val1_8 = val1_3;
                    int num = val2_1;
                    preferredSize = mobjControl.PreferredSize;
                    int height = preferredSize.Height;
                    int val2_6 = num + height;
                    val1_3 = Math.Max(val1_8, val2_6);
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
      return new Size(Math.Max(val1_2, Math.Max(val1_4, val2_2)), Math.Max(val1_1, Math.Max(val1_3, val2_1)));
    }

    /// <summary>Gets the preferred size by auto size mode.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objProposedSize">Size of the obj proposed.</param>
    /// <param name="objPreferredSize">Size of the obj preferred.</param>
    /// <returns></returns>
    protected static Size GetPreferredSizeByAutoSizeMode(
      Control objControl,
      Size objProposedSize,
      Size objPreferredSize)
    {
      if (objControl != null && objControl.AutoSize && objControl.AutoSizeMode == AutoSizeMode.GrowOnly)
      {
        if (objPreferredSize.Width < objProposedSize.Width)
          objPreferredSize.Width = objProposedSize.Width;
        if (objPreferredSize.Height < objProposedSize.Height)
          objPreferredSize.Height = objProposedSize.Height;
      }
      return objPreferredSize;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validating"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnValidating(CancelEventArgs e)
    {
      CancelEventHandler validatingHandler = this.ValidatingHandler;
      if (validatingHandler == null)
        return;
      validatingHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validated"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnValidated(EventArgs e)
    {
      EventHandler validatedHandler = this.ValidatedHandler;
      if (validatedHandler == null)
        return;
      validatedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CausesValidationChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnCausesValidationChanged(EventArgs e)
    {
      EventHandler validationChangedHandler = this.CausesValidationChangedHandler;
      if (validationChangedHandler == null)
        return;
      validationChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.VisibleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnVisibleChanged(EventArgs e)
    {
      bool visible = this.Visible;
      this.DoCreateControl(visible);
      EventHandler visibleChangedHandler = this.VisibleChangedHandler;
      if (visibleChangedHandler != null)
        visibleChangedHandler((object) this, e);
      Control.ControlCollection controls = this.Controls;
      if (controls == null)
        return;
      for (int index = 0; index < controls.Count; ++index)
      {
        Control control = controls[index];
        if (control.Visible)
          control.OnParentVisibleChanged(e);
        if (!visible)
          control.OnParentBecameInvisible();
      }
    }

    /// <summary>Create a control.</summary>
    /// <param name="blnVisible">if set to <c>true</c> [BLN visible].</param>
    protected virtual void DoCreateControl(bool blnVisible)
    {
      if (!(this.ParentInternal != null & blnVisible) || this.Created || !this.ParentInternal.Created)
        return;
      this.CreateControl();
    }

    /// <summary>
    /// Raises the <see cref="E:ParentVisibleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnParentVisibleChanged(EventArgs e)
    {
      if (!this.GetState(Component.ComponentState.Visible))
        return;
      this.OnVisibleChanged(e);
    }

    /// <summary>Called when parent became invisible.</summary>
    internal virtual void OnParentBecameInvisible()
    {
      if (!this.GetState(Component.ComponentState.Visible) || this.mobjControls == null)
        return;
      for (int index = 0; index < this.mobjControls.Count; ++index)
        this.mobjControls[index].OnParentBecameInvisible();
    }

    /// <summary>Supports rendering to the specified bitmap.</summary>
    /// <param name="objBitmap">The bitmap to be drawn to.</param>
    /// <param name="objTargetBounds">The bounds within which the control is rendered.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void DrawToBitmap(Bitmap objBitmap, Rectangle objTargetBounds)
    {
      if (objBitmap == null)
        throw new ArgumentNullException(nameof (objBitmap));
      if (objTargetBounds.Width <= 0 || objTargetBounds.Height <= 0 || objTargetBounds.X < 0 || objTargetBounds.Y < 0)
        throw new ArgumentException(nameof (objTargetBounds));
      int intWidth = Math.Min(this.Width, objTargetBounds.Width);
      int intHeight = Math.Min(this.Height, objTargetBounds.Height);
      using (Bitmap bitmap = this.DrawControl(new ControlRenderingContext(objBitmap.PixelFormat), intWidth, intHeight))
      {
        using (Graphics graphics = Graphics.FromImage((Image) objBitmap))
          graphics.DrawImage((Image) bitmap, objTargetBounds.Location);
      }
    }

    /// <summary>Draws the control and return the cotrol bitmap.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="intWidth">The bitmap width.</param>
    /// <param name="intHeight">The bitmap height.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Bitmap DrawControl(ControlRenderingContext objContext, int intWidth, int intHeight)
    {
      Bitmap bitmap = new Bitmap(intWidth, intHeight, objContext.PixelFormat);
      using (Graphics objGraphics = Graphics.FromImage((Image) bitmap))
        this.DrawControl(objContext, objGraphics);
      return bitmap;
    }

    /// <summary>Draws the control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual void DrawControl(ControlRenderingContext objContext, Graphics objGraphics) => this.GetControlRenderer()?.Render(objContext, objGraphics);

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual ControlRenderer GetControlRenderer() => new ControlRenderer(this);

    /// <summary>Sends to back.</summary>
    public void SendToBack()
    {
      if (this.Parent == null)
        return;
      this.Parent.Controls.SetChildIndex(this, -1);
    }

    /// <summary>Brings the control to the front of the z-order.</summary>
    public void BringToFront()
    {
      if (this.Parent == null)
        return;
      this.Parent.Controls.SetChildIndex(this, 0);
    }

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.</summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        this.SuspendLayout();
        try
        {
          this.ResetBindings();
          if (this.Parent != null)
            this.Parent.Controls.Remove(this);
          Control.ControlCollection controls = this.Controls;
          if (controls != null)
          {
            for (int index = 0; index < controls.Count; ++index)
            {
              Control control = controls[index];
              control.InternalParent = (Component) null;
              control.Dispose();
            }
            this.mobjControls = (Control.ControlCollection) null;
          }
          base.Dispose(blnDisposing);
        }
        finally
        {
          this.ResumeLayout(false);
        }
      }
      else
        base.Dispose(blnDisposing);
    }

    /// <summary>Resets the created flag.</summary>
    protected void ResetCreatedFlag()
    {
      this.SetState(Control.ControlState.Created, false);
      foreach (Control control in (ArrangedElementCollection) this.Controls)
        control.ResetCreatedFlag();
    }

    /// <filterpriority>2</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ResetBindings() => this.DataBindings?.Clear();

    /// <summary>Resets the text.</summary>
    public virtual void ResetText() => this.Text = string.Empty;

    /// <summary>Resets the font.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetFont() => this.Font = (Font) null;

    /// <summary>Resets the color of the fore.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetForeColor() => this.ForeColor = Color.Empty;

    /// <summary>Resets the color of the back.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetBackColor() => this.BackColor = Color.Empty;

    /// <summary>Resets the border style.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetBorderStyle() => this.BorderStyle = this.DefaultBorderStyle;

    /// <summary>Resets the border Color.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetBorderColor() => this.BorderColor = this.DefaultBorderColor;

    /// <summary>Resets the border Width.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetBorderWidth() => this.BorderWidth = this.DefaultBorderWidth;

    /// <summary>Resets the Anchor.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetAnchor() => this.Anchor = AnchorStyles.Left | AnchorStyles.Top;

    /// <summary>Resets the Minimum Size.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetMinimumSize() => this.MinimumSize = this.DefaultMinimumSize;

    /// <summary>Resets the Maximum Size.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetMaximumSize() => this.MaximumSize = this.DefaultMaximumSize;

    /// <summary>Resets the border style.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetPadding() => this.RemoveValue<Padding>(Control.PaddingProperty);

    /// <summary>Resets the border style.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetMargin() => this.RemoveValue<Padding>(Control.MarginProperty);

    /// <summary>Resets the border style.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetSize() => this.Size = this.DefaultSize;

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      this.UnRegisterBatch((ICollection) this.Controls);
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      this.RegisterBatch((ICollection) this.Controls);
    }

    /// <summary>Gets the command text.</summary>
    /// <param name="strText">The STR text.</param>
    /// <returns></returns>
    protected internal string GetCommandText(string strText)
    {
      string input = strText;
      if (!this.DesignMode)
        input = new Regex("(?<![&])&(?![&])").Replace(input, string.Empty).Replace("&&", "&");
      return input;
    }

    /// <summary>Invokes client side selection</summary>
    /// <param name="intStart"></param>
    /// <param name="intLength"></param>
    protected virtual void InvokeSelection(int intStart, int intLength) => this.InvokeMethodWithId("Control_SetSelection", (object) intStart, (object) intLength);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new ControlWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "RecursiveResizeEvent")
        this.UpdateParams(AttributeType.Control);
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objProposedSize">Size of the proposed.</param>
    /// <returns></returns>
    Size IArrangedElement.GetPreferredSize(Size objProposedSize) => this.GetPreferredSize(objProposedSize);

    /// <summary>Gets the children.</summary>
    /// <value>The children.</value>
    ArrangedElementCollection IArrangedElement.Children => (ArrangedElementCollection) this.Controls;

    /// <summary>
    /// Gets a value indicating whether [participates in layout].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [participates in layout]; otherwise, <c>false</c>.
    /// </value>
    bool IArrangedElement.ParticipatesInLayout => this.VisibleIntenal;

    /// <summary>Gets the value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objSerializableProperty">The serializable property.</param>
    /// <returns></returns>
    T IArrangedElement.GetValue<T>(SerializableProperty objSerializableProperty) => this.GetValue<T>(objSerializableProperty);

    /// <summary>Sets the value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objSerializableProperty">The serializable property.</param>
    /// <param name="objValue">The obj value.</param>
    void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue) => this.SetValue<T>(objSerializableProperty, objValue);

    /// <summary>Occurs when [observable suspend layout].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event EventHandler ObservableSuspendLayout
    {
      add => this.AddHandler(Control.ObservableSuspendLayoutEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ObservableSuspendLayoutEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the ObservableSuspendLayout event.
    /// </summary>
    private EventHandler ObservableSuspendLayoutHandler => (EventHandler) this.GetHandler(Control.ObservableSuspendLayoutEvent);

    /// <summary>Occurs when [observable resume layout].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableResumeLayoutHandler ObservableResumeLayout
    {
      add => this.AddHandler(Control.ObservableResumeLayoutEvent, (Delegate) value);
      remove => this.RemoveHandler(Control.ObservableResumeLayoutEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the ObservableResumeLayout event.
    /// </summary>
    private ObservableResumeLayoutHandler ObservableResumeLayoutHandler => (ObservableResumeLayoutHandler) this.GetHandler(Control.ObservableResumeLayoutEvent);

    /// <summary>Creates the graphics.</summary>
    /// <returns></returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Graphics CreateGraphics() => (Graphics) null;

    /// <summary>Gets the create params.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual CreateParams CreateParams => (CreateParams) null;

    /// <summary>Gets a value indicating whether [can edit control].</summary>
    /// <value>
    ///   <c>true</c> if [can edit control]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual bool CanEditControl => false;

    /// <summary>Gets or sets the edit control mode.</summary>
    /// <value>The edit control mode.</value>
    [DefaultValue(EditMode.Off)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public EditMode EditControlMode
    {
      get => this.GetProxyPropertyValue<EditMode>(nameof (EditControlMode), this.menmEditMode);
      set
      {
        if (!this.CanEditControl)
          throw new InvalidOperationException(string.Format("Control of type '{0}' cannot be edited. To edit override the 'CanEditControl' property", (object) this.GetType().FullName));
        this.SetEditControlMode(value, false);
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance can access properties.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance can access properties; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool CanAccessProperties => true;

    /// <summary>Set text without raising any events</summary>
    internal virtual string InternalText
    {
      set
      {
        if (!this.SetValue<string>(Control.TextProperty, value))
          return;
        this.OnTextChanged(EventArgs.Empty);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [becoming active control].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [becoming active control]; otherwise, <c>false</c>.
    /// </value>
    internal bool BecomingActiveControl
    {
      get => this.GetState(Control.ControlState.BecomingActiveControl);
      set => this.SetState(Control.ControlState.BecomingActiveControl, value);
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    [DefaultValue("")]
    [SRCategory("CatAppearance")]
    [SRDescription("ControlTextDescr")]
    [Localizable(true)]
    [Bindable(true)]
    [ProxyBrowsable(true)]
    public virtual string Text
    {
      get => this.GetProxyPropertyValue<string>(nameof (Text), this.GetValue<string>(Control.TextProperty));
      set
      {
        string objValue = value == null ? string.Empty : value;
        if (!this.SetValue<string>(Control.TextProperty, objValue))
          return;
        this.UpdateParams(AttributeType.Control);
        this.OnTextChanged(EventArgs.Empty);
        this.FireObservableItemPropertyChanged(nameof (Text));
      }
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    internal string ToolTip
    {
      get => this.GetValue<string>(Control.ToolTipProperty);
      set
      {
        if (!this.SetValue<string>(Control.ToolTipProperty, value))
          return;
        this.UpdateParams(AttributeType.ToolTip);
        this.FireObservableItemPropertyChanged(nameof (ToolTip));
      }
    }

    /// <summary>Gets the extended tool tip descriptor.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolTipDescriptor ExtendedToolTipDescriptor
    {
      get => this.GetValue<ToolTipDescriptor>(Control.ExtendedToolTipDescriptorProperty);
      set
      {
        if (!this.SetValue<ToolTipDescriptor>(Control.ExtendedToolTipDescriptorProperty, value))
          return;
        this.UpdateParams(AttributeType.ToolTip);
      }
    }

    /// <summary>Gets which multi theme to skip when writing the html.</summary>
    protected virtual ControlSkipMultiTheme SkipMultiTheme => ControlSkipMultiTheme.None;

    /// <summary>Gets the control tag name.</summary>
    /// <remarks>
    /// This property by default reverts to the previous implementation
    /// of setting the TagName property, which is obsolete. To use the newer approach which is
    /// using the MetadataTag attribute do not use the TagName property.
    /// </remarks>
    protected string MetadataTag
    {
      get
      {
        string str = this.GetValue<string>(Control.TagNameProperty);
        return CommonUtils.IsNullOrEmpty(str) ? Metadata.GetTag((object) this) : str;
      }
    }

    /// <summary>Gets or sets the control tag name.</summary>
    [Obsolete("Use MetadataTagAttribute to set tag name or Control.MetadataTag to get tag name.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected string TagName
    {
      get => this.GetValue<string>(Control.TagNameProperty);
      set => this.SetValue<string>(Control.TagNameProperty, value);
    }

    /// <summary>
    /// Gets a value indicating whether to reverse control rendering.
    /// </summary>
    /// <value><c>true</c> if to reverse control rendering; otherwise, <c>false</c>.</value>
    protected virtual bool ReverseControls => false;

    /// <summary>Sets the enabled without update.</summary>
    /// <param name="blnValue">if set to <c>true</c> then control enables.</param>
    /// <returns></returns>
    internal void SetEnabledInternal(bool blnValue)
    {
      if (!this.SetStateWithCheck(Component.ComponentState.Enabled, blnValue))
        return;
      this.OnEnabledChanged(EventArgs.Empty);
      this.FireObservableItemPropertyChanged("Enabled");
    }

    /// <summary>Gets the name of the client component.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override string GetClientComponentName() => this.Name;

    /// <summary>Gets or sets the name associated with this control.</summary>
    [Browsable(false)]
    [DefaultValue("")]
    public string Name
    {
      get
      {
        string name = string.IsNullOrEmpty(this.AccessibleName) ? this.GetValue<string>(Control.NameProperty) : this.AccessibleName;
        if (string.IsNullOrEmpty(name))
        {
          if (this.Site != null)
            name = this.Site.Name;
          if (name == null)
            name = string.Empty;
        }
        return name;
      }
      set
      {
        if (value == null)
          this.SetValue<string>(Control.NameProperty, string.Empty);
        else
          this.SetValue<string>(Control.NameProperty, value);
      }
    }

    /// <summary>
    /// Gets or sets the accessible name associated with this control.
    /// </summary>
    [SRCategory("CatAccessibility")]
    [SRDescription("ControlAccessibleNameDescr")]
    [Localizable(true)]
    [Browsable(true)]
    [DefaultValue("")]
    public string AccessibleName
    {
      get => this.GetValue<string>(Control.AccessibleNameProperty);
      set
      {
        if (!this.SetValue<string>(Control.AccessibleNameProperty, value))
          return;
        this.UpdateParams(AttributeType.Accessibility);
      }
    }

    /// <summary>
    /// Gets or sets the accessible description associated with this control.
    /// </summary>
    [SRCategory("CatAccessibility")]
    [SRDescription("ControlAccessibleDescriptionDescr")]
    [Localizable(true)]
    [Browsable(true)]
    [DefaultValue("")]
    public string AccessibleDescription
    {
      get => this.GetValue<string>(Control.AccessibleDescriptionProperty);
      set
      {
        if (!this.SetValue<string>(Control.AccessibleDescriptionProperty, value))
          return;
        this.UpdateParams(AttributeType.Accessibility);
      }
    }

    /// <summary>Gets the resizable allowed directions.</summary>
    protected virtual string[] ResizableAllowedDirections => (string[]) null;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is resizable.
    /// </summary>
    /// <value>
    ///   <c>true</c> if resizable; otherwise, <c>false</c>.
    /// </value>
    [Description("Properties representing if the control is resizable.")]
    [SRCategory("CatBehavior")]
    public virtual ResizableOptions Resizable
    {
      get
      {
        ResizableOptions resizable = this.ResizableInternal;
        if (resizable == null)
        {
          resizable = new ResizableOptions(false);
          this.Resizable = resizable;
        }
        return resizable;
      }
      set
      {
        value.Owner = (Component) this;
        if (!this.SetValue<ResizableOptions>(Control.ResizableProperty, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>Gets the resizable internally.</summary>
    /// <value>The resizable value.</value>
    private ResizableOptions ResizableInternal => this.GetValue<ResizableOptions>(Control.ResizableProperty);

    /// <summary>Shoulds the serialize draggable.</summary>
    /// <returns></returns>
    private bool ShouldSerializeResizable() => this.Resizable != null && (this.Resizable.IsResizable || !this.Resizable.IsDefault());

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is draggable.
    /// </summary>
    /// <value>
    ///   <c>true</c> if draggable; otherwise, <c>false</c>.
    /// </value>
    [Description("Properties representing if the control is draggable.")]
    [SRCategory("CatBehavior")]
    public virtual DraggableOptions Draggable
    {
      get
      {
        DraggableOptions draggable = this.DraggableInternal;
        if (draggable == null)
        {
          draggable = new DraggableOptions(false);
          this.Draggable = draggable;
        }
        return draggable;
      }
      set
      {
        value.Owner = (Component) this;
        if (!this.SetValue<DraggableOptions>(Control.DraggableProperty, value))
          return;
        this.UpdateParams(AttributeType.Drag);
      }
    }

    /// <summary>Gets the draggable internally.</summary>
    /// <value>The draggable value.</value>
    private DraggableOptions DraggableInternal => this.GetValue<DraggableOptions>(Control.DraggableProperty);

    /// <summary>Shoulds the serialize draggable.</summary>
    /// <returns></returns>
    private bool ShouldSerializeDraggable() => this.Draggable != null && (this.Draggable.IsDraggable || !this.Draggable.IsDefault());

    /// <summary>
    /// Gets a value indicating whether this instance can focus.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance can focus; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public virtual bool CanFocus => this.Enabled && this.Visible;

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected virtual bool Focusable => false;

    /// <summary>Gets a value indicating whether the control can be selected.</summary>
    /// <returns>true if the control can be selected; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatFocus")]
    [SRDescription("ControlCanSelectDescr")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool CanSelect => this.CanSelectCore();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal virtual bool CanSelectCore()
    {
      if ((this.menmControlStyle & ControlStyles.Selectable) != ControlStyles.Selectable)
        return false;
      for (Control control = this; control != null; control = control.Parent)
      {
        if (!control.Enabled || !control.Visible)
          return false;
      }
      return true;
    }

    /// <summary>Retrieves the value of the specified control style bit for the control.</summary>
    /// <returns>true if the specified control style bit is set to true; otherwise, false.</returns>
    /// <param name="enmflag">The <see cref="T:Gizmox.WebGUI.Forms.ControlStyles"></see> bit to return the value from. </param>
    protected bool GetStyle(ControlStyles enmflag) => (this.menmControlStyle & enmflag) == enmflag;

    /// <summary>Sets the specified style bit to the specified value.</summary>
    /// <param name="enmFlag">The <see cref="T:Gizmox.WebGUI.Forms.ControlStyles"></see> bit to set. </param>
    /// <param name="blnValue">true to apply the specified style to the control; otherwise, false. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void SetStyle(ControlStyles enmFlag, bool blnValue)
    {
      ControlStyles menmControlStyle = this.menmControlStyle;
      this.menmControlStyle = blnValue ? menmControlStyle | enmFlag : menmControlStyle & ~enmFlag;
    }

    /// <summary>Gets the default font of the control.</summary>
    /// <returns>The default <see cref="T:System.Drawing.Font"></see> of the control. The value returned will vary depending on the user's operating system the local culture setting of their system.</returns>
    /// <exception cref="T:System.ArgumentException">The default font or the regional alternative fonts are not installed on the client computer. </exception>
    /// <filterpriority>1</filterpriority>
    public static Font DefaultFont => ThemeFonts.DefaultFont;

    /// <summary>
    /// Gets a value indicating whether [supports focus events].
    /// </summary>
    /// <value><c>true</c> if [supports focus events]; otherwise, <c>false</c>.</value>
    protected internal virtual bool SupportsFocusEvents => true;

    /// <summary>Gets or sets the registered timers.</summary>
    /// <value>The registered timers.</value>
    [DefaultValue(null)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Timer[] RegisteredTimers
    {
      get => this.GetValue<Timer[]>(Control.RegisteredTimersProperty);
      set => this.SetValue<Timer[]>(Control.RegisteredTimersProperty, value);
    }

    /// <summary>Gets a value indicating whether [use preferred size].</summary>
    /// <value><c>true</c> if [use preferred size]; otherwise, <c>false</c>.</value>
    protected internal virtual bool UsePreferredSize => this.AutoSize;

    /// <summary>Gets the modifier keys.</summary>
    /// <value>The modifier keys.</value>
    public static Keys ModifierKeys => VWGContext.Current is IContextParams current ? current.ModifierKeys : Keys.None;

    /// <summary>Gets or sets the IME mode.</summary>
    /// <value>The IME mode.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImeMode ImeMode
    {
      get => this.GetValue<ImeMode>(Control.ImeModeProperty);
      set => this.SetValue<ImeMode>(Control.ImeModeProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether this control should redraw its surface using a secondary buffer to reduce or prevent flicker.</summary>
    /// <returns>true if the surface of the control should be drawn using double buffering; otherwise, false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [SRDescription("ControlDoubleBufferedDescr")]
    protected virtual bool DoubleBuffered
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets the top level control.</summary>
    [SRCategory("CatBehavior")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlTopLevelControlDescr")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Control TopLevelControl => this.TopLevelControlInternal;

    /// <summary>Gets the client rectangle.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rectangle ClientRectangle => new Rectangle(this.Location, this.ClientSize);

    /// <summary>
    /// Gets a value indicating whether [supports key navigation].
    /// </summary>
    /// <value>
    /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool SupportsKeyNavigation => true;

    /// <summary>
    /// Check if the DragTargets property should be serialized in designtime
    /// </summary>
    private new bool ShouldSerializeDragTargets() => this.DragTargets.Length != 0;

    /// <summary>
    /// Gets a value indicating whether this instance has tab index.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has tab index; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool HasTabIndex => this.mintTabIndex != -1;

    /// <summary>
    /// Gets a value indicating whether this instance is defined for tabbing as group.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is tab for group; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool EnableGroupTabbing => false;

    /// <summary>
    /// Gets or sets a value indicating whether [visible intenal].
    /// </summary>
    /// <value><c>true</c> if [visible intenal]; otherwise, <c>false</c>.</value>
    internal bool VisibleIntenal
    {
      get => this.GetState(Component.ComponentState.Visible);
      set => this.SetState(Component.ComponentState.Visible, value);
    }

    /// <summary>
    /// Gets a value indicating whether raise click event on right mouse down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should raise right click event on mouse down; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual bool ShouldRaiseClickOnRightMouseDown => this.ContextMenuInherited == null && this.ContextMenuStripInherited == null;

    /// <summary>Gets the top level control internal.</summary>
    internal Control TopLevelControlInternal
    {
      get
      {
        Control levelControlInternal = this;
        while (levelControlInternal != null && !levelControlInternal.GetTopLevel())
          levelControlInternal = !(levelControlInternal is Form form) || !form.IsMdiChild || form.MdiParent == null ? levelControlInternal.ParentInternal : (Control) form.MdiParent;
        return levelControlInternal;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [selected indicator].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [selected indicator]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("ControlSelectedIndicatorDescr")]
    public bool SelectedIndicator
    {
      get => this.mblnSelectedIndicator;
      set
      {
        if (this.mblnSelectedIndicator == value)
          return;
        this.mblnSelectedIndicator = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ControlWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ControlWinFormsCompatibility;

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
    public override bool IsEventsEnabled => this.Enabled && this.Visible && base.IsEventsEnabled;

    /// <summary>
    ///  Gets the collection of controls contained within the control.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Control.ControlCollection Controls
    {
      get
      {
        if (this.mobjControls == null)
          this.mobjControls = this.CreateControlsInstance();
        return this.mobjControls;
      }
    }

    /// <summary>Creates the controls instance.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual Control.ControlCollection CreateControlsInstance() => new Control.ControlCollection(this);

    /// <summary>Return the control child controls</summary>
    [Browsable(false)]
    IList IControl.Controls => (IList) this.Controls;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Common.Interfaces.IControl" /> is name.
    /// </summary>
    /// <value><c>true</c> if name; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    string IControl.Name
    {
      get => this.Name;
      set => this.Name = value;
    }

    /// <summary>Returns the control parent control</summary>
    IControl IControl.Parent => (IControl) this.Parent;

    /// <summary>Performs the layout.</summary>
    /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
    void IControl.PerformLayout(bool blnForceLayout) => this.PerformLayout(blnForceLayout);

    /// <summary>
    /// Gets a value indicating whether this control has children.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this control has children; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public bool HasChildren => this.mobjControls != null && this.mobjControls.Count > 0;

    /// <summary>Gets or sets the parent container of this control.</summary>
    /// <value></value>
    [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control Parent
    {
      get => this.ParentInternal;
      set => this.ParentInternal = value;
    }

    /// <summary>Gets the get offlien parent.</summary>
    protected override IClientComponent ClientParent => (IClientComponent) this.Parent;

    /// <summary>Gets or sets the parent container of this control.</summary>
    /// <value></value>
    internal virtual Control ParentInternal
    {
      get => this.InternalParent as Control;
      set
      {
        Control internalParent = this.InternalParent as Control;
        if (internalParent == value)
          return;
        if (value != null)
          value.Controls.Add(this);
        else
          internalParent.Controls.Remove(this);
      }
    }

    /// <summary>
    /// 	<para>Not Implemented Property.</para>
    /// 	<para>Gets the size of a rectangular area into which the control can fit.</para>
    /// </summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> containing the height and width, in pixels.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public Size PreferredSize => this.mintPreferredHeight != -1 && this.mintPreferredWidth != -1 ? new Size(this.mintPreferredWidth, this.mintPreferredHeight) : Size.Empty;

    /// <summary>Gets or sets the size that is the upper limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.</summary>
    /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
    /// <filterpriority>1</filterpriority>
    [AmbientValue(typeof (Size), "0, 0")]
    [SRDescription("ControlMaximumSizeDescr")]
    [SRCategory("CatLayout")]
    public virtual Size MaximumSize
    {
      get => this.GetValue<Size>(Control.MaximumSizeProperty, this.DefaultMaximumSize);
      set
      {
        if (!this.SetValue<Size>(Control.MaximumSizeProperty, value))
          return;
        this.SetMaximumSize((IArrangedElement) this, value);
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets the length and height, in pixels, that is specified as the default maximum size of a control.</summary>
    /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> representing the size of the control.</returns>
    protected virtual Size DefaultMaximumSize => new Size(0, 0);

    /// <summary>Gets the length and height, in pixels, that is specified as the default minimum size of a control.</summary>
    /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> representing the size of the control.</returns>
    protected virtual Size DefaultMinimumSize => new Size(0, 0);

    /// <summary>Gets or sets the size that is the lower limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.</summary>
    /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatLayout")]
    [SRDescription("ControlMinimumSizeDescr")]
    public virtual Size MinimumSize
    {
      get => this.GetValue<Size>(Control.MinimumSizeProperty, this.DefaultMinimumSize);
      set
      {
        if (!this.SetValue<Size>(Control.MinimumSizeProperty, value, this.DefaultMinimumSize))
          return;
        this.SetMinimumSize((IArrangedElement) this, value);
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets the key down filter.</summary>
    /// <value>The key down filter.</value>
    [Description("The key down filter.")]
    [SRCategory("CatBehavior")]
    [DefaultValue(KeyFilter.All)]
    public KeyFilter KeyFilter
    {
      get => this.GetValue<KeyFilter>(Control.KeyFilterProperty);
      set
      {
        if (!this.SetValue<KeyFilter>(Control.KeyFilterProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Returns the current version info</summary>
    private Control.ControlVersionInfo VersionInfo => new Control.ControlVersionInfo(this);

    /// <summary>Gets the name of the company or creator of the application containing the control.</summary>
    /// <returns>The company name or creator of the application containing the control.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("ControlCompanyNameDescr")]
    public string CompanyName => this.VersionInfo.CompanyName;

    /// <summary>Gets the product name of the assembly containing the control.</summary>
    /// <returns>The product name of the assembly containing the control.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ControlProductNameDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string ProductName => this.VersionInfo.ProductName;

    /// <summary>Gets the version of the assembly containing the control.</summary>
    /// <returns>The file version of the assembly containing the control.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlProductVersionDescr")]
    public string ProductVersion => this.VersionInfo.ProductVersion;

    /// <summary>Gets or sets the ScrollTop property.</summary>
    /// <value>The ScrollTop property</value>
    protected int ScrollTop
    {
      get => this.GetValue<int>(Control.ScrollTopProperty);
      set
      {
        if (!this.SetScrollTop(value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets a value indicating whether [horizontal centered].
    /// </summary>
    /// <value><c>true</c> if [horizontal centered]; otherwise, <c>false</c>.</value>
    internal bool HorizontalCentered => (this.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == AnchorStyles.None;

    /// <summary>Gets a value indicating whether [vertical centered].</summary>
    /// <value><c>true</c> if [vertical centered]; otherwise, <c>false</c>.</value>
    internal bool VerticalCentered => (this.Anchor & (AnchorStyles.Bottom | AnchorStyles.Top)) == AnchorStyles.None;

    /// <summary>Sets the scroll top.</summary>
    /// <param name="intTop">The int top.</param>
    /// <returns></returns>
    protected bool SetScrollTop(int intTop) => this.SetValue<int>(Control.ScrollTopProperty, intTop);

    /// <summary>Gets or sets the ScrollLeft property.</summary>
    /// <value>The ScrollLeft property</value>
    protected int ScrollLeft
    {
      get => this.GetValue<int>(Control.ScrollLeftProperty);
      set
      {
        if (!this.SetScrollLeft(value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Sets the scroll left internal.</summary>
    /// <value>The scroll left internal.</value>
    protected bool SetScrollLeft(int intLeft) => this.SetValue<int>(Control.ScrollLeftProperty, intLeft);

    /// <summary>Gets or sets the control visability.</summary>
    [DefaultValue(true)]
    [SRDescription("ControlVisibleDescr")]
    [SRCategory("CatBehavior")]
    public bool Visible
    {
      get => this.DesignMode ? this.GetState(Component.ComponentState.Visible) : this.GetVisibleCore();
      set => this.SetVisibleInternal(value);
    }

    /// <summary>Sets the visible internal.</summary>
    /// <param name="blnValue">if set to <c>true</c> set visibility true.</param>
    internal virtual void SetVisibleInternal(bool blnValue)
    {
      if (this.VisibleIntenal == blnValue)
        return;
      this.SetVisibleCore(blnValue);
      this.InvalidateParentLayout(new LayoutEventArgs(false, true, false));
      this.Update();
    }

    /// <summary>Returns the visibility internally</summary>
    /// <returns></returns>
    internal virtual bool GetVisibleCore()
    {
      if (!this.GetState(Component.ComponentState.Visible))
        return false;
      Control parentInternal = this.ParentInternal;
      return parentInternal == null || parentInternal.GetVisibleCore();
    }

    /// <summary>Selects the next if focused.</summary>
    private void SelectNextIfFocused()
    {
      Control parentInternal = this.ParentInternal;
      if (!this.ContainsFocus || parentInternal == null)
        return;
      ((Control) parentInternal.GetContainerControlInternal())?.SelectNextControlInternal(this, true, true, true, true);
    }

    /// <summary>Sets the control to the specified visible state.</summary>
    /// <param name="blnValue">true to make the control visible; otherwise, false. </param>
    protected virtual void SetVisibleCore(bool blnValue)
    {
      if (this.GetVisibleCore() != blnValue)
      {
        if (!blnValue)
          this.SelectNextIfFocused();
        bool flag = false;
        Control parent = this.Parent;
        if (blnValue && parent != null && parent.Created || blnValue && this.GetTopLevel())
        {
          this.VisibleIntenal = blnValue;
          flag = true;
          try
          {
            if (blnValue)
              this.CreateControl();
          }
          catch
          {
            this.VisibleIntenal = !blnValue;
            throw;
          }
        }
        if (this.GetVisibleCore() != blnValue)
        {
          this.VisibleIntenal = blnValue;
          flag = true;
        }
        if (!flag)
          return;
        this.FireObservableItemPropertyChanged("Visible");
        this.OnVisibleChanged(EventArgs.Empty);
      }
      else
      {
        if (!(this.VisibleIntenal | blnValue))
          return;
        this.VisibleIntenal = blnValue;
      }
    }

    /// <summary>Gets or sets the control enabled state.</summary>
    [DefaultValue(true)]
    [SRDescription("ControlEnabledDescr")]
    [SRCategory("CatBehavior")]
    public virtual bool Enabled
    {
      get
      {
        bool state = this.GetState(Component.ComponentState.Enabled);
        if (this.DesignMode)
          return state;
        if (!state)
          return false;
        Control parentInternal = this.ParentInternal;
        return parentInternal == null || parentInternal.Enabled;
      }
      set => this.SetEnabled(value, AttributeType.Enabled);
    }

    /// <summary>Sets the enabled.</summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    /// <param name="enmAttributeTypes">The enm attribute types.</param>
    protected void SetEnabled(bool value, AttributeType enmAttributeTypes) => this.SetEnabled(value, enmAttributeTypes, true);

    /// <summary>Sets the enabled.</summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    /// <param name="enmAttributeTypes">The enm attribute types.</param>
    /// <param name="blnUseClientUpdateHandler">if set to <c>true</c> [BLN use client update handler].</param>
    protected void SetEnabled(
      bool value,
      AttributeType enmAttributeTypes,
      bool blnUseClientUpdateHandler)
    {
      if (!this.SetStateWithCheck(Component.ComponentState.Enabled, value))
        return;
      this.OnEnabledChanged(EventArgs.Empty);
      this.FireObservableItemPropertyChanged("Enabled");
      this.UpdateParams(enmAttributeTypes, blnUseClientUpdateHandler);
    }

    /// <summary>Gets a value indicating whether [enabled internal].</summary>
    /// <value>
    ///   <c>true</c> if [enabled internal]; otherwise, <c>false</c>.
    /// </value>
    private bool EnabledInternal => this.GetState(Component.ComponentState.Enabled);

    /// <summary>Gets a value indicating whether the control has a handle associated with it.</summary>
    /// <returns>true if a handle has been assigned to the control; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("ControlHandleCreatedDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool IsHandleCreated => this.IsRegistered;

    /// <summary>Gets a value indicating whether the base <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class is in the process of disposing.</summary>
    /// <returns>true if the base <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class is in the process of disposing; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlDisposingDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool Disposing => false;

    /// <summary>Gets a value indicating whether the control has been disposed of.</summary>
    /// <returns>true if the control has been disposed of; otherwise, false.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ControlDisposedDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool IsDisposed => false;

    /// <summary>Gets the parent container control.</summary>
    /// <value>The parent container control.</value>
    internal ContainerControl ParentContainerControl
    {
      get
      {
        for (Control parentInternal = this.ParentInternal; parentInternal != null; parentInternal = parentInternal.ParentInternal)
        {
          if (parentInternal is ContainerControl)
            return parentInternal as ContainerControl;
        }
        return (ContainerControl) null;
      }
    }

    /// <summary>Gets the handle that the control is bound to.</summary>
    /// <returns>An <see cref="T:System.IntPtr"></see> that contains the handle of the control.</returns>
    /// <filterpriority>2</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("ControlHandleDescr")]
    public IntPtr Handle => new IntPtr(this.ID);

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if tab stop is enabled; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [SRDescription("ControlTabStopDescr")]
    [SRCategory("CatBehavior")]
    public virtual bool TabStop
    {
      get => this.GetState(Control.ControlState.TabStop);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.TabStop, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.</summary>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
    [SRDescription("ControlBackgroundImageLayoutDescr")]
    [DefaultValue(ImageLayout.Tile)]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    [ProxyBrowsable(true)]
    public virtual ImageLayout BackgroundImageLayout
    {
      get => this.GetValue<ImageLayout>(Control.BackgroundImageLayoutProperty);
      set
      {
        if (!this.SetValue<ImageLayout>(Control.BackgroundImageLayoutProperty, value))
          return;
        this.Update();
        this.OnBackgroundImageLayoutChanged(EventArgs.Empty);
      }
    }

    /// <summary>
    /// Gets or sets the background image displayed in the control.
    /// </summary>
    /// <value></value>
    [DefaultValue(null)]
    [SRDescription("ControlBackgroundImageDescr")]
    [ProxyBrowsable(true)]
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    public virtual ResourceHandle BackgroundImage
    {
      get => this.GetValue<ResourceHandle>(Control.BackgroundImageProperty);
      set
      {
        if (!this.SetValue<ResourceHandle>(Control.BackgroundImageProperty, value))
          return;
        this.Update();
        this.OnBackgroundImageChanged(EventArgs.Empty);
        this.FireObservableItemPropertyChanged(nameof (BackgroundImage));
      }
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlFontDescr")]
    [ProxyBrowsable(true)]
    public virtual Font Font
    {
      get => this.GetValue<Font>(Control.FontProperty, this.DefaultControlFont);
      set
      {
        if (!this.SetValue<Font>(Control.FontProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
        this.OnFontChanged(EventArgs.Empty);
        this.FireObservableItemPropertyChanged(nameof (Font));
      }
    }

    /// <summary>Gets or sets where this control is scrolled to in <see cref="M:System.Windows.Forms.ScrollableControl.ScrollControlIntoView(System.Windows.Forms.Control)"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Point"></see> specifying the scroll location. The default is the upper-left corner of the control.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(typeof (Point), "0, 0")]
    public virtual Point AutoScrollOffset
    {
      get => Point.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the visual template.</summary>
    /// <value>The visual template.</value>
    [ProxyBrowsable(true)]
    [Description("Sets the appearance of the control without changing its state")]
    [SRCategory("CatAppearance")]
    public virtual VisualTemplate VisualTemplate
    {
      get => this.GetValue<VisualTemplate>(Control.VisualTemplateProperty, (VisualTemplate) null);
      set
      {
        if (!this.SetValue<VisualTemplate>(Control.VisualTemplateProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (VisualTemplate));
      }
    }

    /// <summary>Resets the visual template.</summary>
    private void ResetVisualTemplate() => this.RemoveValue<VisualTemplate>(Control.VisualTemplateProperty);

    /// <summary>Shoulds the serialize visual template.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal bool ShouldSerializeVisualTemplate() => this.ContainsValue<VisualTemplate>(Control.VisualTemplateProperty);

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [SRDescription("ControlPaddingDescr")]
    [Localizable(true)]
    [SRCategory("CatLayout")]
    [ProxyBrowsable(true)]
    public virtual Padding Padding
    {
      get => this.GetValue<Padding>(Control.PaddingProperty, this.DefaultPadding);
      set
      {
        Padding padding = this.Padding;
        if (!this.SetValue<Padding>(Control.PaddingProperty, value, this.DefaultPadding))
          return;
        this.OnPaddingChanged(EventArgs.Empty);
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (Padding));
        this.UpdateChildSize(padding.Horizontal != value.Horizontal, padding.Vertical != value.Vertical);
      }
    }

    /// <summary>
    /// Computes the location of the specified screen point into client coordinates.
    /// </summary>
    /// <param name="objPoint">The point to be calculated.</param>
    /// <returns>point in client coordinates</returns>
    public Point PointToClient(Point objPoint)
    {
      Control parent = this.Parent;
      if (parent == null)
        return objPoint;
      objPoint.X -= this.Left;
      objPoint.Y -= this.Top;
      return parent.PointToClient(objPoint);
    }

    /// <summary>
    /// Points to screen.
    /// Not implemented by design.
    /// </summary>
    /// <param name="objPoint">The p.</param>
    /// <returns></returns>
    [Obsolete("Not implemented by design.")]
    public Point PointToScreen(Point objPoint) => objPoint;

    /// <summary>Gets or sets the space between controls.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between controls.</returns>
    /// <filterpriority>2</filterpriority>
    [Localizable(true)]
    [SRDescription("ControlMarginDescr")]
    [SRCategory("CatLayout")]
    [ProxyBrowsable(true)]
    public Padding Margin
    {
      get => this.GetValue<Padding>(Control.MarginProperty, this.DefaultMargin);
      set
      {
        Padding margin = this.Margin;
        if (!this.SetValue<Padding>(Control.MarginProperty, value, this.DefaultMargin))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (Margin));
        this.InvalidateParentLayout(new LayoutEventArgs(false, true, false));
        this.UpdateChildSize(margin.Horizontal != value.Horizontal, margin.Vertical != value.Vertical);
      }
    }

    /// <summary>Prevent serializing margin if not required</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal bool ShouldSerializeMargin() => this.ContainsValue<Padding>(Control.MarginProperty);

    /// <summary>Prevent serializing padding if not required</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal bool ShouldSerializePadding() => this.ContainsValue<Padding>(Control.PaddingProperty);

    /// <summary>Gets the doch style.</summary>
    /// <returns></returns>
    internal virtual DockStyle GetDockInternal() => this.menmDock;

    /// <summary>Gets/Sets the controls docking style</summary>
    [DefaultValue(DockStyle.None)]
    [SRCategory("CatLayout")]
    [SRDescription("ControlDockDescr")]
    [ProxyBrowsable(true)]
    public virtual DockStyle Dock
    {
      set
      {
        if (this.menmDock == value)
          return;
        DockStyle menmDock = this.menmDock;
        this.menmDock = value;
        if (this.Parent != null)
          this.Parent.UpdateParams(AttributeType.Redraw);
        this.menmAnchor = AnchorStyles.Left | AnchorStyles.Top;
        this.ApplyPreReleaseDockFillCompatibility();
        this.FireObservableItemPropertyChanged(nameof (Dock));
        this.UpdateParams(AttributeType.Layout);
        this.UpdateChildSizeAfterDockChange(menmDock, this.menmDock);
      }
      get => this.GetDockInternal();
    }

    /// <summary>
    /// Updates the child controls size when the docking has changed
    /// </summary>
    /// <param name="enmCurrentVal">The old docking value</param>
    /// <param name="enmNewVal">The new docking value</param>
    private void UpdateChildSizeAfterDockChange(DockStyle enmCurrentVal, DockStyle enmNewVal)
    {
      bool blnHorizontal = false;
      bool blnVertical = false;
      if ((enmCurrentVal == DockStyle.Bottom || enmCurrentVal == DockStyle.Top) && (enmNewVal == DockStyle.Left || enmNewVal == DockStyle.Right) || (enmCurrentVal == DockStyle.Left || enmCurrentVal == DockStyle.Right) && (enmNewVal == DockStyle.Bottom || enmNewVal == DockStyle.Top) || enmCurrentVal == DockStyle.None && enmNewVal != DockStyle.None || enmNewVal == DockStyle.None && enmCurrentVal != DockStyle.None)
      {
        blnHorizontal = true;
        blnVertical = true;
      }
      else if ((enmCurrentVal == DockStyle.Bottom || enmCurrentVal == DockStyle.Top) && enmNewVal == DockStyle.Fill || enmCurrentVal == DockStyle.Fill && (enmNewVal == DockStyle.Bottom || enmNewVal == DockStyle.Top))
        blnVertical = true;
      else if ((enmCurrentVal == DockStyle.Left || enmCurrentVal == DockStyle.Right) && enmNewVal == DockStyle.Fill || enmCurrentVal == DockStyle.Fill && (enmNewVal == DockStyle.Left || enmNewVal == DockStyle.Right))
        blnHorizontal = true;
      if (!(blnHorizontal | blnVertical))
        return;
      this.UpdateChildSize(blnHorizontal, blnVertical);
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.Controls;

    /// <summary>Gets the anchor style.</summary>
    /// <returns></returns>
    internal virtual AnchorStyles GetAnchorInternal() => this.menmAnchor;

    /// <summary>Gets or sets the anchoring style.</summary>
    /// <value></value>
    [SRCategory("CatLayout")]
    [SRDescription("ControlAnchorDescr")]
    [ProxyBrowsable(true)]
    public virtual AnchorStyles Anchor
    {
      get => this.GetAnchorInternal();
      set
      {
        if (this.menmAnchor == value)
          return;
        this.menmAnchor = value;
        this.menmDock = DockStyle.None;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (Anchor));
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [RefreshProperties(RefreshProperties.All)]
    [Localizable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlAutoSizeDescr")]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(false)]
    public virtual bool AutoSize
    {
      get => this.GetState(Control.ControlState.AutoSize);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.AutoSize, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
        this.OnAutoSizeChanged(EventArgs.Empty);
        this.FireObservableItemPropertyChanged(nameof (AutoSize));
      }
    }

    /// <summary>
    /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    [Localizable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlAutoSizeModeDescr")]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(AutoSizeMode.GrowOnly)]
    public virtual AutoSizeMode AutoSizeMode
    {
      get => this.GetValue<AutoSizeMode>(Control.AutoSizeModeProperty);
      set
      {
        if (!this.SetValue<AutoSizeMode>(Control.AutoSizeModeProperty, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Gets the display rectangle.</summary>
    /// <value>The display rectangle.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("ControlDisplayRectangleDescr")]
    [Browsable(false)]
    public virtual Rectangle DisplayRectangle => new Rectangle(this.Location, this.DisplaySize);

    /// <summary>Gets the display size.</summary>
    /// <remarks>Provides enhancment for performance that cancels the need to get the location for setting the display size.</remarks>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    protected virtual Size DisplaySize => this.Size;

    /// <summary>Gets the control contained area offset.</summary>
    protected virtual PaddingValue ContainedAreaOffset
    {
      get
      {
        if (this.BorderStyle == BorderStyle.None)
          return (PaddingValue) Padding.Empty;
        Padding objValue = new Padding();
        BorderWidth borderWidth = this.BorderWidth;
        objValue.Bottom = borderWidth.Bottom;
        objValue.Top = borderWidth.Top;
        objValue.Left = borderWidth.Left;
        objValue.Right = borderWidth.Right;
        return new PaddingValue(objValue);
      }
    }

    /// <summary>Gets the horizontal contained area offset.</summary>
    private int HorizontalContainedAreaOffset
    {
      get
      {
        PaddingValue containedAreaOffset = this.ContainedAreaOffset;
        return containedAreaOffset.Left + containedAreaOffset.Right;
      }
    }

    /// <summary>Gets the vertical contained area offset.</summary>
    private int VerticalContainedAreaOffset
    {
      get
      {
        PaddingValue containedAreaOffset = this.ContainedAreaOffset;
        return containedAreaOffset.Top + containedAreaOffset.Bottom;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this control requires layout. Will effect controls with autosize or autoscrol.
    /// </summary>
    /// <value><c>true</c> if control requires layout; otherwise, <c>false</c>.</value>
    internal virtual bool RequiresLayout => this.AutoSize;

    /// <summary>Gets or sets the control location.</summary>
    /// <value></value>
    [Localizable(true)]
    [SRCategory("CatLayout")]
    [SRDescription("ControlLocationDescr")]
    [ProxyBrowsable(true)]
    public Point Location
    {
      get => new Point(this.Left, this.Top);
      set
      {
        if (!this.SetBounds(value.X, value.Y, 0, 0, BoundsSpecified.Location))
          return;
        this.OnLocationChangedInternal(new LayoutEventArgs(false, false, true));
        this.FireObservableItemPropertyChanged(nameof (Location));
        if (this.IsDocked(this.Dock))
          return;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets the size.</summary>
    /// <value>The size.</value>
    [Localizable(true)]
    [SRCategory("CatLayout")]
    [SRDescription("ControlSizeDescr")]
    [ProxyBrowsable(true)]
    public Size Size
    {
      get => new Size(this.Width, this.Height);
      set
      {
        if (!this.SetBounds(0, 0, value.Width, value.Height, BoundsSpecified.Size))
          return;
        this.OnResizeInternal(new LayoutEventArgs(false, true, true));
        this.FireObservableItemPropertyChanged(nameof (Size));
        this.UpdateSizeLayuoutParams(true, false);
      }
    }

    /// <summary>Updates the size layuout params.</summary>
    /// <param name="blnUpdateCurrent">if set to <c>true</c> [BLN update current].</param>
    /// <param name="blnForceChildUpdate">if set to <c>true</c> [BLN force child update].</param>
    private void UpdateSizeLayuoutParams(bool blnUpdateCurrent, bool blnForceChildUpdate)
    {
      if (blnUpdateCurrent)
        this.UpdateParams(AttributeType.Layout);
      if (!(this.IsLayoutSuspended | blnForceChildUpdate))
        return;
      foreach (Control control1 in (ArrangedElementCollection) this.Controls)
      {
        AnchorStyles anchor1 = control1.Anchor;
        if (control1.IsRightAnchored(anchor1) || control1.IsBottomAnchored(anchor1))
        {
          control1.UpdateParams(AttributeType.Layout);
          foreach (Control control2 in (ArrangedElementCollection) control1.Controls)
          {
            AnchorStyles anchor2 = control2.Anchor;
            DockStyle dock = control2.Dock;
            if (control2.SizeEffectedByParentResizing(anchor2, dock))
              control2.UpdateSizeLayuoutParams(dock == DockStyle.None, true);
          }
        }
      }
    }

    /// <summary>Updates the size of the child.</summary>
    private void UpdateChildSize(bool blnHorizontal, bool blnVertical)
    {
      if (this.IsLayoutSuspended)
        return;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        AnchorStyles anchor = control.Anchor;
        DockStyle dock = control.Dock;
        if (dock == DockStyle.Fill && blnHorizontal | blnVertical || blnHorizontal && (control.IsRightAnchored(anchor) && control.IsLeftAnchored(anchor) || dock == DockStyle.Top || dock == DockStyle.Bottom) || blnVertical && (control.IsTopAnchored(anchor) && control.IsBottomAnchored(anchor) || dock == DockStyle.Left || dock == DockStyle.Right))
          control.OnResizeInternal(new LayoutEventArgs(false, false, false));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to use WG namespace.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to use WG namespace; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool UseWGNamespace => false;

    /// <summary>
    /// Gets a value indicating whether [size effected by parent resizing].
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns></returns>
    /// <value>
    /// 	<c>true</c> if [size effected by parent resizing]; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool SizeEffectedByParentResizing(AnchorStyles enmAnchor, DockStyle enmDock)
    {
      bool flag = false;
      if (this.Parent != null)
        flag = ((((flag | enmDock != 0 ? 1 : 0) | ((enmAnchor & AnchorStyles.Left) == AnchorStyles.None ? 0 : ((enmAnchor & AnchorStyles.Right) != 0 ? 1 : 0))) != 0 ? 1 : 0) | ((enmAnchor & AnchorStyles.Top) == AnchorStyles.None ? 0 : ((enmAnchor & AnchorStyles.Bottom) != 0 ? 1 : 0))) != 0;
      return flag;
    }

    /// <summary>
    /// Gets a value indicating whether [location effected by parent resizing].
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns></returns>
    /// <value>
    /// 	<c>true</c> if [location effected by parent resizing]; otherwise, <c>false</c>.
    /// </value>
    internal bool LocationEffectedByParentResizing(AnchorStyles enmAnchor, DockStyle enmDock)
    {
      bool flag = false;
      if (this.Parent != null)
        flag = ((((flag ? 1 : 0) | ((enmAnchor & AnchorStyles.Right) == AnchorStyles.None ? 0 : ((enmAnchor & AnchorStyles.Left) == AnchorStyles.None ? 1 : 0))) != 0 ? 1 : 0) | ((enmAnchor & AnchorStyles.Bottom) == AnchorStyles.None ? 0 : ((enmAnchor & AnchorStyles.Top) == AnchorStyles.None ? 1 : 0))) != 0 | enmDock == DockStyle.Right | enmDock == DockStyle.Bottom;
      return flag;
    }

    /// <summary>Gets the layout location.</summary>
    /// <value>The layout location.</value>
    internal Point LayoutLocation => new Point(this.mintLeft, this.mintTop);

    /// <summary>Gets or sets the tab index.</summary>
    /// <value></value>
    [SRDescription("ControlTabIndexDescr")]
    [MergableProperty(false)]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int TabIndex
    {
      get => this.mintTabIndex != -1 ? this.mintTabIndex : 0;
      set => this.mintTabIndex = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof (TabIndex), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (TabIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
    }

    /// <summary>
    /// Gets or sets a value indicating whether [validation cancelled].
    /// </summary>
    /// <value><c>true</c> if [validation cancelled]; otherwise, <c>false</c>.</value>
    internal bool ValidationCancelled
    {
      get
      {
        if (this.GetState(Control.ControlState.ValidationCancelled))
          return true;
        Control parentInternal = this.ParentInternal;
        return parentInternal != null && parentInternal.ValidationCancelled;
      }
      set => this.SetState(Control.ControlState.ValidationCancelled, value);
    }

    /// <summary>Gets/Sets the top position</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Top
    {
      set
      {
        if (!this.SetBounds(0, value, 0, 0, BoundsSpecified.Y) || this.IsDocked(this.Dock))
          return;
        this.OnLocationChangedInternal(new LayoutEventArgs(false, false, true));
        this.UpdateParams(AttributeType.Layout);
      }
      get => this.GetCalculatedTop(this.IsLayoutSuspended || this.DesignMode);
    }

    /// <summary>Gets/Sets the bottom position</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Bottom => this.Top + this.Height;

    /// <summary>
    /// Gets or sets a value indicating whether to force content availability on client side.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [force content availability on client side]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [SRDescription("ForceContentAvailabilityOnClientDescr")]
    [SRCategory("CatBehavior")]
    public bool ForceContentAvailabilityOnClient
    {
      get => this.GetValue<bool>(Control.ForceContentAvailabilityOnClientProperty);
      set
      {
        if (!this.SetValue<bool>(Control.ForceContentAvailabilityOnClientProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets/Sets the left position</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Left
    {
      set
      {
        if (!this.SetBounds(value, 0, 0, 0, BoundsSpecified.X) || this.IsDocked(this.Dock))
          return;
        this.OnLocationChangedInternal(new LayoutEventArgs(false, false, true));
        this.UpdateParams(AttributeType.Layout);
      }
      get => this.GetCalculatedLeft(this.IsLayoutSuspended || this.DesignMode);
    }

    /// <summary>Gets the height of the layout.</summary>
    /// <value>The height of the layout.</value>
    internal int LayoutHeight => this.mintHeight;

    /// <summary>Gets the width of the layout.</summary>
    /// <value>The width of the layout.</value>
    internal int LayoutWidth => this.mintWidth;

    /// <summary>
    /// Gets the left value relative to the center of the container
    /// </summary>
    private int CenteredLeft
    {
      get
      {
        Control parent = this.Parent;
        if (parent == null)
          return 0;
        return parent is TableLayoutPanel ? -(this.Width / 2) : this.LayoutLeft - parent.mintLayoutWidth / 2;
      }
    }

    /// <summary>
    /// Gets the top value relative to the center of the container
    /// </summary>
    private int CenteredTop
    {
      get
      {
        Control parent = this.Parent;
        if (parent == null)
          return 0;
        return parent is TableLayoutPanel ? -(this.Height / 2) : this.LayoutTop - parent.mintLayoutHeight / 2;
      }
    }

    /// <summary>Gets the layout left.</summary>
    /// <value>The layout left.</value>
    internal int LayoutLeft => this.mintLeft;

    /// <summary>Gets the layout right (based on the layout width).</summary>
    /// <value>The layout right.</value>
    internal int LayoutRight
    {
      get
      {
        Control parent = this.Parent;
        if (parent == null)
          return this.mintLeft + this.mintWidth;
        if (parent is ScrollableControl scrollableControl && scrollableControl.AutoScroll)
        {
          Size displaySize = scrollableControl.DisplaySize;
          if (displaySize.Width > parent.mintLayoutWidth)
            return displaySize.Width - (this.mintLeft + this.Width);
        }
        return parent.mintLayoutWidth - (this.mintLeft + this.Width);
      }
    }

    /// <summary>Gets the layout bottom (based on the layout height).</summary>
    /// <value>The layout bottom.</value>
    internal int LayoutBottom
    {
      get
      {
        Control parent = this.Parent;
        if (parent == null)
          return this.mintTop + this.mintHeight;
        if (parent is ScrollableControl scrollableControl && scrollableControl.AutoScroll)
        {
          Size displaySize = scrollableControl.DisplaySize;
          if (displaySize.Height > parent.mintLayoutHeight)
            return displaySize.Height - (this.mintTop + this.Height);
        }
        return parent.mintLayoutHeight - (this.mintTop + this.Height);
      }
    }

    /// <summary>Gets the layout top.</summary>
    /// <value>The layout top.</value>
    internal int LayoutTop => this.mintTop;

    /// <summary>Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.</summary>
    /// <returns>true if the control causes validation to be performed on any controls requiring validation when it receives focus; otherwise, false. The default is true.</returns>
    /// <filterpriority>2</filterpriority>
    [DefaultValue(true)]
    [SRDescription("ControlCausesValidationDescr")]
    [SRCategory("CatFocus")]
    public bool CausesValidation
    {
      get => this.GetState(Control.ControlState.CausesValidation);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.CausesValidation, value))
          return;
        this.OnCausesValidationChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets/Sets the right position</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Right => this.Left + this.Width;

    /// <summary>Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ControlRightToLeftDescr")]
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    public virtual RightToLeft RightToLeft
    {
      get
      {
        RightToLeft rightToLeft = this.GetValue<RightToLeft>(Control.RightToLeftProperty);
        if (rightToLeft == RightToLeft.Inherit)
        {
          Control parentInternal = this.ParentInternal;
          rightToLeft = parentInternal == null ? (this.Context == null ? RightToLeft.No : (this.Context.RightToLeft ? RightToLeft.Yes : RightToLeft.No)) : parentInternal.RightToLeft;
        }
        return rightToLeft;
      }
      set
      {
        if (!this.SetValue<RightToLeft>(Control.RightToLeftProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets/Sets the height position</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Height
    {
      set => this.SetHeight(value, true);
      get => this.GetCalculatedHeight(this.IsLayoutSuspended || this.DesignMode);
    }

    /// <summary>Sets the height.</summary>
    /// <param name="intHeight">Height of the int.</param>
    /// <param name="blnUpdateCurrent">if set to <c>true</c> [BLN update current].</param>
    protected void SetHeight(int intHeight, bool blnUpdateCurrent)
    {
      if (!this.SetBounds(0, 0, 0, intHeight, BoundsSpecified.Height))
        return;
      this.OnResizeInternal(new LayoutEventArgs(false, true, true));
      switch (this.Dock)
      {
        case DockStyle.Fill:
          break;
        case DockStyle.Right:
          break;
        case DockStyle.Left:
          break;
        default:
          this.UpdateSizeLayuoutParams(blnUpdateCurrent, false);
          break;
      }
    }

    /// <summary>Gets the calculated height.</summary>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
    /// <returns></returns>
    protected virtual int GetCalculatedHeight(bool blnUseLayoutValues)
    {
      int calculatedHeight = this.mintHeight;
      if (!blnUseLayoutValues && this.InternalParent is Control internalParent)
      {
        DockStyle dock1 = this.Dock;
        if ((!this.UsePreferredSize ? 0 : (this.IsVerticalDocked(dock1) ? 1 : (!this.IsDocked(dock1) ? 1 : 0))) != 0)
          calculatedHeight = this.ApplyBoundsConstraints(this.mintLeft, this.mintTop, this.Width, this.PreferredSize.Height).Height;
        else if (!(internalParent is FlowLayoutPanel))
        {
          if (dock1 == DockStyle.Left || dock1 == DockStyle.Right || dock1 == DockStyle.Fill)
          {
            if (internalParent is TableLayoutPanel tableLayoutPanel)
            {
              calculatedHeight = Convert.ToInt32(tableLayoutPanel.GetControlCalculatedHeight(this, blnUseLayoutValues));
            }
            else
            {
              int vertical = internalParent.Padding.Vertical;
              int num = internalParent.Controls.IndexOf(this);
              for (int index = internalParent.Controls.Count - 1; index > num; --index)
              {
                if (index != num)
                {
                  Control control = internalParent.Controls[index];
                  if (control.GetState(Component.ComponentState.Visible))
                  {
                    DockStyle dock2 = control.Dock;
                    if (dock2 == DockStyle.Top | dock2 == DockStyle.Bottom)
                      vertical += control.Height;
                  }
                }
              }
              calculatedHeight = internalParent.GetCalculatedHeight(blnUseLayoutValues) - vertical;
              Size minimumSize = this.MinimumSize;
              if (!minimumSize.IsEmpty && minimumSize.Height != 0)
                calculatedHeight = Math.Max(calculatedHeight, minimumSize.Height);
              Size maximumSize = this.MaximumSize;
              if (!maximumSize.IsEmpty && maximumSize.Height != 0)
                calculatedHeight = Math.Min(calculatedHeight, maximumSize.Height);
            }
          }
        }
        else
          calculatedHeight = this.ApplyBoundsConstraints(this.mintLeft, this.mintTop, this.Width, calculatedHeight).Height;
      }
      return calculatedHeight;
    }

    /// <summary>Gets/Sets the width position</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Width
    {
      set
      {
        if (!this.SetBounds(0, 0, value, 0, BoundsSpecified.Width))
          return;
        this.OnResizeInternal(new LayoutEventArgs(false, true, true));
        switch (this.Dock)
        {
          case DockStyle.Fill:
            break;
          case DockStyle.Top:
            break;
          case DockStyle.Bottom:
            break;
          default:
            this.UpdateSizeLayuoutParams(true, false);
            break;
        }
      }
      get => this.GetCalculatedWidth(this.IsLayoutSuspended || this.DesignMode);
    }

    /// <summary>Gets the calculated top.</summary>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> use layout values.</param>
    /// <returns></returns>
    protected int GetCalculatedTop(bool blnUseLayoutValues)
    {
      DockStyle dock = this.Dock;
      if (blnUseLayoutValues || this.Parent == null || !this.IsDocked(dock))
        return this.mintTop;
      Control parent = this.Parent;
      if (parent is TableLayoutPanel tableLayoutPanel)
        return Convert.ToInt32(tableLayoutPanel.GetControlCalculatedTop(this, blnUseLayoutValues));
      return this.IsBottomDocked(dock) ? parent.DisplayRectangle.Height - this.Height - this.GetDockBoundries(DockStyle.Bottom) : this.GetDockBoundries(DockStyle.Top);
    }

    /// <summary>Gets the calculated left.</summary>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> use layout values.</param>
    /// <returns></returns>
    protected int GetCalculatedLeft(bool blnUseLayoutValues)
    {
      DockStyle dock = this.Dock;
      if (blnUseLayoutValues || this.Parent == null || !this.IsDocked(dock))
        return this.mintLeft;
      Control parent = this.Parent;
      if (parent is TableLayoutPanel tableLayoutPanel)
        return Convert.ToInt32(tableLayoutPanel.GetControlCalculatedLeft(this, blnUseLayoutValues));
      return this.IsRightDocked(dock) ? parent.DisplayRectangle.Width - this.Width - this.GetDockBoundries(DockStyle.Right) : this.GetDockBoundries(DockStyle.Left);
    }

    /// <summary>Gets the dock boundries.</summary>
    /// <param name="enmDockStyle">The dock style.</param>
    /// <returns></returns>
    private int GetDockBoundries(DockStyle enmDockStyle)
    {
      int dockBoundries = 0;
      Control parent = this.Parent;
      if (parent != null)
      {
        switch (enmDockStyle)
        {
          case DockStyle.Top:
            dockBoundries += parent.Padding.Top;
            break;
          case DockStyle.Right:
            dockBoundries += parent.Padding.Right;
            break;
          case DockStyle.Bottom:
            dockBoundries += parent.Padding.Bottom;
            break;
          case DockStyle.Left:
            dockBoundries += parent.Padding.Left;
            break;
        }
        Control.ControlCollection controls = parent.Controls;
        int num = controls.IndexOf(this);
        if (num > -1)
        {
          for (int index = num + 1; index < controls.Count; ++index)
          {
            Control control = controls[index];
            if (control.Dock == enmDockStyle)
            {
              if (enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right)
                dockBoundries += control.Width;
              else
                dockBoundries += control.Height;
            }
          }
        }
      }
      return dockBoundries;
    }

    /// <summary>
    /// Gets a value indicating whether this instance is anchored.
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <returns>
    /// 	<c>true</c> if the specified enm anchor is anchored; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is anchored; otherwise, <c>false</c>.
    /// </value>
    internal bool IsAnchored(AnchorStyles enmAnchor) => enmAnchor != 0;

    /// <summary>
    /// Gets a value indicating whether this instance is docked.
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if the specified enm dock is docked; otherwise, <c>false</c>.
    /// </returns>
    /// <value><c>true</c> if this instance is docked; otherwise, <c>false</c>.</value>
    internal bool IsDocked(DockStyle enmDock) => enmDock != 0;

    /// <summary>
    /// Gets a value indicating whether this instance is right docked.
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is right docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is right docked; otherwise, <c>false</c>.
    /// </value>
    internal bool IsRightDocked(DockStyle enmDock) => enmDock == DockStyle.Right;

    /// <summary>
    /// Determines whether [is fill docked] [the specified enm dock].
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is fill docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsFillDocked(DockStyle enmDock) => enmDock == DockStyle.Fill;

    /// <summary>
    /// Gets a value indicating whether this instance is left docked.
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is left docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is left docked; otherwise, <c>false</c>.
    /// </value>
    internal bool IsLeftDocked(DockStyle enmDock) => enmDock == DockStyle.Left;

    /// <summary>
    /// Gets a value indicating whether this instance is horizontal docked.
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is left docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is left docked; otherwise, <c>false</c>.
    /// </value>
    internal bool IsHorizontalDocked(DockStyle enmDock) => enmDock == DockStyle.Left || enmDock == DockStyle.Right;

    /// <summary>Determines whether is vertical docked.</summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is vertical docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsVerticalDocked(DockStyle enmDock) => enmDock == DockStyle.Top || enmDock == DockStyle.Bottom;

    /// <summary>
    /// Gets a value indicating whether this instance is top docked.
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is top docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is top docked; otherwise, <c>false</c>.
    /// </value>
    internal bool IsTopDocked(DockStyle enmDock) => enmDock == DockStyle.Top;

    /// <summary>
    /// Gets a value indicating whether this instance is bottom docked.
    /// </summary>
    /// <param name="enmDock">The enm dock.</param>
    /// <returns>
    /// 	<c>true</c> if [is bottom docked] [the specified enm dock]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is bottom docked; otherwise, <c>false</c>.
    /// </value>
    internal bool IsBottomDocked(DockStyle enmDock) => enmDock == DockStyle.Bottom;

    /// <summary>
    /// Gets a value indicating whether this instance is right anchored.
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <returns>
    /// 	<c>true</c> if [is right anchored] [the specified enm anchor]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is right anchored; otherwise, <c>false</c>.
    /// </value>
    internal bool IsRightAnchored(AnchorStyles enmAnchor) => (enmAnchor & AnchorStyles.Right) != 0;

    /// <summary>
    /// Gets a value indicating whether this instance is left anchored.
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <returns>
    /// 	<c>true</c> if [is left anchored] [the specified enm anchor]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is left anchored; otherwise, <c>false</c>.
    /// </value>
    internal bool IsLeftAnchored(AnchorStyles enmAnchor) => (enmAnchor & AnchorStyles.Left) != 0;

    /// <summary>
    /// Gets a value indicating whether this instance is top anchored.
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <returns>
    /// 	<c>true</c> if [is top anchored] [the specified enm anchor]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is top anchored; otherwise, <c>false</c>.
    /// </value>
    internal bool IsTopAnchored(AnchorStyles enmAnchor) => (enmAnchor & AnchorStyles.Top) != 0;

    /// <summary>
    /// Gets a value indicating whether this instance is bottom anchored.
    /// </summary>
    /// <param name="enmAnchor">The enm anchor.</param>
    /// <returns>
    /// 	<c>true</c> if [is bottom anchored] [the specified enm anchor]; otherwise, <c>false</c>.
    /// </returns>
    /// <value>
    /// 	<c>true</c> if this instance is bottom anchored; otherwise, <c>false</c>.
    /// </value>
    internal bool IsBottomAnchored(AnchorStyles enmAnchor) => (enmAnchor & AnchorStyles.Bottom) != 0;

    /// <summary>Gets the calculated width.</summary>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
    /// <returns></returns>
    protected virtual int GetCalculatedWidth(bool blnUseLayoutValues)
    {
      int calculatedWidth = this.mintWidth;
      if (!blnUseLayoutValues && this.InternalParent is Control internalParent)
      {
        DockStyle dock1 = this.Dock;
        if ((!this.UsePreferredSize ? 0 : (this.IsHorizontalDocked(dock1) ? 1 : (!this.IsDocked(dock1) ? 1 : 0))) != 0)
          calculatedWidth = this.ApplyBoundsConstraints(this.mintLeft, this.mintTop, this.PreferredSize.Width, this.mintHeight).Width;
        else if (!(internalParent is FlowLayoutPanel))
        {
          if (dock1 == DockStyle.Top || dock1 == DockStyle.Bottom || dock1 == DockStyle.Fill)
          {
            if (internalParent is TableLayoutPanel tableLayoutPanel)
            {
              calculatedWidth = Convert.ToInt32(tableLayoutPanel.GetControlCalculatedWidth(this, blnUseLayoutValues));
            }
            else
            {
              int horizontal = internalParent.Padding.Horizontal;
              int num = internalParent.Controls.IndexOf(this);
              for (int index = internalParent.Controls.Count - 1; index > num; --index)
              {
                if (index != num)
                {
                  Control control = internalParent.Controls[index];
                  if (control.GetState(Component.ComponentState.Visible))
                  {
                    DockStyle dock2 = control.Dock;
                    if (dock2 == DockStyle.Right | dock2 == DockStyle.Left)
                      horizontal += control.Width;
                  }
                }
              }
              calculatedWidth = internalParent.GetCalculatedWidth(blnUseLayoutValues) - horizontal;
              Size minimumSize = this.MinimumSize;
              if (!minimumSize.IsEmpty && minimumSize.Width != 0)
                calculatedWidth = Math.Max(calculatedWidth, minimumSize.Width);
              Size maximumSize = this.MaximumSize;
              if (!maximumSize.IsEmpty && maximumSize.Width != 0)
                calculatedWidth = Math.Min(calculatedWidth, maximumSize.Width);
            }
          }
          else
            calculatedWidth = this.ApplyBoundsConstraints(this.mintLeft, this.mintTop, calculatedWidth, this.mintHeight).Width;
        }
      }
      return calculatedWidth;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance has positioning.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has positioning; otherwise, <c>false</c>.
    /// </value>
    protected bool HasPositioning
    {
      get => this.GetState(Control.ControlState.HasPositioning);
      set => this.SetState(Control.ControlState.HasPositioning, value);
    }

    /// <summary>Gets or sets the client size of the form.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size ClientSize
    {
      get => this.Size;
      set => this.Size = value;
    }

    /// <summary>Gets or sets the shortcut menu associated with the control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ContextMenu"></see> that represents the shortcut menu associated with the control.</returns>
    [Browsable(true)]
    [DefaultValue(null)]
    [SRDescription("ControlContextMenuDescr")]
    [SRCategory("CatBehavior")]
    public override ContextMenu ContextMenu
    {
      get => base.ContextMenu;
      set
      {
        base.ContextMenu = value;
        this.FireObservableItemPropertyChanged(nameof (ContextMenu));
      }
    }

    /// <summary>Gets or sets the control custom style.</summary>
    /// <value></value>
    [DefaultValue("")]
    [SRDescription("ControlCustomStyleDescr")]
    [ProxyBrowsable(true)]
    [SRCategory("CatAppearance")]
    public virtual string CustomStyle
    {
      get => this.GetValue<string>(Control.CustomStyleProperty);
      set
      {
        if (!this.SetValue<string>(Control.CustomStyleProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets a value indicating whether the control has been created.</summary>
    /// <returns>true if the control has been created; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [SRDescription("ControlCreatedDescr")]
    public bool Created => this.GetState(Control.ControlState.Created);

    /// <summary>Gets a flag indicating if the object is initializing</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected internal override bool IsSerializableObjectInitializing => !this.GetState(Control.ControlState.Created);

    /// <summary>
    /// Gets the initial size of the serializable filed storage.
    /// </summary>
    /// <value>The initial size of the serializable filed storage.</value>
    protected internal override int SerializableFieldStorageInitialSize => 12;

    /// <summary>Gets or sets the cursor that is displayed when the mouse pointer is over the control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor to display when the mouse pointer is over the control.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlCursorDescr")]
    [ProxyBrowsable(true)]
    public virtual Cursor Cursor
    {
      get => this.GetValue<Cursor>(Control.CursorProperty);
      set
      {
        if (!this.SetValue<Cursor>(Control.CursorProperty, value))
          return;
        this.UpdateParams(AttributeType.Redraw);
      }
    }

    /// <summary>Prevent serializing cursor if is default</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeCursor() => this.ContainsValue<Cursor>(Control.CursorProperty);

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBorderStyleDescr")]
    [ProxyBrowsable(true)]
    public virtual BorderStyle BorderStyle
    {
      get => this.GetValue<BorderStyle>(Control.BorderStyleProperty, this.DefaultBorderStyle);
      set
      {
        if (!this.SetValue<BorderStyle>(Control.BorderStyleProperty, value, this.DefaultBorderStyle))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (BorderStyle));
      }
    }

    /// <summary>Gets or sets the thickness of the border.</summary>
    /// <value>Gets or sets a border thickness.</value>
    /// <remarks>The thinkness struct can be automaticly casted to and from int for backwords compatibility.</remarks>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBorderWidthDescr")]
    [ProxyBrowsable(true)]
    public virtual BorderWidth BorderWidth
    {
      get => this.GetValue<BorderWidth>(Control.BorderWidthProperty, this.DefaultBorderWidth);
      set
      {
        if (!this.SetValue<BorderWidth>(Control.BorderWidthProperty, value, this.DefaultBorderWidth))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (BorderWidth));
      }
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [WebEditor(typeof (WebThemeEditor), typeof (WebUITypeEditor))]
    [SRCategory("CatAppearance")]
    [SRDescription("ControlThemeDescr")]
    [DefaultValue("Inherit")]
    [ProxyBrowsable(true)]
    public virtual string Theme
    {
      get => this.GetValue<string>(Control.ThemeProperty);
      set
      {
        ICollection<string> strings = VWGContext.Current != null ? (ICollection<string>) VWGContext.Current.AvailableThemes : (ICollection<string>) Config.GetInstance().AvailableThemes;
        if (!(value == "Inherit") && !strings.Contains(value) || !this.SetValue<string>(Control.ThemeProperty, value))
          return;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBackColorDescr")]
    [ProxyBrowsable(true)]
    public virtual Color BackColor
    {
      get => this.GetValue<Color>(Control.BackColorProperty, this.DefaultBackColor);
      set
      {
        if (!this.SetValue<Color>(Control.BackColorProperty, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (BackColor));
        this.Update();
        this.OnBackColorChanged(EventArgs.Empty);
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has back color.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has back color; otherwise, <c>false</c>.
    /// </value>
    internal bool HasBackColor => this.ContainsValue<object>(Control.BackColorProperty);

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlBorderColorDescr")]
    [ProxyBrowsable(true)]
    public virtual BorderColor BorderColor
    {
      get => this.GetValue<BorderColor>(Control.BorderColorProperty, this.DefaultBorderColor);
      set
      {
        if (!this.SetValue<BorderColor>(Control.BorderColorProperty, value, this.DefaultBorderColor))
          return;
        this.FireObservableItemPropertyChanged(nameof (BorderColor));
        this.Update();
      }
    }

    /// <summary>Gets or sets the fore color.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [SRDescription("ControlForeColorDescr")]
    [ProxyBrowsable(true)]
    public virtual Color ForeColor
    {
      get => this.GetValue<Color>(Control.ForeColorProperty, this.DefaultForeColor);
      set
      {
        if (!this.SetValue<Color>(Control.ForeColorProperty, value))
          return;
        this.Update();
        this.OnForeColorChanged(new EventArgs());
        this.FireObservableItemPropertyChanged(nameof (ForeColor));
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has fore color.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has fore color; otherwise, <c>false</c>.
    /// </value>
    internal bool HasForeColor => this.ContainsValue<object>(Control.ForeColorProperty);

    /// <summary>
    /// Gets a value indicating whether this instance has right to left.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has right to left; otherwise, <c>false</c>.
    /// </value>
    internal bool HasRightToLeft => this.ContainsValue<object>(Control.RightToLeftProperty);

    /// <summary>Gets the error message.</summary>
    /// <returns></returns>
    internal string GetErrorMessage() => this.ErrorMessage;

    /// <summary>Gets the icon alignment.</summary>
    /// <returns></returns>
    internal ErrorIconAlignment ErrorIconAlignment
    {
      get => this.GetValue<ErrorIconAlignment>(Control.ErrorIconAlignmentProperty);
      set
      {
        if (!this.SetValue<ErrorIconAlignment>(Control.ErrorIconAlignmentProperty, value))
          return;
        this.UpdateParams(AttributeType.Error);
      }
    }

    /// <summary>Gets or sets the error icon padding.</summary>
    /// <value>The error icon padding.</value>
    internal int ErrorIconPadding
    {
      get => this.GetValue<int>(Control.ErrorIconPaddingProperty);
      set
      {
        if (!this.SetValue<int>(Control.ErrorIconPaddingProperty, value))
          return;
        this.UpdateParams(AttributeType.Error);
      }
    }

    /// <summary>Sets the error.</summary>
    /// <param name="strValue">value.</param>
    /// <param name="objErrorIcon">The obj error icon.</param>
    internal void SetErrorMessage(string strValue, ResourceHandle objErrorIcon)
    {
      ResourceHandle errorIcon = this.ErrorIcon;
      string errorMessage = this.ErrorMessage;
      ResourceHandle resourceHandle = objErrorIcon;
      if (errorIcon == resourceHandle && !(errorMessage != strValue))
        return;
      this.ErrorIcon = objErrorIcon;
      this.ErrorMessage = strValue;
      this.UpdateParams(AttributeType.Error);
    }

    /// <summary>Gets or sets the error icon.</summary>
    /// <value>The error icon.</value>
    private ResourceHandle ErrorIcon
    {
      get => this.GetValue<ResourceHandle>(Control.ErrorIconProperty);
      set => this.SetValue<ResourceHandle>(Control.ErrorIconProperty, value);
    }

    /// <summary>Gets or sets the error message.</summary>
    /// <value>The error message.</value>
    private string ErrorMessage
    {
      get => this.GetValue<string>(Control.ErrorMessageProperty);
      set => this.SetValue<string>(Control.ErrorMessageProperty, value);
    }

    /// <summary>Sets the icon alignment.</summary>
    /// <param name="enmValue">value.</param>
    internal void SetErrorIconAlignment(ErrorIconAlignment enmValue)
    {
    }

    /// <summary>
    /// Raises the <see cref="E:ResizeInternal" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    internal void OnResizeInternal(LayoutEventArgs objEventArgs)
    {
      if (objEventArgs.ShouldUpdateParent)
        this.InvalidateParentLayout(objEventArgs);
      this.OnLayoutInternal(objEventArgs);
    }

    /// <summary>Check if design time layouting is allowed.</summary>
    /// <returns></returns>
    private bool AllowDesignTimeLayouting()
    {
      bool flag = false;
      if (this.GetService(typeof (IDesignerHost)) is IDesignerHost service)
        flag = service.Loading;
      return flag;
    }

    /// <summary>
    /// Raises the <see cref="E:Layout" /> event.
    /// </summary>
    /// <param name="levent">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    protected virtual void OnLayout(LayoutEventArgs objEventArgs)
    {
    }

    /// <summary>
    /// Raises the <see cref="E:LayoutInternal" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    internal void OnLayoutInternal(LayoutEventArgs objEventArgs)
    {
      if (this.DesignMode && !this.AllowDesignTimeLayouting() || this.IsLayoutSuspended)
        return;
      Size size = this.Size;
      int height = size.Height;
      int width = size.Width;
      if (this.mintLayoutHeight == height && this.mintLayoutWidth == width)
        return;
      if (this.WinFormsCompatibility.IsRecursiveResizeEvent || !this.IsNonCompatibleModeLayoutSuspended)
        this.OnLayoutInternal(objEventArgs, new Size(width, height), new Size(this.mintLayoutWidth, this.mintLayoutHeight));
      this.mintLayoutHeight = height;
      this.mintLayoutWidth = width;
      this.OnLayout(objEventArgs);
    }

    /// <summary>Gets the opposite dock style.</summary>
    /// <param name="enmDockStyle">The enm dock style.</param>
    /// <returns></returns>
    private DockStyle GetOppositeDockStyle(DockStyle enmDockStyle)
    {
      switch (enmDockStyle)
      {
        case DockStyle.Top:
          return DockStyle.Bottom;
        case DockStyle.Right:
          return DockStyle.Left;
        case DockStyle.Bottom:
          return DockStyle.Top;
        case DockStyle.Left:
          return DockStyle.Right;
        default:
          return DockStyle.None;
      }
    }

    /// <summary>Called when child had been resized.</summary>
    /// <param name="objControl">The resized control.</param>
    /// <param name="objNewSize">The control new size.</param>
    /// <param name="objOldSize">The control old size.</param>
    private void OnDockedChildResizeInternal(
      LayoutEventArgs objEventArgs,
      Control objControl,
      Size objNewSize,
      Size objOldSize)
    {
      DockStyle dock = objControl.Dock;
      if (dock == DockStyle.None)
        return;
      Control.ControlCollection controls = this.Controls;
      if (controls.Count <= 1)
        return;
      int num = controls.IndexOf(objControl);
      if (num <= 0)
        return;
      DockStyle oppositeDockStyle = this.GetOppositeDockStyle(dock);
      for (int index = num - 1; index >= 0; --index)
      {
        Control control = controls[index];
        if (control.Dock != DockStyle.None && control.Dock != oppositeDockStyle)
        {
          control.OnLocationChangedInternal(objEventArgs.Clone(false, false));
          if (control.Dock != dock)
            control.OnResizeInternal(objEventArgs.Clone(false, false));
        }
      }
    }

    /// <summary>
    /// Provides controls with the ability to handle size changed
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    /// <param name="objNewSize">The control new size.</param>
    /// <param name="objOldSize">The control old size.</param>
    internal virtual void OnLayoutInternal(
      LayoutEventArgs objEventArgs,
      Size objNewSize,
      Size objOldSize)
    {
      if (this.GetDockInternal() != DockStyle.None && objEventArgs.ShouldUpdateSiblings)
        this.Parent?.OnDockedChildResizeInternal(objEventArgs, this, objNewSize, objOldSize);
      this.OnLayoutControls(objEventArgs, ref objNewSize, ref objOldSize);
    }

    /// <summary>
    /// Layout the internal controls to reflect parent changes
    /// </summary>
    /// <param name="objEventArgs">The layout arguments.</param>
    /// <param name="objNewSize">The new parent size.</param>
    /// <param name="objOldSize">The old parent size.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLayoutControls(
      LayoutEventArgs objEventArgs,
      ref Size objNewSize,
      ref Size objOldSize)
    {
      if (this.mobjControls == null || this.mobjControls.Count <= 0)
        return;
      int num1 = objNewSize.Width - objOldSize.Width;
      int num2 = objNewSize.Height - objOldSize.Height;
      foreach (Control mobjControl in (ArrangedElementCollection) this.mobjControls)
      {
        DockStyle dock = mobjControl.Dock;
        switch (dock)
        {
          case DockStyle.Fill:
            if (num1 != 0 || num2 != 0)
            {
              mobjControl.OnResizeInternal(objEventArgs.Clone(false, false));
              mobjControl.OnSizeChanged(EventArgs.Empty);
              continue;
            }
            continue;
          case DockStyle.Top:
          case DockStyle.Bottom:
            if (dock == DockStyle.Bottom && num2 != 0)
            {
              mobjControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
              mobjControl.OnLocationChanged(objEventArgs.Clone(false, false));
            }
            if (num1 != 0)
            {
              mobjControl.OnResizeInternal(objEventArgs.Clone(false, false));
              mobjControl.OnSizeChanged(EventArgs.Empty);
              continue;
            }
            continue;
          case DockStyle.Right:
          case DockStyle.Left:
            if (dock == DockStyle.Right && num1 != 0)
            {
              mobjControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
              mobjControl.OnLocationChanged(objEventArgs.Clone(false, false));
            }
            if (num2 != 0)
            {
              mobjControl.OnResizeInternal(objEventArgs.Clone(false, false));
              mobjControl.OnSizeChanged(EventArgs.Empty);
              continue;
            }
            continue;
          default:
            int left = mobjControl.Left;
            int top = mobjControl.Top;
            int height = mobjControl.Height;
            int width = mobjControl.Width;
            AnchorStyles anchor = mobjControl.Anchor;
            bool flag1 = mobjControl.IsRightAnchored(anchor);
            bool flag2 = mobjControl.IsLeftAnchored(anchor);
            bool flag3 = mobjControl.IsTopAnchored(anchor);
            bool flag4 = mobjControl.IsBottomAnchored(anchor);
            bool flag5 = false;
            bool flag6 = false;
            if (num1 != 0)
            {
              if (flag1 && !flag2)
              {
                left += num1;
                flag6 = true;
              }
              else if (flag1 & flag2)
              {
                width += num1;
                flag5 = true;
              }
              else if (!flag1 && !flag2)
              {
                left += num1 / 2;
                flag6 = true;
              }
            }
            if (num2 != 0)
            {
              if (flag4 && !flag3)
              {
                top += num2;
                flag6 = true;
              }
              else if (flag4 & flag3)
              {
                height += num2;
                flag5 = true;
              }
              else if (!flag4 && !flag3)
              {
                top += num2 / 2;
                flag6 = true;
              }
            }
            if (flag6 | flag5)
            {
              mobjControl.UpdateBounds(left, top, width, height, width, height, objEventArgs.IsClientSource);
              if (flag6)
                mobjControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
              if (flag5)
              {
                mobjControl.OnResizeInternal(objEventArgs.Clone(false, false));
                continue;
              }
              continue;
            }
            continue;
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Resize" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnResize(EventArgs e)
    {
      EventHandler resizeHandler = this.ResizeHandler;
      if (resizeHandler == null)
        return;
      resizeHandler((object) this, EventArgs.Empty);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnSizeChanged(EventArgs e)
    {
      this.OnResize(e);
      EventHandler sizeChangedHandler = this.SizeChangedHandler;
      if (sizeChangedHandler == null)
        return;
      sizeChangedHandler((object) this, e);
    }

    /// <summary>Suspends the layout.</summary>
    public void SuspendLayout()
    {
      ++this.mintSuspendLayout;
      if (this.mintSuspendLayout != 1)
        return;
      EventHandler suspendLayoutHandler = this.ObservableSuspendLayoutHandler;
      if (suspendLayoutHandler == null)
        return;
      suspendLayoutHandler((object) this, EventArgs.Empty);
    }

    /// <summary>Terminates registered timers.</summary>
    internal void TerminateRegisteredTimers()
    {
      Timer[] registeredTimers = this.RegisteredTimers;
      if (registeredTimers != null)
      {
        foreach (Timer timer in registeredTimers)
          timer.Enabled = false;
      }
      Control.ControlCollection controls = this.Controls;
      if (controls.Count <= 0)
        return;
      foreach (Control control in (ArrangedElementCollection) controls)
        control.TerminateRegisteredTimers();
    }

    /// <summary>
    /// Gets a value indicating whether this instance is layout suspended non compatible mode.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is layout suspended non compatible mode; otherwise, <c>false</c>.
    /// </value>
    internal bool IsNonCompatibleModeLayoutSuspended
    {
      get
      {
        if (this.mintSuspendLayout > 0)
          return true;
        switch (this)
        {
          case UserControl _:
          case Form _:
            return false;
          default:
            Control parent = this.Parent;
            return parent == null || parent.IsNonCompatibleModeLayoutSuspended;
        }
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is layout suspended.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is layout suspended; otherwise, <c>false</c>.
    /// </value>
    protected bool IsLayoutSuspended => this.mintSuspendLayout > 0;

    /// <summary>Resumes the layout.</summary>
    public void ResumeLayout() => this.ResumeLayout(true);

    /// <summary>Resumes the layout.</summary>
    public void ResumeLayout(LayoutEventArgs objEventArgs) => this.ResumeLayout(objEventArgs, true);

    /// <summary>Resumes the layout.</summary>
    /// <param name="blnPerformLayout">if set to <c>true</c> [BLN perform layout].</param>
    public void ResumeLayout(bool blnPerformLayout) => this.ResumeLayout(new LayoutEventArgs(false, false, true), blnPerformLayout);

    /// <summary>Resumes the layout.</summary>
    /// <param name="blnPerformLayout">if set to <c>true</c> [BLN perform layout].</param>
    public void ResumeLayout(LayoutEventArgs objEventArgs, bool blnPerformLayout)
    {
      if (this.mintSuspendLayout <= 0)
        return;
      --this.mintSuspendLayout;
      if (this.mintSuspendLayout != 0)
        return;
      if (blnPerformLayout)
      {
        this.SetState(Control.ControlState.LayoutIsDirty, true);
        this.PerformLayout(objEventArgs);
      }
      else
      {
        Size size = this.Size;
        this.mintLayoutHeight = size.Height;
        this.mintLayoutWidth = size.Width;
      }
      ObservableResumeLayoutHandler resumeLayoutHandler = this.ObservableResumeLayoutHandler;
      if (resumeLayoutHandler == null)
        return;
      resumeLayoutHandler((object) this, new ObservableResumeLayoutArgs(blnPerformLayout));
    }

    /// <summary>Invalidates the layout.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal void InvalidateLayout(LayoutEventArgs objEventArgs)
    {
      if (this.DesignMode || !this.RequiresLayout)
        return;
      this.SetState(Control.ControlState.LayoutIsDirty, true);
      if (this.GetTopLevel())
      {
        this.PerformLayout(objEventArgs);
      }
      else
      {
        Control parentInternal = this.ParentInternal;
        if (parentInternal == null)
          return;
        if (parentInternal.RequiresLayout)
        {
          Size preferredSize1 = parentInternal.PreferredSize;
          parentInternal.InvalidateLayout(objEventArgs);
          Size preferredSize2 = parentInternal.PreferredSize;
          if (!(preferredSize1 != preferredSize2) || objEventArgs.IsClientSource)
            return;
          parentInternal.UpdateParams(AttributeType.Layout);
        }
        else
        {
          parentInternal.SetState(Control.ControlState.LayoutIsDirty, true);
          parentInternal.PerformLayout(objEventArgs);
        }
      }
    }

    /// <summary>Invalidates the parent layout.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void InvalidateParentLayout(LayoutEventArgs objEventArgs) => this.ParentInternal?.InvalidateLayout(objEventArgs);

    /// <summary>WinForm complaint - No use.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void PerformLayout() => this.PerformLayout(false);

    /// <summary>WinForm complaint - No use.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public void PerformLayout(LayoutEventArgs objEventArgs) => this.PerformLayout(false, objEventArgs);

    /// <summary>Performs the layout.</summary>
    /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
    protected internal virtual void PerformLayout(bool blnForceLayout) => this.PerformLayout(blnForceLayout, new LayoutEventArgs(false, false, true));

    /// <summary>Performs the layout.</summary>
    /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    private void PerformLayout(bool blnForceLayout, LayoutEventArgs objEventArgs)
    {
      if (this.IsLayoutSuspended || !this.Created)
        return;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (blnForceLayout || control.GetState(Control.ControlState.LayoutIsDirty))
          control.PerformLayout(blnForceLayout, objEventArgs);
      }
      this.DoPerformLayout(blnForceLayout, objEventArgs);
    }

    /// <summary>Does the perform layout.</summary>
    /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
    /// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    private void DoPerformLayout(bool blnForceLayout, LayoutEventArgs objEventArgs)
    {
      if (this.IsLayoutSuspended || !this.RequiresLayout || !blnForceLayout && !this.GetState(Control.ControlState.LayoutIsDirty))
        return;
      Size objProposedSize = new Size(this.mintWidth, this.mintHeight);
      if (this.AutoSizeMode == AutoSizeMode.GrowAndShrink)
      {
        if (this.MinimumSize.Height > objProposedSize.Height)
          objProposedSize.Height = this.MinimumSize.Height;
        if (this.MinimumSize.Width > objProposedSize.Width)
          objProposedSize.Width = this.MinimumSize.Width;
      }
      else if (objProposedSize == Size.Empty)
        objProposedSize = this.DefaultSize;
      this.SetMinimumClientSize(objProposedSize);
      this.SetState(Control.ControlState.LayoutIsDirty, false);
      Size preferredSize = this.GetPreferredSize(objProposedSize);
      if (!this.SetPreferredSize(Control.GetPreferredSizeByAutoSizeMode(this, objProposedSize, preferredSize)))
        return;
      if (!objEventArgs.IsClientSource)
        this.UpdateParams(AttributeType.Layout);
      if (this.AutoSize)
        this.OnSizeChanged((EventArgs) objEventArgs);
      this.OnLayoutInternal(objEventArgs);
    }

    /// <summary>Sets the minimum size of the client.</summary>
    /// <param name="objProposedSize">Proposed size.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void SetMinimumClientSize(Size objProposedSize)
    {
    }

    /// <summary>Sets the size of the preferred.</summary>
    /// <param name="objPreferredSize">Size of the obj preferred.</param>
    /// <returns>Returns a flag if control should raise the resize event or do layout.</returns>
    [Browsable(false)]
    protected virtual bool SetPreferredSize(Size objPreferredSize)
    {
      if (this.mintPreferredHeight == -1 || this.mintPreferredWidth == -1)
      {
        this.mintPreferredWidth = objPreferredSize.Width;
        this.mintPreferredHeight = objPreferredSize.Height;
        return false;
      }
      if (this.mintPreferredHeight == objPreferredSize.Height && this.mintPreferredWidth == objPreferredSize.Width)
        return false;
      this.mintPreferredWidth = objPreferredSize.Width;
      this.mintPreferredHeight = objPreferredSize.Height;
      return true;
    }

    /// <summary>Invokes the specified method.</summary>
    /// <param name="objMethod">method.</param>
    /// <returns></returns>
    public object Invoke(Delegate objMethod) => this.Invoke(objMethod, (object[]) null);

    /// <summary>Invokes the specified method.</summary>
    /// <param name="objMethod">method.</param>
    /// <param name="objArgs">Arguments.</param>
    /// <returns></returns>
    public object Invoke(Delegate objMethod, object[] arrArgs) => objMethod?.DynamicInvoke(arrArgs);

    /// <summary>Shoulds the index of the serialize tab.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeTabIndex() => this.mintTabIndex != -1;

    /// <summary>Shoulds the color of the serialize back.</summary>
    /// <returns></returns>
    internal virtual bool ShouldSerializeBackColor() => this.ContainsValue<Color>(Control.BackColorProperty);

    /// <summary>Shoulds the color of the serialize fore.</summary>
    /// <returns></returns>
    internal virtual bool ShouldSerializeForeColor() => this.ContainsValue<Color>(Control.ForeColorProperty);

    /// <summary>Get a flag indicating if should serialize the font.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeFont() => this.ContainsValue<Font>(Control.FontProperty);

    /// <summary>Shoulds the color of the serialize border.</summary>
    /// <returns></returns>
    private bool ShouldSerializeBorderColor() => this.DefaultBorderColor != this.BorderColor;

    /// <summary>Shoulds the serialize border style.</summary>
    /// <returns></returns>
    private bool ShouldSerializeBorderStyle() => this.BorderStyle != this.DefaultBorderStyle;

    /// <summary>Shoulds the width of the serialize border.</summary>
    /// <returns></returns>
    private bool ShouldSerializeBorderWidth() => this.DefaultBorderWidth != this.BorderWidth;

    /// <summary>Shoulds the color of the serialize border.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeBorderColor(BorderColor objBorderColor) => this.DefaultBorderColor != objBorderColor;

    /// <summary>Shoulds the serialize border style.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeBorderStyle(BorderStyle objBordeStyle) => objBordeStyle != this.DefaultBorderStyle;

    private bool ShouldSerializeAnchor() => this.Anchor != (AnchorStyles.Left | AnchorStyles.Top);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeMaximumSize() => this.DefaultMaximumSize != this.MaximumSize;

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeMinimumSize() => this.DefaultMinimumSize != this.MinimumSize;

    private bool ShouldSerializeDock() => this.Dock != 0;

    /// <summary>Shoulds the render border.</summary>
    /// <param name="objBorderValue">The obj border value.</param>
    /// <returns></returns>
    private bool ShouldRenderBorder(BorderValue objBorderValue) => ((false ? 1 : (this.ShouldSerializeBorderColor(objBorderValue.Color) ? 1 : 0)) != 0 ? 1 : (this.ShouldSerializeBorderStyle(objBorderValue.Style) ? 1 : 0)) != 0 || this.ShouldSerializeBorderWidth(objBorderValue.Width);

    /// <summary>Shoulds the width of the serialize border.</summary>
    /// <param name="objBorderWidth">Width of the obj border.</param>
    /// <returns></returns>
    private bool ShouldSerializeBorderWidth(BorderWidth objBorderWidth) => this.DefaultBorderWidth != objBorderWidth;

    /// <summary>Gets the default width of the border.</summary>
    /// <value>The default width of the border.</value>
    protected virtual BorderWidth DefaultBorderWidth => this.Skin.BorderWidth;

    /// <summary>Shoulds the serialize text.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeText() => !string.IsNullOrEmpty(this.Text);

    /// <summary>Shoulds the size of the serialize.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeSize() => true;

    /// <summary>Shoulds the size of the serialize client.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeClientSize() => true;

    /// <summary>Shoulds the serialize right to left.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal virtual bool ShouldSerializeRightToLeft() => this.HasRightToLeft;

    /// <summary>Resets the right to left.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual void ResetRightToLeft() => this.RightToLeft = RightToLeft.Inherit;

    /// <summary>
    /// Gets a value indicating whether this instance is delayed drawing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is delayed drawing; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool IsDelayedDrawing => false;

    /// <summary>Gets a value indicating whether [auto drawn].</summary>
    /// <value>
    ///   <c>true</c> if [auto drawn]; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool AutoDrawn => true;

    /// <summary>
    /// Gets a value indicating whether [support child margins].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [support child margins]; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool SupportChildMargins => false;

    /// <summary>Gets a value indicating whether [force child redraw].</summary>
    /// <value><c>true</c> if [force child redraw]; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool ForceChildRedraw => false;

    /// <summary>
    /// Gets a value indicating whether this instance is redrawing its contained controls.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is redrawing; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool Redraws => false;

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected virtual Size DefaultSize => new Size(100, 100);

    /// <summary>Gets the default color of the back.</summary>
    /// <value>The default color of the back.</value>
    protected Color DefaultBackColor => this.Skin.BackColor;

    /// <summary>Gets the default color of the fore.</summary>
    /// <value>The default color of the fore.</value>
    protected Color DefaultForeColor => this.Skin.ForeColor;

    /// <summary>Gets the default color of the border.</summary>
    /// <value>The default color of the border.</value>
    protected BorderColor DefaultBorderColor => this.Skin.BorderColor;

    /// <summary>Gets the default border style.</summary>
    /// <value>The default border style.</value>
    protected BorderStyle DefaultBorderStyle => this.Skin.BorderStyle;

    /// <summary>Gets the default padding.</summary>
    /// <value>The default padding.</value>
    protected virtual Padding DefaultPadding => (Padding) this.Skin.Padding;

    /// <summary>Gets the default margin.</summary>
    /// <value>The default margin.</value>
    protected Padding DefaultMargin => (Padding) this.Skin.Margin;

    /// <summary>Gets the default font.</summary>
    /// <value>The default font.</value>
    protected Font DefaultControlFont => this.Skin.Font;

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      if (objValue is Control)
      {
        Control objValue1 = (Control) objValue;
        this.Controls.Add(objValue1);
        objValue1.BringToFront();
      }
      else
        base.AddChild(objValue);
    }

    /// <summary>Checks circular control reference.</summary>
    /// <param name="objBottom">The obj bottom.</param>
    /// <param name="objToFind">The obj to find.</param>
    /// <exception cref="T:System.ArgumentException">
    /// </exception>
    internal static void CheckParentingCycle(Control objBottom, Control objToFind)
    {
      Form form1 = (Form) null;
      Control control1 = (Control) null;
      for (Control control2 = objBottom; control2 != null; control2 = control2.ParentInternal)
      {
        control1 = control2;
        if (control2 == objToFind)
          throw new ArgumentException(SR.GetString("CircularOwner"));
      }
      if (control1 != null && control1 is Form)
      {
        for (Form form2 = (Form) control1; form2 != null; form2 = form2.OwnerInternal)
        {
          form1 = form2;
          if (form2 == objToFind)
            throw new ArgumentException(SR.GetString("CircularOwner"));
        }
      }
      if (form1 == null || form1.ParentInternal == null)
        return;
      Control.CheckParentingCycle(form1.ParentInternal, objToFind);
    }

    /// <summary>Assigns the parent.</summary>
    /// <param name="objParent">The obj parent of type Control.</param>
    internal virtual void AssignParent(Control objParent)
    {
      if (!this.CanAccessProperties)
        return;
      Control internalParent = this.InternalParent as Control;
      int num = this.InternalParent != null || objParent == null ? (this.InternalParent == null ? 0 : (objParent == null ? 1 : 0)) : 1;
      this.InternalParent = (Component) objParent;
      this.OnParentChanged(EventArgs.Empty);
      if (this.IsResizedDueToParentAssignment(internalParent, objParent))
        this.OnResizeInternal(new LayoutEventArgs(false, false, false));
      if (this.GetValue<BindingContext>(Control.BindingContextProperty) == null)
        this.OnBindingContextChanged(EventArgs.Empty);
      if (num == 0)
        return;
      this.OnVisibleChanged(EventArgs.Empty);
    }

    /// <summary>
    /// Determines whether is resized due to parent assignment.
    /// </summary>
    /// <param name="objOldParent">The obj old parent.</param>
    /// <param name="objNewParent">The obj new parent.</param>
    /// <returns>
    ///   <c>true</c> if [is resized due to parent assignment] [the specified obj old parent]; otherwise, <c>false</c>.
    /// </returns>
    private bool IsResizedDueToParentAssignment(Control objOldParent, Control objNewParent)
    {
      bool parentAssignment = false;
      if (objNewParent != null)
      {
        bool flag1 = objOldParent == null || objOldParent.Width != objNewParent.Width;
        bool flag2 = objOldParent == null || objOldParent.Height != objNewParent.Height;
        AnchorStyles anchor = this.Anchor;
        DockStyle dock = this.Dock;
        parentAssignment = dock == DockStyle.Fill && flag1 | flag2 || flag1 && (this.IsRightAnchored(anchor) && this.IsLeftAnchored(anchor) || dock == DockStyle.Top || dock == DockStyle.Bottom) || flag2 && (this.IsTopAnchored(anchor) && this.IsBottomAnchored(anchor) || dock == DockStyle.Left || dock == DockStyle.Right);
      }
      return parentAssignment;
    }

    /// <summary>Gets the first child control in tab order.</summary>
    /// <param name="blnForward">if set to <c>true</c> [BLN forward].</param>
    /// <returns></returns>
    internal virtual Control GetFirstChildControlInTabOrder(bool blnForward)
    {
      Control.ControlCollection controls = this.Controls;
      Control controlInTabOrder = (Control) null;
      if (controls != null)
      {
        if (blnForward)
        {
          for (int index = 0; index < controls.Count; ++index)
          {
            if (controlInTabOrder == null || controlInTabOrder.TabIndex > controls[index].TabIndex)
              controlInTabOrder = controls[index];
          }
          return controlInTabOrder;
        }
        for (int index = controls.Count - 1; index >= 0; --index)
        {
          if (controlInTabOrder == null || controlInTabOrder.TabIndex < controls[index].TabIndex)
            controlInTabOrder = controls[index];
        }
      }
      return controlInTabOrder;
    }

    /// <summary>Retrieves the next control forward or back in the tab order of child controls.</summary>
    /// <returns>The next <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in the tab order.</returns>
    /// <param name="blnForward">true to search forward in the tab order; false to search backward. </param>
    /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to start the search with. </param>
    /// <filterpriority>2</filterpriority>
    public Control GetNextControl(Control objControl, bool blnForward)
    {
      if (!this.Contains(objControl))
        objControl = this;
      if (!blnForward)
      {
        if (objControl != this)
        {
          int mintTabIndex = objControl.mintTabIndex;
          bool flag = false;
          Control control = (Control) null;
          Control parent = objControl.Parent;
          int num = 0;
          Control.ControlCollection controls = parent.Controls;
          if (controls != null)
            num = controls.Count;
          for (int index = num - 1; index >= 0; --index)
          {
            if (controls[index] != objControl)
            {
              if (controls[index].mintTabIndex <= mintTabIndex && (control == null || control.mintTabIndex < controls[index].mintTabIndex) && controls[index].mintTabIndex != mintTabIndex | flag)
                control = controls[index];
            }
            else
              flag = true;
          }
          if (control != null)
            objControl = control;
          else
            return parent == this ? (Control) null : parent;
        }
        for (Control.ControlCollection controls = objControl.Controls; controls != null && controls.Count > 0 && (objControl == this || !Control.IsFocusManagingContainerControl(objControl)); controls = objControl.Controls)
        {
          Control controlInTabOrder = objControl.GetFirstChildControlInTabOrder(false);
          if (controlInTabOrder != null)
            objControl = controlInTabOrder;
          else
            break;
        }
      }
      else
      {
        Control.ControlCollection controls1 = objControl.Controls;
        if (controls1 != null && controls1.Count > 0 && (objControl == this || !Control.IsFocusManagingContainerControl(objControl)))
        {
          Control controlInTabOrder = objControl.GetFirstChildControlInTabOrder(true);
          if (controlInTabOrder != null)
            return controlInTabOrder;
        }
        for (; objControl != this; objControl = objControl.Parent)
        {
          int tabIndex = objControl.TabIndex;
          bool flag = false;
          Control nextControl = (Control) null;
          Control parent = objControl.Parent;
          int num = 0;
          Control.ControlCollection controls2 = parent.Controls;
          if (controls2 != null)
            num = controls2.Count;
          for (int index = 0; index < num; ++index)
          {
            if (controls2[index] != objControl)
            {
              if (controls2[index].TabIndex >= tabIndex && (nextControl == null || nextControl.mintTabIndex > controls2[index].mintTabIndex) && controls2[index].mintTabIndex != tabIndex | flag)
                nextControl = controls2[index];
            }
            else
              flag = true;
          }
          if (nextControl != null)
            return nextControl;
        }
      }
      return objControl != this ? objControl : (Control) null;
    }

    /// <summary>Gets the top level.</summary>
    /// <returns></returns>
    protected bool GetTopLevel() => this.GetState(Control.ControlState.TopLevel);

    /// <summary>Sets the top level.</summary>
    /// <param name="blnValue">if set to <c>true</c> [value].</param>
    protected void SetTopLevel(bool blnValue) => this.SetTopLevelInternal(blnValue);

    /// <summary>Sets the top level internal.</summary>
    /// <param name="blnValue">if set to <c>true</c> [value].</param>
    internal void SetTopLevelInternal(bool blnValue)
    {
      if (this.GetTopLevel() == blnValue)
        return;
      if (this.Parent != null)
        throw new ArgumentException(SR.GetString("TopLevelParentedControl"), "value");
      this.SetState(Control.ControlState.TopLevel, blnValue);
      if (!blnValue || !this.Visible)
        return;
      this.CreateControl();
    }

    /// <summary>Checks if a control is a contains this control</summary>
    /// <param name="objDescendantControl">The obj descendant control.</param>
    /// <returns>
    /// 	<c>true</c> if the specified obj descendant control is descendant; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsDescendant(Control objDescendantControl)
    {
      for (Control control = objDescendantControl; control != null; control = control.ParentInternal)
      {
        if (control == this)
          return true;
      }
      return false;
    }

    /// <summary>
    /// Retrieves a value indicating whether the specified control is a child of the control.
    /// </summary>
    /// <param name="objControl">The control.</param>
    /// <returns>
    /// true if the specified control is a child of the control; otherwise, false.
    /// </returns>
    public bool Contains(Control objControl)
    {
      while (objControl != null)
      {
        objControl = objControl.Parent;
        if (objControl == null)
          return false;
        if (objControl == this)
          return true;
      }
      return false;
    }

    /// <summary>Forces the creation of the control, including the creation of the handle and any child controls.</summary>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void CreateControl() => this.CreateControl(false);

    /// <summary>Execute the control creation methods</summary>
    /// <param name="blnIgnoreVisible"></param>
    internal void CreateControl(bool blnIgnoreVisible)
    {
      if (((this.Created ? 0 : (this.Visible ? 1 : 0)) | (blnIgnoreVisible ? 1 : 0)) == 0)
        return;
      this.SetState(Control.ControlState.Created, true);
      bool flag = false;
      try
      {
        Control.ControlCollection mobjControls = this.mobjControls;
        if (mobjControls != null)
        {
          Control[] objArray = new Control[mobjControls.Count];
          mobjControls.CopyTo((Array) objArray, 0);
          foreach (Control control in objArray)
            control.CreateControl(blnIgnoreVisible);
        }
        flag = true;
      }
      finally
      {
        if (!flag)
          this.SetState(Component.ComponentState.Visible, false);
      }
      this.PerformLayout();
      this.OnCreateControl();
    }

    /// <summary>Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnCreateControl()
    {
    }

    /// <summary>
    /// Raises the <see cref="E:ParentBindingContextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnParentBindingContextChanged(EventArgs e)
    {
      if (this.GetValue<BindingContext>(Control.BindingContextProperty) != null)
        return;
      this.OnBindingContextChanged(e);
    }

    /// <summary>
    /// Raises the <see cref="E:BindingContextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBindingContextChanged(EventArgs e)
    {
      if (this.ContainsValue<ControlBindingsCollection>(Control.DataBindingsProperty))
        this.UpdateBindings();
      EventHandler contextChangedHandler = this.BindingContextChangedHandler;
      if (contextChangedHandler != null)
        contextChangedHandler((object) this, e);
      if (this.mobjControls == null)
        return;
      for (int index = 0; index < this.mobjControls.Count; ++index)
        this.mobjControls[index].OnParentBindingContextChanged(e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackgroundImageLayoutChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBackgroundImageLayoutChanged(EventArgs e)
    {
      EventHandler layoutChangedHandler = this.BackgroundImageLayoutChangedHandler;
      if (layoutChangedHandler == null)
        return;
      layoutChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.AutoSizeChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnAutoSizeChanged(EventArgs e)
    {
      EventHandler sizeChangedHandler = this.AutoSizeChangedHandler;
      if (sizeChangedHandler == null)
        return;
      sizeChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackColorChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBackColorChanged(EventArgs e)
    {
      EventHandler colorChangedHandler = this.BackColorChangedHandler;
      if (colorChangedHandler == null)
        return;
      colorChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackgroundImageChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBackgroundImageChanged(EventArgs e)
    {
      EventHandler imageChangedHandler = this.BackgroundImageChangedHandler;
      if (imageChangedHandler == null)
        return;
      imageChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.PaddingChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnPaddingChanged(EventArgs e)
    {
      EventHandler paddingChangedHandler = this.PaddingChangedHandler;
      if (paddingChangedHandler == null)
        return;
      paddingChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HelpRequested"></see> event.</summary>
    /// <param name="objHelpEventArgs">A <see cref="T:Gizmox.WebGUI.Forms.HelpEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnHelpRequested(HelpEventArgs objHelpEventArgs)
    {
      HelpEventHandler requestedHandler = this.HelpRequestedHandler;
      if (requestedHandler == null)
        return;
      requestedHandler((object) this, objHelpEventArgs);
      objHelpEventArgs.Handled = true;
    }

    /// <summary>Updates the bindings.</summary>
    private void UpdateBindings()
    {
      for (int index = 0; index < this.DataBindings.Count; ++index)
        BindingContext.UpdateBinding(this.BindingContext, this.DataBindings[index]);
    }

    /// <summary>
    /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("ControlBindingContextDescr")]
    [Browsable(false)]
    public virtual BindingContext BindingContext
    {
      get => this.BindingContextInternal;
      set => this.BindingContextInternal = value;
    }

    /// <summary>Gets or sets the binding context.</summary>
    /// <value>The binding context.</value>
    internal BindingContext BindingContextInternal
    {
      get
      {
        BindingContext bindingContext = this.GetValue<BindingContext>(Control.BindingContextProperty, (BindingContext) null);
        if (bindingContext == null)
        {
          Control parent = this.Parent;
          if (parent != null && parent.CanAccessProperties)
            bindingContext = parent.BindingContext;
        }
        return bindingContext;
      }
      set
      {
        if (!this.SetValue<BindingContext>(Control.BindingContextProperty, value))
          return;
        this.OnBindingContextChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets the data bindings for the control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects for the control.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [ParenthesizePropertyName(true)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("ControlBindingsDescr")]
    [SRCategory("CatData")]
    [LimitedTrustBrowsable(false)]
    public ControlBindingsCollection DataBindings
    {
      get
      {
        ControlBindingsCollection objValue = this.GetValue<ControlBindingsCollection>(Control.DataBindingsProperty);
        if (objValue == null)
        {
          objValue = new ControlBindingsCollection((IBindableComponent) this);
          this.SetValue<ControlBindingsCollection>(Control.DataBindingsProperty, objValue);
        }
        return objValue;
      }
    }

    /// <summary>Sets the bounds.</summary>
    /// <param name="intLeft">The int left.</param>
    /// <param name="intTop">The int top.</param>
    /// <param name="intWidth">Width of the int.</param>
    /// <param name="intHeight">Height of the int.</param>
    public void SetBounds(int intLeft, int intTop, int intWidth, int intHeight) => this.SetBounds(intLeft, intTop, intWidth, intHeight, BoundsSpecified.All);

    /// <summary>
    /// Sets the specified bounds of the control to the specified location and size.
    /// </summary>
    /// <param name="intLeft">The int left.</param>
    /// <param name="intTop">The int top.</param>
    /// <param name="intWidth">Width of the int layout.</param>
    /// <param name="intHeight">Height of the int layout.</param>
    /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual bool SetBounds(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified)
    {
      return this.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified, false);
    }

    /// <summary>
    /// Sets the specified bounds of the control to the specified location and size.
    /// </summary>
    /// <param name="intLeft">The int left.</param>
    /// <param name="intTop">The int top.</param>
    /// <param name="intWidth">Width of the int layout.</param>
    /// <param name="intHeight">Height of the int layout.</param>
    /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
    /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
    /// <returns></returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual bool SetBounds(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified,
      bool blnIsClientSource)
    {
      if ((enmSpecified & BoundsSpecified.X) == BoundsSpecified.None)
        intLeft = this.mintLeft;
      if ((enmSpecified & BoundsSpecified.Y) == BoundsSpecified.None)
        intTop = this.mintTop;
      if ((enmSpecified & BoundsSpecified.Width) == BoundsSpecified.None)
        intWidth = this.mintWidth;
      if ((enmSpecified & BoundsSpecified.Height) == BoundsSpecified.None)
        intHeight = this.mintHeight;
      return (this.mintLeft != intLeft || this.mintTop != intTop || this.mintWidth != intWidth || this.mintHeight != intHeight) && this.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
    }

    /// <summary>Sets the bounds.</summary>
    /// <param name="objBounds">The obj bounds.</param>
    /// <param name="enmSpecified">The specified.</param>
    void IArrangedElement.SetBounds(Rectangle objBounds, BoundsSpecified enmSpecified)
    {
      ISite site = this.Site;
      IComponentChangeService componentChangeService = (IComponentChangeService) null;
      PropertyDescriptor member1 = (PropertyDescriptor) null;
      PropertyDescriptor member2 = (PropertyDescriptor) null;
      bool flag1 = false;
      bool flag2 = false;
      if (site != null && site.DesignMode)
      {
        componentChangeService = (IComponentChangeService) site.GetService(typeof (IComponentChangeService));
        if (componentChangeService != null)
        {
          member1 = TypeDescriptor.GetProperties((object) this)[PropertyNames.Size];
          member2 = TypeDescriptor.GetProperties((object) this)[PropertyNames.Location];
          try
          {
            if (member1 != null && !member1.IsReadOnly && (objBounds.Width != this.Width || objBounds.Height != this.Height))
            {
              if (!(site is INestedSite))
                componentChangeService.OnComponentChanging((object) this, (MemberDescriptor) member1);
              flag1 = true;
            }
            if (member2 != null)
            {
              if (!member2.IsReadOnly)
              {
                if (objBounds.X == this.mintLeft)
                {
                  if (objBounds.Y == this.mintTop)
                    goto label_16;
                }
                if (!(site is INestedSite))
                  componentChangeService.OnComponentChanging((object) this, (MemberDescriptor) member2);
                flag2 = true;
              }
            }
          }
          catch (InvalidOperationException ex)
          {
          }
        }
      }
label_16:
      this.SetBoundsCore(objBounds.X, objBounds.Y, objBounds.Width, objBounds.Height, enmSpecified);
      if (site == null)
        return;
      if (componentChangeService == null)
        return;
      try
      {
        if (flag1)
          componentChangeService.OnComponentChanged((object) this, (MemberDescriptor) member1, (object) null, (object) null);
        if (!flag2)
          return;
        componentChangeService.OnComponentChanged((object) this, (MemberDescriptor) member2, (object) null, (object) null);
      }
      catch (InvalidOperationException ex)
      {
      }
    }

    /// <summary>Performs the work of setting the specified bounds of this control.</summary>
    /// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control. </param>
    /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. </param>
    /// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control. </param>
    /// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control. </param>
    /// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual bool SetBoundsCore(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified)
    {
      return this.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, false);
    }

    /// <summary>
    /// Performs the work of setting the specified bounds of this control.
    /// </summary>
    /// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control.</param>
    /// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control.</param>
    /// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control.</param>
    /// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control.</param>
    /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values.</param>
    /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual bool SetBoundsCore(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified,
      bool blnIsClientSource)
    {
      if (this.mintLeft == intLeft && this.mintTop == intTop && this.mintWidth == intWidth && this.mintHeight == intHeight)
        return false;
      Rectangle rectangle = this.ApplyBoundsConstraints(intLeft, intTop, intWidth, intHeight);
      intWidth = rectangle.Width;
      intHeight = rectangle.Height;
      intLeft = rectangle.X;
      intTop = rectangle.Y;
      return this.UpdateBounds(intLeft, intTop, intWidth, intHeight, blnIsClientSource);
    }

    /// <summary>Applies the bounds constraints.</summary>
    /// <param name="intSuggestedX">The suggested X.</param>
    /// <param name="intSuggestedY">The suggested Y.</param>
    /// <param name="intProposedWidth">Width of the proposed.</param>
    /// <param name="intProposedHeight">Height of the proposed.</param>
    /// <returns></returns>
    internal virtual Rectangle ApplyBoundsConstraints(
      int intSuggestedX,
      int intSuggestedY,
      int intProposedWidth,
      int intProposedHeight)
    {
      if (!(this.MaximumSize != Size.Empty) && !(this.MinimumSize != Size.Empty))
        return new Rectangle(intSuggestedX, intSuggestedY, intProposedWidth, intProposedHeight);
      Size unbounded = LayoutUtils.ConvertZeroToUnbounded(this.MaximumSize);
      Rectangle rectangle = new Rectangle(intSuggestedX, intSuggestedY, 0, 0)
      {
        Size = LayoutUtils.IntersectSizes(new Size(intProposedWidth, intProposedHeight), unbounded)
      };
      rectangle.Size = LayoutUtils.UnionSizes(rectangle.Size, this.MinimumSize);
      return rectangle;
    }

    /// <summary>Updates the bounds of the control with the specified size and location.</summary>
    /// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
    /// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
    /// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
    /// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight) => this.UpdateBounds(intLeft, intTop, intWidth, intHeight, intWidth, intHeight, false);

    /// <summary>
    /// Updates the bounds of the control with the specified size and location.
    /// </summary>
    /// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control.</param>
    /// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control.</param>
    /// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control.</param>
    /// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control.</param>
    /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected bool UpdateBounds(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      bool blnIsClientSource)
    {
      return this.UpdateBounds(intLeft, intTop, intWidth, intHeight, intWidth, intHeight, blnIsClientSource);
    }

    /// <summary>Updates the bounds of the control with the specified size, location, and client size.</summary>
    /// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
    /// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
    /// <param name="intClientHeight">The client <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
    /// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
    /// <param name="intClientWidth">The client <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
    /// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected internal bool UpdateBounds(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      int intClientWidth,
      int intClientHeight,
      bool blnIsClientSource)
    {
      bool flag1 = this.mintLeft != intLeft || this.mintTop != intTop;
      bool flag2 = this.mintWidth != intWidth || this.mintHeight != intHeight;
      if (!(flag2 | flag1))
        return false;
      this.mintLeft = intLeft;
      this.mintTop = intTop;
      this.mintHeight = intHeight;
      this.mintWidth = intWidth;
      if (flag1)
        this.OnLocationChanged(new LayoutEventArgs(blnIsClientSource, false, false));
      if (flag2)
        this.OnSizeChanged(EventArgs.Empty);
      if (!blnIsClientSource)
        this.UpdateParams(AttributeType.Layout);
      return true;
    }

    /// <summary>Gets or sets the size and location of the control including its nonclient elements, in pixels, relative to the parent control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> in pixels relative to the parent control that represents the size and location of the control including its nonclient elements.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [SRDescription("ControlBoundsDescr")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRCategory("CatLayout")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle Bounds
    {
      get => new Rectangle(this.mintLeft, this.mintTop, this.mintWidth, this.mintHeight);
      set
      {
        this.SetBounds(value.X, value.Y, value.Width, value.Height, BoundsSpecified.All);
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets the skin of the current control.</summary>
    /// <value>The skin of the current control.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    protected internal ControlSkin Skin
    {
      get
      {
        if (this.mobjSkin == null)
          this.mobjSkin = (ControlSkin) SkinFactory.GetSkin((ISkinable) this);
        return this.mobjSkin;
      }
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    string ISkinable.Theme
    {
      get
      {
        if (CommonUtils.IsDesignMode && !ConfigHelper.ApplySelectedThemeInDesignTime)
          return "Default";
        return this.Context != null ? this.Context.CurrentTheme : ConfigHelper.SelectedTheme;
      }
    }

    /// <summary>Gets or sets the client click action.</summary>
    /// <value>The client click action.</value>
    [Category("Client")]
    [Description("Occurs when control is clicked and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientClick
    {
      add => this.AddClientHandler("Click", value);
      remove => this.RemoveClientHandler("Click", value);
    }

    /// <summary>Gets or sets the client click action.</summary>
    /// <value>The client click action.</value>
    [Category("Client")]
    [Description("Occurs when control is clicked and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientDoubleClick
    {
      add => this.AddClientHandler("DoubleClick", value);
      remove => this.RemoveClientHandler("DoubleClick", value);
    }

    /// <summary>Gets or sets the client focus action.</summary>
    /// <value>The client focus action.</value>
    [Category("Client")]
    [Description("Occurs when the control gets focus and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientFocus
    {
      add => this.AddClientHandler("GotFocus", value);
      remove => this.RemoveClientHandler("GotFocus", value);
    }

    /// <summary>Gets or sets the client blur action.</summary>
    /// <value>The client blur action.</value>
    [Category("Client")]
    [Description("Occurs when the control looses focus and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientBlur
    {
      add => this.AddClientHandler("LostFocus", value);
      remove => this.RemoveClientHandler("LostFocus", value);
    }

    /// <summary>Occurs when [client key down].</summary>
    [Category("Client")]
    [Description("Occurs when the control gets key down and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientKeyDown
    {
      add => this.AddClientHandler("KeyDown", value);
      remove => this.RemoveClientHandler("KeyDown", value);
    }

    /// <summary>
    /// Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects.
    /// </summary>
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [ListBindable(false)]
    [Serializable]
    public class ControlCollection : 
      ArrangedElementCollection,
      IList,
      ICollection,
      IEnumerable,
      ICloneable,
      IObservableList
    {
      private int mintLastAccessedIndex;
      private Control mobjOwnerControl;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> class.
      /// </summary>
      /// <param name="owner">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> representing the control that owns the control collection.</param>
      /// <param name="blnReversed">if set to <c>true</c> [BLN reversed].</param>
      public ControlCollection(Control objOwnerControl, bool blnReversed)
      {
        this.mintLastAccessedIndex = -1;
        this.mobjOwnerControl = objOwnerControl;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection" /> class.
      /// </summary>
      /// <param name="objOwnerControl">The owner.</param>
      public ControlCollection(Control objOwnerControl)
        : this(objOwnerControl, false)
      {
      }

      /// <summary>Adds the specified control to the control collection.</summary>
      /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection. </param>
      /// <exception cref="T:System.Exception">The specified control is a top-level control, or a circular control reference would result if this control were added to the control collection. </exception>
      /// <exception cref="T:System.ArgumentException">The object assigned to the value parameter is not a <see cref="T:Gizmox.WebGUI.Forms.Control"></see>. </exception>
      public virtual void Add(Control objValue) => this.Add(objValue, true, -1);

      /// <summary>Adds the specified control to the control collection.</summary>
      /// <param name="objNewControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection.</param>
      /// <param name="blnRegisterControl">if set to <c>true</c> [BLN is add range].</param>
      /// <param name="intIndex">Index for insertion.</param>
      /// <exception cref="T:System.Exception">The specified control is a top-level control, or a circular control reference would result if this control were added to the control collection. </exception>
      /// <exception cref="T:System.ArgumentException">The object assigned to the value parameter is not a <see cref="T:Gizmox.WebGUI.Forms.Control"></see>. </exception>
      protected virtual void Add(Control objNewControl, bool blnRegisterControl, int intIndex)
      {
        if (objNewControl == null)
          return;
        if (objNewControl.GetTopLevel())
          throw new ArgumentException(SR.GetString("TopLevelControlAdd"));
        Control.CheckParentingCycle(this.mobjOwnerControl, objNewControl);
        if (objNewControl.Parent == this.mobjOwnerControl && this.Contains(objNewControl))
        {
          objNewControl.SendToBack();
        }
        else
        {
          if (objNewControl.Parent != null)
            objNewControl.Parent.Controls.Remove(objNewControl);
          if (intIndex >= 0)
            this.InnerList.Insert(intIndex, (object) objNewControl);
          else
            this.InnerList.Add((object) objNewControl);
          if (objNewControl.mintTabIndex == -1)
          {
            int num = 0;
            for (int index = 0; index < this.Count - 1; ++index)
            {
              int tabIndex = this[index].TabIndex;
              if (num <= tabIndex)
                num = tabIndex + 1;
            }
            objNewControl.mintTabIndex = num;
          }
          objNewControl.AssignParent(this.mobjOwnerControl);
          if (blnRegisterControl)
          {
            objNewControl.RegisterSelf();
            this.UpdateOwner();
          }
          if (objNewControl.Visible && this.mobjOwnerControl.Created)
            objNewControl.CreateControl();
          this.mobjOwnerControl.OnControlAdded(new ControlEventArgs(objNewControl));
          this.mobjOwnerControl.InvalidateLayout(new LayoutEventArgs(false, true, true));
          if (this.ObservableItemAdded != null)
            this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objNewControl));
        }
        this.UpdateProxyForm();
      }

      /// <summary>Adds an array of control objects to the collection.</summary>
      /// <param name="arrControls">An array of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects to add to the collection. </param>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public virtual void AddRange(Control[] arrControls)
      {
        if (arrControls == null)
          throw new ArgumentNullException("controls");
        if (arrControls.Length == 0)
          return;
        this.mobjOwnerControl.SuspendLayout();
        try
        {
          for (int index = 0; index < arrControls.Length; ++index)
            this.Add(arrControls[index], false, -1);
          this.mobjOwnerControl.RegisterBatch((ICollection) arrControls);
          this.UpdateOwner();
          this.UpdateProxyForm();
        }
        finally
        {
          this.mobjOwnerControl.ResumeLayout(true);
        }
      }

      /// <summary>Removes all controls from the collection.</summary>
      public virtual void Clear()
      {
        this.mobjOwnerControl.SuspendLayout();
        try
        {
          while (this.Count != 0)
            this.RemoveAt(this.Count - 1);
        }
        finally
        {
          this.mobjOwnerControl.ResumeLayout();
        }
        if (this.ObservableListCleared == null)
          return;
        this.ObservableListCleared((object) this, EventArgs.Empty);
      }

      /// <summary>Determines whether the specified control is a member of the collection.</summary>
      /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a member of the collection; otherwise, false.</returns>
      /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to locate in the collection. </param>
      public bool Contains(Control objControl) => this.InnerList.Contains((object) objControl);

      /// <summary>Determines whether the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> contains an item with the specified key.</summary>
      /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> contains an item with the specified key; otherwise, false.</returns>
      /// <param name="strKey">The key to locate in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
      public virtual bool ContainsKey(string strKey) => this.IsValidIndex(this.IndexOfKey(strKey));

      /// <summary>Searches for controls by their <see cref="P:Gizmox.WebGUI.Forms.Control.Name"></see> property and builds an array of all the controls that match.</summary>
      /// <returns>An array of type <see cref="T:Gizmox.WebGUI.Forms.Control"></see> containing the matching controls.</returns>
      /// <param name="blnSearchAllChildren">true to search all child controls; otherwise, false. </param>
      /// <param name="strKey">The key to locate in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
      /// <exception cref="T:System.ArgumentException">The key parameter is null or the empty string (""). </exception>
      public Control[] Find(string strKey, bool blnSearchAllChildren)
      {
        ArrayList arrayList = !CommonUtils.IsNullOrEmpty(strKey) ? this.FindInternal(strKey, blnSearchAllChildren, this, new ArrayList()) : throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
        Control[] controlArray = new Control[arrayList.Count];
        arrayList.CopyTo((Array) controlArray, 0);
        return controlArray;
      }

      private ArrayList FindInternal(
        string strKey,
        bool blnSearchAllChildren,
        Control.ControlCollection objControlsToLookIn,
        ArrayList foundControls)
      {
        if (objControlsToLookIn != null)
        {
          if (foundControls != null)
          {
            try
            {
              for (int index = 0; index < objControlsToLookIn.Count; ++index)
              {
                if (objControlsToLookIn[index] != null && ClientUtils.SafeCompareStrings(objControlsToLookIn[index].Name, strKey, true))
                  foundControls.Add((object) objControlsToLookIn[index]);
              }
              if (!blnSearchAllChildren)
                return foundControls;
              for (int index = 0; index < objControlsToLookIn.Count; ++index)
              {
                if (objControlsToLookIn[index] != null && objControlsToLookIn[index].Controls != null && objControlsToLookIn[index].Controls.Count > 0)
                  foundControls = this.FindInternal(strKey, blnSearchAllChildren, objControlsToLookIn[index].Controls, foundControls);
              }
            }
            catch (Exception ex)
            {
              if (ClientUtils.IsSecurityOrCriticalException(ex))
                throw;
            }
            return foundControls;
          }
        }
        return (ArrayList) null;
      }

      /// <summary>Retrieves the index of the specified child control within the control collection.</summary>
      /// <returns>A zero-based index value that represents the location of the specified child control within the control collection.</returns>
      /// <param name="objChild">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for in the control collection. </param>
      /// <exception cref="T:System.ArgumentException">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </exception>
      public int GetChildIndex(Control objChild) => this.GetChildIndex(objChild, true);

      /// <summary>Retrieves the index of the specified child control within the control collection, and optionally raises an exception if the specified control is not within the control collection.</summary>
      /// <returns>A zero-based index value that represents the location of the specified child control within the control collection; otherwise -1 if the specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not found in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
      /// <param name="blnThrowException">true to throw an exception if the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> specified in the child parameter is not a control in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>; otherwise, false. </param>
      /// <param name="objChild">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for in the control collection. </param>
      /// <exception cref="T:System.ArgumentException">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>, and the throwException parameter value is true. </exception>
      public virtual int GetChildIndex(Control objChild, bool blnThrowException)
      {
        int num = this.IndexOf(objChild);
        return !(num == -1 & blnThrowException) ? num : throw new ArgumentException(SR.GetString("ControlNotChild"));
      }

      /// <summary>Retrieves a reference to an enumerator object that is used to iterate over a <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see>.</returns>
      public override IEnumerator GetEnumerator() => (IEnumerator) new Control.ControlCollection.ControlCollectionEnumerator(this);

      /// <summary>Retrieves the index of the specified control in the control collection.</summary>
      /// <returns>A zero-based index value that represents the position of the specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
      /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to locate in the collection. </param>
      public int IndexOf(Control objControl) => this.InnerList.IndexOf((object) objControl);

      /// <summary>Retrieves the index of the first occurrence of the specified item within the collection.</summary>
      /// <returns>The zero-based index of the first occurrence of the control with the specified name in the collection.</returns>
      /// <param name="strKey">The name of the control to search for. </param>
      public virtual int IndexOfKey(string strKey)
      {
        if (!CommonUtils.IsNullOrEmpty(strKey))
        {
          if (this.IsValidIndex(this.mintLastAccessedIndex) && ClientUtils.SafeCompareStrings(this[this.mintLastAccessedIndex].Name, strKey, true))
            return this.mintLastAccessedIndex;
          for (int index = 0; index < this.Count; ++index)
          {
            if (ClientUtils.SafeCompareStrings(this[index].Name, strKey, true))
            {
              this.mintLastAccessedIndex = index;
              return index;
            }
          }
          this.mintLastAccessedIndex = -1;
        }
        return -1;
      }

      private bool IsValidIndex(int index) => index >= 0 && index < this.Count;

      /// <summary>Removes the specified control from the control collection.</summary>
      /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove from the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
      public virtual void Remove(Control objValue)
      {
        if (objValue == null || !this.InnerList.Contains((object) objValue))
          return;
        this.InnerList.Remove((object) objValue);
        objValue.UnRegisterSelf();
        objValue.AssignParent((Control) null);
        this.UpdateOwner();
        this.mobjOwnerControl.OnControlRemoved(new ControlEventArgs(objValue));
        this.mobjOwnerControl.InvalidateLayout(new LayoutEventArgs(false, true, true));
        if (this.ObservableItemRemoved != null)
          this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objValue));
        if (this.mobjOwnerControl.GetContainerControlInternal() is ContainerControl containerControlInternal)
          containerControlInternal.AfterControlRemoved(objValue, this.mobjOwnerControl);
        this.UpdateProxyForm();
      }

      /// <summary>Removes a control from the control collection at the specified indexed location.</summary>
      /// <param name="index">The index value of the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove. </param>
      public void RemoveAt(int index) => this.Remove(this[index]);

      /// <summary>Removes the child control with the specified key.</summary>
      /// <param name="strKey">The name of the child control to remove. </param>
      public virtual void RemoveByKey(string strKey)
      {
        int index = this.IndexOfKey(strKey);
        if (!this.IsValidIndex(index))
          return;
        this.RemoveAt(index);
      }

      /// <summary>Sets the index of the specified child control in the collection to the specified index value.</summary>
      /// <param name="objChild">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for. </param>
      /// <param name="intNewIndex">The new index value of the control. </param>
      /// <exception cref="T:System.ArgumentException">The child control is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </exception>
      public virtual void SetChildIndex(Control objChild, int intNewIndex) => this.SetChildIndexInternal(objChild, intNewIndex);

      internal void Sort(IComparer objComparer)
      {
        this.InnerList.Sort(objComparer);
        this.UpdateOwner();
      }

      internal virtual void SetChildIndexInternal(Control objChild, int intNewIndex)
      {
        int intFromIndex = objChild != null ? this.GetChildIndex(objChild) : throw new ArgumentNullException("child");
        if (intFromIndex == intNewIndex)
          return;
        if (intNewIndex >= this.Count || intNewIndex == -1)
          intNewIndex = this.Count - 1;
        this.MoveElement((IArrangedElement) objChild, intFromIndex, intNewIndex);
        this.UpdateOwner();
      }

      int IList.Add(object objControl)
      {
        if (!(objControl is Control))
          throw new ArgumentException(SR.GetString("ControlBadControl"), "control");
        this.Add((Control) objControl);
        return this.IndexOf((Control) objControl);
      }

      /// <summary>Updates the owner.</summary>
      protected virtual void UpdateOwner()
      {
        if (this.mobjOwnerControl == null)
          return;
        this.mobjOwnerControl.Update();
      }

      /// <summary>Updates the proxy form.</summary>
      private void UpdateProxyForm()
      {
        if (this.mobjOwnerControl == null)
          return;
        Form form = this.mobjOwnerControl.Form;
        if (form == null || !(form.ProxyComponent is ProxyForm proxyComponent))
          return;
        proxyComponent.ValidateSourceComponent();
      }

      void IList.Remove(object objControl)
      {
        if (!(objControl is Control))
          return;
        this.Remove((Control) objControl);
      }

      object ICloneable.Clone()
      {
        Control.ControlCollection controlsInstance = this.mobjOwnerControl.CreateControlsInstance();
        controlsInstance.InnerList.AddRange((ICollection) this);
        return (object) controlsInstance;
      }

      /// <summary>Indicates a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> with the specified key in the collection.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> with the specified key within the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
      /// <param name="strKey">The name of the control to retrieve from the control collection.</param>
      public virtual Control this[string strKey]
      {
        get
        {
          if (!CommonUtils.IsNullOrEmpty(strKey))
          {
            int index = this.IndexOfKey(strKey);
            if (this.IsValidIndex(index))
              return this[index];
          }
          return (Control) null;
        }
      }

      /// <summary>Indicates the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> at the specified indexed location in the collection.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> located at the specified index location within the control collection.</returns>
      /// <param name="index">The index of the control to retrieve from the control collection. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than zero or is greater than or equal to the number of controls in the collection. </exception>
      public virtual Control this[int index] => index >= 0 && index < this.Count ? (Control) this.InnerList[index] : throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("IndexOutOfRange"));

      /// <summary>Gets the control that owns this <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that owns this <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
      public Control Owner => this.mobjOwnerControl;

      /// <summary>Occurs when [observable item added].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemAdded;

      /// <summary>Occurs when [observable item inserted].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemInserted;

      /// <summary>Occurs when [observable item removed].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemRemoved;

      /// <summary>Occurs when [observable list cleared].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event EventHandler ObservableListCleared;

      /// <summary>
      /// Gets a value indicating whether the collection is read-only.
      /// </summary>
      /// <value></value>
      /// <returns>true if the collection is read-only; otherwise, false. The default is false.</returns>
      public override bool IsReadOnly => this.InnerList.IsReadOnly;

      /// <summary>
      /// Gets or sets the <see cref="T:System.Object" /> at the specified index.
      /// </summary>
      /// <value></value>
      object IList.this[int index]
      {
        get => this.InnerList[index];
        set => this.InnerList[index] = value;
      }

      /// <summary>Inserts the specified int index.</summary>
      /// <param name="intIndex">Index of the value.</param>
      /// <param name="objValue">The value.</param>
      public void Insert(int intIndex, object objValue) => this.Add(objValue as Control, true, intIndex);

      /// <summary>
      /// Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.
      /// </summary>
      /// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
      /// <returns>
      /// true if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, false.
      /// </returns>
      bool IList.Contains(object objValue) => this.InnerList.Contains(objValue);

      /// <summary>
      /// Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.
      /// </summary>
      /// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
      /// <returns>
      /// The index of <paramref name="value" /> if found in the list; otherwise, -1.
      /// </returns>
      int IList.IndexOf(object objValue) => this.InnerList.IndexOf(objValue);

      /// <summary>
      /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
      /// </summary>
      /// <value></value>
      /// <returns>true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.
      /// </returns>
      public bool IsFixedSize => this.InnerList.IsFixedSize;

      bool ICollection.IsSynchronized => this.InnerList.IsSynchronized;

      /// <summary>Gets the number of elements in the collection.</summary>
      /// <value></value>
      /// <returns>The number of elements currently contained in the collection.</returns>
      public new int Count => this.InnerList.Count;

      void ICollection.CopyTo(Array objArray, int index) => this.InnerList.CopyTo(objArray, index);

      object ICollection.SyncRoot => this.InnerList.SyncRoot;

      [Serializable]
      private class ControlCollectionEnumerator : IEnumerator
      {
        private Control.ControlCollection mobjControls;
        private int mintCurrent;
        private int mintOriginalCount;

        public ControlCollectionEnumerator(Control.ControlCollection objControls)
        {
          this.mobjControls = objControls;
          this.mintOriginalCount = objControls.Count;
          this.mintCurrent = -1;
        }

        public bool MoveNext()
        {
          if (this.mintCurrent >= this.mobjControls.Count - 1 || this.mintCurrent >= this.mintOriginalCount - 1)
            return false;
          ++this.mintCurrent;
          return true;
        }

        public void Reset() => this.mintCurrent = -1;

        public object Current => this.mintCurrent == -1 ? (object) null : (object) this.mobjControls[this.mintCurrent];
      }
    }

    /// <summary>The current control version information</summary>
    [Serializable]
    private class ControlVersionInfo
    {
      /// <summary>The control company name</summary>
      private string mstrCompanyName;
      /// <summary>The control</summary>
      private Control mobjOwner;
      /// <summary>The product name</summary>
      private string mstrProductName;
      /// <summary>The product version</summary>
      private string mstrProductVersion;

      /// <summary>Create a new control version information</summary>
      /// <param name="objOwner">The obj owner.</param>
      internal ControlVersionInfo(Control objOwner) => this.mobjOwner = objOwner;

      /// <summary>Get the control company name</summary>
      internal string CompanyName
      {
        get
        {
          if (this.mstrCompanyName == null)
          {
            object[] customAttributes = this.mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
            if (customAttributes != null && customAttributes.Length != 0)
              this.mstrCompanyName = ((AssemblyCompanyAttribute) customAttributes[0]).Company;
            if (this.mstrCompanyName == null || this.mstrCompanyName.Length == 0)
            {
              string str = this.mobjOwner.GetType().Namespace ?? string.Empty;
              int length = str.IndexOf("/");
              this.mstrCompanyName = length == -1 ? str : str.Substring(0, length);
            }
          }
          return this.mstrCompanyName;
        }
      }

      /// <summary>Get the control product name</summary>
      internal string ProductName
      {
        get
        {
          if (this.mstrProductName == null)
          {
            object[] customAttributes = this.mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof (AssemblyProductAttribute), false);
            if (customAttributes != null && customAttributes.Length != 0)
              this.mstrProductName = ((AssemblyProductAttribute) customAttributes[0]).Product;
            if (this.mstrProductName == null || this.mstrProductName.Length == 0)
            {
              string str = this.mobjOwner.GetType().Namespace ?? string.Empty;
              int num = str.IndexOf(".");
              this.mstrProductName = num == -1 ? str : str.Substring(num + 1);
            }
          }
          return this.mstrProductName;
        }
      }

      /// <summary>Get the control product version</summary>
      internal string ProductVersion
      {
        get
        {
          if (this.mstrProductVersion == null)
          {
            object[] customAttributes = this.mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof (AssemblyInformationalVersionAttribute), false);
            if (customAttributes != null && customAttributes.Length != 0)
              this.mstrProductVersion = ((AssemblyInformationalVersionAttribute) customAttributes[0]).InformationalVersion;
            if (this.mstrProductVersion == null || this.mstrProductVersion.Length == 0)
              this.mstrProductVersion = "1.0.0.0";
          }
          return this.mstrProductVersion;
        }
      }
    }

    [Flags]
    internal enum ControlState
    {
      /// <summary>The top level flag</summary>
      TopLevel = 1,
      /// <summary>The tab stop flag</summary>
      TabStop = 2,
      /// <summary>The becoming active control flag</summary>
      BecomingActiveControl = 4,
      /// <summary>The has positioning flag</summary>
      HasPositioning = 8,
      /// <summary>Layout dirty flag.</summary>
      LayoutIsDirty = 16, // 0x00000010
      /// <summary>The cause validation flag</summary>
      CausesValidation = 32, // 0x00000020
      /// <summary>The validation cancelled flag</summary>
      ValidationCancelled = 64, // 0x00000040
      /// <summary>The auto scroll flag</summary>
      AutoScroll = 128, // 0x00000080
      /// <summary>The hscroll flag</summary>
      HScroll = 256, // 0x00000100
      /// <summary>The vscroll flag</summary>
      VScroll = 512, // 0x00000200
      /// <summary>The auto size state flag</summary>
      AutoSize = 1024, // 0x00000400
      /// <summary>The created flag</summary>
      Created = 2048, // 0x00000800
      /// <summary>The sorted flag</summary>
      Sorted = 4096, // 0x00001000
    }
  }
}
