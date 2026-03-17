using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap layer type for Bicycling Layer
/// </summary>
[Serializable]
public class GoogleMapBicyclingLayer : GoogleMapLayer
{
	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.BicyclingLayer;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapBicyclingLayer()
	{
	}
}
