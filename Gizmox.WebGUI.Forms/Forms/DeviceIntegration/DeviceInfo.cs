// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.DeviceInfo
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  [Serializable]
  public class DeviceInfo : DeviceComponent, IDeviceInfo
  {
    /// <summary>Single call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<DeviceInfoEventArgs> mobjSingleCallMethodStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.WatchedDeviceComponent" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public DeviceInfo(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Gets the single call method store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<DeviceInfoEventArgs> SingleCallMethodStore
    {
      get
      {
        if (this.mobjSingleCallMethodStore == null)
          this.mobjSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<DeviceInfoEventArgs>();
        return this.mobjSingleCallMethodStore;
      }
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "DIN";

    /// <summary>Gets the arguments from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private DeviceInfoEventArgs GetArgumentsFromEvent(IEvent objEvent)
    {
      DeviceInfoEventArgs objEventArgs = (DeviceInfoEventArgs) null;
      if (!DeviceEventArgs.TryGetError<DeviceInfoEventArgs>(objEvent, out objEventArgs) && objEvent["Name"] != null && objEvent["JavascriptVersion"] != null && objEvent["Platform"] != null && objEvent["UUID"] != null && objEvent["Version"] != null)
        objEventArgs = new DeviceInfoEventArgs(objEvent["Name"].ToString(), objEvent["JavascriptVersion"].ToString(), objEvent["Platform"].ToString(), objEvent["UUID"].ToString(), objEvent["Version"].ToString());
      return objEventArgs;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      DeviceInfoEventArgs argumentsFromEvent = this.GetArgumentsFromEvent(objEvent);
      if (argumentsFromEvent == null || string.IsNullOrEmpty(type) || !this.SingleCallMethodStore.HasRegisteredMethod(type))
        return;
      this.SingleCallMethodStore.InvokeSingleCallMethod(type, argumentsFromEvent);
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("DeviceInfo_Initialize", (object) this.ID);
    }

    /// <summary>Gets the device info.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetDeviceInfo(Action<DeviceInfoEventArgs> objCallback) => this.Invoke("DeviceIntegrator.DeviceInfo.getDeviceInfo", (object) this.SingleCallMethodStore.StoreSingleCallMethod(objCallback));
  }
}
