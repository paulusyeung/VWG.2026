// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripContainer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides panels on each side of the form and a central panel that can hold one or more controls.</summary>
  [ComVisible(true)]
  [SRDescription("ToolStripContainerDesc")]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [Gizmox.WebGUI.Forms.MetadataTag("TSC")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ToolStripContainerSkin))]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ToolStripContainer), "ToolStripContainer_45.bmp")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContainerController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ToolStripContainer : ContainerControl
  {
    private static readonly SerializableProperty mobjBottomPanelProperty = SerializableProperty.Register(nameof (mobjBottomPanel), typeof (ToolStripPanel), typeof (ToolStripContainer));
    private static readonly SerializableProperty mobjContentPanelProperty = SerializableProperty.Register(nameof (mobjContentPanel), typeof (ToolStripContentPanel), typeof (ToolStripContainer));
    private static readonly SerializableProperty mobjLeftPanelProperty = SerializableProperty.Register(nameof (mobjLeftPanel), typeof (ToolStripPanel), typeof (ToolStripContainer));
    private static readonly SerializableProperty mobjRightPanelProperty = SerializableProperty.Register(nameof (mobjRightPanel), typeof (ToolStripPanel), typeof (ToolStripContainer));
    private static readonly SerializableProperty mobjTopPanelProperty = SerializableProperty.Register(nameof (mobjTopPanel), typeof (ToolStripPanel), typeof (ToolStripContainer));

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> class. </summary>
    public ToolStripContainer()
    {
      this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
      this.SuspendLayout();
      try
      {
        this.mobjTopPanel = new ToolStripPanel(this);
        this.mobjBottomPanel = new ToolStripPanel(this);
        this.mobjLeftPanel = new ToolStripPanel(this);
        this.mobjRightPanel = new ToolStripPanel(this);
        this.mobjContentPanel = new ToolStripContentPanel();
        this.mobjContentPanel.Dock = DockStyle.Fill;
        this.mobjTopPanel.Dock = DockStyle.Top;
        this.mobjBottomPanel.Dock = DockStyle.Bottom;
        this.mobjRightPanel.Dock = DockStyle.Right;
        this.mobjLeftPanel.Dock = DockStyle.Left;
        if (!(this.Controls is ToolStripContainer.ToolStripContainerTypedControlCollection controls))
          return;
        controls.AddInternal((Control) this.mobjContentPanel);
        controls.AddInternal((Control) this.mobjLeftPanel);
        controls.AddInternal((Control) this.mobjRightPanel);
        controls.AddInternal((Control) this.mobjTopPanel);
        controls.AddInternal((Control) this.mobjBottomPanel);
      }
      finally
      {
        this.ResumeLayout(true);
      }
    }

    private ToolStripPanel mobjBottomPanel
    {
      get => this.GetValue<ToolStripPanel>(ToolStripContainer.mobjBottomPanelProperty);
      set => this.SetValue<ToolStripPanel>(ToolStripContainer.mobjBottomPanelProperty, value);
    }

    private ToolStripContentPanel mobjContentPanel
    {
      get => this.GetValue<ToolStripContentPanel>(ToolStripContainer.mobjContentPanelProperty);
      set => this.SetValue<ToolStripContentPanel>(ToolStripContainer.mobjContentPanelProperty, value);
    }

    private ToolStripPanel mobjLeftPanel
    {
      get => this.GetValue<ToolStripPanel>(ToolStripContainer.mobjLeftPanelProperty);
      set => this.SetValue<ToolStripPanel>(ToolStripContainer.mobjLeftPanelProperty, value);
    }

    private ToolStripPanel mobjRightPanel
    {
      get => this.GetValue<ToolStripPanel>(ToolStripContainer.mobjRightPanelProperty);
      set => this.SetValue<ToolStripPanel>(ToolStripContainer.mobjRightPanelProperty, value);
    }

    private ToolStripPanel mobjTopPanel
    {
      get => this.GetValue<ToolStripPanel>(ToolStripContainer.mobjTopPanelProperty);
      set => this.SetValue<ToolStripPanel>(ToolStripContainer.mobjTopPanelProperty, value);
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>true to enable automatic scrolling; otherwise, false. </returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool AutoScroll
    {
      get => base.AutoScroll;
      set => base.AutoScroll = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripContainerBottomToolStripPanelDescr")]
    [Localizable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ToolStripPanel BottomToolStripPanel => this.mobjBottomPanel;

    /// <summary>Gets or sets a value indicating whether the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible. </summary>
    /// <returns>true if the bottom panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
    [SRDescription("ToolStripContainerBottomToolStripPanelVisibleDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    public bool BottomToolStripPanelVisible
    {
      get => this.BottomToolStripPanel.Visible;
      set => this.BottomToolStripPanel.Visible = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>true if the control causes validation; otherwise, false. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool CausesValidation
    {
      get => base.CausesValidation;
      set => base.CausesValidation = value;
    }

    /// <summary>Gets the center panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see> representing the center panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("ToolStripContainerContentPanelDescr")]
    [Localizable(false)]
    [SRCategory("CatAppearance")]
    public ToolStripContentPanel ContentPanel => this.mobjContentPanel;

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ContextMenuStrip ContextMenuStrip
    {
      get => base.ContextMenuStrip;
      set => base.ContextMenuStrip = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Control.ControlCollection"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Control.ControlCollection Controls => base.Controls;

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.Cursor"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Cursor Cursor
    {
      get => base.Cursor;
      set => base.Cursor = value;
    }

    /// <summary>Gets the default size of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>, in pixels.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> representing the horizontal and vertical dimensions of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>, in pixels.</returns>
    protected override Size DefaultSize => new Size(150, 175);

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    /// <summary>Gets the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripContainerLeftToolStripPanelDescr")]
    [Localizable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ToolStripPanel LeftToolStripPanel => this.mobjLeftPanel;

    /// <summary>Gets or sets a value indicating whether the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
    /// <returns>true if the left panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripContainerLeftToolStripPanelVisibleDescr")]
    [DefaultValue(true)]
    public bool LeftToolStripPanelVisible
    {
      get => this.LeftToolStripPanel.Visible;
      set => this.LeftToolStripPanel.Visible = value;
    }

    /// <summary>Gets the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Localizable(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("ToolStripContainerRightToolStripPanelDescr")]
    public ToolStripPanel RightToolStripPanel => this.mobjRightPanel;

    /// <summary>Gets or sets a value indicating whether the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
    /// <returns>true if the right panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    [SRDescription("ToolStripContainerRightToolStripPanelVisibleDescr")]
    public bool RightToolStripPanelVisible
    {
      get => this.RightToolStripPanel.Visible;
      set => this.RightToolStripPanel.Visible = value;
    }

    /// <summary>Gets the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripPanel"></see> representing the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see>.</returns>
    [SRCategory("CatAppearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("ToolStripContainerTopToolStripPanelDescr")]
    [Localizable(false)]
    public ToolStripPanel TopToolStripPanel => this.mobjTopPanel;

    /// <summary>Gets or sets a value indicating whether the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible.</summary>
    /// <returns>true if the top panel of the <see cref="T:System.Windows.Forms.ToolStripContainer"></see> is visible; otherwise, false. The default is true.</returns>
    [SRDescription("ToolStripContainerTopToolStripPanelVisibleDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    public bool TopToolStripPanelVisible
    {
      get => this.TopToolStripPanel.Visible;
      set => this.TopToolStripPanel.Visible = value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler BackColorChanged
    {
      add => base.BackColorChanged += value;
      remove => base.BackColorChanged -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new event EventHandler BackgroundImageChanged
    {
      add => base.BackgroundImageChanged += value;
      remove => base.BackgroundImageChanged -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new event EventHandler BackgroundImageLayoutChanged
    {
      add => base.BackgroundImageLayoutChanged += value;
      remove => base.BackgroundImageLayoutChanged += value;
    }

    /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripContainer.CausesValidation"></see> property changes.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler CausesValidationChanged
    {
      add => base.CausesValidationChanged += value;
      remove => base.CausesValidationChanged -= value;
    }

    /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripContainer.ContextMenuStrip"></see> property changes.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler ContextMenuStripChanged
    {
      add => base.ContextMenuStripChanged += value;
      remove => base.ContextMenuStripChanged -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler CursorChanged
    {
      add => base.CursorChanged += value;
      remove => base.CursorChanged -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler ForeColorChanged
    {
      add => base.ForeColorChanged += value;
      remove => base.ForeColorChanged -= value;
    }

    /// <summary>Creates and returns a <see cref="T:System.Windows.Forms.ToolStripContainer"></see> collection.</summary>
    /// <returns>A read-only <see cref="T:System.Windows.Forms.ToolStripContainer"></see> collection.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override Control.ControlCollection CreateControlsInstance() => (Control.ControlCollection) new ToolStripContainer.ToolStripContainerTypedControlCollection((Control) this, true);

    internal class ToolStripContainerTypedControlCollection : ClientUtils.ReadOnlyControlCollection
    {
      private Type mobjContentPanelType;
      private ToolStripContainer mobjOwnerToolStripContainer;
      private Type mobjPanelType;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer.ToolStripContainerTypedControlCollection" /> class.
      /// </summary>
      /// <param name="c">The c.</param>
      /// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
      public ToolStripContainerTypedControlCollection(Control c, bool isReadOnly)
        : base(c, isReadOnly)
      {
        this.mobjContentPanelType = typeof (ToolStripContentPanel);
        this.mobjPanelType = typeof (ToolStripPanel);
        this.mobjOwnerToolStripContainer = c as ToolStripContainer;
      }

      /// <summary>Adds the specified value.</summary>
      /// <param name="value">The value.</param>
      public override void Add(Control value)
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        if (this.IsReadOnly)
          throw new NotSupportedException(SR.GetString("ToolStripContainerUseContentPanel"));
        Type type = value.GetType();
        if (!this.mobjContentPanelType.IsAssignableFrom(type) && !this.mobjPanelType.IsAssignableFrom(type))
          throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, SR.GetString("TypedControlCollectionShouldBeOfTypes", (object) this.mobjContentPanelType.Name, (object) this.mobjPanelType.Name)), value.GetType().Name);
        base.Add(value);
      }

      /// <summary>Removes the specified value.</summary>
      /// <param name="value">The value.</param>
      public override void Remove(Control value)
      {
        switch (value)
        {
          case ToolStripPanel _:
          case ToolStripContentPanel _:
            if (!this.mobjOwnerToolStripContainer.DesignMode && this.IsReadOnly)
              throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
            break;
        }
        base.Remove(value);
      }

      /// <summary>Sets the child index internal.</summary>
      /// <param name="child">The child.</param>
      /// <param name="newIndex">The new index.</param>
      internal override void SetChildIndexInternal(Control child, int newIndex)
      {
        switch (child)
        {
          case ToolStripPanel _:
          case ToolStripContentPanel _:
            if (this.mobjOwnerToolStripContainer.DesignMode)
              return;
            if (this.IsReadOnly)
              throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
            break;
        }
        base.SetChildIndexInternal(child, newIndex);
      }
    }
  }
}
