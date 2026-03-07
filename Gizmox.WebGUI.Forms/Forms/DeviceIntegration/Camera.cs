// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Camera
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Camera;
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
  public class Camera : DeviceComponent, ICamera
  {
    private SingleCallMethodStore<CameraEventArgs> mobjCameraMethodStore;
    private SingleCallMethodStore<CleanupEventArgs> mobjClearMethodStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Camera" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public Camera(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Camera_Initialize", (object) this.ID);
    }

    /// <summary>
    /// Cleans up the image files that were taken by the camera, that were stored in a temporary storage location.
    /// </summary>
    /// <param name="objCallback">The obj callback.</param>
    public void Cleanup(Action<CleanupEventArgs> objCallback)
    {
      if (this.mobjClearMethodStore == null)
        this.mobjClearMethodStore = new SingleCallMethodStore<CleanupEventArgs>();
      this.Invoke("DeviceIntegrator.Camera.cleanup", (object) this.mobjClearMethodStore.StoreSingleCallMethod("cln", objCallback));
    }

    /// <summary>Gets A picture with given options.</summary>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void GetPicture(Action<CameraEventArgs> objCallback, CameraOptions objOptions)
    {
      if (this.mobjCameraMethodStore == null)
        this.mobjCameraMethodStore = new SingleCallMethodStore<CameraEventArgs>();
      string str = this.mobjCameraMethodStore.StoreSingleCallMethod("pic", objCallback);
      IClientJsonObject clientJsonObject = (IClientJsonObject) null;
      if (objOptions != null)
        clientJsonObject = CommonUtils.GetClientJsonObject((object) objOptions);
      this.Invoke("DeviceIntegrator.Camera.getPicture", (object) str, (object) clientJsonObject);
    }

    /// <summary>Gets a picture with default options.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetPicture(Action<CameraEventArgs> objCallback) => this.GetPicture(objCallback, (CameraOptions) null);

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "CAM";

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      this.HandleEvent(objEvent);
    }

    private void HandleEvent(IEvent objEvent)
    {
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      switch (keyValuePair.Key)
      {
        case "pic":
          CameraEventArgs argumentsFromEvent = this.GetCameraArgumentsFromEvent(objEvent);
          if (!this.mobjCameraMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjCameraMethodStore.InvokeSingleCallMethod(keyValuePair.Value, argumentsFromEvent);
          break;
        case "cln":
          CleanupEventArgs cleanupEventArgs = this.GetCleanupEventArgs(objEvent);
          if (!this.mobjClearMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjClearMethodStore.InvokeSingleCallMethod(keyValuePair.Value, cleanupEventArgs);
          break;
      }
    }

    /// <summary>Gets the cleanup event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private CleanupEventArgs GetCleanupEventArgs(IEvent objEvent)
    {
      CleanupEventArgs objEventArgs = (CleanupEventArgs) null;
      if (!CameraBaseEventArgs.TryGetCameraError<CleanupEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new CleanupEventArgs();
      return objEventArgs;
    }

    /// <summary>Gets the camera arguments from event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private CameraEventArgs GetCameraArgumentsFromEvent(IEvent objEvent)
    {
      CameraEventArgs objEventArgs = (CameraEventArgs) null;
      if (!CameraBaseEventArgs.TryGetCameraError<CameraEventArgs>(objEvent, out objEventArgs))
      {
        string strDataUrl = objEvent.Value;
        string strFileUri = objEvent["FileUri"];
        if (!string.IsNullOrEmpty(strDataUrl) || !string.IsNullOrEmpty(strFileUri))
          objEventArgs = new CameraEventArgs(strFileUri, strDataUrl);
      }
      return objEventArgs;
    }
  }
}
