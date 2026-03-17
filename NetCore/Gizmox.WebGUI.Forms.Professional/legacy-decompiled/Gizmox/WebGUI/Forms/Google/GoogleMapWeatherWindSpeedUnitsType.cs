using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Wind speed units for Weather layer
/// </summary>
[Serializable]
public enum GoogleMapWeatherWindSpeedUnitsType
{
	/// <summary>
	/// Units in Meters per Second
	/// </summary>
	MetersPerSecond,
	/// <summary>
	/// Units in Kilometers per Hour
	/// </summary>
	KilometersPerHour,
	/// <summary>
	/// Units in Miles per Hour
	/// </summary>
	MilesPerHour
}
