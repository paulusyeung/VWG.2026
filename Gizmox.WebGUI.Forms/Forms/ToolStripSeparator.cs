// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripSeparator
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

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a line used to group items of a <see cref="T:System.Windows.Forms.ToolStrip"></see> or the drop-down items of a <see cref="T:System.Windows.Forms.MenuStrip"></see> or <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> or other <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> control.</summary>
  [Skin(typeof (ToolStripSeparatorSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSeparatorController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.ToolStrip)]
  [Serializable]
  public class ToolStripSeparator : ToolStripItem
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> class. </summary>
    public ToolStripSeparator() => this.ForeColor = SystemColors.ControlDark;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler DisplayStyleChanged
    {
      add => base.DisplayStyleChanged += value;
      remove => base.DisplayStyleChanged -= value;
    }

    /// <summary>This event is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler EnabledChanged
    {
      add => base.EnabledChanged += value;
      remove => base.EnabledChanged -= value;
    }

    /// <summary>This event is not relevant to this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new event EventHandler TextChanged
    {
      add => base.TextChanged += value;
      remove => base.TextChanged -= value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false. </returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool AutoToolTip
    {
      get => base.AutoToolTip;
      set => base.AutoToolTip = value;
    }

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 4;

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> can be selected. </summary>
    /// <returns>true if the component using the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is in design mode; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public override bool CanSelect => this.DesignMode;

    /// <summary>
    /// Gets the internal spacing characteristics of the item.
    /// </summary>
    /// <value></value>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
    protected override Size DefaultSize => new Size(6, 6);

    /// <summary>
    /// Gets a value indicating whether to hide item on strip wrapping.
    /// </summary>
    /// <value><c>true</c> if [hide on wrap]; otherwise, <c>false</c>.</value>
    protected override bool HideOnWrap => true;

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> value.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ToolStripItemDisplayStyle DisplayStyle
    {
      get => base.DisplayStyle;
      set => base.DisplayStyle = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false. </returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool DoubleClickEnabled
    {
      get => base.DoubleClickEnabled;
      set => base.DoubleClickEnabled = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override bool Enabled
    {
      get => base.Enabled;
      set => base.Enabled = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.Font"></see> value.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get => base.Font;
      set => base.Font = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new virtual ResourceHandle Image
    {
      get => base.Image;
      set => base.Image = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.VisualStyles.ContentAlignment"></see> value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public new ContentAlignment ImageAlign
    {
      get => base.ImageAlign;
      set => base.ImageAlign = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Int32"></see>.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [RefreshProperties(RefreshProperties.Repaint)]
    public new int ImageIndex
    {
      get => base.ImageIndex;
      set => base.ImageIndex = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.String"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string ImageKey
    {
      get => base.ImageKey;
      set => base.ImageKey = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>true if enabled; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool RightToLeftAutoMirrorImage
    {
      get => base.RightToLeftAutoMirrorImage;
      set => base.RightToLeftAutoMirrorImage = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.String"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Drawing.ContentAlignment"></see> value.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ContentAlignment TextAlign
    {
      get => base.TextAlign;
      set => base.TextAlign = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripTextDirection"></see> value.</returns>
    [DefaultValue(ToolStripTextDirection.Horizontal)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ToolStripTextDirection TextDirection
    {
      get => base.TextDirection;
      set => base.TextDirection = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.TextImageRelation"></see> value.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new TextImageRelation TextImageRelation
    {
      get => base.TextImageRelation;
      set => base.TextImageRelation = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>A string.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string ToolTipText
    {
      get => base.ToolTipText;
      set => base.ToolTipText = value;
    }

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fit.
    /// </summary>
    /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
    /// </returns>
    /// <PermissionSet>
    /// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    /// <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public override Size GetPreferredSize(Size objConstrainingSize)
    {
      Size size = this.Size;
      if (this.ParentInternal != null && SkinFactory.GetSkin((ISkinable) this) is ToolStripSeparatorSkin skin)
      {
        switch (this.ParentInternal.Orientation)
        {
          case Orientation.Horizontal:
            size.Width = skin.VerticalSeperatorWidth;
            break;
          case Orientation.Vertical:
            size.Height = skin.HorizontalSeperatorHeight;
            break;
        }
      }
      return size;
    }
  }
}
