// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.GeoLocationData
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Description("A data which defines the geographic location services.")]
  [TypeConverter(typeof (GeoLocationDataTypeConverter))]
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  [Serializable]
  public class GeoLocationData : ComponentBase
  {
    public static readonly GeoLocationData Empty = new GeoLocationData(false, false, new double?(), new double?());
    private bool mblnRepeatCheck;
    private bool mblnEnableHighAccuracy;
    private double? mdblMaximumAge;
    private double? mdblTimeout;

    /// <summary>Occurs when [geo location data changed].</summary>
    internal event EventHandler GeoLocationDataChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeoLocationData" /> class.
    /// </summary>
    /// <param name="blnRepeatCheck">if set to <c>true</c> [BLN repeat check].</param>
    /// <param name="blnEnableHighAccuracy">if set to <c>true</c> [BLN enable high accuracy].</param>
    /// <param name="dblMaximumAge">The DBL maximum age.</param>
    /// <param name="dblTimeout">The DBL timeout.</param>
    public GeoLocationData(
      bool blnRepeatCheck,
      bool blnEnableHighAccuracy,
      double? dblMaximumAge,
      double? dblTimeout)
    {
      this.mblnRepeatCheck = blnRepeatCheck;
      this.mblnEnableHighAccuracy = blnEnableHighAccuracy;
      this.mdblMaximumAge = dblMaximumAge;
      this.mdblTimeout = dblTimeout;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeoLocationData" /> class.
    /// </summary>
    public GeoLocationData()
    {
    }

    /// <summary>
    /// Gets or sets a value indicating whether [repeat check].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [repeat check]; otherwise, <c>false</c>.
    /// </value>
    [Description("Deifines whether to repeat location changed event.")]
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.All)]
    public bool RepeatCheck
    {
      get => this.mblnRepeatCheck;
      set
      {
        if (this.mblnRepeatCheck == value)
          return;
        this.mblnRepeatCheck = value;
        this.OnGeoLocationDataChanged();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [enable high accuracy].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [enable high accuracy]; otherwise, <c>false</c>.
    /// </value>
    [Description("Deifines whether the geo-location will be enabled with high accuracy.")]
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(false)]
    public bool EnableHighAccuracy
    {
      get => this.mblnEnableHighAccuracy;
      set
      {
        if (this.mblnEnableHighAccuracy == value)
          return;
        this.mblnEnableHighAccuracy = value;
        this.OnGeoLocationDataChanged();
      }
    }

    /// <summary>Gets or sets the maximum age.</summary>
    /// <value>The maximum age.</value>
    [Description("Deifines the geo-location positions maximum age (in milliseconds).")]
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    public double? MaximumAge
    {
      get
      {
        if (this.mdblMaximumAge.HasValue)
        {
          double? mdblMaximumAge = this.mdblMaximumAge;
          double num = 0.0;
          if ((mdblMaximumAge.GetValueOrDefault() < num ? (mdblMaximumAge.HasValue ? 1 : 0) : 0) != 0)
            return new double?(0.0);
        }
        return this.mdblMaximumAge;
      }
      set
      {
        double? mdblMaximumAge = this.mdblMaximumAge;
        double? nullable = value;
        if ((mdblMaximumAge.GetValueOrDefault() == nullable.GetValueOrDefault() ? (mdblMaximumAge.HasValue != nullable.HasValue ? 1 : 0) : 1) == 0)
          return;
        this.mdblMaximumAge = value;
        this.OnGeoLocationDataChanged();
      }
    }

    /// <summary>
    /// Gets a value indicating whether [supports geo location].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [supports geo location]; otherwise, <c>false</c>.
    /// </value>
    private static bool SupportsGeoLocation => VWGContext.Current is IContextParams current && (current.MISCBrowserCapabilities & MISCBrowserCapabilities.Geolocation) == MISCBrowserCapabilities.Geolocation;

    /// <summary>Gets or sets the options.</summary>
    /// <value>The options.</value>
    [Description("Deifines the geo-location timeout for a single position request (in milliseconds).")]
    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(null)]
    public double? Timeout
    {
      get
      {
        if (this.mdblTimeout.HasValue)
        {
          double? mdblTimeout = this.mdblTimeout;
          double num = 0.0;
          if ((mdblTimeout.GetValueOrDefault() < num ? (mdblTimeout.HasValue ? 1 : 0) : 0) != 0)
            return new double?(0.0);
        }
        return this.mdblTimeout;
      }
      set
      {
        double? mdblTimeout = this.mdblTimeout;
        double? nullable = value;
        if ((mdblTimeout.GetValueOrDefault() == nullable.GetValueOrDefault() ? (mdblTimeout.HasValue != nullable.HasValue ? 1 : 0) : 1) == 0)
          return;
        this.mdblTimeout = value;
        this.OnGeoLocationDataChanged();
      }
    }

    /// <summary>Called when [geo location data changed].</summary>
    private void OnGeoLocationDataChanged()
    {
      if (this.GeoLocationDataChanged == null)
        return;
      this.GeoLocationDataChanged((object) this, EventArgs.Empty);
    }

    /// <summary>Resets the repeat check.</summary>
    private void ResetRepeatCheck() => this.RepeatCheck = GeoLocationData.Empty.RepeatCheck;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      StringBuilder objBuilder = new StringBuilder();
      if (this.RepeatCheck)
        this.AppendKey(objBuilder, "RepeatCheck");
      if (this.EnableHighAccuracy)
        this.AppendKey(objBuilder, "EnableHighAccuracy");
      if (this.MaximumAge.HasValue)
        this.AppendKey(objBuilder, string.Format("MaximumAge({0})", (object) this.MaximumAge));
      if (this.Timeout.HasValue)
        this.AppendKey(objBuilder, string.Format("Timeout({0})", (object) this.Timeout));
      return objBuilder.ToString();
    }

    /// <summary>Appends the key.</summary>
    /// <param name="objBuilder">The obj builder.</param>
    /// <param name="strKey">The STR key.</param>
    private void AppendKey(StringBuilder objBuilder, string strKey)
    {
      if (objBuilder.Length > 0)
        objBuilder.Append(",");
      objBuilder.Append(strKey);
    }

    /// <summary>
    /// Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object obj)
    {
      if (!(obj is GeoLocationData geoLocationData))
        return base.Equals(obj);
      if (this.RepeatCheck == geoLocationData.RepeatCheck && this.EnableHighAccuracy == geoLocationData.EnableHighAccuracy)
      {
        double? maximumAge = this.MaximumAge;
        double? nullable = geoLocationData.MaximumAge;
        if ((maximumAge.GetValueOrDefault() == nullable.GetValueOrDefault() ? (maximumAge.HasValue == nullable.HasValue ? 1 : 0) : 0) != 0)
        {
          nullable = this.Timeout;
          double? timeout = geoLocationData.Timeout;
          return nullable.GetValueOrDefault() == timeout.GetValueOrDefault() && nullable.HasValue == timeout.HasValue;
        }
      }
      return false;
    }

    /// <summary>Resets the enable high accuracy.</summary>
    private void ResetEnableHighAccuracy() => this.EnableHighAccuracy = GeoLocationData.Empty.EnableHighAccuracy;

    /// <summary>Resets the maximum age.</summary>
    private void ResetMaximumAge() => this.MaximumAge = new double?();

    /// <summary>Resets the timeout.</summary>
    private void ResetTimeout() => this.Timeout = new double?();
  }
}
