// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedWindowPlaceHolderDescriptor
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
  internal class DockedWindowPlaceHolderDescriptor : DockedObjectDescriptor
  {
    private DockedWindowDescriptor mobjWindowDescriptor;
    private ZoneType mobjZoneType;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedWindowPlaceHolderDescriptor" /> class.
    /// </summary>
    /// <param name="objWindowDescriptor">The obj window descriptor.</param>
    /// <param name="objZoneType">Type of the obj zone.</param>
    internal DockedWindowPlaceHolderDescriptor(
      DockedWindowDescriptor objWindowDescriptor,
      ZoneType objZoneType)
    {
      this.SetContainer(objWindowDescriptor.ParentDescriptor);
      this.mobjZoneType = objZoneType;
      this.mobjWindowDescriptor = objWindowDescriptor;
    }

    /// <summary>Gets the name of the window.</summary>
    /// <value>The name of the window.</value>
    public DockingWindowName WindowName => this.mobjWindowDescriptor.WindowName;

    /// <summary>Gets or sets the type of the zone.</summary>
    /// <value>The type of the zone.</value>
    internal ZoneType ZoneType
    {
      get => this.mobjZoneType;
      set => this.mobjZoneType = value;
    }

    /// <summary>
    /// Determines whether this instance [can update from] the specified obj type.
    /// </summary>
    /// <param name="objType">Type of the obj.</param>
    /// <returns>
    ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
    /// </returns>
    internal override bool CanUpdateFrom(Type objType) => throw new NotImplementedException();

    /// <summary>Clones the without references.</summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal override T CloneWithoutReferences<T>() => throw new Exception();

    /// <summary>Updates the self.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objManager"></param>
    internal override void UpdateSelf(Control objControl, DockingManager objManager)
    {
    }
  }
}
