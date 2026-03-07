// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Accelerometer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class Accelerometer : WatchedDeviceComponent, IAccelerometer
  {
    /// <summary>Accelerometer single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<AccelerometerEventArgs> mobjSingleCallMethodStore;
    /// <summary>Accelerometer multiple-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<AccelerometerEventArgs> mobjMultipleCallMethodStore;

    /// <summary>Gets the Accelerometer single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<AccelerometerEventArgs> SingleCallMethodStore
    {
      get
      {
        if (this.mobjSingleCallMethodStore == null)
          this.mobjSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<AccelerometerEventArgs>();
        return this.mobjSingleCallMethodStore;
      }
    }

    /// <summary>Gets the Accelerometer multiple-call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<AccelerometerEventArgs> MultipleCallMethodStore
    {
      get
      {
        if (this.mobjMultipleCallMethodStore == null)
          this.mobjMultipleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<AccelerometerEventArgs>();
        return this.mobjMultipleCallMethodStore;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Accelerometer" /> class.
    /// </summary>
    /// <param name="objMobileIntegrator">The obj mobile integrator.</param>
    public Accelerometer(DeviceIntegrator objMobileIntegrator)
      : base(objMobileIntegrator)
    {
    }

    /// <summary>Gets the acceleration.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetCurrentAcceleration(Action<AccelerometerEventArgs> objCallback) => this.Invoke("DeviceIntegrator.Accelerometer.getCurrentAcceleration", (object) this.SingleCallMethodStore.StoreSingleCallMethod(objCallback));

    /// <summary>Gets the arguments from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private AccelerometerEventArgs GetArgumentsFromEvent(IEvent objEvent)
    {
      AccelerometerEventArgs objEventArgs = (AccelerometerEventArgs) null;
      if (!DeviceEventArgs.TryGetError<AccelerometerEventArgs>(objEvent, out objEventArgs))
      {
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        double dblValue1;
        double dblValue2;
        double dblValue3;
        if (objEvent["X"] != null && objEvent["Y"] != null && objEvent["Z"] != null && CommonUtils.TryParse(objEvent["X"], out dblValue1) && CommonUtils.TryParse(objEvent["Y"], out dblValue2) && CommonUtils.TryParse(objEvent["Z"], out dblValue3))
        {
          if (objEvent["timeStamp"] != null)
            empty1 = objEvent["timeStamp"];
          objEventArgs = new AccelerometerEventArgs(dblValue1, dblValue2, dblValue3, empty1);
        }
      }
      return objEventArgs;
    }

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      AccelerometerEventArgs argumentsFromEvent = this.GetArgumentsFromEvent(objEvent);
      if (argumentsFromEvent == null)
        return;
      if (type == "ACC")
      {
        this.OnAccelerationChanged(argumentsFromEvent);
      }
      else
      {
        if (string.IsNullOrEmpty(type) || !this.SingleCallMethodStore.HasRegisteredMethod(type))
          return;
        this.SingleCallMethodStore.InvokeSingleCallMethod(type, argumentsFromEvent);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:AccelerationChanged" /> event.
    /// </summary>
    /// <param name="objArguments">The <see cref="T:Gizmox.WebGUI.Common.Device.Accelerometer.AccelerometerEventArgs" /> instance containing the event data.</param>
    private void OnAccelerationChanged(AccelerometerEventArgs objArguments) => this.MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);

    /// <summary>Occurs when [acceleration changed].</summary>
    public event Action<AccelerometerEventArgs> AccelerationChanged
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

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    public override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = new CriticalEventsData();
      if (this.MultipleCallMethodStore.HasEventListeners())
        criticalEventsData.Set("DAC");
      return criticalEventsData;
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Accelerometer_Initialize", (object) this.ID);
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
    protected internal override string GetTag() => "ACC";
  }
}
