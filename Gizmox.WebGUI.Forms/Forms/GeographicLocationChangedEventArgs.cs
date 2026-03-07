// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GeographicLocationChangedEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class GeographicLocationChangedEventArgs : EventArgs
  {
    private GeoLocation mobjLocation = GeoLocation.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeographicLocationChangedEventArgs" /> class.
    /// </summary>
    /// <param name="objGeoPosition">The obj geo position.</param>
    public GeographicLocationChangedEventArgs(GeoLocation objGeoPosition) => this.mobjLocation = objGeoPosition;

    /// <summary>Gets or sets the location.</summary>
    /// <value>The location.</value>
    public GeoLocation Location
    {
      get => this.mobjLocation;
      set => this.mobjLocation = value;
    }
  }
}
