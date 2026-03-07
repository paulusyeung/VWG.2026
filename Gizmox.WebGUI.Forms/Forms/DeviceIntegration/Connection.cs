// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Connection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Connection;
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
  public class Connection : DeviceComponent, IConnection
  {
    /// <summary>Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<ConnectionEventArgs> mobjSingleCallMethodStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Connection" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public Connection(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<ConnectionEventArgs> SingleCallMethodStore
    {
      get
      {
        if (this.mobjSingleCallMethodStore == null)
          this.mobjSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<ConnectionEventArgs>();
        return this.mobjSingleCallMethodStore;
      }
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "CTY";

    /// <summary>Gets the arguments from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private ConnectionEventArgs GetArgumentsFromEvent(IEvent objEvent)
    {
      ConnectionEventArgs objEventArgs = (ConnectionEventArgs) null;
      if (!DeviceEventArgs.TryGetError<ConnectionEventArgs>(objEvent, out objEventArgs) && objEvent["NetworkState"] != null)
        objEventArgs = new ConnectionEventArgs(objEvent["NetworkState"].ToString());
      return objEventArgs;
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Connection_Initialize", (object) this.ID);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      ConnectionEventArgs argumentsFromEvent = this.GetArgumentsFromEvent(objEvent);
      if (argumentsFromEvent == null || string.IsNullOrEmpty(type) || !this.SingleCallMethodStore.HasRegisteredMethod(type))
        return;
      this.SingleCallMethodStore.InvokeSingleCallMethod(type, argumentsFromEvent);
    }

    /// <summary>Gets the connection.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetConnection(Action<ConnectionEventArgs> objCallback) => this.Invoke("DeviceIntegrator.Connection.getConnection", (object) this.SingleCallMethodStore.StoreSingleCallMethod(objCallback));
  }
}
