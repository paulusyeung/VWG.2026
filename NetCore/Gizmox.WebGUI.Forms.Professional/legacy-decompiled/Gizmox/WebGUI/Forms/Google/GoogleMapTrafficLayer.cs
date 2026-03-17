using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap layer type for Traffic layer
/// </summary>
[Serializable]
public class GoogleMapTrafficLayer : GoogleMapLayer
{
	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.TrafficLayer;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapTrafficLayer()
	{
	}
}
