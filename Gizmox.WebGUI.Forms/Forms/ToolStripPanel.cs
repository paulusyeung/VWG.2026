// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Creates a container within which other controls can share horizontal or vertical space.</summary>
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [Gizmox.WebGUI.Forms.MetadataTag("TSPN")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ToolStripPanelSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ToolStripPanel : ContainerControl, IArrangedElement, IComponent, IDisposable
  {
    private static readonly SerializableProperty mobjToolStripPanelRowCollectionProperty = SerializableProperty.Register(nameof (mobjToolStripPanelRowCollection), typeof (ToolStripPanel.ToolStripPanelRowCollection), typeof (ToolStripPanel));
    private static readonly SerializableProperty mobjRowMarginProperty = SerializableProperty.Register(nameof (mobjRowMargin), typeof (Padding), typeof (ToolStripPanel));
    private static readonly SerializableProperty menmOrientationProperty = SerializableProperty.Register(nameof (menmOrientation), typeof (Orientation), typeof (ToolStripPanel));
    private static readonly SerializableProperty mblnLockedProperty = SerializableProperty.Register(nameof (mblnLocked), typeof (bool), typeof (ToolStripPanel));
    private static readonly SerializableProperty mobjOwnerToolStripContainerProperty = SerializableProperty.Register(nameof (mobjOwnerToolStripContainer), typeof (ToolStripContainer), typeof (ToolStripPanel));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> class. </summary>
    public ToolStripPanel()
    {
      this.mobjRowMargin = new Padding(3, 0, 0, 0);
      this.SuspendLayout();
      this.AutoSize = true;
      this.MinimumSize = Size.Empty;
      this.mblnLocked = false;
      this.TabStop = false;
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.Selectable, false);
      this.ResumeLayout(true);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel" /> class.
    /// </summary>
    /// <param name="objOwnerToolStripContainer">The owner tool strip container.</param>
    internal ToolStripPanel(ToolStripContainer objOwnerToolStripContainer)
      : this()
    {
      this.mobjOwnerToolStripContainer = objOwnerToolStripContainer;
    }

    /// <summary>Begins the initialization of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void BeginInit()
    {
    }

    /// <summary>Ends the initialization of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void EndInit()
    {
    }

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
    public void Join(ToolStrip toolStripToDrag) => this.Join(toolStripToDrag, Point.Empty);

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> in the specified row.</summary>
    /// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
    /// <param name="row">An <see cref="T:System.Int32"></see> representing the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> to which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is added.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row parameter is less than zero (0).</exception>
    public void Join(ToolStrip toolStripToDrag, int row)
    {
      if (row < 0)
        throw new ArgumentOutOfRangeException(nameof (row), SR.GetString("IndexOutOfRange", (object) row.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      this.Join(toolStripToDrag, Point.Empty);
    }

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> at the specified coordinates.</summary>
    /// <param name="y">The vertical client coordinate, in pixels.</param>
    /// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
    /// <param name="x">The horizontal client coordinate, in pixels.</param>
    public void Join(ToolStrip toolStripToDrag, int x, int y) => this.Join(toolStripToDrag, new Point(x, y));

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> at the specified location.</summary>
    /// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
    /// <param name="location">A <see cref="T:System.Drawing.Point"></see> value representing the x- and y-client coordinates, in pixels, of the new location for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
    public void Join(ToolStrip toolStripToDrag, Point location)
    {
      if (toolStripToDrag == null)
        throw new ArgumentNullException(nameof (toolStripToDrag));
      toolStripToDrag.ParentInternal = (Control) this;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripPanel.RendererChanged"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRendererChanged(EventArgs e)
    {
    }

    /// <summary>Retrieves the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> given a point within the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> client area.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> that contains the raftingContainerPoint, or null if no such <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> exists.</returns>
    /// <param name="clientLocation">A <see cref="T:System.Drawing.Point"></see> used as a reference to find the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</param>
    public ToolStripPanelRow PointToRow(Point clientLocation)
    {
      foreach (ToolStripPanelRow row in (ArrangedElementCollection) this.RowsInternal)
      {
        Rectangle rectangle = LayoutUtils.InflateRect(row.Bounds, row.Margin);
        Rectangle displayRectangle;
        if (this.ParentInternal != null)
        {
          if (this.Orientation == Orientation.Horizontal && rectangle.Width == 0)
          {
            ref Rectangle local = ref rectangle;
            displayRectangle = this.ParentInternal.DisplayRectangle;
            int width = displayRectangle.Width;
            local.Width = width;
          }
          else if (this.Orientation == Orientation.Vertical && rectangle.Height == 0)
          {
            ref Rectangle local = ref rectangle;
            displayRectangle = this.ParentInternal.DisplayRectangle;
            int height = displayRectangle.Height;
            local.Height = height;
          }
        }
        if (rectangle.Contains(clientLocation))
          return row;
      }
      return (ToolStripPanelRow) null;
    }

    /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripPanel.AutoSize"></see> property changes. </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new event EventHandler AutoSizeChanged
    {
      add => base.AutoSizeChanged += value;
      remove => base.AutoSizeChanged -= value;
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanel.Renderer"></see> property changes.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler RendererChanged
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler TabIndexChanged
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler TabStopChanged
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler TextChanged
    {
      add => base.TextChanged += value;
      remove => base.TextChanged -= value;
    }

    private ToolStripPanel.ToolStripPanelRowCollection mobjToolStripPanelRowCollection
    {
      get => this.GetValue<ToolStripPanel.ToolStripPanelRowCollection>(ToolStripPanel.mobjToolStripPanelRowCollectionProperty, (ToolStripPanel.ToolStripPanelRowCollection) null);
      set => this.SetValue<ToolStripPanel.ToolStripPanelRowCollection>(ToolStripPanel.mobjToolStripPanelRowCollectionProperty, value);
    }

    private Padding mobjRowMargin
    {
      get => this.GetValue<Padding>(ToolStripPanel.mobjRowMarginProperty);
      set => this.SetValue<Padding>(ToolStripPanel.mobjRowMarginProperty, value);
    }

    private Orientation menmOrientation
    {
      get => this.GetValue<Orientation>(ToolStripPanel.menmOrientationProperty);
      set => this.SetValue<Orientation>(ToolStripPanel.menmOrientationProperty, value);
    }

    private bool mblnLocked
    {
      get => this.GetValue<bool>(ToolStripPanel.mblnLockedProperty);
      set => this.SetValue<bool>(ToolStripPanel.mblnLockedProperty, value);
    }

    private ToolStripContainer mobjOwnerToolStripContainer
    {
      get => this.GetValue<ToolStripContainer>(ToolStripPanel.mobjOwnerToolStripContainerProperty, (ToolStripContainer) null);
      set => this.SetValue<ToolStripContainer>(ToolStripPanel.mobjOwnerToolStripContainerProperty, value);
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override bool AllowDrop
    {
      get => base.AllowDrop;
      set => base.AllowDrop = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override bool AutoScroll
    {
      get => base.AutoScroll;
      set => base.AutoScroll = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size AutoScrollMargin
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size AutoScrollMinSize
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> automatically adjusts its size when the form is resized.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> automatically resizes; otherwise, false. The default is true.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(true)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>Gets/Sets the controls docking style</summary>
    /// <value></value>
    public override DockStyle Dock
    {
      get => base.Dock;
      set
      {
        base.Dock = value;
        if (value == DockStyle.Left || value == DockStyle.Right)
          this.Orientation = Orientation.Vertical;
        else
          this.Orientation = Orientation.Horizontal;
      }
    }

    /// <summary>Gets the layout engine.</summary>
    /// <value>The layout engine.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual LayoutEngine LayoutEngine => (LayoutEngine) null;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> can be moved or resized.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> can be moved or resized; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool Locked
    {
      get => this.mblnLocked;
      set
      {
        if (this.mblnLocked == value)
          return;
        this.mblnLocked = value;
      }
    }

    /// <summary>Gets or sets a value indicating the horizontal or vertical orientation of the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.Orientation"></see> values.</returns>
    public Orientation Orientation
    {
      get => this.menmOrientation;
      set
      {
        if (this.menmOrientation == value)
          return;
        this.menmOrientation = value;
        this.mobjRowMargin = LayoutUtils.FlipPadding(this.mobjRowMargin);
      }
    }

    /// <summary>Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the appearance of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> that handles painting.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripRenderer Renderer
    {
      get => (ToolStripRenderer) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the painting styles to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripRenderMode RenderMode
    {
      get => ToolStripRenderMode.Custom;
      set
      {
      }
    }

    /// <summary>Gets or sets the spacing, in pixels, between the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s and the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> value representing the spacing, in pixels.</returns>
    public Padding RowMargin
    {
      get => this.mobjRowMargin;
      set => this.mobjRowMargin = value;
    }

    /// <summary>Gets the rows internal.</summary>
    /// <value>The rows internal.</value>
    [Browsable(false)]
    [SRDescription("ToolStripPanelRowsDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    internal ToolStripPanel.ToolStripPanelRowCollection RowsInternal
    {
      get
      {
        if (this.mobjToolStripPanelRowCollection == null)
          this.mobjToolStripPanelRowCollection = new ToolStripPanel.ToolStripPanelRowCollection(this);
        return this.mobjToolStripPanelRowCollection;
      }
    }

    /// <summary>Gets the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s in this <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> representing the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s in this <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ToolStripPanelRowsDescr")]
    [Browsable(false)]
    public ToolStripPanelRow[] Rows
    {
      get
      {
        ToolStripPanelRow[] array = new ToolStripPanelRow[this.RowsInternal.Count];
        this.RowsInternal.CopyTo(array, 0);
        return array;
      }
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the tab index.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.String"></see> representing the display text.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets the children.</summary>
    /// <value>The children.</value>
    ArrangedElementCollection IArrangedElement.Children => (ArrangedElementCollection) this.RowsInternal;

    /// <summary>Represents all the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects in a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
    [ComVisible(false)]
    [ListBindable(false)]
    [Serializable]
    public class ToolStripPanelRowCollection : 
      ArrangedElementCollection,
      IList,
      ICollection,
      IEnumerable
    {
      private ToolStripPanel mobjOwner;

      /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> class with the specified number of rows in the specified <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
      /// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that holds this <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
      /// <param name="value">The number of rows in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
      public ToolStripPanelRowCollection(ToolStripPanel owner, ToolStripPanelRow[] value)
      {
        this.mobjOwner = owner;
        this.AddRange(value);
      }

      /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> class in the specified <see cref="T:System.Windows.Forms.ToolStripPanel"></see>. </summary>
      /// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that holds this <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
      public ToolStripPanelRowCollection(ToolStripPanel owner) => this.mobjOwner = owner;

      bool IList.IsFixedSize => this.InnerList.IsFixedSize;

      bool IList.IsReadOnly => this.InnerList.IsReadOnly;

      object IList.this[int index]
      {
        get => this.InnerList[index];
        set => throw new NotSupportedException(SR.GetString("ToolStripCollectionMustInsertAndRemove"));
      }

      /// <summary>Gets a particular <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> within the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <returns>The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> as specified by the index parameter.</returns>
      /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> within the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
      public virtual ToolStripPanelRow this[int index] => (ToolStripPanelRow) this.InnerList[index];

      /// <summary>Adds the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <returns>The position of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</returns>
      /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to add to the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public int Add(ToolStripPanelRow value)
      {
        int index = value != null ? this.InnerList.Add((object) value) : throw new ArgumentNullException(nameof (value));
        this.OnAdd(value, index);
        return index;
      }

      /// <summary>Adds an array of <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects to a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
      /// <param name="value">An array of <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects.</param>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public void AddRange(ToolStripPanelRow[] value)
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        ToolStripPanel mobjOwner = this.mobjOwner;
        mobjOwner?.SuspendLayout();
        try
        {
          for (int index = 0; index < value.Length; ++index)
            this.Add(value[index]);
        }
        finally
        {
          mobjOwner?.ResumeLayout();
        }
      }

      /// <summary>Adds the specified <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
      /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to add to the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</param>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public void AddRange(ToolStripPanel.ToolStripPanelRowCollection value)
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        ToolStripPanel mobjOwner = this.mobjOwner;
        mobjOwner?.SuspendLayout();
        try
        {
          int count = value.Count;
          for (int index = 0; index < count; ++index)
            this.Add(value[index]);
        }
        finally
        {
          mobjOwner?.ResumeLayout();
        }
      }

      /// <summary>Removes all <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      public virtual void Clear()
      {
        if (this.mobjOwner != null)
          this.mobjOwner.SuspendLayout();
        try
        {
          while (this.Count != 0)
            this.RemoveAt(this.Count - 1);
        }
        finally
        {
          if (this.mobjOwner != null)
            this.mobjOwner.ResumeLayout();
        }
      }

      /// <summary>Determines whether the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> is in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <returns>true if the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> is in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>; otherwise, false.</returns>
      /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to search for in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
      public bool Contains(ToolStripPanelRow value) => this.InnerList.Contains((object) value);

      /// <summary>Copies the entire <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> into an existing array at a specified location within the array.</summary>
      /// <param name="array">An <see cref="T:System.Array"></see> representing the array to copy the contents of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to.</param>
      /// <param name="index">The location within the destination array to copy the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to.</param>
      public void CopyTo(ToolStripPanelRow[] array, int index) => this.InnerList.CopyTo((Array) array, index);

      /// <summary>Gets the index of the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <returns>The index of the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>.</returns>
      /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to return the index of.</param>
      public int IndexOf(ToolStripPanelRow value) => this.InnerList.IndexOf((object) value);

      /// <summary>Inserts the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> at the specified location in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to insert.</param>
      /// <param name="index">The zero-based index at which to insert the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>.</param>
      /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
      public void Insert(int index, ToolStripPanelRow value)
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        this.InnerList.Insert(index, (object) value);
        this.OnAdd(value, index);
      }

      /// <summary>Removes the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to remove.</param>
      public void Remove(ToolStripPanelRow value)
      {
        this.InnerList.Remove((object) value);
        this.OnAfterRemove(value);
      }

      /// <summary>Removes the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> at the specified index from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
      /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to remove.</param>
      public void RemoveAt(int index)
      {
        ToolStripPanelRow row = (ToolStripPanelRow) null;
        if (index < this.Count && index >= 0)
          row = (ToolStripPanelRow) this.InnerList[index];
        this.InnerList.RemoveAt(index);
        this.OnAfterRemove(row);
      }

      int IList.Add(object value) => this.Add(value as ToolStripPanelRow);

      void IList.Clear() => this.Clear();

      bool IList.Contains(object value) => this.InnerList.Contains(value);

      int IList.IndexOf(object value) => this.IndexOf(value as ToolStripPanelRow);

      void IList.Insert(int index, object value) => this.Insert(index, value as ToolStripPanelRow);

      void IList.Remove(object value) => this.Remove(value as ToolStripPanelRow);

      void IList.RemoveAt(int index) => this.RemoveAt(index);

      private void OnAdd(ToolStripPanelRow value, int index)
      {
        if (this.mobjOwner == null)
          return;
        this.mobjOwner.Update();
      }

      private void OnAfterRemove(ToolStripPanelRow row)
      {
      }
    }
  }
}
