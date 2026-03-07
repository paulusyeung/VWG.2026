// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.StatusStrip
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  [Gizmox.WebGUI.Forms.MetadataTag("SSP")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (StatusStripSkin))]
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [SRDescription("DescriptionStatusStrip")]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (StatusStrip), "StatusStrip_45.bmp")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.StatusStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class StatusStrip : ToolStrip
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> class. </summary>
    public StatusStrip()
    {
      this.SuspendLayout();
      this.CanOverflow = false;
      this.LayoutStyle = ToolStripLayoutStyle.Table;
      this.GripStyle = ToolStripGripStyle.Hidden;
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.Stretch = true;
      this.ResumeLayout(true);
    }

    /// <summary>Provides custom table layout for a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnSpringTableLayoutCore()
    {
    }

    /// <summary>Creates the default item.</summary>
    /// <param name="strText">The STR text.</param>
    /// <param name="objImage">The obj image.</param>
    /// <param name="objOnClick">The obj on click.</param>
    /// <returns></returns>
    protected internal override ToolStripItem CreateDefaultItem(
      string strText,
      ResourceHandle objImage,
      EventHandler objOnClick)
    {
      return (ToolStripItem) new ToolStripStatusLabel(strText, objImage, objOnClick);
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    public new event EventHandler PaddingChanged
    {
      add => base.PaddingChanged += value;
      remove => base.PaddingChanged -= value;
    }

    /// <summary>
    /// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.StatusStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public override ToolStripItemCollection Items => base.Items;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.StatusStrip"></see> supports overflow functionality.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.StatusStrip"></see> supports overflow functionality; otherwise, false. The default is false.</returns>
    [Browsable(false)]
    [DefaultValue(false)]
    [SRDescription("ToolStripCanOverflowDescr")]
    [SRCategory("CatLayout")]
    public new bool CanOverflow
    {
      get => base.CanOverflow;
      set => base.CanOverflow = value;
    }

    /// <summary>Gets which borders of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> are docked to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Bottom"></see>.</returns>
    protected override DockStyle DefaultDock => DockStyle.Bottom;

    /// <summary>Gets the spacing, in pixels, between the left, right, top, and bottom edges of the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> from the edges of the form.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that represents the spacing. The default is {Left=6, Top=2, Right=0, Bottom=2}.</returns>
    protected override Padding DefaultPadding
    {
      get
      {
        if (this.Skin is StatusStripSkin skin)
        {
          if (this.Orientation != Orientation.Vertical)
            return (Padding) skin.HorizontalOrientationPadding;
          return (Padding) skin.VerticalOrientationPadding with
          {
            Bottom = this.DefaultSize.Height
          };
        }
        if (this.Orientation != Orientation.Horizontal)
          return new Padding(1, 3, 1, this.DefaultSize.Height);
        return this.RightToLeft == RightToLeft.No ? new Padding(1, 0, 14, 0) : new Padding(14, 0, 1, 0);
      }
    }

    /// <summary>Gets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.StatusStrip"></see> by default.</summary>
    /// <returns>false in all cases.</returns>
    protected override bool DefaultShowItemToolTips => false;

    /// <summary>Gets the size, in pixels, of the <see cref="T:System.Windows.Forms.StatusStrip"></see> when it is first created.</summary>
    /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> constructor representing the size of the <see cref="T:System.Windows.Forms.StatusStrip"></see>, in pixels.</returns>
    protected override Size DefaultSize => new Size(200, 22);

    /// <summary>Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> is resized with its parent.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Bottom"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DockStyle.Top)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set => base.Dock = value;
    }

    /// <summary>Gets or sets the visibility of the grip used to reposition the control.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripGripStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripGripStyle.Hidden"></see>.</returns>
    [DefaultValue(ToolStripGripStyle.Hidden)]
    public new ToolStripGripStyle GripStyle
    {
      get => base.GripStyle;
      set => base.GripStyle = value;
    }

    /// <summary>Gets or sets a value indicating how the <see cref="T:System.Windows.Forms.StatusStrip"></see> lays out the items collection.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripLayoutStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripLayoutStyle.Table"></see>.</returns>
    [DefaultValue(ToolStripLayoutStyle.Table)]
    public new ToolStripLayoutStyle LayoutStyle
    {
      get => base.LayoutStyle;
      set => base.LayoutStyle = value;
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [Browsable(false)]
    public new Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>true if ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    [SRDescription("ToolStripShowItemToolTipsDescr")]
    [SRCategory("CatBehavior")]
    public new bool ShowItemToolTips
    {
      get => base.ShowItemToolTips;
      set => base.ShowItemToolTips = value;
    }

    /// <summary>Gets the boundaries of the sizing handle (grip) for a <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the grip boundaries.</returns>
    [Browsable(false)]
    public Rectangle SizeGripBounds
    {
      get
      {
        if (!this.SizingGrip)
          return Rectangle.Empty;
        Size size = this.Size;
        int height = Math.Min(this.DefaultSize.Height, size.Height);
        return this.RightToLeft == RightToLeft.Yes ? new Rectangle(0, size.Height - height, 12, height) : new Rectangle(size.Width - 12, size.Height - height, 12, height);
      }
    }

    /// <summary>Gets or sets a value indicating whether a sizing handle (grip) is displayed in the lower-right corner of the control.</summary>
    /// <returns>true if a grip is displayed; otherwise, false. The default is true.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool SizingGrip
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> stretches from end to end in its container.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> stretches from end to end in its <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>; otherwise, false. The default is true.</returns>
    [SRCategory("CatLayout")]
    [SRDescription("ToolStripStretchDescr")]
    [DefaultValue(true)]
    public new bool Stretch
    {
      get => base.Stretch;
      set => base.Stretch = value;
    }
  }
}
