// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ZoneDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class ZoneDescriptor : DockedObjectDescriptor
  {
    private DockStyle menmDockingPosition;
    private int mintPanelSide;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ZoneDescriptor" /> class.
    /// </summary>
    /// <param name="objZoneDescriptor">The obj zone descriptor.</param>
    public ZoneDescriptor(ZoneDescriptor objZoneDescriptor)
      : this()
    {
      this.mintPanelSide = objZoneDescriptor.mintPanelSide;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ZoneDescriptor" /> class.
    /// </summary>
    public ZoneDescriptor()
    {
      this.mintPanelSide = -1;
      this.menmDockingPosition = DockStyle.None;
    }

    /// <summary>Gets or sets the docking position.</summary>
    /// <value>The docking position.</value>
    public DockStyle DockingPosition
    {
      get => this.menmDockingPosition;
      set => this.menmDockingPosition = value;
    }

    /// <summary>Gets or sets the panel side.</summary>
    /// <value>The panel side.</value>
    public int PanelSide
    {
      get => this.mintPanelSide;
      set => this.mintPanelSide = value;
    }

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal override bool CanUpdateFrom(Type objType) => objType == typeof (DockedSplitContainer) || typeof (DockingManager).IsAssignableFrom(objType) || objType == typeof (DockedForm);

    /// <summary>Clones the without references.</summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal override T CloneWithoutReferences<T>() => new ZoneDescriptor(this) as T;

    /// <summary>Notifies the tab has no windows.</summary>
    /// <param name="objDockedTabControlDescriptor">The docked tab control descriptor.</param>
    internal void NotifyTabHasNoWindows(
      DockedTabControlDescriptor objDockedTabControlDescriptor)
    {
      if (this.ParentDescriptor == null || !(this.ParentDescriptor is DockedSplitContainerDescriptor parentDescriptor))
        return;
      parentDescriptor.NotifyZoneIsEmpty(this.PanelSide);
    }

    /// <summary>Updates from docked manager.</summary>
    /// <param name="objDockedManager">The obj docked manager.</param>
    internal override void UpdateFromDockedManager(DockingManager objDockedManager) => this.PanelSide = -1;

    /// <summary>Updates from docked split container.</summary>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    /// <param name="intPanelSide">The int panel side.</param>
    internal override void UpdateFromDockedSplitContainer(
      DockedSplitContainer objDockedSplitContainer,
      int intPanelSide)
    {
      this.PanelSide = intPanelSide;
    }
  }
}
