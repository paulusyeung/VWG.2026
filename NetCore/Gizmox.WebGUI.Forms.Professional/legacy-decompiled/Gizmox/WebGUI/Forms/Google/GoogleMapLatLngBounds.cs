using System;

namespace Gizmox.WebGUI.Forms.Google;

[Serializable]
public class GoogleMapLatLngBounds
{
	/// <summary>
	/// Internal value for Empty bounds
	/// </summary>
	internal static GoogleMapLatLngBounds mobjEmptyBounds = new GoogleMapLatLngBounds();

	/// <summary>
	/// South West corner of the bounds
	/// </summary>
	internal GoogleMapLocation mobjSouthWest;

	/// <summary>
	/// North East corner of the bounds
	/// </summary>
	internal GoogleMapLocation mobjNorthEast;

	/// <summary>
	/// The South West corner of bounds
	/// </summary>
	[SRDescription("The South West corner of bounds")]
	public GoogleMapLocation SouthWest
	{
		get
		{
			return mobjSouthWest;
		}
		set
		{
			mobjSouthWest = value;
		}
	}

	/// <summary>
	/// The North East corner of bounds
	/// </summary>
	[SRDescription("The North East corner of bounds")]
	public GoogleMapLocation NorthEast
	{
		get
		{
			return mobjNorthEast;
		}
		set
		{
			mobjNorthEast = value;
		}
	}

	/// <summary>
	/// Empty bounds
	/// </summary>
	public static GoogleMapLatLngBounds Empty => mobjEmptyBounds;

	/// <summary>
	/// Initializes a new empty instance
	/// </summary>
	public GoogleMapLatLngBounds()
	{
		mobjSouthWest = GoogleMapLocation.Empty;
		mobjNorthEast = GoogleMapLocation.Empty;
	}

	/// <summary>
	/// Initializes an instance with given SW and NE corner of the bounds.
	/// </summary>
	/// <param name="objSouthWest">The South West corner of bounds as GoogleMapLocation</param>
	/// <param name="objNorthEast">The North East corner of bounds as GoogleMapLocation</param>
	public GoogleMapLatLngBounds(GoogleMapLocation objSouthWest, GoogleMapLocation objNorthEast)
	{
		mobjSouthWest = objSouthWest;
		mobjNorthEast = objNorthEast;
	}

	/// <summary>
	/// Initializes an instance from given GoogleMapLatLngBounds
	/// </summary>
	/// <param name="objBounds"></param>
	public GoogleMapLatLngBounds(GoogleMapLatLngBounds objBounds)
	{
		mobjSouthWest = objBounds.SouthWest;
		mobjNorthEast = objBounds.NorthEast;
	}
}
