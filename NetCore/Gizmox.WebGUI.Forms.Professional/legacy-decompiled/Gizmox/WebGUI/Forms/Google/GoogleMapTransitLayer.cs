using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap layer type for Transit layer
/// </summary>
[Serializable]
public class GoogleMapTransitLayer : GoogleMapLayer
{
	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.TransitLayer;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapTransitLayer()
	{
	}
}
