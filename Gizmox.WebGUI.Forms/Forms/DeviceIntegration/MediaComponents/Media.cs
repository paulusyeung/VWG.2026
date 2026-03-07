// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class Media : IMedia
  {
    private DeviceMedia mobjDeviceMedia;
    private string mstrSource;
    private long mlngLastModified;
    private float mfltDuration = -1f;
    private EventHandler<MediaEventArgs> mobjSuccessCallback;
    private EventHandler<EmptyDeviceEventArgs> mobjErrorCallback;
    private EventHandler<MediaStateEventArgs> mobjMediaStateCallback;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents.Media" /> class.
    /// </summary>
    /// <param name="strSource">The STR source.</param>
    /// <param name="objDeviceMedia">The obj device media.</param>
    public Media(string strSource, DeviceMedia objDeviceMedia)
    {
      this.mstrSource = strSource;
      this.mobjDeviceMedia = objDeviceMedia;
      this.mlngLastModified = DateTime.Now.Ticks;
    }

    /// <summary>Occurs when [compass heading changed].</summary>
    public event Action<MediaPositionEventArgs> PositionChanged
    {
      add => this.mobjDeviceMedia.AddPositionChanged(this, value);
      remove
      {
        this.mobjDeviceMedia.RemovePositionChanged(this, value);
        this.Update();
      }
    }

    /// <summary>Gets the id.</summary>
    public string Id => this.GetHashCode().ToString();

    /// <summary>Gets the source.</summary>
    public string Source => this.mstrSource;

    /// <summary>Plays this instance.</summary>
    public void Play() => this.mobjDeviceMedia.Play(this);

    /// <summary>Updates this instance.</summary>
    internal void Update()
    {
      this.mobjDeviceMedia.Update();
      this.mlngLastModified = DateTime.Now.Ticks;
    }

    /// <summary>Pauses this instance.</summary>
    public void Pause() => this.mobjDeviceMedia.Pause(this);

    /// <summary>Stops this instance.</summary>
    public void Stop() => this.mobjDeviceMedia.Stop(this);

    /// <summary>Releases this instance.</summary>
    public void Release() => this.mobjDeviceMedia.Release(this);

    /// <summary>Seeks to.</summary>
    /// <param name="lngMilliseconds">The LNG milliseconds.</param>
    public void SeekTo(ulong lngMilliseconds) => this.mobjDeviceMedia.SeekTo(this, lngMilliseconds);

    /// <summary>Gets the current position.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetCurrentPosition(EventHandler<MediaPositionEventArgs> objCallback) => this.mobjDeviceMedia.GetCurrentPosition(this, objCallback);

    /// <summary>Gets the duration.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public float Duration
    {
      get => this.mfltDuration;
      internal set => this.mfltDuration = value;
    }

    /// <summary>Starts the record.</summary>
    public void StartRecord() => this.mobjDeviceMedia.StartRecord(this);

    /// <summary>Stops the record.</summary>
    public void StopRecord() => this.mobjDeviceMedia.StopRecord(this);

    /// <summary>Sets the success event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetSuccessEvent(EventHandler<MediaEventArgs> objCallback)
    {
      this.Update();
      this.mobjSuccessCallback = objCallback;
    }

    /// <summary>Sets the error event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
    {
      this.Update();
      this.mobjErrorCallback = objCallback;
    }

    /// <summary>Sets the state change event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetStateChangeEvent(EventHandler<MediaStateEventArgs> objCallback)
    {
      this.Update();
      this.mobjMediaStateCallback = objCallback;
    }

    /// <summary>Handles the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    internal void HandleEvent(IEvent objEvent)
    {
      switch (objEvent.Member.ToLower())
      {
        case "success":
          if (this.mobjSuccessCallback == null)
            break;
          this.mobjSuccessCallback((object) this, new MediaEventArgs((IMedia) this));
          break;
        case "error":
          if (this.mobjErrorCallback == null)
            break;
          EmptyDeviceEventArgs objEventArgs;
          DeviceEventArgs.TryGetError<EmptyDeviceEventArgs>(objEvent, out objEventArgs);
          this.mobjErrorCallback((object) this, objEventArgs);
          break;
        case "state":
          int result;
          if (this.mobjMediaStateCallback == null || !int.TryParse(objEvent["state"], out result))
            break;
          this.mobjMediaStateCallback((object) this, new MediaStateEventArgs(result));
          break;
        default:
          throw new Exception();
      }
    }

    /// <summary>
    /// Determines whether the specified LNG request ID is dirty.
    /// </summary>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <returns>
    ///   <c>true</c> if the specified LNG request ID is dirty; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsDirty(long lngRequestID) => lngRequestID < this.mlngLastModified;

    /// <summary>Gets the success data.</summary>
    /// <returns></returns>
    internal object GetSuccessData() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjSuccessCallback);

    /// <summary>Gets the error data.</summary>
    /// <returns></returns>
    internal object GetErrorData() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjErrorCallback);

    /// <summary>Gets the state data.</summary>
    /// <returns></returns>
    internal object GetStateData() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjMediaStateCallback);
  }
}
