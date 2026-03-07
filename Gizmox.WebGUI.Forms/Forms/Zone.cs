// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Zone
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Gizmox.WebGUI.Forms.MetadataTag("DZ")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ZoneSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class Zone : ContainerControl, IDescriptable, ISupportInitialize
  {
    internal const int ZONE_WITH_NO_OWNING_FORM_ID = -1;
    private bool mblnRegistered;
    private bool mblnSusspentUIEvents;
    private ZoneType menmZoneType;
    private long mlngOwningFormId;
    private ZoneCloseButton mobjCloseButton;
    private DockedHiddenZonesPanel mobjContainingHiddenPanel;
    private ZoneDescriptor mobjData;
    private ZoneDropDownButton mobjDropDownButton;
    private ZoneHeaderPanel mobjHeaderPanel;
    private DockingManager mobjManager;
    private ZonePinCheckBox mobjPinCheckBox;
    private DockedTabControl mobjTabControl;
    private ZoneHeaderLabel mobjZoneHeaderLabel;
    private Form mobjZonePopupForm;
    private bool mblnHideTabs;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Zone" /> class.
    /// </summary>
    /// <param name="objManager">The obj manager.</param>
    /// <param name="enmZoneType">Type of the enm zone.</param>
    public Zone(DockingManager objManager, ZoneType enmZoneType)
    {
      this.AllowDrop = true;
      this.mobjData = new ZoneDescriptor();
      this.Dock = DockStyle.Fill;
      this.mobjManager = objManager;
      this.ParentChanged += new EventHandler(this.Zone_ParentChanged);
      this.menmZoneType = enmZoneType;
      this.mblnSusspentUIEvents = false;
      this.mblnRegistered = false;
      this.mlngOwningFormId = -1L;
      this.mblnHideTabs = false;
      this.InitializeComponent();
      this.PostInitialization();
    }

    /// <summary>Gets or sets the containing hidden panel.</summary>
    /// <value>The containing hidden panel.</value>
    internal DockedHiddenZonesPanel ContainingHiddenPanel
    {
      get => this.mobjContainingHiddenPanel;
      set => this.mobjContainingHiddenPanel = value;
    }

    /// <summary>Gets the current window.</summary>
    public DockingWindow CurrentWindow => (this.mobjTabControl.SelectedTab as DockedTabPage).Window;

    /// <summary>Gets or sets the docking position.</summary>
    /// <value>The docking position.</value>
    public DockStyle DockingPosition
    {
      get => this.mobjData.DockingPosition;
      set => this.mobjData.DockingPosition = value;
    }

    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>Gets the manager.</summary>
    public DockingManager Manager => this.mobjManager;

    /// <summary>Gets or sets the owning form id.</summary>
    /// <value>The owning form id.</value>
    public long OwningFormId
    {
      get => this.mlngOwningFormId;
      set => this.mlngOwningFormId = value;
    }

    /// <summary>Gets the panel side.</summary>
    internal int PanelSide => this.mobjData.PanelSide;

    /// <summary>Gets the tab control.</summary>
    internal DockedTabControl TabControl => this.mobjTabControl;

    /// <summary>Gets the windows.</summary>
    public List<DockingWindow> Windows => this.TabControl.Windows;

    /// <summary>Gets the zone descriptor internal.</summary>
    internal ZoneDescriptor ZoneDescriptorInternal => this.mobjData;

    /// <summary>Gets or sets the type of the zone.</summary>
    /// <value>The type of the zone.</value>
    internal ZoneType ZoneType
    {
      get => this.menmZoneType;
      set
      {
        if (this.menmZoneType == value)
          return;
        this.menmZoneType = value;
        this.UpdateUI();
      }
    }

    /// <summary>Gets or sets the zone popup form.</summary>
    /// <value>The zone popup form.</value>
    public Form ZonePopupForm
    {
      get => this.mobjZonePopupForm;
      set => this.mobjZonePopupForm = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [force hide tabs].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [force hide tabs]; otherwise, <c>false</c>.
    /// </value>
    public bool HideTabs
    {
      get => this.mblnHideTabs;
      set
      {
        this.mblnHideTabs = value;
        this.SetTabControlTabsAppearance();
      }
    }

    /// <summary>Adds the window.</summary>
    /// <param name="enmRelation">The enm relation.</param>
    /// <param name="objDockedWindow">The obj docked window.</param>
    internal void AddWindow(Relation enmRelation, params DockingWindow[] objDockedWindow)
    {
      if (this.ZoneType == ZoneType.Hidden && (objDockedWindow.Length > 1 || this.Windows.Count == 1))
        throw new Exception("Hidden zone cannot contain more than one window");
      switch (enmRelation)
      {
        case Relation.Above:
        case Relation.Below:
        case Relation.ToTheRight:
        case Relation.ToTheLeft:
          Zone zoneForNewWindow = this.CreateZoneForNewWindow();
          this.SplitZone(enmRelation, zoneForNewWindow, true);
          zoneForNewWindow.AddWindow(Relation.Inside, objDockedWindow);
          break;
        case Relation.Inside:
          foreach (DockingWindow objWindow in objDockedWindow)
            this.mobjTabControl.AddWindow(objWindow);
          break;
      }
    }

    /// <summary>Updates the UI.</summary>
    internal void UpdateUI() => this.InitializeUIAccordingToZoneType();

    /// <summary>Notifies the header text chaged.</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    internal void NotifyHeaderTextChanged(DockingWindow objDockedWindow) => this.NotifyTabIndexChanged();

    /// <summary>Notifies the header tool tip changed.</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    internal void NotifyWindowHeaderAttributeChanged(DockingWindow objDockedWindow) => this.NotifyTabIndexChanged();

    /// <summary>Signals the object that initialization is starting.</summary>
    public void BeginInit() => this.mblnSusspentUIEvents = true;

    /// <summary>Signals the object that initialization is complete.</summary>
    public void EndInit() => this.mblnSusspentUIEvents = false;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      int result1;
      int result2;
      if (objEvent.Type == "AddForm" && int.TryParse(objEvent["DS"], out result1) && int.TryParse(objEvent["REL"], out result2))
        this.SplitForm((Relation) result2, this.Manager.GetFormFromComponentId(objEvent["DS"]) ?? throw new Exception("Dragged form with ID=" + (object) result1 + " was not found"));
      base.FireEvent(objEvent);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlAdded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlAdded(ControlEventArgs e)
    {
      base.OnControlAdded(e);
      if (!(e.Control is DockedTabControl control))
        return;
      control.OwningZone = this;
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
      (e.Control as IDescriptable).Descriptor.UpdateFrom((Control) this, (object) null);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlRemoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlRemoved(ControlEventArgs e)
    {
      base.OnControlRemoved(e);
      if (!(e.Control is DockedTabControl control))
        return;
      control.OwningZone = (Zone) null;
      if (this.Parent != null)
      {
        this.Parent.Controls.Remove((Control) this);
      }
      else
      {
        if (this.ContainingHiddenPanel == null)
          return;
        this.ContainingHiddenPanel.RemoveSingleZoneFromPanel(this);
      }
    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.UpdateUI();
      if (this.mblnRegistered)
        return;
      this.mblnRegistered = true;
      this.Manager.RegisterZone(this);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.ZoneType != ZoneType.Hidden)
        return;
      DockingWindow currentWindow = this.CurrentWindow;
      this.RenderHiddenZoneImageAttribute(objWriter, currentWindow, false);
      objWriter.WriteAttributeText("TX", currentWindow.Text);
    }

    /// <summary>
    /// Gets the docking position in relation to the root zone.
    /// </summary>
    /// <param name="objRelation">The obj relation.</param>
    /// <returns></returns>
    private DockStyle GetDockingPositionInRelationToRootZone(Relation objRelation)
    {
      if (this.ZoneType != ZoneType.Root)
        return this.DockingPosition;
      switch (objRelation)
      {
        case Relation.Above:
          return DockStyle.Top;
        case Relation.Below:
          return DockStyle.Bottom;
        case Relation.ToTheRight:
          return DockStyle.Right;
        case Relation.ToTheLeft:
          return DockStyle.Left;
        default:
          throw new Exception();
      }
    }

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor) => this.mobjData = objDescriptor is ZoneDescriptor zoneDescriptor ? zoneDescriptor : throw new ArgumentException("The given descriptor is not of type: " + typeof (ZoneDescriptor).FullName);

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
    {
      List<DockingWindow> windows = this.Windows;
      this.mobjData = this.ZoneDescriptorInternal.CloneWithoutReferences<ZoneDescriptor>();
      ((IDescriptable) this.TabControl).ResetDescriptorsTree(objType, objDockingPosition);
      this.ZoneType = objType;
      foreach (DockingWindow objWindow in windows)
        this.TabControl.AddWindow(objWindow);
      this.DockingPosition = objDockingPosition;
      this.TabControl.DockedTabControlDescriptorInternal.UpdateFrom((Control) this, (object) null);
    }

    /// <summary>Initializes the component.</summary>
    private void InitializeComponent()
    {
      this.mobjHeaderPanel = new ZoneHeaderPanel(this);
      this.mobjCloseButton = new ZoneCloseButton();
      this.mobjPinCheckBox = new ZonePinCheckBox();
      this.mobjDropDownButton = new ZoneDropDownButton();
      this.mobjTabControl = new DockedTabControl(this.mobjManager);
      this.mobjZoneHeaderLabel = new ZoneHeaderLabel();
      this.mobjHeaderPanel.SuspendLayout();
      this.SuspendLayout();
      this.mobjZoneHeaderLabel.Dock = DockStyle.Fill;
      this.mobjZoneHeaderLabel.AutoSize = true;
      this.mobjZoneHeaderLabel.Location = new Point(242, 136);
      this.mobjZoneHeaderLabel.Name = "label1";
      this.mobjZoneHeaderLabel.Size = new Size(35, 13);
      this.mobjZoneHeaderLabel.TabIndex = 1;
      this.mobjZoneHeaderLabel.DoubleClick += new EventHandler(this.mobjHeaderPanel_DoubleClick);
      this.mobjHeaderPanel.Controls.Add((Control) this.mobjZoneHeaderLabel);
      this.mobjHeaderPanel.Controls.Add((Control) this.mobjDropDownButton);
      this.mobjHeaderPanel.Controls.Add((Control) this.mobjPinCheckBox);
      this.mobjHeaderPanel.Controls.Add((Control) this.mobjCloseButton);
      this.mobjHeaderPanel.Dock = DockStyle.Top;
      this.mobjHeaderPanel.Size = new Size(831, 20);
      this.mobjHeaderPanel.TabIndex = 0;
      this.mobjCloseButton.Dock = DockStyle.Right;
      this.mobjCloseButton.Location = new Point(801, 0);
      this.mobjCloseButton.Name = "button1";
      this.mobjCloseButton.Size = new Size(16, 27);
      this.mobjCloseButton.TabIndex = 0;
      this.mobjCloseButton.UseVisualStyleBackColor = true;
      this.mobjCloseButton.Click += new EventHandler(this.mobjCloseButton_Click);
      this.mobjPinCheckBox.Dock = DockStyle.Right;
      this.mobjPinCheckBox.Location = new Point(771, 0);
      this.mobjPinCheckBox.Name = "button2";
      this.mobjPinCheckBox.Size = new Size(100, 27);
      this.mobjPinCheckBox.UseVisualStyleBackColor = true;
      this.mobjPinCheckBox.CheckedChanged += new EventHandler(this.mobjPinCheckBox_CheckedChanged);
      this.mobjDropDownButton.Dock = DockStyle.Right;
      this.mobjDropDownButton.Location = new Point(745, 0);
      this.mobjDropDownButton.Name = "button3";
      this.mobjDropDownButton.Size = new Size(26, 27);
      this.mobjDropDownButton.TabIndex = 2;
      this.mobjDropDownButton.UseVisualStyleBackColor = true;
      this.mobjDropDownButton.Click += new EventHandler(this.mobjMenuButton_Click);
      this.mobjTabControl.Dock = DockStyle.Fill;
      this.mobjTabControl.Location = new Point(0, 27);
      this.mobjTabControl.Name = "tabControl1";
      this.mobjTabControl.SelectedIndex = 0;
      this.mobjTabControl.Size = new Size(831, 606);
      this.mobjTabControl.TabIndex = 1;
      this.Controls.Add((Control) this.mobjTabControl);
      this.Controls.Add((Control) this.mobjHeaderPanel);
      this.mobjHeaderPanel.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    /// <summary>Initializes the custom controls.</summary>
    private void InitializeCustomControls()
    {
      ZoneCloseButtonSkin skin1 = SkinFactory.GetSkin((ISkinable) this.mobjCloseButton) as ZoneCloseButtonSkin;
      ZonePinCheckBoxSkin skin2 = SkinFactory.GetSkin((ISkinable) this.mobjPinCheckBox) as ZonePinCheckBoxSkin;
      ZoneDropDownButtonSkin skin3 = SkinFactory.GetSkin((ISkinable) this.mobjDropDownButton) as ZoneDropDownButtonSkin;
      this.mobjCloseButton.Size = skin1.TotalSize;
      this.mobjCloseButton.Text = "";
      this.mobjPinCheckBox.Size = skin2.TotalSize;
      this.mobjPinCheckBox.Text = "";
      this.mobjDropDownButton.Size = skin3.TotalSize;
      this.mobjDropDownButton.Text = "";
    }

    /// <summary>Initializes the dock zone type UI.</summary>
    private void InitializeDockZoneTypeUI()
    {
      this.InitializeHeaderPanelVisibility(true);
      this.InitializeCloseButtonVisibility(true);
      this.InitializeDropDownButtonVisibility(true);
      this.InitializePinButtonVisibility(true);
      this.mobjCloseButton.ClientAction = (RegisteredClientAction) null;
      this.mobjPinCheckBox.ClientAction = (RegisteredClientAction) null;
      ((IPreventExtraction) this.mobjTabControl).DisableExtraction(false);
      this.InitializeTabControlAppearance(false);
    }

    /// <summary>Initializes the pin button visibility.</summary>
    /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
    private void InitializePinButtonVisibility(bool blnIsVisible) => this.mobjPinCheckBox.Visible = blnIsVisible && this.Manager != null && this.Manager.ShowPinButton;

    /// <summary>Initializes the drop down button visibility.</summary>
    /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
    private void InitializeDropDownButtonVisibility(bool blnIsVisible) => this.mobjDropDownButton.Visible = blnIsVisible && this.Manager != null && this.Manager.ShowDropDownButton;

    /// <summary>Initializes the close button visibility.</summary>
    /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
    private void InitializeCloseButtonVisibility(bool blnIsVisible) => this.mobjCloseButton.Visible = blnIsVisible && this.Manager != null && this.Manager.AllowCloseWindows;

    /// <summary>Initializes the header panel visibility.</summary>
    /// <param name="blnIsVisible">if set to <c>true</c> [BLN is visible].</param>
    private void InitializeHeaderPanelVisibility(bool blnIsVisible) => this.mobjHeaderPanel.Visible = blnIsVisible;

    /// <summary>Initializes the float zone type UI.</summary>
    private void InitializeFloatZoneTypeUI()
    {
      this.InitializeHeaderPanelVisibility(true);
      this.InitializeCloseButtonVisibility(true);
      this.InitializeDropDownButtonVisibility(true);
      this.InitializePinButtonVisibility(false);
      this.mobjCloseButton.ClientAction = (RegisteredClientAction) null;
      this.mobjPinCheckBox.ClientAction = (RegisteredClientAction) null;
      ((IPreventExtraction) this.mobjTabControl).DisableExtraction(false);
      this.InitializeTabControlAppearance(false);
    }

    /// <summary>Initializes the hidden zone type UI.</summary>
    private void InitializeHiddenZoneTypeUI()
    {
      this.InitializeHeaderPanelVisibility(true);
      this.InitializeCloseButtonVisibility(true);
      this.InitializeDropDownButtonVisibility(true);
      this.InitializePinButtonVisibility(true);
      this.mobjPinCheckBox.Checked = true;
    }

    /// <summary>Initializes the type of the root zone.</summary>
    private void InitializeRootZoneType()
    {
      this.InitializeHeaderPanelVisibility(false);
      this.mobjTabControl.ShowCloseButton = this.Manager != null && this.Manager.AllowCloseWindows;
      this.mobjTabControl.CloseClick += new EventHandler(this.mobjTabControl_CloseClick);
      ((IPreventExtraction) this.mobjTabControl).DisableExtraction(true);
      this.InitializeTabControlAppearance(true);
    }

    private void InitializeTabControlAppearance(bool blnIsRoot)
    {
      if (!blnIsRoot)
      {
        this.mobjTabControl.Alignment = TabAlignment.Bottom;
        this.mobjTabControl.ControlAdded -= new ControlEventHandler(this.mobjTabControl_RootControlAdded);
        this.mobjTabControl.ControlRemoved -= new ControlEventHandler(this.mobjTabControl_RootControlRemoved);
        this.mobjTabControl.ControlAdded += new ControlEventHandler(this.mobjTabControl_ControlAdded);
        this.mobjTabControl.ControlRemoved += new ControlEventHandler(this.mobjTabControl_ControlRemoved);
      }
      else
      {
        this.mobjTabControl.Alignment = TabAlignment.Top;
        this.mobjTabControl.ControlAdded -= new ControlEventHandler(this.mobjTabControl_ControlAdded);
        this.mobjTabControl.ControlRemoved -= new ControlEventHandler(this.mobjTabControl_ControlRemoved);
        this.mobjTabControl.ControlAdded += new ControlEventHandler(this.mobjTabControl_RootControlAdded);
        this.mobjTabControl.ControlRemoved += new ControlEventHandler(this.mobjTabControl_RootControlRemoved);
      }
    }

    /// <summary>Initializes the type of the UI according to zone.</summary>
    private void InitializeUIAccordingToZoneType()
    {
      this.BeginInit();
      switch (this.menmZoneType)
      {
        case ZoneType.Root:
          this.InitializeRootZoneType();
          break;
        case ZoneType.Dock:
          this.InitializeDockZoneTypeUI();
          break;
        case ZoneType.Float:
          this.InitializeFloatZoneTypeUI();
          break;
        case ZoneType.Hidden:
          this.InitializeHiddenZoneTypeUI();
          break;
        default:
          throw new Exception("Zone type not supported: " + this.menmZoneType.ToString());
      }
      this.SetTabControlTabsAppearance();
      this.EndInit();
    }

    /// <summary>
    /// Handles the Click event of the mobjCloseButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjCloseButton_Click(object sender, EventArgs e)
    {
      this.CloseCurrentWindow();
      this.CloseZonePopupForm();
    }

    /// <summary>Closes the current window.</summary>
    private void CloseCurrentWindow() => this.Manager.SwitchWindowsDockState(DockState.Close, this.CurrentWindow);

    /// <summary>Closes the zone popup window.</summary>
    private void CloseZonePopupForm()
    {
      if (this.mobjZonePopupForm == null)
        return;
      this.mobjZonePopupForm.Close();
    }

    /// <summary>
    /// Handles the DoubleClick event of the mobjHeaderPanel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjHeaderPanel_DoubleClick(object sender, EventArgs e)
    {
      this.OnHeaderDoubleClick();
      this.CloseZonePopupForm();
    }

    /// <summary>
    /// Handles the Click event of the mobjMenuButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjMenuButton_Click(object sender, EventArgs e) => this.Manager.GetDockedContextMenuStrip(this).Show((Component) this.mobjDropDownButton, new Point(1, 1), ToolStripDropDownDirection.BelowLeft);

    /// <summary>
    /// Handles the CheckedChanged event of the mobjPinCheckBox control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjPinCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.mblnSusspentUIEvents)
        return;
      this.ToggleAutoHide();
    }

    /// <summary>
    /// Handles the CloseClick event of the mobjTabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjTabControl_CloseClick(object sender, EventArgs e) => this.CloseCurrentWindow();

    /// <summary>
    /// Handles the ControlAdded event of the mobjTabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void mobjTabControl_ControlAdded(object sender, ControlEventArgs e) => this.SetTabControlTabsAppearance();

    /// <summary>
    /// Handles the ControlRemoved event of the mobjTabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void mobjTabControl_ControlRemoved(object sender, ControlEventArgs e) => this.SetTabControlTabsAppearance();

    /// <summary>
    /// Handles the RootControlAdded event of the mobjTabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void mobjTabControl_RootControlAdded(object sender, ControlEventArgs e) => this.HandleRootTabControlControlsChanged();

    /// <summary>
    /// Handles the RootControlRemoved event of the mobjTabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void mobjTabControl_RootControlRemoved(object sender, ControlEventArgs e) => this.HandleRootTabControlControlsChanged();

    /// <summary>Handles the root tab control controls changed.</summary>
    private void HandleRootTabControlControlsChanged()
    {
      if (this.mobjTabControl.Controls.Count > 0)
        this.mobjTabControl.ShowCloseButton = true;
      else
        this.mobjTabControl.ShowCloseButton = false;
    }

    /// <summary>Posts the initialization.</summary>
    private void PostInitialization() => this.InitializeCustomControls();

    /// <summary>Removes the and return all windows.</summary>
    /// <returns></returns>
    internal List<DockingWindow> RemoveAndReturnAllWindows()
    {
      List<DockingWindow> windows = this.Windows;
      this.RemoveWindows(this.Windows.ToArray());
      return windows;
    }

    /// <summary>Renders the hidden zone image attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objWindow">The obj window.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderHiddenZoneImageAttribute(
      IAttributeWriter objWriter,
      DockingWindow objWindow,
      bool blnForceRender)
    {
      if (!(objWindow.Image != null | blnForceRender))
        return;
      objWriter.WriteAttributeString("IM", objWindow.Image.ToString());
    }

    /// <summary>Sets the tab control tabs appearance.</summary>
    private void SetTabControlTabsAppearance()
    {
      if (this.mobjTabControl.Controls.Count == 1 && this.ZoneType != ZoneType.Root || this.ZoneType == ZoneType.Hidden || this.mblnHideTabs)
        this.mobjTabControl.Appearance = TabAppearance.Logical;
      else
        this.mobjTabControl.Appearance = TabAppearance.Normal;
    }

    /// <summary>Splits the zone.</summary>
    /// <param name="objRelation">The obj relation.</param>
    /// <param name="objZone">The obj zone.</param>
    /// <param name="blnIsNewZone">if set to <c>true</c> [BLN is new zone].</param>
    private void SplitZone(Relation objRelation, Zone objZone, bool blnIsNewZone)
    {
      if (objZone.ZoneType == ZoneType.Root)
        return;
      switch (objRelation)
      {
        case Relation.Above:
        case Relation.Below:
        case Relation.ToTheRight:
        case Relation.ToTheLeft:
          DockStyle relationToRootZone = this.GetDockingPositionInRelationToRootZone(objRelation);
          if (this.ZoneType == objZone.ZoneType)
          {
            Control logicalParentControl = DockedManagerHelper.GetLogicalParentControl((Control) objZone);
            if (logicalParentControl != null && logicalParentControl is DockedSplitContainer)
              (logicalParentControl as DockedSplitContainer).HardRemovePanel(objZone.PanelSide);
          }
          else if (!blnIsNewZone)
            ((IDescriptable) objZone).ResetDescriptorsTree(this.ZoneType == ZoneType.Root ? ZoneType.Dock : this.ZoneType, relationToRootZone);
          objZone.DockingPosition = relationToRootZone;
          DockedManagerHelper.SplitControl((Control) this, (Control) objZone, objRelation, this.Manager);
          break;
        case Relation.Inside:
          this.AddWindow(Relation.Inside, objZone.RemoveAndReturnAllWindows().ToArray());
          break;
        default:
          throw new Exception("Unsupported Relation type: " + objRelation.ToString());
      }
    }

    /// <summary>Handles the ParentChanged event of the Zone control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void Zone_ParentChanged(object sender, EventArgs e)
    {
      if (this.Parent != null || this.ContainingHiddenPanel != null)
      {
        if (this.ID == 0L || this.mblnRegistered)
          return;
        this.Manager.RegisterZone(this);
        this.mblnRegistered = true;
      }
      else
      {
        this.Manager.UnRegisterZone(this);
        this.mblnRegistered = false;
      }
    }

    /// <summary>Removes the and return all windows.</summary>
    /// <returns></returns>
    internal DockingWindow RemoveAndReturnCurrentWindow()
    {
      DockingWindow currentWindow = this.CurrentWindow;
      this.RemoveWindows(currentWindow);
      return currentWindow;
    }

    /// <summary>Removes the windows.</summary>
    /// <param name="arrWindows">The arr windows.</param>
    internal void RemoveWindows(params DockingWindow[] arrWindows)
    {
      foreach (DockingWindow arrWindow in arrWindows)
        this.TabControl.RemoveWindow(arrWindow);
    }

    /// <summary>Creates the zone for new window.</summary>
    /// <returns></returns>
    internal Zone CreateZoneForNewWindow() => new Zone(this.Manager, this.menmZoneType == ZoneType.Root ? ZoneType.Dock : this.menmZoneType);

    /// <summary>Hides the current window.</summary>
    internal void HideCurrentWindow()
    {
      this.HideWindow(this.CurrentWindow);
      this.CloseZonePopupForm();
    }

    /// <summary>Hides the window.</summary>
    /// <param name="objWindow">The obj window.</param>
    internal void HideWindow(DockingWindow objWindow) => this.Manager.SwitchWindowsDockState(DockState.Hidden, objWindow);

    /// <summary>Notifies the tab index changed.</summary>
    internal void NotifyTabIndexChanged()
    {
      if (this.mobjTabControl.TabPages.Count > 0)
      {
        DockingWindow window = (this.mobjTabControl.SelectedItem as DockedTabPage).Window;
        this.mobjZoneHeaderLabel.Text = window.HeaderText;
        if (!string.IsNullOrEmpty(window.HeaderToolTip))
          this.mobjZoneHeaderLabel.ToolTip = window.HeaderToolTip;
        else
          this.mobjZoneHeaderLabel.ToolTip = string.Empty;
      }
      else
        this.mobjZoneHeaderLabel.Text = string.Empty;
    }

    /// <summary>Called when [header double click].</summary>
    internal virtual void OnHeaderDoubleClick()
    {
      List<DockingWindow> windows = this.Windows;
      this.Manager.SwitchWindowsDockState(this.menmZoneType == ZoneType.Root ? DockState.Dock : DockingManager.GetDockStateAccordingToZoneType(this.menmZoneType), windows.ToArray());
    }

    /// <summary>Splits this zone with a given docked form.</summary>
    /// <param name="enmRelation">The enm relation.</param>
    /// <param name="objForm">The obj form.</param>
    internal void SplitForm(Relation enmRelation, DockedForm objForm)
    {
      Control control = objForm.Controls[0];
      bool flag = this.ZoneType != ZoneType.Float;
      DockingWindow[] arrChangedWindows = (DockingWindow[]) null;
      switch (control)
      {
        case Zone _:
          Zone objZone = control as Zone;
          this.SplitZone(enmRelation, objZone, false);
          if (flag)
          {
            arrChangedWindows = objZone.Windows.ToArray();
            break;
          }
          break;
        case DockedSplitContainer _:
          DockedSplitContainer dockedSplitContainer = control as DockedSplitContainer;
          switch (enmRelation)
          {
            case Relation.Above:
            case Relation.Below:
            case Relation.ToTheRight:
            case Relation.ToTheLeft:
              if (flag)
              {
                ((IDescriptable) dockedSplitContainer).ResetDescriptorsTree(this.ZoneType == ZoneType.Root ? ZoneType.Dock : this.ZoneType, this.GetDockingPositionInRelationToRootZone(enmRelation));
                arrChangedWindows = dockedSplitContainer.Windows.ToArray();
              }
              DockedManagerHelper.SplitControl((Control) this, control, enmRelation, this.Manager);
              break;
            case Relation.Inside:
              arrChangedWindows = dockedSplitContainer.Windows.ToArray();
              this.AddWindow(enmRelation, arrChangedWindows);
              break;
          }
          break;
        default:
          throw new Exception("The root control inside a DockedForm must be of type: '" + typeof (Zone).FullName + "' this ZoneType = Floating, or " + typeof (DockedSplitContainer).FullName);
      }
      if (!flag || this.Manager == null)
        return;
      this.Manager.OnWindowsStateChanged(DockState.Float, this.ZoneType == ZoneType.Root ? DockState.Tabbed : DockState.Dock, arrChangedWindows);
    }

    /// <summary>Switches the state of the current window dock.</summary>
    /// <param name="objDesiredDockState">State of the obj desired dock.</param>
    internal void SwitchCurrentWindowDockState(DockState objDesiredDockState)
    {
      this.CloseZonePopupForm();
      this.Manager.SwitchWindowsDockState(objDesiredDockState, this.CurrentWindow);
    }

    /// <summary>Toggles the auto hide.</summary>
    internal void ToggleAutoHide()
    {
      DockState objDesiredDockState;
      if (this.ZoneType == ZoneType.Dock)
      {
        objDesiredDockState = DockState.AutoHide;
      }
      else
      {
        if (this.ZoneType != ZoneType.Hidden)
          throw new Exception(string.Format("Zone of type: '{0}', does not support AutoHide", (object) this.ZoneType));
        objDesiredDockState = DockState.Dock;
        this.CloseZonePopupForm();
      }
      this.Manager.SwitchWindowsDockState(objDesiredDockState, this.Windows.ToArray());
    }

    /// <summary>Invokes the parent changed.</summary>
    internal void InvokeParentChanged() => this.OnParentChanged(EventArgs.Empty);
  }
}
