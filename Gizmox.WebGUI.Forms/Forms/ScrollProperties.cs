// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ScrollProperties
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [Serializable]
  public abstract class ScrollProperties
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollProperties"></see> class. </summary>
    /// <param name="container">The <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see> whose scrolling properties this object describes.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    protected ScrollProperties(ScrollableControl container)
    {
    }

    /// <summary>Gets or sets whether the scroll bar can be used on the container.</summary>
    /// <returns>true if the scroll bar can be used; otherwise, false. </returns>
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
    public bool Enabled
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the distance to move a scroll bar in response to a large scroll command. </summary>
    /// <returns>An <see cref="T:System.Int32"></see> describing how far, in pixels, to move the scroll bar in response to a large change.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <see cref="P:Gizmox.WebGUI.Forms.ScrollProperties.LargeChange"></see> cannot be less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int LargeChange
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets the upper limit of the scrollable range. </summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the maximum range of the scroll bar.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Maximum
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets the lower limit of the scrollable range. </summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the lower range of the scroll bar.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <see cref="P:Gizmox.WebGUI.Forms.ScrollProperties.LargeChange"></see> cannot be less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Minimum
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets the control to which this scroll information applies.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ScrollableControl"></see>.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected ScrollableControl ParentControl => (ScrollableControl) null;

    /// <summary>Gets or sets the distance to move a scroll bar in response to a small scroll command. </summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing how far, in pixels, to move the scroll bar.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SmallChange
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets a numeric value that represents the current position of the scroll bar box.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the position of the scroll bar box, in pixels. </returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Value
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets whether the scroll bar can be seen by the user.</summary>
    /// <returns>true if it can be seen; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Visible
    {
      get => true;
      set
      {
      }
    }
  }
}
