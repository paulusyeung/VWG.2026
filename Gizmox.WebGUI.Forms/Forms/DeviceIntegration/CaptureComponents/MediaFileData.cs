// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents.MediaFileData
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class MediaFileData : IMediaFileData
  {
    private string mstrCodecs;
    private ulong mlngBitrate;
    private ulong mlngHeight;
    private ulong mlngWidth;
    private ulong mlngDuration;

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    internal static MediaFileData FromVWGEvent(IEvent objEvent)
    {
      MediaFileData mediaFileData = new MediaFileData();
      mediaFileData.mstrCodecs = objEvent["codecs"];
      ulong.TryParse(objEvent["bitrate"], out mediaFileData.mlngBitrate);
      ulong.TryParse(objEvent["height"], out mediaFileData.mlngHeight);
      ulong.TryParse(objEvent["width"], out mediaFileData.mlngWidth);
      ulong.TryParse(objEvent["duration"], out mediaFileData.mlngDuration);
      return mediaFileData;
    }

    /// <summary>Gets the codecs.</summary>
    public string Codecs
    {
      get => this.mstrCodecs;
      internal set => this.mstrCodecs = value;
    }

    /// <summary>Gets the bitrate.</summary>
    public ulong Bitrate
    {
      get => this.mlngBitrate;
      internal set => this.mlngBitrate = value;
    }

    /// <summary>Gets the height.</summary>
    public ulong Height
    {
      get => this.mlngHeight;
      internal set => this.mlngHeight = value;
    }

    /// <summary>Gets the width.</summary>
    public ulong Width
    {
      get => this.mlngWidth;
      internal set => this.mlngWidth = value;
    }

    /// <summary>Gets the duration.</summary>
    public ulong Duration
    {
      get => this.mlngDuration;
      internal set => this.mlngDuration = value;
    }
  }
}
