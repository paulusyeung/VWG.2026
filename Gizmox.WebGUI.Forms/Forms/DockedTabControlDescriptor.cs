// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedTabControlDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DockedTabControlDescriptor : DockedObjectDescriptor
  {
    private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjPlaceHoldersIndexByWindowName;
    private Dictionary<DockedWindowDescriptor, bool> mobjWindowDescriptionsIndicator;
    private int mintSelectedIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabControlDescriptor" /> class.
    /// </summary>
    /// <param name="objDockedTabControlDescriptor">The obj docked tab control descriptor.</param>
    public DockedTabControlDescriptor(
      DockedTabControlDescriptor objDockedTabControlDescriptor)
      : this()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabControlDescriptor" /> class.
    /// </summary>
    public DockedTabControlDescriptor()
    {
      this.mobjWindowDescriptionsIndicator = new Dictionary<DockedWindowDescriptor, bool>();
      this.mobjPlaceHoldersIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
    }

    /// <summary>Gets the sorted window descriptions indicator.</summary>
    internal Dictionary<DockedWindowDescriptor, bool> WindowDescriptionsIndicator => this.mobjWindowDescriptionsIndicator;

    /// <summary>Gets the index of the selected.</summary>
    /// <value>The index of the selected.</value>
    internal int SelectedIndex => this.mintSelectedIndex;

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal override bool CanUpdateFrom(Type objType) => objType == typeof (Zone);

    /// <summary>Clones the without references.</summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal override T CloneWithoutReferences<T>() => new DockedTabControlDescriptor(this) as T;

    /// <summary>Removes the window.</summary>
    /// <param name="objWindowDescriptor">The obj window descriptor.</param>
    internal void RemoveWindow(DockedWindowDescriptor objWindowDescriptor)
    {
      this.mobjWindowDescriptionsIndicator.Remove(objWindowDescriptor);
      DockedWindowPlaceHolderDescriptor objDockedWindowPlaceHolderDescriptor;
      if (this.mobjPlaceHoldersIndexByWindowName.TryGetValue(objWindowDescriptor.WindowName, out objDockedWindowPlaceHolderDescriptor))
      {
        this.mobjPlaceHoldersIndexByWindowName.Remove(objWindowDescriptor.WindowName);
        this.Manager.UnregisterPlaceHolder(objDockedWindowPlaceHolderDescriptor);
      }
      if (this.ParentDescriptor == null || this.mobjWindowDescriptionsIndicator.Count != 0 || this.mobjPlaceHoldersIndexByWindowName.Count != 0 || !(this.ParentDescriptor is ZoneDescriptor parentDescriptor))
        return;
      parentDescriptor.NotifyTabHasNoWindows(this);
    }

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objManager"></param>
    internal override void UpdateSelf(Control objControl, DockingManager objManager)
    {
      DockedTabControl dockedTabControl = objControl as DockedTabControl;
      Dictionary<DockedWindowDescriptor, bool> dictionary = new Dictionary<DockedWindowDescriptor, bool>();
      ZoneType zoneType = dockedTabControl.OwningZone.ZoneType;
      foreach (DockedTabPage control in (ArrangedElementCollection) dockedTabControl.Controls)
      {
        DockedWindowDescriptor descriptorInternal = control.Window.DockedWindowDescriptorInternal;
        dictionary.Add(descriptorInternal, true);
        if (zoneType != ZoneType.Root && zoneType != ZoneType.Hidden && !this.mobjPlaceHoldersIndexByWindowName.ContainsKey(descriptorInternal.WindowName))
          this.mobjPlaceHoldersIndexByWindowName.Add(descriptorInternal.WindowName, objManager.RegisterPlaceHolder(zoneType, descriptorInternal));
      }
      if (!this.IsInLoadMode)
        this.mintSelectedIndex = dockedTabControl.SelectedIndex;
      this.mobjWindowDescriptionsIndicator = dictionary;
    }
  }
}
