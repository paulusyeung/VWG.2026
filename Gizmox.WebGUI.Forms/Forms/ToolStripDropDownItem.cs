// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripDropDownItem
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides basic functionality for controls that display a <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> when a <see cref="T:System.Windows.Forms.ToolStripDropDownButton"></see>, <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>, or <see cref="T:System.Windows.Forms.ToolStripSplitButton"></see> control is clicked.</summary>
  [DefaultProperty("DropDownItems")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public abstract class ToolStripDropDownItem : ToolStripItem
  {
    private static readonly SerializableProperty mobjDropDownProperty = SerializableProperty.Register(nameof (mobjDropDown), typeof (ToolStripDropDown), typeof (ToolStripDropDownItem));
    private static readonly SerializableEvent DropDownOpenedEvent = SerializableEvent.Register("DropDownOpened", typeof (EventHandler), typeof (ToolStripDropDownItem));
    private static readonly SerializableEvent DropDownOpeningEvent = SerializableEvent.Register("DropDownOpening", typeof (EventHandler), typeof (ToolStripDropDownItem));
    private static readonly SerializableEvent DropDownItemClickedEvent = SerializableEvent.Register("DropDownItemClicked", typeof (ToolStripItemClickedEventHandler), typeof (ToolStripDropDownItem));
    private static readonly SerializableEvent DropDownClosedEvent = SerializableEvent.Register("DropDownClosed", typeof (EventHandler), typeof (ToolStripDropDownItem));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class. </summary>
    protected ToolStripDropDownItem()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, and action to take when the drop-down control is clicked.</summary>
    /// <param name="onClick">The action to take when the drop-down control is clicked.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param>
    /// <param name="text">The display text of the drop-down control.</param>
    protected ToolStripDropDownItem(string text, ResourceHandle image, EventHandler onClick)
      : base(text, image, onClick)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, action to take when the drop-down control is clicked, and control name.</summary>
    /// <param name="onClick">The action to take when the drop-down control is clicked.</param>
    /// <param name="name">The name of the control.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param>
    /// <param name="text">The display text of the drop-down control.</param>
    protected ToolStripDropDownItem(
      string text,
      ResourceHandle image,
      EventHandler onClick,
      string name)
      : base(text, image, onClick, (string) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, and <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection that the drop-down control contains.</summary>
    /// <param name="dropDownItems">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection that the drop-down control contains.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param>
    /// <param name="text">The display text of the drop-down control.</param>
    protected ToolStripDropDownItem(
      string text,
      ResourceHandle image,
      ToolStripItem[] dropDownItems)
      : this(text, image, (EventHandler) null)
    {
      if (dropDownItems == null)
        return;
      this.DropDownItems.AddRange(dropDownItems);
    }

    /// <summary>Pres the render tool strip item.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal override void PreRenderToolStripItem(IContext objContext, long lngRequestID)
    {
      base.PreRenderToolStripItem(objContext, lngRequestID);
      this.DropDown.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Posts the render tool strip item.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal override void PostRenderToolStripItem(IContext objContext, long lngRequestID)
    {
      base.PostRenderToolStripItem(objContext, lngRequestID);
      this.DropDown.PostRenderControl(objContext, lngRequestID);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      if (this.mobjDropDown == null)
        return;
      this.UnRegisterBatch((ICollection) this.mobjDropDown.Items);
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      if (this.mobjDropDown == null)
        return;
      this.RegisterBatch((ICollection) this.mobjDropDown.Items);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources
    /// </summary>
    /// <param name="blnDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected override void Dispose(bool blnDisposing)
    {
      if (this.mobjDropDown != null)
      {
        this.mobjDropDown.Opened -= new EventHandler(this.DropDown_Opened);
        this.mobjDropDown.Closed -= new ToolStripDropDownClosedEventHandler(this.DropDown_Closed);
        this.mobjDropDown.ItemClicked -= new ToolStripItemClickedEventHandler(this.DropDown_ItemClicked);
        if (blnDisposing && this.mobjDropDown.IsAutoGenerated)
        {
          this.mobjDropDown.Dispose();
          this.mobjDropDown = (ToolStripDropDown) null;
        }
      }
      base.Dispose(blnDisposing);
    }

    private void DropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e) => this.OnDropDownClosed(EventArgs.Empty);

    private void DropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e) => this.OnDropDownItemClicked(e);

    private void DropDown_Opened(object sender, EventArgs e) => this.OnDropDownOpened(EventArgs.Empty);

    /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownOpened"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected internal virtual void OnDropDownOpened(EventArgs e)
    {
      if (this.DropDown.OwnerItem != this)
        return;
      EventHandler downOpenedHandler = this.DropDownOpenedHandler;
      if (downOpenedHandler == null)
        return;
      downOpenedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownClosed"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected internal virtual void OnDropDownClosed(EventArgs e)
    {
      this.Invalidate();
      if (this.DropDown.OwnerItem != this)
        return;
      EventHandler downClosedHandler = this.DropDownClosedHandler;
      if (downClosedHandler != null)
        downClosedHandler((object) this, e);
      if (this.DropDown.IsAutoGenerated)
        return;
      this.DropDown.OwnerItem = (ToolStripItem) null;
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs"></see> that contains the event data.</param>
    protected internal virtual void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
    {
      if (this.DropDown.OwnerItem != this)
        return;
      ToolStripItemClickedEventHandler itemClickedHandler = this.DropDownItemClickedHandler;
      if (itemClickedHandler == null)
        return;
      itemClickedHandler((object) this, e);
    }

    /// <summary>Creates a generic <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> for which events can be defined.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
    protected virtual ToolStripDropDown CreateDefaultDropDown() => new ToolStripDropDown((ToolStripItem) this, true);

    /// <summary>Makes a visible <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> hidden.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void HideDropDown() => this.OnDropDownHide(EventArgs.Empty);

    /// <summary>Raised in response to the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDownItem.HideDropDown"></see> method.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnDropDownHide(EventArgs e)
    {
    }

    /// <summary>Raised in response to the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDownItem.ShowDropDown"></see> method.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnDropDownShow(EventArgs e)
    {
      EventHandler downOpeningHandler = this.DropDownOpeningHandler;
      if (downOpeningHandler == null)
        return;
      downOpeningHandler((object) this, e);
    }

    /// <summary>Displays the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> control associated with this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</summary>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> is the same as the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void ShowDropDown()
    {
      if (this.mobjDropDown == null)
        this.OnDropDownShow(EventArgs.Empty);
      if (this.mobjDropDown == null || this.mobjDropDown.IsAutoGenerated && this.DropDownItems.Count <= 0)
        return;
      if (this.DropDown == this.ParentInternal)
        throw new InvalidOperationException(SR.GetString("ToolStripShowDropDownInvalidOperation"));
      this.mobjDropDown.ShowDropDown(this);
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
    {
      if (!(strOffspringTypeName == "Gizmox.WebGUI.Forms.ToolStripDropDown"))
        return base.GetComponentOffsprings(strOffspringTypeName);
      return (IList) new List<ToolStripDropDown>()
      {
        this.DropDown
      };
    }

    /// <summary>Renders the tool strip item's text attribute.</summary>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected virtual void RenderToolStripDropDownItemTextAttribute(
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

    /// <summary>Renders the tool strip item's attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    protected override void RenderToolStripItemAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter)
    {
      base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
      this.RenderToolStripDropDownItemDropDownAttribute(objAttributeWriter);
      this.RenderToolStripDropDownItemTextAttribute(objAttributeWriter, false);
    }

    /// <summary>Renders the tool strip item's drop down attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    protected virtual void RenderToolStripDropDownItemDropDownAttribute(
      IAttributeWriter objAttributeWriter)
    {
      objAttributeWriter.WriteAttributeText("DD", "1");
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
      this.RenderToolStripDropDownItemTextAttribute(objAttributeWriter, true);
    }

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> closes. </summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler DropDownClosed
    {
      add
      {
        if (!this.HasHandler(ToolStripDropDownItem.DropDownClosedEvent) && this.mobjDropDown != null)
          this.mobjDropDown.Closed += new ToolStripDropDownClosedEventHandler(this.DropDown_Closed);
        this.AddCriticalHandler(ToolStripDropDownItem.DropDownClosedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownClosedEvent, (Delegate) value);
        if (this.HasHandler(ToolStripDropDownItem.DropDownClosedEvent) || this.mobjDropDown == null)
          return;
        this.mobjDropDown.Closed -= new ToolStripDropDownClosedEventHandler(this.DropDown_Closed);
      }
    }

    /// <summary>Gets the DropDownClosed handler.</summary>
    /// <value>The DropDownClosed handler.</value>
    private EventHandler DropDownClosedHandler => (EventHandler) this.GetHandler(ToolStripDropDownItem.DropDownClosedEvent);

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is clicked.</summary>
    /// <filterpriority>1</filterpriority>
    public event ToolStripItemClickedEventHandler DropDownItemClicked
    {
      add
      {
        if (!this.HasHandler(ToolStripDropDownItem.DropDownItemClickedEvent) && this.mobjDropDown != null)
          this.mobjDropDown.ItemClicked += new ToolStripItemClickedEventHandler(this.DropDown_ItemClicked);
        this.AddCriticalHandler(ToolStripDropDownItem.DropDownItemClickedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownItemClickedEvent, (Delegate) value);
        if (this.HasHandler(ToolStripDropDownItem.DropDownItemClickedEvent) || this.mobjDropDown == null)
          return;
        this.mobjDropDown.ItemClicked -= new ToolStripItemClickedEventHandler(this.DropDown_ItemClicked);
      }
    }

    /// <summary>Gets the DropDownItemClicked handler.</summary>
    /// <value>The DropDownItemClicked handler.</value>
    private ToolStripItemClickedEventHandler DropDownItemClickedHandler => (ToolStripItemClickedEventHandler) this.GetHandler(ToolStripDropDownItem.DropDownItemClickedEvent);

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has opened.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler DropDownOpened
    {
      add
      {
        if (!this.HasHandler(ToolStripDropDownItem.DropDownOpenedEvent) && this.mobjDropDown != null)
          this.mobjDropDown.Opened += new EventHandler(this.DropDown_Opened);
        this.AddCriticalHandler(ToolStripDropDownItem.DropDownOpenedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownOpenedEvent, (Delegate) value);
        if (this.HasHandler(ToolStripDropDownItem.DropDownOpenedEvent) || this.mobjDropDown == null)
          return;
        this.mobjDropDown.Opened -= new EventHandler(this.DropDown_Opened);
      }
    }

    /// <summary>Gets the DropDownOpened handler.</summary>
    /// <value>The DropDownOpened handler.</value>
    private EventHandler DropDownOpenedHandler => (EventHandler) this.GetHandler(ToolStripDropDownItem.DropDownOpenedEvent);

    /// <summary>Occurs as the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is opening.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler DropDownOpening
    {
      add => this.AddCriticalHandler(ToolStripDropDownItem.DropDownOpeningEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripDropDownItem.DropDownOpeningEvent, (Delegate) value);
    }

    /// <summary>Gets the DropDownOpening handler.</summary>
    /// <value>The DropDownOpening handler.</value>
    private EventHandler DropDownOpeningHandler => (EventHandler) this.GetHandler(ToolStripDropDownItem.DropDownOpeningEvent);

    private ToolStripDropDown mobjDropDown
    {
      get => this.GetValue<ToolStripDropDown>(ToolStripDropDownItem.mobjDropDownProperty);
      set => this.SetValue<ToolStripDropDown>(ToolStripDropDownItem.mobjDropDownProperty, value);
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that will be displayed when this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> is clicked.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that is associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [TypeConverter(typeof (ReferenceConverter))]
    [SRCategory("CatData")]
    [SRDescription("ToolStripDropDownDescr")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripDropDown DropDown
    {
      get
      {
        if (this.mobjDropDown == null)
        {
          this.DropDown = this.CreateDefaultDropDown();
          if (!(this is ToolStripOverflowButton))
            this.mobjDropDown.SetAutoGeneratedInternal(true);
        }
        return this.mobjDropDown;
      }
      set
      {
        if (this.mobjDropDown == value)
          return;
        this.mobjDropDown = value;
      }
    }

    /// <summary>Gets or sets a value indicating the direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> emerges from its parent container.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property is set to a value that is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatBehavior")]
    [Browsable(false)]
    [SRDescription("ToolStripDropDownItemDropDownDirectionDescr")]
    public ToolStripDropDownDirection DropDownDirection
    {
      get => ToolStripDropDownDirection.Default;
      set
      {
      }
    }

    /// <summary>Gets the collection of items in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that is associated with this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see> of controls.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatData")]
    [SRDescription("ToolStripDropDownItemsDescr")]
    [Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public ToolStripItemCollection DropDownItems => this.DropDown.Items;

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> has <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> controls associated with it. </summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> has <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> controls; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual bool HasDropDownItems => this.mobjDropDown != null && this.mobjDropDown.Items.Count > 0;
  }
}
