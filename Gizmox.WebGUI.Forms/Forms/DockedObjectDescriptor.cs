// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedObjectDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Describes a Docked object inside the Docke Manager</summary>
  [Serializable]
  public abstract class DockedObjectDescriptor
  {
    private DockedObjectDescriptor mobjParentDescriptor;

    /// <summary>Gets the container.</summary>
    internal DockedObjectDescriptor ParentDescriptor => this.mobjParentDescriptor;

    /// <summary>Gets the manager.</summary>
    public virtual DockingManager Manager => this.ParentDescriptor != null ? this.ParentDescriptor.Manager : (DockingManager) null;

    /// <summary>
    /// Gets a value indicating whether this instance is in load mode.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is in load mode; otherwise, <c>false</c>.
    /// </value>
    protected internal bool IsInLoadMode => this.Manager != null && this.Manager.IsInLoadMode;

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal virtual bool CanUpdateFrom(Type objType) => false;

    /// <summary>Clones the without references.</summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal virtual T CloneWithoutReferences<T>() where T : DockedObjectDescriptor => default (T);

    /// <summary>Sets the container.</summary>
    /// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
    internal void SetContainer(DockedObjectDescriptor objDockedObjectDescriptor) => this.mobjParentDescriptor = objDockedObjectDescriptor;

    /// <summary>Updates from.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objExtraData">The obj extra data.</param>
    internal void UpdateFrom(Control objControl, object objExtraData)
    {
      if (!this.CanUpdateFrom(objControl.GetType()))
        return;
      switch (objControl)
      {
        case DockedTabControl _:
          this.UpdateFromTabControl(objControl as DockedTabControl, (bool) objExtraData);
          break;
        case DockingManager _:
          this.UpdateFromDockedManager(objControl as DockingManager);
          break;
        case DockedSplitContainer _:
          this.UpdateFromDockedSplitContainer(objControl as DockedSplitContainer, (int) objExtraData);
          break;
        case Zone _:
          this.UpdateFromZone(objControl as Zone);
          break;
        case DockingWindow _:
          this.UpdateFromDockedWindow(objControl as DockingWindow);
          break;
        case DockedForm _:
          this.UpdateFromDockedForm(objControl as DockedForm);
          break;
        case DockedHiddenZonesPanel _:
          this.UpdateFromDockedHiddenZonesPanel(objControl as DockedHiddenZonesPanel);
          break;
        default:
          throw new Exception();
      }
      if (objControl is IDescriptable)
        this.SetContainer((objControl as IDescriptable).Descriptor);
      else
        this.mobjParentDescriptor = (DockedObjectDescriptor) null;
    }

    /// <summary>Updates from docked form.</summary>
    /// <param name="dockedForm">The docked form.</param>
    internal virtual void UpdateFromDockedForm(DockedForm dockedForm)
    {
    }

    /// <summary>Updates from docked hidden zones panel.</summary>
    /// <param name="dockedHiddenZonesPanel">The docked hidden zones panel.</param>
    internal virtual void UpdateFromDockedHiddenZonesPanel(
      DockedHiddenZonesPanel dockedHiddenZonesPanel)
    {
    }

    /// <summary>Updates from docked manager.</summary>
    /// <param name="objDockedManager">The obj docked manager.</param>
    internal virtual void UpdateFromDockedManager(DockingManager objDockedManager)
    {
    }

    /// <summary>Updates from docked split container.</summary>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    /// <param name="intPanelSide">The int panel side.</param>
    internal virtual void UpdateFromDockedSplitContainer(
      DockedSplitContainer objDockedSplitContainer,
      int intPanelSide)
    {
    }

    /// <summary>Updates from docked window.</summary>
    /// <param name="objDockedWindow">The obj docked window.</param>
    internal virtual void UpdateFromDockedWindow(DockingWindow objDockedWindow)
    {
    }

    /// <summary>Updates from tab control.</summary>
    /// <param name="objDockedTabControl">The obj docked tab control.</param>
    /// <param name="blnPreventExtraction">if set to <c>true</c> [BLN prevent extraction].</param>
    internal virtual void UpdateFromTabControl(
      DockedTabControl objDockedTabControl,
      bool blnPreventExtraction)
    {
    }

    /// <summary>Updates from zone.</summary>
    /// <param name="zone">The zone.</param>
    internal virtual void UpdateFromZone(Zone zone)
    {
    }

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    internal virtual void UpdateSelf(Control objControl, DockingManager objManager)
    {
    }
  }
}
