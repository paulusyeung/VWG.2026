// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedManagerDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class DockedManagerDescriptor : DockedObjectDescriptor
  {
    [NonSerialized]
    private DockingManager mobjManager;
    private List<DockedWindowDescriptor> mobjRootZoneWindows;
    private DockedHiddenZonePanelDescriptor mobjBottomHiddenWindowsDescriptor;
    private DockedHiddenZonePanelDescriptor mobjLeftHiddenWindowsDescriptor;
    private DockedHiddenZonePanelDescriptor mobjRightHiddenWindowsDescriptor;
    private DockedHiddenZonePanelDescriptor mobjTopHiddenWindowsDescriptor;
    private List<DockedWindowDescriptor> mobjDockedWindowsDescriptor;
    private List<DockedWindowDescriptor> mobjFloatedWindowsDescriptor;
    private List<DockedWindowDescriptor> mobjHiddenWindowsDescriptor;
    private bool mblnAllowShowDropDownButton;
    private bool mblnAllowTabbedDocuments;
    private bool mblnAllowCloseWindows;
    private bool mblnAllowFloatinWindows;
    private bool mblnAllowShowPinButton;
    private bool mblnShowMinimizeButton;
    private bool mblnShowMaximizeButton;
    private Dictionary<DockingWindowName, DockedFormDescriptor> mobjFormDescriptorIndexByWindowName;
    private ZoneDescriptor mobjRootZoneDescriptor;
    private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjWindowPlaceHoldersForDockedZonesIndexByWindowName;
    private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjWindowPlaceHoldersForFloatZonesIndexByWindowName;
    private int mintPinAnimationSpeed;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedManagerDescriptor" /> class.
    /// </summary>
    internal DockedManagerDescriptor(DockingManager objManager)
    {
      this.mobjManager = objManager;
      this.mobjRootZoneWindows = new List<DockedWindowDescriptor>();
      this.mobjFloatedWindowsDescriptor = new List<DockedWindowDescriptor>();
      this.mobjDockedWindowsDescriptor = new List<DockedWindowDescriptor>();
      this.mobjHiddenWindowsDescriptor = new List<DockedWindowDescriptor>();
      this.mobjFormDescriptorIndexByWindowName = new Dictionary<DockingWindowName, DockedFormDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
      this.mobjWindowPlaceHoldersForDockedZonesIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
      this.mobjWindowPlaceHoldersForFloatZonesIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
      this.mobjTopHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
      this.mobjRightHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
      this.mobjBottomHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
      this.mobjLeftHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
      this.mblnAllowShowDropDownButton = true;
      this.mblnAllowFloatinWindows = true;
      this.mblnAllowCloseWindows = true;
      this.mblnAllowShowPinButton = true;
      this.mblnShowMinimizeButton = true;
      this.mblnShowMaximizeButton = true;
      this.mintPinAnimationSpeed = (SkinFactory.GetSkin((ISkinable) objManager.HiddenPanel) as DockedHiddenZonesPanelSkin).HiddenZoneItemExpantionAnimationDuration;
    }

    /// <summary>Gets or sets the bottom hidden windows descriptor.</summary>
    /// <value>The bottom hidden windows descriptor.</value>
    public DockedHiddenZonePanelDescriptor BottomHiddenWindowsDescriptor
    {
      get => this.mobjBottomHiddenWindowsDescriptor;
      set => this.mobjBottomHiddenWindowsDescriptor = value;
    }

    /// <summary>Gets the docked windows descriptor.</summary>
    internal List<DockedWindowDescriptor> DockedWindowsDescriptor => this.mobjDockedWindowsDescriptor;

    /// <summary>Gets or sets the floated windows descriptor.</summary>
    /// <value>The floated windows descriptor.</value>
    public List<DockedWindowDescriptor> FloatedWindowsDescriptor => this.mobjFloatedWindowsDescriptor;

    /// <summary>Gets the hidden windows descriptor.</summary>
    internal List<DockedWindowDescriptor> HiddenWindowsDescriptor => this.mobjHiddenWindowsDescriptor;

    /// <summary>
    /// Gets or sets the name of the form descriptor index by window.
    /// </summary>
    /// <value>The name of the form descriptor index by window.</value>
    internal Dictionary<DockingWindowName, DockedFormDescriptor> FormDescriptorIndexByWindowName
    {
      get => this.mobjFormDescriptorIndexByWindowName;
      set => this.mobjFormDescriptorIndexByWindowName = value;
    }

    /// <summary>Gets or sets the left hidden windows descriptor.</summary>
    /// <value>The left hidden windows descriptor.</value>
    public DockedHiddenZonePanelDescriptor LeftHiddenWindowsDescriptor
    {
      get => this.mobjLeftHiddenWindowsDescriptor;
      set => this.mobjLeftHiddenWindowsDescriptor = value;
    }

    /// <summary>Gets the manager.</summary>
    public override DockingManager Manager => this.mobjManager;

    /// <summary>Gets or sets the right hidden windows descriptor.</summary>
    /// <value>The right hidden windows descriptor.</value>
    public DockedHiddenZonePanelDescriptor RightHiddenWindowsDescriptor
    {
      get => this.mobjRightHiddenWindowsDescriptor;
      set => this.mobjRightHiddenWindowsDescriptor = value;
    }

    /// <summary>Gets or sets the root zone descriptor.</summary>
    /// <value>The root zone descriptor.</value>
    internal ZoneDescriptor RootZoneDescriptor
    {
      get => this.mobjRootZoneDescriptor;
      set => this.mobjRootZoneDescriptor = value;
    }

    /// <summary>Gets or sets the top hidden windows descriptor.</summary>
    /// <value>The top hidden windows descriptor.</value>
    public DockedHiddenZonePanelDescriptor TopHiddenWindowsDescriptor
    {
      get => this.mobjTopHiddenWindowsDescriptor;
      set => this.mobjTopHiddenWindowsDescriptor = value;
    }

    /// <summary>
    /// Gets or sets the name of the window place holders for docked zones index by window.
    /// </summary>
    /// <value>
    /// The name of the window place holders for docked zones index by window.
    /// </value>
    internal Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> WindowPlaceHoldersForDockedZonesIndexByWindowName
    {
      get => this.mobjWindowPlaceHoldersForDockedZonesIndexByWindowName;
      set => this.mobjWindowPlaceHoldersForDockedZonesIndexByWindowName = value;
    }

    /// <summary>
    /// Gets or sets the name of the window place holders for float zones index by window.
    /// </summary>
    /// <value>
    /// The name of the window place holders for float zones index by window.
    /// </value>
    internal Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> WindowPlaceHoldersForFloatZonesIndexByWindowName
    {
      get => this.mobjWindowPlaceHoldersForFloatZonesIndexByWindowName;
      set => this.mobjWindowPlaceHoldersForFloatZonesIndexByWindowName = value;
    }

    /// <summary>Regisers the window.</summary>
    /// <param name="objWindowDescriptor">The docked window descriptor.</param>
    /// <param name="enmZoneType">Type of the enm zone.</param>
    internal void RegiserWindow(DockedWindowDescriptor objWindowDescriptor)
    {
      switch (objWindowDescriptor.CurrentDockState)
      {
        case DockState.Float:
          this.mobjFloatedWindowsDescriptor.Add(objWindowDescriptor);
          break;
        case DockState.Dock:
          this.mobjDockedWindowsDescriptor.Add(objWindowDescriptor);
          break;
        case DockState.Tabbed:
          this.mobjRootZoneWindows.Add(objWindowDescriptor);
          break;
        case DockState.AutoHide:
          break;
        case DockState.Hidden:
          this.mobjHiddenWindowsDescriptor.Add(objWindowDescriptor);
          break;
        case DockState.Close:
          break;
        default:
          throw new Exception();
      }
    }

    /// <summary>Removes the and return docked windows descriptors.</summary>
    /// <returns></returns>
    internal List<DockedWindowDescriptor> RemoveAndReturnDockedWindowsDescriptors()
    {
      List<DockedWindowDescriptor> windowsDescriptor = this.mobjDockedWindowsDescriptor;
      this.mobjDockedWindowsDescriptor = new List<DockedWindowDescriptor>();
      return windowsDescriptor;
    }

    /// <summary>Removes the and return docked windows descriptors.</summary>
    /// <returns></returns>
    internal List<DockedWindowDescriptor> RemoveAndReturnRootWindows()
    {
      List<DockedWindowDescriptor> mobjRootZoneWindows = this.mobjRootZoneWindows;
      this.mobjRootZoneWindows = new List<DockedWindowDescriptor>();
      return mobjRootZoneWindows;
    }

    /// <summary>Removes the and return float windows descriptors.</summary>
    /// <returns></returns>
    internal List<DockedWindowDescriptor> RemoveAndReturnFloatWindowsDescriptors()
    {
      List<DockedWindowDescriptor> windowsDescriptor = this.mobjFloatedWindowsDescriptor;
      this.mobjFloatedWindowsDescriptor = new List<DockedWindowDescriptor>();
      return windowsDescriptor;
    }

    /// <summary>Removes the and return hidden windows descriptors.</summary>
    /// <returns></returns>
    internal List<DockedWindowDescriptor> RemoveAndReturnHiddenWindowsDescriptors()
    {
      List<DockedWindowDescriptor> windowsDescriptor = this.mobjHiddenWindowsDescriptor;
      this.mobjHiddenWindowsDescriptor = new List<DockedWindowDescriptor>();
      return windowsDescriptor;
    }

    /// <summary>Unregisters the window.</summary>
    /// <param name="objWindowDescriptor">The docked window descriptor.</param>
    /// <param name="enmZoneType">Type of the enm zone.</param>
    internal void UnregisterWindow(DockedWindowDescriptor objWindowDescriptor)
    {
      switch (objWindowDescriptor.CurrentDockState)
      {
        case DockState.Float:
          this.mobjFloatedWindowsDescriptor.Remove(objWindowDescriptor);
          break;
        case DockState.Dock:
          this.mobjDockedWindowsDescriptor.Remove(objWindowDescriptor);
          break;
        case DockState.Tabbed:
          this.mobjRootZoneWindows.Remove(objWindowDescriptor);
          break;
        case DockState.AutoHide:
          break;
        case DockState.Hidden:
          this.mobjHiddenWindowsDescriptor.Remove(objWindowDescriptor);
          break;
        case DockState.Close:
          break;
        default:
          throw new Exception();
      }
    }

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    internal override void UpdateSelf(Control objControl, DockingManager objDockedManager) => this.mobjManager = objDockedManager;

    /// <summary>
    /// Gets or sets a value indicating whether [allow floating windows].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [allow allow floating windows]; otherwise, <c>false</c>.
    /// </value>
    internal bool AllowFloatingWindows
    {
      get => this.mblnAllowFloatinWindows;
      set => this.mblnAllowFloatinWindows = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow close windows].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [allow close windows]; otherwise, <c>false</c>.
    /// </value>
    internal bool AllowCloseWindows
    {
      get => this.mblnAllowCloseWindows;
      set => this.mblnAllowCloseWindows = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow tabbed documents].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [allow tabbed documents]; otherwise, <c>false</c>.
    /// </value>
    internal bool AllowTabbedDocuments
    {
      get => this.mblnAllowTabbedDocuments;
      set => this.mblnAllowTabbedDocuments = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow show pin button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [allow show pin button]; otherwise, <c>false</c>.
    /// </value>
    internal bool ShowPinButton
    {
      get => this.mblnAllowShowPinButton;
      set => this.mblnAllowShowPinButton = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow show drop down button].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [allow show drop down button]; otherwise, <c>false</c>.
    /// </value>
    internal bool ShowDropDownButton
    {
      get => this.mblnAllowShowDropDownButton;
      set => this.mblnAllowShowDropDownButton = value;
    }

    /// <summary>Gets or sets the pin animation speed.</summary>
    /// <value>The pin animation speed.</value>
    internal int PinAnimationSpeed
    {
      get => this.mintPinAnimationSpeed;
      set => this.mintPinAnimationSpeed = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show minimize button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show minimize button]; otherwise, <c>false</c>.
    /// </value>
    internal bool ShowMinimizeButton
    {
      get => this.mblnShowMinimizeButton;
      set => this.mblnShowMinimizeButton = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show maximize button].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [show maximize button]; otherwise, <c>false</c>.
    /// </value>
    internal bool ShowMaximizeButton
    {
      get => this.mblnShowMaximizeButton;
      set => this.mblnShowMaximizeButton = value;
    }
  }
}
