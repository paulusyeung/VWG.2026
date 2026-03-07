// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockingWindow
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxItem(false)]
  [Serializable]
  public class DockingWindow : UserControl, IDescriptable
  {
    internal static readonly SerializableEvent EVENT_DOCKEDWINDOWNAMECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (DockingWindow));
    /// <summary>Provides a property reference to Image property.</summary>
    private static SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (DockingWindow), new SerializablePropertyMetadata((object) null));
    private DockedWindowDescriptor mobjData;
    private ResourceHandle mobjImage;
    private DockedTabControl mobjOwningTabControl;
    private DockingManager mobjManager;
    private Size mobjHiddenZonePopupSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> class.
    /// </summary>
    public DockingWindow()
    {
      this.mobjData = new DockedWindowDescriptor(this);
      this.mobjData.CurrentDockState = DockState.Close;
      this.InitializeDockedWindow();
    }

    /// <summary>Gets/Sets the controls docking style</summary>
    public override DockStyle Dock
    {
      get => DockStyle.Fill;
      set
      {
      }
    }

    /// <summary>Gets or sets the last state of the dock.</summary>
    /// <value>The last state of the dock.</value>
    internal DockState LastDockState
    {
      get => this.mobjData.LastDockState;
      set => this.mobjData.LastDockState = value;
    }

    /// <summary>Gets or sets the header text.</summary>
    /// <value>The header text.</value>
    [DefaultValue(null)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public string HeaderText
    {
      get => !string.IsNullOrEmpty(this.mobjData.HeaderText) ? this.mobjData.HeaderText : this.Text;
      set
      {
        if (!(this.mobjData.HeaderText != value))
          return;
        this.mobjData.HeaderText = value;
        if (!this.IsSelectedTab)
          return;
        this.OwningZone.NotifyHeaderTextChanged(this);
      }
    }

    /// <summary>Gets or sets the header tool tip.</summary>
    /// <value>The header tool tip.</value>
    [DefaultValue(null)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public string HeaderToolTip
    {
      get => this.mobjData.HeaderToolTip;
      set
      {
        if (!(this.mobjData.HeaderToolTip != value))
          return;
        this.mobjData.HeaderToolTip = value;
        if (this.IsSelectedTab)
          this.OwningZone.NotifyWindowHeaderAttributeChanged(this);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the tab header tool tip.</summary>
    /// <value>The tab header tool tip.</value>
    [DefaultValue(null)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public string TabHeaderToolTip
    {
      get => this.mobjData.TabHeaderToolTip;
      set
      {
        if (!(this.mobjData.TabHeaderToolTip != value))
          return;
        this.mobjData.TabHeaderToolTip = value;
        if (this.Parent == null || !(this.Parent is DockedTabPage))
          return;
        (this.Parent as DockedTabPage).HeaderToolTip = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is selected tab.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is selected tab; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSelectedTab
    {
      get => this.mobjOwningTabControl != null && this.mobjOwningTabControl.IsWindowSelected(this);
      set
      {
        if (this.mobjOwningTabControl == null)
          return;
        this.mobjOwningTabControl.SetWindowSelectedState(this, value);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is closed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if closed; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Closed
    {
      get => this.CurrentDockState == DockState.Close;
      set
      {
        if (value)
          this.Close();
        else
          this.Show();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is pinned.
    /// </summary>
    /// <value>
    ///   <c>true</c> if pinned; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Pinned
    {
      get => this.CurrentDockState == DockState.AutoHide;
      set
      {
        if (value)
          this.Pin();
        else
          this.Unpin();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is docked.
    /// </summary>
    /// <value>
    ///   <c>true</c> if docked; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Docked
    {
      get => this.CurrentDockState == DockState.Dock;
      set
      {
        if (value)
          this.SetDock();
        else
          this.SetFloat();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is floated.
    /// </summary>
    /// <value>
    ///   <c>true</c> if floated; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Floated
    {
      get => this.CurrentDockState == DockState.Float;
      set
      {
        if (value)
          this.SetFloat();
        else
          this.SetDock();
      }
    }

    /// <summary>Gets or sets the state of the current dock.</summary>
    /// <value>The state of the current dock.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DockState CurrentDockState
    {
      get => this.mobjData.CurrentDockState;
      internal set => this.mobjData.CurrentDockState = value;
    }

    /// <summary>Gets the manager.</summary>
    public DockingManager Manager
    {
      get => this.mobjManager;
      internal set => this.mobjManager = value;
    }

    /// <summary>Gets the docked window descriptor.</summary>
    internal DockedWindowDescriptor DockedWindowDescriptor => this.mobjData;

    /// <summary>Gets the docked window descriptor internal.</summary>
    internal DockedWindowDescriptor DockedWindowDescriptorInternal => this.mobjData;

    /// <summary>Gets the descriptor.</summary>
    DockedObjectDescriptor IDescriptable.Descriptor => (DockedObjectDescriptor) this.mobjData;

    /// <summary>
    /// Gets or sets the image that is displayed on a button control.
    /// </summary>
    public ResourceHandle Image
    {
      get => this.mobjImage;
      set
      {
        if (value == this.mobjImage)
          return;
        this.mobjImage = value;
        if (this.OwningTabControl == null)
          return;
        this.OwningTabControl.WindowImageChanged(this);
      }
    }

    /// <summary>Gets or sets the name associated with this control.</summary>
    [Browsable(false)]
    public new string Name
    {
      get => this.WindowName.WindowName;
      set
      {
        if (!(this.Name != value))
          return;
        base.Name = value;
        this.WindowName.WindowName = value;
        this.mobjData.UpdateSelf((Control) this, (DockingManager) null);
      }
    }

    /// <summary>Gets or sets the owning tab control.</summary>
    /// <value>The owning tab control.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal DockedTabControl OwningTabControl
    {
      get => this.mobjOwningTabControl;
      set => this.mobjOwningTabControl = value;
    }

    /// <summary>Gets the owning zone.</summary>
    internal Zone OwningZone => this.OwningTabControl != null && this.OwningTabControl.OwningZone != null ? this.OwningTabControl.OwningZone : (Zone) null;

    /// <summary>Gets or sets the text associated with this control.</summary>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets or sets the name of the window.</summary>
    /// <value>The name of the window.</value>
    internal DockingWindowName WindowName
    {
      get => this.mobjData.WindowName;
      set => this.Name = value.WindowName;
    }

    /// <summary>Gets or sets the size of the hidden zone.</summary>
    /// <value>The size of the hidden zone.</value>
    public Size HiddenZonePopupSize
    {
      get => this.mobjHiddenZonePopupSize;
      set => this.mobjHiddenZonePopupSize = value;
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderHeaderToolTip(objWriter, false);
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
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      this.RenderHeaderToolTip(objWriter, true);
    }

    /// <summary>Renders the header tool tip.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderHeaderToolTip(IAttributeWriter objWriter, bool blnForceRender)
    {
      string headerToolTip = this.HeaderToolTip;
      if (!(!string.IsNullOrEmpty(headerToolTip) | blnForceRender))
        return;
      objWriter.WriteAttributeString("ZTT", headerToolTip);
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => this.Text;

    /// <summary>Conceals the control from the user.</summary>
    public new void Hide()
    {
      if (this.Manager == null || this.CurrentDockState == DockState.Hidden)
        return;
      this.Manager.SwitchWindowsDockState(DockState.Hidden, this);
    }

    /// <summary>Closes this instance.</summary>
    public void Close()
    {
      if (this.Manager == null || this.CurrentDockState == DockState.Close)
        return;
      this.Manager.SwitchWindowsDockState(DockState.Close, this);
    }

    /// <summary>Displays the control to the user.</summary>
    public new void Show()
    {
      switch (this.CurrentDockState)
      {
        case DockState.Float:
        case DockState.Dock:
        case DockState.Tabbed:
          this.IsSelectedTab = true;
          break;
        case DockState.AutoHide:
          string empty = string.Empty;
          string str;
          switch (this.OwningZone.DockingPosition)
          {
            case DockStyle.Top:
              str = "T";
              break;
            case DockStyle.Right:
              str = "R";
              break;
            case DockStyle.Bottom:
              str = "B";
              break;
            case DockStyle.Left:
              str = "L";
              break;
            default:
              throw new NotSupportedException();
          }
          this.OwningZone.ContainingHiddenPanel.InvokeMethodInternal("DockedHiddenZonesPanel_ShowZonePopUp", (object) this.OwningZone.ContainingHiddenPanel.ID, (object) this.OwningZone.ID, (object) this.Manager.ID, (object) str, (object) this.OwningZone.ContainingHiddenPanel.DockPadding.Right, (object) this.OwningZone.ContainingHiddenPanel.DockPadding.Left);
          break;
        case DockState.Hidden:
        case DockState.Close:
          this.Manager.ShowHiddenWindow(this);
          break;
        default:
          throw new NotSupportedException();
      }
    }

    /// <summary>Pins this instance.</summary>
    public void Pin()
    {
      if (this.Manager == null || this.CurrentDockState != DockState.AutoHide)
        return;
      this.Manager.SwitchWindowsDockState(DockState.Dock, this);
    }

    /// <summary>Unpins this instance.</summary>
    public void Unpin()
    {
      if (this.Manager == null || this.CurrentDockState != DockState.Dock)
        return;
      this.Manager.SwitchWindowsDockState(DockState.AutoHide, this);
    }

    /// <summary>Sets the float.</summary>
    public void SetFloat()
    {
      if (this.Manager == null || this.CurrentDockState == DockState.Float)
        return;
      this.Manager.SwitchWindowsDockState(DockState.Float, this);
    }

    /// <summary>Sets the dock.</summary>
    public void SetDock()
    {
      if (this.Manager == null || this.CurrentDockState == DockState.Dock)
        return;
      this.Manager.SwitchWindowsDockState(DockState.Dock, this);
    }

    /// <summary>
    /// Raises the <see cref="E:TextChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
      if (this.Parent is DockedTabPage)
        this.Parent.Text = this.Text;
      if (this.IsSelectedTab)
        this.OwningZone.NotifyWindowHeaderAttributeChanged(this);
      this.mobjData.UpdateSelf((Control) this, (DockingManager) null);
    }

    /// <summary>Loads the specified descriptor.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
    {
      DockedWindowDescriptor windowDescriptor = objDescriptor as DockedWindowDescriptor;
      this.WindowName = windowDescriptor.WindowName;
      this.Text = windowDescriptor.Text;
      this.mobjData = objDescriptor as DockedWindowDescriptor;
    }

    /// <summary>Resets the descriptors tree.</summary>
    /// <param name="objType">Type of the obj.</param>
    /// <param name="objDockingPosition">The obj docking position.</param>
    void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition) => throw new NotImplementedException();

    /// <summary>Initializes the component.</summary>
    private void InitializeDockedWindow() => base.Dock = DockStyle.Fill;
  }
}
