// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Geolocation
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class Geolocation : WatchedDeviceComponent, IGeolocation
  {
    private const int PERMISSION_DENIED = 1;
    private const int POSITION_UNAVAILABLE = 2;
    private const int TIMEOUT = 3;
    /// <summary>Geolocation single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GeolocationEventArgs> mobjSingleCallMethodStore;
    /// <summary>Geolocation multiple-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<GeolocationEventArgs> mobjMultipleCallMethodStore;

    /// <summary>Gets the single call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GeolocationEventArgs> SingleCallMethodStore
    {
      get
      {
        if (this.mobjSingleCallMethodStore == null)
          this.mobjSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GeolocationEventArgs>();
        return this.mobjSingleCallMethodStore;
      }
    }

    /// <summary>Gets the multiple call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<GeolocationEventArgs> MultipleCallMethodStore
    {
      get
      {
        if (this.mobjMultipleCallMethodStore == null)
          this.mobjMultipleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<GeolocationEventArgs>();
        return this.mobjMultipleCallMethodStore;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Geolocation" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public Geolocation(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Occurs when [Geolocation position changed].</summary>
    public event Action<GeolocationEventArgs> PositionChanged
    {
      add
      {
        this.MultipleCallMethodStore.AddMultipleCallMethod(value);
        this.Update();
      }
      remove
      {
        this.MultipleCallMethodStore.RemoveMultipleCallMethod(value);
        this.Update();
      }
    }

    /// <summary>
    /// Raises the <see cref="E:PositionChanged" /> event.
    /// </summary>
    /// <param name="objArguments">The <see cref="T:Gizmox.WebGUI.Common.Device.Geolocation.GeolocationEventArgs" /> instance containing the event data.</param>
    private void OnPositionChanged(GeolocationEventArgs objArguments) => this.MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      GeolocationEventArgs argumentsFromEvent = this.GetArgumentsFromEvent(objEvent);
      if (argumentsFromEvent == null)
        return;
      if (type == "GPS")
      {
        this.OnPositionChanged(argumentsFromEvent);
      }
      else
      {
        if (string.IsNullOrEmpty(type) || !this.SingleCallMethodStore.HasRegisteredMethod(type))
          return;
        this.SingleCallMethodStore.InvokeSingleCallMethod(type, argumentsFromEvent);
      }
    }

    /// <summary>Gets the arguments from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GeolocationEventArgs GetArgumentsFromEvent(IEvent objEvent)
    {
      GeolocationEventArgs objEventArgs = (GeolocationEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GeolocationEventArgs>(objEvent, out objEventArgs))
      {
        string empty = string.Empty;
        objEventArgs = new GeolocationEventArgs();
        double dblValue1;
        if (objEvent["latitude"] != null && CommonUtils.TryParse(objEvent["latitude"], out dblValue1))
          objEventArgs.Latitude = dblValue1;
        double dblValue2;
        if (objEvent["longitude"] != null && CommonUtils.TryParse(objEvent["longitude"], out dblValue2))
          objEventArgs.Longitude = dblValue2;
        double dblValue3;
        if (objEvent["altitude"] != null && CommonUtils.TryParse(objEvent["altitude"], out dblValue3))
          objEventArgs.Altitude = dblValue3;
        double dblValue4;
        if (objEvent["altitudeAccuracy"] != null && CommonUtils.TryParse(objEvent["altitudeAccuracy"], out dblValue4))
          objEventArgs.AltitudeAccuracy = dblValue4;
        double dblValue5;
        if (objEvent["accuracy"] != null && CommonUtils.TryParse(objEvent["accuracy"], out dblValue5))
          objEventArgs.Accuracy = dblValue5;
        double dblValue6;
        if (objEvent["heading"] != null && CommonUtils.TryParse(objEvent["heading"], out dblValue6))
          objEventArgs.Heading = dblValue6;
        double dblValue7;
        if (objEvent["speed"] != null && CommonUtils.TryParse(objEvent["speed"], out dblValue7))
          objEventArgs.Speed = dblValue7;
      }
      return objEventArgs;
    }

    /// <summary>Gets the Geolocation position with default options.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetPosition(Action<GeolocationEventArgs> objCallback) => this.Invoke("DeviceIntegrator.Geolocation.getPosition", new ArrayList()
    {
      (object) this.SingleCallMethodStore.StoreSingleCallMethod(objCallback)
    }.ToArray());

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Geolocation_Initialize", (object) this.ID);
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
    protected internal override string GetTag() => "GPS";

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    public override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = new CriticalEventsData();
      if (this.MultipleCallMethodStore.HasEventListeners())
        criticalEventsData.Set("DGE");
      return criticalEventsData;
    }
  }
}
