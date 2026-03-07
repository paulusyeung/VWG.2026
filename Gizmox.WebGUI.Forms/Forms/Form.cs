// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Form
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Virtualization.Management;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a window or dialog box that makes up an application's user interface.
  /// </summary>
  [ToolboxItem(false)]
  [ToolboxBitmap(typeof (Form), "Forms.Form.bmp")]
  [DesignerCategory("Form")]
  [InitializationEvent("Load")]
  [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof (IRootDesigner))]
  [DesignTimeVisible(false)]
  [DefaultEvent("Load")]
  [Gizmox.WebGUI.Forms.MetadataTag("F")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (FormSkin))]
  [ProxyComponent(typeof (ProxyForm))]
  [Serializable]
  public class Form : 
    ContainerControl,
    IForm,
    IControl,
    IRegisteredComponent,
    IEventHandler,
    IWin32Window,
    IFormParams,
    IObservableList
  {
    /// <summary>
    /// Provides a property reference to TransparencyKey property.
    /// </summary>
    private static SerializableProperty TransparencyKeyProperty = SerializableProperty.Register(nameof (TransparencyKey), typeof (Color), typeof (Form), new SerializablePropertyMetadata((object) Color.Empty));
    /// <summary>Provides a property reference to Header property.</summary>
    private static SerializableProperty HeaderProperty = SerializableProperty.Register(nameof (Header), typeof (Control), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to Icon property.</summary>
    private static SerializableProperty IconProperty = SerializableProperty.Register(nameof (Icon), typeof (ResourceHandle), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to MdiClient property.</summary>
    private static SerializableProperty MdiClientProperty = SerializableProperty.Register(nameof (MdiClient), typeof (MdiClient), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to OwnerProperty property.
    /// </summary>
    private static SerializableProperty OwnerProperty = SerializableProperty.Register(nameof (OwnerProperty), typeof (Form), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to DialogType property.</summary>
    private static SerializableProperty DialogTypeProperty = SerializableProperty.Register(nameof (DialogType), typeof (DialogTypes), typeof (Form), new SerializablePropertyMetadata((object) DialogTypes.MainWindow));
    /// <summary>
    /// Provides a property reference to AcceptButton property.
    /// </summary>
    private static SerializableProperty AcceptButtonProperty = SerializableProperty.Register(nameof (AcceptButton), typeof (IButtonControl), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to BeforeUnloadMessage property.
    /// </summary>
    private static SerializableProperty BeforeUnloadMessageProperty = SerializableProperty.Register(nameof (BeforeUnloadMessage), typeof (string), typeof (Form), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to CancelButton property.
    /// </summary>
    private static SerializableProperty CancelButtonProperty = SerializableProperty.Register(nameof (CancelButton), typeof (IButtonControl), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to DialogResult property.
    /// </summary>
    private static SerializableProperty DialogResultProperty = SerializableProperty.Register(nameof (DialogResult), typeof (DialogResult), typeof (Form), new SerializablePropertyMetadata((object) DialogResult.None));
    /// <summary>
    /// Provides a property reference to DialogAlignment property.
    /// </summary>
    private static SerializableProperty DialogAlignmentProperty = SerializableProperty.Register(nameof (DialogAlignment), typeof (DialogAlignment), typeof (Form), new SerializablePropertyMetadata((object) DialogAlignment.Below));
    /// <summary>
    /// Provides a property reference to AlignmentId property.
    /// </summary>
    private static SerializableProperty AlignmentIdProperty = SerializableProperty.Register("AlignmentId", typeof (string), typeof (Form), new SerializablePropertyMetadata((object) "0"));
    /// <summary>
    /// Provides a property reference to MemberAlignmentId property.
    /// </summary>
    private static SerializableProperty MemberAlignmentIdProperty = SerializableProperty.Register("MemberAlignmentId", typeof (string), typeof (Form), new SerializablePropertyMetadata((object) "0"));
    /// <summary>
    /// Provides a property reference to StartPosition property.
    /// </summary>
    private static SerializableProperty StartPositionProperty = SerializableProperty.Register(nameof (StartPosition), typeof (FormStartPosition), typeof (Form), new SerializablePropertyMetadata((object) FormStartPosition.WindowsDefaultLocation));
    /// <summary>
    /// Provides a property reference to FormBorderStyle property.
    /// </summary>
    private static SerializableProperty FormBorderStyleProperty = SerializableProperty.Register(nameof (FormBorderStyle), typeof (FormBorderStyle), typeof (Form), new SerializablePropertyMetadata((object) FormBorderStyle.Sizable));
    /// <summary>
    /// Provides a property reference to WindowState property.
    /// </summary>
    private static SerializableProperty WindowStateProperty = SerializableProperty.Register(nameof (WindowState), typeof (FormWindowState), typeof (Form), new SerializablePropertyMetadata((object) FormWindowState.Normal));
    /// <summary>Provides a property reference to FormStyle property.</summary>
    private static SerializableProperty FormStyleProperty = SerializableProperty.Register(nameof (FormStyle), typeof (FormStyle), typeof (Form), new SerializablePropertyMetadata((object) FormStyle.Dialog));
    /// <summary>Provides the entrance visual effect property</summary>
    private static SerializableProperty EntranceVisualEffectProperty = SerializableProperty.Register("EntranceVisualEffect", typeof (VisualEffect), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides the exit visual effect property</summary>
    private static SerializableProperty ExitVisualEffectProperty = SerializableProperty.Register("ExitVisualEffect", typeof (VisualEffect), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to MdiParent property.</summary>
    private static SerializableProperty MdiParentProperty = SerializableProperty.Register(nameof (MdiParent), typeof (Form), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to Menu property.</summary>
    private static SerializableProperty MenuProperty = SerializableProperty.Register(nameof (Menu), typeof (MainMenu), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to MainMenuStrip property.
    /// </summary>
    private static SerializableProperty MainMenuStripProperty = SerializableProperty.Register(nameof (MainMenuStrip), typeof (MenuStrip), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ClientStorage property.
    /// </summary>
    private static SerializableProperty ClientStorageProperty = SerializableProperty.Register(nameof (ClientStorage), typeof (ClientStorage), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to GeoLocationData property.
    /// </summary>
    private static SerializableProperty GeoLocationDataProperty = SerializableProperty.Register("GeoLocationData", typeof (GeoLocationData), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to Shortcuts property.</summary>
    private static SerializableProperty ShortcutsProperty = SerializableProperty.Register(nameof (Shortcuts), typeof (ShortcutsContainer), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to FormRestoredWindowState property.
    /// </summary>
    private static SerializableProperty FormRestoredWindowStateProperty = SerializableProperty.Register(nameof (FormRestoredWindowState), typeof (FormWindowState), typeof (Form), new SerializablePropertyMetadata((object) FormWindowState.Normal));
    /// <summary>
    /// Provides a property reference to FormRestoredSize property.
    /// </summary>
    private static SerializableProperty FormRestoredSizeProperty = SerializableProperty.Register(nameof (FormRestoredSize), typeof (Size), typeof (Form), new SerializablePropertyMetadata((object) Size.Empty));
    /// <summary>
    /// Provides a property reference to FormRestoredLocation property.
    /// </summary>
    private static SerializableProperty FormRestoredLocationProperty = SerializableProperty.Register(nameof (FormRestoredLocation), typeof (Point), typeof (Form), new SerializablePropertyMetadata((object) Point.Empty));
    /// <summary>
    /// Provides a property reference to ActivateOnShow property.
    /// </summary>
    private static SerializableProperty ActivateOnShowProperty = SerializableProperty.Register(nameof (ActivateOnShow), typeof (bool), typeof (Form), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to ControlBox property.</summary>
    private static SerializableProperty ControlBoxProperty = SerializableProperty.Register(nameof (ControlBox), typeof (bool), typeof (Form), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to KeyPreview property.</summary>
    private static SerializableProperty KeyPreviewProperty = SerializableProperty.Register(nameof (KeyPreview), typeof (bool), typeof (Form), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to HelpButton property.</summary>
    private static SerializableProperty HelpButtonProperty = SerializableProperty.Register(nameof (HelpButton), typeof (bool), typeof (Form), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to ClosedDelegate property.
    /// </summary>
    private static SerializableProperty ClosedDelegateProperty = SerializableProperty.Register(nameof (ClosedDelegate), typeof (EventHandler), typeof (Form), new SerializablePropertyMetadata((object) null));
    /// <summary>The Load event registration.</summary>
    private static readonly SerializableEvent LoadEvent = SerializableEvent.Register("Load", typeof (EventHandler), typeof (Form));
    /// <summary>The Closed event registration.</summary>
    private static readonly SerializableEvent ClosedEvent = SerializableEvent.Register("Closed", typeof (EventHandler), typeof (Form));
    /// <summary>The Closing event registration.</summary>
    private static readonly SerializableEvent ClosingEvent = SerializableEvent.Register("Closing", typeof (CancelEventHandler), typeof (Form));
    /// <summary>
    /// 
    /// </summary>
    private static readonly SerializableEvent FormClosingEvent = SerializableEvent.Register("FormClosing", typeof (Form.FormClosingEventHandler), typeof (Form));
    /// <summary>The Closed event registration.</summary>
    private static readonly SerializableEvent FormClosedEvent = SerializableEvent.Register("FormClosed", typeof (Form.FormClosedEventHandler), typeof (Form));
    /// <summary>The Activated event registration.</summary>
    private static readonly SerializableEvent ActivatedEvent = SerializableEvent.Register("Activated", typeof (EventHandler), typeof (Form));
    /// <summary>The Deactivate event registration.</summary>
    private static readonly SerializableEvent DeactivateEvent = SerializableEvent.Register("Deactivate", typeof (EventHandler), typeof (Form));
    /// <summary>
    /// 
    /// </summary>
    private static readonly SerializableEvent OrientationChangedEvent = SerializableEvent.Register("OrientationChange", typeof (Form.OrientationChangedEventHandler), typeof (Form));
    /// <summary>The GeographicLocationChanged event registration.</summary>
    private static readonly SerializableEvent GeographicLocationChangedEvent = SerializableEvent.Register("GeographicLocationChanged", typeof (GeographicLocationChangedEventHandler), typeof (Form));
    /// <summary>The current context object</summary>
    [NonSerialized]
    private IContext mobjContext;
    /// <summary>The form owned forms</summary>
    [NonSerialized]
    private FormCollection mobjOwnedForms;
    private HtmlBox mobjUnauthorizedAccessHtmlBox;
    /// <summary>The amount of fields the form needs to serialize</summary>
    private const int mintFormSerializableFieldCount = 1;
    private object mobjAligmentComponent;
    private IIdentifiedComponent mobjAlignmentMemberComponent;
    /// <summary>The form state</summary>
    [NonSerialized]
    private int mintFormState;
    /// <summary>The ModalMask property registration.</summary>
    private static readonly SerializableProperty ModalMaskProperty = SerializableProperty.Register(nameof (ModalMask), typeof (bool), typeof (Form), new SerializablePropertyMetadata((object) true));
    /// <summary>The ObservableItemAdded event registration.</summary>
    private static readonly SerializableEvent ObservableItemAddedEvent = SerializableEvent.Register("ObservableItemAdded", typeof (ObservableListEventHandler), typeof (Form));
    /// <summary>The ObservableItemInserted event registration.</summary>
    private static readonly SerializableEvent ObservableItemInsertedEvent = SerializableEvent.Register("ObservableItemInserted", typeof (ObservableListEventHandler), typeof (Form));
    /// <summary>The ObservableItemRemoved event registration.</summary>
    private static readonly SerializableEvent ObservableItemRemovedEvent = SerializableEvent.Register("ObservableItemRemoved", typeof (ObservableListEventHandler), typeof (Form));
    /// <summary>The ObservableListCleared event registration.</summary>
    private static readonly SerializableEvent ObservableListClearedEvent = SerializableEvent.Register("ObservableListCleared", typeof (EventHandler), typeof (Form));

    /// <summary>The form load event</summary>
    public event EventHandler Load
    {
      add => this.AddHandler(Form.LoadEvent, (Delegate) value);
      remove => this.RemoveHandler(Form.LoadEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Load event.</summary>
    private EventHandler LoadHandler => (EventHandler) this.GetHandler(Form.LoadEvent);

    /// <summary>Occurs when the form is closed.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [SRDescription("FormOnClosedDescr")]
    [Browsable(false)]
    public event EventHandler Closed
    {
      add => this.AddCriticalHandler(Form.ClosedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.ClosedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Closed event.</summary>
    private EventHandler ClosedHandler => (EventHandler) this.GetHandler(Form.ClosedEvent);

    /// <summary>Occurs when the form is closing.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("FormOnClosingDescr")]
    [Browsable(false)]
    public event CancelEventHandler Closing
    {
      add => this.AddCriticalHandler(Form.ClosingEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.ClosingEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Closing event.</summary>
    private CancelEventHandler ClosingHandler => (CancelEventHandler) this.GetHandler(Form.ClosingEvent);

    /// <summary>Occurs before the form is closed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("FormOnFormClosingDescr")]
    [SRCategory("CatBehavior")]
    public event Form.FormClosingEventHandler FormClosing
    {
      add => this.AddCriticalHandler(Form.FormClosingEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.FormClosingEvent, (Delegate) value);
    }

    /// <summary>Gets the form closing handler.</summary>
    /// <value>The form closing handler.</value>
    private Form.FormClosingEventHandler FormClosingHandler => (Form.FormClosingEventHandler) this.GetHandler(Form.FormClosingEvent);

    /// <summary>Occurs after the form is closed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("FormOnFormClosedDescr")]
    public event Form.FormClosedEventHandler FormClosed
    {
      add => this.AddCriticalHandler(Form.FormClosedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.FormClosedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Closed event.</summary>
    private Form.FormClosedEventHandler FormClosedHandler => (Form.FormClosedEventHandler) this.GetHandler(Form.FormClosedEvent);

    /// <summary>
    /// Occurs when the form is activated in code or by the user.
    /// </summary>
    public event EventHandler Activated
    {
      add => this.AddCriticalHandler(Form.ActivatedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.ActivatedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Activated event.</summary>
    private EventHandler ActivatedHandler => (EventHandler) this.GetHandler(Form.ActivatedEvent);

    /// <devdoc>
    ///    <para>Occurs when the form loses focus and is not the active form.</para>
    /// </devdoc>
    [SRDescription("FormOnDeactivateDescr")]
    [SRCategory("CatFocus")]
    public event EventHandler Deactivate
    {
      add => this.AddCriticalHandler(Form.DeactivateEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.DeactivateEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Deactivate event.</summary>
    private EventHandler DeactivateHandler => (EventHandler) this.GetHandler(Form.DeactivateEvent);

    /// <summary>Occurs when orientation is changed.</summary>
    [SRCategory("Mobile Devices")]
    [Description("OrientationChange Happens when moblie device orientation is changed from landscape to  portrait.")]
    public event Form.OrientationChangedEventHandler OrientationChanged
    {
      add => this.AddCriticalHandler(Form.OrientationChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(Form.OrientationChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client orientation changed].</summary>
    [SRDescription("Occurs when oblie device orientation is changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientOrientationChanged
    {
      add => this.AddClientHandler("OrientationChange", value);
      remove => this.RemoveClientHandler("OrientationChange", value);
    }

    /// <summary>Gets the orientation change handler.</summary>
    private Form.OrientationChangedEventHandler OrientationChangedHandler => (Form.OrientationChangedEventHandler) this.GetHandler(Form.OrientationChangedEvent);

    /// <summary>Occurs when [location changed].</summary>
    public event GeographicLocationChangedEventHandler GeographicLocationChanged
    {
      add
      {
        this.ValidateGeoLocationCapability();
        this.AddHandler(Form.GeographicLocationChangedEvent, (Delegate) value);
      }
      remove => this.RemoveHandler(Form.GeographicLocationChangedEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client geographic location changed].</summary>
    [SRDescription("Occurs when device geolocation changes in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientGeographicLocationChanged
    {
      add => this.AddClientHandler("GeoLocationChanged", value);
      remove => this.RemoveClientHandler("GeoLocationChanged", value);
    }

    /// <summary>Gets the geographic location changed handler.</summary>
    private GeographicLocationChangedEventHandler GeographicLocationChangedHandler => (GeographicLocationChangedEventHandler) this.GetHandler(Form.GeographicLocationChangedEvent);

    private event EventHandler mobjPreRender;

    /// <summary>Gets the security stopper html box.</summary>
    /// <value>The security stopper.</value>
    private HtmlBox UnauthorizedAccessHtmlBox
    {
      get
      {
        if (this.mobjUnauthorizedAccessHtmlBox == null)
        {
          this.mobjUnauthorizedAccessHtmlBox = new HtmlBox();
          this.mobjUnauthorizedAccessHtmlBox.Dock = DockStyle.Fill;
          this.mobjUnauthorizedAccessHtmlBox.Url = "Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Commons.Messages.Unauthorized.html.wgx";
        }
        return this.mobjUnauthorizedAccessHtmlBox;
      }
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Form" /> instance.
    /// </summary>
    public Form(IContext objContext) => this.InitializeForm(objContext);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Form" /> instance.
    /// </summary>
    public Form()
    {
      try
      {
        this.InitializeForm(VWGContext.Current);
      }
      catch (Exception ex)
      {
      }
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        this.CalledOnLoad = false;
        this.CalledMakeVisible = false;
        this.CalledCreateControl = false;
        MainMenu menu = this.Menu;
        if (menu == null || menu.Form != this)
          return;
        menu.Dispose();
        this.Menu = (MainMenu) null;
      }
      else
        base.Dispose(blnDisposing);
    }

    /// <summary>Validates the geo location capability.</summary>
    private void ValidateGeoLocationCapability()
    {
      if (!this.DesignMode && this.Context is IContextParams context && (context.MISCBrowserCapabilities & MISCBrowserCapabilities.Geolocation) != MISCBrowserCapabilities.Geolocation)
        throw new NotSupportedException("Your browser does not support geographic location services.");
    }

    /// <summary>Initializes the form.</summary>
    /// <param name="objContext">The current context.</param>
    private void InitializeForm(IContext objContext)
    {
      this.SetContextInternal(objContext);
      this.VisibleIntenal = false;
      this.GeographicLocation = new GeoLocationData();
      if (!this.DesignMode)
        this.GeographicLocation.GeoLocationDataChanged += new EventHandler(this.OnGeoLocationDataChanged);
      this.SetState(Form.FormState.MaximizeBox | Form.FormState.MinimizeBox | Form.FormState.CloseBox, true);
      this.SetTopLevel(true);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 1 + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjOwnedForms);

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mintFormState = objReader.ReadInt32();
      object[] arrForms = objReader.ReadArray();
      if (arrForms.Length == 0)
        return;
      this.mobjOwnedForms = new FormCollection(this, arrForms);
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteInt32(this.mintFormState);
      objWriter.WriteArray((ICollection) this.mobjOwnedForms);
    }

    /// <summary>Sets the state.</summary>
    /// <param name="enmState">State of the enm.</param>
    /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
    internal void SetState(Form.FormState enmState, bool blnValue) => this.mintFormState = blnValue ? (int) ((Form.FormState) this.mintFormState | enmState) : (int) ((Form.FormState) this.mintFormState & ~enmState);

    /// <summary>Sets the state with check.</summary>
    /// <param name="enmState">State of the enm.</param>
    /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
    /// <returns></returns>
    internal bool SetStateWithCheck(Form.FormState enmState, bool blnValue)
    {
      if (this.GetState(enmState) == blnValue)
        return false;
      this.SetState(enmState, blnValue);
      return true;
    }

    private void OnGeoLocationDataChanged(object sender, EventArgs e) => this.UpdateParams(AttributeType.GeographicLocation);

    /// <summary>Gets the state.</summary>
    /// <param name="enmState">State of the enm.</param>
    /// <returns></returns>
    internal bool GetState(Form.FormState enmState) => ((Form.FormState) this.mintFormState & enmState) != 0;

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree/
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected internal override void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.Parent != null)
      {
        base.RenderControl(objContext, objWriter, lngRequestID);
      }
      else
      {
        objWriter.WriteStartElement(((IServerResponse) objContext.Response).GeneralNamespacePrefix, this.MetadataTag, ((IServerResponse) objContext.Response).GeneralNamespaceUrl);
        if (this.IsDirty(lngRequestID))
        {
          this.RenderAttributes(objContext, (IAttributeWriter) objWriter);
          this.RenderComponentClientEvents(objContext, objWriter, lngRequestID);
        }
        else
          this.RenderUpdatedAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID);
        this.Render(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
    }

    /// <summary>Updates the params internal.</summary>
    /// <param name="enmAttributeType">Type of the enm attribute.</param>
    internal new void UpdateParamsInternal(AttributeType enmAttributeType) => this.UpdateParams(enmAttributeType);

    /// <summary>Renders the theme.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected override void RenderThemeAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (!VWGContext.Current.SupportsMultipleThemes)
        return;
      if (this.TopLevel && this.Theme == "Inherit")
        objWriter.WriteAttributeString("TH", VWGContext.Current.CurrentTheme);
      else
        base.RenderThemeAttribute(objContext, objWriter, blnForceRender);
    }

    /// <summary>
    /// Activates a child control. Optionally specifies the direction in the tab order to select the control from.
    /// </summary>
    /// <param name="blnDirected"></param>
    /// <param name="blnForward"></param>
    protected override void Select(bool blnDirected, bool blnForward) => this.SelectInternal(blnDirected, blnForward);

    /// <summary>Selects the internal.</summary>
    /// <param name="blnDirected">if set to <c>true</c> [BLN directed].</param>
    /// <param name="blnForward">if set to <c>true</c> [BLN forward].</param>
    private void SelectInternal(bool blnDirected, bool blnForward)
    {
      if (blnDirected)
        this.SelectNextControl((Control) null, blnForward, true, true, false);
      if (this.TopLevel)
      {
        this.InvokeMethodWithId("Forms_BringWindowToTop");
        this.ActivateForm(true);
      }
      else
      {
        if (this.IsMdiChild)
          return;
        Form parentFormInternal = this.ParentFormInternal;
        if (parentFormInternal == null)
          return;
        parentFormInternal.ActiveControl = (Control) this;
      }
    }

    /// <summary>Focuses the internal.</summary>
    /// <returns></returns>
    internal override bool FocusInternal()
    {
      if (this.TopLevel)
      {
        this.InvokeMethodWithId("Forms_BringWindowToTop");
        this.ActivateForm(true);
      }
      return base.FocusInternal();
    }

    /// <summary>Renders Form window state.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderFormWindowState(IAttributeWriter objWriter)
    {
      FormWindowState windowState = this.WindowState;
      objWriter.WriteAttributeString("WS", ((int) windowState).ToString());
      if (windowState != FormWindowState.Minimized)
        return;
      objWriter.WriteAttributeString("RWS", ((int) this.FormRestoredWindowState).ToString());
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      if (this.Parent != null)
      {
        base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      }
      else
      {
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
          this.RenderFormRectangle(objWriter, this.StartPosition, this.Location, this.Size);
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.Enabled))
          objWriter.WriteAttributeString("En", this.Enabled ? "1" : "0");
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        {
          objWriter.WriteAttributeText("TX", this.Text);
          this.RenderFormButtons(objWriter, true);
        }
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.Redraw))
        {
          this.RenderFormWindowState(objWriter);
          objWriter.WriteAttributeString("FBS", ((int) this.FormBorderStyle).ToString());
        }
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.Extended))
        {
          this.RenderControlBoxAttribute(objWriter, true);
          this.RenderFormBoxes(objWriter, true);
        }
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.GeographicLocation))
          this.RenderGeoLocationAttributes(objContext, objWriter, true);
        if (this.IsDirtyAttributes(lngRequestID, AttributeType.VisualEffect))
        {
          this.RenderEntranceVisualEffect(objContext, objWriter, true);
          this.RenderExitVisualEffect(objContext, objWriter, true);
        }
        this.RenderComponentAttributes(this.Context, objWriter);
      }
    }

    /// <summary>Renders the form.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    void IForm.RenderForm(IContext objContext, IResponseWriter objWriter, long lngRequestID) => this.RenderControl(objContext, objWriter, lngRequestID);

    /// <summary>Pre-render form.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    void IForm.PreRenderForm(IContext objContext, long lngRequestID)
    {
      this.PreRenderControl(objContext, lngRequestID);
      this.PreRenderForms(objContext, lngRequestID);
      this.OnPreRendered(EventArgs.Empty);
    }

    /// <summary>Raises after PreRenderForm has completed.</summary>
    /// <param name="e"></param>
    protected virtual void OnPreRendered(EventArgs e)
    {
      if (this.mobjPreRender == null)
        return;
      this.mobjPreRender((object) this, e);
    }

    /// <summary>Posts the render form.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    void IForm.PostRenderForm(IContext objContext, long lngRequestID)
    {
      this.PostRenderControl(objContext, lngRequestID);
      this.PostRenderForms(objContext, lngRequestID);
    }

    /// <summary>Pre-render forms.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void PreRenderForms(IContext objContext, long lngRequestID)
    {
      foreach (IForm ownedForm in this.OwnedForms)
        ownedForm.PreRenderForm(objContext, lngRequestID);
    }

    /// <summary>Posts the render forms.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void PostRenderForms(IContext objContext, long lngRequestID)
    {
      foreach (IForm ownedForm in this.OwnedForms)
        ownedForm.PostRenderForm(objContext, lngRequestID);
    }

    /// <summary>Renders the form rectangle.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="enmFormStartPosition">The form start position.</param>
    /// <param name="objLocation">The location of the form.</param>
    /// <param name="objSize">Size of the form.</param>
    private void RenderFormRectangle(
      IAttributeWriter objWriter,
      FormStartPosition enmFormStartPosition,
      Point objLocation,
      Size objSize)
    {
      objWriter.WriteAttributeString("H", objSize.Height.ToString());
      objWriter.WriteAttributeString("W", objSize.Width.ToString());
      if (this.DialogType != DialogTypes.PopupWindow)
      {
        Size formRestoredSize = this.FormRestoredSize;
        if (formRestoredSize != Size.Empty)
        {
          objWriter.WriteAttributeString("RH", formRestoredSize.Height.ToString());
          objWriter.WriteAttributeString("RW", formRestoredSize.Width.ToString());
        }
      }
      if (enmFormStartPosition == FormStartPosition.Manual || this.Moved)
      {
        objWriter.WriteAttributeString("L", objLocation.X.ToString());
        objWriter.WriteAttributeString("T", objLocation.Y.ToString());
      }
      Point restoredLocation = this.FormRestoredLocation;
      if (!(restoredLocation != Point.Empty))
        return;
      objWriter.WriteAttributeString("RL", restoredLocation.X.ToString());
      objWriter.WriteAttributeString("RT", restoredLocation.Y.ToString());
    }

    /// <summary>Renders the forms attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      if (this.Parent == null)
      {
        this.RenderMinMaxSizeAttributes(objContext, objWriter);
        bool flag = false;
        if (this.IsRootForm && this.Context.Arguments is IMashupArguments arguments)
        {
          objWriter.WriteAttributeString("MP", ((int) arguments.Type).ToString());
          objWriter.WriteAttributeString("H", "400");
          objWriter.WriteAttributeString("W", "400");
          objWriter.WriteAttributeString("L", "100");
          objWriter.WriteAttributeString("T", "10");
          flag = true;
        }
        FormStartPosition startPosition = this.StartPosition;
        if (!flag)
          this.RenderFormRectangle(objWriter, startPosition, new Point(this.LayoutLeft, this.LayoutTop), this.Size);
        objWriter.WriteAttributeString("RD", "1");
        objWriter.WriteAttributeString("TP", this.DialogType.ToString());
        if ((startPosition == FormStartPosition.CenterParent || startPosition == FormStartPosition.CenterScreen) && !this.Moved)
          objWriter.WriteAttributeString("FSP", ((int) startPosition).ToString());
        this.RenderFormWindowState(objWriter);
        objWriter.WriteAttributeString("S", this.FormStyle == FormStyle.Dialog ? "0" : "1");
        string beforeUnloadMessage = this.BeforeUnloadMessage;
        if (beforeUnloadMessage != string.Empty)
          objWriter.WriteAttributeString("BUM", beforeUnloadMessage);
        if (this.IsWindowSized)
          objWriter.WriteAttributeString("IWS", "1");
        this.RenderFormButtons(objWriter, false);
        if (!this.ModalMask)
          objWriter.WriteAttributeString("SMM", "0");
        DialogAlignment dialogAlignment = this.DialogAlignment;
        string strComponentId;
        string strMemberId;
        this.GetRenderAlignmentComponentIds(out strComponentId, out strMemberId);
        if (strComponentId != "0" && !string.IsNullOrEmpty(strComponentId) && dialogAlignment != DialogAlignment.None)
        {
          if (strMemberId != "0" && !string.IsNullOrEmpty(strMemberId))
            objWriter.WriteAttributeString("AT", strComponentId + "_" + strMemberId);
          else
            objWriter.WriteAttributeString("AT", strComponentId);
          objWriter.WriteAttributeString("ATP", dialogAlignment.ToString()[0].ToString());
        }
        Form mdiParent = this.MdiParent;
        if (mdiParent != null)
        {
          IControl control = (IControl) mdiParent;
          if (control != null)
            objWriter.WriteAttributeString("MDP", control.ID.ToString());
        }
        if (this.IsMdiContainer)
          objWriter.WriteAttributeString("IMC", "1");
      }
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
      ResourceHandle proxyPropertyValue = this.GetProxyPropertyValue<ResourceHandle>("Icon", this.Icon);
      if (proxyPropertyValue != null)
        objWriter.WriteAttributeString("I", proxyPropertyValue.ToString());
      objWriter.WriteAttributeString("FBS", ((int) this.FormBorderStyle).ToString());
      this.RenderFormBoxes(objWriter, false);
      this.RenderGeoLocationAttributes(objContext, objWriter, false);
      this.RenderControlBoxAttribute(objWriter, false);
      this.RenderEntranceVisualEffect(objContext, objWriter, false);
      this.RenderExitVisualEffect(objContext, objWriter, false);
      base.RenderAttributes(objContext, objWriter);
    }

    /// <summary>Returns aligment component ids for rendering.</summary>
    private void GetRenderAlignmentComponentIds(out string strComponentId, out string strMemberId)
    {
      strComponentId = "";
      strMemberId = "";
      if (this.mobjAligmentComponent == null)
        return;
      Component component = this.mobjAligmentComponent as Component;
      IRegisteredComponentMember aligmentComponent = this.mobjAligmentComponent as IRegisteredComponentMember;
      if (component == null && aligmentComponent == null)
        return;
      if (aligmentComponent == null)
      {
        IIdentifiedComponent alignmentMemberComponent = this.mobjAlignmentMemberComponent;
        if (alignmentMemberComponent != null)
          strMemberId = alignmentMemberComponent.ID;
      }
      else
      {
        component = (VWGContext.Current as ISessionRegistry).GetRegisteredComponent(aligmentComponent.OwnerID) as Component;
        strMemberId = aligmentComponent.MemberID.ToString();
      }
      ProxyComponent objProxyComponent = (ProxyComponent) null;
      if (component.Form != null)
        objProxyComponent = component.Form.ProxyComponent;
      if (objProxyComponent == null)
      {
        strComponentId = component.ID.ToString();
      }
      else
      {
        ProxyComponent componentOfSource = this.GetVisibleProxyComponentOfSource(objProxyComponent, component.ID);
        if (componentOfSource == null)
          return;
        strComponentId = componentOfSource.ID.ToString();
      }
    }

    /// <summary>Returns visible proxy component by source component.</summary>
    private ProxyComponent GetVisibleProxyComponentOfSource(
      ProxyComponent objProxyComponent,
      long objSourceComponentId)
    {
      Component sourceComponent = objProxyComponent.SourceComponent;
      if (sourceComponent != null && sourceComponent.ID == objSourceComponentId && objProxyComponent.Visible)
        return objProxyComponent;
      foreach (ProxyComponent component in (List<ProxyComponent>) objProxyComponent.Components)
      {
        ProxyComponent componentOfSource = this.GetVisibleProxyComponentOfSource(component, objSourceComponentId);
        if (componentOfSource != null)
          return componentOfSource;
      }
      return (ProxyComponent) null;
    }

    /// <summary>Renders the enabled attribute.</summary>
    /// <param name="objWriter">The object writer.</param>
    protected override void RenderEnabledAttribute(IAttributeWriter objWriter)
    {
      if (this.Context.Config.FormsSecurityEnabled)
      {
        if ((this.Context as IContextParams).GetFormAccessMode((IForm) this) == FormAccessMode.ReadOnly)
          objWriter.WriteAttributeString("En", "0");
        else
          base.RenderEnabledAttribute(objWriter);
      }
      else
        base.RenderEnabledAttribute(objWriter);
    }

    /// <summary>Renders the entrance visual effect.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderEntranceVisualEffect(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      this.RenderFullScreenNavigationEffect(this.EntranceEffect, "BEE", "AEE", objContext, objWriter, blnForceRender);
    }

    /// <summary>Renders the exit visual effect.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderExitVisualEffect(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      this.RenderFullScreenNavigationEffect(this.ExitEffect, "BXE", "AXE", objContext, objWriter, blnForceRender);
    }

    /// <summary>Renders the full screen navigation effect.</summary>
    /// <param name="objEffectToRender">The effect to render.</param>
    /// <param name="strBeforeEffectAttributeName">Name of the before-effect attribute.</param>
    /// <param name="strAfterEffectAttributeName">Name of the after-effect attribute.</param>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [forced to render].</param>
    private void RenderFullScreenNavigationEffect(
      VisualEffect objEffectToRender,
      string strBeforeEffectAttributeName,
      string strAfterEffectAttributeName,
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (!(objEffectToRender != null | blnForceRender) || !this.Context.FullScreenMode || !this.TopLevel && !this.IsMdiChild || this.DialogType == DialogTypes.PopupWindow)
        return;
      string strText = objEffectToRender is TranslateVisualEffect ? objEffectToRender.GetBeforeToString(objContext, true) : objEffectToRender.ToString(objContext);
      if (!string.IsNullOrEmpty(strText))
        objWriter.WriteAttributeText(strBeforeEffectAttributeName, strText);
      string afterToString = objEffectToRender.GetAfterToString(objContext, true);
      if (string.IsNullOrEmpty(afterToString))
        return;
      objWriter.WriteAttributeText(strAfterEffectAttributeName, afterToString);
    }

    /// <summary>Renders the control box attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderControlBoxAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool controlBox = this.ControlBox;
      if (!(!controlBox | blnForceRender))
        return;
      objWriter.WriteAttributeString("CBX", controlBox ? "1" : "0");
    }

    /// <summary>Renders the form buttons.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderFormButtons(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool flag1 = this.AcceptButton != null;
      if (flag1 | blnForceRender)
      {
        objWriter.WriteAttributeString("FAB", flag1 ? "1" : "0");
        objWriter.WriteAttributeString("ACI", this.AcceptButton is Control ? (this.AcceptButton as Control).ID.ToString() : "0");
      }
      bool flag2 = this.CancelButton != null;
      if (!(flag2 | blnForceRender))
        return;
      objWriter.WriteAttributeString("FCB", flag2 ? "1" : "0");
    }

    /// <summary>Renders the form boxes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderFormBoxes(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!this.ControlBox)
        return;
      bool maximizeBox = this.MaximizeBox;
      if (maximizeBox | blnForceRender)
        objWriter.WriteAttributeString("MXE", maximizeBox ? "1" : "0");
      bool minimizeBox = this.MinimizeBox;
      if (minimizeBox | blnForceRender)
        objWriter.WriteAttributeString("MNE", minimizeBox ? "1" : "0");
      bool closeBox = this.CloseBox;
      if (!(!closeBox | blnForceRender))
        return;
      objWriter.WriteAttributeString("CE", closeBox ? "1" : "0");
    }

    /// <summary>
    /// Gets a value indicating whether this instance is root form.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is root form; otherwise, <c>false</c>.
    /// </value>
    private bool IsRootForm => this.Context.MainForm == this;

    /// <summary>Render the form content</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.Context.Config.FormsSecurityEnabled)
      {
        if ((this.Context as IContextParams).GetFormAccessMode((IForm) this) == FormAccessMode.Denied)
          this.RenderUnauthorizedAccessHtmlBox(objContext, objWriter, lngRequestID);
        else
          this.RenderContent(objContext, objWriter, lngRequestID);
      }
      else
        this.RenderContent(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the unauthorized access HTML box.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    /// <param name="lngRequestID">The LNG request unique identifier.</param>
    private void RenderUnauthorizedAccessHtmlBox(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.UnauthorizedAccessHtmlBox.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request unique identifier.</param>
    private void RenderContent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      if (this.Parent != null)
      {
        base.Render(objContext, objWriter, lngRequestID);
      }
      else
      {
        if (this.IsDirty(lngRequestID))
        {
          this.RenderControls(objContext, objWriter, 0L);
          this.RenderClientStoratge(objContext, objWriter, lngRequestID);
        }
        else
          this.RenderControls(objContext, objWriter, lngRequestID);
        this.RenderForms(objContext, objWriter, lngRequestID);
      }
    }

    /// <summary>Renders the client storatge.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void RenderClientStoratge(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.ClientStorage?.Render(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the geo-location data.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForcRender">if set to <c>true</c> [BLN forc render].</param>
    private void RenderGeoLocationAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForcRender)
    {
      bool flag1 = false;
      bool flag2 = false;
      double? nullable1 = new double?();
      double? nullable2 = new double?();
      GeoLocationData geographicLocation = this.GeographicLocation;
      if (geographicLocation != null)
      {
        flag1 = geographicLocation.RepeatCheck;
        flag2 = geographicLocation.EnableHighAccuracy;
        nullable1 = geographicLocation.MaximumAge;
        nullable2 = geographicLocation.Timeout;
      }
      if (blnForcRender | flag1)
        objWriter.WriteAttributeString("RCK", flag1 ? "1" : "0");
      if (blnForcRender | flag2)
        objWriter.WriteAttributeString("EHA", flag2 ? "1" : "0");
      if (blnForcRender || nullable1.HasValue)
        objWriter.WriteAttributeString("MAG", nullable1.ToString());
      if (!blnForcRender && !nullable2.HasValue)
        return;
      objWriter.WriteAttributeString("TOT", nullable2.ToString());
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      ProxyComponent proxyComponent = this.ProxyComponent;
      if (proxyComponent == null)
      {
        this.GetValue<ShortcutsContainer>(Form.ShortcutsProperty)?.RenderControl(objContext, objWriter, lngRequestID);
        if (this.Parent == null)
        {
          Control header = this.Header;
          if (header != null)
            this.RenderHeader(header, objContext, objWriter, lngRequestID);
        }
        ((IRenderableComponent) this.Menu)?.RenderComponent(objContext, objWriter, lngRequestID);
      }
      MdiClient mdiClient = (MdiClient) null;
      bool flag = false;
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control is MdiClient)
          mdiClient = control as MdiClient;
        else
          flag = control.Dock == DockStyle.Fill;
        if (mdiClient != null & flag)
          break;
      }
      if (proxyComponent == null && mdiClient != null & flag)
        mdiClient.RenderControl(objContext, objWriter, lngRequestID);
      base.RenderControls(objContext, objWriter, lngRequestID);
      if (proxyComponent != null || mdiClient == null || flag)
        return;
      mdiClient.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the form header control</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    private void RenderHeader(
      Control objHeader,
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      DockStyle dock = objHeader.Dock;
      AnchorStyles anchor = objHeader.Anchor;
      objHeader.Dock = DockStyle.Top;
      ((IRenderableComponent) objHeader).RenderComponent(objContext, objWriter, lngRequestID);
      objHeader.Dock = dock;
      objHeader.Anchor = anchor;
    }

    /// <summary>Renders the child forms.</summary>
    /// <param name="objContext">context.</param>
    /// <param name="objWriter">writer.</param>
    /// <param name="lngRequestID">last updated marker.</param>
    internal void RenderForms(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      foreach (Form ownedForm in this.OwnedForms)
      {
        if (ownedForm.TopLevel || ownedForm.MdiParent != null)
          ownedForm.RenderControl(objContext, objWriter, lngRequestID);
      }
    }

    /// <summary>
    ///  Gets or sets the MainMenu that is displayed in the form.
    /// </summary>
    public MainMenu Menu
    {
      get => this.GetValue<MainMenu>(Form.MenuProperty);
      set
      {
        MainMenu menu = this.Menu;
        if (!this.SetValue<MainMenu>(Form.MenuProperty, value))
          return;
        if (menu != null)
          this.UnRegisterComponent((IRegisteredComponent) menu);
        if (value != null)
        {
          value.Dock = DockStyle.Top;
          value.InternalParent = (Component) this;
          this.RegisterComponent((IRegisteredComponent) value);
        }
        this.Update();
      }
    }

    /// <summary>Gets or sets the primary menu container for the form.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGui.Forms.MenuStrip"></see> that represents the container for the menu structure of the form. The default is null.</returns>
    [SRCategory("CatWindowStyle")]
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    [SRDescription("FormMenuStripDescr")]
    public MenuStrip MainMenuStrip
    {
      get => this.GetValue<MenuStrip>(Form.MainMenuStripProperty);
      set
      {
        MenuStrip mainMenuStrip = this.MainMenuStrip;
        if (!this.SetValue<MenuStrip>(Form.MainMenuStripProperty, value))
          return;
        if (mainMenuStrip != null)
          this.UnRegisterComponent((IRegisteredComponent) mainMenuStrip);
        if (value != null)
        {
          value.InternalParent = (Component) this;
          this.RegisterComponent((IRegisteredComponent) value);
        }
        this.Update();
      }
    }

    /// <summary>Gets or sets the client storage.</summary>
    /// <value>The client storage.</value>
    [SRCategory("Client")]
    [TypeConverter(typeof (ReferenceConverter))]
    [DefaultValue(null)]
    [SRDescription("ClientStorageDescr")]
    public ClientStorage ClientStorage
    {
      get => this.GetValue<ClientStorage>(Form.ClientStorageProperty);
      set
      {
        ClientStorage clientStorage = this.ClientStorage;
        if (!this.SetValue<ClientStorage>(Form.ClientStorageProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// A data which defines the geographic location services.
    /// </summary>
    /// <value>The geo location.</value>
    [Category("Misc")]
    [Description("A data which defines the geographic location services.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public GeoLocationData GeographicLocation
    {
      get => this.GetValue<GeoLocationData>(Form.GeoLocationDataProperty);
      set
      {
        if (!this.SetValue<GeoLocationData>(Form.GeoLocationDataProperty, value))
          return;
        this.UpdateParams(AttributeType.GeographicLocation);
      }
    }

    /// <summary>
    /// Creates a new instance of the control collection for the control.
    /// </summary>
    /// <returns>
    /// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection" /> assigned to the control.
    /// </returns>
    protected override Control.ControlCollection CreateControlsInstance() => (Control.ControlCollection) new Form.ControlCollection(this);

    /// <summary>Invokes the method.</summary>
    /// <param name="objTarget">The obj target.</param>
    /// <param name="strMember">The STR member.</param>
    /// <param name="arrArgs">The arr args.</param>
    internal void InvokeMethod(Component objTarget, string strMember, object[] arrArgs)
    {
      if (!(this.Context is IContextMethodInvoker context))
        return;
      context.InvokeMethod(objTarget as ISkinable, InvokationUniqueness.None, strMember, arrArgs);
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
    {
      Type type = Type.GetType(strOffspringTypeName);
      if (!(type != (Type) null) || !CommonUtils.IsTypeOrSubType(type, typeof (MainMenu)))
        return base.GetComponentOffsprings(strOffspringTypeName);
      return (IList) new List<MainMenu>() { this.Menu };
    }

    /// <summary>Closes this window.</summary>
    public void Close() => this.Close(false, false, false);

    /// <summary>Closes this window.</summary>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <param name="blnSuspendCloseEvent">if set to <c>true</c> - came from visible
    /// the closed event shouldn't be raised.</param>
    /// <param name="blnFormOwnerClosing">if set to <c>true</c> [BLN form owner closing].</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool Close(
      bool blnClientSource,
      bool blnSuspendCloseEvent,
      bool blnFormOwnerClosing)
    {
      if (!this.GetState(Form.FormState.IsClosed))
      {
        bool flag = true;
        CloseReason objCloseReason = !blnFormOwnerClosing ? (!this.IsMdiChild ? CloseReason.UserClosing : CloseReason.MdiFormClosing) : CloseReason.FormOwnerClosing;
        if (!blnSuspendCloseEvent && (this.ClosingHandler != null || this.FormClosingHandler != null))
        {
          FormClosingEventArgs e1 = new FormClosingEventArgs(objCloseReason, false);
          CancelEventArgs e2 = new CancelEventArgs(false);
          this.OnClosing(e2);
          this.OnFormClosing(e1);
          if (e1.Cancel || e2.Cancel)
          {
            if (this.DialogType == DialogTypes.PopupWindow)
              throw new Exception("Closing popup windows cannot be cancelled");
            return false;
          }
        }
        Form[] ownedForms = this.OwnedForms;
        if (ownedForms.Length != 0)
        {
          foreach (Form form in ownedForms)
            flag &= form.Close(blnClientSource, blnSuspendCloseEvent, true);
        }
        if (!flag & blnClientSource)
        {
          this.Update();
          return false;
        }
        if (objCloseReason == CloseReason.UserClosing && this.Modal && this.DialogResult == DialogResult.None)
          this.DialogResult = DialogResult.Cancel;
        this.ResetCreatedFlag();
        this.Parent?.Controls.Remove((Control) this);
        ((IFormResolver) this.Context).UnRegisterForm((IForm) this);
        Form owner = this.Owner;
        if (owner != null)
        {
          if (this.Context.ActiveForm == this)
          {
            if (this.DialogType == DialogTypes.PopupWindow)
            {
              this.Context.ActiveForm = (IForm) owner;
            }
            else
            {
              Form topMostOwnedForm = owner.GetTopMostOwnedForm(this);
              if (topMostOwnedForm != null)
                this.Context.ActiveForm = (IForm) topMostOwnedForm;
            }
            this.Active = false;
            if (this.Context.ActiveForm != this)
              this.Context.ActiveForm.Active = true;
          }
          owner.RemoveForm(this, blnSuspendCloseEvent);
        }
        else
        {
          this.FireClosed();
          this.FireFormClosed(new FormClosedEventArgs(CloseReason.UserClosing));
        }
        if (this.GetState(Form.FormState.IsModalActive))
        {
          this.Context.GetThreadingService()?.ReleaseDialog((IForm) this);
          this.SetState(Form.FormState.IsModalActive, false);
        }
        this.SetState(Form.FormState.IsClosed, true);
      }
      if (this.Context is IContextParams context)
        context.EmulatorForm?.OnFormClosed((IForm) this);
      return true;
    }

    /// <summary>Gets the top most owned form.</summary>
    /// <param name="objExcludedOwnedForm">The excluded form.</param>
    /// <returns></returns>
    private Form GetTopMostOwnedForm(Form objExcludedOwnedForm)
    {
      Form topMostOwnedForm1 = this != objExcludedOwnedForm ? this : (Form) null;
      Form[] ownedForms = this.OwnedForms;
      if (ownedForms != null && ownedForms.Length != 0)
      {
        for (int index = ownedForms.Length - 1; index >= 0; --index)
        {
          Form form = ownedForms[index];
          if (form != null && form != objExcludedOwnedForm && form.TopLevel)
          {
            Form topMostOwnedForm2 = form.GetTopMostOwnedForm(objExcludedOwnedForm);
            if (topMostOwnedForm2 != null)
            {
              topMostOwnedForm1 = topMostOwnedForm2;
              break;
            }
          }
        }
      }
      return topMostOwnedForm1;
    }

    /// <summary>Shows the dialog.</summary>
    /// <param name="objForm">The obj form.</param>
    /// <returns></returns>
    public DialogResult ShowDialog(Form objForm) => this.ShowDialog(objForm, (EventHandler) null);

    /// <summary>Shows the dialog.</summary>
    /// <param name="objForm">The obj form.</param>
    /// <param name="objClosedDelegate">The obj closed delegate.</param>
    /// <returns></returns>
    public DialogResult ShowDialog(Form objForm, EventHandler objClosedDelegate) => this.ShowDialog(objForm, DialogTypes.ModalWindow, objClosedDelegate);

    /// <summary>Shows the specified obj closed delegate.</summary>
    /// <param name="objClosedDelegate">The obj closed delegate.</param>
    public void Show(EventHandler objClosedDelegate)
    {
      if (this.Context.Config.IsFeatureEnabled("ModalWindows", false))
      {
        int num1 = (int) this.ShowDialog(DialogTypes.ModalWindow, objClosedDelegate);
      }
      else
      {
        int num2 = (int) this.ShowDialog(DialogTypes.ModalessWindow, objClosedDelegate);
      }
    }

    /// <summary>Shows the specified obj owner.</summary>
    /// <param name="objOwner">The obj owner.</param>
    /// <param name="objClosedDelegate">The obj closed delegate.</param>
    public void Show(IWin32Window objOwner, EventHandler objClosedDelegate)
    {
      switch (objOwner)
      {
        case Form objForm:
          int num1 = (int) this.ShowDialog(objForm, objClosedDelegate);
          break;
        case Control control:
          Form form = control.Form;
          if (form != null)
          {
            int num2 = (int) this.ShowDialog(form, objClosedDelegate);
            break;
          }
          this.Show(objClosedDelegate);
          break;
      }
    }

    /// <summary>Displays the control to the user.</summary>
    public override void Show() => this.Show((EventHandler) null);

    /// <summary>Shows the specified owner.</summary>
    /// <param name="objOwner">The owner.</param>
    public void Show(IWin32Window objOwner) => this.Show(objOwner, (EventHandler) null);

    /// <summary>Shows the dialog.</summary>
    /// <param name="objOwnerForm">The obj owner form.</param>
    /// <param name="enmDialogType">Type of the enm dialog.</param>
    /// <param name="objClosedDelegate">The obj closed delegate.</param>
    /// <returns></returns>
    private DialogResult ShowDialog(
      Form objOwnerForm,
      DialogTypes enmDialogType,
      EventHandler objClosedDelegate)
    {
      if (objClosedDelegate != null)
        this.ClosedDelegate = objClosedDelegate;
      if (enmDialogType == DialogTypes.PopupWindow && objOwnerForm != null)
      {
        ArrayList arrayList = new ArrayList((ICollection) objOwnerForm.OwnedFormsCollection);
        for (int index = arrayList.Count - 1; index >= 0; --index)
        {
          if (arrayList[index] is Form form && form.DialogType == DialogTypes.PopupWindow)
            form.Close();
        }
      }
      this.DialogResult = DialogResult.None;
      bool state = this.GetState(Form.FormState.IsClosed);
      if (objOwnerForm != this)
      {
        if (CommonSwitches.TraceVerbose)
          VerboseRecord.Write((object) this, "Server/Actions", nameof (ShowDialog), "Shows the currnet dialog in a " + enmDialogType.ToString() + " style.");
        this.DialogType = enmDialogType;
        if ((this.TopLevel || this.IsMdiChild) && !objOwnerForm.OwnedFormsCollection.Contains(this))
          objOwnerForm.OwnedFormsCollection.Add(this);
        if (enmDialogType != DialogTypes.ModalWindow)
        {
          Form mdiParent = objOwnerForm.MdiParent;
          if (mdiParent != null)
            this.MdiParent = mdiParent;
        }
        this.Update();
        this.RegisterSelf();
        this.CalledOnLoad = false;
        this.CalledMakeVisible = false;
        this.InternalVisible = true;
        if (state || !this.GetState(Form.FormState.IsClosed))
        {
          this.CreateControl();
          if (this.Parent == null)
            this.ActivateOnShow = true;
        }
      }
      ((IFormResolver) this.Context).RegisterForm((IForm) this);
      if (state || !this.GetState(Form.FormState.IsClosed))
      {
        if (enmDialogType == DialogTypes.ModalWindow)
        {
          this.SetState(Form.FormState.IsModalActive, true);
          IContextThreadingService threadingService = this.Context.GetThreadingService();
          if (threadingService != null)
          {
            RequestProcessingState requestProcessingState = this.Context.RequestProcessingState;
            switch (requestProcessingState)
            {
              case RequestProcessingState.PreRenderResponse:
              case RequestProcessingState.RenderResponse:
              case RequestProcessingState.PostRrenderResponse:
                ((IFormResolver) this.Context).UnRegisterForm((IForm) this);
                throw new Exception(string.Format("Cannot perform modal dialog emulation through {0} state.", (object) requestProcessingState.ToString()));
              default:
                int dialogResult = (int) threadingService.GetDialogResult((IForm) this);
                break;
            }
          }
        }
        this.SetState(Form.FormState.IsClosed, false);
      }
      if (this.Context is IContextParams context)
        context.EmulatorForm?.OnFormShowed((IForm) this);
      return this.DialogResult;
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      if (this.ActivateOnShow)
      {
        this.ActivateOnShow = false;
        this.ActivateForm(false);
      }
      base.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Activates the form.</summary>
    /// <param name="blnUpdatePosition">if set to <c>true</c> [BLN update position].</param>
    internal void ActivateForm(bool blnUpdatePosition)
    {
      if (blnUpdatePosition && this.Owner != null && this.Owner.OwnedFormsCollection.IndexOf(this) < this.Owner.OwnedFormsCollection.Count - 1)
        this.Owner.OwnedFormsCollection.SetFormPosition(this, this.Owner.OwnedFormsCollection.Count - 1);
      IForm activeForm = this.Context.ActiveForm;
      if (activeForm != this)
      {
        if (activeForm != null)
          activeForm.Active = false;
        this.Context.ActiveForm = (IForm) this;
      }
      if (this.Active)
        return;
      this.Active = true;
    }

    /// <summary>Occurs when control is created</summary>
    protected override void OnCreateControl()
    {
      this.CalledCreateControl = true;
      base.OnCreateControl();
      this.RegisterSelf();
      if (CommonSwitches.TraceVerbose)
        VerboseRecord.Write((object) this, "Server/Events", "Load", "Invoking event handler.");
      long ticks = DateTime.Now.Ticks;
      if (this.CalledMakeVisible && !this.CalledOnLoad)
      {
        this.CalledOnLoad = true;
        this.OnLoad(EventArgs.Empty);
      }
      if (!CommonSwitches.TraceEnabled || !CommonSwitches.TraceInfo)
        return;
      TraceRecord.Write((TraceRecord) new EventTraceRecord("Load", (IRegisteredComponent) this, ticks));
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    internal override bool CanSelectCore() => this.GetStyle(ControlStyles.Selectable) && this.Enabled && this.Visible;

    /// <summary>Shows the dialog.</summary>
    /// <param name="objClosedDelegate">The obj closed delegate.</param>
    /// <returns></returns>
    public virtual DialogResult ShowDialog(EventHandler objClosedDelegate) => this.ShowDialog(DialogTypes.ModalWindow, objClosedDelegate);

    /// <summary>Shows the dialog.</summary>
    /// <returns></returns>
    public virtual DialogResult ShowDialog() => this.ShowDialog(DialogTypes.ModalWindow, (EventHandler) null);

    /// <summary>Shows the dialog.</summary>
    /// <param name="enmDialogTypes">The enm dialog types.</param>
    /// <param name="objClosedDelegate">The obj closed delegate.</param>
    /// <returns></returns>
    private DialogResult ShowDialog(DialogTypes enmDialogTypes, EventHandler objClosedDelegate)
    {
      DialogResult dialogResult = DialogResult.None;
      if (enmDialogTypes == DialogTypes.ModalWindow && !this.TopLevel)
        throw new InvalidOperationException(SR.GetString("ShowDialogOnNonTopLevel", (object) "Show"));
      Form objOwnerForm = (Form) null;
      Form mdiParent = this.MdiParent;
      if (mdiParent != null)
      {
        if (enmDialogTypes == DialogTypes.ModalessWindow)
          objOwnerForm = mdiParent;
      }
      else if (enmDialogTypes != DialogTypes.ModalessWindow)
        objOwnerForm = this.GetOwnerForm(enmDialogTypes);
      if (objOwnerForm != null)
      {
        dialogResult = this.ShowDialog(objOwnerForm, enmDialogTypes, objClosedDelegate);
      }
      else
      {
        if (this.Created && this.Owner != null && this.Context != null && this.Context is IContextMethodInvoker)
        {
          ((IContextMethodInvoker) this.Context).InvokeMethod((ISkinable) this, InvokationUniqueness.Component, "Forms_BringWindowToTop", (object) this.ID);
          this.Owner.OwnedFormsCollection.SetFormPosition(this, this.Owner.OwnedFormsCollection.Count - 1);
        }
        if (this.Context.MainForm is Form mainForm)
        {
          dialogResult = this.ShowDialog(mainForm, enmDialogTypes, objClosedDelegate);
        }
        else
        {
          this.Context.MainForm = (IForm) this;
          this.Context.ActiveForm = (IForm) this;
          this.CreateControl();
          EventHandler activatedHandler = this.ActivatedHandler;
          if (activatedHandler != null)
            activatedHandler((object) this, new EventArgs());
        }
      }
      return dialogResult;
    }

    /// <summary>Shows a the form as a dialog.</summary>
    private DialogResult ShowDialog(DialogTypes enmDialogTypes) => this.ShowDialog(enmDialogTypes, (EventHandler) null);

    /// <summary>Gets an owner form for a newly created form.</summary>
    /// <param name="enmNewDialogTypes">The enm new dialog types.</param>
    /// <returns></returns>
    private Form GetOwnerForm(DialogTypes enmNewDialogTypes)
    {
      if (this.Context.ActiveForm is Form ownerForm)
      {
        if (enmNewDialogTypes != DialogTypes.PopupWindow && ownerForm.DialogType == DialogTypes.PopupWindow)
        {
          Form form = ownerForm;
          while (form != null && form.Owner != null && form.Owner.DialogType == DialogTypes.PopupWindow)
            form = form.Owner;
          if (form != null)
          {
            if (form.Owner != null)
              this.Context.ActiveForm = (IForm) (ownerForm = form.Owner);
            form.Close();
          }
        }
        else
        {
          Form mostOwnedModalForm = ownerForm.TopMostOwnedModalForm;
          if (mostOwnedModalForm != null)
            ownerForm = mostOwnedModalForm;
        }
      }
      return ownerForm;
    }

    /// <summary>Displays the form as a popup window.</summary>
    public DialogResult ShowPopup()
    {
      this.DialogAlignment = DialogAlignment.None;
      this.mobjAligmentComponent = (object) null;
      this.mobjAlignmentMemberComponent = (IIdentifiedComponent) null;
      return this.ShowDialog(DialogTypes.PopupWindow);
    }

    /// <summary>Displays the form as a popup window.</summary>
    public DialogResult ShowPopup(Form objForm)
    {
      this.DialogAlignment = DialogAlignment.None;
      this.mobjAligmentComponent = (object) null;
      this.mobjAlignmentMemberComponent = (IIdentifiedComponent) null;
      return this.ShowDialog(objForm, DialogTypes.PopupWindow, (EventHandler) null);
    }

    /// <summary>Displays the form as a popup window.</summary>
    public DialogResult ShowPopup(Component objComponent) => this.ShowPopup(objComponent, DialogAlignment.Below);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objComponent"></param>
    /// <param name="enmAlignment"></param>
    /// <returns></returns>
    public DialogResult ShowPopup(Component objComponent, DialogAlignment enmAlignment) => this.ShowPopup(objComponent, (IIdentifiedComponent) null, enmAlignment);

    /// <summary>Used by combobox</summary>
    /// <param name="objForm"></param>
    /// <param name="objComponent">IRegisteredComponent</param>
    /// <param name="enmAlignment">DialogAlignment</param>
    /// <returns></returns>
    public DialogResult ShowPopup(
      Form objForm,
      IRegisteredComponent objComponent,
      DialogAlignment enmAlignment)
    {
      this.DialogAlignment = enmAlignment;
      this.mobjAligmentComponent = (object) objComponent;
      this.mobjAlignmentMemberComponent = (IIdentifiedComponent) null;
      return this.ShowDialog(Form.GetValidOwnerForm(objForm), DialogTypes.PopupWindow, (EventHandler) null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objForm"></param>
    /// <param name="objComponent">IRegisteredComponentMember</param>
    /// <param name="enmAlignment">DialogAlignment</param>
    /// <returns></returns>
    public DialogResult ShowPopup(
      Form objForm,
      IRegisteredComponentMember objComponent,
      DialogAlignment enmAlignment)
    {
      this.DialogAlignment = enmAlignment;
      this.mobjAligmentComponent = (object) objComponent;
      this.mobjAlignmentMemberComponent = (IIdentifiedComponent) null;
      return this.ShowDialog(objForm, DialogTypes.PopupWindow, (EventHandler) null);
    }

    /// <summary>Displays the form as a popup window.</summary>
    public DialogResult ShowPopup(
      Component objSourceComponent,
      IIdentifiedComponent objMemberComponent,
      DialogAlignment enmAlignment)
    {
      this.DialogAlignment = enmAlignment;
      this.mobjAligmentComponent = (object) objSourceComponent;
      this.mobjAlignmentMemberComponent = objMemberComponent;
      return this.ShowDialog(Form.GetValidOwnerForm(objSourceComponent.Form), DialogTypes.PopupWindow, (EventHandler) null);
    }

    /// <summary>Gets the valid owner form.</summary>
    /// <param name="objOwnerForm">The owner form.</param>
    /// <returns></returns>
    internal static Form GetValidOwnerForm(Form objOwnerForm)
    {
      Component internalParent;
      for (; objOwnerForm != null && !objOwnerForm.TopLevel && !objOwnerForm.IsMdiChild; objOwnerForm = internalParent == null ? (Form) null : internalParent.Form)
        internalParent = objOwnerForm.InternalParent;
      return objOwnerForm;
    }

    /// <summary>Removes an owned form from this form.</summary>
    /// <param name="objOwnedForm">A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> representing the form to remove from the list of owned forms for this form. </param>
    /// <filterpriority>1</filterpriority>
    public void RemoveOwnedForm(Form objOwnedForm)
    {
      if (objOwnedForm == null)
        return;
      if (objOwnedForm.OwnerInternal != null)
      {
        objOwnedForm.Owner = (Form) null;
      }
      else
      {
        Form[] ownedForms = this.OwnedForms;
        int count = this.OwnedFormsCollection.Count;
        if (ownedForms == null)
          return;
        for (int destinationIndex = 0; destinationIndex < count; ++destinationIndex)
        {
          if (objOwnedForm.Equals((object) ownedForms[destinationIndex]))
          {
            ownedForms[destinationIndex] = (Form) null;
            if (destinationIndex + 1 < count)
            {
              Array.Copy((Array) ownedForms, destinationIndex + 1, (Array) ownedForms, destinationIndex, count - destinationIndex - 1);
              ownedForms[count - 1] = (Form) null;
            }
            --count;
          }
        }
      }
    }

    /// <summary>Adds an owned form to this form.</summary>
    /// <param name="objOwnedForm">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that this form will own. </param>
    /// <filterpriority>1</filterpriority>
    public void AddOwnedForm(Form objOwnedForm)
    {
      if (objOwnedForm == null)
        return;
      if (objOwnedForm.OwnerInternal != this)
      {
        objOwnedForm.Owner = this;
      }
      else
      {
        FormCollection ownedFormsCollection = this.OwnedFormsCollection;
        if (ownedFormsCollection == null || ownedFormsCollection.Contains(objOwnedForm))
          return;
        ownedFormsCollection.Add(objOwnedForm);
      }
    }

    /// <summary>Sets the visible core.</summary>
    /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
    protected override void SetVisibleCore(bool blnValue)
    {
      bool visibleCore = this.GetVisibleCore();
      DialogResult dialogResult = this.DialogResult;
      if (visibleCore == blnValue && dialogResult == DialogResult.OK)
        return;
      if (visibleCore == blnValue && (!blnValue || this.CalledMakeVisible))
      {
        base.SetVisibleCore(blnValue);
      }
      else
      {
        if (blnValue)
        {
          this.CalledMakeVisible = true;
          if (this.CalledCreateControl && !this.CalledOnLoad)
          {
            this.CalledOnLoad = true;
            this.OnLoad(EventArgs.Empty);
            if (dialogResult != DialogResult.None)
              blnValue = false;
          }
        }
        base.SetVisibleCore(blnValue);
        if (!blnValue || this.IsMdiChild || this.WindowState != FormWindowState.Maximized && !this.TopMost || this.ActiveControl != null)
          return;
        this.SelectNextControlInternal((Control) null, true, true, true, false);
        this.FocusActiveControlInternal();
      }
    }

    /// <summary>Removes a form.</summary>
    /// <param name="objForm">Form.</param>
    /// <param name="blnSuspendCloseEvent">if set to <c>true</c> [BLN suspend close event].</param>
    internal void RemoveForm(Form objForm, bool blnSuspendCloseEvent)
    {
      objForm.UnRegisterSelf();
      objForm.InternalVisible = false;
      this.OwnedFormsCollection.Remove(objForm);
      if (!blnSuspendCloseEvent)
      {
        objForm.FireClosed();
        FormClosedEventArgs objFormClosedEventArgs = !objForm.IsMdiChild ? new FormClosedEventArgs(CloseReason.FormOwnerClosing) : new FormClosedEventArgs(CloseReason.MdiFormClosing);
        objForm.FireFormClosed(objFormClosedEventArgs);
      }
      objForm.FireClosedDelegate();
      if (objForm.OwnerInternal != this)
        return;
      objForm.OwnerInternal = (Form) null;
    }

    /// <summary>Fires the closed delegate.</summary>
    private void FireClosedDelegate()
    {
      EventHandler closedDelegate = this.ClosedDelegate;
      if (closedDelegate == null)
        return;
      this.ClosedDelegate = (EventHandler) null;
      closedDelegate((object) this, EventArgs.Empty);
    }

    /// <summary>Fires the closed event.</summary>
    internal void FireClosed() => this.OnClosed(EventArgs.Empty);

    /// <summary>Fires the form closed.</summary>
    /// <param name="objFormClosedEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.FormClosedEventArgs" /> instance containing the event data.</param>
    internal void FireFormClosed(FormClosedEventArgs objFormClosedEventArgs) => this.OnFormClosed(objFormClosedEventArgs);

    /// <summary>
    /// Causes all of the child controls within a control that support validation to validate their data.
    /// </summary>
    /// <param name="validationConstraints">Tells <see cref="M:Gizmox.WebGui.Forms.ContainerControl.ValidateChildren(Gizmox.WebGui.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
    /// <returns>
    /// true if all of the children validated successfully; otherwise, false.
    /// </returns>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    public override bool ValidateChildren(ValidationConstraints validationConstraints) => base.ValidateChildren(validationConstraints);

    /// <summary>
    /// Orientations the change fired.
    /// Checking of current handlers and owned forms handlers.
    /// </summary>
    /// <param name="objEvent">The obj event.</param>
    protected internal virtual void OnOrientationChanged(IEvent objEvent)
    {
      Form.OrientationChangedEventHandler orientationChangedHandler = this.OrientationChangedHandler;
      if (orientationChangedHandler != null)
      {
        int result;
        if (int.TryParse(objEvent["ORI"], out result))
          orientationChangedHandler((object) this, new OrientationChangedEventArgs(new int?(result)));
        else
          orientationChangedHandler((object) this, new OrientationChangedEventArgs(new int?()));
      }
      foreach (Form ownedForm in this.OwnedForms)
        ownedForm.OnOrientationChanged(objEvent);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLoad(EventArgs e)
    {
      EventHandler loadHandler = this.LoadHandler;
      if (loadHandler == null)
        return;
      loadHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Closed" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnClosed(EventArgs e)
    {
      EventHandler closedHandler = this.ClosedHandler;
      if (closedHandler == null)
        return;
      closedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:FormClosed" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.FormClosedEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnFormClosed(FormClosedEventArgs e)
    {
      this.TerminateRegisteredTimers();
      Form.FormClosedEventHandler formClosedHandler = this.FormClosedHandler;
      if (formClosedHandler == null)
        return;
      formClosedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.FormClosing"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.FormClosingEventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnFormClosing(FormClosingEventArgs e)
    {
      Form.FormClosingEventHandler formClosingHandler = this.FormClosingHandler;
      if (formClosingHandler == null)
        return;
      formClosingHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Closing" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnClosing(CancelEventArgs e)
    {
      CancelEventHandler closingHandler = this.ClosingHandler;
      if (closingHandler == null)
        return;
      closingHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGui.Forms.Form.Activated"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnActivated(EventArgs e)
    {
      EventHandler activatedHandler = this.ActivatedHandler;
      if (activatedHandler == null)
        return;
      activatedHandler((object) this, e);
    }

    /// <summary>Afters the control removed.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="objOldParent">The old parent.</param>
    internal override void AfterControlRemoved(Control objControl, Control objOldParent)
    {
      base.AfterControlRemoved(objControl, objOldParent);
      if (objControl == this.AcceptButton)
        this.AcceptButton = (IButtonControl) null;
      if (objControl == this.CancelButton)
        this.CancelButton = (IButtonControl) null;
      if (objControl != this.MdiClient)
        return;
      this.MdiClient = (MdiClient) null;
    }

    /// <devdoc>
    /// <para>Raises the Deactivate event.</para>
    /// </devdoc>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnDeactivate(EventArgs e)
    {
      EventHandler deactivateHandler = this.DeactivateHandler;
      if (deactivateHandler == null)
        return;
      deactivateHandler((object) this, e);
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      Control header = this.Header;
      MainMenu menu = this.Menu;
      if (menu != null)
        this.RegisterComponent((IRegisteredComponent) menu);
      if (header == null)
        return;
      this.RegisterComponent((IRegisteredComponent) header);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      Control header = this.Header;
      MainMenu menu = this.Menu;
      if (menu != null)
        this.UnRegisterComponent((IRegisteredComponent) menu);
      if (header == null)
        return;
      this.UnRegisterComponent((IRegisteredComponent) header);
    }

    /// <summary>Performs the layout.</summary>
    /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
    protected internal override void PerformLayout(bool blnForceLayout)
    {
      if (blnForceLayout)
      {
        foreach (Form ownedForm in this.OwnedForms)
        {
          if (ownedForm.Parent == null)
            ownedForm.PerformLayout(blnForceLayout);
        }
      }
      base.PerformLayout(blnForceLayout);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnLocationChanged(LayoutEventArgs e)
    {
      base.OnLocationChanged(e);
      if (!e.IsClientSource)
        return;
      this.Moved = true;
    }

    /// <summary>
    /// Gets the initial size of the serializable filed storage.
    /// </summary>
    /// <value>The initial size of the serializable filed storage.</value>
    protected internal override int SerializableFieldStorageInitialSize => 20;

    /// <summary>
    /// Gets the form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.
    /// </summary>
    /// <returns>The form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.</returns>
    /// <value></value>
    internal ShortcutsContainer Shortcuts
    {
      get
      {
        ShortcutsContainer objValue = this.GetValue<ShortcutsContainer>(Form.ShortcutsProperty);
        if (objValue == null)
        {
          objValue = new ShortcutsContainer();
          objValue.InternalParent = (Component) this;
          this.SetValue<ShortcutsContainer>(Form.ShortcutsProperty, objValue);
        }
        return objValue;
      }
    }

    /// <summary>Gets or sets the current multiple document interface (MDI) parent form of this form.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that represents the MDI parent form.</returns>
    /// <exception cref="T:System.Exception">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is not marked as an MDI container.-or- The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is both a child and an MDI container form.-or- The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is located on a different thread. </exception>
    [SRCategory("CatWindowStyle")]
    [SRDescription("FormMDIParentDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Form MdiParent
    {
      get => this.MdiParentInternal;
      set => this.MdiParentInternal = value;
    }

    /// <summary>Gets or sets the MDI parent internal.</summary>
    /// <value>The MDI parent internal.</value>
    private Form MdiParentInternal
    {
      get => this.GetValue<Form>(Form.MdiParentProperty);
      set
      {
        Form mdiParentInternal = this.MdiParentInternal;
        if (value == mdiParentInternal && (value != null || this.ParentInternal == null))
          return;
        bool visible = this.Visible;
        this.Visible = false;
        try
        {
          if (value == null)
          {
            this.SetTopLevel(true);
          }
          else
          {
            if (this.IsMdiContainer)
              throw new ArgumentException(SR.GetString("FormMDIParentAndChild"), nameof (value));
            if (!value.IsMdiContainer)
              throw new ArgumentException(SR.GetString("MDIParentNotContainer"), nameof (value));
            this.Dock = DockStyle.None;
            this.SetState(Control.ControlState.TopLevel, false);
            this.SetValue<Form>(Form.MdiParentProperty, value);
          }
        }
        finally
        {
          this.Visible = visible;
        }
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is closed.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is closed; otherwise, <c>false</c>.
    /// </value>
    bool IForm.IsClosed => this.GetState(Form.FormState.IsClosed);

    /// <summary>
    /// Gets a value indicating whether this instance is modal active.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is modal active; otherwise, <c>false</c>.
    /// </value>
    bool IForm.IsModalActive => this.GetState(Form.FormState.IsModalActive);

    /// <summary>Gets or sets the style of the size grip to display in the lower-right corner of the form.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.SizeGripStyle"></see> that represents the style of the size grip to display. The default is <see cref="F:System.Windows.Forms.SizeGripStyle.Auto"></see></returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values. </exception>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(SizeGripStyle.Auto)]
    [SRDescription("FormSizeGripStyleDescr")]
    [SRCategory("CatWindowStyle")]
    public SizeGripStyle SizeGripStyle
    {
      get => SizeGripStyle.Auto;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether right-to-left mirror placement is turned on.</summary>
    /// <returns>true if right-to-left mirror placement is turned on; otherwise, false for standard child control placement. The default is false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ControlRightToLeftLayoutDescr")]
    [Localizable(true)]
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    public virtual bool RightToLeftLayout
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Common.Interfaces.IForm" /> is active.
    /// </summary>
    /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
    bool IForm.Active
    {
      get => this.Active;
      set => this.Active = value;
    }

    /// <summary>Gets the forms.</summary>
    /// <value>The forms.</value>
    IForm[] IForm.Forms
    {
      get
      {
        IForm[] forms = (IForm[]) null;
        FormCollection ownedFormsCollection = this.OwnedFormsCollection;
        if (ownedFormsCollection != null && ownedFormsCollection.Count > 0)
          forms = (IForm[]) new ArrayList((ICollection) ownedFormsCollection).ToArray(typeof (IForm));
        return forms;
      }
    }

    /// <summary>Gets or sets the name associated with this control.</summary>
    /// <value></value>
    string IForm.Name => this.Name;

    /// <summary>Gets the form main menu</summary>
    IMainMenu IForm.Menu
    {
      get => (IMainMenu) this.Menu;
      set
      {
        if (!(value is MainMenu mainMenu))
          return;
        this.Menu = mainMenu;
      }
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGui.Forms.Control"></see> and its child controls and optionally releases the managed resources.
    /// </summary>
    void IForm.Dispose() => this.Dispose();

    /// <summary>Calculate size invluding borders</summary>
    [Browsable(false)]
    protected virtual bool IsWindowSized => false;

    /// <summary>Gets a value indicating whether the form is a multiple document interface (MDI) child form.</summary>
    /// <returns>true if the form is an MDI child form; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("FormIsMDIChildDescr")]
    [SRCategory("CatWindowStyle")]
    public bool IsMdiChild => this.MdiParent != null;

    /// <summary>
    /// Gets or sets a value indicating whether to use WG namespace.
    /// </summary>
    /// <value><c>true</c> if to use WG namespace; otherwise, <c>false</c>.</value>
    internal override bool UseWGNamespace => this.TopLevel;

    /// <summary>Gets or sets a value indicating whether the form is a container for multiple document interface (MDI) child forms.</summary>
    /// <returns>true if the form is a container for MDI child forms; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatWindowStyle")]
    [SRDescription("FormIsMDIContainerDescr")]
    [DefaultValue(false)]
    public bool IsMdiContainer
    {
      get => this.MdiClient != null;
      set
      {
        if (value == this.IsMdiContainer)
          return;
        if (value)
          this.Controls.Add((Control) (this.MdiClient = new MdiClient()));
        else if (this.IsMdiContainer)
        {
          this.Controls.Remove((Control) this.MdiClient);
          this.MdiClient = (MdiClient) null;
        }
        this.Invalidate();
      }
    }

    /// <summary>Gets or sets the form style.</summary>
    /// <value></value>
    public FormStyle FormStyle
    {
      get => this.GetValue<FormStyle>(Form.FormStyleProperty);
      set
      {
        if (!this.SetValue<FormStyle>(Form.FormStyleProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the entrance visual effect.</summary>
    /// <value>The entrance visual effect.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [MergableProperty(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("EntranceEffectDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public VisualEffect EntranceEffect
    {
      get => this.GetValue<VisualEffect>(Form.EntranceVisualEffectProperty, this.DefaultEntranceEffect);
      set
      {
        if (!this.SetValue<VisualEffect>(Form.EntranceVisualEffectProperty, value))
          return;
        this.UpdateParams(AttributeType.VisualEffect);
      }
    }

    /// <summary>Determines whether to serialize the entrance effect.</summary>
    /// <returns></returns>
    private bool ShouldSerializeEntranceEffect() => this.EntranceEffect != this.DefaultEntranceEffect;

    /// <summary>Resets the entrance effect.</summary>
    private void ResetEntranceEffect() => this.EntranceEffect = this.DefaultEntranceEffect;

    /// <summary>Gets or sets the exit visual effect.</summary>
    /// <value>The exit visual effect.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [MergableProperty(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("ExitEffectDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public VisualEffect ExitEffect
    {
      get => this.GetValue<VisualEffect>(Form.ExitVisualEffectProperty, this.DefaultExitEffect);
      set
      {
        if (!this.SetValue<VisualEffect>(Form.ExitVisualEffectProperty, value))
          return;
        this.UpdateParams(AttributeType.VisualEffect);
      }
    }

    /// <summary>Determines whether to serialize the Exit effect.</summary>
    /// <returns></returns>
    private bool ShouldSerializeExitEffect() => this.ExitEffect != this.DefaultExitEffect;

    /// <summary>Resets the Exit effect.</summary>
    private void ResetExitEffect() => this.ExitEffect = this.DefaultExitEffect;

    /// <summary>Gets the default exit effect.</summary>
    /// <value>The default exit effect.</value>
    protected virtual VisualEffect DefaultExitEffect => (VisualEffect) new TranslateVisualEffect(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, new float?(0.0f), new float?()), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, new float?(100f), new float?()), 0.25M, 0M, TransitionTimingFunction.EaseInOut);

    /// <summary>Gets the default entrance effect.</summary>
    /// <value>The default entrance effect.</value>
    protected virtual VisualEffect DefaultEntranceEffect => (VisualEffect) new TranslateVisualEffect(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, new float?(100f), new float?()), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, new float?(0.0f), new float?()), 0.25M, 0M, TransitionTimingFunction.EaseInOut);

    /// <summary>
    /// Gets or sets the restored window state before it was minimized.
    /// </summary>
    /// <value>The last state of the form window.</value>
    private FormWindowState FormRestoredWindowState
    {
      get => this.GetValue<FormWindowState>(Form.FormRestoredWindowStateProperty);
      set => this.SetValue<FormWindowState>(Form.FormRestoredWindowStateProperty, value);
    }

    /// <summary>Gets the size of a minimized form.</summary>
    /// <value>The size of a minimized form.</value>
    private Size FormMinimizedSize
    {
      get
      {
        Size formMinimizedSize = Size.Empty;
        if (this.MdiParent != null)
        {
          if (SkinFactory.GetSkin((ISkinable) this, typeof (FormSkin)) is FormSkin skin1)
            formMinimizedSize = skin1.MinimizedMdiFormSize;
        }
        else if (SkinFactory.GetSkin((ISkinable) this, typeof (TaskBarSkin)) is TaskBarSkin skin2)
          formMinimizedSize = new Size(skin2.ItemWidth, skin2.ItemHeight);
        return formMinimizedSize;
      }
    }

    /// <summary>
    /// Gets or sets the size of the form before it was maximized.
    /// </summary>
    /// <value>The size of the form restored.</value>
    private Size FormRestoredSize
    {
      get => this.GetValue<Size>(Form.FormRestoredSizeProperty);
      set => this.SetValue<Size>(Form.FormRestoredSizeProperty, value);
    }

    /// <summary>
    /// Gets or sets the location of the form before it was maximized.
    /// </summary>
    /// <value>The form restored location.</value>
    private Point FormRestoredLocation
    {
      get => this.GetValue<Point>(Form.FormRestoredLocationProperty);
      set => this.SetValue<Point>(Form.FormRestoredLocationProperty, value);
    }

    /// <summary>Gets or sets the state of the window.</summary>
    /// <value></value>
    [DefaultValue(FormWindowState.Normal)]
    [SRDescription("FormWindowStateDescr")]
    [SRCategory("CatLayout")]
    public FormWindowState WindowState
    {
      get => this.GetValue<FormWindowState>(Form.WindowStateProperty);
      set => this.SetWindowState(value);
    }

    /// <summary>Sets the state of the window.</summary>
    /// <param name="enmNewFormWindowState">New window state of the form.</param>
    private void SetWindowState(FormWindowState enmNewFormWindowState) => this.OnWindowStateChanged(enmNewFormWindowState);

    /// <summary>Called when [window state changed].</summary>
    /// <param name="enmNewFormWindowState">State of the enm new form window.</param>
    protected virtual void OnWindowStateChanged(FormWindowState enmNewFormWindowState)
    {
      FormWindowState windowState = this.WindowState;
      if (windowState == enmNewFormWindowState)
        return;
      if (this.Parent == null)
      {
        switch (enmNewFormWindowState)
        {
          case FormWindowState.Normal:
            this.SetValue<FormWindowState>(Form.WindowStateProperty, enmNewFormWindowState);
            if (this.FormRestoredSize != Size.Empty)
            {
              this.Size = this.FormRestoredSize;
              this.FormRestoredSize = Size.Empty;
            }
            if (this.FormRestoredLocation != Point.Empty)
            {
              this.Location = this.FormRestoredLocation;
              this.FormRestoredLocation = Point.Empty;
              break;
            }
            break;
          case FormWindowState.Minimized:
            if (windowState == FormWindowState.Normal)
            {
              this.FormRestoredSize = this.Size;
              this.FormRestoredLocation = this.Location;
            }
            this.FormRestoredWindowState = windowState;
            this.Size = this.FormMinimizedSize;
            if (this.MdiParent == null)
              this.Location = new Point(0, 0);
            this.SetValue<FormWindowState>(Form.WindowStateProperty, enmNewFormWindowState);
            break;
          case FormWindowState.Maximized:
            if (windowState == FormWindowState.Normal)
            {
              this.FormRestoredSize = this.Size;
              this.FormRestoredLocation = this.Location;
            }
            Size size = Size.Empty;
            if (this.MdiParent != null)
              size = this.MdiParent.Size;
            else if (this.Context != null && this.Context.MainForm is Form mainForm)
              size = mainForm.Size;
            if (size != Size.Empty)
              this.Size = size;
            this.Location = new Point(0, 0);
            this.SetValue<FormWindowState>(Form.WindowStateProperty, enmNewFormWindowState);
            break;
        }
        this.UpdateParams(AttributeType.Redraw);
      }
      this.FireObservableItemPropertyChanged("WindowState");
    }

    /// <summary>Gets or sets the form border style.</summary>
    /// <value></value>
    [DefaultValue(FormBorderStyle.Sizable)]
    [SRCategory("CatAppearance")]
    [SRDescription("FormBorderStyleDescr")]
    public FormBorderStyle FormBorderStyle
    {
      get => this.GetValue<FormBorderStyle>(Form.FormBorderStyleProperty);
      set
      {
        if (!this.SetValue<FormBorderStyle>(Form.FormBorderStyleProperty, value))
          return;
        this.UpdateParams(AttributeType.Redraw);
        this.FireObservableItemPropertyChanged(nameof (FormBorderStyle));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [minimize box].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [minimize box]; otherwise, <c>false</c>.
    /// </value>
    [SRCategory("CatWindowStyle")]
    [DefaultValue(true)]
    [SRDescription("FormMinimizeBoxDescr")]
    public bool MinimizeBox
    {
      get => this.GetState(Form.FormState.MinimizeBox);
      set
      {
        if (!this.SetStateWithCheck(Form.FormState.MinimizeBox, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (MinimizeBox));
        this.UpdateParams(AttributeType.Extended);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a form has a modal mask when modal.
    /// </summary>
    /// <value><c>true</c> if a form has a modal mask when modal; otherwise, <c>false</c>.</value>
    [SRCategory("CatWindowStyle")]
    [DefaultValue(true)]
    [SRDescription("FormModalMaskDescr")]
    public bool ModalMask
    {
      get => this.GetValue<bool>(Form.ModalMaskProperty);
      set => this.SetValue<bool>(Form.ModalMaskProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [maximize box].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [maximize box]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("FormMaximizeBoxDescr")]
    [SRCategory("CatWindowStyle")]
    [DefaultValue(true)]
    public bool MaximizeBox
    {
      get => this.GetState(Form.FormState.MaximizeBox);
      set
      {
        if (!this.SetStateWithCheck(Form.FormState.MaximizeBox, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (MaximizeBox));
        this.UpdateParams(AttributeType.Extended);
      }
    }

    /// <summary>Gets or sets a value indicating whether [close box].</summary>
    /// <value>
    ///   <c>true</c> if [close box]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("FormCloseBoxDescr")]
    [SRCategory("CatWindowStyle")]
    [DefaultValue(true)]
    public bool CloseBox
    {
      get => this.GetState(Form.FormState.CloseBox);
      set
      {
        if (!this.SetStateWithCheck(Form.FormState.CloseBox, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (CloseBox));
        this.UpdateParams(AttributeType.Extended);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show in taskbar].
    /// Not implemented by design
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [show in taskbar]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [SRDescription("FormShowInTaskbarDescr")]
    [SRCategory("CatWindowStyle")]
    [Obsolete("Not implemented by design")]
    public bool ShowInTaskbar
    {
      get => true;
      set
      {
      }
    }

    /// <summary>Gets or sets The starting position of the window</summary>
    /// <value></value>
    [SRDescription("FormStartPositionDescr")]
    [DefaultValue(2)]
    [Localizable(true)]
    [SRCategory("CatLayout")]
    public FormStartPosition StartPosition
    {
      get => this.GetValue<FormStartPosition>(Form.StartPositionProperty);
      set
      {
        if (!this.SetValue<FormStartPosition>(Form.StartPositionProperty, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (StartPosition));
      }
    }

    /// <summary>Gets or sets the dialog Alignment.</summary>
    /// <value></value>
    private DialogAlignment DialogAlignment
    {
      get => this.GetValue<DialogAlignment>(Form.DialogAlignmentProperty);
      set => this.SetValue<DialogAlignment>(Form.DialogAlignmentProperty, value);
    }

    /// <summary>Gets or sets the dialog result.</summary>
    /// <value></value>
    public DialogResult DialogResult
    {
      get => this.GetValue<DialogResult>(Form.DialogResultProperty);
      set => this.SetValue<DialogResult>(Form.DialogResultProperty, value);
    }

    /// <summary>
    /// Gets or sets the button on the form that is clicked when the user presses the ESC key.
    /// </summary>
    public IButtonControl CancelButton
    {
      get => this.GetValue<IButtonControl>(Form.CancelButtonProperty);
      set
      {
        if (!this.SetValue<IButtonControl>(Form.CancelButtonProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
        if (value == null || value.DialogResult != DialogResult.None)
          return;
        value.DialogResult = DialogResult.Cancel;
      }
    }

    /// <summary>Gets or sets the before unload message.</summary>
    /// <value>The before unload message.</value>
    [Localizable(true)]
    [DefaultValue("")]
    public string BeforeUnloadMessage
    {
      get => this.GetValue<string>(Form.BeforeUnloadMessageProperty);
      set
      {
        if (value == null)
          value = string.Empty;
        if (!this.SetValue<string>(Form.BeforeUnloadMessageProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the button on the form that is clicked when the user presses the ENTER key.
    /// </summary>
    public IButtonControl AcceptButton
    {
      get => this.GetValue<IButtonControl>(Form.AcceptButtonProperty);
      set
      {
        if (!this.SetValue<IButtonControl>(Form.AcceptButtonProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Sets the visible internal.</summary>
    /// <param name="blnValue">if set to <c>true</c> set visible.</param>
    internal override void SetVisibleInternal(bool blnValue)
    {
      if (this.TopLevel)
      {
        if (this.Visible == blnValue)
          return;
        IContext current = VWGContext.Current;
        if (blnValue)
        {
          base.SetVisibleInternal(blnValue);
          if (current != null && current.MainForm != this)
            this.Show();
          else
            this.CreateControl();
        }
        else
        {
          if (current != null && current.MainForm != this && current.MainForm != null)
            this.Close(false, true, false);
          base.SetVisibleInternal(blnValue);
        }
      }
      else
        base.SetVisibleInternal(blnValue);
    }

    /// <summary>Gets or sets a value indicating whether [top most].</summary>
    /// <value><c>true</c> if [top most]; otherwise, <c>false</c>.</value>
    [SRDescription("FormTopMostDescr")]
    [SRCategory("CatWindowStyle")]
    [DefaultValue(false)]
    public bool TopMost
    {
      get => !this.DesignMode && this.Context != null && this.Context.ActiveForm == this;
      set
      {
      }
    }

    /// <summary>Gets/Sets visibility internally</summary>
    internal bool InternalVisible
    {
      get => this.Visible;
      set => base.SetVisibleInternal(value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [called on load].
    /// </summary>
    /// <value><c>true</c> if [called on load]; otherwise, <c>false</c>.</value>
    private bool CalledOnLoad
    {
      get => this.GetState(Form.FormState.CalledOnLoad);
      set => this.SetState(Form.FormState.CalledOnLoad, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [called make visible].
    /// </summary>
    /// <value><c>true</c> if [called make visible]; otherwise, <c>false</c>.</value>
    private bool CalledMakeVisible
    {
      get => this.GetState(Form.FormState.CalledMakeVisible);
      set => this.SetState(Form.FormState.CalledMakeVisible, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [called create control].
    /// </summary>
    /// <value><c>true</c> if [called create control]; otherwise, <c>false</c>.</value>
    private bool CalledCreateControl
    {
      get => this.GetState(Form.FormState.CalledCreateControlProperty);
      set => this.SetState(Form.FormState.CalledCreateControlProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the form was moved.
    /// </summary>
    /// <value><c>true</c> if moved; otherwise, <c>false</c>.</value>
    private bool Moved
    {
      get => this.GetState(Form.FormState.Moved);
      set => this.SetState(Form.FormState.Moved, value);
    }

    /// <summary>Gets the context.</summary>
    /// <value></value>
    public override IContext Context
    {
      get
      {
        if (!this.TopLevel)
          return base.Context;
        IContext context = this.mobjContext;
        if (context == null)
          this.mobjContext = context = VWGContext.Current;
        return context;
      }
    }

    /// <summary>Sets the context.</summary>
    /// <value></value>
    internal void SetContextInternal(IContext objContext)
    {
      this.mobjContext = objContext;
      foreach (Form ownedForm in this.OwnedForms)
        ownedForm.SetContextInternal(objContext);
    }

    /// <summary>Sets the context.</summary>
    /// <param name="objContext">The context.</param>
    void IForm.SetContext(IContext objContext)
    {
      if (objContext == null)
        return;
      this.SetContextInternal(objContext);
    }

    /// <summary>Clears the context.</summary>
    void IForm.ClearContext() => this.SetContextInternal((IContext) null);

    /// <summary>
    /// Gets or sets a value indicating whether this window is modal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is modal; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool Modal
    {
      get
      {
        switch (this.DialogType)
        {
          case DialogTypes.ModalWindow:
            return true;
          case DialogTypes.ModalessWindow:
            return false;
          case DialogTypes.PopupWindow:
            return false;
          default:
            return false;
        }
      }
    }

    /// <devdoc>Retrieves true if this form is currently active.</devdoc>
    internal bool Active
    {
      get
      {
        Form parentFormInternal = this.ParentFormInternal;
        if (parentFormInternal == null)
          return this.GetState(Form.FormState.IsActiveForm);
        return parentFormInternal.ActiveControl == this && parentFormInternal.Active;
      }
      set
      {
        if (!this.SetStateWithCheck(Form.FormState.IsActiveForm, value))
          return;
        if (value)
        {
          if (!this.ValidationCancelled)
          {
            if (this.ActiveControl == null)
              this.SelectNextControlInternal((Control) null, true, true, true, false);
            this.InnerMostActiveContainerControl.FocusActiveControlInternal();
          }
          this.OnActivated(EventArgs.Empty);
        }
        else
          this.OnDeactivate(EventArgs.Empty);
      }
    }

    /// <summary>Gets or sets the parent container of this control.</summary>
    /// <value></value>
    internal override Control ParentInternal
    {
      get => base.ParentInternal;
      set
      {
        if (value != null)
          this.Owner = (Form) null;
        base.ParentInternal = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to display the form as a top-level window.
    /// </summary>
    /// <value><c>true</c> if [top level]; otherwise, <c>false</c>.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool TopLevel
    {
      get => this.GetTopLevel();
      set
      {
        if (!value && this.IsMdiContainer && !this.DesignMode)
          throw new ArgumentException(SR.GetString("MDIContainerMustBeTopLevel"), nameof (value));
        this.SetTopLevel(value);
      }
    }

    /// <summary>Gets or sets the type.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public DialogTypes DialogType
    {
      get => this.GetValue<DialogTypes>(Form.DialogTypeProperty);
      internal set => this.SetValue<DialogTypes>(Form.DialogTypeProperty, value);
    }

    /// <summary>Gets or sets the form that owns this form.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that represents the form that is the owner of this form.</returns>
    /// <exception cref="T:System.Exception">A top-level window cannot have an owner. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("FormOwnerDescr")]
    [SRCategory("CatWindowStyle")]
    public Form Owner
    {
      get => this.OwnerInternal;
      set
      {
        Form ownerInternal = this.OwnerInternal;
        if (ownerInternal == value)
          return;
        if (value != null && !this.TopLevel)
          throw new ArgumentException(SR.GetString("NonTopLevelCantHaveOwner"), nameof (value));
        Control.CheckParentingCycle((Control) this, (Control) value);
        Control.CheckParentingCycle((Control) value, (Control) this);
        this.SetValue<Form>(Form.OwnerProperty, (Form) null);
        ownerInternal?.RemoveOwnedForm(this);
        this.OwnerInternal = value;
        value?.AddOwnedForm(this);
      }
    }

    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [SRDescription("ControlTabStopDescr")]
    [DefaultValue(true)]
    [DispId(-516)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets or sets the tab order of the control within its container.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> containing the index of the control within the set of controls within its container that is included in the tab order.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    /// <summary>Gets or sets the parent window.</summary>
    /// <value></value>
    internal Form OwnerInternal
    {
      get => this.GetValue<Form>(Form.OwnerProperty);
      set => this.SetValue<Form>(Form.OwnerProperty, value);
    }

    /// <summary>Gets or sets the closed delegate.</summary>
    /// <value>The closed delegate.</value>
    private EventHandler ClosedDelegate
    {
      get => this.GetValue<EventHandler>(Form.ClosedDelegateProperty);
      set => this.SetValue<EventHandler>(Form.ClosedDelegateProperty, value);
    }

    /// <summary>Gets the child forms.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Form[] OwnedForms => this.mobjOwnedForms == null ? new Form[0] : (Form[]) new ArrayList((ICollection) this.mobjOwnedForms).ToArray(typeof (Form));

    /// <summary>
    /// Gets the form FormCollection from propertyStore if existed and a new FormCollection otherwise.
    /// </summary>
    /// <returns>The form FormCollection from propertyStore if existed and a new FormCollection otherwise.</returns>
    /// <value></value>
    internal FormCollection OwnedFormsCollection
    {
      get
      {
        if (this.mobjOwnedForms == null)
          this.mobjOwnedForms = new FormCollection(this);
        return this.mobjOwnedForms;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has windows.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has windows; otherwise, <c>false</c>.
    /// </value>
    internal bool HasWindows
    {
      get
      {
        FormCollection ownedFormsCollection = this.OwnedFormsCollection;
        return ownedFormsCollection != null && ownedFormsCollection.Count > 0;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has modal windows.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has modal windows; otherwise, <c>false</c>.
    /// </value>
    internal bool HasModalWindows => this.OwnedModalForm != null;

    /// <summary>Gets the owned modal form.</summary>
    /// <value>The owned modal form.</value>
    private Form OwnedModalForm
    {
      get
      {
        Form ownedModalForm = (Form) null;
        FormCollection ownedFormsCollection = this.OwnedFormsCollection;
        if (ownedFormsCollection != null && ownedFormsCollection.Count > 0)
        {
          foreach (Form form in (CollectionBase) ownedFormsCollection)
          {
            if (form.TopLevel && form.DialogType == DialogTypes.ModalWindow)
              ownedModalForm = form;
          }
        }
        return ownedModalForm;
      }
    }

    /// <summary>Gets the top most owned modal form.</summary>
    /// <value>The top most owned modal form.</value>
    private Form TopMostOwnedModalForm
    {
      get
      {
        Form mostOwnedModalForm = (Form) null;
        Form ownedModalForm = this.OwnedModalForm;
        if (ownedModalForm != null && (mostOwnedModalForm = ownedModalForm.TopMostOwnedModalForm) == null)
          mostOwnedModalForm = ownedModalForm;
        return mostOwnedModalForm;
      }
    }

    /// <summary>Gets or sets the form Mdi client</summary>
    public MdiClient MdiClient
    {
      get => this.GetValue<MdiClient>(Form.MdiClientProperty);
      internal set => this.SetValue<MdiClient>(Form.MdiClientProperty, value);
    }

    /// <summary>Gets the form Mdi children</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Form[] MdiChildren => this.MdiClient != null ? this.MdiClient.MdiChildren : new Form[0];

    /// <summary>Gets the form active Mdi child</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Form ActiveMdiChild => (Form) null;

    /// <summary>Gets or sets the form icon</summary>
    [ProxyBrowsable(true)]
    public ResourceHandle Icon
    {
      get => this.GetValue<ResourceHandle>(Form.IconProperty);
      set => this.SetValue<ResourceHandle>(Form.IconProperty, value);
    }

    /// <summary>
    /// Gets or sets the size of the auto scale base.
    /// Not implemented.
    /// </summary>
    /// <value></value>
    [Obsolete("Not implemented.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public Size AutoScaleBaseSize
    {
      get => new Size(5, 3);
      set
      {
      }
    }

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
    public override bool IsEventsEnabled => this.Visible;

    /// <summary>Gets or sets the form header control.</summary>
    /// <value></value>
    [Browsable(false)]
    public Control Header
    {
      get => this.GetValue<Control>(Form.HeaderProperty);
      set
      {
        if (!this.SetValue<Control>(Form.HeaderProperty, value) || value == null)
          return;
        value.InternalParent = (Component) this;
      }
    }

    /// <summary>
    /// Gets or sets the color that will represent transparent areas of the form.
    /// Not implemented by design.
    /// </summary>
    /// <value>The transparency key.</value>
    [Obsolete("Not implemented by design")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color TransparencyKey
    {
      get => this.GetValue<Color>(Form.TransparencyKeyProperty);
      set => this.SetValue<Color>(Form.TransparencyKeyProperty, value);
    }

    /// <summary>
    /// Gets a flag indicating if should serialize the transparency key.
    /// </summary>
    /// <returns></returns>
    private bool ShouldSerializeTransparencyKey() => this.TransparencyKey != Color.Empty;

    /// <summary>Shoulds the serialize geo location data.</summary>
    /// <returns></returns>
    private bool ShouldSerializeGeoLocationData() => !GeoLocationData.Empty.Equals((object) this.GeographicLocation);

    /// <summary>Resets the geo location data.</summary>
    private void ResetGeoLocationData() => this.GeographicLocation = GeoLocationData.Empty;

    /// <summary>Check if conrtol should be rendered.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    protected override bool ShouldRenderControl(Control objControl) => !(objControl is MdiClient);

    /// <summary>
    /// Gets or sets a value indicating whether [activate on pre render].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [activate on show]; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool ActivateOnShow
    {
      get => this.GetValue<bool>(Form.ActivateOnShowProperty);
      set => this.SetValue<bool>(Form.ActivateOnShowProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether a control box is displayed in the caption bar of the form.
    /// </summary>
    /// <value>
    ///   <c>true</c> if the form displays a control box in the upper left corner of the form; otherwise, <c>false</c>. The default is true.
    /// </value>
    [SRCategory("CatWindowStyle")]
    [DefaultValue(true)]
    [SRDescription("FormControlBoxDescr")]
    public bool ControlBox
    {
      get => this.GetValue<bool>(Form.ControlBoxProperty);
      set
      {
        if (!this.SetValue<bool>(Form.ControlBoxProperty, value))
          return;
        this.UpdateParams(AttributeType.Extended);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [key preview].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [key preview]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool KeyPreview
    {
      get => this.GetValue<bool>(Form.KeyPreviewProperty);
      set => this.SetValue<bool>(Form.KeyPreviewProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [help button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [help button]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HelpButton
    {
      get => this.GetValue<bool>(Form.HelpButtonProperty);
      set => this.SetValue<bool>(Form.HelpButtonProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether an icon is displayed in the caption bar of the form.</summary>
    /// <returns>true if the form displays an icon in the caption bar; otherwise, false. The default is true.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatWindowStyle")]
    [SRDescription("FormShowIconDescr")]
    [DefaultValue(true)]
    public bool ShowIcon
    {
      get => true;
      set
      {
      }
    }

    /// <summary>Gets or sets the opacity level of the form.</summary>
    /// <returns>The level of opacity for the form. The default is 1.00.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(1.0)]
    [SRDescription("FormOpacityDescr")]
    [SRCategory("CatWindowStyle")]
    public double Opacity
    {
      get => 1.0;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is resizable.
    /// </summary>
    /// <value>
    ///   <c>true</c> if resizable; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    [Obsolete("Use FormBorderStyle property to change resizable functionality")]
    public override ResizableOptions Resizable
    {
      get => !this.TopLevel ? base.Resizable : (ResizableOptions) null;
      set
      {
        if (this.TopLevel)
          return;
        base.Resizable = value;
      }
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DialogType == DialogTypes.ModalWindow && ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread")
        criticalEventsData.Set("CLO");
      if (this.ClosedHandler != null || this.FormClosedHandler != null || this.ClosedDelegate != null)
        criticalEventsData.Set("CLO");
      if (this.ClosingHandler != null || this.FormClosingHandler != null)
        criticalEventsData.Set("CLI");
      if (this.ActivatedHandler != null)
        criticalEventsData.Set("AC");
      if (this.DeactivateHandler != null)
        criticalEventsData.Set("DAT");
      if (this.OrientationChangedHandler != null)
        criticalEventsData.Set("OC");
      if (this.GeographicLocationChangedHandler != null)
        criticalEventsData.Set("PC");
      return criticalEventsData;
    }

    /// <summary>
    /// Sets the specified bounds of the control to the specified location and size.
    /// </summary>
    /// <param name="intLeft">The int left.</param>
    /// <param name="intTop">The int top.</param>
    /// <param name="intWidth">Width of the int layout.</param>
    /// <param name="intHeight">Height of the int layout.</param>
    /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
    /// <returns></returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override bool SetBounds(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified)
    {
      if (this.WindowState == FormWindowState.Normal)
        return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified);
      Point restoredLocation = this.FormRestoredLocation;
      Size formRestoredSize = this.FormRestoredSize;
      if ((enmSpecified & BoundsSpecified.X) != BoundsSpecified.None)
        restoredLocation.X = intLeft;
      if ((enmSpecified & BoundsSpecified.Y) != BoundsSpecified.None)
        restoredLocation.Y = intTop;
      if ((enmSpecified & BoundsSpecified.Width) != BoundsSpecified.None)
        formRestoredSize.Width = intWidth;
      if ((enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None)
        formRestoredSize.Height = intHeight;
      this.FormRestoredSize = formRestoredSize;
      this.FormRestoredLocation = restoredLocation;
      return false;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.ClosedDelegate != null || this.HasClientHandler("OnUnload"))
      {
        clientEventsData.Set("CLO");
        clientEventsData.Set("CLI");
      }
      if (this.HasClientHandler("Activated"))
        clientEventsData.Set("AC");
      if (this.HasClientHandler("OrientationChange"))
        clientEventsData.Set("OC");
      if (this.HasClientHandler("GeoLocationChanged"))
        clientEventsData.Set("PC");
      return clientEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(type))
      {
        case 23090026:
          if (!(type == "WindowStateChange") || !objEvent.Contains("WS"))
            break;
          this.SetWindowState((FormWindowState) Enum.Parse(typeof (FormWindowState), objEvent["WS"]));
          break;
        case 227274147:
          if (!(type == "OnUnload"))
            break;
          this.Context.ActiveForm = (IForm) this;
          this.Close(true, false, false);
          break;
        case 1218613055:
          if (!(type == "GeoLocationChanged"))
            break;
          this.HandleGeographicLocationChanged(objEvent);
          break;
        case 1673857377:
          if (!(type == "OrientationChange"))
            break;
          this.OnOrientationChanged(objEvent);
          break;
        case 2468156842:
          if (!(type == "OnCancel"))
            break;
          IButtonControl cancelButton = this.CancelButton;
          if (cancelButton == null)
            break;
          Control control1 = cancelButton as Control;
          if (!control1.Enabled || !control1.Visible)
            break;
          cancelButton.PerformClick();
          break;
        case 2547828883:
          if (!(type == "Shortcut"))
            break;
          this.Shortcuts[objEvent["VLB"]]?.FireEvent(objEvent);
          break;
        case 3055555356:
          if (!(type == "Activated"))
            break;
          this.ActivateForm(true);
          break;
        case 3063458536:
          if (!(type == "OnAccept"))
            break;
          IButtonControl acceptButton = this.AcceptButton;
          if (acceptButton == null)
            break;
          Control control2 = acceptButton as Control;
          if (!control2.Enabled || !control2.Visible)
            break;
          acceptButton.PerformClick();
          break;
        case 3542711024:
          if (!(type == "ShowServerExplorer") || !CommonSwitches.EnableClientShortcuts)
            break;
          ServerExplorer serverExplorer = new ServerExplorer();
          serverExplorer.SetRootComponent((IRegisteredComponent) this.Context.MainForm);
          int num = (int) serverExplorer.ShowDialog();
          break;
        case 4189619796:
          if (!(type == "OnClose"))
            break;
          ((IContextTerminate) this.Context).SetPendingTermination();
          break;
      }
    }

    /// <summary>Handles the geographic location changed.</summary>
    /// <param name="objEvent">The obj event.</param>
    private void HandleGeographicLocationChanged(IEvent objEvent)
    {
      if (objEvent == null)
        return;
      string str1 = objEvent["ECD"];
      string str2 = objEvent["EM"];
      if (!string.IsNullOrEmpty(str1) || !string.IsNullOrEmpty(str2))
        throw new Exception(string.Format("Geographic location error (code {0}):\n{1}", (object) str1, (object) str2));
      double dblValue1;
      double dblValue2;
      if (!CommonUtils.TryParse(objEvent["LAT"], out dblValue1) || !CommonUtils.TryParse(objEvent["LNG"], out dblValue2))
        return;
      this.OnGeographicLocationChanged(new GeographicLocationChangedEventArgs(new GeoLocation(dblValue1, dblValue2)));
    }

    /// <summary>
    /// Raises the <see cref="E:GeographicLocationChanged" /> event.
    /// </summary>
    /// <param name="objGeoLocationChangedEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.GeographicLocationChangedEventArgs" /> instance containing the event data.</param>
    protected virtual void OnGeographicLocationChanged(
      GeographicLocationChangedEventArgs objGeoLocationChangedEventArgs)
    {
      if (this.GeographicLocationChangedHandler == null)
        return;
      this.GeographicLocationChangedHandler((object) this, objGeoLocationChangedEventArgs);
    }

    internal void OnFormAdded(Form objForm)
    {
      ObservableListEventHandler itemAddedHandler = this.ObservableItemAddedHandler;
      if (itemAddedHandler == null)
        return;
      itemAddedHandler((object) this, new ObservableListEventArgs((object) objForm));
    }

    internal void OnFormRemoved(Form objForm)
    {
      ObservableListEventHandler itemRemovedHandler = this.ObservableItemRemovedHandler;
      if (itemRemovedHandler == null)
        return;
      itemRemovedHandler((object) this, new ObservableListEventArgs((object) objForm));
    }

    /// <summary>Occurs when [observable item added].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableListEventHandler ObservableItemAdded
    {
      add => this.AddHandler(Form.ObservableItemAddedEvent, (Delegate) value);
      remove => this.RemoveHandler(Form.ObservableItemAddedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ObservableItemAdded event.</summary>
    private ObservableListEventHandler ObservableItemAddedHandler => (ObservableListEventHandler) this.GetHandler(Form.ObservableItemAddedEvent);

    /// <summary>Occurs when [observable item inserted].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableListEventHandler ObservableItemInserted
    {
      add => this.AddHandler(Form.ObservableItemInsertedEvent, (Delegate) value);
      remove => this.RemoveHandler(Form.ObservableItemInsertedEvent, (Delegate) value);
    }

    /// <summary>
    /// Gets the hanlder for the ObservableItemInserted event.
    /// </summary>
    private ObservableListEventHandler ObservableItemInsertedHandler => (ObservableListEventHandler) this.GetHandler(Form.ObservableItemInsertedEvent);

    /// <summary>Occurs when [observable item removed].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableListEventHandler ObservableItemRemoved
    {
      add => this.AddHandler(Form.ObservableItemRemovedEvent, (Delegate) value);
      remove => this.RemoveHandler(Form.ObservableItemRemovedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ObservableItemRemoved event.</summary>
    private ObservableListEventHandler ObservableItemRemovedHandler => (ObservableListEventHandler) this.GetHandler(Form.ObservableItemRemovedEvent);

    /// <summary>Occurs when [observable list cleared].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event EventHandler ObservableListCleared
    {
      add => this.AddHandler(Form.ObservableListClearedEvent, (Delegate) value);
      remove => this.RemoveHandler(Form.ObservableListClearedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ObservableListCleared event.</summary>
    private EventHandler ObservableListClearedHandler => (EventHandler) this.GetHandler(Form.ObservableListClearedEvent);

    /// <summary>
    /// Occurs when the client loads and provides online preperations for entering client mode.
    /// </summary>
    /// <value>The client mode preload handlers.</value>
    [Category("Client")]
    [Description("Occurs when the client loads and provides online preperations for entering client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientPreload
    {
      add => this.AddClientHandler("ClientPreload", value);
      remove => this.RemoveClientHandler("ClientPreload", value);
    }

    /// <summary>Occurs when client mode is initialized</summary>
    /// <value>The client mode initialized handlers.</value>
    [Category("Client")]
    [Description("Occurs after the application changed to offline mode, and offline initializing should be performed.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler OfflineInitializing
    {
      add => this.AddClientHandler("OfflineInitializing", value);
      remove => this.RemoveClientHandler("OfflineInitializing", value);
    }

    /// <summary>Occurs when [client confirming].</summary>
    [Category("Client")]
    [Description("Occurs when confirming offline mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler OfflineConfirming
    {
      add => this.AddClientHandler("OfflineConfirming", value);
      remove => this.RemoveClientHandler("OfflineConfirming", value);
    }

    /// <summary>Occurs when [client closed].</summary>
    [Category("Client")]
    [Description("Occurs when form closed in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientClosed
    {
      add => this.AddClientHandler("OnUnload", value);
      remove => this.RemoveClientHandler("OnUnload", value);
    }

    /// <summary>Occurs when [client activated].</summary>
    [Category("Client")]
    [Description("Occurs when form activated in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientActivated
    {
      add => this.AddClientHandler("Activated", value);
      remove => this.RemoveClientHandler("Activated", value);
    }

    /// <summary>Occurs when [client resize].</summary>
    [Category("Client")]
    [Description("Occurs when the form resized and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientResize
    {
      add => this.AddClientHandler("Resize", value);
      remove => this.RemoveClientHandler("Resize", value);
    }

    /// <summary>Occurs when [client move].</summary>
    [Category("Client")]
    [Description("Occurs when the form moved and client is in client mode.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public event ClientEventHandler ClientMove
    {
      add => this.AddClientHandler("Move", value);
      remove => this.RemoveClientHandler("Move", value);
    }

    IProxyForm IFormParams.ProxyForm
    {
      get => this.ProxyComponent as IProxyForm;
      set => this.ProxyComponent = value as ProxyComponent;
    }

    event EventHandler IFormParams.PreRendered
    {
      add => this.mobjPreRender += value;
      remove => this.mobjPreRender -= value;
    }

    /// <summary>Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.FormClosing"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void FormClosingEventHandler(object sender, FormClosingEventArgs e);

    /// <summary>Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.FormClosed"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void FormClosedEventHandler(object sender, FormClosedEventArgs e);

    /// <summary>Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.OrientationChanged"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void OrientationChangedEventHandler(
      object sender,
      OrientationChangedEventArgs e);

    [Flags]
    internal enum FormState
    {
      /// <summary>The is active form flag</summary>
      IsActiveForm = 1,
      /// <summary>The called on load flag</summary>
      CalledOnLoad = 2,
      /// <summary>The called make visible flag</summary>
      CalledMakeVisible = 4,
      /// <summary>The called create control flag</summary>
      CalledCreateControlProperty = 8,
      /// <summary>The maximize box flag</summary>
      MaximizeBox = 16, // 0x00000010
      /// <summary>The minimize box flag</summary>
      MinimizeBox = 32, // 0x00000020
      /// <summary>The is closed flag</summary>
      IsClosed = 64, // 0x00000040
      /// <summary>The form moved flag</summary>
      Moved = 128, // 0x00000080
      /// <summary>The is modal active flag</summary>
      IsModalActive = 256, // 0x00000100
      /// <summary>The Close box flag</summary>
      CloseBox = 512, // 0x00000200
    }

    /// <summary>Represents a collection of controls on the form.</summary>
    [Serializable]
    public new class ControlCollection : Control.ControlCollection
    {
      private Form mobjOwner;

      /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Form.ControlCollection"></see> class.</summary>
      /// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to contain the controls added to the control collection. </param>
      public ControlCollection(Form objOwner)
        : base((Control) objOwner)
      {
        this.mobjOwner = objOwner;
      }

      /// <summary>Adds the specified control to the control collection.</summary>
      /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection. </param>
      public override void Add(Control objValue)
      {
        if (objValue is MdiClient && this.mobjOwner.MdiClient == null)
          this.mobjOwner.MdiClient = (MdiClient) objValue;
        base.Add(objValue);
      }

      /// <summary>Removes the specified control from the control collection.</summary>
      /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove from the <see cref="T:Gizmox.WebGUI.Forms.Form.ControlCollection"></see>. </param>
      public override void Remove(Control objValue)
      {
        if (objValue == this.mobjOwner.MdiClient)
          this.mobjOwner.MdiClient = (MdiClient) null;
        base.Remove(objValue);
      }
    }
  }
}
