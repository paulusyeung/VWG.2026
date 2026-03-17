using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs type of GoogleMapLayer related events
/// </summary>
[Serializable]
public class GoogleMapLayerEventArgs : EventArgs
{
	private GoogleMapLayer mobjLayer;

	private GoogleMapLocation mobjLocation;

	/// <summary>
	/// The layer which is the target of the event
	/// </summary>
	public GoogleMapLayer Layer
	{
		get
		{
			return mobjLayer;
		}
		set
		{
			mobjLayer = value;
		}
	}

	/// <summary>
	/// The location on the map where the event occurred
	/// </summary>
	public GoogleMapLocation Location
	{
		get
		{
			return mobjLocation;
		}
		set
		{
			mobjLocation = value;
		}
	}

	/// <summary>
	/// Iinitializes the instance from parameters
	/// </summary>
	/// <param name="objLayer">The GoogleMapLayer which is the target of the event</param>
	/// <param name="objLocation">The location on the map where the event occurred</param>
	public GoogleMapLayerEventArgs(GoogleMapLayer objLayer, GoogleMapLocation objLocation)
	{
		mobjLocation = objLocation;
		mobjLayer = objLayer;
	}
}
