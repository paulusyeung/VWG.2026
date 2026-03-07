// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedTabControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A TabControl control</summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DockedTabControlSkin))]
  [ToolboxItem(false)]
  [Serializable]
  public class DockedTabControl : TabControl, IDescriptable, IPreventExtraction
  {
    private bool mblnPreventExtraction;
    private DockedTabControlDescriptor mobjData;
    private DockingManager mobjManager;
    private Zone mobjOwningZone;
    private Dictionary<DockingWindowName, DockedTabPage> mobjTabPagesIndexByTheirContainedDockedWindowName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabControl" /> class.
    /// </summary>
    /// <param name="mobjManager">The mobj manager.</param>
    public DockedTabControl(DockingManager mobjManager)
    {
      this.Visible = false;
      this.CustomStyle = "DockedTabContolSkin";
      this.SelectOnRightClick = true;
      this.mobjTabPagesIndexByTheirContainedDockedWindowName = new Dictionary<DockingWindowName, DockedTabPage>(DockingWindowName.DockedWindowNameEqulityComparer);
      this.mobjData = new DockedTabControlDescriptor();
      this.mobjManager = mobjManager;
    }

    /// <summary>
    /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
    /// </summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
    public override ContextMenuStrip ContextMenuStrip
    {
      get => this.OwningZone != null && this.OwningZone.Manager != null && this.Controls.Count > 0 ? this.OwningZone.Manager.GetDockedContextMenuStrip(this.OwningZone) : base.ContextMenuStrip;
      set
      {
      }
    }

    /// <summary>Gets the docked tab control descriptor internal.</summary>
    internal DockedTabControlDescriptor DockedTabControlDescriptorInternal => this.mobjData;

    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>Gets the owning zone.</summary>
    internal Zone OwningZone
    {
      get => this.mobjOwningZone;
      set => this.mobjOwningZone = value;
    }

    /// <summary>Gets the windows.</summary>
    public List<DockingWindow> Windows
    {
      get
      {
        List<DockingWindow> windows = new List<DockingWindow>();
        foreach (DockedTabPage tabPage in this.TabPages)
          windows.Add(tabPage.Window);
        return windows;
      }
    }

    /// <summary>
    /// Determines whether [is window selected] [the specified docked window].
    /// </summary>
    /// <param name="dockedWindow">The docked window.</param>
    /// <returns>
    ///   <c>true</c> if [is window selected] [the specified docked window]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsWindowSelected(DockingWindow dockedWindow)
    {
      DockedTabPage dockedTabPage;
      return this.mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(dockedWindow.WindowName, out dockedTabPage) && dockedTabPage.TabIndex == this.SelectedIndex;
    }

    /// <summary>Sets the state of the window selected.</summary>
    /// <param name="objDockedWindow">The docked window.</param>
    /// <param name="blnSelect">if set to <c>true</c> [value].</param>
    internal void SetWindowSelectedState(DockingWindow objDockedWindow, bool blnSelect)
    {
      DockedTabPage dockedTabPage;
      if (!this.mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(objDockedWindow.WindowName, out dockedTabPage))
        return;
      if (blnSelect)
      {
        this.SelectedIndex = dockedTabPage.TabIndex;
      }
      else
      {
        if (this.Controls.Count <= 1)
          return;
        if (dockedTabPage.TabIndex == 0)
          this.SelectedIndex = 1;
        else
          this.SelectedIndex = 0;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:ControlAdded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlAdded(ControlEventArgs e)
    {
      if (!(e.Control is DockedTabPage))
        return;
      base.OnControlAdded(e);
      DockedTabPage control = e.Control as DockedTabPage;
      ((IDescriptable) control.Window).Descriptor.UpdateFrom((Control) this, (object) this.mblnPreventExtraction);
      control.Window.OwningTabControl = this;
      this.Visible = true;
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlRemoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlRemoved(ControlEventArgs e)
    {
      if (!(e.Control is DockedTabPage))
        throw new Exception();
      base.OnControlRemoved(e);
      DockedTabPage control = e.Control as DockedTabPage;
      this.HandleWindowRemoved(control.Window);
      control.Window.OwningTabControl = (DockedTabControl) null;
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
      if (this.Controls.Count != 0)
        return;
      this.Visible = false;
      if (this.mblnPreventExtraction)
        return;
      this.Parent.Controls.Remove((Control) this);
    }

    /// <summary>Handles the window removed.</summary>
    /// <param name="objDockedWindow">The docked window.</param>
    private void HandleWindowRemoved(DockingWindow objDockedWindow)
    {
      if (this.mobjManager == null)
        throw new Exception();
      this.mobjManager.DockedWindows.RemoveWindow(objDockedWindow);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.TabControl.SelectedIndexChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnSelectedIndexChanged(EventArgs e)
    {
      base.OnSelectedIndexChanged(e);
      if (this.OwningZone == null)
        return;
      this.OwningZone.NotifyTabIndexChanged();
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor) => this.mobjData = objDescriptor as DockedTabControlDescriptor;

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
    {
      ((IPreventExtraction) this).DisableExtraction(true);
      foreach (DockingWindow window in this.Windows)
        this.RemoveWindow(window);
      this.mobjData = this.mobjData.CloneWithoutReferences<DockedTabControlDescriptor>();
      ((IPreventExtraction) this).DisableExtraction(false);
    }

    /// <summary>Disables the extraction.</summary>
    /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
    void IPreventExtraction.DisableExtraction(bool blnDisable) => this.mblnPreventExtraction = blnDisable;

    /// <summary>Adds the window.</summary>
    /// <param name="objWindow">The obj window.</param>
    internal void AddWindow(DockingWindow objWindow)
    {
      if (this.mobjTabPagesIndexByTheirContainedDockedWindowName.ContainsKey(objWindow.WindowName))
        return;
      DockState accordingToZoneType = DockingManager.GetDockStateAccordingToZoneType(this.OwningZone.ZoneType);
      objWindow.CurrentDockState = accordingToZoneType;
      DockedTabPage objValue = new DockedTabPage(objWindow);
      this.Controls.Add((Control) objValue);
      if (this.Controls.Count == 1)
        this.OwningZone.NotifyTabIndexChanged();
      if (!this.mobjManager.IsInLoadMode || this.Controls.Count == this.mobjData.SelectedIndex + 1)
        this.SelectedTab = (TabPage) objValue;
      this.mobjTabPagesIndexByTheirContainedDockedWindowName.Add(objWindow.WindowName, objValue);
      this.mobjManager.AddWindowToCorrectZoneTypeListInManagersDescriptor(objWindow);
    }

    /// <summary>Removes the window.</summary>
    /// <param name="objWindow">The obj window.</param>
    internal void RemoveWindow(DockingWindow objWindow) => this.RemoveWindow(objWindow.WindowName);

    /// <summary>Removes the window.</summary>
    /// <param name="strWindowName">Name of the STR window.</param>
    internal void RemoveWindow(DockingWindowName strWindowName)
    {
      DockedTabPage dockedTabPage;
      if (this.mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(strWindowName, out dockedTabPage))
      {
        this.mobjManager.RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(dockedTabPage.Window, this.OwningZone.ZoneType);
        this.mobjTabPagesIndexByTheirContainedDockedWindowName.Remove(strWindowName);
        dockedTabPage.Controls.Clear();
      }
      else if (!this.mblnPreventExtraction)
        throw new Exception("This zone does not contain the given window");
    }

    /// <summary>Windows the image changed.</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    internal void WindowImageChanged(DockingWindow objDockedWindow) => this.mobjTabPagesIndexByTheirContainedDockedWindowName[objDockedWindow.WindowName].Image = objDockedWindow.Image;
  }
}
