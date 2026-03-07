// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripRenderEventArgs
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
  public class ToolStripRenderEventArgs : EventArgs
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> and using the specified <see cref="T:System.Drawing.Graphics"></see>. </summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> to use for painting.</param>
    /// <param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to paint.</param>
    public ToolStripRenderEventArgs(Graphics g, ToolStrip toolStrip)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, using the specified <see cref="T:System.Drawing.Graphics"></see> to paint the specified bounds with the specified <see cref="T:System.Drawing.Color"></see>.</summary>
    /// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> to use for painting.</param>
    /// <param name="backColor">The <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</param>
    /// <param name="affectedBounds">The <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted.</param>
    /// <param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to paint.</param>
    public ToolStripRenderEventArgs(
      Graphics g,
      ToolStrip toolStrip,
      Rectangle affectedBounds,
      Color backColor)
    {
    }

    /// <summary>Gets the <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted. </summary>
    /// <returns>The <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle AffectedBounds => Rectangle.Empty;

    /// <summary>Gets the <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</summary>
    /// <returns>The <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BackColor => Color.Empty;

    /// <summary>Gets the <see cref="T:System.Drawing.Rectangle"></see> representing the overlap area between a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> and its <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.OwnerItem"></see>.</summary>
    /// <returns>The <see cref="T:System.Drawing.Rectangle"></see> representing the overlap area between a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> and its <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.OwnerItem"></see>.</returns>
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
    public Rectangle ConnectedArea => Rectangle.Empty;

    /// <summary>Gets the <see cref="T:System.Drawing.Graphics"></see> used to paint.</summary>
    /// <returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Graphics Graphics => (Graphics) null;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be painted.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be painted.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStrip ToolStrip => (ToolStrip) null;
  }
}
