// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Capture
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  [Serializable]
  public class Capture : DeviceComponent, ICapture
  {
    private SingleCallMethodStore<CaptureEventArgs> mobjCaptureEventArgsStore;
    private SingleCallMethodStore<MediaFileDataEventArgs> mobjMediaFileDataEventArgsStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Capture" /> class.
    /// </summary>
    /// <param name="objPhonegapIntegrator">The obj phonegap integrator.</param>
    public Capture(DeviceIntegrator objPhonegapIntegrator)
      : base(objPhonegapIntegrator)
    {
    }

    /// <summary>Gets the capture event args store.</summary>
    internal SingleCallMethodStore<CaptureEventArgs> CaptureEventArgsStore
    {
      get
      {
        if (this.mobjCaptureEventArgsStore == null)
          this.mobjCaptureEventArgsStore = new SingleCallMethodStore<CaptureEventArgs>();
        return this.mobjCaptureEventArgsStore;
      }
    }

    /// <summary>Gets the media file data event args store.</summary>
    internal SingleCallMethodStore<MediaFileDataEventArgs> MediaFileDataEventArgsStore
    {
      get
      {
        if (this.mobjMediaFileDataEventArgsStore == null)
          this.mobjMediaFileDataEventArgsStore = new SingleCallMethodStore<MediaFileDataEventArgs>();
        return this.mobjMediaFileDataEventArgsStore;
      }
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "CAP";

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Capture_Initialize", (object) this.ID);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      if (string.IsNullOrEmpty(keyValuePair.Key))
      {
        CaptureEventArgs captureEventArgs = this.GetCaptureEventArgs(objEvent);
        this.mobjCaptureEventArgsStore.InvokeSingleCallMethod(objEvent.Type, captureEventArgs);
      }
      else
      {
        if (!(keyValuePair.Key == "for"))
          return;
        MediaFileDataEventArgs fileDataEventArgs = this.CreateMediaFileDataEventArgs(objEvent);
        this.MediaFileDataEventArgsStore.InvokeContextualMethod(keyValuePair.Value, fileDataEventArgs);
      }
    }

    /// <summary>Creates the media file data event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private MediaFileDataEventArgs CreateMediaFileDataEventArgs(IEvent objEvent)
    {
      MediaFileDataEventArgs objEventArgs;
      if (!DeviceEventArgs.TryGetError<MediaFileDataEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new MediaFileDataEventArgs((IMediaFileData) MediaFileData.FromVWGEvent(objEvent));
      return objEventArgs;
    }

    /// <summary>Gets the capture event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private CaptureEventArgs GetCaptureEventArgs(IEvent objEvent)
    {
      CaptureEventArgs objEventArgs;
      return !DeviceEventArgs.TryGetError<CaptureEventArgs>(objEvent, out objEventArgs) ? new CaptureEventArgs(MediaFile.ParseFromVWGEvent(objEvent, this)) : objEventArgs;
    }

    /// <summary>Captures the audio.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void CaptureAudio(Action<CaptureEventArgs> objCallback) => this.CaptureAudio((AudioCaptureOptions) null, objCallback);

    /// <summary>Captures the audio.</summary>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void CaptureAudio(AudioCaptureOptions objOptions, Action<CaptureEventArgs> objCallback) => this.CaptureOnline("captureAudio", (DevicePropertyDictionary) objOptions, objCallback);

    /// <summary>Captures the image.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void CaptureImage(Action<CaptureEventArgs> objCallback) => this.CaptureImage((ImageCaptureOptions) null, objCallback);

    /// <summary>Captures the image.</summary>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void CaptureImage(ImageCaptureOptions objOptions, Action<CaptureEventArgs> objCallback) => this.CaptureOnline("captureImage", (DevicePropertyDictionary) objOptions, objCallback);

    /// <summary>Captures the video.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void CaptureVideo(Action<CaptureEventArgs> objCallback) => this.CaptureVideo((VideoCaptureOptions) null, objCallback);

    /// <summary>Captures the video.</summary>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void CaptureVideo(VideoCaptureOptions objOptions, Action<CaptureEventArgs> objCallback) => this.CaptureOnline("captureVideo", (DevicePropertyDictionary) objOptions, objCallback);

    /// <summary>Captures the online.</summary>
    /// <param name="strCaptureType">Type of the STR capture.</param>
    /// <param name="objOptions">The obj options.</param>
    /// <param name="objCallback">The obj callback.</param>
    private void CaptureOnline(
      string strCaptureType,
      DevicePropertyDictionary objOptions,
      Action<CaptureEventArgs> objCallback)
    {
      this.Invoke("DeviceIntegrator.Capture.capture", (object) strCaptureType, (object) this.CaptureEventArgsStore.StoreSingleCallMethod(objCallback), (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    /// <summary>Gets the format data.</summary>
    /// <param name="objMediaFile">The obj media file.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void GetFormatData(
      MediaFile objMediaFile,
      EventHandler<MediaFileDataEventArgs> objCallback)
    {
      this.Invoke("DeviceIntegrator.Capture.getFormatData", (object) this.MediaFileDataEventArgsStore.StoreContextualSingleCallMethod((object) objMediaFile, "for", objCallback), (object) objMediaFile.FullPath, (object) objMediaFile.Type);
    }
  }
}
