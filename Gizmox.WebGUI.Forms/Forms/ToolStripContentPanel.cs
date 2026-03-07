// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripContentPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the center panel of a <see cref="T:System.Windows.Forms.ToolStripContainer"></see> control.</summary>
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [InitializationEvent("Load")]
  [DefaultEvent("Load")]
  [ToolboxItem(false)]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripContentPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ToolStripContentPanel : Panel
  {
    private static readonly SerializableEvent LoadEvent = SerializableEvent.Register("Load", typeof (EventHandler), typeof (ToolStripContentPanel));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> class. </summary>
    public ToolStripContentPanel() => this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnLoad(EventArgs e)
    {
      EventHandler loadHandler = this.LoadHandler;
      if (loadHandler == null)
        return;
      loadHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
    /// </summary>
    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.OnLoad(EventArgs.Empty);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripContentPanel.RendererChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRendererChanged(EventArgs e)
    {
    }

    /// <summary>This event is not relevant to this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new event EventHandler AutoSizeChanged
    {
      add => base.AutoSizeChanged += value;
      remove => base.AutoSizeChanged -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler CausesValidationChanged
    {
      add => base.CausesValidationChanged += value;
      remove => base.CausesValidationChanged -= value;
    }

    /// <summary>This event is not relevant to this class.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler DockChanged
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the content panel loads.</summary>
    [SRDescription("ToolStripContentPanelOnLoadDescr")]
    [SRCategory("CatBehavior")]
    public event EventHandler Load
    {
      add => this.AddCriticalHandler(ToolStripContentPanel.LoadEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripContentPanel.LoadEvent, (Delegate) value);
    }

    /// <summary>Gets the Load handler.</summary>
    /// <value>The Load handler.</value>
    private EventHandler LoadHandler => (EventHandler) this.GetHandler(ToolStripContentPanel.LoadEvent);

    /// <summary>This event is not relevant to this class.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler LocationChanged
    {
      add => base.LocationChanged += value;
      remove => base.LocationChanged -= value;
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripContentPanel.Renderer"></see> property changes.</summary>
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

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Windows.Forms.AnchorStyles"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override AnchorStyles Anchor
    {
      get => base.Anchor;
      set => base.Anchor = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true to enable automatic scrolling; otherwise, false.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool AutoScroll
    {
      get => base.AutoScroll;
      set => base.AutoScroll = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
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
    /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size AutoScrollMinSize
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true to enable automatic sizing; otherwise, false.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Windows.Forms.AutoSizeMode"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [Localizable(false)]
    public override AutoSizeMode AutoSizeMode
    {
      get => AutoSizeMode.GrowOnly;
      set
      {
      }
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if the control causes validation; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool CausesValidation
    {
      get => base.CausesValidation;
      set => base.CausesValidation = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.DockStyle"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set => base.Dock = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Point"></see>.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Point Location
    {
      get => base.Location;
      set => base.Location = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Size MaximumSize
    {
      get => base.MaximumSize;
      set => base.MaximumSize = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override Size MinimumSize
    {
      get => base.MinimumSize;
      set => base.MinimumSize = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.String"></see>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string Name
    {
      get => base.Name;
      set => base.Name = value;
    }

    /// <summary>Gets or sets a <see cref="T:System.Windows.Forms.ToolStripRenderer"></see> used to customize the appearance of a <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripRenderer"></see> that handles painting.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripRenderer Renderer
    {
      get => (ToolStripRenderer) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the painting styles to be applied to the <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripRenderMode"></see> values. </returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripRenderMode RenderMode
    {
      get => ToolStripRenderMode.Custom;
      set
      {
      }
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Int32"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int TabIndex
    {
      get => base.TabIndex;
      set => base.TabIndex = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripContentPanel"></see> can be tabbed to; otherwise, false.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool TabStop
    {
      get => base.TabStop;
      set => base.TabStop = value;
    }
  }
}
