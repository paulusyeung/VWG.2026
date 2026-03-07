// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripProgressBar
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a Windows progress bar control contained in a <see cref="T:System.Windows.Forms.StatusStrip"></see>.</summary>
  [DefaultProperty("Value")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripProgressBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
  [Serializable]
  public class ToolStripProgressBar : ToolStripControlHost
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see> class. </summary>
    public ToolStripProgressBar()
      : base((Control) new ProgressBar())
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see> class with specified name. </summary>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripProgressBar"></see>.</param>
    public ToolStripProgressBar(string name)
      : this()
    {
      this.Name = name;
    }

    /// <summary>Advances the current position of the progress bar by the specified amount.</summary>
    /// <param name="value">The amount by which to increment the progress bar's current position.</param>
    public void Increment(int value) => this.ProgressBar.Increment(value);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ProgressBar.RightToLeftLayoutChanged"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnRightToLeftLayoutChanged(EventArgs e)
    {
    }

    /// <summary>Advances the current position of the progress bar by the amount of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripProgressBar.Step"></see> property.</summary>
    public void PerformStep() => this.ProgressBar.PerformStep();

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event KeyEventHandler KeyDown
    {
      add => base.KeyDown += value;
      remove => base.KeyDown -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event KeyPressEventHandler KeyPress
    {
      add => base.KeyPress += value;
      remove => base.KeyPress -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event KeyEventHandler KeyUp
    {
      add => base.KeyUp += value;
      remove => base.KeyUp -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler LocationChanged
    {
      add => base.LocationChanged += value;
      remove => base.LocationChanged -= value;
    }

    /// <summary>This event is not relevant for this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler OwnerChanged
    {
      add => base.OwnerChanged += value;
      remove => base.OwnerChanged -= value;
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripProgressBar.RightToLeftLayout"></see> property changes.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler RightToLeftLayoutChanged
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>This event is not relevant for this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler TextChanged
    {
      add => base.TextChanged += value;
      remove => base.TextChanged -= value;
    }

    /// <summary>This event is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler Validated
    {
      add => base.Validated += value;
      remove => base.Validated -= value;
    }

    /// <summary>This event is not relevant to this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event CancelEventHandler Validating
    {
      add => base.Validating += value;
      remove => base.Validating -= value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see> value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets the height and width of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> in pixels.</summary>
    /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> value representing the height and width.</returns>
    protected override Size DefaultSize => new Size(100, 15);

    /// <summary>Gets or sets a value representing the delay between each <see cref="F:System.Windows.Forms.ProgressBarStyle.Marquee"></see> display update, in milliseconds.</summary>
    /// <returns>An integer representing the delay, in milliseconds.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int MarqueeAnimationSpeed
    {
      get => 100;
      set
      {
      }
    }

    /// <summary>Gets or sets the upper bound of the range that is defined for this <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
    /// <returns>An integer representing the upper bound of the range. The default is 100.</returns>
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("ProgressBarMaximumDescr")]
    [DefaultValue(100)]
    [SRCategory("CatBehavior")]
    public int Maximum
    {
      get => this.ProgressBar.Maximum;
      set => this.ProgressBar.Maximum = value;
    }

    /// <summary>Gets or sets the lower bound of the range that is defined for this <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
    /// <returns>An integer representing the lower bound of the range. The default is 0.</returns>
    [DefaultValue(0)]
    [SRCategory("CatBehavior")]
    [SRDescription("ProgressBarMinimumDescr")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public int Minimum
    {
      get => this.ProgressBar.Minimum;
      set => this.ProgressBar.Minimum = value;
    }

    /// <summary>Gets the <see cref="T:System.Windows.Forms.ProgressBar"></see>.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ProgressBar"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public ProgressBar ProgressBar => this.Control as ProgressBar;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> layout is right-to-left or left-to-right when the <see cref="T:System.Windows.Forms.RightToLeft"></see> property is set to <see cref="F:System.Windows.Forms.RightToLeft.Yes"></see>. </summary>
    /// <returns>true to turn on mirroring and lay out control from right to left when the <see cref="T:System.Windows.Forms.RightToLeft"></see> property is set to <see cref="F:System.Windows.Forms.RightToLeft.Yes"></see>; otherwise, false. The default is false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool RightToLeftLayout
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the amount by which to increment the current value of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see> when the <see cref="M:System.Windows.Forms.ToolStripProgressBar.PerformStep"></see> method is called.</summary>
    /// <returns>An integer representing the incremental amount. The default value is 10.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(10)]
    [SRCategory("CatBehavior")]
    [SRDescription("ProgressBarStepDescr")]
    public int Step
    {
      get => this.ProgressBar.Step;
      set => this.ProgressBar.Step = value;
    }

    /// <summary>Gets or sets the style of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ProgressBarStyle"></see> values. The default value is <see cref="F:System.Windows.Forms.ProgressBarStyle.Blocks"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ProgressBarStyle Style
    {
      get => ProgressBarStyle.Blocks;
      set
      {
      }
    }

    /// <summary>Gets or sets the text displayed on the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
    /// <returns>A <see cref="T:System.String"></see> representing the display text.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get => this.Control.Text;
      set => this.Control.Text = value;
    }

    /// <summary>Gets or sets the current value of the <see cref="T:System.Windows.Forms.ToolStripProgressBar"></see>.</summary>
    /// <returns>An integer representing the current value.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [SRDescription("ProgressBarValueDescr")]
    [Bindable(true)]
    [DefaultValue(0)]
    public int Value
    {
      get => this.ProgressBar.Value;
      set => this.ProgressBar.Value = value;
    }
  }
}
