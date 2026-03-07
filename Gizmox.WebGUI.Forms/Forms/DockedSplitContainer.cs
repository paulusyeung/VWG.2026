// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedSplitContainer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DockedSplitContainer : SplitContainer, IDescriptable, IPreventExtraction
  {
    private bool mblnPreventExtraction;
    private DockedSplitContainerDescriptor mobjData;
    private DockingManager mobjManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedSplitContainer" /> class.
    /// </summary>
    /// <param name="objManager">The obj manager.</param>
    public DockedSplitContainer(DockingManager objManager)
    {
      this.mblnPreventExtraction = false;
      this.mobjManager = objManager;
      this.Dock = DockStyle.Fill;
      this.mobjData = new DockedSplitContainerDescriptor();
      this.BorderStyle = BorderStyle.None;
      this.Panel1.ControlAdded += new ControlEventHandler(this.Panel1_ControlAdded);
      this.Panel2.ControlAdded += new ControlEventHandler(this.Panel2_ControlAdded);
      this.Panel1.ControlRemoved += new ControlEventHandler(this.Panel1_ControlRemoved);
      this.Panel2.ControlRemoved += new ControlEventHandler(this.Panel2_ControlRemoved);
      this.Panel2Collapsed = true;
    }

    /// <summary>Gets the docked split container descriptor internal.</summary>
    internal DockedSplitContainerDescriptor DockedSplitContainerDescriptorInternal => this.mobjData;

    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>Gets the windows.</summary>
    public List<DockingWindow> Windows
    {
      get
      {
        List<DockingWindow> windowsFromPanel = this.HandleGetWindowsFromPanel(this.Panel1);
        windowsFromPanel.AddRange((IEnumerable<DockingWindow>) this.HandleGetWindowsFromPanel(this.Panel2));
        return windowsFromPanel;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:SplitterMoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event data.</param>
    public override void OnSplitterMoved(SplitterEventArgs e)
    {
      base.OnSplitterMoved(e);
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>
    /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
    /// </summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.mobjManager.RegisterSplitContainer(this);
    }

    /// <summary>Handles the panel.</summary>
    /// <param name="objPanel">The obj panel.</param>
    /// <returns></returns>
    private List<DockingWindow> HandleGetWindowsFromPanel(SplitterPanel objPanel)
    {
      List<DockingWindow> windowsFromPanel = new List<DockingWindow>();
      if (objPanel.Controls.Count == 1)
      {
        if (objPanel.Controls[0] is Zone)
          windowsFromPanel.AddRange((IEnumerable<DockingWindow>) (objPanel.Controls[0] as Zone).Windows);
        else if (objPanel.Controls[0] is DockedSplitContainer)
          windowsFromPanel.AddRange((IEnumerable<DockingWindow>) (objPanel.Controls[0] as DockedSplitContainer).Windows);
      }
      return windowsFromPanel;
    }

    /// <summary>Hides the panel1.</summary>
    private void HidePanel1()
    {
      if (this.Panel2Collapsed || this.Panel2.Controls.Count == 0)
      {
        this.RemoveFromParent();
      }
      else
      {
        this.Panel1Collapsed = true;
        this.mobjData.UpdateSelf((Control) this, this.mobjManager);
      }
    }

    /// <summary>Hides the panel2.</summary>
    private void HidePanel2()
    {
      if (this.Panel1Collapsed || this.Panel1.Controls.Count == 0)
      {
        this.RemoveFromParent();
      }
      else
      {
        this.Panel2Collapsed = true;
        this.mobjData.UpdateSelf((Control) this, this.mobjManager);
      }
    }

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
    {
      if (!(objDescriptor is DockedSplitContainerDescriptor containerDescriptor))
        throw new Exception();
      try
      {
        this.Orientation = containerDescriptor.Orientation;
        this.SplitterDistance = containerDescriptor.SplitterDistance;
      }
      finally
      {
        this.mobjData = containerDescriptor;
        this.mobjManager.RegisterSplitContainer(this);
      }
    }

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
    {
      this.mobjData = this.mobjData.CloneWithoutReferences<DockedSplitContainerDescriptor>();
      this.mobjManager.RegisterSplitContainer(this);
      if (this.Panel1.Controls.Count == 1)
      {
        IDescriptable control = this.Panel1.Controls[0] as IDescriptable;
        control.ResetDescriptorsTree(objType, objDockingPosition);
        control.Descriptor.UpdateFrom((Control) this, (object) 1);
      }
      if (this.Panel2.Controls.Count != 1)
        return;
      IDescriptable control1 = this.Panel2.Controls[0] as IDescriptable;
      control1.ResetDescriptorsTree(objType, objDockingPosition);
      control1.Descriptor.UpdateFrom((Control) this, (object) 2);
    }

    /// <summary>Disables the extraction.</summary>
    /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
    void IPreventExtraction.DisableExtraction(bool blnDisable) => this.mblnPreventExtraction = blnDisable;

    /// <summary>Handles the ControlAdded event of the Panel1 control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void Panel1_ControlAdded(object sender, ControlEventArgs e)
    {
      if (!(e.Control is IDescriptable))
        throw new Exception("DockedSplitContainer.Panel1 can contain only zones or other DockingSplitContainers");
      this.Panel1ControlAdded(e.Control);
    }

    /// <summary>
    /// Handles the ControlRemoved event of the Panel1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void Panel1_ControlRemoved(object sender, ControlEventArgs e)
    {
      if (e.Control is IDescriptable)
        (e.Control as IDescriptable).Descriptor.UpdateFrom((Control) this, (object) 1);
      if (this.Panel1.Controls.Count != 0 || this.mblnPreventExtraction)
        return;
      this.HidePanel1();
    }

    /// <summary>Panel1s the control added.</summary>
    /// <param name="objControl">The obj control.</param>
    private void Panel1ControlAdded(Control objControl)
    {
      this.ShowPanel1();
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
      (objControl as IDescriptable).Descriptor.UpdateFrom((Control) this, (object) 1);
    }

    /// <summary>Handles the ControlAdded event of the Panel2 control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void Panel2_ControlAdded(object sender, ControlEventArgs e)
    {
      if (!(e.Control is IDescriptable))
        throw new Exception("DockedSplitContainer.Panel2 can contain only zones or other DockingSplitContainers");
      this.Panel2ControlAdded(e.Control);
    }

    /// <summary>
    /// Handles the ControlRemoved event of the Panel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void Panel2_ControlRemoved(object sender, ControlEventArgs e)
    {
      if (e.Control is IDescriptable)
        (e.Control as IDescriptable).Descriptor.UpdateFrom((Control) this, (object) 2);
      if (this.Panel2.Controls.Count != 0 || this.mblnPreventExtraction)
        return;
      this.HidePanel2();
    }

    /// <summary>Panel2s the control added.</summary>
    /// <param name="objControl">The obj control.</param>
    private void Panel2ControlAdded(Control objControl)
    {
      this.ShowPanel2();
      ((IDescriptable) this).Descriptor.UpdateSelf((Control) this, this.mobjManager);
      (objControl as IDescriptable).Descriptor.UpdateFrom((Control) this, (object) 2);
    }

    /// <summary>Removes from parent.</summary>
    /// <returns></returns>
    private int RemoveFromParent()
    {
      this.mobjManager.UnregisterSplitContainer(this);
      int childIndex = this.Parent.Controls.GetChildIndex((Control) this);
      this.Parent.Controls.Remove((Control) this);
      return childIndex;
    }

    /// <summary>Shows the panel1.</summary>
    private void ShowPanel1()
    {
      this.Panel1Collapsed = false;
      if (this.Panel2.Controls.Count == 0)
      {
        this.Panel2Collapsed = true;
      }
      else
      {
        this.SplitterDistance = this.mobjData.SplitterDistance;
        this.Panel2Collapsed = false;
      }
    }

    /// <summary>Shows the panel2.</summary>
    private void ShowPanel2()
    {
      this.Panel2Collapsed = false;
      if (this.Panel1.Controls.Count == 0)
      {
        this.Panel1Collapsed = true;
      }
      else
      {
        this.SplitterDistance = this.mobjData.SplitterDistance;
        this.Panel1Collapsed = false;
      }
    }

    /// <summary>Removes the panel.</summary>
    /// <param name="intPanelSide">The int panel side.</param>
    internal void HardRemovePanel(int intPanelSide)
    {
      Control control = (Control) null;
      SplitterPanel splitterPanel1;
      SplitterPanel splitterPanel2;
      if (intPanelSide == 1)
      {
        splitterPanel1 = this.Panel1;
        splitterPanel2 = this.Panel2;
      }
      else
      {
        if (intPanelSide != 2)
          throw new Exception();
        splitterPanel1 = this.Panel2;
        splitterPanel2 = this.Panel1;
      }
      if (splitterPanel2.Controls.Count > 0)
      {
        ((IPreventExtraction) this).DisableExtraction(true);
        control = splitterPanel2.Controls[0];
        splitterPanel2.Controls.Remove(control);
      }
      splitterPanel1.Controls.Clear();
      ((IPreventExtraction) this).DisableExtraction(false);
      if (control == null)
        return;
      Control parent = this.Parent;
      Control logicalParentControl = DockedManagerHelper.GetLogicalParentControl((Control) this);
      if (logicalParentControl is IPreventExtraction)
        (logicalParentControl as IPreventExtraction).DisableExtraction(true);
      int intNewIndex = this.RemoveFromParent();
      if (logicalParentControl is IPreventExtraction)
        (logicalParentControl as IPreventExtraction).DisableExtraction(false);
      parent.Controls.Add(control);
      parent.Controls.SetChildIndex(control, intNewIndex);
    }

    /// <summary>Updates the focused control state</summary>
    internal override void UpdateFocusedControl()
    {
    }
  }
}
