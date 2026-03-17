using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs type for Location information
/// </summary>
[Serializable]
public class GoogleMapLocationEventArgs : EventArgs
{
	private GoogleMapLocation mobjLocation;

	private string mstrAddress;

	private bool mblnIsLocation;

	/// <summary>
	/// The Location
	/// </summary>
	public GoogleMapLocation Location => mobjLocation;

	/// <summary>
	/// The Address
	/// </summary>
	public string Address => mstrAddress;

	/// <summary>
	/// Does the instance hold a Location (not address)
	/// </summary>
	public bool isLocation => mblnIsLocation;

	/// <summary>
	/// Does the instance hold an address (not location)
	/// </summary>
	public bool isAddress => !mblnIsLocation;

	/// <summary>
	/// Initializes a new object with a GoogleMapLocation (address is blanked)
	/// </summary>
	/// <param name="objLocation"></param>
	public GoogleMapLocationEventArgs(GoogleMapLocation objLocation)
	{
		mobjLocation = objLocation;
		mstrAddress = string.Empty;
		mblnIsLocation = true;
	}

	/// <summary>
	/// Initializes a new object with address (location is blanked)
	/// </summary>
	/// <param name="strAddress"></param>
	public GoogleMapLocationEventArgs(string strAddress)
	{
		mobjLocation = GoogleMapLocation.Empty;
		mstrAddress = strAddress;
		mblnIsLocation = false;
	}

	/// <summary>
	/// Initializes a new object after GEOfind with an Address and a GoogleMapLocation if address is valid and found.
	/// </summary>
	/// <param name="objLocation"></param>
	public GoogleMapLocationEventArgs(string strAddress, GoogleMapLocation objLocation, bool blnIsValidAddress)
	{
		mstrAddress = strAddress;
		mobjLocation = objLocation;
		mblnIsLocation = blnIsValidAddress;
	}
}
