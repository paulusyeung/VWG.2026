// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedHiddenZonePanelDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DockedHiddenZonePanelDescriptor : DockedObjectDescriptor
  {
    private List<List<DockedWindowDescriptor>> mobjWindowDescriptorsGroups;

    /// <summary>Gets the window descriptors groups.</summary>
    internal List<List<DockedWindowDescriptor>> WindowDescriptorsGroups => this.mobjWindowDescriptorsGroups;

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal override bool CanUpdateFrom(Type objType) => typeof (DockingManager).IsAssignableFrom(objType);

    /// <summary>
    /// Returns the and remove windows descriptors groups for load.
    /// </summary>
    /// <returns></returns>
    internal List<List<DockedWindowDescriptor>> RemoveAndReturnWindowsDescriptorsGroupsForLoad()
    {
      List<List<DockedWindowDescriptor>> descriptorsGroups = this.mobjWindowDescriptorsGroups;
      this.mobjWindowDescriptorsGroups = new List<List<DockedWindowDescriptor>>();
      return descriptorsGroups;
    }

    /// <summary>Updates self.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objManager"></param>
    internal override void UpdateSelf(Control objControl, DockingManager objManager)
    {
      if (!(objControl is DockedHiddenZonesPanel hiddenZonesPanel))
        throw new Exception();
      this.mobjWindowDescriptorsGroups = new List<List<DockedWindowDescriptor>>();
      foreach (List<Zone> allZoneGroup in hiddenZonesPanel.AllZoneGroups)
      {
        List<DockedWindowDescriptor> windowDescriptorList = new List<DockedWindowDescriptor>();
        foreach (Zone zone in allZoneGroup)
          windowDescriptorList.Add(zone.CurrentWindow.DockedWindowDescriptor);
        this.mobjWindowDescriptorsGroups.Add(windowDescriptorList);
      }
    }
  }
}
