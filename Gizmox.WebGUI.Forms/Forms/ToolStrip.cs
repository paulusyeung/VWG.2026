// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStrip
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// <summary>Provides a container for Windows toolbar objects. </summary>
  /// </summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ToolStripSkin))]
  [Gizmox.WebGUI.Forms.MetadataTag("TSP")]
  [DefaultEvent("ItemClicked")]
  [SRDescription("DescriptionToolStrip")]
  [ComVisible(true)]
  [DefaultProperty("Items")]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ToolStrip), "ToolStrip_45.bmp")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ProxyComponent(typeof (ProxyToolStrip))]
  [Serializable]
  public class ToolStrip : ScrollableControl, IComponent, IDisposable
  {
    private static readonly SerializableProperty mobjToolStripItemCollectionProperty = SerializableProperty.Register(nameof (mobjToolStripItemCollection), typeof (ToolStripItemCollection), typeof (ToolStrip));
    private static readonly SerializableProperty mobjImageScalingSizeProperty = SerializableProperty.Register(nameof (mobjImageScalingSize), typeof (Size), typeof (ToolStrip), new SerializablePropertyMetadata());
    private static readonly SerializableProperty mobjImageListProperty = SerializableProperty.Register(nameof (mobjImageList), typeof (ImageList), typeof (ToolStrip));
    private static readonly SerializableProperty menmToolStripGripStyleProperty = SerializableProperty.Register(nameof (menmToolStripGripStyle), typeof (ToolStripGripStyle), typeof (ToolStrip), new SerializablePropertyMetadata((object) ToolStripGripStyle.Visible));
    private static readonly SerializableProperty mobjGripMarginProperty = SerializableProperty.Register(nameof (mobjGripMargin), typeof (Padding), typeof (ToolStrip));
    private static readonly SerializableProperty menmLayoutStyleProperty = SerializableProperty.Register(nameof (menmLayoutStyle), typeof (ToolStripLayoutStyle), typeof (ToolStrip), new SerializablePropertyMetadata((object) ToolStripLayoutStyle.StackWithOverflow));
    private static readonly SerializableProperty menmOrientationProperty = SerializableProperty.Register(nameof (menmOrientation), typeof (Orientation), typeof (ToolStrip));
    private static readonly SerializableProperty mblnAllowMergeProperty = SerializableProperty.Register(nameof (mblnAllowMerge), typeof (bool), typeof (ToolStrip), new SerializablePropertyMetadata((object) true));
    private static readonly SerializableProperty mblnAllowItemReorderProperty = SerializableProperty.Register(nameof (mblnAllowItemReorder), typeof (bool), typeof (ToolStrip));
    private static readonly SerializableProperty mblnShowItemToolTipsProperty = SerializableProperty.Register(nameof (mblnShowItemToolTips), typeof (bool), typeof (ToolStrip));
    private static readonly SerializableProperty mblnStretchProperty = SerializableProperty.Register(nameof (mblnStretch), typeof (bool), typeof (ToolStrip));
    private static readonly SerializableProperty menmToolStripTextDirectionProperty = SerializableProperty.Register(nameof (menmToolStripTextDirection), typeof (ToolStripTextDirection), typeof (ToolStrip));
    private static readonly SerializableProperty mblnCanOverflowProperty = SerializableProperty.Register(nameof (mblnCanOverflow), typeof (bool), typeof (ToolStrip));
    internal static readonly SerializableEvent ItemClickedEvent = SerializableEvent.Register("ItemClicked", typeof (ToolStripItemClickedEventHandler), typeof (ToolStrip));
    private static readonly SerializableEvent LayoutStyleChangedEvent = SerializableEvent.Register("LayoutStyleChanged", typeof (EventHandler), typeof (ToolStrip));
    private static readonly SerializableEvent ItemAddedEvent = SerializableEvent.Register("ItemAdded", typeof (ToolStripItemEventHandler), typeof (ToolStrip));
    private static readonly SerializableEvent ItemRemovedEvent = SerializableEvent.Register("ItemRemoved", typeof (ToolStripItemEventHandler), typeof (ToolStrip));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class.</summary>
    public ToolStrip()
    {
      this.SuspendLayout();
      this.CanOverflow = true;
      this.TabStop = false;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.Selectable, false);
      this.Dock = this.DefaultDock;
      this.AutoSize = true;
      this.CausesValidation = false;
      Size defaultSize = this.DefaultSize;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.ShowItemToolTips = this.DefaultShowItemToolTips;
      this.ImageScalingSize = this.SkinImageScalingSize;
      this.ResumeLayout(true);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class with the specified array of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>s.</summary>
    /// <param name="items">An array of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> objects.</param>
    public ToolStrip(ToolStripItem[] items)
      : this()
    {
      this.Items.AddRange(items);
    }

    private bool ShouldSerializeDefaultDropDownDirection() => false;

    private bool ShouldSerializeGripMargin() => this.ContainsValue<Padding>(ToolStrip.mobjGripMarginProperty);

    private bool ShouldSerializeLayoutStyle() => this.ContainsValue<ToolStripLayoutStyle>(ToolStrip.menmLayoutStyleProperty);

    private bool ShouldSerializeRenderMode() => false;

    /// <summary>Specifies the visual arrangement for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The default is null.</returns>
    /// <param name="layoutStyle">The visual arrangement to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual LayoutSettings CreateLayoutSettings(ToolStripLayoutStyle layoutStyle) => (LayoutSettings) null;

    /// <summary>This method is not relevant for this class.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Control"></see>.</returns>
    /// <param name="point">A <see cref="T:System.Drawing.Point"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control GetChildAtPoint(Point point) => (Control) null;

    /// <summary>This method is not relevant for this class.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Control"></see>.</returns>
    /// <param name="skipValue">A <see cref="T:Gizmox.WebGUI.Forms.GetChildAtPointSkip"></see>  value.</param>
    /// <param name="pt">A <see cref="T:System.Drawing.Point"></see> value.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control GetChildAtPoint(Point pt, GetChildAtPointSkip skipValue) => (Control) null;

    /// <summary>Returns the item located at the specified x- and y-coordinates of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> client area.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> located at the specified location, or null if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not found.</returns>
    /// <param name="y">The vertical coordinate, in pixels, from the top edge of the client area. </param>
    /// <param name="x">The horizontal coordinate, in pixels, from the left edge of the client area. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripItem GetItemAt(int x, int y) => (ToolStripItem) null;

    /// <summary>Returns the item located at the specified point in the client area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> at the specified location, or null if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not found.</returns>
    /// <param name="point">The <see cref="T:System.Drawing.Point"></see> at which to search for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripItem GetItemAt(Point point) => (ToolStripItem) null;

    /// <summary>Retrieves the next <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> from the specified reference point and moving in the specified direction.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is specified by the start parameter and is next in the order as specified by the direction parameter.</returns>
    /// <param name="direction">One of the values of <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see> that specifies the direction to move.</param>
    /// <param name="start">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the reference point from which to begin the retrieval of the next item.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value of the direction parameter is not one of the values of <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see>.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ToolStripItem GetNextItem(ToolStripItem start, ArrowDirection direction) => (ToolStripItem) null;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.BeginDrag"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnBeginDrag(EventArgs e)
    {
    }

    /// <summary>Updates the strip attributes externally.</summary>
    /// <param name="attributeType">Type of the attribute.</param>
    internal void UpdateStripAttributes(AttributeType attributeType) => this.UpdateParams(attributeType);

    /// <summary>Updates the orientation.</summary>
    /// <param name="objNewOrientation">The  new orientation.</param>
    private void UpdateOrientation(Orientation objNewOrientation)
    {
      if (objNewOrientation == this.Orientation)
        return;
      this.menmOrientation = objNewOrientation;
      this.UpdateParams(AttributeType.Layout);
    }

    /// <summary>Updates the layout style.</summary>
    /// <param name="enmNewDock">The new dock value.</param>
    private void UpdateLayoutStyle(DockStyle enmNewDock)
    {
      if (this.menmLayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow || this.menmLayoutStyle == ToolStripLayoutStyle.VerticalStackWithOverflow)
        return;
      if (enmNewDock == DockStyle.Left || enmNewDock == DockStyle.Right)
        this.UpdateOrientation(Orientation.Vertical);
      else
        this.UpdateOrientation(Orientation.Horizontal);
      this.OnLayoutStyleChanged(EventArgs.Empty);
    }

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objProposedSize">Size of the obj proposed.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      Size preferredSize1 = objProposedSize;
      if (this.Skin is ToolStripSkin skin)
      {
        Size imageScalingSize = this.ImageScalingSize;
        DockStyle dock = this.Dock;
        if (dock != DockStyle.None)
        {
          Size preferredSize2 = this.GetPreferredSize(skin, objProposedSize);
          if (this.IsVerticalDocked(dock))
            preferredSize1.Height = preferredSize2.Height;
          else if (this.IsHorizontalDocked(dock))
            preferredSize1.Width = preferredSize2.Width;
          else if (this.Dock == DockStyle.Fill)
            preferredSize1 = preferredSize2;
        }
        else
        {
          preferredSize1 = this.GetPreferredSize(skin, objProposedSize);
          if (this.GripStyle == ToolStripGripStyle.Visible)
            preferredSize1.Width += skin.HorizontalGripWidth;
        }
      }
      return preferredSize1;
    }

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objImageScalingSize">Size of the obj image scaling.</param>
    /// <param name="objToolStripSkin">The obj tool strip skin.</param>
    /// <param name="objProposedSize">The obj size set as default or from designer.</param>
    /// <returns></returns>
    private Size GetPreferredSize(ToolStripSkin objToolStripSkin, Size objProposedSize)
    {
      Size empty = Size.Empty;
      if (this.Items.Count == 0)
      {
        if (this.Orientation == Orientation.Vertical)
          empty.Width = objProposedSize.Width;
        else
          empty.Height = objProposedSize.Height;
      }
      else
      {
        foreach (ToolStripItem toolStripItem1 in (ArrangedElementCollection) this.Items)
        {
          if (toolStripItem1.Visible)
          {
            Size size = Size.Empty;
            if (!toolStripItem1.AutoSize)
            {
              size.Height = toolStripItem1.Height;
              size.Width = toolStripItem1.Width;
            }
            else
            {
              ToolStripItem toolStripItem2 = toolStripItem1;
              size = toolStripItem2.GetPreferredSize(toolStripItem2.Size);
            }
            if (this.Orientation == Orientation.Horizontal)
            {
              if (size.Height > empty.Height)
                empty.Height = size.Height;
              empty.Width += size.Width;
            }
            else
            {
              if (size.Width > empty.Width)
                empty.Width = size.Width;
              empty.Height += size.Height;
            }
          }
        }
        ref Size local1 = ref empty;
        int height = local1.Height;
        ToolStripSkin toolStripSkin1 = objToolStripSkin;
        int frameEdgeSize1 = toolStripSkin1.GetFrameEdgeSize(toolStripSkin1.FrameStyle, CommonSkin.FrameEdge.Top);
        ToolStripSkin toolStripSkin2 = objToolStripSkin;
        int frameEdgeSize2 = toolStripSkin2.GetFrameEdgeSize(toolStripSkin2.FrameStyle, CommonSkin.FrameEdge.Bottom);
        int num1 = frameEdgeSize1 + frameEdgeSize2;
        local1.Height = height + num1;
        ref Size local2 = ref empty;
        int width = local2.Width;
        int horizontal = objToolStripSkin.Padding.Horizontal;
        ToolStripSkin toolStripSkin3 = objToolStripSkin;
        int frameEdgeSize3 = toolStripSkin3.GetFrameEdgeSize(toolStripSkin3.FrameStyle, CommonSkin.FrameEdge.Left);
        int num2 = horizontal + frameEdgeSize3;
        ToolStripSkin toolStripSkin4 = objToolStripSkin;
        int frameEdgeSize4 = toolStripSkin4.GetFrameEdgeSize(toolStripSkin4.FrameStyle, CommonSkin.FrameEdge.Right);
        int num3 = num2 + frameEdgeSize4;
        local2.Width = width + num3;
      }
      return empty + this.Padding.Size;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.EndDrag"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnEndDrag(EventArgs e)
    {
    }

    /// <summary>Creates a default <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.ToolStrip"></see> instance.</summary>
    /// <returns>A <see cref="M:System.Windows.Forms.ToolStripButton.#ctor(System.String,Gizmox.WebGUI.Common.Resources.ResourceHandle,System.EventHandler)"></see>, or a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see> if the text parameter is a hyphen (-).</returns>
    /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event when the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is clicked.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    /// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripItem"></see>. If the text parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see>.</param>
    protected internal virtual ToolStripItem CreateDefaultItem(
      string text,
      ResourceHandle image,
      EventHandler onClick)
    {
      return text == "-" ? (ToolStripItem) new ToolStripSeparator() : (ToolStripItem) new ToolStripButton(text, image, onClick);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.ItemClicked"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemClickedEventArgs"></see> that contains the event data. </param>
    protected internal virtual void OnItemClicked(ToolStripItemClickedEventArgs e)
    {
      ToolStripItemClickedEventHandler itemClickedHandler = this.ItemClickedHandler;
      if (itemClickedHandler == null)
        return;
      itemClickedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemAdded"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
    protected internal virtual void OnItemAdded(ToolStripItemEventArgs e)
    {
      ToolStripItemEventHandler itemAddedHandler = this.ItemAddedHandler;
      if (itemAddedHandler == null)
        return;
      itemAddedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemRemoved"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
    protected internal virtual void OnItemRemoved(ToolStripItemEventArgs e)
    {
      ToolStripItemEventHandler itemRemovedHandler = this.ItemRemovedHandler;
      if (itemRemovedHandler == null)
        return;
      itemRemovedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.LayoutCompleted"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnLayoutCompleted(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnLayoutStyleChanged(EventArgs e)
    {
      EventHandler styleChangedHandler = this.LayoutStyleChangedHandler;
      if (styleChangedHandler == null)
        return;
      styleChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.RendererChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRendererChanged(EventArgs e)
    {
    }

    /// <summary>This method is not relevant for this class.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new void ResetMinimumSize()
    {
    }

    /// <summary>Controls the return location of the focus.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void RestoreFocus()
    {
    }

    /// <summary>This method is not relevant for this class.</summary>
    /// <param name="y">An <see cref="T:System.Int32"></see>.</param>
    /// <param name="x">An <see cref="T:System.Int32"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new void SetAutoScrollMargin(int x, int y)
    {
    }

    /// <summary>
    /// Resets the collection of displayed and overflow items after a layout is done.
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void SetDisplayedItems()
    {
    }

    /// <summary>Enables you to change the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary>
    /// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> whose <see cref="P:Gizmox.WebGUI.Forms.Control.Parent"></see> property is to be changed. </param>
    /// <param name="parent">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the parent of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> referred to by the item parameter. </param>
    protected static void SetItemParent(ToolStripItem item, ToolStrip parent) => item.ParentInternal = parent;

    /// <summary>
    /// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
    /// </returns>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(base.ToString());
      stringBuilder.Append(", Name: ");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Items: ").Append(this.Items.Count);
      return stringBuilder.ToString();
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        try
        {
          this.SuspendLayout();
          if (!this.Items.IsReadOnly)
          {
            for (int index = this.Items.Count - 1; index >= 0; --index)
              this.Items[index].Dispose();
            this.Items.Clear();
          }
        }
        finally
        {
          this.ResumeLayout(false);
        }
      }
      base.Dispose(blnDisposing);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      if (this.mobjToolStripItemCollection == null)
        return;
      this.UnRegisterBatch((ICollection) this.mobjToolStripItemCollection);
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      if (this.mobjToolStripItemCollection == null)
        return;
      this.RegisterBatch((ICollection) this.mobjToolStripItemCollection);
    }

    /// <summary>
    /// Raises the <see cref="E:EnabledChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnEnabledChanged(EventArgs e)
    {
      base.OnEnabledChanged(e);
      for (int index = 0; index < this.Items.Count; ++index)
      {
        if (this.Items[index] != null && this.Items[index].ParentInternal == this)
          this.Items[index].OnParentEnabledChanged(e);
      }
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      ToolStripItem toolStripItem = (ToolStripItem) null;
      string member = objEvent.Member;
      if (!string.IsNullOrEmpty(member))
      {
        int result = -1;
        if (int.TryParse(member, out result))
          toolStripItem = this.Items[result - 1];
      }
      if (toolStripItem != null)
        toolStripItem.FireToolStripItemEvent(objEvent);
      else
        base.FireEvent(objEvent);
    }

    /// <summary>
    /// Gets the list of tags that client events are propogated to.
    /// </summary>
    /// <value>The client event propogated tags.</value>
    protected override string ClientEventsPropogationTags => string.Format("WC:{0},WC:{1},WC:{2},WC:{3}", (object) "CB", (object) "T", (object) "TSI", (object) "PB");

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.Items)
        toolStripItem.RenderToolStripItem(objContext, objWriter, lngRequestID);
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.Items)
        toolStripItem.PreRenderToolStripItem(objContext, lngRequestID);
      base.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Posts the render control.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    protected internal override void PostRenderControl(IContext objContext, long lngRequestID)
    {
      base.PostRenderControl(objContext, lngRequestID);
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.Items)
        toolStripItem.PostRenderToolStripItem(objContext, lngRequestID);
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("SF", "1");
      this.RenderWrapContentsAttribute(objWriter, false);
      this.RenderShowGripAttribute(objWriter, false);
      this.RenderImageSizeAttributes(objWriter, false);
      this.RenderOrientationAttribute(objWriter);
      if (!this.SupportMenuStickiness)
        return;
      objWriter.WriteAttributeString("SMS", "1");
    }

    /// <summary>Renders the show grip attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderShowGripAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      ToolStripGripStyle gripStyle = this.GripStyle;
      if (!(gripStyle == ToolStripGripStyle.Hidden | blnForceRender))
        return;
      objWriter.WriteAttributeString("SG", gripStyle == ToolStripGripStyle.Hidden ? "0" : "1");
    }

    /// <summary>Renders the image size attributes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderImageSizeAttributes(IAttributeWriter objWriter, bool blnForceRender)
    {
      Size imageScalingSize = this.ImageScalingSize;
      objWriter.WriteAttributeString("IH", imageScalingSize.Height.ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("IW", imageScalingSize.Width.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    /// <summary>Renders the orientation attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderOrientationAttribute(IAttributeWriter objWriter) => objWriter.WriteAttributeString("ORI", Convert.ToInt32((object) this.Orientation).ToString());

    /// <summary>Gets the size of the skin image scaling.</summary>
    /// <value>The size of the skin image scaling.</value>
    internal Size SkinImageScalingSize => SkinFactory.GetSkin((ISkinable) this) is ToolStripSkin skin ? skin.ImageScalingSize : Size.Empty;

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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        this.RenderWrapContentsAttribute(objWriter, true);
        this.RenderShowGripAttribute(objWriter, true);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
        return;
      this.RenderImageSizeAttributes(objWriter, true);
      this.RenderOrientationAttribute(objWriter);
    }

    /// <summary>Renders the wrap contents attribute.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderWrapContentsAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool canOverflow = this.CanOverflow;
      if (!blnForceRender && canOverflow)
        return;
      objWriter.WriteAttributeString("WC", canOverflow ? "1" : "0");
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
    {
      Type type = Type.GetType(strOffspringTypeName);
      return type != (Type) null && CommonUtils.IsTypeOrSubType(type, typeof (ToolStripItem)) ? (IList) this.Items : base.GetComponentOffsprings(strOffspringTypeName);
    }

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AutoSize"></see> property has changed.</summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [SRCategory("CatPropertyChanged")]
    [Browsable(true)]
    [SRDescription("ControlOnAutoSizeChangedDescr")]
    public new event EventHandler AutoSizeChanged
    {
      add => base.AutoSizeChanged += value;
      remove => base.AutoSizeChanged -= value;
    }

    /// <summary>
    /// Occurs when the user begins to drag the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> control.
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler BeginDrag;

    /// <summary>
    /// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.CausesValidation"></see> property changes.
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new event EventHandler CausesValidationChanged;

    /// <summary>This event is not relevant for this class.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ControlEventHandler"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event ControlEventHandler ControlAdded
    {
      add => base.ControlAdded += value;
      remove => base.ControlAdded -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ControlEventHandler"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event ControlEventHandler ControlRemoved
    {
      add => base.ControlRemoved += value;
      remove => base.ControlRemoved -= value;
    }

    /// <summary>
    /// Occurs when the value of the <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> property changes.
    /// </summary>
    [Browsable(false)]
    public new event EventHandler CursorChanged
    {
      add => base.CursorChanged += value;
      remove => base.CursorChanged -= value;
    }

    /// <summary>
    /// Occurs when the user stops dragging the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> control.
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler EndDrag;

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ForeColor"></see> property changes.
    /// </summary>
    [Browsable(false)]
    public new event EventHandler ForeColorChanged
    {
      add => base.ForeColorChanged += value;
      remove => base.ForeColorChanged -= value;
    }

    /// <summary>
    /// Occurs when a new <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is added to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>.
    /// </summary>
    [SRDescription("ToolStripItemAddedDescr")]
    [SRCategory("CatAppearance")]
    public event ToolStripItemEventHandler ItemAdded
    {
      add => this.AddHandler(ToolStrip.ItemAddedEvent, (Delegate) value);
      remove => this.RemoveHandler(ToolStrip.ItemAddedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ItemAdded event.</summary>
    private ToolStripItemEventHandler ItemAddedHandler => (ToolStripItemEventHandler) this.GetHandler(ToolStrip.ItemAddedEvent);

    /// <summary>
    /// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.
    /// </summary>
    [SRDescription("ToolStripItemOnClickDescr")]
    [SRCategory("CatAction")]
    public event ToolStripItemClickedEventHandler ItemClicked
    {
      add => this.AddHandler(ToolStrip.ItemClickedEvent, (Delegate) value);
      remove => this.RemoveHandler(ToolStrip.ItemClickedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ItemClicked event.</summary>
    private ToolStripItemClickedEventHandler ItemClickedHandler => (ToolStripItemClickedEventHandler) this.GetHandler(ToolStrip.ItemClickedEvent);

    /// <summary>
    /// Occurs when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is removed from the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>.
    /// </summary>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripItemRemovedDescr")]
    public event ToolStripItemEventHandler ItemRemoved
    {
      add => this.AddHandler(ToolStrip.ItemRemovedEvent, (Delegate) value);
      remove => this.RemoveHandler(ToolStrip.ItemRemovedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the ItemRemoved event.</summary>
    private ToolStripItemEventHandler ItemRemovedHandler => (ToolStripItemEventHandler) this.GetHandler(ToolStrip.ItemRemovedEvent);

    /// <summary>Occurs when the layout of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is complete.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler LayoutCompleted;

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see> property changes.
    /// </summary>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripLayoutStyleChangedDescr")]
    public event EventHandler LayoutStyleChanged
    {
      add => this.AddHandler(ToolStrip.LayoutStyleChangedEvent, (Delegate) value);
      remove => this.RemoveHandler(ToolStrip.LayoutStyleChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the LayoutStyleChanged event.</summary>
    private EventHandler LayoutStyleChangedHandler => (EventHandler) this.GetHandler(ToolStrip.LayoutStyleChangedEvent);

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle is painted.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event PaintEventHandler PaintGrip;

    /// <summary>
    /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.Renderer"></see> property changes.
    /// </summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler RendererChanged;

    private ToolStripItemCollection mobjToolStripItemCollection
    {
      get => this.GetValue<ToolStripItemCollection>(ToolStrip.mobjToolStripItemCollectionProperty, (ToolStripItemCollection) null);
      set => this.SetValue<ToolStripItemCollection>(ToolStrip.mobjToolStripItemCollectionProperty, value);
    }

    private Size mobjImageScalingSize
    {
      get => this.GetValue<Size>(ToolStrip.mobjImageScalingSizeProperty, this.SkinImageScalingSize);
      set => this.SetValue<Size>(ToolStrip.mobjImageScalingSizeProperty, value);
    }

    private ImageList mobjImageList
    {
      get => this.GetValue<ImageList>(ToolStrip.mobjImageListProperty);
      set => this.SetValue<ImageList>(ToolStrip.mobjImageListProperty, value);
    }

    private bool mblnCanOverflow
    {
      get => this.GetValue<bool>(ToolStrip.mblnCanOverflowProperty, false);
      set => this.SetValue<bool>(ToolStrip.mblnCanOverflowProperty, value);
    }

    private ToolStripTextDirection menmToolStripTextDirection
    {
      get => this.GetValue<ToolStripTextDirection>(ToolStrip.menmToolStripTextDirectionProperty, ToolStripTextDirection.Inherit);
      set => this.SetValue<ToolStripTextDirection>(ToolStrip.menmToolStripTextDirectionProperty, value);
    }

    private bool mblnStretch
    {
      get => this.GetValue<bool>(ToolStrip.mblnStretchProperty);
      set => this.SetValue<bool>(ToolStrip.mblnStretchProperty, value);
    }

    private bool mblnShowItemToolTips
    {
      get => this.GetValue<bool>(ToolStrip.mblnShowItemToolTipsProperty);
      set => this.SetValue<bool>(ToolStrip.mblnShowItemToolTipsProperty, value);
    }

    private bool mblnAllowItemReorder
    {
      get => this.GetValue<bool>(ToolStrip.mblnAllowItemReorderProperty);
      set => this.SetValue<bool>(ToolStrip.mblnAllowItemReorderProperty, value);
    }

    private bool mblnAllowMerge
    {
      get => this.GetValue<bool>(ToolStrip.mblnAllowMergeProperty);
      set => this.SetValue<bool>(ToolStrip.mblnAllowMergeProperty, value);
    }

    private Orientation menmOrientation
    {
      get => this.GetValue<Orientation>(ToolStrip.menmOrientationProperty);
      set => this.SetValue<Orientation>(ToolStrip.menmOrientationProperty, value);
    }

    private ToolStripLayoutStyle menmLayoutStyle
    {
      get => this.GetValue<ToolStripLayoutStyle>(ToolStrip.menmLayoutStyleProperty);
      set => this.SetValue<ToolStripLayoutStyle>(ToolStrip.menmLayoutStyleProperty, value);
    }

    private Padding mobjGripMargin
    {
      get => this.GetValue<Padding>(ToolStrip.mobjGripMarginProperty);
      set => this.SetValue<Padding>(ToolStrip.mobjGripMarginProperty, value);
    }

    private ToolStripGripStyle menmToolStripGripStyle
    {
      get => this.GetValue<ToolStripGripStyle>(ToolStrip.menmToolStripGripStyleProperty);
      set => this.SetValue<ToolStripGripStyle>(ToolStrip.menmToolStripGripStyleProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether drag-and-drop and item reordering are handled through events that you implement.</summary>
    /// <returns>true to control drag-and-drop and item reordering through events that you implement; otherwise, false.</returns>
    /// <exception cref="T:System.ArgumentException">
    /// <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public override bool AllowDrop
    {
      get => base.AllowDrop;
      set => base.AllowDrop = !value || !this.AllowItemReorder ? value : throw new ArgumentException(SR.GetString("ToolStripAllowItemReorderAndAllowDropCannotBeSetToTrue"));
    }

    /// <summary>Gets or sets a value indicating whether drag-and-drop and item reordering are handled privately by the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class.</summary>
    /// <returns>true to cause the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class to handle drag-and-drop and item reordering automatically; otherwise, false. The default value is false.</returns>
    /// <exception cref="T:System.ArgumentException">
    /// <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DefaultValue(false)]
    [SRDescription("ToolStripAllowItemReorderDescr")]
    [SRCategory("CatBehavior")]
    public bool AllowItemReorder
    {
      get => this.mblnAllowItemReorder;
      set
      {
        if (this.mblnAllowItemReorder == value)
          return;
        this.mblnAllowItemReorder = !(this.AllowDrop & value) ? value : throw new ArgumentException(SR.GetString("ToolStripAllowItemReorderAndAllowDropCannotBeSetToTrue"));
      }
    }

    /// <summary>Gets or sets a value indicating whether multiple <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>, and other types can be combined. </summary>
    /// <returns>true if combining of types is allowed; otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ToolStripAllowMergeDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool AllowMerge
    {
      get => this.mblnAllowMerge;
      set
      {
        if (this.mblnAllowMerge == value)
          return;
        this.mblnAllowMerge = value;
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>true to automatically scroll; otherwise, false.</returns>
    /// <exception cref="T:System.NotSupportedException">Automatic scrolling is not supported by <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> controls.</exception>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool AutoScroll
    {
      get => base.AutoScroll;
      set => throw new NotSupportedException(SR.GetString("ToolStripDoesntSupportAutoScroll"));
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> value.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size AutoScrollMargin
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> value.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size AutoScrollMinSize
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Point"></see> value.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Point AutoScrollPosition
    {
      get => Point.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the control is automatically resized to display its entire contents.</summary>
    /// <returns>true if the control adjusts its width to closely fit its contents; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(true)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>Gets or sets the background color for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripBackColorDescr")]
    public new Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    /// <summary>Gets or sets a value indicating whether items in the <see cref="T:System.Windows.Forms.ToolStrip"></see> can be sent to an overflow menu.</summary>
    /// <returns>true to send <see cref="T:System.Windows.Forms.ToolStrip"></see> items to an overflow menu; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ToolStripCanOverflowDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(true)]
    public bool CanOverflow
    {
      get => this.mblnCanOverflow;
      set
      {
        if (this.mblnCanOverflow == value)
          return;
        this.mblnCanOverflow = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> causes validation to be performed on any controls that require validation when it receives focus.</summary>
    /// <returns>false in all cases.</returns>
    [Browsable(false)]
    [DefaultValue(false)]
    public new bool CausesValidation
    {
      get => base.CausesValidation;
      set => base.CausesValidation = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> representing the collection of controls contained within the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Control.ControlCollection Controls => base.Controls;

    /// <summary>Gets or sets the cursor that is displayed when the mouse pointer is over the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor to display when the mouse pointer is over the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Cursor Cursor
    {
      get => base.Cursor;
      set => base.Cursor = value;
    }

    /// <summary>Gets the docking location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, indicating which borders are docked to the container.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Top"></see>.</returns>
    protected virtual DockStyle DefaultDock => DockStyle.Top;

    /// <summary>Gets or sets a value representing the default direction in which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is displayed relative to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</exception>
    [SRCategory("CatBehavior")]
    [Browsable(false)]
    [SRDescription("ToolStripDefaultDropDownDirectionDescr")]
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ToolStripDropDownDirection DefaultDropDownDirection
    {
      get => ToolStripDropDownDirection.Default;
      set
      {
      }
    }

    /// <summary>Gets the default spacing, in pixels, between the sizing grip and the edges of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>
    /// <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values representing the spacing, in pixels.</returns>
    protected virtual Padding DefaultGripMargin => new Padding(2);

    /// <summary>Gets the internal spacing, in pixels, of the contents of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value of (0, 0, 1, 0).</returns>
    protected override Size DefaultSize => new Size(100, 25);

    /// <summary>Gets a value indicating whether ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> by default.</summary>
    /// <returns>true in all cases.</returns>
    protected virtual bool DefaultShowItemToolTips => true;

    /// <summary>Retrieves the current display rectangle.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> area for item layout.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new virtual Rectangle DisplayRectangle => Rectangle.Empty;

    /// <summary>Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is resized with its parent.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Top"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DockStyle.Top)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set
      {
        DockStyle dock = this.Dock;
        if (value == dock)
          return;
        Rectangle bounds = this.Bounds;
        base.Dock = value;
        if (this.IsHorizontalDocked(dock) && this.IsVerticalDocked(value) || this.IsHorizontalDocked(value) && this.IsVerticalDocked(dock))
          this.Size = new Size(bounds.Height, bounds.Width);
        this.UpdateLayoutStyle(value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> representing the foreground color.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    public new Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>Gets the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values. Possible values are <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle.Horizontal"></see> and <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle.Vertical"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public ToolStripGripDisplayStyle GripDisplayStyle => this.LayoutStyle != ToolStripLayoutStyle.HorizontalStackWithOverflow ? ToolStripGripDisplayStyle.Horizontal : ToolStripGripDisplayStyle.Vertical;

    /// <summary>Gets or sets the space around the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>, which represents the spacing.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripGripDisplayStyleDescr")]
    [SRCategory("CatLayout")]
    public Padding GripMargin
    {
      get => this.mobjGripMargin;
      set
      {
        if (!(this.mobjGripMargin != value))
          return;
        this.mobjGripMargin = value;
      }
    }

    /// <summary>Resets the grip margin.</summary>
    private void ResetGripMargin() => this.RemoveValue<Padding>(ToolStrip.mobjGripMarginProperty);

    /// <summary>Gets the boundaries of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary>
    /// <returns>An object of type <see cref="T:System.Drawing.Rectangle"></see>, representing the move handle boundaries. If the boundaries are not visible, the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.GripRectangle"></see> property returns <see cref="F:System.Drawing.Rectangle.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle GripRectangle => Rectangle.Empty;

    /// <summary>Gets or sets whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle is visible or hidden.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripStyle.Visible"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DefaultValue(ToolStripGripStyle.Visible)]
    [SRDescription("ToolStripGripStyleDescr")]
    [SRCategory("CatAppearance")]
    public ToolStripGripStyle GripStyle
    {
      get => this.menmToolStripGripStyle;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 1))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ToolStripGripStyle));
        if (this.menmToolStripGripStyle == value)
          return;
        this.menmToolStripGripStyle = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStrip"></see> has children; otherwise, false. </returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool HasChildren => base.HasChildren;

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>An instance of the <see cref="T:Gizmox.WebGUI.Forms.HScrollProperties"></see> class, which provides basic properties for an <see cref="T:Gizmox.WebGUI.Forms.HScrollBar"></see>.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public HScrollProperties HorizontalScroll => (HScrollProperties) null;

    /// <summary>Gets or sets the image list that contains the image displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> item.</summary>
    /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripImageListDescr")]
    [Browsable(false)]
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    public ImageList ImageList
    {
      get => this.mobjImageList;
      set
      {
        if (this.mobjImageList == value)
          return;
        this.mobjImageList = value;
      }
    }

    internal bool ShouldSerializeImageScalingSize() => this.ImageScalingSize != this.SkinImageScalingSize;

    /// <summary>Gets or sets the size, in pixels, of an image used on a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> value representing the size of the image, in pixels. The default is 16 x 16 pixels.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripImageScalingSizeDescr")]
    public Size ImageScalingSize
    {
      get => this.mobjImageScalingSize;
      set
      {
        if (!(this.mobjImageScalingSize != value))
          return;
        this.mobjImageScalingSize = value;
        this.Update();
      }
    }

    /// <summary>Resets the image size.</summary>
    private void ResetImageScalingSize() => this.ImageScalingSize = this.SkinImageScalingSize;

    /// <summary>Gets a value indicating whether the user is currently moving the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> from one <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see> to another. </summary>
    /// <returns>true if the user is currently moving the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> from one <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see> to another; otherwise, false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool IsCurrentlyDragging => false;

    /// <summary>Gets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool IsDropDown => this is ToolStripDropDown;

    /// <summary>Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [MergableProperty(false)]
    [SRCategory("CatData")]
    [SRDescription("ToolStripItemsDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public virtual ToolStripItemCollection Items
    {
      get
      {
        if (this.mobjToolStripItemCollection == null)
          this.mobjToolStripItemCollection = this.CreateItemCollection();
        return this.mobjToolStripItemCollection;
      }
    }

    /// <summary>Creates the item collection.</summary>
    /// <returns></returns>
    protected virtual ToolStripItemCollection CreateItemCollection() => new ToolStripItemCollection(this, true);

    /// <summary>Passes a reference to the cached <see cref="P:Gizmox.WebGUI.Forms.Control.LayoutEngine"></see> returned by the layout engine interface.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Layout.LayoutEngine"></see> that represents the cached layout engine returned by the layout engine interface.</returns>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual LayoutEngine LayoutEngine => (LayoutEngine) null;

    /// <summary>Gets or sets layout scheme characteristics.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.LayoutSettings"></see> representing the layout scheme characteristics.</returns>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public LayoutSettings LayoutSettings
    {
      get => (LayoutSettings) null;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating how the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> lays out the items collection.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The possible values are <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Table"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Flow"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.StackWithOverflow"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow"></see>, and <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see> is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatLayout")]
    [AmbientValue(0)]
    [SRDescription("ToolStripLayoutStyle")]
    public ToolStripLayoutStyle LayoutStyle
    {
      get
      {
        if (this.menmLayoutStyle == ToolStripLayoutStyle.StackWithOverflow)
        {
          switch (this.Orientation)
          {
            case Orientation.Horizontal:
              return ToolStripLayoutStyle.HorizontalStackWithOverflow;
            case Orientation.Vertical:
              return ToolStripLayoutStyle.VerticalStackWithOverflow;
          }
        }
        return this.menmLayoutStyle;
      }
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 4))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ToolStripLayoutStyle));
        if (this.menmLayoutStyle == value)
          return;
        this.menmLayoutStyle = value;
        int objNewOrientation;
        switch (value)
        {
          case ToolStripLayoutStyle.StackWithOverflow:
            this.UpdateLayoutStyle(this.Dock);
            goto label_11;
          case ToolStripLayoutStyle.VerticalStackWithOverflow:
            objNewOrientation = 1;
            break;
          case ToolStripLayoutStyle.Flow:
            this.UpdateOrientation(Orientation.Horizontal);
            goto label_11;
          case ToolStripLayoutStyle.Table:
            this.UpdateOrientation(Orientation.Horizontal);
            goto label_11;
          default:
            objNewOrientation = 0;
            break;
        }
        this.UpdateOrientation((Orientation) objNewOrientation);
label_11:
        this.OnLayoutStyleChanged(EventArgs.Empty);
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.Update();
      }
    }

    /// <summary>Gets the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>.</returns>
    [Browsable(false)]
    public Orientation Orientation => this.menmOrientation;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the overflow button for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> with overflow enabled.</summary>
    /// <returns>An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> with its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right"></see> and its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> value set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.Never"></see>.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripOverflowButton OverflowButton => (ToolStripOverflowButton) null;

    /// <summary>Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the look and feel of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the look and feel of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripRenderer Renderer
    {
      get => (ToolStripRenderer) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the painting styles to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripRenderMode.ManagerRenderMode"></see>.</returns>
    /// <exception cref="T:System.NotSupportedException">
    /// <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripRenderMode.Custom"></see> without the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.Renderer"></see> property being assigned to a new instance of <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see>.</exception>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value being set is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripRenderMode RenderMode
    {
      get => ToolStripRenderMode.Custom;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether ToolTips are to be displayed on <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> items. </summary>
    /// <returns>true if ToolTips are to be displayed; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatBehavior")]
    [SRDescription("ToolStripShowItemToolTipsDescr")]
    [DefaultValue(true)]
    public bool ShowItemToolTips
    {
      get => this.mblnShowItemToolTips;
      set
      {
        if (this.mblnShowItemToolTips == value)
          return;
        this.mblnShowItemToolTips = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> stretches from end to end in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> stretches from end to end in its <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>; otherwise, false. The default is false.</returns>
    [SRCategory("CatLayout")]
    [DefaultValue(false)]
    [SRDescription("ToolStripStretchDescr")]
    public virtual bool Stretch
    {
      get => this.mblnStretch;
      set
      {
        if (this.mblnStretch == value)
          return;
        this.mblnStretch = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the user can give the focus to an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> using the TAB key.</summary>
    /// <returns>true if the user can give the focus to an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> using the TAB key; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRCategory("CatBehavior")]
    [SRDescription("ControlTabStopDescr")]
    [DefaultValue(false)]
    [DispId(-516)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>
    /// Gets a value indicating whether strip supports menu stickiness.
    /// </summary>
    /// <value><c>true</c> if [supports stickiness]; otherwise, <c>false</c>.</value>
    protected virtual bool SupportMenuStickiness => false;

    /// <summary>Gets or sets the direction in which to draw text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripTextDirection.Horizontal"></see>. </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ToolStripTextDirectionDescr")]
    [DefaultValue(ToolStripTextDirection.Horizontal)]
    [SRCategory("CatAppearance")]
    public virtual ToolStripTextDirection TextDirection
    {
      get
      {
        ToolStripTextDirection textDirection = this.menmToolStripTextDirection;
        if (textDirection == ToolStripTextDirection.Inherit)
          textDirection = ToolStripTextDirection.Horizontal;
        return textDirection;
      }
      set => this.menmToolStripTextDirection = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 3) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (ToolStripTextDirection));
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>An instance of the <see cref="T:Gizmox.WebGUI.Forms.VScrollProperties"></see> class, which provides basic properties for a <see cref="T:Gizmox.WebGUI.Forms.VScrollBar"></see>.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public VScrollProperties VerticalScroll => (VScrollProperties) null;

    /// <summary>Gets the parent of this component.</summary>
    public override Component InternalParent
    {
      get => base.InternalParent;
      set
      {
        Component internalParent = base.InternalParent;
        if (internalParent == value)
          return;
        if (internalParent != null)
        {
          foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.Items)
          {
            if (toolStripItem is ToolStripMenuItem toolStripMenuItem1)
              toolStripMenuItem1.RemovingFromDOM();
            else if (toolStripItem is ToolStripDropDownItem stripDropDownItem)
            {
              foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) stripDropDownItem.DropDownItems)
              {
                if (dropDownItem is ToolStripMenuItem toolStripMenuItem)
                  toolStripMenuItem.RemovingFromDOM();
              }
            }
          }
        }
        base.InternalParent = value;
        if (value == null)
          return;
        foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.Items)
        {
          if (toolStripItem is ToolStripMenuItem toolStripMenuItem2)
            toolStripMenuItem2.AttachedToDOM();
          else if (toolStripItem is ToolStripDropDownItem stripDropDownItem)
          {
            foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) stripDropDownItem.DropDownItems)
            {
              if (dropDownItem is ToolStripMenuItem toolStripMenuItem)
                toolStripMenuItem.AttachedToDOM();
            }
          }
        }
      }
    }

    /// <summary>Resizable indication is disabled for ContextMenuStrip</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ResizableOptions Resizable
    {
      get => (ResizableOptions) null;
      set
      {
      }
    }
  }
}
