// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Manages a related set of tab pages.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (TabControl), "TabControl_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DefaultProperty("TabPages")]
  [SRDescription("DescriptionTabControl")]
  [DefaultEvent("SelectedIndexChanged")]
  [ToolboxItemCategory("Containers")]
  [Gizmox.WebGUI.Forms.MetadataTag("TC")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TabControlSkin))]
  [ProxyComponent(typeof (ProxyTabControl))]
  [Serializable]
  public class TabControl : Control, ISupportInitialize, INavigationControl
  {
    /// <summary>Provides a property reference to Multiline property.</summary>
    private static SerializableProperty MultilineProperty = SerializableProperty.Register(nameof (Multiline), typeof (bool), typeof (TabControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to SelectOnRightClick property.
    /// </summary>
    private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register(nameof (SelectOnRightClick), typeof (bool), typeof (TabControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to TabAppearance property.
    /// </summary>
    private static SerializableProperty TabAppearanceProperty = SerializableProperty.Register("TabAppearance", typeof (TabAppearance), typeof (TabControl), new SerializablePropertyMetadata((object) TabAppearance.Normal));
    /// <summary>
    /// Provides a property reference to SelectedIndex property.
    /// </summary>
    private static SerializableProperty SelectedIndexProperty = SerializableProperty.Register(nameof (SelectedIndex), typeof (int), typeof (TabControl), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to ClientBehavior property.
    /// </summary>
    private static SerializableProperty ClientBehaviorProperty = SerializableProperty.Register(nameof (ClientBehavior), typeof (TabControlClientBehavior), typeof (TabControl), new SerializablePropertyMetadata((object) TabControlClientBehavior.MemoryOptimized));
    /// <summary>
    /// Provides a property reference to ShowCloseButton property.
    /// </summary>
    private static SerializableProperty ShowCloseButtonProperty = SerializableProperty.Register(nameof (ShowCloseButton), typeof (bool), typeof (TabControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to ShowExpandButton property.
    /// </summary>
    private static SerializableProperty ShowExpandButtonProperty = SerializableProperty.Register(nameof (ShowExpandButton), typeof (bool), typeof (TabControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to IsExpandedProperty property.
    /// </summary>
    private static SerializableProperty IsExpandedProperty = SerializableProperty.Register(nameof (IsExpandedProperty), typeof (bool), typeof (TabControl), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to ImageList property.</summary>
    private static SerializableProperty ImageListProperty = SerializableProperty.Register(nameof (ImageList), typeof (ImageList), typeof (TabControl), new SerializablePropertyMetadata((object) null));
    /// <summary>The menmAlignment property registration.</summary>
    private static readonly SerializableProperty AlignmentProperty = SerializableProperty.Register("menmAlignment", typeof (TabAlignment), typeof (TabControl), new SerializablePropertyMetadata((object) TabAlignment.Top));
    /// <summary>The ItemSize property registration.</summary>
    private static SerializableProperty ItemSizeProperty = SerializableProperty.Register(nameof (ItemSize), typeof (Size), typeof (TabControl));
    /// <summary>
    /// Provides a property reference to IsExpanding property.
    /// </summary>
    private static SerializableProperty IsExpandingProperty = SerializableProperty.Register(nameof (IsExpandingProperty), typeof (bool), typeof (TabControl), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to HeaderHeight property.
    /// </summary>
    private static SerializableProperty HeaderHeightProperty = SerializableProperty.Register(nameof (HeaderHeightProperty), typeof (int), typeof (TabControl), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to RestoredHeight property.
    /// </summary>
    private static SerializableProperty RestoredHeightProperty = SerializableProperty.Register(nameof (RestoredHeightProperty), typeof (int), typeof (TabControl), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to HeadersOffset property.
    /// </summary>
    private static SerializableProperty HeadersOffsetProperty = SerializableProperty.Register(nameof (HeadersOffsetProperty), typeof (int), typeof (TabControl), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to ContextualTabGroupCollection property.
    /// </summary>
    private static SerializableProperty ContextualTabGroupCollectionProperty = SerializableProperty.Register(nameof (ContextualTabGroupCollectionProperty), typeof (ContextualTabGroupCollection), typeof (TabControl), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to MaxTabPageHeaders property.
    /// </summary>
    private static SerializableProperty MaxTabPageHeadersProperty = SerializableProperty.Register(nameof (MaxTabPageHeadersProperty), typeof (int), typeof (TabControl), new SerializablePropertyMetadata((object) 0));
    /// <summary>The CloseClick event registration.</summary>
    private static readonly SerializableEvent CloseClickEvent = SerializableEvent.Register("CloseClick", typeof (EventHandler), typeof (TabControl));
    /// <summary>The SelectedIndexChanged event registration.</summary>
    private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof (EventHandler), typeof (TabControl));
    /// <summary>The SelectedIndexChanging event registration.</summary>
    private static readonly SerializableEvent SelectedIndexChangingEvent = SerializableEvent.Register("SelectedIndexChanging", typeof (TabControlCancelEventHandler), typeof (TabControl));
    /// <summary>The control tabs collection</summary>
    private TabPageCollection mobjTabs;
    /// <summary>The Collapse event registration.</summary>
    private static readonly SerializableEvent CollapseEvent = SerializableEvent.Register("Collapse", typeof (EventHandler), typeof (TabControl));
    /// <summary>The Expand event registration.</summary>
    private static readonly SerializableEvent ExpandEvent = SerializableEvent.Register("Expand", typeof (EventHandler), typeof (TabControl));

    /// <summary>Gets the tab control current skin.</summary>
    /// <value>The tab control current skin.</value>
    internal TabControlSkin TabControlCurrentSkin => (TabControlSkin) this.Skin;

    /// <summary>
    /// Occurs when the user clicks the tab control close button
    /// </summary>
    public virtual event EventHandler CloseClick
    {
      add => this.AddHandler(TabControl.CloseClickEvent, (Delegate) value);
      remove => this.RemoveHandler(TabControl.CloseClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the CloseClick event.</summary>
    private EventHandler CloseClickHandler => (EventHandler) this.GetHandler(TabControl.CloseClickEvent);

    /// <summary>Occurs when the SelectedIndex property is changed.</summary>
    [SRDescription("selectedIndexChangedEventDescr")]
    [SRCategory("CatBehavior")]
    public event EventHandler SelectedIndexChanged
    {
      add => this.AddCriticalHandler(TabControl.SelectedIndexChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TabControl.SelectedIndexChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the SelectedIndexChanged event.</summary>
    private EventHandler SelectedIndexChangedHandler => (EventHandler) this.GetHandler(TabControl.SelectedIndexChangedEvent);

    /// <summary>
    /// Occurs when the SelectedIndex property is about to change.
    /// </summary>
    public event TabControlCancelEventHandler SelectedIndexChanging
    {
      add => this.AddCriticalHandler(TabControl.SelectedIndexChangingEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TabControl.SelectedIndexChangingEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the SelectedIndexChanging event.</summary>
    private TabControlCancelEventHandler SelectedIndexChangingHandler => (TabControlCancelEventHandler) this.GetHandler(TabControl.SelectedIndexChangingEvent);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> class.
    /// </summary>
    public TabControl()
    {
      this.mobjTabs = this.CreateTabPageCollection();
      this.RestoredHeight = this.Height;
    }

    /// <summary>Renders the max tab page headers attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderMaxTabPageHeadersAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!blnForceRender && (!this.ContainsValue<int>(TabControl.MaxTabPageHeadersProperty) || this.Appearance != TabAppearance.Spread))
        return;
      objWriter.WriteAttributeText("MTH", this.MaxTabPageHeaders.ToString());
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderMaxTabPageHeadersAttribute(objWriter, false);
      if (this.Multiline)
        objWriter.WriteAttributeString("MLT", "1");
      objWriter.WriteAttributeString("TBL", this.GetTabLayoutId(this.GetProxyPropertyValue<TabAlignment>("Alignment", this.Alignment)));
      TabPage selectedItem = this.SelectedItem;
      if (selectedItem != null)
      {
        long num = selectedItem.ProxyComponent != null ? selectedItem.GetProxyPropertyValue<long>("ID", selectedItem.ID) : selectedItem.ID;
        objWriter.WriteAttributeString("SE", num.ToString());
      }
      this.RenderSelectOnRightClick(objWriter, false);
      this.RenderShowCloseButtonAttribute(objWriter, false);
      this.RenderShowExpandAttribute(objWriter, false);
      this.RenderExpandedAttribute(objWriter, false);
      this.RenderRestoredHeightAttribute(objWriter);
      this.RenderHeaderOffsetAttribute(objWriter, false);
      this.RenderAppearanceAttribute(objWriter, false);
    }

    /// <summary>Renders the appearance attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      TabAppearance proxyPropertyValue = this.GetProxyPropertyValue<TabAppearance>("Appearance", this.Appearance);
      if (!(proxyPropertyValue != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("AP", (int) proxyPropertyValue);
    }

    /// <summary>Renders the controls.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">writer.</param>
    /// <param name="lngRequestID">Request ID.</param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.IsDirty(lngRequestID))
        this.RenderContextualTabGroups(objContext, objWriter);
      foreach (TabPage tabPage in (IEnumerable) this.GetProxyPropertyValue<ICollection>("TabPages", (ICollection) this.TabPages))
      {
        if (tabPage.Visible)
        {
          if (this.ClientBehavior == TabControlClientBehavior.NoOptimizations)
            tabPage.InternalLoaded = true;
          else if (lngRequestID == 0L && !this.ShouldUseClientUpdateHandler)
            tabPage.InternalLoaded = false;
          ((IRenderableComponent) tabPage).RenderComponent(objContext, objWriter, lngRequestID);
        }
      }
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        TabPage selectedItem = this.SelectedItem;
        if (selectedItem != null)
        {
          long num = selectedItem.ProxyComponent != null ? selectedItem.GetProxyPropertyValue<long>("ID", selectedItem.ID) : selectedItem.ID;
          objWriter.WriteAttributeString("SE", num.ToString());
        }
        this.RenderSelectOnRightClick(objWriter, true);
        this.RenderShowCloseButtonAttribute(objWriter, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderShowExpandAttribute(objWriter, true);
      this.RenderMaxTabPageHeadersAttribute(objWriter, true);
      this.RenderExpandedAttribute(objWriter, true);
      this.RenderRestoredHeightAttribute(objWriter);
      this.RenderHeaderOffsetAttribute(objWriter, true);
      this.RenderAppearanceAttribute(objWriter, true);
    }

    /// <summary>Renders the select on right click.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.SelectOnRightClick)
      {
        objWriter.WriteAttributeString("SOR", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SOR", "0");
      }
    }

    /// <summary>Renders the restored height attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderRestoredHeightAttribute(IAttributeWriter objWriter)
    {
      if (this.IsExpanded && !this.ShowExpandButton)
        return;
      objWriter.WriteAttributeString("RH", this.RestoredHeight.ToString());
    }

    /// <summary>Renders the expanded attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderExpandedAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool isExpanded = this.IsExpanded;
      if (!(!isExpanded | blnForceRender))
        return;
      objWriter.WriteAttributeString("EX", isExpanded ? "1" : "0");
    }

    /// <summary>Renders the show expand button attribute.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowExpandAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool showExpandButton = this.ShowExpandButton;
      if (!(showExpandButton | blnForceRender))
        return;
      objWriter.WriteAttributeString("EIN", showExpandButton ? "1" : "0");
    }

    /// <summary>Renders the show expand button attribute.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowCloseButtonAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool showCloseButton = this.ShowCloseButton;
      if (!(showCloseButton | blnForceRender))
        return;
      objWriter.WriteAttributeString("SCB", showCloseButton ? "1" : "0");
    }

    /// <summary>Renders the header offset attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderHeaderOffsetAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      int headersOffset = this.HeadersOffset;
      if (!(headersOffset >= 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("HO", headersOffset.ToString());
    }

    /// <summary>Renders the contextual tab groups.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    private void RenderContextualTabGroups(IContext objContext, IResponseWriter objWriter)
    {
      ContextualTabGroupCollection tabGroupsInternal = this.ContextualTabGroupsInternal;
      if (tabGroupsInternal == null)
        return;
      int num = 0;
      foreach (ContextualTabGroup contextualTabGroup in tabGroupsInternal)
      {
        objWriter.WriteStartElement("G");
        objWriter.WriteAttributeText("IX", num.ToString());
        objWriter.WriteAttributeText("TX", contextualTabGroup.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
        objWriter.WriteEndElement();
        ++num;
      }
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new TabControlRenderer(this);

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      if (objValue is TabPage)
        this.TabPages.Add((TabPage) objValue);
      else
        base.AddChild(objValue);
    }

    /// <summary>Creates the tab page collection.</summary>
    /// <returns></returns>
    protected virtual TabPageCollection CreateTabPageCollection() => new TabPageCollection(this);

    /// <summary>
    /// This member overrides <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControlsInstance"></see>.
    /// </summary>
    /// <returns>A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> assigned to the control.</returns>
    protected override Control.ControlCollection CreateControlsInstance() => (Control.ControlCollection) new TabControl.ControlCollection(this);

    /// <summary>Gets the tab layout id.</summary>
    /// <param name="enmTabAlignment">The tab layout id.</param>
    /// <returns></returns>
    protected virtual int GetTabLayoutId(TabAlignment enmTabAlignment) => this.GetProxyPropertyValue<TabAppearance>("Appearance", this.Appearance) == TabAppearance.Logical ? -1 : (int) enmTabAlignment;

    /// <summary>
    /// Gets or Sets value indication if the close button (when Appearance==TabAppearance.Workspace)
    /// should be shown
    /// </summary>
    [DefaultValue(false)]
    public virtual bool ShowCloseButton
    {
      get => this.GetValue<bool>(TabControl.ShowCloseButtonProperty);
      set
      {
        if (!this.SetValue<bool>(TabControl.ShowCloseButtonProperty, value))
          return;
        this.UpdateParams(AttributeType.Control, false);
      }
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SelectedIndexChangedHandler != null || this.SelectedIndexChangingHandler != null)
        criticalEventsData.Set("VC");
      if (this.ExpandHandler != null)
        criticalEventsData.Set("EXP");
      if (this.CollapseHandler != null)
        criticalEventsData.Set("COL");
      return criticalEventsData;
    }

    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      if (this.HasClientHandler("Expand"))
      {
        clientEventsData.Set("EXP");
        clientEventsData.Set("COL");
      }
      return clientEventsData;
    }

    /// <summary>Occurs when [client close click].</summary>
    [SRDescription("Occurs when control's tab closed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientCloseClick
    {
      add => this.AddClientHandler("TabClose", value);
      remove => this.RemoveClientHandler("TabClose", value);
    }

    /// <summary>Occurs when [client expand].</summary>
    [SRDescription("Occurs when control's tab expanded in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientExpandedChanged
    {
      add => this.AddClientHandler("Expand", value);
      remove => this.RemoveClientHandler("Expand", value);
    }

    /// <summary>Occurs when [client selected index changing].</summary>
    [SRDescription("Occurs when control's selected index changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectedIndexChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Called when [collapse].</summary>
    protected virtual void OnCollapse(bool blnClientSource)
    {
      if (this.CollapseHandler == null)
        return;
      this.CollapseHandler((object) this, EventArgs.Empty);
    }

    /// <summary>Called when [expand].</summary>
    protected virtual void OnExpand(bool blnClientSource)
    {
      if (this.ExpandHandler == null)
        return;
      this.ExpandHandler((object) this, EventArgs.Empty);
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
    public override bool SetBounds(
      int intLeft,
      int intTop,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified,
      bool blnIsClientSource)
    {
      if (!this.DesignMode && (enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None && !this.IsExpanding)
      {
        if (!this.IsExpanded)
          enmSpecified &= ~BoundsSpecified.Height;
        this.RestoredHeight = intHeight;
      }
      return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
    }

    /// <summary>Sets the IsExpanded.</summary>
    /// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private bool SetIsExpanded(bool blnIsExpanded, bool blnClientSource)
    {
      bool showExpandButton = this.ShowExpandButton;
      this.ValidateExpandAndMultiLine(blnIsExpanded, this.Multiline, showExpandButton);
      this.ValidateExpandAndDock(blnIsExpanded, this.Dock, showExpandButton);
      int num = this.SetValue<bool>(TabControl.IsExpandedProperty, blnIsExpanded) ? 1 : 0;
      if (num != 0 && !this.DesignMode && !this.IsLayoutSuspended)
      {
        this.ApplyHeight(blnClientSource);
        if (!blnClientSource)
          this.UpdateParams(AttributeType.Layout | AttributeType.Visual, false);
      }
      if ((num | (blnClientSource ? 1 : 0)) == 0)
        return num != 0;
      if (blnIsExpanded)
      {
        this.OnExpand(blnClientSource);
        return num != 0;
      }
      this.OnCollapse(blnClientSource);
      return num != 0;
    }

    /// <summary>Applies the height.</summary>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    private void ApplyHeight(bool blnClientSource)
    {
      if (!blnClientSource)
        this.UpdateParams(AttributeType.Visual);
      this.IsExpanding = true;
      if (this.SetBounds(0, 0, 0, this.IsExpanded ? this.RestoredHeight : this.SkinHeaderHeight, BoundsSpecified.Height, blnClientSource))
        this.InvalidateParentLayout(new LayoutEventArgs(false, true, true));
      this.IsExpanding = false;
    }

    /// <summary>Validates the expand and multi line.</summary>
    /// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
    /// <param name="blnMultiline">if set to <c>true</c> [BLN multiline].</param>
    /// <param name="blnShowExpandButton">if set to <c>true</c> [BLN show expand button].</param>
    private void ValidateExpandAndMultiLine(
      bool blnIsExpanded,
      bool blnMultiline,
      bool blnShowExpandButton)
    {
      if ((!blnIsExpanded | blnShowExpandButton) & blnMultiline)
        throw new NotSupportedException();
    }

    /// <summary>Validates the expand and dock.</summary>
    /// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
    /// <param name="enmDockStyle">The enm dock style.</param>
    /// <param name="blnShowExpandButton">if set to <c>true</c> [BLN show expand button].</param>
    internal virtual void ValidateExpandAndDock(
      bool blnIsExpanded,
      DockStyle enmDockStyle,
      bool blnShowExpandButton)
    {
      if (!blnIsExpanded | blnShowExpandButton && (enmDockStyle == DockStyle.Fill || enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right))
        throw new NotSupportedException(SR.GetString("TabControlValidateExpandAndDock", (object) enmDockStyle));
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "TabClose":
          if (this.Controls.Count <= 0 || this.CloseClickHandler == null)
            break;
          this.CloseClickHandler((object) this, new EventArgs());
          break;
        case "ValueChange":
          long lngComponentId = long.Parse(objEvent["Value"]);
          if (!(this.Context is ISessionRegistry context))
            break;
          IRegisteredComponent registeredComponent = context.GetRegisteredComponent(lngComponentId);
          TabPage objTabPage = !(registeredComponent is ProxyComponent proxyComponent) ? registeredComponent as TabPage : proxyComponent.SourceComponent as TabPage;
          if (objTabPage == null || objTabPage.TabControl != this)
            break;
          this.ChangeSelectedTab(objTabPage);
          break;
        case "Expand":
          bool result = false;
          if (!bool.TryParse(objEvent["EX"], out result))
            break;
          this.SetIsExpanded(result, true);
          break;
        default:
          base.FireEvent(objEvent);
          break;
      }
    }

    /// <summary>Changes the selected tab.</summary>
    /// <param name="objTabPage">tab page.</param>
    internal void ChangeSelectedTab(TabPage objTabPage)
    {
      if (objTabPage == null)
        return;
      int num = this.TabPages.IndexOf(objTabPage);
      if (this.SelectedIndex != num)
      {
        this.SelectedIndex = num;
        if (this.SelectedIndex != num)
          return;
        if (!objTabPage.Loaded)
          this.SelectedItem.Update();
        this.UpdateParams(AttributeType.Control);
      }
      else
        this.UpdateParams(AttributeType.Redraw);
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.TabControl.SelectedIndexChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnSelectedIndexChanged(EventArgs e)
    {
      EventHandler indexChangedHandler = this.SelectedIndexChangedHandler;
      if (indexChangedHandler == null)
        return;
      indexChangedHandler((object) this, e);
    }

    /// <summary>
    /// Provides controls with the ability to handle size changed
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    /// <param name="objNewSize">The control new size.</param>
    /// <param name="objOldSize">The control old size.</param>
    internal override void OnLayoutInternal(LayoutEventArgs e, Size objNewSize, Size objOldSize)
    {
      base.OnLayoutInternal(e, objNewSize, objOldSize);
      int num1 = objNewSize.Width - objOldSize.Width;
      int num2 = objNewSize.Height - objOldSize.Height;
      foreach (TabPage tabPage in this.TabPages)
      {
        int dock = (int) tabPage.Dock;
        if (num1 != 0 || num2 != 0)
          tabPage.OnResizeInternal(e.Clone(false, false));
      }
    }

    /// <summary>Gets the hanlder for the Collapse event.</summary>
    private EventHandler CollapseHandler => (EventHandler) this.GetHandler(TabControl.CollapseEvent);

    /// <summary>Occurs when [Collapseed].</summary>
    public event EventHandler Collapse
    {
      add => this.AddCriticalHandler(TabControl.CollapseEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TabControl.CollapseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Expand event.</summary>
    private EventHandler ExpandHandler => (EventHandler) this.GetHandler(TabControl.ExpandEvent);

    /// <summary>Occurs when [expanded].</summary>
    public event EventHandler Expand
    {
      add => this.AddCriticalHandler(TabControl.ExpandEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TabControl.ExpandEvent, (Delegate) value);
    }

    /// <summary>Gets or sets the select on right click.</summary>
    /// <value>The select on right click.</value>
    [SRCategory("CatAppearance")]
    [SRDescription("SelectOnRightClickDescr")]
    [DefaultValue(false)]
    public bool SelectOnRightClick
    {
      get => this.GetValue<bool>(TabControl.SelectOnRightClickProperty);
      set
      {
        if (!this.SetValue<bool>(TabControl.SelectOnRightClickProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is expanding.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is expanding; otherwise, <c>false</c>.
    /// </value>
    private bool IsExpanding
    {
      get => this.GetValue<bool>(TabControl.IsExpandingProperty);
      set => this.SetValue<bool>(TabControl.IsExpandingProperty, value);
    }

    /// <summary>Gets or sets the height of the header.</summary>
    /// <value>The height of the header.</value>
    private int HeaderHeight
    {
      get => this.GetValue<int>(TabControl.HeaderHeightProperty);
      set => this.SetValue<int>(TabControl.HeaderHeightProperty, value);
    }

    /// <summary>Gets or sets the height of the restored.</summary>
    /// <value>The height of the restored.</value>
    internal int RestoredHeight
    {
      get => this.GetValue<int>(TabControl.RestoredHeightProperty);
      set
      {
        if (!this.SetValue<int>(TabControl.RestoredHeightProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
    /// </summary>
    /// <value></value>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets or sets the client drawing mode behavior</summary>
    [DefaultValue(TabControlClientBehavior.MemoryOptimized)]
    public virtual TabControlClientBehavior ClientBehavior
    {
      get => this.Context is IContextParams && (this.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient) ? TabControlClientBehavior.NoOptimizations : this.GetValue<TabControlClientBehavior>(TabControl.ClientBehaviorProperty);
      set
      {
        if (!this.SetValue<TabControlClientBehavior>(TabControl.ClientBehaviorProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets the collection of tab pages in this tab control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects in this <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.</returns>
    [SRCategory("CatBehavior")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [MergableProperty(false)]
    [SRDescription("TabControlTabsDescr")]
    public TabPageCollection TabPages => this.mobjTabs;

    /// <summary>Gets the control contained area offset.</summary>
    protected override PaddingValue ContainedAreaOffset
    {
      get
      {
        if (this.Appearance != TabAppearance.Normal && this.Appearance != TabAppearance.Workspace || !(SkinFactory.GetSkin((ISkinable) this) is TabControlSkin skin))
          return base.ContainedAreaOffset;
        Padding padding = new Padding();
        padding.Bottom = skin.BottomFrameHeight;
        padding.Top = skin.TopFrameHeight;
        padding.Left = skin.LeftFrameWidth;
        padding.Right = skin.RightFrameWidth;
        int skinHeaderHeight = this.SkinHeaderHeight;
        switch (this.Alignment)
        {
          case TabAlignment.Top:
            padding.Top += skinHeaderHeight;
            break;
          case TabAlignment.Bottom:
            padding.Bottom += skinHeaderHeight;
            break;
          case TabAlignment.Left:
            padding.Left += skinHeaderHeight;
            break;
          case TabAlignment.Right:
            padding.Right += skinHeaderHeight;
            break;
        }
        return new PaddingValue(padding + (Padding) base.ContainedAreaOffset);
      }
    }

    /// <summary>
    /// Gets or sets the index of the currently selected tab page.
    /// </summary>
    /// <returns>The zero-based index of the currently selected tab page. The default is -1, which is also the value if no tab page is selected.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than -1. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [SRDescription("selectedIndexDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(-1)]
    public int SelectedIndex
    {
      get
      {
        int objValue = this.GetValue<int>(TabControl.SelectedIndexProperty);
        TabPageCollection tabPages = this.TabPages;
        if (objValue == -1 && tabPages != null && tabPages.Count > 0)
        {
          objValue = 0;
          this.SetValue<int>(TabControl.SelectedIndexProperty, objValue);
        }
        return objValue;
      }
      set
      {
        if (value < -1)
          throw new ArgumentOutOfRangeException(nameof (SelectedIndex), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (SelectedIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) -1.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (value < -1 || value >= this.TabPages.Count || this.SelectedIndex == value)
          return;
        if (this.SelectedIndexChangingHandler != null)
        {
          TabControlCancelEventArgs e = value == -1 || this.TabPages.Count == 0 ? new TabControlCancelEventArgs((TabPage) null, false) : new TabControlCancelEventArgs(this.TabPages[value], false);
          this.SelectedIndexChangingHandler((object) this, e);
          if (e.Cancel)
          {
            this.UpdateParams(AttributeType.Control);
            return;
          }
        }
        if (!this.SetValue<int>(TabControl.SelectedIndexProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
        if (this.SelectedItem != null && !this.SelectedItem.Loaded)
          this.SelectedItem.Update();
        this.FireObservableItemPropertyChanged(nameof (SelectedIndex));
        this.OnSelectedIndexChanged(new EventArgs());
      }
    }

    /// <summary>Gets the update handler.</summary>
    /// <value>The update handler.</value>
    protected override string ClientUpdateHandler => this.ClientBehavior != TabControlClientBehavior.DrawingOptimized ? string.Empty : "TabControl_UpdateHandler";

    /// <summary>Gets or sets the image list.</summary>
    /// <value>The image list.</value>
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("TabBaseImageListDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    public ImageList ImageList
    {
      get => this.GetValue<ImageList>(TabControl.ImageListProperty);
      set
      {
        if (!this.SetValue<ImageList>(TabControl.ImageListProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets the selected item.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TabPage SelectedItem
    {
      get
      {
        TabPageCollection tabPages = this.TabPages;
        return this.SelectedIndex > -1 && this.SelectedIndex < tabPages.Count ? tabPages[this.SelectedIndex] : (TabPage) null;
      }
      set
      {
        if (value == null)
          return;
        this.SelectedIndex = this.TabPages.IndexOf(value);
      }
    }

    /// <summary>
    /// Gets or sets the area of the control (for example, along the top) where the tabs are aligned.
    /// </summary>
    /// <returns>
    /// One of the <see cref="T:Gizmox.WebGUI.Forms.TabAlignment"></see> values. The default is Top.
    /// </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
    /// The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAlignment"></see> value.
    /// </exception>
    [DefaultValue(0)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("TabBaseAlignmentDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [ProxyBrowsable(true)]
    public virtual TabAlignment Alignment
    {
      get => this.GetValue<TabAlignment>(TabControl.AlignmentProperty);
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (TabAlignment));
        if (value == TabAlignment.Left || value == TabAlignment.Right)
          throw new NotSupportedException("Tab alignment left and right are currently unsupported.");
        if (!this.SetValue<TabAlignment>(TabControl.AlignmentProperty, value))
          return;
        if (value == TabAlignment.Left || value == TabAlignment.Right)
          this.Multiline = true;
        this.Update();
      }
    }

    /// <summary>Gets the default alignment.</summary>
    /// <value>The default alignment.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual TabAlignment DefaultAlignment => TabAlignment.Top;

    /// <summary>
    /// Gets or sets the visual appearance of the control's tabs.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> values. The default is Normal.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> value. </exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(TabAppearance.Normal)]
    [Localizable(true)]
    [SRDescription("TabBaseAppearanceDescr")]
    [SRCategory("CatBehavior")]
    [ProxyBrowsable(true)]
    public virtual TabAppearance Appearance
    {
      get => this.GetValue<TabAppearance>(TabControl.TabAppearanceProperty);
      set
      {
        if (!this.SetValue<TabAppearance>(TabControl.TabAppearanceProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether more than one row of tabs can be displayed.
    /// </summary>
    /// <returns>true if more than one row of tabs can be displayed; otherwise, false. The default is true.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("TabBaseMultilineDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public virtual bool Multiline
    {
      get => this.GetValue<bool>(TabControl.MultilineProperty);
      set
      {
        this.ValidateExpandAndMultiLine(this.IsExpanded, value, this.ShowExpandButton);
        if (!this.SetValue<bool>(TabControl.MultilineProperty, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (Multiline));
        if (!(this.CustomStyle == string.Empty))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the control enabled state.</summary>
    public override bool Enabled
    {
      get => base.Enabled;
      set => this.SetEnabled(value, AttributeType.Enabled, false);
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [Localizable(true)]
    [SRDescription("TabBasePaddingDescr")]
    [SRCategory("CatBehavior")]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Gets or sets the fore color.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>
    /// Gets or sets the background image displayed in the control.
    /// </summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>Gets or sets the background color.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    /// <summary>Gets or sets the size of the item.</summary>
    /// <value>The size of the item.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Size ItemSize
    {
      get => this.GetValue<Size>(TabControl.ItemSizeProperty);
      set => this.SetValue<Size>(TabControl.ItemSizeProperty, value);
    }

    /// <summary>Gets or sets the selected tab.</summary>
    /// <value>The selected tab.</value>
    [SRDescription("TabControlSelectedTabDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatAppearance")]
    [Browsable(false)]
    public TabPage SelectedTab
    {
      get => this.SelectedItem;
      set => this.SelectedItem = value;
    }

    /// <summary>Gets or sets the max page headers.</summary>
    /// <value>The max page headers.</value>
    [SRCategory("CatAppearance")]
    [SRDescription("MaxTabPageHeadersDescr")]
    [DefaultValue(0)]
    public virtual int MaxTabPageHeaders
    {
      get => this.GetValue<int>(TabControl.MaxTabPageHeadersProperty);
      set
      {
        if (!this.SetValue<int>(TabControl.MaxTabPageHeadersProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the way that the control's tabs are sized.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.TabSizeMode"></see> values. The default is Normal.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:System.Windows.Forms.TabSizeMode"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("TabBaseSizeModeDescr")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue(TabSizeMode.Normal)]
    public TabSizeMode SizeMode
    {
      get => TabSizeMode.Normal;
      set
      {
      }
    }

    /// <summary>
    /// Gets or Sets value indication if the close button should be shown
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show expand button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public virtual bool ShowExpandButton
    {
      get => this.GetValue<bool>(TabControl.ShowExpandButtonProperty);
      set
      {
        bool isExpanded = this.IsExpanded;
        this.ValidateExpandAndMultiLine(isExpanded, this.Multiline, value);
        this.ValidateExpandAndDock(isExpanded, this.Dock, value);
        if (!this.SetValue<bool>(TabControl.ShowExpandButtonProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual, false);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab control is expanded.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this tab control is expanded; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public virtual bool IsExpanded
    {
      get => this.GetValue<bool>(TabControl.IsExpandedProperty);
      set => this.SetIsExpanded(value, false);
    }

    /// <summary>Gets the height of the header.</summary>
    /// <value>The height of the header.</value>
    internal int SkinHeaderHeight
    {
      get
      {
        int skinHeaderHeight = this.HeaderHeight;
        if (skinHeaderHeight == -1 && this.Skin is TabControlSkin skin)
        {
          int num = this.Appearance == TabAppearance.Spread ? skin.TabSpreadHeight : skin.TabHeight;
          skinHeaderHeight = this.HeaderHeight = (this.ContextualTabGroupsInternal == null || this.ContextualTabGroupsInternal.Count <= 0 ? num : skin.ContextualTabGroupHeight + num) + skin.Padding.Top;
        }
        return skinHeaderHeight;
      }
    }

    /// <summary>Gets or sets the headers offset.</summary>
    /// <value>The headers offset.</value>
    [DefaultValue(-1)]
    public int HeadersOffset
    {
      get => this.GetValue<int>(TabControl.HeadersOffsetProperty);
      set
      {
        if (!this.SetValue<int>(TabControl.HeadersOffsetProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual, false);
      }
    }

    /// <summary>Gets the contextual tab groups.</summary>
    /// <value>The contextual tab groups.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [WebEditor(typeof (ContextualTabGroupCollectionEditor), typeof (WebUITypeEditor))]
    [MergableProperty(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Localizable(true)]
    public virtual ContextualTabGroupCollection ContextualTabGroups
    {
      get
      {
        ContextualTabGroupCollection contextualTabGroups = this.ContextualTabGroupsInternal;
        if (contextualTabGroups == null)
        {
          contextualTabGroups = new ContextualTabGroupCollection(this);
          this.ContextualTabGroupsInternal = contextualTabGroups;
        }
        return contextualTabGroups;
      }
    }

    /// <summary>Gets or sets the contextual tab groups internal.</summary>
    /// <value>The contextual tab groups internal.</value>
    internal ContextualTabGroupCollection ContextualTabGroupsInternal
    {
      get => this.GetValue<ContextualTabGroupCollection>(TabControl.ContextualTabGroupCollectionProperty);
      set => this.SetValue<ContextualTabGroupCollection>(TabControl.ContextualTabGroupCollectionProperty, value);
    }

    /// <summary>Gets/Sets the controls docking style</summary>
    public override DockStyle Dock
    {
      get => base.Dock;
      set
      {
        this.ValidateExpandAndDock(this.IsExpanded, value, this.ShowExpandButton);
        base.Dock = value;
      }
    }

    /// <summary>
    /// Gets a value indicating whether [should use client update handler].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [should use client update handler]; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool ShouldUseClientUpdateHandler => this.ClientBehavior == TabControlClientBehavior.DrawingOptimized;

    /// <summary>Signals the object that initialization is starting.</summary>
    void ISupportInitialize.BeginInit()
    {
    }

    /// <summary>Signals the object that initialization is complete.</summary>
    void ISupportInitialize.EndInit()
    {
      if (this.DesignMode)
        return;
      this.ApplyHeight(false);
    }

    /// <summary>Navigate to first view.</summary>
    /// <returns></returns>
    bool INavigationControl.MoveFirst()
    {
      if (this.TabPages.Count <= 0)
        return false;
      this.SelectedIndex = 0;
      return true;
    }

    /// <summary>Navigate to last view.</summary>
    /// <returns></returns>
    bool INavigationControl.MoveLast()
    {
      if (this.TabPages.Count <= 0)
        return false;
      this.SelectedIndex = this.TabPages.Count - 1;
      return true;
    }

    /// <summary>Navigate to next view.</summary>
    /// <returns></returns>
    bool INavigationControl.MoveNext()
    {
      if (this.TabPages.Count <= 0 || this.SelectedIndex >= this.TabPages.Count)
        return false;
      ++this.SelectedIndex;
      return true;
    }

    /// <summary>Navigate to Previous view.</summary>
    /// <returns></returns>
    bool INavigationControl.MovePrevious()
    {
      if (this.TabPages.Count <= 0 || this.SelectedIndex <= 0)
        return false;
      --this.SelectedIndex;
      return true;
    }

    /// <summary>Gets the number of views.</summary>
    int INavigationControl.Count => this.TabPages.Count;

    /// <summary>move to specific tab page.</summary>
    /// <returns></returns>
    void INavigationControl.MoveTo(int intIndex)
    {
      if (intIndex < 0 || intIndex > this.TabPages.Count - 1)
        return;
      this.SelectedIndex = intIndex;
    }

    /// <summary>Gets the selected index.</summary>
    int INavigationControl.SelectedIndex => this.SelectedIndex;

    /// <summary>
    /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects.
    /// </summary>
    [Serializable]
    public new class ControlCollection : Control.ControlCollection
    {
      private TabControl mobjOwner;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlCollection"></see> class.
      /// </summary>
      /// <param name="owner">The <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> that this collection belongs to. </param>
      public ControlCollection(TabControl objOwner)
        : base((Control) objOwner)
      {
        this.mobjOwner = objOwner;
      }

      /// <summary>
      /// Adds a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to the collection.
      /// </summary>
      /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add. </param>
      /// <exception cref="T:System.Exception">The specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>. </exception>
      public override void Add(Control objControl)
      {
        if (!(objControl is TabPage))
          throw new ArgumentException(SR.GetString("TabControlInvalidTabPageType", (object) objControl.GetType().Name));
        if (!(objControl is TabPage objValue))
          return;
        base.Add((Control) objValue);
      }

      /// <summary>
      /// Removes a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> from the collection.
      /// </summary>
      /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove. </param>
      public override void Remove(Control objControl)
      {
        int num1 = this.IndexOf(objControl);
        base.Remove(objControl);
        if (this.mobjOwner == null || !(objControl is TabPage) || num1 == -1)
          return;
        int selectedIndex = this.mobjOwner.SelectedIndex;
        int num2;
        if (this.Count == 0)
        {
          num2 = -1;
        }
        else
        {
          num2 = selectedIndex;
          if (num1 == num2)
            num2 = 0;
          else if (num1 < num2)
            --num2;
        }
        if (selectedIndex == num2)
          return;
        this.mobjOwner.SelectedIndex = num2;
      }

      /// <summary>Updates the owner.</summary>
      protected override void UpdateOwner()
      {
        if (this.mobjOwner == null)
          return;
        if (this.mobjOwner.ShouldUseClientUpdateHandler)
          this.mobjOwner.Update(false, true);
        else
          base.UpdateOwner();
      }
    }
  }
}
