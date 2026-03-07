// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SplitContainer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a control consisting of a movable bar that divides a container's display area into two resizable panels.
  /// </summary>
  /// <remarks>
  /// You can add controls to the two resizable panels, and you can add other SplitContainer controls to existing SplitContainer panels to create many resizable display areas.
  /// Use the SplitContainer control to divide the display area of a container (such as a Form) and allow the user to resize controls that are added to the SplitContainer panels. When the user passes the mouse pointer over the splitter, the cursor changes to indicate that the controls inside the SplitContainer control can be resized.
  /// </remarks>
  [ToolboxItem(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [DefaultEvent("SplitterMoved")]
  [SRDescription("DescriptionSplitContainer")]
  [ComVisible(true)]
  [ToolboxBitmap(typeof (SplitContainer), "SplitContainer_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitContainerController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.SplitContainerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Designer("Gizmox.WebGUI.Forms.Design.SplitContainerDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ToolboxItemCategory("Containers")]
  [Gizmox.WebGUI.Forms.MetadataTag("P")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (SplitContainerSkin))]
  [Serializable]
  public class SplitContainer : ContainerControl
  {
    /// <summary>Provides a property reference to TabStop property.</summary>
    private static SerializableProperty TabStopProperty = SerializableProperty.Register(nameof (TabStop), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to BorderStyle property.
    /// Default defined in the skin.
    /// </summary>
    private static SerializableProperty BorderStyleProperty = SerializableProperty.Register(nameof (BorderStyle), typeof (BorderStyle), typeof (SplitContainer));
    /// <summary>
    /// Provides a property reference to AnchorPoint property.
    /// </summary>
    private static SerializableProperty AnchorPointProperty = SerializableProperty.Register(nameof (AnchorPoint), typeof (Point), typeof (SplitContainer), new SerializablePropertyMetadata((object) Point.Empty));
    /// <summary>Provides a property reference to BorderSize property.</summary>
    private static SerializableProperty BorderSizeProperty = SerializableProperty.Register(nameof (BorderSize), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 0));
    private static readonly SerializableProperty SplitterDragProperty = SerializableProperty.Register(nameof (SplitterDrag), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SplitterFocusedProperty = SerializableProperty.Register(nameof (SplitterFocused), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SplitterWidthProperty = SerializableProperty.Register(nameof (SplitterWidth), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 4));
    private static readonly SerializableProperty Panel2MinSizeProperty = SerializableProperty.Register(nameof (Panel2MinSize), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 25));
    private static readonly SerializableProperty Panel1MinSizeProperty = SerializableProperty.Register(nameof (Panel1MinSize), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 25));
    private static readonly SerializableProperty Panel1Property = SerializableProperty.Register(nameof (Panel1), typeof (SplitterPanel), typeof (SplitContainer), new SerializablePropertyMetadata((object) null));
    private static readonly SerializableProperty Panel2Property = SerializableProperty.Register(nameof (Panel2), typeof (SplitterPanel), typeof (SplitContainer), new SerializablePropertyMetadata((object) null));
    private static readonly SerializableProperty SplitterIncrementProperty = SerializableProperty.Register(nameof (SplitterIncrement), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 1));
    private static readonly SerializableProperty SplitterRectangleInternalProperty = SerializableProperty.Register(nameof (SplitterRectangleInternal), typeof (Rectangle), typeof (SplitContainer), new SerializablePropertyMetadata((object) Rectangle.Empty));
    private static readonly SerializableProperty InitialSplitterRectangleProperty = SerializableProperty.Register(nameof (InitialSplitterRectangle), typeof (Rectangle), typeof (SplitContainer), new SerializablePropertyMetadata((object) new Rectangle()));
    private static readonly SerializableProperty InitialSplitterDistanceProperty = SerializableProperty.Register(nameof (InitialSplitterDistance), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 0));
    private static readonly SerializableProperty FixedPanelProperty = SerializableProperty.Register(nameof (FixedPanel), typeof (FixedPanel), typeof (SplitContainer), new SerializablePropertyMetadata((object) FixedPanel.None));
    private static readonly SerializableProperty SplitterDistanceProperty = SerializableProperty.Register(nameof (SplitterDistance), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 50));
    private static readonly SerializableProperty SplitterDistanceInternalProperty = SerializableProperty.Register(nameof (SplitterDistanceInternal), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 50));
    private static readonly SerializableProperty SplitterClickProperty = SerializableProperty.Register(nameof (SplitterClick), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SplitterMoveProperty = SerializableProperty.Register("SplitMove", typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SplitContainerScalingProperty = SerializableProperty.Register(nameof (SplitContainerScaling), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SplitBreakProperty = SerializableProperty.Register(nameof (SplitBreak), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SplitterBeginProperty = SerializableProperty.Register(nameof (SplitterBegin), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty SetSplitterDistanceProperty = SerializableProperty.Register(nameof (SetSplitterDistance), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty ResizeCalledProperty = SerializableProperty.Register(nameof (ResizeCalled), typeof (bool), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty RatioWidthProperty = SerializableProperty.Register(nameof (RatioWidth), typeof (double), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty RatioHeightProperty = SerializableProperty.Register(nameof (RatioHeight), typeof (double), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty PanelSizeProperty = SerializableProperty.Register(nameof (PanelSize), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty OverrideCursorProperty = SerializableProperty.Register(nameof (OverrideCursor), typeof (Cursor), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty LastDrawSplitProperty = SerializableProperty.Register(nameof (LastDrawSplit), typeof (int), typeof (SplitContainer), new SerializablePropertyMetadata((object) 1));
    private static readonly SerializableProperty OrientationProperty = SerializableProperty.Register(nameof (Orientation), typeof (Orientation), typeof (SplitContainer), new SerializablePropertyMetadata((object) Orientation.Vertical));
    private static readonly SerializableProperty NextActiveControlProperty = SerializableProperty.Register(nameof (NextActiveControl), typeof (Control), typeof (SplitContainer), new SerializablePropertyMetadata((object) false));
    private static readonly SerializableProperty ContainerSplitterPrivateProperty = SerializableProperty.Register(nameof (ContainerSplitterPrivate), typeof (SplitContainer.ContainerSplitter), typeof (SplitContainer), new SerializablePropertyMetadata((object) null));
    private static readonly SerializableEvent EVENT_MOVED = SerializableEvent.Register("Event", typeof (Delegate), typeof (SplitContainer));
    private static readonly SerializableEvent EVENT_MOVING = SerializableEvent.Register("Event", typeof (Delegate), typeof (SplitContainer));
    private const int DRAW_END = 3;
    private const int DRAW_MOVE = 2;
    private const int DRAW_START = 1;
    private const int mcntRightBorder = 5;
    private const int mcntLeftBorder = 2;

    /// <summary>Occurs when [auto size changed].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler AutoSizeChanged;

    /// <summary>
    /// Occurs when the value of the BackgroundImage property changes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    public new event EventHandler BackgroundImageChanged;

    /// <summary>
    /// Occurs when the BackgroundImageLayout property changes.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler BackgroundImageLayoutChanged;

    /// <summary>
    /// Occurs when a new control is added to the ControlCollection.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event ControlEventHandler ControlAdded;

    /// <summary>
    /// Occurs when a control is removed from the ControlCollection.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event ControlEventHandler ControlRemoved;

    /// <summary>Occurs when the PaddingChanged property changes.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler PaddingChanged;

    /// <summary>Occurs when [splitter moved].</summary>
    [SRDescription("SplitterSplitterMovedDescr")]
    [SRCategory("CatBehavior")]
    public event SplitterEventHandler SplitterMoved;

    /// <summary>Occurs when [splitter moving].</summary>
    [SRDescription("SplitterSplitterMovingDescr")]
    [SRCategory("CatBehavior")]
    public event SplitterCancelEventHandler SplitterMoving;

    /// <summary>Occurs when the Text property value changes.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler TextChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitContainer" /> class.
    /// </summary>
    public SplitContainer()
    {
      this.Orientation = Orientation.Vertical;
      this.Panel1MinSize = 25;
      this.Panel2MinSize = 25;
      this.TabStop = true;
      this.SplitterIncrement = 1;
      this.SplitterDistanceInternal = 50;
      this.SplitterWidth = 4;
      this.SetSplitterDistanceDirectly(50);
      this.LastDrawSplit = 1;
      this.AnchorPoint = Point.Empty;
      this.Panel1 = new SplitterPanel(this);
      this.Panel1.TabIndex = 0;
      this.ContainerSplitterPrivate = new SplitContainer.ContainerSplitter(this);
      this.ContainerSplitterPrivate.TabIndex = 1;
      this.Panel2 = new SplitterPanel(this);
      this.Panel2.TabIndex = 2;
      this.SplitterRectangleInternal = new Rectangle();
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      ((ClientUtils.ReadOnlyControlCollection) this.Controls).AddInternal((Control) this.Panel2);
      ((ClientUtils.ReadOnlyControlCollection) this.Controls).AddInternal((Control) this.ContainerSplitterPrivate);
      ((ClientUtils.ReadOnlyControlCollection) this.Controls).AddInternal((Control) this.Panel1);
      this.UpdateSplitter();
    }

    /// <summary>Renders the panel type attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      objWriter.WriteAttributeString("TP", "Normal");
    }

    /// <summary>
    /// The Border size of the SplitContainer as int.
    /// Used to calculate movement and distances.
    /// </summary>
    private int BorderSize
    {
      get => this.GetValue<int>(SplitContainer.BorderSizeProperty);
      set => this.SetValue<int>(SplitContainer.BorderSizeProperty, value);
    }

    /// <summary>
    /// A boolean indicating whether in this instance the splitter has focus.
    /// Used to calculate movement and distances.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if in this instance the splitter is focused. otherwise, <c>false</c>.
    /// </value>
    private bool SplitterFocused
    {
      get => this.GetValue<bool>(SplitContainer.SplitterFocusedProperty);
      set
      {
        if (this.SplitterFocused == value)
          return;
        this.SetValue<bool>(SplitContainer.SplitterFocusedProperty, value);
      }
    }

    /// <summary>
    /// A boolean indicating whether this instance the splitter is dragged.
    /// Used in splitter movement.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance the splitter is dragged. otherwise, <c>false</c>.
    /// </value>
    private bool SplitterDrag
    {
      get => this.GetValue<bool>(SplitContainer.SplitterDragProperty);
      set => this.SetValue<bool>(SplitContainer.SplitterDragProperty, value);
    }

    /// <summary>
    /// Get/Set Boolean indicating whether safe to set the SplitterDistance.
    /// </summary>
    /// <value><c>true</c> if safe to set the SplitterDistance, <c>false</c> otherwise.</value>
    private bool SetSplitterDistance
    {
      get => this.GetValue<bool>(SplitContainer.SetSplitterDistanceProperty);
      set => this.SetValue<bool>(SplitContainer.SetSplitterDistanceProperty, value);
    }

    /// <summary>
    /// Get/Set An integer indicating the perpendicular length of the fixed panel
    /// to the splitter. If Fixed. None, the value is the length of the bottom/right panel.
    /// </summary>
    private int PanelSize
    {
      get => this.GetValue<int>(SplitContainer.PanelSizeProperty);
      set => this.SetValue<int>(SplitContainer.PanelSizeProperty, value);
    }

    /// <summary>Get/Set The next active Control.</summary>
    private Control NextActiveControl
    {
      get => this.GetValue<Control>(SplitContainer.NextActiveControlProperty);
      set => this.SetValue<Control>(SplitContainer.NextActiveControlProperty, value);
    }

    /// <summary>
    /// A double value used to hold the ratio between the height of the base conrol and
    /// another, e.g. splitter width, panel1 width etc.
    /// </summary>
    private double RatioHeight
    {
      get => this.GetValue<double>(SplitContainer.RatioHeightProperty);
      set => this.SetValue<double>(SplitContainer.RatioHeightProperty, value);
    }

    /// <summary>
    /// A double value used to hold the ratio between the width of the base conrol and
    /// another, e.g. splitter width, panel1 width etc.
    /// </summary>
    private double RatioWidth
    {
      get => this.GetValue<double>(SplitContainer.RatioWidthProperty);
      set => this.SetValue<double>(SplitContainer.RatioWidthProperty, value);
    }

    /// <summary>
    /// Boolean indicating whether to begin actions on the splitter.
    /// </summary>
    /// <value><c>true</c> if to begin actions on the splitter, <c>false</c> otherwise.</value>
    private bool SplitterBegin
    {
      get => this.GetValue<bool>(SplitContainer.SplitterBeginProperty);
      set => this.SetValue<bool>(SplitContainer.SplitterBeginProperty, value);
    }

    /// <summary>
    /// Get\Set a boolean indicating whether resize on the control was called.
    /// Used to indicate for example whether to update the ratio width/height.
    /// </summary>
    /// <value><c>true</c> if resize on the control was called, <c>false</c> otherwise.</value>
    private bool ResizeCalled
    {
      get => this.GetValue<bool>(SplitContainer.ResizeCalledProperty);
      set => this.SetValue<bool>(SplitContainer.ResizeCalledProperty, value);
    }

    /// <summary>
    /// Boolean indicating whether to break actions on the splitter.
    /// </summary>
    /// <value><c>true</c> if to break actions on the splitter, <c>false</c> otherwise.</value>
    private bool SplitBreak
    {
      get => this.GetValue<bool>(SplitContainer.SplitBreakProperty);
      set => this.SetValue<bool>(SplitContainer.SplitBreakProperty, value);
    }

    /// <summary>
    /// Boolean indicating whether the splitContainer is in scaling process.
    /// </summary>
    /// <value><c>true</c> if the splitter is in scaling process, <c>false</c> otherwise.</value>
    private bool SplitContainerScaling
    {
      get => this.GetValue<bool>(SplitContainer.SplitContainerScalingProperty);
      set => this.SetValue<bool>(SplitContainer.SplitContainerScalingProperty, value);
    }

    /// <summary>
    /// Boolean indicating whether the splitter is in movement.
    /// </summary>
    /// <value><c>true</c> if the splitter is in movement, <c>false</c> otherwise.</value>
    private bool SplitterMove
    {
      get => this.GetValue<bool>(SplitContainer.SplitterMoveProperty);
      set => this.SetValue<bool>(SplitContainer.SplitterMoveProperty, value);
    }

    /// <summary>Boolean indicating whether the splitter is clicked.</summary>
    /// <value><c>true</c> if the splitter is clicked, <c>false</c> otherwise.</value>
    private bool SplitterClick
    {
      get => this.GetValue<bool>(SplitContainer.SplitterClickProperty);
      set => this.SetValue<bool>(SplitContainer.SplitterClickProperty, value);
    }

    /// <summary>The Anchor of the SplitContainer as Point object</summary>
    private Point AnchorPoint
    {
      get => this.GetValue<Point>(SplitContainer.AnchorPointProperty);
      set => this.SetValue<Point>(SplitContainer.AnchorPointProperty, value);
    }

    /// <summary>
    /// Gets a value indicating whether to reverse control rendering.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to reverse control rendering; otherwise, <c>false</c>.
    /// </value>
    protected override bool ReverseControls => this.FixedPanel == FixedPanel.Panel2;

    /// <summary>
    /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
    /// </summary>
    /// <value>
    /// true if the container enables auto-scrolling; otherwise, false. The default value is false.
    /// </value>
    [SRDescription("FormAutoScrollDescr")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [DefaultValue(false)]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    public override bool AutoScroll
    {
      get => false;
      set => base.AutoScroll = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <value></value>
    /// <returns>true if enabled; otherwise, false.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>
    /// Gets or sets the background image displayed in the control.
    /// </summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [ProxyBrowsable(true)]
    public new ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>
    /// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
    /// </summary>
    /// <value></value>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>
    /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
    /// </summary>
    /// <value></value>
    /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
    [SRDescription("ContainerControlBindingContextDescr")]
    [Browsable(false)]
    public override BindingContext BindingContext
    {
      get => this.BindingContextInternal;
      set => this.BindingContextInternal = value;
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [SRCategory("CatAppearance")]
    [DefaultValue(0)]
    [DispId(-504)]
    [SRDescription("SplitterBorderStyleDescr")]
    public new BorderStyle BorderStyle
    {
      get => this.GetValue<BorderStyle>(SplitContainer.BorderStyleProperty, this.Skin.BorderStyle);
      set
      {
        if (!Enum.IsDefined(typeof (BorderStyle), (object) value))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (BorderStyle));
        BorderStyle borderStyle = this.Skin.BorderStyle;
        if (this.SetValue<BorderStyle>(SplitContainer.BorderStyleProperty, value, borderStyle) && borderStyle != value)
        {
          this.Invalidate();
          this.SetInnerMostBorder(this);
          Control parentInternal = (Control) (this.ParentInternal as SplitterPanel);
          if (parentInternal != null)
          {
            SplitContainer owner = ((SplitterPanel) parentInternal).Owner;
            owner.SetInnerMostBorder(owner);
          }
        }
        switch (value)
        {
          case BorderStyle.None:
            this.BorderSize = 0;
            break;
          case BorderStyle.FixedSingle:
            this.BorderSize = 1;
            break;
          case BorderStyle.Fixed3D:
            this.BorderSize = 4;
            break;
        }
      }
    }

    private bool CollapsedMode => this.Panel1Collapsed || this.Panel2Collapsed;

    /// <summary>
    /// Gets the collection of controls contained within the control.
    /// </summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Control.ControlCollection Controls => base.Controls;

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(150, 100);

    /// <summary>Gets/Sets the controls docking style</summary>
    /// <value></value>
    public new DockStyle Dock
    {
      get => base.Dock;
      set
      {
        base.Dock = value;
        if (this.ParentInternal != null && this.ParentInternal is SplitterPanel)
        {
          SplitContainer owner = ((SplitterPanel) this.ParentInternal).Owner;
          owner.SetInnerMostBorder(owner);
        }
        this.ResizeSplitContainer();
      }
    }

    /// <summary>
    /// Gets or sets the initial size and location of the splitter relative to the SplitContainer.
    /// Used as preliminary in calculations of drawing the splitter.
    /// The default value is .net Deafult of type Rectangle.
    /// </summary>
    /// <value>Rectangle, The default value is .net Deafult of type Rectangle.</value>
    [SRCategory("CatLayout")]
    [SRDescription("SplitContainerFixedPanelDescr")]
    [DefaultValue(0)]
    private Rectangle InitialSplitterRectangle
    {
      get => this.GetValue<Rectangle>(SplitContainer.InitialSplitterRectangleProperty);
      set => this.SetValue<Rectangle>(SplitContainer.InitialSplitterRectangleProperty, value);
    }

    /// <summary>
    /// Gets or sets the initial location of the splitter, in pixels, from the left or top
    /// edge of the SplitContainer.
    /// Used as preliminary in calculations of drawing the splitter.
    /// The default value is 0.
    /// </summary>
    /// <value>Integer, The default value is 0.</value>
    [SRCategory("CatLayout")]
    [SRDescription("SplitContainerFixedPanelDescr")]
    [DefaultValue(0)]
    private int InitialSplitterDistance
    {
      get => this.GetValue<int>(SplitContainer.InitialSplitterDistanceProperty);
      set => this.SetValue<int>(SplitContainer.InitialSplitterDistanceProperty, value);
    }

    /// <summary>
    /// Gets or sets which SplitContainer panel remains the same size when the container
    /// is resized.
    /// The value is one of the values of FixedPanel enum.
    /// </summary>
    /// <value>One of the values of FixedPanel enum. The default value is None. </value>
    [SRCategory("CatLayout")]
    [SRDescription("SplitContainerFixedPanelDescr")]
    [DefaultValue(0)]
    public FixedPanel FixedPanel
    {
      get => this.GetValue<FixedPanel>(SplitContainer.FixedPanelProperty);
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (FixedPanel));
        if (!this.SetValue<FixedPanel>(SplitContainer.FixedPanelProperty, value))
          return;
        this.PanelSize = value != FixedPanel.Panel2 ? this.SplitterDistanceInternal : (this.Orientation != Orientation.Vertical ? this.Height - this.SplitterDistanceInternal - this.SplitterWidthInternal : this.Width - this.SplitterDistanceInternal - this.SplitterWidthInternal);
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (FixedPanel));
      }
    }

    internal override bool IsContainerControl => true;

    /// <summary>Gets the critical events internal.</summary>
    /// <value>
    /// 	<c>true</c> if this instance is splitter moved registered; otherwise, <c>false</c>.
    /// </value>
    /// <returns></returns>
    internal bool IsSplitterMovedRegistered => this.SplitterMoved != null;

    /// <summary>
    /// Gets or sets a value indicating whether in this instance the splitter is fixed or movable.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is splitter fixed. otherwise, <c>false</c>.
    /// </value>
    [SRCategory("CatLayout")]
    [SRDescription("SplitContainerIsSplitterFixedDescr")]
    [DefaultValue(false)]
    [Localizable(true)]
    public bool IsSplitterFixed
    {
      get
      {
        SplitContainer.ContainerSplitter containerSplitterPrivate = this.ContainerSplitterPrivate;
        return containerSplitterPrivate != null && containerSplitterPrivate.IsSplitterFixed;
      }
      set
      {
        SplitContainer.ContainerSplitter containerSplitterPrivate = this.ContainerSplitterPrivate;
        if (containerSplitterPrivate == null)
          return;
        containerSplitterPrivate.IsSplitterFixed = value;
      }
    }

    private bool IsSplitterMovable => this.Orientation == Orientation.Vertical ? this.Width >= this.Panel1MinSize + this.SplitterWidthInternal + this.Panel2MinSize : this.Height >= this.Panel1MinSize + this.SplitterWidthInternal + this.Panel2MinSize;

    /// <summary>Gets or sets the orientation.</summary>
    /// <value>The orientation.</value>
    [SRCategory("CatBehavior")]
    [SRDescription("SplitContainerOrientationDescr")]
    [DefaultValue(1)]
    [Localizable(true)]
    public Orientation Orientation
    {
      get => this.GetValue<Orientation>(SplitContainer.OrientationProperty);
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 1))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (Orientation));
        if (!this.SetValue<Orientation>(SplitContainer.OrientationProperty, value))
          return;
        this.SetSplitterDistanceDirectly(0);
        this.SplitterDistance = this.SplitterDistanceInternal;
        this.UpdateSplitter();
        this.FireObservableItemPropertyChanged(nameof (Orientation));
        this.Update();
      }
    }

    /// <summary>Get/Set a private instance of ContainerSplitter</summary>
    private SplitContainer.ContainerSplitter ContainerSplitterPrivate
    {
      get => this.GetValue<SplitContainer.ContainerSplitter>(SplitContainer.ContainerSplitterPrivateProperty);
      set => this.SetValue<SplitContainer.ContainerSplitter>(SplitContainer.ContainerSplitterPrivateProperty, value);
    }

    /// <summary>
    /// Get/Set an integer holding the length of the splitBar (on move).
    /// </summary>
    private int LastDrawSplit
    {
      get => this.GetValue<int>(SplitContainer.LastDrawSplitProperty);
      set => this.SetValue<int>(SplitContainer.LastDrawSplitProperty, value);
    }

    /// <summary>
    /// Get/Set the cursur when set over the splitter (vertical/horizontal).
    /// </summary>
    private Cursor OverrideCursor
    {
      get => this.GetValue<Cursor>(SplitContainer.OverrideCursorProperty);
      set => this.SetValue<Cursor>(SplitContainer.OverrideCursorProperty, value);
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>
    /// Gets the left or top panel of the SplitContainer, depending on Orientation.
    /// </summary>
    /// <value>The left or top panel of the SplitContainer, depending on Orientation, as SplitterPanel. </value>
    [SRCategory("CatAppearance")]
    [Localizable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("SplitContainerPanel1Descr")]
    public SplitterPanel Panel1
    {
      get => this.GetValue<SplitterPanel>(SplitContainer.Panel1Property);
      private set => this.SetValue<SplitterPanel>(SplitContainer.Panel1Property, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [panel1 collapsed].
    /// </summary>
    /// <value><c>true</c> if [panel1 collapsed]; otherwise, <c>false</c>.</value>
    [SRDescription("SplitContainerPanel1CollapsedDescr")]
    [SRCategory("CatLayout")]
    [DefaultValue(false)]
    public bool Panel1Collapsed
    {
      get => this.Panel1.Collapsed;
      set
      {
        SplitterPanel panel1 = this.Panel1;
        if (value == panel1.Collapsed)
          return;
        if (value && this.Panel2.Collapsed)
          this.CollapsePanel(this.Panel2, false);
        this.CollapsePanel(panel1, value);
        this.FireObservableItemPropertyChanged(nameof (Panel1Collapsed));
      }
    }

    /// <summary>
    /// Gets or sets the minimum distance in pixels of the splitter from the left or top
    /// edge of Panel1.
    /// </summary>
    /// <value>The minimum distance in pixels of the splitter from the left or top edge of
    /// Panel1.</value>
    [Localizable(true)]
    [SRCategory("CatLayout")]
    [DefaultValue(25)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("SplitContainerPanel1MinSizeDescr")]
    public int Panel1MinSize
    {
      get => this.GetValue<int>(SplitContainer.Panel1MinSizeProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (Panel1MinSize), SR.GetString("InvalidLowBoundArgument", (object) nameof (Panel1MinSize), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "0"));
        if (this.Orientation == Orientation.Vertical)
        {
          if (this.DesignMode && this.Width != this.DefaultSize.Width && value + this.Panel2MinSize + this.SplitterWidth > this.Width)
            throw new ArgumentOutOfRangeException(nameof (Panel1MinSize), SR.GetString("InvalidArgument", (object) nameof (Panel1MinSize), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        }
        else if (this.Orientation == Orientation.Horizontal && this.DesignMode && this.Height != this.DefaultSize.Height && value + this.Panel2MinSize + this.SplitterWidth > this.Height)
          throw new ArgumentOutOfRangeException(nameof (Panel1MinSize), SR.GetString("InvalidArgument", (object) nameof (Panel1MinSize), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(SplitContainer.Panel1MinSizeProperty, value) || value <= this.SplitterDistanceInternal)
          return;
        this.SplitterDistance = value;
        this.FireObservableItemPropertyChanged(nameof (Panel1MinSize));
      }
    }

    /// <summary>
    /// Gets the right or bottom panel of the SplitContainer, depending on Orientation.
    /// </summary>
    /// <value>Gets the right or bottom panel of the SplitContainer, depending on Orientation. </value>
    [SRCategory("CatAppearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("SplitContainerPanel2Descr")]
    [Localizable(false)]
    public SplitterPanel Panel2
    {
      get => this.GetValue<SplitterPanel>(SplitContainer.Panel2Property);
      private set => this.SetValue<SplitterPanel>(SplitContainer.Panel2Property, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [panel2 collapsed].
    /// </summary>
    /// <value><c>true</c> if [panel2 collapsed]; otherwise, <c>false</c>.</value>
    [SRCategory("CatLayout")]
    [SRDescription("SplitContainerPanel2CollapsedDescr")]
    [DefaultValue(false)]
    public bool Panel2Collapsed
    {
      get => this.Panel2.Collapsed;
      set
      {
        SplitterPanel panel1 = this.Panel1;
        SplitterPanel panel2 = this.Panel2;
        if (value == panel2.Collapsed)
          return;
        if (value && panel1.Collapsed)
          this.CollapsePanel(panel1, false);
        this.CollapsePanel(panel2, value);
        this.FireObservableItemPropertyChanged(nameof (Panel2Collapsed));
      }
    }

    /// <summary>
    /// Gets or sets the minimum distance in pixels of the splitter from the right or
    /// bottom edge of Panel2.
    /// </summary>
    /// <value>The minimum distance in pixels of the splitter from the right or
    /// bottom edge of Panel2.</value>
    [SRCategory("CatLayout")]
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(25)]
    [Localizable(true)]
    [SRDescription("SplitContainerPanel2MinSizeDescr")]
    public int Panel2MinSize
    {
      get => this.GetValue<int>(SplitContainer.Panel2MinSizeProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (Panel2MinSize), SR.GetString("InvalidLowBoundArgument", (object) nameof (Panel2MinSize), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "0"));
        if (this.Orientation == Orientation.Vertical)
        {
          if (this.DesignMode && this.Width != this.DefaultSize.Width && value + this.Panel1MinSize + this.SplitterWidth > this.Width)
            throw new ArgumentOutOfRangeException(nameof (Panel2MinSize), SR.GetString("InvalidArgument", (object) nameof (Panel2MinSize), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        }
        else if (this.Orientation == Orientation.Horizontal && this.DesignMode && this.Height != this.DefaultSize.Height && value + this.Panel1MinSize + this.SplitterWidth > this.Height)
          throw new ArgumentOutOfRangeException(nameof (Panel2MinSize), SR.GetString("InvalidArgument", (object) nameof (Panel2MinSize), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(SplitContainer.Panel2MinSizeProperty, value))
          return;
        if (value > this.Panel2.Width)
          this.SplitterDistance = this.Panel2.Width + this.SplitterWidthInternal;
        this.FireObservableItemPropertyChanged(nameof (Panel2MinSize));
      }
    }

    /// <summary>
    /// Gets or sets the location of the splitter, in pixels, from the left or top edge
    /// of the SplitContainer.
    /// </summary>
    /// <value>The splitter distance.</value>
    [DefaultValue(50)]
    [SRCategory("CatLayout")]
    [Localizable(true)]
    [SRDescription("SplitContainerSplitterDistanceDescr")]
    [SettingsBindable(true)]
    public int SplitterDistance
    {
      get => this.GetValue<int>(SplitContainer.SplitterDistanceProperty);
      set
      {
        if (value == this.SplitterDistance)
          return;
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (SplitterDistance), SR.GetString("InvalidLowBoundArgument", (object) nameof (SplitterDistance), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "0"));
        try
        {
          this.SetSplitterDistance = true;
          if (this.Orientation == Orientation.Vertical)
          {
            if (value < this.Panel1MinSize)
              value = this.Panel1MinSize;
            if (value + this.SplitterWidthInternal > this.Width - this.Panel2MinSize)
              value = this.Width - this.Panel2MinSize - this.SplitterWidthInternal;
            if (value < 0)
              throw new InvalidOperationException(SR.GetString("SplitterDistanceNotAllowed"));
            this.SetValue<int>(SplitContainer.SplitterDistanceProperty, value);
            this.SetValue<int>(SplitContainer.SplitterDistanceInternalProperty, value);
            this.Panel1.WidthInternal = value;
          }
          else
          {
            if (value < this.Panel1MinSize)
              value = this.Panel1MinSize;
            if (value + this.SplitterWidthInternal > this.Height - this.Panel2MinSize)
              value = this.Height - this.Panel2MinSize - this.SplitterWidthInternal;
            if (value < 0)
              throw new InvalidOperationException(SR.GetString("SplitterDistanceNotAllowed"));
            this.SetValue<int>(SplitContainer.SplitterDistanceProperty, value);
            this.SetValue<int>(SplitContainer.SplitterDistanceInternalProperty, value);
            this.Panel1.HeightInternal = value;
          }
          switch (this.FixedPanel)
          {
            case FixedPanel.Panel1:
              this.PanelSize = value;
              break;
            case FixedPanel.Panel2:
              this.PanelSize = this.Orientation != Orientation.Vertical ? this.Height - value - this.SplitterWidthInternal : this.Width - value - this.SplitterWidthInternal;
              break;
          }
          this.UpdateSplitter();
        }
        finally
        {
          this.SetSplitterDistance = false;
        }
        this.OnSplitterMovedInternal();
        this.FireObservableItemPropertyChanged(nameof (SplitterDistance));
      }
    }

    /// <summary>Raise the splitter moved event.</summary>
    internal void OnSplitterMovedInternal()
    {
      Rectangle splitterRectangle = this.SplitterRectangle;
      this.OnSplitterMoved(new SplitterEventArgs(splitterRectangle.X + splitterRectangle.Width / 2, splitterRectangle.Y + splitterRectangle.Height / 2, splitterRectangle.X, splitterRectangle.Y));
    }

    /// <summary>
    /// Gets or sets the location of the splitter, in pixels, from the left or top edge
    /// of the SplitContainer. For private use.
    /// </summary>
    /// <value>The splitter distance.</value>
    private int SplitterDistanceInternal
    {
      get => this.GetValue<int>(SplitContainer.SplitterDistanceInternalProperty);
      set => this.SetValue<int>(SplitContainer.SplitterDistanceInternalProperty, value);
    }

    /// <summary>
    /// Gets or sets a value representing the increment of splitter movement in pixels.
    /// Used for movement calculations mainly.
    /// </summary>
    /// <value>The splitter increment as int, Default is 1.</value>
    [DefaultValue(1)]
    [SRDescription("SplitContainerSplitterIncrementDescr")]
    [SRCategory("CatLayout")]
    [Localizable(true)]
    public int SplitterIncrement
    {
      get => this.GetValue<int>(SplitContainer.SplitterIncrementProperty);
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException(nameof (SplitterIncrement), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (SplitterIncrement), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "1"));
        if (!this.SetValue<int>(SplitContainer.SplitterIncrementProperty, value))
          return;
        this.FireObservableItemPropertyChanged(nameof (SplitterIncrement));
      }
    }

    /// <summary>
    /// Gets the size and location of the splitter relative to the SplitContainer.
    /// </summary>
    /// <value>The splitter rectangle.</value>
    [Browsable(false)]
    [SRDescription("SplitContainerSplitterRectangleDescr")]
    [SRCategory("CatLayout")]
    public Rectangle SplitterRectangle
    {
      get
      {
        Rectangle rectangleInternal = this.SplitterRectangleInternal;
        rectangleInternal.X -= this.Left;
        rectangleInternal.Y -= this.Top;
        return rectangleInternal;
      }
    }

    /// <summary>
    /// Gets or sets the size and location of the splitter relative to the SplitContainer
    /// for internal use. manipulated in the public property for outside use.
    /// Used as preliminary in calculations of drawing the splitter.
    /// The default value is .net Deafult of type Rectangle.
    /// </summary>
    /// <value>Rectangle, The default value is .net Deafult of type Rectangle.</value>
    [Browsable(false)]
    [SRDescription("SplitContainerSplitterRectangleDescr")]
    [SRCategory("CatLayout")]
    private Rectangle SplitterRectangleInternal
    {
      get => this.GetValue<Rectangle>(SplitContainer.SplitterRectangleInternalProperty);
      set => this.SetValue<Rectangle>(SplitContainer.SplitterRectangleInternalProperty, value);
    }

    /// <summary>
    /// Gets or sets the width of the splitter. Default value is 4.
    /// </summary>
    /// <value>The width of the splitter. Default value is 4.</value>
    [SRDescription("SplitContainerSplitterWidthDescr")]
    [Localizable(true)]
    [DefaultValue(4)]
    [SRCategory("CatLayout")]
    public int SplitterWidth
    {
      get => this.GetValue<int>(SplitContainer.SplitterWidthProperty);
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException(nameof (SplitterWidth), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (SplitterWidth), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) "1"));
        if (this.Orientation == Orientation.Vertical)
        {
          if (this.DesignMode && value + this.Panel1MinSize + this.Panel2MinSize > this.Width)
            throw new ArgumentOutOfRangeException(nameof (SplitterWidth), SR.GetString("InvalidArgument", (object) nameof (SplitterWidth), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        }
        else if (this.Orientation == Orientation.Horizontal && this.DesignMode && value + this.Panel1MinSize + this.Panel2MinSize > this.Height)
          throw new ArgumentOutOfRangeException(nameof (SplitterWidth), SR.GetString("InvalidArgument", (object) nameof (SplitterWidth), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(SplitContainer.SplitterWidthProperty, value))
          return;
        this.UpdateSplitter();
        this.FireObservableItemPropertyChanged(nameof (SplitterWidth));
      }
    }

    private int SplitterWidthInternal => !this.CollapsedMode ? this.SplitterWidth : 0;

    /// <summary>
    /// Gets or sets a value indicating whether tab stop is enabled.
    /// </summary>
    /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
    [SRDescription("ControlTabStopDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    [DispId(-516)]
    public new bool TabStop
    {
      get => this.GetValue<bool>(SplitContainer.TabStopProperty);
      set => this.SetValue<bool>(SplitContainer.TabStopProperty, value);
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Bindable(false)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>
    /// Raises the <see cref="E:SplitterMoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event data.</param>
    public virtual void OnSplitterMoved(SplitterEventArgs e)
    {
      SplitterEventHandler splitterMoved = this.SplitterMoved;
      if (splitterMoved == null)
        return;
      splitterMoved((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:SplitterMoving" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterCancelEventArgs" /> instance containing the event data.</param>
    public void OnSplitterMoving(SplitterCancelEventArgs e)
    {
      SplitterCancelEventHandler handler = (SplitterCancelEventHandler) this.GetHandler(SplitContainer.EVENT_MOVING);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>Creates the controls instance.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override Control.ControlCollection CreateControlsInstance() => (Control.ControlCollection) new SplitContainer.SplitContainerTypedControlCollection((Control) this, typeof (SplitterPanel), true);

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      if (!this.IsSplitterMovable || this.IsSplitterFixed)
        return;
      bool splitterFocused = this.SplitterFocused;
      if (e.KeyData == Keys.Escape && this.SplitterBegin)
      {
        this.SplitterBegin = false;
        this.SplitBreak = true;
      }
      else
      {
        if (e.KeyData != Keys.Right && e.KeyData != Keys.Down && e.KeyData != Keys.Left && !(e.KeyData == Keys.Up & splitterFocused))
          return;
        if (this.SplitterBegin)
          this.SplitterMove = true;
        int borderSize = this.BorderSize;
        if (e.KeyData == Keys.Left || e.KeyData == Keys.Up & splitterFocused)
        {
          int val1 = this.SplitterDistanceInternal - this.SplitterIncrement;
          this.SplitterDistanceInternal = val1 < this.Panel1MinSize ? val1 + this.SplitterIncrement : Math.Max(val1, borderSize);
        }
        if (e.KeyData == Keys.Right || e.KeyData == Keys.Down & splitterFocused)
        {
          int num = this.SplitterDistanceInternal + this.SplitterIncrement;
          this.SplitterDistanceInternal = this.Orientation != Orientation.Vertical ? (num + this.SplitterWidth > this.Height - this.Panel2MinSize - borderSize ? num - this.SplitterIncrement : num) : (num + this.SplitterWidth > this.Width - this.Panel2MinSize - borderSize ? num - this.SplitterIncrement : num);
        }
        if (!this.SplitterBegin)
          this.SplitterBegin = true;
        if (this.SplitterBegin && !this.SplitterMove)
        {
          this.InitialSplitterDistance = this.SplitterDistanceInternal;
          this.DrawSplitBar(1);
        }
        else
        {
          this.DrawSplitBar(2);
          Rectangle rectangle = this.CalcSplitLine(this.SplitterDistanceInternal, 0);
          int x = rectangle.X;
          int y = rectangle.Y;
          Rectangle splitterRectangle = this.SplitterRectangle;
          SplitterCancelEventArgs e1 = new SplitterCancelEventArgs(this.Left + splitterRectangle.X + splitterRectangle.Width / 2, this.Top + splitterRectangle.Y + splitterRectangle.Height / 2, x, y);
          this.OnSplitterMoving(e1);
          if (!e1.Cancel)
            return;
          this.SplitEnd(false);
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.
    /// Implemented by design as KeyPress (Use KeyPress instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
    [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
    protected override void OnKeyUp(KeyEventArgs e)
    {
      base.OnKeyUp(e);
      if (this.SplitterBegin && this.IsSplitterMovable && (e.KeyData == Keys.Right || e.KeyData == Keys.Down || e.KeyData == Keys.Left || e.KeyData == Keys.Up && this.SplitterFocused))
      {
        this.DrawSplitBar(3);
        this.ApplySplitterDistance();
        this.SplitterBegin = false;
        this.SplitterMove = false;
      }
      if (!this.SplitBreak)
        return;
      this.SplitBreak = false;
      this.SplitEnd(false);
    }

    /// <summary>
    /// Raises the <see cref="E:Layout" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    protected override void OnLayout(LayoutEventArgs e)
    {
      this.SetInnerMostBorder(this);
      if (!this.IsSplitterMovable || this.SetSplitterDistance)
        return;
      this.ResizeSplitContainer();
    }

    /// <summary>
    /// Raises the <see cref="E:LostFocus" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);
      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.
    /// Implemented by design as Click (Use Click instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (!this.IsSplitterMovable || !this.SplitterRectangle.Contains(new Point(e.X, e.Y)) || !this.Enabled || e.Button != MouseButtons.Left || e.Clicks != 1 || this.IsSplitterFixed)
        return;
      this.SplitterFocused = true;
      IContainerControl containerControlInternal = this.ParentInternal.GetContainerControlInternal();
      if (containerControlInternal != null)
      {
        if (!(containerControlInternal is ContainerControl containerControl))
          containerControlInternal.ActiveControl = (Control) this;
        else
          containerControl.SetActiveControlInternal((Control) this);
      }
      this.SetActiveControlInternal((Control) null);
      this.NextActiveControl = (Control) this.Panel2;
      this.SplitBegin(e.X, e.Y);
      this.SplitterClick = true;
    }

    /// <summary>
    /// Raises the <see cref="E:MouseLeave" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected void OnMouseLeave(EventArgs e)
    {
      if (!this.Enabled)
        return;
      this.OverrideCursor = (Cursor) null;
    }

    /// <summary>
    /// Raises the <see cref="E:MouseMove" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnMouseMove(MouseEventArgs e)
    {
      if (this.IsSplitterFixed || !this.IsSplitterMovable)
        return;
      this.OverrideCursor = !(this.Cursor == Cursors.Default) || !this.SplitterRectangle.Contains(new Point(e.X, e.Y)) ? (Cursor) null : (this.Orientation != Orientation.Vertical ? Cursors.HSplit : Cursors.VSplit);
      if (!this.SplitterClick)
        return;
      int x1 = e.X;
      int y1 = e.Y;
      this.SplitterDrag = true;
      this.SplitMove(x1, y1);
      int intMouseCursorX;
      int intMouseCursorY;
      if (this.Orientation == Orientation.Vertical)
      {
        intMouseCursorX = Math.Max(Math.Min(x1, this.Width - this.Panel2MinSize), this.Panel1MinSize);
        intMouseCursorY = Math.Max(y1, 0);
      }
      else
      {
        intMouseCursorY = Math.Max(Math.Min(y1, this.Height - this.Panel2MinSize), this.Panel1MinSize);
        intMouseCursorX = Math.Max(x1, 0);
      }
      Rectangle rectangle = this.CalcSplitLine(this.GetSplitterDistance(e.X, e.Y), 0);
      int x2 = rectangle.X;
      int y2 = rectangle.Y;
      SplitterCancelEventArgs e1 = new SplitterCancelEventArgs(intMouseCursorX, intMouseCursorY, x2, y2);
      this.OnSplitterMoving(e1);
      if (!e1.Cancel)
        return;
      this.SplitEnd(false);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
    /// Implemented by design as Click (Use Click instead).
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
    [Obsolete("Implemented by design as Click (Use Click instead).")]
    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (!this.Enabled || this.IsSplitterFixed || !this.IsSplitterMovable || !this.SplitterClick)
        return;
      if (this.SplitterDrag)
      {
        this.CalcSplitLine(this.GetSplitterDistance(e.X, e.Y), 0);
        this.SplitEnd(true);
      }
      else
        this.SplitEnd(false);
      this.SplitterClick = false;
      this.SplitterDrag = false;
    }

    /// <summary>
    /// Raises the <see cref="E:RightToLeftChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void OnRightToLeftChanged(EventArgs e)
    {
      this.Panel1.RightToLeft = this.RightToLeft;
      this.Panel2.RightToLeft = this.RightToLeft;
      this.UpdateSplitter();
    }

    /// <summary>Scales the control.</summary>
    /// <param name="objFactor">The factor.</param>
    /// <param name="enmSpecified">The specified.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected void ScaleControl(SizeF objFactor, BoundsSpecified enmSpecified)
    {
      try
      {
        this.SplitContainerScaling = true;
        this.SplitterWidth = (int) Math.Round((double) this.SplitterWidth * (this.Orientation != Orientation.Vertical ? (double) objFactor.Height : (double) objFactor.Width));
      }
      finally
      {
        this.SplitContainerScaling = false;
      }
    }

    /// <summary>Sets the bounds core.</summary>
    /// <param name="intX">The x.</param>
    /// <param name="intY">The y.</param>
    /// <param name="intWidth">The width.</param>
    /// <param name="intHeight">The height.</param>
    /// <param name="enmSpecified">The specified.</param>
    protected void SetBoundsCore(
      int intX,
      int intY,
      int intWidth,
      int intHeight,
      BoundsSpecified enmSpecified)
    {
      if ((enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None && this.Orientation == Orientation.Horizontal && intHeight < this.Panel1MinSize + this.SplitterWidthInternal + this.Panel2MinSize)
        intHeight = this.Panel1MinSize + this.SplitterWidthInternal + this.Panel2MinSize;
      if ((enmSpecified & BoundsSpecified.Width) != BoundsSpecified.None && this.Orientation == Orientation.Vertical && intWidth < this.Panel1MinSize + this.SplitterWidthInternal + this.Panel2MinSize)
        intWidth = this.Panel1MinSize + this.SplitterWidthInternal + this.Panel2MinSize;
      this.SetSplitterRect(this.Orientation == Orientation.Vertical);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.RenderControls(objContext, objWriter, lngRequestID);
    }

    /// <summary>
    /// SplitterDistance - The location of the splitter, in pixels, from the left or top edge
    /// of the SplitContainer. The public setter changes the value, this method changes the value
    /// without manipulation to it.
    /// </summary>
    private void SetSplitterDistanceDirectly(int value) => this.SplitterDistance = value;

    private void ApplySplitterDistance()
    {
      this.SplitterDistance = this.SplitterDistanceInternal;
      if (this.BackColor == Color.Transparent)
        this.Invalidate();
      Rectangle rectangleInternal = this.SplitterRectangleInternal;
      if (this.Orientation == Orientation.Vertical)
        rectangleInternal.X = this.RightToLeft != RightToLeft.No ? this.LayoutRight - this.SplitterDistanceInternal - this.SplitterWidthInternal : this.Location.X + this.SplitterDistanceInternal;
      else
        rectangleInternal.Y = this.Location.Y + this.SplitterDistanceInternal;
      this.SplitterRectangleInternal = rectangleInternal;
    }

    private Rectangle CalcSplitLine(int intSplitSize, int intMinWeight)
    {
      Rectangle rectangle = new Rectangle();
      switch (this.Orientation)
      {
        case Orientation.Horizontal:
          rectangle.Width = this.Width;
          rectangle.Height = this.SplitterWidthInternal;
          if (rectangle.Width < intMinWeight)
            rectangle.Width = intMinWeight;
          rectangle.Y = this.Panel1.Location.Y + intSplitSize;
          return rectangle;
        case Orientation.Vertical:
          rectangle.Width = this.SplitterWidthInternal;
          rectangle.Height = this.Height;
          if (rectangle.Width < intMinWeight)
            rectangle.Width = intMinWeight;
          if (this.RightToLeft == RightToLeft.No)
          {
            rectangle.X = this.Panel1.Location.X + intSplitSize;
            return rectangle;
          }
          rectangle.X = this.Width - intSplitSize - this.SplitterWidthInternal;
          return rectangle;
        default:
          return rectangle;
      }
    }

    private void CollapsePanel(SplitterPanel objSplitterPanel, bool blnCollapsing)
    {
      objSplitterPanel.Collapsed = blnCollapsing;
      objSplitterPanel.Visible = !blnCollapsing;
      this.ContainerSplitterPrivate.Visible = !blnCollapsing;
      this.UpdateSplitter();
    }

    private void DrawSplitBar(int intMode)
    {
      if (intMode != 1 && this.LastDrawSplit != -1)
      {
        this.DrawSplitHelper(this.LastDrawSplit);
        this.LastDrawSplit = -1;
      }
      else if (intMode != 1 && this.LastDrawSplit == -1)
        return;
      if (intMode != 3)
      {
        int distanceInternal = this.SplitterDistanceInternal;
        if (this.SplitterMove || this.SplitterBegin)
        {
          this.DrawSplitHelper(distanceInternal);
          this.LastDrawSplit = distanceInternal;
        }
        else
        {
          this.DrawSplitHelper(distanceInternal);
          this.LastDrawSplit = distanceInternal;
        }
      }
      else
      {
        if (this.LastDrawSplit != -1)
          this.DrawSplitHelper(this.LastDrawSplit);
        this.LastDrawSplit = -1;
      }
    }

    private void DrawSplitHelper(int intSplitSize)
    {
      this.CalcSplitLine(intSplitSize, 3);
      IntPtr handle = this.Handle;
    }

    private int GetSplitterDistance(int intX, int intY)
    {
      int num = this.Orientation != Orientation.Vertical ? intY - this.AnchorPoint.Y : intX - this.AnchorPoint.X;
      int val1 = 0;
      int borderSize = this.BorderSize;
      switch (this.Orientation)
      {
        case Orientation.Horizontal:
          val1 = Math.Max(this.Panel1.Height + num, borderSize);
          break;
        case Orientation.Vertical:
          val1 = this.RightToLeft == RightToLeft.No ? Math.Max(this.Panel1.Width + num, borderSize) : Math.Max(this.Panel1.Width - num, borderSize);
          break;
      }
      return this.Orientation == Orientation.Vertical ? Math.Max(Math.Min(val1, this.Width - this.Panel2MinSize), this.Panel1MinSize) : Math.Max(Math.Min(val1, this.Height - this.Panel2MinSize), this.Panel1MinSize);
    }

    private void RepaintSplitterRect()
    {
      int num = this.IsHandleCreated ? 1 : 0;
    }

    private void ResizeSplitContainer()
    {
      if (this.SplitContainerScaling)
        return;
      SplitterPanel panel1 = this.Panel1;
      SplitterPanel panel2 = this.Panel2;
      panel1.SuspendLayout();
      panel2.SuspendLayout();
      if (this.Width == 0)
      {
        panel1.Size = new Size(0, panel1.Height);
        panel2.Size = new Size(0, panel2.Height);
      }
      else if (this.Height == 0)
      {
        SplitterPanel splitterPanel1 = panel1;
        splitterPanel1.Size = new Size(splitterPanel1.Width, 0);
        SplitterPanel splitterPanel2 = panel2;
        splitterPanel2.Size = new Size(splitterPanel2.Width, 0);
      }
      else
      {
        if (this.Orientation == Orientation.Vertical)
        {
          if (!this.CollapsedMode)
          {
            if (this.FixedPanel == FixedPanel.Panel1)
            {
              int panelSize = this.PanelSize;
              panel1.Size = new Size(panelSize, this.Height);
              panel2.Size = new Size(Math.Max(this.Width - panelSize - this.SplitterWidthInternal, this.Panel2MinSize), this.Height);
            }
            if (this.FixedPanel == FixedPanel.Panel2)
            {
              int panelSize = this.PanelSize;
              panel2.Size = new Size(panelSize, this.Height);
              int num = Math.Max(this.Width - panelSize - this.SplitterWidthInternal, this.Panel1MinSize);
              this.SplitterDistanceInternal = num;
              panel1.WidthInternal = num;
              panel1.HeightInternal = this.Height;
            }
            if (this.FixedPanel == FixedPanel.None)
            {
              double ratioWidth = this.RatioWidth;
              if (ratioWidth != 0.0)
                this.SplitterDistanceInternal = Math.Max((int) Math.Floor((double) this.Width / ratioWidth), this.Panel1MinSize);
              int distanceInternal = this.SplitterDistanceInternal;
              panel1.WidthInternal = distanceInternal;
              panel1.HeightInternal = this.Height;
              panel2.Size = new Size(Math.Max(this.Width - distanceInternal - this.SplitterWidthInternal, this.Panel2MinSize), this.Height);
            }
            if (this.RightToLeft == RightToLeft.No)
              panel2.Location = new Point(panel1.WidthInternal + this.SplitterWidthInternal, 0);
            else
              panel1.Location = new Point(this.Width - panel1.WidthInternal, 0);
            this.RepaintSplitterRect();
            this.SetSplitterRect(true);
          }
          else if (this.Panel1Collapsed)
          {
            panel2.Size = this.Size;
            panel2.Location = new Point(0, 0);
          }
          else if (this.Panel2Collapsed)
          {
            panel1.Size = this.Size;
            panel1.Location = new Point(0, 0);
          }
        }
        else if (this.Orientation == Orientation.Horizontal)
        {
          if (!this.CollapsedMode)
          {
            if (this.FixedPanel == FixedPanel.Panel1)
            {
              int panelSize = this.PanelSize;
              panel1.Size = new Size(this.Width, panelSize);
              int y = panelSize + this.SplitterWidthInternal;
              panel2.Size = new Size(this.Width, Math.Max(this.Height - y, this.Panel2MinSize));
              panel2.Location = new Point(0, y);
            }
            if (this.FixedPanel == FixedPanel.Panel2)
            {
              panel2.Size = new Size(this.Width, this.PanelSize);
              int num = Math.Max(this.Height - this.Panel2.Height - this.SplitterWidthInternal, this.Panel1MinSize);
              this.SplitterDistanceInternal = num;
              panel1.HeightInternal = num;
              panel1.WidthInternal = this.Width;
              int y = num + this.SplitterWidthInternal;
              panel2.Location = new Point(0, y);
            }
            if (this.FixedPanel == FixedPanel.None)
            {
              double ratioHeight = this.RatioHeight;
              if (ratioHeight != 0.0)
                this.SplitterDistanceInternal = Math.Max((int) Math.Floor((double) this.Height / ratioHeight), this.Panel1MinSize);
              int distanceInternal = this.SplitterDistanceInternal;
              panel1.HeightInternal = distanceInternal;
              panel1.WidthInternal = this.Width;
              int y = distanceInternal + this.SplitterWidthInternal;
              panel2.Size = new Size(this.Width, Math.Max(this.Height - y, this.Panel2MinSize));
              panel2.Location = new Point(0, y);
            }
            this.RepaintSplitterRect();
            this.SetSplitterRect(false);
          }
          else if (this.Panel1Collapsed)
          {
            panel2.Size = this.Size;
            panel2.Location = new Point(0, 0);
          }
          else if (this.Panel2Collapsed)
          {
            panel1.Size = this.Size;
            panel1.Location = new Point(0, 0);
          }
        }
        try
        {
          this.ResizeCalled = true;
          this.ApplySplitterDistance();
        }
        finally
        {
          this.ResizeCalled = false;
        }
      }
      panel1.ResumeLayout();
      panel2.ResumeLayout();
    }

    private void SetInnerMostBorder(SplitContainer sc)
    {
      foreach (Control control1 in (ArrangedElementCollection) sc.Controls)
      {
        bool flag = false;
        if (control1 is SplitterPanel)
        {
          foreach (Control control2 in (ArrangedElementCollection) control1.Controls)
          {
            if (control2 is SplitContainer sc1 && sc1.Dock == DockStyle.Fill)
            {
              if (sc1.BorderStyle == this.BorderStyle)
              {
                ((SplitterPanel) control1).BorderStyle = BorderStyle.None;
                this.SetInnerMostBorder(sc1);
                flag = true;
              }
              else
                break;
            }
          }
          if (!flag)
            ((SplitterPanel) control1).BorderStyle = this.BorderStyle;
        }
      }
    }

    private void SetSplitterRect(bool blnVertical)
    {
      Rectangle rectangleInternal = this.SplitterRectangleInternal;
      if (blnVertical)
      {
        int distanceInternal = this.SplitterDistanceInternal;
        rectangleInternal.X = this.RightToLeft == RightToLeft.Yes ? this.Width - distanceInternal - this.SplitterWidthInternal : this.Location.X + distanceInternal;
        rectangleInternal.Y = this.Location.Y;
        rectangleInternal.Width = this.SplitterWidthInternal;
        rectangleInternal.Height = this.Height;
      }
      else
      {
        ref Rectangle local1 = ref rectangleInternal;
        Point location = this.Location;
        int x = location.X;
        local1.X = x;
        ref Rectangle local2 = ref rectangleInternal;
        location = this.Location;
        int num = location.Y + this.SplitterDistanceInternal;
        local2.Y = num;
        rectangleInternal.Width = this.Width;
        rectangleInternal.Height = this.SplitterWidthInternal;
      }
      this.SplitterRectangleInternal = rectangleInternal;
    }

    private void SplitBegin(int intX, int intY)
    {
      this.AnchorPoint = new Point(intX, intY);
      int splitterDistance = this.GetSplitterDistance(intX, intY);
      this.SplitterDistanceInternal = splitterDistance;
      this.InitialSplitterDistance = splitterDistance;
      this.InitialSplitterRectangle = this.SplitterRectangle;
      this.DrawSplitBar(1);
    }

    private void SplitEnd(bool blnAccept)
    {
      this.DrawSplitBar(3);
      int splitterDistance = this.InitialSplitterDistance;
      if (blnAccept)
        this.ApplySplitterDistance();
      else if (this.SplitterDistanceInternal != splitterDistance)
      {
        this.SplitterClick = false;
        this.SplitterDistance = splitterDistance;
      }
      this.AnchorPoint = Point.Empty;
    }

    private void SplitMove(int intX, int intY)
    {
      int splitterDistance = this.GetSplitterDistance(intX, intY);
      int num = (splitterDistance - this.InitialSplitterDistance) % this.SplitterIncrement;
      if (this.SplitterDistanceInternal != splitterDistance)
      {
        int borderSize = this.BorderSize;
        if (this.Orientation == Orientation.Vertical)
        {
          if (splitterDistance + this.SplitterWidthInternal <= this.Width - this.Panel2MinSize - borderSize)
            this.SplitterDistanceInternal = splitterDistance - num;
        }
        else if (splitterDistance + this.SplitterWidthInternal <= this.Height - this.Panel2MinSize - borderSize)
          this.SplitterDistanceInternal = splitterDistance - num;
      }
      this.DrawSplitBar(2);
    }

    private void UpdateSplitter()
    {
      if (this.SplitContainerScaling)
        return;
      SplitterPanel panel1 = this.Panel1;
      SplitterPanel panel2 = this.Panel2;
      if (this.Orientation == Orientation.Vertical)
      {
        bool flag = this.RightToLeft == RightToLeft.Yes;
        if (!this.CollapsedMode)
        {
          int distanceInternal = this.SplitterDistanceInternal;
          panel1.HeightInternal = this.Height;
          panel1.WidthInternal = distanceInternal;
          panel2.Size = new Size(this.Width - distanceInternal - this.SplitterWidthInternal, this.Height);
          if (!flag)
          {
            panel1.Location = new Point(0, 0);
            panel2.Location = new Point(distanceInternal + this.SplitterWidthInternal, 0);
          }
          else
          {
            panel1.Location = new Point(this.Width - distanceInternal, 0);
            panel2.Location = new Point(0, 0);
          }
          this.RepaintSplitterRect();
          this.SetSplitterRect(true);
          if (!this.ResizeCalled)
            this.RatioWidth = (double) this.Width / (double) panel1.Width > 0.0 ? (double) this.Width / (double) panel1.Width : this.RatioWidth;
        }
        else
        {
          if (this.Panel1Collapsed)
          {
            panel2.Size = this.Size;
            panel2.Location = new Point(0, 0);
          }
          else if (this.Panel2Collapsed)
          {
            panel1.Size = this.Size;
            panel1.Location = new Point(0, 0);
          }
          if (!this.ResizeCalled)
          {
            int distanceInternal = this.SplitterDistanceInternal;
            this.RatioWidth = (double) this.Width / (double) distanceInternal > 0.0 ? (double) this.Width / (double) distanceInternal : this.RatioWidth;
          }
        }
      }
      else if (!this.CollapsedMode)
      {
        panel1.Location = new Point(0, 0);
        panel1.WidthInternal = this.Width;
        int distanceInternal = this.SplitterDistanceInternal;
        panel1.HeightInternal = distanceInternal;
        int y = distanceInternal + this.SplitterWidthInternal;
        panel2.Size = new Size(this.Width, this.Height - y);
        panel2.Location = new Point(0, y);
        this.RepaintSplitterRect();
        this.SetSplitterRect(false);
        if (!this.ResizeCalled)
          this.RatioHeight = (double) this.Height / (double) panel1.Height > 0.0 ? (double) this.Height / (double) panel1.Height : this.RatioHeight;
      }
      else
      {
        if (this.Panel1Collapsed)
        {
          panel2.Size = this.Size;
          panel2.Location = new Point(0, 0);
        }
        else if (this.Panel2Collapsed)
        {
          panel1.Size = this.Size;
          panel1.Location = new Point(0, 0);
        }
        if (!this.ResizeCalled)
        {
          int distanceInternal = this.SplitterDistanceInternal;
          this.RatioHeight = (double) this.Height / (double) distanceInternal > 0.0 ? (double) this.Height / (double) distanceInternal : this.RatioHeight;
        }
      }
      if (this.ContainerSplitterPrivate == null)
        this.ContainerSplitterPrivate = new SplitContainer.ContainerSplitter(this);
      if (this.Orientation == Orientation.Vertical)
        this.ContainerSplitterPrivate.Width = this.SplitterWidth;
      else
        this.ContainerSplitterPrivate.Height = this.SplitterWidth;
    }

    internal new void AfterControlRemoved(Control objControl, Control objOldParent)
    {
      if (!(objControl is SplitContainer) || objControl.Dock != DockStyle.Fill)
        return;
      this.SetInnerMostBorder(this);
    }

    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Serializable]
    private class ContainerSplitter : Splitter
    {
      private SplitContainer mobjSplitContainer;

      /// <summary>Gets the critical events.</summary>
      /// <returns></returns>
      protected override CriticalEventsData GetCriticalEventsData()
      {
        CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
        if (this.mobjSplitContainer != null)
        {
          if (this.mobjSplitContainer.IsSplitterMovedRegistered)
            criticalEventsData.Set("PC");
          if (this.mobjSplitContainer.IsCriticalEvent(Control.MouseClickEvent) || this.mobjSplitContainer.IsCriticalEvent(Control.MouseDownEvent) || this.mobjSplitContainer.IsCriticalEvent(Control.MouseUpEvent))
            criticalEventsData.Set("CL");
          if (this.mobjSplitContainer.IsCriticalEvent(Control.DoubleClickEvent))
            criticalEventsData.Set("DCL");
        }
        return criticalEventsData;
      }

      /// <summary>Fires an event.</summary>
      /// <param name="objEvent">event.</param>
      protected override void FireEvent(IEvent objEvent)
      {
        base.FireEvent(objEvent);
        if (this.mobjSplitContainer == null)
          return;
        switch (objEvent.Type)
        {
          case "SplitterMoved":
            SplitterPanel splitterPanel = this.mobjSplitContainer.FixedPanel == FixedPanel.Panel1 ? this.mobjSplitContainer.Panel1 : this.mobjSplitContainer.Panel2;
            if (splitterPanel == null)
              break;
            if (splitterPanel == this.mobjSplitContainer.Panel1)
            {
              if (this.mobjSplitContainer.Orientation == Orientation.Vertical)
              {
                this.mobjSplitContainer.SetSplitterDistanceDirectly(splitterPanel.Width);
                break;
              }
              this.mobjSplitContainer.SetSplitterDistanceDirectly(splitterPanel.Height);
              break;
            }
            if (this.mobjSplitContainer.Orientation == Orientation.Vertical)
            {
              this.mobjSplitContainer.SetSplitterDistanceDirectly(this.mobjSplitContainer.Width - (splitterPanel.Width + this.mobjSplitContainer.SplitterWidth));
              break;
            }
            this.mobjSplitContainer.SetSplitterDistanceDirectly(this.mobjSplitContainer.Height - (splitterPanel.Height + this.mobjSplitContainer.SplitterWidth));
            break;
          case "Click":
          case "DoubleClick":
            this.mobjSplitContainer.FireEvent(objEvent);
            break;
        }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitContainer.ContainerSplitter" /> class.
      /// </summary>
      internal ContainerSplitter() => this.Size = new Size(3, 3);

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SplitContainer.ContainerSplitter" /> class.
      /// </summary>
      /// <param name="objSplitContainer">The SplitContainer.</param>
      internal ContainerSplitter(SplitContainer objSplitContainer)
        : this()
      {
        this.mobjSplitContainer = objSplitContainer;
      }

      /// <summary>Gets the dock style.</summary>
      /// <returns></returns>
      internal override DockStyle GetDockInternal()
      {
        if (!(this.Parent is SplitContainer parent))
          return base.GetDockInternal();
        return parent.Orientation == Orientation.Vertical ? (parent.FixedPanel == FixedPanel.Panel2 ? DockStyle.Right : DockStyle.Left) : (parent.FixedPanel == FixedPanel.Panel2 ? DockStyle.Bottom : DockStyle.Top);
      }

      /// <summary>Gets the anchor style.</summary>
      /// <returns></returns>
      internal override AnchorStyles GetAnchorInternal() => AnchorStyles.None;
    }

    [Serializable]
    internal class SplitContainerTypedControlCollection : ClientUtils.TypedControlCollection
    {
      private SplitContainer mobjOwner;

      public SplitContainerTypedControlCollection(
        Control objControl,
        Type objType,
        bool blnIsReadOnly)
        : base(objControl, objType, blnIsReadOnly)
      {
        this.mobjOwner = objControl as SplitContainer;
      }

      public override void Remove(Control objValue)
      {
        if (objValue is SplitterPanel && !this.mobjOwner.DesignMode && this.IsReadOnly)
          throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
        base.Remove(objValue);
      }

      internal override void SetChildIndexInternal(Control objChild, int intNewIndex)
      {
        if (objChild is SplitterPanel)
        {
          if (this.mobjOwner.DesignMode)
            return;
          if (this.IsReadOnly)
            throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
        }
        base.SetChildIndexInternal(objChild, intNewIndex);
      }
    }
  }
}
