// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GeoLocation
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
  public class GeoLocation
  {
    public static GeoLocation Empty = new GeoLocation(0.0, 0.0);
    private double mdblLatitude;
    private double mdblLongitude;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeoLocation" /> class.
    /// </summary>
    /// <param name="dblLatitude">The DBL latitude.</param>
    /// <param name="dblLongitude">The DBL longitude.</param>
    public GeoLocation(double dblLatitude, double dblLongitude)
    {
      this.mdblLatitude = dblLatitude;
      this.mdblLongitude = dblLongitude;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeoLocation" /> class.
    /// </summary>
    public GeoLocation()
    {
    }

    /// <summary>Gets or sets the latitude.</summary>
    /// <value>The latitude.</value>
    public double Latitude
    {
      get => this.mdblLatitude;
      set => this.mdblLatitude = value;
    }

    /// <summary>Gets or sets the longitude.</summary>
    /// <value>The longitude.</value>
    public double Longitude
    {
      get => this.mdblLongitude;
      set => this.mdblLongitude = value;
    }
  }
}
