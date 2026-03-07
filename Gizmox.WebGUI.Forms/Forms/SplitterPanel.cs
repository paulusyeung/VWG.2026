// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SplitterPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Creates a panel that is associated with a SplitContainer.
  /// </summary>
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ComVisible(true)]
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (SplitterPanelSkin))]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.SplitterPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Designer("Gizmox.WebGUI.Forms.Design.SplitterPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [Serializable]
  public sealed class SplitterPanel : Panel
  {
    private bool mblnCollapsed;
    private SplitContainer mobjOwner;

    /// <summary>Occurs when [auto size changed].</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler AutoSizeChanged;

    /// <summary>Occurs when the value of the Dock property changes.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler DockChanged;

    /// <summary>Occurs when the Location property value has changed.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new event EventHandler LocationChanged;

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.SplitterPanel.TabIndex"> TabIndex </see> property changes.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler TabIndexChanged;

    /// <summary>
    /// Occurs when the value of the TabStop property changes.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler TabStopChanged;

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Visible"></see> property value changes.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new event EventHandler VisibleChanged
    {
      add => base.VisibleChanged += value;
      remove => base.VisibleChanged -= value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitterPanel" /> class.
    /// </summary>
    /// <param name="objOwner">The owner.</param>
    public SplitterPanel(SplitContainer objOwner)
    {
      this.mobjOwner = objOwner;
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    /// <summary>Gets or sets the anchoring style.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new AnchorStyles Anchor
    {
      get => base.Anchor;
      set => base.Anchor = value;
    }

    /// <summary>
    /// Enables the SplitterPanel to shrink when AutoSize is true.
    /// This property is not relevant for this class.
    /// </summary>
    /// <value></value>
    /// <returns>true if enabled; otherwise, false.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>
    /// Indicates the automatic sizing behavior of the control.
    /// </summary>
    /// <value></value>
    /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Localizable(false)]
    public override AutoSizeMode AutoSizeMode
    {
      get => AutoSizeMode.GrowOnly;
      set
      {
      }
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set => base.BorderStyle = value;
    }

    internal bool Collapsed
    {
      get => this.mblnCollapsed;
      set => this.mblnCollapsed = value;
    }

    /// <summary>Gets/Sets the controls docking style</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DockStyle Dock
    {
      get => base.Dock;
      set => base.Dock = value;
    }

    /// <summary>
    /// Gets the dock padding settings for all edges of the control.
    /// </summary>
    /// <value>
    /// A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges" /> that represents the padding for all the edges of a docked control.
    /// </value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ScrollableControl.DockPaddingEdges DockPadding => base.DockPadding;

    /// <summary>Gets/Sets the height position</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlHeightDescr")]
    public new int Height
    {
      get => this.Collapsed ? 0 : base.Height;
      set => throw new NotSupportedException(SR.GetString("SplitContainerPanelHeight"));
    }

    internal int HeightInternal
    {
      get => base.Height;
      set => base.Height = value;
    }

    /// <summary>Gets or sets the control location.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public new Point Location
    {
      get => base.Location;
      set => base.Location = value;
    }

    /// <summary>
    /// Gets or sets the size that is the upper limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.
    /// </summary>
    /// <value></value>
    /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Size MaximumSize
    {
      get => base.MaximumSize;
      set => base.MaximumSize = value;
    }

    /// <summary>
    /// Gets or sets the size that is the lower limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.
    /// </summary>
    /// <value></value>
    /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Size MinimumSize
    {
      get
      {
        if (this.Owner == null)
          return base.MinimumSize;
        int num = this.Owner.Panel1MinSize;
        if (this == this.Owner.Panel2)
          num = this.Owner.Panel2MinSize;
        return this.Owner.Orientation == Orientation.Horizontal ? new Size(this.DefaultMinimumSize.Width, num) : new Size(num, this.DefaultMinimumSize.Height);
      }
      set => base.MinimumSize = value;
    }

    /// <summary>Gets or sets the name associated with this control.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public new string Name
    {
      get => base.Name;
      set => base.Name = value;
    }

    /// <summary>Gets the owner.</summary>
    /// <value>The owner.</value>
    internal SplitContainer Owner => this.mobjOwner;

    /// <summary>Gets or sets the parent container of this control.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Control Parent
    {
      get => base.Parent;
      set => base.Parent = value;
    }

    /// <summary>Gets or sets the size.</summary>
    /// <value>The size.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size Size
    {
      get => this.Collapsed ? Size.Empty : base.Size;
      set => base.Size = value;
    }

    /// <summary>Gets or sets the tab index.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>Gets or sets the control visability.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool Visible
    {
      get => base.Visible;
      set => base.Visible = value;
    }

    /// <summary>Gets/Sets the width position</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    [SRDescription("ControlWidthDescr")]
    public new int Width
    {
      get => this.Collapsed ? 0 : base.Width;
      set => throw new NotSupportedException(SR.GetString("SplitContainerPanelWidth"));
    }

    internal int WidthInternal
    {
      get => base.Width;
      set => base.Width = value;
    }

    /// <summary>Applies the pre release dock fill compatibility.</summary>
    protected internal override void ApplyPreReleaseDockFillCompatibility()
    {
    }

    internal override AnchorStyles GetAnchorInternal() => this.Parent is SplitContainer parent && parent.Site == null ? AnchorStyles.None : base.GetAnchorInternal();

    internal override DockStyle GetDockInternal()
    {
      DockStyle dockInternal;
      if (this.Parent is SplitContainer parent && parent.Site == null)
      {
        if (this == parent.Panel1 && !parent.Panel1Collapsed && parent.Panel2Collapsed || this == parent.Panel2 && !parent.Panel2Collapsed && parent.Panel1Collapsed)
          return DockStyle.Fill;
        bool flag = parent.Panel1 == this;
        if (parent.FixedPanel != FixedPanel.None)
          flag = parent.Panel1 == this && parent.FixedPanel == FixedPanel.Panel1 || parent.Panel2 == this && parent.FixedPanel == FixedPanel.Panel2;
        dockInternal = !flag ? DockStyle.Fill : (parent.Orientation != Orientation.Vertical ? (this != parent.Panel1 ? DockStyle.Bottom : DockStyle.Top) : (this != parent.Panel1 ? DockStyle.Right : DockStyle.Left));
      }
      else
        dockInternal = base.GetDockInternal();
      return dockInternal;
    }
  }
}
