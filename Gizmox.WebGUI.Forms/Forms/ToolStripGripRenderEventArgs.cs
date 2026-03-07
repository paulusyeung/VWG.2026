// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public class ToolStripGripRenderEventArgs : ToolStripRenderEventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> class.</summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> object used to paint the move handle.</param>
    /// <param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> the move handle is to be drawn on.</param>
    public ToolStripGripRenderEventArgs(Graphics g, ToolStrip toolStrip)
      : base(g, toolStrip)
    {
    }

    /// <summary>Gets the rectangle representing the area in which to paint the move handle.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the area in which to paint the move handle.</returns>
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
    public Rectangle GripBounds => Rectangle.Empty;

    /// <summary>Gets the style that indicates whether the move handle is displayed vertically or horizontally.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripGripDisplayStyle GripDisplayStyle => ToolStripGripDisplayStyle.Horizontal;

    /// <summary>Gets the style that indicates whether or not the move handle is visible.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripGripStyle GripStyle => ToolStripGripStyle.Visible;
  }
}
