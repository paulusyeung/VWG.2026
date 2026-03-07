// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Notifications
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class Notifications : DeviceComponent, INotifications
  {
    private SingleCallMethodStore<EmptyDeviceEventArgs> mobjAlertStore;
    private SingleCallMethodStore<ConfirmEventArgs> mobjConfirmStore;
    private SingleCallMethodStore<EmptyDeviceEventArgs> mobjBeepStore;
    private SingleCallMethodStore<EmptyDeviceEventArgs> mobjVibrateStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Notifications" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public Notifications(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "NTF";

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      switch (keyValuePair.Key)
      {
        case "alert":
          EmptyDeviceEventArgs args1 = new EmptyDeviceEventArgs();
          if (!this.mobjAlertStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjAlertStore.InvokeSingleCallMethod(keyValuePair.Value, args1);
          break;
        case "confirm":
          int result;
          if (!int.TryParse(objEvent["ButtonIndex"], out result))
            break;
          ConfirmEventArgs args2 = new ConfirmEventArgs(result);
          this.mobjConfirmStore.InvokeSingleCallMethod(keyValuePair.Value, args2);
          break;
        case "beep":
          this.mobjBeepStore.InvokeSingleCallMethod(keyValuePair.Value, new EmptyDeviceEventArgs());
          break;
        case "vibrate":
          this.mobjVibrateStore.InvokeSingleCallMethod(keyValuePair.Value, new EmptyDeviceEventArgs());
          break;
      }
    }

    /// <summary>Alerts the specified STR message.</summary>
    /// <param name="strMessage">The STR message.</param>
    public void Alert(string strMessage) => this.Alert(strMessage, (AlertOptions) null, this.mobjAlertStore.StoreSingleCallMethod("alert", this.GetNullAction<EmptyDeviceEventArgs>()));

    /// <summary>Alerts the specified STR message.</summary>
    /// <param name="strMessage">The STR message.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void Alert(
      string strMessage,
      AlertOptions objOptions,
      Action<EmptyDeviceEventArgs> objCallback)
    {
      if (this.mobjAlertStore == null)
        this.mobjAlertStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
      this.Alert(strMessage, objOptions, this.mobjAlertStore.StoreSingleCallMethod("alert", objCallback));
    }

    /// <summary>Alerts the specified STR message.</summary>
    /// <param name="strMessage">The STR message.</param>
    /// <param name="fncCallback">The FNC callback.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="arrCallbackParams">The arr callback params.</param>
    private void Alert(string strMessage, AlertOptions objOptions, string fncCallback) => this.Invoke("DeviceIntegrator.Notifications.alert", (object) strMessage, (object) fncCallback, (object) CommonUtils.GetClientJsonObject((object) objOptions));

    /// <summary>Confirms the specified STR message.</summary>
    /// <param name="strMessage">The STR message.</param>
    public void Confirm(string strMessage) => this.Confirm(strMessage, (ConfirmOptions) null, this.GetNullAction<ConfirmEventArgs>());

    /// <summary>Confrims the specified STR message.</summary>
    /// <param name="strMessage">The STR message.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void Confirm(
      string strMessage,
      ConfirmOptions objOptions,
      Action<ConfirmEventArgs> objCallback)
    {
      if (this.mobjConfirmStore == null)
        this.mobjConfirmStore = new SingleCallMethodStore<ConfirmEventArgs>();
      this.Confirm(strMessage, objOptions, this.mobjConfirmStore.StoreSingleCallMethod("confirm", objCallback));
    }

    /// <summary>Confirms the specified STR message.</summary>
    /// <param name="strMessage">The STR message.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="fncCallback">The FNC callback.</param>
    /// <param name="arrCallbackParams">The arr callback params.</param>
    private void Confirm(string strMessage, ConfirmOptions objOptions, string fncCallback) => this.Invoke("DeviceIntegrator.Notifications.confirm", (object) strMessage, (object) fncCallback, (object) CommonUtils.GetClientJsonObject((object) objOptions));

    /// <summary>Beeps the specified int times.</summary>
    /// <param name="intTimes">The int times.</param>
    public void Beep(int intTimes) => this.Beep(intTimes, this.GetNullAction<EmptyDeviceEventArgs>());

    /// <summary>Beeps the specified int times.</summary>
    /// <param name="intTimes">The int times.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void Beep(int intTimes, Action<EmptyDeviceEventArgs> objCallback)
    {
      if (this.mobjBeepStore == null)
        this.mobjBeepStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
      this.Beep(intTimes, this.mobjBeepStore.StoreSingleCallMethod("beep", objCallback));
    }

    /// <summary>Beeps the specified int times.</summary>
    /// <param name="intTimes">The int times.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="fncCallback">The FNC callback.</param>
    /// <param name="arrCallbackParams">The arr callback params.</param>
    public void Beep(int intTimes, string fncCallback) => this.SingleNumericParameterInvoker("beep", intTimes, fncCallback);

    /// <summary>Vibrates the specified int duiration in milliseconds.</summary>
    /// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
    public void Vibrate(int intDuirationInMilliseconds) => this.Vibrate(intDuirationInMilliseconds, this.GetNullAction<EmptyDeviceEventArgs>());

    /// <summary>Beeps the specified int times.</summary>
    /// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void Vibrate(int intDuirationInMilliseconds, Action<EmptyDeviceEventArgs> objCallback)
    {
      if (this.mobjVibrateStore == null)
        this.mobjVibrateStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
      this.Vibrate(intDuirationInMilliseconds, this.mobjVibrateStore.StoreSingleCallMethod("vibrate", objCallback));
    }

    /// <summary>Beeps the specified int times.</summary>
    /// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="fncCallback">The FNC callback.</param>
    /// <param name="arrCallbackParams">The arr callback params.</param>
    private void Vibrate(int intDuirationInMilliseconds, string fncCallback) => this.SingleNumericParameterInvoker("vibrate", intDuirationInMilliseconds, fncCallback);

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Notifications_Initialize", (object) this.ID);
    }

    /// <summary>Singles the numeric parameter invoker.</summary>
    /// <param name="strFunction">The STR function.</param>
    /// <param name="intNumericParameter">The int numeric parameter.</param>
    /// <param name="objClientContext">The obj client context.</param>
    /// <param name="fncCallback">The FNC callback.</param>
    /// <param name="arrCallbackParams">The arr callback params.</param>
    private void SingleNumericParameterInvoker(
      string strFunction,
      int intNumericParameter,
      string fncCallback)
    {
      object[] objArray = new object[2]
      {
        (object) intNumericParameter,
        (object) fncCallback
      };
      this.Invoke(string.Format("DeviceIntegrator.Notifications.{0}", (object) strFunction), objArray);
    }

    /// <summary>
    /// This method is used just for preventing conflicting between overload methods.
    /// </summary>
    private Action<T> GetNullAction<T>() => (Action<T>) null;
  }
}
