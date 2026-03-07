// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.DeviceEvents
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>Represents Device Events target object.</summary>
  [Serializable]
  public class DeviceEvents : WatchedDeviceComponent, IDeviceEvents
  {
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjPauseEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjResumeEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjOnlineEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjOfflineEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjBackButtonEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjMenuButtonEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjSearchButtonEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjVolumeDownButtonEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjVolumeUpButtonEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjStartCallButtonEventStore;
    private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjEndCallButtonEventStore;
    private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryCriticalEventStore;
    private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryLowEventStore;
    private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryStatusEventStore;

    /// <summary>Gets the pause event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> PauseEventStore
    {
      get
      {
        if (this.mobjPauseEventStore == null)
          this.mobjPauseEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjPauseEventStore;
      }
    }

    /// <summary>Gets the resume event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> ResumeEventStore
    {
      get
      {
        if (this.mobjResumeEventStore == null)
          this.mobjResumeEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjResumeEventStore;
      }
    }

    /// <summary>Gets the online event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> OnlineEventStore
    {
      get
      {
        if (this.mobjOnlineEventStore == null)
          this.mobjOnlineEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjOnlineEventStore;
      }
    }

    /// <summary>Gets the offline event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> OfflineEventStore
    {
      get
      {
        if (this.mobjOfflineEventStore == null)
          this.mobjOfflineEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjOfflineEventStore;
      }
    }

    /// <summary>Gets the back button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> BackButtonEventStore
    {
      get
      {
        if (this.mobjBackButtonEventStore == null)
          this.mobjBackButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjBackButtonEventStore;
      }
    }

    /// <summary>Gets the menu button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> MenuButtonEventStore
    {
      get
      {
        if (this.mobjMenuButtonEventStore == null)
          this.mobjMenuButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjMenuButtonEventStore;
      }
    }

    /// <summary>Gets the search button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> SearchButtonEventStore
    {
      get
      {
        if (this.mobjSearchButtonEventStore == null)
          this.mobjSearchButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjSearchButtonEventStore;
      }
    }

    /// <summary>Gets the volume down button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> VolumeDownButtonEventStore
    {
      get
      {
        if (this.mobjVolumeDownButtonEventStore == null)
          this.mobjVolumeDownButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjVolumeDownButtonEventStore;
      }
    }

    /// <summary>Gets the volume up button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> VolumeUpButtonEventStore
    {
      get
      {
        if (this.mobjVolumeUpButtonEventStore == null)
          this.mobjVolumeUpButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjVolumeUpButtonEventStore;
      }
    }

    /// <summary>Gets the start call button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> StartCallButtonEventStore
    {
      get
      {
        if (this.mobjStartCallButtonEventStore == null)
          this.mobjStartCallButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjStartCallButtonEventStore;
      }
    }

    /// <summary>Gets the end call button event store.</summary>
    private MultipleCallMethodStore<EmptyDeviceEventArgs> EndCallButtonEventStore
    {
      get
      {
        if (this.mobjEndCallButtonEventStore == null)
          this.mobjEndCallButtonEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>();
        return this.mobjEndCallButtonEventStore;
      }
    }

    /// <summary>Gets the battery critical event store.</summary>
    private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryCriticalEventStore
    {
      get
      {
        if (this.mobjBatteryCriticalEventStore == null)
          this.mobjBatteryCriticalEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
        return this.mobjBatteryCriticalEventStore;
      }
    }

    /// <summary>Gets the battery low event store.</summary>
    private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryLowEventStore
    {
      get
      {
        if (this.mobjBatteryLowEventStore == null)
          this.mobjBatteryLowEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
        return this.mobjBatteryLowEventStore;
      }
    }

    /// <summary>Gets the battery status event store.</summary>
    private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryStatusEventStore
    {
      get
      {
        if (this.mobjBatteryStatusEventStore == null)
          this.mobjBatteryStatusEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>();
        return this.mobjBatteryStatusEventStore;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.DeviceEvents" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public DeviceEvents(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Occurs when application is put into the background.</summary>
    public event Action<EmptyDeviceEventArgs> Pause
    {
      add
      {
        this.PauseEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.PauseEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Occurs when application is retrieved from the background.
    /// </summary>
    public event Action<EmptyDeviceEventArgs> Resume
    {
      add
      {
        this.ResumeEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.ResumeEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Occurs when application is online (connected to the Internet).
    /// </summary>
    public event Action<EmptyDeviceEventArgs> Online
    {
      add
      {
        this.OnlineEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.OnlineEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Occurs when application is offline (not connected to the Internet).
    /// </summary>
    public event Action<EmptyDeviceEventArgs> Offline
    {
      add
      {
        this.OfflineEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.OfflineEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when the user presses the back button.</summary>
    public event Action<EmptyDeviceEventArgs> BackButtonPressed
    {
      add
      {
        this.BackButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.BackButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when the user presses the menu button.</summary>
    public event Action<EmptyDeviceEventArgs> MenuButtonPressed
    {
      add
      {
        this.MenuButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.MenuButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when he user presses the search button.</summary>
    public event Action<EmptyDeviceEventArgs> SearchButtonPressed
    {
      add
      {
        this.SearchButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.SearchButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when  the user presses the start call button.</summary>
    public event Action<EmptyDeviceEventArgs> StartCallButtonPressed
    {
      add
      {
        this.StartCallButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.StartCallButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when the user presses the end call button.</summary>
    public event Action<EmptyDeviceEventArgs> EndCallButtonPressed
    {
      add
      {
        this.EndCallButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.EndCallButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when the user presses the volume down button.</summary>
    public event Action<EmptyDeviceEventArgs> VolumeDownButtonPressed
    {
      add
      {
        this.VolumeDownButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.VolumeDownButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>Occurs when the user presses the volume up button.</summary>
    public event Action<EmptyDeviceEventArgs> VolumeUpButtonPressed
    {
      add
      {
        this.VolumeUpButtonEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.VolumeUpButtonEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Occurs when application detects the battery has reached the critical level threshold.
    /// </summary>
    public event Action<DeviceBatteryEventArgs> BatteryCritical
    {
      add
      {
        this.BatteryCriticalEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.BatteryCriticalEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Occurs when application detects the battery has reached the low level threshold.
    /// </summary>
    public event Action<DeviceBatteryEventArgs> BatteryLow
    {
      add
      {
        this.BatteryLowEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.BatteryLowEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Occurs when application detects a change in the battery status.
    /// </summary>
    public event Action<DeviceBatteryEventArgs> BatteryStatusChanged
    {
      add
      {
        this.BatteryStatusEventStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.BatteryStatusEventStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("DeviceEvents_Initialize", (object) this.ID);
    }

    /// <summary>Renders the attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    internal override void RenderAttributes(IContext objContext, IResponseWriter objWriter)
    {
      if (!(objWriter is IAttributeWriter attributeWriter))
        return;
      attributeWriter.WriteAttributeString("E", this.GetCriticalEventsData().ToClientString());
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "ES";

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      MultipleCallMethodStore<EmptyDeviceEventArgs> objDeviceMethodStore = (MultipleCallMethodStore<EmptyDeviceEventArgs>) null;
      MultipleCallMethodStore<DeviceBatteryEventArgs> objBatteryMethodStore = (MultipleCallMethodStore<DeviceBatteryEventArgs>) null;
      switch (type)
      {
        case "DBB":
          objDeviceMethodStore = this.BackButtonEventStore;
          break;
        case "DBC":
          objBatteryMethodStore = this.BatteryCriticalEventStore;
          break;
        case "DBL":
          objBatteryMethodStore = this.BatteryLowEventStore;
          break;
        case "DBS":
          objBatteryMethodStore = this.BatteryStatusEventStore;
          break;
        case "DEC":
          objDeviceMethodStore = this.EndCallButtonEventStore;
          break;
        case "DMB":
          objDeviceMethodStore = this.MenuButtonEventStore;
          break;
        case "DOF":
          objDeviceMethodStore = this.OfflineEventStore;
          break;
        case "DON":
          objDeviceMethodStore = this.OnlineEventStore;
          break;
        case "DPA":
          objDeviceMethodStore = this.PauseEventStore;
          break;
        case "DRE":
          objDeviceMethodStore = this.ResumeEventStore;
          break;
        case "DSB":
          objDeviceMethodStore = this.SearchButtonEventStore;
          break;
        case "DSC":
          objDeviceMethodStore = this.StartCallButtonEventStore;
          break;
        case "DVD":
          objDeviceMethodStore = this.VolumeDownButtonEventStore;
          break;
        case "DVU":
          objDeviceMethodStore = this.VolumeUpButtonEventStore;
          break;
      }
      if (objBatteryMethodStore != null)
      {
        this.RaiseDeviceEvent(DeviceBatteryEventArgs.ParseFromVWGEvent(objEvent), objBatteryMethodStore);
      }
      else
      {
        if (objDeviceMethodStore == null)
          return;
        this.RaiseDeviceEvent(EmptyDeviceEventArgs.ParseFromVWGEvent(objEvent), objDeviceMethodStore);
      }
    }

    /// <summary>Raises the device event.</summary>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs" /> instance containing the event data.</param>
    /// <param name="objDeviceMethodStore">The obj device method store.</param>
    private void RaiseDeviceEvent(
      EmptyDeviceEventArgs objArgs,
      MultipleCallMethodStore<EmptyDeviceEventArgs> objDeviceMethodStore)
    {
      objDeviceMethodStore.InvokeMultipleCallMethods(objArgs);
    }

    /// <summary>Raises the device event.</summary>
    /// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Common.Device.Common.DeviceBatteryEventArgs" /> instance containing the event data.</param>
    /// <param name="objBatteryMethodStore">The obj battery method store.</param>
    private void RaiseDeviceEvent(
      DeviceBatteryEventArgs objArgs,
      MultipleCallMethodStore<DeviceBatteryEventArgs> objBatteryMethodStore)
    {
      objBatteryMethodStore.InvokeMultipleCallMethods(objArgs);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    public override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = new CriticalEventsData();
      if (this.PauseEventStore.HasEventListeners())
        criticalEventsData.Set("DPA");
      if (this.ResumeEventStore.HasEventListeners())
        criticalEventsData.Set("DRE");
      if (this.OnlineEventStore.HasEventListeners())
        criticalEventsData.Set("DON");
      if (this.OfflineEventStore.HasEventListeners())
        criticalEventsData.Set("DOF");
      if (this.BackButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DBB");
      if (this.MenuButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DMB");
      if (this.SearchButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DSB");
      if (this.StartCallButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DSC");
      if (this.EndCallButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DEC");
      if (this.VolumeUpButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DVU");
      if (this.VolumeDownButtonEventStore.HasEventListeners())
        criticalEventsData.Set("DVD");
      if (this.BatteryCriticalEventStore.HasEventListeners())
        criticalEventsData.Set("DBC");
      if (this.BatteryLowEventStore.HasEventListeners())
        criticalEventsData.Set("DBL");
      if (this.BatteryStatusEventStore.HasEventListeners())
        criticalEventsData.Set("DBS");
      return criticalEventsData;
    }
  }
}
