using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs type for LatLngBounds information
/// </summary>
[Serializable]
public class GoogleMapLatLngBoundsEventArgs : EventArgs
{
	private GoogleMapLatLngBounds mobjBounds;

	/// <summary>
	/// The Bounds
	/// </summary>
	public GoogleMapLatLngBounds Bounds => mobjBounds;

	/// <summary>
	/// Initializes a new object with a GoogleMapLatLngBounds
	/// </summary>
	/// <param name="objLocation"></param>
	public GoogleMapLatLngBoundsEventArgs(GoogleMapLatLngBounds objBounds)
	{
		mobjBounds = objBounds;
	}
}
