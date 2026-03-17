using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// An enumeration for animation style when marker is added to map
/// </summary>
[Serializable]
public enum GoogleMapMarkerAnimationType
{
	/// <summary>
	/// No animation when adding marker
	/// </summary>
	None,
	/// <summary>
	/// Marker falls from the top of the map ending with a small bounce.
	/// </summary>
	Drop,
	/// <summary>
	/// Marker bounces until animation is stopped.
	/// </summary>
	Bounce
}
