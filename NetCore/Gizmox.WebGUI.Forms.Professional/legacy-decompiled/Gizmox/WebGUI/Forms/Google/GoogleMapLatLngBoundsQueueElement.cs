using System;

namespace Gizmox.WebGUI.Forms.Google;

[Serializable]
internal class GoogleMapLatLngBoundsQueueElement : GoogleMapLatLngBounds
{
	/// <summary>
	/// How to handle current bounds of the control. Used internally by the rendering process
	/// </summary>
	internal enum BoundsUpdateType
	{
		/// <summary>
		/// Bounds should not be updated to Map (already synched, received by onBoundsChanged etc.)
		/// </summary>
		None,
		/// <summary>
		/// Bounds should be updated by calling FitBounds on Map
		/// </summary>
		Fit,
		/// <summary>
		/// Bounds should be updated by calling PanToBounds on Map
		/// </summary>
		Pan,
		/// <summary>
		/// Extend current bounds to contain location and Pan
		/// </summary>
		PanLocation,
		/// <summary>
		/// Extend current bounds to contain location and Fit
		/// </summary>
		FitLocation
	}

	/// <summary>
	/// How should current bounds of Map be handled on next update
	/// </summary>
	internal BoundsUpdateType menmBoundsUpdateType;

	/// <summary>
	/// Initializes an ToPan/ToFit instance with given SW and NE corner of the bounds.
	/// ToPan / ToFit for internal use by Rendering to notify control of method used to set bounds.
	/// </summary>
	/// <param name="objSouthWest">The South West corner of bounds as GoogleMapLocation</param>
	/// <param name="objNorthEast">The North East corner of bounds as GoogleMapLocation</param>
	/// <param name="enmBoundsUpdateType">How to update the Map control with these bounds on next update</param>
	internal GoogleMapLatLngBoundsQueueElement(GoogleMapLocation objSouthWest, GoogleMapLocation objNorthEast, BoundsUpdateType enmBoundsUpdateType)
	{
		mobjSouthWest = objSouthWest;
		mobjNorthEast = objNorthEast;
		menmBoundsUpdateType = enmBoundsUpdateType;
	}
}
