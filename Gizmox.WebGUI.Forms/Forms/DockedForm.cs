// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedForm
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DockedForm : Form, IDescriptable, IPreventExtraction
  {
    private bool mblnPreventExtraction;
    private DockedFormDescriptor mobjData;
    private DockingManager mobjManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedForm" /> class.
    /// </summary>
    /// <param name="objManager">The obj manager.</param>
    public DockedForm(DockingManager objManager)
    {
      this.mobjData = new DockedFormDescriptor();
      this.TopLevel = true;
      this.mobjManager = objManager;
      this.mblnPreventExtraction = false;
      this.AllowDragTargetsPropagation = false;
    }

    /// <summary>Gets the windows.</summary>
    public List<DockingWindow> Windows
    {
      get
      {
        Control control = (Control) null;
        if (this.Controls.Count > 0)
          control = this.Controls[0];
        switch (control)
        {
          case Zone _:
            return (control as Zone).Windows;
          case DockedSplitContainer _:
            return (control as DockedSplitContainer).Windows;
          default:
            return (List<DockingWindow>) null;
        }
      }
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(300, 300);

    /// <summary>Gets the docked form descriptor internal.</summary>
    internal DockedFormDescriptor DockedFormDescriptorInternal => this.mobjData;

    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>Gets the manager.</summary>
    public DockingManager Manager => this.mobjManager;

    /// <summary>Called when [window state changed].</summary>
    /// <param name="enmNewFormWindowState">State of the enm new form window.</param>
    protected override void OnWindowStateChanged(FormWindowState enmNewFormWindowState)
    {
      base.OnWindowStateChanged(enmNewFormWindowState);
      this.mobjData.UpdateSelf((Control) this, this.Manager);
    }

    /// <summary>Occurs when control is created</summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.mobjData.OwningFormId = this.ID;
    }

    /// <summary>Disables the extraction.</summary>
    /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
    public void DisableExtraction(bool blnDisable) => this.mblnPreventExtraction = blnDisable;

    /// <summary>
    /// Raises the <see cref="E:Closing" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      this.mobjData.FormClosing();
    }

    /// <summary>
    /// Raises the <see cref="E:ControlAdded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlAdded(ControlEventArgs e)
    {
      if (!(e.Control is IDescriptable))
        return;
      base.OnControlAdded(e);
      this.Show();
      (e.Control as IDescriptable).Descriptor.UpdateFrom((Control) this, (object) null);
      this.HandleAddingControl(e.Control, true);
    }

    /// <summary>
    /// Raises the <see cref="E:ControlRemoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlRemoved(ControlEventArgs e)
    {
      base.OnControlRemoved(e);
      this.HandleAddingControl(e.Control, false);
      if (this.Controls.Count != 0 || this.mblnPreventExtraction)
        return;
      this.Close();
      this.Dispose();
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnLocationChanged(LayoutEventArgs e)
    {
      base.OnLocationChanged(e);
      this.mobjData.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      this.mobjData.UpdateSelf((Control) this, this.mobjManager);
    }

    /// <summary>Controls the added listener.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="blnAddListener">if set to <c>true</c> [BLN add listener].</param>
    private void HandleAddingControl(Control objControl, bool blnAddListener)
    {
      if (objControl is DockingWindow & blnAddListener)
      {
        this.Manager.SetWindowFormMapping(objControl as DockingWindow, this.mobjData);
      }
      else
      {
        if (objControl is Zone zone)
        {
          zone.OwningFormId = this.ID;
          if (blnAddListener)
          {
            zone.ZoneType = ZoneType.Float;
            List<Component> componentList = new List<Component>();
            foreach (Component dragTarget in this.DragTargets)
            {
              if (dragTarget.ID != zone.ID)
                componentList.Add(dragTarget);
            }
            this.DragTargets = componentList.ToArray();
          }
          else
            zone.OwningFormId = -1L;
        }
        if (blnAddListener)
        {
          objControl.ControlAdded += new ControlEventHandler(this.objControl_ControlAdded);
          objControl.ControlRemoved += new ControlEventHandler(this.objControl_ControlRemoved);
        }
        else
        {
          objControl.ControlAdded -= new ControlEventHandler(this.objControl_ControlAdded);
          objControl.ControlRemoved -= new ControlEventHandler(this.objControl_ControlRemoved);
        }
        foreach (Control control in (ArrangedElementCollection) objControl.Controls)
          this.HandleAddingControl(control, blnAddListener);
      }
    }

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
    {
      this.Size = objDescriptor is DockedFormDescriptor dockedFormDescriptor ? dockedFormDescriptor.Size : throw new Exception();
      this.StartPosition = FormStartPosition.Manual;
      this.Location = dockedFormDescriptor.Location;
      this.WindowState = dockedFormDescriptor.WindowState;
      this.mobjData = dockedFormDescriptor;
    }

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition) => throw new NotImplementedException();

    /// <summary>
    /// Handles the ControlAdded event of the objControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void objControl_ControlAdded(object sender, ControlEventArgs e) => this.HandleAddingControl(e.Control, true);

    /// <summary>
    /// Handles the ControlRemoved event of the objControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    private void objControl_ControlRemoved(object sender, ControlEventArgs e) => this.HandleAddingControl(e.Control, false);

    /// <summary>Sets the drag targets.</summary>
    /// <param name="arrComponenets">The arr componenets.</param>
    internal void SetDragTargets(Component[] arrComponenets) => this.DragTargets = arrComponenets;
  }
}
