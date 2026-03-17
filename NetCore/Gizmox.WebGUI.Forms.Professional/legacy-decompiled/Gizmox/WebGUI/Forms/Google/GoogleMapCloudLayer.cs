using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap type for Cloud layer
/// </summary>
[Serializable]
public class GoogleMapCloudLayer : GoogleMapLayer
{
	/// <summary>
	/// The type of the layer
	/// </summary>
	[SRDescription("The type of the layer.")]
	public override GoogleMapLayerType LayerType => GoogleMapLayerType.CloudLayer;

	/// <summary>
	/// Initializes a new object
	/// </summary>
	public GoogleMapCloudLayer()
	{
	}
}
