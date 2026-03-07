// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents.MediaFile
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Newtonsoft.Json.Linq;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class MediaFile : IMediaFile
  {
    private Gizmox.WebGUI.Forms.DeviceIntegration.Capture mobjCaptureComponent;
    private string mstrName;
    private string mstrFullPath;
    private string mstrType;
    private DateTime mobjLastModifiedDate;
    private ulong mlngSize;

    /// <summary>Parses from VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objCaptureComponent">The obj capture component.</param>
    /// <returns></returns>
    internal static IMediaFile[] ParseFromVWGEvent(IEvent objEvent, Gizmox.WebGUI.Forms.DeviceIntegration.Capture objCaptureComponent)
    {
      int result;
      if (string.IsNullOrEmpty(objEvent["count"]) || !int.TryParse(objEvent["count"], out result))
        return (IMediaFile[]) null;
      IMediaFile[] fromVwgEvent = new IMediaFile[result];
      for (int index = 0; index < result; ++index)
      {
        string strJSON = objEvent["cap" + (object) index];
        if (!string.IsNullOrEmpty(strJSON))
        {
          JObject jobject = JsonUtils.Deserialize(strJSON);
          fromVwgEvent[index] = (IMediaFile) new MediaFile(objCaptureComponent)
          {
            Name = jobject.Value<string>((object) "name"),
            FullPath = jobject.Value<string>((object) "fullPath"),
            Type = jobject.Value<string>((object) "type"),
            LastModifiedDate = jobject.Value<DateTime>((object) "lastModifiedDate"),
            Size = jobject.Value<ulong>((object) "size")
          };
        }
      }
      return fromVwgEvent;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents.MediaFile" /> class.
    /// </summary>
    /// <param name="objCaptureComponent">The obj capture component.</param>
    public MediaFile(Gizmox.WebGUI.Forms.DeviceIntegration.Capture objCaptureComponent) => this.mobjCaptureComponent = objCaptureComponent;

    /// <summary>Gets the name.</summary>
    public string Name
    {
      get => this.mstrName;
      internal set => this.mstrName = value;
    }

    /// <summary>Gets the full path.</summary>
    public string FullPath
    {
      get => this.mstrFullPath;
      internal set => this.mstrFullPath = value;
    }

    /// <summary>Gets the type.</summary>
    public string Type
    {
      get => this.mstrType;
      internal set => this.mstrType = value;
    }

    /// <summary>Gets the last modified date.</summary>
    public DateTime LastModifiedDate
    {
      get => this.mobjLastModifiedDate;
      internal set => this.mobjLastModifiedDate = value;
    }

    /// <summary>Gets the size.</summary>
    public ulong Size
    {
      get => this.mlngSize;
      internal set => this.mlngSize = value;
    }

    /// <summary>Gets the format data.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void GetFormatData(EventHandler<MediaFileDataEventArgs> objCallback) => this.mobjCaptureComponent.GetFormatData(this, objCallback);
  }
}
