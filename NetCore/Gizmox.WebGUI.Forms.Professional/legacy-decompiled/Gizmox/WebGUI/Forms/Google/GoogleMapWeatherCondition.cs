using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// Weather condition information for Weather layer
/// </summary>
[Serializable]
public class GoogleMapWeatherCondition
{
	private string mstrDay;

	private string mstrDescription;

	private double mdblHigh;

	private double mdblHumidity;

	private double mdblLow;

	private string mstrShortDay;

	private double mdblTemperature;

	private string mstrWindDirection;

	private double mdblWindSpeed;

	/// <summary>
	/// The lowest temperature reached during the day.
	/// </summary>
	public double Low
	{
		get
		{
			return mdblLow;
		}
		set
		{
			mdblLow = value;
		}
	}

	/// <summary>
	/// The current day of the week in short form, e.g. "M".
	/// </summary>
	public string ShortDay
	{
		get
		{
			return mstrShortDay;
		}
		set
		{
			mstrShortDay = value;
		}
	}

	/// <summary>
	/// The current temperature, in the specified temperature units.
	/// </summary>
	public double Temperature
	{
		get
		{
			return mdblTemperature;
		}
		set
		{
			mdblTemperature = value;
		}
	}

	/// <summary>
	/// The current wind direction.
	/// </summary>
	public string WindDirection
	{
		get
		{
			return mstrWindDirection;
		}
		set
		{
			mstrWindDirection = value;
		}
	}

	/// <summary>
	/// The current wind speed, in the specified wind speed units.
	/// </summary>
	public double WindSpeed
	{
		get
		{
			return mdblWindSpeed;
		}
		set
		{
			mdblWindSpeed = value;
		}
	}

	/// <summary>
	/// The current humidity, expressed as a percentage.
	/// </summary>
	public double Humidity
	{
		get
		{
			return mdblHumidity;
		}
		set
		{
			mdblHumidity = value;
		}
	}

	/// <summary>
	/// The highest temperature reached during the day.
	/// </summary>
	public double High
	{
		get
		{
			return mdblHigh;
		}
		set
		{
			mdblHigh = value;
		}
	}

	/// <summary>
	/// A description of the conditions, e.g. "Partly Cloudy".
	/// </summary>
	public string Description
	{
		get
		{
			return mstrDescription;
		}
		set
		{
			mstrDescription = value;
		}
	}

	/// <summary>
	/// The current day of the week in long form, e.g. "Monday".
	/// </summary>
	public string Day
	{
		get
		{
			return mstrDay;
		}
		set
		{
			mstrDay = value;
		}
	}

	/// <summary>
	/// Initialize instance from parameters
	/// </summary>
	/// <param name="strDay">The current day of the week in long form, e.g. "Monday".</param>
	/// <param name="strDescription">A description of the conditions, e.g. "Partly Cloudy".</param>
	/// <param name="dblHigh">The highest temperature reached during the day.</param>
	/// <param name="dblHumidity">The current humidity, expressed as a percentage.</param>
	/// <param name="dblLow">The lowest temperature reached during the day.</param>
	/// <param name="strShortDay">The current day of the week in short form, e.g. "M".</param>
	/// <param name="dblTemperature">The current temperature, in the specified temperature units.</param>
	/// <param name="strWindDirection">The current wind direction.</param>
	/// <param name="dblWindSpeed">The current wind speed, in the specified wind speed units.</param>
	public GoogleMapWeatherCondition(string strDay, string strDescription, double dblHigh, double dblHumidity, double dblLow, string strShortDay, double dblTemperature, string strWindDirection, double dblWindSpeed)
	{
		mstrDay = strDay;
		mstrDescription = strDescription;
		mdblHigh = dblHigh;
		mdblHumidity = dblHumidity;
		mdblLow = dblLow;
		mstrShortDay = strShortDay;
		mdblTemperature = dblTemperature;
		mstrWindDirection = strWindDirection;
		mdblWindSpeed = dblWindSpeed;
	}
}
