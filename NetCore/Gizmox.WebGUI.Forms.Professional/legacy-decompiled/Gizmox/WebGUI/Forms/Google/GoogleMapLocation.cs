using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Provides a class for specifiying google map location
/// </summary>
[Serializable]
[TypeConverter(typeof(GoogleMapLocationConverter))]
public class GoogleMapLocation
{
	/// <summary>
	///
	/// </summary>
	internal double mintLongitude;

	/// <summary>
	///
	/// </summary>
	internal double mintLatitude;

	/// <summary>
	///
	/// </summary>
	internal static GoogleMapLocation mobjEmpty = new GoogleMapLocation();

	/// <summary>
	/// Gets or sets the Longitude.
	/// </summary>
	/// <value>The longitude.</value>
	[SRCategory("Location")]
	[SRDescription("The Longitude")]
	public double Longitude
	{
		get
		{
			return mintLongitude;
		}
		set
		{
			mintLongitude = value;
		}
	}

	/// <summary>
	/// Gets or sets the latitude.
	/// </summary>
	/// <value>The latitude.</value>
	[SRCategory("Location")]
	[SRDescription("The Latitude")]
	public double Latitude
	{
		get
		{
			return mintLatitude;
		}
		set
		{
			mintLatitude = value;
		}
	}

	/// <summary>
	/// Gets the empty location instance
	/// </summary>
	/// <value>The empty location.</value>
	public static GoogleMapLocation Empty => mobjEmpty;

	/// <summary>
	/// Initializes a new empty location instance
	/// </summary>
	public GoogleMapLocation()
	{
		mintLongitude = 0.0;
		mintLatitude = 0.0;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapLocation" /> class.
	/// </summary>
	/// <param name="intLatitude">The latitude.</param>
	/// <param name="intLongitude">The longitude.</param>
	public GoogleMapLocation(double intLatitude, double intLongitude)
	{
		mintLongitude = intLongitude;
		mintLatitude = intLatitude;
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
	/// <returns>
	/// true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
	/// </returns>
	/// <exception cref="T:System.NullReferenceException">
	/// The <paramref name="obj" /> parameter is null.
	/// </exception>
	public override bool Equals(object obj)
	{
		if (obj is GoogleMapLocation)
		{
			GoogleMapLocation googleMapLocation = (GoogleMapLocation)obj;
			if (googleMapLocation.Latitude == Latitude && googleMapLocation.Longitude == Longitude)
			{
				return true;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Latitude, Longitude);
	}
}
