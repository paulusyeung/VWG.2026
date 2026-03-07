// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripPanelRow
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a row of a <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that can contain controls.</summary>
  [ToolboxItem(false)]
  [Serializable]
  public class ToolStripPanelRow : Component, IComponent, IDisposable
  {
    private static readonly SerializableProperty mobjBoundsProperty = SerializableProperty.Register(nameof (mobjBounds), typeof (Rectangle), typeof (ToolStripPanelRow));
    private static readonly SerializableProperty mobjParentProperty = SerializableProperty.Register(nameof (mobjParent), typeof (ToolStripPanel), typeof (ToolStripPanelRow));
    private static readonly SerializableProperty mobjControlsProperty = SerializableProperty.Register(nameof (mobjControls), typeof (List<Control>), typeof (ToolStripPanelRow));
    private static readonly SerializableProperty mobjPaddingProperty = SerializableProperty.Register(nameof (mobjPadding), typeof (Padding), typeof (ToolStripPanelRow));
    private static readonly SerializableProperty mobjMarginProperty = SerializableProperty.Register(nameof (mobjMargin), typeof (Padding), typeof (ToolStripPanelRow));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> class, specifying the containing <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>. </summary>
    /// <param name="parent">The containing <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
    public ToolStripPanelRow(ToolStripPanel parent)
      : this(parent, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow" /> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <param name="visible">if set to <c>true</c> [visible].</param>
    internal ToolStripPanelRow(ToolStripPanel parent, bool visible)
    {
      this.mobjBounds = Rectangle.Empty;
      this.mobjParent = parent;
      this.Margin = this.DefaultMargin;
    }

    /// <summary>Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> can be dragged and dropped into a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary>
    /// <returns>true if there is enough space in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> to receive the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>; otherwise, false. </returns>
    /// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be dragged and dropped into the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool CanMove(ToolStrip toolStripToDrag) => false;

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property changes.</summary>
    /// <param name="newBounds">The new value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property.</param>
    /// <param name="oldBounds">The original value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanelRow.Bounds"></see> property.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected void OnBoundsChanged(Rectangle oldBounds, Rectangle newBounds)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Layout"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnLayout(LayoutEventArgs e)
    {
    }

    private Rectangle mobjBounds
    {
      get => this.GetValue<Rectangle>(ToolStripPanelRow.mobjBoundsProperty);
      set => this.SetValue<Rectangle>(ToolStripPanelRow.mobjBoundsProperty, value);
    }

    private ToolStripPanel mobjParent
    {
      get => this.GetValue<ToolStripPanel>(ToolStripPanelRow.mobjParentProperty);
      set => this.SetValue<ToolStripPanel>(ToolStripPanelRow.mobjParentProperty, value);
    }

    private List<Control> mobjControls
    {
      get => this.GetValue<List<Control>>(ToolStripPanelRow.mobjControlsProperty, (List<Control>) null);
      set => this.SetValue<List<Control>>(ToolStripPanelRow.mobjControlsProperty, value);
    }

    private Padding mobjPadding
    {
      get => this.GetValue<Padding>(ToolStripPanelRow.mobjPaddingProperty);
      set => this.SetValue<Padding>(ToolStripPanelRow.mobjPaddingProperty, value);
    }

    private Padding mobjMargin
    {
      get => this.GetValue<Padding>(ToolStripPanelRow.mobjMarginProperty);
      set => this.SetValue<Padding>(ToolStripPanelRow.mobjMarginProperty, value);
    }

    /// <summary>Gets the size and location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>, including its nonclient elements, in pixels, relative to the parent control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the size and location.</returns>
    public Rectangle Bounds => this.mobjBounds;

    /// <summary>Gets the controls internal.</summary>
    /// <value>The controls internal.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("ControlControlsDescr")]
    internal List<Control> ControlsInternal
    {
      get
      {
        if (this.mobjControls == null)
          this.mobjControls = new List<Control>();
        return this.mobjControls;
      }
    }

    /// <summary>Gets the controls in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary>
    /// <returns>An array of controls.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ControlControlsDescr")]
    [Browsable(false)]
    public Control[] Controls => this.ControlsInternal.ToArray();

    /// <summary>Gets the space, in pixels, that is specified by default between controls.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> that represents the default space between controls.</returns>
    protected virtual Padding DefaultMargin
    {
      get
      {
        Padding rowMargin = this.ToolStripPanel.RowMargin;
        if (this.Orientation == Orientation.Horizontal)
        {
          rowMargin.Left = 0;
          rowMargin.Right = 0;
          return rowMargin;
        }
        rowMargin.Top = 0;
        rowMargin.Bottom = 0;
        return rowMargin;
      }
    }

    /// <summary>Gets the internal spacing, in pixels, of the contents of a control.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> that represents the internal spacing of the contents of a control.</returns>
    protected virtual Padding DefaultPadding => Padding.Empty;

    /// <summary>Gets the display area of the control.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> representing the size and location.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle DisplayRectangle => Rectangle.Empty;

    /// <summary>Gets an instance of the control's layout engine.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Layout.LayoutEngine"></see> for the control's contents.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public LayoutEngine LayoutEngine => (LayoutEngine) null;

    /// <summary>Gets or sets the space between controls.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between controls.</returns>
    public Padding Margin
    {
      get => this.mobjMargin;
      set
      {
        if (!(this.Margin != value))
          return;
        this.mobjMargin = value;
      }
    }

    /// <summary>Gets the layout direction of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> relative to its containing <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.Orientation"></see> values.</returns>
    public Orientation Orientation => this.ToolStripPanel.Orientation;

    /// <summary>Gets or sets padding within the control.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Padding"></see> representing the control's internal spacing characteristics.</returns>
    public virtual Padding Padding
    {
      get => this.mobjPadding;
      set
      {
        if (!(this.Padding != value))
          return;
        this.mobjPadding = value;
      }
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</returns>
    public ToolStripPanel ToolStripPanel => this.mobjParent;
  }
}
