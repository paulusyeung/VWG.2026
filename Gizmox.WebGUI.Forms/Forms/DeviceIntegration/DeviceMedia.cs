// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.DeviceMedia
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  [Serializable]
  public class DeviceMedia : WatchedDeviceComponent, IDeviceMedia
  {
    private Dictionary<string, Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media> mobjIdMediaMap = new Dictionary<string, Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media>();
    private List<KeyValuePair<string, object[]>> mobjClientMethodsInvocationBuffer;
    private SingleCallMethodStore<MediaPositionEventArgs> mobjMediaPositionEventArgsStore;
    private SingleCallMethodStore<MediaEventArgs> mobjMediaEventArgsStore;
    private Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>> mobjMediaIdPositionChangedStoreMap = new Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>>();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.DeviceMedia" /> class.
    /// </summary>
    /// <param name="objIntegrator">The obj integrator.</param>
    public DeviceMedia(DeviceIntegrator objIntegrator)
      : base(objIntegrator)
    {
    }

    private MultipleCallMethodStore<MediaPositionEventArgs> GetPositionChangedStore(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia)
    {
      MultipleCallMethodStore<MediaPositionEventArgs> positionChangedStore = (MultipleCallMethodStore<MediaPositionEventArgs>) null;
      if (!this.mobjMediaIdPositionChangedStoreMap.TryGetValue(objMedia.Id, out positionChangedStore))
      {
        positionChangedStore = new MultipleCallMethodStore<MediaPositionEventArgs>();
        this.mobjMediaIdPositionChangedStoreMap.Add(objMedia.Id, positionChangedStore);
      }
      return positionChangedStore;
    }

    /// <summary>Gets the media position event args store.</summary>
    internal SingleCallMethodStore<MediaPositionEventArgs> MediaPositionEventArgsStore
    {
      get
      {
        if (this.mobjMediaPositionEventArgsStore == null)
          this.mobjMediaPositionEventArgsStore = new SingleCallMethodStore<MediaPositionEventArgs>();
        return this.mobjMediaPositionEventArgsStore;
      }
    }

    /// <summary>Gets the media event args store.</summary>
    internal SingleCallMethodStore<MediaEventArgs> MediaEventArgsStore
    {
      get
      {
        if (this.mobjMediaEventArgsStore == null)
          this.mobjMediaEventArgsStore = new SingleCallMethodStore<MediaEventArgs>();
        return this.mobjMediaEventArgsStore;
      }
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "DMA";

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (objEvent.Type == "Duration")
      {
        float num = float.Parse(objEvent["dur"]);
        this.mobjIdMediaMap[objEvent["mid"]].Duration = num;
      }
      else if (objEvent.Type == "Position")
      {
        string str1 = objEvent["mediaIdsPositionData"];
        if (string.IsNullOrEmpty(str1))
          return;
        string str2 = str1;
        string[] separator1 = new string[1]{ "," };
        foreach (string str3 in str2.Split(separator1, StringSplitOptions.RemoveEmptyEntries))
        {
          string[] separator2 = new string[1]{ "-" };
          string[] strArray = str3.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
          this.OnPositionChanged(this.mobjIdMediaMap[strArray[0]], new MediaPositionEventArgs(float.Parse(strArray[1])));
        }
      }
      else
      {
        KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
        if (keyValuePair.Key == null)
        {
          Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media media;
          if (!this.mobjIdMediaMap.TryGetValue(objEvent.Type, out media))
            return;
          media.HandleEvent(objEvent);
        }
        else
        {
          switch (keyValuePair.Key)
          {
            case "pos":
              float fltValue1;
              if (!CommonUtils.TryParse(objEvent["pos"], out fltValue1))
                break;
              MediaPositionEventArgs args = new MediaPositionEventArgs(fltValue1);
              this.mobjMediaPositionEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args);
              break;
            case "dur":
              float fltValue2;
              if (!CommonUtils.TryParse(objEvent["dur"], out fltValue2))
                break;
              this.mobjIdMediaMap[keyValuePair.Value].Duration = fltValue2;
              break;
            default:
              throw new Exception();
          }
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:OnPositionChanged" /> event.
    /// </summary>
    private void OnPositionChanged(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia, MediaPositionEventArgs objArguments) => this.GetPositionChangedStore(objMedia).InvokeMultipleCallMethods(objArguments);

    /// <summary>Creates a media.</summary>
    /// <param name="strSource">The STR source.</param>
    /// <returns></returns>
    public IMedia CreateMedia(string strSource)
    {
      this.Update();
      Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media media = new Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media(strSource, this);
      this.mobjIdMediaMap.Add(media.GetHashCode().ToString(), media);
      return (IMedia) media;
    }

    /// <summary>Plays the specified obj media.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void Play(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia) => this.Invoke("DeviceIntegrator.Media.playBack", (object) "play", (object) objMedia.GetHashCode().ToString());

    /// <summary>Pauses the specified obj media.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void Pause(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia) => this.Invoke("DeviceIntegrator.Media.playBack", (object) "pause", (object) objMedia.GetHashCode().ToString());

    /// <summary>Stops the specified obj media.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void Stop(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia) => this.Invoke("DeviceIntegrator.Media.playBack", (object) "stop", (object) objMedia.GetHashCode().ToString());

    /// <summary>Releases the specified obj media.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void Release(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia) => this.Invoke("DeviceIntegrator.Media.release", (object) objMedia.GetHashCode().ToString());

    /// <summary>Seeks to.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="lngMilliseconds">The LNG milliseconds.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void SeekTo(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia, ulong lngMilliseconds) => this.Invoke("DeviceIntegrator.Media.seek", (object) objMedia.GetHashCode().ToString(), (object) lngMilliseconds);

    /// <summary>Renders the sub components.</summary>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Media_Initialize", (object) this.ID);
      foreach (Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia in this.mobjIdMediaMap.Values)
      {
        if (objMedia.IsDirty(lngRequestID))
          this.RenderMedia(objMedia, objContext, objWriter);
      }
      if (this.mobjClientMethodsInvocationBuffer == null)
        return;
      foreach (KeyValuePair<string, object[]> keyValuePair in this.mobjClientMethodsInvocationBuffer)
        VWGClientContext.Current.Invoke(keyValuePair.Key, keyValuePair.Value);
      this.mobjClientMethodsInvocationBuffer.Clear();
      this.mobjClientMethodsInvocationBuffer = (List<KeyValuePair<string, object[]>>) null;
    }

    /// <summary>Renders the media.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderMedia(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia, IContext objContext, IResponseWriter objWriter)
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      if (objMedia.GetSuccessData() != null)
        flag1 = true;
      if (objMedia.GetErrorData() != null)
        flag2 = true;
      if (objMedia.GetStateData() != null)
        flag3 = true;
      bool flag4 = false;
      if (this.mobjMediaIdPositionChangedStoreMap.ContainsKey(objMedia.Id))
        flag4 = true;
      VWGClientContext.Current.Invoke((ISkinable) this.DeviceIntegrator, "Media_InitializeMedia", (object) objMedia.Id, (object) objMedia.Source, (object) flag1, (object) flag2, (object) flag3, (object) flag4);
    }

    /// <summary>Renders the attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    internal override void RenderAttributes(IContext objContext, IResponseWriter objWriter)
    {
      IAttributeWriter attributeWriter = objWriter as IAttributeWriter;
      if (!this.GetCriticalEventsData().HasEvents)
        return;
      attributeWriter.WriteAttributeString("E", this.GetCriticalEventsData().ToClientString());
    }

    public void AddPositionChanged(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia, Action<MediaPositionEventArgs> objAction)
    {
      this.GetPositionChangedStore(objMedia).AddMultipleCallMethod(objAction);
      objMedia.Update();
    }

    public void RemovePositionChanged(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia, Action<MediaPositionEventArgs> objAction)
    {
      MultipleCallMethodStore<MediaPositionEventArgs> positionChangedStore = this.GetPositionChangedStore(objMedia);
      positionChangedStore.RemoveMultipleCallMethod(objAction);
      if (!positionChangedStore.HasEventListeners())
        this.mobjMediaIdPositionChangedStoreMap.Remove(objMedia.Id);
      objMedia.Update();
    }

    /// <summary>Gets the current position.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objCallback">The obj callback.</param>
    internal void GetCurrentPosition(
      Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia,
      EventHandler<MediaPositionEventArgs> objCallback)
    {
      this.Invoke("DeviceIntegrator.Media.getCurrentPosition", (object) objMedia.GetHashCode().ToString(), (object) this.MediaPositionEventArgsStore.StoreContextualSingleCallMethod((object) objMedia, "pos", objCallback));
    }

    /// <summary>Starts the record.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void StartRecord(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia) => this.Invoke("DeviceIntegrator.Media.playBack", (object) "startRecord", (object) objMedia.GetHashCode().ToString());

    /// <summary>Stops the record.</summary>
    /// <param name="objMedia">The obj media.</param>
    /// <param name="objClientContext">The obj client context.</param>
    internal void StopRecord(Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media objMedia) => this.Invoke("DeviceIntegrator.Media.playBack", (object) "stopRecord", (object) objMedia.GetHashCode().ToString());

    public override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = new CriticalEventsData();
      foreach (MultipleCallMethodStore<MediaPositionEventArgs> multipleCallMethodStore in this.mobjMediaIdPositionChangedStoreMap.Values)
      {
        if (multipleCallMethodStore.HasEventListeners())
          criticalEventsData.Set("DMP");
      }
      return criticalEventsData;
    }
  }
}
