// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedContextMenuStrip
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
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
  public class DockedContextMenuStrip : ContextMenuStrip
  {
    private ToolStripMenuItem mobjAutoHideButton;
    private ToolStripMenuItem mobjDockButton;
    private ToolStripMenuItem mobjFloatButton;
    private ToolStripMenuItem mobjHideButton;
    private ToolStripMenuItem mobjDockCurrentToRoot;
    private ToolStripMenuItem mobjDockAllToRoot;
    private ToolStripMenuItem mobjDockCurrentRight;
    private ToolStripMenuItem mobjDockCurrentBottom;
    private ToolStripMenuItem mobjDockCurrentLeft;
    private ToolStripMenuItem mobjDockCurrentTop;
    private ToolStripSeparator mobjSeperator;
    private ToolStripMenuItem mobjDockAllRight;
    private ToolStripMenuItem mobjDockAllBottom;
    private ToolStripMenuItem mobjDockAllLeft;
    private ToolStripMenuItem mobjDockAllTop;
    private DockingManager mobjManager;
    private ToolStripMenuItem mobjTabDocumentButton;
    private Zone mobjZone;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedContextMenuStrip" /> class.
    /// </summary>
    public DockedContextMenuStrip(DockingManager objManager)
    {
      this.mobjManager = objManager;
      this.InitializeConponent();
    }

    /// <summary>Shows the specified zone's Context menu.</summary>
    /// <param name="objZone">The obj zone.</param>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objPosition">The obj position.</param>
    /// <param name="objDirection">The obj direction.</param>
    public void Show(
      Zone objZone,
      Control objControl,
      Point objPosition,
      ToolStripDropDownDirection objDirection)
    {
      this.SetZone(objZone);
      this.Show((Component) objControl, objPosition, objDirection);
    }

    /// <summary>Initializes the conponent.</summary>
    private void InitializeConponent()
    {
      this.mobjFloatButton = new ToolStripMenuItem();
      this.mobjDockButton = new ToolStripMenuItem();
      this.mobjTabDocumentButton = new ToolStripMenuItem();
      this.mobjAutoHideButton = new ToolStripMenuItem();
      this.mobjHideButton = new ToolStripMenuItem();
      this.mobjDockCurrentToRoot = new ToolStripMenuItem();
      this.mobjDockAllToRoot = new ToolStripMenuItem();
      this.mobjDockCurrentRight = new ToolStripMenuItem();
      this.mobjDockCurrentBottom = new ToolStripMenuItem();
      this.mobjDockCurrentLeft = new ToolStripMenuItem();
      this.mobjDockCurrentTop = new ToolStripMenuItem();
      this.mobjSeperator = new ToolStripSeparator();
      this.mobjDockAllRight = new ToolStripMenuItem();
      this.mobjDockAllBottom = new ToolStripMenuItem();
      this.mobjDockAllLeft = new ToolStripMenuItem();
      this.mobjDockAllTop = new ToolStripMenuItem();
      this.mobjFloatButton.Click += new EventHandler(this.mobjFloatButton_Click);
      this.mobjFloatButton.Text = SR.GetString("WGFloating");
      this.mobjDockButton.Click += new EventHandler(this.mobjDockButton_Click);
      this.mobjDockButton.Text = SR.GetString("WGDockable");
      this.mobjTabDocumentButton.Click += new EventHandler(this.mobjTabDocumentButton_Click);
      this.mobjTabDocumentButton.Text = SR.GetString("WGTabbedDocument");
      this.mobjAutoHideButton.Click += new EventHandler(this.mobjAutoHideButton_Click);
      this.mobjAutoHideButton.Text = SR.GetString("WGAutoHide");
      this.mobjHideButton.Click += new EventHandler(this.mobjHideButton_Click);
      this.mobjHideButton.Text = SR.GetString("WGHide");
      this.mobjDockCurrentToRoot.Text = SR.GetString("WGGloballyDockCurrentWindow");
      this.mobjDockCurrentToRoot.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.mobjDockCurrentRight,
        (ToolStripItem) this.mobjDockCurrentBottom,
        (ToolStripItem) this.mobjDockCurrentLeft,
        (ToolStripItem) this.mobjDockCurrentTop
      });
      this.mobjDockAllToRoot.Text = SR.GetString("WGGloballyDockAllWindow");
      this.mobjDockAllToRoot.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.mobjDockAllRight,
        (ToolStripItem) this.mobjDockAllBottom,
        (ToolStripItem) this.mobjDockAllLeft,
        (ToolStripItem) this.mobjDockAllTop
      });
      ResourceHandle resourceHandle1 = (ResourceHandle) new SkinResourceHandle(typeof (ZoneSkin), "Top_Global16x16.png");
      ResourceHandle resourceHandle2 = (ResourceHandle) new SkinResourceHandle(typeof (ZoneSkin), "Right_Global16x16.png");
      ResourceHandle resourceHandle3 = (ResourceHandle) new SkinResourceHandle(typeof (ZoneSkin), "Bottom_Global16x16.png");
      ResourceHandle resourceHandle4 = (ResourceHandle) new SkinResourceHandle(typeof (ZoneSkin), "Left_Global16x16.png");
      this.mobjDockCurrentRight.Text = SR.GetString("WGRight");
      this.mobjDockCurrentRight.Tag = (object) Relation.ToTheRight;
      this.mobjDockCurrentRight.Click += new EventHandler(this.mobjDockCurrent_Click);
      this.mobjDockCurrentRight.Image = resourceHandle2;
      this.mobjDockCurrentBottom.Text = SR.GetString("WGBottom");
      this.mobjDockCurrentBottom.Tag = (object) Relation.Below;
      this.mobjDockCurrentBottom.Click += new EventHandler(this.mobjDockCurrent_Click);
      this.mobjDockCurrentBottom.Image = resourceHandle3;
      this.mobjDockCurrentLeft.Text = SR.GetString("WGLeft");
      this.mobjDockCurrentLeft.Tag = (object) Relation.ToTheLeft;
      this.mobjDockCurrentLeft.Click += new EventHandler(this.mobjDockCurrent_Click);
      this.mobjDockCurrentLeft.Image = resourceHandle4;
      this.mobjDockCurrentTop.Text = SR.GetString("WGTop");
      this.mobjDockCurrentTop.Tag = (object) Relation.Above;
      this.mobjDockCurrentTop.Click += new EventHandler(this.mobjDockCurrent_Click);
      this.mobjDockCurrentTop.Image = resourceHandle1;
      this.mobjDockAllRight.Text = SR.GetString("WGRight");
      this.mobjDockAllRight.Tag = (object) Relation.ToTheRight;
      this.mobjDockAllRight.Click += new EventHandler(this.mobjDockAll_Click);
      this.mobjDockAllRight.Image = resourceHandle2;
      this.mobjDockAllBottom.Text = SR.GetString("WGBottom");
      this.mobjDockAllBottom.Tag = (object) Relation.Below;
      this.mobjDockAllBottom.Click += new EventHandler(this.mobjDockAll_Click);
      this.mobjDockAllBottom.Image = resourceHandle3;
      this.mobjDockAllLeft.Text = SR.GetString("WGLeft");
      this.mobjDockAllLeft.Tag = (object) Relation.ToTheLeft;
      this.mobjDockAllLeft.Click += new EventHandler(this.mobjDockAll_Click);
      this.mobjDockAllLeft.Image = resourceHandle4;
      this.mobjDockAllTop.Text = SR.GetString("WGTop");
      this.mobjDockAllTop.Tag = (object) Relation.Above;
      this.mobjDockAllTop.Click += new EventHandler(this.mobjDockAll_Click);
      this.mobjDockAllTop.Image = resourceHandle1;
      this.Items.Add((ToolStripItem) this.mobjFloatButton);
      this.Items.Add((ToolStripItem) this.mobjDockButton);
      this.Items.Add((ToolStripItem) this.mobjTabDocumentButton);
      this.Items.Add((ToolStripItem) this.mobjAutoHideButton);
      this.Items.Add((ToolStripItem) this.mobjHideButton);
      this.Items.Add((ToolStripItem) this.mobjDockCurrentToRoot);
      this.Items.Add((ToolStripItem) this.mobjDockAllToRoot);
    }

    /// <summary>Handles the Click event of the mobjDockAll control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjDockAll_Click(object sender, EventArgs e)
    {
      List<DockingWindow> dockingWindowList = this.mobjZone.RemoveAndReturnAllWindows();
      this.mobjManager.AddDockedWindowsInRootPosition((Relation) (sender as ToolStripMenuItem).Tag, dockingWindowList.ToArray());
    }

    /// <summary>
    /// Handles the Click event of the mobjDockCurrent control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjDockCurrent_Click(object sender, EventArgs e) => this.mobjManager.AddDockedWindowsInRootPosition((Relation) (sender as ToolStripMenuItem).Tag, this.mobjZone.RemoveAndReturnCurrentWindow());

    /// <summary>Initializes the items.</summary>
    private void InitializeItems()
    {
      switch (this.mobjZone.ZoneType)
      {
        case ZoneType.Root:
          this.mobjFloatButton.Enabled = true;
          this.mobjDockButton.Enabled = true;
          this.mobjTabDocumentButton.Enabled = false;
          this.mobjAutoHideButton.Enabled = false;
          this.mobjHideButton.Enabled = true;
          this.mobjDockCurrentToRoot.Visible = true;
          this.mobjDockAllToRoot.Visible = true;
          break;
        case ZoneType.Dock:
          this.mobjFloatButton.Enabled = true;
          this.mobjDockButton.Enabled = false;
          this.mobjTabDocumentButton.Enabled = true;
          this.mobjAutoHideButton.Enabled = true;
          this.mobjHideButton.Enabled = true;
          this.mobjDockCurrentToRoot.Visible = true;
          this.mobjDockAllToRoot.Visible = true;
          break;
        case ZoneType.Float:
          this.mobjFloatButton.Enabled = false;
          this.mobjDockButton.Enabled = true;
          this.mobjTabDocumentButton.Enabled = true;
          this.mobjAutoHideButton.Enabled = false;
          this.mobjHideButton.Enabled = true;
          this.mobjDockCurrentToRoot.Visible = true;
          this.mobjDockAllToRoot.Visible = true;
          break;
        case ZoneType.Hidden:
          this.mobjFloatButton.Enabled = true;
          this.mobjDockButton.Enabled = true;
          this.mobjTabDocumentButton.Enabled = true;
          this.mobjAutoHideButton.Enabled = false;
          this.mobjHideButton.Enabled = true;
          this.mobjDockCurrentToRoot.Visible = false;
          this.mobjDockAllToRoot.Visible = false;
          break;
        default:
          throw new Exception();
      }
      this.mobjFloatButton.Visible = this.mobjManager.AllowFloatingWindows;
      this.mobjTabDocumentButton.Visible = this.mobjManager.AllowTabbedDocuments;
      this.mobjHideButton.Visible = this.mobjManager.AllowCloseWindows;
    }

    /// <summary>
    /// Handles the Click event of the mobjAutoHideButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjAutoHideButton_Click(object sender, EventArgs e)
    {
      this.Close();
      this.mobjZone.ToggleAutoHide();
    }

    /// <summary>
    /// Handles the Click event of the mobjDockButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjDockButton_Click(object sender, EventArgs e)
    {
      this.Close();
      this.mobjZone.SwitchCurrentWindowDockState(DockState.Dock);
    }

    /// <summary>
    /// Handles the Click event of the mobjFloatButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjFloatButton_Click(object sender, EventArgs e)
    {
      this.Close();
      this.mobjZone.SwitchCurrentWindowDockState(DockState.Float);
    }

    /// <summary>
    /// Handles the Click event of the mobjHideButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjHideButton_Click(object sender, EventArgs e)
    {
      this.Close();
      this.mobjZone.HideCurrentWindow();
    }

    /// <summary>
    /// Handles the Click event of the mobjTabDocumentButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void mobjTabDocumentButton_Click(object sender, EventArgs e)
    {
      this.Close();
      this.mobjZone.SwitchCurrentWindowDockState(DockState.Tabbed);
    }

    /// <summary>Sets the zone.</summary>
    /// <param name="objZone">The obj zone.</param>
    /// <returns></returns>
    internal DockedContextMenuStrip SetZone(Zone objZone)
    {
      this.mobjZone = objZone;
      this.InitializeItems();
      if (this.mobjZone.Windows.Count > 1)
        this.mobjDockAllToRoot.Enabled = true;
      else
        this.mobjDockAllToRoot.Enabled = false;
      return this;
    }
  }
}
