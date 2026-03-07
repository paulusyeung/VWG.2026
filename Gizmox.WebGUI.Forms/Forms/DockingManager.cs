// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockingManager
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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Gizmox.WebGUI.Forms.MetadataTag("DM")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DockingManagerSkin))]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (DockingManager), "Professional.DockedManager.DockingManager_45.png")]
  [Serializable]
  public class DockingManager : ContainerControl, IDescriptable
  {
    internal static readonly SerializableEvent EVENT_TABBEDWINDOWSELECTED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DockingManager));
    internal static readonly SerializableEvent EVENT_TABBEDWINDOWCLOSED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DockingManager));
    internal static readonly SerializableEvent EVENT_DOCKINGWINDOWLOADED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DockingManager));
    internal static readonly SerializableEvent EVENT_WINDOWSSTATECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DockingManager));
    private List<Zone> mobjAllZones;
    private List<long> mobjLiveFormsIds;
    private DockedManagerDescriptor mobjData;
    private DockedContextMenuStrip mobjDockedContextMenuStrip;
    private Dictionary<DockedSplitContainerDescriptor, DockedSplitContainer> mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor;
    private Zone mobjRootZone;
    private DockedHiddenZonesPanel mobjRightPanel;
    private DockedHiddenZonesPanel mobjTopPanel;
    private DockedHiddenZonesPanel mobjBottomPanel;
    private DockedHiddenZonesPanel mobjLeftPanel;
    private DockedWindowsCollection mobjDockedWindowsCollection;
    private Dictionary<string, long> mobjDockedFormsIdsIndexByDockedFormsUniqueId;
    private bool mblnIsInLoadMode;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockingManager" /> class.
    /// </summary>
    public DockingManager() => this.InitializeDockedManager((DockedManagerDescriptor) null);

    /// <summary>
    /// Gets a value indicating whether this instance is in load mode.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is in load mode; otherwise, <c>false</c>.
    /// </value>
    internal bool IsInLoadMode
    {
      get => this.mblnIsInLoadMode;
      private set => this.mblnIsInLoadMode = value;
    }

    /// <summary>Gets or sets the pin animation speed.</summary>
    /// <value>The pin animation speed.</value>
    public int PinAnimationSpeed
    {
      get => this.mobjData.PinAnimationSpeed;
      set
      {
        if (this.mobjData.PinAnimationSpeed == value)
          return;
        this.mobjData.PinAnimationSpeed = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the docked windows.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DockedWindowsCollection DockedWindows => this.mobjDockedWindowsCollection;

    /// <summary>
    /// Gets or sets a value indicating whether [show close button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool AllowFloatingWindows
    {
      get => this.mobjData.AllowFloatingWindows;
      set => this.mobjData.AllowFloatingWindows = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow tabbed documents].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [allow tabbed documents]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool AllowTabbedDocuments
    {
      get => this.mobjData.AllowTabbedDocuments;
      set => this.mobjData.AllowTabbedDocuments = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show close button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [Browsable(false)]
    public bool AllowCloseWindows
    {
      get => this.mobjData.AllowCloseWindows;
      set
      {
        if (this.mobjData.AllowCloseWindows == value)
          return;
        this.mobjData.AllowCloseWindows = value;
        this.UpdateZonesUI();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show close button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show close button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [Browsable(false)]
    [Obsolete("Use AllowCloseWindows property instead")]
    public bool ShowCloseButton
    {
      get => this.AllowCloseWindows;
      set => this.AllowCloseWindows = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show minimize button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show minimize button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool ShowMinimizeButton
    {
      get => this.mobjData.ShowMinimizeButton;
      set
      {
        if (this.mobjData.ShowMinimizeButton == value)
          return;
        this.mobjData.ShowMinimizeButton = value;
        this.InitializeAllLiveFormsUI();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show maximize button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show maximize button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool ShowMaximizeButton
    {
      get => this.mobjData.ShowMaximizeButton;
      set
      {
        if (this.mobjData.ShowMaximizeButton == value)
          return;
        this.mobjData.ShowMaximizeButton = value;
        this.InitializeAllLiveFormsUI();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show pin button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show pin button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool ShowPinButton
    {
      get => this.mobjData.ShowPinButton;
      set
      {
        if (this.mobjData.ShowPinButton == value)
          return;
        this.mobjData.ShowPinButton = value;
        this.UpdateZonesUI();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show drop down button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show drop down button]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool ShowDropDownButton
    {
      get => this.mobjData.ShowDropDownButton;
      set
      {
        if (this.mobjData.ShowDropDownButton == value)
          return;
        this.mobjData.ShowDropDownButton = value;
        this.UpdateZonesUI();
      }
    }

    /// <summary>Gets the docked context menu strip.</summary>
    private DockedContextMenuStrip DockedContextMenuStrip
    {
      get
      {
        if (this.mobjDockedContextMenuStrip == null)
          this.mobjDockedContextMenuStrip = new DockedContextMenuStrip(this);
        return this.mobjDockedContextMenuStrip;
      }
    }

    /// <summary>Gets the hidden panel.</summary>
    internal DockedHiddenZonesPanel HiddenPanel => this.mobjLeftPanel != null ? this.mobjLeftPanel : new DockedHiddenZonesPanel((DockingManager) null);

    /// <summary>Gets the root zone.</summary>
    internal Zone RootZone
    {
      get => this.mobjRootZone;
      private set => this.mobjRootZone = value;
    }

    /// <summary>Gets the docked panels padding.</summary>
    /// <value>The docked panels padding.</value>
    internal Padding DockedPanelsPadding
    {
      get
      {
        Padding padding;
        int intLeft;
        if (this.mobjLeftPanel == null || !this.mobjLeftPanel.Visible)
        {
          intLeft = this.Padding.Left + this.BorderWidth.Left;
        }
        else
        {
          int width = this.mobjLeftPanel.Width;
          padding = this.Padding;
          int left = padding.Left;
          intLeft = width + left + this.BorderWidth.Left;
        }
        int intTop;
        if (this.mobjTopPanel == null || !this.mobjTopPanel.Visible)
        {
          padding = this.Padding;
          intTop = padding.Top + this.BorderWidth.Top;
        }
        else
        {
          int height = this.mobjTopPanel.Height;
          padding = this.Padding;
          int top = padding.Top;
          intTop = height + top + this.BorderWidth.Top;
        }
        int intRight;
        if (this.mobjRightPanel == null || !this.mobjRightPanel.Visible)
        {
          padding = this.Padding;
          intRight = padding.Right + this.BorderWidth.Right;
        }
        else
        {
          int width = this.mobjRightPanel.Width;
          padding = this.Padding;
          int right = padding.Right;
          intRight = width + right + this.BorderWidth.Right;
        }
        int intBottom;
        if (this.mobjBottomPanel == null || !this.mobjBottomPanel.Visible)
        {
          padding = this.Padding;
          intBottom = padding.Bottom + this.BorderWidth.Bottom;
        }
        else
        {
          int height = this.mobjBottomPanel.Height;
          padding = this.Padding;
          int bottom = padding.Bottom;
          intBottom = height + bottom + this.BorderWidth.Bottom;
        }
        return new Padding(intLeft, intTop, intRight, intBottom);
      }
    }

    /// <summary>
    /// Hides the main content tabs not enabling to switch between open windows/tabs.
    /// </summary>
    [DefaultValue(false)]
    public bool HideRootZoneTabHeaders
    {
      get => this.mobjRootZone != null && this.mobjRootZone.HideTabs;
      set
      {
        if (this.mobjRootZone == null)
          return;
        this.mobjRootZone.HideTabs = value;
      }
    }

    /// <summary>Occurs when [tabbed window closed].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a tabbed window is closed")]
    public event TabbedWindowClosedEventHandler TabbedWindowClosed
    {
      add
      {
        if (this.GetTabbedWindowSelectedEventCount(DockingManager.EVENT_TABBEDWINDOWCLOSED) == 0)
          this.RootZone.TabControl.ControlRemoved += new ControlEventHandler(this.TabControl_ControlRemoved);
        this.AddHandler(DockingManager.EVENT_TABBEDWINDOWCLOSED, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(DockingManager.EVENT_TABBEDWINDOWCLOSED, (Delegate) value);
        if (this.GetTabbedWindowSelectedEventCount(DockingManager.EVENT_TABBEDWINDOWCLOSED) != 0)
          return;
        this.RootZone.TabControl.ControlRemoved -= new ControlEventHandler(this.TabControl_ControlRemoved);
      }
    }

    /// <summary>Occurs when [docking window loaded].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a DockingWindow is loaded from the LoadData operation")]
    public event DockingWindowLoadedEventHandler DockingWindowLoaded
    {
      add => this.AddHandler(DockingManager.EVENT_DOCKINGWINDOWLOADED, (Delegate) value);
      remove => this.RemoveHandler(DockingManager.EVENT_DOCKINGWINDOWLOADED, (Delegate) value);
    }

    /// <summary>Occurs when [windows state changed].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when window's state is changed")]
    public event WindowsStateChangedEventHandler WindowsStateChanged
    {
      add => this.AddHandler(DockingManager.EVENT_WINDOWSSTATECHANGED, (Delegate) value);
      remove => this.RemoveHandler(DockingManager.EVENT_WINDOWSSTATECHANGED, (Delegate) value);
    }

    /// <summary>Occurs when [tabbed window selected].</summary>
    [SRCategory("CatData")]
    [SRDescription("Raised when a tabbed window is selected")]
    public event TabbedWindowSelectedEventHandler TabbedWindowSelected
    {
      add
      {
        if (this.GetTabbedWindowSelectedEventCount(DockingManager.EVENT_TABBEDWINDOWSELECTED) == 0)
          this.RootZone.TabControl.SelectedIndexChanged += new EventHandler(this.TabControl_SelectedIndexChanged);
        this.AddHandler(DockingManager.EVENT_TABBEDWINDOWSELECTED, (Delegate) value);
      }
      remove
      {
        this.RemoveHandler(DockingManager.EVENT_TABBEDWINDOWSELECTED, (Delegate) value);
        if (this.GetTabbedWindowSelectedEventCount(DockingManager.EVENT_TABBEDWINDOWSELECTED) != 0)
          return;
        this.RootZone.TabControl.SelectedIndexChanged -= new EventHandler(this.TabControl_SelectedIndexChanged);
      }
    }

    /// <summary>Closes all floating windows.</summary>
    public void CloseAllFloatingWindows()
    {
      foreach (long copy in this.CopyCollection<long>((ICollection<long>) this.mobjLiveFormsIds))
        this.GetFormFromComponentId(copy)?.Close();
    }

    /// <summary>Initializes all live forms UI.</summary>
    private void InitializeAllLiveFormsUI()
    {
      foreach (long mobjLiveFormsId in this.mobjLiveFormsIds)
        this.InitializeFormUI(this.GetFormFromComponentId(mobjLiveFormsId));
    }

    /// <summary>Initializes the form UI.</summary>
    /// <param name="objLiveForm">The obj live form.</param>
    private void InitializeFormUI(DockedForm objForm)
    {
      objForm.MinimizeBox = this.ShowMinimizeButton;
      objForm.MaximizeBox = this.ShowMaximizeButton;
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderHiddenZoneExpansionSpeed(objWriter, false);
    }

    /// <summary>Renders the hidden zone expansion speed.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderHiddenZoneExpansionSpeed(IAttributeWriter objWriter, bool blnForceRender)
    {
      int pinAnimationSpeed = this.PinAnimationSpeed;
      if (!(pinAnimationSpeed != (SkinFactory.GetSkin((ISkinable) this.mobjRightPanel) as DockedHiddenZonesPanelSkin).HiddenZoneItemExpantionAnimationDuration | blnForceRender))
        return;
      objWriter.WriteAttributeString("ZAS", pinAnimationSpeed.ToString());
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
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderHiddenZoneExpansionSpeed(objWriter, true);
    }

    /// <summary>Gets the docked context menu strip.</summary>
    /// <param name="mobjOwningZone">The mobj owning zone.</param>
    /// <returns></returns>
    internal ContextMenuStrip GetDockedContextMenuStrip(Zone mobjOwningZone) => (ContextMenuStrip) this.DockedContextMenuStrip.SetZone(mobjOwningZone);

    /// <summary>Docks the windows in root position.</summary>
    /// <param name="enmRelation">The enm relation.</param>
    /// <param name="objDockedWindows">The obj docked windows.</param>
    private void DockWindowsInRootPosition(
      Relation enmRelation,
      params DockingWindow[] objDockedWindows)
    {
      if (enmRelation == Relation.Inside)
      {
        this.SwitchWindowsDockState(DockState.Tabbed, objDockedWindows);
      }
      else
      {
        Control descriptableControl = DockedManagerHelper.GetDescriptableControl((Control) this, out int _);
        Zone zone = new Zone(this, ZoneType.Dock);
        Zone objNewControl = zone;
        int enmSplitRelation = (int) enmRelation;
        DockedManagerHelper.SplitControl(descriptableControl, (Control) objNewControl, (Relation) enmSplitRelation, this);
        zone.AddWindow(Relation.Inside, objDockedWindows);
        switch (enmRelation)
        {
          case Relation.Above:
            zone.DockingPosition = DockStyle.Top;
            break;
          case Relation.Below:
            zone.DockingPosition = DockStyle.Bottom;
            break;
          case Relation.ToTheRight:
            zone.DockingPosition = DockStyle.Right;
            break;
          case Relation.ToTheLeft:
            zone.DockingPosition = DockStyle.Left;
            break;
          default:
            throw new Exception();
        }
      }
    }

    /// <summary>Closes all.</summary>
    public void CloseAll()
    {
      foreach (DockingWindow copy in this.CopyCollection<DockingWindow>((ICollection<DockingWindow>) this.DockedWindows.WindowsIndexByWindowName.Values))
        copy.Close();
    }

    /// <summary>Shows all.</summary>
    public void ShowAll()
    {
      foreach (DockingWindow copy in this.CopyCollection<DockingWindow>((ICollection<DockingWindow>) this.DockedWindows.HiddenWindowsIndexByWindowName.Values))
        copy.Show();
    }

    /// <summary>Copies the collection.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns></returns>
    private IEnumerable<T> CopyCollection<T>(ICollection<T> collection)
    {
      T[] array = new T[collection.Count];
      collection.CopyTo(array, 0);
      return (IEnumerable<T>) array;
    }

    /// <summary>Unpins all.</summary>
    public void UnpinAll()
    {
      List<Zone> zoneList = new List<Zone>();
      foreach (Zone mobjAllZone in this.mobjAllZones)
      {
        if (mobjAllZone.ZoneType == ZoneType.Dock)
          zoneList.Add(mobjAllZone);
      }
      foreach (Zone zone in zoneList)
        zone.ToggleAutoHide();
    }

    /// <summary>Pins all.</summary>
    public void PinAll()
    {
      foreach (DockingWindow copy in this.CopyCollection<DockingWindow>((ICollection<DockingWindow>) this.DockedWindows.WindowsIndexByWindowName.Values))
      {
        if (copy.CurrentDockState == DockState.AutoHide)
          this.SwitchWindowsDockState(DockState.Dock, copy);
      }
    }

    /// <summary>Shows the hidden window.</summary>
    /// <param name="objWindow">The obj window.</param>
    internal void ShowHiddenWindow(DockingWindow objWindow)
    {
      DockingWindow dockingWindow;
      if (!this.DockedWindows.HiddenWindowsIndexByWindowName.TryGetValue(objWindow.WindowName, out dockingWindow))
        return;
      this.RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(objWindow, ZoneType.Hidden);
      this.AddWindow(dockingWindow.LastDockState, DockStyle.Fill, objWindow);
    }

    /// <summary>Gets the tabbed window selected event count.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private int GetTabbedWindowSelectedEventCount(SerializableEvent objEvent)
    {
      Delegate handler = this.GetHandler(objEvent);
      return (object) handler != null ? handler.GetInvocationList().Length : 0;
    }

    /// <summary>
    /// Handles the ControlRemoved event of the TabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void TabControl_ControlRemoved(object sender, ControlEventArgs e) => this.OnTabbedWindowClosed((e.Control as DockedTabPage).Window);

    /// <summary>Called when [tabbed window closed].</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    private void OnTabbedWindowClosed(DockingWindow objDockedWindow)
    {
      if (!(this.GetHandler(DockingManager.EVENT_TABBEDWINDOWCLOSED) is TabbedWindowClosedEventHandler handler))
        return;
      handler((object) this, new TabbedWindowClosedEventArgs(objDockedWindow));
    }

    /// <summary>Called when [docking window loaded].</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    private void OnDockingWindowLoaded(DockingWindow objDockedWindow)
    {
      if (!(this.GetHandler(DockingManager.EVENT_DOCKINGWINDOWLOADED) is DockingWindowLoadedEventHandler handler))
        return;
      handler((object) this, new DockingWindowLoadedEventArgs(objDockedWindow));
    }

    /// <summary>Called when [windows state changed].</summary>
    /// <param name="enmPreviousDockState">State of the enm previous dock.</param>
    /// <param name="enmNewDockState">State of the enm new dock.</param>
    /// <param name="arrChangedWindows">The arr changed windows.</param>
    internal void OnWindowsStateChanged(
      DockState enmPreviousDockState,
      DockState enmNewDockState,
      DockingWindow[] arrChangedWindows)
    {
      if (!(this.GetHandler(DockingManager.EVENT_WINDOWSSTATECHANGED) is WindowsStateChangedEventHandler handler))
        return;
      handler((object) this, new WindowsStateChangedEventArgs(enmPreviousDockState, enmNewDockState, arrChangedWindows));
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the TabControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(sender is DockedTabControl dockedTabControl) || dockedTabControl.SelectedItem == null)
        return;
      this.OnTabbedWindowSelected((dockedTabControl.SelectedItem as DockedTabPage).Window);
    }

    /// <summary>Called when [tabbed window selected].</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    private void OnTabbedWindowSelected(DockingWindow objDockedWindow)
    {
      if (!(this.GetHandler(DockingManager.EVENT_TABBEDWINDOWSELECTED) is TabbedWindowSelectedEventHandler handler))
        return;
      handler((object) this, new TabbedWindowSelectedEventArgs(objDockedWindow));
    }

    /// <summary>Switches the state of the window dock.</summary>
    /// <param name="objDesiredDockState">State of the obj desired dock.</param>
    /// <param name="objWindows">The windows.</param>
    internal void SwitchWindowsDockState(
      DockState objDesiredDockState,
      params DockingWindow[] objWindows)
    {
      Relation enmDockInRootRelation = Relation.Inside;
      DockingWindow objFirstWindow = (DockingWindow) null;
      if (objWindows.Length != 0)
        objFirstWindow = objWindows[0];
      DockingManager.RemovedWindowsData removedWindowsData = this.RemoveWindowFromPreviousDockState(objDesiredDockState, objFirstWindow, objWindows);
      bool blnIsDockInRootPosition = removedWindowsData.DesiredDockState == DockState.Dock && !removedWindowsData.HasDockingStateInfo && removedWindowsData.PreviousDockState == DockState.AutoHide;
      if (blnIsDockInRootPosition)
      {
        switch (removedWindowsData.UnpinPosition)
        {
          case DockStyle.Top:
            enmDockInRootRelation = Relation.Above;
            break;
          case DockStyle.Right:
            enmDockInRootRelation = Relation.ToTheRight;
            break;
          case DockStyle.Bottom:
            enmDockInRootRelation = Relation.Below;
            break;
          case DockStyle.Left:
            enmDockInRootRelation = Relation.ToTheLeft;
            break;
          default:
            throw new Exception("Relation cannot be: " + removedWindowsData.UnpinPosition.ToString());
        }
      }
      this.AddWindow(removedWindowsData.DesiredDockState, removedWindowsData.UnpinPosition, blnIsDockInRootPosition, enmDockInRootRelation, removedWindowsData.Windows);
      if (removedWindowsData.PreviousDockState == DockState.AutoHide && (removedWindowsData.DesiredDockState == DockState.Dock || removedWindowsData.DesiredDockState == DockState.Float))
        objFirstWindow.IsSelectedTab = true;
      this.OnWindowsStateChanged(removedWindowsData.PreviousDockState, removedWindowsData.DesiredDockState, removedWindowsData.Windows);
    }

    /// <summary>Removes the state of the window from previous dock.</summary>
    /// <param name="objDesiredDockState">State of the obj desired dock.</param>
    /// <param name="objFirstWindow">The obj first window.</param>
    /// <param name="objWindows">The obj windows.</param>
    /// <param name="enmPosition">The enm position.</param>
    /// <returns></returns>
    private DockingManager.RemovedWindowsData RemoveWindowFromPreviousDockState(
      DockState objDesiredDockState,
      DockingWindow objFirstWindow,
      DockingWindow[] objWindows)
    {
      DockingManager.RemovedWindowsData removedWindowsData = new DockingManager.RemovedWindowsData();
      removedWindowsData.DesiredDockState = objDesiredDockState;
      removedWindowsData.PreviousDockState = objFirstWindow.CurrentDockState;
      removedWindowsData.HasDockingStateInfo = this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.ContainsKey(objFirstWindow.WindowName);
      removedWindowsData.HasFloatingStateInfo = this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.ContainsKey(objFirstWindow.WindowName);
      removedWindowsData.UnpinPosition = DockStyle.Fill;
      if (objFirstWindow.CurrentDockState == DockState.AutoHide)
      {
        if (objFirstWindow.OwningZone == null)
          throw new Exception("Hidden window must be contained in a Hidden zone");
        removedWindowsData.UnpinPosition = objFirstWindow.OwningZone.DockingPosition;
        if (objDesiredDockState == DockState.Dock || objDesiredDockState == DockState.Float)
          objWindows = objFirstWindow.OwningZone.ContainingHiddenPanel.RemoveAndReturnHiddenWindows(objFirstWindow).ToArray();
        else
          objFirstWindow.OwningZone.ContainingHiddenPanel.RemoveHiddenZone(objFirstWindow.OwningZone);
      }
      else if (objFirstWindow.OwningZone != null)
      {
        removedWindowsData.UnpinPosition = objFirstWindow.OwningZone.DockingPosition;
        objFirstWindow.OwningZone.RemoveWindows(objWindows);
      }
      else
      {
        foreach (DockingWindow objWindow in objWindows)
          this.DockedWindows.RemoveWindow(objWindow);
      }
      removedWindowsData.Windows = objWindows;
      return removedWindowsData;
    }

    /// <summary>Adds the auto hidden windows.</summary>
    /// <param name="objZoneDockingPosition">The obj zone docking position.</param>
    /// <param name="objWindows">The obj windows.</param>
    public void AddAutoHiddenWindows(
      DockStyle objZoneDockingPosition,
      params DockingWindow[] objWindows)
    {
      this.AddWindow(DockState.AutoHide, objZoneDockingPosition, objWindows);
    }

    /// <summary>Adds the docked windows.</summary>
    /// <param name="objWindows">The obj windows.</param>
    public void AddDockedWindows(params DockingWindow[] objWindows) => this.AddWindow(DockState.Dock, DockStyle.Fill, objWindows);

    /// <summary>Adds the docked windows in root position.</summary>
    /// <param name="enmRelation">The enm relation.</param>
    /// <param name="objWindows">The obj windows.</param>
    public void AddDockedWindowsInRootPosition(
      Relation enmRelation,
      params DockingWindow[] objWindows)
    {
      this.AddWindow(DockState.Dock, DockStyle.Fill, true, enmRelation, objWindows);
    }

    /// <summary>Adds the float windows.</summary>
    /// <param name="objWindows">The obj windows.</param>
    public void AddFloatWindows(params DockingWindow[] objWindows) => this.AddWindow(DockState.Float, DockStyle.Fill, objWindows);

    /// <summary>Adds the tabbed windows.</summary>
    /// <param name="objWindows">The obj windows.</param>
    public void AddTabbedWindows(params DockingWindow[] objWindows) => this.AddWindow(DockState.Tabbed, DockStyle.Fill, objWindows);

    /// <summary>Adds the window.</summary>
    /// <param name="objDockState">State of the obj dock.</param>
    /// <param name="objZoneDockingPosition">The obj zone docking position.</param>
    /// <param name="objWindows">The obj windows.</param>
    internal void AddWindow(
      DockState objDockState,
      DockStyle objZoneDockingPosition,
      params DockingWindow[] objWindows)
    {
      this.AddWindow(objDockState, objZoneDockingPosition, false, Relation.Above, objWindows);
    }

    /// <summary>Adds the window.</summary>
    /// <param name="objDockState">State of the obj dock.</param>
    /// <param name="objZoneDockingPosition">The obj zone docking position.</param>
    /// <param name="blnIsDockInRootPosition">if set to <c>true</c> [BLN is dock in root position].</param>
    /// <param name="enmDockInRootRelation">The enm dock in root relation.</param>
    /// <param name="objWindows">The obj windows.</param>
    internal void AddWindow(
      DockState objDockState,
      DockStyle objZoneDockingPosition,
      bool blnIsDockInRootPosition,
      Relation enmDockInRootRelation,
      params DockingWindow[] objWindows)
    {
      switch (objDockState)
      {
        case DockState.Float:
          foreach (DockingWindow objWindow in objWindows)
          {
            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
            this.DockedWindows.RemoveHiddenWindow(objWindow);
            objWindow.Manager = this;
            this.AddFloatWindow(objWindow);
          }
          break;
        case DockState.Dock:
          if (blnIsDockInRootPosition)
          {
            foreach (DockingWindow objWindow in objWindows)
            {
              this.DockedWindows.AddWindowIfDoesntExist(objWindow);
              this.DockedWindows.RemoveHiddenWindow(objWindow);
              objWindow.Manager = this;
            }
            this.DockWindowsInRootPosition(enmDockInRootRelation, objWindows);
            break;
          }
          foreach (DockingWindow objWindow in objWindows)
          {
            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
            this.DockedWindows.RemoveHiddenWindow(objWindow);
            objWindow.Manager = this;
            this.AddDockedWindow(objWindow);
          }
          break;
        case DockState.Tabbed:
          foreach (DockingWindow objWindow in objWindows)
          {
            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
            this.DockedWindows.RemoveHiddenWindow(objWindow);
            objWindow.Manager = this;
            this.RootZone.AddWindow(Relation.Inside, objWindow);
          }
          break;
        case DockState.AutoHide:
          foreach (DockingWindow objWindow in objWindows)
          {
            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
            this.DockedWindows.RemoveHiddenWindow(objWindow);
            objWindow.Manager = this;
          }
          this.AutoHideWindows(objZoneDockingPosition, objWindows);
          break;
        case DockState.Hidden:
          foreach (DockingWindow objWindow in objWindows)
          {
            this.DockedWindows.AddWindowIfDoesntExist(objWindow);
            this.DockedWindows.AddHiddenWindow(objWindow);
            this.SetWindowDockState(objWindow, DockState.Hidden);
            this.AddWindowToCorrectZoneTypeListInManagersDescriptor(objWindow);
          }
          break;
        case DockState.Close:
          foreach (DockingWindow objWindow in objWindows)
          {
            this.DockedWindows.AddHiddenWindow(objWindow);
            this.SetWindowDockState(objWindow, DockState.Close);
          }
          break;
        default:
          throw new NotImplementedException(string.Format("Adding windows of type '{0}' is not supported.", (object) objDockState.ToString()));
      }
    }

    /// <summary>Sets the state of the window dock.</summary>
    /// <param name="objWindow">The obj window.</param>
    /// <param name="enmDockState">State of the dock.</param>
    private void SetWindowDockState(DockingWindow objWindow, DockState enmDockState)
    {
      objWindow.Manager = this;
      objWindow.CurrentDockState = enmDockState;
    }

    /// <summary>Loads the data.</summary>
    /// <param name="objData">The obj data.</param>
    public void LoadData(byte[] objData)
    {
      MemoryStream serializationStream = new MemoryStream();
      try
      {
        serializationStream.Write(objData, 0, objData.Length);
        serializationStream.Seek(0L, SeekOrigin.Begin);
        this.mobjData = (DockedManagerDescriptor) new BinaryFormatter().Deserialize((Stream) serializationStream);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        serializationStream.Close();
      }
      this.IsInLoadMode = true;
      this.Controls.Clear();
      this.CloseAllFloatingWindows();
      this.InitializeDockedManager(this.mobjData);
      this.LoadWindows(this.mobjData.RemoveAndReturnRootWindows(), DockState.Tabbed, DockStyle.Fill);
      this.LoadWindows(this.mobjData.RemoveAndReturnDockedWindowsDescriptors(), DockState.Dock, DockStyle.Fill);
      this.LoadAutoHiddenWindows(this.mobjData.LeftHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Left);
      this.LoadAutoHiddenWindows(this.mobjData.TopHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Top);
      this.LoadAutoHiddenWindows(this.mobjData.RightHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Right);
      this.LoadAutoHiddenWindows(this.mobjData.BottomHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Bottom);
      this.LoadHiddenWindows(this.mobjData.RemoveAndReturnHiddenWindowsDescriptors());
      this.LoadWindows(this.mobjData.RemoveAndReturnFloatWindowsDescriptors(), DockState.Float, DockStyle.None);
      this.IsInLoadMode = false;
    }

    /// <summary>Loads the hidden windows.</summary>
    /// <param name="objHiddenWindows">The obj hidden windows.</param>
    private void LoadHiddenWindows(List<DockedWindowDescriptor> objHiddenWindows) => this.LoadWindows(objHiddenWindows, DockState.Hidden, DockStyle.Fill);

    /// <summary>Saves the data.</summary>
    /// <returns></returns>
    public byte[] SaveData()
    {
      MemoryStream serializationStream = new MemoryStream();
      new BinaryFormatter().Serialize((Stream) serializationStream, (object) this.mobjData);
      serializationStream.Close();
      return serializationStream.ToArray();
    }

    /// <summary>
    /// Raises the <see cref="E:ControlAdded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlAdded(ControlEventArgs e)
    {
      base.OnControlAdded(e);
      if (!(e.Control is IDescriptable control1))
        throw new Exception(this.GetType().Name + ": Supprots only DockingWindow or DockingSplitContaineror RootZone. Added type: " + e.Control.GetType().Name);
      if (e.Control is DockingWindow control2)
        this.AddWindow(DockState.Tabbed, DockStyle.Fill, control2);
      control1.Descriptor.UpdateFrom((Control) this, (object) null);
    }

    /// <summary>Adds a window to the docked position.</summary>
    /// <param name="objWindow">The obj window.</param>
    private void AddDockedWindow(DockingWindow objWindow)
    {
      DockedWindowPlaceHolderDescriptor objDescriptor;
      if (this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.TryGetValue(objWindow.WindowName, out objDescriptor))
      {
        List<DockedObjectDescriptor> descriptorTrace = DockedManagerHelper.GetDescriptorTrace((DockedObjectDescriptor) objDescriptor, false);
        DockedManagerHelper.LoadWindowFromTrace((Control) this, objWindow, descriptorTrace, this, DockState.Dock);
      }
      else
        this.SwitchWindowsDockState(DockState.Tabbed, objWindow);
    }

    /// <summary>Adds the float window.</summary>
    /// <param name="objWindow">The obj window.</param>
    private void AddFloatWindow(DockingWindow objWindow)
    {
      List<DockedObjectDescriptor> objDescriptorsList = (List<DockedObjectDescriptor>) null;
      DockedWindowPlaceHolderDescriptor objDescriptor;
      if (this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.TryGetValue(objWindow.WindowName, out objDescriptor))
        objDescriptorsList = DockedManagerHelper.GetDescriptorTrace((DockedObjectDescriptor) objDescriptor, false);
      if (objDescriptorsList != null)
      {
        DockedManagerHelper.LoadWindowFromTrace((Control) this, objWindow, objDescriptorsList, this, DockState.Float);
      }
      else
      {
        DockedForm newForm = this.CreateNewForm((DockedFormDescriptor) null);
        Zone objValue = new Zone(this, ZoneType.Float);
        newForm.Controls.Add((Control) objValue);
        objValue.AddWindow(Relation.Inside, objWindow);
      }
    }

    /// <summary>Gets all zones as components list.</summary>
    /// <returns></returns>
    private Component[] GetAllZonesAsComponentsList(long lngFormId)
    {
      List<Component> componentList = new List<Component>();
      foreach (Zone mobjAllZone in this.mobjAllZones)
      {
        if (mobjAllZone.OwningFormId != lngFormId)
          componentList.Add((Component) mobjAllZone);
      }
      return componentList.ToArray();
    }

    /// <summary>Initializes the componenet.</summary>
    private void InitializeComponenet(DockedManagerDescriptor objDescriptor)
    {
      this.mobjRootZone = new Zone(this, ZoneType.Root);
      this.mobjTopPanel = new DockedHiddenZonesPanel(this);
      this.mobjRightPanel = new DockedHiddenZonesPanel(this);
      this.mobjBottomPanel = new DockedHiddenZonesPanel(this);
      this.mobjLeftPanel = new DockedHiddenZonesPanel(this);
      this.mobjTopPanel.Dock = DockStyle.Top;
      this.mobjTopPanel.BackColor = Color.Transparent;
      this.mobjRightPanel.Dock = DockStyle.Right;
      this.mobjRightPanel.BackColor = Color.Transparent;
      this.mobjBottomPanel.Dock = DockStyle.Bottom;
      this.mobjBottomPanel.BackColor = Color.Transparent;
      this.mobjLeftPanel.Dock = DockStyle.Left;
      this.mobjLeftPanel.BackColor = Color.Transparent;
      this.mobjRootZone.Dock = DockStyle.Fill;
      this.mobjRootZone.DockingPosition = DockStyle.None;
      if (objDescriptor == null)
        this.Controls.Add((Control) this.mobjRootZone);
      else
        DockedManagerHelper.EnterRootZone(this.mobjRootZone, this);
      this.Controls.Add((Control) this.mobjRightPanel);
      this.Controls.Add((Control) this.mobjLeftPanel);
      this.Controls.Add((Control) this.mobjBottomPanel);
      this.Controls.Add((Control) this.mobjTopPanel);
    }

    /// <summary>Initializes the descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    private void InitializeDescriptor(DockedManagerDescriptor objDescriptor)
    {
      if (objDescriptor == null)
        this.mobjData = new DockedManagerDescriptor(this);
      else
        ((IDescriptable) this).Load((DockedObjectDescriptor) this.mobjData);
    }

    /// <summary>Initializes the docked form.</summary>
    /// <param name="objDocekdForm">The obj docekd form.</param>
    private void InitializeDockedForm(DockedForm objDocekdForm)
    {
      ((IDescriptable) objDocekdForm).Descriptor.UpdateFrom((Control) this, (object) null);
      this.InitializeFormUI(objDocekdForm);
      objDocekdForm.Load += new EventHandler(this.objDocekdForm_Load);
      objDocekdForm.FormClosed += new Form.FormClosedEventHandler(this.objDocekdForm_FormClosed);
      objDocekdForm.Owner = this.ParentForm;
    }

    /// <summary>Initializes the docked manager.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    private void InitializeDockedManager(DockedManagerDescriptor objDescriptor)
    {
      this.mobjAllZones = new List<Zone>();
      this.mobjDockedWindowsCollection = this.CreateCollection();
      this.mobjDockedWindowsCollection.Manager = this;
      this.InitializeDescriptor(objDescriptor);
      this.mobjLiveFormsIds = new List<long>();
      this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor = new Dictionary<DockedSplitContainerDescriptor, DockedSplitContainer>();
      this.mobjDockedFormsIdsIndexByDockedFormsUniqueId = new Dictionary<string, long>();
      this.InitializeComponenet(objDescriptor);
      this.InitializeHiddenPanelsAndRootZoneDescriptorsReferences(objDescriptor);
      this.InitializeVWGSizes();
    }

    /// <summary>Creates the collection.</summary>
    /// <returns></returns>
    protected virtual DockedWindowsCollection CreateCollection() => new DockedWindowsCollection();

    /// <summary>Initializes the hidden panels descriptors referances.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    private void InitializeHiddenPanelsAndRootZoneDescriptorsReferences(
      DockedManagerDescriptor objDescriptor)
    {
      if (objDescriptor != null)
      {
        ((IDescriptable) this.mobjTopPanel).Load((DockedObjectDescriptor) objDescriptor.TopHiddenWindowsDescriptor);
        ((IDescriptable) this.mobjRightPanel).Load((DockedObjectDescriptor) objDescriptor.RightHiddenWindowsDescriptor);
        ((IDescriptable) this.mobjLeftPanel).Load((DockedObjectDescriptor) objDescriptor.LeftHiddenWindowsDescriptor);
        ((IDescriptable) this.mobjBottomPanel).Load((DockedObjectDescriptor) objDescriptor.BottomHiddenWindowsDescriptor);
      }
      else
      {
        this.mobjData.TopHiddenWindowsDescriptor = this.mobjTopPanel.DockedHiddenPanelDescriptor;
        this.mobjData.RightHiddenWindowsDescriptor = this.mobjRightPanel.DockedHiddenPanelDescriptor;
        this.mobjData.LeftHiddenWindowsDescriptor = this.mobjLeftPanel.DockedHiddenPanelDescriptor;
        this.mobjData.BottomHiddenWindowsDescriptor = this.mobjBottomPanel.DockedHiddenPanelDescriptor;
      }
      this.mobjData.RootZoneDescriptor = this.mobjRootZone.ZoneDescriptorInternal;
    }

    /// <summary>Initializes the VWG sizes.</summary>
    private void InitializeVWGSizes()
    {
      DockedHiddenZonesPanelSkin skin = SkinFactory.GetSkin((ISkinable) this.mobjTopPanel) as DockedHiddenZonesPanelSkin;
      this.mobjTopPanel.Size = new Size(0, skin.PanelThickness);
      this.mobjBottomPanel.Size = new Size(0, skin.PanelThickness);
      this.mobjLeftPanel.Size = new Size(skin.PanelThickness, 0);
      this.mobjRightPanel.Size = new Size(skin.PanelThickness, 0);
    }

    /// <summary>Loads the hidden windows.</summary>
    /// <param name="objWindowDescriptorsGroups">The obj window descriptors groups.</param>
    /// <param name="objDockStyle">The obj dock style.</param>
    private void LoadAutoHiddenWindows(
      List<List<DockedWindowDescriptor>> objWindowDescriptorsGroups,
      DockStyle objDockStyle)
    {
      if (objWindowDescriptorsGroups == null)
        return;
      foreach (List<DockedWindowDescriptor> descriptorsGroup in objWindowDescriptorsGroups)
        this.LoadWindows(descriptorsGroup, DockState.AutoHide, objDockStyle);
    }

    /// <summary>Loads the windows.</summary>
    /// <param name="objDockedWindowDescriptors">The docked window descriptors.</param>
    /// <param name="objDockState">The dock state .</param>
    /// <param name="objDockStyle">The dock style.</param>
    private void LoadWindows(
      List<DockedWindowDescriptor> objDockedWindowDescriptors,
      DockState objDockState,
      DockStyle objDockStyle)
    {
      List<DockingWindow> dockingWindowList = new List<DockingWindow>();
      foreach (DockedWindowDescriptor windowDescriptor in objDockedWindowDescriptors)
      {
        Type windowType = windowDescriptor.WindowType;
        try
        {
          DockingWindow instance = (DockingWindow) Activator.CreateInstance(windowType);
          ((IDescriptable) instance).Load((DockedObjectDescriptor) windowDescriptor);
          this.OnDockingWindowLoaded(instance);
          dockingWindowList.Add(instance);
        }
        catch
        {
        }
      }
      if (dockingWindowList.Count <= 0)
        return;
      this.AddWindow(objDockState, objDockStyle, dockingWindowList.ToArray());
    }

    /// <summary>
    /// Handles the FormClosed event of the objDocekdForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.FormClosedEventArgs" /> instance containing the event data.</param>
    private void objDocekdForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      DockedForm dockedForm = sender as DockedForm;
      List<DockingWindow> windows = dockedForm.Windows;
      if (windows != null)
      {
        foreach (DockingWindow dockingWindow in windows.ToArray())
          dockingWindow.Close();
      }
      this.mobjLiveFormsIds.Remove(dockedForm.ID);
    }

    /// <summary>Handles the Load event of the objDocekdForm control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objDocekdForm_Load(object sender, EventArgs e)
    {
      DockedForm dockedForm = sender as DockedForm;
      this.mobjLiveFormsIds.Add(dockedForm.ID);
      dockedForm.SetDragTargets(this.GetAllZonesAsComponentsList(dockedForm.ID));
    }

    /// <summary>Refreshes the drag targets.</summary>
    private void RefreshFormsDragTargets()
    {
      foreach (long mobjLiveFormsId in this.mobjLiveFormsIds)
        this.GetFormFromComponentId(mobjLiveFormsId)?.SetDragTargets(this.GetAllZonesAsComponentsList(mobjLiveFormsId));
    }

    /// <summary>Updates the hidden panels dimentions.</summary>
    internal void UpdateHiddenPanelsDimentions()
    {
      DockedHiddenZonesPanelSkin skin = SkinFactory.GetSkin((ISkinable) this.mobjTopPanel) as DockedHiddenZonesPanelSkin;
      if (this.mobjRightPanel.Visible)
      {
        this.mobjTopPanel.DockPadding.Right = skin.PanelThickness;
        this.mobjBottomPanel.DockPadding.Right = skin.PanelThickness;
      }
      else
      {
        this.mobjTopPanel.DockPadding.Right = 0;
        this.mobjBottomPanel.DockPadding.Right = 0;
        this.mobjBottomPanel.DockPadding.Left = skin.PanelThickness;
      }
      if (this.mobjLeftPanel.Visible)
      {
        this.mobjBottomPanel.DockPadding.Left = skin.PanelThickness;
        this.mobjTopPanel.DockPadding.Left = skin.PanelThickness;
      }
      else
      {
        this.mobjBottomPanel.DockPadding.Left = 0;
        this.mobjTopPanel.DockPadding.Left = 0;
      }
    }

    /// <summary>
    /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
    /// </summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.Form.Closing += new CancelEventHandler(this.Form_Closing);
    }

    /// <summary>Handles the Closing event of the Form control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
    private void Form_Closing(object sender, CancelEventArgs e) => this.CloseAllFloatingWindows();

    /// <summary>Creates the new form.</summary>
    /// <param name="objFormDescriptor">The obj form descriptor.</param>
    /// <returns></returns>
    internal DockedForm CreateNewForm(DockedFormDescriptor objFormDescriptor)
    {
      DockedForm objDocekdForm = new DockedForm(this);
      this.InitializeDockedForm(objDocekdForm);
      if (objFormDescriptor != null)
        ((IDescriptable) objDocekdForm).Load((DockedObjectDescriptor) objFormDescriptor);
      return objDocekdForm;
    }

    /// <summary>Gets the form from component id.</summary>
    /// <param name="lngFormId">The LNG form id.</param>
    /// <returns></returns>
    internal DockedForm GetFormFromComponentId(long lngFormId) => ((ISessionRegistry) this.Context).GetRegisteredComponent(lngFormId) as DockedForm;

    /// <summary>Gets the form from component id.</summary>
    /// <param name="strFormId">The STR form id.</param>
    /// <returns></returns>
    internal DockedForm GetFormFromComponentId(string strFormId) => this.GetFormFromComponentId(long.Parse(strFormId));

    /// <summary>Gets the form from descriptor.</summary>
    /// <param name="objFormDescriptor">The obj form descriptor.</param>
    /// <returns></returns>
    internal DockedForm GetFormFromDescriptor(DockedFormDescriptor objFormDescriptor)
    {
      DockedForm formFromDescriptor = (DockedForm) null;
      if (objFormDescriptor != null && this.mobjLiveFormsIds.Contains(objFormDescriptor.OwningFormId))
        formFromDescriptor = this.GetFormFromComponentId(objFormDescriptor.OwningFormId);
      if (formFromDescriptor == null)
        formFromDescriptor = this.CreateNewForm(objFormDescriptor);
      return formFromDescriptor;
    }

    /// <summary>Handles the window logical location changed.</summary>
    /// <param name="objWindowDescriptor">The obj window descriptor.</param>
    /// <param name="objDockedTabControl">The obj docked tab control descriptor.</param>
    /// <param name="objZone">The obj zone.</param>
    internal void HandleWindowStateChanged(
      DockedWindowDescriptor objWindowDescriptor,
      DockedTabControl objDockedTabControl)
    {
      DockedTabControlDescriptor descriptorInternal = objDockedTabControl.DockedTabControlDescriptorInternal;
      switch (objDockedTabControl.OwningZone.ZoneType)
      {
        case ZoneType.Dock:
          this.TryRemoveFromLastDockStatePosition(this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName, objWindowDescriptor, descriptorInternal);
          break;
        case ZoneType.Float:
          this.TryRemoveFromLastDockStatePosition(this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName, objWindowDescriptor, descriptorInternal);
          break;
      }
    }

    /// <summary>Tries the remove from last dock state position.</summary>
    /// <param name="objWindowPalceHoldersByDockState">State of the obj window palce holders by dock.</param>
    /// <param name="objWindowDescriptor">The obj window descriptor.</param>
    /// <param name="objDockedTabControlDescriptor">The obj docked tab control descriptor.</param>
    private void TryRemoveFromLastDockStatePosition(
      Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> objWindowPalceHoldersByDockState,
      DockedWindowDescriptor objWindowDescriptor,
      DockedTabControlDescriptor objDockedTabControlDescriptor)
    {
      DockedWindowPlaceHolderDescriptor holderDescriptor;
      if (!objWindowPalceHoldersByDockState.TryGetValue(objWindowDescriptor.WindowName, out holderDescriptor) || !(holderDescriptor.ParentDescriptor is DockedTabControlDescriptor parentDescriptor) || parentDescriptor == objDockedTabControlDescriptor)
        return;
      parentDescriptor.RemoveWindow(objWindowDescriptor);
    }

    /// <summary>Notifies the zone empty.</summary>
    /// <param name="objDockedSplitContainerDescriptor">The obj docked split container descriptor.</param>
    /// <param name="intPanelSide">The int panel side.</param>
    internal void NotifyZoneEmpty(
      DockedSplitContainerDescriptor objDockedSplitContainerDescriptor,
      int intPanelSide)
    {
      DockedSplitContainer dockedSplitContainer;
      if (!this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.TryGetValue(objDockedSplitContainerDescriptor, out dockedSplitContainer))
        throw new Exception(string.Format("mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor does not contain the given split container descriptor"));
      dockedSplitContainer.HardRemovePanel(intPanelSide);
    }

    /// <summary>Registers the place holder.</summary>
    /// <param name="enmZoneType">Type of the enm zone.</param>
    /// <param name="objWindowDescriptor">The obj window descriptor.</param>
    /// <returns></returns>
    internal DockedWindowPlaceHolderDescriptor RegisterPlaceHolder(
      ZoneType enmZoneType,
      DockedWindowDescriptor objWindowDescriptor)
    {
      Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> dictionary = (Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>) null;
      switch (enmZoneType)
      {
        case ZoneType.Root:
        case ZoneType.Hidden:
          DockedWindowPlaceHolderDescriptor holderDescriptor = (DockedWindowPlaceHolderDescriptor) null;
          if (dictionary != null)
          {
            holderDescriptor = new DockedWindowPlaceHolderDescriptor(objWindowDescriptor, enmZoneType);
            if (!dictionary.ContainsKey(objWindowDescriptor.WindowName))
              dictionary.Add(objWindowDescriptor.WindowName, holderDescriptor);
            else
              dictionary[objWindowDescriptor.WindowName] = holderDescriptor;
          }
          return holderDescriptor;
        case ZoneType.Dock:
          dictionary = this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName;
          goto case ZoneType.Root;
        case ZoneType.Float:
          dictionary = this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName;
          goto case ZoneType.Root;
        default:
          throw new Exception();
      }
    }

    /// <summary>Registers the split container.</summary>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    internal void RegisterSplitContainer(DockedSplitContainer objDockedSplitContainer)
    {
      DockedSplitContainerDescriptor descriptorInternal = objDockedSplitContainer.DockedSplitContainerDescriptorInternal;
      if (this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.ContainsKey(descriptorInternal))
        this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor[descriptorInternal] = objDockedSplitContainer;
      else
        this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.Add(descriptorInternal, objDockedSplitContainer);
    }

    /// <summary>Registers the zone.</summary>
    /// <param name="objZone">The obj zone.</param>
    internal void RegisterZone(Zone objZone)
    {
      this.mobjAllZones.Add(objZone);
      this.RefreshFormsDragTargets();
    }

    /// <summary>Unregisters the window.</summary>
    /// <param name="objWindow">The obj window.</param>
    /// <param name="enmZoneType">Type of the enm zone.</param>
    internal void RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(
      DockingWindow objWindow,
      ZoneType enmZoneType)
    {
      this.mobjData.UnregisterWindow(objWindow.DockedWindowDescriptorInternal);
    }

    /// <summary>
    /// Adds the window to correct zone type list in managers descriptor.
    /// </summary>
    /// <param name="objWindow">The obj window.</param>
    /// <param name="enmZoneType">Type of the enm zone.</param>
    internal void AddWindowToCorrectZoneTypeListInManagersDescriptor(DockingWindow objWindow) => this.mobjData.RegiserWindow(objWindow.DockedWindowDescriptorInternal);

    /// <summary>Sets the window form owner.</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    /// <param name="objDockedFormDescriptor">The obj docked form descriptor.</param>
    internal void SetWindowFormMapping(
      DockingWindow objDockedWindow,
      DockedFormDescriptor objDockedFormDescriptor)
    {
      if (this.mobjData.FormDescriptorIndexByWindowName.ContainsKey(objDockedWindow.WindowName))
        this.mobjData.FormDescriptorIndexByWindowName[objDockedWindow.WindowName] = objDockedFormDescriptor;
      else
        this.mobjData.FormDescriptorIndexByWindowName.Add(objDockedWindow.WindowName, objDockedFormDescriptor);
    }

    /// <summary>Unpins the windows.</summary>
    /// <param name="objWindows">The obj windows.</param>
    /// <param name="enmPanelSide">The enm panel side.</param>
    internal void AutoHideWindows(DockStyle enmPanelSide, params DockingWindow[] objWindows)
    {
      List<Zone> objHiddenZones = new List<Zone>();
      foreach (DockingWindow objWindow in objWindows)
      {
        Zone zone = new Zone(this, ZoneType.Hidden);
        zone.DockingPosition = enmPanelSide;
        zone.AddWindow(Relation.Inside, objWindow);
        objHiddenZones.Add(zone);
      }
      switch (enmPanelSide)
      {
        case DockStyle.Top:
          this.mobjTopPanel.AddNewZones(objHiddenZones);
          break;
        case DockStyle.Right:
          this.mobjRightPanel.AddNewZones(objHiddenZones);
          break;
        case DockStyle.Bottom:
          this.mobjBottomPanel.AddNewZones(objHiddenZones);
          break;
        case DockStyle.Left:
          this.mobjLeftPanel.AddNewZones(objHiddenZones);
          break;
        default:
          throw new Exception();
      }
    }

    /// <summary>Unregisters the place holder.</summary>
    /// <param name="objDockedWindowPlaceHolderDescriptor">The obj docked window place holder descriptor.</param>
    internal void UnregisterPlaceHolder(
      DockedWindowPlaceHolderDescriptor objDockedWindowPlaceHolderDescriptor)
    {
      switch (objDockedWindowPlaceHolderDescriptor.ZoneType)
      {
        case ZoneType.Dock:
          if (this.mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.Remove(objDockedWindowPlaceHolderDescriptor.WindowName))
            break;
          throw new Exception();
        case ZoneType.Float:
          if (this.mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.Remove(objDockedWindowPlaceHolderDescriptor.WindowName))
            break;
          throw new Exception();
        case ZoneType.Hidden:
          break;
        default:
          throw new Exception();
      }
    }

    /// <summary>Unregisters the split container.</summary>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    internal void UnregisterSplitContainer(DockedSplitContainer objDockedSplitContainer) => this.mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.Remove(objDockedSplitContainer.DockedSplitContainerDescriptorInternal);

    /// <summary>Uns the register zone.</summary>
    /// <param name="zone">The zone.</param>
    internal void UnRegisterZone(Zone zone)
    {
      this.mobjAllZones.Remove(zone);
      this.RefreshFormsDragTargets();
    }

    /// <summary>Updates the zones UI.</summary>
    private void UpdateZonesUI()
    {
      foreach (Zone mobjAllZone in this.mobjAllZones)
        mobjAllZone.UpdateUI();
    }

    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>Gets the docked manager descriptor internal.</summary>
    internal DockedManagerDescriptor DockedManagerDescriptorInternal => this.mobjData;

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
    {
      this.mobjData = objDescriptor as DockedManagerDescriptor;
      objDescriptor.UpdateSelf((Control) this, this);
    }

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition) => throw new NotImplementedException();

    /// <summary>Gets the type of the dock state according to zone.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns></returns>
    internal static DockState GetDockStateAccordingToZoneType(ZoneType objType)
    {
      switch (objType)
      {
        case ZoneType.Root:
          return DockState.Tabbed;
        case ZoneType.Dock:
          return DockState.Dock;
        case ZoneType.Float:
          return DockState.Float;
        case ZoneType.Hidden:
          return DockState.AutoHide;
        default:
          throw new NotSupportedException("ZoneType not supported: '" + objType.ToString() + "'");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private struct RemovedWindowsData
    {
      private DockingWindow[] mobjWindows;
      private DockState mobjDesiredDockState;
      private DockState menmPreviousDockState;
      private bool mblnHasDockingStateInfo;
      private bool mblnHasFloatingStateInfo;
      private DockStyle menmUnpinPosition;

      /// <summary>Gets or sets the unpin position.</summary>
      /// <value>The unpin position.</value>
      public DockStyle UnpinPosition
      {
        get => this.menmUnpinPosition;
        set => this.menmUnpinPosition = value;
      }

      /// <summary>
      /// Gets or sets a value indicating whether this instance has floating state info.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance has floating state info; otherwise, <c>false</c>.
      /// </value>
      public bool HasFloatingStateInfo
      {
        get => this.mblnHasFloatingStateInfo;
        set => this.mblnHasFloatingStateInfo = value;
      }

      /// <summary>
      /// Gets or sets a value indicating whether this instance has docking state info.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance has docking state info; otherwise, <c>false</c>.
      /// </value>
      public bool HasDockingStateInfo
      {
        get => this.mblnHasDockingStateInfo;
        set => this.mblnHasDockingStateInfo = value;
      }

      /// <summary>Gets or sets the state of the previous dock.</summary>
      /// <value>The state of the previous dock.</value>
      public DockState PreviousDockState
      {
        get => this.menmPreviousDockState;
        set => this.menmPreviousDockState = value;
      }

      /// <summary>Gets or sets the state of the desired dock.</summary>
      /// <value>The state of the desired dock.</value>
      public DockState DesiredDockState
      {
        get => this.mobjDesiredDockState;
        set => this.mobjDesiredDockState = value;
      }

      /// <summary>Gets or sets the windows.</summary>
      /// <value>The windows.</value>
      public DockingWindow[] Windows
      {
        get => this.mobjWindows;
        set => this.mobjWindows = value;
      }
    }
  }
}
