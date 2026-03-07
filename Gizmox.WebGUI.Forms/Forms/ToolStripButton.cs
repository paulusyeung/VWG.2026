// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripButton
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a selectable <see cref="T:System.Windows.Forms.ToolStripItem"></see> that can contain text and images. </summary>
  [Skin(typeof (ToolStripButtonSkin))]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ToolStripButton : ToolStripItem
  {
    private static readonly SerializableProperty menmCheckStateProperty = SerializableProperty.Register(nameof (menmCheckState), typeof (CheckState), typeof (ToolStripButton));
    private static readonly SerializableProperty mblnCheckOnClickProperty = SerializableProperty.Register(nameof (mblnCheckOnClick), typeof (bool), typeof (ToolStripButton));
    private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof (EventHandler), typeof (ToolStripButton));
    private static readonly SerializableEvent CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof (EventHandler), typeof (ToolStripButton));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class.</summary>
    public ToolStripButton()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text.</summary>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    public ToolStripButton(string text)
      : base(text, (ResourceHandle) null, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified image.</summary>
    /// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    public ToolStripButton(ResourceHandle image)
      : base((string) null, image, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text and image.</summary>
    /// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    public ToolStripButton(string text, ResourceHandle image)
      : base(text, image, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text and image and that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</summary>
    /// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param>
    /// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    public ToolStripButton(string text, ResourceHandle image, EventHandler onClick)
      : base(text, image, onClick)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class with the specified name that displays the specified text and image and that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</summary>
    /// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    /// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    /// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
    public ToolStripButton(string text, ResourceHandle image, EventHandler onClick, string name)
      : base(text, image, onClick, (string) null)
    {
    }

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fit.
    /// </summary>
    /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
    /// </returns>
    /// <PermissionSet>
    /// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    /// <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public override Size GetPreferredSize(Size objConstrainingSize)
    {
      Size preferredSizeByImage = this.GetPreferredSizeByImage(this.GetPreferredeSizeByText());
      return this.GetPreferredSizeByButtonSkin(SkinFactory.GetSkin((ISkinable) this) as ButtonSkin, preferredSizeByImage);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripButton.CheckedChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnCheckedChanged(EventArgs e)
    {
      EventHandler checkedChangedHandler = this.CheckedChangedHandler;
      if (checkedChangedHandler == null)
        return;
      checkedChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripButton.CheckStateChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnCheckStateChanged(EventArgs e)
    {
      EventHandler stateChangedHandler = this.CheckStateChangedHandler;
      if (stateChangedHandler == null)
        return;
      stateChangedHandler((object) this, e);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (!(objEvent.Type == "CheckedChange"))
        return;
      bool result = false;
      if (!bool.TryParse(objEvent["C"], out result))
        return;
      this.Checked = result;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.CheckedChangedHandler != null)
        criticalEventsData.Set("CC");
      return criticalEventsData;
    }

    /// <summary>Renders the tool strip item's attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    protected override void RenderToolStripItemAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter)
    {
      base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
      this.RenderToolStripItemTextAttribute(objAttributeWriter, false);
      this.RenderToolStripItemCheckedAttribute(objAttributeWriter, false);
      this.RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, false);
    }

    /// <summary>
    /// Renders the tool strip item checked on click attribute.
    /// </summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderToolStripItemCheckedOnClickAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      if (!(this.mblnCheckOnClick | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("COC", this.mblnCheckOnClick ? "1" : "0");
    }

    /// <summary>Renders the tool strip item updated attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected override void RenderToolStripItemUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      long lngRequestID)
    {
      base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderToolStripItemTextAttribute(objAttributeWriter, true);
      this.RenderToolStripItemCheckedAttribute(objAttributeWriter, true);
      this.RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, true);
    }

    /// <summary>Renders the tool strip item text attribute.</summary>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderToolStripItemTextAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      if (!this.ShouldRenderText)
        return;
      string text = this.Text;
      if (!(!string.IsNullOrEmpty(text) | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("TX", text);
    }

    /// <summary>Renders the tool strip item checked attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderToolStripItemCheckedAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      bool flag = this.Checked;
      if (!(flag | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("C", flag ? "1" : "0");
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripButton.Checked"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler CheckedChanged
    {
      add => this.AddCriticalHandler(ToolStripButton.CheckedChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripButton.CheckedChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the CheckedChanged handler.</summary>
    /// <value>The available changed handler.</value>
    private EventHandler CheckedChangedHandler => (EventHandler) this.GetHandler(ToolStripButton.CheckedChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripButton.CheckState"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler CheckStateChanged
    {
      add => this.AddCriticalHandler(ToolStripButton.CheckStateChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripButton.CheckStateChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the CheckStateChanged handler.</summary>
    /// <value>The available changed handler.</value>
    private EventHandler CheckStateChangedHandler => (EventHandler) this.GetHandler(ToolStripButton.CheckStateChangedEvent);

    private CheckState menmCheckState
    {
      get => this.GetValue<CheckState>(ToolStripButton.menmCheckStateProperty);
      set => this.SetValue<CheckState>(ToolStripButton.menmCheckStateProperty, value);
    }

    private bool mblnCheckOnClick
    {
      get => this.GetValue<bool>(ToolStripButton.mblnCheckOnClickProperty);
      set => this.SetValue<bool>(ToolStripButton.mblnCheckOnClickProperty, value);
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 0;

    /// <summary>Gets or sets a value indicating whether default or custom <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>. </summary>
    /// <returns>true if default <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    public new bool AutoToolTip
    {
      get => base.AutoToolTip;
      set => base.AutoToolTip = value;
    }

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> can be selected.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> can be selected; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public override bool CanSelect => true;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is pressed or not pressed.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is pressed in or not pressed in; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripButtonCheckedDescr")]
    [DefaultValue(false)]
    public bool Checked
    {
      get => this.menmCheckState != 0;
      set
      {
        if (value == this.Checked)
          return;
        this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> should automatically appear pressed in and not pressed in when clicked.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> should automatically appear pressed in and not pressed in when clicked; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("ToolStripButtonCheckOnClickDescr")]
    [DefaultValue(false)]
    public bool CheckOnClick
    {
      get => this.mblnCheckOnClick;
      set
      {
        if (this.mblnCheckOnClick == value)
          return;
        this.mblnCheckOnClick = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is in the pressed or not pressed state by default, or is in an indeterminate state.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. The default is Unchecked.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("CheckBoxCheckStateDescr")]
    [DefaultValue(CheckState.Unchecked)]
    [SRCategory("CatAppearance")]
    public CheckState CheckState
    {
      get => this.menmCheckState;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (CheckState));
        if (value == this.menmCheckState)
          return;
        this.menmCheckState = value;
        this.Invalidate();
        this.OnCheckedChanged(EventArgs.Empty);
        this.OnCheckStateChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets a value indicating whether to display the ToolTip that is defined as the default. </summary>
    /// <returns>true in all cases.</returns>
    protected override bool DefaultAutoToolTip => true;
  }
}
