using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration for the layer types available for GoogleMap
/// </summary>
[Serializable]
public enum GoogleMapLayerType
{
	/// <summary>
	/// Bicycling layer
	/// </summary>
	BicyclingLayer,
	/// <summary>
	/// KML layer
	/// </summary>
	KmlLayer,
	/// <summary>
	/// Traffic layer
	/// </summary>
	TrafficLayer,
	/// <summary>
	/// Transit layer
	/// </summary>
	TransitLayer,
	/// <summary>
	/// Cloud layer
	/// </summary>
	CloudLayer,
	/// <summary>
	/// Weather layer
	/// </summary>
	WeatherLayer,
	/// <summary>
	/// Heatmap layer
	/// </summary>
	HeatmapLayer
}
