// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ScrollableControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Defines a base class for controls that support auto-scrolling behavior.
  /// </summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ScrollableControlSkin))]
  [Serializable]
  public class ScrollableControl : Control
  {
    /// <summary>
    /// Provides a property reference to DockPadding property.
    /// </summary>
    private static SerializableProperty DockPaddingProperty = SerializableProperty.Register(nameof (DockPadding), typeof (ScrollableControl.DockPaddingEdges), typeof (ScrollableControl), new SerializablePropertyMetadata((object) null));
    /// <summary>The client minimum height of the control.</summary>
    /// <value>The client minimum height of the control.</value>
    [NonSerialized]
    private int mintMinimumClientHeight = -1;
    /// <summary>The render client minimum of the control.</summary>
    /// <value>The client minimum width of the control.</value>
    [NonSerialized]
    private int mintMinimumClientWidth = -1;
    private ScrollerType menmScrollerType;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> class.
    /// </summary>
    public ScrollableControl()
    {
      this.SetStyle(ControlStyles.ContainerControl, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, false);
      this.SetState(Control.ControlState.HScroll | Control.ControlState.VScroll, true);
    }

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mintMinimumClientHeight = objReader.ReadInt32();
      this.mintMinimumClientWidth = objReader.ReadInt32();
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteInt32(this.mintMinimumClientHeight);
      objWriter.WriteInt32(this.mintMinimumClientWidth);
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderMinimumClientSize(objContext, objWriter, false);
      this.RenderScrollBars(objWriter, false);
    }

    /// <summary>Renders the scroll bars.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderScrollBars(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.GetProxyPropertyValue<bool>("AutoScroll", this.AutoScroll))
      {
        bool vscroll = this.VScroll;
        bool hscroll = this.HScroll;
        if (hscroll & vscroll)
          objWriter.WriteAttributeString("SB", "B");
        else if (hscroll)
          objWriter.WriteAttributeString("SB", "H");
        else if (vscroll)
          objWriter.WriteAttributeString("SB", "V");
        if (!(this.ScrollerType != 0 | blnForceRender))
          return;
        objWriter.WriteAttributeString("SCTP", ((int) this.ScrollerType).ToString());
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SB", string.Empty);
      }
    }

    /// <summary>Renders the preferred size.</summary>
    /// <param name="objContext">The current context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRedraw">if set to <c>true</c> force redraw.</param>
    private void RenderMinimumClientSize(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRedraw)
    {
      if (this.ShouldRenderMinimumClientHeight())
      {
        if (this.mintMinimumClientHeight > 0 && this.VScroll)
          objWriter.WriteAttributeString("MCH", this.mintMinimumClientHeight.ToString());
        else if (blnForceRedraw)
          objWriter.WriteAttributeString("MCH", "0");
      }
      if (!this.ShouldRenderMinimumClientWidth())
        return;
      if (this.mintMinimumClientWidth > 0 && this.HScroll)
      {
        objWriter.WriteAttributeString("MCW", this.mintMinimumClientWidth.ToString());
      }
      else
      {
        if (!blnForceRedraw)
          return;
        objWriter.WriteAttributeString("MCW", "0");
      }
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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        this.RenderScrollBars(objWriter, true);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
        return;
      this.RenderMinimumClientSize(objContext, objWriter, true);
    }

    /// <summary>
    /// Scrolls the specified child control into view on an auto-scroll enabled control.
    /// </summary>
    /// <param name="objActiveControl">The child control to scroll into view. </param>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void ScrollControlIntoView(Control objActiveControl)
    {
      if (!this.IsDescendant(objActiveControl) || !this.AutoScroll || !this.HScroll && !this.VScroll || objActiveControl == null)
        return;
      this.InvokeMethod("Controls_ScrollIntoView", (object) objActiveControl.ID, (object) this.ID, (object) "0", (object) true);
    }

    /// <summary>Sets the minimum size of the client.</summary>
    /// <param name="objProposedSize">Proposed size.</param>
    protected override void SetMinimumClientSize(Size objProposedSize)
    {
      if (this.AutoScroll)
      {
        Size preferredSize = this.GetPreferredSize(objProposedSize, true);
        this.mintMinimumClientWidth = preferredSize.Width;
        this.mintMinimumClientHeight = preferredSize.Height;
      }
      else
      {
        this.mintMinimumClientWidth = -1;
        this.mintMinimumClientHeight = -1;
      }
    }

    /// <summary>Sets the size of the auto-scroll margins.</summary>
    /// <param name="y">The <see cref="P:System.Drawing.Size.Height"></see> value. </param>
    /// <param name="x">The <see cref="P:System.Drawing.Size.Width"></see> value. </param>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void SetAutoScrollMargin(int x, int y)
    {
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new ScrollableControlRenderer(this);

    /// <summary>Gets or sets the size of the auto scroll min.</summary>
    /// <value>The size of the auto scroll min.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size AutoScrollMinSize
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>Indicates if to render padding attribute</summary>
    /// <returns></returns>
    protected override bool ShouldRenderPaddingAttribute(Padding objPadding) => (Padding) PaddingValue.Empty != objPadding;

    /// <summary>
    /// Gets or sets a value indicating whether the vertical scroll bar is visible.
    /// </summary>
    /// <value>true if the vertical scroll bar is visible; otherwise, false.</value>
    [DefaultValue(true)]
    protected bool VScroll
    {
      get => this.GetState(Control.ControlState.VScroll);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.VScroll, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the horizontal scroll bar is visible.
    /// </summary>
    /// <value>true if the horizontal scroll bar is visible; otherwise, false.</value>
    [DefaultValue(true)]
    protected bool HScroll
    {
      get => this.GetState(Control.ControlState.HScroll);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.HScroll, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
    /// </summary>
    /// <value>true if the container enables auto-scrolling; otherwise, false. The default value is false.</value>
    [SRCategory("CatLayout")]
    [SRDescription("FormAutoScrollDescr")]
    [DefaultValue(false)]
    [Localizable(true)]
    [ProxyBrowsable(true)]
    public virtual bool AutoScroll
    {
      get => this.GetState(Control.ControlState.AutoScroll);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.AutoScroll, value))
          return;
        this.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the type of the scroller.</summary>
    /// <value>The type of the scroller.</value>
    [SRCategory("CatLayout")]
    [SRDescription("FormScrollerTypeDescr")]
    [DefaultValue(ScrollerType.Default)]
    [Localizable(true)]
    [ProxyBrowsable(true)]
    public ScrollerType ScrollerType
    {
      get => this.menmScrollerType;
      set
      {
        if (this.menmScrollerType == value)
          return;
        this.menmScrollerType = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets a value indicating whether [should render minimum client size].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [should render minimum client size]; otherwise, <c>false</c>.
    /// </value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual bool ShouldRenderMinimumClientSize => this.ShouldRenderMinimumClientWidth() || this.ShouldRenderMinimumClientHeight();

    /// <summary>
    /// Gets a value indicating whether [should render minimum client Width].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [should render minimum client Width]; otherwise, <c>false</c>.
    /// </value>
    private bool ShouldRenderMinimumClientWidth() => this.Dock != DockStyle.Fill && this.Dock != DockStyle.Top && this.Dock != DockStyle.Bottom || this.AutoScroll;

    /// <summary>
    /// Gets a value indicating whether [should render minimum client height].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [should render minimum client height]; otherwise, <c>false</c>.
    /// </value>
    private bool ShouldRenderMinimumClientHeight() => this.Dock != DockStyle.Fill && this.Dock != DockStyle.Left && this.Dock != DockStyle.Right || this.AutoScroll;

    /// <summary>
    /// Gets the dock padding settings for all edges of the control.
    /// </summary>
    /// <value>A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges" /> that represents the padding for all the edges of a docked control.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ScrollableControl.DockPaddingEdges DockPadding
    {
      get
      {
        ScrollableControl.DockPaddingEdges objValue = this.GetValue<ScrollableControl.DockPaddingEdges>(ScrollableControl.DockPaddingProperty);
        if (objValue == null)
        {
          objValue = new ScrollableControl.DockPaddingEdges(this);
          this.SetValue<ScrollableControl.DockPaddingEdges>(ScrollableControl.DockPaddingProperty, objValue);
        }
        return objValue;
      }
    }

    /// <summary>Prevent serializing DockPadding if not required</summary>
    /// <returns>whether the store value differs form the default skin value.</returns>
    private bool ShouldSerializeDockPadding()
    {
      ScrollableControl.DockPaddingEdges dockPaddingEdges = this.GetValue<ScrollableControl.DockPaddingEdges>(ScrollableControl.DockPaddingProperty);
      return dockPaddingEdges != null && !this.Skin.Padding.Value.Equals((object) new Padding(dockPaddingEdges.Left, dockPaddingEdges.Top, dockPaddingEdges.Right, dockPaddingEdges.Bottom));
    }

    /// <summary>Gets the horizontal padding.</summary>
    /// <value>The horizontal padding.</value>
    internal int HorizontalPadding
    {
      get
      {
        ScrollableControl.DockPaddingEdges dockPadding = this.DockPadding;
        return dockPadding.Left + dockPadding.Right;
      }
    }

    /// <summary>Gets the vertical padding.</summary>
    /// <value>The vertical padding.</value>
    internal int VerticalPadding
    {
      get
      {
        ScrollableControl.DockPaddingEdges dockPadding = this.DockPadding;
        return dockPadding.Top + dockPadding.Bottom;
      }
    }

    /// <summary>Gets the display size.</summary>
    /// <value></value>
    protected override Size DisplaySize => this.AutoScroll ? this.PreferredSize : base.DisplaySize;

    /// <summary>Gets or sets the size of the auto-scroll margin.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the height and width of the auto-scroll margin in pixels.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The <see cref="P:System.Drawing.Size.Height"></see> or <see cref="P:System.Drawing.Size.Width"></see> value assigned is less than 0. </exception>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatLayout")]
    [Localizable(true)]
    [SRDescription("FormAutoScrollMarginDescr")]
    public Size AutoScrollMargin
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>Determines the border padding for docked controls.</summary>
    [TypeConverter(typeof (ScrollableControl.DockPaddingEdgesConverter))]
    [Serializable]
    public class DockPaddingEdges
    {
      private ScrollableControl mobjOwner;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl.DockPaddingEdges" /> class.
      /// </summary>
      /// <param name="objOwner">The owner.</param>
      internal DockPaddingEdges(ScrollableControl objOwner) => this.mobjOwner = objOwner;

      internal bool IsAll => this.mobjOwner.Padding.All != -1;

      /// <summary>
      /// Gets or sets the padding width for all edges of a docked control.
      /// </summary>
      /// <value>The padding width, in pixels.</value>
      [SRDescription("PaddingAllDescr")]
      [RefreshProperties(RefreshProperties.All)]
      public int All
      {
        get => this.mobjOwner.Padding.All;
        set => this.mobjOwner.Padding = this.mobjOwner.Padding with
        {
          All = value
        };
      }

      /// <summary>
      /// Gets or sets the padding width for the bottom edge of a docked control.
      /// </summary>
      /// <value>The padding width, in pixels.</value>
      [SRDescription("PaddingBottomDescr")]
      [RefreshProperties(RefreshProperties.All)]
      public int Bottom
      {
        get => this.mobjOwner.Padding.Bottom;
        set => this.mobjOwner.Padding = this.mobjOwner.Padding with
        {
          Bottom = value
        };
      }

      /// <summary>
      /// Gets or sets the padding width for the top edge of a docked control.
      /// </summary>
      /// <value>The padding width, in pixels.</value>
      [SRDescription("PaddingTopDescr")]
      [RefreshProperties(RefreshProperties.All)]
      public int Top
      {
        get => this.mobjOwner.Padding.Top;
        set => this.mobjOwner.Padding = this.mobjOwner.Padding with
        {
          Top = value
        };
      }

      /// <summary>
      /// Gets or sets the padding width for the right edge of a docked control.
      /// </summary>
      /// <value>The padding width, in pixels.</value>
      [RefreshProperties(RefreshProperties.All)]
      [SRDescription("PaddingRightDescr")]
      public int Right
      {
        get => this.mobjOwner.Padding.Right;
        set => this.mobjOwner.Padding = this.mobjOwner.Padding with
        {
          Right = value
        };
      }

      /// <summary>
      /// Gets or sets the padding width for the left edge of a docked control.
      /// </summary>
      /// <value>The padding width, in pixels.</value>
      [RefreshProperties(RefreshProperties.All)]
      [SRDescription("PaddingLeftDescr")]
      public int Left
      {
        get => this.mobjOwner.Padding.Left;
        set => this.mobjOwner.Padding = this.mobjOwner.Padding with
        {
          Left = value
        };
      }

      private bool ShouldSerializeAll() => this.IsAll && this.All != 0;

      private bool ShouldSerializeBottom() => !this.IsAll && this.Bottom != 0;

      private bool ShouldSerializeLeft() => !this.IsAll && this.Left != 0;

      private bool ShouldSerializeRight() => !this.IsAll && this.Right != 0;

      private bool ShouldSerializeTop() => !this.IsAll && this.Top != 0;

      /// <summary>Returns an empty string.</summary>
      /// <returns>An empty string.</returns>
      public override string ToString() => "";
    }

    /// <summary>DockPaddingEdgesConverter class.</summary>
    [Serializable]
    public class DockPaddingEdgesConverter : TypeConverter
    {
      /// <summary>
      /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
      /// </summary>
      /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
      /// <param name="objValue">An <see cref="T:System.Object"></see> that specifies the type of array for which to get properties.</param>
      /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that is used as a filter.</param>
      /// <returns>
      /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> with the properties that are exposed for this data type, or null if there are no properties.
      /// </returns>
      public override PropertyDescriptorCollection GetProperties(
        ITypeDescriptorContext objContext,
        object objValue,
        Attribute[] arrAttributes)
      {
        return TypeDescriptor.GetProperties(typeof (ScrollableControl.DockPaddingEdges), arrAttributes).Sort(new string[5]
        {
          "All",
          "Left",
          "Top",
          "Right",
          "Bottom"
        });
      }

      /// <summary>
      /// Returns whether this object supports properties, using the specified context.
      /// </summary>
      /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
      /// <returns>
      /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"></see> should be called to find the properties of this object; otherwise, false.
      /// </returns>
      public override bool GetPropertiesSupported(ITypeDescriptorContext objContext) => true;
    }
  }
}
