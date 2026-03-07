// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedTabPage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [ToolboxItem(false)]
  [Serializable]
  public class DockedTabPage : TabPage
  {
    private DockingWindow objDockedWindow;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabPage" /> class.
    /// </summary>
    /// <param name="objWindow">The obj window.</param>
    public DockedTabPage(DockingWindow objWindow)
      : base(objWindow.Text)
    {
      this.Image = objWindow.Image;
      this.HeaderToolTip = objWindow.TabHeaderToolTip;
      this.Controls.Add((Control) objWindow);
    }

    /// <summary>
    /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
    /// </summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
    public override ContextMenuStrip ContextMenuStrip
    {
      get => this.Parent != null && this.Parent.Parent != null ? this.Parent.Parent.ContextMenuStrip : base.ContextMenuStrip;
      set => base.ContextMenuStrip = value;
    }

    /// <summary>Gets the window.</summary>
    public DockingWindow Window => this.objDockedWindow;

    /// <summary>
    /// Raises the <see cref="E:ControlAdded" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlAdded(ControlEventArgs e)
    {
      if (!(e.Control is DockingWindow))
        throw new Exception();
      base.OnControlAdded(e);
      this.objDockedWindow = e.Control as DockingWindow;
    }

    /// <summary>
    /// Raises the <see cref="E:ControlRemoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlRemoved(ControlEventArgs e)
    {
      if (!(e.Control is DockingWindow))
        throw new Exception();
      base.OnControlRemoved(e);
      this.Parent.Controls.Remove((Control) this);
    }
  }
}
