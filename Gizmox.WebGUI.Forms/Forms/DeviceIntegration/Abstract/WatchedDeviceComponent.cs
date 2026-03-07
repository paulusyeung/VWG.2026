// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.WatchedDeviceComponent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class WatchedDeviceComponent : DeviceComponent
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.WatchedDeviceComponent" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public WatchedDeviceComponent(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal abstract override string GetTag();

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected override void FireEvent(IEvent objEvent) => base.FireEvent(objEvent);

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    public new abstract CriticalEventsData GetCriticalEventsData();
  }
}
