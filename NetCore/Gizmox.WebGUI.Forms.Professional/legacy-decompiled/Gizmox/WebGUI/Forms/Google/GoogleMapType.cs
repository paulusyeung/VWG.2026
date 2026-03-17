using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration of map types that can be applied to a google map
/// </summary>
[Serializable]
public enum GoogleMapType
{
	/// <summary>
	/// RoadMap maptype
	/// </summary>
	RoadMap,
	/// <summary>
	/// Hybrid maptype
	/// </summary>
	Hybrid,
	/// <summary>
	/// Satellite maptype
	/// </summary>
	Satellite,
	/// <summary>
	/// Terrain maptype
	/// </summary>
	Terrain,
	/// <summary>
	/// OpenStreatMap maptype
	/// </summary>
	OpenStreatMap
}
