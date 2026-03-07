// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Compass
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  [Serializable]
  public class Compass : WatchedDeviceComponent, ICompass
  {
    private const int INTERNAL_ERROR = 0;
    private const int COMPASS_UNSUPPORTED = 20;
    /// <summary>Compass single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<CompassEventArgs> mobjSingleCallMethodStore;
    /// <summary>Compass multiple-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<CompassEventArgs> mobjMultipleCallMethodStore;

    /// <summary>Gets the single call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<CompassEventArgs> SingleCallMethodStore
    {
      get
      {
        if (this.mobjSingleCallMethodStore == null)
          this.mobjSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<CompassEventArgs>();
        return this.mobjSingleCallMethodStore;
      }
    }

    /// <summary>Gets the multiple call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<CompassEventArgs> MultipleCallMethodStore
    {
      get
      {
        if (this.mobjMultipleCallMethodStore == null)
          this.mobjMultipleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.MultipleCallMethodStore<CompassEventArgs>();
        return this.mobjMultipleCallMethodStore;
      }
    }

    public Compass(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Occurs when [compass heading changed].</summary>
    public event Action<CompassEventArgs> HeadingChanged
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
    /// Raises the <see cref="E:CompassHeadingChanged" /> event.
    /// </summary>
    /// <param name="objArguments">The <see cref="T:Gizmox.WebGUI.Common.Device.Compass.CompassEventArgs" /> instance containing the event data.</param>
    private void OnHeadingChanged(CompassEventArgs objArguments) => this.MultipleCallMethodStore.InvokeMultipleCallMethods(objArguments);

    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      CompassEventArgs argumentsFromEvent = this.GetArgumentsFromEvent(objEvent);
      if (argumentsFromEvent == null)
        return;
      if (type == "CMP")
      {
        this.OnHeadingChanged(argumentsFromEvent);
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
    private CompassEventArgs GetArgumentsFromEvent(IEvent objEvent)
    {
      CompassEventArgs objEventArgs = (CompassEventArgs) null;
      if (!DeviceEventArgs.TryGetError<CompassEventArgs>(objEvent, out objEventArgs))
      {
        string empty = string.Empty;
        double dblValue1;
        double dblValue2;
        double dblValue3;
        if (objEvent["magneticHeading"] != null && CommonUtils.TryParse(objEvent["magneticHeading"], out dblValue1) && objEvent["trueHeading"] != null && CommonUtils.TryParse(objEvent["trueHeading"], out dblValue2) && objEvent["headingAccuracy"] != null && CommonUtils.TryParse(objEvent["magneticHeading"], out dblValue3))
        {
          if (objEvent["timeStamp"] != null)
            empty = objEvent["timeStamp"];
          objEventArgs = new CompassEventArgs(dblValue1, dblValue2, dblValue3, empty);
        }
      }
      return objEventArgs;
    }

    /// <summary>Gets the compass heading.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetCurrentHeading(Action<CompassEventArgs> objCallback) => this.Invoke("DeviceIntegrator.Compass.getCurrentHeading", (object) this.SingleCallMethodStore.StoreSingleCallMethod(objCallback));

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Compass_Initialize", (object) this.ID);
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
    protected internal override string GetTag() => "CMP";

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    public override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = new CriticalEventsData();
      if (this.MultipleCallMethodStore.HasEventListeners())
        criticalEventsData.Set("DCO");
      return criticalEventsData;
    }
  }
}
