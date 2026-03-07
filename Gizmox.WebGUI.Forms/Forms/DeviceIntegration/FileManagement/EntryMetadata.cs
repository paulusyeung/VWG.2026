// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.EntryMetadata
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  [Serializable]
  public class EntryMetadata : DevicePropertyDictionary, IMetadata
  {
    internal static EntryMetadata CreateFromVWGEvent(IEvent objEvent) => new EntryMetadata()
    {
      ModificationTime = DateTime.ParseExact(objEvent["modificationTime"].Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture)
    };

    public DateTime ModificationTime
    {
      get => this.GetValuetypePropertyOrDefault<DateTime>("modificationTime");
      set => this.AddValueTypeProperty<DateTime>("modificationTime", value);
    }
  }
}
