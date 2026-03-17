using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// A GoogleMapLocation class that adds Weight for the location. 
/// </summary>
[Serializable]
public class GoogleMapWeightedLocation : GoogleMapLocation
{
	private double mdblWeight;

	/// <summary>
	/// The weight of the location point
	/// </summary>
	/// <value>The Weight of the point</value>
	[SRCategory("Weight")]
	[SRDescription("The weight of the location point")]
	public double Weight
	{
		get
		{
			return mdblWeight;
		}
		set
		{
			mdblWeight = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapLocation" /> class.
	/// </summary>
	private GoogleMapWeightedLocation()
	{
		mdblWeight = 0.0;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Google.GoogleMapLocation" /> class.
	/// </summary>
	/// <param name="intLatitude">The latitude.</param>
	/// <param name="intLongitude">The longitude.</param>
	/// <param name="dblWeight">The Weight of the point</param>
	public GoogleMapWeightedLocation(double intLatitude, double intLongitude, double dblWeight)
	{
		mintLongitude = intLongitude;
		mintLatitude = intLatitude;
		mdblWeight = dblWeight;
	}

	public override bool Equals(object obj)
	{
		if (obj is GoogleMapWeightedLocation)
		{
			GoogleMapWeightedLocation googleMapWeightedLocation = (GoogleMapWeightedLocation)obj;
			if (googleMapWeightedLocation.Latitude == base.Latitude && googleMapWeightedLocation.Longitude == base.Longitude && googleMapWeightedLocation.Weight == Weight)
			{
				return true;
			}
		}
		return false;
	}
}
