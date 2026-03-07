// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.DeviceFile
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  [Serializable]
  public class DeviceFile : DevicePropertyDictionary, IDeviceFile
  {
    public static DeviceFile FromVWGEvent(IEvent objEvent)
    {
      DeviceFile deviceFile = new DeviceFile();
      deviceFile.FullPath = objEvent["fullPath"];
      long result1;
      if (long.TryParse(objEvent["lastModifiedDate"], out result1))
        deviceFile.AddValueTypeProperty<long>("lastModifiedDate", result1);
      deviceFile.Name = objEvent["name"];
      ulong result2;
      if (ulong.TryParse(objEvent["size"], out result2))
        deviceFile.Size = result2;
      deviceFile.Type = objEvent["type"];
      return deviceFile;
    }

    /// <summary>Gets the full path.</summary>
    public string FullPath
    {
      get => this.GetNullableProperty<string>("fullPath");
      internal set => this.SetNullableProperty<string>("fullPath", value);
    }

    /// <summary>Gets the last modified date.</summary>
    public DateTime LastModifiedDate
    {
      get
      {
        long propertyOrDefault = this.GetValuetypePropertyOrDefault<long>("lastModifiedDate");
        return propertyOrDefault != 0L ? new DateTime(propertyOrDefault * 10000L + 621355968000000000L) : DateTime.MinValue;
      }
      internal set => this.AddValueTypeProperty<DateTime>("lastModifiedDate", value);
    }

    /// <summary>Gets the name.</summary>
    public string Name
    {
      get => this.GetNullableProperty<string>("name");
      internal set => this.SetNullableProperty<string>("name", value);
    }

    /// <summary>Gets the size.</summary>
    public ulong Size
    {
      get => this.GetValuetypePropertyOrDefault<ulong>("size");
      internal set => this.AddValueTypeProperty<ulong>("size", value);
    }

    /// <summary>Gets the full path.</summary>
    public string Type
    {
      get => this.GetNullableProperty<string>("type");
      internal set => this.SetNullableProperty<string>("type", value);
    }
  }
}
