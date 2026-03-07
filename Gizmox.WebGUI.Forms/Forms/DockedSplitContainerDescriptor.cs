// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedSplitContainerDescriptor
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
  internal class DockedSplitContainerDescriptor : DockedObjectDescriptor
  {
    private Orientation menmOrientation;
    private int mintPanelSide;
    private int mintSplitterDistance;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedSplitContainerDescriptor" /> class.
    /// </summary>
    /// <param name="objDockedSplitContainerDescriptor">The obj docked split container descriptor.</param>
    public DockedSplitContainerDescriptor(
      DockedSplitContainerDescriptor objDockedSplitContainerDescriptor)
      : this()
    {
      this.mintSplitterDistance = objDockedSplitContainerDescriptor.mintSplitterDistance;
      this.menmOrientation = objDockedSplitContainerDescriptor.menmOrientation;
      this.mintPanelSide = objDockedSplitContainerDescriptor.mintPanelSide;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedSplitContainerDescriptor" /> class.
    /// </summary>
    public DockedSplitContainerDescriptor() => this.mintPanelSide = -1;

    /// <summary>Gets the orientation.</summary>
    public Orientation Orientation => this.menmOrientation;

    /// <summary>Gets the panel side.</summary>
    public int PanelSide => this.mintPanelSide;

    /// <summary>Gets the splitter distance.</summary>
    public int SplitterDistance => this.mintSplitterDistance;

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
    internal override T CloneWithoutReferences<T>() => new DockedSplitContainerDescriptor(this) as T;

    /// <summary>Notifies the zone is empty.</summary>
    /// <param name="intPanelSide">The int panel side.</param>
    internal void NotifyZoneIsEmpty(int intPanelSide) => this.Manager.NotifyZoneEmpty(this, intPanelSide);

    /// <summary>Updates from docked split container.</summary>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    /// <param name="intPanelSide">The int panel side.</param>
    internal override void UpdateFromDockedSplitContainer(
      DockedSplitContainer objDockedSplitContainer,
      int intPanelSide)
    {
      this.mintPanelSide = intPanelSide;
    }

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    internal override void UpdateSelf(Control objControl, DockingManager objManager)
    {
      DockedSplitContainer dockedSplitContainer = objControl as DockedSplitContainer;
      this.menmOrientation = dockedSplitContainer.Orientation;
      this.mintSplitterDistance = dockedSplitContainer.SplitterDistance;
    }
  }
}
