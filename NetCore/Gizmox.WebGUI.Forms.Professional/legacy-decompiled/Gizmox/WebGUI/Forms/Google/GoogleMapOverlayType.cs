using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration of Overlay types available for GoogleMap
/// </summary>
[Serializable]
public enum GoogleMapOverlayType
{
	/// <summary>
	/// Marker overlay (points of interest)
	/// </summary>
	MarkerOverlay,
	/// <summary>
	/// Polyline overlay (one path)
	/// </summary>
	PolylineOverlay,
	/// <summary>
	/// Polygon overlay (multiple paths)
	/// </summary>
	PolygonOverlay,
	/// <summary>
	/// Rectangle overlay
	/// </summary>
	RectangleOverlay,
	/// <summary>
	/// Circle overlay
	/// </summary>
	CircleOverlay,
	/// <summary>
	/// Ground overlay (Image from Url)
	/// </summary>
	GroundOverlay,
	/// <summary>
	/// Information window overlay
	/// </summary>
	InfoWindowOverlay
}
