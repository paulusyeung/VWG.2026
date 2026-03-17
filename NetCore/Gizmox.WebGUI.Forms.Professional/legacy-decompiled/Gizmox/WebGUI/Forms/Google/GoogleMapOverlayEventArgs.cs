using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs type for GoogleMapOverlay related events.
/// </summary>
[Serializable]
public class GoogleMapOverlayEventArgs : EventArgs
{
	private GoogleMapOverlay mobjOverlay;

	private GoogleMapLocation mobjLocation;

	/// <summary>
	/// The Overlay which is the target of the event
	/// </summary>
	public GoogleMapOverlay Overlay => mobjOverlay;

	/// <summary>
	/// Location where the event occurred on the Map
	/// </summary>
	public GoogleMapLocation Location => mobjLocation;

	/// <summary>
	/// Initializes the instance from parameters
	/// </summary>
	/// <param name="objOverlay">The GoogleMapOverlay which is the target of the event</param>
	/// <param name="objLocation">The location on the map where the event occurred</param>
	public GoogleMapOverlayEventArgs(GoogleMapOverlay objOverlay, GoogleMapLocation objLocation)
	{
		mobjOverlay = objOverlay;
		mobjLocation = objLocation;
	}
}
